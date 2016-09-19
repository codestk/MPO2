using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using FirebirdSql.Data.FirebirdClient;
using MPO.Code.Common;
using Stk.Base;
using Stk.Common;
using StkLib.Errors;

namespace MPO.Code.Bu
{
    public class MPO_PRODUCT : Stk_BuBase_R2
    {



        public int Dong_DATE
        {
            get
            {
                int dDif = 0;
                try
                {
                    DateTime df = Convert.ToDateTime(PR_REV_DATE);
                    DateTime dt = Convert.ToDateTime(PR_CUT_DATE);

                    dDif = (dt - df).Days;
                }
                catch (Exception)
                {
                    return dDif;
                }

                return dDif;
            }
        }


        Int32? _PR_LOT;
        public Int32? PR_LOT { get { return _PR_LOT; } set { _PR_LOT = value; } }

        DateTime? _PR_PRODUCE_DATE;
        public DateTime? PR_PRODUCE_DATE { get { return _PR_PRODUCE_DATE; } set { _PR_PRODUCE_DATE = value; } }

        DateTime? _PR_REV_DATE;
        public DateTime? PR_REV_DATE { get { return _PR_REV_DATE; } set { _PR_REV_DATE = value; } }

        DateTime? _PR_CUT_DATE;
        public DateTime? PR_CUT_DATE { get { return _PR_CUT_DATE; } set { _PR_CUT_DATE = value; } }

        String _PR_LINE;
        public String PR_LINE { get { return _PR_LINE; } set { _PR_LINE = value; } }

        String _PR_CONDITION;
        public String PR_CONDITION { get { return _PR_CONDITION; } set { _PR_CONDITION = value; } }

        Decimal? _PR_WEIGHT;
        public Decimal? PR_WEIGHT { get { return _PR_WEIGHT; } set { _PR_WEIGHT = value; } }

        DateTime? _PR_PACK_DATE;
        public DateTime? PR_PACK_DATE { get { return _PR_PACK_DATE; } set { _PR_PACK_DATE = value; } }

        String _PR_BOX_TYPE;
        public String PR_BOX_TYPE { get { return _PR_BOX_TYPE; } set { _PR_BOX_TYPE = value; } }

        String _PR_LINE_COLOR;
        public String PR_LINE_COLOR { get { return _PR_LINE_COLOR; } set { _PR_LINE_COLOR = value; } }

        Int32? _PR_UNIT;
        public Int32? PR_UNIT { get { return _PR_UNIT; } set { _PR_UNIT = value; } }

        String _FISH_ID;
        public String FISH_ID { get { return _FISH_ID; } set { _FISH_ID = value; } }

        String _PR_SIZE;
        public String PR_SIZE { get { return _PR_SIZE; } set { _PR_SIZE = value; } }

        String _PR_SOURCE;
        public String PR_SOURCE { get { return _PR_SOURCE; } set { _PR_SOURCE = value; } }

        String _LOCATION;
        public String LOCATION { get { return _LOCATION; } set { _LOCATION = value; } }

        String _PR_STATUS;
        public String PR_STATUS { get { return _PR_STATUS; } set { _PR_STATUS = value; } }

        String _BARCODE;
        public String BARCODE { get { return _BARCODE; } set { _BARCODE = value; } }

        String _REF;
        public String REF { get { return _REF; } set { _REF = value; } }

        String _CREATE_BY;
        public String CREATE_BY { get { return _CREATE_BY; } set { _CREATE_BY = value; } }

        String _CHECKIN_BY;
        public String CHECKIN_BY { get { return _CHECKIN_BY; } set { _CHECKIN_BY = value; } }

        DateTime? _L_UPDATE;
        public DateTime? L_UPDATE { get { return _L_UPDATE; } set { _L_UPDATE = value; } }

        String _ROOM_ID;
        public String ROOM_ID { get { return _ROOM_ID; } set { _ROOM_ID = value; } }

