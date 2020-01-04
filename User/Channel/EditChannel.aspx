<%@ Page Title="" Language="C#" MasterPageFile="~/User/Channel/Channel.master" AutoEventWireup="true" CodeFile="EditChannel.aspx.cs" Inherits="User_Channel_EditChannel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">Edit Channel</div>
            <div class="panel-body">
            <div style="padding: 20px">
                <div class="form-group row">
                    <div class="col-sm-3">
                        Channel Name :
                    </div>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtChName" class="form-control" Style="width: 60%;" runat="server" Enabled="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Channel needs Channel name" ValidationGroup="crChannel" ControlToValidate="txtChName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3">
                        Channel Image :
                    </div>
                    <div class="col-sm-9">
                        <asp:FileUpload ID="fuChImage" runat="server" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3">
                        Channel art :
                    </div>
                    <div class="col-sm-9">
                        <asp:FileUpload ID="fuChArt" runat="server" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3">
                        Channel Description :
                    </div>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtAboutChannel" class="form-control" Style="padding-right: 10px; resize: none;" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-5 col-sm-offset-4">
                        <asp:Button ID="btnCancelChannel" runat="server" Text="Cancel" class="btn btn-warning btn-sm" CausesValidation="False" OnClick="btnCancelChannel_Click" />&nbsp;
                       <asp:Button ID="btnUpdateChannel" class="btn btn-primary btn-sm" runat="server" Text="Update Channel" ValidationGroup="crChannel" OnClick="btnUpdateChannel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>

