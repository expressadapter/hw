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

public partial class MyPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null) {
            Response.Redirect("HomePage.aspx");

        }
        if (Session["Type"] != null) 
        welcomeLabel.Text = "Welcome " + (string)Session["UserName"];

   

        if ((string)Session["Type"] == "admin") {
    
            askConsent.Visible = false;
            addCourse.Visible = false;
            viewCourseList.Visible = false;
            profConsent.Visible = false;
            viewCourseStudentList.Visible = false;
            submitGrade.Visible = false;
        }
        if ((string)Session["Type"] == "prof") { 

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
        if ((string)Session["Type"] == "student") { 
            
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

        }

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



    protected void deactivateUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("DeactivateActivatePage.aspx");
    }
}
