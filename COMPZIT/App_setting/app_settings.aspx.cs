using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using BL_Compzit;
using CL_Compzit;
using EL_Compzit;

public partial class App_setting_app_settings : System.Web.UI.Page
{
    //START EVM 040
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            int intCorpId = 0;
            int intOrgId = 0;
            int intUserId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {       clsCommonLibrary.CORP_GLOBAL.LEVSTRTDT_HOLIDAYSTS,//leave //HCM
                                                               clsCommonLibrary.CORP_GLOBAL.LEVEND_HOLIDAYSTS,
                                                               clsCommonLibrary.CORP_GLOBAL.LEVSTRTDT_OFFDUTYSTS,
                                                               clsCommonLibrary.CORP_GLOBAL.LEVEND_OFFDUTYSTS,                                                
                                                               clsCommonLibrary.CORP_GLOBAL.OFFDUTYDAYS_STATUS,
                                                               clsCommonLibrary.CORP_GLOBAL.ELIGIBLE_LEAVE_STLMNT_LMT,
                                                               clsCommonLibrary.CORP_GLOBAL.EMPDLYHR_FUTURE_DAYS,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_LEAVE_SETTLE_DAYS,

                                                               clsCommonLibrary.CORP_GLOBAL.BASIC_PAY,//payroll
                                                               clsCommonLibrary.CORP_GLOBAL.PAYROLL_INDIVIDUAL_ROUND,
                                                               clsCommonLibrary.CORP_GLOBAL.COPRT_SALARY_DATE,
                                                               clsCommonLibrary.CORP_GLOBAL.GRATUITY_START_DATE,
                                                               clsCommonLibrary.CORP_GLOBAL.ELIGIBLE_GRATUITY_DAYS,
                                                               clsCommonLibrary.CORP_GLOBAL.WORKDAY_FIXED_PAYRL_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.FIXED_PAYRL_MODE_JOIN,

                                                               clsCommonLibrary.CORP_GLOBAL.REJOIN_CONFIRMATION_MODE,//dutyrejoin
                                                               clsCommonLibrary.CORP_GLOBAL.JOINING_DATE_LIMIT,

                                                               clsCommonLibrary.CORP_GLOBAL.EMP_REF_FORMAT,//employeesection
                                                               clsCommonLibrary.CORP_GLOBAL.EMPID_AUTOFILL_STS,  
                                              
                                                               clsCommonLibrary.CORP_GLOBAL.HR_EMAIL,//mails
                                                               clsCommonLibrary.CORP_GLOBAL.RPLY_NO_MAIL,

                                                               clsCommonLibrary.CORP_GLOBAL.FOOD_AUTRTY_CAPTION,//mess
                                                               clsCommonLibrary.CORP_GLOBAL.FOOD_AUTRTY_NUMBER,

                                                               clsCommonLibrary.CORP_GLOBAL.MENU_STATUS,//general
                                                               clsCommonLibrary.CORP_GLOBAL.FREQNT_COUNT,
                                                               clsCommonLibrary.CORP_GLOBAL.RECNT_COUNT,

                                                               clsCommonLibrary.CORP_GLOBAL.FMS_VIEW_CODE_STS, //account code//FAS
                                                               clsCommonLibrary.CORP_GLOBAL.FMS_CODE_FORMATE,
                                                               clsCommonLibrary.CORP_GLOBAL.FMS_CODE_NUMBER_FORMAT,

                                                               clsCommonLibrary.CORP_GLOBAL.FMS_LDGR_DUPLICATION,//duplication
                                                               clsCommonLibrary.CORP_GLOBAL.FMS_PRDT_DUPLICATION,

                                                               clsCommonLibrary.CORP_GLOBAL.FMS_SALE_PRCHS_VISBLE_STATUS,//sales and purchase
                                                              
                                                               clsCommonLibrary.CORP_GLOBAL.AUDIT_DEPNDENT_STATUS,//audit
                                                               clsCommonLibrary.CORP_GLOBAL.REFNUM_ACCNTCLS_STS,

                                                               clsCommonLibrary.CORP_GLOBAL.TAXATION_SYSTEM,//tax
                                                              // clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED,
                                                               clsCommonLibrary.CORP_GLOBAL.TAX_PERC_DECIMAL,
                                                              

                                                               clsCommonLibrary.CORP_GLOBAL.GN_APP_HEADER_COLOR,//color
                                                               clsCommonLibrary.CORP_GLOBAL.GN_APP_FOOTER_COLOR,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_SALES_HEADER_COLOR,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_SALES_FOOTER_COLOR,

                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE,//listing
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.ITEM_LISTING_MODE,

                                                                clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,//listing
                                                               //clsCommonLibrary.CORP_GLOBAL.CMN_IMAGE_PATH,
                                                               clsCommonLibrary.CORP_GLOBAL.CMDTY_MANTN_OFFCE,
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,



                                                                 
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId); //GN_CORP_GLOBAL

