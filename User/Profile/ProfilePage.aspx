<%@ Page Title="" Language="C#" MasterPageFile="~/User/Profile/Profile.master" AutoEventWireup="true" CodeFile="ProfilePage.aspx.cs" Inherits="User_Profile_ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../styles/profiletab.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                        <p>Age :
                            <asp:Label ID="lblAge" runat="server" Text=""></asp:Label></p>
                        <p>Gender :
                            <asp:Label ID="lblGender" runat="server" Text=""></asp:Label></p>
                        <p>Country :
                            <asp:Label ID="lblCountry" runat="server" Text=""></asp:Label></p>
                        <p>About :
                            <asp:Label ID="lblAbout" runat="server" Text=""></asp:Label></p>
                    </div>
                    <div style="padding-left: 50px;" class="tab-pane" id="Contacts">
                        <p>Email :
                            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></p>
                        <p>Mobile :
                            <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label></p>
                    </div>
                    <div class="tab-pane" id="Channels">
                        <div class="row" style="padding-right: 20px;">
                            <asp:Button ID="btnCreateChannel" Style="float: right;" class="btn btn-danger" runat="server" Text="New Channel" OnClick="btnCreateChannel_Click" />
                        </div>
                        <asp:Repeater ID="rptChannels" runat="server">
                            <ItemTemplate>
                                <div class="row" style="padding-top:30px;padding-left:30px;padding-right:30px;">
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
    <div class="row" style="padding-top: 20px">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-2" style="text-align: center">
                        <asp:Button ID="btnUpdatePwd" class="btn btn-warning btn-sm" runat="server" Text="Update Password" CausesValidation="False" OnClick="btnUpdatePwd_Click" />
                    </div>
                    <div class="col-md-2" style="text-align: center">
                        <asp:Button ID="btnDeleteUser" class="btn btn-danger btn-sm" runat="server" Text="Delete Account" CausesValidation="False" OnClick="btnDeleteUser_Click"/>
                    </div>
                    <div class="col-md-2 col-md-offset-8" style="text-align: center; padding-top: 10px;">
                        <asp:Button ID="btnEditView" class="btn btn-default btn-sm" runat="server" Text="Edit Profile" CausesValidation="False" OnClick="btnEditView_Click" />
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

