using System;
using System.Collections.Generic;
using System.Data;
 
using FirebirdSql.Data.FirebirdClient;
using System.ComponentModel;
using Stk.Base;
 
namespace Stk.Bu
{
    [DataObject(true)]
    public class Stk_Employee : Stk_BuBase_R2 
    {
        //SELECT  EM_ID, EM_TITLE, EM_NAME, EM_SURNAME, EM_PASS, EM_PERMISSION, EM_ADDRESS, EM_TEL, EM_CREATE, EM_EMAIL, EM_NOTE FROM EMPLOYEE

        private string _EM_ID;
        public string EM_ID { get { return _EM_ID; } set { _EM_ID = value.Trim(); } }

        public string _EM_TITLE;
        public string EM_TITLE { get { return _EM_TITLE; } set { _EM_TITLE = value; } }

        public string _EM_NAME;
        public string EM_NAME { get { return _EM_NAME; } set { _EM_NAME = value; } }

        public string _EM_SURNAME;
        public string EM_SURNAME { get { return _EM_SURNAME; } set { _EM_SURNAME = value; } }


        public string _EM_PASS;
        public string EM_PASS { get { return _EM_PASS; } set { _EM_PASS = value; } }

        public string _EM_PERMISSION;
        public string EM_PERMISSION { get { return _EM_PERMISSION; } set { _EM_PERMISSION = value; } }


        public string _EM_ADDRESS;
        public string EM_ADDRESS { get { return _EM_ADDRESS; } set { _EM_ADDRESS = value; } }

        public string _EM_TEL;
        public string EM_TEL { get { return _EM_TEL; } set { _EM_TEL = value; } }

        public DateTime _EM_CREATE;
        public DateTime EM_CREATE { get { return _EM_CREATE; } set { _EM_CREATE = value; } }

        public string _EM_EMAIL;
        public string EM_EMAIL { get { return _EM_EMAIL; } set { _EM_EMAIL = value; } }

        public string _EM_NOTE;
        public string EM_NOTE { get { return _EM_NOTE; } set { _EM_NOTE = value; } }

        public string _LC_CODE;
        public string LC_CODE
        {
            get
            {
                if (_LC_CODE == "")
                {
                    return null;
                }
                return _LC_CODE;

            }
            set { _LC_CODE = value; }
        }

        public string _EM_FLAG;
        public string EM_FLAG { get { return _EM_FLAG; } set { _EM_FLAG = value; } }


        //private string _FullName;
        //public string FullName { get { return _EM_NAME +" "+ _EM_SURNAME; } }

        private string sql = "";
        private DataSet ds;
        //public static implicit operator Stk_Report_Em(Stk_Employee d)
        //{
        //    Stk_Report_Em ReportEm = new Stk_Report_Em();
        //    ReportEm.EM_NAME = d.EM_NAME;
        //    ReportEm.EM_SURNAME = d.EM_SURNAME;
        //    ReportEm.EM_TEL = d.EM_TEL;
        //    return ReportEm;
        //}

        public bool Save()
        {

            bool result = false;
            sql = "UPDATE OR INSERT INTO EMPLOYEE(EM_ID, EM_TITLE, EM_NAME, EM_SURNAME, EM_PASS, EM_PERMISSION, EM_ADDRESS, EM_TEL, EM_CREATE, EM_EMAIL, EM_NOTE,LC_CODE,EM_FLAG) VALUES(?,?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?)";
            List<IDataParameter> parms = new List<IDataParameter>();
            parms.Add(new FbParameter(":EM_ID", EM_ID));
            parms.Add(new FbParameter(":EM_TITLE", EM_TITLE));
            parms.Add(new FbParameter(":EM_NAME", EM_NAME));

            parms.Add(new FbParameter(":EM_SURNAME", EM_SURNAME));
            parms.Add(new FbParameter(":EM_PASS", EM_PASS));
            parms.Add(new FbParameter(":EM_PERMISSION", EM_PERMISSION));

            parms.Add(new FbParameter(":EM_ADDRESS", EM_ADDRESS));
            parms.Add(new FbParameter(":EM_TEL", EM_TEL));
            parms.Add(new FbParameter(":EM_CREATE", EM_CREATE));


            parms.Add(new FbParameter(":EM_EMAIL", EM_EMAIL));
            parms.Add(new FbParameter(":EM_NOTE", EM_NOTE));
            parms.Add(new FbParameter(":LC_CODE", LC_CODE));
            parms.Add(new FbParameter(":EM_FLAG", EM_FLAG));
            DB_R2.FbExecuteNonQuery(sql, parms);
            result = true;
            return result;
              
        }


