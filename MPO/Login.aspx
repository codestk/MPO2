<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MPO.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>เข้าสู่ระบบ</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
    
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/login-box.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Loginpage">
        <div id="login-box">
            <h2>
                เข้าสู่ระบบ</h2>
            <br />
            <br />
            <div id="Div2">
                <asp:Label ID="lblError" runat="server" Text="กรุณาระบุ UserName และ Password ให้ถูกต้อง"
                    CssClass="ErrorValidate" Visible="False"></asp:Label>
            </div>
            <div id="login-box-name" style="margin-top: 20px;">
                UserName:</div>
            <div id="login-box-field" style="margin-top: 20px;">
                <asp:TextBox ID="txtUserName" runat="server" class="form-login" MaxLength="20" AutoCompleteType="Disabled">admin</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
            <div id="login-box-name">
                Password:</div>
            <div id="login-box-field">
                <asp:TextBox ID="txtUserPass" runat="server" TextMode="Password" class="form-login"
                    AutoCompleteType="None"></asp:TextBox>
                <%-- <asp:TextBox ID="txtUserPass" runat="server"  class="form-login" AutoCompleteType="None">admin</asp:TextBox> --%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" c ControlToValidate="txtUserPass"
                    CssClass="ErrorValidate" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
            <br />
            <span class="login-box-options">
                <asp:CheckBox ID="chkPersistCookie" runat="server" Text="จดจำ" />
            </span>
            <br />
            <br />
            <asp:ImageButton ID="ImageButton1" runat="server" Width="103" Style="margin-left: 90px;"
                ImageUrl="~/images/login-btn.png" OnClick="ImageButton1_Click" />
            <div class="login-box-company">
                SURIMI STORE</div>
        </div>
    </div>
   
    </form>
</body>
</html>
