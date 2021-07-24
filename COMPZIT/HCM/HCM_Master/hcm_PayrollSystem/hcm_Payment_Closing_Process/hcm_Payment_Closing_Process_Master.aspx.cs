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
        hiddenTodate.Value = System.DateTime.Now.Day + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Year;
        ddlmode.Focus();
        ddlEmployee.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlEmployee.Attributes.Add("onkeypress", "return DisableEnter(event)");
        DropDownList2.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        DropDownList2.Attributes.Add("onkeypress", "return DisableEnter(event)");
        DropDownList3.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        DropDownList3.Attributes.Add("onkeypress", "return DisableEnter(event)");
        if (!IsPostBack)
        {
            Session["Succes"] = "";
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            clsEntityCommon objEntityCommon = new clsEntityCommon();
            // DeductionLoad();
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableReOpen = 0, intEnableHrConfirm = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableClose = 0;
            int IntAllBusinessUnit = 0;
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
            
            DataTable dtemp = objBusinessLayer.ReadEmployeeDtl(objEntityCommon);

         
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Payment_closing);

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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString())
                    {
                        IntAllBusinessUnit = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                }

            }

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {
                                                             clsCommonLibrary.CORP_GLOBAL.PAYROLL_INDIVIDUAL_ROUND
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenFieldIndividualRound.Value = dtCorpDetail.Rows[0]["PAYROLL_INDIVIDUAL_ROUND"].ToString();
            }



            cls_Entity_Monthly_Salary_Process objEnt = new cls_Entity_Monthly_Salary_Process();
            cls_Business_Monthly_Salary_Process objBuss = new cls_Business_Monthly_Salary_Process();
            DataTable dtBussUnit;
            objEnt.CorpOffice = Convert.ToInt32(intCorpId);
            objEnt.Orgid = Convert.ToInt32(intOrgId);
            objEnt.UserId = Convert.ToInt32(intUserId);
            int AllBussnsUnit = 0;
            if (IntAllBusinessUnit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                AllBussnsUnit = 1;
            }

            dtBussUnit = objBuss.LoadBissnusUnit(objEnt, AllBussnsUnit);

            LoadBussUnit(dtBussUnit);
            YearLoad();
            monthLoad();
        }

    }
    public void LoadBussUnit(DataTable dt)
    {
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        if (dt.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dt;
            ddlEmployee.DataTextField = "CORPRT_NAME";
            ddlEmployee.DataValueField = "CORPRT_ID";
            ddlEmployee.DataBind();
        }
        ddlEmployee.ClearSelection();
        bool existsCus = dt.Select().ToList().Exists(row => row["CORPRT_ID"].ToString().ToUpper() == intCorpId.ToString());
        if (existsCus == true)
        {

            ddlEmployee.Items.FindByValue(intCorpId.ToString()).Selected = true;
        }
        else
        {
            ddlEmployee.Items.Insert(0, "--SELECT BUSINESS UNIT--");
        }
    }
   
    protected void  YearLoad()
    {

        DropDownList3.Items.Clear();
        // created object for business layer for compare the date
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        string[] split = strCurrentDate.Split('-');

        var currentYear = Convert.ToInt32(split[2]);
        for (int i = 0; i <=20; i++)
        {
            // Now just add an entry that's the current year minus the counter
            DropDownList3.Items.Add((currentYear - i).ToString());

        }
        DropDownList3.Items.Insert(0, "--SELECT YEAR--");
    }
    public void monthLoad(){
        DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
        for (int i = 1; i < 13; i++)
        {
            DropDownList2.Items.Add(new ListItem(info.GetMonthName(i).ToUpper(), i.ToString()));
        }
        DropDownList2.Items.Insert(0, "--SELECT MONTH--");
    }

    [WebMethod]
    public static void PaymentClose(string userId, string id, string Mode, string Paid)
    {
        clsEntityLayer_Payment_Closing objEntityEmployeeDeduction = new clsEntityLayer_Payment_Closing();
        clsBusinessLayer_payment_Closing objBusinessLayerEmployeeDeductn = new clsBusinessLayer_payment_Closing();
        objEntityEmployeeDeduction.UserId = Convert.ToInt32(userId);
        objEntityEmployeeDeduction.CloseId = Convert.ToInt32(id);
        objEntityEmployeeDeduction.Mode = Convert.ToInt32(Mode);
        objEntityEmployeeDeduction.date = System.DateTime.Now;
        if (Paid != "")
        {
            objEntityEmployeeDeduction.PaidAmnt = Convert.ToDecimal(Paid);
        }
        objBusinessLayerEmployeeDeductn.closePayment(objEntityEmployeeDeduction);

    }
}