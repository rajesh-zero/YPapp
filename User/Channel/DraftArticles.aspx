<%@ Page Title="" Language="C#" MasterPageFile="~/User/Channel/Channel.master" AutoEventWireup="true" CodeFile="DraftArticles.aspx.cs" Inherits="User_Channel_DraftArticles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container well">
<div class="col-sm-12">
    <div class="row">
       &nbsp;&nbsp; <asp:Button ID="btnBack" class="btn btn-default" runat="server" Text="Back" OnClick="btnBack_Click" />
    </div>
    <br />
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
                                    <td style="width: auto;">Created on</td>
                                    <td>Edit</td>
                                    <td>Publish</td>
                                    <td>Delete</td>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Container.ItemIndex+1 %></td>
                            <td>
                                <asp:Image ID="Image2" class="img-thumbnail" runat="server" ImageUrl='<%# string.Concat("~/images/articles/articleImage/", "", Eval("thumbnail")) %>' /></td>
                            <td>
                                <asp:LinkButton ID="lbtnHeading" runat="server" Text='<%# Eval("heading") %>'></asp:LinkButton></td>
                            <td><%# Eval("createdon") %></td>
                           <td>
                                <asp:ImageButton ID="ImgEditArticle" Style="height: 30px; width: 30px;" runat="server" ImageUrl="../../images/logos/edit.png" CausesValidation="False" CommandName="edit" OnClick="ImgEditArticle_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>' /></td>
                           <td>
                                <asp:ImageButton ID="ImgPublishArticle" Style="height: 30px; width: 30px;" runat="server" ImageUrl="../../images/logos/publish.png" CausesValidation="False" CommandName="edit" OnClick="ImgPublishArticle_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>' /></td>
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
    </div>
</asp:Content>

