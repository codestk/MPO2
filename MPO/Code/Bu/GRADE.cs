using System;

namespace MPO.Code.Bu
{
    public class GRADE
    {
        public MPO_STOCK StockQC { get; set; }

        public string GetGRADE(string FISHID)
        {
            if ((FISHID == "I0") || (FISHID == "I7") || (FISHID == "K0") || (FISHID == "K5") || (FISHID == "G"))
                return I0_I7_K0_K5_G();


            if (FISHID == "I9")
                return I9();

            if ((FISHID == "K04") || (FISHID == "K72"))
                return K04_K72();


            if ((FISHID == "I82") || (FISHID == "I83"))
                return I82_I83();


            if ((FISHID == "I84") || (FISHID == "I85") || (FISHID == "I89") || (FISHID == "I3"))
                return I84_I85_I89_I3();

            if (FISHID == "K9")
                return K9();

            if (FISHID == "H0")
                return H0();
            if ((FISHID == "HI04") || (FISHID == "I54"))
                return HI04_I54();

            if ((FISHID == "E12") || (FISHID == "ESO"))
                return E12_ESO();


            if ((FISHID == "E03"))
                return E03();

            if ((FISHID == "E22"))
                return E22();
            if ((FISHID == "E9"))
                return E9();
            if ((FISHID == "TW") || (FISHID == "TWD"))
                return TW_TWD();

            //พิเศษ
            if ((FISHID == "I0 พิเศษ") || (FISHID == "I7 พิเศษ") || (FISHID == "K0 พิเศษ") || (FISHID == "G พิเศษ"))
                return I0_I7_K0_G_SPEC();


            if ((FISHID == "I82 พิเศษ") || (FISHID == "I83 พิเศษ"))
                return I82_I83_SPEC();


            if ((FISHID == "I32 พิเศษ") || (FISHID == "I33 พิเศษ"))
                return I32_I33_SPEC();


            if ((FISHID == "H0 พิเศษ"))
                return H0_SPEC();

            if ((FISHID == "E22 พิเศษ"))
                return E22_SPEC();


            throw new Exception("Can not identity grade");
        }


        //=(IF($R9>1099,"OA",IF($R9>1049,"SA+",IF($R9>899,"SA",IF($R9>849,"2A+",IF($R9>699,"2A",IF($R9>649,"A+",IF($R9>549,"A","B"))))))))
        private string I0_I7_K0_K5_G()
        {
            if (StockQC.JELLY_ST > 1099)
            {
                return "OA";
            }
            if (StockQC.JELLY_ST > 1049)
            {
                return "SA+";
            }

            if (StockQC.JELLY_ST > 899)
            {
                return "SA";
            }

            if (StockQC.JELLY_ST > 849)
            {
                return "2A+";
            }
            if (StockQC.JELLY_ST > 699)
            {
                return "2A";
            }

            if (StockQC.JELLY_ST > 649)
            {
                return "A+";
            }

            if (StockQC.JELLY_ST > 549)
            {
                return "A";
            }


            return "B";
        }


        // =IF($Q10<1,"B",IF($S10<50,"B",IF($M10<7,"B",IF($R10>299,"A","B"))))
        private string I9()
        {
            if (StockQC.KUBOMI < 1)
            {
                return "B";
            }
            if (StockQC.COLOR < 50)
            {
                return "B";
            }
            if (StockQC.SPOT < 7)
            {
                return "B";
            }
            if (StockQC.JELLY_ST > 299)
            {
                return "A";
            }


            return "B";
        }

        //=IF($Q11<1,"B",IF($S11<50,"B",IF($M11<7,"B",IF($R11>599,"A+",IF($R11>499,"A","B")))))
        private string K04_K72()
        {
            if (StockQC.KUBOMI < 1)
            {
                return "B";
            }

            if (StockQC.COLOR < 50)
            {
                return "B";
            }

            if (StockQC.SPOT < 7)
            {
                return "B";
            }
            if (StockQC.JELLY_ST > 599)
            {
                return "+A";
            }
            if (StockQC.JELLY_ST > 499)
            {
                return "A";
            }


            return "B";
        }

        //=IF($Q12<0.9,"B",IF($M12<4,"B",IF($S12<50,"B",IF($R12>799,"SA",IF($R12>599,"2A",IF($R12>399,"A","B"))))))
        //=IF($Q13<0.9,"B",IF($M13<7,"B",IF($S13<50,"B",IF($R13>799,"SA",IF($R13>599,"2A",IF($R13>399,"A","B"))))))
        private string I82_I83()
        {
            double _KUBOMI = Convert.ToDouble(StockQC.KUBOMI);

            if (_KUBOMI < 0.9f)
            {
                return "B";
            }

            if (StockQC.SPOT < 4)
            {
                return "B";
            }
            if (StockQC.COLOR < 50)
            {
                return "B";
            }
            if (StockQC.JELLY_ST > 799)
            {
                return "SA";
            }
            if (StockQC.JELLY_ST > 599)
            {
                return "2A";
            }
            if (StockQC.JELLY_ST > 399)
            {
                return "A";
            }


            return "B";
        }

