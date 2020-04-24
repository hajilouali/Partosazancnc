using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Partosazancnc.Models
{
    public class NewsLetters
    {
        [Key]
        public int NewsLetterId { get; set; }
        [Display(Name = "ارسال به لیست ")]
        public int? NewsLetterListId { get; set; }
        [Display(Name = "زمان ارسال ")]
        public DateTime DateTime { get; set; }
        [Display(Name = "روز های ارسالی")]
        public string Days { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "محتوای خبر نامه")]
        public string NewsLetterBody { get; set; }
       [Display(Name = "فعال ؟")]
        public bool IsActive { get; set; }

        public virtual NewsLetterList NewsLetterList { get; set; }

    }
}