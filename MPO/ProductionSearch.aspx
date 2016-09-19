<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductionSearch.aspx.cs" Inherits="MPO.ProductionSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    

   <table>
   <tr><td>PR_LOT  </td><td> <asp:TextBox ID="txt_PR_LOT" runat="server"/> </td>   
 <td>PR_PRODUCE_DATE  </td><td> <asp:TextBox ID="txt_PR_PRODUCE_DATE" runat="server"/> </td> 
 <td>PR_REV_DATE  </td><td> <asp:TextBox ID="txt_PR_REV_DATE" runat="server"/> </td>    

 <td>PR_CUT_DATE  </td><td> <asp:TextBox ID="txt_PR_CUT_DATE" runat="server"/> </td>     </tr> 
<tr> <td>PR_LINE  </td><td> <asp:TextBox ID="txt_PR_LINE" runat="server"/> </td>  
 <td>PR_CONDITION  </td><td> <asp:TextBox ID="txt_PR_CONDITION" runat="server"/> </td> 
 <td>PR_WEIGHT  </td><td> <asp:TextBox ID="txt_PR_WEIGHT" runat="server"/> </td> 
 
 <td>PR_PACK_DATE  </td><td> <asp:TextBox ID="txt_PR_PACK_DATE" runat="server"/> </td>  </tr> 
 <tr><td>PR_BOX_TYPE  </td><td> <asp:TextBox ID="txt_PR_BOX_TYPE" runat="server"/> </td>  
 <td>PR_LINE_COLOR  </td><td> <asp:TextBox ID="txt_PR_LINE_COLOR" runat="server"/> </td>    
 <td>PR_UNIT  </td><td> <asp:TextBox ID="txt_PR_UNIT" runat="server"/> </td>
  <td>FISH_ID  </td><td> <asp:TextBox ID="txt_FISH_ID" runat="server"/> </td> </tr>    
<tr><td>PR_SIZE  </td><td> <asp:TextBox ID="txt_PR_SIZE" runat="server"/> </td>   
 <td>PR_SOURCE  </td><td> <asp:TextBox ID="txt_PR_SOURCE" runat="server"/> </td>     
 <td>LOCATION  </td><td> <asp:TextBox ID="txt_LOCATION" runat="server"/> </td>
 
 <td>PR_STATUS  </td><td> <asp:TextBox ID="txt_PR_STATUS" runat="server"/> </td>    </tr>  
<tr><td>BARCODE  </td><td> <asp:TextBox ID="txt_BARCODE" runat="server"/> </td>   
 <td>REF  </td><td> <asp:TextBox ID="txt_REF" runat="server"/> </td>  
 <td>CREATE_BY  </td><td> <asp:TextBox ID="txt_CREATE_BY" runat="server"/> </td>  
  <td>CHECKIN_BY  </td><td> <asp:TextBox ID="txt_CHECKIN_BY" runat="server"/> </td>   </tr> 
<tr><td>&nbsp;</td><td> 
    <asp:Button ID="Button1" runat="server" Text="ค้นหา" onclick="Button1_Click" />
    </td>   
 <td>&nbsp;</td><td> &nbsp;</td>  
 <td>&nbsp;</td><td> &nbsp;</td>  
  <td>&nbsp;</td><td> &nbsp;</td>   </tr> 
<tr><td colspan="8">
    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
        GridLines="Horizontal" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="PR_LOT" HeaderText="PR_LOT" SortExpression="PR_LOT" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
    </td>   </tr> 
   </table>
    

</asp:Content>
