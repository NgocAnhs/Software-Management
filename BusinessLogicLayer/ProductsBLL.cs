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
    public class ProductsBLL
    {
        DAL db;
        public ProductsBLL(string username, string password, ref string err)
        {
            db = new DAL(username, password, ref err);
        }

        public DataSet getProducts(ref string err)
        {
            return db.ExecuteQueryDataSet(
                "SELECT * FROM vGetProducts", CommandType.Text, ref err);
        }
        public bool delProducts(string ProductID, ref string err)
        {
            return db.MyExecuteNonQuery(
                "spDelProducts",
                CommandType.StoredProcedure,
                ref err,
                new SqlParameter("@ProductID", ProductID));
        }
        public bool insertProducts(string ProductName,string Description, string Image,
            string Price, int Quantity, string CategoryID, ref string err)
        {
            return db.MyExecuteNonQuery(
                "spInsertProducts",
                CommandType.StoredProcedure,
                ref err,
                new SqlParameter("@ProductName", ProductName),
                new SqlParameter("@Description", Description),
                new SqlParameter("@Image", Image),
                new SqlParameter("@Price", Price),
                new SqlParameter("@Quantity", Quantity),
                new SqlParameter("@CategoryID", CategoryID));
        }
        public bool updateProducts(string ProductID, string ProductName,
            string Description, string Image, string Price, 
            int Quantity, string CategoryID, ref string err)
        {
            return db.MyExecuteNonQuery(
                "spUpdateProducts",
                CommandType.StoredProcedure,
                ref err,
                new SqlParameter("@ProductID", ProductID),
                new SqlParameter("@ProductName", ProductName),
                new SqlParameter("@Description", Description),
                new SqlParameter("@Image", Image),
                new SqlParameter("@Price", Price),
                new SqlParameter("@Quantity", Quantity),
                new SqlParameter("@CategoryID", CategoryID));
        }
        public DataSet searchProducts(string key, ref string err)
        {
            return db.ExecuteQueryDataSet(
                "spSearchProducts", CommandType.StoredProcedure, ref err,
                new SqlParameter("@key", key));
        }
    }
}
