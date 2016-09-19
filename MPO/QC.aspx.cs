using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using MPO.Code.Bu.GEN;
using MPO.Code.Common;
using MPO.Code.TempData;
using Stk.Common;

namespace MPO
{
    public partial class QC : Page
    {
        private int LotIndexGrid = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            dataBind();

            if (!Page.IsPostBack)
            {
                SetDrop();
                TableOrder.OrderTable = null;
            }
        }

        private void SetDrop()
        {
            StkDropDown.SetdrpQc(txt_Qc);

        }


        private void dataBind()
        {
            var po = new MPO_PRODUCT();

            GridView1.DataSource = po.GetForQc();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = GridView1.SelectedRow;

            // Display the first name from the selected row.
            // In this example, the third column (index 2) contains
            // the first name.
            //MessageLabel.Text = "You selected " + row.Cells[2].Text + ".";
            string lot = row.Cells[LotIndexGrid].Text;
            lblLot.Text = " " + lot;
            txtNumber.Text = row.Cells[15].Text;
            showDetail(true);

            clearData();

            BindDataConfirm(lot);
            
            
            StateDetail();
            LockButtonForApprove(true);
        }


        private void BindDataConfirm(string lot)
        {
            var pr2 = new MPO_PRODUCT();

            pr2 = pr2.Get(lot);

            if (pr2 == null)
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

            //txt_Qc.Text = StkUser.GetCurrentUser(); 
        // txt_Qc.se

        }


        private void StateMaster()
        {
            GridView1.Visible = true;
            pnlDetail.Visible = false;
        }


        private void StateDetail()
        {
            btnSave.Visible = true;
            Button1.Visible = false;

            GridView1.Visible = false;
            pnlDetail.Visible = true;
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
        }


        private void clearData()
        {
            lbl_MOISTURE.Text = "";
            lbl_PH.Text = "";
            lbl_JELLY_ST.Text = "";
            lbl_COLOR.Text = "";
            lbl_ODOUR.Text = "";
            lbl_SPOT.Text = "";
            lbl_GRADE.Text = "";
            lbl_STOCK.Text = "";
            lbl_REMARK.Text = "";
            lbl_DARN.Text = "";
            lbl_KUBOMI.Text = "";
        }

        private bool Validate()
        {
            bool b = true;

            if (lbl_MOISTURE.Text == "")
            {
                b = false;
                lbl_MOISTURE.Focus();
                lblMsg.Text = "โปรดระบุ Moisture ";
                return b;
            }
            if (lbl_PH.Text == "")
            {
                b = false;
                lbl_PH.Focus();
                lblMsg.Text = "โปรดระบุ PH";
                return b;
            }

            if (lbl_DARN.Text == "")
            {
                b = false;
                lbl_DARN.Focus();
                lblMsg.Text = "โปรดระบุ Darn";
                return b;
            }

            if (lbl_KUBOMI.Text == "")
            {
                b = false;
                lbl_KUBOMI.Focus();
                lblMsg.Text = "โปรดระบุ Kubomi";
                return b;
            }


            //if (lbl_JELLY_ST.Text == "")
            //{
            //    b = false;
            //    lbl_JELLY_ST.Focus();
            //    lblMsg.Text = "โปรดระบุ Jelly St ";
            //    return b;
            //}
            if (lbl_COLOR.Text == "")
            {
                b = false;
                lbl_COLOR.Focus();
                lblMsg.Text = "โปรดระบุ Color ";
                return b;
            }
            if (lbl_ODOUR.Text == "")
            {
                b = false;
                lbl_ODOUR.Focus();
                lblMsg.Text = "โปรดระบุ Odour";
                return b;
            }
            if (lbl_SPOT.Text == "")
            {
                b = false;
                lbl_SPOT.Focus();
                lblMsg.Text = "โปรดระบุ SPOT";
                return b;
            }
            //if (lbl_GRADE.Text == "")
            //{
            //    b = false;
            //    lbl_GRADE.Focus();
            //    lblMsg.Text = "โปรดระบุ GRADE";
            //    return b;
            //}
            if (lbl_STOCK.Text == "")
            {
                b = false;
                lbl_STOCK.Focus();
                lblMsg.Text = "โปรดระบุ STOCK";
                return b;
            }

      

            if (txt_Qc.SelectedIndex == 0)
            {
                b = false;
                txt_Qc.Focus();
                lblMsg.Text = "โปรดระบุผู้ทำการ QC";
                return b;
            }

            if (txt_QcDate.Text == "")
            {
                b = false;
                txt_QcDate.Focus();
                lblMsg.Text = "โปรดระบุวันที่ในการ QC";
                return b;
            }
           if(StkValidates.IsDate(txt_QcDate.Text.Trim() )==false)
            {

                b = false;
                txt_QcDate.Focus();
                lblMsg.Text = "โปรดระบุวันที่ในการ QC ในรูปแบบวันที่";
                return b;
            }


            lblMsg.Text = "";
            return b;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Validate() == false)
            {
                return;
            }


