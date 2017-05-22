using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class deleteAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void deleteAccount_Click(object sender,EventArgs e) {

        OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);

        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conn;
        cmd.CommandText = "DELETE FROM Users WHERE userID=" + Session["userid"];
        cmd.CommandType = CommandType.Text;

        int affected = 0;

        try
        {
            conn.Open();
            affected = cmd.ExecuteNonQuery();
            conn.Close();
        }

        catch (Exception ex)
        {
            Label1.Text = "Error: " + ex.Message;
            return;
        }
        if (affected == 1)
        {
            Session.Clear();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your account has been deleted. You are directing homepage');window.location ='homepage.aspx';", true);
        }
        else
        {
            Label1.Text = "Error, user can not deleted";
        }
    }
}