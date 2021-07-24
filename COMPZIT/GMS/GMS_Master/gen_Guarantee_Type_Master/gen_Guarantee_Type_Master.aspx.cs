using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusinessLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
//using BL
// CREATED BY:EVM-0005
// CREATED DATE:31/12/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class GMS_GMS_Master_gen_Guarantee_Type_Master_gen_Guarantee_Type_Master : System.Web.UI.Page
{
    classBusinessLayerGuaranteType ObjBussinessGuarante = new classBusinessLayerGuaranteType();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtName.Attributes.Add("onkeypress", "return isTag(event)");
        txtName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        radioGuaranteMode.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        radioGuaranteMode.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            int intCorpId = 0;
            btnClose.Visible = false;
            if (Session["CORPOFFICEID"] != null)
            {

                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            GuaranteModeLoad();
            txtName.Focus();
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId, intCorpId);
                lblEntry.Text = "Edit Guarantee Category";

            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId, intCorpId);

                lblEntry.Text = "View Guarantee Category";
            }
            else
            {
                lblEntry.Text = "Add Guarantee Category";

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;
              
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
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_Category_Master);
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


            }
            else
            {

                btnUpdate.Visible = false;

            }
            if (Request.QueryString["PRFG"] !=null)
            {
                btnClear.Visible = false;
                btnCancel.Visible = false;
                divList.Visible = false;
                btnClose.Visible = true;
                btnAdd.Visible = false;
                if (Request.QueryString["PRFG"].ToString() == "AWARDED")
                {
                    radioGuaranteMode.SelectedValue = "101";

                }
                else if (Request.QueryString["PRFG"].ToString() == "BIDDING")
                {
                    radioGuaranteMode.SelectedValue = "102";
                }
            }
        }
    }
    public void GuaranteModeLoad()
    {
        DataTable dtMode = new DataTable();
        dtMode = ObjBussinessGuarante.ReadGuaranteMode();
        if (dtMode.Rows.Count>0)
        {
        radioGuaranteMode.DataSource = dtMode;
        radioGuaranteMode.DataTextField = "GUARNTMODE_NAME";
        radioGuaranteMode.DataValueField = "GUARNTMODE_ID";
        radioGuaranteMode.DataBind();
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            classEntityLayerGuaranteType objEntityGuarType = new classEntityLayerGuaranteType();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityGuarType.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityGuarType.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityGuarType.Guar_Typ_Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityGuarType.Guar_Typ_Status = 0;
            }

            objEntityGuarType.GuaranteeMode =Convert.ToInt32(radioGuaranteMode.SelectedItem.Value);
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityGuarType.GuaranteeTypeId = Convert.ToInt32(strId);
            if (Session["USERID"] != null)
            {
                objEntityGuarType.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            objEntityGuarType.D_Date = System.DateTime.Now;
            objEntityGuarType.GuaranteTypename = txtName.Text.ToUpper().Trim();
            //Checking is there table have any name like this
            string strNameCount = ObjBussinessGuarante.CheckGuaranteTypeName(objEntityGuarType);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                ObjBussinessGuarante.UpdateGuaranteType(objEntityGuarType);
                if (clickedButton.ID == "btnUpdate")
                {
                    //REDIRECT TO UPDATE VIEW 
                    List<EL_Compzit.clsEntityQueryString> objEntityQueryStringList = new List<EL_Compzit.clsEntityQueryString>();
                    EL_Compzit.clsEntityCommon objEntityCommon = new EL_Compzit.clsEntityCommon();
                    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                    objEntityCommon.RedirectUrl = "gen_Guarantee_Type_Master.aspx";
                    EL_Compzit.clsEntityQueryString objEntityQueryString = new EL_Compzit.clsEntityQueryString();
                    objEntityQueryString.QueryString = "InsUpd";
                    objEntityQueryString.QueryStringValue = "Upd";
                    objEntityQueryString.Encrypt = 0;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    objEntityQueryString = new EL_Compzit.clsEntityQueryString();
                    objEntityQueryString.QueryString = "Id";
                    objEntityQueryString.QueryStringValue = strId;
                    objEntityQueryString.Encrypt = 1;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);
                    Response.Redirect(strRedirectUrl);

                   // Response.Redirect("gen_Guarantee_Type_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Guarantee_Type_Master_List.aspx?InsUpd=Upd");
                }

            }
            //If have
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtName.Focus();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        classEntityLayerGuaranteType objEntityGuarType = new classEntityLayerGuaranteType();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityGuarType.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityGuarType.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityGuarType.Guar_Typ_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityGuarType.Guar_Typ_Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityGuarType.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityGuarType.GuaranteeMode = Convert.ToInt32(radioGuaranteMode.SelectedItem.Value);
        objEntityGuarType.D_Date = System.DateTime.Now;

        objEntityGuarType.GuaranteTypename = txtName.Text.ToUpper().Trim();
        //Checking is there table have any name like this
        string strNameCount = ObjBussinessGuarante.CheckGuaranteTypeName(objEntityGuarType);
        //If there is no name like this on table.    
    
        
        if (strNameCount == "0")
        {
            string Gurt_CatgId = "";
          Gurt_CatgId= ObjBussinessGuarante.AddGuaranteType(objEntityGuarType);
            if (Request.QueryString["PRFG"] != null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedCategoryToRFG", "PassSavedCategoryToRFG(" + Gurt_CatgId + ");", true);
            }
            else
            {
                if (clickedButton.ID == "btnAdd")
                {
                    Response.Redirect("gen_Guarantee_Type_Master.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose")
                {
                    Response.Redirect("gen_Guarantee_Type_Master_List.aspx?InsUpd=Ins");
                }
            }

        }
        //If have
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtName.Focus();
        }
        
    }
    //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        classEntityLayerGuaranteType objEntityGuarType = new classEntityLayerGuaranteType();
        objEntityGuarType.GuaranteeTypeId = Convert.ToInt32(strP_Id);
        objEntityGuarType.CorpOffice_Id = intCorpId;
        DataTable dtGUarById = ObjBussinessGuarante.ReadGuaranteTypeById(objEntityGuarType);
        if (dtGUarById.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate
            txtName.Text = dtGUarById.Rows[0]["GUANTCAT_NAME"].ToString().Trim();
            int intComplaintStatus = Convert.ToInt32(dtGUarById.Rows[0]["GUANTCAT_STATUS"]);

            if (dtGUarById.Rows[0]["GUARNTMODE_ID"].ToString() != "" && dtGUarById.Rows[0]["GUARNTMODE_STATUS"].ToString() == "1")
            {
                radioGuaranteMode.Items.FindByValue(dtGUarById.Rows[0]["GUARNTMODE_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtGUarById.Rows[0]["GUARNTMODE_NAME"].ToString(), dtGUarById.Rows[0]["GUARNTMODE_ID"].ToString());
                radioGuaranteMode.Items.Insert(1, lstGrp);

                SortDDL(ref this.radioGuaranteMode);

                radioGuaranteMode.Items.FindByValue(dtGUarById.Rows[0]["GUARNTMODE_ID"].ToString()).Selected = true;
            }
         
            if (intComplaintStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
        txtName.Enabled = false;
        cbxStatus.Enabled = false;
        radioGuaranteMode.Enabled = false;
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        classEntityLayerGuaranteType objEntityGuarType = new classEntityLayerGuaranteType();
        objEntityGuarType.GuaranteeTypeId = Convert.ToInt32(strP_Id);
        objEntityGuarType.CorpOffice_Id = intCorpId;
        DataTable dtGUarById = ObjBussinessGuarante.ReadGuaranteTypeById(objEntityGuarType);
        if (dtGUarById.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate.
            txtName.Text = dtGUarById.Rows[0]["GUANTCAT_NAME"].ToString().Trim();
            int intComplaintStatus = Convert.ToInt32(dtGUarById.Rows[0]["GUANTCAT_STATUS"]);

            if (dtGUarById.Rows[0]["GUARNTMODE_ID"].ToString() != "" && dtGUarById.Rows[0]["GUARNTMODE_STATUS"].ToString() == "1")
            {
                radioGuaranteMode.Items.FindByValue(dtGUarById.Rows[0]["GUARNTMODE_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtGUarById.Rows[0]["GUARNTMODE_NAME"].ToString(), dtGUarById.Rows[0]["GUARNTMODE_ID"].ToString());
                radioGuaranteMode.Items.Insert(1, lstGrp);

                SortDDL(ref this.radioGuaranteMode);

                radioGuaranteMode.Items.FindByValue(dtGUarById.Rows[0]["GUARNTMODE_ID"].ToString()).Selected = true;
            }
            if (intComplaintStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
    }

    //for sorting drop down
    private void SortDDL(ref RadioButtonList objDDL)
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