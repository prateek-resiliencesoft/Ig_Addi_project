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

            try
            {
                if (Request.Form != null)
                {
                    string card = Request.Form["card"];
                    string month = Request.Form["exprmonth"];
                    string year = Request.Form["expryear"];
                    string cvc = Request.Form["cvc"];
                    string plan = Request.Form["plan"];
                    string instagramuser = Request.Form["instagramuser"];

                    if (!string.IsNullOrEmpty(instagramuser))
                    {
                        try
                        {
                            SoftBucketHttpUtility httpHelper = new SoftBucketHttpUtility();

                            string mediaUrl = "https://api.stripe.com/v1/customers";
                            string postData = "card[number]=" + card + "&card[exp_month]=" + month + "&card[exp_year]=" + year + "&card[cvc]=" + cvc + "&plan=" + plan;
                            string MediaPageSource = httpHelper.PostDataToWeb(new Uri(mediaUrl), postData, string.Empty, string.Empty);

                            SubscriptionDetails subscriptionDetails = JsonParser.GetSubscriptionDetails(MediaPageSource);

                            //Insertt Query
                            if (!objCutomerDetailRepository.CheckInstagramScreenNameExist(instagramuser) && subscriptionDetails != null) //Check Ig user exist or not
                            {
                                objCutomerDetailRepository.AddCutomerDetails(subscriptionDetails.sources.data[0].customer, instagramuser, plan);

                            }
                            else
                            {
                                objCutomerDetailRepository.UpdateCutomerDetails(instagramuser, plan);
                            }

                            Response.Write("success : " + subscriptionDetails.sources.data[0].customer);
                        }
                        catch (Exception ex)
                        {
                            Response.Write("Failed : " + ex.Message);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Failed : " + ex.Message);
            }
        }

       
    }
}