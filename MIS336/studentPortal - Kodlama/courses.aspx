<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="courses.aspx.cs" Inherits="courses" %>

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
                         <p class="lead">Delete Course</p>
                        
                        
                  
                       <asp:TextBox ID="deleteid" runat="server" CssClass="form-control"></asp:TextBox>
                        
                        
                        <br />
                        <asp:Button ID="delete" runat="server" Text="Delete" CssClass="btn btn-danger btn-md pull-right" placeholder="id" OnClick="delete_Click" />
                       
                        <br />  <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                        <br />
                    </div>
                        
                </div>
            
       <div class="thumbnail col-md-4 col-md-offset-1" style="margin-bottom:5em;">
               
                    <div class="caption-full" style="padding: 1em;">
                         <p class="lead">Add Course</p>
                        
                        
                        
                        <label for="name">Course Code</label> <asp:TextBox ID="addcode" runat="server" CssClass="form-control"></asp:TextBox>
                        <label for="name">Course Name</label> <asp:TextBox ID="addname" runat="server" CssClass="form-control"></asp:TextBox>
                        <label for="name">University</label> <asp:TextBox ID="uni" runat="server" CssClass="form-control"></asp:TextBox>
                                 <label for="name">Department</label> <asp:TextBox ID="dept" runat="server" CssClass="form-control"></asp:TextBox>
                        <br />
                        
                        <asp:Button ID="addCourse" runat="server" Text="Add" CssClass="btn btn-success btn-md pull-right" OnClick="addCourse_Click" />
                       
                        <br />  <asp:Label ID="Label" runat="server" Text=""></asp:Label>
                        <br />
                    </div>
                        
                </div>

       
    </div>
        
   


</asp:Content>