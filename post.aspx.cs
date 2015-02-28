using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialPanel.Helper;
using Social_Media_Service_Panel.Helper;
using SocialPanel.Model;

namespace SocialPanel
{
    public partial class post : System.Web.UI.Page
    {
        AddTokenRepository autoLikeRepo = new AddTokenRepository();
        OrderRepository orderRepo = new OrderRepository();
        PlanRepository plan = new PlanRepository();
        CutomerDetailRepository objCutomerDetailRepository = new CutomerDetailRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
           


            if (Request.QueryString["hub.challenge"] != null)
            {
                Response.Write(Request.QueryString["hub.challenge"].ToString());
            }
            else
            {
                try
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
                    string NewImagePostedSource = sr.ReadToEnd();

                    //NewImagePostedSource = "[{\"changed_aspect\": \"media\", \"object\": \"user\", \"object_id\": \"966258514\", \"time\": 1411378957, \"subscription_id\": 12866014, \"data\": {\"media_id\": \"815028228719046648_966258514\"}}]";

                    List<MediaPostedDetails> lstMediaPostedDetails = JsonParser.GetMediaId(NewImagePostedSource);

                    foreach (MediaPostedDetails item in lstMediaPostedDetails)
                    {
                        try
                        {
                            string media_id = item.data.media_id;

                            SoftBucketHttpUtility httpHelper = new SoftBucketHttpUtility();

                            string mediaUrl = "https://api.instagram.com/v1/media/" + media_id + "?client_id=d699b2681e2644479f4b97b76b2bda33";
                            string MediaPageSource = httpHelper.GetPageSource(new Uri(mediaUrl), string.Empty, string.Empty);

                            MediaDetails md = JsonParser.GetMediaValue(MediaPageSource);


                            tblAccesstoken tblLikeUser = autoLikeRepo.GetUser(md.username);
                           tbl_CutomerDetail objtbl_CutomerDetail= objCutomerDetailRepository.GetIGUseDetail(md.username);
                           if (tblLikeUser != null && objtbl_CutomerDetail!=null)
                            {
                                bool IsUrlExist = orderRepo.IsUrlExist(md.link);

                                if (!IsUrlExist)
                                {

                                    tblPlan planData = plan.GetPlan(objtbl_CutomerDetail.Planid);
                                    int TodayCount = orderRepo.GetTodayOrdersCount();

                                    if (TodayCount < planData.MaxPhotos)
                                    {
                                        Random rnd = new Random();
                                        int Num = int.Parse(planData.LikeAmount.ToString()); //rnd.Next(int.Parse(tblLikeUser.MinCount.ToString()), int.Parse(tblLikeUser.MaxCount.ToString()));

                                        string OrderNumber = Guid.NewGuid().ToString();
                                        int EndPoint = md.likecount + Num;
                                        //orderRepo.AddOrder("Extreme Instagram Likes", OrderNumber, md.link, Num, tblLikeUser.UserName, DateTime.Now, md.likecount, EndPoint, 0, "Pending", DateTime.Now, 0, "Like");

                                        orderRepo.AddOrder(OrderNumber, md.link, Num,
                                                   DateTime.Now, 0, EndPoint, 0, "Pending", DateTime.Now, "Like", md.username);
                                    }

                                    //orderRepo.AddOrder(OrderNumber, md.link, Num,
                                    //              DateTime.Now, 0, EndPoint, 0, "Pending", DateTime.Now, "Like", md.username);
                                }
                            }

                        }
                        catch (Exception ex)
                        {

                        }
                    }

                }
                catch (Exception ex)
                {

                }
            }

        }
    }
}