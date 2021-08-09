using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManagerUI.Models
{
    public class ProductManagerViewModels
    {
    }

    public class CategoriesViewModel
    {
        [JsonProperty("Result")]
        public List<CategoryModel> DataList { get; set; }
    }

    public class CategoryModel
    {
        [JsonProperty("id")]
        public Int32 id { get; set; }
        [JsonProperty("name")]
        public string catName { get; set; }
        [JsonProperty("catDesc")]
        public string catDescription { get; set; }
        [JsonProperty("createdAt")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime createDate { get; set; }
    }

    public class TypesViewModel
    {
        [JsonProperty("Result")]
        public List<TypeModel> DataList { get; set; }
    }

    public class TypeModel
    {
        [JsonProperty("id")]
        public Int32 id { get; set; }
        [JsonProperty("systemTypeId")]
        public Int32 systemTypeId { get; set; }
        [JsonProperty("name")]
        public string typeName { get; set; }
        [JsonProperty("typeDesc")]
        public string typeDescription { get; set; }
        [JsonProperty("createdAt")] 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime createDate { get; set; }
        public long createDateJS { get; set; }

        public SystemProductTypes systemProdType { get { return (SystemProductTypes)systemTypeId; } }

    }

    public class AttributesViewModel
    {
        [JsonProperty("Result")]
        public List<AttributeModel> DataList { get; set; }
    }

    public class AttributeModel
    {
        [JsonProperty("attributeId")]
        public Int32 id { get; set; }
        [JsonProperty("ProductVariantAttribute")]
        public object VariantAttributeModel { get; set; }
        [JsonProperty("ProductVariantSubAttributes")]
        public object VariantSubAttributeList { get; set; } 
    }

    public class ProductsViewModel
    {
        [JsonProperty("Result")]
        public List<ProductDetailsModel> DataList { get; set; }
    }

    public class ProductViewModel
    {
        [JsonProperty("id")]
        public Int32 id { get; set; }
        [JsonProperty("catId")]
        public Int32 catId { get; set; }
        [JsonProperty("typeId")]
        public Int32 typeId { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("skuCode")]
        public Int32 skuCode { get; set; }
        [JsonProperty("stockQtty")]
        public double stockQtty { get; set; }
        [JsonProperty("createdAt")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime createDate { get; set; } 
    }

    public class ProductDetailsModel
    {
        [JsonProperty("productId")]
        public Int32 id { get; set; }
        [JsonProperty("Product")]
        public ProductViewModel ProductModel { get; set; }
        [JsonProperty("ProductStandard")]
        public object ProductStandardModel { get; set; }
        [JsonProperty("ProductCompositeLines")]
        public object ProductCompositeList { get; set; }
        [JsonProperty("ProductVariants")]
        public object ProductVariantList { get; set; }
    }


    public enum SystemProductTypes : byte
    {
        NONE=0, STANDARD = 1, VARIANT = 2, COMPOSITE = 3
    }
    public class SystemHelper
    {
        public static List<KeyValuePair<SystemProductTypes, byte>> GetSystemTypeList()
        {
            try
            {
                List<KeyValuePair<SystemProductTypes, byte>> modelList = new List<KeyValuePair<SystemProductTypes, byte>>()
            {
                new KeyValuePair<SystemProductTypes, byte>(SystemProductTypes.STANDARD,(byte)SystemProductTypes.STANDARD),
                                new KeyValuePair<SystemProductTypes, byte>(SystemProductTypes.VARIANT,(byte)SystemProductTypes.VARIANT),
                                                new KeyValuePair<SystemProductTypes, byte>(SystemProductTypes.COMPOSITE,(byte)SystemProductTypes.COMPOSITE),
            };
                return modelList;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }

}