using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSchoolManagementSystem.Models.ViewModel
{
	public class VMtblAdmin
	{
		public int AdminId { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public Nullable<bool> IsActive { get; set; }
		public bool IsLoginSuccess { get; set; }
	}
}