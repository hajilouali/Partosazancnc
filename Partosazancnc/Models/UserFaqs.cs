using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public enum Vaziaat
    {
        UnReade=0,
        Reade=1,
        Publish=2,
        Draft=3,
    }
    public class UserFaqs
    {
        [Key]
        public int UserFaqsID { get; set; }
        [Display(Name = "نام کاربر")]
        public string UserName { get; set; }
        [Display(Name = "ایمیل کاربر")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل وارد شده معتبر نمیباشد")]
        public string UserEmail { get; set; }
        [Display(Name = "سوال کاربر")]
        public string UserQuestion { get; set; }
        [Display(Name = "تاریخ ارسال سوال")]
        public DateTime Qdate { get; set; }
        [Display(Name = "وضعیت سوال")]
        public Vaziaat Vaziaat { get; set; }
    }
}