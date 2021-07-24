using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;



using System.Globalization;

public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Employee_Deduction_hcm_Employee_Deduction_Master : System.Web.UI.Page
{
    int intOrgId;
    int intCorpId;
    protected void Page_Load(object sender, EventArgs e)
    {
        HiddenEditval.Value = "0";
        if (!IsPostBack)

                  {Session["Succes"] = "";
        lblinstalsectn.Visible = false;
            txtDocnum.Focus();
           
            lblHeader.Text = "Add Employee Deduction";
            Session["Succes"] = "";
                        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            clsEntityCommon objEntityCommon = new clsEntityCommon();
           // DeductionLoad();
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen = 0, intEnableHrConfirm = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableClose = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
                Hiddencorpid.Value = intCorpId.ToString();
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"]);
                HiddenOrgid.Value = intOrgId.ToString();
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
            DataTable dtemp = objBusinessLayer.ReadEmployeeDtl(objEntityCommon);
          
            loademployee(dtemp);
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.EMPLOYEE_DEDUCTION_MASTER);

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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //future

                    }

                }

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
       
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
            }
            //evm-0027
            BindDdlMonths();
            BindDdlYears();
            //end
           //when editing 
            if (Session["EmpDeductionView"] != null && Session["EmpDeductionView"].ToString() != "")
            {

                string strId = Session["EmpDeductionView"].ToString();
                btnsaveclose.Visible = false;
                btnsavepayment.Visible = false;
                Update(strId);
                lblHeader.Text = "View Employee Deduction";
           
                HiddenDeductID.Value = strId;
                ////evm-0027
                ddlMonth.Enabled = false;
                ddlyear.Enabled = false;
                //BindDdlMonths();
                //BindDdlYears();
                ////end
                if (HiddenCnfrmed.Value == "1")
                {
                    //confirmed
                    btnUpdateClose.Visible = false;
                    btnUpdate.Visible = false;
                    //btnReopen.Visible = true;
                    btnAddClose.Visible = false;
                    // btnsavepayment.Visible = false;
                    // btnsaveclose.Visible = false;
                }
                else if (HiddenCnfrmed.Value == "2")
                {
                    //reopen
                    btnUpdateClose.Visible = true;
                    btnUpdate.Visible = true;
                    btnAddClose.Visible = true;
                  //  btnReopen.Visible = false;
                }
                else
                {
                    btnAddClose.Visible = true;
                    btnReopen.Visible = false;
                }
                if (HiddenNumberOfInstmts.Value == "0")
                {
                    btncalc.Visible = true;
                   // btnAddClose.Visible = false;

                }
                else
                {
                    btncalc.Visible = false;

                }

                if (Session["DeleteView"] != null)
                {

                    if (Session["DeleteView"].ToString() == "1")
                    {
                        btnUpdateClose.Visible = false;
                        btnUpdate.Visible = false;
                        btnsavepayment.Visible = false;
                        btnsaveclose.Visible = false;
                        HiddenCnfrmed.Value = "1";
                        btnAddClose.Visible = false;
                        btnReopen.Visible = false;
                    }
                }


            }
            else
            {
               
                btnUpdateClose.Visible = false;
                btnUpdate.Visible = false;
                btnAddClose.Visible = false;
                btnReopen.Visible = false;
                
            }


         


            if (intEnableAdd == 0)
            {
                btncalc.Visible = false;
                btnsavepayment.Visible = false;
                btnsaveclose.Visible = false;
            }


            if (intEnableModify == 0)
            {
                btnUpdateClose.Visible = false;
                btnUpdate.Visible = false;

            }
            if (intEnableConfirm == 0)
            {
                btnAddClose.Visible = false;

            } string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();

            Hiddencurrentdate.Value = strCurrentDate;
        }

     
    }
    public void Update(string strId)
    {
        txtDocnum.Enabled = false;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        ClsEntityEmployeeDeduction objEntityEmployeeDeduction = new ClsEntityEmployeeDeduction();
            clsBusinessLayerEmployeeDeductn objBusinessLayerEmployeeDeductn = new clsBusinessLayerEmployeeDeductn();
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);

            objEntityEmployeeDeduction.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"]);
            objEntityEmployeeDeduction.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmployeeDeduction.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        objEntityEmployeeDeduction.EmployeeDeductionID = Convert.ToInt32(strId);
        DataTable dtlist = objBusinessLayerEmployeeDeductn.ReadDeductionById(objEntityEmployeeDeduction);
        DataTable dtlistforinst = objBusinessLayerEmployeeDeductn.ReadInstallmentDeductionById(objEntityEmployeeDeduction);
        HiddenEditval.Value = "1";
        if(dtlist.Rows.Count>0)
        {
            HiddenEditval.Value = "1";
        txtDocnum.Text=dtlist.Rows[0]["EMPDEDTN_DOC_NO"].ToString();
    txtRefNo.Text=dtlist.Rows[0]["EMPDEDTN_REF_NO"].ToString();

    if (dtlist.Rows[0]["EMPDEDTN_EMPID"].ToString() != "")
    {
        if (ddlEmployee.Items.FindByValue(dtlist.Rows[0]["EMPDEDTN_EMPID"].ToString()) != null)
        {
            ddlEmployee.Items.FindByValue(dtlist.Rows[0]["EMPDEDTN_EMPID"].ToString()).Selected = true;
        }
        else
        {
            ListItem lstGrp = new ListItem(dtlist.Rows[0]["EMPNAME"].ToString(), dtlist.Rows[0]["EMPDEDTN_EMPID"].ToString());
            ddlEmployee.Items.Insert(1, lstGrp);

            SortDDL(ref this.ddlEmployee);

            ddlEmployee.Items.FindByValue(dtlist.Rows[0]["EMPDEDTN_EMPID"].ToString()).Selected = true;
        }
    }




       ddldeduction.SelectedValue=dtlist.Rows[0]["EMPDEDTN_DEDCTNID"].ToString();
       txtamount.Text=dtlist.Rows[0]["EMPDEDTN_AMOUNT"].ToString();

            //evm-0027
       string strEffectiveDate = dtlist.Rows[0]["EMPDEDTN_EFFECTIVE_DATE"].ToString();
       string[] strDateArray= strEffectiveDate.Split('-');
     
       //ddlMonth.Text =Convert.ToInt32(strDateArray[0]).ToString();
       //ddlyear.Text = strDateArray[2].ToString();

       if (ddlMonth.Items.FindByValue(strDateArray[1].ToString()) != null)
       {
           ddlMonth.ClearSelection();
           ddlMonth.Items.FindByValue(strDateArray[1].ToString()).Selected = true;
       }

       if (ddlyear.Items.FindByValue(strDateArray[2].ToString()) != null)
       {
           ddlyear.ClearSelection();
           ddlyear.Items.FindByValue(strDateArray[2].ToString()).Selected = true;
       }

        Hiddentxtefctvedate.Value=dtlist.Rows[0]["EMPDEDTN_EFFECTIVE_DATE"].ToString();
        txtinstallemntno.Text=dtlist.Rows[0]["EMPDEDTN_INSTLMNTNO"].ToString();
        ddlinstallmentplan.Text=dtlist.Rows[0]["EMPDEDTN_INSTLMNTPLAN"].ToString();
        txtremarks.Text = dtlist.Rows[0]["EMPDEDTN_REMARKS"].ToString();
        HiddenCnfrmed.Value = dtlist.Rows[0]["CNFRM_STATS"].ToString();

            
    }
        if (HiddenCnfrmed.Value == "1")
        {
            //confirmed
            btnUpdateClose.Visible = false;
            btnUpdate.Visible = false;
         //   btnReopen.Visible = true;
            btnAddClose.Visible = false;
            // btnsavepayment.Visible = false;
            // btnsaveclose.Visible = false;
        }
        else if (HiddenCnfrmed.Value == "2")
        {
            //reopen
            btnUpdateClose.Visible = true;
            btnUpdate.Visible = true;
            btnAddClose.Visible = true;
            btnReopen.Visible = false;
        }
        else
        {
            btnAddClose.Visible = true;
            btnReopen.Visible = false;
        }

        //evm-0027
        decimal decBalanceAmt = 0;
        decimal decPaidamt = 0;
        if (dtlistforinst.Rows.Count > 0)
        {
            if (dtlistforinst.Rows[0]["DEDTN_PAID_AMOUNT"].ToString() != "" && dtlistforinst.Rows[0]["DEDTN_INSTL_PAIDDATE"].ToString() != "")
            {
                HiddenNumberOfInstmts.Value = "1";
            }
            else
            {
                HiddenNumberOfInstmts.Value = "0";
                btnAddClose.Visible = false;
            }

            string paidamount = dtlistforinst.Rows[0]["DEDTN_PAID_AMOUNT"].ToString();
            string PaidDate = dtlistforinst.Rows[0]["DEDTN_INSTL_PAIDDATE"].ToString();
            decimal amount;
            decimal Totamount = 0;
            DateTime EffectiveDate;
            int InstallementNo;
            int InstallementPlan;
            int incremnt = 0;
            decimal finalamount = Convert.ToDecimal(txtamount.Text);
            amount = Convert.ToDecimal(txtamount.Text);
            DateTime effctvedate = objCommon.textToDateTime(Hiddentxtefctvedate.Value);
            EffectiveDate = Convert.ToDateTime(effctvedate);
            InstallementNo = Convert.ToInt32(dtlist.Rows[0]["EMPDEDTN_INSTLMNTNO"]);
            //txtinstallemntno.Enabled = true;

            InstallementNo = Convert.ToInt32(txtinstallemntno.Text);
            //txtinstallemntno.Enabled = false;

            //Evm-0027 4.09


            InstallementPlan = Convert.ToInt32(ddlinstallmentplan.Text);

            EffectiveDate = objCommon.textToDateTime(Hiddentxtefctvedate.Value).Date;
            decimal finalpaidamnt = 0;
            int isntpaidcount = 0;
            for (int k = 0; k < dtlistforinst.Rows.Count; k++)
            {
                string calpaidamount = dtlistforinst.Rows[k]["DEDTN_PAID_AMOUNT"].ToString();

                if (calpaidamount != "")
                {
                    isntpaidcount++;
                    finalpaidamnt = Convert.ToDecimal(calpaidamount);

                }
                else
                    finalpaidamnt = 0;
                Totamount = finalpaidamnt + Totamount;
            }



            int rowcount = InstallementNo;
            decimal prevduemaount = 0;

            decimal duemaount = (decimal)amount / InstallementNo;
            if (Totamount != 0)
            {
                prevduemaount = (decimal)amount / InstallementNo;
                if (isntpaidcount == 0)
                {
                    isntpaidcount = 0;

                }
                isntpaidcount = ((int)InstallementNo - (int)isntpaidcount);

                amount = amount - Totamount;
                if (isntpaidcount != 0)
                {
                    duemaount = (decimal)amount / isntpaidcount;
                }

                Math.Round(duemaount, 2);

            } if (InstallementPlan == 1)
            {
                incremnt = 1;

            }
            else if (InstallementPlan == 2)
            {
                incremnt = 2;


            }
            else if (InstallementPlan == 3)
            {
                incremnt = 6;

            }
            else if (InstallementPlan == 4)
            {
                incremnt = 12;

            }
            DateTime installmentdate = EffectiveDate; ;
            string dinstallmentdate = installmentdate.ToString("dd/MM/yyyy");
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-bordered table-striped\" width=\"100%\" >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr >";


            strHtml += "<th class=\"\" style=\"width:2%\"><i class=\"\"></i>  SL#";
            //    strHtml += "<input class=\"form-control\" placeholder=\"Filter Position\" type=\"text\">";
            strHtml += "</th >";


            strHtml += "<th class=\"\" style=\"width:20%;text-align:center;\">DATE";
            // strHtml += "<input class=\"form-control\" placeholder=\"Filter Position\" type=\"text\">";
            strHtml += "</th >";


            strHtml += "<th class=\"\" style=\"width:20%;text-align:center;\"> AMOUNT";
            strHtml += "</th >";
            strHtml += "<th class=\"\" style=\"width:20%;text-align:center;\"> PAID DATE";
            strHtml += "</th >";
            strHtml += "<th class=\"\" style=\"width:20%;text-align:center;\"> AMOUNT PAID";
            strHtml += "</th >";
            //evm-0027
            strHtml += "<th class=\"\" style=\"width:20%;text-align:center;\">BALANCE AMOUNT";
            strHtml += "</th >";
            //end
            strHtml += "<th class=\"\" style=\"width:2%;text-align:center;\"> DELETE ";
            strHtml += "<th class=\"\" style=\"width:2%;text-align:center;display:none;\"> status ";
            strHtml += "</th >";

            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows
            decimal paidamnt = 0;
            strHtml += "<tbody>";
            decimal duemaount1 = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dtlistforinst.Rows.Count; intRowBodyCount++)
            {
                decimal tempduemaount = 0;
                PaidDate = dtlistforinst.Rows[intRowBodyCount]["DEDTN_INSTL_PAIDDATE"].ToString();
                if (PaidDate != "")
                    tempduemaount = prevduemaount;
                else
                    tempduemaount = duemaount;
                paidamount = dtlistforinst.Rows[intRowBodyCount]["DEDTN_PAID_AMOUNT"].ToString();
                if (paidamount != "")
                    paidamnt = Convert.ToDecimal(paidamount);
                else
                {
                    paidamnt = 0;

                }

                //Totamount = paidamnt + Totamount;
                if (paidamnt >= amount)
                {
                    tempduemaount = 0;
                    //  duemaount = 0;
                    if (paidamount != "")
                    {
                        //duemaount = 0; 
                        tempduemaount = paidamnt;
                    }
                }
                else
                {
                    tempduemaount = duemaount;
                }





                int slno = intRowBodyCount + 1;
                if (paidamount != "")
                    strHtml += "<tr id=\"row" + intRowBodyCount + "\" class=\"success\" >";
                else
                {
                    if (installmentdate > DateTime.Today)
                        strHtml += "<tr id=\"row" + intRowBodyCount + "\" class=\"warning\" >";
                    else
                        strHtml += "<tr id=\"row" + intRowBodyCount + "\" class=\"danger\" >";
                }
                string status = "";
                status = dtlistforinst.Rows[intRowBodyCount][3].ToString();
                strHtml += "<td class=\"\" disabled=false; style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left; \" >" + slno + "</td>";
                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
                strHtml += " <label class=\"input\" style=\"float: left;width: 100%;\">";
                strHtml += "<input  id=\"InstlDate" + intRowBodyCount + "\" name=\"InstlDate" + intRowBodyCount + "\" type=\"text\" value=" + dinstallmentdate.Trim() + " class=\"input\" maxlength=\"500\"  /></label></td>";

                //  strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dinstallmentdate + "</td>";

                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
                strHtml += " <label class=\"input\" style=\"float: left;width: 100%;\">";
                strHtml += "<input  id=\"InstlmntAmnt" + intRowBodyCount + "\" name=\"DRemrk_" + intRowBodyCount + "\" type=\"text\" value=" + Math.Round(tempduemaount, 2) + " class=\"input\" maxlength=\"500\" onblur=\"addCommas('InstlmntAmnt" + intRowBodyCount + "')\" style=\"text-align: right\" onchange=\"Recalculate('InstlmntAmnt" + intRowBodyCount + "' )\" /></label></td>";

                strHtml += "<td  disabled=\"false\" class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
                strHtml += " <label  disabled=\"false\" class=\"input\" style=\"float: left;width: 100%;\">";
                strHtml += "<input disabled=\"false\" id=\"PAiddate_" + intRowBodyCount + "\" name=\"PAiddate_" + intRowBodyCount + "\" type=\"text\" value=\"" + PaidDate.Trim() + "\"  class=\"Tabletxt form-control datepicker\" data-dateformat=\"dd/mm/yy\" onchange=\"PaidDateValid('PAiddate_" + intRowBodyCount + "')\" placeholder=\"dd-mm-yyyy\" placeholder=\"dd-mm-yyyy\" maxlength=\"10\" />";
                strHtml += " </label></td>";

                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
                strHtml += " <label class=\"input\" style=\"float: left;width: 100%;\">";

                //}
                //strHtml += "<input id=\"txtamountpaid" + intRowBodyCount + "\" name=\"txtamountpaid" + intRowBodyCount + "\" type=\"text\" value=\"" + paidamount.Trim() + "\" class=\"input\" maxlength=\"10\" onkeydown=\"return isNumber(event);\" onkeypress=\"return isTag(event);\" onblur=\"return AmountCheck('txtamountpaid" + intRowBodyCount + "');\" onchange=\"RecalculateAfterpay('txtamountpaid','InstlmntAmnt','" + intRowBodyCount + "' )\" /></td>";
                if (paidamnt == 0)
                {
                    paidamount = "";
                }
                else
                    paidamount = paidamnt.ToString();


                strHtml += " <input id=\"txtamountpaid" + intRowBodyCount + "\" name=\"txtamountpaid" + intRowBodyCount + "\" value=\"" + paidamount + "\"  type=\"text\"  class=\"input\" maxlength=\"12\" style=\"text-align: right\" onkeydown=\"return isNumberAmount(event,'txtamountpaid" + intRowBodyCount + "');\" onkeypress=\"return isTag(event);\"  onchange=\"RecalculateAfterpay('event','txtamountpaid','InstlmntAmnt','" + intRowBodyCount + "' )\" /></td>";


                //  strHtml += "<asp:TextBox ID=\"txtamount\" onkeydown=\"return isNumberrr(event,'cphMain_txtamount');\" onkeypress=\"return isTag(event);\" onblur=\"return RemoveTag('cphMain_txtamount');\" runat=\"server\" MaxLength=\"8\" Style=\"text-transform: uppercase; margin-right: 4%;\"></asp:TextBox>";
                strHtml += " </label></td>";
                //evm-0027
                string strBalaneAmt = "";
                decPaidamt = decPaidamt + paidamnt;
                decimal decTotalAmt = Convert.ToDecimal(txtamount.Text);
                decBalanceAmt = decTotalAmt - decPaidamt;
                strBalaneAmt = decBalanceAmt.ToString();
                if (paidamnt == 0)
                {
                    strBalaneAmt = "";
                }


                strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><label class=\"input\" style=\"float: left;width: 100%;\"><input id=\"txtBalanceamount" + intRowBodyCount + "\" name=\"txtBalanceamount" + intRowBodyCount + "\" value=\"" + strBalaneAmt + "\" disabled=\"true\" type=\"text\"  class=\"input\" /></label></td>";
                //end

                strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + " <a class=\"\" style=\"cursor:pointer;margin-top:-1.5%;opacity:.5;margin-left:1%;z-index: 29;\" title=\"\" onclick=\"\" >"
                                             + "<img style=\"opacity: 0.8;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\" ><label class=\"input\" style=\"float: left;width: 100%; display:none;\"><input id=\"txtStatus" + intRowBodyCount + "\" name=\"txtStatus" + intRowBodyCount + "\" value=\"" + status + "\" disabled=\"true\" type=\"text\"  class=\"input\" /></label></td>";
                //strHtml += "<td> <label class=\"input\" style=\"float: left;width: 100%;display:none;\" value=\"" + status + "\"></td>";


                strHtml += "</tr>";

                installmentdate = installmentdate.AddMonths(incremnt);
                dinstallmentdate = installmentdate.ToString("dd/MM/yyyy");
            }

            strHtml += "<tr >";
            strHtml += "<td class=\"info\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
            strHtml += "<td class=\"info\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" >TOTAL</td>";
            strHtml += "<td class=\"info\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + Convert.ToDouble(txtamount.Text) + "</td>";
            strHtml += "<td class=\"info\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
            strHtml += "<td class=\"info\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
            //evm-0027
            strHtml += "<td class=\"info\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
            //end

            strHtml += "<td class=\"info\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>"; strHtml += "</tr>";

            strHtml += "</tbody>";

            strHtml += "</table>";

            sb.Append(strHtml);
            divTables.InnerHtml = strHtml;
            HiddenPaidAmt.Value = "saved";

            if (Totamount >= finalamount)
                HiddenPaidAmt.Value = "con";
        }
        
    }

    public class clsWBData
    {
        public string ROWID { get; set; }
        public string INSTALLMENTDATE { get; set; }
        public string AMOUNT { get; set; }
        public string PAIDDATE { get; set; }
        public string PAIDAMT { get; set; }
        public string DETAILID { get; set; }
        public string EVTACTION { get; set; }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        Session["Succes"] = "";
        string a = hiddentotaldata.Value;
        int intUserId=0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMPLOYEE_DEDUCTION_MASTER);
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);

            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        } 
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"]);
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
        objEntityCommon.CorporateID = intCorpId;
        objEntityCommon.Organisation_Id = intOrgId;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        
        Session["MasterIdDeduction"] = strNextId;
        ClsEntityEmployeeDeduction objEntityEmployeeDeduction = new ClsEntityEmployeeDeduction();
        clsBusinessLayerEmployeeDeductn objBusinessLayerEmployeeDeductn = new clsBusinessLayerEmployeeDeductn();
        objEntityEmployeeDeduction.Documentno = Convert.ToInt64(txtDocnum.Text);
        objEntityEmployeeDeduction.Reference_Number = txtRefNo.Text;
        objEntityEmployeeDeduction.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedValue);
        objEntityEmployeeDeduction.DeductionId = Convert.ToInt32(ddldeduction.SelectedValue);
        objEntityEmployeeDeduction.Amount = Convert.ToDouble(txtamount.Text);
        DateTime effctvedate = DateTime.Now;
        if (Hiddentxtefctvedate.Value!="0")
        {
             effctvedate = objCommon.textToDateTime(Hiddentxtefctvedate.Value);

        }
        objEntityEmployeeDeduction.EffectiveDate = Convert.ToDateTime(effctvedate);
        objEntityEmployeeDeduction.InstallementNo = Convert.ToInt32(txtinstallemntno.Text);
        objEntityEmployeeDeduction.InstallementPlan = Convert.ToInt32(ddlinstallmentplan.Text);
        objEntityEmployeeDeduction.Remarks = txtremarks.Text;
        objEntityEmployeeDeduction.orgid = intOrgId;
        objEntityEmployeeDeduction.CorpId = intCorpId;
        objEntityEmployeeDeduction.UserId = intUserId;
        objEntityEmployeeDeduction.EmployeeDeductionID = Convert.ToInt64(strNextId);
        List<ClsEntityEmployeeDeduction> objEntityEmployeeDeductionlist = new List<ClsEntityEmployeeDeduction>();
       // List<clsEntityClearanceFormWorkerDetail> objEntityDetilsList = new List<clsEntityClearanceFormWorkerDetail>();
        if (hiddentotaldata.Value != "" && hiddentotaldata.Value != "0")
        {
            string jsonData = hiddentotaldata.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");
            List<clsWBData> objWBDataList = new List<clsWBData>();
            //   UserData  data
            objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(i);
            foreach (clsWBData objclsWBData in objWBDataList)
            {
                ClsEntityEmployeeDeduction objEntityDetails = new ClsEntityEmployeeDeduction();

                //DateTime INSTALLMENTDATE = objCommon.textToDateTime(objclsWBData.INSTALLMENTDATE);
                DateTime InstallmentDat = objCommon.textToDateTime(objclsWBData.INSTALLMENTDATE);
                objEntityDetails.InstallmentDate = Convert.ToDateTime(InstallmentDat);
                objEntityDetails.InstallmentAmount = Convert.ToDouble(objclsWBData.AMOUNT);
                if (objclsWBData.PAIDAMT != "")
                    objEntityDetails.TotLPaid = Convert.ToDouble(objclsWBData.PAIDAMT);
                else
                    objEntityDetails.TotLPaid = 0;
                if (objclsWBData.PAIDDATE != "")
                {
                  //  DateTime PaidDate = objCommon.textToDateTime(objclsWBData.PAIDDATE);
                    DateTime PaidDat = objCommon.textToDateTime(objclsWBData.PAIDDATE);
                    objEntityDetails.PaidDate = Convert.ToDateTime(PaidDat);

                }
                else
                    objEntityDetails.PaidDate = Convert.ToDateTime(DateTime.MinValue);
                objEntityDetails.EmployeeDeductionID = Convert.ToInt32(strNextId);
                objEntityEmployeeDeductionlist.Add(objEntityDetails);
            }
        }
        string strNameCount = "0";
        if (txtDocnum.Text != "" && txtDocnum.Text != null)
        {
            objEntityEmployeeDeduction.Documentno = Convert.ToInt64(txtDocnum.Text);
            strNameCount = objBusinessLayerEmployeeDeductn.CheckDocNum(objEntityEmployeeDeduction);
        }
        if (strNameCount == "0")
        {
            if (clickedButton.ID == "btnSave")
            {
                objBusinessLayerEmployeeDeductn.Add_Deduction_Details(objEntityEmployeeDeduction, objEntityEmployeeDeductionlist);
                Session["Succes"] = "saved";
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccesMessage", "SuccesMessage()", true);
                btnAddClose.Visible = false;
            }
            else
            {

                objBusinessLayerEmployeeDeductn.Add_Deduction_Details(objEntityEmployeeDeduction, objEntityEmployeeDeductionlist);
                Session["Succes"] = "saved";
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccesMessage", "SuccesMessage()", true);
                btnAddClose.Visible = false;
         
            
            
            }
        }
        else {

            ScriptManager.RegisterStartupScript(this, GetType(), "AlertFor", "AlertFor()", true);
          
        }

         
    }

    public void loademployee(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dt;


            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataTextField = "USR_NAME";

                     ddlEmployee.DataBind();

        }

        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");
    }

    protected void btncalc_Click(object sender, EventArgs e)
    {
      //  int amount;
      //  DateTime EffectiveDate;
      //  int InstallementNo;
      //  int InstallementPlan;
      //  int incremnt=0;
      //  amount = Convert.ToInt32(txtamount.Text);
      //  EffectiveDate = Convert.ToDateTime(Hiddentxtefctvedate.Value);
      //  InstallementNo = Convert.ToInt32(txtinstallemntno.Text);
      //InstallementPlan = Convert.ToInt32(ddlinstallmentplan.Text);
      //clsCommonLibrary objCommon = new clsCommonLibrary();
      //EffectiveDate = objCommon.textToDateTime(Hiddentxtefctvedate.Value).Date;

      //int rowcount = InstallementNo;
      //double duemaount = (double)amount / InstallementNo;
      //Math.Round(duemaount, 2);
      //if (InstallementPlan == 1)
      //{
      //    incremnt = 1;
      
      //}
      //else   if (InstallementPlan == 2)
      //{
      //    incremnt = 2;


      //}
      //else if (InstallementPlan == 3)
      //{
      //    incremnt = 6;

      //}
      //else if (InstallementPlan == 4)
      //{
      //    incremnt = 12;

      //}
      //DateTime installmentdate = EffectiveDate; ;
      //string dinstallmentdate = installmentdate.ToString("dd/MM/yyyy");
      //StringBuilder sb = new StringBuilder();
      //string strHtml = "<table id=\"datatable_fixed_column\" class=\"table\" width=\"100%\" >";
      ////add header row
      //strHtml += "<thead>";
      //strHtml += "<tr >";

          
      //        strHtml += "<th class=\"hasinput\" style=\"width:3%\"><i class=\"fa fa-building\"></i>  SL#";
      //    //    strHtml += "<input class=\"form-control\" placeholder=\"Filter Position\" type=\"text\">";
      //        strHtml += "</th >";


      //        strHtml += "<th class=\"hasinput\" style=\"width:5%\">DATE";
      //       // strHtml += "<input class=\"form-control\" placeholder=\"Filter Position\" type=\"text\">";
      //        strHtml += "</th >";
         
      
      //strHtml += "<th class=\"hasinput\" style=\"width:5%;text-align:center;\"> AMOUNT";
      //strHtml += "</th >";
      //strHtml += "<th class=\"hasinput\" style=\"width:10%;text-align:center;\"> PAID DATE";
      //strHtml += "</th >";
      //strHtml += "<th class=\"hasinput\" style=\"width:10%;text-align:center;\"> AMOUNT PAID";
      //strHtml += "</th >";
      //strHtml += "<th class=\"hasinput\" style=\"width:3%;text-align:center;\"> DELETE ";
      //strHtml += "</th >";
     
      //strHtml += "</tr>";
      //strHtml += "</thead>";
      ////add rows

      //strHtml += "<tbody>";
      //for (int intRowBodyCount = 0; intRowBodyCount <InstallementNo; intRowBodyCount++)
      //{
      //    int slno = intRowBodyCount + 1;

      //    strHtml += "<tr id=\"row" + intRowBodyCount + "\" >";
      //    strHtml += "<td class=\"success\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";
      //    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dinstallmentdate + "</td>";
      //    installmentdate = installmentdate.AddMonths(incremnt);
      //    dinstallmentdate = installmentdate.ToString("dd/MM/yyyy");
      //    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" ;
      //    strHtml += "<input id=\"InstlmntAmnt" + intRowBodyCount + "\" name=\"DRemrk_' + intRowBodyCount + '\" type=\"text\" value=" + Math.Round(duemaount, 2) + " class=\"Tabletxt\" maxlength=\"500\" onchange=\"Recalculate('InstlmntAmnt" + intRowBodyCount +"' )\" /></td>";
      //    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + duemaount + "</td>";
      //    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + duemaount + "</td>";
      //    strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + " <a class=\"\" style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left:1%;z-index: 29;\" title=\"Cancel\" onclick=\"return removeRow("+ intRowBodyCount + ",'');\" >"
      //                                 + "<img style=\"opacity: 0.8;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
     
      //    strHtml += "</tr>";
      //}

      //strHtml += "<tr >";
      //strHtml += "<td class=\"success\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
      //strHtml += "<td class=\"success\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" >TOTAL</td>";
      //strHtml += "<td class=\"success\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" >"+amount+"</td>";
      //strHtml += "<td class=\"success\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
      //strHtml += "<td class=\"success\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";

      //strHtml += "<td class=\"success\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>"; strHtml += "</tr>";

      //strHtml += "</tbody>";

      //strHtml += "</table>";

      //sb.Append(strHtml);
      divTables.InnerHtml = "";
     // return sb.ToString();
    }

    [WebMethod]
    public static string checkduplicate(string txtDocnum, string corpid,string orgid)
    {
        ClsEntityEmployeeDeduction objEntityEmployeeDeduction = new ClsEntityEmployeeDeduction();
        clsBusinessLayerEmployeeDeductn objBusinessLayerEmployeeDeductn = new clsBusinessLayerEmployeeDeductn();
        objEntityEmployeeDeduction.CorpId = Convert.ToInt32(corpid);
        objEntityEmployeeDeduction.orgid = Convert.ToInt32(orgid);
        objEntityEmployeeDeduction.Documentno = Convert.ToInt64(txtDocnum);
       string strNameCount = objBusinessLayerEmployeeDeductn.CheckDocNum(objEntityEmployeeDeduction);



       return strNameCount;
    }

  

    [WebMethod]
    public static string convertdatatohtml(string Stramount, string StrInstallementNo, string StrInstallementPlan, string StrEffectiveDate, string CurID, string corpid,string strEffectiveMonth,string strEffectiveYear)
    {

     
        decimal amount;
        DateTime EffectiveDate;
        int InstallementNo;
        int InstallementPlan;
        int incremnt = 0;
        amount = Convert.ToDecimal(Stramount);
      //  EffectiveDate = Convert.ToDateTime(Hiddentxtefctvedate.Value);
        InstallementNo = Convert.ToInt32(StrInstallementNo);
        InstallementPlan = Convert.ToInt32(StrInstallementPlan);
        clsCommonLibrary objCommon = new clsCommonLibrary();
        //evm-0027
        //if (Convert.ToInt32(strEffectiveMonth) < 10)
          //  strEffectiveMonth = strEffectiveMonth;

        StrEffectiveDate = "01-" + strEffectiveMonth + "-" + strEffectiveYear;
        EffectiveDate = objCommon.textToDateTime(StrEffectiveDate).Date;
        //end
      
        int rowcount = InstallementNo;
        decimal duemaount = (decimal)amount / InstallementNo;
       // Math.Round(duemaount, 2);
        if (InstallementPlan == 1)
        {
            incremnt = 1;

        }
        else if (InstallementPlan == 2)
        {
            incremnt = 2;


        }
        else if (InstallementPlan == 3)
        {
            incremnt = 6;

        }
        else if (InstallementPlan == 4)
        {
            incremnt = 12;

        }
        DateTime installmentdate = EffectiveDate; ;
        string dinstallmentdate = installmentdate.ToString("dd/MM/yyyy");

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-bordered table-striped\" width=\"100%\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";


        strHtml += "<th class=\"\" style=\"width:2%\"><i class=\"\"></i>  SL#";
        //    strHtml += "<input class=\"form-control\" placeholder=\"Filter Position\" type=\"text\">";
        strHtml += "</th >";


        strHtml += "<th class=\"\" style=\"width:25%\">DATE";
        // strHtml += "<input class=\"form-control\" placeholder=\"Filter Position\" type=\"text\">";
        strHtml += "</th >";


        strHtml += "<th class=\"\" style=\"width:25%;text-align:center;\"> AMOUNT";
        strHtml += "</th >";
        strHtml += "<th class=\"\" style=\"width:25%;text-align:center;\"> PAID DATE";
        strHtml += "</th >";
        strHtml += "<th class=\"\" style=\"width:25%;text-align:center;\"> AMOUNT PAID";
        strHtml += "</th >";
        strHtml += "<th class=\"\" style=\"width:2%;text-align:center;\"> DELETE ";
        strHtml += "</th >";

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < InstallementNo; intRowBodyCount++)
        {
            int slno = intRowBodyCount + 1;


            if (installmentdate > DateTime.Today)
                strHtml += "<tr id=\"row" + intRowBodyCount + "\" class=\"warning\" >";
            else
                strHtml += "<tr id=\"row" + intRowBodyCount + "\" class=\"danger\" >";
            strHtml += "<td class=\"\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
            strHtml += " <label class=\"input\" style=\"float: left;width: 100%;\">";
            strHtml += "<input id=\"InstlDate" + intRowBodyCount + "\" name=\"InstlDate" + intRowBodyCount + "\" type=\"text\" value=" + dinstallmentdate + " class=\"input\" maxlength=\"500\"  disabled=\"true\" /></label></td>";
           
          //  strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dinstallmentdate + "</td>";
            installmentdate = installmentdate.AddMonths(incremnt);
            dinstallmentdate = installmentdate.ToString("dd/MM/yyyy");
           
            strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
            strHtml += " <label class=\"input\" style=\"float: left;width: 100%;\">";
            strHtml += "<input id=\"InstlmntAmnt" + intRowBodyCount + "\" name=\"DRemrk_" + intRowBodyCount + "\"onkeydown=\"return isNumber(event);\" onkeypress=\"return isTag(event);\" disabled=\"true\" onblur=\"return RemoveTagWithNumber('InstlmntAmnt" + intRowBodyCount + "');\" type=\"text\" value=" + Math.Round(duemaount, 3) + " style=\"text-align: right\" disabled=\"true\" class=\"input\" maxlength=\"500\" onchange=\"Recalculate('InstlmntAmnt" + intRowBodyCount + "','" + intRowBodyCount + "')\" /></label></td>";
           
            strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
            strHtml += " <label class=\"input\" style=\"float: left;width: 100%;\">";
            strHtml += "<input id=\"PAiddate_" + intRowBodyCount + "\" name=\"PAiddate_" + intRowBodyCount + "\" type=\"text\" class=\"Tabletxt form-control datepicker\" data-dateformat=\"dd/mm/yy\" onchange=\"PaidDateValid('PAiddate_" + intRowBodyCount + "')\" placeholder=\"dd-mm-yyyy\" placeholder=\"dd-mm-yyyy\" maxlength=\"10\" />";
            strHtml += " </label></td>";
          
            strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
            strHtml += " <label class=\"input\" style=\"float: left;width: 100%;\">";
            strHtml += "<input id=\"txtamountpaid" + intRowBodyCount + "\" name=\"txtamountpaid" + intRowBodyCount + "\" value=\"\"   type=\"text\"  class=\"input\" maxlength=\"12\" onkeydown=\"return isNumberAmount(event,'txtamountpaid" + intRowBodyCount + "');\" onkeypress=\"return isTag(event);\" style=\"text-align: right\"  onchange=\"RecalculateAfterpay('event','txtamountpaid','InstlmntAmnt','" + intRowBodyCount + "' )\" /></td>";
         
          //  strHtml += "<asp:TextBox ID=\"txtamount\" onkeydown=\"return isNumberrr(event,'cphMain_txtamount');\" onkeypress=\"return isTag(event);\" onblur=\"return RemoveTag('cphMain_txtamount');\" runat=\"server\" MaxLength=\"8\" Style=\"text-transform: uppercase; margin-right: 4%;\"></asp:TextBox>";
            strHtml += " </label></td>";
                          
            
            strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + " <a class=\"\" style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left:1%;z-index: 29;\" title=\"Delete\" onclick=\"return removeRow(" + intRowBodyCount + ",'');\" >"
                                         + "<img style=\"opacity: 0.8;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
            
                                                              
            strHtml += "</tr>";
        }
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(CurID);
        objEntityCommon.CorporateID = Convert.ToInt32(corpid);
   //s string convertedamount;
   // convertedamount = objBusinessLayer.AddCommasForNumberSeperation(amount.ToString(), objEntityCommon);
        strHtml += "<tr >";
        strHtml += "<td class=\"info\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
        strHtml += "<td class=\"info\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" >TOTAL</td>";
        strHtml += "<td class=\"info\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + amount + "</td>";
        strHtml += "<td class=\"info\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";
        strHtml += "<td class=\"info\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";

        strHtml += "<td class=\"info\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>"; strHtml += "</tr>";

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);

        return strHtml;
    }
    protected void btnsavepayment_Click(object sender, EventArgs e)

    {
        
        ClsEntityEmployeeDeduction objEntityEmployeeDeduction = new ClsEntityEmployeeDeduction();
        clsBusinessLayerEmployeeDeductn objBusinessLayerEmployeeDeductn = new clsBusinessLayerEmployeeDeductn();

        if (HiddenDeductID.Value != "")
        {
            int dedctnid = Convert.ToInt32(HiddenDeductID.Value);
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);

                objEntityEmployeeDeduction.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            } if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"]);
                objEntityEmployeeDeduction.orgid = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                //intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityEmployeeDeduction.EmployeeDeductionID = dedctnid;

            objBusinessLayerEmployeeDeductn.ConfirmDedcution(objEntityEmployeeDeduction);
            Session["Succes"] = "confirmed";
            ScriptManager.RegisterStartupScript(this, GetType(), "SuccesMessage", "SuccesMessage()", true);
    
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (HiddenDeductID.Value != "")
        {
            clsBusinessLayerEmployeeDeductn objBusinessLayerEmployeeDeductn = new clsBusinessLayerEmployeeDeductn();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            List<ClsEntityEmployeeDeduction> objEntityEmployeeDeductionlist = new List<ClsEntityEmployeeDeduction>();
            // List<clsEntityClearanceFormWorkerDetail> objEntityDetilsList = new List<clsEntityClearanceFormWorkerDetail>();
            if (hiddentotaldata.Value != "" && hiddentotaldata.Value != "0")
            {
                ClsEntityEmployeeDeduction objEntitydedctn = new ClsEntityEmployeeDeduction();


                if (Session["CORPOFFICEID"] != null)
                {
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);

                    objEntitydedctn.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                } if (Session["ORGID"] != null)
                {
                    intOrgId = Convert.ToInt32(Session["ORGID"]);
                    objEntitydedctn.orgid = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["USERID"] != null)
                {
                    objEntitydedctn.UserId = Convert.ToInt32(Session["USERID"]);
                    //intUserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }


                objEntitydedctn.EmployeeDeductionID = Convert.ToInt32(HiddenDeductID.Value); ;
                string jsonData = hiddentotaldata.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsWBData> objWBDataList = new List<clsWBData>();
                //   UserData  data
                objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(i);
                foreach (clsWBData objclsWBData in objWBDataList)
                {
                    ClsEntityEmployeeDeduction objEntityDetails = new ClsEntityEmployeeDeduction();
                    DateTime InstallmentDat = objCommon.textToDateTime(objclsWBData.INSTALLMENTDATE);
                    objEntityDetails.InstallmentDate = Convert.ToDateTime(InstallmentDat);
                    objEntityDetails.InstallmentAmount = Convert.ToDouble(objclsWBData.AMOUNT);
                    if (objclsWBData.PAIDAMT != "")
                        objEntityDetails.TotLPaid = Convert.ToDouble(objclsWBData.PAIDAMT);
                    else
                        objEntityDetails.TotLPaid = 0;
                    if (objclsWBData.PAIDDATE != "")
                    {
                    
                        DateTime PaidDat = objCommon.textToDateTime(objclsWBData.PAIDDATE);
                        objEntityDetails.PaidDate = Convert.ToDateTime(PaidDat);
                    }
                    else
                        objEntityDetails.PaidDate = Convert.ToDateTime(DateTime.MinValue);
                    objEntityDetails.EmployeeDeductionID = Convert.ToInt32(HiddenDeductID.Value);
                    objEntityEmployeeDeductionlist.Add(objEntityDetails);
                }
                 objEntitydedctn.EmployeeDeductionID = Convert.ToInt32(HiddenDeductID.Value);
                 string instmtStatus = "0";
                 if (HiddenNumberOfInstmts.Value == "0")
                 {
                     instmtStatus = "1";
                    objEntitydedctn.InstallementNo = Convert.ToInt32(txtinstallemntno.Text);
                    objEntitydedctn.Documentno=Convert.ToInt32(txtDocnum.Text);
                    objEntitydedctn.Reference_Number=txtRefNo.Text;
                    objEntitydedctn.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedValue);
                    objEntitydedctn.DeductionId = Convert.ToInt32(ddldeduction.SelectedValue);
                    objEntitydedctn.Amount=Convert.ToDouble(txtamount.Text);
                    objEntitydedctn.EffectiveDate=objCommon.textToDateTime(Hiddentxtefctvedate.Value);
                    objEntitydedctn.InstallementPlan=Convert.ToInt32(ddlinstallmentplan.SelectedValue);
                    objEntitydedctn.Remarks=txtremarks.Text;
                             
                     
                 }
                 objBusinessLayerEmployeeDeductn.Update_Installement(objEntitydedctn, objEntityEmployeeDeductionlist, instmtStatus);
                Update(HiddenDeductID.Value);


                if (clickedButton.ID == "btndummyconfrm")
                {

                    objBusinessLayerEmployeeDeductn.ConfirmDedcution(objEntitydedctn);
                    Session["Succes"] = "confirmed";
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccesMessage", "SuccesMessage()", true);
                }
                else if (clickedButton.ID == "btnUpdate")
                {

                    Session["Succes"] = "updated";

                    if (clickedButton.ID == "btnUpdate")
                    {
                       // Response.Redirect("hcm_Employee_Deduction_Master.aspx");
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccesUpdate", "SuccesUpdate()", true);
                    }
                    else
                        Response.Redirect("hcm_Employee_Deduction_List.aspx");
                }
                else {
                    Response.Redirect("hcm_Employee_Deduction_List.aspx");
                }
              
            }
        }
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

    [WebMethod]
    public static string CheckEffctveDate(string EmpId, string corpid, string orgid)
    {
        string strNameCount = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        ClsEntityEmployeeDeduction objEntityEmployeeDeduction = new ClsEntityEmployeeDeduction();
        clsBusinessLayerEmployeeDeductn objBusinessLayerEmployeeDeductn = new clsBusinessLayerEmployeeDeductn();
        objEntityEmployeeDeduction.CorpId = Convert.ToInt32(corpid);
        objEntityEmployeeDeduction.orgid = Convert.ToInt32(orgid);
        objEntityEmployeeDeduction.EmployeeId = Convert.ToInt32(EmpId);
        DataTable dt= objBusinessLayerEmployeeDeductn.CheckEffctveDate(objEntityEmployeeDeduction);
        if (dt.Rows.Count > 0)
        {   
            string strMonth="";
            if (Convert.ToInt32(dt.Rows[0][1]) < 10)
            {
                strMonth = "0" + dt.Rows[0][1].ToString();
            }
            else
            {
                strMonth = dt.Rows[0][1].ToString();
            }


            DateTime dtDate = objCommon.textToDateTime("01-" + strMonth + "-" + dt.Rows[0][2].ToString());
            dtDate = dtDate.AddMonths(1);
            strNameCount = dtDate.Day+"/"+dtDate.Month+"/"+dtDate.Year;
        }
        return strNameCount;
    }
    //evm-0027
    public void BindDdlMonths(string strMonth = null)
    {
        strMonth = DateTime.Today.Month.ToString();
        ddlMonth.Items.Clear();
        var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        for (int i = 0; i < months.Length - 1; i++)
        {
            ddlMonth.Items.Add(new ListItem(months[i], (i + 1).ToString("D2")));
        }
        ddlMonth.ClearSelection();
        if (strMonth != null)
        {
            if (ddlMonth.Items.FindByValue(strMonth) != null)
            {
                ddlMonth.Items.FindByValue(strMonth).Selected = true;
            }
        }
        else
        {
            ddlMonth.Items.Insert(0, "--MONTH--");
        }
    }
    public void BindDdlYears(string strYear = null)
    {
        ddlyear.Items.Clear();
        strYear = DateTime.Today.Year.ToString();
        var currentYear = DateTime.Today.Year;
        for (int i = 1; i >= -1; i--)
        {

            ddlyear.Items.Add((currentYear - i).ToString());
        }
        ddlyear.ClearSelection();
        if (strYear != null)
        {
            if (ddlyear.Items.FindByValue(strYear) != null)
            {
                ddlyear.Items.FindByValue(strYear).Selected = true;
            }
        }
        else
        {
            ddlyear.Items.Insert(0, "--YEAR--");
        }
    }
    //end
    protected void btnReopen_Click(object sender, EventArgs e)
    {
        ClsEntityEmployeeDeduction objEntityEmployeeDeduction = new ClsEntityEmployeeDeduction();
        clsBusinessLayerEmployeeDeductn objBusinessLayerEmployeeDeductn = new clsBusinessLayerEmployeeDeductn();

        if (Session["CORPOFFICEID"] != null)
        {
           

            objEntityEmployeeDeduction.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        } if (Session["ORGID"] != null)
        {
           
            objEntityEmployeeDeduction.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            //intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        objEntityEmployeeDeduction.EmployeeDeductionID = Convert.ToInt64(HiddenDeductID.Value);
        try
        {
           
            objBusinessLayerEmployeeDeductn.ReopenDedcution(objEntityEmployeeDeduction);
            Update(HiddenDeductID.Value);
            btnReopen.Visible = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "SuccesReopen", "SuccesReopen()", true);
            
        }
        catch
        {
           
        }
    }
}