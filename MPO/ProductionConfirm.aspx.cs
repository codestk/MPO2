using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using MPO.Code.TempData;
using Stk.Common;
using StkLib.Errors;

namespace MPO
{
    public partial class ProductionConfirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (TempProduct.TEMP_MPO_PRODUCT == null)
            {
                Response.Redirect("Production.aspx");
            }

            if(!Page.IsPostBack)
            BindDataConfirm();
        }

        private void BindDataConfirm()
        {
            MPO_PRODUCT pr2 = TempProduct.TEMP_MPO_PRODUCT;
         // lbl_PR_LOT.Text = Stk_TextNull.StringTotext(pr2.PR_LOT);
            lbl_PR_PRODUCE_DATE.Text = Stk_TextNull.StringTotext(StkDate.DateTotext(pr2.PR_PRODUCE_DATE));
          lbl_PR_REV_DATE.Text = Stk_TextNull.StringTotext(StkDate.DateTotext(pr2.PR_REV_DATE));
          lbl_PR_CUT_DATE.Text = Stk_TextNull.StringTotext(StkDate.DateTotext(pr2.PR_CUT_DATE));
          lbl_PR_LINE.Text = Stk_TextNull.StringTotext(pr2.PR_LINE);
          lbl_PR_CONDITION.Text = Stk_TextNull.StringTotext(pr2.PR_CONDITION);
          lbl_PR_WEIGHT.Text = Stk_TextNull.StringTotext(pr2.PR_WEIGHT.ToString());
          lbl_PR_PACK_DATE.Text = Stk_TextNull.StringTotext(StkDate.DateTotext(  pr2.PR_PACK_DATE));
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
   
          lbl_PR_SUGAR.Text = Stk_TextNull.StringTotext(pr2.PR_SUGAR.ToString());

          lbl_PR_SALT.Text = Stk_TextNull.StringTotext(pr2.PR_SALT.ToString());
          lbl_PR_SORBITOL.Text = Stk_TextNull.StringTotext(pr2.PR_SORBITOL.ToString());
          lbl_PR_POLY_PHOSHATE.Text = Stk_TextNull.StringTotext(pr2.PR_POLY_PHOSHATE.ToString());
            //lbl_CREATE_BY.Text = Stk_TextNull.StringTotext(pr2.CREATE_BY);
          //lbl_CHECKIN_BY.Text = Stk_TextNull.StringTotext(pr2.CHECKIN_BY);
          //lbl_L_UPDATE.Text = Stk_TextNull.StringTotext(pr2.L_UPDATE);
          lbl_PR_FRESHNESS.Text = Stk_TextNull.StringTotext(pr2.PR_FRESHNESS.ToString());
          lbl_Dong_DATE.Text = Stk_TextNull.StringTotext( (pr2.Dong_DATE.ToString()));

          lbl_REMARK.Text = Stk_TextNull.StringTotext((pr2.REMARK.ToString()));
        }

        private void save()

        {
            int a = 0;
            MPO_PRODUCT pr2 = TempProduct.TEMP_MPO_PRODUCT;
            try
            {
                 a=pr2.Save();
            }
            catch (Exception ex)
            {
                ErrorLogging.LogError(ex, "");
                StkAlert.ShowAjax(ex.Message.Replace("'"," "), Page);
                return;
            }

          
            if (a > 0)
            {

                TempProduct.TEMP_MPO_PRODUCT = null;
                //pnlSave.Visible = false;
                //pnlSuccess.Visible = true;
                //lblLotSuccess.Text = "LOT : " + a;
                lblLotNo.Visible = true;
                lblLotNo.Text=    a.ToString();
                btnCancel.Text = "Back";

                Confirm.Visible = false;
            }



        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            save();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Production.aspx");
        }
    }
}