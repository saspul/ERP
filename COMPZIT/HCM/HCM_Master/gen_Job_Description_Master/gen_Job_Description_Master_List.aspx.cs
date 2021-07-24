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

// CREATED BY:EVM-0008
// CREATED DATE:10/5/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class HCM_HCM_Master_gen_Job_Description_Master_gen_Job_Description_Master_List : System.Web.UI.Page
{
    clsBusiness_Job_Description_Master objBusinessJobDesrp = new clsBusiness_Job_Description_Master();
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlDep.Focus();
        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();
            Corp_DepartmentLoad();
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
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
            intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
            DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
            if (dtCancelRecall.Rows.Count > 0)
            {
                intEnableRecall = 1;
            }
            else
            {
                intEnableRecall = 0;
            }
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_Description);
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



                if (Session["USERID"] != null)
                {
                    objEntityJobDesrp.User_Id = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityJobDesrp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityJobDesrp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
                {
                    string strHidden = Request.QueryString["Srch"].ToString();
                    HiddenSearchField.Value = strHidden;

                    string[] strSearchFields = strHidden.Split(',');
                    string strddlDivision = strSearchFields[0];
                    string strDeprtmnt = strSearchFields[1];
                    string strCbxStatus = strSearchFields[2];



                    if (strddlDivision != null && strddlDivision != "")
                    {
                        if (ddlDivision.Items.FindByValue(strddlDivision) != null)
                        {
                            if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                            {
                                ddlDivision.Items.FindByValue(strddlDivision).Selected = true;
                            }
                        }
                    }


                    if (strDeprtmnt != null && strDeprtmnt != "")
                    {
                        if (ddlDep.Items.FindByValue(strDeprtmnt) != null)
                        {
                            if (ddlDep.SelectedItem.Value != "--SELECT DEPARTMENT--")
                            {
                                ddlDep.Items.FindByValue(strDeprtmnt).Selected = true;
                            }
                        }
                    }
                    if (strCbxStatus == "1")
                    {
                        cbxCnclStatus.Checked = true;
                    }
                    else
                    {
                        cbxCnclStatus.Checked = false;
                    }

                }
              

                if (Request.QueryString["canId"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["canId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityJobDesrp.JobDescrpId = Convert.ToInt32(strId);
                    objEntityJobDesrp.User_Id = intUserId;

                    objEntityJobDesrp.D_Date = System.DateTime.Now;



                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                    DataTable dtCorpDetail = new DataTable();
                    dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntityJobDesrp.Cancel_Reason = objCommon.CancelReason();

                            objBusinessJobDesrp.CancelJobDesrp(objEntityJobDesrp);
                            if (HiddenSearchField.Value == "")
                            {
                                Response.Redirect("gen_Job_Description_Master_List.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("gen_Job_Description_Master_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                            }

                        }
                        else
                        {



                            //  clsBusinessLayerEmployeeSponsor objBusinessLayerSponsor = new clsBusinessLayerEmployeeSponsor();
                            DataTable dtContract = new DataTable();
                            //dtContract = objBusinessLayerSponsor.ReadEmployeeSponsorBy_search(objEntitySpnsrMstr);

                            dtContract = objBusinessJobDesrp.ReadJobDesList(objEntityJobDesrp);

                            string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall);
                            //Write to divReport
                            divReport.InnerHtml = strHtm;

                            hiddenRsnid.Value = strId;


                        }

                    }



                }
                else
                {
                    //to view

                    if (HiddenSearchField.Value == "")
                    {
                        objEntityJobDesrp.DivId = 0;
                        objEntityJobDesrp.Deprt_Id = 0;
                        objEntityJobDesrp.Cancel_Status = 0;
                    }
                    else
                    {
                        string strHidden = "";
                        strHidden = HiddenSearchField.Value;

                        string[] strSearchFields = strHidden.Split(',');
                        string strddlDivision = strSearchFields[0];
                        string strDeprtmnt = strSearchFields[1];
                        string strCbxStatus = strSearchFields[2];

                        if (strddlDivision != null && strddlDivision != "")
                        {
                            if (ddlDivision.Items.FindByValue(strddlDivision) != null)
                            {
                                if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                                {
                                    ddlDivision.Items.FindByValue(strddlDivision).Selected = true;
                                    objEntityJobDesrp.DivId = Convert.ToInt32(strddlDivision);
                                }
                            }
                        }


                        if (strDeprtmnt != null && strDeprtmnt != "")
                        {
                            if (ddlDep.Items.FindByValue(strDeprtmnt) != null)
                            {
                                if (ddlDep.SelectedItem.Value != "--SELECT DEPARTMENT--")
                                {
                                    ddlDep.Items.FindByValue(strDeprtmnt).Selected = true;
                                    objEntityJobDesrp.Deprt_Id = Convert.ToInt32(strDeprtmnt);
                                }
                            }
                        }
                        if (strCbxStatus == "1")
                        {
                            cbxCnclStatus.Checked = true;
                           // objEntityJobDesrp.Cancel_Status = 1;
                        }
                        else
                        {
                            cbxCnclStatus.Checked = false;
                            //objEntityJobDesrp.Cancel_Status = 0;
                        }

                        objEntityJobDesrp.Cancel_Status = Convert.ToInt32(strCbxStatus);
                    }
                    objEntityJobDesrp.User_Id = intUserId;

                    DataTable dtContract = new DataTable();
                    dtContract = objBusinessJobDesrp.ReadJobDesList(objEntityJobDesrp);

                    string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall);
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
    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        int intReCallForTAble = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

            if (intCnclUsrId != 0)
            {
                intReCallForTAble = 1;
            }

        }

     //   strHtml += "<th class=\"thT\" style=\"width:6%;text-align: left; word-wrap:break-word;\">SL#</th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
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
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">DIVISION</th>";
            }


        }
        strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: CENTER; word-wrap:break-word;\"></th>";
        //strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">STATUS</th>";

        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (intReCallForTAble == 0)
            {

                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            }
            else
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
            }
        }
        if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (intReCallForTAble == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">CANCEL</th>";
            }
        }

        //if (intReCallForTAble == 1)
        //{
        //    if (intEnableRecall == 1)
        //    {
        //        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">RE-CALL</th>";
        //    }
        //}


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int count = 1;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
           
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";
           // strHtml += "<td class=\"tdT\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count.ToString() + "</td>";
            count++;

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                }

                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["DEPARTMENT"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["DIVISION"].ToString() + "</td>";
                }

            }
         


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"VIEW\" onclick=\"return JobDescrpId('" + Id + "');\" /></td>";

          //  strStatusMode = dt.Rows[intRowBodyCount][4].ToString();
          

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {


                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                          " href=\"gen_Job_Description_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";




                }

                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                     " href=\"gen_Job_Description_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                }
            }
            if (intReCallForTAble == 0)
            {
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (intCnclUsrId == 0)
                    {
                        if (intCancTransaction == 0)
                        {
                            if (HiddenSearchField.Value == "")
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" onclick='return CancelAlert(this.href);' " +
                                 " href=\"gen_Job_Description_Master_List.aspx?canId=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" onclick='return CancelAlert(this.href);' " +
                               " href=\"gen_Job_Description_Master_List.aspx?canId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                        }
                        else
                        {

                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelNotPossible();' >"
                                    + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                        }



                    }
                    else
                    {

                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                    }
                }
            }

           
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    public void Corp_DivisionLoad()
    {
        clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDesrp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobDesrp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobDesrp.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBusinessJobDesrp.ReadDivision(objEntityJobDesrp);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlDivision.DataSource = dtSubConrt;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();

        }
        // DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");

        // ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }
    public void Corp_DepartmentLoad()  //emp25
    {
        clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDesrp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobDesrp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobDesrp.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBusinessJobDesrp.ReadDepartment(objEntityJobDesrp);
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

        clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();



        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDesrp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityJobDesrp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            objEntityJobDesrp.User_Id= Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (HiddenSearchField.Value == "")
        {
            objEntityJobDesrp.DivId = 0;
            objEntityJobDesrp.Deprt_Id = 0;
            objEntityJobDesrp.Cancel_Status = 0;
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;

            string[] strSearchFields = strHidden.Split(',');
            string strddlDivision = strSearchFields[0];
            string strDeprtmnt = strSearchFields[1];
            string strCbxStatus = strSearchFields[2];

         if (strddlDivision != null && strddlDivision != "")
                        {
                            if (ddlDivision.Items.FindByValue(strddlDivision) != null)
                            {
                                if (ddlDivision.SelectedItem.Value != "--SELECT DIVISION--")
                                {
                                    ddlDivision.Items.FindByValue(strddlDivision).Selected = true;
                                    objEntityJobDesrp.DivId = Convert.ToInt32(strddlDivision);
                                }
                            }
                        }


                        if (strDeprtmnt != null && strDeprtmnt != "")
                        {
                            if (ddlDep.Items.FindByValue(strDeprtmnt) != null)
                            {
                                if (ddlDep.SelectedItem.Value != "--SELECT DEPARTMENT--")
                                {
                                    ddlDep.Items.FindByValue(strDeprtmnt).Selected = true;
                                    objEntityJobDesrp.Deprt_Id = Convert.ToInt32(strDeprtmnt);
                                }
                            }
                        }
                        if (strCbxStatus == "1")
                        {
                            cbxCnclStatus.Checked = true;
                           // objEntityJobDesrp.Cancel_Status = 1;
                        }
                        else
                        {
                            cbxCnclStatus.Checked = false;
                            //objEntityJobDesrp.Cancel_Status = 0;
                        }

                        objEntityJobDesrp.Cancel_Status = Convert.ToInt32(strCbxStatus);
                    }
                    objEntityJobDesrp.User_Id = intUserId;

                    DataTable dtContract = new DataTable();
                    dtContract = objBusinessJobDesrp.ReadJobDesList(objEntityJobDesrp);

                


        int  intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
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

        intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
        DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
        if (dtCancelRecall.Rows.Count > 0)
        {
            intEnableRecall = 1;
        }
        else
        {
            intEnableRecall = 0;
        }
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Job_Description);
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
        }

        string strHtm = ConvertDataTableToHTML(dtContract, intEnableModify, intEnableCancel, intEnableRecall);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {

        //Creating objects for business layer
       

        clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();


        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityJobDesrp.JobDescrpId= Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityJobDesrp.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityJobDesrp.D_Date= System.DateTime.Now;

            objEntityJobDesrp.Cancel_Reason = txtCnclReason.Text.Trim();
            objBusinessJobDesrp.CancelJobDesrp(objEntityJobDesrp);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Job_Description_Master_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Job_Description_Master_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }


    protected void ddlDep_SelectedIndexChanged(object sender, EventArgs e)     //emp25
    {

        clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDesrp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobDesrp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobDesrp.User_Id = Convert.ToInt32(Session["USERID"]);
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
            objEntityJobDesrp.Deprt_Id = Dept;
            DataTable dtDivision = objBusinessJobDesrp.ReadDivision(objEntityJobDesrp);
            ddlDivision.Items.Clear();
            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
            if (dtDivision.Rows.Count > 0)
            {
                ddlDivision.Items.Clear();
                ddlDivision.DataSource = dtDivision;


                ddlDivision.DataValueField = "CPRDIV_ID";
                ddlDivision.DataTextField = "CPRDIV_NAME";

                ddlDivision.DataBind();
                ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
            }

        }
    }
}