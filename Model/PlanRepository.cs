using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPanel.Model
{
    public class PlanRepository
    {
        DataClassesDataContext Dbcotext = new DataClassesDataContext();

        public void AddPlan(string PlanName, int LikeAmount, int MaxPhotos)
        {
            tblPlan plan = new tblPlan();

            plan.PlanName = PlanName;
            plan.LikeAmount = LikeAmount;
            plan.MaxPhotos = MaxPhotos;

            Dbcotext.tblPlans.InsertOnSubmit(plan);
            Dbcotext.SubmitChanges();
        }

        public tblPlan GetPlan(string PlanName)
        {
            return Dbcotext.tblPlans.FirstOrDefault(e => e.PlanName == PlanName);
        }

        public List<tblPlan> GetPlans()
        {
            return Dbcotext.tblPlans.ToList();
        }
    }
}