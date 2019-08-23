using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AJEOpex.Models
{
    public class OpexDetail
    {
        public int OpexDetailID { set; get; }
        public int THOpexID { set; get; }
        public int OA_ID { set; get; }
        public Double Actual { set; get; }
        public Double BudgetYTD { set; get; }
        public Double BudgetVar { set; get; }
        public string Comments { set; get; }

    }
}