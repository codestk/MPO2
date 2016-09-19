using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using Stk.Bu;
using Stk.Common;
using StkLib.Web.Controls.StkGridView;

namespace MPO
{
    public partial class OrderDetail : StkGvEvent
    {

       
        protected void Page_Load(object sender, EventArgs e)
        {
          //  GridGroupSum();
            BindData();


            SetLinkInvoice();

         
        }



        private void SetLinkInvoice()
        {
            
            String orId = Stk_QueryString.DecryptQuery("Q");

            string url = string.Format("INVOICE.aspx?Q={0}", Stk_QueryString.EncryptQuery(orId));
           
            

            //OrderDetail.aspx?Q=<%# Stk_QueryString.EncryptQuery( (Eval("OR_ID")))
            btnprint.Attributes.Add("onclick", "javascript:window.open('" + url + "');return false;");




            string sendurl = string.Format("INVOICE_SEND.aspx?Q={0}", Stk_QueryString.EncryptQuery(orId));
            btnSend.Attributes.Add("onclick", "javascript:window.open('" + sendurl + "');return false;");

        }

        public string GetProductName(object prlot)
        {
            MPO_PRODUCT mpo =new  MPO_PRODUCT();

            return mpo.GetProductName(prlot.ToString());
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
             
            lbl_COMPANY.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.COMPANY);
            lbl_ADDR1.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.ADDR1);
            lbl_ADDR2.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.ADDR2);
            lbl_CITY.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.CITY);
            lbl_STATE.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.STATE);
            lbl_ZIP.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.ZIP);
            lbl_COUNTRY.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.COUNTRY);
            lbl_PHONE.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.PHONE);
            lbl_FAX.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.FAX);
           // lbl_TAXRATE.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.TAXRATE);
            lbl_CONTACT.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.CONTACT);
           // lbl_LASTINVOICEDATE.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.LASTINVOICEDATE);
            //lbl_EXPORTER.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.EXPORTER);
            lbl_CUSTNO.Text = Stk_TextNull.StringTotext(orders._MPO_CUSTOMER_R2.CUSTNO.ToString());

            Stk_Employee slEmployee=new Stk_Employee();
            lblSeller.Text = slEmployee.GetFullName( orders.BYUSER);

            GridView1.DataSource = orders._MPO_ODERDETAILS;
            GridView1.DataBind();
        }

       


        #region SumGrid
        private void GridGroupSum()
        {
            GridViewHelper helper = new GridViewHelper(this.GridView1);
            helper.RegisterSummary("ITEMS", SummaryOperation.Sum);
            helper.RegisterSummary("TOTAL", SummaryOperation.Sum);
            
        }


         

        #endregion
    }
}