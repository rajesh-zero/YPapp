<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="ViewProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="styles/profiletab.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="padding-bottom: 200px;">
        <div class="col-md-3">
            <div class="row">
                <asp:ImageButton ID="ImageButton1" class="img-thumbnail img-responsive center-block" Style="height: 250px; width: 250px;" runat="server" AlternateText="profile picture" CausesValidation="False" ToolTip="Profile Picture" ImageUrl="~/images/profileimage/default.png" Enabled="False"></asp:ImageButton>
            </div>
            <div class="row">
                <p style="text-align: center; font-size: large; padding-top: 10px;">
                    <asp:Label runat="server" ID="lblName"></asp:Label>
                </p>
            </div>
        </div>
        <div class="col-md-9">
            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="col-md-10">
                            ID:
                                                <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div id="profileView" class="row" runat="server">
                <div data-spy="scroll" class="tabbable-panel">
                    <div class="tabbable-line">
                        <ul class="nav nav-tabs ">
                            <li class="active">
                                <a style="padding-right: 30px;" href="#about" data-toggle="tab">About</a>
                            </li>
                            <li>
                                <a style="padding-right: 30px;" href="#Contacts" data-toggle="tab">Contacts</a>
                            </li>
                            <li>
                                <a style="padding-right: 30px;" href="#Channels" data-toggle="tab">Channels</a>
                            </li>
                        </ul>
                        <div class="tab-content">
                            <div style="padding-left: 50px;" class="tab-pane active" id="about">
                                <p>
                                    Age :
                            <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                                </p>
                                <p>
                                    Gender :
                            <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
                                </p>
                                <p>
                                    Country :
                            <asp:Label ID="lblCountry" runat="server" Text=""></asp:Label>
                                </p>
                                <p>
                                    About :
                            <asp:Label ID="lblAbout" runat="server" Text=""></asp:Label>
                                </p>
                            </div>
                            <div style="padding-left: 50px;" class="tab-pane" id="Contacts">
                                <p>
                                    Email :
                            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                </p>
                                <p>
                                    Mobile :
                            <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                                </p>
                            </div>
                            <div class="tab-pane" id="Channels">
                                <div class="row" style="padding-right: 20px;">
                                    <%--<asp:Button ID="btnCreateChannel" Style="float: right;" class="btn btn-danger" runat="server" Text="New Channel" OnClick="btnCreateChannel_Click" />--%>
                                </div>
                                <asp:Repeater ID="rptChannels" runat="server">
                                    <ItemTemplate>
                                        <div class="row" style="padding-top: 30px; padding-left: 30px; padding-right: 30px;">
                                            <div class="container col-xs-12" style="border-style: solid; border-color: #dddddd; border-width: thin; border-radius: 5px;">
                                                <div class="row" style="padding: 10px 10px">
                                                    <asp:Image ID="Image2" class="img-thumbnail" runat="server" ImageUrl='<%# string.Concat("~/images/channel/images/", "", Eval("chimage")) %>' Width="75px" />
                                                    <asp:LinkButton ID="btnChName" runat="server" Text='<%# Eval("chname") %>' OnClick="btnChName_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "chid") %>'></asp:LinkButton>
                                                </div>
                                                <div class="row" style="padding-left: 10px">
                                                    <p>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("chdescription") %>'></asp:Label>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

