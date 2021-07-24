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
public partial class FMS_FMS_Master_fms_Cheque_Template_fms_Cheque_Template : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            txtName.Focus();
            HiddenView.Value = "0";
            HiddenFieldTaxId.Value = "";
            HiddenCurrentDate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            HiddenChkSts.Value = "1";
            btnUpdate.Visible = false;
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Cheque_Template);
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
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }
            lblEntry.Text = "Add Cheque Template";
            if (Request.QueryString["Id"] != null)
            {
               
                lblEntry.Text = "Edit Cheque Template";
                string status = "";
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenFieldTaxId.Value = strId;
                bttnsave.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
                Update(strId);
            }
            else if (Request.QueryString["ViewId"] != null)
            {
                HiddenView.Value = "1";
                lblEntry.Text = "View Cheque Template";
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenFieldTaxId.Value = strId;
                bttnsave.Visible = false;
                btnUpdate.Visible = false;
                btnCancel.Visible = true;
                Update(strId);
                txtName.Enabled = false;
                TextBox1.Enabled = false;
                TextBox2.Enabled = false;
                TextBox3.Enabled = false;
                TextBox4.Enabled = false;
                TextBox5.Enabled = false;
            }
            if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
                bttnsave.Visible = false;
            }
            if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
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
        clsBusiness_Cheque_template objEmpPerfomance = new clsBusiness_Cheque_template();
        clsEntityChequeTemplate objEntity = new clsEntityChequeTemplate();
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
        objEntity.ChequeTemplateId = Convert.ToInt32(strP_Id);
        DataTable dtList = objEmpPerfomance.ReadTemplateById(objEntity);
        if (dtList.Rows.Count > 0)
        {

            txtName.Text = dtList.Rows[0]["CHKTEMPLT_NAME"].ToString();
            divImageDisplay1.InnerText = dtList.Rows[0]["CHKTEMPLT_FILE_NAME"].ToString();
            divImageDisplay12.InnerText = dtList.Rows[0]["CHKTEMPLT_ACT_FILE_NAME"].ToString();
            Label5.Text = dtList.Rows[0]["CHKTEMPLT_ACT_FILE_NAME"].ToString();
            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CHEQUE_TEMPLATE) + dtList.Rows[0]["CHKTEMPLT_FILE_NAME"].ToString();
            divImgPreview.Style["background-image"] = strImagePath;
            //divImgPreview.Attributes
            divImgPreview.Attributes.Add("class", "chq_im_res"); 
          //  class="chq_im_res"
            divImgPreview.Style.Add("width", dtList.Rows[0]["CHKTEMPLT_WIDTH"].ToString() + "px");
            divImgPreview.Style.Add("height", dtList.Rows[0]["CHKTEMPLT_HEIGHT"].ToString() + "px");

            HiddenFieldRelativeTop.Value = dtList.Rows[0]["CHKTEMPLT_TOPS"].ToString();

            string[] arr = dtList.Rows[0]["CHKTEMPLT_TOPS"].ToString().Split(',');
            string[] arrf = dtList.Rows[0]["CHKTEMPLT_TOPS_F"].ToString().Split(',');


            lblPayeeLeft.Value = dtList.Rows[0]["CHKTEMPLT_PAYEE_LEFT"].ToString();
          //  lblPayeeTop.Value = Convert.ToString(Convert.ToDecimal(arrf[0])-Convert.ToDecimal(arr[0])); //dtList.Rows[0]["CHKTEMPLT_PAYEE_TOP"].ToString();
            lblPayeeTop.Value = dtList.Rows[0]["CHKTEMPLT_PAYEE_TOP"].ToString();
            //lblPayeeTop.Value = "125";
            lblDateLeft.Value = dtList.Rows[0]["CHKTEMPLT_DATE_LEFT"].ToString();
           // lblDateTop.Value = Convert.ToString(Convert.ToDecimal(arrf[1]) - Convert.ToDecimal(arr[1])); ;//dtList.Rows[0]["CHKTEMPLT_DATE_TOP"].ToString();
            lblDateTop.Value = dtList.Rows[0]["CHKTEMPLT_DATE_TOP"].ToString();
            lblAmntWordLeft.Value = dtList.Rows[0]["CHKTEMPLT_AMNTWORD1_LEFT"].ToString();
          //  lblAmntWordTop.Value = Convert.ToString(Convert.ToDecimal(arrf[2]) - Convert.ToDecimal(arr[2])); //dtList.Rows[0]["CHKTEMPLT_AMNTWORD1_TOP"].ToString();
            lblAmntWordTop.Value = dtList.Rows[0]["CHKTEMPLT_AMNTWORD1_TOP"].ToString();
            lblAmntWordLeft1.Value = dtList.Rows[0]["CHKTEMPLT_AMNTWORD2_LEFT"].ToString();
           // lblAmntWordTop1.Value = Convert.ToString(Convert.ToDecimal(arrf[4]) - Convert.ToDecimal(arr[4])); ;//dtList.Rows[0]["CHKTEMPLT_AMNTWORD2_TOP"].ToString();
            lblAmntWordTop1.Value = dtList.Rows[0]["CHKTEMPLT_AMNTWORD2_TOP"].ToString();
          //  lblAmntNumTop.Value = Convert.ToString(Convert.ToDecimal(arrf[3]) - Convert.ToDecimal(arr[3])); ;//dtList.Rows[0]["CHKTEMPLT_AMNTNUM_TOP"].ToString();
            lblAmntNumTop.Value = dtList.Rows[0]["CHKTEMPLT_AMNTNUM_TOP"].ToString();
            lblAmntNumLeft.Value = dtList.Rows[0]["CHKTEMPLT_AMNTNUM_LEFT"].ToString();

            if (dtList.Rows[0]["CHKTEMPLT_PAYEE_NAME"].ToString() != "")
            {
                TextBox1.Text = dtList.Rows[0]["CHKTEMPLT_PAYEE_NAME"].ToString();
            }
            if (dtList.Rows[0]["CHKTEMPLT_DATE"].ToString() != "")
            {
                TextBox2.Text = dtList.Rows[0]["CHKTEMPLT_DATE"].ToString();
            }
            if (dtList.Rows[0]["CHKTEMPLT_AMT_WORD_ONE"].ToString() != "")
            {
                TextBox3.Text = dtList.Rows[0]["CHKTEMPLT_AMT_WORD_ONE"].ToString();
            }
            if (dtList.Rows[0]["CHKTEMPLT_AMT_WORD_TWO"].ToString() != "")
            {
                TextBox5.Text = dtList.Rows[0]["CHKTEMPLT_AMT_WORD_TWO"].ToString();
            }
            if (dtList.Rows[0]["CHKTEMPLT_AMT_NUM"].ToString() != "")
            {
                TextBox4.Text = dtList.Rows[0]["CHKTEMPLT_AMT_NUM"].ToString();
            }
            ddlPosition.SelectedValue = dtList.Rows[0]["CHKTEMPLT_PRINT_POS"].ToString();
        
        }
    }
    protected void bttnsave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusiness_Cheque_template objEmpPerfomance = new clsBusiness_Cheque_template();
        clsEntityChequeTemplate objEntity = new clsEntityChequeTemplate();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
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
        objEntity.Name = txtName.Text.Trim();
        objEntity.PrintPosition = Convert.ToInt32(ddlPosition.SelectedItem.Value);
        int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CHEQUE_TEMPLATE);
        string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CHEQUE_TEMPLATE);
        if (FileUploadRecharge.HasFile)
        {
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CHEQUE_TEMPLATE);
            objEntityCommon.CorporateID = objEntity.Corporate_id;
            objEntityCommon.Organisation_Id = objEntity.Organisation_id;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
           
            string strFileExt;
            strFileExt = FileUploadRecharge.FileName.Substring(FileUploadRecharge.FileName.LastIndexOf('.') + 1).ToLower();
            string strImageName = intImageSection.ToString() + "_" + strNextId + "." + strFileExt;
            objEntity.FileName = strImageName;
            objEntity.ActFileName = FileUploadRecharge.FileName;
            FileUploadRecharge.SaveAs(Server.MapPath(strImgPath) + strImageName);
        }
        objEntity.Width = Convert.ToDecimal(lblWidth.Value);
        objEntity.Height = Convert.ToDecimal(lblHeight.Value);
        objEntity.PayeeLeft = Convert.ToDecimal(lblPayeeLeft.Value);
        objEntity.PayeeTop = Convert.ToDecimal(lblPayeeTop.Value);
        objEntity.DateLeft = Convert.ToDecimal(lblDateLeft.Value);
        objEntity.DateTop = Convert.ToDecimal(lblDateTop.Value);
        objEntity.AmntWord1Left = Convert.ToDecimal(lblAmntWordLeft.Value);
        objEntity.AmntWord1Top = Convert.ToDecimal(lblAmntWordTop.Value);
        objEntity.AmntWord2Left = Convert.ToDecimal(lblAmntWordLeft1.Value);
        objEntity.AmntWord2Top = Convert.ToDecimal(lblAmntWordTop1.Value);
        objEntity.AmntNumTop = Convert.ToDecimal(lblAmntNumTop.Value);
        objEntity.AmntNumLeft = Convert.ToDecimal(lblAmntNumLeft.Value);
        objEntity.CancelReason = HiddenFieldRelativeTop.Value;
        objEntity.FinalTops = HiddenFieldRelativeTopFinal.Value;

        if (TextBox1.Text.Trim() != "")
        {
            objEntity.PayeeName = TextBox1.Text.Trim();
        }
        if (TextBox2.Text.Trim() != "")
        {
            objEntity.PaymentDate = TextBox2.Text.Trim();
        }
        if (TextBox3.Text.Trim() != "")
        {
            objEntity.Amunt_word_one = TextBox3.Text.Trim();
        }
        if (TextBox5.Text.Trim() != "")
        {
            objEntity.Amunt_word_two = TextBox5.Text.Trim();
        }
        if (TextBox4.Text.Trim() != "")
        {
            objEntity.AmntNum = Convert.ToDecimal(TextBox4.Text.Trim());
        }
        //EVM-0027 Aug 29
        if (txtWord1Count.Value.Trim() != "")
        {
            objEntity.WordOneLength = Convert.ToInt32(txtWord1Count.Value.Trim());
        }
        objEmpPerfomance.InsertChequeTemplte(objEntity);
        if (clickedButton.ID == "bttnsave")
        {
            Response.Redirect("fms_Cheque_Template.aspx?InsUpd=Ins");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusiness_Cheque_template objEmpPerfomance = new clsBusiness_Cheque_template();
        clsEntityChequeTemplate objEntity = new clsEntityChequeTemplate();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
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
        objEntity.Name = txtName.Text.Trim();
        objEntity.PrintPosition = Convert.ToInt32(ddlPosition.SelectedItem.Value);
        int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CHEQUE_TEMPLATE);
        string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CHEQUE_TEMPLATE);
        if (FileUploadRecharge.HasFile)
        {
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CHEQUE_TEMPLATE);
            objEntityCommon.CorporateID = objEntity.Corporate_id;
            objEntityCommon.Organisation_Id = objEntity.Organisation_id;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);

            string strFileExt;
            strFileExt = FileUploadRecharge.FileName.Substring(FileUploadRecharge.FileName.LastIndexOf('.') + 1).ToLower();
            string strImageName = intImageSection.ToString() + "_" + strNextId + "." + strFileExt;
            objEntity.FileName = strImageName;
            objEntity.ActFileName = FileUploadRecharge.FileName;
            FileUploadRecharge.SaveAs(Server.MapPath(strImgPath) + strImageName);
        }
        else
        {
            objEntity.FileName = divImageDisplay1.InnerText;
            objEntity.ActFileName = divImageDisplay12.InnerText;
        }
        objEntity.Width = Convert.ToDecimal(lblWidth.Value);
        objEntity.Height = Convert.ToDecimal(lblHeight.Value);
        objEntity.PayeeLeft = Convert.ToDecimal(lblPayeeLeft.Value);
        objEntity.PayeeTop = Convert.ToDecimal(lblPayeeTop.Value);
        objEntity.DateLeft = Convert.ToDecimal(lblDateLeft.Value);
        objEntity.DateTop = Convert.ToDecimal(lblDateTop.Value);
        objEntity.AmntWord1Left = Convert.ToDecimal(lblAmntWordLeft.Value);
        objEntity.AmntWord1Top = Convert.ToDecimal(lblAmntWordTop.Value);
        objEntity.AmntWord2Left = Convert.ToDecimal(lblAmntWordLeft1.Value);
        objEntity.AmntWord2Top = Convert.ToDecimal(lblAmntWordTop1.Value);
        objEntity.AmntNumTop = Convert.ToDecimal(lblAmntNumTop.Value);
        objEntity.AmntNumLeft = Convert.ToDecimal(lblAmntNumLeft.Value);
        objEntity.CancelReason = HiddenFieldRelativeTop.Value;
        objEntity.FinalTops = HiddenFieldRelativeTopFinal.Value;

        if (TextBox1.Text.Trim() != "")
        {
            objEntity.PayeeName = TextBox1.Text.Trim();
        }
        if (TextBox2.Text.Trim() != "")
        {
            objEntity.PaymentDate = TextBox2.Text.Trim();
        }
        if (TextBox3.Text.Trim() != "")
        {
            objEntity.Amunt_word_one = TextBox3.Text.Trim();
        }
        if (TextBox5.Text.Trim() != "")
        {
            objEntity.Amunt_word_two = TextBox5.Text.Trim();
        }
        if (TextBox4.Text.Trim() != "")
        {
            objEntity.AmntNum = Convert.ToDecimal(TextBox4.Text.Trim());
        }
        //EVM-0027 Aug 29
        if (txtWord1Count.Value.Trim() != "")
        {
            objEntity.WordOneLength = Convert.ToInt32(txtWord1Count.Value.Trim());
        }
        if (HiddenFieldTaxId.Value != "")
            objEntity.ChequeTemplateId = Convert.ToInt32(HiddenFieldTaxId.Value);
        objEntity.Name = txtName.Text.Trim();
        DataTable dtList = objEmpPerfomance.ReadTemplateById(objEntity);
        if (dtList.Rows.Count > 0)
        {
            if (dtList.Rows[0]["CHKTEMPLT_CNCL_USERID"].ToString() != "")
            {
                Response.Redirect("fms_Cheque_Template.aspx?InsUpd=UpdCancl");
            }
            else
            {
                objEmpPerfomance.UpdateChequeTemplte(objEntity);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("fms_Cheque_Template.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                }
            }
        }
    }

    [WebMethod]
    public static string DupChkName(string intTaxid, string intGrpname, string intuserid, string intorgid, string intcorpid)
    {
        string result = "true";

        clsBusiness_Cheque_template objEmpPerfomance = new clsBusiness_Cheque_template();
        clsEntityChequeTemplate objEntity = new clsEntityChequeTemplate();
        if (intTaxid != "")
            objEntity.ChequeTemplateId = Convert.ToInt32(intTaxid);
        objEntity.Name = intGrpname;
        objEntity.User_Id = Convert.ToInt32(intuserid);
        objEntity.Organisation_id = Convert.ToInt32(intorgid);
        objEntity.Corporate_id = Convert.ToInt32(intcorpid);
        string cnt = objEmpPerfomance.DuplicationCheckName(objEntity);
        if (cnt!="0")
        {
         result = "false";
        }
        return result;
    }
}