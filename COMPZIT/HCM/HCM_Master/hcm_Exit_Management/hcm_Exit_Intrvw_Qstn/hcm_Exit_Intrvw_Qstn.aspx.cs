using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HCM_HCM_Master_hcm_Exit_Intrvw_Qstn_hcm_Exit_Intrvw_Qstn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Designation();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableConfirm = 0, intEnableReOpen = 0;

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();

                clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn = new clsEntityLayer_Exit_Intrvw_Qstn();
                clsBusinessLayer_Exit_Intrvw_Qstn objBusinessExitIntrvwQstn = new clsBusinessLayer_Exit_Intrvw_Qstn();
                int intCorpId = 0;
                int intOrgId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityExitIntrvwQstn.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();

                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityExitIntrvwQstn.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                    intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                    hiddenOrganisationId.Value = Session["ORGID"].ToString();

                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
              //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Exit_Interview_questions);
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
                }
            }
            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;
            }
            else
            {

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = true;
            }
                //when editing 
                if (Request.QueryString["Id"] != null)
                {
                    btnClear.Visible = false;
                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    int intWBillId = Convert.ToInt32(strId);
                    hiddenIntwCatID.Value = strId;
                    ddlDesg.Enabled = false;
                    cbxCommonSts.Enabled = false;
                    EditView(intWBillId, 1);
                    lblEntry.Text = "Edit Exit Interview Questions";

                }
                //when editing 
                else if (Request.QueryString["StrId"] != null)
                {
                    btnClear.Visible = false;                 
                    //string strRandomMixedId = Request.QueryString["Id"].ToString();
                    //string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    //int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    //string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    int intWBillId = Convert.ToInt32(Request.QueryString["StrId"]);
                    hiddenIntwCatID.Value = Request.QueryString["StrId"];
                   
                    EditView(intWBillId, 1);
                    lblEntry.Text = "Edit Exit Interview Questions";
                    HiddenFieldClose.Value = "close";
                }

                //when  viewing
                else if (Request.QueryString["ViewId"] != null)
                {
                    btnClear.Visible = false;
                    string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    ddlDesg.Enabled = false;
                    cbxCommonSts.Enabled = false;
                    int intWBillId = Convert.ToInt32(strId);
                    EditView(intWBillId, 2);

                    lblEntry.Text = "View Exit Interview Questions";
                }
                else
                {
                    lblEntry.Text = "Add Exit Interview Questions";
                    hiddenIntwCatID.Value = "0";
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;


                }
            
                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    if (strInsUpd == "Save")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
                    }
                    else if (strInsUpd == "Upd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                    }
                }
                DataTable commonquestion = new DataTable();
                commonquestion = objBusinessExitIntrvwQstn.GetCommonQuestions(objEntityExitIntrvwQstn);
                if (commonquestion.Rows.Count > 0)
                {
                   
                    DataTable dtDetail = new DataTable();
                    //  dtDetail.Columns.Add("DESGN_ID", typeof(int));
                    dtDetail.Columns.Add("DTL_ID", typeof(string));
                    dtDetail.Columns.Add("QUESTION", typeof(string));


                    for (int intcnt = 0; intcnt < commonquestion.Rows.Count; intcnt++)
                    {
                        DataRow drDtl = dtDetail.NewRow();
                        //    drDtl["DESGN_ID"] = Convert.ToInt32(dtInterviewCatDtl.Rows[intcnt]["DSGN_ID"].ToString());
                        drDtl["DTL_ID"] = commonquestion.Rows[intcnt]["EXTINTRVQT_ID"].ToString();
                        drDtl["QUESTION"] = commonquestion.Rows[intcnt]["EXTINTRVQT_QSTN"].ToString();
                        // string jsonData = drDtl["QUESTION"].ToString();
                        //string c = jsonData.Replace(" ' ", "");
                        //drDtl["QUESTION"] = c;
                        dtDetail.Rows.Add(drDtl);
                    }

                    string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
                    HiddenCommonQuestions.Value = strJson;
                }
           
        }
    }


    public void Designation()
    {
        clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn = new clsEntityLayer_Exit_Intrvw_Qstn();
        clsBusinessLayer_Exit_Intrvw_Qstn objBusinessExitIntrvwQstn = new clsBusinessLayer_Exit_Intrvw_Qstn();

        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityExitIntrvwQstn.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityExitIntrvwQstn.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtDivision = objBusinessExitIntrvwQstn.ReadDesignation(objEntityExitIntrvwQstn);
        if (dtDivision.Rows.Count > 0)
        {
            ddlDesg.Items.Clear();
            ddlDesg.DataSource = dtDivision;


            ddlDesg.DataValueField = "DSGN_ID";
            ddlDesg.DataTextField = "DSGN_NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlDesg.DataBind();

        }
        ddlDesg.Items.Insert(0, "--SELECT--");

    }


    public class clsWBData
    {
        public string QUESTIONS { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
       
        try
        {
            
            Button clickedButton = sender as Button;
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            clsBusinessLayer_Exit_Intrvw_Qstn objBusinessExitIntrvwQstn = new clsBusinessLayer_Exit_Intrvw_Qstn();
            clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn = new clsEntityLayer_Exit_Intrvw_Qstn();
            int intUserId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityExitIntrvwQstn.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }


            if (Session["ORGID"] != null)
            {
                objEntityExitIntrvwQstn.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityExitIntrvwQstn.InsUserId = intUserId;
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (ddlDesg.SelectedItem.Value != "--SELECT--")
            {
                objEntityExitIntrvwQstn.DesgId = Convert.ToInt32(ddlDesg.SelectedItem.Value);
               
            }
            else
            {
                objEntityExitIntrvwQstn.DesgId = 0;
            }
            //if (cbxCommonSts.Checked == true)
            //{
            //    objEntityExitIntrvwQstn.Status = 1;
            //}
            //else
            //{
            //    objEntityExitIntrvwQstn.Status = 0;
            //}
            //objEntityInterviewCategory.TotalAmnt = Convert.ToDecimal(hiddenNetAmount.Value.Trim());

            // ID

            objEntityExitIntrvwQstn.InsDate = System.DateTime.Now;

            List<clsEntityLayer_Exit_Intrvw_Qstn_List> objEntityExitIntrvwQstnList = new List<clsEntityLayer_Exit_Intrvw_Qstn_List>();
            string jsonData = HiddenQuestions.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");
            List<clsWBData> objWBDataList = new List<clsWBData>();
            //   UserData  data
            objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(i);
            foreach (clsWBData objclsWBData in objWBDataList)
            { 
                clsEntityLayer_Exit_Intrvw_Qstn_List objEntityDetails = new clsEntityLayer_Exit_Intrvw_Qstn_List();
              
                    objEntityDetails.Questions = objclsWBData.QUESTIONS;
                    if (cbxCommonSts.Checked == true)
                    {

                        objEntityDetails.CommonSts = 1;
                        objEntityExitIntrvwQstn.DesgId = 0;
                    }
                    else
                    {
                        objEntityDetails.CommonSts = 0;
                    }
                    objEntityExitIntrvwQstnList.Add(objEntityDetails);
                }
            
            objBusinessExitIntrvwQstn.InsertExitIntrvwQstn(objEntityExitIntrvwQstn, objEntityExitIntrvwQstnList);
            if (clickedButton.ID == "btnSave")
            {
                Response.Redirect("hcm_Exit_Intrvw_Qstn.aspx?InsUpd=Save");
            }
            else if (clickedButton.ID == "btnSaveClose")
            {
                Response.Redirect("hcm_Exit_Intrvw_Qstn_List.aspx?InsUpd=Save");
            }

        }
        catch (Exception ex)
        {
            //throw ex;
            ScriptManager.RegisterStartupScript(this, GetType(), "ErrMsg", "ErrMsg();", true);
        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            if (Request.QueryString["Id"] != null || Request.QueryString["StrId"] != null)
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();
                clsBusinessLayer_Exit_Intrvw_Qstn objBusinessExitIntrvwQstn = new clsBusinessLayer_Exit_Intrvw_Qstn();
                clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn = new clsEntityLayer_Exit_Intrvw_Qstn();
                int intUserId = 0;

                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityExitIntrvwQstn.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }


                if (Session["ORGID"] != null)
                {
                    objEntityExitIntrvwQstn.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

                if (Session["USERID"] != null)
                {
                    intUserId = Convert.ToInt32(Session["USERID"]);
                    objEntityExitIntrvwQstn.InsUserId = intUserId;
                    objEntityExitIntrvwQstn.UpdUserId = intUserId;
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (ddlDesg.SelectedItem.Value != "--SELECT--")
                {
                    objEntityExitIntrvwQstn.DesgId = Convert.ToInt32(ddlDesg.SelectedItem.Value);

                }
                else
                {
                    objEntityExitIntrvwQstn.DesgId = 0;
                }
                objEntityExitIntrvwQstn.InsDate = DateTime.Now;
                objEntityExitIntrvwQstn.UpdDate = DateTime.Now;
                //if (cbxCommonSts.Checked == true)
                //{
                //    objEntityExitIntrvwQstn.Status = 1;
                //}
                //else
                //{
                //    objEntityExitIntrvwQstn.Status = 0;
                //}
                List<clsEntityLayer_Exit_Intrvw_Qstn_List> objEntityIntrvwINSERTList = new List<clsEntityLayer_Exit_Intrvw_Qstn_List>();

                List<clsEntityLayer_Exit_Intrvw_Qstn_List> objEntityIntrvwUPDATEList = new List<clsEntityLayer_Exit_Intrvw_Qstn_List>();
                List<clsEntityLayer_Exit_Intrvw_Qstn_List> objEntityIntrvwDELETEList = new List<clsEntityLayer_Exit_Intrvw_Qstn_List>();

                string jsonData = HiddenQuestions.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                
                List<clsWBData> objWBDataList = new List<clsWBData>();
                //   UserData  data
                objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(i);


                foreach (clsWBData objClsWBData in objWBDataList)
                {
                    if (objClsWBData.EVTACTION == "INS")
                    {
                        clsEntityLayer_Exit_Intrvw_Qstn_List objEntityDetails = new clsEntityLayer_Exit_Intrvw_Qstn_List();

                        objEntityDetails.Questions =objClsWBData.QUESTIONS;

                        objEntityIntrvwINSERTList.Add(objEntityDetails);
                    }
                    else if (objClsWBData.EVTACTION == "UPD")
                    {
                        clsEntityLayer_Exit_Intrvw_Qstn_List objEntityDetails = new clsEntityLayer_Exit_Intrvw_Qstn_List();
                        objEntityDetails.Questions = objClsWBData.QUESTIONS;
                        objEntityDetails.DtlId = Convert.ToInt32(objClsWBData.DTLID);
                        objEntityIntrvwUPDATEList.Add(objEntityDetails);


                    }
                }



                string strCanclDtlId = "";
                string[] strarrCancldtlIds = strCanclDtlId.Split(',');
                if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
                {
                    strCanclDtlId = hiddenCanclDtlId.Value;
                    strarrCancldtlIds = strCanclDtlId.Split(',');

                }
                //Cancel the rows that have been cancelled when editing in Detail table
                foreach (string strDtlId in strarrCancldtlIds)
                {
                    if (strDtlId != "" && strDtlId != null)
                    {
                        int intDtlId = Convert.ToInt32(strDtlId);
                        clsEntityLayer_Exit_Intrvw_Qstn_List objEntityDetails = new clsEntityLayer_Exit_Intrvw_Qstn_List();
                        objEntityDetails.DtlId = Convert.ToInt32(strDtlId);
                        objEntityIntrvwDELETEList.Add(objEntityDetails);

                    }
                }

                objBusinessExitIntrvwQstn.UpdateCertificateTemplate(objEntityExitIntrvwQstn, objEntityIntrvwINSERTList, objEntityIntrvwUPDATEList, objEntityIntrvwDELETEList);




                if (Request.QueryString["StrId"] != null)
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedCustomerToLead", "PassSavedCustomerToLead();", true);


                }

                else
                {

                    if (clickedButton.ID == "btnUpdate")
                    {
                        Response.Redirect("hcm_Exit_Intrvw_Qstn.aspx?InsUpd=Upd");
                    }
                    else if (clickedButton.ID == "btnUpdateClose")
                    {
                        Response.Redirect("hcm_Exit_Intrvw_Qstn_List.aspx?InsUpd=Upd");
                    }
                }
            }
            else
            {

                Response.Redirect("~/Default.aspx");

            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "ErrorMsg();", true);
        }
    }

    private void EditView(int intId, int intEditOrView)
    {//when Editing or viewing
        //intEditOrView if 1-Edit,2-View
        int intUserId = 0, intUsrRolMstrId=0, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableConfirm = 0, intEnableReOpen = 0;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn = new clsEntityLayer_Exit_Intrvw_Qstn();
        clsBusinessLayer_Exit_Intrvw_Qstn objBusinessExitIntrvwQstn = new clsBusinessLayer_Exit_Intrvw_Qstn();
        //objEntityCertificateBundelTemplate.CertificateBundelTempId = intId;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Exit_Interview_questions);
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
            }
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityExitIntrvwQstn.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }



        if (Session["ORGID"] != null)
        {
            objEntityExitIntrvwQstn.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityExitIntrvwQstn.DesgId = intId;

        DataTable dtInterviewCatDtl1 = new DataTable();

        dtInterviewCatDtl1 = objBusinessExitIntrvwQstn.CheckSubTbl(objEntityExitIntrvwQstn);
        if (dtInterviewCatDtl1.Rows.Count > 0)
        {
            if (Convert.ToInt32(dtInterviewCatDtl1.Rows[0]["Count"].ToString()) > 0)
            {
                HiddenSubCount.Value = "1";
            }
            else
            {
                HiddenSubCount.Value = "0";
            }
        }

        DataTable dtInterviewCatDtl = new DataTable();

        dtInterviewCatDtl = objBusinessExitIntrvwQstn.ReadDtlsById(objEntityExitIntrvwQstn);

        if (dtInterviewCatDtl.Rows.Count > 0)
        {
            for (int j = 0; j < dtInterviewCatDtl.Rows.Count; j++)
            {
                if (dtInterviewCatDtl.Rows[j]["DSGN_ID"].ToString() != "")
                {
                    if (ddlDesg.Items.FindByValue(dtInterviewCatDtl.Rows[j]["DSGN_ID"].ToString()) != null)
                    {
                        ddlDesg.ClearSelection();

                        ddlDesg.Items.FindByValue(dtInterviewCatDtl.Rows[j]["DSGN_ID"].ToString()).Selected = true;

                    }
                    else
                    {
                        ddlDesg.ClearSelection();

                        ListItem lstGrp = new ListItem(dtInterviewCatDtl.Rows[j]["DSGN_NAME"].ToString(), dtInterviewCatDtl.Rows[j]["DSGN_ID"].ToString());
                        ddlDesg.Items.Insert(1, lstGrp);

                        ddlDesg.Items.FindByValue(dtInterviewCatDtl.Rows[j]["DSGN_ID"].ToString()).Selected = true;
                    }
                }

            }
           ddlDesg.SelectedItem.Text = dtInterviewCatDtl.Rows[0]["DSGN_NAME"].ToString();
          
         
            DataTable dtDetail = new DataTable();           
          //  dtDetail.Columns.Add("DESGN_ID", typeof(int));
           dtDetail.Columns.Add("DTL_ID", typeof(string));
            dtDetail.Columns.Add("QUESTION", typeof(string));


            for (int intcnt = 0; intcnt < dtInterviewCatDtl.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
            //    drDtl["DESGN_ID"] = Convert.ToInt32(dtInterviewCatDtl.Rows[intcnt]["DSGN_ID"].ToString());
                drDtl["DTL_ID"] = dtInterviewCatDtl.Rows[intcnt]["EXTINTRVQT_ID"].ToString();
                drDtl["QUESTION"] = dtInterviewCatDtl.Rows[intcnt]["EXTINTRVQT_QSTN"].ToString();
               // string jsonData = drDtl["QUESTION"].ToString();
                //string c = jsonData.Replace(" ' ", "");
                //drDtl["QUESTION"] = c;
                dtDetail.Rows.Add(drDtl);
            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            if (intEditOrView == 1)
            {
                btnSave.Visible = false;
                btnSaveClose.Visible = false;
                if (intEnableModify == 1)
                {
                    btnUpdate.Visible = true;
                    btnUpdateClose.Visible = true;
                }
                else
                {
                   // btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                }
                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnUpdate.Visible = true;
                    btnUpdateClose.Visible = true;
                }
                else
                {

                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = true;
                }
              //  btnUpdate.Visible = true;
              //  btnUpdateClose.Visible = true;
                hiddenEdit.Value = strJson;
            }
            else if (intEditOrView == 2)
            {
               // cbxCnclStatus.Enabled = false;
                btnSave.Visible = false;
                btnSaveClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                hiddenView.Value = strJson;
            }


        }
    }

    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
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
}