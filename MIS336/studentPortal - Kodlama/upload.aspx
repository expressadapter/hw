<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet">
<link href="App_Themes/studentPortal/css/fileinput.min.css" media="all" rel="stylesheet" type="text/css" />
<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
<!-- canvas-to-blob.min.js is only needed if you wish to resize images before upload.
     This must be loaded before fileinput.min.js -->
<script src="App_Themes/studentPortal/js/plugins/canvas-to-blob.min.js" type="text/javascript"></script>
<!-- sortable.min.js is only needed if you wish to sort / rearrange files in initial preview.
     This must be loaded before fileinput.min.js -->
<script src="App_Themes/studentPortal/js/plugins/sortable.min.js" type="text/javascript"></script>
<!-- purify.min.js is only needed if you wish to purify HTML content in your preview for HTML files.
     This must be loaded before fileinput.min.js -->
<script src="App_Themes/studentPortal/js/plugins/purify.min.js" type="text/javascript"></script>
<!-- the main fileinput plugin file -->
<script src="App_Themes/studentPortal/js/fileinput.min.js"></script>
<!-- bootstrap.js below is needed if you wish to zoom and view file content 
     in a larger detailed modal dialog -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" type="text/javascript"></script>
<!-- optionally if you need a theme like font awesome theme you can include 
    it as mentioned below -->
<script src="App_Themes/studentPortal/js/fa.js"></script>
<!-- optionally if you need translation for your language then include 
    locale file as mentioned below -->
<script src="App_Themes/studentPortal/js/<lang>.js"></script>
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

    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
   
    <div class="col-md-10 col-md-offset-2" style="padding-top:3em;">
     
       
        <div class="thumbnail">
               
                    <div class="caption-full" style="padding:1em;">
                        <br /> 
                        <asp:FileUpload ID="FileUploadControl" runat="server" />
        <br />
                        <label for="name">File Name</label> <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        <label for="name">Description</label> <asp:TextBox ID="TextBox2" TextMode="multiline" Columns="50" Rows="5" runat="server" CssClass="form-control"></asp:TextBox>
                        <label for="name">Upload to Course</label><asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                            <asp:ListItem disabled selected value data-hiden="true">Select</asp:ListItem>
                                                                  </asp:DropDownList>
                  
                        
                        
                        <br />  <asp:Label ID="Label" runat="server" Text=""></asp:Label>
                        <br />
                     <asp:Button ID="uploadButton" runat="server" Text="Upload" OnClick="upload_Click" CssClass="btn btn-lg btn-success pull-right"/>
                         </div>
                      
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
          
                </div>
       <br />
        <br />   <br />
        <br />


    </div>
   <script>
       $("#ContentPlaceHolder3_FileUploadControl").fileinput({ 'showUpload': false, 'previewFileType': 'any' });</script>

</asp:Content>


