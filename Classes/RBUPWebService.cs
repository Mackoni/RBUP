using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for RBUPWS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]

public class RBUPWebService : System.Web.Services.WebService
{
    string conn_str = ConfigurationManager.ConnectionStrings["connectionstr"].ToString();

    [WebMethod]
    public string addGrupaKartice(string naziv, string opis)
    {
        return "vracena poruka";
    }

    [WebMethod]
    public int getUserIdByUNamePass(string username, string password)
    {
        return 1;
    }

    #region FIND

    [WebMethod]
    public List<ListRegions> RegionsFind(string region)
    {
        SqlConnection sqlconn = new SqlConnection(conn_str);
        SqlCommand sqlcomm = new SqlCommand("Regions_Find", sqlconn);
        sqlcomm.CommandType = CommandType.StoredProcedure;

        if (region == "")
        {
            sqlcomm.Parameters.Add("@region", SqlDbType.Text);
            sqlcomm.Parameters[0].Value = null;
        }
        else
        {
            sqlcomm.Parameters.Add("@region", SqlDbType.Text);
            sqlcomm.Parameters[0].Value = region;
        }

        SqlDataReader sqldr;
        sqlconn.Open();
        sqldr = sqlcomm.ExecuteReader();
        List<ListRegions> lista = new List<ListRegions> { };

        while (sqldr.Read())
        {
            lista.Add(new ListRegions
            {
                id = sqldr[0].ToString(),
                region = sqldr[1].ToString()
            });
        }
        sqlconn.Close();
        return lista;
    }

    [WebMethod]
    public List<ListYears> YearsFind(string years)
    {
        SqlConnection sqlconn = new SqlConnection(conn_str);
        SqlCommand sqlcomm = new SqlCommand("Years_Find", sqlconn);
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

    [WebMethod]
    public List<ListTeams> TeamsFind(string team)
    {
        SqlConnection sqlconn = new SqlConnection(conn_str);
        SqlCommand sqlcomm = new SqlCommand("Teams_Find", sqlconn);
        sqlcomm.CommandType = CommandType.StoredProcedure;

        if (team == "")
        {
            sqlcomm.Parameters.Add("@team", SqlDbType.Text);
            sqlcomm.Parameters[0].Value = null;
        }
        else
        {
            sqlcomm.Parameters.Add("@team", SqlDbType.Text);
            sqlcomm.Parameters[0].Value = team;
        }

        SqlDataReader sqldr;
        sqlconn.Open();
        sqldr = sqlcomm.ExecuteReader();
        List<ListTeams> lista = new List<ListTeams> { };
        
        while (sqldr.Read())
        {
            lista.Add(new ListTeams
            {
                id = sqldr[0].ToString(),
                team = sqldr[1].ToString()
            });
        }
        sqlconn.Close();
        return lista;
    }

    [WebMethod]
    public List<ListParts> PartsFind(string parts, string descriptions)
    {
        SqlConnection sqlconn = new SqlConnection(conn_str);
        SqlCommand sqlcomm = new SqlCommand("Parts_Find", sqlconn);
        sqlcomm.CommandType = CommandType.StoredProcedure;

        if (parts == "")
        {
            sqlcomm.Parameters.Add("@parts", SqlDbType.Text);
            sqlcomm.Parameters[0].Value = null;
        }
        else
        {
            sqlcomm.Parameters.Add("@parts", SqlDbType.Text);
            sqlcomm.Parameters[0].Value = parts;
        }

        if (descriptions == "")
        {
            sqlcomm.Parameters.Add("@descriptions", SqlDbType.Text);
            sqlcomm.Parameters[1].Value = null;
        }
        else
        {
            sqlcomm.Parameters.Add("@description", SqlDbType.Text);
            sqlcomm.Parameters[1].Value = descriptions;
        }

        SqlDataReader sqldr;
        sqlconn.Open();
        sqldr = sqlcomm.ExecuteReader();
        List<ListParts> lista = new List<ListParts> { };

        while (sqldr.Read())
        {
            lista.Add(new ListParts
            {
                id = sqldr[0].ToString(),
                parts = sqldr[1].ToString(),
                descriptions = sqldr[2].ToString()
            });
        }
        sqlconn.Close();
        return lista;
    }
    #endregion

    #region GET

    [WebMethod]
    public List<ListYears> GetYears(string years)
    {
        List<ListYears> lista = new List<ListYears> { };

        SqlConnection sqlconn = new SqlConnection(conn_str);
        SqlCommand sqlcomm = new SqlCommand("Get_Years", sqlconn);
        sqlcomm.CommandType = CommandType.StoredProcedure;

        sqlcomm.Parameters.Add("@years", SqlDbType.Text);
        sqlcomm.Parameters[0].Value = years;

        SqlDataReader sqldr;
        sqlconn.Open();
        sqldr = sqlcomm.ExecuteReader();

        while (sqldr.Read())
        {
            lista.Add(new ListYears { id = sqldr[0].ToString(), years = sqldr[1].ToString() });
        }
        sqlconn.Close();
        return lista;
    }

    #endregion

}

    #region LISTE

    public class ListRegions
{
    public string id;
    public string region;
}

    public class ListYears
{
    public string id;
    public string years;
}

    public class ListTeams
    {
        public string id;
        public string team;
    }

public class ListParts
{
    public string id;
    public string parts;
    public string descriptions;
}

#endregion