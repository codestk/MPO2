<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifyPassword.aspx.cs" Inherits="MPO.VerifyPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/FormDiy.css" rel="stylesheet" type="text/css" />
 
</head>
<body style="background-color: #ffffff">
    <form id="form1" runat="server">
     <fieldset style="width: 350px;margin-left: auto;margin-right: auto;">
                <legend>โปรดระบุ Password เพื่อยืนยัน</legend>
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPWd" TextMode="Password" runat="server"></asp:TextBox>
                        </td>
                       
                    </tr>
                       <tr>
                        <td>
                            <asp:Button ID="btnVer" runat="server" Text="Confirm" onclick="btnVer_Click" />
                        </td>
                       
                    </tr>
                    <tr>
                        
                        <td>
                            <asp:Label ID="lblMsg" runat="server"></asp:Label> 

                        </td>
                    </tr>
                </table>

 </fieldset>
    </form>
</body>
</html>
