//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cargo.Data.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeliveryCompany
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeliveryCompany()
        {
            this.Courier = new HashSet<Courier>();
        }
    
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Courier> Courier { get; set; }
    }
}
