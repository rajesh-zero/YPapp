<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        jQuery(function ($) {
            var windowWidth = $(window).width();
            var windowHeight = $(window).height();

            $(window).resize(function () {
                if (windowWidth != $(window).width() || windowHeight != $(window).height()) {
                    location.reload();
                    return;
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <asp:DataList ID="dtlistArticle" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="row">
            <ItemTemplate>
                <div class="col-xs-3" style="margin:20px; border: 1px solid grey; border-radius: 5px; box-shadow: 3px 3px 5px #d3d3d3; height: 300px; width:320px">
                    <div style="margin:20px;">
                    <div class="row">
                        <asp:ImageButton ID="ImgBtnThumbnail" style="height: 158px; width:280px" ToolTip='<%# Eval("heading") %>' ImageUrl='<%# string.Concat("~/images/articles/articleImage/", "", Eval("thumbnail")) %>' OnClick="ImgBtnThumbnail_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>' runat="server" />
                    </div>
                    <div class="row">
                        <asp:LinkButton ID="lbtnHeading" runat="server"
                            ForeColor="#000000"
                            Text='<%# Limit(Eval("heading"),76) %>'
                            ToolTip='<%# Eval("heading") %>' OnClick="lbtnHeading_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "artid") %>'>
                        </asp:LinkButton>
                    </div>
                    <div class="row">
                        <asp:LinkButton ID="lbtnChannelname" runat="server" Text='<%# Eval("chname") %>' OnClick="lbtnChannelname_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "chid") %>'></asp:LinkButton>
                    </div>
                    <div class="row">
                        <hr style="padding: 0px; margin: 5px;"/>
                            <asp:Label ID="viewgs" runat="server" Text='<%# string.Concat("views : ", "", Eval("views")) %>' />
                            &nbsp;<asp:Label ID="likges" runat="server" Text='<%# string.Concat("likes : ", "", Eval("likes")) %>'></asp:Label>
                            &nbsp;<asp:Label ID="dislgikes" runat="server" Text='<%# string.Concat("dislikes : ", "", Eval("dislikes")) %>'></asp:Label>
                    </div>
                    </div>
                </div>
                </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>



