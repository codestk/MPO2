using System.Web;

namespace MPO.Code.TempData
{
    public class VerData
    {
        //Use
        //Product PR_LOT
        //USe  1 time
        public static string PR_LOT_VerData
        {
            get
            {
                object VerData_PR_LOT = System.Web.HttpContext.Current.Session["VerData_PR_LOT"];
                if (VerData_PR_LOT == null)
                {
                    return null;
                }
                HttpContext.Current.Session["VerData_PR_LOT"] = null;

                return (string)VerData_PR_LOT;
            }
            set { HttpContext.Current.Session["VerData_PR_LOT"] = value; }
        }

    }
}