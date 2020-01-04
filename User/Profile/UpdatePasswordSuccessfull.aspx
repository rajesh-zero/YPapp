<%@ Page Title="" Language="C#" MasterPageFile="~/User/Profile/Profile.master" AutoEventWireup="true" CodeFile="UpdatePasswordSuccessfull.aspx.cs" Inherits="User_Profile_UpdatePasswordSuccessfull" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="trueSuccess" class="row" runat="server"  style="border-style: solid; border-color: #dddddd; border-width: thin; border-radius: 5px;">
        <div style="text-align:center;padding:75px;" >
            <img style="height: 25px; width: 25px; vertical-align:middle" src="../../images/logos/Greentick.png" />&nbsp;
            <h2 style="color: cadetblue">Password Updated Successfully</h2>
            <br />
            <a href="ProfilePage.aspx" style="text-align: center; color: blue">Back</a>
        </div>
    </div>
    <div id="falseMessage" class="row" runat="server" visible="false" style="border-style: solid; border-color: #dddddd; border-width: thin; border-radius: 5px;">
        <div style="text-align:center;padding:75px;">
            <h2 style="color: cadetblue">Something Went Wrong</h2>
            <br />
            <a href="ProfilePage.aspx" style="text-align: center; color: blue">Back</a>
        </div>
     </div>
</asp:Content>

