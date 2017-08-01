using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBUP.Forms.Admin
{
    public partial class ATMs : System.Web.UI.Page
    {
        string conn_str = ConfigurationManager.ConnectionStrings["connectionstr"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

    }
}