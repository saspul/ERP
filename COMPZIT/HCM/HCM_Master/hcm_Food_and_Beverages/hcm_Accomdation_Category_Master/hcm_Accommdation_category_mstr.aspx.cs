using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
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

public partial class HCM_HCM_Master_hcm_Food_and_Beverages_hcm_Accomdation_Category_Master_hcm_Accommdation_category_mstr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //EditView(711623,1);

            // txtName.Focus();
            clsBusiness_Accommodation_Category objBusinessAccomdtn = new clsBusiness_Accommodation_Category();
            clsEntity_Accommodation_Cat objEntityAccomdtncat = new clsEntity_Accommodation_Cat();
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Accommodatiion_Category_Master);
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
                int intCorpId = 0;
                int intOrgId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityAccomdtncat.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();

                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityAccomdtncat.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
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
                    lblEntry.Text = "Edit Accommodation Category";

                }
                //when editing 
                else if (Request.QueryString["StrId"] != null)
                {
                    btnClear.Visible = false;
                    btnUpdate.Visible = false;
                    int intWBillId = Convert.ToInt32(Request.QueryString["StrId"]);
                    hiddenIntwCatID.Value = Request.QueryString["StrId"];
                    EditView(intWBillId, 1);
                    lblEntry.Text = "Edit Accommodation Category";
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

                    lblEntry.Text = "View Accommodation Category";
                }
                else
                {
                    lblEntry.Text = "Add Accommodation Category";
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
    //for saving
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            //creating objects for layers
            clsBusiness_Accommodation_Category objBusinessAccomdtn = new clsBusiness_Accommodation_Category();
            clsEntity_Accommodation_Cat objEntityAccomdtncat = new clsEntity_Accommodation_Cat();
            int intUserId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityAccomdtncat.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }


            if (Session["ORGID"] != null)
            {
                objEntityAccomdtncat.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
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
            objEntityAccomdtncat.AccommodationName = txtCatName.Text.Trim().ToUpper();
            if (cbxCnclStatus.Checked == true)
            {
                objEntityAccomdtncat.Status = 1;
            }
            else
            {
                objEntityAccomdtncat.Status = 0;
            }
          

            // ID
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.HCM_ACCOMMODATION_CATEGORY);
            objEntityCommon.CorporateID = objEntityAccomdtncat.CorpId;
            objEntityCommon.Organisation_Id = objEntityAccomdtncat.OrgId;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            //objEntityAccomdtncat.AccommodationcatId = Convert.ToInt32(strNextId);
            objEntityAccomdtncat.UserId = intUserId;
            objEntityAccomdtncat.Date = System.DateTime.Now;

            List<cls_Entity_Accommodation_Category_list> objAccomdntncatlist = new List<cls_Entity_Accommodation_Category_list>();
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
                cls_Entity_Accommodation_Category_list objEntityDetails = new cls_Entity_Accommodation_Category_list();
             //   objEntityDetails.Accommodationsubcategrysid = Convert.ToInt32(strNextId);
                objEntityDetails.AccommodationSubCatName = objclsWBData.APTNAME;
                objEntityDetails.AccommodationSubCatStatus = Convert.ToInt32(objclsWBData.DEFLTSTATUS);
                objAccomdntncatlist.Add(objEntityDetails);
            }
            objBusinessAccomdtn.InsertAccomodationTemplate(objEntityAccomdtncat, objAccomdntncatlist);
            if (clickedButton.ID == "btnSave")
            {
                Response.Redirect("hcm_Accommdation_category_mstr.aspx?InsUpd=Save");
            }
            else if (clickedButton.ID == "btnSaveClose")
            {
                Response.Redirect("hcm_accommodation_Category_list.aspx?InsUpd=Save");
            }

        }
        catch (Exception ex)
        {
            //throw ex;
          //  ScriptManager.RegisterStartupScript(this, GetType(), "ErrMsg", "ErrMsg();", true);
        }
    }

    private void EditView(int intId, int intEditOrView)

    {//when Editing or viewing
        //intEditOrView if 1-Edit,2-View
        clsCommonLibrary objCommon = new clsCommonLibrary();
        //creating objects for layers
        clsBusiness_Accommodation_Category objBusinessAccomdtn = new clsBusiness_Accommodation_Category();
        clsEntity_Accommodation_Cat objEntityAccomdtncat = new clsEntity_Accommodation_Cat();
        objEntityAccomdtncat.AccommodationcatId = intId;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccomdtncat.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }



        if (Session["ORGID"] != null)
        {
            objEntityAccomdtncat.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtInterviewCatDtl = new DataTable();
 
        dtInterviewCatDtl = objBusinessAccomdtn.ReadAccommodationCatByID(objEntityAccomdtncat);

        if (dtInterviewCatDtl.Rows.Count > 0)
        {

            txtCatName.Text = dtInterviewCatDtl.Rows[0]["ACCOMDTNCAT_NAME"].ToString();
            if (dtInterviewCatDtl.Rows[0]["STATUS"].ToString() == "1")
            {
                cbxCnclStatus.Checked = true;

            }
            else
            {
                cbxCnclStatus.Checked = false;
            }

 
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("AccmdtnId", typeof(int));
            dtDetail.Columns.Add("ACCMDTNSUB_ID", typeof(int));
            dtDetail.Columns.Add("ACCMDTNSUB_NAME", typeof(string));
            dtDetail.Columns.Add("DfltStatus", typeof(string));


            for (int intcnt = 0; intcnt < dtInterviewCatDtl.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["AccmdtnId"] = Convert.ToInt32(dtInterviewCatDtl.Rows[intcnt]["ACCOMDTNCAT_ID"].ToString());
                drDtl["ACCMDTNSUB_ID"] = Convert.ToInt32(dtInterviewCatDtl.Rows[intcnt]["ACCOMDTNCATSUB_ID"].ToString());
                drDtl["ACCMDTNSUB_NAME"] = dtInterviewCatDtl.Rows[intcnt]["ACCOMDTNCATSUB_NAME"].ToString();
                drDtl["DfltStatus"] = dtInterviewCatDtl.Rows[intcnt]["ACCOMDTNCATSUB_STATUS"].ToString();

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
      [WebMethod]
    public static string CheckDupCertificateTemplate(string strCertfctTempId, string strCertName, string strOrgId, string strCorpId)
    {
        //Confirm
        string strResult = "0";
        clsBusiness_Accommodation_Category objBusinessAccomdtn = new clsBusiness_Accommodation_Category();
        clsEntity_Accommodation_Cat objEntityAccomdtncat = new clsEntity_Accommodation_Cat();
        objEntityAccomdtncat.AccommodationcatId = Convert.ToInt32(strCertfctTempId);
        objEntityAccomdtncat.AccommodationName = strCertName;
        objEntityAccomdtncat.OrgId = Convert.ToInt32(strOrgId);
        objEntityAccomdtncat.CorpId = Convert.ToInt32(strCorpId);
        strResult = objBusinessAccomdtn.CheckDupCertificateTemplate(objEntityAccomdtncat);
        return strResult;
    }
    //for updation
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            if (Request.QueryString["Id"] != null || Request.QueryString["StrId"] != null)
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();
                //creating objects for layers
                clsBusiness_Accommodation_Category objBusinessAccomdtn = new clsBusiness_Accommodation_Category();
                clsEntity_Accommodation_Cat objEntityAccomdtncat = new clsEntity_Accommodation_Cat();
                int intUserId = 0;

                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityAccomdtncat.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }


                if (Session["ORGID"] != null)
                {
                    objEntityAccomdtncat.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
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
                    objEntityAccomdtncat.AccommodationcatId = Convert.ToInt32(strId);
                }
                else
                {
                    objEntityAccomdtncat.AccommodationcatId = Convert.ToInt32(Request.QueryString["StrId"]);
                }

                objEntityAccomdtncat.UserId = intUserId;
                objEntityAccomdtncat.Date = System.DateTime.Now;
                objEntityAccomdtncat.AccommodationName = txtCatName.Text.Trim();
                if (cbxCnclStatus.Checked == true)
                {
                    objEntityAccomdtncat.Status = 1;
                }
                else
                {
                    objEntityAccomdtncat.Status = 0;
                }
                List<cls_Entity_Accommodation_Category_list> objEntityCertfctINSERTList = new List<cls_Entity_Accommodation_Category_list>();
                List<cls_Entity_Accommodation_Category_list> objEntityCertfctUPDATEList = new List<cls_Entity_Accommodation_Category_list>();
                List<cls_Entity_Accommodation_Category_list> objEntityCertfctDELETEList = new List<cls_Entity_Accommodation_Category_list>();
                if (HiddenField1.Value != "")
                {
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
                            cls_Entity_Accommodation_Category_list objEntityDetails = new cls_Entity_Accommodation_Category_list();

                            objEntityDetails.AccommodationSubCatName = objClsWBData.APTNAME;
                            objEntityDetails.AccommodationSubCatStatus = Convert.ToInt32(objClsWBData.DEFLTSTATUS);
                            objEntityCertfctINSERTList.Add(objEntityDetails);
                        }
                        else if (objClsWBData.EVTACTION == "UPD")
                        {
                            cls_Entity_Accommodation_Category_list objEntityDetails = new cls_Entity_Accommodation_Category_list();
                            objEntityDetails.AccommodationSubCatName = objClsWBData.APTNAME;
                            objEntityDetails.AccommodationSubCatStatus = Convert.ToInt32(objClsWBData.DEFLTSTATUS);
                            objEntityDetails.Accommodationsubcategrysid = Convert.ToInt32(objClsWBData.DTLID);
                            objEntityCertfctUPDATEList.Add(objEntityDetails);


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
                            cls_Entity_Accommodation_Category_list objEntityDetails = new cls_Entity_Accommodation_Category_list();
                            objEntityDetails.Accommodationsubcategrysid = Convert.ToInt32(strDtlId);
                            objEntityCertfctDELETEList.Add(objEntityDetails);

                        }
                    }

                }
                objBusinessAccomdtn.UpdateAccommodationCat(objEntityAccomdtncat, objEntityCertfctINSERTList, objEntityCertfctUPDATEList, objEntityCertfctDELETEList);




                if (Request.QueryString["StrId"] != null)
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedCustomerToLead", "PassSavedCustomerToLead();", true);


                }

                else
                {

                    if (clickedButton.ID == "btnUpdate")
                    {
                        Response.Redirect("hcm_Accommdation_category_mstr.aspx?InsUpd=Upd");
                    }
                    else if (clickedButton.ID == "btnUpdateClose")
                    {
                        Response.Redirect("hcm_accommodation_Category_list.aspx?InsUpd=Upd");
                    }
                }
            }
            else
            {

                Response.Redirect("~/Default.aspx");

            }
        }
        catch(Exception ex)
        {
           
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
    [WebMethod]
    public static string checkSubCat(int intDetailID)
    {

        //finish settlement status

        clsBusiness_Accommodation_Category objBusinessAccomdtn = new clsBusiness_Accommodation_Category();
        cls_Entity_Accommodation_Category_list objEntityAccomdtncat = new cls_Entity_Accommodation_Category_list();
        string ret = "true";

        objEntityAccomdtncat.Accommodationsubcategrysid = intDetailID;
        string strClsdOrFnshd = "";
        strClsdOrFnshd = objBusinessAccomdtn.CheckSubCat(objEntityAccomdtncat);

        if (strClsdOrFnshd != "0")
        {
            ret = "false";
        }
       

        return ret;

    }

}