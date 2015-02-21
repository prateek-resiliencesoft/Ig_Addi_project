using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using SocialPanel.Model;

namespace Social_Media_Service_Panel
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        //PaymentRepository pr = new PaymentRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    NavigationBasedOnRole();
                    //this.DataBind();

                    
                }
                else
                {
                    this.UserNavigationMenu.Visible = false;
                    this.AdminNavigationMenu.Visible = false;
                    this.EmployeeNavigationMenu.Visible = false;
                    //Response.Redirect("~/Logout.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Logout.aspx");
            }
        }

        public void NavigationBasedOnRole()
        {
            if (Roles.IsUserInRole("Admin"))
            {
                this.UserNavigationMenu.Visible = false;
                this.AdminNavigationMenu.Visible = true;
                this.EmployeeNavigationMenu.Visible = false;
            }
            else if (Roles.IsUserInRole("Employee"))
            {
                this.UserNavigationMenu.Visible = false;
                this.AdminNavigationMenu.Visible = false;
                this.EmployeeNavigationMenu.Visible = true;
            }
            else if (Roles.IsUserInRole("User"))
            {
                this.UserNavigationMenu.Visible = true;
                this.AdminNavigationMenu.Visible = false;
                this.EmployeeNavigationMenu.Visible = false;

                try
                {
                    //if (Session["Amount"] == null)
                    //{
                    //    tblPayment tblpay = pr.GetAmountDetail(HttpContext.Current.User.Identity.Name);
                    //    Session["Amount"] = tblpay.Amount;
                    //}
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                this.UserNavigationMenu.Visible = false;
                this.AdminNavigationMenu.Visible = false;
                this.EmployeeNavigationMenu.Visible = false;
            }

        }
    }
}
