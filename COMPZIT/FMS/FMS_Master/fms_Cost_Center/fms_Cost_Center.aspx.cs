using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit;
using CL_Compzit;
using System.Data;
using BL_Compzit.BusineesLayer_FMS;
using System.Web.Services;
public partial class FMS_FMS_Master_fms_Cost_Center_fms_Cost_Center : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FRMWRK_ID"] != null && Session["FRMWRK_ID"].ToString() == "2")
        {
            aHome.HRef = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
        }
        else
        {
            aHome.HRef = " /Home/Compzit_LandingPage/Compzit_LandingPage.aspx";
        }
        if (!IsPostBack)
        {
            txtName.Focus();
            LoadCostGroup();
            clsBusinessLayer_Cost_Center objBusinessCostCenter = new clsBusinessLayer_Cost_Center();
            clsEntityLayer_Cost_Center objEntity = new clsEntityLayer_Cost_Center();

            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

                objEntity.UserId = intUserId;

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                objEntity.Corp_Id = intCorpId;
               

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntity.Org_Id = intOrgId;

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                             clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID ,                                                                     
                                                             clsCommonLibrary.CORP_GLOBAL.FMS_VIEW_CODE_STS ,
                                                               clsCommonLibrary.CORP_GLOBAL.FMS_CODE_FORMATE              
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenFieldDecimalCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                HiddenCodeStatus.Value = dtCorpDetail.Rows[0]["FMS_VIEW_CODE_STS"].ToString();

                if (dtCorpDetail.Rows[0]["FMS_CODE_FORMATE"].ToString() != "")
                { 
                    HiddenCodeFormate.Value = dtCorpDetail.Rows[0]["FMS_CODE_FORMATE"].ToString();
                }
            }
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
            }


            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Cost_Center);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleConf.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        // HiddenRoleEdit.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active); ;
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        // hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }


                }
            }


            if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
                bttnsave.Visible = false;
                btnsaveAndClose.Visible = false;
            }


            if (HiddenCodeFormate.Value == "1")
            {
                txtCode.Enabled = true;
            }
            else
            {
                txtCode.Enabled = false;
            }



             if (HiddenCodeStatus.Value == "1")
            {
                DivCostCentreCode.Visible = true;
            }
            else
            {
                DivCostCentreCode.Visible = false;
            }
            
            // user role given above
            if (Request.QueryString["Id"] != null)
            {
                lblEntry.Text = "Edit Cost Centre";
                btnsaveAndClose.Visible = false;
                ButtnClose.Visible = false;
                bttnsave.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId);
            }
            else if (Request.QueryString["ViewId"] != null)
            {
                lblEntry.Text = "View Cost Centre";
                bttnsave.Visible = false;
                btnsaveAndClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
                ButtnClose.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                ddlCC.Enabled = false;
                CheckBox1.Disabled = true;
                txtName.Enabled = false;
                txtblnce.Enabled = false;
                typdebit.Disabled=true;
                typecredit.Disabled = true;
                rdExpense.Disabled = true;
                rdIncome.Disabled = true;

                txtCode.Enabled = false;
                Update(strId);
            }
            else
            {
                lblEntry.Text = "Add Cost Centre";
               // DivCostCentreCode.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
            }


        }
        if (Request.QueryString["InsUpd"] != null)
        {
            string strInsUpd = Request.QueryString["InsUpd"].ToString();
            if (strInsUpd == "Ins")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
            }
            if (strInsUpd == "Upd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
            }
            if (strInsUpd == "dup")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            }

        }
    }
    
    [WebMethod]
    public static string CrateCodeFormate(string orgID, string corptID, string CstGrpId)
    {
        string sts = "";
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();



        int intCorpId = 0;
        if (corptID != null)
        {

            intCorpId = Convert.ToInt32(corptID);
            objEntityCommon.CorporateID = Convert.ToInt32(corptID);

        }

        if (orgID != null)
        {

            objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);

        }

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTER);
        DataTable dtFormate = objBusinessLayer.ReadCodeFormate(objEntityCommon);
        string refFormatByDiv = "";
        string strRealFormat = "";

        DataTable dt = new DataTable();




        if (dtFormate.Rows.Count > 0)
        {



            // CodeFormate = NaureCode.ToString() + dtNextNumber;
            if (dtFormate.Rows[0]["CODE_FORMATE"].ToString() != "")
            {
                refFormatByDiv = dtFormate.Rows[0]["CODE_FORMATE"].ToString();
                string strReferenceFormat = "";
                strReferenceFormat = refFormatByDiv;
                string[] arrReferenceSplit = strReferenceFormat.Split('*');
                int intArrayRowCount = arrReferenceSplit.Length;
                int Codecount = 0;
                strRealFormat = refFormatByDiv.ToString();

                if (strRealFormat.Contains("#NUM#"))
                {
                    string dtNextNumber = objBusinessLayer.ReadNextSequence(objEntityCommon);


                    strRealFormat = strRealFormat.Replace("#NUM#", dtNextNumber);


                }
                if (strRealFormat.Contains("#CSTGRP#"))
                {
                    string dtNextNumber = objBusinessLayer.ReadNextSequence(objEntityCommon);


                    strRealFormat = strRealFormat.Replace("#CSTGRP#", CstGrpId);


                }
                if (dtFormate.Rows[0]["CODE_COUNT"].ToString() != "")
                {
                    Codecount = Convert.ToInt32(dtFormate.Rows[0]["CODE_COUNT"].ToString());
                }

                int k = strRealFormat.Length;
                if (k < Codecount)
                {
                    int Difrnce = Codecount - k;
                    k = k + Difrnce;
                    //  hello.PadLeft(50, '#');
                    strRealFormat = strRealFormat.PadLeft(k, '0');
                }


                sts = strRealFormat;
            }

        }

        return sts.ToString();
    }
    //evm 0044-----------------
    public void CreateCostCntrCode()
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLyer_Cost_Group objBusinessCOST = new clsBusinessLyer_Cost_Group();
        clsEntityLayer_Cost_Group objEntity = new clsEntityLayer_Cost_Group();
        if (Session["USERID"] != null)
        {

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {

            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntity.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }


        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {

            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTER_START_REf );
        string strRealFormat = "";
        objEntity.CostId = Convert.ToInt32(ddlCC.SelectedItem .Value );
        int costcntrnextnum = 0;
        DataTable dtcostgrp = new DataTable();
        dtcostgrp = objBusinessCOST.ReadCOSTById(objEntity);
        if (dtcostgrp.Rows.Count > 0)
        {
            costcntrnextnum = Convert.ToInt32(dtcostgrp.Rows[0]["COSTGRP_NEXTID_COSTCNTR"]);
            if (costcntrnextnum == 0)
            {
                
                objEntityCommon.DefaultModId =  Convert.ToInt32(clsCommonLibrary.Section.COST_CENTER_START_REf) ;
                DataTable dtDefaltModData = objBusinessLayer.ReadDefaultModValues(objEntityCommon);
                if (dtDefaltModData.Rows.Count > 0)
                {
                    costcntrnextnum = Convert.ToInt32(dtDefaltModData.Rows[0]["MOD_DFLT_VALUE"]);
                    strRealFormat = dtcostgrp.Rows[0]["COSTGRP_CODE"].ToString() + Convert.ToString(costcntrnextnum);

                }

            }
            else
            {
              
                strRealFormat = dtcostgrp.Rows[0]["COSTGRP_CODE"].ToString() + Convert.ToString(costcntrnextnum);
            }
        }

        txtCode.Text = strRealFormat;
    }
    [WebMethod]
    public static string CreateCodeFormate(string orgID, string corptID, string CstGrpId)
    {
        string sts = "";
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLyer_Cost_Group objBusinessCOST = new clsBusinessLyer_Cost_Group();
        clsEntityLayer_Cost_Group objEntity = new clsEntityLayer_Cost_Group();

        int intCorpId = 0;
        if (corptID != null)
        {

            intCorpId = Convert.ToInt32(corptID);
            objEntityCommon.CorporateID = Convert.ToInt32(corptID);
            objEntity.Corp_Id = Convert.ToInt32(corptID); ;

        }

        if (orgID != null)
        {

            objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
            objEntity.Org_Id = Convert.ToInt32(orgID);

        }

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTER);
        objEntity.CostId =Convert.ToInt32 (CstGrpId);
        string strRealFormat = "";
        int costcntrnextnum = 0;
        DataTable dtcostgrp = new DataTable();
        dtcostgrp  =objBusinessCOST .ReadCOSTById (objEntity);
        if (dtcostgrp.Rows.Count > 0)
        {
            costcntrnextnum = Convert.ToInt32(dtcostgrp.Rows[0]["COSTGRP_NEXTID_COSTCNTR"]);
            if (costcntrnextnum == 0)
            {
               
                objEntityCommon.DefaultModId = 6;
                DataTable dtDefaltModData = objBusinessLayer.ReadDefaultModValues(objEntityCommon);
                if (dtDefaltModData.Rows.Count > 0)
                {
                    costcntrnextnum = Convert.ToInt32(dtDefaltModData.Rows[0]["MOD_DFLT_VALUE"]);
                    strRealFormat = dtcostgrp.Rows[0]["COSTGRP_CODE"].ToString() + Convert.ToString(costcntrnextnum);

                }

            }
            else
            {
               strRealFormat = dtcostgrp.Rows[0]["COSTGRP_CODE"].ToString() + Convert.ToString(costcntrnextnum);
            }
        }
       
        sts = strRealFormat;
        return sts.ToString();
    }
    //-----------------------------------------------------
    public void LoadCostGroup()
    {
        clsEntityLayer_Cost_Center objEntity = new clsEntityLayer_Cost_Center();
        clsBusinessLayer_Cost_Center objBusinessCostCenter = new clsBusinessLayer_Cost_Center();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UserId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.Corp_Id = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.Org_Id = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdiv = objBusinessCostCenter.ReadCostGroup(objEntity);
        if (dtdiv.Rows.Count > 0)
        {
            ddlCC.DataSource = dtdiv;
            ddlCC.DataTextField = "COSTGRP_NAME";

            ddlCC.DataValueField = "COSTGRP_ID";
            ddlCC.DataBind();
        }
        ddlCC.Items.Insert(0, "--SELECT GROUP--");

    }

    protected void bttnsave_Click(object sender, EventArgs e)
    {

        Button clickedButton = sender as Button;
        clsBusinessLayer_Cost_Center objBusinessCostCenter = new clsBusinessLayer_Cost_Center();
        clsEntityLayer_Cost_Center objEntity = new clsEntityLayer_Cost_Center();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UserId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.Corp_Id = intCorpId;
           

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.Org_Id = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntity.grpId = Convert.ToInt32(ddlCC.SelectedItem.Value.ToString());
        objEntity.Name = txtName.Text.Trim();


        if (CheckBox1.Checked == true)
        {
            objEntity.Status = 1;
        }
        else
        {
            objEntity.Status = 0;
        }
        if (rdExpense.Checked == true)
        {
            objEntity.Nature = 1;
        }
        string strNameCount = "0";
        string strCstCodeCount = "0";
        if (txtName.Text != "" && txtName.Text != null)
        {
            objEntity.Name = txtName.Text.Trim();
            strNameCount = objBusinessCostCenter.CheckCostName(objEntity);

        }
        if (txtblnce.Text != "" && txtblnce.Text != null)
        {
            objEntity.Balance = Convert.ToDecimal(txtblnce.Text.ToString());
            if (typdebit.Checked == true)
            {
                objEntity.DCStatus = 0;
            }
            else
            {
                objEntity.DCStatus = 1;
            }

        }


        if (HiddenCodeFormate.Value != "")
        {
            objEntity.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
        }
        CreateCostCntrCode();//evm 0044
        objEntity.GrpCode = txtCode.Text;

        if (HiddenCodeStatus.Value != "")
        {
            objEntity.CodePrsntSts = Convert.ToInt32(HiddenCodeStatus.Value);
        }


        strCstCodeCount = objBusinessCostCenter.CheckCodeDuplicatn(objEntity);
        if (strNameCount == "0" && strCstCodeCount=="0")
        {
            objBusinessCostCenter.InsertCostCenter(objEntity);
            objBusinessCostCenter.UpdateCostGroupNextId(objEntity);//evm 0044
            if (clickedButton.ID == "bttnsave")
            {
                Response.Redirect("fms_Cost_Center.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnsaveAndClose")
            {
                Response.Redirect("fms_Cost_Center_List.aspx?InsUpd=Ins");
            }
        }
        else
        {
            if (strNameCount != "0")
            {
                //Response.Redirect("fms_Cost_Center.aspx?InsUpd=dup");
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

            }
            else if (strCstCodeCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCstCntrCodeMsg", "DuplicationCstCntrCodeMsg();", true);

            }

        }
    }
   
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLayer_Cost_Center objBusinessCostCenter = new clsBusinessLayer_Cost_Center();
        clsEntityLayer_Cost_Center objEntity = new clsEntityLayer_Cost_Center();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UserId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.Corp_Id = intCorpId;


        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.Org_Id = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        string strRandomMixedId = Request.QueryString["Id"].ToString();
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntity.CostId = Convert.ToInt32(strId);


        if (HiddenCodeFormate.Value != "")
        {
            objEntity.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
        }
        CreateCostCntrCode();//evm 0044
        objEntity.GrpCode = txtCode.Text;



        DataTable dtCancel = objBusinessCostCenter.CostCenterCancelChk(objEntity);
        if (dtCancel.Rows.Count > 0)
        {
            if (Convert.ToInt32(dtCancel.Rows[0][0].ToString()) > 0)
            {
                Response.Redirect("fms_Cost_Center_List.aspx?InsUpd=AlCancl");
                //ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyCancelMsg", "AlreadyCancelMsg();", true);
            }
        }
        else
        {
            objEntity.grpId = Convert.ToInt32(ddlCC.SelectedItem.Value.ToString());
            objEntity.Name = txtName.Text.Trim();
            if (CheckBox1.Checked == true)
            {
                objEntity.Status = 1;
            }
            else
            {
                objEntity.Status = 0;
            }
            if (rdExpense.Checked == true)
            {
                objEntity.Nature = 1;
            }
            string strNameCount = "0";


            string strCstCodeCount = "0";

            if (txtName.Text != "" && txtName.Text != null)
            {
                objEntity.Name = txtName.Text.Trim();
                strNameCount = objBusinessCostCenter.CheckCostName(objEntity);

            }
            if (txtCode.Text != "" && txtName.Text != null)
            {

                strCstCodeCount = objBusinessCostCenter.CheckCodeDuplicatn(objEntity);
            }


            if (txtblnce.Text != "" && txtblnce.Text != null)
            {
                objEntity.Balance = Convert.ToDecimal(txtblnce.Text.ToString());
               if (typdebit.Checked == true)
              {
                  objEntity.DCStatus = 0;
                }
                else
               {
                    objEntity.DCStatus = 1;
            }

            }


            if (HiddenCodeStatus.Value != "")
            {
                objEntity.CodePrsntSts = Convert.ToInt32(HiddenCodeStatus.Value);
            }

            if (strNameCount == "0" && strCstCodeCount=="0")
            {
                objBusinessCostCenter.UpdateCostCenter(objEntity);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("fms_Cost_Center.aspx?InsUpd=Upd&Id=" + strRandomMixedId);
                }
                else if (clickedButton.ID == "btnUpdateAndClose")
                {
                    Response.Redirect("fms_Cost_Center_List.aspx?InsUpd=Upd");
                }
            }
            else
            {
                if (strNameCount != "0")
                {
                    //Response.Redirect("fms_Cost_Center.aspx?InsUpd=dup");
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

                }
                else if (strCstCodeCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCstCntrCodeMsg", "DuplicationCstCntrCodeMsg();", true);

                }

            }
        }
    }
    public void Update(string strP_Id)
    {
        clsBusinessLayer_Cost_Center objBusinessCostCenter = new clsBusinessLayer_Cost_Center();
        clsEntityLayer_Cost_Center objEntity = new clsEntityLayer_Cost_Center();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UserId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.Corp_Id = intCorpId;


        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.Org_Id = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntity.CostId = Convert.ToInt32(strP_Id);

        DataTable dt = objBusinessCostCenter.ReadCostCenterById(objEntity);
        if (dt.Rows.Count > 0)
        {



            if (dt.Rows[0]["COSTCNTR_NATURE"].ToString() == "0")
            {
                rdIncome.Checked = true;
            }
            else
            {
                rdExpense.Checked = true;
            }


            if (dt.Rows[0]["LDGR_ID"].ToString() != "")
            {
                txtName.Enabled = false;
            }


            ddlCC.ClearSelection();
            if (ddlCC.Items.FindByValue(dt.Rows[0]["COSTGRP_ID"].ToString()) != null)
            {
                ddlCC.Items.FindByValue(dt.Rows[0]["COSTGRP_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dt.Rows[0]["COSTGRP_NAME"].ToString(), dt.Rows[0]["COSTGRP_ID"].ToString());
                ddlCC.Items.Insert(1, lstGrp);
                SortDDL(ref this.ddlCC);
                ddlCC.Items.FindByValue(dt.Rows[0]["COSTGRP_ID"].ToString()).Selected = true;
            }
            //ddlCC.Items.FindByText(dt.Rows[0]["COSTGRP_NAME"].ToString()).Selected = true;
            txtName.Text = dt.Rows[0]["COSTCNTR_NAME"].ToString();
            int DC_STS = 0;
            if (dt.Rows[0]["COSTCNTR_DC_STS"].ToString() == "")
            {
                txtblnce.Text = null;
                //DandC.Attributes["style"] = "float: right; width: 89%;display:none;";
            }
            if (dt.Rows[0]["COSTCNTR_DC_STS"].ToString() != "")
            {
                DC_STS = Convert.ToInt32(dt.Rows[0]["COSTCNTR_DC_STS"].ToString());
                if (DC_STS == 0)
                {

                    //DandC.Attributes["style"] = "float: right; width: 89%;display:block;";
                    typdebit.Checked = true;
                }
                else if (DC_STS == 1)
                {

                    //DandC.Attributes["style"] = "float: right; width: 89%;display:block;";
                    typecredit.Checked = true;
                }
                if (dt.Rows[0]["COSTCNTR_OPENING_BALNC"].ToString() != "")
                {
                    txtblnce.Text = dt.Rows[0]["COSTCNTR_OPENING_BALNC"].ToString();
                }
            }
            if (dt.Rows[0]["COSTCNTR_CODE"].ToString() != "")
            {
                txtCode.Text = dt.Rows[0]["COSTCNTR_CODE"].ToString();
            }

            int STS = Convert.ToInt32(dt.Rows[0]["COSTCNTR_STATUS"].ToString());
            if (STS == 1)
            {
                CheckBox1.Checked = true;
            }
            else
            {
                CheckBox1.Checked = false;
            }
        }


    }
    private void SortDDL(ref DropDownList objDDL)
    {
        System.Collections.ArrayList textList = new System.Collections.ArrayList();
        System.Collections.ArrayList valueList = new System.Collections.ArrayList();


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