<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ManageReports.aspx.cs" Inherits="Admin_ManageReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="Container row">
        <h3 style="padding-left:50px;">Manage Reports</h3>
    </div>  
    <%--<div class="Container row form-group">
        <div class="form-inline" style="margin-left:200px;">
            <asp:Label ID="Label1" runat="server" Text="Search"></asp:Label>
            <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
        </div>
    </div>  --%>
    <div class="row">

        <div class="container">
            <div class="container col-sm-12">
                  <asp:Repeater ID="RptReports" runat="server">
                      <HeaderTemplate>
                          <table class="display table table-striped table-bordered table-responsive" style="width:100%;">
                              <thead>
                                  <tr style="background-color:silver;">
                                      <%--<td>ID</td>--%>
                                      <th style="width:70px;">Sr No.</th>
                                      <td style="width:auto;">Username</td>
                                      <td style="width:auto;">Article</td>
                                      <td style="width:auto;">Reason</td>
                                      <td>view</td>
                                      <td>Delete Article</td>
                                     <td>Ignore Report</td>
                                  </tr>
                              </thead>
                      </HeaderTemplate>
                      <ItemTemplate>
                          <tr>
                              <%--<td><%# Eval("cid") %></td>--%>
                              <td><%#Container.ItemIndex+1 %></td>
                              <td><%# Eval("uname") %></td>
                              <td><%# Eval("heading") %></td>
                              <td><%# Eval("description") %></td>
                              <td><asp:LinkButton ID="lBtnView" runat="server" Text="view" OnClick="lBtnView_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>'></asp:LinkButton></td>
                              <td><asp:ImageButton ID="ImgDeleteArticle" style="height:30px;width:30px;" runat="server" ImageUrl="~/images/logos/delete.png" CausesValidation="False"  CommandName="edit" OnClick="ImgDeleteArticle_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>'/></td>
                              <td><asp:ImageButton ID="ImgIgnoreReport" style="height:25px;width:25px;" runat="server" ImageUrl="~/images/logos/ignore.png" CausesValidation="False"  CommandName="delete" OnClick="ImgIgnoreReport_Click" cname='<%# DataBinder.Eval(Container.DataItem, "rid") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "rid") %>'/></td>
                          </tr>
                      </ItemTemplate>
                      <FooterTemplate>
                          </table>
                      </FooterTemplate>
                  </asp:Repeater>
                  </div>
        </div>
                  
              </div>
</asp:Content>

