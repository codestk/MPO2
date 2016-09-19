<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductDetail.ascx.cs" Inherits="MPO.ProductDetail" %>
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
                        <td  class="style1">
                            Lot</td>
                        <td class="style2">
                            <asp:Label ID="lblLotNo" Visible="False" CssClass="biglbl" runat="server"></asp:Label> 
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                           
                        </td>
                        <td  class="style1">
                            Refer</td>
                        <td class="style2">
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
                        <td class="style1">
                            กำหนดวันที่ผลิต
                        </td>
                        <td class="style3">
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
                        <td class="style1">
                            เลือกแหล่งปลา
                        </td>
                        <td class="style3">
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
                        <td class="style1">
                            เลือกรหัสปลา
                        </td>
                        <td class="style2">
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
                        <td class="style1">
                            เลือกขนาดปลา
                        </td>
                        <td class="style2">
                            <asp:Label ID="lbl_PR_SIZE"    runat="server">
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
                        <td class="style1">
                            วันที่ตัดหัวปลา
                        </td>
                        <td class="style2"> 
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
                        <td class="style1">
                            จำนวนวันค้างดอง</td>
                        <td class="style2"> 
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
                        <td class="style1">
                            กำหนดชนิดกล่อง
                        </td>
                        <td class="style2">
                            <asp:Label ID="lbl_PR_BOX_TYPE" runat="server"  ></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style1">
                            กำหนดสีสายลัด</td>
                        <td class="style2">
                            <asp:Label ID="lbl_PR_LINE_COLOR" runat="server"  ></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
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
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    </table>