using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Panosen.Wechat.Mp.Request;
using Panosen.Wechat.Mp.Response;

namespace Panosen.Wechat.Mp
{
    /// <summary>
    /// WechatCore
    /// </summary>
    public class WechatCore
    {
        private readonly IMessageHandler messageProcessor;

        /// <summary>
        /// WechatCore
        /// </summary>
        public WechatCore(IMessageHandler messageProcessor)
        {
            this.messageProcessor = messageProcessor;
        }

        /// <summary>
        /// Process
        /// </summary>
        public string Process(string requestXml)
        {
            WechatRequest request = XmlHelper.FromXml(requestXml);

            var requestMessage = ToMessage(request);

            var responseMessage = messageProcessor.ProcessMessage(requestMessage);

            var response = ToMessageResponse(responseMessage);

            var xml = XmlHelper.ToXml(response);

            return xml;
        }

        /// <summary>
        /// 将外部消息请求转换为内部消息
        /// </summary>
        /// <param name="request">外部消息</param>
        /// <returns>内部消息</returns>
        public static RequestBase ToMessage(WechatRequest request)
        {
            if (request == null)
            {
                return null;
            }

            RequestBase message = GetMessage(request);
            if (message != null)
            {
                message.CreateTime = request.CreateTime;
                message.FromUserName = request.FromUserName;
                message.ToUserName = request.ToUserName;
            }

            return message;
        }

