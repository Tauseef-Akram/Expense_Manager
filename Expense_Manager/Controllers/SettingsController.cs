using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expense_Manager.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult Settings()
        {
            return View();
        }
    }
}