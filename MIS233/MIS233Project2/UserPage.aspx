<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserPage.aspx.cs" Inherits="MyPage" %>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <div id="right_block">
        <span class="modul"><span class="wel">
            <asp:Label ID="welcomeLabel" runat="server" Text="Label"></asp:Label></span> <span class="inr_bllk">
        &nbsp;
    </div>
    </span></span>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder1">
         <!--Left Block Starts -->
      <div id="left_block"> <span class="blk1_lp"> 
             <br />
             <span class="our">RMS User Page</span><br />
             <asp:Button ID="logOutButton" runat="server" Height="32px" Text="Log Out" Width="185px" OnClick="logOutButton_Click" />
          <br />
             <asp:Button ID="changePassword" runat="server" Height="32px" Text="Change Password" Width="185px" OnClick="changePassword_Click" />
          <br />
             <asp:Button ID="askConsent" runat="server" Height="32px" Text="Ask for Consent" Width="185px" />
          <br />
             <asp:Button ID="addCourse" runat="server" Height="32px" Text="Add Course" Width="185px" />
          <br />
             <asp:Button ID="viewCourseList" runat="server" Height="32px" Text="View Course List" Width="185px" />
          <br />
             <asp:Button ID="profConsent" runat="server" Height="32px" Text="V/P Consent Requests" Width="185px" />
          <br />
             <asp:Button ID="viewCourseStudentList" runat="server" Height="32px" Text="View Course and Student List" Width="185px" />
             <br />
             <asp:Button ID="submitGrade" runat="server" Height="32px" Text="Submit Grade" Width="185px" />
             <br />
             <asp:Button ID="newUser" runat="server" Height="32px" Text="New User" Width="185px" OnClick="newUser_Click" />
             <br />
             <asp:Button ID="deactivateUser" runat="server" Height="32px" Text="Deactivate User" Width="185px" OnClick="deactivateUser_Click"  />
             <br />
             <asp:Button ID="newCourse" runat="server" Height="32px" Text="New Course" Width="185px" OnClick="newCourse_Click"/>
             <br />
             <asp:Button ID="listAllUsers" runat="server" Height="32px" Text="List All Users" Width="185px" />
             <br />
             <asp:Button ID="rmsRules" runat="server" Height="32px" Text="RMS Rules" Width="185px" />
             <br />
             <asp:Button ID="reportStatistics" runat="server" Height="32px" Text="Report Statistics" Width="185px" />
             <br />
        </span> </div>
         </asp:Content>

