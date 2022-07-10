using SampleProjectLeave.IRepository;
using SampleProjectLeave.Models;
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
            var result = _empRepository.GetEmpLeaveMasters(empCode,"");
            ViewBag.EmpDetails = result;
            return View();
        }
        [HttpGet]
        public JsonResult GetEmployeeDetails(Int32 empCode)
        {
            List<GetEmpLeaveMaster> emplist = new List<GetEmpLeaveMaster>();
            emplist = _empRepository.GetEmpLeaveMasters(empCode,"S");
        

            return Json(emplist, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EmployeeInsert(InsertEmpLeaveMaster insertEmpLeaveMaster)
        {
            Int32 empCode = 0;
            string returnVal = "";
            if (!ModelState.IsValid)
            {
                
                var result = _empRepository.GetEmpLeaveMasters(empCode,"");
                ViewBag.EmpDetails = result;
            }
            else
            {
                 returnVal = _empRepository.InsertEmpLeaveMasters(insertEmpLeaveMaster);
                 
            }
            return Json(returnVal, JsonRequestBehavior.AllowGet);

        }
    }
}