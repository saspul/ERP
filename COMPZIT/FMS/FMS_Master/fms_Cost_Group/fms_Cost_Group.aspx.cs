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
public partial class FMS_FMS_Master_fms_Cost_Group_fms_Cost_Group : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtName.Focus();
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
            clsBusinessLyer_Cost_Group objBusinessCOST = new clsBusinessLyer_Cost_Group();
            clsEntityLayer_Cost_Group objEntity = new clsEntityLayer_Cost_Group();
            LoadCostGroup();
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
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Cost_Group);
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
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED,
                                                            clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                            clsCommonLibrary.CORP_GLOBAL.FMS_VIEW_CODE_STS,
                                                            clsCommonLibrary.CORP_GLOBAL.FMS_CODE_FORMATE
                                                           
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCostGroupCode.Value = dtCorpDetail.Rows[0]["FMS_VIEW_CODE_STS"].ToString();

                if (dtCorpDetail.Rows[0]["FMS_CODE_FORMATE"].ToString() != "")
                {
                    HiddenCodeFormate.Value = dtCorpDetail.Rows[0]["FMS_CODE_FORMATE"].ToString();
                }

            }
            if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
                bttnsave.Visible = false;
                btnsaveAndClose.Visible = false;
                //bttnUpdate.Visible = false;

            }


            if (HiddenCodeFormate.Value == "1")
            {
                txtCode.Enabled = true;
            }
            else
            {
                txtCode.Enabled = false;
            }


            if (HiddenCostGroupCode.Value == "1")
            {
                DivCostGroupCode.Visible = true;
            }
            else
            {
                DivCostGroupCode.Visible = false;
            }

            // user role given above
            if (Request.QueryString["Id"] != null)
            {
                lblEntry.Text = "Edit Cost Group";
                bttnsave.Visible = false;
                btnsaveAndClose.Visible = false;
                ButtnClose.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId);
            }
            else if (Request.QueryString["ViewId"] != null)
            {
                lblEntry.Text = "View Cost Group";
                bttnsave.Visible = false;
                btnsaveAndClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
                ButtnClose.Visible = false;
                ddlLevel.Enabled = false;
                txtCode.Enabled = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                CheckBox1.Disabled = true;
                txtName.Enabled = false;
               Update(strId);
            }
            else
            {
                lblEntry.Text = "Add Cost Group";
                //DivCostGroupCode.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
                if (HiddenCodeFormate.Value == "1")
                {

                }
                else
                {
                    //evm 0044
                    //CreateGroupCode();
                    CreateGroupCode1();


                }

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
                txtName.Focus();
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            }

        }
    }
    public void CreateGroupCode()
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        //   LoadAccountGroup();
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
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.Cost_Group);
        DataTable dtFormate = objBusinessLayer.ReadCodeFormate(objEntityCommon);
        string refFormatByDiv = "";
        string strRealFormat = "";
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


                    txtCode.Text = strRealFormat;
                }
         
        }



    }
    //evm 0044
    public void CreateGroupCode1()
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        //   LoadAccountGroup();
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
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.COST_GROUP_START_REF );
        string strRealFormat = "";
        int costgrpnextnum = 0;
        costgrpnextnum = Convert.ToInt32(objBusinessLayer.ReadNextNumberOnly(objEntityCommon));
        if (costgrpnextnum == 0)
        {
            objEntityCommon.DefaultModId = 5;
            DataTable dtDefaltModData = objBusinessLayer.ReadDefaultModValues(objEntityCommon);
            if (dtDefaltModData.Rows.Count > 0)
            {
                costgrpnextnum = Convert.ToInt32(dtDefaltModData.Rows[0]["MOD_DFLT_VALUE"].ToString());
                strRealFormat = Convert.ToString(costgrpnextnum);

            }

        }
        else
        {
            strRealFormat = costgrpnextnum.ToString();
        }

        txtCode.Text = strRealFormat;

    }

    protected void bttnsave_Click(object sender, EventArgs e)
    {
      
        Button clickedButton = sender as Button;
        clsBusinessLyer_Cost_Group objBusinessCOST = new clsBusinessLyer_Cost_Group();
        clsEntityLayer_Cost_Group objEntity = new clsEntityLayer_Cost_Group();
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
       //string strP_Id = "";
       // objEntity.CostId = Convert.ToInt32(strP_Id);

        objEntity.Name = txtName.Text;


        if (CheckBox1.Checked == true)
        {
            objEntity.Status = 1;
        }
        else
        {
            objEntity.Status = 0;
        }
        string strNameCount = "0";
        string strCodeCount = "0";


        if (txtName.Text != "" && txtName.Text != null)
        {
            objEntity.Name = txtName.Text.Trim();
            strNameCount = objBusinessCOST.CheckCostName(objEntity);

        }
        if (ddlLevel.SelectedValue != "0" && ddlLevel.SelectedValue != "--SELECT LEVEL--")
        {
            objEntity.HierarchyId = Convert.ToInt32(ddlLevel.SelectedValue);
        }

        if (HiddenCodeFormate.Value != "")
        {
            objEntity.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
        }


        if (HiddenCostGroupCode.Value != "")
        {
            objEntity.CodePrsncSts = Convert.ToInt32(HiddenCostGroupCode.Value);
        }


        objEntity.GrpCode = txtCode.Text;


        if (txtCode.Text != "" && txtCode.Text != null)
        {

            strCodeCount = objBusinessCOST.CheckCodeDuplicatn(objEntity);

        }

        if (strNameCount == "0" && strCodeCount=="0")
        {
            objBusinessCOST.InsertCostGroup(objEntity);
            if (clickedButton.ID == "bttnsave")
            {
                Response.Redirect("fms_Cost_Group.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnsaveAndClose")
            {
                Response.Redirect("fms_Cost_Group_List.aspx?InsUpd=Ins");
            }
        }
        else
        {
            if (strNameCount != "0")
            {
                //Response.Redirect("fms_Cost_Group.aspx?InsUpd=dup");
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

            }

            else if (strCodeCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);

            }

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        
       Button clickedButton = sender as Button;
       clsBusinessLyer_Cost_Group objBusinessCOST = new clsBusinessLyer_Cost_Group();
        clsEntityLayer_Cost_Group objEntity = new clsEntityLayer_Cost_Group();
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
        string strRandomMixedId = Request.QueryString["Id"].ToString();
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntity.CostId = Convert.ToInt32(strId);
        if (ddlLevel.SelectedValue != "0" && ddlLevel.SelectedValue != "--SELECT LEVEL--")
        {
            objEntity.HierarchyId = Convert.ToInt32(ddlLevel.SelectedValue);
        }
        DataTable dtCancel = objBusinessCOST.CostGroupCancelChk(objEntity);
        if (dtCancel.Rows.Count > 0)
        {
            if (Convert.ToInt32(dtCancel.Rows[0][0].ToString()) > 0)
            {
                Response.Redirect("fms_Cost_Group_List.aspx?InsUpd=AlCancl");
                //ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyCancelMsg", "AlreadyCancelMsg();", true);
            }
        }
        else
        {
            objEntity.Name = txtName.Text;

            if (CheckBox1.Checked == true)
            {
                objEntity.Status = 1;
            }
            else
            {
                objEntity.Status = 0;
            }
            string strNameCount = "0";
            string strCodeCount = "0";

            if (HiddenCodeFormate.Value != "")
            {
                objEntity.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
            }


            if (HiddenCostGroupCode.Value != "")
            {
                objEntity.CodePrsncSts = Convert.ToInt32(HiddenCostGroupCode.Value);
            }


            objEntity.GrpCode = txtCode.Text;

            if (txtCode.Text != "" && txtCode.Text != null)
            {

                strCodeCount = objBusinessCOST.CheckCodeDuplicatn(objEntity);

            }

            if (txtName.Text != "" && txtName.Text != null)
            {
                objEntity.Name = txtName.Text;
                strNameCount = objBusinessCOST.CheckCostName(objEntity);

            }

            if (strNameCount == "0" && strCodeCount=="0")
            {
                objBusinessCOST.UpdateCostGroup(objEntity);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("fms_Cost_Group.aspx?InsUpd=Upd&Id=" + strRandomMixedId);
                }
                else if (clickedButton.ID == "btnUpdateAndClose")
                {
                    Response.Redirect("fms_Cost_Group_List.aspx?InsUpd=Upd");
                }
            }
            else
            {
                if (strNameCount != "0")
                {
                    //Response.Redirect("fms_Cost_Group.aspx?InsUpd=dup");
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                }
                else if (strCodeCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);

                }

            }
        }
    }
    
    public void Update(string strP_Id)
    {
        clsBusinessLyer_Cost_Group objBusinessCOST = new clsBusinessLyer_Cost_Group();
        clsEntityLayer_Cost_Group objEntity = new clsEntityLayer_Cost_Group();
        
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
        objEntity.CostId = Convert.ToInt32(strP_Id);



        DataTable dt = objBusinessCOST.ReadCOSTById(objEntity);
        if (dt.Rows.Count > 0)
        {


            txtName.Text = dt.Rows[0]["COSTGRP_NAME"].ToString();

            int STS = Convert.ToInt32(dt.Rows[0]["COSTGRP_STATUS"].ToString());
            if (STS == 1)
            {
                CheckBox1.Checked = true;
            }
            else
            {
                CheckBox1.Checked = false;
            }
            if (dt.Rows[0]["COSTGRP_CODE"].ToString() != "" && dt.Rows[0]["COSTGRP_CODE"].ToString() != null)
            {
                txtCode.Text = dt.Rows[0]["COSTGRP_CODE"].ToString();
            }
            ddlLevel.ClearSelection();
            if (ddlLevel.Items.FindByValue(dt.Rows[0]["HIRCHY_ID"].ToString()) != null)
            {
                ddlLevel.Items.FindByValue(dt.Rows[0]["HIRCHY_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dt.Rows[0]["HIRCHY_NAME"].ToString(), dt.Rows[0]["HIRCHY_ID"].ToString());
                ddlLevel.Items.Insert(1, lstGrp);
                SortDDL(ref this.ddlLevel);
                ddlLevel.Items.FindByValue(dt.Rows[0]["HIRCHY_ID"].ToString()).Selected = true;
            }
          
            //else
            //{ 


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
    public void LoadCostGroup()
    {
        clsBusinessLyer_Cost_Group objBusinessCOST = new clsBusinessLyer_Cost_Group();
        clsEntityLayer_Cost_Group objEntity = new clsEntityLayer_Cost_Group();
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
        DataTable dtdiv = objBusinessCOST.ReadCostGroupHierarchy(objEntity);
        if (dtdiv.Rows.Count > 0)
        {
            ddlLevel.DataSource = dtdiv;
            ddlLevel.DataTextField = "HIRCHY_NAME";
            ddlLevel.DataValueField = "HIRCHY_ID";
            ddlLevel.DataBind();
        }
        ddlLevel.Items.Insert(0, "--SELECT LEVEL--");

    }
}