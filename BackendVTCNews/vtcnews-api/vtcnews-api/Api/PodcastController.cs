using GenLinkImage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace vtcnews_api.Api
{
    [RoutePrefix("api/podcast")]
    public class PodcastController : ApiController
    {
        private static string _playbackUrl = "http://api.vtcnews.vn/";
        [Route("GetAllPodcast")]
        public async Task<HttpResponseMessage> GetAllPodcast()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/podcast/GetAllPodcast";
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
        [Route("ChannelByPodcast/{podId}")]
        public async Task<HttpResponseMessage> GetChannelByPodcast(int podId)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/podcast/ChannelByPodcast?podId="+podId;
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
        [Route("GetAlbumPaging/chanId/{chanId}/pageIndex/{pageIndex}")]
        public async Task<HttpResponseMessage> GetAlbumPaging(int chanId, int pageIndex)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/podcast/GetAlbumPaging?chanId="+ chanId + "&pageIndex=" + pageIndex;
                    var responsePost = await httpClient.GetAsync(url);
                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();
                        dynamic outputs = JsonConvert.DeserializeObject(responseBody);
                        foreach(var output in outputs)
                        {                      
                            output.image182_182 = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_182x182", (string)output.ImageUrl) + "/" + (string)output.ImageUrl;
                            output.image360_360 = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_360x360", (string)output.ImageUrl) + "/" + (string)output.ImageUrl;
                        }
                        return Request.CreateResponse(HttpStatusCode.OK, (Object)outputs, Configuration.Formatters.JsonFormatter);
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
        [Route("AlbumDetail/{id}")]
        public async Task<HttpResponseMessage> GetAlbumDetail(int id)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/podcast/AlbumDetail?id=" + id;
                    var responsePost = await httpClient.GetAsync(url);
                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();
                        dynamic output = JsonConvert.DeserializeObject(responseBody);
                        output.Info.image182_182 = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_182x182", (string)output.Info.ImageUrl) + "/" + (string)output.Info.ImageUrl;
                        output.Info.image360_360 = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_360x360", (string)output.Info.ImageUrl) + "/" + (string)output.Info.ImageUrl;   
                        foreach(var item in output.Items)
                        {
                            item.image182_182 = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_182x182", (string)output.Info.ImageUrl) + "/" + (string)output.Info.ImageUrl;
                        }
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

    }
}
