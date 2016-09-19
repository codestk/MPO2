using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Stk.Base;
using Stk.Common;

namespace MPO.Code.Bu
{
    public class MPO_ODERDETAILS : Stk_BuBase_R2
    {
        public int? ORDE_ID { get; set; }

        public int? OR_ID { get; set; }

        public int? STK_ID { get; set; }

        public int PR_LOT { get; set; }

        public int ITEMS { get; set; }

        public decimal COST { get; set; }

        public DateTime? LOADINGDATE { get; set; }

        public string SHIPMENTNO { get; set; }

        public string CONTAINERNO { get; set; }

        public string TRUCKNO { get; set; }

        public string STAMP { get; set; }

        public string STATUS { get; set; }

        public string STATUS_CURRENT { get; set; }


        public DateTime? CHECKOUT_DATE { get; set; }

        public string CHECKOUT_BY { get; set; }


        public void Save(int OR_ID, DataTable dt)
        {

            foreach (DataRow row in dt.Rows)
            {


                var prset = new List<IDataParameter>();
                string sql =
                    "INSERT INTO MPO_ODERDETAILS(OR_ID,STK_ID,PR_LOT,ITEMS,COST,LOADINGDATE,SHIPMENTNO,CONTAINERNO,TRUCKNO,STAMP,STATUS,STATUS_CURRENT) VALUES (@OR_ID,@STK_ID,@PR_LOT,@ITEMS,@COST,@LOADINGDATE,@SHIPMENTNO,@CONTAINERNO,@TRUCKNO,@STAMP,@STATUS,@STATUS_CURRENT) returning  ORDE_ID;";
                prset.Add(DB_R2.CreateParameterDb("@OR_ID", OR_ID));

                prset.Add(DB_R2.CreateParameterDb("@STK_ID", row["STK_ID"]));
                prset.Add(DB_R2.CreateParameterDb("@PR_LOT", row["PR_LOT"]));
                prset.Add(DB_R2.CreateParameterDb("@ITEMS", row["ITEMS"]));
                prset.Add(DB_R2.CreateParameterDb("@COST", row["COST"]));
                prset.Add(DB_R2.CreateParameterDb("@LOADINGDATE", StkDate.TextToDateThToEn(row["LOADINGDATE"].ToString())));
                prset.Add(DB_R2.CreateParameterDb("@SHIPMENTNO", row["SHIPMENTNO"]));
                prset.Add(DB_R2.CreateParameterDb("@CONTAINERNO", row["CONTAINERNO"]));
                prset.Add(DB_R2.CreateParameterDb("@TRUCKNO", row["TRUCKNO"]));
                prset.Add(DB_R2.CreateParameterDb("@STAMP", row["STAMP"]));
                prset.Add(DB_R2.CreateParameterDb("@STATUS", row["STATUS"]));
                prset.Add(DB_R2.CreateParameterDb("@STATUS_CURRENT", ""));

                ITEMS vItems=new ITEMS();
       
                vItems.validateItems(row["STK_ID"].ToString(), row["ITEMS"].ToString());



                int output = DB_R2.FbExecuteNonQuery(sql, prset);
                if (output != 1)
                {
                    throw new Exception("Save" + ToString());
                }
            }
        }


