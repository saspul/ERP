using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;
// CREATED BY:EVM-0002
// CREATED DATE:03/06/2015
// REVIEWED BY:
// REVIEW DATE:


public partial class Master_gen_Corp_Ofiice_gen_Corp_OfficeAdd : System.Web.UI.Page
{
    //Creating objects for business layer.
    clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();

    protected void Page_Load(object sender, EventArgs e)
    {   
        //Assigning enter key direction on each fields
         ddlBsnsTyp.Attributes.Add("onkeypress", "return DisableEnter(event)");
         ddlBsnsTyp.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         ddlShareTyp.Attributes.Add("onkeypress", "return DisableEnter(event)");
         ddlShareTyp.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtCode.Attributes.Add("onkeypress", "return isTag(event)");
         txtCode.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtFax.Attributes.Add("onkeypress", "return isTag(event)");
         txtFax.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtEnqMail.Attributes.Add("onkeypress", "return isTag(event)");
         txtEnqMail.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtMailStrg.Attributes.Add("onkeypress", "return isTag(event)");
         txtMailStrg.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtCRN.Attributes.Add("onkeypress", "return isTag(event)");
         txtCRN.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtCRNExpDate.Attributes.Add("onkeypress", "return isTag(event)");
         txtCRNExpDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtCRNIssDate.Attributes.Add("onkeypress", "return isTag(event)");
         txtCRNIssDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtTIN.Attributes.Add("onkeypress", "return isTag(event)");
         txtTIN.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtTINExp.Attributes.Add("onkeypress", "return isTag(event)");
         txtTINExp.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtTINIss.Attributes.Add("onkeypress", "return isTag(event)");
         txtTINIss.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtCCN.Attributes.Add("onkeypress", "return isTag(event)");
         txtCCN.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtCCNExp.Attributes.Add("onkeypress", "return isTag(event)");
         txtCCNExp.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtCCNIss.Attributes.Add("onkeypress", "return isTag(event)");
         txtCCNIss.Attributes.Add("onchange", "IncrmntConfrmCounter()");
      

         ddlOfficeTyp.Attributes.Add("onkeypress", "return DisableEnter(event)");
         ddlOfficeTyp.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtCorpName.Attributes.Add("onkeypress", "return isTag(event)");
         txtCorpName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtCorpAdd1.Attributes.Add("onkeypress", "return isTag(event)");
         txtCorpAdd1.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtCorpAdd2.Attributes.Add("onkeypress", "return isTag(event)");
         txtCorpAdd2.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtCorpAdd3.Attributes.Add("onkeypress", "return isTag(event)");
         txtCorpAdd3.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         ddlCorpCountry.Attributes.Add("onkeypress", "return DisableEnter(event)");
         ddlCorpState.Attributes.Add("onkeypress", "return DisableEnter(event)");
         ddlCity.Attributes.Add("onkeypress", "return DisableEnter(event)");
         //ddlCity.Attributes.Add("onchange", " IncrmntConfrmCounter()");

         txtDate.Attributes.Add("onkeydown", "return isNumberDate(event)");
         txtDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtCustCareNumber.Attributes.Add("onkeypress", "return isTag(event)");
         txtCustCareNumber.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtShortName.Attributes.Add("onkeypress", "return isTag(event)");
         txtShortName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtShortAddress.Attributes.Add("onkeypress", "return isTag(event)");
         txtShortAddress.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtCorpZip.Attributes.Add("onkeypress", "return isTag(event)");
         txtCorpZip.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         //txtCorpPhone.Attributes.Add("onkeydown", "return isNumber(event)");
         //txtCorpPhone.Attributes.Add("onkeypress", "return DisableEnter(event)");
         //txtCorpPhone.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         //txtCorpPhone.Attributes.Add("onblur", "return BlurNotNumber('" + txtCorpPhone.ClientID + "')");
         //txtCorpMobile.Attributes.Add("onkeydown", "return isNumber(event)");
         txtCorpMobile.Attributes.Add("onkeydown", "return isNumberPhone(event)");
         txtCorpMobile.Attributes.Add("onblur", "return BlurNotNumber('" + txtCorpMobile.ClientID + "')");
         txtCorpMobile.Attributes.Add("onchange", "IncrmntConfrmCounter()");

         txtCorpWebsite.Attributes.Add("onkeypress", "return isTag(event)");
         txtCorpWebsite.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtCorpEmail.Attributes.Add("onkeypress", "return isTag(event)");
         txtCorpEmail.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         ddlFiscalMonth.Attributes.Add("onkeypress", "return DisableEnter(event)");
         ddlFiscalMonth.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtTinNumber.Attributes.Add("onkeypress", "return isTag(event)");
         txtTinNumber.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtCinNumber.Attributes.Add("onkeypress", "return isTag(event)");
         txtCinNumber.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
         cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         cbxSameOrg.Attributes.Add("onkeypress", "return DisableEnter(event)");
         cbxSameOrg.Attributes.Add("onchange", "ViewAttachment()");
         cbxRmveStrg.Attributes.Add("onkeypress", "return DisableEnter(event)");
         cbxRmveStrg.Attributes.Add("onchange", "IncrmntConfrmCounter()");
         txtCorpName.Focus();
         if (!IsPostBack)
         {

             //if (Session["CORPOFFICEID"] != null)
             //{
             //    DropDownEmployeeDataStore();
             //    HiddenCorpChk.Value = "1";
             //}
             //else if (Session["CORPOFFICEID"] == null)
             //{
             //    HiddenCorpChk.Value = "0";
             //    hiddenEmpDdlData.Value = "0";
             //}
            
             //new code for add provision
             clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
             int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
             //Allocating child roles
             if (Session["USERID"] != null)
             {
                 intUserId = Convert.ToInt32(Session["USERID"]);

             }
             else if (Session["USERID"] == null)
             {
                 Response.Redirect("~/Default.aspx");
             }
             intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Corporate_Office);
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
                         //future

                     }

                 }

                 if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                 {
                     HiddenAddProvision.Value = "1";

                 }


             }



             //new code for add provision
             int intImageMaxSize = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SIZE.WATER_RECHARGE);
             hiddenUserImageSize.Value = intImageMaxSize.ToString();
             BsnsTypeLoad();
             ShareTypeLoad();
             ParentUnitLoad();

             clsBusinessLayer objBusiness = new clsBusinessLayer();
             string strCurrentDate = objBusiness.LoadCurrentDateInString();
             txtDate.Value = strCurrentDate;
             hiddenCurrentDate.Value = strCurrentDate;

             clsEntityCorpOffice objEntityCorpOffice = new clsEntityCorpOffice();

             if (Session["ORGID"] != null)
             {
                 objEntityCorpOffice.Organisation_Id = Convert.ToInt32(Session["ORGID"]);
                 hiddenOrgId.Value = Convert.ToString(Session["ORGID"]);
             }
             else
             {
                 Response.Redirect("~/Default.aspx");
             }

             //Select Corporate office count of current organisation
             int intCorpOfficeCount = Convert.ToInt32(objBusinessLayerCorpOffice.CorpOfficeCount(objEntityCorpOffice));
             //Select count of how many offices registered yet
             int intCheckCorpOffice = Convert.ToInt32(objBusinessLayerCorpOffice.CheckCorpOfficeCount(objEntityCorpOffice));

             //when editing 
             if (Request.QueryString["Id"] != null)
             {
                 // ddlOfficeTyp.Focus();
                 string strRandomMixedId = Request.QueryString["Id"].ToString();
                 string strLenghtofId = strRandomMixedId.Substring(0, 2);
                 int intLenghtofId = Convert.ToInt16(strLenghtofId);
                 string strId = strRandomMixedId.Substring(2, intLenghtofId);
                 HiddenFieldCorpID.Value = strId;
                 Update(strId);
                 lblEntry.InnerText = "Edit Business Unit";
                 lblEntryP.InnerText = "Edit Business Unit";

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
                 }
             }

             //when  viewing
             else if (Request.QueryString["ViewId"] != null)
             {
                 //ddlOfficeTyp.Focus();
                 string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                 string strLenghtofId = strRandomMixedId.Substring(0, 2);
                 int intLenghtofId = Convert.ToInt16(strLenghtofId);
                 string strId = strRandomMixedId.Substring(2, intLenghtofId);

                 View(strId);

                 lblEntry.InnerText = "View Business Unit";
                 lblEntryP.InnerText = "View Business Unit";
             }

             //Method of checking how many allowed offices
             else if (intCheckCorpOffice >= intCorpOfficeCount)
             {
                 lblEntry.InnerText = "Add Business Unit";
                 lblEntryP.InnerText = "Add Business Unit";
                 if (Request.QueryString["InsUpd"] == null)
                 {
                     ScriptManager.RegisterStartupScript(this, GetType(), "CorpOfficeCountReached", "CorpOfficeCountReached();", true);
                 }
                 else
                 {
                     string strInsUpd = Request.QueryString["InsUpd"].ToString();
                     if (strInsUpd == "Ins")
                     {
                         ScriptManager.RegisterStartupScript(this, GetType(), "CorpOfficeCount", "CorpOfficeCount();", true);
                     }
                     else if (strInsUpd == "Upd")
                     {
                         ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                     }

                 }
                 btnAdd.Visible = false;
                 btnAddClose.Visible = false;
                 btnUpdate.Visible = false;
                 btnUpdateClose.Visible = false;

                 btnAddF.Visible = false;
                 btnAddCloseF.Visible = false;
                 btnUpdateF.Visible = false;
                 btnUpdateCloseF.Visible = false;

             }
             else
             {
                 lblEntry.InnerText = "Add Business Unit";
                 lblEntryP.InnerText = "Add Business Unit";
                 btnUpdate.Visible = false;
                 btnUpdateClose.Visible = false;
                 btnAdd.Visible = true;
                 btnAddClose.Visible = true;

                 btnUpdateF.Visible = false;
                 btnUpdateCloseF.Visible = false;
                 btnAddF.Visible = true;
                 btnAddCloseF.Visible = true;
                 // ddlOfficeTyp.Focus();
                 CorpTypeLoad();
                 CountryLoad();
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
                 }

             }

             if (HiddenFieldCorpID.Value != "")
             {
                 DropDownEmployeeDataStore();
                 HiddenCorpChk.Value = "1";
                 divBankDtls.Visible = true;
             }
             else
             {
                 HiddenCorpChk.Value = "0";
                 hiddenEmpDdlData.Value = "0";
                 divBankDtls.Visible = false;
             }
         }
     }
     protected void btnClear_Click(object sender, EventArgs e)
     {
         Response.Redirect("gen_Corp_Office.aspx");
     }
     //Method for binding Corporation type details to dropdown list.
     public void CorpTypeLoad()
     {
         DataTable dtCorpType = objBusinessLayerCorpOffice.ReadCorpType();

         ddlOfficeTyp.DataSource = dtCorpType;

         ddlOfficeTyp.DataTextField = "CORPTYPE_NAME";
         ddlOfficeTyp.DataValueField = "CORPTYPE_ID";
         ddlOfficeTyp.DataBind();

         ddlOfficeTyp.Items.Insert(0, "--Select Office Type--");
     }

     //Method for binding Business type details to dropdown list.
     public void BsnsTypeLoad()
     {
         DataTable dtCorpType = objBusinessLayerCorpOffice.ReadBsnsType();

         ddlBsnsTyp.DataSource = dtCorpType;

         ddlBsnsTyp.DataTextField = "BSNSTYPE_NAME";
         ddlBsnsTyp.DataValueField = "BSNSTYPE_ID";
         ddlBsnsTyp.DataBind();

         ddlBsnsTyp.Items.Insert(0, "--Select Business Type--");
         //EVM 24 new code
         DataTable dtPartner = objBusinessLayerCorpOffice.ReadPartners();
         dtPartner.TableName = "dtTablePartner";
         string result;
         using (StringWriter sw = new StringWriter())
         {
             dtPartner.WriteXml(sw);
             result = sw.ToString();
         }
         HiddenPartner.Value = result;

     }

     [WebMethod]
     public static string partnerDocId(int PId)
     {
         clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
         clsEntityCorpOffice objEntityCorpOffice = new clsEntityCorpOffice();
         objEntityCorpOffice.PartnerId = PId;
         DataTable dtDoc = objBusinessLayerCorpOffice.ReadPartnersDoc(objEntityCorpOffice);
         string docNo = dtDoc.Rows[0]["PRTNR_DOCNUM"].ToString();
         return docNo;

     }

     [WebMethod]

     public static string[] Org_Attachment(int orgid)
     {
         clsEntityCorpOffice objEntityCorpOffice = new clsEntityCorpOffice();
         clsCommonLibrary objCommon = new clsCommonLibrary();
         clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
         int cr = 1;
         string[] result = new string[10];
         for (int s = 1; s < 4; s++)
         {
             cr = s;
             objEntityCorpOffice.crNo = cr;
             objEntityCorpOffice.Organisation_Id = orgid;
             DataTable dtCrCard = new DataTable();
             dtCrCard = objBusinessLayerCorpOffice.OrgCrCard(objEntityCorpOffice);
             if (dtCrCard.Rows.Count > 0)
             {
                 result[3] = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ORGANIZATION);
                 if (cr == 1)
                 {
                     result[0] = DataTableToJSONWithJavaScriptSerializer(dtCrCard);
                 }
                 else if (cr == 2)
                 {
                     result[1] = DataTableToJSONWithJavaScriptSerializer(dtCrCard);
                 }
                 else
                 {
                     result[2] = DataTableToJSONWithJavaScriptSerializer(dtCrCard);
                 }

             }
         }
         return result;

     }


     public class clsAttchtView
     {

         public string ROWID { get; set; }
         public string FILEPATH { get; set; }
         public string DESCRPTN { get; set; }
         public string EVTACTION { get; set; }
         public string DTLID { get; set; }

     }


     //end new code

     //Method for binding Share type details to dropdown list.
     public void ShareTypeLoad()
     {
         DataTable dtCorpType = objBusinessLayerCorpOffice.ReadShareType();

         ddlShareTyp.DataSource = dtCorpType;
         ddlShareTyp.Items.Clear();

         ddlShareTyp.DataTextField = "SHARETYPE_NAME";
         ddlShareTyp.DataValueField = "SHARETYPE_ID";
         ddlShareTyp.DataBind();

         ListItem lst = new ListItem("--Select Share Type--", "0");

         ddlShareTyp.Items.Insert(0, lst);
     }
     //Method for binding parent unit details to dropdown list.
     public void ParentUnitLoad()
     {
         clsEntityCorpOffice objEntityCorpOffice = new clsEntityCorpOffice();
         if (Session["ORGID"] != null)
         {
             objEntityCorpOffice.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

         }
         else if (Session["ORGID"] == null)
         {
             Response.Redirect("../../Default.aspx");
         }

         if (Request.QueryString["Id"] != null)
         {
             // ddlOfficeTyp.Focus();
             string strRandomMixedId = Request.QueryString["Id"].ToString();
             string strLenghtofId = strRandomMixedId.Substring(0, 2);
             int intLenghtofId = Convert.ToInt16(strLenghtofId);
             string strId = strRandomMixedId.Substring(2, intLenghtofId);
             objEntityCorpOffice.CorpOfficeId = Convert.ToInt32(strId);
         }


         DataTable dtCorpType = objBusinessLayerCorpOffice.ReadParentUnit(objEntityCorpOffice);

         ddlParent.DataSource = dtCorpType;

         ddlParent.DataTextField = "CORPRT_NAME";
         ddlParent.DataValueField = "CORPRT_ID";
         ddlParent.DataBind();

         ddlParent.Items.Insert(0, "--Select Parent Unit--");
     }
     //Method for binding Country type details to dropdown list.
     public void CountryLoad()
     {
         DataTable dtCountry = objBusinessLayerCorpOffice.ReadCountry();

         ddlCorpCountry.DataSource = dtCountry;

         ddlCorpCountry.DataTextField = "CNTRY_NAME";
         ddlCorpCountry.DataValueField = "CNTRY_ID";
         ddlCorpCountry.DataBind();
         ddlCorpCountry.Items.Insert(0, "--Select Country--");
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
     public class clsAtchmntData
     {

         public string ROWID { get; set; }
         public string FILEPATH { get; set; }
         public string DESCRPTN { get; set; }
         public string EVTACTION { get; set; }
         public string DTLID { get; set; }

     }
     public class clsTVData
     {

         public string PARTNER { get; set; }
         public string DOCNUM { get; set; }
         public string SHAREPER { get; set; }
         public string EVTACTION { get; set; }
         public string DTLID { get; set; }

     }
     public class clsWBData
     {
         public string ROWID { get; set; }
         public string BANKID { get; set; }
         public string BRANCH { get; set; }
         public string IBAN { get; set; }
         public string DETAILID { get; set; }
         public string EVTACTION { get; set; }
     }
     //When save(add) button clicked
     protected void btnAdd_Click(object sender, EventArgs e)
     {
         Button clickedButton = sender as Button;
         clsEntityCorpOffice objEntityCorpOffice = new clsEntityCorpOffice();
         clsCommonLibrary objCommon = new clsCommonLibrary();
         objEntityCorpOffice.CorpTypeId = Convert.ToInt32(ddlOfficeTyp.Value);
         objEntityCorpOffice.Corporation_Name = txtCorpName.Value.ToUpper().Trim();
         objEntityCorpOffice.Address1 = txtCorpAdd1.Value.Trim();
         objEntityCorpOffice.Address2 = txtCorpAdd2.Value.Trim();
         objEntityCorpOffice.Address3 = txtCorpAdd3.Value.Trim();
         objEntityCorpOffice.TIN_Number = txtTinNumber.Value.Trim();
         objEntityCorpOffice.Cin_Number = txtCinNumber.Value.Trim();
         objEntityCorpOffice.Cust_Care_Number = txtCustCareNumber.Value.Trim();
         objEntityCorpOffice.Short_Name = txtShortName.Value.Trim();
         objEntityCorpOffice.Short_Address = txtShortAddress.Value.Trim();
         objEntityCorpOffice.CountryId = Convert.ToInt32(ddlCorpCountry.SelectedItem.Value);
         //If there is no state selected
         if (HiddenFieldState.Value == "" || HiddenFieldState.Value == null)
         {
             objEntityCorpOffice.StateId = null;
             objEntityCorpOffice.CityId = null;
         }
         else
         {
             if (HiddenFieldState.Value != "--Select Your State--" && HiddenFieldState.Value != "")
             {
                 objEntityCorpOffice.StateId = Convert.ToInt32(HiddenFieldState.Value);
             }
             else
                 objEntityCorpOffice.StateId = null;
             //If there is no city selected
             if (HiddenFieldCity.Value == "" || HiddenFieldCity.Value == null)
             {
                 objEntityCorpOffice.CityId = null;
             }
             else
             {
                 if (HiddenFieldCity.Value != "--Select Your City--" && HiddenFieldCity.Value != "")
                 {
                     objEntityCorpOffice.CityId = Convert.ToInt32(HiddenFieldCity.Value);
                 }
                 else
                     objEntityCorpOffice.CityId = null;

             }
         }
         objEntityCorpOffice.ZipCode = txtCorpZip.Value.Trim();
        // objEntityCorpOffice.Phone_Number = txtCorpPhone.Text;
         objEntityCorpOffice.Mobile_Number = txtCorpMobile.Value.Trim();
         objEntityCorpOffice.Web_Address = txtCorpWebsite.Value.Trim();
         objEntityCorpOffice.Email_Address = txtCorpEmail.Value.Trim();
         objEntityCorpOffice.FiscalMonth = Convert.ToInt32(ddlFiscalMonth.SelectedItem.Value);
         if (Session["USERID"] != null)
         {
             objEntityCorpOffice.UserId = Convert.ToInt32(Session["USERID"]);
         }
         else
         {
             Response.Redirect("~/Default.aspx");
         }
         if (Session["ORGID"] != null)
         {
             objEntityCorpOffice.Organisation_Id = Convert.ToInt32(Session["ORGID"]);
         }
         else
         {
             Response.Redirect("~/Default.aspx");
         }

         if (cbxStatus.Checked == true)
         {
             objEntityCorpOffice.CorpStatus = 1;
         }
         else
         {
             objEntityCorpOffice.CorpStatus = 0;
         }
         //if application date is not selected from date user controller.
         string strDate = txtDate.Value;


         //start new code
         objEntityCorpOffice.Code = txtCode.Value.Trim();
         objEntityCorpOffice.Fax = txtFax.Value.Trim();
         objEntityCorpOffice.EnqMail = txtEnqMail.Value.Trim();
         objEntityCorpOffice.StorageMail = txtMailStrg.Value.Trim();
         objEntityCorpOffice.CRNnum = txtCRN.Value.Trim();
         objEntityCorpOffice.CRNexpDate = objCommon.textToDateTime(txtCRNExpDate.Value);
         if (txtCRNIssDate.Value != "")
         {
             objEntityCorpOffice.CRNissDate = objCommon.textToDateTime(txtCRNIssDate.Value);
         }

         objEntityCorpOffice.TINnum = txtTIN.Value.Trim();
         objEntityCorpOffice.TINexpDate = objCommon.textToDateTime(txtTINExp.Value);
         if (txtTINIss.Value != "")
         {
             objEntityCorpOffice.TINissDate = objCommon.textToDateTime(txtTINIss.Value);
         }
         objEntityCorpOffice.CCNnum = txtCCN.Value.Trim();
         objEntityCorpOffice.CCNexpDate = objCommon.textToDateTime(txtCCNExp.Value);
        //start:- EVM-0024
         string strchkin = txtChkIn.Value.Trim();
         string strcheckin = Convert.ToString("01-01-1000 " + strchkin);
         DateTime dtChkIn = objCommon.textWithTimeToDateTime(strcheckin);
         objEntityCorpOffice.CheckIn = dtChkIn;
         string strchkout = txtChkOut.Value.Trim();
         string strcheckout = Convert.ToString("01-01-1000 " + strchkout);
         DateTime dtChkOut = objCommon.textWithTimeToDateTime(strcheckout);
         objEntityCorpOffice.CheckOut = dtChkOut;
         // end EVM-0024

         if (txtCCNIss.Value != "")
         {
             objEntityCorpOffice.CCNissDate = objCommon.textToDateTime(txtCCNIss.Value);
         }
         if (cbxRmveStrg.Checked == true)
         {
             objEntityCorpOffice.RemoveStrg = 1;
         }
         else
         {
             objEntityCorpOffice.RemoveStrg = 0;
         }
         objEntityCorpOffice.BsnsTypeId = Convert.ToInt32(ddlBsnsTyp.Value);
         if (ddlShareTyp.Value != "--Select Share Type--")
         {

             objEntityCorpOffice.ShareTypeId = Convert.ToInt32(ddlShareTyp.Value);
         }

         if (ddlParent.Value != "--Select Parent Unit--")
          {

              objEntityCorpOffice.ParentTypId = Convert.ToInt32(ddlParent.Value);
          }

         //stop icon file upload

         //start file upload
          string jsonData = HiddenField2_FileUpload.Value;
          string c = jsonData.Replace("\"{", "\\{");

          string d = c.Replace("\\n", "\r\n");
          string g = d.Replace("\\", "");
          string h = g.Replace("}\"]", "}]");
          string i = h.Replace("}\",", "},");

          List<clsAtchmntData> objTVDataList = new List<clsAtchmntData>();
          objTVDataList = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);

          List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPermitAttchmntDeatilsList = new List<clsEntityInsuranceAndPermitAttchmntDtl>();

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
                              clsEntityInsuranceAndPermitAttchmntDtl objEntityRnwlDetailsAttchmnt = new clsEntityInsuranceAndPermitAttchmntDtl();
                              string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                              objEntityRnwlDetailsAttchmnt.ActualFileName = strFileName;
                              string strFileExt;

                              strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                              // int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.QUOTATION);
                              int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                              objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = count;
                              string strImageName = "CRN_" + intImageSection.ToString() + "_" + count + "." + strFileExt;
                              objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                              string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);

                              PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityRnwlDetailsAttchmnt.FileName);
                              if (objTVDataList[count].DESCRPTN != "--Description--")
                              {
                                  objEntityRnwlDetailsAttchmnt.Description = objTVDataList[count].DESCRPTN;
                              }
                              objEntityPermitAttchmntDeatilsList.Add(objEntityRnwlDetailsAttchmnt);

                              //  PostedFile.SaveAs(Server.MapPath("Files\\") + FileName);

                          }
                      }
                  }
              }
          }
         
          jsonData = HiddenField3_FileUpload.Value;
          c = jsonData.Replace("\"{", "\\{");
          d = c.Replace("\\n", "\r\n");
          g = d.Replace("\\", "");
          h = g.Replace("}\"]", "}]");
          i = h.Replace("}\",", "},");

          List<clsAtchmntData> objTVDataList1 = new List<clsAtchmntData>();
          objTVDataList1 = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);

          List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsurAttchmntDeatilsList = new List<clsEntityInsuranceAndPermitAttchmntDtl>();
          if (HiddenField3_FileUpload.Value != "" && HiddenField3_FileUpload.Value != null)
          {

              for (int count = 0; count < objTVDataList1.Count; count++)
              {
                  string jsonFileid = "file" + objTVDataList1[count].ROWID;
                  for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                  {

                      string fileId = Request.Files.AllKeys[intCount].ToString();
                      HttpPostedFile PostedFile = Request.Files[intCount];
                      if (fileId == jsonFileid)
                      {
                          if (PostedFile.ContentLength > 0)
                          {
                              clsEntityInsuranceAndPermitAttchmntDtl objEntityRnwlDetailsAttchmnt = new clsEntityInsuranceAndPermitAttchmntDtl();
                              string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                              objEntityRnwlDetailsAttchmnt.ActualFileName = strFileName;
                              string strFileExt;

                              strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                              // int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.QUOTATION);
                              int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                              objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = count;
                              string strImageName = "TIN_" + intImageSection.ToString() + "_" + count + "." + strFileExt;
                              objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                              string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);

                              PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityRnwlDetailsAttchmnt.FileName);
                              if (objTVDataList1[count].DESCRPTN != "--Description--")
                              {
                                  objEntityRnwlDetailsAttchmnt.Description = objTVDataList1[count].DESCRPTN;
                              }
                              objEntityInsurAttchmntDeatilsList.Add(objEntityRnwlDetailsAttchmnt);

                              //  PostedFile.SaveAs(Server.MapPath("Files\\") + FileName);

                          }
                      }
                  }
              }
          }
         

          jsonData = HiddenField4_FileUpload.Value;
          c = jsonData.Replace("\"{", "\\{");
          d = c.Replace("\\n", "\r\n");
          g = d.Replace("\\", "");
          h = g.Replace("}\"]", "}]");
          i = h.Replace("}\",", "},");

          List<clsAtchmntData> objTVDataList2 = new List<clsAtchmntData>();
          objTVDataList2 = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);

          List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityVhclAttchmntDeatilsList = new List<clsEntityInsuranceAndPermitAttchmntDtl>();
          if (HiddenField4_FileUpload.Value != "" && HiddenField4_FileUpload.Value != null)
          {
              for (int count = 0; count < objTVDataList2.Count; count++)
              {
                  string jsonFileid = "file" + objTVDataList2[count].ROWID;
                  for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                  {

                      string fileId = Request.Files.AllKeys[intCount].ToString();
                      HttpPostedFile PostedFile = Request.Files[intCount];
                      if (fileId == jsonFileid)
                      {
                          if (PostedFile.ContentLength > 0)
                          {
                              clsEntityInsuranceAndPermitAttchmntDtl objEntityRnwlDetailsAttchmnt = new clsEntityInsuranceAndPermitAttchmntDtl();
                              string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                              objEntityRnwlDetailsAttchmnt.ActualFileName = strFileName;
                              string strFileExt;

                              strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                              // int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.QUOTATION);
                              int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                              objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = count;
                              string strImageName = "CCN_" + intImageSection.ToString() + "_" + count + "." + strFileExt;
                              objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                              string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);

                              PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityRnwlDetailsAttchmnt.FileName);
                              if (objTVDataList2[count].DESCRPTN != "--Description--")
                              {
                                  objEntityRnwlDetailsAttchmnt.Description = objTVDataList2[count].DESCRPTN;
                              }
                              objEntityVhclAttchmntDeatilsList.Add(objEntityRnwlDetailsAttchmnt);

                              //  PostedFile.SaveAs(Server.MapPath("Files\\") + FileName);

                          }
                      }
                  }
              }

          }



         //end file upload
         //start partnership table data adding

          List<clsEntityCorpPartners> objEntityTrficVioltnDetilsList = new List<clsEntityCorpPartners>();
          
          jsonData = HiddenFieldAddTable.Value;
          c = jsonData.Replace("\"{", "\\{");
          d= c.Replace("\\n", "\r\n");
          g = d.Replace("\\", "");
          h = g.Replace("}\"]", "}]");
          i = h.Replace("}\",", "},");
          List<clsTVData> objTVDataList5 = new List<clsTVData>();
          //   UserData  data
          objTVDataList5 = JsonConvert.DeserializeObject<List<clsTVData>>(i);
          if (HiddenFieldAddTable.Value != "" && HiddenFieldAddTable.Value != null)
          {

              foreach (clsTVData objclsTVData in objTVDataList5)
              {
                  clsEntityCorpPartners objEntityDetails = new clsEntityCorpPartners();

                  if (objclsTVData.PARTNER != "" && objclsTVData.DOCNUM != "" && objclsTVData.SHAREPER != "")
                  {
                      objEntityDetails.PartnerId =Convert.ToInt32(objclsTVData.PARTNER);
                      objEntityDetails.DocumentNo = objclsTVData.DOCNUM;
                      objEntityDetails.SharePerc = Convert.ToDecimal(objclsTVData.SHAREPER);
                      objEntityTrficVioltnDetilsList.Add(objEntityDetails);
                  }
              }
          }


          //stop partnership table data adding

         //Start:-For bank table
          List<clsEntityBankDtl> objEntityDetilsListBank = new List<clsEntityBankDtl>();
          if (hiddenTotalData.Value != "")
          {
               jsonData = hiddenTotalData.Value;
               c = jsonData.Replace("\"{", "\\{");
               d = c.Replace("\\n", "\r\n");
               g = d.Replace("\\", "");
               h = g.Replace("}\"]", "}]");
               i = h.Replace("}\",", "},");
              List<clsWBData> objWBDataList = new List<clsWBData>();
              //   UserData  data
              objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(i);
              foreach (clsWBData objclsWBData in objWBDataList)
              {
                  clsEntityBankDtl objEntityDetails = new clsEntityBankDtl();
                  objEntityDetails.BankId = Convert.ToInt32(objclsWBData.BANKID);
                  objEntityDetails.Branch = objclsWBData.BRANCH;
                  objEntityDetails.IBAN = objclsWBData.IBAN;
                  objEntityDetilsListBank.Add(objEntityDetails);
              }
          }

         //End:-For bank table





         //Fetch the count of corporate office name that existed in the table.
         string strCount = objBusinessLayerCorpOffice.CheckCorpOffice(objEntityCorpOffice);
         string strCodecount = objBusinessLayerCorpOffice.CheckCodenum(objEntityCorpOffice);
         //string strCRNcount = objBusinessLayerCorpOffice.CheckCRNnum(objEntityCorpOffice);
         //string strTINcount = objBusinessLayerCorpOffice.CheckTINnum(objEntityCorpOffice);
         //string strCCNcount = objBusinessLayerCorpOffice.CheckCCNnum(objEntityCorpOffice);
        
         //if (cbxSameOrg.Checked == true)
         //{
         //    strCRNcount = "0";
         //    strTINcount="0";
         //    strCCNcount = "0";
         //}
         if (strCount == "0" &&  strCodecount=="0")
         {
             //Method for fetching nextvalue for insertion.
             objEntityCorpOffice.NextId = Convert.ToInt32(clsCommonLibrary.MasterId.Corporate_Office);
             DataTable dtNextId = objBusinessLayerCorpOffice.ReadNextId(objEntityCorpOffice);
             objEntityCorpOffice.NextValue = Convert.ToInt32(dtNextId.Rows[0]["MST_NEXT_VALUE"]);

             if (FileUploadProPic.HasFile)
             {
                 // GET FILE EXTENSION
                 string strFileName = FileUploadProPic.FileName;
                 string strFileExt = FileUploadProPic.FileName.Substring(FileUploadProPic.FileName.LastIndexOf('.') + 1).ToLower();
                 int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.CORP_OFFICE_IMAGE);
                 int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                 string strImageName = "Icon_" + objEntityCorpOffice.NextValue + "_" + intAppModSection.ToString() + "_" + intImageSection.ToString() + "." + strFileExt;

                 objEntityCorpOffice.Icon = strImageName;
                 objEntityCorpOffice.ActIcon = strFileName;
             }
           
             objEntityCorpOffice.ApplicationDate = objCommon.textToDateTime(strDate);
             //Insertion Process
             objBusinessLayerCorpOffice.InsertCorpOffice(objEntityCorpOffice, objEntityPermitAttchmntDeatilsList, objEntityInsurAttchmntDeatilsList, objEntityVhclAttchmntDeatilsList, objEntityTrficVioltnDetilsList, objEntityDetilsListBank);
             string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
             if (FileUploadProPic.HasFile)
             {
                 FileUploadProPic.SaveAs(Server.MapPath(strImagePath) + objEntityCorpOffice.Icon);
             }
             if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
             {
                 Response.Redirect("gen_Corp_Office.aspx?InsUpd=Ins");
             }
             else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
             {
                 Response.Redirect("gen_Corp_OfficeList.aspx?InsUpd=Ins");
             }
            
         }
         //else
         //{
         //    if (strCount != "0")
         //    {
         //        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
         //        txtCorpName.Focus();
         //    }
           
         //    else if (strCodecount != "0")
         //    {
         //        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
         //        txtCCN.Focus();

         //    }
            
         //}

     }
     public class clsVhclDataDELETEAttchmnt
     {
         public string FILENAME { get; set; }

         public string DTLID { get; set; }

     }
     //When update button is clicked
     protected void btnUpdate_Click(object sender, EventArgs e)
     {
         Button clickedButton = sender as Button;
      
         if (Request.QueryString["Id"] != null)
         {
             clsCommonLibrary objCommon = new clsCommonLibrary();
             clsEntityCorpOffice objEntityCorpOffice = new clsEntityCorpOffice();

       


             string strRandomMixedId = Request.QueryString["Id"].ToString();
             string strLenghtofId = strRandomMixedId.Substring(0, 2);
             int intLenghtofId = Convert.ToInt16(strLenghtofId);
             string strId = strRandomMixedId.Substring(2, intLenghtofId);
             objEntityCorpOffice.CorpOfficeId = Convert.ToInt32(strId);

             objEntityCorpOffice.CorpTypeId = Convert.ToInt32(ddlOfficeTyp.Value);
             txtCorpName.Value = txtCorpName.Value.ToUpper().Trim();
             objEntityCorpOffice.Corporation_Name = txtCorpName.Value;
             objEntityCorpOffice.Address1 = txtCorpAdd1.Value.Trim();
             objEntityCorpOffice.Address2 = txtCorpAdd2.Value.Trim();
             objEntityCorpOffice.Address3 = txtCorpAdd3.Value.Trim();
             objEntityCorpOffice.TIN_Number = txtTinNumber.Value.Trim();
             objEntityCorpOffice.Cin_Number = txtCinNumber.Value.Trim();
             objEntityCorpOffice.Cust_Care_Number = txtCustCareNumber.Value.Trim();
             objEntityCorpOffice.Short_Name = txtShortName.Value.Trim();
             objEntityCorpOffice.Short_Address = txtShortAddress.Value.Trim();
             objEntityCorpOffice.CountryId = Convert.ToInt32(ddlCorpCountry.SelectedItem.Value);
             //If there is no state selected
             if (HiddenFieldState.Value == "" || HiddenFieldState.Value == null)
             {
                 objEntityCorpOffice.StateId = null;
                 objEntityCorpOffice.CityId = null;
             }
             else
             {
                 if (HiddenFieldState.Value != "--Select Your State--" && HiddenFieldState.Value != "")
                 {
                     objEntityCorpOffice.StateId = Convert.ToInt32(HiddenFieldState.Value);
                 }
                 else
                     objEntityCorpOffice.StateId = null;
                 //If there is no city selected
                 if (HiddenFieldCity.Value == "" || HiddenFieldCity.Value == null)
                 {
                     objEntityCorpOffice.CityId = null;
                 }
                 else
                 {
                     if (HiddenFieldCity.Value != "--Select Your City--" && HiddenFieldCity.Value != "")
                     {
                         objEntityCorpOffice.CityId = Convert.ToInt32(HiddenFieldCity.Value);
                     }
                     else
                         objEntityCorpOffice.CityId = null;

                 }
             }
             objEntityCorpOffice.ZipCode = txtCorpZip.Value.Trim();
            // objEntityCorpOffice.Phone_Number = txtCorpPhone.Text;
             objEntityCorpOffice.Mobile_Number = txtCorpMobile.Value.Trim();
             objEntityCorpOffice.Web_Address = txtCorpWebsite.Value.Trim();
             objEntityCorpOffice.Email_Address = txtCorpEmail.Value.Trim();
             objEntityCorpOffice.FiscalMonth = Convert.ToInt32(ddlFiscalMonth.SelectedItem.Value);

             if (Session["USERID"] != null)
             {
                 objEntityCorpOffice.UserId = Convert.ToInt32(Session["USERID"]);
             }
             else
             {
                 Response.Redirect("~/Default.aspx");
             }
             if (Session["ORGID"] != null)
             {
                 objEntityCorpOffice.Organisation_Id = Convert.ToInt32(Session["ORGID"]);


                 //string strLikePartner = "A";

                 //DataTable dtEmployess = objBusinessLayerCorpOffice.ReadPartnerWebService(strLikePartner.ToUpper(), objEntityCorpOffice);
             }
             else
             {
                 Response.Redirect("~/Default.aspx");
             }
             objEntityCorpOffice.dDate = System.DateTime.Now;
             if (cbxStatus.Checked == true)
             {
                 objEntityCorpOffice.CorpStatus = 1;
             }
             else
             {
                 objEntityCorpOffice.CorpStatus = 0;
             }
             //if application date is not selected from date user controller.
             string strDate = txtDate.Value;

             //start new code
             objEntityCorpOffice.Code = txtCode.Value.Trim();
             objEntityCorpOffice.Fax = txtFax.Value.Trim();
             objEntityCorpOffice.EnqMail = txtEnqMail.Value.Trim();
             objEntityCorpOffice.StorageMail = txtMailStrg.Value.Trim();
             objEntityCorpOffice.CRNnum = txtCRN.Value.Trim();
             objEntityCorpOffice.CRNexpDate = objCommon.textToDateTime(txtCRNExpDate.Value);
             if (txtCRNIssDate.Value != "")
             {
                 objEntityCorpOffice.CRNissDate = objCommon.textToDateTime(txtCRNIssDate.Value);
             }
             objEntityCorpOffice.TINnum = txtTIN.Value.Trim();
             objEntityCorpOffice.TINexpDate = objCommon.textToDateTime(txtTINExp.Value);
             if (txtTINIss.Value != "")
             {
                 objEntityCorpOffice.TINissDate = objCommon.textToDateTime(txtTINIss.Value);
             }
             objEntityCorpOffice.CCNnum = txtCCN.Value.Trim();
             objEntityCorpOffice.CCNexpDate = objCommon.textToDateTime(txtCCNExp.Value);
             //start:- EVM-0024
             string strchkin = txtChkIn.Value.Trim();
             string strcheckin = Convert.ToString("01-01-1000 " + strchkin);
             DateTime dtChkIn = objCommon.textWithTimeToDateTime(strcheckin);
             objEntityCorpOffice.CheckIn = dtChkIn;
             string strchkout = txtChkOut.Value.Trim();
             string strcheckout = Convert.ToString("01-01-1000 " + strchkout);
             DateTime dtChkOut = objCommon.textWithTimeToDateTime(strcheckout);
             objEntityCorpOffice.CheckOut = dtChkOut;
             // end EVM-0024
             if (txtCCNIss.Value != "")
             {
                 objEntityCorpOffice.CCNissDate = objCommon.textToDateTime(txtCCNIss.Value);
             }
             if (cbxRmveStrg.Checked == true)
             {
                 objEntityCorpOffice.RemoveStrg = 1;
             }
             else
             {
                 objEntityCorpOffice.RemoveStrg = 0;
             }
             objEntityCorpOffice.BsnsTypeId = Convert.ToInt32(ddlBsnsTyp.Value);
             if (ddlShareTyp.Value != "--Select Share Type--")
             {

                 objEntityCorpOffice.ShareTypeId = Convert.ToInt32(ddlShareTyp.Value);
             }

             if (ddlParent.Value != "--Select Parent Unit--")
             {

                 objEntityCorpOffice.ParentTypId = Convert.ToInt32(ddlParent.Value);
             }
             //end new code

             string iconfileid = "file201";
             for (int intCount = 0; intCount < Request.Files.Count; intCount++)
             {

                 string fileId = Request.Files.AllKeys[intCount].ToString();
                 HttpPostedFile PostedFile = Request.Files[intCount];
                 if (fileId == iconfileid)
                 {
                     if (PostedFile.ContentLength > 0)
                     {

                         string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                         string strFileExt;
                         strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                         int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);

                         string strImageName = "Icon_" +strFileName+intImageSection.ToString() + "_" + "." + strFileExt;

                         string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);

                         PostedFile.SaveAs(Server.MapPath(strImagePath) + strImageName);

                         objEntityCorpOffice.Icon = strImageName;
                         objEntityCorpOffice.ActIcon = strFileName;

                     }
                 }
             }

             if (FileUploadProPic.HasFile)
             {
                 // GET FILE EXTENSION
                 string strFileName = FileUploadProPic.FileName;
                 string strFileExt = FileUploadProPic.FileName.Substring(FileUploadProPic.FileName.LastIndexOf('.') + 1).ToLower();
                 int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.CORP_OFFICE_IMAGE);
                 int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                 string strImageName = "Icon_" + strId + "_" + intAppModSection.ToString() + "_" + intImageSection.ToString() + "." + strFileExt;

                 objEntityCorpOffice.Icon = strImageName;
                 objEntityCorpOffice.ActIcon = strFileName;
             }
             else
             {
                 //hiddenUserImage.Value = dtCprpOffice.Rows[0]["CORPRT_ICON"].ToString();
                 //hiddenImageName.Value = dtCprpOffice.Rows[0]["CORPRT_ACTICON"].ToString();


                 if (hiddenUserImage.Value != "")
                 {
                     objEntityCorpOffice.ActIcon = hiddenImageName.Value;
                     objEntityCorpOffice.Icon = hiddenUserImage.Value;
                     //HiddenField2_FileUpload.Value = hiddenUserImage.Value;
                 }
                 else
                 {
                     objEntityCorpOffice.ActIcon = null;
                     objEntityCorpOffice.Icon = null;
                 }
             }

             //start file upload
             string jsonData = HiddenField2_FileUpload.Value;
             string c = jsonData.Replace("\"{", "\\{");
             string d = c.Replace("\\n", "\r\n");
             string g = d.Replace("\\", "");
             string h = g.Replace("}\"]", "}]");
             string i = h.Replace("}\",", "},");

             List<clsAtchmntData> objTVDataList = new List<clsAtchmntData>();
             objTVDataList = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);

             List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPermitAttchmntDeatilsList = new List<clsEntityInsuranceAndPermitAttchmntDtl>();

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
                                 clsEntityInsuranceAndPermitAttchmntDtl objEntityRnwlDetailsAttchmnt = new clsEntityInsuranceAndPermitAttchmntDtl();
                                 string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                 objEntityRnwlDetailsAttchmnt.ActualFileName = strFileName;
                                 string strFileExt;

                                 strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                                 // int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.QUOTATION);
                                 int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                                 objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = count;
                                 string strImageName = "CRN_" + intImageSection.ToString() + "_" + count + "." + strFileExt;
                                 objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                                 string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);

                                 PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityRnwlDetailsAttchmnt.FileName);
                                 if (objTVDataList[count].DESCRPTN != "--Description--")
                                 {
                                     objEntityRnwlDetailsAttchmnt.Description = objTVDataList[count].DESCRPTN;
                                 }
                                 objEntityPermitAttchmntDeatilsList.Add(objEntityRnwlDetailsAttchmnt);

                                 //  PostedFile.SaveAs(Server.MapPath("Files\\") + FileName);

                             }
                         }
                     }
                 }
             }

             jsonData = HiddenField3_FileUpload.Value;
             c = jsonData.Replace("\"{", "\\{");
             d = c.Replace("\\n", "\r\n");
             g = d.Replace("\\", "");
             h = g.Replace("}\"]", "}]");
             i = h.Replace("}\",", "},");

             List<clsAtchmntData> objTVDataList1 = new List<clsAtchmntData>();
             objTVDataList1 = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);

             List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsurAttchmntDeatilsList = new List<clsEntityInsuranceAndPermitAttchmntDtl>();
             if (HiddenField3_FileUpload.Value != "" && HiddenField3_FileUpload.Value != null)
             {

                 for (int count = 0; count < objTVDataList1.Count; count++)
                 {
                     string jsonFileid = "file" + objTVDataList1[count].ROWID;
                     for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                     {

                         string fileId = Request.Files.AllKeys[intCount].ToString();
                         HttpPostedFile PostedFile = Request.Files[intCount];
                         if (fileId == jsonFileid)
                         {
                             if (PostedFile.ContentLength > 0)
                             {
                                 clsEntityInsuranceAndPermitAttchmntDtl objEntityRnwlDetailsAttchmnt = new clsEntityInsuranceAndPermitAttchmntDtl();
                                 string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                 objEntityRnwlDetailsAttchmnt.ActualFileName = strFileName;
                                 string strFileExt;

                                 strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                                 // int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.QUOTATION);
                                 int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                                 objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = count;
                                 string strImageName = "TIN_" + intImageSection.ToString() + "_" + count + "." + strFileExt;
                                 objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                                 string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);

                                 PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityRnwlDetailsAttchmnt.FileName);
                                 if (objTVDataList1[count].DESCRPTN != "--Description--")
                                 {
                                     objEntityRnwlDetailsAttchmnt.Description = objTVDataList1[count].DESCRPTN;
                                 }
                                 objEntityInsurAttchmntDeatilsList.Add(objEntityRnwlDetailsAttchmnt);

                                 //  PostedFile.SaveAs(Server.MapPath("Files\\") + FileName);

                             }
                         }
                     }
                 }
             }


             jsonData = HiddenField4_FileUpload.Value;
             c = jsonData.Replace("\"{", "\\{");
             d = c.Replace("\\n", "\r\n");
             g = d.Replace("\\", "");
             h = g.Replace("}\"]", "}]");
             i = h.Replace("}\",", "},");

             List<clsAtchmntData> objTVDataList2 = new List<clsAtchmntData>();
             objTVDataList2 = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);

             List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityVhclAttchmntDeatilsList = new List<clsEntityInsuranceAndPermitAttchmntDtl>();
             if (HiddenField4_FileUpload.Value != "" && HiddenField4_FileUpload.Value != null)
             {
                 for (int count = 0; count < objTVDataList2.Count; count++)
                 {
                     string jsonFileid = "file" + objTVDataList2[count].ROWID;
                     for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                     {

                         string fileId = Request.Files.AllKeys[intCount].ToString();
                         HttpPostedFile PostedFile = Request.Files[intCount];
                         if (fileId == jsonFileid)
                         {
                             if (PostedFile.ContentLength > 0)
                             {
                                 clsEntityInsuranceAndPermitAttchmntDtl objEntityRnwlDetailsAttchmnt = new clsEntityInsuranceAndPermitAttchmntDtl();
                                 string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                 objEntityRnwlDetailsAttchmnt.ActualFileName = strFileName;
                                 string strFileExt;

                                 strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                                 // int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.QUOTATION);
                                 int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                                 objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = count;
                                 string strImageName = "CCN_" + intImageSection.ToString() + "_" + count + "." + strFileExt;
                                 objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                                 string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);

                                 PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityRnwlDetailsAttchmnt.FileName);
                                 if (objTVDataList2[count].DESCRPTN != "--Description--")
                                 {
                                     objEntityRnwlDetailsAttchmnt.Description = objTVDataList2[count].DESCRPTN;
                                 }
                                 objEntityVhclAttchmntDeatilsList.Add(objEntityRnwlDetailsAttchmnt);

                                 //  PostedFile.SaveAs(Server.MapPath("Files\\") + FileName);

                             }
                         }
                     }
                 }

             }



             //end file upload



             //start-for deleting attached files
             //for permit files
             string strCanclDtlId = "";
             string[] strarrCancldtlIds = strCanclDtlId.Split(',');
             if (hiddenPerFileCanclDtlId.Value != "" && hiddenPerFileCanclDtlId.Value != null)
             {
                 strCanclDtlId = hiddenPerFileCanclDtlId.Value;
                 strarrCancldtlIds = strCanclDtlId.Split(',');

             }

             List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPerDeleteAttchmntDeatilsList = new List<clsEntityInsuranceAndPermitAttchmntDtl>();

             if (hiddenPerFileCanclDtlId.Value != "" && hiddenPerFileCanclDtlId.Value != null)
             {
                 string jsonDataDltAttch = hiddenPerFileCanclDtlId.Value;
                 string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                 string strAtt2 = strAtt1.Replace("\\", "");
                 string strAtt3 = strAtt2.Replace("}\"]", "}]");
                 string strAtt4 = strAtt3.Replace("}\",", "},");
                 List<clsVhclDataDELETEAttchmnt> objVhclDataDltAttList = new List<clsVhclDataDELETEAttchmnt>();
                 //   UserData  data
                 objVhclDataDltAttList = JsonConvert.DeserializeObject<List<clsVhclDataDELETEAttchmnt>>(strAtt4);


                 foreach (clsVhclDataDELETEAttchmnt objClsVhclDltAttData in objVhclDataDltAttList)
                 {

                     clsEntityInsuranceAndPermitAttchmntDtl objEntityRnwlDetailsAttchmnt = new clsEntityInsuranceAndPermitAttchmntDtl();

                     objEntityRnwlDetailsAttchmnt.RnwlId = Convert.ToInt32(objClsVhclDltAttData.DTLID);
                     objEntityRnwlDetailsAttchmnt.FileName = Convert.ToString(objClsVhclDltAttData.FILENAME);

                     objEntityPerDeleteAttchmntDeatilsList.Add(objEntityRnwlDetailsAttchmnt);


                 }
             }
             //for insurance files
             strCanclDtlId = "";
             strarrCancldtlIds = strCanclDtlId.Split(',');
             if (hiddenInsFileCanclDtlId.Value != "" && hiddenInsFileCanclDtlId.Value != null)
             {
                 strCanclDtlId = hiddenInsFileCanclDtlId.Value;
                 strarrCancldtlIds = strCanclDtlId.Split(',');

             }

             List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsDeleteAttchmntDeatilsList = new List<clsEntityInsuranceAndPermitAttchmntDtl>();

             if (hiddenInsFileCanclDtlId.Value != "" && hiddenInsFileCanclDtlId.Value != null)
             {
                 string jsonDataDltAttch = hiddenInsFileCanclDtlId.Value;
                 string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                 string strAtt2 = strAtt1.Replace("\\", "");
                 string strAtt3 = strAtt2.Replace("}\"]", "}]");
                 string strAtt4 = strAtt3.Replace("}\",", "},");
                 List<clsVhclDataDELETEAttchmnt> objVhclDataDltAttList = new List<clsVhclDataDELETEAttchmnt>();
                 //   UserData  data
                 objVhclDataDltAttList = JsonConvert.DeserializeObject<List<clsVhclDataDELETEAttchmnt>>(strAtt4);


                 foreach (clsVhclDataDELETEAttchmnt objClsVhclDltAttData in objVhclDataDltAttList)
                 {

                     clsEntityInsuranceAndPermitAttchmntDtl objEntityRnwlDetailsAttchmnt = new clsEntityInsuranceAndPermitAttchmntDtl();

                     objEntityRnwlDetailsAttchmnt.RnwlId = Convert.ToInt32(objClsVhclDltAttData.DTLID);
                     objEntityRnwlDetailsAttchmnt.FileName = Convert.ToString(objClsVhclDltAttData.FILENAME);

                     objEntityInsDeleteAttchmntDeatilsList.Add(objEntityRnwlDetailsAttchmnt);


                 }
             }
             //for vehicle files
             strCanclDtlId = "";
             strarrCancldtlIds = strCanclDtlId.Split(',');
             if (hiddenVhclFileCanclDtlId.Value != "" && hiddenVhclFileCanclDtlId.Value != null)
             {
                 strCanclDtlId = hiddenVhclFileCanclDtlId.Value;
                 strarrCancldtlIds = strCanclDtlId.Split(',');

             }

             List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityVhclDeleteAttchmntDeatilsList = new List<clsEntityInsuranceAndPermitAttchmntDtl>();

             if (hiddenVhclFileCanclDtlId.Value != "" && hiddenVhclFileCanclDtlId.Value != null)
             {
                 string jsonDataDltAttch = hiddenVhclFileCanclDtlId.Value;
                 string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                 string strAtt2 = strAtt1.Replace("\\", "");
                 string strAtt3 = strAtt2.Replace("}\"]", "}]");
                 string strAtt4 = strAtt3.Replace("}\",", "},");
                 List<clsVhclDataDELETEAttchmnt> objVhclDataDltAttList = new List<clsVhclDataDELETEAttchmnt>();
                 //   UserData  data
                 objVhclDataDltAttList = JsonConvert.DeserializeObject<List<clsVhclDataDELETEAttchmnt>>(strAtt4);


                 foreach (clsVhclDataDELETEAttchmnt objClsVhclDltAttData in objVhclDataDltAttList)
                 {

                     clsEntityInsuranceAndPermitAttchmntDtl objEntityRnwlDetailsAttchmnt = new clsEntityInsuranceAndPermitAttchmntDtl();

                     objEntityRnwlDetailsAttchmnt.RnwlId = Convert.ToInt32(objClsVhclDltAttData.DTLID);
                     objEntityRnwlDetailsAttchmnt.FileName = Convert.ToString(objClsVhclDltAttData.FILENAME);

                     objEntityVhclDeleteAttchmntDeatilsList.Add(objEntityRnwlDetailsAttchmnt);


                 }
             }
           //FOR TABLE
                List<clsEntityCorpPartners> objEntityTVDeatilsINSERTList = new List<clsEntityCorpPartners>();
                List<clsEntityCorpPartners> objEntityTVDeatilsUPDATEList = new List<clsEntityCorpPartners>();
                if (HiddenFieldAddTable.Value != "" && HiddenFieldAddTable.Value != null)
                {
                    jsonData = HiddenFieldAddTable.Value;
                    c = jsonData.Replace("\"{", "\\{");
                    d = c.Replace("\\n", "\r\n");
                    g = d.Replace("\\", "");
                    h = g.Replace("}\"]", "}]");
                    i = h.Replace("}\",", "},");
                    List<clsTVData> objTVDataList7 = new List<clsTVData>();
                    //   UserData  data
                    objTVDataList7 = JsonConvert.DeserializeObject<List<clsTVData>>(i);


                    foreach (clsTVData objclsTVData in objTVDataList7)
                    {
                        if (objclsTVData.EVTACTION == "INS")
                        {
                            clsEntityCorpPartners objEntityDetails = new clsEntityCorpPartners();

                            if (objclsTVData.PARTNER != "" && objclsTVData.DOCNUM != "" && objclsTVData.SHAREPER != "")
                            {
                                objEntityDetails.PartnerId = Convert.ToInt32(objclsTVData.PARTNER);
                                objEntityDetails.DocumentNo = objclsTVData.DOCNUM;
                                objEntityDetails.SharePerc = Convert.ToDecimal(objclsTVData.SHAREPER);


                                objEntityTVDeatilsINSERTList.Add(objEntityDetails);
                            }
                        }
                        else if (objclsTVData.EVTACTION == "UPD")
                        {
                            clsEntityCorpPartners objEntityDetails = new clsEntityCorpPartners();

                            if (objclsTVData.PARTNER != "" && objclsTVData.DOCNUM != "" && objclsTVData.SHAREPER != "")
                            {
                                objEntityDetails.PartnerId = Convert.ToInt32(objclsTVData.PARTNER);
                                objEntityDetails.DocumentNo = objclsTVData.DOCNUM;
                                objEntityDetails.SharePerc = Convert.ToDecimal(objclsTVData.SHAREPER);
                                objEntityDetails.Corp_PartnerId = Convert.ToInt32(objclsTVData.DTLID);

                                objEntityTVDeatilsUPDATEList.Add(objEntityDetails);

                            }
                        }
                    }

                }

                string strCancldDtlId = "";
                string[] strarrCanccldtlIds = strCancldDtlId.Split(',');
                if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
                {
                    strCancldDtlId = hiddenCanclDtlId.Value;
                    strarrCanccldtlIds = strCancldDtlId.Split(',');

                }


                //Start:-For bank table
                List<clsEntityBankDtl> objEntityDetilsListBank = new List<clsEntityBankDtl>();
                if (hiddenTotalData.Value != "")
                {
                    jsonData = hiddenTotalData.Value;
                    c = jsonData.Replace("\"{", "\\{");
                    d = c.Replace("\\n", "\r\n");
                    g = d.Replace("\\", "");
                    h = g.Replace("}\"]", "}]");
                    i = h.Replace("}\",", "},");
                    List<clsWBData> objWBDataList = new List<clsWBData>();
                    //   UserData  data
                    objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(i);
                    foreach (clsWBData objclsWBData in objWBDataList)
                    {
                        clsEntityBankDtl objEntityDetails = new clsEntityBankDtl();
                        objEntityDetails.BankId = Convert.ToInt32(objclsWBData.BANKID);
                        objEntityDetails.Branch = objclsWBData.BRANCH;
                        objEntityDetails.IBAN = objclsWBData.IBAN;
                        objEntityDetilsListBank.Add(objEntityDetails);
                    }
                }

                //End:-For bank table

             //Fetch the count of corporate office name that existed in the table.
             string strCount = objBusinessLayerCorpOffice.CheckCorpNameUpdate(objEntityCorpOffice);
            
             //string strCRNcount = objBusinessLayerCorpOffice.CheckCRNnum(objEntityCorpOffice);
             //string strTINcount = objBusinessLayerCorpOffice.CheckTINnum(objEntityCorpOffice);
             //string strCCNcount = objBusinessLayerCorpOffice.CheckCCNnum(objEntityCorpOffice);
             //if (cbxSameOrg.Checked == true)
             //{
             //    strCRNcount = "0";
             //    strTINcount = "0";
             //    strCCNcount = "0";
             //}

             string strCodecount = objBusinessLayerCorpOffice.CheckCodenum(objEntityCorpOffice);
             if (strCount == "0"  && strCodecount == "0")
             {
                 objEntityCorpOffice.ApplicationDate = objCommon.textToDateTime(strDate);
                 objBusinessLayerCorpOffice.UpdateCorpOffice(objEntityCorpOffice, objEntityPermitAttchmntDeatilsList, objEntityInsurAttchmntDeatilsList, objEntityVhclAttchmntDeatilsList, objEntityPerDeleteAttchmntDeatilsList, objEntityInsDeleteAttchmntDeatilsList, objEntityVhclDeleteAttchmntDeatilsList, objEntityTVDeatilsINSERTList, objEntityTVDeatilsUPDATEList, strarrCanccldtlIds, objEntityDetilsListBank);

                 //if (hiddenUserImage.Value == "")

                 //{
                 //    string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                 //    string imageLocation = strImgPath + hiddenUserImage.Value;
                 //    if (File.Exists(MapPath(imageLocation)))
                 //    {
                 //        File.Delete(MapPath(imageLocation));
                 //    }
                 //}
                 
                 string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                 if (FileUploadProPic.HasFile)
                 {
                     FileUploadProPic.SaveAs(Server.MapPath(strImagePath) + objEntityCorpOffice.Icon);
                 }

                 if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                 {
                     if (HiddenAddProvision.Value == "1")
                     {
                         Response.Redirect("gen_Corp_Office.aspx?Id="+Request.QueryString["Id"]+"&InsUpd=Upd");
                     }
                     else
                     {
                         Response.Redirect("gen_Corp_OfficeList.aspx?InsUpd=Upd");
                     }
                 }
                 else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                 {
                     Response.Redirect("gen_Corp_OfficeList.aspx?InsUpd=Upd");
                 }
               
             }
             //else
             //{

             //    if (strCount != "0")
             //    {
             //        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
             //        txtCorpName.Focus();
             //    }

             //    else if (strCodecount != "0")
             //    {
             //        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
             //        txtCCN.Focus();

             //    }
             //}

         }
     }
     //Fetch the new datatable from businesslayer and set separately in each field. 
     public void View(string strCO_Id)
     {
         if (Session["CORPOFFICEID"] != null)
         {
             DropDownEmployeeDataStore();
             HiddenCorpChk.Value = "1";
         }
         else if (Session["CORPOFFICEID"] == null)
         {
             HiddenCorpChk.Value = "0";
             hiddenEmpDdlData.Value = "0";
         }
         BsnsTypeLoad();
         clsCommonLibrary objCommon = new clsCommonLibrary();
         hiddenView.Value = "View";

         btnAdd.Visible = false;
         btnAddClose.Visible = false;
         btnUpdate.Visible = false;
         btnUpdateClose.Visible = false;
         btnClear.Visible = false;

         btnAddF.Visible = false;
         btnAddCloseF.Visible = false;
         btnUpdateF.Visible = false;
         btnUpdateCloseF.Visible = false;
         btnClearF.Visible = false;
         clsEntityCorpOffice objEntCorpOffice = new clsEntityCorpOffice();
         objEntCorpOffice.CorpOfficeId = Convert.ToInt32(strCO_Id);
         DataTable dtCprpOffice = objBusinessLayerCorpOffice.ReadCorpOfficeById(objEntCorpOffice);
         //After fetch corporation office details in datatable,we need to differentiate.
         txtCorpName.Value = dtCprpOffice.Rows[0]["CORPRT_NAME"].ToString();
         hiddenOldName.Value = dtCprpOffice.Rows[0]["CORPRT_NAME"].ToString();
         CorpTypeLoad();
         if (dtCprpOffice.Rows[0]["CORPTYPE_STATUS"].ToString() == "1")
         {
             ddlOfficeTyp.Items.FindByText(dtCprpOffice.Rows[0]["CORPTYPE_NAME"].ToString()).Selected = true;
         }
         else
         {
             ListItem lst = new ListItem(dtCprpOffice.Rows[0]["CORPTYPE_NAME"].ToString(), dtCprpOffice.Rows[0]["CORPTYPE_ID"].ToString());
             ddlOfficeTyp.Items.Insert(1, lst);

            // SortDDL(ref this.ddlOfficeTyp);

             ddlOfficeTyp.Items.FindByText(dtCprpOffice.Rows[0]["CORPTYPE_NAME"].ToString()).Selected = true;
         }
         CountryLoad();

         //ie IF  COUNTRY IS ACTIVE
         if (dtCprpOffice.Rows[0]["CNTRY_STATUS"].ToString() == "1" && dtCprpOffice.Rows[0]["CNTRY_CNCL_USR_ID"].ToString() == "")
         {
             ddlCorpCountry.Items.FindByText(dtCprpOffice.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;

         }
         else
         {
             ListItem lst = new ListItem(dtCprpOffice.Rows[0]["CNTRY_NAME"].ToString(), dtCprpOffice.Rows[0]["CNTRY_ID"].ToString());
             ddlCorpCountry.Items.Insert(1, lst);

             SortDDL(ref this.ddlCorpCountry);

             ddlCorpCountry.Items.FindByText(dtCprpOffice.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
         }

         txtCorpAdd1.Value = dtCprpOffice.Rows[0]["CORPRT_ADDR1"].ToString();
         txtCorpAdd2.Value = dtCprpOffice.Rows[0]["CORPRT_ADDR2"].ToString();
         txtCorpAdd3.Value = dtCprpOffice.Rows[0]["CORPRT_ADDR3"].ToString();
         txtTinNumber.Value = dtCprpOffice.Rows[0]["CORPRT_TIN_NUMBER"].ToString();
         txtCinNumber.Value = dtCprpOffice.Rows[0]["CORPRT_CIN_NUMBER"].ToString();
         txtCustCareNumber.Value = dtCprpOffice.Rows[0]["CORPRT_CCARE_NUMBER"].ToString();
         txtShortName.Value = dtCprpOffice.Rows[0]["CORPRT_NAME_SHORT"].ToString();
         txtShortAddress.Value = dtCprpOffice.Rows[0]["CORPRT_ADDR_SHORT"].ToString();
         txtCorpZip.Value = dtCprpOffice.Rows[0]["CORPRT_ZIP"].ToString();
         txtCorpWebsite.Value = dtCprpOffice.Rows[0]["CORPRT_WEBSITE"].ToString();
         txtCorpMobile.Value = dtCprpOffice.Rows[0]["CORPRT_MOBILE"].ToString();
         // txtCorpPhone.Text = dtCprpOffice.Rows[0]["CORPRT_PHONE"].ToString();
         txtCorpEmail.Value = dtCprpOffice.Rows[0]["CORPRT_EMAIL"].ToString();
         txtDate.Value = dtCprpOffice.Rows[0]["CORPRT_APP_DATE"].ToString();
         int intMonth = Convert.ToInt32(dtCprpOffice.Rows[0]["CORPRT_FISCAL_MONTH"]);
         objEntCorpOffice.CountryId = Convert.ToInt32(dtCprpOffice.Rows[0]["CNTRY_ID"]);
         //Check if there is a state id selected or not.
         if (dtCprpOffice.Rows[0]["STATE_ID"].ToString() != "")
         {
             HiddenFieldState.Value = dtCprpOffice.Rows[0]["STATE_ID"].ToString();
             ddlCorpState.Text=dtCprpOffice.Rows[0]["STATE_NAME"].ToString();
             if (dtCprpOffice.Rows[0]["CITY_ID"].ToString() != "")
             {
                 HiddenFieldCity.Value=dtCprpOffice.Rows[0]["CITY_ID"].ToString();
                 ddlCity.Text = dtCprpOffice.Rows[0]["CITY_NAME"].ToString();
             }
             hiddenCurrentDate.Value = dtCprpOffice.Rows[0]["INS_DATE"].ToString();
         }
         int intCorpStatus = Convert.ToInt32(dtCprpOffice.Rows[0]["CORPRT_STATUS"]);
         if (intCorpStatus == 1)
         {
             cbxStatus.Checked = true;
         }
         else
         {
             cbxStatus.Checked = false;
         }
         //Creating objects for common library
         clsCommonLibrary objCmnLbry = new clsCommonLibrary();
         int intFiscalMonth = Convert.ToInt32(dtCprpOffice.Rows[0]["CORPRT_FISCAL_MONTH"]);
         string strFiscalMonth = objCmnLbry.arrMonth[intFiscalMonth].ToString();
         ddlFiscalMonth.Items.FindByText(strFiscalMonth).Selected = true;

         //start new code
         txtCode.Value = dtCprpOffice.Rows[0]["CORPRT_CODE"].ToString();
         hiddenOldCode.Value = dtCprpOffice.Rows[0]["CORPRT_CODE"].ToString();

         txtFax.Value = dtCprpOffice.Rows[0]["CORPRT_FAX"].ToString();
         txtEnqMail.Value = dtCprpOffice.Rows[0]["CORPRT_ENQ_EMAIL"].ToString();
         txtEnqMail.Value = dtCprpOffice.Rows[0]["CORPRT_ENQ_EMAIL"].ToString();
         txtMailStrg.Value = dtCprpOffice.Rows[0]["CORPRT_STRG_EMAIL"].ToString();
         txtCRN.Value = dtCprpOffice.Rows[0]["CORPRT_CMRCLRGT_NUM"].ToString();
         txtTIN.Value = dtCprpOffice.Rows[0]["CORPRT_TAXCRD_NUM"].ToString();
         txtCCN.Value = dtCprpOffice.Rows[0]["CORPRT_CMPTRCRD_NUM"].ToString();

         txtCRNExpDate.Value = dtCprpOffice.Rows[0]["CRNEXP"].ToString();
         if (dtCprpOffice.Rows[0]["CORPRT_CHECKIN"].ToString() != "")
         {
             DateTime dtchkin = Convert.ToDateTime(dtCprpOffice.Rows[0]["CORPRT_CHECKIN"].ToString());
             txtChkIn.Value = dtchkin.ToString("hh:mm tt");
         }
         if (dtCprpOffice.Rows[0]["CORPRT_CHECKOUT"].ToString() != "")
         {
             DateTime dtchkout = Convert.ToDateTime(dtCprpOffice.Rows[0]["CORPRT_CHECKOUT"].ToString());
             txtChkOut.Value = dtchkout.ToString("hh:mm tt");
         }
         if (dtCprpOffice.Rows[0]["CRNISS"].ToString() != "01-01-0001")
         {

             txtCRNIssDate.Value = dtCprpOffice.Rows[0]["CRNISS"].ToString();
         }
         txtTINExp.Value = dtCprpOffice.Rows[0]["TINEXP"].ToString();
         if (dtCprpOffice.Rows[0]["TINISS"].ToString() != "01-01-0001")
         {

             txtTINIss.Value = dtCprpOffice.Rows[0]["TINISS"].ToString();
         }


         txtCCNExp.Value = dtCprpOffice.Rows[0]["CCNEXP"].ToString();
         if (dtCprpOffice.Rows[0]["CCNISS"].ToString() != "01-01-0001")
         {

             txtCCNIss.Value = dtCprpOffice.Rows[0]["CCNISS"].ToString();
         }


         int intRmvStrg = Convert.ToInt32(dtCprpOffice.Rows[0]["CORPRT_RMV_STRGMAIL"]);
         if (intRmvStrg == 1)
         {
             cbxRmveStrg.Checked = true;
         }
         else
         {
             cbxRmveStrg.Checked = false;
         }




         if (dtCprpOffice.Rows[0]["CORPRT_PRNT_ID"].ToString() != "" && dtCprpOffice.Rows[0]["CORPRT_PRNT_ID"].ToString() != null)
         {
             objEntCorpOffice.CorpOfficeId = Convert.ToInt32(dtCprpOffice.Rows[0]["CORPRT_PRNT_ID"].ToString());
             DataTable dtCprpOfficesTS = objBusinessLayerCorpOffice.ReadCorpSts(objEntCorpOffice);

             if (ddlParent.Items.FindByValue(dtCprpOffice.Rows[0]["CORPRT_PRNT_ID"].ToString()) != null)
             {
             ddlParent.Items.FindByValue(dtCprpOffice.Rows[0]["CORPRT_PRNT_ID"].ToString()).Selected = true;
             }


             else
             {
                 ListItem lst = new ListItem(dtCprpOfficesTS.Rows[0]["CORPRT_NAME"].ToString(), dtCprpOfficesTS.Rows[0]["CORPRT_ID"].ToString());
                 ddlParent.Items.Insert(1, lst);

                 //SortDDL(ref this.ddlParent);

                 ddlParent.Items.FindByText(dtCprpOfficesTS.Rows[0]["CORPRT_NAME"].ToString()).Selected = true;
             }
         }
         HiddenField4.Value = dtCprpOffice.Rows[0]["CORPRT_ICON"].ToString();
         HiddenField5.Value = dtCprpOffice.Rows[0]["CORPRT_ACTICON"].ToString();


         if (dtCprpOffice.Rows[0]["BSNSTYPE_STATUS"].ToString() == "1")
         {
             ddlBsnsTyp.Items.FindByValue(dtCprpOffice.Rows[0]["BSNSTYPE_ID"].ToString()).Selected = true;
         }
         else
         {
             ListItem lst = new ListItem(dtCprpOffice.Rows[0]["BSNSTYPE_NAME"].ToString(), dtCprpOffice.Rows[0]["BSNSTYPE_ID"].ToString());
             ddlBsnsTyp.Items.Insert(1, lst);

             //SortDDL(ref this.ddlBsnsTyp);

             ddlBsnsTyp.Items.FindByText(dtCprpOffice.Rows[0]["BSNSTYPE_NAME"].ToString()).Selected = true;
         }


         if (dtCprpOffice.Rows[0]["SHARETYPE_STATUS"].ToString() == "1")
         {
             ddlShareTyp.Items.FindByValue(dtCprpOffice.Rows[0]["SHARETYPE_ID"].ToString()).Selected = true;
         }
         else if (dtCprpOffice.Rows[0]["SHARETYPE_STATUS"].ToString() == "0")
         {
             ListItem lst = new ListItem(dtCprpOffice.Rows[0]["SHARETYPE_NAME"].ToString(), dtCprpOffice.Rows[0]["SHARETYPE_ID"].ToString());
             ddlShareTyp.Items.Insert(1, lst);

             //SortDDL(ref this.ddlShareTyp);
             ddlShareTyp.Items.FindByText(dtCprpOffice.Rows[0]["SHARETYPE_NAME"].ToString()).Selected = true;
         }




         //end new code
         //icon
         hiddenUserImage.Value = dtCprpOffice.Rows[0]["CORPRT_ICON"].ToString();
         hiddenImageName.Value = dtCprpOffice.Rows[0]["CORPRT_ACTICON"].ToString();
         if (hiddenUserImage.Value != null && hiddenUserImage.Value != "")
         {
             //    divImageEdit.Visible = true;
             string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + hiddenImageName.Value;
             // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
             string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy\" >Click to View Image Uploaded</a>";
             strImage += " <div class=\"lightbox-target\" id=\"goofy\">";
             strImage += " <img src=\"" + strImagePath + "\"/>";
             strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
             strImage += "</div>";
             divImageDisplay.InnerHtml = strImage;

         }
         //start for displaying attached files


         DataTable dtPAttchmnt = new DataTable();
         dtPAttchmnt.Columns.Add("TransDtlId", typeof(int));
         dtPAttchmnt.Columns.Add("FileName", typeof(string));
         dtPAttchmnt.Columns.Add("ActualFileName", typeof(string));
         dtPAttchmnt.Columns.Add("Description", typeof(string));
         DataTable dtPermitAttchmnt = new DataTable();
         dtPermitAttchmnt = objBusinessLayerCorpOffice.ReadCRNFiles(objEntCorpOffice);
         hiddenFilePath.Value = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
         if (dtPermitAttchmnt.Rows.Count > 0)
         {
             for (int intcnt = 0; intcnt < dtPermitAttchmnt.Rows.Count; intcnt++)
             {
                 DataRow drAttchPermt = dtPAttchmnt.NewRow();
                 drAttchPermt["TransDtlId"] = dtPermitAttchmnt.Rows[intcnt][0].ToString();
                 drAttchPermt["FileName"] = dtPermitAttchmnt.Rows[intcnt][1].ToString();
                 drAttchPermt["ActualFileName"] = dtPermitAttchmnt.Rows[intcnt][2].ToString();
                 drAttchPermt["Description"] = dtPermitAttchmnt.Rows[intcnt][4].ToString();
                 dtPAttchmnt.Rows.Add(drAttchPermt);
                 hiddenAttchmntPrmtSlNumber.Value = dtPermitAttchmnt.Rows[intcnt][3].ToString();
             }

             string strJson = DataTableToJSONWithJavaScriptSerializer(dtPAttchmnt);
             hiddenEditPrmtAttchmnt.Value = strJson;
         }

         DataTable dtIAttchmnt = new DataTable();
         dtIAttchmnt.Columns.Add("TransDtlId", typeof(int));
         dtIAttchmnt.Columns.Add("FileName", typeof(string));
         dtIAttchmnt.Columns.Add("ActualFileName", typeof(string));
         dtIAttchmnt.Columns.Add("Description", typeof(string));

         DataTable dtInsurAttchmnt = new DataTable();
         dtInsurAttchmnt = objBusinessLayerCorpOffice.ReadTINFiles(objEntCorpOffice);
         if (dtInsurAttchmnt.Rows.Count > 0)
         {
             for (int intcnt = 0; intcnt < dtInsurAttchmnt.Rows.Count; intcnt++)
             {
                 DataRow drAttchInsur = dtIAttchmnt.NewRow();
                 drAttchInsur["TransDtlId"] = dtInsurAttchmnt.Rows[intcnt][0].ToString();
                 drAttchInsur["FileName"] = dtInsurAttchmnt.Rows[intcnt][1].ToString();
                 drAttchInsur["ActualFileName"] = dtInsurAttchmnt.Rows[intcnt][2].ToString();
                 drAttchInsur["Description"] = dtInsurAttchmnt.Rows[intcnt][4].ToString();
                 dtIAttchmnt.Rows.Add(drAttchInsur);
                 hiddenAttchmntInsurSlNumber.Value = dtInsurAttchmnt.Rows[intcnt][3].ToString();
             }

             string strJson = DataTableToJSONWithJavaScriptSerializer(dtIAttchmnt);
             hiddenEditInsurAttchmnt.Value = strJson;
         }
         DataTable dtVAttchmnt = new DataTable();
         dtVAttchmnt.Columns.Add("TransDtlId", typeof(int));
         dtVAttchmnt.Columns.Add("FileName", typeof(string));
         dtVAttchmnt.Columns.Add("ActualFileName", typeof(string));
         dtVAttchmnt.Columns.Add("Description", typeof(string));
         DataTable dtVhclAttchmnt = new DataTable();
         dtVhclAttchmnt = objBusinessLayerCorpOffice.ReadCCNFiles(objEntCorpOffice);
         if (dtVhclAttchmnt.Rows.Count > 0)
         {
             for (int intcnt = 0; intcnt < dtVhclAttchmnt.Rows.Count; intcnt++)
             {
                 DataRow drAttchVhcl = dtVAttchmnt.NewRow();
                 drAttchVhcl["TransDtlId"] = dtVhclAttchmnt.Rows[intcnt][0].ToString();
                 drAttchVhcl["FileName"] = dtVhclAttchmnt.Rows[intcnt][1].ToString();
                 drAttchVhcl["ActualFileName"] = dtVhclAttchmnt.Rows[intcnt][2].ToString();
                 drAttchVhcl["Description"] = dtVhclAttchmnt.Rows[intcnt][4].ToString();
                 dtVAttchmnt.Rows.Add(drAttchVhcl);
                 hiddenAttchmntVhclSlNumber.Value = dtVhclAttchmnt.Rows[intcnt][3].ToString();
             }

             string strJson = DataTableToJSONWithJavaScriptSerializer(dtVAttchmnt);
             hiddenEditVhclAttchmnt.Value = strJson;


         }
         //end for displaying attached files

         //start partnership table display
         DataTable dtDetail = new DataTable();
         dtDetail.Columns.Add("TransId", typeof(int));
         dtDetail.Columns.Add("TransDtlId", typeof(int));
         dtDetail.Columns.Add("PartnerId", typeof(int));
         dtDetail.Columns.Add("PartnerName", typeof(string));
         dtDetail.Columns.Add("DocumentNo", typeof(string));
         dtDetail.Columns.Add("SharePer", typeof(decimal));
         dtDetail.Columns.Add("Status", typeof(int));

         DataTable dt = new DataTable();
         dt = objBusinessLayerCorpOffice.ReadPartnerDetails(objEntCorpOffice);
         for (int intcnt = 0; intcnt < dt.Rows.Count; intcnt++)
         {
             DataRow drDtl = dtDetail.NewRow();
             drDtl["TransId"] = Convert.ToInt32(dt.Rows[intcnt]["CORPRTPTNR_ID"].ToString());
             drDtl["TransDtlId"] = Convert.ToInt32(dt.Rows[intcnt]["CORPRTPTNR_ID"].ToString());
             drDtl["PartnerId"] = dt.Rows[intcnt]["PRTNR_ID"].ToString();
             drDtl["PartnerName"] = dt.Rows[intcnt]["CORPRTPTNR_NAME"].ToString();
             drDtl["DocumentNo"] = dt.Rows[intcnt]["CORPRTPTNR_DCMNT_NUM"].ToString();
             drDtl["SharePer"] = Convert.ToDecimal(dt.Rows[intcnt]["CORPRTPTNR_PERCNT"].ToString());
             drDtl["Status"] = Convert.ToInt32(dt.Rows[intcnt]["PRTNR_STATUS"].ToString());
             dtDetail.Rows.Add(drDtl);

         }

         string strJsonF = DataTableToJSONWithJavaScriptSerializer(dtDetail);
         HiddenField3.Value = strJsonF;

         //stop partnership table display

         //start Bank Details table display
         DataTable dtDetails = new DataTable();
         dtDetails.Columns.Add("TransId", typeof(int));
         dtDetails.Columns.Add("TransDtlId", typeof(int));
         dtDetails.Columns.Add("BankId", typeof(int));
         dtDetails.Columns.Add("Branch", typeof(string));
         dtDetails.Columns.Add("IBAN", typeof(string));
         dtDetails.Columns.Add("BankName", typeof(string));
         dtDetails.Columns.Add("BankStatus", typeof(int));

         DataTable dtBankDtl = new DataTable();
         dtBankDtl = objBusinessLayerCorpOffice.ReadBankDtlsOfCorp(objEntCorpOffice);
         for (int intcnt = 0; intcnt < dtBankDtl.Rows.Count; intcnt++)
         {
             DataRow drDtl = dtDetails.NewRow();
             drDtl["TransId"] = Convert.ToInt32(dtBankDtl.Rows[intcnt]["CRBNKDTLID"].ToString());
             drDtl["TransDtlId"] = Convert.ToInt32(dtBankDtl.Rows[intcnt]["CRBNKDTLID"].ToString());
             drDtl["BankId"] = Convert.ToInt32(dtBankDtl.Rows[intcnt]["BANK_ID"].ToString());
             drDtl["Branch"] = dtBankDtl.Rows[intcnt]["BRANCH_NAME"].ToString();
             drDtl["IBAN"] = dtBankDtl.Rows[intcnt]["IBAN"].ToString();
             drDtl["BankName"] = dtBankDtl.Rows[intcnt]["BANK_NAME"].ToString();
             drDtl["BankStatus"] = drDtl["BankStatus"] = Convert.ToInt32(dtBankDtl.Rows[intcnt]["BANK_STATUS"].ToString());
             dtDetails.Rows.Add(drDtl);

         }

         string strJsonFf = DataTableToJSONWithJavaScriptSerializer(dtDetails);
         HiddenFieldEditBankData.Value = strJsonFf;

         //stop Bank Details table display


         FileUploadProPic.Enabled = false;
         divImgWrap.Visible = false;

         ddlOfficeTyp.Disabled = true;
         txtCorpName.Disabled = true;
         txtCorpAdd1.Disabled = true;
         txtCorpAdd2.Disabled = true;
         txtCorpAdd3.Disabled = true;

         ddlCorpCountry.Enabled = false;
         ddlCorpState.Enabled = false;
         ddlCity.Enabled = false;
         txtDate.Disabled = true;
         txtCustCareNumber.Disabled = true;
         txtShortName.Disabled = true;
         txtShortAddress.Disabled = true;
         txtCorpZip.Disabled = true;
       //  txtCorpPhone.Enabled = false;
         txtCorpMobile.Disabled = true;
         txtCorpWebsite.Disabled = true;
         txtCorpEmail.Disabled = true;
         ddlFiscalMonth.Enabled = false;
         txtTinNumber.Disabled = true;
         txtCinNumber.Disabled = true;
         cbxStatus.Disabled = true;
         //start new code
         ddlBsnsTyp.Disabled = true;
         ddlShareTyp.Disabled = true;
         ddlParent.Disabled = true;
         cbxRmveStrg.Disabled = true;
         cbxSameOrg.Disabled = true;
         txtCode.Disabled = true;
         txtFax.Disabled = true;
         txtEnqMail.Disabled = true;
         txtMailStrg.Disabled = true;
         txtCRN.Disabled = true;
         txtCRNExpDate.Disabled = true;
         txtCRNIssDate.Disabled = true;
         txtTIN.Disabled = true;
         txtTINExp.Disabled = true;
         txtTINIss.Disabled = true;
         txtCCN.Disabled = true;
         txtCCNExp.Disabled = true;
         txtCCNIss.Disabled = true;
         CheckBox2.Disabled = true;
         txtChkIn.Disabled = true;
         txtChkOut.Disabled = true;
         //imgStart.Disabled = true;
         //imgCCNiss.Disabled = true;
         //imgCRNiss.Disabled = true;
         //imgTINiss.Disabled = true;
         //imgCCNexp.Disabled = true;
         //imgCRNexp.Disabled = true;
         //imgTINexp.Disabled = true;
         //end new code
     }
     //Fetching the table from business layer and assign them in our fields.
     public void Update(string strCO_Id)
     {
         if (Session["CORPOFFICEID"] != null)
         {
             DropDownEmployeeDataStore();
             HiddenCorpChk.Value = "1";
         }
         else if (Session["CORPOFFICEID"] == null)
         {
             HiddenCorpChk.Value = "0";
             hiddenEmpDdlData.Value = "0";
         }
         BsnsTypeLoad();

         hiddenEdit.Value = "Edit";
         clsCommonLibrary objCommon = new clsCommonLibrary();
         btnAdd.Visible = false;
         btnAddClose.Visible = false;
         btnAddF.Visible = false;
         btnAddCloseF.Visible = false;
         if (HiddenAddProvision.Value != "1")
         {
             btnUpdate.Visible = false;
             btnUpdateF.Visible = false;
         }
         else
         {
             btnUpdate.Visible = true;
             btnUpdateF.Visible = true;
         }
         btnUpdateClose.Visible = true;
         btnClear.Visible = false;

         btnUpdateCloseF.Visible = true;
         btnClearF.Visible = false;
         clsEntityCorpOffice objEntCorpOffice = new clsEntityCorpOffice();
         objEntCorpOffice.CorpOfficeId = Convert.ToInt32(strCO_Id);
         DataTable dtCprpOffice = objBusinessLayerCorpOffice.ReadCorpOfficeById(objEntCorpOffice);
         //After fetch corporation office details in datatable,we need to differentiate.
         txtCorpName.Value = dtCprpOffice.Rows[0]["CORPRT_NAME"].ToString();
         hiddenOldName.Value = dtCprpOffice.Rows[0]["CORPRT_NAME"].ToString();

         CorpTypeLoad();
         if (dtCprpOffice.Rows[0]["CORPTYPE_STATUS"].ToString() == "1")
         {
             ddlOfficeTyp.Items.FindByText(dtCprpOffice.Rows[0]["CORPTYPE_NAME"].ToString()).Selected = true;
         }
         else
         {
             ListItem lst = new ListItem(dtCprpOffice.Rows[0]["CORPTYPE_NAME"].ToString(), dtCprpOffice.Rows[0]["CORPTYPE_ID"].ToString());
             ddlOfficeTyp.Items.Insert(1, lst);

            // SortDDL(ref this.ddlOfficeTyp);

             ddlOfficeTyp.Items.FindByText(dtCprpOffice.Rows[0]["CORPTYPE_NAME"].ToString()).Selected = true;
         }
         CountryLoad();

         //ie IF  COUNTRY IS ACTIVE
         if (dtCprpOffice.Rows[0]["CNTRY_STATUS"].ToString() == "1" && dtCprpOffice.Rows[0]["CNTRY_CNCL_USR_ID"].ToString() == "")
         {
             ddlCorpCountry.Items.FindByText(dtCprpOffice.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;

         }
         else
         {
             ListItem lst = new ListItem(dtCprpOffice.Rows[0]["CNTRY_NAME"].ToString(), dtCprpOffice.Rows[0]["CNTRY_ID"].ToString());
             ddlCorpCountry.Items.Insert(1, lst);

             SortDDL(ref this.ddlCorpCountry);

             ddlCorpCountry.Items.FindByText(dtCprpOffice.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
         }

         txtCorpAdd1.Value = dtCprpOffice.Rows[0]["CORPRT_ADDR1"].ToString();
         txtCorpAdd2.Value = dtCprpOffice.Rows[0]["CORPRT_ADDR2"].ToString();
         txtCorpAdd3.Value = dtCprpOffice.Rows[0]["CORPRT_ADDR3"].ToString();
         txtTinNumber.Value = dtCprpOffice.Rows[0]["CORPRT_TIN_NUMBER"].ToString();
         txtCinNumber.Value = dtCprpOffice.Rows[0]["CORPRT_CIN_NUMBER"].ToString();
         txtCustCareNumber.Value = dtCprpOffice.Rows[0]["CORPRT_CCARE_NUMBER"].ToString();
         txtShortName.Value = dtCprpOffice.Rows[0]["CORPRT_NAME_SHORT"].ToString();
         txtShortAddress.Value = dtCprpOffice.Rows[0]["CORPRT_ADDR_SHORT"].ToString();
         txtCorpZip.Value = dtCprpOffice.Rows[0]["CORPRT_ZIP"].ToString();
         txtCorpWebsite.Value = dtCprpOffice.Rows[0]["CORPRT_WEBSITE"].ToString();
         txtCorpMobile.Value = dtCprpOffice.Rows[0]["CORPRT_MOBILE"].ToString();
        // txtCorpPhone.Text = dtCprpOffice.Rows[0]["CORPRT_PHONE"].ToString();
         txtCorpEmail.Value = dtCprpOffice.Rows[0]["CORPRT_EMAIL"].ToString();
         txtDate.Value = dtCprpOffice.Rows[0]["CORPRT_APP_DATE"].ToString();
         int intMonth = Convert.ToInt32(dtCprpOffice.Rows[0]["CORPRT_FISCAL_MONTH"]);
         objEntCorpOffice.CountryId = Convert.ToInt32(dtCprpOffice.Rows[0]["CNTRY_ID"]);
         //Check if there is a state id selected or not.
         if (dtCprpOffice.Rows[0]["STATE_ID"].ToString() != "")
         {
             HiddenFieldState.Value = dtCprpOffice.Rows[0]["STATE_ID"].ToString();
             ddlCorpState.Text = dtCprpOffice.Rows[0]["STATE_NAME"].ToString();
             if (dtCprpOffice.Rows[0]["CITY_ID"].ToString() != "")
             {
                 HiddenFieldCity.Value = dtCprpOffice.Rows[0]["CITY_ID"].ToString();
                 ddlCity.Text = dtCprpOffice.Rows[0]["CITY_NAME"].ToString();
             }
             hiddenCurrentDate.Value = dtCprpOffice.Rows[0]["INS_DATE"].ToString();
         }
         int intCorpStatus = Convert.ToInt32(dtCprpOffice.Rows[0]["CORPRT_STATUS"]);
         if (intCorpStatus == 1)
         {
             cbxStatus.Checked = true;
         }
         else
         {
             cbxStatus.Checked = false;
         }
         //Creating objects for common library
         clsCommonLibrary objCmnLbry = new clsCommonLibrary();
         int intFiscalMonth = Convert.ToInt32(dtCprpOffice.Rows[0]["CORPRT_FISCAL_MONTH"]);
         string strFiscalMonth = objCmnLbry.arrMonth[intFiscalMonth].ToString();
         ddlFiscalMonth.Items.FindByText(strFiscalMonth).Selected = true;

         //start new code
         txtCode.Value = dtCprpOffice.Rows[0]["CORPRT_CODE"].ToString();
         hiddenOldCode.Value = dtCprpOffice.Rows[0]["CORPRT_CODE"].ToString();

         txtFax.Value = dtCprpOffice.Rows[0]["CORPRT_FAX"].ToString();
         txtEnqMail.Value = dtCprpOffice.Rows[0]["CORPRT_ENQ_EMAIL"].ToString();
         txtEnqMail.Value = dtCprpOffice.Rows[0]["CORPRT_ENQ_EMAIL"].ToString();
         txtMailStrg.Value = dtCprpOffice.Rows[0]["CORPRT_STRG_EMAIL"].ToString();
         txtCRN.Value = dtCprpOffice.Rows[0]["CORPRT_CMRCLRGT_NUM"].ToString();
         txtTIN.Value = dtCprpOffice.Rows[0]["CORPRT_TAXCRD_NUM"].ToString();
         txtCCN.Value = dtCprpOffice.Rows[0]["CORPRT_CMPTRCRD_NUM"].ToString();

         txtCRNExpDate.Value = dtCprpOffice.Rows[0]["CRNEXP"].ToString();
         if (dtCprpOffice.Rows[0]["CRNISS"].ToString() != "01-01-0001")
         {

             txtCRNIssDate.Value = dtCprpOffice.Rows[0]["CRNISS"].ToString();
         }
         txtTINExp.Value = dtCprpOffice.Rows[0]["TINEXP"].ToString();
         if (dtCprpOffice.Rows[0]["TINISS"].ToString() != "01-01-0001")
         {

             txtTINIss.Value = dtCprpOffice.Rows[0]["TINISS"].ToString();
         }


         txtCCNExp.Value = dtCprpOffice.Rows[0]["CCNEXP"].ToString();
         if (dtCprpOffice.Rows[0]["CCNISS"].ToString() != "01-01-0001")
         {

             txtCCNIss.Value = dtCprpOffice.Rows[0]["CCNISS"].ToString();
         }
         if (dtCprpOffice.Rows[0]["CORPRT_CHECKIN"].ToString() != "")
         {
             DateTime dtchkin = Convert.ToDateTime(dtCprpOffice.Rows[0]["CORPRT_CHECKIN"].ToString());
             txtChkIn.Value = dtchkin.ToString("hh:mm tt");
         }
         if (dtCprpOffice.Rows[0]["CORPRT_CHECKOUT"].ToString() != "")
         {
             DateTime dtchkout = Convert.ToDateTime(dtCprpOffice.Rows[0]["CORPRT_CHECKOUT"].ToString());
             txtChkOut.Value = dtchkout.ToString("hh:mm tt");
         }
         int intRmvStrg = Convert.ToInt32(dtCprpOffice.Rows[0]["CORPRT_RMV_STRGMAIL"]);
         if (intRmvStrg == 1)
         {
             cbxRmveStrg.Checked = true;
         }
         else
         {
             cbxRmveStrg.Checked = false;
         }


     
         if (dtCprpOffice.Rows[0]["CORPRT_PRNT_ID"].ToString() != "" && dtCprpOffice.Rows[0]["CORPRT_PRNT_ID"].ToString() != null)
         {
             clsEntityCorpOffice objEntCorpOffice1 = new clsEntityCorpOffice();
             objEntCorpOffice1.CorpOfficeId = Convert.ToInt32(dtCprpOffice.Rows[0]["CORPRT_PRNT_ID"].ToString());
             DataTable dtCprpOfficesTS = objBusinessLayerCorpOffice.ReadCorpSts(objEntCorpOffice1);

             if (ddlParent.Items.FindByValue(dtCprpOffice.Rows[0]["CORPRT_PRNT_ID"].ToString()) != null)
             {
                 ddlParent.Items.FindByValue(dtCprpOffice.Rows[0]["CORPRT_PRNT_ID"].ToString()).Selected = true;
             }


             else
             {
                 ListItem lst = new ListItem(dtCprpOfficesTS.Rows[0]["CORPRT_NAME"].ToString(), dtCprpOfficesTS.Rows[0]["CORPRT_ID"].ToString());
                 ddlParent.Items.Insert(1, lst);

                 //SortDDL(ref this.ddlParent);

                 ddlParent.Items.FindByText(dtCprpOfficesTS.Rows[0]["CORPRT_NAME"].ToString()).Selected = true;
             }
         }
            HiddenField4.Value = dtCprpOffice.Rows[0]["CORPRT_ICON"].ToString();
            HiddenField5.Value = dtCprpOffice.Rows[0]["CORPRT_ACTICON"].ToString();


          if (dtCprpOffice.Rows[0]["BSNSTYPE_STATUS"].ToString() == "1")
            {
                ddlBsnsTyp.Items.FindByValue(dtCprpOffice.Rows[0]["BSNSTYPE_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lst = new ListItem(dtCprpOffice.Rows[0]["BSNSTYPE_NAME"].ToString(), dtCprpOffice.Rows[0]["BSNSTYPE_ID"].ToString());
                ddlBsnsTyp.Items.Insert(1, lst);

                //SortDDL(ref this.ddlBsnsTyp);

                ddlBsnsTyp.Items.FindByText(dtCprpOffice.Rows[0]["BSNSTYPE_NAME"].ToString()).Selected = true;
            }


            if (dtCprpOffice.Rows[0]["SHARETYPE_STATUS"].ToString() == "1")
            {
                ddlShareTyp.Items.FindByValue(dtCprpOffice.Rows[0]["SHARETYPE_ID"].ToString()).Selected = true;
            }
            else if (dtCprpOffice.Rows[0]["SHARETYPE_STATUS"].ToString() == "0")
            {
                ListItem lst = new ListItem(dtCprpOffice.Rows[0]["SHARETYPE_NAME"].ToString(), dtCprpOffice.Rows[0]["SHARETYPE_ID"].ToString());
                    ddlShareTyp.Items.Insert(1, lst);
                   // ddlShareTyp.ClearSelection();
                   // SortDDL(ref this.ddlShareTyp);

                    ddlShareTyp.Items.FindByText(dtCprpOffice.Rows[0]["SHARETYPE_NAME"].ToString()).Selected = true;
            }
       



        //end new code
         //icon
            hiddenUserImage.Value = dtCprpOffice.Rows[0]["CORPRT_ICON"].ToString();
            hiddenImageName.Value = dtCprpOffice.Rows[0]["CORPRT_ACTICON"].ToString();
            if (hiddenUserImage.Value != null && hiddenUserImage.Value != "")
            {
                //    divImageEdit.Visible = true;
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + hiddenUserImage.Value;
                // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
                string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy\" >Click to View Image Uploaded</a>";
                strImage += " <div class=\"lightbox-target\" id=\"goofy\">";
                strImage += " <img src=\"" + strImagePath + "\"/>";
                strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                strImage += "</div>";
                divImageDisplay.InnerHtml = strImage;

            }

           //start for displaying attached files

          
           DataTable dtPAttchmnt = new DataTable();
           dtPAttchmnt.Columns.Add("TransDtlId", typeof(int));
           dtPAttchmnt.Columns.Add("FileName", typeof(string));
           dtPAttchmnt.Columns.Add("ActualFileName", typeof(string));
           dtPAttchmnt.Columns.Add("Description", typeof(string));
           DataTable dtPermitAttchmnt = new DataTable();
           dtPermitAttchmnt = objBusinessLayerCorpOffice.ReadCRNFiles(objEntCorpOffice);
           hiddenFilePath.Value = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
           if (dtPermitAttchmnt.Rows.Count > 0)
           {
               for (int intcnt = 0; intcnt < dtPermitAttchmnt.Rows.Count; intcnt++)
               {
                   DataRow drAttchPermt = dtPAttchmnt.NewRow();
                   drAttchPermt["TransDtlId"] = dtPermitAttchmnt.Rows[intcnt][0].ToString();
                   drAttchPermt["FileName"] = dtPermitAttchmnt.Rows[intcnt][1].ToString();
                   drAttchPermt["ActualFileName"] = dtPermitAttchmnt.Rows[intcnt][2].ToString();
                   drAttchPermt["Description"] = dtPermitAttchmnt.Rows[intcnt][4].ToString();
                   dtPAttchmnt.Rows.Add(drAttchPermt);
                   hiddenAttchmntPrmtSlNumber.Value = dtPermitAttchmnt.Rows[intcnt][3].ToString();
               }

               string strJson = DataTableToJSONWithJavaScriptSerializer(dtPAttchmnt);
               hiddenEditPrmtAttchmnt.Value = strJson;
           }

           DataTable dtIAttchmnt = new DataTable();
           dtIAttchmnt.Columns.Add("TransDtlId", typeof(int));
           dtIAttchmnt.Columns.Add("FileName", typeof(string));
           dtIAttchmnt.Columns.Add("ActualFileName", typeof(string));
           dtIAttchmnt.Columns.Add("Description", typeof(string));

           DataTable dtInsurAttchmnt = new DataTable();
           dtInsurAttchmnt = objBusinessLayerCorpOffice.ReadTINFiles(objEntCorpOffice);
           if (dtInsurAttchmnt.Rows.Count > 0)
           {
               for (int intcnt = 0; intcnt < dtInsurAttchmnt.Rows.Count; intcnt++)
               {
                   DataRow drAttchInsur = dtIAttchmnt.NewRow();
                   drAttchInsur["TransDtlId"] = dtInsurAttchmnt.Rows[intcnt][0].ToString();
                   drAttchInsur["FileName"] = dtInsurAttchmnt.Rows[intcnt][1].ToString();
                   drAttchInsur["ActualFileName"] = dtInsurAttchmnt.Rows[intcnt][2].ToString();
                   drAttchInsur["Description"] = dtInsurAttchmnt.Rows[intcnt][4].ToString();
                   dtIAttchmnt.Rows.Add(drAttchInsur);
                   hiddenAttchmntInsurSlNumber.Value = dtInsurAttchmnt.Rows[intcnt][3].ToString();
               }

               string strJson = DataTableToJSONWithJavaScriptSerializer(dtIAttchmnt);
               hiddenEditInsurAttchmnt.Value = strJson;
           }
           DataTable dtVAttchmnt = new DataTable();
           dtVAttchmnt.Columns.Add("TransDtlId", typeof(int));
           dtVAttchmnt.Columns.Add("FileName", typeof(string));
           dtVAttchmnt.Columns.Add("ActualFileName", typeof(string));
           dtVAttchmnt.Columns.Add("Description", typeof(string));
           DataTable dtVhclAttchmnt = new DataTable();
           dtVhclAttchmnt = objBusinessLayerCorpOffice.ReadCCNFiles(objEntCorpOffice);
           if (dtVhclAttchmnt.Rows.Count > 0)
           {
               for (int intcnt = 0; intcnt < dtVhclAttchmnt.Rows.Count; intcnt++)
               {
                   DataRow drAttchVhcl = dtVAttchmnt.NewRow();
                   drAttchVhcl["TransDtlId"] = dtVhclAttchmnt.Rows[intcnt][0].ToString();
                   drAttchVhcl["FileName"] = dtVhclAttchmnt.Rows[intcnt][1].ToString();
                   drAttchVhcl["ActualFileName"] = dtVhclAttchmnt.Rows[intcnt][2].ToString();
                   drAttchVhcl["Description"] = dtVhclAttchmnt.Rows[intcnt][4].ToString();
                   dtVAttchmnt.Rows.Add(drAttchVhcl);
                   hiddenAttchmntVhclSlNumber.Value = dtVhclAttchmnt.Rows[intcnt][3].ToString();
               }

               string strJson = DataTableToJSONWithJavaScriptSerializer(dtVAttchmnt);
               hiddenEditVhclAttchmnt.Value = strJson;
           }
        //end for displaying attached files

        //start partnership table display
           DataTable dtDetail = new DataTable();
           dtDetail.Columns.Add("TransId", typeof(int));
           dtDetail.Columns.Add("TransDtlId", typeof(int));
           dtDetail.Columns.Add("PartnerId", typeof(int));
           dtDetail.Columns.Add("PartnerName", typeof(string));
           dtDetail.Columns.Add("DocumentNo", typeof(string));
           dtDetail.Columns.Add("SharePer", typeof(decimal));
           dtDetail.Columns.Add("Status", typeof(int));

           DataTable dt = new DataTable();
           dt = objBusinessLayerCorpOffice.ReadPartnerDetails(objEntCorpOffice);

           for (int intcnt = 0; intcnt < dt.Rows.Count; intcnt++)
           {
               DataRow drDtl = dtDetail.NewRow();
               drDtl["TransId"] = Convert.ToInt32(dt.Rows[intcnt]["CORPRTPTNR_ID"].ToString());
               drDtl["TransDtlId"] = Convert.ToInt32(dt.Rows[intcnt]["CORPRTPTNR_ID"].ToString());
               drDtl["PartnerId"] = dt.Rows[intcnt]["PRTNR_ID"].ToString();
               drDtl["PartnerName"] = dt.Rows[intcnt]["CORPRTPTNR_NAME"].ToString();
               drDtl["DocumentNo"] = dt.Rows[intcnt]["CORPRTPTNR_DCMNT_NUM"].ToString();
               drDtl["SharePer"] = Convert.ToDecimal(dt.Rows[intcnt]["CORPRTPTNR_PERCNT"].ToString());
               drDtl["Status"] = Convert.ToInt32(dt.Rows[intcnt]["PRTNR_STATUS"].ToString());
               dtDetail.Rows.Add(drDtl);

           }
           HiddenPartnerRowCount.Value = Convert.ToString(dt.Rows.Count);
           string strJsonF = DataTableToJSONWithJavaScriptSerializer(dtDetail);
           HiddenField3.Value = strJsonF;

        //stop partnership table display


           //start Bank Details table display
           DataTable dtDetails = new DataTable();
           dtDetails.Columns.Add("TransId", typeof(int));
           dtDetails.Columns.Add("TransDtlId", typeof(int));
           dtDetails.Columns.Add("BankId", typeof(int));
           dtDetails.Columns.Add("Branch", typeof(string));
           dtDetails.Columns.Add("IBAN", typeof(string));
           dtDetails.Columns.Add("BankName", typeof(string));
           dtDetails.Columns.Add("BankStatus", typeof(int));

           DataTable dtBankDtl = new DataTable();
           dtBankDtl = objBusinessLayerCorpOffice.ReadBankDtlsOfCorp(objEntCorpOffice);
           for (int intcnt = 0; intcnt < dtBankDtl.Rows.Count; intcnt++)
           {
               DataRow drDtl = dtDetails.NewRow();
               drDtl["TransId"] = Convert.ToInt32(dtBankDtl.Rows[intcnt]["CRBNKDTLID"].ToString());
               drDtl["TransDtlId"] = Convert.ToInt32(dtBankDtl.Rows[intcnt]["CRBNKDTLID"].ToString());
               drDtl["BankId"] = Convert.ToInt32(dtBankDtl.Rows[intcnt]["BANK_ID"].ToString());
               drDtl["Branch"] = dtBankDtl.Rows[intcnt]["BRANCH_NAME"].ToString();
               drDtl["IBAN"] = dtBankDtl.Rows[intcnt]["IBAN"].ToString();
               drDtl["BankName"] = dtBankDtl.Rows[intcnt]["BANK_NAME"].ToString();
               drDtl["BankStatus"] = Convert.ToInt32(dtBankDtl.Rows[intcnt]["BANK_STATUS"].ToString());
               dtDetails.Rows.Add(drDtl);

           }
           HiddenFieldEditBankCountRow.Value = Convert.ToString(dtBankDtl.Rows.Count);
           string strJsonFf = DataTableToJSONWithJavaScriptSerializer(dtDetails);
           HiddenFieldEditBankData.Value = strJsonFf;

         //stop Bank Details table display
    }

    public class Orginfo
    {
        public string strAdd1 = "";
        public string strAdd2 = "";
        public string strAdd3 = "";
        public string strCRN = "";
        public string strCRNexp = "";
        public string strCRNiss = "";
        public string strTIN = "";
        public string strTINexp = "";
        public string strTINiss = "";
        public string strCCN = "";
        public string strCCNexp = "";
        public string strCCNiss = "";

    }

    // this web method is for fetching data based on the organisation
    [WebMethod]
    public static Orginfo ReadOrgInfo(string orgId)
    {

        Orginfo objReqstgurnte = new Orginfo();     

        //Creating objects for business layer
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        clsEntityCorpOffice objEntityCorpOffice = new clsEntityCorpOffice();



        if (orgId != null && orgId != "" && orgId != "undefined")
        {
            objEntityCorpOffice.Organisation_Id = Convert.ToInt32(orgId);
        }

        DataTable dtWtrCrdDtl = new DataTable();

        dtWtrCrdDtl = objBusinessLayerCorpOffice.OrgDetails(objEntityCorpOffice);
        if (dtWtrCrdDtl.Rows.Count > 0)
        {
            objReqstgurnte.strAdd1 = dtWtrCrdDtl.Rows[0]["ORG_ADDR1"].ToString();
            objReqstgurnte.strAdd2 = dtWtrCrdDtl.Rows[0]["ORG_ADDR2"].ToString();
            objReqstgurnte.strAdd3 = dtWtrCrdDtl.Rows[0]["ORG_ADDR3"].ToString();
            objReqstgurnte.strCRN = dtWtrCrdDtl.Rows[0]["ORG_CMRCLRGT_NUM"].ToString();
            objReqstgurnte.strCRNexp = dtWtrCrdDtl.Rows[0]["CRNEXP"].ToString();
            objReqstgurnte.strCRNiss = dtWtrCrdDtl.Rows[0]["CRNISS"].ToString();
            objReqstgurnte.strTIN = dtWtrCrdDtl.Rows[0]["ORG_TAXCRD_NUM"].ToString();
            objReqstgurnte.strTINexp = dtWtrCrdDtl.Rows[0]["TINEXP"].ToString();
            objReqstgurnte.strTINiss = dtWtrCrdDtl.Rows[0]["TINISS"].ToString();
            objReqstgurnte.strCCN = dtWtrCrdDtl.Rows[0]["ORG_CMPTRCRD_NUM"].ToString();
            objReqstgurnte.strCCNexp = dtWtrCrdDtl.Rows[0]["CCNEXP"].ToString();
            objReqstgurnte.strCCNiss = dtWtrCrdDtl.Rows[0]["CCNISS"].ToString();
           
        }
        return objReqstgurnte;
    }

   
    [WebMethod]
    public static string countryChange(string tableName, string countryId)
    {

      
        clsEntityCorpOffice objEntityCorp = new clsEntityCorpOffice();
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        objEntityCorp.CountryId = Convert.ToInt32(countryId);
        DataTable dtState = objBusinessLayerCorpOffice.ReadState(objEntityCorp);
        dtState.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtState.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }
    [WebMethod]
    public static string stateChange(string tableName, string stateId)
    {


        clsEntityCorpOffice objEntityCorp = new clsEntityCorpOffice();
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        objEntityCorp.StateId = Convert.ToInt32(stateId);
        DataTable dtCity = objBusinessLayerCorpOffice.ReadCity(objEntityCorp);
        dtCity.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtCity.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }
    [WebMethod]
    public static string[] changeCity(string strLikeEmployee, int orgID, int corptID, int stateID)
    {
        List<string> Employees = new List<string>();
        clsEntityCorpOffice objEntityCorp = new clsEntityCorpOffice();
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        objEntityCorp.StateId = Convert.ToInt32(stateID);
        objEntityCorp.Cancel_Reason = strLikeEmployee;
        DataTable dtEmployess = objBusinessLayerCorpOffice.ReadCity(objEntityCorp);
        for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
        {
            Employees.Add(string.Format("{0}<,>{1}", dtEmployess.Rows[intRowCount]["CITY_ID"].ToString(), dtEmployess.Rows[intRowCount]["CITY_NAME"].ToString()));
        }
        return Employees.ToArray();
    }
    [WebMethod]
    public static string[] changeState(string strLikeEmployee, int orgID, int corptID, int countryID)
    {
        List<string> Employees = new List<string>();
        clsEntityCorpOffice objEntityCorp = new clsEntityCorpOffice();
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        objEntityCorp.CountryId = Convert.ToInt32(countryID);
        objEntityCorp.Cancel_Reason = strLikeEmployee;
        DataTable dtEmployess = objBusinessLayerCorpOffice.ReadState(objEntityCorp);
        for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
        {
            Employees.Add(string.Format("{0}<,>{1}", dtEmployess.Rows[intRowCount]["STATE_ID"].ToString(), dtEmployess.Rows[intRowCount]["STATE_NAME"].ToString()));
        }
        return Employees.ToArray();
    }
    protected void ddlBsnsType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBsnsTyp.Value == "PARTNERSHIP")
        {
            ddlShareTyp.Disabled = false;
        }
        else
        {
            ddlShareTyp.Disabled = true;
        }
    }
    protected void ddlOfficeTyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOfficeTyp.Value == "BRANCH OFFICE")
        {
            ddlParent.Disabled = false;
        }
        else
        {
            ddlParent.Disabled = true;
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
    public void DropDownEmployeeDataStore()
    {
        clsEntityCorpOffice objEntityCorpOffice = new clsEntityCorpOffice();

        if (HiddenFieldCorpID.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCorpOffice.CorpOfficeId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
        }
        else
        {
            objEntityCorpOffice.CorpOfficeId = Convert.ToInt32(HiddenFieldCorpID.Value);
        }

        if (Session["ORGID"] != null)
        {
            objEntityCorpOffice.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        DataTable dtCountryList = objBusinessLayerCorpOffice.ReadBankDtls(objEntityCorpOffice);

        dtCountryList.TableName = "dtTableEmployee";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtCountryList.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenEmpDdlData.Value = result;
    }
    [WebMethod]
    public static string CheckDupIban(string corpId, string IbanNew, string OrgId)
    {
        string sts = "false";
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        clsEntityCorpOffice objEntityCorpOffice = new clsEntityCorpOffice();
        objEntityCorpOffice.CorpOfficeId = Convert.ToInt32(corpId);
        objEntityCorpOffice.Code = IbanNew;
        objEntityCorpOffice.Organisation_Id = Convert.ToInt32(OrgId);
        DataTable dt = objBusinessLayerCorpOffice.checkIbanDup(objEntityCorpOffice);
        if (dt.Rows.Count > 0)
        {
            sts = "true";
        }
        return sts;
    }


    [WebMethod]
    public static string CheckDupName(string strName, string strOrgId)
    {
        string strResult = "0";
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        clsEntityCorpOffice objEntityCorpOffice = new clsEntityCorpOffice();
        objEntityCorpOffice.Corporation_Name = strName.ToUpper();
        objEntityCorpOffice.Organisation_Id = Convert.ToInt32(strOrgId);
        strResult = objBusinessLayerCorpOffice.CheckCorpOffice(objEntityCorpOffice);
        return strResult;
    }
    [WebMethod]
    public static string CheckDupCode(string strCode, string strOrgId)
    {
        string strResult = "0";
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        clsEntityCorpOffice objEntityCorpOffice = new clsEntityCorpOffice();
        objEntityCorpOffice.Code = strCode.ToUpper();
        objEntityCorpOffice.Organisation_Id = Convert.ToInt32(strOrgId);
        strResult = objBusinessLayerCorpOffice.CheckCodenum(objEntityCorpOffice);
        return strResult;
    }

}