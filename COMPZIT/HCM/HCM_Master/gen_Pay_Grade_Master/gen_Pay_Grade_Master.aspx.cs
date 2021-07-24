using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit;
using System.Web.Services;
using EL_Compzit;
using BL_Compzit.HCM;
using EL_Compzit.HCM;
using System.Collections;
using System.Linq;


public partial class HCM_HCM_Master_gen_Pay_Grade_Master_gen_Pay_Grade_Master : System.Web.UI.Page
{
    clsBusiness_Pay_Grade_Master objBussnsPayGrd = new clsBusiness_Pay_Grade_Master();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtName.Attributes.Add("onkeypress", "return isTag(event)");
        txtName.Attributes.Add("onkeypress", "IncrmntConfrmCounter(event)");
        txtBasicpayFrm.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtBasicpayTo.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAmntRgeFrm.Attributes.Add("onchange", "IncrmntConfrmCounterSalryAllwnce()");
        txtAmntRgeTo.Attributes.Add("onchange", "IncrmntConfrmCounterSalryAllwnce()");
        txtAmntRedcnFrom.Attributes.Add("onchange", "IncrmntConfrmCounterSalryDedctn()");
        txtAmntRedcnTo.Attributes.Add("onchange", "IncrmntConfrmCounterSalryDedctn()");
        txtperctg.Attributes.Add("onchange", "IncrmntConfrmCounterSalryDedctn()");
        txtperctg.Attributes.Add("onchange", "IncrmntConfrmCounterSalryDedctn()");

        txtBasicpayFrm.Attributes.Add("onkeypress", "return isTag(event)");
        txtBasicpayTo.Attributes.Add("onkeypress", "return isTag(event)");
        txtAmntRgeFrm.Attributes.Add("onkeypress", "return isTag(event)");
        txtAmntRgeTo.Attributes.Add("onkeypress", "return isTag(event)");
        txtAmntRedcnFrom.Attributes.Add("onkeypress", "return isTag(event)");
        txtAmntRedcnTo.Attributes.Add("onkeypress", "return isTag(event)");

       // ddlcurrncy.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlcurrncy.Attributes.Add("onkeypress", "return DisableEnter(event)");
       // ddlAddtn.Attributes.Add("onchange", "IncrmntConfrmCounterSalryAllwnce()");
        ddlAddtn.Attributes.Add("onkeypress", "return DisableEnter(event)");
      //  ddldedctn.Attributes.Add("onchange", "IncrmntConfrmCounterSalryDedctn()");
        ddldedctn.Attributes.Add("onkeypress", "return DisableEnter(event)");
        
              radioTotlAmnt.Attributes.Add("onkeypress", "return isTag(event)");
              radioBascPay.Attributes.Add("onkeypress", "return isTag(event)");
              radAmnt.Attributes.Add("onkeypress", "return isTag(event)");
              radPercntge.Attributes.Add("onkeypress", "return isTag(event)");

