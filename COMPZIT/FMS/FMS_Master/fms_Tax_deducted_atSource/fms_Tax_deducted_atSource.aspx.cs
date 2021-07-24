using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Text;
using System.Web.Services;
using System.Collections;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit.BusineesLayer_FMS;
using System.Threading;


public partial class FMS_FMS_Master_fms_Tax_deducted_atSource_fms_Tax_deducted_atSource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int intFrmwrkId = 1;
        if (Session["FRMWRK_ID"] != null)
        {
            intFrmwrkId = Convert.ToInt32(Session["FRMWRK_ID"].ToString());
            //intFrmwrkId = 2;
        }
        if (intFrmwrkId == 1)
        {
            aHome.HRef = " /Home/Compzit_LandingPage/Compzit_LandingPage.aspx";
        }
        else
        {
            aHome.HRef = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
        }
        if (!IsPostBack)
        {
            txtName.Focus();
            HiddenView.Value = "0";
            HiddenFieldTaxId.Value = "";
         //   Hiddentxtefctvedate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            HiddenCurrentDate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            //txtFromdate
            HiddenChkSts.Value = "1";
            btnUpdate.Visible = false;
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

               // objEntity.UserId = intUserId;

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

              //  objEntity.CorpId = intCorpId;
                // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
              //  objEntity.OrgId = intOrgId;

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.TAX_DEDCTD_ATSRCE);
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
                        //HiddenRoleUpd.Value = "1";
                    }
              


                }
            }
       
      
            //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            lblEntry.Text = "Add Tax Deducted at Source";
            if (Request.QueryString["Id"] != null)
            {

                lblEntry.Text = "Edit Tax Deducted at Source";
                string status = "";

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenFieldTaxId.Value = strId;



              

                bttnsave.Visible = false;

                btnUpdate.Visible = true;

                //  btnClear.Visible = true;

                btnCancel.Visible = true;


               Update(strId);

            }
            else if (Request.QueryString["ViewId"] != null)
            {
                HiddenView.Value = "1";
                lblEntry.Text = "View Tax Deducted at Source";
                string status = "";
                //if (Request.QueryString["STS"] != null)
                //{
                //    status = Request.QueryString["STS"].ToString();
                //}

                spanFromdate.Attributes["style"] = "pointer-events:none;";
                spanTodate.Attributes["style"] = "pointer-events:none;";  
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenFieldTaxId.Value = strId;





                bttnsave.Visible = false;

                btnUpdate.Visible = false;

                //  btnClear.Visible = true;

                btnCancel.Visible = true;


                Update(strId);
                txtName.Enabled = false;
                txtperctg.Enabled = false;
                txtperctg.Enabled = false;
                txtTodate.Disabled = true;
                txtFromdate.Disabled = true;
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
            if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
              //  btnUpdate.Visible = false;
               // bttnUpdateCls.Visible = false;
            }

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdMsg", "SuccessUpdMsg();", true);
                }
                else if (strInsUpd == "UpdCancl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "CanclUpdMsg", "CanclUpdMsg();", true);
                }


            }


        }

    }



    public void Update(string strP_Id)
    {

        clsBL_Tax_CollectedAt_Source objEmpPerfomance = new clsBL_Tax_CollectedAt_Source();
        clsEntityLayer_Tax_CollectedAt_Source objEntity = new clsEntityLayer_Tax_CollectedAt_Source();
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
        objEntity.TaxId = Convert.ToInt32(strP_Id);

        DataTable dtList = objEmpPerfomance.ReadTaxDeductionById(objEntity);


        if (dtList.Rows.Count > 0)
        {


            txtName.Text = dtList.Rows[0]["TX_DDCTN_NAME"].ToString();
            txtperctg.Text = dtList.Rows[0]["TX_DDCTN_PRCNTG"].ToString();
            txtFromdate.Value = dtList.Rows[0]["TX_DDCTN_FRM_DATE"].ToString();
            txtTodate.Value = dtList.Rows[0]["TX_DDCTN_TO_DATE"].ToString();
            HiddenChkSts.Value = dtList.Rows[0]["TX_DDCTN_STS"].ToString();

            if (dtList.Rows[0]["TX_DDCTN_RSDNT_STS"].ToString() == "0")
            {
                radioNonResident.Checked=true;
                radioResident.Checked = false;
            }
            else
            {
                radioNonResident.Checked = false;
                radioResident.Checked = true;
            }
        
        }
     
       



    }
    protected void bttnsave_Click(object sender, EventArgs e)
    {


        Button clickedButton = sender as Button;
        clsBL_Tax_CollectedAt_Source objEmpPerfomance = new clsBL_Tax_CollectedAt_Source();
        clsEntityLayer_Tax_CollectedAt_Source objEntity = new clsEntityLayer_Tax_CollectedAt_Source();
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
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntity.Name = txtName.Text.Trim();
        objEntity.Percentage = Convert.ToDecimal(txtperctg.Text);
        objEntity.FromDate = objCommon.textToDateTime(txtFromdate.Value);
        objEntity.ToDate = objCommon.textToDateTime(txtTodate.Value);
        if (HiddenChkSts.Value == "1")
        {
            objEntity.Status = 1;
        }
        else
        {
            objEntity.Status = 0;
        }

        if (radioResident.Checked == true)
        {
            objEntity.Resident_sts = 1;

        }
        else if (radioNonResident.Checked == true)
        {
            objEntity.Resident_sts = 0;
        }





        objEmpPerfomance.InsertTaxDeducted(objEntity);
        if (clickedButton.ID == "bttnsave")
        {

            Response.Redirect("fms_Tax_deducted_atSource.aspx?InsUpd=Ins");
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBL_Tax_CollectedAt_Source objEmpPerfomance = new clsBL_Tax_CollectedAt_Source();
        clsEntityLayer_Tax_CollectedAt_Source objEntity = new clsEntityLayer_Tax_CollectedAt_Source();
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
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (HiddenFieldTaxId.Value!="")
        objEntity.TaxId = Convert.ToInt32(HiddenFieldTaxId.Value);
        objEntity.Name = txtName.Text.Trim();
        objEntity.Percentage = Convert.ToDecimal(txtperctg.Text);
        objEntity.FromDate = objCommon.textToDateTime(txtFromdate.Value);
        objEntity.ToDate = objCommon.textToDateTime(txtTodate.Value);
        if (HiddenChkSts.Value == "1")
        {
            objEntity.Status = 1;
        }
        else
        {
            objEntity.Status = 0;
        }

        if (radioResident.Checked == true)
        {
            objEntity.Resident_sts = 1;

        }
        else if (radioNonResident.Checked == true)
        {
            objEntity.Resident_sts = 0;
        }
        int flag = 0;
        DataTable dtList = objEmpPerfomance.ReadTaxDeductionById(objEntity);
        if (dtList.Rows.Count > 0)
        {
            if (dtList.Rows[0]["TX_DDCTN_CNCL_USR_ID"].ToString() != "")
            {
                flag++;
                Response.Redirect("fms_Tax_deducted_atSource.aspx?InsUpd=UpdCancl");
            }
        }

        if (flag == 0)
        {
            objEmpPerfomance.UpdateTaxDeducted(objEntity);
            if (clickedButton.ID == "btnUpdate")
            {
                Response.Redirect("fms_Tax_deducted_atSource.aspx?InsUpd=Upd&Id="+Request.QueryString["Id"].ToString());
            }
        }
       
    }

    [WebMethod]
    public static string DupChkForTaxName(string intTaxid, string intGrpname, string intuserid, string intorgid, string intcorpid)
    {
        string result = "true";

        
        clsBL_Tax_CollectedAt_Source objEmpPerfomance = new clsBL_Tax_CollectedAt_Source();
        clsEntityLayer_Tax_CollectedAt_Source objEntity = new clsEntityLayer_Tax_CollectedAt_Source();
        if (intTaxid != "")
        objEntity.TaxId = Convert.ToInt32(intTaxid);
        objEntity.Name = intGrpname;
        objEntity.User_Id = Convert.ToInt32(intuserid);
        objEntity.Organisation_id = Convert.ToInt32(intorgid);
        objEntity.Corporate_id = Convert.ToInt32(intcorpid);
      
        DataTable DtDup = objEmpPerfomance.DuplicationCheckTaxName(objEntity);
        if (DtDup.Rows.Count > 0)
        {
            int Intcount = Convert.ToInt32(DtDup.Rows[0]["GCOUNT"].ToString());
            if (Intcount > 0)
            {
                result = "false";
            }
        }
        return result;
    }
}