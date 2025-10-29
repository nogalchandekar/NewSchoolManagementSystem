using NewSchoolManagementSystem.DAL;
using NewSchoolManagementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewSchoolManagementSystem.Controllers
{
    public class TeachersController : Controller
    {
		Teachers_DAL teachers_DAL = new Teachers_DAL();

		// GET: Teachers
		public ActionResult Index()
        {
            return View();
        }

		public ActionResult RegristrationForm()
		{
			return View();
		}

		[HttpPost]
        public ActionResult AddTeachers(VMTeachers vMTeachersRequest) 
        {
			return Json(teachers_DAL.AddTeachers(vMTeachersRequest), JsonRequestBehavior.AllowGet);
		}

	}
}