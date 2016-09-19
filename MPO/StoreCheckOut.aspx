<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="StoreCheckOut.aspx.cs" Inherits="MPO.StoreCheckOut" %>
<%@ Import Namespace="MPO.Code.Bu.ColumnGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: right;
            font-weight: 700;
        }
    </style>
    <script src="Scripts/CalendarSet.js" type="text/javascript"></script>


    <link href="JqueryControls/TimePicker/jquery.timepicker.css" rel="stylesheet" type="text/css" />
    <script src="JqueryControls/TimePicker/jquery.timepicker.min.js" type="text/javascript"></script>
    <script src="JqueryControls/TimePicker/jquery.timepicker.js" type="text/javascript"></script>
    <link href="JqueryControls/TimePicker/jquery.timepicker.min.css" rel="stylesheet"
        type="text/css" />
    <script>
        $(document).ready(function () {
            $('#<%=txt_OPENING_TIME.ClientID %>').timepicker();
            $('#<%=txt_CLOSING_TIME.ClientID %>').timepicker();
            ForceNumberTextBox();
        });

        //For Validate Type
        function ForceNumberTextBox() {


            $(".ForceNumber").ForceNumericOnly();


            $(".Force2Digit").ForceNumericOnly2Digit();

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
    
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                    DataKeyNames="OR_ID" ShowHeaderWhenEmpty="True" 
                    EmptyDataText="ไม่พบข้อมูล"  Caption="ใบสั่งซื้อ"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="เลือก" />
                        <asp:BoundField DataField="OR_ID" HeaderText="เลขใบสั่งซื้อ" SortExpression="OR_ID" />
                        <asp:BoundField DataField="CUS_ID" HeaderText="CUS_ID" SortExpression="CUS_ID" />
                    <%--    <asp:BoundField DataField="CUS_ID" HeaderText="CUS_ID" SortExpression="CUS_ID" />--%>
                        <asp:BoundField DataField="COMPANY" HeaderText="COMPANY" SortExpression="COMPANY" />
                        <asp:BoundField DataField="ADDR1" HeaderText="ADDR1" SortExpression="ADDR1" />
                        <asp:BoundField DataField="ADDR2" HeaderText="ADDR2" SortExpression="ADDR2" />
                        <asp:BoundField DataField="CITY" HeaderText="CITY" SortExpression="CITY" />
                        <asp:BoundField DataField="STATE" HeaderText="STATE" SortExpression="STATE" />
                        <asp:BoundField DataField="ZIP" HeaderText="ZIP" SortExpression="ZIP" />
                        <%--<asp:BoundField DataField="COUNTRY" HeaderText="COUNTRY" SortExpression="COUNTRY" />--%>
                        <asp:BoundField DataField="PHONE" HeaderText="PHONE" SortExpression="PHONE" />
                        <asp:BoundField DataField="FAX" HeaderText="FAX" SortExpression="FAX" />
                        <asp:BoundField DataField="CONTACT" HeaderText="CONTACT" SortExpression="CONTACT" />
                        <asp:BoundField DataField="BYUSER" HeaderText="BYUSER" SortExpression="BYUSER" />
                        <asp:BoundField DataField="ORDER_DATE" HeaderText="ORDER_DATE" SortExpression="ORDER_DATE"
                            DataFormatString="{0:dd/MM/yyyy}" />
                       <asp:TemplateField HeaderText="สถานะ">
                <ItemTemplate>
                    <%# GetCommonColumn.ConvertOrderStatus(Eval("STATUS"))%>
                </ItemTemplate>
            </asp:TemplateField>
                    </Columns>
                    <RowStyle />
                    <SelectedRowStyle />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <RowStyle CssClass="RowStyle" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table class="style1">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="GridView2" runat="server" DataKeyNames="ORDE_ID"  CssClass="mGrid"
                                Caption="รายการนำออก" CaptionAlign="Left" 
                                OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnRowDataBound="GridView2_RowDataBound"
                                AutoGenerateColumns="False">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="นำออก" />
                                    <asp:BoundField DataField="ORDE_ID" HeaderText="ลำดับ" SortExpression="ORDE_ID" />
                                    <asp:BoundField DataField="OR_ID" HeaderText="เลขใบสั่ง" SortExpression="OR_ID" />
                                    <asp:BoundField DataField="STK_ID" HeaderText="STK_ID" SortExpression="STK_ID" />
                                    <asp:BoundField DataField="PR_LOT" HeaderText="PR_LOT" SortExpression="PR_LOT" />
                                    <asp:TemplateField HeaderText="Product">
                                        <ItemTemplate>
                                            <%# GetProductName(Eval("PR_LOT"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ITEMS" HeaderText="ITEMS" SortExpression="ITEMS" />
                                    <asp:BoundField DataField="COST" HeaderText="COST" SortExpression="COST" />
                                    <asp:BoundField DataField="LOADINGDATE" HeaderText="LOADINGDATE" SortExpression="LOADINGDATE" />
                                    <asp:BoundField DataField="SHIPMENTNO" HeaderText="SHIPMENTNO" SortExpression="SHIPMENTNO" />
                                    <asp:BoundField DataField="CONTAINERNO" HeaderText="CONTAINERNO" SortExpression="CONTAINERNO" />
                                    <asp:BoundField DataField="TRUCKNO" HeaderText="TRUCKNO" SortExpression="TRUCKNO" />
                                    <asp:BoundField DataField="STAMP" HeaderText="STAMP" SortExpression="STAMP" />
                                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
                              <%--      <asp:BoundField DataField="STATUS_CURRENT" HeaderText="STATUS_CURRENT" SortExpression="STATUS_CURRENT" />--%>
                              <asp:TemplateField HeaderText="STATUS">
                                        <ItemTemplate>
                                            <%# GetCommonColumn.ConvertOrderStatus(Eval("STATUS_CURRENT"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                    
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <RowStyle CssClass="RowStyle" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="pnlDetail" Visible="False" runat="server">
                                <fieldset class="fiedbackgroundCheckOut" style="width: 500px;margin-left: auto;margin-right: auto">
		<legend>Check Out</legend>
                                <table class="style1">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="style2">
                                            ORDE_ID
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lbl_ORDE_ID" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="style2">
                                            STK_ID
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lbl_STK_ID" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="style2">
                                            เลขใบสั่งซื้อ
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lbl_OR_ID" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="style2">
                                            PRODUCT NAME
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lbl_prname" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="style2">
                                            CODE
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lbl_code" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="style2">
                                            ITEMS
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lbl_ITEMS" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="style2">
                                            ตำแหน่งจัดเก็บ
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblLocation" runat="server" CssClass="BigText"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td class="style2">
                                                       Room</td>
                                                    <td style="text-align: left">
                                                      
                                                            <asp:Label ID="lblRoom" runat="server" CssClass="BigText"></asp:Label>
                                                      </td>
                                                    <td>
                                                        &nbsp;</td>
                                    </tr>
                                    
                                                <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td class="style2">
                                            Check out</td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txt_CheckOut" CssClass="ControlDatePicker" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="style2">
                                            Opening Time
                                        </td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txt_OPENING_TIME" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="style2">
                                            Closing Time
                                        </td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txt_CLOSING_TIME" AutoCompleteType="None" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="style2">
                                            Temp. Before
                                        </td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txt_TEMP_BEFORE" AutoCompleteType="None" runat="server" CssClass="Force2Digit"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;  
                                        </td>
                                        <td class="style2">
                                            Temp. After
                                        </td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txt_TEMP_AFTER" runat="server" CssClass="Force2Digit"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                         
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td style="text-align: right; font-weight: 700;">
                                            Code
                                        </td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txtBarCode" runat="server" AutoPostBack="True" OnTextChanged="txtBarCode_TextChanged"
                                                Width="275px"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td style="text-align: right; font-weight: 700;">
                                            &nbsp;
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td colspan="2" style="text-align: center">
                                            &nbsp;
                                            <asp:Button ID="btnClose" runat="server" onclick="btnClose_Click" 
                                                Text="Close" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
	 
	</fieldset>
                                

                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
