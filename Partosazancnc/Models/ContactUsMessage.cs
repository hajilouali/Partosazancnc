using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class ContactUsMessage
    {
        [Key]
        public int ContactUsID { get; set; }
        [Required(ErrorMessage = "لطفا {0}‌ را وارد نمایید")]
        [Display(Name = "نام / شرکت")]
        public string Name { get; set; }
        [Display(Name = "آدرس ایمیل")]
        [Required(ErrorMessage = "لطفا {0}‌ را وارد نمایید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمیباشد")]
        public string Email { get; set; }
        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = "لطفا {0}‌ را وارد نمایید")]
        public string Phone { get; set; }
        [Display(Name = "عنوان پیغام")]
        [Required(ErrorMessage = "لطفا {0}‌ را وارد نمایید")]
        public string Subject { get; set; }
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
        [Required(ErrorMessage = "تاریخ ارسال پیغام")]
        public DateTime DateSend { get; set; }
        [Display(Name = "وضعیت")]
        public Vaziaat Vaziaat { get; set; }
    }
}