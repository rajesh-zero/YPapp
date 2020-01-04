<%@ Page Title="" Language="C#" MasterPageFile="~/User/Profile/Profile.master" AutoEventWireup="true" CodeFile="UpdateProfilePic.aspx.cs" Inherits="User_Profile_UpdateProfilePic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="editImage" class="row" runat="server">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="col-md-12" style="text-align: center">
                    <div class="row">
                        <div class="col-md-4">
                            <asp:FileUpload ID="fuphoto" runat="server" /></div>
                        <div class="col-md-4">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please select an Image" ControlToValidate="fuphoto" Display="Dynamic" ForeColor="Red" ValidationGroup="imgsave"></asp:RequiredFieldValidator></div>
                        <div class="col-md-4" style="padding-top: 10px;">
                            <asp:Button ID="btnUpdateImage" class="btn btn-primary btn-sm" runat="server" Text="Save Image" CausesValidation="True" ValidationGroup="imgsave" OnClick="btnUpdateImage_Click"/>
                            &nbsp;
                                <asp:Button ID="btnCancelImage" class="btn btn-warning btn-sm" runat="server" Text="Cancel" CausesValidation="False" OnClick="btnCancelImage_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

