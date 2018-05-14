using GameStore.Models;
using GameStore.Models.Repository;
using System;
using System.Collections.Generic;
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

        [WebMethod]
        public IEnumerable<Game> GetGames() => context.Games;

        [WebMethod]
        public IEnumerable<string> GetGamesName()
        {
            return context.Games
                .Select(g => g.Category)
                .Distinct()
                .OrderBy(g => g);
        }

        [WebMethod]
        public Game GetSelectedGame(int selectedGameId)
        {
            return context.Games
                .Where(g => g.GameId == selectedGameId)
                .FirstOrDefault();
        }
    }
}
