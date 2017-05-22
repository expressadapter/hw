using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isLogin"] == "1") {
            Response.Redirect("/profile.aspx");
        }

        if (Session["isAdmin"] == "1")
        {
            Response.Redirect("/admin.aspx");
        }
    }

    protected void login_Click(object sender, EventArgs e)
    {
        OleDbConnection connn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);

        OleDbCommand cmd = connn.CreateCommand();
        cmd.CommandText = "SELECT * FROM Users WHERE email='" + TextBox1.Text + "' AND upassword='" + TextBox2.Text + "'"; ;
        cmd.Connection = connn;
        cmd.CommandType = CommandType.Text;

        DataTable dtUser = new DataTable();

        OleDbDataAdapter daRead = new OleDbDataAdapter();
        daRead.SelectCommand = cmd;
        daRead.Fill(dtUser);

        if (dtUser.Rows.Count > 0)
        {
            Session["isLogin"] = "1";
            Session["userid"] = dtUser.Rows[0]["userID"].ToString();
            if (dtUser.Rows[0]["userType"].ToString() == "admin") {
               
                Session["isAdmin"] = "1";
                Response.Redirect("admin.aspx");
            }

            labelWarn.Text = "";
            Response.Redirect("profile.aspx");


        }
        else
        {
            labelWarn.Text = "Kullanıcı Adı ve Şifrenizi kontrol ediniz.";
        }

        connn.Close();
    }

}
    
