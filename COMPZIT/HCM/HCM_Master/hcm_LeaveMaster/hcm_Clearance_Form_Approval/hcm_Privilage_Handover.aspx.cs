using BL_Compzit.BusineesLayer_HCM;
using CL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HCM_HCM_Master_hcm_LeaveMaster_hcm_Clearance_Form_Approval_hcm_Privilage_Handover : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsBusinessLayerClearanceFormWorker objBusinessLeaveApproval = new clsBusinessLayerClearanceFormWorker();
        clsEntityLayerClearanceFormWorker ObjEntityLeaveApproval = new clsEntityLayerClearanceFormWorker();
        if (Session["USERID"] != null)
        {
            ObjEntityLeaveApproval.User_Id = Convert.ToInt32(Session["USERID"]);
            //intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityLeaveApproval.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
           // intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityLeaveApproval.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntityLeaveApproval.Empid = 10027;
        DataTable dtTOtallve = objBusinessLeaveApproval.ReadHadover(ObjEntityLeaveApproval);

        string strHtm1 = ConvertDataTableToHTML(dtTOtallve);
        //Write to divReport
        divmodalPopup.InnerHtml = strHtm1;


    }//It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt)
    {


        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        int count = 0;
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL#</th>";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:38%;text-align: left; word-wrap:break-word;\">Subject</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:22%;text-align: left; word-wrap:break-word;\">Decision</th>";
            }

            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:22%;text-align: left; word-wrap:break-word;\">Comments</th>";
            }




        }


      



        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        int staffworker = 0;
        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            count = intRowBodyCount + 1;
           



            strHtml += "<tr  >";

            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count + "</a> </td>";

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
             


                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:38%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                          strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\"><select onchange=\"Changeddl('1',event);\" style=\"line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 99%; margin-left: 0.1%;\"id =\"ddlDecision"+intRowBodyCount+"\"class=\"form1\"><option value =\"0\">--DECISION--</option><option value =\"1\">APPORVED</option><option value =\"2\">PENDING</option><option value =\"3\">AWAITING THE CANDIDATE ACTION</option></select></td>";

                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\"><input name=\"txtComments\" maxlength=\"99\" id=\"txtComments"+intRowBodyCount+"\" class=\"form1\" onkeypress=\"return isTag(event)\" onchange=\"IncrmntConfrmCounter()\" style=\"width:55%; margin-right:5%; text-transform: uppercase;\" type=\"text\"></td>";

                }

            }


            strHtml += "<td id=\"tdid" + intRowBodyCount + "\"  class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;display:none\"  >" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";


            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    public class clsHandover
    {
        public string DECSNID { get; set; }
        public string COMNTS { get; set; }
        public string TBLID { get; set; }

    }

    protected void btnProcessSingleSave_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerClearanceFormWorker objBusinessLeaveApproval = new clsBusinessLayerClearanceFormWorker();
       // clsEntityLayerClearanceFormWorker ObjEntityLeaveApproval = new clsEntityLayerClearanceFormWorker();
        //For schedule level detail table
        List<clsEntityLayerClearanceFormWorker> objEntityJobSubmsnDtlList = new List<clsEntityLayerClearanceFormWorker>();
        string jsonDataPW = hiddenjsondtails.Value;
        string R1PW = jsonDataPW.Replace("\"{", "\\{");
        string R2PW = R1PW.Replace("\\n", "\r\n");
        string R3PW = R2PW.Replace("\\", "");
        string R4PW = R3PW.Replace("}\"]", "}]");
        string R5PW = R4PW.Replace("}\",", "},");
        List<clsHandover> objWBDataPWList = new List<clsHandover>();
        // UserData  data
        if (hiddenjsondtails.Value != null )
        {
            objWBDataPWList = JsonConvert.DeserializeObject<List<clsHandover>>(R5PW);
            foreach (clsHandover objclsJSData in objWBDataPWList)
            {
                if (objclsJSData.TBLID.ToString() != "")
                {

                    clsEntityLayerClearanceFormWorker ObjEntityLeaveApproval = new clsEntityLayerClearanceFormWorker();
                    ObjEntityLeaveApproval.Subtableid = Convert.ToInt32(objclsJSData.TBLID);
                    ObjEntityLeaveApproval.Decision = Convert.ToInt32(objclsJSData.DECSNID);
                    ObjEntityLeaveApproval.Comments =objclsJSData.COMNTS;
                   
                     objEntityJobSubmsnDtlList.Add(ObjEntityLeaveApproval);
                }
            }

        }
            objBusinessLeaveApproval.UpdateHadover(objEntityJobSubmsnDtlList);
    }
}