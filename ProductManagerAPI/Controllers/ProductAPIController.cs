using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductManagerAPI.Helpers;
using ProductManagerAPI.Models;
using ProductManagerData;
using ProductManagerData.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;

namespace ProductManagerAPI.Controllers
{
    public class ProductAPIController : ApiController
    {
        private string json = "";
        private string responseMessage = "";

        [HttpGet]
        [Route("productCategories")]
        public HttpResponseMessage GetCategories()
        { 
                //Create HTTP Response.
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            try
            { 
                var modelList = Repository.GetCategoryList();

                //Check whether list is empty
                if (modelList == null || modelList.Count == 0)
                {
                    //Throw 204 (No Content) exception
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.ReasonPhrase = string.Format("No data found");
                    throw new HttpResponseException(response);
                }

                responseMessage = "Found";

                var obj = new { categoryList = modelList };

                json = ApiVariables.ResponseJson(0, responseMessage, obj);

                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                json = ApiVariables.ResponseJson(1, responseMessage);

                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpPost]
        [Route("productCategory")]
        public HttpResponseMessage PostCategory([FromBody]JToken postData)
        {
            #region prepare api

            HttpResponseMessage response = null;
            string responseMessage = "";
            string json = "";
            if (postData == null)
            {
                responseMessage = "request data cannot be empty";
                json = ApiVariables.ResponseJson(1, responseMessage);

                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                return response;
            }

            #endregion

            try
            {
                var res = false;
                 
                #region get object
                var requestObjModel = JsonConvert.DeserializeObject<CategoryModel>(postData.ToString());
                var requestObj = requestObjModel.ProductCategory;

                if (requestObj == null)
                {
                    responseMessage = OutputModel.GetEmpty("input data");
                    json = ApiVariables.ResponseJson(1, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }
                if (string.IsNullOrWhiteSpace(requestObj.name))
                {
                    responseMessage = OutputModel.GetEmpty("Name");
                    json = ApiVariables.ResponseJson(1, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }
                #endregion

                #region send object to db
                var model = new MasterProductCategoryDTO
                {
                    id = requestObj.id,
                    name = requestObj.name,
                    catDesc = requestObj.catDesc,
                    createdAt = DateTime.Now
                };

                res = Repository.AddCategory(model);

                if (res)
                {
                    responseMessage = OutputModel.GetAddSuccess("Category");

                    json = ApiVariables.ResponseJson(0, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }
                else
                {
                    responseMessage = OutputModel.GetAddError("Category");
                    json = ApiVariables.ResponseJson(1, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }
                #endregion

            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                json = ApiVariables.ResponseJson(1, responseMessage);

                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            // Info.  
            return response;
        }

        [HttpGet]
        [Route("productTypes")]
        public HttpResponseMessage GetTypes()
        {
            //Create HTTP Response.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            try {
                 
                var modelList = Repository.GetTypeList();

            //Check whether list is empty
            if (modelList == null || modelList.Count==0)
            {
                //Throw 204 (No Content) exception
                response.StatusCode = HttpStatusCode.NoContent;
                response.ReasonPhrase = string.Format("No data found");
                throw new HttpResponseException(response);
            }

            responseMessage = "Found";

            var obj = new { typeList = modelList };

            json = ApiVariables.ResponseJson(0, responseMessage, obj);

            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                json = ApiVariables.ResponseJson(1, responseMessage);

                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpPost]
        [Route("productType")]
        public HttpResponseMessage PostType([FromBody]JToken postData)
        {
            #region prepare api

            HttpResponseMessage response = null;
            string responseMessage = "";
            string json = "";
            if (postData == null)
            {
                responseMessage = "request data cannot be empty";
                json = ApiVariables.ResponseJson(1, responseMessage);

                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                return response;
            }

            #endregion

            try
            {
                var res = false;
                 
                #region get object
                var requestObjModel = JsonConvert.DeserializeObject<TypeModel>(postData.ToString());
                var requestObj = requestObjModel.ProductType;

                if (requestObj == null)
                {
                    responseMessage = OutputModel.GetEmpty("input data");
                    json = ApiVariables.ResponseJson(1, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }
                if (string.IsNullOrWhiteSpace(requestObj.name))
                {
                    responseMessage = OutputModel.GetEmpty("Name");
                    json = ApiVariables.ResponseJson(1, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }
                #endregion

                #region send object to db
                var model = new MasterProductTypeDTO
                {
                    id = requestObj.id,
                    name = requestObj.name,
                    typeDesc = requestObj.typeDesc,
                    createdAt = DateTime.Now
                };

                res = Repository.AddType(model);

                if (res)
                {
                    responseMessage = OutputModel.GetAddSuccess("Type");

                    json = ApiVariables.ResponseJson(0, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }
                else
                {
                    responseMessage = OutputModel.GetAddError("Type");
                    json = ApiVariables.ResponseJson(1, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }
                #endregion

            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                json = ApiVariables.ResponseJson(1, responseMessage);

                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            // Info.  
            return response;
        }


        [HttpGet]
        [Route("products")]
        public HttpResponseMessage GetProducts()
        {
            //Create HTTP Response.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            try {
                 
                var modelList = Repository.GetProductDetailList();

            //Check whether list is empty
            if (modelList == null || modelList.Count==0)
            {
                //Throw 204 (No Content) exception
                response.StatusCode = HttpStatusCode.NoContent;
                response.ReasonPhrase = string.Format("No data found");
                throw new HttpResponseException(response);
            }

            responseMessage = "Found";

            var obj = new { ProductList = modelList };

            json = ApiVariables.ResponseJson(0, responseMessage, obj);

            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                json = ApiVariables.ResponseJson(1, responseMessage);

                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpGet]
        [Route("products/<categoryId>")]
        public HttpResponseMessage GetProducts(Int32 categoryId)
        {
            //Create HTTP Response.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            try {
                 
                var modelList = Repository.GetProductList().Where(c => c.catId == categoryId).ToList();

            //Check whether list is empty
            if (modelList == null || modelList.Count==0)
            {
                //Throw 204 (No Content) exception
                response.StatusCode = HttpStatusCode.NoContent;
                response.ReasonPhrase = string.Format("No data found for categoryId: {0} ", categoryId);
                throw new HttpResponseException(response);
            }

            responseMessage = "Found";

            var obj = new { ProductList = modelList };

            json = ApiVariables.ResponseJson(0, responseMessage, obj);

            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                json = ApiVariables.ResponseJson(1, responseMessage);

                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpPost]
        [Route("products")]
        public HttpResponseMessage PostProducts([FromBody]JToken postData)
        {
            #region prepare api

            HttpResponseMessage response = null;
            string responseMessage = "";
            string json = "";
            if (postData == null)
            {
                responseMessage = "request data cannot be empty";
                json = ApiVariables.ResponseJson(1, responseMessage);

                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                return response;
            }

            #endregion

            var successCount = 0;
            var totalCount = 0;
            try
            {
                var res = false;
                 
                #region get object and validate
                var requestObj = JsonConvert.DeserializeObject<ProductModel>(postData.ToString());

                if (requestObj == null || requestObj.Product == null)
                {
                    responseMessage = OutputModel.GetEmpty("input data");
                    json = ApiVariables.ResponseJson(1, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }
                if (string.IsNullOrWhiteSpace(requestObj.Product.name))
                {
                    responseMessage = OutputModel.GetEmpty("Name");
                    json = ApiVariables.ResponseJson(1, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }
                if (requestObj.Product.catId <= 0)
                {
                    responseMessage = OutputModel.GetEmpty("Category");
                    json = ApiVariables.ResponseJson(1, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }
                if (requestObj.Product.typeId <= 0)
                {
                    responseMessage = OutputModel.GetEmpty("Type");
                    json = ApiVariables.ResponseJson(1, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }

                #endregion

                var productId = requestObj.productId;

                switch (requestObj.Product.MasterProductType.systemType)
                {
                    case SystemProductTypes.STANDARD:
                        #region send object to db
                        var model = requestObj.ProductStandard;
                        model.Product = requestObj.Product;
                        model.Product.id = productId;
                        model.prodId = productId;
                        res = Repository.AddProductStandardAlloc(model);

                        if (res)
                        {
                            responseMessage = OutputModel.GetAddSuccess("Standard Product");

                            json = ApiVariables.ResponseJson(0, responseMessage);

                            response = Request.CreateResponse(HttpStatusCode.OK);
                            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                            return response;
                        }
                        else
                        {
                            responseMessage = OutputModel.GetAddError("Standard Product");
                            json = ApiVariables.ResponseJson(1, responseMessage);

                            response = Request.CreateResponse(HttpStatusCode.BadRequest);
                            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                            return response;
                        }
                    #endregion
                    case SystemProductTypes.VARIANT:
                        #region send object to db
                        var modelVariants = requestObj.ProductVariants;
                        var productModel = requestObj.Product;
                        productModel.id = productId;

                        productId = Repository.AddProductReturnId(productModel);
                        if (productId <= 0)
                        {
                            responseMessage = "Product Could not be added";
                            json = ApiVariables.ResponseJson(1, responseMessage);

                            response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                            return response;
                        }
                        totalCount = modelVariants.Count;
                        foreach (var mymodel in modelVariants)
                        {
                            mymodel.prodId = productId;
                            res = Repository.AddProductVariantAlloc(mymodel);
                            if (res)
                                successCount++;
                        }
                        if (successCount > 0)
                        {
                            responseMessage = OutputModel.GetBulkSuccessResult("Variant Product", successCount, totalCount);

                            json = ApiVariables.ResponseJson(0, responseMessage);

                            response = Request.CreateResponse(HttpStatusCode.OK);
                            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                            return response;
                        }
                        else
                        {
                            responseMessage = OutputModel.GetBulkErrorResult("Variant Product", 0, totalCount);
                            json = ApiVariables.ResponseJson(1, responseMessage);

                            response = Request.CreateResponse(HttpStatusCode.BadRequest);
                            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                            return response;
                        }
                    #endregion
                    case SystemProductTypes.COMPOSITE:
                        #region send object to db
                        var modelComposites = requestObj.ProductCompositeLines;
                        var productModel2 = requestObj.Product;
                        productModel2.id = productId;

                        productId = Repository.AddProductReturnId(productModel2);
                        if (productId <= 0)
                        {
                            responseMessage = "Product Could not be added";
                            json = ApiVariables.ResponseJson(1, responseMessage);

                            response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                            return response;
                        }
                        totalCount = modelComposites.Count;
                        foreach (var mymodel in modelComposites)
                        {
                            res = Repository.AddProductCompositeLine(mymodel);
                            if (res)
                                successCount++;
                        }
                        if (successCount > 0)
                        {
                            responseMessage = OutputModel.GetBulkSuccessResult("COMPOSITE Product", successCount, totalCount);

                            json = ApiVariables.ResponseJson(0, responseMessage);

                            response = Request.CreateResponse(HttpStatusCode.OK);
                            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                            return response;
                        }
                        else
                        {
                            responseMessage = OutputModel.GetBulkErrorResult("COMPOSITE Product", 0, totalCount);
                            json = ApiVariables.ResponseJson(1, responseMessage);

                            response = Request.CreateResponse(HttpStatusCode.BadRequest);
                            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                            return response;
                        }
                    #endregion
                    default:
                        return response;
                }
            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                json = ApiVariables.ResponseJson(1, responseMessage);

                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            // Info.  
            return response;
        }

        [HttpPut]
        [Route("products")]
        public HttpResponseMessage PutProducts([FromBody]JToken postData)
        {
            #region prepare api

            HttpResponseMessage response = null;
            string responseMessage = "";
            string json = "";
            if (postData == null)
            {
                responseMessage = "request data cannot be empty";
                json = ApiVariables.ResponseJson(1, responseMessage);

                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                return response;
            }

            #endregion

            var successCount = 0;
            var totalCount = 0;
            try
            {
                var res = false;
                 
                #region get object and validate
                var requestObj = JsonConvert.DeserializeObject<ProductModel>(postData.ToString());

                if (requestObj == null || requestObj.Product == null)
                {
                    responseMessage = OutputModel.GetEmpty("input data");
                    json = ApiVariables.ResponseJson(1, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }
                if (string.IsNullOrWhiteSpace(requestObj.Product.name))
                {
                    responseMessage = OutputModel.GetEmpty("Name");
                    json = ApiVariables.ResponseJson(1, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }
                if (requestObj.Product.catId <= 0)
                {
                    responseMessage = OutputModel.GetEmpty("Category");
                    json = ApiVariables.ResponseJson(1, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }
                if (requestObj.Product.typeId <= 0)
                {
                    responseMessage = OutputModel.GetEmpty("Type");
                    json = ApiVariables.ResponseJson(1, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }

                #endregion

                var productId = requestObj.productId;

                switch (requestObj.Product.MasterProductType.systemType)
                {
                    case SystemProductTypes.STANDARD:
                        #region send object to db
                        var model = requestObj.ProductStandard;
                        model.Product = requestObj.Product;
                        model.Product.id = productId;
                        model.prodId = productId;
                        res = Repository.UpdateProductStandardAlloc(model);

                        if (res)
                        {
                            responseMessage = OutputModel.GetUpdateSuccess("Standard Product");

                            json = ApiVariables.ResponseJson(0, responseMessage);

                            response = Request.CreateResponse(HttpStatusCode.OK);
                            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                            return response;
                        }
                        else
                        {
                            responseMessage = OutputModel.GetUpdateError("Standard Product");
                            json = ApiVariables.ResponseJson(1, responseMessage);

                            response = Request.CreateResponse(HttpStatusCode.BadRequest);
                            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                            return response;
                        }
                    #endregion
                    case SystemProductTypes.VARIANT:
                        #region send object to db
                        var modelVariants = requestObj.ProductVariants;
                        var productModel = requestObj.Product;
                        productModel.id = productId;

                        res = Repository.UpdateProduct(productModel);
                        if (!res)
                        {
                            responseMessage = "Product Could not be updated";
                            json = ApiVariables.ResponseJson(1, responseMessage);

                            response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                            return response;
                        }
                        totalCount = modelVariants.Count;
                        foreach (var mymodel in modelVariants)
                        {
                            mymodel.prodId = productId;
                            res = Repository.UpdateProductVariantAlloc(mymodel);
                            if (res)
                                successCount++;
                        }
                        if (successCount > 0)
                        {
                            responseMessage = OutputModel.GetBulkSuccessResult("Variants Product", successCount, totalCount);

                            json = ApiVariables.ResponseJson(0, responseMessage);

                            response = Request.CreateResponse(HttpStatusCode.OK);
                            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                            return response;
                        }
                        else
                        {
                            responseMessage = OutputModel.GetBulkErrorResult("Variant Product", 0, totalCount);
                            json = ApiVariables.ResponseJson(1, responseMessage);

                            response = Request.CreateResponse(HttpStatusCode.BadRequest);
                            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                            return response;
                        }
                    #endregion
                    case SystemProductTypes.COMPOSITE:
                        #region send object to db
                        var modelComposites = requestObj.ProductCompositeLines;
                        var productModel2 = requestObj.Product;
                        productModel2.id = productId;

                        res = Repository.UpdateProduct(productModel2);
                        if (!res)
                        {
                            responseMessage = "Product Could not be updated";
                            json = ApiVariables.ResponseJson(1, responseMessage);

                            response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                            return response;
                        }
                        totalCount = modelComposites.Count;
                        foreach (var mymodel in modelComposites)
                        {
                            res = Repository.UpdateProductCompositeLine(mymodel);
                            if (res)
                                successCount++;
                        }
                        if (res)
                        {
                            responseMessage = OutputModel.GetBulkSuccessResult("COMPOSITE Products", successCount, totalCount);

                            json = ApiVariables.ResponseJson(0, responseMessage);

                            response = Request.CreateResponse(HttpStatusCode.OK);
                            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                            return response;
                        }
                        else
                        {
                            responseMessage = OutputModel.GetBulkErrorResult("COMPOSITE Product", 0, totalCount);
                            json = ApiVariables.ResponseJson(1, responseMessage);

                            response = Request.CreateResponse(HttpStatusCode.BadRequest);
                            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                            return response;
                        }
                    #endregion
                    default:
                        return response;
                }
            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                json = ApiVariables.ResponseJson(1, responseMessage);

                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            // Info.  
            return response;
        }


        [HttpPost]
        [Route("productAttributes")]
        public HttpResponseMessage PostProductAttributes([FromBody]JToken postData)
        {
            #region prepare api

            HttpResponseMessage response = null;
            string responseMessage = "";
            string json = "";
            if (postData == null)
            {
                responseMessage = "request data cannot be empty";
                json = ApiVariables.ResponseJson(1, responseMessage);

                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                return response;
            }

            #endregion

            var successCount = 0;
            var totalCount = 0;
            try
            {
                var res = false;
                 
                #region get object and validate
                var requestObj = JsonConvert.DeserializeObject<ProductAttributesViewModel>(postData.ToString());

                if (requestObj == null || requestObj.ProductAttributes == null || requestObj.ProductAttributes.Count <= 0)
                {
                    responseMessage = OutputModel.GetEmpty("input data");
                    json = ApiVariables.ResponseJson(1, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }

                #endregion

                #region send object to db
                var modelAttributes = requestObj.ProductAttributes;

                totalCount = modelAttributes.Count;
                foreach (var mymodel in modelAttributes)
                {
                    var dbModel = new MasterProductVariantAttributesDTO
                    {
                        MasterProductVariantAttribute = mymodel.ProductVariantAttribute,
                        MasterProductVariantSubAttributes = mymodel.ProductVariantSubAttributes
                    };
                    res = Repository.AddAttributeTransaction(dbModel);
                    if (res)
                    {
                        successCount++;
                    }
                }
                if (successCount > 0)
                {
                    responseMessage = OutputModel.GetBulkSuccessResult("Attributes", successCount, totalCount);

                    json = ApiVariables.ResponseJson(0, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }
                else
                {
                    responseMessage = OutputModel.GetBulkErrorResult("Attributes", 0, totalCount);
                    json = ApiVariables.ResponseJson(1, responseMessage);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    return response;
                }
                #endregion
            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                json = ApiVariables.ResponseJson(1, responseMessage);

                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            // Info.  
            return response;
        }

        [HttpGet]
        [Route("productAttributes")]
        public HttpResponseMessage GetProductAttributes()
        {
            //Create HTTP Response.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            try {
                 
                var modelList = Repository.GetAttributeList();

            //Check whether list is empty
            if (modelList == null || modelList.Count==0)
            {
                //Throw 204 (No Content) exception
                response.StatusCode = HttpStatusCode.NoContent;
                response.ReasonPhrase = string.Format("No data found ");
                throw new HttpResponseException(response);
            }

            responseMessage = "Found";

            var obj = new { AttributeList = modelList };

            json = ApiVariables.ResponseJson(0, responseMessage, obj);

            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                json = ApiVariables.ResponseJson(1, responseMessage);

                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpGet]
        [Route("productAttributeValues/<attributeId>")]
        public HttpResponseMessage GetProductSubAttributes(Int32 attributeId)
        {
            //Create HTTP Response.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            try {
                 
                var modelList = Repository.GetSubAttributeList().Where(c => c.attributeId == attributeId).ToList();

            //Check whether list is empty
            if (modelList == null || modelList.Count==0)
            {
                //Throw 204 (No Content) exception
                response.StatusCode = HttpStatusCode.NoContent;
                response.ReasonPhrase = string.Format("No data found for AttributeId: " + attributeId);
                throw new HttpResponseException(response);
            }

            responseMessage = "Found";

            var obj = new { AttributeValueList = modelList };

            json = ApiVariables.ResponseJson(0, responseMessage, obj);

            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                json = ApiVariables.ResponseJson(1, responseMessage);

                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            return response;
        }

    }

    public class ApiVariables
    {

        public static string ResponseJson(byte rCode, string message, dynamic responseObj = null)
        {
            var sModel = new ResponseModel
            {
                rCode = rCode,
                Message = message,
                rObj = responseObj
            };
            var json = JsonConvert.SerializeObject(sModel);

            return json;
        }

    }

    public class ResponseModel
    {
        public byte rCode { get; set; }
        public string Message { get; set; }
        public object rObj { get; set; }
    }
}