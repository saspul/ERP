using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
// CREATED BY:EVM-0008
// CREATED DATE:10/5/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class HCM_HCM_Master_hcm_Exit_Management_hcm_Experiance_Certificate_hcm_Experiance_Certificate : System.Web.UI.Page
{
    ClsBusiness_Experiance_Certificate objBussnsExpCertfct = new ClsBusiness_Experiance_Certificate();
    protected void Page_Load(object sender, EventArgs e)
    {

        TextBox1.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        TextBox1.Attributes.Add("onkeypress", "return isTag(event)");
        TextBox1.Attributes.Add("onkeypress", "return DisableEnter(event)");

        TextBox2.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        TextBox2.Attributes.Add("onkeypress", "return isTag(event)");
        TextBox2.Attributes.Add("onkeypress", "return DisableEnter(event)");

        txtReason.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtReason.Attributes.Add("onkeypress", "return isTag(event)");
        txtReason.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlEmployee.Attributes.Add("onkeypress", "return DisableEnter(event)");

        // ddlEmployee.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        if (!IsPostBack)
        {
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            FillEmployee();

            ddlEmployee.Focus();

            if (Request.QueryString["Id"] != null)
            {
                txtReason.Focus();
                btnAdd.Visible = false;
                //btnUpdate.Visible = true;
                //  btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Hiddenedit.Value = strId;
                Update(strId);
                lblEntry.Text = "Edit Experiance Certificate ";

            }
        }

    }

    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id)
    {

        // clsentitylayeemplo objEntitySponsor = new clsEntitySponsor();
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;

        ClsEntity_Experiance_Certificate objEntityOnBoard = new ClsEntity_Experiance_Certificate();
        if (Session["USERID"] != null)
        {
            //  objEntityOnBoard.UserId = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOnBoard.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityOnBoard.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }



        objEntityOnBoard.EmpId = Convert.ToInt32(strP_Id);
        objEntityOnBoard.UserId = Convert.ToInt32(strP_Id);
        Hiddenedit.Value = strP_Id;
        DataTable dtLevEmployee = objBussnsExpCertfct.ReadLevEmplyById(objEntityOnBoard);
        if (dtLevEmployee.Rows.Count > 0)
        {

            if (dtLevEmployee.Rows[0]["EMPLOYEE ID"].ToString() != null && dtLevEmployee.Rows[0]["EMPLOYEE ID"].ToString() != "")
            {
                ddlEmployee.Enabled = true;

                ddlEmployee.ClearSelection();
                if (ddlEmployee.Items.FindByValue(dtLevEmployee.Rows[0]["EMPLOYEE ID"].ToString()) != null)
                {
                    ddlEmployee.Items.FindByValue(dtLevEmployee.Rows[0]["EMPLOYEE ID"].ToString()).Selected = true;
                }
                else
                {
                    System.Web.UI.WebControls.ListItem lstGrp = new System.Web.UI.WebControls.ListItem(dtLevEmployee.Rows[0]["EMPLOYEE"].ToString(), dtLevEmployee.Rows[0]["EMPLOYEE ID"].ToString());
                    ddlEmployee.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlEmployee);

                    ddlEmployee.Items.FindByText(dtLevEmployee.Rows[0]["EMPLOYEE"].ToString()).Selected = true;

                }
            }

        }

        ScriptManager.RegisterStartupScript(this, GetType(), "ReadEmpDetailsAFTRsAVE", "ReadEmpDetailsAFTRsAVE(" + objEntityOnBoard.EmpId + ");", true);



    }
    //for sorting drop down
    private void SortDDL(ref DropDownList objDDL)
    {
        ArrayList textList = new ArrayList();
        ArrayList valueList = new ArrayList();


        foreach (System.Web.UI.WebControls.ListItem li in objDDL.Items)
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
            System.Web.UI.WebControls.ListItem objItem = new System.Web.UI.WebControls.ListItem(textList[i].ToString(), valueList[i].ToString());
            objDDL.Items.Add(objItem);
        }
    }
    //for adding the details
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        ClsEntity_Experiance_Certificate objEntityOnBoard = new ClsEntity_Experiance_Certificate();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOnBoard.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityOnBoard.Orgid = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityOnBoard.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityOnBoard.Remarks = txtReason.Text.Trim();
        //evm-0023
        objEntityOnBoard.Conduct = txtConduct.Text.Trim();
        objEntityOnBoard.AttendancePerfo = txtAttendancePerfo.Text.Trim();
        objEntityOnBoard.TradePerfo = txtTradePerfo.Text.Trim();
        if (HiddenFrmDate.Value == "")
            objEntityOnBoard.FromDate = DateTime.MinValue;
        else
            objEntityOnBoard.FromDate = objCommon.textToDateTime(HiddenFrmDate.Value);
        objEntityOnBoard.ToDate = objCommon.textToDateTime(HiddenToDate.Value);
        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
            objEntityOnBoard.EmpId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        int EMPID = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        objBussnsExpCertfct.InsertempCertGerndtls(objEntityOnBoard);
        btnAdd.Visible = false;
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCertfct", "SuccessCertfct(" + EMPID + ");", true);

        HiddenPrint.Value = "true";

        clsCommonLibrary ObjCommon = new clsCommonLibrary();

        EmpDetails objemp = new EmpDetails();
        objEntityOnBoard.UserId = EMPID;
        DataTable dtCandData = objBussnsExpCertfct.ReadLevEmplyById(objEntityOnBoard);
        DataTable dtReadDates = objBussnsExpCertfct.ReadJoinLevDate(objEntityOnBoard);
        DataTable dtDivisions = objBussnsExpCertfct.ReadDivisionOfEmp(objEntityOnBoard); //evm-0023

        string strPrintReport = ExperienceCertPrint(dtCandData, dtReadDates, dtDivisions); //evm-0023
        //divPrintReport.InnerHtml = strPrintReport;

    }

    //for adding the details
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        ClsEntity_Experiance_Certificate objEntityOnBoard = new ClsEntity_Experiance_Certificate();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOnBoard.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityOnBoard.Orgid = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityOnBoard.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityOnBoard.EmpId = Convert.ToInt32(Hiddenedit.Value);
        int EMPID = objEntityOnBoard.EmpId;
        objEntityOnBoard.Remarks = txtReason.Text.Trim();
        //evm-0023
        objEntityOnBoard.Conduct = txtConduct.Text.Trim();
        objEntityOnBoard.AttendancePerfo = txtAttendancePerfo.Text.Trim();
        objEntityOnBoard.TradePerfo = txtTradePerfo.Text.Trim();
        objBussnsExpCertfct.UpdateempCertGerndtls(objEntityOnBoard);

        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCertfct", "SuccessCertfct(" + EMPID + ");", true);

        HiddenPrint.Value = "true";

        clsCommonLibrary ObjCommon = new clsCommonLibrary();

        EmpDetails objemp = new EmpDetails();
        objEntityOnBoard.UserId = EMPID;
        DataTable dtCandData = objBussnsExpCertfct.ReadLevEmplyById(objEntityOnBoard);
        DataTable dtReadDates = objBussnsExpCertfct.ReadJoinLevDate(objEntityOnBoard);
        DataTable dtDivisions = objBussnsExpCertfct.ReadDivisionOfEmp(objEntityOnBoard); //evm-00231

        string strPrintReport = ExperienceCertPrint(dtCandData, dtReadDates, dtDivisions); //evm-0023
       

             


   
         
      
    }
    public void FillEmployee()
    {

        ClsEntity_Experiance_Certificate objEntityOnBoard = new ClsEntity_Experiance_Certificate();
        if (Session["USERID"] != null)
        {
            objEntityOnBoard.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOnBoard.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityOnBoard.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtLevEmployee = objBussnsExpCertfct.ReadEmployeeCrtfct(objEntityOnBoard);
        if (dtLevEmployee.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dtLevEmployee;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();

        }

        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");



    }
    public class EmpDetails
    {
        public string[] empdatails;
        public string empdivision = "";
        public string empDependntName = "";
        public string empJoinDate = "";
        public string empLevDate = "";
    }

    [WebMethod]
    public static EmpDetails ReadCandidateData(int intCandId)
    {
        string[] CandData = new string[15];

        ClsBusiness_Experiance_Certificate objBussnsExpCertfct = new ClsBusiness_Experiance_Certificate();
        ClsEntity_Experiance_Certificate objEntityOnBoard = new ClsEntity_Experiance_Certificate();
        clsCommonLibrary ObjCommon = new clsCommonLibrary();
        EmpDetails objemp = new EmpDetails();
        objEntityOnBoard.UserId = intCandId;
        DataTable dtCandData = objBussnsExpCertfct.ReadLevEmplyById(objEntityOnBoard);
        DataTable dtDivisions = objBussnsExpCertfct.ReadDivisionOfEmp(objEntityOnBoard);
        DataTable dtReadEmpFather = objBussnsExpCertfct.ReadEmpFather(objEntityOnBoard);
        DataTable dtReadDates = objBussnsExpCertfct.ReadJoinLevDate(objEntityOnBoard);
        if (dtCandData.Rows.Count > 0)
        {
            CandData[0] = dtCandData.Rows[0]["EMPLOYEE"].ToString();
            CandData[1] = dtCandData.Rows[0]["DESIGNATION"].ToString();
            CandData[2] = dtCandData.Rows[0]["DEPARTMENT"].ToString();


            CandData[3] = dtCandData.Rows[0]["PYGRD_NAME"].ToString();

            CandData[4] = dtCandData.Rows[0]["EMCNDT_ADR1"].ToString();
            CandData[5] = dtCandData.Rows[0]["REMARKS"].ToString();
            CandData[6] = dtCandData.Rows[0]["EMCNDT_ADR2"].ToString();
            CandData[7] = dtCandData.Rows[0]["EMCNDT_ADR3"].ToString();
            CandData[8] = dtCandData.Rows[0]["CNTRY_NAME"].ToString();
            //evm-0023
            CandData[9] = dtCandData.Rows[0]["CONDUCT"].ToString();
            CandData[10] = dtCandData.Rows[0]["ATTDCPRFMNC"].ToString();
            CandData[11] = dtCandData.Rows[0]["TRADEPRFMNC"].ToString();
            CandData[12] = dtCandData.Rows[0]["STAFF_WORKER"].ToString();

        }

        foreach (DataRow dtDiv in dtDivisions.Rows)
        {
            if (objemp.empdivision == "")
            {
                objemp.empdivision = dtDiv["DIVISION"].ToString();
            }
            else
            {
                objemp.empdivision = dtDiv["DIVISION"] + "," + objemp.empdivision;
            }
        }
        foreach (DataRow dtNam in dtReadEmpFather.Rows)
        {
            if (objemp.empDependntName == "")
            {
                objemp.empDependntName = dtNam["EMPDPNT_NAME"].ToString();
            }
            else
            {
                objemp.empDependntName = dtNam["EMPDPNT_NAME"].ToString() + "," + objemp.empDependntName;
            }
        }
        if (dtReadDates.Rows.Count > 0)
        {
            if (dtReadDates.Rows[0]["USR_JOIN_DATE"].ToString() != DateTime.MinValue.ToString() && dtReadDates.Rows[0]["USR_JOIN_DATE"].ToString() != "")
            {
                objemp.empJoinDate = dtReadDates.Rows[0]["USR_JOIN_DATE"].ToString();
            }
            else
            {
                objemp.empJoinDate = dtReadDates.Rows[0]["USR_INS_DATE"].ToString();
            }
            if (dtReadDates.Rows[0]["LEVDATE"].ToString() != DateTime.MinValue.ToString() && dtReadDates.Rows[0]["LEVDATE"].ToString() != "")
            {
                objemp.empLevDate = dtReadDates.Rows[0]["LEVDATE"].ToString();
            }
            else
            {
                objemp.empLevDate = DateTime.Now.ToString("dd-MM-yyyy");
            }
        }
        objemp.empdatails = CandData;

        return objemp;
    }


    //evm-27
    //To Generate Experience Certificate pdf 

    public string ExperienceCertPrint(DataTable dtCandData, DataTable dtReadDates, DataTable dtDivisions)
    {
        
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommonLibrary = new clsCommonLibrary();

        Document pdfDoc = new Document(PageSize.A4, 50f, 40f, 20f, 10f);

        string datetm = DateTime.Now.ToString("dd-MM-yyyy");

        string joindt;
        string levdt;

        if (dtReadDates.Rows[0]["USR_JOIN_DATE"].ToString() != "")
        {
            joindt = dtReadDates.Rows[0]["USR_JOIN_DATE"].ToString();
        }
        else
        {
            joindt = dtReadDates.Rows[0]["USR_INS_DATE"].ToString();
        }
        if (dtReadDates.Rows[0]["LEVDATE"].ToString() != "")
        {
            levdt = dtReadDates.Rows[0]["LEVDATE"].ToString();
        }
        else
        {
            levdt = DateTime.Today.ToString("dd-MM-yyyy");
        }



        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

        string CandId = dtCandData.Rows[0]["EMPLOYEE ID"].ToString() + objEntityCommon.UserCodeRef.ToString();

        string strImageName = "EXPERIENCE CERTIFICATE_" + CandId + ".pdf";
        string imgpath = "/CustomFiles/messagepdf/";
        string strImagePath = objCommonLibrary.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EXPERIENCE_CERT_PDF);

        FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(imgpath) + strImageName, FileMode.Create);
        PdfWriter.GetInstance(pdfDoc, file);

        pdfDoc.Open();



        PdfPTable headtable = new PdfPTable(1);

        string strImageLoc = objCommonLibrary.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "quotation-header.png";
        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLoc));
        image.ScalePercent(PdfPCell.ALIGN_CENTER);
        image.ScaleToFit(600f, 100f);

        headtable.AddCell(new PdfPCell(image) { Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_CENTER, });
        headtable.AddCell(new PdfPCell(new Phrase("EXPERIENCE CERTIFICATE  ", FontFactory.GetFont("Times New Roman", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, });
        //headtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, });
        //headtable.AddCell(new PdfPCell(new Phrase("Date : " + DateTime.Now.ToString("dd-MMMM-yyyy"), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0,  });
        headtable.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, });

        pdfDoc.Add(headtable);
        pdfDoc.Add(new Paragraph("Date : " + DateTime.Now.ToString("dd-MMMM-yyyy"), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK)));
        pdfDoc.Add(new Paragraph("Ref# : "+dtCandData.Rows[0]["EMPLOYEE_ID"].ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK)));
        pdfDoc.Add(new Paragraph(new Chunk("  ", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK))));
        string strcompletestring="";
        string strpass = "";
        string strnopass = "";
        PdfPTable tableLayout = new PdfPTable(2);

        tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, });

        if (dtCandData.Rows[0]["STAFF_WORKER"].ToString() == "0")         //staff
        {
            string strpassy = "";
            string strPassport = "";
            string strQID = "";
            string str1 = "";
            string gender="";
            if (dtCandData.Rows[0]["PASSPRT_NO"].ToString() != "" && dtCandData.Rows[0]["CNTRY_NAME"].ToString() != "")
                strPassport = dtCandData.Rows[0]["CNTRY_NAME"].ToString() + " Passport No. " + dtCandData.Rows[0]["PASSPRT_NO"].ToString();

            if (dtCandData.Rows[0]["Q_ID"].ToString() != "")
                strQID = " ( QID " + dtCandData.Rows[0]["Q_ID"].ToString() + " )";
            if (Convert.ToInt32(dtCandData.Rows[0]["EMPERDTL_GENDER"]) == 0)
            {
                gender = "Mr";
            }
            else
            {
                gender = "Ms";
            }


            if (strPassport != "")
            {


                strpassy = "This is to certify that  " + gender + " " + dtCandData.Rows[0]["EMPLOYEE"].ToString() + " holder of    " + strPassport + strQID + "," + " has worked in our organization as " + dtCandData.Rows[0]["DESIGNATION"].ToString() + " from  " + joindt + " to " + levdt + " in our " + dtCandData.Rows[0]["DEPARTMENT"].ToString() + " Department ";
                //  pdfDoc.Add(new Paragraph(new Chunk(strpassy + "", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK))));
               
            }

            else
            {

                strpass = "This is to certify that  " + gender + " "  + dtCandData.Rows[0]["EMPLOYEE"].ToString() + " has worked in our organization as " + dtCandData.Rows[0]["DESIGNATION"].ToString() + " from  " + joindt + " to " + levdt + " in our " + dtCandData.Rows[0]["DEPARTMENT"].ToString() + " Department";

            }

                int intCount = 0;
                intCount = dtDivisions.Rows.Count;
                if (dtDivisions.Rows.Count != 0)
                {

                    if (dtDivisions.Rows.Count == 1)
                    {

                        str1 = " in our " + dtDivisions.Rows[0]["DIVISION"].ToString() + " Division.";


                    }
                    else
                    {
                        string division = "";
                        string strdiv = "";
                        for (int i = 0; i < dtDivisions.Rows.Count; i++)
                        {



                            if (intCount != (i + 1))
                            {
                                division = dtDivisions.Rows[i]["DIVISION"].ToString();





                            }

                            division = dtDivisions.Rows[i]["DIVISION"].ToString();
                            strdiv = strdiv + " ," + division;

                            str1 = strdiv + " Divisions.";


                        }




                    }

                }


             

                    if (strpass != "")
                    {
                        if (str1 != "")
                            strcompletestring = strpass + " " + str1;
                        else
                            strcompletestring = strpass;
                    }

                    if (strpassy != "")
                    {
                        if (str1 != "")
                            strcompletestring = strpassy + " " + str1;
                        else
                            strcompletestring = strpassy;
                    }

              
            if (strcompletestring != "")
            {
                pdfDoc.Add(new Paragraph(new Chunk(strcompletestring, FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK))));
                
            }
            //else if (strpassy != "")
            //{
            //    pdfDoc.Add(new Paragraph(new Chunk(strpassy + "", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK))));
            //}
            else
            {
                pdfDoc.Add(new Paragraph(new Chunk(strpass, FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK))));
            }
            pdfDoc.Add(new Paragraph(new Chunk("  ", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK))));
            pdfDoc.Add(new Paragraph(new Chunk(" During the tenure he has discharged his duties well. He left our organization on his own and wish him all success. ", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK))));
            pdfDoc.Add(new Paragraph(new Chunk("  ", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK))));
            pdfDoc.Add(new Paragraph(new Chunk("  ", FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, BaseColor.BLACK))));
            pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
            pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
            pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
            pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
            pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));

            //pdfDoc.Add(new Paragraph(new Chunk("  AL BALAGH TRADING & CONTRACTING CO. W.L.L.  SRINIVASAN VENKATESAN  General Manager", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));

        }

        else     //worker
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, });

            AddCellToBody(tableLayout, "Name         ");
            AddCellToBody(tableLayout, dtCandData.Rows[0]["EMPLOYEE"].ToString());
            AddCellToBody(tableLayout, " Empl. No   ");
            AddCellToBody(tableLayout, dtCandData.Rows[0]["EMPLOYEE_ID"].ToString());
            AddCellToBody(tableLayout, "Trade ");
            AddCellToBody(tableLayout, dtCandData.Rows[0]["DESIGNATION"].ToString());
            if (dtDivisions.Rows.Count != 0)
            {

                AddCellToBody(tableLayout, "Division  ");
                AddCellToBody(tableLayout, dtDivisions.Rows[0]["DIVISION"].ToString());

            }
            else
            {
                AddCellToBody(tableLayout, "Department ");
                AddCellToBody(tableLayout, dtCandData.Rows[0]["DEPARTMENT"].ToString());

            }
            if (dtCandData.Rows[0]["PASSPRT_NO"].ToString() != "")
            {
                AddCellToBody(tableLayout, "Passport No");
                AddCellToBody(tableLayout, dtCandData.Rows[0]["PASSPRT_NO"].ToString());
            }

            if (dtCandData.Rows[0]["Q_ID"].ToString() != "")
            {
                AddCellToBody(tableLayout, "Qatari ID No.  ");
                AddCellToBody(tableLayout, dtCandData.Rows[0]["Q_ID"].ToString());

            }
            if (dtCandData.Rows[0]["CNTRY_NAME"].ToString() != "")
            {
                AddCellToBody(tableLayout, "Nationality   ");
                AddCellToBody(tableLayout, dtCandData.Rows[0]["CNTRY_NAME"].ToString());

            }
            AddCellToBody(tableLayout, "Period of service  From ");
            AddCellToBody(tableLayout, joindt);
            AddCellToBody(tableLayout, " Period of service  To  ");
            AddCellToBody(tableLayout, levdt);


            string strConduct = dtCandData.Rows[0]["CONDUCT"].ToString();
            string strAttendancePerfo = dtCandData.Rows[0]["ATTDCPRFMNC"].ToString();
            string strTradePerfo = dtCandData.Rows[0]["TRADEPRFMNC"].ToString();
            if (strConduct != "")
            {
                AddCellToBody(tableLayout, "Conduct ");
                AddCellToBody(tableLayout, strConduct);

            }
            if (strAttendancePerfo != "")
            {
                AddCellToBody(tableLayout, "Attendance performance ");
                AddCellToBody(tableLayout, strAttendancePerfo);

            }
            if (strTradePerfo != "")
            {
                AddCellToBody(tableLayout, "Trade performance  ");
                AddCellToBody(tableLayout, strTradePerfo);

            }
            pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
            pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
           
            
        }


        pdfDoc.Add(tableLayout);
        PdfPTable tableLayout2 = new PdfPTable(2);

       


        pdfDoc.Add(tableLayout2);

        pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
        pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
        //pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));

        pdfDoc.Add(new Paragraph(new Chunk("For AL BALAGH TRADING & CONTRACTING CO. W.L.L.    ", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))));

        //pdfDoc.Add(new PdfPCell(new Phrase("  AL BALAGH TRADING & CONTRACTING CO. W.L.L.  SRINIVASAN VENKATESAN  General Manager", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, });

       
        pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
        pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
        pdfDoc.Add(new Paragraph(new Chunk("SRINIVASAN VENKATESAN ", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, BaseColor.BLACK))));
        pdfDoc.Add(new Paragraph(new Chunk("General Manager", FontFactory.GetFont("Times New Roman", 11, Font.BOLD, BaseColor.BLACK))));
        pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
       
        pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
        pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
        pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
        pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
        pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
        pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
        //pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
        //pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
        //pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
        //pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));

        PdfPTable footrtable = new PdfPTable(2);
        float[] headersBodyfootr = { 0, 100 };
        footrtable.SetWidths(headersBodyfootr);
        footrtable.WidthPercentage = 100;

        string strImageLocFooter = objCommonLibrary.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "quotation-footer.png";
        iTextSharp.text.Image imageFootr = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLocFooter));
        imageFootr.ScalePercent(PdfPCell.ALIGN_LEFT);
        imageFootr.ScaleToFit(520f, 60f);

        footrtable.AddCell(new PdfPCell(new Phrase(" ")) { Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_LEFT });
        footrtable.AddCell(new PdfPCell(imageFootr) { Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_LEFT });
        pdfDoc.Add(footrtable);


        pdfDoc.Close();

        Response.Write(pdfDoc);





        return pdfDoc.ToString();
    }
   //End Evm -27
    public string ConvertDataTableForPrint(DataTable dtCandData, DataTable dtReadDates, DataTable dtDivisions)
    {
        string s="ggghh";
        //    string datetm = DateTime.Now.ToString("dd-MM-yyyy");

        //    string joindt;
        //    string levdt;

        //    if (dtReadDates.Rows[0]["USR_JOIN_DATE"].ToString() != "")
        //    {
        //        joindt = dtReadDates.Rows[0]["USR_JOIN_DATE"].ToString();
        //    }
        //    else
        //    {
        //        joindt = dtReadDates.Rows[0]["USR_INS_DATE"].ToString();
        //    }
        //    if (dtReadDates.Rows[0]["LEVDATE"].ToString() != "")
        //    {
        //        levdt =dtReadDates.Rows[0]["LEVDATE"].ToString();
        //    }
        //    else
        //    {
        //        levdt = DateTime.Today.ToString("dd-MM-yyyy");
        //    }





        //    ////StringBuilder sb = new StringBuilder();


        //    ////{

        //    ////}






        //    ////string strHtml = "";
        //    ////strHtml += "<div class=\"top\">";


        //    ////strHtml += "<div style=\"width:100%\" class=\"col-lg-8 logo\"><img style=\"display: block;margin-left: auto;margin-right: auto;width: 50%;\" src=\"/CustomImages/Corporate Logos/quotation-header.png\"  />";
        //    ////strHtml += " </div>  <br> <br>";
        //    ////strHtml += "<div class=\"title\">";
        //    ////strHtml += "<table> <br> <tr>  <td><h3> Ref </h3></td>  <td><h3 style=\"margin-left: 15px \">" + ":   " + dtCandData.Rows[0]["EMPLOYEE_ID"].ToString() + "</h3></td>   </tr>";
        //    ////strHtml += "<tr>  <td style=\"width:10%\"> <h3> Date </h3> </td> <td> <h3 style=\"margin-left: 15px \"> " + ":   " + datetm + " </h3> </td>  </tr> </table> <br>";
        //    ////strHtml += "<span style=\"font-size:30px; font-family:font_two;font-weight:bold; color:#363636;\">EXPERIENCE CERTIFICATE<br/></span> </div>";
        //    ////strHtml += "<div class=\"content\" style=\"margin-top: 0px; height:68.5%\">";
        //    ////strHtml += "<h3>";

        //    ////if (dtCandData.Rows[0]["STAFF_WORKER"].ToString() == "0")         //staff
        //    ////{

        //    ////    string strPassport="";
        //    ////    string strQID="";
        //    ////    strHtml += " This is to certify that  <span class=\"font_bold\"> " + dtCandData.Rows[0]["EMPLOYEE"].ToString() + ", </span>";
        //    ////   //EVM-0024
        //    ////    if (dtCandData.Rows[0]["PASSPRT_NO"].ToString() != "" && dtCandData.Rows[0]["CNTRY_NAME"].ToString()!="")
        //    ////    {
        //    ////        strPassport = dtCandData.Rows[0]["CNTRY_NAME"].ToString() + " Passport No. " + dtCandData.Rows[0]["PASSPRT_NO"].ToString();
        //    ////    }
        //    ////    if(dtCandData.Rows[0]["Q_ID"].ToString() != "")
        //    ////    {
        //    ////        strQID=" ( QID "+dtCandData.Rows[0]["Q_ID"].ToString()+" )";
        //    ////    }
        //    ////    if(strPassport!="")
        //    ////        strHtml += "<span class=\"font_bold\"> holder of  " + strPassport + strQID + "   </span>  ";
        //    ////    //END
        //    ////    strHtml += "  has worked in our organization as <span class=\"font_bold\"> ''" + dtCandData.Rows[0]["DESIGNATION"].ToString() + "''  </span>  from " + joindt + " to " + levdt + "     ";
        //    ////    //EVM-0024
        //    ////     strHtml += " in our ";
        //    ////     int intCount = 0;
        //    ////    intCount= dtDivisions.Rows.Count;

        //    ////    if (dtDivisions.Rows.Count != 0)
        //    ////    {
        //    ////        if (dtDivisions.Rows.Count == 1)
        //    ////        {
        //    ////            strHtml += dtDivisions.Rows[0]["DIVISION"].ToString()+" Division";
        //    ////        }
        //    ////        else
        //    ////        {
        //    ////            for (int i = 0; i < dtDivisions.Rows.Count; i++)
        //    ////            {
        //    ////                strHtml += dtDivisions.Rows[i]["DIVISION"].ToString();
        //    ////                if (intCount != (i+1))
        //    ////                {
        //    ////                    strHtml += ", ";
        //    ////                }
        //    ////            }
        //    ////            strHtml += " Divisions";
        //    ////        }
        //    ////    }
        //    ////    else
        //    ////    {
        //    ////        strHtml += " in our " + dtCandData.Rows[0]["DEPARTMENT"].ToString() + " Department. ";

        //    ////    }
        //    ////    //END
        //    ////    strHtml += "<br><br> During the tenure he has discharged his duties well.    He left our organization on his own and wish him all success. ";
        //    ////    strHtml += "<br><br> <br> for <span class=\"font_bold\"> AL BALAGH TRADING & CONTRACTING CO. W.L.L. <br><br> <br> SRINIVASAN VENKATESAN <br> <h4 style=\"line-height: 0px;\">General Manager</h4> ";

        //    ////    strHtml += "</h3>";
        //    ////    strHtml += "<div style=\"margin:140px 0 0 94px; font-family:Verdana, Geneva, sans-serif; font-weight:600\"><span style=\"margin-left:366px;\"></span></div></div>";
        //    ////}

        //    ////else     //worker
        //    ////{


        //    ////    strHtml += "<table align=\"center\" style=\" width:90%;margin-left: 10px; border:2px solid;padding-left: 15px; \" >   <tr> <br>  <td style=\" width:35%;\">Name</td style=\" width:5%;\"> <td>: &nbsp&nbsp</td>  <td style=\" width:50%;\" class=\"font_bold\"> " + dtCandData.Rows[0]["EMPLOYEE"].ToString() + "</td>   </tr>";
        //    ////    strHtml += "<tr>  <td  >Empl. No.</td> <td>: &nbsp&nbsp</td> <td class=\"font_bold\">" +  dtCandData.Rows[0]["EMPLOYEE_ID"].ToString() + "</td>   </tr>";
        //    ////    strHtml += "<tr>  <td>Trade</td> <td>: &nbsp&nbsp</td>  <td class=\"font_bold\">" +  dtCandData.Rows[0]["DESIGNATION"].ToString() + "</td>   </tr>";
        //    ////    if (dtDivisions.Rows.Count != 0)
        //    ////    {
        //    ////        strHtml += "<tr>  <td>Division</td> <td>: &nbsp&nbsp</td>  <td>" + dtDivisions.Rows[0]["DIVISION"].ToString() + " </td>   </tr>";
        //    ////    }
        //    ////    else
        //    ////    {
        //    ////        strHtml += "<tr>  <td>Department</td> <td>: &nbsp&nbsp</td>  <td>" + dtCandData.Rows[0]["DEPARTMENT"].ToString() + " </td>   </tr>";
        //    ////    }
        //    ////    if (dtCandData.Rows[0]["PASSPRT_NO"].ToString() != "")
        //    ////    {
        //    ////        strHtml += "<tr>  <td>Passport No.</td> <td>: &nbsp&nbsp</td>  <td>" +  dtCandData.Rows[0]["PASSPRT_NO"].ToString() + "</td>   </tr>";
        //    ////    }

        //    ////    if (dtCandData.Rows[0]["Q_ID"].ToString() != "")
        //    ////    {
        //    ////        strHtml += "<tr>  <td>Qatari ID No.</td> <td>: &nbsp&nbsp</td>  <td>" +  dtCandData.Rows[0]["Q_ID"].ToString() + "</td>   </tr>";
        //    ////    }
        //    ////    if (dtCandData.Rows[0]["CNTRY_NAME"].ToString() != "")
        //    ////    {
        //    ////        strHtml += "<tr>  <td>Nationality.</td> <td>: &nbsp&nbsp</td>  <td> "+ dtCandData.Rows[0]["CNTRY_NAME"].ToString() + "</td>   </tr>";
        //    ////    }

        //    ////    strHtml += "<tr>  <td>Period of service</td> <td>: &nbsp&nbsp</td>  <td class=\"font_bold\">" + joindt + " to " + levdt + "</td>   </tr>";

        //    ////    string strConduct = dtCandData.Rows[0]["CONDUCT"].ToString();
        //    ////    string strAttendancePerfo = dtCandData.Rows[0]["ATTDCPRFMNC"].ToString();
        //    ////    string strTradePerfo = dtCandData.Rows[0]["TRADEPRFMNC"].ToString();
        //    ////    if (strConduct != "")
        //    ////    {
        //    ////        strHtml += "<tr>  <td>Conduct </td> <td>: &nbsp&nbsp</td>  <td class=\"font_bold\">" + strConduct + "</td>   </tr>";              
        //    ////    }
        //    ////    if(strAttendancePerfo!="")
        //    ////    {
        //    ////        strHtml += "<tr>  <td>Attendance performance </td> <td>: &nbsp&nbsp</td>  <td class=\"font_bold\">" + strAttendancePerfo + "</td>   </tr>";
        //    ////    }
        //    ////    if(strTradePerfo!="")
        //    ////    {
        //    ////        strHtml += "<tr>  <td>Trade performance </td> <td>: &nbsp&nbsp</td>  <td class=\"font_bold\">" + strTradePerfo + "</td> </tr>";
        //    ////    }

        //    ////    strHtml += "</table>";

        //    ////    strHtml += "<br>  for <span  class=\"font_bold\"> AL BALAGH TRADING & CONTRACTING CO. W.L.L. <br><br> SRINIVASAN VENKATESAN <br> <h4 style=\"line-height: 0px;\">General Manager</h4> ";
        //    ////    strHtml += "</h3><br><br>";
        //    ////}


        //    ////strHtml += "<div class=\"col-lg-12 footer_div\"><img src=\"/CustomImages/Corporate Logos/quotation-footer.png\" width=\"100%\" /> ";
        //    ////strHtml += "</page>";


        //    ////sb.Append(strHtml);
        //    ////return sb.ToString();
        return s;

}

    private static void AddCellToBody(PdfPTable tableLayout, string cellText)
    {
         //FontFactory.GetFont("Times New Roman", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, });
        tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.TIMES_ROMAN, 13,0, iTextSharp.text.BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_JUSTIFIED, Padding = 5, BackgroundColor = iTextSharp.text.BaseColor.WHITE });

    }

}

