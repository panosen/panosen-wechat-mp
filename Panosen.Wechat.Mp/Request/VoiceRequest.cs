using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp.Request
{
    /// <summary>
    /// 语音消息
    /// </summary>
    public class VoiceRequest : MessageRequest
    {
        /// <summary>
        /// MsgType
        /// </summary>
        public override RequestMsgType MsgType { get { return RequestMsgType.Voive; } }

        /// <summary>
        /// 图片消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 语音识别结果
        /// </summary>
        public string Recognition { get; set; }
    }
}
