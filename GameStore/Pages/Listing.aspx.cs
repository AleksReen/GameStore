using GameStore.Models;
using GameStore.Models.Helpers;
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
            GamesList.GameCollection = FilterGames()
                .OrderBy(g => g.GameId)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }

        private IEnumerable<Game> FilterGames()
        {
            IEnumerable<Game> games = gameStoreDataService.GetGames();
            string currentCategory = (string)RouteData.Values["category"] ??
                Request.QueryString["category"];
            return currentCategory == null ? games :
                games.Where(p => p.Category == currentCategory);
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
            else
            {
                int selectedGameId;
                if (int.TryParse(Request.Form["add"], out selectedGameId))
                {
                    Game selectedGame = gameStoreDataService.GetSelectedGame(selectedGameId);
                       
                    if (selectedGame != null)
                    {
                        SessionHelper.GetCart(Session).AddItem(selectedGame, 1);
                        SessionHelper.Set(Session, SessionKey.RETURN_URL,
                            Request.RawUrl);

                        Response.Redirect(RouteTable.Routes
                            .GetVirtualPath(null, "cart", null).VirtualPath);
                    }
                }
            }
        }
    }
}