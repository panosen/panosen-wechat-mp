﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp.Response
{
    /// <summary>
    /// 音乐消息
    /// </summary>
    public class MusicResponse : ResponseBase
    {
        /// <summary>
        /// MsgType
        /// </summary>
        public override ResponseType MsgType { get { return ResponseType.Music; } }

        /// <summary>
        /// 音乐消息内容
        /// </summary>
        public Music Music { get; set; }
    }

    /// <summary>
    /// 音乐消息正文
    /// </summary>
    public class Music
    {
        /// <summary>
        /// 音乐标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 音乐描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 音乐链接
        /// </summary>
        public string MusicUrl { get; set; }

        /// <summary>
        /// 高质量音乐链接，WIFI环境优先使用该链接播放音乐
        /// </summary>
        public string HQMusicUrl { get; set; }

        /// <summary>
        /// 缩略图的媒体id，通过素材管理接口上传多媒体文件，得到的id
        /// </summary>
        public string ThumbMediaId { get; set; }
    }
}
