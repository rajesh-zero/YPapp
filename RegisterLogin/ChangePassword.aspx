<%@ Page Title="" Language="C#" MasterPageFile="~/RegisterLogin/RegisterLogin.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="RegisterLogin_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" id="regcontainer">
        <div class="jumbotron col-md-8">
            <h3>Change password</h3>
            <div class="container">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="container">
                            <div>
                                <div id="divPassword" runat="server" visible="false">
                                    <div class="form-group row">
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtNewPwd" class="form-control" placeholder="new password" runat="server" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtConfirmPwd" class="form-control" placeholder="confirm password" runat="server" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:Button ID="btnChangePwd" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnChangePwd_Click" />
                                    <br />
                                    <br />
                                </div>
                                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

