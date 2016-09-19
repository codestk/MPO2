using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPO.Code.Bu.ColumnGrid
{
    public class GetCommonColumn
    {


        public static string GetProductName(object prlot)
        {
            MPO_PRODUCT mpo = new MPO_PRODUCT();

            return mpo.GetProductName(prlot.ToString());
        }

        public  static string GetCustomerName(object CUS_ID)
        {
            int _cut = Convert.ToInt32(CUS_ID);
            var c = new MPO_CUSTOMER_R2();
            c = c.GetSource(_cut);

            if (c == null)
            {
                return "-";
            }

            return c.COMPANY;
        }

        public static string ConvertOrderStatus(object STATUS)
        {
            if (STATUS == null)
                return "<img src='images/our_process_icon.jpg' title='อยู่ระหว่างนำออก' />";


            if (STATUS.ToString() == "Y")
                return "<img src='images/success1.gif' title='ส่งสินค้าเรียบร้อย' />";


            if (STATUS.ToString() == "")
            {
                return "<img src='images/our_process_icon.jpg' title='อยู่ระหว่างนำออก' />";
            }


            return STATUS.ToString();
        }

         //=============================================================

        /// <summary>
        /// C = Complete
        /// N = Calcel
        /// NULL = Non ChineID
        /// P = PEnding
        /// </summary>
        /// <param name="STATUS"></param>
        /// <returns></returns>
        public static string ConvertProductStatus(object STATUS)
        {
            if (STATUS == null)
                return "<img src='images/pending.gif' title='ระหว่างจัดเก็บ' />";


            if (STATUS.ToString() == "N")
                return "<img src='images/cancel.png' title='ยกเลิก' />";

            if (STATUS.ToString() == "P")
                return "<img src='images/Qc.png' title='รอ QC' />";

            if (STATUS.ToString() == "C")
                return "<img src='images/success1.gif' title='นำเข้าคลังเรียบร้อย' />";

              if (STATUS.ToString() == "R")
                  return "<img src='images/reject.png' title='ไม่ผ่าน QC' />";
           

            return STATUS.ToString();
        }

    }
}