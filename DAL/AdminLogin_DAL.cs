using NewSchoolManagementSystem.Models.DataModel;
using NewSchoolManagementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSchoolManagementSystem.DAL
{
	public class AdminLogin_DAL
	{
		School_Management_SystemEntities db = new School_Management_SystemEntities();
		Response response = new Response();

		public VMtblAdmin CheckAdminLogin(VMtblAdmin vmtblAdminrequest)
		{
			VMtblAdmin vmadminlogin = new VMtblAdmin();

			try
			{
				var login = db.tbl_Admin
							  .AsEnumerable() // brings data to memory for case-sensitive check
							  .Where(x => string.Equals(x.UserName, vmtblAdminrequest.UserName, StringComparison.Ordinal) &&
										  string.Equals(x.Password, vmtblAdminrequest.Password, StringComparison.Ordinal) &&
										  x.IsActive == true)
							  .FirstOrDefault();

				if (login != null)
				{
					vmadminlogin = new VMtblAdmin
					{
						UserName = login.UserName,
						Password = login.Password,
						AdminId = login.AdminId,
						IsLoginSuccess = true
					};
				}
				else
				{
					vmadminlogin.IsLoginSuccess = false;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
				vmadminlogin.IsLoginSuccess = false;
			}

			return vmadminlogin;
		}




	}
}