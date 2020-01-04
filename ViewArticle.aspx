<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="ViewArticle.aspx.cs" Inherits="ViewArticle" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            text-align:left;
        }
        .auto-style2 {
            height: 26px;
            text-align:left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="row" >
            <div class="col-md-8" style="padding: 0px 20px;">
                <div style="padding:0px 20px">
                    <div class="row" style="padding: 20px; border: 1px solid grey; border-radius: 5px; box-shadow: 3px 3px 5px #d3d3d3; height: 500px; overflow-y: scroll; overflow-x: hidden;">
                    <asp:Label ID="lblMainBody" runat="server" Text="Label"></asp:Label>
                </div>
                </div>
                
                <div style="padding: 10px 20px;">
                    <div class="row" style="padding: 10px; border: 1px solid grey; border-radius: 5px; box-shadow: 3px 3px 5px #d3d3d3; height: auto;">
                        <div class="row col-md-12" style="margin-left: 0px">
                            <asp:Label ID="lblHeading" runat="server" Text="Label" Font-Size="1.5em" ForeColor="Black" Font-Bold="False"></asp:Label></div>
                        <div class="row">

                        </div>
                        <hr style="padding: 0px; margin: 5px;"/>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div style="margin: 0px; padding-top: 10px">
                                    <div class="col-xs-5">
                                        <asp:Label ID="lblViews" runat="server" Text="" Font-Size="1.5em" ForeColor="#666666"></asp:Label>
                                    </div>

                                    <div class="col-xs-7" style="padding-bottom: 4px;text-align:right">
                                        <asp:LinkButton ID="lnkLike" class="btn btn-default btn-xs" Font-Size="1.5em" Style="border-radius: 0; border: none; vertical-align: middle" runat="server" OnClick="lnkLike_Click"><i id="like" runat="server" class="fa fa-thumbs-up" style="color: thistle; font-size: x-large;"></i></asp:LinkButton><asp:Label ID="lblLike" runat="server" Font-Size="1.5em" ForeColor="#666666" Text="0"></asp:Label>
                                        <asp:LinkButton ID="lnkDislike" class="btn btn-default btn-xs" Font-Size="1.5em" Style="border-radius: 0; border: none; vertical-align: middle" runat="server" OnClick="lnkDislike_Click"><i id="dislike" runat="server" class="fa fa-thumbs-down fa-flip-horizontal" style="color: thistle; font-size: x-large;"></i></asp:LinkButton><asp:Label ID="lbldislike" runat="server" Font-Size="1.5em" ForeColor="#666666" Text="0"></asp:Label>&nbsp;&nbsp;&nbsp;
                                        <asp:LinkButton ID="lnkReport" class="btn btn-default btn-xs" Font-Size="1.5em" Style="border-radius: 0; border: none; vertical-align: middle" runat="server" OnClick="lnkReport_Click"><i id="report" runat="server" class="fa fa-flag" style="color: thistle; font-size: x-large;"></i></asp:LinkButton>
                                    </div>
                                </div>
                                </ContentTemplate>
                      </asp:UpdatePanel>
                                <div class="row" style="margin: 0px; padding-top: 10px">
                                    <div class="col-xs-3">
                                        <asp:Image ID="ImgChannel" runat="server" style="height:60px;width:60px" ImageUrl="~/images/channel/images/default.png" />
                                        <asp:LinkButton ID="lnkChannel" Font-Size="1.0em" runat="server" Text="channel" OnClick="lnkChannel_Click"></asp:LinkButton>
                                    </div>

                                    <div class="col-xs-4 col-xs-offset-5" style="padding-bottom: 4px;text-align:right">
                                        <asp:Button ID="btnSubscribe" class="btn btn-danger" runat="server" Text="Subscribe" OnClick="btnSubscribe_Click" />
                                    </div>
                                </div>
                            
                    </div>
                </div>

                <div style="padding: 0px 20px;">
                    <div class="row" style="padding: 20px; border: 1px solid grey; border-radius: 5px; box-shadow: 3px 3px 5px #d3d3d3; height: auto;">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="row col-md-12">
                                <%-- <asp:Image ID="ImgUser" runat="server" Style="height: 60px; width: 60px" />--%>
                                <div>
                                    <asp:TextBox ID="txtComment" class="form-control" Style="height: 60px; resize: vertical;" runat="server" placeholder="write comment here ...." TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row col-md-12">
                                <div>
                                    <asp:Button ID="btnComment" class="btn btn-primary muted pull-right" style="margin:10px;" runat="server" Text="Comment" OnClick="btnComment_Click" />
                                </div>
                            </div>
                            <div class="row col-md-12">
                                <hr />
                            </div>
                            
                            <div class="row col-md-12">
                                <asp:Repeater ID="rptComments" runat="server">
                                    <ItemTemplate>
                                        <div class="container">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <asp:Label ID="lblComments" runat="server" Text='<%# Eval("comment") %>'></asp:Label></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-3">
                                                &nbsp;<asp:LinkButton ID="lBtnkChname" ForeColor="#000000" runat="server" Text='<%# Eval("uname") %>' OnClick="lBtnkChname_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "uid") %>'>></asp:LinkButton></div>
                                            <div class="col-sm-6">
                                                Commented on:&nbsp;<asp:Label ID="lblCommentDatetime" runat="server" Text='<%# Eval("postedon") %>'></asp:Label></div>
                                        </div>
                                    </div>
                                        <hr />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    
                        
                   </div>
                </div>
            </div>
            <div class="col-md-4" style="padding: 0px 0px;text-align:left">
                <asp:Repeater ID="rptSideArticle" runat="server">
                    <ItemTemplate>
                        <div runat="server" style="padding: 5px;margin:10px; border: 1px solid grey; border-radius: 5px; box-shadow: 3px 3px 5px #d3d3d3; height:auto;">
                            <table>
                                <tr>
                                    <td rowspan="3">
                                        <asp:ImageButton ID="IBtnartimage" class="img-thumbnail" style="height:100px;width:160px;margin:10px;" runat="server" OnClick="ImgBtnThumbnail_Click" ImageUrl='<%# string.Concat("~/images/articles/articleImage/", "", Eval("thumbnail")) %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>'/>
                                    </td>
                                    <td colspan="3">
                                        <asp:LinkButton ID="lbtnartName" ForeColor="#000000" runat="server" Text='<%# Limit(Eval("heading"),40) %>' ToolTip='<%# Eval("heading") %>' OnClick="lbtnHeading_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>'></asp:LinkButton>
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

