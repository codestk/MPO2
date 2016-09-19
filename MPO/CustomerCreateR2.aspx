<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerCreateR2.aspx.cs" Inherits="MPO.WebCustomer.CustomerCreateR2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/FormDiy.css" rel="stylesheet" type="text/css" />
    
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <style>
       
        body {
            background-color: #ffffff !important;
        }
        label 
        {
            float: none;
            clear: both;
}
    </style>
    <script src="Scripts/Stk/Momojojo_Web-1.0.1.0.js" type="text/javascript"></script>
    <%--   <script type="text/javascript" src="Scripts/Stk/Momojojo_Web-1.0.1.0.js"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            ForceNumberTextBox();
        });

        function updated() {
            //  close the popup
            tb_remove();
            //           refresh the update panel so we can view the changes  
            //          $("#< %= btnSearch.ClientID %  >").click();

        }

        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                //  reapply the thick box stuff
                tb_init('a.thickbox');

            }
        }


        //For Validate Type
        function ForceNumberTextBox() {
            $("#<%= txt_TAXRATE.ClientID %>").ForceNumericOnly2Digit();
        }
    </script>
</head>
<body  >
    <form id="form1" runat="server">
    <div class="panel panel-primary" style="width: 300px; margin-left: auto; margin-right: auto;
        margin-top: 10px; margin-bottom: 10px;">
    
        <div class="panel-body">
            <div class="well bs-component " style="margin-left: auto; margin-right: auto;">
                <fieldset>
                    <legend>ลูกค้า</legend>
                    <div class="form-group">
                        <label for="inputEmail" class="col-lg-5 control-label">
                            รหัสลูกค้า</label>
                        <div class="col-lg-5">
                            <asp:Label ID="lbl_CUSTNO" runat="server"  />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPassword" class="col-lg-5 control-label">
                            ชื่อบริษัท</label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txt_COMPANY" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPassword" class="col-lg-5 control-label">
                            ที่อยู่ 1</label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txt_ADDR1" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPassword" class="col-lg-5 control-label">
                            ที่อยู่ 2</label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txt_ADDR2" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPassword" class="col-lg-5 control-label">
                            เขต</label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txt_CITY" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPassword" class="col-lg-5 control-label">
                            จังหวัด</label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txt_STATE" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPassword" class="col-lg-5 control-label">
                            รหัสไปรษณีย์</label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txt_ZIP" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPassword" class="col-lg-5 control-label">
                            ประเทศ
                        </label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txt_COUNTRY" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPassword" class="col-lg-5 control-label">
                            เบอร์โทร
                        </label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txt_PHONE" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPassword" class="col-lg-5 control-label">
                            แฟกซ์
                        </label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txt_FAX" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPassword" class="col-lg-5 control-label">
                            ภาษี
                        </label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txt_TAXRATE" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPassword" class="col-lg-5 control-label">
                            ผู้ติตต่อ
                        </label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txt_CONTACT" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPassword" class="col-lg-5 control-label">
                        </label>
                        <div class="col-lg-5" style="text-align: left">
                            <asp:Button ID="btnSave" runat="server" Text="บันทึก" class="btn btn-primary" OnClick="btnSave_Click" />
                        
                        </div>
                    </div>
                </fieldset>
                <asp:Label ID="txtMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
    </form>
</body>
</html>