using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Social_Media_Service_Panel.Helper;
using Social_Media_Service_Panel.ForImage.Helper;

namespace SocialPanel.Helper
{
    public class JsonParser
    {

        public static SubscriptionDetails GetSubscriptionDetails(string Data)
        {
            SubscriptionDetails subscriptionDetails = new SubscriptionDetails();

            try
            {
                subscriptionDetails = JsonConvert.DeserializeObject<SubscriptionDetails>(Data);
            }
            catch (Exception ex)
            {

            }

            return subscriptionDetails;

        }

        public static InstagramUser GetInstagramUser(string Data)
        {
            InstagramUser instagramUser = new InstagramUser();

            try
            {
                instagramUser = JsonConvert.DeserializeObject<InstagramUser>(Data);
            }
            catch (Exception ex)
            {

            }

            return instagramUser;

        }

        public static InstagramImageResult GetImageResult(string data)
        {
            InstagramImageResult instaImage = new InstagramImageResult();

            try
            {
                instaImage = JsonConvert.DeserializeObject<InstagramImageResult>(data);
            }
            catch (Exception ex)
            {

            }

            return instaImage;
        }



        public static MediaDetails GetMediaValue(string PageSource)
        {
            MediaDetails md = new MediaDetails();

            try
            {
                JObject OBJData = JObject.Parse(PageSource);
                if (OBJData != null)
                {
                    JObject JDATA = (JObject)OBJData["data"];
                    if (JDATA != null)
                    {
                        md.link = (string)JDATA["link"];
                        JObject JLIKE = (JObject)JDATA["likes"];
                        if (JLIKE != null)
                        {
                            md.likecount = (int)JLIKE["count"];
                        }

                        JObject JUser = (JObject)JDATA["user"];
                        if (JUser != null)
                        {
                            md.username = (string)JUser["username"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return md;
        }

        public static List<MediaPostedDetails> GetMediaId(string PageSource)
        {
            List<MediaPostedDetails> lstMediaDetails = new List<MediaPostedDetails>();

            try
            {
                lstMediaDetails = JsonConvert.DeserializeObject<List<MediaPostedDetails>>(PageSource);
            }
            catch (Exception ex)
            {

            }

            return lstMediaDetails;
        }


        public IGProfile GetIGuserProfileDetails(string data)
        {
            //Getting profile details........
            IGProfile objIGProfile = new IGProfile();

            JObject Output = JObject.Parse(data);

            if (Output["access_token"] != null)
            {
                objIGProfile.AccessToken = (string)Output["access_token"];
            }

            if (Output["user"] != null)
            {
                JObject User = (JObject)Output["user"];
                if (User != null)
                {
                    objIGProfile.UserId = (string)User["id"];

                    objIGProfile.UserName = (string)User["username"];

                    objIGProfile.Name = (string)User["full_name"];

                    objIGProfile.profile_picture = (string)User["profile_picture"];
                }



            }

            return objIGProfile;
        }

    }



    public class Data
    {
        public string media_id { get; set; }
    }

    public class MediaPostedDetails
    {
        public string changed_aspect { get; set; }
        public string @object { get; set; }
        public string object_id { get; set; }
        public int time { get; set; }
        public int subscription_id { get; set; }
        public Data data { get; set; }
    }

    public class MediaDetails
    {
        public string link { get; set; }
        public int likecount { get; set; }
        public string username { get; set; }
    }


    #region IGProfile
    public struct IGProfile
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string profile_picture { get; set; }


        public string AccessToken { get; set; }






    }
    #endregion
}