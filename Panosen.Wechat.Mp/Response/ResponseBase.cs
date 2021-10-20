using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Panosen.Wechat.Mp.Response
{
    /// <summary>
    /// 被动回复给微信服务器的相应基类
    /// </summary>
    [XmlInclude(typeof(TextResponse))]
    public abstract class ResponseBase
    {
        /// <summary>
        /// ToUserName
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// FromUserName
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// MsgType
        /// </summary>
        public abstract ResponseType MsgType { get; }
    }

    /// <summary>
    /// 响应消息类型
    /// </summary>
    public enum ResponseType
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        Text,

        /// <summary>
        /// 图片消息
        /// </summary>
        Image,

        /// <summary>
        /// 语音消息
        /// </summary>
        Voice,

        /// <summary>
        /// 视频消息
        /// </summary>
        Video,

        /// <summary>
        /// 音乐消息
        /// </summary>
        Music,

        /// <summary>
        /// 图文消息
        /// </summary>
        News
    }
}
