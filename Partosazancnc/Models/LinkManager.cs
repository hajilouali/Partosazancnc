using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class LinkManager
    {
        [Key]
        public int LinkMAnagerId { get; set; }
        [MaxLength(50,ErrorMessage = "حداکثر {1} کاراکتر مورد تایید میباشد.  ")]
        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید ")]
        [Display(Name = "عنوان ")]
        public string ReDirectName { get; set; }
        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید ")]
        [Display(Name = "لینک منبع ")]
        [MaxLength(200, ErrorMessage = "حداکثر {1} کاراکتر مورد تایید میباشد.  ")]
        public string Url { get; set; }
        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید ")]
        [Display(Name = "لینک مقصد ")]
        [MaxLength(200, ErrorMessage = "حداکثر {1} کاراکتر مورد تایید میباشد.  ")]
        public string RedirectToUrl { get; set; }

    }
}