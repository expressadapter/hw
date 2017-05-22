<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="_Default" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <!--Left Block Starts -->
      <div id="left_block"> <span class="blk1_lp"> <span class="our">RMS Login<br />
          <span class="usr" style="margin-top:12px;">
          <br />
          User Name:</span><br />
          <span class="usr">
          <asp:TextBox ID="nameBox" runat="server" Width="121px" ></asp:TextBox>
          <br />
          Password:<br />
          <asp:TextBox ID="passwordBox" runat="server" Width="121px"></asp:TextBox>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click1" />
          <asp:Label ID="loginErrorLabel" runat="server" Text="Label" Visible="False"></asp:Label>
          &nbsp;&nbsp;&nbsp;
          
          <br />
          <br />
          </span></span> &nbsp;<span class="usr" style="margin-top:12px;"><br />
          </span>&nbsp;
        <span class="usr">
          <br />
          <br />
          <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <br />
          <br />
          <br />
          </span>
        &nbsp;&nbsp;&nbsp;
        </span> <span class="blk2_lp"> <span class="nws">News </span>&nbsp;<span class="dat" style="margin-top:22px;"><span>12-10-2007</span><br />
        Let us turn your stressful environment into a tranquil setting with plants.</span> <span class="dat"><span>04-11-2007</span><br />
        Trees and blooming plants will create and and more.Trees and blooming plants will create and and more.</span> <span class="dat"><span>11-01-2008</span><br />
        impressive entrance for your clients and a relaxing area for your employees. <span>04-02-2008</span><br />
        Let us turn that empty into a company oasis! trees and blooming plants will create.</span> <span class="dat"><span>04-11-2007</span><br />
        Trees and blooming plants will create and and more.</span> <span class="dat"><span>11-01-2008</span><br />
        impressive entrance for your clients and a relaxing area for your employees. Trees and blooming plants will create and and more.&nbsp;
        </span> </span> </div>
         </asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <div id="right_block">
        <span class="modul"><span class="wel">Welcome to Registration Management System</span> <span class="inr_bllk">
        <img src="images/map.gif" width="195" height="120" class="flr" alt="" /> </span>&nbsp;</span><img src="images/rp_ln.gif" alt="" class="rp_ln" /> <span class="blks"><span class="special"><span class="clnt"><span class="our">Calendar<br />
        <asp:Calendar ID="Calendar1" runat="server" Height="244px" Width="265px"></asp:Calendar>
        </span></span><br />
&nbsp;</span><span class="widt">
       
    </div><title></title>





    </span></span>





</asp:Content>