        public bool CheckKey()
        {
            bool chek = false;
            sql = string.Format("SELECT count(EM_ID) FROM EMPLOYEE where LOWER(EM_ID)='{0}';", EM_ID.ToLower());

            int RowCount = 0;
            RowCount = Convert.ToInt32(DB_R2.FbExecuteScalar(sql));
            if (RowCount > 0)
            {
                chek = true;
            }
            return chek;
        }
        public void Delete(string EM_ID)
        {

            sql = "DELETE FROM EMPLOYEE WHERE EM_ID = '" + EM_ID + "'";
            DB_R2.FbExecuteNonQuery(sql);

        }


        public DataSet GetEmployee(bool sortAscending, string SortExpression)
        {

            string sql;
            //sql = "SELECT  EM_ID, EM_TITLE, EM_NAME, EM_SURNAME, EM_PASS, EM_PERMISSION, EM_ADDRESS, EM_TEL, EM_CREATE, EM_EMAIL, EM_NOTE,EM_FLAG FROM EMPLOYEE ";
            //Add Join Location
            //sql = "SELECT    EMPLOYEE.EM_ID,  EMPLOYEE.EM_TITLE,  EMPLOYEE.EM_NAME,  EMPLOYEE.EM_SURNAME,  EMPLOYEE.EM_PASS,  EMPLOYEE.EM_PERMISSION,  EMPLOYEE.EM_ADDRESS,  EMPLOYEE.EM_TEL,  EMPLOYEE.EM_CREATE,  EMPLOYEE.EM_EMAIL,  EMPLOYEE.EM_NOTE,  EMPLOYEE.LC_CODE,  EMPLOYEE.EM_FLAG,  LOCATION.LC_CODE,  LOCATION.LC_NAME,  LOCATION.LC_ADDRESS,  LOCATION.LC_DEC,  LOCATION.LC_TEL,  LOCATION.LC_ACTIVE,    EMPLOYEE.EM_NAME     ||' ' ||  EMPLOYEE.EM_SURNAME AS FULLNAME  FROM EMPLOYEE LEFT JOIN   LOCATION ON EMPLOYEE.LC_CODE= LOCATION.LC_CODE ";
            //sql += string.Format(" WHERE ((EM_ID like '%{0}%') or ('{1}' = 'null'))  and  ((LOWER(EM_NAME) like '%{2}%') or ('{3}' = 'null')) and ((LOWER(EM_SURNAME) like '%{4}%') or ('{5}' = 'null'))  and ((EMPLOYEE.LC_CODE = '{6}') or ('{6}' = '0')) ", EM_ID.ToLower(), EM_ID.ToLower(), EM_NAME.ToLower(), EM_NAME.ToLower(), EM_SURNAME.ToLower(), EM_SURNAME.ToLower(), LC_CODE);

          
            sql = "SELECT * FROM EMPLOYEE";
                sql += string.Format(" WHERE ((EM_ID like '%{0}%') or ('{1}' = 'null'))  and  ((LOWER(EM_NAME) like '%{2}%') or ('{3}' = 'null')) and ((LOWER(EM_SURNAME) like '%{4}%') or ('{5}' = 'null'))    ", EM_ID.ToLower(), EM_ID.ToLower(), EM_NAME.ToLower(), EM_NAME.ToLower(), EM_SURNAME.ToLower(), EM_SURNAME.ToLower());
      
            switch (SortExpression)
            {
                case "EM_ID":

                    sql += " order by EM_ID";
                    sql += sortAscending ? "" : " desc";
                    //  users = sortAscending ? users.OrderBy(u => u.FirstName) :
                    //     users.OrderByDescending(u => u.FirstName);
                    break;
                case "EM_NAME":
                    //users = sortAscending ? users.OrderBy(u => u.LastName) :
                    //    users.OrderByDescending(u => u.LastName);
                    sql += " order by EM_NAME";
                    sql += sortAscending ? "" : " desc";
                    break;
                case "EM_SURNAME":
                    //users = sortAscending ? users.OrderBy(u => u.LastName) :
                    //    users.OrderByDescending(u => u.LastName);
                    sql += " order by EM_SURNAME";
                    sql += sortAscending ? "" : " desc";
                    break;

                case  "FULLNAME":
                     sql += " order by FULLNAME";
                    sql += sortAscending ? "" : " desc";
                        break;
                default:
                    sql += " order by EMPLOYEE.LC_CODE,EM_ID";
                    //    users.OrderByDescending(u => u.UserID);
                    // sql="SELECT a.CUST_NO, a.CUSTOMER, a.CONTACT_FIRST, a.CONTACT_LAST, a.PHONE_NO, a.ADDRESS_LINE1, a.ADDRESS_LINE2, a.CITY, a.STATE_PROVINCE, a.COUNTRY, a.POSTAL_CODE, a.ON_HOLD FROM CUSTOMER a";
                    break;
            }

            ds = DB_R2.GetDataSet(sql);

            return ds;
        }

