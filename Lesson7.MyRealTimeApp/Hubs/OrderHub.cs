using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Lesson7.MyRealTimeApp.Models;
using Microsoft.AspNet.SignalR;

namespace Lesson7.MyRealTimeApp.Hubs
{
    public class OrderHub : Hub
    {
        private OrderRepository _repo = new OrderRepository();

        //public override Task OnConnected()
        //{
        //    Clients.Caller.LoadOrders(_repo.GetCollection());
        //    return base.OnConnected();
        //}

        public void LoadOrders()
        {
            Clients.Caller.LoadOrders(_repo.GetCollection());
        }

        public void Create(Order order)
        {
            _repo.Create(order);

            Clients.All.Created(order);
        }

        public void Start(int id)
        {
            var item = _repo.Start(id);

            Clients.All.Started(item);
        }

        public void Finish(int id)
        {
            var item = _repo.Finish(id);

            Clients.All.Finished(item);
        }



    }
}