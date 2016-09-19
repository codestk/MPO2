using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using StkLib.Web.Controls.Form;
using StkLib.Web.Controls.StkGridView;

namespace MPO
{
    public partial class Locations : StkGvEvent
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                BindData();
            }
        }




        override protected void BindData()
        {


            bool sortAscending = this.SortDirection == SortDirection.Ascending ? true : false;


            MPO_LOCATION lc = new MPO_LOCATION();
            lc.LC_ADDRESS = "null";
            lc.LOCATION_ID = "null";
            lc.LC_NAME = "null";

            lc.LC_DEC = "null";
            lc.LC_TEL = "null";


            if (txtLOCATION_ID.Text.Trim() != "")
            {
                lc.LOCATION_ID = txtLOCATION_ID.Text.ToLower().Trim();
            }

            if (txtLC_NAME.Text.Trim() != "")
            {
                lc.LC_NAME = txtLC_NAME.Text.ToLower().Trim();
            }

            if (txtLC_ADDRESS.Text.Trim() != "")
            {
                lc.LC_ADDRESS = txtLC_ADDRESS.Text.ToLower().Trim();
            }


            gvCustomers.DataSource = lc.GetLocations(sortAscending, SortExpression);

            gvCustomers.DataBind();
        }


        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            //  get the gridviewrow from the sender so we can get the datakey we need
            LinkButton btnDelete = sender as LinkButton;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;

            string LC_CODE;
            LC_CODE = gvCustomers.DataKeys[row.RowIndex].Value.ToString();
            MPO_LOCATION Ps = new MPO_LOCATION();

            try
            {
                Ps.Delete(LC_CODE);
            }
            catch
            {
                StkAlert.ShowAjax("ระบบไม่สามารถลบคลังสินค้านี้ได้เนื่องจากมีการทำรายการค้างอยู่", BtnSearch);
                return;
            }
            BindData();

        }

        //Display Iconf
        public string CheckStatus(Object SP_ACTIVE_STATUS)
        {
            string OUTPUT = "";
            //<img src="images/success.png" />
            //<img src="images/delete.png" />
            if (SP_ACTIVE_STATUS.ToString().ToUpper().Trim() == "A")
            {
                OUTPUT = "<img src=images/success1.gif />";
            }
            else
            {
                OUTPUT = "<img src=images/cancel.png />";
            }

            return OUTPUT;
        }

    }
}