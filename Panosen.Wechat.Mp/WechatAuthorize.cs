using Panosen.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Wechat.Mp
{
    /// <summary>
    /// WechatAuthorize
    /// </summary>
    public class WechatAuthorize
    {
        private readonly WechatContext wechatContext;

        /// <summary>
        /// WechatAuthorize
        /// </summary>
        public WechatAuthorize(WechatContext wechatContext)
        {
            this.wechatContext = wechatContext;
        }

        /// <summary>
        /// 开发者提交信息后，微信服务器将发送GET请求到填写的URL上
        /// 开发者通过检验signature对请求进行校验（下面有校验方式）。若确认此次GET请求来自微信服务器，请原样返回echostr参数内容，则接入生效，成为开发者成功，否则接入失败。
        /// 加密/校验流程如下：
        /// 1. 将token、timestamp、nonce三个参数进行字典序排序
        /// 2. 将三个参数字符串拼接成一个字符串进行sha1加密
        /// 3. 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信
        /// </summary>
        /// <param name="signature">微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数。</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">随机数</param>
        /// <param name="echostr">随机字符串</param>
        /// <returns></returns>
        public string Authorize(string signature, string timestamp, string nonce, string echostr)
        {
            List<string> list = new List<string>();

            var token = wechatContext.Token;
            list.Add(token);
            list.Add(timestamp);
            list.Add(nonce);

            //1.排序
            list = list.OrderBy(v => v).ToList();

            //2.拼接
            var original = string.Join(string.Empty, list);

            //3.sha1加密
            var encryptet = Hash.SHA1(original);

            //4.对比
            if (encryptet.Equals(signature, StringComparison.OrdinalIgnoreCase))
            {
                return echostr;
            }
            else
            {
                return "error";
            }
        }
    }
}
