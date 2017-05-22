<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

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
<br />
    
    


</asp:Content>
