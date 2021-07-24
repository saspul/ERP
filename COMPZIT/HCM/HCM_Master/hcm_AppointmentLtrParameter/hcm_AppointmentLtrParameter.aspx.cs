using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using CL_Compzit;
using BL_Compzit;
using EL_Compzit;
using System.Data;
using System.Collections;

public partial class HCM_HCM_Master_hcm_AppointmentLtrParameter_hcm_AppointmentLtrParameter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCnsltyName.Focus();

            //NEW
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            //Creating objects for business layer
            clsEntityAppointmentLtrParameter objEntityConslt = new clsEntityAppointmentLtrParameter();
            clsBusinessLayerAppointmentLtrParameter objBusinessConslt = new clsBusinessLayerAppointmentLtrParameter();
            int intUserId = 0, intUsrRolMstrId = 0, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityConslt.UserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityConslt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityConslt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            //Allocating child roles

            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.AppointmentLetterParameter);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //future

                    }

                }
            }
            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdateClose.Visible = true;

            }
            else
            {

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = true;
            }
            //when editing 
            if (Request.QueryString["Id"] != null)
            {

                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId, intCorpId, intOrgId);
                lblEntry.Text = "Edit Appointment Letter Parameter";
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                txtCnsltyName.Focus();


            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {

                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                // HiddenViewId.Value = strId;
                Update(strId, intCorpId, intOrgId);

                //img1.Disabled = true;
                lblEntry.Text = "View Appointment Letter Parameter";
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                txtDescription.Enabled = false;



                cbStatus.Enabled = false;
                txtCnsltyName.Enabled = false;


            }
            else
            {
                lblEntry.Text = "Add Appointment Letter Parameter";

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
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
                    }
                    else if (strInsUpd == "Upd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                    }
                }
                txtCnsltyName.Focus();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityAppointmentLtrParameter objEntityConslt = new clsEntityAppointmentLtrParameter();
        clsBusinessLayerAppointmentLtrParameter objBusinessConslt = new clsBusinessLayerAppointmentLtrParameter();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityConslt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityConslt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityConslt.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityConslt.Head = txtCnsltyName.Text.Trim().ToUpper();
        objEntityConslt.Description = txtDescription.Text.Trim();




        if (cbStatus.Checked == true)
        {
            objEntityConslt.Status = 1;
        }
        else
        {
            objEntityConslt.Status = 0;

        }
       
        objEntityConslt.Date = DateTime.Now;



        string strNameCount = "";
        if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddClose")
        {
            strNameCount = objBusinessConslt.CheckDupApptLetterParameterName(objEntityConslt);
            if (strNameCount == "0")
            {
                objBusinessConslt.AddApptLetterParameterMstr(objEntityConslt);
                if (clickedButton.ID == "btnAdd")
                {

                    Response.Redirect("hcm_AppointmentLtrParameter.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose")
                {
                    Response.Redirect("hcm_AppointmentLtrParameterList.aspx?InsUpd=Ins");
                }
            }
            else
            {
                //duplicate err msg
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicateAppointmentLetter_ParameterName", "DuplicateAppointmentLetter_ParameterName();", true);
            }
        }
        else
        {
            if (HiddenConsultancyId.Value!="")
            {
                objEntityConslt.ApptLtrParameterId = Convert.ToInt32(HiddenConsultancyId.Value);
                
            }
            strNameCount = objBusinessConslt.CheckDupApptLetterParameterName(objEntityConslt);
            if (strNameCount == "0")
            {
                objBusinessConslt.UpdateApptLetterParameterMstr(objEntityConslt);
                if (clickedButton.ID == "btnUpdate")
                {

                    Response.Redirect("hcm_AppointmentLtrParameter.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("hcm_AppointmentLtrParameterList.aspx?InsUpd=Upd");
                }
            }
            else
            {
                //duplicate err msg
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicateAppointmentLetter_ParameterName", "DuplicateAppointmentLetter_ParameterName();", true);
            }
        }


    }
    public void Update(string strId, int intCorpId, int intOrgId)
    {
        clsEntityAppointmentLtrParameter objEntityConslt = new clsEntityAppointmentLtrParameter();
        clsBusinessLayerAppointmentLtrParameter objBusinessConslt = new clsBusinessLayerAppointmentLtrParameter();
        objEntityConslt.ApptLtrParameterId = Convert.ToInt32(strId);
        HiddenConsultancyId.Value = strId;
        objEntityConslt.CorpId = intCorpId;
        objEntityConslt.OrgId = intOrgId;
        DataTable dtConsltDetails = new DataTable();
        dtConsltDetails = objBusinessConslt.ReadApptLetterParameterByID(objEntityConslt);
        if (dtConsltDetails.Rows.Count > 0)
        {
            txtCnsltyName.Text = dtConsltDetails.Rows[0]["APPT_LTR_PARAM_HEAD"].ToString();
            txtDescription.Text = dtConsltDetails.Rows[0]["APPT_LTR_PARAM_DESCRIPTION"].ToString();

            //ie IF  Country IS ACTIVE


            if (dtConsltDetails.Rows[0]["APPT_LTR_PARAM_STATUS"].ToString() == "1")
            {
                cbStatus.Checked = true;
            }
            else
            {
                cbStatus.Checked = false;
            }

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