        Decimal? _PR_SUGAR;
        public Decimal? PR_SUGAR { get { return _PR_SUGAR; } set { _PR_SUGAR = value; } }

        Decimal? _PR_SALT;
        public Decimal? PR_SALT { get { return _PR_SALT; } set { _PR_SALT = value; } }

        Decimal? _PR_SORBITOL;
        public Decimal? PR_SORBITOL { get { return _PR_SORBITOL; } set { _PR_SORBITOL = value; } }

        Decimal? _PR_POLY_PHOSHATE;
        public Decimal? PR_POLY_PHOSHATE { get { return _PR_POLY_PHOSHATE; } set { _PR_POLY_PHOSHATE = value; } }

        String _PR_FRESHNESS;
        public String PR_FRESHNESS { get { return _PR_FRESHNESS; } set { _PR_FRESHNESS = value; } }

        String _REMARK;
        public String REMARK { get { return _REMARK; } set { _REMARK = value; } }

        //public string PR_LINE { get; set; }

        //public string PR_CONDITION { get; set; }

        //public decimal PR_WEIGHT { get; set; }

        //public DateTime? PR_PACK_DATE { get; set; }

        //public string PR_BOX_TYPE { get; set; }

        //public string PR_LINE_COLOR { get; set; }

        //public int? PR_UNIT { get; set; }

        //public string FISH_ID { get; set; }

        //public string PR_SIZE { get; set; }

        //public string PR_SOURCE { get; set; }

        //public string LOCATION { get; set; }

        //public string PR_STATUS { get; set; }

        //public string BARCODE { get; set; }

        //public string REF { get; set; }

        //public string CREATE_BY { get; set; }

        //public string CHECKIN_BY { get; set; }

        //public DateTime? L_UPDATE { get; set; }
        //public string ROOM_ID { get; set; }

        public List<MPO_PRODUCT> GetAll()
        {
            string _sql1 = "SELECT * FROM MPO_PRODUCT WHERE PR_STATUS is null";
            DataSet ds = DB_R2.GetDataSet(_sql1);
            return DataSetToList(ds);
        }


        public string GetProductName(string PR_LOT)
        {
            MPO_PRODUCT M = Get(PR_LOT);
            //Cut tom table
            string sql = "  SELECT FISH_ID||' '||NAME   FROM FISH WHERE FISH_ID='" + M.FISH_ID + M.PR_SIZE + "'";
            string  Name =DB_R2.FbExecuteScalar(sql);
            if (Name == "")
            {
                Name = M.FISH_ID + M.PR_SIZE + " (ไม่ระบุชื่อ)";
            } 
            return Name;
        }

        public MPO_PRODUCT Get(string PR_LOT)
        {
            string _sql1 = "SELECT * FROM MPO_PRODUCT WHERE PR_LOT=" + PR_LOT;
            DataSet ds = DB_R2.GetDataSet(_sql1);
            return DataSetToList(ds).FirstOrDefault();
        }

        public List<MPO_PRODUCT> GetForQc()
        {
            string _sql1 = "SELECT * FROM MPO_PRODUCT WHERE PR_STATUS ='P'";
            DataSet ds = DB_R2.GetDataSet(_sql1);
            return DataSetToList(ds);
        }

        public void QcReject(string PR_LOT)
        {
            string _sql1 = "UPDATE MPO_PRODUCT SET PR_STATUS =  'R' WHERE PR_LOT = " + PR_LOT;
            DB_R2.FbExecuteNonQuery(_sql1);
        }


        public void CalCelProductChekIn(string PR_LOT)
        {
            string _sql1 = "UPDATE  MPO_PRODUCT SET   PR_STATUS = 'N' WHERE   PR_LOT = " + PR_LOT;
            DB_R2.FbExecuteNonQuery(_sql1);
        }


