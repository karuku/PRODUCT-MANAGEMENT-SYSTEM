using Newtonsoft.Json;
using ProductManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Robsoft.Extentions.DotNet;

namespace ProductManagerUI.Controllers
{
    [RoutePrefix("types")]
    public class TypeManagementController : MainController
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

        [HttpGet]
        [Route("all")]
        public async Task<JsonResult> GetAll()
        { 
            var resObj = await RestClientGetFromAPI("productTypes", null);
            if (resObj.rCode == 0 && resObj.rObj != null)
            {
                var obj = resObj.rObj;
                var responseObj = JsonConvert.DeserializeObject<TypesViewModel>(obj.ToString());

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
            var resObj = await RestClientGetFromAPI("productTypes", parameters);
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
        public async Task<JsonResult> PostOne(TypeModel model)
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
                systemTypeId = (byte)model.systemTypeId,
                name = model.typeName,
                typeDesc = model.typeDescription
            };
            var inObj = new
            {
                ProductType = obj
            };
            var resObj = await RestClientPostToAPI("productType", inObj);

            return Json(resObj, "application/json", JsonRequestBehavior.AllowGet);
        }

    }
}