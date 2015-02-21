using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using Social_Media_Service_Panel.Helper;

/// <summary>
/// Summary description for MailFormat
/// </summary>
namespace Social_Media_Service_Panel_With_Pintrest.Helper
{
    public class MailFormats
    {
        public MailFormats()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public string RegistrationMail(string UserName , string Email, string Password)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<b>UserName : </b>" + UserName);
            sb.Append("<br/>");
            sb.Append("<b>Email : </b>" + Email);
            sb.Append("<br/>");
            sb.Append("<b>Password : </b>" + Password);
            sb.Append("<br/>");

            string Format = MailTemplate("", sb.ToString());
            return Format;
        }


        // Start

        public string OrderMailBody(string OrderType, string Url, string OrderId, string OrderSite)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<b>OrderId : </b>" + OrderId);
            sb.Append("<br/>");
            sb.Append("<b>OrderType : </b>" + OrderType);
            sb.Append("<br/>");
            sb.Append("<b>OrderSite : </b>" + OrderSite);
            sb.Append("<br/>");
            //sb.Append("<b>OrderDetails : </b>" + OrderDetails);
            //sb.Append("<br/>");

            string Format = MailTemplate("Order Details of " + OrderSite, sb.ToString());
            return Format;
        }

        public string EmployeeOrderMailBody(string OrderType, string URL, int Amount, string OrderId, string OrderSite)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<b>OrderId : </b>" + OrderId);
            sb.Append("<br/>");
            sb.Append("<b>OrderType : </b>" + OrderType);
            sb.Append("<br/>");
            sb.Append("<b>OrderSite : </b>" + OrderSite);
            sb.Append("<br/>");
            sb.Append("<b>URL : </b>" + URL);
            sb.Append("<br/>");
            sb.Append("<b>Count : </b>" + Amount);
            sb.Append("<br/>");

            string Format = MailTemplate("Order Details of " + OrderSite, sb.ToString());
            return Format;
        }

        public string MessageMailBody(string Message)
        {
            StringBuilder sb = new StringBuilder();


            sb.Append("<b>Message : </b>" + Message);
            sb.Append("<br/>");
            string Format = MailTemplate("", sb.ToString());
            return Format;
        }

        private string MailTemplate(string SubBody, string MainBody)
        {
            string Body = FileHelper.ReadStringFromTextfile(HttpContext.Current.Server.MapPath("~/MailTemplate/Mail.txt"));
            string MailBody = Body.Replace("@BodyTile", SubBody).Replace("@BodyDescription",MainBody);
            return MailBody;
        }

        public void SendMessageMailWithFormat(string To, string Body)
        {
            string From = "socialpanelorders@gmail.com";

            try
            {
                
                MailHelper.SendMailMessage(From, To, string.Empty, string.Empty, "You have successfully Updated Project Details.", Body);
            }
            catch (Exception ex)
            {

            }

          

        }

        public void SendNewOrderMailWithFormat(string To, string Body)
        {
            string From = "socialpanelorders@gmail.com";

            try
            {
                //Mail To Client (User)
                MailHelper.SendMailMessage(From, To, string.Empty, string.Empty, "You have successfully added order.", Body);
            }
            catch (Exception ex)
            {

            }

            try
            {
                //Mail To Employee 
                MailHelper.SendMailMessage(From, string.Empty, "socialhelper@resiliencesoft.com", string.Empty, "You have got new order.", Body);
            }
            catch (Exception ex)
            {

            }
            
        }

        public void SendOrderStatusMailWithFormat(string To, string Body)
        {
            string From = "socialpanelorders@gmail.com";

            try
            {
                //Mail To Client (User)
                MailHelper.SendMailMessage(From, To, string.Empty, string.Empty, "Your Order Is Succrssfully Completed.", Body);
            }
            catch (Exception ex)
            {

            }

            try
            {
                //Mail To Employee 
                MailHelper.SendMailMessage(From, string.Empty, "mailer1@resiliencesoft.com", string.Empty, "We Have Succrssfully Completed The Orders.", Body);
            }
            catch (Exception ex)
            {

            }

        }

        public void SendRegistrationMailWithFormat(string To, string Body)
        {
            string From = "socialpanelorders@gmail.com";

            try
            {
                //Mail To Client (User)
                MailHelper.SendMailMessage(From, To, string.Empty, string.Empty, "You have successfully registered with us.", Body);
            }
            catch (Exception ex)
            {

            }
        }

        public string ForgetPassword(string UserName, string NewPassword)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Hello " + UserName + "<br/><br/>");
            sb.Append("<b>New Password :- </b>" + NewPassword);
            sb.Append("<br/>");
            string Format = MailTemplate("you have new password.", sb.ToString());
            return Format;
        }

        public void SendForgetPasswordMailWithFormat(string To, string Body)
        {
            string From = "socialpanelorders@gmail.com";

            try
            {
                //Mail To Client (User)
                MailHelper.SendMailMessage(From, To, string.Empty, string.Empty, "You Have New Password.", Body);
            }
            catch (Exception ex)
            {

            }
        }
    } 
}
