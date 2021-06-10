using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProductManagerData.DTO
{
    [Serializable]
    public class AppUserDTO
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string userPwd { get; set; }
        public byte userLevel { get; set; }
        public System.DateTime createdAt { get; set; }
    }

    [Serializable]
    public class MasterProductCategoryDTO
    { 
        public int id { get; set; }
        public string name { get; set; }
        public string catDesc { get; set; }
        public System.DateTime createdAt { get; set; } 
    }


    public enum SystemProductTypes : byte
    {
        STANDARD = 1, VARIANT, COMPOSITE
    }

    [Serializable]
    public class MasterProductTypeDTO
    {
        public int id { get; set; }
        public byte systemTypeId { get; set; }
        public SystemProductTypes systemType { get { return (SystemProductTypes)systemTypeId; } }
        public string name { get; set; }
        public string typeDesc { get; set; }
        public System.DateTime createdAt { get; set; } 
    }

    [Serializable]
    public class MasterProductVariantAttributeDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string variantDesc { get; set; }
        public System.DateTime createdAt { get; set; }
    }

    [Serializable]
    public class MasterProductVariantSubAttributeDTO
    {
        public int id { get; set; }
        public int attributeId { get; set; }
        public string name { get; set; }
        public string subVariantDesc { get; set; }
        public System.DateTime createdAt { get; set; }

        public virtual MasterProductVariantAttributeDTO MasterProductVariantAttribute { get; set; }
    }

    [Serializable]
    public class MasterProductVariantAttributesDTO
    {
        public virtual MasterProductVariantAttributeDTO MasterProductVariantAttribute { get; set; }
        public virtual List<MasterProductVariantSubAttributeDTO> MasterProductVariantSubAttributes { get; set; }
    }

    [Serializable]
    public class ProductDTO
    {
        public int id { get; set; }
        public int catId { get; set; }
        public int typeId { get; set; }
        public string name { get; set; }
        public string skuCode { get; set; }
        public double stockQtty { get; set; }
        public System.DateTime createdAt { get; set; }

        public virtual MasterProductCategoryDTO MasterProductCategory { get; set; }
        public virtual MasterProductTypeDTO MasterProductType { get; set; }
    }

    [Serializable]
    public class ProductStandardAllocDTO
    {
        public int id { get; set; }
        public int prodId { get; set; }
        public double price { get; set; }
        public System.DateTime createdAt { get; set; }

        public virtual ProductDTO Product { get; set; }
    }

    [Serializable]
    public class ProductCompositeAllocDTO
    {
        public int id { get; set; }
        public int prodId { get; set; }
        public System.DateTime createdAt { get; set; }

        public virtual ProductDTO Product { get; set; }
    }

    [Serializable]
    public class ProductCompositeLineDTO
    {
        public int id { get; set; }
        public int compId { get; set; }
        public int prodStandId { get; set; }
        public bool isMandatory { get; set; }
        public bool isPriceInclusive { get; set; }
        public bool isParent { get; set; }
        public System.DateTime createdAt { get; set; }

        public virtual ProductCompositeAllocDTO ProductCompositeAlloc { get; set; }
        public virtual ProductStandardAllocDTO ProductStandardAlloc { get; set; }
    }

    [Serializable]
    public class ProductVariantAllocDTO
    {
        public int id { get; set; }
        public int prodId { get; set; }
        public int subAttrId { get; set; }
        public double price { get; set; }
        public System.DateTime createdAt { get; set; }

        public virtual MasterProductVariantSubAttributeDTO MasterProductVariantSubAttribute { get; set; }
        public virtual ProductDTO Product { get; set; }
    }


    [Serializable]
    public class ProductDetailsDTO
    {
        public int id { get; set; }
        public int prodId { get; set; } 
        public double price { get; set; }
      
        public virtual ProductDTO Product { get; set; }
    }

}
