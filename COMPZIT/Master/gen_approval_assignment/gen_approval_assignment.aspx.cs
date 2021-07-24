using System;  
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DL_Compzit.DataLayer_PMS;
using BL_Compzit.BusinessLayer_PMS;
using EL_Compzit.EntityLayer_PMS;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.ComponentModel;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Web.Services;
using System.Net;
using System.Globalization;


public partial class Master_gen_approval_assignment_gen_approval_assignment : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            Read_Designation();
          
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableConfirm = 0, intEnableReopne = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intCorpId = 0;

            int corpid = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                corpid = intCorpId;

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int orgid = 0;
            if (Session["ORGID"] == null)
            {
                orgid = Convert.ToInt32(Session["ORGID"].ToString());
                Response.Redirect("/Default.aspx");
            }
            if (Request.QueryString["Id"] != null)
            {
                HiddenCancel.Value = Request.QueryString["Id"].ToString();
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                HiddenMaincanceldl.Value = "1";

                btnCancel.Visible = true;
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;
                btnClear.Visible = false;

                btncancel2.Visible = true;
                btnsave.Visible = false;
                btnsaveclose.Visible = false;
                btnupdate2.Visible = true;
                btnupdateclose2.Visible = true;
                btnclear2.Visible = false;

                Update(strId, 0);
                HiddenFieldView.Value = "1";
                HiddenApprovalId.Value = strId;

                lblEntry.Text = "Edit Approval Assignment";
            }
            else
            {
                lblEntry.Text = "Add Approval Assignment";
            }

            if (Request.QueryString["InsUpd"] != null)
            {

                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                }
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpd", "SuccessUpd();", true);
                }
                else if (strInsUpd == "Cnfm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCnfm", "SuccessCnfm();", true);
                }
                else if (strInsUpd == "Reopen")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopen", "SuccessReopen();", true);
                }
            }
        }
    }


    [WebMethod]
    public static string[] ReadDocDdl(string strLikeEmployee,int orgID, int corptID,string desgid)
    {
        List<string> Documents = new List<string>();
        clsEntityApprovalAssign objentityPassport = new clsEntityApprovalAssign();
        clsBusinessLayerApprovalAssign objBussinesspasprt = new clsBusinessLayerApprovalAssign();
        objentityPassport.Corporate_id = corptID;
        objentityPassport.Organisation_id = orgID;
        objentityPassport.desgid = Convert.ToInt32(desgid);
        DataTable doc = objBussinesspasprt.Readwrkflw(strLikeEmployee.ToUpper(), objentityPassport);
       
      
        for (int intRowCount = 0; intRowCount < doc.Rows.Count; intRowCount++)
        {
            Documents.Add(string.Format("{0}<->{1}", doc.Rows[intRowCount]["WRKFLW_ID"].ToString(), doc.Rows[intRowCount]["WRKFLW_NAME"].ToString()));
        }
        return Documents.ToArray();
    }


    [WebMethod]
    public static string[] ReadAssDdl(string strLikeEmployee, int orgID, int corptID)
    {
        List<string> Assign = new List<string>();
        clsEntityApprovalAssign objentityPassport = new clsEntityApprovalAssign();
        clsBusinessLayerApprovalAssign objBussinesspasprt = new clsBusinessLayerApprovalAssign();
        objentityPassport.Corporate_id = corptID;
        objentityPassport.Organisation_id = orgID;
        DataTable doc = objBussinesspasprt.Readapproval(strLikeEmployee.ToUpper(), objentityPassport);
    
        for (int intRowCount = 0; intRowCount < doc.Rows.Count; intRowCount++)
        {
            Assign.Add(string.Format("{0}<->{1}", doc.Rows[intRowCount]["APRVLSET_ID"].ToString(), doc.Rows[intRowCount]["APRVLSET_NAME"].ToString()));
        }
        return Assign.ToArray();
    }



    [WebMethod]
    public static string CancelReason(string strasid, string DtlId, string strUserID, string strOrgIdID, string strCorpID, string doc, string appro, string sdate, string edate, string desgid)
    {

        string arr = "";
        try
        {
            clsEntityApprovalAssign objEntityAcco = new clsEntityApprovalAssign();
            clsBusinessLayerApprovalAssign objEntityApproval = new clsBusinessLayerApprovalAssign();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            string id = strasid;
            objEntityAcco.tempid = Convert.ToInt32(DtlId);
            objEntityAcco.Status_id = Convert.ToInt32(id);
            objEntityAcco.userid = Convert.ToInt32(strUserID);

            objEntityApproval.cancelApprovalAss(objEntityAcco);

            objEntityAcco.Organisation_id = Convert.ToInt32(strOrgIdID);
            objEntityAcco.Corporate_id = Convert.ToInt32(strCorpID);
            DataTable dt = objEntityApproval.ReadAppAssignment(objEntityAcco);
            if (dt.Rows.Count > 0)
            {
                arr = "successcncl";
            }
            else
            {
                arr = "successcnclfull";
            }
        }
        catch
        {
            arr = "failed";
        }

        return arr;
    }


    public void Read_Designation()
    {
        int intUserId = 0;

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
        int intorgid = 0;
        if (Session["ORGID"] != null)
        {
            intorgid = Convert.ToInt32(Session["ORGID"].ToString());

        }
        if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsEntityApprovalAssign objentityPassport = new clsEntityApprovalAssign();
        clsBusinessLayerApprovalAssign objBussinesspasprt = new clsBusinessLayerApprovalAssign();

        objentityPassport.Corporate_id = intCorpId;
        objentityPassport.Organisation_id = intorgid;
        DataTable doc = objBussinesspasprt.ReadDesgDDL(objentityPassport);

        ddldesg.Items.Clear();
        ddldesg.DataSource = doc;
        ddldesg.DataValueField = "DSGN_ID";
        ddldesg.DataTextField = "DSGN_NAME";
        ddldesg.DataBind();
        ddldesg.Items.Insert(0, "--SELECT DESIGNATION--");

    }
   
    public class clsTVData
    {
        public string CON { get; set; }
        public string DTLID { get; set; }
        public string DOC { get; set; }
        public string APPRO { get; set; }
        public string SDATE { get; set; }
        public string EDATE { get; set; }

    }


    [WebMethod]
    public static string updatewrkflwdtl(string DtlId, string sdte, string edte, string ddlwrk)
    {
        string arr = "";
        try
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityApprovalAssign objentityPass = new clsEntityApprovalAssign();
            clsBusinessLayerApprovalAssign objEntityApproval = new clsBusinessLayerApprovalAssign();
            objentityPass.tempid = Convert.ToInt32(DtlId);
            objentityPass.Status_id = Convert.ToInt32(ddlwrk);
            objentityPass.StartDate = objCommon.textToDateTime(sdte);
            objentityPass.EndDate = objCommon.textToDateTime(edte);
            objEntityApproval.updatewrkflwftl(objentityPass);
        }
        catch (Exception ex)
        {
        }
        return arr;
    }

    public void Update(string id, int mode)
    {
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intorgid = 0;
        if (Session["ORGID"] != null)
        {
            intorgid = Convert.ToInt32(Session["ORGID"].ToString());

        }
        if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        HiddenMaincanceldl.Value = "1";
        clsEntityApprovalAssign objEntityAcco = new clsEntityApprovalAssign();
        clsBusinessLayerApprovalAssign objEntityApproval = new clsBusinessLayerApprovalAssign();
        objEntityAcco.tempid = Convert.ToInt32(id);
        objEntityAcco.Organisation_id = intorgid;
        objEntityAcco.Corporate_id = intCorpId;

        DataTable dt = objEntityApproval.ReadAppAssignment(objEntityAcco);

        if (dt.Rows.Count > 0)
        {
            HiddenDesgid.Value = dt.Rows[0]["DSGN_ID"].ToString();
            ddldesg.Items.Insert(0, new ListItem(dt.Rows[0]["DSGN_NAME"].ToString(), dt.Rows[0]["DSGN_ID"].ToString()));
            ddldesg.Enabled = false;
        }
        HiddenEditlist.Value = "1";
        StringBuilder objstr = new StringBuilder();

        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("DOC", typeof(string));
        dtDetail.Columns.Add("WRKNAME", typeof(string));
        dtDetail.Columns.Add("APPRO", typeof(string));
        dtDetail.Columns.Add("APPNAME", typeof(string));
        dtDetail.Columns.Add("SDATE", typeof(string));
        dtDetail.Columns.Add("EDATE", typeof(string));
        dtDetail.Columns.Add("DTLID", typeof(string));
        dtDetail.Columns.Add("CON", typeof(string));

        for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
        {
            DataRow drDtl = dtDetail.NewRow();
            drDtl["DOC"] = dt.Rows[intCount]["WRKFLW_ID"].ToString();
            drDtl["WRKNAME"] = dt.Rows[intCount]["WRKFLW_NAME"].ToString();
            drDtl["APPRO"] = dt.Rows[intCount]["APRVLSET_ID"].ToString();
            drDtl["APPNAME"] = dt.Rows[intCount]["APRVLSET_NAME"].ToString();
            if (dt.Rows[intCount]["APRVLASGN_STRTDATE"].ToString() == "")
            {
                drDtl["SDATE"] = dt.Rows[intCount]["APRVLASGN_STRTDATE"].ToString();
            }
            else
            {
                DateTime dd = DateTime.Parse(dt.Rows[intCount]["APRVLASGN_STRTDATE"].ToString());
                drDtl["SDATE"] = dd.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            if (dt.Rows[intCount]["APRVLASGN_ENDDATE"].ToString() == "")
            {
                drDtl["EDATE"] = dt.Rows[intCount]["APRVLASGN_ENDDATE"].ToString();
            }
            else
            {
                DateTime dd = DateTime.Parse(dt.Rows[intCount]["APRVLASGN_ENDDATE"].ToString());
                drDtl["EDATE"] = dd.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            drDtl["DTLID"] = dt.Rows[intCount]["APRVLASGN_DTL_ID"].ToString();
            drDtl["CON"] = dt.Rows[intCount]["APRVLASGN_CONSOLE"].ToString();

            dtDetail.Rows.Add(drDtl);
        }


        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        HiddenEdit.Value = strJson;
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




    public void Msgbox(String s)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + s + "');", true);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityApprovalAssign objentityPassport = new clsEntityApprovalAssign();
            clsEntityApprovalAssign objentityPass = new clsEntityApprovalAssign();
            clsBusinessLayerApprovalAssign objEntityApproval = new clsBusinessLayerApprovalAssign();
            if (Session["CORPOFFICEID"] != null)
            {
                objentityPassport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
                objentityPass.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objentityPassport.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                objentityPass.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objentityPassport.userid = Convert.ToInt32(Session["USERID"]);
                objentityPass.userid = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            objentityPass.desgid = Convert.ToInt32(ddldesg.SelectedItem.Value);
            DateTime dd = DateTime.Parse(DateTime.Now.ToShortDateString());
            string dat = dd.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            if (dat.Trim() != "")
            {
                objentityPass.cDate = objCommon.textToDateTime(dat.Trim());
            }
            List<clsEntityApprovalAssign> objEntityTrficVioltnDetilsList = new List<clsEntityApprovalAssign>();
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
                foreach (clsTVData objclsTVData in objTVDataList5)
                {
                    clsEntityApprovalAssign objEntityDetails = new clsEntityApprovalAssign();

                    objEntityDetails.wrkflwid = Convert.ToInt32(objclsTVData.DOC);
                    objEntityDetails.apprsetid = Convert.ToInt32(objclsTVData.APPRO);
                    if (objclsTVData.SDATE != null && objclsTVData.SDATE.Trim() != "")
                    {
                        objEntityDetails.StartDate = objCommon.textToDateTime(objclsTVData.SDATE);
                    }
                    if (objclsTVData.EDATE != null && objclsTVData.EDATE != "")
                    {
                        objEntityDetails.EndDate = objCommon.textToDateTime(objclsTVData.EDATE);
                    }
                    objEntityTrficVioltnDetilsList.Add(objEntityDetails);
                }

                objEntityApproval.insertApprovalAssignment(objentityPass, objEntityTrficVioltnDetilsList);

                if (clickedButton.ID == "btnAdd")
                {
                    Response.Redirect("gen_approval_assignment.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnsave")
                {
                    Response.Redirect("gen_approval_assignment.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose")
                {
                    Response.Redirect("gen_approval_assignment_list.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnsaveclose")
                {
                    Response.Redirect("gen_approval_assignment_list.aspx?InsUpd=Ins");
                }
            }

        }

        catch (Exception ex)
        {
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityApprovalAssign objentityPassport = new clsEntityApprovalAssign();
            clsEntityApprovalAssign objentityPass = new clsEntityApprovalAssign();
            clsBusinessLayerApprovalAssign objEntityApproval = new clsBusinessLayerApprovalAssign();
            if (Session["CORPOFFICEID"] != null)
            {
                objentityPassport.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
                objentityPass.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objentityPassport.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                objentityPass.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objentityPassport.userid = Convert.ToInt32(Session["USERID"]);
                objentityPass.userid = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objentityPass.tempid = Convert.ToInt32(HiddenApprovalId.Value);
            objentityPass.desgid = Convert.ToInt32(HiddenDesgid.Value);
            DateTime dd = DateTime.Parse(DateTime.Now.ToShortDateString());
            string dat = dd.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            if (dat.Trim() != "")
            {
                objentityPass.cDate = objCommon.textToDateTime(dat.Trim());
            }

            List<clsEntityApprovalAssign> objEntityTrficVioltnDetilsList = new List<clsEntityApprovalAssign>();
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
                foreach (clsTVData objclsTVData in objTVDataList5)
                {
                    clsEntityApprovalAssign objEntityDetails = new clsEntityApprovalAssign();

                    if (objclsTVData.DTLID != "" && objclsTVData.DTLID != "null" && objclsTVData.DTLID != null && objclsTVData.DTLID != "undefined")
                    {
                        objEntityDetails.desgid = Convert.ToInt32(objclsTVData.DTLID);
                    }
                    objEntityDetails.tempid = Convert.ToInt32(HiddenApprovalId.Value);
                    objEntityDetails.wrkflwid = Convert.ToInt32(objclsTVData.DOC);
                    objEntityDetails.apprsetid = Convert.ToInt32(objclsTVData.APPRO);
                    objEntityDetails.StartDate = objCommon.textToDateTime(objclsTVData.SDATE);
                    objEntityDetails.EndDate = objCommon.textToDateTime(objclsTVData.EDATE);
                    objEntityTrficVioltnDetilsList.Add(objEntityDetails);
                }
                objEntityApproval.UpdateApprovalAssign(objentityPass, objEntityTrficVioltnDetilsList);

                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_approval_assignment.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_approval_assignment_list.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnupdate2")
                {
                    Response.Redirect("gen_approval_assignment.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnupdateclose2")
                {
                    Response.Redirect("gen_approval_assignment_list.aspx?InsUpd=Upd");
                }

            }

        }
        catch (Exception ex)
        {
        }
    }

}