using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class Faqs
    {
        [Key]
        public int FaqsID { get; set; }
        [Display(Name = "عنوان سوال ")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string FaqsTitle { get; set; }
        [Display(Name = "توضیحات ")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string FaqsDiscription { get; set; }
        [Display(Name = "دسته بندی سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; }

    }
}