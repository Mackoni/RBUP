using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBUP.Forms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            RBUP.Classes.UserCheck uc = new Classes.UserCheck();
            int uID = uc.CheckUserGroup(txtQLID.Text, txtPassword.Text);
            if (uID == 1)
            {
                //Msg.Text = "admin";
                Session["UlogovaniID"] = uID;
                FormsAuthentication.RedirectFromLoginPage(uID.ToString(), cbRemember.Checked);
                Response.Redirect("Admin/Admin.aspx");
            }
            else if (uID==2 || uID==3)
            {
                //Msg.Text = "aim/ce";
                Session["UlogovaniID"] = uID;
                FormsAuthentication.RedirectFromLoginPage(uID.ToString(), cbRemember.Checked);
                Response.Redirect("Users/Users.aspx");
            }
            else
            {
                Msg.Text = "Pogrešno korisničko ime ili šifra. Pokušajte ponovo.";
            }
        }

    }
}