using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Web.Services;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

public partial class HCM_HCM_Master_hcm_LeaveMaster_hcm_leave_type_hcm_Individual_Leave_Type : System.Web.UI.Page
{
    clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
    clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (Session["CORPOFFICEID"] != null)
            {
                ObjEntityLeaveType.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                ObjEntityLeaveType.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                ObjEntityLeaveType.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }


            int intUserId = 0, intUsrRolMstrId, intEnableReOpen, intEnableConfirm, intEnableAdd = 0;

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Leave_Type_Master);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();
                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }

            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                HiddenLeaveId.Value = strId;
            }
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                HiddenLeaveId.Value = strId;
            }

        }
    }

    [WebMethod]
    public static string[] LoadEmployees(string CorpId, string OrgId, string strSearchString)
    {
        List<string> Employees = new List<string>();

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        objEntityCommon.CorporateID = Convert.ToInt32(CorpId);
        objEntityCommon.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityCommon.Searchstring = strSearchString;

        DataTable dt = objBusinessLayer.ReadEmployees(objEntityCommon);

        for (int intRowCount = 0; intRowCount < dt.Rows.Count; intRowCount++)
        {
            Employees.Add(string.Format("{0}<,>{1}", dt.Rows[intRowCount]["USR_ID"].ToString(), dt.Rows[intRowCount]["USR_NAME_CODE"].ToString()));
        }

        return Employees.ToArray();
    }

    [WebMethod]
    public static string[] LoadDatas(string LeavTypId)
    {
        string[] strReturn = new string[6];

        clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();

        ObjEntityLeaveType.LeaveTypeMasterId = Convert.ToInt32(LeavTypId);
        DataTable dt = objBusinessLeavetype.ReadIndividualLeavTypById(ObjEntityLeaveType);

        if (dt.Rows.Count > 0)
        {
            strReturn[0] = dt.Rows[0]["LEAVETYP_NAME"].ToString() + " (" + dt.Rows[0]["LEAVETYP_NUMDAYS"].ToString() + " days)";
            strReturn[4] = dt.Rows[0]["LEAVETYP_NUMDAYS"].ToString();
            strReturn[5] = dt.Rows[0]["LEAVETYPDTLS_PAIDLEAVE"].ToString();

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("ID", typeof(int));
            dtDetail.Columns.Add("EMPID", typeof(int));
            dtDetail.Columns.Add("EMPNAME", typeof(string));
            dtDetail.Columns.Add("STRTDATE", typeof(string));
            dtDetail.Columns.Add("CNFRMSTS", typeof(int));
            dtDetail.Columns.Add("USEDSTS", typeof(int));

            int CnfrmCnt = 0, CnfrmSts = 0;
            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {
                if (dt.Rows[intCount]["EMPLEAVTYP_ID"].ToString() != "")
                {
                    DataRow drDtl = dtDetail.NewRow();
                    drDtl["ID"] = dt.Rows[intCount]["EMPLEAVTYP_ID"].ToString();
                    drDtl["EMPID"] = dt.Rows[intCount]["USR_ID"].ToString();
                    drDtl["EMPNAME"] = dt.Rows[intCount]["USR_NAME_CODE"].ToString();
                    drDtl["STRTDATE"] = dt.Rows[intCount]["EMPLEAVTYP_DATE"].ToString();
                    drDtl["CNFRMSTS"] = dt.Rows[intCount]["EMPLEAVTYP_CNFRM_STS"].ToString();
                    drDtl["USEDSTS"] = dt.Rows[intCount]["EMPLEAVTYP_USED_STS"].ToString();
                    dtDetail.Rows.Add(drDtl);

                    if (dt.Rows[intCount]["EMPLEAVTYP_CNFRM_STS"].ToString() == "1")
                    {
                        CnfrmCnt++;
                    }
                }
            }

            if (CnfrmCnt == dt.Rows.Count)
            {
                CnfrmSts = 1;
            }

            if (dtDetail.Rows.Count > 0)
            {
                string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
                strReturn[1] = strJson;
                strReturn[2] = dt.Rows.Count.ToString();
                strReturn[3] = CnfrmSts.ToString();
            }
        }

        return strReturn;
    }

    //public void Update(string strId)
    //{
    //    ObjEntityLeaveType.LeaveTypeMasterId = Convert.ToInt32(strId);
    //    DataTable dt = objBusinessLeavetype.ReadIndividualLeavTypById(ObjEntityLeaveType);

    //    if (dt.Rows.Count > 0)
    //    {
    //        lblLeaveTypName.InnerHtml = dt.Rows[0]["LEAVETYP_NAME"].ToString();

    //        DataTable dtDetail = new DataTable();
    //        dtDetail.Columns.Add("ID", typeof(int));
    //        dtDetail.Columns.Add("EMPID", typeof(int));
    //        dtDetail.Columns.Add("EMPNAME", typeof(string));
    //        dtDetail.Columns.Add("STRTDATE", typeof(string));
    //        dtDetail.Columns.Add("CNFRMSTS", typeof(int));
    //        dtDetail.Columns.Add("USEDSTS", typeof(int));

    //        for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
    //        {
    //            if (dt.Rows[intCount]["EMPLEAVTYP_ID"].ToString() != "")
    //            {
    //                DataRow drDtl = dtDetail.NewRow();
    //                drDtl["ID"] = dt.Rows[intCount]["EMPLEAVTYP_ID"].ToString();
    //                drDtl["EMPID"] = dt.Rows[intCount]["USR_ID"].ToString();
    //                drDtl["EMPNAME"] = dt.Rows[intCount]["USR_NAME_CODE"].ToString();
    //                drDtl["STRTDATE"] = dt.Rows[intCount]["EMPLEAVTYP_DATE"].ToString();
    //                drDtl["CNFRMSTS"] = dt.Rows[intCount]["EMPLEAVTYP_CNFRM_STS"].ToString();
    //                drDtl["USEDSTS"] = dt.Rows[intCount]["EMPLEAVTYP_USED_STS"].ToString();
    //                dtDetail.Rows.Add(drDtl);
    //            }
    //        }
    //        if (dtDetail.Rows.Count > 0)
    //        {
    //            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
    //            hiddenEmpLvTypDtls.Value = strJson;
    //            hiddenEmpLvTypRows.Value = dt.Rows.Count.ToString();
    //        }
    //    }

    //}

    [WebMethod]
    public static string SaveUpdDelEmpDtls(string CorpId, string OrgId, string UserId, string LeaveTypId, string AddEmpDtls, string Mode, string CancelIds, string NoOfDays, string PaidLevTypSts)
    {
        string strReturn = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();

        List<clsEntity_Leave_Type> objEntityList = new List<clsEntity_Leave_Type>();
        List<clsEntity_Leave_Type> objEntityDeleteList = new List<clsEntity_Leave_Type>();
        List<clsEntity_Leave_Type> objEntityOverRideList = new List<clsEntity_Leave_Type>();

        ObjEntityLeaveType.Corporate_id = Convert.ToInt32(CorpId);
        ObjEntityLeaveType.Organisation_id = Convert.ToInt32(OrgId);
        ObjEntityLeaveType.User_Id = Convert.ToInt32(UserId);
        ObjEntityLeaveType.LeaveTypeMasterId = Convert.ToInt32(LeaveTypId);
        ObjEntityLeaveType.NoOfDays = Convert.ToInt32(NoOfDays);

        string[] values = AddEmpDtls.Split('‡');
        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] != "")
            {
                clsEntity_Leave_Type objEntityDtls = new clsEntity_Leave_Type();

                string[] valSplit = values[i].Split('%');

                if (valSplit[1] != "" && valSplit[1] != "-Select-" && valSplit[1] != "0")
                {
                    if (valSplit[0] != "0" && valSplit[0] != "")
                    {
                        objEntityDtls.IndividualLeavTypId = Convert.ToInt32(valSplit[0]);
                    }
                    objEntityDtls.EmployeeId = Convert.ToInt32(valSplit[1]);
                    objEntityDtls.Date = objCommon.textToDateTime(valSplit[2]);
                    DateTime dtStartDate = objEntityDtls.Date;
                    objEntityDtls.Year = dtStartDate.Year;

                    //remaining days calculation from start date of new levtype if paid leavtyp
                    string NewYrDate = "01-01-" + objEntityDtls.Year.ToString();
                    int StrtDays = Convert.ToInt32((dtStartDate - objCommon.textToDateTime(NewYrDate)).TotalDays);

                    if (PaidLevTypSts == "1")
                    {
                        decimal NewLevDays = Convert.ToDecimal(NoOfDays);
                        decimal decNewLeaveTotal = (NewLevDays / 365);
                        decNewLeaveTotal = decNewLeaveTotal * StrtDays;

                        decNewLeaveTotal = Convert.ToInt32(NoOfDays) - decNewLeaveTotal;

                        ObjEntityLeaveType.NoOfDays = Convert.ToInt32(decNewLeaveTotal);
                    }

                    DataTable dtReadLevTypeByYr = objBusinessLeavetype.ReadUserLeavTypDtlsByYr(objEntityDtls);

                    int Days = 0;

                    //inserting this leavetype of user if not present for the leave adding year :-START
                    if (dtReadLevTypeByYr.Rows.Count == 0)
                    {
                        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                        string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
                        DateTime CurrentDate = objCommon.textToDateTime(strCurrentDate);

                        if (objEntityDtls.Date >= CurrentDate)
                        {

                            DataTable dtJoin = objBusinessLeavetype.ReadEmpJoinDate(objEntityDtls);
                            string UsrJoinDate = "";
                            if (dtJoin.Rows.Count > 0)
                            {
                                for (int intRowCount = 0; intRowCount < dtJoin.Rows.Count; intRowCount++)
                                {
                                    if (dtJoin.Rows[intRowCount]["TYPE"].ToString() == "USR_JOIN_DATE" && dtJoin.Rows[intRowCount]["VALUE"].ToString() != "")
                                    {
                                        UsrJoinDate = dtJoin.Rows[intRowCount]["VALUE"].ToString();
                                    }
                                    if (dtJoin.Rows[intRowCount]["TYPE"].ToString() == "USR_EXPCTD_JOIN_DATE" && dtJoin.Rows[intRowCount]["VALUE"].ToString() != "")
                                    {
                                        UsrJoinDate = dtJoin.Rows[intRowCount]["VALUE"].ToString();
                                    }
                                }
                            }

                            DataTable dtExpDtls = objBusinessLeavetype.ReadExperienceByID(objEntityDtls);
                            decimal ExpYears = 0;
                            int ExpChck = 0;
                            if (UsrJoinDate != "")
                            {
                                DateTime Dob = objCommon.textToDateTime(UsrJoinDate);

                                ExpYears = (CurrentDate.Month - Dob.Month) + 12 * (CurrentDate.Year - Dob.Year);
                                ExpYears = ExpYears / 12;

                                for (int intRowCount = 0; intRowCount < dtExpDtls.Rows.Count; intRowCount++)
                                {
                                    int intMinYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MIN_YEAR"]);
                                    int intMaxYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MAX_YEAR"]);
                                    if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
                                    {
                                        ExpChck = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["LEAVDTLS_EXPMASTR_ID"]);
                                    }
                                }
                            }

                            objEntityDtls.ExpMstrId = Convert.ToInt32(ExpChck);
                            objEntityDtls.FromDate = dtStartDate;

                            DataTable dtLeaveTypes = objBusinessLeavetype.ReadUserLeaveTypes(objEntityDtls);

                            for (int intRowCnt = 0; intRowCnt < dtLeaveTypes.Rows.Count; intRowCnt++)
                            {
                                objEntityDtls.LeaveTypeMasterId = Convert.ToInt32(dtLeaveTypes.Rows[intRowCnt]["LEAVETYP_ID"].ToString());
                                objEntityDtls.NoOfDays = Convert.ToInt32(dtLeaveTypes.Rows[intRowCnt]["LEAVETYP_NUMDAYS"].ToString());

                                objBusinessLeavetype.InsertUserNewLevRow(objEntityDtls);
                            }
                        }
                    }
                    //inserting this leavetype of user if not present for the leave adding year :-END


                    if (Mode == "1")
                    {
                        objEntityDtls.ConfirmSts = 1;
                    }
                    else if (Mode == "3")
                    {
                        objEntityDtls.ReopenSts = 1;
                    }

                    objEntityDtls.Corporate_id = ObjEntityLeaveType.Corporate_id;
                    objEntityDtls.Organisation_id = ObjEntityLeaveType.Organisation_id;
                    DataTable dt = objBusinessLeavetype.ReadEmpJoinDate(objEntityDtls);
                    string strDate = "";
                    if (dt.Rows.Count > 0)
                    {
                        for (int intRowCount = 0; intRowCount < dt.Rows.Count; intRowCount++)
                        {
                            if (dt.Rows[intRowCount]["TYPE"].ToString() == "DUTYREJOIN_DATE" && dt.Rows[intRowCount]["VALUE"].ToString() != "")
                            {
                                strDate = dt.Rows[intRowCount]["VALUE"].ToString();
                                break;
                            }
                            else if (dt.Rows[intRowCount]["TYPE"].ToString() == "USR_JOIN_DATE")
                            {
                                strDate = dt.Rows[intRowCount]["VALUE"].ToString();
                            }
                        }
                    }

                    if (strDate != "")
                    {
                        DateTime dtJoinDate = objCommon.textToDateTime(strDate);

                        Days = Convert.ToInt32((dtStartDate - dtJoinDate).TotalDays);

                        if (dtJoinDate.Year != dtStartDate.Year)
                        {
                            Days = Convert.ToInt32((dtStartDate - objCommon.textToDateTime(NewYrDate)).TotalDays);
                        }

                        if (Mode == "1")
                        {
                            if (valSplit[3] != "")
                            {
                                string[] Ovrrdvalues = valSplit[3].Split(',');
                                foreach (string strOvrrd in Ovrrdvalues)
                                {
                                    clsEntity_Leave_Type objEntityOverrdDtls = new clsEntity_Leave_Type();

                                    if (strOvrrd != "")
                                    {
                                        objEntityDtls.OverRideSts = 1;
                                        string[] strSplit = strOvrrd.Split('_');

                                        objEntityOverrdDtls.LeaveTypeMasterId = Convert.ToInt32(strSplit[0]);//overrided leavtype id

                                        //override calculatn
                                        decimal LevDays = Convert.ToDecimal(strSplit[1]);//overrided leavtype no of levdays
                                        decimal decLeaveTotal = (LevDays / 365);
                                        decLeaveTotal = decLeaveTotal * Days;
                                        decLeaveTotal = Convert.ToInt32(LevDays) - decLeaveTotal;

                                        objEntityOverrdDtls.OverRideDays = decLeaveTotal;

                                        objEntityOverRideList.Add(objEntityOverrdDtls);
                                    }
                                }
                            }
                        }
                        else if (Mode == "3")
                        {
                            DataTable dtOverRide = objBusinessLeavetype.ReadUserLeavTypOverRide(objEntityDtls);
                            if (dtOverRide.Rows.Count > 0)
                            {
                                for (int intCount = 0; intCount < dtOverRide.Rows.Count; intCount++)
                                {
                                    clsEntity_Leave_Type objEntityOverrdDtls = new clsEntity_Leave_Type();

                                    objEntityDtls.OverRideSts = 1;
                                    objEntityOverrdDtls.LeaveTypeMasterId = Convert.ToInt32(dtOverRide.Rows[intCount]["LEAVETYP_ID"].ToString());
                                    objEntityOverRideList.Add(objEntityOverrdDtls);
                                }
                            }
                        }

                    }

                    objEntityList.Add(objEntityDtls);
                }
            }
        }

        if (CancelIds != "")
        {
            string[] Cnclvalues = CancelIds.Split(',');
            foreach (string strCncl in Cnclvalues)
            {
                clsEntity_Leave_Type objEntityDeleteDtls = new clsEntity_Leave_Type();
                objEntityDeleteDtls.CancelId = Convert.ToInt32(strCncl);
                objEntityDeleteList.Add(objEntityDeleteDtls);
            }
        }

        objBusinessLeavetype.InsertUpdateDeleteIndividualLeavetyp(ObjEntityLeaveType, objEntityList, objEntityDeleteList, objEntityOverRideList);

        strReturn = ObjEntityLeaveType.IndvdlLeavIds;

        return strReturn;
    }

    [WebMethod]
    public static string LoadEmpDate(string CorpId, string OrgId, string EmpId)
    {
        clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();

        ObjEntityLeaveType.Corporate_id = Convert.ToInt32(CorpId);
        ObjEntityLeaveType.Organisation_id = Convert.ToInt32(OrgId);
        ObjEntityLeaveType.EmployeeId = Convert.ToInt32(EmpId);

        DataTable dt = objBusinessLeavetype.ReadEmpJoinDate(ObjEntityLeaveType);
        string strDate = "";
        if (dt.Rows.Count > 0)
        {
            for (int intRowCount = 0; intRowCount < dt.Rows.Count; intRowCount++)
            {
                if (dt.Rows[intRowCount]["TYPE"].ToString() == "DUTYREJOIN_DATE" && dt.Rows[intRowCount]["VALUE"].ToString() != "")
                {
                    strDate = dt.Rows[intRowCount]["VALUE"].ToString();
                    break;
                }
                else if (dt.Rows[intRowCount]["TYPE"].ToString() == "USR_JOIN_DATE")
                {
                    strDate = dt.Rows[intRowCount]["VALUE"].ToString();
                }
                else if (dt.Rows[intRowCount]["TYPE"].ToString() == "USR_INS_DATE")
                {
                    strDate = dt.Rows[intRowCount]["VALUE"].ToString();
                }
            }
        }

        return strDate;
    }

    public static string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);

            }

            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);
    }

    [WebMethod]
    public static string LoadPaidLeaveTypes(string CorpId, string OrgId, string EmpId, string LeavTypId, string StartDate)
    {
        clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
        clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        ObjEntityLeaveType.EmployeeId = Convert.ToInt32(EmpId);
        ObjEntityLeaveType.LeaveTypeMasterId = Convert.ToInt32(LeavTypId);
        DateTime dtStrtDate = objCommon.textToDateTime(StartDate);
        ObjEntityLeaveType.Year = dtStrtDate.Year;

        DataTable dt = objBusinessLeavetype.ReadUserPaidLeaveType(ObjEntityLeaveType);

        StringBuilder sb = new StringBuilder();
        foreach (DataRow dtRow in dt.Rows)
        {
            sb.Append("<option value=\"" + dtRow["LEAVETYP_ID"].ToString() + "_" + dtRow["LEAVETYP_NUMDAYS"].ToString() + "\">" + dtRow["LEAVETYP_NAME"].ToString() + "</option>");
        }

        return sb.ToString();
    }


}