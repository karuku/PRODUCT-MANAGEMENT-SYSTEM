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
    
    public partial class ProductCompositeLine
    {
        public int id { get; set; }
        public int compId { get; set; }
        public int prodStandId { get; set; }
        public bool isMandatory { get; set; }
        public bool isPriceInclusive { get; set; }
        public bool isParent { get; set; }
        public System.DateTime createdAt { get; set; }
    
        public virtual ProductCompositeAlloc ProductCompositeAlloc { get; set; }
        public virtual ProductStandardAlloc ProductStandardAlloc { get; set; }
    }
}
