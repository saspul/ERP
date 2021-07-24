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
using EL_Compzit;
using BL_Compzit.BusinessLayer_GMS;
using EL_Compzit.EntityLayer_GMS;

public partial class GMS_GMS_Master_gen_Insurance_Type_Master_gen_Insurance_Type_Master : System.Web.UI.Page
{
    clsBusinessLayerInsuranceTypMaster ObjBussinessInsrncTyp = new clsBusinessLayerInsuranceTypMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtName.Attributes.Add("onkeypress", "return isTag(event)");
        txtName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
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
            if (Session["CORPOFFICEID"] != null)
            {

                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

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
                lblEntry.Text = "Edit Insurance Type";

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

                lblEntry.Text = "View Insurance Type";
            }
            else
            {
                lblEntry.Text = "Add Insurance Type";

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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Insurance_Type_Master);
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
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {

            clsEntityLayerInsuranceTypMaster objEntityInsrncTyp = new clsEntityLayerInsuranceTypMaster();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityInsrncTyp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityInsrncTyp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (cbxStatus.Checked == true)
            {
                objEntityInsrncTyp.InsrTypStatus = 1;
            }
            else
            {
                objEntityInsrncTyp.InsrTypStatus = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityInsrncTyp.InsrTypId = Convert.ToInt32(strId);
            if (Session["USERID"] != null)
            {
                objEntityInsrncTyp.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            objEntityInsrncTyp.D_Date = System.DateTime.Now;
            objEntityInsrncTyp.InsrTypname = txtName.Text.Trim();
            //Checking is there table have any name like this
            string strNameCount = ObjBussinessInsrncTyp.CheckInsuranceTypName(objEntityInsrncTyp);
            DataTable dtCheckCnclSts = ObjBussinessInsrncTyp.CheckInsrncTypCnclSts(objEntityInsrncTyp);

            if (dtCheckCnclSts.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CrossDeleted", "CrossDeleted();", true);
            }

            else if (strNameCount == "0")
            {
                ObjBussinessInsrncTyp.UpdateInsuranceTyp(objEntityInsrncTyp);

                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_Insurance_Type_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Insurance_Type_Master_List.aspx?InsUpd=Upd");
                }
            }
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
        clsEntityLayerInsuranceTypMaster objEntityInsrncTyp = new clsEntityLayerInsuranceTypMaster();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsrncTyp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsrncTyp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityInsrncTyp.InsrTypStatus = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityInsrncTyp.InsrTypStatus = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityInsrncTyp.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityInsrncTyp.D_Date = System.DateTime.Now;

        objEntityInsrncTyp.InsrTypname = txtName.Text.Trim();
        //Checking is there table have any name like this
        string strNameCount = ObjBussinessInsrncTyp.CheckInsuranceTypName(objEntityInsrncTyp);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            ObjBussinessInsrncTyp.AddInsuranceTyp(objEntityInsrncTyp);
            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Insurance_Type_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Insurance_Type_Master_List.aspx?InsUpd=Ins");
            }

        }
        //If have
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtName.Focus();
        }
    }

    public void View(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        clsEntityLayerInsuranceTypMaster objEntityInsrncTyp = new clsEntityLayerInsuranceTypMaster();
        objEntityInsrncTyp.InsrTypId = Convert.ToInt32(strP_Id);
        objEntityInsrncTyp.CorpOffice_Id = intCorpId;
        DataTable dtInsrTypId = ObjBussinessInsrncTyp.ReadInsuranceTypById(objEntityInsrncTyp);
        if (dtInsrTypId.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate
            txtName.Text = dtInsrTypId.Rows[0]["INSRC_TYPMSTR_NAME"].ToString().Trim();
            int intComplaintStatus = Convert.ToInt32(dtInsrTypId.Rows[0]["INSRC_TYPMSTR_STS"]);
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
    }

    public void Update(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        clsEntityLayerInsuranceTypMaster objEntityInsrncTyp = new clsEntityLayerInsuranceTypMaster();
        objEntityInsrncTyp.InsrTypId = Convert.ToInt32(strP_Id);
        objEntityInsrncTyp.CorpOffice_Id = intCorpId;
        DataTable dtComplaintById = ObjBussinessInsrncTyp.ReadInsuranceTypById(objEntityInsrncTyp);
        if (dtComplaintById.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate.
            txtName.Text = dtComplaintById.Rows[0]["INSRC_TYPMSTR_NAME"].ToString();
            int intInsrTypeStatus = Convert.ToInt32(dtComplaintById.Rows[0]["INSRC_TYPMSTR_STS"]);
            if (intInsrTypeStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
    }
}