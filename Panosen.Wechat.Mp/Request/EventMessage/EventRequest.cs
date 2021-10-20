using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp.Request
{
    /// <summary>
    /// 事件消息基类
    /// </summary>
    public abstract class EventRequest : RequestBase
    {
        /// <summary>
        /// MsgType
        /// </summary>
        public override RequestMsgType MsgType { get { return RequestMsgType.Event; } }

        /// <summary>
        /// EventType
        /// </summary>
        public abstract EventType EventType { get; }
    }

    /// <summary>
    /// 事件类型
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// 无事件
        /// </summary>
        None,

        /// <summary>
        /// 订阅
        /// </summary>
        Subscribe,

        /// <summary>
        /// 取消订阅
        /// </summary>
        UnSubscribe,

        /// <summary>
        /// 扫描二维码
        /// </summary>
        Scan,

        /// <summary>
        /// 上报地理位置信息
        /// </summary>
        Location,

        /// <summary>
        /// 自定义事件信息
        /// </summary>
        Click,

        /// <summary>
        /// 点击菜单跳转链接事件
        /// </summary>
        View
    }
}
