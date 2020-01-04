<%@ Page Title="" Language="C#" MasterPageFile="~/RegisterLogin/RegisterLogin.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register_Login_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:scriptmanager runat="server"></asp:scriptmanager>
            <div class="alert alert-info alert-dismissable container" id="registersuccess" runat="server" visible="false">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">×</a>
                <strong>Registered Successfully!</strong>
            </div>
    <br />
    <div class="container" id="regcontainer">
        <div class="jumbotron">
            <h3>Sign up for YouPaper</h3>
            <div class="container">
                <div class="panel panel-default">
                <div class="panel-body">
                    <div class="container col-xs-12" style="margin-top: 30px; margin-bottom: 15px;">
                        <div class="form-group row">
                            <div class="col-md-4">
                                <asp:TextBox ID="txtRName" class="form-control" placeholder="Enter Name" name="RName" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Minimum 3 and Maximum 50 characters required." Text="*" Display="Dynamic" Font-Size="X-Large" ToolTip="Minimum 3 and Maximum 50 characters allowed" ControlToValidate="txtRName" ForeColor="Red" ValidationExpression="^[\s\S]{3,50}$" ValidationGroup="register"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RFVRName" runat="server" ErrorMessage="Enter name &amp; surname" ControlToValidate="txtRName" Display="Dynamic" ValidationGroup="register" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="form-group row">
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtREmail" class="form-control" placeholder="Enter email" name="REmail" runat="server" AutoPostBack="True" OnTextChanged="txtREmail_TextChanged"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:RequiredFieldValidator ID="RFVREmail" runat="server" ErrorMessage="Enter email address" ControlToValidate="txtREmail" Display="Dynamic" ValidationGroup="register" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Minimum 3 and Maximum 50 characters required." Text="*" Display="Dynamic" Font-Size="X-Large" ToolTip="Minimum 3 and Maximum 50 characters allowed" ControlToValidate="txtREmail" ForeColor="Red" ValidationExpression="^[\s\S]{3,50}$" ValidationGroup="register"></asp:RegularExpressionValidator>
                                        <asp:RegularExpressionValidator ID="REVREmail" runat="server" ErrorMessage="Enter valid email address" ControlToValidate="txtREmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="register" ForeColor="Red"></asp:RegularExpressionValidator>
                                        <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="form-group row">
                            <div class="col-md-4">
                                <asp:RadioButton ID="RadioMale" runat="server" Checked="True" GroupName="gender" Text="Male" />
                                &nbsp
                                <asp:RadioButton ID="RadioFemale" runat="server" GroupName="gender" Text="Female" />
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-md-4">
                                <asp:TextBox ID="txtRPwd" class="form-control" placeholder="Enter password" name="RPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Minimum 3 and Maximum 50 characters required." Text="*" Display="Dynamic" Font-Size="X-Large" ToolTip="Minimum 3 and Maximum 50 characters allowed" ControlToValidate="txtRPwd" ForeColor="Red" ValidationExpression="^[\s\S]{6,20}$" ValidationGroup="register"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RFVRpwd" runat="server" ErrorMessage="Enter password" ControlToValidate="txtRPwd" Display="Dynamic" ValidationGroup="register" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-md-4">
                                <asp:TextBox ID="txtRCPwd" class="form-control" placeholder="Confirm password" name="RCPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RequiredFieldValidator ID="RFVRCpwd" runat="server" ErrorMessage="Confirm password" ControlToValidate="txtRCPwd" Display="Dynamic" ValidationGroup="register" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CVRCpwd" runat="server" ErrorMessage="Password does not match" ControlToCompare="txtRPwd" ControlToValidate="txtRCPwd" Display="Dynamic" ValidationGroup="register" ForeColor="Red"></asp:CompareValidator>
                            </div>
                        </div>
                        <asp:Button ID="BtnSignup" type="submit" class="btn btn-success" runat="server" Text="Sign up" ValidationGroup="register" OnClick="BtnSignup_Click"/>
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
    </div>
</asp:Content>