        public void CutRefORder()
        {
            var prset = new List<IDataParameter>();
            string sql =
                "   UPDATE  MPO_PRODUCT SET   PR_UNIT = PR_UNIT -" + PR_UNIT + "  WHERE  PR_LOT = @PR_LOT;";
            //prset.Add(DB_R2.CreateParameterDb("@STK_ID", STK_ID));
            prset.Add(DB_R2.CreateParameterDb("@PR_LOT", REF));


            int output = DB_R2.FbExecuteNonQuery(sql, prset);

            int a = Convert.ToInt32(DB_R2.FbExecuteScalar("SELECT PR_UNIT  FROM MPO_PRODUCT WHERE  PR_LOT = @PR_LOT;"));

            if (a < 0)
            {
                throw new Exception("not enought items");
            }
        }


        public List<MPO_PRODUCT> GetAllForRecreate()
        {
            string _sql1 =
                "SELECT * FROM MPO_PRODUCT WHERE PR_STATUS='R' AND PR_UNIT>0 AND PR_LOT not    in (select  REF from MPO_PRODUCT where REF IS Not null)";
            DataSet ds = DB_R2.GetDataSet(_sql1);
            return DataSetToList(ds);
        }


        public List<MPO_PRODUCT> GetMyProduct(string User, string ITEMS)
        {
            string _sql1 =
                "SELECT FIRST " + ITEMS + " * FROM MPO_PRODUCT WHERE CREATE_BY='" + User + "' ORDER BY PR_LOT DESC ";
            DataSet ds = DB_R2.GetDataSet(_sql1);
            return DataSetToList(ds);
        }

        public int Save()
        {
            var prset = new List<IDataParameter>();
            var sql = "INSERT INTO MPO_PRODUCT(PR_LOT,PR_PRODUCE_DATE,PR_REV_DATE,PR_CUT_DATE,PR_LINE,PR_CONDITION,PR_WEIGHT,PR_PACK_DATE,PR_BOX_TYPE,PR_LINE_COLOR,PR_UNIT,FISH_ID,PR_SIZE,PR_SOURCE,LOCATION,PR_STATUS,BARCODE,REF,CREATE_BY,CHECKIN_BY,L_UPDATE,ROOM_ID,PR_SUGAR,PR_SALT,PR_SORBITOL,PR_POLY_PHOSHATE,PR_FRESHNESS,REMARK) VALUES (@PR_LOT,@PR_PRODUCE_DATE,@PR_REV_DATE,@PR_CUT_DATE,@PR_LINE,@PR_CONDITION,@PR_WEIGHT,@PR_PACK_DATE,@PR_BOX_TYPE,@PR_LINE_COLOR,@PR_UNIT,@FISH_ID,@PR_SIZE,@PR_SOURCE,@LOCATION,@PR_STATUS,@BARCODE,@REF,@CREATE_BY,@CHECKIN_BY,@L_UPDATE,@ROOM_ID,@PR_SUGAR,@PR_SALT,@PR_SORBITOL,@PR_POLY_PHOSHATE,@PR_FRESHNESS,@REMARK)returning  PR_LOT;";
            prset.Add(DB_R2.CreateParameterDb("@PR_LOT", PR_LOT)); prset.Add(DB_R2.CreateParameterDb("@PR_PRODUCE_DATE", PR_PRODUCE_DATE)); prset.Add(DB_R2.CreateParameterDb("@PR_REV_DATE", PR_REV_DATE)); prset.Add(DB_R2.CreateParameterDb("@PR_CUT_DATE", PR_CUT_DATE)); prset.Add(DB_R2.CreateParameterDb("@PR_LINE", PR_LINE)); prset.Add(DB_R2.CreateParameterDb("@PR_CONDITION", PR_CONDITION)); prset.Add(DB_R2.CreateParameterDb("@PR_WEIGHT", PR_WEIGHT)); prset.Add(DB_R2.CreateParameterDb("@PR_PACK_DATE", PR_PACK_DATE)); prset.Add(DB_R2.CreateParameterDb("@PR_BOX_TYPE", PR_BOX_TYPE)); prset.Add(DB_R2.CreateParameterDb("@PR_LINE_COLOR", PR_LINE_COLOR)); prset.Add(DB_R2.CreateParameterDb("@PR_UNIT", PR_UNIT)); prset.Add(DB_R2.CreateParameterDb("@FISH_ID", FISH_ID)); prset.Add(DB_R2.CreateParameterDb("@PR_SIZE", PR_SIZE)); prset.Add(DB_R2.CreateParameterDb("@PR_SOURCE", PR_SOURCE)); prset.Add(DB_R2.CreateParameterDb("@LOCATION", LOCATION)); prset.Add(DB_R2.CreateParameterDb("@PR_STATUS", PR_STATUS)); prset.Add(DB_R2.CreateParameterDb("@BARCODE", BARCODE)); prset.Add(DB_R2.CreateParameterDb("@REF", REF)); prset.Add(DB_R2.CreateParameterDb("@CREATE_BY", CREATE_BY)); prset.Add(DB_R2.CreateParameterDb("@CHECKIN_BY", CHECKIN_BY)); prset.Add(DB_R2.CreateParameterDb("@L_UPDATE", L_UPDATE)); prset.Add(DB_R2.CreateParameterDb("@ROOM_ID", ROOM_ID)); prset.Add(DB_R2.CreateParameterDb("@PR_SUGAR", PR_SUGAR)); prset.Add(DB_R2.CreateParameterDb("@PR_SALT", PR_SALT)); prset.Add(DB_R2.CreateParameterDb("@PR_SORBITOL", PR_SORBITOL)); prset.Add(DB_R2.CreateParameterDb("@PR_POLY_PHOSHATE", PR_POLY_PHOSHATE)); prset.Add(DB_R2.CreateParameterDb("@PR_FRESHNESS", PR_FRESHNESS)); prset.Add(DB_R2.CreateParameterDb("@REMARK", REMARK));

            int output = 0;
            try
            {
                DB_R2.OpenFbData();
                DB_R2.BeginTransaction();
                output = Convert.ToInt32(DB_R2.FbExecuteScalar(sql, prset));
                if (REF != null) //กรีไม่มี Ref
                    CutRefORder();

                DB_R2.CommitTransaction();
            }
            catch (Exception e)
            {
                ErrorLogging.LogError(e, "");
                DB_R2.RollBackTransaction();
                throw e;
            }


            return output;
        }

