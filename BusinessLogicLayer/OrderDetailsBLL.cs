using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class OrderDetailsBLL
    {
        DAL db;
        public OrderDetailsBLL(string username, string password, ref string err)
        {
            db = new DAL(username, password, ref err);
        }

        public DataSet getOrderDetails(ref string err)
        {
            return db.ExecuteQueryDataSet(
                "SELECT * FROM vGetAllOrderDetails", CommandType.Text, ref err);
        }

        public bool insertOrderDetails(string OrderID, string ProductID, 
            int Quantity, decimal Price, ref string err)
        {
            return db.MyExecuteNonQuery(
                "spInsertOrderDetails",
                CommandType.StoredProcedure,
                ref err,
                new SqlParameter("@OrderID", OrderID),
                new SqlParameter("@ProductID", ProductID),
                new SqlParameter("@Quantity", Quantity),
                new SqlParameter("@Price", Price));
        }

        public DataSet searchOrderDetails(string key, ref string err)
        {
            return db.ExecuteQueryDataSet(
                "spSearchOrderDetails", CommandType.StoredProcedure, ref err,
                new SqlParameter("@key", key));
        }
    }
}
