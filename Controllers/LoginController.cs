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
		[HttpGet]
		public ActionResult Index()
		{
			// Clear old messages when the page loads
			TempData["Message"] = null;
			return View();
		}

		// POST: Login
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Index(VMtblAdmin vmtblAdminrequest)
		{
			// Server-side validation
			if (string.IsNullOrWhiteSpace(vmtblAdminrequest.UserName) ||
				string.IsNullOrWhiteSpace(vmtblAdminrequest.Password))
			{
				TempData["Message"] = "Please enter Username and Password.";
				return View(vmtblAdminrequest);
			}

			VMtblAdmin loginresponse = admin.CheckAdminLogin(vmtblAdminrequest);
			if (loginresponse != null && loginresponse.IsLoginSuccess)
			{
				AddSession(loginresponse);
				TempData["LoginSuccess"] = "Welcome, " + loginresponse.UserName + "!";
				return RedirectToAction("Index", "AdminDashboard");
			}

			TempData["Message"] = "Incorrect Username or Password.";
			return View(vmtblAdminrequest);
		}

		private void AddSession(VMtblAdmin vmtblAdminrequest)
		{
			Session["UserName"] = vmtblAdminrequest.UserName;
			Session["UserID"] = vmtblAdminrequest.AdminId;
			Session.Timeout = 30; // 30 minutes
		}



	}
}