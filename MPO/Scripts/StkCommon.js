






//Check length in drop down list
function checkTextAreaMaxLength(textBox, e, length) {
 
    var mLen = textBox["MaxLength"];
    if (null == mLen)
        mLen = length;

    var maxLength = parseInt(mLen);
    if (!checkSpecialKeys(e)) {
        if (textBox.value.length > maxLength - 1) {
            if (window.event)//IE
                e.returnValue = false;
            else//Firefox
                e.preventDefault();
        }
    }
}
function checkSpecialKeys(e) {
    if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
        return false;
    else
        return true;
}

 

function OpenNewWindows(url) {
    
    var WinPrint =window.open(url, 'Reports', 'letf=0,top=100,width=890,height=500,toolbar=0,scrollbars=1,sta­tus=0');
//    WinPrint.document.write(prtContent.innerHTML);
//    WinPrint.document.close();
//    WinPrint.focus();
//    WinPrint.print();
//    WinPrint.close();
    //prtContent.innerHTML=strOldOne; 

}

//function updated() {
//    //  close the popup
//    tb_remove();

//    //  refresh the update panel so we can view the changes  
//    $('#<%= this.btnRefreshCustomers.ClientID %>').click();
//}

//function pageLoad(sender, args) {
//    if (args.get_isPartialLoad()) {
//        //  reapply the thick box stuff
//        tb_init('a.thickbox');

//    }
//}
