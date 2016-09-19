<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductionConfirm.aspx.cs" Inherits="MPO.ProductionConfirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
      <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: right;
            font-weight: bold;
            padding-left: 5px;
        }
        .style3
        {
            text-align: left;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
      <div style="width: 600px; margin-left: auto;margin-right: auto">
          <fieldset class="fiedbackgroundProduct"  >
		<legend>Production</legend>
		 
       <table class="style1">
       
            
              
          
        
        <tr>
            <td colspan="2" style="text-align: center">
                <table class="style1">
                        <tr>
                        <td>
                           
                        </td>
                        <td  class="style2">
                            No.</td>
                        <td class="style3">
                            <asp:Label ID="lblLotNo" Visible="False" CssClass="biglbl" runat="server"></asp:Label> 
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                           
                        </td>
                        <td  class="style2">
                            Refer</td>
                        <td class="style3">
                            <asp:Label ID="lbl_REF" runat="server" >
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
                        <td class="style2">
                            กำหนดวันที่ผลิต
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lbl_PR_PRODUCE_DATE"  runat="server"
                                Width="100"></asp:Label> 
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
                            เลือกแหล่งปลา
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lbl_PR_SOURCE"   runat="server">
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
                        <td class="style2">
                            เลือกรหัสปลา
                        </td>
                        <td class="style3">
                            <asp:Label ID="lbl_FISH_ID"   runat="server">
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
                        <td class="style2">
                            เลือกขนาดปลา
                        </td>
                        <td class="style3">
                            <asp:Label ID="lbl_PR_SIZE"    runat="server">
                            </asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    
                       <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            ความสดของปลา
                        </td>
                        <td class="style3">
                            <asp:Label ID="lbl_PR_FRESHNESS" runat="server" >
                            </asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    

                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td class="style2">
                            วันที่รับปลาตัว
                        </td>
                        <td class="style3">
                            <asp:Label ID="lbl_PR_REV_DATE"    Width="100" runat="server"
                              ></asp:Label>
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
                            วันที่ตัดหัวปลา
                        </td>
                        <td class="style3"> 
                            <asp:Label ID="lbl_PR_CUT_DATE" runat="server"
                                Width="100"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            จำนวนวันค้างดอง</td>
                        <td class="style3"> 
                             <asp:Label ID="lbl_Dong_DATE" runat="server"
                                Width="100"></asp:Label>
                            </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td class="style2">
                            เลือกไลน์ผลิต
                        </td>
                        <td class="style3">
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
                        <td class="style2">
                            เงื่อนไขผลิต
                        </td>
                        <td class="style3">
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
                        <td class="style2">
                            น้ำหนักผลิตได้
                        </td>
                        <td class="style3">
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
                        <td class="style2">
                            กำหนดวันที่บรรจุ
                        </td>
                        <td class="style3">                                       
                            <asp:Label ID="lbl_PR_PACK_DATE" runat="server" Width="100px"
                                ></asp:Label>
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
                            กำหนดชนิดกล่อง
                        </td>
                        <td class="style3">
                            <asp:Label ID="lbl_PR_BOX_TYPE" runat="server"  ></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            กำหนดสีสายลัด</td>
                        <td class="style3">
                            <asp:Label ID="lbl_PR_LINE_COLOR" runat="server"  ></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
       
                  
                       <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            ปริมาณน้ำตาล
                        </td>
                        <td class="style3">
                            <asp:Label ID="lbl_PR_SUGAR" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            ปริมาณเกลือ
                        </td>
                        <td class="style3">
                            <asp:Label ID="lbl_PR_SALT" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            ปริมาณซอลบิทอล
                        </td>
                        <td class="style3">
                            <asp:Label ID="lbl_PR_SORBITOL" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            ปริมาณโพลีฟอสเฟส
                        </td>
                        <td class="style3">
                            <asp:Label ID="lbl_PR_POLY_PHOSHATE" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td class="style2">
                            กำหนดจำนวนกล่อง
                        </td>
                        <td class="style3">
                            <asp:Label ID="lbl_PR_UNIT" runat="server"></asp:Label>
                            <asp:Label ID="lblnumItem" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            หมายเหตุ</td>
                        <td class="style3">
                            <asp:Label ID="lbl_REMARK" runat="server" Height="79px" TextMode="MultiLine" 
                                Width="248px"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align=center colspan="4">
                            <asp:Button ID="Confirm" runat="server"  Text="Confirm" 
                                Width="88px" onclick="Confirm_Click" />&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server"  Text="Cancel" 
                                Width="88px" onclick="btnCancel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td class="style2">
                            &nbsp;
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                            &nbsp;
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
    
    
    

</asp:Content>
