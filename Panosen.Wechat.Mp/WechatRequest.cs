using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp
{
    /// <summary>
    /// 消息请求
    /// </summary>
    public class WechatRequest
    {
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public long MsgId { get; set; }

        /// <summary>
        /// MsgType
        /// </summary>
        public string MsgType { get; set; }

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
        public int CreateTime { get; set; }

        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 图片链接
        /// </summary>
        public string PicUrl { get; set; }

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

        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据
        /// </summary>
        public string ThumbMediaId { get; set; }

        /// <summary>
        /// 消息链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 消息描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 地理位置维度
        /// </summary>
        public float Location_X { get; set; }

        /// <summary>
        /// 地理位置经度
        /// </summary>
        public float Location_Y { get; set; }

        /// <summary>
        /// 地图缩放大小
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// 地理位置信息
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 事件类型
        /// 例如：subscribe(订阅)、unsubscribe(取消订阅)
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// 事件Key值
        /// </summary>
        public string EventKey { get; set; }

        /// <summary>
        /// 二维码的Ticket
        /// </summary>
        public string Ticket { get; set; }

        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// 地理位置经度
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// 地理位置精度
        /// </summary>
        public float Precision { get; set; }
    }
}
