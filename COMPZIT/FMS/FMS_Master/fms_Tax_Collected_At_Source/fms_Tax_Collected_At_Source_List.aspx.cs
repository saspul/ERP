using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit;
using BL_Compzit.BusinessLayer_FMS;
using CL_Compzit;
using System.Data;
using System.Text;
using System.Web.Services;
public partial class FMS_FMS_Master_fms_Tax_Collected_At_Source_fms_Tax_Collected_At_Source_List : System.Web.UI.Page
{
    clsBusinessLyer_Tax_CollectedAt_Source objEmpTCS = new clsBusinessLyer_Tax_CollectedAt_Source();
    protected void Page_Load(object sender, EventArgs e)
    {
        int intFrmwrkId = 1;
        if (Session["FRMWRK_ID"] != null)
        {
            intFrmwrkId = Convert.ToInt32(Session["FRMWRK_ID"].ToString());
            //intFrmwrkId = 2;
        }
        if (intFrmwrkId == 1)
        {
            aHome.HRef = " /Home/Compzit_LandingPage/Compzit_LandingPage.aspx";
        }
        else
        {
            aHome.HRef = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
        }
        ddlStatus.Focus();
        clsEntityLayer_Tax_CollectedAt_Source objEntity = new clsEntityLayer_Tax_CollectedAt_Source();
        if (!IsPostBack)
        {
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

                objEntity.User_Id = intUserId;

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                objEntity.Corporate_id = intCorpId;
                // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntity.Organisation_id = intOrgId;

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.TaxCollectedAtSource);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleConf.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                       // HiddenRoleEdit.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active); ;
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }


                }
            }


            if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
                divAdd.Visible = false;
            }

            objEntity.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
            DataTable dtList = objEmpTCS.ReadTCSList(objEntity);

            //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

           divList.InnerHtml = ConvertDataTableToHTML(dtList,intUpdate, intEnableCancel);
           clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                       };

           DataTable dtCorpDetail = new DataTable();
           dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
           if (dtCorpDetail.Rows.Count > 0)
           {
               HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
           }
           if (Request.QueryString["InsUpd"] != null)
           {
               string strInsUpd = Request.QueryString["InsUpd"].ToString();
               if (strInsUpd == "Cncl")
               {
                   ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
               }
               else if (strInsUpd == "Error")
               {
                   ScriptManager.RegisterStartupScript(this, GetType(), "ErrorCancelation", "ErrorCancelation();", true);
               }
           }

        }

    }
    public string ConvertDataTableToHTML(DataTable dt,int intUpdate, int intEnableCancel)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        String Status = "";
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());


        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"display table-bordered\" cellspacing=\"0\"  width=\"100%\">";
        //add header row
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr >";



        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {

                strHtml += "<th class=\"col-md-1 tr_l \" > NAME";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in\" placeholder=\" NAME\"  type=\"text\"/>";
                strHtml += "</th >";

                //strHtml += "<th class=\"hasinput\" style=\"text-align:left;width:35%;\">NAME ";

                //strHtml += "	<input class=\"form-control\" placeholder=\" NAME\" style=\"text-align:left;width:35%;\" type=\"text\">";
                //strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"col-md-2 hasinput\" >COLLECTIVE PERCENTAGE";
                strHtml += " <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in\" placeholder=\"DEDUCTIVE PERCENTAGE\" type=\"text\"/>";
                strHtml += "</th >";

                //strHtml += "<th class=\"hasinput\" style=\"width:20%;text-align:right;\">COLLECTIVE PERCENTAGE ";
                //strHtml += "	<input class=\"form-control\" placeholder=\"COLLECTIVE PERCENTAGE \" style=\"text-align:right;width:10%;\" type=\"text\">";
                //strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"col-md-2 hasinput\" >FROM DATE ";
                strHtml += "	<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in\" placeholder=\"FROM DATE\"  type=\"text\"/>";
                strHtml += "</th >";

                //strHtml += "<th class=\"hasinput\" style=\"width:15%;text-align:center;\">FROM DATE ";
                //strHtml += "	<input class=\"form-control\" placeholder=\"FROM DATE\" style=\"text-align:center;width:15%;\" type=\"text\">";
                //strHtml += "</th >";
            }

            else if (intColumnHeaderCount == 4)
            {

                strHtml += "<th class=\"col-md-2 hasinput\">TO DATE";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input class=\"tb_inp_1 tb_in\"  placeholder=\"TO DATE\" type=\"text\"/>";
                strHtml += "</th >";

                //strHtml += "<th class=\"hasinput\" style=\"width:15%;text-align:center;\">TO DATE ";
                //strHtml += "	<input class=\"form-control\" placeholder=\"TO DATE\" style=\"text-align:center;width:15%;\" type=\"text\">";
                //strHtml += "</th >";
            }

            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"col-md-2 \" > ACTIONS <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>";
                //    if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                //    {
                //        if (cbxCnclStatus.Checked == false)
                //        {

                //            strHtml += "<th class=\"hasinput\" style=\"width:5%;text-align: center;\"> EDIT";

                //        }
                //    }
                //    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                //    {
                //        if (cbxCnclStatus.Checked == false)
                //        {

                //            strHtml += "<th class=\"hasinput\" style=\"width:5%;text-align: center;\"> DELETE";

                //        }
                //    }

                //}

                //else if (intColumnHeaderCount == 6)
                //{
                //    if (cbxCnclStatus.Checked == true)
                //    {
                //        strHtml += "<th class=\"hasinput\" style=\"width:5%;text-align: center;\"> VIEW";
                //    }
                //}


            }
        }

            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows

            strHtml += "<tbody>";
            int COUNT = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                //  string orgid = dt.Rows[intRowBodyCount][0].ToString();
                // strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";
                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                COUNT++;

                // strHtml += "<td class=\"tdT\" style=\" width:5%;text-align: left;\" >" + COUNT + "</td>";

                for (int intColumnBodyCount = 0; intColumnBodyCount < 7; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount]["TX_CLTN_NAME"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {

                        strHtml += "<td > <button class=\"btn tab_but1 butn1\">" + dt.Rows[intRowBodyCount]["TX_CLTN_PRCNTG"].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 3)
                    {


                        strHtml += "<td > " + dt.Rows[intRowBodyCount]["TX_CLTN_FRM_DATE"].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 4)
                    {


                        strHtml += "<td > " + dt.Rows[intRowBodyCount]["TX_CLTN_TO_DATE"].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 5)
                    {

                        strHtml += " <td> <div class=\"btn_stl1\">";
                        if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            if (cbxCnclStatus.Checked == false)
                            {

                                strHtml += " <a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn1 bt_e\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                " href=\"fms_Tax_Collected_At_Source.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";

                            }

                        }
                        if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            if (cbxCnclStatus.Checked == false)
                            {
                                //if (intCancTransaction == 0)
                                strHtml += "<a  href=\"#\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                                //else
                                //    strHtml += "<td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><a  href=\"#\" style=\"opacity: .4;margin-left: 1%;z-index: 10;\" class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a></td>";

                            }

                        }


                        if (cbxCnclStatus.Checked == true)
                        {
                            strHtml += "<a style=\"opacity: 1;\" class=\"btn act_btn bn4 bt_v\" title=\"VIEW\" onclick='return getdetails(this.href);' " +
                                         " href=\"fms_Tax_Collected_At_Source.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";


                        }
                        strHtml += "</div></td>";
                    }
               

            }
            strHtml += "</tr>";
        }
          
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    [WebMethod]
    public static string CancelMemoReason(string strmemotId, string reasonmust, string usrId, string cnclRsn, string strOrgIdID, string strCorpID)
    {
        clsBusinessLyer_Tax_CollectedAt_Source objEmpTCS = new clsBusinessLyer_Tax_CollectedAt_Source();
        clsEntityLayer_Tax_CollectedAt_Source objEntity = new clsEntityLayer_Tax_CollectedAt_Source();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntity.TcsId = Convert.ToInt32(strId);
        objEntity.User_Id = Convert.ToInt32(usrId);
        objEntity.Organisation_id = Convert.ToInt32(strOrgIdID);
        objEntity.Corporate_id = Convert.ToInt32(strCorpID);
        if (reasonmust == "1")
        {
            objEntity.CancelReason = cnclRsn;
        }

        else
        {
            objEntity.CancelReason = objCommon.CancelReason();
        }

        try
        {
            objEmpTCS.CancelTaxCollectedAtSource(objEntity);

        }
        catch
        {
            strRets = "failed";
        }

        return strRets;

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntityLayer_Tax_CollectedAt_Source objEntity = new clsEntityLayer_Tax_CollectedAt_Source();

        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.User_Id = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.Corporate_id = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.Organisation_id = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.TaxCollectedAtSource);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                {
                    intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    //HiddenRoleConf.Value = "1";
                }
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    // HiddenRoleEdit.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active); ;
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                }


            }
        }
        if (cbxCnclStatus.Checked == true)
        {

            objEntity.cncl_sts = 1;
        }
        else
        {
            objEntity.cncl_sts = 0;
        }
        objEntity.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        DataTable dtList = objEmpTCS.ReadTCSList(objEntity);

        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel);
    }
}