using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Partosazancnc.Models
{
    public class Sliders
    {
        [Key]
        public int SlideID { get; set; }
        [Required(ErrorMessage = "لطفا {0}‌را وارد نمایید")]
        [Display(Name = "عنوان اسلاید")]
        public string SliderTitle { get; set; }
        [Display(Name = "توضیحات مختصر")]
        [DataType(DataType.MultilineText)]
        public string SliderDiscription { get; set; }
        [Display(Name = "لینک")]
        [DataType(DataType.Url,ErrorMessage = "لین وارد شده معتبر نمی باشد")]
        public string SliderURL { get; set; }
        public string data_transition { get; set; }
        public string data_slotamount { get; set; }
        public string data_masterspeed { get; set; }
        public string data_Delay { get; set; }
        public string data_saveperformance { get; set; }
        [Display(Name = "تصویر اسلاید")]
        public string ImageSlider { get; set; }
        public string Imagedatabgposition { get; set; }
        public string Imagedatabgfit { get; set; }
        [Display(Name = "Css‌اختصاصی ")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string CostomCss { get; set; }
        [Display(Name = "وضعیت")]
        public Vaziaat Vaziaat { get; set; }
        public virtual ICollection<LayerSliders> LayerSliders { get; set; }
    }
}