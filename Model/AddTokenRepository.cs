using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPanel.Model
{
    public class AddTokenRepository
    {
        DataClassesDataContext Dbcotext = new DataClassesDataContext();

        public void AddToken(string UserId, string Username, string AccessToken)
        {
            tblAccesstoken tokenusername = new tblAccesstoken();

            tokenusername.UserID = UserId;
            tokenusername.UserName = Username;
            tokenusername.AccessToken = AccessToken;
            tokenusername.IsActive = "True";
            tokenusername.DateTime = DateTime.Now.ToString();

            Dbcotext.tblAccesstokens.InsertOnSubmit(tokenusername);
            Dbcotext.SubmitChanges();
        }

        public List<tblAccesstoken> selectaccounts()
        {
            return Dbcotext.tblAccesstokens.ToList();
        }

        public void deleteuser(string id)
        {
            tblAccesstoken order = Dbcotext.tblAccesstokens.First(O => O.UserID == id);
            Dbcotext.tblAccesstokens.DeleteOnSubmit(order);
            Dbcotext.SubmitChanges();
        }

        public bool CheckUserExist(string userid)
        {
          return  Dbcotext.tblAccesstokens.Where(e => e.UserID == userid).Any();
        }

        public void Updatecheckid(string accesstoken, string username)
        {
            {
                tblAccesstoken token = Dbcotext.tblAccesstokens.First(O => O.AccessToken == accesstoken && O.UserName == username);
                token.UserName = username;
                token.AccessToken = accesstoken;
                token.DateTime = DateTime.Now.ToString();
                Dbcotext.SubmitChanges();
            }            
        }
    }
}