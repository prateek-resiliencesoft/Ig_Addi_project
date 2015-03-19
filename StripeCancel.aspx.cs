using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialPanel.Model;
using System.Xml.Serialization;
using System.Text;
using System.Web.Script.Serialization;
using Social_Media_Service_Panel.Helper;
using SocialPanel.Helper;

namespace SocialPanel
{
    public partial class StripeCancel : System.Web.UI.Page
    {
        CutomerDetailRepository objCutomerDetailRepository = new CutomerDetailRepository();

        private void WriteResponseData(object obj)
        {
            this.Context.Response.Clear();

            string responsetype = "json";
            if (!string.IsNullOrEmpty(this.Context.Request.QueryString["responsetype"]))
            {
                responsetype = this.Context.Request.QueryString["responsetype"];
            }

            if (responsetype.ToLower().Equals("xml"))
            {

                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(stringwriter, obj);

                this.Context.Response.ContentType = "text/xml";
                this.Context.Response.ContentEncoding = Encoding.UTF8;
                this.Context.Response.Write(stringwriter.ToString());
            }
            else
            {
                this.Context.Response.ContentType = "application/json; charset=utf-8";
                this.Context.Response.Write(new JavaScriptSerializer().Serialize(obj));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassMessage MSG = new ClassMessage();

            try
            {


                if (Request.QueryString["customer"] != null)
                {
                    string customer = Request.QueryString["customer"];
                   // string customer = "cus_5t6rQU83A8Qlec";

                    if (!string.IsNullOrEmpty(customer))
                    {
                        try
                        {
                            SoftBucketHttpUtility httpHelper = new SoftBucketHttpUtility();

                            string SubscriptionId = objCutomerDetailRepository.GetSubscription(customer);
                            string mediaUrl = "https://api.stripe.com/v1/customers/" + customer + "/subscriptions/" + SubscriptionId;

                            //string postData = "card[number]=" + card + "&card[exp_month]=" + month + "&card[exp_year]=" + year + "&card[cvc]=" + cvc + "&plan=" + plan;
                            string MediaPageSource = httpHelper.PostDataToCancel(new Uri(mediaUrl), string.Empty, string.Empty, string.Empty);
                            CancelSubscription cancelSubscription = JsonParser.CancelSubscriptionDetails(MediaPageSource);

                            if (cancelSubscription.status=="canceled")
                            {
                                objCutomerDetailRepository.UpdateStatus(cancelSubscription.customer, "false");
                                Response.Redirect("http://welikeu.com/user/profile.php?cancel=true", false);
                            }
                            else
                            {
                                Response.Redirect("http://welikeu.com/user/profile.php?cancel=false", false);
                            }

                            //MSG.Type = "success";
                            //MSG.Message = "subcription cancelled";
                        }
                        catch (Exception ex)
                        {
                            Response.Redirect("http://welikeu.com/user/profile.php?cancel=error", false);
                            //MSG.Type = "failed";
                            //MSG.Message = ex.Message;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MSG.Type = "failed";
                MSG.Message = ex.Message;
            }

            WriteResponseData(MSG);

        }
    }

}