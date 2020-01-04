<%@ Page Title="" Language="C#" MasterPageFile="~/User/Channel/Channel.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="User_Channel_Dashboard" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
    <div class="panel panel-default">
  <div class="panel-heading"><p style="font-size:30px">DashBoard</p></div>
  <div class="panel-body">
      <div class="row">
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">Total Views</div>
                    <div class="panel-body">
                        <asp:Label ID="lblViews" style="font-size:20px" runat="server" Text="Label"></asp:Label></div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">Total Subscribers</div>
                    <div class="panel-body">
                        <asp:Label ID="lblSubs" style="font-size:20px" runat="server" Text="Label"></asp:Label></div>
                </div>
            </div>
        </div>
      <div class="row">
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">Total Likes</div>
                    <div class="panel-body">
                        <asp:Label ID="lblLikes" style="font-size:20px" runat="server" Text="Label"></asp:Label></div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">Total Dislikes</div>
                    <div class="panel-body">
                        <asp:Label ID="lblDislikes" style="font-size:20px" runat="server" Text="Label"></asp:Label></div>
                </div>
            </div>
        </div>
      <div class="row">
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">Total Article</div>
                    <div class="panel-body">
                        <asp:Label ID="lblArticles" style="font-size:20px" runat="server" Text="Label"></asp:Label></div>
                </div>
            </div>
            <div class="col-md-6">
            </div>
        </div>
  </div>
</div>
        <div class="row">
            <div class="container col-sm-12">
                <asp:Repeater ID="RptAllArticle" runat="server">
                    <HeaderTemplate>
                        <table class="display table table-striped table-bordered table-responsive" style="width: 100%;">
                            <thead>
                                <tr style="background-color: silver;">
                                    <th style="width: auto;">Sr No.</th>
                                    <th style="width: 117px; height: 68px">Thumbnail</th>
                                    <td style="width: auto;">Heading</td>
                                    <td style="width: auto;">Likes</td>
                                    <td style="width: auto;">Dislikes</td>
                                    <td style="width: auto;">Views</td>
                                    <td style="width: auto;">Posted on</td>
                                    <%--<td>Edit</td>--%>
                                    <td>Delete</td>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Container.ItemIndex+1 %></td>
                            <td>
                                <asp:Image ID="Image2" class="img-thumbnail" runat="server" ImageUrl='<%# string.Concat("~/images/articles/articleimage/", "", Eval("thumbnail")) %>' /></td>
                            <td>
                                <asp:LinkButton ID="lbtnHeading" runat="server" Text='<%# Eval("heading") %>' OnClick="lbtnHeading_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>'></asp:LinkButton></td>
<%--                            <td><asp:LinkButton ID="lbtnHeading" runat="server"Text='<%# Eval("heading") %>' OnClick="lbtnHeading_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>'></asp:LinkButton></td>--%>
                            <td><%# Eval("likes") %></td>
                            <td><%# Eval("dislikes") %></td>
                            <td><%# Eval("views") %></td>
                            <td><%# Eval("postedon") %></td>
                            <%--<td>
                                <asp:ImageButton ID="ImgEditArticle" Style="height: 30px; width: 30px;" runat="server" ImageUrl="../../images/logos/edit.png" CausesValidation="False" CommandName="edit" OnClick="ImgEditArticle_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>' /></td>--%>
                            <td>
                                <asp:ImageButton ID="ImgDeleteArticle" Style="height: 25px; width: 25px;" runat="server" ImageUrl="../../images/logos/delete.png" CausesValidation="False" CommandName="delete" OnClick="ImgDeleteArticle_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>' /></td>
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

