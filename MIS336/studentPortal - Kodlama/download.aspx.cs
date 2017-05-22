using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Text;


public partial class download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isLogin"] == null) {
            this.Master.FindControl("button1").Visible = false;
        }



        String search = Request.QueryString["search"];
        DataTable dt = new DataTable();

        OleDbConnection connn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
        OleDbCommand cm = connn.CreateCommand();
        OleDbDataAdapter sda = new OleDbDataAdapter();

        cm.CommandText = "SELECT fileid AS ID, filename AS File, filetype AS Type, Courses.ccode AS CourseCode, Courses.cname AS CourseName, department AS Department, university AS University  FROM UploadedMaterials INNER JOIN Courses ON UploadedMaterials.courseid = Courses.cid  WHERE Courses.ccode LIKE '" + search + "%' UNION SELECT fileid AS ID, filename AS File, filetype AS Type, Courses.ccode AS CourseCode, Courses.cname AS CourseName, department AS Department, university AS University FROM UploadedMaterials INNER JOIN Courses ON UploadedMaterials.courseid = Courses.cid  WHERE Courses.cname LIKE '" + search + "%'";





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
            html.Append(" <div class='panel panel-default table-responsive'>");
            html.Append(" <div class='panel - body  '>");
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
                html.Append("<td><a href='/file.aspx?id=");
                html.Append(row[dt.Columns[0].ColumnName]);
                html.Append("'>Details</a></td>");
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
    protected void search_Click(object sender,EventArgs e) {
        Response.Redirect("/download.aspx?search=" + TextBox1.Text);
    }
}
