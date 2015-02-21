using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialPanel.Model;

namespace Social_Media_Service_Panel.Helper
{
    public class TotalAmount
    {
        DataClassesDataContext Dbcontext = new DataClassesDataContext();

        //public static int PinterestTotalAmount(string OrderType)
        //{
        //    DataClassesDataContext Dbcontext = new DataClassesDataContext();
        //    return Dbcontext.tblPinterestOrderDetails.Where(pin => pin.TypeOfAccount == OrderType).Sum(s => s.AmountOfLikes);
        //}
        //public static int InstagramTotalAmount(string OrderType)
        //{
        //    DataClassesDataContext Dbcontext = new DataClassesDataContext();
        //    return Dbcontext.tblInstagramOrderDetails.Where(insta => insta.OrderType == OrderType).Sum(s => s.AmountOfFlowersAndLike);
        //}
        //public static int keekTotalAmount(string OrderType)
        //{
        //    DataClassesDataContext Dbcontext = new DataClassesDataContext();
        //    return Dbcontext.tblKeekOrderDetails.Where(keek => keek.OrderType == OrderType).Sum(s => s.Amount);
        //}
        //public static int twitterTotalAmount(string OrderType)
        //{
        //    DataClassesDataContext Dbcontext = new DataClassesDataContext();
        //    return Dbcontext.tblTwitterOrderDetails.Where(twit => twit.OrderType == OrderType).Sum(s => s.Amount);
        //}
        //public static int facebookTotalAmount(string OrderType)
        //{
        //    DataClassesDataContext Dbcontext = new DataClassesDataContext();
        //    return Dbcontext.tblFacebookOrderDetails.Where(face => face.OrderType == OrderType).Sum(s => s.Amount);
        //}
    }
}