        private static RequestBase GetMessage(WechatRequest request)
        {
            switch (request.MsgType)
            {
                case RequestMsgTypeConst.Text:// 文本消息
                    {
                        var textMessage = new TextRequest();
                        textMessage.MsgId = request.MsgId;
                        textMessage.Content = request.Content;

                        return textMessage;
                    }
                case RequestMsgTypeConst.Image:// 图片消息
                    {
                        var imageMessage = new ImageRequest();
                        imageMessage.MsgId = request.MsgId;
                        imageMessage.PicUrl = request.PicUrl;
                        imageMessage.MediaId = request.MediaId;

                        return imageMessage;
                    }
                case RequestMsgTypeConst.Voice:// 语音消息
                    {
                        var voiceMessage = new VoiceRequest();
                        voiceMessage.MsgId = request.MsgId;
                        voiceMessage.MediaId = request.MediaId;
                        voiceMessage.Format = request.Format;
                        voiceMessage.Recognition = request.Recognition;

                        return voiceMessage;
                    }
                case RequestMsgTypeConst.Video:// 视频消息
                    {
                        var videoMessage = new VideoRequest();
                        videoMessage.MsgId = request.MsgId;
                        videoMessage.MediaId = request.MediaId;
                        videoMessage.ThumbMediaId = request.ThumbMediaId;

                        return videoMessage;
                    }
                case RequestMsgTypeConst.ShortVideo:// 小视频消息
                    {
                        var shortVideoMessage = new ShortVideoRequest();
                        shortVideoMessage.MsgId = request.MsgId;
                        shortVideoMessage.MediaId = request.MediaId;
                        shortVideoMessage.ThumbMediaId = request.ThumbMediaId;

                        return shortVideoMessage;
                    }
                case RequestMsgTypeConst.Location:// 地理位置消息
                    {
                        var locationMessage = new LocationRequest();
                        locationMessage.MsgId = request.MsgId;
                        locationMessage.Location_X = request.Location_X;
                        locationMessage.Location_Y = request.Location_Y;
                        locationMessage.Scale = request.Scale;
                        locationMessage.Label = request.Label;

                        return locationMessage;
                    }
                case RequestMsgTypeConst.Link:// 链接消息
                    {
                        var linkMessage = new LinkRequest();
                        linkMessage.MsgId = request.MsgId;
                        linkMessage.Url = request.Url;
                        linkMessage.Description = request.Description;

                        return linkMessage;
                    }

                case RequestMsgTypeConst.Event://事件

                    switch (request.EventType)
                    {
                        case EventTypeConst.Subscribe://订阅(包含 通过扫描二维码订阅)
                            {
                                var subscribeMessage = new SubscribeEventRequest();
                                subscribeMessage.EventKey = request.EventKey;
                                subscribeMessage.Ticket = request.Ticket;

                                return subscribeMessage;
                            }
                        case EventTypeConst.UnSubscribe://取消订阅
                            {
                                var unSubscribeMessage = new UnSubscribeEventRequest();

                                return unSubscribeMessage;
                            }
                        case EventTypeConst.Scan://扫描二维码事件
                            {
                                var scanMessage = new ScanEventRequest();
                                scanMessage.EventKey = request.EventKey;
                                scanMessage.Ticket = request.Ticket;

                                return scanMessage;
                            }
                        case EventTypeConst.Location://上报地址位置事件
                            {
                                var locationEventMessage = new LocationEventRequest();
                                locationEventMessage.Latitude = request.Latitude;
                                locationEventMessage.Longitude = request.Longitude;
                                locationEventMessage.Precision = request.Precision;

                                return locationEventMessage;
                            }
                        case EventTypeConst.Click://自定义菜单事件
                            {
                                var customEventMessage = new ClickEventRequest();
                                customEventMessage.EventKey = request.EventKey;

                                return customEventMessage;
                            }
                        case EventTypeConst.View://点击菜单跳转连接事件
                            {
                                var viewEventMessage = new ViewEventRequest();
                                viewEventMessage.EventKey = request.EventKey;

                                return viewEventMessage;
                            }
                        default:
                            {
                                return null;
                            }
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        /// <summary>
        /// 将内部消息转换为返回的外部消息
        /// </summary>
        /// <param name="message">内部消息</param>
        /// <returns></returns>
        public static WechatResponse ToMessageResponse(ResponseBase message)
        {
            if (message == null)
            {
                return null;
            }

            WechatResponse response = new WechatResponse();

            response.ToUserName = message.ToUserName;
            response.FromUserName = message.FromUserName;
            response.CreateTime = message.CreateTime;

            switch (message.MsgType)
            {
                case ResponseType.Text:
                    {
                        response.MsgType = ResponseMsgTypeConst.Text;

                        var textResponse = message as TextResponse;
                        response.Content = textResponse.Content;

                        return response;
                    }
                case ResponseType.Image:
                    {
                        response.MsgType = ResponseMsgTypeConst.Image;

                        var imageResponse = message as ImageResponse;
                        if (imageResponse.Image != null)
                        {
                            response.Image = new Image();
                            response.Image.MediaId = imageResponse.Image.MediaId;
                        }

                        return response;
                    }
                case ResponseType.Voice:
                    {
                        response.MsgType = ResponseMsgTypeConst.Voice;

                        var voiceResponse = message as VoiceResponse;
                        if (voiceResponse.Voice != null)
                        {
                            response.Voice = new Voice();
                            response.Voice.MediaId = voiceResponse.Voice.MediaId;
                        }

                        return response;
                    }
                case ResponseType.Video:
                    {
                        response.MsgType = ResponseMsgTypeConst.Video;

                        var videoResponse = message as VideoResponse;
                        if (videoResponse.Video != null)
                        {
                            response.Video = new Video();
                            response.Video.MediaId = videoResponse.Video.MediaId;
                            response.Video.Title = videoResponse.Video.Title;
                            response.Video.Description = videoResponse.Video.Description;
                        }

                        return response;
                    }
                case ResponseType.Music:
                    {
                        response.MsgType = ResponseMsgTypeConst.Music;

                        var musicResponse = message as MusicResponse;
                        if (musicResponse.Music != null)
                        {
                            response.Music = new Music();
                            response.Music.Title = musicResponse.Music.Title;
                            response.Music.Description = musicResponse.Music.Description;
                            response.Music.MusicUrl = musicResponse.Music.MusicUrl;
                            response.Music.HQMusicUrl = musicResponse.Music.HQMusicUrl;
                            response.Music.ThumbMediaId = musicResponse.Music.ThumbMediaId;
                        }

                        return response;
                    }
                case ResponseType.News:
                    {
                        response.MsgType = ResponseMsgTypeConst.News;

                        var newsResponse = message as NewsResponse;
                        if (newsResponse.Articles != null)
                        {
                            response.Articles = new List<Article>();
                            foreach (var item in newsResponse.Articles)
                            {
                                var article = new Article();
                                article.Title = item.Title;
                                article.Description = item.Description;
                                article.PicUrl = item.PicUrl;
                                article.Url = item.Url;
                                response.Articles.Add(article);
                            }
                        }

                        return response;
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
