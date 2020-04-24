using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class PostComments
    {
        [Key]
        public int PostCommentID { get; set; }
        [Display(Name = "عنوان مقاله")]
        public int PostID { get; set; }

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
        public int?  ParentID { get; set; }
        [Display(Name = "وضعیت نظر")]
        public Vaziaat Vaziaat { get; set; }
        public virtual Post Post { get; set; }
    }
}