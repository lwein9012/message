using System;

namespace Message.Model
{
    public class App
    {
        /// <summary>
        /// 应用
        /// </summary>
        public string AppNo { get; set; }

        /// <summary>
        /// 应用事件
        /// </summary>
        public string AppEvent { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

    }
}
