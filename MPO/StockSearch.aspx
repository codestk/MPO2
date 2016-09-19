<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="StockSearch.aspx.cs" Inherits="MPO.StockSearch" %>

<%@ Import Namespace="MPO.Code.Bu.ColumnGrid" %>
<%@ Import Namespace="Stk.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/CalendarSet.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset style="width: 500px; margin-left: auto; margin-right: auto;">
        <legend>Stock </legend>
        <table>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: right">
                    แหล่งปลา
                </td>
                <td>
                    <asp:DropDownList ID="drpSource" CssClass="chosen-select" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: right">
                    รหัสปลา
                </td>
                <td>
                    <asp:DropDownList ID="drpFishID" CssClass="chosen-select" runat="server" AutoPostBack="True"
                        >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: right">
                    ขนาดปลา
                </td>
                <td>
                    <asp:DropDownList ID="drpFishSize" CssClass="chosen-select" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: right">
                    ตำแหน่ง
                </td>
                <td>
                    <asp:DropDownList ID="drpLocation" CssClass="chosen-select" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: right">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="ค้นหา" />
                    <input id="Button1" type="button" onclick="ClearData();" value="Reset" />
                </td>
            </tr>
        </table>
        <table style="width: 500px;">
            <tr>
                <td>
                     
                </td>
                <td>
                    <asp:RadioButton ID="rdNon" Text="ไม่รวมยอด" GroupName="g1" runat="server" />
                    <asp:RadioButton ID="rdSource" Text="แหล่งปลา"  GroupName="g1" runat="server" />
                    <asp:RadioButton ID="rdFisid" Text="รหัสปลา" GroupName="g1" runat="server" />
                    <asp:RadioButton ID="rdPosition" Text="ตำแหน่ง"  GroupName="g1" runat="server" />
                </td>
                <td>
                </td>
            </tr>
        </table>
    </fieldset>
    <asp:GridView ID="GridView1" AutoGenerateColumns="False" runat="server" DataKeyNames="STK_ID"
        EmptyDataText="ไม่พบสินค้า" CssClass="mGrid" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <%--   <asp:CommandField ShowSelectButton="True" />--%>
            <%--  <asp:BoundField DataField="STK_ID" HeaderText="STK_ID" SortExpression="STK_ID" />
            <asp:BoundField DataField="PR_LOT" HeaderText="Lot" SortExpression="PR_LOT" />--%>
            <%--          <asp:BoundField DataField="PR_PRODUCE_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ผลิต"
                SortExpression="PR_PRODUCE_DATE" />--%>
            <%--<asp:BoundField DataField="PR_REV_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่รับปลาตัว"
                SortExpression="PR_REV_DATE" />
            <asp:BoundField DataField="PR_CUT_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ตัดหัวปลา"
                SortExpression="PR_CUT_DATE" />--%>
            <%--    <asp:BoundField DataField="PR_PACK_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="กำหนดวันที่บรรจุ"
                SortExpression="PR_PACK_DATE" />--%>
            <%--  <asp:BoundField DataField="PR_BOX_TYPE" HeaderText="ชนิดกล่อง" SortExpression="PR_BOX_TYPE" />
            <asp:BoundField DataField="PR_LINE_COLOR" HeaderText="สีสายลัด" SortExpression="PR_LINE_COLOR" />--%>
            <%--    <asp:BoundField DataField="QC_BY" HeaderText="QC BY" SortExpression="QC_BY" />--%>
           
               <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a id="btnShowPopup0" target="_blank" href="PrintBarCode_R2.aspx?Q=<%# Stk_QueryString.EncryptQuery( (Eval("STK_ID"))) %>&amp;Mode=Add&amp;TB_iframe=true&amp;height=550&amp;width=600"
                        title="">
                        <img src="images/details.gif" />
                    </a>
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:BoundField DataField="FISH_ID" HeaderText="รหัสปลา" SortExpression="FISH_ID">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="ชื่อสินค้า">
                <ItemTemplate>
                    <%# GetCommonColumn.GetProductName( Eval("PR_LOT"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="PR_SOURCE" HeaderText="แหล่งปลา" SortExpression="PR_SOURCE" />
            <asp:BoundField DataField="PR_SIZE" HeaderText="ขนาดปลา" SortExpression="PR_SIZE" />
            <%--  <asp:BoundField DataField="PR_LINE" HeaderText="ไลน์ผลิต" SortExpression="PR_LINE" />--%>
            <%--   <asp:BoundField DataField="PR_CONDITION" HeaderText=" เงื่อนไขผลิต " SortExpression="PR_CONDITION" />
            <asp:BoundField DataField="PR_WEIGHT" HeaderText="น้ำหนักผลิตได้" SortExpression="PR_WEIGHT" />--%>
            <asp:BoundField DataField="ITEMS" HeaderText="จำนวน" SortExpression="ITEMS" />
            <asp:BoundField DataField="LOCATION" HeaderText="ตำแหน่ง" SortExpression="LOCATION" />
        </Columns>
        <SelectedRowStyle CssClass="SelectedRowStyle" />
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <RowStyle CssClass="RowStyle" />
    </asp:GridView>
</asp:Content>
