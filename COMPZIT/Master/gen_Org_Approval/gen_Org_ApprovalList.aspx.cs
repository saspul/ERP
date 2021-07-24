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
// CREATED DATE:22/02/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_Org_Approval_Pending_gen_ApprovalList : System.Web.UI.Page
{
    public static string strParkId;

    protected void Page_Load(object sender, EventArgs e)
    {
        txtCnclReason.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {


            //Creating objects for business layer.
            clsBusinessLayerApproval objBusinessLayerApproval = new clsBusinessLayerApproval();



            if (Request.QueryString["RId"] != null)
            {//when Canceled

                string strRandomMixedId = Request.QueryString["RId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);


                DataTable dtOrg = new DataTable();
                dtOrg = objBusinessLayerApproval.Approval_Pending();

                string strHtm = ConvertDataTableToHTML(dtOrg);
                //Write to divReport
                divReport.InnerHtml = strHtm;

                hiddenRsnid.Value = strId;
                ModalPopupExtenderCncl.Show();



            }

           else if (Request.QueryString["AId"] != null)
            {//when Approved
                clsEntityLayerApproval objEntityApproval = new clsEntityLayerApproval();
                string strRandomMixedId = Request.QueryString["AId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityApproval.Park_id = Convert.ToInt32(strId);

                objEntityApproval.Status = 4;
                objEntityApproval.Date_Update = System.DateTime.Now;
                if (Session["USERID"] != null)
                {
                    objEntityApproval.UserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }

                //For status updation passing values to businesslayer
                objBusinessLayerApproval.Update_Organisation(objEntityApproval);
                Response.Redirect("gen_Org_ApprovalList.aspx?InsUpd=Aprv");


               



            }
            else
            {
                //to view
                DataTable dtOrg = new DataTable();
                dtOrg = objBusinessLayerApproval.Approval_Pending();

                string strHtm = ConvertDataTableToHTML(dtOrg);
                //Write to divReport
                divReport.InnerHtml = strHtm;

                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    if (strInsUpd == "Aprv")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproval", "SuccessApproval();", true);
                    }

                    else if (strInsUpd == "Rejct")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRejection", "SuccessRejection();", true);
                    }
                }
            }

        }

    }

    //It build the Html table by using the datatable provided
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

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%; word-wrap:break-word;text-align: center;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:34%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:34%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }


        }


        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";

        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";

        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            strHtml += "<tr  >";


            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 0)
                {
                    int intCnt = intRowBodyCount + 1;
                    strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + intCnt + "</td>";
                }

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:34%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:34%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }


            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;


            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return ApproveAlert(this.href);' " +
               " href=\"gen_Org_ApprovalList.aspx?AId=" + Id + "\">" + "<img  style=\"\" src='../../Images/Icons/Approve.png' /> " + "</a> </td>";

            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return RejectAlert(this.href);' " +
           " href=\"gen_Org_ApprovalList.aspx?RId=" + Id + "\">" + "<img  src='../../Images/Icons/Reject.png' /> " + "</a> </td>";


            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return getdetails(this.href);' " +
        " href=\"gen_Org_Approval.aspx?ViewParkId=" + Id + "\">" + "<img  style=\" \" src='../../Images/Icons/view.png' /> " + "</a> </td>";

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

        //Creating objects for business layer.
        clsBusinessLayerApproval objBusinessLayerApproval = new clsBusinessLayerApproval();
        clsEntityLayerApproval objEntityApproval = new clsEntityLayerApproval();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityApproval.Park_id = Convert.ToInt32(hiddenRsnid.Value);
            objEntityApproval.Status = 3;

            if (Session["USERID"] != null)
            {
                objEntityApproval.UserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityApproval.Date_Update = System.DateTime.Now;

            objEntityApproval.Reason = txtCnclReason.Text.Trim();
            objBusinessLayerApproval.Reject_Organisation(objEntityApproval);


            Response.Redirect("gen_Org_ApprovalList.aspx?InsUpd=Rejct");


        }
    }


}