using BL_Compzit;
using BL_Compzit.BusinessLayer_AWMS;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
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

public partial class AWMS_AWMS_Master_gen_Traffic_Violation_gen_Traffic_Violation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlVehicleNumber.Attributes.Add("onkeypress", "return DisableEnter(event)");
            ddlSettledBy.Attributes.Add("onkeypress", "return DisableEnter(event)");
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableConfirm = 0, intEnableReOpen = 0;
            hiddenRoleConfirm.Value = "0";
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();

            hiddenCurrentDate.Value = strCurrentDate;

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            hiddenUserId.Value = Convert.ToString(intUserId);

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Traffic_Violation);
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
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleConfirm.Value = intEnableConfirm.ToString();

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);


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
                    btnUpdate.Visible = true;
                    btnUpdateClose.Visible = true;

                }
                else
                {

                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;

                }
                if (intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnConfirm.Visible = true;

                }
                else
                {

                    btnConfirm.Visible = false;


                }

                if (intEnableReOpen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnReOpen.Visible = true;

                    //txtRecptNo.Enabled = false;
                    //ddlSettledBy.Enabled = false;
                    //lblReceiptAmount.Enabled = false;

                }
                else
                {

                  
                   
                }

                //Loading Terms in dropdown
                VehicleNumberLoad();
                EmployeeLoad();

                //Creating objects for business layer
                clsBusinessLayerTrafficViolation objBusinessTrafficViolation = new clsBusinessLayerTrafficViolation();
                clsEntityLayerTrafficViolation objEntityTrafficViolation = new clsEntityLayerTrafficViolation();
                int intCorpId = 0;
                int intOrgId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityTrafficViolation.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityTrafficViolation.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                    hiddenOrganisationId.Value = Session["ORGID"].ToString();

                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }



                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                             clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                                      
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {

                    hiddenFloatingValueMoney.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                    hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                }
                clsEntityCommon objEntityCommon = new clsEntityCommon();
                        // cliebt side number format
                        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                        DataTable dtCurrencyDetail = new DataTable();
                        dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
                        if (dtCurrencyDetail.Rows.Count > 0)
                        {
                            hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                           
                        }


                //when editing 
                if (Request.QueryString["Id"] != null)
                {
                    txtRecptNo.Enabled = false;
                    ddlSettledBy.Enabled = false;
                    lblReceiptAmount.Enabled = false;
                    btnClear.Visible = false;
                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    int intTVioltnId = Convert.ToInt32(strId);
                    EditView(intTVioltnId, 1);
                    hiddenVioltnId.Value = strId;
                    lblEntry.Text = "Edit Traffic Violation";
                    if (Request.QueryString["InsUpd"] != null)
                    {
                        string strInsUpd = Request.QueryString["InsUpd"].ToString();


                        if (strInsUpd == "NotCnfrm")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "FailureConfirmation", "FailureConfirmation();", true);
                        }



                        else if (strInsUpd == "NotReOpen")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "FailureReOpen", "FailureReOpen();", true);
                        }
                    }  
                }
                //when  viewing
                else if (Request.QueryString["ViewId"] != null)
                {
                    btnClear.Visible = false;
                    btnReOpen.Visible = false;
                    ddlVehicleNumber.Enabled = false;
                    txtRecptNo.Enabled = false;
                    ddlSettledBy.Enabled = false;
                    lblReceiptAmount.Enabled = false;
                    string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    int intTVioltnId = Convert.ToInt32(strId);
                    EditView(intTVioltnId, 2);

                    lblEntry.Text = "View Traffic Violation";  
                }
                else
                {
                    lblEntry.Text = "Add Traffic Violation";

                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                    btnConfirm.Visible = false;
                    btnReOpen.Visible = false;
                    txtRecptNo.Enabled = false;
                    ddlSettledBy.Enabled =false;
                    lblReceiptAmount.Enabled = false;

                    //EVM-0027

                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.TRAFIC_VIOLATION);
                    objEntityCommon.CorporateID = intCorpId;
                    objEntityCommon.Organisation_Id = intOrgId;
                    string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                    //string year = DateTime.Today.Year.ToString();

                    lblRefNumber.Text = "REF/" + strNextId;
                    //END

                }
              

                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    if (strInsUpd == "Save")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessSave", "SuccessSave();", true);
                    }
                    else if (strInsUpd == "Upd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                    }
                    else if (strInsUpd == "Cnfrm")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                    }
                    else if (strInsUpd == "NotCnfrm")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "FailureConfirmation", "FailureConfirmation();", true);
                    }

                    else if (strInsUpd == "ReOpen")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
                    }

                    else if (strInsUpd == "NotReOpen")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "FailureReOpen", "FailureReOpen();", true);
                    }
                    else if (strInsUpd == "CnfrmPnd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ConfirmPnd", "ConfirmPnd();", true);
                    }
                }

            }
            else
            {
                btnSave.Visible = false;
                btnSaveClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnReOpen.Visible = false;
                btnConfirm.Visible = false;
                // btnClose.Visible = false;
                btnClear.Visible = false;

            }

           
        }
    }
    //This is the method for binding manufacturer terms to dropdown list.
    public void VehicleNumberLoad()
    {
        ddlVehicleNumber.Items.Clear();
        clsBusinessLayerTrafficViolation objBusinessLayerTrafficVltn = new clsBusinessLayerTrafficViolation();
        clsEntityLayerTrafficViolation objEntityLayerTrafficVltn = new clsEntityLayerTrafficViolation();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerTrafficVltn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityLayerTrafficVltn.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityLayerTrafficVltn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityLayerTrafficVltn.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
        DataTable dtVehicleDetails = new DataTable();
        dtVehicleDetails = objBusinessLayerTrafficVltn.ReadVehicleNumber(objEntityLayerTrafficVltn);



        ddlVehicleNumber.DataSource = dtVehicleDetails;
        ddlVehicleNumber.DataTextField = "VHCL_NUMBR";
        ddlVehicleNumber.DataValueField = "VHCL_ID";
        ddlVehicleNumber.DataBind();
        ddlVehicleNumber.Items.Insert(0, "--SELECT VEHICLE NUMBER--");
    }
    public void EmployeeLoad()
    {
        ddlSettledBy.Items.Clear();
        clsBusinessLayerTrafficViolation objBusinessLayerTrafficVltn = new clsBusinessLayerTrafficViolation();
        clsEntityLayerTrafficViolation objEntityLayerTrafficVltn = new clsEntityLayerTrafficViolation();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerTrafficVltn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityLayerTrafficVltn.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityLayerTrafficVltn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityLayerTrafficVltn.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
        DataTable dtEmpDetails = new DataTable();
        dtEmpDetails = objBusinessLayerTrafficVltn.ReadEmployee(objEntityLayerTrafficVltn);



        ddlSettledBy.DataSource = dtEmpDetails;
        ddlSettledBy.DataTextField = "USR_NAME";
        ddlSettledBy.DataValueField = "USR_ID";
        ddlSettledBy.DataBind();
        ddlSettledBy.Items.Insert(0, "--Select Employee--");
    }
    public class VhclDtls
    {
        public string strAmount = "";
        public string strEmpId = "";
        public string strEmployee = "";
       

    }
    // this web method is for fetching data based on the vehicle selected 
    [WebMethod]
    public static VhclDtls VehicleDetails(string corporateId, string organisationId, string VHCLID)
    {

        VhclDtls objVhclDtls = new VhclDtls();     // CREATE AN OBJECT.

        //Creating objects for business layer
        clsBusinessLayerTrafficViolation objBusinessLayerTrafficVltn = new clsBusinessLayerTrafficViolation();
        clsEntityLayerTrafficViolation objEntityLayerTrafficVltn = new clsEntityLayerTrafficViolation();

        if (corporateId != null && corporateId != "" && corporateId != "undefined" && organisationId != null && organisationId != "" && organisationId != "undefined" && VHCLID != null && VHCLID != "" && VHCLID != "undefined")
        {
            objEntityLayerTrafficVltn.CorpOffice_Id = Convert.ToInt32(corporateId);
            objEntityLayerTrafficVltn.Organisation_Id = Convert.ToInt32(organisationId);
            objEntityLayerTrafficVltn.VehicleId = Convert.ToInt32(VHCLID);
        }

        DataTable dtVhclDtl = new DataTable();

        dtVhclDtl = objBusinessLayerTrafficVltn.ReadVehicleDtlByID(objEntityLayerTrafficVltn);
        if (dtVhclDtl.Rows.Count > 0)
        {
            objVhclDtls.strAmount = dtVhclDtl.Rows[0]["RCPT_AMNT"].ToString();
            objVhclDtls.strEmpId = dtVhclDtl.Rows[0]["TRFCVIOLTNDTL_USRID"].ToString();
            objVhclDtls.strEmployee = dtVhclDtl.Rows[0]["USR_NAME"].ToString();
           
        }
        return objVhclDtls;
    }
    public class clsTVData
    {

        public string VLTNDATE { get; set; }
        public string EMPID { get; set; }
        public string EMPNAME { get; set; }
        public string VLTN { get; set; }
        public string VLTNAMNT { get; set; }
        public string STLD { get; set; }
        public string STLDAMNT { get; set; }
        public string STLDDATE { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
         {
            Button clickedButton = sender as Button;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayerTrafficViolation objBusinessLayerTrafficVltn = new clsBusinessLayerTrafficViolation();
            clsEntityLayerTrafficViolation objEntityLayerTrafficVltn = new clsEntityLayerTrafficViolation();

            int intUserId = 0;
            if (hiddenCorporateId.Value == "")
            {
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLayerTrafficVltn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {

                objEntityLayerTrafficVltn.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
            }
            if (hiddenOrganisationId.Value == "")
            {
                if (Session["ORGID"] != null)
                {
                    objEntityLayerTrafficVltn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                objEntityLayerTrafficVltn.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
            }
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }



            objEntityLayerTrafficVltn.VehicleId = Convert.ToInt32(ddlVehicleNumber.SelectedValue);
            //objEntityLayerTrafficVltn.TotalAmnt = Convert.ToDecimal(hiddenNetAmount.Value.Trim());
            objEntityLayerTrafficVltn.User_Id = intUserId;
            objEntityLayerTrafficVltn.D_Date = System.DateTime.Now;
            //evm-0027
            objEntityLayerTrafficVltn.RefNo = lblRefNumber.Text;
            //end
            if (hiddenNetAmount.Value != "")
            {
                objEntityLayerTrafficVltn.RecptAmnt = Convert.ToDecimal(hiddenNetAmount.Value); 
            }
            objEntityLayerTrafficVltn.ReceiptNumber = txtRecptNo.Text;
            
                if (hiddenStldUserId.Value != "--Select Employee--")
                {

                    objEntityLayerTrafficVltn.StldUser_Id = Convert.ToInt32(hiddenStldUserId.Value);
                }

                List<clsEntityLayerTrafficViolationDtl> objEntityTrficVioltnDetilsList = new List<clsEntityLayerTrafficViolationDtl>();
                string jsonData = HiddenField1.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsTVData> objTVDataList = new List<clsTVData>();
                //   UserData  data
                objTVDataList = JsonConvert.DeserializeObject<List<clsTVData>>(i);


                foreach (clsTVData objclsTVData in objTVDataList)
                {
                    clsEntityLayerTrafficViolationDtl objEntityDetails = new clsEntityLayerTrafficViolationDtl();

                    objEntityDetails.Violtndate = objCommon.textToDateTime(objclsTVData.VLTNDATE.ToString());
                    objEntityDetails.UserId = Convert.ToInt32(objclsTVData.EMPID);
                    objEntityDetails.Violation = Convert.ToInt32(objclsTVData.VLTN);
                    objEntityDetails.VioltnAmnt = Convert.ToDecimal(objclsTVData.VLTNAMNT);
                    objEntityDetails.StldStatusId = Convert.ToInt32(objclsTVData.STLD);
                    objEntityDetails.SettledAmnt = Convert.ToDecimal(objclsTVData.STLDAMNT);
                    if ((objclsTVData.STLDDATE.ToString()) != "")
                    {
                        objEntityDetails.Settleddate = objCommon.textToDateTime(objclsTVData.STLDDATE.ToString());
                    }

                    objEntityTrficVioltnDetilsList.Add(objEntityDetails);

                }

                int intTrficVioltnId = objBusinessLayerTrafficVltn.Insert_TrafficVioltn(objEntityLayerTrafficVltn, objEntityTrficVioltnDetilsList);

                if (hiddenRoleConfirm.Value != "0")
                {
                    string strRandom = objCommon.Random_Number();

                    string strId = intTrficVioltnId.ToString();
                    int intIdLength = strId.Length;
                    string stridLength = intIdLength.ToString("00");
                    string strMixedTVId = stridLength + strId + strRandom;

                    if (clickedButton.ID == "btnSave")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "RedirectConFirm", "RedirectConFirm('" + strMixedTVId + "');", true);
                    }
                    else if (clickedButton.ID == "btnSaveClose")
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "RedirectConFirmAdCls", "RedirectConFirmAdCls('" + strMixedTVId + "');", true);
                    }
                }
                else
                {
                    if (clickedButton.ID == "btnSave")
                    {
                        Response.Redirect("gen_Traffic_Violation.aspx?InsUpd=Save");
                    }
                    else if (clickedButton.ID == "btnSaveClose")
                    {
                        Response.Redirect("gen_Traffic_Violation_List.aspx?InsUpd=Save");
                    }


                }
            
              

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "ErrorMsg();", true);
        }
    }
    private void EditView(int intTVltnId, int intEditOrView)
    {//when Editing or viewing
        //intEditOrView if 1-Edit,2-View
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerTrafficViolation objBusinessLayerTrafficVltn = new clsBusinessLayerTrafficViolation();
        clsEntityLayerTrafficViolation objEntityLayerTrafficVltn = new clsEntityLayerTrafficViolation();
        objEntityLayerTrafficVltn.TrafficVltnId = intTVltnId;
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerTrafficVltn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityLayerTrafficVltn.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }

        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityLayerTrafficVltn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityLayerTrafficVltn.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
        DataTable dtTVltnDtl = new DataTable();
        //   DataTable dtWBill = new DataTable();


        dtTVltnDtl = objBusinessLayerTrafficVltn.ReadTrafficVioltnDetail(objEntityLayerTrafficVltn);

      

        if (dtTVltnDtl.Rows.Count > 0)
        {


            //ie IF  VEHICLE IS ACTIVE
            if (dtTVltnDtl.Rows[0]["VHCL_STATUS"].ToString() == "1" && dtTVltnDtl.Rows[0]["VHCL_CNCL_USR_ID"].ToString() == "")
            {
                ddlVehicleNumber.ClearSelection();
                ddlVehicleNumber.Items.FindByValue(dtTVltnDtl.Rows[0]["VHCL_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lst = new ListItem(dtTVltnDtl.Rows[0]["VHCL_NUMBR"].ToString(), dtTVltnDtl.Rows[0]["VHCL_ID"].ToString());
                ddlVehicleNumber.Items.Insert(1, lst);

                SortDDL(ref this.ddlVehicleNumber);
                ddlVehicleNumber.ClearSelection();
                ddlVehicleNumber.Items.FindByValue(dtTVltnDtl.Rows[0]["VHCL_ID"].ToString()).Selected = true;
            }
            txtRecptNo.Text = dtTVltnDtl.Rows[0]["RCPT_NUMBER"].ToString();
            lblRefNumber.Text = dtTVltnDtl.Rows[0]["TRFCVIOLTN_REFNO"].ToString();
            if (dtTVltnDtl.Rows[0]["SETTLD_USRID"].ToString() != "")
            {
                ddlSettledBy.Items.FindByValue(dtTVltnDtl.Rows[0]["SETTLD_USRID"].ToString()).Selected = true;
            }
            if (dtTVltnDtl.Rows[0]["TRFCVIOLTN_CNFRM_STS"].ToString() == "1")
            {
                intEditOrView = 2;

            }




            //   hiddenActiveUser.Value = dtQtn.Rows[0]["LDQUOT_ACTIVE_USR_ID"].ToString();



            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("TransId", typeof(int));
            dtDetail.Columns.Add("TransDtlId", typeof(int));
            dtDetail.Columns.Add("VioltnDate", typeof(string));
            dtDetail.Columns.Add("EmpId", typeof(int));
            dtDetail.Columns.Add("EmpName", typeof(string));
            dtDetail.Columns.Add("VioltnId", typeof(int));
            dtDetail.Columns.Add("Violtn", typeof(string));
            dtDetail.Columns.Add("VioltnAmnt", typeof(decimal));
            dtDetail.Columns.Add("StldSts", typeof(int));
            dtDetail.Columns.Add("StldAmnt", typeof(decimal));
            dtDetail.Columns.Add("StldDate", typeof(string));
            dtDetail.Columns.Add("RcptNumbr", typeof(string));
           // dtDetail.Columns.Add("StldUsrID", typeof(int));
            dtDetail.Columns.Add("RcptAmnt", typeof(decimal));


            for (int intcnt = 0; intcnt < dtTVltnDtl.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["TransId"] = Convert.ToInt32(dtTVltnDtl.Rows[intcnt]["TRFCVIOLTN_ID"].ToString());
                drDtl["TransDtlId"] = Convert.ToInt32(dtTVltnDtl.Rows[intcnt]["TRFCVIOLTNDTL_ID"].ToString());
                drDtl["VioltnDate"] = dtTVltnDtl.Rows[intcnt]["VIOLTN_DATE"].ToString();
                drDtl["EmpId"] = Convert.ToInt32(dtTVltnDtl.Rows[intcnt]["TRFCVIOLTNDTL_USRID"].ToString());
                drDtl["EmpName"] = dtTVltnDtl.Rows[intcnt]["USR_NAME"].ToString();
                drDtl["VioltnId"] = Convert.ToInt32(dtTVltnDtl.Rows[intcnt]["CMPLNTMSTR_ID"].ToString());
                drDtl["Violtn"] = dtTVltnDtl.Rows[intcnt]["CMPLNTMSTR_DSCPTN"].ToString();
                drDtl["VioltnAmnt"] = Convert.ToDecimal(dtTVltnDtl.Rows[intcnt]["VIOLTN_AMNT"].ToString());
                drDtl["StldSts"] = Convert.ToInt32(dtTVltnDtl.Rows[intcnt]["TRFCVIOLTNDTL_STLD_STS"].ToString());           
                drDtl["StldAmnt"] = Convert.ToDecimal(dtTVltnDtl.Rows[intcnt]["STLD_AMNT"].ToString());
                drDtl["StldDate"] = dtTVltnDtl.Rows[intcnt]["STLD_DATE"].ToString();
                drDtl["RcptNumbr"] = dtTVltnDtl.Rows[intcnt]["RCPT_NUMBER"].ToString();
              //  drDtl["StldUsrID"] = Convert.ToInt32(dtTVltnDtl.Rows[intcnt]["SETTLD_USRID"].ToString());
                drDtl["RcptAmnt"] = Convert.ToDecimal(dtTVltnDtl.Rows[intcnt]["RCPT_AMNT"].ToString());

                dtDetail.Rows.Add(drDtl);

            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            if (intEditOrView == 1)
            {
               
                btnSave.Visible = false;
                btnSaveClose.Visible = false;
                btnReOpen.Visible = false;
                hiddenEdit.Value = strJson;
            }
            else if (intEditOrView == 2)
            {

                btnSave.Visible = false;
                btnSaveClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnConfirm.Visible = false;
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            if (Request.QueryString["Id"] != null)
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();

                clsBusinessLayerTrafficViolation objBusinessLayerTrafficVltn = new clsBusinessLayerTrafficViolation();
                clsEntityLayerTrafficViolation objEntityLayerTrafficVltn = new clsEntityLayerTrafficViolation();
                int intUserId = 0;
                if (hiddenCorporateId.Value == "")
                {
                    if (Session["CORPOFFICEID"] != null)
                    {
                        objEntityLayerTrafficVltn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {

                    objEntityLayerTrafficVltn.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
                }
                if (hiddenOrganisationId.Value == "")
                {
                    if (Session["ORGID"] != null)
                    {
                        objEntityLayerTrafficVltn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    objEntityLayerTrafficVltn.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
                }
                if (Session["USERID"] != null)
                {
                    intUserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityLayerTrafficVltn.TrafficVltnId = Convert.ToInt32(strId);


                objEntityLayerTrafficVltn.VehicleId = Convert.ToInt32(ddlVehicleNumber.SelectedValue);          
                if (hiddenNetAmount.Value != "")
                {
                    objEntityLayerTrafficVltn.RecptAmnt = Convert.ToDecimal(hiddenNetAmount.Value);
                }
                //evm-0027
                objEntityLayerTrafficVltn.RefNo = lblRefNumber.Text;
                //end
                objEntityLayerTrafficVltn.ReceiptNumber = txtRecptNo.Text;
                if (hiddenStldUserId.Value != "--Select Employee--")
                {

                    objEntityLayerTrafficVltn.StldUser_Id = Convert.ToInt32(hiddenStldUserId.Value);
                }
                objEntityLayerTrafficVltn.User_Id = intUserId;
                objEntityLayerTrafficVltn.D_Date = System.DateTime.Now;




                List<clsEntityLayerTrafficViolationDtl> objEntityTVDeatilsINSERTList = new List<clsEntityLayerTrafficViolationDtl>();
                List<clsEntityLayerTrafficViolationDtl> objEntityTVDeatilsUPDATEList = new List<clsEntityLayerTrafficViolationDtl>();
                string jsonData = HiddenField1.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsTVData> objTVDataList = new List<clsTVData>();
                //   UserData  data
                objTVDataList = JsonConvert.DeserializeObject<List<clsTVData>>(i);


                foreach (clsTVData objclsTVData in objTVDataList)
                {
                    if (objclsTVData.EVTACTION == "INS")
                    {
                        clsEntityLayerTrafficViolationDtl objEntityDetails = new clsEntityLayerTrafficViolationDtl();

                        objEntityDetails.Violtndate = objCommon.textToDateTime(objclsTVData.VLTNDATE.ToString());
                        objEntityDetails.UserId = Convert.ToInt32(objclsTVData.EMPID);
                        objEntityDetails.Violation = Convert.ToInt32(objclsTVData.VLTN);
                        objEntityDetails.VioltnAmnt = Convert.ToDecimal(objclsTVData.VLTNAMNT);
                        objEntityDetails.StldStatusId = Convert.ToInt32(objclsTVData.STLD);
                        objEntityDetails.SettledAmnt = Convert.ToDecimal(objclsTVData.STLDAMNT);
                        if ((objclsTVData.STLDDATE.ToString()) != "")
                        {
                            objEntityDetails.Settleddate = objCommon.textToDateTime(objclsTVData.STLDDATE.ToString());
                        }


                        objEntityTVDeatilsINSERTList.Add(objEntityDetails);
                    }
                    else if (objclsTVData.EVTACTION == "UPD")
                    {
                        clsEntityLayerTrafficViolationDtl objEntityDetails = new clsEntityLayerTrafficViolationDtl();
                        objEntityDetails.Violtndate = objCommon.textToDateTime(objclsTVData.VLTNDATE.ToString());
                        objEntityDetails.UserId = Convert.ToInt32(objclsTVData.EMPID);
                        objEntityDetails.Violation = Convert.ToInt32(objclsTVData.VLTN);
                        objEntityDetails.VioltnAmnt = Convert.ToDecimal(objclsTVData.VLTNAMNT);
                        objEntityDetails.StldStatusId = Convert.ToInt32(objclsTVData.STLD);
                        objEntityDetails.SettledAmnt = Convert.ToDecimal(objclsTVData.STLDAMNT);
                        if ((objclsTVData.STLDDATE.ToString()) != "")
                        {
                            objEntityDetails.Settleddate = objCommon.textToDateTime(objclsTVData.STLDDATE.ToString());
                        }
                        objEntityDetails.TrficVioltn_DtlId = Convert.ToInt32(objclsTVData.DTLID);

                        objEntityTVDeatilsUPDATEList.Add(objEntityDetails);


                    }
                }



                string strCanclDtlId = "";
                string[] strarrCancldtlIds = strCanclDtlId.Split(',');
                if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
                {
                    strCanclDtlId = hiddenCanclDtlId.Value;
                    strarrCancldtlIds = strCanclDtlId.Split(',');

                }

                objBusinessLayerTrafficVltn.Update_TrafficVioltn(objEntityLayerTrafficVltn, objEntityTVDeatilsINSERTList, objEntityTVDeatilsUPDATEList, strarrCancldtlIds);


                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_Traffic_Violation.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Traffic_Violation_List.aspx?InsUpd=Upd");
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
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        try
        {
            bool blIsConfirmed = false;
            Button clickedButton = sender as Button;
            if (Request.QueryString["Id"] != null)
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();

                clsBusinessLayerTrafficViolation objBusinessLayerTrafficVltn = new clsBusinessLayerTrafficViolation();
                clsEntityLayerTrafficViolation objEntityLayerTrafficVltn = new clsEntityLayerTrafficViolation();
                int intUserId = 0;
                if (hiddenCorporateId.Value == "")
                {
                    if (Session["CORPOFFICEID"] != null)
                    {
                        objEntityLayerTrafficVltn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {

                    objEntityLayerTrafficVltn.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
                }
                if (hiddenOrganisationId.Value == "")
                {
                    if (Session["ORGID"] != null)
                    {
                        objEntityLayerTrafficVltn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    objEntityLayerTrafficVltn.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
                }
                if (Session["USERID"] != null)
                {
                    intUserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityLayerTrafficVltn.TrafficVltnId = Convert.ToInt32(strId);

                DataTable dtTVioltn = new DataTable();



                dtTVioltn = objBusinessLayerTrafficVltn.ReadTraficVioltnById(objEntityLayerTrafficVltn);
                if (dtTVioltn.Rows.Count > 0)
                {
                    if (dtTVioltn.Rows[0]["TRFCVIOLTN_CNFRM_STS"].ToString() == "1")
                    {
                        blIsConfirmed = true;

                    }
                }

                if (blIsConfirmed == false)
                {
                    objEntityLayerTrafficVltn.VehicleId = Convert.ToInt32(ddlVehicleNumber.SelectedValue);
                    
                    if (hiddenNetAmount.Value != "")
                    {
                        objEntityLayerTrafficVltn.RecptAmnt = Convert.ToDecimal(hiddenNetAmount.Value);
                    }
                    objEntityLayerTrafficVltn.ReceiptNumber = txtRecptNo.Text;
                    if (hiddenStldUserId.Value != "--Select Employee--")
                    {

                        objEntityLayerTrafficVltn.StldUser_Id = Convert.ToInt32(hiddenStldUserId.Value);
                    }
                    //evm-0027
                    objEntityLayerTrafficVltn.RefNo = lblRefNumber.Text;
                    //end
                    objEntityLayerTrafficVltn.User_Id = intUserId;
                    objEntityLayerTrafficVltn.D_Date = System.DateTime.Now;

                   // objEntityWaterBilling.CardCurrentAmnt = Convert.ToDecimal(hiddenWtrCurrentAmount.Value.Trim()) - objEntityWaterBilling.TotalAmnt;


                    List<clsEntityLayerTrafficViolationDtl> objEntityTVDeatilsINSERTList = new List<clsEntityLayerTrafficViolationDtl>();
                    List<clsEntityLayerTrafficViolationDtl> objEntityTVDeatilsUPDATEList = new List<clsEntityLayerTrafficViolationDtl>();
                    string jsonData = HiddenField1.Value;
                    string c = jsonData.Replace("\"{", "\\{");
                    string d = c.Replace("\\n", "\r\n");
                    string g = d.Replace("\\", "");
                    string h = g.Replace("}\"]", "}]");
                    string i = h.Replace("}\",", "},");
                    List<clsTVData> objTVDataList = new List<clsTVData>();
                    //   UserData  data
                    objTVDataList = JsonConvert.DeserializeObject<List<clsTVData>>(i);


                    foreach (clsTVData objclsTVData in objTVDataList)
                    {
                        if (objclsTVData.EVTACTION == "INS")
                        {
                            clsEntityLayerTrafficViolationDtl objEntityDetails = new clsEntityLayerTrafficViolationDtl();

                            objEntityDetails.Violtndate = objCommon.textToDateTime(objclsTVData.VLTNDATE.ToString());
                            objEntityDetails.UserId = Convert.ToInt32(objclsTVData.EMPID);
                            objEntityDetails.Violation = Convert.ToInt32(objclsTVData.VLTN);
                            objEntityDetails.VioltnAmnt = Convert.ToDecimal(objclsTVData.VLTNAMNT);
                            objEntityDetails.StldStatusId = Convert.ToInt32(objclsTVData.STLD);
                            objEntityDetails.SettledAmnt = Convert.ToDecimal(objclsTVData.STLDAMNT);
                            if ((objclsTVData.STLDDATE.ToString()) != "")
                            {
                                objEntityDetails.Settleddate = objCommon.textToDateTime(objclsTVData.STLDDATE.ToString());
                            }


                            objEntityTVDeatilsINSERTList.Add(objEntityDetails);
                        }
                        else if (objclsTVData.EVTACTION == "UPD")
                        {
                            clsEntityLayerTrafficViolationDtl objEntityDetails = new clsEntityLayerTrafficViolationDtl();
                            objEntityDetails.Violtndate = objCommon.textToDateTime(objclsTVData.VLTNDATE.ToString());
                            objEntityDetails.UserId = Convert.ToInt32(objclsTVData.EMPID);
                            objEntityDetails.Violation = Convert.ToInt32(objclsTVData.VLTN);
                            objEntityDetails.VioltnAmnt = Convert.ToDecimal(objclsTVData.VLTNAMNT);
                            objEntityDetails.StldStatusId = Convert.ToInt32(objclsTVData.STLD);
                            objEntityDetails.SettledAmnt = Convert.ToDecimal(objclsTVData.STLDAMNT);
                            if ((objclsTVData.STLDDATE.ToString()) != "")
                            {
                                objEntityDetails.Settleddate = objCommon.textToDateTime(objclsTVData.STLDDATE.ToString());
                            }
                            objEntityDetails.TrficVioltn_DtlId = Convert.ToInt32(objclsTVData.DTLID);

                            objEntityTVDeatilsUPDATEList.Add(objEntityDetails);


                        }
                    }



                    string strCanclDtlId = "";
                    string[] strarrCancldtlIds = strCanclDtlId.Split(',');
                    if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
                    {
                        strCanclDtlId = hiddenCanclDtlId.Value;
                        strarrCancldtlIds = strCanclDtlId.Split(',');

                    }

                    objBusinessLayerTrafficVltn.Confirm_TraficVioltn(objEntityLayerTrafficVltn, objEntityTVDeatilsINSERTList, objEntityTVDeatilsUPDATEList, strarrCancldtlIds);

                    if (clickedButton.ID == "btnConfirm")
                    {
                        Response.Redirect("gen_Traffic_Violation_List.aspx?InsUpd=Cnfrm");
                    }
                     else if (clickedButton.ID == "btnConfirmClose")
                    {
                        Response.Redirect("gen_Traffic_Violation_List.aspx?InsUpd=Cnfrm");
                    }

                }
                else
                {

                    Response.Redirect("gen_Traffic_Violation.aspx?Id=" + strRandomMixedId + "&InsUpd=NotCnfrm");

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
    protected void btnReOpen_Click(object sender, EventArgs e)
    {
        try
        {
            bool blIsConfirmed = true;
            Button clickedButton = sender as Button;
            if (Request.QueryString["Id"] != null)
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();

                clsBusinessLayerTrafficViolation objBusinessLayerTrafficVltn = new clsBusinessLayerTrafficViolation();
                clsEntityLayerTrafficViolation objEntityLayerTrafficVltn = new clsEntityLayerTrafficViolation();
                int intUserId = 0;
                if (hiddenCorporateId.Value == "")
                {
                    if (Session["CORPOFFICEID"] != null)
                    {
                        objEntityLayerTrafficVltn.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {

                    objEntityLayerTrafficVltn.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
                }
                if (hiddenOrganisationId.Value == "")
                {
                    if (Session["ORGID"] != null)
                    {
                        objEntityLayerTrafficVltn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    objEntityLayerTrafficVltn.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
                }
                if (Session["USERID"] != null)
                {
                    intUserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityLayerTrafficVltn.TrafficVltnId = Convert.ToInt32(strId);
                

                    DataTable dtTVioltn = new DataTable();

                    dtTVioltn = objBusinessLayerTrafficVltn.ReadTraficVioltnById(objEntityLayerTrafficVltn);
                    decimal intTVRcptAmount = 0;

                    if (dtTVioltn.Rows.Count > 0)
                    {

                        intTVRcptAmount = Convert.ToDecimal(dtTVioltn.Rows[0]["RCPT_AMNT"].ToString());
                        objEntityLayerTrafficVltn.VehicleId = Convert.ToInt32(dtTVioltn.Rows[0]["VHCL_ID"].ToString());



                        if (dtTVioltn.Rows[0]["TRFCVIOLTN_CNFRM_STS"].ToString() == "0")
                        {
                            blIsConfirmed = false;

                        }


                        if (blIsConfirmed == true)
                        {
                            objEntityLayerTrafficVltn.User_Id = intUserId;
                            objEntityLayerTrafficVltn.D_Date = System.DateTime.Now;
                            objBusinessLayerTrafficVltn.Reopen_TrficVioltn(objEntityLayerTrafficVltn);



                            if (clickedButton.ID == "btnReOpen")
                            {
                                clsEntityCommon objEntityCommon = new clsEntityCommon();
                                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

                                //REDIRECT TO UPDATE VIEW
                                List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                                objEntityCommon.RedirectUrl = "gen_Traffic_Violation.aspx";
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
                               // Response.Redirect("gen_Traffic_Violation.aspx?InsUpd=ReOpen");
                            }
                            else if (clickedButton.ID == "btnReOpenClose")
                            {
                                Response.Redirect("gen_Traffic_Violation_List.aspx?InsUpd=ReOpen");
                            }

                        }
                        else
                        {

                            Response.Redirect("gen_Traffic_Violation.aspx?Id=" + strRandomMixedId + "&InsUpd=NotReOpen");

                        }
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx");
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