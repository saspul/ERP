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

public partial class Employee_Perfomance_Evaluation_Employee_Perfomance_Evaluation_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            clsBusiness_Emp_Perfomance_Evaluation objEmpPerfomance = new clsBusiness_Emp_Perfomance_Evaluation();
            clsEntity_Emp_perfomance_Evaluation objEntity = new clsEntity_Emp_perfomance_Evaluation();
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
                HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntity.OrgId = intOrgId;
                Hiddenorgid.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intConfirm = 0, intUsrRolMstrId = 0, HrApprove = 0, intEnableDMApprove = 0, intEnableGMApprove = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Perfomance_Evalvtn);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                    {
                        HrApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                       // HiddenHrCnfrm.Value = intEnableHrConfirm.ToString(); ;

                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                        intEnableDMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                      
                      //  HiddenDMApprove.Value = intEnableDMApprove.ToString();

                    }
                   if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString())
                    {


                        intEnableGMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);



                    }


                }
            }



            DataTable dtUsrDtls = objEmpPerfomance.ReadUsrDesgDept(objEntity);
            DataTable dtList = objEmpPerfomance.ReadPerfomanceEvaluationList(objEntity);
            divList.InnerHtml = ConvertDataTableToHTML(dtList,dtUsrDtls, HrApprove, intEnableDMApprove, intEnableGMApprove, intUserId);
         

        }
        if (Request.QueryString["InsUpd"] != null)
        {
          
            if (Request.QueryString["InsUpd"] == "Ins")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsert", "SuccessInsert();", true);
            }
            if (Request.QueryString["InsUpd"] == "Upd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdate", "SuccessUpdate();", true);
            }
            if (Request.QueryString["InsUpd"] == "CNFM")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
            }
            if (Request.QueryString["InsUpd"] == "CNFMERROR")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ConfirmError", "ConfirmError();", true);
            }
        }
       
    }

    public string ConvertDataTableToHTML(DataTable dt,DataTable dtUsrDtls, int HrApprove, int intEnableDMApprove, int intEnableGMApprove, int intUserId)
    {
        clsEntity_Emp_perfomance_Evaluation objEntity = new clsEntity_Emp_perfomance_Evaluation();
         clsBusiness_Emp_Perfomance_Evaluation objEmpPerfomance = new clsBusiness_Emp_Perfomance_Evaluation();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        String Status = "";
        int intOrgId = 0;
        int Nodata = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());


        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

       
        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"table table-striped table-bordered\" width=\"100%\" style=\"border-spacing: 1px;background-color: #e7e6e6;\">";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr >";




        for (int intColumnHeaderCount = 0; intColumnHeaderCount < 7; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:20%;text-align:left;\">REFERENCE NUMBER";


                strHtml += "	<input class=\"form-control\" placeholder=\"REFERENCE NUMBER\" style=\"text-align:left;\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:25%;text-align:left;\">PERFORMANCE FORM ";


                strHtml += "	<input class=\"form-control\" placeholder=\"PERFORMANCE FORM\" style=\"text-align:left;\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:22%;text-align:left;\">EMPLOYEE ";


                strHtml += "	<input class=\"form-control\" placeholder=\"EMPLOYEE\" style=\"text-align:left;\" type=\"text\">";
                strHtml += "</th >";
            }

            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:22%;text-align:left;\"> RESPONSE TYPE";


                strHtml += "	<input class=\"form-control\" style=\"text-align:left;\" placeholder=\"RESPONSE TYPE\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"hasinput\" style=\"width:10%;text-align:center;\">ISSUED DATE";


                strHtml += "	<input class=\"form-control\" style=\"text-align:center;\" placeholder=\"ISSUED DATE\" type=\"text\">";
                strHtml += "</th >";
            }


            else if (intColumnHeaderCount == 6)
            {
               

                        strHtml += "<th class=\"hasinput\" style=\" width:1%;text-align: center;\"> SUBMIT RESPONSE";

                  
                
               
            }

           


        }

        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string rsTyp_0 = "";
            string rsTyp_1 = "";
            string rsTyp_2 = "";
            string rsTyp_3 = "";
            string rsTyp_4 = "";
            int responsSts = 1;
            //  string orgid = dt.Rows[intRowBodyCount][0].ToString();
            // strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";
            int IssueEval = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_EVAL"].ToString());
            int hrEvaluvation = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_HR_EVLTOR"].ToString());
            int DmEvaluvation = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_DM_EVLTOR"].ToString());
            int GmEvaluvation = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_GM_EVLTOR"].ToString());
            int SelfEvaluvation = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_SELF_EVLTOR"].ToString());
          int ReptEvaluvation = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_RO_EVLTOR"].ToString());
            objEntity.EmpTyp = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_EMP"].ToString());
            objEntity.IssueId = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_ID"].ToString());
         //   objEntity.IssueEmpId = Convert.ToInt32(dt.Rows[intRowBodyCount]["ISSUE_EMP_ID"].ToString());
            objEntity.CorpId=Convert.ToInt32(  HiddenCorpId.Value);
            objEntity.OrgId = Convert.ToInt32(Hiddenorgid.Value);
            objEntity.UsrId = intUserId;
            DataTable DdtEmployeeDtls = objEmpPerfomance.ReadUsrDtls(objEntity);
           
            for (int intRowCount = 0; intRowCount < DdtEmployeeDtls.Rows.Count; intRowCount++)
            {
                string resposetype = HiddenResponseType.Value;
                //if (resposetype != "")
               // {
                   if (ddlResponsType.SelectedItem.Text == "--Select Response Type--")
                    {
                        responsSts = 1;
                    }

                    //else
                    //{

                    //    responsSts = 0;
                    //    string[] vars = resposetype.Split(',');
                    //    int length = vars.Length;

                    //    if (length == 1)
                    //    {
                    //        rsTyp_0 = vars[0];
                    //        if (ddlResponsType.SelectedItem.Text == rsTyp_0)
                    //        {
                    //            responsSts = 1;
                    //        }
                    //    }
                    //    else if (length == 2)
                    //    {
                    //        rsTyp_0 = vars[0];
                    //        rsTyp_1 = vars[1];
                    //        if (ddlResponsType.SelectedItem.Text == rsTyp_0 || ddlResponsType.SelectedItem.Text == vars[1])
                    //        {
                    //            responsSts = 1;
                    //        }
                    //    }
                    //    else if (length == 3)
                    //    {
                    //        rsTyp_0 = vars[0];
                    //        rsTyp_1 = vars[1];
                    //        rsTyp_2 = vars[2];
                    //        if (ddlResponsType.SelectedItem.Text == rsTyp_0 || ddlResponsType.SelectedItem.Text == vars[1] || ddlResponsType.SelectedItem.Text == vars[2])
                    //        {
                    //            responsSts = 1;
                    //        }
                    //    }

                    //    else if (length == 4)
                    //    {
                    //        rsTyp_0 = vars[0];
                    //        rsTyp_1 = vars[1];
                    //        rsTyp_2 = vars[2];
                    //        rsTyp_3 = vars[3];
                    //        if (ddlResponsType.SelectedItem.Text == rsTyp_0 || ddlResponsType.SelectedItem.Text == vars[1] || ddlResponsType.SelectedItem.Text == vars[2] || ddlResponsType.SelectedItem.Text == vars[3])
                    //        {
                    //            responsSts = 1;
                    //        }
                    //    }
                    //    else if (length == 5)
                    //    {
                    //        rsTyp_0 = vars[0];
                    //        rsTyp_1 = vars[1];
                    //        rsTyp_2 = vars[2];
                    //        rsTyp_3 = vars[3];
                    //        rsTyp_4 = vars[4];
                    //        if (ddlResponsType.SelectedItem.Text == rsTyp_0 || ddlResponsType.SelectedItem.Text == vars[1] || ddlResponsType.SelectedItem.Text == vars[2] || ddlResponsType.SelectedItem.Text == vars[3] || ddlResponsType.SelectedItem.Text == vars[4])
                    //        {
                    //            responsSts = 1;
                    //        }

                    //    }

                    //}
               // }
                int RoEvaluvation = 0;
                if (DdtEmployeeDtls.Rows[intRowCount]["EMPREPORTING"].ToString() != "")
                {
                    RoEvaluvation = Convert.ToInt32(DdtEmployeeDtls.Rows[intRowCount]["EMPREPORTING"].ToString());
                }
                int EmpSelfEvaluvation = 0;
                if (DdtEmployeeDtls.Rows[intRowCount]["USR_ID"].ToString() != "")
                {
                    EmpSelfEvaluvation = Convert.ToInt32(DdtEmployeeDtls.Rows[intRowCount]["USR_ID"].ToString());
                }
                int flag = 0;
                HiddenResponseType.Value = "";

                if (IssueEval == 1)
                {
                    objEntity.UsrId = intUserId;
                    objEntity.IssueType = 1;
                    DataTable DdteVLTR = objEmpPerfomance.ReadUsrEvltr(objEntity);
                    if (DdteVLTR.Rows.Count > 0)
                    {
                        for (int count = 0; count < DdteVLTR.Rows.Count; count++)
                        
                        {
                            if (intUserId ==Convert.ToInt32( DdteVLTR.Rows[count]["ISSUE_EVLTR_USR_ID"].ToString()))
                            {
                                flag = 1;
                                HiddenResponseType.Value = "ADDITIONAL EMPLOYEE";
                            }
                        }
                    }

                }
                else if (IssueEval == 2)
                {
                    if (dtUsrDtls.Rows[0]["CPRDEPT_ID"].ToString() != "")
                    {
                        objEntity.IssueType = 2;
                        objEntity.DeptId = Convert.ToInt32(dtUsrDtls.Rows[0]["CPRDEPT_ID"].ToString());
                        DataTable DdteVLTR = objEmpPerfomance.ReadUsrEvltr(objEntity);
                        if (DdteVLTR.Rows.Count > 0)
                        {
                            for (int count = 0; count < DdteVLTR.Rows.Count; count++)
                            {
                                if (dtUsrDtls.Rows[0]["CPRDEPT_ID"].ToString() == DdteVLTR.Rows[count]["ISSUE_EVLTR_DEPTID"].ToString())
                                {
                                    flag = 1;
                                    HiddenResponseType.Value = "DEPARTMENT";
                                }
                            }
                        }
                    }
                }
                else if (IssueEval == 3)
                {
                    if(dtUsrDtls.Rows[0]["DSGN_ID"].ToString()!="")
                    {
                        objEntity.IssueType = 3;
                    objEntity.DesgId = Convert.ToInt32(dtUsrDtls.Rows[0]["DSGN_ID"].ToString());
                    DataTable DdteVLTR = objEmpPerfomance.ReadUsrEvltr(objEntity);
                    if (DdteVLTR.Rows.Count > 0)
                    {
                        for (int count = 0; count < DdteVLTR.Rows.Count; count++)
                        {
                            if (dtUsrDtls.Rows[0]["DSGN_ID"].ToString() == DdteVLTR.Rows[count]["ISSUE_EVLTR_DSGNID"].ToString())
                            {
                                flag = 1;
                                HiddenResponseType.Value = "DESIGNATION";
                            }
                        }
                    }
                    }
                }

                if ((SelfEvaluvation == 1) && (EmpSelfEvaluvation == intUserId))
                {
                  
                    flag = 1;
                    if (HiddenResponseType.Value == "")
                    {
                        HiddenResponseType.Value = "SELF";
                    }
                    else
                    {
                        HiddenResponseType.Value = HiddenResponseType.Value + "," + "SELF";
                    }
                }

                if ((RoEvaluvation != 0) && (ReptEvaluvation==1))
                {
                    if (RoEvaluvation == intUserId)
                    {
                       
                        flag = 1;
                        if (HiddenResponseType.Value == "")
                        {
                            HiddenResponseType.Value = "REPORTING OFFICER";
                        }
                        else
                        {
                            HiddenResponseType.Value = HiddenResponseType.Value + "," + "REPORTING OFFICER";
                        }
                    }
                   
                }

                if (DmEvaluvation == 1 && intEnableDMApprove == 1)
                {
                    flag = 1;
                 
                    if (HiddenResponseType.Value == "")
                    {
                        HiddenResponseType.Value = "DIVISION MANAGER";
                    }
                    else
                    {
                        HiddenResponseType.Value = HiddenResponseType.Value + "," + "DIVISION MANAGER";
                    }
                }
                
                if (hrEvaluvation == 1 && HrApprove == 1)
                {
                    flag = 1;
                   
                    if (HiddenResponseType.Value == "")
                    {
                        HiddenResponseType.Value = "HR";
                    }
                    else
                    {
                        HiddenResponseType.Value = HiddenResponseType.Value + "," + "HR";
                    }
                }
               
                if (GmEvaluvation == 1 && intEnableGMApprove == 1)
                {
                    flag = 1;
                   
                    if (HiddenResponseType.Value == "")
                    {
                        HiddenResponseType.Value = "GENERAL MANAGER";
                    }
                    else
                    {
                        HiddenResponseType.Value = HiddenResponseType.Value + "," + "GENERAL MANAGER";
                    }
                    
                }


                string RESPONStYP="";
                    
                    if( responsSts ==1)
                    {

                        RESPONStYP = HiddenResponseType.Value;
                    }
            
                if (flag == 1 && responsSts == 1)
                {
                    for (int intColumnBodyCount = 0; intColumnBodyCount < 7; intColumnBodyCount++)
                    {

                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["ISSUE_REFNO"].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 2)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["ISSUE_PRFM"].ToString() + "</td>";  //emp0025
                        }
                        else if (intColumnBodyCount == 3)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + DdtEmployeeDtls.Rows[intRowCount]["EMPLOYEE_NAME"].ToString() + "</td>";

                         //   strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" ></td>";

                        }

                        else if (intColumnBodyCount == 4)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + RESPONStYP + "</td>";

                            //Session["MESSG_RSPNCTYP"] = HiddenResponseType.Value;
                        }
                        else if (intColumnBodyCount == 5)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["ISSUE_DATE"].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 6)
                        {


                            string strId = dt.Rows[intRowBodyCount]["ISSUE_ID"].ToString();
                            int intIdLength = dt.Rows[intRowBodyCount]["ISSUE_ID"].ToString().Length;
                            string stridLength = intIdLength.ToString("00");
                            string Id = stridLength + strId + strRandom;
                            string EmpId = "0";
                            if (DdtEmployeeDtls.Rows[intRowCount]["USR_ID"].ToString() != null)
                            {
                                string strEmpId = DdtEmployeeDtls.Rows[intRowCount]["USR_ID"].ToString();
                                int intIdEmpLength = DdtEmployeeDtls.Rows[intRowCount]["USR_ID"].ToString().Length;
                                string strEmpidLength = intIdEmpLength.ToString("00");
                                EmpId = strEmpidLength + strEmpId + strRandom;
                            }
                            int flagsts = 0;
                            string sts = "";
                            objEntity.IssueEmpId = Convert.ToInt32(DdtEmployeeDtls.Rows[intRowCount]["USR_ID"].ToString());
                            DataTable DdtEvltrsDtls = objEmpPerfomance.ReadEvltrsDtls(objEntity);
                            if (DdtEvltrsDtls.Rows.Count > 0)
                            {
                                for (int cnfCount = 0; cnfCount < DdtEvltrsDtls.Rows.Count; cnfCount++)
                                {
                                     sts = DdtEvltrsDtls.Rows[cnfCount]["PRMNC_CNFRM_STS"].ToString();
                                     if (DdtEmployeeDtls.Rows[intRowCount]["EMPLOYEE_NAME"].ToString() == DdtEvltrsDtls.Rows[cnfCount]["EMPLOYEE_NAME"].ToString())
                                    {
                                        flagsts = 1;
                                    }
                                    else
                                    {
                                        flagsts = 0;
                                    }

                                }


                                if (flagsts == 1)
                                {


                                    if (sts == "")
                                    {
                                        strHtml += " <td style=\" width: 1%; text-align: center; float: right; margin-right: 51%;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a style=\"opacity: 1; \"   class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                        " href=\"Employee_Performance_Evaluation.aspx?Id=" + Id + "EmpId." + EmpId + "\"><i class=\"fa fa-pencil\"></i></a></td>";


                                    }

                                    else
                                    {
                                        strHtml += " <td style=\" width: 1%; text-align: center; float: right; margin-right: 51%;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a style=\"opacity: 1; \"   class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                                                                                        " href=\"Employee_Performance_Evaluation.aspx?Id=" + Id + "EmpId." + EmpId + "\"><i class=\"fa fa-eye\"></i></a></td>";

                                    }
                                }
                                else
                                {

                                    strHtml += " <td style=\" width: 1%; text-align: center; float: right; margin-right: 51%;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a style=\"opacity: 1; \"   class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                    " href=\"Employee_Performance_Evaluation.aspx?Id=" + Id + "EmpId." + EmpId + "\"><i class=\"fa fa-pencil\"></i></a></td>";

                                }

                            }

                            else
                            {
                                strHtml += " <td style=\" width: 1%; text-align: center; float: right; margin-right: 51%;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\">" + " <a style=\"opacity: 1; \"   class=\"tooltip\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                   " href=\"Employee_Performance_Evaluation.aspx?Id=" + Id + "EmpId." + EmpId + "\"><i class=\"fa fa-pencil\"></i></a></td>";
                            }

                          
                           
                        }



                    }
                }
                else
                {
                   
                }



                strHtml += "</tr>";
            }
        }
        
        if (dt.Rows.Count == 0)
        {
            strHtml += "<td class=\"tdT\"colspan=\"6\" style=\" width:16%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No Data Available</td>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }





    protected void btnCnclSearch_Click(object sender, EventArgs e)
    {
        clsBusiness_Emp_Perfomance_Evaluation objEmpPerfomance = new clsBusiness_Emp_Perfomance_Evaluation();
        clsEntity_Emp_perfomance_Evaluation objEntity = new clsEntity_Emp_perfomance_Evaluation();
        clsCommonLibrary objCommon = new clsCommonLibrary();
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
        int intConfirm = 0, intUsrRolMstrId = 0, HrApprove = 0, intEnableDMApprove = 0, intEnableGMApprove = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Perfomance_Evalvtn);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
        
        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                {
                    HrApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    // HiddenHrCnfrm.Value = intEnableHrConfirm.ToString(); ;

                }
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                {
                    intEnableDMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //  HiddenDMApprove.Value = intEnableDMApprove.ToString();

                }
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString())
                {


                    intEnableGMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);



                }


            }
        }

        if (txtFromDate.Text.Trim() != "")
        {
            objEntity.frmDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
        }
        if (txtTodate.Text.Trim() != "")
        {
            objEntity.ToDate = objCommon.textToDateTime(txtTodate.Text.Trim());
        }
        if (ddlResponsType.SelectedItem.Value != "--Select Response Type--")
        {
            objEntity.RspnTypeId = Convert.ToInt32(ddlResponsType.SelectedItem.Value);
        }

        DataTable dtList = objEmpPerfomance.ReadPerfomanceEvaluationList(objEntity);
        DataTable dtUsrDtls = objEmpPerfomance.ReadUsrDesgDept(objEntity);
        divList.InnerHtml = ConvertDataTableToHTML(dtList,dtUsrDtls, HrApprove, intEnableDMApprove, intEnableGMApprove, intUserId);
    }
}