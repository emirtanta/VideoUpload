//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VideoUpload.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public Nullable<int> product_price { get; set; }
        public string product_describe { get; set; }
        public string product_photo { get; set; }
        public Nullable<System.DateTime> product_datetime { get; set; }
        public Nullable<int> product_discount { get; set; }
        public Nullable<int> category_id { get; set; }
        public Nullable<int> brand_id { get; set; }
    
        public virtual Brands Brands { get; set; }
        public virtual Categories Categories { get; set; }
    }
}
