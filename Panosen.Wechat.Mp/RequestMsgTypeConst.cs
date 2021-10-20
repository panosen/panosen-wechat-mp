using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp
{
    /// <summary>
    /// 接收消息类型常量
    /// </summary>
    public static class RequestMsgTypeConst
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        public const string Text = "text";

        /// <summary>
        /// 图片消息
        /// </summary>
        public const string Image = "image";

        /// <summary>
        /// 语音消息
        /// </summary>
        public const string Voice = "voice";

        /// <summary>
        /// 视频消息
        /// </summary>
        public const string Video = "video";

        /// <summary>
        /// 小视频消息
        /// </summary>
        public const string ShortVideo = "shortvideo";

        /// <summary>
        /// 地理位置消息
        /// </summary>
        public const string Location = "location";

        /// <summary>
        /// 链接消息
        /// </summary>
        public const string Link = "link";

        /// <summary>
        /// 事件消息
        /// </summary>
        public const string Event = "event";
    }
}
