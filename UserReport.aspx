<%@ Page Title="" Language="C#" MasterPageFile="~/Reports.master" AutoEventWireup="true" CodeFile="UserReport.aspx.cs" Inherits="UserReport" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="UserCR.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

