using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
// CREATED BY:EVM-0008
// CREATED DATE:10/5/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class HCM_HCM_Master_gen_visa_quota_info_gen_visa_quota_info : System.Web.UI.Page
{
    clsBusiness_visa_quota_info objBussnsVisQuotInfo = new clsBusiness_visa_quota_info();
    protected void Page_Load(object sender, EventArgs e)
    {

        txtBundlNum.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtIssuedDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtExpDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtBundlNum.Attributes.Add("onkeypress", "return isTag(event)");
        txtIssuedDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtExpDate.Attributes.Add("onkeypress", "return isTag(event)");

        ddlVisTyp.Attributes.Add("onchange", "IncrmntConfrmCounterVisQut()");
        ddlNation.Attributes.Add("onchange", "IncrmntConfrmCounterVisQut()");
        txtnumofvisa.Attributes.Add("onchange", "IncrmntConfrmCounterVisQut()");
        ddlBusUnit.Attributes.Add("onchange", "IncrmntConfrmCounterVisQut()");
        ddlGender.Attributes.Add("onchange", "IncrmntConfrmCounterVisQut()");

        ddlVisTyp.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlNation.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlBusUnit.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlGender.Attributes.Add("onkeypress", "return DisableEnter(event)");

       

    


        if (!IsPostBack)
        {

            HiddenVisaTyp.Value ="";
         
            HiddenNation.Value="";
            txtBundlNum.Focus();
            SelectNationsLoad();
                VisaTypLoad();
                BussnsUnitLoad();
                HiddenView.Value = "";
                txtAllotdVisa.Enabled= false;
                HiddenVisaQuotaId.Value = "";
                imgbtnReOpen.ImageUrl = "/Images/Icons/Reopen.png";
                imgbtnReOpen.Visible = false;
                hiddenRoleReOpen.Value = "";
                hiddenRoleConfirm.Value = "";
                btnConfirm.Visible = false;
                HiddenCurrentDate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
            int intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);
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
                objEntityVisQuotInfo.CorpOffice= Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
                objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
                HiddenOrgId.Value = Session["ORGID"].ToString();

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intUsrRolMstrId, intEnableAdd = 0, intEnableModify=0;
            //Allocating child roles
            hiddenRoleAdd.Value = "0";
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Visa_Quota);
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
                    else if (strC_Role == Convert.ToInt32(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleUpdate.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        HiddnEnableCacel.Value = "1";

                    }

                    else if (strC_Role == Convert.ToInt32(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        hiddenRoleReOpen.Value = "1";
                    }

                    else if (strC_Role == Convert.ToInt32(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        hiddenRoleConfirm.Value = "1";
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
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
               // HiddenEdtOrViw.Value = "1";
                btnClear.Visible = true;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.Text = "Edit Visa Quota";

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
               // HiddenEdtOrViw.Value = "1";
                HiddenView.Value = "1";
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                // HiddenViewId.Value = strId;
                View(strId);

                //img1.Disabled = true;
                lblEntry.Text = "View Visa Quota";



            }
            else
            {
                lblEntry.Text = "Visa Quota";

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
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
       
        btnUpdateClose.Visible = true;
        // clsentitylayeemplo objEntitySponsor = new clsEntitySponsor();
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;

        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();

        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId= Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //Allocating child roles
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Visa_Quota);
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

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdate.Visible = true;
            }
            else
            {

                btnUpdate.Visible = false;

            }



        }





        objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(strP_Id);
        HiddenVisaQuotaId.Value = strP_Id;
        DataTable dtSponsor = objBussnsVisQuotInfo.ReadVisaQuota(objEntityVisQuotInfo);
        if (dtSponsor.Rows.Count > 0)
        {
            HiddenVisaQuotaId.Value = dtSponsor.Rows[0]["VISQT_ID"].ToString();
           // if (dtSponsor.Rows[0]["BUNDLE NUMBER"].ToString() != null && dtSponsor.Rows[0]["BUNDLE NUMBER"].ToString() != "")
            txtBundlNum.Text = dtSponsor.Rows[0]["BUNDLE NUMBER"].ToString();

          //  if (dtSponsor.Rows[0]["JOBDES_DESIRED_QUALFN"].ToString() != null && dtSponsor.Rows[0]["JOBDES_DESIRED_QUALFN"].ToString() != "")
            txtIssuedDate.Text = dtSponsor.Rows[0]["ISSUED DATE"].ToString();

          //  if (dtSponsor.Rows[0]["JOBDES_SUMMRY_POSTN"].ToString() != null && dtSponsor.Rows[0]["JOBDES_SUMMRY_POSTN"].ToString() != "")
            txtExpDate.Text = dtSponsor.Rows[0]["EXPIRY DATE"].ToString();
          
                if (hiddenRoleReOpen.Value == "1")
                {
                    if (dtSponsor.Rows[0]["VISQT_CNFRM_STATUS"].ToString() == "1")
                    {
                        imgbtnReOpen.Visible = true;
                    }
                }
            

           
                if (hiddenRoleConfirm.Value == "1")
                {

                    if (dtSponsor.Rows[0]["VISQT_CNFRM_STATUS"].ToString() == "0")
                    {
                        btnConfirm.Visible = true;
                    }
                }
                imgbtnReOpen.Visible= false;

        }
        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

    }
    //Fetching the table from business layer and assign them in our fields.
    public void View(string strP_Id)
    {
        
        // clsentitylayeemplo objEntitySponsor = new clsEntitySponsor();
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;

        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();

        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //Allocating child roles
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Visa_Quota);
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

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdate.Visible = true;
            }
            else
            {

                btnUpdate.Visible = false;

            }



        }





        objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(strP_Id);
        DataTable dtSponsor = objBussnsVisQuotInfo.ReadVisaQuota(objEntityVisQuotInfo);
        if (dtSponsor.Rows.Count > 0)
        {
            HiddenVisaQuotaId.Value = dtSponsor.Rows[0]["VISQT_ID"].ToString();
            // if (dtSponsor.Rows[0]["BUNDLE NUMBER"].ToString() != null && dtSponsor.Rows[0]["BUNDLE NUMBER"].ToString() != "")
            txtBundlNum.Text = dtSponsor.Rows[0]["BUNDLE NUMBER"].ToString();

            //  if (dtSponsor.Rows[0]["JOBDES_DESIRED_QUALFN"].ToString() != null && dtSponsor.Rows[0]["JOBDES_DESIRED_QUALFN"].ToString() != "")
            txtIssuedDate.Text = dtSponsor.Rows[0]["ISSUED DATE"].ToString();

            //  if (dtSponsor.Rows[0]["JOBDES_SUMMRY_POSTN"].ToString() != null && dtSponsor.Rows[0]["JOBDES_SUMMRY_POSTN"].ToString() != "")
            txtExpDate.Text = dtSponsor.Rows[0]["EXPIRY DATE"].ToString();

            if (hiddenRoleReOpen.Value == "1")
            {
                if (dtSponsor.Rows[0]["VISQT_CNFRM_STATUS"].ToString() == "1")
                {
                    imgbtnReOpen.Visible = true;
                }
            }



            if (hiddenRoleConfirm.Value == "1")
            {

                if (dtSponsor.Rows[0]["VISQT_CNFRM_STATUS"].ToString() == "0")
                {
                    btnConfirm.Visible = true;
                }
            }


        }
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        btnConfirm.Enabled = false;
       // imgbtnReOpen.Enabled = false;
        txtBundlNum.Enabled = false;
        txtIssuedDate.Enabled = false;
        txtExpDate.Enabled = false;

        ddlVisTyp.Enabled = false;
        ddlNation.Enabled = false;
        txtnumofvisa.Enabled = false;
        ddlBusUnit.Enabled = false;
        ddlGender.Enabled = false;
        ButtnDiv.Visible = false;
        btnConfirm.Visible = false;
        imgDate.Disabled = true;
        img1.Disabled = true;
        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

    }
    public void VisaTypLoad()
    {
        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussnsVisQuotInfo.ReadVisaTyp(objEntityVisQuotInfo);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlVisTyp.DataSource = dtSubConrt;
            ddlVisTyp.DataTextField = "VISA_NAME";
            ddlVisTyp.DataValueField = "VISATYP_ID";
            ddlVisTyp.DataBind();

        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddlVisTyp.Items.Insert(0, "--SELECT VISA PROFESSION--");

        // ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }

    public void SelectNationsLoad()
    {
        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussnsVisQuotInfo.ReadSelectNations(objEntityVisQuotInfo);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlNation.DataSource = dtSubConrt;
            ddlNation.DataTextField = "CNTRY_NAME";
            ddlNation.DataValueField = "CNTRY_ID";
            ddlNation.DataBind();

        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddlNation.Items.Insert(0, "--SELECT NATION--");

        // ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }
    public void BussnsUnitLoad()
    {
        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
        string strcorp = "";
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
            int CoprId = Convert.ToInt32(Session["CORPOFFICEID"]);
             strcorp = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussnsVisQuotInfo.ReadBussnsUnit(objEntityVisQuotInfo);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlBusUnit.DataSource = dtSubConrt;
            ddlBusUnit.DataTextField = "CORPRT_NAME";
            ddlBusUnit.DataValueField = "CORPRT_ID";
            ddlBusUnit.DataBind();

        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
      //  ddlNation.Items.Insert(0, "--SELECT NATION--");
        if(strcorp!="")
            ddlBusUnit.Items.FindByValue(strcorp).Selected = true;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        objEntityVisQuotInfo.BundleNum = txtBundlNum.Text.Trim();
        objEntityVisQuotInfo.IssueDate = objCommon.textToDateTime(txtIssuedDate.Text.Trim());
        objEntityVisQuotInfo.ExpiryDate = objCommon.textToDateTime(txtExpDate.Text.Trim());
     
  

        DataTable strdupName ;
        strdupName = objBussnsVisQuotInfo.DuplCheckVisaQuota(objEntityVisQuotInfo);
        if (strdupName.Rows.Count > 0)
        {

            if (strdupName.Rows[0]["COUNT"].ToString() == "" || strdupName.Rows[0]["COUNT"].ToString() == "0")
            {
                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.VISA_QUOTA);
                objEntityCommon.CorporateID = objEntityVisQuotInfo.CorpOffice;
                objEntityCommon.Organisation_Id = objEntityVisQuotInfo.Orgid;
                string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(strNextId);
                HiddenVisaQuotaId.Value = strNextId;
                objBussnsVisQuotInfo.AddVisaQuota(objEntityVisQuotInfo);



                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnClear.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

                if (clickedButton.ID == "btnAdd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationVisaQuota", "SuccessConfirmationVisaQuota();", true);

                }
                else if (clickedButton.ID == "btnAddClose")
                {
                    //Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Ins");
                    Response.Redirect("gen_visa_quota_info_List.aspx?InsUpd=Ins");
                }
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            }
        }
       

    }

    protected void btnAdd_Addtn_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
        int intUserId = 0, intUsrRolMstrId = 0, intEnableCancel = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

      

        if (HiddenVisaQuotaId.Value != "")
        {
            objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(HiddenVisaQuotaId.Value);
            if (ddlVisTyp.SelectedItem.Value.ToString() != "--SELECT VISA PROFESSION--")
            {
                objEntityVisQuotInfo.VisaTyp = Convert.ToInt32(ddlVisTyp.SelectedItem.Value);
            }
            if (ddlNation.SelectedItem.Value.ToString() != "--SELECT NATION--")
            {
                objEntityVisQuotInfo.CountryId = Convert.ToInt32(ddlNation.SelectedItem.Value);
            }
            DataTable strdupName;
            strdupName = objBussnsVisQuotInfo.DuplCheckVisaQuotaType(objEntityVisQuotInfo);
            if (strdupName.Rows.Count > 0)
            {

                if (strdupName.Rows[0]["COUNT"].ToString() == "" || strdupName.Rows[0]["COUNT"].ToString() == "0")
                {

                   
                    objEntityVisQuotInfo.BussnsId = Convert.ToInt32(ddlBusUnit.SelectedItem.Value);
                    objEntityVisQuotInfo.Gender = Convert.ToInt32(ddlGender.SelectedItem.Value);
                    objEntityVisQuotInfo.NumVisa = Convert.ToInt32(HiddenNumVisa.Value);






                    objBussnsVisQuotInfo.AddVisaQuotaDetails(objEntityVisQuotInfo);





                    if (clickedButton.ID == "SaveAddtn")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationVisaQuotaDtls", "SuccessConfirmationVisaQuotaDtls();", true);
                    }
                }
                else
                {


                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationVisaTypNameSave", "DuplicationVisaTypNameSave();", true);
            
                }
            }
        }
     
      //  ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

       // ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);

    }
    protected void btnUpdate_VisaDtls_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
        int intUserId = 0, intUsrRolMstrId = 0, intEnableCancel = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }



        if (HiddenVisaQuotaId.Value != "")
        {
            if (HiddenVisaQuotaId.Value != "")
            {
                objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(HiddenVisaQuotaId.Value);
            }
            objEntityVisQuotInfo.VisaDetailId = Convert.ToInt32(HiddenVisaDetlId.Value);
            if (HiddenVisaTyp.Value != "")
            {
                objEntityVisQuotInfo.VisaTyp = Convert.ToInt32(HiddenVisaTyp.Value);
            }

            if (HiddenNation.Value != "")
            {
                objEntityVisQuotInfo.CountryId = Convert.ToInt32(HiddenNation.Value);
            }
               DataTable strdupName;
            strdupName = objBussnsVisQuotInfo.DuplCheckVisaQuotaType(objEntityVisQuotInfo);
            if (strdupName.Rows.Count > 0)
            {

                if (strdupName.Rows[0]["COUNT"].ToString() == "" || strdupName.Rows[0]["COUNT"].ToString() == "0")
                {
                    if (HiddenNation.Value != "")
                    {
                        objEntityVisQuotInfo.CountryId = Convert.ToInt32(HiddenNation.Value);
                    }
                    //if (ddlVisTyp.SelectedItem.Value.ToString() != "--SELECT VISA TYPE--")
                    //{
                    //    objEntityVisQuotInfo.VisaTyp = Convert.ToInt32(ddlVisTyp.SelectedItem.Value);
                    //}
                    //if (ddlNation.SelectedItem.Value.ToString() != "--SELECT NATION--")
                    //{
                    //    objEntityVisQuotInfo.CountryId = Convert.ToInt32(ddlNation.SelectedItem.Value);
                    //}
                    objEntityVisQuotInfo.BussnsId = Convert.ToInt32(HiddenBissnsUnitID.Value);
                    // objEntityVisQuotInfo.BussnsId = Convert.ToInt32(ddlBusUnit.SelectedItem.Value);
                    objEntityVisQuotInfo.Gender = Convert.ToInt32(ddlGender.SelectedItem.Value);
                    objEntityVisQuotInfo.NumVisa = Convert.ToInt32(HiddenNumVisa.Value);

                        




                    objBussnsVisQuotInfo.UpDateVisaQuotaDetails(objEntityVisQuotInfo);






                    if (clickedButton.ID == "UpdateAddtn")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "UpdateVisaDetls", "UpdateVisaDetls();", true);
                    }
                    else if (clickedButton.ID == "btnUpdateClose")
                    {
                        //Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Ins");
                        Response.Redirect("gen_visa_quota_info_List.aspx?InsUpd=Upd");
                    }
                }
                else
                {


                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationVisaTypName", "DuplicationVisaTypName();", true);

                }
            }
        }
            //else if (clickedButton.ID == "btnAddClose")
            //{
            //    //Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Ins");
            //}
     
        //  ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

        //  ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);
    }

    protected void imgbtnReOpen_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
        int intUserId = 0, intUsrRolMstrId = 0, intEnableCancel = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }



        if (HiddenVisaQuotaId.Value != "")
        {
           
                objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(HiddenVisaQuotaId.Value);
                //evm-0023 Bundle number to upper case
            objEntityVisQuotInfo.BundleNum = txtBundlNum.Text.Trim().ToUpper();
            objEntityVisQuotInfo.IssueDate = objCommon.textToDateTime(txtIssuedDate.Text.Trim());
            objEntityVisQuotInfo.ExpiryDate = objCommon.textToDateTime(txtExpDate.Text.Trim());
           // objEntityVisQuotInfo.ConfrmChkId = 1;




            objBussnsVisQuotInfo.ReopenVisaQuota(objEntityVisQuotInfo);






          
                Response.Redirect("gen_visa_quota_info_List.aspx?InsUpd=REOPN");
            
          
        }
        //else if (clickedButton.ID == "btnAddClose")
        //{
        //    //Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Ins");
        //}

        //  ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

        //  ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
        int intUserId = 0, intUsrRolMstrId = 0, intEnableCancel = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }



        if (HiddenVisaQuotaId.Value != "")
        {
           
                objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(HiddenVisaQuotaId.Value);
                objEntityVisQuotInfo.BundleNum = txtBundlNum.Text.Trim().ToUpper();

             DataTable strdupName ;
        strdupName = objBussnsVisQuotInfo.DuplCheckVisaQuota(objEntityVisQuotInfo);
        if (strdupName.Rows.Count > 0)
        {

            if (strdupName.Rows[0]["COUNT"].ToString() == "" || strdupName.Rows[0]["COUNT"].ToString() == "0")
            {
                //evm-0023 Bundle number to upper case
              
                objEntityVisQuotInfo.IssueDate = objCommon.textToDateTime(txtIssuedDate.Text.Trim());
                objEntityVisQuotInfo.ExpiryDate = objCommon.textToDateTime(txtExpDate.Text.Trim());
                objEntityVisQuotInfo.ConfrmChkId = 1;




                objBussnsVisQuotInfo.UpDateVisaQuota(objEntityVisQuotInfo);






                if (clickedButton.ID == "btnConfirm")
                {
                    Response.Redirect("gen_visa_quota_info_List.aspx?InsUpd=CNFIRM");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            }
        }
          
        }
        //else if (clickedButton.ID == "btnAddClose")
        //{
        //    //Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Ins");
        //}

        //  ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

        //  ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
        int intUserId = 0, intUsrRolMstrId = 0, intEnableCancel = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVisQuotInfo.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityVisQuotInfo.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }



        if (HiddenVisaQuotaId.Value != "")
        {
            objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(HiddenVisaQuotaId.Value);
            objEntityVisQuotInfo.BundleNum = txtBundlNum.Text.Trim();
              DataTable strdupName ;
        strdupName = objBussnsVisQuotInfo.DuplCheckVisaQuota(objEntityVisQuotInfo);
        if (strdupName.Rows.Count > 0)
        {

            if (strdupName.Rows[0]["COUNT"].ToString() == "" || strdupName.Rows[0]["COUNT"].ToString() == "0")
            {
               
               
                objEntityVisQuotInfo.IssueDate = objCommon.textToDateTime(txtIssuedDate.Text.Trim());
                objEntityVisQuotInfo.ExpiryDate = objCommon.textToDateTime(txtExpDate.Text.Trim());
                objEntityVisQuotInfo.ConfrmChkId = 0;




                objBussnsVisQuotInfo.UpDateVisaQuota(objEntityVisQuotInfo);






                if (clickedButton.ID == "btnUpdate")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "UpdateVisaDetls", "UpdateVisaDetls();", true);
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    //Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Ins");
                    Response.Redirect("gen_visa_quota_info_List.aspx?InsUpd=Upd");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            }
            }
        }
        //else if (clickedButton.ID == "btnAddClose")
        //{
        //    //Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Ins");
        //}

        //  ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

        //  ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);
    }
    public class ConvrtDataTable
    {
        public int VisaQuotaId = 0;
        public int VisDtlId = 0;
         public int ddlselValVisa = 0;
         public int ddlselValNation = 0;
         public int ddlselValBussns = 0;
        public int NoofVisa = 0;
         public int Gender = 0;
          public int ddlChkVisa = 0;
        public int ddlChkCorp = 0;
         public int ddlChkContry = 0;
       
       
        public string ddltextVisa = "";
         public string ddltextNation = "";
         public string ddltextBussns = "";
         public string strhtml = "";

         public string strRemVis = "";




         public string ConvertDataTableToHTML(DataTable dt, int intEnableCancel, string RoleUpdate, string View)
        {
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
    

            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "";
       
                strHtml = "<table id=\"ReportTableAllw\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
      
        

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
          //  strHtml += "<th class=\"thT\" style=\"width:4%;text-align: left; word-wrap:break-word;\">SL#</th>";
          
                for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
                {

                    if (intColumnHeaderCount == 1)
                    {
                        strHtml += "<th class=\"thT\" style=\"width:24%;text-align: left; word-wrap:break-word;\">VISA PROFESSION</th>";
                    }

                    else if (intColumnHeaderCount == 2)
                    {
                        strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                    }
                    else if (intColumnHeaderCount == 3)
                    {
                        strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                    }
                    else if (intColumnHeaderCount == 4)
                    {
                        strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: right; word-wrap:break-word;\">BALANCE NO. OF VISA</th>";
                    }


                }
            
         
           


            //if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            //{
            if (intReCallForTAble == 0)
            {
                if (RoleUpdate == "1")
                {
                    strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
                }
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
                        if (intColumnBodyCount == 2)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 3)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 4)
                        {
                            string STRCOUNT = "0";
                            clsBusiness_visa_quota_info objBussnsVisQuotInfo = new clsBusiness_visa_quota_info();
                            clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
                            objEntityVisQuotInfo.VisaTyp =Convert.ToInt32(dt.Rows[intRowBodyCount]["VISATYP_ID"].ToString());
                            objEntityVisQuotInfo.NxtVisaId =Convert.ToInt32(dt.Rows[intRowBodyCount]["VISQT_ID"].ToString());
                            DataTable dtVisaCount = objBussnsVisQuotInfo.ReadVisaCountId(objEntityVisQuotInfo);
                            if (dtVisaCount.Rows.Count > 0)
                            {
                                int Count = Convert.ToInt32(dt.Rows[0]["VISQT_DTLS_NUM_ALLOCTD_VISA"].ToString()) - Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
                                if (Count <= 0)
                                {
                                    STRCOUNT = "0";
                                }
                                else
                                {
                                  STRCOUNT=  Count.ToString();
                                }
                            }

                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + STRCOUNT + "</td>";
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
                            if (View != "1")
                            {

                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" style=\"cursor:pointer;margin-top:-1.5%;opacity:1;\" onclick=\"return getdetailsAllwceById('" + strId + "');\" >" +
                                     "<img  style=\"cursor:pointer;margin-top:-1.5%;opacity:1 \" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                            }
                            else
                            {
                                //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" style=\"cursor:pointer;margin-top:-1.5%;opacity:.2;\" >" +
                                //           "<img  style=\"cursor:pointer;margin-top:-1.5%;opacity:1 \" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" style=\"cursor:pointer;margin-top:-1.5%;opacity:1;\" onclick=\"return getdetailsAllwceById('" + strId + "');\" >" +
                                   "<img  style=\"cursor:pointer;margin-top:-1.5%;opacity:1 \" src='/Images/Icons/view.png' /> " + "</a> </td>";
                            }

                        }
                        else
                        {
                            //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\"  style=\"opacity: .5;margin-top: -1.3%\" title=\"Edit\"  >" +
                            //       "<img  style=\"cursor:pointer;margin-top:-1.5%;\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                        }


                    }

                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\"  style=\"opacity: .5;\" title=\"Edit\"  >" +
                                   "<img  style=\"cursor:pointer\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


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
                                if (View != "1")
                                {

                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left:1%\" class=\"tooltip\" title=\"Cancel\" onclick=\"return CancelAlertAllwceById('" + strId + "');\" >" +
                                      "<img  style=\"cursor:pointer\" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  style=\"cursor:pointer;margin-top:-1.5%;opacity:.2;margin-left:1%\" class=\"tooltip\" title=\"Cancel\"  >" +
                                        "<img  style=\"cursor:pointer\" src='/Images/Icons/delete.png' /> " + "</a> </td>";
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

                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left:1%\" class=\"tooltip\" title=\"Cancel\" onclick='return CancelNotPossible();' >"
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
    public static ConvrtDataTable LoadListPageallwnce(string EnableCanl, string CorpId, string OrgId, string VisaQuotaId, string RoleUpdate, string View)
    {
        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();
        clsBusiness_visa_quota_info objBussnsVisQuotInfo = new clsBusiness_visa_quota_info();
        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
        DataTable dtContract = new DataTable();
        objEntityVisQuotInfo.Orgid = Convert.ToInt32(OrgId);
        objEntityVisQuotInfo.CorpOffice= Convert.ToInt32(CorpId);
     
        if (VisaQuotaId != "")
            objEntityVisQuotInfo.NxtVisaId = Convert.ToInt32(VisaQuotaId);
        else
            objEntityVisQuotInfo.NxtVisaId = 0;
        dtContract = objBussnsVisQuotInfo.ReadVisaDetailsList(objEntityVisQuotInfo);

        

        string htrm = "";
        int EnableCancel = Convert.ToInt32(EnableCanl);
        objConvrtDataTable.strhtml = objConvrtDataTable.ConvertDataTableToHTML(dtContract, EnableCancel, RoleUpdate, View);
   
        return objConvrtDataTable;
    }

    [WebMethod]
    public static ConvrtDataTable ReadVisaDetailsEdit(string x, string CorpId, string OrgId)
    {
        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();
        clsBusiness_visa_quota_info objBussnsVisQuotInfo = new clsBusiness_visa_quota_info();
        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();
        objEntityVisQuotInfo.VisaDetailId = Convert.ToInt32(x);
        objEntityVisQuotInfo.Orgid = Convert.ToInt32(OrgId);
        objEntityVisQuotInfo.CorpOffice = Convert.ToInt32(CorpId);
        DataTable dtAllwce = objBussnsVisQuotInfo.ReadVisaDetailsId(objEntityVisQuotInfo);
      //  DataTable dtVisaCount = objBussnsVisQuotInfo.ReadVisaCountId(objEntityVisQuotInfo);
        if (dtAllwce.Rows.Count > 0)
        {
            objConvrtDataTable.VisaQuotaId = Convert.ToInt32(dtAllwce.Rows[0]["VISQT_ID"].ToString());
            objConvrtDataTable.VisDtlId = Convert.ToInt32(dtAllwce.Rows[0]["VISQT_DTLS_ID"].ToString());
            objConvrtDataTable.ddltextVisa = dtAllwce.Rows[0]["VISA TYPE"].ToString();
            objConvrtDataTable.ddlselValVisa = Convert.ToInt32(dtAllwce.Rows[0]["VISATYP_ID"].ToString());
            objEntityVisQuotInfo.VisaTyp = objConvrtDataTable.ddlselValVisa;
            objEntityVisQuotInfo.NxtVisaId = objConvrtDataTable.VisaQuotaId;
            DataTable dtVisaCount = objBussnsVisQuotInfo.ReadVisaCountId(objEntityVisQuotInfo);
            if (dtVisaCount.Rows.Count > 0)
            {
                int Count =Convert.ToInt32(dtAllwce.Rows[0]["VISQT_DTLS_NUM_ALLOCTD_VISA"].ToString())-Convert.ToInt32(dtVisaCount.Rows[0]["COUNT"].ToString());
                if (Count <= 0)
                {
                    objConvrtDataTable.strRemVis = "0";
                }
                else
                {
                    objConvrtDataTable.strRemVis = Count.ToString();
                }
            }

            objConvrtDataTable.ddltextNation = dtAllwce.Rows[0]["NATION"].ToString();
            objConvrtDataTable.ddlselValNation = Convert.ToInt32(dtAllwce.Rows[0]["CNTRY_ID"].ToString());
            objConvrtDataTable.ddltextBussns = dtAllwce.Rows[0]["COMPANY"].ToString();
            objConvrtDataTable.ddlselValBussns = Convert.ToInt32(dtAllwce.Rows[0]["CORPRT_ID"].ToString());

            objConvrtDataTable.NoofVisa = Convert.ToInt32(dtAllwce.Rows[0]["NO. OF VISA"].ToString());
            objConvrtDataTable.Gender = Convert.ToInt32(dtAllwce.Rows[0]["VISQT_DTLS_GENDER"].ToString());
            if (dtAllwce.Rows[0]["VISA_STATUS"].ToString() == "1" && dtAllwce.Rows[0]["VISATYP_CNCL_USR_ID"].ToString() == "")
            {
                objConvrtDataTable.ddlChkVisa = 0;
            }
            else
            {

                objConvrtDataTable.ddlChkVisa = 1;
            }
            if (dtAllwce.Rows[0]["CORPRT_STATUS"].ToString() == "1" && dtAllwce.Rows[0]["CORPRT_CNCL_USR_ID"].ToString() == "")
             {
                 objConvrtDataTable.ddlChkCorp = 0;
             }
             else
             {

                 objConvrtDataTable.ddlChkCorp = 1;
             }
            if (dtAllwce.Rows[0]["CNTRY_STATUS"].ToString() == "1" && dtAllwce.Rows[0]["CNTRY_CNCL_USR_ID"].ToString() == "")
             {
                 objConvrtDataTable.ddlChkContry = 0;
             }
             else
             {

                 objConvrtDataTable.ddlChkContry = 1;
             }
          
        }
        return objConvrtDataTable;
    }

    [WebMethod]
    public static string CancelAlertVisaDtls(string x, string userId, string CorpId)
    {
        int intuserId = Convert.ToInt32(userId);
        int intCorpId = Convert.ToInt32(CorpId);
        int ret = 0;
        clsBusiness_visa_quota_info objBussnsVisQuotInfo = new clsBusiness_visa_quota_info();
        clsEntity_visa_quota_info objEntityVisQuotInfo = new clsEntity_visa_quota_info();


        objEntityVisQuotInfo.VisaDetailId = Convert.ToInt32(x);
        objEntityVisQuotInfo.UserId= intuserId;

        objEntityVisQuotInfo.dateNow= System.DateTime.Now;

        string strRet = "success";
      try{
        
             
                    objBussnsVisQuotInfo.CancelVisaDtls(objEntityVisQuotInfo);
      }
            
        catch
        {
            strRet = "failed";
        }

        return strRet;


          

       
    }
    
  
}