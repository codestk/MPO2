using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Stk.Base;

namespace MPO.Code
{
    public class MPO_LINE : Stk_BuBase_R2
    {

        public DataSet GetAll()
        {

            string sql =
                "SELECT PR_LINE FROM MPO_LINE;";

            DataSet ds = DB_R2.GetDataSet(sql);


            return ds;


        }


    }
}