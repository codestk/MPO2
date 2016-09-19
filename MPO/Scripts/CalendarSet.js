

function InnitControl() {

    var _dayNames = ['อาทิตย์', 'จันทร์', 'อังคาร', 'พุธ', 'พฤหัสบดี', 'ศุกร์', 'เสาร์'];
    var _dayNamesMin = ['อา', 'จ', 'อ', 'พ', 'ฤ', 'ศ', 'ส'];
    var _monthNames = ['มกราคม', 'กุมภาพันธ์', 'มีนาคม', 'เมษายน', 'พฤษภาคม', 'มิถุนายน', 'กรกฎาคม', 'สิงหาคม', 'กันยายน', 'ตุลาคม', 'พฤศจิกายน', 'ธันวาคม'];
    var _monthNamesShort = ['ม.ค.', 'ก.พ.', 'มี.ค.', 'เม.ย.', 'พ.ค.', 'มิ.ย.', 'ก.ค.', 'ส.ค.', 'ก.ย.', 'ต.ค.', 'พ.ย.', 'ธ.ค.'];
    var _constrainInput = true;
    var _dateFormat = 'd/m/yy';

    var now = new Date();
    var _formDate = new Date(now.getFullYear(), now.getMonth() -1, 1);

//    $(".ControlDatePicker1,.ControlDatePicker2,.ControlDatePicker3,.ControlDatePicker4").datepicker({
    $(".ControlDatePicker").datepicker({
        changeMonth: true,
        changeYear: true,
        //defaultDate: GetFxupdateDate(FxRateDateAndUpdate.d[0].Day),
               showOn: "button",
               buttonImage: "images/calendar.gif",
        //        buttonImageOnly: false,
        isBuddhist: true,
        dateFormat: _dateFormat,
        //yearOffset: 543,
        dayNames: _dayNames,
        dayNamesMin: _dayNamesMin,
        monthNames: _monthNames,
        monthNamesShort: _monthNamesShort,
        constrainInput: _constrainInput

    });

    if ($(".ControlDatePicker1").val() == '') {
        $(".ControlDatePicker1").datepicker('setDate', _formDate);
    }

    if ($(".ControlDatePicker2").val() == '') {
        $(".ControlDatePicker2").datepicker('setDate', _formDate);
    }

    if ($(".ControlDatePicker3").val() == '') {
        $(".ControlDatePicker3").datepicker('setDate', _formDate);
    }
    if ($(".ControlDatePicker4").val() == '') {
        $(".ControlDatePicker4").datepicker('setDate', _formDate);
    }
 
//  $(".ControlDatePicker1").datepicker('setDate', _formDate);
//  $(".ControlDatePicker2").datepicker('setDate', _formDate);
//  $(".ControlDatePicker3").datepicker('setDate', _formDate); 
//  $(".ControlDatePicker4").datepicker('setDate', _formDate);
    
}


$(document).ready(function () {
//    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
//    function EndRequestHandler(sender, args) {
//        InnitControl();
//    }

});



$(document).ready(function () {

    InnitControl();

});
