using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using BL_Compzit;
using System.Web.Services;
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Collections.Generic;
using EL_Compzit;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

// CREATED BY:EVM-0005
// CREATED DATE:23/5/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class HCM_HCM_Master_gen_InterView_Panel_gen_InterView_Panel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Id"] != null)
        {

            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            FillInitialData(strId);
            hiddenManPwrRqstId.Value = strId;

            clsEntityLayer_InterViewPanel objEntityJobIntrvPanel = new clsEntityLayer_InterViewPanel();
            clsBusiness_Interview_Panel ObjBussinesIntrvPanel = new clsBusiness_Interview_Panel();
            objEntityJobIntrvPanel.ManPwrRqstId = Convert.ToInt32(strId);

            DataTable dtPanel = ObjBussinesIntrvPanel.ReadInterViewPanel(objEntityJobIntrvPanel);
            if (dtPanel.Rows.Count > 0)
            {
                hiddenInterViewPanelId.Value = dtPanel.Rows[0]["INTRVPNL_ID"].ToString();
            }
            else
            {
                hiddenInterViewPanelId.Value = "0";
            }
            DropDownEmployeeDataStore();

            if (Request.QueryString["InsUpd"] != null)
            {
                if (Request.QueryString["InsUpd"].ToString() == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
            }
        }
    }
    public void FillInitialData(string RqstId)
    {
        clsEntityLayer_InterViewPanel objEntityJobIntrvPanel = new clsEntityLayer_InterViewPanel();
        clsBusiness_Interview_Panel ObjBussinesIntrvPanel = new clsBusiness_Interview_Panel();
        objEntityJobIntrvPanel.ManPwrRqstId = Convert.ToInt32(RqstId);
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobIntrvPanel.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);

            hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobIntrvPanel.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrganisationId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobIntrvPanel.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtReqstDetail = ObjBussinesIntrvPanel.ReadManPwrReqstById(objEntityJobIntrvPanel);
        if (dtReqstDetail.Rows.Count > 0)
        {
            lblRefNum.Text = dtReqstDetail.Rows[0]["MNP_REFNUM"].ToString();
            lblNumber.Text = dtReqstDetail.Rows[0]["MNP_RESOURCENUM"].ToString();
            lblDesign.Text = dtReqstDetail.Rows[0]["DESIGNATION"].ToString(); ;
            lblDeprtmnt.Text = dtReqstDetail.Rows[0]["DEPARTMENT"].ToString();
            lblDateOfReq.Text = dtReqstDetail.Rows[0]["MNPRQST_DATE"].ToString();
            lblExprnce.Text = dtReqstDetail.Rows[0]["MNP_EXPERIENCE"].ToString() + "  Years";
            lblPaygrd.Text = dtReqstDetail.Rows[0]["PYGRD_NAME"].ToString();
            lblPrjct.Text = dtReqstDetail.Rows[0]["PROJECT"].ToString();

        }

        DataTable dtTempData = ObjBussinesIntrvPanel.ReadInterviewTempData(objEntityJobIntrvPanel);
        if (dtTempData.Rows.Count > 0)
        {
            hiddenTemplateId.Value = dtTempData.Rows[0]["INVTEM_ID"].ToString();
        }
        string sb = ConvertDataTableToHTML(dtTempData);
        divTemplateDetail.InnerHtml = sb;

    }
    public void DropDownEmployeeDataStore()
    {
        clsEntityLayer_InterViewPanel objEntityJobIntrvPanel = new clsEntityLayer_InterViewPanel();
        clsBusiness_Interview_Panel ObjBussinesIntrvPanel = new clsBusiness_Interview_Panel();
        if (Session["USERID"] != null)
        {
            objEntityJobIntrvPanel.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityJobIntrvPanel.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobIntrvPanel.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtEmployeeList = new DataTable();
        dtEmployeeList = ObjBussinesIntrvPanel.ReadEmployee(objEntityJobIntrvPanel);
        dtEmployeeList.TableName = "dtTableEmployee";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtEmployeeList.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenEmployeeDdlData.Value = result;
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


        strHtml += "<th class=\"thT\" style=\"width:6%;text-align: left; word-wrap:break-word;\">SL#</th>";

        strHtml += "<th class=\"thT\"  style=\"width:25%;text-align: left; word-wrap:break-word;\">SCHEDULE NAME</th>";

        strHtml += "<th class=\"thT\"  style=\"width:25%;text-align: left; word-wrap:break-word;\">CATEGORY</th>";

        strHtml += "<th class=\"thT\"  style=\"width:25%;text-align: left; word-wrap:break-word;\">TYPE</th>";

        strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">SCORING</th>";

        strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">PANEL</th>";

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";


        int count = 1;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {


            strHtml += "<tr  >";
            strHtml += "<td class=\"tdT\" style=\" width:6%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + count.ToString() + "</td>";
            count++;

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString().ToUpper()+ "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() +"</td>";
                }

                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    int intId = Convert.ToInt32(dt.Rows[intRowBodyCount][0]);
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + " <a class=\"tooltip\" title=\"Add Panel\" onclick=\"return openPanel('" + intId + "','" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "');\">"
                        + "<img style=\"margin-left: -23%;cursor: pointer;\"  src='/Images/Icons/interview_panel_vector.png' /> " + "</a> </td>";
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
    public static string DropdownEmployeeBind(string tableName, int CorpId, int OrgId)
    {
        clsEntityLayer_InterViewPanel objEntityJobIntrvPanel = new clsEntityLayer_InterViewPanel();
        clsBusiness_Interview_Panel ObjBussinesIntrvPanel = new clsBusiness_Interview_Panel();
        objEntityJobIntrvPanel.CorpOffice_Id = CorpId;
        objEntityJobIntrvPanel.Organisation_Id = OrgId;
        DataTable dtEmployeeList = new DataTable();
        dtEmployeeList = ObjBussinesIntrvPanel.ReadEmployee(objEntityJobIntrvPanel);
        dtEmployeeList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtEmployeeList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }
    [WebMethod]
    public static string ReadInterViewPanel(int intCorpId, int intOrgId, int PanelId, int TempDetail)
    {
        clsEntityLayer_InterViewPanel objEntityJobIntrvPanel = new clsEntityLayer_InterViewPanel();
        clsBusiness_Interview_Panel ObjBussinesIntrvPanel = new clsBusiness_Interview_Panel();
        objEntityJobIntrvPanel.CorpOffice_Id = intCorpId;
        objEntityJobIntrvPanel.Organisation_Id = intOrgId;
        objEntityJobIntrvPanel.IntrvPanelId = PanelId;
        objEntityJobIntrvPanel.TemplateDetailId = TempDetail;

        DataTable dtPanelDetail = ObjBussinesIntrvPanel.ReadInterViewPanelDetail(objEntityJobIntrvPanel);
        string strJsonData = "";

        if (dtPanelDetail.Rows.Count > 0)
        {

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("PANELDTLID", typeof(int));
            dtDetail.Columns.Add("PANELEMPID", typeof(int));
            dtDetail.Columns.Add("ISDEFAULT", typeof(int));


            foreach (DataRow RowData in dtPanelDetail.Rows)
            {
                DataRow drDtl = dtDetail.NewRow();

                drDtl["PANELDTLID"] = Convert.ToInt32(RowData["INTRVPNLDTL_ID"].ToString());
                drDtl["PANELEMPID"] = Convert.ToInt32(RowData["USR_ID"].ToString());
                drDtl["ISDEFAULT"] = Convert.ToInt32(RowData["INTRVPNLDTL_DFLT_STS"].ToString());

                dtDetail.Rows.Add(drDtl);
            }


            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dtDetail.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtDetail.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);

                }

                parentRow.Add(childRow);
            }


            strJsonData = jsSerializer.Serialize(parentRow);
        }
        return strJsonData;

    }
    [WebMethod]
    public static string AddInterViewPanel(int intCorpId, int intOrgId, int RqstId, int Temp, int TempDetail, List<string> TotalDetail)
    {
        clsEntityLayer_InterViewPanel objEntityJobIntrvPanel = new clsEntityLayer_InterViewPanel();
        clsBusiness_Interview_Panel ObjBussinesIntrvPanel = new clsBusiness_Interview_Panel();
        string success = "true";

        objEntityJobIntrvPanel.Organisation_Id = intOrgId;
        objEntityJobIntrvPanel.CorpOffice_Id = intCorpId;
        objEntityJobIntrvPanel.ManPwrRqstId = RqstId;
        objEntityJobIntrvPanel.TemplateId = Temp;

        List<clsEntityLayer_InterViewPanel_Dtl> objEntityJobIntrvPanelDtlList = new List<clsEntityLayer_InterViewPanel_Dtl>();

        string jsonDataPanel = "";
        string a = jsonDataPanel.Replace("\"{", "\\{");
        string b = a.Replace("\\n", "\r\n");
        string c = b.Replace("\\", "");
        string d = c.Replace("}\"]", "}]");
        string k = d.Replace("}\",", "},");

        List<clsPanelData> objPanelData = new List<clsPanelData>();
        objPanelData = JsonConvert.DeserializeObject<List<clsPanelData>>(k);
        for (int count = 0; count < objPanelData.Count; count++)
        {
            clsEntityLayer_InterViewPanel_Dtl objEntityJobIntrvPanelDtl = new clsEntityLayer_InterViewPanel_Dtl();

            objEntityJobIntrvPanelDtl.EmpId = Convert.ToInt32(objPanelData[count].DDLVALUE);
            objEntityJobIntrvPanelDtl.DfltStsId = Convert.ToInt32(objPanelData[count].CHKBXVALUE);

            objEntityJobIntrvPanelDtlList.Add(objEntityJobIntrvPanelDtl);

        }
        try
        {
            ObjBussinesIntrvPanel.Insert_Interv_Panel(objEntityJobIntrvPanel, objEntityJobIntrvPanelDtlList);
        }
        catch
        {
            success = "false";
        }
        return success;
    }


    [WebMethod]
    public static string UpdateInterViewPanel(int PanelId, int Temp, int TempDetail, int intCorpId, List<string> TotalDetail)
    {
        clsEntityLayer_InterViewPanel objEntityJobIntrvPanel = new clsEntityLayer_InterViewPanel();
        clsBusiness_Interview_Panel ObjBussinesIntrvPanel = new clsBusiness_Interview_Panel();
        string success = "true";

        objEntityJobIntrvPanel.TemplateId = Temp;

        List<clsEntityLayer_InterViewPanel_Dtl> objEntityJobIntrvPanelDtlListAdd = new List<clsEntityLayer_InterViewPanel_Dtl>();
        List<clsEntityLayer_InterViewPanel_Dtl> objEntityJobIntrvPanelDtlListUpd = new List<clsEntityLayer_InterViewPanel_Dtl>();
        string jsonDataPanel = "";
        string a = jsonDataPanel.Replace("\"{", "\\{");
        string b = a.Replace("\\n", "\r\n");
        string c = b.Replace("\\", "");
        string d = c.Replace("}\"]", "}]");
        string k = d.Replace("}\",", "},");

        List<clsPanelData> objPanelData = new List<clsPanelData>();
        objPanelData = JsonConvert.DeserializeObject<List<clsPanelData>>(k);
        for (int count = 0; count < objPanelData.Count; count++)
        {
            clsEntityLayer_InterViewPanel_Dtl objEntityJobIntrvPanelDtlAdd = new clsEntityLayer_InterViewPanel_Dtl();
            clsEntityLayer_InterViewPanel_Dtl objEntityJobIntrvPanelDtlUpd = new clsEntityLayer_InterViewPanel_Dtl();

            if (objPanelData[count].EVTACTION == "INS")
            {
                objEntityJobIntrvPanelDtlAdd.Panelid = PanelId;
                objEntityJobIntrvPanelDtlAdd.TempId = Temp;
                objEntityJobIntrvPanelDtlAdd.TempDtlId = TempDetail;
                objEntityJobIntrvPanelDtlAdd.CorpId = intCorpId;
                objEntityJobIntrvPanelDtlAdd.EmpId = Convert.ToInt32(objPanelData[count].DDLVALUE);
                objEntityJobIntrvPanelDtlAdd.DfltStsId = Convert.ToInt32(objPanelData[count].CHKBXVALUE);

                objEntityJobIntrvPanelDtlListAdd.Add(objEntityJobIntrvPanelDtlAdd);
            }
            else
                if (objPanelData[count].EVTACTION == "UPD")
                {
                    objEntityJobIntrvPanelDtlUpd.Panelid = PanelId;
                    objEntityJobIntrvPanelDtlUpd.TempId = Temp;
                    objEntityJobIntrvPanelDtlUpd.TempDtlId = TempDetail;
                    objEntityJobIntrvPanelDtlUpd.EmpId = Convert.ToInt32(objPanelData[count].DDLVALUE);
                    objEntityJobIntrvPanelDtlUpd.DfltStsId = Convert.ToInt32(objPanelData[count].CHKBXVALUE);
                    objEntityJobIntrvPanelDtlUpd.PanelDtlId = Convert.ToInt32(objPanelData[count].DTLID);
                    objEntityJobIntrvPanelDtlListUpd.Add(objEntityJobIntrvPanelDtlUpd);
                }

        }
        try
        {
            ObjBussinesIntrvPanel.Update_Interv_Panel(objEntityJobIntrvPanelDtlListAdd, objEntityJobIntrvPanelDtlListUpd);
        }
        catch
        {
            success = "false";
        }
        return success;
    }
    public class clsPanelData
    {
        public string ROWID { get; set; }
        public string DDLVALUE { get; set; }
        public string CHKBXVALUE { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }
    }

    public class clsPanelDataDel
    {
        public string ROWID { get; set; }
        public string DTLID { get; set; }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        clsEntityLayer_InterViewPanel objEntityJobIntrvPanel = new clsEntityLayer_InterViewPanel();
        clsBusiness_Interview_Panel ObjBussinesIntrvPanel = new clsBusiness_Interview_Panel();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobIntrvPanel.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);

            hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobIntrvPanel.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobIntrvPanel.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityJobIntrvPanel.ManPwrRqstId = Convert.ToInt32(hiddenManPwrRqstId.Value);

        DataTable dtPanel = ObjBussinesIntrvPanel.ReadInterViewPanel(objEntityJobIntrvPanel);
        if (dtPanel.Rows.Count > 0)
        {
            hiddenInterViewPanelId.Value = dtPanel.Rows[0]["INTRVPNL_ID"].ToString();


            List<clsEntityLayer_InterViewPanel_Dtl> objEntityJobIntrvPanelDtlListAdd = new List<clsEntityLayer_InterViewPanel_Dtl>();
            List<clsEntityLayer_InterViewPanel_Dtl> objEntityJobIntrvPanelDtlListUpd = new List<clsEntityLayer_InterViewPanel_Dtl>();
            List<clsEntityLayer_InterViewPanel_Dtl> objEntityJobIntrvPanelDtlListDelete = new List<clsEntityLayer_InterViewPanel_Dtl>();
            string jsonDataPanel = hiddenTotalDetailOfPanel.Value;
            if (jsonDataPanel != null && jsonDataPanel != "[]" && jsonDataPanel != "")
            {
                string a = jsonDataPanel.Replace("\"{", "\\{");
                string b = a.Replace("\\n", "\r\n");
                string c = b.Replace("\\", "");
                string d = c.Replace("}\"]", "}]");
                string k = d.Replace("}\",", "},");

                List<clsPanelData> objPanelData = new List<clsPanelData>();
                objPanelData = JsonConvert.DeserializeObject<List<clsPanelData>>(k);
                for (int count = 0; count < objPanelData.Count; count++)
                {
                    clsEntityLayer_InterViewPanel_Dtl objEntityJobIntrvPanelDtlAdd = new clsEntityLayer_InterViewPanel_Dtl();
                    clsEntityLayer_InterViewPanel_Dtl objEntityJobIntrvPanelDtlUpd = new clsEntityLayer_InterViewPanel_Dtl();

                    if (objPanelData[count].EVTACTION == "INS")
                    {
                        objEntityJobIntrvPanelDtlAdd.Panelid = Convert.ToInt32(hiddenInterViewPanelId.Value);
                        objEntityJobIntrvPanelDtlAdd.TempId = Convert.ToInt32(hiddenTemplateId.Value);
                        objEntityJobIntrvPanelDtlAdd.TempDtlId = Convert.ToInt32(hiddenTemplateDetailId.Value);
                        objEntityJobIntrvPanelDtlAdd.CorpId = Convert.ToInt32(hiddenCorporateId.Value);
                        objEntityJobIntrvPanelDtlAdd.EmpId = Convert.ToInt32(objPanelData[count].DDLVALUE);
                        objEntityJobIntrvPanelDtlAdd.DfltStsId = Convert.ToInt32(objPanelData[count].CHKBXVALUE);

                        objEntityJobIntrvPanelDtlListAdd.Add(objEntityJobIntrvPanelDtlAdd);
                    }
                    else
                        if (objPanelData[count].EVTACTION == "UPD")
                        {
                            objEntityJobIntrvPanelDtlUpd.Panelid = Convert.ToInt32(hiddenInterViewPanelId.Value);
                            objEntityJobIntrvPanelDtlUpd.TempId = Convert.ToInt32(hiddenTemplateId.Value);
                            objEntityJobIntrvPanelDtlUpd.TempDtlId = Convert.ToInt32(hiddenTemplateDetailId.Value);
                            objEntityJobIntrvPanelDtlUpd.EmpId = Convert.ToInt32(objPanelData[count].DDLVALUE);
                            objEntityJobIntrvPanelDtlUpd.DfltStsId = Convert.ToInt32(objPanelData[count].CHKBXVALUE);
                            objEntityJobIntrvPanelDtlUpd.PanelDtlId = Convert.ToInt32(objPanelData[count].DTLID);
                            objEntityJobIntrvPanelDtlListUpd.Add(objEntityJobIntrvPanelDtlUpd);
                        }

                }
                try
                {
                    ObjBussinesIntrvPanel.Update_Interv_Panel(objEntityJobIntrvPanelDtlListAdd, objEntityJobIntrvPanelDtlListUpd);
                }
                catch
                {

                }

            }


               string jsonDataPanelDel = hiddenPanelDetailDelete.Value;
               string[] strarrCancldtlIds = jsonDataPanelDel.Split(',');

                foreach (string strDtlId in strarrCancldtlIds)
                {
                    if (strDtlId != "" && strDtlId != null)
                    {
                        int intDtlId = Convert.ToInt32(strDtlId);
                        clsEntityLayer_InterViewPanel_Dtl objEntityJobIntrvPanelDtlDel = new clsEntityLayer_InterViewPanel_Dtl();

                        objEntityJobIntrvPanelDtlDel.PanelDtlId = Convert.ToInt32(strDtlId);
                        objEntityJobIntrvPanelDtlListDelete.Add(objEntityJobIntrvPanelDtlDel);
                    }
                }
                ObjBussinesIntrvPanel.Delete_Interv_Panel(objEntityJobIntrvPanelDtlListDelete);
          

           

        }
        else
        {


            objEntityJobIntrvPanel.TemplateId = Convert.ToInt32(hiddenTemplateId.Value);
            objEntityJobIntrvPanel.TemplateDetailId = Convert.ToInt32(hiddenTemplateDetailId.Value);
            List<clsEntityLayer_InterViewPanel_Dtl> objEntityJobIntrvPanelDtlList = new List<clsEntityLayer_InterViewPanel_Dtl>();

            string jsonDataPanel = hiddenTotalDetailOfPanel.Value;
            if (jsonDataPanel != null && jsonDataPanel != "[]" && jsonDataPanel != "")
            {
                string a = jsonDataPanel.Replace("\"{", "\\{");
                string b = a.Replace("\\n", "\r\n");
                string c = b.Replace("\\", "");
                string d = c.Replace("}\"]", "}]");
                string k = d.Replace("}\",", "},");

                List<clsPanelData> objPanelData = new List<clsPanelData>();
                objPanelData = JsonConvert.DeserializeObject<List<clsPanelData>>(k);
                for (int count = 0; count < objPanelData.Count; count++)
                {
                    clsEntityLayer_InterViewPanel_Dtl objEntityJobIntrvPanelDtl = new clsEntityLayer_InterViewPanel_Dtl();

                    objEntityJobIntrvPanelDtl.EmpId = Convert.ToInt32(objPanelData[count].DDLVALUE);
                    objEntityJobIntrvPanelDtl.DfltStsId = Convert.ToInt32(objPanelData[count].CHKBXVALUE);

                    objEntityJobIntrvPanelDtlList.Add(objEntityJobIntrvPanelDtl);

                }
                try
                {
                    ObjBussinesIntrvPanel.Insert_Interv_Panel(objEntityJobIntrvPanel, objEntityJobIntrvPanelDtlList);


                }
                catch
                {

                }
            }
        }

        Response.Redirect("gen_InterView_Panel.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Ins");


    }
}