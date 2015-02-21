using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

namespace Social_Media_Service_Panel.Helper
{
    public class PinterestDetails
    {
        //SoftBucketHttpUtility httpHelper = new SoftBucketHttpUtility();

        public static string GetNumberOfFollow(string URL)
        {
            //string html = httpHelper.GetPageSource(URL, string.Empty, string.Empty);
            WebRequest request = WebRequest.Create(URL);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            StreamReader sr = new StreamReader(data);
            string html = sr.ReadToEnd();
            int first = html.IndexOf("\"followersFollowingLinks\">");
            int Second = html.IndexOf("</li>", first);
            string value = html.Substring(first, Second - first);
            int firstPoint = value.IndexOf("=\"buttonText\">");
            int SecondPoint = value.IndexOf("</span>", firstPoint);
            string follow = value.Substring(firstPoint, SecondPoint - firstPoint).Replace("=\"buttonText\">", string.Empty).Replace("\n", string.Empty).Replace("Followers    \n    ", string.Empty).Trim().Replace("Followers", "");
            return follow;
        }

        public static string GetNumberOfPin(string URL)
        {
            //string html = httpHelper.GetPageSource(URL, string.Empty, string.Empty);
            WebRequest request = WebRequest.Create(URL);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            StreamReader sr = new StreamReader(data);
            string html = sr.ReadToEnd();
            int first = html.IndexOf("userStats\">");
            int Second = html.IndexOf("</div>", first);
            string value = html.Substring(first, Second - first);
            int firstPoint = value.IndexOf(" <div class=\"");
            int SecondPoint = value.IndexOf("Pins", firstPoint);
            string Pin = value.Substring(firstPoint, SecondPoint - firstPoint).Replace("<div class=\"PinCount Module\" id=\"PinCount-24\">","").Replace("\n","").Trim();
            return Pin;
        }

        public static string GetNumberOfBoard(string URL)
        {
            WebRequest request = WebRequest.Create(URL);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            StreamReader sr = new StreamReader(data);
            string html = sr.ReadToEnd();

            string Board = SoftBucketHttpUtility.ParseJson(html, "followers/\" >", "Followers").Replace("\"", "").Trim();
            //int first = html.IndexOf("userStats\">");
            //int Second = html.IndexOf("</div>", first);
            //string value = html.Substring(first, Second - first);
            //int firstPoint = value.IndexOf("<span class=\"buttonText\">");
            //int SecondPoint = value.IndexOf("Boards", firstPoint);
            //string Board = value.Substring(firstPoint, SecondPoint - firstPoint).Replace("<span class=\"buttonText\">", string.Empty).Replace("\n", string.Empty).Trim();
            return Board;
        }

        public static string GetNumberOfLikes(string URL)
        {
           // string html = httpHelper.GetPageSource(URL, string.Empty, string.Empty);
            WebRequest request = WebRequest.Create(URL);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            StreamReader sr = new StreamReader(data);
            string html = sr.ReadToEnd();
            int first = html.IndexOf("userStats\">");
            int Second = html.IndexOf("</ul>", first);
            string value = html.Substring(first, Second - first);
            int firstPoint = value.IndexOf("/likes/\">");
          //  int firstPoint = value.IndexOf("<a href=\" / liveyourspace / likes / \">");
            int SecondPoint = value.IndexOf("Likes", firstPoint);
            string Like = value.Substring(firstPoint, SecondPoint - firstPoint).Replace("/likes/\">",string.Empty).Replace("\n", string.Empty).Trim();
            return Like;
        }
    }
}