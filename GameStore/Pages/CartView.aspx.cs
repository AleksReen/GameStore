using GameStore.Models;
using GameStore.Models.Helpers;
using GameStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStore.Pages
{
    public partial class CartView : System.Web.UI.Page
    {
        private GameStoreDataService gameStoreDataService = new GameStoreDataService();

        protected void Page_Load(object sender, EventArgs e)
        {           
            if (IsPostBack)
            {
                int gameId;
                if (int.TryParse(Request.Form["remove"], out gameId))
                {
                    Game gameToRemove = gameStoreDataService.GetSelectedGame(gameId);
                    if (gameToRemove != null)
                    {
                        SessionHelper.GetCart(Session).RemoveLine(gameToRemove);
                    }
                }
            }
        }
        public IEnumerable<CartLine> GetCartLines()
        {
            return SessionHelper.GetCart(Session).Lines;
        }

        public decimal CartTotal
        {
            get
            {
                return SessionHelper.GetCart(Session).ComputeTotalValue();
            }
        }

        public string ReturnUrl
        {
            get
            {
                return SessionHelper.Get<string>(Session, SessionKey.RETURN_URL);
            }
        }
    }
}