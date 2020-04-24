using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class NewsLetterList
    {
        [Key]
        public int NewsLetterListId { get; set; }
        [Display(Name = "نام لیست")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(150,ErrorMessage = "حداکثر تعداد کاراکتر {1} می باشد .")]
        public string NewsLetterListTitle { get; set; }
        public virtual ICollection<NewsLetterMember> NewsLetterMembers { get; set; }
        public virtual ICollection<NewsLetters> NewsLetterses { get; set; }
    }
}