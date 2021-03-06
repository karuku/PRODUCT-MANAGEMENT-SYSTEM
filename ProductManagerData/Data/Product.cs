//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductManagerData.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductCompositeAllocs = new HashSet<ProductCompositeAlloc>();
            this.ProductVariantAllocs = new HashSet<ProductVariantAlloc>();
        }
    
        public int id { get; set; }
        public int catId { get; set; }
        public int typeId { get; set; }
        public string name { get; set; }
        public string skuCode { get; set; }
        public double stockQtty { get; set; }
        public System.DateTime createdAt { get; set; }
    
        public virtual MasterProductCategory MasterProductCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCompositeAlloc> ProductCompositeAllocs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductVariantAlloc> ProductVariantAllocs { get; set; }
        public virtual ProductStandardAlloc ProductStandardAlloc { get; set; }
        public virtual MasterProductType MasterProductType { get; set; }
    }
}
