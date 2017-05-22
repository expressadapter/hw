<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="download.aspx.cs" Inherits="download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <div class="col-md-12" style="padding-top:5em;">
         
   <div class="input-group input-group-md col-md-6 col-md-offset-6">
            <asp:TextBox ID="TextBox1" runat="server" type="text" class="form-control" ></asp:TextBox>
            <span class="input-group-btn">
            <asp:Button ID="Button3" runat="server" Text="Search" class="btn btn-primary" type="button" OnClick="search_Click" />
      </span>
        

    </div> <br /><br />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br /><br /><br /><br /><br /><br /><br /><br />
</div>
</asp:Content>

