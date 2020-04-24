using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class VisitorLogs
    {
        [Key]
        public int VisiteId { get; set; }
        public double VisitCount { get; set; }
        public DateTime DateTime { get; set; }
    }
}