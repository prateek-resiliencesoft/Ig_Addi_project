using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPanel.Model
{
    public class SocialAccountRepository
    {
        DataClassesDataContext Dbcotext = new DataClassesDataContext();

        public void AddAccount(string AccountType, string Username,string Password,
            string Proxy, int Port, string ProxyUsername, string ProxyPassword, bool IsActive)
        {
            tblSocialAccount socialAccount = new tblSocialAccount();
            
            socialAccount.AccountType = AccountType;
            socialAccount.Username = Username;
            socialAccount.Password = Password;
            socialAccount.Proxy = Proxy;
            socialAccount.Port = Port;
            socialAccount.ProxyUsername = ProxyUsername;
            socialAccount.ProxyPassword = ProxyPassword;
            socialAccount.IsActive = IsActive;
            socialAccount.DateTime = DateTime.Now;

            Dbcotext.tblSocialAccounts.InsertOnSubmit(socialAccount);
            Dbcotext.SubmitChanges();
        }

        public void UpdateAccount(string AccountType, string Username, string Password,
            string Proxy, int Port, string ProxyUsername, string ProxyPassword, bool IsActive)
        {
            tblSocialAccount socialAccount = Dbcotext.tblSocialAccounts.Single(S => S.Username == Username);

            socialAccount.AccountType = AccountType;
            //socialAccount.Username = Username;
            socialAccount.Password = Password;
            socialAccount.Proxy = Proxy;
            socialAccount.Port = Port;
            socialAccount.ProxyUsername = ProxyUsername;
            socialAccount.ProxyPassword = ProxyPassword;
            socialAccount.IsActive = IsActive;
            socialAccount.DateTime = DateTime.Now;

            Dbcotext.SubmitChanges();
        }

        public IQueryable<tblSocialAccount> GetAccounts()
        {
            DataClassesDataContext DbContext = new DataClassesDataContext();
            var tblSocialAccountDetails = DbContext.tblSocialAccounts;
            return tblSocialAccountDetails.OrderByDescending(S => S.DateTime);
        }

        public tblSocialAccount GetAccount(string Username)
        {
            DataClassesDataContext DbContext = new DataClassesDataContext();
            var tblSocialAccountDetails = DbContext.tblSocialAccounts.FirstOrDefault(S => S.Username == Username);
            return tblSocialAccountDetails;
        }

        
    }
}