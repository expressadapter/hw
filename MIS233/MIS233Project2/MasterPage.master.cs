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

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
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
   
    