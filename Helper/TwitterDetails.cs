using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

namespace Social_Media_Service_Panel.Helper
{
    public class TwitterDetails
    {
        public static string GetNumberOfFollow(string URL)
        {
            //string html = httpHelper.GetPageSource(URL, string.Empty, string.Empty);
            WebRequest request = WebRequest.Create(URL);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            StreamReader sr = new StreamReader(data);
            string html = sr.ReadToEnd();

            string followData = SoftBucketHttpUtility.ParseJson(html, "follower_stats", "</strong>").Trim();

            string follow = SoftBucketHttpUtility.ParseJson(followData, "strong title=", "class=").Replace("\"",string.Empty).Trim();
            //int first = html.IndexOf("\"stats js-mini-profile-stats\"");
            //int Second = html.IndexOf("</ul>", first);
            //string value = html.Substring(first, Second - first);
            //int firstPoint = value.IndexOf("data-nav=\"followers\"");
            //int SecondPoint = value.IndexOf("</strong>", firstPoint);
            //string follow = value.Substring(firstPoint, SecondPoint - firstPoint).Replace("data-nav=\"followers\"", string.Empty).Replace("<strong>", string.Empty).Replace(">", string.Empty).Trim();
            return follow;
        }

        public static string GetNumberOfTweet(string URL)
        {
            //string html = httpHelper.GetPageSource(URL, string.Empty, string.Empty);
            WebRequest request = WebRequest.Create(URL);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            StreamReader sr = new StreamReader(data);
            string html = sr.ReadToEnd();

            string followData = SoftBucketHttpUtility.ParseJson(html, "tweet_stats", "</strong>").Trim();

            string follow = SoftBucketHttpUtility.ParseJson(followData, "strong title=", "class=").Replace("\"", string.Empty).Trim();
            //int first = html.IndexOf("\"stats js-mini-profile-stats\"");
            //int Second = html.IndexOf("</li>", first);
            //string value = html.Substring(first, Second - first);
            //int firstPoint = value.IndexOf("data-nav=\"profile\"");
            //int SecondPoint = value.IndexOf("</strong>", firstPoint);
            //string follow = value.Substring(firstPoint, SecondPoint - firstPoint).Replace("data-nav=\"profile\"", string.Empty).Replace("<strong>", string.Empty).Replace(">", string.Empty).Trim();
            return follow;
        }

        public static string GetNumberOfReTweet(string URL)
        {
            SoftBucketHttpUtility httpHelper = new SoftBucketHttpUtility();
            string html = httpHelper.GetPageSource(new Uri(URL), string.Empty, string.Empty);
            string follow = SoftBucketHttpUtility.ParseJson(html, "data-activity-popup-title=", "time").Replace("Retweeted","").Replace("\"","").Trim();
            return follow;
        }
    }
}