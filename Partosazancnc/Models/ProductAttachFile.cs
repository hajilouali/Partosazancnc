using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class ProductAttachFile
    {
        [Key]
        public int ProductAttachFileID { get; set; }

        [MaxLength(300, ErrorMessage = "حداکثر {1} کاراکتر مورد قبول می باشد")]
        [Display(Name = "عنوان فایل پیوستی")]
        public string AttachFileTitle { get; set; }

        [MaxLength(700, ErrorMessage = "حداکثر {1} کاراکتر مورد قبول می باشد")]
        [Display(Name = "نام فایل ")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string FileName { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}