using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using HashingUtility;
using System.Text;
using System.IO;
using System.Data;
using System.Web.UI.HtmlControls;
using CL_Compzit;

public partial class Master_gen_Corp_Division_gen_Corp_Div_MailSettings : System.Web.UI.Page
{

    clsCommonLibrary objCommon = new clsCommonLibrary();
    clsBusinessLayerCorpDivision objBLCorpDiv = new clsBusinessLayerCorpDivision();

    protected void Page_Load(object sender, EventArgs e)
    {

        txtEmail.Attributes.Add("onkeypress", "return isTag(event)");
        txtPassword.Attributes.Add("onkeypress", "return isTag(event)");
        txtConfirmPassword.Attributes.Add("onkeypress", "return isTag(event)");
        txtServiceName.Attributes.Add("onkeypress", "return isTag(event)");
        // If this page is loaded or redirected from any other location other than edit button and view button in the list of city is clicked.
        if (!IsPostBack)
        {
            txtEmail.Focus();            

            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);

            }
           
        }
    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //clsEntityCommon objEntityCommon = new clsEntityCommon();




        clsEntityCorpDivision objCorpDiv = new clsEntityCorpDivision();


        if (Session["USERID"] != null)
        {
            objCorpDiv.UpdateUsrId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objCorpDiv.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objCorpDiv.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        clsHash objHashing = new clsHash();
        if (hiddenMailId.Value != "")
            objCorpDiv.Mail_Settings_Id = Convert.ToInt32(hiddenMailId.Value);
        if (hiddenDivId.Value != "")
            objCorpDiv.DivisionId = Convert.ToInt32(hiddenDivId.Value);

        objCorpDiv.EmailId = txtEmail.Text;
        if (txtPassword.Text != null || txtPassword.Text != "")
        {
            string strPassWord = txtPassword.Text;

            clsHash objHash = new clsHash();
            strPassWord = objHash.GetHash(strPassWord, Convert.ToInt32(clsCommonLibrary.HashType.SHA256));

            objCorpDiv.Password = strPassWord;
        }
        objCorpDiv.Service_Name = txtServiceName.Text;
        Int64 intValue=0;
        if (Int64.TryParse(txtPort.Text.Trim(), out intValue))
        {
            objCorpDiv.Port_Number = Convert.ToInt64(txtPort.Text.Trim());
        }
        objCorpDiv.UpdUsrDate = System.DateTime.Now;

        objBLCorpDiv.Update_Mail_Console(objCorpDiv);

        ScriptManager.RegisterStartupScript(this, GetType(), "SucessfullUpdation", "SucessfullUpdation();", true);
    }


    public void Update(string strC_Id)
    {
        if (strC_Id != "")
        {
            

            clsEntityCorpDivision objCorpDiv = new clsEntityCorpDivision();

            objCorpDiv.DivisionId = Convert.ToInt32(strC_Id);
            hiddenDivId.Value = strC_Id;
            if (Session["USERID"] != null)
            {
                objCorpDiv.InsertUsrId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objCorpDiv.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objCorpDiv.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            DataTable dtMailSettings = objBLCorpDiv.Read_Mail_Console(objCorpDiv);
            if (dtMailSettings.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Close", "Close();", true);
            }
            else
            {
                txtEmail.Text = dtMailSettings.Rows[0]["MLCNFG_EMAIL"].ToString();
                txtServiceName.Text = dtMailSettings.Rows[0]["MLCNFG_SERVICE_NAME"].ToString();
                txtPort.Text = dtMailSettings.Rows[0]["MLCNFG_PORT_NUMBER"].ToString();

                hiddenMailId.Value = dtMailSettings.Rows[0]["MLCNFG_ID"].ToString();

                clsEncryptionDecryption objEncryDecry = new clsEncryptionDecryption();
                if (dtMailSettings.Rows[0]["MLCNFG_PASSWORD"] == DBNull.Value)
                {
                    
                }
                else
                {
                    HiddenPassword.Value = "1";
                    ScriptManager.RegisterStartupScript(this, GetType(), "HidePassWord", "HidePassWord();", true);
                }
                txtEmail.Focus();
            }
        }
    }


}