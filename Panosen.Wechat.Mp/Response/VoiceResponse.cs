using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp.Response
{
    /// <summary>
    /// 语音消息
    /// </summary>
    public class VoiceResponse : ResponseBase
    {
        /// <summary>
        /// MsgType
        /// </summary>
        public override ResponseType MsgType { get { return ResponseType.Voice; } }

        /// <summary>
        /// 语音消息内容
        /// </summary>
        public Voice Voice { get; set; }
    }

    /// <summary>
    /// 语音消息正文
    /// </summary>
    public class Voice
    {
        /// <summary>
        /// 通过素材管理接口上传多媒体文件，得到的id
        /// </summary>
        public string MediaId { get; set; }
    }
}
