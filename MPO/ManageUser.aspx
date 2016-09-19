<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="MPO.ManageUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
    
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" language="javascript">


        function updated() {
            //  close the popup
            tb_remove();

            //  refresh the update panel so we can view the changes  
            $('#<%= this.BtnSearch.ClientID %>').click();
        }

        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                //  reapply the thick box stuff
                tb_init('a.thickbox');

            }
        }
        
    </script>
  
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional" ViewStateMode="Enabled">
        <ContentTemplate>
           
              <fieldset style="margin-left: auto; margin-right: auto; width: 800px;">
        <legend>User</legend>
                    <table width="100%">
                        <tr>
                            <td>
                               <label >
                                    UserName</label>
                            </td>
                            <td>
                               
                                <asp:TextBox ID="txtEM_ID"  runat="server" CssClass="form-control "></asp:TextBox>
                            </td>
                            <td>
                                 <label >
                                    ชื่อ</label>

                            </td>
                            <td>
                               
                                <asp:TextBox ID="txtEM_NAME"    runat="server" CssClass="form-control "></asp:TextBox>
                            </td>
                            
                            <td>  <label >
                                    นามกสกุล</label>  </td>
                            <td>
                              
                                <asp:TextBox ID="txtEM_SURNAME"    runat="server" CssClass="form-control "></asp:TextBox>
                              
                            </td>
                            
                        </tr>
                        <tr>
                            <td></td>
                            <td>  <asp:Button ID="BtnSearch" runat="server"   CssClass="btn btn-primary   CustomButton  "  OnClick="BtnSearch_Click"
                                    Text="ค้นหา" />
                                       <input id="Button2" type="button" onclick="ClearData();" value="Reset" />
                                    </td>
                        </tr>
                    </table>
             </fieldse>   
            
            <div class="extrapad" >
                <a id="btnShowPopup0" class="thickbox" href="ManageUserE.aspx?Mode=Add&amp;TB_iframe=true&amp;height=500&amp;width=400"
                    title="เพิ่มข้อมูล">
                    <img alt="แก้ไข" style="border: 0px" src="images/imgR2/add_user.png" />เพิ่มผู้ใช้งาน
                </a>
                <asp:Button ID="btnRefreshCustomers" runat="server" OnClick="Refresh_Click" Style="display: none" />
            </div>
            <div id="table-format">
                <asp:GridView ID="gvCustomers" runat="server" CssClass="mGrid" AllowSorting="True"
                    DataKeyNames="EM_ID" ShowHeaderWhenEmpty="True" OnRowDataBound="GvCustomers_RowDataBound"
                    AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="gvCustomers_PageIndexChanged"
                    OnPageIndexChanging="gvCustomers_PageIndexChanging" OnSorted="gvCustomers_Sorted"
                    OnSorting="gvCustomers_Sorting" Width="100%">
                    <AlternatingRowStyle CssClass="alternatingrowstyle" />
                    <EmptyDataRowStyle BorderWidth="0px" CssClass="rowstyle" />
                    <EmptyDataTemplate>
                        <img alt="ไม่มีรายการนำออกสินค้า" style="border: 0;" src="images/help.png" />ไม่พบข้อมูลอยู่ในระบบ
                    </EmptyDataTemplate>
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="rowstyle" />
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="10" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" Text="ลบ" OnClientClick='<%# String.Format("javascript:return confirm(&#39;คุณต้องการลบ UserName: {0}&#39;);",Eval("EM_ID")) %>'
                                    OnClick="BtnDelete_Click" ToolTip='<%# String.Format("ลบ UserName {0}",Eval("EM_ID")) %>'
                                    BorderWidth="0"><img  
                                alt="ลบคลังสินค้า"  style="border:0;" src="images/delete.png"/></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="10px" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="10" ShowHeader="False">
                            <ItemTemplate>
                                <a id="btnShowPopup" class="thickbox" title='<%# Eval("EM_ID", "แก้ไข UserName {0}") %>'
                                    href='<%# String.Format("ManageUserE.aspx?EM_ID={0}&Mode=Edit&TB_iframe=true&height=500&width=400", Eval("EM_ID")) %>'>
                                    <img alt="แก้ไข" style="border: 0px" src="images/imgR2/edit_user.png" />
                                </a>
                            </ItemTemplate>
                            <ItemStyle Width="10px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="UserName" DataField="EM_ID" SortExpression="EM_ID" HeaderStyle-Width="100">
                            <HeaderStyle Width="100px" />
                           
                        </asp:BoundField>
                        <%--  <asp:BoundField HeaderText="คำนำหน้า" DataField="EM_TITLE" NullDisplayText="-"></asp:BoundField>--%>
                        <asp:BoundField HeaderText="ชื่อ" DataField="EM_NAME" SortExpression="EM_NAME"></asp:BoundField>
                        <asp:BoundField HeaderText="นามกสกุล" DataField="EM_SURNAME" SortExpression="EM_SURNAME"
                            HeaderStyle-Width="100">
                        <HeaderStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ที่อยู่" DataField="EM_ADDRESS" NullDisplayText="-">
                        </asp:BoundField>
                        <asp:BoundField HeaderText="เบอร์ติดต่อ" DataField="EM_TEL" NullDisplayText="-">
                        </asp:BoundField>
                        <asp:BoundField HeaderText="สิทธิ์" DataField="EM_PERMISSION"></asp:BoundField>
                        <asp:BoundField HeaderText="สร้างเมื่อ" DataField="EM_CREATE" DataFormatString="{0:d/MM/yyyy}"
                            ItemStyle-HorizontalAlign="left">
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                      <%--  <asp:BoundField HeaderText="คลังสินค้า" DataField="LC_NAME" NullDisplayText="-">
                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="สถานะ">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# CheckStatus(Eval("EM_FLAG") ) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
