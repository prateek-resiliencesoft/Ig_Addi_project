using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPanel.Model
{
    public class OrderRepository
    {
        DataClassesDataContext DbContext = new DataClassesDataContext();

        public void AddOrder(string OrderNumber, string Url, int Amount,DateTime OrderDate, int StartPoint,
            int EndPoint, int CurrentCount, string OrderStatus, DateTime LastUpdateDate, string OrderType)
        {
            tblOrder order = new tblOrder();

            order.OrderNumber = OrderNumber;
            order.Url = Url;
            order.Amount = Amount;
            order.OrderDate = OrderDate;
            order.StartPoint = StartPoint;
            order.EndPoint = EndPoint;
            order.CurrentCount = CurrentCount;
            order.OrderStatus = OrderStatus;
            order.LastUpdateDate = LastUpdateDate;
            order.OrderType = OrderType;

            DbContext.tblOrders.InsertOnSubmit(order);
            DbContext.SubmitChanges();
        }

        public void AddOrder(string OrderNumber, string Url, int Amount, DateTime OrderDate, int StartPoint,
            int EndPoint, int CurrentCount, string OrderStatus, DateTime LastUpdateDate, string OrderType,string Username)
        {
            tblOrder order = new tblOrder();

            order.OrderNumber = OrderNumber;
            order.Url = Url;
            order.Amount = Amount;
            order.OrderDate = OrderDate;
            order.StartPoint = StartPoint;
            order.EndPoint = EndPoint;
            order.CurrentCount = CurrentCount;
            order.OrderStatus = OrderStatus;
            order.LastUpdateDate = LastUpdateDate;
            order.OrderType = OrderType;
            order.UserName = Username;
            DbContext.tblOrders.InsertOnSubmit(order);
            DbContext.SubmitChanges();
        }

        public void UpdateOderStatus(int OrderId, string OrderStatus, int StartPoint, int EndPoint, DateTime CompleteDate)
        {
            tblOrder order = DbContext.tblOrders.Single(O => O.OrderId == OrderId);

            order.OrderStatus = OrderStatus;
            order.StartPoint = StartPoint;
            order.EndPoint = EndPoint;
            order.StartPoint = StartPoint;
            order.EndPoint = EndPoint;
            order.LastUpdateDate = CompleteDate;

            DbContext.SubmitChanges();
        }



        public bool IsUrlExist(string Url)
        {
            return DbContext.tblOrders.Any(O => O.Url == Url);
        }

        public tblOrder GetDetail(int OrderId)
        {
            return DbContext.tblOrders.First(O => O.OrderId == OrderId);
        }

        //public bool IsUrlExist(string Url)
        //{
        //    return DbContext.tblOrders.Where(O=>O.FeatureType =="AutoLike").Any(O => O.Url == Url);
        //}

        public void UpdateOrderForAdmin(int OrderId,string Url, int Amount,DateTime OrderDate,
           string OrderStatus, DateTime CompleteDate)
        {
            tblOrder order = DbContext.tblOrders.First(O => O.OrderId == OrderId);

            order.Url = Url;
            order.Amount = Amount;
            order.OrderDate = OrderDate;
            order.OrderStatus = OrderStatus;
            order.LastUpdateDate = CompleteDate;
            DbContext.SubmitChanges();
        }

        public tblOrder CheckOrderStatus(int OrderId)
        {
            return DbContext.tblOrders.First(O => O.OrderId == OrderId);
        }

        //public object GetFacebookOrders(string Email)
        //{
        //    DataClassesDataContext DbContext = new DataClassesDataContext();
        //    var FacebookOrderDetail = DbContext.spFacebookOrderDetailsForUser(Email, null, null, null, null);
        //    return FacebookOrderDetail.OrderByDescending(o => o.Id);
        //}

        public IQueryable<tblOrder> GetOrders()
        {
            DataClassesDataContext DbContext = new DataClassesDataContext();
            var tblOrderDetails = DbContext.tblOrders;
            return tblOrderDetails.OrderByDescending(O => O.OrderId);
        }

        public int GetTodayOrdersCount(string UserName)
        {
            DataClassesDataContext DbContext = new DataClassesDataContext();
            return DbContext.tblOrders.Where(O => O.UserName == UserName).Count(O => O.OrderDate >= DateTime.Now.Date);
        }

        //public IQueryable<tblOrder> GetCompletedOrders()
        //{
        //    DataClassesDataContext DbContext = new DataClassesDataContext();
        //    var tblOrderDetails = DbContext.tblOrders.Where(O=>O.OrderStatus=="Completed");
        //    return tblOrderDetails.OrderByDescending(O => O.OrderId);
        //}

        //public IQueryable<tblOrder> GetCompletedOrders()
        //{
        //    DataClassesDataContext DbContext = new DataClassesDataContext();
        //    var tblOrderDetails = DbContext.tblOrders.Where(O => O.OrderStatus == "Completed");
        //    return tblOrderDetails.OrderByDescending(O => O.OrderId);
        //}
        //public IQueryable<tblOrder> GetNonCompletedOrders()
        //{
        //    DataClassesDataContext DbContext = new DataClassesDataContext();
        //    var tblOrderDetails = DbContext.tblOrders.Where(O => O.OrderStatus != "Completed");
        //    return tblOrderDetails.OrderByDescending(O => O.OrderId);
        //}

        public IQueryable<tblOrder> GetCompletedOrders(string OrderType)
        {
            DataClassesDataContext DbContext = new DataClassesDataContext();
            var tblOrderDetails = DbContext.tblOrders.Where(O => O.OrderStatus == "Completed" && O.OrderType == OrderType);
            return tblOrderDetails.OrderByDescending(O => O.OrderId);
        }
        public IQueryable<tblOrder> GetNonCompletedOrders(string OrderType)
        {
            DataClassesDataContext DbContext = new DataClassesDataContext();
            var tblOrderDetails = DbContext.tblOrders.Where(O => O.OrderStatus != "Completed" && O.OrderType==OrderType);
            return tblOrderDetails.OrderByDescending(O => O.OrderId);
        }

        //public IQueryable<tblOrder> GetOrders(string ClientUserName)
        //{
        //    DataClassesDataContext DbContext = new DataClassesDataContext();
        //    var tblOrderDetails = DbContext.tblOrders.Where(O => O.ClientUserName == ClientUserName);
        //    return tblOrderDetails.OrderByDescending(O => O.OrderId);
        //}

        //public IQueryable<tblOrder> GetCompletedOrders(string ClientUserName, string FeatureType)
        //{
        //    DataClassesDataContext DbContext = new DataClassesDataContext();
        //    var tblOrderDetails = DbContext.tblOrders.Where(O => O.ClientUserName == ClientUserName && O.OrderStatus == "Completed" && O.FeatureType == FeatureType);
        //    return tblOrderDetails.OrderByDescending(O => O.OrderId);
        //}

        //public IQueryable<tblOrder> GetNonCompletedOrders(string ClientUserName ,string FeatureType)
        //{
        //    DataClassesDataContext DbContext = new DataClassesDataContext();
        //    var tblOrderDetails = DbContext.tblOrders.Where(O => O.ClientUserName == ClientUserName && O.OrderStatus != "Completed" && O.FeatureType == FeatureType);
        //    return tblOrderDetails.OrderByDescending(O => O.OrderId);
        //}

        public void DeleteOrder(int Id)
        {
            tblOrder order = DbContext.tblOrders.First(O => O.OrderId == Id);
            DbContext.tblOrders.DeleteOnSubmit(order);
            DbContext.SubmitChanges();
        }

        public void DeleteAllOrder(string status)
        {
            var value = from r in DbContext.tblOrders
                        where r.OrderStatus == status
                        select r;
            DbContext.tblOrders.DeleteAllOnSubmit(value);
            DbContext.SubmitChanges();
        }
    }
}