using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Social_Media_Service_Panel.Helper;
using SocialPanel.Helper;
using SocialPanel.Model;
using SocialPanel.Admin;

namespace SocialPanel.User
{
    public partial class InstagramCallback : System.Web.UI.Page
    {

        HttpCalls objHttpCalls = new HttpCalls();
        JsonParser objJsonParser = new JsonParser();
        SoftBucketHttpUtility objSoftBucketHttpUtility = new SoftBucketHttpUtility();
        AddTokenRepository objaccesstoken = new AddTokenRepository();
        OrderRepository orderRepo = new OrderRepository();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string RedirectUri = ConfigurationManager.AppSettings["redirecturl"];
                if (Request["code"] == null && Session["Instagram"] == null)
                {
                    string ClientId = ConfigurationManager.AppSettings["client_id"];

                    string authorizationUrl = "https://api.instagram.com/oauth/authorize/?client_id=" + ClientId + "&redirect_uri=" + RedirectUri + "&response_type=code&&scope=comments+likes+relationships";
                    //string authorizationUrl = "https://api.instagram.com/oauth/authorize/?client_id=ff93a1cc8b6e45799f3019e8e01d5b2b&redirect_uri=http://localhost:34129/User/InstagramCallback.aspx&response_type=code&&scope=comments+likes+relationships";
                    Response.Redirect(authorizationUrl, false);
                    return;
                }
                else if (Request["code"] != null)
                {
                    string AccessToken = string.Empty;
                    string code = Request["code"];


                    string postdata = "client_id=" + ConfigurationManager.AppSettings["client_id"] + "&client_secret=" + ConfigurationManager.AppSettings["client_Secret"] + "&grant_type=authorization_code&redirect_uri=" + RedirectUri + "&code=" + code;
                    //string retunData = objoAuthTwitter.oAuthWebRequest(oAuthTwitter.Method.POST, "https://api.instagram.com/oauth/access_token", postdata);
                    //string retunData = objHttpCalls.Httpwebrequests("https://api.instagram.com/oauth/access_token?" + postdata, "POST");
                    string retunData = objSoftBucketHttpUtility.PostDataToWeb(new Uri("https://api.instagram.com/oauth/access_token"), postdata, "", "");
                    IGProfile objIGProfile = objJsonParser.GetIGuserProfileDetails(retunData);
                    if (objaccesstoken.CheckUserExist(objIGProfile.UserId))
                    {
                        //Update User
                        objaccesstoken.Updatecheckid(objIGProfile.AccessToken, objIGProfile.UserName);
                    }
                    else
                    {
                        //New User
                        objaccesstoken.AddToken(objIGProfile.UserId, objIGProfile.UserName, objIGProfile.AccessToken);
                        string OrderNumber = Guid.NewGuid().ToString();
                        int startpoint = 0;
                        int endpoint = 0;
                        string url = string.Empty;

                        try
                        {

                            url = "https://instagram.com/" + objIGProfile.UserName;

                            startpoint = InstagramDetails.GetNumberOfFollow(url);

                            endpoint = startpoint + 10;

                            orderRepo.AddOrder(OrderNumber, url, 10,
                                                DateTime.Now, startpoint, endpoint, 0, "Pending", DateTime.Now, "Follow", objIGProfile.UserName);

                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }



            }
            catch (Exception ex)
            {
            }

        }
    }
}