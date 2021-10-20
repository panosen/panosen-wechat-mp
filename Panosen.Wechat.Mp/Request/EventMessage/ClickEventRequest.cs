using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp.Request
{
    /// <summary>
    /// 自定义菜单事件
    /// </summary>
    public class ClickEventRequest : EventRequest
    {
        /// <summary>
        /// EventType
        /// </summary>
        public override EventType EventType { get { return EventType.Click; } }

        /// <summary>
        /// 事件KEY值，与自定义菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }
    }
}
