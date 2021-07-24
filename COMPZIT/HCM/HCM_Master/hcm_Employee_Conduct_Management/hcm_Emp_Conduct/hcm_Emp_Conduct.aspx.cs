using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Text;
using System.Web.Services;

// CREATED BY:EVM-0008
// CREATED DATE:16/30/2018
// REVIEWED BY:
// REVIEW DATE:


public partial class HCM_HCM_Master_hcm_Emp_Conduct_hcm_Emp_Conduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hiddenStatus.Value = "0";
            txtDate.Enabled = false;
            txtReason.Enabled = false;
            txtEmpname.Enabled = false;
            txtMemoDesc.Enabled = false;
            clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
            clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

                objEntity.UserId = intUserId;

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

           
            


            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntity.ConductIncident_Id =Convert.ToInt32( strId);
                HiddenFieldQryString.Value = strId;
                DataTable dtconduct = objEmpConduct.readConductEmployeeById(objEntity);
                if (dtconduct != null)
                {
                    if (dtconduct.Rows.Count > 0)
                    {
                        lblEmpName.Text = dtconduct.Rows[0]["EMPLOYEE"].ToString();
                        lblDescription.Text = dtconduct.Rows[0]["CNDTINC_DESCRPTN"].ToString();
                        lblDate.Text = dtconduct.Rows[0]["DATE"].ToString();
                        lblPriority.Text = dtconduct.Rows[0]["PRIORITY"].ToString();
                        lblType.Text = dtconduct.Rows[0]["TYPE"].ToString();
                        int memo = Convert.ToInt32(dtconduct.Rows[0]["CNDTINC_MEMO_ISSUE"].ToString());

                        HiddenMemo.Value = memo.ToString();
                        if (memo == 1)
                        {

                            txtDate.Text = dtconduct.Rows[0]["ISSUEDATE"].ToString();
                            txtReason.Text = dtconduct.Rows[0]["M_REASON"].ToString();
                            txtMemoDesc.Text = dtconduct.Rows[0]["CNDTINC_CATGORYRSN"].ToString();
                            txtEmpname.Text = dtconduct.Rows[0]["REPORTING"].ToString();
                            showdiv.Visible = true;
                        }
                        else
                        {
                            showdiv.Visible = false;
                        }
                        int read = Convert.ToInt32(dtconduct.Rows[0]["CNDTINC_RECIVE"].ToString());
                        if (read == 0)
                        {
                            //cbxResive.Checked = true;
                            //cbxResive.Enabled = false;
                           
                        }
                        else
                        {
                            cbxResive.Checked = true;
                            cbxResive.Enabled = false;
                            hiddenStatus.Value = "1";
                          //  cbxResive.Checked = false;
                        }

                        if (Convert.ToInt32(dtconduct.Rows[0]["USR_ID"].ToString()) == intUserId)  //emp0025
                        {
                            txtreplay.Visible = true;
                            MessageHead.Visible = true;
                            btnSave.Visible = true;
                            btnSavenCls.Visible = true;
                            divSts.Visible = true;
                        }
                        else
                        {
                            txtreplay.Visible = false;
                            MessageHead.Visible = false;
                            btnSave.Visible = false;
                            btnSavenCls.Visible = false;
                            divSts.Visible = false;
                        }

                    }
                }
               
            }

            if (Request.QueryString["InsUpd"] != null)
            {
                string strRandomMixedId = Request.QueryString["InsUpd"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntity.ConductIncident_Id = Convert.ToInt32(strId);
                HiddenFieldQryString.Value = strId;
                DataTable dtconduct = objEmpConduct.readConductEmployeeById(objEntity);


                DataTable dtDisplayMsg1 = new DataTable();
                dtDisplayMsg1 = objEmpConduct.ReadMessage(objEntity);
                if (dtconduct != null)
                {
                    if (dtconduct.Rows.Count > 0)
                    {
                        lblEmpName.Text = dtconduct.Rows[0]["EMPLOYEE"].ToString();
                        lblDescription.Text = dtconduct.Rows[0]["CNDTINC_DESCRPTN"].ToString();
                        lblDate.Text = dtconduct.Rows[0]["DATE"].ToString();
                        lblPriority.Text = dtconduct.Rows[0]["PRIORITY"].ToString();
                        lblType.Text = dtconduct.Rows[0]["TYPE"].ToString();
                        int memo = Convert.ToInt32(dtconduct.Rows[0]["CNDTINC_MEMO_ISSUE"].ToString());
                        HiddenMemo.Value = memo.ToString();
                        if (memo == 1)
                        {

                            txtDate.Text = dtconduct.Rows[0]["ISSUEDATE"].ToString();
                            txtReason.Text = dtconduct.Rows[0]["M_REASON"].ToString();
                            txtMemoDesc.Text = dtconduct.Rows[0]["CNDTINC_CATGORYRSN"].ToString();
                            txtEmpname.Text = dtconduct.Rows[0]["REPORTING"].ToString();
                            showdiv.Visible = true;
                        }
                        else
                        {
                            showdiv.Visible = false;
                        }
                        int count = dtDisplayMsg1.Rows.Count;
                        if (count > 0)
                        {
                            txtDate.Text = dtconduct.Rows[0]["ISSUEDATE"].ToString();
                            txtReason.Text = dtconduct.Rows[0]["M_REASON"].ToString();
                            txtMemoDesc.Text = dtconduct.Rows[0]["CNDTINC_CATGORYRSN"].ToString();
                            txtEmpname.Text = dtconduct.Rows[0]["REPORTING"].ToString();
                            showdiv.Visible = true;
                        }

                        int read = Convert.ToInt32(dtconduct.Rows[0]["CNDTINC_RECIVE"].ToString());
                        if (read == 1)
                        {
                            cbxResive.Checked = true;
                            cbxResive.Enabled = false;
                            hiddenStatus.Value = "1";
                        }
                        else
                        {
                            cbxResive.Checked = false;
                        }

                        //if (Convert.ToInt32(dtconduct.Rows[0]["CNDTINC_CNFM_USR_ID"].ToString()) == intUserId)
                        //{

                        //    txtreplay.Visible = false;
                        //    btnSave.Visible = false;
                        //    btnSavenCls.Visible = false;
                        //    divSts.Visible = false;
                        //}
                        if (Convert.ToInt32(dtconduct.Rows[0]["USR_ID"].ToString()) == intUserId)  //emp0025
                        {
                            txtreplay.Visible = true;
                            MessageHead.Visible = true;
                            btnSave.Visible = true;
                            btnSavenCls.Visible = true;
                            divSts.Visible = true;
                        }
                        else
                        {
                            txtreplay.Visible = false;
                            MessageHead.Visible = false;
                           btnSave.Visible = false;
                           btnSavenCls.Visible = false;
                           divSts.Visible = false;
                           
                        }

                    }
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "ConductSuccessInsertion", "ConductSuccessInsertion();", true);
            }
          
           DataTable dtDisplayMsg = new DataTable();
          dtDisplayMsg = objEmpConduct.ReadMessage(objEntity);
       
          if (dtDisplayMsg.Rows.Count > 0)   //emp0025
          {
             
              divMsg.Visible = true;
          }
          else
          {
              divMsg.Visible = false;
          }
            int intEnableModify = 1, intEnableCancel = 1, intEnableRecall = 1;
            string strHtm = ConvertDataTableToHTML(dtDisplayMsg);
            //Write to divReport
           divList.InnerHtml = strHtm;


           //if (Request.QueryString["InsUpdMsg"] != null)
           //{
           //    string strInsUpd = Request.QueryString["InsUpdMsg"].ToString();
           //    if (strInsUpd == "CancelMsg")
           //    {
           //        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelMsg", "SuccessCancelMsg();", true);
           //    }
           //}
        }
                  
            
       
    }


    public string ConvertDataTableToHTML(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        int count = dt.Rows.Count;
        int maxintCondctId = int.MinValue;
        string strmaxintCondctId = "";
        string strEndTime = "";
        DateTime EndTime=DateTime.MinValue;
        foreach (DataRow dr in dt.Rows)
        {
            int intCondctId = dr.Field<int>("CNDTINCSUB_ID");
            maxintCondctId = Math.Max(maxintCondctId, intCondctId);
            string sEndTime = dt.Compute("max(CNDTINCSUB_DATE)", string.Empty).ToString();
            EndTime = objCommon.textToDateTime(sEndTime);
            strEndTime = EndTime.ToString("dd-MM-yyyy");
        }
        
        strmaxintCondctId = Convert.ToString(maxintCondctId);
        StringBuilder sb = new StringBuilder();
        foreach (DataRow Rowd in dt.Rows)
        {

            DateTime DATE;
            string strHtml;
            if (Rowd["CNDTINCSUB_STATUS"].ToString() == "0")
            {

                string strDate = Rowd["CNDTINCSUB_DATE"].ToString();
                string strtime = Rowd["CNDTINCSUB_DATETIME"].ToString();
                strHtml = "<div class=\"col-xs-12\" style=\" height:auto;text-align:left;padding-bottom:10px;\">";
                strHtml += " <div class=\"panel panel-info col-xs-10 arrow_left_box  padding-0\">";
                strHtml += "<div class=\"panel-heading\"> " + Rowd["CNDTINCSUB_MSG"].ToString() + "<div  style=\"color:#a9a7a7;padding-left: 10px;font-size: 12px;margin-top: 7px;\">" + strDate + strtime + "</div></div></div></div>";



            }
            else
            {
                string strId = Rowd["CNDTINCSUB_ID"].ToString();
                string strDate = Rowd["CNDTINCSUB_DATE"].ToString();
                string strtime = Rowd["CNDTINCSUB_DATETIME"].ToString();
                strHtml = "<div class=\"col-xs-12\" style=\" height:auto;text-align:right;padding-bottom:10px;\">";
                strHtml += " <div class=\"panel panel-default col-xs-11 arrow_right_box  padding-0\" style=\"float:right;\">";

                if (strmaxintCondctId == strId && strEndTime == strDate)
                {
                    strHtml += "<div class=\"panel-heading\"> " + Rowd["CNDTINCSUB_MSG"].ToString() + "<div  style=\"color:#a9a7a7;padding-left: 10px;font-size: 12px;margin-top: 7px;\">" + strDate + strtime + "<div class=\"smart-form\"> <img title=\"DELETE MESSAGE\" style=\"float: left;margin-top: -1%; cursor: pointer;\" onclick=\"return CancelEntry('" + strId + "');\" src=\"../../../../Images/Icons/removeQuotCatgry.png\" height=\"15px\" width=\"15px\" /></div></div></div></div></div>";
                }
                else
                {
                    strHtml += "<div class=\"panel-heading\"> " + Rowd["CNDTINCSUB_MSG"].ToString() + "<div  style=\"color:#a9a7a7;padding-left: 10px;font-size: 12px;margin-top: 7px;\">" + strDate + strtime + "</div></div></div></div>";
                }
            }


            sb.Append(strHtml);

        }

        return sb.ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
        clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UserId = intUserId;

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

        objEntity.ReplyExpln = 1;
        objEntity.Message = txtreplay.Text;
        objEntity.InsertDate = DateTime.Now;
        objEntity.ConductIncident_Id = Convert.ToInt32(HiddenFieldQryString.Value);

        string strId = HiddenFieldQryString.Value;
        int intIdLength = HiddenFieldQryString.Value.Length;
        string stridLength = intIdLength.ToString("00");
        string Id = stridLength + strId + strRandom;
        DataTable dtCancel = objEmpConduct.CancelNotPossible(objEntity);
        DataTable dtTermn = objEmpConduct.TerminationNotPossible(objEntity);
        if (dtCancel.Rows.Count > 0)
        {
            if (dtCancel.Rows[0]["CNDTINC_TRMNTN_USRID"].ToString() != "")
            {

                Session["MESSG_CONDINCDNT"] = "TERMINATED";
            }
            else if (dtCancel.Rows[0]["CNDTINC_CLS_USRID"].ToString() != "")
            {
                Session["MESSG_CONDINCDNT"] = "CLOSED";
            }
        }
        else if (dtTermn.Rows.Count > 0)
        {
            Session["MESSG_CONDINCDNT"] = "TERMNTN_UNDER_PRSS";
        }
        else
        {
            objEmpConduct.InsertConductReplay(objEntity);

            if (clickedButton.ID == "btnSave")
            {

                Response.Redirect("hcm_Emp_Conduct.aspx?InsUpd=" + Id);



            }
            else if (clickedButton.ID == "btnSavenCls")
            {
                Response.Redirect("hcm_Emp_Conduct_List.aspx?InsUpd=Ins");
            }

        }
    }

    [WebMethod]
    public static string[] CancelMessage(string IncidentSubID, string strId, string UsrId)
    {
        string[] a = new string[3];
        string strreturn = "";
        string strMsg = "";
        HCM_HCM_Master_hcm_Emp_Conduct_hcm_Emp_Conduct Obj = new HCM_HCM_Master_hcm_Emp_Conduct_hcm_Emp_Conduct();
        clsBusiness_Emp_Conduct_Incident objEmpConduct = new clsBusiness_Emp_Conduct_Incident();
        clsEntity_Emp_conduct_Incident objEntity = new clsEntity_Emp_conduct_Incident();
        objEntity.ConductSubIncident_Id = Convert.ToInt32(IncidentSubID);

        objEntity.UserId = Convert.ToInt32(UsrId);
        objEntity.ConductSubIncident_Id = Convert.ToInt32(IncidentSubID);
        objEntity.ConductIncident_Id = Convert.ToInt32(strId);

        DataTable dtCancel = objEmpConduct.CancelNotPossible(objEntity);
        DataTable dtTermn = objEmpConduct.TerminationNotPossible(objEntity);
        if (dtCancel.Rows.Count > 0)
        {
            if (dtCancel.Rows[0]["CNDTINC_TRMNTN_USRID"].ToString() != "")
            {

                strMsg = "TERMINATED";
            }
            else if (dtCancel.Rows[0]["CNDTINC_CLS_USRID"].ToString() != "")
            {
                strMsg = "CLOSED";
            }
        }
        else if (dtTermn.Rows.Count > 0)
        {
            strMsg = "TERMNTN_UNDER_PRSS";
        }
        else
        {
            objEmpConduct.CancelMessageBox(objEntity);
        }
        DataTable dtDisplayMsg = new DataTable();
        dtDisplayMsg = objEmpConduct.ReadMessage(objEntity);

        if (dtDisplayMsg.Rows.Count > 0)   //emp0025
        {

            strreturn = "T";
        }
        else
        {
            strreturn = "F";
        }
        a[0] = Obj.ConvertDataTableToHTML(dtDisplayMsg);
        a[1] = strreturn;
        a[2] = strMsg;

        return a;
    }
}