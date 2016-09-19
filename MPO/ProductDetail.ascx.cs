using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using MPO.Code.TempData;
using Stk.Common;

namespace MPO
{
    public partial class ProductDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         //   if (!Page.IsPostBack)
                BindDataConfirm();
        }


        private void BindDataConfirm()
        {
            MPO_PRODUCT pr2 = TempProduct.TEMP_MPO_PRODUCT;


            if  (pr2==null)
           return;

            lblLotNo.Text = Stk_TextNull.StringTotext(pr2.PR_LOT.ToString());
            lbl_PR_PRODUCE_DATE.Text = Stk_TextNull.StringTotext(StkDate.DateTotext(pr2.PR_PRODUCE_DATE));
            lbl_PR_REV_DATE.Text = Stk_TextNull.StringTotext(StkDate.DateTotext(pr2.PR_REV_DATE));
            lbl_PR_CUT_DATE.Text = Stk_TextNull.StringTotext(StkDate.DateTotext(pr2.PR_CUT_DATE));
            lbl_PR_LINE.Text = Stk_TextNull.StringTotext(pr2.PR_LINE);
            lbl_PR_CONDITION.Text = Stk_TextNull.StringTotext(pr2.PR_CONDITION);
            lbl_PR_WEIGHT.Text = Stk_TextNull.StringTotext(pr2.PR_WEIGHT.ToString());
            lbl_PR_PACK_DATE.Text = Stk_TextNull.StringTotext(StkDate.DateTotext(pr2.PR_PACK_DATE));
            lbl_PR_BOX_TYPE.Text = Stk_TextNull.StringTotext(pr2.PR_BOX_TYPE);
            lbl_PR_LINE_COLOR.Text = Stk_TextNull.StringTotext(pr2.PR_LINE_COLOR);
            lbl_PR_UNIT.Text = Stk_TextNull.StringTotext(pr2.PR_UNIT.ToString());
            lbl_FISH_ID.Text = Stk_TextNull.StringTotext(pr2.FISH_ID);
            lbl_PR_SIZE.Text = Stk_TextNull.StringTotext(pr2.PR_SIZE);
            lbl_PR_SOURCE.Text = Stk_TextNull.StringTotext(pr2.PR_SOURCE);
            // lbl_LOCATION.Text = Stk_TextNull.StringTotext(pr2.LOCATION);
            // lbl_PR_STATUS.Text = Stk_TextNull.StringTotext(pr2.PR_STATUS);
            //lbl_BARCODE.Text = Stk_TextNull.StringTotext(pr2.BARCODE);
            lbl_REF.Text = Stk_TextNull.StringTotext(pr2.REF);
            //lbl_CREATE_BY.Text = Stk_TextNull.StringTotext(pr2.CREATE_BY);
            //lbl_CHECKIN_BY.Text = Stk_TextNull.StringTotext(pr2.CHECKIN_BY);
            //lbl_L_UPDATE.Text = Stk_TextNull.StringTotext(pr2.L_UPDATE);

            lbl_Dong_DATE.Text = Stk_TextNull.StringTotext((pr2.Dong_DATE.ToString()));

        }


    }
}