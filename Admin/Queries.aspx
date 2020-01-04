<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Queries.aspx.cs" Inherits="Admin_Queries" %>

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
                                      <td style="width:auto;">Name</td>
                                      <td style="width:auto;">Email</td>
                                      <td style="width:auto;">Mobile no</td>
                                      <td style="width:auto;">Query</td>
                                      <td>Reply</td>
                                     <td style="width:auto;">Delete</td>
                                  </tr>
                              </thead>
                      </HeaderTemplate>
                      <ItemTemplate>
                          <tr>
                              <td><%#Container.ItemIndex+1 %></td>
                              <td><%# Eval("Name") %></td>
                              <td><%# Eval("Email") %></td>
                              <td><%# Eval("MobileNo") %></td>
                              <td><%# Eval("Query") %></td>
                              <td><asp:LinkButton ID="lbtnREplyQuery" runat="server" Text="view" CausesValidation="False"  CommandName="edit"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EnquiryID") %>' OnClick="lbtnREplyQuery_Click"></asp:LinkButton></td>
                              <td><asp:ImageButton ID="DeleteQuery" style="height:25px;width:25px;" runat="server" ImageUrl="~/images/logos/delete.png" CausesValidation="False"  CommandName="delete" OnClick="DeleteQuery_Click" chid='<%# DataBinder.Eval(Container.DataItem, "EnquiryID") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EnquiryID") %>'/></td>
                          </tr>
                      </ItemTemplate>
                      <FooterTemplate>
                          </table>
                      </FooterTemplate>
                  </asp:Repeater>
                  </div>
              </div>
</asp:Content>

