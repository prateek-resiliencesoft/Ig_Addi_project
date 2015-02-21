using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPanel.Model
{
    public class AutoLikeRepository
    {
        DataClassesDataContext Dbcotext = new DataClassesDataContext();

        public void AddInstagramUser(string Login_Username, string InstagramUser, int MinCount, int MaxCount, string status)
        {
            tblAutoLikeUser autoLikeuser = new tblAutoLikeUser();

            autoLikeuser.Login_Username = Login_Username;
            autoLikeuser.Insta_Username = InstagramUser;
            autoLikeuser.MinCount = MinCount;
            autoLikeuser.MaxCount = MaxCount;
            autoLikeuser.Status = status;
            autoLikeuser.Date = DateTime.Now;

            Dbcotext.tblAutoLikeUsers.InsertOnSubmit(autoLikeuser);
            Dbcotext.SubmitChanges();
        }

        public void UpdateInstagramUser(int OrderId, string Status, int Mincount, int Maxcount)
        {
            tblAutoLikeUser objtbl = Dbcotext.tblAutoLikeUsers.First(a => a.ID == OrderId);

            objtbl.Status = Status;
            objtbl.MinCount = Mincount;
            objtbl.MaxCount = Maxcount;
            Dbcotext.SubmitChanges();
        }

        public tblAutoLikeUser GetUser(string InstagramUser)
        {
            return Dbcotext.tblAutoLikeUsers.First(A => A.Insta_Username == InstagramUser);
        }

        public bool IsInstagramUserExist(string InstagramUser)
        {
            return Dbcotext.tblAutoLikeUsers.Any(A => A.Insta_Username == InstagramUser);
        }

        public tblAutoLikeUser GetUser(int Id)
        {
            return Dbcotext.tblAutoLikeUsers.First(A => A.ID == Id);
        }

        public List<tblAutoLikeUser> GetUsers(string Login_Username)
        {
            return Dbcotext.tblAutoLikeUsers.Where(A => A.Login_Username == Login_Username).ToList();
        }

        public List<tblAutoLikeUser> GetUsers()
        {
            return Dbcotext.tblAutoLikeUsers.ToList();
        }
    }
}