using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class NewsLettersMail
    {
        [Key]
        public int NewsLettersMailID { get; set; }
        [Display(Name = "ایمیل شما")]
        [EmailAddress]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید ")]
        public string Email { get; set; }
        [Display(Name = "تاریخ ثبت ایمیل")]
        public DateTime SubmitTime { get; set; }

        public string DeActivatCode { get; set; }
        public virtual ICollection<NewsLetterMember> NewsLetterMembers { get; set; }
    }
}