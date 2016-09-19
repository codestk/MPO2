using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Enum;
using Stk.Bu;
using Stk.Common;
using StkLib.CCEnum;
using StkAlert = StkLib.Web.Controls.Form.StkAlert;

namespace MPO
{
    public partial class ManageUserE : System.Web.UI.Page
    {
        string Mode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Mode = Request.QueryString["Mode"];
            if (!Page.IsPostBack)
            {
                //trLocation.Visible = false;
                //Stk_Location lc = new Stk_Location();

                //drpLocation.DataSource = lc.GetLocations();
                //drpLocation.DataTextField = lc.STKText;
                //drpLocation.DataValueField = lc.STKValue;
                //drpLocation.DataBind();
                //drpLocation.Items.Insert(0, "กรุณาเลือกคลังสินค้า");

                if (Mode != null)
                {
                    if (Mode == "Edit")
                    {

                        Stk_Employee Em = new Stk_Employee();
                        string EM_ID = Request.QueryString["EM_ID"].ToString();
                        Em.GetEmployee(EM_ID);
                        txtEM_ID.Text = Em.EM_ID;
                        txtEM_ID.Enabled = false;
                        txtEM_PASS.Text = Em.EM_PASS;
                        if (Em.EM_PERMISSION == StringEnum.GetStringValue(EnumStkRole.Admin))
                        {
                            rdAdmin.Checked = true;
                        }
                        else if (Em.EM_PERMISSION == StringEnum.GetStringValue(EnumStkRole.Store))
                        {
                            //rdstock.Checked = true;
                            //trLocation.Visible = true;
                            ////for Delete Location
                            //try
                            //{
                            //    drpLocation.Items.FindByValue(Em.LC_CODE).Selected = true;
                            //}
                            //catch
                            //{
                            //    drpLocation.SelectedIndex = 0;
                            //}
                        }
                        else if (Em.EM_PERMISSION == StringEnum.GetStringValue(EnumStkRole.Purchase))
                        {
                            rdSale.Checked = true;

                        }
                        else if (Em.EM_PERMISSION == StringEnum.GetStringValue(EnumStkRole.SuperVisor))
                        {
                            rdUser.Checked = true;

                        }
                        else if (Em.EM_PERMISSION == StringEnum.GetStringValue(EnumStkRole.Production))
                        {
                            rdProduction.Checked = true;
                        }

                        else if (Em.EM_PERMISSION == StringEnum.GetStringValue(EnumStkRole.QC))
                        {
                            rdQc.Checked = true;
                        }

                        txtEM_TITLE.Text = Em.EM_TITLE;
                        txtEM_NAME.Text = Em.EM_NAME;
                        txtEM_SURNAME.Text = Em.EM_SURNAME;
                        txtEM_EMAIL.Text = Em.EM_EMAIL;
                        txtEM_ADDRESS.Text = Em.EM_ADDRESS;
                        txtEM_TEL.Text = Em.EM_TEL;
                        txtEM_NOTE.Text = Em.EM_NOTE;

                        if (Em.EM_FLAG == "A")
                        { chkActive.Checked = true; }
                        else

                        { chkActive.Checked = false; }


                        //it can not flag user is Unactive
                        if ((Em.EM_NAME.ToLower() == "admin") && (Em.EM_FLAG == "A"))
                        {
                            chkActive.Enabled = false;
                            return;
                        }

                    }
                }
            }


        }



        private bool validateForm()
        {
            bool output = true;

            if (txtEM_ID.Text.Trim() == "")
            {
                StkAlert.ShowAjax("กรุณาระบุ UserName", UpdateLinkButton);
                output = false;
            }

            if (txtEM_PASS.Text.Trim() == "")
            {
                StkAlert.ShowAjax("กรุณาระบุ Password", UpdateLinkButton);
                output = false;
            }

            //Add New Role
            if ((rdUser.Checked == rdProduction.Checked == rdAdmin.Checked == rdSale.Checked == rdstock.Checked == rdQc.Checked))
            {
                StkAlert.ShowAjax("กรุณาระบุสิทธิ์", UpdateLinkButton);
                output = false;
            }

            //if ((rdstock.Checked == true) && (drpLocation.SelectedIndex == 0))
            //{
            //    StkAlert.ShowAjax("กรุณาระบุคลังสินค้า", UpdateLinkButton);
            //    output = false;


            //}

            if (txtEM_TITLE.Text.Trim() == "")
            {
                StkAlert.ShowAjax("กรุณาระบุคำนำหน้า", UpdateLinkButton);
                output = false;
            }

            if (txtEM_NAME.Text.Trim() == "")
            {
                StkAlert.ShowAjax("กรุณาระบุชื่อ", UpdateLinkButton);
                output = false;
            }
            if (txtEM_SURNAME.Text.Trim() == "")
            {
                StkAlert.ShowAjax("กรุณาระบุนามสกุล", UpdateLinkButton);
                output = false;
            }

            //if (txtEM_EMAIL.Text.Trim() == "")
            //{
            //    StkAlert.ShowAjax("กรุณาระบุ E-Mail", UpdateLinkButton);

            //    output = false;


            //}
            //else if (StkValidates.IsValidEmail(txtEM_EMAIL.Text.Trim())==false)
            //{
            //    StkAlert.ShowAjax("กรุณาระบุ E-Mail ให้ถูกต้อง", UpdateLinkButton);

            //    output = false;

            //}




            //   if (txtEM_ADDRESS.Text.Trim() == "")
            //{
            //    StkAlert.ShowAjax("กรุณาระบุที่อยู่", UpdateLinkButton);
            //    output = false;
            //} 


            return output;
        }

