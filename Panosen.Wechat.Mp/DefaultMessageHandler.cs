using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panosen.Wechat.Mp.Request;
using Panosen.Wechat.Mp.Response;

namespace Panosen.Wechat.Mp
{
    /// <summary>
    /// DefaultMessageHandler
    /// </summary>
    public class DefaultMessageHandler : IMessageHandler
    {
        /// <summary>
        /// ProcessMessage
        /// </summary>
        public ResponseBase ProcessMessage(RequestBase request)
        {
            ResponseBase response = OnProcessMessage(request);

            if (response != null)
            {
                response.FromUserName = request.ToUserName;
                response.ToUserName = request.FromUserName;
                response.CreateTime = Panosen.Time.TimeConvert.ToTicks(DateTime.Now);
            }

            return response;
        }

        private ResponseBase OnProcessMessage(RequestBase request)
        {
            if (request == null)
            {
                return new TextResponse();
            }

            switch (request.MsgType)
            {
                case RequestMsgType.Text:
                    {
                        return ProcessTextMessage(request as TextRequest);
                    }
                case RequestMsgType.Image:
                    {
                        return ProcessImageMessage(request as ImageRequest);
                    }
                case RequestMsgType.Voive:
                    {
                        return ProcessVoiceMessage(request as VoiceRequest);
                    }
                case RequestMsgType.Video:
                    {
                        return ProcessVideoMessage(request as VideoRequest);
                    }
                case RequestMsgType.ShortVideo:
                    {
                        return ProcessShortVideoMessage(request as ShortVideoRequest);
                    }
                case RequestMsgType.Location:
                    {
                        return ProcessLocationMessage(request as LocationRequest);
                    }
                case RequestMsgType.Link:
                    {
                        return ProcessLinkMessage(request as LinkRequest);
                    }
                case RequestMsgType.Event:
                    {
                        var eventMessage = request as EventRequest;
                        switch (eventMessage.EventType)
                        {
                            case EventType.Subscribe:
                                {
                                    return ProcessSubscribeMessage(eventMessage as SubscribeEventRequest);
                                }
                            case EventType.UnSubscribe:
                                {
                                    return ProcessUnSubscribeMessage(eventMessage as UnSubscribeEventRequest);
                                }
                            case EventType.Scan:
                                {
                                    return ProcessScanEventMessage(eventMessage as ScanEventRequest);
                                }
                            case EventType.Location:
                                {
                                    return ProcessLocationEventMessage(eventMessage as LocationEventRequest);
                                }
                            case EventType.View:
                                {
                                    return ProcessViewEventMessage(eventMessage as ViewEventRequest);
                                }
                            case EventType.Click:
                                {
                                    return ProcessClickMessage(request as ClickEventRequest);
                                }
                            case EventType.None:
                            default:
                                {
                                    return new TextResponse { Content = $"[EventTypeNotSupport]{eventMessage.EventType}" };
                                }
                        }
                    }
                default:
                    {
                        return new TextResponse { Content = $"[MsgTypeNotSupport] {request.MsgType}" };
                    }
            }
        }

        /// <summary>
        /// ProcessViewEventMessage
        /// </summary>
        protected virtual ResponseBase ProcessViewEventMessage(ViewEventRequest viewEventMessage)
        {
            return NotSupportMessage("View");
        }

        /// <summary>
        /// ProcessLocationEventMessage
        /// </summary>
        protected virtual ResponseBase ProcessLocationEventMessage(LocationEventRequest locationEventMessage)
        {
            return NotSupportMessage("Location");
        }

        /// <summary>
        /// ProcessScanEventMessage
        /// </summary>
        protected virtual ResponseBase ProcessScanEventMessage(ScanEventRequest scanEventMessage)
        {
            return NotSupportMessage("Scan");
        }

        /// <summary>
        /// ProcessUnSubscribeMessage
        /// </summary>
        protected virtual ResponseBase ProcessUnSubscribeMessage(UnSubscribeEventRequest unSubscribeEventMessage)
        {
            return NotSupportMessage("UnSubscribe");
        }

        /// <summary>
        /// ProcessLinkMessage
        /// </summary>
        protected virtual ResponseBase ProcessLinkMessage(LinkRequest linkMessage)
        {
            return NotSupportMessage("Link");
        }

        /// <summary>
        /// ProcessLocationMessage
        /// </summary>
        protected virtual ResponseBase ProcessLocationMessage(LocationRequest locationMessage)
        {
            return NotSupportMessage("Location");
        }

        /// <summary>
        /// ProcessShortVideoMessage
        /// </summary>
        protected virtual ResponseBase ProcessShortVideoMessage(ShortVideoRequest shortVideoMessage)
        {
            return NotSupportMessage("ShortVideo");
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual ResponseBase ProcessVideoMessage(VideoRequest videoMessage)
        {
            return NotSupportMessage("Video");
        }

        /// <summary>
        /// ProcessVoiceMessage
        /// </summary>
        protected virtual ResponseBase ProcessVoiceMessage(VoiceRequest voiceMessage)
        {
            return NotSupportMessage("Voice");
        }

        /// <summary>
        /// ProcessImageMessage
        /// </summary>
        protected virtual ResponseBase ProcessImageMessage(ImageRequest imageMessage)
        {
            return NotSupportMessage("Image");
        }

        /// <summary>
        /// ProcessTextMessage
        /// </summary>
        protected virtual ResponseBase ProcessTextMessage(TextRequest request)
        {
            return new TextResponse { Content = $"您输入了`{request.Content}`" };
        }

        /// <summary>
        /// ProcessClickMessage
        /// </summary>
        protected ResponseBase ProcessClickMessage(ClickEventRequest request)
        {
            return NotSupportMessage("Click");
        }

        /// <summary>
        /// ProcessSubscribeMessage
        /// </summary>
        protected ResponseBase ProcessSubscribeMessage(SubscribeEventRequest subscribeEventMessage)
        {
            return NotSupportMessage("Subscribe");
        }

        /// <summary>
        /// NotSupportMessage
        /// </summary>
        protected virtual ResponseBase NotSupportMessage(string type)
        {
            return new TextResponse { Content = $"暂不支持`{type}`消息" };
        }
    }
}
