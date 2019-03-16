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
    public partial class WebForm4 : System.Web.UI.Page
    {
        public static string userStr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("../login.aspx");

            userStr = Session["username"].ToString();
        }

        [System.Web.Services.WebMethod]
        public static string addStocks(string product, string description, string price, string quantity, string id)
        {
            
            try
            {
                using (var cn = new NpgsqlConnection(ConfigurationManager.AppSettings["dbconnection"]))
                {
                    int prices = Convert.ToInt32(price);
                    int quantities = Convert.ToInt32(quantity);
                    int ids = Convert.ToInt32(id);
                    var query = "insert into stock_table (username, product, description, price, quantity, id) values (@userS,@productS,@descriptionS,@priceS,@quantityS,@idS)";
                    var result = cn.Execute(query, new { userS = userStr, productS = product, descriptionS = description, priceS = prices, quantityS = quantities, idS = ids });
                    return "success";
                }
            }
            catch
            {
                return "error";
            }
        }


        [System.Web.Services.WebMethod]
        public static string deleteStock(string id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            using (var cn = new NpgsqlConnection(ConfigurationManager.AppSettings["dbconnection"]))
            {
                cn.Open();
                Int32 id_int = Convert.ToInt32(id);
                var query = "delete from stock_table where id=@ids;";
                var result = cn.Execute(query, new { ids = id_int });
            }
            return "success";
        }

    }
}