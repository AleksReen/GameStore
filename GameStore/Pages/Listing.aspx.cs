using GameStore.Models;
using GameStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace GameStore.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private GameStoreDataService gameStoreDataService = new GameStoreDataService();
        private int pageSize = 4;

        protected int CurrentPage
        {
            get {
                    int page;
                    page = GetPageFromRequest();
                    return page > MaxPage ? MaxPage : page;
                }
        }

        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ?? 
                Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }

        protected int MaxPage
        {
            get
            {
                return (int)Math.Ceiling((decimal)gameStoreDataService.GetGames().Count() / pageSize);
            }
        }

        protected void GetGames()
        {
            var games = gameStoreDataService.GetGames()
                .OrderBy(g => g.GameId)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);

            foreach (var game in games)
            {
                gamesTable.Text += $"<h3>{ game.Name}</h3>{game.Description}<h4>{game.Price:c}</h4>";
            }
            gamesTable.CssClass = "item";
        }

        protected void GetPages()
        {
            for (int i = 1; i <= MaxPage; i++)
            {
                string path = RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary() { { "page", i } }).VirtualPath;

                var link = new HyperLink();

                link.NavigateUrl = path;                
                link.Text = i.ToString();

                if (i == CurrentPage)
                {
                    link.CssClass = "item";
                }
                else
                {
                    link.CssClass = string.Empty;
                }

                gamePages.Controls.Add(link);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetGames();
                GetPages();
            }
        }
    }
}