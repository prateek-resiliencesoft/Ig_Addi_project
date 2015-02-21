using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPanel.Model
{
    public class OrderTypePriceRepository
    {
        DataClassesDataContext DbContext = new DataClassesDataContext();

        public void AddOrderTypePrice(string OrderType, decimal Price, int MinAccount, int MaxAccount)
        {
            tblOrderTypePrice orderTypePrice = new tblOrderTypePrice();

            orderTypePrice.OrderType = OrderType;
            orderTypePrice.Price = double.Parse(Price.ToString());
            orderTypePrice.MinAmount = MinAccount;
            orderTypePrice.MaxAmount = MaxAccount;

            DbContext.tblOrderTypePrices.InsertOnSubmit(orderTypePrice);
            DbContext.SubmitChanges();
        }

        public void UpdateOrderTypePrice(int Id, string OrderType, decimal Price, int MinAccount, int MaxAccount)
        {
            tblOrderTypePrice orderTypePrice = DbContext.tblOrderTypePrices.Single(O => O.Id == Id);

            orderTypePrice.OrderType = OrderType;
            orderTypePrice.Price = double.Parse(Price.ToString());
            orderTypePrice.MinAmount = MinAccount;
            orderTypePrice.MaxAmount = MaxAccount;

            DbContext.SubmitChanges();
        }

        public tblOrderTypePrice GetOrderTypePrice(int Id)
        {
            return DbContext.tblOrderTypePrices.First(O => O.Id == Id);
        }

        public tblOrderTypePrice GetOrderTypePrice(string OrderType)
        {
            return DbContext.tblOrderTypePrices.First(O => O.OrderType == OrderType);
        }

        public IQueryable<tblOrderTypePrice> GetOrderTypePrice()
        {
            DataClassesDataContext DbContext = new DataClassesDataContext();
            var tblOrderTypePriceDetails = DbContext.tblOrderTypePrices;
            return tblOrderTypePriceDetails.OrderByDescending(O => O.Id);
        }
    }
}