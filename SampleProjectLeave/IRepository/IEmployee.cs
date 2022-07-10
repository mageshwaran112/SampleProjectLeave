using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleProjectLeave.Models;

namespace SampleProjectLeave.IRepository
{
    interface IEmployee
    {
        List<GetEmpLeaveMaster> GetEmpLeaveMasters(Int32? EmpCode);
    }
}