        protected void UpdateLinkButton_Click(object sender, EventArgs e)
        {
            if (validateForm() == false)
            {


                return;
            }

            Stk_Employee Em = new Stk_Employee();
            Em.EM_ID = txtEM_ID.Text;
            Em.EM_PASS = txtEM_PASS.Text;

            if (rdAdmin.Checked == true)
            {
                Em.EM_PERMISSION = StringEnum.GetStringValue(EnumStkRole.Admin);
            }
            else if (rdstock.Checked == true)
            {
                Em.EM_PERMISSION = StringEnum.GetStringValue(EnumStkRole.Store);
            }
            else if (rdSale.Checked == true)
            {
                Em.EM_PERMISSION = StringEnum.GetStringValue(EnumStkRole.Purchase);
            }
            //Add New Roles
            else if (rdProduction.Checked == true)
            {
                Em.EM_PERMISSION = StringEnum.GetStringValue(EnumStkRole.Production);
            }
            else if (rdUser.Checked == true)
            {
                Em.EM_PERMISSION = StringEnum.GetStringValue(EnumStkRole.SuperVisor);
            }

            else if (rdQc.Checked == true)
            {
                Em.EM_PERMISSION = StringEnum.GetStringValue(EnumStkRole.QC);
            }


            if (rdAdmin.Checked == true)
            {
                Em.LC_CODE = "0";

            }
            else
            {
                //if (drpLocation.SelectedIndex != 0)
                //{
                //    Em.LC_CODE = drpLocation.SelectedValue;
                //}

            }

            Em.EM_TITLE = txtEM_TITLE.Text;
            Em.EM_NAME = txtEM_NAME.Text;
            Em.EM_SURNAME = txtEM_SURNAME.Text;
            Em.EM_EMAIL = txtEM_EMAIL.Text;
            Em.EM_ADDRESS = txtEM_ADDRESS.Text;
            Em.EM_TEL = txtEM_TEL.Text;
            Em.EM_NOTE = txtEM_NOTE.Text;
            Em.EM_CREATE = System.DateTime.Now;




            if (chkActive.Checked == true)
            {
                Em.EM_FLAG = "A";
            }
            else
            {
                Em.EM_FLAG = "I";
            }

            if (Mode != "Edit")
            {
                if (Em.CheckKey() == true)
                {
                    txtEM_ID.Focus();
                    StkAlert.ShowAjax("มี UserName นี้อยู่แล้วในระบบ", UpdateLinkButton);
                    //trLocation.Visible = true;
                    // trLocation.Style.Add("display", "block");

                    return;
                }



            }


            if (Em.Save())
            {
                StkAlert.ShowAjax("ทำการบันทึกผู้ใช้เรียบร้อยแล้ว", UpdateLinkButton);
                StkClosePopUp.CloseAjax(UpdateLinkButton);
            }

        }

        protected void CancelLinkButton_Click(object sender, EventArgs e)
        {
            StkClosePopUp.CloseAjax(UpdateLinkButton);
        }



        //protected void rdstock_CheckedChanged(object sender, EventArgs e)
        //{
        //    trLocation.Visible = true;
        //    //trLocation.Style.Add("display", "block");

        //}

        //protected void rdSale_CheckedChanged(object sender, EventArgs e)
        //{
        //    trLocation.Visible = false;
        //    // trLocation.Style.Add("display", "none");
        //}

        //protected void rdAdmin_CheckedChanged(object sender, EventArgs e)
        //{
        //    trLocation.Visible = false;
        //    //trLocation.Style.Add("display", "none");
        //}

        //protected void rdProduction_CheckedChanged(object sender, EventArgs e)
        //{
        //    trLocation.Visible = false;
        //}

        protected void rd_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdstock.Checked == true)
            //{
            //    trLocation.Visible = true;
            //}
            //else
            //{
            //    trLocation.Visible = false;
            //}
        }

    }
}