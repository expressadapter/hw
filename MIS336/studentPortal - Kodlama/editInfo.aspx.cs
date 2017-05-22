using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class editInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (Session["isLogin"] == "1")
            {
                String usrname = (string)Session["username"];
                OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);



                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT * FROM Users WHERE email='a@a.com'";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                DataTable dtUser = new DataTable();

                OleDbDataAdapter daRead = new OleDbDataAdapter(cmd);
                daRead.Fill(dtUser);

                if (dtUser.Rows.Count > 0)
                {

                    name.Text = dtUser.Rows[0]["name"].ToString();
                    surname.Text = dtUser.Rows[0]["surname"].ToString();
                    email.Text = dtUser.Rows[0]["email"].ToString();
                    password.Text = dtUser.Rows[0]["upassword"].ToString();

                }
                conn.Close();
            }
            else
            {
                Response.Redirect("homepage.aspx");
            }
        }
    }
    protected void updateInfo_Click(object sender, EventArgs e) {
        String usrname = (string)Session["username"];

        OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);

        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conn;
        cmd.CommandText = "UPDATE Users SET name=@name, surname=@surname, email=@email, upassword=@password  WHERE userID=" + Session["userid"];
        cmd.CommandType = CommandType.Text;


        cmd.Parameters.AddWithValue("@name", name.Text);
        cmd.Parameters.AddWithValue("@surname", surname.Text);
        cmd.Parameters.AddWithValue("@email", email.Text);
        cmd.Parameters.AddWithValue("@password", password.Text);


        int affected = 0;

        try
        {
            conn.Open();
            affected = cmd.ExecuteNonQuery();
            conn.Close();
        }

        catch (Exception ex)
        {
            Label.Text = "Error: " + ex.Message;
            return;
        }
        if (affected == 1)
        {
            Label.Text = "Info is updated";
        }
        else
        {
            Label.Text = "Error, info can not updated";
        }
    }
}