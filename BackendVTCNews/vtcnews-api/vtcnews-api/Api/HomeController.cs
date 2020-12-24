﻿using GenLinkImage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace app.vtclive.Api.Home
{
    
    [RoutePrefix("api/home")]
    public class HomeController : ApiController
    {
        private static string _playbackUrl = "http://api.vtcnews.vn/";
        [Route("news/menu")]
        public async Task<HttpResponseMessage> GetMenuAsync()
        {
            try
            {              
                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/news/getcategory";
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
        [Route("news/getarticlehot")]
        public async Task<HttpResponseMessage> GetGetarticlehotAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/news/getarticlehot";
                    var responsePost = await httpClient.GetAsync(url);
                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();

                        dynamic outputs = JsonConvert.DeserializeObject(responseBody);
                        foreach(var output in outputs)
                        {
                            output.image16_9_large = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_480x270", (string)output.ImageUrl) + "/" + (string)output.ImageUrl;
                            output.image16_9 = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_160x90", (string)output.ImageUrl) + "/" + (string)output.ImageUrl;
                           
                           
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
        [Route("news/getchannelhot")]
        public async Task<HttpResponseMessage> GetChannelHotAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/news/getchannelhot";
                    var responsePost = await httpClient.GetAsync(url);
                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();

                        dynamic outputs = JsonConvert.DeserializeObject(responseBody);
                        foreach (var output in outputs)
                        {
                            output.image16_9 = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_160x90", (string)output.ImageUrl) + "/" + (string)output.ImageUrl;
                          
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
        [Route("news/GetArticleSuggestionHome")]
        public async Task<HttpResponseMessage> GetArticleSuggestionHomeAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/news/GetArticleSuggestionHome";
                    var responsePost = await httpClient.GetAsync(url);
                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();

                        dynamic outputs = JsonConvert.DeserializeObject(responseBody);
                        foreach (var output in outputs)
                        {
                            output.image16_9 = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_160x90", (string)output.ImageUrl) + "/" + (string)output.ImageUrl;
                           
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
        [Route("news/GetVideoHome")]
        public async Task<HttpResponseMessage> GetVideoHomeAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/news/GetVideoHome";
                    var responsePost = await httpClient.GetAsync(url);
                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();

                        dynamic outputs = JsonConvert.DeserializeObject(responseBody);
                        foreach (var output in outputs)
                        {
                            output.image16_9_large = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_480x270", (string)output.ImageUrl) + "/" + (string)output.ImageUrl;
                            output.image16_9 = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_160x90", (string)output.ImageUrl) + "/" + (string)output.ImageUrl;
                          
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
        [Route("news/GetVideoDetail/{Id}")]
        public async Task<HttpResponseMessage> GetVideoDetail(int Id)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/news/GetVideoDetail?articleId="+Id;
                    var responsePost = await httpClient.GetAsync(url);
                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();
                        dynamic outputs = JsonConvert.DeserializeObject(responseBody);                       
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
        [Route("news/GetVideoHome/{Id}")]
        public async Task<HttpResponseMessage> GetVideoHomeIdAsync(int Id)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/news/GetVideoHome";
                    var responsePost = await httpClient.GetAsync(url);
                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();
                        dynamic outputs = JsonConvert.DeserializeObject(responseBody);
                        foreach (var output in outputs)
                        {
                            if(output.Id == Id)
                            {
                                output.image16_9 = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_160x90", (string)output.ImageUrl) + "/" + (string)output.ImageUrl;
                              
                                return Request.CreateResponse(HttpStatusCode.OK, (Object)output, Configuration.Formatters.JsonFormatter);
                            }
                           
                        }
                        return Request.CreateResponse(HttpStatusCode.OK, false, Configuration.Formatters.JsonFormatter);
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
        [Route("news/detail/{id}")]
        public async Task<HttpResponseMessage> GetDetailAsync(int id)
        {
            var data = new { Id = id };
          
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/news/detail?Id=" +id;
                    var responsePost = await httpClient.GetAsync(url);
                    
                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();
                        dynamic outputs = JsonConvert.DeserializeObject(responseBody);
                        outputs.image16_9 = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_160x90", (string)outputs.DetailData.ImageUrl) + "/" + (string)outputs.DetailData.ImageUrl;
                        foreach (var output in outputs.ListArticleRelated)
                        {
                            output.imagecrop = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_160x90", (string)output.ImageUrl) + "/" + (string)output.ImageUrl;
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
        [Route("news/ListChannel/{pageIndex}")]
        public async Task<HttpResponseMessage> GetListChannelAsync(int pageIndex)
        {
            var data = new { Id = pageIndex };

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/news/ListChannel?pageIndex=" + pageIndex;
                    var responsePost = await httpClient.PostAsJsonAsync(url, data);

                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();
                        dynamic outputs = JsonConvert.DeserializeObject(responseBody);
                        foreach (var output in outputs)
                        {
                            output.image16_9 = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_160x90", (string)output.ImageUrl) + "/" + (string)output.ImageUrl;
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
        [Route("news/IndexChannelPaging/{pageIndex}/{id}")]
        public async Task<HttpResponseMessage> GetIndexChannelPagingAsync(int pageIndex, int id)
        {
            var data = new { pageIndex = pageIndex , id = id};
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/news/IndexChannelPaging?pageIndex="+pageIndex+"&id=" + id;
                    var responsePost = await httpClient.PostAsJsonAsync(url, data);

                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();
                        dynamic outputs = JsonConvert.DeserializeObject(responseBody);
                        foreach (var output in outputs.Items)
                        {
                            output.image16_9 = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_160x90", (string)output.ImageUrl) + "/" + (string)output.ImageUrl;
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
        [Route("news/trending/{pageIndex}")]
        public async Task<HttpResponseMessage> GetTrendAsync(int pageIndex)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/news/trending?pageIndex="+ pageIndex;
                    var responsePost = await httpClient.GetAsync(url);
                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();

                        dynamic outputs = JsonConvert.DeserializeObject(responseBody);
                        foreach (var output in outputs)
                        {
                            output.image16_9 = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_160x90", (string)output.ImageUrl) + "/" + (string)output.ImageUrl;
                           
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
        [Route("news/comment/GetComment/{articleId}/{pageIndex}")]
        public async Task<HttpResponseMessage> GetCommentAsync(int pageIndex, int articleId)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {                  
                    string url = _playbackUrl + "api/comment/GetComment?articleId="+ articleId+"&pageIndex="+ pageIndex;
                    var responsePost = await httpClient.GetAsync(url);
                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();

                        dynamic outputs = JsonConvert.DeserializeObject(responseBody);                       
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
        [Route("comment/PostComment")]
        public async Task<HttpResponseMessage> PostCommentAsync(string _username,string _email, long _idArticle, string _idComment, string _value)
        {
            try
            {
               string _token= LinkImg.GetTokenComment(_idArticle);
                var  data = new  { token=_token, username = _username, email  = _email , idArticle = _idArticle , idComment = _idComment , value = _value };
                using (var httpClient = new HttpClient())
                {                  
                    string url = _playbackUrl + "api/comment/PostComment?token="+ _token+"&username="+ _username+"&email="+_email+ "&idArticle="+ _idArticle+ "&idComment="+ _idComment + "&value="+ _value;
                    var responsePost = await httpClient.PostAsJsonAsync(url, data);
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
        [Route("video/GetVideoById")]
        public async Task<HttpResponseMessage> GetVideoByIdAsync(string text)
        {
            try
            {
                
                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/video/GetVideoById?plist=" + text;
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

        [Route("news/NewsHot/{categoryId}")]
        public async Task<HttpResponseMessage> GetNewsHot(int categoryId)
        {
            try
            {

                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/news/NewsHot?categoryId=" + categoryId;
                    var responsePost = await httpClient.GetAsync(url);
                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();
                        dynamic outputs = JsonConvert.DeserializeObject(responseBody);
                        foreach (var output in outputs)
                        {
                            output.image16_9 = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_160x90", (string)output.ImageUrl) + "/" + (string)output.ImageUrl;
                           
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
        [Route("news/ArticleCategoryPaging/{pageIndex}/{id}")]
        public async Task<HttpResponseMessage> GetArticleCategoryPaging(int pageIndex, int id)
        {
            try
            {

                using (var httpClient = new HttpClient())
                {
                    string url = _playbackUrl + "api/news/ArticleCategoryPaging?pageIndex="+ pageIndex+"&id=" + id;
                    var responsePost = await httpClient.GetAsync(url);
                    if (responsePost.IsSuccessStatusCode)
                    {
                        string responseBody = await responsePost.Content.ReadAsStringAsync();
                        dynamic outputs = JsonConvert.DeserializeObject(responseBody);
                        foreach (var output in outputs)
                        {
                            output.image16_9 = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_160x90", (string)output.ImageUrl) + "/" + (string)output.ImageUrl;
                            output.imagecrop = "https://image.vtc.vn/resize/" + LinkImg.GetStringEncryptImage("crop_160x90", (string)output.ImageUrl) + "/" + (string)output.ImageUrl;

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

    }
}
