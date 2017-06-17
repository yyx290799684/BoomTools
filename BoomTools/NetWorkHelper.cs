using BoomTools.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BoomTools
{
    public class NetWorkHelper
    {
        /// <summary>
        /// 网络是否可以用
        /// </summary>
        /// <returns></returns>
        public static bool IsNetworkAvailable()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <param name="content"></param>
        /// <param name="headList"></param>
        /// <param name="paramList"></param>
        /// <param name="isNeedErrorReturn"></param>
        /// <returns></returns>
        public static async Task<string> getHttpWebRequest(string uri, Constants.HttpMethod method = Constants.HttpMethod.GET, string content = "", List<KeyValuePair<string, string>> headList = null, List<KeyValuePair<string, string>> paramList = null, bool isNeedErrorReturn = false)
        {
            HttpResponseMessage response = null;
            string responseReturn = "";
            return await Task.Run(() =>
            {
                if (IsNetworkAvailable())
                {
                    HttpClient httpClient = new HttpClient();
                    if (headList != null && headList.Count != 0)
                    {
                        foreach (var head in headList)
                        {
                            httpClient.DefaultRequestHeaders.Add(head.Key, head.Value);
                        }
                    }
                    HttpRequestMessage requst;
                    switch (method.ToString())
                    {
                        case "POST":
                            if (paramList == null || paramList.Count == 0)
                            {
                                response = httpClient.PostAsync(new Uri(uri), new StringContent(content, Encoding.UTF8, "application/json")).Result;
                            }
                            else
                            {
                                response = httpClient.PostAsync(new Uri(uri), new System.Net.Http.FormUrlEncodedContent(paramList)).Result;
                            }
                            break;
                        case "GET":
                            response = httpClient.GetAsync(new Uri(uri)).Result;
                            break;
                        case "PUT":
                            response = httpClient.PutAsync(new Uri(uri), new StringContent(content, Encoding.UTF8, "application/json")).Result;
                            break;
                        case "DELETE":
                            requst = new HttpRequestMessage(HttpMethod.Delete, new Uri(uri));
                            requst.Content = new StringContent(content, Encoding.UTF8, "application/json");
                            response = httpClient.SendAsync(requst).Result;
                            break;
                        case "HEAD":
                            requst = new HttpRequestMessage(HttpMethod.Head, new Uri(uri));
                            requst.Content = new StringContent(content, Encoding.UTF8, "application/json");
                            response = httpClient.SendAsync(requst).Result;
                            break;
                        case "OPTIONS":
                            requst = new HttpRequestMessage(HttpMethod.Options, new Uri(uri));
                            requst.Content = new StringContent(content, Encoding.UTF8, "application/json");
                            response = httpClient.SendAsync(requst).Result;
                            break;
                        case "TRACE":
                            requst = new HttpRequestMessage(HttpMethod.Trace, new Uri(uri));
                            requst.Content = new StringContent(content, Encoding.UTF8, "application/json");
                            response = httpClient.SendAsync(requst).Result;
                            break;
                        default:
                            break;
                    }
                    if (response.StatusCode == HttpStatusCode.OK || isNeedErrorReturn)
                    {
                        responseReturn = response.Content.ReadAsStringAsync().Result;
                    }
                }
                else
                {
                    throw new NetWorkErrorException();
                }
                return responseReturn;
            });
        }


    }
}
