using System;
using System.Data;
using System.Web;
using Stk.Common;

namespace MPO.Code.TempData
{
    public class TableOrder
    {
        #region Const

        public const string Col0 = "STK_ID";
        public const string Col1 = "PR_LOT";
        public const string Col2 = "ITEMS";
        public const string Col3 = "COST";
        public const string Col4 = "LOADINGDATE";
        public const string Col5 = "SHIPMENTNO";
        public const string Col6 = "CONTAINERNO";
        public const string Col7 = "TRUCKNO";
        public const string Col8 = "STAMP";
        public const string Col9 = "STATUS";
        public const string Col10 = "ORDE_ID";

        #endregion

        public static DataTable OrderTable
        {
            get
            {
                object orderTable = HttpContext.Current.Session["OrderTable"];
                if (orderTable == null)
                {
                    return null;
                }
                return (DataTable) orderTable;
            }
            set { HttpContext.Current.Session["OrderTable"] = value; }
        }


        public static void CreateTableOrder()
        {
            var tempTable = new DataTable();

            tempTable.Columns.Add("sino");
            tempTable.Columns.Add(Col0);
            tempTable.Columns.Add(Col1);
            tempTable.Columns.Add(Col2);
            tempTable.Columns.Add(Col3);

            tempTable.Columns.Add(Col4);
            tempTable.Columns.Add(Col5);
            tempTable.Columns.Add(Col6);
            tempTable.Columns.Add(Col7);
            tempTable.Columns.Add(Col8);
            tempTable.Columns.Add(Col9);
            tempTable.Columns.Add(Col10);
            //          public const string Col4 = "LOADINGDATE";
            //public const string Col5 = "SHIPMENTNO";
            //public const string Col6 = "CONTAINERNO";
            //public const string Col7 = "TRUCKNO";
            //public const string Col8 = "STAMP";
            //public const string Col9 = "STATUS";
            //TempTable.PrimaryKey = new DataColumn[] { TempTable.Columns["sino"] };
            //TempTable.PrimaryKey = new[] {TempTable.Columns[ColPR_CODE], TempTable.Columns[ColUN_ID]};
            tempTable.PrimaryKey = new[] {tempTable.Columns[Col0]};

            //Save
            OrderTable = tempTable;
        }


        public static void Clear()
        {
            HttpContext.Current.Session["OrderTable"] = null;
        }

        public static void AddITem(string STK_ID, string PR_LOT, string ITEMS, string COST, string LoadingDate,
            string ShipmentNo,
            string ContainerNo,
            string TruckNo,
            string Stamp,
            string Status, string ordeid)
        {
            if (OrderTable == null)
            {
                CreateTableOrder();
            }

            DataTable dt = OrderTable;


            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr["sino"] = dt.Rows.Count + 1;
                dr[Col0] = STK_ID;
                dr[Col1] = PR_LOT;
                dr[Col2] = ITEMS;
                dr[Col3] = COST;
                dr[Col4] = LoadingDate;
                dr[Col5] = ShipmentNo;
                dr[Col6] = ContainerNo;
                dr[Col7] = TruckNo;
                dr[Col8] = Stamp;
                dr[Col9] = Status;
                dr[Col10] = ordeid;

                dt.Rows.Add(dr);
            }
        }

        public static void ConvertToDataTable(DataSet lsOrderdetailsR2S)
        {
            DataTable dt;
            OrderTable = null;
            //foreach (var l in lsOrderdetailsR2S)
            //{
            //    AddITem(l.ITEMS.ToString(), l.CATEGORY.ToString(), l.ITEMNO.ToString(), l.DESCRIPTION.ToString(), l.COST.ToString());
            //}


            foreach (DataRow  r in lsOrderdetailsR2S.Tables[0].Rows)
            {
                //       string STK_ID ,string PR_LOT, string ITEMS, string COST, string LoadingDate, string ShipmentNo,
                //string ContainerNo,
                //string TruckNo,
                //string Stamp,
                //string Status

                AddITem(r["STK_ID"].ToString(), r["PR_LOT"].ToString(), r["ITEMS"].ToString(), r["COST"].ToString(),
                    StkDate.DateTotext(Convert.ToDateTime(r["LoadingDate"])), r["ShipmentNo"].ToString(),
                    r["ContainerNo"].ToString(),
                    r["TruckNo"].ToString(),
                    r["Stamp"].ToString(),
                    r["Status"].ToString(), r["ORDE_ID"].ToString());
            }
        }
    }
}