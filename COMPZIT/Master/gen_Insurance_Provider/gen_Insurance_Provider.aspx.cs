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
using ServiceInsurance;
public partial class WMS_Wms_Master_gen_Insurance_Provider_gen_Insurance_Provider : System.Web.UI.Page
{
    clsBusinessLayerInsuranceProvider objBusinessInsurance = new clsBusinessLayerInsuranceProvider();
    protected void Page_Load(object sender, EventArgs e)
    {
       

        //Assigning  Key actions
        txtProviderName.Attributes.Add("onkeypress", "return isTag(event)");
        txtProviderName.Attributes.Add("onkeydown", "return DisableEnter(event)");
        txtProviderName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtProviderAddress.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlType.Attributes.Add("onkeypress", "return DisableEnter(event)");
        if (!IsPostBack)
        {
            txtProviderName.Focus();
            
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                btnClear.Visible = false;
                btnClearF.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                InsuraceTypeLoad();
                Update(strId);
                lblEntry.InnerText = "Edit Insurance Provider";
                lblEntryB.InnerText = "Edit Insurance Provider";
            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                btnClearF.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                InsuraceTypeLoad();
                View(strId);

                lblEntry.InnerText = "View Insurance Provider";
                lblEntryB.InnerText = "View Insurance Provider";
            }

            else
            {
                lblEntry.InnerText = "Add Insurance Provider";
                lblEntryB.InnerText = "Add Insurance Provider";
                InsuraceTypeLoad();
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;

                btnUpdateF.Visible = false;
                btnUpdateCloseF.Visible = false;
                btnAddF.Visible = true;
                btnAddCloseF.Visible = true;
                btnClearF.Visible = true;
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

        }
        
    }

     public void InsuraceTypeLoad()
     {
         Service_InsuranceProvider objServiceInsurance = new Service_InsuranceProvider();
         
         string jsonValue = objServiceInsurance.ReadInsuranceType();
         DataTable dtInsuranceType = (DataTable)JsonConvert.DeserializeObject(jsonValue, (typeof(DataTable)));
         if (dtInsuranceType.Rows.Count > 0)
         {
             ddlType.DataSource = dtInsuranceType;
             ddlType.DataTextField = "INSURTYP_NAME";
             ddlType.DataValueField = "INSURTYP_ID";
             ddlType.DataBind();
         }

     }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Service_InsuranceProvider objServiceInsurance = new Service_InsuranceProvider();

        Button clickedButton = sender as Button;
        int intCorpId = 0, intOrgId = 0, intInsuranceId = 0, intInsuranceTypeId = 0, intStatusId = 0, intUserId = 0;
        string strInsuranceProviderName = "", strInsuranceProviderAddr = "";
        if (Request.QueryString["Id"] != null)
        {
            clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();


            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                intStatusId = 1;
            }
            //Status checkbox not checked
            else
            {
                intStatusId = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strInsuranceId = strRandomMixedId.Substring(2, intLenghtofId);

            intInsuranceId = Convert.ToInt32(strInsuranceId);
          
            strInsuranceProviderName = txtProviderName.Value.Trim().ToUpper();
            strInsuranceProviderAddr = txtProviderAddress.Value.Trim();

            string strInsuranceType = HiddenFieldTypeValues.Value;
            

            //Checking is there table have any name like this
            string strNameCount = objServiceInsurance.CheckInsuranceProviderName(intInsuranceId, strInsuranceProviderName, intCorpId, intOrgId);

            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                objServiceInsurance.UpdateInsuranceProvider(intInsuranceId, intCorpId, intOrgId, intUserId, strInsuranceType, intStatusId, strInsuranceProviderName, strInsuranceProviderAddr);
                if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                {
                    Response.Redirect("gen_Insurance_Provider.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                {
                    Response.Redirect("gen_Insurance_Provider_List.aspx?InsUpd=Upd");
                }

            }
            //If have
            else
            {
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

        Service_InsuranceProvider objServiceInsurance = new Service_InsuranceProvider();
        clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        int intCorpId = 0, intOrgId = 0, intUserId = 0, intStatus = 0;
        string strProviderName = "", strProviderAddress = "";
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityInsurance.Status_id = 1;
            intStatus = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityInsurance.Status_id = 0;
            intStatus = 0;
        }
        strProviderName = txtProviderName.Value.Trim().ToUpper();

        if (txtProviderAddress.Value.Trim() != "" && txtProviderAddress.Value.Trim() != null)
        {
            strProviderAddress = txtProviderAddress.Value.Trim();
        }

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_PROVIDER);
        objEntityCommon.CorporateID = intCorpId;
        objEntityCommon.Organisation_Id = intOrgId;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        objEntityInsurance.NextNumber = Convert.ToInt32(strNextId);
        int intNextNumber = objEntityInsurance.NextNumber;


        string strInsuranceType = HiddenFieldTypeValues.Value;
      


