<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Reply.aspx.cs" Inherits="Admin_Reply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container " style="margin:25px;">
        Enquiry by : <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
        Email      : <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
        Body       : <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
        Reply      :<asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox><br />
        <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />

        <asp:Label ID="Label4" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>

