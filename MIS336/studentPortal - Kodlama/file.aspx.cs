using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class filedetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isLogin"] == null)
        {
            this.Master.FindControl("button1").Visible = false;
        }
        if (Request.QueryString["id"] != null)
        {
            


                OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);



                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT * FROM UploadedMaterials INNER JOIN Users ON UploadedMaterials.uploadedBy = Users.userID  WHERE fileid=" + Request.QueryString["id"];
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                DataTable dtUser = new DataTable();

                OleDbDataAdapter daRead = new OleDbDataAdapter(cmd);
                daRead.Fill(dtUser);

                if (dtUser.Rows.Count > 0)
                {

                    Label1.Text = dtUser.Rows[0]["filename"].ToString();
                    Label2.Text = dtUser.Rows[0]["filetype"].ToString();
                    TextBox1.Text = dtUser.Rows[0]["description"].ToString();
                    Label4.Text = dtUser.Rows[0]["name"].ToString()+" "+ dtUser.Rows[0]["surname"].ToString();

                }
                conn.Close();


                OleDbConnection connn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
                OleDbCommand cm = connn.CreateCommand();
                OleDbDataAdapter sda = new OleDbDataAdapter();

                DataTable dt = new DataTable();
                cm.CommandText = "SELECT commentText AS Comment, commentDate AS CommentDate  FROM Comments WHERE commentedTo=" + Request.QueryString["id"];





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
        else
            {
                Response.Redirect("homepage.aspx");
            }
        }
    protected void addComment_Click(object sender, EventArgs e)
    {

        OleDbConnection connn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);// Creating new database connection by using settings defined in Web.config file <connectionString> tag 
        DateTime uploadDate = new DateTime();
        uploadDate = DateTime.Today;

        OleDbCommand cm = connn.CreateCommand();// Creating database comand to insert new values
        cm.CommandText = @"INSERT INTO [Comments]([commentedBy],[commentedTo],[commentText],[commentDate])
                              VALUES(@name,@surname,@bdate,@date)";
        cm.CommandType = CommandType.Text;

        // Checking are string values empty, if they empty assign them Null value
        cm.Parameters.AddWithValue("@name", Convert.ToInt32(Session["userid"]));
        cm.Parameters.AddWithValue("@surname", Convert.ToInt32(Request.QueryString["id"]));
        cm.Parameters.AddWithValue("@bdate", TextBox2.Text);
        cm.Parameters.Add("@date", uploadDate);

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
                    Response.Redirect("/file.aspx?id="+ Request.QueryString["id"]);

                }

                else
                {
                    Label.Text = "Unsuccessful";// Resultlabel empty string


                }

                connn.Close();
            }
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string fName = @"C:\Users\Emre\Desktop\studentPortal - Kodlama\Uploads\"+Label1.Text;
        FileInfo fi = new FileInfo(fName);
       

        Response.ClearContent();
        Response.ContentType = MimeType(Path.GetExtension(fName));
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(fName)));
        Response.TransmitFile(fName);
        Response.End();
    }
    public static string MimeType(string Extension)
    {
        string mime = "application/octetstream";
        if (string.IsNullOrEmpty(Extension))
            return mime;
        string ext = Extension.ToLower();
        Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        if (rk != null && rk.GetValue("Content Type") != null)
            mime = rk.GetValue("Content Type").ToString();
        return mime;
    }
}

