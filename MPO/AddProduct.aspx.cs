using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using MPO.Code.Common;
using MPO.Code.TempData;
using Stk.Common;

namespace MPO
{
    public partial class AddProduct : Page
    {
        private int iTemlColumn = 17;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Setdrp();


                //if (Request.QueryString["Q"] != null)
                //{
                //    string OR_ID = Stk_QueryString.DecryptQuery("Q");

                //    if (OR_ID != null)
                //    {
                //       // BindOldData(OR_ID);
                //    }
                //}
            }
        }

        private void Setdrp()
        {
            StkDropDown.SetDropSource(drpSource);

            StkDropDown.SetDropFish(drpFishID);

            //  StkDropDown.SetDropFishSize(drpFishSize);

            StkDropDown.SetDropLINE_COLOR(DropPR_LINE_COLOR);

            StkDropDown.SetdrpBOX_TYPE(drpPR_BOX_TYPE);

            StkDropDown.SetdrpCondition(drpPR_CONDITION);

                 StkDropDown.SetDropFishSize( drpFishSize);
             
            //var customer = new MPO_CUSTOMER_R2();
            //drpCustomer.DataSource = customer.GetSource();
            //drpCustomer.DataTextField = MPO_CUSTOMER_R2.DataText;
            //drpCustomer.DataValueField = MPO_CUSTOMER_R2.DataValue;
            //drpCustomer.DataBind();

            //var lt = new ListItem("กรุณาเลือกลูกค้า", "0");
            //drpCustomer.Items.Insert(0, lt);
        }


        private void Reset()
        {
            drpSource.SelectedIndex = 0;

            drpFishID.SelectedIndex = 0;

            drpFishSize.SelectedIndex = 0;

            DropPR_LINE_COLOR.SelectedIndex = 0;

            drpPR_BOX_TYPE.SelectedIndex = 0;

            drpPR_CONDITION.SelectedIndex = 0;
            txtGrade.Text = "";

            txtSpot1.Text = "";
            txtSpot2.Text = "";

            txtPH1.Text = "";
            txtPH2.Text = "";

            txtOdour1.Text = "";
            txtOdour2.Text = "";

            txtMoisture1.Text = "";
            txtMoisture2.Text = "";


            txtKubomi1.Text = "";

            txtKubomi2.Text = "";

            txtJellySt1.Text = "";
            txtJellySt2.Text = "";

            txtDarn1.Text = "";
            txtDarn2.Text = "";

            txtCOLOR1.Text = "";
            txtCOLOR2.Text = "";
            //drpCustomer.SelectedIndex = 0;

            txtPR_PACK_DATE.Text = "";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;

            // Display the first name from the selected row.
            // In this example, the third column (index 2) contains
            // the first name.
            //MessageLabel.Text = "You selected " + row.Cells[2].Text + ".";

            //TableOrder.AddITem(row.Cells[1].Text, row.Cells[2].Text, "0", "0", "11/11/2010", "ShipmentNo", "ContainerNo",
            //    "TruckNo", "Stamp",
            //    "Status"
            //    );
            // SaveOder();
            try
            {
                string CurDate = StkDate.DateTotext(DateTime.Now);
                TableOrder.AddITem(row.Cells[1].Text, row.Cells[2].Text, row.Cells[15].Text, "-", CurDate, "-", "-",
                    "-", "-",
                    "-", "0"
                    );

                //  StateSave(true);
            }
            catch (Exception)
            {
                StkAlert.ShowAjax("รายการสินค้าซ้ำ", Page);
                return;
            }


            //  Bind();
            //grdSale.DataSource = TableOrder.OrderTable;
            //grdSale.DataBind();
            //   btnSend.Visible = false;

            StkClosePopUp.CloseBindDataAjax(btnSearch);
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var gvQC = (GridView) e.Row.FindControl("gvQC");

                string STK_ID = GridView1.DataKeys[e.Row.RowIndex].Values[0].ToString();

                //Get QC
                //Sub Detail
                var mpo = new MPO_STOCK();
                mpo.STK_ID = Convert.ToInt16(STK_ID);
                gvQC.DataSource = mpo.Search();
                gvQC.DataBind();
            }
        }

        private void BinbStock()
        {
            var obj = new MPO_STOCK();


            if ((txtMoisture1.Text != "") && (txtMoisture2.Text != ""))
            {
                obj.MOISTURE_Filter = txtMoisture1.Text + "|" + txtMoisture2.Text;
            }


            if ((txtPH1.Text != "") && (txtPH2.Text != ""))
            {
                obj.PH_Filter = txtPH1.Text + "|" + txtPH2.Text;
            }

            if ((txtJellySt1.Text != "") && (txtJellySt2.Text != ""))
            {
                obj.JellySt_Filter = txtJellySt1.Text + "|" + txtJellySt2.Text;
            }


            if ((txtCOLOR1.Text != "") && (txtCOLOR2.Text != ""))
            {
                obj.COLOR_Filter = txtCOLOR1.Text + "|" + txtCOLOR2.Text;
            }


            if ((txtOdour1.Text != "") && (txtOdour2.Text != ""))
            {
                obj.Odour_Filter = txtOdour1.Text + "|" + txtOdour2.Text;
            }


            if ((txtSpot1.Text != "") && (txtSpot2.Text != ""))
            {
                obj.Spot_Filter = txtSpot1.Text + "|" + txtSpot2.Text;
            }


            if ((txtDarn1.Text != "") && (txtDarn2.Text != ""))
            {
                obj.Darn_Filter = txtDarn1.Text + "|" + txtDarn2.Text;
            }


            if ((txtKubomi1.Text != "") && (txtKubomi2.Text != ""))
            {
                obj.Kubomi_Filter = txtKubomi1.Text + "|" + txtKubomi2.Text;
            }

            if (txtGrade.Text != "")
            {
                obj.GRADE = txtGrade.Text;

            }
            //========================================================================================================
            var po = new MPO_PRODUCT();

            if (drpPR_CONDITION.SelectedIndex > 0)
            {
                po.PR_CONDITION = drpPR_CONDITION.SelectedValue;
            }
            //if (drpPR_WEIGHT.SelectedIndex > 0)
            //{
            //    po.PR_WEIGHT = drpPR_WEIGHT.SelectedValue;
            //}
            if (txtPR_PACK_DATE.Text != "")
            {
                po.PR_PACK_DATE = StkDate.TextToDateThToEn(txtPR_PACK_DATE.Text);
            }
            if (drpPR_BOX_TYPE.SelectedIndex > 0)
            {
                po.PR_BOX_TYPE = drpPR_BOX_TYPE.SelectedValue;
            }
            if (DropPR_LINE_COLOR.SelectedIndex > 0)
            {
                po.PR_LINE_COLOR = DropPR_LINE_COLOR.SelectedValue;
            }
            //if (drpPR_UNIT.SelectedIndex > 0)
            //{
            //    po.PR_UNIT = drpPR_UNIT.SelectedValue;
            //}
            if (drpFishID.SelectedIndex > 0)
            {
                po.FISH_ID = drpFishID.SelectedValue;
            }
            if (drpFishSize.SelectedIndex > 0)
            {
                po.PR_SIZE = drpFishSize.SelectedValue;
            }
            if (drpSource.SelectedIndex > 0)
            {
                po.PR_SOURCE = drpSource.SelectedValue;
            }
          
               

            //========================================================================================================

            obj._MPO_PRODUCT = po;

            GridView1.DataSource = obj.Search();
            GridView1.DataBind();
        }

        public string AvaliableItem(object val)
        {
            string STK_ID = val.ToString();
            var lItems = new ITEMS();
            int av = lItems.Avaliableitem(STK_ID);
            return av.ToString();
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //StateSave(false);
            BinbStock();
            //   clearORder();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void drpFishID_SelectedIndexChanged(object sender, EventArgs e)
        {
            StkDropDown.SetDropFishSize(drpFishSize, drpFishID.SelectedValue);
        }
    }
}