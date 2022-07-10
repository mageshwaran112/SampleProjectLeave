using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleProjectLeave.Models
{
    public class GetEmpLeaveMaster
    {
        public int EmpCode { get; set; }
        public string EmpName { get; set; }
        public int LeaveEligibility { get; set; }
        public int LeaveBalance { get; set; }

    }
    public class InsertEmpLeaveMaster
    {
        [Required(ErrorMessage = "Select Employee Name")]
        public int EmpCode { get; set; }
     
        [Required(ErrorMessage ="Select Leave Date")]
        public DateTime LeaveAppliedDate { get; set; }

    }
 

//    CREATE PROCEDURE SP_Employee(
//   @EmpCode int= NULL,
//   @LeaveAppliedDate datetime,
//   @input char(1),
//@LeaveBalance int
//)
//AS
//BEGIN
//DECLARE @LeaveCount AS INT;
//    IF(@EmpCode= 0)
//BEGIN
//SET @EmpCode=NULL
//END
//IF(@input= 'I')
//BEGIN
//   IF EXISTS(SELECT 1 FROM EmpLeaveApliedDate where LeaveAppliedDate = @LeaveAppliedDate)
//   BEGIN
//      SELECT 'Your Already Applied Same Date' AS ReturnValue;
//    RETURN
// END
// ELSE IF EXISTS(SELECT 1 FROM EmpLeaveMaster where EmpLeaveMaster.LeaveEligibility= 0 AND EmpCode = @EmpCode)
//    BEGIN
//       SELECT 'Your Leave Balance is Zero'  AS ReturnValue;
//    RETURN
//   END
//   ELSE
//   BEGIN
//        INSERT INTO EmpLeaveApliedDate(EmpCode, LeaveAppliedDate)

//        SELECT EmpCode = @EmpCode, LeaveAppliedDate = @LeaveAppliedDate;
//    SET @LeaveCount = (select COUNT(*) from EmpLeaveApliedDate where Empcode = @EmpCode);
//		SET @LeaveBalance = (SELECT LeaveEligibility-@LeaveCount FROM EmpLeaveMaster where Empcode=@EmpCode);
//	SELECT @LeaveBalance AS ReturnValue;
//    RETURN;
//   END

//END
//ELSE IF(@input= 'S')
//BEGIN
//    SET @LeaveCount=(select COUNT(*) from EmpLeaveApliedDate where Empcode=@EmpCode);
//	SET @LeaveBalance = (SELECT LeaveEligibility-@LeaveCount FROM EmpLeaveMaster where Empcode=@EmpCode);
//	SELECT @LeaveBalance AS LeaveBalance, * FROM EmpLeaveMaster WHERE EmpCode=COALESCE(@EmpCode, EmpLeaveMaster.EmpCode)

//    ORDER BY EmpLeaveMaster.EmpName ASC;
//    END
//    ELSE
//BEGIN
//SELECT 0 AS LeaveBalance, * from EmpLeaveMaster
// END;
//    END;



}