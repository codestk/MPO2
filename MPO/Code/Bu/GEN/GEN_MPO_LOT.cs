using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stk.Base;

namespace MPO.Code.Bu.GEN
{
    public class GEN_MPO_LOT : Stk_BuBase_R2
    {

        private void Reset()
        {

            string sql = " ALTER SEQUENCE GEN_MPO_LOT_ID RESTART WITH 1;";

            DB_R2.FbExecuteNonQuery( sql);
        }

        public void Next()
        {

          //  string sql = " SELECT GEN_ID( GEN_MPO_LOT_ID, 1 ) FROM RDB$DATABASE;";

            string sql = "SELECT NEXT VALUE FOR GEN_MPO_LOT_ID FROM RDB$DATABASE;";
           object a= DB_R2.FbExecuteScalar( sql);
        }


        public void ReporduceGen()
        {
            //check 9999

            string sql = "SELECT GEN_ID( GEN_MPO_LOT_ID, 0 ) FROM RDB$DATABASE;";


            int lot= Convert.ToInt16(DB_R2.FbExecuteScalar(sql));
            if (lot == 9999)
            {
                Reset();
            }
            //reset =1
        }
    }
}