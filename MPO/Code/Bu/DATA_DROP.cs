using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Stk.Base;

namespace MPO.Code.Bu
{
    public class DATA_DROP : Stk_BuBase_R2
    {



        //Distinct

        public   DataSet drpPR_LINE_COLOR()
        {
            string _sql1 = "SELECT  PR_LINE_COLOR FROM MPO_COLOR;";
           
            return getdata(_sql1);
        }


        public DataSet drpPR_BOX_TYPE()
        {
            string _sql1 = "SELECT PR_BOX_TYPE FROM MPO_BOX_TYPE;";

            return getdata(_sql1);
        }


        public DataSet drpPR_CONDITION()
        {
            string _sql1 = "SELECT PR_CONDITION FROM MPO_CONDITION;";

            return getdata(_sql1);
        }


        public DataSet drpColor()
        {
            string _sql1 = "SELECT distinct  COLOR  FROM MPO_STOCK";

            return getdata(_sql1);
        }


        public DataSet drpMOISTURE()
        {
            string _sql1 = "SELECT distinct  MOISTURE  FROM MPO_STOCK";

            return getdata(_sql1);
        }

        
        public DataSet drpDARN()
        {
            string _sql1 = "SELECT distinct  DARN  FROM MPO_STOCK";

            return getdata(_sql1);
        }

 
            public DataSet  drpOdour()
        {
            string _sql1 = "SELECT distinct  ODOUR FROM MPO_STOCK";

            return getdata(_sql1);
        }

       
        public DataSet drpJELLY_ST()
        {
            string _sql1 = "SELECT distinct  JELLY_ST  FROM MPO_STOCK";

            return getdata(_sql1);
        }



        public DataSet drpPH()
        {
            string _sql1 = "SELECT distinct  PH  FROM MPO_STOCK";

            return getdata(_sql1);
        }
        
        
        public DataSet drpKUBOMI()
        {
            string _sql1 = "SELECT distinct   KUBOMI  FROM MPO_STOCK";

            return getdata(_sql1);
        }




        public DataSet drpSPOT()
        {
            string _sql1 = "SELECT distinct  SPOT  FROM MPO_STOCK";

            return getdata(_sql1);
        }
       

        private DataSet getdata(string sql )
        {
            return   DB_R2.GetDataSet(sql);
        }
    }
}