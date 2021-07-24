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

public partial class HCM_HCM_Master_hcm_Food_and_Beverages_hcm_Mess_Exemption_hcm_Mess_Exemption_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Employee_Load();
            ddlEmployee.Focus();
            clsEntity_Mess_Exemption objEntityMessException= new clsEntity_Mess_Exemption();


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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Mess_Exemption);
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
                    
                }



                if (Session["USERID"] != null)
                {
                    objEntityMessException.User_Id = Convert.ToInt32(Session["USERID"]);
                    
                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityMessException.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityMessException.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    hiddenOrganisationId.Value = Session["ORGID"].ToString();
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                cls_Business_Mess_Exemption ObjBussinesMessException = new cls_Business_Mess_Exemption();
               
                DataTable dtList = new DataTable();
                dtList = ObjBussinesMessException.ReadMessException_List(objEntityMessException);

                string strHtm = ConvertDataTableToHTML(dtList, intEnableAdd, intEnableModify);
                //Write to divReport
                divReport.InnerHtml = strHtm;
                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    if (strInsUpd == "Save")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessSave", "SuccessSave();", true);
                    }
                    else if (strInsUpd == "Upd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdate", "SuccessUpdate();", true);
                    }

                }
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

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:40%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
           
        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            strHtml += "<tr  >";
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            string strUserId = dt.Rows[intRowBodyCount][6].ToString();

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;cursor:pointer;color: #004093;\" <a onclick=\" return OpenPopUp('" + strUserId + "','" + strId + "');\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + " </a> </td>";
                }
            else if (intColumnBodyCount == 2)
                {
                    if (intEnableModify == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" +  dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + " </td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align: left;cursor:pointer;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + " </td>";

                    }
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                

                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

            }


            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    public void Employee_Load()
    {
         clsEntity_Mess_Exemption objEntityMessException= new clsEntity_Mess_Exemption();
         cls_Business_Mess_Exemption ObjBussinesMessException = new cls_Business_Mess_Exemption();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMessException.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityMessException.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityMessException.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtEmp = ObjBussinesMessException.ReadEmployee(objEntityMessException);
        if (dtEmp.Rows.Count > 0)
        {
            ddlEmployee.DataSource = dtEmp;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();

        }

        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");

    }

    public void Search_Click()
    {

        //Creating objects for business layer

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Mess_Exemption objEntityMessException = new clsEntity_Mess_Exemption();
        cls_Business_Mess_Exemption ObjBussinesMessException = new cls_Business_Mess_Exemption();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMessException.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityMessException.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityMessException.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            objEntityMessException.EmpId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }
        if (txtFromDate.Text != "")
        {
            objEntityMessException.Fromdate = objCommon.textToDateTime(txtFromDate.Text);
        }
        if (txtToDate.Text != "")
        {
            objEntityMessException.Fromdate = objCommon.textToDateTime(txtToDate.Text);
        }

        DataTable dtList = new DataTable();
        dtList = ObjBussinesMessException.ReadMessException_List(objEntityMessException);


        int intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Mess_Exemption);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(objEntityMessException.User_Id, intUsrRolMstrId);

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

        string strHtm = ConvertDataTableToHTML(dtList, intEnableAdd, intEnableModify);
        //Write to divReport
        divReport.InnerHtml = strHtm;

    }

    //  at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer

        clsCommonLibrary objCommon = new clsCommonLibrary();
         clsEntity_Mess_Exemption objEntityMessException= new clsEntity_Mess_Exemption();
         cls_Business_Mess_Exemption ObjBussinesMessException = new cls_Business_Mess_Exemption();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMessException.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityMessException.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityMessException.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
           objEntityMessException.EmpId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }
        if (txtFromDateSrch.Text != "")
        {
            objEntityMessException.Fromdate = objCommon.textToDateTime(txtFromDateSrch.Text);
        }
        if (txtTodateSrch.Text != "")
        {
            objEntityMessException.Todate = objCommon.textToDateTime(txtTodateSrch.Text);
        }
       
        DataTable dtList = new DataTable();
        dtList = ObjBussinesMessException.ReadMessException_List(objEntityMessException);


        int intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Mess_Exemption);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(objEntityMessException.User_Id, intUsrRolMstrId);

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

        string strHtm = ConvertDataTableToHTML(dtList, intEnableAdd, intEnableModify);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }

    protected void btnExceptUpdate_Click(object sender, EventArgs e)
    {
        clsEntity_Mess_Exemption objEntityMessException = new clsEntity_Mess_Exemption();
        cls_Business_Mess_Exemption ObjBussinesMessException = new cls_Business_Mess_Exemption();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityMessException.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityMessException.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityMessException.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityMessException.MessexceptId = Convert.ToInt32(hiddenMessExId.Value);
        objEntityMessException.Fromdate = objCommon.textToDateTime(txtFromDate.Text);
        objEntityMessException.Todate = objCommon.textToDateTime(txtToDate.Text);

        DataTable dtDup = ObjBussinesMessException.CheckDuplication(objEntityMessException);
        if (dtDup.Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "MessDuplication", "MessDuplication();", true);
        }
        else
        {
            ObjBussinesMessException.UpdateMessExcept(objEntityMessException);
        }

        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdate", "SuccessUpdate();", true);
        Search_Click();
    }
    [WebMethod]
    public static string[] ReadAndFillUserData(string intCorpId, string intOrgId, string intUserId)
    {
        string[] datapassing = new string[5];
        clsEntity_Mess_Exemption objEntityMessException = new clsEntity_Mess_Exemption();
        cls_Business_Mess_Exemption ObjBussinesMessException = new cls_Business_Mess_Exemption();

        objEntityMessException.CorpOffice_Id = Convert.ToInt32(intCorpId);
        objEntityMessException.Organisation_Id = Convert.ToInt32(intOrgId);
        objEntityMessException.EmpId = Convert.ToInt32(intUserId);

        DataTable dtDivisions = ObjBussinesMessException.ReadDivisionOfEmp(objEntityMessException);

        string strDivisions = "";
        foreach (DataRow dtDiv in dtDivisions.Rows)
        {
            strDivisions = dtDiv["CPRDIV_NAME"] + "," + strDivisions;
        }
        if (strDivisions != "")
        {
            strDivisions = strDivisions.Remove(strDivisions.Length - 1);
        }
        DataTable dtEmp = ObjBussinesMessException.ReadEmpDetailById(objEntityMessException);
        if (dtEmp.Rows.Count > 0)
        {
            datapassing[0] = dtEmp.Rows[0]["EMPERDTL_FNAME"].ToString();
            datapassing[1] = dtEmp.Rows[0]["DSGN_NAME"].ToString();
            datapassing[2] = dtEmp.Rows[0]["ACCMDTN_NAME"].ToString();


            datapassing[3] = strDivisions;

        }
        return datapassing;
    }
     [WebMethod]
    public static string[] ReadAndFillMessExcept(string intCorpId, string intOrgId, string intMesExId)
    {
        string[] datapassing = new string[5];
        clsEntity_Mess_Exemption objEntityMessException = new clsEntity_Mess_Exemption();
        cls_Business_Mess_Exemption ObjBussinesMessException = new cls_Business_Mess_Exemption();

        objEntityMessException.CorpOffice_Id = Convert.ToInt32(intCorpId);
        objEntityMessException.Organisation_Id = Convert.ToInt32(intOrgId);
        objEntityMessException.MessexceptId = Convert.ToInt32(intMesExId);

        DataTable dtMessdata = ObjBussinesMessException.ReadMessExceptionData_ById(objEntityMessException);

        if (dtMessdata.Rows.Count > 0)
        {
            datapassing[0] = dtMessdata.Rows[0]["FROM DATE"].ToString();
            datapassing[1] = dtMessdata.Rows[0]["TO DATE"].ToString();

        }
        return datapassing;
    }
}