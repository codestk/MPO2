<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Sales.aspx.cs" Inherits="MPO.Sales" %>

<%@ Import Namespace="MPO.Code.Bu.ColumnGrid" %>
<%@ Register Src="chosen.ascx" TagName="chosen" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script>

        function updatedBind() {
            //  close the popup
            tb_remove();
            //           refresh the update panel so we can view the changes  
            //          $("#< %= btnSearch.ClientID %  >").click();

            $("#<%= Button2.ClientID %>").click();
        }
    </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
            margin: 0 auto;
        }
        .auto-style1
        {
            width: 67px;
        }
        .auto-style2
        {
            width: 300px;
        }
        .auto-style3
        {
            width: 114px;
        }
    </style>
    <script src="Scripts/CalendarSet.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            ForceNumberTextBox();
        });

        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                //  reapply the thick box stuff
                tb_init('a.thickbox');

            }
        }




        function updated() {
            //  close the popup
            tb_remove();

            //  refresh the update panel so we can view the changes  
            $('#<%= this.btnRefreshCustomers.ClientID %>').click();
        }



        //For Validate Type
        function ForceNumberTextBox() {


            $(".ForceNumber").ForceNumericOnly();


            $(".Force2Digit").ForceNumericOnly2Digit();

        }
    </script>
    <uc1:chosen ID="chosen1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnl1" runat="server">
        <fieldset style="margin-left: auto; margin-right: auto; width: 600px;">
            <legend>ระบุลูกค้า</legend>
            <table class="style1">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align: left" class="auto-style3">
                        เลือกลูกค้า
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="drpCustomer" runat="server" AutoPostBack="True" CssClass="chosen-select"
                            OnSelectedIndexChanged="drpCustomer_SelectedIndexChanged" Width="211px">
                        </asp:DropDownList>
                        <a id="A1" class="thickbox" href="CustomerCreateR2.aspx?Mode=Add&amp;Mode=Add&amp;TB_iframe=true&amp;height=550&amp;width=300"
                            title="เพิ่มข้อมูล">
                            <img alt="แก้ไข" src="images/imgR2/add_user.png" />
                        </a>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align: right" class="auto-style3">
                        &nbsp;
                    </td>
                    <td style="text-align: left">
                        <ul>
                            <li>
                                <asp:Label ID="lbl_CUSTNO" runat="server" CssClass=" control-label" Text=""></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="lbl_ADDR1" runat="server" CssClass=" control-label" Text=""></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="lbl_ADDR2" runat="server" CssClass=" control-label" Text=""></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="lbl_STATE" runat="server" CssClass="control-label" Text=""></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="lbl_ZIP" runat="server" CssClass="control-label" Text=""></asp:Label>
                            </li>
                            <li>
                                <div>
                                    <a id="A1" class="thickbox" href="CustomerCreateR2.aspx?Mode=Add&amp;Mode=Add&amp;TB_iframe=true&amp;height=550&amp;width=300"
                                        title="เพิ่มข้อมูล">&nbsp;</a><div style="display: none">
                                            <asp:Button ID="btnRefreshCustomers" runat="server" OnClick="Refresh_Click" Style="display: block" />
                                        </div>
                                </div>
                            </li>
                        </ul>
                    </td>
                    <td>
                        &nbsp;
                        <div style="display: none">
                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align: left" class="auto-style3">
                        กำหนดวัน
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtOrderDate" CssClass="ControlDatePicker" Width="100" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="auto-style3" style="text-align: left">
                        ผู้ขาย
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="drpSeller" runat="server" CssClass="chosen-select" Width="211px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </fieldset>
        <a id="btnShowPopup" class="thickbox" title='' href='AddProduct.aspx?EM_ID=9&Mode=Edit&TB_iframe=true&height=500&width=1100'>
            <img alt="แก้ไข" style="border: 0px" src="images/imgR2/edit_user.png" />
            เลือกสินค้า </a>
        <asp:GridView ID="grdSale" runat="server" CellPadding="4" AutoGenerateColumns="False"
            DataKeyNames="PR_LOT" CssClass="mGrid" Caption="รายการสั่งซื้อ" ForeColor="#333333"
            OnRowDataBound="grdSale_RowDataBound">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete0" runat="server" BorderWidth="0" OnClick="BtnDelete_Click"
                            OnClientClick='<%# String.Format("javascript:return confirm(&#39;คุณต้องการลบรายการสินค้า &#39;);",Eval("sino")) %>'
                            Text="ลบ" ToolTip='<%# String.Format("ลบรายการสินค้า {0}",Eval("sino")) %>'><img  alt="ลบคลังสินค้า"  
                                style=" border:0;" src="images/delete.png"/></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:BoundField DataField="STK_ID" HeaderText="STK_ID" SortExpression="STK_ID" />
                <asp:BoundField DataField="PR_LOT" HeaderText="No." SortExpression="PR_LOT" />
                <asp:BoundField DataField="ORDE_ID" HeaderText="รหัสย่อย" SortExpression="ORDE_ID" />
                <asp:TemplateField HeaderText="ชื่อสินค้า">
                    <ItemTemplate>
                        <%# GetCommonColumn.GetProductName( Eval("PR_LOT"))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ITEMS">
                    <ItemTemplate>
                        <asp:TextBox ID="txtITEMS" CssClass="ForceNumber" Width="50px" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ใช้ได้">
                    <ItemTemplate>
                        <%#  AvaliableItem(Eval("STK_ID"), Eval("ORDE_ID"))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="COST">
                    <ItemTemplate>
                        <asp:TextBox ID="txtCost" CssClass="Force2Digit" Width="50px" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Loading Date">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLoadingDate" CssClass="ControlDatePicker" Width="100px" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Shipment No.">
                    <ItemTemplate>
                        <asp:TextBox ID="txtShipment" Width="50px" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Container No.">
                    <ItemTemplate>
                        <asp:TextBox ID="txtContainer" Width="50px" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Truck No.">
                    <ItemTemplate>
                        <asp:TextBox ID="txtTruckNo" Width="50px" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stamp">
                    <ItemTemplate>
                        <asp:TextBox ID="txtStamp" Width="50px" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:TextBox ID="txtStatus" Width="50px" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:Panel ID="pnlControl" Visible="False" runat="server">
            <asp:Button ID="UpdateOrder" runat="server" OnClick="UpdateOrder_Click" Text="อัพเดทรายการสั่งซื้อ" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="แก้ไข" />
            <div style="width: 300px; float: right; text-align: right">
                <asp:Button ID="btnSend" runat="server" OnClick="Button1_Click" Text="ส่งใบเบิก"
                    Visible="False" />
            </div>
        </asp:Panel>
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="Panel2" Visible="False" runat="server" Style="text-align: center">
        <asp:Label ID="lblSuccess" runat="server" Text="Label" Font-Bold="True" Font-Size="20pt"></asp:Label>
    </asp:Panel>
    <uc1:chosen ID="chosen2" runat="server" />
</asp:Content>
