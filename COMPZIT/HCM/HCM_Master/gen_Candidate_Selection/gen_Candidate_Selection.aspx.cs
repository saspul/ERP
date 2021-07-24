using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Collections;
using BL_Compzit;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System.IO;


public partial class HCM_HCM_Master_gen_Candidate_Selection_gen_Candidate_Selection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownCountryDataStore();
        if (!IsPostBack)
        {
           
            radioBascPay.Checked = true;
            this.Form.Enctype = "multipart/form-data";
            HiddenImportCheck.Value = "";
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
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


            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Candidate_Selection);
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

                    }
                }
            }


            if (Session["CORPOFFICEID"] != null)
            {
                hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                hiddenOrganisationId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                int intManPwrReqId = Convert.ToInt32(strId);
           
                LoadInterviewTemplate();
                EditView(intManPwrReqId, 1);
                FillInitialData(strId);
            }
            LoadAdditionalDropdown();
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Save")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessSave", "SuccessSave();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdate", "SuccessUpdate();", true);
                }

            }
        }
    }
    public void LoadAdditionalDropdown()
    {
        clsEntityCandidateSelection objEntityCandidateSel = new clsEntityCandidateSelection();
        clsBusinessLayerCandidateSelection objBussinessCandidateSel = new clsBusinessLayerCandidateSelection();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCandidateSel.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityCandidateSel.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityCandidateSel.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //EVM-0024
        if (HiddenDeptId.Value != "")
        {
            objEntityCandidateSel.Deprt_Id = Convert.ToInt32(HiddenDeptId.Value);
        }
        //END
        DataTable dtdiv = objBussinessCandidateSel.ReadDivision(objEntityCandidateSel);
        if (dtdiv.Rows.Count > 0)
        {
            ddlDivision.DataSource = dtdiv;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();
        }
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");

        DataTable dtSubCorp = objBussinessCandidateSel.ReadDepartment(objEntityCandidateSel);
        if (dtSubCorp.Rows.Count > 0)
        {
            ddlDepartment.DataSource = dtSubCorp;
            ddlDepartment.DataTextField = "CPRDEPT_NAME";
            ddlDepartment.DataValueField = "CPRDEPT_ID";
            ddlDepartment.DataBind();

        }
        ddlDepartment.Items.Insert(0, "--SELECT DEPARTMENT--");


        DataTable dtConsult = objBussinessCandidateSel.ReadConsultancies(objEntityCandidateSel);
        if (dtConsult.Rows.Count > 0)
        {
            ddlConsultancy.DataSource = dtConsult;
            ddlConsultancy.DataTextField = "CNSLT_NAME";
            ddlConsultancy.DataValueField = "CNSLT_ID";
            ddlConsultancy.DataBind();

        }
        ddlConsultancy.Items.Insert(0, "--SELECT CONSULTANCY--");


        DataTable dtEmp = objBussinessCandidateSel.ReadEmployee(objEntityCandidateSel);
        if (dtEmp.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dtEmp;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();

        }
        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");

    }

    public void LoadInterviewTemplate()
    {
        clsEntityCandidateSelection objEntityCandidateSel = new clsEntityCandidateSelection();
        clsBusinessLayerCandidateSelection objBussinessCandidateSel = new clsBusinessLayerCandidateSelection();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCandidateSel.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityCandidateSel.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityCandidateSel.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtInterviewTemp = objBussinessCandidateSel.ReadinterviewTemList(objEntityCandidateSel);
        if (dtInterviewTemp.Rows.Count > 0)
        {
            ddlInterviewTemp.DataSource = dtInterviewTemp;
            ddlInterviewTemp.DataTextField = "INVTEM_NAME";
            ddlInterviewTemp.DataValueField = "INVTEM_ID";
            ddlInterviewTemp.DataBind();

        }
        ddlInterviewTemp.Items.Insert(0, "--SELECT INTERVIEW TEMPLATE--");
    }
    public void FillInitialData(string RqstId)
    {
        clsEntityCandidateSelection objEntityCandidateSel = new clsEntityCandidateSelection();
        clsBusinessLayerCandidateSelection objBussinessCandidateSel = new clsBusinessLayerCandidateSelection();
        objEntityCandidateSel.ManPwrRqstId = Convert.ToInt32(RqstId);
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCandidateSel.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityCandidateSel.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityCandidateSel.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtReqstDetail = objBussinessCandidateSel.ReadManPwrReqstById(objEntityCandidateSel);
        if (dtReqstDetail.Rows.Count > 0)
        {
            lblRefNum.Text = dtReqstDetail.Rows[0]["MNP_REFNUM"].ToString();
            lblNumber.Text = dtReqstDetail.Rows[0]["MNP_RESOURCENUM"].ToString();
            lblDesign.Text = dtReqstDetail.Rows[0]["DESIGNATION"].ToString(); ;
            lblDeprtmnt.Text = dtReqstDetail.Rows[0]["DEPARTMENT"].ToString();
            lblDateOfReq.Text = dtReqstDetail.Rows[0]["MNPRQST_DATE"].ToString();
            lblExprnce.Text = dtReqstDetail.Rows[0]["MNP_EXPERIENCE"].ToString() + "  Years";
            lblPaygrd.Text = dtReqstDetail.Rows[0]["PYGRD_NAME"].ToString();
            lblPrjct.Text = dtReqstDetail.Rows[0]["PROJECT"].ToString();
            HiddenDeptId.Value = dtReqstDetail.Rows[0]["CPRDEPT_ID"].ToString();//EVM-0024
        }


    }
    public void DropDownCountryDataStore()
    {
        clsBusinessLayerCandidateSelection objBussinessCandidateSel = new clsBusinessLayerCandidateSelection();

        DataTable dtCountryList = new DataTable();
        dtCountryList = objBussinessCandidateSel.ReadCountry();
        dtCountryList.TableName = "dtTableCountry";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtCountryList.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenCountryDdlData.Value = result;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        string strEncId = Request.QueryString["Id"].ToString();
        Response.Redirect("gen_Candidate_Selection.aspx?id=" + strEncId);
        //Response.Redirect("gen_Job_Notification.aspx");
    }
    [WebMethod]
    public static string DropdownCountryBind(string tableName)
    {
        clsBusinessLayerCandidateSelection objBussinessCandidateSel = new clsBusinessLayerCandidateSelection();
        DataTable dtCountryList = new DataTable();
        dtCountryList = objBussinessCandidateSel.ReadCountry();
        dtCountryList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtCountryList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;


    }
    public class clsWBData
    {
        public string ROWID { get; set; }
        public string CANDNAME { get; set; }
        public string CANDLOCAION { get; set; }
        public string CANDCOUNTRY { get; set; }
        public string CANDREFTYP { get; set; }
        public string CANDREFVAL { get; set; }
        public string CANDSKPINT { get; set; }
        public string CANDVISA { get; set; }
        public string CANDLICENSE { get; set; }
        public string CANDPASSPORT { get; set; }
        public string CANDEMAIL { get; set; }
        public string CANDMOBILE { get; set; }
        public string CANDGENDER { get; set; }
        public string CANDDOCNAME { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }
        public string FILECOUNT { get; set; }
        //public string FILENAME { get; set; }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityCandidateSelection objEntityCandidateSel = new clsEntityCandidateSelection();
            clsBusinessLayerCandidateSelection objBussinessCandidateSel = new clsBusinessLayerCandidateSelection();
            int intUserId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCandidateSel.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }


            if (Session["ORGID"] != null)
            {
                objEntityCandidateSel.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
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

            //objEntityInterviewCategory.TotalAmnt = Convert.ToDecimal(hiddenNetAmount.Value.Trim());

            // ID
            if (Request.QueryString["Id"] != null)
            {

                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityCandidateSel.ManPwrRqstId = Convert.ToInt32(strId);

            }

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CANDIDATE_SELECTION);
            objEntityCommon.CorporateID = objEntityCandidateSel.CorpOffice_Id;
            objEntityCommon.Organisation_Id = objEntityCandidateSel.Organisation_Id;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            objEntityCandidateSel.CandidateSelectionId = Convert.ToInt32(strNextId);

            objEntityCandidateSel.User_Id = intUserId;
            objEntityCandidateSel.J_Date = System.DateTime.Now;

            objEntityCandidateSel.IntervTemplateId = Convert.ToInt32(ddlInterviewTemp.SelectedItem.Value);



            List<clsEntityCandSelectionDtl> objEntityInterviewCategoryDetilsList = new List<clsEntityCandSelectionDtl>();
            string jsonData = HiddenField1.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");
            List<clsWBData> objWBDataList = new List<clsWBData>();
            //   UserData  data
            objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(i);
            int intImgCount = 1;
            int intFileID = 0;
            foreach (clsWBData objclsWBData in objWBDataList)
            {

                clsEntityCandSelectionDtl objEntityDetails = new clsEntityCandSelectionDtl();
                objEntityDetails.Candidatename = objclsWBData.CANDNAME;
                objEntityDetails.Location = objclsWBData.CANDLOCAION;
                objEntityDetails.CountryId = Convert.ToInt32(objclsWBData.CANDCOUNTRY);
                if (objclsWBData.CANDREFTYP != null && objclsWBData.CANDREFTYP.ToString() != "")
                objEntityDetails.RefType = Convert.ToInt32(objclsWBData.CANDREFTYP);
                if (objclsWBData.CANDREFTYP=="1")
                    objEntityDetails.ConsultId = Convert.ToInt32(objclsWBData.CANDREFVAL);
                else if (objclsWBData.CANDREFTYP == "2")
                    objEntityDetails.DivisionId = Convert.ToInt32(objclsWBData.CANDREFVAL);
                else if (objclsWBData.CANDREFTYP == "3")
                    objEntityDetails.DepartId = Convert.ToInt32(objclsWBData.CANDREFVAL);
                else if (objclsWBData.CANDREFTYP == "4")
                    objEntityDetails.EmpId = Convert.ToInt32(objclsWBData.CANDREFVAL);
                objEntityDetails.SkipIntrw = Convert.ToInt32(objclsWBData.CANDSKPINT);
                objEntityDetails.Visa = Convert.ToInt32(objclsWBData.CANDVISA);
                objEntityDetails.License = Convert.ToInt32(objclsWBData.CANDLICENSE);
                objEntityDetails.Passport = objclsWBData.CANDPASSPORT;
                objEntityDetails.Email = objclsWBData.CANDEMAIL;

                objEntityDetails.MobileNo = objclsWBData.CANDMOBILE;
                objEntityDetails.Gender = Convert.ToInt32(objclsWBData.CANDGENDER);

                objEntityDetails.ResumeType = 1;
                string strFileNameImport = objclsWBData.CANDDOCNAME;

                strFileNameImport = Path.GetFileNameWithoutExtension(strFileNameImport);
                if (intFileID == 0)
                {
                    //CANDIDATE_SELECTION_FILES
                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CANDIDATE_SELECTION_FILES);
                    objEntityCommon.CorporateID = objEntityCandidateSel.CorpOffice_Id;
                    objEntityCommon.Organisation_Id = objEntityCandidateSel.Organisation_Id;
                    string strNextFId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                    intFileID = Convert.ToInt32(strNextFId);

                }
                if (HiddenImportCheck.Value == "1")
                {
                    for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                    {

                        HttpPostedFile PostedFileimp = Request.Files[intCount];

                        if (PostedFileimp.ContentLength > 0)
                        {

                            string strFileName = System.IO.Path.GetFileName(PostedFileimp.FileName);
                            string strTempFileName = Path.GetFileNameWithoutExtension(strFileName);
                            // strFileName = GetFileName(strFileName);
                            if (strFileNameImport.ToLower() == strTempFileName.ToLower())
                            {
                                objEntityDetails.ActFileName = strFileName;
                                string strFileExt;
                                strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
                                string strImageName = "CAND_" + intFileID + "_" + intImgCount + "." + strFileExt;
                                objEntityDetails.FileName = strImageName;
                                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
                                PostedFileimp.SaveAs(Server.MapPath(strImagePath) + objEntityDetails.FileName);
                                intImgCount++;
                                objEntityInterviewCategoryDetilsList.Add(objEntityDetails);
                            }
                        }
                    }
                }
                else
                {
                    for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                    {
                        HttpPostedFile PostedFiles = Request.Files[intCount];
                        if (PostedFiles.ContentLength > 0)
                        {

                            string strFileName = System.IO.Path.GetFileName(PostedFiles.FileName);
                            string strTempFileName = Path.GetFileNameWithoutExtension(strFileName);
                            if (strFileNameImport.ToLower() == strTempFileName.ToLower())
                            {
                                objEntityDetails.ActFileName = strFileName;
                                string strFileExt;
                                strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
                                string strImageName = "CAND_" + intFileID + "_" + intImgCount + "." + strFileExt;
                                objEntityDetails.FileName = strImageName;
                                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
                                PostedFiles.SaveAs(Server.MapPath(strImagePath) + objEntityDetails.FileName);
                                intImgCount++;
                                objEntityInterviewCategoryDetilsList.Add(objEntityDetails);
                            }
                        }
                    }

                }


            }
            objBussinessCandidateSel.InsertCandidateSel(objEntityCandidateSel, objEntityInterviewCategoryDetilsList);
            if (clickedButton.ID == "btnSave")
            {
                string strEncId = Request.QueryString["Id"].ToString();
                Response.Redirect("gen_Candidate_Selection.aspx?id=" + strEncId + "&InsUpd=Save");
            }
            else if (clickedButton.ID == "btnSaveClose")
            {
                Response.Redirect("gen_Candidate_SelectionList.aspx?InsUpd=Save");
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ErrMsg", "ErrMsg();", true);
        }
    }
    private void EditView(int intId, int intEditOrView)
    {//when Editing or viewing
        //intEditOrView if 1-Edit,2-View
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCandidateSelection objEntityCandidateSel = new clsEntityCandidateSelection();
        clsBusinessLayerCandidateSelection objBussinessCandidateSel = new clsBusinessLayerCandidateSelection();
        objEntityCandidateSel.ManPwrRqstId = intId;


        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCandidateSel.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCandidateSel.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtCandidateList = new DataTable();

        objEntityCandidateSel.ManPwrRqstId = intId;
        hiddenManpwrId.Value = intId.ToString();

        objEntityCandidateSel.MstrResumeType = 1;
        dtCandidateList = objBussinessCandidateSel.ReadCandidateListByID(objEntityCandidateSel);

        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        HiddenFilePath.Value = strImagePath;
        if (dtCandidateList.Rows.Count > 0)
        {

            hiddenCandMasterID.Value = dtCandidateList.Rows[0]["CAND_MSTRID"].ToString();
            if (dtCandidateList.Rows[0]["INVTEM_STATUS"].ToString() == "1" && dtCandidateList.Rows[0]["INVTEM_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlInterviewTemp.Items.FindByText(dtCandidateList.Rows[0]["INVTEM_NAME"].ToString()) != null)
                {
                    ddlInterviewTemp.ClearSelection();
                    ddlInterviewTemp.Items.FindByText(dtCandidateList.Rows[0]["INVTEM_NAME"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lst = new ListItem(dtCandidateList.Rows[0]["INVTEM_NAME"].ToString(), dtCandidateList.Rows[0]["INVTEM_ID"].ToString());
                ddlInterviewTemp.Items.Insert(1, lst);

                SortDDL(ref this.ddlInterviewTemp);
                ddlInterviewTemp.ClearSelection();
                ddlInterviewTemp.Items.FindByText(dtCandidateList.Rows[0]["INVTEM_NAME"].ToString()).Selected = true;
            }

            string strManPowerReqCount = "0";
            strManPowerReqCount = objBussinessCandidateSel.CheckInterviewPanel(objEntityCandidateSel);
            string strNoDeleteCandList = "";
            HiddenNoDelIDs.Value = "";
            DataTable dtNoDelList = objBussinessCandidateSel.ReadNoDelCandidateList(objEntityCandidateSel);

            if (dtNoDelList.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtNoDelList.Rows.Count; intcnt++)
                {
                    strNoDeleteCandList += dtNoDelList.Rows[intcnt]["CAND_ID"].ToString() + ",";
                }
                HiddenNoDelIDs.Value = strNoDeleteCandList;
            }

            //string includes
            if (strManPowerReqCount != "0")
            {

                ddlInterviewTemp.Enabled = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "FocusFileUplod", "FocusFileUplod();", true);
            }
           

            DataTable dtDetail = new DataTable();

            dtDetail.Columns.Add("CAND_ID", typeof(int));
            dtDetail.Columns.Add("CAND_NAME", typeof(string));
            dtDetail.Columns.Add("CAND_LOC", typeof(string));
            dtDetail.Columns.Add("CNTRY_ID", typeof(string));
            dtDetail.Columns.Add("CAND_REF", typeof(string));
            dtDetail.Columns.Add("CAND_VAL", typeof(string));
            dtDetail.Columns.Add("CAND_SKPINT", typeof(string));
            dtDetail.Columns.Add("CAND_VISA", typeof(string));
            dtDetail.Columns.Add("CAND_LICENSE", typeof(string));
            dtDetail.Columns.Add("CAND_PASSPORTNO", typeof(string));
            dtDetail.Columns.Add("CAND_RESUMENAME", typeof(string));
            dtDetail.Columns.Add("CAND_ACT_RESUMENAME", typeof(string));
            dtDetail.Columns.Add("CAND_EMAIL", typeof(string));
            dtDetail.Columns.Add("CAND_MOBILE", typeof(string));
            dtDetail.Columns.Add("CAND_GENDER", typeof(string));


            for (int intcnt = 0; intcnt < dtCandidateList.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                //EditListRows(json[key].CAND_ID, json[key].CAND_NAME, json[key].CAND_LOC, json[key].CNTRY_ID, json[key].CAND_REF, json[key].CAND_VISA, json[key].CAND_LICENSE, json[key].CAND_PASSPORTNO, json[key].CAND_RESUMENAME, json[key].CAND_ACT_RESUMENAME, json[key].CAND_EMAIL);
                if (dtCandidateList.Rows[intcnt]["CAND_ID"].ToString() != "" && dtCandidateList.Rows[intcnt]["CAND_MSTR_TYPE"].ToString() == "1")
                {
                    drDtl["CAND_ID"] = Convert.ToInt32(dtCandidateList.Rows[intcnt]["CAND_ID"].ToString());
                    drDtl["CAND_NAME"] = dtCandidateList.Rows[intcnt]["CAND_NAME"].ToString();
                    drDtl["CAND_LOC"] = dtCandidateList.Rows[intcnt]["CAND_LOC"].ToString();
                    drDtl["CNTRY_ID"] = dtCandidateList.Rows[intcnt]["CNTRY_ID"].ToString();
                    drDtl["CAND_REF"] = dtCandidateList.Rows[intcnt]["CAND_REF"].ToString();
                    if (dtCandidateList.Rows[intcnt]["CAND_REF"].ToString()=="1")
                        drDtl["CAND_VAL"] = dtCandidateList.Rows[intcnt]["CNSLT_ID"].ToString();
                    else if (dtCandidateList.Rows[intcnt]["CAND_REF"].ToString() == "2")
                        drDtl["CAND_VAL"] = dtCandidateList.Rows[intcnt]["CPRDIV_ID"].ToString();
                    else if (dtCandidateList.Rows[intcnt]["CAND_REF"].ToString() == "3")
                        drDtl["CAND_VAL"] = dtCandidateList.Rows[intcnt]["CPRDEPT_ID"].ToString();
                    else if (dtCandidateList.Rows[intcnt]["CAND_REF"].ToString() == "4")
                        drDtl["CAND_VAL"] = dtCandidateList.Rows[intcnt]["USR_ID"].ToString();

                    drDtl["CAND_SKPINT"] = dtCandidateList.Rows[intcnt]["CAND_SKP_INTRV"].ToString();
                    drDtl["CAND_VISA"] = dtCandidateList.Rows[intcnt]["CAND_VISA"].ToString();
                    drDtl["CAND_LICENSE"] = dtCandidateList.Rows[intcnt]["CAND_LICENSE"].ToString();
                    drDtl["CAND_PASSPORTNO"] = dtCandidateList.Rows[intcnt]["CAND_PASSPORTNO"].ToString();
                    drDtl["CAND_RESUMENAME"] = dtCandidateList.Rows[intcnt]["CAND_RESUMENAME"].ToString();
                    drDtl["CAND_ACT_RESUMENAME"] = dtCandidateList.Rows[intcnt]["CAND_ACT_RESUMENAME"].ToString();
                    drDtl["CAND_EMAIL"] = dtCandidateList.Rows[intcnt]["CAND_EMAIL"].ToString();
                    drDtl["CAND_MOBILE"] = dtCandidateList.Rows[intcnt]["CAND_MOBILENO"].ToString();
                    drDtl["CAND_GENDER"] = dtCandidateList.Rows[intcnt]["CAND_GENDER"].ToString();

                    dtDetail.Rows.Add(drDtl);
                }

            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            if (intEditOrView == 1)
            {
                btnClear.Visible = false;
                btnSave.Visible = false;
                btnSaveClose.Visible = false;
                hiddenEdit.Value = strJson;
            }

        }
        else
        {
            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;

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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            if (Request.QueryString["Id"] != null)
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();
                clsEntityCommon objEntityCommon = new clsEntityCommon();
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsEntityCandidateSelection objEntityCandidateSel = new clsEntityCandidateSelection();
                clsBusinessLayerCandidateSelection objBussinessCandidateSel = new clsBusinessLayerCandidateSelection();
                int intUserId = 0;

                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityCandidateSel.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }


                if (Session["ORGID"] != null)
                {
                    objEntityCandidateSel.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
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

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityCandidateSel.ManPwrRqstId = Convert.ToInt32(strId);


                objEntityCandidateSel.User_Id = intUserId;
                objEntityCandidateSel.J_Date = System.DateTime.Now;
                objEntityCandidateSel.IntervTemplateId = Convert.ToInt32(ddlInterviewTemp.SelectedItem.Value);
                //
                if (hiddenCandMasterID.Value != "")
                {
                    objEntityCandidateSel.CandidateSelectionId = Convert.ToInt32(hiddenCandMasterID.Value);
                }
                if (HiddenField1.Value != "")
                {

                    List<clsEntityCandSelectionDtl> objEntityIntwCatDtlINSERTList = new List<clsEntityCandSelectionDtl>();

                    List<clsEntityCandSelectionDtl> objEntityIntwCatDtlUPDATEList = new List<clsEntityCandSelectionDtl>();
                    List<clsEntityCandSelectionDtl> objEntityIntwCatDtlDELETEList = new List<clsEntityCandSelectionDtl>();

                    string jsonData = HiddenField1.Value;
                    string c = jsonData.Replace("\"{", "\\{");
                    string d = c.Replace("\\n", "\r\n");
                    string g = d.Replace("\\", "");
                    string h = g.Replace("}\"]", "}]");
                    string i = h.Replace("}\",", "},");
                    List<clsWBData> objWBDataList = new List<clsWBData>();
                    //   UserData  data
                    objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(i);

                    int intImgCount = 0;
                    int intUPDCount = 0;
                    int intFileID = 0;
                    foreach (clsWBData objclsWBData in objWBDataList)
                    {
                        if (objclsWBData.EVTACTION == "INS")
                        {
                            clsEntityCandSelectionDtl objEntityDetails = new clsEntityCandSelectionDtl();
                            objEntityDetails.Candidatename = objclsWBData.CANDNAME;
                            objEntityDetails.Location = objclsWBData.CANDLOCAION;
                            objEntityDetails.CountryId = Convert.ToInt32(objclsWBData.CANDCOUNTRY);
                            if (objclsWBData.CANDREFTYP!=null&&objclsWBData.CANDREFTYP.ToString()!="")
                            objEntityDetails.RefType = Convert.ToInt32(objclsWBData.CANDREFTYP);
                            if (objclsWBData.CANDREFTYP == "1")
                                objEntityDetails.ConsultId = Convert.ToInt32(objclsWBData.CANDREFVAL);
                            else if (objclsWBData.CANDREFTYP == "2")
                                objEntityDetails.DivisionId = Convert.ToInt32(objclsWBData.CANDREFVAL);
                            else if (objclsWBData.CANDREFTYP == "3")
                                objEntityDetails.DepartId = Convert.ToInt32(objclsWBData.CANDREFVAL);
                            else if (objclsWBData.CANDREFTYP == "4")
                                objEntityDetails.EmpId = Convert.ToInt32(objclsWBData.CANDREFVAL);
                            objEntityDetails.SkipIntrw = Convert.ToInt32(objclsWBData.CANDSKPINT);
                            objEntityDetails.Visa = Convert.ToInt32(objclsWBData.CANDVISA);
                            objEntityDetails.License = Convert.ToInt32(objclsWBData.CANDLICENSE);
                            objEntityDetails.Passport = objclsWBData.CANDPASSPORT;
                            objEntityDetails.Email = objclsWBData.CANDEMAIL;

                            objEntityDetails.MobileNo = objclsWBData.CANDMOBILE;
                            objEntityDetails.Gender = Convert.ToInt32(objclsWBData.CANDGENDER);

                            string strFileNameImport = objclsWBData.CANDDOCNAME;

                            strFileNameImport = Path.GetFileNameWithoutExtension(strFileNameImport);
                            objEntityDetails.ResumeType = 1;

                            if (intFileID == 0)
                            {
                                //CANDIDATE_SELECTION_FILES
                                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CANDIDATE_SELECTION_FILES);
                                objEntityCommon.CorporateID = objEntityCandidateSel.CorpOffice_Id;
                                objEntityCommon.Organisation_Id = objEntityCandidateSel.Organisation_Id;
                                string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                                intFileID = Convert.ToInt32(strNextId);

                            }
                            if (HiddenImportCheck.Value == "1")
                            {
                                for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                                {

                                    HttpPostedFile PostedFileimp = Request.Files[intCount];

                                    if (PostedFileimp.ContentLength > 0)
                                    {

                                        string strFileName = System.IO.Path.GetFileName(PostedFileimp.FileName);
                                        string strTempFileName = Path.GetFileNameWithoutExtension(strFileName);
                                        // strFileName = GetFileName(strFileName);
                                        if (strFileNameImport.ToLower() == strTempFileName.ToLower())
                                        {
                                            objEntityDetails.ActFileName = strFileName;
                                            string strFileExt;
                                            strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                                            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
                                            string strImageName = "CAND_" + intFileID + "_" + intImgCount + "." + strFileExt;
                                            objEntityDetails.FileName = strImageName;
                                            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
                                            PostedFileimp.SaveAs(Server.MapPath(strImagePath) + objEntityDetails.FileName);
                                            intImgCount++;
                                            objEntityIntwCatDtlINSERTList.Add(objEntityDetails);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                                {
                                    HttpPostedFile PostedFiles = Request.Files[intCount];
                                    if (PostedFiles.ContentLength > 0)
                                    {

                                        string strFileName = System.IO.Path.GetFileName(PostedFiles.FileName);
                                        string strTempFileName = Path.GetFileNameWithoutExtension(strFileName);
                                        if (strFileNameImport.ToLower() == strTempFileName.ToLower())
                                        {
                                            objEntityDetails.ActFileName = strFileName;
                                            string strFileExt;
                                            strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                                            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
                                            string strImageName = "CAND_" + intFileID + "_" + intImgCount + "." + strFileExt;
                                            objEntityDetails.FileName = strImageName;
                                            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
                                            PostedFiles.SaveAs(Server.MapPath(strImagePath) + objEntityDetails.FileName);
                                            intImgCount++;
                                            objEntityIntwCatDtlINSERTList.Add(objEntityDetails);
                                        }
                                    }
                                }

                            }
                        }
                        else if (objclsWBData.EVTACTION == "UPD")
                        {

                            clsEntityCandSelectionDtl objEntityDetails = new clsEntityCandSelectionDtl();
                            objEntityDetails.CandDtlId = Convert.ToInt32(objclsWBData.DTLID);
                            objEntityDetails.Candidatename = objclsWBData.CANDNAME;
                            objEntityDetails.Location = objclsWBData.CANDLOCAION;
                            objEntityDetails.CountryId = Convert.ToInt32(objclsWBData.CANDCOUNTRY);
                            if (objclsWBData.CANDREFTYP != null && objclsWBData.CANDREFTYP.ToString() != "")
                            objEntityDetails.RefType = Convert.ToInt32(objclsWBData.CANDREFTYP);
                            if (objclsWBData.CANDREFTYP == "1")
                                objEntityDetails.ConsultId = Convert.ToInt32(objclsWBData.CANDREFVAL);
                            else if (objclsWBData.CANDREFTYP == "2")
                                objEntityDetails.DivisionId = Convert.ToInt32(objclsWBData.CANDREFVAL);
                            else if (objclsWBData.CANDREFTYP == "3")
                                objEntityDetails.DepartId = Convert.ToInt32(objclsWBData.CANDREFVAL);
                            else if (objclsWBData.CANDREFTYP == "4")
                                objEntityDetails.EmpId = Convert.ToInt32(objclsWBData.CANDREFVAL);
                            objEntityDetails.SkipIntrw = Convert.ToInt32(objclsWBData.CANDSKPINT);
                            objEntityDetails.Visa = Convert.ToInt32(objclsWBData.CANDVISA);
                            objEntityDetails.License = Convert.ToInt32(objclsWBData.CANDLICENSE);
                            objEntityDetails.Passport = objclsWBData.CANDPASSPORT;
                            objEntityDetails.Email = objclsWBData.CANDEMAIL;
                            objEntityDetails.ResumeType = 1;

                            objEntityDetails.MobileNo = objclsWBData.CANDMOBILE;
                            objEntityDetails.Gender = Convert.ToInt32(objclsWBData.CANDGENDER);

                            objEntityIntwCatDtlUPDATEList.Add(objEntityDetails);
                            intUPDCount++;
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
                            clsEntityCandSelectionDtl objEntityDetails = new clsEntityCandSelectionDtl();
                            objEntityDetails.CandDtlId = Convert.ToInt32(strDtlId);
                            objEntityIntwCatDtlDELETEList.Add(objEntityDetails);
                        }
                    }

                    objBussinessCandidateSel.UpdateCandidateSel(objEntityCandidateSel, objEntityIntwCatDtlINSERTList, objEntityIntwCatDtlUPDATEList, objEntityIntwCatDtlDELETEList);
                    string strCanclFileName = "";
                    string[] strarrCanclFileNames = strCanclFileName.Split(',');
                    if (HiddenDelFiles.Value != "" && HiddenDelFiles.Value != null)
                    {
                        strCanclFileName = HiddenDelFiles.Value;
                        strarrCanclFileNames = strCanclFileName.Split(',');

                    }
                    string strFilePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
                    foreach (string strDtlName in strarrCanclFileNames)
                    {
                        if (strDtlName != "" && strDtlName != null)
                        {
                            //int intDtlId = strDtlName;
                            string strFileLocation = strFilePath + strDtlName;
                            File.Delete(MapPath(strFileLocation));
                        }
                    }


                }

                if (clickedButton.ID == "btnUpdate")
                {
                    string strEncId = Request.QueryString["Id"].ToString();
                    Response.Redirect("gen_Candidate_Selection.aspx?id=" + strEncId + "&InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Candidate_SelectionList.aspx?InsUpd=Upd");
                }

            }
            else
            {

                Response.Redirect("~/Default.aspx");

            }
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ErrMsg", "ErrMsg();", true);
        }
    }

    protected void btnCSVPrcd_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCandidateSelection objEntityCandidateSel = new clsEntityCandidateSelection();
        clsBusinessLayerCandidateSelection objBussinessCandidateSel = new clsBusinessLayerCandidateSelection();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCandidateSel.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCandidateSel.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityCandidateSel.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityCandidateSel.J_Date = System.DateTime.Now;

        string strFilePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);

        //for delete all the files in the specific folder.
        Array.ForEach(Directory.GetFiles(Server.MapPath(strFilePath)), File.Delete);

        if (FileUploader.HasFile)
        {
            FileUploader.SaveAs(Server.MapPath(strFilePath) + FileUploader.PostedFile.FileName);
        }

        string strData = Server.MapPath(strFilePath) + "/" + FileUploader.PostedFile.FileName;
        try
        {
            var OuterLines = new List<string[]>();
            var CodeCorrectList = new List<string[]>();
            var CodeMissingList = new List<string[]>();
            var CodeIncorrectList = new List<string[]>();
            var CodeDuplicateList = new List<string[]>();
            var ExceedLengthItem = new List<string[]>();
            bool blHeader = false;

            using (CsvFileReader reader = new CsvFileReader(strData))
            {
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {
                    string[] Line = row.ToArray();
                    OuterLines.Add(Line);
                }

            }


            var OuterLinesCopy = new List<string[]>(OuterLines);
            OuterLinesCopy = OuterLines.ToList();

            for (int intRow = OuterLinesCopy.Count - 1; intRow >= 0; intRow--)
            {
                for (int i = 0; i < 10; i++)
                {

                    //For removing <> 
                    string strItem = OuterLinesCopy[intRow][i].ToString().ToUpper();
                    strItem = strItem.Replace("<", string.Empty);
                    strItem = strItem.Replace(">", string.Empty);
                    OuterLinesCopy[intRow][i] = strItem;

                    //checking missing values
                    if (OuterLinesCopy[intRow][i] == null || OuterLinesCopy[intRow][i] == "")
                    {
                        CodeMissingList.Add(OuterLinesCopy[intRow]);
                        if (OuterLines.Count >= intRow)
                            OuterLines.RemoveAt(intRow);
                        break;
                    }
                }
            }

            for (int intRow = OuterLines.Count - 1; intRow >= 0; intRow--)
            {

                string strCountryName = OuterLines[intRow][2].ToString();
                string visa = OuterLines[intRow][3].ToString();
                string Lisence = OuterLines[intRow][4].ToString();
                //string strRefTyp = OuterLines[intRow][8].ToString();
                //string strRefVal = OuterLines[intRow][9].ToString();
                //string strSkipInterview = OuterLines[intRow][10].ToString();

                DataTable dtCountryList = new DataTable();
                DataTable dtConsultList = new DataTable();
                DataTable dtDivisionList = new DataTable();
                DataTable dtDepartList = new DataTable();
                DataTable dtEmpList = new DataTable();
                dtCountryList = objBussinessCandidateSel.ReadCountry();
                dtConsultList = objBussinessCandidateSel.ReadConsultancies(objEntityCandidateSel);
                dtDivisionList = objBussinessCandidateSel.ReadDivision(objEntityCandidateSel);
                dtDepartList = objBussinessCandidateSel.ReadDepartment(objEntityCandidateSel);

                dtCountryList.TableName = "dtTableCountry";
                string result;
                using (StringWriter sw = new StringWriter())
                {
                    dtCountryList.WriteXml(sw);
                    result = sw.ToString();
                }
                hiddenCountryDdlData.Value = result;

                bool existsCountry = dtCountryList.Select().ToList().Exists(row => row["CNTRY_NAME"].ToString().ToUpper() == strCountryName.ToUpper());
                bool existsDivision = false;
                bool existConsult = false;
                bool ExistDepart = false;
                bool ExistEmployee = false;
                //if not exist
                //int RefTyp = 0;
                //if (strRefTyp == "CONSULTANCY" || strRefTyp == "DIVISION" || strRefTyp == "DEPARTMENT" || strRefTyp == "EMPLOYEE")
                //{
                //    RefTyp = 1;

                //    if (strRefTyp == "CONSULTANCY")
                //    {
                //        if (strRefVal != "")
                //        {
                //            existConsult = dtConsultList.Select().ToList().Exists(row => row["CNSLT_NAME"].ToString().ToUpper() == strRefVal.ToUpper());
                //        }
                //    }
                //    else if (strRefTyp == "DIVISION")
                //    {
                //        if (strRefVal != "")
                //        {
                //            existsDivision = dtDivisionList.Select().ToList().Exists(row => row["CPRDIV_NAME"].ToString().ToUpper() == strRefVal.ToUpper());
                //        }
                //    }
                //    else if (strRefTyp == "DEPARTMENT")
                //    {
                //        if (strRefVal != "")
                //        {
                //            ExistDepart = dtDivisionList.Select().ToList().Exists(row => row["CPRDEPT_NAME"].ToString().ToUpper() == strRefVal.ToUpper());
                //        }
                //    }
                //    else if (strRefTyp == "EMPLOYEE")
                //    {
                //        if (strRefVal != "")
                //        {
                //            ExistEmployee = dtDivisionList.Select().ToList().Exists(row => row["USR_NAME"].ToString().ToUpper() == strRefVal.ToUpper());
                //        }
                //    }
                //}
                int visaExist = 0;
                if (visa.ToUpper() == "YES" || visa.ToUpper() == "NO")
                {
                    visaExist = 1;
                }
                int LisenceExist = 0;
                if (Lisence.ToUpper() == "YES" || Lisence.ToUpper() == "NO")
                {
                    LisenceExist = 1;
                }
                //int SkipIntExist = 0;
                //if (strSkipInterview.ToUpper() == "YES" || strSkipInterview.ToUpper() == "NO")
                //{
                //    SkipIntExist = 1;
                //}

                //if (existsCountry == false || RefTyp == 0 || visaExist == 0 || LisenceExist == 0 || SkipIntExist == 0 || (RefTyp == 1 && existConsult == false && ExistDepart == false && existsDivision == false && ExistEmployee == false))
                //{

                //    CodeMissingList.Add(OuterLines[intRow]);

                //    OuterLines.RemoveAt(intRow);
                //    goto outerLabel;

                //}

                if (existsCountry == false || visaExist == 0 || LisenceExist == 0)
                {

                    CodeMissingList.Add(OuterLines[intRow]);

                    OuterLines.RemoveAt(intRow);
                    goto outerLabel;

                }


            outerLabel: ;
            }



            string strCodeCorrectListCopyJson = ConvertArrayToJson(OuterLines);
            HiddenCorrectListCopy.Value = strCodeCorrectListCopyJson;

            DataTable dtDetail = new DataTable();

            dtDetail.Columns.Add("CAND_NAME", typeof(string));
            dtDetail.Columns.Add("CAND_LOC", typeof(string));
            dtDetail.Columns.Add("CNTRY_ID", typeof(string));
            dtDetail.Columns.Add("CAND_VISA", typeof(string));
            dtDetail.Columns.Add("CAND_LICENSE", typeof(string));
            dtDetail.Columns.Add("CAND_PASSPORTNO", typeof(string));
            dtDetail.Columns.Add("CAND_EMAIL", typeof(string));
            dtDetail.Columns.Add("CAND_RESUMENAME", typeof(string));
            dtDetail.Columns.Add("CAND_REF", typeof(string));
            dtDetail.Columns.Add("CAND_VAL", typeof(string));
            dtDetail.Columns.Add("CAND_SKPINT", typeof(string));

            dtDetail.Columns.Add("CAND_MOBILE", typeof(string));
            dtDetail.Columns.Add("CAND_GENDER", typeof(string));

            for (int intRow = OuterLines.Count - 1; intRow >= 0; intRow--)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["CAND_NAME"] = OuterLines[intRow][0].ToString();
                drDtl["CAND_LOC"] = OuterLines[intRow][1].ToString();
                drDtl["CNTRY_ID"] = OuterLines[intRow][2].ToString();

                drDtl["CAND_VISA"] = OuterLines[intRow][3].ToString();
                drDtl["CAND_LICENSE"] = OuterLines[intRow][4].ToString();

                drDtl["CAND_PASSPORTNO"] = OuterLines[intRow][5].ToString();
                drDtl["CAND_EMAIL"] = OuterLines[intRow][6].ToString();
                drDtl["CAND_RESUMENAME"] = OuterLines[intRow][9].ToString();
                //if (OuterLines[intRow][8].ToString() == "CONSULTANCY")
                //{
                //    drDtl["CAND_REF"] = "1";
                //    drDtl["CAND_VAL"] = OuterLines[intRow][9].ToString();
                //}
                //else if (OuterLines[intRow][8].ToString() == "DIVISION")
                //{
                //    drDtl["CAND_REF"] = "2";
                //    drDtl["CAND_VAL"] = OuterLines[intRow][9].ToString();
                //}
                //else if (OuterLines[intRow][8].ToString() == "DEPARTMENT")
                //{
                //    drDtl["CAND_REF"] = "3";
                //    drDtl["CAND_VAL"] = OuterLines[intRow][9].ToString();
                //}
                //else if (OuterLines[intRow][8].ToString() == "EMPLOYEE")
                //{
                //    drDtl["CAND_REF"] = "4";
                //    drDtl["CAND_VAL"] = OuterLines[intRow][9].ToString();
                //}

                //drDtl["CAND_SKPINT"] = OuterLines[intRow][10].ToString();


                drDtl["CAND_REF"] = 0;
                drDtl["CAND_VAL"] = 0;
                drDtl["CAND_SKPINT"] = 0;


                drDtl["CAND_MOBILE"] = OuterLines[intRow][7].ToString();
                if (OuterLines[intRow][8].ToString() == "MALE")
                {
                    drDtl["CAND_GENDER"] = "0";
                }
                else if (OuterLines[intRow][8].ToString() == "FEMALE")
                {
                    drDtl["CAND_GENDER"] = "1";
                }

                dtDetail.Rows.Add(drDtl);

            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            HiddenjsonImport.Value = strJson;

            CodeMissingList.Reverse();
            HiddenCodeMissingCount.Value = CodeMissingList.Count.ToString();

        }
        catch
        {
            Response.Redirect("gen_Candidate_Selection.aspx?InsUpd=Err");
        }

    }

    private string ConvertArrayToJson(List<string[]> strArrayList)
    {
        string strjson = JsonConvert.SerializeObject(strArrayList);
        return strjson;
    }

    /// Class to read data from a CSV file
    /// </summary>
    public class CsvFileReader : StreamReader
    {
        public CsvFileReader(Stream stream)
            : base(stream)
        {
        }

        public CsvFileReader(string filename)
            : base(filename)
        {
        }

        /// <summary>
        /// Reads a row of data from a CSV file
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool ReadRow(CsvRow row)
        {
            row.LineText = ReadLine();
            if (String.IsNullOrEmpty(row.LineText))
                return false;

            int pos = 0;
            int rows = 0;

            while (pos < row.LineText.Length)
            {
                string value;

                // Special handling for quoted field
                if (row.LineText[pos] == '"')
                {
                    // Skip initial quote
                    pos++;

                    // Parse quoted value
                    int start = pos;
                    while (pos < row.LineText.Length)
                    {
                        // Test for quote character
                        if (row.LineText[pos] == '"')
                        {
                            // Found one
                            pos++;

                            // If two quotes together, keep one
                            // Otherwise, indicates end of value
                            if (pos >= row.LineText.Length || row.LineText[pos] != '"')
                            {
                                pos--;
                                break;
                            }
                        }
                        pos++;
                    }
                    value = row.LineText.Substring(start, pos - start);
                    value = value.Replace("\"\"", "\"");
                }
                else
                {
                    // Parse unquoted value
                    int start = pos;
                    while (pos < row.LineText.Length && row.LineText[pos] != ',')
                        pos++;
                    value = row.LineText.Substring(start, pos - start);
                }

                // Add field to list
                if (rows < row.Count)
                    row[rows] = value;
                else
                    row.Add(value);
                rows++;

                // Eat up to and including next comma
                while (pos < row.LineText.Length && row.LineText[pos] != ',')
                    pos++;
                if (pos < row.LineText.Length)
                    pos++;
            }
            // Delete any unused items
            while (row.Count > rows)
                row.RemoveAt(rows);

            // Return true if any columns read
            return (row.Count > 0);
        }
    }
    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }
    //for sorting drop down
    private void SortDDL(ref DropDownList objDDL)
    {
        ArrayList textList = new ArrayList();
        ArrayList valueList = new ArrayList();


        foreach (ListItem li in objDDL.Items)
        {
            textList.Add(li.Text);
        }

        textList.Sort();


        foreach (object item in textList)
        {
            string value = objDDL.Items.FindByText(item.ToString()).Value;
            valueList.Add(value);
        }
        objDDL.Items.Clear();

        for (int i = 0; i < textList.Count; i++)
        {
            ListItem objItem = new ListItem(textList[i].ToString(), valueList[i].ToString());
            objDDL.Items.Add(objItem);
        }
    }
}





