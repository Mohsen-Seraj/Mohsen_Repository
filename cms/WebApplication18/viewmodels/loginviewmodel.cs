using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cms
{
    public class loginviewmodel
    {

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = " {0}وارد کنید")]
        [MaxLength(200)]
        public string username { get; set; }


        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = " {0}وارد کنید")]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        public string password { get; set; }


        [Display(Name = "مرا بخاطر بسپار")]
        public bool rememberme { get; set; }

    }
}