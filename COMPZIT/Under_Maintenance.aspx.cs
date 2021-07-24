using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using BL_Compzit;
using CL_Compzit;
using System.Data;
using System.Configuration;
public partial class Security_Under_Maintenance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strWorkingSts = ConfigurationManager.AppSettings["WorkingStatus"];
        if (strWorkingSts == "1")
        {
           Response.Redirect("/Security/Login.aspx");
        }
        if (!IsPostBack)
        {
            DataTable dtConfigDtl = new DataTable();
            clsBusinessLayerLogin objBusinesLogin = new clsBusinessLayerLogin();
            clsBusinessLayer objBusines = new clsBusinessLayer();
            //Emp15--Tocheck wheather the employee is resigned on that date
            clsBusinessLayerPersonalDtls objBusinessLayerPersonalDtls = new clsBusinessLayerPersonalDtls();
            objBusinessLayerPersonalDtls.EmployeeResign();
            dtConfigDtl = objBusines.LoadConfigDetail();
            string strDvlprInfo = "0";
            if (dtConfigDtl.Rows.Count > 0)
            {
                strDvlprInfo = dtConfigDtl.Rows[0]["DVLPR_INFO"].ToString().Trim(); 
            }
            //to show developed by information
            if (strDvlprInfo == "1")
            {
                string strCompanyName = "", strCompanyWeb = "";

                DataTable dtCompanyDetail = new DataTable();
                clsCommonLibrary.APP_COMPANY[] arrEnumer = { clsCommonLibrary.APP_COMPANY.CMPNY_NAME, clsCommonLibrary.APP_COMPANY.CMPNY_WEB, clsCommonLibrary.APP_COMPANY.CHNL_PARTNR_NAME, clsCommonLibrary.APP_COMPANY.CHNL_PARTNR_WEB };
                dtCompanyDetail = objBusines.LoadCompanyDetail(arrEnumer);
                if (dtCompanyDetail.Rows.Count > 0)
                {
                    if (dtCompanyDetail.Rows[0]["CHNL_PARTNR_NAME"].ToString() != "")
                    {
                        strCompanyName = dtCompanyDetail.Rows[0]["CHNL_PARTNR_NAME"].ToString();
                        strCompanyWeb = "http://" + dtCompanyDetail.Rows[0]["CHNL_PARTNR_WEB"].ToString();
                    }
                    else
                    {
                        strCompanyName = dtCompanyDetail.Rows[0]["CMPNY_NAME"].ToString();
                        strCompanyWeb = "http://" + dtCompanyDetail.Rows[0]["CMPNY_WEB"].ToString();

                    }
                }

                divdevelop.InnerHtml = "<p>Copyright 2019 <a href=\"#\">Compzit</a> | Developed by <a target=\"_blank \" href=\"" + strCompanyWeb + "\">" + strCompanyName + "</a></p>";
            }
            else
            {
                divdevelop.InnerHtml = "<p>Copyright 2019 <a href=\"#\">Compzit</a></p>";
            }
        }
    }
}