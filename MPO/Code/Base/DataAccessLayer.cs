using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using Stk.DB;

namespace MPO.Code.Base
{
    //OpenData Base Before Use Command
    public class DataAccessLayer
    {
        FbConnection con;
        FbCommand com;
        System.Exception GloEx;
        string constr;
        public DataAccessLayer()
        {

            con = null;
            com = null;
            GloEx = null;
            constr = "";

            if (((ConfigurationManager.ConnectionStrings["CFireBird"] == null)))
            {
                throw new System.Exception("Connection Error");
            }
            constr = ConfigurationManager.ConnectionStrings["CFireBird"].ToString();
            con = new FbConnection(constr);

        }

        //Get DataSet 
        public DataSet GetDataSet(string sql)
        {
            // Description: fill DataSet via OleDbDataAdapter, connect Firebird, Interbase
            DataSet ds = new DataSet();

            //using (System.Transactions.TransactionScope scope =new System.Transactions.TransactionScope())
           // {

            FbDataAdapter adapter = new FbDataAdapter(sql, con);
            adapter.Fill(ds);
             //scope.Complete();
            //}


            return ds;
        }

        public string  FbExecuteScalar(String sql)
        {
            // Description: ExecuteScalar - gets a single value. Firebird, Interbase .Net provider (c#)
            string output = null;
            OpenFbData();
            //FbTransaction  trans = con.BeginTransaction();

            try
            {
                com = new FbCommand(sql, con);
                output = Convert.ToString(com.ExecuteScalar());
              
            }
            catch (System.Exception ex)
            {
                GloEx = ex;
               
            }
            finally { CloseFbData(); }

            if (GloEx != null)
            {
                throw GloEx;
            }
                //trans.Commit();
            //CloseFbData();

            return output;
        }

        public bool FbExecuteNonQuery(String sql)
        {
            // Description: ExecuteScalar - gets a single value. Firebird, Interbase .Net provider (c#)
            bool output = false;
            GloEx = null;
            OpenFbData();
            //FbTransaction trans = con.BeginTransaction();
            try
            {
                com = new FbCommand(sql, con);

                int rowsOutput=0;
                rowsOutput=com.ExecuteNonQuery();
                if (rowsOutput > 0)
                {
                    output = true;
                }
            }
            catch (System.Exception ex)
            {
                GloEx = ex;
               
            }
            finally
            {
                //trans.Commit();
                CloseFbData();
            }

            if (GloEx != null)
            {
                throw GloEx;
            }


            return output;
        }



        public void FbExecuteNonQuery(string sql, List<FbParameter> parms)
        {
          
          
            try
            {
                OpenFbData();
                com = new FbCommand(sql, con);
                foreach (var p in parms)
                {

                    com.Parameters.Add(p);

                }
                com.ExecuteNonQuery();
            }

            catch (System.Exception ex)
            {
                GloEx = ex;
             
            }
            finally {

                CloseFbData();
            }

            if (GloEx != null)
            {
                throw GloEx;
            }
                


        }


        public string FbExecuteScalar(string sql, List<FbParameter> parms)
        {
            string  output = "" ;
            OpenFbData();
            com = new FbCommand(sql, con);
            foreach (var p in parms)
            {

                com.Parameters.Add(p);

            }
            try
            {
              
                output = com.ExecuteScalar().ToString();
            }

            catch (System.Exception ex)
            {
                GloEx = ex;

            }
            finally
            {

                CloseFbData();
            }

            if (GloEx != null)
            {
                throw GloEx;
            }

            return output;

        }

        public FbDataReader FbExecuteReader(string sql, List<FbParameter> parms)
        {
            FbDataReader fbrd = null; ;
            OpenFbData();
            com = new FbCommand(sql, con);
            foreach (var p in parms)
            {

                com.Parameters.Add(p);

            }
            try
            {
              
                fbrd = com.ExecuteReader(CommandBehavior.SingleRow);
            }

            catch (System.Exception ex)
            {
                GloEx = ex;

            }
            finally
            {

                CloseFbData();
            }

            if (GloEx != null)
            {
                throw GloEx;
            }

            return fbrd;

        }


        public bool FbExecuteTransaction(TransactionSetCollection ts)
        {
            bool output = false;
            System.Exception Global = null;
            OpenFbData();
            FbTransaction trans = con.BeginTransaction();
           
             try
            {
               
                    foreach (TransactionSet t in ts)
                    {
                        com = new FbCommand(t.SqlCommand, con, trans);
                        if (t.Parameter != null)
                        {
                            foreach (var p in t.Parameter)
                            {

                                com.Parameters.Add(p);

                            }
                        }
                        com.ExecuteNonQuery();
                    }

            


                trans.Commit();
                output = true;
            }
             catch (System.Exception ex)
             {
                 trans.Rollback();
                 Global = ex;
             }
             finally
             {

                 //Check State And Close DB
                 //if (con.State == ConnectionState.Open)
                 //{
                 //    con.Close();
                 //}
                 CloseFbData();
             }


             if (Global != null)
             {
                 throw Global;
             }

             return output;
        }

        public  void OpenFbData()
        {
            //Check Null
            if (con == null)
            {
                con = new FbConnection(constr);
            }


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }


        public  void CloseFbData()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
                con = null;

            }

        }

    }
}