using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace vtcnews_api.Api
{
    [RoutePrefix("api/playlist")]
    public class VideoController : ApiController
    {
        private static string accountIdPlaylist = "103e5b3a-3971-4fcb-bf44-5b15c5bbb88e";
        private static string playlistId = "f4fb5997-b362-48f2-bf9f-cb533a4db323/20/0";
        private static string _appID = "bc6da08b-3ad4-4452-8f29-d56bc69e33432";
        private static string _apiKey = "5G2Zix5YcWLdatLFrr+81d7ldMV7Yt5CGftGF5VTqhM=1";
        private static string _accountID = "103e5b3a-3971-4fcb-bf44-5b15c5bbb88e";
        private static string _playbackUrl = "https://playback.tek4tv.vn/";
        [Route("all")]
        public async Task<HttpResponseMessage> GetAllAsync()
        {
            try
            {
                string policyKey = "";              
                var data = new { AppID = _appID, ApiKey = _apiKey, AccountId = _accountID };
                using (var httpClient = new HttpClient())
                {
                    String domain = HttpContext.Current.Request.Url.Host;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string urlToken = _playbackUrl + "api/token";
                    var response = httpClient.PostAsJsonAsync(urlToken, data).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        policyKey = response.Content.ReadAsAsync<string>().Result;
                    }
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", policyKey);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string url = _playbackUrl + "v1/accounts/" + accountIdPlaylist + "/playlists/"+ playlistId;
                    var responsePost = await httpClient.GetAsync(url);
                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();
                        dynamic output = JsonConvert.DeserializeObject(responseBody);
                        return Request.CreateResponse(HttpStatusCode.OK, (Object)output, Configuration.Formatters.JsonFormatter);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, false);
                    }
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [Route("PrivateID/{ID}")]
        public async Task<HttpResponseMessage> GetByPrivateIDAsync(string ID)
        {
            try
            {
                string policyKey = "";
                var data = new { AppID = _appID, ApiKey = _apiKey, AccountId = _accountID };
                using (var httpClient = new HttpClient())
                {
                    String domain = HttpContext.Current.Request.Url.Host;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string urlToken = _playbackUrl + "api/token";
                    var response = httpClient.PostAsJsonAsync(urlToken, data).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        policyKey = response.Content.ReadAsAsync<string>().Result;
                    }
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", policyKey);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string url = _playbackUrl + "v1/accounts/" + accountIdPlaylist + "/playlists/" + playlistId;
                    var responsePost = await httpClient.GetAsync(url);
                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();
                        dynamic output = JsonConvert.DeserializeObject(responseBody);
                        foreach(var item in output.Media){
                            if(item.PrivateID == ID)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, (Object)item, Configuration.Formatters.JsonFormatter);
                            }
                        }
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, false);

                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, false);
                    }
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
