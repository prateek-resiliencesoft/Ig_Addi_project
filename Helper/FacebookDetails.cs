using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Social_Media_Service_Panel.Helper
{
    public class FacebookDetails
    {
        public static string GetNumberOfPictureLike(string URL)
        {

            SoftBucketHttpUtility httpHelper = new SoftBucketHttpUtility();
            string html = httpHelper.GetPageSource(new Uri(URL), string.Empty, string.Empty);
            //int firstPoint = html.IndexOf("<meta name=\"description\"");
            int firstPoint = html.IndexOf("\"fbPhotoPageFeedback\"");
           // int firstPoint = html.IndexOf("<table class=\"uiGrid _51mz fbPhotoPageInfo\">");
            int SecondPoint = html.IndexOf("people", firstPoint);
            string value = html.Substring(firstPoint, SecondPoint - firstPoint);
            int FirstPoint = value.IndexOf("\"UFILikeSentenceText\"");
            int secondPoint = value.IndexOf("People", FirstPoint);
            string PictureLike = value.Substring(FirstPoint, secondPoint - FirstPoint).Replace("\"UFILikeSentenceText\"", string.Empty).Trim();
            return PictureLike;
        }

        public static string GetNumberOfPostLike(string URL)
        {
            SoftBucketHttpUtility httpHelper = new SoftBucketHttpUtility();
            string html = httpHelper.GetPageSource(new Uri(URL), string.Empty, string.Empty);
            int firstPoint = html.IndexOf("\"fbTimelineFeedbackActions clearfix\">");
            int SecondPoint = html.IndexOf("</div>", firstPoint);
            string value = html.Substring(firstPoint, SecondPoint - firstPoint);
            int FirstPoint = value.IndexOf("\"UFILikeSentenceText\"");
            int secondPoint = value.IndexOf("People", FirstPoint);
            string PostLike = value.Substring(FirstPoint, secondPoint - FirstPoint).Replace("\"UFILikeSentenceText\"", string.Empty).Trim();
            return PostLike;
        }
       

        public static string GetNumberOfPageLike(string URL)
        {
            SoftBucketHttpUtility httpHelper = new SoftBucketHttpUtility();
            string html = httpHelper.GetPageSource(new Uri(URL), string.Empty, string.Empty);
            int firstPoint = html.IndexOf("\"name\"");
            int SecondPoint = html.IndexOf("</h2>", firstPoint);
            string value = html.Substring(firstPoint, SecondPoint - firstPoint);
            int FirstPoint = value.IndexOf("\"fsm fwn fcg\">");
            int secondPoint = value.IndexOf("likes", FirstPoint);
            string PageLike = value.Substring(FirstPoint, secondPoint - FirstPoint).Replace("\"fsm fwn fcg\">", string.Empty).Replace("<div class=", string.Empty);
            return PageLike;
        }
    }
}