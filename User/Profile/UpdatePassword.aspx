<%@ Page Title="" Language="C#" MasterPageFile="~/User/Profile/Profile.master" AutoEventWireup="true" CodeFile="UpdatePassword.aspx.cs" Inherits="User_Profile_UpdatePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="updatepassword" class="row" runat="server">
        <div class="panel panel-default">
            <div class="panel-body">
                <div style="padding: 20px;">
                    <div class="form-group row">
                        <div class="col-sm-3">
                            Password :
                        </div>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtPwd" class="form-control" Style="width: 60%;" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RFVUPWD" runat="server" ErrorMessage="Please Enter password" ControlToValidate="txtPwd" ForeColor="Red" Display="Dynamic" ValidationGroup="upwd"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3">
                            Confirm Password :
                        </div>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtCpwd" class="form-control" Style="width: 60%;" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RFVUCPWD" runat="server" ErrorMessage="Please confirm Password" ControlToValidate="txtCpwd" ForeColor="Red" Display="Dynamic" ValidationGroup="upwd"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password does not match" Display="Dynamic" ForeColor="Red" ControlToCompare="txtPwd" ControlToValidate="txtCpwd" ValidationGroup="upwd"></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-5 col-sm-offset-4">
                            <asp:Button ID="btnCancelpwd" runat="server" Text="Cancel" class="btn btn-warning btn-sm" CausesValidation="False" OnClick="btnCancelpwd_Click" />&nbsp;
                       <asp:Button ID="btnpwdupdate" class="btn btn-primary btn-sm" runat="server" Text="Update Password" ValidationGroup="upwd" OnClick="btnpwdupdate_Click" />
                        </div>
                    </div>
                    <asp:Label ID="Label1" runat="server" Text="Password Updated Successfully" ForeColor="Red" Visible="False"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

