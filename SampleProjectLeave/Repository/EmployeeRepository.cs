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
        public List<GetEmpLeaveMaster> GetEmpLeaveMasters(Int32? EmpCode, string Input)
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
                sql_cmnd.Parameters.AddWithValue("@input", SqlDbType.Char).Value = Input;
                sql_cmnd.Parameters.AddWithValue("@LeaveBalance", SqlDbType.Char).Value = 0;
                SqlDataReader reader=  sql_cmnd.ExecuteReader();
                while(reader.Read())
                {
                    Emp = new GetEmpLeaveMaster();
                    Emp.EmpCode =Convert.ToInt32(reader["EmpCode"]);
                    Emp.EmpName = reader["EmpName"].ToString();
                    Emp.LeaveEligibility = Convert.ToInt32(reader["LeaveEligibility"]);
                    Emp.LeaveBalance = Convert.ToInt32(reader["LeaveBalance"]);
                    EmpList.Add(Emp);
                }
                sqlCon.Close();
            }
            return EmpList;
        }
        public string InsertEmpLeaveMasters(InsertEmpLeaveMaster insertEmpLeave )
        {
            string returnVal = string.Empty;
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("SP_Employee", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@EmpCode", SqlDbType.Int).Value = insertEmpLeave.EmpCode;
                sql_cmnd.Parameters.AddWithValue("@LeaveAppliedDate", SqlDbType.DateTime).Value = Convert.ToDateTime(insertEmpLeave.LeaveAppliedDate).ToString("yyyy/MM/dd");
                sql_cmnd.Parameters.AddWithValue("@input", SqlDbType.Char).Value ='I';
                sql_cmnd.Parameters.AddWithValue("@LeaveBalance", SqlDbType.Char).Value = 0;
                // sql_cmnd.ExecuteNonQuery();
                SqlDataReader reader = sql_cmnd.ExecuteReader();
                while (reader.Read())
                {

                    returnVal = reader["ReturnValue"].ToString();

                }
                sqlCon.Close();
            }
            return returnVal;
        }
    }
}
