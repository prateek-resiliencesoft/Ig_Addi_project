using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialPanel.Model;

namespace SocialPanel.User
{
    public partial class Site : System.Web.UI.MasterPage
    {
        //PaymentRepository pr = new PaymentRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (Session["Amount"] == null)
                //{
                //    tblPayment tblpay = pr.GetAmountDetail(HttpContext.Current.User.Identity.Name);
                //    Session["Amount"] = tblpay.Amount;
                //}
            }
            catch (Exception ex)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}