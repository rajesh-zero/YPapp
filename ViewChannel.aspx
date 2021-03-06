﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="ViewChannel.aspx.cs" Inherits="ViewChannel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="font-awesome-4.1.0/css/font-awesome.css" rel="stylesheet" />
    <link href="styles/profiletab.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="container">
        <div class="row">
                       <div class="container col-sm-12">
                <%--  <div class="container" style="border: 1px solid grey; border-radius: 5px; box-shadow: 3px 3px 5px #d3d3d3;">--%>
                <div class="container col-sm-12" style="border-style: solid; border-color: #dddddd; border-width: thin; border-radius: 5px;">
                    <br />
                    <div>
                        <asp:Image ID="chArt" Class="img-responsive" runat="server" Height="130px" ImageUrl="~/images/logos/delete.png" Width="100%" />
                    </div>
                    &nbsp;
                <div>
                    <asp:Image ID="chImage" class="img-thumbnail" runat="server" ImageUrl="~/images/logos/Greentick.png" Width="85px" height="85px"/>
                    <asp:Label ID="lblChName" runat="server" Text="Name of channel"></asp:Label>
                    <div style="float: right; padding-top: 25px;">
                        <asp:Button ID="btnSubscribe" class="btn btn-danger" runat="server" Text="Subscribe" OnClick="btnSubscribe_Click" /><asp:Label ID="lblSubscriber" class="btn btn-default" runat="server" Text="Label"></asp:Label></div>
                    <br />
                </div>
                    &nbsp;
                </div>
                <br />
                <div class="container col-sm-12" style="border-style: solid; border-color: #dddddd; border-width: thin; border-radius: 5px;">
                    <div style="padding: 2px;">
                        <div id="scrollview" class="row" runat="server">
                            <div data-spy="scroll" class="tabbable-panel">
                                <div class="tabbable-line">
                                    <ul class="nav nav-tabs ">
                                        <li class="active">
                                            <a style="padding-right: 30px;" href="#Popular" data-toggle="tab">Popular</a>
                                        </li>
                                        <li>
                                            <a style="padding-right: 30px;" href="#Articles" data-toggle="tab">Articles</a>
                                        </li>
                                        <li>
                                            <a style="padding-right: 30px;" href="#About" data-toggle="tab">About</a>
                                        </li>
                                    </ul>
                                    <div class="tab-content">
                                        <div style="padding-left: 5px;" class="tab-pane active" id="Popular">
                                            <asp:DataList ID="dtlistPopularArticle" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="row">
                                                <ItemTemplate>
                                                    <div class="col-xs-3" style="margin: 5px; border: 1px solid grey; border-radius: 5px; height: 200px; width: 210px">
                                                        <div style="margin: 10px;">
                                                            <div class="row">
                                                                <asp:ImageButton ID="ImgBtnThumbnail" Style="height: 110px; width: 187px" ImageUrl='<%# string.Concat("~/images/articles/articleImage/", "", Eval("thumbnail")) %>' OnClick="ImgBtnThumbnail_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>' runat="server" />
                                                            </div>
                                                            <div class="row">
                                                                <asp:LinkButton ID="lbtnHeading" runat="server"
                                                                    ForeColor="#000000"
                                                                    Text='<%# Limit(Eval("heading"),40) %>'
                                                                    ToolTip='<%# Eval("heading") %>' OnClick="lbtnHeading_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>'>
                                                                </asp:LinkButton>
                                                            </div>
                                                            <div class="row">
                                                                <hr style="padding: 0px; margin: 5px;" />
                                                                <i class="fa fa-eye"></i><asp:Label ID="views" runat="server" Text='<%# string.Concat(Eval("views")) %>' />
                                                                &nbsp;<i class="fa fa-thumbs-up"></i><asp:Label ID="likges" runat="server" Text='<%# string.Concat(Eval("likes")) %>'></asp:Label>
                                                                &nbsp;<i class="fa fa-thumbs-down fa-flip-horizontal"></i><asp:Label ID="dislgikes" runat="server" Text='<%# string.Concat(Eval("dislikes")) %>'></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </div>
                                        <div style="padding-left: 5px;" class="tab-pane" id="Articles">
                                            <asp:DataList ID="dtlistArticle" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="row">
                                                <ItemTemplate>
                                                    <div class="col-xs-3" style="margin: 5px; border: 1px solid grey; border-radius: 5px; height: 200px; width: 210px">
                                                        <div style="margin: 10px;">
                                                            <div class="row">
                                                                <asp:ImageButton ID="ImgBtnThumbnail" Style="height: 110px; width: 187px" ImageUrl='<%# string.Concat("~/images/articles/articleImage/", "", Eval("thumbnail")) %>' OnClick="ImgBtnThumbnail_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>' runat="server" />
                                                            </div>
                                                            <div class="row">
                                                                <asp:LinkButton ID="lbtnHeading" runat="server"
                                                                    ForeColor="#000000"
                                                                    Text='<%# Limit(Eval("heading"),40) %>'
                                                                    ToolTip='<%# Eval("heading") %>' OnClick="lbtnHeading_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>'>
                                                                </asp:LinkButton>
                                                            </div>
                                                            <div class="row">
                                                                <hr style="padding: 0px; margin: 5px;" />
                                                                <i class="fa fa-eye"></i><asp:Label ID="views" runat="server" Text='<%# string.Concat(Eval("views")) %>' />
                                                                &nbsp;<i class="fa fa-thumbs-up"></i><asp:Label ID="likges" runat="server" Text='<%# string.Concat(Eval("likes")) %>'></asp:Label>
                                                                &nbsp;<i class="fa fa-thumbs-down fa-flip-horizontal"></i><asp:Label ID="dislgikes" runat="server" Text='<%# string.Concat(Eval("dislikes")) %>'></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </div>
                                        <div style="padding-left: 50px;" class="tab-pane" id="About">
                                            <br />
                                            <asp:LinkButton ID="channelOwner" runat="server" OnClick="channelOwner_Click">channelOwner</asp:LinkButton>
                                            <hr />
                                            <br />
                                            <asp:Label ID="lblchdescription" runat="server" Text="Label"></asp:Label>
                                            <hr />
                                            <br />
                                            <asp:Label ID="lblCreatedon" runat="server" Text="Label"></asp:Label>
                                            <hr />
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                    </div>
    </div>
</asp:Content>

