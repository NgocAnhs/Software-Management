using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    class EmployeesBLL
    {
        DAL db;
        public EmployeesBLL(string username, string password, ref string err)
        {
            db = new DAL(username, password, ref err);
        }

        public DataSet getEmployees(ref string err)
        {
            return db.ExecuteQueryDataSet(
                "SELECT * FROM vGetEmployees", CommandType.Text, ref err);
        }
        public bool delEmployees(string EmployeeID, ref string err)
        {
            return db.MyExecuteNonQuery(
                "spDelEmployees",
                CommandType.StoredProcedure,
                ref err,
                new SqlParameter("@EmployeeID", EmployeeID));
        }

        public DataSet getEmpOrders(string EmployeeID, ref string err)
        {
            return db.ExecuteQueryDataSet(
                "spGetEmpOrders", CommandType.StoredProcedure, ref err,
                new SqlParameter("@EmployeeID", EmployeeID));
        }
        public bool insertEmployeesCreateAcc(string EmployeeName,bool isFemale,
            DateTime BirthDate, DateTime HireDate, string Address, string Phone, 
            string Photo, string Notes, string Office, ref string err)
        {
            return db.MyExecuteNonQuery(
                "spInsertEmployeesCreateAcc",
                CommandType.StoredProcedure,
                ref err,
                new SqlParameter("@EmployeeName", EmployeeName),
                new SqlParameter("@isFemale", isFemale),
                new SqlParameter("@BirthDate", BirthDate),
                new SqlParameter("@HireDate", HireDate),
                new SqlParameter("@Address", Address),
                new SqlParameter("@Phone", Phone),
                new SqlParameter("@Photo", Photo),
                new SqlParameter("@Notes", Notes),
                new SqlParameter("@Office", Office));
        }
        public bool updateEmployees(string EmployeeID, string EmployeeName, bool isFemale,
            DateTime BirthDate, DateTime HireDate, string Address, string Phone,
            string Photo, string Notes, string Office,bool Activity, ref string err)
        {
            return db.MyExecuteNonQuery(
                "spUpdateEmployees",
                CommandType.StoredProcedure,
                ref err,
                new SqlParameter("@EmployeeID", EmployeeID),
                new SqlParameter("@EmployeeName", EmployeeName),
                new SqlParameter("@isFemale", isFemale),
                new SqlParameter("@BirthDate", BirthDate),
                new SqlParameter("@HireDate", HireDate),
                new SqlParameter("@Address", Address),
                new SqlParameter("@Phone", Phone),
                new SqlParameter("@Photo", Photo),
                new SqlParameter("@Notes", Notes),
                new SqlParameter("@Office", Office),
                new SqlParameter("@Activity", Activity));
        }
        public DataSet searchEmployees(string key, ref string err)
        {
            return db.ExecuteQueryDataSet(
                "spSearchEmployees", CommandType.StoredProcedure, ref err,
                new SqlParameter("@key", key));
        }
    }
}
