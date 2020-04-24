using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Partosazancnc.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }

        [Required(ErrorMessage = "لطفاْ {0} را وارد نمایید .")]
        [StringLength(150, ErrorMessage = "حداکثر {1} کاراکتر مورد مجاز میباشد ")]
        [Display(Name = "عنوان مقاله")]

        public string PostTitle { get; set; }
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        [Display(Name = "متن مقاله")]

        public string PostText { get; set; }
        [Display(Name = "دسته بندی مقاله")]

        public int? PostTypeID { get; set; }
        [Required(ErrorMessage = "لطفاْ {0} را وارد نمایید .")]
        [StringLength(190, ErrorMessage = "حداکثر {1} کاراکتر مورد مجاز میباشد ")]
        [Display(Name = "توضیحات مختصر مقاله")]
        [DataType(DataType.MultilineText)]
        public string PostShortDiscription { get; set; }
        [Display(Name = "تاریخ انتشار")]

        public DateTime PostDate { get; set; }

        [StringLength(300, ErrorMessage = "حداکثر {1} کاراکتر مورد مجاز میباشد ")]
        [Display(Name = "کلمات کلیدی ")]

        public string KeyWord { get; set; }

        [Display(Name = "نویسنده")]

        public int? UserID { get; set; }

        [StringLength(150, ErrorMessage = "حداکثر {1} کاراکتر مورد مجاز میباشد ")]
        [Display(Name = "تصویر شاخص")]

        public string PostImage { get; set; }
        [Display(Name = "وضعیت مقاله")]
        public Vaziaat Vaziaat { get; set; }


        public virtual Users Users { get; set; }
        public virtual PostType PostType { get; set; }
        public virtual ICollection<PostComments> PostCommentses { get; set; }
    }
}