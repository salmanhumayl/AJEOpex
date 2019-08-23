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
    public class AMCOpexController : Controller
    {
        // GET: AMCOpex
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveAMCOpex(string Description)
        {
            int AMCOpexID = 0;
            System.Data.IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            string sql = " INSERT INTO AMC_Opex(Description,ItemType) " +
                              " VALUES (@Description,'F')" +
                             " SELECT CAST(SCOPE_IDENTITY() as int)";

            AMCOpexID = db.Query<int>(sql, new
            {
                Description
            })
              .SingleOrDefault();
           return Json(AMCOpexID, JsonRequestBehavior.AllowGet);
            
        }

    }
}