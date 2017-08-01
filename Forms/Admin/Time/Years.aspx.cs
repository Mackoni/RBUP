using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace RBUP.Forms.Admin
{
    public partial class Years : System.Web.UI.Page
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
                    btnUpdateYear.Enabled = true;
                }
                else
                {
                    InitKontroleNew();
                    btnUpdateYear.Enabled = false;
                }
            }
        }

        protected void InitKontroleNew() { }

        protected void InitKontroleID(string id)
        {
            hfSelectedIndex.Value = id;
            SqlConnection sqlconn = new SqlConnection(conn_str);
            SqlCommand sqlcomm = new SqlCommand("Years_Load", sqlconn);
            sqlcomm.CommandType = CommandType.StoredProcedure;

            sqlcomm.Parameters.Add("@id", SqlDbType.Int);
            sqlcomm.Parameters[0].Value = id;

            SqlDataReader sqldr;
            sqlconn.Open();
            sqldr = sqlcomm.ExecuteReader();


            while (sqldr.Read())
            {
                txtYear.Text = sqldr[1].ToString();
            }
            sqlconn.Close();
        }

        protected void btnNewYear_Click(object sender, EventArgs e)
        {
            if (txtYear.Text != "")
            {
                try
                {
                    SqlConnection sqlconn = new SqlConnection(conn_str);
                    SqlCommand sqlcomm = new SqlCommand("Years_New", sqlconn);
                    sqlcomm.CommandType = CommandType.StoredProcedure;

                    sqlcomm.Parameters.Add("@years", SqlDbType.Int);
                    sqlcomm.Parameters[0].Value = txtYear.Text;

                    string id;
                    sqlconn.Open();
                    id = sqlcomm.ExecuteScalar().ToString();

                    if (id != "0")
                        Poruka.PorukaRedirekcija(this, "Item added successfully.", ResolveUrl("Years.aspx?id=" + id));
                    else
                        Poruka.PorukaRedirekcija(this, "Item already exists.", ResolveUrl("Years.aspx"));

                    sqlconn.Close();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message.ToString() + "');", true);
                }
            }
            else
                Poruka.PorukaRedirekcija(this, "Enter value.", ResolveUrl("Years.aspx"));
        }

        protected void btnUpdateYear_Click(object sender, EventArgs e)
        {
            if (txtYear.Text != "")
            {
                try
                {
                    SqlConnection sqlconn = new SqlConnection(conn_str);
                    SqlCommand sqlcomm = new SqlCommand("Years_Save", sqlconn);
                    sqlcomm.CommandType = CommandType.StoredProcedure;

                    sqlcomm.Parameters.Add("@id", SqlDbType.Int);
                    sqlcomm.Parameters[0].Value = hfSelectedIndex.Value;
                    sqlcomm.Parameters.Add("@years", SqlDbType.Text);
                    sqlcomm.Parameters[1].Value = txtYear.Text;

                    string id;
                    sqlconn.Open();
                    id = sqlcomm.ExecuteScalar().ToString();

                    if (id != "0")
                        Poruka.PorukaRedirekcija(this, "Item updated successfully.", ResolveUrl("Years.aspx?id=" + hfSelectedIndex.Value));
                    else
                        Poruka.PorukaRedirekcija(this, "Item already exists.", ResolveUrl("Years.aspx"));

                    sqlconn.Close();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message.ToString() + "');", true);
                }
            }
            else
                Poruka.PorukaRedirekcija(this, "Enter value.", ResolveUrl("Years.aspx"));
        }
    }
}