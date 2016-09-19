using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using CoreDb;

namespace Stk.Base
{
    public class Stk_BuBase_R2
    {
        public DataAccessLayer DB_R2; 
        public Stk_BuBase_R2 ()
        {
            if (((ConfigurationManager.ConnectionStrings["CFireBird"] == null)))
            {
                throw new System.Exception("Connection Error");
            }
          
            string connecStionstring = ConfigurationManager.ConnectionStrings["CFireBird"].ToString();
            DB_R2 = new DataBaseFireBird(connecStionstring);
        }



        //=====================================================================================================


        /// <summary>
        /// Utility Sort
        /// </summary>
        /// <param name="sortAscending"></param>
        /// <param name="sortExpression"></param>
        /// <returns></returns>

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


    }
}