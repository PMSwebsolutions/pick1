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
    public partial class WebForm3 : System.Web.UI.Page
    {
        public static string userStr;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("../login.aspx");

            userStr = Session["username"].ToString();
        }


        [System.Web.Services.WebMethod]
        public static List<stockDapper> getStocks()
        {
            using (var cn = new NpgsqlConnection(ConfigurationManager.AppSettings["dbconnection"]))
            {

                cn.Open();
                var query = "select * from stock_table where username=@userS;";
                var result = cn.Query<stockDapper>(query, new { userS = userStr });
                var d = result;
                return d.ToList();
            }

        }

    }
}