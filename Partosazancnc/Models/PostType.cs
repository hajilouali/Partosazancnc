using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class PostType
    {
        [Key]
        public int PostTypeID { get; set; }

        [StringLength(50,ErrorMessage = "حداکثر {1} کاراکتر مورد مجاز میباشد ")]
        [Display(Name = "عنوان دسته بندی")]
        [Required(ErrorMessage = "لطفاْ {0} را وارد نمایید .")]
        public string Title { get; set; }



        public virtual ICollection<Post> Post { get; set; }
    }
}