        //Checking is there table have any name like this
        string strNameCount = objServiceInsurance.CheckInsuranceProviderName(0, strProviderName, intCorpId, intOrgId);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            objServiceInsurance.AddInsuranceProvider(intNextNumber,intCorpId, intOrgId, intUserId, strInsuranceType, intStatus, strProviderName, strProviderAddress);
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_Insurance_Provider.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_Insurance_Provider_List.aspx?InsUpd=Ins");
            }

        }
        //If have
        else
        {
            if (strNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

            }

        }
    }


    public void View(string strDId)
    {

        Service_InsuranceProvider objServiceInsurance = new Service_InsuranceProvider();
        clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();
        string JsonInsuranceDetails = objServiceInsurance.ReadInsuranceDetailById(Convert.ToInt32(strDId));
        DataTable dtInsuranceDetails = (DataTable)JsonConvert.DeserializeObject(JsonInsuranceDetails, (typeof(DataTable)));

        string JsonInsuranceTypeDetails = objServiceInsurance.ReadInsuranceTypeByPrvdrId(Convert.ToInt32(strDId));
        DataTable dtInsuranceTypeDetail = (DataTable)JsonConvert.DeserializeObject(JsonInsuranceTypeDetails, (typeof(DataTable)));
        //After fetch insurance details in datatable,we need to differentiate.
        if (dtInsuranceDetails.Rows.Count > 0)
        {
            txtProviderName.Value = dtInsuranceDetails.Rows[0]["INSURPRVDR_NAME"].ToString();
            txtProviderAddress.Value = dtInsuranceDetails.Rows[0]["INSURPRVDR_ADDRS"].ToString();
           
            int intInsuretStatus = Convert.ToInt32(dtInsuranceDetails.Rows[0]["INSURPRVDR_STATUS"]);
            if (intInsuretStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }

        if (dtInsuranceTypeDetail.Rows.Count > 0)
        {
  
                for (int count = 0; count < dtInsuranceTypeDetail.Rows.Count; count++)
                {
                    string intType = dtInsuranceTypeDetail.Rows[count]["INSURTYP_ID"].ToString();

                    if (HiddenFieldTypeValues.Value == "")
                    {
                        HiddenFieldTypeValues.Value = intType;
                    }
                    else
                    {
                        HiddenFieldTypeValues.Value = HiddenFieldTypeValues.Value + "," + intType;
                    }
                }

        }





        txtProviderName.Disabled = true;
        txtProviderAddress.Disabled = true;

        ddlType.Enabled = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        cbxStatus.Disabled = true;
        cbxStatus.Attributes["style"] = "pointer-events: none;";
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateCloseF.Visible = false;
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strDId)
     {
        Service_InsuranceProvider objServiceInsurance = new Service_InsuranceProvider();
        clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();
        string JsonInsuranceDetails = objServiceInsurance.ReadInsuranceDetailById(Convert.ToInt32(strDId));
        DataTable dtInsuranceDetails = (DataTable)JsonConvert.DeserializeObject(JsonInsuranceDetails, (typeof(DataTable)));


        string JsonInsuranceTypeDetails = objServiceInsurance.ReadInsuranceTypeByPrvdrId(Convert.ToInt32(strDId));
        DataTable dtInsuranceTypeDetail = (DataTable)JsonConvert.DeserializeObject(JsonInsuranceTypeDetails, (typeof(DataTable)));
        //After fetch insurance details in datatable,we need to differentiate.
        if (dtInsuranceDetails.Rows.Count > 0)
        {
            txtProviderName.Value = dtInsuranceDetails.Rows[0]["INSURPRVDR_NAME"].ToString();
            txtProviderAddress.Value = dtInsuranceDetails.Rows[0]["INSURPRVDR_ADDRS"].ToString();
            //ddlinsuranceType.Items.FindByText(dtInsuranceDetails.Rows[0]["INSURTYP_ID"].ToString()).Selected = true;

      
            int intInsuretStatus = Convert.ToInt32(dtInsuranceDetails.Rows[0]["INSURPRVDR_STATUS"]);
            if (intInsuretStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }

        if (dtInsuranceTypeDetail.Rows.Count>0)
        {

           
                for(int count=0;count<dtInsuranceTypeDetail.Rows.Count;count++)
                {
                    string intType=dtInsuranceTypeDetail.Rows[count]["INSURTYP_ID"].ToString();

                    if (HiddenFieldTypeValues.Value == "")
                    {
                        HiddenFieldTypeValues.Value = intType;
                    }
                    else
                    {
                        HiddenFieldTypeValues.Value = HiddenFieldTypeValues.Value + "," + intType;
                    }
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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Insurance_Provider);
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
            btnUpdateF.Visible = true;
        }
        else
        {

            btnUpdate.Visible = false;
            btnUpdateF.Visible = false;

        }

        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdateClose.Visible = true;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateCloseF.Visible = true;
    }
}