        //=IF($Q13<0.9,"B",IF($M13<7,"B",IF($S13<50,"B",IF($R13>799,"SA",IF($R13>599,"2A",IF($R13>399,"A","B"))))))
        private string I84_I85_I89_I3()
        {
            double _KUBOMI = Convert.ToDouble(StockQC.KUBOMI);

            if (_KUBOMI < 0.9f)
            {
                return "B";
            }

            if (StockQC.SPOT < 7)
            {
                return "B";
            }
            if (StockQC.COLOR < 50)
            {
                return "B";
            }
            if (StockQC.JELLY_ST > 799)
            {
                return "SA";
            }
            if (StockQC.JELLY_ST > 599)
            {
                return "2A";
            }
            if (StockQC.JELLY_ST > 399)
            {
                return "A";
            }


            return "B";
        }

        //=IF($Q14<1,"B",IF($M14<7,"B",IF($S14<46,"B",IF($R14>299,"A","B"))))
        private string K9()
        {
            double _KUBOMI = Convert.ToDouble(StockQC.KUBOMI);

            if (_KUBOMI < 1f)
            {
                return "B";
            }

            if (StockQC.SPOT < 7)
            {
                return "B";
            }
            if (StockQC.COLOR < 14)
            {
                return "B";
            }
            if (StockQC.JELLY_ST > 299)
            {
                return "A";
            }


            return "B";
        }

        //=IF($Q15<0.9,"B",IF($M15<9,"B",IF($S15<50,"B",IF($R15>799,"SA",IF($R15>599,"2A",IF($R15>449,"A","B"))))))
        private string H0()
        {
            double _KUBOMI = Convert.ToDouble(StockQC.KUBOMI);

            if (_KUBOMI < 0.9f)
            {
                return "B";
            }

            if (StockQC.SPOT < 9)
            {
                return "B";
            }
            if (StockQC.COLOR < 50)
            {
                return "B";
            }
            if (StockQC.JELLY_ST > 799)
            {
                return "SA";
            }
            if (StockQC.JELLY_ST > 599)
            {
                return "2A";
            }
            if (StockQC.JELLY_ST > 499)
            {
                return "A";
            }


            return "B";
        }

        //=IF($Q16<1,"B",IF($S16<40,"B",IF($M16<6,"B",IF($R16>799,"SA",IF($R16>599,"2A",IF($R16>399,"A","B"))))))
        private string HI04_I54()
        {
            double _KUBOMI = Convert.ToDouble(StockQC.KUBOMI);

            if (_KUBOMI < 1)
            {
                return "B";
            }
            if (StockQC.COLOR < 40)
            {
                return "B";
            }
            if (StockQC.SPOT < 6)
            {
                return "B";
            }

            if (StockQC.JELLY_ST > 799)
            {
                return "SA";
            }
            if (StockQC.JELLY_ST > 599)
            {
                return "2A";
            }
            if (StockQC.JELLY_ST > 399)
            {
                return "A";
            }


            return "B";
        }

        //=IF($Q17<0.5,"B",IF($M17<7,"B",IF($S17<50,"B",IF($R17>99,"A","B"))))
        private string E12_ESO()
        {
            double _KUBOMI = Convert.ToDouble(StockQC.KUBOMI);

            if (_KUBOMI < 0.5)
            {
                return "B";
            }

            if (StockQC.SPOT < 7)
            {
                return "B";
            }
            if (StockQC.COLOR < 50)
            {
                return "B";
            }


            if (StockQC.JELLY_ST > 99)
            {
                return "A";
            }


            return "B";
        }


        //=IF($Q18<0.5,"B",IF($M18<7,"B",IF($S18<48,"B",IF($R18>99,"A","B"))))
        private string E03()
        {
            double _KUBOMI = Convert.ToDouble(StockQC.KUBOMI);

            if (_KUBOMI < 0.5)
            {
                return "B";
            }

            if (StockQC.SPOT < 7)
            {
                return "B";
            }
            if (StockQC.COLOR < 48)
            {
                return "B";
            }


            if (StockQC.JELLY_ST > 99)
            {
                return "A";
            }


            return "B";
        }

        //=IF($Q19<0.5,"B",IF($M19<7,"B",IF($S19<46,"B",IF($R19>99,"A","B"))))
        private string E22()
        {
            double _KUBOMI = Convert.ToDouble(StockQC.KUBOMI);

            if (_KUBOMI < 0.5)
            {
                return "B";
            }

            if (StockQC.SPOT < 7)
            {
                return "B";
            }
            if (StockQC.COLOR < 46)
            {
                return "B";
            }


            if (StockQC.JELLY_ST > 99)
            {
                return "A";
            }


            return "B";
        }

