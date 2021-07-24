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


public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Attendance_Sheet_hcm_Monthly_Attendance_Sheet_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        DropDownList2.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        DropDownList2.Attributes.Add("onkeypress", "return DisableEnter(event)");
        DropDownList3.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        DropDownList3.Attributes.Add("onkeypress", "return DisableEnter(event)");

        if (!IsPostBack)
        {
            YearLoad();
            monthLoad();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayerEmployeeDailyWorkHour objBusinessEmpDailyWorkHour = new clsBusinessLayerEmployeeDailyWorkHour();
            clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour = new clsEntityEmployeeDailyWorkHour();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

            Session["DailyWrkView"] = null;


            int intUserId = 0, intUsrRolMstrId;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityEmpDailyWorkHour.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityEmpDailyWorkHour.orgid = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            if (Session["USERID"] != null)
            {
                objEntityEmpDailyWorkHour.UserId = Convert.ToInt32(Session["USERID"].ToString());
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }



            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Daily_Attendance_Sheet);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            divAdd.Visible = false;
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {

                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        divAdd.Visible = true;
                    }


                }
            }


        }
    }
    protected void YearLoad()
    {

        DropDownList3.Items.Clear();
        // created object for business layer for compare the date
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strCurrentDate = objBusiness.LoadCurrentDateInString();
        string[] split = strCurrentDate.Split('-');

        var currentYear = Convert.ToInt32(split[2]);
        for (int i = 0; i <= 20; i++)
        {
            // Now just add an entry that's the current year minus the counter
            DropDownList3.Items.Add((currentYear - i).ToString());

        }
        DropDownList3.Items.Insert(0, "--SELECT YEAR--");
    }
    public void monthLoad()
    {
        DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
        for (int i = 1; i < 13; i++)
        {
            DropDownList2.Items.Add(new ListItem(info.GetMonthName(i).ToUpper(), i.ToString()));
        }
        DropDownList2.Items.Insert(0, "--SELECT MONTH--");
    }
    protected void btnRedirect_Click(object sender, EventArgs e)
    {
        Session["DailyWrkView"] = HiddenViewId.Value;
        Response.Redirect("/HCM/HCM_Master/hcm_PayrollSystem/hcm_Monthly_Attendance_Sheet/hcm_Monthly_Attendance_Sheet_View.aspx");
    }
}