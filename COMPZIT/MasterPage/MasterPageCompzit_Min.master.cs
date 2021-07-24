using BL_Compzit;
using CL_Compzit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_MasterPageCompzit_Min : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (!Request.FilePath.Contains("Default"))
            //{
            //    string strPreviousPage = "";
            //    if (Request.UrlReferrer != null)
            //    {
            //        strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
            //    }
            //    if (strPreviousPage == "")
            //    {
            //        Response.Redirect("~/Default.aspx");
            //    }
            //}

            DataTable dtConfigDtl = new DataTable();
            clsBusinessLayer objBusines = new clsBusinessLayer();
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
                divdevelop.InnerHtml = "Developed by: <a target= \"_blank \" href=\"" + strCompanyWeb + "\">" + strCompanyName + "</a> ";
            }
            else
            {
                divdevelop.InnerHtml = "";

            }
            //for changing color of header and footer
            if (Session["CORPOFFICEID"] != null)
            {
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.GN_APP_HEADER_COLOR, clsCommonLibrary.CORP_GLOBAL.GN_APP_FOOTER_COLOR };
                DataTable dtCorpDetail = new DataTable();
                int intCorpId = 0;

                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);

                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    hiddenHeaderColor.Value = dtCorpDetail.Rows[0]["GN_APP_HEADER_COLOR"].ToString();
                    hiddenFooterColor.Value = dtCorpDetail.Rows[0]["GN_APP_FOOTER_COLOR"].ToString();
                }
            }

        }
    }
}
