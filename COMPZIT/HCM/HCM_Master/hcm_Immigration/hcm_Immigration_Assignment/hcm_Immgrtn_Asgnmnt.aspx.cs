using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

public partial class HCM_HCM_Master_hcm_Immigration_hcm_Immigration_Assignment_hcm_Immgrtn_Asgnmnt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            FillDropdown();
            hiddenAsignId.Value = "";
            hiddenFinishStatus.Value = "0";
            hiddenCloseStatus.Value = "0";
            int intUserId = 0, intUsrRolMstrId = 0, intEnableAdd = 0, intEnableModify = 0;
            clsBusinessLayerImgrtnAsgnmnt objBusinessImmiAsgn = new clsBusinessLayerImgrtnAsgnmnt();
            clsEntityLayerImgrtnAsgnmnt objEntityImmiAsgn = new clsEntityLayerImgrtnAsgnmnt();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            radioNotAssigned.Checked = true;

            if (Session["USERID"] != null)
            {
                hiddenUserId.Value = Session["USERID"].ToString();
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();
                objEntityImmiAsgn.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                hiddenOrganisationId.Value = Session["ORGID"].ToString();
                objEntityImmiAsgn.Orgid = Convert.ToInt32(Session["ORGID"]);
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


             intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Immigration_Assignment);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            btnAssign.Visible = false;
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        btnAssign.Visible = true;
                        intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenRoleModify.Value = intEnableModify.ToString();
                    }
                }
            }

            objEntityImmiAsgn.EmployeeId = 0;
            DataTable dtCandidateList = objBusinessImmiAsgn.ReadEmployeeCandidatesList(objEntityImmiAsgn);
            string strHtm = ConvertDataTableToHTMLNotAssigned(dtCandidateList);
            divReport.InnerHtml = strHtm;


            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "PrcsAsgn")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
                }
                else if (strInsUpd == "PrcsAsgnUpd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "Rcl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRecall", "SuccessRecall();", true);
                }

            }
        }


    }
    public void FillDropdown()
    {
        clsBusinessLayerImgrtnAsgnmnt objBusinessImmiAsgn = new clsBusinessLayerImgrtnAsgnmnt();
        clsEntityLayerImgrtnAsgnmnt objEntityImmiAsgn = new clsEntityLayerImgrtnAsgnmnt();
        if (Session["USERID"] != null)
        {
            objEntityImmiAsgn.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImmiAsgn.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityImmiAsgn.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtEmp = objBusinessImmiAsgn.ReadEmployeeCandidate(objEntityImmiAsgn);
        if (dtEmp.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dtEmp;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();

        }

        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");

    }



    public string ConvertDataTableToHTMLNotAssigned(DataTable dt)
    {
        clsBusinessLayerImgrtnAsgnmnt objBusinessImmiAsgn = new clsBusinessLayerImgrtnAsgnmnt();
        clsEntityLayerImgrtnAsgnmnt objEntityImmiAsgn = new clsEntityLayerImgrtnAsgnmnt();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";
        strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" Id=\"cbxSelectAll\" style=\"margin-left: 23%;\" onkeypress=\"return DisableEnter(event)\"; onchange=\"selectAllCandidate()\"></th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {


            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:30%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:25%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

        }
        strHtml += "<th class=\"thT\"  style=\"width:25%;text-align: left; word-wrap:break-word;\">DIVISION</th>";

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        hiddenRowCount.Value = dt.Rows.Count.ToString();
        strHtml += "<tbody>";
        int count = 0;
        if (dt.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                count++;
                strHtml += "<tr  >";

                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblcandidatelist" + intRowBodyCount + "\"true\" onkeypress=\"return DisableEnter(event)\"; onchange=\"IncrmntConfrmCounter()\"></td>";

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 3)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                }
                objEntityImmiAsgn.EmployeeId =Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"]);
                DataTable dtDivisions = objBusinessImmiAsgn.ReadDivisionOfEmp(objEntityImmiAsgn);

                string strDivisions = "";
                foreach (DataRow dtDiv in dtDivisions.Rows)
                {
                    strDivisions = dtDiv["CPRDIV_NAME"] + "," + strDivisions;
                }
                if (strDivisions != "")
                {
                    strDivisions = strDivisions.Remove(strDivisions.Length - 1);
                }
                strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strDivisions + "</td>";

                strHtml += "<td id=\"tdcandiateid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount]["CAND_ID"].ToString() + "</td>";

                strHtml += "</tr>";

            }
        }
        else
        {
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  >No Data Available</td>";
            strHtml += "<td  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";

        }

        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }

    public string ConvertDataTableToHTMLAssigned(DataTable dt)
    {
        clsBusinessLayerImgrtnAsgnmnt objBusinessImmiAsgn = new clsBusinessLayerImgrtnAsgnmnt();
        clsEntityLayerImgrtnAsgnmnt objEntityImmiAsgn = new clsEntityLayerImgrtnAsgnmnt();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:30%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:25%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }


        }

        strHtml += "<th class=\"thT\"  style=\"width:25%;text-align: left; word-wrap:break-word;\">DIVISION</th>";

        if (HiddenRoleModify.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
        {
            strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: center; word-wrap:break-word;\">EDIT</th>";
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        hiddenRowCount.Value = dt.Rows.Count.ToString();
        strHtml += "<tbody>";
        int count = 0;
        if (dt.Rows.Count == 0)
        {
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  >No Data Available</td>";
            strHtml += "<td  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            if (HiddenRoleModify.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
            {
                strHtml += "<td  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            }
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";
        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < 1; intRowBodyCount++)
            {
                count++;
                strHtml += "<tr  >";

                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</td>";

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                string strDetailId = dt.Rows[intRowBodyCount]["IMGTNDTL_ID"].ToString();
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                }

                objEntityImmiAsgn.EmployeeId = Convert.ToInt32(dt.Rows[intRowBodyCount]["USR_ID"]);
                DataTable dtDivisions = objBusinessImmiAsgn.ReadDivisionOfEmp(objEntityImmiAsgn);

                string strDivisions = "";
                foreach (DataRow dtDiv in dtDivisions.Rows)
                {
                    strDivisions = dtDiv["CPRDIV_NAME"] + "," + strDivisions;
                }
                if (strDivisions!="")
                {
                strDivisions = strDivisions.Remove(strDivisions.Length - 1);
                }
                string CandidateId = dt.Rows[intRowBodyCount]["CAND_ID"].ToString();
                strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strDivisions + "</td>";
                if (HiddenRoleModify.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                {
                    strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\"><a class=\"tooltip\" title=\"Edit\" onclick=\"return ProcessEdit('" + objEntityImmiAsgn.EmployeeId + "','" + CandidateId + "');\" ><img  style=\"cursor:pointer;margin-left: 10%;float: left;\" src='/Images/Icons/edit.png' /></a> </td>";

                }
                strHtml += "<td id=\"tdcandiateid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount]["CAND_ID"].ToString() + "</td>";

                strHtml += "</tr>";

            }
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusinessLayerImgrtnAsgnmnt objBusinessImmiAsgn = new clsBusinessLayerImgrtnAsgnmnt();
        clsEntityLayerImgrtnAsgnmnt objEntityImmiAsgn = new clsEntityLayerImgrtnAsgnmnt();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImmiAsgn.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityImmiAsgn.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (radioNotAssigned.Checked == true)
        {
            btnAssign.Visible = true;
            objEntityImmiAsgn.SearchStatus = 0;

            if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                objEntityImmiAsgn.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            }
            DataTable dtCandidateList = objBusinessImmiAsgn.ReadEmployeeCandidatesList(objEntityImmiAsgn);
            string strHtm = ConvertDataTableToHTMLNotAssigned(dtCandidateList);
            divReport.InnerHtml = strHtm;

        }
        else
        {
            btnAssign.Visible = false;
            objEntityImmiAsgn.SearchStatus = 1;

            if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                objEntityImmiAsgn.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            }
            DataTable dtCandidateList = objBusinessImmiAsgn.ReadEmployeeCandidatesList(objEntityImmiAsgn);
            string strHtm = ConvertDataTableToHTMLAssigned(dtCandidateList);
            divReport.InnerHtml = strHtm;
        }

    }
    protected void btnImmiAsgnMultySave_Click(object sender, EventArgs e)
    {
        clsBusinessLayerImgrtnAsgnmnt objBusinessImmiAsgn = new clsBusinessLayerImgrtnAsgnmnt();
        clsEntityLayerImgrtnAsgnmnt objEntityImmiAsgn = new clsEntityLayerImgrtnAsgnmnt();
        clsCommonLibrary ObjCommon = new clsCommonLibrary();

        if (Session["USERID"] != null)
        {
            objEntityImmiAsgn.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImmiAsgn.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityImmiAsgn.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int AsignId = objBusinessImmiAsgn.Insert_ImmiAsignmnt(objEntityImmiAsgn);

        if (hiddenTotalData.Value != "" && hiddenTotalData.Value != "0")
        {
             string jsonDataPW = hiddenTotalData.Value;
            string R1PW = jsonDataPW.Replace("\"{", "\\{");
            string R2PW = R1PW.Replace("\\n", "\r\n");
            string R3PW = R2PW.Replace("\\", "");
            string R4PW = R3PW.Replace("}\"]", "}]");
            string R5PW = R4PW.Replace("}\",", "},");
            List<clsTimeSheetData> objWBDataPWList = new List<clsTimeSheetData>();
            // UserData  data
            objWBDataPWList = JsonConvert.DeserializeObject<List<clsTimeSheetData>>(R5PW);
            string EmployeeIds = Hiddenchecklist.Value;

            string[] EmpidSplit = EmployeeIds.Split(',');
            foreach (string Empid in EmpidSplit)
            {
                if (Empid != "")
                {
                    foreach (clsTimeSheetData objclsJSData in objWBDataPWList)
                    {

                        objEntityImmiAsgn.CandId =Convert.ToInt32(Empid);
                        objEntityImmiAsgn.RoundId = Convert.ToInt32(objclsJSData.ROUND);
                        objEntityImmiAsgn.RoundStatusId = Convert.ToInt32(objclsJSData.STATUS);
                        objEntityImmiAsgn.ImmgrtnAsgnId = AsignId;
                        objEntityImmiAsgn.UsrDate = ObjCommon.textToDateTime(objclsJSData.DATEPASS);

                        string[] AsignEmpids = objclsJSData.EMPIDS.Replace("(", string.Empty).Replace(")", string.Empty).Split(',');
                        List<clsEntityLayerImgrtnAsgnmntEmpLoy> ObjEmpList = new List<clsEntityLayerImgrtnAsgnmntEmpLoy>();
                        foreach (string AsignEmpid in AsignEmpids)
                        {
                            if (AsignEmpid != "")
                            {
                                clsEntityLayerImgrtnAsgnmntEmpLoy objEmp = new clsEntityLayerImgrtnAsgnmntEmpLoy();

                                objEmp.EmployeeId = Convert.ToInt32(AsignEmpid);
                                ObjEmpList.Add(objEmp);
                            }
                        }

                        objBusinessImmiAsgn.Insert_Process_Detail(objEntityImmiAsgn, ObjEmpList);
                    }
                }
            }

        }

        Response.Redirect("hcm_Immgrtn_Asgnmnt.aspx?InsUpd=PrcsAsgn");

    }

    public class clsTimeSheetData
    {
        public string ROWID { get; set; }
        public string ROUND { get; set; }
        public string STATUS { get; set; }
        public string EMPIDS { get; set; }
        public string DATEPASS { get; set; }
        public string FINISH { get; set; }
        public string CLOSE { get; set; }
        public string DETAILID { get; set; }
    }

    

    protected void btnImmiAsgnSingleSave_Click(object sender, EventArgs e)
    {
        clsBusinessLayerImgrtnAsgnmnt objBusinessImmiAsgn = new clsBusinessLayerImgrtnAsgnmnt();
        clsEntityLayerImgrtnAsgnmnt objEntityImmiAsgn = new clsEntityLayerImgrtnAsgnmnt();
        clsCommonLibrary ObjCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            objEntityImmiAsgn.UserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImmiAsgn.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityImmiAsgn.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (hiddenTotalData.Value != "" && hiddenTotalData.Value != "0")
        {
            string jsonDataPW = hiddenTotalData.Value;
            string R1PW = jsonDataPW.Replace("\"{", "\\{");
            string R2PW = R1PW.Replace("\\n", "\r\n");
            string R3PW = R2PW.Replace("\\", "");
            string R4PW = R3PW.Replace("}\"]", "}]");
            string R5PW = R4PW.Replace("}\",", "},");
            List<clsTimeSheetData> objWBDataPWList = new List<clsTimeSheetData>();
            // UserData  data
            objWBDataPWList = JsonConvert.DeserializeObject<List<clsTimeSheetData>>(R5PW);

                    foreach (clsTimeSheetData objclsJSData in objWBDataPWList)
                    {
                        objEntityImmiAsgn.RoundId = Convert.ToInt32(objclsJSData.ROUND);
                        objEntityImmiAsgn.RoundStatusId = Convert.ToInt32(objclsJSData.STATUS);
                        objEntityImmiAsgn.ImmgrtnAsgnDetailId = Convert.ToInt32(objclsJSData.DETAILID);
                        objEntityImmiAsgn.UsrDate = ObjCommon.textToDateTime(objclsJSData.DATEPASS);
                        objEntityImmiAsgn.Finishstatus = Convert.ToInt32(objclsJSData.FINISH);
                        objEntityImmiAsgn.CloseSts = Convert.ToInt32(objclsJSData.CLOSE);

                        string[] AsignEmpids = objclsJSData.EMPIDS.Replace("(", string.Empty).Replace(")", string.Empty).Split(',');
                        List<clsEntityLayerImgrtnAsgnmntEmpLoy> ObjEmpList = new List<clsEntityLayerImgrtnAsgnmntEmpLoy>();
                        foreach (string AsignEmpid in AsignEmpids)
                        {
                            if (AsignEmpid != "")
                            {
                                clsEntityLayerImgrtnAsgnmntEmpLoy objEmp = new clsEntityLayerImgrtnAsgnmntEmpLoy();

                                objEmp.EmployeeId = Convert.ToInt32(AsignEmpid);
                                ObjEmpList.Add(objEmp);
                            }
                        }

                        DataTable dtImmiDetail = objBusinessImmiAsgn.ReadCurrentStsByDtlId(objEntityImmiAsgn);

                        string IntFini="0",IntCls="0";
                        if (dtImmiDetail.Rows.Count > 0)
                        {
                            IntFini = dtImmiDetail.Rows[0]["IMGTNDTL_FNSH_STS"].ToString();
                            IntCls = dtImmiDetail.Rows[0]["IMGTNDTL_CLOSE_STS"].ToString();
                        }
                        if(IntFini=="0"&&IntCls=="0")
                        {
                        objBusinessImmiAsgn.Update_Process_Detail(objEntityImmiAsgn, ObjEmpList);
                        }

                    }
            

        }

        Response.Redirect("hcm_Immgrtn_Asgnmnt.aspx?InsUpd=PrcsAsgn");
    }

    [WebMethod]
    public static string[] ReadImmiRounds(int intCorpId, int intOrgId)
    {
        clsBusinessLayerImgrtnAsgnmnt objBusinessImmiAsgn = new clsBusinessLayerImgrtnAsgnmnt();
        clsEntityLayerImgrtnAsgnmnt objEntityImmiAsgn = new clsEntityLayerImgrtnAsgnmnt();
        clsCommonLibrary ObjCommon = new clsCommonLibrary();
        
        objEntityImmiAsgn.CorpOffice =intCorpId ;
        objEntityImmiAsgn.Orgid = intOrgId ;
        string[] strJsonDW = new string[1];

        DataTable dtImmiRounds = objBusinessImmiAsgn.ReadImmgrtnRounds(objEntityImmiAsgn);
        if (dtImmiRounds.Rows.Count > 0)
        {
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("RoundId", typeof(int));
            dtDetail.Columns.Add("RoundName", typeof(string));

            foreach (DataRow dtRow in dtImmiRounds.Rows)
            {
                DataRow dtDetRow = dtDetail.NewRow();

                dtDetRow["RoundId"] = dtRow["IMGRTNRND_ID"];
                dtDetRow["RoundName"] = dtRow["IMGRTNRND_NAME"];

                dtDetail.Rows.Add(dtDetRow);
            }

            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dtDetail.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtDetail.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);

                }

                parentRow.Add(childRow);
            }

            strJsonDW[0] = jsSerializer.Serialize(parentRow);
        }

        return strJsonDW;
    }

    [WebMethod]
    public static string DropdownRoundStatusBind(string tableName, int intRoundId)
    {
        clsBusinessLayerImgrtnAsgnmnt objBusinessImmiAsgn = new clsBusinessLayerImgrtnAsgnmnt();
        clsEntityLayerImgrtnAsgnmnt objEntityImmiAsgn = new clsEntityLayerImgrtnAsgnmnt();

        objEntityImmiAsgn.RoundId = intRoundId;
        DataTable dtRoundList = new DataTable();
        dtRoundList = objBusinessImmiAsgn.ReadImmgrtnRoundsDetails(objEntityImmiAsgn);
        dtRoundList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtRoundList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }
    [WebMethod]
    public static string DropdownEmployeeBind(string tableName, int intCorpId, int intOrgId)
    {
        clsBusinessLayerImgrtnAsgnmnt objBusinessImmiAsgn = new clsBusinessLayerImgrtnAsgnmnt();
        clsEntityLayerImgrtnAsgnmnt objEntityImmiAsgn = new clsEntityLayerImgrtnAsgnmnt();

        objEntityImmiAsgn.CorpOffice = intCorpId;
        objEntityImmiAsgn.Orgid = intOrgId;
        DataTable dtEmpList = new DataTable();
        dtEmpList = objBusinessImmiAsgn.ReadEmployee(objEntityImmiAsgn);
        dtEmpList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtEmpList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }

    
         [WebMethod]
    public static string[] ReadEmpCandidateData(int intCandId)
    {
        clsBusinessLayerImgrtnAsgnmnt objBusinessImmiAsgn = new clsBusinessLayerImgrtnAsgnmnt();
        clsEntityLayerImgrtnAsgnmnt objEntityImmiAsgn = new clsEntityLayerImgrtnAsgnmnt();

        objEntityImmiAsgn.EmployeeId = intCandId;
        DataTable dtEmpData = new DataTable();
        dtEmpData = objBusinessImmiAsgn.ReadEmployeeCndDtById(objEntityImmiAsgn);
        string[] result = new string[8];
        if (dtEmpData.Rows.Count > 0)
        {
            result[0] = dtEmpData.Rows[0]["EMPERDTL_REF_NUM"].ToString();
            result[1] = dtEmpData.Rows[0]["EMPERDTL_EMPLOYEE_ID"].ToString();
            result[2] = dtEmpData.Rows[0]["USR_NAME"].ToString();
            result[3] = dtEmpData.Rows[0]["DSGN_NAME"].ToString();
            result[4] = dtEmpData.Rows[0]["Type"].ToString();
            result[5] = dtEmpData.Rows[0]["JOBRL_NAME"].ToString();
            result[6] = dtEmpData.Rows[0]["JOIN DATE"].ToString();


        }


        return result;

    }


     [WebMethod]
         public static string AddImmigrationAsign(int intCorpId, int intOrgId,int intUserId)
     {
             string sucess = "";

             clsBusinessLayerImgrtnAsgnmnt objBusinessImmiAsgn = new clsBusinessLayerImgrtnAsgnmnt();
             clsEntityLayerImgrtnAsgnmnt objEntityImmiAsgn = new clsEntityLayerImgrtnAsgnmnt();

             objEntityImmiAsgn.CorpOffice = intCorpId;
             objEntityImmiAsgn.Orgid = intOrgId;
             objEntityImmiAsgn.UserId = intUserId;

             int AsignId = objBusinessImmiAsgn.Insert_ImmiAsignmnt(objEntityImmiAsgn);
             sucess = AsignId.ToString();

             return sucess;
         }

     public static string AddImmigrationAsignDtl(int intCorpId, int intOrgId, int intUserId, int intEmpId, int intRoundId, int intRoundSts, string strTotlEmpIds, string strDatePass, int intAssign)
     {
         string sucess = "";

         clsBusinessLayerImgrtnAsgnmnt objBusinessImmiAsgn = new clsBusinessLayerImgrtnAsgnmnt();
         clsEntityLayerImgrtnAsgnmnt objEntityImmiAsgn = new clsEntityLayerImgrtnAsgnmnt();
         List<clsEntityLayerImgrtnAsgnmntEmpLoy> ObjEmpList = new List<clsEntityLayerImgrtnAsgnmntEmpLoy>();
         clsCommonLibrary ObjCommon = new clsCommonLibrary();

         objEntityImmiAsgn.CorpOffice = intCorpId;
         objEntityImmiAsgn.Orgid = intOrgId;
         objEntityImmiAsgn.UserId = intUserId;
         objEntityImmiAsgn.CandId = intEmpId;
         objEntityImmiAsgn.RoundId = intRoundId;
         objEntityImmiAsgn.RoundStatusId = intRoundSts;
         objEntityImmiAsgn.ImmgrtnAsgnId = intAssign;
         objEntityImmiAsgn.UsrDate = ObjCommon.textToDateTime(strDatePass);

         string[] Empids = strTotlEmpIds.Split(',');

         foreach(string Empid in Empids)
         {
             if (Empid!="")
             {
                 clsEntityLayerImgrtnAsgnmntEmpLoy objEmp = new clsEntityLayerImgrtnAsgnmntEmpLoy();

                 objEmp.EmployeeId = Convert.ToInt32(Empid);
                 ObjEmpList.Add(objEmp);
             }
         }

         objBusinessImmiAsgn.Insert_Process_Detail(objEntityImmiAsgn, ObjEmpList);
         return sucess;
     }


     [WebMethod]
     public static string[] ReadAsignedDetail(int intCandId)
     {
         clsBusinessLayerImgrtnAsgnmnt objBusinessImmiAsgn = new clsBusinessLayerImgrtnAsgnmnt();
         clsEntityLayerImgrtnAsgnmnt objEntityImmiAsgn = new clsEntityLayerImgrtnAsgnmnt();
         clsCommonLibrary ObjCommon = new clsCommonLibrary();

         objEntityImmiAsgn.CandId = intCandId;
         string[] strJsonDW = new string[1];

         DataTable dtImmiDetail = objBusinessImmiAsgn.ReadImmgrtnAsignDetailsByCand(objEntityImmiAsgn);
         if (dtImmiDetail.Rows.Count > 0)
         {
             DataTable dtDetail = new DataTable();
             dtDetail.Columns.Add("ImmiDtlId", typeof(int));
             dtDetail.Columns.Add("ImmiId", typeof(string));
             dtDetail.Columns.Add("RoundId", typeof(string));
             dtDetail.Columns.Add("RoundName", typeof(string));
             dtDetail.Columns.Add("RoundSts", typeof(string));
             dtDetail.Columns.Add("TarDate", typeof(string));
             dtDetail.Columns.Add("FnshSts", typeof(string));
             dtDetail.Columns.Add("CloseSts", typeof(string));
             dtDetail.Columns.Add("EmpIds", typeof(string));
             dtDetail.Columns.Add("EmpNames", typeof(string));
             dtDetail.Columns.Add("EmpSts", typeof(string));
             foreach (DataRow dtRow in dtImmiDetail.Rows)
             {
                 DataRow dtDetRow = dtDetail.NewRow();

                 dtDetRow["ImmiDtlId"] = dtRow["IMGTNDTL_ID"];
                 dtDetRow["ImmiId"] = dtRow["IMGRTN_ID"];
                 dtDetRow["RoundId"] = dtRow["IMGRTNRND_ID"];
                 dtDetRow["RoundName"] = dtRow["IMGRTNRND_NAME"];
                 dtDetRow["RoundSts"] = dtRow["IMGRTNRNDDTL_ID"];
                 dtDetRow["TarDate"] = dtRow["IMGTNDTL_DATE"];
                 dtDetRow["FnshSts"] = dtRow["IMGTNDTL_FNSH_STS"];
                 dtDetRow["CloseSts"] = dtRow["IMGTNDTL_CLOSE_STS"];

                 dtDetail.Rows.Add(dtDetRow);

                 objEntityImmiAsgn.ImmgrtnAsgnDetailId =Convert.ToInt32(dtRow["IMGTNDTL_ID"]);
                 DataTable dtTotalEmp = objBusinessImmiAsgn.ReadAsignedEployees(objEntityImmiAsgn);
                 string strEmpIds = "";
                 string strEmpNames = "";
                 string strEmpSts = "";
                 if (dtTotalEmp.Rows.Count > 0)
                 {

                     foreach (DataRow dt in dtTotalEmp.Rows)
                     {
                         strEmpIds = strEmpIds + "," + dt["USR_ID"].ToString();
                         strEmpNames = strEmpNames + "," + dt["USR_NAME"].ToString();
                         strEmpSts = strEmpSts + "," + dt["USR_STATUS"].ToString();
                     }

                 }

                 dtDetRow["EmpIds"] = strEmpIds;
                 dtDetRow["EmpNames"] = strEmpNames;
                 dtDetRow["EmpSts"] = strEmpSts;

             }

             JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
             List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
             Dictionary<string, object> childRow;
             foreach (DataRow row in dtDetail.Rows)
             {
                 childRow = new Dictionary<string, object>();
                 foreach (DataColumn col in dtDetail.Columns)
                 {
                     childRow.Add(col.ColumnName, row[col]);

                 }

                 parentRow.Add(childRow);
             }

             strJsonDW[0] = jsSerializer.Serialize(parentRow);
         }

         return strJsonDW;
     }

     [WebMethod]
     public static string[] CheckStatusAlreadyDone(string strDetailId)
     {
         clsBusinessLayerImgrtnAsgnmnt objBusinessImmiAsgn = new clsBusinessLayerImgrtnAsgnmnt();
         clsEntityLayerImgrtnAsgnmnt objEntityImmiAsgn = new clsEntityLayerImgrtnAsgnmnt();
         clsCommonLibrary ObjCommon = new clsCommonLibrary();

         objEntityImmiAsgn.ImmgrtnAsgnDetailId =Convert.ToInt32(strDetailId);
         string[] strJsonDW = new string[2];

         DataTable dtImmiDetail = objBusinessImmiAsgn.ReadCurrentStsByDtlId(objEntityImmiAsgn);

         if (dtImmiDetail.Rows.Count > 0)
         {
             strJsonDW[0] = dtImmiDetail.Rows[0]["IMGTNDTL_FNSH_STS"].ToString();
             strJsonDW[1] = dtImmiDetail.Rows[0]["IMGTNDTL_CLOSE_STS"].ToString();
         }
         return strJsonDW;
     }


     [WebMethod]
     public static string RecallClosed(string strDetailId)
     {
         clsBusinessLayerImgrtnAsgnmnt objBusinessImmiAsgn = new clsBusinessLayerImgrtnAsgnmnt();
         clsEntityLayerImgrtnAsgnmnt objEntityImmiAsgn = new clsEntityLayerImgrtnAsgnmnt();
         clsCommonLibrary ObjCommon = new clsCommonLibrary();

         objEntityImmiAsgn.ImmgrtnAsgnDetailId = Convert.ToInt32(strDetailId);
         string strJsonDW = "";

        objBusinessImmiAsgn.RecallAssignment(objEntityImmiAsgn);

         return strJsonDW;
     }
}