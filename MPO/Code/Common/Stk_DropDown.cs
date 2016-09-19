﻿using System.Web.UI.WebControls;
using MPO.Code.Bu;
using Stk.Bu;

namespace MPO.Code.Common
{
    /// <summary>
    ///     All Drop Down In this PAge
    /// </summary>
    public class StkDropDown
    {
        public static void SetDropSource(DropDownList drpList)
        {
            var source = new Source();
            drpList.DataSource = source.GetAll();
            drpList.DataTextField = "NAME";
            drpList.DataValueField = "NAME";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }


        public static void SetDropFish(DropDownList drpList)
        {
            var source = new FISH();
            drpList.DataSource = source.GetAll();
            drpList.DataTextField = "FISH_ID";
            drpList.DataValueField = "FISH_ID";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }

        public static void SetDropLinecolor(DropDownList drpList)
        {
            var source = new MPO_COLOR();
            drpList.DataSource = source.GetAll();
            drpList.DataTextField = "PR_LINE_COLOR";
            drpList.DataValueField = "PR_LINE_COLOR";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }


        public static void SetDropLine(DropDownList drpList)
        {
            var source = new MPO_LINE();
            drpList.DataSource = source.GetAll();
            drpList.DataTextField = "PR_LINE";
            drpList.DataValueField = "PR_LINE";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }




        public static void SetDropFishSize(DropDownList drpList)
        {
            var source = new MPO_SIZE();
            drpList.DataSource = source.GetAll();
            drpList.DataTextField = "MPO_SIZE";
            drpList.DataValueField = "MPO_SIZE";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }


        public static void SetDropFishSize(DropDownList drpList, string fishId)
        {
            var source = new FISH();
            drpList.DataSource = source.GetSize(fishId);
            drpList.DataTextField = "SIZE";
            drpList.DataValueField = "SIZE";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }


        public static void SetDropLocation(DropDownList drpList)
        {
            var source = new MPO_LOCATION();
            drpList.DataSource = source.GetLocations();
            drpList.DataTextField = source.STKText;
            drpList.DataValueField = source.STKValue;

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }

        public static void SetDropRoom(DropDownList drpList)
        {
            var source = new MPO_LOCATION();
            drpList.DataSource = source.GetRooms();
            drpList.DataTextField = "ROOM_ID";
            drpList.DataValueField = "ROOM_ID";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }


        public static void SetDropLINE_COLOR(DropDownList drpList)
        {
            drpList.DataSource = (new DATA_DROP()).drpPR_LINE_COLOR();
            drpList.DataTextField = "PR_LINE_COLOR";
            drpList.DataValueField = "PR_LINE_COLOR";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }

        public static void SetdrpBOX_TYPE(DropDownList drpList)
        {
            drpList.DataSource = (new DATA_DROP()).drpPR_BOX_TYPE();
            drpList.DataTextField = "PR_BOX_TYPE";
            drpList.DataValueField = "PR_BOX_TYPE";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }


        public static void SetdrpFreshness(DropDownList drpList)
        {
            drpList.DataSource = (new DATA_DROP()).drpPR_CONDITION();
            drpList.DataTextField = "PR_CONDITION";
            drpList.DataValueField = "PR_CONDITION";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }

        public static void SetdrpCondition(DropDownList drpList)
        {
            drpList.DataSource = (new DATA_DROP()).drpPR_CONDITION();
            drpList.DataTextField = "PR_CONDITION";
            drpList.DataValueField = "PR_CONDITION";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }


        public static void SetdrpColor(DropDownList drpList)
        {
            //drpList.DataSource = (new DATA_DROP()).drpColor();
            //drpList.DataTextField = "Color";
            //drpList.DataValueField = "Color";

            drpList.DataSource = (new DATA_DROP()).drpPR_LINE_COLOR();
            drpList.DataTextField = "PR_LINE_COLOR";
            drpList.DataValueField = "PR_LINE_COLOR";
            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }


        public static void SetdrpMoisture(DropDownList drpList)
        {
            drpList.DataSource = (new DATA_DROP()).drpMOISTURE();
            drpList.DataTextField = "MOISTURE";
            drpList.DataValueField = "MOISTURE";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }


        public static void SetdrpDarn(DropDownList drpList)
        {
            drpList.DataSource = (new DATA_DROP()).drpDARN();
            drpList.DataTextField = "DARN";
            drpList.DataValueField = "DARN";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }

        public static void SetdrpOdour(DropDownList drpList)
        {
            drpList.DataSource = (new DATA_DROP()).drpOdour();
            drpList.DataTextField = "ODOUR";
            drpList.DataValueField = "ODOUR";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }

        public static void SetdrpPh(DropDownList drpList)
        {
            drpList.DataSource = (new DATA_DROP()).drpPH();
            drpList.DataTextField = "PH";
            drpList.DataValueField = "PH";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }


        public static void SetdrpSpot(DropDownList drpList)
        {
            drpList.DataSource = (new DATA_DROP()).drpSPOT();
            drpList.DataTextField = "SPOT";
            drpList.DataValueField = "SPOT";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }

        public static void SetdrpKubomi(DropDownList drpList)
        {
            drpList.DataSource = (new DATA_DROP()).drpKUBOMI();
            drpList.DataTextField = "KUBOMI";
            drpList.DataValueField = "KUBOMI";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }


        public static void SetdrpJELLY_ST(DropDownList drpList)
        {
            drpList.DataSource = (new DATA_DROP()).drpJELLY_ST();
            drpList.DataTextField = "JELLY_ST";
            drpList.DataValueField = "JELLY_ST";

            drpList.DataBind();
            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }


        public static void SetdrpCustomer(DropDownList drpList)
        {
            var customer = new MPO_CUSTOMER_R2();
            drpList.DataSource = customer.GetSource();
            drpList.DataTextField = MPO_CUSTOMER_R2.DataText;
            drpList.DataValueField = MPO_CUSTOMER_R2.DataValue;
            drpList.DataBind();

            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }


        public static void SetdrpSell(DropDownList drpList)
        {
            var em = new Stk_Employee();
            drpList.DataSource = em.GetSeller();
            drpList.DataTextField = "NAME";
            drpList.DataValueField = "EM_ID";
            drpList.DataBind();

            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }

        public static void SetDropFreshness(DropDownList drpList)
        {
            var f = new MPO_FRESHNESS();
            drpList.DataSource = f.GetAll();
            drpList.DataTextField = "PR_FRESHNESS";
            drpList.DataValueField = "PR_FRESHNESS";
            drpList.DataBind();

            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }

        public static void SetdrpQc(DropDownList drpList)
        {
            var em = new Stk_Employee();
            drpList.DataSource = em.GetQc();
            drpList.DataTextField = "NAME";
            drpList.DataValueField = "EM_ID";
            drpList.DataBind();

            var lt = new ListItem("กรุณาระบุ", "0");
            drpList.Items.Insert(0, lt);
        }
    }
}