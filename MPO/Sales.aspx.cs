using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using MPO.Code.Common;
using MPO.Code.TempData;
using Stk.Common;

namespace MPO
{
    public partial class Sales : Page
    {
        private string Mode()
        {
            if (Request.QueryString["Q"] != null)
            {
                btnSend.Text = "บันทึก";

                string OR_ID = Stk_QueryString.DecryptQuery("Q");

                if (OR_ID != null)
                {
                    return "Change";
                }
            }
            return "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //----------------------------------------------
            if (!Page.IsPostBack)
            {
                Setdrp();
                TableOrder.Clear();

                if (Request.QueryString["Q"] != null)
                {
                    string OR_ID = Stk_QueryString.DecryptQuery("Q");

                    if (OR_ID != null)
                    {
                        BindOldData(OR_ID);
                    }
                }
            }
            //----------------------------------------------
        }


        private void BindOldData(string OR_ID)
        {
            var or = new MPO_ORDERS();

            or = or.GetOrders(OR_ID);
            drpCustomer.Items.FindByValue(or.CUS_ID).Selected = true;
            SetDataCustomer(true);

            txtOrderDate.Text = StkDate.DateTotext(or.ORDER_DATE);

            //Must Convert Data
            TableOrder.ConvertToDataTable(or._MPO_ODERDETAILS);
            Bind();
            drpSeller.Items.FindByValue(or.BYUSER).Selected = true;
            drpSeller.Enabled = false;
            //Enble control
            StateSave(true);

            btnSend.Visible = false;
        }


        public string GetProductName(object prlot)
        {
            var mpo = new MPO_PRODUCT();

            return mpo.GetProductName(prlot.ToString());
        }

        private void Setdrp()
        {
            StkDropDown.SetdrpCustomer(drpCustomer);
            StkDropDown.SetdrpSell(drpSeller);

            
        }


        private void Reset()
        {
            drpCustomer.SelectedIndex = 0;
        }

       

        private void Bind()
        {
            if (TableOrder.OrderTable != null)
            {
                grdSale.DataSource = TableOrder.OrderTable;
                grdSale.DataBind();
            }
        }

    

        private void AddCateriaProduct()
        {
        }


        private bool ValidateOrder()
        {
            foreach (GridViewRow _row in grdSale.Rows)
            {
                string STK_ID = _row.Cells[1].Text;
                string PR_LOT = _row.Cells[2].Text;
                string ITEMS = ((TextBox) _row.FindControl("txtITEMS")).Text;
                string COST = ((TextBox) _row.FindControl("txtCost")).Text;
                string LoadingDate = ((TextBox) _row.FindControl("txtLoadingDate")).Text;
                string ShipmentNo = ((TextBox) _row.FindControl("txtShipment")).Text;
                string txtContainer = ((TextBox) _row.FindControl("txtContainer")).Text;
                string TruckNo = ((TextBox) _row.FindControl("txtTruckNo")).Text;
                string Stamp = ((TextBox) _row.FindControl("txtStamp")).Text;
                string Status = ((TextBox) _row.FindControl("txtStatus")).Text;
                string Orde_id = _row.Cells[3].Text;

                if (StkValidates.IsNumber(ITEMS) == false)
                {
                    // StkAlert.ShowAjax("กรุนาระบุจำนวน", Page);
                    lblMsg.Text = "กรุณาระบุ ระบุจำนวน";
                    _row.FindControl("txtITEMS").Focus();
                    return false;
                }


                if (StkValidates.IsDecimal(COST) == false)
                {
                    // StkAlert.ShowAjax("กรุนาระบุราคา", Page);
                    lblMsg.Text = "กรุณาระบุ ระบุราคา";
                    _row.FindControl("txtCost").Focus();
                    return false;
                }


                if (StkValidates.IsDate(LoadingDate) == false)
                {
                    //  StkAlert.ShowAjax("กรุณาระบุ LoadingDate", Page);
                    lblMsg.Text = "กรุณาระบุ LoadingDate";
                    _row.FindControl("txtLoadingDate").Focus();
                    return false;
                }


                try
                {
                    var vItems = new ITEMS();

                    if (Mode() == "Change")
                    {
                        //ต้อง ลบ Item ตัวมันเอง
                        vItems.ORDE_ID = Orde_id;
                        vItems.change = true;
                    }
                    vItems.validateItems(STK_ID, ITEMS);
                }
                catch (Exception)
                {
                    // StkAlert.ShowAjax("จำนวนไม่พอ", Page);
                    lblMsg.Text = "จำนวนไม่พอ";
                    _row.FindControl("txtITEMS").Focus();
                    return false;
                }
            }

            return true;
        }


