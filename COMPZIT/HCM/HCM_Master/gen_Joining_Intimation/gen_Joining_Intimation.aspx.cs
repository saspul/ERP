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
using System.Web.UI.WebControls;

public partial class HCM_HCM_Master_gen_Joining_Intimation_gen_Joining_Intimation : System.Web.UI.Page
{
    clcBusiness_Joining_Intimation objJoiningList = new clcBusiness_Joining_Intimation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            clsEntity_Joining_Intimation objEntityJoiningList = new clsEntity_Joining_Intimation();
            ddlDep.Focus();
            HiddenFieldFocus.Value = "";
           // Corp_DivisionLoad();
            Corp_DepartmentLoad();
            ProjectLoad();
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_Notification);
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
                    objEntityJoiningList.User_Id = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityJoiningList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

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

                clsBusinessCandidate_ShortList objBusinessShortList = new clsBusinessCandidate_ShortList();

                DataTable dtAprvdManpwrRqst = new DataTable();
                dtAprvdManpwrRqst = objJoiningList.ReadJoingReqrmntList(objEntityJoiningList);

                string strHtm = ConvertDataTableToHTML(dtAprvdManpwrRqst, intEnableAdd, intEnableModify);
                //Write to divReport
                divReport.InnerHtml = strHtm;

            }
        }


    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableAdd, int intEnableModify)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";


      //  strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:8%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int count = 1;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            strHtml += "<tr  >";
           // strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count.ToString() + "</td>";
            count++;

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a  onclick='return getdetails(this.href);' " +
                          " href=\"gen_Joining_Intimation_List.aspx?Id=" + Id + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a> </td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 8)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

            }


            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
  
    public void ProjectLoad()
    {
        clsEntity_Joining_Intimation objEntityJoiningList = new clsEntity_Joining_Intimation();

        clsBusinessCandidate_ShortList objBusinessShortList = new clsBusinessCandidate_ShortList();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        if (Session["USERID"] != null)
        {
            objEntityJoiningList.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtProjct = objJoiningList.ReadProject(objEntityJoiningList);
        if (dtProjct.Rows.Count > 0)
        {
            ddlProject.DataSource = dtProjct;
            ddlProject.DataTextField = "PROJECT_NAME";
            ddlProject.DataValueField = "PROJECT_ID";
            ddlProject.DataBind();

        }

        ddlProject.Items.Insert(0, "--SELECT PROJECT--");

    }
    public void Corp_DepartmentLoad()
    {
        clsEntity_Joining_Intimation objEntityJoiningList = new clsEntity_Joining_Intimation();

        clsBusinessCandidate_ShortList objBusinessShortList = new clsBusinessCandidate_ShortList();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        if (Session["USERID"] != null)
        {
            objEntityJoiningList.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objJoiningList.ReadDepartment(objEntityJoiningList);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlDep.DataSource = dtSubConrt;
            ddlDep.DataTextField = "CPRDEPT_NAME";
            ddlDep.DataValueField = "CPRDEPT_ID";
            ddlDep.DataBind();

        }

        ddlDep.Items.Insert(0, "--SELECT DEPARTMENT--");
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");

    }
    //  at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer
        clsEntity_Joining_Intimation objEntityJoiningList = new clsEntity_Joining_Intimation();

        clsBusinessCandidate_ShortList objBusinessShortList = new clsBusinessCandidate_ShortList();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
        if (Session["USERID"] != null)
        {
            objEntityJoiningList.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }



        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntityJoiningList.DivId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }

        if (ddlDep.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            objEntityJoiningList.Deprt_Id = Convert.ToInt32(ddlDep.SelectedItem.Value);
        }
        if (ddlProject.SelectedItem.Value != "--SELECT PROJECT--")
        {
            objEntityJoiningList.PrjctId = Convert.ToInt32(ddlProject.SelectedItem.Value);
        }
        //   clsBusinessLayer_JobNotification objBussinessJobNOtify = new clsBusinessLayer_JobNotification();
        DataTable dtContract = new DataTable();
        dtContract = objJoiningList.ReadJoingReqrmntList(objEntityJoiningList);


        int intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Joining_Intimation);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(objEntityJoiningList.User_Id, intUsrRolMstrId);

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

            }
        }

        string strHtm = ConvertDataTableToHTML(dtContract, intEnableAdd, intEnableModify);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }

    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsEntity_Joining_Intimation objEntityJoiningList = new clsEntity_Joining_Intimation();

        clsBusinessCandidate_ShortList objBusinessShortList = new clsBusinessCandidate_ShortList();
        HiddenFieldFocus.Value = "Div";
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        if (Session["USERID"] != null)
        {
            objEntityJoiningList.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
        {
            objEntityJoiningList.DivId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }


        DataTable dtProjct = objJoiningList.ReadProject(objEntityJoiningList);
        ddlProject.Items.Clear();
        if (dtProjct.Rows.Count > 0)
        {
            ddlProject.DataSource = dtProjct;
            ddlProject.DataTextField = "PROJECT_NAME";
            ddlProject.DataValueField = "PROJECT_ID";
            ddlProject.DataBind();

        }

        ddlProject.Items.Insert(0, "--SELECT PROJECT--");
    }


    protected void ddlDep_SelectedIndexChanged(object sender, EventArgs e)     //emp25
    {
        clsEntity_Joining_Intimation objEntityJoiningList = new clsEntity_Joining_Intimation();

        clsBusinessCandidate_ShortList objBusinessShortList = new clsBusinessCandidate_ShortList();
        HiddenFieldFocus.Value = "Dep";
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        if (Session["USERID"] != null)
        {
            objEntityJoiningList.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ddlDivision.Items.Clear();
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
        if (ddlDep.SelectedItem.Value != "--SELECT DEPARTMENT--")
        {
            int Dept = Convert.ToInt32(ddlDep.SelectedItem.Value);
            objEntityJoiningList.Deprt_Id = Dept;

            DataTable dtSubConrt = objJoiningList.ReadDivision(objEntityJoiningList);
            ddlDivision.Items.Clear();
            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
            if (dtSubConrt.Rows.Count > 0)
            {
                ddlDivision.Items.Clear();
                ddlDivision.DataSource = dtSubConrt;


                ddlDivision.DataValueField = "CPRDIV_ID";
                ddlDivision.DataTextField = "CPRDIV_NAME";

                ddlDivision.DataBind();
                ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
            }

        }


    }

}