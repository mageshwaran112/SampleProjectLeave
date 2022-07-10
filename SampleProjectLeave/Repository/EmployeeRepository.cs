using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SampleProjectLeave.IRepository;
using SampleProjectLeave.Models;

namespace SampleProjectLeave.Repository
{
    public class EmployeeRepository:IEmployee
    {
        SqlConnection sqlCon = null;
        String SqlconString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        public List<GetEmpLeaveMaster> GetEmpLeaveMasters(Int32? EmpCode)
        {
            List<GetEmpLeaveMaster> EmpList = new List<GetEmpLeaveMaster>();
            GetEmpLeaveMaster Emp;
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("SP_Employee", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@EmpCode", SqlDbType.Int).Value = EmpCode;
                sql_cmnd.Parameters.AddWithValue("@LeaveAppliedDate", SqlDbType.DateTime).Value =DateTime.Now.ToString();
                sql_cmnd.Parameters.AddWithValue("@input", SqlDbType.Char).Value = string.Empty;
                SqlDataReader reader=  sql_cmnd.ExecuteReader();
                while(reader.Read())
                {
                    Emp = new GetEmpLeaveMaster();
                    Emp.EmpCode =Convert.ToInt32(reader["EmpCode"]);
                    Emp.EmpName = reader["EmpName"].ToString();
                    Emp.LeaveEligibility = Convert.ToInt32(reader["LeaveEligibility"]);
                    EmpList.Add(Emp);
                }
                sqlCon.Close();
            }
            return EmpList;
        }
    }
}
