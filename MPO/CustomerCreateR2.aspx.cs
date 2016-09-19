using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Bu;
using Stk.Common;
using StkLib.Errors;

namespace MPO.WebCustomer
{
    public partial class CustomerCreateR2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                  if (HaveCustno())
                  {
                string CUSTNO = RequestCustNo();

              
          
                    bindFormData(CUSTNO);
                }
            }
        }


        private bool HaveCustno()
        {
            bool o = RequestCustNo() != null;
            return o;
        }




        void bindFormData(string custno)
        {
            MPO_CUSTOMER_R2 customer=new MPO_CUSTOMER_R2();
            int cus = Convert.ToInt32(custno);
            customer = customer.GetSource(cus);
            txt_COMPANY.Text = Stk_TextNull.StringTotext(customer.COMPANY);
            txt_ADDR1.Text = Stk_TextNull.StringTotext(customer.ADDR1);
            txt_ADDR2.Text = Stk_TextNull.StringTotext(customer.ADDR2);
            txt_CITY.Text = Stk_TextNull.StringTotext(customer.CITY);
            txt_STATE.Text = Stk_TextNull.StringTotext(customer.STATE);
            txt_ZIP.Text = Stk_TextNull.StringTotext(customer.ZIP);
            txt_COUNTRY.Text = Stk_TextNull.StringTotext(customer.COUNTRY);
            txt_PHONE.Text = Stk_TextNull.StringTotext(customer.PHONE);
            txt_FAX.Text = Stk_TextNull.StringTotext(customer.FAX);


            try
            {
                txt_TAXRATE.Text  =customer.TAXRATE .ToString();

            }
            catch (System.Exception)
            {
                txt_TAXRATE.Text = "0";

            }
         
            txt_CONTACT.Text = Stk_TextNull.StringTotext(customer.CONTACT);
            //txt_LASTINVOICEDATE.Text = Stk_TextNull.StringTotext(customer.LASTINVOICEDATE);
            //txt_EXPORTER.Text = Stk_TextNull.StringTotext(customer.EXPORTER);
            //txt_CUSTNO_R2.Text = Stk_TextNull.StringTotext(customer.CUSTNO_R2);
            lbl_CUSTNO.Text = customer.CUSTNO.ToString();

        }

        private string RequestCustNo()
        {

            string CUSTONO = "";


            CUSTONO=Request.QueryString["Q"];
            return CUSTONO;
        }


        #region Event
        //protected void btnClose_Click(object sender, EventArgs e)
        //{
        //    StkClosePopUp.CloseAjax(btnClose);
        //}
        bool Validate()  {
  bool b=true; if (txt_COMPANY.Text == "")
{
  b = false;
txt_COMPANY.Focus();txtMsg.Text ="โปรดระบุ COMPANY";
return b;
}
 if (txt_ADDR1.Text == "")
{
  b = false;
txt_ADDR1.Focus();txtMsg.Text ="โปรดระบุ ADDR1";
return b;
}
 if (txt_ADDR2.Text == "")
{
  b = false;
txt_ADDR2.Focus();txtMsg.Text ="โปรดระบุ ADDR2";
return b;
}
 if (txt_CITY.Text == "")
{
  b = false;
txt_CITY.Focus();txtMsg.Text ="โปรดระบุ CITY";
return b;
}
 if (txt_STATE.Text == "")
{
  b = false;
txt_STATE.Focus();txtMsg.Text ="โปรดระบุ STATE";
return b;
}
 if (txt_ZIP.Text == "")
{
  b = false;
txt_ZIP.Focus();txtMsg.Text ="โปรดระบุ ZIP";
return b;
}
 if (txt_COUNTRY.Text == "")
{
  b = false;
txt_COUNTRY.Focus();txtMsg.Text ="โปรดระบุ COUNTRY";
return b;
}
 if (txt_PHONE.Text == "")
{
  b = false;
txt_PHONE.Focus();txtMsg.Text ="โปรดระบุ PHONE";
return b;
}
 if (txt_FAX.Text == "")
{
  b = false;
txt_FAX.Focus();txtMsg.Text ="โปรดระบุ FAX";
return b;
}
 if (txt_TAXRATE.Text == "")
{
  b = false;
txt_TAXRATE.Focus();txtMsg.Text ="โปรดระบุ TAXRATE";
return b;
}
 if (txt_CONTACT.Text == "")
{
  b = false;
txt_CONTACT.Focus();txtMsg.Text ="โปรดระบุ CONTACT";
return b;
}


            txtMsg.Text = ""; return b;}



        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Validate() == false)
            {
                return;
            }

            MPO_CUSTOMER_R2 customer=new MPO_CUSTOMER_R2();

            //customer.CUSTNO = txt_CUSTNO.Text;
            customer.COMPANY = txt_COMPANY.Text;
            customer.ADDR1 = txt_ADDR1.Text;
            customer.ADDR2 = txt_ADDR2.Text;
            customer.CITY = txt_CITY.Text;
            customer.STATE = txt_STATE.Text;
            customer.ZIP = txt_ZIP.Text;
            customer.COUNTRY = txt_COUNTRY.Text;
            customer.PHONE = txt_PHONE.Text;
            customer.FAX = txt_FAX.Text;


            try
            {
                customer.TAXRATE = Convert.ToDouble(txt_TAXRATE.Text);
            }
            catch (Exception)
            {

                customer.TAXRATE = 0;
            }
        
          
            
            customer.CONTACT = txt_CONTACT.Text;

            try
            {

                if (HaveCustno())
                {
                    customer.CUSTNO = Convert.ToInt32(lbl_CUSTNO.Text);
                    customer.Update();
                }
                else
                {
                  lbl_CUSTNO.Text=  customer.Save();
                }
                
           
            //Update


                StkAlert.ShowAjax("บันทึกเรียบร้อยแล้ว", btnSave);
                StkClosePopUp.CloseBindDataAjax(btnSave);
            }
            catch (System.Exception e1)
            {

                ErrorLogging.LogErrorToLogFile(e1,"Save Fali");
                StkAlert.ShowAjax("เกิดข้อผิดพลาด", btnSave);
                throw;
            }

        }
        #endregion




    }
}