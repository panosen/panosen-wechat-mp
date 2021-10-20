using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp.Request
{
    /// <summary>
    /// 关注事件
    /// </summary>
    public class SubscribeEventRequest : EventRequest
    {
        /// <summary>
        /// EventType
        /// </summary>
        public override EventType EventType { get { return EventType.Subscribe; } }

        /// <summary>
        /// 如果用户是通过二维码来关注的，会额外传过来这个参数
        /// 事件KEY值，qrscene_为前缀，后面为二维码的参数值
        /// </summary>
        public string EventKey { get; set; }

        /// <summary>
        /// 如果用户是通过二维码来关注的，会额外传过来这个参数
        /// 二维码的ticket，可用来换取二维码图片
        /// </summary>
        public string Ticket { get; set; }
    }
}
