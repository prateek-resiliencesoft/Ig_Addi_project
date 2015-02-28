using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Social_Media_Service_Panel.Helper;
using SocialPanel.Helper;
using SocialPanel.Model;

namespace SocialPanel
{
    public partial class StripeAPI : System.Web.UI.Page
    {

        CutomerDetailRepository objCutomerDetailRepository = new CutomerDetailRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"]==null)
            {
                Response.Redirect("Default.aspx",false);
            }

            //if (Request.Form!=null)
            //{
            //    string IguserName = Request.Form["IgScreenName"];
            //    string stripeToken = Request.Form["stripeToken"];
            //    string stripeTokenType = Request.Form["stripeTokenType"];
            //    string stripeEmail = Request.Form["stripeEmail"];
            //    string plan = Request.Form["plan"];


            
            //}
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(this.txtIgScrrenName.Text))
            {
                try
                {
                    SoftBucketHttpUtility httpHelper = new SoftBucketHttpUtility();

                    string mediaUrl = "https://api.stripe.com/v1/customers";
                    string postData = "card[number]=" + this.txtCard.Text + "&card[exp_month]=" + this.txtExpirationMonth.Text + "&card[exp_year]=" + this.txtExpirationYear.Text + "&card[cvc]=123&plan=" + Request.QueryString["id"].ToString();
                    string MediaPageSource = httpHelper.PostDataToWeb(new Uri(mediaUrl), postData, string.Empty, string.Empty);

                    SubscriptionDetails subscriptionDetails = JsonParser.GetSubscriptionDetails(MediaPageSource);

                    //Insertt Query
                    if (!objCutomerDetailRepository.CheckInstagramScreenNameExist(this.txtIgScrrenName.Text) && subscriptionDetails != null) //Check Ig user exist or not
                    {
                        objCutomerDetailRepository.AddCutomerDetails(subscriptionDetails.sources.data[0].customer, this.txtIgScrrenName.Text, Request.QueryString["id"].ToString());
                        
                    }
                    else
                    {
                        objCutomerDetailRepository.UpdateCutomerDetails(this.txtIgScrrenName.Text, Request.QueryString["id"].ToString());
                    }
                    Response.Redirect("User/InstagramCallback.aspx", false);
                }
                catch (Exception ex)
                {

                    lblerror.Text = ex.Message;
                }

            }
            
           
        }
    }
}