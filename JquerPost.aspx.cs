using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialPanel.Model;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Social_Media_Service_Panel
{
    public partial class JquerPost : System.Web.UI.Page
    {

        [WebMethod]
        public static object ViewPlans()
        {
            PlanRepository plan = new PlanRepository();
            var tblPlanDetails = plan.GetPlans();
            return tblPlanDetails;
        }

        [WebMethod]
        public static object GetOrdersForAdmin()
        {
            OrderRepository orderRepo = new OrderRepository();
            var tblOrderDetails = orderRepo.GetOrders();
            return tblOrderDetails;
        }

        [WebMethod]
        public static object GetCompletedLikeOrdersForAdmin()
        {
            OrderRepository orderRepo = new OrderRepository();
            var tblOrderDetails = orderRepo.GetCompletedOrders("Like");
            return tblOrderDetails;
        }
        [WebMethod]
        public static object GetNonCompletedLikeOrdersForAdmin()
        {
            OrderRepository orderRepo = new OrderRepository();
            var tblOrderDetails = orderRepo.GetNonCompletedOrders("Like");
            return tblOrderDetails;
        }

       

        [WebMethod]
        public static object GetCompletedFollowOrdersForAdmin()
        {
            OrderRepository orderRepo = new OrderRepository();
            var tblOrderDetails = orderRepo.GetCompletedOrders("Follow");
            return tblOrderDetails;
        }

        [WebMethod]
        public static object GetNonCompletedFollowOrdersForAdmin()
        {
            OrderRepository orderRepo = new OrderRepository();
            var tblOrderDetails = orderRepo.GetNonCompletedOrders("Follow");
            return tblOrderDetails;
        }

       

        public IQueryable<tblOrder> GetCompletedOrders()
        {
            DataClassesDataContext DbContext = new DataClassesDataContext();
            var tblOrderDetails = DbContext.tblOrders.Where(O => O.OrderStatus == "Completed");
            return tblOrderDetails.OrderByDescending(O => O.OrderId);
        }

        //public IQueryable<tblOrder> GetCompletedOrders(string FeatureType)
        //{
        //    DataClassesDataContext DbContext = new DataClassesDataContext();
        //    var tblOrderDetails = DbContext.tblOrders.Where(O => O.OrderStatus == "Completed" && O.FeatureType == FeatureType);
        //    return tblOrderDetails.OrderByDescending(O => O.OrderId);
        //}
        //public IQueryable<tblOrder> GetNonCompletedOrders(string FeatureType)
        //{
        //    DataClassesDataContext DbContext = new DataClassesDataContext();
        //    var tblOrderDetails = DbContext.tblOrders.Where(O => O.OrderStatus != "Completed" && O.FeatureType == FeatureType);
        //    return tblOrderDetails.OrderByDescending(O => O.OrderId);
        //}

        //public IQueryable<tblOrder> GetOrders(string ClientUserName)
        //{
        //    DataClassesDataContext DbContext = new DataClassesDataContext();
        //    var tblOrderDetails = DbContext.tblOrders.Where(O => O.ClientUserName == ClientUserName);
        //    return tblOrderDetails.OrderByDescending(O => O.OrderId);
        //}

        [WebMethod]
        public static object GetAutoLikeCompletedOrdersForAdmin()
        {
            OrderRepository orderRepo = new OrderRepository();
            var tblOrderDetails = orderRepo.GetCompletedOrders("Like");
            return tblOrderDetails;
        }

        [WebMethod]
        public static object GetAutoLikeNonCompletedOrdersForAdmin()
        {
            OrderRepository orderRepo = new OrderRepository();
            var tblOrderDetails = orderRepo.GetNonCompletedOrders("Like");
            return tblOrderDetails;
        }

        //[WebMethod]
        //public static object GetOrdersForUser()
        //{
        //    OrderRepository orderRepo = new OrderRepository();
        //    var tblOrderDetails = orderRepo.GetOrders(HttpContext.Current.User.Identity.Name);
        //    return tblOrderDetails;
        //}

        //[WebMethod]
        //public static object GetNormalCompletedOrdersForUser()
        //{
        //    OrderRepository orderRepo = new OrderRepository();
        //    var tblOrderDetails = orderRepo.GetCompletedOrders(HttpContext.Current.User.Identity.Name,"Normal");
        //    return tblOrderDetails;
        //}

        //[WebMethod]
        //public static object GetNormalNonCompletedOrdersForUser()
        //{
        //    OrderRepository orderRepo = new OrderRepository();
        //    var tblOrderDetails = orderRepo.GetNonCompletedOrders(HttpContext.Current.User.Identity.Name,"Normal");
        //    return tblOrderDetails;
        //}

        //[WebMethod]
        //public static object GetAutoLikeCompletedOrdersForUser()
        //{
        //    OrderRepository orderRepo = new OrderRepository();
        //    var tblOrderDetails = orderRepo.GetCompletedOrders(HttpContext.Current.User.Identity.Name,"AutoLike");
        //    return tblOrderDetails;
        //}

        ////[WebMethod]
        ////public static object GetAutoLikeNonCompletedOrdersForUser()
        ////{
        ////    OrderRepository orderRepo = new OrderRepository();
        ////    var tblOrderDetails = orderRepo.GetNonCompletedOrders(HttpContext.Current.User.Identity.Name, "AutoLike");
        ////    return tblOrderDetails;
        ////}

        ////[WebMethod]
        ////public static object GetAllUsers()
        ////{
        ////    MembershipUserCollection MUC = Membership.GetAllUsers();
        ////    return MUC;
        ////}

        [WebMethod]
        public static string DeleteOrder(object Id)
        {
            int tempId = (int)Id;
            OrderRepository orderRepo = new OrderRepository();
            orderRepo.DeleteOrder(tempId);
            return "Deleted";
        }

        ////[WebMethod]
        ////public static object GetAccounts()
        ////{
        ////    SocialAccountRepository socialRepo = new SocialAccountRepository();
        ////    var tblSocialAccountDetails = socialRepo.GetAccounts();
        ////    return tblSocialAccountDetails;
        ////}

        [WebMethod]
        public static object GetTokens()
        {
            AddTokenRepository usertoken = new AddTokenRepository();
            var tbladdtoken = usertoken.selectaccounts();
            return tbladdtoken;
        }

        [WebMethod]

        public static void DeleteUser(string Id)
        {
            AddTokenRepository deleteaccount = new AddTokenRepository();
            deleteaccount.deleteuser(Id);
             

        }

        //[WebMethod]
        //public static object GetFacebookOrdersForAdmin()
        //{
        //    FacebookRepository Facebook = new FacebookRepository();
        //    var tblFacebookOrderDetail = Facebook.GetFacebookOrders();
        //    // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return tblFacebookOrderDetail;
        //}

        //[WebMethod]
        //public static object GetPinterestOrdersForAdmin()
        //{
        //    PintrestRepository Pinterest = new PintrestRepository();
        //    var Pin = Pinterest.GetPinterestOrders();
        //    // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return Pin;
        //}

        //[WebMethod]
        //public static object GetInstagramOrdersForAdmin()
        //{
        //    InstagramRepository Instagram = new InstagramRepository();
        //    //JavaScriptSerializer js = new JavaScriptSerializer();
        //    var IG = Instagram.GetInstagramOrders();
        //    return IG;
        //}

        //[WebMethod]
        //public static object GetKeekOrdersForAdmin()
        //{
        //    KeekRepositry Keek = new KeekRepositry();
        //    var KK = Keek.GetKeekOrders();
        //    // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return KK;
        //}

        //[WebMethod]
        //public static object GetTwitterOrdersForAdmin()
        //{
        //    TwitterRepository Twitter = new TwitterRepository();
        //    var Twt = Twitter.GetTwitterOrders();
        //    // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return Twt;
        //}


        //[WebMethod]
        //public static object GetYouTubeOrdersForAdmin()
        //{
        //    YouTubeRepository YouTube = new YouTubeRepository();
        //    var tblYouTubeOrderDetail = YouTube.GetYouTubeOrders();
        //    // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return tblYouTubeOrderDetail;
        //}


        //[WebMethod]
        //public static string DeleteTwitterDetailForAdmin(object Id)
        //{
        //    int tempId = (int)Id;
        //    TwitterRepository Twitter = new TwitterRepository();
        //    Twitter.DeleteTwitterDetail(tempId);
        //    return "Deleted";
        //}

        //[WebMethod]
        //public static string DeleteFacebookDetailForAdmin(string Id)
        //{
        //    int tempId = int.Parse(Id);
        //    FacebookRepository Facebook = new FacebookRepository();
        //    Facebook.DeleteFacebookDetail(tempId);
        //    return "Deleted";
        //}

        //[WebMethod]
        //public static string DeleteFacebookDetailForAdmin()
        //{

        //    return "Deleted";
        //}

        //[WebMethod]
        //public static string DeleteKeekDetailForAdmin(object Id)
        //{
        //    int tempId = (int)Id;
        //    KeekRepositry Keek = new KeekRepositry();
        //    Keek.DeleteKeekDetail(tempId);
        //    return "Deleted";
        //}

        //[WebMethod]
        //public static string DeleteInstagramDetailForAdmin(object Id)
        //{
        //    int tempId = (int)Id;
        //    InstagramRepository Instagram = new InstagramRepository();
        //    Instagram.DeleteInstagramDetail(tempId);
        //    return "Deleted";
        //}

       

        //[WebMethod]
        //public static string DeletePinterestDetailForAdmin(object Id)
        //{
        //    int tempId = (int)Id;
        //    PintrestRepository Pinterest = new PintrestRepository();
        //    Pinterest.DeletePinterestDetail(tempId);
        //    return "Deleted";
        //}

        //[WebMethod]
        //public static string DeleteYouTubeDetailForAdmin(object Id)
        //{
        //    int tempId = (int)Id;
        //    YouTubeRepository YouTube = new YouTubeRepository();
        //    YouTube.DeletetblYouTubeOrderDetails(tempId);
        //    return "Deleted";
        //}

        //[WebMethod]
        //public static object GetFacebookOrdersForUser()
        //{
        //    FacebookRepository Facebook = new FacebookRepository();
        //    var fb = Facebook.GetFacebookOrders(HttpContext.Current.User.Identity.Name);
        //    return fb;
            
        //}

        //[WebMethod]
        //public static object GetPinterestOrdersForUser()
        //{
        //    PintrestRepository Pinterest = new PintrestRepository();
        //    var Pin = Pinterest.GetPinterestOrders(HttpContext.Current.User.Identity.Name);
        //   // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return Pin;
        //}

        //[WebMethod]
        //public static object GetInstagramOrdersForUser()
        //{
        //    InstagramRepository Instagram = new InstagramRepository();
        //   //JavaScriptSerializer js = new JavaScriptSerializer();
        //    var IG = Instagram.GetInstagramOrders(HttpContext.Current.User.Identity.Name);
        //   return IG;
        //}

        //[WebMethod]
        //public static object GetKeekOrdersForUser()
        //{
        //    KeekRepositry Keek = new KeekRepositry();
        //    var KK = Keek.GetKeekOrders(HttpContext.Current.User.Identity.Name);
        //   // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return KK;
        //}

        //[WebMethod]
        //public static object GetTwitterOrdersForUser()
        //{
        //    TwitterRepository Twitter = new TwitterRepository();
        //    var Twt = Twitter.GetTwitterOrders(HttpContext.Current.User.Identity.Name);
        //   // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return Twt;
        //}

        //[WebMethod]
        //public static object GetPaymentRecordDetailsForUser()
        //{
        //    PaymentRepository Payment = new PaymentRepository();
        //    var Pay = Payment.GetPaymentRecords(HttpContext.Current.User.Identity.Name);
        //    // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return Pay;
        //}

        //[WebMethod]
        //public static object GetPaymentRecordDetailsForAdmin()
        //{
        //    PaymentRepository Payment = new PaymentRepository();
        //    var Pay = Payment.GetPaymentRecords();
        //    // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return Pay;
        //}

        //[WebMethod]
        //public static object GetPaymentDetailsForAdmin()
        //{
        //    PaymentRepository Payment = new PaymentRepository();
        //    var Pay = Payment.GetPaymentDetails();
        //    // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return Pay;
        //}

        //[WebMethod]
        //public static object GetPaymentDetailsForUser()
        //{
        //    PaymentRepository Payment = new PaymentRepository();
        //    var Pay = Payment.GetPaymentDetails(HttpContext.Current.User.Identity.Name);
        //    // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return Pay;
        //}


        //[WebMethod]
        //public static object GetOrderTypePriceDetailsForAdmin()
        //{
        //    OrderTypePriceRepository orderTypePrice = new OrderTypePriceRepository();
        //    var Pay = orderTypePrice.GetOrderTypePrice();
        //    return Pay;
        //}

        //[WebMethod]
        //public static object GetAutoLikeUsersForUser()
        //{
        //    AutoLikeRepository autoLikeUsers = new AutoLikeRepository();
        //    var Pay = autoLikeUsers.GetUsers(HttpContext.Current.User.Identity.Name);
        //    return Pay;
        //}

        //[WebMethod]
        //public static object GetAutoLikeUsersForAdmin()
        //{
        //    AutoLikeRepository autoLikeUsers = new AutoLikeRepository();
        //    var Pay = autoLikeUsers.GetUsers();
        //    return Pay;
        //}

        //[WebMethod]
        //public static object GetYouTubeForUser()
        //{
        //    YouTubeRepository YouTube = new YouTubeRepository();
        //    var YouTubeDetails = YouTube.GetYouTubeOrders(HttpContext.Current.User.Identity.Name);
        //    return YouTubeDetails;

        //}

        //[WebMethod]
        //public static object GetFacebookOrdersForEmployee()
        //{
        //    FacebookRepository Facebook = new FacebookRepository();
        //    var tblFacebookOrderDetail = Facebook.GetFacebookOrders();
        //   // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return tblFacebookOrderDetail;
        //}

        //[WebMethod]
        //public static object GetTwitterOrdersForEmployee()
        //{
        //    TwitterRepository Twitter = new TwitterRepository();
        //    var Twt = Twitter.GetTwitterOrders();
        //    // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return Twt;
        //}

        //[WebMethod]
        //public static object GetKeekOrdersForEmployee()
        //{
        //    KeekRepositry Keek = new KeekRepositry();
        //    var KK = Keek.GetKeekOrders();
        //    // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return KK;
        //}

        //[WebMethod]
        //public static object GetInstagramOrdersForEmployee()
        //{
        //    InstagramRepository Instagram = new InstagramRepository();
        //    //JavaScriptSerializer js = new JavaScriptSerializer();
        //    var IG = Instagram.GetInstagramOrdersEmployee();
        //    return IG;
        //}

        //[WebMethod]
        //public static object GetPinterestOrdersForEmployee()
        //{
        //    PintrestRepository Pinterest = new PintrestRepository();
        //    var Pin = Pinterest.GetPinterestOrders();
        //    // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return Pin;
        //}
        //[WebMethod]
        //public static object GetPaymentRecordsForAdmin()
        //{
        //    PaymentRepository Payment = new PaymentRepository();
        //    var Pay = Payment.tblPaymentRecords();
        //    // JavaScriptSerializer js = new JavaScriptSerializer();
        //    return Pay;
        //}

        //[WebMethod]
        //public static string GetData()
        //{
        //    return  "My Id Is" + 1;
        //}
       
    }
}