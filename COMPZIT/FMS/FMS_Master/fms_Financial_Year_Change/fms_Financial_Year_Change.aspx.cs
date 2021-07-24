using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusinessLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using System.Data;
using System.Web.Services;
using BL_Compzit.BusineesLayer_FMS;
using System.Text;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Globalization;
using System.Web;

public partial class FMS_FMS_Master_fms_Financial_Year_Change_fms_Financial_Year_Change : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FRMWRK_ID"] != null && Session["FRMWRK_ID"].ToString() == "2")
        {
            aHome.HRef = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
        }
        else
        {
            aHome.HRef = " /Home/Compzit_LandingPage/Compzit_LandingPage.aspx";
        }
        if (!IsPostBack)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntity_Account_Setting objEntity = new clsEntity_Account_Setting();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                objEntity.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntity.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntity.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }     
            FinancialYearLoad();          
        }
    }
   

    public void FinancialYearLoad()
    {
        clsEntity_Account_Setting objEntityAccount = new clsEntity_Account_Setting();
        clsBusiness_Account_Setting objBussinessAccount = new clsBusiness_Account_Setting();
        if (Session["USERID"] != null)
        {
            objEntityAccount.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccount.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccount.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussinessAccount.ReadFinancialYear(objEntityAccount);
        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("FINCYR_ID", typeof(int));
        dtDetail.Columns.Add("FINCYR_START_DT", typeof(string));
        dtDetail.Columns.Add("FINCYR_END_DT", typeof(string));
        dtDetail.Columns.Add("FINCYR_STATUS", typeof(int));
        dtDetail.Columns.Add("FINCYR_DEFAULTNAME", typeof(string));
        for (int intCount = 0; intCount < dtSubConrt.Rows.Count; intCount++)
        {
            DataRow drDtl = dtDetail.NewRow();
            drDtl["FINCYR_ID"] = Convert.ToInt32(dtSubConrt.Rows[intCount]["FINCYR_ID"].ToString());
            drDtl["FINCYR_START_DT"] = dtSubConrt.Rows[intCount]["START_DATE"].ToString();
            drDtl["FINCYR_END_DT"] = dtSubConrt.Rows[intCount]["END_DATE"].ToString();
            drDtl["FINCYR_STATUS"] = Convert.ToInt32(dtSubConrt.Rows[intCount]["FINCYR_STATUS"].ToString());
            drDtl["FINCYR_DEFAULTNAME"] = dtSubConrt.Rows[intCount]["FINCYR_DEFAULTNAME"].ToString();
            dtDetail.Rows.Add(drDtl);
        }
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        HiddenFinancialYear.Value = strJson;
    }

    public static string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);

            }

            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);
    }

    [WebMethod(EnableSession = true)]
    public static void ChangeFinYear(String id)
    {
        if (id != "")
        {
            HttpContext.Current.Session["FINCYRID"] = Convert.ToInt32(id);
        }
    }

}