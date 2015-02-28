using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using SocialPanel.Helper;
using Social_Media_Service_Panel.ForImage.Helper;

namespace Social_Media_Service_Panel.Helper
{
    public class InstagramDetails
    {
        SoftBucketHttpUtility httpHelper = new SoftBucketHttpUtility();

        public InstagramUser GetInstgramUserByUserName(string Username)
        {
            if (!Username.Contains("https://instagram.com/"))
            {
                Username = "https://instagram.com/" + Username;
            }

            string UserPageSource = httpHelper.GetPageSource(new Uri(Username), string.Empty, string.Empty);
            UserPageSource = SoftBucketHttpUtility.ParseJsonForUserId(UserPageSource, "window._sharedData", "</script>").Trim(';').Trim('=').Trim();
            InstagramUser instaUser = JsonParser.GetInstagramUser(UserPageSource);
            return instaUser;
        }

        public InstagramImageResult GetInstagramImageIdByUrl(string ImageUrl)
        {
            if (!ImageUrl.Contains("https://instagram.com/"))
            {
                ImageUrl = "https://instagram.com/p/" + ImageUrl + "/";
            }

            string ImagePageSource = httpHelper.GetPageSource(new Uri(ImageUrl), string.Empty, string.Empty);
            ImagePageSource = SoftBucketHttpUtility.ParseJsonForUserId(ImagePageSource, "window._sharedData", "</script>").Trim(';').Trim('=').Trim();
            InstagramImageResult instaImgResult = JsonParser.GetImageResult(ImagePageSource);
            return instaImgResult;
        }

        public static int GetNumberOfFollow(string URL)
        {
            try
            {
                //string html = httpHelper.GetPageSource(URL, string.Empty, string.Empty);
                WebRequest request = WebRequest.Create(URL);
                WebResponse response = request.GetResponse();
                Stream data = response.GetResponseStream();
                StreamReader sr = new StreamReader(data);
                string html = sr.ReadToEnd();
                int firstPoint = html.IndexOf("followed_by");
                int SecondPoint = html.IndexOf(",", firstPoint);
                string follow = html.Substring(firstPoint, SecondPoint - firstPoint).Replace("followed_by", string.Empty).Replace(":", string.Empty).Replace("\"", string.Empty).Trim();
                return int.Parse(follow);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int GetNumberOfLikes(string URL)
        {
            try
            {
                // string html = httpHelper.GetPageSource(URL, string.Empty, string.Empty);
                WebRequest request = WebRequest.Create(URL);
                WebResponse response = request.GetResponse();
                Stream data = response.GetResponseStream();
                StreamReader sr = new StreamReader(data);
                string html = sr.ReadToEnd();
                int firstPoint = html.IndexOf("likes\":{");
                int SecondPoint = html.IndexOf(",", firstPoint);
                string Like = html.Substring(firstPoint, SecondPoint - firstPoint).Replace("likes", string.Empty).Replace(":", string.Empty).Replace("{", string.Empty).Replace("count", string.Empty).Replace(":", string.Empty).Replace("\"", string.Empty).Replace("\"", string.Empty).Replace("\"", string.Empty).Trim();
                return int.Parse(Like);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}