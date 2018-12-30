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
    public class AccountBLL
    {
        DAL db;
        public AccountBLL(string username, string password, ref string err)
        {
            db = new DAL(username, password, ref err);
        }
        public bool changePassword(string Username, string NewPass, string OldPass, ref string err)
        {
            return db.MyExecuteNonQuery(
                "spChangePassAcc",
                CommandType.StoredProcedure,
                ref err,
                new SqlParameter("@Username", Username),
                new SqlParameter("@NewPass", NewPass),
                new SqlParameter("@OldPass", OldPass));
        }

        public DataSet getAccounts(ref string err)
        {
            return db.ExecuteQueryDataSet(
                "SELECT * FROM vGetAccounts", CommandType.Text, ref err);
        }

        public DataSet searchAccounts(string username,ref string err)
        {
            return db.ExecuteQueryDataSet(
                "spSearchAccounts", CommandType.StoredProcedure,
                ref err, new SqlParameter("@key", username));
        }

        public bool resetPassword(string Username, ref string err)
        {
            return db.MyExecuteNonQuery(
                "spChangePassAcc",
                CommandType.StoredProcedure,
                ref err,
                new SqlParameter("@Username", Username));
        }
    }
}
