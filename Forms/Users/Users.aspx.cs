using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBUP.Forms.Users
{
    public partial class Users1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UlogovaniID"] == null)
            {
                FormsAuthentication.SignOut();
                Response.Redirect("Login.aspx");
            }
        }
    }
}