using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp.Request
{
    /// <summary>
    /// 取消关注事件
    /// </summary>
    public class UnSubscribeEventRequest : EventRequest
    {
        /// <summary>
        /// EventType
        /// </summary>
        public override EventType EventType { get { return EventType.UnSubscribe; } }
    }
}
