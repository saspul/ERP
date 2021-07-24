using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit;
using CL_Compzit;
using DL_Compzit;

namespace BL_Compzit
{

    public class clsBusinessLayer
    {
        //Creating object for datalayer.
        clsDataLayer objDataLayer = new clsDataLayer();

        public DataTable ReadFinancialYear(clsEntityCommon objEntCommon)
        {
            clsDataLayer objDataLayer = new clsDataLayer();
            DataTable dtFin = new DataTable();
            dtFin = objDataLayer.ReadFinancialYear(objEntCommon);
            return dtFin;
        }
        public DataTable ReadFinancialYearById(clsEntityCommon objEntCommon)
        {
            clsDataLayer objDataLayer = new clsDataLayer();
            DataTable dtFin = new DataTable();
            dtFin = objDataLayer.ReadFinancialYearById(objEntCommon);
            return dtFin;
        }
        public DataTable ReadAccountClsDate(clsEntityCommon objEntCommon)
        {
            clsDataLayer objDataLayer = new clsDataLayer();
            DataTable dtConfig = new DataTable();
            dtConfig = objDataLayer.ReadAccountClsDate(objEntCommon);
            return dtConfig;
        }

        //It build the Html List by using the datatable provided
        public string ConvertDataTableToHTML_List(DataTable dt, string strUrl)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            StringBuilder sb = new StringBuilder();
            string strHtml = "<h2 >Choose Corporate Office</h2>";
            strHtml += "</br>";
            //add ul
            strHtml += "<ul class=\"ulCorp\">";

            //add li

            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                int intCorpOffcId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CORPRT_ID"].ToString());
                string strCorpName = dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString();

                strHtml += "<li style=\"cursor: pointer;\" class=\"liCorp\">";


                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                strHtml += " <a style=\"cursor: pointer;\"  onclick='return getdetails(this.href);' " +
                              " href=\"" + strUrl + "?CId=" + Id + "\">" + strCorpName + "</a>";

                strHtml += "</li>";

            }

