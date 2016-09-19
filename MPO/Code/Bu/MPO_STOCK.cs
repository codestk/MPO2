using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using Stk.Base;
using Stk.Common;

namespace MPO.Code.Bu
{
    public class MPO_STOCK : Stk_BuBase_R2
    {
        public MPO_PRODUCT _MPO_PRODUCT;
        public int? STK_ID { get; set; }

        public int? PR_LOT { get; set; }

        public string GRADE { get; set; }

        public string STOCK { get; set; }

        public string REMARK { get; set; }

        public int? ITEMS { get; set; }

        public string BARCODE_STOCK { get; set; }

        public string QC_BY { get; set; }

        public DateTime? QC_DATE { get; set; }

        public decimal? JELLY_ST { get; set; }

        public decimal? KUBOMI { get; set; }

        public decimal? COLOR { get; set; }

        public decimal? SPOT { get; set; }

        public decimal? DARN { get; set; }

        public decimal? ODOUR { get; set; }

        public decimal? MOISTURE { get; set; }

        public decimal? PH { get; set; }


        /// <summary>
        ///     For Flietre Command
        /// </summary>
        public string MOISTURE_Filter { get; set; }

        public string PH_Filter { get; set; }
        public string JellySt_Filter { get; set; }
        public string COLOR_Filter { get; set; }
        public string Odour_Filter { get; set; }
        public string Spot_Filter { get; set; }
        public string Darn_Filter { get; set; }
        public string Kubomi_Filter { get; set; }


        public void QCSAVE()
        {
            try
            {
                DB_R2.OpenFbData();
                DB_R2.BeginTransaction();

                SaveData();
                FlageProductComplete();
                //  CutPreORder();


                DB_R2.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB_R2.RollBackTransaction();
                throw ex;
            }
        }

        private void FlageProductComplete()
        {
            var prset = new List<IDataParameter>();
            string sql =
                "   UPDATE  MPO_PRODUCT SET    PR_STATUS='C' WHERE  PR_LOT = @PR_LOT;";
            //prset.Add(DB_R2.CreateParameterDb("@STK_ID", STK_ID));
            prset.Add(DB_R2.CreateParameterDb("@PR_LOT", PR_LOT));

            int output = DB_R2.FbExecuteNonQuery(sql, prset);
        }

        private void CutPreORder()
        {
            var prset = new List<IDataParameter>();
            string sql =
                "   UPDATE  MPO_PRODUCT SET   PR_UNIT = PR_UNIT -" + ITEMS + " ,PR_STATUS='P' WHERE  PR_LOT = @PR_LOT;";
            //prset.Add(DB_R2.CreateParameterDb("@STK_ID", STK_ID));
            prset.Add(DB_R2.CreateParameterDb("@PR_LOT", PR_LOT));


            int output = DB_R2.FbExecuteNonQuery(sql, prset);

            int a = Convert.ToInt32(DB_R2.FbExecuteScalar("SELECT PR_UNIT  FROM MPO_PRODUCT WHERE  PR_LOT = @PR_LOT;"));

            if (a < 0)
            {
                throw new Exception("not enought items");
            }
        }

        private void SaveData()
        {
            var prset = new List<IDataParameter>();
            string sql =
                "INSERT INTO MPO_STOCK(PR_LOT,MOISTURE,PH,JELLY_ST,COLOR,ODOUR,SPOT,GRADE,STOCK,REMARK,DARN,KUBOMI,ITEMS,BARCODE_STOCK,QC_BY,QC_DATE) VALUES (@PR_LOT,@MOISTURE,@PH,@JELLY_ST,@COLOR,@ODOUR,@SPOT,@GRADE,@STOCK,@REMARK,@DARN,@KUBOMI,@ITEMS,@BARCODE_STOCK||'-'||(GEN_ID( GEN_MPO_LOT_ID, 0 ) +1),@QC_BY,@QC_DATE) returning  STK_ID;";
            //prset.Add(DB_R2.CreateParameterDb("@STK_ID", STK_ID));
            prset.Add(DB_R2.CreateParameterDb("@PR_LOT", PR_LOT));
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
            prset.Add(DB_R2.CreateParameterDb("@ITEMS", ITEMS));


            prset.Add(DB_R2.CreateParameterDb("@BARCODE_STOCK", GenBarCode()));

            prset.Add(DB_R2.CreateParameterDb("@QC_BY", QC_BY));

            prset.Add(DB_R2.CreateParameterDb("@QC_DATE", Convert.ToDateTime(QC_DATE)));


            int output = Convert.ToInt32(DB_R2.FbExecuteScalar(sql, prset));
            //if (output != 1)
            //{
            //    throw new Exception("Save" + ToString());
            //}


            STK_ID = output;
        }


