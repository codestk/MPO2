<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Locations.aspx.cs" Inherits="MPO.Locations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" language="javascript">


        function updated() {
            //close the popup
            tb_remove();

            //  refresh the update panel so we can view the changes  
            $('#<%= this.btnRefreshCustomers.ClientID %>').click();
        }

        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                //  reapply the thick box stuff
                tb_init('a.thickbox');

            }
        }
        
    </script>
    <fieldset style="width: 800px; margin-left: auto; margin-right: auto;">
        <legend>Location</legend>
        <table width="100%">
            <tr>
                <td>
                    <label class="LabelSearch">
                        รหัสคลังสินค้า</label>
                </td>
                <td>
                    <asp:TextBox ID="txtLOCATION_ID" runat="server" CssClass="form-control "></asp:TextBox>
                </td>
                <td>
                    <label class="LabelSearch">
                        ชื่อคลังสินค้า</label>
                </td>
                <td>
                    <asp:TextBox ID="txtLC_NAME" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <label class="LabelSearch">
                        ที่อยู่</label>
                </td>
                <td>
                    <asp:TextBox ID="txtLC_ADDRESS" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td style="vertical-align: middle">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="BtnSearch" runat="server" OnClick="BtnSearch_Click" Text="ค้นหา"
                        CssClass="btn btn-primary   CustomButton  " />
                  <input id="Button2" type="button" onclick="ClearData();" value="Reset" />
                </td>
            </tr>
        </table>
        <div class="extrapad">
            <a id="btnShowPopup0" class="thickbox" href="LocationE.aspx?Mode=Add&TB_iframe=true&height=400&width=380"
                title="เพิ่มข้อมูล">
                <img alt="แก้ไข" style="border: 0px" src="images/imgR2/add_user.png" />เพิ่มคลังสินค้า</a>
            <asp:Button ID="btnRefreshCustomers" runat="server" OnClick="Refresh_Click" Style="display: none" />
        </div>
        <div id="table-format">
            <asp:GridView ID="gvCustomers" runat="server" CssClass="mGrid" AllowSorting="True"
                DataKeyNames="LOCATION_ID" ShowHeaderWhenEmpty="True" OnRowDataBound="GvCustomers_RowDataBound"
                AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="gvCustomers_PageIndexChanged"
                OnPageIndexChanging="gvCustomers_PageIndexChanging" OnSorted="gvCustomers_Sorted"
                OnSorting="gvCustomers_Sorting" Width="100%">
                <AlternatingRowStyle CssClass="alternatingrowstyle" />
                <EmptyDataRowStyle BorderWidth="0px" CssClass="rowstyle" />
                <EmptyDataTemplate>
                    <img alt="ลบข้อมูล" style="border: 0;" src="images/help.gif" />
                    ไม่พบข้อมูลอยู่ในระบบ
                </EmptyDataTemplate>
                <PagerStyle CssClass="PagerStyle" />
                <RowStyle CssClass="rowstyle" HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField ItemStyle-Width="10" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDelete" runat="server" Text="ลบ" OnClientClick='<%# String.Format("javascript:return confirm(&#39;คุณต้องการลบ คลังสินค้า {0}&#39;);",Eval("LC_NAME")) %>'
                                OnClick="BtnDelete_Click" ToolTip='<%# String.Format("ลบคลังสินค้า {0}",Eval("LC_NAME")) %>'
                                BorderWidth="0"><img  alt="ลบคลังสินค้า"  style=" border:0;" src="images/delete.png"/></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="10px" />
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="10" ShowHeader="False">
                        <ItemTemplate>
                            <a id="btnShowPopup" class="thickbox" title='<%# Eval("LOCATION_ID", "แก้ไขคลังสินค้า {0}") %>'
                                href='<%# String.Format("LocationE.aspx?LC_CODE={0}&LC_NAME={1}&LC_DEC={2}&LC_ADDRESS={3}&LC_TEL={4}&LC_ACTIVE={5}&Mode=Edit&TB_iframe=true&height=400&width=380", Eval("LOCATION_ID"), Eval("LC_NAME"),Eval("LC_DEC"),Eval("LC_ADDRESS"),Eval("LC_TEL"),Eval("LC_ACTIVE")) %>'>
                                <img alt="แก้ไข" style="border: 0px" src="images/edit1.png" />
                            </a>
                        </ItemTemplate>
                        <ItemStyle Width="10px" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="รหัสคลังสินค้า" ItemStyle-Width="80" DataField="LOCATION_ID"
                        SortExpression="LOCATION_ID">
                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="ชื่อคลังสินค้า" ItemStyle-Width="180" DataField="LC_NAME"
                        SortExpression="LC_NAME">
                        <ItemStyle Width="180px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="ที่อยู่" DataField="LC_ADDRESS" SortExpression="LC_ADDRESS"
                        ItemStyle-Width="200">
                        <ItemStyle Width="200px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="เบอร์ติดต่อ" DataField="LC_TEL">
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="left" Width="80px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="สถานะ" HeaderStyle-Width="15">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# CheckStatus(Eval("LC_ACTIVE") ) %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="15px"></HeaderStyle>
                    </asp:TemplateField>
                    <%--  <asp:BoundField HeaderText="รายละเอียด" DataField="LC_DEC" ItemStyle-Width="100"  />--%>
                </Columns>
                <SelectedRowStyle CssClass="SelectedRowStyle" />
                <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                <RowStyle CssClass="RowStyle" />
            </asp:GridView>
        </div>
    </fieldset>
</asp:Content>
