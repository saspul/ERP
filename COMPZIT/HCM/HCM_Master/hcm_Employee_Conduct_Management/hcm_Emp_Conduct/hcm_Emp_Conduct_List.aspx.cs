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

public partial class HCM_HCM_Master_hcm_Employee_Conduct_Management_hcm_Emp_Conduct_hcm_Emp_Conduct_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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

            if (Request.QueryString["InsUpd"] != null)
            {
                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    if (strInsUpd == "Ins")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ConductSuccessInsertion", "ConductSuccessInsertion();", true);
                    }
                }
            }

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intUsrRolMstrId = 0, intEnableDMApprove = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Emp_Conduct);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                        intEnableDMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        objEntity.divisionManager = intEnableDMApprove;
                       
                    }

                }
            }





            DataTable dtConductEmployee = new DataTable();

            dtConductEmployee = objEmpConduct.ReadConductEmployee(objEntity);
            //int intEnableModify = 1, intEnableCancel = 1, intEnableRecall = 1;

            string strHtm = ConvertDataTableToHTML(dtConductEmployee, intUserId, intEnableDMApprove);
            //Write to divReport
            divList.InnerHtml = strHtm;

            if (Request.QueryString["InsUpdMsg"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpdMsg"].ToString();
                if (strInsUpd == "CancelMsg")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelMsg", "SuccessCancelMsg();", true);
                }
            }
  
        }
    }
    public string ConvertDataTableToHTML(DataTable dt, int intUserId, int intEnableDMApprove)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

       
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"table table-striped table-bordered\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";
       

        

      //  strHtml += "<th class=\"thT\" style=\"width:2%;text-align: left; word-wrap:break-word;\">" +"SL#" +"</th>";


        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
           
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:15%;text-align:left;\"> CATEGORY NAME";
                strHtml += "<input class=\"form-control\"placeholder=\"CATEGORY NAME\" type=\"text\"></th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:20%;text-align:center;\"> INCIDENT DATE";

                strHtml += "<input style=\"text-align:center;\" class=\"form-control\"placeholder=\"INCIDENT DATE\" type=\"text\"></th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:20%;text-align:left;\">TYPE";

                strHtml += "<input class=\"form-control\"placeholder=\"TYPE\"  type=\"text\"></th>";
            
            }

            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:10%;text-align:left;\">SEVERITY";

                strHtml += "<input class=\"form-control\"placeholder=\"SEVERITY\"  type=\"text\"></th>";
            

            }
            else if (intColumnHeaderCount == 5)
            {

                strHtml += "<th class=\"hasinput\" style=\"width:10%;text-align:center;\">STATUS";

                strHtml += "<input class=\"form-control\" style=\"text-align:center;\" placeholder=\"STATUS\"  type=\"text\"></th>";
           
            }

            else if (intColumnHeaderCount == 6)
            {

                strHtml += "<th class=\"hasinput\" style=\"width:15%;text-align:center;\">ISSUE MEMO";

                strHtml += "<input class=\"form-control\" style=\"text-align:center;\" placeholder=\"ISSUE MEMO\"  type=\"text\"></th>";
          
            }

        }
        strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">VIEW</th>";


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        string ud=intUserId.ToString();
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int flag = 0;
            if (dt.Rows[intRowBodyCount]["USR_ID"].ToString() == ud)
            {
                if (dt.Rows[intRowBodyCount]["CNDTINC_EMP_NOTIFY"].ToString() == "1")
                {
                    
                    flag = 1;
                }
                
            }

            else if (dt.Rows[intRowBodyCount]["CNDTINC_NOTIFY"].ToString() == "1")
            {
                if (dt.Rows[intRowBodyCount]["EMPREPORTING"].ToString() == ud)
                {

                    flag = 1;
                }


            }
            else if (dt.Rows[intRowBodyCount]["CNDTINC_NOTIFY"].ToString() == "2")
            {

                if (intEnableDMApprove == 1 )
                {

                    flag = 1;
                }
            }
            else if (dt.Rows[intRowBodyCount]["CNDTINC_NOTIFY"].ToString() == "3")
            {

                if (intEnableDMApprove == 1 || dt.Rows[intRowBodyCount]["EMPREPORTING"].ToString() == ud)
                {


                    flag = 1;

                }
            }

            else
            {
                flag = 0;
            }
            if (flag == 1)
            {
                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                int slno = intRowBodyCount + 1;
                strHtml += "<tr  >";
                //   strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {



                    if (intColumnBodyCount == 1)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["M_REASON"].ToString() + " </td>";

                    }

                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["DATE"].ToString() + " </td>";
                    }
                    else if (intColumnBodyCount == 3)
                    {
                        int type = Convert.ToInt32(dt.Rows[intRowBodyCount]["CNDTINC_TYPE"].ToString());
                        if (type == 1)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >POSITIVE</td>";
                        }
                        else if (type == 0)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" > NEGATIVE </td>";
                        }
                        else
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" > </td>";
                    }

                    else if (intColumnBodyCount == 4)
                    {
                        int severity = Convert.ToInt32(dt.Rows[intRowBodyCount]["CNDTINC_SEVERITY"].ToString());
                        if (severity == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >CRITICAL</td>";
                        }
                        else if (severity == 2)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >HIGH</td>";
                        }
                        else if (severity == 3)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >MEDIUM</td>";
                        }
                        else if (severity == 4)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >LOW</td>";
                        }
                        else
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";

                    }
                    else if (intColumnBodyCount == 5)
                    {
                        int STS = Convert.ToInt32(dt.Rows[intRowBodyCount]["CNDTINC_RECIVE"].ToString());
                        if (STS == 0)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >UNREAD</td>";
                        }
                        else if (STS == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  > READ</td>";
                        }
                        else
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  ></td>";
                    }


                    else if (intColumnBodyCount == 6)
                    {
                        int issue = Convert.ToInt32(dt.Rows[intRowBodyCount]["CNDTINC_MEMO_ISSUE"].ToString());
                        if (issue == 0)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >NO </td>";
                        }
                        else
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >YES </td>";
                    }




                }

                //strHtml += "<td class=\"tdT\" style=\"width:10%; word-wrap:break-word;text-align: center;\">" + " <a  style=\" opacity: 1;margin-top: -0.5%;\" class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                // " href=\"hcm_Emp_Conduct.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' /> " + "</a> </td>";


                strHtml += " <td style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a style=\"opacity: 1;margin: 1%;margin-top: .5%;\" class=\"tooltip\" title=\"view\" onclick='return getdetails(this.href);' " +
                         " href=\"hcm_Emp_Conduct.aspx?Id=" + Id + "\"><i class=\"fa fa-eye\"></i></a></td>";

                strHtml += "</tr>";
            }

           
        }
        if (dt.Rows.Count == 0)
        {

            strHtml += "<td class=\"tdT\" colspan=\"8\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >No  Data Available</td>";
        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    
}