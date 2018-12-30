using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class OrdersBLL
    {
        DAL db;
        public OrdersBLL(string username, string password, ref string err)
        {
            db = new DAL(username, password, ref err);
        }

        public DataSet getOrders(ref string err)
        {
            return db.ExecuteQueryDataSet(
                "SELECT * FROM vGetAllOrders", CommandType.Text, ref err);
        }
        public DataSet getOneOrderDetails(string OrderID, ref string err)
        {
            return db.ExecuteQueryDataSet(
                "spGetOneOrderDetails", CommandType.StoredProcedure, ref err,
                new SqlParameter("@OrderID", OrderID));
        }

        public bool insertOrders(string EmployeeID,string CustomerName,decimal Price, ref string err)
        {
            return db.MyExecuteNonQuery(
                "spInsertOrders",
                CommandType.StoredProcedure,
                ref err,
                new SqlParameter("@EmployeeID", EmployeeID),
                new SqlParameter("@CustomerName", CustomerName),
                new SqlParameter("@Price", Price));
        }

        public DataSet searchOrderID(string OrderID, ref string err)
        {
            return db.ExecuteQueryDataSet(
                "spSearchOrderID", CommandType.StoredProcedure, ref err,
                new SqlParameter("@key", OrderID));
        }
        public DataSet searchOrderTime(DateTime fromDate, DateTime toDate, ref string err)
        {
            return db.ExecuteQueryDataSet(
                "spSearchOrdersTime", CommandType.StoredProcedure, ref err,
                new SqlParameter("@fromDate", fromDate),
                new SqlParameter("@toDate", toDate));
        }
    }
}
