using Newtonsoft.Json;
using ProductManagerUI.Models;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
//using ProductManagerData.DTO;

namespace ProductManagerUI.Controllers
{
    [RoutePrefix("categories")]
    public class CategoryManagementController : MainController
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

        [HttpGet]
        [Route("all")]
        public async Task<JsonResult> GetAll()
        {
          
            var resObj = await RestClientGetFromAPI("productCategories", null);
            if(resObj.rCode==0 && resObj.rObj != null)
            {
                var obj = resObj.rObj;
                var responseObj = JsonConvert.DeserializeObject<CategoriesViewModel>(obj.ToString());
                
                var rModel = new ResponseModel
                {
                    rCode = 0,
                    Message = "Success",
                    rObj = responseObj
                };
                return Json(rModel, "application/json", JsonRequestBehavior.AllowGet);
            }
             
            return Json(resObj, "application/json", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<JsonResult> GetOne(int id)
        {
            var rModel = new ResponseModel
            {
                rCode = 1,
                Message = "Invalid Request"
            };
            if (!ModelState.IsValid)
            {
                rModel.Message = "Invalid Model";
                return Json(rModel, "application/json", JsonRequestBehavior.AllowGet);
            }
            var parameters = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("id",id.ToString())
            };
            var resObj = await RestClientGetFromAPI("productCategories", parameters);
            if (resObj.rCode == 0 && resObj.rObj != null)
            {
                var obj = resObj.rObj;
                var responseObj = JsonConvert.DeserializeObject<CategoryModel>(obj.ToString());

                rModel = new ResponseModel
                {
                    rCode = 0,
                    Message = "Success",
                    rObj = responseObj
                }; 
            }

            return Json(rModel, "application/json", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("edit")]
        public async Task<JsonResult> PostOne(CategoryModel model)
        {
            var rModel = new ResponseModel
            {
                rCode = 1,
                Message = "Invalid Request"
            };
            if (!ModelState.IsValid)
            {
                rModel.Message = "Invalid Model";
                return Json(rModel, "application/json", JsonRequestBehavior.AllowGet);
            }
            var obj = new
            {
                id = model.id,
                name = model.catName,
                catDesc = model.catDescription,
                createdAt = DateTime.Now
            };
            var inObj = new
            {
                ProductCategory = obj
            };
            var resObj = await RestClientPostToAPI("productCategory", inObj);
           
            return Json(resObj, "application/json", JsonRequestBehavior.AllowGet);
        }

    }
}