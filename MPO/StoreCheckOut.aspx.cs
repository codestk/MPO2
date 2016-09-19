using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using MPO.Code.Common;
using Stk.Common;

namespace MPO
{
    public partial class StoreCheckOut : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            databind();
        }

        private void databind()
        {
            GridView1.DataSource = (new MPO_ORDERS()).GetAllForCheckOut();
            GridView1.DataBind();
        }

        private void MasterState()
        {
            GridView1.Visible = true;
            GridView2.Visible = false;
            pnlDetail.Visible = false;
            clearText();
        }

        private void SubMaster()
        {
            GridView1.Visible = false;
            GridView2.Visible = true;
        }

        private void DetailState()
        {
            pnlDetail.Visible = false;
            pnlDetail.Visible = true;
        }




        public string GetProductName(object prlot)
        {
            var mpo = new MPO_PRODUCT();

            return mpo.GetProductName(prlot.ToString());
        }

        private void clearText()
        {
            lbl_ORDE_ID.Text = "";
            lblLocation.Text = "";
            txt_OPENING_TIME.Text = "";
            txt_CLOSING_TIME.Text = "";
            txt_TEMP_BEFORE.Text = "";
            txt_TEMP_AFTER.Text = "";
            txtBarCode.Text = "";
        }
 
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;


            // string ORDE_ID  =  GridView1.DataKeys[GridView1.SelectedRow.DataItemIndex].ToString();
            //string orid = row.Cells[1].Text;
            string orid = GridView1.DataKeys[row.DataItemIndex].Value.ToString();


            //string  orid=   row.Cells[1].Text;
            GridView2.DataSource = (new MPO_ODERDETAILS()).GetORder(orid);
            GridView2.DataBind();
          //  MasterState();
            SubMaster();



        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindFormAndOrderDetial();
        }

        void bindFormAndOrderDetial()
        {
            if (GridView1.Rows.Count == 0)
            {
                GridView2.DataBind();
                return;
              
            }


            GridViewRow row = GridView2.SelectedRow;
            // string ORDE_ID  =  GridView1.DataKeys[GridView1.SelectedRow.DataItemIndex].ToString();
            //string orid = row.Cells[1].Text;
            string ORDE_ID = GridView2.DataKeys[row.DataItemIndex].Value.ToString();

            var ppOderdetails = new MPO_ODERDETAILS();
            ppOderdetails = ppOderdetails.Get(ORDE_ID);

            lbl_ORDE_ID.Text = ORDE_ID;
            string PR_LOT = ppOderdetails.PR_LOT.ToString();
            string STK_ID = ppOderdetails.STK_ID.ToString();

          
            
            
            string OR_ID = ppOderdetails.OR_ID.ToString();
            //string  orid=   row.Cells[1].Text;
            GridView2.DataSource = (new MPO_ODERDETAILS()).GetORder(OR_ID);
            GridView2.DataBind();


            var product = new MPO_PRODUCT();
            product = product.Get(PR_LOT);
            lblLocation.Text = product.LOCATION;

            lblRoom.Text = product.ROOM_ID;
            lbl_STK_ID.Text = STK_ID;
            lbl_ORDE_ID.Text = ORDE_ID;

            lbl_ITEMS.Text = ppOderdetails.ITEMS.ToString();
            lbl_prname.Text = GetProductName(PR_LOT);
            lbl_OR_ID.Text = OR_ID;

            var stock = new MPO_STOCK();

            stock = stock.GetStockItems(STK_ID);
            lbl_code.Text = stock.BARCODE_STOCK;
            DetailState();

        }
      
        private bool Validate()
        {
            bool b = true;

            if (txt_CheckOut.Text == "")
            {
                b = false;
                txt_CheckOut.Focus();
                lblMsg.Text = "โปรดระบุ Check Out";
                return b;

            }
            if (StkValidates.IsDate(txt_CheckOut.Text) == false)
            {
                b = false;
                txt_CheckOut.Focus();
                lblMsg.Text = "รูปแบบวันที่ไม่ถูกต้อง";
                return b;
            }



            if (txt_OPENING_TIME.Text == "")
            {
                b = false;
                txt_OPENING_TIME.Focus();
                lblMsg.Text = "โปรดระบุ OPENING_TIME";
                return b;
            }
            if (txt_CLOSING_TIME.Text == "")
            {
                b = false;
                txt_CLOSING_TIME.Focus();
                lblMsg.Text = "โปรดระบุ CLOSING_TIME";
                return b;
            }
            if (txt_TEMP_BEFORE.Text == "")
            {
                b = false;
                txt_TEMP_BEFORE.Focus();
                lblMsg.Text = "โปรดระบุ TEMP_BEFORE";
                return b;
            }
            if (txt_TEMP_AFTER.Text == "")
            {
                b = false;
                txt_TEMP_AFTER.Focus();
                lblMsg.Text = "โปรดระบุ TEMP_AFTER";
                return b;
            }
            lblMsg.Text = "";
            return b;
        }


        protected void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            //Cut 
            //

            if (Validate() == false)
            {
               return;

            }

            var checkOut = new CheckOut();

            var orderdOderdetails = new MPO_ODERDETAILS();

            orderdOderdetails.STK_ID = Convert.ToInt32(lbl_STK_ID.Text);
            orderdOderdetails.OR_ID = Convert.ToInt32(lbl_OR_ID.Text);
            orderdOderdetails.ORDE_ID = Convert.ToInt32(lbl_ORDE_ID.Text);
            orderdOderdetails.ITEMS = Convert.ToInt32(lbl_ITEMS.Text);
            orderdOderdetails.CHECKOUT_DATE  = StkDate.TextToDateThToEn(txt_CheckOut.Text);

            //exportDetail.EX_ID = txt_EX_ID.Text;
            var exportDetail = new MPO_EXPORT_DETAIL();
            exportDetail.ORDE_ID = Convert.ToInt32(lbl_ORDE_ID.Text);
            exportDetail.OPENING_TIME = txt_OPENING_TIME.Text;
            exportDetail.CLOSING_TIME = txt_CLOSING_TIME.Text;
            exportDetail.TEMP_BEFORE = txt_TEMP_BEFORE.Text;
            exportDetail.TEMP_AFTER = txt_TEMP_AFTER.Text;
           
            checkOut.oderdetails = orderdOderdetails;
            checkOut.ExportDetail = exportDetail;


            checkOut.BARCODE_STOCK = txtBarCode.Text;

            //Check Barcode
            if (checkOut.ValidateBarCode())
            {
                checkOut.WithDraw();
            }
            else
            {
                lblMsg.Text = "BarCode ไม่ถูกต้อง";
                return;
            }
            databind();
            bindFormAndOrderDetial();
            clearText();
         
             MasterState();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                object b = e.Row.DataItem;
                //string  STATUS_CURRENT =   
                if (((DataRowView) (b)).Row.ItemArray[13] != "")
                {
                    e.Row.Cells[0].Controls[0].Visible = false;
                }
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            MasterState();
        }
    }
}