using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int page = string.IsNullOrEmpty(Request.QueryString["page"]) ? 1 : int.Parse(Request.QueryString["page"]);

        GridPager pgr = new GridPager { CurrentPage = page, TotalItems = 1190, PerPage = 5 };
        lit1.Text = pgr.Paginate();
    }
}