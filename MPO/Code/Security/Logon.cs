using System;
using CoreDb;
using Stk.Base;
using Stk.Common;

namespace Stk.Security
{



    public class Logon
    {

       string _userName;
       string  _passWord;
        
       public string userName
       { get { return _userName; }
           set {
               _userName = value;
           }
       }


       public string passWord
       {
           get { return _passWord; }
           set
           {
               _passWord = value;
           }
       }
        public  bool ValidateUser(string userName, string passWord)
        {
            
            string lookupPassword = null;

            // Check for invalid userName.
            // userName must not be null and must be between 1 and 15 characters.
            if ((null == userName) || (0 == userName.Length) || (userName.Length > 15))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
                return false;
            }

            // Check for invalid passWord.
            // passWord must not be null and must be between 1 and 25 characters.
            if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
                return false;
            }

          
                // Consult with your SQL Server administrator for an appropriate connection
                // string to use to connect to your local SQL Server.
                //conn = new SqlConnection("server=localhost;Integrated Security=SSPI;database=pubs");
                //conn.Open();

                //// Create SqlCommand to select pwd field from users table given supplied userName.
                //cmd = new SqlCommand("Select pwd from users where uname=@userName", conn);
                //cmd.Parameters.Add("@userName", SqlDbType.VarChar, 25);
                //cmd.Parameters["@userName"].Value = userName;

                // Execute command and fetch pwd field into lookupPassword string.
                //DataAccessLayer db = new DataAccessLayer();

                  Stk_BuBase_R2 stkbasR2=new Stk_BuBase_R2();
                //db.FbExecuteScalar("SELECT a.EMP_NO FROM EMPLOYEE a where EMP_NO=2")
                //lookupPassword = (string)cmd.ExecuteScalar();
                string SqlCommand = "SELECT EM_PASS FROM EMPLOYEE  where LOWER(EM_ID)='" + userName.ToLower() + "'  AND EM_FLAG ='A';";
                lookupPassword = Convert.ToString(stkbasR2.DB_R2.FbExecuteScalar(SqlCommand));
                _userName = userName;
                _passWord = lookupPassword;
                //db.FbExecuteScalar("SELECT EM_PASS FROM EMPLOYEE  where EM_ID=" + userName);
                // Cleanup command and connection objects.
                //cmd.Dispose();
          
                // Add error handling here for debugging.
                // This error message should not be sent back to the caller.
             
            

            // If no password found, return false.
            if (null == lookupPassword)
            {
                // You could write failed login attempts here to event log for additional security.
                return false;
            }
           
            // Compare lookupPassword and input passWord, using a case-sensitive comparison.
            return (0 == string.Compare(lookupPassword, passWord, false));

        }

    }


}