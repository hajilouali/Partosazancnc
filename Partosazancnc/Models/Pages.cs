using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Partosazancnc.Models
{
    public class Pages
    {
        [Key]
        public int PageID { get; set; }
        [Required(ErrorMessage = "لطفا نام صفحه را وارد نمایید")]
        [MaxLength(65, ErrorMessage = "حدا اکثر کاراکتر 65 میباشد ")]
        [Display(Name = "عنوان صفحه ")]
        public string PageTitle { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "متن صفحه")]
        public string PageContent { get; set; }
        [MaxLength(200, ErrorMessage = "حداکثر کاراکتر مجاز 200 میباشد")]
        [Display(Name = "کلمات کلیدی")]
        public string KeyWord { get; set; }
        [MaxLength(160, ErrorMessage = "حداکثر تعداد کاراکتر 160 میباشد")]
        [Display(Name = "توضیحات مختصر صفحه")]
        [DataType(DataType.MultilineText)]
        public string PageShortDiscription { get; set; }
        [Display(Name = "تصویر شاخص ")]
        public string ImageThumline { get; set; }
        [Display(Name = "نویسنده")]
        public int? UserID { get; set; }
        [Display(Name = "وضعت برگه")]
        public Vaziaat Vaziaat { get; set; }

        public virtual Users Users { get; set; }
    }
}