using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp.Response
{
    /// <summary>
    /// 图片消息
    /// </summary>
    public class ImageResponse : ResponseBase
    {
        /// <summary>
        /// MsgType
        /// </summary>
        public override ResponseType MsgType { get { return ResponseType.Image; } }

        /// <summary>
        /// 图片消息内容
        /// </summary>
        public Image Image { get; set; }
    }

    /// <summary>
    /// 图片消息正文
    /// </summary>
    public class Image
    {
        /// <summary>
        /// 通过素材管理接口上传多媒体文件，得到的id。
        /// </summary>
        public string MediaId { get; set; }
    }
}
