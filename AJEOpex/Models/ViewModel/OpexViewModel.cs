using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AJEOpex.Models
{
    public class OpexViewModel
    {
        public int OA_ID { set; get; }

        public string Description { set; get; }
        public Double Actual { set; get; }
        public Double BudgetYTD { set; get; }

        public Double BudgetVar { set; get; }

        public string Comments { set; get; }

        public bool ItemSelection { set; get; }
    }


    public class OpexSummaryViewModel
    {
        public int  Sr { set; get; }
        public int OA_ID { set; get; }

        public string Description { set; get; }
        public Double Actual { set; get; }
        public Double BudgetYTD { set; get; }

        public Double BudgetVar { set; get; }

        public string Comments { set; get; }

        
    }

}