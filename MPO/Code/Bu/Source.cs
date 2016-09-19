using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Stk.Base;
using Stk.Common;

namespace MPO.Code.Bu
{
    public class Source: Stk_BuBase_R2 
    { 
        public     DataSet GetAll()
        {

            string sql =
                "  SELECT NAME FROM BELONG;";
             
            DataSet ds = DB_R2.GetDataSet(sql);


            return ds;


        }

 
    
    
    }
}