using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusinessLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using System.Data;
using System.Web.Services;

public partial class FMS_Account_Group_AccountGroup : System.Web.UI.Page
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

        clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();
        clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();
        txtAccountName.Focus();
        txtAccountName.Attributes.Add("onkeypress", "return isTagEnter(event)");
        cbxGrossProfit.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ChkStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
       

        if (!IsPostBack)
        {
            HiddenEditable.Value = "";
            HiddenDirctIndirect.Value = "0";
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            LoadAccountGroup();
            if (Session["USERID"] != null)
            {
                objEntityAccountGroup.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityAccountGroup.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }


            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityAccountGroup.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.FMS_CODE_FORMATE
                                                           
                                                      
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {

                if (dtCorpDetail.Rows[0]["FMS_CODE_FORMATE"].ToString() != "")
                {
                    HiddenCodeFormate.Value = dtCorpDetail.Rows[0]["FMS_CODE_FORMATE"].ToString();
                }

            }


            if (HiddenCodeFormate.Value == "1")
            {
                txtGrpCode.Enabled = true;
            }
            else
            {
                txtGrpCode.Enabled = false;
            }

            cbxGrossProfit.Checked = false;
            radioDirect.Checked = true;

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                ButtnClose.Visible = false;
                Update(strId,"UPD");
                lblEntry.Text = "Edit Account Group";

            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenView.Value = "1";
                Update(strId,"VIEW");

                lblEntry.Text = "View Account Group";
            }

            else
            {
                lblEntry.Text = "Add Account Group";
                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
                btnsaveAndClose.Visible = false;
                btnsave.Visible = true;
                //btnsave1.Visible = true;
                btnsaveAndClose.Visible = true;


                if (HiddenCodeFormate.Value == "1")
                {
                   
                }
                else
                {
                    //evm 0044
                    //CreateGroupCode();
                    CreateGroupCodeByLevel();

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
            else if (strInsUpd == "Upd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
            }
            else if (strInsUpd == "Dup")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsg();", true);
            }
        }
    }
    // evm 0044--------
    public void CreateGroupCodeByLevel()
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();
        clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();
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
            //evm 0044
            objEntityAccountGroup.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
            
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
         
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityAccountGroup.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ACCOUNT_GROUP_START_REF);
        int acctgrpnextnum = 0;
        acctgrpnextnum = Convert.ToInt32(objBusinessLayer.ReadNextNumberOnly (objEntityCommon));
        if (acctgrpnextnum == 0)
        {
            objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.ACCOUNT_GROUP_START_REF  ); 
            DataTable dtDefaltModData = objBusinessLayer.ReadDefaultModValues(objEntityCommon);
            if (dtDefaltModData.Rows.Count > 0)
            {
                acctgrpnextnum = Convert.ToInt32(dtDefaltModData.Rows[0]["MOD_DFLT_VALUE"].ToString());
                txtGrpCode .Text =Convert .ToString (acctgrpnextnum );
               
            }

        }
        else
        {
            objEntityAccountGroup.AccountGrpName  = ddlParntGrp.SelectedItem.Text;
            objEntityAccountGroup.AccountGrpId = Convert.ToInt32(ddlParntGrp.SelectedItem.Value);
            if (objEntityAccountGroup.AccountGrpName == "PRIMARY")
            {
                txtGrpCode.Text = Convert.ToString(acctgrpnextnum);
            }

            else
            {
                int subgrpnextnum = 0;
                DataTable dtactgroup = objBusinessAcountGrp.LoadAccountGroupBYId(objEntityAccountGroup);
                if (dtactgroup.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtactgroup.Rows[0]["ACNT_NEXTID_GROUP"].ToString()) == 0)
                    {
                        objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.ACCOUNT_SUB_GROUP_START_REF);
                        objEntityCommon.CorporateID = objEntityAccountGroup.CorpId;
                        objEntityCommon.Organisation_Id = objEntityAccountGroup.OrgId;
                        DataTable dtDefaltModData = objBusinessLayer.ReadDefaultModValues(objEntityCommon);
                        if (dtDefaltModData.Rows.Count > 0)
                        {
                            subgrpnextnum = Convert.ToInt32(dtDefaltModData.Rows[0]["MOD_DFLT_VALUE"].ToString());
                            txtGrpCode.Text = dtactgroup.Rows[0]["ACNT_CODE"].ToString() + Convert.ToString(subgrpnextnum);

                        }
                    }
                    else
                    {
                        subgrpnextnum = Convert.ToInt32(dtactgroup.Rows[0]["ACNT_NEXTID_GROUP"].ToString());
                        txtGrpCode.Text = dtactgroup.Rows[0]["ACNT_CODE"].ToString() + Convert.ToString(subgrpnextnum);

                    }
                }

            }
            
        }
        
         
    }
    //--------------------
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
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ACCOUNT_GROUP);
        DataTable dtFormate = objBusinessLayer.ReadCodeFormate(objEntityCommon);
        string refFormatByDiv = "";
        string strRealFormat = "";
        if (dtFormate.Rows.Count > 0)
        {
            if (ddlNature.SelectedItem.Text != "")
            {

                int NaureCode = 0;
                string CodeFormate = "";
                int intNature = Convert.ToInt32(ddlNature.SelectedItem.Value);

                if (intNature == 0)
                {
                    NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Asset);
                }
                else if (intNature == 1)
                {
                    NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Liability);
                }
                else if (intNature == 2)
                {
                    NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Expense);
                }
                else if (intNature == 3)
                {
                    NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Income);
                }



                CodeFormate = NaureCode.ToString();

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
                    if (strRealFormat.Contains("#NAT#"))
                    {
                        strRealFormat = strRealFormat.Replace("#NAT#", NaureCode.ToString());


                    }
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


                    txtGrpCode.Text = strRealFormat;
                }
            }
        }



    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();
        clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int flag = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccountGroup.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccountGroup.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityAccountGroup.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityAccountGroup.AccountGrpName = txtAccountName.Text;
        objEntityAccountGroup.ParentAccountGrpId = Convert.ToInt32(ddlParntGrp.SelectedItem.Value);
        objEntityAccountGroup.NatureId = Convert.ToInt32(ddlNature.SelectedItem.Value);
        if (cbxGrossProfit.Checked)
        {
            objEntityAccountGroup.Affect_Gross_Profit = 0;
        }
        else
        {
            objEntityAccountGroup.Affect_Gross_Profit = 1;
        }
        if (HiddenDirctIndirect.Value=="0")
        {
            objEntityAccountGroup.NatureType = 0;
        }
        else if (HiddenDirctIndirect.Value=="1")
        {
            objEntityAccountGroup.NatureType = 1;
        }
        if (ChkStatus.Checked)
        {
            objEntityAccountGroup.GroupStatus = 1;
        }
        else
        {
            objEntityAccountGroup.GroupStatus = 0;
        }

        if (ChkAddressSts.Checked == true)
        {
            objEntityAccountGroup.AddressStatus = 1;
        }
        else
        {
            objEntityAccountGroup.AddressStatus = 0;
        }
        CreateGroupCodeByLevel();
        objEntityAccountGroup.GrpCode = txtGrpCode.Text.Trim();

        if (HiddenCodeFormate.Value != "")
        {
            objEntityAccountGroup.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
        }
        DataTable dtIns = objBusinessAcountGrp.AccountGroupDplctnChk(objEntityAccountGroup);
        if (dtIns.Rows.Count > 0)
        {
            int idcount=Convert.ToInt32(dtIns.Rows[0][0].ToString());
            if (idcount > 0)
            {
                flag++;
                //Response.Redirect("AccountGroup.aspx?InsUpd=Dup");
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsg();", true);
            }
        }
        if (flag == 0)
        {
            string strCodeCount = objBusinessAcountGrp.CheckCodeDuplicatn(objEntityAccountGroup);

            if (strCodeCount == "0")
            {

                objBusinessAcountGrp.InsertAccountGroup(objEntityAccountGroup);
                objBusinessAcountGrp.UpdateAccountGroupNextGroup(objEntityAccountGroup);//evm 0044
                if (clickedButton.ID == "btnsave")
                {
                    Response.Redirect("AccountGroup.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnsaveAndClose")
                {
                    Response.Redirect("Account_Group_List.aspx?InsUpd=Ins");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCodeMsg", "DuplicationCodeMsg();", true);
            }
        }
    }
    public void LoadAccountGroup()
    {
        clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();
        clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();
     
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccountGroup.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccountGroup.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtAccount = objBusinessAcountGrp.LoadAccountGroup(objEntityAccountGroup);
        ddlParntGrp.Items.Clear();

        ddlParntGrp.DataSource = dtAccount;
        ddlParntGrp.DataTextField = "ACNT_GRP_NAME";
        ddlParntGrp.DataValueField = "ACNT_GRP_ID";
        ddlParntGrp.DataBind();
       //ddlParntGrp.Items.Insert(0, "");

        int prmryVal = Convert.ToInt32(dtAccount.Rows[0]["PRIMARY"].ToString());
            
         //   Convert.ToInt32( (clsCommonLibrary.ACNT_GRP_ID.PRIMARY).ToString());
        ListItem selectedListItem = ddlParntGrp.Items.FindByValue(prmryVal.ToString());

        if (selectedListItem != null)
        {
            selectedListItem.Selected = true;
        }
    }
  
    protected void ddlParntGrp_SelectedIndexChanged1(object sender, EventArgs e)
    {
        clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();
        clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccountGroup.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccountGroup.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //if (ddlParntGrp.SelectedItem.Value != "1")
        //{
            objEntityAccountGroup.AccountGrpId = Convert.ToInt32(ddlParntGrp.SelectedItem.Value);
        //evm 0044
            CreateGroupCodeByLevel();
            DataTable dtAccountById = objBusinessAcountGrp.ReadAccountGroupByID(objEntityAccountGroup);
            if (dtAccountById.Rows.Count > 0)
            {
                // ddlParntGrp.Items.FindByValue(dtAccountById.Rows[0]["ACNT_PARENT_GRP_ID"].ToString()).Selected = true;
                ddlNature.ClearSelection();

                int prmryVal = Convert.ToInt32(clsCommonLibrary.ACNT_GRP_ID.PRIMARY);
                if (ddlParntGrp.SelectedItem.Value != prmryVal.ToString())
                {
                    if (ddlNature.Items.FindByValue(dtAccountById.Rows[0]["ACNT_NATURE_STS"].ToString()) != null)
                    {
                        ddlNature.Items.FindByValue(dtAccountById.Rows[0]["ACNT_NATURE_STS"].ToString()).Selected = true;
                    }
                }
              //ddlNature.SelectedItem.Value = dtAccountById.Rows[0]["ACNT_NATURE_STS"].ToString();
                if (dtAccountById.Rows[0]["ACNT_NATURE_TYPE_STS"].ToString() != "")
                {
                    if (dtAccountById.Rows[0]["ACNT_NATURE_STS"].ToString() == "3")
                    {
                        DivNature.Attributes["style"] = "   background-color: rgb(246, 246, 246); border: 1px solid rgb(186, 186, 186); float: right;";
                        divGrossProfit.Attributes["style"] = "margin-left: 0%;";
                        divtype.Attributes["style"] = "float: right;float: left;marginTop = 0%;";
                     

                    }
                    else if (dtAccountById.Rows[0]["ACNT_NATURE_STS"].ToString() == "2")
                    {
                        DivNature.Attributes["style"] = "  background-color: rgb(246, 246, 246); border: 1px solid rgb(186, 186, 186); float: right; ";
                        divGrossProfit.Attributes["style"] = "margin-left: 0%;";
                        divtype.Attributes["style"] = "float: right;float: left;marginTop = 0%;";
                       
                    }

                    else
                    {

                        DivNature.Attributes["style"] = " background-color: rgb(246, 246, 246); border: 1px solid rgb(186, 186, 186); float: right; ";
                    }
                    radioDirect.Checked = false;
                    radioIndirect.Checked = false;
                    if (dtAccountById.Rows[0]["ACNT_NATURE_TYPE_STS"].ToString() == "0")
                    {
                        radioDirect.Checked = true;
                        HiddenDirctIndirect.Value = "0";
                    }
                    else if (dtAccountById.Rows[0]["ACNT_NATURE_TYPE_STS"].ToString() == "1")
                    {
                        radioIndirect.Checked = true;
                        HiddenDirctIndirect.Value = "1";
                    }
                }
                else
                {
                    DivNature.Attributes["style"] = " background-color: rgb(246, 246, 246); border: 1px solid rgb(186, 186, 186); float: right;";

                }
                if (ddlParntGrp.SelectedItem.Value != "1")
                {
                    ddlNature.Enabled = false;
                    radioDirect.Disabled = true;
                    radioIndirect.Disabled = true;
                }
                else
                {
                    ddlNature.Enabled = true;
                    radioDirect.Disabled = false;
                    radioIndirect.Disabled = false;
                    int acsts = Convert.ToInt32(dtAccountById.Rows[0]["ACNT_NATURE_STS"].ToString());
                    if (acsts == 3)
                    {
                        DivNature.Attributes["style"] = "  background-color: rgb(246, 246, 246); border: 1px solid rgb(186, 186, 186); float: right;";
                        divGrossProfit.Attributes["style"] = "margin-left: 0%;";
                        divtype.Attributes["style"] = "float: right;float: left;marginTop = 0%;";
                    }
                    else if (acsts == 2)
                    {
                        DivNature.Attributes["style"] = " background-color: rgb(246, 246, 246); border: 1px solid rgb(186, 186, 186); float: right;";
                        divGrossProfit.Attributes["style"] = "margin-left: 0%;";
                        divtype.Attributes["style"] = "float: right;float: left;marginTop = -3%;";
                    }
                    else
                    {
                        DivNature.Attributes["style"] = "  background-color: rgb(246, 246, 246); border: 1px solid rgb(186, 186, 186); float: right;";
                    }
                }
                
            }
            ddlParntGrp.Focus();
          
          // ScriptManager.RegisterStartupScript(this, GetType(), "AutoCompletePrntGrp", "AutoCompletePrntGrp();", true);
        //}

    }

    public void Update(string strId,string mode)
    {
        btnsave.Visible = false;
        btnsaveAndClose.Visible = false;
        ButtnClose.Visible = false;

        LoadAccountGroup();
        clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();
        clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();
        objEntityAccountGroup.AccountGrpId = Convert.ToInt32(strId);
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccountGroup.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccountGroup.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtService = objBusinessAcountGrp.ReadAccountGroupByID(objEntityAccountGroup);
        if (dtService.Rows.Count > 0)
        {
            ddlParntGrp.ClearSelection();
            txtAccountName.Text = dtService.Rows[0]["ACNT_GRP_NAME"].ToString().Trim();

            string itemValue = strId;
            if (ddlParntGrp.Items.FindByValue(itemValue) != null)
            {
                string itemText = ddlParntGrp.Items.FindByValue(itemValue).Text;
                ListItem li = new ListItem();
                li.Text = itemText;
                li.Value = itemValue;
                ddlParntGrp.Items.Remove(li);
            }


            if (ddlParntGrp.Items.FindByValue(dtService.Rows[0]["ACNT_PARENT_GRP_ID"].ToString()) != null)
            {
            ddlParntGrp.Items.FindByValue(dtService.Rows[0]["ACNT_PARENT_GRP_ID"].ToString()).Selected = true;
        }
            int intprntGrp = Convert.ToInt32(dtService.Rows[0]["ACNT_PARENT_GRP_ID"].ToString());
            string PredefinedValue = dtService.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString();
            int intAccId =0;
            if (strId != "")
            {
                intAccId = Convert.ToInt32(strId);
            }
            if (PredefinedValue  != "")
            {
                ChkStatus.Disabled = true;
                HiddenEditable.Value = PredefinedValue;
                txtAccountName.Enabled = false;
            }
            else
            {
                ChkStatus.Disabled = false;
            }
       
                ddlNature.ClearSelection();
                ddlNature.Items.FindByValue(dtService.Rows[0]["ACNT_NATURE_STS"].ToString()).Selected = true;
                if (dtService.Rows[0]["ACNT_NATURE_TYPE_STS"].ToString() != "")
                {
                    DivNature.Attributes["style"] = "background-color: #f6f6f6;border: 1px solid #bababa;";
                    if (dtService.Rows[0]["ACNT_NATURE_STS"].ToString() == "2" || dtService.Rows[0]["ACNT_NATURE_STS"].ToString() == "3")
                    {
                        divGrossProfit.Attributes["style"] = "margin-left: 0%;";
                        divtype.Attributes["style"] = "float: right;float: left;marginTop = 0%;";

                    }
                    else
                    {
                        DivNature.Attributes["style"] = " background-color: #f6f6f6;border: 1px solid #bababa;";
                        divGrossProfit.Attributes["style"] = "margin-left: 0%;";
                        divtype.Attributes["style"] = "float: right;float: left;marginTop = -3%;";

                    }
                    radioDirect.Checked = false;
                    radioIndirect.Checked = false;
                    if (dtService.Rows[0]["ACNT_NATURE_TYPE_STS"].ToString() == "0")
                    {
                        radioDirect.Checked = true;
                        HiddenDirctIndirect.Value = "0";
                    }
                    else if (dtService.Rows[0]["ACNT_NATURE_TYPE_STS"].ToString() == "1")
                    {
                        radioIndirect.Checked = true;
                        HiddenDirctIndirect.Value = "1";
                    }
                    radioDirect.Disabled = true;
                    radioIndirect.Disabled = true;


                    if (dtService.Rows[0]["ACNT_GRP_STS"].ToString() == "0")
                    {
                        ChkStatus.Checked = false;
                    }
                    else
                    {
                        ChkStatus.Checked = true;
                    }

                    if (dtService.Rows[0]["ACNT_AFFECT_GP"].ToString() == "0")
                    {
                        cbxGrossProfit.Checked = true;
                    }
                    else
                    {
                        cbxGrossProfit.Checked = false;
                    }

                    if (dtService.Rows[0]["ACNT_GRP_ADRES_STS"].ToString() == "0")
                    {
                        ChkAddressSts.Checked = false;
                    }
                    else
                    {
                        ChkAddressSts.Checked = true;
                    }

                    if (dtService.Rows[0]["ACNT_CODE"].ToString() != "")
                    {
                        txtGrpCode.Text = dtService.Rows[0]["ACNT_CODE"].ToString();
                    }
                }
                //if (!(intprntGrp >= 6 && intprntGrp <= 9))
                //{
                //    DivNature.Attributes["style"] = " padding-left: 6.6%;width: 40.5%;background-color: #f6f6f6;border: 1px solid #bababa;display:none;";

                //}

                //if (PredefinedValue != "")
                //{
                //    cbxGrossProfit.Disabled = true;
                //    radioDirect.Disabled = true;
                //    radioIndirect.Disabled = true;
                //    ChkAddressSts.Disabled = true;
                //}

            int CntChild=Convert.ToInt32(dtService.Rows[0]["CNT_CHILD"].ToString().Trim());
            if (CntChild > 0 )
            {
                ddlParntGrp.Enabled = false;
                ChkStatus.Disabled = true;
               
                txtGrpCode.Enabled = false;
               
            }
            if (PredefinedValue != "")
            {
                ddlParntGrp.Enabled = false;
                ddlNature.Enabled = false;
            }

            if (mode == "VIEW")
            {
                btnCancel.Visible = true;
                txtAccountName.Enabled = false;
                ddlParntGrp.Enabled = false;
                ddlNature.Enabled = false;
                cbxGrossProfit.Disabled = true;
                ChkStatus.Disabled = true;
                ChkAddressSts.Disabled = true;
                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
                ButtnClose.Visible = false;
                txtGrpCode.Enabled = false;
                radioDirect.Disabled = true;
                radioIndirect.Disabled = true;
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();
        clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityAccountGroup.AccountGrpId =Convert.ToInt32(strId);
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccountGroup.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccountGroup.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityAccountGroup.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityAccountGroup.AccountGrpName = txtAccountName.Text.Trim();
        objEntityAccountGroup.ParentAccountGrpId = Convert.ToInt32(ddlParntGrp.SelectedItem.Value);
        objEntityAccountGroup.NatureId = Convert.ToInt32(ddlNature.SelectedItem.Value);
        if (cbxGrossProfit.Checked)
        {
            objEntityAccountGroup.Affect_Gross_Profit = 0;
        }
        else
        {
            objEntityAccountGroup.Affect_Gross_Profit = 1;
        }
        if (HiddenDirctIndirect.Value == "0")
        {
            objEntityAccountGroup.NatureType = 0;
        }
        else if(HiddenDirctIndirect.Value == "1")
        {
            objEntityAccountGroup.NatureType = 1;
        }
        if (ChkStatus.Checked)
        {
            objEntityAccountGroup.GroupStatus = 1;
        }
        else
        {
            objEntityAccountGroup.GroupStatus = 0;
        }

        if (ChkAddressSts.Checked == true)
        {
            objEntityAccountGroup.AddressStatus = 1;
        }
        else
        {
            objEntityAccountGroup.AddressStatus = 0;
        }
        //evm 0044----------

        string strRandomMixedId1 = Request.QueryString["Id"].ToString();
        string strLenghtofId1 = strRandomMixedId1.Substring(0, 2);
        int intLenghtofId1 = Convert.ToInt16(strLenghtofId1);
        string strId1 = strRandomMixedId1.Substring(2, intLenghtofId1);
        objEntityAccountGroup.AccountGrpId  = Convert.ToInt32(strId1);
        int updatests = 0;
        DataTable dtService = objBusinessAcountGrp.ReadAccountGroupByID(objEntityAccountGroup);
        if (dtService.Rows.Count > 0)
        {
            int accgrpparentId = 0;
            if (dtService.Rows[0]["ACNT_PARENT_GRP_ID"].ToString() != "")
            {
                accgrpparentId = Convert.ToInt32(dtService.Rows[0]["ACNT_PARENT_GRP_ID"].ToString());
            }
            if (accgrpparentId != Convert.ToInt32(ddlParntGrp.SelectedItem.Value))
            {
                updatests = 1;
                CreateGroupCodeByLevel();
            }
          
        }
        //-----------
       
        objEntityAccountGroup.GrpCode = txtGrpCode.Text.Trim();
        if (HiddenCodeFormate.Value != "")
        {
            objEntityAccountGroup.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
        }
        DataTable dtIns = objBusinessAcountGrp.AccountGroupDplctnUpdChk(objEntityAccountGroup);
        DataTable dtCancel = objBusinessAcountGrp.AccountGroupCancelChk(objEntityAccountGroup);

        if (dtIns.Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsg();", true);
        }
        else if (dtCancel.Rows.Count > 0)
        {
            if (Convert.ToInt32(dtCancel.Rows[0][0].ToString()) > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyCancelMsg", "AlreadyCancelMsg();", true);
            }
        }
        else
        {
            string strCodeCount = objBusinessAcountGrp.CheckCodeDuplicatn(objEntityAccountGroup);

            if (strCodeCount == "0")
            {

                objBusinessAcountGrp.UpadteAccountGroup(objEntityAccountGroup);
                if (updatests ==1)
                {
                    objBusinessAcountGrp.UpdateAccountGroupNextGroup(objEntityAccountGroup);
                }
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("AccountGroup.aspx?InsUpd=Upd&Id=" + Request.QueryString["Id"]);
                }
                else if (clickedButton.ID == "btnUpdateAndClose")
                {
                    Response.Redirect("Account_Group_List.aspx?InsUpd=Upd");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCodeMsg", "DuplicationCodeMsg();", true);
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("AccountGroup.aspx");
    }

    protected void BtnList_Click(object sender, EventArgs e)
    {
        Response.Redirect("Account_Group_List.aspx");
    }


    [WebMethod]
    public static string CrateCodeFormate(string orgID, string corptID, string AcntGrpId)
    {

        string sts = "";
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        //evm 0044
        clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();
        clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();


        int intCorpId = 0;
        if (corptID != null)
        {

            intCorpId = Convert.ToInt32(corptID);
            objEntityCommon.CorporateID = Convert.ToInt32(corptID);
            objEntityAccountGroup.CorpId = Convert.ToInt32(corptID); 
        }

        if (orgID != null)
        {

            objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
            objEntityAccountGroup.OrgId = Convert.ToInt32(corptID);
        }

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ACCOUNT_GROUP_START_REF );
        //DataTable dtFormate = objBusinessLayer.ReadCodeFormate(objEntityCommon);
        //string refFormatByDiv = "";
        string strRealFormat = "";
        int acctgrpnextnum = 0;
        acctgrpnextnum = Convert.ToInt32(objBusinessLayer.ReadNextNumberOnly(objEntityCommon));
        if (acctgrpnextnum == 0)
        {
            objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.ACCOUNT_GROUP_START_REF); 
            DataTable dtDefaltModData = objBusinessLayer.ReadDefaultModValues(objEntityCommon);
            if (dtDefaltModData.Rows.Count > 0)
            {
                acctgrpnextnum = Convert.ToInt32(dtDefaltModData.Rows[0]["MOD_DFLT_VALUE"].ToString());
                strRealFormat  = Convert.ToString(acctgrpnextnum);

            }

        }
        else
        {
           objEntityAccountGroup.AccountGrpName  =AcntGrpId;
           objEntityAccountGroup.AccountGrpId = Convert.ToInt32(AcntGrpId);
            if (objEntityAccountGroup.AccountGrpName == "PRIMARY")
            {
              strRealFormat = Convert.ToString(acctgrpnextnum);
            }

            else
            {
                int subgrpnextnum = 0;
                DataTable dtactgroup = objBusinessAcountGrp.LoadAccountGroupBYId(objEntityAccountGroup);
                if (dtactgroup.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtactgroup.Rows[0]["ACNT_NEXTID_GROUP"].ToString()) == 0)
                    {
                        objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.ACCOUNT_SUB_GROUP_START_REF ); ; 
                        objEntityCommon.CorporateID = objEntityAccountGroup.CorpId;
                        objEntityCommon.Organisation_Id = objEntityAccountGroup.OrgId;
                        DataTable dtDefaltModData = objBusinessLayer.ReadDefaultModValues(objEntityCommon);
                        if (dtDefaltModData.Rows.Count > 0)
                        {
                            subgrpnextnum = Convert.ToInt32(dtDefaltModData.Rows[0]["MOD_DFLT_VALUE"].ToString());
                            strRealFormat = dtactgroup.Rows[0]["ACNT_CODE"].ToString() + Convert.ToString(subgrpnextnum);

                        }
                    }
                    else
                    {
                        subgrpnextnum = Convert.ToInt32(dtactgroup.Rows[0]["ACNT_NEXTID_GROUP"].ToString());
                        strRealFormat = dtactgroup.Rows[0]["ACNT_CODE"].ToString() + Convert.ToString(subgrpnextnum);

                    }
                }

            }

        }
        //if (dtFormate.Rows.Count > 0)
        //{
        //    if (NatureId != "")
        //    {

        //        int NaureCode = 0;
        //        string CodeFormate = "";
        //        int intNature = Convert.ToInt32(NatureId);

        //        if (intNature == 0)
        //        {
        //            NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Asset);
        //        }
        //        else if (intNature == 1)
        //        {
        //            NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Liability);
        //        }
        //        else if (intNature == 2)
        //        {
        //            NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Expense);
        //        }
        //        else if (intNature == 3)
        //        {
        //            NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Income);
        //        }



        //        CodeFormate = NaureCode.ToString();

        //        // CodeFormate = NaureCode.ToString() + dtNextNumber;
        //        if (dtFormate.Rows[0]["CODE_FORMATE"].ToString() != "")
        //        {
        //            refFormatByDiv = dtFormate.Rows[0]["CODE_FORMATE"].ToString();
        //            string strReferenceFormat = "";
        //            strReferenceFormat = refFormatByDiv;
        //            string[] arrReferenceSplit = strReferenceFormat.Split('*');
        //            int intArrayRowCount = arrReferenceSplit.Length;
        //            int Codecount = 0;
        //            strRealFormat = refFormatByDiv.ToString();
        //            if (strRealFormat.Contains("#NAT#"))
        //            {
        //                strRealFormat = strRealFormat.Replace("#NAT#", NaureCode.ToString());


        //            }
        //            if (strRealFormat.Contains("#NUM#"))
        //            {
        //                string dtNextNumber = objBusinessLayer.ReadNextSequence(objEntityCommon);


        //                strRealFormat = strRealFormat.Replace("#NUM#", dtNextNumber);


        //            }
        //            if (dtFormate.Rows[0]["CODE_COUNT"].ToString() != "")
        //            {
        //                Codecount = Convert.ToInt32(dtFormate.Rows[0]["CODE_COUNT"].ToString());
        //            }

        //            int k = strRealFormat.Length;
        //            if (k < Codecount)
        //            {
        //                int Difrnce = Codecount - k;
        //                k = k + Difrnce;
        //                //  hello.PadLeft(50, '#');
        //                strRealFormat = strRealFormat.PadLeft(k, '0');
        //            }


                    sts = strRealFormat;
        //        }
        //    }
        //}

        return sts.ToString();
    }
}