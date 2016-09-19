<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="MPO.Menu" %>
<%@ Import Namespace="MPO.Code.Enum" %>
<%@ Import Namespace="StkLib.CCEnum" %>
<% if (HttpContext.Current.User.IsInRole(StringEnum.GetStringValue(EnumStkRole.Purchase)))
   { %>
<ul class="jd_menu">
    <li><a href="default.aspx">หน้าแรก</a></li>
    <li><a href="Sales.aspx">ทำรายการสั่งซื้อ</a></li>
    <li><a href="StockSearch.aspx">สินค้าคงคลัง</a></li>
</ul>
<% } %>
<% else if ((HttpContext.Current.User.IsInRole(StringEnum.GetStringValue(EnumStkRole.Store))))
   { %>
<ul class="jd_menu">
    <li><a href="default.aspx">หน้าแรก</a></li>
    <li><a href="StoreCheckIn.aspx">รายการนำเข้า</a></li>
    <li><a href="StoreCheckOut.aspx">รายการนำออก</a> </li>
    <!--สำหรับทำ High light-->
    <li style="display: none"><a href="StoreImportsSaveR2.aspx">ผลิตสินค้า</a></li>
    <li style="display: none"><a href="Exports_R2.aspx">ผลิตสินค้า</a></li>
</ul>
<% } %>
<% else if ((HttpContext.Current.User.IsInRole(StringEnum.GetStringValue(EnumStkRole.SuperVisor))))
   { %>
<ul class="jd_menu">
    <li><a href="default.aspx">หน้าแรก</a></li>
    <li><a href="OrderSearch.aspx">ค้นหาใบสั่งซื้อ</a></li>
    <li><a href="StockSearch.aspx">ตรวจสอบสินค้าในคลัง</a> </li>
    <!--สำหรับทำ High light-->
    <li style="display: none"><a href="StoreImportsSaveR2.aspx">ผลิตสินค้า</a></li>
    <li style="display: none"><a href="Exports_R2.aspx">ผลิตสินค้า</a></li>
</ul>
<% } %>
<% else if (HttpContext.Current.User.IsInRole(StringEnum.GetStringValue(EnumStkRole.Admin)))
   { %>
<ul class="jd_menu">
    <li><a href="ManageUser.aspx">จัดการผู้ใช้งาน</a></li><li><a href="CustomerSearchR2.aspx">
        ลูกค้า</a></li><li><a href="Locations.aspx">ตำแหน่งจัดเก็บ</a></li>
</ul>
<% } %>
<% else if (HttpContext.Current.User.IsInRole(StringEnum.GetStringValue(EnumStkRole.User)))
   { %>
xxxxx
<% } %>
<% else if (HttpContext.Current.User.IsInRole(StringEnum.GetStringValue(EnumStkRole.Production)))
   { %>
<ul class="jd_menu">
    <li><a href="default.aspx">หน้าแรก</a></li>
    <li><a href="Production.aspx">ผลิตสินค้า</a></li>
    <!--สำหรับทำ High light-->
</ul>
<% } %>
<% else if (HttpContext.Current.User.IsInRole(StringEnum.GetStringValue(EnumStkRole.QC)))
   { %>
<ul class="jd_menu">
    <li><a href="default.aspx">หน้าแรก</a></li>
    <li><a href="QC.aspx">Quality Control</a></li>
    <!--สำหรับทำ High light-->
</ul>
<% } %>
<% else
   { %>
<ul class="jd_menu">
    <li><a href="BarCodeCreate_R2.aspx">ผลิตสินค้า &raquo;</a>
        <ul>
            <li><a href="BarCodeCreate_R2.aspx">กำหนดการผลิต</a> </li>
            <li style="display: none"><a href="PrintBarCode_R2.aspx">ผลิตสินค้า</a></li>
        </ul>
    </li>
    <li><a href="BarCodeList_R2.aspx">ค้นหารายการผลิต</a></li>
    <li><a href="BarCodeListHistory_R2.aspx">ข้อมูลผลิตย้อนหลัง</a></li>
    <!--สำหรับทำ High light-->
</ul>
<% } %>
