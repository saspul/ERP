using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using System.Text;
using System.Collections;
using HashingUtility;
using OpenPop;
using MailUtility_ERP;

// CREATED BY:EVM-0002
// CREATED DATE:08/04/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_Mail_Console_gen_Mail_Console : System.Web.UI.Page
{
     //Creating objects for businesslayer
    clsBusinessLayerTaxMaster objBusinessLayerTaxMaster = new clsBusinessLayerTaxMaster();
    clsBusinessLayerMailConsole objBusinessLayerMailConsole = new clsBusinessLayerMailConsole();
    protected void Page_Load(object sender, EventArgs e)
    {                
        txtEmail.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmail.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtPassword.Attributes.Add("onkeypress", "return isTag(event)");
        //txtPassword.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtConfirmPassword.Attributes.Add("onkeypress", "return isTag(event)");
        //txtConfirmPassword.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtInServiceName.Attributes.Add("onkeypress", "return isTag(event)");
        txtInServiceName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtOutServerName.Attributes.Add("onkeypress", "return isTag(event)");
        txtOutServerName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtInPort.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtOutPort.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtSignature.Attributes.Add("onchange", "IncrmntConfrmCounter()");    
        cbxStatus.Attributes.Add("onchange", " IncrmntConfrmCounter()");
        cbxSecurity.Attributes.Add("onchange", " IncrmntConfrmCounter()");      
        ddlMailProtocol.Attributes.Add("onchange", " IncrmntConfrmCounter()");
        cbxChecking.Attributes.Add("onchange", " IncrmntConfrmCounter()");
        // If this page is loaded or redirected from any other location other than edit button and view button in the list of city is clicked.
        if (!IsPostBack)
        {
            txtEmail.Focus();
            //load mail protocols to the drop down list
            Mail_Protocol_Load();
            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;
            btnAdd.Visible = true;
            btnAddClose.Visible = true;
            btnUpdateF.Visible = false;
            btnUpdateCloseF.Visible = false;
            btnAddF.Visible = true;
            btnAddCloseF.Visible = true;
            lblEntry.InnerText = "Add Mail Settings";
            lblEntryB.InnerText = "Add Mail Settings";

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.InnerText = "Edit Mail Settings";
                lblEntryB.InnerText = "Edit Mail Settings";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.InnerText = "View Mail Settings";
                lblEntryB.InnerText = "View Mail Settings";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }

            else
            {
                lblEntry.InnerText = "Add Mail Settings";
                lblEntryB.InnerText = "Add Mail Settings";

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnUpdateF.Visible = false;
                btnUpdateCloseF.Visible = false;
                btnAddF.Visible = true;
                btnAddCloseF.Visible = true;
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



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();

        OpenPop.Pop3.Pop3Client objPop3 = new OpenPop.Pop3.Pop3Client();

        if (Session["USERID"] != null)
        {
            objEntityMail.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMail.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityMail.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityMail.Email_Address = txtEmail.Text;
      
        objEntityMail.In_Service_Name = txtInServiceName.Text;
        objEntityMail.Out_Service_Name = txtOutServerName.Text;

        string strSign = "\r\n\r\n";
        strSign = strSign + txtSignature.Value;
        objEntityMail.Signature = strSign;

        Int64 intValue = 0;
        if (Int64.TryParse(txtInPort.Text.Trim(), out intValue))
        {
            objEntityMail.In_Port_Number = Convert.ToInt64(txtInPort.Text.Trim());
        }
        if (Int64.TryParse(txtOutPort.Text.Trim(), out intValue))
        {
            objEntityMail.Out_Port_Number = Convert.ToInt64(txtOutPort.Text.Trim());
        }
        objEntityMail.D_Date = System.DateTime.Now;

        objEntityMail.Protocol_Id = Convert.ToInt32(ddlMailProtocol.SelectedItem.Value);

        if (cbxStatus.Checked == true)
        {
            objEntityMail.Console_Status = 1;
        }
        else
        {
            objEntityMail.Console_Status = 0;
        }

        if (cbxSecurity.Checked == true)
        {
            objEntityMail.SSL_Status = 1;
        }
        else
        {
            objEntityMail.SSL_Status = 0;
        }
        

        if (txtPassword.Text != null || txtPassword.Text != "")
        {
            string strPassWord = txtPassword.Text;
            
            clsEncryptionDecryption objEncrypt = new clsEncryptionDecryption();
            strPassWord = objEncrypt.Encrypt(strPassWord);

            objEntityMail.Password = strPassWord;
        }

        //checking the email already existed in the table or not
        string strCount = objBusinessLayerMailConsole.CheckEmailAddress(objEntityMail);

        // no duplication
        if (strCount == "0")
        {

            //checking connection with the server
            if (cbxChecking.Checked == true)
            {
                try
                {
                    objPop3.Connect(objEntityMail.In_Service_Name, Convert.ToInt32(objEntityMail.In_Port_Number), Convert.ToBoolean(objEntityMail.SSL_Status));
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "WrongInputServer", "WrongInputServer();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "HideLoading", "HideLoading();", true);
                    goto outer;
                }
            }
            if (cbxChecking.Checked == true)
            {
                try
                {
                    clsMail objMail = new clsMail();
                    objMail.CheckSmtpServer(objEntityMail.Out_Service_Name, Convert.ToInt32(objEntityMail.Out_Port_Number));                    
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "WrongOutputServer", "WrongOutputServer();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "HideLoading", "HideLoading();", true);
                    goto outer;
                }
            }
            if (cbxChecking.Checked == true)
            {
                try
                {
                    objPop3.Authenticate(objEntityMail.Email_Address, txtPassword.Text);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "WrongEmailPassword", "WrongEmailPassword();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "HideLoading", "HideLoading();", true);
                    goto outer;

                }
            }
            try
            {
                objBusinessLayerMailConsole.AddMailConsole(objEntityMail);
                if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
                {
                    Response.Redirect("gen_Mail_Console.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
                {
                    Response.Redirect("gen_Mail_ConsoleList.aspx?InsUpd=Ins");
                }
                
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "ErrorMsg();", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationEmail", "DuplicationEmail();", true);
            txtEmail.Focus();
        }
    outer: ;
        ScriptManager.RegisterStartupScript(this, GetType(), "HideLoading", "HideLoading();", true);
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {

            clsEntityMailConsole objEntityMail = new clsEntityMailConsole();

            OpenPop.Pop3.Pop3Client objPop3 = new OpenPop.Pop3.Pop3Client();

            clsMail objClsMail = new clsMail();

            if (Session["USERID"] != null)
            {
                objEntityMail.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityMail.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityMail.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityMail.Mail_Console_Id = Convert.ToInt32(strId);
            objEntityMail.Email_Address = txtEmail.Text;

            string strSign = "\r\n\r\n";
            strSign = strSign + txtSignature.Value;
            objEntityMail.Signature = strSign;
            

            objEntityMail.In_Service_Name = txtInServiceName.Text;
            objEntityMail.Out_Service_Name = txtOutServerName.Text;

            Int64 intValue = 0;
            if (Int64.TryParse(txtInPort.Text.Trim(), out intValue))
            {
                objEntityMail.In_Port_Number = Convert.ToInt64(txtInPort.Text.Trim());
            }
            if (Int64.TryParse(txtOutPort.Text.Trim(), out intValue))
            {
                objEntityMail.Out_Port_Number = Convert.ToInt64(txtOutPort.Text.Trim());
            }
            objEntityMail.D_Date = System.DateTime.Now;


            objEntityMail.Protocol_Id = Convert.ToInt32(ddlMailProtocol.SelectedItem.Value);

            if (cbxStatus.Checked == true)
            {
                objEntityMail.Console_Status = 1;
            }
            else
            {
                objEntityMail.Console_Status = 0;
            }

            if (cbxSecurity.Checked == true)
            {
                objEntityMail.SSL_Status = 1;
            }
            else
            {
                objEntityMail.SSL_Status = 0;
            }

            
            if (txtPassword.Text != null && txtPassword.Text != "")
            {
                string strPassWord = txtPassword.Text;

                clsHash objHash = new clsHash();
                clsEncryptionDecryption objEncrypt = new clsEncryptionDecryption();
                strPassWord = objEncrypt.Encrypt(strPassWord);                

                objEntityMail.Password = strPassWord;
            }

            //checking the email already existed in the table or not
            string strCount = objBusinessLayerMailConsole.CheckEmailAddress(objEntityMail);

            // no duplication
            if (strCount == "0")
            {

                //checking connection with server
                if (cbxChecking.Checked == true)
                {
                    try
                    {
                        objPop3.Connect(objEntityMail.In_Service_Name, Convert.ToInt32(objEntityMail.In_Port_Number), Convert.ToBoolean(objEntityMail.SSL_Status));
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "WrongInputServer", "WrongInputServer();", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "HideLoading", "HideLoading();", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "HidePassWord", "HidePassWord();", true);
                        goto outer;
                    }
                }
                if (cbxChecking.Checked == true)
                {
                    try
                    {
                        clsMail objMail = new clsMail();
                        objMail.CheckSmtpServer(objEntityMail.Out_Service_Name, Convert.ToInt32(objEntityMail.Out_Port_Number));                                                            
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "WrongOutputServer", "WrongOutputServer();", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "HideLoading", "HideLoading();", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "HidePassWord", "HidePassWord();", true);
                        goto outer;
                    }
                }
                if (cbxChecking.Checked == true)
                {
                    if (txtPassword.Text != null && txtPassword.Text != "")
                    {
                        try
                        {
                            objPop3.Authenticate(objEntityMail.Email_Address, txtPassword.Text);
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "WrongEmailPassword", "WrongEmailPassword();", true);
                            ScriptManager.RegisterStartupScript(this, GetType(), "HideLoading", "HideLoading();", true);
                            ScriptManager.RegisterStartupScript(this, GetType(), "HidePassWord", "HidePassWord();", true);
                            goto outer;

                        }
                    }
                }


                try
                {

                    DataTable dtComplaintDetail = objBusinessLayerMailConsole.ReadMailConsoleById(objEntityMail);
                     if (dtComplaintDetail.Rows.Count > 0)
                     {
                         if (dtComplaintDetail.Rows[0]["MLCNFG_CNCL_USR_ID"].ToString() == "" || dtComplaintDetail.Rows[0]["MLCNFG_CNCL_USR_ID"].ToString() == null)
                         {

                             if (txtPassword.Text == null || txtPassword.Text == "")
                                 objBusinessLayerMailConsole.UpdateMailConsoleWithOut(objEntityMail);
                             else
                                 objBusinessLayerMailConsole.UpdateMailConsole(objEntityMail);
                         }
                         else
                         {
                             Response.Redirect("gen_Mail_ConsoleList.aspx?InsUpd=AlCncl");
                         }
                     }
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "ErrorMsg();", true);
                }
                if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                {
                    Response.Redirect("gen_Mail_Console.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                {
                    Response.Redirect("gen_Mail_ConsoleList.aspx?InsUpd=Upd");
                }
                        
               
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "HidePassWord", "HidePassWord();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationEmail", "DuplicationEmail();", true);
                txtEmail.Focus();
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "HideLoading", "HideLoading();", true);
        outer: ;
            
        }
    }


    public void Update(string strC_Id)
    {
        if (strC_Id != "")
        {

            btnUpdate.Visible = true;
            btnUpdateClose.Visible = true;
            btnAdd.Visible = false;
            btnAddClose.Visible = false;

            btnUpdateF.Visible = true;
            btnUpdateCloseF.Visible = true;
            btnAddF.Visible = false;
            btnAddCloseF.Visible = false;
            clsEntityMailConsole objEntityMail = new clsEntityMailConsole();

            objEntityMail.Mail_Console_Id = Convert.ToInt32(strC_Id);
            hiddenDivId.Value = strC_Id;
            if (Session["USERID"] != null)
            {
                objEntityMail.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityMail.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityMail.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            DataTable dtMailSettings = objBusinessLayerMailConsole.ReadMailConsoleById(objEntityMail);

            txtEmail.Text = dtMailSettings.Rows[0]["MLCNFG_EMAIL"].ToString();
            txtInServiceName.Text = dtMailSettings.Rows[0]["MLCNFG_IN_SERVICE_NAME"].ToString();
            txtInPort.Text = dtMailSettings.Rows[0]["MLCNFG_IN_PORT_NUMBER"].ToString();
            txtOutServerName.Text = dtMailSettings.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
            txtOutPort.Text = dtMailSettings.Rows[0]["MLCNFG_OUT_PORT_NUMBER"].ToString();
            txtSignature.Value = dtMailSettings.Rows[0]["MLCNFG_SIGNATURE"].ToString();

            if (Convert.ToInt32(dtMailSettings.Rows[0]["MLCNFG_STATUS"]) == 1)
                cbxStatus.Checked = true;
            else
                cbxStatus.Checked = false;

            if (Convert.ToInt32(dtMailSettings.Rows[0]["MLCNFG_SSL_STATUS"]) == 1)
                cbxSecurity.Checked = true;
            else
                cbxSecurity.Checked = false;

            hiddenMailId.Value = dtMailSettings.Rows[0]["MLCNFG_ID"].ToString();

            if (dtMailSettings.Rows[0]["MLPRTCL_STATUS"].ToString() == "1")
            {
                ddlMailProtocol.Items.FindByText(dtMailSettings.Rows[0]["MLPRTCL_NAME"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstProductGroup = new ListItem(dtMailSettings.Rows[0]["MLPRTCL_NAME"].ToString(), dtMailSettings.Rows[0]["MLPRTCL_ID"].ToString());
                ddlMailProtocol.Items.Insert(1, lstProductGroup);
                SortDDL(ref this.ddlMailProtocol);
                ddlMailProtocol.Items.FindByText(dtMailSettings.Rows[0]["MLPRTCL_NAME"].ToString()).Selected = true;
            }

            HiddenPassword.Value = "1";
            ScriptManager.RegisterStartupScript(this, GetType(), "HidePassWord", "HidePassWord();", true);
            txtEmail.Focus();
        }
    }
    //Method for assigning mail protocol to the drop down list
    public void Mail_Protocol_Load()
    {

        DataTable dtProtocol = objBusinessLayerMailConsole.ReadMailProtocol();

        ddlMailProtocol.Items.Clear();

        ddlMailProtocol.DataSource = dtProtocol;

        ddlMailProtocol.DataTextField = "MLPRTCL_NAME";
        ddlMailProtocol.DataValueField = "MLPRTCL_ID";
        ddlMailProtocol.DataBind();

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

    //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strT_Id)
    {
        if (strT_Id != "")
        {

            btnUpdate.Visible = true;
            btnUpdateClose.Visible = true;
            btnAdd.Visible = false;
            btnAddClose.Visible = false;

            btnUpdateF.Visible = true;
            btnUpdateCloseF.Visible = true;
            btnAddF.Visible = false;
            btnAddCloseF.Visible = false;
            clsEntityMailConsole objEntityMail = new clsEntityMailConsole();

            objEntityMail.Mail_Console_Id = Convert.ToInt32(strT_Id);
            hiddenDivId.Value = strT_Id;
            if (Session["USERID"] != null)
            {
                objEntityMail.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityMail.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityMail.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            DataTable dtMailSettings = objBusinessLayerMailConsole.ReadMailConsoleById(objEntityMail);

            txtEmail.Text = dtMailSettings.Rows[0]["MLCNFG_EMAIL"].ToString();
            txtInServiceName.Text = dtMailSettings.Rows[0]["MLCNFG_IN_SERVICE_NAME"].ToString();
            txtInPort.Text = dtMailSettings.Rows[0]["MLCNFG_IN_PORT_NUMBER"].ToString();
            txtOutServerName.Text = dtMailSettings.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
            txtOutPort.Text = dtMailSettings.Rows[0]["MLCNFG_OUT_PORT_NUMBER"].ToString();
            txtSignature.Value = dtMailSettings.Rows[0]["MLCNFG_SIGNATURE"].ToString();


            if (Convert.ToInt32(dtMailSettings.Rows[0]["MLCNFG_STATUS"]) == 1)
                cbxStatus.Checked = true;
            else
                cbxStatus.Checked = false;

            if (Convert.ToInt32(dtMailSettings.Rows[0]["MLCNFG_SSL_STATUS"]) == 1)
                cbxSecurity.Checked = true;
            else
                cbxSecurity.Checked = false;

            hiddenMailId.Value = dtMailSettings.Rows[0]["MLCNFG_ID"].ToString();

            if (dtMailSettings.Rows[0]["MLPRTCL_STATUS"].ToString() == "1")
            {
                ddlMailProtocol.Items.FindByText(dtMailSettings.Rows[0]["MLPRTCL_NAME"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstProductGroup = new ListItem(dtMailSettings.Rows[0]["MLPRTCL_NAME"].ToString(), dtMailSettings.Rows[0]["MLPRTCL_ID"].ToString());
                ddlMailProtocol.Items.Insert(1, lstProductGroup);
                SortDDL(ref this.ddlMailProtocol);
                ddlMailProtocol.Items.FindByText(dtMailSettings.Rows[0]["MLPRTCL_NAME"].ToString()).Selected = true;
            }

            HiddenPassword.Value = "1";
            ScriptManager.RegisterStartupScript(this, GetType(), "HidePassWordAll", "HidePassWordAll();", true);
            txtEmail.Focus();

        }
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateCloseF.Visible = false;
        txtEmail.Enabled = false;
        ddlMailProtocol.Enabled=false;
        txtInServiceName.Enabled = false;
        txtInPort.Enabled = false;
        txtOutServerName.Enabled = false;
        txtOutPort.Enabled = false;
        cbxStatus.Disabled = true;
        cbxSecurity.Disabled = true;
        cbxChecking.Disabled = true;

    }
}