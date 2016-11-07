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
    
    public partial class Warehouse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Warehouse()
        {
            this.Courier = new HashSet<Courier>();
            this.WarehouseTypeRelation = new HashSet<WarehouseTypeRelation>();
        }
    
        public string WarehouseID { get; set; }
        public Nullable<int> NumberCode { get; set; }
        public string Fk_BranchID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string Fk_ShipperID { get; set; }
        public string Fk_Consignee { get; set; }
        public string Fk_Agent { get; set; }
        public string Fk_DeliveryCompany { get; set; }
        public string Fk_Condition { get; set; }
        public string Description { get; set; }
        public string Fk_Origin { get; set; }
        public string Fk_Destination { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    
        public virtual Branch Branch { get; set; }
        public virtual CompanyAccount CompanyAccount { get; set; }
        public virtual CompanyAccount CompanyAccount1 { get; set; }
        public virtual CompanyAccount CompanyAccount2 { get; set; }
        public virtual Condition Condition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Courier> Courier { get; set; }
        public virtual Destination Destination { get; set; }
        public virtual Origin Origin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseTypeRelation> WarehouseTypeRelation { get; set; }
    }
}