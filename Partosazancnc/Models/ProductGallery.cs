using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class ProductGallery
    {
        [Key]
        public int ProductGalleryID { get; set; }

        [StringLength(350, ErrorMessage = "حداکثر {1} کاراکتر مورد قبول می باشد")]
        [Display(Name = "تصویر گالری")]
        public string Image { get; set; }

        [StringLength(150, ErrorMessage = "حداکثر {1} کاراکتر مورد قبول می باشد")]
        [Display(Name = "عنوان گالری")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Title { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}