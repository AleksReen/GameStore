using GameStore.Models.Repository;
using System;
using System.Data.Entity;
using System.Web.Routing;

namespace GameStore
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<EFDbContext>(null);
        }
    }
}