using System;
using System.Collections.Generic;
using System.Data;
using CoreDb;
using FirebirdSql.Data.FirebirdClient;
using Stk.Base;
using Stk.Common;

namespace Stk.Security
{
    public class STkRolesGroup
    {
        private Stk_BuBase_R2 stlbase;
        public string GetRole(Logon lg)
        {
            string Roles=null;
            //DataAccessLayer db = new DataAccessLayer();
            stlbase   = new Stk_BuBase_R2();

            List<IDataParameter> parms = new List<IDataParameter>();
            parms.Add(new FbParameter(":EM_ID", lg.userName.ToLower()));
            parms.Add(new FbParameter(":EM_PASS", lg.passWord));
            Roles = Convert.ToString(stlbase.DB_R2.FbExecuteScalar("SELECT   EMPLOYEE.EM_PERMISSION FROM EMPLOYEE WHERE  (LOWER(EM_ID)=?) and (EM_PASS =?)", parms));
            return Roles;
        }
 
  
       }
}