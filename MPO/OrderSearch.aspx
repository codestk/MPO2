<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="OrderSearch.aspx.cs" Inherits="MPO.OrderSearch" %>

<%@ Import Namespace="MPO.Code.Bu.ColumnGrid" %>
<%@ Import Namespace="Stk.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/CalendarSet.js" type="text/javascript"></script>
    <script>


        //For Validate Type
        function ForceNumberTextBox() {


            $(".ForceNumber").ForceNumericOnly();


            $(".Force2Digit").ForceNumericOnly2Digit();

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset style="margin-left: auto; margin-right: auto; width: 800px;">
        <legend>รายการสั่งซื้อ</legend>
        <table>
            <tr>
                <td>
                    รหัสใบสั่งซื้อ
                </td>
                <td>
                    <asp:TextBox ID="txt_OR_ID" runat="server" CssClass="ForceNumber" />
                </td>
                <td>
                    ลูกค้า
                </td>
                <td>
                    <asp:DropDownList ID="drpCustomer" CssClass="chosen-select"  runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    โดย User
                </td>
                <td>
                    <asp:TextBox ID="txt_BYUSER" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    วันทำรายการ
                </td>
                <td>
                    <asp:TextBox ID="txt_ORDER_DATE" CssClass="ControlDatePicker" Width="100px" runat="server" />
                </td>
                <td>
                    สถานะ
                </td>
                <td>
                    <asp:DropDownList ID="drpStatus" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
                    <input id="Button2" type="button" onclick="ClearData();" value="Reset" />
                </td>
                <td>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </fieldset>
    <asp:GridView ID="gvCustomers" runat="server" CssClass="mGrid" AutoGenerateColumns="False"
        AllowPaging="True" Width="100%" OnPageIndexChanged="gvCustomers_PageIndexChanged"
        DataKeyNames="OR_ID" OnPageIndexChanging="gvCustomers_PageIndexChanging" OnSorted="gvCustomers_Sorted"
        OnRowDataBound="GvCustomers_RowDataBound" OnSorting="gvCustomers_Sorting" AllowSorting="True"
        PageSize="20" OnSelectedIndexChanged="gvCustomers_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" SelectText="เลือก" />
            
             <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# SetEditLink(Eval("OR_ID"), Eval("STATUS"))%>
                </ItemTemplate>
            </asp:TemplateField>
            

            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a id="btnShowPopup0"  target="_blank" href="OrderDetail.aspx?Q=<%# Stk_QueryString.EncryptQuery( (Eval("OR_ID"))) %>&amp;Mode=Add&amp;TB_iframe=true&amp;height=550&amp;width=600"
                        title="">
                        <img src="images/print.gif" />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="OR_ID" HeaderText="รหัส" SortExpression="OR_ID" />
            <%--<asp:BoundField DataField="CUS_ID" HeaderText="CUS_ID" SortExpression="CUS_ID" />--%>
            <asp:TemplateField HeaderText="ลูกค้า">
                <ItemTemplate>
                    <%# GetCustomerName(Eval("CUS_ID"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="BYUSER" HeaderText="ผู้ทำรายการ" SortExpression="BYUSER" />
            <asp:BoundField DataField="ORDER_DATE" HeaderText="วันทำรายการ" SortExpression="ORDER_DATE"
                DataFormatString="{0:dd/MM/yyyy}" />
            <asp:TemplateField HeaderText="สถานะ">
                <ItemTemplate>
                    <%# GetCommonColumn.ConvertOrderStatus(Eval("STATUS"))%>
                </ItemTemplate>
            </asp:TemplateField>
      
        </Columns>
        <SelectedRowStyle CssClass="SelectedRowStyle" />
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <RowStyle CssClass="RowStyle" />
    </asp:GridView>
    
    <asp:Panel ID="pnlDetail" runat="server">
        <table style="width: 100%;margin-left: auto;margin-right: auto;">
            <tr><td>
                    
    <asp:GridView ID="gvOrderDetail" runat="server" AutoGenerateColumns="False" DataKeyNames="ORDE_ID"
        EnableViewState="False" CssClass="mGrid" GridLines="None" Width="100%" OnRowDataBound="gvOrderDetail_RowDataBound">
        <Columns>
            <asp:BoundField DataField="ORDE_ID" HeaderText="ORDE_ID" SortExpression="ORDE_ID" />
            <asp:BoundField DataField="OR_ID" HeaderText="OR_ID" SortExpression="OR_ID" />
            <asp:BoundField DataField="PR_LOT" HeaderText="PR_LOT" SortExpression="PR_LOT" />
            <asp:TemplateField HeaderText="Product">
                <ItemTemplate>
                    <%# GetCommonColumn.GetProductName(Eval("PR_LOT"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ITEMS" HeaderText="ITEMS" SortExpression="ITEMS" />
            <asp:BoundField DataField="COST" HeaderText="COST" SortExpression="COST" />
            <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" SortExpression="TOTAL" />
            <asp:BoundField DataField="LOADINGDATE" HeaderText="LOADINGDATE" SortExpression="LOADINGDATE"
                DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="SHIPMENTNO" HeaderText="SHIPMENTNO" SortExpression="SHIPMENTNO" />
            <asp:BoundField DataField="CONTAINERNO" HeaderText="CONTAINERNO" SortExpression="CONTAINERNO" />
            <asp:BoundField DataField="TRUCKNO" HeaderText="TRUCKNO" SortExpression="TRUCKNO" />
            <asp:BoundField DataField="STAMP" HeaderText="STAMP" SortExpression="STAMP" />
            <%--     <asp:BoundField DataField="STATUS_CURRENT" HeaderText="STATUS_CURRENT" SortExpression="STATUS_CURRENT" />--%>
               <asp:BoundField DataField="CHECK_OUT" HeaderText="CHECK_OUT" SortExpression="CHECK_OUT" DataFormatString="{0:dd/MM/yyyy}" />
                  <asp:BoundField DataField="CHECKOUT_BY" HeaderText="CHECKOUT_BY" SortExpression="CHECKOUT_BY" />
       
            <asp:TemplateField HeaderText="STATUS">
                <ItemTemplate>
                    <%# GetCommonColumn.ConvertOrderStatus(Eval("STATUS_CURRENT"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <tr>
                        <td colspan="5">
                        </td>
                        <td colspan="6" style="text-align: right">
                            <asp:GridView ID="GvExportsDetail" runat="server" BackColor="White" BorderColor="#CCCCCC"
                                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="100%" style="background-color: ##e6e6fa">
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


                </td></tr>
            <tr><td style="margin-left: auto;margin-right: auto">
                <asp:Button ID="btnClose" runat="server" Text="Close" Visible="False"
                    onclick="btnClose_Click" />
                </td></tr>
        </table>
    
    
    </asp:Panel>
</asp:Content>
