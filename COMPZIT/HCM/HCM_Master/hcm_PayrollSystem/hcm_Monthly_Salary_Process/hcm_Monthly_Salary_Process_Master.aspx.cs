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
using System.IO;

// CREATED BY:EVM-0008
// CREATED DATE:10/30/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_Process_hcm_Monthly_Salary_Process_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            HiddenSalaryDedctnId.Value = "";
            HiddnEnableCacel.Value = "1";
          //  Session["SALARPRSS"] = null;
            int intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);


            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


                // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

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

            if (Session["SALAR_PRSS_EDIT"] != null)
            {
                string Employename = "", Paygrd = "", Desg = "",Month="",year="";
                cls_Entity_Monthly_Salary_Process objEntPrcss = new cls_Entity_Monthly_Salary_Process();
                var strSALARPRSS = Session["SALAR_PRSS_EDIT"];
                string[] ProssId = strSALARPRSS.ToString().Split('~');
                objEntPrcss.UserId =Convert.ToInt32(ProssId[0]);
                HiddenEmployeeMasterId.Value = ProssId[0];
                HiddenPaygrdId.Value = ProssId[1];
                HiddenPayGrdeId.Value = ProssId[1];
                HiddenTotalPerBasic.Value = ProssId[2];
                HiddenSalarSummry.Value = ProssId[2];
                HiddenEmpSalryId.Value = ProssId[3];
                string[] empDtls = ProssId[4].Split('|');
               // string[] MonthYr = ProssId[5].Split('|');
                Employename = empDtls[0];
                lblCandtName.Text = Employename;
                Paygrd = empDtls[2];
                lblResume.Text = Paygrd;
                Desg = empDtls[1];
                lblRefEmp.Text = Desg;
                Month = empDtls[3];
                year = empDtls[4];
               string monthname= CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(Month));
               lblLoctn.Text = monthname.ToUpper() + " " + year;
                }
           
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

            // for adding comma
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusiness.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
            }
        }

    }
    protected void btnAdd_Addtn_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        cls_Business_Monthly_Salary_Process objEmpSalary = new cls_Business_Monthly_Salary_Process();
        int intUserId = 0, intUsrRolMstrId = 0, intEnableCancel = 0;

    

            if (Session["CORPOFFICEID"] != null)
            {

                objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        

        if (Session["ORGID"] != null)
        {
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //must change when integrating
        objEntityEmpSlary.EmplyUserId = Convert.ToInt32(HiddenEmployeeMasterId.Value);

        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(HiddenPayGrdeId.Value);
    
        objEntityEmpSlary.EmpSalaryId = Convert.ToInt32(HiddenEmpSalryId.Value);

        objEntityEmpSlary.AlownceId = Convert.ToInt32(HiddenddlAllDed.Value);
      
        objEntityEmpSlary.AmountRangeFrm = Convert.ToDecimal(txtAmntRgeFrm.Text.Trim());

        //string strdupAllownce = "";
      //  strdupAllownce = objEmpSalary.DuplCheckSalaryAllownce(objEntityEmpSlary);
       // if (strdupAllownce == "" || strdupAllownce == "0")
      //  {
            objEmpSalary.AddSalaryAddnAllownce(objEntityEmpSlary);

            Session["MESSGSALARY"] = "SAVEALLOW";

            int Paygdid = Convert.ToInt32(HiddenPayGrdeId.Value);

            //if (clickedButton.ID == "SaveAddtn")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationAllwnce", "SuccessConfirmationAllwnce(" + Paygdid + ");", true);
            //}
            //else if (clickedButton.ID == "btnAddClose")
            //{
            //    //Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Ins");
            //}
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationSalaryAllwnce", "DuplicationSalaryAllwnce();", true);
        //}
        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);
        Response.Redirect("hcm_Monthly_Salary_Process_Master.aspx?");
        // ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);

    }
    protected void btnAdd_Dedctn_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        cls_Business_Monthly_Salary_Process objEmpSalary = new cls_Business_Monthly_Salary_Process();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }

        if (Session["ORGID"] != null)
        {
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

       
        objEntityEmpSlary.EmplyUserId = Convert.ToInt32(HiddenEmployeeMasterId.Value);


        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(HiddenPayGrdeId.Value);
        //objEntityEmpSlary.NextIdForPayGrade = 381624;
        objEntityEmpSlary.EmpSalaryId = Convert.ToInt32(HiddenEmpSalryId.Value);






        objEntityEmpSlary.DedctnId = Convert.ToInt32(HiddenddlAllDed.Value);
        //if (ddldedctn.SelectedItem.Value.ToString() != "--SELECT SALARY DEDUCTION--")
        //{
        //    objEntityPaygrd.SlaryDedctnId = Convert.ToInt32(ddldedctn.SelectedItem.Value);
        //}
        if (radAmnt.Checked == true)
        {
            objEntityEmpSlary.PercOrAmountChk = 0;
            objEntityEmpSlary.AmountRangeFrm = Convert.ToDecimal(txtAmntRedcnFrom.Text.Trim());

        }
        else if (radPercntge.Checked == true)
        {
            objEntityEmpSlary.PercOrAmountChk = 1;
            objEntityEmpSlary.Percentge = Convert.ToDecimal(txtperctg.Text.Trim());
        }
        if (radioBascPay.Checked == true)
        {
            objEntityEmpSlary.BasicOrTotalAmtChk = 0;
        }
        else if (radioTotlAmnt.Checked == true)
        {
            objEntityEmpSlary.BasicOrTotalAmtChk = 1;
        }
        string strdupAllownce = "";
       // strdupAllownce = objEmpSalary.DuplCheckSalaryDedctn(objEntityEmpSlary);
        //if (strdupAllownce == "" || strdupAllownce == "0")
        //{
            objEmpSalary.AddSalaryDedction(objEntityEmpSlary);



            int Paygdid = Convert.ToInt32(HiddenPayGrdeId.Value);
            Session["MESSGSALARY"] = "SAVEDEDCTN";
            //if (clickedButton.ID == "SaveDedctn")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationDedctn", "SuccessConfirmationDedctn(" + Paygdid + ");", true);
            //}
            //else if (clickedButton.ID == "btnAddClose")
            //{
            //    //Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Ins");
            //}
      //  }
      //  else
      //  {
       //     ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationSalaryDedctn", "DuplicationSalaryDedctn();", true);
      //  }
        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);
        Response.Redirect("hcm_Monthly_Salary_Process_Master.aspx?");
        //  ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);

    }

    //SALARY DETAILS
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {

        //Creating objects for business layer
        cls_Business_Monthly_Salary_Process objEmpSalary = new cls_Business_Monthly_Salary_Process();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityEmpSlary.D_Date = System.DateTime.Now;

            objEntityEmpSlary.Cancel_reason = txtCnclReason.Text.Trim();


            int Paygdid = Convert.ToInt32(HiddenPayGrdeId.Value);
            if (HiddenDelChk.Value == "0")
            {
                objEmpSalary.CancelAllownce(objEntityEmpSlary);
                txtCnclReason.Text = "";
                Session["MESSGSALARY"] = "SAVEDEL";
               // ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelationAllwnce", "SuccessCancelationAllwnce(" + Paygdid + ");", true);
            }
            if (HiddenDelChk.Value == "1")
            {
                objEmpSalary.CancelDedctn(objEntityEmpSlary);
                txtCnclReason.Text = "";
                Session["MESSGSALARY"] = "SAVEDELL";
                //ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelationDedctn", "SuccessCancelationDedctn(" + Paygdid + ");", true);
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

            //ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);

            Response.Redirect("hcm_Monthly_Salary_Process_Master.aspx?");

        }
    }
    //SALARY DETAILS

    protected void btnUpdate_Addtn_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        cls_Business_Monthly_Salary_Process objEmpSalary = new cls_Business_Monthly_Salary_Process();
        int intUserId = 0, intUsrRolMstrId = 0, intEnableCancel = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }

        if (Session["ORGID"] != null)
        {
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityEmpSlary.D_Date = DateTime.Now;
        if (HiddenEmpSalryId.Value != "")
        {
            objEntityEmpSlary.EmpSalaryId = Convert.ToInt32(HiddenEmpSalryId.Value);
        }
        objEntityEmpSlary.SalaryAllwnceId = Convert.ToInt32(HiddenSalaryAllwceId.Value);

        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(HiddenPayGrdeId.Value);

        objEntityEmpSlary.AlownceId = Convert.ToInt32(HiddenddlAllDed.Value);

        //if (ddlAddtn.SelectedItem.Value.ToString() != "--SELECT SALARY ADDITION--")
        //{
        //    objEntityPaygrd.SalaryAllwnceId = Convert.ToInt32(ddlAddtn.SelectedItem.Value);
        //}
        objEntityEmpSlary.AmountRangeFrm = Convert.ToDecimal(txtAmntRgeFrm.Text.Trim());

       // string strdupAllownce = "";
       // strdupAllownce = objEmpSalary.DuplCheckSalaryAllownce(objEntityEmpSlary);
       // if (strdupAllownce == "" || strdupAllownce == "0")
      //  {
            objEmpSalary.UpdSalaryAddnAllownce(objEntityEmpSlary);


            int Paygdid = Convert.ToInt32(HiddenPayGrdeId.Value);

            Session["MESSGSALARY"] = "UPDADDTN";

          //  if (clickedButton.ID == "UpdateAddtn")
          //  {
              //  ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePayGradeAllwnce", "UpdatePayGradeAllwnce(" + Paygdid + ");", true);
          //  }
            //else if (clickedButton.ID == "btnAddClose")
            //{
              
            //}
       // }
      //  else
      //  {
      //      ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationSalaryAllwnce", "DuplicationSalaryAllwnce();", true);
     //   }
        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);
        Response.Redirect("hcm_Monthly_Salary_Process_Master.aspx?");
        // ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);
    }

    protected void btnUpdate_Dedctn_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        //  HiddenTotalpay.value=
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        cls_Business_Monthly_Salary_Process objEmpSalary = new cls_Business_Monthly_Salary_Process();
        int intUserId = 0, intUsrRolMstrId = 0, intEnableCancel = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }

        if (Session["ORGID"] != null)
        {
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityEmpSlary.D_Date = DateTime.Now;
        if (HiddenEmpSalryId.Value != "")
        {
            objEntityEmpSlary.EmpSalaryId = Convert.ToInt32(HiddenEmpSalryId.Value);
        }
        objEntityEmpSlary.SlaryDedctnId = Convert.ToInt32(HiddenSalaryDedctnId.Value);

        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(HiddenPayGrdeId.Value);

        objEntityEmpSlary.DedctnId = Convert.ToInt32(HiddenddlAllDed.Value);


        // objEntityPaygrd.NextIdForPayGrade = Convert.ToInt32(HiddenPayGrdeId.Value);
        //if (ddldedctn.SelectedItem.Value.ToString() != "--SELECT SALARY DEDUCTION--")
        //{
        //    objEntityPaygrd.SlaryDedctnId = Convert.ToInt32(ddldedctn.SelectedItem.Value);
        //}
        if (radAmnt.Checked == true)
        {
            objEntityEmpSlary.PercOrAmountChk = 0;
            objEntityEmpSlary.AmountRangeFrm = Convert.ToDecimal(txtAmntRedcnFrom.Text.Trim());

        }
        else if (radPercntge.Checked == true)
        {
            objEntityEmpSlary.PercOrAmountChk = 1;
            objEntityEmpSlary.Percentge = Convert.ToDecimal(txtperctg.Text.Trim());
        }
        if (radioBascPay.Checked == true)
        {
            objEntityEmpSlary.BasicOrTotalAmtChk = 0;
        }
        else if (radioTotlAmnt.Checked == true)
        {
            objEntityEmpSlary.BasicOrTotalAmtChk = 1;
        }
       // string strdupAllownce = "";
       // strdupAllownce = objEmpSalary.DuplCheckSalaryDedctn(objEntityEmpSlary);
       // if (strdupAllownce == "" || strdupAllownce == "0")
      //  {
            objEmpSalary.UpdateSalaryDedction(objEntityEmpSlary);



            int Paygdid = Convert.ToInt32(HiddenPayGrdeId.Value);
            Session["MESSGSALARY"] = "UPDDEDTN";

        //    if (clickedButton.ID == "UpdateDedctn")
          //  {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePayGradeDedctn", "UpdatePayGradeDedctn(" + Paygdid + ");", true);
        //    }
            //else if (clickedButton.ID == "btnAddClose")
            //{
            //    //Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Ins");
            //}
       // }
       // else
      //  {
         //   ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationSalaryDedctn", "DuplicationSalaryDedctn();", true);
      //  }
        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);
        Response.Redirect("hcm_Monthly_Salary_Process_Master.aspx?");
        // ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageDed", "LoadListPageDed();", true);
    }


    public class ConvrtDataTable
    {
        public int SalaryAllwceId = 0;
        public int PaygrdId = 0;
        public int AllowceId = 0;
        public int DedctnId = 0;
        public decimal FrmAmount = 0;
        public decimal Toamount = 0;
        public int ddlselectedVal = 0;
        public int sts = 0;
        public int RestrctSts = 0;
        public decimal Perctgeamnt = 0;
        public int PerOrAmntck = 0;
        public int BasicOrTotl = 0;
        public string strhtml = "";
        public string strSummry = "";
        public int ddlBinding = 0;
        public string ddltext = "";
        public string strperct = "";
        public string strCurrcAbbrv = "";
        public string Amnt = "";
        public string strPerFromTotal = "0";
        public string strPerFromBasic = "0";
        //It build the Html table by using the datatable provided

        public string SalaryPerctTotal(DataTable dt, string AllwOrDed)
        {
            string strStatusMode = ""; decimal perctotalFromTotal = 0, perctotalFromBasic = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strStatusMode = dt.Rows[intRowBodyCount][4].ToString();

                if (AllwOrDed == "1")
                {
                    int PerORAmntchk = 0, TotalAmountBsic = 1;
                    PerORAmntchk = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString());
                    TotalAmountBsic = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString());

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {

                        if (PerORAmntchk == 1)
                        {
                            if (intColumnBodyCount == 3)
                            {
                                if (strStatusMode == "1")
                                {
                                    // count++;
                                    if (TotalAmountBsic == 1)
                                        perctotalFromTotal = perctotalFromTotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                                    else if (TotalAmountBsic == 0)
                                        perctotalFromBasic = perctotalFromBasic + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                                }

                            }
                        }

                      



                    }
                }
            }
            string strPerTotal = perctotalFromTotal.ToString() + "-" + perctotalFromBasic.ToString();

            return strPerTotal;
        }

        public string SalarySummary(DataTable dt, string AllwOrDed)
        {

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            //objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);


            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            Decimal totalAmntFrm = 0, totalAmntTo = 0, perctotal = 0;
            int count = 0;
            var strStatusMode = "";
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
               
                if (AllwOrDed == "0")
                {
                    strStatusMode = dt.Rows[intRowBodyCount][3].ToString();
                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                        if (intColumnBodyCount == 2)
                        {
                            if (strStatusMode == "1")
                            {
                                count++;

                                string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                                totalAmntFrm = totalAmntFrm + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                            }

                        }

                    



                    }
                }
                else if (AllwOrDed == "1")
                {
                    strStatusMode = dt.Rows[intRowBodyCount][4].ToString();
                    int PerORAmntchk = 0;
                    PerORAmntchk = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString());

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                        if (PerORAmntchk == 0)
                        {
                            if (intColumnBodyCount == 2)
                            {
                                if (strStatusMode == "1"  )
                                {
                                    count++;

                                    totalAmntFrm = totalAmntFrm + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                                }

                            }
                        }
                        else if (PerORAmntchk == 1)
                        {
                            if (intColumnBodyCount == 3)
                            {
                                if (strStatusMode == "1")
                                {
                                    // count++;

                                    perctotal = perctotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                                }

                            }
                        }

                  



                    }
                }
            }
            string NetAmountWithCommaTo = "0";
            string stramntSummary = "0";
         
            string NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(totalAmntFrm.ToString(), objEntityCommon);
            //NetAmountWithCommaTo = objBusiness.AddCommasForNumberSeperation(totalAmntTo.ToString(), objEntityCommon);
            string strabbrv = "";
            if (dt.Rows.Count > 0)
            {
                strabbrv = dt.Rows[0]["CRNCMST_ABBRV"].ToString();
            }
            stramntSummary = NetAmountWithCommaFrm + " " + strabbrv;
            // }

            return stramntSummary;
        }

        public string ConvertDataTableToHTML(DataTable dt, int intEnableCancel, string CurrcyId, string AllwOrDed)
        {
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            //objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);


            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "";

            if (AllwOrDed == "0")
            {
                strHtml = "<table id=\"ReportTableAllow\" class=\"table table-striped table-bordered\" cellspacing=\"0\" cellpadding=\"2px\" >";
            }
            if (AllwOrDed == "1")
            {
                strHtml = "<table id=\"ReportTableDedtn\" class=\"table table-striped table-bordered\" cellspacing=\"0\" cellpadding=\"2px\" >";
            }

            //add header row
            strHtml += "<thead>";
            strHtml += "<tr >";

            int intReCallForTAble = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

                if (intCnclUsrId != 0)
                {
                    intReCallForTAble = 1;
                }

            }
            //  strHtml += "<th class=\"thT\" style=\"width:4%;text-align: left; word-wrap:break-word;\">SL#</th>";
            if (AllwOrDed == "0")
            {
                for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
                {

                    if (intColumnHeaderCount == 1)
                    {
                        strHtml += "<th class=\"hasinput\" style=\"width:26%;text-align: left; word-wrap:break-word;\">ADDITION</th>";
                    }

                    else if (intColumnHeaderCount == 2)
                    {
                        strHtml += "<th class=\"hasinput\" style=\"width:24%;text-align: right; word-wrap:break-word;\">AMOUNT </th>";
                    }



                }
            }
            else if (AllwOrDed == "1")
            {

                for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
                {

                    if (intColumnHeaderCount == 1)
                    {
                        strHtml += "<th class=\"hasinput\" style=\"width:26%;text-align: left; word-wrap:break-word;\">DEDUCTION</th>";
                    }

                    else if (intColumnHeaderCount == 2)
                    {
                        strHtml += "<th class=\"hasinput\"  style=\"width:24%;text-align: right; word-wrap:break-word;\">PERCENTAGE/AMOUNT </th>";
                    }



                }
            }
            //if (intReCallForTAble == 0)
            //{
            //    strHtml += "<th class=\"hasinput\" style=\"width:4%; word-wrap:break-word;text-align: center;\">STATUS</th>";
            //}


            //if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            //{
            if (intReCallForTAble == 0)
            {

                strHtml += "<th class=\"hasinput\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            }
            else
            {
                strHtml += "<th class=\"hasinput\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
            }
            // }
            if (intReCallForTAble == 0)
            {
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    strHtml += "<th class=\"hasinput\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";
                }
            }



            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows

            strHtml += "<tbody>";
            string amountFrm = "", amountTo = "";
            float totalAmntFrm = 0, totalAmntTo = 0;
            int count = 0;
            int intSlno = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string strStatusMode = "";
                int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
                int intCancTransaction = 0;
                    //Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

                strHtml += "<tr  >";
                intSlno = Convert.ToInt32(intRowBodyCount.ToString());
                intSlno++;
                //   strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + intSlno.ToString() + "</td>";
                if (AllwOrDed == "0")
                {

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                        //if (j == 0)
                        //{
                        //    int intCnt = i + 1;
                        //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                        //}

                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:26%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 2)
                        {
                            count++;
                            //strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                            amountFrm = strNetAmountWithComma;
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + amountFrm + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                        }




                    }
                }
                else if (AllwOrDed == "1")
                {
                    int PerORAmntchk = 0;
                    PerORAmntchk = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString());

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:26%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                      

                        else if (intColumnBodyCount == 2)
                        {
                            if (PerORAmntchk == 0)
                            {
                                string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                                amountFrm = strNetAmountWithComma;
                                strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + amountFrm + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                            }
                        }
                        else if (intColumnBodyCount == 3)
                        {
                            if (PerORAmntchk == 1)
                            {
                                string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                                strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma + " " + "%" + "</td>";
                            }
                        }


                    }
                }

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                strStatusMode = dt.Rows[intRowBodyCount][4].ToString();


                //if (intCnclUsrId == 0)
                //{
                //    if (strStatusMode == "ACTIVE")
                //    {
                //        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"cursor:pointer;opacity: 1;margin-left: 1.8%;margin-top: -1.5%;z-index: 99;\" class=\"tooltip\"  title=\"Make Inactive\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "','" + AllwOrDed + "');\" >" +
                //            "<img   src='../../Images/Icons/activate.png' /> " + "</a> </td>";

                //    }
                //    else
                //    {
                //        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"cursor:pointer;opacity: 1;margin-left: 1.8%;margin-top: -1.5%;z-index: 99;\" class=\"tooltip\" title=\" Make Active\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "','" + AllwOrDed + "');\" >" +
                //          "<img   src='../../Images/Icons/inactivate.png' /> " + "</a> </td>";
                //    }
                //}
          


                //if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                if (AllwOrDed == "0")
                {
                    //{
                    if (intCnclUsrId == 0)
                    {


                        //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"cursor:pointer;opacity: 1;margin-left: 1.1%;margin-top: -1.5%;z-index: 99;\" class=\"tooltip\" title=\"Edit\" onclick=\"return getdetailsAllwceById('" + strId + "');\" >" +
                        //     "<img  style=\"cursor:pointer\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";

                        strHtml += " <td style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" title=\"EDIT\"   onclick=\"return getdetailsAllwceById('" + strId + "');\"><i class=\"fa fa-pencil\"></i></button></td>";


                    }

                    else
                    {
                        //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"cursor:pointer;opacity: 1;margin-left: 1.1%;margin-top: -1.2%;z-index: 99;\" class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                        // " href=\"gen_Pay_Grade_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='../../Images/Icons/view.png' /> " + "</a> </td>";

                        strHtml += " <td style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" title=\"VIEW\" data-original-title=\"Edit Row\"  onclick='return getdetails(this.href);'><i class=\"fa fa-eye\"></i></button></td>";
                    }
                }
                else if (AllwOrDed == "1")
                {

                    if (intCnclUsrId == 0)
                    {


                        //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"cursor:pointer;opacity: 1;margin-left: 1.8%;margin-top: -1.5%;z-index: 99;\" class=\"tooltip\" title=\"Edit\" onclick=\"return getdetailsDedctnById('" + strId + "');\" >" +
                        //     "<img  style=\"cursor:pointer\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";

                        strHtml += " <td style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" title=\"EDIT\" onclick=\"return getdetailsDedctnById('" + strId + "');\" ><i class=\"fa fa-pencil\"></i></button></td>";


                    }

                    else
                    {
                        //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"cursor:pointer;opacity: 1;margin-left: 2.0%;margin-top: -1.5%;z-index: 99;\" class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                        // " href=\"gen_Pay_Grade_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='../../Images/Icons/view.png' /> " + "</a> </td>";
                        strHtml += " <td style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" title=\"VIEW\"  onclick='return getdetails(this.href);' ><i class=\"fa fa-eye\"></i></button></td>";

                    }
                }
                //}
                if (intReCallForTAble == 0)
                {
                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (intCnclUsrId == 0)
                        {
                            if (intCancTransaction == 0)
                            {
                             

                                //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"cursor:pointer;opacity: 1;margin-left: 2.8%;margin-top: -1.5%;z-index: 99;\" class=\"tooltip\" title=\"Delete\" onclick=\"return CancelAlertAllwceById('" + strId + "','" + AllwOrDed + "');\" >" +
                                //  "<img  style=\"cursor:pointer\" src='../../Images/Icons/delete.png' /> " + "</a> </td>";
                                strHtml += " <td style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" title=\"DELETE\"  onclick=\"return CancelAlertAllwceById('" + strId + "','" + AllwOrDed + "');\" ><i class=\"fa fa-trash\"></i></button></td>";
                               
                            }
                            else
                            {

                                //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"cursor:pointer;opacity: 1;margin-left: 1%;margin-top: -1%;z-index: 99;\" class=\"tooltip\" title=\"Delete\" onclick='return CancelNotPossible();' >"
                                //        + "<img style=\"opacity: 0.2;cursor: pointer; \" src='../../Images/Icons/delete.png' /> " + "</a> </td>";
                                strHtml += " <td style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" title=\"DELETE\"  onclick='return CancelNotPossible();' );\" ><i class=\"fa fa-trash\"></i></button></td>";
                            }



                        }
                        else
                        {

                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                        }
                    }
                }



                strHtml += "</tr>";
            }

            // HiddenAmountRnge.Value = amountTo;

            strHtml += "</tbody>";

            strHtml += "</table>";



            sb.Append(strHtml);
            return sb.ToString();
        }
    }
    [WebMethod]
    public static ConvrtDataTable CheckForRestriction(string ddlAddtnValue, string Orgid, string CorpId, string AllwOrDed)
    {

        cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();
        int AmntFrm = 0, AmountTo = 0;
        string Amnt = "";
        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(ddlAddtnValue);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Orgid);
        DataTable dtCorpDetail = new DataTable();
     
         if (AllwOrDed == "1")
        {
            dtCorpDetail = objBuss.AllowncRestrictionChk(objEntityEmpSlary);
            if (dtCorpDetail.Rows.Count > 0)
            {
                objConvrtDataTable.Amnt = dtCorpDetail.Rows[0]["PGALLCE_RANGE_FRM"].ToString() + "," + dtCorpDetail.Rows[0]["PGALLCE_RANGE_TO"].ToString() + "," + dtCorpDetail.Rows[0]["PGALLCE_RANGE_RESTRICT_STS"].ToString();

            }
        }
        else if (AllwOrDed == "2")
        {
            dtCorpDetail = objBuss.DedctnRestrictionChk(objEntityEmpSlary);
            if (dtCorpDetail.Rows.Count > 0)
            {
                objConvrtDataTable.Amnt = dtCorpDetail.Rows[0]["PGDEDTN_RANGE_FRM"].ToString() + "," + dtCorpDetail.Rows[0]["PGDEDTN_RANGE_TO"].ToString() + "," + dtCorpDetail.Rows[0]["PGDEDTN_RANGE_RESTRICT_STS"].ToString();
            }
        }


        return objConvrtDataTable;
    }
    [WebMethod]
    public static string Loadallwceddl(int ddlpygdeValue, int Orgid, int CorpId)
    {
        cls_Business_Monthly_Salary_Process objEmpSalary = new cls_Business_Monthly_Salary_Process();
      //  clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();

        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(ddlpygdeValue);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Orgid);
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objEmpSalary.ReadAddnLoad(objEntityEmpSlary);
        dtCorpDetail.TableName = "dtTableAllwnce";
        string result = "";
        if (dtCorpDetail.Rows.Count > 0)
        {
            using (StringWriter sw = new StringWriter())
            {
                dtCorpDetail.WriteXml(sw);
                result = sw.ToString();
            }
        }

        return result;
    }

    [WebMethod]
    public static string LoadDedctionddl(int ddlpygdeValue, int Orgid, int CorpId)
    {
        cls_Business_Monthly_Salary_Process objEmpSalary = new cls_Business_Monthly_Salary_Process();
       // clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();

        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(ddlpygdeValue);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Orgid);
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objEmpSalary.ReadDedctnLoad(objEntityEmpSlary);
        dtCorpDetail.TableName = "dtTableDedctn";
        string result = "";
        if (dtCorpDetail.Rows.Count > 0)
        {
            using (StringWriter sw = new StringWriter())
            {
                dtCorpDetail.WriteXml(sw);
                result = sw.ToString();
            }
        }

        return result;
    }



    [WebMethod]
    public static ConvrtDataTable LoadListPageallwncee(string EnableCanl, string CurrcyId, string CorpId, string OrgId, string varddlAddtn, string salProssId)
    {
        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();
       // clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        cls_Business_Monthly_Salary_Process objEmpSalary = new cls_Business_Monthly_Salary_Process();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        DataTable dtContract = new DataTable();
        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        string AllwOrDed = "0";
        objEntityEmpSlary.EmplyUserId = Convert.ToInt32(varddlAddtn);
        dtContract = objEmpSalary.ReadAllounceListEdit(objEntityEmpSlary,salProssId);



        string htrm = "";
        int EnableCancel = Convert.ToInt32(EnableCanl);
        objConvrtDataTable.strhtml = objConvrtDataTable.ConvertDataTableToHTML(dtContract, EnableCancel, CurrcyId, AllwOrDed);
        objConvrtDataTable.strSummry = objConvrtDataTable.SalarySummary(dtContract, AllwOrDed);
        return objConvrtDataTable;
    }

    [WebMethod]
    public static ConvrtDataTable LoadListPageDed(string EnableCanl, string CurrcyId, string CorpId, string OrgId, string varddlAddtn, string salProssId)
    {
        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();
       // clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        cls_Business_Monthly_Salary_Process objEmpSalary = new cls_Business_Monthly_Salary_Process();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        DataTable dtContract = new DataTable();
        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        string AllwOrDed = "1";
        objEntityEmpSlary.EmplyUserId = Convert.ToInt32(varddlAddtn);
        dtContract = objEmpSalary.ReadDeductionListEdit(objEntityEmpSlary, salProssId);

        string htrm = "";
        int EnableCancel = Convert.ToInt32(EnableCanl);

        objConvrtDataTable.strhtml = objConvrtDataTable.ConvertDataTableToHTML(dtContract, EnableCancel, CurrcyId, AllwOrDed);
        objConvrtDataTable.strSummry = objConvrtDataTable.SalarySummary(dtContract, AllwOrDed);
        string totalper = objConvrtDataTable.SalaryPerctTotal(dtContract, AllwOrDed);
        string[] strtotalper = totalper.Split('-');
        objConvrtDataTable.strPerFromTotal = strtotalper[0];
        objConvrtDataTable.strPerFromBasic = strtotalper[1];

        return objConvrtDataTable;
    }




 
    [WebMethod]
    public static ConvrtDataTable ReadAllwceById(string x, string CorpId, string OrgId)
    {
        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();

       // clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        cls_Business_Monthly_Salary_Process objEmpSalary = new cls_Business_Monthly_Salary_Process();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(x);
        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        DataTable dtAllwce = objEmpSalary.ReadAllounceById(objEntityEmpSlary);
        if (dtAllwce.Rows.Count > 0)
        {
            objConvrtDataTable.SalaryAllwceId = Convert.ToInt32(dtAllwce.Rows[0]["SLRYPROSALLCE_ID"].ToString());
            // objConvrtDataTable.AllowceId = Convert.ToInt32(dtAllwce.Rows[0]["PGALLCE_ID"].ToString());
            objConvrtDataTable.ddltext = dtAllwce.Rows[0]["PAYRL_NAME"].ToString();
            objConvrtDataTable.ddlselectedVal = Convert.ToInt32(dtAllwce.Rows[0]["PGALLCE_ID"].ToString());
            objConvrtDataTable.FrmAmount = Convert.ToDecimal(dtAllwce.Rows[0]["AMOUNTFRM"].ToString());
            objConvrtDataTable.PaygrdId = Convert.ToInt32(dtAllwce.Rows[0]["PYGRD_ID"].ToString());

            if (dtAllwce.Rows[0]["PGALLCE_STATUS"].ToString() == "1" && dtAllwce.Rows[0]["PGALLCE_CNCL_USR_ID"].ToString() == "")
            {
                objConvrtDataTable.ddlBinding = 0;
            }
            else
            {

                objConvrtDataTable.ddlBinding = 1;
            }
        }
        return objConvrtDataTable;
    }
    [WebMethod]
    public static int CancelAlertAllwceById(string x, string userId, string CorpId, string AllwOrDed)
    {
        int intuserId = Convert.ToInt32(userId);
        int intCorpId = Convert.ToInt32(CorpId);
        int ret = 0;
       // clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        cls_Business_Monthly_Salary_Process objEmpSalary = new cls_Business_Monthly_Salary_Process();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(x);
        objEntityEmpSlary.User_Id = intuserId;

        objEntityEmpSlary.D_Date = System.DateTime.Now;

        if (dtCorpDetail.Rows.Count > 0)
        {
            // string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            string CnclrsnMust = "0";
            if (CnclrsnMust == "0")
            {

                objEntityEmpSlary.Cancel_reason = objCommon.CancelReason();
                if (AllwOrDed == "0")
                {
                    ret = 0;
                    objEmpSalary.CancelAllownce(objEntityEmpSlary);
                }
                if (AllwOrDed == "1")
                {
                    ret = 1;
                    objEmpSalary.CancelDedctn(objEntityEmpSlary);
                }


            }
            else
            {

                ret = 1;
            }
        }

        return ret;
    }

    [WebMethod]
    public static ConvrtDataTable ReadDedctnId(string x, string CorpId, string OrgId)
    {
        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();
       // clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        cls_Business_Monthly_Salary_Process objEmpSalary = new cls_Business_Monthly_Salary_Process();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(x);
        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        DataTable dtAllwce = objEmpSalary.ReadDedctnById(objEntityEmpSlary);
        if (dtAllwce.Rows.Count > 0)
        {
            objConvrtDataTable.SalaryAllwceId = Convert.ToInt32(dtAllwce.Rows[0]["SLRYPROSDEDTN_ID"].ToString());
            // objConvrtDataTable.AllowceId = Convert.ToInt32(dtAllwce.Rows[0]["PGALLCE_ID"].ToString());
            objConvrtDataTable.ddltext = dtAllwce.Rows[0]["PAYRL_NAME"].ToString();
            objConvrtDataTable.ddlselectedVal = Convert.ToInt32(dtAllwce.Rows[0]["PGDEDTN_ID"].ToString());
            objConvrtDataTable.FrmAmount = Convert.ToDecimal(dtAllwce.Rows[0]["AMOUNTFRM"].ToString());
            objConvrtDataTable.PaygrdId = Convert.ToInt32(dtAllwce.Rows[0]["PYGRD_ID"].ToString());
            if (Convert.ToInt32(dtAllwce.Rows[0]["SLRYPROSDEDTN_AMNT_PERCTGE"].ToString()) == 1)
            {
                objConvrtDataTable.strperct = dtAllwce.Rows[0]["PERC"].ToString();
            }
            objConvrtDataTable.BasicOrTotl = Convert.ToInt32(dtAllwce.Rows[0]["SLRYPROSDEDTN_BSIC_TOTL_AMNT"].ToString());
            objConvrtDataTable.PerOrAmntck = Convert.ToInt32(dtAllwce.Rows[0]["SLRYPROSDEDTN_AMNT_PERCTGE"].ToString());
            if (dtAllwce.Rows[0]["PGDEDTN_STATUS"].ToString() == "1" && dtAllwce.Rows[0]["SLRYPROSDEDTN_CNCL_USR_ID"].ToString() == "")
            {
                objConvrtDataTable.ddlBinding = 0;
            }
            else
            {

                objConvrtDataTable.ddlBinding = 1;
            }


        }
        return objConvrtDataTable;
    }

    


        
    [WebMethod]
    public static string CheckForDupAllow(string EmpId, string PaygrdId, string SalId, string AllowId, string Orgid, string CorpId, string AlloId)
    {
        cls_Business_Monthly_Salary_Process objEmpSalary = new cls_Business_Monthly_Salary_Process();
       // clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        string result = "0";
        objEntityEmpSlary.EmplyUserId = Convert.ToInt32(EmpId);

        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(PaygrdId);

        objEntityEmpSlary.EmpSalaryId = Convert.ToInt32(SalId);

        objEntityEmpSlary.AlownceId = Convert.ToInt32(AllowId);
        objEntityEmpSlary.SalaryAllwnceId = Convert.ToInt32(AlloId);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Orgid);
        string strdupAllownce = "";
        strdupAllownce = objEmpSalary.DuplCheckSalaryAllownce(objEntityEmpSlary);
        if (strdupAllownce == "" || strdupAllownce == "0")
        {

        }
        else
        {
            result = "1";
        }

     

        return result;
    }

    [WebMethod]
    public static string CheckForDupDedctn(string EmpId, string PaygrdId, string SalId, string DedctnId, string Orgid, string CorpId, string AlloId)
    {
        cls_Business_Monthly_Salary_Process objEmpSalary = new cls_Business_Monthly_Salary_Process();
        // clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        string result = "0";
        objEntityEmpSlary.EmplyUserId = Convert.ToInt32(EmpId);

        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(PaygrdId);

        objEntityEmpSlary.EmpSalaryId = Convert.ToInt32(SalId);

        objEntityEmpSlary.DedctnId = Convert.ToInt32(DedctnId);
        objEntityEmpSlary.SlaryDedctnId = Convert.ToInt32(AlloId);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Orgid);
        string strdupAllownce = "";
          strdupAllownce = objEmpSalary.DuplCheckSalaryDedctn(objEntityEmpSlary);
          if (strdupAllownce == "" || strdupAllownce == "0")
          {
          }
          else
          {
              result = "1";
          }



        return result;
    }
}