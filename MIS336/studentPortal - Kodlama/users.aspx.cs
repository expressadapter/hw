using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String search = Request.QueryString["search"];
        DataTable dt = new DataTable();

        OleDbConnection connn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
        OleDbCommand cm = connn.CreateCommand();
        OleDbDataAdapter sda = new OleDbDataAdapter();

        cm.CommandText = "SELECT *  FROM Users";





        cm.CommandType = CommandType.Text;

        try
        {
            connn.Open();
            sda.SelectCommand = cm;
            sda.Fill(dt);
            connn.Close();
        }

        catch (Exception ex)
        {

            Label1.Text = "Error" + ex.Message;
            return;
        }

        finally
        {
            if (connn.State != ConnectionState.Closed)
            {
                connn.Close();
            }
        }

        {
            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            html.Append(" <div class='panel panel-default'>");
            html.Append(" <div class='panel - body'>");
            html.Append("<table class = 'table'>");

            //Building the Header row.
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<th>");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            html.Append("<th></th>");
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("<td>");
                html.Append("</tr>");
            }
            //Table end.
            html.Append("</table>");
            html.Append("</div>");
            html.Append("</div>");
            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        }
    }
    protected void delete_Click(object sender, EventArgs e) {

        OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
  

        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conn;
        cmd.CommandText = "Delete From Users Where id=" + deleteid.Text;
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
            Label2.Text = "Error: " + ex.Message;
            return;
        }
        if (affected == 1)
        {
            Label2.Text = "User is deleted from list";
            Response.Redirect("list.aspx");
        }
        else
        {
            Label2.Text = "Error, user can not deleted";
        }
    }
}