<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="OrderDetail.aspx.cs" Inherits="MPO.OrderDetail" %>

<%@ Import Namespace="MPO.Code.Bu.ColumnGrid" %>
<%@ Import Namespace="Stk.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   <%-- <link href="Styles/bootstrap_R2.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Order.css" rel="stylesheet" type="text/css" />--%>
    <style type="text/css">
        .signup
        {
            display: block;
            margin: 0 auto;
            margin-top: 10px;
            position: relative;
            width: 90%;
        }
        
        .signup ul li
        {
            float: left; /*display:block;
            list-style-image:none;
            
            margin:0px;*/
            width: 22%;
        }
        
        .signup ul li label
        {
            float: left; /*display:block;
            list-style-image:none;
            
            margin:0px;*/
            width: 100%;
        }
        
        
        
        .ActiveButton
        {
            background-color: #4E616D;
        }
        
        
        #signup
        {
            position: relative;
            margin: 0 auto;
            display: block;
            width: 850px;
            margin-top: 10px;
            overflow: auto;
        }
        
        #divOrderDetail
        {
            width: 800px;
            margin-left: auto;
            margin-right: auto;
            margin-top: 10px;
        }
        
        #reslut
        {
            position: relative;
            margin: 10px;
            display: block;
            position: relative;
            height: 150px;
        }
        
        #reslut ul li
        {
            width: 300px !important;
        }
        
        #reslut ul li label
        {
            padding-right: 5px;
            float: left;
        }
        
        #reslut ul li label + label
        {
            font-weight: normal;
        }
        
        
        #legenlabel
        {
            display: block;
            margin-top: 0px;
            width: 100px;
        }
        
        
        
        
        
        #OrderDetail
        {
            width: 700px !important;
            margin: 0 auto;
            padding: 5px;
        }
        
        #OrderDetailProfile1
        {
            float: left;
            width: 49%;
            padding-left: 34px;
        }
        
        #OrderDetailProfile1 ul li
        {
            width: 93%;
        }
        
        #OrderDetailProfile1 ul li label
        {
            float: left;
            width: 60px;
        }
        
        
        #OrderDetailProfile2
        {
            float: left;
            width: 45%;
            padding: 4px;
        }
        
        #OrderDetailProfile2 ul li
        {
            width: 93%;
        }
        
        #OrderDetailProfile2 ul li label
        {
            float: left;
            width: 100px;
        }
        
        #OrderDetailProfile3
        {
            width: 98%;
            clear: both;
            padding-left: 5px;
            padding-right: 5px;
        }
        
        
        #divGoodDetail ul li
        {
            width: 50px;
        }
        
        #divGoodDetail ul li + li
        {
            width: 357px;
        }
        
        #divGoodDetail ul li + li + li
        {
            width: 50px;
        }
        
        #divGoodDetail ul li + li + li + li
        {
            width: 80px;
        }
        
        
        .DivRow div
        {
            width: 20%;
        }
        
        .DivRow div + div
        {
            width: 40%;
        }
        
        .DivRow div + div + div
        {
            width: 10%;
        }
        
        .DivRow div + div + div + div
        {
            width: 20%;
        }
        
        
        .DivRow div + div + div + div + div
        {
            width: 10%;
        }
        
        #divButtonSet div
        {
            float: left;
        }
        
        #divButtonSet div + div
        {
            float: right;
        }
        
        #mainDetail
        {
            display: block;
            overflow: auto;
            width: 100%;
        }
        
        #detail1
        {
            padding: 6px;
            clear: left;
            display: block;
            float: left;
            width: 49%;
            margin-left: 8px;
        }
        
        #detail2
        {
            padding: 6px;
            display: block;
            float: right;
            width: 48%;
            margin-right: 8px;
        }
        
        
        
        
        
        select
        {
            /*padding:2px !important;
       height:22px !important;*/
        }
        
        .InputForm ul li
        {
            /*  height: 40px;*/
            padding: 10px;
        }
        
        
        #itemDetail
        {
            margin-left: 8px;
            margin-right: 8px;
        }
        
        #itemDetailButton
        {
            float: right;
        }
        
        
        
        
        #detailBuutton
        {
            float: left;
            width: 47%;
            margin-left: 8px;
            padding: 4px;
        }
        
        #detailBox
        {
            float: right; /*width: 48%;*/
            margin-right: 8px;
            padding: 4px;
        }
        
        #signup .txt-fld
        {
            padding: 0px;
            height: 27px;
        }
        
        #customer
        {
            width: 500px;
            height: 320px;
        }
        
        #customerForm
        {
            overflow: visible;
        }
        
        
        .customerPaddingbutton
        {
            padding-bottom: 6px;
        }
        
        .customerbuttonRight
        {
            padding-top: 15px;
            padding-bottom: 10px;
            text-align: right;
        }
        
        
        
        
        
        
        
        /*CusTom Sltyte*/
        .DivCell
        {
            clear: none;
            display: block;
            float: left;
            margin: 0px 5px 5px 0px;
            min-height: 140px;
            overflow: hidden;
            padding: 3px;
            width: 31.9%;
        }
        
        .TypeCate
        {
            width: 100% !important;
        }
        
        #Div_Product_Detail
        {
            margin-left: 8px; /*min-height: 400px;*/
            min-height: 290px;
            position: relative;
            width: 98%;
            overflow: auto;
            display: block;
        }
        
        #Div_Product_Detail DIV
        {
            display: block;
            float: left;
            margin: 0px 3px 3px 0px;
        }
        
        .div_details_rows
        {
            border-bottom-style: dotted;
            border-color: #ccc;
            border-width: 1px;
            cursor: pointer;
            display: run-in;
            overflow: hidden;
            padding: 9px;
            position: relative;
            width: 98%;
        }
        
        .div_details_rows:hover
        {
            background-color: #F9EDBE;
        }
        
        .div_details_rows .divShortClomun
        {
            width: 20%;
        }
        
        .div_details_rows .divLongClomun
        {
            width: 78%;
        }
        
        .div_details_rows .divClomun
        {
            width: 24.5%;
        }
        
        
        .SelectBackGround
        {
            background-color: #F4F4F4;
        }
        
        /*Custom Width*/
        
        .InputForm ul li select
        {
            /*  width: 180px;*/
        }
        
        
        
        /*For slide like hotmail*/
        #Div_Product_Detail div
        {
            margin-left: 5px;
        }
        
        
        td, th
        {
            padding: 3px; /* text-align: center; */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
     
      
                
                 <fieldset style="margin-left: auto; margin-right: auto; width: 600px;">
        <legend>รายการ</legend>
                
              
                            <table width="100%">
                                <td colspan="2">
                                    <asp:Label ID="lbl_COMPANY" runat="server" />
                                    (<asp:Label ID="lbl_CUSTNO" runat="server" />
                                    )
                                </td>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_ADDR1" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_ADDR2" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_CITY" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_STATE" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_ZIP" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_COUNTRY" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_PHONE" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_FAX" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_TAXRATE" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_CONTACT" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_LASTINVOICEDATE" runat="server" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                     ผู่ขาย :  
                                        <asp:Label ID="lblSeller" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                    
                   
               
                        <div id="itemDetailButton" style="display: inline;  margin: 10px;" runat="server">
                            <div style="display: none">
                            </div>
                                <div class="extrapad">
                             <%--   <a id="btnShowPopup0" class="thickbox" href="PopUpProductOrderR2.aspx?Mode=Add&amp;TB_iframe=true&amp;height=550&amp;width=1000"
                                    title="เพิ่มข้อมูล">
                                
                                
                                 <asp:Button ID="Button1" runat="server"   Text="ใบแจ้งส่งสินค้า" />
                                  </a>--%>
                            </div>
                            
                                   
               

                        </div>
               
             
                 </fieldset>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                DataKeyNames="ORDE_ID" EnableViewState="False" CssClass="mGrid"
                                Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="ORDE_ID" HeaderText="ลำดับ" SortExpression="ORDE_ID" /> 
                                  <%--  <asp:BoundField DataField="OR_ID" HeaderText="รหัส" SortExpression="OR_ID" />--%>
                                    <asp:BoundField DataField="PR_LOT" HeaderText="No" SortExpression="PR_LOT" />
                                    <asp:TemplateField HeaderText="ชื่อสินค้า">
                                        <ItemTemplate>
                                            <%# GetProductName(Eval("PR_LOT"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ITEMS" HeaderText="จำนวน" SortExpression="ITEMS" />
                                    <asp:BoundField DataField="COST" HeaderText="ราคา" SortExpression="COST" />
                                    <asp:BoundField DataField="TOTAL" HeaderText="รวม" SortExpression="TOTAL" />
                                    <asp:BoundField DataField="LOADINGDATE" HeaderText="LOADINGDATE" SortExpression="LOADINGDATE"
                                        DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="SHIPMENTNO" HeaderText="SHIPMENTNO" SortExpression="SHIPMENTNO" />
                                    <asp:BoundField DataField="CONTAINERNO" HeaderText="CONTAINERNO" SortExpression="CONTAINERNO" />
                                    <asp:BoundField DataField="TRUCKNO" HeaderText="TRUCKNO" SortExpression="TRUCKNO" />
                                    <asp:BoundField DataField="STAMP" HeaderText="STAMP" SortExpression="STAMP" />
                                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
                               <%--     <asp:BoundField DataField="STATUS_CURRENT" HeaderText="STATUS_CURRENT" SortExpression="STATUS_CURRENT" />--%>
                                    <asp:TemplateField HeaderText="สถานะ">
                                        <ItemTemplate>
                                            <%# GetCommonColumn.ConvertOrderStatus(Eval("STATUS_CURRENT"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10" ShowHeader="False">
                                        <ItemTemplate>
                                            <a id="btnShowPopup"  target="_blank" title='<%# Eval("STK_ID", "พิมพ์ Quality Report") %>'
                                                href='<%# String.Format("QualityReportR2.aspx?Q={0}&ORDE_ID={1}&Mode=Edit&TB_iframe=true&height=540&width=600",Stk_QueryString.EncryptQuery( Eval("STK_ID")),Stk_QueryString.EncryptQuery( Eval("ORDE_ID"))) %>'>
                                                <img alt="Quality Report" style="border: 0px" src="images/print.gif" />
                                            </a>
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                    </asp:TemplateField>
                                </Columns>
                                  <SelectedRowStyle CssClass="SelectedRowStyle" />
                    
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        <RowStyle CssClass="RowStyle" />
                            </asp:GridView>
                     
                
                    <div id="detailBuutton" class="InputForm">
                                                <%--    <asp:Button ID="btnprint" runat="server"   Text="INVOICE" OnClientClick="javascript:window.print();return false;" />--%>
                               <asp:Button ID="btnprint" runat="server"   Text="INVOICE" />         <asp:Button ID="btnSend" runat="server"   Text="ใบแจ้งส่งสินค้า" />
                            </div>
                    <div id="detailBox" class="InputForm ">
                         
                    </div>
         
            <div style="display: none">
                <asp:Button ID="btnBack" runat="server" CssClass="btn btn-default" Text="กลับ" OnClientClick="javascript:history.back();"
                    Visible="False" /></div>
    
</asp:Content>
