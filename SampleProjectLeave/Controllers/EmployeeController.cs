using SampleProjectLeave.IRepository;
using SampleProjectLeave.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProjectLeave.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private readonly IEmployee _empRepository;
        public EmployeeController()
        {
            _empRepository = new EmployeeRepository();
        }
        public ActionResult EmployeeDetails(Int32?empCode)
        {
            var result = _empRepository.GetEmpLeaveMasters(empCode);
            ViewBag.EmpDetails = result;
            return View();
        }
    }
}