using GameStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStore.Controls
{
    public partial class CategoryList : System.Web.UI.UserControl
    {
        GameStoreDataService service = new GameStoreDataService();

        protected void Page_Load(object sender, EventArgs e)
        {
            CreateHomeLinkHtml();
            CreateLinkHtml();
        }

        public IEnumerable<string> GetCategories()
        {
            return service.GetGamesName();
        }

        protected void CreateHomeLinkHtml()
        {
            string path = RouteTable.Routes.GetVirtualPath(null, null).VirtualPath;
            homeLink.Text = "Главная";
            homeLink.NavigateUrl = path;         
        }

        protected void CreateLinkHtml()
        {
            CategoryLinks.CategoryList = GetCategories();
        }
    }
}