        private void SaveOder()
        {
            //TableOrder.OrderTable = null;

            if (TableOrder.OrderTable != null)
                TableOrder.OrderTable.Rows.Clear();

            foreach (GridViewRow _row in grdSale.Rows)
            {
                string STK_ID = _row.Cells[1].Text;
                string PR_LOT = _row.Cells[2].Text;
                string ITEMS = ((TextBox) _row.FindControl("txtITEMS")).Text;
                string COST = ((TextBox) _row.FindControl("txtCost")).Text;
                string LoadingDate = ((TextBox) _row.FindControl("txtLoadingDate")).Text;
                string ShipmentNo = ((TextBox) _row.FindControl("txtShipment")).Text;
                string txtContainer = ((TextBox) _row.FindControl("txtContainer")).Text;
                string TruckNo = ((TextBox) _row.FindControl("txtTruckNo")).Text;
                string Stamp = ((TextBox) _row.FindControl("txtStamp")).Text;
                string Status = ((TextBox) _row.FindControl("txtStatus")).Text;

                try
                {
                    if (Mode() == "Change")
                    {
                        string odrde_id = _row.Cells[3].Text;
                        TableOrder.AddITem(STK_ID, PR_LOT, ITEMS, COST, LoadingDate, ShipmentNo, txtContainer, TruckNo,
                            Stamp,
                            Status, odrde_id
                            );
                    }
                    else
                    {
                        TableOrder.AddITem(STK_ID, PR_LOT, ITEMS, COST, LoadingDate, ShipmentNo, txtContainer, TruckNo,
                            Stamp,
                            Status, "0"
                            );
                    }
                }
                catch (Exception)
                {
                    StkAlert.ShowAjax("รายการสินค้าซ้ำ", Page);
                }


                //   TableOrder.AddITem(row.Cells[1].Text, "0", "0", "11/11/2010", "ShipmentNo", "ContainerNo","TruckNo","Stamp",
                //       "Status"
                //       );
                //string PR_LOT, string ITEMS, string COST, string LoadingDate, string ShipmentNo,
                //string ContainerNo,
                //string TruckNo,
                //string Stamp,
                //string Status)
            }
            //Bind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //StateSave(false);
            // BinbStock();
            clearORder();
        }

     

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            // if (GridView1.Rows.Count > 0)

            if (TableOrder.OrderTable == null)
            {
                grdSale.DataBind();
                return;
            }

            SaveOder();
            if (TableOrder.OrderTable.Rows.Count > 0)
            {
                var btnDelete = sender as LinkButton;
                if (btnDelete != null)
                {
                    var row = (GridViewRow) btnDelete.NamingContainer;

                    DataTable dt = TableOrder.OrderTable;

                    dt.Rows[row.RowIndex].Delete();

                    TableOrder.OrderTable = dt;

                    grdSale.DataSource = dt;
                }

                grdSale.DataBind();
                //  CalAllValue();
            }
        }

        protected void UpdateOrder_Click(object sender, EventArgs e)
        {
            if (ValidateOrder() == false)
            {
                btnSend.Visible = false;
                return;
            }

            btnSend.Visible = true;
            TableOrder.OrderTable = null;
            SaveOder();
            Bind();

            lblMsg.Text = "";
            EnableOrder(false);
        }

