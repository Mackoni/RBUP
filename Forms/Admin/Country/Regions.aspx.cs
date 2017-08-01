using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBUP.Forms.Admin
{
    public partial class Regions : System.Web.UI.Page
    {
        string conn_str = ConfigurationManager.ConnectionStrings["connectionstr"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //http://172.24.10.114:1618/PrimeriAjaxJQuery.aspx?id=test - POZIV SA ARGUMENTOM
                if (Page.Request.QueryString["id"] != null)
                {
                    InitKontroleID(Page.Request.QueryString["id"].ToString());
                    btnUpdateRegion.Enabled = true;
                }
                else
                {
                    InitKontroleNew();
                    btnUpdateRegion.Enabled = false;
                }
            }
        }

        protected void InitKontroleNew() { }

        protected void InitKontroleID(string id)
        {
            hfSelectedIndex.Value = id;
            SqlConnection sqlconn = new SqlConnection(conn_str);
            SqlCommand sqlcomm = new SqlCommand("Regions_Load", sqlconn);
            sqlcomm.CommandType = CommandType.StoredProcedure;

            sqlcomm.Parameters.Add("@id", SqlDbType.Int);
            sqlcomm.Parameters[0].Value = id;

            SqlDataReader sqldr;
            sqlconn.Open();
            sqldr = sqlcomm.ExecuteReader();

            while (sqldr.Read())
            {
                txtRegion.Text = sqldr[1].ToString();
            }
            sqlconn.Close();
        }

        protected void btnNewRegion_Click(object sender, EventArgs e)
        {
            if (txtRegion.Text != "")
            {
                try
                {
                    SqlConnection sqlconn = new SqlConnection(conn_str);
                    SqlCommand sqlcomm = new SqlCommand("Regions_New", sqlconn);
                    sqlcomm.CommandType = CommandType.StoredProcedure;

                    sqlcomm.Parameters.Add("@region", SqlDbType.Text);
                    sqlcomm.Parameters[0].Value = txtRegion.Text;

                    string id;
                    sqlconn.Open();
                    id = sqlcomm.ExecuteScalar().ToString();

                    if (id != "0")
                        Poruka.PorukaRedirekcija(this, "Item added successfully.", ResolveUrl("Regions.aspx?id=" + id));
                    else
                        Poruka.PorukaRedirekcija(this, "Item already exists.", ResolveUrl("Regions.aspx"));

                    sqlconn.Close();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message.ToString() + "');", true);
                }
            }
            else
                Poruka.PorukaRedirekcija(this, "Enter value.", ResolveUrl("Regions.aspx"));
        }

        protected void btnUpdateRegion_Click(object sender, EventArgs e)
        {
            if (txtRegion.Text != "")
            {
                try
                {
                    SqlConnection sqlconn = new SqlConnection(conn_str);
                    SqlCommand sqlcomm = new SqlCommand("Regions_Save", sqlconn);
                    sqlcomm.CommandType = CommandType.StoredProcedure;

                    sqlcomm.Parameters.Add("@id", SqlDbType.Int);
                    sqlcomm.Parameters[0].Value = hfSelectedIndex.Value;
                    sqlcomm.Parameters.Add("@region", SqlDbType.Text);
                    sqlcomm.Parameters[1].Value = txtRegion.Text;

                    string id;
                    sqlconn.Open();
                    id = sqlcomm.ExecuteScalar().ToString();

                    if (id != "0")
                        Poruka.PorukaRedirekcija(this, "Item updated successfully.", ResolveUrl("Regions.aspx?id=" + hfSelectedIndex.Value));
                    else
                        Poruka.PorukaRedirekcija(this, "Item already exists.", ResolveUrl("Regions.aspx"));

                    sqlconn.Close();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message.ToString() + "');", true);
                }
            }
            else
                Poruka.PorukaRedirekcija(this, "Enter value.", ResolveUrl("Regions.aspx"));
        }
    }
}