            hiddenDefaultCurrencyId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();

            //HCM//
            //leavesettlement load
            if (dtCorpDetail.Rows[0]["LEVSTRTDT_HOLIDAYSTS"].ToString() == "0")
            {
                Checkboxholidaystart.Checked = false;
            }
            else
            {
                Checkboxholidaystart.Checked = true;
            }
            if (dtCorpDetail.Rows[0]["LEVEND_HOLIDAYSTS"].ToString() == "0")
            {
                Checkboxholidayend.Checked = false;
            }
            else
            {
                Checkboxholidayend.Checked = true;
            }
            if (dtCorpDetail.Rows[0]["LEVSTRTDT_OFFDUTYSTS"].ToString() == "0")
            {
                Checkboxoffdaystart.Checked = false;
            }
            else
            {
                Checkboxoffdaystart.Checked = true;
            }
            if (dtCorpDetail.Rows[0]["LEVEND_OFFDUTYSTS"].ToString() == "0")
            {
                Checkboxoffdayend.Checked = false;
            }
            else
            {
                Checkboxoffdayend.Checked = true;
            }
            leaveddl1.ClearSelection();
            if (leaveddl1.Items.FindByValue(dtCorpDetail.Rows[0]["OFFDUTYDAYS_STATUS"].ToString()) != null)
            {
                leaveddl1.Items.FindByValue(dtCorpDetail.Rows[0]["OFFDUTYDAYS_STATUS"].ToString()).Selected = true;
            }
            txteligibledays.Value = dtCorpDetail.Rows[0]["ELIGIBLE_LEAVE_STLMNT_LMT"].ToString();
            txtfuturedays.Value = dtCorpDetail.Rows[0]["EMPDLYHR_FUTURE_DAYS"].ToString();
            txtleavesettlementdays.Value = dtCorpDetail.Rows[0]["GN_LEAVE_SETTLE_DAYS"].ToString();

            //payroll load
            payrollddl1.ClearSelection();
            if (payrollddl1.Items.FindByValue(dtCorpDetail.Rows[0]["BASIC_PAY"].ToString()) != null)
            {
                payrollddl1.Items.FindByValue(dtCorpDetail.Rows[0]["BASIC_PAY"].ToString()).Selected = true;
            }
            clsCommonLibrary objCommon = new clsCommonLibrary();

            DateTime dtCorpSalaryDate = objCommon.textToDateTime(dtCorpDetail.Rows[0]["COPRT_SALARY_DATE"].ToString());
            DateTime dtGratuityDate = objCommon.textToDateTime(dtCorpDetail.Rows[0]["GRATUITY_START_DATE"].ToString());

            txtsalarydate.Value = dtCorpSalaryDate.ToString("dd-MM-yyyy");
            txtgratuitydate.Value = dtGratuityDate.ToString("dd-MM-yyyy");


            txtgratuitydays.Value = dtCorpDetail.Rows[0]["ELIGIBLE_GRATUITY_DAYS"].ToString();
            payrollddl2.ClearSelection();
            payrollddl3.ClearSelection();
            if (payrollddl2.Items.FindByValue(dtCorpDetail.Rows[0]["WORKDAY_FIXED_PAYRL_MODE"].ToString()) != null)
            {
                payrollddl2.Items.FindByValue(dtCorpDetail.Rows[0]["WORKDAY_FIXED_PAYRL_MODE"].ToString()).Selected = true;
            }

