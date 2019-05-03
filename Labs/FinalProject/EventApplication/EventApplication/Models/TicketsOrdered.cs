using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApplication.Models
{
    public class TicketsOrdered
    {
        public string TicketsOrderedId;

        private EventApplicationDB db = new EventApplicationDB();

        public static TicketsOrdered GetOrder(HttpContextBase context)
        {
            TicketsOrdered order = new TicketsOrdered();
            order.TicketsOrderedId = order.GetOrderId(context);
            return order;
        }

        private string GetOrderId(HttpContextBase context)
        {
            const string OrderSessionId = "OrderId";

            string orderId;

            //if (context.Session[OrderSessionId] == null)
            //{
            //    //Create a new order id
            //    orderId = Guid.NewGuid().ToString();

            //    //Save to the session state
            //    context.Session[OrderSessionId] = orderId;
            //}

            if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
            {
                context.Session[OrderSessionId] = context.User.Identity.Name;

                orderId = context.Session[OrderSessionId].ToString();
            }

            else
            {
                //Return the existing order id
                orderId = context.Session[OrderSessionId].ToString();
            }

            return orderId;
        }

        public List<Order> GetOrderItems()
        {
            return db.Orders.Where(c => c.OrderId == this.TicketsOrderedId).ToList();
        }

        //public decimal GetCartTotal()
        //{
        //    decimal? total = (from cartItem in db.Carts
        //                      where cartItem.CartId == this.ShoppingCartId
        //                      select cartItem.AlbumSelected.Price * (int?)cartItem.Count).Sum();

        //    return total ?? decimal.Zero;
        //}

        public void AddToOrder(int eventId)
        {
            //TODO: Verify the Event Id exists in the database.
            Order orderItem = db.Orders.SingleOrDefault(c => c.OrderId == this.TicketsOrderedId && c.EventId == eventId);

            if (orderItem == null)
            {
                //Item is not in cart; add new item
                orderItem = new Order()
                {
                    OrderId = this.TicketsOrderedId,
                    EventId = eventId,
                    Quantity = 0,
                    DateCreated = DateTime.Now
                };

                db.Orders.Add(orderItem);
            }
            else
            {
                //Item is already; increase order quantity
                orderItem.Quantity++;
            }

            db.SaveChanges();
        }

        public int CancelOrder(int recordId)
        {
            Order orderItem = db.Orders.SingleOrDefault(c => c.OrderId == this.TicketsOrderedId && c.RecordId == recordId);

            if (orderItem == null)
            {
                throw new NullReferenceException();
            }

            int newQuantity;

            if (orderItem.Quantity > 1)
            {
                //The count > 1; decrement count
                orderItem.Quantity--;
                newQuantity = orderItem.Quantity;
            }
            else
            {
                //The count <= 0; remove cart item
                db.Orders.Remove(orderItem);
                newQuantity = 0;
            }

            db.SaveChanges();

            return newQuantity;

        }
    }
}