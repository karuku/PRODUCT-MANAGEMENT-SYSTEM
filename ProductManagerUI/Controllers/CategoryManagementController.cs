using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using ProductManagerData.DTO;

namespace ProductManagerUI.Controllers
{
    public class CategoryManagementController : Controller
    {
        // GET: CategoryManagement
        public ActionResult Index()
        { 
            return View();
        }

        // GET: CategoryManagement
        public ActionResult Edit()
        {
            return View();
        }
    
    }
}