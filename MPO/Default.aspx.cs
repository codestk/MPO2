using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using MPO.Code.Common;
using MPO.Code.TempData;
using Stk.Common;

namespace MPO
{
    public partial class _Default : System.Web.UI.Page
    {

        private  const string Curentitem = "20";
        private string userCurrent;
        protected void Page_Load(object sender, EventArgs e)
        {
            userCurrent = StkUser.GetCurrentUser();
            
            bindMyOrder();
            bindMyProduct();
            bindMyQc();
        
        
        }
 

        private void bindMyOrder()
        {

            MPO_ORDERS mpoOrders=new MPO_ORDERS();

            gvMyOrder.DataSource = mpoOrders.GetMyoderTop(userCurrent, Curentitem);

            gvMyOrder.DataBind();
        }


        private void bindMyProduct()
        {
            MPO_PRODUCT pr=new MPO_PRODUCT();
            MyProduct.DataSource = pr.GetMyProduct(userCurrent, Curentitem);
            MyProduct.DataBind();
        }

        private void bindMyQc()
        {
          MPO_STOCK st=new MPO_STOCK();
          MyQc.DataSource = st.GetMyQc(userCurrent, Curentitem);
          MyQc.DataBind();
        }


        public string ShowLinkDetail(object PR_STATUS,object PR_LOT)
        {
            if (PR_STATUS == null)
                return "-";

            string _PR_STATUS = PR_STATUS.ToString();
            string _PR_LOT = PR_LOT.ToString();



            if (_PR_STATUS == "C")

            {

               MPO_STOCK geStock=new MPO_STOCK();
               geStock =  geStock.GetStockItemsByPR_LOT(_PR_LOT);
               string lnk = string.Format("<a id='btnShowPopup0' target='_blank' href='PrintBarCode_R2.aspx?Q={0}&amp;Mode=Add&amp;TB_iframe=true&amp;height=550&amp;width=600'                        title=''>                        <img src='images/barcode_all.gif' />                    </a>", Stk_QueryString.EncryptQuery(  geStock.STK_ID));
                return lnk;
            }




            return "-";
        }
    }
}
