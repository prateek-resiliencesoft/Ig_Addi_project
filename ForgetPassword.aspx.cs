using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Social_Media_Service_Panel_With_Pintrest.Helper;

namespace SocialPanel
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool LockUser = Membership.Provider.UnlockUser(txtUserName.Text.Trim());
                if (LockUser)
                {
                    var Details = Membership.GetUser(txtUserName.Text.Trim());
                    string Email = Details.Email;
                    string Password = Membership.Provider.ResetPassword(txtUserName.Text.Trim(), "admin");
                    if (Password != string.Empty)
                    {
                        MailFormats mf = new MailFormats();
                        string Body = mf.ForgetPassword(txtUserName.Text.Trim(), Password);
                        mf.SendForgetPasswordMailWithFormat(Email, Body);
                    }
                    else
                    {
                        lblerror.Text = txtUserName.Text.Trim() + " Is Lock";
                    }
                }
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
            }
        }
    }
}