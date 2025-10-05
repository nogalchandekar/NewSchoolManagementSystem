using NewSchoolManagementSystem.DAL;
using NewSchoolManagementSystem.Models.DataModel;
using NewSchoolManagementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewSchoolManagementSystem.Controllers
{
    public class LoginController : Controller
    {
		School_Management_SystemEntities db = new School_Management_SystemEntities();
		Response response = new Response();
        AdminLogin_DAL admin = new AdminLogin_DAL();

		// GET: Login
		public ActionResult Index(VMtblAdmin vmtblAdminrequest)
		{
			VMtblAdmin loginresponse = admin.CheckAdminLogin(vmtblAdminrequest);
			if (loginresponse != null && loginresponse.IsLoginSuccess)
			{
				AddSession(loginresponse);
				TempData["LoginSuccess"] = "Welcome, " + loginresponse.UserName + "!";
				return RedirectToAction("Index", "AdminDashboard");
			}
			TempData["Message"] = "Incorrect Username or Password.";
			return View();
		}

		private void AddSession(VMtblAdmin vmtblAdminrequest)
		{
			Session["UserName"] = vmtblAdminrequest.UserName;
			Session["UserID"] = vmtblAdminrequest.AdminId;
			Session.Timeout = 30; // 30 minutes
		}


	}
}