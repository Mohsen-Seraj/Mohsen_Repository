using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace datalayer
{
   public class pagecomment
    {

        [Key]
        public int commentid { get; set; }

        [Display(Name = "خبر")]
        [Required(ErrorMessage = " {0}وارد کنید")]
        public int pageid { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = " {0}وارد کنید")]
        [MaxLength(150)]
        public string name { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = " {0}وارد کنید")]
        [MaxLength(150)]
        public string email { get; set; }

        [Display(Name = "وبسایت")]
        [Required(ErrorMessage = " {0}وارد کنید")]
        [MaxLength(200)]
        public string website { get; set; }

        [Display(Name = "نظر")]
        [Required(ErrorMessage = " {0}وارد کنید")]
        [MaxLength(500)]
        public string comment { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime createdate { get; set; }

        public virtual page page { get; set; }


        public pagecomment()
        {




        }

    }
}
