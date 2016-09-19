<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="StoreCheckIn.aspx.cs" Inherits="MPO.StoreCheckIn" %>

<%@ Import Namespace="MPO.Code.Bu.ColumnGrid" %>
<%@ Import Namespace="Stk.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        
        .style1
        {
            font-weight: bold;
            text-align: right;
        }
        
    </style>
    <script src="Scripts/CalendarSet.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

        });

        //For Validate Type
        function ForceNumberTextBox() {
        }

        function updated() {
            //  close the popup
            tb_remove();

            //  refresh the update panel so we can view the changes  
            $('#<%= this.btnDel.ClientID %>').click();
        }

        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                //  reapply the thick box stuff
                tb_init('a.thickbox');

            }
        }
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td  style="text-align: center">
                <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" CellPadding="4" ForeColor="#333333"
                    GridLines="None" AutoGenerateColumns="False" DataKeyNames="PR_LOT" Width="100%" Caption="รายการนำเข้า"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowHeaderWhenEmpty="True"
                    EmptyDataText="ไม่มีรายการ" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="เลือก" />
                        <%--     <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" BorderWidth="0" OnClick="BtnDelete_Click"
                                    OnClientClick='<%# String.Format("javascript:return confirm(&#39;คุณต้องการลบรายการสินค้า &#39;);",Eval("PR_LOT")) %>'
                                    Text="ลบ" ToolTip='<%# String.Format("ยกเลิกการนำเข้ารายการ {0}",Eval("PR_LOT")) %>'><img  alt="ลบคลังสินค้า"  
                                style=" border:0;" src="images/delete.png"/></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="PR_LOT" HeaderText="No" SortExpression="PR_LOT" />
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
                        <asp:TemplateField ItemStyle-Width="10" ShowHeader="False">
                            <ItemTemplate>
                                <a id="btnShowPopup" class="thickbox" title='<%# Eval("PR_LOT", "กรุณายืนยันการลบข้อมูล") %>'
                                    href='<%# String.Format("VerifyPassword.aspx?PR_LOT={0}&Mode=Edit&TB_iframe=true&height=150&width=500",Stk_QueryString.EncryptQuery(  Eval("PR_LOT"))) %>'>
                                    <img alt="-" style="border: 0px" src="images/delete.png" />
                                </a>
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Panel ID="pnlDetail" Visible="False" runat="server">
                    <div style="width: 500px; text-align: left; margin-left: auto; margin-right: auto">
                        <fieldset <%--class="fiedbackgroundCheckIn"--%>>
                            <legend>Check In</legend>
                            <table width="100%">
                                <tr>
                                    <td class="style1">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="chosen-rtl">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        No
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_PR_LOT" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td class="chosen-rtl">
                                        <b>REF </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_REF" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="chosen-rtl">
                                        <b>วันที่รับปลาตัว </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_PR_REV_DATE" runat="server" Text="Label"></asp:Label>
                                    </td>
                                
                                    <td class="chosen-rtl">
                                        <b>รหัสปลา </b></td>
                                    <td>
                                        <asp:Label ID="lbl_FISH_ID" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="chosen-rtl">
                                        <b>วันที่ตัดหัวปลา </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_PR_CUT_DATE" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td class="chosen-rtl">
                                        <b>แหล่งปลา </b></td>
                                    <td>
                                        <asp:Label ID="lbl_PR_SOURCE" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="chosen-rtl">
                                         <b> วันค้างดอง </b></td>
                                    <td>
                                        <asp:Label ID="lbl_Dong_DATE" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td class="chosen-rtl">
                                        <b>วันที่ผลิต </b></td>
                                    <td>
                                        <asp:Label ID="lbl_PR_PRODUCE_DATE" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="chosen-rtl">
                                        <b>ไลน์ผลิต </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_PR_LINE" runat="server" Text="Label"></asp:Label>
                                    </td>
                              
                                    <td class="chosen-rtl">
                                        <b>เงื่อนไขผลิต </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_PR_CONDITION" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="chosen-rtl">
                                        <b>น้ำหนักผลิตได้ </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_PR_WEIGHT" runat="server" Text="Label"></asp:Label>
                                    </td>
                               
                                    <td class="chosen-rtl">
                                        <b>วันที่บรรจุ </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_PR_PACK_DATE" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="chosen-rtl">
                                        <b>ชนิดกล่อง </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_PR_BOX_TYPE" runat="server" Text="Label"></asp:Label>
                                    </td>
                               
                                    <td class="chosen-rtl">
                                        <b>สีสายลัด </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_PR_LINE_COLOR" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="chosen-rtl">
                                        <b>จำนวนกล่อง </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_PR_UNIT" runat="server" Text="Label"></asp:Label>
                                    </td>
                               
                                    <td class="chosen-rtl">
                                     
                                        <b>ผู้สร้าง </b>
                                     
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_CREATE_BY" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="chosen-rtl">
                                        <b>ขนาดปลา </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_PR_SIZE" runat="server" Text="Label"></asp:Label>
                                    </td>
                              
                                    <td class="chosen-rtl">
                                     
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="chosen-rtl">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <%--<tr><td>CHECKIN_BY</td> <td><asp:Label ID="lbl_CHECKIN_BY" runat="server"  Text="Label"></asp:Label>  </td></tr>
<tr><td>L_UPDATE</td> <td><asp:Label ID="lbl_L_UPDATE" runat="server"  Text="Label"></asp:Label>  </td></tr>
<tr><td>ROOM_ID</td> <td><asp:Label ID="lbl_ROOM_ID" runat="server"  Text="Label"></asp:Label>  </td></tr>--%>
                            </table>
                            <table class="style1">
                                <tr>
                                    <td style="text-align: center">
                                        <table class="style1">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td class="chosen-rtl">
                                                    No.
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblLot" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td class="chosen-rtl">
                                                    ตำแหน่ง
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:DropDownList ID="drpLocation" runat="server" AutoPostBack="True" 
                                                        CssClass="chosen-select" 
                                                        OnSelectedIndexChanged="drpLocation_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td class="chosen-rtl">
                                                    ห้อง
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:DropDownList ID="drpRoom" runat="server" AutoPostBack="True" 
                                                        CssClass="chosen-select" 
                                                        OnSelectedIndexChanged="drpLocation_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: left">
                                                    &nbsp;
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
                                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" 
                                                        Width="88px" />
                                                    &nbsp;&nbsp;
                                                    <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Close" 
                                                        Width="88px" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td colspan="2">
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </div>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Caption="สินค้าที่อยู่ในตำแหน่งนี้"
                        CaptionAlign="Left" DataKeyNames="PR_LOT" EmptyDataText="ไม่พบข้อมูล" CssClass="mGrid" Width="100%"
                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowHeaderWhenEmpty="True"
                        OnRowDataBound="GridView2_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="PR_LOT" HeaderText="No" SortExpression="PR_LOT" />
                            <%--    <asp:BoundField DataField="PR_PRODUCE_DATE" HeaderText="PR_PRODUCE_DATE" 
                                        SortExpression="PR_PRODUCE_DATE" />
                                    <asp:BoundField DataField="PR_REV_DATE" HeaderText="PR_REV_DATE" 
                                        SortExpression="PR_REV_DATE" />
                                    <asp:BoundField DataField="PR_CUT_DATE" HeaderText="PR_CUT_DATE" 
                                        SortExpression="PR_CUT_DATE" />--%>
                            <asp:BoundField DataField="PR_LINE" HeaderText="ไลน์ผลิต" SortExpression="PR_LINE" />
                            <asp:BoundField DataField="PR_CONDITION" HeaderText="เงื่อนไขผลิต	" SortExpression="PR_CONDITION" />
                            <asp:BoundField DataField="PR_WEIGHT" HeaderText="น้ำหนักผลิตได้" SortExpression="PR_WEIGHT" />
                        <%--    <asp:BoundField DataField="PR_PACK_DATE" HeaderText="วันที่บรรจุ" SortExpression="PR_PACK_DATE" />--%>
                            <asp:BoundField DataField="PR_BOX_TYPE" HeaderText="ชนิดกล่อง" SortExpression="PR_BOX_TYPE" />
                            <asp:BoundField DataField="PR_LINE_COLOR" HeaderText="สีสายลัด" SortExpression="PR_LINE_COLOR" />
                            <%-- <asp:BoundField DataField="PR_UNIT" HeaderText="PR_UNIT" 
                                        SortExpression="PR_UNIT" />--%>
                            <asp:TemplateField HeaderText="จำนวนกล่อง">
                                <ItemTemplate>
                                    <%--  <asp:Label ID=items runat="server"></asp:Label>--%>
                                    <%#  GetItems(Eval("PR_STATUS"), Eval("PR_LOT"), Eval("PR_UNIT"), Eval("ITEMS"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="FISH_ID" HeaderText="รหัสปลา" SortExpression="FISH_ID" />
                            <asp:BoundField DataField="PR_SIZE" HeaderText="ขนาดปลา" SortExpression="PR_SIZE" />
                            <asp:BoundField DataField="PR_SOURCE" HeaderText="แหล่งปลา" SortExpression="PR_SOURCE" />
                            <%--<asp:BoundField DataField="LOCATION" HeaderText="LOCATION" SortExpression="LOCATION" />--%>
                            <%--                                    <asp:BoundField DataField="PR_STATUS" HeaderText="PR_STATUS" 
                                        SortExpression="PR_STATUS" />--%>
                            <asp:TemplateField HeaderText="สถานะ">
                                <ItemTemplate>
                                    <%# GetCommonColumn.ConvertProductStatus(Eval("PR_STATUS"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="BARCODE" HeaderText="BARCODE" SortExpression="BARCODE" />--%>
                            <asp:BoundField DataField="REF" HeaderText="REF" SortExpression="REF" />
                            <asp:BoundField DataField="CREATE_BY" HeaderText="ผู้สร้าง" SortExpression="CREATE_BY" />
                          <%--  <asp:BoundField DataField="CHECKIN_BY" HeaderText="CHECKIN_BY" SortExpression="CHECKIN_BY" />--%>
                      <%--      <asp:BoundField DataField="L_UPDATE" HeaderText="L_UPDATE" SortExpression="L_UPDATE" />--%>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <asp:Panel ID="pnlMessage" Visible="False" runat="server">
                    <h2>
                        <asp:Label ID="Label2" runat="server" Style="font-weight: 700" Text=""></asp:Label>
                    </h2>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <div style="display: none;">
        <asp:Button ID="btnDel" OnClick="BtnDelete_Click" runat="server" Text="" />
    </div>
</asp:Content>
