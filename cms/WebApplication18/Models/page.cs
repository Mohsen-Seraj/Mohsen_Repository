using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace datalayer
{
   public class page
    {

        [Key]
        public int pageid { get; set; }

        [Display(Name = "گروه صفحه")]
        [Required(ErrorMessage = " {0} وارد کنید")]
        //[ForeignKey("pagegroup")]
        public int groupid { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = " {0} وارد کنید")]
        [MaxLength(250)]
        public string title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = " {0} وارد کنید")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string shortdescription { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = " {0} وارد کنید ")]
        [DataType(DataType.MultilineText)]
        public string text { get; set; }

        [Display(Name = "بازدید")]
        public int visit { get; set; }

        [Display(Name = "تصویر")]
        public string imagename { get; set; }

        [Display(Name = "اسلایدر")]
        public bool showinslider { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime createdate { get; set; }

        public pagegroup pagegroup { get; set; }

        public virtual List<pagecomment> pagecomments { get; set; }


        public page()
        {



        }

    }
}
