using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Social_Media_Service_Panel_With_Pintrest.Helper;

namespace Social_Media_Service_Panel
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.User != null)
                {
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "Admin"))
                        {
                            Response.Redirect("~/Admin/Home.aspx",false);
                        }
                        else
                        {
                            Response.Redirect("~/User/Home.aspx", false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsExistUser = Membership.ValidateUser(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                if (IsExistUser)
                {
                    if (Roles.IsUserInRole(txtUserName.Text.Trim(),"Admin"))
                    {
                        FormsAuthentication.SetAuthCookie(txtUserName.Text.Trim(), false);   
                        Response.Redirect("~/Admin/Home.aspx");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(txtUserName.Text.Trim(), false);
                        Response.Redirect("~/User/Home.aspx");
                    }
                }
                else
                {
                    lblerror.Text = "User & Password Is Not Correct";
                    txtUserName.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                lblerror.Text += ex.Message;
            }
        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        bool LockUser = Membership.Provider.UnlockUser(txtUserName.Text.Trim());
        //        if (LockUser)
        //        {
        //            var Details = Membership.GetUser(txtUserName.Text.Trim());
        //            string Email = Details.Email;
        //            string Password = Membership.Provider.ResetPassword(txtUserName.Text.Trim(), "answer");
        //            if (Password != string.Empty)
        //            {
        //                MailFormats mf = new MailFormats();
        //                string Body = mf.ForgetPassword(txtUserName.Text.Trim(), Password);
        //                mf.SendForgetPasswordMailWithFormat(Email, Body);
        //            }
        //            else
        //            {
        //                lblerror.Text = txtUserName.Text.Trim() + " Is Lock";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblerror.Text = ex.Message;
        //    }
        //}
    }
}