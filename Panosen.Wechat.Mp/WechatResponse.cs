using Panosen.Wechat.Mp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp
{
    /// <summary>
    /// 被动回复消息
    /// </summary>
    public class WechatResponse
    {
        /// <summary>
        /// 接收方帐号（收到的OpenID）
        /// 必填
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 开发者微信号
        /// 必填
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间 （整型）
        /// 必填
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// text
        /// 必填
        /// </summary>
        public string MsgType { get; set; }

        /// <summary>
        /// 文本消息正文（换行：在content中能够换行，微信客户端就支持换行显示）
        /// 必填
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 图片消息正文
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// 语音消息正文
        /// </summary>
        public Voice Voice { get; set; }

        /// <summary>
        /// 视频消息正文
        /// </summary>
        public Video Video { get; set; }

        /// <summary>
        /// 音乐消息正文
        /// </summary>
        public Music Music { get; set; }

        /// <summary>
        /// 图文消息正文
        /// 多条图文消息信息，默认第一个item为大图,注意，如果图文数超过10，则将会无响应
        /// </summary>
        public List<Article> Articles { get; set; }
    }
}
