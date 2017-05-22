using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.Mail;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void loginButton_Click1(object sender, EventArgs e)
    {
        string sif = passwordBox.Text;
        string paswd = FormsAuthentication.HashPasswordForStoringInConfigFile(sif, "md5");
        string userName = nameBox.Text;
        string password = passwordBox.Text;
        string userType = "";
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = @"select * from dbo.Users where UserName=@UserName and 
                Password=@Password";
        cmd.Parameters.AddWithValue("@UserName", userName);
        cmd.Parameters.AddWithValue("@Password", paswd);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
        

        if (dr.Read())
        {
            Session["isLogin"] = true;
            Session["UserName"] = userName;
            userType = dr["Type"].ToString();
            Session["Type"] = userType;
            Response.Redirect("UserPage.aspx");

        }
        else
        {
            loginErrorLabel.Text = "No such a user or wrong password!";
            loginErrorLabel.Visible = true;

        }
        dr.Close();
        conn.Close();
    }

    



 
}