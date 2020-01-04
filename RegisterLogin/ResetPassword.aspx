<%@ Page Title="" Language="C#" MasterPageFile="~/RegisterLogin/RegisterLogin.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="Register_Login_ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="margin-bottom:100px;margin-top:100px;">
        <div class="panel panel-danger">
            <div class="panel-body">
                
        <div class="form-inline">
        &nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" CssClass="form-control" Style="margin-top:10px;" placeholder="Enter email address" runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="Button1" CssClass="btn btn-danger" Style="margin-top:10px;" runat="server" Text="Reset Password" OnClick="Button1_Click" />
        <asp:Label ID="lblMessage" Style="margin-top:10px;" runat="server" Text=""></asp:Label>
            </div>
                </div>
        </div>
    </div>
</asp:Content>

