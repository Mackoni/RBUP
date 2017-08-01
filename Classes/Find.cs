using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;

namespace RBUP.Classes
{
    ///// <summary>
    ///// Summary description for RBUPWS
    ///// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    //// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //[System.Web.Script.Services.ScriptService]
    public partial class Find : System.Web.UI.Page
    {
        string conn_str = ConfigurationManager.ConnectionStrings["connectionstr"].ToString();

        [WebMethod]
        public List<ListYears> YearsFind(string years)
        {
            SqlConnection sqlconn = new SqlConnection(conn_str);
            SqlCommand sqlcomm = new SqlCommand("YearsFind", sqlconn);
            sqlcomm.CommandType = CommandType.StoredProcedure;

            if (years == "")
            {
                sqlcomm.Parameters.Add("@years", SqlDbType.Text);
                sqlcomm.Parameters[0].Value = null;
            }
            else
            {
                sqlcomm.Parameters.Add("@years", SqlDbType.Text);
                sqlcomm.Parameters[0].Value = years;
            }

            SqlDataReader sqldr;
            sqlconn.Open();
            sqldr = sqlcomm.ExecuteReader();
            List<ListYears> lista = new List<ListYears> { };

            while (sqldr.Read())
            {
                lista.Add(new ListYears
                {
                    id = sqldr[0].ToString(),
                    years = sqldr[1].ToString()
                });
            }
            sqlconn.Close();
            return lista;
        }

        public class ListYears
        {
            public string id;
            public string years;
        }
    }

    

}