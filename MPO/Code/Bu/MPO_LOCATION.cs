using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FirebirdSql.Data.FirebirdClient;
using Stk.Base;

namespace MPO.Code.Bu
{
    public class MPO_LOCATION:   Stk_BuBase_R2
    {


        #region "Properties"
        private string _LOCATION_ID;
        public string LOCATION_ID
        {
            get
            {
                return _LOCATION_ID.Trim();
            }
            set
            {
                _LOCATION_ID = value.Trim();
            }
        }


        private string _LC_NAME;
        public string LC_NAME
        {
            get
            {
                return _LC_NAME.Trim();
            }
            set
            {
                _LC_NAME = value;
            }
        }

        private string _LC_ADDRESS;
        public string LC_ADDRESS
        {
            get
            {
                return _LC_ADDRESS.Trim();
            }
            set
            {
                _LC_ADDRESS = value;
            }
        }


        private string _LC_DEC;
        public string LC_DEC
        {
            get
            {
                return _LC_DEC.Trim();
            }
            set
            {

                string _inPut = value;
                if (_inPut.Length > 255)
                {
                    _inPut = _inPut.Substring(0, 255);
                    _LC_DEC = _inPut;
                }
                else
                {
                    _LC_DEC = _inPut;
                }

            }
        }

        private string _LC_TEL;
        public string LC_TEL
        {
            get
            {
                return _LC_TEL.Trim();
            }
            set
            {
                _LC_TEL = value;
            }
        }


        private string _LC_ACTIVE;
        public string LC_ACTIVE
        {
            get
            {
                return _LC_ACTIVE.Trim();
            }
            set
            {
                _LC_ACTIVE = value;
            }
        }
        #endregion


        public string STKValue = "LOCATION_ID";
        public string STKText = "LC_NAME";

        private DataSet ds;
        private string sql = "";
        public DataSet GetLocations()
        {
            string sql;
            sql = "SELECT  LOCATION_ID, LC_NAME, LC_ADDRESS, LC_DEC, LC_TEL FROM MPO_LOCATION WHERE LC_ACTIVE='A' order by LC_NAME;";
            ds = DB_R2.GetDataSet(sql);
            return ds;
        }

        public DataSet GetRooms()
        {
          

            string sql;
            sql = "  SELECT ROOM_ID FROM MPO_ROOM;";
            ds = DB_R2.GetDataSet(sql);
            return ds;
        }


        public MPO_LOCATION GetLocations(string LOCATION_ID)
        {
            string sql;
            sql = "SELECT  LOCATION_ID, LC_NAME, LC_ADDRESS, LC_DEC, LC_TEL,LC_ACTIVE FROM MPO_LOCATION WHERE LOCATION_ID='" + LOCATION_ID + "' ;";
            ds = DB_R2.GetDataSet(sql);

            MPO_LOCATION q = (from T in ds.Tables[0].AsEnumerable()
                              select new MPO_LOCATION
                              {
                                  LC_ADDRESS = T.Field<string>("LC_ADDRESS").ToString(),
                                  LOCATION_ID = T.Field<string>("LOCATION_ID").ToString(),
                                  LC_DEC = T.Field<string>("LC_DEC").ToString(),
                                  LC_NAME = T.Field<string>("LC_NAME").ToString(),
                                  LC_TEL = T.Field<string>("LC_TEL").ToString(),
                                  //EM_ID = T.Field<string>("EM_ID").ToString(),

                              }).FirstOrDefault();

            return q;
        }

