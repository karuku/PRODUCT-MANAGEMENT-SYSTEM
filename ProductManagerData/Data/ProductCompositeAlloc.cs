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
    
    public partial class ProductCompositeAlloc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductCompositeAlloc()
        {
            this.ProductCompositeLines = new HashSet<ProductCompositeLine>();
        }
    
        public int id { get; set; }
        public int prodId { get; set; }
        public System.DateTime createdAt { get; set; }
    
        public virtual Product Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCompositeLine> ProductCompositeLines { get; set; }
    }
}