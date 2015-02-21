using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPanel.Model
{
    public class OperationSettingRepository
    {
        DataClassesDataContext DbContext = new DataClassesDataContext();

        public void UpdateDelay(int Id, int LikeDelay, int FollowDelay, int SearchDelay)
        {
            OperationSetting opr = DbContext.OperationSettings.Single(O => O.Id == Id);

            opr.LikeDelay = LikeDelay;
            opr.FollowDelay = FollowDelay;
            opr.SearchDelay = SearchDelay;

            DbContext.SubmitChanges();
        }

        public OperationSetting GetSetting(int Id)
        {
            return DbContext.OperationSettings.FirstOrDefault(S => S.Id == Id);
        }
    }
}