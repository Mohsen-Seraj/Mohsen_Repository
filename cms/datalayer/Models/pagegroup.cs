using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace datalayer
{
   public class pagegroup
    {

        [Key]
        public int groupid { get; set; }



        [Display(Name = " ")]
        [Required(ErrorMessage = " {0}وارد کنید")]
        [MaxLength(150)]
        public string grouptitle { get; set; }


        public virtual List<page> pages { get; set; }

       public pagegroup()
        {



        }


    }
}