        //public int Save()
        //{
        //    var prset = new List<IDataParameter>();
        //    string sql =
        //        "INSERT INTO MPO_PRODUCT(PR_LOT,PR_PRODUCE_DATE,PR_REV_DATE,PR_CUT_DATE,PR_LINE,PR_CONDITION,PR_WEIGHT,PR_PACK_DATE,PR_BOX_TYPE,PR_LINE_COLOR,PR_UNIT,FISH_ID,PR_SIZE,PR_SOURCE,BARCODE,REF,CREATE_BY) VALUES (@PR_LOT,@PR_PRODUCE_DATE,@PR_REV_DATE,@PR_CUT_DATE,@PR_LINE,@PR_CONDITION,@PR_WEIGHT,@PR_PACK_DATE,@PR_BOX_TYPE,@PR_LINE_COLOR,@PR_UNIT,@FISH_ID,@PR_SIZE,@PR_SOURCE,@BARCODE,@REF,@CREATE_BY)returning  PR_LOT;";
        //    prset.Add(DB_R2.CreateParameterDb("@PR_LOT", PR_LOT));
        //    prset.Add(DB_R2.CreateParameterDb("@PR_PRODUCE_DATE", PR_PRODUCE_DATE));
        //    prset.Add(DB_R2.CreateParameterDb("@PR_REV_DATE", PR_REV_DATE));
        //    prset.Add(DB_R2.CreateParameterDb("@PR_CUT_DATE", PR_CUT_DATE));
        //    prset.Add(DB_R2.CreateParameterDb("@PR_LINE", PR_LINE));
        //    prset.Add(DB_R2.CreateParameterDb("@PR_CONDITION", PR_CONDITION));
        //    prset.Add(DB_R2.CreateParameterDb("@PR_WEIGHT", PR_WEIGHT));
        //    prset.Add(DB_R2.CreateParameterDb("@PR_PACK_DATE", PR_PACK_DATE));
        //    prset.Add(DB_R2.CreateParameterDb("@PR_BOX_TYPE", PR_BOX_TYPE));
        //    prset.Add(DB_R2.CreateParameterDb("@PR_LINE_COLOR", PR_LINE_COLOR));
        //    prset.Add(DB_R2.CreateParameterDb("@PR_UNIT", PR_UNIT));
        //    prset.Add(DB_R2.CreateParameterDb("@FISH_ID", FISH_ID));
        //    prset.Add(DB_R2.CreateParameterDb("@PR_SIZE", PR_SIZE));
        //    prset.Add(DB_R2.CreateParameterDb("@PR_SOURCE", PR_SOURCE));
        //    prset.Add(DB_R2.CreateParameterDb("@BARCODE", GenBarCode()));
        //    prset.Add(DB_R2.CreateParameterDb("@REF", REF));
        //    prset.Add(DB_R2.CreateParameterDb("@CREATE_BY", StkUser.GetCurrentUser()));

