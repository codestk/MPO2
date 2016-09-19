using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using Stk.Common;

namespace MPO
{
    public partial class QualityReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            BindData();
        }


        void BindData()
        {
            string STK_ID = Stk_QueryString.DecryptQuery("Q");

           MPO_STOCK st=new MPO_STOCK();

           st = st.GetStockItems(STK_ID);
           txt_STK_ID.Text = Stk_TextNull.StringTotext(st.STK_ID.ToString());
           txt_PR_LOT.Text = Stk_TextNull.StringTotext(st.PR_LOT.ToString());
           txt_MOISTURE.Text = Stk_TextNull.StringTotext(st.MOISTURE.ToString());
           txt_PH.Text = Stk_TextNull.StringTotext(st.PH.ToString());
           txt_JELLY_ST.Text = Stk_TextNull.StringTotext(st.JELLY_ST.ToString());
           txt_COLOR.Text = Stk_TextNull.StringTotext(st.COLOR.ToString());
           txt_ODOUR.Text = Stk_TextNull.StringTotext(st.ODOUR.ToString());
           txt_SPOT.Text = Stk_TextNull.StringTotext(st.SPOT.ToString());
           txt_GRADE.Text = Stk_TextNull.StringTotext(st.GRADE);
           txt_STOCK.Text = Stk_TextNull.StringTotext(st.STOCK);
           txt_REMARK.Text = Stk_TextNull.StringTotext(st.REMARK);
           txt_DARN.Text = Stk_TextNull.StringTotext(st.DARN.ToString());
           txt_KUBOMI.Text = Stk_TextNull.StringTotext(st.KUBOMI.ToString());
       
           
       
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {

        }
    }
}