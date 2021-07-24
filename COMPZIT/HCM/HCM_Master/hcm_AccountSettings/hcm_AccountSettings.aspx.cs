using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using System.Data;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Services;
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;

using System.Web.Mail;
using BL_Compzit.BusineesLayer_HCM;
using Newtonsoft.Json;
public partial class HCM_HCM_Master_hcm_AccountSettings_hcm_AccountSettings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblEntry.Text = "Account Setting";
            int intCorpId = 0, intOrgId = 0, intuserId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {

                intuserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

        }

    }
    //protected void btnAdd_Click(object sender, EventArgs e)
    //{
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
    //    clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
    //    clsEntity_AccountSettings objEntityAccountSettings = new clsEntity_AccountSettings();
    //    clsbusinessLayer_AccntSetting objBusinessAccountSetting = new clsbusinessLayer_AccntSetting();
    //    int intCorpId = 0, intOrgId = 0, intuserId = 0;
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
      
    //    if (Session["ORGID"] != null)
    //    {
    //        intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }

    //    if (Session["USERID"] != null)
    //    {
            
    //        intuserId = Convert.ToInt32(Session["USERID"].ToString());
    //    }
    //    else if (Session["USERID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }

    //    objEntityLeaveRequest.Corporate_id = intCorpId;
    //    objEntityLeaveRequest.Organisation_id = intOrgId;
    //    objEntityAccountSettings.OrgId = intOrgId;
    //    objEntityAccountSettings.CorpId = intCorpId;
    //   // objEntityLeaveRequest.User_Id = EmployeeId;
    //    clsBusinessLayer objBusiness = new clsBusinessLayer();
    //    string strCurrentDate = objBusiness.LoadCurrentDateInString();

    //    DateTime dtCurreDate = objCommon.textToDateTime(strCurrentDate);

    //    DataTable DtLevAlloDetails = objBusinessLeaveRequest.ReadLeavTypdtl(objEntityLeaveRequest);
    //    DataTable DtUser = objBusinessAccountSetting.ReadEmployeLeaveDetails(objEntityAccountSettings);
    //    int intCount = 0;
    //  //  pp.Attributes.Add("max", intCount.ToString());
    //  //  pp.Attributes.Add("min", "0");

    //    for (int intRowCount = 0; intRowCount < DtUser.Rows.Count; intRowCount++)
    //    {
    //        string UsrDesg = DtUser.Rows[intRowCount]["DSGN_ID"].ToString();
    //        string UsrJoinDate = DtUser.Rows[intRowCount]["EMPERDTL_JOIN_DATE"].ToString();
    //        string UsrGender = DtUser.Rows[intRowCount]["EMPERDTL_GENDER"].ToString();
    //        string UsrMrtlSts = DtUser.Rows[intRowCount]["EMPERDTL_MRTL_STS"].ToString();
    //        string UsrPayGrd = DtUser.Rows[intRowCount]["PYGRD_ID"].ToString();
           
    //        pp.Attributes.Add("value", intCount.ToString());
    //        Label_For_Server_Time.InnerHtml = intCount.ToString();
    //        intCount = intCount + 1;

          


    //        if (UsrJoinDate != "")
    //        {
    //        foreach (DataRow rowDepnt in DtLevAlloDetails.Rows)
    //        {
    //            string GendrChck = "false", MrtlChck = "false", DesgChck = "false", PayGrdChck = "false", ExpChck = "false";
    //            objEntityLeaveRequest.Leave_Id = Convert.ToInt32(rowDepnt["LEAVETYP_ID"].ToString());
    //            DataTable dtGendrMrtSts = objBusinessLeaveRequest.ReadGendrMrtSts(objEntityLeaveRequest);
    //            DataTable dtDesgDtls = objBusinessLeaveRequest.ReadDesgDtls(objEntityLeaveRequest);
    //            DataTable dtPayGrdeDtls = objBusinessLeaveRequest.ReadPayGrdedtls(objEntityLeaveRequest);
    //            DataTable dtExpDtls = objBusinessLeaveRequest.ReadExpDtls(objEntityLeaveRequest);

    //            //For gender check
    //            if (dtGendrMrtSts.Rows.Count > 0)
    //            {
    //                if (dtGendrMrtSts.Rows[0][0].ToString() == "2")
    //                {
    //                    GendrChck = "true";
    //                }
    //                else if (dtGendrMrtSts.Rows[0][0].ToString() == UsrGender)
    //                {
    //                    GendrChck = "true";
    //                }
    //            }
    //            //For marrital status
    //            if (dtGendrMrtSts.Rows.Count > 0)
    //            {
    //                if (dtGendrMrtSts.Rows[0][1].ToString() == "2")
    //                {
    //                    MrtlChck = "true";
    //                }
    //                else if (dtGendrMrtSts.Rows[0][1].ToString() != UsrGender)
    //                {
    //                    MrtlChck = "true";
    //                }
    //            }
    //            //For Designation 
    //            if (dtDesgDtls.Rows.Count > 0)
    //            {
    //                if (dtDesgDtls.Rows[0][1].ToString() == "1")
    //                {
    //                    DesgChck = "true";
    //                }
    //                else
    //                {
    //                    foreach (DataRow rowDesg in dtDesgDtls.Rows)
    //                    {
    //                        if (rowDesg[0].ToString() == UsrDesg)
    //                        {
    //                            DesgChck = "true";
    //                            break;
    //                        }
    //                    }

    //                }
    //            }
    //            //For paygrade
    //            if (dtPayGrdeDtls.Rows.Count > 0)
    //            {
    //                if (dtPayGrdeDtls.Rows[0][1].ToString() == "1")
    //                {
    //                    PayGrdChck = "true";
    //                }
    //                else
    //                {
    //                    foreach (DataRow rowDesg in dtPayGrdeDtls.Rows)
    //                    {
    //                        if (rowDesg[0].ToString() == UsrPayGrd)
    //                        {
    //                            PayGrdChck = "true";
    //                            break;
    //                        }
    //                    }

    //                }
    //            }
    //            //For experience
    //            decimal ExpYears = 0;
    //            if (UsrJoinDate != "")
    //            {

    //                DateTime Dob = objCommon.textToDateTime(UsrJoinDate);
    //                //ExpYears = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
    //                ExpYears = (dtCurreDate.Month - Dob.Month) + 12 * (dtCurreDate.Year - Dob.Year);
    //                ExpYears = ExpYears / 12;
    //            }

    //            if (dtExpDtls.Rows.Count > 0)
    //            {
    //                if (dtExpDtls.Rows[0][1].ToString() == "1")
    //                {
    //                    ExpChck = "true";
    //                }
    //                else
    //                {
    //                    foreach (DataRow rowDesg in dtExpDtls.Rows)
    //                    {
    //                        int intMinYear = Convert.ToInt32(rowDesg[2]);
    //                        int intMaxYear = Convert.ToInt32(rowDesg[3]);
    //                        if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
    //                        {
    //                            ExpChck = "true";
    //                        }

    //                    }

    //                }
    //            }


    //            if ((DesgChck == "true" || ExpChck == "true" || PayGrdChck == "true") && (GendrChck == "true" && MrtlChck == "true"))
    //            {
    //            }
    //            else
    //            {
    //                rowDepnt.Delete();

    //            }
    //        }

    //        DtLevAlloDetails.AcceptChanges();
    //        decimal days = 365;

           
    //            DateTime DtJoinDate;
    //            DtJoinDate = objCommon.textToDateTime(UsrJoinDate);
    //            if (dtCurreDate.Year > DtJoinDate.Year)
    //            {
    //                DtJoinDate = new DateTime(dtCurreDate.Year, 1, 1);
    //            }
    //            else
    //            {
    //                days = CalculateDays(DtJoinDate, new DateTime(DtJoinDate.Year, 12, 31));
    //            }
              
    //            for (int i = 0; i < DtLevAlloDetails.Rows.Count; i++)
    //            {
    //                string strchkuserlevCount = "0";
                    
    //                objEntityLeaveRequest.LeaveFrmDate = DtJoinDate;
    //                objEntityLeaveRequest.User_Id =Convert.ToInt32( DtUser.Rows[intRowCount]["USR_ID"].ToString());
    //                objEntityLeaveRequest.Leave_Id = Convert.ToInt32(DtLevAlloDetails.Rows[i]["LEAVETYP_ID"].ToString());
    //                strchkuserlevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
    //                objEntityLeaveRequest.OpeningLv = (Convert.ToDecimal(DtLevAlloDetails.Rows[i]["LEAVETYP_NUMDAYS"].ToString()) / 365) * days;
    //                objEntityLeaveRequest.RemingLev = (Convert.ToDecimal(DtLevAlloDetails.Rows[i]["LEAVETYP_NUMDAYS"].ToString()) / 365) * days;
    //                if (strchkuserlevCount != "0" && strchkuserlevCount != "")
    //                {
    //                }
    //                else
    //                {
                        
    //                        objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
    //                        ScriptManager.RegisterStartupScript(this, this.GetType(), "updateProgressBar()", "updateProgressBar(); ", true);
                        
    //                }
    //            }
               
    //        }
        
          
    //    }

    //   // pp.Attributes.Add("value", DtUser.Rows.Count.ToString());
    //}
    public static decimal CalculateDays(DateTime dtFrom, DateTime dtTo)
    {
        decimal TotalDays = Convert.ToInt32((dtTo - dtFrom).TotalDays) + 1;
        if (TotalDays > 365)
        {
            TotalDays = 365;
        }
        return TotalDays;
    }
    [WebMethod]
    public static string LoadLeaveDetails(string OrgId,string CorpId)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLeaveRequest objBusinessLeaveRequest = new clsBusinessLeaveRequest();
        clsEntityLeaveRequest objEntityLeaveRequest = new clsEntityLeaveRequest();
        clsEntity_AccountSettings objEntityAccountSettings = new clsEntity_AccountSettings();
        clsbusinessLayer_AccntSetting objBusinessAccountSetting = new clsbusinessLayer_AccntSetting();
        int intCorpId =Convert.ToInt32(CorpId), intOrgId = Convert.ToInt32(OrgId), intuserId = 0;
        //if (Session["CORPOFFICEID"] != null)
        //{
        //    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        //}
        //else if (Session["CORPOFFICEID"] == null)
        //{
        //    Response.Redirect("~/Default.aspx");
        //}

        //if (Session["ORGID"] != null)
        //{
        //    intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        //}
        //else if (Session["ORGID"] == null)
        //{
        //    Response.Redirect("/Default.aspx");
        //}

        //if (Session["USERID"] != null)
        //{

        //    intuserId = Convert.ToInt32(Session["USERID"].ToString());
        //}
        //else if (Session["USERID"] == null)
        //{
        //    Response.Redirect("/Default.aspx");
        //}
        string msg = "True";
        objEntityLeaveRequest.Corporate_id = intCorpId;
        objEntityLeaveRequest.Organisation_id = intOrgId;
        objEntityAccountSettings.OrgId = intOrgId;
        objEntityAccountSettings.CorpId = intCorpId;
        // objEntityLeaveRequest.User_Id = EmployeeId;
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strCurrentDate = objBusiness.LoadCurrentDateInString();

        DateTime dtCurreDate = objCommon.textToDateTime(strCurrentDate);

        DataTable DtLevAlloDetails = objBusinessLeaveRequest.ReadLeavTypdtl(objEntityLeaveRequest);
        DataTable DtUser = objBusinessAccountSetting.ReadEmployeLeaveDetails(objEntityAccountSettings);
        int intCount = 0;
        //  pp.Attributes.Add("max", intCount.ToString());
        //  pp.Attributes.Add("min", "0");

        for (int intRowCount = 0; intRowCount < DtUser.Rows.Count; intRowCount++)
        {
            string UsrDesg = DtUser.Rows[intRowCount]["DSGN_ID"].ToString();
            string UsrJoinDate = DtUser.Rows[intRowCount]["EMPERDTL_JOIN_DATE"].ToString();
            string UsrGender = DtUser.Rows[intRowCount]["EMPERDTL_GENDER"].ToString();
            string UsrMrtlSts = DtUser.Rows[intRowCount]["EMPERDTL_MRTL_STS"].ToString();
            string UsrPayGrd = DtUser.Rows[intRowCount]["PYGRD_ID"].ToString();

            //pp.Attributes.Add("value", intCount.ToString());
            //Label_For_Server_Time.InnerHtml = intCount.ToString();
            intCount = intCount + 1;




            if (UsrJoinDate != "")
            {
                foreach (DataRow rowDepnt in DtLevAlloDetails.Rows)
                {
                    string GendrChck = "false", MrtlChck = "false", DesgChck = "false", PayGrdChck = "false", ExpChck = "false";
                    objEntityLeaveRequest.Leave_Id = Convert.ToInt32(rowDepnt["LEAVETYP_ID"].ToString());
                    DataTable dtGendrMrtSts = objBusinessLeaveRequest.ReadGendrMrtSts(objEntityLeaveRequest);
                    DataTable dtDesgDtls = objBusinessLeaveRequest.ReadDesgDtls(objEntityLeaveRequest);
                    DataTable dtPayGrdeDtls = objBusinessLeaveRequest.ReadPayGrdedtls(objEntityLeaveRequest);
                    DataTable dtExpDtls = objBusinessLeaveRequest.ReadExpDtls(objEntityLeaveRequest);

                    //For gender check
                    if (dtGendrMrtSts.Rows.Count > 0)
                    {
                        if (dtGendrMrtSts.Rows[0][0].ToString() == "2")
                        {
                            GendrChck = "true";
                        }
                        else if (dtGendrMrtSts.Rows[0][0].ToString() == UsrGender)
                        {
                            GendrChck = "true";
                        }
                    }
                    //For marrital status
                    if (dtGendrMrtSts.Rows.Count > 0)
                    {
                        if (dtGendrMrtSts.Rows[0][1].ToString() == "2")
                        {
                            MrtlChck = "true";
                        }
                        else if (dtGendrMrtSts.Rows[0][1].ToString() != UsrGender)
                        {
                            MrtlChck = "true";
                        }
                    }
                    //For Designation 
                    if (dtDesgDtls.Rows.Count > 0)
                    {
                        if (dtDesgDtls.Rows[0][1].ToString() == "1")
                        {
                            DesgChck = "true";
                        }
                        else
                        {
                            foreach (DataRow rowDesg in dtDesgDtls.Rows)
                            {
                                if (rowDesg[0].ToString() == UsrDesg)
                                {
                                    DesgChck = "true";
                                    break;
                                }
                            }

                        }
                    }
                    //For paygrade
                    if (dtPayGrdeDtls.Rows.Count > 0)
                    {
                        if (dtPayGrdeDtls.Rows[0][1].ToString() == "1")
                        {
                            PayGrdChck = "true";
                        }
                        else
                        {
                            foreach (DataRow rowDesg in dtPayGrdeDtls.Rows)
                            {
                                if (rowDesg[0].ToString() == UsrPayGrd)
                                {
                                    PayGrdChck = "true";
                                    break;
                                }
                            }

                        }
                    }
                    //For experience
                    decimal ExpYears = 0;
                    if (UsrJoinDate != "")
                    {

                        DateTime Dob = objCommon.textToDateTime(UsrJoinDate);
                        //ExpYears = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
                        ExpYears = (dtCurreDate.Month - Dob.Month) + 12 * (dtCurreDate.Year - Dob.Year);
                        ExpYears = ExpYears / 12;
                    }

                    if (dtExpDtls.Rows.Count > 0)
                    {
                        if (dtExpDtls.Rows[0][1].ToString() == "1")
                        {
                            ExpChck = "true";
                        }
                        else
                        {
                            foreach (DataRow rowDesg in dtExpDtls.Rows)
                            {
                                int intMinYear = Convert.ToInt32(rowDesg[2]);
                                int intMaxYear = Convert.ToInt32(rowDesg[3]);
                                if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
                                {
                                    ExpChck = "true";
                                }

                            }

                        }
                    }


                    if ((DesgChck == "true" || ExpChck == "true" || PayGrdChck == "true") && (GendrChck == "true" && MrtlChck == "true"))
                    {
                    }
                    else
                    {
                        rowDepnt.Delete();

                    }
                }

                DtLevAlloDetails.AcceptChanges();
                decimal days = 365;


                DateTime DtJoinDate;
                DtJoinDate = objCommon.textToDateTime(UsrJoinDate);
                if (dtCurreDate.Year > DtJoinDate.Year)
                {
                    DtJoinDate = new DateTime(dtCurreDate.Year, 1, 1);
                }
                else
                {
                    days = CalculateDays(DtJoinDate, new DateTime(DtJoinDate.Year, 12, 31));
                }

                for (int i = 0; i < DtLevAlloDetails.Rows.Count; i++)
                {
                    string strchkuserlevCount = "0";

                    objEntityLeaveRequest.LeaveFrmDate = DtJoinDate;
                    objEntityLeaveRequest.User_Id = Convert.ToInt32(DtUser.Rows[intRowCount]["USR_ID"].ToString());
                    objEntityLeaveRequest.Leave_Id = Convert.ToInt32(DtLevAlloDetails.Rows[i]["LEAVETYP_ID"].ToString());
                    strchkuserlevCount = objBusinessLeaveRequest.chkUserLevCount(objEntityLeaveRequest);
                    objEntityLeaveRequest.OpeningLv = (Convert.ToDecimal(DtLevAlloDetails.Rows[i]["LEAVETYP_NUMDAYS"].ToString()) / 365) * days;
                    objEntityLeaveRequest.RemingLev = (Convert.ToDecimal(DtLevAlloDetails.Rows[i]["LEAVETYP_NUMDAYS"].ToString()) / 365) * days;
                    if (strchkuserlevCount != "0" && strchkuserlevCount != "")
                    {
                    }
                    else
                    {
                        
                        try
                        {
                            objBusinessLeaveRequest.InsertUserNewLevRow(objEntityLeaveRequest);
                            msg = "True";
                        }
                        catch (Exception ex)
                        {
                            msg = "Fail";
                        }
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "updateProgressBar()", "updateProgressBar(); ", true);

                    }
                }

            }

           
        }

        return msg;
       
    }
   
}