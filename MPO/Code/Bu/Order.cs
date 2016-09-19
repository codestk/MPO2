using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MPO.Code.TempData;
using Stk.Base;
using StkLib.Errors;

namespace MPO.Code.Bu
{
    public class Order:Stk_BuBase_R2
    {
     
        public MPO_ORDERS _MPO_ORDERS { get; set; }
        public DataTable  ODERDETAILS { get; set; }
   
        public int   OR_ID { get; set; }
        public bool   AddNewOrder( )
        {
            bool output = false;
            try
            {
                DB_R2.OpenFbData();
                DB_R2.BeginTransaction();
               
                MPO_ORDERS o1=new MPO_ORDERS();
                o1 = _MPO_ORDERS;
               int  orid= o1.Save();
               
                MPO_ODERDETAILS o2=new MPO_ODERDETAILS();
                o2.Save(orid, ODERDETAILS);

                DB_R2.CommitTransaction();
              OR_ID = orid;
                output = true;
            }
            catch (System.Exception ex)
            {
                DB_R2.RollBackTransaction();
                ErrorLogging.LogErrorToLogFile( ex, "");
                throw ex;
            }

            return output;

        }


        public bool Update()
        {
            bool output = false;
            try
            {
                DB_R2.OpenFbData();
                DB_R2.BeginTransaction();

                MPO_ORDERS o1 = new MPO_ORDERS();
                o1 = _MPO_ORDERS;
                o1.Upadate(OR_ID);

                MPO_ODERDETAILS o2 = new MPO_ODERDETAILS();
                o2.Update(OR_ID, ODERDETAILS);

                DB_R2.CommitTransaction();
                OR_ID = OR_ID;
                output = true;
            }
            catch (System.Exception ex)
            {
                DB_R2.RollBackTransaction();
                ErrorLogging.LogErrorToLogFile(ex, "");
                throw ex;
            }

            return output;

        }


    }
}