<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CustomerSearchR2.aspx.cs" Inherits="MPO.WebCustomer.CustomerSearchR2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/FormDiy.css" rel="stylesheet" type="text/css" />
    <%--  <link href="Styles/bootstrap_R2.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript" src="WebCustomer/Scripts/Stk/Momojojo_Web-1.0.1.0.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            ForceNumberTextBox();
        });

        function updatedBind() {
            //  close the popup
            tb_remove();

            //refresh the update panel so we can view the changes  
            //refresh the update panel so we can view the changes  
            $("#<%= btnSearch.ClientID %>").click();

        }

        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                //  reapply the thick box stuff
                tb_init('a.thickbox');

            }
        }


        //For Validate Type
        function ForceNumberTextBox() {
            $("#<%= txt_CUSTNO.ClientID %>").ForceNumericOnly();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        
           
    <fieldset style="margin-left: auto; margin-right: auto; width: 850px; ">
        <legend>Customer</legend>
                   <table width="100%">
                        <tr>
                            <td>
                             <label for="exampleInputName2">
            รหัส</label>
                            </td>
                            <td>
                               
                               <asp:TextBox ID="txt_CUSTNO" class="form-control" runat="server"></asp:TextBox>
                            </td>
                            <td>
                              <label for="exampleInputEmail2">
            ชื่อบิรษัท</label>
                            </td>
                            <td>
                               
                               <asp:TextBox ID="txt_COMPANY" class="form-control" runat="server"></asp:TextBox>
                            </td>
                            
                            <td>  <label for="select">
            จังหวัด</label> </td>
                            <td>
                              
                               <asp:DropDownList ID="drpSTATE" CssClass="form-control" runat="server">
        </asp:DropDownList>
                              
                            </td>
                            
                        </tr>
                        <tr>
                            <td></td>
                            <td>  <asp:Button ID="btnSearch" class="btn btn-primary  " runat="server" Text="ค้นหา"
        OnClick="btnSearch_Click" />   <input id="Button2" type="button" onclick="ClearData();" value="Reset" />
                                    </td>
                        </tr>
                    </table>
        

     
       <div class="extrapad">
        <a id="btnShowPopup0" class="thickbox" href="CustomerCreateR2.aspx?Mode=Add&amp;Mode=Add&amp;TB_iframe=true&amp;height=550&amp;width=400"
            title="เพิ่มข้อมูล">
            <img alt="แก้ไข" style="border: 0px" src="images/imgR2/add_user.png" />เพิ่มลูกค้า
        </a>
        <asp:Button ID="btnRefreshCustomers" runat="server" OnClick="Refresh_Click" Style="display: none" />
    </div>
    <asp:GridView ID="gvCustomers" runat="server" CssClass="mGrid" AutoGenerateColumns="False"
        ShowHeaderWhenEmpty="True" AllowPaging="True"
        DataKeyNames="CUSTNO" OnPageIndexChanged="gvCustomers_PageIndexChanged" OnPageIndexChanging="gvCustomers_PageIndexChanging"
        OnSorted="gvCustomers_Sorted" OnRowDataBound="GvCustomers_RowDataBound" OnSorting="gvCustomers_Sorting"
        AllowSorting="True">
        <EmptyDataRowStyle BorderWidth="0px" CssClass="rowstyle" />
        <EmptyDataTemplate>
            <img alt="ไม่พบข้อมูล" style="border: 0;" src="images/help.png" />ไม่พบข้อมูล
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="แก้ไข">
                <ItemTemplate>
                    <a id="btnShowPopup0" class="thickbox" href="CustomerCreateR2.aspx?Q=<%# (Eval("CUSTNO")) %>&amp;Mode=Add&amp;TB_iframe=true&amp;height=550&amp;width=400"
                        title="เพิ่มข้อมูล">
                        <img src="images/edit1.png" />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="รหัสลูกค้า">
                <ItemTemplate>
                    <%# (Eval("CUSTNO")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ชื่อบริษัท">
                <ItemTemplate>
                    <%# (Eval("COMPANY")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ADDR1" HeaderText="ที่อยู่1" />
            <asp:BoundField DataField="ADDR2" HeaderText="ที่อยู่2"  />
            <asp:TemplateField HeaderText="เขต">
                <ItemTemplate>
                    <%# (Eval("CITY")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="จังหวัด">
                <ItemTemplate>
                    <%# (Eval("STATE")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ผู้ติต่อ">
                <ItemTemplate>
                    <%# (Eval("CONTACT")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="เบอร์โทร">
                <ItemTemplate>
                    <%#  (Eval("PHONE")) %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle CssClass="pagination-ys" />
    </asp:GridView>
   
    </fieldset>
    
 
    

</asp:Content>
