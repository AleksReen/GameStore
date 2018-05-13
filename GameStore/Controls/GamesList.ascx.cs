using GameStore.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace GameStore.Controls.tools
{
    public partial class GamesList : System.Web.UI.UserControl
    {
        public IEnumerable<Game> GameCollection { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater.DataSource = GameCollection;
            Repeater.DataBind();
        }
    }
}