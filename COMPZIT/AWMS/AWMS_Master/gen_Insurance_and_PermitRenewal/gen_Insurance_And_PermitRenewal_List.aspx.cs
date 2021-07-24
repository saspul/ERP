using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusinessLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
using System.Web.Services;
using System.IO;
// CREATED BY:WEM-0005
// CREATED DATE:14/11/2016
// REVIEWED BY:
// REVIEW DATE:
public partial class AWMS_AWMS_Master_gen_Insurance_and_PermitRenewal_gen_Insurance_And_PermitRenewal_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Vehicle_renewal();
            hiddenRoleCancel.Value = "0";
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            //Creating objects for business layer
            clsBusinessLayerInsuranceAndPermitExp objBusinessLayerInsunc = new clsBusinessLayerInsuranceAndPermitExp();
            clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            int intUserId = 0, intUsrRolMstrId, intEnableCancel = 0, intCorpId=0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityInsunc.Corporate_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.VEHICLE_MASTER);
            objEntityCommon.CommonLabelFieldName = "VHCL_PERMIT_NUMBR";

            //fetch permit common label name
            DataTable dtLblName = new DataTable();
            dtLblName = objBusinessLayer.ReadGeneralLabelName(objEntityCommon);
            string strPermit = "";
            if (dtLblName.Rows.Count > 0)
            {
                strPermit = dtLblName.Rows[0]["CMNLBL_NAME_TOCHNG"].ToString();
                hiddenPermitName.Value = strPermit;

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

                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleCancel.Value = "1";
                    }


                }

            }


            if (Request.QueryString["Mode"] != null)
            {
                objEntityInsunc.Mode = Convert.ToInt32(Request.QueryString["Mode"].ToString());
            }

            //for search
            if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
            {
                string strSearch = Request.QueryString["Srch"].ToString();
                string[] strSplit = strSearch.Split(',');
                txtDateTo.Text = strSplit[1];
                txtDateFrom.Text = strSplit[0];
                ddlVehicleRenewal.Items.FindByValue(strSplit[2]).Selected = true;
            }


            if (Request.QueryString["InsId"] != null)
            {//when Canceled
               

                string strRandomMixedId = Request.QueryString["InsId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                objEntityInsunc.InsrnceRnwlId = Convert.ToInt32(strId);
                objEntityInsunc.User_Id = intUserId;
                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);

                if (dtCorpDetail.Rows.Count > 0)
                {
                    string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                    if (CnclrsnMust == "0")
                    {
                        objEntityInsunc.Cancelreason = objCommon.CancelReason();
                        if (objEntityInsunc.Mode == 1)
                        {
                            objBusinessLayerInsunc.CancelInsuranceRenewal(objEntityInsunc);
                        }
                        else if (objEntityInsunc.Mode == 2)
                        {
                            objBusinessLayerInsunc.CancelInsuranceRenewalTR(objEntityInsunc);
                        }
                        if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                        {
                            string strSearch = Request.QueryString["Srch"].ToString();
                            Response.Redirect("gen_Insurance_And_PermitRenewal_List.aspx?InsUpd=CnclIns&Srch="+strSearch+"");

                        }
                        else
                        {
                            Response.Redirect("gen_Insurance_And_PermitRenewal_List.aspx?InsUpd=CnclIns");
                        }

                    }
                    else
                    {
                        DataTable dtRenewalList = new DataTable();

                        // created object for business layer for compare the date
                        clsBusinessLayer objBusiness = new clsBusinessLayer();
                        string strCurrentDate = objBusiness.LoadCurrentDateInString();

                        hiddenCurrentDate.Value = strCurrentDate;
                        DateTime CurrentDate = objCommon.textToDateTime(strCurrentDate);
                        DateTime FromDate = CurrentDate.AddMonths(-1);
                        if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                        {
                            if (ddlVehicleRenewal.SelectedItem.Value.ToString() != "ALL")
                            {
                                objEntityInsunc.DisplayMode = Convert.ToInt32(ddlVehicleRenewal.SelectedItem.Value);
                            }
                            else
                            {
                                objEntityInsunc.DisplayMode = 0;
                            }
                            objEntityInsunc.FromDate = objCommon.textToDateTime(txtDateFrom.Text.Trim());
                            objEntityInsunc.ToDate = objCommon.textToDateTime(txtDateTo.Text.Trim());
                        }
                        else
                        {
                            objEntityInsunc.DisplayMode = 0;
                            objEntityInsunc.FromDate = FromDate;
                            objEntityInsunc.ToDate = CurrentDate;
                        }
                        dtRenewalList = objBusinessLayerInsunc.ReadRenewalListBySearch(objEntityInsunc);

                        string strHtm = ConvertDataTableToHTMLAsOnDate(dtRenewalList, intEnableCancel);
                        //Write to divReport
                        divReportDate.InnerHtml = strHtm;

                        hiddenRsnid.Value = strId;
                        hiddenCancelMode.Value = "1";

                    }

                }



            }

            else if (Request.QueryString["PrmtId"] != null)
            {
                string strRandomMixedId = Request.QueryString["PrmtId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                objEntityInsunc.PermitRnwlId = Convert.ToInt32(strId);
                objEntityInsunc.User_Id = intUserId;
                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);

                if (dtCorpDetail.Rows.Count > 0)
                {
                    string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                    if (CnclrsnMust == "0")
                    {
                        objEntityInsunc.Cancelreason = objCommon.CancelReason();

                        if (objEntityInsunc.Mode == 1)
                        {
                            objBusinessLayerInsunc.CancelPermitRenewal(objEntityInsunc);
                        }
                        else if (objEntityInsunc.Mode == 2)
                        {
                            objBusinessLayerInsunc.CancelPermitRenewalTR(objEntityInsunc);
                        }
                        if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                        {
                            string strSearch = Request.QueryString["Srch"].ToString();
                            Response.Redirect("gen_Insurance_And_PermitRenewal_List.aspx?InsUpd=CnclPer&Srch=" + strSearch + "");

                        }
                        else
                        {
                            Response.Redirect("gen_Insurance_And_PermitRenewal_List.aspx?InsUpd=CnclPer");
                        }


                    }
                    else
                    {
                        DataTable dtRenewalList = new DataTable();

                        // created object for business layer for compare the date
                        clsBusinessLayer objBusiness = new clsBusinessLayer();
                        string strCurrentDate = objBusiness.LoadCurrentDateInString();

                        hiddenCurrentDate.Value = strCurrentDate;
                        DateTime CurrentDate = objCommon.textToDateTime(strCurrentDate);
                        DateTime FromDate = CurrentDate.AddMonths(-1);
                        if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                        {
                            if (ddlVehicleRenewal.SelectedItem.Value.ToString() != "ALL")
                            {
                                objEntityInsunc.DisplayMode = Convert.ToInt32(ddlVehicleRenewal.SelectedItem.Value);
                            }
                            else
                            {
                                objEntityInsunc.DisplayMode = 0;
                            }
                            objEntityInsunc.FromDate = objCommon.textToDateTime(txtDateFrom.Text.Trim());
                            objEntityInsunc.ToDate = objCommon.textToDateTime(txtDateTo.Text.Trim());
                        }
                        else
                        {
                            objEntityInsunc.DisplayMode = 0;
                            objEntityInsunc.FromDate = FromDate;
                            objEntityInsunc.ToDate = CurrentDate;
                        }

                        dtRenewalList = objBusinessLayerInsunc.ReadRenewalListBySearch(objEntityInsunc);

                        string strHtm = ConvertDataTableToHTMLAsOnDate(dtRenewalList, intEnableCancel);
                        //Write to divReport
                        divReportDate.InnerHtml = strHtm;

                        hiddenRsnid.Value = strId;
                        hiddenCancelMode.Value = "2";

                    }

                }

            }

            else
            {

                // created object for business layer for compare the date
                clsBusinessLayer objBusiness = new clsBusinessLayer();
                string strCurrentDate = objBusiness.LoadCurrentDateInString();

                hiddenCurrentDate.Value = strCurrentDate;
                DateTime CurrentDate = objCommon.textToDateTime(strCurrentDate);
                DateTime FromDate = CurrentDate.AddMonths(-1);
                if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                {
                    if (ddlVehicleRenewal.SelectedItem.Value.ToString() != "ALL")
                    {
                        objEntityInsunc.DisplayMode = Convert.ToInt32(ddlVehicleRenewal.SelectedItem.Value);
                    }
                    else
                    {
                        objEntityInsunc.DisplayMode = 0;
                    }
                    objEntityInsunc.FromDate = objCommon.textToDateTime(txtDateFrom.Text.Trim());
                    objEntityInsunc.ToDate = objCommon.textToDateTime(txtDateTo.Text.Trim());
                }
                else
                {
                    objEntityInsunc.ToDate = CurrentDate;
                    objEntityInsunc.FromDate = FromDate;
                    objEntityInsunc.DisplayMode = 0;
                }
                DataTable dtRenewalList = objBusinessLayerInsunc.ReadRenewalListBySearch(objEntityInsunc);
                string strRport = ConvertDataTableToHTMLAsOnDate(dtRenewalList, intEnableCancel);
                divReportDate.InnerHtml = strRport;

                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    if (strInsUpd == "CnclIns")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelationInsur", "SuccessCancelationInsur();", true);
                    }
                    else if (strInsUpd == "CnclPer")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelationPermit", "SuccessCancelationPermit();", true);
                    }
                }
            }
           
        }

    }//set vehcle renewal details
    private void Vehicle_renewal()
    {
        clsBusinessLayerInsuranceAndPermitExp objBusinessLayerInsunc = new clsBusinessLayerInsuranceAndPermitExp();
        clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();
       
        DataTable dtRenewal = objBusinessLayerInsunc.ReadVehicleRenewal(objEntityInsunc);
        if (dtRenewal.Rows.Count > 0)
        {
            ddlVehicleRenewal.DataSource = dtRenewal;

            ddlVehicleRenewal.DataTextField = "VHCLRENWL_NAME";
            ddlVehicleRenewal.DataValueField = "VHCLRENWL_ID";
            ddlVehicleRenewal.DataBind();
        }
        ddlVehicleRenewal.Items.Insert(0, "ALL");

    }


    public string ConvertDataTableToHTMLAsOnDate(DataTable dt,int intEnableCancel)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();
        StringBuilder sb = new StringBuilder();

        string passingString = "";
        if (txtDateFrom.Text != "" && txtDateTo.Text != "")
        {
            string fromdate = txtDateFrom.Text;
            string todate = txtDateTo.Text;
            string Mode = ddlVehicleRenewal.SelectedItem.Value;
            passingString = fromdate + "," + todate + "," + Mode;

        }



        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
          
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">" + "REGISTRATION NUMBER" + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 3)
            {

                strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";

            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
        }

            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
               
               strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE </th>";
              
            }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";


            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {

                string Mode = dt.Rows[intRowBodyCount][8].ToString();


                 int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
                 int intIdentityValue = Convert.ToInt32(dt.Rows[intRowBodyCount]["IDENTITY STATUS"].ToString());

                strHtml += "<tr  >";
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        if (Mode == "1")
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                        }
                        else if (Mode == "2")
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][9].ToString() + "</td>";

                        }
                    }
                    if (intColumnBodyCount == 2)
                    {

                       strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }

                    if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }


                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }

                }

                string RenewalName = dt.Rows[intRowBodyCount][5].ToString();
                    //for taking and pASSING id
                    string strId = dt.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;


                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                            {
                                if (intCnclUsrId == 0)
                                {
                                    if (intIdentityValue == 0)
                                    {
                                        if (RenewalName == "INSURANCE")
                                        {
                                            if (passingString == "")
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelAlert(this.href);' " +
                                                                        " href=\"gen_Insurance_And_PermitRenewal_List.aspx?InsId=" + Id + "&Mode=" + Mode + "\">" + "<img title=\"Delete\" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                            }
                                            else
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelAlert(this.href);' " +
                                                                        " href=\"gen_Insurance_And_PermitRenewal_List.aspx?InsId=" + Id + "&Srch=" + passingString + "&Mode=" + Mode + "\">" + "<img title=\"Delete\"  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                            }
                                        }
                                        else if (RenewalName == "ISTAMARA")
                                        {
                                            if (passingString == "")
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelAlert(this.href);' " +
                                                                        " href=\"gen_Insurance_And_PermitRenewal_List.aspx?PrmtId=" + Id + "&Mode=" + Mode + "\">" + "<img title=\"Delete\"  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                            }
                                            else
                                            {
                                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelAlert(this.href);' " +
                                                                        " href=\"gen_Insurance_And_PermitRenewal_List.aspx?PrmtId=" + Id + "&Srch=" + passingString + "&Mode=" + Mode + "\">" + "<img title=\"Delete\"  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible2();' >"
                                               + "<img title=\"Delete\" style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                    }
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible1();' >"
                                               + "<img title=\"Delete\" style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                }
                }
                strHtml += "</tr>";
            }
      


        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        //Creating objects for business layer
        clsBusinessLayerInsuranceAndPermitExp objBusinessLayerInsunc = new clsBusinessLayerInsuranceAndPermitExp();
        clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();

        int intEnableCancel = 0;
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

        if (hiddenRoleCancel.Value != ""&& hiddenRoleCancel.Value != null)
        {
            intEnableCancel = Convert.ToInt32(hiddenRoleCancel.Value);
        }

        objEntityInsunc.FromDate = objCommon.textToDateTime(txtDateFrom.Text.Trim());
        objEntityInsunc.ToDate = objCommon.textToDateTime(txtDateTo.Text.Trim());
        if (cbxCnclStatus.Checked == true)
        {
            objEntityInsunc.CancelCheck = 1;
        }
        else
        {
            objEntityInsunc.CancelCheck = 0;
        }

        if (ddlVehicleRenewal.SelectedItem.Value.ToString() != "ALL")
        {
            objEntityInsunc.DisplayMode = Convert.ToInt32(ddlVehicleRenewal.SelectedItem.Value);
        }
        else
        {
            objEntityInsunc.DisplayMode = 0;
        }

        DataTable dtRenewalList = objBusinessLayerInsunc.ReadRenewalListBySearch(objEntityInsunc);
        string strRport = ConvertDataTableToHTMLAsOnDate(dtRenewalList, intEnableCancel);
        divReportDate.InnerHtml = strRport;
    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer

        clsBusinessLayerInsuranceAndPermitExp objBusinessLayerInsunc = new clsBusinessLayerInsuranceAndPermitExp();
        clsEntityInsuranceAndPermitRenewal objEntityInsunc = new clsEntityInsuranceAndPermitRenewal();



        if (Request.QueryString["Mode"] != null)
        {
            objEntityInsunc.Mode = Convert.ToInt32(Request.QueryString["Mode"].ToString());
        }

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            if (Session["USERID"] != null)
            {
                objEntityInsunc.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            objEntityInsunc.Cancelreason = txtCnclReason.Text.Trim();

            if (hiddenCancelMode.Value == "1")
            {
                objEntityInsunc.InsrnceRnwlId = Convert.ToInt32(hiddenRsnid.Value);
                  if (objEntityInsunc.Mode == 1)
                        {
                              objBusinessLayerInsunc.CancelInsuranceRenewal(objEntityInsunc);
                        }
                  else if (objEntityInsunc.Mode == 2)
                  {
                      objBusinessLayerInsunc.CancelInsuranceRenewalTR(objEntityInsunc);
                  }
            }
            else if (hiddenCancelMode.Value == "2")
            {
                objEntityInsunc.PermitRnwlId = Convert.ToInt32(hiddenRsnid.Value);
                if (objEntityInsunc.Mode == 1)
                {
                    objBusinessLayerInsunc.CancelPermitRenewal(objEntityInsunc);
                }
                else if (objEntityInsunc.Mode == 2)
                {
                    objBusinessLayerInsunc.CancelPermitRenewalTR(objEntityInsunc);
                }
            }
            string passingString="";
            if (txtDateFrom.Text != "" && txtDateTo.Text != "")
            {
                string fromdate = txtDateFrom.Text;
                string todate = txtDateTo.Text;
                string Mode = ddlVehicleRenewal.SelectedItem.Value;
                 passingString= fromdate + "," + todate + "," + Mode;

            }
            if (hiddenCancelMode.Value == "1")
            {
                if (passingString != "")
                {
                    Response.Redirect("gen_Insurance_And_PermitRenewal_List.aspx?InsUpd=CnclIns&Srch=" + passingString + "");
                }
                else
                {
                    Response.Redirect("gen_Insurance_And_PermitRenewal_List.aspx?InsUpd=CnclIns");
                }
            }
            else if (hiddenCancelMode.Value == "2")
            {
                if (passingString != "")
                {
                    Response.Redirect("gen_Insurance_And_PermitRenewal_List.aspx?InsUpd=CnclPer&Srch=" + passingString + "");
                }
                else
                {
                    Response.Redirect("gen_Insurance_And_PermitRenewal_List.aspx?InsUpd=CnclPer");
                }
            }
               



        }
    }
}