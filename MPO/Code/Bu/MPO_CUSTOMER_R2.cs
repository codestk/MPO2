using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Stk.Base;

namespace MPO.Code.Bu
{
    public class MPO_CUSTOMER_R2 : Stk_BuBase_R2
    {

        /// <summary>
        /// ใช้ สำหรับกำหนดค่า Drop Down ต่าง
        /// </summary>
        public const string DataText = "COMPANY";
        public const string DataValue = "CUSTNO";



        public List<MPO_CUSTOMER_R2> GetWithFilter(bool sortAscending, string sortExpression)
        {
            string sql = "SELECT * FROM MPO_CUSTOMER_R2 ";
            sql += string.Format(" WHERE ((''='{0}')or(COMPANY like'%{0}%'))", COMPANY);

            sql += string.Format("  AND ((''='{0}')or(STATE='{0}'))", STATE);

            sql += string.Format("  AND ((''='{0}')or(CUSTNO='{0}'))", CUSTNO);
            // sql += string.Format("  AND ((''='{0}')or(COMPANY like'%{0}%'))", COMPANY);

            if (sortExpression == null)
            {
                sql += string.Format(" order by CUSTNO", sortExpression);

            }
            else
            {
                sql += setSort(sortAscending, sortExpression);

            }


            DataSet ds = DB_R2.GetDataSet(sql);


            return DataSetToList(ds);
        }




        #region For Dropdown
        public DataSet GetState()
        {
            string sql = "SELECT STATE FROM MPO_CUSTOMER_R2 where STATE is not null group by STATE order by STATE";




            DataSet ds = DB_R2.GetDataSet(sql);


            return ds;
        }

        #endregion



        public List<MPO_CUSTOMER_R2> GetSource()
        {
            const string sql1 = "SELECT * FROM MPO_CUSTOMER_R2";

            DataSet ds = DB_R2.GetDataSet(sql1);

            return DataSetToList(ds);

        }

    

        public MPO_CUSTOMER_R2 GetSource(Int32 CUSTNO)
        {
            string sql1 = "SELECT * FROM MPO_CUSTOMER_R2 WHERE CUSTNO=" + CUSTNO;

            var ds = DB_R2.GetDataSet(sql1);

            return DataSetToList(ds).FirstOrDefault();

        }


        public string GetCustomerName(int CUSTNO)
        {


            return GetSource(CUSTNO).COMPANY;

        }

        /// <summary>
        /// CUSTNO
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var prset = new List<IDataParameter>();
            string sql =
                "INSERT INTO MPO_CUSTOMER_R2(COMPANY,ADDR1,ADDR2,CITY,STATE,ZIP,COUNTRY,PHONE,FAX,TAXRATE,CONTACT,LASTINVOICEDATE,EXPORTER) VALUES (@COMPANY,@ADDR1,@ADDR2,@CITY,@STATE,@ZIP,@COUNTRY,@PHONE,@FAX,@TAXRATE,@CONTACT,@LASTINVOICEDATE,@EXPORTER) returning  CUSTNO;";
            //prset.Add(DB_R2.CreateParameterDb("@CUSTNO", CUSTNO));
            prset.Add(DB_R2.CreateParameterDb("@COMPANY", COMPANY));
            prset.Add(DB_R2.CreateParameterDb("@ADDR1", ADDR1));
            prset.Add(DB_R2.CreateParameterDb("@ADDR2", ADDR2));
            prset.Add(DB_R2.CreateParameterDb("@CITY", CITY));
            prset.Add(DB_R2.CreateParameterDb("@STATE", STATE));
            prset.Add(DB_R2.CreateParameterDb("@ZIP", ZIP));
            prset.Add(DB_R2.CreateParameterDb("@COUNTRY", COUNTRY));
            prset.Add(DB_R2.CreateParameterDb("@PHONE", PHONE));
            prset.Add(DB_R2.CreateParameterDb("@FAX", FAX));
            prset.Add(DB_R2.CreateParameterDb("@TAXRATE", TAXRATE));
            prset.Add(DB_R2.CreateParameterDb("@CONTACT", CONTACT));
            prset.Add(DB_R2.CreateParameterDb("@LASTINVOICEDATE", LASTINVOICEDATE));
            prset.Add(DB_R2.CreateParameterDb("@EXPORTER", EXPORTER));

            object output = DB_R2.FbExecuteScalar(sql, prset);
            //if (output != 1)
            //{
            //    throw new System.Exception("Save" + ToString());
            //}

            return output.ToString();
        }


