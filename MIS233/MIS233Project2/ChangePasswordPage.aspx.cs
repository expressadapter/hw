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

public partial class ChangePasswordPage : System.Web.UI.Page
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


        changePassword.Visible = false;


    }



    protected void updatePassword_Click(object sender, EventArgs e)
    {
        string passwordNew = newPassword.Text;
        string passwordConfirm = confirmPassword.Text;

        if (passwordNew == passwordConfirm)
        {
            string sif = newPassword.Text;
            string paswd = FormsAuthentication.HashPasswordForStoringInConfigFile(sif, "md5");
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
            SqlCommand cm = conn.CreateCommand();
            cm.CommandText = @"Update [Users] SET
                              Password=@Password where UserName=@UserName";
            cm.CommandType = CommandType.Text;
            cm.Parameters.AddWithValue("@UserName", (string)Session["UserName"]);
            cm.Parameters.AddWithValue("@Password", paswd);

            passwordErrorLabel.Visible = true;

            int affected = 0;

            try
            {
                conn.Open();
                affected = cm.ExecuteNonQuery();
                conn.Close();
            }

            catch (Exception ex)
            {
                passwordErrorLabel.Text = "Error" + ex.Message;
                return;
            }

            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            if (affected == 1)
            {
                passwordErrorLabel.Text = "Password is changed";
            }
            else
            {
                passwordErrorLabel.Text = "Error, Password can not change";
            }
        }
        else
        {
            passwordErrorLabel.Visible = true;
            passwordErrorLabel.Text = "Passwords are not same!";
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