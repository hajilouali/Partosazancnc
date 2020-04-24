using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Partosazancnc.Models.ViewModels
{
    public class WellComeViewModel
    {
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "متن ")]
        public string Text { get; set; }
    }

    public class FeaturesVewModel
    {
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "متن ")]
        public string Text { get; set; }
    }

    public class VisiteViewModel
    {
        public string daynale { get; set; }

        public string Count { get; set; }

    }

    public class NewsLetterViewModel
    {
        public string DeActiveCode { get; set; }
        public string Body { get; set; }
    }
}