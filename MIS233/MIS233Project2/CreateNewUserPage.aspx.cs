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

public partial class CreateNewUserPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
        {
            Response.Redirect("HomePage.aspx");

        }




        if ((string)Session["Type"] == "admin")
        {

            askConsent.Visible = false;
            addCourse.Visible = false;
            viewCourseList.Visible = false;
            profConsent.Visible = false;
            viewCourseStudentList.Visible = false;
            submitGrade.Visible = false;
        }
        if ((string)Session["Type"] == "prof")
        {

            askConsent.Visible = false;
            addCourse.Visible = false;
            viewCourseList.Visible = false;
            newUser.Visible = false;
            deactivateUser.Visible = false;
            newCourse.Visible = false;
            listAllUsers.Visible = false;
            rmsRules.Visible = false;
            reportStatistics.Visible = false;

        }
        if ((string)Session["Type"] == "student")
        {

            profConsent.Visible = false;
            viewCourseStudentList.Visible = false;
            submitGrade.Visible = false;
            newUser.Visible = false;
            deactivateUser.Visible = false;
            newCourse.Visible = false;
            listAllUsers.Visible = false;
            rmsRules.Visible = false;
            reportStatistics.Visible = false;

        }


          newUser.Visible = false;


    }



    protected void addUser_Click(object sender, EventArgs e)
    {
        string nameUser = userName.Text;
        string passwordUser = userPassword.Text;
        string typeUser = userType.Text;

            string sif = userPassword.Text;
            string paswd = FormsAuthentication.HashPasswordForStoringInConfigFile(sif, "md5");
            SqlConnection connn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
            SqlCommand cm = connn.CreateCommand();
            cm.CommandText = @"INSERT INTO [Users]([UserName] ,[Password],[Type] )
                              VALUES(@UserName,@Password,@Type)";
            cm.CommandType = CommandType.Text;
            cm.Parameters.AddWithValue("@UserName", nameUser);
            cm.Parameters.AddWithValue("@Password", paswd);
            cm.Parameters.AddWithValue("@Type", typeUser);


        passwordErrorLabel.Visible = true;
        int affected = 0;

        try
        {
            connn.Open();
            affected = cm.ExecuteNonQuery();
            connn.Close();
        }

        catch (Exception ex)
        {
            passwordErrorLabel.Text = "Error" + ex.Message;
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
           passwordErrorLabel.Text = "User added to database";
        }
        else
        {
           passwordErrorLabel.Text = "User can not added to database";
        }

    }

    //redirects

    protected void logOutButton_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Contents.Abandon();
        Session.Contents.RemoveAll();
        Response.Redirect("HomePage.aspx");
    }
    protected void changePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangePasswordPage.aspx");
    }

    protected void newUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateNewUserPage.aspx");
    }
    protected void newCourse_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateNewCourse.aspx");
    }

    protected void askConsent_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserPage.aspx");
    }

    protected void addCourse_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserPage.aspx");
    }

    protected void viewCourseList_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserPage.aspx");
    }

    protected void profConsent_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserPage.aspx");
    }

    protected void viewCoursesStudentList_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserPage.aspx");
    }

    protected void submitGrade_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserPage.aspx");
    }

    protected void deactivateUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("DeactivateActivatePage.aspx");
    }

    protected void listAllUsers_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserPage.aspx");
    }

    protected void rmsRules_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserPage.aspx");
    }

    protected void reportStatistics_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserPage.aspx");
    }

}