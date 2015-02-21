using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialPanel.Model;
using System.Text.RegularExpressions;
using Social_Media_Service_Panel.Helper;
using System.Data.SqlClient;
using System.Data;

namespace SocialPanel.Admin
{
    public partial class Order : System.Web.UI.Page
    {
        OrderRepository orderRepo = new OrderRepository();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (!IsPostBack)
                    {
                        //Order_Types.GetOrderTypes();
                        //ddlOrderType.DataSource = Order_Types.OrderTypes;
                        //ddlOrderType.DataTextField = "Value";
                        //ddlOrderType.DataValueField = "Value";
                        //ddlOrderType.DataBind();

                        Order_Types.GetStatusForAdmin();
                        ddlOrderStatus.DataSource = Order_Types.StatusForAdmin;
                        ddlOrderStatus.DataTextField = "Value";
                        ddlOrderStatus.DataValueField = "Value";
                        ddlOrderStatus.DataBind();

                        if (Request.QueryString["ID"] != null)
                        {
                            int OrderId = int.Parse(Request.QueryString["ID"]);

                            tblOrder order = orderRepo.GetDetail(OrderId);
                            txtUrl.Text = order.Url;
                            txtAmount.Text = order.Amount.ToString();

                            //hfUser.Value = order.ClientUserName;

                            //ddlOrderType.ClearSelection();
                            ddlOrderStatus.ClearSelection();
                            //this.ddlOrderType.Items.FindByText(order.OrderType).Selected = true;
                            this.ddlOrderStatus.Items.FindByText(order.OrderStatus).Selected = true;
                        }
                    }

                    
                }
                else
                {
                    Response.Redirect("~/Login.aspx", false);
                    return;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["ID"] == null)
                {
                    string OrderNumber = Guid.NewGuid().ToString();

                    decimal AmountForTask = decimal.Parse(txtAmount.Text.Trim()) / 1000;
                    AmountForTask = AmountForTask * 2;

                    List<string> lstAcconts = Regex.Split(txtUrl.Text.Trim(), "\r\n").ToList();

                    

                    foreach (string item in lstAcconts)
                    {
                        int startpoint = 0;
                        int endpoint = 0;
                        string url = string.Empty;
                        
                        try
                        {
                            if (!item.Contains("http://instagram.com/"))
                            {
                                url = "http://instagram.com/" + item;
                            }

                            startpoint = InstagramDetails.GetNumberOfFollow(url);

                            endpoint = startpoint + int.Parse(txtAmount.Text.Trim());

                            orderRepo.AddOrder(OrderNumber, url, int.Parse(txtAmount.Text.Trim()),
                                                DateTime.Now, startpoint, endpoint, 0, ddlOrderStatus.SelectedItem.Value, DateTime.Now);
                            lblErrorMessage.Text = "Record successfully added";
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    
                }
                else
                {
                    int OrderId = int.Parse(Request.QueryString["ID"]);

                    decimal AmountForTask = decimal.Parse(txtAmount.Text.Trim()) / 1000;
                    AmountForTask = AmountForTask * 2;

                    //orderRepo.UpdateOrderForAdmin(OrderId,ddlOrderType.SelectedItem.Value, txtUrl.Text.Trim(), int.Parse(txtAmount.Text.Trim()),
                    //    HttpContext.Current.User.Identity.Name, DateTime.Now, ddlOrderStatus.SelectedItem.Value, DateTime.Now,AmountForTask);

                    orderRepo.UpdateOrderForAdmin(OrderId,txtUrl.Text.Trim(), int.Parse(txtAmount.Text.Trim()),
                        DateTime.Now, ddlOrderStatus.SelectedItem.Value, DateTime.Now);

                    lblErrorMessage.Text = "Record successfully updated";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtAmount.Text = string.Empty;
                txtUrl.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void Btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["ID"] != null)
                {
                    int id = int.Parse(Request.QueryString["ID"].ToString());
                    orderRepo.DeleteOrder(id);
                    lblErrorMessage.Text = "Record successfully deleted";
                }
            }

            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }

        }

        //protected void Btndeleteall_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (ddlOrderStatus.SelectedItem.Value != null)
        //        {
        //            string status = ddlOrderStatus.SelectedItem.Value;
        //            orderRepo.DeleteAllOrder(status);
        //            string msg = "All" + ddlOrderStatus.SelectedItem.Value + "Records successfully deleted";
        //            lblErrorMessage.Text = msg;
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        lblErrorMessage.Text = ex.Message;
        //    }
        //}
    }
}