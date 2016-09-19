<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="QC.aspx.cs" Inherits="MPO.QC" %>
<%@ Import Namespace="MPO.Code.Bu.ColumnGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            ForceNumberTextBox();
        });


        //For Validate Type
        function ForceNumberTextBox() {

            $("#<%= txtNumber.ClientID %>").ForceNumericOnly2Digit();

            $("#<%= lbl_KUBOMI.ClientID %>").ForceNumericOnly2Digit();

            $("#<%= lbl_JELLY_ST.ClientID %>").ForceNumericOnly2Digit();

            $("#<%= lbl_MOISTURE.ClientID %>").ForceNumericOnly2Digit();

            $("#<%= lbl_PH.ClientID %>").ForceNumericOnly2Digit();

            $("#<%= lbl_DARN.ClientID %>").ForceNumericOnly2Digit();

            $("#<%= lbl_JELLY_ST.ClientID %>").ForceNumericOnly2Digit();

            $("#<%= lbl_SPOT.ClientID %>").ForceNumericOnly2Digit();

            $("#<%= lbl_STOCK.ClientID %>").ForceNumericOnly2Digit();

            $("#<%= lbl_ODOUR.ClientID %>").ForceNumericOnly2Digit();


        }
    </script>
    <script src="Scripts/CalendarSet.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1
        {
        }
        .auto-style2
        {
            width: 343px;
        }
        
        .LockTxt, .LockTxt:hover {
           background-color: #ffffff;
            border-style: dotted;
           
            text-align: center;
            font-weight: bold;
 
          
        }
        .gradeStlye, .gradeStlye:hover
        {
            background-color: #ffffff;
            border-style: dotted;
            font-size: 70px;
            text-align: center;
            font-weight: bold;
            height: 100px;
        }
        
        
        .NonEdit , .NonEdit:hover {
            
               background-color: #ffffff;
            border-style:  none;
          
          
       
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
        <tr>
            <td>
                <%--   <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Qc"></asp:Label>--%>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:GridView ID="GridView1" runat="server" AlternatingRowStyle="AlternatingRowStyle"
                    RowStyle="RowStyle" AutoGenerateColumns="False" DataKeyNames="PR_LOT" ShowHeaderWhenEmpty="True"
                    Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                    EmptyDataText="ไม่พบข้อมูล" CssClass="mGrid" Caption="Quality Control">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="เลือก" />
                        <asp:BoundField DataField="PR_LOT" HeaderText="No." SortExpression="PR_LOT" />
                        <asp:BoundField DataField="PR_PRODUCE_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="วันที่ผลิต"
                            SortExpression="PR_PRODUCE_DATE" />
                        <asp:BoundField DataField="PR_SOURCE" HeaderText="แหล่งปลา" SortExpression="PR_SOURCE" />
                        <asp:BoundField DataField="FISH_ID" HeaderText="รหัสปลา " SortExpression="FISH_ID" />
                            <asp:TemplateField HeaderText="ชื่อ">
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
                        <asp:BoundField DataField="Ref" HeaderText="Refer " SortExpression="Ref" />
                    </Columns>
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                    <RowStyle CssClass="RowStyle" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlDetail" Visible="False" runat="server">
        <fieldset style="width: 500px; margin-left: auto; margin-right: auto;" class="fiedbackgroundQc">
            <legend>Quality </legend>
            <table>
                <tr>
                    <td>
                        <style type="text/css">
                            .style1
                            {
                                font-weight: bold;
                            }
                            .style2
                            {
                                font-weight: normal;
                            }
                            .style3
                            {
                                text-align: left;
                                font-weight: normal;
                            }
                        </style>
                        <table class="style1">
                            <tr>
                                <td>
                                </td>
                                <td class="style1">
                                    No.
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lblLotNo" CssClass="biglbl" runat="server"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td class="style1">
                                    Refer
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lbl_REF" runat="server">
                                    </asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    กำหนดวันที่ผลิต
                                </td>
                                <td class="style3">
                                    <asp:Label ID="lbl_PR_PRODUCE_DATE" runat="server" Width="100"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    เลือกแหล่งปลา
                                </td>
                                <td class="style3">
                                    <asp:Label ID="lbl_PR_SOURCE" runat="server">
                                    </asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    เลือกรหัสปลา
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lbl_FISH_ID" runat="server">
                                    </asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    เลือกขนาดปลา
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lbl_PR_SIZE" runat="server">
                                    </asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    วันที่รับปลาตัว
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lbl_PR_REV_DATE" Width="100" runat="server"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    วันที่ตัดหัวปลา
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lbl_PR_CUT_DATE" runat="server" Width="100"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    จำนวนวันค้างดอง
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lbl_Dong_DATE" runat="server" Width="100"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    เลือกไลน์ผลิต
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lbl_PR_LINE" runat="server"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    เงื่อนไขผลิต
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lbl_PR_CONDITION" runat="server"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    น้ำหนักผลิตได้
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lbl_PR_WEIGHT" runat="server"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    กำหนดวันที่บรรจุ
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lbl_PR_PACK_DATE" runat="server" Width="100px"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    กำหนดชนิดกล่อง
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lbl_PR_BOX_TYPE" runat="server"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    กำหนดสีสายลัด
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lbl_PR_LINE_COLOR" runat="server"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <%--       <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td class="style2">
                            Auto Lot No
                        </td>
                        <td class="style3">
                            <asp:Label ID="lblLotNo" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>--%>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    กำหนดจำนวนกล่อง
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lbl_PR_UNIT" runat="server"></asp:Label>
                                    <asp:Label ID="lblnumItem" runat="server"></asp:Label>
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
                                    &nbsp;
                                </td>
                                <td class="style3">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <table class="style1">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: left" class="auto-style1">
                                    No.
                                </td>
                                <td style="text-align: left" class="auto-style2">
                                    <asp:Label ID="lblLot" runat="server" Font-Bold="True" Font-Size="12pt" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: left" class="auto-style1">
                                    Moisture
                                </td>
                                <td style="text-align: left" class="auto-style2">
                                    <asp:TextBox ID="lbl_MOISTURE" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: left" class="auto-style1">
                                    PH
                                </td>
                                <td style="text-align: left" class="auto-style2">
                                    <asp:TextBox ID="lbl_PH" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: left" class="auto-style1">
                                    Darn
                                </td>
                                <td style="text-align: left" class="auto-style2">
                                    <asp:TextBox ID="lbl_DARN" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: left" class="auto-style1">
                                    Kubomi (cm)
                                </td>
                                <td style="text-align: left" class="auto-style2">
                                    <asp:TextBox ID="lbl_KUBOMI" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: left" class="auto-style1">
                                    Jelly St.(g*cm)
                                </td>
                                <td style="text-align: left" class="auto-style2">
                                    <asp:TextBox ID="lbl_JELLY_ST" Enabled="False" CssClass="LockTxt" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: left" class="auto-style1">
                                    Color
                                </td>
                                <td style="text-align: left" class="auto-style2">
                                    <asp:TextBox ID="lbl_COLOR" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: left" class="auto-style1">
                                    Odour
                                </td>
                                <td style="text-align: left" class="auto-style2">
                                    <asp:TextBox ID="lbl_ODOUR" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: left" class="auto-style1">
                                    Spot
                                </td>
                                <td style="text-align: left" class="auto-style2">
                                    <asp:TextBox ID="lbl_SPOT" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: left" class="auto-style1">
                                    Grade
                                </td>
                                <td style="text-align: left" class="auto-style2">
                                    <asp:TextBox ID="lbl_GRADE" CssClass="gradeStlye" runat="server" 
                                        Enabled="False" Width="150px">-</asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: left" class="auto-style1">
                                    Stock
                                </td>
                                <td style="text-align: left" class="auto-style2">
                                    <asp:TextBox ID="lbl_STOCK" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: left" class="auto-style1">
                                    Remark
                                </td>
                                <td style="text-align: left" class="auto-style2">
                                    <asp:TextBox ID="lbl_REMARK" runat="server" MaxLength="255" Rows="5" TextMode="MultiLine"
                                        Width="339px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: left" class="auto-style1">
                                    ITEMS
                                </td>
                                <td style="text-align: left" class="auto-style2">
                                    <asp:TextBox ID="txtNumber" runat="server" CssClass="NonEdit" Enabled="False"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="auto-style1" style="text-align: left">
                                    ผู้ตรวจ
                                </td>
                                <td class="auto-style2" style="text-align: left">
                                    <%--    <asp:TextBox ID="txt_Qc" runat="server"  ></asp:TextBox>--%>
                                    <asp:DropDownList ID="txt_Qc" runat="server" CssClass="chosen-select" Width="211px">
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
                                <td class="auto-style1" style="text-align: left">
                                    วันที่ตรวจ
                                </td>
                                <td class="auto-style2" style="text-align: left">
                                    <asp:TextBox ID="txt_QcDate" Width="100" CssClass="ControlDatePicker" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="auto-style1" style="text-align: left">
                                    &nbsp;
                                </td>
                                <td class="auto-style2" style="text-align: left">
                                          <asp:Button ID="btnSave" runat="server" Text="Save" Width="88px" 
                                              onclick="btnSave_Click" />
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Approve" 
                                              Width="88px" Visible="False" />
                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Reject" Width="88px" />
                                    <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click1" Text="Close" Width="88px" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>
    <asp:Panel ID="pnlFinish" Visible="False" runat="server">
        <h2>
            <asp:Label ID="lblMgs" runat="server" Text="บันทึกเรียบร้อย" Style="text-align: center"></asp:Label>
        </h2>
        <p>
            &nbsp;</p>
    </asp:Panel>
</asp:Content>
