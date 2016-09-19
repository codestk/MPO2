using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPO.Code.Common;
using MPO.Code.TempData;
using Stk.Common;
using Stk.Security;

namespace MPO
{
    public partial class VerifyPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            Logon lg=new Logon();
            string u = StkUser.GetCurrentUser();
            string p = txtPWd.Text;
            if (lg.ValidateUser(u, p))
            {
                lblMsg.Text = "";

                string PR_LOT = Stk_QueryString.DecryptQuery("PR_LOT");
                VerData.PR_LOT_VerData = PR_LOT;
                StkClosePopUp.CloseAjax(btnVer);
              
            }
            else
            {
                lblMsg.Text = "Password ไม่ถูกต้อง!!!";

            }
        }
    }
}