            if (payrollddl3.Items.FindByValue(dtCorpDetail.Rows[0]["FIXED_PAYRL_MODE_JOIN"].ToString()) != null)
            {
                payrollddl3.Items.FindByValue(dtCorpDetail.Rows[0]["FIXED_PAYRL_MODE_JOIN"].ToString()).Selected = true;
            }

            //dutyrejoin load

            if (dtCorpDetail.Rows[0]["REJOIN_CONFIRMATION_MODE"].ToString() == "0")
            {
                checkboxhr.Checked = false;
            }
            else
            {
                checkboxhr.Checked = true;
            }
            txtjoininglimit.Value = dtCorpDetail.Rows[0]["JOINING_DATE_LIMIT"].ToString();

            //employee section
            txtreferenceformat.Value = dtCorpDetail.Rows[0]["EMP_REF_FORMAT"].ToString();

            ddlempcode.ClearSelection();
            if (ddlempcode.Items.FindByValue(dtCorpDetail.Rows[0]["EMPID_AUTOFILL_STS"].ToString()) != null)
            {
                ddlempcode.Items.FindByValue(dtCorpDetail.Rows[0]["EMPID_AUTOFILL_STS"].ToString()).Selected = true;
            }

            //mails

            txtemailhr.Value = dtCorpDetail.Rows[0]["HR_EMAIL"].ToString();
            txtemailnoreply.Value = dtCorpDetail.Rows[0]["RPLY_NO_MAIL"].ToString();

            //mess-bill

            txtfoodcaption.Value = dtCorpDetail.Rows[0]["FOOD_AUTRTY_CAPTION"].ToString();
            txtsafetynumber.Value = dtCorpDetail.Rows[0]["FOOD_AUTRTY_NUMBER"].ToString();

            //general
            generalddl1.ClearSelection();
            if (generalddl1.Items.FindByValue(dtCorpDetail.Rows[0]["MENU_STATUS"].ToString()) != null)
            {
                generalddl1.Items.FindByValue(dtCorpDetail.Rows[0]["MENU_STATUS"].ToString()).Selected = true;
            }
            txtfrequentlyused.Value = dtCorpDetail.Rows[0]["FREQNT_COUNT"].ToString();
            txtrecentlyused.Value = dtCorpDetail.Rows[0]["RECNT_COUNT"].ToString();

            //FAS//
            //account code

            if (dtCorpDetail.Rows[0]["FMS_VIEW_CODE_STS"].ToString() == "0")
            {
                checkboxcode.Checked = false;
            }
            else
            {
                checkboxcode.Checked = true;
            }
            if (dtCorpDetail.Rows[0]["FMS_CODE_FORMATE"].ToString() == "0")
            {
                checkboxmanualtype.Checked = false;
            }
            else
            {
                checkboxmanualtype.Checked = true;
            }
            if (dtCorpDetail.Rows[0]["FMS_CODE_NUMBER_FORMAT"].ToString() == "0")
            {
                checkboxcodeasnumber.Checked = false;
            }
            else
            {
                checkboxcodeasnumber.Checked = true;
            }



            //duplication

            if (dtCorpDetail.Rows[0]["FMS_LDGR_DUPLICATION"].ToString() == "0")
            {
                checkboxledgerdup.Checked = false;
            }
            else
            {
                checkboxledgerdup.Checked = true;
            }
            if (dtCorpDetail.Rows[0]["FMS_PRDT_DUPLICATION"].ToString() == "0")
            {
                checkboxprddup.Checked = false;
            }
            else
            {
                checkboxprddup.Checked = true;
            }



            //sales and purchase

            if (dtCorpDetail.Rows[0]["FMS_SALE_PRCHS_VISBLE_STATUS"].ToString() == "0")
            {
                checkboxjournal.Checked = false;
            }
            else
            {
                checkboxjournal.Checked = true;
            }

