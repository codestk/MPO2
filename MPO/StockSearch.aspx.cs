using System;
using System.Drawing;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using MPO.Code.Common;
using Stk.Common;
using StkLib.Web.Controls.StkGridView;

namespace MPO
{
    public partial class StockSearch : StkGvEvent
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridGroupSum();
            if (!Page.IsPostBack)
            {
                Setdrp();
            }
        }


        private void GridGroupSum()
        {
            var helper = new GridViewHelper(GridView1);
            // helper.RegisterSummary("ITEMS", SummaryOperation.Sum);
            // helper.RegisterSummary("TOTAL", SummaryOperation.Sum);

            if (rdFisid.Checked)
            {
                helper.RegisterGroup("FISH_ID", true, true);
                helper.RegisterSummary("ITEMS", SummaryOperation.Sum, "FISH_ID");
            }

            else if (rdPosition.Checked)
            {
                helper.RegisterGroup("LOCATION", true, true);
                helper.RegisterSummary("ITEMS", SummaryOperation.Sum, "LOCATION");
            }
            else if (rdSource.Checked)
            {
                helper.RegisterGroup("PR_SOURCE", true, true);
                helper.RegisterSummary("ITEMS", SummaryOperation.Sum, "PR_SOURCE");
            }
            else
            {
                helper.RegisterGroup("BARCODE_STOCK", true, true);
                }

            helper.GroupHeader += helper_GroupHeader;
        }

        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == null) return;
            row.BackColor = Color.FromArgb(236, 236, 236);
            row.Cells[0].Font.Bold = true;
            row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
            if (groupName == "FISH_ID")
            {
                row.Cells[0].Text = "รหัสปลา : " + row.Cells[0].Text;
            }
            else if (groupName == "PR_SOURCE")
            {
                row.Cells[0].Text = "แหล่งปลา : " + row.Cells[0].Text;
            }
            else if (groupName == "LOCATION")
            {
                row.Cells[0].Text = "ตำแหน่ง : " + row.Cells[0].Text;
            }
            else
            {
                row.Cells[0].Text = "BarCode : " + row.Cells[0].Text;
            }
        }

        private void Setdrp()
        {
            StkDropDown.SetDropSource(drpSource);

            StkDropDown.SetDropFish(drpFishID);

            StkDropDown.SetDropLocation(drpLocation);

            StkDropDown.SetDropFishSize(drpFishSize);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }


        private void Search()
        {
            var obj = new MPO_STOCK();


            //if (drpMoisture.SelectedIndex > 0)
            //{
            //    obj.MOISTURE = Convert.ToDecimal(  drpMoisture.SelectedValue);
            //}
            //if (drpPH.SelectedIndex > 0)
            //{
            //    obj.PH =  Convert.ToDecimal(  drpPH.SelectedValue);
            //}
            //if (drpJellySt.SelectedIndex > 0)
            //{
            //    obj.JELLY_ST =  Convert.ToDecimal(  drpJellySt.SelectedValue);
            //}
            //if (drpCOLOR.SelectedIndex > 0)
            //{
            //    obj.COLOR =  Convert.ToDecimal(  drpCOLOR.SelectedValue);
            //}
            //if (drpOdour.SelectedIndex > 0)
            //{
            //    obj.ODOUR = Convert.ToDecimal(   drpOdour.SelectedValue);
            //}
            //if (drpSpot.SelectedIndex > 0)
            //{
            //    obj.SPOT =  Convert.ToDecimal(  drpSpot.SelectedValue);
            //}
            //if (drpGRADE.SelectedIndex > 0)
            //{
            //    obj.GRADE = drpGRADE.SelectedValue;
            //}
            //if (drpSTOCK.SelectedIndex > 0)
            //{
            //    obj.STOCK = drpSTOCK.SelectedValue;
            //}

            //if (drpDarn.SelectedIndex > 0)
            //{
            //    obj.DARN =  Convert.ToDecimal(  drpDarn.SelectedValue);
            //}
            //if (drpKubomi.SelectedIndex > 0)
            //{
            //    obj.KUBOMI = Convert.ToDecimal(   drpKubomi.SelectedValue);
            //}
            //if (drpITEMS.SelectedIndex > 0)
            //{
            //    obj.ITEMS = drpITEMS.SelectedValue;
            //}
            //if (drpBARCODE_STOCK.SelectedIndex > 0)
            //{
            //    obj.BARCODE_STOCK = drpBARCODE_STOCK.SelectedValue;
            //}
            //========================================================================================================
            var po = new MPO_PRODUCT();
            //if (drpPR_LOT.SelectedIndex > 0)
            //{
            //    po.PR_LOT = drpPR_LOT.SelectedValue;
            //}
            //if (drpPR_PRODUCE_DATE.SelectedIndex > 0)
            //{
            //    po.PR_PRODUCE_DATE = drpPR_PRODUCE_DATE.SelectedValue;
            //}
            //if (drpPR_REV_DATE.SelectedIndex > 0)
            //{
            //    po.PR_REV_DATE = drpPR_REV_DATE.SelectedValue;
            //}
            //if (drpPR_CUT_DATE.SelectedIndex > 0)
            //{
            //    po.PR_CUT_DATE = drpPR_CUT_DATE.SelectedValue;
            //}
            //if (drpPR_LINE.SelectedIndex > 0)
            //{
            //    po.PR_LINE = drpPR_LINE.SelectedValue;
            //}
            //if (drpPR_CONDITION.SelectedIndex > 0)
            //{
            //    po.PR_CONDITION = drpPR_CONDITION.SelectedValue;
            //}
            //if (drpPR_WEIGHT.SelectedIndex > 0)
            //{
            //    po.PR_WEIGHT = drpPR_WEIGHT.SelectedValue;
            //}
            //if (txtPR_PACK_DATE.Text != "")
            //{
            //    po.PR_PACK_DATE = StkDate.TextToDateThToEn(txtPR_PACK_DATE.Text);
            //}

            //if (DropPR_LINE_COLOR.SelectedIndex > 0)
            //{
            //    po.PR_LINE_COLOR = DropPR_LINE_COLOR.SelectedValue;
            //}
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
            if (drpLocation.SelectedIndex > 0)
            {
                po.LOCATION = drpLocation.SelectedValue;
            }
            //if (drpPR_STATUS.SelectedIndex > 0)
            //{
            //    po.PR_STATUS = drpPR_STATUS.SelectedValue;
            //}
            //if (drpBARCODE.SelectedIndex > 0)
            //{
            //    po.BARCODE = drpBARCODE.SelectedValue;
            //}
            //if (drpREF.SelectedIndex > 0)
            //{
            //    po.REF = drpREF.SelectedValue;
            //}
            //if (drpCREATE_BY.SelectedIndex > 0)
            //{
            //    po.CREATE_BY = drpCREATE_BY.SelectedValue;
            //}
            //if (drpCHECKIN_BY.SelectedIndex > 0)
            //{
            //    po.CHECKIN_BY = drpCHECKIN_BY.SelectedValue;
            //}

            //========================================================================================================

            obj._MPO_PRODUCT = po;

            //GridView1.DataSource = obj.SearchAllCondition() ;
            GridView1.DataSource = obj.Search();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridViewRow row = GridView1.SelectedRow;


            //// string ORDE_ID  =  GridView1.DataKeys[GridView1.SelectedRow.DataItemIndex].ToString();
            ////string orid = row.Cells[1].Text;
            //string STK_ID = GridView1.DataKeys[row.DataItemIndex].Value.ToString();

            //Response.Redirect("PrintBarCode_R2.aspx?Q=" + Stk_QueryString.EncryptQuery(STK_ID));
        }


        protected void drpFishID_SelectedIndexChanged(object sender, EventArgs e)
        {
            StkDropDown.SetDropFishSize(drpFishSize, drpFishID.SelectedValue);
        }
    }
}