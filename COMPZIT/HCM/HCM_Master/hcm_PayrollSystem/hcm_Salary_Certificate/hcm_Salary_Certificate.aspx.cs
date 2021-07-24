using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit;
using System.Web.Services;
using EL_Compzit.EntityLayer_HCM;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;

public partial class HCM_HCM_Master_hcm_Salary_Certificate_hcm_Salary_Certificate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            clsEntityCommon objEntityCommon = new clsEntityCommon();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableCancel = 0, intEnableHrConfirm = 0, intEnableConfirm = 0;

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Salary_Certificate);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                    {
                        intEnableHrConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnConfirm.Visible = true;
                }
                else
                {
                    btnConfirm.Visible = false;
                }

                if (intEnableHrConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnHRApprove.Visible = true;
                    btnHRReject.Visible = true;
                }
                else
                {
                    btnHRApprove.Visible = false;
                    btnHRReject.Visible = false;
                }
            }

            DataTable dtEmp = objBusinessLayer.ReadEmployeeDtl(objEntityCommon);
            LoadEmployee(dtEmp, intUserId, intEnableHrConfirm);


            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }

            divRejectReasn.Visible = false;

            if (Session["EDIT_ID"] != null)
            {
                string strId = Session["EDIT_ID"].ToString();
                hiddenEdit.Value = strId;
                Update(strId, intEnableHrConfirm);
                lblHeader.InnerText = "Edit Salary Certificate Request";
            }
            else if (Session["VIEW_ID"] != null)
            {
                string strId = Session["VIEW_ID"].ToString();
                hiddenView.Value = strId;
                Update(strId, intEnableHrConfirm);
                btnHRApprove.Visible = false;
                btnHRReject.Visible = false;
                btnConfirm.Visible = false;
                lblHeader.InnerText = "View Salary Certificate Request";
            }
            else
            {
                btnHRApprove.Visible = false;
                btnHRReject.Visible = false;
                lblHeader.InnerText = "Add Salary Certificate Request";
                btnPrint.Visible = false;
            }
        }

    }

    public void LoadEmployee(DataTable dt, int intUserId, int intEnableHrConfirm)
    {
        if (dt.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dt;
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataBind();
        }
        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");

        if (Session["EDIT_ID"] == null && Session["VIEW_ID"] == null)
        {
            if (ddlEmployee.Items.FindByValue(intUserId.ToString()) != null)
            {
                ddlEmployee.Items.FindByValue(intUserId.ToString()).Selected = true;
            }
        }
        if (intEnableHrConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            ddlEmployee.Enabled = true;
        }
        else
        {
            ddlEmployee.Enabled = false;
        }
    }


    [WebMethod]
    public static string[] EmployeeDtlsDisplay(string strEmpId,string DecimalCnt)
    {
        string[] strJson = new string[8];

        clsBusinessLayerSalaryCertificate objBusinessSalryCertfct=new clsBusinessLayerSalaryCertificate();
        clsEntityLayerSalaryCertificate objEntitySalryCertfct=new clsEntityLayerSalaryCertificate();

        if (strEmpId != "--SELECT EMPLOYEE--" && strEmpId != "")
        {
            objEntitySalryCertfct.EmployeeId = Convert.ToInt32(strEmpId);

            DataTable dtEmpDtls = objBusinessSalryCertfct.ReadEmployeeDtls(objEntitySalryCertfct);

            strJson[0] = dtEmpDtls.Rows[0]["USR_NAME"].ToString();
            strJson[1] = dtEmpDtls.Rows[0]["DSGN_NAME"].ToString();
            strJson[2] = dtEmpDtls.Rows[0]["CPRDEPT_NAME"].ToString();
            strJson[3] = dtEmpDtls.Rows[0]["USR_NTNLID_NUMBR"].ToString();
            strJson[4] = dtEmpDtls.Rows[0]["EMPIMG_DOC_NUMBER"].ToString();

            DataTable dtBasicPay = objBusinessSalryCertfct.ReadBasicPay(objEntitySalryCertfct);
            DataTable dtAllowance = objBusinessSalryCertfct.ReadAllowance(objEntitySalryCertfct);

            int precision = Convert.ToInt32(DecimalCnt);
            string format = String.Format("{{0:N{0}}}", precision);

            decimal BasicPay = 0;
            if (dtBasicPay.Rows[0]["SLRY_BASIC_PAY"].ToString() != "")
            {
                BasicPay = Convert.ToDecimal(dtBasicPay.Rows[0]["SLRY_BASIC_PAY"].ToString());
            }
            decimal Allownce=0;
            if (dtAllowance.Rows[0]["SLRYALLCE_AMOUNT"].ToString() != "")
            {
                Allownce = Convert.ToDecimal(dtAllowance.Rows[0]["SLRYALLCE_AMOUNT"].ToString());
            }
            strJson[5] = String.Format(format, BasicPay);
            strJson[6] = String.Format(format, Allownce);

            DataTable dtDivision = objBusinessSalryCertfct.ReadDivision(objEntitySalryCertfct);

            foreach (DataRow dtDiv in dtDivision.Rows)
            {
                strJson[7] = (dtDiv["CPRDIV_NAME"].ToString() + "," + strJson[7]).TrimEnd(" , ".ToCharArray());
            }

        }
        return strJson;
    }



    protected void btnConfirm_Click(object sender, EventArgs e)
    {

        clsBusinessLayerSalaryCertificate objBusinessSalryCertfct = new clsBusinessLayerSalaryCertificate();
        clsEntityLayerSalaryCertificate objEntitySalryCertfct = new clsEntityLayerSalaryCertificate();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntitySalryCertfct.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntitySalryCertfct.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntitySalryCertfct.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntitySalryCertfct.EmployeeId = Convert.ToInt32(hiddenEmpId.Value);
        objEntitySalryCertfct.BasicPay = Convert.ToDecimal(hiddenBasicPay.Value);
        objEntitySalryCertfct.Allowance = Convert.ToDecimal(hiddenAllowance.Value);
        objEntitySalryCertfct.ConfirmSts = 1;
        objEntitySalryCertfct.Reason = txtRsn.Text.Trim();
        objEntitySalryCertfct.Date = System.DateTime.Now;

        objBusinessSalryCertfct.InsertSalaryCertfctRequest(objEntitySalryCertfct);
        Session["SUCCESS"] = "SAVE";
        Response.Redirect("hcm_Salary_Certificate_List.aspx");

    }


    public void Update(string strId, int intEnableHrConfirm)
    {

        clsBusinessLayerSalaryCertificate objBusinessSalryCertfct = new clsBusinessLayerSalaryCertificate();
        clsEntityLayerSalaryCertificate objEntitySalryCertfct = new clsEntityLayerSalaryCertificate();

        objEntitySalryCertfct.CertifictId = Convert.ToInt32(strId);

        DataTable dtSalryReqById = objBusinessSalryCertfct.ReadRequestById(objEntitySalryCertfct);

        hiddenEmpId.Value = dtSalryReqById.Rows[0]["USR_ID"].ToString();

        if (ddlEmployee.Items.FindByValue(dtSalryReqById.Rows[0]["USR_ID"].ToString()) != null)
        {
            ddlEmployee.Items.FindByValue(dtSalryReqById.Rows[0]["USR_ID"].ToString()).Selected = true;
        }
        else
        {
            System.Web.UI.WebControls.ListItem lstGrp = new System.Web.UI.WebControls.ListItem(dtSalryReqById.Rows[0]["USR_NAME"].ToString(), dtSalryReqById.Rows[0]["USR_ID"].ToString());
            ddlEmployee.Items.Insert(0, lstGrp);
            ddlEmployee.Items.FindByValue(dtSalryReqById.Rows[0]["USR_ID"].ToString()).Selected = true;
        }
        ddlEmployee.Enabled = false;

        int precision = Convert.ToInt32(hiddenDecimalCount.Value);
        string format = String.Format("{{0:N{0}}}", precision);

        decimal BasicPay = 0;
        if (dtSalryReqById.Rows[0]["SLRYCRTFCT_BASIC_PAY_AMT"].ToString() != "")
        {
            BasicPay = Convert.ToDecimal(dtSalryReqById.Rows[0]["SLRYCRTFCT_BASIC_PAY_AMT"].ToString());
        }
        decimal Allownce = 0;
        if (dtSalryReqById.Rows[0]["SLRYCRTFCT_ALLOWANCE_AMT"].ToString() != "")
        {
            Allownce = Convert.ToDecimal(dtSalryReqById.Rows[0]["SLRYCRTFCT_ALLOWANCE_AMT"].ToString());
        }

        lblBasicPay.Text = String.Format(format, BasicPay);
        lblAllwnce.Text = String.Format(format, Allownce);
        txtRsn.Enabled = false;

        txtRsn.Text = dtSalryReqById.Rows[0]["SLRYCRTFCT_REASN"].ToString();

        if (dtSalryReqById.Rows[0]["SLRYCRTFCT_HR_APPROVAL_STS"].ToString() == "2")
        {
            lblReason.InnerText = "Employee Reason";
            divRejectReasn.Visible = true;
            txtRejctReasnDisplay.Text = dtSalryReqById.Rows[0]["SLRYCRTFCT_RJCT_REASN"].ToString();
        }
        else
        {
            lblReason.InnerText = "Reason";
            divRejectReasn.Visible = false;
        }

        if (intEnableHrConfirm == 1)
        {
            btnConfirm.Visible = false;
            btnHRApprove.Visible = true;
            btnHRReject.Visible = true;
        }

        if (dtSalryReqById.Rows[0]["SLRYCRTFCT_HR_APPROVAL_STS"].ToString() == "1")
        {
            btnPrint.Visible = true;
        }
        else
        {
            btnPrint.Visible = false;
        }

    }

    [WebMethod]
    public static string ApproveReject(string strCertfctId, string Sts, string UserId, string RejctReasn)
    {
        string result;

        clsBusinessLayerSalaryCertificate objBusinessSalryCertfct = new clsBusinessLayerSalaryCertificate();
        clsEntityLayerSalaryCertificate objEntitySalryCertfct = new clsEntityLayerSalaryCertificate();

        objEntitySalryCertfct.CertifictId = Convert.ToInt32(strCertfctId);
        objEntitySalryCertfct.UserId = Convert.ToInt32(UserId);
        objEntitySalryCertfct.Date = System.DateTime.Now;

        Page objpage = new Page();

        DataTable dtSalryReqById = objBusinessSalryCertfct.ReadRequestById(objEntitySalryCertfct);
        if (dtSalryReqById.Rows[0]["SLRYCRTFCT_HR_APPROVAL_STS"].ToString() == "0")
        {
            if (Sts == "1")
            {
                objBusinessSalryCertfct.UpdateApproveSalaryReqst(objEntitySalryCertfct);
                objpage.Session["SUCCESS"] = "APPROVE";
            }

            if (Sts == "2")
            {
                objEntitySalryCertfct.RejectReason = RejctReasn;
                objBusinessSalryCertfct.UpdateRejectSalaryReqst(objEntitySalryCertfct);
                objpage.Session["SUCCESS"] = "REJECT";
            }
        }
        else
        {
            if (dtSalryReqById.Rows[0]["SLRYCRTFCT_HR_APPROVAL_STS"].ToString() == "1")
            {
                objpage.Session["SUCCESS"] = "DONEAPPROVE";
            }
            else if (dtSalryReqById.Rows[0]["SLRYCRTFCT_HR_APPROVAL_STS"].ToString() == "2")
            {
                objpage.Session["SUCCESS"] = "DONEREJECT";
            }
            Sts = "3";
        }

        return result = Sts;
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            clsEntityLayerSalaryCertificate objEntitySalryCertfct = new clsEntityLayerSalaryCertificate();
            clsBusinessLayerSalaryCertificate objBusinessSalryCertfct = new clsBusinessLayerSalaryCertificate();

            objEntitySalryCertfct.CertifictId = Convert.ToInt32(hiddenView.Value);

            DataTable dtSalaryCertfct = objBusinessSalryCertfct.ReadRequestById(objEntitySalryCertfct);

            int precision = Convert.ToInt32(hiddenDecimalCount.Value);
            string format = String.Format("{{0:N{0}}}", precision);

            decimal BasicPay = Convert.ToDecimal(dtSalaryCertfct.Rows[0]["SLRYCRTFCT_BASIC_PAY_AMT"].ToString());
            decimal Allownce = Convert.ToDecimal(dtSalaryCertfct.Rows[0]["SLRYCRTFCT_ALLOWANCE_AMT"].ToString());
            decimal TotalPay = BasicPay + Allownce;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntitySalryCertfct.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntitySalryCertfct.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALARY_CERTIFICATE);

            objEntityCommon.CorporateID = objEntitySalryCertfct.CorpId;
            objEntityCommon.Organisation_Id = objEntitySalryCertfct.OrgId;

            string strNextId = "";
            strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);

            if (dtSalaryCertfct.Rows[0]["CRNCMST_ID"].ToString() != "")
            {
                objEntityCommon.CurrencyId = Convert.ToInt32(dtSalaryCertfct.Rows[0]["CRNCMST_ID"].ToString());
            }
            string AmtInWords = objBusinessLayer.ConvertCurrencyToWords(objEntityCommon, TotalPay.ToString());

            objEntitySalryCertfct.EmployeeId = Convert.ToInt32(dtSalaryCertfct.Rows[0]["USR_ID"].ToString());
            DataTable dtDivision = objBusinessSalryCertfct.ReadDivision(objEntitySalryCertfct);
            string strDivsn = "";
            foreach (DataRow dtDiv in dtDivision.Rows)
            {
                strDivsn = (dtDiv["CPRDIV_NAME"].ToString() + ", " + strDivsn).TrimEnd(" , ".ToCharArray());
            }

            Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);

            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                string strImageName = "Salary_Certificate_" + strNextId + ".pdf";
                string imgpath = "/CustomFiles/SalaryCertficate/";
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.SALARY_CERTIFICATE);

                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(imgpath) + strImageName, FileMode.Create);
                PdfWriter.GetInstance(document, file);

                document.Open();

                PdfPTable headtable = new PdfPTable(1);

                string strImageLoc = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "quotation-header.png";
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLoc));
                image.ScalePercent(PdfPCell.ALIGN_CENTER);
                image.ScaleToFit(600f, 100f);

                headtable.AddCell(new PdfPCell(image) { Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_CENTER, });
                document.Add(headtable);
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));

                PdfPTable tableLayout = new PdfPTable(2);
                float[] headersBody = { 50, 50 };
                tableLayout.SetWidths(headersBody);
                tableLayout.WidthPercentage = 100;

                tableLayout.AddCell(new PdfPCell(new Phrase("Ref : " + strNextId, FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                tableLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                tableLayout.AddCell(new PdfPCell(new Phrase("Date : " + DateTime.Now.ToString("dd-MMMM-yyyy"), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                tableLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                tableLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });

                document.Add(tableLayout);

                PdfPTable headLayout = new PdfPTable(1);

                headLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                headLayout.AddCell(new PdfPCell(new Phrase("TO WHOM IT MAY CONCERN", FontFactory.GetFont("Times New Roman", 17, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });

                document.Add(headLayout);

                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk("Sub : Salary Certificate", FontFactory.GetFont("Times New Roman", 14, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));

                Phrase phrase1 = new Phrase();
                phrase1.Add(new Chunk("This is to certify that ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK)));
                if (dtSalaryCertfct.Rows[0]["EMPERDTL_GENDER"].ToString() != "" && dtSalaryCertfct.Rows[0]["EMPERDTL_GENDER"].ToString() == "1")
                {
                    phrase1.Add(new Chunk("Mrs. " + dtSalaryCertfct.Rows[0]["USR_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)));
                }
                else
                {
                    phrase1.Add(new Chunk("Mr. " + dtSalaryCertfct.Rows[0]["USR_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)));
                }
                if (dtSalaryCertfct.Rows[0]["EMPIMG_DOC_NUMBER"].ToString() != "")
                {
                    phrase1.Add(new Chunk(", Indian Passport No. " + dtSalaryCertfct.Rows[0]["EMPIMG_DOC_NUMBER"].ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK)));
                }
                if (dtSalaryCertfct.Rows[0]["USR_NTNLID_NUMBR"].ToString() != "")
                {
                    phrase1.Add(new Chunk(" (Qatari I.D. No. " + dtSalaryCertfct.Rows[0]["USR_NTNLID_NUMBR"].ToString() + ")", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK)));
                }
                string JoinDt = "";
                JoinDt = dtSalaryCertfct.Rows[0]["USR_INS_DATE"].ToString();
                if (dtSalaryCertfct.Rows[0]["EMP_JOINED_DATE"].ToString() != "")
                {
                    JoinDt = dtSalaryCertfct.Rows[0]["EMP_JOINED_DATE"].ToString();
                }
                if (strDivsn == "")
                {
                    phrase1.Add(new Chunk(" is working with us since " + JoinDt + " as ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK)));
                    phrase1.Add(new Chunk(dtSalaryCertfct.Rows[0]["DSGN_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)));
                    phrase1.Add(new Chunk(" in our " + dtSalaryCertfct.Rows[0]["CPRDEPT_NAME"].ToString() + " department.", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK)));
                }
                else
                {
                    phrase1.Add(new Chunk(" is working with us since " + JoinDt + " as ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK)));
                    phrase1.Add(new Chunk(dtSalaryCertfct.Rows[0]["DSGN_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)));
                    phrase1.Add(new Chunk(" in our " + strDivsn + " division(s).", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK)));
                }
                document.Add(new Paragraph(phrase1));

                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                Phrase phrase2 = new Phrase();
                phrase2.Add(new Chunk("He is paid a salary of ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK)));
                phrase2.Add(new Chunk(String.Format(format, TotalPay) + " " + dtSalaryCertfct.Rows[0]["CRNCMST_ABBRV"].ToString() + " (" + AmtInWords + ") (Basic : " + String.Format(format, BasicPay) + " " + dtSalaryCertfct.Rows[0]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)));
                int intAllwnce = Convert.ToInt32(dtSalaryCertfct.Rows[0]["SLRYCRTFCT_ALLOWANCE_AMT"].ToString());
                if (intAllwnce != 0)
                {
                    phrase2.Add(new Chunk(" plus a special allowance of " + String.Format(format, Allownce) + " " + dtSalaryCertfct.Rows[0]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)));
                }
                phrase2.Add(new Chunk(") per month and other perquisites as per the rules of company. He is also provided with free furnished sharing bachelor accommodation and yearly air ticket for self.", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK)));
                document.Add(new Paragraph(phrase2));

                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk("This certificate is issued at his request and without any liability for the company.", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))));

                Phrase phrase3 = new Phrase();
                phrase3.Add(new Chunk("for ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK)));
                phrase3.Add(new Chunk(" AL BALAGH TRADING & CONTRACTING CO. W.L.L. ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)));
                document.Add(new Paragraph(phrase3));

                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk("SRINIVASAN VENKATESAN", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk("GENERAL MANAGER", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));

                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));

                PdfPTable footrtable = new PdfPTable(2);
                float[] headersBodyfootr = { 0, 100 };
                footrtable.SetWidths(headersBodyfootr);
                footrtable.WidthPercentage = 100;

                string strImageLocFooter = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "quotation-footer.png";
                iTextSharp.text.Image imageFootr = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLocFooter));
                imageFootr.ScalePercent(PdfPCell.ALIGN_LEFT);
                imageFootr.ScaleToFit(520f, 60f);

                footrtable.AddCell(new PdfPCell(new Phrase(" ")) { Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_LEFT });
                footrtable.AddCell(new PdfPCell(imageFootr) { Border = 0, PaddingBottom = 10, HorizontalAlignment = Element.ALIGN_LEFT });
                document.Add(footrtable);

                document.Close();

                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=Salary_Certificate_" + strNextId + ".pdf");          
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }
        }
        catch
        {

        }
    }

}