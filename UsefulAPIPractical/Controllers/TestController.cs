using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UsefulAPIPractical.Utility;

namespace UsefulAPIPractical.Controllers
{
    public class TestController : ApiController
    {
        // get the session id first
        //string cookie = getSessionId();
        //object GetSourceList()
        //{
        //    using (var httpClient = new HttpClient())
        //        httpClient.BaseAddress = new UriBuilder("http://localhost:63586").Uri;
        //    var message = new HttpRequestMessage(HttpMethod.Get, "/api/sources");
        //    // add cookie value to the message header
        //    message.Headers.Add("cookie", cookie);
        //    // send to server
        //    var result = httpClient.SendAsync(message);
        //    result.Result.EnsureSuccessStatusCode();
        //    // get json response
        //    var s = result.Result.Content.ReadAsStringAsync().Result;
        //    return JsonConvert.DeserializeObject(s);
        //}

        //public string getSessionId()
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.BaseAddress = new UriBuilder("http://localhost:63586").Uri;
        //        dynamic loginInfo = new ExpandoObject();
        //        loginInfo.user = "nidhi.t@elaunchinfotech.com";
        //        loginInfo.password = "N@userful1";
        //        var auth = JsonConvert.SerializeObject(loginInfo);
        //        var buffer = System.Text.Encoding.UTF8.GetBytes(auth);
        //        var byteContent = new ByteArrayContent(buffer);
        //        var ret = httpClient.PostAsync("http://localhost:63586/api/system", byteContent);
        //        IEnumerable<string> retval;
        //        ret.Result.Headers.TryGetValues("Set-Cookie", out retval);
        //        if (retval != null)
        //            return retval.FirstOrDefault();
        //        else
        //            return null;
        //    }
        //}

        //public ApiResponse GetData()
        //{
        //    ApiResponse apiResponse = new ApiResponse();
        //    try
        //    {
        //        using (var httpClient = new HttpClient())
        //        {
        //            //httpClient.BaseAddress = new UriBuilder("http://localhost:63586").Uri;
        //            httpClient.BaseAddress = new UriBuilder("http://192.168.0.113:9000/").Uri;
        //            dynamic loginInfo = new ExpandoObject();
        //            loginInfo.user = "nidhi.t@elaunchinfotech.com";
        //            loginInfo.password = "N@userful1";
        //            var auth = JsonConvert.SerializeObject(loginInfo);
        //            var buffer = System.Text.Encoding.UTF8.GetBytes(auth);
        //            var byteContent = new ByteArrayContent(buffer);
        //            var ret = httpClient.PostAsync("api/session", byteContent);
        //            IEnumerable<string> retval;
        //            ret.Result.Headers.TryGetValues("Set-Cookie", out retval);
        //            if (retval != null)
        //                apiResponse = Common.GenerateApiResponse(1, true, "No data available", retval.FirstOrDefault());
        //            else
        //                apiResponse = Common.GenerateApiResponse(0, false, "Something went wrong", null);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        apiResponse = Common.GenerateApiResponse(0, false, ex.Message.ToString(), null);
        //    }
        //    return apiResponse;
        //}


        public ApiResponse GetData()
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    //httpClient.BaseAddress = new UriBuilder("http://192.168.111.10:9000").Uri;
                    //httpClient.BaseAddress = new UriBuilder("http://192.168.111.10:9000/api/system").Uri;
                    //httpClient.BaseAddress = new UriBuilder("http://157.119.207.146:9000/api/system").Uri;
                    httpClient.BaseAddress = new UriBuilder("http://192.168.0.113:9000/api/system").Uri;
                    dynamic loginInfo = new ExpandoObject();
                    loginInfo.user = "nidhi.t@elaunchinfotech.com";
                    loginInfo.password = "N@userful1";
                    var auth = JsonConvert.SerializeObject(loginInfo);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(auth);
                    var byteContent = new ByteArrayContent(buffer);
                    var ret = httpClient.PostAsync("/api/session", byteContent);
                    IEnumerable<string> retval;
                    ret.Result.Headers.TryGetValues("Set-Cookie", out retval);
                    if (retval != null)
                    {
                        string cookie = retval.FirstOrDefault();
                        using (var http = new HttpClient())
                            //http.BaseAddress = new UriBuilder("http://192.168.111.10:9000/api/system").Uri;
                            //http.BaseAddress = new UriBuilder("http://157.119.207.146:9900/api/system").Uri;
                            http.BaseAddress = new UriBuilder("http://192.168.0.113:9000/api/system").Uri;
                        var message = new HttpRequestMessage(HttpMethod.Get, "/api/sources");
                        // add cookie value to the message header
                        message.Headers.Add("cookie", cookie);
                        // send to server
                        var result = httpClient.SendAsync(message);
                        result.Result.EnsureSuccessStatusCode();
                        // get json response
                        var s = result.Result.Content.ReadAsStringAsync().Result;
                        JsonConvert.DeserializeObject(s);

                    }
                }
            }
            catch (Exception ex)
            {
                apiResponse = Common.GenerateApiResponse(0, false, ex.Message.ToString(), null);
            }
            return apiResponse;
        }




        //public string getSessionId()
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.BaseAddress = new UriBuilder("http://localhost:9000").Uri;
        //        dynamic loginInfo = new ExpandoObject();
        //        loginInfo.user = "nidhi.t@elaunchinfotech.com";
        //        loginInfo.password = "N@userful1";
        //        var auth = JsonConvert.SerializeObject(loginInfo);
        //        var buffer = System.Text.Encoding.UTF8.GetBytes(auth);
        //        var byteContent = new ByteArrayContent(buffer);
        //        var ret = httpClient.PostAsync("/api/session", byteContent);
        //        IEnumerable<string> retval;
        //        ret.Result.Headers.TryGetValues("Set-Cookie", out retval);
        //        if (retval != null)
        //            return retval.FirstOrDefault();
        //        else
        //            return null;
        //    }
        //}

        //// get the session id first
        //string cookie = getSessionId();
        //public object GetSourceList()
        //{
        //    using (var httpClient = new HttpClient())
        //        httpClient.BaseAddress = new UriBuilder("http://localhost:9000").Uri;
        //    var message = new HttpRequestMessage(HttpMethod.Get, "/api/sources");
        //    // add cookie value to the message header
        //    message.Headers.Add("cookie", cookie);
        //    // send to server
        //    var result = httpClient.SendAsync(message);
        //    result.Result.EnsureSuccessStatusCode();
        //    // get json response
        //    var s = result.Result.Content.ReadAsStringAsync().Result;
        //    return JsonConvert.DeserializeObject(s);
        //}

    }
}
