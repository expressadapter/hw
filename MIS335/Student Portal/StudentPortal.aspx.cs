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
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //Add New User
    protected void addNewUser_Click(object sender,EventArgs e)
    {
        string nameUser = userName.Text;
        string passwordUser = userPassword.Text;
        string roleUser = userRole.Text;
        string mailUser = userMail.Text;
        string idUser = userID.Text;
       
        SqlConnection connn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
        SqlCommand cm = connn.CreateCommand();
        cm.CommandText = @"INSERT INTO [Users]([userID],[userRole],[userName] ,[userPassword],[userMail] )
                              VALUES(@ID,@Role,@Name,@Password,@Mail)";
        cm.CommandType = CommandType.Text;
        cm.Parameters.AddWithValue("@ID", idUser);
        cm.Parameters.AddWithValue("@Role",roleUser);
        cm.Parameters.AddWithValue("@Name", nameUser);
        cm.Parameters.AddWithValue("@Password", passwordUser);
        cm.Parameters.AddWithValue("@Mail", mailUser);

        resultLabel.Visible = true;
        int affected = 0;

        try
        {
            connn.Open();
            affected = cm.ExecuteNonQuery();
            connn.Close();
        }

        catch (Exception ex)
        {
            resultLabel.Text = "Error" + ex.Message;
            return;
        }

        finally
        {
            if (connn.State != ConnectionState.Closed)
            {
                connn.Close();
            }
        }

        if (affected == 1)
        {
            resultLabel.Text = "User added to database";
        }
        else
        {
            resultLabel.Text = "User can not added to database";
        }

    }
    protected void addNewCourse_Click(object sender, EventArgs e) {
        string courseId = TextBox1.Text;
        string courseCode = TextBox2.Text;
        string courseName = TextBox3.Text;
        string department = TextBox4.Text;

        SqlConnection connn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
        SqlCommand cm = connn.CreateCommand();
        cm.CommandText = @"INSERT INTO [Courses]([courseID],[courseCode] ,[courseName],[department] )
                              VALUES(@ID,@Role,@Name,@Password)";
        cm.CommandType = CommandType.Text;
        cm.Parameters.AddWithValue("@ID", courseId);
        cm.Parameters.AddWithValue("@Role", courseCode);
        cm.Parameters.AddWithValue("@Name", courseName);
        cm.Parameters.AddWithValue("@Password", department);
        
        Label1.Visible = true;
        int affected = 0;

        try
        {
            connn.Open();
            affected = cm.ExecuteNonQuery();
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

        if (affected == 1)
        {
            Label1.Text = "Course added to database";
        }
        else
        {
            Label1.Text = "Course can not added to database";
        }
    }
    protected void query1_Click(object sender,EventArgs e){
        //Populating a DataTable from database.
        DataTable dt=new DataTable();
    
        SqlConnection connn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
        SqlCommand cm = connn.CreateCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        cm.CommandText = @"SELECT userName, materialName, uploadDate 
                           FROM  Users 
                           INNER JOIN UploadedMaterials
	                       ON Users.userID=UploadedMaterials.uploadedBy";
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
            Label2.Visible = true;
            Label2.Text = "Error" + ex.Message;
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
    protected void query2_Click(object sender, EventArgs e)
    {
        //Populating a DataTable from database.
        DataTable dt = new DataTable();

        SqlConnection connn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
        SqlCommand cm = connn.CreateCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        cm.CommandText = @"SELECT UM.MaterialName
                            FROM  UploadedMaterials UM
                            WHERE UM.numberOfDownloads = (SELECT MAX(UM2.numberOfDownloads)
			           FROM UploadedMaterials UM2)";
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
            Label2.Visible = true;
            Label2.Text = "Error" + ex.Message;
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
    protected void query3_Click(object sender, EventArgs e)
    {
        //Populating a DataTable from database.
        DataTable dt = new DataTable();

        SqlConnection connn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
        SqlCommand cm = connn.CreateCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        cm.CommandText = @"SELECT userID, courseName
FROM Courses INNER JOIN Follows
	ON Courses.courseID=Follows.courseID
";
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
            Label2.Visible = true;
            Label2.Text = "Error" + ex.Message;
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
    protected void query4_Click(object sender, EventArgs e)
    {
        //Populating a DataTable from database.
        DataTable dt = new DataTable();

        SqlConnection connn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
        SqlCommand cm = connn.CreateCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        cm.CommandText = @"SELECT userName
FROM Users
WHERE EXISTS 
  (SELECT *
   FROM Comments
   WHERE Users.userID = Comments.commentedBy)";
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
            Label2.Visible = true;
            Label2.Text = "Error" + ex.Message;
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
    protected void query5_Click(object sender, EventArgs e)
    {
        //Populating a DataTable from database.
        DataTable dt = new DataTable();

        SqlConnection connn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
        SqlCommand cm = connn.CreateCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        cm.CommandText = @"SELECT userName,userMail
FROM Users
WHERE userID = ANY
       (SELECT userID
          FROM Courses INNER JOIN Follows 
		  ON Courses.courseID=Follows.courseID
          WHERE Courses.courseName ='Database Systems')
";
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
            Label2.Visible = true;
            Label2.Text = "Error" + ex.Message;
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
    protected void query6_Click(object sender, EventArgs e)
    {
        //Populating a DataTable from database.
        DataTable dt = new DataTable();

        SqlConnection connn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
        SqlCommand cm = connn.CreateCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        cm.CommandText = @"SELECT AVG ( DISTINCT Rates.rating) as AvgRating
FROM Rates
WHERE Rates.materialID=ANY(SELECT materialID 
							FROM UploadedMaterials INNER JOIN Courses
							ON Courses.courseID=UploadedMaterials.course
							WHERE Courses.courseName ='Database Systems')";
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
            Label2.Visible = true;
            Label2.Text = "Error" + ex.Message;
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
    protected void query7_Click(object sender, EventArgs e)
    {
        //Populating a DataTable from database.
        DataTable dt = new DataTable();

        SqlConnection connn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
        SqlCommand cm = connn.CreateCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        cm.CommandText = @"SELECT COUNT(*)
FROM Users
WHERE EXISTS 
  (SELECT *
   FROM UploadedMaterials
   WHERE Users.userID = UploadedMaterials.uploadedBy);
";
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
            Label2.Visible = true;
            Label2.Text = "Error" + ex.Message;
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
    protected void query8_Click(object sender, EventArgs e)
    {
        //Populating a DataTable from database.
        DataTable dt = new DataTable();

        SqlConnection connn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
        SqlCommand cm = connn.CreateCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        cm.CommandText = @"SELECT courseName
FROM Courses
WHERE courseID=(SELECT TOP 1  course 
				FROM UploadedMaterials 
				GROUP BY course
				ORDER BY count(*) DESC )
";
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
            Label2.Visible = true;
            Label2.Text = "Error" + ex.Message;
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
}
