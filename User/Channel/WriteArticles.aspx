<%@ Page Title="" Language="C#" MasterPageFile="~/User/Channel/Channel.master" AutoEventWireup="true" CodeFile="WriteArticles.aspx.cs" Inherits="User_Channel_WriteArticles" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <div id="form1" runat="server">
        <div class="container">
            <div class="col-md-12">
                <div class="row" style="padding-top: 20px">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            Post on Channel : <asp:Label ID="lblName" runat="server" Text="" ForeColor="#000099"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row" style="border-style: solid; border-color: #dddddd; border-width: thin; border-radius: 5px;">
                    <div class="container" style="padding: 20px;">
                        <div class="row  col-xs-12">
                            <div class="col-md-9">
                                <asp:TextBox ID="txtHeading" class="form-control" placeholder="Title for article ...." runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVheading" runat="server" ErrorMessage="Heading is compulsory" ControlToValidate="txtHeading" Display="Dynamic" Font-Size="Small" ForeColor="Red" ToolTip="Heading is compulsory" ValidationGroup="ValPublish"></asp:RequiredFieldValidator>&nbsp;
                                <asp:RequiredFieldValidator ID="RFVheadingDraft" runat="server" ControlToValidate="txtHeading" Display="Dynamic" ErrorMessage="Heading is compulsory" Font-Size="Small" ForeColor="Red" ValidationGroup="ValDraft"></asp:RequiredFieldValidator>
&nbsp;<asp:RequiredFieldValidator ID="RFVpreview" runat="server" ControlToValidate="txtHeading" Display="Dynamic" ErrorMessage="Heading is compulsory" Font-Size="Small" ForeColor="Red" ValidationGroup="ValPreview"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3" style="text-align: center">
                                <asp:Button ID="btnCancel" class="btn btn-warning" runat="server" Text="Cancel" CausesValidation="False" OnClick="btnCancel_Click" />
                                &nbsp;
                                <asp:Button ID="btnPublish" class="btn btn-primary" runat="server" Text="Publish" OnClick="btnPublish_Click" ValidationGroup="ValPublish" />
                                &nbsp;
                                <asp:Button ID="btnPreview" class="btn btn-success" runat="server" Text="Preview" OnClick="btnPreview_Click" ToolTip="If it is not working then enable pop ups in your browser." ValidationGroup="ValPreview" />
                            </div>
                        </div>
                        <div class="row  col-xs-12">
                            <div class="col-md-5">
                                <asp:DropDownList ID="DropDownCategory" runat="server" class="form-control" DataSourceID="SqlDataSource1" DataTextField="cname" DataValueField="cid"></asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="Data Source=LAPTOP-RAJESH\SQLEXPRESS;Initial Catalog=YouPaper;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [cname], [cid] FROM [category]"></asp:SqlDataSource>
                             </div>&nbsp;
                            <div class="col-md-5">
                                <div class="col-xs-4"><h5>Select thumbnail : </h5></div><div class="col-xs-8"><asp:FileUpload ID="fuThumbnail" class="form-control" runat="server"/></div>
                            </div>
                        </div>
                    </div>
                    <div class="container col-xs-12" style="padding: 0px 35px;" >
                        <CKEditor:CKEditorControl ID="CKEditor1" runat="server" Skin="kama" UIColor="#FFFFFF" Toolbar="Source|-|Find|Replace|-|SelectAll|-|Bold|Italic|Underline|Strike|-|Subscript|SuperscriptNumberedList|BulletedList|-|Outdent|Indent|Blockquote|CreateDiv|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlockBidiLtr|Table|HorizontalRule|Smiley|SpecialChar|Styles|Format|Font|FontSize|TextColor|BGColor|Maximize" ResizeEnabled="False" EditingBlock="True" Height="600px"></CKEditor:CKEditorControl>
                        <br />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="col-md-2 col-md-offset-10" style="text-align: center">
                                <asp:Button ID="btnDraft" class="btn btn-danger btn-sm" runat="server" Text="Save Draft" OnClick="btnDraft_Click" ValidationGroup="ValDraft" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
</asp:Content>

