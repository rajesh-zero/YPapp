<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ManageChannel.aspx.cs" Inherits="Admin_ManageChannel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="Container row">
        <h3 style="padding-left:50px;">Manage Channel</h3>
    </div>
    <%--<div class="Container row form-group">
        <div class="form-inline" style="margin-left:200px;">
            <asp:Label ID="Label1" runat="server" Text="Search"></asp:Label>
            <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
        </div>
    </div>--%>
    <div class="row">
                  <div class="container col-md-12">
                  <asp:Repeater ID="Repeater1" runat="server">
                      <HeaderTemplate>
                          <table class="display table table-striped table-bordered table-responsive" style="width:100%;">
                              <thead>
                                  <tr style="background-color:silver;">
                                      <th style="width:50px;">Sr No.</th>
                                      <td style="width:auto;">Channel Image</td>
                                      <td style="width:auto;">Name</td>
                                      <td style="width:auto;">Owner</td>
                                      <td style="width:auto;">Created on</td>
                                      <td style="width:auto;">Status</td>
                                      <td>View</td>
                                     <td style="width:auto;">Delete</td>
                                  </tr>
                              </thead>
                      </HeaderTemplate>
                      <ItemTemplate>
                          <tr>
                              <td><%#Container.ItemIndex+1 %></td>
                              <td><asp:Image ID="Image1" runat="server" style="width:90px;height:90px;" ImageUrl='<%# string.Concat("~/images/channel/images/", "", Eval("chimage")) %>' AlternateText="no picture" /></td>
                              <td><%# Eval("chname") %></td>
                              <td><%# Eval("uname") %></td>
                              <td><%# Eval("chcreatedon") %></td>
                              <td><%# Eval("status") %></td>
                              <td><asp:LinkButton ID="lbtnViewChannel" runat="server" Text="view" CausesValidation="False"  CommandName="edit"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "chid") %>' OnClick="lbtnViewChannel_Click"></asp:LinkButton></td>
                              <td><asp:ImageButton ID="ImgDeleteChannel" style="height:25px;width:25px;" runat="server" ImageUrl="~/images/logos/delete.png" CausesValidation="False"  CommandName="delete" OnClick="ImgDeleteChannel_Click" chid='<%# DataBinder.Eval(Container.DataItem, "chid") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "chid") %>'/></td>
                          </tr>
                      </ItemTemplate>
                      <FooterTemplate>
                          </table>
                      </FooterTemplate>
                  </asp:Repeater>
                  </div>
              </div>
</asp:Content>

