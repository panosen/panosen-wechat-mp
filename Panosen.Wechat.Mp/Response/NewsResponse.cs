using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp.Response
{
    /// <summary>
    /// 图文消息
    /// 图文消息个数，限制为10条以内
    /// </summary>
    public class NewsResponse : ResponseBase
    {
        /// <summary>
        /// MsgType
        /// </summary>
        public override ResponseType MsgType { get { return ResponseType.News; } }

        /// <summary>
        /// 多条图文消息信息，默认第一个item为大图,注意，如果图文数超过10，则将会无响应
        /// </summary>
        public List<Article> Articles { get; set; }
    }

    /// <summary>
    /// 图文消息正文
    /// </summary>
    public class Article
    {
        /// <summary>
        /// 图文消息标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 图文消息描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 点击图文消息跳转链接
        /// </summary>
        public string Url { get; set; }
    }
}
