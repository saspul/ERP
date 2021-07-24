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
// CREATED BY:EVM-0001
// CREATED DATE:
// REVIEWED BY:
// REVIEW DATE
public partial class MasterPage_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Session["USERNAME"] = "ajay";
            //Session["USERID"] = 10026;
            //Session["WRKSTNID"] = 0;

            //Creating objects for business layer.
          
            DataTable dtConfigDtl = new DataTable();
            clsBusinessLayer objBusines = new clsBusinessLayer();      
            dtConfigDtl = objBusines.LoadConfigDetail();
            string strCompanyName = "", strCompanyWeb = "";
            string strDvlprInfo = "0";
            string strProductName = "";
            if (dtConfigDtl.Rows.Count > 0)
            {
                strDvlprInfo = dtConfigDtl.Rows[0]["DVLPR_INFO"].ToString().Trim();
                strProductName = dtConfigDtl.Rows[0]["PRODUCT_NAME"].ToString().Trim();
            }


            


            //to show developed by information
            if (strDvlprInfo == "1")
            {
               

                DataTable dtCompanyDetail = new DataTable();
                clsCommonLibrary.APP_COMPANY[] arrEnumer = { clsCommonLibrary.APP_COMPANY.CMPNY_NAME, clsCommonLibrary.APP_COMPANY.CMPNY_WEB };
                dtCompanyDetail = objBusines.LoadCompanyDetail(arrEnumer);
                if (dtCompanyDetail.Rows.Count > 0)
                {
                    strCompanyName = dtCompanyDetail.Rows[0]["CMPNY_NAME"].ToString();
                    strCompanyWeb = "http://" + dtCompanyDetail.Rows[0]["CMPNY_WEB"].ToString();

                }
                divdevelop.InnerHtml = "Developed by: <a target= \"_blank \" href=\"" + strCompanyWeb + "\">" + strCompanyName + "</a> ";
            }
            else
            {
                divdevelop.InnerHtml = "";

            }
          
            EL_Compzit.clsEntityLayerLogin objEntity = null;
            objEntity = new EL_Compzit.clsEntityLayerLogin();
            if (Session["USERNAME"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {

                lblUserName.Text = Session["USERNAME"].ToString();

            }
            if (Session["USERID"].ToString() != null)
            {
                objEntity.UserIdInt = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"].ToString() == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["WRKSTNID"].ToString() != null)
            {
                objEntity.WorkStatnId = Convert.ToInt32(Session["WRKSTNID"].ToString());

            }

            else if (Session["WRKSTNID"].ToString() == null)
            {
                Response.Redirect("~/Default.aspx");

            }
            objEntity.AppType = 'W';
            clsBusinessLayerMenu objBusinessMenu = new clsBusinessLayerMenu();
            StringBuilder objstrb = new StringBuilder();
            objstrb = objBusinessMenu.GetMenuData(objEntity);
            divmenu.InnerHtml = objstrb.ToString();



            if (strCompanyName == "")
            {
                DataTable dtCompanyDet = new DataTable();
                clsCommonLibrary.APP_COMPANY[] arrEnumertn = { clsCommonLibrary.APP_COMPANY.CMPNY_NAME };
                dtCompanyDet = objBusines.LoadCompanyDetail(arrEnumertn);
                if (dtCompanyDet.Rows.Count > 0)
                {
                    strCompanyName = dtCompanyDet.Rows[0]["CMPNY_NAME"].ToString();


                }
            }
            //if session Work Station is 0 then workstation is not allocated
            if (objEntity.WorkStatnId == 0)
            {
                if (Session["CORPORATENAME"] != null)
                {
                    divheaderName.InnerHtml = Session["CORPORATENAME"].ToString();
                }
                else
                {
                
                        if (Session["ORGNAME"] != null)
                        {
                            divheaderName.InnerHtml = Session["ORGNAME"].ToString();
                        }
                        else
                        {
                 divheaderName.InnerHtml = strCompanyName;
                
                        }
                
                
                }
            }
            else
            {
            
            string strHeader=Session["CORPORATENAME"].ToString()+" ( "+Session["PREMISENAME"]+" )";
            
              divheaderName.InnerHtml = strHeader;
            
            }
               




            


        }
    }
}
