<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentPortal.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Student Portal</title>
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css">
    <link rel="stylesheet" href="bootstrap.vertical-tabs.css">
</head>
<body>
       <form id="form" runat="server">
    <div>
    <div class="container">
        <div class="page-header">
            <h1>Student Portal <small> | Sql Interface</small></h1>
        </div>
        <div class="row" style="min-height:600px;">
            <div class="col-sm-12">
                
                <div class="col-sm-3">
                    <!-- required for floating -->
                    <!-- Nav tabs -->
                    <ul class="nav nav-tabs tabs-left" id="tabs">
                        <li><a href="#home" data-toggle="tab">Add New User&Course</a></li>
                        <li><a href="#profile" data-toggle="tab">Querys</a></li>
                        <li><a href="#messages" data-toggle="tab">Sources</a></li>
                        <!--li><a href="#settings" data-toggle="tab">Settings</a></li-->
                    </ul>
                </div>
                <div class="col-sm-9">
                    <!-- Tab panes -->
                    <div class="tab-content" id="tabs2">
                        <div class="tab-pane" id="home">
                          
                                <div class="panel panel-default col-sm-4">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Add New User</h3>
                                    </div>
                                    <div class="panel-body">
                                         <label>User ID:</label>  
                                        <asp:TextBox ID="userID" runat="server" class="form-control input-xs"></asp:TextBox><br />
                                        <label>Username:</label>  
                                        <asp:TextBox ID="userName" runat="server" class="form-control input-xs"></asp:TextBox><br />
                                        <label>User Mail:</label>  
                                        <asp:TextBox ID="userMail" runat="server" class="form-control input-xs"></asp:TextBox><br />
                                        <label>User Password:</label>  
                                        <asp:TextBox ID="userPassword" runat="server" class="form-control input-xs"></asp:TextBox><br />
                                        <label>User Role:</label>  
                                        <asp:TextBox ID="userRole" runat="server" class="form-control input-xs"></asp:TextBox><br />
                                        <asp:Button Text="Add" runat="server" class="btn btn-primary" OnClick="addNewUser_Click" /><br /><br />
                                        <asp:Label ID="resultLabel" runat="server" Text="Label" Visible="False" role=""/>
                                 
                                    </div>

                            </div>
                            <div class="col-sm-1"></div>
                      <div class="panel panel-default col-sm-4">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Add New Course</h3>
                                    </div>
                                    <div class="panel-body">
                                         <label>Course ID:</label>  
                                        <asp:TextBox ID="TextBox1" runat="server" class="form-control input-xs"></asp:TextBox><br />
                                        <label>Course Code:</label>  
                                        <asp:TextBox ID="TextBox2" runat="server" class="form-control input-xs"></asp:TextBox><br />
                                        <label>Course Name:</label>  
                                        <asp:TextBox ID="TextBox3" runat="server" class="form-control input-xs"></asp:TextBox><br />
                                        <label>Department:</label>  
                                        <asp:TextBox ID="TextBox4" runat="server" class="form-control input-xs"></asp:TextBox><br />
                                        <asp:Button Text="Add" runat="server" class="btn btn-primary" OnClick="addNewCourse_Click" /><br /><br />
                                        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False" role=""/>
                                 
                                    </div>

                            </div>
                          
                        
                        
                        
                            </div>
                        <div class="tab-pane" id="profile">
                            <div>
                                 <h3>Find uploaded material's uploader name and upload date<asp:Button Text="Find" runat="server" class="btn btn-primary" OnClick="query1_Click" style="margin-left:10px;" /></h3>
                                 <h3>Find most downloaded material's name<asp:Button Text="Find" runat="server" class="btn btn-primary" OnClick="query2_Click" style="margin-left:10px;" /></h3>
                                 <h3>Find userids and their followed course's names<asp:Button Text="Find" runat="server" class="btn btn-primary" OnClick="query3_Click" style="margin-left:10px;" /></h3>
                                 <h3>Find usernames of commentors<asp:Button Text="Find" runat="server" class="btn btn-primary" OnClick="query4_Click" style="margin-left:10px;" /></h3>
                                 <h3>Find usernames and mails of Database Systems course followers<asp:Button Text="Find" runat="server" class="btn btn-primary" OnClick="query5_Click" style="margin-left:10px;" /></h3>
                                 <h3>Find average rating of Database Systems course materials<asp:Button Text="Find" runat="server" class="btn btn-primary" OnClick="query6_Click" style="margin-left:10px;" /></h3>
                                 <h3>Find count of users who uploaded a material<asp:Button Text="Find" runat="server" class="btn btn-primary" OnClick="query7_Click" style="margin-left:10px;" /></h3>
                                 <h3>Find name of course which had most uploaded material<asp:Button Text="Find" runat="server" class="btn btn-primary" OnClick="query8_Click" style="margin-left:10px;" /></h3>
                            </div>
                            <div>
                                <h3><strong>Output:</strong></h3>
                                <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
                                <asp:Label ID="Label2" runat="server" Text="Label" Visible="False" role=""/>
                            </div>
                        </div>
                        <div class="tab-pane" id="messages">
                            <div>
                                <h3><strong>Sources:</strong></h3>
                                <p>
                                    <h4>
                                   <a href=" http://www.aspsnippets.com/Articles/Display-data-from-database-in-HTML-table-in-ASPNet.aspx"> http://www.aspsnippets.com/Articles/Display-data-from-database-in-HTML-table-in-ASPNet.aspx</a><br />
                                    <a href="http://bootstrapdocs.com/v3.3.0/docs/getting-started/">http://bootstrapdocs.com/v3.3.0/docs/getting-started/</a><br />
                                    <a href="https://github.com/expressadapter/hw/tree/master/MIS233/MIS233Project2">https://github.com/expressadapter/hw/tree/master/MIS233/MIS233Project2</a><br />
                                    <a href="http://stackoverflow.com/questions/3641154/jquery-trapping-tab-select-event">http://stackoverflow.com/questions/3641154/jquery-trapping-tab-select-event</a><br />
                                    <a href="https://www.smashingmagazine.com/2010/10/local-storage-and-how-to-use-it/">https://www.smashingmagazine.com/2010/10/local-storage-and-how-to-use-it/</a><br />
                                    <a href="http://www.uykusuzadam.com/2014/06/asp-net-ile-iletisim-formu-bootstrap/">http://www.uykusuzadam.com/2014/06/asp-net-ile-iletisim-formu-bootstrap/</a><br />
                                    <a href="https://github.com/dbtek/bootstrap-vertical-tabs">https://github.com/dbtek/bootstrap-vertical-tabs</a><br />
                                    </h4>
                               </p>
                            </div>

                        </div>
                        <div class="tab-pane" id="settings">Settings Tab.</div>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
  </form>
    <footer class="footer" style="width:100%; text-align:center; padding-bottom:20px;">
       
    </footer>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="http://netdna.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script src="http://code.jquery.com/ui/1.7.3/jquery-ui.min.js" integrity="sha256-pYKd3m/N09PCc1/MM/f1Nk4PnaHrShF5ehtyZ0kdDds=" crossorigin="anonymous"></script>
    <script>
        $(document).ready(function () {
            $('.nav-tabs a').click(function (e) {
                e.preventDefault();
                localStorage.setItem('activeTab', $($(this).attr('href')).index())
            });
        });
    </script>
    <script>
        if (localStorage.getItem('activeTab')) {
            var index = localStorage.getItem('activeTab');
            $(".nav-tabs").children('li').eq(index).addClass('active')
            $(".tab-content").children('div').eq(index).addClass('active')
        }
    </script>
    </div>
</body>
</html>