            //accounting closing and auditing
            ddlauditstatus.ClearSelection();
            if (ddlauditstatus.Items.FindByValue(dtCorpDetail.Rows[0]["AUDIT_DEPNDENT_STATUS"].ToString()) != null)
            {
                ddlauditstatus.Items.FindByValue(dtCorpDetail.Rows[0]["AUDIT_DEPNDENT_STATUS"].ToString()).Selected = true;
            }
            ddlaccountclosing.ClearSelection();
            if (ddlaccountclosing.Items.FindByValue(dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString()) != null)
            {
                ddlaccountclosing.Items.FindByValue(dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString()).Selected = true;
            }


            //general

            //tax
            txttaxsystem.Value = dtCorpDetail.Rows[0]["TAXATION_SYSTEM"].ToString();

            if (dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString() == "1")
            {
                checkboxenabletax.Checked = true;
            }
            else
            {
                checkboxenabletax.Checked = false;
            }
            txttaxdecimal.Value = dtCorpDetail.Rows[0]["TAX_PERC_DECIMAL"].ToString();

            //colour
            txtappheader.Value = dtCorpDetail.Rows[0]["GN_APP_HEADER_COLOR"].ToString();
            txtappfooter.Value = dtCorpDetail.Rows[0]["GN_APP_FOOTER_COLOR"].ToString();
            txtsalesheader.Value = dtCorpDetail.Rows[0]["GN_SALES_HEADER_COLOR"].ToString();
            txtsalesfooter.Value = dtCorpDetail.Rows[0]["GN_SALES_FOOTER_COLOR"].ToString();



            //listing

            ddllistmode.ClearSelection();
            if (ddllistmode.Items.FindByValue(dtCorpDetail.Rows[0]["LISTING_MODE"].ToString()) != null)
            {
                ddllistmode.Items.FindByValue(dtCorpDetail.Rows[0]["LISTING_MODE"].ToString()).Selected = true;
            }

            txtlistsize.Value = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();


            ddlitemlistingmode.ClearSelection();
            if (ddllistmode.Items.FindByValue(dtCorpDetail.Rows[0]["ITEM_LISTING_MODE"].ToString()) != null)
            {
                ddlitemlistingmode.Items.FindByValue(dtCorpDetail.Rows[0]["ITEM_LISTING_MODE"].ToString()).Selected = true;
            }

            //others

            if (dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString() == "0")
            {
                checkboxcancel.Checked = false;
            }
            else
            {
                checkboxhr.Checked = true;
            }
            //txtcommonimagepath.Value = dtCorpDetail.Rows[0]["CMN_IMAGE_PATH"].ToString();
            ddlcomoditystatus.ClearSelection();
            if (ddllistmode.Items.FindByValue(dtCorpDetail.Rows[0]["CMDTY_MANTN_OFFCE"].ToString()) != null)
            {
                ddlcomoditystatus.Items.FindByValue(dtCorpDetail.Rows[0]["CMDTY_MANTN_OFFCE"].ToString()).Selected = true;
            }


