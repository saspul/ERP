using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class Master_gen_Approval_Hierarchy_temp_gen_Approval_Hierarchy_Temp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtName.Focus();
        if (!IsPostBack)
        {
            cbxMajorityApr.Checked = false;
            cbxSingleApproval.Checked = false;

            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Approval_Hierarchy_Template);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                    }
                }
            }
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId,0);
                lblEntry.InnerHtml = "Edit Approval Hierarchy Template";
                //currPage.InnerText = "Edit Approval Hierarchy Template";
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnClear.Visible = false;
                HiddenFieldAprvlHierarchyId.Value = strId;
            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId,1);
                lblEntry.InnerHtml = "View Approval Hierarchy Template";
                //currPage.InnerText = "View Approval Hierarchy Template";
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                HiddenFieldView.Value = "1";
            }
            else
            {
                lblEntry.InnerHtml = "Add Approval Hierarchy Template";
                //currPage.InnerText = "Add Approval Hierarchy Template";
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
            }
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpd", "SuccessUpd();", true);
                }
            }
        }
    }
    [WebMethod]
    public static string[] ReadDesgDdl(string strLikeEmployee, int orgID, int corptID)
    {
        List<string> Employees = new List<string>();
        clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
        objentityPassport.Corporate_id = corptID;
        objentityPassport.Organisation_id = orgID;
        DataTable dtEmployess = objBussinesspasprt.ReadDesgDDL(strLikeEmployee.ToUpper(), objentityPassport);
        for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
        {
            Employees.Add(string.Format("{0}<->{1}", dtEmployess.Rows[intRowCount]["DSGN_ID"].ToString(), dtEmployess.Rows[intRowCount]["DSGN_NAME"].ToString()));
        }
        return Employees.ToArray();
    }

    [WebMethod]
    public static string[] changeDesg(string strLikeEmployee, int orgID, int corptID, string DesgId)
    {       
         List<string> Employees = new List<string>();           
         clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
         clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
         objentityPassport.Corporate_id = Convert.ToInt32(corptID);
         objentityPassport.Organisation_id = Convert.ToInt32(orgID);
         objentityPassport.DesgId = Convert.ToInt32(DesgId);
         DataTable dtEmployess = objBussinesspasprt.ReadEmployeeDDL(strLikeEmployee.ToUpper(), objentityPassport);
         for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
         {
           Employees.Add(string.Format("{0}<->{1}", dtEmployess.Rows[intRowCount]["USR_ID"].ToString(), dtEmployess.Rows[intRowCount]["USR_NAME"].ToString()));
         }
         return Employees.ToArray();
    }
    [WebMethod]
    public static string checkDup(string orgID, string corptID, string Id, string Name)
    {
        string arr = "";
        try
        {
            clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
            objentityPassport.Corporate_id = Convert.ToInt32(corptID);
            objentityPassport.Organisation_id = Convert.ToInt32(orgID);
            objentityPassport.TempId = Convert.ToInt32(Id);
            objentityPassport.Name = Name;
            DataTable dtSubConrt = objBussinesspasprt.CheckDupName(objentityPassport);
            if (dtSubConrt.Rows[0][0].ToString() != "0")
            {
                arr = "dup";
            }
        }
        catch (Exception ex)
        {
        }
        return arr;
    }
    [WebMethod]
    public static string checkEmpDuplication(string orgID, string corptID, string Id, string DtlId, string EmpId, string CanclIds)
    {
        string arr = "";
        try
        {
            clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
            objentityPassport.Corporate_id = Convert.ToInt32(corptID);
            objentityPassport.Organisation_id = Convert.ToInt32(orgID);
            objentityPassport.TempId = Convert.ToInt32(Id);
            objentityPassport.ParentId = Convert.ToInt32(DtlId);
            objentityPassport.EmployeeId = Convert.ToInt32(EmpId);
            objentityPassport.CancelReason = CanclIds.Replace('-', ',');
            DataTable dtSubConrt = objBussinesspasprt.CheckEmpDup(objentityPassport);
            if (dtSubConrt.Rows[0][0].ToString() != "0")
            {
                arr = "dup";
            }
        }
        catch (Exception ex)
        {
        }
        return arr;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
            if (Session["CORPOFFICEID"] != null)
            {
                objentityPassport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objentityPassport.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objentityPassport.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            objentityPassport.TempId = Convert.ToInt32(HiddenFieldAprvlHierarchyId.Value);
            objentityPassport.Name = txtName.Value.Trim();
            if (cbxSts.Checked == true)
            {
                objentityPassport.Status_id = 1;
            }
            if (cbxMajorityApr.Checked == true)
            {
                objentityPassport.MajorityAprvSts = 1;
            }
            if (cbxSingleApproval.Checked == true)
            {
                objentityPassport.SingleApprvlSts = 1;
            }
            if (txtFromdate.Value.Trim() != "")
            {
                objentityPassport.StartDate = objCommon.textToDateTime(txtFromdate.Value.Trim());
            }
            if (txtTodate.Value.Trim() != "")
            {
                objentityPassport.EndDate = objCommon.textToDateTime(txtTodate.Value.Trim());
            }
            List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListIns = new List<clsEntityApprovalHierarchyTemp>();
            List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele = new List<clsEntityApprovalHierarchyTemp>();
            List<clsEntityApprovalHierarchyTemp> objEntitySubstituteList = new List<clsEntityApprovalHierarchyTemp>();

            string jsonData = HiddenFieldMainData.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");
            List<clsTVData> objTVDataList5 = new List<clsTVData>();
            objTVDataList5 = JsonConvert.DeserializeObject<List<clsTVData>>(i);
            if (HiddenFieldMainData.Value != "" && HiddenFieldMainData.Value != null)
            {
                int Count = 0;
                foreach (clsTVData objclsTVData in objTVDataList5)
                {
                    clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();

                    if (objclsTVData.EMPID != "-Select-" && objclsTVData.DESGID != "-Select-" && objclsTVData.PERIOD != "")
                    {
                        objEntityDetails.DesgId = Convert.ToInt32(objclsTVData.DESGID);
                        objEntityDetails.EmployeeId = Convert.ToInt32(objclsTVData.EMPID);
                        objEntityDetails.MajorityAprvSts = Convert.ToInt32(objclsTVData.APPRVMANSTS);
                        objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objclsTVData.SUBEMPSTS);
                        objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objclsTVData.THRESMODE);
                        objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objclsTVData.PERIOD);
                        objEntityDetails.AprvPendingSts = Convert.ToInt32(objclsTVData.APPRVPENSTS);
                        objEntityDetails.TtExceededSts = Convert.ToInt32(objclsTVData.TTCSTS);
                        objEntityDetails.SmsSts = Convert.ToInt32(objclsTVData.SMSSTS);
                        objEntityDetails.SystemSts = Convert.ToInt32(objclsTVData.SYSSTS);
                        objEntityDetails.MailSts = Convert.ToInt32(objclsTVData.MAILSTS);
                        objEntityDetails.SkipLvlSts = Convert.ToInt32(objclsTVData.SKIPLVLSTS);
                        objEntityDetails.Count = Count;
                        if (objclsTVData.DTLID != "" && objclsTVData.DTLID != "null" && objclsTVData.DTLID != null)
                        {
                            objEntityDetails.TempId = Convert.ToInt32(objclsTVData.DTLID);
                        }
                        objEntityTrficVioltnDetilsListIns.Add(objEntityDetails);


                        string SubstituteVal = objclsTVData.SUBSTUTVAL;
                        string[] SubstituteSplit = SubstituteVal.Split('¦');
                        foreach (string strVal in SubstituteSplit)
                        {
                            if (strVal != "")
                            {
                                clsEntityApprovalHierarchyTemp objEntity = new clsEntityApprovalHierarchyTemp();

                                string[] strValSplit = strVal.Split('‡');
                                objEntity.DesgId = Convert.ToInt32(strValSplit[0]);
                                objEntity.EmployeeId = Convert.ToInt32(strValSplit[1]);
                                objEntity.Count = Count;

                                objEntitySubstituteList.Add(objEntity);
                            }
                        }
                    }
                    Count++;
                }
                objEntityTrficVioltnDetilsListIns.Reverse();
                string strCanclDtlId = "";
                string[] strarrCancldtlIdsGrp = strCanclDtlId.Split(',');
                if (hiddenMainCanclDbId.Value != "" && hiddenMainCanclDbId.Value != null)
                {
                    strCanclDtlId = hiddenMainCanclDbId.Value;
                    strarrCancldtlIdsGrp = strCanclDtlId.Split(',');
                }
                foreach (string strDtlId in strarrCancldtlIdsGrp)
                {
                    if (strDtlId != "" && strDtlId != null)
                    {
                        int intDtlId = Convert.ToInt32(strDtlId);
                        clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                        objEntityDetails.TempId = Convert.ToInt32(strDtlId);
                        objEntityTrficVioltnDetilsListDele.Add(objEntityDetails);
                    }
                }
                int Cncl = 0;
                DataTable dt = objBussinesspasprt.ReadTemplatedtls(objentityPassport);
                if (dt.Rows.Count > 0 && dt.Rows[0]["HRCHY_CNCL_USR_ID"].ToString() != "")
                {
                    Cncl++;
                }
                if (Cncl == 0)
                {
                    objBussinesspasprt.updateHierarchyData(objentityPassport, objEntityTrficVioltnDetilsListIns, objEntityTrficVioltnDetilsListDele, objEntitySubstituteList);
                    
                    if (clickedButton.ID == "btnUpdate")
                    {
                        Response.Redirect("gen_Approval_Hierarchy_Temp.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                    }
                    else if (clickedButton.ID == "btnUpdateClose")
                    {
                        Response.Redirect("gen_Approval_Hierarchy_Temp_List.aspx?InsUpd=Upd");
                    }
                }
                else
                {
                    Response.Redirect("gen_Approval_Hierarchy_Temp_List.aspx?InsUpd=AlCancl");
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    public class clsTVData
    {
        public string DTLID { get; set; }
        public string LEVEL { get; set; }
        public string DESGID { get; set; }
        public string EMPID { get; set; }
        public string APPRVMANSTS { get; set; }
        public string SUBEMPSTS { get; set; }
        public string THRESMODE { get; set; }
        public string PERIOD { get; set; }
        public string APPRVPENSTS { get; set; }
        public string TTCSTS { get; set; }
        public string SMSSTS { get; set; }
        public string SYSSTS { get; set; }
        public string MAILSTS { get; set; }
        public string SKIPLVLSTS { get; set; }
        public string SUBSTUTVAL { get; set; }
        public string PARENTID { get; set; }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
            if (Session["CORPOFFICEID"] != null)
            {
                objentityPassport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objentityPassport.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objentityPassport.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            objentityPassport.Name = txtName.Value.Trim();
            if (cbxSts.Checked == true)
            {
                objentityPassport.Status_id = 1;
            }
            if (cbxMajorityApr.Checked == true)
            {
                objentityPassport.MajorityAprvSts = 1;
            }
            if (cbxSingleApproval.Checked == true)
            {
                objentityPassport.SingleApprvlSts = 1;
            }
            if (txtFromdate.Value.Trim() != "")
            {
                objentityPassport.StartDate = objCommon.textToDateTime(txtFromdate.Value.Trim());
            }
            if (txtTodate.Value.Trim() != "")
            {
                objentityPassport.EndDate = objCommon.textToDateTime(txtTodate.Value.Trim());
            }

            List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList = new List<clsEntityApprovalHierarchyTemp>();
            List<clsEntityApprovalHierarchyTemp> objEntitySubstituteList = new List<clsEntityApprovalHierarchyTemp>();

            string jsonData = HiddenFieldMainData.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");
            List<clsTVData> objTVDataList5 = new List<clsTVData>();
            objTVDataList5 = JsonConvert.DeserializeObject<List<clsTVData>>(i);
            if (HiddenFieldMainData.Value != "" && HiddenFieldMainData.Value != null)
            {
                int Count = 0;
                foreach (clsTVData objclsTVData in objTVDataList5)
                {
                    clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                    if (objclsTVData.EMPID != "-Select-" && objclsTVData.DESGID != "-Select-" && objclsTVData.PERIOD != "")
                    {
                        objEntityDetails.DesgId = Convert.ToInt32(objclsTVData.DESGID);
                        objEntityDetails.EmployeeId = Convert.ToInt32(objclsTVData.EMPID);
                        objEntityDetails.MajorityAprvSts = Convert.ToInt32(objclsTVData.APPRVMANSTS);
                        objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objclsTVData.SUBEMPSTS);
                        objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objclsTVData.THRESMODE);
                        objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objclsTVData.PERIOD);
                        objEntityDetails.AprvPendingSts = Convert.ToInt32(objclsTVData.APPRVPENSTS);
                        objEntityDetails.TtExceededSts = Convert.ToInt32(objclsTVData.TTCSTS);
                        objEntityDetails.SmsSts = Convert.ToInt32(objclsTVData.SMSSTS);
                        objEntityDetails.SystemSts = Convert.ToInt32(objclsTVData.SYSSTS);
                        objEntityDetails.MailSts = Convert.ToInt32(objclsTVData.MAILSTS);
                        objEntityDetails.SkipLvlSts = Convert.ToInt32(objclsTVData.SKIPLVLSTS);
                        objEntityDetails.Count = Count;

                        objEntityTrficVioltnDetilsList.Add(objEntityDetails);

                        string SubstituteVal = objclsTVData.SUBSTUTVAL;
                        string[] SubstituteSplit = SubstituteVal.Split('¦');
                        foreach (string strVal in SubstituteSplit)
                        {
                            if (strVal != "")
                            {
                                clsEntityApprovalHierarchyTemp objEntity = new clsEntityApprovalHierarchyTemp();

                                string[] strValSplit = strVal.Split('‡');
                                objEntity.DesgId = Convert.ToInt32(strValSplit[0]);
                                objEntity.EmployeeId = Convert.ToInt32(strValSplit[1]);
                                objEntity.Count = Count;

                                objEntitySubstituteList.Add(objEntity);
                            }
                        }
                    }
                    Count++;
                }

                objEntityTrficVioltnDetilsList.Reverse();
                objBussinesspasprt.insertHierarchyData(objentityPassport, objEntityTrficVioltnDetilsList, objEntitySubstituteList);

                if (clickedButton.ID == "btnAdd")
                {
                    Response.Redirect("gen_Approval_Hierarchy_Temp.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose")
                {
                    Response.Redirect("gen_Approval_Hierarchy_Temp_List.aspx?InsUpd=Ins");
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    public void Update(string id, int mode)
    {
        clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
        objentityPassport.TempId = Convert.ToInt32(id);
        DataTable dt = objBussinesspasprt.ReadTemplatedtls(objentityPassport);
        if (dt.Rows.Count > 0)
        {
            txtName.Value = dt.Rows[0]["HRCHY_NAME"].ToString();
            if (dt.Rows[0]["HRCHY_STATUS"].ToString() == "0")
            {
                cbxSts.Checked = false;
            }
            else
            {
                cbxSts.Checked = true;
            }
            if (dt.Rows[0]["HRCHY_MAJORITY_APRVL"].ToString() == "0")
            {
                cbxMajorityApr.Checked = false;
            }
            else
            {
                cbxMajorityApr.Checked = true;
            }
            if (dt.Rows[0]["HRCHY_SINGLE_APRVL"].ToString() == "0")
            {
                cbxSingleApproval.Checked = false;
            }
            else
            {
                cbxSingleApproval.Checked = true;
            }
            if (dt.Rows[0]["HRCHY_STRTDATE"].ToString() != "")
            {
                cbx_dte1.Checked = true;
                txtFromdate.Value = dt.Rows[0]["HRCHY_STRTDATE"].ToString();

            }
            if (dt.Rows[0]["HRCHY_ENDDATE"].ToString() != "")
            {
                cbx_dte.Checked = true;
                txtTodate.Value = dt.Rows[0]["HRCHY_ENDDATE"].ToString();
            }


            StringBuilder objstr = new StringBuilder();

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("DTLID", typeof(string));
            dtDetail.Columns.Add("LEVEL", typeof(string));
            dtDetail.Columns.Add("DESGID", typeof(string));
            dtDetail.Columns.Add("EMPID", typeof(string));
            dtDetail.Columns.Add("APPRVMANSTS", typeof(string));
            dtDetail.Columns.Add("SUBEMPSTS", typeof(string));
            dtDetail.Columns.Add("THRESMODE", typeof(string));
            dtDetail.Columns.Add("PERIOD", typeof(string));
            dtDetail.Columns.Add("APPRVPENSTS", typeof(string));
            dtDetail.Columns.Add("TTCSTS", typeof(string));
            dtDetail.Columns.Add("SMSSTS", typeof(string));
            dtDetail.Columns.Add("SYSSTS", typeof(string));
            dtDetail.Columns.Add("NAME", typeof(string));
            dtDetail.Columns.Add("DESGNAME", typeof(string));
            dtDetail.Columns.Add("MAILSTS", typeof(string));
            dtDetail.Columns.Add("SKIPLVLSTS", typeof(string));
            dtDetail.Columns.Add("SUBSTUTVAL", typeof(string));
            dtDetail.Columns.Add("PARENTID", typeof(string));

            int HrchyCount = 0;
            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {
                clsEntityApprovalHierarchyTemp objEntityDtl = new clsEntityApprovalHierarchyTemp();
                objEntityDtl.TempId = Convert.ToInt32(dt.Rows[intCount]["HRCHY_DTL_ID"].ToString());
                DataTable dtSubst = objBussinesspasprt.ReadSubstutEmptls(objEntityDtl);

                string SubstituteList = "";
                if (dtSubst.Rows.Count > 0)
                {
                    for (int intRow = 0; intRow < dtSubst.Rows.Count; intRow++)
                    {
                        if (SubstituteList == "")
                        {
                            SubstituteList = dtSubst.Rows[intRow]["DSGN_ID"].ToString() + "‡" + dtSubst.Rows[intRow]["USR_ID"].ToString() + "‡" + dtSubst.Rows[intRow]["DSGN_NAME"].ToString() + "‡" + dtSubst.Rows[intRow]["USR_NAME"].ToString() + "‡" + dtSubst.Rows[intRow]["HRCHY_SUBEMP_ID"].ToString();
                        }
                        else
                        {
                            SubstituteList = SubstituteList + "¦" + dtSubst.Rows[intRow]["DSGN_ID"].ToString() + "‡" + dtSubst.Rows[intRow]["USR_ID"].ToString() + "‡" + dtSubst.Rows[intRow]["DSGN_NAME"].ToString() + "‡" + dtSubst.Rows[intRow]["USR_NAME"].ToString() + "‡" + dtSubst.Rows[intRow]["HRCHY_SUBEMP_ID"].ToString();
                        }
                    }
                }

                DataRow drDtl = dtDetail.NewRow();
                drDtl["DTLID"] = dt.Rows[intCount]["HRCHY_DTL_ID"].ToString();
                drDtl["LEVEL"] = dt.Rows[intCount]["HRCHY_LEVEL"].ToString();
                drDtl["DESGID"] = dt.Rows[intCount]["DSGN_ID"].ToString();
                drDtl["EMPID"] = dt.Rows[intCount]["USR_ID"].ToString();
                drDtl["APPRVMANSTS"] = dt.Rows[intCount]["HRCHY_APRVL_MNDTRY_STS"].ToString();
                drDtl["SUBEMPSTS"] = dt.Rows[intCount]["HRCHY_SUBSTUTE_STS"].ToString();
                drDtl["THRESMODE"] = dt.Rows[intCount]["HRCHY_THRSHOLD_PRD_STS"].ToString();
                drDtl["PERIOD"] = dt.Rows[intCount]["HRCHY_THRSHOLD_PERIOD"].ToString();
                drDtl["APPRVPENSTS"] = dt.Rows[intCount]["HRCHY_APRVL_PENDING_MSG_STS"].ToString();
                drDtl["TTCSTS"] = dt.Rows[intCount]["HRCHY_TTC_EXCD_MSG_STS"].ToString();
                drDtl["SMSSTS"] = dt.Rows[intCount]["HRCHY_SMS_MSG_STS"].ToString();
                drDtl["SYSSTS"] = dt.Rows[intCount]["HRCHY_DASHBRD_MSG_STS"].ToString();
                drDtl["NAME"] = dt.Rows[intCount]["USR_NAME"].ToString();
                drDtl["DESGNAME"] = dt.Rows[intCount]["DSGN_NAME"].ToString();

                drDtl["MAILSTS"] = dt.Rows[intCount]["HRCHY_MAIL_MSG_STS"].ToString();
                drDtl["SKIPLVLSTS"] = dt.Rows[intCount]["HRCHY_SKIP_LEVEL_STS"].ToString();
                drDtl["SUBSTUTVAL"] = SubstituteList;
                drDtl["PARENTID"] = dt.Rows[intCount]["HRCHY_PARENT_DTL_ID"].ToString();

                dtDetail.Rows.Add(drDtl);

                objstr.Append("<li>");
                objstr.Append("<span id=\"span_" + dt.Rows[intCount]["HRCHY_DTL_ID"].ToString() + "\" class=\"Chkcls\"><i class=\"fa fa-black-tie\"></i>" + dt.Rows[intCount]["USR_NAME"].ToString() + "</span>");
                objstr.Append("<button onclick=\"return FuctionOrganize('" + dt.Rows[intCount]["HRCHY_DTL_ID"].ToString() + "','" + dt.Rows[intCount]["HRCHY_LEVEL"].ToString() + "','" + dt.Rows[intCount]["USR_NAME"].ToString() + "');\" class=\"edt_1 edt_1_0 tablinks notv\"><i class=\"fa fa-edit\"></i></button>");
                objstr.Append(bindSubmenu(dt.Rows[intCount]["HRCHY_DTL_ID"].ToString()));
                objstr.Append("</li>");


                clsEntityApprovalHierarchyTemp objEntity = new clsEntityApprovalHierarchyTemp();
                objEntity.TempId = Convert.ToInt32(dt.Rows[intCount]["HRCHY_DTL_ID"].ToString());
                DataTable dtSub = objBussinesspasprt.ReadSubtableDtls(objEntity);

                if (dtSub.Rows.Count > 0)
                {
                    HrchyCount++;
                }
            }

            if (HrchyCount > 0)
            {
                cbxSingleApproval.Checked = false;
                cbxSingleApproval.Disabled = true;
            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            HiddenEdit.Value = strJson;
            myTab1.InnerHtml = objstr.ToString();
        }
    }
    public string bindSubmenu(string DtlId)
    {
        StringBuilder objstr = new StringBuilder();
        clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
        clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
        objentityPassport.TempId = Convert.ToInt32(DtlId);
        DataTable dt = objBussinesspasprt.ReadSubtableDtls(objentityPassport);
        if (dt.Rows.Count > 0)
        {
            objstr.Append("<ul>");
            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {
                objstr.Append("<li>");
                objstr.Append("<span id=\"span_" + dt.Rows[intCount]["HRCHY_DTL_ID"].ToString() + "\" class=\"Chkcls\"><i class=\"fa fa-black-tie\"></i>" + dt.Rows[intCount]["USR_NAME"].ToString() + "</span>");
                objstr.Append("<button onclick=\"return FuctionOrganize('" + dt.Rows[intCount]["HRCHY_DTL_ID"].ToString() + "','" + dt.Rows[intCount]["HRCHY_LEVEL"].ToString() + "','" + dt.Rows[intCount]["USR_NAME"].ToString() + "');\" class=\"edt_1 edt_1_0 tablinks notv\"><i class=\"fa fa-edit\"></i></button>");
                objstr.Append(bindSubmenu(dt.Rows[intCount]["HRCHY_DTL_ID"].ToString()));
                objstr.Append("</li>");
            }
            objstr.Append("</ul>");
        }
        return objstr.ToString();
    }
    [WebMethod]
    public static string[] ReadSubtableDtls(string orgID, string corptID, string DtlId)
    {
        string[] arr = new string[2];
        try
        {
            clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
            clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
            objentityPassport.Corporate_id = Convert.ToInt32(corptID);
            objentityPassport.Organisation_id = Convert.ToInt32(orgID);
            objentityPassport.TempId = Convert.ToInt32(DtlId);
            objentityPassport.Mode = 1;
            DataTable dt = objBussinesspasprt.ReadSubtableDtls(objentityPassport);
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("DTLID", typeof(string));
            dtDetail.Columns.Add("LEVEL", typeof(string));
            dtDetail.Columns.Add("DESGID", typeof(string));
            dtDetail.Columns.Add("EMPID", typeof(string));
            dtDetail.Columns.Add("APPRVMANSTS", typeof(string));
            dtDetail.Columns.Add("SUBEMPSTS", typeof(string));
            dtDetail.Columns.Add("THRESMODE", typeof(string));
            dtDetail.Columns.Add("PERIOD", typeof(string));
            dtDetail.Columns.Add("APPRVPENSTS", typeof(string));
            dtDetail.Columns.Add("TTCSTS", typeof(string));
            dtDetail.Columns.Add("SMSSTS", typeof(string));
            dtDetail.Columns.Add("SYSSTS", typeof(string));
            dtDetail.Columns.Add("SUBORDNUM", typeof(string));
            dtDetail.Columns.Add("NAME", typeof(string));
            dtDetail.Columns.Add("DESGNAME", typeof(string));
            dtDetail.Columns.Add("MAILSTS", typeof(string));
            dtDetail.Columns.Add("SKIPLVLSTS", typeof(string));
            dtDetail.Columns.Add("SUBSTUTVAL", typeof(string));
            dtDetail.Columns.Add("PARENTID", typeof(string));

            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {
                clsEntityApprovalHierarchyTemp objEntityDtl = new clsEntityApprovalHierarchyTemp();
                objEntityDtl.TempId = Convert.ToInt32(dt.Rows[intCount]["HRCHY_DTL_ID"].ToString());
                DataTable dtSubst = objBussinesspasprt.ReadSubstutEmptls(objEntityDtl);

                string SubstituteList = "";
                if (dtSubst.Rows.Count > 0)
                {
                    for (int intRow = 0; intRow < dtSubst.Rows.Count; intRow++)
                    {
                        if (SubstituteList == "")
                        {
                            SubstituteList = dtSubst.Rows[intRow]["DSGN_ID"].ToString() + "‡" + dtSubst.Rows[intRow]["USR_ID"].ToString() + "‡" + dtSubst.Rows[intRow]["DSGN_NAME"].ToString() + "‡" + dtSubst.Rows[intRow]["USR_NAME"].ToString() + "‡" + dtSubst.Rows[intRow]["HRCHY_SUBEMP_ID"].ToString();
                        }
                        else
                        {
                            SubstituteList = SubstituteList + "¦" + dtSubst.Rows[intRow]["DSGN_ID"].ToString() + "‡" + dtSubst.Rows[intRow]["USR_ID"].ToString() + "‡" + dtSubst.Rows[intRow]["DSGN_NAME"].ToString() + "‡" + dtSubst.Rows[intRow]["USR_NAME"].ToString() + "‡" + dtSubst.Rows[intRow]["HRCHY_SUBEMP_ID"].ToString();
                        }
                    }
                }

                DataRow drDtl = dtDetail.NewRow();
                drDtl["DTLID"] = dt.Rows[intCount]["HRCHY_DTL_ID"].ToString();
                drDtl["LEVEL"] = dt.Rows[intCount]["HRCHY_LEVEL"].ToString();
                drDtl["DESGID"] = dt.Rows[intCount]["DSGN_ID"].ToString();
                drDtl["EMPID"] = dt.Rows[intCount]["USR_ID"].ToString();
                drDtl["APPRVMANSTS"] = dt.Rows[intCount]["HRCHY_APRVL_MNDTRY_STS"].ToString();
                drDtl["SUBEMPSTS"] = dt.Rows[intCount]["HRCHY_SUBSTUTE_STS"].ToString();
                drDtl["THRESMODE"] = dt.Rows[intCount]["HRCHY_THRSHOLD_PRD_STS"].ToString();
                drDtl["PERIOD"] = dt.Rows[intCount]["HRCHY_THRSHOLD_PERIOD"].ToString();
                drDtl["APPRVPENSTS"] = dt.Rows[intCount]["HRCHY_APRVL_PENDING_MSG_STS"].ToString();
                drDtl["TTCSTS"] = dt.Rows[intCount]["HRCHY_TTC_EXCD_MSG_STS"].ToString();
                drDtl["SMSSTS"] = dt.Rows[intCount]["HRCHY_SMS_MSG_STS"].ToString();
                drDtl["SYSSTS"] = dt.Rows[intCount]["HRCHY_DASHBRD_MSG_STS"].ToString();
                drDtl["SUBORDNUM"] = dt.Rows[intCount]["SUBORD_NUM"].ToString();
                drDtl["NAME"] = dt.Rows[intCount]["USR_NAME"].ToString();
                drDtl["DESGNAME"] = dt.Rows[intCount]["DSGN_NAME"].ToString();

                drDtl["MAILSTS"] = dt.Rows[intCount]["HRCHY_MAIL_MSG_STS"].ToString();
                drDtl["SKIPLVLSTS"] = dt.Rows[intCount]["HRCHY_SKIP_LEVEL_STS"].ToString();
                drDtl["SUBSTUTVAL"] = SubstituteList;
                drDtl["PARENTID"] = dt.Rows[intCount]["HRCHY_PARENT_DTL_ID"].ToString();

                dtDetail.Rows.Add(drDtl);
            }
            if (dt.Rows.Count > 0)
            {
                arr[0] = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            }

            arr[1] = dt.Rows.Count.ToString();
        }
        catch (Exception ex)
        {
        }
        return arr;
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
     protected void btnUpdateS_Click(object sender, EventArgs e)
     {
         try
         {
             int intUserId = 0;
             Button clickedButton = sender as Button;
             clsCommonLibrary objCommon = new clsCommonLibrary();
             if (Session["CORPOFFICEID"] != null)
             {
             }
             else if (Session["CORPOFFICEID"] == null)
             {
                 Response.Redirect("/Default.aspx");
             }
             if (Session["ORGID"] != null)
             {
             }
             else if (Session["ORGID"] == null)
             {
                 Response.Redirect("/Default.aspx");
             }
             if (Session["USERID"] != null)
             {
                 intUserId = Convert.ToInt32(Session["USERID"]);
             }
             else if (Session["USERID"] == null)
             {
                 Response.Redirect("/Default.aspx");
             }

             clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
             objentityPassport.TempId = Convert.ToInt32(HiddenFieldAprvlHierarchyId.Value);

             clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
             List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListIns = new List<clsEntityApprovalHierarchyTemp>();
             List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele = new List<clsEntityApprovalHierarchyTemp>();
             List<clsEntityApprovalHierarchyTemp> objEntitySubstituteList = new List<clsEntityApprovalHierarchyTemp>();

             string jsonData = HiddenFieldSubData.Value;
             string c = jsonData.Replace("\"{", "\\{");
             string d = c.Replace("\\n", "\r\n");
             string g = d.Replace("\\", "");
             string h = g.Replace("}\"]", "}]");
             string i = h.Replace("}\",", "},");
             List<clsTVData> objTVDataList5 = new List<clsTVData>();
             objTVDataList5 = JsonConvert.DeserializeObject<List<clsTVData>>(i);
             if (HiddenFieldSubData.Value != "" && HiddenFieldSubData.Value != null)
             {
                 int Count = 0;
                 foreach (clsTVData objclsTVData in objTVDataList5)
                 {
                     clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                     if (objclsTVData.EMPID != "-Select-" && objclsTVData.DESGID != "-Select-" && objclsTVData.PERIOD != "")
                     {
                         objEntityDetails.Status_id = Convert.ToInt32(HiddenFieldAprvlHierarchyId.Value);
                         if (objclsTVData.PARENTID != "")
                         {
                             objEntityDetails.ParentId = Convert.ToInt32(objclsTVData.PARENTID);
                         }
                         objEntityDetails.Level = Convert.ToInt32(objclsTVData.LEVEL);
                         objEntityDetails.User_Id = intUserId;


                         objEntityDetails.DesgId = Convert.ToInt32(objclsTVData.DESGID);
                         objEntityDetails.EmployeeId = Convert.ToInt32(objclsTVData.EMPID);
                         objEntityDetails.MajorityAprvSts = Convert.ToInt32(objclsTVData.APPRVMANSTS);
                         objEntityDetails.SubstituteEmpSts = Convert.ToInt32(objclsTVData.SUBEMPSTS);
                         objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(objclsTVData.THRESMODE);
                         objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(objclsTVData.PERIOD);
                         objEntityDetails.AprvPendingSts = Convert.ToInt32(objclsTVData.APPRVPENSTS);
                         objEntityDetails.TtExceededSts = Convert.ToInt32(objclsTVData.TTCSTS);
                         objEntityDetails.SmsSts = Convert.ToInt32(objclsTVData.SMSSTS);
                         objEntityDetails.SystemSts = Convert.ToInt32(objclsTVData.SYSSTS);
                         objEntityDetails.MailSts = Convert.ToInt32(objclsTVData.MAILSTS);
                         objEntityDetails.SkipLvlSts = Convert.ToInt32(objclsTVData.SKIPLVLSTS);
                         objEntityDetails.Count = Count;

                         if (objclsTVData.DTLID != "" && objclsTVData.DTLID != "null" && objclsTVData.DTLID != null)
                         {
                             objEntityDetails.TempId = Convert.ToInt32(objclsTVData.DTLID);
                         }
                         objEntityTrficVioltnDetilsListIns.Add(objEntityDetails);


                         string SubstituteVal = objclsTVData.SUBSTUTVAL;
                         string[] SubstituteSplit = SubstituteVal.Split('¦');
                         foreach (string strVal in SubstituteSplit)
                         {
                             if (strVal != "")
                             {
                                 clsEntityApprovalHierarchyTemp objEntity = new clsEntityApprovalHierarchyTemp();

                                 string[] strValSplit = strVal.Split('‡');
                                 objEntity.DesgId = Convert.ToInt32(strValSplit[0]);
                                 objEntity.EmployeeId = Convert.ToInt32(strValSplit[1]);
                                 objEntity.Count = Count;

                                 objEntitySubstituteList.Add(objEntity);
                             }
                         }
                     }
                     Count++;
                 }
                 objEntityTrficVioltnDetilsListIns.Reverse();
                 string strCanclDtlId = "";
                 string[] strarrCancldtlIdsGrp = strCanclDtlId.Split(',');
                 if (hiddenSubCanclDbId.Value != "" && hiddenSubCanclDbId.Value != null)
                 {
                     strCanclDtlId = hiddenSubCanclDbId.Value;
                     strarrCancldtlIdsGrp = strCanclDtlId.Split(',');
                 }
                 foreach (string strDtlId in strarrCancldtlIdsGrp)
                 {
                     if (strDtlId != "" && strDtlId != null)
                     {
                         int intDtlId = Convert.ToInt32(strDtlId);
                         clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
                         objEntityDetails.TempId = Convert.ToInt32(strDtlId);
                         objEntityTrficVioltnDetilsListDele.Add(objEntityDetails);
                     }
                 }

                 int Cncl = 0;
                 DataTable dt = objBussinesspasprt.ReadTemplatedtls(objentityPassport);
                 if (dt.Rows.Count > 0 && dt.Rows[0]["HRCHY_CNCL_USR_ID"].ToString() != "")
                 {
                     Cncl++;
                 }
                 if (Cncl == 0)
                 {
                     objBussinesspasprt.updateHierarchyDataSub(objEntityTrficVioltnDetilsListIns, objEntityTrficVioltnDetilsListDele, objEntitySubstituteList);

                     if (clickedButton.ID == "btnUpdateS")
                     {
                         Response.Redirect("gen_Approval_Hierarchy_Temp.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                     }
                 }
                 else
                 {
                     Response.Redirect("gen_Approval_Hierarchy_Temp_List.aspx?InsUpd=AlCancl");
                 }

             }
         }
         catch (Exception ex)
         {
         }
     }

     [WebMethod]
     public static string SaveDetails(string CorpId, string OrgId, string UserId, string HrchyId, string HrchyName, string StrtDate, string EndDate, string MajrtyApprvl, string SingleApprvl,string Status, string DTLID, string LEVEL, string DESGID, string EMPID, string APPRVMANSTS, string SUBEMPSTS,
         string THRESMODE, string PERIOD, string APPRVPENSTS, string TTCSTS, string SMSSTS, string SYSSTS, string MAILSTS, string SKIPLVLSTS, string SUBSTUTVAL, string PARENTID)
     {
         string strReturn = "success";
         try
         {
             clsCommonLibrary objCommon = new clsCommonLibrary();
             clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
             clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();

             objentityPassport.User_Id = Convert.ToInt32(UserId);
             objentityPassport.TempId = Convert.ToInt32(HrchyId);

             if (HrchyId == "")
             {
                 objentityPassport.Name = HrchyName;
                 objentityPassport.Status_id = Convert.ToInt32(Status);
                 objentityPassport.MajorityAprvSts = Convert.ToInt32(MajrtyApprvl);
                 objentityPassport.SingleApprvlSts = Convert.ToInt32(SingleApprvl);
                 if (StrtDate != "")
                 {
                     objentityPassport.StartDate = objCommon.textToDateTime(StrtDate);
                 }
                 if (EndDate != "")
                 {
                     objentityPassport.EndDate = objCommon.textToDateTime(EndDate);
                 }
             }
             else
             {
                 DataTable dt = objBussinesspasprt.ReadTemplatedtls(objentityPassport);
                 if (dt.Rows.Count > 0)
                 {
                     objentityPassport.Name = dt.Rows[0]["HRCHY_NAME"].ToString();
                     objentityPassport.Status_id = Convert.ToInt32(dt.Rows[0]["HRCHY_STATUS"].ToString());
                     objentityPassport.MajorityAprvSts = Convert.ToInt32(dt.Rows[0]["HRCHY_MAJORITY_APRVL"].ToString());
                     objentityPassport.SingleApprvlSts = Convert.ToInt32(dt.Rows[0]["HRCHY_SINGLE_APRVL"].ToString());
                     if (dt.Rows[0]["HRCHY_STRTDATE"].ToString() != "")
                     {
                         objentityPassport.StartDate = objCommon.textToDateTime(dt.Rows[0]["HRCHY_STRTDATE"].ToString());
                     }
                     if (dt.Rows[0]["HRCHY_ENDDATE"].ToString() != "")
                     {
                         objentityPassport.EndDate = objCommon.textToDateTime(dt.Rows[0]["HRCHY_ENDDATE"].ToString());
                     }
                 }
             }

             List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListIns = new List<clsEntityApprovalHierarchyTemp>();
             List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele = new List<clsEntityApprovalHierarchyTemp>();
             List<clsEntityApprovalHierarchyTemp> objEntitySubstituteList = new List<clsEntityApprovalHierarchyTemp>();


             clsEntityApprovalHierarchyTemp objEntityDetails = new clsEntityApprovalHierarchyTemp();
             if (EMPID != "-Select-" && DESGID != "-Select-" && PERIOD != "")
             {
                 objEntityDetails.Status_id = Convert.ToInt32(HrchyId);
                 objEntityDetails.ParentId = Convert.ToInt32(PARENTID);
                 objEntityDetails.Level = Convert.ToInt32(LEVEL);
                 objEntityDetails.User_Id = Convert.ToInt32(UserId);


                 objEntityDetails.DesgId = Convert.ToInt32(DESGID);
                 objEntityDetails.EmployeeId = Convert.ToInt32(EMPID);
                 objEntityDetails.MajorityAprvSts = Convert.ToInt32(APPRVMANSTS);
                 objEntityDetails.SubstituteEmpSts = Convert.ToInt32(SUBEMPSTS);
                 objEntityDetails.ThresholdPeriodMode = Convert.ToInt32(THRESMODE);
                 objEntityDetails.ThresholdPeriodDays = Convert.ToInt32(PERIOD);
                 objEntityDetails.AprvPendingSts = Convert.ToInt32(APPRVPENSTS);
                 objEntityDetails.TtExceededSts = Convert.ToInt32(TTCSTS);
                 objEntityDetails.SmsSts = Convert.ToInt32(SMSSTS);
                 objEntityDetails.SystemSts = Convert.ToInt32(SYSSTS);
                 objEntityDetails.MailSts = Convert.ToInt32(MAILSTS);
                 objEntityDetails.SkipLvlSts = Convert.ToInt32(SKIPLVLSTS);

                 if (DTLID != "" && DTLID != "null" && DTLID != null)
                 {
                     objEntityDetails.TempId = Convert.ToInt32(DTLID);
                 }
                 objEntityTrficVioltnDetilsListIns.Add(objEntityDetails);


                 string SubstituteVal = SUBSTUTVAL;
                 string[] SubstituteSplit = SubstituteVal.Split('¦');
                 foreach (string strVal in SubstituteSplit)
                 {
                     if (strVal != "")
                     {
                         clsEntityApprovalHierarchyTemp objEntity = new clsEntityApprovalHierarchyTemp();

                         string[] strValSplit = strVal.Split('‡');
                         objEntity.DesgId = Convert.ToInt32(strValSplit[0]);
                         objEntity.EmployeeId = Convert.ToInt32(strValSplit[1]);

                         objEntitySubstituteList.Add(objEntity);
                     }
                 }
                 objEntityTrficVioltnDetilsListIns.Reverse();

                 if (LEVEL == "0")
                 {
                     objBussinesspasprt.updateHierarchyData(objentityPassport, objEntityTrficVioltnDetilsListIns, objEntityTrficVioltnDetilsListDele, objEntitySubstituteList);
                 }
                 else
                 {
                     objBussinesspasprt.updateHierarchyDataSub(objEntityTrficVioltnDetilsListIns, objEntityTrficVioltnDetilsListDele, objEntitySubstituteList);
                 }

             }
         }
         catch (Exception ex)
         {
             strReturn = "error";
         }
         return strReturn;
     }

     [WebMethod]
     public static string LoadHierarchy(string HrchyId)
     {
         Master_gen_Approval_Hierarchy_temp_gen_Approval_Hierarchy_Temp objMaster = new Master_gen_Approval_Hierarchy_temp_gen_Approval_Hierarchy_Temp();

         clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
         clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
         objentityPassport.TempId = Convert.ToInt32(HrchyId);
         DataTable dt = objBussinesspasprt.ReadTemplatedtls(objentityPassport);

         StringBuilder objstr = new StringBuilder();
         if (dt.Rows.Count > 0)
         {
             for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
             {
                 objstr.Append("<li>");
                 objstr.Append("<span id=\"span_" + dt.Rows[intCount]["HRCHY_DTL_ID"].ToString() + "\" class=\"Chkcls\"><i class=\"fa fa-black-tie\"></i>" + dt.Rows[intCount]["USR_NAME"].ToString() + "</span>");
                 objstr.Append("<button onclick=\"return FuctionOrganize('" + dt.Rows[intCount]["HRCHY_DTL_ID"].ToString() + "','" + dt.Rows[intCount]["HRCHY_LEVEL"].ToString() + "','" + dt.Rows[intCount]["USR_NAME"].ToString() + "');\" class=\"edt_1 edt_1_0 tablinks notv\"><i class=\"fa fa-edit\"></i></button>");
                 objstr.Append(objMaster.bindSubmenu(dt.Rows[intCount]["HRCHY_DTL_ID"].ToString()));
                 objstr.Append("</li>");
             }
         }
         return objstr.ToString();
     }

     [WebMethod]
     public static string CheckLowerHrchy(string HrchyId)
     {
         clsEntityApprovalHierarchyTemp objentityPassport = new clsEntityApprovalHierarchyTemp();
         clsBusinessLayerApprovalHierarchyTemp objBussinesspasprt = new clsBusinessLayerApprovalHierarchyTemp();
         objentityPassport.TempId = Convert.ToInt32(HrchyId);
         DataTable dt = objBussinesspasprt.ReadTemplatedtls(objentityPassport);

         int HrchyCount = 0;
         for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
         {
             clsEntityApprovalHierarchyTemp objEntity = new clsEntityApprovalHierarchyTemp();

             objEntity.TempId = Convert.ToInt32(dt.Rows[intCount]["HRCHY_DTL_ID"].ToString());
             DataTable dtSub = objBussinesspasprt.ReadSubtableDtls(objEntity);

             if (dtSub.Rows.Count > 0)
             {
                 HrchyCount++;
             }
         }
         return HrchyCount.ToString();
     }

}