        /// <summary>
        ///     Lot ของผลิต ขอเป็นรหัสดังนี้
        ///     รหัสปลา + ความสดของปลา + ขนาดปลา + dd/mm/yy ที่ผลิต + Lot Automatic
        /// </summary>
        /// <returns></returns>
        private string GenBarCode()
        {
            var culture = new CultureInfo("en-US", false);
            string Dmy = DateTime.Now.ToString("ddMMyyyy", culture);

            var mop = new MPO_PRODUCT();
            mop = mop.Get(PR_LOT.ToString());
            // return Dmy + "-" + mop.FISH_ID + "-" + mop.PR_SIZE + "-" + PR_LOT.ToString();
            return mop.FISH_ID + mop.PR_FRESHNESS + mop.PR_SIZE + Dmy;
        }


        public DataSet Search()
        {
            string sql =
                "SELECT *    FROM MPO_STOCK inner join  MPO_PRODUCT on MPO_STOCK.PR_LOT= MPO_PRODUCT.PR_LOT AND ITEMS>0 ";

            sql = AddCateriaStock(sql);



            if (_MPO_PRODUCT != null)
                sql = AddCateriaProduct(sql);

            //Add Order for sum
            sql += " ORDER BY MPO_PRODUCT.FISH_ID; ";
            return DB_R2.GetDataSet(sql);
        }

        public DataSet GetMyQc(string userCurrent, string Curentitem)
        {
            string sql = "SELECT  FIRST " + Curentitem +
                         " *    FROM MPO_STOCK inner join  MPO_PRODUCT on MPO_STOCK.PR_LOT= MPO_PRODUCT.PR_LOT  AND QC_BY='" +
                         userCurrent + "'";


            return DB_R2.GetDataSet(sql);
        }

        public DataSet SearchAllCondition()
        {
            string sql = "SELECT *    FROM MPO_STOCK inner join  MPO_PRODUCT on MPO_STOCK.PR_LOT= MPO_PRODUCT.PR_LOT";

            sql = AddCateriaStock(sql);

            if (_MPO_PRODUCT != null)
                sql = AddCateriaProduct(sql);

            return DB_R2.GetDataSet(sql);
        }

