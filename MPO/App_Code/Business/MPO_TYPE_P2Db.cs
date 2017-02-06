using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
public class  MPO_TYPE_P2Db: DataAccess
{
public string _SortDirection { get; set; }
public string _SortExpression { get; set; }
  public MPO_TYPE_P2 _MPO_TYPE_P2;
public const string DataKey = "PR_TYPE";
public const string DataText = "TYPE_DEC";
public const string DataValue = "PR_TYPE";
public List<SelectInputProperties> Select()
 { string sql = "SELECT PR_TYPE,TYPE_DEC,0 AS RecordCount FROM MPO_TYPE_P2";
 DataSet ds = Db.GetDataSet(sql);  
  return SelectInputProperties.DataSetToList(ds);} 
public MPO_TYPE_P2 Select(string PR_TYPE) 
{ 
 string sql = "SELECT PR_TYPE,TYPE_DEC,0 AS RecordCount FROM MPO_TYPE_P2 where PR_TYPE = @PR_TYPE; "; 
  var prset = new List<IDataParameter>();
  prset.Add(Db.CreateParameterDb("@PR_TYPE", PR_TYPE));
  DataSet ds = Db.GetDataSet(sql,prset);
return DataSetToList(ds).FirstOrDefault(); 
}public List<MPO_TYPE_P2> GetWithFilter(bool sortAscending, string sortExpression){
throw new Exception("Not implement");
string sql = "SELECT * FROM MPO_TYPE_P2 "; 
sql += string.Format("  where ((''='{0}')or(PR_TYPE='{0}'))", _MPO_TYPE_P2.PR_TYPE);
sql += string.Format("  and ((''='{0}')or(TYPE_DEC='{0}'))", _MPO_TYPE_P2.TYPE_DEC);
  if (sortExpression == null){
sql += string.Format(" order by PR_TYPE ", sortExpression);}
else
{
}

DataSet ds = Db.GetDataSet(sql);return DataSetToList(ds);}
  public List< MPO_TYPE_P2> GetPageWise(int pageIndex, int PageSize, string wordFullText = "") 
    { 
        string sql = ""; 
 
        //Set @Command = 'insert into  #Results   SELECT ROW_NUMBER() OVER (ORDER BY [EM_ID] desc )AS RowNumber ,*  FROM [ MPO_TYPE_P2]' + @CommandFilter; 
        string ColumnSort = ""; 
        if (_SortExpression == null) 
        { 
            ColumnSort = DataKey; 
        } 
        else 
        { 
            ColumnSort = _SortExpression; 
        } 
        string sortCommnad = GenSort(_SortDirection, ColumnSort); 
 
// Non implemnet full text Search
        string whereCommnad = GenWhereformProperties(); 
 
        int startRow = ((pageIndex - 1) * PageSize) + 1; 
        int toRow = (startRow + PageSize) - 1; 
        sql = string.Format("SELECT  {4},PR_TYPE,TYPE_DEC,  (SELECT count(*) FROM  MPO_TYPE_P2  {1}) as RecordCount FROM  MPO_TYPE_P2 A {1} {0} ROWS {2} TO {3}; ", sortCommnad, whereCommnad, startRow, toRow, Get_row_number_command()); 
 
        DataSet ds = Db.GetDataSet(sql); 
        return DataSetToList(ds); 
    }
public object Insert() {
var prset = new List<IDataParameter>();var sql = "INSERT INTO MPO_TYPE_P2(PR_TYPE,TYPE_DEC) VALUES (@PR_TYPE,@TYPE_DEC) returning PR_TYPE";

