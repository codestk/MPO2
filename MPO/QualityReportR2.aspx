<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QualityReportR2.aspx.cs"
    Inherits="MPO.QualityReportR2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/FormDiy.css" rel="stylesheet" type="text/css" />
    <style>
        input[type="text"]
        {
            width: 150px;
            display: block;
            border: none;
            margin-bottom: 3px;
            border-bottom-style: solid;
            border-bottom-color: #a9a9a9;
            border-bottom-width: 1px;
        }
        
        @media print
        {
            input[type="submit"]
            {
                display: none;
            }
        
            .printNon
            {
                display: none;
            }
        
        }
        #items
        {
            clear: both;
            width: 100%;
            margin: 30px 0 0 0;
            border: 1px solid black;
        }
        #items th
        {
            background: #eee;
            text-align: left;
        }
        table td, table th
        {
            border: 1px solid black;
            padding: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table cellspacing="0" rules="all" border="1" id="items" style="width: 100%; border-collapse: collapse;">
        <tbody>
            <tr>
                <th scope="col" colspan="4">
                    Quality Report
                </th>
            </tr>
            <tr>
                <td>
                    <b>Code </b>
                </td>
                <td>
                    <asp:TextBox ID="txt_STK_ID" runat="server" Enabled="False" />
                </td>
                <td>
                    <b>No. </b>
                </td>
                <td>
                    <asp:TextBox ID="txt_PR_LOT" runat="server" Enabled="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <b>MOISTURE </b>
                </td>
                <td>
                    <asp:TextBox ID="txt_MOISTURE" runat="server" />
                </td>
                <td>
                    <b>PH </b>
                </td>
                <td>
                    <asp:TextBox ID="txt_PH" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <b>JELLY_ST </b>
                </td>
                <td>
                    <asp:TextBox ID="txt_JELLY_ST" runat="server" />
                </td>
                <td>
                    <b>COLOR </b>
                </td>
                <td>
                    <asp:TextBox ID="txt_COLOR" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <b>ODOUR </b>
                </td>
                <td>
                    <asp:TextBox ID="txt_ODOUR" runat="server" />
                </td>
                <td>
                    <b>SPOT </b>
                </td>
                <td>
                    <asp:TextBox ID="txt_SPOT" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <b>GRADE </b>
                </td>
                <td>
                    <asp:TextBox ID="txt_GRADE" runat="server" />
                </td>
                <td>
                    <b>STOCK </b>
                </td>
                <td>
                    <asp:TextBox ID="txt_STOCK" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <b>REMARK </b>
                </td>
                <td>
                    <asp:TextBox ID="txt_REMARK" runat="server" />
                </td>
                <td>
                    <b>DARN </b>
                </td>
                <td>
                    <asp:TextBox ID="txt_DARN" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <b>KUBOMI </b>
                </td>
                <td>
                    <asp:TextBox ID="txt_KUBOMI" runat="server" />
                </td>
                <td>
                    <b>&nbsp; </b>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="3">
                    <asp:Image ID="BarcodeImage" runat="server" />
                </td>
            </tr>
        </tbody>
    </table>
    <div style="width: 100%; text-align: center; margin-top: 5px;">
        <asp:Button ID="Button1" runat="server" Text="พิมพ์" OnClientClick="javascript:window.print();return false;" />
        &nbsp;<asp:Button ID="Button2" runat="server" Text="บันทึก" OnClick="Button2_Click"
            />
    </div>
    <asp:GridView ID="GvHisTory" CssClass="mGrid printNon"
        AutoGenerateColumns="False"  DataKeyNames="CAHNGE_ID"
    
        onselectedindexchanged="GvHisTory_SelectedIndexChanged"  runat="server" >
        <Columns>
              <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="CAHNGE_ID" HeaderText="CAHNGE_ID" SortExpression="CAHNGE_ID" />
            <asp:BoundField DataField="ORDE_ID" HeaderText="ORDE_ID" SortExpression="ORDE_ID" />
            <asp:BoundField DataField="MOISTURE" HeaderText="MOISTURE" SortExpression="MOISTURE" />
            <asp:BoundField DataField="PH" HeaderText="PH" SortExpression="PH" />
            <asp:BoundField DataField="JELLY_ST" HeaderText="JELLY_ST" SortExpression="JELLY_ST" />
            <asp:BoundField DataField="COLOR" HeaderText="COLOR" SortExpression="COLOR" />
            <asp:BoundField DataField="ODOUR" HeaderText="ODOUR" SortExpression="ODOUR" />
            <asp:BoundField DataField="SPOT" HeaderText="SPOT" SortExpression="SPOT" />
            <asp:BoundField DataField="GRADE" HeaderText="GRADE" SortExpression="GRADE" />
            <asp:BoundField DataField="STOCK" HeaderText="STOCK" SortExpression="STOCK" />
          <%--  <asp:BoundField DataField="REMARK" HeaderText="REMARK" SortExpression="REMARK" />--%>
            <asp:BoundField DataField="DARN" HeaderText="DARN" SortExpression="DARN" />
            <asp:BoundField DataField="KUBOMI" HeaderText="KUBOMI" SortExpression="KUBOMI" />
            <asp:BoundField DataField="CHANGE_BY" HeaderText="CHANGE_BY" SortExpression="CHANGE_BY" />
            <asp:BoundField DataField="CHANGE_DATE" HeaderText="CHANGE_DATE" 
                SortExpression="CHANGE_DATE"   />
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
