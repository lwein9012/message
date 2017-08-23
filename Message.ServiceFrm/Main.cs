using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Message.Model;
using Message.ServiceFrm.Handler;

namespace Message.ServiceFrm
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        CancellationTokenSource source;
        private Dictionary<string, List<SubMsg>> SubMsgs = GetSubMsgs();
        private void Start_Btn_Click(object sender, EventArgs e) {
            source = new CancellationTokenSource();
            var token = source.Token;
            this.Start_Btn.Enabled = false;
            this.Stop_Btn.Enabled = true;
            var task = new Task(() =>
            {
                while (true)
                {
                    if (token.IsCancellationRequested)
                    {
                        this.AppendText("推送服务已停止");
                        break;
                    }
                    if (!TaskHelper.CanAddTask)
                    {
                        Thread.Sleep(5 * 1000);
                        continue;
                    }
                    var msg = ServerManager.ServerHelper.GetQueueImp.PopMsg();
                    if (msg == null)
                    {
                        Thread.Sleep(5 * 1000);
                        continue;
                    }
                    var key = string.Format("{0}.{1}", msg.AppNo, msg.AppEvent);
                    if (!SubMsgs.ContainsKey(key))
                    {
                        this.AppendText("无效Key：" + key);
                        continue;
                    }
                    var subMsgs = SubMsgs[key];
                    var notclientsubs = subMsgs.Where(p => p.Enabled && p.ReceiveType != PubMsgManager.PushType.client.ToString());
                    foreach (var subMsg in notclientsubs)
                    {
                        var sub = subMsg;
                        var pub = PubMsgManager.GetPubMsgImp(sub.ReceiveType);
                        var msgTask = new Task(() => pub.PubMsg(0, msg, sub));
                        TaskHelper.AddTask(msgTask);
                    }
                    TaskHelper.AddTask(new Task(() => PubMsgManager.DefaultPubMsg.PubMsg(0, msg, null)));
                    this.AppendText(msg.MsgNo + "已处理");
                }
            }, token, TaskCreationOptions.LongRunning);
            task.Start();

            AppendText("推送服务已启动");
            ReflushSubMsgs();
            TaskHelper.StartRun();
        }

        private void Stop_Btn_Click(object sender, EventArgs e)
        {
            this.Start_Btn.Enabled = true;
            this.Stop_Btn.Enabled = false;
            source.Cancel();
            TaskHelper.Stop();
        }

        private void Msg_Txt_TextChanged(object sender, EventArgs e)
        {
            if (this.Msg_Txt.TextLength > 2000)
                this.Msg_Txt.ResetText();
        }

        private static Dictionary<string, List<SubMsg>> GetSubMsgs()
        {
            var subMsgs = ServerManager.ServerHelper.GetSubImp.GetSubMsgs();
            var keys = subMsgs.Select(p => string.Format("{0}.{1}", p.PubAppNo, p.PubAppEvent)).Distinct();
            var subs = new Dictionary<string, List<SubMsg>>();
            foreach (var key in keys)
            {
                subs.Add(key, subMsgs.Where(p => string.Format("{0}.{1}", p.PubAppNo, p.PubAppEvent) == key).ToList());
            }
            return subs;
        }

        private void ReflushSubMsgs()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(5 * 60 * 1000);
                    var subMsgs = ServerManager.ServerHelper.GetSubImp.GetSubMsgs();
                    var keys = subMsgs.Select(p => string.Format("{0}.{1}", p.PubAppNo, p.PubAppEvent)).Distinct();
                    foreach (var key in keys)
                    {
                        var msgs = subMsgs.Where(p => string.Format("{0}.{1}", p.PubAppNo, p.PubAppEvent) == key).ToList();
                        SubMsgs[key] = msgs;
                    }
                    AppendText("消息订阅情况已刷新");
                }
            }, TaskCreationOptions.LongRunning);
        }


        private void AppendText(string str)
        {
            this.Msg_Txt.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + str + System.Environment.NewLine);
        }
    }
}
