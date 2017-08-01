using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RBUP.Classes
{
    public class UserCheck
    {
        string conn_str = ConfigurationManager.ConnectionStrings["connectionstr"].ToString();

        public int CheckUserGroup(string username, string password)
        {
            string p;
            Crypt enc = new Crypt();
            p = enc.Encrypt(password);

            SqlConnection sqlconn = new SqlConnection(conn_str);
            SqlCommand sqlcomm = new SqlCommand("CheckUserGroup", sqlconn);
            sqlcomm.CommandType = CommandType.StoredProcedure;

            sqlcomm.Parameters.Add("@qlid", SqlDbType.Text);
            //sqlcomm.Parameters[0].Value = username;
            sqlcomm.Parameters[0].Value = "a";
            sqlcomm.Parameters.Add("@pass", SqlDbType.Text);
            //sqlcomm.Parameters[1].Value = p;
            sqlcomm.Parameters[1].Value = "a";
            sqlconn.Open();
            object id = sqlcomm.ExecuteScalar();
            sqlconn.Close();
            if ((id == null) || (id == DBNull.Value))
                return -1;
            return
                (int)id;
        }
    }
}