using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPO.Code.Bu;

namespace MPO.Code.TempData
{
    public class TempProduct
    {

        public static MPO_PRODUCT TEMP_MPO_PRODUCT
        {
            get
            {
                object _TEMP_MPO_PRODUCT = System.Web.HttpContext.Current.Session["TEMP_MPO_PRODUCT"];
                if (_TEMP_MPO_PRODUCT == null)
                {
                    return null;
                }
                return (MPO_PRODUCT)_TEMP_MPO_PRODUCT;
            }
            set { System.Web.HttpContext.Current.Session["TEMP_MPO_PRODUCT"] = value; }
        }


        public static void  SetProductByLot(string Lot)
        {
            MPO_PRODUCT p = new MPO_PRODUCT();

            p=p.Get(Lot);

            TEMP_MPO_PRODUCT = p;

        }


        public static void ClearProduct()
        {
             
            TEMP_MPO_PRODUCT = null;

        }


    }
}