 prset.Add(Db.CreateParameterDb("@PR_TYPE",_MPO_TYPE_P2.PR_TYPE));
 prset.Add(Db.CreateParameterDb("@TYPE_DEC",_MPO_TYPE_P2.TYPE_DEC));


object output = Db.FbExecuteScalar(sql, prset);return output;  }

public void Update() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@PR_TYPE",_MPO_TYPE_P2.PR_TYPE)); prset.Add(Db.CreateParameterDb("@TYPE_DEC",_MPO_TYPE_P2.TYPE_DEC));
var sql = @"UPDATE   MPO_TYPE_P2 SET  TYPE_DEC=@TYPE_DEC where PR_TYPE = @PR_TYPE";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Update" + this.ToString());}   }

public void Delete() {
var prset = new List<IDataParameter>();
 prset.Add(Db.CreateParameterDb("@PR_TYPE",_MPO_TYPE_P2.PR_TYPE));
var sql =@"DELETE FROM MPO_TYPE_P2 where PR_TYPE=@PR_TYPE";

int output = Db.FbExecuteNonQuery(sql, prset);
if (output != 1){
 throw new System.Exception("Delete" + this.ToString());}   }

private List<MPO_TYPE_P2> DataSetToList(DataSet ds) 
{
 EnumerableRowCollection<MPO_TYPE_P2> q = (from temp in ds.Tables[0].AsEnumerable()
 select new MPO_TYPE_P2
{
RecordCount = temp.Field<Int32>("RecordCount"),PR_TYPE= temp.Field<String>("PR_TYPE"), 
 TYPE_DEC= temp.Field<String>("TYPE_DEC"), 
  });
  return q.ToList();
}
   public Boolean UpdateColumn(string id, string column,string value) 
        { 
            var prset = new List<IDataParameter>(); 
            prset.Add(Db.CreateParameterDb("@PR_TYPE", id)); 
            prset.Add(Db.CreateParameterDb("@Data", value)); 
             var sql = @"UPDATE   MPO_TYPE_P2 SET "+column+ "=@Data where PR_TYPE = @PR_TYPE"; 
 
            int output = Db.FbExecuteNonQuery(sql, prset); 
            if (output == 1) 
            { 
                return true; 
            } 
 
            return false;   
        } 
 public List<string> GetKeyWordsAllColumn(string Keyword) 
    { 
        
        string sql = "Sp_GetMPO_TYPE_P2_Autocomplete"; 
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
          
 
  string sql = "SELECT  " + column + " FROM MPO_TYPE_P2 where lower(" + column + ") like '" + keyword.ToLower() + "%'   group by " + column + " order by count(*) desc;"; 
         
         
  List<string> dataArray = new List<string>(); 
 
 
  DataSet ds = Db.GetDataSet(sql); 
  foreach (DataRow row in ds.Tables[0].Rows) 
        { 
            dataArray.Add(row[0].ToString()); 
        } 
 
        return dataArray; 
    } 
  public string GenSql() 
        { 
            string sql = ""; 
 
            //Set @Command = 'insert into  #Results   SELECT ROW_NUMBER() OVER (ORDER BY [EM_ID] desc )AS RowNumber ,*  FROM [MPO_TYPE_P2]' + @CommandFilter; 
            string ColumnSort = ""; 
            if (_SortExpression == null) 
            { 
                ColumnSort = DataKey; 
            } 
            else 
            { 
                ColumnSort = _SortExpression; 
            } 
            string sortCommnad = GenSort(_SortDirection, ColumnSort); 
            sql = string.Format("insert into  #Results   SELECT ROW_NUMBER() OVER (  {0} )AS RowNumber ,*  FROM [MPO_TYPE_P2] ", sortCommnad); 
 
            sql += GenWhereformProperties(); 
            return sql; 
        }
public string GenWhereformProperties() 
{
  String sql="";
   sql += "WHERE (1=1) "; 
            if (( _MPO_TYPE_P2.PR_TYPE!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (PR_TYPE='{0}') )", _MPO_TYPE_P2.PR_TYPE); 
            } 
            if (( _MPO_TYPE_P2.TYPE_DEC!= null) )
            { 
                sql += string.Format(" AND ((''='{0}') or (TYPE_DEC='{0}') )", _MPO_TYPE_P2.TYPE_DEC); 
            } 
return sql;
}
    public string Get_row_number_command() 
    { 
        return "rdb$get_context('USER_TRANSACTION', 'row#') as row_number,rdb$set_context('USER_TRANSACTION', 'row#', coalesce(cast(rdb$get_context('USER_TRANSACTION', 'row#') as integer), 0) + 1)"; 
    }
}