        public void Update(int OR_ID, DataTable dt)
        {

            foreach (DataRow row in dt.Rows)
            {


                var prset = new List<IDataParameter>();
                string sql =
                    "UPDATE  MPO_ODERDETAILS SET  STK_ID = @STK_ID,  PR_LOT = @PR_LOT,  ITEMS = @ITEMS,  COST = @COST,  LOADINGDATE = @LOADINGDATE,  SHIPMENTNO = @SHIPMENTNO,  CONTAINERNO = @CONTAINERNO,  TRUCKNO = @TRUCKNO,  STAMP = @STAMP,  STATUS = @STATUS  WHERE  ORDE_ID = @ORDE_ID AND  OR_ID = @OR_ID;";
                prset.Add(DB_R2.CreateParameterDb("@OR_ID", OR_ID));

                prset.Add(DB_R2.CreateParameterDb("@STK_ID", row["STK_ID"]));
                prset.Add(DB_R2.CreateParameterDb("@PR_LOT", row["PR_LOT"]));
                prset.Add(DB_R2.CreateParameterDb("@ITEMS", row["ITEMS"]));
                prset.Add(DB_R2.CreateParameterDb("@COST", row["COST"]));
                prset.Add(DB_R2.CreateParameterDb("@LOADINGDATE", StkDate.TextToDateThToEn(row["LOADINGDATE"].ToString())));
                prset.Add(DB_R2.CreateParameterDb("@SHIPMENTNO", row["SHIPMENTNO"]));
                prset.Add(DB_R2.CreateParameterDb("@CONTAINERNO", row["CONTAINERNO"]));
                prset.Add(DB_R2.CreateParameterDb("@TRUCKNO", row["TRUCKNO"]));
                prset.Add(DB_R2.CreateParameterDb("@STAMP", row["STAMP"]));
                    prset.Add(DB_R2.CreateParameterDb("@STATUS", row["STATUS"]));
                    prset.Add(DB_R2.CreateParameterDb("@OR_ID", OR_ID));
                       prset.Add(DB_R2.CreateParameterDb("@ORDE_ID", row["ORDE_ID"]));
                
                //prset.Add(DB_R2.CreateParameterDb("@STATUS_CURRENT", ""));

               // ITEMS vItems = new ITEMS();

               //vItems.validateItems(row["STK_ID"].ToString(), row["ITEMS"].ToString());



                int output = DB_R2.FbExecuteNonQuery(sql, prset);
                if (output != 1)
                {
                    throw new Exception("Update" + ToString());
                }
            }
        }

        public DataSet GetORder(string or_id)
        {
           // string _sql1 = "SELECT * FROM MPO_ODERDETAILS WHERE OR_ID=" + or_id;

            string _sql1 = "SELECT  ORDE_ID, OR_ID, STK_ID, PR_LOT, ITEMS, COST, cast( (ITEMS*COST) as decimal)  AS \"TOTAL\", LOADINGDATE, SHIPMENTNO, CONTAINERNO, TRUCKNO, STAMP, STATUS, STATUS_CURRENT, CHECK_OUT,CHECKOUT_BY FROM MPO_ODERDETAILS WHERE   OR_ID=" + or_id;
            DataSet ds = DB_R2.GetDataSet(_sql1);
            return ds;
        }



        

        public  MPO_ODERDETAILS Get(string ORDE_ID)
        {
            string _sql1 = "SELECT * FROM MPO_ODERDETAILS WHERE ORDE_ID=" + ORDE_ID;
            DataSet ds = DB_R2.GetDataSet(_sql1);
            return DataSetToList(ds).FirstOrDefault();
        } 


        private List<MPO_ODERDETAILS> DataSetToList(DataSet ds)
        {
            EnumerableRowCollection<MPO_ODERDETAILS> q = (from temp in ds.Tables[0].AsEnumerable()
                                                          select new MPO_ODERDETAILS
                                                          {
                                                              ORDE_ID = temp.Field<Int32>("ORDE_ID"),
                                                              OR_ID = temp.Field<Int32>("OR_ID"),
                                                              STK_ID = temp.Field<Int32>("STK_ID"),
                                                              PR_LOT = temp.Field<Int32>("PR_LOT"),
                                                              ITEMS = temp.Field<Int32>("ITEMS"),
                                                              COST = temp.Field<Decimal>("COST"),
                                                              LOADINGDATE = temp.Field<DateTime?>("LOADINGDATE"),
                                                              SHIPMENTNO = temp.Field<String>("SHIPMENTNO"),
                                                              CONTAINERNO = temp.Field<String>("CONTAINERNO"),
                                                              TRUCKNO = temp.Field<String>("TRUCKNO"),
                                                              STAMP = temp.Field<String>("STAMP"),
                                                              STATUS = temp.Field<String>("STATUS"),
                                                              STATUS_CURRENT = temp.Field<String>("STATUS_CURRENT"),
                                                          });
            return q.ToList();
        }


    }
}