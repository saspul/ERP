using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using System.Text;
using System.IO;
using System.Data;
using System.Web.UI.HtmlControls;
using CL_Compzit;



public partial class MasterPage_Default : System.Web.UI.Page
{
    clsCommonLibrary objCommon = new clsCommonLibrary();
    clsBusinessLayerCorpDivision objBLCorpDiv = new clsBusinessLayerCorpDivision();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["USERID"] = 3;
        //Session["CORPID"] = 48;
        //Session["ORGID"] = 103;
        //Assigning  Key actions.
        //imgClearBtn.Visible = false;

        txtDivisionName.Attributes.Add("onkeypress", "return isTag(event)");
        txtDivisionName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtEmail.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmail.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtMailStoreEmail.Attributes.Add("onkeypress", "return isTag(event)");
        txtMailStoreEmail.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtDivCode.Attributes.Add("onkeypress", "return isTag(event)");
        txtDivCode.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxRemoveMails.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxRemoveMails.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        int intImageMaxSize = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SIZE.DIVISION_ICON);
        hiddenImageSize.Value = intImageMaxSize.ToString();
        // If this page is loaded or redirected from any other location other than edit button and view button in the list of city is clicked.
        if (!IsPostBack)
        {
            
            txtDivisionName.Focus();
            //if (Session["DSGN_TYPID"] != null)
            //{
            //    hiddenDsgnTypId.Value = Session["DSGN_TYPID"].ToString();
            //}
            //else
            //{
            //    Response.Redirect("~/Default.aspx");
            //}

            if (Request.QueryString["Id"] != null)
            {
                hiddenDivId.Value = Request.QueryString["Id"].ToString();
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.InnerText = "Edit Corporate Division";
                lblEntryB.InnerText = "Edit Corporate Division";
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
                lblEntry.InnerText = "View Corporate Division";
                lblEntryB.InnerText = "View Corporate Division";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }
            else
            {
                lblEntry.InnerText = "Add Corporate Division";
                lblEntryB.InnerText = "Add Corporate Division";
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
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();


     

        EL_Compzit.clsEntityCorpDivision objCorpDiv = null;
        objCorpDiv = new EL_Compzit.clsEntityCorpDivision();

       
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

        objCorpDiv.CorpDivisionName = txtDivisionName.Value.ToUpper().Trim();
        objCorpDiv.EmailId = txtEmail.Value;
        objCorpDiv.DivisionCode = txtDivCode.Value.ToUpper().Trim();
        objCorpDiv.Mail_Storage_Email = txtMailStoreEmail.Value;
        if (cbxRemoveMails.Checked == true)
        {
            objCorpDiv.Remove_Mail_Store = 1;
        }
        else
        {
            objCorpDiv.Remove_Mail_Store = 0;
        }


        string strDivisionCount = objBLCorpDiv.CheckDupDivNameUpdate(objCorpDiv);
        //string strDivEmailCount = objBLCorpDiv.CheckDupDivEmail(objCorpDiv);
        string strDivCodeCount = objBLCorpDiv.CheckDupDivCode(objCorpDiv);

        if (strDivisionCount == "0" &&  strDivCodeCount =="0")
        {
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CORP_DIVISION);
            objEntityCommon.CorporateID = objCorpDiv.CorpId;
            string strNextNum = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);

            objCorpDiv.DivisionId = Convert.ToInt32(strNextNum);

            if (FileUpload1.HasFile)
            {
                // GET FILE EXTENSION

                string strFileExt;

                strFileExt = FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.') + 1).ToLower();
                int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.CORP_DIVISION);
                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DIVISION_ICON);
                string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + objCorpDiv.DivisionId.ToString() + "." + strFileExt;
                objCorpDiv.DivisionIcon = strImageName;
                
            }

            else
            {
                objCorpDiv.DivisionIcon = null;
                //  lblMessage.Text = "Please select image file.";

            }

            

            if (cbxStatus.Checked == false)
            {
                objCorpDiv.DivStatus = 0;
            }
            else
            {
                objCorpDiv.DivStatus = 1;
            }

            //When CheckBox For Active is unChecked

            objBLCorpDiv.AddCorporateDivision(objCorpDiv);
            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DIVISION_ICON);
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath(strImagePath) + objCorpDiv.DivisionIcon);
            }
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_Corp_Division.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_Corp_DivisionList.aspx?InsUpd=Ins");
            }
                 
           
        }
        else
        {
            if (strDivCodeCount != "0")
            {
              
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
                txtDivCode.Focus();
            }
            //if (strDivEmailCount != "0")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationEmail", "DuplicationEmail();", true);
            //    txtEmail.Focus();
            //}
            if (strDivisionCount != "0")
            {
              
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtDivisionName.Focus();
            }

        }



    }


    public void Update(string strC_Id)
    {
        if (strC_Id != "")
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "ViewMailSettings", "ViewMailSettings();", true);

            EL_Compzit.clsEntityCorpDivision objCorpDiv = null;
            objCorpDiv = new EL_Compzit.clsEntityCorpDivision();
            objCorpDiv.DivisionId = Convert.ToInt32(strC_Id);
            DataTable dtEditCoprDiv = new DataTable();
            dtEditCoprDiv = objBLCorpDiv.EditViewCorpDiv(objCorpDiv);
            txtDivisionName.Value = dtEditCoprDiv.Rows[0]["CPRDIV_NAME"].ToString();
            txtEmail.Value = dtEditCoprDiv.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
            txtDivCode.Value = dtEditCoprDiv.Rows[0]["CPRDIV_CODE"].ToString();
            string filename = dtEditCoprDiv.Rows[0]["CPRDIV_ICON"].ToString();
            txtMailStoreEmail.Value = dtEditCoprDiv.Rows[0]["CPRDIV_STRG_MAIL"].ToString();
            if (dtEditCoprDiv.Rows[0]["CPRDIV_STGMAIL_REMV"].ToString() == "1")
            {
                cbxRemoveMails.Checked = true;
            }
            else
            {
                cbxRemoveMails.Checked = false;
            }

            HiddenDivImage.Value = dtEditCoprDiv.Rows[0]["CPRDIV_ICON"].ToString();
            hiddenImagePath.Value = dtEditCoprDiv.Rows[0]["CPRDIV_ICON"].ToString();
            if (HiddenDivImage.Value != null && HiddenDivImage.Value != "")
            {
                divImageEdit.Visible = true;
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DIVISION_ICON) + "/" + HiddenDivImage.Value;
                string strImage = "<a style=\"font-family: Calibri;font-size:13px;margin-left:1.5%\" href=\"#goofy\" >Click to View Image Uploaded</a>";
                 strImage += " <div class=\"lightbox-target\" id=\"goofy\">";
                strImage += " <img src=\"" + strImagePath + "\"/>";
                strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                strImage += "</div>";
                divImageDisplay.InnerHtml = strImage;

            }


            if (dtEditCoprDiv.Rows[0]["CPRDIV_STATUS"].ToString() == "1")
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            txtDivisionName.Disabled = false;
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnUpdate.Visible = true;
            btnUpdateClose.Visible = true;

            btnAddF.Visible = false;
            btnAddCloseF.Visible = false;
            btnUpdateF.Visible = true;
            btnUpdateCloseF.Visible = true;
        }
    }


    public void View(string strC_Id)
    {
        if (strC_Id != "")
        {
            EL_Compzit.clsEntityCorpDivision objCorpDiv = null;
            objCorpDiv = new EL_Compzit.clsEntityCorpDivision();
            objCorpDiv.DivisionId = Convert.ToInt32(strC_Id);
            DataTable dtEditCoprDiv = new DataTable();
            dtEditCoprDiv = objBLCorpDiv.EditViewCorpDiv(objCorpDiv);
            txtDivisionName.Value = dtEditCoprDiv.Rows[0]["CPRDIV_NAME"].ToString();
            txtEmail.Value = dtEditCoprDiv.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
            txtDivCode.Value = dtEditCoprDiv.Rows[0]["CPRDIV_CODE"].ToString();
            txtMailStoreEmail.Value = dtEditCoprDiv.Rows[0]["CPRDIV_STRG_MAIL"].ToString();
            if (dtEditCoprDiv.Rows[0]["CPRDIV_STGMAIL_REMV"].ToString() == "1")
            {
                cbxRemoveMails.Checked = true;
            }
            else
            {
                cbxRemoveMails.Checked = false;
            }

            HiddenDivImage.Value = dtEditCoprDiv.Rows[0]["CPRDIV_ICON"].ToString();
            
            if (HiddenDivImage.Value != null && HiddenDivImage.Value != "")
            {
                divImageEdit.Visible = true;
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DIVISION_ICON) + "/" + HiddenDivImage.Value;
                
                
                string strImage = "<a style=\"font-family: Calibri;font-size:13px;margin-left:3.5%\" href=\"#goofy\" >Click to View Image Uploaded</a>";
                strImage += " <div class=\"lightbox-target\" id=\"goofy\">";
                strImage += " <img src=\"" + strImagePath + "\"/>";
                strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                strImage += "</div>";
                divImageDisplay.InnerHtml = strImage;
            }





            if (dtEditCoprDiv.Rows[0]["CPRDIV_STATUS"].ToString() == "1")
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            txtDivisionName.Disabled = true;
            txtDivCode.Disabled = true;
            txtEmail.Disabled = true;
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;
            FileUpload1.Visible = false;
            cbxStatus.Disabled = true;
            imgClear.Visible = false;
            txtMailStoreEmail.Disabled = true;
            cbxRemoveMails.Disabled = true;
            btnAddF.Visible = false;
            btnAddCloseF.Visible = false;
            btnUpdateF.Visible = false;
            btnUpdateCloseF.Visible = false;
        }
    }






    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            EL_Compzit.clsEntityCorpDivision objCorpDiv = null;
            objCorpDiv = new EL_Compzit.clsEntityCorpDivision();
            objCorpDiv.DivStatus = 1;
            if (cbxStatus.Checked == false)
            {
                objCorpDiv.DivStatus = 0;
            }
            objCorpDiv.CorpDivisionName = txtDivisionName.Value.ToUpper().Trim();
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objCorpDiv.DivisionId = Convert.ToInt32(strId);
            objCorpDiv.EmailId = txtEmail.Value.Trim();
            objCorpDiv.DivisionCode = txtDivCode.Value.ToUpper().Trim();
            objCorpDiv.Mail_Storage_Email = txtMailStoreEmail.Value;
            if (cbxRemoveMails.Checked == true)
            {
                objCorpDiv.Remove_Mail_Store = 1;
            }
            else
            {
                objCorpDiv.Remove_Mail_Store = 0;
            }
            if (FileUpload1.HasFile)
            {
                // GET FILE EXTENSION
                


                string strFileExt;
                strFileExt = FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.') + 1).ToLower();
                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DIVISION_ICON);
                int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.CORP_DIVISION);
                string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + objCorpDiv.DivisionId.ToString() + "." + strFileExt;
                objCorpDiv.DivisionIcon = strImageName;

                if (HiddenDivImage.Value != "")
                {
                    string imglocation = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DIVISION_ICON);
                    string strImagePath = imglocation + hiddenImagePath.Value;

                    if (File.Exists(MapPath(strImagePath)))
                    {
                        File.Delete(MapPath(strImagePath));
                    }
                }
                
            }

            else
            {
                if (HiddenDivImage.Value != "")
                {
                    objCorpDiv.DivisionIcon = HiddenDivImage.Value;
                }
                else
                {
                    string imglocation = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DIVISION_ICON);
                    string strImagePath = imglocation + hiddenImagePath.Value;
                   
                    objCorpDiv.DivisionIcon = null;
                    if(File.Exists(MapPath(strImagePath)))
                    {
                    File.Delete(MapPath(strImagePath));
                    }
                    //  lblMessage.Text = "Please select image file.";
                }
            }

           
            if (Session["USERID"] != null)
            {
                objCorpDiv.UpdateUsrId = Convert.ToInt32(Session["USERID"]);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objCorpDiv.UpdUsrDate = System.DateTime.Now;
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

            string strDivisionCount = objBLCorpDiv.CheckDupDivNameUpdate(objCorpDiv);
            //string strDivEmailCount = objBLCorpDiv.CheckDupDivEmail(objCorpDiv);
            string strDivCodeCount = objBLCorpDiv.CheckDupDivCode(objCorpDiv);

            if (strDivisionCount == "0" && strDivCodeCount == "0")
            {
                objBLCorpDiv.UpdateCorpDivision(objCorpDiv);

                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DIVISION_ICON);
                if (FileUpload1.HasFile)
                {
                    FileUpload1.SaveAs(Server.MapPath(strImagePath) + objCorpDiv.DivisionIcon);
                }
                if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                {
                    Response.Redirect("gen_Corp_Division.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                {
                    Response.Redirect("gen_Corp_DivisionList.aspx?InsUpd=Upd");
                }
              

            }
            else
            {
                if (strDivCodeCount != "0")
                {
                
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
                    txtDivCode.Focus();
                }
                //if (strDivEmailCount != "0")
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationEmail", "DuplicationEmail();", true);
                //    txtEmail.Focus();
                //}
                if (strDivisionCount != "0")
                {
                 
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                    txtDivisionName.Focus();
                }
            }
        }
    }

    //protected void FileUpload1_Load(object sender, EventArgs e)
    //{
    //    HttpPostedFile file = (HttpPostedFile)(FileUpload1.PostedFile);
    //    int intFileSize = file.ContentLength;
    //    if (intFileSize > 1000000)
    //    {
    //        Response.Write("hahahaha");
    //    }
    //}
    

}