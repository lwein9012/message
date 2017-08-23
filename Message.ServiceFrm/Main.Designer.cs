namespace Message.ServiceFrm
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Start_Btn = new System.Windows.Forms.Button();
            this.Stop_Btn = new System.Windows.Forms.Button();
            this.Msg_Txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Start_Btn
            // 
            this.Start_Btn.Location = new System.Drawing.Point(86, 31);
            this.Start_Btn.Name = "Start_Btn";
            this.Start_Btn.Size = new System.Drawing.Size(75, 23);
            this.Start_Btn.TabIndex = 0;
            this.Start_Btn.Text = "开始推送";
            this.Start_Btn.UseVisualStyleBackColor = true;
            this.Start_Btn.Click += new System.EventHandler(this.Start_Btn_Click);
            // 
            // Stop_Btn
            // 
            this.Stop_Btn.Enabled = false;
            this.Stop_Btn.Location = new System.Drawing.Point(244, 31);
            this.Stop_Btn.Name = "Stop_Btn";
            this.Stop_Btn.Size = new System.Drawing.Size(75, 23);
            this.Stop_Btn.TabIndex = 0;
            this.Stop_Btn.Text = "结束推送";
            this.Stop_Btn.UseVisualStyleBackColor = true;
            this.Stop_Btn.Click += new System.EventHandler(this.Stop_Btn_Click);
            // 
            // Msg_Txt
            // 
            this.Msg_Txt.Enabled = false;
            this.Msg_Txt.Location = new System.Drawing.Point(34, 73);
            this.Msg_Txt.Multiline = true;
            this.Msg_Txt.Name = "Msg_Txt";
            this.Msg_Txt.Size = new System.Drawing.Size(386, 345);
            this.Msg_Txt.TabIndex = 1;
            this.Msg_Txt.TextChanged += new System.EventHandler(this.Msg_Txt_TextChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 430);
            this.Controls.Add(this.Msg_Txt);
            this.Controls.Add(this.Stop_Btn);
            this.Controls.Add(this.Start_Btn);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start_Btn;
        private System.Windows.Forms.Button Stop_Btn;
        private System.Windows.Forms.TextBox Msg_Txt;
    }
}

