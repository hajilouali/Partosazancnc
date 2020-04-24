using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Partosazancnc.Models
{
    public class LayerSliders
    {
        [Key]
        public int LayerID { get; set; }
        public int SlideID { get; set; }
        [Display(Name = "تصویر لایه")]

        public string LayerImage { get; set; }
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        [Display(Name = "متن لایه")]
        public string LayerText { get; set; }
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string CostomCss { get; set; }
        public string data_x { get; set; }
        public string data_y { get; set; }
        
        public string data_speed { get; set; }
        public string data_start { get; set; }
        public string data_easing { get; set; }
        public string data_splitin { get; set; }
        public string data_splitout { get; set; }
        public string data_elementdelay { get; set; }
        public string data_endelementdelay { get; set; }
        public string data_captionhidden { get; set; }

        public string data_endspeed { get; set; }
        public string data_endeasing { get; set; }
        public string data_hoffset { get; set; }
        [AllowHtml]
        public string ClassCostom { get; set; }
        public virtual Sliders Sliders { get; set; }
    }
}