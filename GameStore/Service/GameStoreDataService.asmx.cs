using GameStore.Models;
using GameStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace GameStore.Service
{
    /// <summary>
    /// Summary description for GameStoreDataService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GameStoreDataService : System.Web.Services.WebService
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Game> Games => context.Games;

        public IEnumerable<Order> Orders => context.Orders
                    .Include(o => o.OrderLines.Select(ol => ol.Game));

        [WebMethod]
        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                order = context.Orders.Add(order);

                foreach (OrderLine line in order.OrderLines)
                {
                    context.Entry(line.Game).State = EntityState.Modified;
                }

            }
            else
            {
                Order dbOrder = context.Orders.Find(order.OrderId);
                if (dbOrder != null)
                {
                    dbOrder.Name = order.Name;
                    dbOrder.Line1 = order.Line1;
                    dbOrder.Line2 = order.Line2;
                    dbOrder.Line3 = order.Line3;
                    dbOrder.City = order.City;
                    dbOrder.GiftWrap = order.GiftWrap;
                    dbOrder.Dispatched = order.Dispatched;
                }
            }
            context.SaveChanges();
        }

        [WebMethod]
        public IEnumerable<Game> GetGames() => context.Games;

        [WebMethod]
        public IEnumerable<string> GetGamesName() => context.Games
            .Select(g => g.Category)
            .Distinct()
            .OrderBy(g => g);


        [WebMethod]
        public Game GetSelectedGame(int selectedGameId) => context.Games
            .Where(g => g.GameId == selectedGameId)
            .FirstOrDefault();
    }
}
