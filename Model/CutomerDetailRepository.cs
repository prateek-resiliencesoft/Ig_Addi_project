using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPanel.Model
{
    public class CutomerDetailRepository
    {
        DataClassesDataContext Dbcotext = new DataClassesDataContext();

        public bool CheckInstagramScreenNameExist(string instagramusername)
        {
            return Dbcotext.tbl_CutomerDetails.Where(e => e.InstagramUserName == instagramusername).Any();
        }

        public string GetSubscription(string customerid)
        {
            return Dbcotext.tbl_CutomerDetails.FirstOrDefault(e => e.CutomerId == customerid).subscriptionid;
        }

        public tbl_CutomerDetail GetIGUseDetail(string instagramUser)
        {
            return Dbcotext.tbl_CutomerDetails.First(A => A.InstagramUserName == instagramUser);
        }


        public void AddCutomerDetails(string cutomerid, string instagramusername, string planid, string subscriptionid)
        {
            tbl_CutomerDetail CutomerDetail = new tbl_CutomerDetail();

            CutomerDetail.CutomerId = cutomerid;
            CutomerDetail.InstagramUserName = instagramusername;
            CutomerDetail.Planid = planid;
            CutomerDetail.subscriptionid = subscriptionid;
            CutomerDetail.OrderDate = DateTime.Now.ToString();
            CutomerDetail.Status = "true";


            Dbcotext.tbl_CutomerDetails.InsertOnSubmit(CutomerDetail);
            Dbcotext.SubmitChanges();
        }


        public void UpdateCutomerDetails(string instagramusername, string planid, string customerid, string subscriptionid)
        {
            {
                tbl_CutomerDetail CutomerDetail = Dbcotext.tbl_CutomerDetails.First(O => O.InstagramUserName == instagramusername );
                CutomerDetail.Planid = planid;
                CutomerDetail.CutomerId = customerid;
                CutomerDetail.subscriptionid = subscriptionid;
                CutomerDetail.Status = "true";
                CutomerDetail.OrderDate = DateTime.Now.ToString();
                
                Dbcotext.SubmitChanges();
            }
        }

        public void UpdateStatus(string CutomerId, string status)
        {
            tbl_CutomerDetail CutomerDetail = Dbcotext.tbl_CutomerDetails.FirstOrDefault(O => O.CutomerId == CutomerId);
            CutomerDetail.Status = status;

            Dbcotext.SubmitChanges();
        }

    }
}