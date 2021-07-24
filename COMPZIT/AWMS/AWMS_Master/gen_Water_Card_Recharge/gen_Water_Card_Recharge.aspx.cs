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
// CREATED BY:EVM-0005
// CREATED DATE:27/10/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class AWMS_AWMS_Master_gen_Water_Card_Recharge_gen_Water_Card_Recharge : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        txtRechargeAmount.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtRechargeDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtRemarks.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlCardNumber.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        imgbtnReOpen.ImageUrl = "/Images/Icons/Reopen.png";

        if (!IsPostBack)
        {

            WaterCardLoad();
            
            hiddenBackToCard.Value = "0";
            hiddenRoleReOpen.Value = "0";
            hiddenRoleConfirm.Value = "0";
            imgbtnReOpen.Visible = false;
            btnConfirm.Visible = false;
            divCalciPic.Visible = false;
            ddlCardNumber.Enabled = true;
            int intUserId = 0, intUsrRolMstrId, intEnableReOpen, intEnableConfirm;
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
            // created object for business layer for compare the date
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            string strCurrentDate = objBusiness.LoadCurrentDateInString();

            hiddenCurrentDate.Value = strCurrentDate;
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Water_Card_Recharge);

            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {

                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleReOpen.Value = intEnableReOpen.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleConfirm.Value = intEnableConfirm.ToString();
                    }


                }

            }

            int intCorpId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                            clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDecimalCountCommon.Value = dtCorpDetail.Rows[0]["GN_UNIT_DECIMAL_CNT"].ToString();
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

                if (Request.QueryString["BckCrd"] != null)
                {
                    hiddenBackToCard.Value = "1";

                }

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.Text = "Edit Water Card Recharge";
                ddlCardNumber.Focus();


              
                
            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.Text = "View Water Card Recharge";
            }

            else
            {
                clsBusinessLayerWaterCardRecharge objBusinessWater = new clsBusinessLayerWaterCardRecharge();
                clsEntityLayerWaterCardRecharge objEntityWater = new clsEntityLayerWaterCardRecharge();
                lblEntry.Text = "Add Water Card Recharge";
                
                txtRechargeDate.Text = hiddenCurrentDate.Value;


                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                
                if (Request.QueryString["CrdId"] != null)
                {
                    clsCommonLibrary objCommonLbry = new clsCommonLibrary();
                    int intMoneyDecimalCount = Convert.ToInt32(hiddenDecimalCount.Value);
                    string strRandomMixedId = Request.QueryString["CrdId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strCardId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityWater.CardNumberId = Convert.ToInt32(strCardId);
                    if (strCardId != "")
                    {

                        ddlCardNumber.Items.FindByValue(strCardId).Selected = true;
                    }

                    DataTable dtWaterCardDetail = new DataTable();
                    dtWaterCardDetail = objBusinessWater.ReadWaterCardById(objEntityWater);
                    if (dtWaterCardDetail.Rows.Count > 0)
                    {
                        txtVehicleNumber.Text = dtWaterCardDetail.Rows[0]["VHCL_NUMBR"].ToString();
                        txtCardName.Text = dtWaterCardDetail.Rows[0]["WTRCRD_NAME"].ToString();
                        string decBalAmount = dtWaterCardDetail.Rows[0]["WTRCRD_CURNT_AMNT"].ToString();
                        txtBalanceAmount.Text = objCommonLbry.Format(intMoneyDecimalCount, decBalAmount).ToString();
                        hiddenBalanceAmount.Value = dtWaterCardDetail.Rows[0]["WTRCRD_CURNT_AMNT"].ToString();

                        if (dtWaterCardDetail.Rows[0]["VHCL_ID"].ToString() != "" && dtWaterCardDetail.Rows[0]["VHCL_ID"].ToString() != null)
                        {
                            objEntityWater.VehicleId = Convert.ToInt32(dtWaterCardDetail.Rows[0]["VHCL_ID"].ToString());
                        }
                    }
                    DataTable dtVehicle = objBusinessWater.ReadVehicleDetails(objEntityWater);
                    if (dtVehicle.Rows.Count > 0)
                    {
                        if (dtVehicle.Rows[0]["AMNT_PER_BARREL"].ToString() != "")
                        {
                            decimal AmountPerBarrel = Convert.ToDecimal(dtVehicle.Rows[0]["AMNT_PER_BARREL"].ToString());
                            decimal TankerCapacity = Convert.ToDecimal(dtVehicle.Rows[0]["TANKER_CAPACITY"].ToString());
                            decimal AmountForTrip = AmountPerBarrel * TankerCapacity;
                            hiddenAmountPerBarrel.Value = AmountForTrip.ToString();
                            divCalciPic.Visible = true;
                        }
                    }

                    ddlCardNumber.Enabled = false;
                    txtRechargeAmount.Focus();
                    hiddenBackToCard.Value = "1";

                    divList.Visible = false;
                    btnAdd.Visible = false;
                }
                else
                {
                    ddlCardNumber.Focus();
                }


               
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
                else if (strInsUpd == "CnfrmPnd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ConfirmPnd", "ConfirmPnd();", true);
                }
                    
                else if (strInsUpd == "ReOpen")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
                }
                else if (strInsUpd == "ReOpenFail")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "FailedReOpen", "FailedReOpen();", true);
                }
                else if (strInsUpd == "ReOpnAlrd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ReOpenedAlrdy", "ReOpenedAlrdy();", true);
                }
            }



            hiddenPermitFileSize.Value = Convert.ToInt32(clsCommonLibrary.IMAGE_SIZE.WATER_RECHARGE).ToString();






        }
    }
    //for loading water card details
    protected void WaterCardLoad()
    {
        clsBusinessLayerWaterCardRecharge objBusinessWater = new clsBusinessLayerWaterCardRecharge();
        clsEntityLayerWaterCardRecharge objEntityWater = new clsEntityLayerWaterCardRecharge();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWater.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWater.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtCardDetails = new DataTable();
        dtCardDetails = objBusinessWater.ReadWaterCard(objEntityWater);
        if (dtCardDetails.Rows.Count > 0)
        {
            ddlCardNumber.DataSource = dtCardDetails;
            ddlCardNumber.DataValueField = "WTRCRD_ID";
            ddlCardNumber.DataTextField = "WTRCRD_NUMBER";
            ddlCardNumber.DataBind();


        }
        ddlCardNumber.Items.Insert(0, "--SELECT--");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerWaterCardRecharge objBusinessWater = new clsBusinessLayerWaterCardRecharge();
        clsEntityLayerWaterCardRecharge objEntityWater = new clsEntityLayerWaterCardRecharge();
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null)
        {

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWater.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityWater.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityWater.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strWaterRechId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityWater.WaterCardRchrgeId = Convert.ToInt32(strWaterRechId);

            objEntityWater.CardNumberId = Convert.ToInt32(ddlCardNumber.SelectedItem.Value);

            objEntityWater.RechargeAmnt = Convert.ToDecimal(txtRechargeAmount.Text.Trim());
            objEntityWater.Remark = txtRemarks.Text.Trim();
            objEntityWater.RechargeDate = objCommon.textToDateTime(txtRechargeDate.Text.Trim());

            //Checking is there table have any name like this
            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.WATER_RECHARGE);
            string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.WATER_RECHARGE);
            if (FileUploadRecharge.HasFile)
            {
                // GET FILE EXTENSION

                string strFileExt;
                objEntityWater.FileNameAct = FileUploadRecharge.FileName;
                strFileExt = FileUploadRecharge.FileName.Substring(FileUploadRecharge.FileName.LastIndexOf('.') + 1).ToLower();

                string strImageName = intImageSection.ToString() + "_" + objEntityWater.WaterCardRchrgeId + "." + strFileExt;
                objEntityWater.FileName = strImageName;


            }
            else
            {

                if (hiddenRechargeFile.Value == "")
                {
                    objEntityWater.FileName = "";
                    objEntityWater.FileNameAct = "";

                }
                else
                {
                    objEntityWater.FileName = hiddenRechargeFile.Value;
                    objEntityWater.FileNameAct = hiddenRechargeFileAct.Value;
                }
            }


            objBusinessWater.UpdateWaterCardRecharge(objEntityWater);

            if (FileUploadRecharge.HasFile)
            {
                if (hiddenRechargeFileDeleted.Value != "")
                {
                    string imageLocation = strImgPath + hiddenRechargeFileDeleted.Value;
                    if (File.Exists(MapPath(imageLocation)))
                    {
                        File.Delete(MapPath(imageLocation));
                    }
                }
                FileUploadRecharge.SaveAs(Server.MapPath(strImgPath) + objEntityWater.FileName);
            }
            else
            {
                if (hiddenRechargeFile.Value == "")
                {
                    if (hiddenRechargeFileDeleted.Value != "")
                    {
                        string imageLocation = strImgPath + hiddenRechargeFileDeleted.Value;
                        if (File.Exists(MapPath(imageLocation)))
                        {
                            File.Delete(MapPath(imageLocation));
                        }
                    }
                }
            }




            if (clickedButton.ID == "btnUpdate")
            {

                if (hiddenBackToCard.Value == "0")
                {
                    Response.Redirect("gen_Water_Card_Recharge.aspx?InsUpd=Upd");
                }
                else
                {
                    Response.Redirect("/AWMS/AWMS_Master/gen_Water_Card_Master/gen_Water_Card_Master_List.aspx?InsUpd=RechIns");
                }
            }
            else if (clickedButton.ID == "btnUpdateClose")
            {
                if (hiddenBackToCard.Value == "0")
                {
                    Response.Redirect("gen_Water_Card_Recharge_List.aspx?InsUpd=Upd");
                }
                else
                {
                    Response.Redirect("/AWMS/AWMS_Master/gen_Water_Card_Master/gen_Water_Card_Master_List.aspx?InsUpd=RechIns");
                }

            }

        }
    }




    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerWaterCardRecharge objBusinessWater = new clsBusinessLayerWaterCardRecharge();
        clsEntityLayerWaterCardRecharge objEntityWater = new clsEntityLayerWaterCardRecharge();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWater.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWater.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityWater.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.WATER_RECHARGE);
        objEntityCommon.CorporateID = objEntityWater.Corporate_id;
        objEntityCommon.Organisation_Id = objEntityWater.Organisation_id;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        objEntityWater.NextId = Convert.ToInt32(strNextId);



        objEntityWater.CardNumberId = Convert.ToInt32(ddlCardNumber.SelectedItem.Value);

        objEntityWater.RechargeAmnt = Convert.ToDecimal(txtRechargeAmount.Text.Trim());
        objEntityWater.Remark = txtRemarks.Text.Trim();
        objEntityWater.RechargeDate = objCommon.textToDateTime(txtRechargeDate.Text.Trim());

        //Checking is there table have any name like this
        int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.WATER_RECHARGE);
        string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.WATER_RECHARGE);
        if (FileUploadRecharge.HasFile)
        {
            // GET FILE EXTENSION

            string strFileExt;
            objEntityWater.FileNameAct = FileUploadRecharge.FileName;
            strFileExt = FileUploadRecharge.FileName.Substring(FileUploadRecharge.FileName.LastIndexOf('.') + 1).ToLower();

            string strImageName = intImageSection.ToString() + "_" + objEntityWater.NextId + "." + strFileExt;
            objEntityWater.FileName = strImageName;


        }

        if (hiddenRoleConfirm.Value != "0")
        {

         objBusinessWater.AddWaterCardRecharge(objEntityWater);

 
         string strRandom = objCommon.Random_Number();

         string strId = objEntityWater.NextId.ToString();
         int intIdLength = objEntityWater.NextId.ToString().Length;
         string stridLength = intIdLength.ToString("00");
         string strRechargeId = stridLength + strId + strRandom;


         if (FileUploadRecharge.HasFile)
         {
             FileUploadRecharge.SaveAs(Server.MapPath(strImgPath) + objEntityWater.FileName);
         }
         if (clickedButton.ID == "btnAdd")
         {
             ScriptManager.RegisterStartupScript(this, GetType(), "RedirectConFirm", "RedirectConFirm('" + strRechargeId + "');", true);
         }
         else if (clickedButton.ID == "btnAddClose")
         {

             ScriptManager.RegisterStartupScript(this, GetType(), "RedirectConFirmAdCls", "RedirectConFirmAdCls('" + strRechargeId + "');", true);
         }
        }
        else
        {

            objBusinessWater.AddWaterCardRecharge(objEntityWater);


            if (FileUploadRecharge.HasFile)
            {
                FileUploadRecharge.SaveAs(Server.MapPath(strImgPath) + objEntityWater.FileName);
            }

            if (clickedButton.ID == "btnAdd")
            {
                if (hiddenBackToCard.Value == "0")
                {
                    Response.Redirect("gen_Water_Card_Recharge.aspx?InsUpd=Ins");
                }
                else
                {
                    Response.Redirect("/AWMS/AWMS_Master/gen_Water_Card_Master/gen_Water_Card_Master_List.aspx?InsUpd=RechIns");
                }
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                if (hiddenBackToCard.Value == "0")
                {
                    Response.Redirect("gen_Water_Card_Recharge_List.aspx?InsUpd=Ins");
                }
                else
                {
                    Response.Redirect("/AWMS/AWMS_Master/gen_Water_Card_Master/gen_Water_Card_Master_List.aspx?InsUpd=RechIns");
                }

            }

        }
    }


    public void View(string strWId)
    {

        clsBusinessLayerWaterCardRecharge objBusinessWater = new clsBusinessLayerWaterCardRecharge();
        clsEntityLayerWaterCardRecharge objEntityWater = new clsEntityLayerWaterCardRecharge();
        clsCommonLibrary objCommonLbry = new clsCommonLibrary();
        int intMoneyDecimalCount = Convert.ToInt32(hiddenDecimalCount.Value);
        objEntityWater.WaterCardRchrgeId = Convert.ToInt32(strWId);
        DataTable dtWaterRechargeDetail = new DataTable();
        dtWaterRechargeDetail = objBusinessWater.ReadWaterCardRechargeById(objEntityWater);
        //After fetch insurance details in datatable,we need to differentiate.
        if (dtWaterRechargeDetail.Rows.Count > 0)
        {
            string decBalAmount = dtWaterRechargeDetail.Rows[0]["WTRCRD_CURNT_AMNT"].ToString();
            txtBalanceAmount.Text = objCommonLbry.Format(intMoneyDecimalCount, decBalAmount).ToString();
            txtVehicleNumber.Text = dtWaterRechargeDetail.Rows[0]["VHCL_NUMBR"].ToString();
            txtCardName.Text = dtWaterRechargeDetail.Rows[0]["WTRCRD_NAME"].ToString();
            txtRechargeAmount.Text = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_AMNT"].ToString();
            txtRechargeDate.Text = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_DATE"].ToString();
            txtRemarks.Text = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_REMARK"].ToString();

            decimal intBalance = Convert.ToDecimal(dtWaterRechargeDetail.Rows[0]["WTRCRD_CURNT_AMNT"].ToString());
            decimal intRechargeAmnt = Convert.ToDecimal(dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_AMNT"].ToString());
            decimal intFinalAmnt = intBalance + intRechargeAmnt;
            if (dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_CNFRM_STS"].ToString() == "0")
            {
                txtFinalAmount.Text = intFinalAmnt.ToString();
                string decBalAmount2 = dtWaterRechargeDetail.Rows[0]["WTRCRD_CURNT_AMNT"].ToString();
                txtBalanceAmount.Text = objCommonLbry.Format(intMoneyDecimalCount, decBalAmount2).ToString();
            }
            else
            {
                string decBalBefore = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_BAL_AMNT"].ToString();
                txtBalanceAmount.Text = objCommonLbry.Format(intMoneyDecimalCount, decBalBefore).ToString();
                decimal decFinal = Convert.ToDecimal(decBalBefore) + intRechargeAmnt;
                txtFinalAmount.Text = decFinal.ToString();
            }





            if (dtWaterRechargeDetail.Rows[0]["WTRCRD_ID"].ToString() != "" && dtWaterRechargeDetail.Rows[0]["WTRCRD_ID"] != DBNull.Value)
            {
                if (dtWaterRechargeDetail.Rows[0]["WTRCRD_STATUS"].ToString() == "1")
                {
                    ddlCardNumber.Items.FindByValue(dtWaterRechargeDetail.Rows[0]["WTRCRD_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtWaterRechargeDetail.Rows[0]["WTRCRD_NUMBER"].ToString(), dtWaterRechargeDetail.Rows[0]["WTRCRD_ID"].ToString());
                    ddlCardNumber.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlCardNumber);

                    ddlCardNumber.Items.FindByValue(dtWaterRechargeDetail.Rows[0]["WTRCRD_ID"].ToString()).Selected = true;
                }
            }


            if (dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_FILENAME"] != DBNull.Value && dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_FILENAME"].ToString() != "")
            {
                hiddenRechargeFile.Value = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_FILENAME"].ToString();
                string strFileName = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_FILENAME"].ToString();
                //    divImageEdit.Visible = true;
                clsCommonLibrary objCommon = new clsCommonLibrary();
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.WATER_RECHARGE) + dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_FILENAME"].ToString();
                // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
                string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                string strImage;
                if (strFileExt == "gif" || strFileExt == "png" || strFileExt == "bmp" || strFileExt == "jpeg" || strFileExt == "jpg")
                {

                    // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
                    strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy\" >Click to View Attachment Uploaded</a>";
                    strImage += " <div class=\"lightbox-target\" id=\"goofy\">";
                    strImage += " <img src=\"" + strImagePath + "\"/>";
                    strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                    strImage += "</div>";

                }
                else
                {
                    strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\" target=\"blank\" >Click to View Attachment Uploaded</a>";
                }
                divImageDisplay.InnerHtml = strImage;

            }

            if (dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_FLNM_ACT"] != DBNull.Value && dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_FLNM_ACT"].ToString() != "")
            {
                hiddenRechargeFileAct.Value = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_FLNM_ACT"].ToString();
            }


        }
        txtRechargeAmount.Enabled = false;
        txtRechargeDate.Enabled = false;
        txtRemarks.Enabled = false;
        ddlCardNumber.Enabled = false;
        FileUploadRecharge.Enabled = false;

        btnClear.Visible = false;
        btnConfirm.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strWId)
    {
        clsCommonLibrary objCommonLbry = new clsCommonLibrary();
        clsBusinessLayerWaterCardRecharge objBusinessWater = new clsBusinessLayerWaterCardRecharge();
        clsEntityLayerWaterCardRecharge objEntityWater = new clsEntityLayerWaterCardRecharge();
        int intMoneyDecimalCount = Convert.ToInt32(hiddenDecimalCount.Value);
        objEntityWater.WaterCardRchrgeId = Convert.ToInt32(strWId);
        DataTable dtWaterRechargeDetail = new DataTable();
        dtWaterRechargeDetail = objBusinessWater.ReadWaterCardRechargeById(objEntityWater);
        //After fetch insurance details in datatable,we need to differentiate.
        //After fetch insurance details in datatable,we need to differentiate.
        if (dtWaterRechargeDetail.Rows.Count > 0)
        {
            txtVehicleNumber.Text = dtWaterRechargeDetail.Rows[0]["VHCL_NUMBR"].ToString();
            txtCardName.Text = dtWaterRechargeDetail.Rows[0]["WTRCRD_NAME"].ToString();
            txtRechargeAmount.Text = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_AMNT"].ToString();
            txtRechargeDate.Text = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_DATE"].ToString();
            txtRemarks.Text = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_REMARK"].ToString();

            decimal intBalance = Convert.ToDecimal(dtWaterRechargeDetail.Rows[0]["WTRCRD_CURNT_AMNT"].ToString());
            hiddenBalanceAmount.Value = dtWaterRechargeDetail.Rows[0]["WTRCRD_CURNT_AMNT"].ToString();
            decimal intRechargeAmnt = Convert.ToDecimal(dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_AMNT"].ToString());
            decimal intFinalAmnt = intBalance + intRechargeAmnt;
            if (dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_CNFRM_STS"].ToString() == "0")
            {
                txtFinalAmount.Text = intFinalAmnt.ToString();
                string decBalAmount = dtWaterRechargeDetail.Rows[0]["WTRCRD_CURNT_AMNT"].ToString();
                txtBalanceAmount.Text = objCommonLbry.Format(intMoneyDecimalCount, decBalAmount);
            }
            else
            {

                string decBalBefore = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_BAL_AMNT"].ToString();
                txtBalanceAmount.Text = objCommonLbry.Format(intMoneyDecimalCount, decBalBefore);
                decimal decFinal = Convert.ToDecimal(decBalBefore) + intRechargeAmnt;
                txtFinalAmount.Text = decFinal.ToString();
            }


            if (dtWaterRechargeDetail.Rows[0]["WTRCRD_ID"].ToString() != "" && dtWaterRechargeDetail.Rows[0]["WTRCRD_ID"] != DBNull.Value)
            {
                if (dtWaterRechargeDetail.Rows[0]["WTRCRD_STATUS"].ToString() == "1")
                {
                    ddlCardNumber.Items.FindByValue(dtWaterRechargeDetail.Rows[0]["WTRCRD_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtWaterRechargeDetail.Rows[0]["WTRCRD_NUMBER"].ToString(), dtWaterRechargeDetail.Rows[0]["WTRCRD_ID"].ToString());
                    ddlCardNumber.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlCardNumber);

                    ddlCardNumber.Items.FindByValue(dtWaterRechargeDetail.Rows[0]["WTRCRD_ID"].ToString()).Selected = true;
                }
            }


            //for loading calculator
            if (ddlCardNumber.SelectedItem.Text != "--SELECT--")
            {
                objEntityWater.CardNumberId = Convert.ToInt32(ddlCardNumber.SelectedItem.Value);
            }
            DataTable dtCardDetails = new DataTable();
            dtCardDetails = objBusinessWater.ReadWaterCardDetails(objEntityWater);
            if (dtCardDetails.Rows.Count > 0)
            {
                txtVehicleNumber.Text = dtCardDetails.Rows[0]["VHCL_NUMBR"].ToString();
                txtCardName.Text = dtCardDetails.Rows[0]["WTRCRD_NAME"].ToString();
                string decBalAmount = dtCardDetails.Rows[0]["WTRCRD_CURNT_AMNT"].ToString();
                txtBalanceAmount.Text = objCommonLbry.Format(intMoneyDecimalCount, decBalAmount).ToString();
                hiddenBalanceAmount.Value = dtCardDetails.Rows[0]["WTRCRD_CURNT_AMNT"].ToString();
                if (dtCardDetails.Rows[0]["VHCL_ID"].ToString() != "" && dtCardDetails.Rows[0]["VHCL_ID"].ToString() != null)
                {
                    objEntityWater.VehicleId = Convert.ToInt32(dtCardDetails.Rows[0]["VHCL_ID"].ToString());
                }
            }
            DataTable dtVehicle = objBusinessWater.ReadVehicleDetails(objEntityWater);
            if (dtVehicle.Rows.Count > 0)
            {
                if (dtVehicle.Rows[0]["AMNT_PER_BARREL"].ToString() != "")
                {
                    decimal AmountPerBarrel = Convert.ToDecimal(dtVehicle.Rows[0]["AMNT_PER_BARREL"].ToString());
                    decimal TankerCapacity = Convert.ToDecimal(dtVehicle.Rows[0]["TANKER_CAPACITY"].ToString());
                    decimal AmountForTrip = AmountPerBarrel * TankerCapacity;
                    hiddenAmountPerBarrel.Value = AmountForTrip.ToString();
                    divCalciPic.Visible = true;
                }

            }

            if (dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_FILENAME"] != DBNull.Value && dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_FILENAME"].ToString() != "")
            {
                hiddenRechargeFile.Value = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_FILENAME"].ToString();
                hiddenRechargeFileAct.Value = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_FLNM_ACT"].ToString();
                string strFileName = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_FILENAME"].ToString();
                //    divImageEdit.Visible = true;
                clsCommonLibrary objCommon = new clsCommonLibrary();
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.WATER_RECHARGE) + dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_FILENAME"].ToString();


                string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                string strImage;
                if (strFileExt == "gif" || strFileExt == "png" || strFileExt == "bmp" || strFileExt == "jpeg" || strFileExt == "jpg")
                {

                    // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
                    strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy\" >Click to View Attachment Uploaded</a>";
                    strImage += " <div class=\"lightbox-target\" id=\"goofy\">";
                    strImage += " <img src=\"" + strImagePath + "\"/>";
                    strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                    strImage += "</div>";

                }
                else
                {
                    strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\" target=\"blank\" >Click to View Attachment Uploaded</a>";
                }
                divImageDisplay.InnerHtml = strImage;
            }
            if (hiddenRoleReOpen.Value != "")
            {
                if (hiddenRoleReOpen.Value == "1")
                {

                    if (dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_CNFRM_STS"].ToString() == "1")
                    {
                        txtRechargeAmount.Enabled = false;
                        txtRechargeDate.Enabled = false;
                        txtRemarks.Enabled = false;
                        ddlCardNumber.Enabled = false;
                        FileUploadRecharge.Enabled = false;
                        if (intBalance < intRechargeAmnt)
                        {
                            imgbtnReOpen.Visible = false;
                        }
                        else
                        {
                            imgbtnReOpen.Visible = true;
                        }
                    }
                    else
                    {
                        imgbtnReOpen.Visible = false;
                    }
                }
                else
                {
                    if (dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_CNFRM_STS"].ToString() == "1")
                    {
                        txtRechargeAmount.Enabled = false;
                        txtRechargeDate.Enabled = false;
                        txtRemarks.Enabled = false;
                        ddlCardNumber.Enabled = false;
                        FileUploadRecharge.Enabled = false;
                    }
                    imgbtnReOpen.Visible = false;
                }
            }





            if (hiddenRoleConfirm.Value == "1")
            {

                if (dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_CNFRM_STS"].ToString() == "1")
                {
                    btnConfirm.Visible = false;
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                }
                else
                {
                    btnConfirm.Visible = true;
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = true;
                }
            }
            else
            {
                if (dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_CNFRM_STS"].ToString() == "0")
                {
                    btnConfirm.Visible = false;
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                }
                else
                {
                    btnConfirm.Visible = false;
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = true;
                }
            }


            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Water_Card_Recharge);
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
            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_CNFRM_STS"].ToString() == "1")
                {
                    btnUpdate.Visible = false;
                }
                else
                {
                    btnUpdate.Visible = true;
                }

            }
            else
            {

                btnUpdate.Visible = false;

            }




        }

        if (hiddenBackToCard.Value != "0")
        {
            btnUpdate.Visible = false;
            ddlCardNumber.Enabled = false;
            divList.Visible = false;
        }

        btnClear.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;

    }
    protected void ddlCardNumber_SelectedIndexChanged(object sender, EventArgs e)
    {  
        int intCorpId=0;
        divCalciPic.Visible = false;
        hiddenConfirmValue.Value = "1";
        int intMoneyDecimalCount = Convert.ToInt32(hiddenDecimalCount.Value);
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
          if (Session["CORPOFFICEID"] != null)
                {
                  
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
              


                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {   
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                }
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
       
        clsBusinessLayerWaterCardRecharge objBusinessWater = new clsBusinessLayerWaterCardRecharge();
        clsEntityLayerWaterCardRecharge objEntityWater = new clsEntityLayerWaterCardRecharge();
        if (ddlCardNumber.SelectedItem.Text != "--SELECT--")
        {
            objEntityWater.CardNumberId = Convert.ToInt32(ddlCardNumber.SelectedItem.Value);
        }
        DataTable dtCardDetails = new DataTable();
        dtCardDetails = objBusinessWater.ReadWaterCardDetails(objEntityWater);
        if (dtCardDetails.Rows.Count > 0)
        {
           txtVehicleNumber.Text = dtCardDetails.Rows[0]["VHCL_NUMBR"].ToString();
           txtCardName.Text = dtCardDetails.Rows[0]["WTRCRD_NAME"].ToString();
            string decBalAmount = dtCardDetails.Rows[0]["WTRCRD_CURNT_AMNT"].ToString();
            string balAmnt=objCommon.Format(intMoneyDecimalCount, decBalAmount).ToString();
            txtBalanceAmount.Text = objBusinessLayer.AddCommasForNumberSeperation(balAmnt, objEntityCommon);
           // txtBalanceAmount.Text = objCommon.Format(intMoneyDecimalCount, decBalAmount).ToString();

            hiddenBalanceAmount.Value = dtCardDetails.Rows[0]["WTRCRD_CURNT_AMNT"].ToString();
            if (dtCardDetails.Rows[0]["VHCL_ID"].ToString() != "" && dtCardDetails.Rows[0]["VHCL_ID"].ToString() != null)
            {
                objEntityWater.VehicleId = Convert.ToInt32(dtCardDetails.Rows[0]["VHCL_ID"].ToString());
            }
        }

        DataTable dtVehicle = objBusinessWater.ReadVehicleDetails(objEntityWater);
        if (dtVehicle.Rows.Count > 0)
        {
            if (dtVehicle.Rows[0]["AMNT_PER_BARREL"].ToString() != "")
            {
                decimal AmountPerBarrel = Convert.ToDecimal(dtVehicle.Rows[0]["AMNT_PER_BARREL"].ToString());
                decimal TankerCapacity = Convert.ToDecimal(dtVehicle.Rows[0]["TANKER_CAPACITY"].ToString());
                decimal AmountForTrip = AmountPerBarrel * TankerCapacity;
                hiddenAmountPerBarrel.Value = AmountForTrip.ToString();
                divCalciPic.Visible = true;
            }
        }

        ScriptManager.RegisterStartupScript(this, GetType(), "AmountCheckPostback", "AmountCheckPostback('cphMain_txtRechargeAmount');", true);
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        clsBusinessLayerWaterCardRecharge objBusinessWater = new clsBusinessLayerWaterCardRecharge();
        clsEntityLayerWaterCardRecharge objEntityWater = new clsEntityLayerWaterCardRecharge();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null)
        {

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWater.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityWater.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityWater.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strWaterRechId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityWater.WaterCardRchrgeId = Convert.ToInt32(strWaterRechId);




            //for save and confirm

            objEntityWater.CardNumberId = Convert.ToInt32(ddlCardNumber.SelectedItem.Value);

            objEntityWater.RechargeAmnt = Convert.ToDecimal(txtRechargeAmount.Text.Trim());
            objEntityWater.Remark = txtRemarks.Text.Trim();
            objEntityWater.RechargeDate = objCommon.textToDateTime(txtRechargeDate.Text.Trim());

            //Checking is there table have any name like this
            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.WATER_RECHARGE);
            string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.WATER_RECHARGE);
            if (FileUploadRecharge.HasFile)
            {
                // GET FILE EXTENSION

                string strFileExt;
                objEntityWater.FileNameAct = FileUploadRecharge.FileName;
                strFileExt = FileUploadRecharge.FileName.Substring(FileUploadRecharge.FileName.LastIndexOf('.') + 1).ToLower();

                string strImageName = intImageSection.ToString() + "_" + objEntityWater.WaterCardRchrgeId + "." + strFileExt;
                objEntityWater.FileName = strImageName;


            }
            else
            {

                if (hiddenRechargeFile.Value == "")
                {
                    objEntityWater.FileName = "";
                    objEntityWater.FileNameAct = "";

                }
                else
                {
                    objEntityWater.FileName = hiddenRechargeFile.Value;
                    objEntityWater.FileNameAct = hiddenRechargeFileAct.Value;
                }
            }



            objBusinessWater.UpdateWaterCardRecharge(objEntityWater);

            if (FileUploadRecharge.HasFile)
            {
                if (hiddenRechargeFileDeleted.Value != "")
                {
                    string imageLocation = strImgPath + hiddenRechargeFileDeleted.Value;
                    if (File.Exists(MapPath(imageLocation)))
                    {
                        File.Delete(MapPath(imageLocation));
                    }
                }
                FileUploadRecharge.SaveAs(Server.MapPath(strImgPath) + objEntityWater.FileName);
            }
            else
            {
                if (hiddenRechargeFile.Value == "")
                {
                    if (hiddenRechargeFileDeleted.Value != "")
                    {
                        string imageLocation = strImgPath + hiddenRechargeFileDeleted.Value;
                        if (File.Exists(MapPath(imageLocation)))
                        {
                            File.Delete(MapPath(imageLocation));
                        }
                    }
                }
            }
        }




        DataTable dtWaterRechargeDetail = new DataTable();
        dtWaterRechargeDetail = objBusinessWater.ReadWaterCardRechargeById(objEntityWater);
        //After fetch insurance details in datatable,we need to differentiate.
        decimal intBalance = 0;
        string strConfirmSts = "0";
        if (dtWaterRechargeDetail.Rows.Count > 0)
        {
            intBalance = Convert.ToDecimal(dtWaterRechargeDetail.Rows[0]["WTRCRD_CURNT_AMNT"].ToString());
            strConfirmSts = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_CNFRM_STS"].ToString();

        }
        decimal intRechAmount = Convert.ToDecimal(txtRechargeAmount.Text.Trim());

        decimal TotalAmount = intBalance + intRechAmount;
        objEntityWater.BalanceBeforeCnfrm = intBalance;
        objEntityWater.BalanceAmount = TotalAmount;

        objEntityWater.Status_id = 1;

        if (strConfirmSts == "0")
        {
            objBusinessWater.ConfirmWaterCardRecharge(objEntityWater);


            if (hiddenBackToCard.Value == "0")
            {
                Response.Redirect("gen_Water_Card_Recharge.aspx?InsUpd=Cnfrm");
            }
            else
            {
                Response.Redirect("/AWMS/AWMS_Master/gen_Water_Card_Master/gen_Water_Card_Master_List.aspx?InsUpd=Rech");
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ConfirmedAlready", "ConfirmedAlready();", true);

        }

    }


    protected void imgbtnReOpen_Click(object sender, ImageClickEventArgs e)
    {
        clsBusinessLayerWaterCardRecharge objBusinessWater = new clsBusinessLayerWaterCardRecharge();
        clsEntityLayerWaterCardRecharge objEntityWater = new clsEntityLayerWaterCardRecharge();
        Button clickedButton = sender as Button;
        string strEditId = Request.QueryString["Id"].ToString();
        if (Request.QueryString["Id"] != null)
        {

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWater.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityWater.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityWater.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strWaterRechId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityWater.WaterCardRchrgeId = Convert.ToInt32(strWaterRechId);

            DataTable dtWaterRechargeDetail = new DataTable();
            dtWaterRechargeDetail = objBusinessWater.ReadWaterCardRechargeById(objEntityWater);
            //After fetch insurance details in datatable,we need to differentiate.
            decimal intBalance = 0;
            string strConfirmSts ="0";
            if (dtWaterRechargeDetail.Rows.Count > 0)
            {
                intBalance = Convert.ToDecimal(dtWaterRechargeDetail.Rows[0]["WTRCRD_CURNT_AMNT"].ToString());
                objEntityWater.CardNumberId = Convert.ToInt32(dtWaterRechargeDetail.Rows[0]["WTRCRD_ID"].ToString());
                strConfirmSts = dtWaterRechargeDetail.Rows[0]["WTCRDRCHRG_CNFRM_STS"].ToString();
            }


            decimal intRechAmount = Convert.ToDecimal(txtRechargeAmount.Text.Trim());

            decimal TotalAmount = intBalance - intRechAmount;
            objEntityWater.BalanceAmount = TotalAmount;

            objEntityWater.Status_id = 0;
            if (strConfirmSts == "1")
            {
                if (intBalance >= intRechAmount)
                {
                    objBusinessWater.ReOpenWaterCardRecharge(objEntityWater);

                    Response.Redirect("gen_Water_Card_Recharge.aspx?InsUpd=ReOpen");
                }
                else
                {
                    Response.Redirect("gen_Water_Card_Recharge.aspx?InsUpd=ReOpenFail&&Id=" + strEditId + "");
                }
            }
            else
            {
                Response.Redirect("gen_Water_Card_Recharge.aspx?InsUpd=ReOpnAlrd&&Id=" + strEditId + "");
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["CrdId"] != null)
        {
            string CardId = Request.QueryString["CrdId"].ToString();
            Response.Redirect("gen_Water_Card_Recharge.aspx?CrdId=" + CardId + "");
        }
        else
        {
            Response.Redirect("gen_Water_Card_Recharge.aspx");
        }
       
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (hiddenBackToCard.Value != "1")
        {
            Response.Redirect("/AWMS/AWMS_Master/gen_Water_Card_Recharge/gen_Water_Card_Recharge_List.aspx");
        }
        else
        {
            Response.Redirect("/AWMS/AWMS_Master/gen_Water_Card_Master/gen_Water_Card_Master_List.aspx");
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