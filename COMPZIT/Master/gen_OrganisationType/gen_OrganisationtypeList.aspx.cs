using BL_Compzit;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit;

// CREATED BY:EVM-0001
// CREATED DATE:20/02/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_OrganisationType_gen_OrganisationtypeList : System.Web.UI.Page
{
    public static string strOrgId;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        //On not is post back
        if (!IsPostBack)
        {
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Organisation_Type);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //future

                    }

                }

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    divAdd.Visible = true;

                }
                else
                {

                    divAdd.Visible = false;

                }


                //Created objects for business layer
                clsBusinessLayerOrgType objBusinessLayerOrgType = new clsBusinessLayerOrgType();
                clsEntityOrgType objEntityOrgType = new clsEntityOrgType();

                hiddenDsgnTypId.Value = "0";
                hiddenDsgnControlId.Value = "C";
                if (Session["DSGN_TYPID"] != null)
                {
                    hiddenDsgnTypId.Value = Session["DSGN_TYPID"].ToString();
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["DSGN_CONTROL"] != null)
                {
                    hiddenDsgnControlId.Value = Session["DSGN_CONTROL"].ToString();
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }


                if (Request.QueryString["Id"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityOrgType.OrgTypId = Convert.ToInt32(strId);
                    objEntityOrgType.OrgUserId = intUserId;

                    objEntityOrgType.OrgDate = System.DateTime.Now;

                    if (hiddenDsgnControlId.Value == "C")
                    {
                        int intCorpId = 0;
                        if (Session["CORPOFFICEID"] != null)
                        {

                            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                        }
                        else if (Session["CORPOFFICEID"] == null)
                        {
                            Response.Redirect("~/Default.aspx");
                        }

                        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                        DataTable dtCorpDetail = new DataTable();
                        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                        if (dtCorpDetail.Rows.Count > 0)
                        {
                            string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                            if (CnclrsnMust == "0")
                            {
                                objEntityOrgType.OrgCancelReason = objCommon.CancelReason();
                                objBusinessLayerOrgType.UpdateCancel(objEntityOrgType);
                                Response.Redirect("gen_OrganisationtypeList.aspx?InsUpd=Cncl");

                            }
                            else
                            {

                                DataTable dtOrgType = new DataTable();
                                dtOrgType = objBusinessLayerOrgType.GridDisplay(objEntityOrgType);

                                string strHtm = ConvertDataTableToHTML(dtOrgType, intEnableModify, intEnableCancel);
                                //Write to divReport
                                divReport.InnerHtml = strHtm;

                                hiddenRsnid.Value = strId;
                                ModalPopupExtenderCncl.Show();

                            }

                        }

                    }
                    else
                    {
                        objEntityOrgType.OrgCancelReason = objCommon.CancelReason();
                        objBusinessLayerOrgType.UpdateCancel(objEntityOrgType);
                        Response.Redirect("gen_OrganisationtypeList.aspx?InsUpd=Cncl");

                    }
                }
                else
                {
                    //to view
                    objEntityOrgType.OrgStatus = 1;
                    objEntityOrgType.Cancel_Status = 0;
                    DataTable dtOrgType = new DataTable();
                    dtOrgType = objBusinessLayerOrgType.GridDisplay(objEntityOrgType);

                    string strHtm = ConvertDataTableToHTML(dtOrgType, intEnableModify, intEnableCancel);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;

                    if (Request.QueryString["InsUpd"] != null)
                    {
                        string strInsUpd = Request.QueryString["InsUpd"].ToString();
                        if (strInsUpd == "Ins")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                        }
                        else if (strInsUpd == "Upd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                        }
                        else if (strInsUpd == "Cncl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                        }
                    }
                }

            }

        }
    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel)
    {


        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:76%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
          
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }




        }

        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
        }

        if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
        }


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());
       
            strHtml += "<tr >";

            //FOR CANCELED COLUMN IDENTIFICATION ICON
            if (intCnclUsrId == 0)
            {
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word; text-align: center;\"></td>";
            }
            else
            {
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" +
                         "<img   src='../../Images/Icons/cancel.png' /> " + " </td>";
            }
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:76%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
              
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;



            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {


                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
                              " href=\"gen_Organisationtype.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";


                }

                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
                     " href=\"gen_Organisationtype.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='../../Images/Icons/view.png' /> " + "</a> </td>";


                }
            }
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {
                      if (intCancTransaction == 0)
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelAlert(this.href);' " +
                             " href=\"gen_OrganisationtypeList.aspx?Id=" + Id + "\">" + "<img  src='../../Images/Icons/delete.png' /> " + "</a> </td>";
                        }
                        else
                        {

                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >" +
                                   "<img style=\"opacity: 0.2;cursor: pointer; \" src='../../Images/Icons/delete.png' /> " + "</a> </td>";

                        }

                }
                else
                {

                    strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\"></td>";
                }
            }
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    //for creating HTML Title
    private string SetTitle(string size, string value)
    {

        return "<h" + size + "><p align=center>" + value + "</p align></h" + size + ">";

    }
   
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {

        //Created objects for business layer
        clsBusinessLayerOrgType objBusinessLayerOrgType = new clsBusinessLayerOrgType();
        clsEntityOrgType objEntityOrgType = new clsEntityOrgType();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityOrgType.OrgTypId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityOrgType.OrgUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityOrgType.OrgDate = System.DateTime.Now;

            objEntityOrgType.OrgCancelReason = txtCnclReason.Text.Trim();
            objBusinessLayerOrgType.UpdateCancel(objEntityOrgType);


            Response.Redirect("gen_OrganisationtypeList.aspx?InsUpd=Cncl");


        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusinessLayerOrgType objBusinessLayerOrgType = new clsBusinessLayerOrgType();
        clsEntityOrgType objEntityOrgType = new clsEntityOrgType();
       
        objEntityOrgType.OrgStatus = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        if (cbxCnclStatus.Checked == true)
        {
            objEntityOrgType.Cancel_Status = 1;
        }
        else
        {
            objEntityOrgType.Cancel_Status = 0;
        }





        DataTable dtOrgType = new DataTable();
        dtOrgType = objBusinessLayerOrgType.GridDisplay(objEntityOrgType);

        int intUserId = 0, intUsrRolMstrId,intEnableModify = 0, intEnableCancel = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Organisation_Type);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                }
            }
        }
        string strHtm = ConvertDataTableToHTML(dtOrgType, intEnableModify, intEnableCancel);
        //Write to divReport
        divReport.InnerHtml = strHtm;

    }
}