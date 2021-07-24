using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using EL_Compzit;
using BL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit.BusinessLayer_GMS;
using CL_Compzit;
using System.Web.Services;
using Newtonsoft.Json;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections;

public partial class GMS_GMS_Master_gen_Insurance_Master_gen_Insurance_Master : System.Web.UI.Page
{
    clsBusinessLayerInsuranceMaster objBusinessInsurance = new clsBusinessLayerInsuranceMaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            LoadCurrency();
            LoadEmployee();
            LoadInsuranceProvider();
            NotifyTempLoad();

            txtValidity.Enabled = false;
            imgbtnReOpen.Visible = false;
            btnConfirm.Visible = false;
            btnrenew.Visible = false;

            HiddenFieldView.Value = "";
            HiddenFieldUpdate.Value = "0";
            hiddenFileCanclDtlId.Value = "";
            HiddenField2_FileUploadLnk.Value = "";
            hiddenEditAttchmnt.Value = "";
            HiddenRenew.Value = "";
            HiddenFieldRequestCltId.Value = "";
            HiddenImportaddchk.Value = "";
            HiddenDuplictnchk.Value = "0";
            hiddenRoleAddProjct.Value = "";

            clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();
            int intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);
                HiddenUserId.Value = Session["USERID"].ToString();

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                HiddenOrgansId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            int intUsrRolMstrId, intEnableAdd = 0, intUsrRolMstrIdprjct = 0, intEnableReOpen = 0, intEnableConfirm = 0, intEnableSuplier = 0, intEnableClient = 0, intEnableClose = 0, intEnableAdd1 = 0, intEnableAddContract = 0, intUsrRolMstrIdContract = 0;
            //Allocating child roles
            hiddenRoleAdd.Value = "0";
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Insurance_Master);
            intUsrRolMstrIdprjct = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Project);

            DataTable dtPrjct = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdprjct);
            DataTable dtContractRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdContract);

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
                        hiddenRoleAdd.Value = intEnableAdd.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleReOpen.Value = intEnableReOpen.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleConfirm.Value = intEnableConfirm.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                    {
                        intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleClose.Value = intEnableConfirm.ToString();
                    }
                }
            }

            if (dtPrjct.Rows.Count > 0)
            {
                string strChildRolDeftn1 = dtPrjct.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords1 = strChildRolDeftn1.Split('-');
                foreach (string strC_Role in strChildDefArrWords1)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intEnableAdd1 = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleAddProjct.Value = intEnableAdd1.ToString();
                    }
                }

            }
            if (hiddenRoleAddProjct.Value == "")
            {
                btnNewProject.Visible = false;
            }

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intEnableSuplier == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnAdd.Visible = true;
                    btnAddClose.Visible = true;
                }

                else if (intEnableClient == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {

                    btnAdd.Visible = true;
                    btnAddClose.Visible = true;
                }
                else
                {

                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                    btnAdd.Visible = false;
                    btnAddClose.Visible = false;
                    btnClear.Visible = false;
                }

            }
            else
            {
                btnUpdate.Visible = false;
            }

            hiddenFilePath.Value = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
            DataTable dtAttchmnt = objBusinessInsurance.Read_AllAttachment();
            if (dtAttchmnt.Rows.Count > 0)
            {
                hiddenAttchmntSlNumber.Value = dtAttchmnt.Rows[0]["INSRNC_ATTCH_SL_NUM"].ToString();
            }

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }

            // for adding comma
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
            }

            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            hiddenCurrentDate.Value = strCurrentDate;

            if (Request.QueryString["Id"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.Text = "Edit Insurance";

                if (hiddenRoleAdd.Value.ToString() != "")
                {
                    if (Convert.ToInt32(hiddenRoleAdd.Value.ToString()) != Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        btnUpdate.Visible = false;
                    }
                }
            }

            else if (Request.QueryString["Renew"] != null)
            {
                string strRandomMixedId = Request.QueryString["Renew"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityInsurance.InsuranceId = Convert.ToInt32(strId);

                objEntityInsurance.User_Id = intUserId;
                objEntityInsurance.D_Date = System.DateTime.Now;
                imgbtnReOpen.Visible = false;

                btnNewProject.Visible = false;
                HiddenRenew.Value = "1";
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnrenew.Visible = true;
                btnClear.Visible = false;

                View(strId);

                lblEntry.Text = "Renew Insurance";
                hiddenEditMode.Value = "View";
            }
            else if (Request.QueryString["ViewId"] != null)
            {
                btnNewProject.Visible = false;
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.Text = "View Insurance";
                hiddenConfirmOrNot.Value = "1";
                hiddenEditMode.Value = "View";
            }
            else
            {
                lblEntry.Text = "Add Insurance";

                DropDownEmployeeDataStore();
                DropdownDesignationDataStore();
                DropdownDivisionDataStore();

                DefaultTemplateLoad();
                LoadProjects(0, "");

                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_MSTR);
                objEntityCommon.CorporateID = intCorpId;
                objEntityCommon.Organisation_Id = intOrgId;
                string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);

                string year = DateTime.Today.Year.ToString();
                LabelRefnum.Text = "INSRNC/" + year + "/" + strNextId;
                hiddenFieldRefNumber.Value = "INSRNC/" + year + "/" + strNextId;

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;

                cbxExistingEmployee.Checked = true;
                radioOpen.Checked = true;
                btnConfirm.Visible = false;
                btnrenew.Visible = false;
                imgbtnReOpen.Visible = false;
            }

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "Cnfrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
                }
                else if (strInsUpd == "ReOpen")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
                }
                else if (strInsUpd == "Renewd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessGuaranteeRenewed", "SuccessGuaranteeRenewed();", true);
                }
                else if (strInsUpd == "PrjIns")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationPrjct", "SuccessConfirmationPrjct();", true);
                }
                else if (strInsUpd == "PrjUpd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationPrjct", "SuccessUpdationPrjct();", true);
                }
            }

        }
    }

    public void LoadCurrency()
    {
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtCurrency = objBusinessInsurance.ReadCurrency(objEntityInsurance);
        if (dtCurrency.Rows.Count > 0)
        {
            ddlCurrency.DataSource = dtCurrency;
            ddlCurrency.DataTextField = "CRNCMST_NAME";
            ddlCurrency.DataValueField = "CRNCMST_ID";
            ddlCurrency.DataBind();

        }
        string strdefltcurrcy = hiddenDfltCurrencyMstrId.Value;
        if (ddlCurrency.Items.FindByValue(strdefltcurrcy) != null)
        {
            ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
        }
    }

    public void LoadEmployee()
    {
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtEmp = objBusinessInsurance.ReadEmployee(objEntityInsurance);
        if (dtEmp.Rows.Count > 0)
        {
            ddlExistingEmp.DataSource = dtEmp;
            ddlExistingEmp.DataTextField = "USR_NAME";
            ddlExistingEmp.DataValueField = "USR_ID";
            ddlExistingEmp.DataBind();
        }
        ddlExistingEmp.Items.Insert(0, "--SELECT EMPLOYEE--");
    }

    public void LoadInsuranceProvider()
    {
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtInsurancePrvdrs = objBusinessInsurance.ReadInsuranceProviders(objEntityInsurance);
        if (dtInsurancePrvdrs.Rows.Count > 0)
        {
            ddlInsurncPrvdr.DataSource = dtInsurancePrvdrs;
            ddlInsurncPrvdr.DataTextField = "INSURPRVDR_NAME";
            ddlInsurncPrvdr.DataValueField = "INSURPRVDR_ID";
            ddlInsurncPrvdr.DataBind();
        }
        ddlInsurncPrvdr.Items.Insert(0, "--SELECT INSURANCE PROVIDER--");
    }

    public void LoadProjects(int ProjctId, string PrjctName)
    {
        DropDownEmployeeDataStore();
        DropdownDesignationDataStore();
        DropdownDivisionDataStore();

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtProjects = objBusinessInsurance.ReadProjects(objEntityInsurance);
        if (dtProjects.Rows.Count > 0)
        {
            ddlProjects.Items.Clear();
            ddlProjects.DataSource = dtProjects;
            ddlProjects.DataTextField = "PROJECT_NAME";
            ddlProjects.DataValueField = "PROJECT_ID";
            ddlProjects.DataBind();
        }
        ddlProjects.Items.Insert(0, "--SELECT PROJECT--");

        if (ProjctId != 0)
        {
            if (ddlProjects.Items.FindByValue(ProjctId.ToString()) != null)
            {
                ddlProjects.Items.FindByValue(ProjctId.ToString()).Selected = true;
            }

            else
            {
                ListItem lstGrp = new ListItem(PrjctName, ProjctId.ToString());
                ddlProjects.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlProjects);
                ddlProjects.ClearSelection();
                if (ddlProjects.Items.FindByValue(ProjctId.ToString()) != null)
                {
                    ddlProjects.Items.FindByValue(ProjctId.ToString()).Selected = true;
                }
            }
        }

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
    public void NotifyTempLoad()
    {
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtTemplate = objBusinessInsurance.ReadNotifyTemplates(objEntityInsurance);
        if (dtTemplate.Rows.Count > 0)
        {
            ddlTemplate.DataSource = dtTemplate;
            ddlTemplate.DataTextField = "NOTFTEMP_NAME";
            ddlTemplate.DataValueField = "NOTFTEMP_ID";
            ddlTemplate.DataBind();
        }
        else
        {
            ddlTemplate.Items.Insert(0, "--SELECT TEMPLATE--");
        }
    }

    public void DefaultTemplateLoad()
    {
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtDfltTemp = objBusinessInsurance.ReadDefaultNotifyTemplates(objEntityInsurance);

        int templateid = 0;
        if (dtDfltTemp.Rows.Count > 0)
        {
            templateid = Convert.ToInt32(dtDfltTemp.Rows[0]["NOTFTEMP_ID"]);
            ddlTemplate.Items.FindByValue(dtDfltTemp.Rows[0]["NOTFTEMP_ID"].ToString()).Selected = true;
        }

        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();

        objEntityNotTemp.NotTempId = Convert.ToInt32(templateid);

        DataTable dtTemplate = ObjBusinessNotiFi.ReadTemplateById(objEntityNotTemp);
        if (dtTemplate.Rows.Count > 0)
        {
            DataTable dtTemplateDetail = new DataTable();
            dtTemplateDetail.Columns.Add("TempDetailId", typeof(int));
            dtTemplateDetail.Columns.Add("NotifyMod", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyVia", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyDur", typeof(string));

            DataTable dtEachTemplateDetail = ObjBusinessNotiFi.ReadTemplateDetailById(objEntityNotTemp);

            string strAlertDetailFull = "";
            if (dtEachTemplateDetail.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtEachTemplateDetail.Rows.Count; intcnt++)
                {
                    DataRow drAttchTempDet = dtTemplateDetail.NewRow();
                    drAttchTempDet["TempDetailId"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_ID"].ToString();
                    drAttchTempDet["NotifyMod"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_PERIOD"].ToString();
                    drAttchTempDet["NotifyDur"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_COUNT"].ToString();
                    string strVia = "";
                    if (dtEachTemplateDetail.Rows[intcnt]["TEMDTL_DASHBOARD"].ToString() == "1")
                    {
                        strVia = strVia + "," + "D";
                    }
                    if (dtEachTemplateDetail.Rows[intcnt]["TEMDTL_EMAIL"].ToString() == "1")
                    {
                        strVia = strVia + "," + "E";
                    }
                    drAttchTempDet["NotifyVia"] = strVia;
                    dtTemplateDetail.Rows.Add(drAttchTempDet);

                    objEntityNotTemp.TempDetailId = Convert.ToInt32(dtEachTemplateDetail.Rows[intcnt]["TEMDTL_ID"]);

                    DataTable dtTemplateAlert = new DataTable();
                    dtTemplateAlert.Columns.Add("TempDetailId", typeof(int));
                    dtTemplateAlert.Columns.Add("TempAlertId", typeof(int));
                    dtTemplateAlert.Columns.Add("AlertOpt", typeof(string));
                    dtTemplateAlert.Columns.Add("AlertNtfyId", typeof(string));

                    DataTable dtTempAlertEachSlice = ObjBusinessNotiFi.ReadTemplateAlertById(objEntityNotTemp);
                    if (dtTempAlertEachSlice.Rows.Count > 0)
                    {
                        for (int intAlertcnt = 0; intAlertcnt < dtTempAlertEachSlice.Rows.Count; intAlertcnt++)
                        {
                            DataRow drAttchTempAlert = dtTemplateAlert.NewRow();
                            drAttchTempAlert["TempDetailId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMDTL_ID"].ToString();
                            drAttchTempAlert["TempAlertId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_ID"].ToString();
                            drAttchTempAlert["AlertOpt"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_OPT"].ToString();
                            if (dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_OPT"].ToString() == "3")
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_EMAIL"].ToString();
                            }
                            else
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_NTFY_ID"].ToString();
                            }

                            dtTemplateAlert.Rows.Add(drAttchTempAlert);
                        }
                    }

                    string strAlertJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateAlert);
                    strAlertDetailFull = strAlertDetailFull + "!" + strAlertJson;
                }

                string strJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateDetail);
                hiddenEachTemplateDetail.Value = strJson;
                hiddenTemplateAlertData.Value = strAlertDetailFull;
            }
        }
        hiddenTemplateLoadingMode.Value = "FromTemp";
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

    public void DropdownDivisionDataStore()
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        if (Session["USERID"] != null)
        {
            objEntityNotTemp.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNotTemp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {

            objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtDivisionList = new DataTable();
        dtDivisionList = ObjBusinessNotiFi.ReadDivision(objEntityNotTemp);
        dtDivisionList.TableName = "dtTableDivision";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDivisionList.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenDivisionddlData.Value = result;
    }


    public void DropdownDesignationDataStore()
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        if (Session["USERID"] != null)
        {
            objEntityNotTemp.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNotTemp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {

            objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtDesignationList = new DataTable();
        dtDesignationList = ObjBusinessNotiFi.ReadDesignations(objEntityNotTemp);
        dtDesignationList.TableName = "dtTableDesignation";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDesignationList.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenDesignationddlData.Value = result;
    }

    public void DropDownEmployeeDataStore()
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        if (Session["USERID"] != null)
        {
            objEntityNotTemp.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNotTemp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtEmployeeList = new DataTable();
        dtEmployeeList = ObjBusinessNotiFi.ReadEmployee(objEntityNotTemp);
        dtEmployeeList.TableName = "dtTableEmployee";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtEmployeeList.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenEmployeeDdlData.Value = result;
    }
    [WebMethod]
    public static string DropdownDivisionBind(string tableName, int CorpId, int OrgId)
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();

        objEntityNotTemp.CorpOffice_Id = CorpId;
        objEntityNotTemp.Organisation_Id = OrgId;
        DataTable dtDivisionList = new DataTable();
        dtDivisionList = ObjBusinessNotiFi.ReadDivision(objEntityNotTemp);
        dtDivisionList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDivisionList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }
    [WebMethod]
    public static string DropdownDesignationBind(string tableName, int CorpId, int OrgId)
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        objEntityNotTemp.CorpOffice_Id = CorpId;
        objEntityNotTemp.Organisation_Id = OrgId;
        DataTable dtDesignationList = new DataTable();
        dtDesignationList = ObjBusinessNotiFi.ReadDesignations(objEntityNotTemp);
        dtDesignationList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDesignationList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }

    [WebMethod]
    public static string DropdownEmployeeBind(string tableName, int CorpId, int OrgId)
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        objEntityNotTemp.CorpOffice_Id = CorpId;
        objEntityNotTemp.Organisation_Id = OrgId;
        DataTable dtEmployeeList = new DataTable();
        dtEmployeeList = ObjBusinessNotiFi.ReadEmployee(objEntityNotTemp);
        dtEmployeeList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtEmployeeList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        int intnoofDays = 0;

        if (HiddenFieldAmount.Value.Trim() != "")
        {
            objEntityInsurance.Amount = Convert.ToDecimal(HiddenFieldAmount.Value);
        }
        objEntityInsurance.ProjectId = Convert.ToInt32(ddlProjects.SelectedItem.Value);

        if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
        {
            objEntityInsurance.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
        }

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_MSTR);
        objEntityCommon.CorporateID = objEntityInsurance.CorpOffice_Id;
        objEntityCommon.Organisation_Id = objEntityInsurance.Organisation_Id;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        objEntityInsurance.NextIdForRqst = Convert.ToInt32(strNextId);
        HiddenBankGuarenteeId.Value = Convert.ToString(objEntityInsurance.NextIdForRqst);

        objEntityInsurance.RefNumber = hiddenFieldRefNumber.Value;
        objEntityInsurance.InsuranceNo = txtInsuranceno.Text.Trim();

        if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
        {
            objEntityInsurance.InsuranceProvider = Convert.ToInt32(ddlInsurncPrvdr.SelectedItem.Value);
        }
        if (radioOpen.Checked == true)
        {
            objEntityInsurance.InsuranceTyp = 101;
            objEntityInsurance.ExpireDate = DateTime.MinValue;
        }
        else if (radioLimited.Checked == true)
        {
            objEntityInsurance.InsuranceTyp = 102;
            objEntityInsurance.NoOfDays = Convert.ToInt32(HiddenValidatedays.Value);
            intnoofDays = Convert.ToInt32(HiddenValidatedays.Value);

            objEntityInsurance.ExpireDate = objCommon.textToDateTime(txtPrjctClsngDate.Text.Trim());
        }
        objEntityInsurance.OpenDate = objCommon.textToDateTime(txtOpngDate.Text.Trim());

        if (cbxDontNotify.Checked == true)
        {
            objEntityInsurance.DontNotify = 1;
        }
        else
        {
            objEntityInsurance.DontNotify = 0;
        }

        objEntityInsurance.NotTempId = Convert.ToInt32(ddlTemplate.SelectedItem.Value);
        objEntityInsurance.Description = txtDescrptn.Text.Trim();

        if (cbxExistingEmployee.Checked == true)
        {
            if (ddlExistingEmp.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                objEntityInsurance.EmployeName = ddlExistingEmp.SelectedItem.Text;
                objEntityInsurance.ContactPersnUsrId = Convert.ToInt32(ddlExistingEmp.SelectedItem.Value);

            }
        }
        else
        {
            objEntityInsurance.EmployeName = txtEmpName.Text.Trim();
        }
        objEntityInsurance.Email = txtCntctMail.Text.Trim();
        objEntityInsurance.D_Date = System.DateTime.Now;

        string strGurntNo = "";
        strGurntNo = objBusinessInsurance.CheckDupInsrncNo(objEntityInsurance);

        if (strGurntNo == "" || strGurntNo == "0")
        {
            objBusinessInsurance.AddInsurance(objEntityInsurance);


            //for inserting attachmnts

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_ATTACHMNT);
            objEntityCommon.CorporateID = objEntityInsurance.CorpOffice_Id;

            List<clsEntityLayerInsuranceAttachments> objEntityLayerGuarenteeAtchmntDtlList = new List<clsEntityLayerInsuranceAttachments>();

            int intSlNumbr = 0;
            if (hiddenAttchmntSlNumber.Value != "")
            {
                intSlNumbr = Convert.ToInt32(hiddenAttchmntSlNumber.Value);
                intSlNumbr++;
            }

            if (HiddenField2_FileUploadLnk.Value != "" && HiddenField2_FileUploadLnk.Value != null && HiddenField2_FileUploadLnk.Value != "[]")
            {
                string jsonDataDltAttch = HiddenField2_FileUploadLnk.Value;
                string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                string strAtt2 = strAtt1.Replace("\\", "");
                string strAtt3 = strAtt2.Replace("}\"]", "}]");
                string strAtt4 = strAtt3.Replace("}\",", "},");

                List<clsBannerDataADDAttchmnt> objBannerDataDltAttList = new List<clsBannerDataADDAttchmnt>();
                objBannerDataDltAttList = JsonConvert.DeserializeObject<List<clsBannerDataADDAttchmnt>>(strAtt4);

                foreach (clsBannerDataADDAttchmnt objClsBannrAddAttData in objBannerDataDltAttList)
                {
                    if (objClsBannrAddAttData.EVTACTION == "INS")
                    {
                        string strfilepath = Convert.ToString(objClsBannrAddAttData.ROWID);

                        HttpPostedFile PostedFile = Request.Files["file" + strfilepath];
                        if (PostedFile.ContentLength > 0)
                        {
                            clsEntityLayerInsuranceAttachments objEntityLayerGuarnteeAtchmntDtl = new clsEntityLayerInsuranceAttachments();
                            string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                            objEntityLayerGuarnteeAtchmntDtl.ActualFileName = strFileName;

                            string strFileExt;
                            strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                            int intAppModSection = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_ATTACHMNT);
                            int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                            objEntityLayerGuarnteeAtchmntDtl.AttchmntSlNumber = intSlNumbr;
                            string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + "_" + intSlNumbr + "." + strFileExt;
                            objEntityLayerGuarnteeAtchmntDtl.FileName = strImageName;

                            objEntityLayerGuarnteeAtchmntDtl.CaptionName = Request.Form["textbx" + strfilepath];

                            objEntityLayerGuarnteeAtchmntDtl.InsuranceId = Convert.ToInt32(HiddenBankGuarenteeId.Value);

                            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                            PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityLayerGuarnteeAtchmntDtl.FileName);

                            objEntityLayerGuarenteeAtchmntDtlList.Add(objEntityLayerGuarnteeAtchmntDtl);
                            intSlNumbr++;
                        }


                    }
                }
            }

            List<clsEntityLayerInsuranceAttachments> objEntityLayerInsuranceAtchmntDtlListDelete = new List<clsEntityLayerInsuranceAttachments>();

            if (hiddenFileCanclDtlId.Value != "" && hiddenFileCanclDtlId.Value != null)
            {
                string jsonDataDltAttch = hiddenFileCanclDtlId.Value;
                string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                string strAtt2 = strAtt1.Replace("\\", "");
                string strAtt3 = strAtt2.Replace("}\"]", "}]");
                string strAtt4 = strAtt3.Replace("}\",", "},");

                List<clsPictureDataDELETEAttchmnt> objPictureDataDltAttList = new List<clsPictureDataDELETEAttchmnt>();
                objPictureDataDltAttList = JsonConvert.DeserializeObject<List<clsPictureDataDELETEAttchmnt>>(strAtt4);

                foreach (clsPictureDataDELETEAttchmnt objClsPictureDltAttData in objPictureDataDltAttList)
                {
                    clsEntityLayerInsuranceAttachments objEntityLayerInsuranceAtchmntDtl = new clsEntityLayerInsuranceAttachments();

                    objEntityLayerInsuranceAtchmntDtl.PictureId = Convert.ToInt32(objClsPictureDltAttData.DTLID);
                    objEntityLayerInsuranceAtchmntDtl.FileName = Convert.ToString(objClsPictureDltAttData.FILENAME);
                    objEntityLayerInsuranceAtchmntDtlListDelete.Add(objEntityLayerInsuranceAtchmntDtl);
                }
            }

            if (objEntityLayerGuarenteeAtchmntDtlList.Count > 0)
            {
                objBusinessInsurance.Add_Pictures(objEntityInsurance, objEntityLayerGuarenteeAtchmntDtlList);
            }

            if (objEntityLayerInsuranceAtchmntDtlListDelete.Count > 0)
            {
                objBusinessInsurance.Delete_Pictures(objEntityInsurance, objEntityLayerInsuranceAtchmntDtlListDelete);

                foreach (clsEntityLayerInsuranceAttachments objEntityLayerIInsuranceAtchmntDtl in objEntityLayerInsuranceAtchmntDtlListDelete)
                {

                    string strImgPath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                    string imageLocation = strImgPath + objEntityLayerIInsuranceAtchmntDtl.FileName;
                    if (File.Exists(MapPath(imageLocation)))
                    {
                        File.Delete(MapPath(imageLocation));
                    }
                }
            }

            //for inserting template

            string strEachTempTotalString = hiddenEachSliceData.Value;
            string strNotifyMode = hiddenNotificationMOde.Value;
            string strNotifyVia = hiddenNotifyVia.Value;
            string strNotifyDur = hiddenNotificationDuration.Value;
            int TempCount = Convert.ToInt32(hiddenTemplateCount.Value);

            string[] strEachTempString = new string[TempCount];
            strEachTempString = strEachTempTotalString.Split('!');

            for (int intCount = 0; intCount < TempCount; intCount++)
            {
                InsuranceTemplateDetail objEntityTempDeatils = new InsuranceTemplateDetail();

                //for template mode
                string jsonDataNotyMod = strNotifyMode;
                string a = jsonDataNotyMod.Replace("\"{", "\\{");
                string b = a.Replace("\\n", "\r\n");
                string c = b.Replace("\\", "");
                string d = c.Replace("}\"]", "}]");
                string k = d.Replace("}\",", "},");

                List<clsEachTempNotyMOde> objEachTempDetModList = new List<clsEachTempNotyMOde>();
                objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde>>(k);

                string MODEROWID = objEachTempDetModList[intCount].ROWID;
                string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                if (NOTMODE == "D")
                {
                    objEntityTempDeatils.TempDetPeriod = 2;
                }
                else
                {
                    objEntityTempDeatils.TempDetPeriod = 1;
                }

                //for template NotifyVia
                string jsonDataNotyVia = strNotifyVia;
                string l = jsonDataNotyVia.Replace("\"{", "\\{");
                string m = l.Replace("\\n", "\r\n");
                string n = m.Replace("\\", "");
                string o = n.Replace("}\"]", "}]");
                string p = o.Replace("}\",", "},");

                List<clsEachTempNotyVia> objEachTempDetViaList = new List<clsEachTempNotyVia>();
                objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia>>(p);

                string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                if (VIAWHT.Contains("D"))
                {
                    objEntityTempDeatils.IsDashBoard = 1;
                }
                if (VIAWHT.Contains("E"))
                {
                    objEntityTempDeatils.IsEmail = 1;
                }

                //for template notify Duration
                string jsonDataNotyDur = strNotifyDur;
                string q = jsonDataNotyDur.Replace("\"{", "\\{");
                string r = q.Replace("\\n", "\r\n");
                string s = r.Replace("\\", "");
                string t = s.Replace("}\"]", "}]");
                string u = t.Replace("}\",", "},");

                List<clsEachTempNotyDur> objEachTempDetDurList = new List<clsEachTempNotyDur>();
                objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur>>(u);

                string DURROWID = objEachTempDetDurList[intCount].ROWID;
                string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);


                string jsonData = strEachTempString[intCount + 1];
                string V = jsonData.Replace("\"{", "\\{");
                string W = V.Replace("\\n", "\r\n");
                string X = W.Replace("\\", "");
                string Y = X.Replace("}\"]", "}]");
                string Z = Y.Replace("}\",", "},");

                List<InsuranceTemplateAlert> objEntityTempAlertList = new List<InsuranceTemplateAlert>();

                List<clsEachTempDeatail> objEachTempDetList = new List<clsEachTempDeatail>();
                objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail>>(Z);

                if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                {

                    for (int count = 0; count < objEachTempDetList.Count; count++)
                    {
                        string ROWID = objEachTempDetList[count].ROWID;

                        string VALUE = objEachTempDetList[count].DDLVALUE;
                        string DDLMODE = objEachTempDetList[count].DDLMODE;
                        string DTLID = objEachTempDetList[count].DTLID;
                        if (VALUE != "0")
                        {
                            InsuranceTemplateAlert objEntityTemplateAlert = new InsuranceTemplateAlert();
                            if (DDLMODE == "ddlDivision_")
                            {
                                objEntityTemplateAlert.TemplateAlertOptId = 0;
                                objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                            }
                            else if (DDLMODE == "ddlDesignation_")
                            {
                                objEntityTemplateAlert.TemplateAlertOptId = 1;
                                objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                            }
                            else if (DDLMODE == "ddlEmployee_")
                            {
                                objEntityTemplateAlert.TemplateAlertOptId = 2;
                                objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                            }
                            else if (DDLMODE == "txtGenMail_")
                            {
                                objEntityTemplateAlert.TemplateAlertOptId = 3;
                                objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                            }


                            objEntityTempAlertList.Add(objEntityTemplateAlert);
                        }
                    }

                }

                objBusinessInsurance.AddTemplateDetail(objEntityInsurance, objEntityTempDeatils, objEntityTempAlertList);
            }



            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Insurance_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Insurance_Master_List.aspx?InsUpd=Ins");
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Duplication", "Duplication();", true);
        }

    }


    public class clsPictureDataDELETEAttchmnt
    {
        public string FILENAME { get; set; }
        public string DTLID { get; set; }
    }
    public class clsBannerDataADDAttchmnt
    {
        public string EVTACTION { get; set; }
        public string ROWID { get; set; }
        public string DTLID { get; set; }
    }

    public class clsEachTempDeatail
    {
        public string DDLVALUE { get; set; }
        public string ROWID { get; set; }
        public string DDLMODE { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }
    }

    public class clsEachTempNotyMOde
    {
        public string ROWID { get; set; }
        public string NOTMODE { get; set; }
        public string TEMPID { get; set; }
    }
    public class clsEachTempNotyVia
    {
        public string ROWID { get; set; }
        public string NOTVIA { get; set; }
        public string TEMPID { get; set; }
    }
    public class clsEachTempNotyDur
    {
        public string ROWID { get; set; }
        public string NOTDUR { get; set; }
        public string TEMPID { get; set; }
    }


    public class clsEachAlertDel
    {
        public string ROWID { get; set; }
        public string DTLID { get; set; }
    }

    protected void ddlTemplate_SelectedIndexChanged(object sender, EventArgs e)
    {
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();

        DropDownEmployeeDataStore();
        DropdownDesignationDataStore();
        DropdownDivisionDataStore();
        int strId = Convert.ToInt32(ddlTemplate.SelectedItem.Value);
        objEntityNotTemp.NotTempId = Convert.ToInt32(strId);
        DataTable dtTemplate = ObjBusinessNotiFi.ReadTemplateById(objEntityNotTemp);

        if (dtTemplate.Rows.Count > 0)
        {
            DataTable dtTemplateDetail = new DataTable();
            dtTemplateDetail.Columns.Add("TempDetailId", typeof(int));
            dtTemplateDetail.Columns.Add("NotifyMod", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyVia", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyDur", typeof(string));

            DataTable dtEachTemplateDetail = new DataTable();
            dtEachTemplateDetail = ObjBusinessNotiFi.ReadTemplateDetailById(objEntityNotTemp);

            string strAlertDetailFull = "";
            if (dtEachTemplateDetail.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtEachTemplateDetail.Rows.Count; intcnt++)
                {
                    DataRow drAttchTempDet = dtTemplateDetail.NewRow();
                    drAttchTempDet["TempDetailId"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_ID"].ToString();
                    drAttchTempDet["NotifyMod"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_PERIOD"].ToString();
                    drAttchTempDet["NotifyDur"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_COUNT"].ToString();
                    string strVia = "";
                    if (dtEachTemplateDetail.Rows[intcnt]["TEMDTL_DASHBOARD"].ToString() == "1")
                    {
                        strVia = strVia + "," + "D";
                    }
                    if (dtEachTemplateDetail.Rows[intcnt]["TEMDTL_EMAIL"].ToString() == "1")
                    {
                        strVia = strVia + "," + "E";
                    }
                    drAttchTempDet["NotifyVia"] = strVia;

                    dtTemplateDetail.Rows.Add(drAttchTempDet);

                    objEntityNotTemp.TempDetailId = Convert.ToInt32(dtEachTemplateDetail.Rows[intcnt]["TEMDTL_ID"]);
                    DataTable dtTemplateAlert = new DataTable();
                    dtTemplateAlert.Columns.Add("TempDetailId", typeof(int));
                    dtTemplateAlert.Columns.Add("TempAlertId", typeof(int));
                    dtTemplateAlert.Columns.Add("AlertOpt", typeof(string));
                    dtTemplateAlert.Columns.Add("AlertNtfyId", typeof(string));

                    DataTable dtTempAlertEachSlice = ObjBusinessNotiFi.ReadTemplateAlertById(objEntityNotTemp);
                    if (dtTempAlertEachSlice.Rows.Count > 0)
                    {
                        for (int intAlertcnt = 0; intAlertcnt < dtTempAlertEachSlice.Rows.Count; intAlertcnt++)
                        {
                            DataRow drAttchTempAlert = dtTemplateAlert.NewRow();
                            drAttchTempAlert["TempDetailId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMDTL_ID"].ToString();
                            drAttchTempAlert["TempAlertId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_ID"].ToString();
                            drAttchTempAlert["AlertOpt"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_OPT"].ToString();
                            if (dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_OPT"].ToString() == "3")
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_EMAIL"].ToString();
                            }
                            else
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_NTFY_ID"].ToString();
                            }

                            dtTemplateAlert.Rows.Add(drAttchTempAlert);
                        }
                    }

                    string strAlertJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateAlert);
                    strAlertDetailFull = strAlertDetailFull + "!" + strAlertJson;
                }

                string strJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateDetail);
                hiddenEachTemplateDetail.Value = strJson;
                hiddenTemplateAlertData.Value = strAlertDetailFull;
            }
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "TemplateLoad", "TemplateLoad();", true);
    }

    protected void btnNewProject_Click(object sender, EventArgs e)
    {
        int Projectid = Convert.ToInt32(hiddenNewProjectId.Value);
        LoadProjects(Projectid, "");   
    }

    public void Update(string strId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        HiddenFieldUpdate.Value = "1";
        HiddenImportaddchk.Value = "1";

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (strId != "")
        {
            objEntityInsurance.InsuranceId = Convert.ToInt32(strId);
            HiddenBankGuarenteeId.Value = strId;
        }

        DataTable dtInsurance = objBusinessInsurance.ReadInsuranceById(objEntityInsurance);
        if (dtInsurance.Rows.Count > 0)
        {
            HiddenFieldRefNumber2.Value = dtInsurance.Rows[0]["INSURANCE_REF_NUM"].ToString();
            LabelRefnum.Text = dtInsurance.Rows[0]["INSURANCE_REF_NUM"].ToString();
            txtInsuranceno.Text = dtInsurance.Rows[0]["INSURANCE_NUMBER"].ToString();
            txtCntctMail.Text = dtInsurance.Rows[0]["INSURANCE_PERSON_EMAIL"].ToString();
            txtOpngDate.Text = dtInsurance.Rows[0]["INSURANCE_DATE"].ToString();
            txtDescrptn.Text = dtInsurance.Rows[0]["INSURANCE_DESCRIPTION"].ToString();

            if (dtInsurance.Rows[0]["INSURPRVDR_STATUS"].ToString() == "1" && dtInsurance.Rows[0]["INSURPRVDR_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlInsurncPrvdr.Items.FindByValue(dtInsurance.Rows[0]["INSURPRVDR_ID"].ToString()) != null)
                {
                    ddlInsurncPrvdr.Items.FindByValue(dtInsurance.Rows[0]["INSURPRVDR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["INSURPRVDR_NAME"].ToString(), dtInsurance.Rows[0]["INSURPRVDR_ID"].ToString());
                ddlInsurncPrvdr.Items.Insert(1, lstGrp);
                ddlInsurncPrvdr.Items.FindByValue(dtInsurance.Rows[0]["INSURPRVDR_ID"].ToString()).Selected = true;
            }

            int intProjectId = 0; string strProjectName = "";
            if (dtInsurance.Rows[0]["PROJECT_ID"].ToString() != null || dtInsurance.Rows[0]["PROJECT_ID"].ToString() != "")
            {
                intProjectId = Convert.ToInt32(dtInsurance.Rows[0]["PROJECT_ID"].ToString());
                strProjectName = dtInsurance.Rows[0]["PROJECT_NAME"].ToString();
            }
            LoadProjects(intProjectId, strProjectName);

            if (dtInsurance.Rows[0]["INSURANCE_DONT_NOTIFY"].ToString() == "1")
            {
                cbxDontNotify.Checked = true;
            }
            else
            {
                cbxDontNotify.Checked = false;
            }
            ddlCurrency.ClearSelection();
            if (dtInsurance.Rows[0]["CRNCMST_STATUS"].ToString() == "1" && dtInsurance.Rows[0]["CRNCMST_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlCurrency.Items.FindByValue(dtInsurance.Rows[0]["CRNCMST_ID"].ToString()) != null)
                {
                    ddlCurrency.Items.FindByValue(dtInsurance.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["CRNCMST_NAME"].ToString(), dtInsurance.Rows[0]["CRNCMST_ID"].ToString());
                ddlCurrency.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCurrency);

                ddlCurrency.Items.FindByValue(dtInsurance.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }

            txtAmount.Text = dtInsurance.Rows[0]["INSURANCE_AMOUNT"].ToString();

            if (dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString() != "")
            {
                cbxExistingEmployee.Checked = true;

                if (dtInsurance.Rows[0]["USR_STATUS"].ToString() == "1" && dtInsurance.Rows[0]["USR_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlExistingEmp.Items.FindByValue(dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString()) != null)
                    {
                        ddlExistingEmp.Items.FindByValue(dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["USR_NAME"].ToString(), dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString());
                    ddlExistingEmp.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlExistingEmp);

                    ddlExistingEmp.Items.FindByValue(dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                cbxExistingEmployee.Checked = false;
                txtEmpName.Text = dtInsurance.Rows[0]["INSURANCE_PERSON_NAME"].ToString();
            }

            if (dtInsurance.Rows[0]["NOTFTEMP_STATUS"].ToString() == "1" && dtInsurance.Rows[0]["NOTFTEMP_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlTemplate.Items.FindByValue(dtInsurance.Rows[0]["NOTFTEMP_ID"].ToString()) != null)
                {
                    ddlTemplate.ClearSelection();
                    ddlTemplate.Items.FindByValue(dtInsurance.Rows[0]["NOTFTEMP_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["NOTFTEMP_NAME"].ToString(), dtInsurance.Rows[0]["NOTFTEMP_ID"].ToString());
                ddlTemplate.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlTemplate);
                ddlTemplate.ClearSelection();

                ddlTemplate.Items.FindByValue(dtInsurance.Rows[0]["NOTFTEMP_ID"].ToString()).Selected = true;
            }

            if (dtInsurance.Rows[0]["INSURNCTYPE_ID"].ToString() == "101")
            {
                radioOpen.Checked = true;
                txtPrjctClsngDate.Enabled = false;
            }
            else if (dtInsurance.Rows[0]["INSURNCTYPE_ID"].ToString() == "102")
            {
                radioLimited.Checked = true;
                txtValidity.Text = dtInsurance.Rows[0]["INSURANCE_NO_DAYS"].ToString();
                HiddenTextValidty.Value = dtInsurance.Rows[0]["INSURANCE_NO_DAYS"].ToString();
                txtPrjctClsngDate.Text = dtInsurance.Rows[0]["INSURANCE_EXP_DATE"].ToString();
                txtPrjctClsngDate.Enabled = true;
            }

            DataTable dtAttchmnt = new DataTable();
            dtAttchmnt.Columns.Add("PictureAttchmntDtlId", typeof(int));
            dtAttchmnt.Columns.Add("FileName", typeof(string));
            dtAttchmnt.Columns.Add("ActualFileName", typeof(string));
            dtAttchmnt.Columns.Add("Description", typeof(string));

            DataTable dtPicGalleryFull = objBusinessInsurance.ReadAttachmntsById(objEntityInsurance);

            if (dtPicGalleryFull.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtPicGalleryFull.Rows.Count; intcnt++)
                {
                    DataRow drAttch = dtAttchmnt.NewRow();
                    drAttch["PictureAttchmntDtlId"] = dtPicGalleryFull.Rows[intcnt]["INSRNC_ATTCH_ID"].ToString();
                    drAttch["FileName"] = dtPicGalleryFull.Rows[intcnt]["INSRNC_ATTCH_NAME"].ToString();
                    drAttch["ActualFileName"] = dtPicGalleryFull.Rows[intcnt]["INSRNC_ATTCH_ACT_NAME"].ToString();
                    drAttch["Description"] = dtPicGalleryFull.Rows[intcnt]["INSRNC_ATTCH_DESCRPTN"].ToString();
                    dtAttchmnt.Rows.Add(drAttch);
                }

                string strJson = DataTableToJSONWithJavaScriptSerializer(dtAttchmnt);
                hiddenEditAttchmnt.Value = strJson;
            }

            //for filling template details

            DataTable dtTemplateDetail = new DataTable();
            dtTemplateDetail.Columns.Add("TempDetailId", typeof(int));
            dtTemplateDetail.Columns.Add("NotifyMod", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyVia", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyDur", typeof(string));

            DataTable dtEachTemplateDetail = objBusinessInsurance.ReadTemplateById(objEntityInsurance);

            string strAlertDetailFull = "";
            if (dtEachTemplateDetail.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtEachTemplateDetail.Rows.Count; intcnt++)
                {
                    DataRow drAttchTempDet = dtTemplateDetail.NewRow();
                    drAttchTempDet["TempDetailId"] = dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_ID"].ToString();
                    drAttchTempDet["NotifyMod"] = dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_PERIOD"].ToString();
                    drAttchTempDet["NotifyDur"] = dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_COUNT"].ToString();
                    string strVia = "";
                    if (dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_DASHBOARD"].ToString() == "1")
                    {
                        strVia = strVia + "," + "D";
                    }
                    if (dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_EMAIL"].ToString() == "1")
                    {
                        strVia = strVia + "," + "E";
                    }
                    drAttchTempDet["NotifyVia"] = strVia;

                    dtTemplateDetail.Rows.Add(drAttchTempDet);

                    InsuranceTemplateDetail objEntityNotTempDetail = new InsuranceTemplateDetail();

                    DataTable dtTemplateAlert = new DataTable();
                    dtTemplateAlert.Columns.Add("TempDetailId", typeof(int));
                    dtTemplateAlert.Columns.Add("TempAlertId", typeof(int));
                    dtTemplateAlert.Columns.Add("AlertOpt", typeof(string));
                    dtTemplateAlert.Columns.Add("AlertNtfyId", typeof(string));

                    objEntityNotTempDetail.TempDetailId = Convert.ToInt32(dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_ID"]);

                    DataTable dtTempAlertEachSlice = objBusinessInsurance.ReadTemplateAlertById(objEntityNotTempDetail);
                    if (dtTempAlertEachSlice.Rows.Count > 0)
                    {
                        for (int intAlertcnt = 0; intAlertcnt < dtTempAlertEachSlice.Rows.Count; intAlertcnt++)
                        {
                            DataRow drAttchTempAlert = dtTemplateAlert.NewRow();
                            drAttchTempAlert["TempDetailId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPDTL_ID"].ToString();
                            drAttchTempAlert["TempAlertId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPALRT_ID"].ToString();
                            drAttchTempAlert["AlertOpt"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPALRT_OPT"].ToString();
                            if (dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPALRT_OPT"].ToString() == "3")
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPALRT_NTFYEMAILID"].ToString();
                            }
                            else
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_NOTIFY_ID"].ToString();
                            }

                            dtTemplateAlert.Rows.Add(drAttchTempAlert);
                        }
                    }

                    string strAlertJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateAlert);
                    strAlertDetailFull = strAlertDetailFull + "!" + strAlertJson;
                }

                string strJson2 = DataTableToJSONWithJavaScriptSerializer(dtTemplateDetail);
                hiddenEachTemplateDetail.Value = strJson2;
                hiddenTemplateAlertData.Value = strAlertDetailFull;
            }
            hiddenTemplateLoadingMode.Value = "FromBnk";


            if (hiddenRoleReOpen.Value != "")
            {
                if (hiddenRoleReOpen.Value == "1")
                {
                    if (dtInsurance.Rows[0]["INSURANCE_STATUS"].ToString() == "2")
                    {
                        imgbtnReOpen.Visible = true;
                    }
                }
            }

            if (hiddenRoleConfirm.Value != "")
            {
                if (hiddenRoleConfirm.Value == "1")
                {
                    if (dtInsurance.Rows[0]["INSURANCE_STATUS"].ToString() == "1")
                    {
                        btnConfirm.Visible = true;
                    }
                }
            }
            txtValidity.Enabled = false;
        }
    }

    public void View(string strId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        HiddenFieldView.Value = "1";

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (strId != "")
        {
            objEntityInsurance.InsuranceId = Convert.ToInt32(strId);
            HiddenBankGuarenteeId.Value = strId;
        }
        string strGurntNo = "";
        strGurntNo = objBusinessInsurance.CheckDupInsrncNo(objEntityInsurance);
        if (strGurntNo == "" || strGurntNo == "0")
        {
            DataTable GuarantStatus = objBusinessInsurance.ReadInsuranceStatus(objEntityInsurance);
            string strchckStatus = "";
            if (GuarantStatus.Rows.Count > 0)
            {
                strchckStatus = GuarantStatus.Rows[0]["INSURANCE_STATUS"].ToString();
            }
            if (strchckStatus == "2")
            {
                HiddenGuarStatus.Value = "2";
            }
        }

        DataTable dtInsurance = objBusinessInsurance.ReadInsuranceById(objEntityInsurance);
        if (dtInsurance.Rows.Count > 0)
        {
            HiddenFieldRefNumber2.Value = dtInsurance.Rows[0]["INSURANCE_REF_NUM"].ToString();
            LabelRefnum.Text = dtInsurance.Rows[0]["INSURANCE_REF_NUM"].ToString();
            txtInsuranceno.Text = dtInsurance.Rows[0]["INSURANCE_NUMBER"].ToString();
            txtCntctMail.Text = dtInsurance.Rows[0]["INSURANCE_PERSON_EMAIL"].ToString();
            txtOpngDate.Text = dtInsurance.Rows[0]["INSURANCE_DATE"].ToString();
            txtDescrptn.Text = dtInsurance.Rows[0]["INSURANCE_DESCRIPTION"].ToString();

            if (dtInsurance.Rows[0]["INSURPRVDR_STATUS"].ToString() == "1" && dtInsurance.Rows[0]["INSURPRVDR_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlInsurncPrvdr.Items.FindByValue(dtInsurance.Rows[0]["INSURPRVDR_ID"].ToString()) != null)
                {
                    ddlInsurncPrvdr.Items.FindByValue(dtInsurance.Rows[0]["INSURPRVDR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["INSURPRVDR_NAME"].ToString(), dtInsurance.Rows[0]["INSURPRVDR_ID"].ToString());
                ddlInsurncPrvdr.Items.Insert(1, lstGrp);
                ddlInsurncPrvdr.Items.FindByValue(dtInsurance.Rows[0]["INSURPRVDR_ID"].ToString()).Selected = true;
            }

            int intProjectId = 0; string strProjectName = "";
            if (dtInsurance.Rows[0]["PROJECT_ID"].ToString() != null || dtInsurance.Rows[0]["PROJECT_ID"].ToString() != "")
            {
                intProjectId = Convert.ToInt32(dtInsurance.Rows[0]["PROJECT_ID"].ToString());
                strProjectName = dtInsurance.Rows[0]["PROJECT_NAME"].ToString();
            }
            LoadProjects(intProjectId, strProjectName);

            if (dtInsurance.Rows[0]["INSURANCE_DONT_NOTIFY"].ToString() == "1")
            {
                cbxDontNotify.Checked = true;
            }
            else
            {
                cbxDontNotify.Checked = false;
            }
            ddlCurrency.ClearSelection();
            if (dtInsurance.Rows[0]["CRNCMST_STATUS"].ToString() == "1" && dtInsurance.Rows[0]["CRNCMST_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlCurrency.Items.FindByValue(dtInsurance.Rows[0]["CRNCMST_ID"].ToString()) != null)
                {
                    ddlCurrency.Items.FindByValue(dtInsurance.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["CRNCMST_NAME"].ToString(), dtInsurance.Rows[0]["CRNCMST_ID"].ToString());
                ddlCurrency.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCurrency);

                ddlCurrency.Items.FindByValue(dtInsurance.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }

            txtAmount.Text = dtInsurance.Rows[0]["INSURANCE_AMOUNT"].ToString();

            if (dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString() != "")
            {
                cbxExistingEmployee.Checked = true;

                if (dtInsurance.Rows[0]["USR_STATUS"].ToString() == "1" && dtInsurance.Rows[0]["USR_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlExistingEmp.Items.FindByValue(dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString()) != null)
                    {
                        ddlExistingEmp.Items.FindByValue(dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["USR_NAME"].ToString(), dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString());
                    ddlExistingEmp.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlExistingEmp);

                    ddlExistingEmp.Items.FindByValue(dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                cbxExistingEmployee.Checked = false;
                txtEmpName.Text = dtInsurance.Rows[0]["INSURANCE_PERSON_NAME"].ToString();
            }

            if (dtInsurance.Rows[0]["NOTFTEMP_STATUS"].ToString() == "1" && dtInsurance.Rows[0]["NOTFTEMP_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlTemplate.Items.FindByValue(dtInsurance.Rows[0]["NOTFTEMP_ID"].ToString()) != null)
                {
                    ddlTemplate.ClearSelection();
                    ddlTemplate.Items.FindByValue(dtInsurance.Rows[0]["NOTFTEMP_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["NOTFTEMP_NAME"].ToString(), dtInsurance.Rows[0]["NOTFTEMP_ID"].ToString());
                ddlTemplate.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlTemplate);
                ddlTemplate.ClearSelection();

                ddlTemplate.Items.FindByValue(dtInsurance.Rows[0]["NOTFTEMP_ID"].ToString()).Selected = true;
            }

            if (dtInsurance.Rows[0]["INSURNCTYPE_ID"].ToString() == "101")
            {
                radioOpen.Checked = true;
                txtPrjctClsngDate.Enabled = false;
            }
            else if (dtInsurance.Rows[0]["INSURNCTYPE_ID"].ToString() == "102")
            {
                radioLimited.Checked = true;
                txtValidity.Text = dtInsurance.Rows[0]["INSURANCE_NO_DAYS"].ToString();
                HiddenTextValidty.Value = dtInsurance.Rows[0]["INSURANCE_NO_DAYS"].ToString();
                txtPrjctClsngDate.Text = dtInsurance.Rows[0]["INSURANCE_EXP_DATE"].ToString();
                txtPrjctClsngDate.Enabled = true;
            }

            DataTable dtAttchmnt = new DataTable();
            dtAttchmnt.Columns.Add("PictureAttchmntDtlId", typeof(int));
            dtAttchmnt.Columns.Add("FileName", typeof(string));
            dtAttchmnt.Columns.Add("ActualFileName", typeof(string));
            dtAttchmnt.Columns.Add("Description", typeof(string));

            DataTable dtPicGalleryFull = objBusinessInsurance.ReadAttachmntsById(objEntityInsurance);

            if (dtPicGalleryFull.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtPicGalleryFull.Rows.Count; intcnt++)
                {
                    DataRow drAttch = dtAttchmnt.NewRow();
                    drAttch["PictureAttchmntDtlId"] = dtPicGalleryFull.Rows[intcnt]["INSRNC_ATTCH_ID"].ToString();
                    drAttch["FileName"] = dtPicGalleryFull.Rows[intcnt]["INSRNC_ATTCH_NAME"].ToString();
                    drAttch["ActualFileName"] = dtPicGalleryFull.Rows[intcnt]["INSRNC_ATTCH_ACT_NAME"].ToString();
                    drAttch["Description"] = dtPicGalleryFull.Rows[intcnt]["INSRNC_ATTCH_DESCRPTN"].ToString();
                    dtAttchmnt.Rows.Add(drAttch);
                }

                string strJson = DataTableToJSONWithJavaScriptSerializer(dtAttchmnt);
                hiddenEditAttchmnt.Value = strJson;
            }


            //for filling template details

            DataTable dtTemplateDetail = new DataTable();
            dtTemplateDetail.Columns.Add("TempDetailId", typeof(int));
            dtTemplateDetail.Columns.Add("NotifyMod", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyVia", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyDur", typeof(string));

            DataTable dtEachTemplateDetail = objBusinessInsurance.ReadTemplateById(objEntityInsurance);

            string strAlertDetailFull = "";
            if (dtEachTemplateDetail.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtEachTemplateDetail.Rows.Count; intcnt++)
                {
                    DataRow drAttchTempDet = dtTemplateDetail.NewRow();
                    drAttchTempDet["TempDetailId"] = dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_ID"].ToString();
                    drAttchTempDet["NotifyMod"] = dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_PERIOD"].ToString();
                    drAttchTempDet["NotifyDur"] = dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_COUNT"].ToString();
                    string strVia = "";
                    if (dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_DASHBOARD"].ToString() == "1")
                    {
                        strVia = strVia + "," + "D";
                    }
                    if (dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_EMAIL"].ToString() == "1")
                    {
                        strVia = strVia + "," + "E";
                    }
                    drAttchTempDet["NotifyVia"] = strVia;

                    dtTemplateDetail.Rows.Add(drAttchTempDet);

                    InsuranceTemplateDetail objEntityNotTempDetail = new InsuranceTemplateDetail();

                    DataTable dtTemplateAlert = new DataTable();
                    dtTemplateAlert.Columns.Add("TempDetailId", typeof(int));
                    dtTemplateAlert.Columns.Add("TempAlertId", typeof(int));
                    dtTemplateAlert.Columns.Add("AlertOpt", typeof(string));
                    dtTemplateAlert.Columns.Add("AlertNtfyId", typeof(string));

                    objEntityNotTempDetail.TempDetailId = Convert.ToInt32(dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_ID"]);

                    DataTable dtTempAlertEachSlice = objBusinessInsurance.ReadTemplateAlertById(objEntityNotTempDetail);
                    if (dtTempAlertEachSlice.Rows.Count > 0)
                    {
                        for (int intAlertcnt = 0; intAlertcnt < dtTempAlertEachSlice.Rows.Count; intAlertcnt++)
                        {
                            DataRow drAttchTempAlert = dtTemplateAlert.NewRow();
                            drAttchTempAlert["TempDetailId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPDTL_ID"].ToString();
                            drAttchTempAlert["TempAlertId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPALRT_ID"].ToString();
                            drAttchTempAlert["AlertOpt"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPALRT_OPT"].ToString();
                            if (dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPALRT_OPT"].ToString() == "3")
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPALRT_NTFYEMAILID"].ToString();
                            }
                            else
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_NOTIFY_ID"].ToString();
                            }

                            dtTemplateAlert.Rows.Add(drAttchTempAlert);
                        }
                    }

                    string strAlertJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateAlert);
                    strAlertDetailFull = strAlertDetailFull + "!" + strAlertJson;
                }

                string strJson2 = DataTableToJSONWithJavaScriptSerializer(dtTemplateDetail);
                hiddenEachTemplateDetail.Value = strJson2;
                hiddenTemplateAlertData.Value = strAlertDetailFull;
            }
            hiddenTemplateLoadingMode.Value = "FromBnk";

            if (hiddenRoleReOpen.Value != "")
            {
                if (hiddenRoleReOpen.Value == "1")
                {
                    if (dtInsurance.Rows[0]["INSURANCE_STATUS"].ToString() == "3")
                    {
                        imgbtnReOpen.Visible = true;
                    }
                }
            }
            if (hiddenRoleReOpen.Value != "")
            {
                if (hiddenRoleReOpen.Value == "1")
                {
                    if (dtInsurance.Rows[0]["INSURANCE_STATUS"].ToString() == "2")
                    {
                        imgbtnReOpen.Visible = true;
                    }
                }
            }

            if (HiddenGuarStatus.Value == "2" || HiddenGuarStatus.Value == "3")
            {
                if (HiddenRenew.Value == "1")
                {
                    btnrenew.Visible = true;
                }
            }
            txtDescrptn.Enabled = false;
            txtInsuranceno.Enabled = false;
            txtCntctMail.Enabled = false;
            txtOpngDate.Enabled = false;
            cbxExistingEmployee.Enabled = false;
            ddlExistingEmp.Enabled = false;
            ddlInsurncPrvdr.Enabled = false;
            ddlTemplate.Enabled = false;
            cbxDontNotify.Enabled = false;
            ddlProjects.Enabled = false;
            if (HiddenRenew.Value != "1")
            {
                img1.Attributes.Add("style", "pointer-events:none;");
            }
            img2.Attributes.Add("style", "pointer-events:none;");

            if (HiddenGuarStatus.Value == "2")
            {
                if (HiddenRenew.Value == "1")
                {
                    txtAmount.Enabled = true;
                }
                else
                {
                    txtAmount.Enabled = false;
                }
            }
            else
            {
                txtAmount.Enabled = false;
            }
            ddlCurrency.Enabled = false;
            radioOpen.Disabled = true;
            radioLimited.Disabled = true;
            txtValidity.Enabled = false;
            if (HiddenGuarStatus.Value == "2")
            {
                if (HiddenRenew.Value == "1")
                {
                    if (radioLimited.Checked == true)
                    {
                        txtPrjctClsngDate.Enabled = true;
                    }
                    else
                    {
                        txtPrjctClsngDate.Enabled = false;
                    }
                }
                else
                {
                    txtPrjctClsngDate.Enabled = false;
                }
            }
            else
            {
                txtPrjctClsngDate.Enabled = false;
            }
            txtEmpName.Enabled = false;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Request.QueryString["Id"] != null || Request.QueryString["ViewId"] != null)
        {
            string strRandomMixedId = "";
            if (Request.QueryString["Id"] != null)
            {
                strRandomMixedId = Request.QueryString["Id"].ToString();
            }
            if (Request.QueryString["ViewId"] != null)
            {
                strRandomMixedId = Request.QueryString["ViewId"].ToString();
            }
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityInsurance.InsuranceId = Convert.ToInt32(strId);

            objEntityInsurance.RefNumber = HiddenFieldRefNumber2.Value;
            objEntityInsurance.InsuranceNo = txtInsuranceno.Text.Trim();

            if (HiddenFieldAmount.Value.Trim() != "")
            {
                objEntityInsurance.Amount = Convert.ToDecimal(HiddenFieldAmount.Value);
            }
            objEntityInsurance.ProjectId = Convert.ToInt32(ddlProjects.SelectedItem.Value);
            if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
            {
                objEntityInsurance.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            }


            if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
            {
                objEntityInsurance.InsuranceProvider = Convert.ToInt32(ddlInsurncPrvdr.SelectedItem.Value);
            }
            if (radioOpen.Checked == true)
            {
                objEntityInsurance.InsuranceTyp = 101;
                objEntityInsurance.ExpireDate = DateTime.MinValue;
            }
            else if (radioLimited.Checked == true)
            {
                objEntityInsurance.InsuranceTyp = 102;
                objEntityInsurance.NoOfDays = Convert.ToInt32(HiddenTextValidty.Value);
                objEntityInsurance.ExpireDate = objCommon.textToDateTime(txtPrjctClsngDate.Text.Trim());
            }
            objEntityInsurance.OpenDate = objCommon.textToDateTime(txtOpngDate.Text.Trim());

            if (cbxDontNotify.Checked == true)
            {
                objEntityInsurance.DontNotify = 1;
            }
            else
            {
                objEntityInsurance.DontNotify = 0;
            }

            objEntityInsurance.NotTempId = Convert.ToInt32(ddlTemplate.SelectedItem.Value);
            objEntityInsurance.Description = txtDescrptn.Text.Trim();

            if (cbxExistingEmployee.Checked == true)
            {
                if (ddlExistingEmp.SelectedItem.Value != "--SELECT EMPLOYEE--")
                {
                    objEntityInsurance.EmployeName = ddlExistingEmp.SelectedItem.Text;
                    objEntityInsurance.ContactPersnUsrId = Convert.ToInt32(ddlExistingEmp.SelectedItem.Value);
                }
            }
            else
            {
                objEntityInsurance.EmployeName = txtEmpName.Text.Trim();
            }
            objEntityInsurance.Email = txtCntctMail.Text.Trim();
            objEntityInsurance.D_Date = System.DateTime.Now;

            string strGurntNo = "";
            strGurntNo = objBusinessInsurance.CheckDupInsrncNo(objEntityInsurance);

            if (strGurntNo == "" || strGurntNo == "0")
            {
                objBusinessInsurance.UpdateInsurance(objEntityInsurance);


                //for UPDATING attachmnts

                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_ATTACHMNT);
                objEntityCommon.CorporateID = objEntityInsurance.CorpOffice_Id;

                List<clsEntityLayerInsuranceAttachments> objEntityLayerGuarenteeAtchmntDtlList = new List<clsEntityLayerInsuranceAttachments>();

                int intSlNumbr = 0;
                if (hiddenAttchmntSlNumber.Value != "")
                {
                    intSlNumbr = Convert.ToInt32(hiddenAttchmntSlNumber.Value);
                    intSlNumbr++;
                }

                if (HiddenField2_FileUploadLnk.Value != "" && HiddenField2_FileUploadLnk.Value != null && HiddenField2_FileUploadLnk.Value != "[]")
                {
                    string jsonDataDltAttch = HiddenField2_FileUploadLnk.Value;
                    string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                    string strAtt2 = strAtt1.Replace("\\", "");
                    string strAtt3 = strAtt2.Replace("}\"]", "}]");
                    string strAtt4 = strAtt3.Replace("}\",", "},");

                    List<clsBannerDataADDAttchmnt> objBannerDataDltAttList = new List<clsBannerDataADDAttchmnt>();
                    objBannerDataDltAttList = JsonConvert.DeserializeObject<List<clsBannerDataADDAttchmnt>>(strAtt4);

                    foreach (clsBannerDataADDAttchmnt objClsBannrAddAttData in objBannerDataDltAttList)
                    {
                        if (objClsBannrAddAttData.EVTACTION == "INS")
                        {
                            string strfilepath = Convert.ToString(objClsBannrAddAttData.ROWID);

                            HttpPostedFile PostedFile = Request.Files["file" + strfilepath];
                            if (PostedFile.ContentLength > 0)
                            {
                                clsEntityLayerInsuranceAttachments objEntityLayerGuarnteeAtchmntDtl = new clsEntityLayerInsuranceAttachments();
                                string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                objEntityLayerGuarnteeAtchmntDtl.ActualFileName = strFileName;

                                string strFileExt;
                                strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                                int intAppModSection = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_ATTACHMNT);
                                int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                                objEntityLayerGuarnteeAtchmntDtl.AttchmntSlNumber = intSlNumbr;
                                string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + "_" + intSlNumbr + "." + strFileExt;
                                objEntityLayerGuarnteeAtchmntDtl.FileName = strImageName;

                                objEntityLayerGuarnteeAtchmntDtl.CaptionName = Request.Form["textbx" + strfilepath];

                                objEntityLayerGuarnteeAtchmntDtl.InsuranceId = Convert.ToInt32(HiddenBankGuarenteeId.Value);

                                string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                                PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityLayerGuarnteeAtchmntDtl.FileName);

                                objEntityLayerGuarenteeAtchmntDtlList.Add(objEntityLayerGuarnteeAtchmntDtl);
                                intSlNumbr++;
                            }


                        }
                    }
                }

                List<clsEntityLayerInsuranceAttachments> objEntityLayerInsuranceAtchmntDtlListDelete = new List<clsEntityLayerInsuranceAttachments>();

                if (hiddenFileCanclDtlId.Value != "" && hiddenFileCanclDtlId.Value != null)
                {
                    string jsonDataDltAttch = hiddenFileCanclDtlId.Value;
                    string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                    string strAtt2 = strAtt1.Replace("\\", "");
                    string strAtt3 = strAtt2.Replace("}\"]", "}]");
                    string strAtt4 = strAtt3.Replace("}\",", "},");

                    List<clsPictureDataDELETEAttchmnt> objPictureDataDltAttList = new List<clsPictureDataDELETEAttchmnt>();
                    objPictureDataDltAttList = JsonConvert.DeserializeObject<List<clsPictureDataDELETEAttchmnt>>(strAtt4);

                    foreach (clsPictureDataDELETEAttchmnt objClsPictureDltAttData in objPictureDataDltAttList)
                    {
                        clsEntityLayerInsuranceAttachments objEntityLayerInsuranceAtchmntDtl = new clsEntityLayerInsuranceAttachments();

                        objEntityLayerInsuranceAtchmntDtl.PictureId = Convert.ToInt32(objClsPictureDltAttData.DTLID);
                        objEntityLayerInsuranceAtchmntDtl.FileName = Convert.ToString(objClsPictureDltAttData.FILENAME);
                        objEntityLayerInsuranceAtchmntDtlListDelete.Add(objEntityLayerInsuranceAtchmntDtl);
                    }
                }

                if (objEntityLayerGuarenteeAtchmntDtlList.Count > 0)
                {
                    objBusinessInsurance.Add_Pictures(objEntityInsurance, objEntityLayerGuarenteeAtchmntDtlList);
                }

                if (objEntityLayerInsuranceAtchmntDtlListDelete.Count > 0)
                {
                    objBusinessInsurance.Delete_Pictures(objEntityInsurance, objEntityLayerInsuranceAtchmntDtlListDelete);

                    foreach (clsEntityLayerInsuranceAttachments objEntityLayerIInsuranceAtchmntDtl in objEntityLayerInsuranceAtchmntDtlListDelete)
                    {
                        string strImgPath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                        string imageLocation = strImgPath + objEntityLayerIInsuranceAtchmntDtl.FileName;
                        if (File.Exists(MapPath(imageLocation)))
                        {
                            File.Delete(MapPath(imageLocation));
                        }
                    }
                }

                objEntityInsurance.NextIdForRqst = objEntityInsurance.InsuranceId;

                //for UPDATING template
                if (hiddenTemplateChange.Value == "CHANGED")
                {
                    //TEMPLT CHANGED

                    objBusinessInsurance.DeleteTemplateAlertById(objEntityInsurance);
                    objBusinessInsurance.DeleteTemplateDetailById(objEntityInsurance);

                    int TemplateCount = Convert.ToInt32(hiddenTemplateCount.Value);
                    string strEachTempTotalString = hiddenEachSliceData.Value;
                    string strNotifyMode = hiddenNotificationMOde.Value;
                    string strNotifyVia = hiddenNotifyVia.Value;
                    string strNotifyDur = hiddenNotificationDuration.Value;
                    int TempCount = Convert.ToInt32(hiddenTemplateCount.Value);

                    string[] strEachTempString = new string[TempCount];
                    strEachTempString = strEachTempTotalString.Split('!');

                    for (int intCount = 0; intCount < TempCount; intCount++)
                    {
                        InsuranceTemplateDetail objEntityTempDeatils = new InsuranceTemplateDetail();

                        //for template mode
                        string jsonDataNotyMod = strNotifyMode;
                        string a = jsonDataNotyMod.Replace("\"{", "\\{");
                        string b = a.Replace("\\n", "\r\n");
                        string c = b.Replace("\\", "");
                        string d = c.Replace("}\"]", "}]");
                        string k = d.Replace("}\",", "},");

                        List<clsEachTempNotyMOde> objEachTempDetModList = new List<clsEachTempNotyMOde>();
                        objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde>>(k);

                        string MODEROWID = objEachTempDetModList[intCount].ROWID;
                        string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                        string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                        if (NOTMODE == "D")
                        {
                            objEntityTempDeatils.TempDetPeriod = 2;
                        }
                        else
                        {
                            objEntityTempDeatils.TempDetPeriod = 1;
                        }

                        //for template NotifyVia
                        string jsonDataNotyVia = strNotifyVia;
                        string l = jsonDataNotyVia.Replace("\"{", "\\{");
                        string m = l.Replace("\\n", "\r\n");
                        string n = m.Replace("\\", "");
                        string o = n.Replace("}\"]", "}]");
                        string p = o.Replace("}\",", "},");

                        List<clsEachTempNotyVia> objEachTempDetViaList = new List<clsEachTempNotyVia>();
                        objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia>>(p);

                        string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                        string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                        string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                        if (VIAWHT.Contains("D"))
                        {
                            objEntityTempDeatils.IsDashBoard = 1;
                        }
                        if (VIAWHT.Contains("E"))
                        {
                            objEntityTempDeatils.IsEmail = 1;
                        }

                        //for template notify Duration
                        string jsonDataNotyDur = strNotifyDur;
                        string q = jsonDataNotyDur.Replace("\"{", "\\{");
                        string r = q.Replace("\\n", "\r\n");
                        string s = r.Replace("\\", "");
                        string t = s.Replace("}\"]", "}]");
                        string u = t.Replace("}\",", "},");

                        List<clsEachTempNotyDur> objEachTempDetDurList = new List<clsEachTempNotyDur>();
                        objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur>>(u);

                        string DURROWID = objEachTempDetDurList[intCount].ROWID;
                        string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                        string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                        objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);


                        string jsonData = strEachTempString[intCount + 1];
                        string V = jsonData.Replace("\"{", "\\{");
                        string W = V.Replace("\\n", "\r\n");
                        string X = W.Replace("\\", "");
                        string Y = X.Replace("}\"]", "}]");
                        string Z = Y.Replace("}\",", "},");

                        List<InsuranceTemplateAlert> objEntityTempAlertList = new List<InsuranceTemplateAlert>();

                        List<clsEachTempDeatail> objEachTempDetList = new List<clsEachTempDeatail>();
                        objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail>>(Z);

                        if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                        {

                            for (int count = 0; count < objEachTempDetList.Count; count++)
                            {
                                string ROWID = objEachTempDetList[count].ROWID;

                                string VALUE = objEachTempDetList[count].DDLVALUE;
                                string DDLMODE = objEachTempDetList[count].DDLMODE;
                                string DTLID = objEachTempDetList[count].DTLID;
                                if (VALUE != "0")
                                {
                                    InsuranceTemplateAlert objEntityTemplateAlert = new InsuranceTemplateAlert();
                                    if (DDLMODE == "ddlDivision_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 0;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "ddlDesignation_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 1;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "ddlEmployee_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 2;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "txtGenMail_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 3;
                                        objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                                    }


                                    objEntityTempAlertList.Add(objEntityTemplateAlert);
                                }
                            }

                        }

                        objBusinessInsurance.AddTemplateDetail(objEntityInsurance, objEntityTempDeatils, objEntityTempAlertList);
                    }
                }
                else
                {
                    //SAME TEMPLT UPDT

                    int TemplateCount = Convert.ToInt32(hiddenTemplateCount.Value);
                    string strEachTempTotalString = hiddenEachSliceData.Value;
                    string strNotifyMode = hiddenNotificationMOde.Value;
                    string strNotifyVia = hiddenNotifyVia.Value;
                    string strNotifyDur = hiddenNotificationDuration.Value;
                    //-----for template ---
                    int TempCount = Convert.ToInt32(hiddenTemplateCount.Value);

                    string[] strEachTempString = new string[TempCount];
                    strEachTempString = strEachTempTotalString.Split('!');

                    for (int intCount = 0; intCount < TempCount; intCount++)
                    {
                        InsuranceTemplateDetail objEntityTempDeatils = new InsuranceTemplateDetail();

                        //for template mode
                        string jsonDataNotyMod = strNotifyMode;
                        string a = jsonDataNotyMod.Replace("\"{", "\\{");
                        string b = a.Replace("\\n", "\r\n");
                        string c = b.Replace("\\", "");
                        string d = c.Replace("}\"]", "}]");
                        string k = d.Replace("}\",", "},");

                        List<clsEachTempNotyMOde> objEachTempDetModList = new List<clsEachTempNotyMOde>();
                        objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde>>(k);

                        string MODEROWID = objEachTempDetModList[intCount].ROWID;
                        string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                        string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                        if (NOTMODE == "D")
                        {
                            objEntityTempDeatils.TempDetPeriod = 2;
                        }
                        else
                        {
                            objEntityTempDeatils.TempDetPeriod = 1;
                        }
                        if (MODETEMPID != "0")
                        {
                            objEntityTempDeatils.TempDetailId = Convert.ToInt32(MODETEMPID);
                        }
                        //for template NotifyVia
                        string jsonDataNotyVia = strNotifyVia;
                        string l = jsonDataNotyVia.Replace("\"{", "\\{");
                        string m = l.Replace("\\n", "\r\n");
                        string n = m.Replace("\\", "");
                        string o = n.Replace("}\"]", "}]");
                        string p = o.Replace("}\",", "},");

                        List<clsEachTempNotyVia> objEachTempDetViaList = new List<clsEachTempNotyVia>();
                        objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia>>(p);

                        string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                        string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                        string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                        if (VIAWHT.Contains("D"))
                        {
                            objEntityTempDeatils.IsDashBoard = 1;
                        }
                        if (VIAWHT.Contains("E"))
                        {
                            objEntityTempDeatils.IsEmail = 1;
                        }

                        //for template notify Duration
                        string jsonDataNotyDur = strNotifyDur;
                        string q = jsonDataNotyDur.Replace("\"{", "\\{");
                        string r = q.Replace("\\n", "\r\n");
                        string s = r.Replace("\\", "");
                        string t = s.Replace("}\"]", "}]");
                        string u = t.Replace("}\",", "},");

                        List<clsEachTempNotyDur> objEachTempDetDurList = new List<clsEachTempNotyDur>();
                        objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur>>(u);

                        string DURROWID = objEachTempDetDurList[intCount].ROWID;
                        string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                        string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                        objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);

                        string jsonData = strEachTempString[intCount + 1];
                        string V = jsonData.Replace("\"{", "\\{");
                        string W = V.Replace("\\n", "\r\n");
                        string X = W.Replace("\\", "");
                        string Y = X.Replace("}\"]", "}]");
                        string Z = Y.Replace("}\",", "},");

                        List<InsuranceTemplateAlert> objEntityTempAlertList = new List<InsuranceTemplateAlert>();


                        List<clsEachTempDeatail> objEachTempDetList = new List<clsEachTempDeatail>();
                        objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail>>(Z);



                        if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                        {
                            int AddingCount = 0;
                            for (int count = 0; count < objEachTempDetList.Count; count++)
                            {
                                string ROWID = objEachTempDetList[count].ROWID;

                                string VALUE = objEachTempDetList[count].DDLVALUE;
                                string DDLMODE = objEachTempDetList[count].DDLMODE;
                                string DTLID = objEachTempDetList[count].DTLID;
                                if (VALUE != "0")
                                {
                                    InsuranceTemplateAlert objEntityTemplateAlert = new InsuranceTemplateAlert();
                                    if (DDLMODE == "ddlDivision_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 0;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "ddlDesignation_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 1;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "ddlEmployee_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 2;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "txtGenMail_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 3;
                                        objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                                    }

                                    if (DTLID != "0")
                                    {
                                        objEntityTemplateAlert.TemplateAlertId = Convert.ToInt32(DTLID);
                                        objBusinessInsurance.UpdateTemplateAlert(objEntityTempDeatils, objEntityTemplateAlert);
                                    }
                                    else
                                    {
                                        AddingCount++;
                                        objEntityTempAlertList.Add(objEntityTemplateAlert);
                                    }
                                }

                            }
                            if (objEntityTempDeatils.TempDetailId != 0)
                            {
                                if (AddingCount != 0)
                                {
                                    objBusinessInsurance.AddTemplateAlert(objEntityInsurance, objEntityTempDeatils, objEntityTempAlertList);
                                }
                            }
                        }

                        if (objEntityTempDeatils.TempDetailId != 0)
                        {
                            objBusinessInsurance.UpdateTemplateDetail(objEntityTempDeatils);
                        }
                        else
                        {
                            objBusinessInsurance.AddTemplateDetail(objEntityInsurance, objEntityTempDeatils, objEntityTempAlertList);
                        }
                    }

                    string strTotalDelete = hiddenDeleteSliceData.Value;
                    string[] strEachTempDelete = new string[TempCount];
                    strEachTempDelete = strTotalDelete.Split('!');
                    for (int intDCount = 1; intDCount <= TempCount; intDCount++)
                    {
                        if (strEachTempDelete[intDCount] != null && strEachTempDelete[intDCount] != "" && strEachTempDelete[intDCount] != "null")
                        {
                            string strDeletedAlert = strEachTempDelete[intDCount];
                            string jsonDataDeleted = strDeletedAlert;
                            string d1 = jsonDataDeleted.Replace("\"{", "\\{");
                            string d2 = d1.Replace("\\n", "\r\n");
                            string d3 = d2.Replace("\\", "");
                            string d4 = d3.Replace("}\"]", "}]");
                            string d5 = d4.Replace("}\",", "},");
                            List<InsuranceTemplateAlert> objEntityTempAlertDeleteList = new List<InsuranceTemplateAlert>();


                            List<clsEachAlertDel> objAlertDelList = new List<clsEachAlertDel>();
                            objAlertDelList = JsonConvert.DeserializeObject<List<clsEachAlertDel>>(d5);
                            for (int delcount = 0; delcount < objAlertDelList.Count; delcount++)
                            {
                                string ROWID = objAlertDelList[delcount].ROWID;
                                string AlertVALUE = objAlertDelList[delcount].DTLID;

                                InsuranceTemplateAlert objEntityTempAlertDelete = new InsuranceTemplateAlert();
                                objEntityTempAlertDelete.TemplateAlertId = Convert.ToInt32(AlertVALUE);
                                objEntityTempAlertDeleteList.Add(objEntityTempAlertDelete);
                            }

                            objBusinessInsurance.DeleteTemplateAlert(objEntityTempAlertDeleteList);
                        }
                    }
                }

                if (clickedButton.ID == "btnUpdate")
                {
                    //REDIRECT TO UPDATE VIEW
                    List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                    objEntityCommon.RedirectUrl = "gen_Insurance_Master.aspx";
                    clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "InsUpd";
                    objEntityQueryString.QueryStringValue = "Upd";
                    objEntityQueryString.Encrypt = 0;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "Id";
                    objEntityQueryString.QueryStringValue = strId;
                    objEntityQueryString.Encrypt = 1;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);

                    Response.Redirect(strRedirectUrl);
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    if (Request.QueryString["default"] != null)
                    {
                        if (Request.QueryString["default"] == "3months")
                        {
                            Response.Redirect("gen_Insurance_Master_List.aspx?InsUpd=Upd&default=3months");
                        }
                        else if (Request.QueryString["default"] == "expired")
                        {
                            Response.Redirect("gen_Insurance_Master_List.aspx?InsUpd=Upd&default=expired");
                        }
                        else if (Request.QueryString["default"] == "new")
                        {
                            Response.Redirect("gen_Insurance_Master_List.aspx?InsUpd=Upd&default=new");
                        }
                        else
                        {
                            Response.Redirect("gen_Insurance_Master_List.aspx?InsUpd=Upd");
                        }
                    }
                    else
                    {
                        Response.Redirect("gen_Insurance_Master_List.aspx?InsUpd=Upd");
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Duplication", "Duplication();", true);
            }
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Request.QueryString["Id"] != null || Request.QueryString["ViewId"] != null)
        {
            string strRandomMixedId = "";
            if (Request.QueryString["Id"] != null)
            {
                strRandomMixedId = Request.QueryString["Id"].ToString();
            }
            if (Request.QueryString["ViewId"] != null)
            {
                strRandomMixedId = Request.QueryString["ViewId"].ToString();
            }
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityInsurance.InsuranceId = Convert.ToInt32(strId);

            objEntityInsurance.RefNumber = HiddenFieldRefNumber2.Value;
            objEntityInsurance.InsuranceNo = txtInsuranceno.Text.Trim();

            if (HiddenFieldAmount.Value.Trim() != "")
            {
                objEntityInsurance.Amount = Convert.ToDecimal(HiddenFieldAmount.Value);
            }
            objEntityInsurance.ProjectId = Convert.ToInt32(ddlProjects.SelectedItem.Value);
            if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
            {
                objEntityInsurance.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            }

            if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
            {
                objEntityInsurance.InsuranceProvider = Convert.ToInt32(ddlInsurncPrvdr.SelectedItem.Value);
            }
            if (radioOpen.Checked == true)
            {
                objEntityInsurance.InsuranceTyp = 101;
                objEntityInsurance.ExpireDate = DateTime.MinValue;
            }
            else if (radioLimited.Checked == true)
            {
                objEntityInsurance.InsuranceTyp = 102;
                objEntityInsurance.NoOfDays = Convert.ToInt32(HiddenTextValidty.Value);
                objEntityInsurance.ExpireDate = objCommon.textToDateTime(txtPrjctClsngDate.Text.Trim());
            }
            objEntityInsurance.OpenDate = objCommon.textToDateTime(txtOpngDate.Text.Trim());

            if (cbxDontNotify.Checked == true)
            {
                objEntityInsurance.DontNotify = 1;
            }
            else
            {
                objEntityInsurance.DontNotify = 0;
            }

            objEntityInsurance.NotTempId = Convert.ToInt32(ddlTemplate.SelectedItem.Value);
            objEntityInsurance.Description = txtDescrptn.Text.Trim();

            if (cbxExistingEmployee.Checked == true)
            {
                if (ddlExistingEmp.SelectedItem.Value != "--SELECT EMPLOYEE--")
                {
                    objEntityInsurance.EmployeName = ddlExistingEmp.SelectedItem.Text;
                    objEntityInsurance.ContactPersnUsrId = Convert.ToInt32(ddlExistingEmp.SelectedItem.Value);
                }
            }
            else
            {
                objEntityInsurance.EmployeName = txtEmpName.Text.Trim();
            }
            objEntityInsurance.Email = txtCntctMail.Text.Trim();
            objEntityInsurance.D_Date = System.DateTime.Now;

            string strGurntNo = "";
            strGurntNo = objBusinessInsurance.CheckDupInsrncNo(objEntityInsurance);

            if (strGurntNo == "" || strGurntNo == "0")
            {

                DataTable GuarantStatus = objBusinessInsurance.ReadInsuranceStatus(objEntityInsurance);
                string strchckStatus = "";
                if (GuarantStatus.Rows.Count > 0)
                {
                    strchckStatus = GuarantStatus.Rows[0]["INSURANCE_STATUS"].ToString();
                }
                if (strchckStatus == "1")
                {
                    objEntityInsurance.StatusIdCheck = 2;
                }
                else if (strchckStatus == "3")
                {
                    objEntityInsurance.StatusIdCheck = 4;
                }
                if (strchckStatus != "2")
                {

                    objBusinessInsurance.UpdateInsurance(objEntityInsurance);
                    objBusinessInsurance.ConfirmInsurance(objEntityInsurance);

                    //for UPDATING attachmnts

                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_ATTACHMNT);
                    objEntityCommon.CorporateID = objEntityInsurance.CorpOffice_Id;

                    List<clsEntityLayerInsuranceAttachments> objEntityLayerGuarenteeAtchmntDtlList = new List<clsEntityLayerInsuranceAttachments>();

                    int intSlNumbr = 0;
                    if (hiddenAttchmntSlNumber.Value != "")
                    {
                        intSlNumbr = Convert.ToInt32(hiddenAttchmntSlNumber.Value);
                        intSlNumbr++;
                    }

                    if (HiddenField2_FileUploadLnk.Value != "" && HiddenField2_FileUploadLnk.Value != null && HiddenField2_FileUploadLnk.Value != "[]")
                    {
                        string jsonDataDltAttch = HiddenField2_FileUploadLnk.Value;
                        string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                        string strAtt2 = strAtt1.Replace("\\", "");
                        string strAtt3 = strAtt2.Replace("}\"]", "}]");
                        string strAtt4 = strAtt3.Replace("}\",", "},");

                        List<clsBannerDataADDAttchmnt> objBannerDataDltAttList = new List<clsBannerDataADDAttchmnt>();
                        objBannerDataDltAttList = JsonConvert.DeserializeObject<List<clsBannerDataADDAttchmnt>>(strAtt4);

                        foreach (clsBannerDataADDAttchmnt objClsBannrAddAttData in objBannerDataDltAttList)
                        {
                            if (objClsBannrAddAttData.EVTACTION == "INS")
                            {
                                string strfilepath = Convert.ToString(objClsBannrAddAttData.ROWID);

                                HttpPostedFile PostedFile = Request.Files["file" + strfilepath];
                                if (PostedFile.ContentLength > 0)
                                {
                                    clsEntityLayerInsuranceAttachments objEntityLayerGuarnteeAtchmntDtl = new clsEntityLayerInsuranceAttachments();
                                    string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                    objEntityLayerGuarnteeAtchmntDtl.ActualFileName = strFileName;

                                    string strFileExt;
                                    strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                                    int intAppModSection = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_ATTACHMNT);
                                    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                                    objEntityLayerGuarnteeAtchmntDtl.AttchmntSlNumber = intSlNumbr;
                                    string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + "_" + intSlNumbr + "." + strFileExt;
                                    objEntityLayerGuarnteeAtchmntDtl.FileName = strImageName;

                                    objEntityLayerGuarnteeAtchmntDtl.CaptionName = Request.Form["textbx" + strfilepath];

                                    objEntityLayerGuarnteeAtchmntDtl.InsuranceId = Convert.ToInt32(HiddenBankGuarenteeId.Value);

                                    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                                    PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityLayerGuarnteeAtchmntDtl.FileName);

                                    objEntityLayerGuarenteeAtchmntDtlList.Add(objEntityLayerGuarnteeAtchmntDtl);
                                    intSlNumbr++;
                                }


                            }
                        }
                    }

                    List<clsEntityLayerInsuranceAttachments> objEntityLayerInsuranceAtchmntDtlListDelete = new List<clsEntityLayerInsuranceAttachments>();

                    if (hiddenFileCanclDtlId.Value != "" && hiddenFileCanclDtlId.Value != null)
                    {
                        string jsonDataDltAttch = hiddenFileCanclDtlId.Value;
                        string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                        string strAtt2 = strAtt1.Replace("\\", "");
                        string strAtt3 = strAtt2.Replace("}\"]", "}]");
                        string strAtt4 = strAtt3.Replace("}\",", "},");

                        List<clsPictureDataDELETEAttchmnt> objPictureDataDltAttList = new List<clsPictureDataDELETEAttchmnt>();
                        objPictureDataDltAttList = JsonConvert.DeserializeObject<List<clsPictureDataDELETEAttchmnt>>(strAtt4);

                        foreach (clsPictureDataDELETEAttchmnt objClsPictureDltAttData in objPictureDataDltAttList)
                        {
                            clsEntityLayerInsuranceAttachments objEntityLayerInsuranceAtchmntDtl = new clsEntityLayerInsuranceAttachments();

                            objEntityLayerInsuranceAtchmntDtl.PictureId = Convert.ToInt32(objClsPictureDltAttData.DTLID);
                            objEntityLayerInsuranceAtchmntDtl.FileName = Convert.ToString(objClsPictureDltAttData.FILENAME);
                            objEntityLayerInsuranceAtchmntDtlListDelete.Add(objEntityLayerInsuranceAtchmntDtl);
                        }
                    }

                    if (objEntityLayerGuarenteeAtchmntDtlList.Count > 0)
                    {
                        objBusinessInsurance.Add_Pictures(objEntityInsurance, objEntityLayerGuarenteeAtchmntDtlList);
                    }

                    if (objEntityLayerInsuranceAtchmntDtlListDelete.Count > 0)
                    {
                        objBusinessInsurance.Delete_Pictures(objEntityInsurance, objEntityLayerInsuranceAtchmntDtlListDelete);

                        foreach (clsEntityLayerInsuranceAttachments objEntityLayerIInsuranceAtchmntDtl in objEntityLayerInsuranceAtchmntDtlListDelete)
                        {
                            string strImgPath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                            string imageLocation = strImgPath + objEntityLayerIInsuranceAtchmntDtl.FileName;
                            if (File.Exists(MapPath(imageLocation)))
                            {
                                File.Delete(MapPath(imageLocation));
                            }
                        }
                    }

                    objEntityInsurance.NextIdForRqst = objEntityInsurance.InsuranceId;

                    //for UPDATING template
                    if (hiddenTemplateChange.Value == "CHANGED")
                    {
                        //TEMPLT CHANGED

                        objBusinessInsurance.DeleteTemplateAlertById(objEntityInsurance);
                        objBusinessInsurance.DeleteTemplateDetailById(objEntityInsurance);

                        int TemplateCount = Convert.ToInt32(hiddenTemplateCount.Value);
                        string strEachTempTotalString = hiddenEachSliceData.Value;
                        string strNotifyMode = hiddenNotificationMOde.Value;
                        string strNotifyVia = hiddenNotifyVia.Value;
                        string strNotifyDur = hiddenNotificationDuration.Value;
                        int TempCount = Convert.ToInt32(hiddenTemplateCount.Value);

                        string[] strEachTempString = new string[TempCount];
                        strEachTempString = strEachTempTotalString.Split('!');

                        for (int intCount = 0; intCount < TempCount; intCount++)
                        {
                            InsuranceTemplateDetail objEntityTempDeatils = new InsuranceTemplateDetail();

                            //for template mode
                            string jsonDataNotyMod = strNotifyMode;
                            string a = jsonDataNotyMod.Replace("\"{", "\\{");
                            string b = a.Replace("\\n", "\r\n");
                            string c = b.Replace("\\", "");
                            string d = c.Replace("}\"]", "}]");
                            string k = d.Replace("}\",", "},");

                            List<clsEachTempNotyMOde> objEachTempDetModList = new List<clsEachTempNotyMOde>();
                            objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde>>(k);

                            string MODEROWID = objEachTempDetModList[intCount].ROWID;
                            string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                            string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                            if (NOTMODE == "D")
                            {
                                objEntityTempDeatils.TempDetPeriod = 2;
                            }
                            else
                            {
                                objEntityTempDeatils.TempDetPeriod = 1;
                            }

                            //for template NotifyVia
                            string jsonDataNotyVia = strNotifyVia;
                            string l = jsonDataNotyVia.Replace("\"{", "\\{");
                            string m = l.Replace("\\n", "\r\n");
                            string n = m.Replace("\\", "");
                            string o = n.Replace("}\"]", "}]");
                            string p = o.Replace("}\",", "},");

                            List<clsEachTempNotyVia> objEachTempDetViaList = new List<clsEachTempNotyVia>();
                            objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia>>(p);

                            string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                            string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                            string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                            if (VIAWHT.Contains("D"))
                            {
                                objEntityTempDeatils.IsDashBoard = 1;
                            }
                            if (VIAWHT.Contains("E"))
                            {
                                objEntityTempDeatils.IsEmail = 1;
                            }

                            //for template notify Duration
                            string jsonDataNotyDur = strNotifyDur;
                            string q = jsonDataNotyDur.Replace("\"{", "\\{");
                            string r = q.Replace("\\n", "\r\n");
                            string s = r.Replace("\\", "");
                            string t = s.Replace("}\"]", "}]");
                            string u = t.Replace("}\",", "},");

                            List<clsEachTempNotyDur> objEachTempDetDurList = new List<clsEachTempNotyDur>();
                            objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur>>(u);

                            string DURROWID = objEachTempDetDurList[intCount].ROWID;
                            string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                            string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                            objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);


                            string jsonData = strEachTempString[intCount + 1];
                            string V = jsonData.Replace("\"{", "\\{");
                            string W = V.Replace("\\n", "\r\n");
                            string X = W.Replace("\\", "");
                            string Y = X.Replace("}\"]", "}]");
                            string Z = Y.Replace("}\",", "},");

                            List<InsuranceTemplateAlert> objEntityTempAlertList = new List<InsuranceTemplateAlert>();

                            List<clsEachTempDeatail> objEachTempDetList = new List<clsEachTempDeatail>();
                            objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail>>(Z);

                            if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                            {

                                for (int count = 0; count < objEachTempDetList.Count; count++)
                                {
                                    string ROWID = objEachTempDetList[count].ROWID;

                                    string VALUE = objEachTempDetList[count].DDLVALUE;
                                    string DDLMODE = objEachTempDetList[count].DDLMODE;
                                    string DTLID = objEachTempDetList[count].DTLID;
                                    if (VALUE != "0")
                                    {
                                        InsuranceTemplateAlert objEntityTemplateAlert = new InsuranceTemplateAlert();
                                        if (DDLMODE == "ddlDivision_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 0;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "ddlDesignation_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 1;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "ddlEmployee_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 2;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "txtGenMail_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 3;
                                            objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                                        }


                                        objEntityTempAlertList.Add(objEntityTemplateAlert);
                                    }
                                }

                            }

                            objBusinessInsurance.AddTemplateDetail(objEntityInsurance, objEntityTempDeatils, objEntityTempAlertList);
                        }
                    }
                    else
                    {
                        //SAME TEMPLT UPDT

                        int TemplateCount = Convert.ToInt32(hiddenTemplateCount.Value);
                        string strEachTempTotalString = hiddenEachSliceData.Value;
                        string strNotifyMode = hiddenNotificationMOde.Value;
                        string strNotifyVia = hiddenNotifyVia.Value;
                        string strNotifyDur = hiddenNotificationDuration.Value;
                        //-----for template ---
                        int TempCount = Convert.ToInt32(hiddenTemplateCount.Value);

                        string[] strEachTempString = new string[TempCount];
                        strEachTempString = strEachTempTotalString.Split('!');

                        for (int intCount = 0; intCount < TempCount; intCount++)
                        {
                            InsuranceTemplateDetail objEntityTempDeatils = new InsuranceTemplateDetail();

                            //for template mode
                            string jsonDataNotyMod = strNotifyMode;
                            string a = jsonDataNotyMod.Replace("\"{", "\\{");
                            string b = a.Replace("\\n", "\r\n");
                            string c = b.Replace("\\", "");
                            string d = c.Replace("}\"]", "}]");
                            string k = d.Replace("}\",", "},");

                            List<clsEachTempNotyMOde> objEachTempDetModList = new List<clsEachTempNotyMOde>();
                            objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde>>(k);

                            string MODEROWID = objEachTempDetModList[intCount].ROWID;
                            string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                            string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                            if (NOTMODE == "D")
                            {
                                objEntityTempDeatils.TempDetPeriod = 2;
                            }
                            else
                            {
                                objEntityTempDeatils.TempDetPeriod = 1;
                            }
                            if (MODETEMPID != "0")
                            {
                                objEntityTempDeatils.TempDetailId = Convert.ToInt32(MODETEMPID);
                            }
                            //for template NotifyVia
                            string jsonDataNotyVia = strNotifyVia;
                            string l = jsonDataNotyVia.Replace("\"{", "\\{");
                            string m = l.Replace("\\n", "\r\n");
                            string n = m.Replace("\\", "");
                            string o = n.Replace("}\"]", "}]");
                            string p = o.Replace("}\",", "},");

                            List<clsEachTempNotyVia> objEachTempDetViaList = new List<clsEachTempNotyVia>();
                            objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia>>(p);

                            string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                            string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                            string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                            if (VIAWHT.Contains("D"))
                            {
                                objEntityTempDeatils.IsDashBoard = 1;
                            }
                            if (VIAWHT.Contains("E"))
                            {
                                objEntityTempDeatils.IsEmail = 1;
                            }

                            //for template notify Duration
                            string jsonDataNotyDur = strNotifyDur;
                            string q = jsonDataNotyDur.Replace("\"{", "\\{");
                            string r = q.Replace("\\n", "\r\n");
                            string s = r.Replace("\\", "");
                            string t = s.Replace("}\"]", "}]");
                            string u = t.Replace("}\",", "},");

                            List<clsEachTempNotyDur> objEachTempDetDurList = new List<clsEachTempNotyDur>();
                            objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur>>(u);

                            string DURROWID = objEachTempDetDurList[intCount].ROWID;
                            string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                            string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                            objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);

                            string jsonData = strEachTempString[intCount + 1];
                            string V = jsonData.Replace("\"{", "\\{");
                            string W = V.Replace("\\n", "\r\n");
                            string X = W.Replace("\\", "");
                            string Y = X.Replace("}\"]", "}]");
                            string Z = Y.Replace("}\",", "},");

                            List<InsuranceTemplateAlert> objEntityTempAlertList = new List<InsuranceTemplateAlert>();


                            List<clsEachTempDeatail> objEachTempDetList = new List<clsEachTempDeatail>();
                            objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail>>(Z);



                            if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                            {
                                int AddingCount = 0;
                                for (int count = 0; count < objEachTempDetList.Count; count++)
                                {
                                    string ROWID = objEachTempDetList[count].ROWID;

                                    string VALUE = objEachTempDetList[count].DDLVALUE;
                                    string DDLMODE = objEachTempDetList[count].DDLMODE;
                                    string DTLID = objEachTempDetList[count].DTLID;
                                    if (VALUE != "0")
                                    {
                                        InsuranceTemplateAlert objEntityTemplateAlert = new InsuranceTemplateAlert();
                                        if (DDLMODE == "ddlDivision_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 0;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "ddlDesignation_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 1;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "ddlEmployee_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 2;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "txtGenMail_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 3;
                                            objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                                        }

                                        if (DTLID != "0")
                                        {
                                            objEntityTemplateAlert.TemplateAlertId = Convert.ToInt32(DTLID);
                                            objBusinessInsurance.UpdateTemplateAlert(objEntityTempDeatils, objEntityTemplateAlert);
                                        }
                                        else
                                        {
                                            AddingCount++;
                                            objEntityTempAlertList.Add(objEntityTemplateAlert);
                                        }
                                    }

                                }
                                if (objEntityTempDeatils.TempDetailId != 0)
                                {
                                    if (AddingCount != 0)
                                    {
                                        objBusinessInsurance.AddTemplateAlert(objEntityInsurance, objEntityTempDeatils, objEntityTempAlertList);
                                    }
                                }
                            }

                            if (objEntityTempDeatils.TempDetailId != 0)
                            {
                                objBusinessInsurance.UpdateTemplateDetail(objEntityTempDeatils);
                            }
                            else
                            {
                                objBusinessInsurance.AddTemplateDetail(objEntityInsurance, objEntityTempDeatils, objEntityTempAlertList);
                            }
                        }

                        string strTotalDelete = hiddenDeleteSliceData.Value;
                        string[] strEachTempDelete = new string[TempCount];
                        strEachTempDelete = strTotalDelete.Split('!');
                        for (int intDCount = 1; intDCount <= TempCount; intDCount++)
                        {
                            if (strEachTempDelete[intDCount] != null && strEachTempDelete[intDCount] != "" && strEachTempDelete[intDCount] != "null")
                            {
                                string strDeletedAlert = strEachTempDelete[intDCount];
                                string jsonDataDeleted = strDeletedAlert;
                                string d1 = jsonDataDeleted.Replace("\"{", "\\{");
                                string d2 = d1.Replace("\\n", "\r\n");
                                string d3 = d2.Replace("\\", "");
                                string d4 = d3.Replace("}\"]", "}]");
                                string d5 = d4.Replace("}\",", "},");
                                List<InsuranceTemplateAlert> objEntityTempAlertDeleteList = new List<InsuranceTemplateAlert>();


                                List<clsEachAlertDel> objAlertDelList = new List<clsEachAlertDel>();
                                objAlertDelList = JsonConvert.DeserializeObject<List<clsEachAlertDel>>(d5);
                                for (int delcount = 0; delcount < objAlertDelList.Count; delcount++)
                                {
                                    string ROWID = objAlertDelList[delcount].ROWID;
                                    string AlertVALUE = objAlertDelList[delcount].DTLID;

                                    InsuranceTemplateAlert objEntityTempAlertDelete = new InsuranceTemplateAlert();
                                    objEntityTempAlertDelete.TemplateAlertId = Convert.ToInt32(AlertVALUE);
                                    objEntityTempAlertDeleteList.Add(objEntityTempAlertDelete);
                                }

                                objBusinessInsurance.DeleteTemplateAlert(objEntityTempAlertDeleteList);
                            }
                        }
                    }
                    //REDIRECT TO UPDATE VIEW
                    List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                    objEntityCommon.RedirectUrl = "gen_Insurance_Master.aspx";
                    clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "InsUpd";
                    objEntityQueryString.QueryStringValue = "Cnfrm";
                    objEntityQueryString.Encrypt = 0;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "ViewId";
                    objEntityQueryString.QueryStringValue = strId;
                    objEntityQueryString.Encrypt = 1;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);

                    Response.Redirect(strRedirectUrl);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "StatusCheck", "StatusCheck();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Duplication", "Duplication();", true);
            }
        }
    }

    protected void btnrenew_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        string strRandomMixedId = "";
        if (Request.QueryString["ViewId"] != null || Request.QueryString["Renew"] != null)
        {
            if (Request.QueryString["ViewId"] != null)
            {
                strRandomMixedId = Request.QueryString["ViewId"].ToString();
            }

            if (Request.QueryString["Renew"] != null)
            {
                strRandomMixedId = Request.QueryString["Renew"].ToString();
            }

            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityInsurance.InsuranceId = Convert.ToInt32(strId);

            objEntityInsurance.RefNumber = HiddenFieldRefNumber2.Value;
            objEntityInsurance.InsuranceNo = txtInsuranceno.Text.Trim();

            if (HiddenFieldAmount.Value.Trim() != "")
            {
                objEntityInsurance.Amount = Convert.ToDecimal(HiddenFieldAmount.Value);
            }
            objEntityInsurance.ProjectId = Convert.ToInt32(ddlProjects.SelectedItem.Value);
            if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
            {
                objEntityInsurance.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            }

            if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
            {
                objEntityInsurance.InsuranceProvider = Convert.ToInt32(ddlInsurncPrvdr.SelectedItem.Value);
            }
            if (radioOpen.Checked == true)
            {
                objEntityInsurance.InsuranceTyp = 101;
                objEntityInsurance.ExpireDate = DateTime.MinValue;
            }
            else if (radioLimited.Checked == true)
            {
                objEntityInsurance.InsuranceTyp = 102;
                objEntityInsurance.NoOfDays = Convert.ToInt32(HiddenTextValidty.Value);
                objEntityInsurance.ExpireDate = objCommon.textToDateTime(txtPrjctClsngDate.Text.Trim());
            }
            objEntityInsurance.OpenDate = objCommon.textToDateTime(txtOpngDate.Text.Trim());

            if (cbxDontNotify.Checked == true)
            {
                objEntityInsurance.DontNotify = 1;
            }
            else
            {
                objEntityInsurance.DontNotify = 0;
            }

            objEntityInsurance.NotTempId = Convert.ToInt32(ddlTemplate.SelectedItem.Value);
            objEntityInsurance.Description = txtDescrptn.Text.Trim();

            if (cbxExistingEmployee.Checked == true)
            {
                if (ddlExistingEmp.SelectedItem.Value != "--SELECT EMPLOYEE--")
                {
                    objEntityInsurance.EmployeName = ddlExistingEmp.SelectedItem.Text;
                    objEntityInsurance.ContactPersnUsrId = Convert.ToInt32(ddlExistingEmp.SelectedItem.Value);
                }
            }
            else
            {
                objEntityInsurance.EmployeName = txtEmpName.Text.Trim();
            }
            objEntityInsurance.Email = txtCntctMail.Text.Trim();
            objEntityInsurance.D_Date = System.DateTime.Now;

            string strGurntNo = "";
            strGurntNo = objBusinessInsurance.CheckDupInsrncNo(objEntityInsurance);

            if (strGurntNo == "" || strGurntNo == "0")
            {

                DataTable GuarantStatus = objBusinessInsurance.ReadInsuranceStatus(objEntityInsurance);
                string strchckStatus = "";
                if (GuarantStatus.Rows.Count > 0)
                {
                    strchckStatus = GuarantStatus.Rows[0]["INSURANCE_STATUS"].ToString();
                }
                if (strchckStatus != "1")
                {
                    if (strchckStatus != "4")
                    {
                        if (strchckStatus == "2")
                        {
                            objBusinessInsurance.RenewInsurance(objEntityInsurance);
                        }

                        objBusinessInsurance.UpdateInsurance(objEntityInsurance);

                        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_ATTACHMNT);
                        objEntityCommon.CorporateID = objEntityInsurance.CorpOffice_Id;

                        List<clsEntityLayerInsuranceAttachments> objEntityLayerGuarenteeAtchmntDtlList = new List<clsEntityLayerInsuranceAttachments>();

                        int intSlNumbr = 0;
                        if (hiddenAttchmntSlNumber.Value != "")
                        {
                            intSlNumbr = Convert.ToInt32(hiddenAttchmntSlNumber.Value);
                            intSlNumbr++;
                        }

                        if (HiddenField2_FileUploadLnk.Value != "" && HiddenField2_FileUploadLnk.Value != null && HiddenField2_FileUploadLnk.Value != "[]")
                        {
                            string jsonDataDltAttch = HiddenField2_FileUploadLnk.Value;
                            string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                            string strAtt2 = strAtt1.Replace("\\", "");
                            string strAtt3 = strAtt2.Replace("}\"]", "}]");
                            string strAtt4 = strAtt3.Replace("}\",", "},");

                            List<clsBannerDataADDAttchmnt> objBannerDataDltAttList = new List<clsBannerDataADDAttchmnt>();
                            objBannerDataDltAttList = JsonConvert.DeserializeObject<List<clsBannerDataADDAttchmnt>>(strAtt4);

                            foreach (clsBannerDataADDAttchmnt objClsBannrAddAttData in objBannerDataDltAttList)
                            {
                                if (objClsBannrAddAttData.EVTACTION == "INS")
                                {
                                    string strfilepath = Convert.ToString(objClsBannrAddAttData.ROWID);

                                    HttpPostedFile PostedFile = Request.Files["file" + strfilepath];
                                    if (PostedFile.ContentLength > 0)
                                    {
                                        clsEntityLayerInsuranceAttachments objEntityLayerGuarnteeAtchmntDtl = new clsEntityLayerInsuranceAttachments();
                                        string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                        objEntityLayerGuarnteeAtchmntDtl.ActualFileName = strFileName;

                                        string strFileExt;
                                        strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                                        int intAppModSection = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_ATTACHMNT);
                                        int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                                        objEntityLayerGuarnteeAtchmntDtl.AttchmntSlNumber = intSlNumbr;
                                        string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + "_" + intSlNumbr + "." + strFileExt;
                                        objEntityLayerGuarnteeAtchmntDtl.FileName = strImageName;

                                        objEntityLayerGuarnteeAtchmntDtl.CaptionName = Request.Form["textbx" + strfilepath];

                                        objEntityLayerGuarnteeAtchmntDtl.InsuranceId = Convert.ToInt32(HiddenBankGuarenteeId.Value);

                                        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                                        PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityLayerGuarnteeAtchmntDtl.FileName);

                                        objEntityLayerGuarenteeAtchmntDtlList.Add(objEntityLayerGuarnteeAtchmntDtl);
                                        intSlNumbr++;
                                    }


                                }
                            }
                        }

                        List<clsEntityLayerInsuranceAttachments> objEntityLayerInsuranceAtchmntDtlListDelete = new List<clsEntityLayerInsuranceAttachments>();

                        if (hiddenFileCanclDtlId.Value != "" && hiddenFileCanclDtlId.Value != null)
                        {
                            string jsonDataDltAttch = hiddenFileCanclDtlId.Value;
                            string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                            string strAtt2 = strAtt1.Replace("\\", "");
                            string strAtt3 = strAtt2.Replace("}\"]", "}]");
                            string strAtt4 = strAtt3.Replace("}\",", "},");

                            List<clsPictureDataDELETEAttchmnt> objPictureDataDltAttList = new List<clsPictureDataDELETEAttchmnt>();
                            objPictureDataDltAttList = JsonConvert.DeserializeObject<List<clsPictureDataDELETEAttchmnt>>(strAtt4);

                            foreach (clsPictureDataDELETEAttchmnt objClsPictureDltAttData in objPictureDataDltAttList)
                            {
                                clsEntityLayerInsuranceAttachments objEntityLayerInsuranceAtchmntDtl = new clsEntityLayerInsuranceAttachments();

                                objEntityLayerInsuranceAtchmntDtl.PictureId = Convert.ToInt32(objClsPictureDltAttData.DTLID);
                                objEntityLayerInsuranceAtchmntDtl.FileName = Convert.ToString(objClsPictureDltAttData.FILENAME);
                                objEntityLayerInsuranceAtchmntDtlListDelete.Add(objEntityLayerInsuranceAtchmntDtl);
                            }
                        }

                        if (objEntityLayerGuarenteeAtchmntDtlList.Count > 0)
                        {
                            objBusinessInsurance.Add_Pictures(objEntityInsurance, objEntityLayerGuarenteeAtchmntDtlList);
                        }

                        if (objEntityLayerInsuranceAtchmntDtlListDelete.Count > 0)
                        {
                            objBusinessInsurance.Delete_Pictures(objEntityInsurance, objEntityLayerInsuranceAtchmntDtlListDelete);

                            foreach (clsEntityLayerInsuranceAttachments objEntityLayerIInsuranceAtchmntDtl in objEntityLayerInsuranceAtchmntDtlListDelete)
                            {
                                string strImgPath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                                string imageLocation = strImgPath + objEntityLayerIInsuranceAtchmntDtl.FileName;
                                if (File.Exists(MapPath(imageLocation)))
                                {
                                    File.Delete(MapPath(imageLocation));
                                }
                            }
                        }


                        objBusinessInsurance.MailStatusChangeBack(objEntityInsurance);

                        //REDIRECT TO UPDATE VIEW 
                        List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                        objEntityCommon.RedirectUrl = "gen_Insurance_Master.aspx";
                        clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                        objEntityQueryString.QueryString = "InsUpd";
                        objEntityQueryString.QueryStringValue = "Renewd";
                        objEntityQueryString.Encrypt = 0;
                        objEntityQueryStringList.Add(objEntityQueryString);
                        objEntityQueryString = new clsEntityQueryString();
                        objEntityQueryString.QueryString = "ViewId";
                        objEntityQueryString.QueryStringValue = strId;
                        objEntityQueryString.Encrypt = 1;
                        objEntityQueryStringList.Add(objEntityQueryString);
                        string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);
                        Response.Redirect(strRedirectUrl);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "StsChkClsRenew", "StsChkClsRenew();", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "StsChkReopnRenew", "StsChkReopnRenew();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Duplication", "Duplication();", true);
            }
        }
    }

    protected void imgbtnReOpen_Click(object sender, ImageClickEventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        string strRandomMixedId = "";
        if (Request.QueryString["Id"] != null || Request.QueryString["ViewId"] != null || Request.QueryString["Renew"] != null)
        {
            if (Request.QueryString["Id"] != null)
            {
                strRandomMixedId = Request.QueryString["Id"].ToString();
            }
            if (Request.QueryString["ViewId"] != null)
            {
                strRandomMixedId = Request.QueryString["ViewId"].ToString();
            }

            if (Request.QueryString["Renew"] != null)
            {
                strRandomMixedId = Request.QueryString["Renew"].ToString();
            }

            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityInsurance.InsuranceId = Convert.ToInt32(strId);

            DataTable GuarantStatus = objBusinessInsurance.ReadInsuranceStatus(objEntityInsurance);
            string strchckStatus = "";
            if (GuarantStatus.Rows.Count > 0)
            {
                strchckStatus = GuarantStatus.Rows[0]["INSURANCE_STATUS"].ToString();
            }
            if (strchckStatus == "2")
            {
                objEntityInsurance.StatusIdCheck = 1;
            }
            else if (strchckStatus == "4")
            {
                objEntityInsurance.StatusIdCheck = 3;
            }
            if (strchckStatus != "4")
            {
                if (strchckStatus != "1")
                {
                    objBusinessInsurance.ReOpenInsurance(objEntityInsurance);
                    objBusinessInsurance.MailStatusChangeBack(objEntityInsurance);


                    //REDIRECT TO UPDATE VIEW 
                    List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                    objEntityCommon.RedirectUrl = "gen_Insurance_Master.aspx";
                    clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "InsUpd";
                    objEntityQueryString.QueryStringValue = "ReOpen";
                    objEntityQueryString.Encrypt = 0;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "Id";
                    objEntityQueryString.QueryStringValue = strId;
                    objEntityQueryString.Encrypt = 1;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);
                    Response.Redirect(strRedirectUrl);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "StatusCheckReopn", "StatusCheckReopn();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "StatusCheckClsReopn", "StatusCheckClsReopn();", true);
            }
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["default"] != null)
        {
            if (Request.QueryString["default"] == "3months")
            {
                Response.Redirect("gen_Insurance_Master_List.aspx?default=3months");
            }
            else if (Request.QueryString["default"] == "expired")
            {
                Response.Redirect("gen_Insurance_Master_List.aspx?default=expired");
            }
            else
            {
                Response.Redirect("gen_Insurance_Master_List.aspx");
            }
        }
        else
        {
            Response.Redirect("gen_Insurance_Master_List.aspx");
        }
    }
}