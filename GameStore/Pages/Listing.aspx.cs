using GameStore.Models;
using GameStore.Service;
using System;
using System.Collections.Generic;

namespace GameStore.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private GameStoreDataService gameStoreDataService = new GameStoreDataService();

        protected void GetGames()
        {
            var games = gameStoreDataService.GetGames();

            foreach (var game in games)
            {
                gamesLable.Text += $"<h3>{ game.Name}</h3>{game.Description}<h4>{game.Price:c}</h4>";
            }
            gamesLable.CssClass = "item";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetGames();
            }
        }
    }
}