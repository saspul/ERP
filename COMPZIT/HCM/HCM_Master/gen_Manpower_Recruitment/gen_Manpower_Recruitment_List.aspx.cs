using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HCM_HCM_Master_gen_Manpower_Recruitment_gen_Manpower_Recruitment_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ddldepartment.Focus();  //emp00025
        //DepartmentLoad();
        if (!IsPostBack)
        {
            LoadRole();
          
         //  DivisionLoad();
            DepartmentLoad();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
                      clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayerManpowerRecruitment objBusinessMNPWRDetails = new clsBusinessLayerManpowerRecruitment();
            CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
            int intUserId = 0, intcorpid=0,intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0,intEnableConfirm=0,intEnableReOpen=0, intEnableClose=0,intEnableCancel = 0, intEnableRecall = 0, intEnableHrConfirm = 0, intEnableGMApprove = 0;

            // objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.VEHICLE_MASTER);
            /// objEntityCommon.CommonLabelFieldName = "VHCL_PERMIT_NUMBR";
            if (Session["CORPOFFICEID"] != null)
            {
                Hiddencorpid.Value = Session["CORPOFFICEID"].ToString();
                intcorpid=Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                Hiddenorgid.Value = Session["ORGID"].ToString();
                ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                hiddenUsrId.Value = Session["USERID"].ToString();
                intUserId = Convert.ToInt32(Session["USERID"]);
                ObjEntityManpowerRecruitment.UserId = Convert.ToInt32(Session["USERID"]);
            
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
            DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
            if (dtCancelRecall.Rows.Count > 0)
            {
                intEnableRecall = 0;
            }
            else
            {
                intEnableRecall = 0;
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Mapower_Requirement);
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
                        Hiddenenabledit.Value = intEnableModify.ToString(); ;
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        Hiddenenablecancl.Value = intEnableCancel.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                    {
                        intEnableHrConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        HiddenHrCnfrm.Value = intEnableHrConfirm.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString())
                    {
                        intEnableGMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        HiddenGMApprove.Value = intEnableGMApprove.ToString(); 

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                    {
                        intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                    }

                }
            }

            if (intEnableConfirm != 1)
            {
                ListItem removeItem = ddrole.Items.FindByText("DIVISION MANAGER");
                ddrole.Items.Remove(removeItem);

            }
            if (intEnableHrConfirm != 1)
            {
                ListItem removeItem = ddrole.Items.FindByText("HR");
                ddrole.Items.Remove(removeItem);

            }
            if (intEnableGMApprove != 1)
            {
                ListItem removeItem = ddrole.Items.FindByText("GENERAL MANAGER");
                ddrole.Items.Remove(removeItem);

            }

            if (intEnableConfirm == 1)
            {
                ObjEntityManpowerRecruitment.Role_id = 0;

            }

            else if (intEnableHrConfirm == 1)
            {
               ObjEntityManpowerRecruitment.Role_id = 1;
            
            }
            else if (intEnableGMApprove == 1)
                {
                    ObjEntityManpowerRecruitment.Role_id = 2;
                }
                else
                {
                }

            if (intEnableAdd == 0)
                divAdd.Visible = false;
            if (Request.QueryString["canId"] != null)
            {//when Canceled

                string strRandomMixedId = Request.QueryString["canId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(strId);
                ObjEntityManpowerRecruitment.UserId = intUserId;

                ObjEntityManpowerRecruitment.RequestDate1 = System.DateTime.Now;



                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                DataTable dtCorpDetail = new DataTable();
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intcorpid);
                if (dtCorpDetail.Rows.Count > 0)
                {
                    string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                    if (CnclrsnMust == "0")
                    {
                        ObjEntityManpowerRecruitment.Cancel_Reason = objCommon.CancelReason();

                        objBusinessMNPWRDetails.CancelManpowerRecruitmentById(ObjEntityManpowerRecruitment);
                        if (HiddenSearchField.Value == "")
                        {
                            Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Cncl");
                        }
                        else
                        {
                            Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                        }

                    }
                    else
                    {

                        hiddenRsnid.Value = strId;

                    }
                }
            }
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
                else if (strInsUpd == "Appr")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproved", "SuccessApproved();", true);
                }
                else if (strInsUpd == "Reopen")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
                }
                else if (strInsUpd == "Close")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose", "SuccessClose();", true);
                }
                else if (strInsUpd == "Rejctd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRejected", "SuccessRejected();", true);
                }
                else if (strInsUpd == "verify")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessVerified", "SuccessVerified();", true);
                }
            }




                    DataTable dtManpower = objBusinessMNPWRDetails.ReadManpower_search(ObjEntityManpowerRecruitment);
       
                 string strHtm = ConvertDataTableToHTML(dtManpower, intEnableModify, intEnableCancel, intEnableRecall);
            //Write to divReport
            divReport.InnerHtml = strHtm;
        }
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
        int intCnclUsrId=0;
        int intReCallForTAble = 0;

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
             intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

            if (intCnclUsrId != 0)
            {
                intReCallForTAble = 0;
            }

        }

      //  strHtml += "<th class=\"thT\" style=\"width:2%;text-align: left; word-wrap:break-word;\">" +"SL#" +"</th>";
       

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" href=\"#\"  style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" href=\"#\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" href=\"#\"  style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  href=\"#\"  style=\"width:8%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  href=\"#\"  style=\"width:5%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" href=\"#\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

       
    


        }
        strHtml += "<th class=\"thT\" href=\"#\"  style=\"width:4%; word-wrap:break-word;text-align: center;\">STATUS</th>";

        if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (intCnclUsrId == 0)
            {


                strHtml += "<th  href=\"#\" class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            }
            else
                strHtml += "<th href=\"#\" class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
      
        }
        else
            strHtml += "<th href=\"#\"  class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
        if (intCnclUsrId == 0)
        {
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

                strHtml += "<th  href=\"#\" class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">CANCEL</th>";

            }

        }
        strHtml += "<th  href=\"#\" class=\"thT\" style=\"width:8%; word-wrap:break-word;text-align: center;\">REQUIREMENT STATUS</th>";

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strStatusMode = "";
            int intappstatus = Convert.ToInt32(dt.Rows[intRowBodyCount]["MNP_PROCESS_STATUS"].ToString());
           int intrejectedctdstatus = Convert.ToInt32(dt.Rows[intRowBodyCount]["REJECT_STATUS"].ToString());
            int intstatus;

           
            if (dt.Rows[intRowBodyCount]["MNP_CONFIRM"].ToString() == "")
            {
                intstatus = 0;
            }
            else
                intstatus = Convert.ToInt32(dt.Rows[intRowBodyCount]["MNP_CONFIRM"].ToString());
            intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            //int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());
            int slno = intRowBodyCount + 1;
            strHtml += "<tr  >";
           // strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";

            string strId = dt.Rows[intRowBodyCount][8].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][8].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;


            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
                if (intColumnBodyCount == 0)
                {
               // strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a href=\"#\"  class=\"tooltip\"  style=\"cursor:pointer;color: blue;\"  title=\"Go To View\"      onclick=\"return ManPowerId('" + Id + "');\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a> </td>";
                }
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
               {
                   strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            
        

            }


        
            strStatusMode = dt.Rows[intRowBodyCount][6].ToString();
            
            if (intCnclUsrId == 0)
            {
                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (strStatusMode == "ACTIVE")
                    {
                        strHtml += "<td    class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a href=\"#\"   class=\"tooltip\" title=\"Make Inactive\"   onclick=\"return ChangeEntryStatus('" + strId + "','" + strStatusMode + "');\" >" +
                            "<img   style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td    class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a href=\"#\" class=\"tooltip\" title=\" Make Active\" onclick=\"return ChangeEntryStatus('" + strId + "','" + strStatusMode + "');\" >" +
                          "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                    }
                }
                else
                {
                    if (strStatusMode == "ACTIVE")
                    {
                        strHtml += "<td     class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a href=\"#\" class=\"tooltip\" title=\"Make Inactive\" >" +
                            "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td   class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a href=\"#\"  class=\"tooltip\" title=\" Make Active\" >" +
                          "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                    }
                }

            }
            else
            {
                if (strStatusMode == "ACTIVE")
                {
                    strHtml += "<td   class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a href=\"#\"  class=\"tooltip\" title=\"Make Active\" >" +
                        "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                }
                else
                {
                    strHtml += "<td   class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a href=\"#\" class=\"tooltip\" title=\" Make Inactive\" >" +
                      "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                }
            }

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {
                    if (intstatus != 1)
                    {
                        strHtml += "<td   class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                      " href=\"gen_Manpower_Recruitment.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


                    }
                    else
                    {

                        strHtml += "<td     class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                   " href=\"gen_Manpower_Recruitment.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                    }


                }
                else
                {
                    strHtml += "<td    class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                     " href=\"gen_Manpower_Recruitment.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                }

          }

                else
                {
                    strHtml += "<td     class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                     " href=\"gen_Manpower_Recruitment.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                }
            

            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {

                    if (intappstatus <4)
                    {
                        strHtml += "<td     class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Cancel\" onclick='return CancelAlert();' " +
                   " href=\"gen_Manpower_Recruitment_List.aspx?canId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                    }
                    else
                        strHtml += "<td    class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Cancel\" onclick='return CancelNotPossible();' >"
                                + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
               
                }




                else
                {

                   // strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">xx</td>";
                }
            }

            else
            {


                if (intCnclUsrId == 0)
                {
                    //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                }
                else
                {
                    if (HiddenSearchField.Value == "")
                    {
                        strHtml += "<td     class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                      " href=\"gen_Manpower_Recruitment.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                    }
                    else
                    {
                        strHtml += "<td    class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                     " href=\"gen_Manpower_Recruitment.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";

                    }
                }
            }
            
            if(intappstatus==1)
            {
                if (intrejectedctdstatus == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">REJECTED</td>";
                }
                else
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">NEW</td>";


            }
            else if (intappstatus == 2)
            {
                strHtml += "<td class=\"tdT\" style=\"width:8%; word-wrap:break-word;text-align: center;\">CONFIRMED</td>";


            } else if (intappstatus == 3)
            {
                strHtml += "<td class=\"tdT\" style=\"width:8%; word-wrap:break-word;text-align: center;\">VERIFIED</td>";


            } else if (intappstatus == 4)
            {
                strHtml += "<td class=\"tdT\" style=\"width:8%; word-wrap:break-word;text-align: center;\">APPROVED</td>";


            }
            else  if (intappstatus == 5)
            {
                strHtml += "<td class=\"tdT\" style=\"width:8%; word-wrap:break-word;text-align: center;\">NEW</td>";


            }
            else
                strHtml += "<td class=\"tdT\" style=\"width:8%; word-wrap:break-word;text-align: center;\">NEW</td>";

            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    [WebMethod]
    public static manpower ChangeEntryStatus(int strCatId, string strStatus, int corpid, int orgid, int edit, int cancel, string SearchString, int UserId)
    {

        //Creating objects for business layer
        clsBusinessLayerManpowerRecruitment objBusinessMNPWRDetails = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
     //   clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr = new clsEntityLayerEmployeeSponsorMaster();
        manpower objmanpower = new manpower();
        
        string strRet = "success";

        if (strStatus == "ACTIVE")
        {
            ObjEntityManpowerRecruitment.Cancel_Status = 0;
        }
        else
        {
            ObjEntityManpowerRecruitment.Cancel_Status = 1;
        }
        ObjEntityManpowerRecruitment.RequestId = strCatId;
        try
        {
            objBusinessMNPWRDetails.ChangeEntryStatus(ObjEntityManpowerRecruitment);
        }
        catch
        {
            strRet = "failed";
        }
        ObjEntityManpowerRecruitment.CorpId=corpid;
        ObjEntityManpowerRecruitment.orgid = orgid;
        ObjEntityManpowerRecruitment.UserId = UserId;
        objmanpower.strRet = strRet;
      DataTable dt=  objBusinessMNPWRDetails.ReadManpower_search(ObjEntityManpowerRecruitment);
      objmanpower.strhtml = objmanpower.ConvertDataTableToHTML(dt, edit, cancel, 0, SearchString);
        return objmanpower;
     }
    public class manpower
    {
        public string strhtml;
        public string strRet;
        //It build the Html table by using the datatable provided
        public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall, string SearchString)
        {

            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"main_table_head\">";
            int intCnclUsrId = 0;
            int intReCallForTAble = 0;

            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

                if (intCnclUsrId != 0)
                {
                    intReCallForTAble = 0;
                }

            }

            //  strHtml += "<th class=\"thT\" style=\"width:2%;text-align: left; word-wrap:break-word;\">" +"SL#" +"</th>";


            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {
                //if (i == 0)
                //{
                //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
                //}
                if (intColumnHeaderCount == 0)
                {
                    strHtml += "<th  href=\"#\" class=\"thT\" style=\"width:15%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th href=\"#\" class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }

                else if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th href=\"#\" class=\"thT\"  style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }

                else if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th  href=\"#\" class=\"thT\"  style=\"width:8%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                else if (intColumnHeaderCount == 4)
                {
                    strHtml += "<th href=\"#\"  class=\"thT\"  style=\"width:5%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                else if (intColumnHeaderCount == 5)
                {
                    strHtml += "<th  href=\"#\" class=\"thT\"  style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }





            }
            strHtml += "<th  href=\"#\" class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">STATUS</th>";

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {


                    strHtml += "<th  href=\"#\" class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
                }
                else
                    strHtml += "<th href=\"#\"  class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";

            }
            else
                strHtml += "<th href=\"#\"  class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
            if (intCnclUsrId == 0)
            {
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {

                    strHtml += "<th href=\"#\" class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">CANCEL</th>";

                }

            }
            strHtml += "<th class=\"thT\" style=\"width:8%; word-wrap:break-word;text-align: center;\">REQUIREMENT STATUS</th>";

            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows

            strHtml += "<tbody>";
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string strStatusMode = "";
                int intappstatus = Convert.ToInt32(dt.Rows[intRowBodyCount]["MNP_PROCESS_STATUS"].ToString());
                int intrejectedctdstatus = Convert.ToInt32(dt.Rows[intRowBodyCount]["REJECT_STATUS"].ToString());
                int intstatus;

                string strId = dt.Rows[intRowBodyCount][8].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][8].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;


                if (dt.Rows[intRowBodyCount]["MNP_CONFIRM"].ToString() == "")
                {
                    intstatus = 0;
                }
                else
                    intstatus = Convert.ToInt32(dt.Rows[intRowBodyCount]["MNP_CONFIRM"].ToString());
                intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
                //int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());
                int slno = intRowBodyCount + 1;
                strHtml += "<tr  >";
                // strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    //if (j == 0)
                    //{
                    //    int intCnt = i + 1;
                    //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                    //}
                    if (intColumnBodyCount == 0)
                    {
                       // strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        strHtml += "<td  class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + " <a href=\"#\" class=\"tooltip\"  style=\"cursor:pointer;color: blue;\"  title=\"Go To View\" onclick=\"return ManPowerId('" + Id + "');\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</a> </td>";
                        
                    }
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:8%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }



                }


          

                strStatusMode = dt.Rows[intRowBodyCount][6].ToString();
                if (intCnclUsrId == 0)
                {
                    if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (strStatusMode == "ACTIVE")
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  href=\"#\" class=\"tooltip\" title=\"Make Inactive\" onclick=\"return ChangeEntryStatus('" + strId + "','" + strStatusMode + "');\" >" +
                                "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   href=\"#\" class=\"tooltip\" title=\" Make Active\" onclick=\"return ChangeEntryStatus('" + strId + "','" + strStatusMode + "');\" >" +
                              "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                        }
                    }
                    else
                    {
                        if (strStatusMode == "ACTIVE")
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  href=\"#\"  class=\"tooltip\" title=\"Make Inactive\" >" +
                                "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  href=\"#\"  class=\"tooltip\" title=\" Make Active\" >" +
                              "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                        }
                    }

                }
                else
                {
                    if (strStatusMode == "ACTIVE")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  href=\"#\"  class=\"tooltip\" title=\"Make Active\" >" +
                            "<img  style=\"cursor:pointer\" src='/Images/Icons/activate.png' /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  href=\"#\"   class=\"tooltip\" title=\" Make Inactive\" >" +
                          "<img  style=\"cursor:pointer\" src='/Images/Icons/inactivate.png' /> " + "</a> </td>";
                    }
                }

                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (intCnclUsrId == 0)
                    {
                        if (intstatus != 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                          " href=\"gen_Manpower_Recruitment.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


                        }
                        else
                        {

                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a    class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                       " href=\"gen_Manpower_Recruitment.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                        }


                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                         " href=\"gen_Manpower_Recruitment.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                    }

                }

                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                     " href=\"gen_Manpower_Recruitment.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                }


                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (intCnclUsrId == 0)
                    {

                        if (intappstatus < 4)
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  href=\"#\"  class=\"tooltip\" title=\"Cancel\" onclick='return CancelAlert();' " +
                       " href=\"gen_Manpower_Recruitment_List.aspx?canId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                        }
                        else
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  href=\"#\"  class=\"tooltip\" title=\"Cancel\" onclick='return CancelNotPossible();' >"
                                    + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                    }




                    else
                    {

                        // strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">xx</td>";
                    }
                }

                else
                {


                    if (intCnclUsrId == 0)
                    {
                        //strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                    }
                    else
                    {
                        if (SearchString == "")
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  href=\"#\"  class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                          " href=\"gen_Manpower_Recruitment.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  href=\"#\"  class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                         " href=\"gen_Manpower_Recruitment.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";

                        }
                    }
                }

                if (intappstatus == 1)
                {
                    if (intrejectedctdstatus == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">REJECTED</td>";
                    }
                    else
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">NEW</td>";


                }
                else if (intappstatus == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\"width:8%; word-wrap:break-word;text-align: center;\">CONFIRMED</td>";


                }
                else if (intappstatus == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\"width:8%; word-wrap:break-word;text-align: center;\">VERIFIED</td>";


                }
                else if (intappstatus == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\"width:8%; word-wrap:break-word;text-align: center;\">APPROVED</td>";


                }
                else if (intappstatus == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\"width:8%; word-wrap:break-word;text-align: center;\">NEW</td>";


                }
                else
                    strHtml += "<td class=\"tdT\" style=\"width:8%; word-wrap:break-word;text-align: center;\">NEW</td>";

                strHtml += "</tr>";
            }

            strHtml += "</tbody>";

            strHtml += "</table>";



            sb.Append(strHtml);
            return sb.ToString();
        }
    
    
    
    
    }
    // at search button click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer
        clsBusinessLayerManpowerRecruitment objBusinessMNPWRDetails = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();

        int intUserId = 0, intcorpid = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableConfirm = 0, intEnableReOpen = 0, intEnableClose = 0, intEnableCancel = 0, intEnableRecall = 0, intEnableHrConfirm = 0, intEnableGMApprove = 0;

        //  objEntitySpnsrMstr.Sponsor_Status = Convert.ToInt32(ddlType.SelectedItem.Value);


        if (cbxCnclStatus.Checked == true)
            ObjEntityManpowerRecruitment.Cancel_Status = 1;
        else
            ObjEntityManpowerRecruitment.Cancel_Status = 0;

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            ObjEntityManpowerRecruitment.UserId = Convert.ToInt32(Session["USERID"]);
            //objEntityCntrct.User_Id = 
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Mapower_Requirement);
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
                    Hiddenenabledit.Value = intEnableModify.ToString(); ;
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    Hiddenenablecancl.Value = intEnableCancel.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                {
                    intEnableHrConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    HiddenHrCnfrm.Value = intEnableHrConfirm.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString())
                {
                    intEnableGMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    HiddenGMApprove.Value = intEnableGMApprove.ToString();

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                {
                    intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                {
                    intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                {
                    intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                }

            }
        }
        if (intEnableConfirm == 1)
        {
            ObjEntityManpowerRecruitment.Role_id = 0;

        }

        else if (intEnableHrConfirm == 1)
        {
            ObjEntityManpowerRecruitment.Role_id = 1;

        }
        else if (intEnableGMApprove == 1)
        {
            ObjEntityManpowerRecruitment.Role_id = 2;
        }
        DataTable dtBrnd = new DataTable();
        if (ddlStatus.SelectedItem.Text == "Active")
        {
            ObjEntityManpowerRecruitment.Application_Status = 1;
        }
        else if (ddlStatus.SelectedItem.Text == "Inactive")
        {
            ObjEntityManpowerRecruitment.Application_Status = 0;
        }
        else if (ddlStatus.SelectedItem.Text == "All")
        {
            ObjEntityManpowerRecruitment.Application_Status = 3;
        }

        else
        {
            ObjEntityManpowerRecruitment.Application_Status = 4;
        }

        // objEntitySpnsrMstr.SponsorType_Id = Convert.ToInt32(ddlType.SelectedItem.Value);
        if (ddldepartment.SelectedItem.Text == "--SELECT DEPARTMENT--")
        {
            ObjEntityManpowerRecruitment.Derpartment = 0;

        }
        else
            ObjEntityManpowerRecruitment.Derpartment = Convert.ToInt32(ddldepartment.SelectedItem.Value);
        if (ddlDivision.SelectedItem.Text == "--SELECT DIVISION--")
        {
            ObjEntityManpowerRecruitment.DivisionId = 0;

        }
        else
            ObjEntityManpowerRecruitment.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        if (cbxCnclStatus.Checked == true)
        {
            ObjEntityManpowerRecruitment.Cancel_Status = 1;
        }
        else
        {
            ObjEntityManpowerRecruitment.Cancel_Status = 0;
        }
        if (ddlSts.SelectedItem.Text == "PENDING")
        {
            if (ddrole.SelectedItem.Text != "--SELECT ROLE--")
            {

                ObjEntityManpowerRecruitment.RoleSrch = Convert.ToInt32(ddrole.SelectedItem.Value);

            }
        }
        else
        {
            ObjEntityManpowerRecruitment.RoleSrch = Convert.ToInt32(ddlSts.SelectedItem.Value);
        }

       

        dtBrnd = objBusinessMNPWRDetails.ReadManpower_search(ObjEntityManpowerRecruitment);


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
            intEnableRecall = 0;
        }
        else
        {
            intEnableRecall = 0;
        }
        //Allocating child roles
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Sponsor_Master);
      //  DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

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


    public void DepartmentLoad()  //emp25
    {
        clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();
        clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
        clsEntityProjectAssign ObjEntityProjectAssign = new clsEntityProjectAssign();
        
        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDetails.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityJobDetails.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityJobDetails.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
      DataTable dtdepartment = objBusinessJobDetails.ReadDepartment(objEntityJobDetails);
      
        if (dtdepartment.Rows.Count > 0)
        {
            ddldepartment.DataSource = dtdepartment;
            ddldepartment.Items.Clear();
          
            ddldepartment.DataValueField = "CPRDEPT_ID";
            ddldepartment.DataTextField = "CPRDEPT_NAME";
            


            //ddlProjct.DataValueField = "PROJECT_ID";
            ddldepartment.DataBind();

        }
        ddldepartment.Items.Insert(0, "--SELECT DEPARTMENT--");
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
       
    }
    public void DivisionLoad()
    {
       
    }

    //    clsBusinessLayerManpowerRecruitment objBusinessMNPWRDetails = new clsBusinessLayerManpowerRecruitment();
    //    CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
    //    clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();
    //    clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
  

    //    //  clsEntityReports ObjLeadReport = new clsEntityReports();
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        objEntityJobDetails.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        objEntityJobDetails.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    if (Session["USERID"] != null)
    //    {
    //        // intUserId = Convert.ToInt32(Session["USERID"]);
    //        objEntityJobDetails.UserId = Convert.ToInt32(Session["USERID"]);
    //    }
    //    else if (Session["USERID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    DataTable dtDivision = objBusinessJobDetails.ReadDivision(objEntityJobDetails);
    //    if (dtDivision.Rows.Count > 0)
    //    {
    //        ddlDivision.Items.Clear();
    //        ddlDivision.DataSource = dtDivision;


    //        ddlDivision.DataValueField = "CPRDIV_ID";
    //        ddlDivision.DataTextField = "CPRDIV_NAME";



    //        //ddlProjct.DataValueField = "PROJECT_ID";
    //        ddlDivision.DataBind();

    //    }
    //    ddlDivision.Items.Insert(0, "--SELECT DIVISION--");

    //}

        protected void btnRsnSave_Click(object sender, EventArgs e)
    {

        //Creating objects for business layer
    clsBusinessLayerManpowerRecruitment objBusinessMNPWRDetails = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityManpowerRecruitment. orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                ObjEntityManpowerRecruitment.UserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            ObjEntityManpowerRecruitment.RequestDate1 = System.DateTime.Now;

            ObjEntityManpowerRecruitment.Cancel_Reason = txtCnclReason.Text.Trim();
            objBusinessMNPWRDetails.CancelManpowerRecruitmentById(ObjEntityManpowerRecruitment);

            if (HiddenSearchField.Value == "")
            {
                Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }


        }
    }

        public void LoadRole()
        {

            ListItem lstGrp = new ListItem("--SELECT ROLE--", "0");

            ddrole.Items.Insert(0, lstGrp);

            lstGrp = new ListItem("DIVISION MANAGER", "1");
            ddrole.Items.Insert(1, lstGrp);

         
            lstGrp = new ListItem("HR", "2");

            ddrole.Items.Insert(2, lstGrp);
            lstGrp = new ListItem("GENERAL MANAGER", "3");
            ddrole.Items.Insert(3, lstGrp);
        }

        protected void ddldepartment_SelectedIndexChanged(object sender, EventArgs e)     //emp25
        {
            clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();
            clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
            clsBusinessLayerManpowerRecruitment objBusinessMNPWRDetails = new clsBusinessLayerManpowerRecruitment();
            CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
            if (Session["CORPOFFICEID"] != null)
            {
                ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                // intUserId = Convert.ToInt32(Session["USERID"]);
                ObjEntityManpowerRecruitment.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            ddlDivision.Items.Clear();
            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
            if (ddldepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
            {
                int Dept = Convert.ToInt32(ddldepartment.SelectedItem.Value);
                ObjEntityManpowerRecruitment.Derpartment = Dept;
                DataTable dtDivision = objBusinessMNPWRDetails.ReadDivision(ObjEntityManpowerRecruitment);
                
                    if (dtDivision.Rows.Count > 0)
                    {
                        ddlDivision.Items.Clear();
                      
                        ddlDivision.DataSource = dtDivision;


                        ddlDivision.DataValueField = "CPRDIV_ID";
                        ddlDivision.DataTextField = "CPRDIV_NAME";



                        //ddlProjct.DataValueField = "PROJECT_ID";
                        ddlDivision.DataBind();
                        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");

                    }
                   // ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
                }
            

        }
}