using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class ProductComments
    {
        [Key]
        public int ProductCommentID { get; set; }
        [Display(Name = "عنوان محصول")]
        public int ProductID { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "متن نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Comment { get; set; }
        [Display(Name = "تاریخ ایجاد نظر")]
        public DateTime CreateDate { get; set; }
        public int? ParentID { get; set; }
        [Display(Name = "وضعیت نظر")]
        public Vaziaat Vaziaat { get; set; }
        public virtual Product Product { get; set; }
    }
}