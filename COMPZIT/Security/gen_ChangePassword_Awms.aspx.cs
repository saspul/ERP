using BL_Compzit;
using CL_Compzit;
using EL_Compzit;
using HashingUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mail;
using System.Data;

public partial class Security_gen_ChangePassword_Awms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
        cbxPswdVisible.Attributes.Add("onkeypress", "return controlEnter('" + btnAdd.ClientID + "', event)");
 
        txtCurrentPassword.Attributes.Add("onkeypress", "return isTag(event)");
        txtConfirmPssword.Attributes.Add("onkeypress", "return isTag(event)");
        txtNewPassword.Attributes.Add("onkeypress", "return isTag(event)");

        if (!IsPostBack)         
        {

            txtCurrentPassword.Focus();
                btnAdd.Visible = true;
                txtConfirmPssword.Text = "";
                txtCurrentPassword.Text = "";
                txtNewPassword.Text = "";
                txtNewPassword.TextMode = TextBoxMode.Password;
                txtConfirmPssword.TextMode = TextBoxMode.Password;
                txtCurrentPassword.TextMode = TextBoxMode.Password;
                cbxPswdVisible.Checked = false;
              
                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    if (strInsUpd == "Ins")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                    }
                }

            
        }


    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        clsBusinessLayerChangePassword objBussinessChangePwd = new clsBusinessLayerChangePassword();
        clsEntityLayerUserRegistration objEntUser = new clsEntityLayerUserRegistration();

        if (Session["ORGID"] != null)
        {
            objEntUser.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {

            objEntUser.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        string strPwd = txtCurrentPassword.Text.Trim();
        clsHash objHashing = new clsHash();
        string strEncryptedPwd = objHashing.GetHash(strPwd, Convert.ToInt32(clsCommonLibrary.HashType.SHA256));
       
        objEntUser.UserOldPsw = strEncryptedPwd;

        objEntUser.UserDate = System.DateTime.Now;
        //it is calling a method in bussiness layer inorder to check if current password is true or not for the  logged in user if it return 0 then it is false
        int intCheckCountCurrentPwd = objBussinessChangePwd.CheckCurrentPasswd(objEntUser);
        //if 0 then entered password is wrong
        if (intCheckCountCurrentPwd == 0)
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "CurrentPasswordWrong", "CurrentPasswordWrong();", true);

        }
        else
        {
            strPwd = txtNewPassword.Text.Trim();
            string strEncryptedNewPwd = objHashing.GetHash(strPwd, Convert.ToInt32(clsCommonLibrary.HashType.SHA256));
            objEntUser.UserPsw = strEncryptedNewPwd;
            objBussinessChangePwd.UpdatePassword(objEntUser);
          //  Response.Redirect("~/Home/Compzit_Home/Compzit_Home_App.aspx");
            //0006 start
            if (Session["CORPOFFICEID"] != null)
            {
                objEntUser.UserCrprtId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
            clsBusinessLayer objBussinessLayer = new clsBusinessLayer();
            clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
            MailMessage mail = new MailMessage();
            DataTable dtFromMail = objBussinessLayer.ReadFromMailDetails(objEntUser);
            DataTable dtReadMailId = new DataTable();
            dtReadMailId = objBussinessChangePwd.ReadMailId(objEntUser);
            string strEmpname = "";
            string strEmailid = "";
            string strLoginname = "";
            if (dtReadMailId.Rows.Count > 0)
            {
                strEmpname = dtReadMailId.Rows[0]["USR_NAME"].ToString();
                strEmailid = dtReadMailId.Rows[0]["USR_EMAIL"].ToString();
                strLoginname = dtReadMailId.Rows[0]["LOGIN_NAME"].ToString();
            }
            string content = "\nHi " + strEmpname + ",\n\nThe Password for your Compzit Account: " + strEmailid + " / " + strLoginname + " was recently changed.\n\nYour New Password is : " + txtNewPassword.Text + "";
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }

    protected void cbxMakeVisible_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxPswdVisible.Checked == true)
        {
            txtConfirmPssword.TextMode = TextBoxMode.SingleLine;
            txtCurrentPassword.TextMode = TextBoxMode.SingleLine;
            txtNewPassword.TextMode = TextBoxMode.SingleLine;
        }
        else
        {
            string strConfirmPwd = txtConfirmPssword.Text;
            string strCurrentPwd = txtCurrentPassword.Text;
            string strNewPwd = txtNewPassword.Text;
            txtConfirmPssword.TextMode = TextBoxMode.Password;
            txtCurrentPassword.TextMode = TextBoxMode.Password;
            txtNewPassword.TextMode = TextBoxMode.Password;




            txtConfirmPssword.Attributes.Add("value", strConfirmPwd);
            txtCurrentPassword.Attributes.Add("value", strCurrentPwd);
            txtNewPassword.Attributes.Add("value", strNewPwd);
        }
        cbxPswdVisible.Focus();
    }
}