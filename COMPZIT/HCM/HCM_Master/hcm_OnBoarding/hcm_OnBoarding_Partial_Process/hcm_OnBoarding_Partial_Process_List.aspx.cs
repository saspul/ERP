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

public partial class HCM_HCM_Master_hcm_OnBoarding_hcm_OnBoarding_Partial_Process_hcm_OnBoarding_Partial_Process_List : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        txtAsgnedDate.Focus();
        if (!IsPostBack)
        {
            ReqrmntLoad();

            clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
            clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Onboaring_Partial_Process);
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
                    objEntityPartialProcess.User_Id = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityPartialProcess.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityPartialProcess.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

               

                DataTable dtAssgndProcess = new DataTable();
                dtAssgndProcess = objBusinessPartialProcess.ReadAssignedProcessList(objEntityPartialProcess);
                string strHtm = ConvertDataTableToHTML(dtAssgndProcess, intEnableAdd, intEnableModify);
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
                strHtml += "<th class=\"thT\" style=\"width:35%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">LOCATION</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:13%;text-align: center; word-wrap:break-word;\">REFERENCE</th>";
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
        //0008
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: center; word-wrap:break-word;\"></th>";
        strHtml += "<th class=\"thT\" style=\"width:4%;text-align: center; word-wrap:break-word;\">EDIT</th>";
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
                        strHtml += "<td class=\"tdT\" style=\" width:35%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" +
                               dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:13%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"><div >" + " <a style=\"opacity:2;margin-top:-1%;\" class=\"tooltips\" title=\"\" onclick='return getdetails(this.href);' " +
                            " href=\"" + imgpath + dt.Rows[intRowBodyCount]["CAND_RESUMENAME"].ToString() + "\">" + dt.Rows[intRowBodyCount]["CAND_ACT_RESUMENAME"].ToString() + "</a></div> </td>";
                    }

                   


                }
            //0008
                strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"VIEW\" onclick=\"return OnBordId('" + Id + "');\" /></td>";

                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"opacity:2;margin-top:-1.3%;\"  class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                        " href=\"hcm_OnBoarding_Partial_Process.aspx?Id=" + Id + "\">" + "<img  style=\" cursor:pointer;\" src='/Images/Icons/edit.png' /> " + "</a> </td>";

          


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
        clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
        clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Onboaring_Partial_Process);
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
                objEntityPartialProcess.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityPartialProcess.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityPartialProcess.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityPartialProcess.ReqrmntId = Convert.ToInt32(ddlRqrmnt.SelectedItem.Value);
            if (txtAsgnedDate.Text.Trim() != "")
            {
                objEntityPartialProcess.AsgndDate = objCommon.textToDateTime(txtAsgnedDate.Text);
            }
            if (txtTodate.Text.Trim() != "")
            {
                objEntityPartialProcess.ToDate = objCommon.textToDateTime(txtTodate.Text);
            }

            DataTable dtAssgndProcess = new DataTable();
            dtAssgndProcess = objBusinessPartialProcess.ReadAssignedProcessList(objEntityPartialProcess);
            string strHtm = ConvertDataTableToHTML(dtAssgndProcess, intEnableAdd, intEnableModify);
            //Write to divReport
            divReport.InnerHtml = strHtm;

        }
    }
    public void ReqrmntLoad()
    {
        clsEntityOnBoardingPartialProcess objEntityPartialProcess = new clsEntityOnBoardingPartialProcess();
        clsBusinessLayerOnBoardingPartialProcess objBusinessPartialProcess = new clsBusinessLayerOnBoardingPartialProcess();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPartialProcess.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityPartialProcess.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPartialProcess.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dt = objBusinessPartialProcess.ReadReqrmtLoad(objEntityPartialProcess);
        ddlRqrmnt.Items.Clear();
        if (dt.Rows.Count > 0)
        {
            ddlRqrmnt.DataSource = dt;
            ddlRqrmnt.DataTextField = "NAME";
            ddlRqrmnt.DataValueField = "MNPRQST_ID";
            ddlRqrmnt.DataBind();

        }

        ddlRqrmnt.Items.Insert(0, "--SELECT--");
    }
 
}