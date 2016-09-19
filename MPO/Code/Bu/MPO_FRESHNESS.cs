using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Stk.Base;

namespace MPO.Code.Bu
{
    public class MPO_FRESHNESS : Stk_BuBase_R2
    {

        public DataSet GetAll()
        {

            string sql =
                "SELECT PR_FRESHNESS FROM MPO_FRESHNESS;";

            DataSet ds = DB_R2.GetDataSet(sql);


            return ds;


        }


    }
}