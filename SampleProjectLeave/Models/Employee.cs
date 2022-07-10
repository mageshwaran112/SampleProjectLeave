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

    }
    public class InsertEmpLeaveMaster
    {
        public int EmpCode { get; set; }
        public DateTime LeaveAppliedDate { get; set; }

    }
}