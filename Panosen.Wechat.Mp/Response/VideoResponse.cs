using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp.Response
{
    /// <summary>
    /// 视频消息
    /// </summary>
    public class VideoResponse : ResponseBase
    {
        /// <summary>
        /// MsgType
        /// </summary>
        public override ResponseType MsgType { get { return ResponseType.Video; } }

        /// <summary>
        /// 视频消息内容
        /// </summary>
        public Video Video { get; set; }
    }

    /// <summary>
    /// 视频消息正文
    /// </summary>
    public class Video
    {
        /// <summary>
        /// 通过素材管理接口上传多媒体文件，得到的id
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 视频消息的标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 视频消息的描述
        /// </summary>
        public string Description { get; set; }
    }
}
