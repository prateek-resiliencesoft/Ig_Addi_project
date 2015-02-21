using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace SocialPanel
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipCreateStatus status;


            Membership.CreateUser("testadmin", "admin1234", "testadmin@testadmin.com", "name", "testadmin", true, out status);

            Roles.AddUserToRole("testadmin", "Admin");

            //Roles.CreateRole("Admin");
        }
    }
}