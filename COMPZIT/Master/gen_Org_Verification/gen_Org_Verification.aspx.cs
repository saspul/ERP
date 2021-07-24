using System;
using System.Data;
using EL_Compzit;
using BL_Compzit;
using MailUtility_ERP;
using System.Threading;
using System.Text;
using CL_Compzit;

// CREATED BY:EVM-0001
// CREATED DATE:22/02/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_Org_Verification_OrgVerification : System.Web.UI.Page
{
    ////Creating object for clsBusinessLayer Mail in in the BusinessLayer
    //clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();
    ////Creating object for clsMail  in in the MailUtility Layer
    //clsMail objMail = new clsMail();
    ////Create objects for businesslayer.
    //clsBusinesslayerOrgVerification objBusinessLayerOrgvef = new clsBusinesslayerOrgVerification();
    protected void Page_Load(object sender, EventArgs e)
    {
        divAppAdmin.Visible = false;

        txtVerification.Attributes.Add("onkeypress", "return isTag(event)");
        txtOrgMailID.Attributes.Add("onkeypress", "return isTag(event)");


        if (!IsPostBack)
        {


            txtVerification.Focus();
        }
        if (Session["USERID"] != null)
        {
            divAppAdmin.Visible = true;
            // If session user id is not null, then App Administrator can fetch Verification code by entering valid Email ID.
            txtOrgMailID.Focus();
        }
    }



    //When save button is pressed.
    protected void btnAdd_Click(object sender, EventArgs e)
    {  ////Creating object for clsBusinessLayer Mail in in the BusinessLayer
        clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();
        clsBusinesslayerOrgVerification objBusinessLayerOrgvef = new clsBusinesslayerOrgVerification();
        clsMail objMail = new clsMail();
        clsEntityLayerOrgVerification objEntOrgVef = new clsEntityLayerOrgVerification();
        objEntOrgVef.Verification_Code = txtVerification.Text;
        //passing verification code to businesslayer and acquire results.
        DataTable dtOrgVef = new DataTable();
        dtOrgVef = objBusinessLayerOrgvef.OrgVerification(objEntOrgVef);
        //database table have no current verification code that user enter
        if (dtOrgVef.Rows.Count == 0)
        {
            lblVerificationMsg.Visible = true;
            lblVerificationMsg.Text = "<center> Sorry, Verification Code you Entered is Incorrect. Try to Enter Exact Code that you Received in Mail! </br></br>" +
               " Or Verification for This Code may be Completed! </center>";
            lblVerificationMsg.ForeColor = System.Drawing.Color.Red;
            txtVerification.Focus();
        }
        //If table have verification code
        else
        {
            DataTable dtCompanyDetail = new DataTable();
            string StrCompanyName = "";
            dtCompanyDetail = objBusinessLayerMail.SelectCompanyDetails();
            if (dtCompanyDetail.Rows.Count > 0)
            {
                StrCompanyName = dtCompanyDetail.Rows[0]["CMPNY_NAME"].ToString();
            }

            DataTable dtTemplateDetail = new DataTable();
            clsBusinessLayer objBusines = new clsBusinessLayer();
            DataTable dtConfigDtl = new DataTable();

            dtConfigDtl = objBusines.LoadConfigDetail();
            string strTemplateId = "";
            string strPrdctName = "";
            // temp id for after verification submission
            //string strTemlpltIdAftr = "";
            if (dtConfigDtl.Rows.Count > 0)
            {
                strPrdctName = dtConfigDtl.Rows[0]["PRODUCT_NAME"].ToString();
                strTemplateId = dtConfigDtl.Rows[0]["DFLT_APP_EMTMPLT_ID"].ToString();
                //strTemlpltIdAftr = dtConfigDtl.Rows[0]["DFLT_AFTR_VRF_EMTMPLT_ID"].ToString();
            }
            string strVerificationCount = dtOrgVef.Rows[0]["ORG_PARK_ID"].ToString();
            objEntOrgVef.Organisation_Name = dtOrgVef.Rows[0]["ORG_PARK_NAME"].ToString();
            objEntOrgVef.Mobile_Number = dtOrgVef.Rows[0]["ORG_PARK_MOBILE"].ToString();
            objEntOrgVef.LicensePac_Name = dtOrgVef.Rows[0]["LIC_PACK_NAME"].ToString();
            objEntOrgVef.CorporatePack_Name = dtOrgVef.Rows[0]["CORP_PACK_NAME"].ToString();
            objEntOrgVef.Organisation_Id = dtOrgVef.Rows[0]["ORG_PARK_ID"].ToString();
            objEntOrgVef.Date_Verification = System.DateTime.Now;






            objMail.InstantMail(strTemplateId, ref dtTemplateDetail);
            //objMail.InstantMail(strTemlpltIdAftr, ref dtTemplateDetail);

            // save to registration table
            // save to message table
            //for status updation in parking table ('new' to 'approval prending') and to save to message table
            objBusinessLayerOrgvef.OrgStatusChange_Mail(objEntOrgVef, strTemplateId, dtCompanyDetail, dtTemplateDetail);



            lblVerificationMsg.Visible = true;
            lblVerificationMsg.Text = "</br><center> Congratulations " + dtOrgVef.Rows[0]["ORG_PARK_NAME"] + ". </br></br></br></br> You can Login to " + strPrdctName + "  after Approval from  " + StrCompanyName + ".</br></br></br></br> Thank You </center>";
            lblVerificationMsg.ForeColor = System.Drawing.Color.Green;
            divVerification.Visible = false;
            btnAdd.Visible = false;
            divAppAdmin.Visible = false;
            //for sending mail, avoid time delay we use threading
            //Thread threadMail = new Thread(new ThreadStart(Mail));
            //threadMail.Start();
            //Mail(objEntOrgVef, strTemplateId,

            Mail(objEntOrgVef, strTemplateId, dtCompanyDetail);

            ////mail after
            //Mail(objEntOrgVef, strTemlpltIdAftr, dtCompanyDetail);




            if (Session["USERID"] == null)
            {
                Session.Clear();
            }
        }
    }
    //Method for sending mail.
    public void Mail(clsEntityLayerOrgVerification objEntityOrgVef, string strTemplateId, DataTable dtCompanyDetail)
    {
        clsBusinessLayer objBusines = new clsBusinessLayer();

        clsMail objMail = new clsMail();


        // on success send mail
        objMail.BulkMail(strTemplateId, objEntityOrgVef.Organisation_Id, dtCompanyDetail, null, objEntityOrgVef);
        //   objMail.BulkMail();
    }

    protected void ibtnMail_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {

        //Creating object for clsMail  in in the MailUtility Layer
        clsMail objMail = new clsMail();

        clsEntityLayerLogin objEntLogin = new clsEntityLayerLogin();
        objEntLogin.UserEmail = txtOrgMailID.Text;

        //Creating objects for business layer login.
        clsBusinessLayerLogin objbusinessLayerLogin = new clsBusinessLayerLogin();
        DataTable dtOrgStatusNotify = new DataTable();
        dtOrgStatusNotify = objbusinessLayerLogin.CheckReSendMAil_Notify(objEntLogin);
        //to check if organisation present with given email id and find its detail
        if (dtOrgStatusNotify.Rows.Count > 0)
        {
            string OrgParkID = dtOrgStatusNotify.Rows[0]["ORG_PARK_ID"].ToString();

            string strOrgStatus = dtOrgStatusNotify.Rows[0]["ORG_PARK_STATUS_ID"].ToString();
            string strOrgName = dtOrgStatusNotify.Rows[0]["ORG_PARK_NAME"].ToString();
            string strOrgVerifyCode = dtOrgStatusNotify.Rows[0]["ORG_PARK_VERIFY_CODE"].ToString();
            //  string strOrgVerifyLink = "http://" + GetServerDetail() + "/Master/gen_Org_Verification/gen_Org_Verification.aspx";

            //if Status is NEW
            if (Convert.ToInt16(strOrgStatus) == Convert.ToInt16(clsCommonLibrary.Status.Status_New))
            {
                txtVerification.Text = strOrgVerifyCode;

            }



            //if Status is ApprovalPending
            else if (Convert.ToInt16(strOrgStatus) == Convert.ToInt16(clsCommonLibrary.Status.Status_ApprovalPending))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert(' Sorry, Cannot Fetch Verification Code. This is an Approval Pending Mail ID!')</script>");

                txtOrgMailID.Text = "";
            }
            //if Status is Approved
            else if (Convert.ToInt16(strOrgStatus) == Convert.ToInt16(clsCommonLibrary.Status.Status_Approved))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert(' Sorry, Cannot Fetch Verification Code. This Mail ID is Already Approved!')</script>");
                txtOrgMailID.Text = "";

            }
            //if Status is Rejected
            else if (Convert.ToInt16(strOrgStatus) == Convert.ToInt16(clsCommonLibrary.Status.Status_Rejected))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert(' Sorry, Cannot Fetch Verification Code. This Mail ID is Already Rejected!')</script>");
                txtOrgMailID.Text = "";

            }

        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert(' Sorry, This Email ID is not Registered!')</script>");
            txtOrgMailID.Text = "";
        }




    }
}