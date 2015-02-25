using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPanel.Model
{
    public class Order_Types
    {
        public static Dictionary<int, string> AcountType = new Dictionary<int, string>();
        public static Dictionary<int, string> LoginAcountStatus = new Dictionary<int, string>();

        public static Dictionary<int, string> twitterType = new Dictionary<int, string>();
        public static Dictionary<int, string> FacebookType = new Dictionary<int, string>();
        public static Dictionary<int, string> KeekType = new Dictionary<int, string>();
        public static Dictionary<int, string> InstgramType = new Dictionary<int, string>();
        public static Dictionary<int, string> StatusForAdmin = new Dictionary<int, string>();
        public static Dictionary<int, string> UserAmountStatus = new Dictionary<int, string>();
        public static Dictionary<int, string> ManuallyAndAutomatically = new Dictionary<int, string>();
        public static Dictionary<int, string> SocialAccount = new Dictionary<int, string>();
        public static Dictionary<int, string> StatusForInstagram = new Dictionary<int, string>();
        public static Dictionary<int, string> VineType = new Dictionary<int, string>();
        public static Dictionary<int, string> YouTubeType = new Dictionary<int, string>();
        public static Dictionary<int, string> SoundCloudType = new Dictionary<int, string>();
        public static Dictionary<int, string> StatusForYouTube = new Dictionary<int, string>();

        public static Dictionary<int, string> OrderTypes = new Dictionary<int, string>();

        public  List<string> UserType = new List<string>();
        //public  List<string> Status = new List<string>();


        public static void GetLoginAccountStatus()
        {
            try
            {
                LoginAcountStatus.Add(1, "Working");
                LoginAcountStatus.Add(2, "Failed");
                LoginAcountStatus.Add(3, "Captcha");
            }
            catch (Exception ex)
            {

            }
        }

        public static void GetOrderTypes()
        {
            try
            {
                //OrderTypes.Add(1, "Extreme Instagram Followers");
                //OrderTypes.Add(2, "Extreme Instagram Likes");
                //OrderTypes.Add(3, "Regular Instagram Followers");
                //OrderTypes.Add(4, "Regular Instagram Likes");

                OrderTypes.Add(1, "Follow");
                OrderTypes.Add(2, "Like");
            }
            catch (Exception ex)
            {

            }
        }

        public static void  GetAccountType()
        {
            try
            {
                AcountType.Add(1, "Extreme Instagram");
                AcountType.Add(2, "Regular Instagram");
            }
            catch (Exception ex)
            {

            }
        }
        
        //public static void GettwitterType()
        //{
        //    try
        //    {
        //        twitterType.Add(1, "Follow");
        //        twitterType.Add(2, "Tweet");
        //        twitterType.Add(3, "ReTweet");
        //        twitterType.Add(4, "All");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //public static void GetInstgramType()
        //{
        //    try
        //    {
        //        InstgramType.Add(1, "Follow");
        //        InstgramType.Add(2, "Like");
        //        InstgramType.Add(3, "All");
        //        InstgramType.Add(4, "Comment");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //public static void GetFacebookType()
        //{
        //    try
        //    {
        //        FacebookType.Add(1, "PageLike");
        //        FacebookType.Add(2, "Comment Like");
        //        FacebookType.Add(3, "Picture Like");
        //        FacebookType.Add(4, "Post Like");
        //        FacebookType.Add(5, "All");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //public static void GetKeekType()
        //{
        //    try
        //    {
        //        KeekType.Add(1, "Follow");
        //        KeekType.Add(2, "Like");
        //        KeekType.Add(3, "Subscribe");
        //        KeekType.Add(4, "Keek");
        //        KeekType.Add(5, "All");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //public List<string> GetUserType()
        //{
        //    try
        //    {
        //        UserType.Add("Admin");
        //        UserType.Add("User");
        //        UserType.Add("Employee");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return UserType;
        //}

        //public List<string> GetStatus()
        ////{
        ////    try
        ////    {
        ////        Status.Add( "Pending");
        ////        Status.Add( "Processing");
        ////        Status.Add("Completed");
        ////    }
        ////    catch (Exception ex)
        ////    {

        ////    }

        //    return Status;
        //}

        public static void GetStatusForAdmin()
        {
            try
            {
                StatusForAdmin.Add(1, "Pending");
                StatusForAdmin.Add(2, "Processing");
                StatusForAdmin.Add(3, "Remaining");
                StatusForAdmin.Add(4, "Completed");
                StatusForAdmin.Add(5, "Private");
                StatusForAdmin.Add(6, "PageNotFound");
                StatusForAdmin.Add(7, "WrongType");

            }
            catch (Exception ex)
            {

            }
        }

        public static void GetUserAmountStatus()
        {
            try
            {
                UserAmountStatus.Add(1, "Pending");
                UserAmountStatus.Add(2, "True");
                UserAmountStatus.Add(3, "false");
            }
            catch (Exception ex)
            {

            }
        }

        public static void GetManuallyAndAutomatically()
        {
            try
            {
                ManuallyAndAutomatically.Add(1, "Manually");
                ManuallyAndAutomatically.Add(2, "Automatically");
            }
            catch (Exception ex)
            {

            }
        }

        //public static void GetSocialAccount()
        //{
        //    try
        //    {
        //        SocialAccount.Add(1, "Facebook");
        //        SocialAccount.Add(2, "Instagram");
        //        SocialAccount.Add(3, "Keek");
        //        SocialAccount.Add(4, "Pinterest");
        //        SocialAccount.Add(5, "Twitter");
        //        SocialAccount.Add(6, "All");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //public static void GetStatusForInstagram()
        //{
        //    try
        //    {
        //        StatusForInstagram.Add(1, "Pending");
        //        StatusForInstagram.Add(2, "Processing");
        //        StatusForInstagram.Add(3, "Completed");
        //        StatusForInstagram.Add(4, "Blocked");
        //        StatusForInstagram.Add(5, "Private");
        //        StatusForInstagram.Add(6, "All");
        //        StatusForInstagram.Add(7, "Page Not Found");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //public static void GetVineType()
        //{
        //    try
        //    {
        //        VineType.Add(1, "Follow");
        //        VineType.Add(2, "All");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //public static void GetSoundCloudType()
        //{
        //    try
        //    {
        //        SoundCloudType.Add(1, "Follow");
        //        SoundCloudType.Add(2, "All");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //public static void GetYouTubeType()
        //{
        //    try
        //    {
        //        YouTubeType.Add(1, "Like");
        //        YouTubeType.Add(2, "View");
        //        YouTubeType.Add(3, "All");
        //        YouTubeType.Add(4, "Subscribe");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //public static void GetStatusForYouTube()
        //{
        //    try
        //    {
        //        StatusForYouTube.Add(1, "Pending");
        //        StatusForYouTube.Add(2, "Processing");
        //        StatusForYouTube.Add(3, "Completed");
        //        StatusForYouTube.Add(4, "Blocked By YouTube");
        //        StatusForYouTube.Add(5, "Page Not Found");
        //        StatusForYouTube.Add(6, "All");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}