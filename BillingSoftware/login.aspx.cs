using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using Dapper;
using DapperExtensions;
using Npgsql;
using DapperExtensions.Sql;
using BillingSoftwareBLL.DAPPER;

namespace BillingSoftware
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorLog.Visible = false;
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            using (var cn = new NpgsqlConnection(ConfigurationManager.AppSettings["dbconnection"]))
            {
                cn.Open();
                try
                {
                    var query = "select password from log where username=@userS;";
                    var result = cn.Query<loginClass>(query, new { userS = usernameInput.Text.Trim() }).Single<loginClass>();
                    var d = result.password;
                    if (d.ToString() == passwordInput.Text.Trim())
                    {
                        Session["username"] = usernameInput.Text.Trim();
                        Response.Redirect("admin/homeAdmin.aspx");
                    }
                    else
                    {
                        errorLog.Visible = true;
                    }
                }
                catch
                {
                    errorLog.Visible = true;
                }

            }
        }
    }
}