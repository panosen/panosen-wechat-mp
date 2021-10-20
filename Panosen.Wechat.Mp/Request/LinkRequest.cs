using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp.Request
{
    /// <summary>
    /// 链接消息
    /// </summary>
    public class LinkRequest : MessageRequest
    {
        /// <summary>
        /// MsgType
        /// </summary>
        public override RequestMsgType MsgType { get { return RequestMsgType.Link; } }

        /// <summary>
        /// 消息链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 消息描述
        /// </summary>
        public string Description { get; set; }
    }
}
