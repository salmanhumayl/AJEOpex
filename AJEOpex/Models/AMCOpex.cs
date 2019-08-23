using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AJEOpex.Models
{
    public class AMCOpex
    {

        [ScaffoldColumn(true)]
        public int OA_ID { set; get; }
        public string Description { set; get; }
        public char ItemType { set; get; }
    }
}