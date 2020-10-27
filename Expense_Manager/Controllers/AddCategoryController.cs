using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL.DataClasses;
namespace Expense_Manager.Controllers
{
    [Authorize]
    public class AddCategoryController : Controller
    {
        // GET: AddCategory
        CategoryBLL categoryBLL = new CategoryBLL();
        Models.Category CategoryModel = new Models.Category();



        public ActionResult Add_Category()
        {
            string userid = "";
            HttpCookie cookieObj = HttpContext.Request.Cookies.Get("info");
            if (cookieObj != null)
            {
                userid = cookieObj["id"];
            }
            ViewBag.list= categoryBLL.GetCategoryList(userid);     //Here using viewdata to send list of categories
            return View();                                                   //this is one of the method to display multiple model in view
        }




        [HttpPost]
        public ActionResult SaveCategory(Models.Category category)
        {
            int result = 0;
            bool success = false;
            string message = "Error";
            if(ModelState.IsValid)
            {
                result = categoryBLL.AddCategory(category);
                if (result == 1)
                {
                    message = "Category Added Successfully!";
                    success = true;
                }
                else if(result == 2){
                    message = "Category Already Exist! Please give another category name.";
                    success = false;
                }else if (result == 0)
                {
                    message = "Category not added!";
                    success = false;
                }
                else
                {
                    message = "error";
                }
            }
            return Json(new { success = success, responseText =message }, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public ActionResult DeleteCategory(Models.Category category)
        {
            int result =categoryBLL.DeleteCategory(category.id);
            if (result == 1)
            {
                return Json(new { success = true, responseText = "" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, responseText = "Error in Deleting category !" }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult EditCategory(int id,string name)
        {
            if (id > 0 && name != null)
            {
                int result=categoryBLL.EditCategory(id, name);
                if (result == 1) {
                    return Json(new { success = true, responseText = "" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, responseText = "Error in Editing Category !" }, JsonRequestBehavior.AllowGet);
        }

    }
}