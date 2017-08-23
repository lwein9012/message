using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Message.ServiceFrm.Common
{
    public class HttpHelper
    {
        public static string Post(string url, string content, string contenttype = "application/json", string chatset = "utf-8")
        {
            try
            {
                var req = System.Net.WebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = string.Format("{0};{1}", contenttype, chatset);
                var bytes = Encoding.GetEncoding(chatset).GetBytes(content);
                req.ContentLength = bytes.Length;
                using (var reqStream = req.GetRequestStream())
                {
                    reqStream.Write(bytes, 0, bytes.Length);
                }
                using (var resp = (HttpWebResponse)req.GetResponse())
                {
                    return resp.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                return "Exception";
            }
        } 
    }
}