        protected void grdSale_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var txtITEMS = e.Row.FindControl("txtITEMS") as TextBox;

                txtITEMS.Text = ((DataRowView) (e.Row.DataItem)).Row.ItemArray[3].ToString();

                var txtCost = e.Row.FindControl("txtCost") as TextBox;

                txtCost.Text = ((DataRowView) (e.Row.DataItem)).Row.ItemArray[4].ToString();

                var txtLoadingDate = e.Row.FindControl("txtLoadingDate") as TextBox;

                txtLoadingDate.Text = ((DataRowView) (e.Row.DataItem)).Row.ItemArray[5].ToString();

                var txtShipment = e.Row.FindControl("txtShipment") as TextBox;

                txtShipment.Text = ((DataRowView) (e.Row.DataItem)).Row.ItemArray[6].ToString();

                var txtContainer = e.Row.FindControl("txtContainer") as TextBox;

                txtContainer.Text = ((DataRowView) (e.Row.DataItem)).Row.ItemArray[7].ToString();

                var txtTruckNo = e.Row.FindControl("txtTruckNo") as TextBox;

                txtTruckNo.Text = ((DataRowView) (e.Row.DataItem)).Row.ItemArray[8].ToString();

                var txtStamp = e.Row.FindControl("txtStamp") as TextBox;

                txtStamp.Text = ((DataRowView) (e.Row.DataItem)).Row.ItemArray[9].ToString();

                var txtStatus = e.Row.FindControl("txtStatus") as TextBox;

