using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL.DataClasses;

namespace Expense_Manager.Controllers
{
    [Authorize]
    public class AddExpenseOrIncomeController : Controller
    {

        CategoryBLL categoryBLL = new CategoryBLL();
        ExpenseIncomeBLL ExInObj = new ExpenseIncomeBLL();
        AccountController account = new AccountController();

        // GET: AddExpenseOrIncome
        [HttpGet]
        public ActionResult Add_expense()
        {
            BindDropList();
            return View();
        }

        public void BindDropList()
        {
            int userid = 0;
            HttpCookie cookieObj = HttpContext.Request.Cookies.Get("info");
            if (cookieObj != null)
            {
                userid = Convert.ToInt32(cookieObj["id"]);
            }
            List<Models.Category> categoryList = new List<Models.Category>();
            if (userid > 0)
            {
                categoryList = categoryBLL.GetCategoryList(userid.ToString());
            }
            ViewBag.list = categoryList;
        }

        /*
        [HttpGet]
        public ActionResult GetCategories()
        {
            //int id = account.GetUserId();
            int userid = 0;
            HttpCookie cookieObj = HttpContext.Request.Cookies.Get("info");
            if (cookieObj != null)
            {
                userid = Convert.ToInt32(cookieObj["id"]);
            }
            List<Models.Category> categoryList = new List<Models.Category>();
            if (userid > 0)
            {
                categoryList = categoryBLL.GetCategoryList(userid.ToString());
                return Json(categoryList, JsonRequestBehavior.AllowGet);
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }
        */

        [HttpPost]
        public ActionResult Add_record(Models.Records rec)
        {
            int result = 0;
            bool success = false;
            string message = "Error";
            BindDropList();
            if (ModelState.IsValid && rec.userid>0)
            {
                result=ExInObj.AddRecord(rec);
                success = true;
                message = "Successfully saved record !";
                return Json(new { success = success, responseText = message }, JsonRequestBehavior.AllowGet);
            }
            
            return View("Add_Expense");
        }

    }
}