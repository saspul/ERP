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
public partial class AWMS_AWMS_Transaction_flt_Water_Billing_flt_Water_Billing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          

            ddlCardNumber.Attributes.Add("onkeypress", "return DisableEnter(event)");
          
            


            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableConfirm = 0,  intEnableReOpen = 0;
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Water_Billing);
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

                }
                else
                {

                    btnReOpen.Visible = false;

                }

                //Loading Terms in dropdown
                CardNumberLoad();


                //Creating objects for business layer
                clsBusinessLayerWaterBilling objBusinessLayerWaterBilling = new clsBusinessLayerWaterBilling();
                clsEntityLayerWaterBilling objEntityWaterBilling = new clsEntityLayerWaterBilling();
                int intCorpId = 0;
                int intOrgId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityWaterBilling.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityWaterBilling.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                    hiddenOrganisationId.Value = Session["ORGID"].ToString();

                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }



                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                        
                                                                      
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {

                    hiddenFloatingValueMoney.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();

                }



                //when editing 
                if (Request.QueryString["Id"] != null)
                {
                    btnClear.Visible = false;
                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    int intWBillId=Convert.ToInt32(strId);
                   EditView( intWBillId, 1);
                   lblEntry.Text = "Edit Water Billing";
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
                    string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                      int intWBillId=Convert.ToInt32(strId);
                    EditView( intWBillId, 2);

                    lblEntry.Text = "View Water Billing";
                }
                else
                {
                    lblEntry.Text = "Add Water Billing";

                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                    btnConfirm.Visible = false;
                    btnReOpen.Visible = false;
                   


              
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
    public void CardNumberLoad()
    {
        ddlCardNumber.Items.Clear();
        clsBusinessLayerWaterBilling objBusinessLayerWaterBilling = new clsBusinessLayerWaterBilling();
        clsEntityLayerWaterBilling objEntityWaterBilling = new clsEntityLayerWaterBilling();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWaterBilling.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityWaterBilling.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityWaterBilling.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityWaterBilling.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
        DataTable dtCardDetails = new DataTable();
        dtCardDetails = objBusinessLayerWaterBilling.ReadWaterCard(objEntityWaterBilling);



        ddlCardNumber.DataSource = dtCardDetails;
        ddlCardNumber.DataTextField = "WTRCRD_NUMBER";
        ddlCardNumber.DataValueField = "WTRCRD_ID";
        ddlCardNumber.DataBind();
        ddlCardNumber.Items.Insert(0, "--SELECT WATER CARD--");
    }



    private void EditView(int intWBillId, int intEditOrView)
    {//when Editing or viewing
        //intEditOrView if 1-Edit,2-View
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerWaterBilling objBusinessLayerWaterBilling = new clsBusinessLayerWaterBilling();
        clsEntityLayerWaterBilling objEntityWaterBilling = new clsEntityLayerWaterBilling();
        objEntityWaterBilling.WaterFillingId = intWBillId;
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWaterBilling.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityWaterBilling.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }

        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityWaterBilling.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityWaterBilling.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
        DataTable dtWBillDtl = new DataTable();
     //   DataTable dtWBill = new DataTable();


        dtWBillDtl = objBusinessLayerWaterBilling.ReadWaterBilingDetail(objEntityWaterBilling);



        if (dtWBillDtl.Rows.Count > 0)
        {


            //ie IF  CARD IS ACTIVE
            if (dtWBillDtl.Rows[0]["WTRCRD_STATUS"].ToString() == "1" && dtWBillDtl.Rows[0]["WTRCRD_CNCL_USR_ID"].ToString() == "")
            {
                ddlCardNumber.ClearSelection();
                ddlCardNumber.Items.FindByValue(dtWBillDtl.Rows[0]["WTRCRD_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lst = new ListItem(dtWBillDtl.Rows[0]["WTRCRD_NUMBER"].ToString(), dtWBillDtl.Rows[0]["WTRCRD_ID"].ToString());
                ddlCardNumber.Items.Insert(1, lst);

                SortDDL(ref this.ddlCardNumber);
                ddlCardNumber.ClearSelection();
                ddlCardNumber.Items.FindByValue(dtWBillDtl.Rows[0]["WTRCRD_ID"].ToString()).Selected = true;
            }


            if (dtWBillDtl.Rows[0]["WTRFILNG_CNFRM_STS"].ToString() == "1")
            {
                intEditOrView = 2;
            
            }
           
          


            //   hiddenActiveUser.Value = dtQtn.Rows[0]["LDQUOT_ACTIVE_USR_ID"].ToString();



            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("TransId", typeof(int));
            dtDetail.Columns.Add("TransDtlId", typeof(int));
            dtDetail.Columns.Add("RcptNumbr", typeof(string));
            dtDetail.Columns.Add("RcptDate", typeof(string));
            dtDetail.Columns.Add("VhclNumbr", typeof(string));
            dtDetail.Columns.Add("VhclId", typeof(int));
            dtDetail.Columns.Add("Amount", typeof(decimal));


                for (int intcnt = 0; intcnt < dtWBillDtl.Rows.Count; intcnt++)
                {
                    DataRow drDtl = dtDetail.NewRow();
                    drDtl["TransId"] = Convert.ToInt32(dtWBillDtl.Rows[intcnt]["WTRFILNG_ID"].ToString());
                    drDtl["TransDtlId"] = Convert.ToInt32(dtWBillDtl.Rows[intcnt]["WTRFILNGDTL_ID"].ToString());
                    drDtl["RcptNumbr"] = dtWBillDtl.Rows[intcnt]["RCPT_NUMBER"].ToString();
                    drDtl["RcptDate"] = dtWBillDtl.Rows[intcnt]["RCPT_DATE"].ToString();
                    drDtl["VhclNumbr"] = dtWBillDtl.Rows[intcnt]["VHCL_NUMBR"].ToString();
                    drDtl["VhclId"] = Convert.ToInt32(dtWBillDtl.Rows[intcnt]["VHCL_ID"].ToString());
                    drDtl["Amount"] = Convert.ToDecimal(dtWBillDtl.Rows[intcnt]["RCPT_AMNT"].ToString());

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

    public class clsWBData
    {
        public string RCPTNUMBR { get; set; }
        public string RCPTDATE { get; set; }
        public string VHCLID { get; set; }
        public string VHCLNUMBR { get; set; }
        public string AMOUNT { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }
       
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayerWaterBilling objBusinessLayerWaterBilling = new clsBusinessLayerWaterBilling();
            clsEntityLayerWaterBilling objEntityWaterBilling = new clsEntityLayerWaterBilling();
                int intUserId = 0;
                if (hiddenCorporateId.Value == "")
                {
                    if (Session["CORPOFFICEID"] != null)
                    {
                        objEntityWaterBilling.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {

                    objEntityWaterBilling.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
                }
                if (hiddenOrganisationId.Value == "")
                {
                    if (Session["ORGID"] != null)
                    {
                        objEntityWaterBilling.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    objEntityWaterBilling.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
                }
                if (Session["USERID"] != null)
                {
                    intUserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }


           
                objEntityWaterBilling.WaterCardId = Convert.ToInt32(ddlCardNumber.SelectedValue);
                objEntityWaterBilling.TotalAmnt = Convert.ToDecimal(hiddenNetAmount.Value.Trim());

                objEntityWaterBilling.User_Id = intUserId;
                objEntityWaterBilling.D_Date = System.DateTime.Now;

                List<clsEntityLayerWaterBillingDtl> objEntityWaterBillingDetilsList = new List<clsEntityLayerWaterBillingDtl>();
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
                    clsEntityLayerWaterBillingDtl objEntityDetails = new clsEntityLayerWaterBillingDtl();

                    objEntityDetails.RcptNumber = objclsWBData.RCPTNUMBR;
                    objEntityDetails.Rcptdate = objCommon.textToDateTime(objclsWBData.RCPTDATE.ToString());
                    objEntityDetails.VhclId = Convert.ToInt32(objclsWBData.VHCLID);
                    objEntityDetails.RcptAmnt = Convert.ToDecimal(objclsWBData.AMOUNT);
               


                    objEntityWaterBillingDetilsList.Add(objEntityDetails);

                }

             int intWtrFillngId=  objBusinessLayerWaterBilling.Insert_WaterBiling(objEntityWaterBilling, objEntityWaterBillingDetilsList);

             if (hiddenRoleConfirm.Value != "0")
             {
                 string strRandom = objCommon.Random_Number();

                 string strId = intWtrFillngId.ToString();
                 int intIdLength = strId.Length;
                 string stridLength = intIdLength.ToString("00");
                 string strMixedWtrFillngId = stridLength + strId + strRandom;

                 if (clickedButton.ID == "btnSave")
                 {
                     ScriptManager.RegisterStartupScript(this, GetType(), "RedirectConFirm", "RedirectConFirm('" + strMixedWtrFillngId + "');", true);
                 }
                 else if (clickedButton.ID == "btnSaveClose")
                 {

                     ScriptManager.RegisterStartupScript(this, GetType(), "RedirectConFirmAdCls", "RedirectConFirmAdCls('" + strMixedWtrFillngId + "');", true);
                 }
             }
             else
             {
                 if (clickedButton.ID == "btnSave")
                 {
                     Response.Redirect("flt_Water_Billing.aspx?InsUpd=Save");
                 }
                 else if (clickedButton.ID == "btnSaveClose")
                 {
                     Response.Redirect("flt_Water_Billing_List.aspx?InsUpd=Save");
                 }
             
             
             }
                 
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "ErrorMsg();", true);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            if (Request.QueryString["Id"] != null )
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();

                clsBusinessLayerWaterBilling objBusinessLayerWaterBilling = new clsBusinessLayerWaterBilling();
                clsEntityLayerWaterBilling objEntityWaterBilling = new clsEntityLayerWaterBilling();
                int intUserId = 0;
                if (hiddenCorporateId.Value == "")
                {
                    if (Session["CORPOFFICEID"] != null)
                    {
                        objEntityWaterBilling.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {

                    objEntityWaterBilling.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
                }
                if (hiddenOrganisationId.Value == "")
                {
                    if (Session["ORGID"] != null)
                    {
                        objEntityWaterBilling.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    objEntityWaterBilling.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
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
                objEntityWaterBilling.WaterFillingId = Convert.ToInt32(strId);


                objEntityWaterBilling.WaterCardId = Convert.ToInt32(ddlCardNumber.SelectedValue);
                objEntityWaterBilling.TotalAmnt = Convert.ToDecimal(hiddenNetAmount.Value.Trim());

                objEntityWaterBilling.User_Id = intUserId;
                objEntityWaterBilling.D_Date = System.DateTime.Now;




                List<clsEntityLayerWaterBillingDtl> objEntityWBDeatilsINSERTList = new List<clsEntityLayerWaterBillingDtl>();
                List<clsEntityLayerWaterBillingDtl> objEntityWBDeatilsUPDATEList = new List<clsEntityLayerWaterBillingDtl>();
                string jsonData = HiddenField1.Value;
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
                        clsEntityLayerWaterBillingDtl objEntityDetails = new clsEntityLayerWaterBillingDtl();

                        objEntityDetails.RcptNumber = objClsWBData.RCPTNUMBR;
                        objEntityDetails.Rcptdate = objCommon.textToDateTime(objClsWBData.RCPTDATE.ToString());
                        objEntityDetails.VhclId = Convert.ToInt32(objClsWBData.VHCLID);
                        objEntityDetails.RcptAmnt = Convert.ToDecimal(objClsWBData.AMOUNT);
                      

                        objEntityWBDeatilsINSERTList.Add(objEntityDetails);
                    }
                    else if (objClsWBData.EVTACTION == "UPD")
                    {
                        clsEntityLayerWaterBillingDtl objEntityDetails = new clsEntityLayerWaterBillingDtl();
                        objEntityDetails.RcptNumber = objClsWBData.RCPTNUMBR;
                        objEntityDetails.Rcptdate = objCommon.textToDateTime(objClsWBData.RCPTDATE.ToString());
                        objEntityDetails.VhclId = Convert.ToInt32(objClsWBData.VHCLID);
                        objEntityDetails.RcptAmnt = Convert.ToDecimal(objClsWBData.AMOUNT);
                        objEntityDetails.WtrFilling_DtlId = Convert.ToInt32(objClsWBData.DTLID);

                        objEntityWBDeatilsUPDATEList.Add(objEntityDetails);


                    }
                }


               
                string strCanclDtlId = "";
                string[] strarrCancldtlIds = strCanclDtlId.Split(',');
                if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
                {
                    strCanclDtlId = hiddenCanclDtlId.Value;
                    strarrCancldtlIds = strCanclDtlId.Split(',');

                }

                objBusinessLayerWaterBilling.Update_WaterBiling(objEntityWaterBilling, objEntityWBDeatilsINSERTList, objEntityWBDeatilsUPDATEList, strarrCancldtlIds);


                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("flt_Water_Billing.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("flt_Water_Billing_List.aspx?InsUpd=Upd");
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

                clsBusinessLayerWaterBilling objBusinessLayerWaterBilling = new clsBusinessLayerWaterBilling();
                clsEntityLayerWaterBilling objEntityWaterBilling = new clsEntityLayerWaterBilling();
                int intUserId = 0;
                if (hiddenCorporateId.Value == "")
                {
                    if (Session["CORPOFFICEID"] != null)
                    {
                        objEntityWaterBilling.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {

                    objEntityWaterBilling.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
                }
                if (hiddenOrganisationId.Value == "")
                {
                    if (Session["ORGID"] != null)
                    {
                        objEntityWaterBilling.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    objEntityWaterBilling.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
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
                objEntityWaterBilling.WaterFillingId = Convert.ToInt32(strId);

                DataTable dtWBill = new DataTable();
                //   DataTable dtWBill = new DataTable();


                dtWBill = objBusinessLayerWaterBilling.ReadWaterBillingById(objEntityWaterBilling);
                if (dtWBill.Rows.Count > 0)
                {
                    if (dtWBill.Rows[0]["WTRFILNG_CNFRM_STS"].ToString() == "1")
                    {
                        blIsConfirmed = true;

                    }
                }

                if (blIsConfirmed == false)
                {
                    objEntityWaterBilling.WaterCardId = Convert.ToInt32(ddlCardNumber.SelectedValue);
                    objEntityWaterBilling.TotalAmnt = Convert.ToDecimal(hiddenNetAmount.Value.Trim());

                    objEntityWaterBilling.User_Id = intUserId;
                    objEntityWaterBilling.D_Date = System.DateTime.Now;

                    objEntityWaterBilling.CardCurrentAmnt = Convert.ToDecimal(hiddenWtrCurrentAmount.Value.Trim()) - objEntityWaterBilling.TotalAmnt;


                    List<clsEntityLayerWaterBillingDtl> objEntityWBDeatilsINSERTList = new List<clsEntityLayerWaterBillingDtl>();
                    List<clsEntityLayerWaterBillingDtl> objEntityWBDeatilsUPDATEList = new List<clsEntityLayerWaterBillingDtl>();
                    string jsonData = HiddenField1.Value;
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
                            clsEntityLayerWaterBillingDtl objEntityDetails = new clsEntityLayerWaterBillingDtl();

                            objEntityDetails.RcptNumber = objClsWBData.RCPTNUMBR;
                            objEntityDetails.Rcptdate = objCommon.textToDateTime(objClsWBData.RCPTDATE.ToString());
                            objEntityDetails.VhclId = Convert.ToInt32(objClsWBData.VHCLID);
                            objEntityDetails.RcptAmnt = Convert.ToDecimal(objClsWBData.AMOUNT);


                            objEntityWBDeatilsINSERTList.Add(objEntityDetails);
                        }
                        else if (objClsWBData.EVTACTION == "UPD")
                        {
                            clsEntityLayerWaterBillingDtl objEntityDetails = new clsEntityLayerWaterBillingDtl();
                            objEntityDetails.RcptNumber = objClsWBData.RCPTNUMBR;
                            objEntityDetails.Rcptdate = objCommon.textToDateTime(objClsWBData.RCPTDATE.ToString());
                            objEntityDetails.VhclId = Convert.ToInt32(objClsWBData.VHCLID);
                            objEntityDetails.RcptAmnt = Convert.ToDecimal(objClsWBData.AMOUNT);
                            objEntityDetails.WtrFilling_DtlId = Convert.ToInt32(objClsWBData.DTLID);

                            objEntityWBDeatilsUPDATEList.Add(objEntityDetails);


                        }
                    }



                    string strCanclDtlId = "";
                    string[] strarrCancldtlIds = strCanclDtlId.Split(',');
                    if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
                    {
                        strCanclDtlId = hiddenCanclDtlId.Value;
                        strarrCancldtlIds = strCanclDtlId.Split(',');

                    }

                    objBusinessLayerWaterBilling.Confirm_WaterBiling(objEntityWaterBilling, objEntityWBDeatilsINSERTList, objEntityWBDeatilsUPDATEList, strarrCancldtlIds);


                    if (clickedButton.ID == "btnConfirm")
                    {
                        Response.Redirect("flt_Water_Billing.aspx?InsUpd=Cnfrm");
                    }
                    else if (clickedButton.ID == "btnConfirmClose")
                    {
                        Response.Redirect("flt_Water_Billing_List.aspx?InsUpd=Cnfrm");
                    }

                }
                else
                {

                    Response.Redirect("flt_Water_Billing.aspx?Id=" + strRandomMixedId + "&InsUpd=NotCnfrm");

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

                clsBusinessLayerWaterBilling objBusinessLayerWaterBilling = new clsBusinessLayerWaterBilling();
                clsEntityLayerWaterBilling objEntityWaterBilling = new clsEntityLayerWaterBilling();
                int intUserId = 0;
                if (hiddenCorporateId.Value == "")
                {
                    if (Session["CORPOFFICEID"] != null)
                    {
                        objEntityWaterBilling.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {

                    objEntityWaterBilling.CorpOffice_Id = Convert.ToInt32(hiddenCorporateId.Value);
                }
                if (hiddenOrganisationId.Value == "")
                {
                    if (Session["ORGID"] != null)
                    {
                        objEntityWaterBilling.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    objEntityWaterBilling.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
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
                objEntityWaterBilling.WaterFillingId = Convert.ToInt32(strId);

                DataTable dtWBill = new DataTable();
                //   DataTable dtWBill = new DataTable();
                dtWBill = objBusinessLayerWaterBilling.ReadWaterBillingById(objEntityWaterBilling);
                decimal intBalance = 0, intWaterFilledAmount = 0;

                if (dtWBill.Rows.Count > 0)
                {
                    intBalance = Convert.ToDecimal(dtWBill.Rows[0]["WTRCRD_CURNT_AMNT"].ToString());
                    intWaterFilledAmount = Convert.ToDecimal(dtWBill.Rows[0]["WTRFILNG_TOTAL_AMNT"].ToString());
                    objEntityWaterBilling.WaterCardId = Convert.ToInt32(dtWBill.Rows[0]["WTRCRD_ID"].ToString());

                    decimal TotalAmount = intBalance + intWaterFilledAmount;
                    objEntityWaterBilling.CardCurrentAmnt = TotalAmount;

                    if (dtWBill.Rows[0]["WTRFILNG_CNFRM_STS"].ToString() == "0")
                    {
                        blIsConfirmed = false;

                    }


                    if (blIsConfirmed == true)
                    {
                        objEntityWaterBilling.User_Id = intUserId;
                        objEntityWaterBilling.D_Date = System.DateTime.Now;
                        objBusinessLayerWaterBilling.Reopen_WaterBiling(objEntityWaterBilling);



                        if (clickedButton.ID == "btnReOpen")
                        {
                            Response.Redirect("flt_Water_Billing.aspx?InsUpd=ReOpen");
                        }
                        else if (clickedButton.ID == "btnReOpenClose")
                        {
                            Response.Redirect("flt_Water_Billing_List.aspx?InsUpd=ReOpen");
                        }

                    }
                    else
                    {

                        Response.Redirect("flt_Water_Billing.aspx?Id=" + strRandomMixedId + "&InsUpd=NotReOpen");

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
    public class CardDtls
    {
        public string strCurrentAmount = "";
        public string strVhclId ="";
        public string strVchlNumbr="";

    }
    // this web method is for fetching data based on the card selected 
    [WebMethod]
    public static CardDtls CardDetails(string corporateId, string organisationId, string CARDID)
    {

        CardDtls objCardDtls = new CardDtls();     // CREATE AN OBJECT.

        //Creating objects for business layer
        clsBusinessLayerWaterBilling objBusinessLayerWaterBilling = new clsBusinessLayerWaterBilling();
        clsEntityLayerWaterBilling objEntityWaterBilling = new clsEntityLayerWaterBilling();


        if (corporateId != null && corporateId != "" && corporateId != "undefined" && organisationId != null && organisationId != "" && organisationId != "undefined" && CARDID != null && CARDID != "" && CARDID != "undefined")
        {
            objEntityWaterBilling.CorpOffice_Id = Convert.ToInt32(corporateId);
            objEntityWaterBilling.Organisation_Id = Convert.ToInt32(organisationId);
            objEntityWaterBilling.WaterCardId = Convert.ToInt32(CARDID);
        }

        DataTable dtWtrCrdDtl = new DataTable();

        dtWtrCrdDtl = objBusinessLayerWaterBilling.ReadWaterCardDtlByID(objEntityWaterBilling);
        if (dtWtrCrdDtl.Rows.Count > 0)
        {
            objCardDtls.strCurrentAmount = dtWtrCrdDtl.Rows[0]["WTRCRD_CURNT_AMNT"].ToString();
            objCardDtls.strVhclId =dtWtrCrdDtl.Rows[0]["VHCL_ID"].ToString();
            objCardDtls.strVchlNumbr = dtWtrCrdDtl.Rows[0]["VHCL_NUMBR"].ToString();
        }
        return objCardDtls;
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