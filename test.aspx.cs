using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Social_Media_Service_Panel.Helper;

namespace SocialPanel
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SoftBucketHttpUtility httpHelper = new SoftBucketHttpUtility();

            //string PostData = "client_id=d699b2681e2644479f4b97b76b2bda33" +
            //                  "&client_secret=b524d5a73edc47e78396db76426d4f2f" +
            //                  "&object=user" +
            //                  "&aspect=media" +
            //                  "&verify_token=myVerifyToken" +
            //                  "&callback_url=http://52.10.69.137/post.aspx";

            //string aa = httpHelper.PostDataToWeb(new Uri("https://api.instagram.com/v1/subscriptions/"), PostData, "", string.Empty);
        }
    }
}