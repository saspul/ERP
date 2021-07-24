using BL_Compzit;
using BL_Compzit.BusinessLayer_GMS;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


public partial class HCM_HCM_Master_gen_Joining_Intimation_gen_Joining_Intimation_List : System.Web.UI.Page
{

    clcBusiness_Joining_Intimation objBusinessJoingIntimation = new clcBusiness_Joining_Intimation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            btnAdd.Visible = true;

           // txtJoinDt.Text = DateTime.Now.ToString("dd-MM-yyyy");
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {

                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
        }
        if (Request.QueryString["Id"] != null)
        {
            btnClear.Visible = false;
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            Update(strId);
            HiddenreqstId.Value = strId;
            HiddenStatus.Value = strRandomMixedId;
            lblEntry.Text = "Edit Joining Intimation";

        }
        if (Request.QueryString["InsUpd"] != null)
        {
            string strInsUpd = Request.QueryString["InsUpd"].ToString();
            if (strInsUpd == "Ins")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
            }

        }


    }
    public void Update(string strP_Id)
    {
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableConfirm = 0;

        clsEntity_Joining_Intimation objEntityJoiningList = new clsEntity_Joining_Intimation();
        if (Session["USERID"] != null)
        {
            objEntityJoiningList.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityJoiningList.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //Allocating child roles
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_Notification);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

        objEntityJoiningList.ReqstID = Convert.ToInt32(strP_Id);

        DataTable dtShortlist = objBusinessJoingIntimation.ReadAprvdManPwrReqstListByid(objEntityJoiningList);
        if (dtShortlist.Rows.Count > 0)
        {
            lblRefNum.Text = dtShortlist.Rows[0]["MNP_REFNUM"].ToString();

            lblDateOfReq.Text = dtShortlist.Rows[0]["DATE OF REQUEST"].ToString();

            lblNumber.Text = dtShortlist.Rows[0]["MNP_RESOURCENUM"].ToString();

            lblDesign.Text = dtShortlist.Rows[0]["DESIGNATION"].ToString();
            lblDeprtmnt.Text = dtShortlist.Rows[0]["DEPARTMENT"].ToString();

            lblPrjct.Text = dtShortlist.Rows[0]["PROJECT"].ToString();

            lblExprnce.Text = dtShortlist.Rows[0]["MNP_EXPERIENCE"].ToString() + "  Years";

            lblPaygrd.Text = dtShortlist.Rows[0]["PYGRD_NAME"].ToString();
            HiddenPaygrdScale.Value = dtShortlist.Rows[0]["PYGRD_RANGE_FRM"].ToString() + " " + dtShortlist.Rows[0]["CRNCMST_ABBRV"].ToString() + "-" + dtShortlist.Rows[0]["PYGRD_RANGE_TO"].ToString() + " " + dtShortlist.Rows[0]["CRNCMST_ABBRV"].ToString();  //emv0025

            hiddenCurrencyId.Value = dtShortlist.Rows[0]["CRNCMST_ID"].ToString();

            hiddenPaygrdFrm.Value = dtShortlist.Rows[0]["PYGRD_RANGE_FRM"].ToString();
            hiddenPaygrdTo.Value = dtShortlist.Rows[0]["PYGRD_RANGE_TO"].ToString();

            hiddenDesgId.Value = dtShortlist.Rows[0]["DSGN_ID"].ToString();
            hiddenPaygradeId.Value = dtShortlist.Rows[0]["PYGRD_ID"].ToString();

            hiddenExperience.Value = dtShortlist.Rows[0]["MNP_EXPERIENCE"].ToString();

        }

        DataTable dtShortlistcandidates = objBusinessJoingIntimation.ReadCandidates(objEntityJoiningList);
        DataTable dtShortlistedcandidatelist = null;
        string strHtm = ConvertDataTableToHTML(dtShortlistcandidates, dtShortlistedcandidatelist);

        //Write to divReport
        divReport.InnerHtml = strHtm;

    }
    //evm-0019 Start
    public string ConvertDataTableToHTML(DataTable dt, DataTable Shortlist)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        HiddenFieldCbxCheck.Value = dt.Rows.Count.ToString();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";


        strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" title=\"SELECT ALL\" onchange='return changeAll();' Id=\"cblcandidatelist\"></td>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:13%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:11%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:9%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:7%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:7%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 9)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }


        }
        string Mail = "MAIL STATUS";
        strHtml += "<th class=\"thT\"  style=\"width:7%;text-align: center; word-wrap:break-word;\">" + Mail + "</th>";
        strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\"> JOINING STATUS </th>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        hiddenRowCount.Value = dt.Rows.Count.ToString();

        strHtml += "<tbody>";
        int count = 1, listcount = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            strHtml += "<tr  >";
            listcount = 0;

            count++;

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            //emp0026
            //if (dt.Rows[intRowBodyCount]["JOINING_STATUS"].ToString() == "0")
            //{
            //    strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\"  disabled=\"true\" onchange='return IncrmntConfrmCounter();' Id=\"cblcandidatelist" + intRowBodyCount + "\"></td>";
            //}

            if (dt.Rows[intRowBodyCount]["JOINING_STATUS"].ToString() == "0" || dt.Rows[intRowBodyCount]["JOINING_STATUS"].ToString() == "1")
            {
                if (dt.Rows[intRowBodyCount]["EMAIL_STATUS"].ToString() == "1")
                {
                    strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\"  disabled=\"true\" onchange='return IncrmntConfrmCounter();' Id=\"cblcandidatelist" + intRowBodyCount + "\"></td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\"  onchange='return IncrmntConfrmCounter();' Id=\"cblcandidatelist" + intRowBodyCount + "\"></td>";
                }
            }
            else
            {
                if (dt.Rows[intRowBodyCount]["JOINING_STATUS"].ToString() == "2")
                {
                    strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\"  disabled=\"true\" onchange='return IncrmntConfrmCounter();' Id=\"cblcandidatelist" + intRowBodyCount + "\"></td>";
                }
            }

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a> </td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:11%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 6)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                        strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >YES</td>";
                    else
                        strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >NO</td>";

                }
                else if (intColumnBodyCount == 7)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                        strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >YES</td>";
                    else
                        strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >NO</td>";

                }
                else if (intColumnBodyCount == 8)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                }
                else if (intColumnBodyCount == 9)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }


            }
            string DdlId = "ddlJoiningSts" + intRowBodyCount;
            if (dt.Rows[intRowBodyCount]["EMAIL_STATUS"].ToString() == "1")
            {
                strHtml += "<td id=\"tdSendStatus" + intRowBodyCount + "\" class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >SEND</td>";
                strHtml += "<td id=\"tdcandiateid" + intRowBodyCount + "\"  class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";
            }
            else
            {
                strHtml += "<td id=\"tdSendStatus" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >NOT SEND</td>";
                strHtml += "<td id=\"tdcandiateid" + intRowBodyCount + "\"  class=\"tdT\" style=\" word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";
            }
            // EMP0026

            string Emailsts = dt.Rows[intRowBodyCount]["EMAIL_STATUS"].ToString();

            if (dt.Rows[intRowBodyCount]["JOINING_STATUS"].ToString() == "0")
            {
                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
                strHtml += "<select id=\"ddlJoiningSts" + intRowBodyCount + "\"  style=\" width:94%;\" onchange=\"IncrmntChange('" + DdlId + "','" + strId + "','" + intRowBodyCount + "','" + Emailsts + "')\" onkeydown=\"return isEnter(event); \"> <option selected=\"selected\" value=\"0\">Pending</option><option  value=\"1\">Confirmed</option><option value=\"2\">Rejected</option></select>";
                strHtml += "</td>";

            }


            if (dt.Rows[intRowBodyCount]["JOINING_STATUS"].ToString() == "1")
            {
                //EVM-0023

                if (dt.Rows[intRowBodyCount]["CAND COUNT"].ToString() != "")
                {
                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
                    strHtml += "<select disabled=\"true\" id=\"ddlJoiningSts" + intRowBodyCount + "\"  style=\" width:94%;\" onchange=\"IncrmntChange('" + DdlId + "','" + strId + "','" + intRowBodyCount + "','" + Emailsts + "')\" onkeydown=\"return isEnter(event);\"> <option  value=\"0\">Pending</option><option selected=\"selected\" value=\"1\">Confirmed</option><option value=\"2\">Rejected</option></select>";
                    strHtml += "</td>";
                }
                else
                {
                    //emp0026
                    if (dt.Rows[intRowBodyCount]["EMAIL_STATUS"].ToString() == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
                        strHtml += "<select  disabled=\"true\" id=\"ddlJoiningSts" + intRowBodyCount + "\"  style=\" width:94%;\" onchange=\"IncrmntChange('" + DdlId + "','" + strId + "','" + intRowBodyCount + "','" + Emailsts + "')\" onkeydown=\"return isEnter(event);\"> <option  value=\"0\">Pending</option><option selected=\"selected\" value=\"1\">Confirmed</option><option value=\"2\">Rejected</option></select>";
                        strHtml += "</td>";
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
                        strHtml += "<select id=\"ddlJoiningSts" + intRowBodyCount + "\"  style=\" width:94%;\" onchange=\"IncrmntChange('" + DdlId + "','" + strId + "','" + intRowBodyCount + "','" + Emailsts + "')\" onkeydown=\"return isEnter(event);\"> <option  value=\"0\">Pending</option><option selected=\"selected\" value=\"1\">Confirmed</option><option value=\"2\">Rejected</option></select>";
                        strHtml += "</td>";
                    }
                }

            }
            if (dt.Rows[intRowBodyCount]["JOINING_STATUS"].ToString() == "2")
            {
                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >";
                strHtml += "<select id=\"ddlJoiningSts" + intRowBodyCount + "\"  style=\" width:94%;\" onchange=\"IncrmntChange('" + DdlId + "','" + strId + "','" + intRowBodyCount + "','" + Emailsts + "')\"; onkeydown=\"return isEnter(event);\"> <option  value=\"0\">Pending</option><option  value=\"1\">Confirmed</option><option selected=\"selected\" value=\"2\">Rejected</option></select>";
                strHtml += "</td>";

            }
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }//evm-0019 Start

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;


        clsEntity_Joining_Intimation objEntityJoiningList = new clsEntity_Joining_Intimation();
        clcBusiness_Joining_Intimation objBusinessJoingIntimation = new clcBusiness_Joining_Intimation();


        List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();
        List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();



        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        int intCorpId = 0, intOrgId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityJoiningList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityJoiningList.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityJoiningList.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intmailSendChk = 0;
        try
        {
            if (Hiddenchecklist.Value != "")
            {
                string[] strArrIdValue = Hiddenchecklist.Value.Split(',');
                //evm-0023 start
                string[,] strArrayValueID = new string[strArrIdValue.Count(), 2];
                for (int intArrCount = 0; intArrCount < strArrIdValue.Count(); intArrCount++)
                {
                    if (strArrIdValue[intArrCount] != "")
                    {
                        string[] strArrIdValueSub = strArrIdValue[intArrCount].Split(':');

                        strArrayValueID[intArrCount, 0] = strArrIdValueSub[0];
                        strArrayValueID[intArrCount, 1] = strArrIdValueSub[1];
                    }
                }
                //evm-0023 end
                string[] tokens = Hiddenchecklist.Value.Split(',');





                for (int i = 0; i < strArrayValueID.GetLength(0); i++)
                {
                    if (strArrayValueID[i, 0] != null || strArrayValueID[i, 1] != null)  // evm-0023
                    {
                        int a = Convert.ToInt32(strArrayValueID[i, 0]);
                        SelectedCandiate objentityShortList = new SelectedCandiate();
                        objentityShortList.CandidateId = a;
                        DataTable dtEmailId = objBusinessJoingIntimation.EmailIdFetch(objentityShortList);
                        //if (Convert.ToInt32(strArrayValueID[i, 1]) == 1)
                        //{//Confirmed
                            
                            if (dtEmailId.Rows.Count > 0)
                            {
                                objentityShortList.JoinDate = objCommonLibrary.textToDateTime(txtJoinDt.Text.Trim());

                                objBusinessJoingIntimation.UpdJoinDate(objentityShortList);

                                Entity_Template_Mail_Service EntityTemMailServce = new Entity_Template_Mail_Service();
                                clsBusiness_Template_Mail_Service objBusnssTemMailServce = new clsBusiness_Template_Mail_Service();
                                EntityTemMailServce.CorpOffice_Id = intCorpId;
                                DataTable dtFromMail = objBusnssTemMailServce.ReadFromMailDetails(EntityTemMailServce);
                                clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
                                objEntityMail.Email_Subject = "JOINING INTIMATION";

                                objEntityMail.From_Email_Address = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();

                                objEntityMail.Out_Service_Name = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
                                objEntityMail.Out_Port_Number = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
                                objEntityMail.SSL_Status = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
                                objEntityMail.Password = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();

                                string strFromAddrss = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();
                                string strServiceName = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
                                int intPortNo = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
                                int intSSlStatus = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
                                string strSslStatus = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();

                                objEntityMail.D_Date = System.DateTime.Now;
                                //EVM-0024
                                if (dtEmailId.Rows[0]["CAND_EMAIL"].ToString() == "" || dtEmailId.Rows[0]["CAND_EMAIL"].ToString() == null)
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "MissingCandidateMailID", "MissingCandidateMailID();", true);
                                }
                                //end
                                //EVM-0024
                                if (dtEmailId.Rows[0]["CNSLT_EMAIL"].ToString() != "")
                                {
                                    string strCnstncyMail = dtEmailId.Rows[0]["CNSLT_EMAIL"].ToString();
                                    string strCandidatename = dtEmailId.Rows[0]["CAND_NAME"].ToString();
                                    string strOrg = dtEmailId.Rows[0]["ORG_NAME"].ToString();
                                    ConsultancyMailTransfer(strCnstncyMail, strCandidatename, strOrg, strFromAddrss, strServiceName, intPortNo, intSSlStatus, strSslStatus);
                                }
                                //END
                                objEntityMail.To_Email_Address = dtEmailId.Rows[0]["CAND_EMAIL"].ToString();
                                //objEntityMail.To_Email_Address = "varsham@volviar.com";
                                if (objEntityMail.From_Email_Address != "" && objEntityMail.To_Email_Address != "")
                                {

                                    string Content = "";

                                    if (dtEmailId.Rows[0]["CAND_NAME"].ToString() != "")
                                    {
                                        Content = " Dear " + dtEmailId.Rows[0]["CAND_NAME"].ToString() + ",";
                                    }
                                    else
                                    {
                                        Content = " Dear Candidate,";
                                    }
                                    //EVM-0023 START
                                    Content += "<br/><br/>This is an offer of employment as a " + lblDesign.Text + " at " + dtEmailId.Rows[0]["CORPRT_NAME"].ToString() + ".";
                                    if (dtEmailId.Rows[0]["CPRDIV_EMAIL_ID"].ToString() != "")
                                    {
                                        Content += "<br/> Your title will be " + lblDesign.Text + " if you accept this employment offer. You can replay to the mail-id : " + dtEmailId.Rows[0]["CPRDIV_EMAIL_ID"].ToString() + ". ";
                                    }


                                    Content += "<br/> We are offering you a base salary range  " + HiddenPaygrdScale.Value + " which will be subject to deductions for taxes and other with holdings as required by law or the policies of the company.";
                                    if (lblDeprtmnt.Text != "")
                                    {
                                        Content += "<br/> If you have ready  to start your employment, please report to the " + lblDeprtmnt.Text + " where you will get the  inform about your onboarding process date  later.";
                                    }
                                    else
                                    {
                                        Content += "<br/> If you have ready  to start your employment, please report to the " + dtEmailId.Rows[0]["CORPRT_NAME"].ToString() + " division  where you will get the  inform about your onboarding process date later.";
                                    }
                                    //EVM-0023 END
                                    Content += "<br/>Your employment with " + dtEmailId.Rows[0]["CORPRT_NAME"].ToString() + " WLL is at-will and either party can terminate the employment relationship at any time with or without cause and with or without notice.";

                                    Content += "<br/>If you are in agreement with the above employment offer details, please intimate the same to sfademo@albalagh.com. This employment offer is in effect for five business days.";

                                    Content += "<br/>You acknowledge that this employment offer letter represents the entire agreement between you and " + dtEmailId.Rows[0]["CORPRT_NAME"].ToString() + " and that no verbal or written agreements, promises or representations that are not specifically stated in this employment offer letter, are or will be binding upon " + dtEmailId.Rows[0]["CORPRT_NAME"].ToString() + " .";
                                    Content += "<br/><br/><br/><b><u>NOTE</u></b>: <i>PLEASE FIND THE ATTACHED APPOINTMENT LETTER</i>";  //EMV0025
                                    Content += "<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>";
                                    Content += "<br/><br/><br/>Best Regards,";
                                    Content += "<br/><font color=\"#0a409b\"><b>Compzit Administrator</b></font><br/><font color=\"#438df8\">Al-Balagh Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>";
                                    objEntityMail.Email_Content = Content;


                                    //----attachment---



                                    //string DivisionContent = "";
                                    //DivisionContent = "<h4  style=\" text-align:center\"> APPOINTMENT LETTER  </h4>"; //EMV0025

                                    //if (dtEmailId.Rows[0]["CAND_NAME"].ToString() != "")
                                    //{
                                    //    DivisionContent += "<br/><font color=\"#0a409b\"><b> FROM:Compzit Administrator</b></font><br/><font color=\"#438df8\">Al-Balagh Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>";
                                    //    DivisionContent += "<br/> Dear " + dtEmailId.Rows[0]["CAND_NAME"].ToString() + ",";
                                    //}
                                    //else
                                    //{
                                    //    DivisionContent += " Dear Candidate,";
                                    //}
                                    ////EVM-0023 START

                                    //DivisionContent += "<br/><br/>We are pleased to confirm your appointment to the position of     " + lblDesign.Text + " at " + dtEmailId.Rows[0]["CORPRT_NAME"].ToString() + ".";
                                    //if (dtEmailId.Rows[0]["CPRDIV_EMAIL_ID"].ToString() != "")
                                    //{
                                    //    DivisionContent += "<br/> Your title will be " + lblDesign.Text + "  ";
                                    //}
                                    //DivisionContent += "<br/> This letter of appointment will accompany, and form part of a suite of documents recording, inter alia, the terms and conditions of your employment and the company’s policy on various matters; which policies may from time to time be altered or amended by the company at its discretion.";

                                    //DivisionContent += "<br/> We are offering you a base salary range  " + HiddenPaygrdScale.Value + " which will be subject to deductions for taxes and other with holdings as required by law or the policies of the company.";
                                    //if (lblDeprtmnt.Text != "")
                                    //{
                                    //    DivisionContent += "<br/> At the time of joining please report to the " + lblDeprtmnt.Text + " where you will get more  information about your   job";
                                    //}
                                    //else
                                    //{
                                    //    DivisionContent += "<br/> If you have ready  to start your employment, please report to the " + dtEmailId.Rows[0]["CORPRT_NAME"].ToString() + " division  where you will get the  inform about your onboarding process date later.";
                                    //}
                                    ////EVM-0023 END
                                    //DivisionContent += "<br/>Your employment with " + dtEmailId.Rows[0]["CORPRT_NAME"].ToString() + " WLL is at-will and either party can terminate the employment relationship at any time with or without cause and with or without notice.";

                                    //DivisionContent += "<br/>If you are in agreement with the above employment offer details, please intimate the same to sfademo@albalagh.com. This employment offer is in effect for five business days.";

                                    //DivisionContent += "<br/>You acknowledge that this employment offer letter represents the entire agreement between you and " + dtEmailId.Rows[0]["CORPRT_NAME"].ToString() + " and that no verbal or written agreements, promises or representations that are not specifically stated in this employment offer letter, are or will be binding upon " + dtEmailId.Rows[0]["CORPRT_NAME"].ToString() + " .";

                                    //DivisionContent += "<br/><br/><br/>Best Regards,";
                                    //DivisionContent += "<br/><font color=\"#0a409b\"><b>Compzit Administrator</b></font><br/><font color=\"#438df8\">Al-Balagh Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>";

                                    //// objentityShortList.DivContent = DivisionContent;

                                    //divPayment.InnerHtml = DivisionContent;
                                    //StringWriter sw = new StringWriter();
                                    //HtmlTextWriter hw = new HtmlTextWriter(sw);
                                    //divPayment.RenderControl(hw);
                                    //StringReader sr = new StringReader(sw.ToString());



                                    Document pdfDoc = new Document(PageSize.A4, 50f, 40f, 20f, 85f);

                                    string CandId = dtEmailId.Rows[0]["CAND_MSTRID"].ToString() + objentityShortList.CandidateId.ToString();

                                    string strImageName = "Appointment Letter_" + CandId + ".pdf";
                                    string imgpath = "/CustomFiles/messagepdf/";
                                    string strImagePath = objCommonLibrary.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.APPOINMENT_PDF);

                                    FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(imgpath) + strImageName, FileMode.Create);
                                    PdfWriter w = PdfWriter.GetInstance(pdfDoc, file);

                                    w.PageEvent = new PDFFooter();

                                    pdfDoc.Open();
                                    float s = w.GetVerticalPosition(false);

                                    pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 50, Font.BOLD, BaseColor.BLACK))));


                                    PdfPTable tableLayout = new PdfPTable(2);
                                    float[] headersBody = { 50, 50 };
                                    tableLayout.SetWidths(headersBody);
                                    tableLayout.WidthPercentage = 100;

                                    tableLayout.AddCell(new PdfPCell(new Phrase("Ref : " + dtEmailId.Rows[0]["MNP_REFNUM"].ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT,PaddingTop=40 });
                                    tableLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    tableLayout.AddCell(new PdfPCell(new Phrase("Date : " + DateTime.Now.ToString("dd-MMMM-yyyy"), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    tableLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    tableLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    tableLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    tableLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    tableLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    if (dtEmailId.Rows[0]["CAND_NAME"].ToString() != "")
                                    {
                                        if (dtEmailId.Rows[0]["CAND_GENDER"].ToString() == "0")
                                        {
                                            tableLayout.AddCell(new PdfPCell(new Phrase("Mr. " + dtEmailId.Rows[0]["CAND_NAME"].ToString() + ",", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                        }
                                        else if (dtEmailId.Rows[0]["CAND_GENDER"].ToString() == "1")
                                        {
                                            tableLayout.AddCell(new PdfPCell(new Phrase("Mrs. " + dtEmailId.Rows[0]["CAND_NAME"].ToString() + ",", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                        }
                                    }
                                    else
                                    {
                                        tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    }
                                    tableLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });

                                    if (dtEmailId.Rows[0]["CAND_PASSPORTNO"].ToString() != "")
                                    {
                                        tableLayout.AddCell(new PdfPCell(new Phrase("Indian passport #" + dtEmailId.Rows[0]["CAND_PASSPORTNO"].ToString() + ",", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    }
                                    else
                                    {
                                        tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    }
                                    if (dtEmailId.Rows[0]["CAND_MOBILENO"].ToString() != "")
                                    {
                                        tableLayout.AddCell(new PdfPCell(new Phrase("Mobile : " + dtEmailId.Rows[0]["CAND_MOBILENO"].ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    }
                                    else
                                    {
                                        tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    }
                                    if (dtEmailId.Rows[0]["CAND_LOC"].ToString() != "")
                                    {
                                        tableLayout.AddCell(new PdfPCell(new Phrase(dtEmailId.Rows[0]["CAND_LOC"].ToString() + ",", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    }
                                    else
                                    {
                                        tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    }
                                    if (dtEmailId.Rows[0]["CAND_EMAIL"].ToString() != "")
                                    {
                                        tableLayout.AddCell(new PdfPCell(new Phrase("Email : " + dtEmailId.Rows[0]["CAND_EMAIL"].ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    }
                                    else
                                    {
                                        tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    }
                                    if (dtEmailId.Rows[0]["CNTRY_NAME"].ToString() != "")
                                    {
                                        tableLayout.AddCell(new PdfPCell(new Phrase(dtEmailId.Rows[0]["CNTRY_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    }
                                    else
                                    {
                                        tableLayout.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    }
                                    tableLayout.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    pdfDoc.Add(tableLayout);

                                    pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                                    if (dtEmailId.Rows[0]["CAND_NAME"].ToString() != "")
                                    {
                                        pdfDoc.Add(new Paragraph(new Chunk("Dear " + dtEmailId.Rows[0]["CAND_NAME"].ToString() + ",", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                                    }
                                    pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                                    pdfDoc.Add(new Paragraph(new Chunk("Sub : Appointment of " + lblDesign.Text, FontFactory.GetFont("Times New Roman", 12, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK))));
                                    pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                                    var phrase1 = new Phrase();
                                    phrase1.Add(new Chunk("Reference to your application and the interview at our office, we are pleased to appoint you as ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK)));
                                    phrase1.Add(new Chunk(lblDesign.Text, FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)));
                                    phrase1.Add(new Chunk(" in our " + lblDeprtmnt.Text + " department on the following terms and conditions:-", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK)));
                                    pdfDoc.Add(new Paragraph(phrase1));
                                    pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));

                                    float s3 = w.GetVerticalPosition(false);

                                    pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))));
                                    pdfDoc.Add(new Paragraph(new Chunk("- 	DATE OF JOINING", FontFactory.GetFont("Times New Roman", 12, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK))));
                                    pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))));
                                    pdfDoc.Add(new Paragraph(new Chunk("Your appointment will come into effect from the date of joining duty, which will be no later than "+txtJoinDt.Text+".", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))));


                                    string jsonData = hiddenParametersSelctd.Value;
                                    string c = jsonData.Replace("\"{", "\\{");
                                    string d = c.Replace("\\n", "\r\n");
                                    string g = d.Replace("\\", "");
                                    string h = g.Replace("}\"]", "}]");
                                    string j = h.Replace("}\",", "},");

                                    List<clsWBData> objWBDataList = new List<clsWBData>();

                                    objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(j);
                                    foreach (clsWBData objclsWBData in objWBDataList)
                                    {
                                        string Header = objclsWBData.HEADER_NAME;
                                        string Description = objclsWBData.DESCRIPTN;

                                        pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))));
                                        pdfDoc.Add(new Paragraph(new Chunk("- 	" + Header, FontFactory.GetFont("Times New Roman", 12, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK))));
                                        pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))));
                                        pdfDoc.Add(new Paragraph(new Chunk(Description, FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))));
                                    }

                                    pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));
                                    pdfDoc.Add(new Paragraph(new Chunk("Please sign and return the duplicate copy of this letter as a token of your acceptance.", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))));
                                    pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));

                                    var phrase4 = new Phrase();
                                    phrase4.Add(new Chunk("Dear ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK)));
                                    phrase4.Add(new Chunk(dtEmailId.Rows[0]["CAND_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK)));
                                    phrase4.Add(new Chunk(", we welcome you to our company and wish you a long and rewarding career. ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK)));
                                    pdfDoc.Add(new Paragraph(phrase4));

                                    pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))));

                                    float vv = w.GetVerticalPosition(false);


                                    PdfPTable tableLayout3 = new PdfPTable(2);
                                    float[] headersBody3 = { 45, 55 };
                                    tableLayout3.SetWidths(headersBody3);
                                    tableLayout3.WidthPercentage = 100;


                                    tableLayout3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                    tableLayout3.AddCell(new PdfPCell(new Phrase(" Read, Understood & Accepted", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, BorderWidth = 2, Padding = 2 });
                                    tableLayout3.AddCell(new PdfPCell(new Phrase("Best regards,", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    tableLayout3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidth = 2, Padding = 2 });
                                    tableLayout3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
                                    tableLayout3.AddCell(new PdfPCell(new Phrase(" I shall join by .......................", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidth = 2, Padding = 2 });
                                    tableLayout3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    tableLayout3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidth = 2, Padding = 2 });
                                    tableLayout3.AddCell(new PdfPCell(new Phrase("Srinivasan Venkatesan", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    tableLayout3.AddCell(new PdfPCell(new Phrase(" " + dtEmailId.Rows[0]["CAND_NAME"].ToString(), FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidth = 2, Padding = 2 });
                                    tableLayout3.AddCell(new PdfPCell(new Phrase("GENERAL MANAGER", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, });
                                    tableLayout3.AddCell(new PdfPCell(new Phrase(" (Indian Passport #" + dtEmailId.Rows[0]["CAND_PASSPORTNO"].ToString() + ")", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidth = 2, Padding = 2 });
                                    tableLayout3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0, });
                                    tableLayout3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Times New Roman", 12, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthTop = 0, BorderWidth = 2, Padding = 2 });

                                    if (vv >= 130)
                                    {
                                        pdfDoc.Add(tableLayout3);
                                    }
                                    else
                                    {
                                        if ((130 - vv) < 65)
                                        {
                                            pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", vv, Font.BOLD, BaseColor.BLACK))));
                                        }
                                        else
                                        {
                                            pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", (130 - vv), Font.BOLD, BaseColor.BLACK))));
                                        }

                                        pdfDoc.Add(tableLayout3);
                                    }


                                    pdfDoc.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Times New Roman", 25, Font.BOLD, BaseColor.BLACK))));

                                    float vv2 = w.GetVerticalPosition(false);


                                    pdfDoc.Close();

                                    Response.Write(pdfDoc);



                                    //EMP0026
                                    if (File.Exists(Server.MapPath(imgpath + strImageName)))
                                    {
                                        List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();

                                        clsEntityMailAttachment objEntityAttach = new clsEntityMailAttachment();
                                        objEntityAttach.Attch_Path = Server.MapPath(imgpath + strImageName);
                                        objEntityMailAttachList.Add(objEntityAttach);

                                        MailUtility_ERP.clsMail objMail = new MailUtility_ERP.clsMail();
                                        objMail.SendJobNotifyMail(objEntityMail, objEntityMailAttachList);

                                    }



                                    objBusinessJoingIntimation.EmailStsUpdate(objentityShortList);
                                    intmailSendChk++;
                                }
                            }
                        //}
                    }
                }


            }
        }
        catch (Exception)
        {


        }


        ScriptManager.RegisterStartupScript(this, GetType(), "HideLoading", "HideLoading();", true);
        if (intmailSendChk != 0)
            Response.Redirect("gen_Joining_Intimation_List.aspx?InsUpd=Ins&&Id=" + Request.QueryString["Id"] + "");

    }




    //EVM-0024
    public void ConsultancyMailTransfer(string strConstncyMail, string strCandidatename, string strOrg, string strFromAddrss, string strServiceName, int intPortNo, int intSSlStatus, string strSslStatus)
    {
        List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
        clsEntity_Joining_Intimation objEntityJoiningList = new clsEntity_Joining_Intimation();
        Entity_Template_Mail_Service EntityTemMailServce = new Entity_Template_Mail_Service();
        clsBusiness_Template_Mail_Service objBusnssTemMailServce = new clsBusiness_Template_Mail_Service();
        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
        objEntityMail.Email_Subject = "Notification - Employee Selected";
        objEntityMail.From_Email_Address = strFromAddrss;
        objEntityMail.Out_Service_Name = strServiceName;
        objEntityMail.Out_Port_Number = intPortNo;
        objEntityMail.SSL_Status = intSSlStatus;
        objEntityMail.Password = strSslStatus;
        objEntityMail.D_Date = System.DateTime.Now;
        string strDate = System.DateTime.Now.ToString("dd-MM-yyyy");
        objEntityMail.To_Email_Address = strConstncyMail;
        string strMailContent = "";
        if (lblDesign.Text != "")
        {
            strMailContent = "This is to notify that the candidate with the following details has selected for the post of " + lblDesign.Text + "";
        }
        else
        {
            strMailContent = "This is to notify that the candidate with the following details has selected";
        }
        if (strOrg != "")
        {
            strMailContent += " in " + strOrg + " Organization.";
        }
        else
        {
            strMailContent += " in our organization.";
        }
        strMailContent += "<br/><br/>Name   : " + strCandidatename + "";
        strMailContent += "<br/>Date   : " + strDate + "";
        strMailContent += "<br/>Thank you";
        objEntityMail.Email_Content = strMailContent;
        MailUtility_ERP.clsMail objMail = new MailUtility_ERP.clsMail();
        objMail.SendJobNotifyMail(objEntityMail, objEntityMailAttachList);
    }
    //END
    [WebMethod]
    public static void JoiningStatus(string strId, string strSts)
    {

        clsEntity_Joining_Intimation objEntityJoiningList = new clsEntity_Joining_Intimation();
        SelectedCandiate objentityShortList = new SelectedCandiate();

        clcBusiness_Joining_Intimation objBusinessJoingIntimation = new clcBusiness_Joining_Intimation();
        objentityShortList.CandidateId = Convert.ToInt32(strId);
        objentityShortList.JoiningStatus = Convert.ToInt32(strSts);
        objBusinessJoingIntimation.UpdJoinStatus(objentityShortList);

    }

    public class PDFFooter : PdfPageEventHelper
    {
        // write on top of document
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);
            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            tabFot.SpacingAfter = 10F;
            PdfPCell cell;
            tabFot.TotalWidth = 300F;
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/CustomImages/Corporate Logos/quotation-header.png"));
            image.ScalePercent(PdfPCell.ALIGN_CENTER);
            image.ScaleToFit(600f, 80f);
            cell = new PdfPCell(new PdfPCell(image) { Border = 0 });
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 145, document.Top, writer.DirectContent);
        }

        // write on start of each page
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
        }

        // write on end of each page
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            PdfPCell cell;
            tabFot.TotalWidth = 300F;
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/CustomImages/Corporate Logos/quotation-footer.png"));
            image.ScalePercent(PdfPCell.ALIGN_LEFT);
            image.ScaleToFit(594f, 80f);
            cell = new PdfPCell(new PdfPCell(image) { Border = 0 });
            tabFot.AddCell(cell);
            //float row = 10;
            tabFot.WriteSelectedRows(0, -1, 0, 90, writer.DirectContent);
            //tabFot.WriteSelectedRows(
        }

        //write on close of document
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
        }
    }


    [WebMethod]
    public static string LoadParmtrsChkbox(string strCorpId, string strOrgId)
    {
        clsEntity_Joining_Intimation objEntityJoiningList = new clsEntity_Joining_Intimation();
        clcBusiness_Joining_Intimation objBusinessJoingIntimation = new clcBusiness_Joining_Intimation();

        HCM_HCM_Master_gen_Joining_Intimation_gen_Joining_Intimation_List objMaster = new HCM_HCM_Master_gen_Joining_Intimation_gen_Joining_Intimation_List();

        objEntityJoiningList.CorpOffice_Id = Convert.ToInt32(strCorpId);
        objEntityJoiningList.Organisation_Id = Convert.ToInt32(strOrgId);

        DataTable dtParmtrs = objBusinessJoingIntimation.ReadAppointmtParamtrs(objEntityJoiningList);

        dtParmtrs.TableName = "dtTable";
        string result = "";
        if (dtParmtrs.Rows.Count > 0)
        {
            result = objMaster.DataTableToJSONWithJavaScriptSerializer(dtParmtrs);
        }

        return result;
    }

    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
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


    public class clsWBData
    {
        public string HEADER_ID { get; set; }
        public string HEADER_NAME { get; set; }
        public string DESCRIPTN { get; set; }
    }

}