        private string AddCateriaStock(string sql)
        {
            if (STK_ID != null)
            {
                sql += string.Format(" AND ((''='{0}') or (STK_ID='{0}') )", STK_ID);
            }

            if (MOISTURE_Filter != null)
            {
                string[] temp = MOISTURE_Filter.Split('|');

                sql += string.Format(" AND  ( KUBOMI >={0} AND KUBOMI <= {1})", temp[0], temp[1]);
            }
            if (PH_Filter != null)
            {
                // sql += string.Format(" AND ((''='{0}') or (PH='{0}') )", PH);
                string[] temp = PH_Filter.Split('|');
                sql += string.Format(" AND  ( PH >={0} AND PH <= {1})", temp[0], temp[1]);
            }
            if (JellySt_Filter != null)
            {
                // sql += string.Format(" AND ((''='{0}') or (JELLY_ST='{0}') )", JELLY_ST);
                string[] temp = JellySt_Filter.Split('|');
                sql += string.Format(" AND  ( JELLY_ST >={0} AND JELLY_ST <= {1})", temp[0], temp[1]);
            }
            if (COLOR_Filter != null)
            {
                // sql += string.Format(" AND ((''='{0}') or (COLOR='{0}') )", COLOR);
                string[] temp = COLOR_Filter.Split('|');
                sql += string.Format(" AND  ( COLOR >={0} AND COLOR <= {1})", temp[0], temp[1]);
            }
            if (Odour_Filter != null)
            {
                string[] temp = Odour_Filter.Split('|');
                //  sql += string.Format(" AND ((''='{0}') or (ODOUR='{0}') )", ODOUR);
                sql += string.Format(" AND  ( ODOUR >={0} AND ODOUR <= {1})", temp[0], temp[1]);
            }
            if (Spot_Filter != null)
            {
                string[] temp = Spot_Filter.Split('|');
                //sql += string.Format(" AND ((''='{0}') or (SPOT='{0}') )", SPOT);
                sql += string.Format(" AND  ( SPOT >={0} AND SPOT <= {1})", temp[0], temp[1]);
            }

            if (Darn_Filter != null)
            {
                string[] temp = Darn_Filter.Split('|');
                //  sql += string.Format(" AND ((''='{0}') or (DARN='{0}') )", DARN);
                sql += string.Format(" AND  ( DARN >={0} AND DARN <= {1})", temp[0], temp[1]);
            }
            if (Kubomi_Filter != null)
            {
                string[] temp = Kubomi_Filter.Split('|');
                //sql += string.Format(" AND ((''='{0}') or (KUBOMI='{0}') )", KUBOMI);
                sql += string.Format(" AND  ( KUBOMI >={0} AND KUBOMI <= {1})", temp[0], temp[1]);
            }


            if (GRADE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (GRADE='{0}') )", GRADE);
            }
            if (STOCK != null)
            {
                sql += string.Format(" AND ((''='{0}') or (STOCK='{0}') )", STOCK);
            }



            return sql;
        }

