using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using MPO.Code.Common;
using MPO.Code.TempData;
using Stk.Common;

namespace MPO
{
    public partial class StoreCheckIn : Page
    {
        private int PRLOTInsex = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }


        private void Bind()
        {
            var a = new MPO_PRODUCT();
            GridView1.DataSource = a.GetAll();
            GridView1.DataBind();
        }


        public string GetItems(object PR_STATUS, object PR_LOT, object PR_UNIT, object ITEMS)
        {
            string _PR_STATUS = PR_STATUS.ToString();
            string _PR_LOT = PR_LOT.ToString();
            string _PR_UNIT = PR_UNIT.ToString();
            if (_PR_STATUS == "P")
                return _PR_UNIT;


            return ITEMS.ToString();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            //var btnDelete = sender as LinkButton;
            //if (btnDelete != null)
            //{
            //    var row = (GridViewRow) btnDelete.NamingContainer;

            //    string prlot = GridView1.Rows[row.RowIndex].Cells[PRLOTInsex].Text;

            //    //row.RowIndex 
            //    var product = new MPO_PRODUCT();
            //    product.CalCelProductChekIn(prlot);
            //}

            //Bind();

            //Fix Confirm
            string PR_LOT = VerData.PR_LOT_VerData;

            if (PR_LOT != null)
            {
                var product = new MPO_PRODUCT();
                product.CalCelProductChekIn(PR_LOT);
            }

            Bind();
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = GridView1.SelectedRow;

            // Display the first name from the selected row.
            // In this example, the third column (index 2) contains
            // the first name.
            //MessageLabel.Text = "You selected " + row.Cells[2].Text + ".";
            pnlDetail.Visible = true;
            lblLot.Text = " " + row.Cells[PRLOTInsex].Text;
            SetDrp();
            OperState();

            //Clear iteom location
            GridView2.Visible=false;

            DisplayProductionformation(row.Cells[PRLOTInsex].Text);
        }


        private void DisplayProductionformation(string lot)
        {
            var pr2 = new MPO_PRODUCT();
            pr2 = pr2.Get(lot);
            lbl_PR_LOT.Text = Stk_TextNull.StringTotext(pr2.PR_LOT.ToString());
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
            lbl_Dong_DATE.Text = Stk_TextNull.StringTotext( pr2.Dong_DATE.ToString());
            
            lbl_REF.Text = Stk_TextNull.StringTotext(pr2.REF);
            lbl_CREATE_BY.Text = Stk_TextNull.StringTotext(pr2.CREATE_BY);
            //lbl_CHECKIN_BY.Text = Stk_TextNull.StringTotext(pr2.CHECKIN_BY);
            //lbl_L_UPDATE.Text = Stk_TextNull.StringTotext(StkDate.DateTotext(pr2.L_UPDATE));
            //lbl_ROOM_ID.Text = Stk_TextNull.StringTotext(pr2.ROOM_ID);
            //lbl_LOCATION.Text = Stk_TextNull.StringTotext(pr2.LOCATION);
            //lbl_PR_STATUS.Text = Stk_TextNull.StringTotext(pr2.PR_STATUS);
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
        }

        private void SetDrp()
        {
            StkDropDown.SetDropLocation(drpLocation);

            StkDropDown.SetDropRoom(drpRoom);
        }



        bool validateKeepProduct()
        {

            if (drpLocation.SelectedIndex == 0)
            {
                StkAlert.ShowAjax("กรุณาระบุสถานที่",Button1);

                return false;
            }

            if (drpRoom.SelectedIndex == 0)
            {
                StkAlert.ShowAjax("กรุณาระบุห้อง", Button1);
                return false;
            }

            return true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            if (validateKeepProduct()==false)
            {
                return;
            }

            var a = new MPO_PRODUCT();
            a.AssignPrestock(lblLot.Text, drpLocation.SelectedValue, drpRoom.SelectedValue);
            Bind();
            Label2.Text = "นำเข้าเรียบร้อยแล้ว";
            CompletState();
        }


        private void CompletState()
        {
            pnlDetail.Visible = false;
            pnlMessage.Visible = true;
            GridView1.Visible = true;
        }

        private void OperState()
        {
            pnlDetail.Visible = true;
            pnlMessage.Visible = false;
            GridView1.Visible = false;
        }

        protected void drpLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView2.Visible = true;
            var s = new MPO_PRODUCT();
            string locationId = drpLocation.SelectedValue;
            GridView2.DataSource = s.GetStockByLocation(locationId);
            GridView2.DataBind();

          
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string _PR_STATUS = PR_STATUS.ToString();
                //string _PR_LOT = PR_LOT.ToString();
                //string _PR_UNIT = PR_UNIT.ToString();
                //if (item == "0")
                //{
                //    e.Row.Visible = false;
                //}
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Label2.Text = "";
            CompletState();
        }
    }
}