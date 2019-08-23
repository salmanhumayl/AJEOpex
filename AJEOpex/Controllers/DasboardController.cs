using AJEOpex.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
namespace AJEOpex.Controllers
{
    public class DasboardController : Controller
    {
        System.Data.IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        // GET: Dasboard

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult OpexSummary()
        {

            var obj1 = db.Query<OpexSummaryViewModel>("Select  ROW_NUMBER() OVER(ORDER BY AMC_Opex.Description ASC) AS Sr,TD_Opex.OA_ID,AMC_Opex.Description,TD_Opex.Actual,TD_Opex.BudgetYTD," +
                                                      "TD_Opex.BudgetVar,TD_Opex.Comments" +
                                                      " From TD_Opex inner join AMC_Opex on TD_Opex.OA_ID = AMC_Opex.OA_ID").ToList();
            db.Close();
            return PartialView("_SummOpex",obj1);
        }
    }
}