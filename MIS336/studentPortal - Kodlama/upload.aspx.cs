using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using System.Data;

public partial class upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["isLogin"] == null)
        {
            Response.Redirect("/homepage.aspx");
        }
        if (!IsPostBack)
        {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);

            conn.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM Courses";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            DataTable dtUser = new DataTable();

            OleDbDataAdapter daRead = new OleDbDataAdapter(cmd);
            daRead.Fill(dtUser);

            foreach (DataRow row in dtUser.Rows)
            {

                DropDownList1.Items.Add(new ListItem(row[dtUser.Columns[1].ColumnName].ToString() + " " + row[dtUser.Columns[2].ColumnName].ToString(), row[dtUser.Columns[0].ColumnName].ToString()));

            }


            conn.Close();
        }
    }
    protected void upload_Click(object sender, EventArgs e)
    {
        if (FileUploadControl.HasFile)
        {
            try
            {
               
                    if (FileUploadControl.PostedFile.ContentLength < 5242880)
                    {
                        string filename = TextBox1.Text;
                       
                        FileUploadControl.SaveAs(Server.MapPath("~/Uploads/") + filename);
                        Label.Text = "Upload status: File uploaded!";

                        
                        String fileType = FileUploadControl.PostedFile.ContentType;
                        int filesize = FileUploadControl.PostedFile.ContentLength;
                        DateTime uploadDate = new DateTime();
                        uploadDate = DateTime.Today;

                        OleDbConnection connn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);

                        OleDbCommand cm = connn.CreateCommand();// Creating database comand to insert new values
                        cm.CommandText = @"INSERT INTO [UploadedMaterials]([filetype],[filename],[filesize],[uploadDate],[uploadedBy],[courseid],[description])
                              VALUES(@name,@surname,@bdate,@university,@by,@to,@desc)";
                        cm.CommandType = CommandType.Text;

                        // Checking are string values empty, if they empty assign them Null value
                        cm.Parameters.AddWithValue("@name", fileType);
                        cm.Parameters.AddWithValue("@surname", filename);
                        cm.Parameters.AddWithValue("@bdate", filesize);
                        cm.Parameters.Add("@university", uploadDate);
                        cm.Parameters.Add("@by", Convert.ToInt32(Session["userid"]));
                        cm.Parameters.Add("@to", Convert.ToInt32(DropDownList1.SelectedValue));
                        cm.Parameters.AddWithValue("@desc", TextBox2.Text);



                        int affected = 0; // Variable to check database insert operation successful or not

                        try
                        {
                            connn.Open(); //Open database connection
                            affected = cm.ExecuteNonQuery(); // Execute insert operation
                            connn.Close(); // Close databae connection
                        }

                        catch (Exception ex)  // Catch database errors
                        {
                            Label2.Text = "Error: " + ex.Message; // Show database error at resultLabel 

                            return;
                        }
                        finally
                        {
                            if (connn.State != ConnectionState.Closed)
                            {
                                if (affected == 1) // If database insert operation successful
                                {
                               

                                }
                                connn.Close();
                            }
                        }
                    }
                    else
                        Label.Text = "Upload status: The file has to be less than 5 mb!";
                
              
            }
            catch (Exception ex)
            {
                Label.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    }
}
/*

                        String filename = TextBox1.Text;
                        String fileType = FileUpload1.PostedFile.ContentType;
                        int filesize = FileUpload1.PostedFile.ContentLength;
                        DateTime uploadDate = new DateTime();
                        uploadDate = DateTime.Today;

                        OleDbConnection connn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);

                        OleDbCommand cm = connn.CreateCommand();// Creating database comand to insert new values
                        cm.CommandText = @"INSERT INTO [UploadedMaterials]([filetype],[filename],[filesize],[uploadDate],[uploadedBy],[courseid],[description])
                              VALUES(@name,@surname,@bdate,@university,@by,@to,@desc)";
                        cm.CommandType = CommandType.Text;

                        // Checking are string values empty, if they empty assign them Null value
                        cm.Parameters.AddWithValue("@name", fileType);
                        cm.Parameters.AddWithValue("@surname", filename);
                        cm.Parameters.AddWithValue("@bdate", filesize);
                        cm.Parameters.Add("@university", uploadDate);
                        cm.Parameters.Add("@by", Convert.ToInt32(Session["userid"]));
                        cm.Parameters.Add("@to", Convert.ToInt32(DropDownList1.SelectedValue));
                        cm.Parameters.AddWithValue("@desc", TextBox2.Text);



                        int affected = 0; // Variable to check database insert operation successful or not

                        try
                        {
                            connn.Open(); //Open database connection
                            affected = cm.ExecuteNonQuery(); // Execute insert operation
                            connn.Close(); // Close databae connection
                        }

                        catch (Exception ex)  // Catch database errors
                        {
                            Label2.Text = "Error: " + ex.Message; // Show database error at resultLabel 

                            return;
                        }
                        finally
                        {
                            if (connn.State != ConnectionState.Closed)
                            {
                                if (affected == 1) // If database insert operation successful
                                {
                                    Label1.Text = "Upload status: File uploaded!";
                                    FileUpload1.SaveAs(Server.MapPath("~/Uploads/"+ filename) );

                                }
                                connn.Close();
                            }
                        }
*/