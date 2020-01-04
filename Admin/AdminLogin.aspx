<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="Admin_AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="../bootstrap3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../bootstrap3.3.7/js/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-3.1.1.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <link href="../styles/StyleSheet.css" rel="stylesheet" />
    <script src="../styles/JavaScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container" id="regcontainer" runat="server" style="padding:25px;">
        <div class="jumbotron">
            <h3>Admin Login</h3>
            <div class="container">
                <div class="panel panel-success col-md-10">
                    <div class="container" style="margin-top: 30px; margin-bottom:15px;">                       
                            <div class="form-group row">
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtUsername" class="form-control" placeholder="Enter username" name="username" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RF_Val_Log_Username" runat="server" ErrorMessage="Please enter username" Display="Dynamic" ForeColor="Red" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
                                <%--    <asp:RegularExpressionValidator ID="RE_Val_Username" runat="server" ErrorMessage="Enter valid email" ControlToValidate="logUsername" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtPwd" class="form-control" placeholder="Enter password" name="password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RF_Val_Log_Pwd" runat="server" ErrorMessage="Please enter password" ControlToValidate="txtPwd" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            
                            <asp:Button ID="logSubmit" class="btn btn-success" runat="server" Text="Login" OnClick="logSubmit_Click"/>&nbsp;<asp:Label ID="Label1" runat="server" Text="Login Failed" ForeColor="Red" Visible="False"></asp:Label>
                            <hr />                    
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
