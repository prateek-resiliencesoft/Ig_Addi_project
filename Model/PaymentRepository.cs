using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPanel.Model
{
    public class PaymentRepository
    {
        DataClassesDataContext Dbcontext = new DataClassesDataContext();

        public void AddPaymentRecord(string UserName, double Amount, string Status, DateTime PaymentDate, DateTime PaymentUpdatedDate, string UpdatedBy, string TransactionId,
            string PayerEmail, string ReceiverEmail)
        {
            tblPaymentRecord PaymenRecord = new tblPaymentRecord();
            PaymenRecord.UserName = UserName;
            PaymenRecord.Amount = Amount;
            PaymenRecord.Status = Status;
            PaymenRecord.PaymentDate = PaymentDate;
            PaymenRecord.PaymentUpdatedDate = PaymentUpdatedDate;
            PaymenRecord.UpdatedBy = UpdatedBy;
            PaymenRecord.TransactionId = TransactionId;
            PaymenRecord.PayerEmail = PayerEmail;
            PaymenRecord.ReceiverEmail = ReceiverEmail;
            Dbcontext.tblPaymentRecords.InsertOnSubmit(PaymenRecord);
            Dbcontext.SubmitChanges();
        }

        public void UpadtePaymentRecord(int Id, string UserName, double Amount, string Status, string UpdatedBy,
            string TransactionId, string PayerEmail, string ReceiverEmail)
        {
            tblPaymentRecord PaymenRecord = Dbcontext.tblPaymentRecords.Single(pay => pay.Id == Id);
            PaymenRecord.UserName = UserName;
            PaymenRecord.Amount = Amount;
            PaymenRecord.Status = Status;
            PaymenRecord.PaymentDate = DateTime.Now;
            PaymenRecord.PaymentUpdatedDate = DateTime.Now;
            PaymenRecord.UpdatedBy = UpdatedBy;
            PaymenRecord.TransactionId = TransactionId;
            PaymenRecord.PayerEmail = PayerEmail;
            PaymenRecord.ReceiverEmail = ReceiverEmail;
            Dbcontext.SubmitChanges();
        }

        public void AddPayment(string UserName, double Amount, DateTime DateTime)
        {
            tblPayment Payment = new tblPayment();
            Payment.UserName = UserName;
            Payment.Amount = Amount;
            Payment.DateTime = DateTime;
            Dbcontext.tblPayments.InsertOnSubmit(Payment);
            Dbcontext.SubmitChanges();
        }

        public IQueryable<tblPayment> GetPaymentDetails(string UserName)
        {
            return Dbcontext.tblPayments.Where(Pay => Pay.UserName == UserName).OrderByDescending(Pay=>Pay.Id);
        }

        public bool GetPaymentDetail(string UserName)
        {
            return Dbcontext.tblPayments.Where(Pay => Pay.UserName == UserName).Any();
        }

        public IQueryable<tblPayment> GetPaymentDetails()
        {
            return Dbcontext.tblPayments.OrderByDescending(Pay => Pay.Id);
        }

        public tblPayment GetAmountDetail(string UserName)
        {
            return Dbcontext.tblPayments.Single(Pay => Pay.UserName == UserName);
        }

        public void UpdatePayment(string UserName, double Amount)
        {
            tblPayment payment = Dbcontext.tblPayments.First(pay => pay.UserName == UserName);
            payment.Amount = Amount;
            Dbcontext.SubmitChanges();
        }

        public object GetPaymentRecordDetails(string Email)
        {
            var PaymentRecordDetailsForUser = Dbcontext.spPaymentRecordDetailsForUser(Email);
            return PaymentRecordDetailsForUser;
        }

        //public object GetPaymentDetails(string Email)
        //{
        //    var PaymentDetails = Dbcontext.spPaymentDetailsForUser(Email);
        //    return PaymentDetails;
        //}

        public IQueryable<tblPaymentRecord> GetPaymentRecords()
        {
            IQueryable<tblPaymentRecord> tblPaymentRecord = Dbcontext.tblPaymentRecords.OrderByDescending(Pay => Pay.Id);
            return tblPaymentRecord;//.OrderByDescending(o => o.Id);
        }

        public IQueryable<tblPaymentRecord> GetPaymentRecords(string UserName)
        {
            IQueryable<tblPaymentRecord> tblPaymentRecord = Dbcontext.tblPaymentRecords.Where(P => P.UserName == UserName).OrderByDescending(Pay => Pay.Id);
            return tblPaymentRecord;//.OrderByDescending(o => o.Id);
        }
    }
}