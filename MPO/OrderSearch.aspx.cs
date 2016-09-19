using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using MPO.Code.Common;
using Stk.Common;
using StkLib.Web.Controls.StkGridView;

namespace MPO
{
    public partial class OrderSearch : StkGvEvent
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                setdrp();
            }
        }


        void MasterState()
        {
            gvCustomers.Visible = true;
            gvOrderDetail.Visible = false;
            pnlDetail.Visible = false;
            btnClose.Visible = false;
        }

        void DetailState()
        {
            btnClose.Visible = true;
            gvCustomers.Visible = false;
            gvOrderDetail.Visible = true;
            pnlDetail.Visible = true;
        }

        public string GetCustomerName(object CUS_ID)
        {
            int _cut = Convert.ToInt32(CUS_ID);
            var c = new MPO_CUSTOMER_R2();
            c = c.GetSource(_cut);

            if (c == null)
            {
                return "-";
            }

            return c.COMPANY;
        }

        public string ConvertStatus(object STATUS)
        {
            if (STATUS == null)
                return "N";
                    

            if (STATUS.ToString() == "")
            {
                return "N";
            }


            return STATUS.ToString();
        }

        private void setdrp()
        {
            StkDropDown.SetdrpCustomer(drpCustomer);

            /*drpstatus*/
            var lt0 = new ListItem("กรุณาระบุ", "");
            drpStatus.Items.Insert(0, lt0);
            var lt1 = new ListItem("Y", "Y");
            drpStatus.Items.Insert(1, lt1);
            var lt2 = new ListItem("N", "N");
            drpStatus.Items.Insert(2, lt2);

        }

        protected override void BindData()
        {
            bool sortAscending = SortDirection == SortDirection.Ascending;

            var orders = new MPO_ORDERS();
            if (txt_OR_ID.Text != "")
            {
                orders.OR_ID = Convert.ToInt32(txt_OR_ID.Text);
            }
            if (drpCustomer.SelectedIndex != 0)
            {
                orders.CUS_ID = drpCustomer.SelectedValue;
            }
            if( (drpStatus.SelectedIndex != 0) )
            {
                orders.STATUS = drpStatus.SelectedValue;
            }

            if (txt_BYUSER.Text != "")
            {
                orders.BYUSER = txt_BYUSER.Text;
            }
            if (txt_ORDER_DATE.Text != "")
            {
                orders.ORDER_DATE = StkDate.TextToDateThToEn(txt_ORDER_DATE.Text);
            }

            gvCustomers.DataSource = orders.GetWithFilter(sortAscending, SortExpression);
            gvCustomers.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MasterState();
            BindData();
        }

        protected void gvCustomers_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvCustomers.SelectedRow;

           // string orid = gvCustomers.DataKeys[row.DataItemIndex].Value.ToString();

            string orid = gvCustomers.SelectedDataKey.Value.ToString();
                

            MPO_ORDERS orders = new MPO_ORDERS();

            orders = orders.GetOrders(orid);
            gvOrderDetail.DataSource = orders._MPO_ODERDETAILS;
            gvOrderDetail.DataBind();

            DetailState();
        }

        protected void gvOrderDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvExports = (GridView)e.Row.FindControl("GvExportsDetail");
              MPO_EXPORT_DETAIL ex=new MPO_EXPORT_DETAIL();
              //  string orid_de = "9";
                string orid_de = gvOrderDetail.DataKeys[e.Row.RowIndex].Values[0].ToString();
                gvExports.DataSource = ex.Get(orid_de);
                gvExports.DataBind();
                //  int CountryId = Convert.ToInt32(ddl.SelectedItem);
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            MasterState();
        }

        protected void GvCustomers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
             
            }
        }

        public string SetEditLink(object ORID, object Status)
        {
            string url = "-";
            string usrlFormat = "<a id=\"btnShowPopup0\" target=\"_blank\" href=\"Sales.aspx?Q={0}\"> แก้ไข</a>";

            MPO_ORDERS or=new MPO_ORDERS();


            if (or.ORDER_PROCESSING(ORID.ToString())==false)
            {
                string enOrid = Stk_QueryString.EncryptQuery(ORID.ToString());
                url = string.Format(usrlFormat, enOrid);
            }
            


            return url;
        }


    }
}