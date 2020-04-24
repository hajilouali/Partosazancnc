using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models.ViewModels
{
    public class OverviewViewModel
    {
        [Display(Name = "لوگوی سایت ")]
        public string Logo { get; set; }
        [Display(Name = "فاوآیکون")]
        public string fivicon { get; set; }
        [Display(Name = "نام سایت ")]
        [Required(ErrorMessage = "لطفا {0}‌را وارد نمایید")]
        public string SiteName { get; set; }
        [Display(Name = "توضیحات سایت ")]
        [MaxLength(180,ErrorMessage = "حداکثر {1} کاراکتر مورد قبول میباشد")]
        public string SiteDiscription { get; set; }
        [Display(Name = "کلمات کلیدی سایت ")]
        public string SiteKeyWord { get; set; }

    }

    public class socialViewModel
    {
        [Display(Name = "اینستاگرام")]
        [DataType(DataType.Html)]
        
        public string Instagram { get; set; }
        [Display(Name = "تلگرام")]
        [DataType(DataType.Html)]
        public string Telegram { get; set; }
        [Display(Name = "فیس بوک")]
        [DataType(DataType.Html)]
        public string FaceBook { get; set; }
        [Display(Name = "آپارات")]
        [DataType(DataType.Html)]
        public string Aparat { get; set; }
    }

    public class ContactUsViewModel
    {
        [Display(Name = "آدرس ")]
        public string Address { get; set; }
        [Display(Name = "شماره تماس ")]
        public string Phone { get; set; }
        [Display(Name = "آدرس ایمیل  ")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمیباشد")]
        public string EmailWebsite { get; set; }
        
    }

    public class EmailSettingViewModel
    {
        [Display(Name = "آدرس هاست ")]
        public string EmailHost { get; set; }
        [Display(Name = "نام کاربری ")]
        public string EmailUserName { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور ")]
        public string EmailPassword { get; set; }
        [Display(Name = "پورت")]
        public int EmailPort { get; set; }
    }
}