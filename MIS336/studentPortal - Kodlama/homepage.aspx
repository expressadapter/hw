<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="homepage.aspx.cs" Inherits="homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Main jumbotron for a primary marketing message or call to action -->

	<div class="jumbotron jumbotronHeader text-center">
      <br />
	  <h1>Search for Lecture Notes</h1>
	    <br />
	  <br />

         <div class="col-md-6 col-md-offset-3">
        	<div class="input-group input-group-lg col-md-6 col-md-offset-3">
            <asp:TextBox ID="TextBox1" runat="server" type="text" class="form-control" placeholder="Course Code or Name "></asp:TextBox>
            <span class="input-group-btn">
            <asp:Button ID="Button1" runat="server" Text="Search" class="btn btn-default" type="button" OnClick="Button1_Click" />
      </span>
          </div>
        </div>

	  <br />
      <br /><br />
 
	</div>
    <div class="container page-wrap">
     <div class="row">
        <div class="col-md-3">
          <h2>Upload File to Support Charities and help others</h2>
          <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
          <p class="text-center"><a class="btn btn-default" href="#" role="button">View details &raquo;</a></p>
        </div>
        <div class="col-md-3">
          <h2>Search Upcoming Events,Concerts etc.</h2>
          <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
          <p class="text-center"><a class="btn btn-default" href="#" role="button">View details &raquo;</a></p>
       </div>
        <div class="col-md-3">
          <h2>Look for Traineeship Announcements</h2>
          <p>Donec sed odio dui. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Vestibulum id ligula porta felis euismod semper. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus.</p>
          <p class="text-center"><a class="btn btn-default" href="#" role="button">View details &raquo;</a></p>
        </div>
		<div class="col-md-3">
          <h2>Hang out in Forums Speak with others</h2>
          <p>Donec sed odio dui. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Vestibulum id ligula porta felis euismod semper. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus.</p>
          <p class="text-center"><a class="btn btn-default" href="#" role="button">View details &raquo;</a></p>
        </div>
      </div>
	  <hr />
	<div class="row" style="margin-bottom:5em;">
        <div>
		<h2>About</h2>
		<p>We are planning to create a comfortable and interactive web platform in which university students can share and download all kinds of course-related materials free of charge and communicate with each other and our business partners. Our aim is to bring source owners together, who are mostly students and create an alternative note sharing and interaction platform.  So, we think that an online platform that will be fed and sustained by students might be a good option for their colleagues who may have difficulty in finding helpful sources and materials. In addition to that purpose, students will be made donations to charities that they had selected by uploading their lecture notes. Hayrına Sınav Notları will make donations per downloads to selected charities. As a revenue model, we are planning to work with business partners who will make payment for their corporate accounts. As a gain, they can reach university students in different universities, faculties, genders, ages etc. as their subscription agreement allows. That way they can reach any specific student group and communicate with them in direction of their aims (internship announcements, seminars, trainings, marketing campaigns etc.)</p>
         </div>
      </div>
     
    </div> <!-- /container -->


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->

    <script src="App_Themes/studentPortal/js/bootstrap.min.js"></script>

   

</asp:Content>