        //=IF($Q20<0.5,"B",IF($M20<7,"B",IF($S20<40,"B",IF($R20>99,"A","B"))))
        //E9
        private string E9()
        {
            double _KUBOMI = Convert.ToDouble(StockQC.KUBOMI);

            if (_KUBOMI < 0.5)
            {
                return "B";
            }

            if (StockQC.SPOT < 7)
            {
                return "B";
            }
            if (StockQC.COLOR < 40)
            {
                return "B";
            }


            if (StockQC.JELLY_ST > 99)
            {
                return "A";
            }


            return "B";
        }

        //=IF($Q21<0.9,"B",IF($S21<48,"B",IF($R21>299,"A","B")))
        private string TW_TWD()
        {
            double _KUBOMI = Convert.ToDouble(StockQC.KUBOMI);

            if (_KUBOMI < 0.9)
            {
                return "B";
            }
            if (StockQC.COLOR < 48)
            {
                return "B";
            }
            //if (StockQC.SPOT < 7)
            //{
            //    return "B";
            //}


            if (StockQC.JELLY_ST > 299)
            {
                return "A";
            }


            return "B";
        }

        //=IF($Q22<1,"B",IF($S22<50,"B",IF($M22<7,"B",IF($R22>999,"OA",IF($R22>799,"SA",IF($R22>599,"2A",IF($R22>=450,"A","B")))))))
        //I0 I7 K0 G พิเศษ
        private string I0_I7_K0_G_SPEC()
        {
            double _KUBOMI = Convert.ToDouble(StockQC.KUBOMI);

            if (_KUBOMI < 1)
            {
                return "B";
            }
            if (StockQC.COLOR < 50)
            {
                return "B";
            }
            if (StockQC.SPOT < 7)
            {
                return "B";
            }


            if (StockQC.JELLY_ST > 999)
            {
                return "OA";
            }
            if (StockQC.JELLY_ST > 799)
            {
                return "SA";
            }
            if (StockQC.JELLY_ST > 599)
            {
                return "2A";
            }
            if (StockQC.JELLY_ST > 450)
            {
                return "A";
            }

            return "B";
        }

        //I82 I83 พิเศษ 
        //=IF($Q23<0.9,"B",IF($M23<4,"B",IF($S23<50,"B",IF($R23>699,"SA",IF($R23>499,"2A",IF($R23>299,"A","B"))))))
        private string I82_I83_SPEC()
        {
            double _KUBOMI = Convert.ToDouble(StockQC.KUBOMI);

            if (_KUBOMI < 0.9)
            {
                return "B";
            }
            if (StockQC.SPOT < 4)
            {
                return "B";
            }

            if (StockQC.COLOR < 50)
            {
                return "B";
            }


            if (StockQC.JELLY_ST > 699)
            {
                return "SA";
            }
            if (StockQC.JELLY_ST > 499)
            {
                return "2A";
            }
            if (StockQC.JELLY_ST > 299)
            {
                return "A";
            }


            return "B";
        }

        //=IF($Q24<0.9,"B",IF($M24<7,"B",IF($S24<50,"B",IF($R24>699,"SA",IF($R24>499,"2A",IF($R24>399,"A","B"))))))
        //I32 I33 พิเศษ
        private string I32_I33_SPEC()
        {
            double _KUBOMI = Convert.ToDouble(StockQC.KUBOMI);

            if (_KUBOMI < 0.9)
            {
                return "B";
            }
            if (StockQC.SPOT < 7)
            {
                return "B";
            }

            if (StockQC.COLOR < 50)
            {
                return "B";
            }


            if (StockQC.JELLY_ST > 699)
            {
                return "SA";
            }
            if (StockQC.JELLY_ST > 499)
            {
                return "2A";
            }
            if (StockQC.JELLY_ST > 299)
            {
                return "A";
            }


            return "B";
        }

        //=IF($Q25<0.9,"B",IF($M25<9,"B",IF($S25<50,"B",IF($R25>699,"SA",IF($R25>499,"2A",IF($R25>349,"A","B"))))))
        //H0 พิเศษ
        private string H0_SPEC()
        {
            double _KUBOMI = Convert.ToDouble(StockQC.KUBOMI);

            if (_KUBOMI < 0.9)
            {
                return "B";
            }
            if (StockQC.SPOT < 9)
            {
                return "B";
            }

            if (StockQC.COLOR < 50)
            {
                return "B";
            }


            if (StockQC.JELLY_ST > 699)
            {
                return "SA";
            }
            if (StockQC.JELLY_ST > 499)
            {
                return "2A";
            }
            if (StockQC.JELLY_ST > 349)
            {
                return "A";
            }


            return "B";
        }

        //=IF($Q26<0.5,"B",IF($S26<46,"B",IF($R26>99,"A","B")))
        //E22 ใต้แทงก์
        private string E22_SPEC()
        {
            double _KUBOMI = Convert.ToDouble(StockQC.KUBOMI);

            if (_KUBOMI < 0.5)
            {
                return "B";
            }
            //if (StockQC.SPOT < 9)
            //{
            //    return "B";
            //}

            if (StockQC.COLOR < 46)
            {
                return "B";
            }


            if (StockQC.JELLY_ST > 99)
            {
                return "A";
            }


            return "B";
        }
    }
}