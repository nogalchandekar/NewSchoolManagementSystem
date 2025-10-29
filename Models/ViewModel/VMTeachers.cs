using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSchoolManagementSystem.Models.ViewModel
{
	public class VMTeachers
	{
		public int TeachersId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Gender { get; set; }
		public Nullable<System.DateTime> DOB { get; set; }
		public string MartialStatus { get; set; }
		public string BloodGroup { get; set; }
		public Nullable<decimal> MobileNo { get; set; }
		public Nullable<decimal> AlternativeMobileNo { get; set; }
		public string EmailId { get; set; }
		public string Address { get; set; }
		public string Qualification { get; set; }
		public string Specification { get; set; }
		public Nullable<int> Experience { get; set; }
		public Nullable<System.DateTime> Joiningdate { get; set; }
		public string Department { get; set; }
		public string Designation { get; set; }
		public Nullable<decimal> Salary { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Status { get; set; }
		public Nullable<bool> IsActive { get; set; }
		public string CreatedBy { get; set; }
		public Nullable<System.DateTime> CreatedDate { get; set; }
		public string ModifiedBy { get; set; }
		public Nullable<System.DateTime> ModifiedDate { get; set; }
	}
}