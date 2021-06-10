using ProductManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagerUI.Controllers
{
    public class TypeManagementController : Controller
    {
        // GET: TypeManagement
        public ActionResult Index()
        {
            ViewBag.SystemTypes = SystemHelper.GetSystemTypeList();
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}