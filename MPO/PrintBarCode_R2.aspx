<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PrintBarCode_R2.aspx.cs" Inherits="MPO.PrintBarCode_R2" %>

<%@ Import Namespace="Stk.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .btn-primary
        {
        }
        .auto-style1
        {
            width: 356px;
        }
        .auto-style3
        {
            width: 180px;
        }
        .auto-style4
        {
            width: 233px;
        }
        .auto-style5
        {
            width: 622px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary" style="margin-left: auto; margin-right: auto;">
        <div class="panel-heading">
        </div>
        <div class="panel-body">
            <table style="margin-left: auto; margin-right: auto; vertical-align: top;">
                <tr>
                    <td style="text-align: center;" class="auto-style5">
                        <asp:Label ID="lbl_LotCode" runat="server" Text="Label" CssClass="labelHeadR2"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;" class="auto-style5">
                        <h2>
                            <asp:Label ID="lbl_name" runat="server" Text="Label" CssClass=""></asp:Label></h2>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5" style="text-align: center">
                        <asp:Panel ID="pnlButton" runat="server">
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center" class="auto-style5">
                        <asp:Image ID="BarcodeImage" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5" style="text-align: center">
                        <div class="panel panel-default">
                            <div class="panel-body ">
                                <asp:Label ID="lbl_Item" runat="server" CssClass="BigText" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5" style="text-align: center">
                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" OnClick="Button2_Click"
                            Text="พิมพ์ BarCode" Width="150px" />
                        <%--   
                              <asp:Button ID="btnprint" runat="server" CssClass="btn btn-primary" OnClick="Button2_Click"
                            Text="พิมพ์รายงานตรวจสอบคุณภาพ" Width="150px" />--%>
                        <a id="A1" target="_blank" title='พิมพ์ Quality Report' href='<%= String.Format("QualityReportR2.aspx?Q={0}&Mode=Edit&TB_iframe=true&height=540&width=600",Stk_QueryString.EncryptQuery(stk_id)) %>'>
                            <input name="Pop" value="พิมพ์ Quality Report" class="btn btn-primary" style="width: 150px;
                                text-align: center" />
                        </a>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <fieldset style="width: 100%; margin-left: auto; margin-right: auto">
                            <legend>Details</legend>
                            <table>
                                <tr valign="top">
                                    <td class="auto-style1">
                                        <table id="Tablemain" class="table table-striped">
                                            <tr>
                                                <td colspan="2" style="text-align: center; background: #ddd;">
                                                    <strong>Production</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>REF </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_REF" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>No. </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_PR_LOT" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>แหล่งปลา </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_PR_SOURCE" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>รหัสปลา </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_FISH_ID" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>ขนาดปลา </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_PR_SIZE" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>ความสดของปลา </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_PR_FRESHNESS" runat="server">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>วันที่ผลิต </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_PR_PRODUCE_DATE" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>วันที่รับปลาตัว </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_PR_REV_DATE" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>วันที่ตัดหัวปลา </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_PR_CUT_DATE" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>จำนวนวันค้างดอง</b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Dong_DATE" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>ไลน์ผลิต </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_PR_LINE" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>เงื่อนไขผลิต </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_PR_CONDITION" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>น้ำหนักผลิตได้ </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_PR_WEIGHT" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>วันที่บรรจุ </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_PR_PACK_DATE" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>ชนิดกล่อง </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_PR_BOX_TYPE" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>สีสายลัด </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_PR_LINE_COLOR" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>จำนวนกล่อง </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_PR_UNIT" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>สถานที่ </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_LOCATION" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>ห้อง </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_ROOM" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>สถานะ </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_PR_STATUS" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>สร้างโดย </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_CREATE_BY" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>นำเข้าโดย </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_CHECKIN_BY" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>QC โดย </b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_QC_BY" runat="server" />
                                                </td>
                                            </tr>
                                            <%--         <tr>
                                <td style="text-align: left" class="auto-style3">
                                    <b>L_UPDATE
                                </b>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_L_UPDATE" runat="server" />
                                </td>
                            </tr>--%>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    .....
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    
                                    <td>
                                        <table id="Table1" class="table table-striped">
                                            <tr>
                                                <td colspan="2" style="text-align: center; background: #ddd;">
                                                    <strong>Quality Report</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>MOISTURE </b>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Label ID="lbl_MOISTURE" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>PH </b>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Label ID="lbl_PH" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>JELLY_ST </b>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Label ID="lbl_JELLY_ST" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>COLOR </b>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Label ID="lbl_COLOR" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>ODOUR </b>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Label ID="lbl_ODOUR" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>SPOT </b>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Label ID="lbl_SPOT" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>GRADE </b>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Label ID="lbl_GRADE" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>STOCK </b>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Label ID="lbl_STOCK" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>DARN </b>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Label ID="lbl_DARN" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>KUBOMI </b>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Label ID="lbl_KUBOMI" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" style="text-align: left" class="auto-style3">
                                                    <b>REMARK </b>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Label ID="lbl_REMARK" runat="server" Height="200px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    ....
                                                </td>
                                            </tr>
                                        </table>
                                            <table id="Table2" class="table table-striped">
                                            <tr>
                                                <td colspan="2" style="text-align: center; background: #ddd;">
                                                    <strong>Product Detail</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>ปริมาณน้ำตาล</b>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Label ID="lbl_PR_SUGAR" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>ปริมาณเกลือ </b>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Label ID="lbl_PR_SALT" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>ปริมาณซอลบิทอล	 </b>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Label ID="lbl_PR_SORBITOL" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="auto-style3">
                                                    <b>ปริมาณโพลีฟอสเฟส	 </b>
                                                </td>
                                                <td class="auto-style4">
                                                    <asp:Label ID="lbl_PR_POLY_PHOSHATE" runat="server" />
                                                </td>
                                            </tr>
                                        
                                     
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    ....
                                                </td>
                                            </tr>
                                        </table>
                                    </td>

                                </tr>

                            </table>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center" class="auto-style5">
                        <asp:Button ID="Button7" runat="server" CssClass="btn btn-default" OnClick="Button7_Click"
                            Text="กลับ" />
                        <div style="display: none">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
