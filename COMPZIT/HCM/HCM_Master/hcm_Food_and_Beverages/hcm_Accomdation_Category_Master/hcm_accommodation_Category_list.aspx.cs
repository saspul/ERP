using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HCM_HCM_Master_hcm_Food_and_Beverages_hcm_Accomdation_Category_Master_hcm_accommodation_Category_list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlcat.Focus();
            //loading the categories in drop down
            AccommodationCatLoad();
            clsBusiness_Accommodation_Category objBusinessAccomdtn = new clsBusiness_Accommodation_Category();
            clsEntity_Accommodation_Cat objEntityAccomdtncat = new clsEntity_Accommodation_Cat();
            int intUserId = 0, intUsrRolMstrId = 0, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            hiddenEnableModify.Value = Convert.ToString(intEnableModify);
            hiddenEnableCancl.Value = Convert.ToString(intEnableCancel);
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityAccomdtncat.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityAccomdtncat.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityAccomdtncat.UserId = Convert.ToInt32(Session["USERID"]);
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Accommodatiion_Category_Master);
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
            }
            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                divAdd.Visible = true;

            }
            else
            {

                divAdd.Visible = false;
            }

            hiddenEnableModify.Value = Convert.ToString(intEnableModify);
            hiddenEnableCancl.Value = Convert.ToString(intEnableCancel);


            if (Request.QueryString["Srch"] != null && Request.QueryString["Srch"] != "")
            {
                string strHidden = Request.QueryString["Srch"].ToString();
                HiddenSearchField.Value = strHidden;

                string[] strSearchFields = strHidden.Split(',');


                string strddlStatus = strSearchFields[0];
                string strCbxStatus = strSearchFields[1];



                if (strddlStatus != null && strddlStatus != "")
                {
                    if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                    {
                        ddlStatus.ClearSelection();
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

            DataTable dtCorpDetail = new DataTable();
            int intCorpId = 0;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityAccomdtncat.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityAccomdtncat.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityAccomdtncat.UserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                                       clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE 

                                                                       };

            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);

            string CnclrsnMust = "";
            if (dtCorpDetail.Rows.Count > 0)
            {
                string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
                string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();
                CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();

            }
            if (Request.QueryString["Id"] != null)
            {//when Canceled

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                objEntityAccomdtncat.AccommodationcatId = Convert.ToInt32(strId);
                objEntityAccomdtncat.UserId = intUserId;

                objEntityAccomdtncat.Date = System.DateTime.Now;

                if (CnclrsnMust == "0")
                {
                    objEntityAccomdtncat.CancelReason = objCommon.CancelReason();

                    objBusinessAccomdtn.CancelAccommodtincat(objEntityAccomdtncat);
                    DataTable dtProductSrch = new DataTable();
                    objEntityAccomdtncat.Status = 1;
                    objEntityAccomdtncat.CancelStatus = 0;

                    dtProductSrch = objBusinessAccomdtn.ReadAccomdtncat(objEntityAccomdtncat);

                    string strHtm = ConvertDataTableToHTML(dtProductSrch, intEnableModify, intEnableCancel);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;
                }
                else
                {
                    DataTable dtProductSrch = new DataTable();
                    objEntityAccomdtncat.Status = 1;
                    objEntityAccomdtncat.CancelStatus = 0;
                    objEntityAccomdtncat.AccommodationcatId = 0;
                    dtProductSrch = objBusinessAccomdtn.ReadAccomdtncat(objEntityAccomdtncat);

                    string strHtm = ConvertDataTableToHTML(dtProductSrch, intEnableModify, intEnableCancel);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;

                    hiddenRsnid.Value = strId;
                    //ModalPopupExtenderCncl.Show();

                }
            }

            else if (Request.QueryString["StsCh"] != null)
            {
                string strRandomMixedId = Request.QueryString["StsCh"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityAccomdtncat.AccommodationcatId = Convert.ToInt32(strId);
                objEntityAccomdtncat.UserId = intUserId;
                objEntityAccomdtncat.Date = System.DateTime.Now;
                objBusinessAccomdtn.StatusChangeAccoomdtn(objEntityAccomdtncat);
                
                //DataTable dtProductSrch = new DataTable();
               
                //objEntityAccomdtncat.CancelStatus = 0;
                //if (HiddenSearchField.Value == "")
                //{

                //    objEntityAccomdtncat.Status = 1;
                //    objEntityAccomdtncat.CancelStatus = 0;
                //}
                //else
                //{
                //    string strHidden = "";
                //    strHidden = HiddenSearchField.Value;

                //    string[] strSearchFields = strHidden.Split(',');

                //    string strddlStatus = strSearchFields[0];
                //    string strCbxStatus = strSearchFields[1];

                //    if (strddlStatus != null && strddlStatus != "")
                //    {
                //        if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                //        {
                //            ddlStatus.ClearSelection();
                //            ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                //            objEntityAccomdtncat.Status = Convert.ToInt32(strddlStatus);
                //        }
                //    }
                //    if (strCbxStatus == "1")
                //    {
                //        cbxCnclStatus.Checked = true;
                //    }
                //    else
                //    {
                //        cbxCnclStatus.Checked = false;
                //    }

                //    objEntityAccomdtncat.CancelStatus = Convert.ToInt32(strCbxStatus);
                //}
                //objEntityAccomdtncat.AccommodationcatId = 0;
                //dtProductSrch = objBusinessAccomdtn.ReadAccomdtncat(objEntityAccomdtncat);

                //string strHtm = ConvertDataTableToHTML(dtProductSrch, intEnableModify, intEnableCancel);
                ////Write to divReport
                //divReport.InnerHtml = strHtm;
                Response.Redirect("hcm_accommodation_Category_list.aspx?InsUpd=Sts");
            }
            else
            {
                if (HiddenSearchField.Value == "")
                {

                    objEntityAccomdtncat.Status = 1;
                    objEntityAccomdtncat.CancelStatus = 0;
                }
                else
                {
                    string strHidden = "";
                    strHidden = HiddenSearchField.Value;

                    string[] strSearchFields = strHidden.Split(',');

                    string strddlStatus = strSearchFields[0];
                    string strCbxStatus = strSearchFields[1];

                    if (strddlStatus != null && strddlStatus != "")
                    {
                        if (ddlStatus.Items.FindByValue(strddlStatus) != null)
                        {
                            ddlStatus.ClearSelection();
                            ddlStatus.Items.FindByValue(strddlStatus).Selected = true;
                            objEntityAccomdtncat.Status = Convert.ToInt32(strddlStatus);
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

                    objEntityAccomdtncat.CancelStatus = Convert.ToInt32(strCbxStatus);
                }

                objEntityAccomdtncat.Status = 1;
                DataTable dtProductSrch = new DataTable();
                dtProductSrch = objBusinessAccomdtn.ReadAccomdtncat(objEntityAccomdtncat);
                string strHtm = ConvertDataTableToHTML(dtProductSrch, intEnableModify, intEnableCancel);
                //Write to divReport
                divReport.InnerHtml = strHtm;
            }
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Save")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                }
                else if (strInsUpd == "Sts")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Successstatschanged", "Successstatschanged();", true);

                }
            }
        }
    }

        
    
    
    //for reason save
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer
        clsBusiness_Accommodation_Category objBusinessAccomdtn = new clsBusiness_Accommodation_Category();
        clsEntity_Accommodation_Cat objEntityAccomdtncat = new clsEntity_Accommodation_Cat();
        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityAccomdtncat.AccommodationcatId = Convert.ToInt32(hiddenRsnid.Value);

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityAccomdtncat.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityAccomdtncat.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityAccomdtncat.UserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityAccomdtncat.Date = System.DateTime.Now;

            objEntityAccomdtncat.CancelReason = txtCnclReason.Text.Trim();
            objBusinessAccomdtn.CancelAccommodtincat(objEntityAccomdtncat);
            Response.Redirect("hcm_accommodation_Category_list.aspx?InsUpd=Cncl");
        }
    }



    //for loading objects for the accommodation category
    public void AccommodationCatLoad()
    {
        //Creating objects for business layer
        clsBusiness_Accommodation_Category objBusinessAccomdtn = new clsBusiness_Accommodation_Category();
        clsEntity_Accommodation_Cat objEntityAccomdtncat = new clsEntity_Accommodation_Cat();

    
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccomdtncat.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccomdtncat.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityAccomdtncat.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdesig = objBusinessAccomdtn.Readcatname(objEntityAccomdtncat);
   
        if (dtdesig.Rows.Count > 0)
        {
            ddlcat.DataSource = dtdesig;
            ddlcat.Items.Clear();

            ddlcat.DataValueField = "ACCOMDTNCAT_ID";
            ddlcat.DataTextField = "ACCOMDTNCAT_NAME";
            ddlcat.DataBind();
             
        }
        ddlcat.Items.Insert(0, "--SELECT CATEGORY--");
        ddlcat.SelectedIndex = 0;  
    }


    //for list table

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
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:58%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                
                    strHtml += "<th class=\"thT\" style=\"width:4%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                
            }
            if (intColumnHeaderCount == 3)
            {
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (cbxCnclStatus.Checked == false)
                    {
                        strHtml += "<th class=\"thT\" style=\"width:58%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                    }
                     }
            }
            //else if (intColumnHeaderCount == 3)
            //{
            //    strHtml += "<th class=\"thT\"  style=\"width:12%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            //}




        }
        if (cbxCnclStatus.Checked == false)
        {
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT </th>";

            }

            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE </th>";
            }
        }
        else
        {
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW </th>";
        }


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            //int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}


                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:58%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {

                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                  
                      

                    


                }
                if (intColumnBodyCount == 3)
                {
                    if (cbxCnclStatus.Checked == false)
                    {
                      if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {

                            if (HiddenSearchField.Value == "")
                            {
                                if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "ACTIVE")
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Inactive\" onclick='return ChangeStatus();' href=\"hcm_accommodation_Category_list.aspx?StsCh=" + Id + "\"\" >" +
                                        "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                                }

                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Active\" onclick='return ChangeStatus();' href=\"hcm_accommodation_Category_list.aspx?StsCh=" + Id + "\"\" >" +
                                      "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                                }
                            }

                            else
                            {


                                if (dt.Rows[intRowBodyCount]["STATUS"].ToString() == "ACTIVE")
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Make Inactive\" onclick='return ChangeStatus();' href=\"hcm_accommodation_Category_list.aspx?StsCh=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\"\" >" +
                                        "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                                }

                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Active\" onclick='return ChangeStatus();' href=\"hcm_accommodation_Category_list.aspx?StsCh=" + Id + "\"\" >" +
                                      "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                                }

                            }
                        }
                }
                }
               
            }
           

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (cbxCnclStatus.Checked == false)
                {


                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                          " href=\"hcm_Accommdation_category_mstr.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                }


            }
            if (cbxCnclStatus.Checked == true)
            {
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"View\"  onclick='return getdetails(this.href);' " +
                 " href=\"hcm_Accommdation_category_mstr.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


            }
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (cbxCnclStatus.Checked == false)
                {

                    if (intCancTransaction == 0)
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\"   onclick='return CancelAlert(this.href);' " +
                         " href=\"hcm_accommodation_Category_list.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                    }
                    else
                    {

                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Delete\" onclick='return CancelNotPossible();' >"
                                + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

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
    //for search
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer
        clsBusiness_Accommodation_Category objBusinessAccomdtn = new clsBusiness_Accommodation_Category();
        clsEntity_Accommodation_Cat objEntityAccomdtncat = new clsEntity_Accommodation_Cat();

        int intCorpId = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccomdtncat.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccomdtncat.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityAccomdtncat.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (ddlStatus.SelectedItem.Value != "")
        {
            objEntityAccomdtncat.Status = Convert.ToInt32(ddlStatus.SelectedItem.Value);
        }
        if (cbxCnclStatus.Checked == true)
        {
            objEntityAccomdtncat.CancelStatus = 1;
        }
        else
        {
            objEntityAccomdtncat.CancelStatus = 0;
        }
        if (ddlcat.SelectedItem.Value != "--SELECT CATEGORY--")
        {
            objEntityAccomdtncat.AccommodationcatId = Convert.ToInt32(ddlcat.SelectedItem.Value);
        }
       
        DataTable dtProductSrch = new DataTable();
        dtProductSrch = objBusinessAccomdtn.ReadAccomdtncat(objEntityAccomdtncat);

        int intEnableModify = 0, intEnableCancel = 0;

        intEnableModify = Convert.ToInt32(hiddenEnableModify.Value);
        intEnableCancel = Convert.ToInt32(hiddenEnableCancl.Value);
        string strHtm = ConvertDataTableToHTML(dtProductSrch, intEnableModify, intEnableCancel);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }
}