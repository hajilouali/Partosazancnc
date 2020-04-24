using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class Menu
    {
        [Key]
        public int MenusID { get; set; }
        [Display(Name = "تیتر منو")]
        public string MenuTitle { get; set; }
        [Display(Name = "لینک")]
        public string URL { get; set; }
        [Display(Name = "مادر")]
        public int? ParentID { get; set; }
    }
}