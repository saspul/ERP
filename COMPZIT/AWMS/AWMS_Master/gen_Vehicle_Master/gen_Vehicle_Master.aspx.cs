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


public partial class AWMS_AWMS_Master_gen_Vehicle_Master_gen_Vehicle_Master : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["PRCHS"] != null)
        {
            this.MasterPageFile = "~/MasterPage/MasterPage_Modal.master";

        }
        else
        {

            this.MasterPageFile = "~/MasterPage/MasterPageCompzit_AWMS.master";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        //Assigning  Key actions  .
        txtVehicleNumber.Attributes.Add("onkeypress", "return isTag(event)");
        txtVehicleNumber.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtDescription.Attributes.Add("onkeypress", "return isTag(event)");
        txtDescription.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtChasisNumber.Attributes.Add("onkeypress", "return isTag(event)");
        txtChasisNumber.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtEngineCapacity.Attributes.Add("onkeypress", "return isTag(event)");
        txtEngineCapacity.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtKML.Attributes.Add("onkeypress", "return isTag(event)");
        txtKML.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtPurchaseDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtPurchaseDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtCurrentMileage.Attributes.Add("onkeypress", "return isTag(event)");
        txtCurrentMileage.Attributes.Add("onchange", "IncrmntConfrmCounter()");


        txtPermitExpiryDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtPermitExpiryDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtInsurance.Attributes.Add("onkeypress", "return isTag(event)");
        txtInsurance.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtInsuranceExpiry.Attributes.Add("onkeypress", "return isTag(event)");
        txtInsuranceExpiry.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtRFIDTagNum.Attributes.Add("onkeypress", "return isTag(event)");
        txtRFIDTagNum.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtTankerCapacity.Attributes.Add("onkeypress", "return isTag(event)");
        txtTankerCapacity.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtAmountPerBarrel.Attributes.Add("onkeypress", "return isTag(event)");
        txtAmountPerBarrel.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtFuelLimit.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtFuelLimit.Attributes.Add("onkeypress", "return isTag(event)");

        txtInsuranceAmount.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtInsuranceAmount.Attributes.Add("onkeypress", "return isTag(event)");

        txtDealer.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtDealer.Attributes.Add("onkeypress", "return isTag(event)");
        ddlMake.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtModel.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtContact.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtPrice.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlInsuranceProvider.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlModalYear.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlVehicleType.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlRegiType.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlTrnsmn.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlColor.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlCoverageType.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtBedIstamara.Attributes.Add("onkeypress", "return isTag(event)");
        txtBedIstamara.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtBedInsNumber.Attributes.Add("onkeypress", "return isTag(event)");
        txtBedInsNumber.Attributes.Add("onchange", "IncrmntConfrmCounter()");


        txtTrPerExpDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtTrPerExpDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtTRinsExpDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtTRinsExpDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");


        txtTrInsAmnt.Attributes.Add("onkeypress", "return isTag(event)");
        txtTrInsAmnt.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        ddlTrInsCvrgeTyp.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlTRinsPrvdr.Attributes.Add("onchange", "IncrmntConfrmCounter()");


        if (!IsPostBack)
        {
            //btnImportCsv.Enabled = false;
            HiddenField3_FileUpload.Value = null;
            ModalYearLoad();
            VehicleClassLoad();
            FuelTypeLoad();
            VehicleTypeLoad();
            InsProviderLoad();
            InsCoverageTypeLoad();
            VehicleRegstrTypeLoad();
            VhclTransmsnLoad();
            VhclColorLoad();
            VhclMakeLoad();
            divRenewPermit.Visible = false;
            divInsuranceRenewal.Visible = false;

            divTrRnwlIconPrmt.Visible = false;
            divTRrnwlIconIns.Visible = false;

            lblInsEditNotPsbl.Visible = false;
            lblPermitRnwlNtPosible.Visible = false;

            lblTRprmtRnwlNotPos.Visible = false;
            lblTrInsRnwlPos.Visible = false;

            hiddenOpenPrmtORIns.Value = "0";
            //for common naming field
            //ddlVehicleCls.Focus();
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
                LabelPermit_Details.InnerText = strPermit + " Details*";
                //Permit_Number.InnerText = strPermit + " Number*";
                Permit_Exp_Date.InnerText = strPermit + " Expiry Date*";
            }
            divCSV.Attributes["style"] = "margin-left: 31%;margin-top: 1%;";
            clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
            clsEntityLayerVehicleMaster objEntityVehicle = new clsEntityLayerVehicleMaster();
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                if (Request.QueryString["MODE"] != null)
                {
                    hiddenOpenPrmtORIns.Value = Request.QueryString["MODE"].ToString();
                }
                if (Request.QueryString["TR"] != null)
                {
                    HiddenFieldTR.Value = Request.QueryString["TR"].ToString();
                }
               
                
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;
                hiddenVehicleIdForRenew.Value = Request.QueryString["Id"].ToString();
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                //CheckDutyRoster
                
                objEntityVehicle.VehicleId = Convert.ToInt32(strId);
                objEntityVehicle.Organisation_id= objEntityCommon.Organisation_Id;
                objEntityVehicle.Corporate_id = objEntityCommon.CorporateID;
                string strCount = "0";
                strCount=objBusinessVehicle.CheckDutyRoster(objEntityVehicle);

                Update(strId);
                if (strCount != "0")
                {
                    txtCurrentMileage.Enabled = false;
                }

                hiddenViewMode.Value = "edit";
                lblEntry.Text = "Edit Vehicle";

                
            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.Text = "View Vehicle";
            }

            else
            {
                lblEntry.Text = "Add Vehicle";
              

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;
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


           
            DataTable dtAttchmnt = new DataTable();
            dtAttchmnt = objBusinessVehicle.ReadVehicleMasterAttachment(objEntityVehicle);
            if (dtAttchmnt.Rows.Count > 0)
            {
                string strSerialnumber = dtAttchmnt.Rows[0]["VHCLIMGFLS_SLNUM"].ToString();
                hiddenAttachSerialNum.Value = strSerialnumber;
            }


            hiddenPermitFileSize.Value = clsCommonLibrary.IMAGE_SIZE.VEHICLE_ATTACHMENT.ToString();



            // created object for business layer for compare the date
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            string strCurrentDate = objBusiness.LoadCurrentDateInString();

            hiddenCurrentDate.Value = strCurrentDate;


            int intCorpId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                          clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_UNIT_DECIMAL_CNT"].ToString();
                hiddenDecimalCountMoney.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }
            objEntityCommon = new clsEntityCommon();
            // cliebt side number format
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();

            }


            if (Request.QueryString["PRCHS"] != null)
            {
                divList.Visible = false;
                btnUpdate.Visible = false;
                btnUpdate.Visible = false;
                btnAdd.Visible = false;
                btnAddClose.Visible = true;
                btnCancel.Visible = false;
            }


        }

    }
    protected void ModalYearLoad()
    {

        ddlModalYear.Items.Clear();
        // created object for business layer for compare the date
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        string[] split = strCurrentDate.Split('-');

        var currentYear = Convert.ToInt32(split[2]);
        for (int i = 20; i >= 0; i--)
        {
            // Now just add an entry that's the current year minus the counter
            ddlModalYear.Items.Add((currentYear - i).ToString());

        }
        ddlModalYear.Items.Insert(0, "--SELECT--");
    }
    protected void VehicleClassLoad(int intVehClass = 0)
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
        objEntityVehicle.VehicleClassId = intVehClass;
        string strImagePath = (objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.APP_ICON_IMAGES));
        StringBuilder sb = new StringBuilder();

        DataTable dtVehicleClass = new DataTable();
        dtVehicleClass = objBusinessVehicle.ReadVehicleClass(objEntityVehicle);
        //string strHtml = "";
        //if (dtVehicleClass.Rows.Count > 0)
        //{
        //    int intRowcount;

        //    for (intRowcount = 0; intRowcount < dtVehicleClass.Rows.Count; intRowcount++)
        //    {
        //        string ClassName = dtVehicleClass.Rows[intRowcount]["VHCLCLS_NAME"].ToString();
        //        string strImageName = dtVehicleClass.Rows[intRowcount]["GNIMGSCT_IMGNAME"].ToString();
        //        string strImageId = dtVehicleClass.Rows[intRowcount]["VHCLCLS_ID"].ToString();
        //        string VhclCtgryType = dtVehicleClass.Rows[intRowcount]["VHCL_CTGRYTYP_NAME"].ToString();
        //        strHtml += "<div class=\"divImageVehicle\" id=\"divImageVehicle-" + strImageId + "\" onclick=\"SelectVehicleClass('" + strImageId + "','" + VhclCtgryType + "');\" style=\"float:left;cursor: pointer;\">";
        //        strHtml += "<Label ID=\"lblClassName-" + strImageId + "\" style=\"color:#600;;display: block;text-align:center;width: 100%;font-family: calibri;font-size: 15px;\">" + ClassName + "</asp:Label>";

        //        strHtml += "<img style=\"margin-left: 14%;margin-top: -0.5%;padding-bottom: 2%\"  id=\"Veh-" + strImageId + "\" src=" + strImagePath + "" + strImageName + " alt=\"vehicle\" onclick=\"SelectVehicleClass('" + strImageId + "','" + VhclCtgryType + "');\" />";
        //        strHtml += "</div>";
        //    }


        //}
        //divVehicleClass.InnerHtml = strHtml;

        if (dtVehicleClass.Rows.Count > 0)
        {
            ddlVehicleCls.DataSource = dtVehicleClass;
            ddlVehicleCls.DataValueField = "VHCLCLS_ID";
            ddlVehicleCls.DataTextField = "VHCLCLS_NAME";
            ddlVehicleCls.DataBind();
            ddlVehicleCls.Items.Insert(0, "--SELECT VEHICLE CLASS--");
        }
    }

    protected void FuelTypeLoad(int Typeid = 0)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerVehicleMaster objEntityVehicle = new clsEntityLayerVehicleMaster();
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
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
        objEntityVehicle.FuelTypeId = Typeid;
        DataTable dtFuelDetails = new DataTable();
        string strImagePath = (objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.APP_ICON_IMAGES));
        StringBuilder sb = new StringBuilder();
        dtFuelDetails = objBusinessVehicle.ReadFuelType(objEntityVehicle);
        //string strHtml = "";
        //if (dtFuelDetails.Rows.Count > 0)
        //{
        //    int intRowcount;

        //    for (intRowcount = 0; intRowcount < dtFuelDetails.Rows.Count; intRowcount++)
        //    {
        //        string FuelName = dtFuelDetails.Rows[intRowcount]["FUELTYP_NAME"].ToString();
        //        string strImageName = dtFuelDetails.Rows[intRowcount]["GNIMGSCT_IMGNAME"].ToString();
        //        string strImageId = dtFuelDetails.Rows[intRowcount]["FUELTYP_ID"].ToString();
        //        strHtml += "<div class=\"divImageVehicle\" id=\"divFuel-" + strImageId + "\" onclick=\"SelectFuelType('" + strImageId + "');\" style=\"float:left;cursor: pointer;width:95%;\">";
        //        strHtml += "<Label ID=\"lblFuelName-" + strImageId + "\" style=\"color:#600;;display: block;text-align:center;width: 100%;font-family: calibri;font-size: 15px;\">" + FuelName + "</asp:Label>";

        //        strHtml += "<img style=\"margin-left: 14%;margin-top: -0.5%;padding-bottom: 2%\"  id=\"Veh-" + strImageId + "\" src=" + strImagePath + "" + strImageName + " alt=\"vehicle\" onclick=\"SelectFuelType('" + strImageId + "');\" />";
        //        strHtml += "</div>";
        //    }

        //}
        //divFuelImage.InnerHtml = strHtml;

        if (dtFuelDetails.Rows.Count > 0)
        {
            ddlFuelTyp.DataSource = dtFuelDetails;
            ddlFuelTyp.DataValueField = "FUELTYP_ID";
            ddlFuelTyp.DataTextField = "FUELTYP_NAME";
            ddlFuelTyp.DataBind();
            ddlFuelTyp.Items.Insert(0, "--SELECT FUEL TYPE--");
        }

    }


    [WebMethod]
    public static string[] VehicleImageLoad(string strVehicleClsId)
    {
        string[] result = new string[3];

        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        clsEntityLayerVehicleMaster objEntityVehicle = new clsEntityLayerVehicleMaster();

        if (strVehicleClsId != "--SELECT VEHICLE CLASS--")
        {
            objEntityVehicle.VehicleClassId = Convert.ToInt32(strVehicleClsId);
        }

        string strImagePath = (objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.APP_ICON_IMAGES));

        string strHtmlVehiclCls = "", strVehiclClsName = "";
        DataTable dtVehiclCls = objBusinessVehicle.ReadImagebyVehicleClsId(objEntityVehicle);
        if (dtVehiclCls.Rows.Count > 0)
        {
            int intRowcount;

            for (intRowcount = 0; intRowcount < dtVehiclCls.Rows.Count; intRowcount++)
            {
                string ClassName = dtVehiclCls.Rows[intRowcount]["VHCLCLS_NAME"].ToString();
                string strImageName = dtVehiclCls.Rows[intRowcount]["GNIMGSCT_IMGNAME"].ToString();
                string strImageId = dtVehiclCls.Rows[intRowcount]["VHCLCLS_ID"].ToString();
                string VhclCtgryType = dtVehiclCls.Rows[intRowcount]["VHCL_CTGRYTYP_NAME"].ToString();
                strHtmlVehiclCls += "<div class=\"divImageVehicle\" id=\"divImageVehicle-" + strImageId + "\" style=\"float:left;cursor: pointer;margin-left: 9%;width: 75%;\">";
                strHtmlVehiclCls += "<Label ID=\"lblClassName-" + strImageId + "\" style=\"color:#600;;display: block;text-align:center;width: 100%;font-family: calibri;font-size: 15px;\">Category : " + VhclCtgryType + "</asp:Label>";

                strHtmlVehiclCls += "<img style=\"margin-left: 14%;margin-top: -0.5%;padding-bottom: 2%\"  id=\"Veh-" + strImageId + "\" src=" + strImagePath + "" + strImageName + " alt=\"vehicle\" />";   
                strHtmlVehiclCls += "</div>";

                strVehiclClsName = VhclCtgryType;
            }
            result[0] = strHtmlVehiclCls;
            result[2] = strVehiclClsName;
        }

        return result;
    }

    [WebMethod]
    public static string[] FuelTypImageLoad(string strFuelTypId)
    {
        string[] result = new string[3];

        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        clsEntityLayerVehicleMaster objEntityVehicle = new clsEntityLayerVehicleMaster();

        if (strFuelTypId != "--SELECT FUEL TYPE--")
        {
            objEntityVehicle.FuelTypeId = Convert.ToInt32(strFuelTypId);
        }

        string strImagePath = (objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.APP_ICON_IMAGES));

        string strHtmlFuel = "";
        DataTable dtFueltyp = objBusinessVehicle.ReadImagebyFuelTypId(objEntityVehicle);
        if (dtFueltyp.Rows.Count > 0)
        {
            int intRowcount;

            for (intRowcount = 0; intRowcount < dtFueltyp.Rows.Count; intRowcount++)
            {
                string FuelName = dtFueltyp.Rows[intRowcount]["FUELTYP_NAME"].ToString();
                string strImageName = dtFueltyp.Rows[intRowcount]["GNIMGSCT_IMGNAME"].ToString();
                string strImageId = dtFueltyp.Rows[intRowcount]["FUELTYP_ID"].ToString();
                strHtmlFuel += "<div class=\"divImageVehicle\" id=\"divFuel-" + strImageId + "\" style=\"float:left;cursor: pointer;width:78%;margin-left: 6%;\">";
                strHtmlFuel += "<img style=\"margin-left: 14%;margin-top: -0.5%;padding-bottom: 2%\"  id=\"Veh-" + strImageId + "\" src=" + strImagePath + "" + strImageName + " alt=\"vehicle\"  />";
                strHtmlFuel += "</div>";

            }
            result[1] = strHtmlFuel;

        }

        return result;
    }

    protected void InsProviderLoad()
    {
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

        DataTable dtInsDetails = new DataTable();
        dtInsDetails = objBusinessVehicle.ReadInsuranceProvider(objEntityVehicle);
        if (dtInsDetails.Rows.Count > 0)
        {
            ddlInsuranceProvider.DataSource = dtInsDetails;
            ddlInsuranceProvider.DataValueField = "INSURPRVDR_ID";
            ddlInsuranceProvider.DataTextField = "INSURPRVDR_NAME";
            ddlInsuranceProvider.DataBind();


            ddlTRinsPrvdr.DataSource = dtInsDetails;
            ddlTRinsPrvdr.DataValueField = "INSURPRVDR_ID";
            ddlTRinsPrvdr.DataTextField = "INSURPRVDR_NAME";
            ddlTRinsPrvdr.DataBind();

        }
        ddlInsuranceProvider.Items.Insert(0, "--SELECT--");
        ddlTRinsPrvdr.Items.Insert(0, "--SELECT--");
    }

    protected void VehicleTypeLoad()
    {
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        DataTable dtVehDetails = new DataTable();
        dtVehDetails = objBusinessVehicle.ReadVehicleType();
        if (dtVehDetails.Rows.Count > 0)
        {
            ddlVehicleType.DataSource = dtVehDetails;
            ddlVehicleType.DataValueField = "VHCLTYP_ID";
            ddlVehicleType.DataTextField = "VHCLTYP_NAME";
            ddlVehicleType.DataBind();
            ddlVehicleType.Items.Insert(0, "--SELECT--");
        }
    }

    protected void VehicleRegstrTypeLoad()
    {
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        DataTable dtVehDetails = new DataTable();
        dtVehDetails = objBusinessVehicle.ReadRegistrationType();
        if (dtVehDetails.Rows.Count > 0)
        {
            ddlRegiType.DataSource = dtVehDetails;
            ddlRegiType.DataValueField = "VHCLREGTYP_ID";
            ddlRegiType.DataTextField = "VHCLREGTYP_NAME";
            ddlRegiType.DataBind();
            ddlRegiType.Items.Insert(0, "--SELECT--");
        }
    }

    protected void VhclTransmsnLoad()
    {
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        DataTable dtVehDetails = new DataTable();
        dtVehDetails = objBusinessVehicle.ReadVhclTransmsn();
        if (dtVehDetails.Rows.Count > 0)
        {
            ddlTrnsmn.DataSource = dtVehDetails;
            ddlTrnsmn.DataValueField = "TRNSMTYP_ID";
            ddlTrnsmn.DataTextField = "TRNSMTYP_NAME";
            ddlTrnsmn.DataBind();
            ddlTrnsmn.Items.Insert(0, "--SELECT--");
        }
    }

    protected void VhclMakeLoad()
    {
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        DataTable dtVehDetails = new DataTable();
        dtVehDetails = objBusinessVehicle.ReadVhclMake();
        if (dtVehDetails.Rows.Count > 0)
        {
            ddlMake.DataSource = dtVehDetails;
            ddlMake.DataValueField = "MAKETYP_ID";
            ddlMake.DataTextField = "MAKETYP_NAME";
            ddlMake.DataBind();
            ddlMake.Items.Insert(0, "--SELECT--");
        }
    }

    protected void VhclColorLoad()
    {
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        DataTable dtVehDetails = new DataTable();
        dtVehDetails = objBusinessVehicle.ReadVhclColor();
        if (dtVehDetails.Rows.Count > 0)
        {
            ddlColor.DataSource = dtVehDetails;
            ddlColor.DataValueField = "COLOR_ID";
            ddlColor.DataTextField = "COLOR_NAME";
            ddlColor.DataBind();
            ddlColor.Items.Insert(0, "--SELECT--");
        }
    }
    protected void InsCoverageTypeLoad()
    {
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        DataTable dtVehDetails = new DataTable();
        dtVehDetails = objBusinessVehicle.ReadInsCoverageType();
        if (dtVehDetails.Rows.Count > 0)
        {
            ddlCoverageType.DataSource = dtVehDetails;
            ddlCoverageType.DataValueField = "COVRGTYP_ID";
            ddlCoverageType.DataTextField = "COVRGTYP_NAME";
            ddlCoverageType.DataBind();


            ddlTrInsCvrgeTyp.DataSource = dtVehDetails;
            ddlTrInsCvrgeTyp.DataValueField = "COVRGTYP_ID";
            ddlTrInsCvrgeTyp.DataTextField = "COVRGTYP_NAME";
            ddlTrInsCvrgeTyp.DataBind();
        }
        ddlCoverageType.Items.Insert(0, "--SELECT--");
        ddlTrInsCvrgeTyp.Items.Insert(0, "--SELECT--");
    }
    public class clsVhclDataDELETEAttchmnt
    {
        public string FILENAME { get; set; }

        public string DTLID { get; set; }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        clsEntityLayerVehicleMaster objEntityVehicle = new clsEntityLayerVehicleMaster();
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null)
        {

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

            if (Session["USERID"] != null)
            {
                objEntityVehicle.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityVehicle.Status_id = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityVehicle.Status_id = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strVehicleId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityVehicle.VehicleId = Convert.ToInt32(strVehicleId);

            if (hiddenVehicleClassId.Value != "" && hiddenVehicleClassId.Value != "--SELECT VEHICLE CLASS--")
            {
                objEntityVehicle.VehicleClassId = Convert.ToInt32(hiddenVehicleClassId.Value);
            }
            if (hiddenFuelTypeId.Value != "" && hiddenFuelTypeId.Value != "--SELECT FUEL TYPE--")
            {
                objEntityVehicle.FuelTypeId = Convert.ToInt32(hiddenFuelTypeId.Value);
            }


            objEntityVehicle.VehicleNumber = txtVehicleNumber.Text.Trim().ToUpper();
           // objEntityVehicle.PermitNumber = txtPermitNumber.Text.Trim().ToUpper();
            objEntityVehicle.PermitExpiryDate = objCommon.textToDateTime(txtPermitExpiryDate.Text.Trim());
            objEntityVehicle.Description = txtDescription.Text.Trim();
            objEntityVehicle.ModalYear = Convert.ToInt32(ddlModalYear.SelectedItem.Text);

            objEntityVehicle.RegTypeId = Convert.ToInt32(ddlRegiType.SelectedItem.Value);
            objEntityVehicle.RfIdTagNum = txtRFIDTagNum.Text.Trim();
            if (txtFuelLimit.Text.Trim() != "" && txtFuelLimit.Text.Trim() != null)
            {
                objEntityVehicle.FuelLimit = Convert.ToDecimal(txtFuelLimit.Text.Trim());
            }

            if (hiddenCategoryName.Value == "TANKER")
            {
                objEntityVehicle.IsTanker = 1;
                objEntityVehicle.TankCapacity = Convert.ToDecimal(txtTankerCapacity.Text);
                objEntityVehicle.AmountPerBarrel = Convert.ToDecimal(txtAmountPerBarrel.Text);
            }
            else
            {
                objEntityVehicle.IsTanker = 0;
            }

            objEntityVehicle.VehicleTypeId = Convert.ToInt32(ddlVehicleType.SelectedItem.Value);
            objEntityVehicle.VehPurchaseDate = objCommon.textToDateTime(txtPurchaseDate.Text);

            if (txtEngineCapacity.Text != "" && txtEngineCapacity.Text != null)
            {
                objEntityVehicle.EngineCapacity = Convert.ToDecimal(txtEngineCapacity.Text);
            }

            if (txtKML.Text != "" && txtKML.Text != null)
            {
                objEntityVehicle.KilometerPerLitre = Convert.ToDecimal(txtKML.Text.Trim());
            }
            if (txtChasisNumber.Text != "" && txtChasisNumber.Text != null)
            {
                objEntityVehicle.ChasisNumber = txtChasisNumber.Text.Trim().ToUpper();
            }

            if (txtCurrentMileage.Text != "" && txtCurrentMileage.Text != null)
            {
                objEntityVehicle.Mileage = Convert.ToDecimal(txtCurrentMileage.Text.Trim());
            }
            if (txtInsuranceExpiry.Text != "" && txtInsuranceExpiry.Text != null)
            {
                objEntityVehicle.InsuranceExpirydate = objCommon.textToDateTime(txtInsuranceExpiry.Text);
            }

            objEntityVehicle.Insurance = txtInsurance.Text.Trim();
            if (ddlInsuranceProvider.SelectedItem.Value != "--SELECT--" && ddlInsuranceProvider.SelectedItem.Value != null)
            {
                objEntityVehicle.InsureProviderId = Convert.ToInt32(ddlInsuranceProvider.SelectedItem.Value);
            }
            if (txtInsuranceAmount.Text != "" && txtInsuranceAmount.Text != null)
            {
                objEntityVehicle.InsuranceAmount = Convert.ToDecimal(txtInsuranceAmount.Text.Trim());
            }

           
            if (ddlTrnsmn.SelectedItem.Value != "--SELECT--" && ddlTrnsmn.SelectedItem.Value != null)
            {
                objEntityVehicle.TransmsnTypeId = Convert.ToInt32(ddlTrnsmn.SelectedItem.Value);
            }
           
            if (ddlColor.SelectedItem.Value != "--SELECT--" && ddlColor.SelectedItem.Value != null)
            {
                objEntityVehicle.ColorId = Convert.ToInt32(ddlColor.SelectedItem.Value);
            }

            if (ddlMake.SelectedItem.Value != "--SELECT--" && ddlMake.SelectedItem.Value != null)
            {
                objEntityVehicle.Make = Convert.ToInt32(ddlMake.SelectedItem.Value);
            }
             
            objEntityVehicle.Model = txtModel.Text.Trim().ToUpper();
            if (txtDealer.Text != "" && txtDealer.Text != null)
            {
                objEntityVehicle.DealerName = txtDealer.Text.Trim().ToUpper();
            }
            if (txtContact.Text != "" && txtContact.Text != null)
            {
                objEntityVehicle.ContactNo = txtContact.Text.Trim();
            }
            if (txtPrice.Text != "" && txtPrice.Text != null)
            {
                objEntityVehicle.Price = Convert.ToDecimal(txtPrice.Text.Trim());
            }
            if (ddlCoverageType.SelectedItem.Value != "--SELECT--" && ddlCoverageType.SelectedItem.Value != null)
            {
                objEntityVehicle.CoverageTypeId = Convert.ToInt32(ddlCoverageType.SelectedItem.Value);
            }
            if (hiddenCategoryName.Value == "TRAILER")
            {

                objEntityVehicle.TrailerRegNum = txtBedIstamara.Text.Trim();
                objEntityVehicle.TrailerInsNum = txtBedInsNumber.Text.Trim();

                objEntityVehicle.TRregstrnExpDate = objCommon.textToDateTime(txtTrPerExpDate.Text);
                if (ddlTRinsPrvdr.SelectedItem.Value != "--SELECT--" && ddlTRinsPrvdr.SelectedItem.Value != null && ddlTRinsPrvdr.SelectedItem.Value != "")
                {
                    objEntityVehicle.TRinsrncePrvdrId = Convert.ToInt32(ddlTRinsPrvdr.SelectedItem.Value);
                }
                if (ddlTrInsCvrgeTyp.SelectedItem.Value != "--SELECT--" && ddlTrInsCvrgeTyp.SelectedItem.Value != null && ddlTrInsCvrgeTyp.SelectedItem.Value != "")
                {
                    objEntityVehicle.TRinsrnceCvrgTypId = Convert.ToInt32(ddlTrInsCvrgeTyp.SelectedItem.Value);
                }
                objEntityVehicle.TRinsrnceExpDate = objCommon.textToDateTime(txtTRinsExpDate.Text);
                objEntityVehicle.TRinsuranceAmnt = Convert.ToDecimal(txtTrInsAmnt.Text);
            }


            //Checking is there table have any name like this
            string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);
        

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.VEHICLE_MASTER);
            objEntityCommon.CorporateID = objEntityVehicle.Corporate_id;
            objEntityCommon.Organisation_Id = objEntityVehicle.Organisation_id;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            objEntityVehicle.NextIdForVehicle = Convert.ToInt32(strNextId);
           



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

                int intSlNumbr = 0;
                if (hiddenAttchmntPrmtSlNumber.Value != "")
                {
                    intSlNumbr = Convert.ToInt32(hiddenAttchmntPrmtSlNumber.Value);
                    intSlNumbr++;

                }



                for (int count = 0; count < objTVDataList.Count; count++)
                {
                    if (objTVDataList[count] != null)
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
                                    int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);
                                    objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = intSlNumbr;
                                    string strImageName = "PERMIT_" + intImageSection.ToString() + "_" + objEntityVehicle.NextIdForVehicle.ToString() + "_" + intSlNumbr + "." + strFileExt;
                                    objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                                    string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);

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
                        intSlNumbr++;

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


                int intSlNumbr1 = 0;
                if (hiddenAttchmntInsurSlNumber.Value != "")
                {
                    intSlNumbr1 = Convert.ToInt32(hiddenAttchmntInsurSlNumber.Value);
                    intSlNumbr1++;

                }

                for (int count = 0; count < objTVDataList1.Count; count++)
                {

                    if (objTVDataList1[count] != null)
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
                                    int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);
                                    objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = intSlNumbr1;
                                    string strImageName = "INSUR_" + intImageSection.ToString() + "_" + objEntityVehicle.NextIdForVehicle.ToString() + "_" + intSlNumbr1 + "." + strFileExt;
                                    objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                                    string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);

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
                        intSlNumbr1++;
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

                int intSlNumbr2 = 0;
                if (hiddenAttchmntVhclSlNumber.Value != "")
                {
                    intSlNumbr2 = Convert.ToInt32(hiddenAttchmntVhclSlNumber.Value);
                    intSlNumbr2++;

                }

                for (int count = 0; count < objTVDataList2.Count; count++)
                {
                    if (objTVDataList2[count] != null)
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
                                    int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);
                                    objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = intSlNumbr2;
                                    string strImageName = "VHCL_" + intImageSection.ToString() + "_" + objEntityVehicle.NextIdForVehicle.ToString() + "_" + intSlNumbr2 + "." + strFileExt;
                                    objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                                    string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);

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
                        intSlNumbr2++;
                    }
                }

            }






            //Start:-For trailer attachment

            jsonData = HiddenField5_FileUpload.Value;
            c = jsonData.Replace("\"{", "\\{");
            d = c.Replace("\\n", "\r\n");
            g = d.Replace("\\", "");
            h = g.Replace("}\"]", "}]");
            i = h.Replace("}\",", "},");

            List<clsAtchmntData> objTVDataList6 = new List<clsAtchmntData>();
            objTVDataList6 = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);

            List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPerAttchmntDeatilsListTR = new List<clsEntityInsuranceAndPermitAttchmntDtl>();
            if (HiddenField5_FileUpload.Value != "" && HiddenField5_FileUpload.Value != null)
            {
                int intSlNumbr2 = 0;
                if (hiddenAttchmntPrmtSlNumberTR.Value != "")
                {
                    intSlNumbr2 = Convert.ToInt32(hiddenAttchmntPrmtSlNumberTR.Value);
                    intSlNumbr2++;

                }

                for (int count = 0; count < objTVDataList6.Count; count++)
                {
                    if (objTVDataList6[count] != null)
                    {
                        string jsonFileid = "file" + objTVDataList6[count].ROWID;
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
                                    int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);
                                    objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = intSlNumbr2;
                                    string strImageName = "TR_PER_" + intImageSection.ToString() + "_" + objEntityVehicle.NextIdForVehicle.ToString() + "_" + count + "." + strFileExt;
                                    objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                                    string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);

                                    PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityRnwlDetailsAttchmnt.FileName);
                                    if (objTVDataList6[count].DESCRPTN != "--Description--")
                                    {
                                        objEntityRnwlDetailsAttchmnt.Description = objTVDataList6[count].DESCRPTN;
                                    }
                                    objEntityPerAttchmntDeatilsListTR.Add(objEntityRnwlDetailsAttchmnt);



                                }
                            }
                        }
                        intSlNumbr2++;
                    }
                }
            }





            jsonData = HiddenField6_FileUpload.Value;
            c = jsonData.Replace("\"{", "\\{");
            d = c.Replace("\\n", "\r\n");
            g = d.Replace("\\", "");
            h = g.Replace("}\"]", "}]");
            i = h.Replace("}\",", "},");

            List<clsAtchmntData> objTVDataList7 = new List<clsAtchmntData>();
            objTVDataList7 = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);

            List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsAttchmntDeatilsListTR = new List<clsEntityInsuranceAndPermitAttchmntDtl>();
            if (HiddenField6_FileUpload.Value != "" && HiddenField6_FileUpload.Value != null)
            {
                int intSlNumbr2 = 0;
                if (hiddenAttchmntInsurSlNumberTR.Value != "")
                {
                    intSlNumbr2 = Convert.ToInt32(hiddenAttchmntInsurSlNumberTR.Value);
                    intSlNumbr2++;

                }

                for (int count = 0; count < objTVDataList7.Count; count++)
                {
                    if (objTVDataList7[count] != null)
                    {
                        string jsonFileid = "file" + objTVDataList7[count].ROWID;
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
                                    int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);
                                    objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = intSlNumbr2;
                                    string strImageName = "TR_INS_" + intImageSection.ToString() + "_" + objEntityVehicle.NextIdForVehicle.ToString() + "_" + count + "." + strFileExt;
                                    objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                                    string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);

                                    PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityRnwlDetailsAttchmnt.FileName);
                                    if (objTVDataList7[count].DESCRPTN != "--Description--")
                                    {
                                        objEntityRnwlDetailsAttchmnt.Description = objTVDataList7[count].DESCRPTN;
                                    }
                                    objEntityInsAttchmntDeatilsListTR.Add(objEntityRnwlDetailsAttchmnt);



                                }
                            }
                        }
                        intSlNumbr2++;
                    }
                }
            }
            //End:-For trailer attachment


           

            string strNameCount = objBusinessVehicle.CheckVehicleNumber(objEntityVehicle);
           // string strPermitCount = objBusinessVehicle.CheckPermitNumber(objEntityVehicle);
            string strRFIDCount = objBusinessVehicle.CheckRF_IdNumber(objEntityVehicle);
            string strInsureCount = objBusinessVehicle.CheckInsuranceNumber(objEntityVehicle);
            string strChasisCount;
            if (txtChasisNumber.Text != "" && txtChasisNumber.Text != null)
            {
                strChasisCount = objBusinessVehicle.CheckChasisNumber(objEntityVehicle);
            }
            else
            {
                strChasisCount = "0";
            }

        string strTrailerRegCount;
        string strTrailerInsCount;

        if (txtBedIstamara.Text != "" && txtBedIstamara.Text != null)
        {
            strTrailerRegCount = objBusinessVehicle.CheckTrailerNumber(objEntityVehicle);
        }
        else
        {
            strTrailerRegCount = "0";
        }


        if (txtBedInsNumber.Text != "" && txtBedInsNumber.Text != null)
        {
            strTrailerInsCount = objBusinessVehicle.CheckTrailerInsNumber(objEntityVehicle);
        }
        else
        {
            strTrailerInsCount = "0";
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

           


            strCanclDtlId = "";
            strarrCancldtlIds = strCanclDtlId.Split(',');
            if (hiddenPerFileCanclDtlIdTR.Value != "" && hiddenPerFileCanclDtlIdTR.Value != null)
            {
                strCanclDtlId = hiddenPerFileCanclDtlIdTR.Value;
                strarrCancldtlIds = strCanclDtlId.Split(',');

            }

            List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPerDeleteAttchmntDeatilsListTR = new List<clsEntityInsuranceAndPermitAttchmntDtl>();

            if (hiddenPerFileCanclDtlIdTR.Value != "" && hiddenPerFileCanclDtlIdTR.Value != null)
            {
                string jsonDataDltAttch = hiddenPerFileCanclDtlIdTR.Value;
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
                    objEntityPerDeleteAttchmntDeatilsListTR.Add(objEntityRnwlDetailsAttchmnt);


                }
            }






          
            strCanclDtlId = "";
            strarrCancldtlIds = strCanclDtlId.Split(',');
            if (hiddenInsFileCanclDtlIdTR.Value != "" && hiddenInsFileCanclDtlIdTR.Value != null)
            {
                strCanclDtlId = hiddenInsFileCanclDtlIdTR.Value;
                strarrCancldtlIds = strCanclDtlId.Split(',');

            }

            List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsDeleteAttchmntDeatilsListTR = new List<clsEntityInsuranceAndPermitAttchmntDtl>();

            if (hiddenInsFileCanclDtlIdTR.Value != "" && hiddenInsFileCanclDtlIdTR.Value != null)
            {
                string jsonDataDltAttch = hiddenInsFileCanclDtlIdTR.Value;
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

                    objEntityInsDeleteAttchmntDeatilsListTR.Add(objEntityRnwlDetailsAttchmnt);


                }
            }

            //end-for deleting attached files

             
       

            //If there is no name like this on table.    
            if (strNameCount == "0" && strInsureCount == "0" && strChasisCount == "0" && strRFIDCount == "0" && strTrailerInsCount == "0" && strTrailerRegCount == "0")
            {
                objBusinessVehicle.UpdateVehicleMaster(objEntityVehicle, objEntityPermitAttchmntDeatilsList, objEntityInsurAttchmntDeatilsList, objEntityVhclAttchmntDeatilsList, objEntityPerDeleteAttchmntDeatilsList, objEntityInsDeleteAttchmntDeatilsList, objEntityVhclDeleteAttchmntDeatilsList, objEntityPerAttchmntDeatilsListTR, objEntityInsAttchmntDeatilsListTR, objEntityPerDeleteAttchmntDeatilsListTR, objEntityInsDeleteAttchmntDeatilsListTR);





                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_Vehicle_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Vehicle_Master_List.aspx?InsUpd=Upd");
                }

            }
            //If have
            else
            {
                if (strNameCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

                }
                else if (strChasisCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationChasis", "DuplicationChasis();", true);

                }
                else if (strRFIDCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationRFid", "DuplicationRFid();", true);

                }
            
                else if (strInsureCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationInsurance", "DuplicationInsurance();", true);

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
    }
    public class clsAtchmntData
    {

        public string ROWID { get; set; }
        public string FILEPATH { get; set; }
        public string DESCRPTN { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }

    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        clsEntityLayerVehicleMaster objEntityVehicle = new clsEntityLayerVehicleMaster();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
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

        if (Session["USERID"] != null)
        {
            objEntityVehicle.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (hiddenVehicleClassId.Value != "" && hiddenVehicleClassId.Value != "--SELECT VEHICLE CLASS--")
        {
            objEntityVehicle.VehicleClassId = Convert.ToInt32(hiddenVehicleClassId.Value);
        }
        if (hiddenFuelTypeId.Value != "" && hiddenFuelTypeId.Value != "--SELECT FUEL TYPE--")
        {
            objEntityVehicle.FuelTypeId = Convert.ToInt32(hiddenFuelTypeId.Value);
        }
        objEntityVehicle.VehicleNumber = txtVehicleNumber.Text.Trim().ToUpper();
        objEntityVehicle.Description = txtDescription.Text.Trim();
       // objEntityVehicle.PermitNumber = txtPermitNumber.Text.Trim().ToUpper();
        objEntityVehicle.RegTypeId = Convert.ToInt32(ddlRegiType.SelectedItem.Value);
        objEntityVehicle.Make = Convert.ToInt32(ddlMake.SelectedItem.Value);

        objEntityVehicle.RfIdTagNum = txtRFIDTagNum.Text.Trim();
        if (txtFuelLimit.Text.Trim() != "" && txtFuelLimit.Text.Trim() != null)
        {
            objEntityVehicle.FuelLimit = Convert.ToDecimal(txtFuelLimit.Text.Trim());
        }

        if (hiddenCategoryName.Value == "TANKER")
        {
            objEntityVehicle.IsTanker = 1;
            objEntityVehicle.TankCapacity = Convert.ToDecimal(txtTankerCapacity.Text);
            objEntityVehicle.AmountPerBarrel = Convert.ToDecimal(txtAmountPerBarrel.Text);
        }
        else
        {
            objEntityVehicle.IsTanker = 0;
        }

        if (txtPermitExpiryDate.Text != "" && txtPermitExpiryDate.Text != null)
        {
            objEntityVehicle.PermitExpiryDate = objCommon.textToDateTime(txtPermitExpiryDate.Text);
        }
        if (txtEngineCapacity.Text != "" && txtEngineCapacity.Text != null)
        {
            objEntityVehicle.EngineCapacity = Convert.ToDecimal(txtEngineCapacity.Text);
        }
        objEntityVehicle.ModalYear = Convert.ToInt32(ddlModalYear.SelectedItem.Text);
        if (txtKML.Text != "" && txtKML.Text != null)
        {
            objEntityVehicle.KilometerPerLitre = Convert.ToDecimal(txtKML.Text.Trim());
        }
        if (txtChasisNumber.Text != "" && txtChasisNumber.Text != null)
        {
            objEntityVehicle.ChasisNumber = txtChasisNumber.Text.Trim().ToUpper();
        }
        objEntityVehicle.VehicleTypeId = Convert.ToInt32(ddlVehicleType.SelectedItem.Value);
        objEntityVehicle.VehPurchaseDate = objCommon.textToDateTime(txtPurchaseDate.Text);
        if (txtCurrentMileage.Text != "" && txtCurrentMileage.Text != null)
        {
            objEntityVehicle.Mileage = Convert.ToDecimal(txtCurrentMileage.Text.Trim());
        }
        if (txtInsuranceExpiry.Text != "" && txtInsuranceExpiry.Text != null)
        {
            objEntityVehicle.InsuranceExpirydate = objCommon.textToDateTime(txtInsuranceExpiry.Text);
        }

        objEntityVehicle.Insurance = txtInsurance.Text.Trim();
        if (ddlInsuranceProvider.SelectedItem.Value != "--SELECT--" && ddlInsuranceProvider.SelectedItem.Value != null)
        {
            objEntityVehicle.InsureProviderId = Convert.ToInt32(ddlInsuranceProvider.SelectedItem.Value);
        }

        if (txtInsuranceAmount.Text != "" && txtInsuranceAmount.Text != null)
        {
            objEntityVehicle.InsuranceAmount = Convert.ToDecimal(txtInsuranceAmount.Text.Trim());
        }
        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityVehicle.Status_id = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityVehicle.Status_id = 0;
        }



        if (ddlTrnsmn.SelectedItem.Value != "--SELECT--" && ddlTrnsmn.SelectedItem.Value != null)
        {
            objEntityVehicle.TransmsnTypeId = Convert.ToInt32(ddlTrnsmn.SelectedItem.Value);
        }
        if (ddlColor.SelectedItem.Value != "--SELECT--" && ddlColor.SelectedItem.Value != null)
        {
            objEntityVehicle.ColorId = Convert.ToInt32(ddlColor.SelectedItem.Value);
        }
         
        objEntityVehicle.Model = txtModel.Text.Trim().ToUpper();
        if (txtDealer.Text != "" && txtDealer.Text != null)
        {
            objEntityVehicle.DealerName = txtDealer.Text.Trim().ToUpper();
        }
        if (txtContact.Text != "" && txtContact.Text != null)
        {
            objEntityVehicle.ContactNo = txtContact.Text.Trim();
        }
        if (txtPrice.Text != "" && txtPrice.Text != null)
        {
            objEntityVehicle.Price = Convert.ToDecimal(txtPrice.Text.Trim());
        }
        if (ddlCoverageType.SelectedItem.Value != "--SELECT--" && ddlCoverageType.SelectedItem.Value != null)
        {
            objEntityVehicle.CoverageTypeId = Convert.ToInt32(ddlCoverageType.SelectedItem.Value);
        }


        if (hiddenCategoryName.Value == "TRAILER")
        {
            
            objEntityVehicle.TrailerRegNum = txtBedIstamara.Text.Trim();
            objEntityVehicle.TrailerInsNum = txtBedInsNumber.Text.Trim();

            objEntityVehicle.TRregstrnExpDate = objCommon.textToDateTime(txtTrPerExpDate.Text);
            if (ddlTRinsPrvdr.SelectedItem.Value != "--SELECT--" && ddlTRinsPrvdr.SelectedItem.Value != null && ddlTRinsPrvdr.SelectedItem.Value != "")
            {
                objEntityVehicle.TRinsrncePrvdrId = Convert.ToInt32(ddlTRinsPrvdr.SelectedItem.Value);
            }
            if (ddlTrInsCvrgeTyp.SelectedItem.Value != "--SELECT--" && ddlTrInsCvrgeTyp.SelectedItem.Value != null && ddlTrInsCvrgeTyp.SelectedItem.Value != "")
            {
                objEntityVehicle.TRinsrnceCvrgTypId = Convert.ToInt32(ddlTrInsCvrgeTyp.SelectedItem.Value);
            }
            objEntityVehicle.TRinsrnceExpDate = objCommon.textToDateTime(txtTRinsExpDate.Text);
            objEntityVehicle.TRinsuranceAmnt = Convert.ToDecimal(txtTrInsAmnt.Text);
        }


        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.VEHICLE_MASTER);
        objEntityCommon.CorporateID = objEntityVehicle.Corporate_id;
        objEntityCommon.Organisation_Id = objEntityVehicle.Organisation_id;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        objEntityVehicle.NextIdForVehicle = Convert.ToInt32(strNextId);

     
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
                                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);
                                objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = count;
                                string strImageName = "PERMIT_" + intImageSection.ToString() + "_" + objEntityVehicle.NextIdForVehicle.ToString() + "_" + count + "." + strFileExt;
                                objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);

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
                            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);
                            objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = count;
                            string strImageName = "INSUR_" + intImageSection.ToString() + "_" + objEntityVehicle.NextIdForVehicle.ToString() + "_" + count + "." + strFileExt;
                            objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);

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
                                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);
                                objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = count;
                                string strImageName = "VHCL_" + intImageSection.ToString() + "_" + objEntityVehicle.NextIdForVehicle.ToString() + "_" + count + "." + strFileExt;
                                objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);

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

  //Start:-For trailer attachment

        jsonData = HiddenField5_FileUpload.Value;
        c = jsonData.Replace("\"{", "\\{");
        d = c.Replace("\\n", "\r\n");
        g = d.Replace("\\", "");
        h = g.Replace("}\"]", "}]");
        i = h.Replace("}\",", "},");

        List<clsAtchmntData> objTVDataList6 = new List<clsAtchmntData>();
        objTVDataList6 = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);

        List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityPerAttchmntDeatilsListTR = new List<clsEntityInsuranceAndPermitAttchmntDtl>();
        if (HiddenField5_FileUpload.Value != "" && HiddenField5_FileUpload.Value != null)
        {

            for (int count = 0; count < objTVDataList6.Count; count++)
            {
                string jsonFileid = "file" + objTVDataList6[count].ROWID;
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
                            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);
                            objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = count;
                            string strImageName = "TR_PER_" + intImageSection.ToString() + "_" + objEntityVehicle.NextIdForVehicle.ToString() + "_" + count + "." + strFileExt;
                            objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);

                            PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityRnwlDetailsAttchmnt.FileName);
                            if (objTVDataList6[count].DESCRPTN != "--Description--")
                            {
                                objEntityRnwlDetailsAttchmnt.Description = objTVDataList6[count].DESCRPTN;
                            }
                            objEntityPerAttchmntDeatilsListTR.Add(objEntityRnwlDetailsAttchmnt);

                          

                        }
                    }
                }
            }
        }





        jsonData = HiddenField6_FileUpload.Value;
        c = jsonData.Replace("\"{", "\\{");
        d = c.Replace("\\n", "\r\n");
        g = d.Replace("\\", "");
        h = g.Replace("}\"]", "}]");
        i = h.Replace("}\",", "},");

        List<clsAtchmntData> objTVDataList7 = new List<clsAtchmntData>();
        objTVDataList7 = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);

        List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityInsAttchmntDeatilsListTR = new List<clsEntityInsuranceAndPermitAttchmntDtl>();
        if (HiddenField6_FileUpload.Value != "" && HiddenField6_FileUpload.Value != null)
        {

            for (int count = 0; count < objTVDataList7.Count; count++)
            {
                string jsonFileid = "file" + objTVDataList7[count].ROWID;
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
                            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);
                            objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = count;
                            string strImageName = "TR_INS_" + intImageSection.ToString() + "_" + objEntityVehicle.NextIdForVehicle.ToString() + "_" + count + "." + strFileExt;
                            objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);

                            PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityRnwlDetailsAttchmnt.FileName);
                            if (objTVDataList7[count].DESCRPTN != "--Description--")
                            {
                                objEntityRnwlDetailsAttchmnt.Description = objTVDataList7[count].DESCRPTN;
                            }
                            objEntityInsAttchmntDeatilsListTR.Add(objEntityRnwlDetailsAttchmnt);

                          

                        }
                    }
                }
            }
        }
  //End:-For trailer attachment
        //Checking is there table have any name like this
        string strNameCount = objBusinessVehicle.CheckVehicleNumber(objEntityVehicle);
       // string strPermitCount = objBusinessVehicle.CheckPermitNumber(objEntityVehicle);
        string strRFIDCount = objBusinessVehicle.CheckRF_IdNumber(objEntityVehicle);
        string strInsureCount = objBusinessVehicle.CheckInsuranceNumber(objEntityVehicle);
        
       
        string strChasisCount;
        
        if (txtChasisNumber.Text != "" && txtChasisNumber.Text != null)
        {
            strChasisCount = objBusinessVehicle.CheckChasisNumber(objEntityVehicle);
        }
        else
        {
            strChasisCount = "0";
        }

        string strTrailerRegCount;
        string strTrailerInsCount;

        if (txtBedIstamara.Text != "" && txtBedIstamara.Text != null)
        {
            strTrailerRegCount = objBusinessVehicle.CheckTrailerNumber(objEntityVehicle);
        }
        else
        {
            strTrailerRegCount = "0";
        }


        if (txtBedInsNumber.Text != "" && txtBedInsNumber.Text != null)
        {
            strTrailerInsCount = objBusinessVehicle.CheckTrailerInsNumber(objEntityVehicle);
        }
        else
        {
            strTrailerInsCount = "0";
        }

        //If there is no name like this on table.    
        if (strNameCount == "0" && strInsureCount == "0" && strChasisCount == "0" && strRFIDCount == "0" && strTrailerInsCount == "0" && strTrailerRegCount == "0")
        {
            objBusinessVehicle.AddVehicleMaster(objEntityVehicle, objEntityPermitAttchmntDeatilsList, objEntityInsurAttchmntDeatilsList, objEntityVhclAttchmntDeatilsList, objEntityPerAttchmntDeatilsListTR, objEntityInsAttchmntDeatilsListTR);

            //for add file to folder
            string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);

            if (Request.QueryString["PRCHS"] == "VEHROW")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedVehicleId", "PassSavedVehicleId('" + objEntityVehicle.NextIdForVehicle + "','" + objEntityVehicle.VehicleNumber + "','" + Request.QueryString["ROW"].ToString() + "');", true);
            }
            else
            {
                if (clickedButton.ID == "btnAdd")
                {
                    Response.Redirect("gen_Vehicle_Master.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose")
                {
                    Response.Redirect("gen_Vehicle_Master_List.aspx?InsUpd=Ins");
                }
            }

        }
        //If have
        else
        {
            if (strNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

            }
            else if (strChasisCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationChasis", "DuplicationChasis();", true);

            }
            else if (strRFIDCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationRFid", "DuplicationRFid();", true);

            }
            /*else if (strPermitCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationPermit", "DuplicationPermit();", true);

            }*/
            else if (strInsureCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationInsurance", "DuplicationInsurance();", true);

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


    public void View(string strDId)
    {
        InsProviderLoad();
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        clsEntityLayerVehicleMaster objEntityVehicle = new clsEntityLayerVehicleMaster();
        hiddenView.Value = "View";
        objEntityVehicle.VehicleId = Convert.ToInt32(strDId);
        DataTable dtVehicleDetail = new DataTable();
        dtVehicleDetail = objBusinessVehicle.ReadVehicleDetailsById(objEntityVehicle);
        DataTable dtVehicleStsDetail = new DataTable();
        dtVehicleStsDetail = objBusinessVehicle.ReadVehicleSts(objEntityVehicle);
        //After fetch insurance details in datatable,we need to differentiate.
        if (dtVehicleDetail.Rows.Count > 0)
        {
            txtVehicleNumber.Text = dtVehicleDetail.Rows[0]["VHCL_NUMBR"].ToString();
            txtDescription.Text = dtVehicleDetail.Rows[0]["VHCL_DESCRIPTION"].ToString();
            txtEngineCapacity.Text = dtVehicleDetail.Rows[0]["VHCL_ENGINE_CPCTY"].ToString();
            txtKML.Text = dtVehicleDetail.Rows[0]["VHCL_KMPL"].ToString();
            txtChasisNumber.Text = dtVehicleDetail.Rows[0]["VHCL_CHASIS_NUM"].ToString();
            txtPurchaseDate.Text = dtVehicleDetail.Rows[0]["VHCL_PRCH_DATE"].ToString();
            txtCurrentMileage.Text = dtVehicleDetail.Rows[0]["VHCL_CRNT_MILEAGE"].ToString();
            // txtPermitNumber.Text = dtVehicleDetail.Rows[0]["VHCL_PERMIT_NUMBR"].ToString();
            txtPermitExpiryDate.Text = dtVehicleDetail.Rows[0]["VHCL_PERMIT_EXPR_DATE"].ToString();
            txtInsurance.Text = dtVehicleDetail.Rows[0]["VHCL_INSUR_NUMBR"].ToString();
            txtInsuranceExpiry.Text = dtVehicleDetail.Rows[0]["VHCL_INSUR_EXPR_DATE"].ToString();
            txtInsuranceAmount.Text = dtVehicleDetail.Rows[0]["VHCL_INSUR_AMNT"].ToString();
            txtRFIDTagNum.Text = dtVehicleDetail.Rows[0]["VHCL_RF_ID_TAG_NUMBR"].ToString();
            txtTankerCapacity.Text = dtVehicleDetail.Rows[0]["TANKER_CAPACITY"].ToString();
            txtFuelLimit.Text = dtVehicleDetail.Rows[0]["VHCL_FUEL_LMTPERDAY"].ToString();
            txtAmountPerBarrel.Text = dtVehicleDetail.Rows[0]["AMNT_PER_BARREL"].ToString();


            if (dtVehicleDetail.Rows[0]["VHCLREGTYP_ID"].ToString() != "" && dtVehicleDetail.Rows[0]["VHCLREGTYP_STATUS"].ToString() == "1")
            {
                ddlRegiType.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCLREGTYP_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["VHCLREGTYP_NAME"].ToString(), dtVehicleDetail.Rows[0]["VHCLREGTYP_ID"].ToString());
                ddlRegiType.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlInsuranceProvider);

                ddlRegiType.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCLREGTYP_ID"].ToString()).Selected = true;
            }
            //ddlinsuranceType.Items.FindByText(dtInsuranceDetails.Rows[0]["INSURTYP_ID"].ToString()).Selected = true;
            if (ddlModalYear.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCL_MODEL_YEAR"].ToString()) != null)
            {
                ddlModalYear.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCL_MODEL_YEAR"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["VHCL_MODEL_YEAR"].ToString());
                ddlModalYear.Items.Insert(1, lstGrp);

                ddlModalYear.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCL_MODEL_YEAR"].ToString()).Selected = true;
            }

            if (dtVehicleDetail.Rows[0]["VHCLTYP_ID"].ToString() != "" && dtVehicleDetail.Rows[0]["VHCLTYP_STATUS"].ToString() == "1")
            {
                ddlVehicleType.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCLTYP_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["VHCLTYP_NAME"].ToString(), dtVehicleDetail.Rows[0]["VHCLTYP_ID"].ToString());
                ddlVehicleType.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlInsuranceProvider);

                ddlVehicleType.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCLTYP_ID"].ToString()).Selected = true;
            }

            if (dtVehicleDetail.Rows[0]["INSURPRVDR_ID"].ToString() != "" && dtVehicleDetail.Rows[0]["INSURPRVDR_STATUS"].ToString() == "1" && dtVehicleDetail.Rows[0]["INSURPRVDR_ID"].ToString() != "0" && dtVehicleDetail.Rows[0]["INSURPRVDR_CNCL_USR_ID"].ToString() != "")
            {
                ddlInsuranceProvider.Items.FindByValue(dtVehicleDetail.Rows[0]["INSURPRVDR_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["INSURPRVDR_NAME"].ToString(), dtVehicleDetail.Rows[0]["INSURPRVDR_ID"].ToString());
                ddlInsuranceProvider.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlInsuranceProvider);

                ddlInsuranceProvider.Items.FindByValue(dtVehicleDetail.Rows[0]["INSURPRVDR_ID"].ToString()).Selected = true;
            }

            hiddenFuelTypeId.Value = dtVehicleDetail.Rows[0]["FUELTYP_ID"].ToString();
            int fuelTypeId = Convert.ToInt32(dtVehicleDetail.Rows[0]["FUELTYP_ID"].ToString());

            FuelTypeLoad(fuelTypeId);

            if (dtVehicleDetail.Rows[0]["FUELTYP_STATUS"].ToString() == "1" && dtVehicleDetail.Rows[0]["FUELTYP_ID"].ToString() != "")
            {
                if (ddlFuelTyp.Items.FindByValue(dtVehicleDetail.Rows[0]["FUELTYP_ID"].ToString()) != null)
                {
                    ddlFuelTyp.Items.FindByValue(dtVehicleDetail.Rows[0]["FUELTYP_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["FUELTYP_NAME"].ToString(), dtVehicleDetail.Rows[0]["FUELTYP_ID"].ToString());
                ddlFuelTyp.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlFuelTyp);

                ddlFuelTyp.Items.FindByValue(dtVehicleDetail.Rows[0]["FUELTYP_ID"].ToString()).Selected = true;
            }



            hiddenVehicleClassId.Value = dtVehicleDetail.Rows[0]["VHCLCLS_ID"].ToString();
            int VehicleClassId = Convert.ToInt32(dtVehicleDetail.Rows[0]["VHCLCLS_ID"].ToString());


            DataTable dcategorytype = new DataTable();
            dcategorytype = objBusinessVehicle.readCategoryType(VehicleClassId);

            if (dcategorytype.Rows.Count > 0)
            {
                hiddenCategoryName.Value = dcategorytype.Rows[0][0].ToString();
            }


            VehicleClassLoad(VehicleClassId);

            if (dtVehicleDetail.Rows[0]["VHCLCLS_STATUS"].ToString() == "1" && dtVehicleDetail.Rows[0]["VHCLCLS_ID"].ToString() != "")
            {
                if (ddlVehicleCls.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCLCLS_ID"].ToString()) != null)
                {
                    ddlVehicleCls.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCLCLS_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["VHCLCLS_NAME"].ToString(), dtVehicleDetail.Rows[0]["VHCLCLS_ID"].ToString());
                ddlFuelTyp.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlFuelTyp);

                ddlFuelTyp.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCLCLS_ID"].ToString()).Selected = true;
            }

            int intInsuretStatus = Convert.ToInt32(dtVehicleDetail.Rows[0]["VHCL_STATUS"]);
            if (intInsuretStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }

            if (dtVehicleDetail.Rows[0]["MAKETYP_ID"].ToString() != "")
            {
                ddlMake.Items.FindByValue(dtVehicleDetail.Rows[0]["MAKETYP_ID"].ToString()).Selected = true;
            }

            txtModel.Text = dtVehicleDetail.Rows[0]["VHCL_MODEL"].ToString();
            txtDealer.Text = dtVehicleDetail.Rows[0]["VHCL_PRCHS_DEALER"].ToString();
            txtContact.Text = dtVehicleDetail.Rows[0]["VHCL_DELR_CNTCT_NUM"].ToString();
            txtPrice.Text = dtVehicleDetail.Rows[0]["VHCL_PRICE"].ToString();
            if (dtVehicleDetail.Rows[0]["TRNSMTYP_ID"].ToString() != "")
            {
                ddlTrnsmn.Items.FindByValue(dtVehicleDetail.Rows[0]["TRNSMTYP_ID"].ToString()).Selected = true;
            }

            if (dtVehicleDetail.Rows[0]["COLOR_ID"].ToString() != "")
            {
                ddlColor.Items.FindByValue(dtVehicleDetail.Rows[0]["COLOR_ID"].ToString()).Selected = true;
            }
            if (dtVehicleDetail.Rows[0]["COVRGTYP_ID"].ToString() != "" && dtVehicleDetail.Rows[0]["COVRGTYP_STATUS"].ToString() == "1")
            {
                ddlCoverageType.Items.FindByValue(dtVehicleDetail.Rows[0]["COVRGTYP_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["COVRGTYP_NAME"].ToString(), dtVehicleDetail.Rows[0]["COVRGTYP_ID"].ToString());
                ddlCoverageType.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCoverageType);

                ddlCoverageType.Items.FindByValue(dtVehicleDetail.Rows[0]["COVRGTYP_ID"].ToString()).Selected = true;
            }

            txtBedIstamara.Text = dtVehicleDetail.Rows[0]["TRLER_REG_NUMBR"].ToString();
            txtBedInsNumber.Text = dtVehicleDetail.Rows[0]["TRLER_INSUR_NUMBR"].ToString();


            txtTrPerExpDate.Text = dtVehicleDetail.Rows[0]["TR_REG_EXPDATE"].ToString();
            txtTRinsExpDate.Text = dtVehicleDetail.Rows[0]["TR_INS_EXPDATE"].ToString();
            txtTrInsAmnt.Text = dtVehicleDetail.Rows[0]["TR_INS_AMNT"].ToString();

           hiddenCovergTypSelctd.Value = dtVehicleDetail.Rows[0]["TR_INS_CVRGTYP_ID"].ToString();

            if (dtVehicleDetail.Rows[0]["TR_INS_CVRGTYP_ID"].ToString() != "" && dtVehicleDetail.Rows[0]["TR_CVRGTYP_STS"].ToString() == "1")
            {
                if (ddlTrInsCvrgeTyp.Items.FindByValue(dtVehicleDetail.Rows[0]["TR_INS_CVRGTYP_ID"].ToString()) != null)
                {
                    ddlTrInsCvrgeTyp.Items.FindByValue(dtVehicleDetail.Rows[0]["TR_INS_CVRGTYP_ID"].ToString()).Selected = true;
                
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["TR_CVRGTYP_NAME"].ToString(), dtVehicleDetail.Rows[0]["TR_INS_CVRGTYP_ID"].ToString());
                ddlTrInsCvrgeTyp.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlTrInsCvrgeTyp);

                ddlTrInsCvrgeTyp.Items.FindByValue(dtVehicleDetail.Rows[0]["TR_INS_CVRGTYP_ID"].ToString()).Selected = true;
            }

            hiddenInsrncPrvdrSelctd.Value = dtVehicleDetail.Rows[0]["TR_INS_PRVDR_ID"].ToString();

            if (dtVehicleDetail.Rows[0]["TR_INS_PRVDR_ID"].ToString() != "" && dtVehicleDetail.Rows[0]["TR_INSPRVDR_STS"].ToString() == "1" && dtVehicleDetail.Rows[0]["TR_INS_PRVDR_ID"].ToString() != "0")
            {
                if (ddlTRinsPrvdr.Items.FindByValue(dtVehicleDetail.Rows[0]["TR_INS_PRVDR_ID"].ToString()) != null)
                {
                    ddlTRinsPrvdr.Items.FindByValue(dtVehicleDetail.Rows[0]["TR_INS_PRVDR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["TR_INSPRVDR_NAME"].ToString(), dtVehicleDetail.Rows[0]["TR_INS_PRVDR_ID"].ToString());
                ddlTRinsPrvdr.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlTRinsPrvdr);

                ddlTRinsPrvdr.Items.FindByValue(dtVehicleDetail.Rows[0]["TR_INS_PRVDR_ID"].ToString()).Selected = true;
            }


            if (dtVehicleStsDetail.Rows.Count > 0)
            {
                txtVhclSts.Text = dtVehicleStsDetail.Rows[0]["VHCLSTSTYP_NAME"].ToString();
            }
            else
            {
                txtVhclSts.Text = "AVAILABLE";
            }


        }
    
        //start for displaying attached files

        clsCommonLibrary objCommon = new clsCommonLibrary();
        DataTable dtPAttchmnt = new DataTable();
        dtPAttchmnt.Columns.Add("TransDtlId", typeof(int));
        dtPAttchmnt.Columns.Add("FileName", typeof(string));
        dtPAttchmnt.Columns.Add("ActualFileName", typeof(string));
        dtPAttchmnt.Columns.Add("Description", typeof(string));

        DataTable dtPermitAttchmnt = new DataTable();
        dtPermitAttchmnt = objBusinessVehicle.ReadPermtFiles(objEntityVehicle);
        hiddenFilePath.Value = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);
        if (dtPermitAttchmnt.Rows.Count > 0)
        {
            for (int intcnt = 0; intcnt < dtPermitAttchmnt.Rows.Count; intcnt++)
            {
                DataRow drAttchPermt = dtPAttchmnt.NewRow();
                drAttchPermt["TransDtlId"] = dtPermitAttchmnt.Rows[intcnt]["VHCLPRMTFLS_ID"].ToString();
                drAttchPermt["FileName"] = dtPermitAttchmnt.Rows[intcnt]["VHCLPRMTFLS_FILENAME"].ToString();
                drAttchPermt["ActualFileName"] = dtPermitAttchmnt.Rows[intcnt]["VHCLPRMTFLS_FLNM_ACT"].ToString();
                drAttchPermt["Description"] = dtPermitAttchmnt.Rows[intcnt]["VHCLPRMTFLS_DSCRPTN"].ToString();
                dtPAttchmnt.Rows.Add(drAttchPermt);
                hiddenAttchmntPrmtSlNumber.Value = dtPermitAttchmnt.Rows[intcnt]["VHCLPRMTFLS_SLNUM"].ToString();
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
        dtInsurAttchmnt = objBusinessVehicle.ReadInsurFiles(objEntityVehicle);
        if (dtInsurAttchmnt.Rows.Count > 0)
        {
            for (int intcnt = 0; intcnt < dtInsurAttchmnt.Rows.Count; intcnt++)
            {
                DataRow drAttchInsur = dtIAttchmnt.NewRow();
                drAttchInsur["TransDtlId"] = dtInsurAttchmnt.Rows[intcnt]["VHCLINSFLS_ID"].ToString();
                drAttchInsur["FileName"] = dtInsurAttchmnt.Rows[intcnt]["VHCLINSFLS_FILENAME"].ToString();
                drAttchInsur["ActualFileName"] = dtInsurAttchmnt.Rows[intcnt]["VHCLINSFLS_FLNM_ACT"].ToString();
                drAttchInsur["Description"] = dtInsurAttchmnt.Rows[intcnt]["VHCLINSFLS_DSCRPTN"].ToString();
                dtIAttchmnt.Rows.Add(drAttchInsur);
                hiddenAttchmntInsurSlNumber.Value = dtInsurAttchmnt.Rows[intcnt]["VHCLINSFLS_SLNUM"].ToString();
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
        dtVhclAttchmnt = objBusinessVehicle.ReadVehicleFiles(objEntityVehicle);
        if (dtVhclAttchmnt.Rows.Count > 0)
        {
            for (int intcnt = 0; intcnt < dtVhclAttchmnt.Rows.Count; intcnt++)
            {
                DataRow drAttchVhcl = dtVAttchmnt.NewRow();
                drAttchVhcl["TransDtlId"] = dtVhclAttchmnt.Rows[intcnt]["VHCLIMGFLS_ID"].ToString();
                drAttchVhcl["FileName"] = dtVhclAttchmnt.Rows[intcnt]["VHCLIMGFLS_FILENAME"].ToString();
                drAttchVhcl["ActualFileName"] = dtVhclAttchmnt.Rows[intcnt]["VHCLIMGFLS_FLNM_ACT"].ToString();
                drAttchVhcl["Description"] = dtVhclAttchmnt.Rows[intcnt]["VHCLIMGFLS_DESC"].ToString();
                dtVAttchmnt.Rows.Add(drAttchVhcl);
                hiddenAttchmntVhclSlNumber.Value = dtVhclAttchmnt.Rows[intcnt]["VHCLIMGFLS_SLNUM"].ToString();
            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtVAttchmnt);
            hiddenEditVhclAttchmnt.Value = strJson;
        }
        //end for displaying attached files


        DataTable dtVAttchmntTRper = new DataTable();
        dtVAttchmntTRper.Columns.Add("TransDtlId", typeof(int));
        dtVAttchmntTRper.Columns.Add("FileName", typeof(string));
        dtVAttchmntTRper.Columns.Add("ActualFileName", typeof(string));
        dtVAttchmntTRper.Columns.Add("Description", typeof(string));
        DataTable dtVAttchmntTr = new DataTable();
        dtVAttchmntTr = objBusinessVehicle.ReadVehicleFilesTRper(objEntityVehicle);
        if (dtVAttchmntTr.Rows.Count > 0)
        {
            for (int intcnt = 0; intcnt < dtVAttchmntTr.Rows.Count; intcnt++)
            {
                DataRow drAttchVhcl = dtVAttchmntTRper.NewRow();
                drAttchVhcl["TransDtlId"] = dtVAttchmntTr.Rows[intcnt][0].ToString();
                drAttchVhcl["FileName"] = dtVAttchmntTr.Rows[intcnt][1].ToString();
                drAttchVhcl["ActualFileName"] = dtVAttchmntTr.Rows[intcnt][2].ToString();
                drAttchVhcl["Description"] = dtVAttchmntTr.Rows[intcnt][4].ToString();
                dtVAttchmntTRper.Rows.Add(drAttchVhcl);
                hiddenAttchmntPrmtSlNumberTR.Value = dtVAttchmntTr.Rows[intcnt][3].ToString();
            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtVAttchmntTRper);
            hiddenEditPrmtAttchmntTR.Value = strJson;
        }



        DataTable dtVAttchmntTRINS = new DataTable();
        dtVAttchmntTRINS.Columns.Add("TransDtlId", typeof(int));
        dtVAttchmntTRINS.Columns.Add("FileName", typeof(string));
        dtVAttchmntTRINS.Columns.Add("ActualFileName", typeof(string));
        dtVAttchmntTRINS.Columns.Add("Description", typeof(string));
        DataTable dtVAttchmntTrFSA = new DataTable();
        dtVAttchmntTrFSA = objBusinessVehicle.ReadVehicleFilesTRins(objEntityVehicle);
        if (dtVAttchmntTrFSA.Rows.Count > 0)
        {
            for (int intcnt = 0; intcnt < dtVAttchmntTrFSA.Rows.Count; intcnt++)
            {
                DataRow drAttchVhcl = dtVAttchmntTRINS.NewRow();
                drAttchVhcl["TransDtlId"] = dtVAttchmntTrFSA.Rows[intcnt][0].ToString();
                drAttchVhcl["FileName"] = dtVAttchmntTrFSA.Rows[intcnt][1].ToString();
                drAttchVhcl["ActualFileName"] = dtVAttchmntTrFSA.Rows[intcnt][2].ToString();
                drAttchVhcl["Description"] = dtVAttchmntTrFSA.Rows[intcnt][4].ToString();
                dtVAttchmntTRINS.Rows.Add(drAttchVhcl);
                hiddenAttchmntInsurSlNumberTR.Value = dtVAttchmntTrFSA.Rows[intcnt][3].ToString();
            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtVAttchmntTRINS);
            hiddenEditInsurAttchmntTR.Value = strJson;
        }




        txtInsuranceAmount.Enabled = false;
        txtVehicleNumber.Enabled = false;
        txtDescription.Enabled = false;
        txtEngineCapacity.Enabled = false;
        txtKML.Enabled = false;
        txtPurchaseDate.Enabled = false;
        txtCurrentMileage.Enabled = false;
       // txtPermitNumber.Enabled = false;
        txtPermitExpiryDate.Enabled = false;
        txtInsurance.Enabled = false;
        txtInsuranceExpiry.Enabled = false;
        ddlModalYear.Enabled = false;
        ddlVehicleType.Enabled = false;
        ddlInsuranceProvider.Enabled = false;
        txtChasisNumber.Enabled = false;
        //divVehicleClassContainer.Attributes["style"] = "float: left;width: 41%;height: 354px;border:1px solid;border-color: #008641;margin: 1%;pointer-events: none;";
        //divFuelImage.Attributes["style"] = "width: 85%;margin-left: 7%;overflow:auto;max-height: 83%;border: solid;border-color: #779E99;pointer-events: none;";

        ddlVehicleCls.Enabled = false;
        ddlFuelTyp.Enabled = false;

        ddlRegiType.Enabled = false;
        txtFuelLimit.Enabled = false;
        txtRFIDTagNum.Enabled = false;
        txtTankerCapacity.Enabled = false;
        txtAmountPerBarrel.Enabled = false;
        ddlMake.Enabled = false;
        txtModel.Enabled = false;
        txtDealer.Enabled = false;
        txtContact.Enabled = false;
        txtPrice.Enabled = false;
        ddlColor.Enabled = false;
        ddlTrnsmn.Enabled = false;
        ddlCoverageType.Enabled = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        cbxStatus.Enabled = false;
        ddlCoverageType.Enabled = false;
        cbxStatus.Attributes["style"] = "pointer-events: none;";
        btnChangeSts.Enabled = false;
        btnImportCsv.Enabled = false;

        //For trailer details
        txtBedIstamara.Enabled = false;
        txtBedInsNumber.Enabled = false;
        txtTrPerExpDate.Enabled = false;
        ddlTRinsPrvdr.Enabled = false;
        txtTRinsExpDate.Enabled = false;
        txtTrInsAmnt.Enabled = false;
        ddlTrInsCvrgeTyp.Enabled = false;
 
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
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strDId)
    {
        InsProviderLoad();
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        clsEntityLayerVehicleMaster objEntityVehicle = new clsEntityLayerVehicleMaster();
        hiddenEdit.Value = "Edit";
        HiddenVehicleId.Value = strDId;
        objEntityVehicle.VehicleId = Convert.ToInt32(strDId);
        DataTable dtVehicleDetail = new DataTable();
        DataTable dtVehicleStsDetail = new DataTable();
        dtVehicleStsDetail = objBusinessVehicle.ReadVehicleSts(objEntityVehicle);
        dtVehicleDetail = objBusinessVehicle.ReadVehicleDetailsById(objEntityVehicle);
       
        //After fetch insurance details in datatable,we need to differentiate.
        if (dtVehicleDetail.Rows.Count > 0)
        {
            txtVehicleNumber.Text = dtVehicleDetail.Rows[0]["VHCL_NUMBR"].ToString();
            txtDescription.Text = dtVehicleDetail.Rows[0]["VHCL_DESCRIPTION"].ToString();
            txtEngineCapacity.Text = dtVehicleDetail.Rows[0]["VHCL_ENGINE_CPCTY"].ToString();
            txtKML.Text = dtVehicleDetail.Rows[0]["VHCL_KMPL"].ToString();
            txtChasisNumber.Text = dtVehicleDetail.Rows[0]["VHCL_CHASIS_NUM"].ToString();
            txtPurchaseDate.Text = dtVehicleDetail.Rows[0]["VHCL_PRCH_DATE"].ToString();
            txtCurrentMileage.Text = dtVehicleDetail.Rows[0]["VHCL_CRNT_MILEAGE"].ToString();
            txtPermitExpiryDate.Text = dtVehicleDetail.Rows[0]["VHCL_PERMIT_EXPR_DATE"].ToString();
            txtInsurance.Text = dtVehicleDetail.Rows[0]["VHCL_INSUR_NUMBR"].ToString();
            txtInsuranceExpiry.Text = dtVehicleDetail.Rows[0]["VHCL_INSUR_EXPR_DATE"].ToString();
            txtInsuranceAmount.Text = dtVehicleDetail.Rows[0]["VHCL_INSUR_AMNT"].ToString();
            txtRFIDTagNum.Text = dtVehicleDetail.Rows[0]["VHCL_RF_ID_TAG_NUMBR"].ToString();
            txtTankerCapacity.Text = dtVehicleDetail.Rows[0]["TANKER_CAPACITY"].ToString();
            txtFuelLimit.Text = dtVehicleDetail.Rows[0]["VHCL_FUEL_LMTPERDAY"].ToString();
            txtAmountPerBarrel.Text = dtVehicleDetail.Rows[0]["AMNT_PER_BARREL"].ToString();

         
            if (dtVehicleDetail.Rows[0]["VHCLREGTYP_ID"].ToString() != "" && dtVehicleDetail.Rows[0]["VHCLREGTYP_STATUS"].ToString() == "1")
            {
                ddlRegiType.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCLREGTYP_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["VHCLREGTYP_NAME"].ToString(), dtVehicleDetail.Rows[0]["VHCLREGTYP_ID"].ToString());
                ddlRegiType.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlRegiType);

                ddlRegiType.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCLREGTYP_ID"].ToString()).Selected = true;
            }
            //ddlinsuranceType.Items.FindByText(dtInsuranceDetails.Rows[0]["INSURTYP_ID"].ToString()).Selected = true;
            if (dtVehicleDetail.Rows[0]["VHCL_MODEL_YEAR"].ToString() != "")
            {
                ddlModalYear.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCL_MODEL_YEAR"].ToString()).Selected = true;
            }

            if (dtVehicleDetail.Rows[0]["VHCLTYP_ID"].ToString() != "" && dtVehicleDetail.Rows[0]["VHCLTYP_STATUS"].ToString() == "1")
            {
                ddlVehicleType.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCLTYP_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["VHCLTYP_NAME"].ToString(), dtVehicleDetail.Rows[0]["VHCLTYP_ID"].ToString());
                ddlVehicleType.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlVehicleType);

                ddlVehicleType.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCLTYP_ID"].ToString()).Selected = true;
            }


            if (dtVehicleDetail.Rows[0]["INSURPRVDR_ID"].ToString() != "" && dtVehicleDetail.Rows[0]["INSURPRVDR_STATUS"].ToString() == "1" && dtVehicleDetail.Rows[0]["INSURPRVDR_ID"].ToString() != "0" && dtVehicleDetail.Rows[0]["INSURPRVDR_CNCL_USR_ID"].ToString() == "")
            {
                ddlInsuranceProvider.Items.FindByValue(dtVehicleDetail.Rows[0]["INSURPRVDR_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["INSURPRVDR_NAME"].ToString(), dtVehicleDetail.Rows[0]["INSURPRVDR_ID"].ToString());
                ddlInsuranceProvider.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlInsuranceProvider);

                ddlInsuranceProvider.Items.FindByValue(dtVehicleDetail.Rows[0]["INSURPRVDR_ID"].ToString()).Selected = true;
            }

            hiddenFuelTypeId.Value = dtVehicleDetail.Rows[0]["FUELTYP_ID"].ToString();

            int fuelTypeId = Convert.ToInt32(dtVehicleDetail.Rows[0]["FUELTYP_ID"].ToString());

            FuelTypeLoad(fuelTypeId);

            if (dtVehicleDetail.Rows[0]["FUELTYP_STATUS"].ToString() == "1" && dtVehicleDetail.Rows[0]["FUELTYP_ID"].ToString() != "")
            {
                if (ddlFuelTyp.Items.FindByValue(dtVehicleDetail.Rows[0]["FUELTYP_ID"].ToString()) != null)
                {
                    ddlFuelTyp.Items.FindByValue(dtVehicleDetail.Rows[0]["FUELTYP_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["FUELTYP_NAME"].ToString(), dtVehicleDetail.Rows[0]["FUELTYP_ID"].ToString());
                ddlFuelTyp.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlFuelTyp);

                ddlFuelTyp.Items.FindByValue(dtVehicleDetail.Rows[0]["FUELTYP_ID"].ToString()).Selected = true;
            }

            int vhclclassId = Convert.ToInt32(dtVehicleDetail.Rows[0]["VHCLCLS_ID"]);
            hiddenVehicleClassId.Value = dtVehicleDetail.Rows[0]["VHCLCLS_ID"].ToString();
           



          DataTable dcategorytype = new DataTable();
          dcategorytype = objBusinessVehicle.readCategoryType(vhclclassId);
       
          if (dcategorytype.Rows.Count > 0)
          {
              hiddenCategoryName.Value = dcategorytype.Rows[0][0].ToString();
          }





            int VehicleClassId = Convert.ToInt32(dtVehicleDetail.Rows[0]["VHCLCLS_ID"].ToString());

            VehicleClassLoad(VehicleClassId);

            if (dtVehicleDetail.Rows[0]["VHCLCLS_STATUS"].ToString() == "1" && dtVehicleDetail.Rows[0]["VHCLCLS_ID"].ToString() != "")
            {
                if (ddlVehicleCls.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCLCLS_ID"].ToString()) != null)
                {
                    ddlVehicleCls.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCLCLS_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["VHCLCLS_NAME"].ToString(), dtVehicleDetail.Rows[0]["VHCLCLS_ID"].ToString());
                ddlFuelTyp.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlFuelTyp);

                ddlFuelTyp.Items.FindByValue(dtVehicleDetail.Rows[0]["VHCLCLS_ID"].ToString()).Selected = true;
            }

            int intInsuretStatus = Convert.ToInt32(dtVehicleDetail.Rows[0]["VHCL_STATUS"]);
            if (intInsuretStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
            }

            if (dtVehicleDetail.Rows[0]["MAKETYP_ID"].ToString() != "")
            {
                ddlMake.Items.FindByValue(dtVehicleDetail.Rows[0]["MAKETYP_ID"].ToString()).Selected = true;
            }            
            txtModel.Text = dtVehicleDetail.Rows[0]["VHCL_MODEL"].ToString();
            txtDealer.Text = dtVehicleDetail.Rows[0]["VHCL_PRCHS_DEALER"].ToString();
            txtContact.Text = dtVehicleDetail.Rows[0]["VHCL_DELR_CNTCT_NUM"].ToString();
            txtPrice.Text = dtVehicleDetail.Rows[0]["VHCL_PRICE"].ToString();
            if (dtVehicleDetail.Rows[0]["TRNSMTYP_ID"].ToString() != "" )
            {
                ddlTrnsmn.Items.FindByValue(dtVehicleDetail.Rows[0]["TRNSMTYP_ID"].ToString()).Selected = true;
            }

            if (dtVehicleDetail.Rows[0]["COLOR_ID"].ToString() != "")
            {
                ddlColor.Items.FindByValue(dtVehicleDetail.Rows[0]["COLOR_ID"].ToString()).Selected = true;
            }




            if (dtVehicleDetail.Rows[0]["COVRGTYP_ID"].ToString() != "" && dtVehicleDetail.Rows[0]["COVRGTYP_STATUS"].ToString() == "1" )
            {
                if (ddlCoverageType.Items.FindByValue(dtVehicleDetail.Rows[0]["COVRGTYP_ID"].ToString()) != null)
                {
                    ddlCoverageType.Items.FindByValue(dtVehicleDetail.Rows[0]["COVRGTYP_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["COVRGTYP_NAME"].ToString(), dtVehicleDetail.Rows[0]["COVRGTYP_ID"].ToString());
                ddlCoverageType.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCoverageType);

                ddlCoverageType.Items.FindByValue(dtVehicleDetail.Rows[0]["COVRGTYP_ID"].ToString()).Selected = true;
            }


            txtBedIstamara.Text = dtVehicleDetail.Rows[0]["TRLER_REG_NUMBR"].ToString();
            txtBedInsNumber.Text = dtVehicleDetail.Rows[0]["TRLER_INSUR_NUMBR"].ToString();


            txtTrPerExpDate.Text = dtVehicleDetail.Rows[0]["TR_REG_EXPDATE"].ToString();
            txtTRinsExpDate.Text = dtVehicleDetail.Rows[0]["TR_INS_EXPDATE"].ToString();
            txtTrInsAmnt.Text = dtVehicleDetail.Rows[0]["TR_INS_AMNT"].ToString();

            hiddenCovergTypSelctd.Value = dtVehicleDetail.Rows[0]["TR_INS_CVRGTYP_ID"].ToString();

            if (dtVehicleDetail.Rows[0]["TR_INS_CVRGTYP_ID"].ToString() != "" && dtVehicleDetail.Rows[0]["TR_CVRGTYP_STS"].ToString() == "1")
            {
                if (ddlTrInsCvrgeTyp.Items.FindByValue(dtVehicleDetail.Rows[0]["TR_INS_CVRGTYP_ID"].ToString()) != null)
                {
                    ddlTrInsCvrgeTyp.Items.FindByValue(dtVehicleDetail.Rows[0]["TR_INS_CVRGTYP_ID"].ToString()).Selected = true;
                
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["TR_CVRGTYP_NAME"].ToString(), dtVehicleDetail.Rows[0]["TR_INS_CVRGTYP_ID"].ToString());
                ddlTrInsCvrgeTyp.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlTrInsCvrgeTyp);

                ddlTrInsCvrgeTyp.Items.FindByValue(dtVehicleDetail.Rows[0]["TR_INS_CVRGTYP_ID"].ToString()).Selected = true;
            }

            hiddenInsrncPrvdrSelctd.Value = dtVehicleDetail.Rows[0]["TR_INS_PRVDR_ID"].ToString();

            if (dtVehicleDetail.Rows[0]["TR_INS_PRVDR_ID"].ToString() != "" && dtVehicleDetail.Rows[0]["TR_INSPRVDR_STS"].ToString() == "1" && dtVehicleDetail.Rows[0]["TR_INS_PRVDR_ID"].ToString() != "0")
            {
                if (ddlTRinsPrvdr.Items.FindByValue(dtVehicleDetail.Rows[0]["TR_INS_PRVDR_ID"].ToString()) != null)
                {
                    ddlTRinsPrvdr.Items.FindByValue(dtVehicleDetail.Rows[0]["TR_INS_PRVDR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtVehicleDetail.Rows[0]["TR_INSPRVDR_NAME"].ToString(), dtVehicleDetail.Rows[0]["TR_INS_PRVDR_ID"].ToString());
                ddlTRinsPrvdr.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlTRinsPrvdr);

                ddlTRinsPrvdr.Items.FindByValue(dtVehicleDetail.Rows[0]["TR_INS_PRVDR_ID"].ToString()).Selected = true;
            }




            if (dtVehicleStsDetail.Rows.Count > 0)
            {
                txtVhclSts.Text = dtVehicleStsDetail.Rows[0]["VHCLSTSTYP_NAME"].ToString();
            }
            else
            {
                txtVhclSts.Text = "AVAILABLE";
            }

          




        }
      
        //start for displaying attached files

        clsCommonLibrary objCommon = new clsCommonLibrary();
        DataTable dtPAttchmnt = new DataTable();
        dtPAttchmnt.Columns.Add("TransDtlId", typeof(int));
        dtPAttchmnt.Columns.Add("FileName", typeof(string));
        dtPAttchmnt.Columns.Add("ActualFileName", typeof(string));
        dtPAttchmnt.Columns.Add("Description", typeof(string));

     

       DataTable dtPermitAttchmnt = new DataTable();
       dtPermitAttchmnt = objBusinessVehicle.ReadPermtFiles(objEntityVehicle);
       hiddenFilePath.Value = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);
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
       dtInsurAttchmnt = objBusinessVehicle.ReadInsurFiles(objEntityVehicle);
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
        dtVhclAttchmnt = objBusinessVehicle.ReadVehicleFiles(objEntityVehicle);
        if (dtVhclAttchmnt.Rows.Count > 0)
        {
            for (int intcnt = 0; intcnt < dtVhclAttchmnt.Rows.Count; intcnt++)
            {
                DataRow drAttchVhcl = dtVAttchmnt.NewRow();
                drAttchVhcl["TransDtlId"] = dtVhclAttchmnt.Rows[intcnt]["VHCLIMGFLS_ID"].ToString();
                drAttchVhcl["FileName"] = dtVhclAttchmnt.Rows[intcnt]["VHCLIMGFLS_FILENAME"].ToString();
                drAttchVhcl["ActualFileName"] = dtVhclAttchmnt.Rows[intcnt]["VHCLIMGFLS_FLNM_ACT"].ToString();
                drAttchVhcl["Description"] = dtVhclAttchmnt.Rows[intcnt]["VHCLIMGFLS_DESC"].ToString();
                dtVAttchmnt.Rows.Add(drAttchVhcl);
                hiddenAttchmntVhclSlNumber.Value = dtVhclAttchmnt.Rows[intcnt]["VHCLIMGFLS_SLNUM"].ToString();
            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtVAttchmnt);
            hiddenEditVhclAttchmnt.Value = strJson;
        }
        //end for displaying attached files






        DataTable dtVAttchmntTRper = new DataTable();
        dtVAttchmntTRper.Columns.Add("TransDtlId", typeof(int));
        dtVAttchmntTRper.Columns.Add("FileName", typeof(string));
        dtVAttchmntTRper.Columns.Add("ActualFileName", typeof(string));
        dtVAttchmntTRper.Columns.Add("Description", typeof(string));
        DataTable dtVAttchmntTr = new DataTable();
        dtVAttchmntTr = objBusinessVehicle.ReadVehicleFilesTRper(objEntityVehicle);
        if (dtVAttchmntTr.Rows.Count > 0)
        {
            for (int intcnt = 0; intcnt < dtVAttchmntTr.Rows.Count; intcnt++)
            {
                DataRow drAttchVhcl = dtVAttchmntTRper.NewRow();
                drAttchVhcl["TransDtlId"] = dtVAttchmntTr.Rows[intcnt][0].ToString();
                drAttchVhcl["FileName"] = dtVAttchmntTr.Rows[intcnt][1].ToString();
                drAttchVhcl["ActualFileName"] = dtVAttchmntTr.Rows[intcnt][2].ToString();
                drAttchVhcl["Description"] = dtVAttchmntTr.Rows[intcnt][4].ToString();
                dtVAttchmntTRper.Rows.Add(drAttchVhcl);
                hiddenAttchmntPrmtSlNumberTR.Value = dtVAttchmntTr.Rows[intcnt][3].ToString();
            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtVAttchmntTRper);
            hiddenEditPrmtAttchmntTR.Value = strJson;
        }






        DataTable dtVAttchmntTRINS = new DataTable();
        dtVAttchmntTRINS.Columns.Add("TransDtlId", typeof(int));
        dtVAttchmntTRINS.Columns.Add("FileName", typeof(string));
        dtVAttchmntTRINS.Columns.Add("ActualFileName", typeof(string));
        dtVAttchmntTRINS.Columns.Add("Description", typeof(string));
        DataTable dtVAttchmntTrFSA = new DataTable();
        dtVAttchmntTrFSA = objBusinessVehicle.ReadVehicleFilesTRins(objEntityVehicle);
        if (dtVAttchmntTrFSA.Rows.Count > 0)
        {
            for (int intcnt = 0; intcnt < dtVAttchmntTrFSA.Rows.Count; intcnt++)
            {
                DataRow drAttchVhcl = dtVAttchmntTRINS.NewRow();
                drAttchVhcl["TransDtlId"] = dtVAttchmntTrFSA.Rows[intcnt][0].ToString();
                drAttchVhcl["FileName"] = dtVAttchmntTrFSA.Rows[intcnt][1].ToString();
                drAttchVhcl["ActualFileName"] = dtVAttchmntTrFSA.Rows[intcnt][2].ToString();
                drAttchVhcl["Description"] = dtVAttchmntTrFSA.Rows[intcnt][4].ToString();
                dtVAttchmntTRINS.Rows.Add(drAttchVhcl);
                hiddenAttchmntInsurSlNumberTR.Value = dtVAttchmntTrFSA.Rows[intcnt][3].ToString();
            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtVAttchmntTRINS);
            hiddenEditInsurAttchmntTR.Value = strJson;
        }






        int intUserId = 0, intUsrRolMstrId, intUsrRolMstrIdInsPer, intEnableAdd = 0, intEnableAddRenewal = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


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

                }
            }
        }

        intUsrRolMstrIdInsPer = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Insurance_Permit_Renewal);
        DataTable dtChildRolRenew = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdInsPer);

        if (dtChildRolRenew.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRolRenew.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                {
                    intEnableAddRenewal = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                }
            }
        }
        if (intEnableAddRenewal == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            divRenewPermit.Visible = true;
            divInsuranceRenewal.Visible = true;
            divTrRnwlIconPrmt.Visible = true;
            divTRrnwlIconIns.Visible = true;
        }
        else
        {
            divRenewPermit.Visible = false;
            divInsuranceRenewal.Visible = false;
            divTrRnwlIconPrmt.Visible = false;
            divTRrnwlIconIns.Visible = false;
        }


        if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            btnUpdate.Visible = true;

        }
        else
        {

            btnUpdate.Visible = false;

        }

        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdateClose.Visible = true;


        DataTable dtInsRenewal = objBusinessVehicle.ReadInsuranceRenew(objEntityVehicle);
        if (dtInsRenewal.Rows.Count > 0)
        {
            hiddenIsInsurRenwed.Value = "1";
            lblInsEditNotPsbl.Visible = true;
            txtInsuranceAmount.Enabled = false;
            txtInsuranceExpiry.Enabled = false;
            divInsureexpirydate.Attributes["style"] = "width: 45%;margin-top: 1%;margin-right: 2%;float:right;pointer-events: none;"; 
            //imgInsuranceRenewal.Attributes["style"]="width: 23%;margin-left: 28%;";
            txtInsurance.Enabled = false;
            ddlInsuranceProvider.Enabled = false;
            ddlCoverageType.Enabled = false;
           // FileUploadInsurance.Enabled = false;
        }

        DataTable dtPerRenewal = objBusinessVehicle.ReadPermitRenew(objEntityVehicle);
        if (dtPerRenewal.Rows.Count > 0)
        {
            hiddenIsPrmtRenwed.Value = "1";
            //divPerAtch.Attributes["style"] = "pointer-events: none;";
            lblPermitRnwlNtPosible.Visible = true;
            txtPermitExpiryDate.Enabled = false;
            divPermitExpiryDate.Attributes["style"] = "width: 42%;margin-top: 2%;margin-left: 1%;float:left;pointer-events: none;";
            divRenewPermit.Attributes["style"] = "width: 10%;height: 107px;float: right;margin-right: -57%;margin-top: 11%;";
           // txtPermitNumber.Enabled = false;
            //FileUploadPermit.Enabled = false;
         
        }


        //Start:-EMP-0009
        DataTable dtInsRenewalTR = objBusinessVehicle.ReadInsuranceRenewTR(objEntityVehicle);
        if (dtInsRenewalTR.Rows.Count > 0)
        {
            hiddenIsInsurRenwedTR.Value = "1";
            lblTrInsRnwlPos.Visible = true;
            txtBedInsNumber.Enabled = false;
            ddlTRinsPrvdr.Enabled = false;
            txtTRinsExpDate.Enabled = false;
            txtTrInsAmnt.Enabled = false;
            ddlTrInsCvrgeTyp.Enabled = false;
            divTrInsPrvdr.Attributes["style"] = "margin-top: 11%;";
            divTrInsExpDate.Attributes["style"] = "margin-top: 16.5%;pointer-events: none;";
            divTRrnwlIconIns.Attributes["style"] = "width: 20%;height: 107px;float: right;margin-right: -1%;margin-top: -8%;cursor:pointer";

        }
        else
        {
            divTRrnwlIconIns.Attributes["style"] = "width: 20%;height: 107px;float: right;margin-right: -1%;margin-top: -6.5%;cursor:pointer";
        }

        DataTable dtPerRenewalTR = objBusinessVehicle.ReadPermitRenewTR(objEntityVehicle);
        if (dtPerRenewalTR.Rows.Count > 0)
        {
            hiddenIsPrmtRenwedTR.Value = "1";
            lblTRprmtRnwlNotPos.Visible = true;
            txtBedIstamara.Enabled = false;
            txtTrPerExpDate.Enabled = false;
            Div5.Attributes["style"] = "font-family:Calibri;float:right;width:59.5%;pointer-events: none;";
            divTrRnwlIconPrmt.Attributes["style"] = "width: 20%;height: 107px;float: right;margin-right: -100%;margin-top: 29.5%;cursor:pointer";
        }

        //End:-EMP-0009






    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("gen_Vehicle_Master.aspx");
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
    //for CSV FILE
    /// <summary>
    /// Class to store one CSV row
    /// </summary>
    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }  /// <summary>
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
    void ReadTest()
    {
        // Read sample data from CSV file
        using (CsvFileReader reader = new CsvFileReader("ReadTest.csv"))
        {
            CsvRow row = new CsvRow();
            while (reader.ReadRow(row))
            {
                foreach (string s in row)
                {
                    Console.Write(s);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
    protected void btnImportCsvVhcl_Click(object sender, EventArgs e)
    {
        Response.Redirect("/AWMS/AWMS_Master/gen_Vehicle_Master/gen_Vehicle_Master_Fileupload_CSV.aspx");       
    }
    protected void btnChangeSts_Click(object sender, EventArgs e)
    {
        Response.Redirect("/AWMS/AWMS_Master/gen_Vehicle_Status_Management/gen_Vehicle_Status_Management.aspx?VhclID=" + hiddenVehicleIdForRenew.Value + "");
    }


    //evm-0023

    [WebMethod]
    public static string InsuranceProviderDDList(int intOrgId, int intCorpId)
    {
        //loading employees
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        clsEntityLayerVehicleMaster objEntityVehicle = new clsEntityLayerVehicleMaster();

        objEntityVehicle.Corporate_id = intCorpId;
        objEntityVehicle.Organisation_id = intOrgId;
        DataTable dtInsDetails = new DataTable();
        dtInsDetails = objBusinessVehicle.ReadInsuranceProvider(objEntityVehicle);

        dtInsDetails.TableName = "dtTrailerInsrProv";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtInsDetails.WriteXml(sw);
            result = sw.ToString();
        }
        return result;
    }

    [WebMethod]
    public static string InsuranceCovrgTypDDList()
    {
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        DataTable dtVehDetails = new DataTable();
        dtVehDetails = objBusinessVehicle.ReadInsCoverageType();

        dtVehDetails.TableName = "dtTrailerInsrCovrgTyp";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtVehDetails.WriteXml(sw);
            result = sw.ToString();
        }
        return result;
    }
}