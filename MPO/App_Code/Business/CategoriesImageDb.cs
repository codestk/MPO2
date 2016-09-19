using System.Collections.Generic;
using System.Data;
public class CategoriesImageDb : DataAccess
 {
public IDataReader GetPicture(string id)
    {
        string sql = "SELECT Picture FROM Categories where CategoryID = @CategoryID;";
        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@CategoryID", id));
        Db.OpenFbData();        return Db.FbExecuteReader(sql, prset, CommandType.Text);
    }
 public bool SavePicture(string id, byte[] Picture)
    {
        string sql = "UPDATE  Categories SET Picture = @Picture  WHERE CategoryID = @CategoryID";

        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@CategoryID", id));
        prset.Add(Db.CreateParameterDb("@Picture", Picture));


        int output = Db.FbExecuteNonQuery(sql, prset);
        if (output != 1)
        {
            throw new System.Exception("Update" + this.ToString());
        }
        return true;

    }
  public bool DeletePicture(string id)
    {
        string sql = "UPDATE Categories SET  Picture =null  WHERE CategoryID=@CategoryID";

        var prset = new List<IDataParameter>();
        prset.Add(Db.CreateParameterDb("@CategoryID", id));


        int output = Db.FbExecuteNonQuery(sql, prset);
        if (output != 1)
        {
            throw new System.Exception("Update" + this.ToString());
        }
        return true;

    }
}

