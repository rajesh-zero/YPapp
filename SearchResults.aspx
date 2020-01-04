<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="SearchResults.aspx.cs" Inherits="SearchResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">Search Results</div>
            <div class="panel-body">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div runat="server" style="padding: 5px;margin:10px; border: 1px solid grey; border-radius: 5px; box-shadow: 3px 3px 5px #d3d3d3; height:auto;">
                            <table>
                                <tr>
                                    <td rowspan="3">
                                        <asp:ImageButton ID="IBtnartimage" class="img-thumbnail" style="height:100px;width:160px;margin:10px;" runat="server" OnClick="ImgBtnThumbnail_Click" ImageUrl='<%# string.Concat("~/images/articles/articleImage/", "", Eval("thumbnail")) %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>'/>
                                    </td>
                                    <td colspan="3">
                                        <asp:LinkButton ID="lbtnartName" ForeColor="#000000" runat="server" Text='<%# Limit(Eval("heading"),80) %>' ToolTip='<%# Eval("heading") %>' OnClick="lbtnHeading_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>'></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:LinkButton ID="lbChannelName" runat="server" Text='<%# Eval("chname") %>' OnClick="lbtnChannelname_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "chid") %>'></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:left"><%# string.Concat("views : ", "", Eval("views")) %></td>
                                    <td><%# string.Concat("likes : ", "", Eval("likes")) %></td>
                                    <td><%# string.Concat("dislikes : ", "", Eval("dislikes")) %></td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
        </div>
    </div>
    </div>
</asp:Content>

