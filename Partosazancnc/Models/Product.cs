using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Partosazancnc.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Display(Name = "کاربر ایجاد کننده محصول")]
        public int? UserID { get; set; }
        [Display(Name = "دسته بندی محصول")]

        public int? ProductTypeId { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [StringLength(150,ErrorMessage = "حداکثر {1} کاراکتر مورد قبول می باشد")]
        [Display(Name = "عنوان محصول یا خدمات")]
        public string Title { get; set; }

        [AllowHtml]
        [StringLength(350, ErrorMessage = "حداکثر {1} کاراکتر مورد قبول می باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "توضیحات مختصر محصول")]
        public string ShortDiscription { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        [Display(Name = "توضیحات محصول  ")]
        public string Text { get; set; }

        [StringLength(350)]
        [Display(Name = "تصویر شاخص محصول")]
        public string PicThumbnail { get; set; }

        [StringLength(500, ErrorMessage = "حداکثر {1} کاراکتر مورد قبول می باشد")]
        [Display(Name = "کلمات کلیدی ")]
        public string KeyWord { get; set; }

        [Display(Name = "تاریخ ایجاد محصول")]
        public DateTime Date { get; set; }
        [Display(Name = "وضعیت محصول")]
        public Vaziaat Vaziaat { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual Users Users { get; set; }
        public virtual ICollection<ProductGallery> ProductGallery { get; set; }
        public virtual ICollection<ProductProperty> ProductProperty { get; set; }
        public virtual ICollection<ProductAttachFile> ProductAttachFiles { get; set; }
        public virtual ICollection<ProductComments> ProductCommentses { get; set; }

    }
}