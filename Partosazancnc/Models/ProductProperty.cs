using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class ProductProperty
    {
        [Key]
        public int ProductPropertyID { get; set; }

        [StringLength(150, ErrorMessage = "حداکثر {1} کاراکتر مورد قبول می باشد")]
        [Display(Name = "عنوان متغییر ")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Title { get; set; }
        [Display(Name = " متغییر ")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string value { get; set; }


        public int ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}