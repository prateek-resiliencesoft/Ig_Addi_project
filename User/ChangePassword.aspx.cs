using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace SocialPanel.User
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            txtNewPassword.Text = string.Empty;
            txtOldPassword.Text = string.Empty;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {

                bool Status = Membership.ValidateUser(HttpContext.Current.User.Identity.Name, txtOldPassword.Text.Trim());
                //bool Status = Membership.ValidateUser("test3", txtOldPassword.Text.Trim());
                if (Status)
                {
                    Membership.Provider.ChangePassword(HttpContext.Current.User.Identity.Name, txtOldPassword.Text.Trim(), txtNewPassword.Text.Trim());
                    //Membership.Provider.ChangePassword("test3", txtOldPassword.Text.Trim(), txtNewPassword.Text.Trim());
                    lblErrorMessage.Text = "Password Changed";
                }
                else
                {
                    lblErrorMessage.Text = "Password Is Not Correct";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}