        public void Update()
        {
            string sql =
                "UPDATE   MPO_CUSTOMER_R2 SET COMPANY=@COMPANY,ADDR1=@ADDR1,ADDR2=@ADDR2,CITY=@CITY,STATE=@STATE,ZIP=@ZIP,COUNTRY=@COUNTRY,PHONE=@PHONE,FAX=@FAX,TAXRATE=@TAXRATE,CONTACT=@CONTACT where  CUSTNO=@CUSTNO";
            var prset = new List<IDataParameter>();
            prset.Add(DB_R2.CreateParameterDb("@CUSTNO", CUSTNO));
            prset.Add(DB_R2.CreateParameterDb("@COMPANY", COMPANY));
            prset.Add(DB_R2.CreateParameterDb("@ADDR1", ADDR1));
            prset.Add(DB_R2.CreateParameterDb("@ADDR2", ADDR2));
            prset.Add(DB_R2.CreateParameterDb("@CITY", CITY));
            prset.Add(DB_R2.CreateParameterDb("@STATE", STATE));
            prset.Add(DB_R2.CreateParameterDb("@ZIP", ZIP));
            prset.Add(DB_R2.CreateParameterDb("@COUNTRY", COUNTRY));
            prset.Add(DB_R2.CreateParameterDb("@PHONE", PHONE));
            prset.Add(DB_R2.CreateParameterDb("@FAX", FAX));
            prset.Add(DB_R2.CreateParameterDb("@TAXRATE", TAXRATE));
            prset.Add(DB_R2.CreateParameterDb("@CONTACT", CONTACT));

            int output = DB_R2.FbExecuteNonQuery(sql, prset);
            if (output != 1)
            {
                throw new System.Exception("Save" + ToString());
            }
        }

        /*Common*/
        private List<MPO_CUSTOMER_R2> DataSetToList(DataSet ds)
        {
            EnumerableRowCollection<MPO_CUSTOMER_R2> q = (from temp in ds.Tables[0].AsEnumerable()
                                                      select new MPO_CUSTOMER_R2
                                                      {
                                                          CUSTNO = temp.Field<Int32?>("CUSTNO"),
                                                          COMPANY = temp.Field<String>("COMPANY"),
                                                          ADDR1 = temp.Field<String>("ADDR1"),
                                                          ADDR2 = temp.Field<String>("ADDR2"),
                                                          CITY = temp.Field<String>("CITY"),
                                                          STATE = temp.Field<String>("STATE"),
                                                          ZIP = temp.Field<String>("ZIP"),
                                                          COUNTRY = temp.Field<String>("COUNTRY"),
                                                          PHONE = temp.Field<String>("PHONE"),
                                                          FAX = temp.Field<String>("FAX"),
                                                          TAXRATE = temp.Field<Double?>("TAXRATE"),
                                                          CONTACT = temp.Field<String>("CONTACT"),
                                                          LASTINVOICEDATE = temp.Field<DateTime?>("LASTINVOICEDATE"),
                                                          EXPORTER = temp.Field<String>("EXPORTER"),
                                                      });

            return q.ToList();
        }


        public string CustomerMessage(object custno)
        {
            string message = "";
            //   return custno.ToString();
            try
            {
                var pR2 = new MPO_CUSTOMER_R2();

                int _custno = Convert.ToInt32(custno);
                pR2 = pR2.GetSource(_custno);
                message = pR2.COMPANY;
            }
            catch (System.Exception)
            {
                message = "-";
            }

            return message;
        }

        #region properties

        Int32? _CUSTNO;
        public Int32? CUSTNO { get { return _CUSTNO; } set { _CUSTNO = value; } }

        String _COMPANY;
        public String COMPANY { get { return _COMPANY; } set { _COMPANY = value; } }

        String _ADDR1;
        public String ADDR1 { get { return _ADDR1; } set { _ADDR1 = value; } }

        String _ADDR2;
        public String ADDR2 { get { return _ADDR2; } set { _ADDR2 = value; } }

        String _CITY;
        public String CITY { get { return _CITY; } set { _CITY = value; } }

        String _STATE;
        public String STATE { get { return _STATE; } set { _STATE = value; } }

        String _ZIP;
        public String ZIP { get { return _ZIP; } set { _ZIP = value; } }

        String _COUNTRY;
        public String COUNTRY { get { return _COUNTRY; } set { _COUNTRY = value; } }

        String _PHONE;
        public String PHONE { get { return _PHONE; } set { _PHONE = value; } }

        String _FAX;
        public String FAX { get { return _FAX; } set { _FAX = value; } }

        Double? _TAXRATE;
        public Double? TAXRATE { get { return _TAXRATE; } set { _TAXRATE = value; } }

        String _CONTACT;
        public String CONTACT { get { return _CONTACT; } set { _CONTACT = value; } }

        DateTime? _LASTINVOICEDATE;
        public DateTime? LASTINVOICEDATE { get { return _LASTINVOICEDATE; } set { _LASTINVOICEDATE = value; } }

        String _EXPORTER;
        public String EXPORTER { get { return _EXPORTER; } set { _EXPORTER = value; } }


        #endregion
    }
}