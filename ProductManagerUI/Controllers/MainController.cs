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

namespace ProductManagerUI.Controllers
{
    public class MainController : Controller
    {
        private string userName = "johnDoe";
        private string password = "1234567890";
         
        public object APIBridge(string entity)
        {
            var baseURL = "http://localhost:1002/"+entity;

            try
            {
                var client = new RestClient(baseURL);
                client.Authenticator = new HttpBasicAuthenticator(userName, password);
                var response = client.Execute(new RestRequest());

                return response.Content;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public string PostToAPI(string entity,object data)
        { 
            var url = "http://localhost:1002/" + entity;

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";
             
            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var result = "";
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }

        public ActionResult GetCategories()
        {
            var obj = APIBridge("productCategories");

            return View();
        }
         
    }

}
