//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Karnel_Travel_Guide.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hotel
    {
        public int Hotel_Id { get; set; }
        public string Hotel_Name { get; set; }
        public string Hotel_PriceRange { get; set; }
        public string Hotel_Image { get; set; }
        public string Hotel_Image2 { get; set; }
        public string Hotel_Image3 { get; set; }
        public string Hotel_Discription { get; set; }
        public int Hotel_City { get; set; }
    
        public virtual City City { get; set; }
    }
}