using ProductManagerData.DTO;
using ProductManagerData.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization; 
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using System.Data.Entity; 
using Newtonsoft.Json; 
using Robsoft.Logger; 
using System.Reflection; 
using System.Data; 

namespace ProductManagerData
{
    public static class Repository
    {
        #region user
        
        public static List<AppUserDTO> GetUserList()
        {
            List<AppUserDTO> modelList = new List<AppUserDTO>();
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    modelList = context.AppUsers.AsNoTracking().AsEnumerable().Select(model =>
                           ConvertUser(model)).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelList;
        }

        public static AppUserDTO ConvertUser(AppUser model)
        {
            AppUserDTO modelDTO = null;
            try
            {
                modelDTO = new AppUserDTO
                {
                    id = model.id,
                    userName = model.userName,
                    userPwd = model.userPwd,
                    userLevel=model.userLevel,
                    createdAt = model.createdAt
                };
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelDTO;
        }

        #endregion

        #region category
        public static bool AddCategory(MasterProductCategoryDTO model)
        {  
            try { 
            using (PMEntities context = new PMEntities())
            { 
                context.MasterProductCategories.Add(new MasterProductCategory
                {
                    name = model.name,
                    catDesc = model.catDesc, 
                    createdAt = DateTime.Now
                });

                return context.SaveChanges() > 0;
            }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static bool UpdateCategory(MasterProductCategoryDTO model)
        { 
            try { 
            using (PMEntities context = new PMEntities())
            {
                var tblRowFound = context.MasterProductCategories.Where(c => c.id == model.id).FirstOrDefault();
                if (tblRowFound != null)
                {
                    tblRowFound.name = model.name;
                    tblRowFound.catDesc = model.catDesc;  
                    tblRowFound.createdAt = DateTime.Now;
                }

                return context.SaveChanges() > 0;
            }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static bool RemoveCategory(Int32 id)
        {try { 
            MasterProductCategory detail = null;
            using (PMEntities context = new PMEntities())
            {
                detail = context.MasterProductCategories.Where(c => c.id == id).FirstOrDefault();
                if (detail != null)
                {
                    context.MasterProductCategories.Remove(detail);

                    return context.SaveChanges() > 0;
                }

                return false;
            }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static List<MasterProductCategoryDTO> GetCategoryList()
        {
            List<MasterProductCategoryDTO> modelList = new List<MasterProductCategoryDTO>();
            try { 
            using (PMEntities context = new PMEntities())
            {
                    modelList = context.MasterProductCategories.AsNoTracking().AsEnumerable().Select(model =>
                           ConvertCategory(model)).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message); 
            }
            return modelList;
        }
         
        public static MasterProductCategoryDTO ConvertCategory(MasterProductCategory model)
        {
            MasterProductCategoryDTO modelDTO = null;
            try
            {
                modelDTO = new MasterProductCategoryDTO
                {
                    id = model.id, 
                    name = model.name,
                    catDesc = model.catDesc,
                    createdAt = model.createdAt
                };
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelDTO;
        }

        #endregion

        #region type
        public static bool AddType(MasterProductTypeDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    context.MasterProductTypes.Add(new MasterProductType
                    {
                        systemTypeId=model.systemTypeId,
                        name = model.name,
                        typeDesc = model.typeDesc,
                        createdAt = DateTime.Now
                    });

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static bool UpdateType(MasterProductTypeDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    var tblRowFound = context.MasterProductTypes.Where(c => c.id == model.id).FirstOrDefault();
                    if (tblRowFound != null)
                    {
                        tblRowFound.systemTypeId = model.systemTypeId;
                        tblRowFound.name = model.name;
                        tblRowFound.typeDesc = model.typeDesc;
                        tblRowFound.createdAt = DateTime.Now;
                    }

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static bool RemoveType(Int32 id)
        {
            try
            {
                MasterProductType detail = null;
                using (PMEntities context = new PMEntities())
                {
                    detail = context.MasterProductTypes.Where(c => c.id == id).FirstOrDefault();
                    if (detail != null)
                    {
                        context.MasterProductTypes.Remove(detail);

                        return context.SaveChanges() > 0;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static List<MasterProductTypeDTO> GetTypeList()
        {
            List<MasterProductTypeDTO> modelList = new List<MasterProductTypeDTO>();
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    modelList = context.MasterProductTypes.AsNoTracking().AsEnumerable().Select(model =>
                           ConvertType(model)).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelList;
        }
         
        public static MasterProductTypeDTO ConvertType(MasterProductType model)
        {
            MasterProductTypeDTO modelDTO = null;
            try
            {
                modelDTO = new MasterProductTypeDTO
                {
                    id = model.id,
                    systemTypeId = model.systemTypeId,
                    name = model.name,
                    typeDesc = model.typeDesc,
                    createdAt = model.createdAt
                };
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelDTO;
        }

        #endregion

        #region variant
        public static bool AddAttribute(MasterProductVariantAttributeDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    context.MasterProductVariantAttributes.Add(new MasterProductVariantAttribute
                    {
                        name = model.name,
                        variantDesc = model.variantDesc,
                        createdAt = DateTime.Now
                    });

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }
        public static Int32 AddAttributeReturnId(MasterProductVariantAttributeDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    context.MasterProductVariantAttributes.Add(new MasterProductVariantAttribute
                    {
                        name = model.name,
                        variantDesc = model.variantDesc,
                        createdAt = DateTime.Now
                    });

                    var res = context.SaveChanges() > 0;
                    if (res)
                        return context.MasterProductVariantAttributes.Local.FirstOrDefault().id;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return 0;
        }

        public static bool AddAttributeTransaction(MasterProductVariantAttributesDTO model)
        {
            var result = false;
            var transResult = TransactionReturnType.NONE;
          
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var attrId = 0;
                    #region parent attr
                    var isExists = GetAttributeList().Where(c => c.id == model.MasterProductVariantAttribute.id).FirstOrDefault();
                    if (isExists == null)
                    {
                        attrId = AddAttributeReturnId(model.MasterProductVariantAttribute);
                        if (attrId > 0)
                        {
                            transResult = TransactionReturnType.ADDED;
                        }
                        else
                            transResult = TransactionReturnType.ERRORADDING;
                    }
                    else
                    {
                        transResult = TransactionReturnType.ALREADYEXISTS;
                    }
                    #endregion

                    var subTotalCount = 0;
                    var subCount = 0;

                    #region composite
                    if (attrId > 0 && model.MasterProductVariantSubAttributes!=null && model.MasterProductVariantSubAttributes.Count>0 && (transResult == TransactionReturnType.ADDED))
                    {
                        subTotalCount = model.MasterProductVariantSubAttributes.Count;
                        foreach (var sub in model.MasterProductVariantSubAttributes)
                        {
                            sub.attributeId = attrId;

                            var compExists = GetSubAttributeList().FirstOrDefault(c => c.attributeId==attrId && c.id == sub.id);
                            if (compExists == null)
                            {
                                result = AddSubAttribute(sub);
                                if (result)
                                    subCount++; 
                            }
                        }
                    }

                    #endregion

                    #region end transaction

                    if (attrId > 0 && transResult == TransactionReturnType.ADDED && (subTotalCount>0 && subCount==subTotalCount))
                    {
                        scope.Complete();
                        return true;
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return false;
        }

        public static bool UpdateAttribute(MasterProductVariantAttributeDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    var tblRowFound = context.MasterProductVariantAttributes.Where(c => c.id == model.id).FirstOrDefault();
                    if (tblRowFound != null)
                    {
                        tblRowFound.name = model.name;
                        tblRowFound.variantDesc = model.variantDesc;
                        tblRowFound.createdAt = DateTime.Now;
                    }

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static bool RemoveAttribute(Int32 id)
        {
            try
            {
                MasterProductVariantAttribute detail = null;
                using (PMEntities context = new PMEntities())
                {
                    detail = context.MasterProductVariantAttributes.Where(c => c.id == id).FirstOrDefault();
                    if (detail != null)
                    {
                        context.MasterProductVariantAttributes.Remove(detail);

                        return context.SaveChanges() > 0;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static List<MasterProductVariantAttributeDTO> GetAttributeList()
        {
            List<MasterProductVariantAttributeDTO> modelList = new List<MasterProductVariantAttributeDTO>();
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    modelList = context.MasterProductVariantAttributes.AsNoTracking().AsEnumerable().Select(model =>
                           ConvertAttribute(model)).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelList;
        }

        public static MasterProductVariantAttributeDTO ConvertAttribute(MasterProductVariantAttribute model)
        {
            MasterProductVariantAttributeDTO modelDTO = null;
            try
            {
                modelDTO = new MasterProductVariantAttributeDTO
                {
                    id = model.id,
                    name = model.name,
                    variantDesc = model.variantDesc,
                    createdAt = model.createdAt
                };
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelDTO;
        }

        #endregion

        #region subvariant
        public static bool AddSubAttribute(MasterProductVariantSubAttributeDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    context.MasterProductVariantSubAttributes.Add(new MasterProductVariantSubAttribute
                    {
                        attributeId=model.attributeId,
                        name = model.name,
                        subVariantDesc = model.subVariantDesc,
                        createdAt = DateTime.Now
                    });

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static bool UpdateSubAttribute(MasterProductVariantSubAttributeDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    var tblRowFound = context.MasterProductVariantSubAttributes.Where(c => c.id == model.id).FirstOrDefault();
                    if (tblRowFound != null)
                    {
                        tblRowFound.attributeId = model.attributeId;
                        tblRowFound.name = model.name;
                        tblRowFound.subVariantDesc = model.subVariantDesc;
                        tblRowFound.createdAt = DateTime.Now;
                    }

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static bool RemoveSubAttribute(Int32 id)
        {
            try
            {
                MasterProductVariantSubAttribute detail = null;
                using (PMEntities context = new PMEntities())
                {
                    detail = context.MasterProductVariantSubAttributes.Where(c => c.id == id).FirstOrDefault();
                    if (detail != null)
                    {
                        context.MasterProductVariantSubAttributes.Remove(detail);

                        return context.SaveChanges() > 0;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static List<MasterProductVariantSubAttributeDTO> GetSubAttributeList()
        {
            List<MasterProductVariantSubAttributeDTO> modelList = new List<MasterProductVariantSubAttributeDTO>();
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    modelList = context.MasterProductVariantSubAttributes.AsNoTracking().AsEnumerable().Select(model =>
                           ConvertSubAttribute(model)).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelList;
        }

        public static MasterProductVariantSubAttributeDTO ConvertSubAttribute(MasterProductVariantSubAttribute model)
        {
            MasterProductVariantSubAttributeDTO modelDTO = null;
            try
            {
                modelDTO = new MasterProductVariantSubAttributeDTO
                {
                    id = model.id,
                    attributeId=model.attributeId,
                    name = model.name,
                    subVariantDesc = model.subVariantDesc,
                    createdAt = model.createdAt,
                    MasterProductVariantAttribute=ConvertAttribute(model.MasterProductVariantAttribute)
                };
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelDTO;
        }

        #endregion

        #region product
        public static bool AddProduct(ProductDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    context.Products.Add(new Product
                    {
                        catId = model.catId,
                        typeId = model.typeId,
                        name = model.name,
                        skuCode=model.skuCode,
                        stockQtty=model.stockQtty,
                        createdAt = DateTime.Now
                    });

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }
        public static Int32 AddProductReturnId(ProductDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    context.Products.Add(new Product
                    {
                        catId = model.catId,
                        typeId = model.typeId,
                        name = model.name,
                        skuCode = model.skuCode,
                        stockQtty = model.stockQtty,
                        createdAt = DateTime.Now
                    });
                
                    var res = context.SaveChanges() > 0;
                    if (res)
                        return context.Products.Local.FirstOrDefault().id;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return 0;
        }

        public static bool UpdateProduct(ProductDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    var tblRowFound = context.Products.Where(c => c.id == model.id).FirstOrDefault();
                    if (tblRowFound != null)
                    {
                        tblRowFound.catId = model.catId;
                        tblRowFound.typeId = model.typeId;
                        tblRowFound.name = model.name;
                        tblRowFound.skuCode = model.skuCode;
                        tblRowFound.stockQtty = model.stockQtty;
                        tblRowFound.createdAt = DateTime.Now;
                    }

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static bool RemoveProduct(Int32 id)
        {
            try
            {
                Product detail = null;
                using (PMEntities context = new PMEntities())
                {
                    detail = context.Products.Where(c => c.id == id).FirstOrDefault();
                    if (detail != null)
                    {
                        context.Products.Remove(detail);

                        return context.SaveChanges() > 0;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static List<ProductDTO> GetProductList()
        {
            List<ProductDTO> modelList = new List<ProductDTO>();
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    modelList = context.Products.AsNoTracking().AsEnumerable().Select(model =>
                           ConvertProduct(model)).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelList;
        }

        public static ProductDTO ConvertProduct(Product model)
        {
            ProductDTO modelDTO = null;
            try
            {
                modelDTO = new ProductDTO
                {
                    id = model.id,
                    catId = model.catId,
                    typeId = model.typeId,
                    name = model.name,
                    skuCode=model.skuCode,
                    stockQtty=model.stockQtty,
                    createdAt = model.createdAt,
                    MasterProductCategory = ConvertCategory(model.MasterProductCategory),
                    MasterProductType = ConvertType(model.MasterProductType)
                };
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelDTO;
        }

        public static List<ProductDetailsDTO> GetProductDetailList()
        {
            List<ProductDetailsDTO> modelList = new List<ProductDetailsDTO>();

            try
            {
                using (PMEntities context = new PMEntities())
                {
                    var pd1 = context.ProductStandardAllocs.AsNoTracking().AsEnumerable().Select(model =>
                           ConvertProductDetailsFromStandard(model)).ToList();
                    modelList.AddRange(pd1);
                }
                using (PMEntities context = new PMEntities())
                {
                    var pd2 = context.ProductVariantAllocs.AsNoTracking().AsEnumerable().Select(model =>
                           ConvertProductDetailsFromVariant(model)).ToList();
                    modelList.AddRange(pd2);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelList;
        }

        public static ProductDetailsDTO ConvertProductDetailsFromStandard(ProductStandardAlloc model)
        {
            ProductDetailsDTO modelDTO = null;
            try
            {
                modelDTO = new ProductDetailsDTO
                {
                    id = model.id,
                    prodId=model.prodId,
                    price = model.price, 
                    Product = ConvertProduct(model.Product), 
                };
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelDTO;
        }
        public static ProductDetailsDTO ConvertProductDetailsFromVariant(ProductVariantAlloc model)
        {
            ProductDetailsDTO modelDTO = null;
            try
            {
                modelDTO = new ProductDetailsDTO
                {
                    id = model.id,
                    prodId = model.prodId,
                    price = model.price,
                    Product = ConvertProduct(model.Product),
                };
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelDTO;
        }
     
        #endregion

        #region product standard
        public static bool AddProductStandardAlloc(ProductStandardAllocDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    context.ProductStandardAllocs.Add(new ProductStandardAlloc
                    {
                        prodId = model.prodId,
                        price = model.price,
                        createdAt = DateTime.Now
                    });

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static bool UpdateProductStandardAlloc(ProductStandardAllocDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    var tblRowFound = context.ProductStandardAllocs.Where(c => c.id == model.id).FirstOrDefault();
                    if (tblRowFound != null)
                    {
                        tblRowFound.prodId = model.prodId; 
                        tblRowFound.price = model.price;
                        tblRowFound.createdAt = DateTime.Now;
                    }

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static bool RemoveProductStandardAlloc(Int32 id)
        {
            try
            {
                ProductStandardAlloc detail = null;
                using (PMEntities context = new PMEntities())
                {
                    detail = context.ProductStandardAllocs.Where(c => c.id == id).FirstOrDefault();
                    if (detail != null)
                    {
                        context.ProductStandardAllocs.Remove(detail);

                        return context.SaveChanges() > 0;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static List<ProductStandardAllocDTO> GetProductStandardAllocList()
        {
            List<ProductStandardAllocDTO> modelList = new List<ProductStandardAllocDTO>();
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    modelList = context.ProductStandardAllocs.AsNoTracking().AsEnumerable().Select(model =>
                           ConvertProductStandardAlloc(model)).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelList;
        }

        public static ProductStandardAllocDTO ConvertProductStandardAlloc(ProductStandardAlloc model)
        {
            ProductStandardAllocDTO modelDTO = null;
            try
            {
                modelDTO = new ProductStandardAllocDTO
                {
                    id = model.id,
                    prodId = model.prodId,
                    price = model.price,
                    createdAt = model.createdAt,
                    Product = ConvertProduct(model.Product),
                };
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelDTO;
        }

        #endregion

        #region product composite
        public static bool AddProductCompositeAlloc(ProductCompositeAllocDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    context.ProductCompositeAllocs.Add(new ProductCompositeAlloc
                    {
                        prodId = model.prodId, 
                        createdAt = DateTime.Now
                    });

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }
        public static Int32 AddProductCompositeAllocReturnId(ProductCompositeAllocDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    context.ProductCompositeAllocs.Add(new ProductCompositeAlloc
                    {
                        prodId = model.prodId,
                        createdAt = DateTime.Now
                    });

                    var res = context.SaveChanges() > 0;
                    if (res)
                        return context.ProductCompositeAllocs.Local.FirstOrDefault().id;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return 0;
        }

        public static bool AddProductCompositeAllocTransaction(ProductCompositeAllocDTO model)
        {
            var result = false;
            var prodResult = TransactionReturnType.NONE;
            var prodCompResult = TransactionReturnType.NONE;

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var productId = 0;
                    #region product
                    var isProductExists =  GetProductList().Where(c => c.id == model.prodId || c.skuCode==model.Product.skuCode || c.name==model.Product.name).FirstOrDefault();
                    if (isProductExists == null)
                    {
                        productId = AddProductReturnId(model.Product);
                        if (productId > 0)
                        { 
                            prodResult = TransactionReturnType.ADDED;
                        }
                        else
                            prodResult = TransactionReturnType.ERRORADDING;
                    }
                    else
                    {
                        prodResult = TransactionReturnType.ALREADYEXISTS;
                    }
                    #endregion

                    #region composite
                    if (productId > 0 && (prodResult == TransactionReturnType.ADDED))
                    {
                        model.prodId = productId;
                     
                        var compExists = GetProductCompositeAllocList().FirstOrDefault(c => c.id == model.id);
                        if (compExists == null)
                        {
                            result = AddProductCompositeAlloc(model);
                            if (result)
                                prodCompResult = TransactionReturnType.ADDED;
                            else
                                prodCompResult = TransactionReturnType.ERRORADDING;
                        }
                    }

                    #endregion
                     
                    #region end transaction

                    if (productId > 0 && (prodResult == TransactionReturnType.ADDED || prodCompResult == TransactionReturnType.UPDATED))
                    {
                        scope.Complete();
                        return true;
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return false;
        }

        public static bool UpdateProductCompositeAlloc(ProductCompositeAllocDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    var tblRowFound = context.ProductCompositeAllocs.Where(c => c.id == model.id).FirstOrDefault();
                    if (tblRowFound != null)
                    {
                        tblRowFound.prodId = model.prodId; 
                        tblRowFound.createdAt = DateTime.Now;
                    }

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static bool RemoveProductCompositeAlloc(Int32 id)
        {
            try
            {
                ProductCompositeAlloc detail = null;
                using (PMEntities context = new PMEntities())
                {
                    detail = context.ProductCompositeAllocs.Where(c => c.id == id).FirstOrDefault();
                    if (detail != null)
                    {
                        context.ProductCompositeAllocs.Remove(detail);

                        return context.SaveChanges() > 0;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static List<ProductCompositeAllocDTO> GetProductCompositeAllocList()
        {
            List<ProductCompositeAllocDTO> modelList = new List<ProductCompositeAllocDTO>();
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    modelList = context.ProductCompositeAllocs.AsNoTracking().AsEnumerable().Select(model =>
                           ConvertProductCompositeAlloc(model)).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelList;
        }

        public static ProductCompositeAllocDTO ConvertProductCompositeAlloc(ProductCompositeAlloc model)
        {
            ProductCompositeAllocDTO modelDTO = null;
            try
            {
                modelDTO = new ProductCompositeAllocDTO
                {
                    id = model.id,
                    prodId = model.prodId,
                    createdAt = model.createdAt,
                    Product = ConvertProduct(model.Product),
                };
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelDTO;
        }

        #endregion

        #region product composite lines
        public static bool AddProductCompositeLine(ProductCompositeLineDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    context.ProductCompositeLines.Add(new ProductCompositeLine
                    { 
                        compId = model.compId,
                        prodStandId = model.prodStandId,
                        isMandatory = model.isMandatory,
                        isPriceInclusive = model.isPriceInclusive,
                        isParent = model.isParent,
                        createdAt = model.createdAt,
                    });

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static bool AddProductCompositeLineTransaction(ProductCompositeLineDTO model)
        {
            var productModel = model.ProductCompositeAlloc.Product;
            var productCompModel = model.ProductCompositeAlloc;
            var result = false;
            var prodResult = TransactionReturnType.NONE;
            var prodCompResult = TransactionReturnType.NONE;

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var productId = 0;
                    #region product
                    var isProductExists = GetProductList().Where(c => c.id == model.ProductCompositeAlloc.prodId || c.skuCode == productModel.skuCode || c.name == productModel.name).FirstOrDefault();
                    if (isProductExists == null)
                    {
                        productId = AddProductReturnId(productModel);
                        if (productId > 0)
                        {
                            prodResult = TransactionReturnType.ADDED;
                        }
                        else
                            prodResult = TransactionReturnType.ERRORADDING;
                    }
                    else
                    {
                        prodResult = TransactionReturnType.ALREADYEXISTS;
                    }
                    #endregion

                    #region composite
                    if (productId > 0 && (prodResult == TransactionReturnType.ADDED))
                    {
                        productCompModel.prodId = productId;

                        var compExists = GetProductCompositeAllocList().FirstOrDefault(c => c.id == productCompModel.id);
                        if (compExists == null)
                        {
                            result = AddProductCompositeAlloc(productCompModel);
                            if (result)
                                prodCompResult = TransactionReturnType.ADDED;
                            else
                                prodCompResult = TransactionReturnType.ERRORADDING;
                        }
                    }

                    #endregion

                    #region end transaction

                    if (productId > 0 && (prodResult == TransactionReturnType.ADDED || prodCompResult == TransactionReturnType.UPDATED))
                    {
                        scope.Complete();
                        return true;
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return false;
        }

        public static bool UpdateProductCompositeLine(ProductCompositeLineDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    var tblRowFound = context.ProductCompositeLines.Where(c => c.id == model.id).FirstOrDefault();
                    if (tblRowFound != null)
                    {
                        tblRowFound.compId = model.compId;
                        tblRowFound.prodStandId = model.prodStandId;
                        tblRowFound.isMandatory = model.isMandatory;
                        tblRowFound.isPriceInclusive = model.isPriceInclusive;
                        tblRowFound.isParent = model.isParent;
                        tblRowFound.createdAt = DateTime.Now;
                    }

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static bool RemoveProductCompositeLine(Int32 id)
        {
            try
            {
                ProductCompositeLine detail = null;
                using (PMEntities context = new PMEntities())
                {
                    detail = context.ProductCompositeLines.Where(c => c.id == id).FirstOrDefault();
                    if (detail != null)
                    {
                        context.ProductCompositeLines.Remove(detail);

                        return context.SaveChanges() > 0;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static List<ProductCompositeLineDTO> GetProductCompositeLineList()
        {
            List<ProductCompositeLineDTO> modelList = new List<ProductCompositeLineDTO>();
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    modelList = context.ProductCompositeLines.AsNoTracking().AsEnumerable().Select(model =>
                           ConvertProductCompositeLine(model)).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelList;
        }

        public static ProductCompositeLineDTO ConvertProductCompositeLine(ProductCompositeLine model)
        {
            ProductCompositeLineDTO modelDTO = null;
            try
            {
                modelDTO = new ProductCompositeLineDTO
                {
                    id = model.id,
                    compId = model.compId,
                    prodStandId=model.prodStandId,
                    isMandatory=model.isMandatory,
                    isPriceInclusive=model.isPriceInclusive,
                    isParent=model.isParent,
                    createdAt = model.createdAt,
                    ProductCompositeAlloc = ConvertProductCompositeAlloc(model.ProductCompositeAlloc),
                    ProductStandardAlloc=ConvertProductStandardAlloc(model.ProductStandardAlloc)
                };
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelDTO;
        }

        #endregion

        #region product variant
        public static bool AddProductVariantAlloc(ProductVariantAllocDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    context.ProductVariantAllocs.Add(new ProductVariantAlloc
                    {
                        prodId = model.prodId,
                        subAttrId = model.subAttrId,
                        price = model.price,
                        createdAt = DateTime.Now
                    });

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static bool UpdateProductVariantAlloc(ProductVariantAllocDTO model)
        {
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    var tblRowFound = context.ProductVariantAllocs.Where(c => c.id == model.id).FirstOrDefault();
                    if (tblRowFound != null)
                    {
                        tblRowFound.prodId = model.prodId;
                        tblRowFound.subAttrId = model.subAttrId;
                        tblRowFound.price = model.price;
                        tblRowFound.createdAt = DateTime.Now;
                    }

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static bool RemoveProductVariantAlloc(Int32 id)
        {
            try
            {
                ProductVariantAlloc detail = null;
                using (PMEntities context = new PMEntities())
                {
                    detail = context.ProductVariantAllocs.Where(c => c.id == id).FirstOrDefault();
                    if (detail != null)
                    {
                        context.ProductVariantAllocs.Remove(detail);

                        return context.SaveChanges() > 0;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
                return false;
            }
        }

        public static List<ProductVariantAllocDTO> GetProductVariantAllocList()
        {
            List<ProductVariantAllocDTO> modelList = new List<ProductVariantAllocDTO>();
            try
            {
                using (PMEntities context = new PMEntities())
                {
                    modelList = context.ProductVariantAllocs.AsNoTracking().AsEnumerable().Select(model =>
                           ConvertProductVariantAlloc(model)).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelList;
        }

        public static ProductVariantAllocDTO ConvertProductVariantAlloc(ProductVariantAlloc model)
        {
            ProductVariantAllocDTO modelDTO = null;
            try
            {
                modelDTO = new ProductVariantAllocDTO
                {
                    id = model.id,
                    prodId = model.prodId,
                    subAttrId = model.subAttrId,
                    price = model.price,
                    createdAt = model.createdAt,
                    Product = ConvertProduct(model.Product),
                    MasterProductVariantSubAttribute = ConvertSubAttribute(model.MasterProductVariantSubAttribute)
                };
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogLevel.WARNING, ex.Message);
            }
            return modelDTO;
        }

        #endregion

    }
     
    public enum TransactionReturnType
    {
        NONE, ALREADYEXISTS, TRANSACTIONSUCCESS, TRANSACTIONERROR, ADDED, ERRORADDING, UPDATED, ERRORUPDATING, DELETED, ERRORDELETING
    }

}
