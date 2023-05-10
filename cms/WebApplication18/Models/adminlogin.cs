using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cms
{
    public class adminlogin
    {

        [Key]      
        public int loginid { get; set; }


        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = " {0}وارد کنید")]
        [MaxLength(200)]
        public string username { get; set; }


        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = " {0}وارد کنید")]
        [MaxLength(200)]
        public string password { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = " {0}وارد کنید")]
        [MaxLength(250)]
        public string email { get; set; }

    }
}