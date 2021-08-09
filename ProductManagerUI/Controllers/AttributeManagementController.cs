using Newtonsoft.Json;
using ProductManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProductManagerUI.Controllers
{
    [RoutePrefix("attributes")]
    public class AttributeManagementController : MainController
    {
        // GET: AttributeManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SubVariants()
        {
            return View();
        }

        [HttpGet]
        [Route("all")]
        public async Task<JsonResult> GetAll()
        {

            var resObj = await RestClientGetFromAPI("productAttributes", null);
            if (resObj.rCode == 0 && resObj.rObj != null)
            {
                var obj = resObj.rObj;
                var responseObj = JsonConvert.DeserializeObject<AttributesViewModel>(obj.ToString());

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
        //[Route("{attributeId}")]
        public async Task<JsonResult> GetSubAttributes(int attributeId)
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
                new KeyValuePair<string, string>("id",attributeId.ToString())
            };
            var resObj = await RestClientGetFromAPI("productAttributeValues/"+ attributeId, null);
            if (resObj.rCode == 0 && resObj.rObj != null)
            {
                var obj = resObj.rObj;
                var responseObj = JsonConvert.DeserializeObject<AttributeModel>(obj.ToString());

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
        public async Task<JsonResult> PostOne(AttributeModel model)
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
                attributeId = model.id,
                ProductVariantAttribute = model.VariantAttributeModel,
                ProductVariantSubAttributes = model.VariantSubAttributeList
            };
            var inObj = new
            {
                ProductCategory = obj
            };
            var resObj = await RestClientPostToAPI("productType", inObj);

            return Json(resObj, "application/json", JsonRequestBehavior.AllowGet);
        }

    }
}