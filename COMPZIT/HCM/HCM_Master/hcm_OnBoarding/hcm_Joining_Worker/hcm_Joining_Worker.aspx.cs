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
using System.IO;
public partial class HCM_HCM_Master_hcm_OnBoarding_hcm_Joining_Worker_hcm_JoiningWorker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlCandidateName.Focus();
            LoadCandidates();
            txtWorkerName.Enabled = false;
            txtDesignation.Enabled = false;
            txtDivision.Enabled = false;
            HiddenDelView.Value = "";
            btnRegCandidate.Visible = false;
            hiddenWrkId.Value = "0";
            //NEW
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();           
            //Creating objects for business layer
            clsEntityJoiningWorker objEntityJoiningWorker = new clsEntityJoiningWorker();
            clsBusinessLayerJoiningWorker objBusinessLayerJoiningWorker = new clsBusinessLayerJoiningWorker();
            int intUserId = 0, intUsrRolMstrId = 0, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableCnfrmSts = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityJoiningWorker.UserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityJoiningWorker.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                HiddenCorpid.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityJoiningWorker.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                HiddenOrgid.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            //Allocating child roles          
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Joining_Worker);
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
                        intEnableCnfrmSts = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }

                }
            }
            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdateClose.Visible = true;

            }
            else
            {
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = true;
            }
            int intImageMaxSize = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SIZE.JOINING_WORKER_DOCUMENTS);
            hiddenLicenceFileSize.Value = intImageMaxSize.ToString();
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                hiddenWrkId.Value = strId;
                Update(strId, intCorpId, intOrgId);
                lblEntry.Text = "Edit Worker";
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnRegCandidate.Visible = false;
                if (intEnableCnfrmSts != Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnCnfrmSts.Visible = false;
                }
            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                // HiddenViewId.Value = strId;
                Update(strId, intCorpId, intOrgId);

                //img1.Disabled = true;
                lblEntry.Text = "View Worker";
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                txtJoiningDate.Enabled = false;
                txtPassportNo.Enabled = false;
                txtFormFillingDate.Enabled = false;
                txtSiteNo.Enabled = false;
                FileUploadCertificates.Enabled = false;
                FileUploadLicence.Enabled = false;
                txtComments.Enabled = false;
                btnCnfrmSts.Visible = false;
                //  txtCntctName.Enabled = false;
                HiddenDelView.Value = "true";
               

            }
            else
            {
                lblEntry.Text = "Add Worker";
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;
                btnCnfrmSts.Visible = false;
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
                ddlCandidateName.Focus();
            }
        }
    }


    public void LoadCandidates()
    {
        clsEntityJoiningWorker objEntityJoiningWorker = new clsEntityJoiningWorker();
        clsBusinessLayerJoiningWorker objBusinessLayerJoiningWorker = new clsBusinessLayerJoiningWorker();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningWorker.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJoiningWorker.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJoiningWorker.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBusinessLayerJoiningWorker.ReadCandidate(objEntityJoiningWorker);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlCandidateName.DataSource = dtSubConrt;
            ddlCandidateName.DataTextField = "CAND_NAME";
            ddlCandidateName.DataValueField = "CAND_ID";
            ddlCandidateName.DataBind();

        }

        ddlCandidateName.Items.Insert(0, "--SELECT CANDIDATE--");


    }
    public class clsOtherDocuAttchDELETE
    {
        public string FILENAME { get; set; }

        public string DTLID { get; set; }

    }

    public void updateData()
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityJoiningWorker objEntityJoiningWorker = new clsEntityJoiningWorker();
        clsBusinessLayerJoiningWorker objBusinessLayerJoiningWorker = new clsBusinessLayerJoiningWorker();
        int intUserId = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningWorker.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }


        if (Session["ORGID"] != null)
        {
            objEntityJoiningWorker.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
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
        objEntityJoiningWorker.WorkerName = txtWorkerName.Text.Trim();

        objEntityJoiningWorker.UserId = Convert.ToInt32(hiddenCandID.Value);
        DataTable dtCandDtls = objBusinessLayerJoiningWorker.ReadCandidateData(objEntityJoiningWorker);
        if (dtCandDtls.Rows.Count > 0)
        {
            objEntityJoiningWorker.CandidateID = Convert.ToInt32(dtCandDtls.Rows[0]["CAND_ID"].ToString());
            objEntityJoiningWorker.Designation = Convert.ToInt32(dtCandDtls.Rows[0]["DSGN_ID"].ToString());
            objEntityJoiningWorker.Division = Convert.ToInt32(dtCandDtls.Rows[0]["CPRDIV_ID"].ToString());
        }

        objEntityJoiningWorker.PassportNo = txtPassportNo.Text.Trim();
        if (txtJoiningDate.Text.Trim() != "")
        {
            objEntityJoiningWorker.JoiningDate = objCommon.textToDateTime(txtJoiningDate.Text);
        }
        objEntityJoiningWorker.FormFillDate = objCommon.textToDateTime(txtFormFillingDate.Text.Trim());
        objEntityJoiningWorker.SiteNo = txtSiteNo.Text.Trim();
        objEntityJoiningWorker.Comments = txtComments.Text.Trim();
        // ID
        string strRandomMixedId = Request.QueryString["Id"].ToString();
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strWaterRechId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityJoiningWorker.WorkerID = Convert.ToInt32(strWaterRechId);
        objEntityJoiningWorker.UserId = intUserId;
        objEntityJoiningWorker.Date = System.DateTime.Now;
        //licence
        int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_LICENCE);
        string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_LICENCE);
        if (FileUploadLicence.HasFile)
        {
            // GET FILE EXTENSION
            string strFileExt;
            objEntityJoiningWorker.LicenceActualName = FileUploadLicence.FileName;
            strFileExt = FileUploadLicence.FileName.Substring(FileUploadLicence.FileName.LastIndexOf('.') + 1).ToLower();
            string strImageName = intImageSection.ToString() + "_" + objEntityJoiningWorker.WorkerID + "." + strFileExt;
            objEntityJoiningWorker.LicenceFileName = strImageName;
        }
        else
        {

            if (hiddenLicenceFile.Value == "")
            {
                objEntityJoiningWorker.LicenceFileName = "";
                objEntityJoiningWorker.LicenceActualName = "";

            }
            else
            {
                objEntityJoiningWorker.LicenceFileName = hiddenLicenceFile.Value;
                objEntityJoiningWorker.LicenceActualName = hiddenLicenceFileAct.Value;
            }
        }
        //certificate
        int intImageSectionCertificate = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_CERTIFICATE);
        string strImgPathCertificate = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_CERTIFICATE);
        if (FileUploadCertificates.HasFile)
        {
            // GET FILE EXTENSION
            string strFileExt;
            objEntityJoiningWorker.CertificateActualName = FileUploadCertificates.FileName;
            strFileExt = FileUploadCertificates.FileName.Substring(FileUploadCertificates.FileName.LastIndexOf('.') + 1).ToLower();
            string strImageName = intImageSectionCertificate.ToString() + "_" + objEntityJoiningWorker.WorkerID + "." + strFileExt;
            objEntityJoiningWorker.CertificateFileName = strImageName;
        }
        else
        {

            if (hiddenCertificatesFile.Value == "")
            {
                objEntityJoiningWorker.CertificateFileName = "";
                objEntityJoiningWorker.CertificateActualName = "";

            }
            else
            {
                objEntityJoiningWorker.CertificateFileName = hiddenCertificatesFile.Value;
                objEntityJoiningWorker.CertificateActualName = hiddenCertificatesFileAct.Value;
            }
        }

        string jsonData = HiddenField2_FileUpload.Value;
        string c = jsonData.Replace("\"{", "\\{");
        string d = c.Replace("\\n", "\r\n");
        string g = d.Replace("\\", "");
        string h = g.Replace("}\"]", "}]");
        string i = h.Replace("}\",", "},");

        List<clsAtchmntData> objTVDataList = new List<clsAtchmntData>();
        objTVDataList = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);

        List<clsJoiningWorkerDtl> objEntityJoiningWorkerDetilsList = new List<clsJoiningWorkerDtl>();



        if (HiddenField2_FileUpload.Value != "" && HiddenField2_FileUpload.Value != null)
        {


            for (int count = 0; count < objTVDataList.Count; count++)
            {
                string jsonFileid = "file" + objTVDataList[count].ROWID;
                for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                {

                    string fileId = Request.Files.AllKeys[intCount].ToString();
                    HttpPostedFile PostedFile = Request.Files[intCount];
                    if (fileId == jsonFileid)
                    {
                        if (PostedFile.ContentLength > 0)
                        {
                            clsJoiningWorkerDtl objEntityJWorkerDtl = new clsJoiningWorkerDtl();
                            string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                            objEntityJWorkerDtl.OtherDocuActualName = strFileName;
                            string strFileExt;

                            strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                            int intImageSectionOtherDocu = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_DOCUMENTS);
                            string strImageName = "DOC_" + intImageSectionOtherDocu.ToString() + "_" + objEntityJoiningWorker.WorkerID.ToString() + "_" + count + "." + strFileExt;
                            objEntityJWorkerDtl.OtherDocuFileName = strImageName;
                            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_DOCUMENTS);

                            PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityJWorkerDtl.OtherDocuFileName);
                            objEntityJoiningWorkerDetilsList.Add(objEntityJWorkerDtl);

                        }
                    }
                }
            }
        }





        //start-for deleting attached files
        //for permit files
        string strCanclDtlId = "";
        string[] strarrCancldtlIds = strCanclDtlId.Split(',');
        if (hiddenPerFileCanclDtlId.Value != "" && hiddenPerFileCanclDtlId.Value != null)
        {
            strCanclDtlId = hiddenPerFileCanclDtlId.Value;
            strarrCancldtlIds = strCanclDtlId.Split(',');

        }

        List<clsJoiningWorkerDtl> objEntityPerDeleteAttchmntDeatilsList = new List<clsJoiningWorkerDtl>();

        if (hiddenPerFileCanclDtlId.Value != "" && hiddenPerFileCanclDtlId.Value != null)
        {
            string jsonDataDltAttch = hiddenPerFileCanclDtlId.Value;
            string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
            string strAtt2 = strAtt1.Replace("\\", "");
            string strAtt3 = strAtt2.Replace("}\"]", "}]");
            string strAtt4 = strAtt3.Replace("}\",", "},");
            List<clsOtherDocuAttchDELETE> objVhclDataDltAttList = new List<clsOtherDocuAttchDELETE>();
            //   UserData  data
            objVhclDataDltAttList = JsonConvert.DeserializeObject<List<clsOtherDocuAttchDELETE>>(strAtt4);


            foreach (clsOtherDocuAttchDELETE objClsVhclDltAttData in objVhclDataDltAttList)
            {

                clsJoiningWorkerDtl objEntityRnwlDetailsAttchmnt = new clsJoiningWorkerDtl();

                objEntityRnwlDetailsAttchmnt.WorkerDetailID = Convert.ToInt32(objClsVhclDltAttData.DTLID);
                objEntityRnwlDetailsAttchmnt.OtherDocuFileName = Convert.ToString(objClsVhclDltAttData.FILENAME);

                objEntityPerDeleteAttchmntDeatilsList.Add(objEntityRnwlDetailsAttchmnt);


            }
        }


        objBusinessLayerJoiningWorker.UpdateJoiningWorker(objEntityJoiningWorker, objEntityJoiningWorkerDetilsList, objEntityPerDeleteAttchmntDeatilsList);

        if (FileUploadLicence.HasFile)
        {
            if (hiddenLicenceFileDeleted.Value != "")
            {
                string imageLocation = strImgPath + hiddenLicenceFileDeleted.Value;
                if (File.Exists(MapPath(imageLocation)))
                {
                    File.Delete(MapPath(imageLocation));
                }
            }
            FileUploadLicence.SaveAs(Server.MapPath(strImgPath) + objEntityJoiningWorker.LicenceFileName);
        }
        else
        {
            if (hiddenLicenceFile.Value == "")
            {
                if (hiddenLicenceFileDeleted.Value != "")
                {
                    string imageLocation = strImgPath + hiddenLicenceFileDeleted.Value;
                    if (File.Exists(MapPath(imageLocation)))
                    {
                        File.Delete(MapPath(imageLocation));
                    }
                }
            }
        }
        //certificate
        if (FileUploadCertificates.HasFile)
        {
            if (hiddenCertificatesFileDeleted.Value != "")
            {
                string imageLocation = strImgPathCertificate + hiddenCertificatesFileDeleted.Value;
                if (File.Exists(MapPath(imageLocation)))
                {
                    File.Delete(MapPath(imageLocation));
                }
            }
            FileUploadCertificates.SaveAs(Server.MapPath(strImgPathCertificate) + objEntityJoiningWorker.CertificateFileName);
        }
        else
        {
            if (hiddenCertificatesFile.Value == "")
            {
                if (hiddenCertificatesFileDeleted.Value != "")
                {
                    string imageLocation = strImgPathCertificate + hiddenCertificatesFileDeleted.Value;
                    if (File.Exists(MapPath(imageLocation)))
                    {
                        File.Delete(MapPath(imageLocation));
                    }
                }
            }
        }
    
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;

            updateData();
            //Delete files

            if (clickedButton.ID == "btnUpdate")
            {
                Response.Redirect("hcm_Joining_Worker.aspx?InsUpd=Upd");
            }
            else if (clickedButton.ID == "btnUpdateClose")
            {
                Response.Redirect("hcm_Joining_WorkerList.aspx?InsUpd=Upd");
            }

        }
        catch (Exception ex)
        {
            //throw ex;
            //ScriptManager.RegisterStartupScript(this, GetType(), "ErrMsg", "ErrMsg();", true);
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            clsEntityJoiningWorker objEntityJoiningWorker = new clsEntityJoiningWorker();
            clsBusinessLayerJoiningWorker objBusinessLayerJoiningWorker = new clsBusinessLayerJoiningWorker();
            int intUserId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityJoiningWorker.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }


            if (Session["ORGID"] != null)
            {
                objEntityJoiningWorker.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
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
            objEntityJoiningWorker.WorkerName = txtWorkerName.Text.Trim();

            if (ddlCandidateName.SelectedItem.Value != "--SELECT CANDIDATE--")
            {
                objEntityJoiningWorker.UserId = Convert.ToInt32(ddlCandidateName.SelectedItem.Value);
                DataTable dtCandDtls = objBusinessLayerJoiningWorker.ReadCandidateData(objEntityJoiningWorker);
                if (dtCandDtls.Rows.Count > 0)
                {
                    objEntityJoiningWorker.CandidateID = Convert.ToInt32(dtCandDtls.Rows[0]["CAND_ID"].ToString());
                    objEntityJoiningWorker.Designation = Convert.ToInt32(dtCandDtls.Rows[0]["DSGN_ID"].ToString());
                    objEntityJoiningWorker.Division = Convert.ToInt32(dtCandDtls.Rows[0]["CPRDIV_ID"].ToString());
                }
            }
            objEntityJoiningWorker.PassportNo = txtPassportNo.Text.Trim();
            if (txtJoiningDate.Text.Trim() != "")
            {
                objEntityJoiningWorker.JoiningDate = objCommon.textToDateTime(txtJoiningDate.Text);
            }
            objEntityJoiningWorker.FormFillDate = objCommon.textToDateTime(txtFormFillingDate.Text);
            objEntityJoiningWorker.SiteNo = txtSiteNo.Text.Trim();
            objEntityJoiningWorker.Comments = txtComments.Text.Trim();
            // ID
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOINING_WORKER);
            objEntityCommon.CorporateID = objEntityJoiningWorker.CorpId;
            objEntityCommon.Organisation_Id = objEntityJoiningWorker.OrgId;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            objEntityJoiningWorker.WorkerID = Convert.ToInt32(strNextId);
           
            objEntityJoiningWorker.UserId = intUserId;
            objEntityJoiningWorker.Date = System.DateTime.Now;
            //licence
            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_LICENCE);
            string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_LICENCE);
            if (FileUploadLicence.HasFile)
            {
                // GET FILE EXTENSION

                string strFileExt;
                objEntityJoiningWorker.LicenceActualName = FileUploadLicence.FileName;
                strFileExt = FileUploadLicence.FileName.Substring(FileUploadLicence.FileName.LastIndexOf('.') + 1).ToLower();

                string strImageName = intImageSection.ToString() + "_" + objEntityJoiningWorker.WorkerID + "." + strFileExt;
                objEntityJoiningWorker.LicenceFileName = strImageName;


            }
            //certificate
            int intImageSectionCertificate = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_CERTIFICATE);
            string strImgPathCertificate = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_CERTIFICATE);
            if (FileUploadCertificates.HasFile)
            {
                // GET FILE EXTENSION
                string strFileExt;
                objEntityJoiningWorker.CertificateActualName = FileUploadCertificates.FileName;
                strFileExt = FileUploadCertificates.FileName.Substring(FileUploadCertificates.FileName.LastIndexOf('.') + 1).ToLower();
                string strImageName = intImageSectionCertificate.ToString() + "_" + objEntityJoiningWorker.WorkerID + "." + strFileExt;
                objEntityJoiningWorker.CertificateFileName = strImageName;
            }

            string jsonData = HiddenField2_FileUpload.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");

            List<clsAtchmntData> objTVDataList = new List<clsAtchmntData>();
            objTVDataList = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);

            List<clsJoiningWorkerDtl> objEntityJoiningWorkerDetilsList = new List<clsJoiningWorkerDtl>();

            if (HiddenField2_FileUpload.Value != "" && HiddenField2_FileUpload.Value != null)
            {


                for (int count = 0; count < objTVDataList.Count; count++)
                {
                    string jsonFileid = "file" + objTVDataList[count].ROWID;
                    for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                    {

                        string fileId = Request.Files.AllKeys[intCount].ToString();
                        HttpPostedFile PostedFile = Request.Files[intCount];
                        if (fileId == jsonFileid)
                        {
                            if (PostedFile.ContentLength > 0)
                            {
                                clsJoiningWorkerDtl objEntityJWorkerDtl = new clsJoiningWorkerDtl();
                                string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                objEntityJWorkerDtl.OtherDocuActualName = strFileName;
                                string strFileExt;

                                strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                                int intImageSectionOtherDocu = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_DOCUMENTS);
                                string strImageName = "DOC_" + intImageSectionOtherDocu.ToString() + "_" + objEntityJoiningWorker.WorkerID.ToString() + "_" + count + "." + strFileExt;
                                objEntityJWorkerDtl.OtherDocuFileName = strImageName;
                                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_DOCUMENTS);

                                PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityJWorkerDtl.OtherDocuFileName);
                                objEntityJoiningWorkerDetilsList.Add(objEntityJWorkerDtl);

                            }
                        }
                    }
                }
            }
            objBusinessLayerJoiningWorker.InsertJoiningWorker(objEntityJoiningWorker, objEntityJoiningWorkerDetilsList);

            if (FileUploadLicence.HasFile)
            {
                FileUploadLicence.SaveAs(Server.MapPath(strImgPath) + objEntityJoiningWorker.LicenceFileName);
            }
            //certificate
            if (FileUploadCertificates.HasFile)
            {
                FileUploadCertificates.SaveAs(Server.MapPath(strImgPathCertificate) + objEntityJoiningWorker.CertificateFileName);
            }
            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("hcm_Joining_Worker.aspx?InsUpd=Save");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("hcm_Joining_WorkerList.aspx?InsUpd=Save");
            }

        }
        catch (Exception ex)
        {
            //throw ex;
           // ScriptManager.RegisterStartupScript(this, GetType(), "ErrMsg", "ErrMsg();", true);
        }
    }


    public class clsAtchmntData
    {

        public string ROWID { get; set; }
        public string FILEPATH { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }

    }
    protected void ddlCandidateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsEntityJoiningWorker objEntityJoiningWorker = new clsEntityJoiningWorker();
        clsBusinessLayerJoiningWorker objBusinessLayerJoiningWorker = new clsBusinessLayerJoiningWorker();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningWorker.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJoiningWorker.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJoiningWorker.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlCandidateName.SelectedItem.Value != "--SELECT CANDIDATE--")
        {
            objEntityJoiningWorker.UserId = Convert.ToInt32(ddlCandidateName.SelectedItem.Value);
            DataTable dtCandDtls = objBusinessLayerJoiningWorker.ReadCandidateData(objEntityJoiningWorker);
            if (dtCandDtls.Rows.Count > 0)
            {
                txtWorkerName.Text = dtCandDtls.Rows[0]["CAND_NAME"].ToString();
                txtDesignation.Text = dtCandDtls.Rows[0]["DSGN_NAME"].ToString();
                txtDivision.Text = dtCandDtls.Rows[0]["CPRDIV_NAME"].ToString();
            }
        }
        ddlCandidateName.Focus();
    }
    public void Update(string strId, int intCorpId, int intOrgId)
    {

        clsEntityJoiningWorker objEntityJoiningWorker = new clsEntityJoiningWorker();
        clsBusinessLayerJoiningWorker objBusinessLayerJoiningWorker = new clsBusinessLayerJoiningWorker();


        objEntityJoiningWorker.WorkerID = Convert.ToInt32(strId);
        // HiddenConsultancyId.Value = strId;
        objEntityJoiningWorker.CorpId = intCorpId;
        objEntityJoiningWorker.OrgId = intOrgId;

        DataTable dtWorkerDetails = new DataTable();

        dtWorkerDetails = objBusinessLayerJoiningWorker.ReadJoinigWorkerByID(objEntityJoiningWorker);

        DataTable dtWorkerOtherDocu = new DataTable();

        dtWorkerOtherDocu = objBusinessLayerJoiningWorker.ReadJoinigWkrDtlByID(objEntityJoiningWorker);

        if (dtWorkerDetails.Rows.Count > 0)
        {

            //if (ddlCandidateName.Items.FindByValue(dtWorkerDetails.Rows[0]["CAND_ID"].ToString()) != null)
            //{
            //    ddlCandidateName.Items.FindByValue(dtWorkerDetails.Rows[0]["CAND_ID"].ToString()).Selected = true;
            //}
            hiddenCandID.Value = dtWorkerDetails.Rows[0]["CAND_ID"].ToString();
            divCandidateName.Visible = false;
            txtWorkerName.Text = dtWorkerDetails.Rows[0]["CAND_NAME"].ToString();
            txtDesignation.Text = dtWorkerDetails.Rows[0]["DSGN_NAME"].ToString();
            txtDivision.Text = dtWorkerDetails.Rows[0]["CPRDIV_NAME"].ToString();
            txtPassportNo.Text = dtWorkerDetails.Rows[0]["WKR_PASSPORTNO"].ToString();
            txtJoiningDate.Text = dtWorkerDetails.Rows[0]["WKR_JOINING_DATE"].ToString();
            txtFormFillingDate.Text = dtWorkerDetails.Rows[0]["WKR_FRM_FLNG_DATE"].ToString();
            txtComments.Text = dtWorkerDetails.Rows[0]["WKR_COMMENTS"].ToString();
            txtSiteNo.Text = dtWorkerDetails.Rows[0]["WKR_SITE_NO"].ToString();
            string strCancelSts=dtWorkerDetails.Rows[0]["WKR_CNCL_USR_ID"].ToString();
            if (strCancelSts == "")
            {
                btnRegCandidate.Visible = true;
            }
           


            //licence
            if (dtWorkerDetails.Rows[0]["WKR_LICN_FILE_NAME"] != DBNull.Value && dtWorkerDetails.Rows[0]["WKR_LICN_FILE_NAME"].ToString() != "")
            {
                hiddenLicenceFile.Value = dtWorkerDetails.Rows[0]["WKR_LICN_FILE_NAME"].ToString();
                hiddenLicenceFileAct.Value = dtWorkerDetails.Rows[0]["WKR_LICN_ACT_NAME"].ToString();
                string strFileName = dtWorkerDetails.Rows[0]["WKR_LICN_FILE_NAME"].ToString();
                clsCommonLibrary objCommon = new clsCommonLibrary();
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_LICENCE) + dtWorkerDetails.Rows[0]["WKR_LICN_FILE_NAME"].ToString();


                string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                string strImage;
                //if (strFileExt == "gif" || strFileExt == "png" || strFileExt == "bmp" || strFileExt == "jpeg" || strFileExt == "jpg")
                //{

                //    // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
                //    strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy\" >Click to View Attachment Uploaded</a>";
                //    strImage += " <div class=\"lightbox-target\" id=\"goofy\">";
                //    strImage += " <img src=\"" + strImagePath + "\"/>";
                //    strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                //    strImage += "</div>";

                //}
                //else
                //{
                strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\" target=\"blank\" >Click to View Attachment Uploaded</a>";
                //}
                divImageDisplay.InnerHtml = strImage;

            }
            //certificate
            if (dtWorkerDetails.Rows[0]["WKR_CRTF_FILE_NAME"] != DBNull.Value && dtWorkerDetails.Rows[0]["WKR_CRTF_FILE_NAME"].ToString() != "")
            {
                hiddenCertificatesFile.Value = dtWorkerDetails.Rows[0]["WKR_CRTF_FILE_NAME"].ToString();
                hiddenCertificatesFileAct.Value = dtWorkerDetails.Rows[0]["WKR_CRTF_ACT_NAME"].ToString();
                string strFileName = dtWorkerDetails.Rows[0]["WKR_CRTF_FILE_NAME"].ToString();
                clsCommonLibrary objCommon = new clsCommonLibrary();
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_CERTIFICATE) + dtWorkerDetails.Rows[0]["WKR_CRTF_FILE_NAME"].ToString();


                string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                string strImage;
                //if (strFileExt == "gif" || strFileExt == "png" || strFileExt == "bmp" || strFileExt == "jpeg" || strFileExt == "jpg")
                //{

                //    // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
                //    strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy\" >Click to View Attachment Uploaded</a>";
                //    strImage += " <div class=\"lightbox-target\" id=\"goofy2\">";
                //    strImage += " <img src=\"" + strImagePath + "\"/>";
                //    strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                //    strImage += "</div>";

                //}
                //else
                //{
                strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\" target=\"blank\" >Click to View Attachment Uploaded</a>";
                //}
                divImageDisplayCertificates.InnerHtml = strImage;

            }

        }
        if (dtWorkerOtherDocu.Rows.Count > 0)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            hiddenFilePath.Value = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_DOCUMENTS);

            DataTable dtIAttchmnt = new DataTable();
            dtIAttchmnt.Columns.Add("TransDtlId", typeof(int));
            dtIAttchmnt.Columns.Add("FileName", typeof(string));
            dtIAttchmnt.Columns.Add("ActualFileName", typeof(string));




            if (dtWorkerOtherDocu.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtWorkerOtherDocu.Rows.Count; intcnt++)
                {
                    DataRow drAttchInsur = dtIAttchmnt.NewRow();
                    drAttchInsur["TransDtlId"] = dtWorkerOtherDocu.Rows[intcnt]["WKR_DTL_ID"].ToString();
                    drAttchInsur["FileName"] = dtWorkerOtherDocu.Rows[intcnt]["WKR_DTL_FILE_NAME"].ToString();
                    drAttchInsur["ActualFileName"] = dtWorkerOtherDocu.Rows[intcnt]["WKR_DTL_ACT_NAME"].ToString();
                    dtIAttchmnt.Rows.Add(drAttchInsur);
                }
                string strJson = DataTableToJSONWithJavaScriptSerializer(dtIAttchmnt);
                hiddenEdit.Value = strJson;
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

    protected void btnCnfrmSts_Click(object sender, EventArgs e)
    {
        clsEntityJoiningWorker objEntityJoiningWorker = new clsEntityJoiningWorker();
        clsBusinessLayerJoiningWorker objBusinessLayerJoiningWorker = new clsBusinessLayerJoiningWorker();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningWorker.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJoiningWorker.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJoiningWorker.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        string strRandomMixedId = Request.QueryString["Id"].ToString();
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strWaterRechId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityJoiningWorker.WorkerID = Convert.ToInt32(strWaterRechId);
        objEntityJoiningWorker.Date = System.DateTime.Now;
        objBusinessLayerJoiningWorker.UpdateCnfrmSts(objEntityJoiningWorker);
        int intcandidateid = Convert.ToInt32(hiddenCandID.Value);
        updateData();
        Response.Redirect("~/Master/gen_Emply_Personal_Informn/gen_Emply_Personal_Informn.aspx?WORKERID=" + strRandomMixedId);
    }
    protected void btnRegCandidate_Click(object sender, EventArgs e)
    {
        clsEntityJoiningWorker objEntityJoiningWorker = new clsEntityJoiningWorker();
        clsBusinessLayerJoiningWorker objBusinessLayerJoiningWorker = new clsBusinessLayerJoiningWorker();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningWorker.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJoiningWorker.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJoiningWorker.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }      
        int intcandidateid = Convert.ToInt32(hiddenCandID.Value);
        string strRandomMixedId = Request.QueryString["ViewId"].ToString();
        Response.Redirect("~/Master/gen_Emply_Personal_Informn/gen_Emply_Personal_Informn.aspx?WORKERID=" + strRandomMixedId);
    }

    [WebMethod]
    public static string CheckPassNo(string strWrkId, string strPassno, string strOrgid, string strCrpid)
    {
        //Confirm
        string strResult = "0";
        clsEntityJoiningWorker objEntityJoiningWorker = new clsEntityJoiningWorker();
        clsBusinessLayerJoiningWorker objBusinessLayerJoiningWorker = new clsBusinessLayerJoiningWorker();
        objEntityJoiningWorker.WorkerID = Convert.ToInt32(strWrkId);
        objEntityJoiningWorker.PassportNo = strPassno;
        objEntityJoiningWorker.OrgId = Convert.ToInt32(strOrgid);
        objEntityJoiningWorker.CorpId = Convert.ToInt32(strCrpid);
        strResult = objBusinessLayerJoiningWorker.CheckPassNo(objEntityJoiningWorker);
        return strResult;
    }

}