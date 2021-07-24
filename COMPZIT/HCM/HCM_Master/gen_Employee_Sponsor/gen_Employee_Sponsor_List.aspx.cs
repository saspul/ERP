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
// CREATED BY:EVM-0005
// CREATED DATE:7/1/2017
// REVIEWED BY:
// REVIEW DATE:
public partial class HCM_HCM_Master_gen_Employee_Sponsor_gen_Employee_Sponsor_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cbxCnclStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
       // cbxCnclStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
   
        //Creating objects for business layer
        clsBusinessLayerEmployeeSponsor objBusinessLayerSponsor = new clsBusinessLayerEmployeeSponsor();
        clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr = new clsEntityLayerEmployeeSponsorMaster();
        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            ddlSponsorStatus.SelectedValue ="1" ;
            Type_Load();
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Sponsor_Master);
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
                    objEntitySpnsrMstr.UserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntitySpnsrMstr.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntitySpnsrMstr.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
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
                    string strddlStatus = strSearchFields[1];
                    string strCbxStatus = strSearchFields[2];
                    string strtype = strSearchFields[0];
                   // string strCntrctrType = strSearchFields[3];
                    if (strtype == "--SELECT TYPE--")
                    {
                        objEntitySpnsrMstr.SponsorType_Id = 0;

                    }
                    else
                        objEntitySpnsrMstr.SponsorType_Id = Convert.ToInt32(strtype);
                    if (strtype != null && strtype != "")
                    {
                        if (ddlType.Items.FindByValue(strtype) != null)
                        {
                            ddlType.ClearSelection();
                          //  objEntitySpnsrMstr.Sponsor_Status = Convert.ToInt32(strddlStatus);

                            ddlType.Items.FindByValue(strtype).Selected = true;
                        }
                    }

                         if (strddlStatus != null && strddlStatus != "")
                    {
                        if (ddlSponsorStatus.Items.FindByValue(strddlStatus) != null)
                        {
                            ddlSponsorStatus.ClearSelection();
                            objEntitySpnsrMstr.Sponsor_Status = Convert.ToInt32(strddlStatus);
                
                            ddlSponsorStatus.Items.FindByValue(strddlStatus).Selected = true;
                        }
                    }
                    if (strCbxStatus == "1")
                    {
                        objEntitySpnsrMstr.Cancel_Status = Convert.ToInt32(strCbxStatus);
                        cbxCnclStatus.Checked = true;
                    }
                    else
                    {
                        objEntitySpnsrMstr.Cancel_Status = Convert.ToInt32(strCbxStatus);
                    
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

                    objEntitySpnsrMstr.Sponsor_Id = Convert.ToInt32(strId);
                   // objEntitySpnsrMstr.CorpId=
                      //  objEntitySpnsrMstr.Organisation_Id
                    objEntitySpnsrMstr.UserId = intUserId;

                    objEntitySpnsrMstr.SponsrDate = System.DateTime.Now;
                   DataTable Dtls= objBusinessLayerSponsor.ReadEmployeeSponsorById(objEntitySpnsrMstr);
                   int DuplChk = 0;
                   if (Dtls.Rows.Count > 0)
                   {
                       objEntitySpnsrMstr.Sponsor_Name = Dtls.Rows[0]["SPNSR_NAME"].ToString();
                     string Count = objBusinessLayerSponsor.CheckEmployeeSponsor(objEntitySpnsrMstr);
                     if (Count == "1")
                     {
                         DuplChk = 1;
                     }
                   }
                   if (DuplChk == 0)
                   {
                       objBusinessLayerSponsor.ReCallEmployeeSponsor(objEntitySpnsrMstr);
                   }
                   else
                   {
                       ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                   }
                    DataTable dtSpnsrDetail = new DataTable();
                    dtSpnsrDetail = objBusinessLayerSponsor.ReadEmployeeSponsorBy_search(objEntitySpnsrMstr);

                    string strHtm = ConvertDataTableToHTML(dtSpnsrDetail, intEnableModify, intEnableCancel, intEnableRecall);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;

                    string strNameCount = "0";
                    string strCodeCount = "0";
                    //if (dtContractDetail.Rows.Count > 0)
                    //{
                    //    objEntitySpnsrMstr.Sub_Cntrct_Name = dtContractDetail.Rows[0]["CNTRCT_NAME"].ToString();
                    //    objEntitySpnsrMstr.Sub_CntrctCode = dtContractDetail.Rows[0]["CNTRCT_CODE"].ToString();
                    //}
                    //strNameCount = objBusinessLayerContract.CheckContractName(objEntitySpnsrMstr);
                    //strCodeCount = objBusinessLayerContract.CheckContractCode(objEntitySpnsrMstr);
                    //if (strNameCount == "0" && strCodeCount == "0")
                    //{
                    //    objBusinessLayerContract.ReCallContract(objEntitySpnsrMstr);
                    //    if (HiddenSearchField.Value == "")
                    //    {
                    //        Response.Redirect("gen_Contract_Master_List.aspx?InsUpd=Recl");
                    //    }
                    //    else
                    //    {
                    //        Response.Redirect("gen_Contract_Master_List.aspx?InsUpd=Recl&Srch=" + this.HiddenSearchField.Value);
                    //    }
                    //}
                    //else
                    //{
                    //    if (strNameCount != "0")
                    //    {
                    //        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                    //    }
                    //    else if (strCodeCount != "0")
                    //    {
                    //        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
                    //    }

                    //}


                }

                if (Request.QueryString["canId"] != null)
                {//when Canceled

                    string strRandomMixedId = Request.QueryString["canId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    objEntitySpnsrMstr.Sponsor_Id = Convert.ToInt32(strId);
                    objEntitySpnsrMstr.UserId = intUserId;

                    objEntitySpnsrMstr.SponsrDate = System.DateTime.Now;



                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                    DataTable dtCorpDetail = new DataTable();
                    dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                        if (CnclrsnMust == "0")
                        {
                            objEntitySpnsrMstr.Cancel_Reason = objCommon.CancelReason();

                            objBusinessLayerSponsor.CancelEmployeeSponsor(objEntitySpnsrMstr);
                            if (HiddenSearchField.Value == "")
                            {
                                Response.Redirect("gen_Employee_Sponsor_List.aspx?InsUpd=Cncl");
                            }
                            else
                            {
                                Response.Redirect("gen_Employee_Sponsor_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                            }

                        }
                        else
                        {



                         //  clsBusinessLayerEmployeeSponsor objBusinessLayerSponsor = new clsBusinessLayerEmployeeSponsor();
                            DataTable dtContract = new DataTable();
                            //dtContract = objBusinessLayerSponsor.ReadEmployeeSponsorBy_search(objEntitySpnsrMstr);

                            dtContract = objBusinessLayerSponsor.ReadEmployeeSponsorBy_search(objEntitySpnsrMstr);
                
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
                        objEntitySpnsrMstr.Sponsor_Status =1;
                        objEntitySpnsrMstr.Sponsor_Id = 0;
                        objEntitySpnsrMstr.Cancel_Status = 0;
                    }
                    else
                    {
                        string strHidden = "";
                        strHidden = HiddenSearchField.Value;

                        string[] strSearchFields = strHidden.Split(',');
                        string strddlStatus = strSearchFields[1];
                        string strCbxStatus = strSearchFields[2];
                        string strtype = strSearchFields[0];
                        // string strCntrctrType = strSearchFields[3];
                        if (strtype == "--SELECT TYPE--")
                        {
                            objEntitySpnsrMstr.SponsorType_Id = 0;

                        }
                        else
                            objEntitySpnsrMstr.SponsorType_Id = Convert.ToInt32(ddlType.SelectedItem.Value);


                        if (strddlStatus != null && strddlStatus != "")
                        {
                            if (ddlSponsorStatus.Items.FindByValue(strddlStatus) != null)
                            {
                                ddlSponsorStatus.ClearSelection();
                         
                                objEntitySpnsrMstr.Sponsor_Status = Convert.ToInt32(strddlStatus);

                                ddlSponsorStatus.Items.FindByValue(strddlStatus).Selected = true;
                            }
                        }
                        if (strCbxStatus == "1")
                        {
                            objEntitySpnsrMstr.Cancel_Status = Convert.ToInt32(strCbxStatus);
                            cbxCnclStatus.Checked = true;
                        }
                        else
                        {
                            objEntitySpnsrMstr.Cancel_Status = Convert.ToInt32(strCbxStatus);

                            cbxCnclStatus.Checked = false;
                        }
                        objEntitySpnsrMstr.Cancel_Status = Convert.ToInt32(strCbxStatus);
                    }
                    objEntitySpnsrMstr.UserId = intUserId;
                 
                    DataTable dtContract = new DataTable();
                    dtContract = objBusinessLayerSponsor.ReadEmployeeSponsorBy_search(objEntitySpnsrMstr);

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
    

  //methode for loading the country
    public void Type_Load()
    {
        clsBusinessLayerEmployeeSponsor objBusinessEmployeeSponsor = new clsBusinessLayerEmployeeSponsor();
      //  clsEntitySponsor objEntitySponsor = new clsEntitySponsor();

        DataTable dtCountry = objBusinessEmployeeSponsor.Read_SponsorType();

        ddlType.Items.Clear();

        ddlType.DataSource = dtCountry;

        ddlType.DataTextField = "SPNSR_TYPE_NAME";
        ddlType.DataValueField = "SPNSR_TYPE_ID";
        ddlType.DataBind();

        ddlType.Items.Insert(0, "--SELECT TYPE--");




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
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:22%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }



        }
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
        else
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
 

        if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intReCallForTAble == 0)
                {
                    strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";
                }
            }

        if (intReCallForTAble == 1) 
        {
            if (intEnableRecall == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:6%; word-wrap:break-word;text-align: center;\">RE-CALL</th>";
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
                    strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                //else if (intColumnBodyCount == 4)
                //{
                //    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                //}


            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            strStatusMode = dt.Rows[intRowBodyCount][4].ToString();
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
                          " href=\"gen_Employee_Sponsor_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";




                }

                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                     " href=\"gen_Employee_Sponsor_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                }
            }
          
          
            else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                     " href=\"gen_Employee_Sponsor_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


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
                                     " href=\"gen_Employee_Sponsor_List.aspx?canId=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" onclick='return CancelAlert(this.href);' " +
                                   " href=\"gen_Employee_Sponsor_List.aspx?canId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
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
                                strHtml += "<td class=\"tdT\" style=\"width:6%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                     " href=\"gen_Employee_Sponsor_List.aspx?ReId=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:6%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Recall\"  onclick='return ReCallAlert(this.href);' " +
                                     " href=\"gen_Employee_Sponsor_List.aspx?ReId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";

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
        clsBusinessLayerEmployeeSponsor objBusinessEmployeeSponsor = new clsBusinessLayerEmployeeSponsor();
        clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr = new clsEntityLayerEmployeeSponsorMaster();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntitySpnsrMstr.Sponsor_Id = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntitySpnsrMstr.UserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntitySpnsrMstr.SponsrDate = System.DateTime.Now;

            objEntitySpnsrMstr.Cancel_Reason = txtCnclReason.Text.Trim();
            objBusinessEmployeeSponsor.CancelEmployeeSponsor(objEntitySpnsrMstr);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Employee_Sponsor_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Employee_Sponsor_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }

    // at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer
        clsBusinessLayerEmployeeSponsor objBusinessLayerSponsor = new clsBusinessLayerEmployeeSponsor();
        clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr = new clsEntityLayerEmployeeSponsorMaster();


      //  objEntitySpnsrMstr.Sponsor_Status = Convert.ToInt32(ddlType.SelectedItem.Value);
 
       
        if (cbxCnclStatus.Checked == true)
            objEntitySpnsrMstr.Cancel_Status = 1;
        else
            objEntitySpnsrMstr.Cancel_Status = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntitySpnsrMstr.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntitySpnsrMstr.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
  
        if (Session["USERID"] != null)
        {
            objEntitySpnsrMstr.UserId = Convert.ToInt32(Session["USERID"]);
            //objEntityCntrct.User_Id = 

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
  

        DataTable dtBrnd = new DataTable();
        if (ddlSponsorStatus.SelectedItem.Text == "Active")
        {
            objEntitySpnsrMstr.Sponsor_Status = 1;
        }
        else if (ddlSponsorStatus.SelectedItem.Text == "Inactive")
        {
            objEntitySpnsrMstr.Sponsor_Status = 0;
        }
        else if (ddlSponsorStatus.SelectedItem.Text == "All")
        {
            objEntitySpnsrMstr.Sponsor_Status = 3;
        }

        else{
                objEntitySpnsrMstr.Sponsor_Status = 4;
            }

       // objEntitySpnsrMstr.SponsorType_Id = Convert.ToInt32(ddlType.SelectedItem.Value);
        if (ddlType.SelectedItem.Value  == "--SELECT TYPE--")
        {
            objEntitySpnsrMstr.SponsorType_Id = 0;
        
        }
        else
                   objEntitySpnsrMstr.SponsorType_Id = Convert.ToInt32(ddlType.SelectedItem.Value);
        if (cbxCnclStatus.Checked ==true)
        {
            objEntitySpnsrMstr.Cancel_Status = 1; 
        }
        else {
            objEntitySpnsrMstr.Cancel_Status = 0;
        }
        dtBrnd = objBusinessLayerSponsor.ReadEmployeeSponsorBy_search(objEntitySpnsrMstr);


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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Sponsor_Master);
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
    public static string ChangeSponsorStatus(int strCatId, string strStatus)
    {

        //Creating objects for business layer
        clsBusinessLayerEmployeeSponsor objBusinessLayerSponsor = new clsBusinessLayerEmployeeSponsor();
        clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr = new clsEntityLayerEmployeeSponsorMaster();
        string strRet = "success";

        if (strStatus == "ACTIVE")
        {
            objEntitySpnsrMstr.Sponsor_Status = 0;
        }
        else
        {
            objEntitySpnsrMstr.Sponsor_Status = 1;
        }
        objEntitySpnsrMstr.Sponsor_Id = strCatId;
        try
        {
            objBusinessLayerSponsor.ChangeEmployeeSponsor(objEntitySpnsrMstr);
        }
        catch
        {
            strRet = "failed";
        }
        return strRet;
    }

}