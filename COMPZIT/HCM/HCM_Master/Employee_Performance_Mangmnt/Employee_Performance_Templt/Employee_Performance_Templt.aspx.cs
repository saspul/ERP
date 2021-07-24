using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit;
using System.Data;
using System.Web.Services;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Globalization;
public partial class HCM_HCM_Master_Employee_Performance_Mangmnt_Employee_Performance_Templt_Employee_Performance_Templt : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["RFGP"] != null)
        {
          
            this.MasterPageFile = "~/MasterPage/MasterPage_Modal.master";

        }
        else
        {

            this.MasterPageFile = "~/MasterPage/MasterPageNewHcm.master";
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            txtPefmnceFrm.Focus();
            clsBusiness_Emp_Perfomance_Template objEmpPerfomance = new clsBusiness_Emp_Perfomance_Template();
            clsEntity_Emp_perfomance_Template objEntity = new clsEntity_Emp_perfomance_Template();
            hiddenUpdatevw.Value = "";
            HiddenConductId.Value = "";
            txtRefNo.Enabled = false;
            HiddenFieldView.Value = "0";
            ButtnClose.Visible = false;
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

                objEntity.UsrId = intUserId;

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                objEntity.CorpId = intCorpId;
                // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntity.OrgId = intOrgId;

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PERFOMANCE_TEMPLATE_REF);
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;
            string strNextId = objBusinessLayer.ReadNextNumber(objEntityCommon);
            string year = DateTime.Today.Year.ToString();
            string Month = DateTime.Today.Month.ToString();
            string timestamp = DateTime.UtcNow.ToString("fff", CultureInfo.InvariantCulture);
            txtRefNo.Text = "REF#"+""+timestamp + year + "" + strNextId;
         

            //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Perfomance_Tmplt);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleConf.Value = "1";
                    }
             


                }
            }

            if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
                bttnsave.Visible = false;
            }



       DataTable dtTempPerf= objEmpPerfomance.ReadPerfomanceTemplate(objEntity);
    
       if (dtTempPerf.Rows.Count > 0)
       {
           ddlPerfForm.DataSource = dtTempPerf;
           ddlPerfForm.DataTextField = "PRFMNC_TMPLT_FORM";
           ddlPerfForm.DataValueField = "PRFMNC_TMPLT_ID";
           ddlPerfForm.DataBind();

       }
       ddlPerfForm.ClearSelection();
       ddlPerfForm.Items.Insert(0, "--SELECT PERFORMANCE TEMPLATE--");
       ddlPerfForm.Focus();

            if (Request.QueryString["Id"] != null)
            {

                lblEntry.Text = "Edit Performance Template";

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                HiddenConductId.Value = strId;

                bttnsave.Visible = false;

                btnUpdate.Visible = true;

              //  btnClear.Visible = true;

                btnCancel.Visible = true;
               

                Update(strId);

            }
            else  if (Request.QueryString["ViewId"] != null)
            {

          
                lblEntry.Text = "View Performance Template";
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                HiddenConductId.Value = strId;

                bttnsave.Visible = false;

                btnUpdate.Visible = false;

               // btnClear.Visible = false;

                btnCancel.Visible = true;
                txtNote.Enabled = false;
                txtPefmnceFrm.Enabled = false;
                txtRefNo.Enabled = false;
                ddlRating.Enabled = false;
                Chksts.Enabled = false;
                HiddenFieldView.Value = "1";

                Update(strId);
                if (Request.QueryString["RFGP"] != null)
                {
                    divList.Visible = false;
                    btnCancel.Visible = false;
                    ButtnClose.Visible = true;
                }

            }

            else
            {
                lblEntry.Text = "Add Performance Template";
                btnUpdate.Visible = false;
            }


        }
        if (Request.QueryString["InsUpd"] != null)
        {
            string strInsUpd = Request.QueryString["InsUpd"].ToString();
            if (strInsUpd == "Ins")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);
            }
            else  if (strInsUpd == "Upd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdMsg", "SuccessUpdMsg();", true);
            }
            else if (strInsUpd == "UpdCancl")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CanclUpdMsg", "CanclUpdMsg();", true);
            }
            
            
        }
    }
    protected void bttnsave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusiness_Emp_Perfomance_Template objEmpPerfomance = new clsBusiness_Emp_Perfomance_Template();
        clsEntity_Emp_perfomance_Template objEntity = new clsEntity_Emp_perfomance_Template();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UsrId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntity.prfmncForm = txtPefmnceFrm.Text.Trim();
        objEntity.REFNo = txtRefNo.Text;
        objEntity.prfmncNote = txtNote.Text;
        objEntity.Rating = Convert.ToInt32(ddlRating.SelectedItem.Value);
        if (Chksts.Checked == true)
        {
            objEntity.Status = 1;
        }
        else
        {
            objEntity.Status = 0;
        }

        List<clsEntity_Emp_perfomance_Template> objEntityPerfomList = new List<clsEntity_Emp_perfomance_Template>();
        List<clsEntity_Emp_perfomance_Template> objEntityPerfomListGrps = new List<clsEntity_Emp_perfomance_Template>();
        if (HiddenFieldSaveTemplate.Value != "" && HiddenFieldSaveTemplate.Value != null && HiddenFieldSaveTemplate.Value != "[]")
        {
            string jsonDataDltAttch = HiddenFieldSaveTemplate.Value;
            string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
            string strAtt2 = strAtt1.Replace("\\", "");
            string strAtt3 = strAtt2.Replace("}\"]", "}]");
            string strAtt4 = strAtt3.Replace("}\",", "},");
            List<clsGrpDetails> objVideoDataDltAttList = new List<clsGrpDetails>();
            //   UserData  data
            objVideoDataDltAttList = JsonConvert.DeserializeObject<List<clsGrpDetails>>(strAtt4);

            foreach (clsGrpDetails objClsVideoAddAttData in objVideoDataDltAttList)
            {
                clsEntity_Emp_perfomance_Template objSubEntityGrp = new clsEntity_Emp_perfomance_Template();

              

                objSubEntityGrp.GrpName = Request.Form["inpGrpName_" + objClsVideoAddAttData.GROUPNUM];
                string QstnIdarr = objClsVideoAddAttData.QUSTNNUM;
                string[] values = QstnIdarr.Split(',');
                foreach (string str in values)
                {
                    clsEntity_Emp_perfomance_Template objSubEntity = new clsEntity_Emp_perfomance_Template();
                    objSubEntity.GrpName = Request.Form["inpGrpName_" + objClsVideoAddAttData.GROUPNUM];
                    objSubEntity.QstnText = Request.Form["txtQstn_" + str];
                    objSubEntity.RateSclaeId = Convert.ToInt32(Request.Form["txtddlValue_" + str]);
                    objSubEntity.KpiText = Request.Form["txtkpi_" + str];
                 //  string s= Request.Form["tdEvtQstn" + str];

                    objEntityPerfomList.Add(objSubEntity);
                }




                objEntityPerfomListGrps.Add(objSubEntityGrp);  

            }
        }




       objEmpPerfomance.InsertPerfomanceTemplate(objEntity, objEntityPerfomList, objEntityPerfomListGrps);
        if (clickedButton.ID == "bttnsave")
        {

            Response.Redirect("Employee_Performance_Templt.aspx?InsUpd=Ins");
        }

    }
    public void Update(string strP_Id)
    {
     
        clsBusiness_Emp_Perfomance_Template objEmpPerfomance = new clsBusiness_Emp_Perfomance_Template();
        clsEntity_Emp_perfomance_Template objEntity = new clsEntity_Emp_perfomance_Template();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UsrId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntity.PerfomanceId=Convert.ToInt32(strP_Id);

        txtRefNo.Enabled = false;
      
        DataTable dt = objEmpPerfomance.ReadPerfomanceByIdByid(objEntity);
        if (dt.Rows.Count > 0)
        {
           // ddlRating.Items.Clear();
            HiddenConductInsId.Value = dt.Rows[0]["PRFMNC_TMPLT_ID"].ToString();
            txtRefNo.Text = dt.Rows[0]["PRFMNC_TMPLT_REF"].ToString();
            txtPefmnceFrm.Text = dt.Rows[0]["PRFMNC_TMPLT_FORM"].ToString();
            txtNote.Text = dt.Rows[0]["PRFMNC_TMPLT_NOTE"].ToString();
      //   ddlRating.SelectedItem.Value = dt.Rows[0]["PRFMNC_TMPLT_RATING"].ToString();
         ddlRating.Items.FindByValue(dt.Rows[0]["PRFMNC_TMPLT_RATING"].ToString()).Selected = true;
         //  ddlRating.Items.FindByValue(dt.Rows[0]["PRFMNC_TMPLT_RATING"].ToString()).Selected = true;
            

            int STS =Convert.ToInt32( dt.Rows[0]["PRFMNC_TMPLT_STS"].ToString());
            if (STS == 0)
            {
                Chksts.Checked = false;
            }
            else
            {
                Chksts.Checked = true;
            }

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("TempId", typeof(int));
            dtDetail.Columns.Add("GrpName", typeof(string));
            dtDetail.Columns.Add("GrpId", typeof(int));
            dtDetail.Columns.Add("Qstnid", typeof(int));
            dtDetail.Columns.Add("QstnName", typeof(string));
            dtDetail.Columns.Add("Api", typeof(string));
            dtDetail.Columns.Add("Ratescaleid", typeof(int));
            // dtDetail.Columns.Add("VhclId", typeof(int));
            //  dtDetail.Columns.Add("Amount", typeof(decimal));
            string Groupid = "";

            for (int intcnt = 0; intcnt < dt.Rows.Count; intcnt++)
            {
             
                    DataRow drDtl = dtDetail.NewRow();
                    if (!(Groupid.Contains(dt.Rows[intcnt]["PRFMNC_GRP_NAME"].ToString())))
                    {
                        Groupid = Groupid + "," + dt.Rows[intcnt]["PRFMNC_GRP_NAME"].ToString();
                        drDtl["GrpName"] = dt.Rows[intcnt]["PRFMNC_GRP_NAME"].ToString();
                    }
                    else
                    {
                        drDtl["GrpName"] = "";
                    }
                    drDtl["TempId"] = Convert.ToInt32(dt.Rows[intcnt]["PRFMNC_TMPLT_ID"].ToString());
                  
                    drDtl["GrpId"] = Convert.ToInt32(dt.Rows[intcnt]["PRFMNC_GRP_ID"].ToString());
                    drDtl["Qstnid"] = Convert.ToInt32(dt.Rows[intcnt]["PRFMNC_QSTN_ID"].ToString());
                    drDtl["QstnName"] = dt.Rows[intcnt]["PRFMNC_QSTN"].ToString();
                    drDtl["Api"] = dt.Rows[intcnt]["PRFMNC_QSTN_KPI"].ToString();
                    drDtl["Ratescaleid"] = Convert.ToInt32(dt.Rows[intcnt]["PRFMNC_ANSWR_TYPE"].ToString());


                    dtDetail.Rows.Add(drDtl);
                

            }
            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            hiddenUpdatevw.Value = strJson;
                //else
                //{ 

             
            }

          

     
    }

    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);

            }

            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusiness_Emp_Perfomance_Template objEmpPerfomance = new clsBusiness_Emp_Perfomance_Template();
        clsEntity_Emp_perfomance_Template objEntity = new clsEntity_Emp_perfomance_Template();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UsrId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.CorpId = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.OrgId = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntity.PerfomanceId = Convert.ToInt32(HiddenConductInsId.Value);
        objEntity.prfmncForm = txtPefmnceFrm.Text.Trim();
        objEntity.REFNo = txtRefNo.Text;
        objEntity.prfmncNote = txtNote.Text;
        objEntity.Rating = Convert.ToInt32(ddlRating.SelectedItem.Value);
        if (Chksts.Checked == true)
        {
            objEntity.Status = 1;
        }
        else
        {
            objEntity.Status = 0;
        }
        List<clsEntity_Emp_perfomance_Template> objEntityPerfomList = new List<clsEntity_Emp_perfomance_Template>();
        List<clsEntity_Emp_perfomance_Template> objEntityPerfomListGrps = new List<clsEntity_Emp_perfomance_Template>();
        if (HiddenFieldSaveTemplate.Value != "" && HiddenFieldSaveTemplate.Value != null && HiddenFieldSaveTemplate.Value != "[]")
        {
            string jsonDataDltAttch = HiddenFieldSaveTemplate.Value;
            string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
            string strAtt2 = strAtt1.Replace("\\", "");
            string strAtt3 = strAtt2.Replace("}\"]", "}]");
            string strAtt4 = strAtt3.Replace("}\",", "},");
            List<clsGrpDetails> objVideoDataDltAttList = new List<clsGrpDetails>();
            //   UserData  data
            objVideoDataDltAttList = JsonConvert.DeserializeObject<List<clsGrpDetails>>(strAtt4);

            foreach (clsGrpDetails objClsVideoAddAttData in objVideoDataDltAttList)
            {
                clsEntity_Emp_perfomance_Template objSubEntityGrp = new clsEntity_Emp_perfomance_Template();



                objSubEntityGrp.GrpName = Request.Form["inpGrpName_" + objClsVideoAddAttData.GROUPNUM];
                objSubEntityGrp.GrpName = Request.Form["inpGrpName_" + objClsVideoAddAttData.GROUPNUM];
                objSubEntityGrp.EventText = Request.Form["tdEvtGrp" + objClsVideoAddAttData.GROUPNUM];
                if (objSubEntityGrp.EventText == "UPD")
                    objSubEntityGrp.GrpId = Convert.ToInt32(Request.Form["tdDtlIdGrp" + objClsVideoAddAttData.GROUPNUM]);

                string QstnIdarr = objClsVideoAddAttData.QUSTNNUM;
                string[] values = QstnIdarr.Split(',');
                foreach (string str in values)
                {
                    clsEntity_Emp_perfomance_Template objSubEntity = new clsEntity_Emp_perfomance_Template();

                    objSubEntity.GrpName = Request.Form["inpGrpName_" + objClsVideoAddAttData.GROUPNUM];
                    objSubEntity.EventText = Request.Form["tdEvtQstn" + str];
                    if (objSubEntity.EventText=="UPD")
                        objSubEntity.QstnId = Convert.ToInt32(Request.Form["tdDtlIdQstn" + str]);

                    objSubEntity.QstnText = Request.Form["txtQstn_" + str];
                    objSubEntity.RateSclaeId = Convert.ToInt32(Request.Form["txtddlValue_" + str]);
                    objSubEntity.KpiText = Request.Form["txtkpi_" + str];
                    //  string s= Request.Form["tdEvtQstn" + str];

                    objEntityPerfomList.Add(objSubEntity);
                }

              


                objEntityPerfomListGrps.Add(objSubEntityGrp);

            }
        }

        string strCanclDtlId = "";
        string[] strarrCancldtlIdsGrp = strCanclDtlId.Split(',');
        if (hiddenGrpCanclDtlId.Value != "" && hiddenGrpCanclDtlId.Value != null)
        {
            strCanclDtlId = hiddenGrpCanclDtlId.Value;
            strarrCancldtlIdsGrp = strCanclDtlId.Split(',');

        }

        string strCanclDtlIdQst = "";
        string[] strarrCancldtlIdsQst = strCanclDtlIdQst.Split(',');
        if (hiddenQstnCanclDtlId.Value != "" && hiddenQstnCanclDtlId.Value != null)
        {
            strCanclDtlIdQst = hiddenQstnCanclDtlId.Value;
            strarrCancldtlIdsQst = strCanclDtlIdQst.Split(',');

        }

        DataTable dt = objEmpPerfomance.ReadPerfomanceByIdByid(objEntity);
        if (dt.Rows.Count > 0)
        {

            objEmpPerfomance.UpdatePerfomanceTemplate(objEntity, objEntityPerfomList, objEntityPerfomListGrps, strarrCancldtlIdsQst, strarrCancldtlIdsGrp);
            if (clickedButton.ID == "btnUpdate")
            {

                Response.Redirect("Employee_Performance_Templt.aspx?InsUpd=Upd");
            }
        }
        else
        {
            Response.Redirect("Employee_Performance_Templt.aspx?InsUpd=UpdCancl");
        }

    }

      [WebMethod]
    public static string[] LoadGroupsAndQstns(string intPertempid, string intuserid, string intorgid, string intcorpid)
    {
        string[] result = new string[3];
        clsBusiness_Emp_Perfomance_Template objEmpPerfomance = new clsBusiness_Emp_Perfomance_Template();
        clsEntity_Emp_perfomance_Template objEntity = new clsEntity_Emp_perfomance_Template();

        objEntity.PerfomanceId = Convert.ToInt32(intPertempid);
        objEntity.OrgId = Convert.ToInt32(intorgid);
        objEntity.CorpId = Convert.ToInt32(intcorpid);
        DataTable dtTempPerf = objEmpPerfomance.ReadGrupsandQstnById(objEntity);
           StringBuilder sb = new StringBuilder();
           StringBuilder sbGrp = new StringBuilder();
           string Groupid = "";
           string CopyGroupid = "";
        if (dtTempPerf.Rows.Count > 0)
        {

            sb.Append("<table class=\"list-group bg-grey\" style=\"width:100%\" id=\"TableAddQstn\" >");
            for(int row1=0;row1<dtTempPerf.Rows.Count;row1++)
            {
                //string chkVal = dtTempPerf.Rows[row1]["PRFMNC_GRP_ID"].ToString();
                if (!(Groupid.Contains(dtTempPerf.Rows[row1]["PRFMNC_GRP_ID"].ToString())))
                {
                    Groupid = Groupid + "," + dtTempPerf.Rows[row1]["PRFMNC_GRP_ID"].ToString();
                    sb.Append("<tr class=\"list-group-item\" id=\"SelectRow" + dtTempPerf.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "\" >");

                    sb.Append("<td class=\"smart-form\"    style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;font-weight: bold;\">" + dtTempPerf.Rows[row1]["PRFMNC_GRP_NAME"].ToString() + "</td>");

                    sb.Append("</tr>");
                }

                sb.Append("<tr class=\"list-group-item\" id=\"SelectRow" + dtTempPerf.Rows[row1]["PRFMNC_QSTN_ID"].ToString() + "\" >");

                sb.Append("<td class=\"smart-form\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input type=\"checkbox\"  onkeypress=\"return DisableEnter(event);\"  value=\"" + dtTempPerf.Rows[row1]["PRFMNC_QSTN_ID"].ToString() + "\" id=\"cbMandatory" + dtTempPerf.Rows[row1]["PRFMNC_QSTN_ID"].ToString() + "\"><i  style=\"margin-top:-15%;\"></i></label></td>");
                 sb.Append("<td class=\"smart-form\" id=\"tdUsrName" + dtTempPerf.Rows[row1]["PRFMNC_QSTN_ID"].ToString() + "\" style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtTempPerf.Rows[row1]["PRFMNC_QSTN"].ToString() + "</td>");
                 sb.Append("<td class=\"smart-form\" id=\"tdRatg" + dtTempPerf.Rows[row1]["PRFMNC_QSTN_ID"].ToString() + "\" style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\">" + dtTempPerf.Rows[row1]["PRFMNC_ANSWR_TYPE"].ToString() + "</td>");
                 sb.Append("<td class=\"smart-form\" id=\"tdKpi" + dtTempPerf.Rows[row1]["PRFMNC_QSTN_ID"].ToString() + "\" style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\">" + dtTempPerf.Rows[row1]["PRFMNC_QSTN_KPI"].ToString() + "</td>");
               // sb.Append("<td id="tdUsrId' + RowNum + '" style="display: none;">' + USRID + '</td>");
                sb.Append("</tr>");
        
            }
             sb.Append("</table>");
        }

        if (dtTempPerf.Rows.Count > 0)
        {

            sbGrp.Append("<table class=\"list-group bg-grey\" style=\"width:100%\" id=\"TableGrp\" >");
            for (int row1 = 0; row1 < dtTempPerf.Rows.Count; row1++)
            {
                //string chkVal = dtTempPerf.Rows[row1]["PRFMNC_GRP_ID"].ToString();
                if (!(CopyGroupid.Contains(dtTempPerf.Rows[row1]["PRFMNC_GRP_ID"].ToString())))
                {
                    CopyGroupid = CopyGroupid + "," + dtTempPerf.Rows[row1]["PRFMNC_GRP_ID"].ToString();
                    sbGrp.Append("<tr class=\"list-group-item\" id=\"SelectRowGrp" + dtTempPerf.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "\" >");

                    sbGrp.Append("<td class=\"smart-form\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input onkeypress=\"return DisableEnter(event);\" type=\"checkbox\" value=\"" + dtTempPerf.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "\" id=\"cbGrpcpy" + dtTempPerf.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "\"><i  style=\"margin-top:-15%;\"></i></label></td>");
                    sbGrp.Append("<td class=\"smart-form\" id=\"tdGrpnameCpy" + dtTempPerf.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "\" style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtTempPerf.Rows[row1]["PRFMNC_GRP_NAME"].ToString() + "</td>");

                  

                    sbGrp.Append("</tr>");
                }

                sbGrp.Append("<tr style=\"display:none\" class=\"list-group-item\" id=\"SelectRowGrp" + dtTempPerf.Rows[row1]["PRFMNC_QSTN_ID"].ToString() + "\" >");
                sbGrp.Append("<td  class=\"" + dtTempPerf.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "\" id=\"tdQstNameCpy" + dtTempPerf.Rows[row1]["PRFMNC_QSTN_ID"].ToString() + "\" style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dtTempPerf.Rows[row1]["PRFMNC_QSTN"].ToString() + "</td>");


                sbGrp.Append("<td  class=\"" + dtTempPerf.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "\" id=\"tdRatgCpy" + dtTempPerf.Rows[row1]["PRFMNC_QSTN_ID"].ToString() + "\" style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\">" + dtTempPerf.Rows[row1]["PRFMNC_ANSWR_TYPE"].ToString() + "</td>");
                sbGrp.Append("<td  class=\"" + dtTempPerf.Rows[row1]["PRFMNC_GRP_ID"].ToString() + "\" id=\"tdKpiCpy" + dtTempPerf.Rows[row1]["PRFMNC_QSTN_ID"].ToString() + "\" style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\">" + dtTempPerf.Rows[row1]["PRFMNC_QSTN_KPI"].ToString() + "</td>");


              //  sb.Append("<td class=\"smart-form\" id=\"tdRatg" + dtTempPerf.Rows[row1]["PRFMNC_QSTN_ID"].ToString() + "\" style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\">" + dtTempPerf.Rows[row1]["PRFMNC_ANSWR_TYPE"].ToString() + "</td>");
             //   sb.Append("<td class=\"smart-form\" id=\"tdKpi" + dtTempPerf.Rows[row1]["PRFMNC_QSTN_ID"].ToString() + "\" style=\"width:15%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;\">" + dtTempPerf.Rows[row1]["PRFMNC_QSTN_KPI"].ToString() + "</td>");
                sbGrp.Append("</tr>");

            }
            sbGrp.Append("</table>");
        }

        result[0] = sb.ToString();
        result[1] = sbGrp.ToString();
        return result;

      }

      public class clsGrpDetails
      {
          public string GROUPNUM { get; set; }
          public string QUSTNNUM { get; set; }
          

         
      }

    
        
      [WebMethod]
      public static string DupChkForGrpName(string intGrpid,string intTempid, string intGrpname, string intuserid, string intorgid, string intcorpid)
    {
        string result = "true";
        clsBusiness_Emp_Perfomance_Template objEmpPerfomance = new clsBusiness_Emp_Perfomance_Template();
        clsEntity_Emp_perfomance_Template objEntity = new clsEntity_Emp_perfomance_Template();

        objEntity.GrpId = Convert.ToInt32(intGrpid);
        objEntity.GrpName = intGrpname;
        objEntity.UsrId = Convert.ToInt32(intuserid);
        objEntity.OrgId = Convert.ToInt32(intorgid);
        objEntity.CorpId = Convert.ToInt32(intcorpid);
          if(intTempid!="")
              objEntity.PerfomanceId = Convert.ToInt32(intTempid);
        DataTable DtDup = objEmpPerfomance.DuplicationCheckGrp(objEntity);
        if (DtDup.Rows.Count > 0)
        {
            int Intcount=Convert.ToInt32(DtDup.Rows[0]["GCOUNT"].ToString());
            if (Intcount > 0)
            {
                 result = "false";
            }
        }
        return result;
      }

    
}