using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Stk.Base;

namespace MPO.Code.Bu
{
    public class MPO_EXPORT_DETAIL : Stk_BuBase_R2
    {
        public int EX_ID { get; set; }

        public int ORDE_ID { get; set; }

        public string OPENING_TIME { get; set; }

        public string CLOSING_TIME { get; set; }

        public string TEMP_BEFORE { get; set; }

        public string TEMP_AFTER { get; set; }



        public void Save()
        {
            var prset = new List<IDataParameter>();
            string sql =
                "INSERT INTO MPO_EXPORT_DETAIL(ORDE_ID,OPENING_TIME,CLOSING_TIME,TEMP_BEFORE,TEMP_AFTER) VALUES (@ORDE_ID,@OPENING_TIME,@CLOSING_TIME,@TEMP_BEFORE,@TEMP_AFTER) returning  EX_ID;";
            //prset.Add(DB_R2.CreateParameterDb("@EX_ID", EX_ID));
            prset.Add(DB_R2.CreateParameterDb("@ORDE_ID", ORDE_ID));
            prset.Add(DB_R2.CreateParameterDb("@OPENING_TIME", OPENING_TIME));
            prset.Add(DB_R2.CreateParameterDb("@CLOSING_TIME", CLOSING_TIME));
            prset.Add(DB_R2.CreateParameterDb("@TEMP_BEFORE", TEMP_BEFORE));
            prset.Add(DB_R2.CreateParameterDb("@TEMP_AFTER", TEMP_AFTER));

            int output = DB_R2.FbExecuteNonQuery(sql, prset);
            if (output != 1)
            {
                throw new Exception("Save" + ToString());
            }
        }


        public List<MPO_EXPORT_DETAIL> GetAll()
        {
            string _sql1 = "SELECT * FROM MPO_EXPORT_DETAIL";
            DataSet ds = DB_R2.GetDataSet(_sql1);
            return DataSetToList(ds);
        }

        public List<MPO_EXPORT_DETAIL> Get(string ORDE_ID)
        {
            string _sql1 = "SELECT * FROM MPO_EXPORT_DETAIL WHERE ORDE_ID="+ ORDE_ID;
            DataSet ds = DB_R2.GetDataSet(_sql1);
            return DataSetToList(ds);
        }

        private List<MPO_EXPORT_DETAIL> DataSetToList(DataSet ds)
        {
            EnumerableRowCollection<MPO_EXPORT_DETAIL> q = (from temp in ds.Tables[0].AsEnumerable()
                select new MPO_EXPORT_DETAIL
                {
                    EX_ID = temp.Field<Int32>("EX_ID"),
                    ORDE_ID = temp.Field<Int32>("ORDE_ID"),
                    OPENING_TIME = temp.Field<String>("OPENING_TIME"),
                    CLOSING_TIME = temp.Field<String>("CLOSING_TIME"),
                    TEMP_BEFORE = temp.Field<String>("TEMP_BEFORE"),
                    TEMP_AFTER = temp.Field<String>("TEMP_AFTER"),
                });
            return q.ToList();
        }
    }
}