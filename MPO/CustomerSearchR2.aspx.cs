using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using StkLib.Web.Controls.StkGridView;

namespace MPO.WebCustomer
{
    public partial class CustomerSearchR2 : StkGvEvent
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetDropDown();
            }
        }


        protected override void BindData()
        {
            bool sortAscending = SortDirection == SortDirection.Ascending ? true : false;


            var customerR2 = new MPO_CUSTOMER_R2();

            //if (drpStatus.SelectedIndex > 0)
            //{
            //    ssOrdersR2.STATUS = Convert.ToInt32(drpStatus.SelectedValue);
            //}

            //if (txt_rd_id.Text.Trim() != "")
            //{
            //    ssOrdersR2.OR_ID = Convert.ToInt32(txt_rd_id.Text);
            //}

            if (txt_CUSTNO.Text.Trim() != "")
            {
                customerR2.CUSTNO = Convert.ToInt32(txt_CUSTNO.Text.Trim());
            }

            if (drpSTATE.SelectedIndex > 0)
            {

                customerR2.STATE = drpSTATE.SelectedValue;
            }

            if (txt_COMPANY.Text.Trim() != "")
            {

                customerR2.COMPANY = txt_COMPANY.Text;
            }

            gvCustomers.DataSource = customerR2.GetWithFilter(sortAscending, SortExpression);
            gvCustomers.DataBind();


            SetTableBootsStab(gvCustomers);
        }


        private void SetDropDown()
        {
            var customerR2 = new MPO_CUSTOMER_R2();
            drpSTATE.DataTextField = "STATE";
            drpSTATE.DataValueField = "STATE";
            drpSTATE.DataSource = customerR2.GetState();
            drpSTATE.DataBind();

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}