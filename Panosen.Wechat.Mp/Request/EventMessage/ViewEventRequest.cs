using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp.Request
{
    /// <summary>
    /// 点击菜单跳转链接事件
    /// </summary>
    public class ViewEventRequest : EventRequest
    {
        /// <summary>
        /// EventType
        /// </summary>
        public override EventType EventType
        {
            get { return EventType.View; }
        }

        /// <summary>
        /// 事件KEY值，设置的跳转URL
        /// </summary>
        public string EventKey { get; set; }
    }
}
