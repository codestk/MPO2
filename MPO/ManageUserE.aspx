<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUserE.aspx.cs" Inherits="MPO.ManageUserE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/FormDiy.css" rel="stylesheet" type="text/css" />
 
    <script src="Scripts/StkCommon.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    
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
<body style="background-color:#fff;" >
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset style="width: 350px;margin-left: auto;margin-right: auto;">
                <legend>กำหนดผู้ใช้งาน</legend>
                <table class="TableThickBox">
                    <tr>
                        <th align="right">
                            UserName:
                        </th>
                        <td>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEM_ID" runat="server" MaxLength="10" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            Password:
                        </th>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEM_PASS" runat="server" MaxLength="20" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" valign=top>
                            สิทธิ์:
                        </th>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left" valign=top>
                            <asp:RadioButton ID="rdAdmin" runat="server" Text="Admin" Width="80px" GroupName="1"
                                OnCheckedChanged="rd_CheckedChanged" AutoPostBack="True" Checked="True" />
                             <%--   Change for Sale --%>

                                      <asp:RadioButton ID="rdUser" runat="server" Text="Super Visor" 
                                Width="100px" GroupName="1"
                                AutoPostBack="True" oncheckedchanged="rd_CheckedChanged"  />
                             
                            <asp:RadioButton ID="rdSale" runat="server" Text="Seller" Width="80px" GroupName="1"
                                OnCheckedChanged="rd_CheckedChanged" AutoPostBack="True" />
                            <asp:RadioButton ID="rdstock" runat="server" Text="Store " Width="100px" GroupName="1"
                                AutoPostBack="True" OnCheckedChanged="rd_CheckedChanged" />
                                          <asp:RadioButton ID="rdQc" runat="server" Text="QC" Width="80px" GroupName="1"
                                OnCheckedChanged="rd_CheckedChanged" AutoPostBack="True" />
                                 <asp:RadioButton ID="rdProduction" runat="server" Text="Production" 
                                Width="100px" GroupName="1"
                                AutoPostBack="True" oncheckedchanged="rd_CheckedChanged"  />
                            

                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            คำนำหน้า:
                        </th>
                        <td>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEM_TITLE" runat="server" MaxLength="20" Width="150px" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ชื่อ:
                        </th>
                        <td>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEM_NAME" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            นามสกุล:
                        </th>
                        <td>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEM_SURNAME" runat="server" MaxLength="50" Width="150px" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            E-Mail:
                        </th>
                        <td>
                            &nbsp;
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtEM_EMAIL" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ที่อยู่:
                        </th>
                        <td>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtEM_ADDRESS" runat="server" MaxLength="255" Rows="5" TextMode="MultiLine"
                                onkeyDown="checkTextAreaMaxLength(this,event,'255');" Width="150px" />
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            เบอร์โทร:
                        </th>
                        <td>
                            &nbsp;
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtEM_TEL" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            หมายเหตุ:
                        </th>
                        <td>
                            &nbsp;
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtEM_NOTE" runat="server" MaxLength="255" Rows="5" TextMode="MultiLine"
                                onkeyDown="checkTextAreaMaxLength(this,event,'255');" Width="150px" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