                txtStatus.Text = ((DataRowView) (e.Row.DataItem)).Row.ItemArray[10].ToString();
            }
        }


        private bool valdateDataInfomation()
        {
            bool f = true;

            if (drpCustomer.SelectedIndex == 0)
            {
                f = false;
                lblMsg.Text = "โปรดระบุลูกค้า";
                drpCustomer.Focus();
                return f;
            }

            if (txtOrderDate.Text == "")
            {
                f = false;
                lblMsg.Text = "โปรดกำหนดวัน";
                txtOrderDate.Focus();
                return f;
            }

            if (StkValidates.IsDate(txtOrderDate.Text)==false)
            {
                f = false;
                lblMsg.Text = "รูปแบบวันไม่ถูกต้อง";
                txtOrderDate.Focus();
                return f;
            }

           

            if (drpSeller.SelectedIndex == 0)
            {
                f = false;
                lblMsg.Text = "โปรดระบุผู้ขาย";
                drpSeller.Focus();
                return f;
            }



            if (TableOrder.OrderTable == null)
            {
                f = false;
                lblMsg.Text = "โปรดเลือกสินค้า";
                drpSeller.Focus();
                return f;

            }

            if (TableOrder.OrderTable.Rows.Count == 0)
            {
                f = false;
                lblMsg.Text = "โปรดเลือกสินค้า";
                drpSeller.Focus();
                return f;

            }


            lblMsg.Text = "";
            return f;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (valdateDataInfomation() == false)
            {
                return;
            }

            var or = new Order();

            var mpoOrder = new MPO_ORDERS();
            if (txtOrderDate.Text != "")
                mpoOrder.ORDER_DATE = StkDate.TextToDateThToEn(txtOrderDate.Text);


            mpoOrder.CUS_ID = drpCustomer.SelectedValue;
            mpoOrder.BYUSER = drpSeller.SelectedValue;
            or._MPO_ORDERS = mpoOrder;


            // or.ORDER = o1;
            or.ODERDETAILS = TableOrder.OrderTable;




            if (Mode() == "Change")
            {
                or.OR_ID = Convert.ToInt16(Stk_QueryString.DecryptQuery("Q"));
                if (or.Update())
                {
                    pnl1.Visible = false;
                    Panel2.Visible = true;
                    // lblSuccess.Text = "หมายเลขใบเบิก : " + or.OR_ID;
                    // clearORder();
                    btnSend.Visible = false;
                    lblSuccess.Text = "ทำการแก้ไขเรียบร้อยแล้ว";
                    // string ency = Stk_QueryString.EncryptQuery(or.OR_ID.ToString());
                    //    Response.Redirect("OrderDetail.aspx?Q=" + ency);
                }
            }
            else
            {
                // Add New 
                if (or.AddNewOrder())
                {
                    pnl1.Visible = false;
                    Panel2.Visible = true;
                    lblSuccess.Text = "หมายเลขใบเบิก : " + or.OR_ID;
                    clearORder();
                    btnSend.Visible = false;

                    string ency = Stk_QueryString.EncryptQuery(or.OR_ID.ToString());
                    Response.Redirect("OrderDetail.aspx?Q=" + ency);
                }
            }
        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            Bind();
            EnableOrder(true);
        }

        private void clearORder()
        {
            TableOrder.OrderTable = null;
        }


        private void EnableOrder(bool e)
        {
            foreach (GridViewRow _row in grdSale.Rows)
            {
                //string STK_ID = _row.Cells[1].Text;
                //string PR_LOT = _row.Cells[2].Text;
                ((TextBox) _row.FindControl("txtITEMS")).Enabled = e;
                ((TextBox) _row.FindControl("txtCost")).Enabled = e;
                ((TextBox) _row.FindControl("txtLoadingDate")).Enabled = e;
                ((TextBox) _row.FindControl("txtShipment")).Enabled = e;
                ((TextBox) _row.FindControl("txtContainer")).Enabled = e;
                ((TextBox) _row.FindControl("txtTruckNo")).Enabled = e;
                ((TextBox) _row.FindControl("txtStamp")).Enabled = e;
                ((TextBox) _row.FindControl("txtStatus")).Enabled = e;
            }

            btnSend.Visible = !e;
        }


        private void StateSave(bool e)
        {
            pnlControl.Visible = e;

            //  grdSale.Visible = e;
        }

        protected void drpCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpCustomer.SelectedIndex == 0)
            {
                SetBankCustomer();
            }
            else
            {
                SetDataCustomer(true);
            }
        }

        private void SetDataCustomer(bool SetTax)
        {
            int custno = Convert.ToInt32(drpCustomer.SelectedValue);
            var customer = new MPO_CUSTOMER_R2();
            //Test
            try
            {
                customer = customer.GetSource(custno);
                lbl_CUSTNO.Text = customer.CUSTNO.ToString();
                lbl_ADDR1.Text = customer.ADDR1;
                lbl_ADDR2.Text = customer.ADDR2;
                lbl_STATE.Text = customer.STATE;
                lbl_ZIP.Text = customer.ZIP;

                //Set tax rate

                //if ((SetTax == false))
                //    return;
                //if ((customer.TAXRATE != null))
                //    txtTax.Text = customer.TAXRATE.ToString();
                //else
                //{
                //    txtTax.Text = "7";
                //}
            }
            catch (Exception)
            {
            }
        }

        private void SetBankCustomer()
        {
            lbl_CUSTNO.Text = "-";
            lbl_ADDR1.Text = "-";
            lbl_ADDR2.Text = "-";
            lbl_STATE.Text = "-";
            lbl_ZIP.Text = "-";
        }

        protected void Refresh_Click(object sender, EventArgs e)
        {
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            StateSave(true);
            // Setdrp();
            Bind();
            grdSale.DataSource = TableOrder.OrderTable;
            grdSale.DataBind();
            btnSend.Visible = false;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

     

        public string AvaliableItem(object val, object _ORDE_ID)
        {
            string STK_ID = val.ToString();
            string ORDE_ID = _ORDE_ID.ToString();
            var lItems = new ITEMS();

            int av = lItems.Avaliableitem(STK_ID);
            if (Mode() == "Change")
            {
                var mpoOderdetails = new MPO_ODERDETAILS();
                mpoOderdetails = mpoOderdetails.Get(ORDE_ID);
                if (mpoOderdetails != null)
                    av = av + mpoOderdetails.ITEMS;
            }

            return av.ToString();
        }
    }
}