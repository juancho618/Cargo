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
    
    public partial class WarehouseTypeRelation
    {
        public string WarehouseTypeRelationId { get; set; }
        public string WarehouseId { get; set; }
        public string TypeId { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    
        public virtual Warehouse Warehouse { get; set; }
        public virtual WarehouseTypes WarehouseTypes { get; set; }
    }
}