using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using Stk.Security;

namespace MPO
{
    public partial class Login : System.Web.UI.Page
    {

        private void Sigon()
        {


            Logon lg = new Logon();
            if (lg.ValidateUser(txtUserName.Text, txtUserPass.Text))
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;


                STkRolesGroup stkRole = new STkRolesGroup();
                string Roles;
                Roles = stkRole.GetRole(lg);


                //var stkEmployee = new Bu.Stk_Employee();

                //stkEmployee.GetEmployee(txtUserName.Text.Trim());
                tkt = new FormsAuthenticationTicket(1, txtUserName.Text, DateTime.Now, DateTime.Now.AddMinutes(50), chkPersistCookie.Checked, Roles);

                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                if (chkPersistCookie.Checked)
                    ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);


                string strRedirect;
                strRedirect = Request["ReturnUrl"];
                if (strRedirect == null)
                {
                    strRedirect = "default.aspx";

                }



                Response.Redirect(strRedirect, true);

            }
            else
            {
                lblError.Visible = true;
                //Response.Redirect("login.aspx", true);
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Sigon();
        }
    }
}