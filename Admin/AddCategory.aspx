<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="Admin_AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding-right: 15px; padding-left: 15px">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="row">
                <div class="col-md-3 form-group">
                    <asp:TextBox ID="txtCname" placeholder="Category name" class="form-control" runat="server"></asp:TextBox>                    
                </div>
                <div class="col-md-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter category name" ControlToValidate="txtCname" Display="Dynamic" ForeColor="Red" ToolTip="Enter category name" Font-Size="X-Large" ValidationGroup="cVal">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Minimum 3 and Maximum 50 characters required." Text="*" Display="Dynamic" Font-Size="X-Large" ToolTip="Minimum 3 and Maximum 50 characters allowed" ControlToValidate="txtCname" ForeColor="Red" ValidationExpression="^[\s\S]{3,50}$" ValidationGroup="cVal"></asp:RegularExpressionValidator>
                </div>
                <div class="col-md-4 form-group">
                    <asp:TextBox ID="txtCdescription" placeholder="Category description..(optional)" class="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Maximum 300 Characters allowed" ValidationGroup="cVal" ControlToValidate="txtCdescription" Font-Size="X-Large" ForeColor="Red" ToolTip="Maximum 300 characters allowed" ValidationExpression="^[\s\S]{0,300}$">*</asp:RegularExpressionValidator>
                </div>
                <div class="col-md-4 form-group">
                    <asp:Button ID="btnSaveCategory" class="btn btn-primary" runat="server" Text="Add Category" OnClick="btnSaveCategory_Click" ValidationGroup="cVal" />&nbsp;
                    <asp:Button ID="btnCancel" class="btn btn-warning" runat="server" Text="Cancel" Visible="false" OnClick="btnCancel_Click" />
                    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
              </div>
              <div class="row">
                  <div class="container col-sm-12">
                  <asp:Repeater ID="Repeater1" runat="server">
                      <HeaderTemplate>
                          <table class="display table table-striped table-bordered table-responsive" style="width:100%;">
                              <thead>
                                  <tr style="background-color:silver;">
                                      <%--<td>ID</td>--%>
                                      <th style="width:70px;">Sr No.</th>
                                      <td style="width:auto;">Category</td>
                                      <td style="width:auto;">Description</td>
                                      <td>Edit</td>
                                     <%--<td>Delete</td>--%>
                                  </tr>
                              </thead>
                      </HeaderTemplate>
                      <ItemTemplate>
                          <tr>
                              <%--<td><%# Eval("cid") %></td>--%>
                              <td><%#Container.ItemIndex+1 %></td>
                              <td><%# Eval("cname") %></td>
                              <td><%# Eval("cdescription") %></td>
                              <td><asp:ImageButton ID="ImgEditCategory" style="height:30px;width:30px;" runat="server" ImageUrl="~/images/logos/edit.png" CausesValidation="False"  CommandName="edit" OnClick="ImgEditCategory_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "cid") %>'/></td>
                              <%--<td><asp:ImageButton ID="ImgDeleteCategory" style="height:25px;width:25px;" runat="server" ImageUrl="~/images/logos/delete.png" CausesValidation="False"  CommandName="delete" OnClick="ImgDeleteCategory_Click" cname='<%# DataBinder.Eval(Container.DataItem, "cname") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "cid") %>'/></td>--%>
                          </tr>
                      </ItemTemplate>
                      <FooterTemplate>
                          </table>
                      </FooterTemplate>
                  </asp:Repeater>
                  </div>
              </div>
            </div>
        </div>
    </div>
</asp:Content>

