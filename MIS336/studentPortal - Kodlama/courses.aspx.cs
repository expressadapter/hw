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

public partial class courses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        DataTable dt = new DataTable();

        OleDbConnection connn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
        OleDbCommand cm = connn.CreateCommand();
        OleDbDataAdapter sda = new OleDbDataAdapter();

        cm.CommandText = "SELECT *  FROM Courses";





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
    protected void delete_Click(object sender, EventArgs e)
    {

        OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);


        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conn;
        cmd.CommandText = "Delete From Courses Where cid=" + deleteid.Text;
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
            Label2.Text = "Course is deleted from list";
            Response.Redirect("/courses.aspx");
        }
        else
        {
            Label2.Text = "Error, course can not deleted";
        }
    }
    protected void addCourse_Click(object sender, EventArgs e)
    {
       
            OleDbConnection connn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);// Creating new database connection by using settings defined in Web.config file <connectionString> tag 

            OleDbCommand cm = connn.CreateCommand();// Creating database comand to insert new values
            cm.CommandText = @"INSERT INTO [Courses]([ccode],[cname],[department],[university])
                              VALUES(@name,@surname,@bdate,@university)";
            cm.CommandType = CommandType.Text;

            // Checking are string values empty, if they empty assign them Null value
            cm.Parameters.AddWithValue("@name", addcode.Text);
            cm.Parameters.AddWithValue("@surname", addname.Text);
            cm.Parameters.AddWithValue("@bdate", dept.Text);
            cm.Parameters.AddWithValue("@university", uni.Text);


            int affected = 0; // Variable to check database insert operation successful or not

            try
            {
                connn.Open(); //Open database connection
                affected = cm.ExecuteNonQuery(); // Execute insert operation
                connn.Close(); // Close databae connection
            }

            catch (Exception ex)  // Catch database errors
            {
                Label.Text = "Error: " + ex.Message; // Show database error at resultLabel 

                return;
            }

            finally
            {
                if (connn.State != ConnectionState.Closed)
                {
                    if (affected == 1) // If database insert operation successful
                    {
                        Label.Text = "Successful";
                        Response.Redirect("/courses.aspx");

                    }
                
                    else
                    {
                        Label.Text = "Unsuccessful";// Resultlabel empty string


                    }

                    connn.Close();
                }
            }
        }
    
}