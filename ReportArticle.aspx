<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="ReportArticle.aspx.cs" Inherits="ReportArticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="margin:90px">
        <div class="container">
        <asp:Label ID="Label1" style="font-size:15px" runat="server" Text="Label"></asp:Label>
    </div>
    <div class="container form-group">
      <label style="font-size:20px">Please Select reason : </label>
       <asp:DropDownList ID="Report" class="form-control" Style="width: 60%;" runat="server">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem Value="Hateful speech">Hateful speech</asp:ListItem>
                            <asp:ListItem Value="Spam">Spam</asp:ListItem>
                            <asp:ListItem Value="Sexual abuse">Sexual abuse</asp:ListItem>
                            <asp:ListItem Value="Violence">Violence</asp:ListItem>
                            <asp:ListItem Value="religious sentiments">religious sentiments</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="container">
        <asp:Button ID="btnsubmit" class="btn btn-danger" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
    </div>
    </div>
    
</asp:Content>

