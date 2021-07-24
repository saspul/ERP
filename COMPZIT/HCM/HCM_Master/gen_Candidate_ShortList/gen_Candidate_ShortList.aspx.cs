using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
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

public partial class HCM_HCM_Master_gen_Candidate_ShortList_gen_Candidate_ShortList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // SponsorType_Load();
           // Country_Load();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayerEmployeeSponsor objBusinessEmployeeSponsor = new clsBusinessLayerEmployeeSponsor();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {

                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
        }

        if (Request.QueryString["Id"] != null)
        {
            //btnClear.Visible = false;
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            Update(strId);
            HiddenreqstId.Value=strId;
            lblEntry.Text = "Edit Candidate Shortlist";

        }
    }
    public void Update(string strP_Id)
    {
        //btnAdd.Visible = false;
      //  btnAddClose.Visible = false;

       // btnAdd.Visible = true;
        // clsentitylayeemplo objEntitySponsor = new clsEntitySponsor();
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableConfirm = 0;
        clsBusinessCandidate_ShortList objBusinesscandidateShrtlist = new clsBusinessCandidate_ShortList();
        clsEntityLayer_Candidate_ShortList objEntitycandidateShrtlist = new clsEntityLayer_Candidate_ShortList();
        if (Session["USERID"] != null)
        {
            objEntitycandidateShrtlist.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntitycandidateShrtlist.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntitycandidateShrtlist.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //Allocating child roles
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.CANDIDATE_SHORTLIST);
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

                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                {
                    intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

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
                //Btnsave.Visible = true;
                    btnAdd.Visible = true;
            }
            else
            {
               // Btnsave.Visible = false;
                btnAdd.Visible = false;
              //  btnUpdate.Visible = false;

            }


            if (intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnCnfrm.Visible = true;
                btnAdd.Visible = true;
            }
            else
            {
                btnCnfrm.Visible = false;
               // btnAdd.Visible = false;
              //  btnUpdate.Visible = false;

            }
        }



     //   Hiddensponsorid.Value = strP_Id;
        objEntitycandidateShrtlist.ReqstID = Convert.ToInt32(strP_Id);
        DataTable dtShortlist = objBusinesscandidateShrtlist.ReadAprvdManPwrReqstListByid(objEntitycandidateShrtlist);
      //  txtSponsorName.Text = dtShortlist.Rows[0]["SPNSR_NAME"].ToString();
        int selected = 0;
        if (dtShortlist.Rows.Count > 0)
        {
            if (dtShortlist.Rows[0]["CAND_CNFRM_STATUS"].ToString() == "1")
            {
                selected = 1;
                btnCnfrm.Visible = true;
                btnAdd.Visible = true;

            }
            if (dtShortlist.Rows[0]["CAND_CNFRM_STATUS"].ToString() == "2")
            {
                btnCnfrm.Visible = false;
                btnAdd.Visible = true;

            }
            //ddlSpnsrType.SelectedValue = dtShortlist.Rows[0]["CSTMRTYP_ID"].ToString();
            lblRefNum.Text = dtShortlist.Rows[0]["MNP_REFNUM"].ToString().ToUpper();

            lblDateOfReq.Text = dtShortlist.Rows[0]["DATE OF REQUEST"].ToString().ToUpper();

            lblNumber.Text = dtShortlist.Rows[0]["MNP_RESOURCENUM"].ToString().ToUpper();

            lblDesign.Text = dtShortlist.Rows[0]["DESIGNATION"].ToString().ToUpper();
            lblDeprtmnt.Text = dtShortlist.Rows[0]["DEPARTMENT"].ToString().ToUpper();

            lblPrjct.Text = dtShortlist.Rows[0]["PROJECT"].ToString().ToUpper();

            lblExprnce.Text = dtShortlist.Rows[0]["MNP_EXPERIENCE"].ToString()+" Years";

            lblPaygrd.Text = dtShortlist.Rows[0]["PYGRD_NAME"].ToString().ToUpper();
        }
        DataTable dtShortlistcandidates = objBusinesscandidateShrtlist.ReadCandidates(objEntitycandidateShrtlist);
        DataTable dtShortlistedcandidatelist = objBusinesscandidateShrtlist.ReadSelected_Candidates(objEntitycandidateShrtlist);
        string strHtm = ConvertDataTableToHTML(dtShortlistcandidates, dtShortlistedcandidatelist);
        //Write to divReport
        divReport.InnerHtml = strHtm;



    }
    //public string ConvertDataTableToHTML(DataTable dt, DataTable Shortlist)
    //{

    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    string strRandom = objCommon.Random_Number();
    //    int intimgsection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
    //    // intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.CANDIDATE_SHORTLIST);
    //    string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
    //    // class="table table-bordered table-striped"
    //    StringBuilder sb = new StringBuilder();
    //    string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
    //    //add header row
    //    strHtml += "<thead>";
    //    strHtml += "<tr class=\"main_table_head\">";
        
    //    int shortlistcount = 0;
    //    strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" Id=\"cbxSelectAll\" title=\"Select All\"  style=\"margin-left: 13%;\" onkeypress=\"return DisableEnter(event)\"; onchange=\"selectAll()\"></th>";
    //    for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
    //    {
    //        if (intColumnHeaderCount == 1)
    //        {
    //            strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
    //        }

    //        else if (intColumnHeaderCount == 2)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
    //        }

    //        else if (intColumnHeaderCount == 3)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
    //        }
    //        else if (intColumnHeaderCount == 4)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
    //        }
    //        else if (intColumnHeaderCount == 5)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:7%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
    //        }
    //        else if (intColumnHeaderCount == 6)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:7%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
    //        }
    //        else if (intColumnHeaderCount == 7)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
    //        }
    //        else if (intColumnHeaderCount == 8)
    //        {
    //            strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
    //        }

    //    }

    //    strHtml += "</tr>";
    //    strHtml += "</thead>";
    //    //add rows
    //    hiddenRowCount.Value = dt.Rows.Count.ToString();
    //    strHtml += "<tbody>";
    //    int count = 1, listcount = 0, flag = 0;
    //    for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
    //    {
          
    //        strHtml += "<tr  >";
    //        listcount = 0;

    //        flag = 0;
    //        while (listcount < Shortlist.Rows.Count)
    //        {



    //            if (dt.Rows[intRowBodyCount][0].ToString() == Shortlist.Rows[listcount][0].ToString())
    //            {
    //                shortlistcount = listcount;
    //                flag = 1;
    //                //strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblcandidatelist" + intRowBodyCount + "\"checked=\"true\"></td>";
    //                listcount++;

    //            }
    //            else
    //            {
    //                // strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblcandidatelist" + intRowBodyCount + "\"></td>";
    //                listcount++;

    //            }

    //        }
    //        if (flag == 1)
    //        {
    //            if (Shortlist.Rows[shortlistcount][2].ToString() == "1")
    //            {
    //                 strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblcandidatelist" + intRowBodyCount + "\" checked=\"true\" disabled =\"true\" onchange=\"IncrmntConfrmCounter()\"></td>";
    //            }
    //            else
    //            {
    //                  strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblcandidatelist" + intRowBodyCount + "\" checked=\"true\" onchange=\"IncrmntConfrmCounter()\"></td>";
    //            }
    //        }
    //        else
    //            strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblcandidatelist" + intRowBodyCount + "\"true\" onchange=\"IncrmntConfrmCounter()\"></td>";

    //        //shortlistcount++;

    //        count++;

    //        string strId = dt.Rows[intRowBodyCount][0].ToString();
    //        int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
    //        string stridLength = intIdLength.ToString("00");
    //        string Id = stridLength + strId + strRandom;
    //        string reference = "";
    //        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
    //        {

    //            if (intColumnBodyCount == 1)
    //            {
    //                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a> </td>";
    //            }
    //            else if (intColumnBodyCount == 2)
    //            {
    //                strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //            }

    //            else if (intColumnBodyCount == 3)
    //            {
    //                strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //            }
    //            else if (intColumnBodyCount == 4)
    //            {
    //                if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
    //                {
    //                    reference = "CONSULTANCY";
    //                }
    //                else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "2")
    //                {
    //                    reference = "DIVISION";
    //                }
    //                else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "3")
    //                {
    //                    reference = "DEPARTMENT";
    //                }
    //                else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "4")
    //                {
    //                    reference = "EMPLOYEE";
    //                }

    //                strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + reference + "</td>";
    //            }

    //            else if (intColumnBodyCount == 5)
    //            {
    //                if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
    //                    strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >YES</td>";
    //                else
    //                    strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >NO</td>";

    //            }
    //            else if (intColumnBodyCount == 6)
    //            {
    //                if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
    //                    strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >YES</td>";
    //                else
    //                    strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >NO</td>";

    //            }
    //            else if (intColumnBodyCount == 7)
    //            {
    //                strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

    //            }
    //            else if (intColumnBodyCount == 8)
    //            {
    //                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a class=\"tooltip\" title=\"\" onclick='return getdetails(this.href);' " +
    //                         " href=\"" + imgpath + dt.Rows[intRowBodyCount][9].ToString() + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a> </td>";

    //                // strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
    //            }


    //        }
    //        strHtml += "<td id=\"tdcandiateid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";


    //        strHtml += "</tr>";
    //        break;
    //    }

    //    strHtml += "</tbody>";

    //    strHtml += "</table>";



    //    sb.Append(strHtml);
    //    return sb.ToString();
    //}
    public string ConvertDataTableToHTML(DataTable dt, DataTable Shortlist)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        int intimgsection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        // intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.CANDIDATE_SHORTLIST);
        string imgpath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CANDIDATE_SELECTION);
        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        int shortlistcount = 0;
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" Id=\"cbxSelectAll\" title=\"Select All\"  style=\"margin-left: 13%;\" onkeypress=\"return DisableEnter(event)\"; onchange=\"selectAll()\"></th>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
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
                strHtml += "<th class=\"thT\"  style=\"width:7%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\"  style=\"width:7%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 8)
            {
                strHtml += "<th class=\"thT\"  style=\"width:14%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        hiddenRowCount.Value = dt.Rows.Count.ToString();
        strHtml += "<tbody>";
        int count = 1, listcount = 0, flag = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            strHtml += "<tr  >";
            listcount = 0;

            flag = 0;
            while (listcount < Shortlist.Rows.Count)
            {



                if (dt.Rows[intRowBodyCount][0].ToString() == Shortlist.Rows[listcount][0].ToString())
                {
                    shortlistcount = listcount;
                    flag = 1;
                    //strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblcandidatelist" + intRowBodyCount + "\"checked=\"true\"></td>";
                    listcount++;

                }
                else
                {
                    // strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblcandidatelist" + intRowBodyCount + "\"></td>";
                    listcount++;

                }

            }
            if (flag == 1)
            {
                if (Shortlist.Rows[shortlistcount][2].ToString() == "1")
                {
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblcandidatelist" + intRowBodyCount + "\"checked=\"true\"disabled =\"true\" onchange=\"IncrmntConfrmCounter()\"></td>";
                }
                else
                    strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblcandidatelist" + intRowBodyCount + "\"checked=\"true\"onchange=\"IncrmntConfrmCounter()\"></td>";

            }
            else
                strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblcandidatelist" + intRowBodyCount + "\"true\" onchange=\"IncrmntConfrmCounter()\"></td>";

            //shortlistcount++;

            count++;

            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            string reference = "";
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a> </td>";
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
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                    {
                        reference = "CONSULTANCY";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "2")
                    {
                        reference = "DIVISION";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "3")
                    {
                        reference = "DEPARTMENT";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "4")
                    {
                        reference = "EMPLOYEE";
                    }

                    strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + reference + "</td>";
                }

                else if (intColumnBodyCount == 5)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                        strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >YES</td>";
                    else
                        strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >NO</td>";

                }
                else if (intColumnBodyCount == 6)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                        strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >YES</td>";
                    else
                        strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >NO</td>";

                }
                else if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:7%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                }
                else if (intColumnBodyCount == 8)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a class=\"tooltip\" title=\"\" onclick='return getdetails(this.href);' " +
                             " href=\"" + imgpath + dt.Rows[intRowBodyCount][9].ToString() + "\">" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a> </td>";

                    // strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }


            }
            strHtml += "<td id=\"tdcandiateid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";


            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    protected void Btnsave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessCandidate_ShortList objbusinessShortList = new clsBusinessCandidate_ShortList();
        clsEntityLayer_Candidate_ShortList ObjEntityShortList = new clsEntityLayer_Candidate_ShortList();
        CllsEntityPrefferedNationaity ObjEntityPrefferedNationaity = new CllsEntityPrefferedNationaity();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
        //  clsEntityReports ObjLeadReport = new clsEntityReports();

        int intCorpId = 0, intOrgId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityShortList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            ObjEntityShortList.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityShortList.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntityShortList.ReqstID = Convert.ToInt32(HiddenreqstId.Value);
        DataTable dtShortlist = objbusinessShortList.ReadAprvdManPwrReqstListByid(ObjEntityShortList);

        if (dtShortlist.Rows.Count > 0)
        {



        }

        else
        {


            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CANDIDATE_SHORTLIST);
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);

            // ObjEntityShortList.ShortlistMasterId = Convert.ToInt32(strNextId);
            //  CllsEntityShortList ObjEntityShortList = new CllsEntityShortList();
            ObjEntityShortList.ShorltistDate = objCommonLibrary.textToDateTime(DateTime.Today.Date.ToString());

            ObjEntityShortList.ReqstID = Convert.ToInt32(HiddenreqstId.Value);
            // ObjEntityShortList.No_Resources = Convert.ToInt32(txtRqrmntNo.Text);

            List<clsEntityLayerJobRlAppRole> objlistShortList = new List<clsEntityLayerJobRlAppRole>();
            //   foreach (ListItem itemCheckBoxModules in cbxlCompzitModules.Items)
            // {

            //  if (itemCheckBoxModules.Selected)
            //  {

            clsEntityLayerJobRlAppRole objJobRlAppRol = new clsEntityLayerJobRlAppRole();

            // If the item is selected.

            // if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.))
            // {
            // intTreeAppAdminVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

            //}
            //  }

            //  }

            //   objbusinessShortList.AddCandidateShortList(ObjEntityShortList,);
        }
        if (clickedButton.ID == "btnAdd")
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
        }
        else if (clickedButton.ID == "btnAddClose")
        {
            Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Ins");


        }
        
    }
    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
      //  clsBusinessLayerShortList objbusinessShortList = new clsBusinessLayerShortList();

        clsEntityLayer_Candidate_ShortList ObjEntityShortList = new clsEntityLayer_Candidate_ShortList();
        clsBusinessCandidate_ShortList objbusinessShortList = new clsBusinessCandidate_ShortList();
    //    CllsEntityPrefferedNationaity ObjEntityPrefferedNationaity = new CllsEntityPrefferedNationaity();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        int intCorpId = 0, intOrgId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityShortList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            ObjEntityShortList.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityShortList.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
                ObjEntityShortList.ReqstID = Convert.ToInt32(HiddenreqstId.Value);
                
        DataTable dtShortlist = objbusinessShortList.ReadSelected_Candidates(ObjEntityShortList);
            
        if (dtShortlist.Rows.Count > 0)
        {
            ObjEntityShortList.ShortlistMasterId = Convert.ToInt32(dtShortlist.Rows[0][1].ToString());
            HiddenShortlistMasterid.Value =dtShortlist.Rows[0][1].ToString();
                  List<ShortListedCandiate> objlistShortList = new List<ShortListedCandiate>();
            string[] tokens = Hiddenchecklist.Value.Split(',');
            //  foreach (ListItem itemCheckBoxModules in cblcandidatelist.Items)
            // {

            for (int i = 0; i < tokens.Count() - 1; i++)
            {

                int a = Convert.ToInt32(tokens[i]);
                ShortListedCandiate objentityShortList = new ShortListedCandiate();

                //    If the item is selected.

                //  if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.APP_ADMINSTRATION))
                //   {
                //      intTreeAppAdminVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                //     }
                objentityShortList.CandidateId = a;
                objlistShortList.Add(objentityShortList);
            }
         
            //    else
            //   {
            //        Item is not selected, do something else.
            //  }
            //}
            //objbusinessShortList.AddCandidateShortList(ObjEntityShortList, objlistShortList);
            DataTable dtShortlistedcandidatelist = objbusinessShortList.ReadSelected_Candidates(ObjEntityShortList);
        
            objbusinessShortList.UpdateShortlist(ObjEntityShortList, objlistShortList);
           
            int count=0;
            for (int i = 0; i < dtShortlistedcandidatelist.Rows.Count; i++)
            {
               
                ObjEntityShortList.ShortlistDetailId = Convert.ToInt32(dtShortlistedcandidatelist.Rows[count][0].ToString());

                ObjEntityShortList.Confirmstatus = 1;
          
                if (dtShortlistedcandidatelist.Rows[count][2].ToString() == "1")
                {
                    
                    objbusinessShortList.ConfirmCandidateId(ObjEntityShortList);


                } count++;
            }
            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Candidate_ShortList_LIst.aspx?InsUpd=Ins");
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Candidate_ShortList.aspx?InsUpd=Ins");


            }
        
        }
        

        else
        {

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CANDIDATE_SHORTLIST);
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            ObjEntityShortList.ShortlistMasterId = Convert.ToInt32(strNextId);
            HiddenShortlistMasterid.Value = strNextId;
            ObjEntityShortList.ReqstID = Convert.ToInt32(HiddenreqstId.Value);
            //  CllsEntityShortList ObjEntityShortList = new CllsEntityShortList();
            ObjEntityShortList.ShorltistDate = DateTime.Today.Date;

            // ObjEntityShortList.RequestDate1 = objCommonLibrary.textToDateTime(TxtdivRqrdDate.Text);



            List<ShortListedCandiate> objlistShortList = new List<ShortListedCandiate>();
            string[] tokens = Hiddenchecklist.Value.Split(',');
            //  foreach (ListItem itemCheckBoxModules in cblcandidatelist.Items)
            // {

            for (int i = 0; i < tokens.Count() - 1; i++)
            {

                int a = Convert.ToInt32(tokens[i]);
                ShortListedCandiate objentityShortList = new ShortListedCandiate();

                //    If the item is selected.

                //  if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.APP_ADMINSTRATION))
                //   {
                //      intTreeAppAdminVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                //     }
                objentityShortList.CandidateId = a;
                objlistShortList.Add(objentityShortList);
            }
            //    else
            //   {
            //        Item is not selected, do something else.
            //  }
            //}
            objbusinessShortList.AddCandidateShortList(ObjEntityShortList, objlistShortList);
            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Candidate_ShortList_LIst.aspx?InsUpd=Ins");
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Ins");


            }
        
        }
        Update(HiddenreqstId.Value);
       


    }
    protected void btnCnfrm_Click(object sender, EventArgs e)
    {
       save();
        clsEntityLayer_Candidate_ShortList ObjEntityShortList = new clsEntityLayer_Candidate_ShortList();
        clsBusinessCandidate_ShortList objbusinessShortList = new clsBusinessCandidate_ShortList();
        int intCorpId = 0, intOrgId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityShortList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            ObjEntityShortList.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityShortList.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntityShortList.ReqstID = Convert.ToInt32(HiddenreqstId.Value);

        DataTable dtShortlist = objbusinessShortList.ReadSelected_Candidates(ObjEntityShortList);
        if (dtShortlist.Rows.Count > 0)
        {
            ObjEntityShortList.Confirmstatus = 1;
            ObjEntityShortList.ShorltistDate = DateTime.Today.Date;
            ObjEntityShortList.ShortlistMasterId = Convert.ToInt32(dtShortlist.Rows[0][1].ToString());
            HiddenShortlistMasterid.Value = dtShortlist.Rows[0][1].ToString();
            objbusinessShortList.ChangeStatus(ObjEntityShortList);
            objbusinessShortList.ConfirmEntries(ObjEntityShortList);
            //  btnCnfrm.Visible = false;
            //  btnAdd.Visible = false;
            Update(HiddenreqstId.Value);
            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmed", "SuccessConfirmed();", true);
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Update(HiddenreqstId.Value);
    }
    public void save()
    {
        clsEntityLayer_Candidate_ShortList ObjEntityShortList = new clsEntityLayer_Candidate_ShortList();
        clsBusinessCandidate_ShortList objbusinessShortList = new clsBusinessCandidate_ShortList();
        //    CllsEntityPrefferedNationaity ObjEntityPrefferedNationaity = new CllsEntityPrefferedNationaity();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        int intCorpId = 0, intOrgId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityShortList.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            ObjEntityShortList.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityShortList.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntityShortList.ReqstID = Convert.ToInt32(HiddenreqstId.Value);

        DataTable dtShortlist = objbusinessShortList.ReadSelected_Candidates(ObjEntityShortList);

        if (dtShortlist.Rows.Count > 0)
        {
            ObjEntityShortList.ShortlistMasterId = Convert.ToInt32(dtShortlist.Rows[0][1].ToString());
            HiddenShortlistMasterid.Value = dtShortlist.Rows[0][1].ToString();
            List<ShortListedCandiate> objlistShortList = new List<ShortListedCandiate>();
            string[] tokens = Hiddenchecklist.Value.Split(',');
            //  foreach (ListItem itemCheckBoxModules in cblcandidatelist.Items)
            // {

            for (int i = 0; i < tokens.Count() - 1; i++)
            {

                int a = Convert.ToInt32(tokens[i]);
                ShortListedCandiate objentityShortList = new ShortListedCandiate();

                //    If the item is selected.

                //  if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.APP_ADMINSTRATION))
                //   {
                //      intTreeAppAdminVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                //     }
                objentityShortList.CandidateId = a;
                objlistShortList.Add(objentityShortList);
            }

            //    else
            //   {
            //        Item is not selected, do something else.
            //  }
            //}
            //objbusinessShortList.AddCandidateShortList(ObjEntityShortList, objlistShortList);
            DataTable dtShortlistedcandidatelist = objbusinessShortList.ReadSelected_Candidates(ObjEntityShortList);

            objbusinessShortList.UpdateShortlist(ObjEntityShortList, objlistShortList);

            int count = 0;
            for (int i = 0; i < dtShortlistedcandidatelist.Rows.Count; i++)
            {

                ObjEntityShortList.ShortlistDetailId = Convert.ToInt32(dtShortlistedcandidatelist.Rows[count][0].ToString());

                ObjEntityShortList.Confirmstatus = 1;

                if (dtShortlistedcandidatelist.Rows[count][2].ToString() == "1")
                {

                    objbusinessShortList.ConfirmCandidateId(ObjEntityShortList);


                } count++;
            }
       
           //     Response.Redirect("gen_Candidate_ShortList_LIst.aspx?InsUpd=Ins");
               // ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
 
            

        }


        else
        {

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CANDIDATE_SHORTLIST);
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            ObjEntityShortList.ShortlistMasterId = Convert.ToInt32(strNextId);
            HiddenShortlistMasterid.Value = strNextId;
            ObjEntityShortList.ReqstID = Convert.ToInt32(HiddenreqstId.Value);
            //  CllsEntityShortList ObjEntityShortList = new CllsEntityShortList();
            ObjEntityShortList.ShorltistDate = DateTime.Today.Date;

            // ObjEntityShortList.RequestDate1 = objCommonLibrary.textToDateTime(TxtdivRqrdDate.Text);



            List<ShortListedCandiate> objlistShortList = new List<ShortListedCandiate>();
            string[] tokens = Hiddenchecklist.Value.Split(',');
            //  foreach (ListItem itemCheckBoxModules in cblcandidatelist.Items)
            // {

            for (int i = 0; i < tokens.Count() - 1; i++)
            {

                int a = Convert.ToInt32(tokens[i]);
                ShortListedCandiate objentityShortList = new ShortListedCandiate();

                //    If the item is selected.

                //  if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.APP_ADMINSTRATION))
                //   {
                //      intTreeAppAdminVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                //     }
                objentityShortList.CandidateId = a;
                objlistShortList.Add(objentityShortList);
            }
            //    else
            //   {
            //        Item is not selected, do something else.
            //  }
            //}
            objbusinessShortList.AddCandidateShortList(ObjEntityShortList, objlistShortList);
      //   Response.Redirect("gen_Candidate_ShortList_LIst.aspx?InsUpd=Ins");
        
 

        }
       // Update(HiddenreqstId.Value);
    
    
    }
}