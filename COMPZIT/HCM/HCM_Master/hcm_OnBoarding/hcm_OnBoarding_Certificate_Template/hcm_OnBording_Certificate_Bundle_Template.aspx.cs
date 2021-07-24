using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Collections;
using BL_Compzit;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Text;

public partial class HCM_HCM_Master_hcm_OnBoarding_hcm_OnBoarding_Certificate_Template_hcm_OnBording_Certificate_Bundle_Template : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            // txtName.Focus();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableConfirm = 0, intEnableReOpen = 0;

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();



            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            TempHistTab();
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Certificate_Bundle_Template);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        // intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);


                    }


                }

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnSave.Visible = true;
                    btnSaveClose.Visible = true;

                }
                else
                {

                    btnSave.Visible = false;
                    btnSaveClose.Visible = false;

                }
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        btnUpdate.Visible = true;
                    }
                    else
                    {
                        btnUpdate.Visible = false;

                    }
                    btnUpdateClose.Visible = true;

                }
                else
                {

                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;

                }



                //Creating objects for business layer
                //clsBusinessLayerWaterBilling objBusinessLayerWaterBilling = new clsBusinessLayerWaterBilling();
                clsEntity_Certificate_Bundel_Template objEntityCertificateBundel = new clsEntity_Certificate_Bundel_Template();
                int intCorpId = 0;
                int intOrgId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityCertificateBundel.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();

                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityCertificateBundel.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                    intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                    hiddenOrganisationId.Value = Session["ORGID"].ToString();

                }
                else
                {
                    Response.Redirect("~/Default.aspx");
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
                    EditView(intWBillId, 1);
                    lblEntry.Text = "Edit Certificate Bundle Template";

                }
                //when editing 
                else if (Request.QueryString["StrId"] != null)
                {
                    btnClear.Visible = false;
                    btnUpdate.Visible = false;
                    //string strRandomMixedId = Request.QueryString["Id"].ToString();
                    //string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    //int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    //string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    int intWBillId = Convert.ToInt32(Request.QueryString["StrId"]);
                    hiddenIntwCatID.Value = Request.QueryString["StrId"];
                    EditView(intWBillId, 1);
                    lblEntry.Text = "Edit Certificate Bundle Template";
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
                    int intWBillId = Convert.ToInt32(strId);
                    EditView(intWBillId, 2);

                    lblEntry.Text = "View Certificate Bundle Template";
                }
                else
                {
                    lblEntry.Text = "Add Certificate Bundle Template";
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

            }
            else
            {
                btnSave.Visible = false;
                btnSaveClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                // btnClose.Visible = false;
                btnClear.Visible = false;

            }


        }
    }




    public class clsWBData
    {
        public string APTNAME { get; set; }
        public string DEFLTSTATUS { get; set; }
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

            cls_Business_Certificate_Bundel_Template objBusinessCertificateBundelTemplate = new cls_Business_Certificate_Bundel_Template();
            clsEntity_Certificate_Bundel_Template objEntityCertificateBundelTemplate = new clsEntity_Certificate_Bundel_Template();
            int intUserId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCertificateBundelTemplate.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }


            if (Session["ORGID"] != null)
            {
                objEntityCertificateBundelTemplate.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityCertificateBundelTemplate.CertificateBundelName = txtName.Text.Trim().ToUpper();
            if (cbxCnclStatus.Checked == true)
            {
                objEntityCertificateBundelTemplate.Status = 1;
            }
            else
            {
                objEntityCertificateBundelTemplate.Status = 0;
            }
            //objEntityInterviewCategory.TotalAmnt = Convert.ToDecimal(hiddenNetAmount.Value.Trim());

            // ID
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CERTIFICATE_BUNDEL);
            objEntityCommon.CorporateID = objEntityCertificateBundelTemplate.CorpId;
            objEntityCommon.Organisation_Id = objEntityCertificateBundelTemplate.OrgId;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            objEntityCertificateBundelTemplate.CertificateBundelTempId = Convert.ToInt32(strNextId);
            objEntityCertificateBundelTemplate.UserId = intUserId;
            objEntityCertificateBundelTemplate.Date = System.DateTime.Now;

            List<clsEntity_Certificate_Bundel_Template_details> objCertificatebundelDtls = new List<clsEntity_Certificate_Bundel_Template_details>();
            string jsonData = HiddenField1.Value;
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
                clsEntity_Certificate_Bundel_Template_details objEntityDetails = new clsEntity_Certificate_Bundel_Template_details();
                objEntityDetails.CertificateBundelTemplateDetailsid = Convert.ToInt32(strNextId);
                objEntityDetails.CertificateBundelTemplateDetailsName = objclsWBData.APTNAME;
                objEntityDetails.CertificateBundelTemplateDetailsStatus = Convert.ToInt32(objclsWBData.DEFLTSTATUS);
                objCertificatebundelDtls.Add(objEntityDetails);
            }
            objBusinessCertificateBundelTemplate.InsertCertificateTemplate(objEntityCertificateBundelTemplate, objCertificatebundelDtls);
            if (clickedButton.ID == "btnSave")
            {
                Response.Redirect("hcm_OnBording_Certificate_Bundle_Template.aspx?InsUpd=Save");
            }
            else if (clickedButton.ID == "btnSaveClose")
            {
                Response.Redirect("hcm_OnBording_Certificate_Bundle_Template_List.aspx?InsUpd=Save");
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
       
            Button clickedButton = sender as Button;
            if (Request.QueryString["Id"] != null || Request.QueryString["StrId"] != null)
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();
                cls_Business_Certificate_Bundel_Template objBusinessCertificateBundelTemplate = new cls_Business_Certificate_Bundel_Template();
                clsEntity_Certificate_Bundel_Template objEntityCertificateBundelTemplate = new clsEntity_Certificate_Bundel_Template();
                int intUserId = 0;

                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityCertificateBundelTemplate.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }


                if (Session["ORGID"] != null)
                {
                    objEntityCertificateBundelTemplate.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

                if (Session["USERID"] != null)
                {
                    intUserId = Convert.ToInt32(Session["USERID"]);

                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Request.QueryString["StrId"] == null)
                {
                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    objEntityCertificateBundelTemplate.CertificateBundelTempId = Convert.ToInt32(strId);
                }
                else
                {
                    objEntityCertificateBundelTemplate.CertificateBundelTempId = Convert.ToInt32(Request.QueryString["StrId"]);
                }

                objEntityCertificateBundelTemplate.UserId = intUserId;
                objEntityCertificateBundelTemplate.Date = System.DateTime.Now;
                objEntityCertificateBundelTemplate.CertificateBundelName = txtName.Text.Trim();
                if (cbxCnclStatus.Checked == true)
                {
                    objEntityCertificateBundelTemplate.Status = 1;
                }
                else
                {
                    objEntityCertificateBundelTemplate.Status = 0;
                }
                List<clsEntity_Certificate_Bundel_Template_details> objEntityCertfctINSERTList = new List<clsEntity_Certificate_Bundel_Template_details>();

                List<clsEntity_Certificate_Bundel_Template_details> objEntityCertfctUPDATEList = new List<clsEntity_Certificate_Bundel_Template_details>();
                List<clsEntity_Certificate_Bundel_Template_details> objEntityCertfctDELETEList = new List<clsEntity_Certificate_Bundel_Template_details>();

                string jsonData = HiddenField1.Value;

                if (jsonData != null && jsonData != "")
                {
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
                            clsEntity_Certificate_Bundel_Template_details objEntityDetails = new clsEntity_Certificate_Bundel_Template_details();

                            objEntityDetails.CertificateBundelTemplateDetailsName = objClsWBData.APTNAME;
                            objEntityDetails.CertificateBundelTemplateDetailsStatus = Convert.ToInt32(objClsWBData.DEFLTSTATUS);
                            objEntityCertfctINSERTList.Add(objEntityDetails);
                        }
                        else if (objClsWBData.EVTACTION == "UPD")
                        {
                            clsEntity_Certificate_Bundel_Template_details objEntityDetails = new clsEntity_Certificate_Bundel_Template_details();
                            objEntityDetails.CertificateBundelTemplateDetailsName = objClsWBData.APTNAME;
                            objEntityDetails.CertificateBundelTemplateDetailsStatus = Convert.ToInt32(objClsWBData.DEFLTSTATUS);
                            objEntityDetails.CertificateBundelTemplateDetailsid = Convert.ToInt32(objClsWBData.DTLID);
                            objEntityCertfctUPDATEList.Add(objEntityDetails);


                        }
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
                        clsEntity_Certificate_Bundel_Template_details objEntityDetails = new clsEntity_Certificate_Bundel_Template_details();
                        objEntityDetails.CertificateBundelTemplateDetailsid = Convert.ToInt32(strDtlId);
                        objEntityCertfctDELETEList.Add(objEntityDetails);

                    }
                }

                objBusinessCertificateBundelTemplate.UpdateCertificateTemplate(objEntityCertificateBundelTemplate, objEntityCertfctINSERTList, objEntityCertfctUPDATEList, objEntityCertfctDELETEList);


                    if (clickedButton.ID == "btnUpdate")
                    {
                        Response.Redirect("hcm_OnBording_Certificate_Bundle_Template.aspx?InsUpd=Upd");
                    }
                    else if (clickedButton.ID == "btnUpdateClose")
                    {
                        Response.Redirect("hcm_OnBording_Certificate_Bundle_Template_List.aspx?InsUpd=Upd");
                    }
                }
           
       
    }



    [WebMethod]
    public static string CheckDupCertificateTemplate(string strCertfctTempId, string strCertName, string strOrgId, string strCorpId)
    {
        //Confirm
        string strResult = "0";
        cls_Business_Certificate_Bundel_Template objBusinessCertificateBundelTemplate = new cls_Business_Certificate_Bundel_Template();
        clsEntity_Certificate_Bundel_Template objEntityCertificateBundelTemplate = new clsEntity_Certificate_Bundel_Template();
        objEntityCertificateBundelTemplate.CertificateBundelTempId = Convert.ToInt32(strCertfctTempId);
        objEntityCertificateBundelTemplate.CertificateBundelName = strCertName;
        objEntityCertificateBundelTemplate.OrgId = Convert.ToInt32(strOrgId);
        objEntityCertificateBundelTemplate.CorpId = Convert.ToInt32(strCorpId);
        strResult = objBusinessCertificateBundelTemplate.CheckDupCertificateTemplate(objEntityCertificateBundelTemplate);
        return strResult;
    }

    private void TempHistTab()
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        cls_Business_Certificate_Bundel_Template objBusinessCertificateBundelTemplate = new cls_Business_Certificate_Bundel_Template();
        clsEntity_Certificate_Bundel_Template objEntityCertificateBundelTemplate = new clsEntity_Certificate_Bundel_Template();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCertificateBundelTemplate.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }



        if (Session["ORGID"] != null)
        {
            objEntityCertificateBundelTemplate.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }


        DataTable dtProductSrch = new DataTable();
        objEntityCertificateBundelTemplate.Status = 1;
        objEntityCertificateBundelTemplate.CancelStatus = 0;

        dtProductSrch = objBusinessCertificateBundelTemplate.ReadCertificateTemplate(objEntityCertificateBundelTemplate);

        StringBuilder sb = new StringBuilder();
        string strHtml = "";
        strHtml += "<div id=\"accordion-2\" style=\"float: left;width: 98%;margin-left: 1%;\">";
        foreach (DataRow dt in dtProductSrch.Rows)
        {
            strHtml += " <div class=\"panel-heading\">";
            strHtml += "<h4 class=\"panel-title\"><a data-toggle=\"collapse\" data-parent=\"#accordion-2\" href=\"#collapseOne-" + dt["CRTFTBNDLTEM_ID"] + "\" aria-expanded=\"false\" class=\"collapsed\">" + dt["TEMPLATE NAME"] + " </a></h4>";
            strHtml += "</div>";
            strHtml += "<div id=\"collapseOne-" + dt["CRTFTBNDLTEM_ID"] + "\" class=\"panel-collapse collapse\" aria-expanded=\"false\" style=\"height: 0px;width:98%; float: left; overflow: hidden;\">";
            strHtml += " <div class=\"panel-body\">";

            objEntityCertificateBundelTemplate.CertificateBundelTempId = Convert.ToInt32(dt["CRTFTBNDLTEM_ID"]);
            DataTable dtInterviewCatDtl = new DataTable();

            dtInterviewCatDtl = objBusinessCertificateBundelTemplate.ReadInterviewCatByID(objEntityCertificateBundelTemplate);
            foreach (DataRow dtSub in dtInterviewCatDtl.Rows)
            {
                strHtml += "<div class=\"EachDiv\">" + dtSub["CRTFTBNDLTEMDTL_NAME"] + " </div>";

            }
            strHtml += " </div >";
            strHtml += " </div >";
        }
        strHtml += " </div >";
        sb.Append(strHtml);

        divHistoryContainer.InnerHtml = sb.ToString();
    }

    private void EditView(int intId, int intEditOrView)
    {//when Editing or viewing
        //intEditOrView if 1-Edit,2-View
        clsCommonLibrary objCommon = new clsCommonLibrary();
        cls_Business_Certificate_Bundel_Template objBusinessCertificateBundelTemplate = new cls_Business_Certificate_Bundel_Template();
        clsEntity_Certificate_Bundel_Template objEntityCertificateBundelTemplate = new clsEntity_Certificate_Bundel_Template();
        objEntityCertificateBundelTemplate.CertificateBundelTempId = intId;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCertificateBundelTemplate.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }



        if (Session["ORGID"] != null)
        {
            objEntityCertificateBundelTemplate.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtInterviewCatDtl = new DataTable();
        //   DataTable dtWBill = new DataTable();


        dtInterviewCatDtl = objBusinessCertificateBundelTemplate.ReadInterviewCatByID(objEntityCertificateBundelTemplate);



        if (dtInterviewCatDtl.Rows.Count > 0)
        {



            txtName.Text = dtInterviewCatDtl.Rows[0]["CRTFTBNDLTEM_NAME"].ToString();
            if (dtInterviewCatDtl.Rows[0]["STATUS"].ToString() == "1")
            {
                cbxCnclStatus.Checked = true;

            }
            else
            {
                cbxCnclStatus.Checked = false;
            }

            //if (dtInterviewCatDtl.Rows[0]["WTRFILNG_CNFRM_STS"].ToString() == "1")
            //{
            //    intEditOrView = 2;

            //}




            //   hiddenActiveUser.Value = dtQtn.Rows[0]["LDQUOT_ACTIVE_USR_ID"].ToString();



            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("TempId", typeof(int));
            dtDetail.Columns.Add("TEMDTL_ID", typeof(int));
            dtDetail.Columns.Add("TEMDTL_NAME", typeof(string));
            dtDetail.Columns.Add("DfltStatus", typeof(string));


            for (int intcnt = 0; intcnt < dtInterviewCatDtl.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["TempId"] = Convert.ToInt32(dtInterviewCatDtl.Rows[intcnt]["CRTFTBNDLTEM_ID"].ToString());
                drDtl["TEMDTL_ID"] = Convert.ToInt32(dtInterviewCatDtl.Rows[intcnt]["CRTFTBNDLTEMDTL_ID"].ToString());
                drDtl["TEMDTL_NAME"] = dtInterviewCatDtl.Rows[intcnt]["CRTFTBNDLTEMDTL_NAME"].ToString();
                drDtl["DfltStatus"] = dtInterviewCatDtl.Rows[intcnt]["CRTFTBNDLTEMDTL_STATUS"].ToString();

                dtDetail.Rows.Add(drDtl);

            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            if (intEditOrView == 1)
            {
                btnSave.Visible = false;
                btnSaveClose.Visible = false;
                hiddenEdit.Value = strJson;
            }
            else if (intEditOrView == 2)
            {
                cbxCnclStatus.Enabled = false;
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


