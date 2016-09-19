using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Stk.Base;
using Stk.Common;

namespace MPO.Code.Bu
{
    public class MPO_ORDERS : Stk_BuBase_R2
    {
        public MPO_CUSTOMER_R2 _MPO_CUSTOMER_R2;

        public DataSet _MPO_ODERDETAILS;
        public int? OR_ID { get; set; }

        public string CUS_ID { get; set; }

        public string STATUS { get; set; }

        public string BYUSER { get; set; }

        public DateTime? ORDER_DATE { get; set; }


        //-------------------------------------------Custom

        public int Save()
        {
            var prset = new List<IDataParameter>();
            string sql =
                "INSERT INTO MPO_ORDERS(CUS_ID,BYUSER,ORDER_DATE) VALUES (@CUS_ID,@BYUSER,@ORDER_DATE) returning  OR_ID;";
            //prset.Add(DB_R2.CreateParameterDb("@OR_ID", OR_ID));
            prset.Add(DB_R2.CreateParameterDb("@CUS_ID", CUS_ID));


            prset.Add(DB_R2.CreateParameterDb("@BYUSER", BYUSER));
            prset.Add(DB_R2.CreateParameterDb("@ORDER_DATE", ORDER_DATE));
            int output = Convert.ToInt32(DB_R2.FbExecuteScalar(sql, prset));
            return output;
        }

        public void Upadate(int OR_ID)
        {

           
            var prset = new List<IDataParameter>();
            string sql =
                " UPDATE  MPO_ORDERS SET  CUS_ID = @CUS_ID ,  BYUSER = @BYUSER,  ORDER_DATE = @ORDER_DATE WHERE  OR_ID = @OR_ID;";
            prset.Add(DB_R2.CreateParameterDb("@CUS_ID", CUS_ID));
     
            
            prset.Add(DB_R2.CreateParameterDb("@BYUSER", BYUSER));
            prset.Add(DB_R2.CreateParameterDb("@ORDER_DATE", ORDER_DATE));
            prset.Add(DB_R2.CreateParameterDb("@OR_ID", OR_ID));

            DB_R2.FbExecuteNonQuery(sql, prset);

        }


        public bool ORDER_PROCESSING(string OR_ID)
        {
            string _sql1 =
                "   SELECT COUNT(*) FROM MPO_ODERDETAILS WHERE   OR_ID=" + OR_ID + " AND    STATUS_CURRENT ='Y'";
            int row = Convert.ToInt16(DB_R2.FbExecuteScalar(_sql1));
            if (row > 0)
                return true;

            return false;
        }


        public DataSet GetAllForCheckOut()
        {
            string _sql1 =
                "SELECT * FROM MPO_ORDERS inner join MPO_CUSTOMER_R2 ON MPO_ORDERS.CUS_ID= MPO_CUSTOMER_R2.CUSTNO WHERE STATUS is null;";
            DataSet ds = DB_R2.GetDataSet(_sql1);
            return ds;
        }


        public MPO_ORDERS GetOrders(string orid)
        {
            string _sql1 = "SELECT * FROM MPO_ORDERS WHERE OR_ID=" + orid;
            DataSet ds = DB_R2.GetDataSet(_sql1);

            var or = new MPO_ORDERS();
            or = DataSetToList(ds).FirstOrDefault();

            var customer = new MPO_CUSTOMER_R2();
            int cusid = Convert.ToInt32(or.CUS_ID);
            customer = customer.GetSource(cusid);
            or._MPO_CUSTOMER_R2 = customer;

            var deOderdetails = new MPO_ODERDETAILS();
            or._MPO_ODERDETAILS = deOderdetails.GetORder(or.OR_ID.ToString());

            return or;
        }

        public DataSet GetWithFilter(bool sortAscending, string sortExpression)
        {
            string _sql1 = "SELECT * FROM MPO_ORDERS ";

            _sql1 = AddCateria(_sql1);
            _sql1 += setSort(sortAscending, sortExpression);
            DataSet ds = DB_R2.GetDataSet(_sql1);
            return ds;
        }

        public string setSort(bool sortAscending, string sortExpression)
        {
            string sort = "";
            if (sortExpression == null)
            {
                sort += "";
            }
            else
            {
                sort += string.Format(" order by {0}", sortExpression);
                sort += (sortAscending ? "" : " desc");
            }


            return sort;
        }


        private string AddCateria(string sql)
        {
            sql += "WHERE (1=1) ";
            if (OR_ID != null)
            {
                sql += string.Format(" AND ((''='{0}') or (OR_ID='{0}') )", OR_ID);
            }
            if (CUS_ID != null)
            {
                sql += string.Format(" AND ((''='{0}') or (CUS_ID='{0}') )", CUS_ID);
            }

            if (STATUS == "N")
            {
                sql += string.Format(" AND ( (STATUS is null) )", STATUS);
            }
            else if (STATUS != null)
            {
                sql += string.Format(" AND ((''='{0}') or (STATUS='{0}') )", STATUS);
            }


            if (BYUSER != null)
            {
                sql += string.Format(" AND ((''='{0}') or (BYUSER='{0}') )", BYUSER);
            }
            if (ORDER_DATE != null)
            {
                DateTime _Dt = Convert.ToDateTime(ORDER_DATE);
                sql += string.Format(" AND ((''='{0}') or (ORDER_DATE='{0}') )", StkDate.ConvertDateEnForDb(_Dt));
            }
            return sql;
        }

        private List<MPO_ORDERS> DataSetToList(DataSet ds)
        {
            EnumerableRowCollection<MPO_ORDERS> q = (from temp in ds.Tables[0].AsEnumerable()
                select new MPO_ORDERS
                {
                    OR_ID = temp.Field<Int32?>("OR_ID"),
                    CUS_ID = temp.Field<String>("CUS_ID"),
                    STATUS = temp.Field<String>("STATUS"),
                    BYUSER = temp.Field<String>("BYUSER"),
                    ORDER_DATE = temp.Field<DateTime?>("ORDER_DATE"),
                });
            return q.ToList();
        }


        public List<MPO_ORDERS> GetMyoderTop(string BYUSER, string Top)
        {
            string _sql1 = "SELECT FIRST " + Top + " * FROM MPO_ORDERS WHERE BYUSER='" + BYUSER +
                           "' ORDER BY OR_ID DESC";

            DataSet ds = DB_R2.GetDataSet(_sql1);
            return DataSetToList(ds);
        }
    }
}