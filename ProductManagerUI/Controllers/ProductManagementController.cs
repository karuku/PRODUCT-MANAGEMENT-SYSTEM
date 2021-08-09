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
    public class ProductManagementController : MainController
    {
        // GET: ProductManagement
        public ActionResult Index()
        {
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

            var resObj = await RestClientGetFromAPI("products", null);
            if (resObj.rCode == 0 && resObj.rObj != null)
            {
                var obj = resObj.rObj;
                var responseObj = JsonConvert.DeserializeObject<ProductsViewModel>(obj.ToString());

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
            var resObj = await RestClientGetFromAPI("products", parameters);
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
        public async Task<JsonResult> PostMany(ProductDetailsModel model)
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
                productId = model.id,
                Product = model.ProductModel,
                ProductStandard = model.ProductStandardModel,
                ProductCompositeLines = model.ProductCompositeList,
                ProductVariants = model.ProductVariantList
            };
            var inObj = new
            {
                Products = obj
            };
            var resObj = await RestClientPostToAPI("products", obj);

            return Json(resObj, "application/json", JsonRequestBehavior.AllowGet);
        }

    }
}