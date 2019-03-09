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
        public static string userStr;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("../login.aspx");

            userStr = Session["username"].ToString();
            
        }

        [System.Web.Services.WebMethod]
        public static List<productDapper> getProducts()
        {
            using (var cn = new NpgsqlConnection(ConfigurationManager.AppSettings["dbconnection"]))
            {
                
                cn.Open();
                var query = "select * from product_table where username=@userS;";
                var result = cn.Query<productDapper>(query, new { userS = userStr });
                var d = result;
                return d.ToList();
            }

        }
        
        [System.Web.Services.WebMethod]
        public static string addProducts(string item, string cost)
        {
            System.Diagnostics.Debug.WriteLine(item + " => " + cost);
            try
            {
                using(var cn = new NpgsqlConnection(ConfigurationManager.AppSettings["dbconnection"]))
                {
                    int costs = Convert.ToInt32(cost);
                    var query = "insert into product_table (item,cost,username) values (@itemS,@costS,@userS)";
                    var result = cn.Execute(query, new { itemS = item, costS = costs, userS = userStr });
                    return "success";
                }
            }
            catch
            {
                return "error";
            }
        }


        [System.Web.Services.WebMethod]
        public static string deleteName(string id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            using (var cn = new NpgsqlConnection(ConfigurationManager.AppSettings["dbconnection"]))
            {
                cn.Open();
                Int32 id_int = Convert.ToInt32(id);
                var query = "delete from product_table where id=@ids;";
                var result = cn.Execute(query, new { ids = id_int });
            }
            return "success";
        }


    }
}