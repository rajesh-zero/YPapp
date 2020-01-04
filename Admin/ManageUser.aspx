<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ManageUser.aspx.cs" Inherits="Admin_ManageUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="Container row">
        <h3 style="padding-left:50px;">Manage user</h3>
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
                                      <td style="width:auto;">Profile Image</td>
                                      <td style="width:auto;">Name</td>
                                      <td style="width:auto;">Gender</td>
                                      <td style="width:auto;">Mobile no</td>
                                      <td style="width:auto;">Email</td>
                                      <td style="width:auto;">Age</td>
                                      <td style="width:auto;">Country</td>
                                      <td style="width:auto;">Registered Date</td>
                                      <td style="width:auto;">Status</td>
                                      <td>View</td>
                                     <td style="width:auto;">Delete</td>
                                  </tr>
                              </thead>
                      </HeaderTemplate>
                      <ItemTemplate>
                          <tr>
                              <td><%#Container.ItemIndex+1 %></td>
                              <td><asp:Image ID="Image1" runat="server" style="width:90px;height:90px;" ImageUrl='<%# string.Concat("~/images/profileimage/", "", Eval("uprofilepic")) %>' AlternateText="no picture" /></td>
                              <td><%# Eval("uname") %></td>
                              <td><%# Eval("ugender") %></td>
                              <td><%# Eval("umobile") %></td>
                              <td><%# Eval("uemail") %></td>
                              <td><%# Eval("udob") %></td>
                              <td><%# Eval("ucountry") %></td>
                              <td><%# Eval("uregisteredon") %></td>
                              <td><%# Eval("ustatus") %></td>
                              <td><asp:LinkButton ID="lbtnViewUser" runat="server" Text="view" CausesValidation="False"  CommandName="edit"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "uid") %>' OnClick="lbtnViewUser_Click"></asp:LinkButton></td>
                              <td><asp:ImageButton ID="ImgDeleteUser" style="height:25px;width:25px;" runat="server" ImageUrl="~/images/logos/delete.png" CausesValidation="False"  CommandName="delete" OnClick="ImgDeleteUser_Click" uid='<%# DataBinder.Eval(Container.DataItem, "uid") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "uid") %>'/></td>
                          </tr>
                      </ItemTemplate>
                      <FooterTemplate>
                          </table>
                      </FooterTemplate>
                  </asp:Repeater>
                  </div>
              </div>
</asp:Content>

