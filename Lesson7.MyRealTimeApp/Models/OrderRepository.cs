using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson7.MyRealTimeApp.Models
{
    public class OrderRepository
    {
        private static ICollection<Order> _list;

        public ICollection<Order> GetCollection()
        {
            if (_list == null)
            {
                _list = new List<Order>();
            }

            return _list;
        }

        public void Create(Order order)
        {
            order.CreateDate = DateTime.Now;

            order.Id = _list.Any() ?
                _list.Max(x => x.Id) + 1 :
                1;

            _list.Add(order);
        }

        public Order Start(int id)
        {
            var item = _list.First(x => x.Id == id);
            item.StartDate = DateTime.Now;

            return item;
        }

        public Order Finish(int id)
        {
            var item = _list.First(x => x.Id == id);
            item.FinishDate = DateTime.Now;

            return item;
        }

    }
}