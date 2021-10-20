using Panosen.Wechat.Mp.Request;
using Panosen.Wechat.Mp.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.Wechat.Mp
{
    /// <summary>
    /// IMessageHandler
    /// </summary>
    public interface IMessageHandler
    {
        /// <summary>
        /// ProcessMessage
        /// </summary>
        ResponseBase ProcessMessage(RequestBase request);
    }
}
