using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;
using BLL;
using Microsoft.AspNetCore.Http;

namespace Expense_Manager.Controllers
{

    public class AccountController : Controller
    {
        // GET: Account

        BLL.AccountBLL accountBLL = new BLL.AccountBLL();

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterInfo(Models.UserInfo info)
        {
            int Result = 0;
            string message;

            try
            {
                if (ModelState.IsValid)
                {
                        Result = accountBLL.Register(info);
                        if (Result == 1)
                        {
                            message = "You are Successfully Registered";
                        }
                        else
                        {
                            message = "Oops Something went wrong";
                        }
                    return Json(new { success = true, responseText = message }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
            return View("Register",info);

        }


        public ActionResult LoginToDashboard(Models.Login info)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int Result = accountBLL.IsUserExistWithUsernamePass(info);
                    if (Result == -1)
                    {
                        ModelState.AddModelError("password", "Password is wrong");
                        return View("Login");     //here directly returning to view bcoz RedirectionToAction() will erase the data of model error
                    }
                    if (Result == -2)
                    {
                        ModelState.AddModelError("email", "Username doesn't exist");
                        return View("Login");
                    }
                    if (Result == 1)
                    {
                        Models.UserInfo BALinfo = new Models.UserInfo();
                        BALinfo = accountBLL.FetchUserInfo(info);

                        HttpCookie VarCookie = new HttpCookie("info");
                        VarCookie["id"] = BALinfo.id.ToString();
                        VarCookie["fname"] = BALinfo.firstname;           //here setting name to show on dashboard and id to perform any operation
                        VarCookie["lname"] = BALinfo.lastname;
                        HttpContext.Response.SetCookie(VarCookie);

                        FormsAuthentication.SetAuthCookie(BALinfo.email, false);
                        return RedirectToAction("Add_Expense", "AddExpenseOrIncome");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
          return RedirectToAction("Login", "Account");
        }

        public ActionResult CheckUsernameExist(string email)
        {
            int result = 0;
            if (email != null)
            {
                result = accountBLL.CheckUsernameIsExist(email);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Signout()
        {
            HttpCookie aCookie;   //Instantiate a cookie placeholder          //here deleting cookie eg. id , fname,lname
            aCookie= Request.Cookies.Get("info");    //get the cookie by its name
            aCookie.Value = "";    //set a blank value to the cookie
            aCookie.Expires = DateTime.Now.AddDays(-1);    //Setting the expiration date
            Response.Cookies.Add(aCookie);    //Set the cookie to delete it.

            FormsAuthentication.SignOut();
            return View("Login");
        }

        public ActionResult ForgotPass()
        {
            return View();
        }

        [HttpGet]
        public int GetUserId()
        {
            int userid = -1;
            HttpCookie cookieObj = HttpContext.Request.Cookies.Get("info");
            if (cookieObj != null)
            {
                userid = Convert.ToInt32(cookieObj["id"]);
            }
            return userid;
        }
    }
}