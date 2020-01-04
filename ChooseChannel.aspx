<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="ChooseChannel.aspx.cs" Inherits="ChooseChannel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="ChannelExists" runat="server" visible="false" class="container jumbotron" style="text-align:center">
  <div class="form-inline">
    <div class="form-group">
      <label style="font-size:25px">Choose Channel you want to write article on : </label>
        <asp:DropDownList ID="DropDownList1" class="form-control" runat="server" AppendDataBoundItems="true" DataTextField="chname" DataValueField="chid"></asp:DropDownList>
        
    </div>
      <asp:Button ID="btnNext" class="btn btn-primary" runat="server" Text="Proceed" OnClick="btnNext_Click" />
  </div>
</div>
    <div id="ChannelDoesnotExist" runat="server" visible="false">
    <div class="container">
        <h4>You dont have any Active Channels, Before you can Write something You need a channel to Create one <a href="User/Channel/CreateChannel.aspx">click here</a> </h4>
        <h4>Please <a href="RegisterLogin/Register.aspx">Register</a> OR <a href="RegisterLogin/Login.aspx">login</a> to perform that activity</h4>
    </div>
    </div>
</asp:Content>

