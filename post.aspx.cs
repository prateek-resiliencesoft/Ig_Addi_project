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
                    Dictionary<string,MediaPostedDetails> newlstMediaPostedDetails = new  Dictionary<string,MediaPostedDetails>();

                   
                    foreach (MediaPostedDetails item in lstMediaPostedDetails)
                    {
                        try
                        {
                            string media_id = item.data.media_id;

                            SoftBucketHttpUtility httpHelper = new SoftBucketHttpUtility();

                            string mediaUrl = "https://api.instagram.com/v1/media/" + media_id + "?client_id=d699b2681e2644479f4b97b76b2bda33";
                            string MediaPageSource = httpHelper.GetPageSource(new Uri(mediaUrl), string.Empty, string.Empty);

                            FileHelper.AppendStringToTextfileNewLine("Media Id Data Found : " + media_id, Server.MapPath("Result.txt"));

                            MediaDetails md = JsonParser.GetMediaValue(MediaPageSource);

                            tblAccesstoken tblLikeUser = autoLikeRepo.GetUser(md.username);
                            tbl_CutomerDetail objtbl_CutomerDetail = objCutomerDetailRepository.GetIGUseDetail(md.username);

                            FileHelper.AppendStringToTextfileNewLine("Customer Details Found : " + media_id, Server.MapPath("Result.txt"));

                            if (tblLikeUser != null && objtbl_CutomerDetail != null)
                            {
                                FileHelper.AppendStringToTextfileNewLine("Checking For Null : " + media_id, Server.MapPath("Result.txt"));

                                bool IsUrlExist = orderRepo.IsUrlExist(md.link);

                                if (!IsUrlExist)
                                {
                                    FileHelper.AppendStringToTextfileNewLine("Url Not Exist : " + media_id, Server.MapPath("Result.txt"));

                                    tblPlan planData = plan.GetPlan(objtbl_CutomerDetail.Planid);
                                    int TodayCount = orderRepo.GetTodayOrdersCount(md.username);

                                    FileHelper.AppendStringToTextfileNewLine("Url Not Exist : " + TodayCount + ":" + planData.MaxPhotos, Server.MapPath("Result.txt"));

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
                                else
                                {
                                    FileHelper.AppendStringToTextfileNewLine("Url Exist : " + media_id, Server.MapPath("Result.txt"));
                                }
                            }

                            //orderRepo.AddOrder(OrderNumber, md.link, Num,
                            //              DateTime.Now, 0, EndPoint, 0, "Pending", DateTime.Now, "Like", md.username);


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