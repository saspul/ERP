<%@ WebHandler Language="C#" Class="SalaryProcess" %>

using System;
using System.Web;
using System.Linq;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using iTextSharp.text;
using System.Collections.Generic;

using System.Web.Services;
public class SalaryProcess : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        //PARAMETERS MANUALLY ADDED
        var Org_Id = context.Request["orgID"];
        var Corpt_Id = context.Request["corptID"];
        var SaveOrConf = context.Request["SaveOrConf"];
        var CorpdepId = context.Request["CorpdepId"];
        var staffWrk = context.Request["staffWrk"];
        var ddate = context.Request["ddate"];
        var month = context.Request["month"];
        var Year = context.Request["Year"];

        var cbxAllowance = context.Request["cbxAllowance"];
        var cbxDeduction = context.Request["cbxDeduction"];


        string strDecimalCount = "2", strIndividualRnd = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                            clsCommonLibrary.CORP_GLOBAL.PAYROLL_INDIVIDUAL_ROUND 
                                                         
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, Convert.ToInt32(Corpt_Id));
        if (dtCorpDetail.Rows.Count > 0)
        {
            strDecimalCount = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
            strIndividualRnd = dtCorpDetail.Rows[0]["PAYROLL_INDIVIDUAL_ROUND"].ToString();
            //hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        }


        var result = getData(Org_Id, Corpt_Id, SaveOrConf, CorpdepId, staffWrk, ddate, month, Year, cbxAllowance, cbxDeduction, strDecimalCount, strIndividualRnd);

        JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
        string strR = javaScriptSerializer.Serialize(result);
        context.Response.ContentType = "application/json";
        context.Response.Write(strR);
    }

    public string getData(string Org_Id, string Corpt_Id, string SaveOrConf, string CorpdepId, string staffWrk, string ddate, string month, string Year, string cbxAllowance, string cbxDeduction, string strDecimalCount, string strIndividualRnd)
    {
        clsBusinessLayerSalaryStatement objSalarySatement = new clsBusinessLayerSalaryStatement();
        clsEntityLayerSalaryStatement objEntitySalry = new clsEntityLayerSalaryStatement();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        objEntitySalry.CorpID = Convert.ToInt32(Corpt_Id);
        objEntitySalry.Orgid = Convert.ToInt32(Org_Id);
        objEntitySalry.SavConf = Convert.ToInt32(SaveOrConf);
        objEntitySalry.CorpOffice = Convert.ToInt32(CorpdepId);
        objEntitySalry.StffWrkr = Convert.ToInt32(staffWrk);
        if (ddate != "0")
        {
            objEntitySalry.date = objCommon.textToDateTime(ddate);
        }
        objEntitySalry.Month = Convert.ToInt32(month);
        objEntitySalry.Year = Convert.ToInt32(Year);
        objEntitySalry.Orgid = Convert.ToInt32(Org_Id);
        DataTable dtorglist = objSalarySatement.LoadSalaryPrssListPrssTable(objEntitySalry);


        string strMonthYear = dtorglist.Rows[0]["month"].ToString().ToUpper() +" " + dtorglist.Rows[0]["SLPRCDMNTH_YEAR"].ToString();

        decimal value = 0;
        int precision = Convert.ToInt32(strDecimalCount); 
        string format = String.Format("{{0:N{0}}}", precision);
        string strZeroAmount = String.Format(format, value);
        
      
        objEntitySalry.CorpOffice = Convert.ToInt32(Corpt_Id);
        decimal decNetSalary = 0;
        string CurrencyId = "";
        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        DataTable dtAllwncPrimary = new DataTable(); 
        DataTable dtdeductnPrimary = new DataTable(); 
        DataTable dtDetail = new DataTable();
        if (cbxAllowance == "1")
        {
            dtAllwncPrimary = objSalarySatement.ReadAllwnc(objEntitySalry);
        }
        if (cbxDeduction == "1")
        {
            dtdeductnPrimary = objSalarySatement.ReadDedctn(objEntitySalry);
        }
        dtDetail.Columns.Add("EMPLOYEE ID", typeof(string));
        dtDetail.Columns.Add("EMPLOYEE NAME", typeof(string));
        dtDetail.Columns.Add("BASIC PAY", typeof(string));
        dtDetail.Columns.Add("OVERTIME", typeof(string));
        int n = dtorglist.Rows.Count + dtAllwncPrimary.Rows.Count + dtdeductnPrimary.Rows.Count;
        string[] strAllignment = new string[11 + dtAllwncPrimary.Rows.Count + dtdeductnPrimary.Rows.Count];
         strAllignment[0] = "L";
         strAllignment[1] = "L";
         strAllignment[2] = "R";
         strAllignment[3] = "R";

         int intColCount = 0;
         if (dtAllwncPrimary.Rows.Count > 0)
         {
             intColCount = intColCount + 4;
             for (int intRowCount = 0; intRowCount < dtAllwncPrimary.Rows.Count; intRowCount++, intColCount++)
             {

                 strAllignment[intColCount] = "R";
                 dtDetail.Columns.Add("" + dtAllwncPrimary.Rows[intRowCount]["PAYRL_NAME"], typeof(string));

             }
         }
         else
         {
             intColCount = 4;
         }


         dtDetail.Columns.Add("ALLOWANCE", typeof(string));
        strAllignment[intColCount] = "R";

        dtDetail.Columns.Add("OTHER ADDITION", typeof(string));
        strAllignment[intColCount + 1] = "R";
        
        dtDetail.Columns.Add("TOTAL SALARY", typeof(string));
        strAllignment[intColCount + 2] = "R";


        
        //intColCount=intColCount+1;
        if (dtdeductnPrimary.Rows.Count > 0)
        {
            intColCount = intColCount + 2;
            for (int intRowCount = 0; intRowCount < dtdeductnPrimary.Rows.Count; intRowCount++, intColCount++)
            {
                strAllignment[intColCount] = "R";
                dtDetail.Columns.Add("" + dtdeductnPrimary.Rows[intRowCount]["PAYRL_NAME"], typeof(string));
                //intColCount++;
            }
        }
        else
        {
            intColCount = intColCount + 2;
        }
        

        dtDetail.Columns.Add("DEDUCTION", typeof(string));
        strAllignment[intColCount] = "R";

        dtDetail.Columns.Add("OTHER DEDUCTION", typeof(string));
        strAllignment[intColCount + 1] = "R";
        
        dtDetail.Columns.Add("PAID", typeof(string));
        strAllignment[intColCount+2] = "C";

        dtDetail.Columns.Add("NET SALARY", typeof(string));
        strAllignment[intColCount+3] = "R";


        
        string strCurrency = "";
        foreach (DataRow dtRowsIn in dtorglist.Rows)
        {
           
            decimal decAllowance = 0;
            decimal decOtherAllwnc = 0;
            decimal decDeduction = 0;
            decimal decOtherDeduction = 0;

            decimal decAllowanceManual = 0;
            decimal decOtherAllwncManual = 0;
            decimal decDeductionManual = 0;
            decimal decOtherDeductionManual = 0;
            
            
            decimal decTotalAllowance = 0;
            decimal decTotal = 0;
            DataRow drDtl = dtDetail.NewRow();
            int[] arrayAllwncPrimary = new int[dtAllwncPrimary.Rows.Count];

            
            objEntitySalry.SalaryPrssId = Convert.ToInt32(dtRowsIn["SLPRCDMNTH_ID"]);


            decimal decPrevArrAmnt = Convert.ToDecimal(dtRowsIn["SLPRCDMNTH_PREV_MNTH_ARRE_AMNT"]);
            if (decPrevArrAmnt >= 0)
            {
                decOtherAllwnc = decOtherAllwnc + decPrevArrAmnt;
            }

          
            
            
            
            
            if (dtRowsIn["CRNCMST_ABBRV"].ToString() != "")
            {
                strCurrency = dtRowsIn["CRNCMST_ABBRV"].ToString();

            }
            DataTable dtAllownce = objSalarySatement.ReadAllowanceDetails(objEntitySalry);
            int[] ArrayAllwanc = new int[dtAllownce.Rows.Count];

            for (int intRowCount = 0; intRowCount < dtAllownce.Rows.Count; intRowCount++)
            {
                ArrayAllwanc[intRowCount] = Convert.ToInt32(dtAllownce.Rows[intRowCount]["PAYRL_ID"]);
            }
            for (int intRowCount = 0; intRowCount < dtAllwncPrimary.Rows.Count; intRowCount++)
            {
                arrayAllwncPrimary[intRowCount] = Convert.ToInt32(dtAllwncPrimary.Rows[intRowCount]["PAYRL_ID"]);
            }
           
           
            if (dtRowsIn["CRNCMST_ID"].ToString() != "")
            {
                CurrencyId = dtRowsIn["CRNCMST_ID"].ToString();
                
            }
            
            
            if (dtAllwncPrimary.Rows.Count > 0)
            {
                for (int intRowCount = 0; intRowCount < dtAllwncPrimary.Rows.Count; intRowCount++)
                {
                   // dtDetail.Columns.Add("" + dtAllwncPrimary.Rows[intRowCount]["PAYRL_NAME"], typeof(string));
                    drDtl["" + dtAllwncPrimary.Rows[intRowCount]["PAYRL_NAME"]] = strZeroAmount;
                }
            }
 
            if (dtAllownce.Rows.Count > 0)
            {
                for (int intRowCount = 0; intRowCount < dtAllownce.Rows.Count; intRowCount++)
                {
                    int intPrimaryAllwnc = 0;

                    intPrimaryAllwnc = ArrayAllwanc[intRowCount];

                    if (arrayAllwncPrimary.Contains(intPrimaryAllwnc))
                    {
                        if (dtAllownce.Rows[intRowCount]["SLRYPROSALLCE_AMOUNT_FINAL"].ToString() != "")
                        {
                            decAllowance = decAllowance + Convert.ToDecimal(dtAllownce.Rows[intRowCount]["SLRYPROSALLCE_AMOUNT_FINAL"]);
                            drDtl["" + dtAllownce.Rows[intRowCount]["PAYRL_NAME"]] = dtAllownce.Rows[intRowCount]["SLRYPROSALLCE_AMOUNT_FINAL"] ;
                        }
                     
                    }
                    else
                    {
                        
                        if (dtAllownce.Rows[intRowCount]["SLRYPROSALLCE_AMOUNT_FINAL"].ToString() != "")
                        {
                            decOtherAllwnc = decOtherAllwnc + Convert.ToDecimal(dtAllownce.Rows[intRowCount]["SLRYPROSALLCE_AMOUNT_FINAL"]);
                            drDtl["ALLOWANCE"] = dtAllownce.Rows[intRowCount]["SLRYPROSALLCE_AMOUNT_FINAL"]; 

                        }
                    }
                }
            }
            
            
            ///////////other add


            objEntitySalry.Employee = Convert.ToInt32(dtRowsIn["USR_ID"]);
            DataTable dtOtherAddDedDetls = objSalarySatement.ReadEmpManualy_Add_Dedn_Dtls(objEntitySalry);
            //int RowCountAddDedd = 0;
            int ArrayOtherAddCount =0;
            int ArrayOtherDedCount =0;


            if (dtOtherAddDedDetls.Rows.Count > 0)
            {
                DataRow[] resultAdd = dtOtherAddDedDetls.Select("PAYRL_MODE =1");
                DataRow[] resultDed = dtOtherAddDedDetls.Select("PAYRL_MODE =2");

                ArrayOtherAddCount =resultAdd.Length;
                ArrayOtherDedCount = resultDed.Length;
            }
            
            //var result = dtOtherAddDedDetls.AsEnumerable()
            //    .GroupBy(r => r.Field<Int16>("PAYRL_MODE"))
            //    .Select(r => new
            //    {
            //        Str = r.Key,
            //        Count = r.Count()
            //    });
            //foreach (var item in result)
            //{
            //    if (RowCountAddDedd == 0)
            //    {
            //        ArrayOtherAddCount = item.Count;
            //    }
            //    if (RowCountAddDedd == 1)
            //    {
            //        ArrayOtherDedCount = item.Count;
            //    }
            //    RowCountAddDedd++;
            //}

            int[] ArrayOtherAdd = new int[ArrayOtherAddCount];
            int rowcountAdd = 0;
            for (int intRowCount = 0; intRowCount < dtOtherAddDedDetls.Rows.Count; intRowCount++)
            {
                if (dtOtherAddDedDetls.Rows[intRowCount]["PAYRL_MODE"].ToString() == "1")
                {
                    ArrayOtherAdd[rowcountAdd] = Convert.ToInt32(dtOtherAddDedDetls.Rows[intRowCount]["PAYRL_ID"]);
                    rowcountAdd++;
                }
            }

            int rowcnt1 = 0;
            if (dtOtherAddDedDetls.Rows.Count > 0)
            {
                for (int intRowCount = 0; intRowCount < dtOtherAddDedDetls.Rows.Count; intRowCount++)
                {
                    if (dtOtherAddDedDetls.Rows[intRowCount]["PAYRL_MODE"].ToString() == "1")
                    {
                        int intPrimaryAllwnc = 0;

                        intPrimaryAllwnc = ArrayOtherAdd[rowcnt1];

                        if (arrayAllwncPrimary.Contains(intPrimaryAllwnc))
                        {
                            if (dtOtherAddDedDetls.Rows[intRowCount]["PAYINFDT_AMOUNT"].ToString() != "")
                            {
                                decAllowanceManual = decAllowanceManual + Convert.ToDecimal(dtOtherAddDedDetls.Rows[intRowCount]["PAYINFDT_AMOUNT"]);
                                drDtl["" + dtOtherAddDedDetls.Rows[intRowCount]["PAYRL_NAME"]] = dtOtherAddDedDetls.Rows[intRowCount]["PAYINFDT_AMOUNT"];
                            }
                        }
                        else
                        {
                            if (dtOtherAddDedDetls.Rows[intRowCount]["PAYINFDT_AMOUNT"].ToString() != "")
                            {
                                decOtherAllwncManual = decOtherAllwncManual + Convert.ToDecimal(dtOtherAddDedDetls.Rows[intRowCount]["PAYINFDT_AMOUNT"]);
                                drDtl["OTHER ADDITION"] = dtOtherAddDedDetls.Rows[intRowCount]["PAYINFDT_AMOUNT"];

                            }
                        }
                        rowcnt1++;
                    }
                }
            }



            /////////////// other add
            

            DataTable dtDeduction = objSalarySatement.ReadDeductionDetails(objEntitySalry);
            int[] intDedArray = new int[dtdeductnPrimary.Rows.Count];
            int[] intDedByEmpArry = new int[dtDeduction.Rows.Count];

            if (dtdeductnPrimary.Rows.Count > 0)
            {
                for (int intRowCount = 0; intRowCount < dtdeductnPrimary.Rows.Count; intRowCount++)
                {

                    drDtl["" + dtdeductnPrimary.Rows[intRowCount]["PAYRL_NAME"]] = strZeroAmount;
                }
            }
            
            for (int intRowCount = 0; intRowCount < dtDeduction.Rows.Count; intRowCount++)
            {
                intDedByEmpArry[intRowCount] = Convert.ToInt32(dtDeduction.Rows[intRowCount]["PAYRL_ID"]);
            }
            for (int intRowCount = 0; intRowCount < dtdeductnPrimary.Rows.Count; intRowCount++)
            {
                //display
                intDedArray[intRowCount] = Convert.ToInt32(dtdeductnPrimary.Rows[intRowCount]["PAYRL_ID"]);
            }

            if (dtDeduction.Rows.Count > 0)
            {
                for (int intRowCount = 0; intRowCount < dtDeduction.Rows.Count; intRowCount++)
                {
                    int intDedid = 0;
                    intDedid = intDedByEmpArry[intRowCount];

                    if (intDedArray.Contains(intDedid))
                    {
                        if (dtDeduction.Rows[intRowCount]["SLRYPROCESD_AMT_FINAL"].ToString() != "")
                        {
                            decDeduction = decDeduction + Convert.ToDecimal(dtDeduction.Rows[intRowCount]["SLRYPROCESD_AMT_FINAL"]);
                            drDtl["" + dtDeduction.Rows[intRowCount]["PAYRL_NAME"]] = dtDeduction.Rows[intRowCount]["SLRYPROCESD_AMT_FINAL"];
                        }
                      
                    }
                    else
                    {
                        if (dtDeduction.Rows[intRowCount]["SLRYPROCESD_AMT_FINAL"].ToString() != "")
                        {
                            decOtherDeduction = decOtherDeduction + Convert.ToDecimal(dtDeduction.Rows[intRowCount]["SLRYPROCESD_AMT_FINAL"]);
                            drDtl["DEDUCTION"] = dtDeduction.Rows[intRowCount]["SLRYPROCESD_AMT_FINAL"]; 
                        }
                       
                    }
                }
            }
            
            
            //// other ded


            int[] ArrayOtherDed = new int[ArrayOtherDedCount];
            int rowcountDed = 0;
            for (int intRowCount = 0; intRowCount < dtOtherAddDedDetls.Rows.Count; intRowCount++)
            {
                if (dtOtherAddDedDetls.Rows[intRowCount]["PAYRL_MODE"].ToString() == "2")
                {
                    ArrayOtherDed[rowcountDed] = Convert.ToInt32(dtOtherAddDedDetls.Rows[intRowCount]["PAYRL_ID"]);
                    rowcountDed++;
                }
            }

            int rowcnt2 = 0;
            if (dtOtherAddDedDetls.Rows.Count > 0)
            {
                for (int intRowCount = 0; intRowCount < dtOtherAddDedDetls.Rows.Count; intRowCount++)
                {
                    if (dtOtherAddDedDetls.Rows[intRowCount]["PAYRL_MODE"].ToString() == "2")
                    {
                        int intDedid = 0;
                        intDedid = ArrayOtherDed[rowcnt2];

                        if (intDedArray.Contains(intDedid))
                        {
                            if (dtOtherAddDedDetls.Rows[intRowCount]["PAYINFDT_AMOUNT"].ToString() != "")
                            {
                                decDeductionManual = decDeductionManual + Convert.ToDecimal(dtOtherAddDedDetls.Rows[intRowCount]["PAYINFDT_AMOUNT"]);
                                drDtl["" + dtOtherAddDedDetls.Rows[intRowCount]["PAYRL_NAME"]] = dtOtherAddDedDetls.Rows[intRowCount]["PAYINFDT_AMOUNT"];
                            }
                        }
                        else
                        {
                            if (dtOtherAddDedDetls.Rows[intRowCount]["PAYINFDT_AMOUNT"].ToString() != "")
                            {
                                decOtherDeductionManual = decOtherDeductionManual + Convert.ToDecimal(dtOtherAddDedDetls.Rows[intRowCount]["PAYINFDT_AMOUNT"]);
                                drDtl["OTHER DEDUCTION"] = dtOtherAddDedDetls.Rows[intRowCount]["PAYINFDT_AMOUNT"];
                            }
                        }
                        rowcnt2++;
                    }
                }
            }

            
            
            //// other ded

            drDtl["OTHER ADDITION"] = dtRowsIn["SLPRCDMNTH_OTHR_ADTION_AMT"].ToString();
            drDtl["OTHER DEDUCTION"] = dtRowsIn["SLPRCDMNTH_OTHR_DEDCTN_AMT"].ToString();

            decimal decManualOtherAllwnc = Convert.ToDecimal(dtRowsIn["SLPRCDMNTH_OTHR_ADTION_AMT"]);
            decimal decManualOtherDeduction = Convert.ToDecimal(dtRowsIn["SLPRCDMNTH_OTHR_DEDCTN_AMT"]);
            
            string StrTableID = dtRowsIn[0].ToString();
            string strUsername = dtRowsIn["EMPLOYEE"].ToString();
            if (dtRowsIn["SLPRCDMNTH_PRSD_BASICPAY"].ToString() != "")
            {
                //decTotalAllowance = Convert.ToDecimal(dtRowsIn["SLPRCDMNTH_PRSD_BASICPAY"].ToString()) + decAllowance + decOtherAllwnc;
                decTotalAllowance = Convert.ToDecimal(dtRowsIn["SLPRCDMNTH_PRSD_BASICPAY"].ToString()) + decAllowance + decOtherAllwnc + decManualOtherAllwnc ;
            }
        //    if(dtRowsIn["SLPRCDMNTH_SPECIAL_ALLOW_AMT"].ToString()!="")
                
            if (dtRowsIn["SLPRCDMNTH_INSTLMNT_DEDCN_AMT"].ToString() != "")
           
                decOtherDeduction = decOtherDeduction + Convert.ToDecimal(dtRowsIn["SLPRCDMNTH_INSTLMNT_DEDCN_AMT"]) + Convert.ToDecimal(dtRowsIn["SLPRCDMNTH_MESS_DEDCTN_AMT"]);

            if (decPrevArrAmnt < 0)
            {
                decOtherDeduction = decOtherDeduction + (decPrevArrAmnt*-1);
            }

            decimal decLeaveArrAmnt = Convert.ToDecimal(dtRowsIn["SLPRCDMNTH_LEV_ARREAR_AMT"]);
            if (decLeaveArrAmnt > 0)
            {
                decOtherDeduction = decOtherDeduction + decLeaveArrAmnt;
            }
            
            
        //   decTotal = decTotalAllowance - decDeduction - decOtherDeduction;
            decTotal = decTotalAllowance - decDeduction - decOtherDeduction - decManualOtherDeduction;
            drDtl["EMPLOYEE NAME"] = strUsername;
            drDtl["EMPLOYEE ID"] = dtRowsIn["EID"];
            if (dtRowsIn["SLPRCDMNTH_PRSD_BASICPAY"].ToString() != "")
            {
                drDtl["BASIC PAY"] = dtRowsIn["SLPRCDMNTH_PRSD_BASICPAY"].ToString() ;
               
                string ss = dtRowsIn["SLPRCDMNTH_PRSD_BASICPAY"].ToString();
            }
         
            drDtl["TOTAL SALARY"] = decTotalAllowance.ToString() ;
            drDtl["PAID"] = dtRowsIn["SLPRCDMNTH_PAID_AMT"].ToString() ;
            if (dtRowsIn["SLPRCDMNTH_OVERTIME_ALLOW_AMT"].ToString() != "")
            {
                drDtl["OVERTIME"] = dtRowsIn["SLPRCDMNTH_OVERTIME_ALLOW_AMT"].ToString() ;
                decTotalAllowance += Convert.ToDecimal(dtRowsIn["SLPRCDMNTH_OVERTIME_ALLOW_AMT"]);
            }
            else
            {
                drDtl["OVERTIME"] = strZeroAmount;
            }

            drDtl["TOTAL SALARY"] = decTotalAllowance.ToString();
            
            
            if (dtRowsIn["SLPRCDMNTH_TOTAL_AMT"].ToString() != "")
            {
                decimal decNetAmt = Convert.ToDecimal(dtRowsIn["SLPRCDMNTH_TOTAL_AMT"].ToString());
                drDtl["NET SALARY"] = Math.Round(decNetAmt, 0).ToString("0.00");
                
                //drDtl["NET SALARY"] = dtRowsIn["SLPRCDMNTH_TOTAL_AMT"].ToString() ;
            }
            else
            {
                drDtl["NET SALARY"] = strZeroAmount ;
            }
            
            if (decOtherAllwnc == 0)
            {
                drDtl["ALLOWANCE"] = strZeroAmount;
            }
            else
            {
                drDtl["ALLOWANCE"] = decOtherAllwnc.ToString();
            }
            drDtl["DEDUCTION"] = decOtherDeduction.ToString() ;

            if (decOtherAllwncManual == 0)
            {
                drDtl["OTHER ADDITION"] = strZeroAmount;
            }
            else 
            {
                drDtl["OTHER ADDITION"] = decOtherAllwncManual.ToString();
            }

            if (decOtherDeductionManual == 0)
            {
                drDtl["OTHER DEDUCTION"] = strZeroAmount;
            }
            else
            {
                drDtl["OTHER DEDUCTION"] = decOtherDeductionManual.ToString();
            }
            

            if ((dtRowsIn["SLPRCDMNTH_TOTAL_AMT"]).ToString() != "")
            {
                decNetSalary = decNetSalary + Math.Round(Convert.ToDecimal(dtRowsIn["SLPRCDMNTH_TOTAL_AMT"]), 0);
            }
            else
            {
                decNetSalary = decNetSalary + 0;
            }
            dtDetail.Rows.Add(drDtl);
        }
        clsBusinessLayer ObjBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);
        string strcurrenWord = strCurrency +" - "+ ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decNetSalary));




   

      
        
        DataRow drTotal = dtDetail.NewRow();

        for (int intColCount2 = 0; intColCount2 < dtDetail.Columns.Count; intColCount2++)
        {
            if (intColCount2 == 1)
            {
                drTotal[dtDetail.Columns[intColCount2].ColumnName.ToString()] = "Total";
            }
            else
            {
               
                    drTotal[dtDetail.Columns[intColCount2].ColumnName.ToString()] = "";
                
            }
           
        }



        for (int IntTotalRowCount = 0; IntTotalRowCount < dtDetail.Rows.Count; IntTotalRowCount++)
        {

            for (int intColCount2 = 0; intColCount2 < dtDetail.Columns.Count; intColCount2++)
            {
                if (intColCount2 != 0 && intColCount2 != 1 && dtDetail.Columns[intColCount2].ColumnName.ToString() != "PAID")
                {
                    if (drTotal[intColCount2]=="")
                    {
                        drTotal[intColCount2] = "0";
                    }
                    if (dtDetail.Rows[IntTotalRowCount][intColCount2].ToString()!="" )
                    {
                        drTotal[intColCount2] = Convert.ToDecimal(drTotal[intColCount2]) + Convert.ToDecimal(dtDetail.Rows[IntTotalRowCount][intColCount2]);
                    }
                   
                }
              
            }
        }



        dtDetail.Rows.Add(drTotal);

        string strJson = ConvertDataTableToHTML(dtDetail, dtAllwncPrimary, dtdeductnPrimary, strAllignment, strcurrenWord, objEntityCommon.CurrencyId, strMonthYear, strIndividualRnd);
        return strJson.ToString();      
    }



    public static string ConvertDataTableToHTML(DataTable dt, DataTable dtAllowance, DataTable dtDeduction, string[] strAllignment, string strcurrenWord, int intCurrencyId, string strMonthYear, string strIndividualRnd)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer=new clsBusinessLayer();
        clsEntityCommon objEntityCommon=new clsEntityCommon();
        objEntityCommon.CurrencyId = intCurrencyId;
        
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        int n = dt.Rows.Count + dtAllowance.Rows.Count + dtDeduction.Rows.Count;
        StringBuilder sb1 = new StringBuilder();

        string html = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" cellspacing=\"0\" cellpadding=\"2px\" >";                
        html += "<thead>";

        html += "<tr>";
        html += "<td class=\"expand\" style=\"  word-wrap:break-word;text-align: left;background: white;color: #7F8672;font-size: 16px;\"><strong> " + strMonthYear + "</strong> </td>";
        html += "</tr>";     
        
        html += "<tr class=\"main_table_head\">";       
        for (int intRowCount = 0; intRowCount < dt.Columns.Count; intRowCount++)
            if (strAllignment[intRowCount] == "L")
            {
                html += "<th class=\"expand\" style=\"background-color: rgb(131, 144, 87);text-align: left;\">" + dt.Columns[intRowCount].ColumnName + "</th>";
            }
            else if (strAllignment[intRowCount] == "R")
            {
                html += "<th class=\"expand\" style=\"background-color: rgb(131, 144, 87);text-align: right;\">" + dt.Columns[intRowCount].ColumnName + "</th>";
            }
            else if (strAllignment[intRowCount] == "c")
            {
                html += "<th class=\"expand\" style=\"background-color: rgb(131, 144, 87);text-align: center;\">" + dt.Columns[intRowCount].ColumnName + "</th>";
            }
            else
            {
                html += "<th class=\"expand\" style=\"background-color: rgb(131, 144, 87);text-align: center;\">" + dt.Columns[intRowCount].ColumnName + "</th>";
            }
        html += "</tr>";
        html += "</thead>";
        html += "<tbody>";
        //add rows
        for (int intRowCount = 0; intRowCount < dt.Rows.Count; intRowCount++)
        {
            string strClass="tdT";
            if (intRowCount==(dt.Rows.Count-1))
            {
                strClass += " bold_th";
            }
            html += "<tr>";
            for (int intColCount = 0; intColCount < dt.Columns.Count; intColCount++)
            {

                string strValue = dt.Rows[intRowCount][intColCount].ToString();

                if (intColCount != 0 && intColCount != 1 && dt.Columns[intColCount].ColumnName.ToString() != "PAID")
                {
                    if (strIndividualRnd == "0")
                    {
                        strValue = objBusinessLayer.AddCommasForNumberSeperation(strValue, objEntityCommon);
                    }
                    else
                    {
                        strValue = objBusinessLayer.AddCommasForNumberSeperation(Math.Round(Convert.ToDecimal(strValue), 0).ToString("0.00"), objEntityCommon);
                    }
                }
                
                if (intRowCount == (dt.Rows.Count - 1))
                {
                    if (intColCount == 0)
                    {
                        html += "<td  class=\"" + strClass + " \" style=\"border-right: 0px;  word-wrap:break-word;text-align: right;\">" + strValue + "</td>";
                        continue;
                    }
                    else if (intColCount == 1)
                        {
                            html += "<td  class=\"" + strClass + " \" style=\"  word-wrap:break-word;text-align: right;\">" + strValue + "</td>";
                            continue;
                        }
                    
                  

                }
                
                if (strAllignment[intColCount] == "L")
                {
                    html += "<td class=\""+strClass+" \" style=\"  word-wrap:break-word;text-align: left;\">" + strValue + "</td>";
                }
                else if (strAllignment[intColCount] == "R")
                {
                    html += "<td class=\""+strClass+"\" style=\" width:80px; word-wrap:break-word;text-align: right;\">" + strValue + "</td>";
                }
                else  
                {
                    html += "<td class=\""+strClass+"\" style=\" word-wrap:break-word;text-align: center;\">" + strValue + "</td>";
                }
            }
            html += "</tr>";
        }
    
        html += "</tbody>";
        html += "<tr><td colspan="+ dt.Columns.Count+" style=\" width:100%;word-break: break-all; word-wrap:break-word;text-align: right;\">"  + strcurrenWord + "</td></tr>";
        html += "</table>";
        sb1.Append(html);
        
        return sb1.ToString();
    }
   

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }    
  
}
