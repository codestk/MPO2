using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Common;
using Stk.Common;

namespace MPO
{
    public partial class PrintBarCodePreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["d"] != null)
                {
                    //Read in the parameters
                    string strData = Request.QueryString["d"];
                    Stk_Barcode_R2 barcodeR2 = new Stk_Barcode_R2();
                    barcodeR2.GenBarCode128(strData);
                    MemoryStream MemStream = barcodeR2.GenBarCode128(strData);
                    MemStream.WriteTo(Response.OutputStream);


                }//if
            }//try
            catch (System.Exception ex)
            {
                Response.Write(e.ToString());
                //TODO: find a way to return this to display the encoding error message
            }//catch
            finally
            {
                //if (barcodeImage != null)
                //{
                //    //Clean up / Dispose...
                //   // barcodeImage.Dispose();
                //}
            }//finally
        }//if
    }
}