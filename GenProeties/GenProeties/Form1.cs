using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data;
using System.Data;
namespace GenProeties
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            OrderHasBeenPending();


        }

        public void OrderHasBeenPending()
        {

            string sql;
            // sql = "SELECT * FROM ORDERS";

            sql = "select * from " + textBox1.Text + " where 1=0;";
            FbConnection _FbConnection = new FbConnection();
            //'_FbConnection.ConnectionString=@"Server=localhost;User=SYSDBA;Password=masterkey;Database=C:\DB\STK.FDB";
            _FbConnection.ConnectionString = @"Server=localhost;User=SYSDBA;Password=masterkey;Database=C:\var\db\FISHWEIGHT.FDB";
            DataSet ds = new DataSet();


            FbDataAdapter adapter = new FbDataAdapter(sql, _FbConnection);
            adapter.Fill(ds);
            var sbt = new StringBuilder();


            //Employee em = new Employee();


            foreach (DataColumn _DataColumn in ds.Tables[0].Columns)
            {

                textBox2.Text += _DataColumn.DataType.Name + " _" + _DataColumn.ColumnName + "; \r\n";
                textBox2.Text += "public " + _DataColumn.DataType.Name + " " + _DataColumn.ColumnName + " { get { return _" + _DataColumn.ColumnName + "; } set { _" + _DataColumn.ColumnName + " = value; } } \r\n \r\n";

            }


        //    //Employee em = new Employee();
            
        //public List<SOURCE_R2> GetSource()
        //{
        //    string _sql1 = "SELECT * FROM SOURCE_R2";

        //    DataSet ds = DB_R2.GetDataSet(_sql1);

        //    return DataSetToList(ds);

        //}

            string NewValus = "";
            string RemapObject = "";
            NewValus += "=========================================================================================\r\n ";

            textBox3.Text += "public List<" +textBox1.Text + "> GetAll()\r\n {";
            textBox3.Text += "string _sql1 = \"SELECT * FROM " + textBox1.Text + "\";\r\n";
           textBox3.Text += " DataSet ds = DB_R2.GetDataSet(_sql1);  \r\n ";
           textBox3.Text += " return DataSetToList(ds);   \r\n";
           textBox3.Text += "} \r\n";
           textBox3.Text += "================================================================ \r\n";
           
            
        //      /*Common*/
        //private List<SOURCE_R2> DataSetToList(DataSet ds)
        //{
        //    EnumerableRowCollection<SOURCE_R2> q = (from temp in ds.Tables[0].AsEnumerable()
        //                                            select new SOURCE_R2
        //                                             {
        //                                                 SOURCE_R2_CODE = temp.Field<String>("SOURCE_R2_CODE"), 
        //                                             });

        //    return q.ToList();
        //}
           textBox3.Text += "private List<" + textBox1.Text + "> DataSetToList(DataSet ds) \r\n";
           textBox3.Text += "{\r\n";
           textBox3.Text += " EnumerableRowCollection<" + textBox1.Text + "> q = (from temp in ds.Tables[0].AsEnumerable()\r\n";
            textBox3.Text += " select new " + textBox1.Text + "\r\n";
            textBox3.Text += "{\r\n";
            foreach (DataColumn _DataColumn in ds.Tables[0].Columns)
            {

                textBox3.Text += _DataColumn.ColumnName + "= temp.Field<" + _DataColumn.DataType.Name + "?>(\"" + _DataColumn.ColumnName + "\"), \r\n ";


                NewValus += "_obj." + _DataColumn.ColumnName + "= " + _DataColumn.ColumnName + "; \r\n ";
                RemapObject += "" + _DataColumn.ColumnName + "= _obj." + _DataColumn.ColumnName + "; \r\n ";
            }
       
           textBox3.Text += " });\r\n";

           textBox3.Text += "  return q.ToList();\r\n";
           textBox3.Text += "}\r\n";
           textBox3.Text += NewValus;
            NewValus += "=========================================================================================\r\n ";

            textBox3.Text += RemapObject;
           
            // var sql = "INSERT INTO EMPLOYEE (EM_ID, EM_TITLE, EM_NAME, EM_SURNAME, EM_PASS, EM_PERMISSION, EM_ADDRESS, EM_TEL, EM_EMAIL, EM_NOTE, EM_FLAG, EM_CREATE, EM_UPDATE, PICTURE) 
            //VALUES (:EM_ID, :EM_TITLE, :EM_NAME, :EM_SURNAME, :EM_PASS, :EM_PERMISSION, :EM_ADDRESS, :EM_TEL, :EM_EMAIL, :EM_NOTE,:EM_FLAG, :CURRENT_DATE, :CURRENT_DATE, :PICTURE)";
            //var prset = new List<FbParameter> { new FbParameter(":EM_ID", em.EM_ID), new FbParameter(":EM_ID", em.EM_TITLE) };
            string insercolumn = "";
            string inservalue = "";
            string insertparameter = "";

            string updateCommand = "";
            foreach (DataColumn _DataColumn in ds.Tables[0].Columns)
            {
                //              insercolumn += _DataColumn.ColumnName + "," ;
                //              inservalue += "?,";
                //insertparameter += "new FbParameter(\":"+ _DataColumn.ColumnName+"\", _obj."+ _DataColumn.ColumnName+"),";

                updateCommand += _DataColumn.ColumnName + "=?,";
                //=====================================================================
                // New Version 
                //   Db.CreateParameterDb(":V1_GOOD_INOUT_ID", _obj.V1_GOOD_INOUT_ID.ToString().Trim())
                insercolumn += _DataColumn.ColumnName + ",";
                inservalue += "@" + _DataColumn.ColumnName + ",";
                insertparameter += " prset.Add(DB_R2.CreateParameterDb(\"@" + _DataColumn.ColumnName + "\"," + _DataColumn.ColumnName + "));";
            }

            insercolumn = insercolumn.TrimEnd(',');
            inservalue = inservalue.TrimEnd(',');
            insertparameter = insertparameter.TrimEnd(',');

            textBox4.Text += " void Save() {";
            textBox4.Text += Environment.NewLine + "var prset = new List<IDataParameter>();";
            textBox4.Text += "var sql = \"INSERT INTO " + textBox1.Text + "(" + insercolumn + ")";
            textBox4.Text += " VALUES (" + inservalue + ")returning  " + ds.Tables[0].Columns[0].ColumnName + ";\";";
            //textBox4.Text += Environment.NewLine + "var prset = new List<FbParameter> { " + insertparameter + "};";
            textBox4.Text += Environment.NewLine + insertparameter;



            textBox4.Text += Environment.NewLine;


            textBox4.Text += "var sql = \"UPDATE   " + textBox1.Text + " SET  " + updateCommand.Trim(',') + " where " + Environment.NewLine; ;
            textBox4.Text += "var prset = new List<FbParameter> { new FbParameter(\":" + textBox1.Text + "_ID\", " + textBox1.Text + "_ID.ToString().Trim()) };";
            textBox4.Text += Environment.NewLine;



            //   Db.CreateParameterDb(":V1_GOOD_INOUT_ID", _obj.V1_GOOD_INOUT_ID.ToString().Trim())
            //int output = DB_R2.FbExecuteNonQuery(sql, prset);
            //if (output != 1)
            //{
            //    throw new System.Exception("Save " + this.ToString());
            //}
            textBox4.Text += "int output = DB_R2.FbExecuteNonQuery(sql, prset);" + Environment.NewLine;
            textBox4.Text += "if (output != 1){" + Environment.NewLine;
            textBox4.Text += " throw new System.Exception(\"Save\" + this.ToString());}   }" + Environment.NewLine;

            textBox4.Text += Environment.NewLine +
                      "=====================================================================================================================";



            //"(string emmm,strig djsfkm)";
            // data = "{filter:'" + filter + "',startRowIndex:" + startRowIndex + ",maximumRows:" + itemsOnPage + "}";
            //  var urlDel=$(#'urlDel').val;
            string dotnetfunction = "function " + textBox1.Text + "(";
            string jsonstring = "\"{";
            string jqeryGetControl = "";
            string propertieJavascript = "function " + textBox1.Text + "(";
            string thispropertieJavascript = "";
            foreach (DataColumn _DataColumn in ds.Tables[0].Columns)
            {
                dotnetfunction += _DataColumn.DataType.Name + " " + _DataColumn.ColumnName + ",";

                propertieJavascript += _DataColumn.ColumnName + ",";
                thispropertieJavascript += "this." + _DataColumn.ColumnName + "=" + _DataColumn.ColumnName + ";" + Environment.NewLine;

                jqeryGetControl += "var " + _DataColumn.ColumnName + "=$('#txt_" + _DataColumn.ColumnName + "').val();" + Environment.NewLine;

                if (_DataColumn.DataType.Name == "String")
                {
                    jsonstring += _DataColumn.ColumnName + ":'\"+" + _DataColumn.ColumnName + "+\"',";
                }
                else
                {
                    jsonstring += _DataColumn.ColumnName + ":\"+" + _DataColumn.ColumnName + "+\",";
                }

            }
            dotnetfunction = dotnetfunction.Trim(',');
            dotnetfunction += ")";

            jsonstring = jsonstring.Trim(',');
            jsonstring += "}\"" + Environment.NewLine;


            textBox5.Text += propertieJavascript.TrimEnd(',') + "){" + Environment.NewLine + thispropertieJavascript + Environment.NewLine + "}" + Environment.NewLine;
            textBox5.Text += "===============================================================================" + Environment.NewLine;
            textBox5.Text += dotnetfunction;
            textBox5.Text += "===============================================================================" + Environment.NewLine;
            textBox5.Text += Environment.NewLine;
            textBox5.Text += jsonstring;
            textBox5.Text += "===============================================================================" + Environment.NewLine;
            textBox5.Text += jqeryGetControl;


            //=============================For lbl
            string apsLAbel = " <asp:Label ID=\"lbl_{0}\" runat=\"server\">" + Environment.NewLine;
            foreach (DataColumn _DataColumn in ds.Tables[0].Columns)
            {

                lblcommand.Text += string.Format(apsLAbel, _DataColumn.ColumnName);


            }
            lblcommand.Text += " ===============================" + Environment.NewLine;


            string ColumGridFotmart =
                "   <asp:BoundField DataField=\"{0}\" HeaderText=\"{0}\" SortExpression=\"{0}\" />" + Environment.NewLine;
            foreach (DataColumn _DataColumn in ds.Tables[0].Columns)
            {

                lblcommand.Text += string.Format(ColumGridFotmart, _DataColumn.ColumnName);


            }
            lblcommand.Text += " ===============================" + Environment.NewLine;



            string lblCodebehide = "lbl_{0}.Text =  Stk_TextNull.StringTotext(pr2.{0});" + Environment.NewLine;
            foreach (DataColumn _DataColumn in ds.Tables[0].Columns)
            {


                lblcommand.Text += string.Format(lblCodebehide, _DataColumn.ColumnName, _DataColumn.ColumnName);

            }

            lblcommand.Text += " ===============================" + Environment.NewLine;
            string trfortmat = "<tr><td>{0}</td> <td><asp:Label ID=\"lbl_{1}\" runat=\"server\"  Text=\"Label\"></asp:Label>  </td></tr>" + Environment.NewLine;
            foreach (DataColumn _DataColumn in ds.Tables[0].Columns)
            {


                lblcommand.Text += string.Format(trfortmat, _DataColumn.ColumnName, _DataColumn.ColumnName);

            }


        }

        //   public void  OrderHasBeenPending()
        //   {

        //       string sql;
        //      // sql = "SELECT * FROM ORDERS";

        //       sql = "SELECT * FROM "+textBox1.Text;
        //       FbConnection _FbConnection = new FbConnection();
        //       //'_FbConnection.ConnectionString=@"Server=localhost;User=SYSDBA;Password=masterkey;Database=C:\DB\STK.FDB";
        //       _FbConnection.ConnectionString = @"Server=localhost;User=SYSDBA;Password=masterkey;Database=C:\DB\STK.FDB";
        //       DataSet ds = new DataSet();


        //       FbDataAdapter adapter = new FbDataAdapter(sql, _FbConnection);
        //       adapter.Fill(ds);
        //           var  sbt = new StringBuilder();
        ////For insert
        //       foreach (DataColumn _DataColumn in ds.Tables[0].Columns)
        // {

        //     textBox2.Text +=  _DataColumn.DataType.Name + " _"+ _DataColumn.ColumnName + "; \r\n";
        //     textBox2.Text += "public " + _DataColumn.DataType.Name + " " + _DataColumn.ColumnName + " { get { return _" + _DataColumn.ColumnName + "; } set { _" + _DataColumn.ColumnName + " = value; } } \r\n \r\n";
        // }
        //       //Code Behine  new FbParameter(":LINE_R2_CODE", _LINE_R2_CODE)
        //       textBox3.Text = "  var prset = new List<IDataParameter> {";
        //       foreach (DataColumn _DataColumn in ds.Tables[0].Columns)
        //       {


        //           textBox3.Text += string.Format(@",new FbParameter("":{0}"", _{0})",_DataColumn.ColumnName)
        //           ;

        //       }
        //       //for Object 



        //   }
    }
}
