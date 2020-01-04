<%@ Page Title="" Language="C#" MasterPageFile="~/RegisterLogin/RegisterLogin.master" AutoEventWireup="true" CodeFile="UserVerification.aspx.cs" Inherits="RegisterLogin_UserVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="alert alert-info alert-dismissable container" id="success" runat="server" visible="false">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">×</a>
        <strong>Email Verification Completed Successfully</strong> <u>now try logging in</u>
    </div>
    <div class="alert alert-danger alert-dismissable container" id="failure" runat="server" visible="false">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">×</a>
        <strong>Bad link</strong>
    </div>
</asp:Content>

