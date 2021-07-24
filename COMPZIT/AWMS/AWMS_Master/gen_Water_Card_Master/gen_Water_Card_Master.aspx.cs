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
// CREATED DATE:23/10/2016
// REVIEWED BY:
// REVIEW DATE:
public partial class AWMS_AWMS_Master_gen_Water_Card_Master_gen_Water_Card_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCardName.Attributes.Add("onkeypress", "return isTag(event)");
        txtCardName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtCardNumber.Attributes.Add("onkeypress", "return isTag(event)");
        txtCardNumber.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAlertAmount.Attributes.Add("onkeypress", "return isTag(event)");
        txtAlertAmount.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtOpeningAmount.Attributes.Add("onkeypress", "return isTag(event)");
        txtOpeningAmount.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtCardEspiryDate.Attributes.Add("onkeypress", "return isTag(event)");
    
        txtCardIsueDate.Attributes.Add("onkeypress", "return isTag(event)");

        ddlBank.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlVehicleNumber.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        if (!IsPostBack)
        {
            BankLoad();
            VehicleNumberLoad();
            txtCardNumber.Focus();
            //when editing 
            hiddenBalanceChangeNtps.Value = "0";
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.Text = "Edit Water Card";

            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.Text = "View Water Card";
            }

            else
            {
                lblEntry.Text = "Add Water Card";

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
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
                Response.Redirect("~/Default.aspx");
            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                            clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
             DataTable dtCorpDetail = new DataTable();
             dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                    hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                }
                clsEntityCommon objEntityCommon = new clsEntityCommon();
                // cliebt side number format
                objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                DataTable dtCurrencyDetail = new DataTable();
                dtCurrencyDetail = objBusiness.ReadCurrencyDetails(objEntityCommon);
                if (dtCurrencyDetail.Rows.Count > 0)
                {
                    hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();

                } 

        }
    }

    protected void BankLoad()
    {
        clsBusinessLayerWaterCard objBusinessWater = new clsBusinessLayerWaterCard();
        clsEntityLayerWaterCardMaster objEntityWater = new clsEntityLayerWaterCardMaster();
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

        DataTable dtBankDetails = new DataTable();
        dtBankDetails = objBusinessWater.ReadBank(objEntityWater);
        if (dtBankDetails.Rows.Count > 0)
        {
            ddlBank.DataSource = dtBankDetails;
            ddlBank.DataValueField = "BANK_ID";
            ddlBank.DataTextField = "BANK_NAME";
            ddlBank.DataBind();


        }
        ddlBank.Items.Insert(0, "--SELECT--");
    }
    protected void VehicleNumberLoad()
    {
        clsBusinessLayerWaterCard objBusinessWater = new clsBusinessLayerWaterCard();
        clsEntityLayerWaterCardMaster objEntityWater = new clsEntityLayerWaterCardMaster();
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

        DataTable dtVehDetails = new DataTable();
        dtVehDetails = objBusinessWater.ReadVehicleNumber(objEntityWater);
        if (dtVehDetails.Rows.Count > 0)
        {
            ddlVehicleNumber.DataSource = dtVehDetails;
            ddlVehicleNumber.DataValueField = "VHCL_ID";
            ddlVehicleNumber.DataTextField = "VHCL_NUMBR";
            ddlVehicleNumber.DataBind();


        }
        ddlVehicleNumber.Items.Insert(0, "--SELECT--");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerWaterCard objBusinessWater = new clsBusinessLayerWaterCard();
        clsEntityLayerWaterCardMaster objEntityWater = new clsEntityLayerWaterCardMaster();
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
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityWater.Status_id = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityWater.Status_id = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strWaterId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityWater.WaterCardMasterId = Convert.ToInt32(strWaterId);
           
            objEntityWater.CardNumber = txtCardNumber.Text.Trim().ToUpper();
            objEntityWater.CardExpiry = objCommon.textToDateTime(txtCardEspiryDate.Text.Trim());
            objEntityWater.BankId = Convert.ToInt32(ddlBank.SelectedItem.Value);

            if (hiddenBalanceChangeNtps.Value != "1")
            {
                if (txtOpeningAmount.Text != "" && txtOpeningAmount.Text != null)
                {
                    objEntityWater.OpeningAmount = Convert.ToDecimal(txtOpeningAmount.Text.Trim());
                    objEntityWater.BalanceAmount = Convert.ToDecimal(txtOpeningAmount.Text.Trim());
                }
               
            }
            else
            {
                objEntityWater.OpeningAmount = Convert.ToDecimal(txtOpeningAmount.Text.Trim());
                objEntityWater.BalanceAmount = Convert.ToDecimal(txtBalanceAmount.Text.Trim());
            }
           

            if (txtCardIsueDate.Text != "" && txtCardIsueDate.Text != null)
            {
                objEntityWater.CardIsuedDate = objCommon.textToDateTime(txtCardIsueDate.Text);
            }

            if(ddlVehicleNumber.SelectedItem.Value !="--SELECT--")
            {
            objEntityWater.VehNumber = Convert.ToInt32(ddlVehicleNumber.SelectedItem.Value);
            }

            if (txtAlertAmount.Text != "" && txtAlertAmount.Text != null)
            {
                objEntityWater.AlertAmount = Convert.ToDecimal(txtAlertAmount.Text.Trim());
            }
            string strCardNameCount = "0";
            if (txtCardName.Text != "" && txtCardName.Text != null)
            {
                objEntityWater.CardName = txtCardName.Text.Trim().ToUpper();
                strCardNameCount = objBusinessWater.CheckWaterCardName(objEntityWater);
            }


            string strNameCount = objBusinessWater.CheckWaterCardNumber(objEntityWater);

            //If there is no name like this on table.    
            if (strNameCount == "0" && strCardNameCount == "0")
            {
                objBusinessWater.UpdateWaterCard(objEntityWater);

                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_Water_Card_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Water_Card_Master_List.aspx?InsUpd=Upd");
                }

            }
            //If have
            else
            {
              
                if (strCardNameCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCardName", "DuplicationCardName();", true);

                }
                if (strNameCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

                }
            }
        }
    }




    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerWaterCard objBusinessWater = new clsBusinessLayerWaterCard();
        clsEntityLayerWaterCardMaster objEntityWater = new clsEntityLayerWaterCardMaster();
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

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityWater.Status_id = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityWater.Status_id = 0;
        }


        objEntityWater.CardNumber = txtCardNumber.Text.Trim().ToUpper();
        objEntityWater.CardExpiry = objCommon.textToDateTime(txtCardEspiryDate.Text.Trim());
        objEntityWater.BankId = Convert.ToInt32(ddlBank.SelectedItem.Value);

        if (txtOpeningAmount.Text != "" && txtOpeningAmount.Text != null)
        {
            objEntityWater.OpeningAmount = Convert.ToDecimal(txtOpeningAmount.Text.Trim());
            objEntityWater.BalanceAmount = Convert.ToDecimal(txtOpeningAmount.Text.Trim());
           
        }

        if (txtCardIsueDate.Text != "" && txtCardIsueDate.Text != null)
        {
            objEntityWater.CardIsuedDate = objCommon.textToDateTime(txtCardIsueDate.Text);
        }

        if (ddlVehicleNumber.SelectedItem.Value != "--SELECT--")
        {
            objEntityWater.VehNumber = Convert.ToInt32(ddlVehicleNumber.SelectedItem.Value);
        }

        if (txtAlertAmount.Text != "" && txtAlertAmount.Text != null)
        {
            objEntityWater.AlertAmount = Convert.ToDecimal(txtAlertAmount.Text.Trim());
        }
        string strCardNameCount = "0";
        if (txtCardName.Text != "" && txtCardName.Text != null)
        {
            objEntityWater.CardName = txtCardName.Text.Trim().ToUpper();
            strCardNameCount = objBusinessWater.CheckWaterCardName(objEntityWater);
        }
        



        //Checking is there table have any name like this
        string strNameCount = objBusinessWater.CheckWaterCardNumber(objEntityWater);
        //If there is no name like this on table.    
        if (strNameCount == "0" && strCardNameCount == "0")
        {
            objBusinessWater.AddWaterCard(objEntityWater);

            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Water_Card_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Water_Card_Master_List.aspx?InsUpd=Ins");
            }

        }
        //If have
        else
        {
          

            if (strCardNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCardName", "DuplicationCardName();", true);

            }
            if (strNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

            }

        }
    }


    public void View(string strWId)
    {

        clsBusinessLayerWaterCard objBusinessWater = new clsBusinessLayerWaterCard();
        clsEntityLayerWaterCardMaster objEntityWater = new clsEntityLayerWaterCardMaster();

        objEntityWater.WaterCardMasterId = Convert.ToInt32(strWId);
        DataTable dtWaterCardDetail = new DataTable();
        dtWaterCardDetail = objBusinessWater.ReadWaterCardById(objEntityWater);
        //After fetch insurance details in datatable,we need to differentiate.
        if (dtWaterCardDetail.Rows.Count > 0)
        {
            txtCardNumber.Text = dtWaterCardDetail.Rows[0]["WTRCRD_NUMBER"].ToString();
            txtCardEspiryDate.Text = dtWaterCardDetail.Rows[0]["WTRCRD_EXPDATE"].ToString();
            txtOpeningAmount.Text = dtWaterCardDetail.Rows[0]["WTRCRD_OPNG_AMNT"].ToString();
            txtCardIsueDate.Text = dtWaterCardDetail.Rows[0]["WTRCRD_ISUEDATE"].ToString();
            txtAlertAmount.Text = dtWaterCardDetail.Rows[0]["ALERT_AMNT"].ToString();
            txtCardName.Text = dtWaterCardDetail.Rows[0]["WTRCRD_NAME"].ToString();
            txtBalanceAmount.Text = dtWaterCardDetail.Rows[0]["WTRCRD_CURNT_AMNT"].ToString();

            if (dtWaterCardDetail.Rows[0]["BANK_ID"].ToString() != "" && dtWaterCardDetail.Rows[0]["BANK_ID"] != DBNull.Value)
            {
                if (dtWaterCardDetail.Rows[0]["BANK_STATUS"].ToString() != "0")
                {
                    ddlBank.Items.FindByValue(dtWaterCardDetail.Rows[0]["BANK_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtWaterCardDetail.Rows[0]["BANK_NAME"].ToString(), dtWaterCardDetail.Rows[0]["BANK_ID"].ToString());
                    ddlBank.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlBank);

                    ddlBank.Items.FindByValue(dtWaterCardDetail.Rows[0]["BANK_ID"].ToString()).Selected = true;
                }
            }
            if (dtWaterCardDetail.Rows[0]["VHCL_ID"].ToString() != "" && dtWaterCardDetail.Rows[0]["VHCL_ID"] != DBNull.Value)
            {
                if (dtWaterCardDetail.Rows[0]["VHCL_STATUS"].ToString() != "0")
                {
                    if (dtWaterCardDetail.Rows[0]["IS_VHCL_TANKER"].ToString() != "0")
                    {
                        ddlVehicleNumber.Items.FindByValue(dtWaterCardDetail.Rows[0]["VHCL_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtWaterCardDetail.Rows[0]["VHCL_NUMBR"].ToString(), dtWaterCardDetail.Rows[0]["VHCL_ID"].ToString());
                        ddlVehicleNumber.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlVehicleNumber);

                        ddlVehicleNumber.Items.FindByValue(dtWaterCardDetail.Rows[0]["VHCL_ID"].ToString()).Selected = true;

                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtWaterCardDetail.Rows[0]["VHCL_NUMBR"].ToString(), dtWaterCardDetail.Rows[0]["VHCL_ID"].ToString());
                    ddlVehicleNumber.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlVehicleNumber);

                    ddlVehicleNumber.Items.FindByValue(dtWaterCardDetail.Rows[0]["VHCL_ID"].ToString()).Selected = true;

                }
            }
            int intInsuretStatus = Convert.ToInt32(dtWaterCardDetail.Rows[0]["WTRCRD_STATUS"]);
            if (intInsuretStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
        txtCardNumber.Enabled = false;
        txtCardEspiryDate.Enabled = false;
        txtOpeningAmount.Enabled = false;
        txtCardIsueDate.Enabled = false;
        ddlVehicleNumber.Enabled = false;
        txtAlertAmount.Enabled = false;
        txtCardName.Enabled = false;
        txtBalanceAmount.Enabled = false;
        ddlBank.Enabled = false;

        btnClear.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        cbxStatus.Enabled = false;
        cbxStatus.Attributes["style"] = "pointer-events: none;";
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strWId)
    {

        clsBusinessLayerWaterCard objBusinessWater = new clsBusinessLayerWaterCard();
        clsEntityLayerWaterCardMaster objEntityWater = new clsEntityLayerWaterCardMaster();
        objEntityWater.WaterCardMasterId = Convert.ToInt32(strWId);
        DataTable dtWaterCardDetail = new DataTable();
        dtWaterCardDetail = objBusinessWater.ReadWaterCardById(objEntityWater);
        //After fetch insurance details in datatable,we need to differentiate.
        if (dtWaterCardDetail.Rows.Count > 0)
        {
            txtCardNumber.Text = dtWaterCardDetail.Rows[0]["WTRCRD_NUMBER"].ToString();
            txtCardEspiryDate.Text = dtWaterCardDetail.Rows[0]["WTRCRD_EXPDATE"].ToString();
            txtOpeningAmount.Text = dtWaterCardDetail.Rows[0]["WTRCRD_OPNG_AMNT"].ToString();
            txtCardIsueDate.Text = dtWaterCardDetail.Rows[0]["WTRCRD_ISUEDATE"].ToString();
            txtAlertAmount.Text = dtWaterCardDetail.Rows[0]["ALERT_AMNT"].ToString();
            txtCardName.Text = dtWaterCardDetail.Rows[0]["WTRCRD_NAME"].ToString();
            txtBalanceAmount.Text = dtWaterCardDetail.Rows[0]["WTRCRD_CURNT_AMNT"].ToString();

            if (dtWaterCardDetail.Rows[0]["BANK_ID"].ToString() != "" && dtWaterCardDetail.Rows[0]["BANK_ID"] != DBNull.Value)
            {
                if (dtWaterCardDetail.Rows[0]["BANK_STATUS"].ToString() != "0")
                {
                    ddlBank.Items.FindByValue(dtWaterCardDetail.Rows[0]["BANK_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtWaterCardDetail.Rows[0]["BANK_NAME"].ToString(), dtWaterCardDetail.Rows[0]["BANK_ID"].ToString());
                    ddlBank.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlBank);

                    ddlBank.Items.FindByValue(dtWaterCardDetail.Rows[0]["BANK_ID"].ToString()).Selected = true;
                }
            }
            if (dtWaterCardDetail.Rows[0]["VHCL_ID"].ToString() != "" && dtWaterCardDetail.Rows[0]["VHCL_ID"] != DBNull.Value)
            {
                if (dtWaterCardDetail.Rows[0]["VHCL_STATUS"].ToString()!="0")
                {
                    if (dtWaterCardDetail.Rows[0]["IS_VHCL_TANKER"].ToString() != "0")
                    {
                        ddlVehicleNumber.Items.FindByValue(dtWaterCardDetail.Rows[0]["VHCL_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtWaterCardDetail.Rows[0]["VHCL_NUMBR"].ToString(), dtWaterCardDetail.Rows[0]["VHCL_ID"].ToString());
                        ddlVehicleNumber.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlVehicleNumber);

                        ddlVehicleNumber.Items.FindByValue(dtWaterCardDetail.Rows[0]["VHCL_ID"].ToString()).Selected = true;

                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtWaterCardDetail.Rows[0]["VHCL_NUMBR"].ToString(), dtWaterCardDetail.Rows[0]["VHCL_ID"].ToString());
                    ddlVehicleNumber.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlVehicleNumber);

                    ddlVehicleNumber.Items.FindByValue(dtWaterCardDetail.Rows[0]["VHCL_ID"].ToString()).Selected = true;

                }
            }
            int intInsuretStatus = Convert.ToInt32(dtWaterCardDetail.Rows[0]["WTRCRD_STATUS"]);
            if (intInsuretStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            decimal CurrentAmount =Convert.ToDecimal(dtWaterCardDetail.Rows[0]["WTRCRD_CURNT_AMNT"].ToString());
            decimal OpeningAmount = Convert.ToDecimal(dtWaterCardDetail.Rows[0]["WTRCRD_OPNG_AMNT"].ToString());
            if (CurrentAmount != OpeningAmount)
            {
                txtOpeningAmount.Enabled = false;
                hiddenBalanceChangeNtps.Value = "1";
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
            Response.Redirect("~/Default.aspx");
        }
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Water_Card_Master);
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
            btnUpdate.Visible = true;

        }
        else
        {

            btnUpdate.Visible = false;

        }

        btnClear.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdateClose.Visible = true;
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("gen_Water_Card_Master.aspx");
    }

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