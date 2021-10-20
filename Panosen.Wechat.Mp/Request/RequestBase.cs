using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Panosen.Wechat.Mp.Request
{
    /// <summary>
    /// 消息基础类型
    /// </summary>
    [XmlInclude(typeof(TextRequest))]
    public abstract class RequestBase
    {
        /// <summary>
        /// MsgType
        /// </summary>
        public abstract RequestMsgType MsgType { get; }

        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public long CreateTime { get; set; }
    }

    /// <summary>
    /// 普通消息基类
    /// </summary>
    public abstract class MessageRequest : RequestBase
    {
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public long MsgId { get; set; }
    }

    /// <summary>
    /// 消息类型
    /// </summary>
    public enum RequestMsgType
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
        Voive,

        /// <summary>
        /// 视频消息
        /// </summary>
        Video,

        /// <summary>
        /// 小视频消息
        /// </summary>
        ShortVideo,

        /// <summary>
        /// 地理位置消息
        /// </summary>
        Location,

        /// <summary>
        /// 链接消息
        /// </summary>
        Link,

        /// <summary>
        /// 事件
        /// </summary>
        Event
    }
}
