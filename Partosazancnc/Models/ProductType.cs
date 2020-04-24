using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [StringLength(150, ErrorMessage = "حداکثر {1} کاراکتر مورد قبول می باشد")]
        [Display(Name = "عنوان دسته بندی ")]

        public string Title { get; set; }

        [StringLength(150, ErrorMessage = "حداکثر {1} کاراکتر مورد قبول می باشد")]
        [Display(Name = "تصویر دسته بندی ")]
        public string image { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(400, ErrorMessage = "حداکثر {1} کاراکتر مورد قبول می باشد")]
        [Display(Name = "توضبحات مختصر ")]
        public string Discription { get; set; }

        


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }

        public virtual ICollection<Faqs> Faqses { get; set; }
    }
}