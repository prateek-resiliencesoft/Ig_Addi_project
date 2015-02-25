using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialPanel.Model;

namespace SocialPanel.Admin
{
    public partial class AddPlan : System.Web.UI.Page
    {
        PlanRepository planRepo = new PlanRepository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                planRepo.AddPlan(txtPlanName.Text.Trim(), int.Parse(txtLikeAmount.Text.Trim()), int.Parse(txtMaxCount.Text.Trim()));
                lblErrorMessage.Text = "Plan Added Successfully.";
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}