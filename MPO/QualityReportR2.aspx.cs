using System;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using MPO.Code.Common;
using Stk.Common;
using StkLib.Web.Controls.StkGridView;

namespace MPO
{
    public partial class QualityReportR2 : StkGvEvent
    {
        private string ORDE_ID;
        protected void Page_Load(object sender, EventArgs e)
        {



            if (Request.QueryString["ORDE_ID"] == null)
            {
                Button2.Visible = false;
              //  return;
                
            }
            else
            {
                bindDataHistory();
            }

            if (!Page.IsPostBack)
            {
                BindData();
               // bindDataHistory();
                return;
            }
          


            ORDE_ID = Stk_QueryString.DecryptQuery("ORDE_ID");
            if (ORDE_ID != null)
            {
                Button2.Visible = true;
            }
            else
            {
                Button2.Visible = false;
            }
           
        }


        void BindData()
        {

            string STK_ID = Stk_QueryString.DecryptQuery("Q");
            MPO_STOCK st = new MPO_STOCK();

            st = st.GetStockItems(STK_ID);
            SetFrom(st);
        }


        private void SetFrom(MPO_STOCK st)
        {
          

       
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


            MPO_STOCK stock = new MPO_STOCK();

            stock = stock.GetStockItems(st.STK_ID.ToString());

            string strImageURL = "PrintBarCode_HttpBinary.aspx?d=" + stock.BARCODE_STOCK;
            BarcodeImage.ImageUrl = strImageURL;
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MPO_QC_CHANGE _obj = new MPO_QC_CHANGE();
            _obj.ORDE_ID = Convert.ToInt16(ORDE_ID);
            _obj.MOISTURE = txt_MOISTURE.Text;
            _obj.PH = txt_PH.Text;
            _obj.JELLY_ST = txt_JELLY_ST.Text;
            _obj.COLOR = txt_COLOR.Text;
            _obj.ODOUR = txt_ODOUR.Text;
            _obj.SPOT = txt_SPOT.Text;
            _obj.GRADE = txt_GRADE.Text;
            _obj.STOCK = txt_STOCK.Text;
            _obj.REMARK = txt_REMARK.Text;
            _obj.DARN = txt_DARN.Text;
            _obj.KUBOMI = txt_KUBOMI.Text;
            _obj.CHANGE_BY = StkUser.GetCurrentUser();
            _obj.CHANGE_DATE =DateTime.Now;

            _obj.Save();
         //   _obj.CAHNGE_ID = CAHNGE_ID; 

            bindDataHistory();
        }

        void bindDataHistory()
        {
            
            ORDE_ID = Stk_QueryString.DecryptQuery("ORDE_ID");
            if (ORDE_ID == null)
            {
                return;
                
            }

            ORDE_ID = Stk_QueryString.DecryptQuery("ORDE_ID");
            if (ORDE_ID==null)
                return;
            

               MPO_QC_CHANGE _obj = new MPO_QC_CHANGE();
               GvHisTory.DataSource  = _obj.GetList(ORDE_ID);
            GvHisTory.DataBind();
        }

   

        protected void GvHisTory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GvHisTory.SelectedRow;


            //// string ORDE_ID  =  GridView1.DataKeys[GridView1.SelectedRow.DataItemIndex].ToString();
            ////string orid = row.Cells[1].Text;
            string CHANGE_ID = GvHisTory.DataKeys[row.DataItemIndex].Value.ToString();

            //Response.Redirect("PrintBarCode_R2.aspx?Q=" + Stk_QueryString.EncryptQuery(STK_ID));


           BindData();//<< For Set 2 fied
            //   txt_STK_ID.Text = Stk_TextNull.StringTotext(qc.STK_ID.ToString());
            //  txt_PR_LOT.Text = Stk_TextNull.StringTotext(qc.PR_LOT.ToString());

            MPO_QC_CHANGE qc = new MPO_QC_CHANGE();
            qc = qc.GetByChangeID(CHANGE_ID);

            txt_MOISTURE.Text = Stk_TextNull.StringTotext(qc.MOISTURE);
            txt_PH.Text = Stk_TextNull.StringTotext(qc.PH);
            txt_JELLY_ST.Text = Stk_TextNull.StringTotext(qc.JELLY_ST);
            txt_COLOR.Text = Stk_TextNull.StringTotext(qc.COLOR);
            txt_ODOUR.Text = Stk_TextNull.StringTotext(qc.ODOUR);
            txt_SPOT.Text = Stk_TextNull.StringTotext(qc.SPOT);
            txt_GRADE.Text = Stk_TextNull.StringTotext(qc.GRADE);
            txt_STOCK.Text = Stk_TextNull.StringTotext(qc.STOCK);
            txt_REMARK.Text = Stk_TextNull.StringTotext(qc.REMARK);
            txt_DARN.Text = Stk_TextNull.StringTotext(qc.DARN);
            txt_KUBOMI.Text = Stk_TextNull.StringTotext(qc.KUBOMI);
        
            
            bindDataHistory();
        }
    }
}