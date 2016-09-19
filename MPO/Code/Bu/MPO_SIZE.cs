using System.Data;
using Stk.Base;

namespace MPO.Code.Bu
{
    public class MPO_SIZE : Stk_BuBase_R2
    {
        public DataSet GetAll()
        {

            string sql =
                "SELECT * FROM MPO_SIZE ORDER BY MPO_SIZE;";

            DataSet ds = DB_R2.GetDataSet(sql);


            return ds;


        }

    }
}