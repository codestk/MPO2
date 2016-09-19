using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
public class  MPO_SOURCEDb: DataAccess
{
 public string _SortDirection { get; set; }
 public string _SortExpression { get; set; }
  public MPO_SOURCE _MPO_SOURCE;
public const string DataKey = "PR_SOURCE";
public const string DataText = "PR_DEC";
public const string DataValue = "PR_SOURCE";
 public List<SelectInputProperties> Select()
    {
 string sql = "SELECT * FROM MPO_SOURCE";
        DataSet ds = Db.GetDataSet(sql);

        return SelectInputProperties.DataSetToList(ds);
		
    }
	
public MPO_SOURCE Select(string PR_SOURCE) 
{ 
 string _sql1 = "SELECT *,0 AS RecordCount FROM MPO_SOURCE where PR_SOURCE = @PR_SOURCE; "; 
   var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@PR_SOURCE", PR_SOURCE));
  DataSet ds = Db.GetDataSet(_sql1,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<MPO_SOURCE> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM MPO_SOURCE "; 
sql += string.Format("  where ((''='{0}')or(PR_SOURCE='{0}'))", _MPO_SOURCE.PR_SOURCE);
sql += string.Format("  and ((''='{0}')or(PR_DEC='{0}'))", _MPO_SOURCE.PR_DEC);
if (sortExpression == null){
sql += string.Format(" order by PR_SOURCE ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
public List<MPO_SOURCE> GetPageWise(int pageIndex, int PageSize, string  wordFullText="") 
{ 
string store = "Sp_GetMPO_SOURCEPageWise"; 
 
 
var dbParameter = GetParameter(pageIndex,PageSize);

 
 
DataSet ds = Db.GetDataSet(store, dbParameter, CommandType.StoredProcedure); 
return DataSetToList(ds); 
}
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO MPO_SOURCE(PR_SOURCE,PR_DEC) VALUES (@PR_SOURCE,@PR_DEC) ;Select @PR_SOURCE";
 prset.Add(Db.CreateParameterDb("@PR_SOURCE",_MPO_SOURCE.PR_SOURCE)); prset.Add(Db.CreateParameterDb("@PR_DEC",_MPO_SOURCE.PR_DEC));

object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@PR_SOURCE",_MPO_SOURCE.PR_SOURCE)); prset.Add(Db.CreateParameterDb("@PR_DEC",_MPO_SOURCE.PR_DEC));
var sql = @"UPDATE   MPO_SOURCE SET  PR_DEC=@PR_DEC where PR_SOURCE = @PR_SOURCE";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@PR_SOURCE",_MPO_SOURCE.PR_SOURCE));
var sql =@"DELETE FROM MPO_SOURCE where PR_SOURCE=@PR_SOURCE";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<MPO_SOURCE> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<MPO_SOURCE> q = (from temp in ds.Tables[0].AsEnumerable()
 select new MPO_SOURCE
{
RecordCount = temp.Field<Int32>("RecordCount"),PR_SOURCE= temp.Field<String>("PR_SOURCE"), 
 PR_DEC= temp.Field<String>("PR_DEC"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@PR_SOURCE", id)); 
prset.Add(Db.CreateParameterDb("@Column", column));
            prset.Add(Db.CreateParameterDb("@Data", value)); 
   var sql = @"Sp_GetMPO_SOURCE_UpdateColumn";
            int output = Db.FbExecuteNonQuery(sql, prset, CommandType.StoredProcedure); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetMPO_SOURCE_Autocomplete"; 
        var prset = new List<IDataParameter>(); 
        prset.Add(Db.CreateParameterDb("@Key_word", Keyword)); 
 
        List<string> dataArray = new List<string>(); 
 
        DataSet ds = Db.GetDataSet(sql, prset,CommandType.StoredProcedure); 
        foreach (DataRow row in ds.Tables[0].Rows) 
        { 
            dataArray.Add(row[0].ToString()); 
        } 
 
        return dataArray; 
    }
  public List<string> GetKeyWordsOneColumn(string column, string keyword) 
  { 
          
 
  string sql = "SELECT  " + column + " FROM MPO_SOURCE where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
  List<string> dataArray = new List<string>(); 
 
 
  DataSet ds = Db.GetDataSet(sql); 
  foreach (DataRow row in ds.Tables[0].Rows) 
        { 
            dataArray.Add(row[0].ToString()); 
        } 
 
        return dataArray; 
    } 
public string GenWhereformProperties() 
{
  String sql="";
   sql += "WHERE (1=1) "; 
            if ( _MPO_SOURCE.PR_SOURCE!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (PR_SOURCE='{0}') )", _MPO_SOURCE.PR_SOURCE); 
            } 
            if ( _MPO_SOURCE.PR_DEC!= null) 
            { 
                sql += string.Format(" AND ((''='{0}') or (PR_DEC='{0}') )", _MPO_SOURCE.PR_DEC); 
            } 
return sql;
}
      public List<IDataParameter> GetParameter(int pageIndex, int PageSize)
        {
            var sqlStorePamameters = new List<IDataParameter>();
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageIndex", pageIndex));
            sqlStorePamameters.Add(Db.CreateParameterDb("@PageSize", PageSize));
if (_MPO_SOURCE.PR_SOURCE != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@PR_SOURCE", _MPO_SOURCE.PR_SOURCE));

            }
if (_MPO_SOURCE.PR_DEC != null)
            {
sqlStorePamameters.Add(Db.CreateParameterDb("@PR_DEC", _MPO_SOURCE.PR_DEC));

            }
/*Sort Order*/
  if (_SortExpression != null)
        {
           
            sqlStorePamameters.Add(Db.CreateParameterDb("@SortColumn", _SortExpression));
            sqlStorePamameters.Add(Db.CreateParameterDb("@SortOrder", _SortDirection));
        }


            return sqlStorePamameters;
        }
}

//Trasaction User
//bool output = false;
//    try
//    {
//        Db.OpenFbData();
//        Db.BeginTransaction();
//        MPO_ORDERS o1 = new MPO_ORDERS();
//o1 = _MPO_ORDERS;
//        int orid = o1.Save();
//MPO_ODERDETAILS o2 = new MPO_ODERDETAILS();
//o2.Save(orid, ODERDETAILS);
//        Db.CommitTransaction();
//        OR_ID = orid;
//        output = true;
//    }
//    catch (System.Exception ex)
//    {
//        Db.RollBackTransaction();
//        ErrorLogging.LogErrorToLogFile(ex, "");
//        throw ex;
//    }
//    return output;

