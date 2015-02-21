using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

namespace Social_Media_Service_Panel.Helper
{
    public class KeekDetails
    {
        public static string GetNumberOfKeek(string URL)
        {
            //string html = httpHelper.GetPageSource(URL, string.Empty, string.Empty);
            WebRequest request = WebRequest.Create(URL);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            StreamReader sr = new StreamReader(data);
            string html = sr.ReadToEnd();
            int firstPoint = html.IndexOf("\" user-statinfo-disable\">");
            int SecondPoint = html.IndexOf("</li>", firstPoint);
            string value = html.Substring(firstPoint, SecondPoint - firstPoint);
            int first = value.IndexOf("<span>Keeks:");
            int Second = value.IndexOf("</a>", first);
            string Keeks = value.Substring(first, Second - first).Replace("<span>", string.Empty).Replace("Keeks:", string.Empty).Replace("</span>", string.Empty).Trim();
            return Keeks;
        }

        public static string GetNumberOfLikes(string URL)
        {
            //string html = httpHelper.GetPageSource(URL, string.Empty, string.Empty);
            WebRequest request = WebRequest.Create(URL);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            StreamReader sr = new StreamReader(data);
            string html = sr.ReadToEnd();
            int firstPoint = html.IndexOf("Likes:");
            int SecondPoint = html.IndexOf("</a>", firstPoint);
            string value = html.Substring(firstPoint, SecondPoint - firstPoint).Replace("Likes:", string.Empty).Replace("</span>", string.Empty).Trim(); 
            int first = value.IndexOf(">");
            int Second = value.IndexOf("</div>", first);
            string Likes = value.Substring(first, Second - first).Replace(">", string.Empty);
            return Likes;
        }

        public static string GetNumberOfFollowers(string URL)
        {
            //string html = httpHelper.GetPageSource(URL, string.Empty, string.Empty);
            WebRequest request = WebRequest.Create(URL);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            StreamReader sr = new StreamReader(data);
            string html = sr.ReadToEnd();
            int firstPoint = html.IndexOf("Followers:");
            int SecondPoint = html.IndexOf("</a>", firstPoint);
            string value = html.Substring(firstPoint, SecondPoint - firstPoint).Replace("Likes:", string.Empty).Replace("</span>", string.Empty).Trim();
            int first = value.IndexOf(">");
            int Second = value.IndexOf("</div>", first);
            string Followers = value.Substring(first, Second - first).Replace(">", string.Empty);
            return Followers;
        }

        public static string GetNumberOfSubscribers(string URL)
        {
            //string html = httpHelper.GetPageSource(URL, string.Empty, string.Empty);
            WebRequest request = WebRequest.Create(URL);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            StreamReader sr = new StreamReader(data);
            string html = sr.ReadToEnd();
            int firstPoint = html.IndexOf("Subscribers:");
            int SecondPoint = html.IndexOf("</a>", firstPoint);
            string value = html.Substring(firstPoint, SecondPoint - firstPoint).Replace("Likes:", string.Empty).Replace("</span>", string.Empty).Trim();
            int first = value.IndexOf(">");
            int Second = value.IndexOf("</div>", first);
            string Subscribers = value.Substring(first, Second - first).Replace(">", string.Empty);
            return Subscribers;
        }
    }
}