//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnCoSo.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoaiSanPham
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Slug { get; set; }
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<System.DateTime> CreateOnUtc { get; set; }
        public Nullable<System.DateTime> UpdateOnUtc { get; set; }
        public Nullable<bool> Delete { get; set; }
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
}
