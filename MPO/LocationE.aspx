<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LocationE.aspx.cs" Inherits="MPO.LocationE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
        <script src="Scripts/StkCommon.js" type ="text/javascript"></script>
    <link href="Styles/FormDiy.css" rel="stylesheet" type="text/css" />
        <script src="Scripts/StkCommon.js" type="text/javascript"></script>
        
          
      <style>
        label {
  /* float: left; */
  /* width: 10em; */
  /* text-align: right; */
  /* margin-right: 1em; */
  float:none;
   width: 0em;
            text-align: left;
            margin-right: 0;
}
        input[type="radio"],input[type="checkbox"] {
/* padding: 0.15em;
  width: 10em;
  border: 1px solid #ddd;
  background: #fafafa;
  font: bold 0.95em arial, sans-serif;
  -moz-border-radius: 0.4em;
  -khtml-border-radius: 0.4em;*/
   width: 10px;
            padding: 0px;
            border: 0;
            -moz-border-radius: 0;
            -khtml-border-radius: 0;
}

 
    </style>
</head>
<body style="background-color: #ffffff">
     <form id="form1" runat="server">
 
            <fieldset style="width: 300px;margin-left: auto;margin-right: auto;">
                <legend>คลังสินค้า</legend>
                <table class="TableThickBox">
                    <tr>
                        <th align="right">
                            รหัสคลังสินค้า:
                        </th>
                        <td>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtLC_CODE" runat="server" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ชื่อคลังสินค้า:
                        </th>
                        <td>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtLC_NAME" runat="server" MaxLength="255" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ที่อยู่:
                        </th>
                        <td>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtLC_ADDRESS" runat="server" MaxLength="255" Rows="5" TextMode="MultiLine"
                                onkeyDown="checkTextAreaMaxLength(this,event,'255');" />
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            เบอร์โทร:
                        </th>
                        <td>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtLC_TEL" runat="server" MaxLength="50" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            รายละเอียด:
                        </th>
                        <td>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtLC_DEC" runat="server" MaxLength="255" Rows="5" TextMode="MultiLine"
                                onkeyDown="checkTextAreaMaxLength(this,event,'255');" />
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            สถานะ:</th>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:CheckBox ID="chkActive" runat="server" Text="Active" Checked="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="UpdateLinkButton" CommandName="update" ValidationGroup="UpdateCustomerVG"
                                onkeyDown="checkTextAreaMaxLength(this,event,'255');" Text="บันทึก" runat="server"
                                OnClick="UpdateLinkButton_Click" />&nbsp;
                            <asp:LinkButton ID="CancelLinkButton" CommandName="cancel" Text="ยกเลิก" runat="server"
                                OnClick="CancelLinkButton_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        
    </form>
</body>
</html>
