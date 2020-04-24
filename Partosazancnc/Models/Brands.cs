using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class Brands
    {
        [Key]
        public int BrandID { get; set; }
        [Display(Name = "نام برند")]
        [Required(ErrorMessage = "لطفاْ {0} را وارد نمایید")]
        [MaxLength(150,ErrorMessage = "حداکثر {1} کاراکتر مورد قبول میباشد")]
        public string BrandName { get; set; }
        [Display(Name = "تصویر برند")]
        public string Image { get; set; }

    }
}