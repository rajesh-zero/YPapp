<%@ Page Title="" Language="C#" MasterPageFile="~/RegisterLogin/RegisterLogin.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Register_Login_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="alert alert-danger alert-dismissable fade in container" id="loginfailed" runat="server" visible="false">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Login failed!</strong> <u>Incorrect username or Password</u>
    </div>
    <div class="alert alert-danger alert-dismissable fade in container" id="PendingVerification" runat="server" visible="false">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Verification Pending! </strong> <u>Check your email</u>
    </div>
        <div class="container" id="regcontainer">
        <div class="jumbotron">
            <h3>Login for YouPaper</h3>
            <div class="container">
                <div class="panel panel-default col-md-8">
                    <div class="panel-body">
                        <div class="container col-xs-12" style="margin-top: 30px; margin-bottom: 15px;">
                            <div class="form-group row">
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtLEmail" class="form-control" placeholder="Enter email" name="LEmail" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RFVLEmail" runat="server" ErrorMessage="Enter email address" ControlToValidate="txtLEmail" Display="Dynamic" ValidationGroup="login" ForeColor="Red"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="REVLEmail" runat="server" ErrorMessage="Enter valid email address" ControlToValidate="txtLEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="login" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtLPwd" class="form-control" placeholder="Enter password" name="LPassword" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RFVLPwd" runat="server" ErrorMessage="Enter Password" Display="Dynamic" ControlToValidate="txtLPwd" ValidationGroup="login" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="checkbox">
                                <label>
                                    <asp:CheckBox ID="ChkBxRemember" name="remember" runat="server" />
                                    Remember me
                                </label>
                            </div>
                            <asp:Button ID="BtnLogin" runat="server" class="btn btn-primary" Text="Login" ValidationGroup="login" OnClick="BtnLogin_Click" />&nbsp;&nbsp;&nbsp;<a href="ResetPassword.aspx">Forgot password?</a>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <p style="text-align: center; font-size: medium">Or Login using</p>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6">
                                <asp:Button ID="btnGoogle" runat="server" class="form-control btn btn-success" Text="Google" CausesValidation="False" OnClick="btnGoogle_Click"/>
                            </div>
                            <div class="col-sm-6">
                                <asp:Button ID="btnFacebook" runat="server" class="form-control btn btn-primary" Text="Facebook" CausesValidation="False" OnClick="btnFacebook_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
</asp:Content>

