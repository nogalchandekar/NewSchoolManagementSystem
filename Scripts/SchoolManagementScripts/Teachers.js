$(document).ready(function () {

    $("#btnSubmit").click(function () {
        $("#btnSubmit").text("Processing....!");
        $("#btnSubmit").prop("disabled", true);
        AddTeachers();
    });
    function AddTeachers() {
        var requestUrl = "/Teachers/AddTeachers";
        var TeachersModel = getTeachersModel();

        $.ajax({
            url: requestUrl,
            type: "POST",
            data: JSON.stringify(TeachersModel),
            contentType: "application/json; charset=utf-8",
            success: function () {
                alert("Student Added successfully......!!");
                window.location.reload();
                $("#btnSubmit").text("Submit");
                $("#btnSubmit").prop("disabled", false);
            },
            error: function (error) {
                console.error("Error Occour While Adding employee:", error);
                alert("Something wents wrong pls try Again Later");
                $("#btnSubmit").text("Submit");
                $("#btnSubmit").prop("disabled", false);
            }
        });
    }
    function getTeachersModel() {
        // ensure hidden id is numeric
        var idVal = $("#hdnteachersId").val();
        var teacherId = idVal && idVal !== "" ? parseInt(idVal, 10) : 0;

        return {
            TeachersId: teacherId,
            FirstName: $("#FirstName").val(),
            LastName: $("#LastName").val(),
            Gender: $("input[type='radio'][name='Gender']:checked").val(),
            DOB: $("#DOB").val(), // ensure your input has id="DOB" and type="date"
            MartialStatus: $("#MaritalStatus").val(), // your VM property is 'MartialStatus' so key name kept same
            BloodGroup: $("#BloodGroup").val(),
            MobileNo: $("#MobileNo").val() ? $("#MobileNo").val() : null,
            AlternativeMobileNo: $("#AlternateMobileNo").val() ? $("#AlternateMobileNo").val() : null,
            EmailId: $("#EmailId").val(),
            Address: $("#Address").val(),
            Qualification: $("#Qualification").val(),
            Specification: $("#Specialization").val(),
            Experience: $("#ExperienceYears").val() ? parseInt($("#ExperienceYears").val(), 10) : null,
            Joiningdate: $("#JoiningDate").val(), // ensure input id="JoiningDate" and format acceptable
            Department: $("#DepartmentId").val(),
            Designation: $("#DesignationId").val(),
            Salary: $("#Salary").val() ? parseFloat($("#Salary").val()) : null,
            UserName: $("#UserName").val(),
            Password: $("#Password").val(),
            Status: $("#Status").val(),
        };
    }





});