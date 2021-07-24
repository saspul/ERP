using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;
using CL_Compzit;
using BL_Compzit;
using EL_Compzit;
using System.Web.Services;
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;



public partial class HCM_Payroll_Structure_master_Payroll_Structure_Master : System.Web.UI.Page
{
    clsBusinessLayerPayroll objBusinessPayrl = new clsBusinessLayerPayroll();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityLayerPayroll objEntityPayrol = new clsEntityLayerPayroll();



            if (Session["USERID"] != null)
            {
                objEntityPayrol.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityPayrol.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityPayrol.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }


            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                btnUpdate.Visible = true;
                btnUpdateAndClose.Visible = true;
                btnSave.Visible = false;
                btnSaveAndClose.Visible = false;
                btnClear.Visible = false;
                lblEntry.InnerHtml = "Edit Payroll";
                UpdateView(strId);
            }


            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
                btnSave.Visible = false;
                btnSaveAndClose.Visible = false;
                btnClear.Visible = false;
                lblEntry.InnerHtml = "View Payroll";
                UpdateView(strId);
            }
            else
            {
                btnSave.Visible = true;
                btnSaveAndClose.Visible = true;
                btnUpdate.Visible = false;
                btnClear.Visible = true;
                btnUpdateAndClose.Visible = false;
                lblEntry.InnerHtml = "Add Payroll";
            }



            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsertion", "SuccessInsertion();", true);
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
    }

        

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
              clsCommonLibrary objCommon = new clsCommonLibrary();
                clsEntityLayerPayroll objEntityPayrol = new clsEntityLayerPayroll();

            Button clickedButton = sender as Button;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityPayrol.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityPayrol.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityPayrol.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }


            objEntityPayrol.Name = txtPyrlName.Text.ToUpper().Trim();


            string Count = objBusinessPayrl.FetchPayrollName(objEntityPayrol);

            objEntityPayrol.Code = txtcode.Text;


            string Count1 = "0";
            if (txtcode.Text.Trim() != "")
            {
                Count1 = objBusinessPayrl.FetchPayrollCode(objEntityPayrol);
            }
            if (Convert.ToInt32(Count) == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsg();", true);
               // txtPyrlName.BorderColor = System.Drawing.Color.Red;
               // txtPyrlName.Focus();


               // ScriptManager.RegisterStartupScript(this, GetType(), "Error", "Error();", true);
            }
            else if (Convert.ToInt32(Count1) == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsgC();", true);
                //txtcode.BorderColor = System.Drawing.Color.Red;
                //txtcode.Focus();
            }


            if (Convert.ToInt32(Count1) == 0 && Convert.ToInt32(Count) == 0)
            {
                objEntityPayrol.Mode = Convert.ToInt32(ddlmode.SelectedItem.Value);

                if (cbxStatus.Checked == true)
                {

                    objEntityPayrol.Status = 1;
                }
                else
                {

                    objEntityPayrol.Status = 0;

                }

                if (Radiofix.Checked == true)
                {

                    objEntityPayrol.PayrollType = 0;

                }
                else
                {


                    objEntityPayrol.PayrollType = 1;
                }


                if (cbxvisible.Checked == true)
                {
                    objEntityPayrol.DirectPaymentSts = 1;
                }
                else
                {
                    objEntityPayrol.DirectPaymentSts = 0;
                }

                if (cbxprimary.Checked == true)
                {
                    objEntityPayrol.PrimaryStatus = 1;
                }
                else
                {
                    objEntityPayrol.PrimaryStatus = 0;
                }

                objEntityPayrol.InsUser_Id = Convert.ToInt32(Session["USERID"].ToString());
                objEntityPayrol.InsDateTime = DateTime.Now;
                objBusinessPayrl.AddPayrolDetails(objEntityPayrol);


                if (clickedButton.ID == "btnSave")
                {
                    Response.Redirect("Payroll_Structure_Master.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnSaveAndClose")
                {
                    Response.Redirect("Payroll_Structure_list.aspx?InsUpd=Ins");
                }
            }


            else {


                if (Convert.ToInt32(Count) == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsg();", true);
                    // txtPyrlName.BorderColor = System.Drawing.Color.Red;
                    // txtPyrlName.Focus();


                   // ScriptManager.RegisterStartupScript(this, GetType(), "Error", "Error();", true);
                }
                else if (Convert.ToInt32(Count1) == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsgC();", true);
                    //txtcode.BorderColor = System.Drawing.Color.Red;
                    //txtcode.Focus();
                }
            
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Error", "Error();", true);
        }
    }

    public void UpdateView(string strId)
    {


        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerPayroll objEntityPayrol = new clsEntityLayerPayroll();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPayrol.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPayrol.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPayrol.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        int intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
        //Allocating child roles
        int intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Payroll_Structure);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(objEntityPayrol.User_Id, intUsrRolMstrId);

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
            }
        }

        objEntityPayrol.Payrl_ID = Convert.ToInt32(strId);

        DataTable dt = objBusinessPayrl.getDataById(objEntityPayrol);

        if (dt.Rows.Count > 0)
        {
            txtPyrlName.Text = dt.Rows[0]["NAME"].ToString();

            txtcode.Text=dt.Rows[0]["PAYRL_CODE"].ToString();



            ddlmode.SelectedValue = dt.Rows[0]["MODE"].ToString();

            int intStatus = Convert.ToInt32(dt.Rows[0]["ACTIVE"]);
            if (intStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            if (dt.Rows[0]["PAYRL_TYPE_STS"].ToString() != "")
            {

                string payrollTyp = dt.Rows[0]["PAYRL_TYPE_STS"].ToString();
                if (payrollTyp == "0")
                {
                    Radiofix.Checked = true;

                }
                else if (payrollTyp == "1")
                {
                    Radiovar.Checked = true;
                }
            }

            if (dt.Rows[0]["PAYRL_DIRECT_STS"].ToString() == "1")
            {
                cbxvisible.Checked = true;
            }
            else
            {
                cbxvisible.Checked = false;
            }


            if (dt.Rows[0]["PAYRL_PRIMARY_STS"].ToString() == "1")
            {

                cbxprimary.Checked = true;

            }
            else
            {
                cbxprimary.Checked = false;
            
            
            }
            if (Request.QueryString["ViewId"] != null || intEnableModify==0)
            {

                txtPyrlName.Enabled = false;
                txtcode.Enabled = false;
                Radiofix.Enabled = false;
                Radiovar.Enabled = false;
                ddlmode.Enabled = false;
                cbxvisible.Disabled = true;
                cbxprimary.Disabled = true;
                 cbxStatus.Disabled = true;
            }


        }

    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        try
        {
            Button clickedButton = sender as Button;

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityLayerPayroll objEntityPayrol = new clsEntityLayerPayroll();


            string strId = "";
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                strId = strRandomMixedId.Substring(2, intLenghtofId);
            }
            if (strId != "")
            {
                objEntityPayrol.Payrl_ID = Convert.ToInt32(strId);
            }


            int intCorpId = 0;
            int intUserId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityPayrol.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityPayrol.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityPayrol.User_Id = Convert.ToInt32(Session["USERID"]);
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityPayrol.UpdName = txtPyrlName.Text.ToUpper().Trim();
            objEntityPayrol.Name = txtPyrlName.Text.ToUpper().Trim();

            string Count = objBusinessPayrl.FetchPayrollName(objEntityPayrol);

            objEntityPayrol.Code = txtcode.Text;


            string Count1 = "0";
            if (txtcode.Text.Trim() != "")
            {
                Count1 = objBusinessPayrl.FetchPayrollCode(objEntityPayrol);
            }
            if (Convert.ToInt32(Count) == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsg();", true);
                // txtPyrlName.BorderColor = System.Drawing.Color.Red;
                // txtPyrlName.Focus();


                // ScriptManager.RegisterStartupScript(this, GetType(), "Error", "Error();", true);
            }
            else if (Convert.ToInt32(Count1) == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsgC();", true);
                //txtcode.BorderColor = System.Drawing.Color.Red;
                //txtcode.Focus();
            }


            if (Convert.ToInt32(Count1) == 0 && Convert.ToInt32(Count) == 0)
            {
                objEntityPayrol.Mode = Convert.ToInt32(ddlmode.SelectedItem.Value);

                if (cbxStatus.Checked == true)
                {

                    objEntityPayrol.Status = 1;
                }
                else
                {

                    objEntityPayrol.Status = 0;

                }

                if (Radiofix.Checked == true)
                {

                    objEntityPayrol.PayrollType = 0;

                }
                else
                {


                    objEntityPayrol.PayrollType = 1;
                }


                if (cbxvisible.Checked == true)
                {
                    objEntityPayrol.DirectPaymentSts = 1;
                }
                else
                {
                    objEntityPayrol.DirectPaymentSts = 0;
                }

                if (cbxprimary.Checked == true)
                {
                    objEntityPayrol.PrimaryStatus = 1;
                }
                else
                {
                    objEntityPayrol.PrimaryStatus = 0;
                }

                objEntityPayrol.InsUser_Id = Convert.ToInt32(Session["USERID"].ToString());
                objEntityPayrol.UpdDateTime = DateTime.Now;

                objBusinessPayrl.updatePayrol(objEntityPayrol);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("Payroll_Structure_Master.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateAndClose")
                {
                    Response.Redirect("Payroll_Structure_list.aspx?InsUpd=Upd");
                }
            }


            else
            {


                if (Convert.ToInt32(Count) == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsg();", true);
                    // txtPyrlName.BorderColor = System.Drawing.Color.Red;
                    // txtPyrlName.Focus();


                    // ScriptManager.RegisterStartupScript(this, GetType(), "Error", "Error();", true);
                }
                else if (Convert.ToInt32(Count1) == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsgC();", true);
                    //txtcode.BorderColor = System.Drawing.Color.Red;
                    //txtcode.Focus();
                }
            }
        }

        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Error", "Error();", true);
        }
    }
}