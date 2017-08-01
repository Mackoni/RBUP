using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using static RBUP.Classes.SideMenu;

namespace RBUP.Forms.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        private RBUP.Classes.SideMenu meni;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                meni = new RBUP.Classes.SideMenu();
                TreeNode myNode = new TreeNode();
                myNode.Text = "NCR";
                myNode.NavigateUrl = "/";
                //// myNode.ImageUrl = "images/folder.png";
                navigationTreeView.Nodes.Add(myNode);

                List<MenuNodes> menuNodes = meni.getMenuNodes(1);

                for (int i = 0; i < menuNodes.Count; i++)
                {
                    insertMenuNode(menuNodes[i], "NCR");
                }
            }
        }

        private void insertMenuNode(MenuNodes node, string parentNode)
        {
            TreeNode myNode = new TreeNode();
            myNode.Text = node.text;
            myNode.NavigateUrl = node.url;
            if (node.subNodes.Count != 0) { myNode.SelectAction = TreeNodeSelectAction.SelectExpand; }
            navigationTreeView.FindNode(parentNode).ChildNodes.Add(myNode);
            for (int i = 0; i < node.subNodes.Count; i++)
            {
                insertMenuNode(node.subNodes[i], parentNode + "/" + node.text);
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Forms/Login.aspx");
        }
    }
}