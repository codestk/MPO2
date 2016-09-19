<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PRintBacrCode_Img.aspx.cs" Inherits="MPO.PRintBacrCode_Img" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
      <script src="Jquery/js/jquery-1.6.1.min.js" type="text/javascript"></script> 
    <style media="print">
        input
        {
            display: none !important;
        }
    </style>
    
    
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div style="margin-bottom: 20px;">
        <asp:Image ID="BarcodeImage" runat="server" />
    </div>
   <%-- <asp:Button ID="Button1" runat="server" Text="พิมพ์" CssClass="btn btn-primary" OnClientClick="javascript:window.print();window.close();return true; "
        OnClick="Button1_Click" />--%>
        <script>
            window.print();
            setTimeout(function () { window.close(); }, 120);
        </script>
    </form>
</body>
</html>