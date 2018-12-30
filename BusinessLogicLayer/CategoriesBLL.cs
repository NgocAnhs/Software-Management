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
    public class CategoriesBLL
    {
        DAL db;
        public CategoriesBLL(string username, string password, ref string err)
        {
            db = new DAL(username, password, ref err);
        }
        
        public DataSet getCategories(ref string err)
        {
            return db.ExecuteQueryDataSet(
                "SELECT * FROM vGetCategories", CommandType.Text, ref err);
        }
        public bool delCategories(string CategoryID, ref string err)
        {
            return db.MyExecuteNonQuery(
                "spDelCategories",
                CommandType.StoredProcedure,
                ref err,
                new SqlParameter("@CategoryID", CategoryID));
        }
        public bool insertCategories(string CategoryName, ref string err)
        {
            return db.MyExecuteNonQuery(
                "spInsertCategories",
                CommandType.StoredProcedure,
                ref err,
                new SqlParameter("@CategoryName", CategoryName));
        }
        public bool updateCategories(string CategoryID,string CategoryName, ref string err)
        {
            return db.MyExecuteNonQuery(
                "spUpdateCategories",
                CommandType.StoredProcedure,
                ref err,
                new SqlParameter("@CategoryID", CategoryID),
                new SqlParameter("@CategoryName", CategoryName));
        }
        public DataSet searchCategories(string key,ref string err)
        {
            return db.ExecuteQueryDataSet(
                "spSearchCategories", CommandType.StoredProcedure, ref err,
                new SqlParameter("@key", key));
        }
    }
}