        public DataSet Gets()
        {

            //sql = "SELECT  EM_ID, EM_TITLE, EM_NAME, EM_SURNAME, EM_PASS, EM_PERMISSION, EM_ADDRESS, EM_TEL, EM_CREATE, EM_EMAIL, EM_NOTE,EM_FLAG FROM EMPLOYEE ";
            //Add Join Location
            string sql = "SELECT  * FROM EMPLOYEE";
            ds = DB_R2.GetDataSet(sql);
            return ds;
        }

        public DataSet GetSeller()
        {
            const string sql1 = "SELECT EM_ID, (EM_NAME ||' ' || EM_SURNAME) AS NAME FROM EMPLOYEE WHERE EM_PERMISSION='S'";

            DataSet ds = DB_R2.GetDataSet(sql1);

            return (ds);

        }

        public DataSet GetQc()
        {
            const string sql1 = "SELECT EM_ID, (EM_NAME ||' ' || EM_SURNAME) AS NAME FROM EMPLOYEE WHERE EM_PERMISSION='Q'";

            DataSet ds = DB_R2.GetDataSet(sql1);

            return (ds);

        }



        public void GetEmployee(string EM_ID)
        {
            //sql = string.Format("SELECT  EM_ID, EM_TITLE, EM_NAME, EM_SURNAME, EM_PASS, EM_PERMISSION, EM_ADDRESS, EM_TEL, EM_CREATE, EM_EMAIL, EM_NOTE, LC_CODE FROM EMPLOYEE  where LOWER(EM_ID)='{0}';", EM_ID.ToLower());
            sql = string.Format("SELECT  EM_ID, EM_TITLE, EM_NAME, EM_SURNAME, EM_PASS, EM_PERMISSION, EM_ADDRESS, EM_TEL, EM_CREATE, EM_EMAIL, EM_NOTE, LC_CODE,EM_FLAG FROM EMPLOYEE  where LOWER(EM_ID)='{0}';", EM_ID.ToString().ToLower());

            //List<FbParameter> parms = new List<FbParameter>();
            //     parms.Add(new FbParameter(":EM_ID", EM_ID));
            DataSet ds = DB_R2.GetDataSet(sql);
            if (ds.Tables[0].Rows.Count == 1)
            {
                _EM_ID = ds.Tables[0].Rows[0]["EM_ID"].ToString();
                _EM_PASS = ds.Tables[0].Rows[0]["EM_PASS"].ToString();
                _EM_PERMISSION = ds.Tables[0].Rows[0]["EM_PERMISSION"].ToString();

                _LC_CODE = ds.Tables[0].Rows[0]["LC_CODE"].ToString();

                _EM_TITLE = ds.Tables[0].Rows[0]["EM_TITLE"].ToString();
                _EM_NAME = ds.Tables[0].Rows[0]["EM_NAME"].ToString();
                _EM_SURNAME = ds.Tables[0].Rows[0]["EM_SURNAME"].ToString();
                _EM_EMAIL = ds.Tables[0].Rows[0]["EM_EMAIL"].ToString();
                _EM_ADDRESS = ds.Tables[0].Rows[0]["EM_ADDRESS"].ToString();
                _EM_TEL = ds.Tables[0].Rows[0]["EM_TEL"].ToString();
                _EM_NOTE = ds.Tables[0].Rows[0]["EM_NOTE"].ToString();
                _EM_FLAG = ds.Tables[0].Rows[0]["EM_FLAG"].ToString();
            }
            else if (ds.Tables[0].Rows.Count > 1)
                throw new System.Exception("Find User More 1. ?What?");

        }

        public string GetFullName(string EM_ID)
        {
            string name = "";
            GetEmployee(EM_ID);
           name=  _EM_NAME + " " + _EM_SURNAME;
            return name;
        }

    }




}