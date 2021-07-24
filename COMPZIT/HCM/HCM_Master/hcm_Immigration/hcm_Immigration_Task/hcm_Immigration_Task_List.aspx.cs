using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit;
using System.Web.Services;
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
public partial class HCM_HCM_Master_hcm_Immigration_hcm_Immigration_Task_hcm_Immigration_Task_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtAsgnedDate.Focus();
        txtAsgnedDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtTodate.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            EmployeeLoad();

            clsEntityImmigrationTasks objEntityImgrtnTasks = new clsEntityImmigrationTasks();
            clsBusinessImmigrationTasks objBusinessImgrtnTasks = new clsBusinessImmigrationTasks();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
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


            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Immigration_Tasks);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                }



                if (Session["USERID"] != null)
                {
                    objEntityImgrtnTasks.UserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityImgrtnTasks.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityImgrtnTasks.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }



                DataTable dtAssgnedImgrtnCandidts = new DataTable();
                dtAssgnedImgrtnCandidts = objBusinessImgrtnTasks.ReadAsgndImgrtnCandts(objEntityImgrtnTasks);
                string strHtm = ConvertDataTableToHTML(dtAssgnedImgrtnCandidts, intEnableAdd, intEnableModify);
                //Write to divReport
                divReport.InnerHtml = strHtm;
                string strhtml = ConvertDataTableToHTMLNotAssigned(dtAssgnedImgrtnCandidts);
                divReportMul.InnerHtml = strhtml;
            }
        }
    }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableAdd, int intEnableModify)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();


        int intimgsection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        int selctdCount = 0;
        //strHtml += "<th class=\"thT\" style=\"width:3%;text-align: left; word-wrap:break-word;\">SL#</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">LOCATION</th>";
            }

            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">REFERENCE</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">NATIONALITY</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">FILE NAME</th>";
            }

        }
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: center; word-wrap:break-word;\">EDIT</th>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {



            strHtml += "<tr>";
            //strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count.ToString() + "</td>";


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;


            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</td>";
                }
               else  if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" +
                           dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CAND_LOC"].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["REF"].ToString() + "</td>";
                }
                else if (intColumnBodyCount ==5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CNTRY_NAME"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a style=\"opacity:2;margin-top:-1%;\" class=\"tooltips\" title=\"\" onclick='return getdetails(this.href);' " +
                        " href=\"" + imgpath + dt.Rows[intRowBodyCount]["CAND_RESUMENAME"].ToString() + "\">" + dt.Rows[intRowBodyCount]["CAND_ACT_RESUMENAME"].ToString() + "</a> </td>";
                }




            }


            strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a style=\"opacity:2;margin-top:-1.3%;\"  class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                    " href=\"hcm_Immigration_Task.aspx?Id=" + Id + "\">" + "<img  style=\" cursor:pointer;\" src='/Images/Icons/edit.png' /> " + "</a> </td>";




            strHtml += "</tr>";




        }




        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }


    public string ConvertDataTableToHTMLNotAssigned(DataTable dt)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        int intimgsection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";
        strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" Id=\"cbxSelectAll\" style=\"margin-left: 23%;\" onchange=\"selectAllCandidate()\"></th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {


            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:30%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

        }

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
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblcandidatelist" + intRowBodyCount + "\"true\" onchange=\"IncrmntConfrmCounter()\"></td>";

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string reference = "";
                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 3)
                    {
                        if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                        {
                            reference = "Consultancy";
                        }
                        else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "2")
                        {
                            reference = "Division";
                        }
                        else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "3")
                        {
                            reference = "Department";
                        }
                        else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "4")
                        {
                            reference = "Employee";
                        }

                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + reference + "</td>";
                    }



                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }
                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a class=\"tooltip\" title=\"\" onclick='return getdetails(this.href);' " +
                                " href=\"" + imgpath + dt.Rows[intRowBodyCount][6].ToString() + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a> </td>";

                    }
                    else if (intColumnBodyCount == 7)
                    {
                        if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                            strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >YES</td>";
                        else
                            strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >NO</td>";

                    }

                }

                strHtml += "<td id=\"tdcandiateid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";

                strHtml += "</tr>";

            }
        }
        else
        {
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  >No Data Available</td>";
            strHtml += "<td  class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;border-right: none;\"  ></td>";
            strHtml += "<td  class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  ></td>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    //  at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntityImmigrationTasks objEntityImgrtnTasks = new clsEntityImmigrationTasks();
        clsBusinessImmigrationTasks objBusinessImgrtnTasks = new clsBusinessImmigrationTasks();
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
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


        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Immigration_Tasks);
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
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                }
            }



            if (Session["USERID"] != null)
            {
                objEntityImgrtnTasks.UserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityImgrtnTasks.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityImgrtnTasks.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (ddlEmp.SelectedItem.Value != "--Select Employee--")
            {
                objEntityImgrtnTasks.EmployeeId = Convert.ToInt32(ddlEmp.SelectedItem.Value);
            }
            if (txtAsgnedDate.Text.Trim() != "")
            {
                objEntityImgrtnTasks.CloseDate = objCommon.textToDateTime(txtAsgnedDate.Text);
            }
            if (txtTodate.Text.Trim() != "")
            {
                objEntityImgrtnTasks.FinishDate = objCommon.textToDateTime(txtTodate.Text);
            }

            DataTable dtAssgndProcess = new DataTable();
            dtAssgndProcess = objBusinessImgrtnTasks.ReadAsgndImgrtnCandts(objEntityImgrtnTasks);
            string strHtm = ConvertDataTableToHTML(dtAssgndProcess, intEnableAdd, intEnableModify);
            //Write to divReport
            divReport.InnerHtml = strHtm;

        }
    }
    public void EmployeeLoad()
    {
        clsEntityImmigrationTasks objEntityImgrtnTasks = new clsEntityImmigrationTasks();
        clsBusinessImmigrationTasks objBusinessImgrtnTasks = new clsBusinessImmigrationTasks();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImgrtnTasks.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityImgrtnTasks.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityImgrtnTasks.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dt = objBusinessImgrtnTasks.ReadEmpLoad(objEntityImgrtnTasks);
        ddlEmp.Items.Clear();
        if (dt.Rows.Count > 0)
        {
            ddlEmp.DataSource = dt;
            ddlEmp.DataTextField = "USR_NAME";
            ddlEmp.DataValueField = "CAND_ID";
            ddlEmp.DataBind();

        }

        ddlEmp.Items.Insert(0, "--Select Employee--");
    }
}