            strHtml += "</ul>";
            sb.Append(strHtml);
            return sb.ToString();
        }


        //method to load current date and time
        public DateTime LoadCurrentDate()
        {
            clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
            DateTime dateCurrent = objDataLayerDateTime.DateAndTime();
            return dateCurrent;
        }

        //method to load current date and time IN STRING IN 'DD-MM-YYYY' FORMAT
        public string LoadCurrentDateInString()
        {
            clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
            string strdateCurrent = objDataLayerDateTime.DateAndTimeString();
            return strdateCurrent;
        }
        //method that Concatinate Columns of GN_CORP_GLOBAL and read the global values relating to a corporate
        public DataTable LoadGlobalDetail(clsCommonLibrary.CORP_GLOBAL[] enumertn, int intCorprtId = 0)
        {
            DataTable dtDefault = new DataTable();
            string strColumns = "";
            for (int intcount = 0; intcount < enumertn.Length; intcount++)
            {
                if (intcount == 0)
                {


                    strColumns = enumertn[intcount].ToString();

                }
                else
                {

                    strColumns = strColumns + "," + enumertn[intcount].ToString();


                }
            }
            dtDefault = objDataLayer.LoadGlobalDetail(strColumns, intCorprtId);
            return dtDefault;
        }

        //method that Concatinate Columns of GN_CORP_SUB_GLOBAL and read the global values relating to a corporate
        public DataTable Load_Sub_GlobalDetail(clsCommonLibrary.CORP_SUB_GLOBAL[] enumertn, int intCorprtId = 0)
        {
            DataTable dtDefault = new DataTable();
            string strColumns = "";
            for (int intcount = 0; intcount < enumertn.Length; intcount++)
            {
                if (intcount == 0)
                {

                    strColumns = enumertn[intcount].ToString();
                }
                else
                {
                    strColumns = strColumns + "," + enumertn[intcount].ToString();
                }
            }
            dtDefault = objDataLayer.Load_Sub_GlobalDetail(strColumns, intCorprtId);
            return dtDefault;
        }

        //method that Concatinate Columns of APP_COMPANY  and read the Company values 
        public DataTable LoadCompanyDetail(clsCommonLibrary.APP_COMPANY[] enumertn)
        {
            DataTable dtDefault = new DataTable();
            string strColumns = "";
            for (int intcount = 0; intcount < enumertn.Length; intcount++)
            {
                if (intcount == 0)
                {

                    strColumns = enumertn[intcount].ToString();
                }
                else
                {
                    strColumns = strColumns + "," + enumertn[intcount].ToString();
                }
            }
            dtDefault = objDataLayer.LoadCompanyDetail(strColumns);
            return dtDefault;
        }


        public string ReadRefNumberOnlyWeb(clsEntityCommon objEntCommon)
        {
            string strRefNum = objDataLayer.ReadRefNumberOnlyWeb(objEntCommon);
            return strRefNum;
        }
        public string ReadNextNumberWebForUI(clsEntityCommon objEntCommon)
        {
            string strPKNxtNumbr = objDataLayer.ReadNextNumberWebForUI(objEntCommon);
            return strPKNxtNumbr;
        }
        public string ReadNextNumber(clsEntityCommon objEntCommon)
        {
            string strPKNxtNumbr = objDataLayer.ReadNextNumber(objEntCommon);
            return strPKNxtNumbr;
        }

        //method to load Detail from GN_config Table
        public DataTable LoadConfigDetail()
        {
            clsDataLayer objDataLayer = new clsDataLayer();
            DataTable dtConfig = new DataTable();
            dtConfig = objDataLayer.LoadConfigDetail();
            return dtConfig;
        }
        //check the unit breakable condition so pass unit id
        public string CheckUnit(clsEntityCommon objEntityCommon)
        {
            string strReturn = objDataLayer.CheckUnit(objEntityCommon);
            return strReturn;
        }
        public DataTable LoadChildRoleDefnDetail(int intUserId, int intUsrolMstrId)
        {
            DataTable dtChildRoleDefn = new DataTable();
            dtChildRoleDefn = objDataLayer.LoadChildRoleDefnDetail(intUserId, intUsrolMstrId);
            return dtChildRoleDefn;
        }
        public DataTable LoadUserRolMstrIdByUserId(int intUserId)
        {
            DataTable dtUsrRoleMstrDtl = new DataTable();
            dtUsrRoleMstrDtl = objDataLayer.LoadUserRolMstrIdByUserId(intUserId);
            return dtUsrRoleMstrDtl;
        }

        //fetch preference for stock id that generate barcod
        public string ReadStkIdPreference()
        {
            DataTable dtOut = objDataLayer.ReadStockIdPreference();
            string strPreference = dtOut.Rows[0]["STKID_BARCODE_PREFIX"].ToString();
            return strPreference;
        }
        //to fetch Finacial Year start date and end date based on Financial year Id.
        public DataTable LoadFincyrDetail(int intFinanceYearId)
        {
            DataTable dtFyr = new DataTable();
            dtFyr = objDataLayer.LoadFincyrDetail(intFinanceYearId);
            return dtFyr;
        }
        // function to read divisions of a user based on usrId 
        public DataTable ReadDivisionsOfUser(int intUserId, int intOrgId)
        {
            DataTable dtDivisionsDtl = new DataTable();
            dtDivisionsDtl = objDataLayer.ReadDivisionsOfUser(intUserId, intOrgId);
            return dtDivisionsDtl;
        }

        //fetch lead staus based on lead id
        public DataTable ReadLeadStatus(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtLeadStatus = objDataLayer.ReadLeadStatus(objEntityLead);
            return dtLeadStatus;
        }

        //fetch all active Quotation Template
        public DataTable ReadQuotationTempalate()
        {
            DataTable dtTmplt = objDataLayer.ReadQuotationTempalate();
            return dtTmplt;
        }
        //READ TEAM NAME FROM TEAM ID
        public DataTable ReadTeamById(clsEntityLeadCreation objEntityLead)
        {
            DataTable dtTeamName = objDataLayer.ReadTeamById(objEntityLead);
            return dtTeamName;
        }
        //fetch send mail details using user corporate id for reply no mail
        public DataTable ReadFromMailDetails(clsEntityLayerUserRegistration objEntityUsrReg)
        {
            DataTable dtTeamName = objDataLayer.ReadFromMailDetails(objEntityUsrReg);
            return dtTeamName;
        }
        //fetch currency details using currency id and convert currency into words
        public string ConvertCurrencyToWords(clsEntityCommon objEntityCommon, string NetAmount)
        {
            DataTable dtCurrencyDetails = objDataLayer.ReadCurrencyDetailsById(objEntityCommon);
            string strCurrencyName = "";
            string strCurrencyNameOnly = "";
            string strCurrencyMainName = "";
            string strCurrencySubName = "";
            string strCurrencySubNamePlural = "";
            string strCurrencyMainNamePlural = "";
            int intCurrencyMode = 0;
            int intCurrencyWordFormat = 1;
            if (dtCurrencyDetails.Rows.Count > 0)
            {
                strCurrencyName = dtCurrencyDetails.Rows[0]["CRNCMST_NAME"].ToString();
                strCurrencyMainName = dtCurrencyDetails.Rows[0]["CRNCMST_MAIN_NAME"].ToString();
                strCurrencySubName = dtCurrencyDetails.Rows[0]["CRNCMST_SUB_NAME"].ToString();
                strCurrencyMainNamePlural = dtCurrencyDetails.Rows[0]["CRNCMST_MAIN_NAME_PLURAL"].ToString();
                strCurrencySubNamePlural = dtCurrencyDetails.Rows[0]["CRNCMST_SUB_NAME_PLURAL"].ToString();
                intCurrencyMode = Convert.ToInt32(dtCurrencyDetails.Rows[0]["CRNCYMD_ID"]);
                intCurrencyWordFormat = Convert.ToInt32(dtCurrencyDetails.Rows[0]["CURRENCY_WORD_FORMAT"]);
            }

            string[] SplitName = new string[2];
            SplitName = strCurrencyName.ToString().Split('(');
            strCurrencyNameOnly = strCurrencyName;
            if (SplitName[0] != "")
            {
                strCurrencyNameOnly = SplitName[0].Trim().ToUpper();

            }


            string NetAmountInNumber = NetAmount.ToString();
            string[] SplitNumber = new string[2];
            SplitNumber = NetAmountInNumber.ToString().Split('.');
            string NondecimalPart = "";
            string NonDecimalToword = "";
            if (SplitNumber.Length > 0 && SplitNumber[0] != "")
            {
                NondecimalPart = SplitNumber[0];
                NonDecimalToword = NondecimalParttoWords(Convert.ToInt64(NondecimalPart), intCurrencyMode);
            }

            string DecimalPart = "";
            string DecimalToword = "";
            if (SplitNumber.Length > 1 && SplitNumber[1] != "")
            {
                DecimalPart = SplitNumber[1];
                DecimalToword = ConvertDecimalPart(Convert.ToInt64(DecimalPart));
            }
            string FullMoneyInWords = "";
            if (intCurrencyWordFormat == 1)
            { //QAR 7000, it should be  Seven Thousand Riyals Only
                if (NonDecimalToword != "" && NonDecimalToword != "ZERO")
                {
                    if (NonDecimalToword == "ONE")
                    {
                        strCurrencyMainNamePlural = strCurrencyMainName;
                        if (DecimalToword != "")
                        {
                            if (DecimalToword == "ONE")
                            {
                                strCurrencySubNamePlural = strCurrencySubName;
                                FullMoneyInWords = NonDecimalToword + " " + strCurrencyMainNamePlural + " AND " + DecimalToword + " " + strCurrencySubNamePlural + " ONLY";
                            }
                            else
                            {
                                FullMoneyInWords = NonDecimalToword + " " + strCurrencyMainNamePlural + " AND " + DecimalToword + " " + strCurrencySubNamePlural + " ONLY";
                            }
                        }
                        else
                        {

                            FullMoneyInWords = NonDecimalToword + " " + strCurrencyMainNamePlural + " ONLY";
                        }
                    }

                    else
                    {
                        if (DecimalToword != "")
                        {
                            if (DecimalToword == "ONE")
                            {
                                strCurrencySubNamePlural = strCurrencySubName;
                                FullMoneyInWords = NonDecimalToword + " " + strCurrencyMainNamePlural + " AND " + DecimalToword + " " + strCurrencySubNamePlural + " ONLY";
                            }
                            else
                            {
                                FullMoneyInWords = NonDecimalToword + " " + strCurrencyMainNamePlural + " AND " + DecimalToword + " " + strCurrencySubNamePlural + " ONLY";
                            }
                        }
                        else
                        {

                            FullMoneyInWords = NonDecimalToword + " " + strCurrencyMainNamePlural + " ONLY";
                        }
                    }
                }
                else
                {
                    if (DecimalToword != "")
                    {
                        if (DecimalToword == "ONE")
                        {
                            strCurrencySubNamePlural = strCurrencySubName;
                            FullMoneyInWords = DecimalToword + " " + strCurrencySubNamePlural + " ONLY";
                        }
                        else
                        {
                            FullMoneyInWords = DecimalToword + " " + strCurrencySubNamePlural + " ONLY";
                        }
                    }
                    else
                    {
                        FullMoneyInWords = "ZERO";
                    }
                }
            }
            else if (intCurrencyWordFormat == 2)
            {
                //QAR 7000, it should be  Qatari Riyals Seven Thousand Only

                if (NonDecimalToword != "" && NonDecimalToword != "ZERO")
                {
                    if (NonDecimalToword == "ONE")
                    {

                        if (DecimalToword != "")
                        {
                            if (DecimalToword == "ONE")
                            {
                                strCurrencySubNamePlural = strCurrencySubName;
                                FullMoneyInWords = strCurrencyNameOnly + " " + NonDecimalToword + " AND " + strCurrencySubNamePlural + " " + DecimalToword + " ONLY";
                            }
                            else
                            {
                                FullMoneyInWords = strCurrencyNameOnly + " " + NonDecimalToword + " AND " + strCurrencySubNamePlural + " " + DecimalToword + " ONLY";
                            }
                        }
                        else
                        {

                            FullMoneyInWords = strCurrencyNameOnly + " " + NonDecimalToword + " ONLY";
                        }
                    }

                    else
                    {
                        strCurrencyNameOnly = strCurrencyNameOnly + "S";
                        if (DecimalToword != "")
                        {
                            if (DecimalToword == "ONE")
                            {
                                strCurrencySubNamePlural = strCurrencySubName;
                                FullMoneyInWords = strCurrencyNameOnly + " " + NonDecimalToword + " AND " + strCurrencySubNamePlural + " " + DecimalToword + " ONLY";
                            }
                            else
                            {
                                FullMoneyInWords = strCurrencyNameOnly + " " + NonDecimalToword + " AND " + strCurrencySubNamePlural + " " + DecimalToword + " ONLY";
                            }
                        }
                        else
                        {

                            FullMoneyInWords = strCurrencyNameOnly + " " + NonDecimalToword + " ONLY";
                        }
                    }
                }
                else
                {
                    if (DecimalToword != "")
                    {
                        if (DecimalToword == "ONE")
                        {
                            strCurrencySubNamePlural = strCurrencySubName;
                            FullMoneyInWords = DecimalToword + " " + strCurrencySubNamePlural + " ONLY";
                        }
                        else
                        {
                            FullMoneyInWords = DecimalToword + " " + strCurrencySubNamePlural + " ONLY";
                        }
                    }
                    else
                    {
                        FullMoneyInWords = "ZERO";
                    }
                }


            }
            return FullMoneyInWords;

        }
        //convert the non decimal part of the currency

        public string ConvertCurrencyToWordsWithoutCurrency(clsEntityCommon objEntityCommon, string NetAmount)
        {
            DataTable dtCurrencyDetails = objDataLayer.ReadCurrencyDetailsById(objEntityCommon);
            string strCurrencyName = "";
            string strCurrencyNameOnly = "";
            string strCurrencyMainName = "";
            string strCurrencySubName = "";
            string strCurrencySubNamePlural = "";
            string strCurrencyMainNamePlural = "";
            int intCurrencyMode = 0;
            int intCurrencyWordFormat = 1;
            if (dtCurrencyDetails.Rows.Count > 0)
            {
                strCurrencyName = dtCurrencyDetails.Rows[0]["CRNCMST_NAME"].ToString();
                strCurrencyMainName = dtCurrencyDetails.Rows[0]["CRNCMST_MAIN_NAME"].ToString();
                strCurrencySubName = dtCurrencyDetails.Rows[0]["CRNCMST_SUB_NAME"].ToString();
                strCurrencyMainNamePlural = dtCurrencyDetails.Rows[0]["CRNCMST_MAIN_NAME_PLURAL"].ToString();
                strCurrencySubNamePlural = dtCurrencyDetails.Rows[0]["CRNCMST_SUB_NAME_PLURAL"].ToString();
                intCurrencyMode = Convert.ToInt32(dtCurrencyDetails.Rows[0]["CRNCYMD_ID"]);
                intCurrencyWordFormat = Convert.ToInt32(dtCurrencyDetails.Rows[0]["CURRENCY_WORD_FORMAT"]);
            }

            string[] SplitName = new string[2];
            SplitName = strCurrencyName.ToString().Split('(');
            //strCurrencyNameOnly = strCurrencyName;
            //if (SplitName[0] != "")
            //{
            //    strCurrencyNameOnly = SplitName[0].Trim().ToUpper();

            //}


            string NetAmountInNumber = NetAmount.ToString();
            string[] SplitNumber = new string[2];
            SplitNumber = NetAmountInNumber.ToString().Split('.');
            string NondecimalPart = "";
            string NonDecimalToword = "";
            if (SplitNumber.Length > 0 && SplitNumber[0] != "")
            {
                NondecimalPart = SplitNumber[0];
                NonDecimalToword = NondecimalParttoWords(Convert.ToInt64(NondecimalPart), intCurrencyMode);
            }

            string DecimalPart = "";
            string DecimalToword = "";
            if (SplitNumber.Length > 1 && SplitNumber[1] != "")
            {
                DecimalPart = SplitNumber[1];
                DecimalToword = ConvertDecimalPart(Convert.ToInt64(DecimalPart));
            }
            string FullMoneyInWords = "";
            if (intCurrencyWordFormat == 1)
            { //QAR 7000, it should be  Seven Thousand Riyals Only
                if (NonDecimalToword != "" && NonDecimalToword != "ZERO")
                {
                    if (NonDecimalToword == "ONE")
                    {
                        strCurrencyMainNamePlural = strCurrencyMainName;
                        if (DecimalToword != "")
                        {
                            if (DecimalToword == "ONE")
                            {
                                strCurrencySubNamePlural = strCurrencySubName;
                                FullMoneyInWords = NonDecimalToword + " " + strCurrencyMainNamePlural + " AND " + DecimalToword + " " + strCurrencySubNamePlural + " ONLY";
                            }
                            else
                            {
                                FullMoneyInWords = NonDecimalToword + " " + strCurrencyMainNamePlural + " AND " + DecimalToword + " " + strCurrencySubNamePlural + " ONLY";
                            }
                        }
                        else
                        {

                            FullMoneyInWords = NonDecimalToword + " " + strCurrencyMainNamePlural + " ONLY";
                        }
                    }

                    else
                    {
                        if (DecimalToword != "")
                        {
                            if (DecimalToword == "ONE")
                            {
                                strCurrencySubNamePlural = strCurrencySubName;
                                FullMoneyInWords = NonDecimalToword + " " + strCurrencyMainNamePlural + " AND " + DecimalToword + " " + strCurrencySubNamePlural + " ONLY";
                            }
                            else
                            {
                                FullMoneyInWords = NonDecimalToword + " " + strCurrencyMainNamePlural + " AND " + DecimalToword + " " + strCurrencySubNamePlural + " ONLY";
                            }
                        }
                        else
                        {

                            FullMoneyInWords = NonDecimalToword + " " + strCurrencyMainNamePlural + " ONLY";
                        }
                    }
                }
                else
                {
                    if (DecimalToword != "")
                    {
                        if (DecimalToword == "ONE")
                        {
                            strCurrencySubNamePlural = strCurrencySubName;
                            FullMoneyInWords = DecimalToword + " " + strCurrencySubNamePlural + " ONLY";
                        }
                        else
                        {
                            FullMoneyInWords = DecimalToword + " " + strCurrencySubNamePlural + " ONLY";
                        }
                    }
                    else
                    {
                        FullMoneyInWords = "ZERO";
                    }
                }
            }
            else if (intCurrencyWordFormat == 2)
            {
                //QAR 7000, it should be  Qatari Riyals Seven Thousand Only

                if (NonDecimalToword != "" && NonDecimalToword != "ZERO")
                {
                    if (NonDecimalToword == "ONE")
                    {

                        if (DecimalToword != "")
                        {
                            if (DecimalToword == "ONE")
                            {
                                strCurrencySubNamePlural = strCurrencySubName;
                                FullMoneyInWords = strCurrencyNameOnly + " " + NonDecimalToword + " AND " + strCurrencySubNamePlural + " " + DecimalToword + " ONLY";
                            }
                            else
                            {
                                FullMoneyInWords = strCurrencyNameOnly + " " + NonDecimalToword + " AND " + strCurrencySubNamePlural + " " + DecimalToword + " ONLY";
                            }
                        }
                        else
                        {

                            FullMoneyInWords = strCurrencyNameOnly + " " + NonDecimalToword + " ONLY";
                        }
                    }

                    else
                    {
                        //strCurrencyNameOnly = strCurrencyNameOnly + "S";
                        if (DecimalToword != "")
                        {
                            if (DecimalToword == "ONE")
                            {
                                strCurrencySubNamePlural = strCurrencySubName;
                                FullMoneyInWords = strCurrencyNameOnly + " " + NonDecimalToword + " AND " + strCurrencySubNamePlural + " " + DecimalToword + " ONLY";
                            }
                            else
                            {
                                FullMoneyInWords = strCurrencyNameOnly + " " + NonDecimalToword + " AND " + strCurrencySubNamePlural + " " + DecimalToword + " ONLY";
                            }
                        }
                        else
                        {

                            FullMoneyInWords = strCurrencyNameOnly + " " + NonDecimalToword + " ONLY";
                        }
                    }
                }
                else
                {
                    if (DecimalToword != "")
                    {
                        if (DecimalToword == "ONE")
                        {
                            strCurrencySubNamePlural = strCurrencySubName;
                            FullMoneyInWords = DecimalToword + " " + strCurrencySubNamePlural + " ONLY";
                        }
                        else
                        {
                            FullMoneyInWords = DecimalToword + " " + strCurrencySubNamePlural + " ONLY";
                        }
                    }
                    else
                    {
                        FullMoneyInWords = "ZERO";
                    }
                }


            }
            return FullMoneyInWords;

        }

        public string NondecimalParttoWords(Int64 number, int currencymode)
        {

            if (number == 0) return "ZERO";
            if (number < 0) return "minus " + NondecimalParttoWords(Math.Abs(number), currencymode);
            string words = "";

            if (currencymode == 1)
            {
                if ((number / 10000000) > 0)
                {
                    words += NondecimalParttoWords(number / 10000000, currencymode) + " CRORE ";
                    number %= 10000000;
                }
                if ((number / 100000) > 0)
                {
                    words += NondecimalParttoWords(number / 100000, currencymode) + " LAKHS ";
                    number %= 100000;
                }
            }

            else if (currencymode == 2)
            {
                if ((number / 1000000000000) > 0)
                {
                    words += NondecimalParttoWords(number / 1000000000000, currencymode) + " TRILLION ";
                    number %= 1000000000000;
                }
                if ((number / 1000000000) > 0)
                {
                    words += NondecimalParttoWords(number / 1000000000, currencymode) + " BILLION ";
                    number %= 1000000000;
                }
                if ((number / 1000000) > 0)
                {
                    words += NondecimalParttoWords(number / 1000000, currencymode) + " MILLION ";
                    number %= 1000000;
                }
                if ((number / 100000) > 0)
                {
                    words += NondecimalParttoWords(number / 100000, currencymode) + " LAKHS ";
                    number %= 100000;
                }
            }


            else if (currencymode == 3)
            {
                if ((number / 1000000000000) > 0)
                {
                    words += NondecimalParttoWords(number / 1000000000000, currencymode) + " TRILLION ";
                    number %= 1000000000000;
                }

                if ((number / 1000000000) > 0)
                {
                    words += NondecimalParttoWords(number / 1000000000, currencymode) + " BILLION ";
                    number %= 1000000000;
                }
                if ((number / 1000000) > 0)
                {
                    words += NondecimalParttoWords(number / 1000000, currencymode) + " MILLION ";
                    number %= 1000000;
                }
                //if ((number / 100000) > 0)
                //{
                //    words += NondecimalParttoWords(number / 100000, currencymode) + " HUNDRED THOUSAND ";
                //    number %= 100000;
                //}
            }
            if ((number / 1000) > 0)
            {
                words += NondecimalParttoWords(number / 1000, currencymode) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += NondecimalParttoWords(number / 100, currencymode) + " HUNDRED ";
                number %= 100;
            }


            //if ((number / 10) > 0)  
            //{  
            // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
            // number %= 10;  
            //}  

            if (number > 0)
            {
                if (words != "") words += "AND ";
                var unitsMap = new[]   
        {  
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"  
        };
                var tensMap = new[]   
        {  
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"  
        };
                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }
        // convert the decimal part of the currency
        public string ConvertDecimalPart(Int64 DecimalPart)
        {
            string DecimalWords = "";

            if (DecimalPart == 0) return "";


            if ((DecimalPart / 1000) > 0)
            {
                DecimalWords += ConvertDecimalPart(DecimalPart / 1000) + " THOUSAND ";
                DecimalPart %= 1000;
            }
            if ((DecimalPart / 100) > 0)
            {
                DecimalWords += ConvertDecimalPart(DecimalPart / 100) + " HUNDRED ";
                DecimalPart %= 100;
            }
            if (DecimalPart > 0)
            {
                var unitsMap = new[]   
        {  
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"  
        };
                var tensMap = new[]   
        {  
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"  
        };
                if (DecimalPart < 20) DecimalWords += unitsMap[DecimalPart];
                else
                {
                    DecimalWords += tensMap[DecimalPart / 10];
                    if ((DecimalPart % 10) > 0) DecimalWords += " " + unitsMap[DecimalPart % 10];
                }
            }
            return DecimalWords;
        }


        // for fetching reference format
        public DataTable ReferenceFormat(clsEntityCommon objEntityCommon)
        {
            DataTable dtRefFormat = objDataLayer.ReadReferenceFormat(objEntityCommon);
            return dtRefFormat;
        }


        //fetch and send reference common format
        public string strRefFormat(clsEntityCommon objEntityCommon)
        {

            DataTable dtRefFormat = objDataLayer.ReadReferenceFormat(objEntityCommon);
            string refFormatByDiv = "";
            string strRealFormat = "";
            if (dtRefFormat.Rows.Count != 0)
            {
                refFormatByDiv = dtRefFormat.Rows[0]["CPRDIV_REF_FORMAT"].ToString();

                if (refFormatByDiv == "" || refFormatByDiv == null)
                {
                    strRealFormat = objEntityCommon.QtnId.ToString();
                }
                else
                {
                    strRealFormat = refFormatByDiv.ToString();
                    if (strRealFormat.Contains("#DIV#"))
                    {
                        strRealFormat = strRealFormat.Replace("#DIV#", objEntityCommon.CorpDivisionCode);
                    }

                    if (strRealFormat.Contains("#USR#"))
                    {
                        strRealFormat = strRealFormat.Replace("#USR#", objEntityCommon.UserCodeRef.ToString());
                    }

                    if (strRealFormat.Contains("#SLN#"))
                    {
                        strRealFormat = strRealFormat.Replace("#SLN#", objEntityCommon.QtnId.ToString());
                    }

                    if (strRealFormat.Contains("#YER#"))
                    {
                        strRealFormat = strRealFormat.Replace("#YER#", objEntityCommon.YearRef.ToString());
                    }

                    if (strRealFormat.Contains("#MON#"))
                    {
                        strRealFormat = strRealFormat.Replace("#MON#", objEntityCommon.MonthRef.ToString());

                    }

                    if (strRealFormat.Contains("#REV#"))
                    {
                        string[] arrSplit = strRealFormat.Split('%');
                        int intRowCount = arrSplit.Count();
                        for (int intCnt = 0; intCnt <= intRowCount - 1; intCnt++)
                        {
                            if (arrSplit[intCnt].Contains("#REV#"))
                            {
                                if (objEntityCommon.RvsnVrsnRef != "")
                                {
                                    strRealFormat = strRealFormat.Replace("#REV#", objEntityCommon.RvsnVrsnRef.ToString());
                                }

                                else
                                {
                                    //if (intCnt != 0)
                                    // {
                                    string strReplace = arrSplit[intCnt].ToString();
                                    strRealFormat = strRealFormat.Replace("%" + strReplace + "%", "");
                                    //if (strRealFormat[strRealFormat.Length - 1].ToString() == "/")
                                    //  {
                                    //    strRealFormat = strRealFormat.TrimEnd(strRealFormat[strRealFormat.Length - 1]);

                                    //}

                                    //}
                                    //else
                                    //{
                                    //    string strReplace = objEntityCommon.QtnId.ToString();
                                    //    strRealFormat = strRealFormat.Replace(strReplace, "");
                                    //  }
                                }
                            }
                        }
                    }

                    if (strRealFormat == "")
                    {
                        strRealFormat = objEntityCommon.QtnId.ToString();
                    }
                    strRealFormat = strRealFormat.Replace("#", "");
                    strRealFormat = strRealFormat.Replace("*", "");
                    strRealFormat = strRealFormat.Replace("%", "");
                    //if (strRealFormat[strRealFormat.Length - 1].ToString() == "/")
                    //{
                    //    strRealFormat = strRealFormat.TrimEnd(strRealFormat[strRealFormat.Length - 1]);
                    //}
                    //if (strRealFormat[0].ToString() == "/")
                    //{
                    //    strRealFormat = strRealFormat.Trim(strRealFormat[0]);
                    //}


                }


            }
            else
            {
                strRealFormat = objEntityCommon.QtnId.ToString();
            }
            return strRealFormat;
        }

        public string AddCommasForNumberSeperation(string strNumber, clsEntityCommon objEntityCommon)
        {
            DataTable dtCurrencyDetails = objDataLayer.ReadCurrencyDetailsById(objEntityCommon);
            int intCurrencyMode = 0;
            if (dtCurrencyDetails.Rows.Count > 0)
            {

                intCurrencyMode = Convert.ToInt32(dtCurrencyDetails.Rows[0]["CRNCYMD_ID"]);
            }
            string strNetAmountInNumber = strNumber.ToString();
            string[] SplitNumber = new string[2];
            SplitNumber = strNetAmountInNumber.ToString().Split('.');
            string strNondecimalPart = "";
            decimal intNonDecimalPart = 0;
            if (SplitNumber.Length > 0 && SplitNumber[0] != "")
            {
                intNonDecimalPart = Convert.ToDecimal(SplitNumber[0]);
                strNondecimalPart = SplitNumber[0].ToString();
            }

            string strDecimalPart = "";
            if (SplitNumber.Length > 1 && SplitNumber[1] != "")
            {
                strDecimalPart = SplitNumber[1];

            }

            if (intCurrencyMode == 1)
            {
                if (intNonDecimalPart >= 1000000000 || intNonDecimalPart <= -1000000000)
                {
                    strNondecimalPart = strNondecimalPart.Insert(strNondecimalPart.Length - 9, ",");
                }
                if (intNonDecimalPart >= 10000000 || intNonDecimalPart <= -10000000)
                {
                    strNondecimalPart = strNondecimalPart.Insert(strNondecimalPart.Length - 7, ",");
                }
            }
            if (intCurrencyMode == 2 || intCurrencyMode == 3)
            {
                if (intNonDecimalPart >= 1000000000000 || intNonDecimalPart <= -1000000000000)
                {
                    strNondecimalPart = strNondecimalPart.Insert(strNondecimalPart.Length - 12, ",");
                }
            }
            if (intCurrencyMode == 2 || intCurrencyMode == 3)
            {
                if (intNonDecimalPart >= 1000000000 || intNonDecimalPart <= -1000000000)
                {
                    strNondecimalPart = strNondecimalPart.Insert(strNondecimalPart.Length - 9, ",");
                }
            }
            if (intCurrencyMode == 3 || intCurrencyMode == 2)
            {
                if (intNonDecimalPart >= 1000000 || intNonDecimalPart <= -1000000)
                {
                    strNondecimalPart = strNondecimalPart.Insert(strNondecimalPart.Length - 6, ",");
                }
            }
            if (intCurrencyMode == 2 || intCurrencyMode == 1)
            {
                if (intNonDecimalPart >= 100000 || intNonDecimalPart <= -100000)
                {
                    strNondecimalPart = strNondecimalPart.Insert(strNondecimalPart.Length - 5, ",");
                }
            }


            if (intNonDecimalPart >= 1000 || intNonDecimalPart <= -1000)
            {
                strNondecimalPart = strNondecimalPart.Insert(strNondecimalPart.Length - 3, ",");
            }

            strNondecimalPart = strNondecimalPart + "." + strDecimalPart;
            return strNondecimalPart;

        }


        public DataTable ReadCurrencyDetails(clsEntityCommon objEntityCommon)
        {
            DataTable dtCurrencyDetails = objDataLayer.ReadCurrencyDetailsById(objEntityCommon);
            return dtCurrencyDetails;
        }

        //Fetch Designation App Role master table from datalayer according to the id and pass to the ui layer. 
        public DataTable ReadUserAppRoleByUserId(int intUserId)
        {
            DataTable dtReadUserAppMstrEdit = objDataLayer.ReadUserAppRoleByUserId(intUserId);
            return dtReadUserAppMstrEdit;
        }
        public DataTable LoadDsgnRoleDetail(int intDsgnId, int intUsrolMstrId)
        {
            DataTable dtChildRoleDefn = new DataTable();
            dtChildRoleDefn = objDataLayer.LoadDsgnRoleDetail(intDsgnId, intUsrolMstrId);
            return dtChildRoleDefn;
        }
        public DataTable ReadUserTypeMaster()
        {
            DataTable dtRcrd = new DataTable();
            dtRcrd = objDataLayer.ReadUserTypeMaster();
            return dtRcrd;
        }
        //fetch reference number generalization format corp divisions
        public DataTable ReadGeneralLabelName(clsEntityCommon objEntityCommon)
        {
            DataTable dtLabelNames = objDataLayer.ReadGeneralLabelName(objEntityCommon);
            return dtLabelNames;
        }


        public DateTime EnableVhclRnwlLink(clsEntityCommon objEntityCommon)
        {
            int intVhclRnwlAlrtMod = objEntityCommon.VhclRnwlAlrtMod;
            int intVhclRnwlAlrtVal = objEntityCommon.VhclRnwlAlrtVal;
            DateTime dateRnwlAlrt = new DateTime();
            if (intVhclRnwlAlrtMod == 1)
            {
                dateRnwlAlrt = DateTime.Now.AddDays(intVhclRnwlAlrtVal * 30);
            }
            if (intVhclRnwlAlrtMod == 2)
            {
                dateRnwlAlrt = DateTime.Now.AddDays(intVhclRnwlAlrtVal * 7);
            }
            if (intVhclRnwlAlrtMod == 3)
            {
                dateRnwlAlrt = DateTime.Now.AddDays(intVhclRnwlAlrtVal);
            }
            return dateRnwlAlrt;
        }
        public string RedirectToUpdateView(clsEntityCommon objEntityCommon, List<clsEntityQueryString> objEntityQueryStringList)
        {
            //RedirectUrl contains the URL and it can not be null
            string strUpdateUrl = objEntityCommon.RedirectUrl;
            //strQueryString  stores the query strings
            string strQueryString = "";
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            if (strUpdateUrl != "")
            {
                if (objEntityQueryStringList.Count > 0)
                {

                    foreach (clsEntityQueryString objEntityQueryString in objEntityQueryStringList)
                    {
                        //if Encrypt is 1 Encrypt the value
                        if (objEntityQueryString.Encrypt == 1)
                        {

                            string strId = objEntityQueryString.QueryStringValue;
                            int intIdLength = objEntityQueryString.QueryStringValue.Length;
                            string stridLength = intIdLength.ToString("00");
                            string Id = stridLength + strId + strRandom;
                            objEntityQueryString.QueryStringValue = Id;
                        }

                        if (strQueryString == "")
                        {
                            strQueryString += "?" + objEntityQueryString.QueryString + "=" + objEntityQueryString.QueryStringValue;
                        }
                        else
                        {
                            strQueryString += "&" + objEntityQueryString.QueryString + "=" + objEntityQueryString.QueryStringValue;
                        }

                    }

                }
                return strUpdateUrl + strQueryString;
            }
            else
            {
                //invalid url
                return "/Default.aspx"; 
            }


        }
        //fetch employee list for dropdownlist
        public DataTable ReadEmployeeDtl(clsEntityCommon objEntityCommon)
        {
            DataTable dtReadEmp = objDataLayer.ReadEmployeeDtl(objEntityCommon);
            return dtReadEmp;
        }
        public DataTable ReadLastAuditClose(clsEntityCommon objEntityCommon)
        {
            DataTable dtReadEmp = objDataLayer.ReadLastAuditClose(objEntityCommon);
            return dtReadEmp;
        }
        public string ReadNextNumberSequanceForUI(clsEntityCommon objEntCommon)
        {
            string strPKNxtNumbr = objDataLayer.ReadNextNumberSequanceForUI(objEntCommon);
            return strPKNxtNumbr;
        }


        public string ReadNextSequence(clsEntityCommon objEntCommon)
        {
            string strPKNxtNumbr = objDataLayer.ReadNextSequence(objEntCommon);
            return strPKNxtNumbr;
        }


        public DataTable ReadCodeFormate(clsEntityCommon objEntityCommon)
        {
            DataTable dtReadEmp = objDataLayer.ReadCodeFormate(objEntityCommon);
            return dtReadEmp;
        }
        public DataTable ReadPrintVersion(clsEntityCommon objEntityCommon)
        {
            DataTable dtReadEmp = objDataLayer.ReadPrintVersion(objEntityCommon);
            return dtReadEmp;
        }
        public DataTable ReadBankDetails(clsEntityCommon objEntityCommon)
        {
            DataTable dtReadEmp = objDataLayer.ReadBankDetails(objEntityCommon);
            return dtReadEmp;
        }

        public DataTable ReadAccountGrps(clsEntityCommon objEntityCommon)
        {
            DataTable dtReadEmp = objDataLayer.ReadAccountGrps(objEntityCommon);
            return dtReadEmp;
        }

        public DataTable ReadLedgers(clsEntityCommon objEntityCommon)
        {
            DataTable dtReadEmp = objDataLayer.ReadLedgers(objEntityCommon);
            return dtReadEmp;
        }


        public string ConvertDataTableToHTML_ListNew(DataTable dt, string strUrl)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            StringBuilder sb = new StringBuilder();
            string strHtml = "";
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                int intCorpOffcId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CORPRT_ID"].ToString());
                string strCorpName = dt.Rows[intRowBodyCount]["CORPRT_NAME"].ToString();

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                strHtml += "<a style=\"cursor: pointer;\"  onclick='return getdetails(this.href);' " +
                           " href=\"" + strUrl + "?CId=" + Id + "\">";
                strHtml += "<button  class=\"btn bu_btn\"><i class=\"fa fa-building\"></i>" + strCorpName + "</button></a>";

            }
            sb.Append(strHtml);
            return sb.ToString();
        }

        public DataTable ReadCorpDetails(clsEntityCommon objEntityCommon)
        {
            DataTable dtReadEmp = objDataLayer.ReadCorpDetails(objEntityCommon);
            return dtReadEmp;
        }
        public DataTable ReadAppDetails(clsEntityCommon objEntityCommon)
        {
            DataTable dtReadEmp = objDataLayer.ReadAppDetails(objEntityCommon);
            return dtReadEmp;
        }

        public string GenereatePagination(int intTotalItems, int intPageIndex, int intPageSize, int intCurrentRowCount)
        {
            StringBuilder strHTML = new StringBuilder();

            //options
            //‹
            int intPageNumberRange = 2;
            int intTotalPages = 0;
            intTotalPages = intTotalItems / intPageSize;
            if (intTotalItems % intPageSize != 0)
            {
                intTotalPages++;
            }
            int intStart = 0;
            int intEnd = 0;
            intStart = intPageIndex - intPageNumberRange;
            if (intStart <= 0)
            {
                intStart = 1;
            }
            intEnd = intPageIndex + intPageNumberRange;
            if (intEnd >= intTotalPages)
            {
                intEnd = intTotalPages;
            }


            strHTML.Append("<div class=\"dataTables_info\" >Showing " + intCurrentRowCount + " of " + intTotalItems + " entries</div>");
            strHTML.Append("<nav aria-label=\"Page navigation example\" class=\"pull-right\">");
            strHTML.Append("<ul class=\"pagination\">");
            if (intStart != 1)
            {
                strHTML.Append(" <li class=\"page-item\"><a class=\"page-link\" onclick=\"getdata(1);\" href=\"javascript:void(0);\">First</a></li>");
            }
            if (intPageIndex != intStart)
            {
                strHTML.Append(" <li class=\"page-item\"><a class=\"page-link\" onclick=\"getdata(" + (intPageIndex - 1) + ");\" href=\"javascript:void(0);\">Previous</a></li>");
            }
            else
            {
                strHTML.Append(" <li class=\"page-item disabled\"><a class=\"page-link\" href=\"javascript:void(0);\">Previous</a></li>");
            }
            if (intStart != 1)
            {
                strHTML.Append(" <li class=\"page-item disabled\"><a class=\"page-link\" href=\"javascript:void(0);\">...</a></li>");
            }
            for (int intPageCount = intStart; intPageCount <= intEnd; intPageCount++)
            {
                if (intPageIndex != intPageCount)
                {
                    strHTML.Append(" <li class=\"page-item\"><a class=\"page-link\" onclick=\"getdata(" + intPageCount + ");\" href=\"javascript:void(0);\">" + intPageCount + "</a></li>");
                }
                else
                {
                    strHTML.Append(" <li class=\"page-item active\"><a class=\"page-link\" onclick=\"getdata(" + intPageCount + ");\" href=\"javascript:void(0);\">" + intPageCount + "</a></li>");
                }
            }

            if (intEnd < intTotalPages)
            {
                strHTML.Append(" <li class=\"page-item disabled\"><a class=\"page-link\" href=\"javascript:void(0);\">...</a></li>");
            }
            if (intEnd != intPageIndex)
            {
                strHTML.Append(" <li class=\"page-item\"><a class=\"page-link\" onclick=\"getdata(" + (intPageIndex + 1) + ");\" href=\"javascript:void(0);\">Next</a></li>");
            }
            else
            {
                strHTML.Append(" <li class=\"page-item disabled\" ><a class=\"page-link\" href=\"javascript:void(0);\">Next</a></li>");
            }
            if (intEnd != intPageIndex)
            {
                strHTML.Append(" <li class=\"page-item\"><a class=\"page-link\" onclick=\"getdata(" + intTotalPages + ");\" href=\"javascript:void(0);\">Last</a></li>");
            }
            strHTML.Append("</ul> </div>");
            return strHTML.ToString();
        }


        public DataTable CheckLastSalProcess(clsEntityCommon objEntityCommon)
        {
            DataTable dtReadEmp = objDataLayer.CheckLastSalProcess(objEntityCommon);
            return dtReadEmp;
        }

        public DataTable ReadEmployees(clsEntityCommon objEntityCommon)
        {
            DataTable dtReadEmp = objDataLayer.ReadEmployees(objEntityCommon);
            return dtReadEmp;
        }

        public DataTable ReadYearEndCloseDate(clsEntityCommon objEntityCommon)
        {
            DataTable dtReadEmp = objDataLayer.ReadYearEndCloseDate(objEntityCommon);
            return dtReadEmp;
        }

        //evm 0044
        //method to load Detail from FMS_CODE_Defalt_MOD__Setting Table
        public DataTable ReadDefaultModValues(clsEntityCommon objEntityCommon)
        {
            DataTable dtdfltmoddata = objDataLayer.ReadDefaultModValues(objEntityCommon);
            return dtdfltmoddata;
        }
        //Method to read next number without updating
        public string ReadNextNumberOnly(clsEntityCommon objEntCommon)
        {
            string strPKNxtNumbr = objDataLayer.ReadNextNumberOnly(objEntCommon);
            return strPKNxtNumbr;
        }
        //--------------------
        public DataTable ReadCurrency(clsEntityCommon objEntCommon)
        {
            DataTable dtRead = objDataLayer.ReadCurrency(objEntCommon);
            return dtRead;
        }

        //end
        public DataTable ReadRefFormat(clsEntityCommon objEntCommon)
        {
            DataTable dtRead = objDataLayer.ReadRefFormat(objEntCommon);
            return dtRead;
        }

    }
}
