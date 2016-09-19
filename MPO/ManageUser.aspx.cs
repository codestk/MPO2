using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Enum;
using Stk.Bu;
using StkLib.CCEnum;
using StkLib.Web.Controls.Form;
using StkLib.Web.Controls.StkGridView;

namespace MPO
{
    public partial class ManageUser :  StkGvEvent
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindDropLocation();//Must First Bind Data
                BindData();
            
            }
        }

        void BindDropLocation()
        { 
            //Stk_Location l=new Stk_Location();

            //drpLocations.DataSource = l.GetLocations();
            //drpLocations.DataTextField = l.STKText;
            //drpLocations.DataValueField = l.STKValue;
            //drpLocations.DataBind();

            //drpLocations.Items.Insert(0,new ListItem("ทั้งหมด","0"));
        }
        override protected void BindData()
        {


            bool sortAscending = this.SortDirection == SortDirection.Ascending ? true : false;


           
            Stk_Employee emp = new Stk_Employee();
            emp.EM_ID = "null";
            emp.EM_NAME = "null";
            emp.EM_SURNAME = "null";
            //lc.LC_ADDRESS = "null";
            //lc.LC_CODE = "null";
            //lc.LC_NAME = "null";

            //lc.LC_DEC = "null";
            //lc.LC_TEL = "null";


            if (txtEM_ID.Text.Trim() != "")
            {
                emp.EM_ID = txtEM_ID.Text.Trim();
            }

            if (txtEM_NAME.Text.Trim() != "")
            {
                emp.EM_NAME = txtEM_NAME.Text.Trim();
            }

            if (txtEM_SURNAME.Text.Trim() != "")
            {
                emp.EM_SURNAME = txtEM_SURNAME.Text.Trim();
            }


           // emp.LC_CODE = drpLocations.SelectedValue;
            gvCustomers.DataSource = emp.GetEmployee(sortAscending, SortExpression);

            gvCustomers.DataBind();
        }
        protected override void GvCustomers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView gridView = (GridView)sender;

            if (e.Row.RowType == DataControlRowType.Header)
            {
                int cellIndex = -1;
                foreach (DataControlField field in gridView.Columns)
                {

                    if (field.SortExpression != "")
                    {
                        e.Row.Cells[gridView.Columns.IndexOf(field)].CssClass = "headerstyle";
                    }
                    //if (field.SortExpression == gridView.SortExpression)
                    if (field.SortExpression == this.SortExpression)
                    {
                        cellIndex = gridView.Columns.IndexOf(field);
                    }
                }

                if (cellIndex > -1)
                {
                    //  this is a header row,
                    //  set the sort style
                    e.Row.Cells[cellIndex].CssClass =
                        this.SortDirection == SortDirection.Ascending
                        ? "sortascheaderstyle" : "sortdescheaderstyle";
                }
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // determine the value of the UnitsInStock field
               
                string Role = (DataBinder.Eval(e.Row.DataItem, "EM_PERMISSION")).ToString();
              
                if (Role == StringEnum.GetStringValue(EnumStkRole.Admin))
                {
                 e.Row.Cells[7].Text = EnumStkRole.Admin.ToString();
                }
                else if (Role == StringEnum.GetStringValue(EnumStkRole.Purchase))
                {
                    e.Row.Cells[7].Text = EnumStkRole.Purchase.ToString();
                }
                else if (Role == StringEnum.GetStringValue(EnumStkRole.Store))
                {
                    e.Row.Cells[7].Text = EnumStkRole.Store.ToString();
                }
                //Add New Rows
                else if (Role == StringEnum.GetStringValue(EnumStkRole.Production ))
                {
                    e.Row.Cells[7].Text = EnumStkRole.Production.ToString();
                }
                else if (Role == StringEnum.GetStringValue(EnumStkRole.SuperVisor  ))
                {
                    e.Row.Cells[7].Text = EnumStkRole.SuperVisor.ToString();
                }
                else if (Role == StringEnum.GetStringValue(EnumStkRole.QC))
                {
                    e.Row.Cells[7].Text = EnumStkRole.QC.ToString();
                }
                else if (Role == StringEnum.GetStringValue(EnumStkRole.User))
                {
                    e.Row.Cells[7].Text = EnumStkRole.User.ToString();
                }
        

            }

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            //  get the gridviewrow from the sender so we can get the datakey we need
            LinkButton btnDelete = sender as LinkButton;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;

            string EM_ID;
            EM_ID = gvCustomers.DataKeys[row.RowIndex].Value.ToString();
            Stk_Employee emp = new Stk_Employee();

            if (EM_ID.ToLower() == "admin")
            {
                StkAlert.ShowAjax("ระบบไม่สามารถลบ UserName นี้ได้", BtnSearch);
                return;
            }
            
            try
            {
                emp.Delete(EM_ID);
            }
            catch
            {
                StkAlert.ShowAjax("ระบบไม่สามารถทำการลบ UserName:" + EM_ID + " ออกจากระบบได้เนื่องจาก UserName ดังกล่าวได้ทำรายการค้างอยู่ในระบบ", BtnSearch);
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
                OUTPUT = "<img src=images/iMGr2/ok.png />";
            } 
            else
            {
                OUTPUT = "<img src=images/iMGr2/cancel.png />";
            }

            return OUTPUT;
        }

    }
}