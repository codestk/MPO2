<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ITEM_OVER_VIEW.aspx.cs" Inherits="MPO.ITEM_OVER_VIEW" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
       <fieldset style="margin-left: auto; margin-right: auto; width: 600px;">
            <legend>ค้นหาสินค้า</legend>
            <table>
            
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align: left" class="auto-style3">
                        แหล่งปลา
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="drpSource" CssClass="chosen-select" runat="server" Width="160px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: left">
                        Color
                    </td>
                    <td>
                        <asp:DropDownList ID="drpCOLOR" runat="server" CssClass="chosen-select" Width="160px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align: left" class="auto-style3">
                        รหัสปลา
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="drpFishID" runat="server" CssClass="chosen-select" Width="160px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: left">
                        Moisture
                    </td>
                    <td>
                        <asp:DropDownList ID="drpMoisture" runat="server" CssClass="chosen-select" Width="160px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align: left" class="auto-style3">
                        ชนิดกล่อง
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="drpPR_BOX_TYPE" runat="server" CssClass="chosen-select" Width="160px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: left">
                        Darn
                    </td>
                    <td>
                        <asp:DropDownList ID="drpDarn" runat="server" CssClass="chosen-select" Width="160px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align: left" class="auto-style3">
                        วันที่บรรจุ
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtPR_PACK_DATE" CssClass="ControlDatePicker" Width="100" runat="server"></asp:TextBox>
                    </td>
                    <td style="text-align: left">
                        Odour
                    </td>
                    <td>
                        <asp:DropDownList ID="drpOdour" runat="server" CssClass="chosen-select" Width="160px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align: left" class="auto-style3">
                        ขนาดปลา
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="drpFishSize" runat="server" CssClass="chosen-select" Width="160px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: left">
                        PH
                    </td>
                    <td>
                        <asp:DropDownList ID="drpPH" runat="server" CssClass="chosen-select" Width="160px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align: left" class="auto-style3">
                        สีสายรัด
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="DropPR_LINE_COLOR" runat="server" CssClass="chosen-select"
                            Width="160px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: left">
                        Spot
                    </td>
                    <td>
                        <asp:DropDownList ID="drpSpot" runat="server" CssClass="chosen-select" Width="160px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align: left" class="auto-style3">
                        เงื่อนไข
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="drpPR_CONDITION" runat="server" CssClass="chosen-select" Width="160px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: left">
                        Kubomi
                    </td>
                    <td>
                        <asp:DropDownList ID="drpKubomi" runat="server" CssClass="chosen-select" Width="160px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align: right" class="auto-style3">
                        &nbsp;
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                        <div style="display: none">
                            <input id="Button3" onclick="ClearData();" type="button" value="Reset" /></div>
                    </td>
                    <td style="text-align: left">
                        Jelly St
                    </td>
                    <td>
                        <asp:DropDownList ID="drpJellySt" runat="server" CssClass="chosen-select" Width="160px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align: right" class="auto-style3">
                        &nbsp;
                    </td>
                    <td class="auto-style2">
                        &nbsp;
                    </td>
                    <td style="text-align: right">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </fieldset>


</asp:Content>
