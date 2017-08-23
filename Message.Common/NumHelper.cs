using System;
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Message.Common
{
    public class NumHelper
    {
        private static int number = 0;
        private static readonly object obj = new object();
        private static readonly string MachineNo = ConfigurationManager.AppSettings["MachineNo"];
        /// <summary>
        /// 固定前缀 MMddHHmmssfff
        /// </summary>
        /// <param name="machineNo">数字</param>
        /// <returns></returns>
        public static string GetRandomNo(string machineNo = null)
        {
            var start = new StringBuilder(DateTime.Now.ToString("MMddHHmmssfff"));
            if (string.IsNullOrEmpty(machineNo))
            {
                machineNo = MachineNo;
                if (string.IsNullOrEmpty(machineNo)) machineNo = "01";
            }
            start.Append(machineNo);
            var length = 7 - machineNo.Length;
            lock (obj)
            {
                if (number >= length * 10) number = 0;
                number++;
            }
            start.Append(number.ToString(CultureInfo.InvariantCulture).PadLeft(length, '0'));
            return start.ToString();
        }

    }
}
