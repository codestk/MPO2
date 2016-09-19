using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using MPO.Code.Common;
using MPO.Code.TempData;
using Stk.Common;

namespace MPO
{
    public partial class Production : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetDrop();
            }
        }


        private void SetDrop()
        {
            drpRecreate.DataSource = (new MPO_PRODUCT()).GetAllForRecreate();
            drpRecreate.DataTextField = "PR_LOT";
            drpRecreate.DataValueField = "PR_LOT";
            drpRecreate.DataBind();

            var lt = new ListItem("-", "0");
            drpRecreate.Items.Insert(0, lt);

            StkDropDown.SetDropSource(drpSource);

            StkDropDown.SetDropFish(drpFishID);

           // StkDropDown.SetDropFishSize(drpFishSize);

            StkDropDown.SetdrpColor(drp_PR_LINE_COLOR);

            StkDropDown.SetDropLine(drp_PR_LINE);

            StkDropDown.SetdrpBOX_TYPE(drp_PR_BOX_TYPE);

            StkDropDown.SetdrpCondition(drp_PR_CONDITION);



            StkDropDown.SetDropFreshness(drpPR_FRESHNESS);


            //StkDropDown.SetDropFishSize(drpFishSize, drpFishID.SelectedValue);
            StkDropDown.SetDropFishSize(drpFishSize);
        }


        private bool Validate()
        {
            bool b = true;


            if (txt_PR_PRODUCE_DATE.Text == "")
            {
                b = false;
                txt_PR_PRODUCE_DATE.Focus();
                lblMsg.Text = "โปรดกำหนดวันที่ผลิต";
                return b;
            }

            if (StkValidates.IsDate(txt_PR_PRODUCE_DATE.Text) == false)
            {
                b = false;
                txt_PR_PRODUCE_DATE.Focus();
                lblMsg.Text = "รูปแบบวันที่ผลิตไม่ถูกต้อง";
                return b;
            }


            if (drpSource.SelectedIndex == 0)
            {
                b = false;
                lblMsg.Text = "โปรดเลือกแหล่งปลา	";
                drpSource.Focus();
                return b;
            }

            if (drpFishID.SelectedIndex == 0)
            {
                b = false;
                lblMsg.Text = "โปรดเลือกรหัสปลา	";
                drpFishID.Focus();
                return b;
            }


            if (drpFishSize.SelectedIndex == 0)
            {
                b = false;
                lblMsg.Text = "โปรดเลือกขนาดปลา";
                drpFishSize.Focus();
                return b;
            }

            //=================================================================

            if (txt_PR_REV_DATE.Text == "")
            {
                b = false;
                txt_PR_REV_DATE.Focus();
                lblMsg.Text = "โปรดกำหนดวันที่รับปลาตัว";
                return b;
            }

            if (StkValidates.IsDate(txt_PR_REV_DATE.Text) == false)
            {
                b = false;
                txt_PR_PRODUCE_DATE.Focus();
                lblMsg.Text = "รูปแบบวันที่รับปลาตัวไม่ถูกต้อง";
                return b;
            }
            //========================================================================

            if (txt_PR_CUT_DATE.Text == "")
            {
                b = false;
                txt_PR_CUT_DATE.Focus();
                lblMsg.Text = "โปรดกำหนดวันที่ตัดหัวปลา";
                return b;
            }

            if (StkValidates.IsDate(txt_PR_CUT_DATE.Text) == false)
            {
                b = false;
                txt_PR_CUT_DATE.Focus();
                lblMsg.Text = "รูปแบบวันที่ตัดหัวปลาไม่ถูกต้อง";
                return b;
            }

            //==========================================================================


            //if (txt_PR_LINE.Text == "")
            //{
            //    b = false;
            //    txt_PR_LINE.Focus();
            //    lblMsg.Text = "โปรดกำหนดไลน์ผลิต";
            //    return b;
            //}
               if (drp_PR_LINE.SelectedIndex == 0)
            {
                b = false;
                drp_PR_LINE.Focus();
                lblMsg.Text = "โปรดกำหนดไลน์ผลิต";
                return b;
            }
          
            //==========================================================================

            //if (txt_PR_CONDITION.Text == "")
            //{
            //    b = false;
            //    txt_PR_CONDITION.Focus();
            //    lblMsg.Text = "โปรดเกำหนดเงื่อนไขผลิต";
            //    return b;
            //}
              if (drp_PR_CONDITION.SelectedIndex == 0)
            {
                b = false;
                drp_PR_CONDITION.Focus();
                lblMsg.Text = "โปรดเกำหนดเงื่อนไขผลิต";
                return b;
            }
             

            //===========================================================================

            if (txt_PR_WEIGHT.Text == "")
            {
                b = false;
                txt_PR_WEIGHT.Focus();
                lblMsg.Text = "โปรดเกำหนดน้ำหนักผลิตได้";
                return b;
            }

            //===========================================================================

            if (txt_PR_PACK_DATE.Text == "")
            {
                b = false;
                txt_PR_PACK_DATE.Focus();
                lblMsg.Text = "โปรดกำหนดวันที่บรรจุ";
                return b;
            }

            if (StkValidates.IsDate(txt_PR_PACK_DATE.Text) == false)
            {
                b = false;
                txt_PR_PACK_DATE.Focus();
                lblMsg.Text = "รูปแบบวันที่บรรจุไม่ถูกต้อง";
                return b;
            }
            //===========================================================================

            if (drp_PR_BOX_TYPE.SelectedIndex == 0)
            {
                b = false;
                drp_PR_BOX_TYPE.Focus();
                lblMsg.Text = "โปรดกำหนดชนิดกล่อง";
                return b;
            }
            //===========================================================================

            if (drp_PR_LINE_COLOR.SelectedIndex == 0)
            {
                b = false;
                drp_PR_LINE_COLOR.Focus();
                lblMsg.Text = "โปรดกำหนดสีสายลัด";
                return b;
            }


            //$("#<%= txt_PR_SUGAR.ClientID %>").ForceNumericOnly2Digit();
            //$("#<%= txt_PR_SALT.ClientID %>").ForceNumericOnly2Digit();
            //$("#<%= txt_PR_SORBITOL.ClientID %>").ForceNumericOnly2Digit();
            //$("#<%= txt_PR_POLY_PHOSHATE.ClientID %>").ForceNumericOnly2Digit();

            if (txt_PR_SUGAR.Text == "")
            {
                b = false;
                txt_PR_SUGAR.Focus();
                lblMsg.Text = "โปรดกำหนดปริมาณน้ำตาล";
                return b;
            }


            if (txt_PR_SALT.Text == "")
            {
                b = false;
                txt_PR_SALT.Focus();
                lblMsg.Text = "โปรดกำหนดปริมาณเกลือ";
                return b;
            }

            if (txt_PR_SORBITOL.Text == "")
            {
                b = false;
                txt_PR_SORBITOL.Focus();
                lblMsg.Text = "โปรดกำหนดปริมาณซอลบิทอล";
                return b;
            }

            if (txt_PR_POLY_PHOSHATE.Text == "")
            {
                b = false;
                txt_PR_POLY_PHOSHATE.Focus();
                lblMsg.Text = "โปรดกำหนดปริมาณโพลีฟอสเฟส";
                return b;
            }
            //===================================================================================

            if (txt_PR_UNIT.Text == "")
            {
                b = false;
                txt_PR_UNIT.Focus();
                lblMsg.Text = "โปรดกำหนดจำนวนกล่อง";
                return b;
            }

            lblMsg.Text = "";
            return b;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool _vallidate = Validate();

            if (_vallidate == false)
            {
                return;
            }
            SaveTempProduct();
            Response.Redirect("ProductionConfirm.aspx");

            //int a = Save();
            //if (a > 0)
            //{
            //    pnlSave.Visible = false;
            //    pnlSuccess.Visible = true;
            //    lblLotSuccess.Text = "LOT : " + a;
            //}
        }

        private void SaveTempProduct()
        {
            var obj = new MPO_PRODUCT();
            // obj.PR_LOT = txt_PR_LOT.Text;
            obj.PR_PRODUCE_DATE = StkDate.TextToDateThToEn(txt_PR_PRODUCE_DATE.Text);
            obj.PR_REV_DATE = StkDate.TextToDateThToEn(txt_PR_REV_DATE.Text);
            obj.PR_CUT_DATE = StkDate.TextToDateThToEn(txt_PR_CUT_DATE.Text);
            obj.PR_LINE = drp_PR_LINE.SelectedValue;
            obj.PR_CONDITION = drp_PR_CONDITION.SelectedValue;
            obj.PR_WEIGHT = Convert.ToDecimal(txt_PR_WEIGHT.Text);
            obj.PR_PACK_DATE = StkDate.TextToDateThToEn(txt_PR_PACK_DATE.Text);
            obj.PR_BOX_TYPE = drp_PR_BOX_TYPE.SelectedValue;
            obj.PR_LINE_COLOR = drp_PR_LINE_COLOR.SelectedValue;
            obj.PR_UNIT = Convert.ToInt32(txt_PR_UNIT.Text);
            obj.FISH_ID = drpFishID.SelectedValue;
            obj.PR_SIZE = drpFishSize.SelectedValue;
            obj.PR_SOURCE = drpSource.SelectedValue;
             if (drpRecreate.SelectedIndex > 0)
            {
                obj.REF = drpRecreate.SelectedValue;
            }

             obj.PR_SUGAR = Convert.ToDecimal(  txt_PR_SUGAR.Text);
             obj.PR_SALT = Convert.ToDecimal(txt_PR_SALT.Text);
             obj.PR_SORBITOL =Convert.ToDecimal( txt_PR_SORBITOL.Text );
             obj.PR_POLY_PHOSHATE =  Convert.ToDecimal( txt_PR_POLY_PHOSHATE.Text);
             obj.PR_FRESHNESS = drpPR_FRESHNESS.SelectedValue;
            obj.CREATE_BY = StkUser.GetCurrentUser();
            obj.REMARK = txt_REMARK.Text;

            TempProduct.TEMP_MPO_PRODUCT = obj;
            //if (drpRecreate.SelectedIndex > 0)
            //{
            //    obj.REF = drpRecreate.SelectedValue;
            //}
            //int a = 0;
            //try
            //{
            //    a = obj.Save();
            //}
            //catch (Exception)
            //{
            //    StkAlert.ShowAjax("จำนวนไม่ถูกต้อง", Page);
            //    return a;
            //}

            //obj = null;
            //return a;
        }

        //NonUSe
        private int Save()
        {
            var obj = new MPO_PRODUCT();
            // obj.PR_LOT = txt_PR_LOT.Text;
            obj.PR_PRODUCE_DATE = StkDate.TextToDateThToEn(txt_PR_PRODUCE_DATE.Text);
            obj.PR_REV_DATE = StkDate.TextToDateThToEn(txt_PR_REV_DATE.Text);
            obj.PR_CUT_DATE = StkDate.TextToDateThToEn(txt_PR_CUT_DATE.Text);
            obj.PR_LINE = drp_PR_LINE.SelectedValue;
            obj.PR_CONDITION = drp_PR_CONDITION.SelectedValue;
            obj.PR_WEIGHT = Convert.ToDecimal(txt_PR_WEIGHT.Text);
            obj.PR_PACK_DATE = StkDate.TextToDateThToEn(txt_PR_PACK_DATE.Text);
            obj.PR_BOX_TYPE = drp_PR_BOX_TYPE.SelectedValue;
            obj.PR_LINE_COLOR = drp_PR_LINE_COLOR.SelectedValue;
            obj.PR_UNIT = Convert.ToInt32(txt_PR_UNIT.Text);
            obj.FISH_ID = drpFishID.SelectedValue;
            obj.PR_SIZE = drpFishSize.SelectedValue;
            obj.PR_SOURCE = drpSource.SelectedValue;

            if (drpRecreate.SelectedIndex > 0)
            {
                obj.REF = drpRecreate.SelectedValue;
            }
            int a = 0;
            try
            {
                a = obj.Save();
            }
            catch (Exception)
            {
                StkAlert.ShowAjax("จำนวนไม่ถูกต้อง", Page);
                return a;
            }

            obj = null;
            return a;
        }

        protected void drpRecreate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpRecreate.SelectedIndex != 0)
            {
                string prlot = drpRecreate.SelectedValue;

                var pr2 = new MPO_PRODUCT();
                pr2 = pr2.Get(prlot);
                //txt_PR_LOT.Text = Stk_TextNull.StringTotext(pr2.PR_LOT.ToString() );
                txt_PR_PRODUCE_DATE.Text = StkDate.DateTotext(Convert.ToDateTime(pr2.PR_PRODUCE_DATE));
                txt_PR_REV_DATE.Text = StkDate.DateTotext(Convert.ToDateTime(pr2.PR_REV_DATE));
                txt_PR_CUT_DATE.Text = StkDate.DateTotext(Convert.ToDateTime(pr2.PR_CUT_DATE));
                //txt_PR_LINE.Text = Stk_TextNull.StringTotext(pr2.PR_LINE);
                drp_PR_LINE.Items.FindByValue(Stk_TextNull.StringTotext(pr2.PR_LINE));

                //txt_PR_CONDITION.Text = Stk_TextNull.StringTotext(pr2.PR_CONDITION);
                drp_PR_CONDITION.Items.FindByValue(Stk_TextNull.StringTotext(pr2.PR_CONDITION));
             
                txt_PR_WEIGHT.Text = Stk_TextNull.StringTotext(pr2.PR_WEIGHT.ToString());
                txt_PR_PACK_DATE.Text = StkDate.DateTotext(Convert.ToDateTime(pr2.PR_PACK_DATE));
                //txt_PR_BOX_TYPE.Text = Stk_TextNull.StringTotext(pr2.PR_BOX_TYPE);
                drp_PR_BOX_TYPE.Items.FindByValue(Stk_TextNull.StringTotext(pr2.PR_BOX_TYPE));
                // txt_PR_LINE_COLOR.Text = Stk_TextNull.StringTotext(pr2.PR_LINE_COLOR);
                drp_PR_LINE_COLOR.Items.FindByValue(Stk_TextNull.StringTotext(pr2.PR_LINE_COLOR));
                
                txt_PR_UNIT.Text = Stk_TextNull.StringTotext(pr2.PR_UNIT.ToString());
                //txt_FISH_ID.Text = Stk_TextNull.StringTotext(pr2.FISH_ID);
                //txt_PR_SIZE.Text = Stk_TextNull.StringTotext(pr2.PR_SIZE);
                //txt_PR_SOURCE.Text = Stk_TextNull.StringTotext(pr2.PR_SOURCE);
                lblnumItem.Text = pr2.PR_UNIT.ToString();

                try
                {
                    drpFishID.SelectedValue = pr2.FISH_ID;
                }
                catch (Exception)
                {
                    drpFishID.SelectedIndex = 0;
                }

                try
                {
                    drpFishSize.SelectedValue = pr2.PR_SIZE;
                }
                catch (Exception)
                {
                    drpFishSize.SelectedIndex = 0;
                }

                try
                {
                    drpSource.SelectedValue = pr2.PR_SOURCE;
                }
                catch (Exception)
                {
                    drpSource.SelectedIndex = 0;
                }

                 try
                {
                    drpPR_FRESHNESS.SelectedValue = pr2.PR_FRESHNESS;
                }
                catch (Exception)
                {
                    drpPR_FRESHNESS.SelectedIndex = 0;
                }


                      try
                {
                    drp_PR_LINE.SelectedValue = pr2.PR_LINE;
                }
                catch (Exception)
                {
                    drp_PR_LINE.SelectedIndex = 0;
                }

                  try
                {
                    drp_PR_BOX_TYPE.SelectedValue = pr2.PR_BOX_TYPE;
                }
                catch (Exception)
                {
                    drp_PR_BOX_TYPE.SelectedIndex = 0;
                }
                     try
                {
                    drp_PR_LINE_COLOR.SelectedValue = pr2.PR_LINE_COLOR;
                }
                catch (Exception)
                {
                    drp_PR_LINE_COLOR.SelectedIndex = 0;
                }

                      try
                {
                    drp_PR_CONDITION.SelectedValue = pr2.PR_CONDITION;
                }
                catch (Exception)
                {
                    drp_PR_CONDITION.SelectedIndex = 0;
                }

                txt_PR_SUGAR.Text = pr2.PR_SUGAR.ToString();


                txt_PR_SALT.Text = pr2.PR_SALT.ToString();

                txt_PR_SORBITOL.Text = pr2.PR_SORBITOL.ToString();

                txt_PR_POLY_PHOSHATE.Text = pr2.PR_POLY_PHOSHATE.ToString();


            }
            else
            {
                clearData();
            }
        }

        private void clearData()
        {
            txt_PR_PRODUCE_DATE.Text = "";
            txt_PR_REV_DATE.Text = "";
            txt_PR_CUT_DATE.Text = "";
            drp_PR_LINE.SelectedIndex = 0;
            //txt_PR_CONDITION.Text = "";
            drp_PR_CONDITION.SelectedIndex = 0;

            txt_PR_WEIGHT.Text = "";
            txt_PR_PACK_DATE.Text = "";
            //txt_PR_BOX_TYPE.Text = "";
            drp_PR_BOX_TYPE.SelectedIndex = 0;
            //txt_PR_LINE_COLOR.Text = "";
            drp_PR_LINE_COLOR.SelectedIndex = 0;
            txt_PR_UNIT.Text = "";
            drpFishID.SelectedIndex = 0;
            drpFishSize.SelectedIndex = 0;
            drpSource.SelectedIndex = 0;
        }

        protected void drpFishID_SelectedIndexChanged(object sender, EventArgs e)
        {  
         // StkDropDown.SetDropFishSize(drpFishSize,drpFishID.SelectedValue);
        }
    }
}