        public DataSet GetLocations(bool sortAscending, string SortExpression)
        {

            string sql;
            sql = "SELECT  LOCATION_ID, LC_NAME, LC_ADDRESS, LC_DEC, LC_TEL,LC_ACTIVE FROM MPO_LOCATION";

            sql += string.Format(" WHERE ((LOWER(LOCATION_ID) like '%{0}%') or ('{1}' = 'null'))  and  ((LOWER(LC_NAME) like '%{2}%') or ('{3}' = 'null')) and ((LOWER(LC_ADDRESS) like '%{4}%') or ('{5}' = 'null'))", LOCATION_ID, LOCATION_ID, LC_NAME, LC_NAME, LC_ADDRESS, LC_ADDRESS);
            switch (SortExpression)
            {
                case "LOCATION_ID":

                    sql += " order by LOCATION_ID";
                    sql += sortAscending ? "" : " desc";
                    //  users = sortAscending ? users.OrderBy(u => u.FirstName) :
                    //     users.OrderByDescending(u => u.FirstName);
                    break;
                case "LC_NAME":
                    //users = sortAscending ? users.OrderBy(u => u.LastName) :
                    //    users.OrderByDescending(u => u.LastName);
                    sql += " order by LC_NAME";
                    sql += sortAscending ? "" : " desc";
                    break;

                case "LC_ADDRESS":
                    //users = sortAscending ? users.OrderBy(u => u.LastName) :
                    //    users.OrderByDescending(u => u.LastName);
                    sql += " order by LC_ADDRESS";
                    sql += sortAscending ? "" : " desc";
                    break;
                default:
                    sql += " order by LC_NAME";
                    //users = sortAscending ? users.OrderBy(u => u.UserID) :
                    //    users.OrderByDescending(u => u.UserID);
                    // sql="SELECT a.CUST_NO, a.CUSTOMER, a.CONTACT_FIRST, a.CONTACT_LAST, a.PHONE_NO, a.ADDRESS_LINE1, a.ADDRESS_LINE2, a.CITY, a.STATE_PROVINCE, a.COUNTRY, a.POSTAL_CODE, a.ON_HOLD FROM CUSTOMER a";
                    break;
            }

            ds = DB_R2.GetDataSet(sql);

            return ds;
        }



        public void Save()
        {

            //sql = string.Format("UPDATE OR INSERT INTO POSITIONS (PS_ID, LC_NAME, LC_ADDRESS) VALUES ('{0}', '{1}', '{2}')", _PS_ID, _LC_NAME,_LC_ADDRESS);
            //sql = string.Format("INSERT INTO POSITIONS (LOCATION_ID,LC_NAME, LC_ADDRESS) VALUES ('{0}', '{1}','{2}')",_LOCATION_ID, _LC_NAME,_LC_ADDRESS);
            //if (CheckP_CODE() == true)
            //{
            //    sql = "UPDATE POSITIONS SET LC_NAME = ?, LC_ADDRESS = ? WHERE LOCATION_ID = ?";
            //}
            //else
            //{
            //    sql = "INSERT INTO POSITIONS (LOCATION_ID,LC_NAME, LC_ADDRESS) VALUES (?,?,?)";
            //}

            sql = "UPDATE OR INSERT INTO MPO_LOCATION (LOCATION_ID, LC_NAME, LC_ADDRESS, LC_DEC, LC_TEL,LC_ACTIVE)VALUES    (?,?,?,?,?,?)";
            List<IDataParameter> parms = new List<IDataParameter>();

            parms.Add(new FbParameter(":LOCATION_ID", LOCATION_ID));
            parms.Add(new FbParameter(":LC_NAME", LC_NAME));
            parms.Add(new FbParameter(":LC_ADDRESS", LC_ADDRESS));
            parms.Add(new FbParameter(":LC_DEC", LC_DEC));
            parms.Add(new FbParameter(":LC_TEL", LC_TEL));
            parms.Add(new FbParameter(":LC_TEL", LC_ACTIVE));



            DB_R2.FbExecuteNonQuery(sql, parms);
        }


        public bool CheckKey()
        {
            bool chek = false;
            sql = string.Format("SELECT count(LOCATION_ID) FROM MPO_LOCATION where LOWER(LOCATION_ID)='{0}';", LOCATION_ID.ToLower());

            int RowCount = 0;
            RowCount = Convert.ToInt32(DB_R2.FbExecuteScalar(sql));
            if (RowCount > 0)
            {
                chek = true;
            }
            return chek;
        }


        public void Delete(string LOCATION_ID)
        {

            sql = "DELETE FROM  MPO_LOCATION WHERE  LOCATION_ID ='" + LOCATION_ID + "'";

            DB_R2.FbExecuteNonQuery(sql);




            //List<FbParameter> parms = new List<FbParameter>();
            //parms.Add(new FbParameter(":LOCATION_ID", LOCATION_ID));
            //DB_R2.FbExecuteNonQuery(sql, parms);
        }

    }
}