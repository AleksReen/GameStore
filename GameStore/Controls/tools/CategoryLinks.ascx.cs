using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStore.Controls.tools
{
    public partial class CategoryLinks : UserControl
    {
        public IEnumerable<string> CategoryList { get; set; }       

        protected void Page_Load(object sender, EventArgs e)
        {
            List<HyperLink> LinksCollection = new List<HyperLink>();

            foreach (var categoryName in CategoryList)
            {
                string selectedCategory = (string)Page.RouteData.Values["category"]
                ?? Request.QueryString["category"];

                string path = RouteTable.Routes.GetVirtualPath(null, null,
                new RouteValueDictionary() { { "category", categoryName },
                    {"page", "1"} }).VirtualPath;

                LinksCollection.Add(new HyperLink {
                    NavigateUrl = path,
                    Text = categoryName,
                    CssClass = categoryName == selectedCategory ? "selected" : ""});
            }

            Repeater.DataSource = LinksCollection;
            Repeater.DataBind();
        }
    }
}