            var Bar = new GEN_MPO_LOT();
            Bar.ReporduceGen();

            var obj = new MPO_STOCK();

            // obj.STK_ID = lbl_STK_ID.Text;
            obj.PR_LOT = Convert.ToInt32(lblLot.Text);
            obj.MOISTURE = Convert.ToDecimal(lbl_MOISTURE.Text);
            obj.PH = Convert.ToDecimal(lbl_PH.Text);
            obj.JELLY_ST = Convert.ToDecimal(lbl_JELLY_ST.Text);
            obj.COLOR = Convert.ToDecimal(lbl_COLOR.Text);
            obj.ODOUR = Convert.ToDecimal(lbl_ODOUR.Text);
            obj.SPOT = Convert.ToDecimal(lbl_SPOT.Text);
            obj.GRADE = lbl_GRADE.Text;
            obj.STOCK = lbl_STOCK.Text;
            obj.REMARK = lbl_REMARK.Text;
            obj.DARN =Convert.ToDecimal( lbl_DARN.Text);
            obj.KUBOMI = Convert.ToDecimal(lbl_KUBOMI.Text);
            obj.ITEMS = Convert.ToInt32(txtNumber.Text);
            obj.QC_BY = txt_Qc.SelectedValue;

            obj.QC_DATE = StkDate.TextToDate(txt_QcDate.Text);
            obj.QCSAVE();
           

            Bar.Next();

            dataBind();
            pnlFinish.Visible = true; 
            showDetail(false);

            // lblMgs.Text= obj.STK_ID.ToString();
            // PrintBarCode_R2.aspx?Q=<%#EncryptQueryString(Eval("LOT_NO_R2_CODE"))
            var stkQuery = new Stk_QueryString();
            string qstring = "?Q=" + stkQuery.EncryptQueryString(obj.STK_ID.ToString());
            Response.Redirect("PrintBarCode_R2.aspx" + qstring, false);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var obj = new MPO_PRODUCT();
            obj.QcReject(lblLot.Text);
            dataBind();
            showDetail(false);
        }


        private void showDetail(bool e)
        {
            pnlDetail.Visible = e;
        }


        protected void btnClose_Click1(object sender, EventArgs e)
        {
            StateMaster();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate() == false)
            {
                return;
            }


            lbl_JELLY_ST.Text = CalJelly(lbl_DARN.Text, lbl_KUBOMI.Text); //Setp1
            lbl_GRADE.Text = CalGrade(); //Step 2
            //DARN, string Kobomi
            //decimal DARN = Convert.ToDecimal(lbl_DARN.Text);
            //decimal Kobomi = Convert.ToDecimal(lbl_KUBOMI.Text);
          
            btnSave.Visible = false;
            Button1.Visible = true;
            LockButtonForApprove(false);
        }

     void LockButtonForApprove(bool x)
     {
         lbl_MOISTURE.Enabled = x;

         lbl_PH.Enabled = x;

         lbl_DARN.Enabled = x;

         lbl_KUBOMI.Enabled = x;

        // lbl_JELLY_ST.Enabled = x;


         lbl_COLOR.Enabled = x;

         lbl_ODOUR.Enabled = x;

         lbl_SPOT.Enabled = x;

         lbl_STOCK.Enabled = x;

         lbl_REMARK.Enabled = x;

         txtNumber.Enabled = x;
     }

        private void AddCssLock(TextBox tx)
        {
            tx.CssClass = "LockControl";
        }



        private string  CalGrade()
        {
            GRADE grade=new GRADE();
           MPO_STOCK m=new MPO_STOCK();
            m.COLOR =Convert.ToDecimal(lbl_COLOR.Text);
            m.DARN = Convert.ToDecimal(lbl_DARN.Text);
            m.KUBOMI = Convert.ToDecimal(lbl_KUBOMI.Text);
            m.SPOT = Convert.ToDecimal(lbl_SPOT.Text);
            m.JELLY_ST = Convert.ToDecimal(lbl_JELLY_ST.Text);
            m.PH = Convert.ToDecimal(lbl_PH.Text);
            grade.StockQC = m;
            return grade.GetGRADE(lbl_FISH_ID.Text);
        }

        private string CalJelly(string DARN, string Kobomi)
        {
            decimal _DARN = Convert.ToDecimal(DARN);
            decimal _Kobomi = Convert.ToDecimal(Kobomi);

            decimal result = _DARN*_Kobomi;
            return result.ToString();
        }
//สูตร
//(5) Jelly St.(g*cm) = (3) DARN * (4) Kobomi

//(9) Grade คำนวณอัตโนมัติ ตามไฟล์ excel



    }
}