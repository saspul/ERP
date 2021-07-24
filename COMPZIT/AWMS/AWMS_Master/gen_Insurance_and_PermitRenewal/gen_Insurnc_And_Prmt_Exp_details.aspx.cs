using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
//using BL
// CREATED BY:WEM-0006
// CREATED DATE:19/10/2016
// REVIEWED BY:
// REVIEW DATE:
public partial class AWMS_AWMS_Master_gen_Insurance_and_PermitRenewal_gen_Insurnc_And_Prmt_Exp_details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hiddenRoleAdd.Value = "0";
        //txtNewPermitNum.Attributes.Add("onkeypress", "return isTag(event)");
        //txtNewPermitNum.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtNewPerDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtNewPerDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtNewInsrncNmbr.Attributes.Add("onkeypress", "return isTag(event)");
        txtNewInsrncNmbr.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtNewInsrncDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtNewInsrncDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        ddlInsrncPrvdrId.Attributes.Add("onkeypress", "return isTag(event)");
        ddlInsrncPrvdrId.Attributes.Add("onchange", "IncrmntConfrmCounter()");


        ddlNewCoverageType.Attributes.Add("onkeypress", "return isTag(event)");
        ddlNewCoverageType.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            //Creating objects for business layer
            clsBusinessLayerInsuranceAndPermitExp objBusinessLayerInsunc = new clsBusinessLayerInsuranceAndPermitExp();
            clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();
              clsEntityCommon objEntityCommon = new clsEntityCommon();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
            if (Session["USERID"] != null)
            {
                objEntityInsunc.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityInsunc.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityInsunc.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            //for common naming field

          
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.VEHICLE_MASTER);
            objEntityCommon.CommonLabelFieldName = "VHCL_PERMIT_NUMBR";
           
            string strPermit = "";
            DataTable dtLblName = new DataTable();
            dtLblName = objBusinessLayer.ReadGeneralLabelName(objEntityCommon);
            if (dtLblName.Rows.Count > 0)
            {
                strPermit = dtLblName.Rows[0]["CMNLBL_NAME_TOCHNG"].ToString();
                hiddenPermitLabelName.Value = strPermit;

            }
           
          

            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Insurance_Permit_Renewal);

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
                        hiddenRoleAdd.Value = "1";
                    }


                }

            }

            if (Request.QueryString["Mode"] != null)
            {
                HiddenFieldTR.Value = Request.QueryString["Mode"].ToString();
            }

            if (Request.QueryString["insd"] != null && Request.QueryString["Mode"] != null)
            {

              
                    HiddenAtchmnt.Value = "INSUR";
                    if (Request.QueryString["Bck"] != null)
                    {
                        hiddenRedirect.Value = Request.QueryString["insd"].ToString();
                        hiddenRedirectMode.Value = "INSUR";
                    }

                    string strRandomMixedId = Request.QueryString["insd"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    hiddenInsudate.Value = Request.QueryString["insd"].ToString();

                    InsuUpdate(strId);
                    divInsuranceContainer.Attributes["style"] = "display: block";
                    txtNewInsrncNmbr.Focus();
              
            }


            if (Request.QueryString["permd"] != null && Request.QueryString["Mode"] != null)
            {
                HiddenAtchmnt.Value = "PRMT";
                if (Request.QueryString["Bck"] != null)
                {
                    hiddenRedirect.Value = Request.QueryString["permd"].ToString();
                    hiddenRedirectMode.Value = "PRMT";
                }

                string strRandomMixedId = Request.QueryString["permd"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                hiddenPrmtdate.Value = Request.QueryString["permd"].ToString();
              
                PrmtUpdate(strId);
                divPermitContainer.Attributes["style"] = "display: block";
               // txtNewPermitNum.Focus();
            }
            // created object for business layer for compare the date
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            string strCurrentDate = objBusiness.LoadCurrentDateInString();

            hiddenCurrentDate.Value = strCurrentDate;


            // created object for business layer for compare the date

            int intCorpId = objEntityInsunc.Corporate_Id; 

            
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                   };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCountMoney.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }

            hiddenPermitFileSize.Value = clsCommonLibrary.IMAGE_SIZE.VEHICLE_ATTACHMENT.ToString();
           
            // cliebt side number format
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();

            }
        }
    }
    protected void InsCoverageTypeLoad()
    {
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        DataTable dtVehDetails = new DataTable();
        dtVehDetails = objBusinessVehicle.ReadInsCoverageType();
        if (dtVehDetails.Rows.Count > 0)
        {
            ddlNewCoverageType.DataSource = dtVehDetails;
            ddlNewCoverageType.DataValueField = "COVRGTYP_ID";
            ddlNewCoverageType.DataTextField = "COVRGTYP_NAME";
            ddlNewCoverageType.DataBind();
            ddlNewCoverageType.Items.Insert(0, "--SELECT COVERAGE TYPE--");
        }
    }

    public void InsuUpdate(string strId)
    {
        InsurncProvdrIdr();
        InsCoverageTypeLoad();

        lblEntry.Text = "Vehicle Insurance Renewal";

        clsBusinessLayerInsuranceAndPermitExp objBusinessLayerInsunc = new clsBusinessLayerInsuranceAndPermitExp();
        clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();
        clsEntityInsuranceAndPermitAttchmntDtl objEntityAttchmntDtl = new clsEntityInsuranceAndPermitAttchmntDtl();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            objEntityInsunc.User_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsunc.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsunc.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


       string strRnwlID="";
       objEntityInsunc.Mode = Convert.ToInt32(Request.QueryString["Mode"].ToString());
     

       objEntityInsunc.VehicleId =Convert.ToInt32(strId);
       DataTable dtExpInsu = objBusinessLayerInsunc.ReadExpVehicleDetails(objEntityInsunc);
        if (dtExpInsu.Rows.Count > 0)
        {
        txtVehicleNumber.Enabled = false;
        txtVehicleClass.Enabled = false;
        txtOldInsrncDate.Enabled = false;
        txtOldInsrncNumbr.Enabled = false;
        txtOldCoverageType.Enabled = false;
        txtInsurncPrvdrid.Enabled = false;
        txtOldInsAmount.Enabled = false;
        hiddenVehId.Value = strId;
           
            txtVehicleClass.Text = dtExpInsu.Rows[0]["VHCLCLS_NAME"].ToString();

            if (objEntityInsunc.Mode == 1)
            {
                txtVehicleNumber.Text = dtExpInsu.Rows[0]["VHCL_NUMBR"].ToString();
                txtOldInsrncDate.Text = dtExpInsu.Rows[0]["VHCL_INSUR_EXPR_DATE"].ToString();
                txtOldInsrncNumbr.Text = dtExpInsu.Rows[0]["VHCL_INSUR_NUMBR"].ToString();
                txtInsurncPrvdrid.Text = dtExpInsu.Rows[0]["INSURPRVDR_NAME"].ToString();
                txtOldInsAmount.Text = dtExpInsu.Rows[0]["VHCL_INSUR_AMNT"].ToString();
                hiddenInsPrvdr.Value = dtExpInsu.Rows[0]["INSURPRVDR_ID"].ToString();
                txtOldCoverageType.Text = dtExpInsu.Rows[0]["COVRGTYP_NAME"].ToString();
                hiddenInsCovrgtyp.Value = dtExpInsu.Rows[0]["COVRGTYP_ID"].ToString();
                strRnwlID = dtExpInsu.Rows[0]["INSURRNWL_ID"].ToString();
            }
            else if(objEntityInsunc.Mode == 2)
            {

                txtVehicleNumber.Text = dtExpInsu.Rows[0]["TRLER_REG_NUMBR"].ToString();
                txtOldInsrncDate.Text = dtExpInsu.Rows[0]["TR_INS_EXPR_DATE"].ToString();
                txtOldInsrncNumbr.Text = dtExpInsu.Rows[0]["TRLER_INSUR_NUMBR"].ToString();
                txtInsurncPrvdrid.Text = dtExpInsu.Rows[0]["TR_INSPVDR_NAME"].ToString();
                txtOldInsAmount.Text = dtExpInsu.Rows[0]["TR_INS_AMNT"].ToString();
                hiddenInsPrvdr.Value = dtExpInsu.Rows[0]["TR_INSPVDR_ID"].ToString();
                txtOldCoverageType.Text = dtExpInsu.Rows[0]["TR_INSCVRG_NAME"].ToString();
                hiddenInsCovrgtyp.Value = dtExpInsu.Rows[0]["TR_INSCVRG_ID"].ToString();
                strRnwlID = dtExpInsu.Rows[0]["TR_INSRNWL_ID"].ToString();
            }






            if (strRnwlID != "" && strRnwlID!=null)
            {
                string strPrmtNum = strRnwlID;
                objEntityAttchmntDtl.RnwlId = Convert.ToInt32(strPrmtNum);
                DataTable dtPrmtAtcmnt = objBusinessLayerInsunc.ReadInsurRnwlFiles(objEntityAttchmntDtl);
                if (dtPrmtAtcmnt.Rows.Count > 0)
                {
                    string strImage;
                    strImage = "<table>";
                    for (int i = 0; i < dtPrmtAtcmnt.Rows.Count; i++)
                    {
                        hiddenInsuranceFile.Value = dtPrmtAtcmnt.Rows[i]["INSATCH_FILE_NAME"].ToString();
                        string strFileName = dtPrmtAtcmnt.Rows[i]["INSATCH_FILE_NAME"].ToString();
                        string strDecrptn = dtPrmtAtcmnt.Rows[i]["INSATCH_DESC"].ToString();
                        //    divImageEdit.Visible = true;
                        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER) + dtPrmtAtcmnt.Rows[i]["INSATCH_FILE_NAME"].ToString();
                        string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                        if (strFileExt == "gif" || strFileExt == "png" || strFileExt == "bmp" || strFileExt == "jpeg" || strFileExt == "jpg")
                        {
                            // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
                            strImage += "<tr><td>";
                            strImage += "<a class=\"tooltip\"  title=\"" + strDecrptn + "\" style=\"opacity:1;font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofyINS" + i + "\" >Click to View Image Uploaded</a>";
                            strImage += " <div class=\"lightbox-target\" id=\"goofyINS" + i + "\">";
                            strImage += " <img src=\"" + strImagePath + "\"/>";
                            strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                            strImage += "</div>";
                            strImage += "</td></tr>";
                        }
                        else
                        {
                            strImage += "<tr><td>";
                            strImage += "<a class=\"tooltip\"  title=\"" + strDecrptn + "\" style=\"opacity:1;font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\"  target=\"_blank\" >Click to View Attachment Uploaded</a>";
                            strImage += "</td></tr>";
                        }
                    }
                    strImage += "</table>";
                    divOldImageDisplayInsur.InnerHtml = strImage;

                }
                else
                {
                    string strImage = "<Label Style=\"font-family: Calibri; font-size: medium;\">No File Uploaded</asp:Label>";
                    divOldImageDisplayInsur.InnerHtml = strImage;
                }
            }
            else
            {
                DataTable dtPrmtAtcmnt = objBusinessLayerInsunc.ReadInsurFiles(objEntityInsunc);
                if (dtPrmtAtcmnt.Rows.Count > 0)
                {
                    string strImage;
                    strImage = "<table>";
                    for (int i = 0; i < dtPrmtAtcmnt.Rows.Count; i++)
                    {
                        hiddenInsuranceFile.Value = dtPrmtAtcmnt.Rows[i][0].ToString();
                        string strFileName = dtPrmtAtcmnt.Rows[i][0].ToString();
                        string strDecrptn = dtPrmtAtcmnt.Rows[i][1].ToString();
                        //    divImageEdit.Visible = true;
                        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER) + dtPrmtAtcmnt.Rows[i][0].ToString();
                        string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                        if (strFileExt == "gif" || strFileExt == "png" || strFileExt == "bmp" || strFileExt == "jpeg" || strFileExt == "jpg")
                        {
                            // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
                            strImage += "<tr><td>";
                            strImage += "<a class=\"tooltip\"  title=\"" + strDecrptn + "\" style=\"opacity:1;font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofyINS" + i + "\" >Click to View Image Uploaded</a>";
                            strImage += " <div class=\"lightbox-target\" id=\"goofyINS" + i + "\">";
                            strImage += " <img src=\"" + strImagePath + "\"/>";
                            strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                            strImage += "</div>";
                            strImage += "</td></tr>";
                        }
                        else
                        {
                            strImage += "<tr><td>";
                            strImage += "<a class=\"tooltip\"  title=\"" + strDecrptn + "\" style=\"opacity:1;font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\"  target=\"_blank\" >Click to View Attachment Uploaded</a>";
                            strImage += "</td></tr>";
                        }
                    }
                    strImage += "</table>";
                    divOldImageDisplayInsur.InnerHtml = strImage;

                }
                else
                {
                    string strImage = "<Label Style=\"font-family: Calibri; font-size: medium;\">No File Uploaded</asp:Label>";
                    divOldImageDisplayInsur.InnerHtml = strImage;
                }
            }

         


        }

        if (hiddenRoleAdd.Value == "0")
        {
            btnAdd.Visible = false;
            divNewInsNum.Visible = false;
            divInsDate.Visible = false;
            divNewInsurPrvdr.Visible = false;
            divInsureAmount.Visible = false;
        }
    }

    public void PrmtUpdate(string strId)
    {
        string PermitName = "Permit";
        if (hiddenPermitLabelName.Value != "")
        {
            PermitName = hiddenPermitLabelName.Value.ToString();
        }
        lblEntry.Text = "Vehicle "+PermitName+" Renewal";   
        lblNewPrmtdate.InnerText = "New " + PermitName + " Date*";  
        lblOldPermitDate.Text = "Previous " + PermitName + " Date";
        lblOldPermitFile.Text = "Previous " + PermitName + " File";
        clsBusinessLayerInsuranceAndPermitExp objBusinessLayerInsunc = new clsBusinessLayerInsuranceAndPermitExp();
        clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();
        clsEntityInsuranceAndPermitAttchmntDtl objEntityAttchmntDtl=new clsEntityInsuranceAndPermitAttchmntDtl();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            objEntityInsunc.User_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsunc.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsunc.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


     
        objEntityInsunc.Mode = Convert.ToInt32(Request.QueryString["Mode"].ToString());
       
        objEntityInsunc.VehicleId = Convert.ToInt32(strId);
   
        DataTable dtExpInsu = objBusinessLayerInsunc.ReadExpVehicleDetails(objEntityInsunc);

        if (dtExpInsu.Rows.Count > 0)
        {
            txtVehNumberPer.Enabled = false;
            txtVehicleClassPer.Enabled = false;
            txtOldPermitDate.Enabled = false;
        
            hiddenVehId.Value = strId;
         
           
            txtVehicleClassPer.Text = dtExpInsu.Rows[0]["VHCLCLS_NAME"].ToString();

            if (objEntityInsunc.Mode == 1)
            {
                txtVehNumberPer.Text = dtExpInsu.Rows[0]["VHCL_NUMBR"].ToString();
                txtOldPermitDate.Text = dtExpInsu.Rows[0]["VHCL_PERMIT_EXPR_DATE"].ToString();
            }
            else if (objEntityInsunc.Mode == 2)
            {
                txtVehNumberPer.Text = dtExpInsu.Rows[0]["TRLER_REG_NUMBR"].ToString();
                txtOldPermitDate.Text = dtExpInsu.Rows[0]["TR_PERMIT_EXPR_DATE"].ToString();
            }
            objEntityInsunc.VehiclNmbr = txtVehNumberPer.Text;
            DataTable dtPrmtRnwlId = objBusinessLayerInsunc.ReadPermitRnwlId(objEntityInsunc);


            if (dtPrmtRnwlId.Rows[0]["PRMT_RNWLID"] != DBNull.Value && dtPrmtRnwlId.Rows[0]["PRMT_RNWLID"].ToString() != "")
            {
                string strPrmtNum = dtPrmtRnwlId.Rows[0]["PRMT_RNWLID"].ToString();

                objEntityAttchmntDtl.RnwlId = Convert.ToInt32(strPrmtNum);
                DataTable dtPrmtAtcmnt = objBusinessLayerInsunc.ReadPermtRnwlFiles(objEntityAttchmntDtl);
                if (dtPrmtAtcmnt.Rows.Count > 0)
                {
                    string strImage;
                    strImage = "<table>";
                    for (int i = 0; i < dtPrmtAtcmnt.Rows.Count; i++)
                    {
                        hiddenPermitFile.Value = dtPrmtAtcmnt.Rows[i]["PERATCH_FILE_NAME"].ToString();
                        string strFileName = dtPrmtAtcmnt.Rows[i]["PERATCH_FILE_NAME"].ToString();
                        string strDecrptn = dtPrmtAtcmnt.Rows[i]["PERATCH_DESC"].ToString();

                        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER) + dtPrmtAtcmnt.Rows[i]["PERATCH_FILE_NAME"].ToString();
                        string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                        if (strFileExt == "gif" || strFileExt == "png" || strFileExt == "bmp" || strFileExt == "jpeg" || strFileExt == "jpg")
                        {
                            // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
                            strImage += "<tr><td>";
                            strImage += "<a class=\"tooltip\"  title=\"" + strDecrptn + "\" style=\"opacity:1;font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy1" + i + "\"  >Click to View Image Uploaded</a>";
                            strImage += " <div class=\"lightbox-target\" id=\"goofy1" + i + "\">";
                            strImage += " <img src=\"" + strImagePath + "\"/>";
                            strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                            strImage += "</div>";
                            strImage += "</td></tr>";

                        }
                        else
                        {
                            strImage += "<tr><td>";
                            strImage += "<a class=\"tooltip\"  title=\"" + strDecrptn + "\" style=\"opacity:1;font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\"  target=\"_blank\" >Click to View Attachment Uploaded</a>";
                            strImage += "</td></tr>";
                        }
                    }
                    strImage += "</table>";
                    divOldImageDisplayPermit.InnerHtml = strImage;

                }
                else
                {
                    string strImage = "<Label Style=\"font-family: Calibri; font-size: medium;\">No File Uploaded</asp:Label>";
                    divOldImageDisplayPermit.InnerHtml = strImage;
                }
            }
            else
            {
                DataTable dtVhclPrmtFiles = objBusinessLayerInsunc.ReadPermitFiles(objEntityInsunc);
                if (dtVhclPrmtFiles.Rows.Count > 0)
                {
                    string strImage;
                    strImage = "<table>";
                    for (int i = 0; i < dtVhclPrmtFiles.Rows.Count; i++)
                    {
                        hiddenPermitFile.Value = dtVhclPrmtFiles.Rows[i][0].ToString();
                        string strFileName = dtVhclPrmtFiles.Rows[i][0].ToString();
                        string strDecrptn = dtVhclPrmtFiles.Rows[i][1].ToString();

                        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER) + dtVhclPrmtFiles.Rows[i][0].ToString();
                        string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                        if (strFileExt == "gif" || strFileExt == "png" || strFileExt == "bmp" || strFileExt == "jpeg" || strFileExt == "jpg")
                        {
                            // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
                            strImage += "<tr><td>";
                            strImage += "<a class=\"tooltip\"  title=\"" + strDecrptn + "\" style=\"opacity:1;font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy1" + i + "\"  >Click to View Image Uploaded</a>";
                            strImage += " <div class=\"lightbox-target\" id=\"goofy1" + i + "\">";
                            strImage += " <img src=\"" + strImagePath + "\"/>";
                            strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                            strImage += "</div>";
                            strImage += "</td></tr>";

                        }
                        else
                        {
                            strImage += "<tr><td>";
                            strImage += "<a class=\"tooltip\"  title=\"" + strDecrptn + "\" style=\"opacity:1;font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\"  target=\"_blank\" >Click to View Attachment Uploaded</a>";
                            strImage += "</td></tr>";
                        }
                    }
                    strImage += "</table>";
                    divOldImageDisplayPermit.InnerHtml = strImage;

                }
                else
                {
                    string strImage = "<Label Style=\"font-family: Calibri; font-size: medium;\">No File Uploaded</asp:Label>";
                    divOldImageDisplayPermit.InnerHtml = strImage;
                }
            }

        }
        if (hiddenRoleAdd.Value == "0")
        {
            SavePermit.Visible = false;
           // divNewPermNum.Visible = false;
            divPermitDate.Visible = false;
        }
   

    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        clsBusinessLayerInsuranceAndPermitExp objBusinessLayerInsunc = new clsBusinessLayerInsuranceAndPermitExp();
        clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (Session["USERID"] != null)
        {
            objEntityInsunc.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsunc.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsunc.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (hiddenVehId.Value != "")
        {
            objEntityInsunc.VehicleId = Convert.ToInt32(hiddenVehId.Value);
        }

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_RENEWAL);
        objEntityCommon.CorporateID = objEntityInsunc.Corporate_Id;
        objEntityCommon.Organisation_Id = objEntityInsunc.Organisation_Id;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        objEntityInsunc.NextNumInsure = Convert.ToInt32(strNextId);

        if (hiddenInsuranceFile.Value.ToString() != "")
        {
            objEntityInsunc.OldFileName = hiddenInsuranceFile.Value;
        }
      

        string jsonData = HiddenField2_FileUpload.Value;
        string c = jsonData.Replace("\"{", "\\{");
        string d = c.Replace("\\n", "\r\n");
        string g = d.Replace("\\", "");
        string h = g.Replace("}\"]", "}]");
        string i = h.Replace("}\",", "},");
        List<clsAtchmntData> objTVDataList = new List<clsAtchmntData>();
        objTVDataList = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);
        List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityRnwlAttchmntDeatilsList = new List<clsEntityInsuranceAndPermitAttchmntDtl>();
        int intSlNumbr = 0;
        for (int intCount = 0; intCount < Request.Files.Count; intCount++)
        {

            HttpPostedFile PostedFile = Request.Files[intCount];

            if (PostedFile.ContentLength > 0)
            {
                clsEntityInsuranceAndPermitAttchmntDtl objEntityRnwlDetailsAttchmnt = new clsEntityInsuranceAndPermitAttchmntDtl();
                string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                objEntityRnwlDetailsAttchmnt.ActualFileName = strFileName;
                string strFileExt;

                strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                // int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.QUOTATION);
                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);
                objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = intSlNumbr;
                string strImageName = intImageSection.ToString() + "_" + objEntityInsunc.NextNumInsure.ToString() + "_" + intSlNumbr + "." + strFileExt;
                objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);

                PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityRnwlDetailsAttchmnt.FileName);
                if (objTVDataList[intSlNumbr].DESCRPTN != "--Description--")
                {
                    objEntityRnwlDetailsAttchmnt.Description = objTVDataList[intSlNumbr].DESCRPTN;
                }
                objEntityRnwlAttchmntDeatilsList.Add(objEntityRnwlDetailsAttchmnt);

              
                intSlNumbr++;
            }

        }

        objEntityInsunc.Mode = Convert.ToInt32(Request.QueryString["Mode"].ToString());


        objEntityInsunc.OldInsureAmount = Convert.ToDecimal(txtOldInsAmount.Text.Trim());
        objEntityInsunc.NewInsureAmount = Convert.ToDecimal(txtNewInsuranceAmount.Text.Trim());

        objEntityInsunc.OldNumber = txtOldInsrncNumbr.Text; ;
        objEntityInsunc.OldDate = objCommon.textToDateTime(txtOldInsrncDate.Text);
        if (hiddenInsPrvdr.Value!="")
        {
        objEntityInsunc.InsPrvdrId =Convert.ToInt32(hiddenInsPrvdr.Value);
        }
        objEntityInsunc.NewNumber = txtNewInsrncNmbr.Text.Trim();
        objEntityInsunc.NewDate = objCommon.textToDateTime(txtNewInsrncDate.Text.Trim());
        objEntityInsunc.NewInsPrvdrId =Convert.ToInt32(ddlInsrncPrvdrId.SelectedItem.Value);

        if (hiddenInsCovrgtyp.Value != "")
        {
            objEntityInsunc.InsCovrgTypId = Convert.ToInt32(hiddenInsCovrgtyp.Value);
        }
        objEntityInsunc.NewInsCovrgTypId = Convert.ToInt32(ddlNewCoverageType.SelectedItem.Value);

        //THERE IS NO NEED OF INSURANCE AND PERMIT CHECKING - FINAL DECISION
        string NameCount = "0";
        NameCount = objBusinessLayerInsunc.CheckInsuranceNumber(objEntityInsunc);

        string VhclOrTr = Request.QueryString["Mode"].ToString();
        if (NameCount == "0")
        {
            objBusinessLayerInsunc.InsertInsurnceRenewal(objEntityInsunc, objEntityRnwlAttchmntDeatilsList);

            if (hiddenRedirect.Value.ToString() == "")
            {
                Response.Redirect("gen_Insurance_and_PermitRenewal.aspx?InsUpd=Ins");
            }
            else
            {
                string strVeh = hiddenRedirect.Value.ToString();
                Response.Redirect("/AWMS/AWMS_Master/gen_Vehicle_Master/gen_Vehicle_Master.aspx?Id=" + strVeh + "&&MODE=INS&TR=" + VhclOrTr);
            }
        }
        else
        {
            if (NameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationInsurance", "DuplicationInsurance();", true);

            }
        }

    

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtNewInsrncNmbr.Text = "";
        txtNewInsrncDate.Text = "";
        InsurncProvdrIdr();
        InsCoverageTypeLoad();
    }
    //set vehcle renewal details
    private void InsurncProvdrIdr()
    {
        clsBusinessLayerInsuranceAndPermitExp objBusinessLayerInsunc = new clsBusinessLayerInsuranceAndPermitExp();
        clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();
        //EVM-0016
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsunc.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsunc.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //EVM-0016
        DataTable dtRenewal = objBusinessLayerInsunc.ReadInsurncPrvdrId(objEntityInsunc);

        ddlInsrncPrvdrId.DataSource = dtRenewal;

        ddlInsrncPrvdrId.DataTextField = "INSURPRVDR_NAME";
        ddlInsrncPrvdrId.DataValueField = "INSURPRVDR_ID";
        ddlInsrncPrvdrId.DataBind();
        ddlInsrncPrvdrId.Items.Insert(0, "--SELECT INSURANCE PROVIDER--");

    }
    public class clsAtchmntData
    {

        public string ROWID { get; set; }
        public string FILEPATH { get; set; }
        public string DESCRPTN { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }

    }

    protected void SavePermit_Click(object sender, EventArgs e)
    {
        clsBusinessLayerInsuranceAndPermitExp objBusinessLayerInsunc = new clsBusinessLayerInsuranceAndPermitExp();
        clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (Session["USERID"] != null)
        {
            objEntityInsunc.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsunc.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsunc.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (hiddenVehId.Value != "")
        {
            objEntityInsunc.VehicleId = Convert.ToInt32(hiddenVehId.Value);
        }

        objEntityInsunc.Mode = Convert.ToInt32(Request.QueryString["Mode"].ToString());


        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PERMIT_RENEWAL);
        objEntityCommon.CorporateID = objEntityInsunc.Corporate_Id;
        objEntityCommon.Organisation_Id = objEntityInsunc.Organisation_Id;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        objEntityInsunc.NextNumPer = Convert.ToInt32(strNextId);

        if (hiddenPermitFile.Value != "")
        {
            objEntityInsunc.OldFileName = hiddenPermitFile.Value;
        }


        string jsonData = HiddenField2_FileUpload.Value;
        string c = jsonData.Replace("\"{", "\\{");
        string d = c.Replace("\\n", "\r\n");
        string g = d.Replace("\\", "");
        string h = g.Replace("}\"]", "}]");
        string i = h.Replace("}\",", "},");
        List<clsAtchmntData> objTVDataList = new List<clsAtchmntData>();
        objTVDataList = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);

        List<clsEntityInsuranceAndPermitAttchmntDtl> objEntityRnwlAttchmntDeatilsList = new List<clsEntityInsuranceAndPermitAttchmntDtl>();

        
       int intSlNumbr = 0;
        for (int intCount = 0; intCount < Request.Files.Count; intCount++)
        {

            HttpPostedFile PostedFile = Request.Files[intCount];

            if (PostedFile.ContentLength > 0)
            {
                clsEntityInsuranceAndPermitAttchmntDtl objEntityRnwlDetailsAttchmnt = new clsEntityInsuranceAndPermitAttchmntDtl();
                string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                objEntityRnwlDetailsAttchmnt.ActualFileName = strFileName;
                string strFileExt;

                strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

               // int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.QUOTATION);
                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);
                objEntityRnwlDetailsAttchmnt.RnwlAttchmntSlNumber = intSlNumbr;
                string strImageName = intImageSection.ToString() + "_" + objEntityInsunc.NextNumPer.ToString() + "_" + intSlNumbr + "." + strFileExt ;
                objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);

                PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityRnwlDetailsAttchmnt.FileName);
                if (objTVDataList[intSlNumbr].DESCRPTN != "--Description--")
                {
                    objEntityRnwlDetailsAttchmnt.Description = objTVDataList[intSlNumbr].DESCRPTN;
                }
                objEntityRnwlAttchmntDeatilsList.Add(objEntityRnwlDetailsAttchmnt);

                //  PostedFile.SaveAs(Server.MapPath("Files\\") + FileName);
                intSlNumbr++;
            }

        }




        objEntityInsunc.OldNumber = txtVehNumberPer.Text.Trim();
        objEntityInsunc.OldDate = objCommon.textToDateTime(txtOldPermitDate.Text.Trim());
       // objEntityInsunc.NewNumber = "0";
        objEntityInsunc.NewDate = objCommon.textToDateTime(txtNewPerDate.Text.Trim());

    
         objBusinessLayerInsunc.InsertPermtRenewal(objEntityInsunc, objEntityRnwlAttchmntDeatilsList);
         string  VhclOrTr= Request.QueryString["Mode"].ToString();
        
         if (hiddenRedirect.Value.ToString() == "")
             {
                 Response.Redirect("gen_Insurance_and_PermitRenewal.aspx?InsUpd=permt");
             }
             else
             {
                 string strVeh = hiddenRedirect.Value.ToString();
                 Response.Redirect("/AWMS/AWMS_Master/gen_Vehicle_Master/gen_Vehicle_Master.aspx?Id=" + strVeh + "&&MODE=PER&TR=" + VhclOrTr);
             }
       
    }
    protected void CancelPermit_Click(object sender, EventArgs e)
    {
      //  txtNewPermitNum.Text = "";
        txtNewPerDate.Text = "";
    }
}