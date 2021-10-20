using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp.Request
{
    /// <summary>
    /// 文本消息
    /// </summary>
    public class TextRequest : MessageRequest
    {
        /// <summary>
        /// MsgType
        /// </summary>
        public override RequestMsgType MsgType { get { return RequestMsgType.Text; } }

        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
    }
}
