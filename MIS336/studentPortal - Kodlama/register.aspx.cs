/*
-------------------------Student Portal Registration-----------------------------------
                                    v 1.0
   
  This is the server side of registration process. At server side it will take validated
  form values, check for empty and null values and if everything is okay it will insert  
  data to database. 

--------------------------------------Notes--------------------------------------------
    
  All form validation operations are made at client side. At server side we only check 
  empty or null values.   
 

*/

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


public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
    /*
    -------------------------registerSubmit_Click()---------------------------------

    This function takes submitted form values and assigns them to new variables 
    and then it connects to database to insert new registration data to Users 
    table. Finally it shows message according to result of database operation 
    and if it is a successful registration it redirects user to homepage otherwise
    user stays at registration page. 
          
    -----------------------------------------------------------------------------------                    
    */
    protected void registerSubmit_Click(object sender, EventArgs e)
    {
        // Assinging form values to new variables
        string name = signupName.Text;
        string surname = signupSurname.Text;
        string birthdate = signupBday.Text;
        string university = signupUniversity.Text;
        string department = signupDepartment.Text;
        string mail = signupEmail.Text;
        string password = signupPassword.Text;
        DateTime bDateparam = new DateTime(); // Creating new DateTime object


        if (!string.IsNullOrEmpty(birthdate))// Checking birthdate variable is not null or empty string
        {
            bDateparam = Convert.ToDateTime(birthdate);// Converting birthdate variable value to DateTime and assing that new value to bDateparam variable
        }


        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);// Creating new database connection by using settings defined in Web.config file <connectionString> tag 

        OleDbCommand cm = con.CreateCommand();// Creating database comand to insert new values
        cm.CommandText = @"INSERT INTO [Users]([name],[surname],[birthdate] ,[university],[department],[email],[upassword])
                              VALUES(@name,@surname,@bdate,@university,@department,@email,@password)";
        cm.CommandType = CommandType.Text;

        // Checking are string values empty, if they empty assign them Null value
        cm.Parameters.AddWithValue("@name", string.IsNullOrEmpty(name) ? (object)DBNull.Value : name);
        cm.Parameters.AddWithValue("@surname", string.IsNullOrEmpty(surname) ? (object)DBNull.Value : surname);
        cm.Parameters.Add("@bdate", OleDbType.Date).Value = bDateparam;
        cm.Parameters.AddWithValue("@university", string.IsNullOrEmpty(university) ? (object)DBNull.Value : university);
        cm.Parameters.AddWithValue("@department", string.IsNullOrEmpty(department) ? (object)DBNull.Value : department);
        cm.Parameters.AddWithValue("@email", string.IsNullOrEmpty(mail) ? (object)DBNull.Value : mail);
        cm.Parameters.AddWithValue("@password", string.IsNullOrEmpty(password) ? (object)DBNull.Value : password);


        int affect = 0; // Variable to check database insert operation successful or not

        try
        {
            con.Open(); //Open database connection
            affect = cm.ExecuteNonQuery(); // Execute insert operation
            con.Close(); // Close databae connection
        }

        catch (Exception ex)  // Catch database errors
        {
            resultLabel.Text = "Error: " + ex.Message; // Show database error at resultLabel 

            return;
        }

        finally
        {
            if (con.State != ConnectionState.Closed)
            {
                if (affect == 1) // If database insert operation successful
                {
                    resultLabel.Text = "olumlu";

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You are registered to Hayrına Sınav Notları, please check your e-mail account for confirmation link');window.location ='homepage.aspx';", true);// Alert success message and redirect user to homepage

                }
                else
                {
                    resultLabel.Text = "olumsuz";// Resultlabel empty string
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You are already registered, please try to login.')", true); // Alert user is already registered

                }

                con.Close();
            }
        }

        

    }// end
    
}