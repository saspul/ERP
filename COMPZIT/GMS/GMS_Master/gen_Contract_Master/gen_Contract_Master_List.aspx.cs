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

using System.Net.Mail;
using System.Collections.Generic;
using EL_Compzit;
using HashingUtility;
using System.IO;
// CREATED BY:EVM-0005
// CREATED DATE:7/1/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class GMS_GMS_Master_gen_Contract_Master_gen_Contract_Master_List : System.Web.UI.Page
{
    int FLAG = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            ContractCategoryLoad();
            ContractorLoad();
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
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Contract_Master);
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

                //Creating objects for business layer
                classBusinessLayerContractMaster objBusinessLayerContract = new classBusinessLayerContractMaster();
                classEntityLayerContractMaster objEntityContract = new classEntityLayerContractMaster();

                if (Session["USERID"] != null)
                {
                    objEntityContract.User_Id = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityContract.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityContract.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
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
                    string strddlStatus = strSearchFields[0];
                    string strCbxStatus = strSearchFields[1];
                    string strContractor = strSearchFields[2];
                    string strCntrctrType = strSearchFields[3];


                    if (strContractor != null && strContractor != "")
                    {
                        if (ddlContractor.Items.FindByValue(strContractor) != null)
                        {
                            ddlContractor.Items.FindByValue(strContractor).Selected = true;
                        }
                    }

                    if (strCntrctrType != null && strCntrctrType != "")
                    {
                        if (ddlContrctrType.Items.FindByValue(strCntrctrType) != null)
                        {
                            ddlContrctrType.Items.FindByValue(strCntrctrType).Selected = true;
                        }
                    }

                    if (strddlStatus != null && strddlStatus != "")
                    {
                        if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                        {
                            ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
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
                //when recalled
                if (Request.QueryString["ReId"] != null)
                {
                    string strRandomMixedId = Request.QueryString["ReId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityContract.CntrctId = Convert.ToInt32(strId);
                    objEntityContract.User_Id = intUserId;

                    objEntityContract.D_Date = System.DateTime.Now;

                    DataTable dtContractDetail = new DataTable();
                    dtContractDetail = objBusinessLayerContract.ReadContractById(objEntityContract);
                    string strNameCount = "0";
                    string strCodeCount="0";
                    if (dtContractDetail.Rows.Count > 0)
                    {
                        objEntityContract.Sub_Cntrct_Name = dtContractDetail.Rows[0]["CNTRCT_NAME"].ToString();
                        objEntityContract.Sub_CntrctCode = dtContractDetail.Rows[0]["CNTRCT_CODE"].ToString();
                    }
                    strNameCount = objBusinessLayerContract.CheckContractName(objEntityContract);
                    strCodeCount= objBusinessLayerContract.CheckContractCode(objEntityContract);
                    if (strNameCount == "0"&&strCodeCount=="0")
                    {
                        objBusinessLayerContract.ReCallContract(objEntityContract);
                        if (HiddenSearchField.Value == "")
                        {
                            Response.Redirect("gen_Contract_Master_List.aspx?InsUpd=Recl");
                        }
                        else
                        {
                            Response.Redirect("gen_Contract_Master_List.aspx?InsUpd=Recl&Srch=" + this.HiddenSearchField.Value);
                        }
                    }
                    else
                    {
                        if(strNameCount!="0")
                        {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                        }
                        else if(strCodeCount!="0")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
                        }

                    }


                }

                if (Request.QueryString["Id"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntityContract.CntrctId = Convert.ToInt32(strId);
                    objEntityContract.User_Id = intUserId;

                    objEntityContract.D_Date = System.DateTime.Now;



                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                    DataTable dtCorpDetail = new DataTable();
                    dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntityContract.Cancel_reason = objCommon.CancelReason();

                            objBusinessLayerContract.CancelContract(objEntityContract);
                            if (HiddenSearchField.Value == "")
                            {
                                Response.Redirect("gen_Contract_Master_List.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("gen_Contract_Master_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                            }

                        }
                        else
                        {




                            if (HiddenSearchField.Value == "")
                            {
                                objEntityContract.Contract_Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                                objEntityContract.CntrctId = 0;
                                objEntityContract.CntrctCatId = 0;
                                objEntityContract.Cancel_Status = 0;
                            }
                            else
                            {
                                string strHidden = "";
                                strHidden = HiddenSearchField.Value;

                    string[] strSearchFields = strHidden.Split(',');
                    string strddlStatus = strSearchFields[0];
                    string strCbxStatus = strSearchFields[1];
                    string strContractor = strSearchFields[2];
                    string strCntrctrType = strSearchFields[3];


                    if (strContractor != "")
                    {
                        if (ddlContractor.Items.FindByValue(strContractor) != null)
                        {
                            ddlContractor.Items.FindByValue(strContractor).Selected = true;
                            objEntityContract.SubCntrctrId=Convert.ToInt32(strContractor);
                        }
                    }

                    if (strCntrctrType != "")
                    {
                        if (ddlContrctrType.Items.FindByValue(strCntrctrType) != null)
                        {
                            ddlContrctrType.Items.FindByValue(strCntrctrType).Selected = true;
                            objEntityContract.CntrctCatId=Convert.ToInt32(strCntrctrType);
                        }
                    }

                    if (strddlStatus != null && strddlStatus != "")
                    {
                        if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                        {
                            ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                            objEntityContract.Contract_Status=Convert.ToInt32(strddlStatus);
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
                                objEntityContract.Cancel_Status = Convert.ToInt32(strCbxStatus);
                            }
                            DataTable dtContract = new DataTable();
                            dtContract = objBusinessLayerContract.ReadContractList(objEntityContract);

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
                                objEntityContract.Contract_Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                                objEntityContract.CntrctId = 0;
                                objEntityContract.CntrctCatId = 0;
                                objEntityContract.Cancel_Status = 0;
                            }
                            else
                            {
                                string strHidden = "";
                                strHidden = HiddenSearchField.Value;

                    string[] strSearchFields = strHidden.Split(',');
                    string strddlStatus = strSearchFields[0];
                    string strCbxStatus = strSearchFields[1];
                    string strContractor = strSearchFields[2];
                    string strCntrctrType = strSearchFields[3];


                    if (strContractor != "")
                    {
                        if (ddlContractor.Items.FindByValue(strContractor) != null)
                        {
                            ddlContractor.Items.FindByValue(strContractor).Selected = true;
                            objEntityContract.SubCntrctrId=Convert.ToInt32(strContractor);
                        }
                    }

                    if (strCntrctrType != "")
                    {
                        if (ddlContrctrType.Items.FindByValue(strCntrctrType) != null)
                        {
                            ddlContrctrType.Items.FindByValue(strCntrctrType).Selected = true;
                            objEntityContract.CntrctCatId=Convert.ToInt32(strCntrctrType);
                        }
                    }

                    if (strddlStatus != null && strddlStatus != "")
                    {
                        if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                        {
                            ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                            objEntityContract.Contract_Status=Convert.ToInt32(strddlStatus);
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
                                objEntityContract.Cancel_Status = Convert.ToInt32(strCbxStatus);
                            }
                    objEntityContract.User_Id = intUserId;
                    DataTable dtContract = new DataTable();
                    dtContract = objBusinessLayerContract.ReadContractList(objEntityContract);

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
                        else if (strInsUpd == "Recl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRecall", "SuccessRecall();", true);
                        }
                        else if (strInsUpd == "StsCh")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessStatusChange", "SuccessStatusChange();", true);
                        }
                    }
                }

            }
        }
    }

    public void ContractCategoryLoad()
    {
        classBusinessLayerContractMaster ObjBusinessContract = new classBusinessLayerContractMaster();
        classEntityLayerContractMaster objEntityCntrct = new classEntityLayerContractMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCntrct.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityCntrct.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
            //neethu
        if (Session["USERID"] != null)
        {
            objEntityCntrct.User_Id= Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //neethu
        DataTable dtContract = ObjBusinessContract.ReadContractCategory(objEntityCntrct);
        if (dtContract.Rows.Count > 0)
        {
            ddlContrctrType.DataSource = dtContract;
            ddlContrctrType.DataTextField = "CNTRCTYPE_NAME";
            ddlContrctrType.DataValueField = "CNTRCTYPE_ID";
            ddlContrctrType.DataBind();
            ddlContrctrType.Items.Insert(0, "--SELECT--");
        }


    }
    public void ContractorLoad()
    {
        classBusinessLayerContractMaster ObjBusinessContract = new classBusinessLayerContractMaster();
        classEntityLayerContractMaster objEntityCntrct = new classEntityLayerContractMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCntrct.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityCntrct.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ////neethu
        //if (Session["USERID"] != null)
        //{
        //    objEntityCntrct.User_Id = Convert.ToInt32(Session["USERID"]);

        //}
        //else if (Session["USERID"] == null)
        //{
        //    Response.Redirect("/Default.aspx");
        //}
        ////neethu
        DataTable dtExistingCustomer = ObjBusinessContract.ReadContractor(objEntityCntrct);
        if (dtExistingCustomer.Rows.Count > 0)
        {
            ddlContractor.DataSource = dtExistingCustomer;
            ddlContractor.DataTextField = "CSTMR_NAME";
            ddlContractor.DataValueField = "CSTMR_ID";
            ddlContractor.DataBind();
            ddlContractor.Items.Insert(0, "--SELECT--");
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


        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:22%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:22%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

               else if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"thT\"  style=\"width:22%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
              else  if (intColumnHeaderCount == 4)
                {
                    strHtml += "<th class=\"thT\"  style=\"width:22%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
           
       

        }
        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">STATUS</th>";

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
        if (intReCallForTAble == 0)
        {
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">CANCEL</th>";
            }
        }
        if (intReCallForTAble == 1)
        {
            if (intEnableRecall == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">RE-CALL</th>";
            }
        }


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strStatusMode = "";
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:34%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                  else  if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                  else  if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
               

            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            strStatusMode = dt.Rows[intRowBodyCount][5].ToString();
            if (intCnclUsrId == 0)
            {
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (strStatusMode == "ACTIVE")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Inactive\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "');\" >" +
                            "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Active\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "');\" >" +
                          "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                    }
                }
                else
                {
                    if (strStatusMode == "ACTIVE")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Inactive\" >" +
                            "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Active\" >" +
                          "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                    }
                }

            }
            else
            {
                if (strStatusMode == "ACTIVE")
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Active\" >" +
                        "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Inactive\" >" +
                      "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                }
            }

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {


                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                          " href=\"gen_Contract_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";




                }

                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                     " href=\"gen_Contract_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


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
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelAlert(this.href);' " +
                                 " href=\"gen_Contract_Master_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Cancel\" onclick='return CancelAlert(this.href);' " +
                               " href=\"gen_Contract_Master_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
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
            if (intReCallForTAble == 1)
            {
                if (intEnableRecall == 1)
                {
                    if (intCnclUsrId == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                    }
                    else
                    {
                        if (HiddenSearchField.Value == "")
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                 " href=\"gen_Contract_Master_List.aspx?ReId=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                 " href=\"gen_Contract_Master_List.aspx?ReId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";

                        }
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
    //for creating HTML Title
    private string SetTitle(string size, string value)
    {

        return "<h" + size + "><p align=center>" + value + "</p align></h" + size + ">";

    }

    protected void btnRsnSave_Click(object sender, EventArgs e)
    {

        //Creating objects for business layer
        classBusinessLayerContractMaster objBusinessLayerContract = new classBusinessLayerContractMaster();
        classEntityLayerContractMaster objEntityContract = new classEntityLayerContractMaster();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityContract.CntrctId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityContract.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityContract.D_Date = System.DateTime.Now;

            objEntityContract.Cancel_reason = txtCnclReason.Text.Trim();
            objBusinessLayerContract.CancelContract(objEntityContract);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Contract_Master_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Contract_Master_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }

   // at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        classBusinessLayerContractMaster objBusinessLayerContract = new classBusinessLayerContractMaster();
        classEntityLayerContractMaster objEntityContract = new classEntityLayerContractMaster();

        objEntityContract.Contract_Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        if (ddlContractor.SelectedItem.Value.ToString() != "--SELECT--")
        {
        objEntityContract.SubCntrctrId = Convert.ToInt32(ddlContractor.SelectedItem.Value);
        }
        else
        {
            objEntityContract.SubCntrctrId = 0;
        }
        if (ddlContrctrType.SelectedItem.Value.ToString() != "--SELECT--")
        {
            objEntityContract.CntrctCatId = Convert.ToInt32(ddlContrctrType.SelectedItem.Value);
        }
        else
        {
            objEntityContract.CntrctCatId = 0;
        }
        if (cbxCnclStatus.Checked == true)
            objEntityContract.Cancel_Status = 1;
        else
            objEntityContract.Cancel_Status = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityContract.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityContract.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ////neethu
        if (Session["USERID"] != null)
        {
            objEntityContract.User_Id=Convert.ToInt32(Session["USERID"]);
            //objEntityCntrct.User_Id = 

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ////neethu

        DataTable dtBrnd = new DataTable();

        dtBrnd = objBusinessLayerContract.ReadContractList(objEntityContract);


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
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Contract_Master);
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

        string strHtm = ConvertDataTableToHTML(dtBrnd, intEnableModify, intEnableCancel, intEnableRecall);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }


    [WebMethod]
    public static string ChangeContractStatus(int strCatId, string strStatus)
    {

        classBusinessLayerContractMaster objBusinessLayerContract = new classBusinessLayerContractMaster();
        classEntityLayerContractMaster objEntityContract = new classEntityLayerContractMaster();
        string strRet = "success";

        if (strStatus == "ACTIVE")
        {
            objEntityContract.Contract_Status = 0;
        }
        else
        {
            objEntityContract.Contract_Status = 1;
        }
        objEntityContract.CntrctId = strCatId;
        try
        {
            objBusinessLayerContract.ChangeContractStatus(objEntityContract);
        }
        catch
        {
            strRet = "failed";
        }
        return strRet;
    }

    protected void btnRsnMail_Click(object sender, EventArgs e)
    {
        MailSendingChking();

    }
    public bool MailSendingChking()
    {

        string strServerPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        string strCommonPath = "ServiceError\\GMS_Mail.txt";
        string strFilePath = strServerPath + strCommonPath;

        //if any exception on the time of mail fetching
        if (File.Exists(strFilePath))
        {
            File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
            File.AppendAllText(strFilePath, "Mail Send Start");
        }
        try
        {

            try
            {
                File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                File.AppendAllText(strFilePath, "in");

                clsBusiness_Template_Mail_Service objBusnssTemMailServce1 = new clsBusiness_Template_Mail_Service();
                Entity_Template_Mail_Service EntityTemMailServce1 = new Entity_Template_Mail_Service();
                clsBusinessLayer objBusiness1 = new clsBusinessLayer();
                clsCommonLibrary objCommon1 = new clsCommonLibrary();

                DateTime dtDateNow1 = DateTime.Now;
                string strCurrentDate1 = objBusiness1.LoadCurrentDateInString();

                File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                File.AppendAllText(strFilePath, strCurrentDate1);

                DateTime dateCurrntdte1 = objCommon1.textToDateTime(strCurrentDate1);

                DateTime dateRfqCloseDate1 = DateTime.MinValue;
                DataTable dtReqstGuarnteedetails1 = objBusnssTemMailServce1.ReqstGuarnteedetails(EntityTemMailServce1);
            }
            catch (Exception ex)
            {

                File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                File.AppendAllText(strFilePath, ex + "inside catch");
            }







            clsBusiness_Template_Mail_Service objBusnssTemMailServce = new clsBusiness_Template_Mail_Service();
            Entity_Template_Mail_Service EntityTemMailServce = new Entity_Template_Mail_Service();
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            DateTime dtDateNow = DateTime.Now;
            string strCurrentDate = objBusiness.LoadCurrentDateInString();
            DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);

            DateTime dateRfqCloseDate = DateTime.MinValue;
            DataTable dtReqstGuarnteedetails = objBusnssTemMailServce.ReqstGuarnteedetails(EntityTemMailServce);




            if (dtReqstGuarnteedetails.Rows.Count > 0)
            {
                foreach (DataRow rowrqst in dtReqstGuarnteedetails.Rows)
                {
                    dateRfqCloseDate = objCommon.textToDateTime(rowrqst["RFQ_CLOSING_DATE"].ToString());
                    if (dtDateNow >= dateRfqCloseDate)
                    {
                        EntityTemMailServce.ReqstGrntId = Convert.ToInt32(rowrqst["RFQ_ID"].ToString());
                        objBusnssTemMailServce.UpdateRfqCloseDate(EntityTemMailServce);
                    }
                }
            }


            //hiddenCurrentDate.Value = strCurrentDate;
            DataTable dtBankGuaranteeDtls = objBusnssTemMailServce.ReadBankDetails(EntityTemMailServce);
            int intTimeDiff = 0, intdays = 0, inthour = 0, intSectId = 0;
            DateTime dtdatehourDiff;
            //DateTime dtDateNow = DateTime.Now;


            if (dtBankGuaranteeDtls.Rows.Count > 0)
            {
                foreach (DataRow row in dtBankGuaranteeDtls.Rows)
                {
                    DateTime dateExpiredte = DateTime.MinValue;
                    if (row["GUARANTEE_EXP_DATE"].ToString() != "")
                    {
                        dateExpiredte = objCommon.textToDateTime(row["GUARANTEE_EXP_DATE"].ToString());
                    }
                    DateTime dateGuarnteeDate = new DateTime();
                    if (row["GUARANTEE_DATE"].ToString() != "")
                    {
                        dateGuarnteeDate = objCommon.textToDateTime(row["GUARANTEE_DATE"].ToString());
                    }
                    int inttempltAlertOptn = Convert.ToInt32(row["GRNT_TMALRT_OPT"].ToString());
                    EntityTemMailServce.GuaranteeId = Convert.ToInt32(row["GUARANTEE_ID"].ToString());
                    int intCorpId = 0;
                    intCorpId = Convert.ToInt32(row["CORPRT_ID"].ToString());
                    EntityTemMailServce.CorpOffice_Id = intCorpId;
                    DataTable dtGR = objBusnssTemMailServce.ReadGuranteeById(EntityTemMailServce);
                    EntityTemMailServce.TempAlertId = Convert.ToInt32(row["GRNT_TMALRT_ID"].ToString());

                    int intGurntId = 0, intTemAlertId = 0, GuarntypeChk = 0;
                    string strRefNo = "", strGurantTyp = "", strGuaranteeNo = "";
                    strGurantTyp = row["GUARNTYPE_ID"].ToString();
                    if (strGurantTyp == "101")
                    {
                        GuarntypeChk = 1;
                    }
                    strGuaranteeNo = row["GUARANTEE_NUMBER"].ToString();
                    strRefNo = row["GUARANTEE_REF_NUM"].ToString();
                    intGurntId = Convert.ToInt32(row["GUARANTEE_ID"].ToString());
                    intTemAlertId = Convert.ToInt32(row["GRNT_TMALRT_ID"].ToString());
                    if (row["GRTY_TMDTL_DASHBOARD"].ToString() != "0" || row["GRTY_TMDTL_EMAIL"].ToString() != "0")
                    {

                        if (row["GRTY_TMDTL_EMAIL"].ToString() != "0")
                        {

                            DataTable dtMailServce;
                            string MailAddress = "";
                            // MailAddress = "ajinks@volviar.com";
                            //TempMailSend(MailAddress);TemAlertId

                            string strMailSndNot = row["GRNT_MAILSEND_STS"].ToString();
                            if (inttempltAlertOptn != 3)
                            {
                                intSectId = Convert.ToInt32(row["GRNT_NTFY_ID"].ToString());
                                EntityTemMailServce.EmployeId = intSectId;
                            }

                            if (row["GRTY_TMDTL_PERIOD"].ToString() == "1")
                            {

                                if (GuarntypeChk != 1)
                                {
                                    inthour = Convert.ToInt32(row["GRTY_TMDTL_COUNT"].ToString());
                                    dtdatehourDiff = dateExpiredte.AddHours(-(inthour));


                                    if (dtDateNow >= dtdatehourDiff)
                                    {
                                        if (strMailSndNot == "0")
                                        {

                                            if (inttempltAlertOptn == 0)
                                            {

                                                dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                }
                                            }
                                            else if (inttempltAlertOptn == 1)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    foreach (DataRow roww in dtMailServce.Rows)
                                                    {

                                                        MailAddress = roww["USR_EMAIL"].ToString();

                                                        //MailAddress = str;
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                    }
                                                }


                                            }
                                            else if (inttempltAlertOptn == 2)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                            }
                                            else if (inttempltAlertOptn == 3)
                                            {
                                                string strMailAddrs = "";
                                                dtMailServce = objBusnssTemMailServce.ReadMailAddress(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    strMailAddrs = dtMailServce.Rows[0]["GRNT_TMALRT_EMAIL"].ToString();
                                                    string[] strAddrs = strMailAddrs.Split(',');
                                                    foreach (string str in strAddrs)
                                                    {
                                                        MailAddress = str;
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    inthour = Convert.ToInt32(row["GRTY_TMDTL_COUNT"].ToString());
                                    dtdatehourDiff = dateGuarnteeDate.AddHours((inthour));
                                    if (dtDateNow >= dtdatehourDiff)
                                    {
                                        if (strMailSndNot == "0")
                                        {

                                            if (inttempltAlertOptn == 0)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                }
                                            }
                                            else if (inttempltAlertOptn == 1)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    foreach (DataRow roww in dtMailServce.Rows)
                                                    {


                                                        MailAddress = roww["USR_EMAIL"].ToString();

                                                        //MailAddress = str;
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                    }
                                                }


                                            }
                                            else if (inttempltAlertOptn == 2)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                            }
                                            else if (inttempltAlertOptn == 3)
                                            {
                                                string strMailAddrs = "";
                                                dtMailServce = objBusnssTemMailServce.ReadMailAddress(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    strMailAddrs = dtMailServce.Rows[0]["GRNT_TMALRT_EMAIL"].ToString();
                                                    string[] strAddrs = strMailAddrs.Split(',');
                                                    foreach (string str in strAddrs)
                                                    {
                                                        MailAddress = str;
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                            else if (row["GRTY_TMDTL_PERIOD"].ToString() == "2")
                            {
                                if (GuarntypeChk != 1)
                                {
                                    intdays = Convert.ToInt32(row["GRTY_TMDTL_COUNT"].ToString());
                                    if (row["GUARANTEE_EXP_DATE"].ToString() != "")
                                    {
                                        EntityTemMailServce.ExpireDate = objCommon.textToDateTime(row["GUARANTEE_EXP_DATE"].ToString());
                                    }


                                    //  intTimeDiff = Math.Abs(Convert.ToInt32(dateExpiredte.ToShortTimeString()) - Convert.ToInt32(dateCurrntdte.ToShortTimeString()));
                                    intTimeDiff = Convert.ToInt32((dateExpiredte - dateCurrntdte).TotalDays);
                                    if (Math.Abs(intdays) >= Math.Abs(intTimeDiff))
                                    {
                                        if (strMailSndNot == "0")
                                        {

                                            if (inttempltAlertOptn == 0)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                }
                                            }
                                            else if (inttempltAlertOptn == 1)
                                            {


                                                dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    foreach (DataRow roww in dtMailServce.Rows)
                                                    {


                                                        MailAddress = roww["USR_EMAIL"].ToString();

                                                        //MailAddress = str;
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                    }
                                                }

                                            }
                                            else if (inttempltAlertOptn == 2)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                            }
                                            else if (inttempltAlertOptn == 3)
                                            {
                                                //string strMailAddrs = "";
                                                string strMailAddrs = "";
                                                dtMailServce = objBusnssTemMailServce.ReadMailAddress(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    strMailAddrs = dtMailServce.Rows[0]["GRNT_TMALRT_EMAIL"].ToString();
                                                    string[] strAddrs = strMailAddrs.Split(',');
                                                    foreach (string str in strAddrs)
                                                    {
                                                        MailAddress = str;
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                            }


                                        }


                                    }
                                }
                                else
                                {
                                    intdays = Convert.ToInt32(row["GRTY_TMDTL_COUNT"].ToString());
                                    intdays++;
                                    DateTime dateExpGurntDate = dateGuarnteeDate.AddDays(intdays);
                                    if (dtDateNow >= dateExpGurntDate)
                                    {

                                        if (strMailSndNot == "0")
                                        {

                                            if (inttempltAlertOptn == 0)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                }
                                            }
                                            else if (inttempltAlertOptn == 1)
                                            {


                                                dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    foreach (DataRow roww in dtMailServce.Rows)
                                                    {


                                                        MailAddress = roww["USR_EMAIL"].ToString();

                                                        //MailAddress = str;
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                    }
                                                }

                                            }
                                            else if (inttempltAlertOptn == 2)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                            }
                                            else if (inttempltAlertOptn == 3)
                                            {
                                                //string strMailAddrs = "";
                                                string strMailAddrs = "";
                                                dtMailServce = objBusnssTemMailServce.ReadMailAddress(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    strMailAddrs = dtMailServce.Rows[0]["GRNT_TMALRT_EMAIL"].ToString();
                                                    string[] strAddrs = strMailAddrs.Split(',');
                                                    foreach (string str in strAddrs)
                                                    {
                                                        MailAddress = str;
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                            }

                                            //if any exception on the time of mail fetching
                                            if (File.Exists(strFilePath))
                                            {
                                                File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                                                File.AppendAllText(strFilePath, "PASS");
                                            }
                                        }


                                    }

                                }
                            }

                        }

                    }

                }
            }

            //Insurance Mail 

            DataTable dtInsuranceDtls = objBusnssTemMailServce.ReadInsuranceDetails(EntityTemMailServce);
            int intTimeDiff_Insu = 0, intdays_Insu = 0, inthour_insu = 0, intSectId_Insu = 0;
            DateTime dtdatehourDiff_Insu;

            if (dtInsuranceDtls.Rows.Count > 0)
            {
                foreach (DataRow row in dtInsuranceDtls.Rows)
                {
                    DateTime dateExpiredte = DateTime.MinValue;
                    if (row["INSURANCE_EXP_DATE"].ToString() != "")
                    {
                        dateExpiredte = objCommon.textToDateTime(row["INSURANCE_EXP_DATE"].ToString());
                    }
                    DateTime dateGuarnteeDate = new DateTime();
                    if (row["INSURANCE_DATE"].ToString() != "")
                    {
                        dateGuarnteeDate = objCommon.textToDateTime(row["INSURANCE_DATE"].ToString());
                    }
                    int inttempltAlertOptn = Convert.ToInt32(row["INSRNC_TMPALRT_OPT"].ToString());
                    EntityTemMailServce.InsuranceID = Convert.ToInt32(row["INSURANCE_ID"].ToString());
                    int intCorpId = 0;
                    intCorpId = Convert.ToInt32(row["CORPRT_ID"].ToString());
                    EntityTemMailServce.CorpOffice_Id = intCorpId;
                    DataTable dtGR = objBusnssTemMailServce.ReadInsuranceByID(EntityTemMailServce);
                    EntityTemMailServce.TempAlertId = Convert.ToInt32(row["INSRNC_TMPALRT_ID"].ToString());

                    int intGurntId = 0, intTemAlertId = 0, GuarntypeChk = 0;
                    string strRefNo = "", strGurantTyp = "", strGuaranteeNo = "";
                    strGurantTyp = row["INSURNCTYPE_ID"].ToString();
                    if (strGurantTyp == "101")
                    {
                        GuarntypeChk = 1;
                    }
                    strGuaranteeNo = row["INSURANCE_NUMBER"].ToString();
                    strRefNo = row["INSURANCE_REF_NUM"].ToString();
                    intGurntId = Convert.ToInt32(row["INSURANCE_ID"].ToString());
                    intTemAlertId = Convert.ToInt32(row["INSRNC_TMPALRT_ID"].ToString());
                    if (row["INSRNC_TMPDTL_DASHBOARD"].ToString() != "0" || row["INSRNC_TMPDTL_EMAIL"].ToString() != "0")
                    {

                        if (row["INSRNC_TMPDTL_EMAIL"].ToString() != "0")
                        {

                            DataTable dtMailServce;
                            string MailAddress = "";
                            // MailAddress = "ajinks@volviar.com";
                            //Temp_MailSendForInsurance(MailAddress);TemAlertId

                            string strMailSndNot = row["INSRNC_MAILSEND_STS"].ToString();
                            if (inttempltAlertOptn != 3)
                            {
                                intSectId_Insu = Convert.ToInt32(row["INSRNC_NOTIFY_ID"].ToString());
                                EntityTemMailServce.EmployeId = intSectId_Insu;
                            }

                            if (row["INSRNC_TMPDTL_PERIOD"].ToString() == "1")
                            {

                                if (GuarntypeChk != 1)
                                {
                                    inthour_insu = Convert.ToInt32(row["INSRNC_TMPDTL_COUNT"].ToString());
                                    dtdatehourDiff_Insu = dateExpiredte.AddHours(-(inthour_insu));


                                    if (dtDateNow >= dtdatehourDiff_Insu)
                                    {
                                        if (strMailSndNot == "0")
                                        {

                                            if (inttempltAlertOptn == 0)
                                            {

                                                dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                    Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                }
                                            }
                                            else if (inttempltAlertOptn == 1)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    foreach (DataRow roww in dtMailServce.Rows)
                                                    {

                                                        MailAddress = roww["USR_EMAIL"].ToString();

                                                        //MailAddress = str;
                                                        Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                    }
                                                }


                                            }
                                            else if (inttempltAlertOptn == 2)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                            }
                                            else if (inttempltAlertOptn == 3)
                                            {
                                                string strMailAddrs = "";
                                                dtMailServce = objBusnssTemMailServce.ReadMailAddressInsurance(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    strMailAddrs = dtMailServce.Rows[0]["INSRNC_TMPALRT_NTFYEMAILID"].ToString();
                                                    string[] strAddrs = strMailAddrs.Split(',');
                                                    foreach (string str in strAddrs)
                                                    {
                                                        MailAddress = str;
                                                        Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    inthour_insu = Convert.ToInt32(row["INSRNC_TMPDTL_COUNT"].ToString());
                                    dtdatehourDiff_Insu = dateGuarnteeDate.AddHours((inthour_insu));
                                    if (dtDateNow >= dtdatehourDiff_Insu)
                                    {
                                        if (strMailSndNot == "0")
                                        {

                                            if (inttempltAlertOptn == 0)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                    Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                }
                                            }
                                            else if (inttempltAlertOptn == 1)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    foreach (DataRow roww in dtMailServce.Rows)
                                                    {


                                                        MailAddress = roww["USR_EMAIL"].ToString();

                                                        //MailAddress = str;
                                                        Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                    }
                                                }


                                            }
                                            else if (inttempltAlertOptn == 2)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                            }
                                            else if (inttempltAlertOptn == 3)
                                            {
                                                string strMailAddrs = "";
                                                dtMailServce = objBusnssTemMailServce.ReadMailAddressInsurance(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    strMailAddrs = dtMailServce.Rows[0]["INSRNC_TMPALRT_NTFYEMAILID"].ToString();
                                                    string[] strAddrs = strMailAddrs.Split(',');
                                                    foreach (string str in strAddrs)
                                                    {
                                                        MailAddress = str;
                                                        Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                            else if (row["INSRNC_TMPDTL_PERIOD"].ToString() == "2")
                            {
                                if (GuarntypeChk != 1)
                                {
                                    intdays_Insu = Convert.ToInt32(row["INSRNC_TMPDTL_COUNT"].ToString());
                                    if (row["INSURANCE_EXP_DATE"].ToString() != "")
                                    {
                                        EntityTemMailServce.ExpireDate = objCommon.textToDateTime(row["INSURANCE_EXP_DATE"].ToString());
                                    }


                                    //  intTimeDiff_Insu = Math.Abs(Convert.ToInt32(dateExpiredte.ToShortTimeString()) - Convert.ToInt32(dateCurrntdte.ToShortTimeString()));
                                    intTimeDiff_Insu = Convert.ToInt32((dateExpiredte - dateCurrntdte).TotalDays);
                                    if (Math.Abs(intdays_Insu) >= Math.Abs(intTimeDiff_Insu))
                                    {
                                        if (strMailSndNot == "0")
                                        {

                                            if (inttempltAlertOptn == 0)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                    Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                }
                                            }
                                            else if (inttempltAlertOptn == 1)
                                            {


                                                dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    foreach (DataRow roww in dtMailServce.Rows)
                                                    {


                                                        MailAddress = roww["USR_EMAIL"].ToString();

                                                        //MailAddress = str;
                                                        Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                    }
                                                }

                                            }
                                            else if (inttempltAlertOptn == 2)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                            }
                                            else if (inttempltAlertOptn == 3)
                                            {
                                                //string strMailAddrs = "";
                                                string strMailAddrs = "";
                                                dtMailServce = objBusnssTemMailServce.ReadMailAddressInsurance(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    strMailAddrs = dtMailServce.Rows[0]["INSRNC_TMPALRT_NTFYEMAILID"].ToString();
                                                    string[] strAddrs = strMailAddrs.Split(',');
                                                    foreach (string str in strAddrs)
                                                    {
                                                        MailAddress = str;
                                                        Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                            }


                                        }


                                    }
                                }
                                else
                                {
                                    intdays_Insu = Convert.ToInt32(row["INSRNC_TMPDTL_COUNT"].ToString());
                                    intdays_Insu++;
                                    DateTime dateExpGurntDate = dateGuarnteeDate.AddDays(intdays_Insu);
                                    if (dtDateNow >= dateExpGurntDate)
                                    {

                                        if (strMailSndNot == "0")
                                        {

                                            if (inttempltAlertOptn == 0)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                    Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                }
                                            }
                                            else if (inttempltAlertOptn == 1)
                                            {


                                                dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    foreach (DataRow roww in dtMailServce.Rows)
                                                    {


                                                        MailAddress = roww["USR_EMAIL"].ToString();

                                                        //MailAddress = str;
                                                        Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                    }
                                                }

                                            }
                                            else if (inttempltAlertOptn == 2)
                                            {
                                                dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                            }
                                            else if (inttempltAlertOptn == 3)
                                            {
                                                //string strMailAddrs = "";
                                                string strMailAddrs = "";
                                                dtMailServce = objBusnssTemMailServce.ReadMailAddressInsurance(EntityTemMailServce);
                                                if (dtMailServce.Rows.Count > 0)
                                                {
                                                    strMailAddrs = dtMailServce.Rows[0]["INSRNC_TMPALRT_NTFYEMAILID"].ToString();
                                                    string[] strAddrs = strMailAddrs.Split(',');
                                                    foreach (string str in strAddrs)
                                                    {
                                                        MailAddress = str;
                                                        Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                            }

                                            //if any exception on the time of mail fetching
                                            if (File.Exists(strFilePath))
                                            {
                                                File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                                                File.AppendAllText(strFilePath, "PASS");
                                            }
                                        }


                                    }

                                }
                            }

                        }

                    }

                }
            }
            if (File.Exists(strFilePath))
            {
                File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                File.AppendAllText(strFilePath, "inside");
            }




        }
        catch (Exception ex)
        {
            File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
            File.AppendAllText(strFilePath, ex.ToString() + "inside Error");
            File.AppendAllText(strFilePath, Environment.CurrentDirectory.ToString() + "inside11");
            File.AppendAllText(strFilePath, System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "inside22");
        }
        return false;
    }


    private void Temp_MailSendForInsurance(string MailAddress, int intCorpId, int intGurntId, string strRefNo, string strGuaranteeNo, DateTime dateExpiredte, int GuarntypeChk, int intTemAlertId, DataTable dtGR)
    {
        string strServerPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        string strCommonPath = "ServiceError\\GMS_Mail.txt";
        string strFilePath = strServerPath + strCommonPath;
        if (File.Exists(strFilePath))
        {
            File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
            File.AppendAllText(strFilePath, "Mail Sending in progress");
        }


        Entity_Template_Mail_Service EntityTemMailServce = new Entity_Template_Mail_Service();


        EntityTemMailServce.CorpOffice_Id = intCorpId;
        EntityTemMailServce.InsuranceID = intGurntId;
        EntityTemMailServce.TempAlertId = intTemAlertId;
        EntityTemMailServce.MailMOdule = "INSURANCE";

        clsBusiness_Template_Mail_Service objBusnssTemMailServce = new clsBusiness_Template_Mail_Service();

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
        //clsBusinessLayer objBussinessLayer = new clsBusinessLayer();
        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
        MailMessage mail = new MailMessage();
        DataTable dtFromMail = objBusnssTemMailServce.ReadFromMailDetails(EntityTemMailServce);
        DataTable dtUserDetails = new DataTable();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                               clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                                  };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        }

        string g_Ref = "";
        string g_Mode = "";
        string g_Type = "";
        string g_ExDate = "";
        string g_Projct_Ref = "";
        string g_Projct_Name = "";
        string g_Contact_PName = "";
        string g_Cont_PEmail = "";
        string g_Bank_gurn_date = "";
        string g_Cust_SupplierName = "";
        string g_Amount = "";
        string g_CurrencyType = "";
        string g_BankName = "";
        string g_GrnteeNo = "";
        // string g_Per_No = "";
        if (dtGR.Rows.Count > 0)
        {
            /////
            //FOR TRACKING TABLE
            EntityTemMailServce.Organisation_Id = Convert.ToInt32(dtGR.Rows[0]["ORG_ID"].ToString());
            EntityTemMailServce.RefNumber = dtGR.Rows[0]["INSURANCE_REF_NUM"].ToString();

            if (dtGR.Rows[0]["INSURANCE_REF_NUM"].ToString() != "")
            {
                g_Ref = dtGR.Rows[0]["INSURANCE_REF_NUM"].ToString();
            }



            ////////////if (dtGR.Rows[0]["GUANTCAT_NAME"].ToString() != "")
            ////////////{
            ////////////    g_Mode = dtGR.Rows[0]["GUANTCAT_NAME"].ToString();
            ////////////}

            if (dtGR.Rows[0]["INSURNCTYPE_NAME"].ToString() != "")
            {
                g_Type = dtGR.Rows[0]["INSURNCTYPE_NAME"].ToString();
            }
            else
            {
                g_Type = "";
            }
            if (dtGR.Rows[0]["INSURANCE_EXP_DATE"].ToString() != "")
            {
                g_ExDate = dtGR.Rows[0]["INSURANCE_EXP_DATE"].ToString();
            }


            if (dtGR.Rows[0]["PROJECT_REF_NUMBER"].ToString() != "")
            {
                g_Projct_Ref = dtGR.Rows[0]["PROJECT_REF_NUMBER"].ToString();
            }
            else
            {

                g_Projct_Ref = "";
            }

            if (dtGR.Rows[0]["PROJECT_NAME"].ToString() != "")
            {
                g_Projct_Name = dtGR.Rows[0]["PROJECT_NAME"].ToString();
            }
            else
            {

                g_Projct_Name = "";
            }
            if (dtGR.Rows[0]["INSURANCE_PERSON_NAME"].ToString() != "")
            {
                g_Contact_PName = dtGR.Rows[0]["INSURANCE_PERSON_NAME"].ToString();
            }
            else
            {
                g_Contact_PName = "";
            }

            if (dtGR.Rows[0]["INSURANCE_PERSON_EMAIL"].ToString() != "")
            {
                g_Cont_PEmail = dtGR.Rows[0]["INSURANCE_PERSON_EMAIL"].ToString();
            }
            else
            {
                g_Cont_PEmail = "";
            }

            //if (dtGR.Rows[0]["USR_NAME"].ToString() != "")
            //{
            //    g_Per_No = dtGR.Rows[0]["USR_NAME"].ToString();
            //}
            //else
            //{
            //    g_Per_No = "";
            //}
            if (dtGR.Rows[0]["INSURANCE_DATE"].ToString() != "")
            {
                g_Bank_gurn_date = dtGR.Rows[0]["INSURANCE_DATE"].ToString();
            }
            else
            {
                g_Bank_gurn_date = "";
            }
            //Mod by EVM-0012
            //////////////if (dtGR.Rows[0]["CSTMR_NAME"].ToString() != "")
            //////////////{
            //////////////    g_Cust_SupplierName = dtGR.Rows[0]["CSTMR_NAME"].ToString();
            //////////////}
            //////////////else
            //////////////{
            //////////////    g_Cust_SupplierName = "";
            //////////////}
            if (dtGR.Rows[0]["INSURANCE_AMOUNT"].ToString() != "")
            {
                string strAmount = dtGR.Rows[0]["INSURANCE_AMOUNT"].ToString();
                g_Amount = objBusiness.AddCommasForNumberSeperation(strAmount, objEntityCommon);
            }
            else
            {
                g_Amount = "";
            }
            if (dtGR.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
            {
                g_CurrencyType = dtGR.Rows[0]["CRNCMST_ABBRV"].ToString();
            }
            else
            {
                g_CurrencyType = "";
            }
            if (dtGR.Rows[0]["INSURPRVDR_NAME"].ToString() != "")
            {
                g_BankName = dtGR.Rows[0]["INSURPRVDR_NAME"].ToString();
            }
            else
            {
                g_BankName = "";
            }

            if (dtGR.Rows[0]["INSURANCE_NUMBER"].ToString() != "")
            {
                g_GrnteeNo = dtGR.Rows[0]["INSURANCE_NUMBER"].ToString();
            }
            else
            {
                g_GrnteeNo = "";
            }

        }

        string content = "";
        if (GuarntypeChk != 1)
        {
            content = " Dear Sir/Madam,<br/><br/> The below insurance will expire on Date " + g_ExDate + ".";
        }
        else
        {
            content = " Dear Sir/Madam,<br/><br/> The below insurance created on Date " + g_Bank_gurn_date + ".";
        }
        content += "<br/><br/><b><u>Insurance Management System Notification</u></b>";
        //Evm-0012
        //table
        content += "<br/><br/><br/><table>";
        if (g_Cust_SupplierName != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Customer/Supplier&emsp;</th><td>:&emsp;" + g_Cust_SupplierName + "</td></tr>";


        }

        if (g_Amount != "")
        {

            content += "<tr style=\"text-align: left;\"><th>Amount&emsp;</th><td>:&emsp;" + g_Amount + " " + g_CurrencyType + "</td></tr>";
        }


        if (g_BankName != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Insurance provider name&emsp;</th><td>:&emsp;" + g_BankName + "</td></tr>";

        }


        if (g_Ref != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Insurance Ref #&emsp;</th><td>:&emsp;" + g_Ref + "</td></tr>";
        }
        if (g_GrnteeNo != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Insurance Number&emsp;</th><td>:&emsp;" + g_GrnteeNo + "</td></tr>";
        }
        if (g_Mode != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Insurance Mode&emsp;</th><td>:&emsp;" + g_Mode + "</td></tr>";
        }
        if (g_Type != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Insurance Type&emsp;</th><td>:&emsp;" + g_Type + "</td></tr>";
        }
        if (GuarntypeChk != 1)
        {
            if (g_ExDate != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Expiry Date&emsp;</th><td>:&emsp;" + g_ExDate + "</td></tr>";
            }
        }
        if (g_Projct_Ref != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Project Ref&emsp;</th><td>:&emsp;" + g_Projct_Ref + "</td></tr>";
        }
        if (g_Projct_Ref != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Project Name&emsp;</th><td>:&emsp;" + g_Projct_Name + "</td></tr>";
        }
        if (g_Contact_PName != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Contact Person Name&emsp;</th><td>:&emsp;" + g_Contact_PName + "</td></tr>";

        }
        if (g_Cont_PEmail != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Contact Person Email&emsp;</th><td>:&emsp;" + g_Cont_PEmail + "</td></tr>";

        }
        content += "</table>";

        content += "<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>";
        content += "<br/><br/><br/>Best Regards,";
        content += "<br/><font color=\"#0a409b\"><b>Compzit Administrator</b></font><br/><font color=\"#438df8\">Al-Balagh Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>";


        if (dtFromMail.Rows.Count > 0)
        {

            objEntityMail.To_Email_Address = MailAddress;
            objEntityMail.Email_Subject = "INSURANCE EXPIRATION";
            objEntityMail.Email_Content = content;
            objEntityMail.From_Email_Address = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();
            objEntityMail.Out_Service_Name = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
            objEntityMail.Out_Port_Number = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
            objEntityMail.SSL_Status = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
            objEntityMail.Password = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();
            objEntityMail.Signature = dtFromMail.Rows[0]["MLCNFG_SIGNATURE"].ToString();



            List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
            List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();
            try
            {
               // SendMailAsHtml(objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);
              //  objBusnssTemMailServce.UpdateMailChk_Insurance(EntityTemMailServce);


               // EntityTemMailServce.D_Date = DateTime.Now;
               // EntityTemMailServce.FromMailId = objEntityMail.From_Email_Address;
               // EntityTemMailServce.ToMailId = objEntityMail.To_Email_Address;

               // EntityTemMailServce.MailSubject = objEntityMail.Email_Subject;
              //  objBusnssTemMailServce.InsertMailTracking(EntityTemMailServce);

            }
            catch
            {


            }

        }
    }
    private void TempMailSend(string MailAddress, int intCorpId, int intGurntId, string strRefNo, string strGuaranteeNo, DateTime dateExpiredte, int GuarntypeChk, int intTemAlertId, DataTable dtGR)
    {
        string strServerPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        string strCommonPath = "ServiceError\\GMS_Mail.txt";
        string strFilePath = strServerPath + strCommonPath;
        if (File.Exists(strFilePath))
        {
            File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
            File.AppendAllText(strFilePath, "Mail Sending in progress");
        }


        Entity_Template_Mail_Service EntityTemMailServce = new Entity_Template_Mail_Service();


        EntityTemMailServce.CorpOffice_Id = intCorpId;
        EntityTemMailServce.GuaranteeId = intGurntId;
        EntityTemMailServce.TempAlertId = intTemAlertId;
        EntityTemMailServce.MailMOdule = "BANK GUARANTEE";
        clsBusiness_Template_Mail_Service objBusnssTemMailServce = new clsBusiness_Template_Mail_Service();

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
        //clsBusinessLayer objBussinessLayer = new clsBusinessLayer();
        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
        MailMessage mail = new MailMessage();
        DataTable dtFromMail = objBusnssTemMailServce.ReadFromMailDetails(EntityTemMailServce);
        DataTable dtUserDetails = new DataTable();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                               clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                                  };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
        }

        string g_Ref = "";
        string g_Mode = "";
        string g_Type = "";
        string g_ExDate = "";
        string g_Projct_Ref = "";
        string g_Projct_Name = "";
        string g_Contact_PName = "";
        string g_Cont_PEmail = "";
        string g_Bank_gurn_date = "";
        string g_Cust_SupplierName = "";
        string g_Amount = "";
        string g_CurrencyType = "";
        string g_BankName = "";
        string g_GrnteeNo = "";
        // string g_Per_No = "";
        if (dtGR.Rows.Count > 0)
        {
            /////
            //FOR TRACKING TABLE
            EntityTemMailServce.Organisation_Id = Convert.ToInt32(dtGR.Rows[0]["ORG_ID"].ToString());
            EntityTemMailServce.RefNumber = dtGR.Rows[0]["GUARANTEE_REF_NUM"].ToString();

            if (dtGR.Rows[0]["GUARANTEE_REF_NUM"].ToString() != "")
            {
                g_Ref = dtGR.Rows[0]["GUARANTEE_REF_NUM"].ToString();
            }



            if (dtGR.Rows[0]["GUANTCAT_NAME"].ToString() != "")
            {
                g_Mode = dtGR.Rows[0]["GUANTCAT_NAME"].ToString();
            }

            if (dtGR.Rows[0]["GUARNTYPE_NAME"].ToString() != "")
            {
                g_Type = dtGR.Rows[0]["GUARNTYPE_NAME"].ToString();
            }
            else
            {
                g_Type = "";
            }
            if (dtGR.Rows[0]["GUARANTEE_EXP_DATE"].ToString() != "")
            {
                g_ExDate = dtGR.Rows[0]["GUARANTEE_EXP_DATE"].ToString();
            }


            if (dtGR.Rows[0]["PROJECT_REF_NUMBER"].ToString() != "")
            {
                g_Projct_Ref = dtGR.Rows[0]["PROJECT_REF_NUMBER"].ToString();
            }
            else
            {

                g_Projct_Ref = "";
            }

            if (dtGR.Rows[0]["PROJECT_NAME"].ToString() != "")
            {
                g_Projct_Name = dtGR.Rows[0]["PROJECT_NAME"].ToString();
            }
            else
            {

                g_Projct_Name = "";
            }
            if (dtGR.Rows[0]["GUARANTEE_PERSON_NAME"].ToString() != "")
            {
                g_Contact_PName = dtGR.Rows[0]["GUARANTEE_PERSON_NAME"].ToString();
            }
            else
            {
                g_Contact_PName = "";
            }

            if (dtGR.Rows[0]["GUARANTEE_PERSON_EMAIL"].ToString() != "")
            {
                g_Cont_PEmail = dtGR.Rows[0]["GUARANTEE_PERSON_EMAIL"].ToString();
            }
            else
            {
                g_Cont_PEmail = "";
            }

            //if (dtGR.Rows[0]["USR_NAME"].ToString() != "")
            //{
            //    g_Per_No = dtGR.Rows[0]["USR_NAME"].ToString();
            //}
            //else
            //{
            //    g_Per_No = "";
            //}
            if (dtGR.Rows[0]["GUARANTEE_DATE"].ToString() != "")
            {
                g_Bank_gurn_date = dtGR.Rows[0]["GUARANTEE_DATE"].ToString();
            }
            else
            {
                g_Bank_gurn_date = "";
            }
            //Mod by EVM-0012
            if (dtGR.Rows[0]["CSTMR_NAME"].ToString() != "")
            {
                g_Cust_SupplierName = dtGR.Rows[0]["CSTMR_NAME"].ToString();
            }
            else
            {
                g_Cust_SupplierName = "";
            }
            if (dtGR.Rows[0]["GUARANTEE_AMOUNT"].ToString() != "")
            {
                string strAmount = dtGR.Rows[0]["GUARANTEE_AMOUNT"].ToString();
                g_Amount = objBusiness.AddCommasForNumberSeperation(strAmount, objEntityCommon);
            }
            else
            {
                g_Amount = "";
            }
            if (dtGR.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
            {
                g_CurrencyType = dtGR.Rows[0]["CRNCMST_ABBRV"].ToString();
            }
            else
            {
                g_CurrencyType = "";
            }
            if (dtGR.Rows[0]["BANK_NAME"].ToString() != "")
            {
                g_BankName = dtGR.Rows[0]["BANK_NAME"].ToString();
            }
            else
            {
                g_BankName = "";
            }

            if (dtGR.Rows[0]["GUARANTEE_NUMBER"].ToString() != "")
            {
                g_GrnteeNo = dtGR.Rows[0]["GUARANTEE_NUMBER"].ToString();
            }
            else
            {
                g_GrnteeNo = "";
            }

        }

        string content = "";
        if (GuarntypeChk != 1)
        {
            content = " Dear Sir/Madam,<br/><br/> The below guarantee will expire on Date " + g_ExDate + ".";
        }
        else
        {
            content = " Dear Sir/Madam,<br/><br/> The below guarantee created on Date " + g_Bank_gurn_date + ".";
        }
        content += "<br/><br/><b><u>Guarantee Management System Notification</u></b>";
        //Evm-0012
        //table
        content += "<br/><br/><br/><table>";
        if (g_Cust_SupplierName != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Customer/Supplier&emsp;</th><td>:&emsp;" + g_Cust_SupplierName + "</td></tr>";


        }

        if (g_Amount != "")
        {

            content += "<tr style=\"text-align: left;\"><th>Amount&emsp;</th><td>:&emsp;" + g_Amount + " " + g_CurrencyType + "</td></tr>";
        }


        if (g_BankName != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Bank name&emsp;</th><td>:&emsp;" + g_BankName + "</td></tr>";

        }


        if (g_Ref != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Guarantee Ref #&emsp;</th><td>:&emsp;" + g_Ref + "</td></tr>";
        }
        if (g_GrnteeNo != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Guarantee Number&emsp;</th><td>:&emsp;" + g_GrnteeNo + "</td></tr>";
        }
        if (g_Mode != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Guarantee Mode&emsp;</th><td>:&emsp;" + g_Mode + "</td></tr>";
        }
        if (g_Type != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Guarantee Type&emsp;</th><td>:&emsp;" + g_Type + "</td></tr>";
        }
        if (GuarntypeChk != 1)
        {
            if (g_ExDate != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Expiry Date&emsp;</th><td>:&emsp;" + g_ExDate + "</td></tr>";
            }
        }
        if (g_Projct_Ref != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Project Ref&emsp;</th><td>:&emsp;" + g_Projct_Ref + "</td></tr>";
        }
        if (g_Projct_Ref != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Project Name&emsp;</th><td>:&emsp;" + g_Projct_Name + "</td></tr>";
        }
        if (g_Contact_PName != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Contact Person Name&emsp;</th><td>:&emsp;" + g_Contact_PName + "</td></tr>";

        }
        if (g_Cont_PEmail != "")
        {
            content += "<tr style=\"text-align: left;\"><th>Contact Person Email&emsp;</th><td>:&emsp;" + g_Cont_PEmail + "</td></tr>";

        }
        content += "</table>";

        content += "<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>";
        content += "<br/><br/><br/>Best Regards,";
        content += "<br/><font color=\"#0a409b\"><b>Compzit Administrator</b></font><br/><font color=\"#438df8\">Al-Balagh Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>";


        if (dtFromMail.Rows.Count > 0)
        {
           

            if (FLAG == 0)
            {
                FLAG++;
                objEntityMail.To_Email_Address = "SUDHEESHK@VOLVIAR.COM";
                //MailAddress;
                objEntityMail.Email_Subject = "BANK GUARANTEE EXPIRATION";
                objEntityMail.Email_Content = content;
                objEntityMail.From_Email_Address = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();
                objEntityMail.Out_Service_Name = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
                objEntityMail.Out_Port_Number = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
                objEntityMail.SSL_Status = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
                objEntityMail.Password = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();
                objEntityMail.Signature = dtFromMail.Rows[0]["MLCNFG_SIGNATURE"].ToString();



                List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
                List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();
                try
                {
                    SendMailAsHtml(objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);
                    //objBusnssTemMailServce.UpdateMailChk(EntityTemMailServce);


                    //EntityTemMailServce.D_Date = DateTime.Now;
                    //EntityTemMailServce.FromMailId = objEntityMail.From_Email_Address;
                    //EntityTemMailServce.ToMailId = objEntityMail.To_Email_Address;

                    //EntityTemMailServce.MailSubject = objEntityMail.Email_Subject;
                    //objBusnssTemMailServce.InsertMailTracking(EntityTemMailServce);

                }
                catch
                {


                }
            }

        }
    }
    public void SendMailAsHtml(clsEntityMailConsole objEntityMail, List<clsEntityMailAttachment> objEntityMailAttachList, List<clsEntityMailCcBCc> objEntityMailCcBCcList, List<classEntityToMailAddress> objEntityToMailAddressList)
    {

        clsEncryptionDecryption objEncryptDecrypt = new clsEncryptionDecryption();
        MailMessage mail = new MailMessage();
        mail.IsBodyHtml = true;
        SmtpClient SmtpServer = new SmtpClient(objEntityMail.Out_Service_Name);
        mail.From = new MailAddress(objEntityMail.From_Email_Address);
        mail.To.Add(objEntityMail.To_Email_Address);
        foreach (classEntityToMailAddress objEntityToMailAddress in objEntityToMailAddressList)
        {
            if (objEntityToMailAddress.ToAddress != "" && objEntityToMailAddress.ToAddress != null)
            {
                mail.To.Add(new MailAddress(objEntityToMailAddress.ToAddress));
            }
        }

        foreach (clsEntityMailCcBCc objEntityMailCcBCc in objEntityMailCcBCcList)
        {
            if (objEntityMailCcBCc.CcMail != "" && objEntityMailCcBCc.CcMail != null)
            {
                mail.CC.Add(new MailAddress(objEntityMailCcBCc.CcMail)); //Adding Multiple CC email Id
            }
            if (objEntityMailCcBCc.BCcMail != "" && objEntityMailCcBCc.BCcMail != null)
            {

                mail.Bcc.Add(new MailAddress(objEntityMailCcBCc.BCcMail)); //Adding Multiple BCC email Id
            }
        }



        //string strBody = objEntityMail.Email_Content + objEntityMail.Signature;
        //string strBody = objEntityMail.Email_Content;
        mail.Subject = objEntityMail.Email_Subject;
        mail.Body = objEntityMail.Email_Content;
        // mail.IsBodyHtml = true;


        //ContentType mimeType = new System.Net.Mime.ContentType("text/html");
        //// Add the alternate body to the message.

        //AlternateView alternate = AlternateView.CreateAlternateViewFromString(strBody, mimeType);
        //mail.AlternateViews.Add(alternate);


        //for attachment
        foreach (clsEntityMailAttachment objEntityAtt in objEntityMailAttachList)
        {
            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(objEntityAtt.Attch_Path);
            mail.Attachments.Add(attachment);
        }
        SmtpServer.Port = Convert.ToInt32(objEntityMail.Out_Port_Number);
        string strPassword = objEncryptDecrypt.Decrypt(objEntityMail.Password);
        if (objEntityMail.SSL_Status == 1)
            SmtpServer.EnableSsl = true;
        else
            SmtpServer.EnableSsl = false;
        SmtpServer.UseDefaultCredentials = false;
        SmtpServer.Credentials = new System.Net.NetworkCredential(objEntityMail.From_Email_Address, strPassword);
        SmtpServer.Send(mail);
        SmtpServer.Dispose();
        mail.Dispose();
    }


}