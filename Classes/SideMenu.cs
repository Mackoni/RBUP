using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RBUP.Classes
{
    public class SideMenu
    {
        public List<MenuNodes> getMenuNodes(int userID)
        {
            List<MenuNodes> nodes = new List<MenuNodes>();

            MenuNodes RBUPList = new MenuNodes("RBUP list", "~/Forms/Admin/adminRBUP.aspx");
            MenuNodes AuditLog = new MenuNodes("Audit logs", "~/Forms/Admin/AdminRBUP/AuditLogUser.aspx");
            MenuNodes Types = new MenuNodes("Types", "~/Forms/Admin/AdminRBUP/Types.aspx");
            MenuNodes Actions = new MenuNodes("Types", "~/Forms/Admin/AdminRBUP/Actions.aspx");
            RBUPList.subNodes.Add(AuditLog);
            RBUPList.subNodes.Add(Types);
            RBUPList.subNodes.Add(Actions);
            nodes.Add(RBUPList);

            MenuNodes Customers = new MenuNodes("Customers", "~/Forms/Admin/Customer/Customers.aspx");
            MenuNodes ATMList = new MenuNodes("ATMs", "~/Forms/Admin/Customer/ATMs.aspx");            
            Customers.subNodes.Add(ATMList);
            nodes.Add(Customers);

            MenuNodes Users = new MenuNodes("Users", "~/Forms/Admin/Users/UsersList.aspx");
            
            MenuNodes Teams = new MenuNodes("Teams", "~/Forms/Admin/Users/Teams.aspx");
            MenuNodes Groups = new MenuNodes("Groups", "~/Forms/Admin/Users/Groups.aspx");
            Users.subNodes.Add(Teams);
            Users.subNodes.Add(Groups);
            nodes.Add(Users);

            MenuNodes Regions = new MenuNodes("Regions", "~/Forms/Admin/Country/Regions.aspx");
            MenuNodes Countries = new MenuNodes("Countries", "~/Forms/Admin/Country/Countries.aspx");
            MenuNodes Cities = new MenuNodes("Cities", "~/Forms/Admin/Country/Cities.aspx");
            Regions.subNodes.Add(Countries);
            Regions.subNodes.Add(Cities);
            nodes.Add(Regions);

            MenuNodes Years = new MenuNodes("Years", "~/Forms/Admin/Time/Years.aspx");
            MenuNodes Parts = new MenuNodes("Parts", "~/Forms/Admin/Time/Parts.aspx");
            Years.subNodes.Add(Parts);
            nodes.Add(Years);

            /*   for (int i = 0; i < 2; i++)
               {
                   MenuNodes newNode = new MenuNodes("node " + (i + 1), "#");
                   for (int j = 0; j < 3; j++)
                   {
                       MenuNodes newNode1 = new MenuNodes("subNode " + (j + 1), "#");
                       for (int k = 0; k < 2; k++)
                       {
                           newNode1.subNodes.Add(new MenuNodes("subSubNode " + (k + 1), "#"));
                       }
                       newNode.subNodes.Add(newNode1);
                   }
                   nodes.Add(newNode);
               }*/

            return nodes;
        }

        public class MenuNodes
        {
            public string text { get; set; }
            public string url { get; set; }
            public List<MenuNodes> subNodes { get; set; }

            public MenuNodes()
            {
                text = url = "";
                subNodes = new List<MenuNodes>();
            }
            public MenuNodes(string text, string url)
            {
                this.text = text;
                this.url = url;
                subNodes = new List<MenuNodes>();
            }
        }
    }
}