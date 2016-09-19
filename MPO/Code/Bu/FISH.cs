using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Stk.Base;

namespace MPO.Code.Bu
{
    public class FISH : Stk_BuBase_R2
    {
        public DataSet GetAll()
        {

            string sql =
                "SELECT * FROM MPO_FISH;";

            DataSet ds = DB_R2.GetDataSet(sql);


            return ds;


        }


        public DataSet GetSize(string FISH_ID)
        {

            string sql =
                //"SELECT distinct \"SIZE\" FROM FISH;";
                "SELECT Distinct SIZE FROM FISH WHERE FISH_ID LIKE '" + FISH_ID + "%';";
            DataSet ds = DB_R2.GetDataSet(sql);


            return ds;


        }


    }
}