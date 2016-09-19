<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="MPO.AddProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Jquery/js/jquery-1.6.1.min.js" type="text/javascript"></script>
    
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/FormDiy.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/Stk/Momojojo_Web-1.0.1.0.js"></script>
    <link href="Jquery/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="Jquery/jquery.ui.theme.css" rel="stylesheet" type="text/css" />
    <script src="Jquery/js/jquery-ui-1.8.10.offset.datepicker.min.js" type="text/javascript"></script>
    <link href="Styles/FormDiy.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/CalendarSet.js" type="text/javascript"></script>
    <style>
        .Force2Digit
        {
            width: 50px;
        }
    </style>
    <script>
        ForceNumberTextBox();
        function ForceNumberTextBox() {

            $(".Force2Digit").ForceNumericOnly2Digit();

        }
    </script>
</head>
<body style="background-color: #ffffff">
    <form id="form1" runat="server">
    <fieldset style="margin-left: auto; margin-right: auto; width: 700px;">
        <legend>ค้นหาสินค้า</legend>
        <table>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: left" class="auto-style3">
                    แหล่งปลา
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="drpSource" CssClass="chosen-select" runat="server" Width="160px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td style="text-align: left">
                    Color
                </td>
                <td>
                    <asp:TextBox ID="txtCOLOR1" CssClass="Force2Digit" runat="server"></asp:TextBox>
                    To
                    <asp:TextBox ID="txtCOLOR2" CssClass="Force2Digit" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: left" class="auto-style3">
                    รหัสปลา
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="drpFishID" runat="server" CssClass="chosen-select" Width="160px"
                        >
                    </asp:DropDownList>
                </td>
                <td style="text-align: left">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    Moisture
                </td>
                <td>
                    <%--   <asp:DropDownList ID="drpMoisture" runat="server" CssClass="chosen-select" Width="160px">
                        </asp:DropDownList>--%>
                    <asp:TextBox ID="txtMoisture1" CssClass="Force2Digit" runat="server"></asp:TextBox>
                    To
                    <asp:TextBox ID="txtMoisture2" CssClass="Force2Digit" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: left" class="auto-style3">
                    ชนิดกล่อง
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="drpPR_BOX_TYPE" runat="server" CssClass="chosen-select" Width="160px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: left">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    Darn
                </td>
                <td>
                    <asp:TextBox ID="txtDarn1" CssClass="Force2Digit" runat="server"></asp:TextBox>
                    To
                    <asp:TextBox ID="txtDarn2" CssClass="Force2Digit" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: left" class="auto-style3">
                    วันที่บรรจุ
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtPR_PACK_DATE" CssClass="ControlDatePicker" Width="100" runat="server"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    Odour
                </td>
                <td>
                    <asp:TextBox ID="txtOdour1" CssClass="Force2Digit" runat="server"></asp:TextBox>
                    To
                    <asp:TextBox ID="txtOdour2" CssClass="Force2Digit" runat="server"></asp:TextBox>
                    <%--  <asp:DropDownList ID="drpOdour" runat="server" CssClass="chosen-select" Width="160px">
                        </asp:DropDownList>--%>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: left" class="auto-style3">
                    ขนาดปลา
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="drpFishSize" runat="server" CssClass="chosen-select" Width="160px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: left">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    PH
                </td>
                <td>
                    <asp:TextBox ID="txtPH1" CssClass="Force2Digit" runat="server"></asp:TextBox>
                    To
                    <asp:TextBox ID="txtPH2" CssClass="Force2Digit" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: left" class="auto-style3">
                    สีสายรัด
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropPR_LINE_COLOR" runat="server" CssClass="chosen-select"
                        Width="160px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: left">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    Spot
                </td>
                <td>
                    <asp:TextBox ID="txtSpot1" CssClass="Force2Digit" runat="server"></asp:TextBox>
                    To
                    <asp:TextBox ID="txtSpot2" CssClass="Force2Digit" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: left" class="auto-style3">
                    เงื่อนไข
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="drpPR_CONDITION" runat="server" CssClass="chosen-select" Width="160px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: left">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    Kubomi
                </td>
                <td>
                    <asp:TextBox ID="txtKubomi1" CssClass="Force2Digit" runat="server"></asp:TextBox>
                    To
                    <asp:TextBox ID="txtKubomi2" CssClass="Force2Digit" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: left">
                    เกรด
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtGrade" runat="server"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    Jelly St
                </td>
                <td>
                    <asp:TextBox ID="txtJellySt1" CssClass="Force2Digit" runat="server"></asp:TextBox>
                    To
                    <asp:TextBox ID="txtJellySt2" CssClass="Force2Digit" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: right" class="auto-style3">
                    &nbsp;
                </td>
                <td class="auto-style2">
                    &nbsp;
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                    <div style="display: none">
                        <input id="Button3" onclick="ClearData();" type="button" value="Reset" /></div>
                </td>
                <td style="text-align: right">
                    &nbsp;
                </td>
                <td style="text-align: right">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </fieldset>
    <table class="style1">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="STK_ID"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowHeaderWhenEmpty="True"
                    GridLines="None" Caption="สินค้า" EmptyDataText="ไม่พบข้อมูล" CssClass="mGrid"
                    OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="เพิ่ม" />
                        <asp:BoundField DataField="STK_ID" HeaderText="STK_ID" SortExpression="STK_ID" />
                        <asp:BoundField DataField="PR_LOT" HeaderText="No." SortExpression="PR_LOT" />
                        <asp:BoundField DataField="PR_PRODUCE_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ผลิต"
                            SortExpression="PR_PRODUCE_DATE" />
                        <asp:BoundField DataField="PR_SOURCE" HeaderText="แหล่งปลา" SortExpression="PR_SOURCE" />
                        <asp:BoundField DataField="FISH_ID" HeaderText="รหัสปลา " SortExpression="FISH_ID" />
                        <asp:BoundField DataField="PR_SIZE" HeaderText="ขนาดปลา " SortExpression="PR_SIZE" />
                        <asp:BoundField DataField="PR_REV_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่รับปลาตัว"
                            SortExpression="PR_REV_DATE" />
                        <asp:BoundField DataField="PR_CUT_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ตัดหัวปลา"
                            SortExpression="PR_CUT_DATE" />
                        <asp:BoundField DataField="PR_LINE" HeaderText="ไลน์ผลิต" SortExpression="PR_LINE" />
                        <asp:BoundField DataField="PR_CONDITION" HeaderText=" เงื่อนไขผลิต " SortExpression="PR_CONDITION" />
                        <asp:BoundField DataField="PR_WEIGHT" HeaderText="น้ำหนักผลิตได้" SortExpression="PR_WEIGHT" />
                        <asp:BoundField DataField="PR_PACK_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="กำหนดวันที่บรรจุ"
                            SortExpression="PR_PACK_DATE" />
                        <asp:BoundField DataField="PR_BOX_TYPE" HeaderText="ชนิดกล่อง" SortExpression="PR_BOX_TYPE" />
                        <asp:BoundField DataField="PR_LINE_COLOR" HeaderText="สีสายลัด" SortExpression="PR_LINE_COLOR" />
                        <asp:BoundField DataField="ITEMS" HeaderText="จำนวน" SortExpression="ITEMS" />
                        <asp:TemplateField HeaderText="ใช้ได้">
                            <ItemTemplate>
                                <%#  AvaliableItem(Eval("STK_ID"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                    <td colspan="16">
                                        <asp:GridView ID="gvQC" runat="server" BackColor="White" BorderColor="#CCCCCC" AutoGenerateColumns="False"
                                            Width="100%" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                            CssClass="tablestyle" GridLines="Horizontal">
                                            <HeaderStyle BackColor="red"></HeaderStyle>
                                            <Columns>
                                                <asp:BoundField DataField="MOISTURE" HeaderText="MOISTURE" SortExpression="MOISTURE" />
                                                <asp:BoundField DataField="PH" HeaderText="PH" SortExpression="PH" />
                                                <asp:BoundField DataField="JELLY_ST" HeaderText="JELLY_ST" SortExpression="JELLY_ST" />
                                                <asp:BoundField DataField="COLOR" HeaderText="COLOR" SortExpression="COLOR" />
                                                <asp:BoundField DataField="ODOUR" HeaderText="ODOUR" SortExpression="ODOUR" />
                                                <asp:BoundField DataField="SPOT" HeaderText="SPOT" SortExpression="SPOT" />
                                                <asp:BoundField DataField="GRADE" HeaderText="GRADE" SortExpression="GRADE" />
                                                <asp:BoundField DataField="STOCK" HeaderText="STOCK" SortExpression="STOCK" />
                                                <asp:BoundField DataField="DARN" HeaderText="DARN" SortExpression="DARN" />
                                                <asp:BoundField DataField="KUBOMI" HeaderText="KUBOMI" SortExpression="KUBOMI" />
                                                <asp:BoundField DataField="REMARK" HeaderText="REMARK" SortExpression="REMARK" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="100%" style="background-color: #b">
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                    <RowStyle CssClass="RowStyle" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
