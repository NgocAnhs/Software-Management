using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// SQL Provider
using System.Data.SqlClient;
// DataSet - DataTable
using System.Data;

namespace DataAccessLayer
{
    // connect to database
    // get some data
    public class DAL
    {
        SqlConnection cnn;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp;
        // constructor
        public DAL(string username, string password, ref string err)
        {
            string strConnect = "Server = (local); Database = Store; " +
                "User Id = " + username + ";Password = " + password;
            try
            {
                cnn = new SqlConnection(strConnect);
                if (cnn.State == ConnectionState.Open)
                    cnn.Open();
                cnn.Open();
            }
            catch (SqlException ex)
            {
                err=ex.Message;
            }
        }
        // data access methods
        // Select query ==> DataSet (DataTableCollection)
        public DataSet ExecuteQueryDataSet(
            string strSQL, CommandType ct, ref string err, params SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = cnn;
                cmd.CommandText = strSQL;
                cmd.CommandType = ct;

                if (param != null)
                    foreach (SqlParameter p in param)
                        cmd.Parameters.Add(p);

                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
            }
            catch (SqlException ex)
            {
                err = ex.Message;
            }
            finally
            {
                cnn.Close();
            }
            return ds;
        }
        // INSERT-DELETE-UPDATE-STORE PROCEDURE
        // action query
        public bool MyExecuteNonQuery(string strSQL,
            CommandType ct, ref string error,
            params SqlParameter[] param)
        {
            bool f = false;

            if (cnn.State == ConnectionState.Open)
                cnn.Close();
            cnn.Open();

            cmd.Parameters.Clear();
            cmd.Connection = cnn;
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            if (param != null)
                foreach (SqlParameter p in param)
                    cmd.Parameters.Add(p);

            try
            {
                cmd.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                cnn.Close();
            }
            return f;
        }
    }
}