            //EMP-0043 start
            CurrencyLoad();
            //end



            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdate", "SuccessUpdate();", true);
                }
            }


        }
    }
  
    
    protected void Btnsaveappsettings_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityAppSetting objEntityAppSetting = new clsEntityAppSetting();
        clsBusinessLayerAppSetting objBusinessLayerAppSetting = new clsBusinessLayerAppSetting();
        // clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAppSetting.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAppSetting.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //HCM
        //leavesettlement
        if (Checkboxholidaystart.Checked)
        {
            objEntityAppSetting.allowstart = 1;

        }
        if (Checkboxholidayend.Checked)
        {
            objEntityAppSetting.allowend = 1;

        }
        if (Checkboxoffdaystart.Checked)
        {
            objEntityAppSetting.allowoffday = 1;

        }
        if (Checkboxoffdayend.Checked)
        {
            objEntityAppSetting.blockoffday = 1;

        }
        objEntityAppSetting.calculateoffduty = Convert.ToInt32(leaveddl1.SelectedItem.Value);
        //objEntityAppSetting.leaveeligible = Convert.ToInt32(txteligibledays.Value.Trim());

        if (txteligibledays.Value.Trim() != "")
        {
            objEntityAppSetting.leaveeligible = Convert.ToInt32(txteligibledays.Value.Trim());
        }


       // objEntityAppSetting.attendancesheet = Convert.ToInt32(txtfuturedays.Value.Trim());
        if (txtfuturedays.Value.Trim() != "")
        {
            objEntityAppSetting.attendancesheet = Convert.ToInt32(txtfuturedays.Value.Trim());
        }
        if (txtleavesettlementdays.Value.Trim() != "")
        {
            objEntityAppSetting.leavesettlementdays = Convert.ToInt32(txtleavesettlementdays.Value.Trim());
        }
        //payroll

        objEntityAppSetting.basicpay = Convert.ToInt32(payrollddl1.SelectedItem.Value);
        if (individualround.Checked)
        {
            objEntityAppSetting.payrollround = 1;

        }
        objEntityAppSetting.corpsalary = objCommon.textToDateTime(txtsalarydate.Value.Trim());
        objEntityAppSetting.gratuitystart = objCommon.textToDateTime(txtgratuitydate.Value.Trim());




        //objEntityAppSetting.gratuitydays = Convert.ToInt32(txtgratuitydays.Value.Trim());
        if (txtgratuitydays.Value.Trim() != "")
        {
            objEntityAppSetting.gratuitydays = Convert.ToInt32(txtgratuitydays.Value.Trim());
        }

        objEntityAppSetting.payrollworkday = Convert.ToInt32(payrollddl2.SelectedItem.Value);
        objEntityAppSetting.payrolljoin = Convert.ToInt32(payrollddl3.SelectedItem.Value);

        //dutyrejoin
        if (checkboxhr.Checked)
        {
            objEntityAppSetting.rejoinmode = 1;

        }
       // objEntityAppSetting.joininglimit = Convert.ToInt32(txtjoininglimit.Value.Trim());

        if (txtjoininglimit.Value.Trim() != "")
        {
            objEntityAppSetting.joininglimit = Convert.ToInt32(txtjoininglimit.Value.Trim());
        }

        //employee section


        objEntityAppSetting.employeereferenceformat = Convert.ToString(txtreferenceformat.Value.Trim());
        objEntityAppSetting.employeestatus = Convert.ToInt32(ddlempcode.SelectedItem.Value);


        //mails
       
        objEntityAppSetting.hrmail = Convert.ToString(txtemailhr.Value.Trim());
        



        objEntityAppSetting.noreply = Convert.ToString(txtemailnoreply.Value.Trim());

        //messbill

        objEntityAppSetting.foodcaption = Convert.ToString(txtfoodcaption.Value.Trim());
        objEntityAppSetting.safetynumber = Convert.ToString(txtsafetynumber.Value.Trim());

        //general
        objEntityAppSetting.menubar = Convert.ToInt32(generalddl1.SelectedItem.Value);

       // objEntityAppSetting.frequent = Convert.ToInt32(txtfrequentlyused.Value.Trim());
        if (txtfrequentlyused.Value.Trim() != "")
        {
            objEntityAppSetting.frequent = Convert.ToInt32(txtfrequentlyused.Value.Trim());
        }
       // objEntityAppSetting.recent = Convert.ToInt32(txtrecentlyused.Value.Trim());
        if (txtrecentlyused.Value.Trim() != "")
        {
            objEntityAppSetting.recent = Convert.ToInt32(txtrecentlyused.Value.Trim());
        }
        //emp-0043 start
        objEntityAppSetting.primarycurrency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);

        //end





        objBusinessLayerAppSetting.UpdateAppSettingHCM(objEntityAppSetting);


        //FAS
        //acount code
        if (checkboxcode.Checked)
        {
            objEntityAppSetting.codestatus = 1;

        }
        if (checkboxmanualtype.Checked)
        {
            objEntityAppSetting.codeformat = 1;

        }
        if (checkboxcodeasnumber.Checked)
        {
            objEntityAppSetting.codeaddition = 1;

        }

        //duplication

        if (checkboxledgerdup.Checked)
        {
            objEntityAppSetting.ledgerdup = 1;

        }
        if (checkboxprddup.Checked)
        {
            objEntityAppSetting.productdup = 1;

        }

        //sales and purchase
        if (checkboxjournal.Checked)
        {
            objEntityAppSetting.salesandpurchase = 1;

        }
        objBusinessLayerAppSetting.UpdateAppSettingFAS(objEntityAppSetting);

        //auditing and accont closing
        objEntityAppSetting.auditing = Convert.ToInt32(ddlauditstatus.SelectedItem.Value);
        objEntityAppSetting.accountclosing = Convert.ToInt32(ddlaccountclosing.SelectedItem.Value);

        objBusinessLayerAppSetting.UpdateAppSettingFAS(objEntityAppSetting);


        //HiddenFieldMessage.Value = "1";

        //general
        //tax

        objEntityAppSetting.taxsystem = Convert.ToString(txttaxsystem.Value.Trim());

        if (checkboxenabletax.Checked)
        {
            objEntityAppSetting.taxenabled = 1;

        }
        //objEntityAppSetting.taxdecimal =  Convert.ToInt32(txttaxdecimal.Value.Trim());

        if (txttaxdecimal.Value.Trim() != "")
        {
            objEntityAppSetting.taxdecimal = Convert.ToInt32(txttaxdecimal.Value.Trim());
        }
        //color

        objEntityAppSetting.appheader = Convert.ToString(txtappheader.Value.Trim());
        objEntityAppSetting.appfooter = Convert.ToString(txtappfooter.Value.Trim());
        objEntityAppSetting.salesheader = Convert.ToString(txtsalesheader.Value.Trim());
        objEntityAppSetting.salesfooter = Convert.ToString(txtsalesfooter.Value.Trim());

        //listing

        objEntityAppSetting.listingmode = Convert.ToInt32(ddllistmode.SelectedItem.Value);

        //objEntityAppSetting.listingsize = Convert.ToInt32(txtlistsize.Value.Trim());
        if (txtlistsize.Value.Trim() != "")
        {
            objEntityAppSetting.listingsize = Convert.ToInt32(txtlistsize.Value.Trim());
        }



        objEntityAppSetting.itemlistingmode = Convert.ToInt32(ddlitemlistingmode.SelectedItem.Value);

        //others

        if (checkboxcancel.Checked)
        {
            objEntityAppSetting.cancelreason = 1;

        }

        //objEntityAppSetting.imagepath = Convert.ToString(txtcommonimagepath.Value.Trim());

        objEntityAppSetting.commoditystatus = Convert.ToInt32(ddlcomoditystatus.SelectedItem.Value);






        objBusinessLayerAppSetting.UpdateAppSettingGeneral(objEntityAppSetting);


        Response.Redirect("app_settings.aspx?InsUpd=Upd");
        
        //ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);

    }
    
    //END EVM 040

    //emp-0043 start
    public void CurrencyLoad()
    {
        clsBusinessLayer objBusinessSales = new clsBusinessLayer();
        clsEntityCommon ObjEntitySales = new clsEntityCommon();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntitySales.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntitySales.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntitySales.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        ddlCurrency.ClearSelection();
        DataTable dtSubConrt = objBusinessSales.ReadCurrency(ObjEntitySales);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlCurrency.DataSource = dtSubConrt;
            ddlCurrency.DataTextField = "CRNCMST_NAME";
            ddlCurrency.DataValueField = "CRNCMST_ID";
            ddlCurrency.DataBind();
        }
        ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");

        string strdefltcurrcy = hiddenDefaultCurrencyId.Value;
        if (ddlCurrency.Items.FindByValue(strdefltcurrcy) != null)
        {
            ddlCurrency.ClearSelection();
            ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
        }
    }

}    