        //    int output = 0;
        //    try
        //    {
        //        DB_R2.OpenFbData();
        //        DB_R2.BeginTransaction();
        //        output = Convert.ToInt32(DB_R2.FbExecuteScalar(sql, prset));
        //        if (REF != null) //กรีไม่มี Ref
        //            CutRefORder();

        //        DB_R2.CommitTransaction();
        //    }
        //    catch (Exception e)
        //    {
        //        ErrorLogging.LogError(e, "");
        //        DB_R2.RollBackTransaction();
        //        throw e;
        //    }


        //    return output;
        //}


        public DataSet Search()
        {
            string sql = "SELECT *    FROM MPO_PRODUCT  ";

            sql = AddCateria(sql);

            return DB_R2.GetDataSet(sql);
        }

        private string AddCateria(string sql)
        {
            sql += string.Format(" WHERE (''='') ");
            if (PR_LOT != null)
            {
                sql += string.Format(" AND  ((''='{0}') or (PR_LOT='{0}') )", PR_LOT);
            }
            if (PR_PRODUCE_DATE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_PRODUCE_DATE='{0}') )", PR_PRODUCE_DATE);
            }
            if (PR_REV_DATE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_REV_DATE='{0}') )", PR_REV_DATE);
            }
            if (PR_CUT_DATE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_CUT_DATE='{0}') )", PR_CUT_DATE);
            }
            if (PR_LINE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_LINE='{0}') )", PR_LINE);
            }
            if (PR_CONDITION != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_CONDITION='{0}') )", PR_CONDITION);
            }
            //if (PR_WEIGHT != null)
            //{
            //    sql += string.Format(" AND ((''='{0}') or (PR_WEIGHT='{0}') )", PR_WEIGHT);
            //}
            if (PR_PACK_DATE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_PACK_DATE='{0}') )", PR_PACK_DATE);
            }
            if (PR_BOX_TYPE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_BOX_TYPE='{0}') )", PR_BOX_TYPE);
            }
            if (PR_LINE_COLOR != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_LINE_COLOR='{0}') )", PR_LINE_COLOR);
            }
            if (PR_UNIT != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_UNIT='{0}') )", PR_UNIT);
            }
            if (FISH_ID != null)
            {
                sql += string.Format(" AND ((''='{0}') or (FISH_ID='{0}') )", FISH_ID);
            }
            if (PR_SIZE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_SIZE='{0}') )", PR_SIZE);
            }
            if (PR_SOURCE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_SOURCE='{0}') )", PR_SOURCE);
            }
            if (LOCATION != null)
            {
                sql += string.Format(" AND ((''='{0}') or (LOCATION='{0}') )", LOCATION);
            }
            if (PR_STATUS != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_STATUS='{0}') )", PR_STATUS);
            }
            if (BARCODE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (BARCODE='{0}') )", BARCODE);
            }
            if (REF != null)
            {
                sql += string.Format(" AND ((''='{0}') or (REF='{0}') )", REF);
            }
            if (CREATE_BY != null)
            {
                sql += string.Format(" AND ((''='{0}') or (CREATE_BY='{0}') )", CREATE_BY);
            }
            if (CHECKIN_BY != null)
            {
                sql += string.Format(" AND ((''='{0}') or (CHECKIN_BY='{0}') )", CHECKIN_BY);
            }
            if (L_UPDATE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (L_UPDATE='{0}') )", L_UPDATE);
            }
            return sql;
        }

        //ไม่ใช้
        private string GenBarCode()
        {
            var culture = new CultureInfo("en-US", false);
            string Dmy = DateTime.Now.ToString("ddMMyyyy", culture);
            return Dmy + "-" + FISH_ID + "-" + PR_SIZE + "-" + PR_LOT;
        }

        public bool AssignPrestock(string PR_LOT, string LOCATION, string ROOM_ID)
        {
            bool b = false;
            var prset = new List<IDataParameter>();
            string sql =
                "  UPDATE  MPO_PRODUCT SET    LOCATION = @LOCATION,ROOM_ID=@ROOM_ID , PR_STATUS = @PR_STATUS,CHECKIN_BY=@CHECKIN_BY WHERE  PR_LOT = @PR_LOT;";
            prset.Add(DB_R2.CreateParameterDb("@PR_LOT", PR_LOT));
            prset.Add(DB_R2.CreateParameterDb("@LOCATION", LOCATION));
            prset.Add(DB_R2.CreateParameterDb("@ROOM_ID", ROOM_ID));
            prset.Add(DB_R2.CreateParameterDb("@PR_STATUS", "P"));
            prset.Add(DB_R2.CreateParameterDb("@CHECKIN_BY", StkUser.GetCurrentUser()));


            int output = DB_R2.FbExecuteNonQuery(sql, prset);
            if (output != 1)
            {
                throw new Exception("Save" + ToString());
            }
            b = false;
            return b;
        }


        public DataSet GetStockByLocation(string _LOCATION_ID)
        {
            string sql =
                //   "SELECT * FROM MPO_PRODUCT WHERE ((PR_STATUS='P') OR (PR_STATUS='C') ) AND LOCATION='" + _LOCATION_ID + "'";
                "SELECT * FROM MPO_PRODUCT LEFT JOIN  MPO_STOCK ON MPO_STOCK.PR_LOT =  MPO_PRODUCT.PR_LOT WHERE (MPO_STOCK.ITEMS > 0 OR MPO_STOCK.ITEMS is null)AND ((PR_STATUS='P') OR (PR_STATUS='C') ) AND LOCATION='" +
                _LOCATION_ID + "'";
            return DB_R2.GetDataSet(sql);
        }


        public List<MPO_PRODUCT> DataSetToList(DataSet ds)
        {
            EnumerableRowCollection<MPO_PRODUCT> q = (from temp in ds.Tables[0].AsEnumerable()
                                                      select new MPO_PRODUCT
                                                      {
                                                          //PR_LOT = temp.Field<Int32?>("PR_LOT"),
                                                          //PR_PRODUCE_DATE = temp.Field<DateTime?>("PR_PRODUCE_DATE"),
                                                          //PR_REV_DATE = temp.Field<DateTime?>("PR_REV_DATE"),
                                                          //PR_CUT_DATE = temp.Field<DateTime?>("PR_CUT_DATE"),
                                                          //PR_LINE = temp.Field<String>("PR_LINE"),
                                                          //PR_CONDITION = temp.Field<String>("PR_CONDITION"),
                                                          //PR_WEIGHT = temp.Field<Decimal>("PR_WEIGHT"),
                                                          //PR_PACK_DATE = temp.Field<DateTime?>("PR_PACK_DATE"),
                                                          //PR_BOX_TYPE = temp.Field<String>("PR_BOX_TYPE"),
                                                          //PR_LINE_COLOR = temp.Field<String>("PR_LINE_COLOR"),
                                                          //PR_UNIT = temp.Field<Int32?>("PR_UNIT"),
                                                          //FISH_ID = temp.Field<String>("FISH_ID"),
                                                          //PR_SIZE = temp.Field<String>("PR_SIZE"),
                                                          //PR_SOURCE = temp.Field<String>("PR_SOURCE"),
                                                          //LOCATION = temp.Field<String>("LOCATION"),
                                                          //PR_STATUS = temp.Field<String>("PR_STATUS"),
                                                          //BARCODE = temp.Field<String>("BARCODE"),
                                                          //REF = temp.Field<String>("REF"),
                                                          //CREATE_BY = temp.Field<String>("CREATE_BY"),
                                                          //CHECKIN_BY = temp.Field<String>("CHECKIN_BY"),
                                                          //L_UPDATE = temp.Field<DateTime?>("L_UPDATE"),
                                                          //ROOM_ID = temp.Field<string>("ROOM_ID"),

                                                          PR_LOT = temp.Field<Int32?>("PR_LOT"),
                                                          PR_PRODUCE_DATE = temp.Field<DateTime?>("PR_PRODUCE_DATE"),
                                                          PR_REV_DATE = temp.Field<DateTime?>("PR_REV_DATE"),
                                                          PR_CUT_DATE = temp.Field<DateTime?>("PR_CUT_DATE"),
                                                          PR_LINE = temp.Field<String>("PR_LINE"),
                                                          PR_CONDITION = temp.Field<String>("PR_CONDITION"),
                                                          PR_WEIGHT = temp.Field<Decimal?>("PR_WEIGHT"),
                                                          PR_PACK_DATE = temp.Field<DateTime?>("PR_PACK_DATE"),
                                                          PR_BOX_TYPE = temp.Field<String>("PR_BOX_TYPE"),
                                                          PR_LINE_COLOR = temp.Field<String>("PR_LINE_COLOR"),
                                                          PR_UNIT = temp.Field<Int32?>("PR_UNIT"),
                                                          FISH_ID = temp.Field<String>("FISH_ID"),
                                                          PR_SIZE = temp.Field<String>("PR_SIZE"),
                                                          PR_SOURCE = temp.Field<String>("PR_SOURCE"),
                                                          LOCATION = temp.Field<String>("LOCATION"),
                                                          PR_STATUS = temp.Field<String>("PR_STATUS"),
                                                          BARCODE = temp.Field<String>("BARCODE"),
                                                          REF = temp.Field<String>("REF"),
                                                          CREATE_BY = temp.Field<String>("CREATE_BY"),
                                                          CHECKIN_BY = temp.Field<String>("CHECKIN_BY"),
                                                          L_UPDATE = temp.Field<DateTime?>("L_UPDATE"),
                                                          ROOM_ID = temp.Field<String>("ROOM_ID"),
                                                          PR_SUGAR = temp.Field<Decimal?>("PR_SUGAR"),
                                                          PR_SALT = temp.Field<Decimal?>("PR_SALT"),
                                                          PR_SORBITOL = temp.Field<Decimal?>("PR_SORBITOL"),
                                                          PR_POLY_PHOSHATE = temp.Field<Decimal?>("PR_POLY_PHOSHATE"),
                                                          PR_FRESHNESS = temp.Field<String>("PR_FRESHNESS"),
                                                          REMARK = temp.Field<String>("REMARK"),

                                                      });
            return q.ToList();
        }
    }
}