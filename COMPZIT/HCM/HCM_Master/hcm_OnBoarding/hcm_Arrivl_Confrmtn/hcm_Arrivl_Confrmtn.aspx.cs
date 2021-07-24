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
using EL_Compzit;
using System.Collections.Generic;

public partial class HCM_HCM_Master_hcm_OnBoarding_hcm_Arrivl_Confrmtn_hcm_Arrivl_Confrmtn : System.Web.UI.Page
{
    clsBusiness_Arrivl_Confrmtn objBussnsArrvlConfrm = new clsBusiness_Arrivl_Confrmtn();
    protected void Page_Load(object sender, EventArgs e)
    {
        //clsEntity_Job_Description_Master objEntityJobDesrp = new clsEntity_Job_Description_Master();



        txtFromDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtToDate.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {

            ArrvlDate.Visible = false;
          //  ddldiv.Style.Add("margin-top", ".5%");
            //divserch.Style.Add("margin-top", "-3.7%");
            clsEntity_Arrivl_Confrmtn objEntityArrvlConfrm = new clsEntity_Arrivl_Confrmtn();


            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0, intRenew = 0, intConfirm = 0;
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Visa_Quota);
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



                }

            }


                if (Session["USERID"] != null)
                {
                    objEntityArrvlConfrm.UserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityArrvlConfrm.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityArrvlConfrm.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
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
                    string strFromDate = strSearchFields[0];
                    string strToDate = strSearchFields[1];
                    string strArrvlSts = strSearchFields[2];



                    if (strFromDate != null && strFromDate != "")
                    {

                        txtFromDate.Text = strFromDate;

                    }


                    if (strToDate != null && strToDate != "")
                    {
                        txtToDate.Text = strToDate;
                    }
                    if (strArrvlSts != null && strArrvlSts != "")
                    {
                        if (ddlArvlSts.Items.FindByValue(strArrvlSts) != null)
                        {
                            ddlArvlSts.Items.FindByValue(strArrvlSts).Selected = true;
                            
                        }
                    }

                }

                    
             
                    //to view

                    if (HiddenSearchField.Value == "")
                    {
                        objEntityArrvlConfrm.FromDate = DateTime.MinValue;
                        objEntityArrvlConfrm.ToDate = DateTime.MinValue;
                        objEntityArrvlConfrm.ArrvedStsId = 0;
                    }
                    else
                    {
                        string strHidden = "";
                        strHidden = HiddenSearchField.Value;

                        string[] strSearchFields = strHidden.Split(',');
                        string strFromDate = strSearchFields[0];
                        string strToDate = strSearchFields[1];
                        string strArrvlSts = strSearchFields[2];

                        if (strFromDate != null && strFromDate != "")
                        {

                            txtFromDate.Text = strFromDate;
                            objEntityArrvlConfrm.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());

                        }


                        if (strToDate != null && strToDate != "")
                        {
                            txtToDate.Text = strToDate;
                            objEntityArrvlConfrm.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
                        }
                        if (strArrvlSts != null && strArrvlSts != "")
                        {
                            if (ddlArvlSts.Items.FindByValue(strArrvlSts) != null)
                            {
                                ddlArvlSts.ClearSelection();
                                ddlArvlSts.Items.FindByValue(strArrvlSts).Selected = true;
                                objEntityArrvlConfrm.ArrvedStsId =Convert.ToInt32( strArrvlSts);
                            }
                        }

                        
                    }
                    if (Request.QueryString["StsCh"] != null)
                    {
                       
                        string strRandomMixedId = Request.QueryString["StsCh"].ToString();
                        string strLenghtofId = strRandomMixedId.Substring(0, 2);
                        int intLenghtofId = Convert.ToInt16(strLenghtofId);
                        string strId = strRandomMixedId.Substring(2, intLenghtofId);
                        objEntityArrvlConfrm.CandId = Convert.ToInt32(strId);
                        objEntityArrvlConfrm.UserId = intUserId;
                        //objEntityArrvlConfrm.datenow = objCommon.textToDateTime(System.DateTime.Now.ToString("dd-mm-yyyy"));
                        objBussnsArrvlConfrm.StatusChangeArrvlConfrmtn(objEntityArrvlConfrm);
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                        //Response.Redirect("gen_Interview_CategoryList.aspx");
                    }


                    DataTable dtContract = new DataTable();
                    dtContract = objBussnsArrvlConfrm.ReadArrvlConfrmtnList(objEntityArrvlConfrm);

                    string strHtm = ConvertDataTableToHTML(dtContract);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;

                    if (Request.QueryString["InsUpd"] != null)
                    {
                        string strInsUpd = Request.QueryString["InsUpd"].ToString();
                        if (strInsUpd == "Ins")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                        }
                     

                    }
                
            
        }
    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        int ArrvlSts = Convert.ToInt32(ddlArvlSts.SelectedItem.Value);
        if (ArrvlSts == 1)
        {
            ArrvlDate.Visible = true;
            ddldiv.Style.Add("margin-top","4.5%");
            divserch.Style.Add("margin-top", "-7.7%");
        }
        else {
            ArrvlDate.Visible = false;
            ddldiv.Style.Add("margin-top", ".5%");
            divserch.Style.Add("margin-top", "-3.7%");
        }
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
                strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">LOCATION</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:13%;text-align: left; word-wrap:break-word;\">REFERENCE</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:13%;text-align: left; word-wrap:break-word;\">NATIONALITY</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">FILE NAME</th>";
            }
        

        }
        if (ArrvlSts == 1)
        {
            strHtml += "<th class=\"thT\"  style=\"width:9%;text-align: center; word-wrap:break-word;\">ARRIVED DATE</th>";
        }
        if (ArrvlSts == 0)
        {
            strHtml += "<th class=\"thT\" style=\"width:4%;text-align: center; word-wrap:break-word;\">ARRIVE</th>";
        }
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
                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" +
                           dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a style=\"opacity:2;margin-top:-1%;\" class=\"tooltip\" title=\"\" onclick='return getdetails(this.href);' " +
                        " href=\"" + imgpath + dt.Rows[intRowBodyCount]["CAND_RESUMENAME"].ToString() + "\">" + dt.Rows[intRowBodyCount]["CAND_ACT_RESUMENAME"].ToString() + "</a> </td>";
                }




            }

            if (ArrvlSts == 1)
            {
                strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["ARVLCONFM_DATE"].ToString() + "</td>";
                }
            if (ArrvlSts == 0)
            {
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  style=\"opacity:1;margin-top: -1.2%;  margin-left: .8%;\" class=\"tooltip\" title=\"Make Arrived\" onclick='return ChangeStatus();' href=\"hcm_Arrivl_Confrmtn.aspx?StsCh=" + Id + "\"\" >" +
                    "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

            }

          
  
            //else
            //{
            //    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\" Make Active\" onclick='return ChangeStatus();' href=\"gen_Interview_CategoryList.aspx?StsCh=" + Id + "\"\" >" +
            //      "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
            //}




            strHtml += "</tr>";




        }




        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    //  at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer

        clsEntity_Arrivl_Confrmtn objEntityArrvlConfrm = new clsEntity_Arrivl_Confrmtn();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityArrvlConfrm.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityArrvlConfrm.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            objEntityArrvlConfrm.UserId = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (HiddenSearchField.Value == "")
        {
            objEntityArrvlConfrm.FromDate = DateTime.MinValue;
            objEntityArrvlConfrm.ToDate = DateTime.MinValue;
            objEntityArrvlConfrm.ArrvedStsId = 0;
        }
        else
        {
            string strHidden = "";
            strHidden = HiddenSearchField.Value;

            string[] strSearchFields = strHidden.Split(',');
            string strFromDate = strSearchFields[0];
            string strToDate = strSearchFields[1];
            string strArrvlSts = strSearchFields[2];

            if (strFromDate != null && strFromDate != "")
            {

                txtFromDate.Text = strFromDate;
              

            }


            if (strToDate != null && strToDate != "")
            {
                txtToDate.Text = strToDate;
                objEntityArrvlConfrm.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
            }
            if (strArrvlSts != null && strArrvlSts != "")
            {
                if (ddlArvlSts.Items.FindByValue(strArrvlSts) != null)
                {
                    ddlArvlSts.ClearSelection();
                    ddlArvlSts.Items.FindByValue(strArrvlSts).Selected = true;
                    objEntityArrvlConfrm.ArrvedStsId = Convert.ToInt32(strArrvlSts);
                }
            }


        }
        if (txtFromDate.Text.Trim()!="")
        objEntityArrvlConfrm.FromDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
        if (txtToDate.Text.Trim() != "")
        objEntityArrvlConfrm.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
        objEntityArrvlConfrm.ArrvedStsId = Convert.ToInt32(ddlArvlSts.SelectedValue);
        objEntityArrvlConfrm.UserId = intUserId;

        DataTable dtContract = new DataTable();
        dtContract = objBussnsArrvlConfrm.ReadArrvlConfrmtnList(objEntityArrvlConfrm);




        int intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
     //   clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
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
             

            }
        }

        string strHtm = ConvertDataTableToHTML(dtContract);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }

  
}