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
    
    public partial class TouristSpot
    {
        public int Tour_Id { get; set; }
        public string Tour_Designation { get; set; }
        public string Tour_Price { get; set; }
        public string Tour_Image { get; set; }
        public string Tour_Image2 { get; set; }
        public string Tour_Image3 { get; set; }
        public string Tour_Discription { get; set; }
        public int Tour_City { get; set; }
    
        public virtual City City { get; set; }
    }
}
