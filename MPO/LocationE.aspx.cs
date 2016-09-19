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
    public partial class LocationE : System.Web.UI.Page
    {
        string Mode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Mode = Request.QueryString["Mode"];
            if (!Page.IsPostBack)
            {


                if (Mode != null)
                {
                    if (Mode == "Edit")
                    {
                        txtLC_CODE.Enabled = false;
                        txtLC_CODE.Text = Request.QueryString["LC_CODE"].ToString();
                        txtLC_NAME.Text = Request.QueryString["LC_NAME"].ToString();

                        txtLC_ADDRESS.Text = Request.QueryString["LC_ADDRESS"].ToString();
                        txtLC_DEC.Text = Request.QueryString["LC_DEC"].ToString();
                        txtLC_TEL.Text = Request.QueryString["LC_TEL"].ToString();

                        string LC_ACTIVE = Request.QueryString["LC_ACTIVE"].ToString().Trim();
                        if (LC_ACTIVE == "A")
                        {
                            chkActive.Checked = true;
                        }
                        else
                        {
                            chkActive.Checked = false;
                        }
                    }
                }
            }
        }


        public bool ValidateForm()
        {
            bool output = true;

            if (txtLC_CODE.Text.Trim() == "")
            {
                StkAlert.ShowAjax("กรุณาระบุรหัสคลังสินค้า", UpdateLinkButton);
                output = false;
            }
            else if (txtLC_NAME.Text.Trim() == "")
            {
                StkAlert.ShowAjax("กรุณาระบุชื่อคลังสินค้า", UpdateLinkButton);
                output = false;

            }
            return output;

        }

        protected void UpdateLinkButton_Click(object sender, EventArgs e)
        {

            if (ValidateForm() == false)
            {
                return;
            }
            MPO_LOCATION lc = new MPO_LOCATION();


            lc.LOCATION_ID = txtLC_CODE.Text;
            lc.LC_NAME = txtLC_NAME.Text;
            lc.LC_ADDRESS = txtLC_ADDRESS.Text;
            lc.LC_DEC = txtLC_DEC.Text;
            lc.LC_TEL = txtLC_TEL.Text;


            if (chkActive.Checked == true)
            {
                lc.LC_ACTIVE = "A";
            }
            else
            {
                lc.LC_ACTIVE = "D";
            }

            //ถ้า Add ให้Check Duplication Key
            if (Mode == "Add")
            {
                if (lc.CheckKey() == true)
                {

                    StkAlert.ShowAjax("ตำแหน่งซ้ำ", UpdateLinkButton);
                    return;
                }
            }

            lc.Save();
            ClearTxt();
            StkAlert.ShowAjax("ทำการบันทึกเรียบร้อย", UpdateLinkButton);


            StkClosePopUp.CloseAjax(UpdateLinkButton);
        }

        protected void CancelLinkButton_Click(object sender, EventArgs e)
        {
            StkClosePopUp.CloseAjax(UpdateLinkButton);
        }




        private void ClearTxt()
        {

            txtLC_ADDRESS.Text = "";
            txtLC_CODE.Text = "";
            txtLC_DEC.Text = "";
            txtLC_NAME.Text = "";
            txtLC_TEL.Text = "";
        }
    }
}