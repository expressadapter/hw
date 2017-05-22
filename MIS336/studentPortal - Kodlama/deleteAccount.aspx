<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="deleteAccount.aspx.cs" Inherits="deleteAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
        <div class="nav-side-menu">
        <div class="brand">Dashboard</div>
        <i class="fa fa-bars fa-2x toggle-btn" data-toggle="collapse" data-target="#menu-content"></i>

        <div class="menu-list">

            <ul id="menu-content" class="menu-content collapse out">
                <li>
                    <a href="/profile.aspx">
                        <i class="fa fa-dashboard fa-lg"></i>Dashboard
                </a>
                </li>

                <li data-toggle="collapse" data-target="#products" class="collapsed">
                    <a href="#"><i class="fa fa-user fa-lg"></i>Profile <span class="arrow"></span></a>
                </li>
                <ul class="sub-menu collapse" id="products">
                    <li><a href="/editInfo.aspx">Edit Info</a></li>
                    <li><a href="/deleteAccount.aspx">Delete Account</a></li>
      
                </ul>


                <li data-toggle="collapse" data-target="#service" class="collapsed">
                    <a href="#"><i class="fa fa-globe fa-lg"></i>Files <span class="arrow"></span></a>
                </li>
                <ul class="sub-menu collapse" id="service">
                    <li><a href="/download.aspx">Download a File</a></li>
                    <li><a href="/upload.aspx">Upload a File</a></li>
              
                </ul>





     
            </ul>
        </div>
    </div>
        </asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    

     <div class="col-md-8 col-md-offset-2" style="padding-top: 3em;">
        <div class="thumbnail">

            <div class="caption-full" style="padding:1em;">
                <br />
                 <p>
                            <h2>Delete Account <asp:Button ID="Button1" runat="server" Text="Delete" CssClass="btn btn-danger pull-right" OnClick="deleteAccount_Click" /></h2>
                        </p>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <br />
            </div>

        </div>
    </div>

</asp:Content>
