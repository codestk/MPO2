using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Stk.Base;

namespace MPO.Code.Bu
{
    public class MPO_COLOR : Stk_BuBase_R2
    {

        public DataSet GetAll()
        {

            string sql =
                "SELECT PR_LINE_COLOR FROM MPO_COLOR;";

            DataSet ds = DB_R2.GetDataSet(sql);


            return ds;


        }


    }
}