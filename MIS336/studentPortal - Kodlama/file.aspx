<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="file.aspx.cs" Inherits="filedetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
     
    <div class="thumbnail col-md-3" style=" margin-top:8em; padding:1em; ">

        <br />
        <h4>File Name:</h4>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <h4>File Tye:</h4>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <h4>File Description:</h4>
         <asp:TextBox ID="TextBox1" TextMode="multiline" Columns="50" Rows="5" runat="server" CssClass="form-control"></asp:TextBox>
        <h4>Uploaded By:</h4>
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>

        <br />     <br />     <br />
       <asp:Button ID="Button1" runat="server" Text="Download File" CssClass="btn btn-md btn-success text-center"  OnClick="Button1_Click"  />


        <br />


    </div>
    <div class="col-md-8"  style=" margin-top:3em; ">
        <h2>Commments:</h2>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <br />
                    <div class="thumbnail col-md-12" style="margin-bottom:5em;">
               
                    <div class="caption-full" style="padding: 1em;">
          
                        
                        <label for="name">Make Comment</label> <asp:TextBox ID="TextBox2" TextMode="multiline" Columns="50" Rows="5" runat="server" CssClass="form-control"></asp:TextBox>
                        
        
                        <br />
                        
                        <asp:Button ID="addCourse" runat="server" Text="Send" CssClass="btn btn-success btn-md pull-right" OnClick="addComment_Click" />
                       
                        <br />  <asp:Label ID="Label" runat="server" Text=""></asp:Label>
                        <br />
                    </div>
                        
                </div>
    </div>
    </asp:Content>

