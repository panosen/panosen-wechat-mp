using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp.Response
{
    /// <summary>
    /// 文本消息
    /// </summary>
    public class TextResponse : ResponseBase
    {
        /// <summary>
        /// MsgType
        /// </summary>
        public override ResponseType MsgType { get { return ResponseType.Text; } }

        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
    }
}
