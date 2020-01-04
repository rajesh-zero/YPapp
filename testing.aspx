<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="testing.aspx.cs" Inherits="testing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

        <br />
        <br />
      
        <table class="nav-justified">
            <tr>
                <td rowspan="3">
                    <asp:ImageButton ID="IBtnartimage" runat="server" />
                </td>
                <td class="auto-style1">
                    <asp:LinkButton ID="lbtnartName" runat="server">LinkButton</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="lbChannelName" runat="server">LinkButton</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblStats" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
      
        <br />
        <br />
        <br />
    </form>
</asp:Content>

