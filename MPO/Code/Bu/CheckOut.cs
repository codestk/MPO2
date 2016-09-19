using System;
using MPO.Code.Common;
using Stk.Base;
using Stk.Common;
using StkLib.Errors;

namespace MPO.Code.Bu
{
    public class CheckOut : Stk_BuBase_R2
    {
        public string BARCODE_STOCK; //for stock
        public MPO_EXPORT_DETAIL ExportDetail;
        public MPO_ODERDETAILS oderdetails;

        public void WithDraw()
        {
            try
            {
                DB_R2.OpenFbData();
                DB_R2.BeginTransaction();


                //validate BarCode
                //string sql = "SELECT STK_ID FROM MPO_STOCK WHERE ITEMS>0 AND BARCODE_STOCK='" + BARCODE_STOCK + "'";
                //int STK_ID = Convert.ToInt32(DB_R2.FbExecuteScalar(sql));
                if (ValidateBarCode() == false)
                {
                    throw new Exception("BarCode MissMatch :Table>" + "  Intput>" +
                                        oderdetails.STK_ID);
                }




                //Flage detail
                DB_R2.FbExecuteNonQuery("UPDATE MPO_ODERDETAILS SET STATUS_CURRENT ='Y' , CHECKOUT_BY='" + StkUser.GetCurrentUser() + "', CHECK_OUT='" + StkDate.ConvertDateEnForDb(Convert.ToDateTime(oderdetails.CHECKOUT_DATE)) + "'  WHERE ORDE_ID =" +
                                        oderdetails.ORDE_ID);
                //Cut Stock
                DB_R2.FbExecuteScalar("UPDATE MPO_STOCK SET ITEMS = ITEMS-" + oderdetails.ITEMS + "  WHERE  STK_ID = " +
                                      oderdetails.STK_ID + " AND BARCODE_STOCK='" + BARCODE_STOCK + "'");

                int i =
                    Convert.ToInt32(
                        DB_R2.FbExecuteScalar("select  ITEMS FROM MPO_STOCK WHERE    STK_ID = " + oderdetails.STK_ID));
                if (i < 0)
                {
                    throw new Exception("items cut fail.");
                }

                //หาทำครบทุกรายการยัง
                int b =
                    Convert.ToInt32(
                        DB_R2.FbExecuteScalar(
                            "SELECT COUNT(*) FROM MPO_ODERDETAILS WHERE STATUS_CURRENT ='' AND  OR_ID =" +
                            oderdetails.OR_ID));

                if (b == 0)
                {
                    DB_R2.FbExecuteScalar("UPDATE MPO_ORDERS SET STATUS = 'Y' WHERE OR_ID = " + oderdetails.OR_ID);
                }

                MPO_EXPORT_DETAIL ex=new MPO_EXPORT_DETAIL();

                ex = ExportDetail;
                ex.Save();
                //Save Exports


                DB_R2.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB_R2.RollBackTransaction();
                ErrorLogging.LogErrorToLogFile(ex, "");
                throw ex;
            }


         
        }


        public bool ValidateBarCode()
        {
            string sql = "SELECT STK_ID FROM MPO_STOCK WHERE ITEMS>0 AND BARCODE_STOCK='" + BARCODE_STOCK + "'";
            try
            {
                int STK_ID = Convert.ToInt32(DB_R2.FbExecuteScalar(sql));
                if (STK_ID != oderdetails.STK_ID)
                {
                    //throw new Exception("BarCode MissMatch :Table>" + STK_ID + "  Intput>" +
                    //                    oderdetails.STK_ID);
                    return false;
                }

            }
            catch (Exception)
            {
                return false;

            }
     


            return true;
            
        }

    }
}