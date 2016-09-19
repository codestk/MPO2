function PrintPanel() {
    var divContents = $(".ContentDiv").html(); //ContentDiv means div or panel class name   
     
    var printWindow = window.open('', '', 'height=400,width=1050,scrollbars=1');
    printWindow.document.write('<html><head><title>Business Trends Report</title>');
   
    printWindow.document.write('<link rel="stylesheet" type="text/css" href=" http://localhost/Stk/Styles/bootstrap_R2.css" />'); //css path  
    printWindow.document.write(' <link href=" http://localhost/Stk/Styles/StyleSheet.css" rel="stylesheet" type="text/css" />'); //css path  
    printWindow.document.write('  <link href=" http://localhost/Stk/Styles/detailgrid.css" rel="stylesheet" type="text/css" />'); //css path  

    printWindow.document.write('</head><body>');
    printWindow.document.write(divContents);
       
    printWindow.document.write('</body></html>');
    printWindow.document.close();
    printWindow.print();

}

 