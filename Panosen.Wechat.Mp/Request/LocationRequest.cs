using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp.Request
{
    /// <summary>
    /// 地理位置消息
    /// </summary>
    public class LocationRequest : MessageRequest
    {
        /// <summary>
        /// MsgType
        /// </summary>
        public override RequestMsgType MsgType { get { return RequestMsgType.Location; } }

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
    }
}
