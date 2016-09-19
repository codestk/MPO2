using System;
using System.Data;
using System.Linq;
using MPO.Code.Bu;
using MPO.Code.Common;
using Stk.Common;
using StkLib.Web.Controls.StkGridView;

namespace MPO
{
    public partial class INVOICE_SEND :  StkGvEvent
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //  GridGroupSum();
            BindData();
            CalTotal();


        }

        public string GetProductName(object prlot)
        {
            MPO_PRODUCT mpo = new MPO_PRODUCT();

            return mpo.GetProductName(prlot.ToString());
        }


        public string GetProductID(object prlot)
        {
            MPO_PRODUCT mpo = new MPO_PRODUCT();

            return mpo.Get(prlot.ToString()).FISH_ID;
        }


        public string GetStatusImg(object st)
        {

            string OUTPUT = "";
            //<img src="images/success.png" />
            //<img src="images/delete.png" />
            if (st.ToString().ToUpper().Trim() == "A")
            {
                OUTPUT = "<img src=images/iMGr2/ok.png />";
            }
            else
            {
                OUTPUT = "<img src=images/iMGr2/cancel.png />";
            }

            return OUTPUT;
        }

        //public string CalTatal(object item, object cost)
        //{
        //    int i = Convert.ToInt32( item);
        //    decimal c = Convert.ToDecimal(cost);

        //    c = c*i;
        //    return c.ToString("F");
        //}

        protected override void BindData()
        {

            String orId = Stk_QueryString.DecryptQuery("Q");

            MPO_ORDERS orders = new MPO_ORDERS();

            orders = orders.GetOrders(orId);

            //lbl_COMPANY.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.COMPANY);
            //lbl_ADDR1.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.ADDR1);
            //lbl_ADDR2.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.ADDR2);
            //lbl_CITY.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.CITY);
            //lbl_STATE.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.STATE);
            //lbl_ZIP.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.ZIP);
            //lbl_COUNTRY.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.COUNTRY);
            //lbl_PHONE.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.PHONE);
            //lbl_FAX.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.FAX);
            //// lbl_TAXRATE.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.TAXRATE);
            //lbl_CONTACT.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.CONTACT);
            //// lbl_LASTINVOICEDATE.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.LASTINVOICEDATE);
            ////lbl_EXPORTER.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.EXPORTER);
            //lbl_CUSTNO.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.CUSTNO.ToString());



            Ord_id.Text = orders.OR_ID.ToString();
            lbl_ORDER_DATE.Text = StkDate.DateTotextThaiFull(Convert.ToDateTime(orders.ORDER_DATE));

            customertitle.Text = orders._MPO_CUSTOMER_R2.COMPANY + "<br/>" + orders._MPO_CUSTOMER_R2.CONTACT;
            address.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.ADDR1) + "  " + Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.COMPANY) + "<br>";


            address.Text += Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.ADDR2) + "<br>";
            address.Text += Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.CITY) + " " + Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.STATE) + "<br>";
            address.Text += Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.ZIP);
            address.Text += "Phone:" + Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.PHONE);

            items.DataSource = orders._MPO_ODERDETAILS;
            items.DataBind();


            //Sum Grid 

            decimal total = orders._MPO_ODERDETAILS.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("TOTAL"));
            subtotal.Text = total.ToString("N2");

        }


        private void CalTotal()
        {
            string p = paid.Text.Replace(",", "");
            string t = subtotal.Text.Replace(",", "");
            decimal _piad = 0;
            decimal _total = 0;
            if (StkValidates.IsDecimal(p))
            {
                _piad = Convert.ToDecimal(p);
            }

            if (StkValidates.IsDecimal(t))
            {
                _total = Convert.ToDecimal(t);
            }

            _total = _total - _piad;
            headDue.Text = _total.ToString("N");
            lblTotal.Text = _total.ToString("N");
        }



        #region SumGrid
        private void GridGroupSum()
        {
            GridViewHelper helper = new GridViewHelper(this.items);
            helper.RegisterSummary("ITEMS", SummaryOperation.Sum);
            helper.RegisterSummary("TOTAL", SummaryOperation.Sum);

        }




        #endregion

        protected void paid_TextChanged(object sender, EventArgs e)
        {
            CalTotal();
        }
    }
}