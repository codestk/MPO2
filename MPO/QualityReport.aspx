<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QualityReport.aspx.cs"
    Inherits="MPO.QualityReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/bootstrap_R2.css" rel="stylesheet" type="text/css" />
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
        
        }
        #items {
  clear: both;
  width: 100%;
  margin: 30px 0 0 0;
  border: 1px solid black;
}
#items th {
  background: #eee;
}
table td, table th {
  border: 1px solid black;
  padding: 5px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
 
   
  
        
        
        <table cellspacing="0" rules="all" border="1" id="items" style="width:100%;border-collapse:collapse;">
		<tbody><tr>
			<th scope="col">Item</th><th scope="col">Description</th><th class="cost" scope="col">Unit Cost</th><th scope="col">Quantity</th><th scope="col">Price</th>
		</tr> 
               <tr>
                                    <td>
                                        <b>STK_ID
                                    </b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_STK_ID" runat="server" />
                                    </td>
                                    <td>
                                        <b>PR_LOT
                                    </b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_PR_LOT" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>MOISTURE
                                    </b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_MOISTURE" runat="server" />
                                    </td>
                                    <td>
                                        <b>PH
                                    </b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_PH" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>JELLY_ST
                                    </b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_JELLY_ST" runat="server" />
                                    </td>
                                    <td>
                                        <b>COLOR
                                    </b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_COLOR" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>ODOUR
                                    </b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_ODOUR" runat="server" />
                                    </td>
                                    <td>
                                        <b>SPOT
                                    </b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_SPOT" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>GRADE
                                    </b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_GRADE" runat="server" />
                                    </td>
                                    <td>
                                        <b>STOCK
                                    </b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_STOCK" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>REMARK
                                    </b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_REMARK" runat="server" />
                                    </td>
                                    <td>
                                        <b>DARN
                                    </b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_DARN" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>KUBOMI
                                    </b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_KUBOMI" runat="server" />
                                    </td>
                                    <td>
                                        <b>&nbsp;
                                    </b>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
	</tbody></table>
    </form>
</body>
</html>
