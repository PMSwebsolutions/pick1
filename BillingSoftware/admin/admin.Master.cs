using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BillingSoftware.admin
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserName.Text = Session["username"].ToString();
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../login.aspx");
        }
    }
}