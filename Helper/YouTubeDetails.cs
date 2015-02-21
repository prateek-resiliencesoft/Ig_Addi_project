using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Social_Media_Service_Panel.Helper
{
    public class YouTubeDetails
    {
        public static string GetNumberOfsubscribe(string URL)
        {
            SoftBucketHttpUtility httphelper = new SoftBucketHttpUtility();
            string html = httphelper.GetPageSource(new Uri(URL), "", "");
            string[] data1 = Regex.Split(html, "<div class=\"primary-header-contents");
            string subscribe = SoftBucketHttpUtility.ParseJson(data1[1], "horizontal subscribed\" >", "</span>").Replace("\"","").Trim();
            return subscribe;
        }
    }
}