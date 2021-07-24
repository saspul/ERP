
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DL_Compzit;
using EL_Compzit;
using System.Data;
using DL_Compzit.DataLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Web.Script.Serialization;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using BL_Compzit;
// CREATED BY:EVM-0008
// CREATED DATE:31/12/2016
// REVIEWED BY:
// REVIEW DATE:


/// <summary>
/// Summary description for Service_Leave_Allocation
/// </summary>
[WebService(Namespace = "http://microsoft.com/webservices/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class Service_Leave_Allocation : System.Web.Services.WebService {

    public Service_Leave_Allocation () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string ReadRemUsrLevType(string strdate, int strUserId, int strtypId)
    
    {
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
       // decimal ret=0;
           CL_Compzit.clsCommonLibrary objCommon = new CL_Compzit.clsCommonLibrary();
        string strRemLev="",ret="";
        objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(strdate);
        objEntLevAllocn.Leave_Id = Convert.ToInt32(strtypId);
        objEntLevAllocn.EmployeeId = Convert.ToInt32(strUserId);

      DataTable dataDt = objBusLevAllocn.ReadRemLeavNxtYr(objEntLevAllocn);
      if (dataDt.Rows.Count > 0)
      {
          strRemLev = dataDt.Rows[0]["BALANCE_NUMLEAVE"].ToString();
      }


      if (strRemLev != "")
      {
        //  ret = Convert.ToDecimal(strRemLev);
          ret = strRemLev;
      }


      return ret;
       
    }


    [WebMethod]
    public decimal ReadOPeningLeave( int strtypId)
    {
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
        decimal ret = 0;
        CL_Compzit.clsCommonLibrary objCommon = new CL_Compzit.clsCommonLibrary();
        string strRemLev = "";
        
        objEntLevAllocn.Leave_Id = Convert.ToInt32(strtypId);


        DataTable dataDt = objBusLevAllocn.ReadOPeningLeav(objEntLevAllocn);
        if (dataDt.Rows.Count > 0)
        {
            strRemLev = dataDt.Rows[0]["LEAVETYP_NUMDAYS"].ToString();
        }
        if (strRemLev != "")
        {
            ret = Convert.ToDecimal(strRemLev);
        }


        return ret;
    }


    [WebMethod]
    public int ReadHolidayCountSiglDat(string strdate)
    {
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
        int ret = 0;
        CL_Compzit.clsCommonLibrary objCommon = new CL_Compzit.clsCommonLibrary();
        string strRemLev = "";

        if (strdate != "")
        {
            objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(strdate);
        }

        DataTable dataDt = objBusLevAllocn.ReadHolidayCountSiglDate(objEntLevAllocn);
        if (dataDt.Rows.Count > 0 && dataDt.Rows[0]["HOLCOUNT"].ToString() != "")
        {
            strRemLev = dataDt.Rows[0]["HOLCOUNT"].ToString();
        }
        if (strRemLev != "0")
        {
            ret = Convert.ToInt32((strRemLev));
        }


        return ret;
    }
    [WebMethod]
    public int ReadHolidayCountSiglDatTo(string strdate)
    {
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
        int ret = 0;
        CL_Compzit.clsCommonLibrary objCommon = new CL_Compzit.clsCommonLibrary();
        string strRemLev = "";

        objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(strdate);


        DataTable dataDt = objBusLevAllocn.ReadHolidayCountSiglDateTo(objEntLevAllocn);
        if (dataDt.Rows.Count > 0 && dataDt.Rows[0]["HOLCOUNT"].ToString() != "")
        {
            strRemLev = dataDt.Rows[0]["HOLCOUNT"].ToString();
        }
        if (strRemLev != "0")
        {
            ret = Convert.ToInt32((strRemLev));
        }


        return ret;
    }
    [WebMethod]
    public int ReadHolidayCountSiglDatFrm(string strdate)
    {
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
        int ret = 0;
        CL_Compzit.clsCommonLibrary objCommon = new CL_Compzit.clsCommonLibrary();
        string strRemLev = "";

        objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(strdate);


        DataTable dataDt = objBusLevAllocn.ReadHolidayCountSiglDateFrm(objEntLevAllocn);
        if (dataDt.Rows.Count > 0 && dataDt.Rows[0]["HOLCOUNT"].ToString() != "")
        {
            strRemLev = dataDt.Rows[0]["HOLCOUNT"].ToString();
        }
        if (strRemLev != "0")
        {
            ret = Convert.ToInt32((strRemLev));
        }


        return ret;
    }
     [WebMethod]
    public int HolidaySameyrCount(string strdate,string strdateto)
    {
        clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
        clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
        int ret = 0;
        CL_Compzit.clsCommonLibrary objCommon = new CL_Compzit.clsCommonLibrary();
        string strRemLev = "";

        objEntLevAllocn.LeaveFrmDate = objCommon.textToDateTime(strdate);
        objEntLevAllocn.LeaveToDate = objCommon.textToDateTime(strdateto);

        DataTable dataDt = objBusLevAllocn.HolidayChck(objEntLevAllocn);
        if (dataDt.Rows.Count > 0 && dataDt.Rows[0]["HOLCOUNT"].ToString() != "")
        {
            strRemLev = dataDt.Rows[0]["HOLCOUNT"].ToString();
        }
        if (strRemLev != "0")
        {
            ret = Convert.ToInt32((strRemLev));
        }


        return ret;
    }

     [WebMethod]
     public string HolidayCovrtDecToWords(int strnum)
     {
         clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new clsBussinessLayerLeaveAllocationMaster();
         clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new clsEntityLayerLeaveAllocationMaster();
         // ret = 0;
        // CL_Compzit.clsCommonLibrary objCommon = new CL_Compzit.clsCommonLibrary();
         BL_Compzit.clsBusinessLayer objBusinessLayer = new BL_Compzit.clsBusinessLayer();
         string strRemLev = "";

        strRemLev=objBusinessLayer.ConvertDecimalPart(strnum);




        return strRemLev;
     }
     [WebMethod]
     public string ReadRemLeavePaidEligble(string strtypId, string EmpId, string strOrgId, string strCorpId)
     {        
            clsEntityLayerLeaveSettlmt objEntityLeavSettlmt = new clsEntityLayerLeaveSettlmt();
            clsBusinessLayerLeaveSettlmt objBusinessLeavSettlmt = new clsBusinessLayerLeaveSettlmt();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            objEntityLeavSettlmt.EmployeeId = Convert.ToInt32(EmpId);
            objEntityLeavSettlmt.CorpId = Convert.ToInt32(strCorpId);
            objEntityLeavSettlmt.OrgId = Convert.ToInt32(strOrgId);
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            DateTime dtFinal = new DateTime();
            cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
            cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
            objEnt.Employee = Convert.ToInt32(EmpId); ;
            DataTable dtLeavMonth11 = objBuss.ReadLastLeaveStlDate(objEnt);
            if (dtLeavMonth11.Rows.Count > 0)
            {
             for (int i = 0; i < dtLeavMonth11.Rows.Count; i++)
             {
              if (dtLeavMonth11.Rows[i]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "" && dtLeavMonth11.Rows[i][1].ToString() == "1")
              {
                  dtFinal = objCommon.textToDateTime(dtLeavMonth11.Rows[i]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                  dtFinal = dtFinal.AddDays(1);
              }
             }
            }
                DataTable dtEmpRejoin = objBusinessLeavSettlmt.ReadRejoin(objEntityLeavSettlmt);
                DataTable dtEmpjoin = objBusinessLeavSettlmt.ReadJoinDt(objEntityLeavSettlmt);
                DataTable dtEmpLev = objBusinessLeavSettlmt.ReadInsertDt(objEntityLeavSettlmt);
                DataTable dtEmpOpenRejoin = objBusinessLeavSettlmt.ReadOpenRejoin(objEntityLeavSettlmt);

                int rejoinHalfDay = 0;
                string strRejoinJoinDate = "";
                if (dtEmpRejoin.Rows.Count > 0 && dtEmpRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString() != "")
                {
                    strRejoinJoinDate = dtEmpRejoin.Rows[0]["DUTYREJOIN_DATE"].ToString();
                    rejoinHalfDay = Convert.ToInt32(dtEmpRejoin.Rows[0]["HALFDAY_STATUS"].ToString());
                }
                else if (dtEmpOpenRejoin.Rows.Count > 0 && dtEmpOpenRejoin.Rows[0]["USRJDT_ACT_DATE"].ToString() != "")
                {
                    strRejoinJoinDate = dtEmpOpenRejoin.Rows[0]["USRJDT_CALC_DATE"].ToString();
                }
                else if (dtEmpjoin.Rows.Count > 0 && dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString() != "")
                {
                    strRejoinJoinDate = dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString();
                }
                else if (dtEmpLev.Rows.Count > 0 && dtEmpLev.Rows[0]["USR_INS_DATE"].ToString() != "")
                {
                    strRejoinJoinDate = dtEmpLev.Rows[0]["USR_INS_DATE"].ToString();
                }
                else if (dtEmpjoin.Rows.Count > 0 && dtEmpjoin.Rows[0]["USR_JOIN_DATE"].ToString() != "")
                {
                    strRejoinJoinDate = dtEmpjoin.Rows[0]["USR_JOIN_DATE"].ToString();
                }
                string strCurrDateServer = objBusinessLayer.LoadCurrentDateInString();

                DataTable dtTotalLeavTaken = objBusinessLeavSettlmt.ReadEmpLeav(objEntityLeavSettlmt);
                DateTime Today = objCommon.textToDateTime(strCurrDateServer);
                string Year = Today.ToString("yyyy");
                DateTime Date1 = new DateTime();
                DateTime Date2 = new DateTime();
                 if (strRejoinJoinDate != "")
                    {
                        Date1 = objCommon.textToDateTime(strRejoinJoinDate);
                    }
                    DataTable dtLeavSettld = objBusinessLeavSettlmt.ReadLastSettldDt(objEntityLeavSettlmt);
                    DateTime dtLastSettle = new DateTime();
                    if (dtLeavSettld.Rows.Count > 0 && dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString() != "")
                    {
                        dtLastSettle = objCommon.textToDateTime(dtLeavSettld.Rows[0]["LEVSETLMT_LST_SETLMTDATE"].ToString());
                    }
                    DataTable dtLeavMonth = objBusinessLeavSettlmt.ReadMonthlyLastDate(objEntityLeavSettlmt);
                    if (dtLastSettle != DateTime.MinValue || Date1 != DateTime.MinValue)
                    {
                        if (dtLastSettle > Date1)
                        {
                            Date1 = dtLastSettle;
                        }
                    }
                    if (dtFinal != DateTime.MinValue)
                    {
                        if (dtFinal > Date1)
                        {
                            Date1 = dtFinal;
                        }
                    }
                    if (strCurrDateServer != null)
                    {
                        Date2 = objCommon.textToDateTime(strCurrDateServer);
                    }
                    DateTime dtFrom = Date1;
                    DateTime dtTo = Date2;
                    DateTime dtJoinDate = new DateTime();
                    int FromYear = dtFrom.Year;
                    int ToYear = dtTo.Year;
                    int CurrYear = Today.Year;
                    decimal PrevYearBalLeave = 0, CurrYearBalLeave = 0;
                    decimal CurrYearDays = 0, NextYearDays = 0, JoinDateDays = 365;
                    decimal LeaveEligbleDays = 0;
                    if (dtEmpjoin.Rows.Count > 0 && dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString() != "")
                    {
                        dtJoinDate = objCommon.textToDateTime(dtEmpjoin.Rows[0]["EMPERDTL_JOIN_DATE"].ToString());
                        if (dtJoinDate.Year == dtFrom.Year)
                        {
                            JoinDateDays = CalculateDays(dtJoinDate, new DateTime(dtJoinDate.Year, 12, 31));
                        }
                    }
                    if (FromYear == ToYear)
                    {
                        CurrYearDays = CalculateDays(dtFrom, dtTo);
                    }
                    else
                    {
                        int YearDiff = ToYear - FromYear;
                        if (dtFrom.Year == CurrYear)
                        {
                            DateTime NewToDate = new DateTime(dtFrom.Year, 12, 31);
                            CurrYearDays = CalculateDays(dtFrom, NewToDate);
                        }
                        if (dtTo.Year == CurrYear)
                        {
                            DateTime NewFromDate = new DateTime(dtTo.Year, 1, 1);
                            CurrYearDays = CalculateDays(NewFromDate, dtTo);
                        }
                        else if (YearDiff > 1)
                        {
                            DateTime NewFromDatep = new DateTime(CurrYear, 1, 1);
                            DateTime NewToDate = new DateTime(CurrYear, 12, 31);
                            if (NewToDate > dtTo)
                            {
                                NewToDate = dtTo;
                            }
                            CurrYearDays = CalculateDays(NewFromDatep, NewToDate);
                        }
                        if (dtTo.Year > CurrYear)
                        {
                            DateTime NewFromDate = new DateTime(dtTo.Year, 1, 1);
                            NextYearDays = CalculateDays(NewFromDate, dtTo);
                        }
                    }
                    if (rejoinHalfDay == 1)
                    {
                        CurrYearDays = CurrYearDays - (decimal)0.5;
                    }
                    objEntityLeavSettlmt.Year = Date2.Year;
                    DataTable dtLeav = objBusinessLeavSettlmt.ReadEligibleLeaveCount(objEntityLeavSettlmt);
                    if (dtLeav.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtLeav.Rows.Count; i++)
                        {
                            if (dtLeav.Rows[i]["LEAVETYP_ID"].ToString() == strtypId)
                            {
                                int dtDear = Convert.ToInt32(dtLeav.Rows[i]["USRLEAVTYP_YEAR"].ToString());
                                if (dtLeav.Rows[i]["USRLEAVTYP_SETTLEMENT_LEAVE"].ToString() != "")
                                {
                                    if (dtDear < CurrYear)
                                    {
                                        PrevYearBalLeave = Convert.ToDecimal(dtLeav.Rows[i]["USRLEAVTYP_SETTLEMENT_LEAVE"].ToString());
                                        LeaveEligbleDays += PrevYearBalLeave;
                                    }
                                    else if (dtDear == CurrYear)
                                    {
                                        CurrYearBalLeave = Convert.ToDecimal(dtLeav.Rows[i]["USRLEAVTYP_SETTLEMENT_LEAVE"].ToString());
                                        if (dtJoinDate.Year == dtDear)
                                        {
                                            LeaveEligbleDays += (CurrYearBalLeave / JoinDateDays) * CurrYearDays;                                           
                                        }
                                        else
                                        {
                                            LeaveEligbleDays += (CurrYearBalLeave / 365) * CurrYearDays;                                          
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return LeaveEligbleDays.ToString("0.00");                                 
     }

     public static decimal CalculateDays(DateTime dtFrom, DateTime dtTo)
     {
         decimal TotalDays = Convert.ToInt32((dtTo - dtFrom).TotalDays) + 1;
         if (TotalDays > 365)
         {
             TotalDays = 365;
         }
         if (TotalDays < 0)
         {
             TotalDays = 0;
         }
         return TotalDays;
     }


}
