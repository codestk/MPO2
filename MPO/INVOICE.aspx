<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="INVOICE.aspx.cs" Inherits="MPO.OrderDetailR2" %>
<%@ Import Namespace="Stk.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>INVOICE</title>
       <script src="Jquery/js/jquery-1.6.1.min.js" type="text/javascript"></script>
          <script type="text/javascript" src="Scripts/Stk/Momojojo_Web-1.0.1.0.js"></script>
          <script>
            $(document).ready(function () {
            ForceNumberTextBox();
        });

            function ForceNumberTextBox() {


            $("#<%= paid.ClientID %>").ForceNumericOnly2Digit();

         //   $("#< %= txt_PR_UNIT.ClientID %>").ForceNumericOnly();


        }
         </script>
    <link href="Styles/Invoice.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    
    
    
    <div id="page-wrap">

		<textarea id="header">INVOICE</textarea>
		
		<div id="identity">
		    <asp:Label id="address" runat="server">
		        
                

		    </asp:Label>
<%--	   <textarea id="address">Chris Coyier
123 Appleseed Street
Appleville, WI 53719

Phone: (555) 555-5555</textarea> --%>




            <div id="logo">

             <%-- <div id="logoctr">
 a href="javascript:;" id="change-logo" title="Change logo">Change Logo</a>
                <a href="javascript:;" id="save-logo" title="Save changes">Save</a>
                |
                <a href="javascript:;" id="delete-logo" title="Delete logo">Delete Logo</a>
                <a href="javascript:;" id="cancel-logo" title="Cancel changes">Cancel</a> 
              </div>--%>

              <div id="logohelp">
                <input id="imageloc" type="text" size="50" value=""><br>
                (max width: 540px, max height: 100px)
              </div>
              <img   src="images/SURIMI_LOGO.png" alt="logo">
            </div>
		
		</div>
		
		<div style="clear:both"></div>
		
		<div id="customer">
<%--
            <textarea id="customer-title">Widget Corp.
c/o Steve Widget</textarea>--%>

<asp:Label id="customertitle" Width="200px"  CssClass="customer-title" Text="Widget Corp.
c/o Steve Widget" runat="server"></asp:Label>

            <table id="meta">
                <tbody><tr>
                    <td class="meta-head">Invoice #</td>
                    <td><%--<textarea>000123</textarea>--%>
                    
                    <asp:Label ID="Ord_id" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>

                    <td class="meta-head">Date</td>
                    <td>
                      <%--  <textarea id="date">December 15, 2009</textarea>--%>
                       <asp:Label ID="lbl_ORDER_DATE" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="meta-head">Amount Due</td>
                    <td><%--<div class="due">$650.00</div>--%>    <asp:Label ID="headDue" CssClass="due" runat="server"></asp:Label></td>
                </tr>

            </tbody></table>
		
		</div>
		     <asp:GridView ID="items" runat="server" AutoGenerateColumns="False" 
                                DataKeyNames="ORDE_ID" EnableViewState="False"  
                                Width="100%">
                                <Columns>
                                   <%-- <asp:BoundField DataField="ORDE_ID" HeaderText="ORDE_ID" SortExpression="ORDE_ID" />--%>
                                  <%--  <asp:BoundField DataField="OR_ID" HeaderText="OR_ID" SortExpression="OR_ID" />--%>
                                  <%--  <asp:BoundField DataField="PR_LOT" HeaderText="PR_LOT" SortExpression="PR_LOT" />--%>
                                    <asp:TemplateField HeaderText="Item">
                                        <ItemTemplate>
                                            <%# GetProductID(Eval("PR_LOT"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Description" >
                                        <ItemTemplate>
                                            <%# GetProductName(Eval("PR_LOT"))%>
                                        </ItemTemplate>
                                        
                                          <ItemStyle Width="300px" />
                                        
                                    </asp:TemplateField>
                                 
                                    <asp:BoundField DataField="COST" HeaderText="Unit Cost" SortExpression="COST" >
                                       <HeaderStyle CssClass="cost" />
                                    </asp:BoundField>
                                       <asp:BoundField DataField="ITEMS" HeaderText="Quantity" SortExpression="ITEMS" />
                                    <asp:BoundField DataField="TOTAL" HeaderText="Price" SortExpression="TOTAL" />
                                    <%--<asp:BoundField DataField="LOADINGDATE" HeaderText="LOADINGDATE" SortExpression="LOADINGDATE"
                                        DataFormatString="{0:dd/MM/yyyy}" />--%>
                                <%--    <asp:BoundField DataField="SHIPMENTNO" HeaderText="SHIPMENTNO" SortExpression="SHIPMENTNO" />--%>
                                   <%-- <asp:BoundField DataField="CONTAINERNO" HeaderText="CONTAINERNO" SortExpression="CONTAINERNO" />--%>
                                 <%--   <asp:BoundField DataField="TRUCKNO" HeaderText="TRUCKNO" SortExpression="TRUCKNO" />--%>
                                 <%--   <asp:BoundField DataField="STAMP" HeaderText="STAMP" SortExpression="STAMP" />--%>
