using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Security;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using Robsoft.Logger;

namespace ProductManagerUI.Controllers
{
    public class MainController : Controller
    {
        private string userName = "johnDoe";
        private string password = "1234567890";
        private static string baseUrl = ConfigurationManager.AppSettings["PRODBASEURL"];

        public object APIBridge(string entity)
        {
            var baseURL = "http://localhost:1002/"+entity;

            try
            {
                var client = new RestClient(baseUrl);
                client.Authenticator = new HttpBasicAuthenticator(userName, password);
                var response = client.Execute(new RestRequest());

                return response.Content;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public string PostToAPI1(string entity, string data)
        {
            var url = "http://localhost:1002/" + entity;
            var result = "";
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "POST";

                httpRequest.Accept = "application/json";
                httpRequest.ContentType = "application/json";

                var datas = JsonConvert.DeserializeObject(data);

                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(datas);
                }

               
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                // generic error handling
                result = string.Format("Could not get data. {0}", ex);
            }

            return result;
        }

        public static async Task<ResponseModel> HttpClientPostToAPI(string entity, string data)
        {
            ResponseModel responseObj = null;
            // Posting.  
            using (var client = new HttpClient())
            {
                // Setting Base address.  
                client.BaseAddress = new Uri(baseUrl);

                // Setting content type.                   
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Initialization.  
                HttpResponseMessage response = new HttpResponseMessage();

                var requestObj = JsonConvert.DeserializeObject(data);

                // HTTP POST  
                response = await client.PostAsJsonAsync(entity, requestObj).ConfigureAwait(false);

                // Verification  
                if (response.IsSuccessStatusCode)
                {
                    // Reading Response.  
                    string result = response.Content.ReadAsStringAsync().Result;
                    responseObj = JsonConvert.DeserializeObject<ResponseModel>(result);
                }
            }

            return responseObj;
        }

        public static async Task<ResponseModel> RestClientPostToAPI(string uri, dynamic requestParameters, string acceptHeaderValue = "application/json", string contentTypeHeaderValue = "application/json")
        {
            ResponseModel responseObj = null;

            try
            {
                //Create a restclient  
                var restClient = new RestClient(baseUrl);

                var request = new RestRequest(uri, Method.POST)
                { RequestFormat = DataFormat.Json };
                //Define request headers
                request.AddHeader("Accept", acceptHeaderValue);
                request.AddHeader("Content-Type", contentTypeHeaderValue);
                request.AddHeader("cache-control", "no-cache");
                //request.AddHeader("apiKey", ApiKey);

                //Define request parameters 
                if (requestParameters != null)
                    request.AddJsonBody(requestParameters);
                //request.AddParameter("application/x-www-form-urlencoded", requestParameters, ParameterType.RequestBody);

                //Create a restResponse  
                var response = await restClient.ExecuteAsync(request);
                var responseContent = response.Content;

                //Deserializing the response recieved from web api and storing into a Model 
                responseObj = JsonConvert.DeserializeObject<ResponseModel>(responseContent);
            }
            catch(Exception ex)
            {
                LogHelper.Log(LogLevel.SEVERE, ex.Message, "RestClientPostToAPI", "MainController");
            }
            return responseObj;
        }

        public static async Task<ResponseModel> HttpClientGetFromAPI(string entity, string data)
        {
            ResponseModel responseObj = null;
            // Posting.  
            using (var client = new HttpClient())
            {
                // Setting Base address.  
                client.BaseAddress = new Uri(baseUrl);

                // Setting content type.                   
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Initialization.  
                HttpResponseMessage response = new HttpResponseMessage();

                var requestObj = JsonConvert.DeserializeObject(data);

                // HTTP POST  
                response = await client.GetAsync(entity).ConfigureAwait(false);

                // Verification  
                if (response.IsSuccessStatusCode)
                {
                    // Reading Response.  
                    string result = response.Content.ReadAsStringAsync().Result;
                    responseObj = JsonConvert.DeserializeObject<ResponseModel>(result);
                }
            }

            return responseObj;
        }

        public static async Task<ResponseModel> RestClientGetFromAPI(string uri, List<KeyValuePair<string, string>> requestParameters, string acceptHeaderValue = "application/json", string contentTypeHeaderValue = "application/json")
        {
            ResponseModel responseObj = null;

            try
            {
                //Create a restclient  
                var restClient = new RestClient(baseUrl);

                var request = new RestRequest(uri, Method.GET)
                { RequestFormat = DataFormat.Json };
                //Define request headers
                request.AddHeader("Accept", acceptHeaderValue);
                request.AddHeader("Content-Type", contentTypeHeaderValue);
                request.AddHeader("cache-control", "no-cache");
                //request.AddHeader("apiKey", ApiKey);

                //Define request parameters 
                //if (requestParameters != null)
                //    request.AddJsonBody(requestParameters);
                //request.AddParameter("application/x-www-form-urlencoded", requestParameters, ParameterType.RequestBody);
                if (requestParameters != null && requestParameters.Count > 0)
                {
                    foreach (KeyValuePair<string, string> pair in requestParameters)
                    {
                        if (string.IsNullOrWhiteSpace(pair.Value))
                            continue;

                        request.AddQueryParameter(pair.Key, pair.Value);
                    }
                }

                //Create a restResponse  
                var response = await restClient.ExecuteAsync(request);
                var responseContent = response.Content;
                if (!string.IsNullOrWhiteSpace(responseContent))
                    //Deserializing the response recieved from web api and storing into a Model 
                    responseObj = JsonConvert.DeserializeObject<ResponseModel>(responseContent);
                else
                {
                    responseObj = new ResponseModel
                    {
                        rCode = 1,
                        rObj = null,
                        Message = "No Data Found"
                    }; 
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.SEVERE, ex.Message, "RestClientPostToAPI", "MainController");
            }
            return responseObj;
        }
           
    }

    public class ResponseModel
    {
        public byte rCode { get; set; }
        public string Message { get; set; }
        public object rObj { get; set; }
    }
}
