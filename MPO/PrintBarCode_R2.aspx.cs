using System;
using System.Globalization;
using System.Web.UI;
using MPO.Code.Bu;
using MPO.Code.Bu.ColumnGrid;
using Stk.Common;

namespace MPO
{
    public partial class PrintBarCode_R2 : Page
    {
        public string stk_id = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            binddata();
            //BarcodeImage.ImageUrl = "PrintBarCode_HttpBinary.aspx?d=" + "31052015-I02SSSS-SSSS-3-2";

            HideBack();

            // SetLinkInvoice();
        }

        private void HideBack()
        {
            if (User.IsInRole("S"))
            {
                Button7.Visible = true;
            }
            else
            {
                Button7.Visible = false;
            }
        }


        private void SetLinkInvoice()
        {
            String lotid = lbl_PR_LOT.Text;

            string url = string.Format("INVOICE.aspx?Q={0}", Stk_QueryString.EncryptQuery(lotid));


            //OrderDetail.aspx?Q=<%# Stk_QueryString.EncryptQuery( (Eval("OR_ID")))
            // btnprint.Attributes.Add("onclick", "javascript:window.open('" + url + "');return false;");
        }

        private void binddata()
        {
            stk_id = Stk_QueryString.DecryptQuery("Q");

            var stock = new MPO_STOCK();

            stock = stock.GetStockItems(stk_id);

            string strImageUrl = "PrintBarCode_HttpBinary.aspx?d=" + stock.BARCODE_STOCK;
            BarcodeImage.ImageUrl = strImageUrl;

            //For producttablt
            lbl_PR_LOT.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.PR_LOT.ToString());
            lbl_PR_PRODUCE_DATE.Text =
                Stk_TextNull.StringTotext(StkDate.DateTotext(Convert.ToDateTime(stock._MPO_PRODUCT.PR_PRODUCE_DATE)));
            lbl_PR_REV_DATE.Text =
                Stk_TextNull.StringTotext(StkDate.DateTotext(Convert.ToDateTime(stock._MPO_PRODUCT.PR_REV_DATE)));
            lbl_PR_CUT_DATE.Text =
                Stk_TextNull.StringTotext(StkDate.DateTotext(Convert.ToDateTime(stock._MPO_PRODUCT.PR_CUT_DATE)));
            lbl_PR_LINE.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.PR_LINE);
            lbl_PR_CONDITION.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.PR_CONDITION);
            lbl_PR_WEIGHT.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.PR_WEIGHT.ToString());
            lbl_PR_PACK_DATE.Text =
                Stk_TextNull.StringTotext(StkDate.DateTotext(Convert.ToDateTime(stock._MPO_PRODUCT.PR_PACK_DATE)));

            lbl_PR_SUGAR.Text = Stk_TextNull.StringTotext(((stock._MPO_PRODUCT.PR_SUGAR.ToString())));

            lbl_PR_SALT.Text = Stk_TextNull.StringTotext(((stock._MPO_PRODUCT.PR_SALT.ToString())));

            lbl_PR_SORBITOL.Text = Stk_TextNull.StringTotext(((stock._MPO_PRODUCT.PR_SORBITOL.ToString())));

            lbl_PR_POLY_PHOSHATE.Text = Stk_TextNull.StringTotext(((stock._MPO_PRODUCT.PR_POLY_PHOSHATE.ToString())));

            lbl_PR_BOX_TYPE.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.PR_BOX_TYPE);
            lbl_PR_LINE_COLOR.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.PR_LINE_COLOR);
            lbl_PR_UNIT.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.PR_UNIT.ToString());
            lbl_FISH_ID.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.FISH_ID);
            lbl_PR_SIZE.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.PR_SIZE);
            lbl_PR_SOURCE.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.PR_SOURCE);
            lbl_LOCATION.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.LOCATION);
            lbl_ROOM.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.ROOM_ID);

            lbl_PR_FRESHNESS.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.PR_FRESHNESS);
            lbl_PR_STATUS.Text =
                GetCommonColumn.ConvertProductStatus(Stk_TextNull.StringTotext(stock._MPO_PRODUCT.PR_STATUS));

            lbl_REF.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.REF);
            lbl_CREATE_BY.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.CREATE_BY);
            lbl_CHECKIN_BY.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.CHECKIN_BY);
            //lbl_L_UPDATE.Text = Stk_TextNull.StringTotext(stock._MPO_PRODUCT.L_UPDATE.ToString());
            lbl_Dong_DATE.Text = stock._MPO_PRODUCT.Dong_DATE.ToString(CultureInfo.InvariantCulture);


            //lbl_PR_LOT.Text = Stk_TextNull.StringTotext(stock.PR_LOT);
            lbl_MOISTURE.Text = Stk_TextNull.StringTotext(stock.MOISTURE.ToString());
            lbl_PH.Text = Stk_TextNull.StringTotext(stock.PH.ToString());
            lbl_JELLY_ST.Text = Stk_TextNull.StringTotext(stock.JELLY_ST.ToString());
            lbl_COLOR.Text = Stk_TextNull.StringTotext(stock.COLOR.ToString());
            lbl_ODOUR.Text = Stk_TextNull.StringTotext(stock.ODOUR.ToString());
            lbl_SPOT.Text = Stk_TextNull.StringTotext(stock.SPOT.ToString());
            lbl_GRADE.Text = Stk_TextNull.StringTotext(stock.GRADE);
            lbl_STOCK.Text = Stk_TextNull.StringTotext(stock.STOCK);
            lbl_REMARK.Text = Stk_TextNull.StringTotext(stock.REMARK);
            lbl_DARN.Text = Stk_TextNull.StringTotext(stock.DARN.ToString());
            lbl_KUBOMI.Text = Stk_TextNull.StringTotext(stock.KUBOMI.ToString());
            lbl_QC_BY.Text = Stk_TextNull.StringTotext(stock.QC_BY);

            //other label
            lbl_LotCode.Text = "No." + stock.PR_LOT;

           // lbl_Item.Text = Stk_TextNull.StringTotext(stock.ITEMS.ToString());
            lbl_Item.Text = stock._MPO_PRODUCT.PR_UNIT.ToString();
            
            lbl_name.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
         Print(true);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("StockSearch.aspx", false);
        }

        private void Print(bool countITem)
        {
            stk_id = Stk_QueryString.DecryptQuery("Q");

            var stock = new MPO_STOCK();

            stock = stock.GetStockItems(stk_id);
            string fullbarcdoe = stock.BARCODE_STOCK;
            string flage = "y";
            if (countITem)
            {
                flage = "y";
            }

            ClientScript.RegisterStartupScript(GetType(), "key",
                @"var a=window.open('PRintBacrCode_Img.aspx?d=" + fullbarcdoe + "&f=" + flage +
                "', 'letf=0,top=0,toolbar=0,scrollbars=0,sta­tus=0');", true);
        }
    }
}