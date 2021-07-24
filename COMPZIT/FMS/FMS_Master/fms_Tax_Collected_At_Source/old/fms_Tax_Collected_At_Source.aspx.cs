using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit;
using BL_Compzit.BusinessLayer_FMS;
using CL_Compzit;
using System.Data;
public partial class FMS_fms_Tax_Collected_At_Source_fms_Tax_Collected_At_Source : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtName.Focus();
            clsBusinessLyer_Tax_CollectedAt_Source objEmpTCS = new clsBusinessLyer_Tax_CollectedAt_Source();
            clsEntityLayer_Tax_CollectedAt_Source objEntity = new clsEntityLayer_Tax_CollectedAt_Source();
        // Hiddentxtefctvedate.Value = DateTime.Now.ToString("dd-MM-yyyy");
        //HiddentxtefctveTodate.Value = DateTime.Now.ToString("dd-MM-yyyy");
          //  Hiddentxtefctvedate.Value ="";
          //  HiddentxtefctveTodate.Value = "";
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

                objEntity.User_Id = intUserId;

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                objEntity.Corporate_id = intCorpId;
                // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntity.Organisation_id = intOrgId;

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.TaxCollectedAtSource);
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
                //btnSaveCls.Visible = false;
                //bttnUpdate.Visible = false;

            }

            if (Request.QueryString["Id"] != null)
            {
                lblEntry.Text = "Edit Tax Collected at Source";
                bttnsave.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId);
            }
            else if (Request.QueryString["ViewId"] != null)
            {
                lblEntry.Text = "View Tax Collected at Source";
                bttnsave.Visible = false;
                btnUpdate.Visible=false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
              
                txtName.Enabled = false;
                txtCltvPercng.Enabled = false;
                txtDateFrom.Disabled = true;
                txtToDate.Disabled = true;
                Chksts.Disabled = true;
                typResident.Disabled = true;
                typeNonResident.Disabled = true;
                Update(strId);
            }
            else
            {
                lblEntry.Text = "Add Tax Collected at Source";
                btnUpdate.Visible = false;
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
            if (strInsUpd == "UpdCancl")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CanclUpdMsg", "CanclUpdMsg();", true);
            }
            
            
       
        }


    }
    public void Update(string strP_Id)
    {

        clsBusinessLyer_Tax_CollectedAt_Source objEmpTCS = new clsBusinessLyer_Tax_CollectedAt_Source();
        clsEntityLayer_Tax_CollectedAt_Source objEntity = new clsEntityLayer_Tax_CollectedAt_Source();
        //Hiddentxtefctvedate.Value = DateTime.Now.ToString("dd-MM-yyyy");
        //cphMain_HiddentxtefctveTodate.Value = DateTime.Now.ToString("dd-MM-yyyy");
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.User_Id = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.Corporate_id = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.Organisation_id = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntity.TcsId = Convert.ToInt32(strP_Id);



        DataTable dt = objEmpTCS.ReadTcsByIdByid(objEntity);
        if (dt.Rows.Count > 0)
        {


            txtName.Text = dt.Rows[0]["TX_CLTN_NAME"].ToString();
            txtCltvPercng.Text = dt.Rows[0]["TX_CLTN_PRCNTG"].ToString();
          
           txtDateFrom.Value = dt.Rows[0]["TX_CLTN_FRM_DATE"].ToString();
          txtToDate.Value = dt.Rows[0]["TX_CLTN_TO_DATE"].ToString();
            int residentsts = Convert.ToInt32(dt.Rows[0]["TX_CLTN_RSDNT_STS"].ToString());
            if (residentsts == 0)
            {
                typResident.Checked = true;
            }
            else
            {
                typeNonResident.Checked = true;
            }
            int STS = Convert.ToInt32(dt.Rows[0]["TX_CLTN_STS"].ToString());
            if (STS == 1)
            {
                Chksts.Checked = true;
            }
            else
            {
                Chksts.Checked = false;
            }

        
          
            //else
            //{ 


        }




    }
    protected void bttnsave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLyer_Tax_CollectedAt_Source objBusinessTCS = new clsBusinessLyer_Tax_CollectedAt_Source();
        clsEntityLayer_Tax_CollectedAt_Source objEntity = new clsEntityLayer_Tax_CollectedAt_Source();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.User_Id = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.Corporate_id = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.Organisation_id = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntity.Name = txtName.Text;
        objEntity.Percentage =Convert.ToDecimal(txtCltvPercng.Text);
        string dt = Hiddentxtefctvedate.Value;
        objEntity.FromDate = objCommon.textToDateTime(txtDateFrom.Value);
        objEntity.ToDate = objCommon.textToDateTime(txtToDate.Value);
        if (typResident.Checked == true)
        {
            objEntity.Resident_sts = 0;
        }
        else
        {
            objEntity.Resident_sts =1;
        }
        if (Chksts.Checked == true)
        {
            objEntity.Status = 1;
        }
        else
        {
            objEntity.Status = 0;
        }
        string strNameCount = "0";
        if (txtName.Text != "" && txtName.Text != null)
        {
             objEntity.Name = txtName.Text;
             strNameCount = objBusinessTCS.CheckTaxName(objEntity);

        }

        if (strNameCount == "0")
        {
            objBusinessTCS.InsertTaxCollectedAtSource(objEntity);
            if (clickedButton.ID == "bttnsave")
            {
                Response.Redirect("fms_Tax_Collected_At_Source.aspx?InsUpd=Ins");
            }
        }
        else
        {
            if (strNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

            }

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLyer_Tax_CollectedAt_Source objBusinessTCS = new clsBusinessLyer_Tax_CollectedAt_Source();
        clsEntityLayer_Tax_CollectedAt_Source objEntity = new clsEntityLayer_Tax_CollectedAt_Source();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.User_Id = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.Corporate_id = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.Organisation_id = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        string strRandomMixedId = Request.QueryString["Id"].ToString();
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntity.TcsId = Convert.ToInt32(strId);
        objEntity.Name = txtName.Text;
        objEntity.Percentage = Convert.ToDecimal(txtCltvPercng.Text);
        string dt = Hiddentxtefctvedate.Value;
        objEntity.FromDate = objCommon.textToDateTime(txtDateFrom.Value);
        objEntity.ToDate = objCommon.textToDateTime(txtToDate.Value);
        if (typResident.Checked == true)
        {
            objEntity.Resident_sts = 0;
        }
        else
        {
            objEntity.Resident_sts = 1;
        }
        if (Chksts.Checked == true)
        {
            objEntity.Status = 1;
        }
        else
        {
            objEntity.Status = 0;
        }
        string strNameCount = "0";
        if (txtName.Text != "" && txtName.Text != null)
        {
            objEntity.Name = txtName.Text;
            strNameCount = objBusinessTCS.CheckTaxName(objEntity);

        }



        DataTable dtCHKTCS = objBusinessTCS.ReadTcsByIdByid(objEntity);
        if (dtCHKTCS.Rows.Count > 0)
        {
            if (dtCHKTCS.Rows[0]["TX_CLTN_CNCL_USR_ID"].ToString() == "")
            {

                if (strNameCount == "0")
                {
                    objBusinessTCS.UpdateTaxCollectedAtSource(objEntity);
                    if (clickedButton.ID == "btnUpdate")
                    {
                        Response.Redirect("fms_Tax_Collected_At_Source.aspx?InsUpd=Upd");
                    }
                }
                else
                {
                    if (strNameCount != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

                    }

                }
            }
            else
            {
                Response.Redirect("fms_Tax_Collected_At_Source.aspx?InsUpd=UpdCancl");
            }
        }
    }
}