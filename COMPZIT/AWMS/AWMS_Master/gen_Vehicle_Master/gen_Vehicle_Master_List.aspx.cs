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

public partial class AWMS_AWMS_Master_gen_Vehicle_Master_gen_Vehicle_Master_List : System.Web.UI.Page
{
    //enumeration for previous and next button
    private enum Button_type
    {
        Previous = 1,
        Next = 2
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        txtProviderName.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            VehicleClassLoad();
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            int intUserId = 0, intUsrRolMstrId,intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
            hiddenRoleAdd.Value = "0";
            hiddenRoleUpdate.Value = "0";
            hiddenRoleCancel.Value = "0";
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            //for common naming field
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.VEHICLE_MASTER);
            objEntityCommon.CommonLabelFieldName = "VHCL_PERMIT_NUMBR";
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            string strPermit = "";
            DataTable dtLblName = new DataTable();
            dtLblName = objBusinessLayer.ReadGeneralLabelName(objEntityCommon);
            if (dtLblName.Rows.Count > 0)
            {
                strPermit = dtLblName.Rows[0]["CMNLBL_NAME_TOCHNG"].ToString();
                hiddenPermitLabelName.Value = strPermit;
            }

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
            DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
            if (dtCancelRecall.Rows.Count > 0)
            {
                intEnableRecall = 1;
                hiddenRoleRecall.Value = "1";
            }
            else
            {
                intEnableRecall = 0;
                hiddenRoleRecall.Value = "0";
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Vehicle_Master);
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
                        hiddenRoleAdd.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleUpdate.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleCancel.Value = "1";
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
                    divAdd.Visible = true;

                }
                else
                {

                    divAdd.Visible = false;

                }

                if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                {
                    string strHidden = Request.QueryString["Srch"].ToString();
                    HiddenSearchField.Value = strHidden;

                    string[] strSearchFields = strHidden.Split(',');
                    string strSearchWord = strSearchFields[0];
                    string strddlStatus = strSearchFields[1];
                    string strCbxStatus = strSearchFields[2];
                    string strVehicleClass = strSearchFields[3];



                    if (strVehicleClass != null && strVehicleClass != "")
                    {
                        if (ddlVehicleClass.Items.FindByValue(strVehicleClass) != null)
                        {
                            ddlVehicleClass.Items.FindByValue(strVehicleClass).Selected = true;
                        }
                    }

                    if (strSearchWord != null && strSearchWord != "")
                    {

                        txtProviderName.Text = strSearchWord;
                    }
                    else
                    {
                        txtProviderName.Text = "";
                    }
                    if (strddlStatus != null && strddlStatus != "")
                    {
                        if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                        {
                            ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                        }
                    }
                    if (strCbxStatus == "1")
                    {
                        cbxCnclStatus.Checked = true;
                    }
                    else
                    {
                        cbxCnclStatus.Checked = false;
                    }

                }


                //Creating objects for business layer

                clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
                clsEntityLayerVehicleMaster objEntityVehicle = new clsEntityLayerVehicleMaster();
                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityVehicle.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityVehicle.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }


                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE,
                                                               clsCommonLibrary.CORP_GLOBAL.CMDTY_MANTN_OFFCE
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    hiddenCommodityValue.Value = dtCorpDetail.Rows[0]["CMDTY_MANTN_OFFCE"].ToString();
                    string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
                    string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();

                    int intListingMode = Convert.ToInt32(strListingMode);

                    if (intListingMode == 2)//variant
                    {
                        btnNext.Text = "Show Next Records";
                        btnPrevious.Text = "Show Previous Records";
                        hiddenMemorySize.Value = strLstingModeSize;
                    }
                    else if (intListingMode == 1)//fixed
                    {
                        btnNext.Text = "Show Next " + strLstingModeSize + " Records";
                        btnPrevious.Text = "Show Previous " + strLstingModeSize + " Records";
                        hiddenTotalRowCount.Value = strLstingModeSize;
                        hiddenNext.Value = strLstingModeSize;
                    }
                    hiddenPrevious.Value = "0";

                }


                //when recalled
                if (Request.QueryString["ReId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["ReId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityVehicle.VehicleId = Convert.ToInt32(strId);
                    objEntityVehicle.User_Id = intUserId;

                    objEntityVehicle.Date = System.DateTime.Now;

                    DataTable dtVehicleDetail = new DataTable();
                    dtVehicleDetail = objBusinessVehicle.ReadVehicleDetailsById(objEntityVehicle);
                    if (dtVehicleDetail.Rows.Count > 0)
                    {
                        objEntityVehicle.VehicleNumber = dtVehicleDetail.Rows[0]["VHCL_NUMBR"].ToString();
                        objEntityVehicle.Insurance = dtVehicleDetail.Rows[0]["VHCL_INSUR_NUMBR"].ToString();
                        objEntityVehicle.ChasisNumber = dtVehicleDetail.Rows[0]["VHCL_CHASIS_NUM"].ToString();
                        objEntityVehicle.PermitNumber = dtVehicleDetail.Rows[0]["VHCL_PERMIT_NUMBR"].ToString();
                        objEntityVehicle.RfIdTagNum = dtVehicleDetail.Rows[0]["VHCL_RF_ID_TAG_NUMBR"].ToString();
                        objEntityVehicle.TrailerRegNum = dtVehicleDetail.Rows[0]["TRLER_REG_NUMBR"].ToString();
                        objEntityVehicle.TrailerInsNum = dtVehicleDetail.Rows[0]["TRLER_INSUR_NUMBR"].ToString();

                    }
                    string strNameCount = objBusinessVehicle.CheckVehicleNumber(objEntityVehicle);
                   // string strPermitCount = objBusinessVehicle.CheckPermitNumber(objEntityVehicle);
                    string strRFIDCount = objBusinessVehicle.CheckRF_IdNumber(objEntityVehicle);
                    string strInsureCount = objBusinessVehicle.CheckInsuranceNumber(objEntityVehicle);
                    string strChasisCount = objBusinessVehicle.CheckChasisNumber(objEntityVehicle);

                    string strTrailerRegCount = objBusinessVehicle.CheckTrailerNumber(objEntityVehicle);
                    string strTrailerInsCount = objBusinessVehicle.CheckTrailerInsNumber(objEntityVehicle);


                    if (strNameCount == "0" && strInsureCount == "0" && strChasisCount == "0" && strRFIDCount == "0" && strTrailerRegCount == "0" && strTrailerInsCount == "0")
                    {
                        objBusinessVehicle.RecallVehicleMaster(objEntityVehicle);
                        if (HiddenSearchField.Value == "")
                            Response.Redirect("gen_Vehicle_Master_List.aspx?InsUpd=Recl");
                        else
                            Response.Redirect("gen_Vehicle_Master_List.aspx?InsUpd=Recl&Srch=" + this.HiddenSearchField.Value);
                    }
                    else
                    {

                      
                        if (strInsureCount != "0")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationInsurance", "DuplicationInsurance();", true);

                        }
                         /* else if (strPermitCount != "0")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationPermit", "DuplicationPermit();", true);

                        }*/

                        else if (strRFIDCount != "0")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationRFid", "DuplicationRFid();", true);

                        }
                       else if (strChasisCount != "0")
                       {
                           ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationChasis", "DuplicationChasis();", true);

                       }
                       else if (strNameCount != "0")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

                        }

                        else if (strTrailerRegCount != "0")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationTrailerReg", "DuplicationTrailerReg();", true);

                        }
                        else if (strTrailerInsCount != "0")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationTrailerIns", "DuplicationTrailerIns();", true);

                        }
                    }




                }



                if (Request.QueryString["Id"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityVehicle.VehicleId = Convert.ToInt32(strId);
                    objEntityVehicle.User_Id = intUserId;

                    objEntityVehicle.Date = System.DateTime.Now;

                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
                        string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntityVehicle.CancelReason = objCommon.CancelReason();
   

                            objBusinessVehicle.CancelVehicleMaster(objEntityVehicle);
                            if (HiddenSearchField.Value == "")
                                Response.Redirect("gen_Vehicle_Master_List.aspx?InsUpd=Cncl");
                            else
                                Response.Redirect("gen_Vehicle_Master_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);

                        }
                        else
                        {
                            DataTable dtCategory = new DataTable();
                            if (HiddenSearchField.Value == "")
                            {
                                objEntityVehicle.Status_id = 1;
                                objEntityVehicle.CancelStatus = 0;



                                dtCategory = objBusinessVehicle.ReadVehicleMasterListBySearch(objEntityVehicle);
                            }

                            else
                            {
                                string strHidden = "";
                                strHidden = HiddenSearchField.Value;
                                string[] strSearchFields = strHidden.Split(',');
                                string strSearchWord = strSearchFields[0];
                                string strddlStatus = strSearchFields[1];
                                string strCbxStatus = strSearchFields[2];
                                string strVehicleClass = strSearchFields[3];

                                objEntityVehicle.VehicleClassId = Convert.ToInt32(strVehicleClass);
                                objEntityVehicle.SearchField = strSearchWord;
                                objEntityVehicle.DataBase_Field = hiddenSearchDataBaseField.Value;
                                objEntityVehicle.Status_id = Convert.ToInt32(strddlStatus);
                                objEntityVehicle.CancelStatus = Convert.ToInt32(strCbxStatus);

                                dtCategory = objBusinessVehicle.ReadVehicleMasterListBySearch(objEntityVehicle);


                            }
                            string strHtm = ConvertDataTableToHTML(dtCategory, intEnableModify, intEnableCancel, intEnableRecall);
                            //Write to divReport
                            divReport.InnerHtml = strHtm;

                            hiddenRsnid.Value = strId;
                          

                        }

                    }



                }
                else
                {
                    //to view
                    DataTable dtCategory = new DataTable();
                    if (HiddenSearchField.Value == "")
                    {
                        objEntityVehicle.Status_id = 1;
                        objEntityVehicle.CancelStatus = 0;
                        dtCategory = objBusinessVehicle.ReadVehicleMasterListBySearch(objEntityVehicle);

                    }

                    else
                    {
                        string strHidden = "";
                        strHidden = HiddenSearchField.Value;
                        string[] strSearchFields = strHidden.Split(',');
                        string strSearchWord = strSearchFields[0];
                        string strddlStatus = strSearchFields[1];
                        string strCbxStatus = strSearchFields[2];
                        string strVehicleClass = strSearchFields[3];

                        objEntityVehicle.VehicleClassId = Convert.ToInt32(strVehicleClass);
                        objEntityVehicle.SearchField = strSearchWord;
                        objEntityVehicle.DataBase_Field = hiddenSearchDataBaseField.Value;
                        objEntityVehicle.Status_id = Convert.ToInt32(strddlStatus);
                        objEntityVehicle.CancelStatus = Convert.ToInt32(strCbxStatus);


                        dtCategory = objBusinessVehicle.ReadVehicleMasterListBySearch(objEntityVehicle);


                    }
                    string strHtm = ConvertDataTableToHTML(dtCategory, intEnableModify, intEnableCancel, intEnableRecall);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;

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
                        else if (strInsUpd == "Cncl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                        }
                        else if (strInsUpd == "Recl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "RecallCancelation", "RecallCancelation();", true);
                        }
                    }
                }

            }
        }
    }


    protected void VehicleClassLoad()
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        clsEntityLayerVehicleMaster objEntityVehicle = new clsEntityLayerVehicleMaster();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehicle.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityVehicle.VehicleClassId = 0;
        DataTable dtVehicleClass = new DataTable();
        dtVehicleClass = objBusinessVehicle.ReadVehicleClass(objEntityVehicle);
        if (dtVehicleClass.Rows.Count > 0)
        {

            ddlVehicleClass.DataSource = dtVehicleClass;
            ddlVehicleClass.DataValueField = "VHCLCLS_ID";
            ddlVehicleClass.DataTextField = "VHCLCLS_NAME";
            ddlVehicleClass.DataBind();
            ddlVehicleClass.Items.Insert(0, "--SELECT ALL CLASS--");

        }
      
    }

     //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall, int intCommodityOffice = 1)
    {
        var vehiclestatusname = "";
        clsEntityLayerVehicleMaster objEntityVehicle = new clsEntityLayerVehicleMaster();
        //for common naming field
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.VEHICLE_MASTER);
        objEntityCommon.CommonLabelFieldName = "VHCL_PERMIT_NUMBR";
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        string strPermit = "";
        DataTable dtLblName = new DataTable();
        dtLblName = objBusinessLayer.ReadGeneralLabelName(objEntityCommon);
        if (dtLblName.Rows.Count > 0)
        {
            strPermit = dtLblName.Rows[0]["CMNLBL_NAME_TOCHNG"].ToString().ToUpper();
        }
        else
        {
            strPermit = "PERMIT";
        }


        int first = Convert.ToInt32(hiddenPrevious.Value);

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";




        int intReCallForTAble = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

            if (intCnclUsrId != 0)
            {
                intReCallForTAble = 1;
                break;
            }

        }
        //EVM-0016
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
           

            //hiddencommodityvalue=1 means the current corporate office is a commodity maintained corporate office else not maintained corporate office.


            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "VEHICLE CLASS NAME" + "</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:26%; word-wrap:break-word; text-align: left;\">" + "REGISTER NUMBER" + "</th>";
            }
           

            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: left; word-wrap:break-word;\">" + "MAKE" + "</th>";

            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: left; word-wrap:break-word;\">" + "VEHICLE MODEL" + "</th>";

            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: center; word-wrap:break-word;\">" + " MODEL YEAR" + "</th>";

            }


            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">" + strPermit + " EXPIRY" + "</th>";

            }

            else if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: center; word-wrap:break-word;\">" + "VEHICLE STATUS" + "</th>";

            }
            else if (intColumnHeaderCount == 9)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: center; word-wrap:break-word;\">" + "STATUS" + "</th>";

            }



        }

        if (cbxCnclStatus.Checked == true)
        {
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";

            if (intReCallForTAble == 1)
            {
                if (intEnableRecall == 1)
                {
                    strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">RE-CALL</th>";
                }
            }
        }
        else
        {
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            }
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";
            }

        }
        //EVM-0016


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        
        for (int intRowBodyCount = first; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            //EVM-0016
            clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();

            objEntityVehicle.VehicleId = int.Parse(dt.Rows[intRowBodyCount][0].ToString());
            DataTable dtVehicleStsDetail = new DataTable();
            dtVehicleStsDetail = objBusinessVehicle.ReadVehicleSts(objEntityVehicle);
            if (dtVehicleStsDetail.Rows.Count > 0)
            {
                vehiclestatusname = dtVehicleStsDetail.Rows[0]["VHCLSTSTYP_NAME"].ToString();
            }
            else
            {
                vehiclestatusname = "AVAILABLE";
            }
            //EVM-0016

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;


            int intMemoryBytes = System.Text.ASCIIEncoding.Unicode.GetByteCount(strHtml);
            if (hiddenTotalRowCount.Value == "")
            {
                if (hiddenMemorySize.Value != "")
                {
                    if (intMemoryBytes >= Convert.ToInt64(hiddenMemorySize.Value))
                    {
                        hiddenTotalRowCount.Value = intRowBodyCount.ToString();
                        hiddenNext.Value = hiddenTotalRowCount.Value;
                        btnNext.Enabled = true;
                        break;
                    }
                    else
                    {

                        int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
                        int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

                        strHtml += "<tr  >";


                        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                        {
                            //if (j == 0)
                            //{
                            //    int intCnt = i + 1;
                            //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                            //}
                            if (intColumnBodyCount == 1)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                            }
                            if (intColumnBodyCount == 2)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:26%;word-break: break-all; word-wrap:break-word; text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                            }
                            

                            else if (intColumnBodyCount == 4)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                            }
                            else if (intColumnBodyCount == 5)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                            }
                            else if (intColumnBodyCount == 6)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                            }

                            else if (intColumnBodyCount == 7)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                            }
                            //EVM-0016
                            else if (intColumnBodyCount == 8)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + " <a class=\"tooltip\"  onclick='return getdetails(this.href);' " +
                               " href=\"/AWMS/AWMS_Master/gen_Vehicle_Status_Management/gen_Vehicle_Status_Management.aspx?VhclID=" + Id + "\">" + vehiclestatusname + "</a> </td>";

                                //strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + vehiclestatusname + "</td>";

                            }

                            else if (intColumnBodyCount == 9)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";

                            }

                        }


                     



                        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            if (intCnclUsrId == 0)
                            {

                                if (cbxCnclStatus.Checked == false)
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\"  onclick='return getdetails(this.href);' " +
                                          " href=\"gen_Vehicle_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";

                                }


                            }

                            else
                            {
                                if (cbxCnclStatus.Checked == true)
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                                     " href=\"gen_Vehicle_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";
                                }

                            }
                        }
                        if (cbxCnclStatus.Checked == false)
                        {
                            if (intReCallForTAble == 0)
                            {
                                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                                {
                                    if (intCnclUsrId == 0)
                                    {
                                        if (intCancTransaction == 0)
                                        {
                                            if (HiddenSearchField.Value == "")
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                                 " href=\"gen_Vehicle_Master_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                            }
                                            else
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                                 " href=\"gen_Vehicle_Master_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                            }
                                        }
                                        else
                                        {

                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelNotPossible();' >"
                                                    + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                                        }



                                    }
                                    else
                                    {

                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                    }
                                }
                            }
                        }
                        if (cbxCnclStatus.Checked == true)
                        {
                            if (intReCallForTAble == 1)
                            {
                                if (intEnableRecall == 1)
                                {
                                    if (intCnclUsrId == 0)
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                                    }
                                    else
                                    {

                                        if (HiddenSearchField.Value == "")
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Re-call\"   onclick='return RecallAlert(this.href);' " +
                                             " href=\"gen_Vehicle_Master_List.aspx?ReId=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Re-call\"  onclick='return RecallAlert(this.href);' " +
                                             " href=\"gen_Vehicle_Master_List.aspx?ReId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                        }

                                    }
                                }
                               
                            }
                        }
                        strHtml += "</tr>";

                    }
                }
            }
            //EVM-0016
            else
            {
                if (hiddenNext.Value == "")
                {
                    hiddenNext.Value = hiddenTotalRowCount.Value;
                }
                int last = Convert.ToInt32(hiddenNext.Value);
                if (intRowBodyCount < last)
                {
                    int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
                    int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

                    strHtml += "<tr  >";


                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                        //if (j == 0)
                        //{
                        //    int intCnt = i + 1;
                        //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                        //}
                        if (intColumnBodyCount == 1)
                        {
                            if (hiddenCommodityValue.Value == "1")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                        }
                        if (intColumnBodyCount == 2)
                        {
                            if (hiddenCommodityValue.Value == "1")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:26%;word-break: break-all; word-wrap:break-word; text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:26%;word-break: break-all; word-wrap:break-word; text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                        }
                        
                        else if (intColumnBodyCount == 4)
                        {
                            if (hiddenCommodityValue.Value == "1")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                        }
                        else if (intColumnBodyCount == 5)
                        {
                            if (hiddenCommodityValue.Value == "1")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                        }
                        else if (intColumnBodyCount == 6)
                        {
                            if (hiddenCommodityValue.Value == "1")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                        }

                        else if (intColumnBodyCount == 7)
                        {
                            if (hiddenCommodityValue.Value == "1")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                        }
                        else if (intColumnBodyCount == 8)
                        {
                            if (hiddenCommodityValue.Value == "1")
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + " <a class=\"tooltip\"  onclick='return getdetails(this.href);' " +
                             " href=\"/AWMS/AWMS_Master/gen_Vehicle_Status_Management/gen_Vehicle_Status_Management.aspx?VhclID=" + Id + "\">" + vehiclestatusname + "</a> </td>";

                                //strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + vehiclestatusname + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + " <a class=\"tooltip\"  onclick='return getdetails(this.href);' " +
                           " href=\"/AWMS/AWMS_Master/gen_Vehicle_Status_Management/gen_Vehicle_Status_Management.aspx?VhclID=" + Id + "\">" + vehiclestatusname + "</a> </td>";
                               // strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + vehiclestatusname + "</td>";
                            }
                        }
                        else if (intColumnBodyCount == 9)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";

                        }


                    }


                  



                    if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (intCnclUsrId == 0)
                        {


                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\"   onclick='return getdetails(this.href);' " +
                                  " href=\"gen_Vehicle_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";




                        }

                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                             " href=\"gen_Vehicle_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                        }
                    }
                    if (intReCallForTAble == 0)
                    {
                        if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            if (intCnclUsrId == 0)
                            {
                                if (intCancTransaction == 0)
                                {
                                    if (HiddenSearchField.Value == "")
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                         " href=\"gen_Vehicle_Master_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                         " href=\"gen_Vehicle_Master_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                    }
                                }
                                else
                                {

                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  onclick='return CancelNotPossible();' >"
                                            + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                                }



                            }
                            else
                            {

                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                            }
                        }
                    }

                    if (intReCallForTAble == 1)
                    {
                        if (intEnableRecall == 1)
                        {
                            if (intCnclUsrId == 0)
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                            }
                            else
                            {

                                if (HiddenSearchField.Value == "")
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Re-call\" onclick='return RecallAlert(this.href);' " +
                                     " href=\"gen_Vehicle_Master_List.aspx?ReId=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Re-call\"  onclick='return RecallAlert(this.href);' " +
                                     " href=\"gen_Vehicle_Master_List.aspx?ReId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                }

                            }
                        }
                    }

                    strHtml += "</tr>";
                }
                else
                {
                    btnNext.Enabled = true;
                }
            }

        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    //for creating HTML Title
    private string SetTitle(string size, string value)
    {

        return "<h" + size + "><p align=center>" + value + "</p align></h" + size + ">";

    }

    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
    //Creating objects for business layer

   clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
    clsEntityLayerVehicleMaster objEntityVehicle = new clsEntityLayerVehicleMaster();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityVehicle.VehicleId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityVehicle.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityVehicle.Date = System.DateTime.Now;

            objEntityVehicle.CancelReason = txtCnclReason.Text.Trim();


            objBusinessVehicle.CancelVehicleMaster(objEntityVehicle);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Vehicle_Master_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Vehicle_Master_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }


    //at previous records show button click
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Set_Table(Convert.ToInt32(Button_type.Previous));
    }




    //at next records show button click
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Set_Table(Convert.ToInt32(Button_type.Next));
    }





    //prepare table set datatable
    public void Set_Table(int intButtonId)
    {
        int intUserId = 0, intUsrRolMstrId,intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        //Allocating child roles

        if (hiddenRoleAdd.Value == "1")
        {
            intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
        }
        if (hiddenRoleUpdate.Value == "1")
        {
            intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
        }
        if (hiddenRoleCancel.Value == "1")
        {
            intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
        }

        if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            divAdd.Visible = true;

        }
        else
        {

            divAdd.Visible = false;

        }

                clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
                clsEntityLayerVehicleMaster objEntityVehicle = new clsEntityLayerVehicleMaster();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehicle.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

         intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
            DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
            if (dtCancelRecall.Rows.Count > 0)
            {
                intEnableRecall = 1;
                hiddenRoleRecall.Value = "1";
            }
            else
            {
                intEnableRecall = 0;
                hiddenRoleRecall.Value = "0";
            }

        DataTable dtCategory = new DataTable();
        if (HiddenSearchField.Value == "")
        {
            objEntityVehicle.Status_id = 1;
            objEntityVehicle.CancelStatus = 0;

            dtCategory=objBusinessVehicle.ReadVehicleMasterListBySearch(objEntityVehicle);


        }

        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;
            string[] strSearchFields = strHidden.Split(',');
            string strSearchWord = strSearchFields[0];
            string strddlStatus = strSearchFields[1];
            string strCbxStatus = strSearchFields[2];
            string strVehicleClass = strSearchFields[3];

            objEntityVehicle.VehicleClassId = Convert.ToInt32(strVehicleClass);
            objEntityVehicle.SearchField = strSearchWord;
            objEntityVehicle.DataBase_Field = hiddenSearchDataBaseField.Value;
            objEntityVehicle.Status_id = Convert.ToInt32(strddlStatus);
            objEntityVehicle.CancelStatus = Convert.ToInt32(strCbxStatus);


           dtCategory=objBusinessVehicle.ReadVehicleMasterListBySearch(objEntityVehicle);


        }

        int first = 0;
        int last = 0;

        if (intButtonId == Convert.ToInt32(Button_type.Next))
        {
            first = Convert.ToInt32(hiddenNext.Value);
            last = Convert.ToInt32(hiddenNext.Value) + Convert.ToInt32(hiddenTotalRowCount.Value);
            hiddenPrevious.Value = first.ToString();
            hiddenNext.Value = last.ToString();
        }

        if (intButtonId == Convert.ToInt32(Button_type.Previous))
        {
            first = Convert.ToInt32(hiddenPrevious.Value) - Convert.ToInt32(hiddenTotalRowCount.Value);
            last = Convert.ToInt32(hiddenPrevious.Value);
            hiddenPrevious.Value = first.ToString();
            hiddenNext.Value = last.ToString();
        }
        if (first == 0)
        {
            btnPrevious.Enabled = false;

        }
        else
        {
            btnPrevious.Enabled = true;
        }
        if (last < dtCategory.Rows.Count)
        {

            btnNext.Enabled = true;
        }
        else
        {
            btnNext.Enabled = false;
        }

        string strHtm = ConvertDataTableToHTML(dtCategory, intEnableModify, intEnableCancel, intEnableRecall);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }

    //at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        btnNext.Enabled = false;
        btnPrevious.Enabled = false;
        int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
        hiddenRoleAdd.Value = "0";
        hiddenRoleUpdate.Value = "0";
        hiddenRoleCancel.Value = "0";
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
        intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
        DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
        if (dtCancelRecall.Rows.Count > 0)
        {
            intEnableRecall = 1;
            hiddenRoleRecall.Value = "1";
        }
        else
        {
            intEnableRecall = 0;
            hiddenRoleRecall.Value = "0";
        }
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Vehicle_Master);
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
                    hiddenRoleAdd.Value = "1";
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenRoleUpdate.Value = "1";
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenRoleCancel.Value = "1";
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
                divAdd.Visible = true;

            }
            else
            {

                divAdd.Visible = false;

            }

            //Creating objects for business layer
                clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
                clsEntityLayerVehicleMaster objEntityVehicle = new clsEntityLayerVehicleMaster();
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityVehicle.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityVehicle.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            string VehicleClassSearch = ddlVehicleClass.SelectedItem.Value;

            if (ddlVehicleClass.SelectedItem.Value != "--SELECT ALL CLASS--" && ddlVehicleClass.SelectedItem.Value != null)
            {
                objEntityVehicle.VehicleClassId = Convert.ToInt32(ddlVehicleClass.SelectedItem.Value);
            }
            else
            {
                objEntityVehicle.VehicleClassId = 0;

            }



            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                                   clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE,
                                                               clsCommonLibrary.CORP_GLOBAL.CMDTY_MANTN_OFFCE
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenCommodityValue.Value = dtCorpDetail.Rows[0]["CMDTY_MANTN_OFFCE"].ToString();
                string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
                string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();

                int intListingMode = Convert.ToInt32(strListingMode);

                if (intListingMode == 2)//variant
                {
                    btnNext.Text = "Show Next Records";
                    btnPrevious.Text = "Show Previous Records";
                    hiddenMemorySize.Value = strLstingModeSize;
                }
                else if (intListingMode == 1)//fixed
                {
                    btnNext.Text = "Show Next " + strLstingModeSize + " Records";
                    btnPrevious.Text = "Show Previous " + strLstingModeSize + " Records";
                    hiddenTotalRowCount.Value = strLstingModeSize;
                    hiddenNext.Value = strLstingModeSize;
                }
                hiddenPrevious.Value = "0";

            }

            //to view
            DataTable dtCategory = new DataTable();
            if (HiddenSearchField.Value == "")
            {
                objEntityVehicle.Status_id = 1;
                objEntityVehicle.CancelStatus = 0;

              dtCategory=objBusinessVehicle.ReadVehicleMasterListBySearch(objEntityVehicle);
            }

            else
            {
                string strHidden = "";
                strHidden = HiddenSearchField.Value;
                string[] strSearchFields = strHidden.Split(',');
                string strSearchWord = strSearchFields[0];
                string strddlStatus = strSearchFields[1];
                string strCbxStatus = strSearchFields[2];
                string strVehicleCls = strSearchFields[3];



                objEntityVehicle.SearchField = strSearchWord;
                objEntityVehicle.DataBase_Field = hiddenSearchDataBaseField.Value;
                objEntityVehicle.Status_id = Convert.ToInt32(strddlStatus);
                objEntityVehicle.CancelStatus = Convert.ToInt32(strCbxStatus);
                objEntityVehicle.VehicleClassId=Convert.ToInt32(strVehicleCls);

                dtCategory=objBusinessVehicle.ReadVehicleMasterListBySearch(objEntityVehicle);


            }

            string strHtm = ConvertDataTableToHTML(dtCategory, intEnableModify, intEnableCancel, intEnableRecall);
            //Write to divReport
            divReport.InnerHtml = strHtm;

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsertion", "SuccessInsertion();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                }
            }


        }
    }
}
