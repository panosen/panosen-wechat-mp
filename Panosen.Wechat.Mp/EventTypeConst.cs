using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp
{
    /// <summary>
    /// 事件类型常量
    /// </summary>
    public static class EventTypeConst
    {
        /// <summary>
        /// 订阅
        /// </summary>
        public const string Subscribe = "subscribe";

        /// <summary>
        /// 取消订阅
        /// </summary>
        public const string UnSubscribe = "unsubscribe";

        /// <summary>
        /// 扫描二维码事件
        /// </summary>
        public const string Scan = "SCAN";

        /// <summary>
        /// 上报地理位置事件
        /// </summary>
        public const string Location = "LOCATION";

        /// <summary>
        /// 自定义菜单事件
        /// </summary>
        public const string Click = "CLICK";

        /// <summary>
        /// 跳转链接事件
        /// </summary>
        public const string View = "VIEW";
    }
}
