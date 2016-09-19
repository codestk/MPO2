<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="MPO._Default" %>

<%@ Import Namespace="MPO.Code.Bu.ColumnGrid" %>
<%@ Import Namespace="Stk.Common" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="gvMyOrder" runat="server" CellPadding="4" AutoGenerateColumns="False"
        CssClass="mGrid" Caption="รายการสั่งซื้อของท่าน" ForeColor="#333333" GridLines="None"
        ShowHeaderWhenEmpty="False">
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <RowStyle CssClass="RowStyle" />
        <Columns>
             <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a id="btnShowPopup0" target="_blank" href="OrderDetail.aspx?Q=<%# Stk_QueryString.EncryptQuery( (Eval("OR_ID"))) %>&amp;Mode=Add&amp;TB_iframe=true&amp;height=550&amp;width=600"
                        title="">
                        <img src="images/print.gif" />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="OR_ID" HeaderText="เลขใบสั่งซื้อ" SortExpression="OR_ID" />
            <asp:BoundField DataField="CUS_ID" HeaderText="รหัสลูกค้า" SortExpression="CUS_ID" />
           
            <asp:TemplateField HeaderText="ชื่อลูกค้า">
                <ItemTemplate>
                    <%# GetCommonColumn.GetCustomerName(Eval("CUS_ID"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField DataField="BYUSER" HeaderText="BYUSER" SortExpression="BYUSER" />--%>
            <asp:BoundField DataField="ORDER_DATE" HeaderText="วันทำรายการสั่งซื้อ" SortExpression="ORDER_DATE"
                DataFormatString="{0:dd/MM/yyyy}" />
            <asp:TemplateField HeaderText="สถานะ">
                <ItemTemplate>
                    <%# GetCommonColumn.ConvertOrderStatus(Eval("STATUS"))%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:GridView ID="MyProduct" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
        Caption="รายการผลิตของท่าน">
        <Columns>
            <%--  <asp:CommandField ShowSelectButton="True" SelectText="เลือก" />--%>
            <%--             <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelete" runat="server" BorderWidth="0" OnClick="BtnDelete_Click"
                                                OnClientClick='<%# String.Format("javascript:return confirm(&#39;คุณต้องการลบรายการสินค้า &#39;);",Eval("PR_LOT")) %>'
                                                Text="ลบ" ToolTip='<%# String.Format("ยกเลิกการนำเข้ารายการ {0}",Eval("PR_LOT")) %>'><img  alt="ลบคลังสินค้า"  
                                style=" border:0;" src="images/delete.png"/></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>--%>
            <asp:BoundField DataField="PR_LOT" HeaderText="Lot" SortExpression="PR_LOT" />
            <asp:BoundField DataField="PR_PRODUCE_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ผลิต"
                SortExpression="PR_PRODUCE_DATE" />
            <asp:BoundField DataField="PR_SOURCE" HeaderText="แหล่งปลา" SortExpression="PR_SOURCE" />
            <asp:BoundField DataField="FISH_ID" HeaderText="รหัสปลา " SortExpression="FISH_ID" />
               <asp:TemplateField HeaderText="ชื่อสินค้า">
                    <ItemTemplate>
                        <%# GetCommonColumn.GetProductName( Eval("PR_LOT"))%>
                    </ItemTemplate>
                </asp:TemplateField>
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
            <asp:BoundField DataField="PR_UNIT" HeaderText="จำนวนกล่อง " SortExpression="PR_UNIT" />
            <asp:BoundField DataField="Ref" HeaderText="Ref" SortExpression="Ref" />
            <asp:TemplateField HeaderText="สถานะ">
                <ItemTemplate>
                    <%# GetCommonColumn.ConvertProductStatus(Eval("PR_STATUS"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%--      <a id="btnShowPopup0" target="_blank" href="PrintBarCode_R2.aspx?Q=<%# Stk_QueryString.EncryptQuery( (Eval("PR_LOT"))) %>&amp;Mode=Add&amp;TB_iframe=true&amp;height=550&amp;width=600"
                        title="">
                        <img src="images/barcode_all.gif" />
                    </a>--%>
                    <%# ShowLinkDetail(Eval("PR_STATUS"), Eval("PR_LOT") )%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <SelectedRowStyle CssClass="SelectedRowStyle" />
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <RowStyle CssClass="RowStyle" />
    </asp:GridView>
    <asp:GridView ID="MyQc" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
        Caption="รายการ QC ของท่าน">
        <Columns>
            <%--  <asp:CommandField ShowSelectButton="True" SelectText="เลือก" />--%>
            <%--             <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelete" runat="server" BorderWidth="0" OnClick="BtnDelete_Click"
                                                OnClientClick='<%# String.Format("javascript:return confirm(&#39;คุณต้องการลบรายการสินค้า &#39;);",Eval("PR_LOT")) %>'
                                                Text="ลบ" ToolTip='<%# String.Format("ยกเลิกการนำเข้ารายการ {0}",Eval("PR_LOT")) %>'><img  alt="ลบคลังสินค้า"  
                                style=" border:0;" src="images/delete.png"/></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>--%>
            <asp:BoundField DataField="PR_LOT" HeaderText="Lot" SortExpression="PR_LOT" />
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
            <asp:BoundField DataField="PR_UNIT" HeaderText="จำนวนกล่อง " SortExpression="PR_UNIT" />
            <asp:BoundField DataField="Ref" HeaderText="Ref" SortExpression="Ref" />
            <asp:TemplateField HeaderText="สถานะ">
                <ItemTemplate>
                    <%# GetCommonColumn.ConvertProductStatus(Eval("PR_STATUS"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%--      <a id="btnShowPopup0" target="_blank" href="PrintBarCode_R2.aspx?Q=<%# Stk_QueryString.EncryptQuery( (Eval("PR_LOT"))) %>&amp;Mode=Add&amp;TB_iframe=true&amp;height=550&amp;width=600"
                        title="">
                        <img src="images/barcode_all.gif" />
                    </a>--%>
                    <%# ShowLinkDetail(Eval("PR_STATUS"), Eval("PR_LOT") )%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <SelectedRowStyle CssClass="SelectedRowStyle" />
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <RowStyle CssClass="RowStyle" />
    </asp:GridView>
</asp:Content>
