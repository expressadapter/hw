<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="users.aspx.cs" Inherits="users" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
   
        <div class="nav-side-menu">
            <div class="brand">Dashboard</div>
            <i class="fa fa-bars fa-2x toggle-btn" data-toggle="collapse" data-target="#menu-content"></i>

            <div class="menu-list">

                <ul id="menu-content" class="menu-content collapse out">
                    <li>
                        <a href="/admin.aspx">
                            <i class="fa fa-dashboard fa-lg"></i>Dashboard
                </a>
                    </li>

                    <li>
                        <a href="/users.aspx">
                            <i class="fa fa-users fa-lg"></i>Users
                </a>
                    </li>

                    <li>
                        <a href="/courses.aspx">
                            <i class="fa fa-book fa-lg"></i>Courses
                </a>
                    </li>

                    <li>
                        <a href="/files.aspx">
                            <i class="fa fa-file fa-lg"></i>Files
                </a>
                    </li>

                    <li>
                        <a href="/comments.aspx">
                            <i class="fa fa-comments fa-lg"></i>Comments
                </a>
                    </li>








                </ul>
            </div>
        </div>


    <div class="col-md-8 col-md-offset-3" style="padding-top: 3em;">


        <div class="thumbnail">

            <div class="caption-full table-responsive" style="padding: 1em;">
                <br />

                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>


                <br />


            </div>



        </div>
        <div class="thumbnail col-md-4  ">
               
                    <div class="caption-full" style="padding: 1em;">
                         <p class="lead">Delete User</p>
                        
                        
                  
                       <asp:TextBox ID="deleteid" runat="server" CssClass="form-control"></asp:TextBox>
                        
                        
                        <br />
                        <asp:Button ID="delete" runat="server" Text="Delete" CssClass="btn btn-danger btn-lg pull-right" placeholder="id" OnClick="delete_Click" />
                       
                        <br />  <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                        <br />
                    </div>
                        
                </div>
            
        <div class="col-md-4"></div>


    </div>
        
   


</asp:Content>

