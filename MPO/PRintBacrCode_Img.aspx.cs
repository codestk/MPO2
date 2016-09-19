using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MPO
{
    public partial class PRintBacrCode_Img : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            string lotNo = Request.QueryString["d"];
            string strImageURL = "PrintBarCode_HttpBinary.aspx?d=" + lotNo;
            this.BarcodeImage.ImageUrl = strImageURL;

            //javascript: window.print(); window.close(); return true;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //BarCode_R2 barCode = new BarCode_R2();

            //string barcode = Request.QueryString["d"];
            //string flage = Request.QueryString["f"];
            //string strImageURL = "GenBarCodeHttp_R2.aspx?d=" + barcode;
            //if (flage == "y")
            //{

            //    string lotno = barcode.Substring(barcode.Length - 9);
            //    barCode.ItemPlus(lotno);
            //}


            refreshParentPage();


        }


        private void refreshParentPage()
        {


            ClientScript.RegisterStartupScript(GetType(), "key",
             @" window.location.reload();", true);
        }
    }
}