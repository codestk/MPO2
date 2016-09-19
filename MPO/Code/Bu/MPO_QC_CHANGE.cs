using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Stk.Base;

namespace MPO.Code.Bu
{
    public class MPO_QC_CHANGE : Stk_BuBase_R2
    {
        public int? ORDE_ID { get; set; }

        public string MOISTURE { get; set; }

        public string PH { get; set; }

        public string JELLY_ST { get; set; }

        public string COLOR { get; set; }

        public string ODOUR { get; set; }

        public string SPOT { get; set; }

        public string GRADE { get; set; }

        public string STOCK { get; set; }

        public string REMARK { get; set; }

        public string DARN { get; set; }

        public string KUBOMI { get; set; }

        public string CHANGE_BY { get; set; }

        public DateTime? CHANGE_DATE { get; set; }

        public int? CAHNGE_ID { get; set; }


        public  void Save()
        {
            var prset = new List<IDataParameter>();
            string sql =
                "INSERT INTO MPO_QC_CHANGE(ORDE_ID,MOISTURE,PH,JELLY_ST,COLOR,ODOUR,SPOT,GRADE,STOCK,REMARK,DARN,KUBOMI,CHANGE_BY,CHANGE_DATE) VALUES (@ORDE_ID,@MOISTURE,@PH,@JELLY_ST,@COLOR,@ODOUR,@SPOT,@GRADE,@STOCK,@REMARK,@DARN,@KUBOMI,@CHANGE_BY,@CHANGE_DATE)returning  CAHNGE_ID;";
            prset.Add(DB_R2.CreateParameterDb("@ORDE_ID", ORDE_ID));
            prset.Add(DB_R2.CreateParameterDb("@MOISTURE", MOISTURE));
            prset.Add(DB_R2.CreateParameterDb("@PH", PH));
            prset.Add(DB_R2.CreateParameterDb("@JELLY_ST", JELLY_ST));
            prset.Add(DB_R2.CreateParameterDb("@COLOR", COLOR));
            prset.Add(DB_R2.CreateParameterDb("@ODOUR", ODOUR));
            prset.Add(DB_R2.CreateParameterDb("@SPOT", SPOT));
            prset.Add(DB_R2.CreateParameterDb("@GRADE", GRADE));
            prset.Add(DB_R2.CreateParameterDb("@STOCK", STOCK));
            prset.Add(DB_R2.CreateParameterDb("@REMARK", REMARK));
            prset.Add(DB_R2.CreateParameterDb("@DARN", DARN));
            prset.Add(DB_R2.CreateParameterDb("@KUBOMI", KUBOMI));
            prset.Add(DB_R2.CreateParameterDb("@CHANGE_BY", CHANGE_BY));
            prset.Add(DB_R2.CreateParameterDb("@CHANGE_DATE", CHANGE_DATE));
           // prset.Add(DB_R2.CreateParameterDb("@CAHNGE_ID", CAHNGE_ID));

            int output = DB_R2.FbExecuteNonQuery(sql, prset);
            if (output != 1)
            {
                throw new Exception("Save" + ToString());
            }
        }

        public MPO_QC_CHANGE GetLastUpdate(string ORDE_ID)
        {
            string _sql1 = "SELECT FIRST  1 *   FROM MPO_QC_CHANGE WHERE  ORDE_ID='" + ORDE_ID + "'  ORDER BY  CAHNGE_ID DESC";
            DataSet ds = DB_R2.GetDataSet(_sql1);
            return DataSetToList(ds).FirstOrDefault();
        }

        public MPO_QC_CHANGE Get(string CAHNGE_ID)
        {
            string _sql1 = "SELECT FIRST  1 *   FROM MPO_QC_CHANGE WHERE  CAHNGE_ID='" + CAHNGE_ID + "'  ";
            DataSet ds = DB_R2.GetDataSet(_sql1);
            return DataSetToList(ds).FirstOrDefault();
        }


        public MPO_QC_CHANGE GetByChangeID(string CHANGE_ID)
        {
            string _sql1 = "SELECT   *   FROM MPO_QC_CHANGE WHERE  CAHNGE_ID='" + CHANGE_ID + "' ";
            DataSet ds = DB_R2.GetDataSet(_sql1);
            return DataSetToList(ds).FirstOrDefault();
        }



        public List<MPO_QC_CHANGE> GetList(string ORDE_ID)
        {
            string _sql1 = "SELECT   *   FROM MPO_QC_CHANGE WHERE  ORDE_ID='" + ORDE_ID + "'  ORDER BY  CAHNGE_ID DESC";
            DataSet ds = DB_R2.GetDataSet(_sql1);
            return DataSetToList(ds);
        }

        public List<MPO_QC_CHANGE> GetAll()
        {
            string _sql1 = "SELECT * FROM MPO_QC_CHANGE";
            DataSet ds = DB_R2.GetDataSet(_sql1);
            return DataSetToList(ds);
        }

        private List<MPO_QC_CHANGE> DataSetToList(DataSet ds)
        {
            EnumerableRowCollection<MPO_QC_CHANGE> q = (from temp in ds.Tables[0].AsEnumerable()
                select new MPO_QC_CHANGE
                {
                    ORDE_ID = temp.Field<Int32?>("ORDE_ID"),
                    MOISTURE = temp.Field<String>("MOISTURE"),
                    PH = temp.Field<String>("PH"),
                    JELLY_ST = temp.Field<String>("JELLY_ST"),
                    COLOR = temp.Field<String>("COLOR"),
                    ODOUR = temp.Field<String>("ODOUR"),
                    SPOT = temp.Field<String>("SPOT"),
                    GRADE = temp.Field<String>("GRADE"),
                    STOCK = temp.Field<String>("STOCK"),
                    REMARK = temp.Field<String>("REMARK"),
                    DARN = temp.Field<String>("DARN"),
                    KUBOMI = temp.Field<String>("KUBOMI"),
                    CHANGE_BY = temp.Field<String>("CHANGE_BY"),
                    CHANGE_DATE = temp.Field<DateTime?>("CHANGE_DATE"),
                    CAHNGE_ID = temp.Field<Int32?>("CAHNGE_ID"),
                });
            return q.ToList();
        }
    }
}