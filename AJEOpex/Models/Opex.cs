using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AJEOpex.Models
{
    public class Opex
    {
        public int OpexID { set; get; }
        public int BudgetYear { set; get; }
        public string Department { set; get; }

        public List<OpexDetail> lstOpexDetails { get; set; }

    }
}