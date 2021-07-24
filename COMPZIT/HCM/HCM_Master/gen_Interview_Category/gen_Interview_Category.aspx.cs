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
public partial class HCM_HCM_Master_gen_Interview_Category_gen_Interview_Category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            txtIntwCategory.Focus();
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



            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Interview_Category);
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
                clsEntityInterviewCategory objEntityInterviewCategory = new clsEntityInterviewCategory();
                int intCorpId = 0;
                int intOrgId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityInterviewCategory.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();

                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityInterviewCategory.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
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
                    lblEntry.Text = "Edit Interview Category";
                    
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
                    lblEntry.Text = "Edit Interview Category";
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

                    lblEntry.Text = "View Interview Category";
                }
                else
                {
                    lblEntry.Text = "Add Interview Category";
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

            clsBusinessLayerInterviewCategory objBusinessInterviewCategory = new clsBusinessLayerInterviewCategory();
            clsEntityInterviewCategory objEntityInterviewCategory = new clsEntityInterviewCategory();
            int intUserId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityInterviewCategory.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else 
            {
                Response.Redirect("~/Default.aspx");
            }


            if (Session["ORGID"] != null)
            {
                objEntityInterviewCategory.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
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
            objEntityInterviewCategory.IntwCategoryName = txtIntwCategory.Text.Trim();
            if (cbxCnclStatus.Checked == true)
            {
                objEntityInterviewCategory.IntwCategoryStatus = 1;
            }
            else
            {
                objEntityInterviewCategory.IntwCategoryStatus = 0;
            }
            //objEntityInterviewCategory.TotalAmnt = Convert.ToDecimal(hiddenNetAmount.Value.Trim());
           
                // ID
                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INTERVIEW_CATEGORY);
                objEntityCommon.CorporateID = objEntityInterviewCategory.CorpId;
                objEntityCommon.Organisation_Id = objEntityInterviewCategory.OrgId;
                string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                objEntityInterviewCategory.IntwCategoryId = Convert.ToInt32(strNextId);
                objEntityInterviewCategory.UserId = intUserId;
                objEntityInterviewCategory.Date = System.DateTime.Now;

                List<clsEntityInterviewCategoryDetails> objEntityInterviewCategoryDetilsList = new List<clsEntityInterviewCategoryDetails>();
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
                    clsEntityInterviewCategoryDetails objEntityDetails = new clsEntityInterviewCategoryDetails();

                    objEntityDetails.IntwCtgryDtlName = objclsWBData.APTNAME;
                    objEntityDetails.IntwCtgryDtlStatus = Convert.ToInt32(objclsWBData.DEFLTSTATUS);
                    objEntityInterviewCategoryDetilsList.Add(objEntityDetails);
                }
                objBusinessInterviewCategory.InsertInterviewCategory(objEntityInterviewCategory, objEntityInterviewCategoryDetilsList);
                if (clickedButton.ID == "btnSave")
                {
                    Response.Redirect("gen_Interview_Category.aspx?InsUpd=Save");
                }
                else if (clickedButton.ID == "btnSaveClose")
                {
                    Response.Redirect("gen_Interview_CategoryList.aspx?InsUpd=Save");
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
                clsBusinessLayerInterviewCategory objBusinessInterviewCategory = new clsBusinessLayerInterviewCategory();
                clsEntityInterviewCategory objEntityInterviewCategory = new clsEntityInterviewCategory();
                int intUserId = 0;

                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityInterviewCategory.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }


                if (Session["ORGID"] != null)
                {
                    objEntityInterviewCategory.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
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
                    objEntityInterviewCategory.IntwCategoryId = Convert.ToInt32(strId);
                }
                else
                {
                    objEntityInterviewCategory.IntwCategoryId = Convert.ToInt32(Request.QueryString["StrId"]);
                }

                objEntityInterviewCategory.UserId = intUserId;
                objEntityInterviewCategory.Date = System.DateTime.Now;
                objEntityInterviewCategory.IntwCategoryName = txtIntwCategory.Text.Trim();
                if (cbxCnclStatus.Checked == true)
                {
                    objEntityInterviewCategory.IntwCategoryStatus = 1;
                }
                else
                {
                    objEntityInterviewCategory.IntwCategoryStatus = 0;
                }
                List<clsEntityInterviewCategoryDetails> objEntityIntwCatDtlINSERTList = new List<clsEntityInterviewCategoryDetails>();

                List<clsEntityInterviewCategoryDetails> objEntityIntwCatDtlUPDATEList = new List<clsEntityInterviewCategoryDetails>();
                List<clsEntityInterviewCategoryDetails> objEntityIntwCatDtlDELETEList = new List<clsEntityInterviewCategoryDetails>();

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
                        clsEntityInterviewCategoryDetails objEntityDetails = new clsEntityInterviewCategoryDetails();

                        objEntityDetails.IntwCtgryDtlName = objClsWBData.APTNAME;
                        objEntityDetails.IntwCtgryDtlStatus = Convert.ToInt32(objClsWBData.DEFLTSTATUS);
                        objEntityIntwCatDtlINSERTList.Add(objEntityDetails);
                    }
                    else if (objClsWBData.EVTACTION == "UPD")
                    {
                        clsEntityInterviewCategoryDetails objEntityDetails = new clsEntityInterviewCategoryDetails();
                        objEntityDetails.IntwCtgryDtlName = objClsWBData.APTNAME;
                        objEntityDetails.IntwCtgryDtlStatus = Convert.ToInt32(objClsWBData.DEFLTSTATUS);
                        objEntityDetails.IntwCtgryDtlId = Convert.ToInt32(objClsWBData.DTLID);
                        objEntityIntwCatDtlUPDATEList.Add(objEntityDetails);


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
                        clsEntityInterviewCategoryDetails objEntityDetails = new clsEntityInterviewCategoryDetails();
                        objEntityDetails.IntwCtgryDtlId = Convert.ToInt32(strDtlId);
                        objEntityIntwCatDtlDELETEList.Add(objEntityDetails);
                       
                    }
                }

                objBusinessInterviewCategory.UpdateInterviewCategory(objEntityInterviewCategory, objEntityIntwCatDtlINSERTList, objEntityIntwCatDtlUPDATEList, objEntityIntwCatDtlDELETEList);




                if (Request.QueryString["StrId"] != null)
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedCustomerToLead", "PassSavedCustomerToLead();", true);


                }

                else
                {

                    if (clickedButton.ID == "btnUpdate")
                    {
                        Response.Redirect("gen_Interview_Category.aspx?InsUpd=Upd");
                    }
                    else if (clickedButton.ID == "btnUpdateClose")
                    {
                        Response.Redirect("gen_Interview_CategoryList.aspx?InsUpd=Upd");
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
   
    [WebMethod]
    public static string CheckDupIntwCatName(string strIntwCategoryId, string strIntwCategoryName, string strOrgId, string strCorpId)
    {
        //Confirm
        string strResult = "0";
        clsBusinessLayerInterviewCategory objBusinessInterviewCategory = new clsBusinessLayerInterviewCategory();
        clsEntityInterviewCategory objEntityInterviewCategory = new clsEntityInterviewCategory();
        objEntityInterviewCategory.IntwCategoryId = Convert.ToInt32(strIntwCategoryId);
        objEntityInterviewCategory.IntwCategoryName = strIntwCategoryName;
        objEntityInterviewCategory.OrgId = Convert.ToInt32(strOrgId);
        objEntityInterviewCategory.CorpId = Convert.ToInt32(strCorpId);
        strResult = objBusinessInterviewCategory.CheckDupInterviewCategory(objEntityInterviewCategory);
        return strResult;
    }
    private void EditView(int intId, int intEditOrView)
    {//when Editing or viewing
        //intEditOrView if 1-Edit,2-View
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerInterviewCategory objBusinessInterviewCategory = new clsBusinessLayerInterviewCategory();
        clsEntityInterviewCategory objEntityInterviewCategory = new clsEntityInterviewCategory();
        objEntityInterviewCategory.IntwCategoryId = intId;
        
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityInterviewCategory.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else 
            {
                Response.Redirect("~/Default.aspx");
            }
       

        
            if (Session["ORGID"] != null)
            {
                objEntityInterviewCategory.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else 
            {
                Response.Redirect("~/Default.aspx");
            }
    
        DataTable dtInterviewCatDtl = new DataTable();
        //   DataTable dtWBill = new DataTable();


        dtInterviewCatDtl = objBusinessInterviewCategory.ReadInterviewCatByID(objEntityInterviewCategory);



        if (dtInterviewCatDtl.Rows.Count > 0)
        {


           
          txtIntwCategory.Text = dtInterviewCatDtl.Rows[0]["INTWCTGRY_NAME"].ToString();
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
            dtDetail.Columns.Add("IntwCatId", typeof(int));
            dtDetail.Columns.Add("IntwCatDtlId", typeof(int));
            dtDetail.Columns.Add("IntwCatDtlName", typeof(string));
            dtDetail.Columns.Add("DfltStatus", typeof(string));


            for (int intcnt = 0; intcnt < dtInterviewCatDtl.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["IntwCatId"] = Convert.ToInt32(dtInterviewCatDtl.Rows[intcnt]["INTWCTGRY_ID"].ToString());
                drDtl["IntwCatDtlId"] = Convert.ToInt32(dtInterviewCatDtl.Rows[intcnt]["INTWCTGRYDTL_ID"].ToString());
                drDtl["IntwCatDtlName"] = dtInterviewCatDtl.Rows[intcnt]["INTWCTGRYDTL_NAME"].ToString();
                drDtl["DfltStatus"] = dtInterviewCatDtl.Rows[intcnt]["DFLT_STATUS"].ToString();
                
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