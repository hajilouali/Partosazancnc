using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class NewsLetterMember
    {
        [Key]
        public int NewsLetterMemberId { get; set; }
        public int NewsLetterListId { get; set; }
        public int NewsLettersMailID { get; set; }
        public virtual NewsLetterList NewsLetterList { get; set; }
        public virtual NewsLettersMail NewsLettersMail { get; set; }
    }
}