<%--                                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />--%>
                               <%--     <asp:BoundField DataField="STATUS_CURRENT" HeaderText="STATUS_CURRENT" SortExpression="STATUS_CURRENT" />--%>
                                   
                           <%--         <asp:TemplateField ItemStyle-Width="10" ShowHeader="False">
                                        <ItemTemplate>
                                            <a id="btnShowPopup" class="thickbox" title='<%# Eval("STK_ID", "แก้ไข UserName {0}") %>'
                                                href='<%# String.Format("QualityReport.aspx?Q={0}&Mode=Edit&TB_iframe=true&height=540&width=600", Stk_QueryString.EncryptQuery( Eval("STK_ID"))) %>'>
                                                <img alt="Quality Report" style="border: 0px" src="images/print.gif" />
                                            </a>
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
		<table id="items" style="border: none;">
		
		<%--  <tbody>--%>
		  <%--    <tr>
		      <th>Item</th>
		      <th>Description</th>
		      <th>Unit Cost</th>
		      <th>Quantity</th>
		      <th>Price</th>
		  </tr>--%>
		 
         <tr class="item-row">
		      <td class="item-name"></td>
		      <td class="description"></td>
		      <td></td>
		      <td></td>
		      <td></td>
		  </tr> 
	 
         

		  <%--<tr class="item-row">
		      <td class="item-name"><div class="delete-wpr"><textarea>Web Updates</textarea><a class="delete" href="javascript:;" title="Remove row" style="display: none;">X</a></div></td>
		      <td class="description"><textarea>Monthly web updates for http://widgetcorp.com (Nov. 1 - Nov. 30, 2009)</textarea></td>
		      <td><textarea class="cost">$650.00</textarea></td>
		      <td><textarea class="qty">1</textarea></td>
		      <td><span class="price">$650.00</span></td>
		  </tr> 
	 --%>
		         
		  
<%--		  <tr id="hiderow">
		    <td colspan="5"><a id="addrow" href="javascript:;" title="Add a row">Add a row</a></td>
		  </tr>--%>
		  
		  <tr>
		      <td colspan="2" class="blank"> </td>
		      <td colspan="2" class="total-line">Subtotal</td>
		      <td class="total-value"> <%-- <div id="subtotal">$650.00</div>  --%>     <asp:Label  id="subtotal" runat="server"></asp:Label> </td>
		  </tr>
<%--		  <tr>

		      <td colspan="2" class="blank"> </td>
		      <td colspan="2" class="total-line">Total</td>
		      <td class="total-value"><div id="total">$650.00</div></td>
		  </tr>--%>
          
      
		  <tr>
		      <td colspan="2" class="blank"> </td>
		      <td colspan="2" class="total-line">Amount Paid</td>

		      <td class="total-value"><%--<textarea id="paid">$0.00</textarea>--%>
               <asp:TextBox id="paid" runat="server" AutoPostBack="True" 
                      ontextchanged="paid_TextChanged"></asp:TextBox>
               </td>
		  </tr>
		  <tr>
		      <td colspan="2" class="blank"> </td>
		      <td colspan="2" class="total-line balance">Balance Due</td>
		      <td class="total-value balance"><%--<div class="due">$650.00</div>--%> <asp:Label ID="lblTotal" CssClass="due" runat="server"></asp:Label>  </td>
		  </tr>
		
	<%--	</tbody>--%>
        
        
        
        
        </table>
		
		<div id="terms">
		  <h5>Terms</h5>
		<%--  <textarea>NET 30 Days. Finance Charge of 1.5% will be made on unpaid balances after 30 days.</textarea>--%>
         NET 30 Days. Finance Charge of 1.5% will be made on unpaid balances after 30 days. 
		</div>
	
	</div>

    </form>
</body>
</html>
