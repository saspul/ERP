using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using BL_Compzit;
using HashingUtility;
using CL_Compzit;
using System.Data;
using System.Web.Mail;

public partial class MasterPage_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        txtNewPassword.Attributes.Add("onkeypress", "return controlTabEnter('" + txtConfirmPssword.ClientID + "', event)");
        txtNewPassword.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtConfirmPssword.Attributes.Add("onkeypress", "return controlTabEnter('" + btnReset.ClientID + "', event)");
        txtConfirmPssword.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtNewPassword.Attributes.Add("onkeypress", "return isTag(event)");
        txtConfirmPssword.Attributes.Add("onkeypress", "return isTag(event)");
        cbxPswdVisible.Attributes.Add("onkeypress", "return DisableEnter(event)");
       // cbxPswdVisible.Attributes.Add("onchange", "IncrmntConfrmCounter()");
       //lblEntry.Text = "Reset Password";

        
        if (!IsPostBack)
        {
            txtNewPassword.Focus();
            if (Request.QueryString["Id"] != null)
            {

                btnReset.Visible = true;
                txtConfirmPssword.Value = "";
                txtNewPassword.Value = "";
               

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                hiddenUserId.Value = strId;
                clsEntityResetPassword objEntityRest = new clsEntityResetPassword();
                objEntityRest.UserId = Convert.ToInt32(strId);
                 clsBusinesslayerResetPassword objBusinessResetPswd = new clsBusinesslayerResetPassword();
                DataTable dtRstNmMail = new DataTable();
                dtRstNmMail = objBusinessResetPswd.ReadEmployeeNameEmail(objEntityRest);
                divName.InnerHtml = dtRstNmMail.Rows[0]["USR_NAME"].ToString();
              
                divMail.InnerHtml = dtRstNmMail.Rows[0]["USR_EMAIL"].ToString();
                hiddenOldPassword.Value = dtRstNmMail.Rows[0]["USR_PWD"].ToString();
            }

        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clsEntityResetPassword objEntResetPasswrd = new clsEntityResetPassword();
        clsEntityLayerUserRegistration objEntUser = new clsEntityLayerUserRegistration();
        clsBusinesslayerResetPassword objBusinessResetPswd = new clsBusinesslayerResetPassword();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntResetPasswrd.CorpOfficeId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntResetPasswrd.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        string strPwd = txtNewPassword.Value.Trim();
        clsHash objHashing = new clsHash();
        string strEncryptedPwd = objHashing.GetHash(strPwd, Convert.ToInt32(clsCommonLibrary.HashType.SHA256));

        objEntResetPasswrd.UserPsw = strEncryptedPwd;

        if (hiddenUserId.Value == "")
        {
            Response.Redirect("gen_ResetPasswordList.aspx");

        }
        else
        {
            objEntResetPasswrd.UserId = Convert.ToInt32(hiddenUserId.Value);
            if (Session["USERID"] != null)
            {
                objEntResetPasswrd.PaswdTrackUsrId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else 
            {
                Response.Redirect("../../Default.aspx");
            }
            objEntResetPasswrd.Date = System.DateTime.Now;

            objEntResetPasswrd.UserOldPsw = hiddenOldPassword.Value;


         
            objBusinessResetPswd.UpdatePassword(objEntResetPasswrd);

            //Response.Redirect("gen_ResetPasswordList.aspx?InsUpd=Upd");
            //start 0006
          
             objEntUser.UserCrprtId = objEntResetPasswrd.CorpOfficeId;
            

            List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
            clsBusinessLayer objBussinessLayer = new clsBusinessLayer();
            clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
            MailMessage mail = new MailMessage();
            DataTable dtFromMail = objBussinessLayer.ReadFromMailDetails(objEntUser);
            DataTable dtUser = new DataTable();
            dtUser = objBusinessResetPswd.ReadEmployeeNameEmail(objEntResetPasswrd);
            string strEmpname = "";
            string strEmailid = "";
            string strLoginname = "";
            if (dtUser.Rows.Count > 0)
            {
                strEmpname = dtUser.Rows[0]["USR_NAME"].ToString();
                strEmailid = dtUser.Rows[0]["USR_EMAIL"].ToString();
                strLoginname = dtUser.Rows[0]["LOGIN_NAME"].ToString();
            }
            string content = "\nHi " + strEmpname + ",\n\nThe Password for your Compzit Account: " + strEmailid + " / " + strLoginname + " was recently changed.\n\nYour New Password is : " + txtNewPassword.Value + "";
            if (dtFromMail.Rows.Count > 0)
            {
                objEntityMail.To_Email_Address = strEmailid;
                objEntityMail.Email_Subject = "Your Password Changed";
                objEntityMail.Email_Content = content;
                objEntityMail.From_Email_Address = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();
                objEntityMail.Out_Service_Name = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
                objEntityMail.Out_Port_Number = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
                objEntityMail.SSL_Status = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
                objEntityMail.Password = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();
                objEntityMail.Signature = dtFromMail.Rows[0]["MLCNFG_SIGNATURE"].ToString();


                MailUtility_ERP.clsMail objMail = new MailUtility_ERP.clsMail();
                List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
                List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();
                try
                {
                    objMail.SendMail(objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);
                }
                catch
                {

                    Response.Redirect("~/Home/Compzit_Home/Compzit_Home_App.aspx");
                }
                Response.Redirect("~/Home/Compzit_Home/Compzit_Home_App.aspx");
            }
            else
            {
                Response.Redirect("~/Home/Compzit_Home/Compzit_Home_App.aspx");
            }
            //0006 stop 

        }
    }
}