using NewSchoolManagementSystem.Models.DataModel;
using NewSchoolManagementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace NewSchoolManagementSystem.DAL
{
	public class Teachers_DAL
	{
		School_Management_SystemEntities db = new School_Management_SystemEntities();
		Response response = new Response();

		//========== Add / Update Teachers ==========///

		public Response AddTeachers(VMTeachers vMTeachersRequest)
		{
			Response status = new Response();
			using (var transaction = db.Database.BeginTransaction())
			{
				try
				{
					// Duplicate email check
					bool isDuplicate = db.tbl_Teachers
										 .Any(t => t.EmailId == vMTeachersRequest.EmailId && t.TeachersId != vMTeachersRequest.TeachersId);
					if (isDuplicate)
					{
						status.code = HttpStatusCode.Conflict;
						status.message = "This email id Already Exists.....!";
						return status;
					}

					// Try to find existing teacher by id (for update)
					var existingTeacher = db.tbl_Teachers
										   .FirstOrDefault(t => t.TeachersId == vMTeachersRequest.TeachersId);

					// Safe session read
					string createdBy = null;
					if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Session["UserName"] != null)
					{
						createdBy = System.Web.HttpContext.Current.Session["UserName"].ToString();
					}

					if (existingTeacher == null)
					{
						// Insert new teacher (do NOT set TeachersId for identity column)
						var newTeacher = new tbl_Teachers
						{
							FirstName = vMTeachersRequest.FirstName,
							LastName = vMTeachersRequest.LastName,
							Gender = vMTeachersRequest.Gender,
							DOB = vMTeachersRequest.DOB,
							MartialStatus = vMTeachersRequest.MartialStatus,
							BloodGroup = vMTeachersRequest.BloodGroup,
							MobileNo = vMTeachersRequest.MobileNo,
							AlternativeMobileNo = vMTeachersRequest.AlternativeMobileNo,
							EmailId = vMTeachersRequest.EmailId,
							Address = vMTeachersRequest.Address,
							Qualification = vMTeachersRequest.Qualification,
							Specification = vMTeachersRequest.Specification,
							Experience = vMTeachersRequest.Experience,
							Joiningdate = vMTeachersRequest.Joiningdate,
							Department = vMTeachersRequest.Department,
							Designation = vMTeachersRequest.Designation,
							Salary = vMTeachersRequest.Salary,
							UserName = vMTeachersRequest.UserName,
							Password = vMTeachersRequest.Password,
							Status = vMTeachersRequest.Status,
							IsActive = true,
							CreatedBy = createdBy,
							CreatedDate = DateTime.Now
						};

						db.tbl_Teachers.Add(newTeacher);            // <-- important fix: add newTeacher (not a null variable)
						db.SaveChanges();
						transaction.Commit();

						status.code = HttpStatusCode.OK;
						status.message = "Teacher Added Successfully";
					}
					else
					{
						// Update existing teacher
						existingTeacher.FirstName = vMTeachersRequest.FirstName;
						existingTeacher.LastName = vMTeachersRequest.LastName;
						existingTeacher.Gender = vMTeachersRequest.Gender;
						existingTeacher.DOB = vMTeachersRequest.DOB;
						existingTeacher.MartialStatus = vMTeachersRequest.MartialStatus;
						existingTeacher.BloodGroup = vMTeachersRequest.BloodGroup;
						existingTeacher.MobileNo = vMTeachersRequest.MobileNo;
						existingTeacher.AlternativeMobileNo = vMTeachersRequest.AlternativeMobileNo;
						existingTeacher.EmailId = vMTeachersRequest.EmailId;
						existingTeacher.Address = vMTeachersRequest.Address;
						existingTeacher.Qualification = vMTeachersRequest.Qualification;
						existingTeacher.Specification = vMTeachersRequest.Specification;
						existingTeacher.Experience = vMTeachersRequest.Experience;
						existingTeacher.Joiningdate = vMTeachersRequest.Joiningdate;
						existingTeacher.Department = vMTeachersRequest.Department;
						existingTeacher.Designation = vMTeachersRequest.Designation;
						existingTeacher.Salary = vMTeachersRequest.Salary;
						existingTeacher.UserName = vMTeachersRequest.UserName;
						existingTeacher.Password = vMTeachersRequest.Password;
						existingTeacher.Status = vMTeachersRequest.Status;
						existingTeacher.IsActive = vMTeachersRequest.IsActive ?? true;
						existingTeacher.ModifiedBy = createdBy;
						existingTeacher.ModifiedDate = DateTime.Now;

						db.SaveChanges();
						transaction.Commit();

						status.code = HttpStatusCode.OK;
						status.message = "Teacher Updated Successfully";
					}
				}
				catch (Exception ex)
				{
					transaction.Rollback();

					// Log actual exception in dev - you already do Console.WriteLine, keep it
					Console.WriteLine("Error: " + ex.Message);
					if (ex.InnerException != null)
					{
						Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
					}

					status.code = HttpStatusCode.InternalServerError;
					status.message = "Something went wrong, please try again later";
				}

				return status;
			}
		}

	}
}