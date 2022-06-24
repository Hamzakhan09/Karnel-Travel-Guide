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
    using System.ComponentModel.DataAnnotations;
    
    public partial class User_Registration
    {
        public int UserReg_Id { get; set; }

        [Required(ErrorMessage = "Enter Username ! ")]
        [Display(Name ="Username")]
        public string UserReg_UserName { get; set; }


        [Required(ErrorMessage ="Enter Email !")]
        [Display(Name ="Email")]
        public string UserReg_Email { get; set; }

        [Display(Name ="Enter Mobile no")]
        public string UserReg_Mobile { get; set; }

        [Display(Name ="Enter Image")]
        public string UserReg_Image { get; set; }

        [Required(ErrorMessage = "Enter Password !")]
        [Display(Name = "Enter  Password")]
        [DataType(DataType.Password)]
        public string UserReg_Password { get; set; }

        [Required(ErrorMessage = "Enter Confirm Password !")]
        [DataType(DataType.Password)]
        [Compare("UserReg_Password")]
        [Display(Name ="Enter Confirm Password")]
        public string UserReg_CPassword { get; set; }
    }
}