        private string AddCateriaProduct(string sql)
        {
            //if (PR_LOT != null)
            //{
            //    sql += string.Format(" AND ((''='{0}') or (PR_LOT='{0}') )", PR_LOT);
            //}
            if (_MPO_PRODUCT.PR_PRODUCE_DATE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_PRODUCE_DATE='{0}') )", _MPO_PRODUCT.PR_PRODUCE_DATE);
            }
            if (_MPO_PRODUCT.PR_REV_DATE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_REV_DATE='{0}') )", _MPO_PRODUCT.PR_REV_DATE);
            }
            if (_MPO_PRODUCT.PR_CUT_DATE != null)
            {
                // StkDate.ConvertDateEnForDb(Convert.ToDateTime(FromDate)
                sql += string.Format(" AND ((''='{0}') or (PR_CUT_DATE='{0}') )", _MPO_PRODUCT.PR_CUT_DATE);
            }
            if (_MPO_PRODUCT.PR_LINE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_LINE='{0}') )", _MPO_PRODUCT.PR_LINE);
            }
            if (_MPO_PRODUCT.PR_CONDITION != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_CONDITION='{0}') )", _MPO_PRODUCT.PR_CONDITION);
            }
            //if (_MPO_PRODUCT.PR_WEIGHT != null)
            //{
            //    sql += string.Format(" AND ((''='{0}') or (PR_WEIGHT='{0}') )", _MPO_PRODUCT.PR_WEIGHT);
            //}
            if (_MPO_PRODUCT.PR_PACK_DATE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_PACK_DATE='{0}') )",
                    StkDate.ConvertDateEnForDb(Convert.ToDateTime(_MPO_PRODUCT.PR_PACK_DATE)));
            }
            if (_MPO_PRODUCT.PR_BOX_TYPE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_BOX_TYPE='{0}') )", _MPO_PRODUCT.PR_BOX_TYPE);
            }
            if (_MPO_PRODUCT.PR_LINE_COLOR != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_LINE_COLOR='{0}') )", _MPO_PRODUCT.PR_LINE_COLOR);
            }
            if (_MPO_PRODUCT.PR_UNIT != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_UNIT='{0}') )", _MPO_PRODUCT.PR_UNIT);
            }
            if (_MPO_PRODUCT.FISH_ID != null)
            {
                sql += string.Format(" AND ((''='{0}') or (FISH_ID='{0}') )", _MPO_PRODUCT.FISH_ID);
            }
            if (_MPO_PRODUCT.PR_SIZE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_SIZE='{0}') )", _MPO_PRODUCT.PR_SIZE);
            }
            if (_MPO_PRODUCT.PR_SOURCE != null)
            {
                sql += string.Format(" AND ((''='{0}') or (PR_SOURCE='{0}') )", _MPO_PRODUCT.PR_SOURCE);
            }
            if (_MPO_PRODUCT.LOCATION != null)
            {
                sql += string.Format(" AND ((''='{0}') or (LOCATION='{0}') )", _MPO_PRODUCT.LOCATION);
            }
            //if (_MPO_PRODUCT.PR_STATUS != null)
            //{
            //    sql += string.Format(" AND ((''='{0}') or (PR_STATUS='{0}') )", PR_STATUS);
            //}
            //if (BARCODE != null)
            //{
            //    sql += string.Format(" AND ((''='{0}') or (BARCODE='{0}') )", BARCODE);
            //}
            //if (REF != null)
            //{
            //    sql += string.Format(" AND ((''='{0}') or (REF='{0}') )", REF);
            //}
            //if (CREATE_BY != null)
            //{
            //    sql += string.Format(" AND ((''='{0}') or (CREATE_BY='{0}') )", CREATE_BY);
            //}
            //if (CHECKIN_BY != null)
            //{
            //    sql += string.Format(" AND ((''='{0}') or (CHECKIN_BY='{0}') )", CHECKIN_BY);
            //}
            return sql;
        }

        public MPO_STOCK GetStockItems(string STK_ID)
        {
            string sql =
                "SELECT *    FROM MPO_STOCK inner join  MPO_PRODUCT on MPO_STOCK.PR_LOT= MPO_PRODUCT.PR_LOT WHERE STK_ID=" +
                STK_ID;

            var stock = new MPO_STOCK();

            DataSet ds = DB_R2.GetDataSet(sql);
            stock = DataSetToList(ds).FirstOrDefault();


            var product = new MPO_PRODUCT();
            product = product.DataSetToList(ds).FirstOrDefault();

            stock._MPO_PRODUCT = product;
            return stock;
        }


        public MPO_STOCK GetStockItemsByPR_LOT(string PR_LOT)
        {
            string sql =
                "SELECT *    FROM MPO_STOCK inner join  MPO_PRODUCT on MPO_STOCK.PR_LOT= MPO_PRODUCT.PR_LOT WHERE MPO_PRODUCT.PR_LOT='" +
                PR_LOT + "'";

            var stock = new MPO_STOCK();

            DataSet ds = DB_R2.GetDataSet(sql);
            stock = DataSetToList(ds).FirstOrDefault();


            var product = new MPO_PRODUCT();
            product = product.DataSetToList(ds).FirstOrDefault();

            stock._MPO_PRODUCT = product;
            return stock;
        }


        private List<MPO_STOCK> DataSetToList(DataSet ds)
        {
            EnumerableRowCollection<MPO_STOCK> q = (from temp in ds.Tables[0].AsEnumerable()
                                                    select new MPO_STOCK
                                                    {
                                                        STK_ID = temp.Field<Int32?>("STK_ID"),
                                                        PR_LOT = temp.Field<Int32?>("PR_LOT"),
                                                        GRADE = temp.Field<String>("GRADE"),
                                                        STOCK = temp.Field<String>("STOCK"),
                                                        REMARK = temp.Field<String>("REMARK"),
                                                        ITEMS = temp.Field<Int32?>("ITEMS"),
                                                        BARCODE_STOCK = temp.Field<String>("BARCODE_STOCK"),
                                                        QC_BY = temp.Field<String>("QC_BY"),
                                                        QC_DATE = temp.Field<DateTime?>("QC_DATE"),
                                                        JELLY_ST = temp.Field<Decimal?>("JELLY_ST"),
                                                        KUBOMI = temp.Field<Decimal?>("KUBOMI"),
                                                        COLOR = temp.Field<Decimal?>("COLOR"),
                                                        SPOT = temp.Field<Decimal?>("SPOT"),
                                                        DARN = temp.Field<Decimal?>("DARN"),
                                                        ODOUR = temp.Field<Decimal?>("ODOUR"),
                                                        MOISTURE = temp.Field<Decimal?>("MOISTURE"),
                                                        PH = temp.Field<Decimal?>("PH"),
                                                    });
            return q.ToList();
        }
    }
}