              radAmntAllw.Attributes.Add("onkeypress", "return isTag(event)");
              RadioPercAllow.Attributes.Add("onkeypress", "return isTag(event)");
              radioBascPayAllow.Attributes.Add("onkeypress", "return isTag(event)");
           
                       
        if (!IsPostBack)
        {
            HiddenView.Value = "";
            txtName.Focus();
            CurrencyLoad();
            SalaryAddnLoad();
            SalaryDedctnLoad();
            //divAllnce.Visible = false;
          //  divdedcn.Visible = false;
            HiddenDedctnId.Value = "";
            HiddenEdtOrViw.Value = "";
            HiddnEnableCacel.Value = "0";
            // UpdateAddtn.Visible = false;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();
            int intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityPaygrd.User_Id = Convert.ToInt32(Session["USERID"]);
                HiddenUserId.Value = Session["USERID"].ToString();

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

                // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityPaygrd.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                HiddenOrgId.Value = Session["ORGID"].ToString();

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

         
            int intUsrRolMstrId, intEnableAdd = 0;
            //Allocating child roles
            hiddenRoleAdd.Value = "0";
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Pay_Grades);
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
                        hiddenRoleAdd.Value = intEnableAdd.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        //intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleUpdate.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        HiddnEnableCacel.Value = "1";

                    }

                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {

                    }
                   
                }
            }
            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {


            }
            else
            {

                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;
                 // btnPayupdt.Visible=false;
                 // btnPayupdtclose.Visible = false;
                     
            }

            // clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }

            // for adding comma
            clsEntityCommon objEntityCommon = new clsEntityCommon();
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
                HiddenEdtOrViw.Value = "1";
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId, intCorpId);
                lblEntry.Text = "Edit Pay Grade";

                if (hiddenRoleAdd.Value.ToString() != "")
                {

                    if (Convert.ToInt32(hiddenRoleAdd.Value.ToString()) != Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                       // btnUpdate.Visible = false;
                       // btnUpdateClose.Visible = false;
                          //btnPayupdt.Visible=false;
                          //btnPayupdtclose.Visible = false;
                      
                    }
                }


            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                HiddenEdtOrViw.Value = "1";
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                 HiddenView.Value = strId;
                View(strId, intCorpId);

                //img1.Disabled = true;
                lblEntry.Text = "View Pay Grade";



            }
            else
            {
                lblEntry.Text = "Add Pay Grade";

               // btnPayupdt.Visible=false;
              //  btnPayupdtclose.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

                ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);

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
                    else if (strInsUpd == "StsCh")
                    {
                        //  ScriptManager.RegisterStartupScript(this, GetType(), "SuccessChangeStatus", "SuccessChangeStatus();", true);
                    }

                }


            }

        }
    }

    public void CurrencyLoad()
    {
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityPaygrd.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPaygrd.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussnsPayGrd.ReadCurrency(objEntityPaygrd);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlcurrncy.DataSource = dtSubConrt;
            ddlcurrncy.DataTextField = "CRNCMST_NAME";
            ddlcurrncy.DataValueField = "CRNCMST_ID";
            ddlcurrncy.DataBind();

        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddlcurrncy.Items.Insert(0, "--SELECT CURRENCY--");

        // ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }



    public void SalaryAddnLoad()
    {
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityPaygrd.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPaygrd.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussnsPayGrd.ReadSalaryAddn(objEntityPaygrd);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlAddtn.DataSource = dtSubConrt;
            ddlAddtn.DataTextField = "PAYRL_NAME";
            ddlAddtn.DataValueField = "PAYRL_ID";
            ddlAddtn.DataBind();

        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddlAddtn.Items.Insert(0, "--SELECT SALARY ADDITION--");

        // ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }




    public void SalaryDedctnLoad()
    {
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityPaygrd.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPaygrd.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussnsPayGrd.ReadSalaryDedctn(objEntityPaygrd);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddldedctn.DataSource = dtSubConrt;
            ddldedctn.DataTextField = "PAYRL_NAME";
            ddldedctn.DataValueField = "PAYRL_ID";
            ddldedctn.DataBind();

        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddldedctn.Items.Insert(0, "--SELECT SALARY DEDUCTION--");

        // ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }


    protected void btnAdd_Addtn_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();
        int intUserId = 0, intUsrRolMstrId = 0, intEnableCancel = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPaygrd.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPaygrd.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        //Status checkbox checked
        if (CheckStatsAddtn.Checked == true)
        {
            objEntityPaygrd.PayGrdStatus = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPaygrd.PayGrdStatus = 0;
        }
        if (CheckRestrict.Checked == true)
        {
            objEntityPaygrd.RestrctLimit = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPaygrd.RestrctLimit = 0;
        }

        if (CheckRestrictPerc.Checked == true)
        {
            objEntityPaygrd.RestrctLimitPerc = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPaygrd.RestrctLimitPerc = 0;
        }

        if (HiddenAllownceId.Value != "")
        {
            objEntityPaygrd.AlownceId = 0;
                //Convert.ToInt32(HiddenAllownceId.Value);
        }
       
        objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(HiddenPayGrdeId.Value);
        if (ddlAddtn.SelectedItem.Value.ToString() != "--SELECT SALARY ADDITION--")
        {
            objEntityPaygrd.SalaryAllwnceId = Convert.ToInt32(ddlAddtn.SelectedItem.Value);
        }
        if (radAmntAllw.Checked == true)
        {
            objEntityPaygrd.PercOrAmountChk = 0;
            objEntityPaygrd.AmountRangeFrm = Convert.ToDecimal(txtAmntRgeFrm.Text.Trim());
            objEntityPaygrd.AmountRangeTo = Convert.ToDecimal(txtAmntRgeTo.Text.Trim());
        }
        else if (RadioPercAllow.Checked == true)
        {
            objEntityPaygrd.PercOrAmountChk = 1;
            objEntityPaygrd.Percentge = Convert.ToDecimal(txtperctgAllw.Text.Trim());
            objEntityPaygrd.PercentgeTo = Convert.ToDecimal(txtperctgAllwTo.Text.Trim());
        }



       
        string strdupAllownce = "";
        strdupAllownce = objBussnsPayGrd.DuplCheckSalaryAllownce(objEntityPaygrd);
        if (strdupAllownce == "" || strdupAllownce == "0")
        {
            objBussnsPayGrd.AddSalaryAddnAllownce(objEntityPaygrd);


           
        

            if (clickedButton.ID == "SaveAddtn")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationAllwnce", "SuccessConfirmationAllwnce();", true);
            }
            //else if (clickedButton.ID == "btnAddClose")
            //{
            //    //Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Ins");
            //}
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationSalaryAllwnce", "DuplicationSalaryAllwnce();", true);
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);

    }

    protected void btnAdd_Dedctn_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPaygrd.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPaygrd.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        //Status checkbox checked
        if (CheckstsDedctn.Checked == true)
        {
            objEntityPaygrd.PayGrdStatus = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPaygrd.PayGrdStatus = 0;
        }

        if (RestrctstsDedPerc.Checked == true)
        {
            objEntityPaygrd.RestrctLimitPerc = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPaygrd.RestrctLimitPerc = 0;
        }

        if (RestrctstsDed.Checked == true)
        {
            objEntityPaygrd.RestrctLimit = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPaygrd.RestrctLimit = 0;
        }
        if (HiddenDedctnId.Value != "")
        {
            objEntityPaygrd.DedctnId = 0;
                //Convert.ToInt32(HiddenDedctnId.Value);
        }
        objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(HiddenPayGrdeId.Value);
        if (ddldedctn.SelectedItem.Value.ToString() != "--SELECT SALARY DEDUCTION--")
        {
            objEntityPaygrd.SlaryDedctnId = Convert.ToInt32(ddldedctn.SelectedItem.Value);
        }
        if (radAmnt.Checked == true)
        {
            objEntityPaygrd.PercOrAmountChk = 0;
            objEntityPaygrd.AmountRangeFrm = Convert.ToDecimal(txtAmntRedcnFrom.Text.Trim());
            objEntityPaygrd.AmountRangeTo = Convert.ToDecimal(txtAmntRedcnTo.Text.Trim());
        }
        else if (radPercntge.Checked == true)
        {
            objEntityPaygrd.PercOrAmountChk = 1;
            objEntityPaygrd.Percentge = Convert.ToDecimal(txtperctg.Text.Trim());
            objEntityPaygrd.PercentgeTo = Convert.ToDecimal(txtperctgTo.Text.Trim());
        }
        if (radioBascPay.Checked == true)
        {
            objEntityPaygrd.BasicOrTotalAmtChk = 0;
        }
        else if (radioTotlAmnt.Checked == true)
        {
            objEntityPaygrd.BasicOrTotalAmtChk = 1;
        }
        string strdupAllownce = "";
        strdupAllownce = objBussnsPayGrd.DuplCheckSalaryDedctn(objEntityPaygrd);
        if (strdupAllownce == "" || strdupAllownce == "0")
        {
            objBussnsPayGrd.AddSalaryDedction(objEntityPaygrd);

  

      

            if (clickedButton.ID == "SaveDedctn")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationDedctn", "SuccessConfirmationDedctn();", true);
            }
            //else if (clickedButton.ID == "btnAddClose")
            //{
            //    //Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Ins");
            //}
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationSalaryDedctn", "DuplicationSalaryDedctn();", true);
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPaygrd.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPaygrd.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityPaygrd.PayGrdStatus = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPaygrd.PayGrdStatus = 0;
        }
        if (cbxRestrictPaygrd.Checked == true)
        {
            objEntityPaygrd.RestrctLimit = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPaygrd.RestrctLimit = 0;
        }

        if (ddlcurrncy.SelectedItem.Value.ToString() != "--SELECT CURRENCY--")
        {
            objEntityPaygrd.currcyId = Convert.ToInt32(ddlcurrncy.SelectedItem.Value);
        }
        objEntityPaygrd.AmountRangeFrm = Convert.ToDecimal(txtBasicpayFrm.Text.Trim());
        objEntityPaygrd.AmountRangeTo = Convert.ToDecimal(txtBasicpayTo.Text.Trim());
        objEntityPaygrd.PayGrdName = txtName.Text.Trim();
        //DataTable Currcydt= objBussnsPayGrd.CurncyAbbrv(objEntityPaygrd);
        //if (Currcydt.Rows.Count > 0)
        //{ 
        
        //}
      
        string strdupName = "";
        strdupName = objBussnsPayGrd.DuplCheckNamePayGrade(objEntityPaygrd);
        if (strdupName == "" || strdupName == "0")
        {
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PAY_GRADE);
            objEntityCommon.CorporateID = objEntityPaygrd.CorpOffice_Id;
            objEntityCommon.Organisation_Id = objEntityPaygrd.Organisation_Id;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(strNextId);
            HiddenPayGrdeId.Value = strNextId;
            objBussnsPayGrd.AddPayGrade(objEntityPaygrd);
            btnUpdate.Visible = true;
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnClear.Visible = false;
            // document.getElementById("<%=btnUpdate.ClientID%>").style.display = "block";
            //document.getElementById("<%=btnAdd.ClientID%>").style.display = "none";

     


            // HiddenBankGuarenteeId.Value = Convert.ToString(ObjEntityBnkGurnt.NextIdForRqst);
          
            if (clickedButton.ID == "btnAdd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationPayGrade", "SuccessConfirmationPayGrade();", true);

            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnPaySveClose")
            {
                //Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Ins");
                Response.Redirect("gen_Pay_Grade_Master_List.aspx?InsUpd=Ins");
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationPaygrdName", "DuplicationPaygrdName();", true);
        }
      //  ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

       // ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPaygrd.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPaygrd.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityPaygrd.PayGrdStatus = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPaygrd.PayGrdStatus = 0;
        }
        if (cbxRestrictPaygrd.Checked == true)
        {
            objEntityPaygrd.RestrctLimit = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPaygrd.RestrctLimit = 0;
        }
        int currId = 0;
        if (ddlcurrncy.SelectedItem.Value.ToString() != "--SELECT CURRENCY--")
        {
            objEntityPaygrd.currcyId = Convert.ToInt32(ddlcurrncy.SelectedItem.Value);
            currId = Convert.ToInt32(ddlcurrncy.SelectedItem.Value);
        }
        objEntityPaygrd.AmountRangeFrm = Convert.ToDecimal(txtBasicpayFrm.Text.Trim());
        objEntityPaygrd.AmountRangeTo = Convert.ToDecimal(txtBasicpayTo.Text.Trim());
        objEntityPaygrd.PayGrdName = txtName.Text.Trim();


        //objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PAY_GRADE);
        //objEntityCommon.CorporateID = objEntityPaygrd.CorpOffice_Id;
        //objEntityCommon.Organisation_Id = objEntityPaygrd.Organisation_Id;
        //string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(HiddenPayGrdeId.Value);
        string strdupName = "";
        strdupName = objBussnsPayGrd.DuplCheckNamePayGrade(objEntityPaygrd);
        if (strdupName == "" || strdupName == "0")
        {
            objBussnsPayGrd.UpdatePayGrade(objEntityPaygrd);




            // HiddenBankGuarenteeId.Value = Convert.ToString(ObjEntityBnkGurnt.NextIdForRqst);

          // ScriptManager.RegisterStartupScript(this, GetType(), "currcyabbrvLoad", "currcyabbrvLoad("+currId+");", true);
      
            if (clickedButton.ID == "btnUpdate" )
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePayGradePayGrade", "UpdatePayGradePayGrade();", true);
            }
            else if (clickedButton.ID == "btnUpdateClose" )
            {
                Response.Redirect("gen_Pay_Grade_Master_List.aspx?InsUpd=Upd");
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationPaygrdName", "DuplicationPaygrdName();", true);
        }

      //  ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

        //ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);
    }

   
    protected void btnUpdate_Addtn_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();
        int intUserId = 0, intUsrRolMstrId = 0, intEnableCancel = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPaygrd.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPaygrd.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(HiddenPayGrdeId.Value);
        if (HiddenAllownceId.Value != "")
        {
            objEntityPaygrd.AlownceId = Convert.ToInt32(HiddenAllownceId.Value);
               
        }
      
        //Status checkbox checked
        if (CheckStatsAddtn.Checked == true)
        {
            objEntityPaygrd.PayGrdStatus = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPaygrd.PayGrdStatus = 0;
        }
        if (CheckRestrict.Checked == true)
        {
            objEntityPaygrd.RestrctLimit = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPaygrd.RestrctLimit = 0;
        }

        if (CheckRestrictPerc.Checked == true)
        {
            objEntityPaygrd.RestrctLimitPerc = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPaygrd.RestrctLimitPerc = 0;
        }

        objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(HiddenPayGrdeId.Value);
      
        if (Hiddendddlallwce.Value != "")
        {
            objEntityPaygrd.SalaryAllwnceId = Convert.ToInt32(Hiddendddlallwce.Value);
        }

        if (radAmntAllw.Checked == true)
        {
            objEntityPaygrd.PercOrAmountChk = 0;
            objEntityPaygrd.AmountRangeFrm = Convert.ToDecimal(txtAmntRgeFrm.Text.Trim());
            objEntityPaygrd.AmountRangeTo = Convert.ToDecimal(txtAmntRgeTo.Text.Trim());
        }
        else if (RadioPercAllow.Checked == true)
        {
            objEntityPaygrd.PercOrAmountChk = 1;
            objEntityPaygrd.Percentge = Convert.ToDecimal(txtperctgAllw.Text.Trim());
            objEntityPaygrd.PercentgeTo = Convert.ToDecimal(txtperctgAllwTo.Text.Trim());
        }
        //objEntityPaygrd.AmountRangeFrm = Convert.ToDecimal(txtAmntRgeFrm.Text.Trim());
       // objEntityPaygrd.AmountRangeTo = Convert.ToDecimal(txtAmntRgeTo.Text.Trim());
        string strdupAllownce = "";
        strdupAllownce = objBussnsPayGrd.DuplCheckSalaryAllownce(objEntityPaygrd);
        if (strdupAllownce == "" || strdupAllownce == "0")
        {
            objBussnsPayGrd.UpdSalaryAddnAllownce(objEntityPaygrd);


        

      

            if (clickedButton.ID == "UpdateAddtn")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePayGradeAllwnce", "UpdatePayGradeAllwnce();", true);
            }
            //else if (clickedButton.ID == "btnAddClose")
            //{
            //    //Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Ins");
            //}
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationSalaryAllwnce", "DuplicationSalaryAllwnce();", true);
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);
    }

    protected void btnUpdate_Dedctn_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();
        int intUserId = 0, intUsrRolMstrId = 0, intEnableCancel = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPaygrd.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPaygrd.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(HiddenPayGrdeId.Value);

        if (HiddenDedctnId.Value != "")
        {
            objEntityPaygrd.DedctnId = Convert.ToInt32(HiddenDedctnId.Value);
        }
       
        //Status checkbox checked
        if (CheckstsDedctn.Checked == true)
        {
            objEntityPaygrd.PayGrdStatus = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPaygrd.PayGrdStatus = 0;
        }
        if (RestrctstsDed.Checked == true)
        {
            objEntityPaygrd.RestrctLimit = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPaygrd.RestrctLimit = 0;
        }

        if (RestrctstsDedPerc.Checked == true)
        {
            objEntityPaygrd.RestrctLimitPerc = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPaygrd.RestrctLimitPerc = 0;
        }

       // objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(HiddenPayGrdeId.Value);
        if (Hiddenddldedctn.Value != "")
        {
            objEntityPaygrd.SlaryDedctnId = Convert.ToInt32(Hiddenddldedctn.Value);
        }
        if (radAmnt.Checked == true)
        {
            objEntityPaygrd.PercOrAmountChk = 0;
            objEntityPaygrd.AmountRangeFrm = Convert.ToDecimal(txtAmntRedcnFrom.Text.Trim());
            objEntityPaygrd.AmountRangeTo = Convert.ToDecimal(txtAmntRedcnTo.Text.Trim());
        }
        else if (radPercntge.Checked == true)
        {
            objEntityPaygrd.PercOrAmountChk = 1;
            objEntityPaygrd.Percentge = Convert.ToDecimal(txtperctg.Text.Trim());
            objEntityPaygrd.PercentgeTo = Convert.ToDecimal(txtperctgTo.Text.Trim());

        }
        if (radioBascPay.Checked == true)
        {
            objEntityPaygrd.BasicOrTotalAmtChk = 0;
        }
        else if (radioTotlAmnt.Checked == true)
        {
            objEntityPaygrd.BasicOrTotalAmtChk = 1;
        }
        string strdupAllownce = "";
        strdupAllownce = objBussnsPayGrd.DuplCheckSalaryDedctn(objEntityPaygrd);
        if (strdupAllownce == "" || strdupAllownce == "0")
        {
            objBussnsPayGrd.UpdateSalaryDedction(objEntityPaygrd);





            if (clickedButton.ID == "UpdateDedctn")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePayGradeDedctn", "UpdatePayGradeDedctn();", true);
            }
            //else if (clickedButton.ID == "btnAddClose")
            //{
            //    //Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Ins");
            //}
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationSalaryDedctn", "DuplicationSalaryDedctnUpdate();", true);
        }
      //  ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

      //  ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);
    }
    //to view
    public void View(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;

        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityPaygrd.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(strP_Id);
        HiddenPayGrdeId.Value = Convert.ToString(strP_Id);
        objEntityPaygrd.CorpOffice_Id = intCorpId;
        DataTable dtRqstFrGrnt = objBussnsPayGrd.ReadPayGradeById(objEntityPaygrd);
        if (dtRqstFrGrnt.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate
            txtName.Text = dtRqstFrGrnt.Rows[0]["PYGRD_NAME"].ToString();
            txtBasicpayFrm.Text = dtRqstFrGrnt.Rows[0]["AMOUNTFRM"].ToString();
            txtBasicpayTo.Text = dtRqstFrGrnt.Rows[0]["AMOUNTTO"].ToString();
            HiddenBasicForPer.Value = dtRqstFrGrnt.Rows[0]["AMOUNTFRM"].ToString() + "-" + dtRqstFrGrnt.Rows[0]["AMOUNTTO"].ToString();
            HiddenAmountRnge.Value = dtRqstFrGrnt.Rows[0]["AMOUNTFRM"].ToString() + "-" + dtRqstFrGrnt.Rows[0]["AMOUNTTO"].ToString() + " " + dtRqstFrGrnt.Rows[0]["CRNCMST_ABBRV"].ToString();
            HiddenSalaryAbbrv.Value = dtRqstFrGrnt.Rows[0]["CRNCMST_ABBRV"].ToString();

            if (dtRqstFrGrnt.Rows[0]["CRNCMST_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["CRNCMST_CNCL_USR_ID"].ToString() == "")
            {
                ddlcurrncy.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["CRNCMST_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString());
                ddlcurrncy.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlcurrncy);

                ddlcurrncy.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }




            int intPayStatus = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["PYGRD_STATUS"]);
            if (intPayStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            int intPayRestrctStatus = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["PYGRD_RANGE_RESTRICT_STS"]);
            if (intPayRestrctStatus == 1)
            {
                cbxRestrictPaygrd.Checked = true;
            }
            else
            {
                cbxRestrictPaygrd.Checked = false;
            }



            txtName.Enabled = false;
            txtBasicpayFrm.Enabled = false;
            txtBasicpayTo.Enabled = false;
            ddlcurrncy.Enabled = false;
            cbxStatus.Enabled = false;
            cbxRestrictPaygrd.Enabled = false;
            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;
            ddlAddtn.Enabled = false;
            txtAmntRgeFrm.Enabled = false;
            txtAmntRgeTo.Enabled = false;
            CheckStatsAddtn.Enabled = false;
            CheckRestrict.Enabled = false;
            UpdateAddtn.Visible = false;
            SaveAddtn.Visible = false;
           // ClearAddtn.Visible = false;
            ddldedctn.Enabled = false;
            radAmnt.Disabled = true;
            radPercntge.Disabled = true;
            txtAmntRedcnFrom.Enabled = false;
            txtAmntRedcnTo.Enabled = false;
            txtperctg.Enabled = false;
            radioBascPay.Disabled = true;
            radioTotlAmnt.Disabled = true;
            UpdateDedctn.Visible = false;
            SaveDedctn.Visible = false;
           // ClearDedctn.Visible = false;
            ClearAddtn.Visible = false;
            CheckstsDedctn.Enabled = false;
            RestrctstsDed.Enabled = false;
            divded.Visible = false;
            divallw.Visible = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

            ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);

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
    public void Update(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
     //   divAllnce.Visible = true;
       // divdedcn.Visible = true;

      //  btnPayupdt.Visible=true;
                       // btnPayupdtclose.Visible=true;
                        //btnPaySave.Visible=false;
                       // btnPaySveClose.Visible = false;
        HiddenPayGrdeId.Value = Convert.ToString(strP_Id);
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        int intUserId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityPaygrd.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPaygrd.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["SalarySummary"] != null)
        {
           // HiddenAmountRnge.Value = Session["SalarySummary"].ToString();

        }
        objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(strP_Id);
        objEntityPaygrd.CorpOffice_Id = intCorpId;
        DataTable dtRqstFrGrnt = objBussnsPayGrd.ReadPayGradeById(objEntityPaygrd);
        if (dtRqstFrGrnt.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate
            txtName.Text = dtRqstFrGrnt.Rows[0]["PYGRD_NAME"].ToString();
            txtBasicpayFrm.Text = dtRqstFrGrnt.Rows[0]["AMOUNTFRM"].ToString();
            txtBasicpayTo.Text = dtRqstFrGrnt.Rows[0]["AMOUNTTO"].ToString();
            string numfrom = objBusiness.AddCommasForNumberSeperation(dtRqstFrGrnt.Rows[0]["AMOUNTFRM"].ToString(), objEntityCommon);
            string numto = objBusiness.AddCommasForNumberSeperation(dtRqstFrGrnt.Rows[0]["AMOUNTTO"].ToString(), objEntityCommon);
            HiddenBasicForPer.Value = dtRqstFrGrnt.Rows[0]["AMOUNTFRM"].ToString() + "-" + dtRqstFrGrnt.Rows[0]["AMOUNTTO"].ToString();
            HiddenAmountRnge.Value = numfrom + "-" + numto + " " + dtRqstFrGrnt.Rows[0]["CRNCMST_ABBRV"].ToString();
            HiddenSalaryAbbrv.Value = dtRqstFrGrnt.Rows[0]["CRNCMST_ABBRV"].ToString();
            if (dtRqstFrGrnt.Rows[0]["CRNCMST_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["CRNCMST_CNCL_USR_ID"].ToString() == "")
            {
                ddlcurrncy.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["CRNCMST_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString());
                ddlcurrncy.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlcurrncy);

                ddlcurrncy.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }




            int intPayStatus = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["PYGRD_STATUS"]);
            if (intPayStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            int intPayRestrctStatus = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["PYGRD_RANGE_RESTRICT_STS"]);
            if (intPayRestrctStatus == 1)
            {
                cbxRestrictPaygrd.Checked = true;
            }
            else
            {
                cbxRestrictPaygrd.Checked = false;
            }

            DataTable dtOvertime = objBussnsPayGrd.ReadOvertimeById(objEntityPaygrd);
            if (dtOvertime.Rows.Count>0)
            OvertimeCat(dtOvertime);
            ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);
            
            ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);

         // int  AllwceOrDed = 1;
      

        }
    }
    public void OvertimeCat(DataTable dtOvertime)
    {
        StringBuilder sb = new StringBuilder();
     
        string strHtml = "";

        strHtml = "<div  style=\"float:left;width:95%;border: 2px solid rgb(207, 204, 204);margin-left: 1.3%;padding: 1%;overflow: auto;max-height: 150px;\">";
        strHtml += "<table id=\"tableOvertime\"  cellspacing=\"0\" cellpadding=\"2px\"  style=\"width:50%;padding:1%\">";
      strHtml += "<tbody>";
      foreach (DataRow overtm in dtOvertime.Rows)
      {
          strHtml += "<tr >";
          strHtml += "<td  style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
          strHtml += "<h2 style=\"float:left;margin-left:5.5%;font-size: 18px\">" + overtm["OVRTMCATG_NAME"].ToString() + "</h2></td>";
          strHtml += "<td  style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
          strHtml += "<input disabled   type=\"text\" value=\"" + overtm["OVRTMCATG_RATE"].ToString() + "\"   maxlength=85 style=\"float:left;margin-left:14%\"/><h2 style=\"float:left;margin-left:5.5%;font-size: 18px\">Per Hour</h2></td></tr>";
      }
      strHtml += "</tbody></table></div>";
       sb.Append(strHtml);
       divovertime.InnerHtml= sb.ToString();
    }

    protected void btnRsnSave_Click(object sender, EventArgs e)
    {

        //Creating objects for business layer
        clsBusiness_Pay_Grade_Master objBussnsPayGrd = new clsBusiness_Pay_Grade_Master();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityPaygrd.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityPaygrd.D_Date = System.DateTime.Now;

            objEntityPaygrd.Cancel_reason = txtCnclReason.Text.Trim();
            if (HiddenDelChk.Value == "0")
            {
                objBussnsPayGrd.CancelAllownce(objEntityPaygrd);
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelationAllwnce", "SuccessCancelationAllwnce();", true);
            }
            if (HiddenDelChk.Value == "1")
            {
                objBussnsPayGrd.CancelDedctn(objEntityPaygrd);
                txtCnclReason.Text = "";
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelationDedctn", "SuccessCancelationDedctn();", true);
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

            ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);
                    


        }
    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableCancel)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);


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
            }

        }
        strHtml += "<th class=\"thT\" style=\"width:4%;text-align: left; word-wrap:break-word;\">SL#</th>";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:24%;text-align: left; word-wrap:break-word;\">ADDITION</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: left; word-wrap:break-word;\">AMOUNT RANGE</th>";
            }



        }
        if (intReCallForTAble == 0)
        {
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">STATUS</th>";
        }


        //if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        //{
        if (intReCallForTAble == 0)
        {

            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
        }
        else
        {
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
        }
        // }
        if (intReCallForTAble == 0)
        {
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">CANCEL</th>";
            }
        }
        //if (intReCallForTAble == 1)
        //{
        //    if (intEnableRecall == 1)
        //    {
        //        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">RE-CALL</th>";
        //    }
        //}




        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        string amountFrm = "", amountTo = "";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strStatusMode = "";
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";
            strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + intRowBodyCount.ToString() + "</td>";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    //strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                    string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                    amountFrm = strNetAmountWithComma;
                }

                else if (intColumnBodyCount == 3)
                {
                    string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                    string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                    amountTo = strNetAmountWithComma;
                    strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + amountFrm + "-" + amountTo + "</td>";
                }
                //else if (intColumnBodyCount == 4)
                //{

                //    string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                //    string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                //    strHtml += "<td class=\"tdT\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma.ToString() + "</td>";
                //}


            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            strStatusMode = dt.Rows[intRowBodyCount][4].ToString();


            //if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            //{
            if (intCnclUsrId == 0)
            {
                if (strStatusMode == "ACTIVE")
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Inactive\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "');\" >" +
                        "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Active\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "');\" >" +
                      "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                }
            }
            //}


            //if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            //{
            if (intCnclUsrId == 0)
            {


                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                      " href=\"gen_Pay_Grade_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";




            }

            else
            {
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                 " href=\"gen_Pay_Grade_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


            }
            //}
            if (intReCallForTAble == 0)
            {
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (intCnclUsrId == 0)
                    {
                        if (intCancTransaction == 0)
                        {
                            //if (HiddenSearchField.Value == "")
                            //{
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelAlert(this.href);' " +
                             " href=\"gen_Pay_Grade_Master_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            //}
                            //else
                            //{
                            //    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelAlert(this.href);' " +
                            //   " href=\"gen_Pay_Grade_Master_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            //}
                        }
                        else
                        {

                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelNotPossible();' >"
                                    + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                        }



                    }
                    else
                    {

                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                    }
                }
            }










            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    public class ConvrtDataTable
    {
        public int PaygrdId = 0;
        public int AllowceId = 0;
        public int DedctnId = 0;
        public decimal FrmAmount = 0;
        public decimal Toamount = 0;
        public int ddlselectedVal = 0;
        public int sts = 0;
        public int RestrctSts = 0;
        public int RestrctStsPerc = 0;
        public decimal Perctgeamn;
        public string strPerctgeamn = "";
        public string strPerctgeamnTo = "";
        public int PerOrAmntck = 0;
        public int BasicOrTotl = 0;
        public string strhtml = "";
        public string strSummry = "";
        public int ddlBinding = 0;
        public string ddltext = "";
          public string strPerFromTotal="";
          public string strPerFromBasic="";
          public string strPerFromBasicAllw = "";

          public string SalaryPerctTotalAllow(DataTable dt, string AllwOrDed)
          {
              string strStatusMode = ""; decimal perctotalFromTotal = 0, perctotalFromBasic = 0;
              for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
              {
                  strStatusMode = dt.Rows[intRowBodyCount][4].ToString();

                  if (AllwOrDed == "0")
                  {
                      int PerORAmntchk = 0, TotalAmountBsic = 1;
                      PerORAmntchk = Convert.ToInt32(dt.Rows[intRowBodyCount]["PGALLCE_AMNT_PERCTGE_CHCK"].ToString());
                    //  TotalAmountBsic = Convert.ToInt32(dt.Rows[intRowBodyCount]["PGDEDTN_BASIC_OR_TOTAL_AMNT"].ToString());

                      for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                      {

                          if (PerORAmntchk == 1)
                          {
                              if (intColumnBodyCount == 3)
                              {
                                  if (strStatusMode == "ACTIVE")
                                  {
                                      // count++;
                                      //if (TotalAmountBsic == 1)
                                          //perctotalFromTotal = perctotalFromTotal + Convert.ToDecimal(dt.Rows[intRowBodyCount]["PERC"].ToString());
                                     // else if (TotalAmountBsic == 0)
                                          perctotalFromBasic = perctotalFromBasic + Convert.ToDecimal(dt.Rows[intRowBodyCount]["PERC"].ToString());
                                  }

                              }
                          }

                          //else if (intColumnBodyCount == 3)
                          //{
                          //    if (PerORAmntchk == 0)
                          //    {

                          //        totalAmntTo = totalAmntTo + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());

                          //    }
                          //}



                      }
                  }
              }
              string strPerTotal =  perctotalFromBasic.ToString();

              return strPerTotal;
          }
          public string SalaryPerctTotal(DataTable dt, string AllwOrDed)
          {
              string strStatusMode = ""; decimal perctotalFromTotal = 0, perctotalFromBasic = 0;
              for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
              {
                  strStatusMode = dt.Rows[intRowBodyCount][4].ToString();

                  if (AllwOrDed == "1")
                  {
                      int PerORAmntchk = 0, TotalAmountBsic = 1;
                      PerORAmntchk = Convert.ToInt32(dt.Rows[intRowBodyCount]["PGDEDTN_AMNT_PERCTGE_CHCK"].ToString());
                      TotalAmountBsic = Convert.ToInt32(dt.Rows[intRowBodyCount]["PGDEDTN_BASIC_OR_TOTAL_AMNT"].ToString());

                      for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                      {

                          if (PerORAmntchk == 1)
                          {
                              if (intColumnBodyCount == 3)
                              {
                                  if (strStatusMode == "ACTIVE")
                                  {
                                      // count++;
                                      if (TotalAmountBsic == 1)
                                          perctotalFromTotal = perctotalFromTotal + Convert.ToDecimal(dt.Rows[intRowBodyCount]["PERC"].ToString());
                                      else if (TotalAmountBsic == 0)
                                          perctotalFromBasic = perctotalFromBasic + Convert.ToDecimal(dt.Rows[intRowBodyCount]["PERC"].ToString());
                                  }

                              }
                          }

                          //else if (intColumnBodyCount == 3)
                          //{
                          //    if (PerORAmntchk == 0)
                          //    {

                          //        totalAmntTo = totalAmntTo + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());

                          //    }
                          //}



                      }
                  }
              }
              string strPerTotal = perctotalFromTotal.ToString() + "-" + perctotalFromBasic.ToString();

              return strPerTotal;
          }
       
        //It build the Html table by using the datatable provided
        public string SalarySummary(DataTable dt, string AllwOrDed, string CurrcyId)
        {

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(CurrcyId);


            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            Decimal totalAmntFrm = 0, totalAmntTo = 0;
            int count = 0; string strStatusMode = ""; 
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strStatusMode = dt.Rows[intRowBodyCount][4].ToString();
                if (AllwOrDed == "0")
                {

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                       
                            if (intColumnBodyCount == 2)
                            {
                                if (strStatusMode == "ACTIVE")
                                {
                                    count++;

                                    string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                                    totalAmntFrm = totalAmntFrm + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                                }

                            }

                            else if (intColumnBodyCount == 3)
                            {
                                if (strStatusMode == "ACTIVE")
                                {
                                    totalAmntTo = totalAmntTo + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                                }

                            }

                        

                    }
                }
                else if (AllwOrDed == "1")
                {
                    int PerORAmntchk = 0;
                    PerORAmntchk = Convert.ToInt32(dt.Rows[intRowBodyCount]["PGDEDTN_AMNT_PERCTGE_CHCK"].ToString());

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {

                        if (PerORAmntchk != 1)
                        {
                            if (intColumnBodyCount == 2)
                            {
                                if (strStatusMode == "ACTIVE")
                                {
                                    count++;

                                    totalAmntFrm = totalAmntFrm + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                                }

                            }

                            else if (intColumnBodyCount == 3)
                            {
                                if (PerORAmntchk == 0)
                                {
                                    if (strStatusMode == "ACTIVE")
                                    {
                                        totalAmntTo = totalAmntTo + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                                    }

                                }
                            }

                        }

                    }
                }
            }
            string NetAmountWithCommaTo = "0";
            string stramntSummary = "0";
            if (totalAmntTo != 0)
            {
                //totalAmntTo = totalAmntTo / count;
                //totalAmntFrm = totalAmntFrm / count;
                string NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(totalAmntFrm.ToString(), objEntityCommon);
                NetAmountWithCommaTo = objBusiness.AddCommasForNumberSeperation(totalAmntTo.ToString(), objEntityCommon);
           stramntSummary = NetAmountWithCommaFrm + " - " + NetAmountWithCommaTo;
            }
          
            return stramntSummary;
        }

        public string ConvertDataTableToHTML(DataTable dt, int intEnableCancel, string CurrcyId, string AllwOrDed, string RoleUpdate, string View)
        {
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(CurrcyId);


            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "";
            if (AllwOrDed == "0")
            {
                strHtml = "<table id=\"ReportTableAllw\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            }
            if (AllwOrDed == "1")
            {
                strHtml = "<table id=\"ReportTableDed\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            }

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
                }

            }
           // strHtml += "<th class=\"thT\" style=\"width:4%;text-align: left; word-wrap:break-word;\">SL#</th>";
            if (AllwOrDed == "0")
            {
                for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
                {

                    if (intColumnHeaderCount == 1)
                    {
                        strHtml += "<th class=\"thT\" style=\"width:24%;text-align: left; word-wrap:break-word;\">ADDITION</th>";
                    }

                    else if (intColumnHeaderCount == 2)
                    {
                        strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: right; word-wrap:break-word;\">PERCENTAGE/AMOUNT RANGE</th>";
                    }



                }
            }
            else if (AllwOrDed=="1")
            {

                for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
                {

                    if (intColumnHeaderCount == 1)
                    {
                        strHtml += "<th class=\"thT\" style=\"width:24%;text-align: left; word-wrap:break-word;\">DEDUCTION</th>";
                    }

                    else if (intColumnHeaderCount == 2)
                    {
                        strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: right; word-wrap:break-word;\">PERCENTAGE/AMOUNT RANGE</th>";
                    }



                }
            }
            if (intReCallForTAble == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">STATUS</th>";
            }


            //if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            //{
            if (intReCallForTAble == 0)
            {

                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            }
            else
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
            }
            // }
            if (intReCallForTAble == 0)
            {
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">CANCEL</th>";
                }
            }



            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows

            strHtml += "<tbody>";
            string amountFrm = "", amountTo = "";
            float totalAmntFrm = 0, totalAmntTo = 0;
            int count = 1;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string strStatusMode = "";
                int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
                int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

                strHtml += "<tr  >";
               // strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count.ToString() + "</td>";
                count++;
                if (AllwOrDed == "0")
                {
                    int PerORAmntchk = 0;
                    PerORAmntchk = Convert.ToInt32(dt.Rows[intRowBodyCount]["PGALLCE_AMNT_PERCTGE_CHCK"].ToString());
                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                        //if (j == 0)
                        //{
                        //    int intCnt = i + 1;
                        //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                        //}

                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 2)
                        {
                            
                            //strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                         
                            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                            amountFrm = strNetAmountWithComma;
                        }

                        else if (intColumnBodyCount == 3)
                        {
                            if (PerORAmntchk == 0)
                            {
                                string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                                amountTo = strNetAmountWithComma;
                                strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + amountFrm + "-" + amountTo + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                            }
                        }
                        else if (intColumnBodyCount == 9)
                        {
                            if (PerORAmntchk == 1)
                            {
                                string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

                                string strNetAmountTo = dt.Rows[intRowBodyCount]["PERC_TO"].ToString();
                                string strNetAmountWithCommaTo = objBusiness.AddCommasForNumberSeperation(strNetAmountTo, objEntityCommon);

                                strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma.ToString()  + "%  -  "  + strNetAmountWithCommaTo.ToString()  + "%" + "</td>";
                            }
                        }


                    }
                }
                else if (AllwOrDed == "1")
                {
                    int PerORAmntchk = 0;
                    PerORAmntchk = Convert.ToInt32(dt.Rows[intRowBodyCount]["PGDEDTN_AMNT_PERCTGE_CHCK"].ToString());

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                        //if (j == 0)
                        //{
                        //    int intCnt = i + 1;
                        //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                        //}
                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 2)
                        {
                           
                            //strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                          
                            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                            amountFrm = strNetAmountWithComma;
                        }

                        else if (intColumnBodyCount == 3)
                        {
                            if (PerORAmntchk == 0)
                            {
                                string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                               
                                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                                amountTo = strNetAmountWithComma;
                                strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + amountFrm + "-" + amountTo +" " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString()+ "</td>";
                            }
                        }
                        else if (intColumnBodyCount == 5)
                        {
                            if (PerORAmntchk == 1)
                            {
                                string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

                                string strNetAmountTo = dt.Rows[intRowBodyCount]["PERC_TO"].ToString();
                                string strNetAmountWithCommaTo = objBusiness.AddCommasForNumberSeperation(strNetAmountTo, objEntityCommon);

                                strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma.ToString()  + "%  -  " + strNetAmountWithCommaTo.ToString()  + "%" + "</td>";
                            }
                        }


                    }
                }

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                strStatusMode = dt.Rows[intRowBodyCount][4].ToString();


                //if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                //{
                if (intCnclUsrId == 0)
                {
                    if (RoleUpdate == "1")
                    {
                        if (View == "")
                        {
                            if (strStatusMode == "ACTIVE")
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Inactive\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "','" + AllwOrDed + "');\" >" +
                                    "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Active\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "','" + AllwOrDed + "');\" >" +
                                  "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                            }
                        }
                        else
                        { 
                        if (strStatusMode == "ACTIVE")
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Active\" >" +
                                "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Inactive\" >" +
                              "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                        }
                        }
                    }
                    else
                    {
                        if (strStatusMode == "ACTIVE")
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Active\" >" +
                                "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Inactive\" >" +
                              "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                        }
                    }
                    
                   
                }
                //}


                //if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                if (AllwOrDed == "0")
                {
                    //{
                    if (intCnclUsrId == 0)
                    {
                        if (RoleUpdate == "1")
                        {
                            if (View == "")
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick=\"return getdetailsAllwceById('" + strId + "');\" >" +
                                     "<img  style=\"cursor:pointer\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                            }
                            else 
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\"  style=\"opacity: .5;\" title=\"Edit\"  >" +
                                     "<img  style=\"cursor:pointer\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                            }

                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\"  style=\"opacity: .5;\" title=\"Edit\"  >" +
                                   "<img  style=\"cursor:pointer\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                        }


                    }

                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\"  style=\"opacity: .5;\" title=\"Edit\"  >" +
                                   "<img  style=\"cursor:pointer\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


                    }
                }
                else if (AllwOrDed == "1")
                {

                    if (intCnclUsrId == 0)
                    {
                        if (RoleUpdate == "1")
                        {
                            if (View == "")
                            {

                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick=\"return getdetailsDedctnById('" + strId + "');\" >" +
                                     "<img  style=\"cursor:pointer\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\"  style=\"opacity: .5;\" title=\"Edit\"  >" +
                                      "<img  style=\"cursor:pointer\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                            }

                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\"  style=\"opacity: .5;\" title=\"Edit\"  >" +
                                   "<img  style=\"cursor:pointer\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                        }


                    }

                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\"  style=\"opacity: .5;\" title=\"Edit\"  >" +
                                   "<img  style=\"cursor:pointer\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


                    }
                }
                //}
                if (intReCallForTAble == 0)
                {
                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (intCnclUsrId == 0)
                        {
                            if (intCancTransaction == 0)
                            {
                                //if (HiddenSearchField.Value == "")
                                //{
                                if (View == "")
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick=\"return CancelAlertAllwceById('" + strId + "','" + AllwOrDed + "');\" >" +
                                      "<img  style=\"cursor:pointer\" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\"  >"
                                          + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                }
                                //}
                                //elseCancelAlert
                                //{
                                //    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelAlert(this.href);' " +
                                //   " href=\"gen_Pay_Grade_Master_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                //}
                            }
                            else
                            {

                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelNotPossible();' >"
                                        + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                            }



                        }
                        else
                        {

                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                        }
                    }
                }



                strHtml += "</tr>";
            }
          
           // HiddenAmountRnge.Value = amountTo;
          
            strHtml += "</tbody>";

            strHtml += "</table>";



            sb.Append(strHtml);
            return sb.ToString();
        }
    }
    [WebMethod]
    public static string ChangeContractStatus(int strCatId, string strStatus, string AllwOrDed)
    {

        clsBusiness_Pay_Grade_Master objBussnsPayGrd = new clsBusiness_Pay_Grade_Master();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();

        string strRet = "success";

        if (strStatus == "ACTIVE")
        {
            objEntityPaygrd.PayGrdStatus = 0;
        }
        else
        {
            objEntityPaygrd.PayGrdStatus = 1;
        }
        objEntityPaygrd.NextIdForPayGrade = strCatId;
        try
        {
            if (AllwOrDed == "0")
            {
                objBussnsPayGrd.ChangeAllowStatus(objEntityPaygrd);
            }
            if (AllwOrDed == "1")
            {
                objBussnsPayGrd.ChangeDedctnStatus(objEntityPaygrd);
            }
        }
        catch
        {
            strRet = "failed";
        }

        return strRet;
    }
    [WebMethod]
    public static ConvrtDataTable LoadListPageallwnce(string EnableCanl, string CurrcyId, string CorpId, string OrgId, string PaygrdId, string RoleUpdate, string View)
    {
        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();
        clsBusiness_Pay_Grade_Master objBussnsPayGrd = new clsBusiness_Pay_Grade_Master();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();
        DataTable dtContract = new DataTable();
        objEntityPaygrd.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(CorpId);
        string AllwOrDed = "0";
        if (PaygrdId != "")
            objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(PaygrdId);
        else
            objEntityPaygrd.NextIdForPayGrade = 0;
            dtContract = objBussnsPayGrd.ReadAllounceList(objEntityPaygrd);
            string totalper = objConvrtDataTable.SalaryPerctTotalAllow(dtContract, AllwOrDed);

            objConvrtDataTable.strPerFromBasicAllw = totalper;
        string htrm = "";
        int EnableCancel = Convert.ToInt32(EnableCanl);
        objConvrtDataTable.strhtml = objConvrtDataTable.ConvertDataTableToHTML(dtContract, EnableCancel, CurrcyId, AllwOrDed, RoleUpdate, View);
        objConvrtDataTable.strSummry = objConvrtDataTable.SalarySummary(dtContract, AllwOrDed, CurrcyId);
        return objConvrtDataTable;
    }
      [WebMethod]
    public static ConvrtDataTable LoadListPageDed(string EnableCanl, string CurrcyId, string CorpId, string OrgId, string PaygrdId, string RoleUpdate,string View)
    {
        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();
        clsBusiness_Pay_Grade_Master objBussnsPayGrd = new clsBusiness_Pay_Grade_Master();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();
        DataTable dtContract = new DataTable();
        objEntityPaygrd.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(CorpId);
        string AllwOrDed = "1";
        if (PaygrdId != "")
            objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(PaygrdId);
        else
            objEntityPaygrd.NextIdForPayGrade = 0;
            dtContract = objBussnsPayGrd.ReadDedctnList(objEntityPaygrd);
        
        string htrm = "";
        int EnableCancel = Convert.ToInt32(EnableCanl);
        objConvrtDataTable.strhtml = objConvrtDataTable.ConvertDataTableToHTML(dtContract, EnableCancel, CurrcyId, AllwOrDed, RoleUpdate, View);
        objConvrtDataTable.strSummry = objConvrtDataTable.SalarySummary(dtContract, AllwOrDed, CurrcyId);

        string totalper = objConvrtDataTable.SalaryPerctTotal(dtContract, AllwOrDed);
        string[] strtotalper = totalper.Split('-');
        objConvrtDataTable.strPerFromTotal = strtotalper[0];
        objConvrtDataTable.strPerFromBasic = strtotalper[1];

        return objConvrtDataTable;
    }
    
    [WebMethod]
    public static ConvrtDataTable ReadAllwceById(string x, string CorpId, string OrgId)
    {
        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();
        clsBusiness_Pay_Grade_Master objBussnsPayGrd = new clsBusiness_Pay_Grade_Master();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();
        objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(x);
        objEntityPaygrd.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(CorpId);
        DataTable dtAllwce = objBussnsPayGrd.ReadAllounceById(objEntityPaygrd);
        if (dtAllwce.Rows.Count > 0)
        {
            objConvrtDataTable.PaygrdId = Convert.ToInt32(dtAllwce.Rows[0]["PYGRD_ID"].ToString());
            objConvrtDataTable.AllowceId = Convert.ToInt32(dtAllwce.Rows[0]["PGALLCE_ID"].ToString());
            objConvrtDataTable.ddltext = dtAllwce.Rows[0]["PAYRL_NAME"].ToString(); 
            objConvrtDataTable.ddlselectedVal = Convert.ToInt32(dtAllwce.Rows[0]["PAYRL_ID"].ToString());
           

            if (Convert.ToInt32(dtAllwce.Rows[0]["PGALLCE_AMNT_PERCTGE_CHCK"].ToString()) == 0)
            {
                objConvrtDataTable.FrmAmount = Convert.ToDecimal(dtAllwce.Rows[0]["AMOUNTFRM"].ToString());
                objConvrtDataTable.Toamount = Convert.ToDecimal(dtAllwce.Rows[0]["AMOUNTTO"].ToString());
                objConvrtDataTable.RestrctSts = Convert.ToInt32(dtAllwce.Rows[0]["PGALLCE_RANGE_RESTRICT_STS"].ToString());

            }
            if (Convert.ToInt32(dtAllwce.Rows[0]["PGALLCE_AMNT_PERCTGE_CHCK"].ToString()) == 1)
            {
                //  objConvrtDataTable.Perctgeamnt = Convert.ToDecimal(dtAllwce.Rows[0]["PERC"].ToString());
                objConvrtDataTable.strPerctgeamn = dtAllwce.Rows[0]["PERC"].ToString();
                objConvrtDataTable.strPerctgeamnTo = dtAllwce.Rows[0]["PERC_TO"].ToString();
                objConvrtDataTable.RestrctStsPerc = Convert.ToInt32(dtAllwce.Rows[0]["PGALLCE_RANGE_RESTRICT_PER_STS"].ToString());
            }

            objConvrtDataTable.PerOrAmntck = Convert.ToInt32(dtAllwce.Rows[0]["PGALLCE_AMNT_PERCTGE_CHCK"].ToString());
            objConvrtDataTable.sts = Convert.ToInt32(dtAllwce.Rows[0]["PGALLCE_STATUS"].ToString());

            if (dtAllwce.Rows[0]["PAYRL_STATUS"].ToString() == "1" && dtAllwce.Rows[0]["PAYRL_CNCL_USR_ID"].ToString() == "")
            {
                objConvrtDataTable.ddlBinding = 0;
            }
            else
            {

                objConvrtDataTable.ddlBinding = 1;
            }
            DataTable dtSubConrt = objBussnsPayGrd.ReadSalaryAddn(objEntityPaygrd);
            bool existsCus = dtSubConrt.Select().ToList().Exists(row => row["PAYRL_ID"].ToString().ToUpper() == dtAllwce.Rows[0]["PAYRL_ID"].ToString());
            if (existsCus == false)
            {
                objConvrtDataTable.ddlBinding = 1;
            }
        }
        return objConvrtDataTable;
    }
    
            [WebMethod]
    public static ConvrtDataTable ReadDedctnId(string x, string CorpId, string OrgId)
    {
        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();
        clsBusiness_Pay_Grade_Master objBussnsPayGrd = new clsBusiness_Pay_Grade_Master();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();
        objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(x);
        objEntityPaygrd.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(CorpId);
        DataTable dtAllwce = objBussnsPayGrd.ReadDedctnById(objEntityPaygrd);
        if (dtAllwce.Rows.Count > 0)
        {
            objConvrtDataTable.PaygrdId = Convert.ToInt32(dtAllwce.Rows[0]["PYGRD_ID"].ToString());
            objConvrtDataTable.DedctnId = Convert.ToInt32(dtAllwce.Rows[0]["PGDEDTN_ID"].ToString());
            objConvrtDataTable.ddlselectedVal = Convert.ToInt32(dtAllwce.Rows[0]["PAYRL_ID"].ToString());
            objConvrtDataTable.ddltext = dtAllwce.Rows[0]["PAYRL_NAME"].ToString(); 
            if (Convert.ToInt32(dtAllwce.Rows[0]["PGDEDTN_AMNT_PERCTGE_CHCK"].ToString()) == 0)
            {
                objConvrtDataTable.FrmAmount = Convert.ToDecimal(dtAllwce.Rows[0]["AMOUNTFRM"].ToString());
                objConvrtDataTable.Toamount = Convert.ToDecimal(dtAllwce.Rows[0]["AMOUNTTO"].ToString());
                objConvrtDataTable.RestrctSts = Convert.ToInt32(dtAllwce.Rows[0]["PGDEDTN_RANGE_RESTRICT_STS"].ToString());

            }
            if (Convert.ToInt32(dtAllwce.Rows[0]["PGDEDTN_AMNT_PERCTGE_CHCK"].ToString()) == 1)
            {
              //  objConvrtDataTable.Perctgeamnt = Convert.ToDecimal(dtAllwce.Rows[0]["PERC"].ToString());
                objConvrtDataTable.strPerctgeamn = dtAllwce.Rows[0]["PERC"].ToString();
                objConvrtDataTable.strPerctgeamnTo = dtAllwce.Rows[0]["PERC_TO"].ToString();
                objConvrtDataTable.RestrctStsPerc = Convert.ToInt32(dtAllwce.Rows[0]["PGDEDTN_RANGE_RESTRICT_PER_STS"].ToString());

            }

            objConvrtDataTable.BasicOrTotl = Convert.ToInt32(dtAllwce.Rows[0]["PGDEDTN_BASIC_OR_TOTAL_AMNT"].ToString());
            objConvrtDataTable.PerOrAmntck = Convert.ToInt32(dtAllwce.Rows[0]["PGDEDTN_AMNT_PERCTGE_CHCK"].ToString());
            objConvrtDataTable.sts = Convert.ToInt32(dtAllwce.Rows[0]["PGDEDTN_STATUS"].ToString());
            if (dtAllwce.Rows[0]["PAYRL_STATUS"].ToString() == "1" && dtAllwce.Rows[0]["PAYRL_CNCL_USR_ID"].ToString() == "")
            {
                objConvrtDataTable.ddlBinding = 0;
            }
            else
            {
              
                objConvrtDataTable.ddlBinding = 1;
            }
            DataTable dtSubConrt = objBussnsPayGrd.ReadSalaryDedctn(objEntityPaygrd);
           
            bool existsCus = dtSubConrt.Select().ToList().Exists(row => row["PAYRL_ID"].ToString().ToUpper() == dtAllwce.Rows[0]["PAYRL_ID"].ToString());
            if (existsCus == false)
            {
                objConvrtDataTable.ddlBinding = 1;
            }
        }
        return objConvrtDataTable;
    }

    [WebMethod]
            public static int CancelAlertAllwceById(string x, string userId, string CorpId, string AllwOrDed)
    {
        int intuserId = Convert.ToInt32(userId);
        int intCorpId = Convert.ToInt32(CorpId);
        int ret = 0;
        clsBusiness_Pay_Grade_Master objBussnsPayGrd = new clsBusiness_Pay_Grade_Master();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(x);
        objEntityPaygrd.User_Id = intuserId;

        objEntityPaygrd.D_Date = System.DateTime.Now;

        if (dtCorpDetail.Rows.Count > 0)
        {
            string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            if (CnclrsnMust == "0")
            {
                ret = 0;
                objEntityPaygrd.Cancel_reason = objCommon.CancelReason();
                if (AllwOrDed == "0")
                {
                    objBussnsPayGrd.CancelAllownce(objEntityPaygrd);
                }
                if (AllwOrDed == "1")
                {
                    objBussnsPayGrd.CancelDedctn(objEntityPaygrd);
                }


            }
            else
            {
               
                ret = 1;
            }
        }

        return ret;
    }
    
          [WebMethod]
    public static string LoadCurrcyAbbrv(string ddlAddtnValue, string CorpId, string OrgId)
    {
        
        clsBusiness_Pay_Grade_Master objBussnsPayGrd = new clsBusiness_Pay_Grade_Master();
        clsEntity_Pay_Grade_Master objEntityPaygrd = new clsEntity_Pay_Grade_Master();
        DataTable dtContract = new DataTable();
        objEntityPaygrd.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityPaygrd.CorpOffice_Id = Convert.ToInt32(CorpId);
        objEntityPaygrd.currcyId = Convert.ToInt32(ddlAddtnValue);
        DataTable Currcydt = objBussnsPayGrd.CurncyAbbrv(objEntityPaygrd);

        string strabbrv = "";
        if (Currcydt.Rows.Count > 0)
        {
            strabbrv = Currcydt.Rows[0]["CRNCMST_ABBRV"].ToString();
        }
   

        return strabbrv;
    }
}