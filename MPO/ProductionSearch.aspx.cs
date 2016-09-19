using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Bu;

namespace MPO
{
    public partial class ProductionSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var p=new MPO_PRODUCT();
            GridView1.DataSource = p.Search();
           GridView1.DataBind();
        }
    }
}