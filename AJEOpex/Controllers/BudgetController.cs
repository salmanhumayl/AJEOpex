using Dapper; 
using AJEOpex.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_BP.Controllers
{
    public class BudgetController : Controller
    {
        System.Data.IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        // GET: Budget
        public ActionResult Opex()
        {
            
            var obj1 = db.Query<OpexViewModel>("Select a.OA_ID,a.Description, 0 as Acual, 0 as BudgetYTD, 0 as BudgetVar, '' as Comments  FROM AMC_Opex as a where ItemType = 'F'").ToList();
            db.Close(); 
            return View(obj1);
        }


       [HttpPost]
        public ActionResult SaveOMCOpexBudget(List<OpexViewModel> Model,int BudgetedYear,String Department)
        {
            string sqlDetail="";
            int RecordID = 0;
            string sql = " INSERT INTO TH_Opex(BudgetYear,Department) " +
                              " VALUES (@BudgetedYear,@Department)" +
                             " SELECT CAST(SCOPE_IDENTITY() as int)";

            RecordID = db.Query<int>(sql, new
            {
                BudgetedYear,
                Department
            })
              .SingleOrDefault();

            if (RecordID > 0 )
            {
                foreach (var item in Model)
                {
                    sqlDetail = @"INSERT INTO TD_Opex(THOpexID,OA_ID,Actual,BudgetYTD,BudgetVar,Comments) " +
                                 " VALUES (@RecordID,@OA_ID,@Actual,@BudgetYTD,@BudgetVar,@Comments)";

                    db.Execute(sqlDetail,
                      new
                      {
                          RecordID,
                          item.OA_ID,
                          item.Actual,
                          item.BudgetYTD,
                          item.BudgetVar,
                          item.Comments
                      });
                }
            }
            
           return  RedirectToAction("Dasboard/index");

           // return View();
        }
    }
}