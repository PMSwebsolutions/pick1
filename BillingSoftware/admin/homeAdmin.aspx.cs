using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using Dapper;
using DapperExtensions;
using DapperExtensions.Sql;
using Npgsql;
using BillingSoftwareBLL.DAPPER;

namespace BillingSoftware.admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("../login.aspx");
            
        }

        [System.Web.Services.WebMethod]
        public static List<productDapper> getProducts()
        {
            using (var cn = new NpgsqlConnection(ConfigurationManager.AppSettings["dbconnection"]))
            {
                cn.Open();
                var query = "select * from product_table where id>@ids;";
                var result = cn.Query<productDapper>(query, new { ids = 0 });
                var d = result;
                return d.ToList();
            }

        }
        

    }
}