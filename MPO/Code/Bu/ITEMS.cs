using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BarcodeLib;
using Stk.Base;

namespace MPO.Code.Bu
{
    public class ITEMS : Stk_BuBase_R2
    {
            public ITEMS()
            {
                change = false;

            }

        public bool change { get; set; }
        public string ORDE_ID { get; set; }

        public void validateItems(string _STK_ID, string _ITEMS)
        {


            if (change == true)
            {
                Change(_STK_ID, _ITEMS);
            }
            else
            {
                Nomal(_STK_ID, _ITEMS);
            }
     

        }




        void Change(string _STK_ID, string _ITEMS)
        {

            MPO_ODERDETAILS  mpoOderdetails=new MPO_ODERDETAILS();
            mpoOderdetails = mpoOderdetails.Get(ORDE_ID);
            int OlrdOrder = mpoOderdetails.ITEMS;

            int _HoldItems = HoldItems(_STK_ID) - OlrdOrder;


            int _OrderItem = Convert.ToInt32(_ITEMS);


            int _StockItem = StockItem(_STK_ID);

            if ((_StockItem - _HoldItems - _OrderItem) < 0)
            {
                throw new Exception("Not Enoungh item");
            }
        }
        void Nomal(string _STK_ID, string _ITEMS)
        {

            int _HoldItems = HoldItems(_STK_ID);


            int _OrderItem = Convert.ToInt32(_ITEMS);




            int _StockItem = StockItem(_STK_ID);





            if ((_StockItem - _HoldItems - _OrderItem) < 0)
            {
                throw new Exception("Not Enoungh item");
            }
        }

  

        public int Avaliableitem(string _STK_ID)
        {
            int _HoldItems = HoldItems(_STK_ID);


            int _StockItem = StockItem(_STK_ID);


            return _StockItem - _HoldItems;

        }

        public int HoldItems(string _STK_ID)
        {
            int _HoldItems;// = Convert.ToInt32(DB_R2.FbExecuteScalar("    SELECT sum(  ITEMS) FROM MPO_ODERDETAILS WHERE STK_ID = " + _STK_ID));
            try
            {
                _HoldItems = Convert.ToInt32(DB_R2.FbExecuteScalar("    SELECT sum(  ITEMS) FROM MPO_ODERDETAILS WHERE  STATUS_CURRENT='' AND STK_ID = " + _STK_ID));
            }
            catch (Exception)
            {

                _HoldItems = 0;
            }
            return _HoldItems;
        }
        public int StockItem(string _STK_ID)
        {
            int _StockItem;//=Convert.ToInt32(DB_R2.FbExecuteScalar("    SELECT sum(  ITEMS) FROM MPO_STOCK WHERE STK_ID = " + _STK_ID));
            try
            {
                _StockItem =
                Convert.ToInt32(DB_R2.FbExecuteScalar("    SELECT sum(  ITEMS) FROM MPO_STOCK WHERE STK_ID = " + _STK_ID));
            }
            catch (Exception)
            {
                _StockItem = 0;

            }
            return _StockItem;
        }

    }
}