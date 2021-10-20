using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Panosen.Wechat.Mp
{
    /// <summary>
    /// XmlHelper
    /// </summary>
    internal class XmlHelper
    {
        /// <summary>
        /// 解析外部post来的请求
        /// </summary>
        public static WechatRequest FromXml(string requestXml)
        {
            XmlDocument document = new XmlDocument();

            document.LoadXml(requestXml);

            WechatRequest request = new WechatRequest();

            request.MsgType = ReadStringValue(document, NodeNameConst.MsgType);
            request.ToUserName = ReadStringValue(document, NodeNameConst.ToUserName);
            request.FromUserName = ReadStringValue(document, NodeNameConst.FromUserName);
            request.CreateTime = ReadIntValue(document, NodeNameConst.CreateTime);
            request.MsgId = ReadLongValue(document, NodeNameConst.MsgId);
            request.Content = ReadStringValue(document, NodeNameConst.Content);
            request.Description = ReadStringValue(document, NodeNameConst.Description);
            request.Format = ReadStringValue(document, NodeNameConst.Format);
            request.Label = ReadStringValue(document, NodeNameConst.Label);
            request.Location_X = ReadFloatValue(document, NodeNameConst.Location_X);
            request.Location_Y = ReadFloatValue(document, NodeNameConst.Location_Y);
            request.MediaId = ReadStringValue(document, NodeNameConst.MediaId);
            request.PicUrl = ReadStringValue(document, NodeNameConst.PicUrl);
            request.Recognition = ReadStringValue(document, NodeNameConst.Recognition);
            request.Scale = ReadIntValue(document, NodeNameConst.Scale);
            request.ThumbMediaId = ReadStringValue(document, NodeNameConst.ThumbMediaId);
            request.Url = ReadStringValue(document, NodeNameConst.Url);
            request.EventType = ReadStringValue(document, NodeNameConst.Event);
            request.EventKey = ReadStringValue(document, NodeNameConst.EventKey);
            request.Ticket = ReadStringValue(document, NodeNameConst.Ticket);
            request.Latitude = ReadFloatValue(document, NodeNameConst.Latitude);
            request.Longitude = ReadFloatValue(document, NodeNameConst.Longitude);
            request.Precision = ReadFloatValue(document, NodeNameConst.Precison);

            return request;
        }

        public static string ToXml(WechatResponse response)
        {
            string content = string.Empty;

            XmlDocument document = new XmlDocument();

            var root = document.CreateElement(NodeNameConst.Xml);
            document.AppendChild(root);

            //消息头
            root.AppendChild(ToXmlElement(document, NodeNameConst.ToUserName, response.ToUserName));
            root.AppendChild(ToXmlElement(document, NodeNameConst.FromUserName, response.FromUserName));
            root.AppendChild(ToXmlElement(document, NodeNameConst.CreateTime, response.CreateTime.ToString()));
            root.AppendChild(ToXmlElement(document, NodeNameConst.MsgType, response.MsgType));

            //消息正文
            AppendBody(response, document, root);

            //Write xml
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.OmitXmlDeclaration = true;

            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, setting))
                {
                    document.WriteContentTo(xmlWriter);
                }

                content = stringWriter.ToString();
            }

            return content;
        }

        private static XmlElement ToXmlElement(XmlDocument document, string key, string value)
        {
            var xmlElement = document.CreateElement(key);
            xmlElement.AppendChild(document.CreateCDataSection(value ?? string.Empty));

            return xmlElement;
        }

        private static XmlElement ToXmlElement(XmlDocument document, string key, string subKey, string value)
        {
            var xmlElement = document.CreateElement(key);
            xmlElement.AppendChild(ToXmlElement(document, subKey, value ?? string.Empty));

            return xmlElement;
        }

        private static XmlElement ToXmlElement(XmlDocument document, string key, Dictionary<string, string> subKeyValue)
        {
            var xmlElement = document.CreateElement(key);
            foreach (var item in subKeyValue)
            {
                xmlElement.AppendChild(ToXmlElement(document, item.Key, item.Value ?? string.Empty));
            }

            return xmlElement;
        }

        private static void AppendBody(WechatResponse response, XmlDocument document, XmlElement root)
        {
            switch (response.MsgType)
            {
                case ResponseMsgTypeConst.Text://文本消息
                    root.AppendChild(ToXmlElement(document, NodeNameConst.Content, response.Content));

                    break;
                case ResponseMsgTypeConst.Image://图片消息
                    root.AppendChild(ToXmlElement(document, NodeNameConst.Image, NodeNameConst.MediaId, response.Image.MediaId));

                    break;
                case ResponseMsgTypeConst.Voice://语音消息
                    root.AppendChild(ToXmlElement(document, NodeNameConst.Voice, NodeNameConst.MediaId, response.Voice.MediaId));

                    break;
                case ResponseMsgTypeConst.Video://视频消息
                    {
                        var items = new Dictionary<string, string>();
                        items.Add(NodeNameConst.MediaId, response.Video.MediaId);
                        items.Add(NodeNameConst.Title, response.Video.Title);
                        items.Add(NodeNameConst.Description, response.Video.Description);

                        root.AppendChild(ToXmlElement(document, NodeNameConst.Video, items));
                    }

                    break;
                case ResponseMsgTypeConst.Music://音乐消息
                    {
                        var items = new Dictionary<string, string>();
                        items.Add(NodeNameConst.Title, response.Music.Title);
                        items.Add(NodeNameConst.Description, response.Music.Description);
                        items.Add(NodeNameConst.MusicUrl, response.Music.MusicUrl);
                        items.Add(NodeNameConst.HQMusicUrl, response.Music.HQMusicUrl);
                        items.Add(NodeNameConst.ThumbMediaId, response.Music.ThumbMediaId);

                        root.AppendChild(ToXmlElement(document, NodeNameConst.Music, items));
                    }

                    break;
                case ResponseMsgTypeConst.News://图文消息
                    {
                        root.AppendChild(ToXmlElement(document, NodeNameConst.ArticleCount, response.Articles.Count.ToString()));

                        XmlElement articles = document.CreateElement(NodeNameConst.Articles);
                        foreach (var article in response.Articles)
                        {
                            XmlElement item = document.CreateElement(NodeNameConst.Articles);

                            var items = new Dictionary<string, string>();
                            items.Add(NodeNameConst.Title, article.Title);
                            items.Add(NodeNameConst.Description, article.Title);
                            items.Add(NodeNameConst.PicUrl, article.Title);
                            items.Add(NodeNameConst.Url, article.Title);

                            articles.AppendChild(ToXmlElement(document, NodeNameConst.Item, items));
                        }
                        root.AppendChild(articles);
                    }

                    break;
                default:
                    break;
            }
        }

        private static string ReadStringValue(XmlDocument document, string nodeName)
        {
            var node = document.GetElementsByTagName(nodeName);
            if (node.Count > 0)
            {
                return node[0].InnerText;
            }

            return null;
        }

        private static int ReadIntValue(XmlDocument document, string nodeName)
        {
            var node = document.GetElementsByTagName(nodeName);
            if (node.Count > 0)
            {
                return int.Parse(node[0].InnerText);
            }

            return 0;
        }

        private static long ReadLongValue(XmlDocument document, string nodeName)
        {
            var node = document.GetElementsByTagName(nodeName);
            if (node.Count > 0)
            {
                return long.Parse(node[0].InnerText);
            }

            return 0;
        }

        private static float ReadFloatValue(XmlDocument document, string nodeName)
        {
            var node = document.GetElementsByTagName(nodeName);
            if (node.Count > 0)
            {
                return float.Parse(node[0].InnerText);
            }

            return 0;
        }
    }
}
