using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using CL_Compzit;
using BL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Web.Services;
using EL_Compzit;
using System.IO;

public partial class HCM_HCM_Reports_hcm_Immigration_tasks_Report_hcm_Immigration_tasks_Report : System.Web.UI.Page
{
    clsBusiness_ImmigrationTaskReport objBusinessManpwrReqmt = new clsBusiness_ImmigrationTaskReport();
    protected void Page_Load(object sender, EventArgs e)
    {
        //txtFromDate.Text = "";
        //txtTodate.Text = "";
    
        clsEntity_ImmigrationTaskReport objEntityManpwrReqmt = new clsEntity_ImmigrationTaskReport();
        
        if (!IsPostBack)
        {
          ddlRound.Focus();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityManpwrReqmt.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityManpwrReqmt.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
                hiddenOrgId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            //Evm-27

            DataTable dtImmigrationRound = new DataTable();
            dtImmigrationRound = objBusinessManpwrReqmt.ReadImgratnRnd(objEntityManpwrReqmt);
            ddlRound.Items.Clear();
            ddlRound.DataSource = dtImmigrationRound;

            ddlRound.DataTextField = "ROUND NAME";
            ddlRound.DataValueField = "IMGRTNRND_ID";
            ddlRound.DataBind();

            ddlRound.Items.Insert(0, "--SELECT IMMIGRATION ROUND--");


          


            //txtFromDate.Text = null;
            //txtTodate.Text = null;



            DataTable dtCandidateList = new DataTable();
            dtCandidateList = objBusinessManpwrReqmt.ReadCandidate(objEntityManpwrReqmt);

            ddlCandidate.Items.Clear();
            ddlCandidate.DataSource = dtCandidateList;

            ddlCandidate.DataTextField = "CAND_NAME";
            ddlCandidate.DataValueField = "USR_ID";
            ddlCandidate.DataBind();

            //ddlCandidate.Items.Insert(0, "--SELECT CANDIDATE--");



            DataTable dtProject = new DataTable();
            dtProject = objBusinessManpwrReqmt.ReadProject(objEntityManpwrReqmt);

            ddlProject.Items.Clear();
            ddlProject.DataSource = dtProject;

            ddlProject.DataTextField = "PROJECT_NAME";
            ddlProject.DataValueField = "PROJECT_ID";
            ddlProject.DataBind();

            ddlProject.Items.Insert(0, "--SELECT PROJECT--");
            //End

            DataTable dtDepts = new DataTable();
            dtDepts = objBusinessManpwrReqmt.ReadEmployee(objEntityManpwrReqmt);

            ddlEmployee.Items.Clear();
            ddlEmployee.DataSource = dtDepts;
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataBind();

            ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");

            if (ddlRound.SelectedItem.Text != "--SELECT IMMIGRATION ROUND--")
            {
                objEntityManpwrReqmt.ImgrtnRndId = Convert.ToInt32(ddlRound.SelectedItem.Value);
            }
            if (Hiddenselectedtext.Value != "")
            {
                objEntityManpwrReqmt.CandidateId = (hiddenselectedlist.Value);
            }
            if (ddlProject.SelectedItem.Text != "--SELECT PROJECT--")
            {
                objEntityManpwrReqmt.pjtId = Convert.ToInt32(ddlProject.SelectedItem.Value);
            }
            if (ddlEmployee.SelectedItem.Text != "--SELECT EMPLOYEE--")
            {
                objEntityManpwrReqmt.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            }
            DataTable dtCorp = objBusinessManpwrReqmt.ReadCorporateAddress(objEntityManpwrReqmt);
            objEntityManpwrReqmt.CorpOffice = 0;
            objEntityManpwrReqmt.Orgid = 0;

            DataTable dtManpwr = new DataTable();
            dtManpwr = objBusinessManpwrReqmt.ReadImmigrationTask(objEntityManpwrReqmt);

            string strHtm = ConvertDataTableToHTMLLL(dtManpwr);
            divReport.InnerHtml = strHtm;
            //for printing table
            string strPrintReport = ConvertDataTableForPrint(dtManpwr, dtCorp);
            divPrintReport.InnerHtml = strPrintReport;

        }
        //for viewing table

           
           
    }


    public string ConvertDataTableToHTMLLL(DataTable dt)
    {
        string str = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        //  clsBusinessManpwrJobAssignemntReport objBusinessRqrmnt = new clsBusinessManpwrJobAssignemntReport();
       clsEntity_ImmigrationTaskReport objEntityManpwrReqmt = new clsEntity_ImmigrationTaskReport();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < 7; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)//Ref#
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";
            }
            if (intColumnHeaderCount == 2)//Approved Date
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
            }
            if (intColumnHeaderCount == 3)//Department
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
            }
            if (intColumnHeaderCount == 4)//Designation
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">IMMIGRATION ROUND</th>";
            }
            if (intColumnHeaderCount == 5)//Division
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">STATUS</th>";
            }
            if (intColumnHeaderCount == 6)//Project
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">ASSIGNED TO</th>";
            }


        }

        //  strHtml += "<th class=\"thT\" style=\"width:11%; word-wrap:break-word;text-align: center;\">MORE INFO</th>";


        strHtml += "</tr>";


        strHtml += "</thead>";
        strHtml += "<tbody>";

        string imground = "";
        string employee = "";
        if (ddlRound.SelectedItem.Text != "--SELECT IMMIGRATION ROUND--")
        {
             imground = ddlRound.SelectedItem.Text;
        }
        else
        {
            imground = "--SELECT IMMIGRATION ROUND--";
        }
        if (ddlEmployee.SelectedItem.Text != "--SELECT EMPLOYEE--")
        {
            employee = ddlEmployee.SelectedItem.Text;
        }
        else
        {
            employee = "--SELECT EMPLOYEE--";
        }

            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {



                objEntityManpwrReqmt.CandId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CAND_ID"].ToString());
                DataTable dtcandDtl = objBusinessManpwrReqmt.readCandidateById(objEntityManpwrReqmt);
                //strHtml += "<tr  >";



                //  strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\">";

                // strHtml += "</td>";




                for (int intcandCount = 0; intcandCount < dtcandDtl.Rows.Count; intcandCount++)
                {
                    if (imground != "--SELECT IMMIGRATION ROUND--" )
                    {

                        if (imground == dtcandDtl.Rows[intcandCount]["IMGRTNRND_NAME"].ToString())
                        {
                            //if (intcandCount!=0)
                            strHtml += "<tr  >";
                            //for (int intColumnBodyCount = 0; intColumnBodyCount < 7; intColumnBodyCount++)
                            //{
                            // if (intColumnBodyCount == 1)
                            //{
                            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CAND_NAME"].ToString() + "</td>";
                            //}
                            // else if (intColumnBodyCount == 2)
                            // {
                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + "</td>";
                            //}

                            // else if (intColumnBodyCount == 3)
                            // {
                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString() + "</td>";
                            //}
                            //else if (intColumnBodyCount == 4)
                            // {


                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dtcandDtl.Rows[intcandCount]["IMGRTNRND_NAME"].ToString() + "</td>";

                            // }
                            // else if (intColumnBodyCount == 5)
                            //{
                            int finishsts = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_FNSH_STS"].ToString());
                            int clssts = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_CLOSE_STS"].ToString());
                            if (clssts == 0)
                            {
                                if (finishsts == 0)
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dtcandDtl.Rows[intcandCount]["IMGRTNRNDDTL_NAME"].ToString() + "</td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >FINISHED</td>";
                                }
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >CLOSED</td>";
                            }

                            //}
                            //else if (intColumnBodyCount == 6)
                            //{
                            objEntityManpwrReqmt.ImgrtnId = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_ID"].ToString());

                            DataTable dtAssign = objBusinessManpwrReqmt.ReadEmployeebyDtlId(objEntityManpwrReqmt);
                            string stremp = "";
                            int intCount = 0;
                            intCount = dtAssign.Rows.Count;
                            if (dtAssign.Rows.Count != 0)
                            {
                                if (dtAssign.Rows.Count == 1)
                                {
                                    stremp = dtAssign.Rows[0]["USR_NAME"].ToString();
                                }
                                else
                                {
                                    string emp = "";
                                    string stremp1 = "";
                                    for (int i = 0; i < dtAssign.Rows.Count; i++)
                                    {
                                        if (intCount != (i + 1))
                                        {
                                            emp = dtAssign.Rows[i]["USR_NAME"].ToString();
                                        }

                                        emp = dtAssign.Rows[i]["USR_NAME"].ToString();
                                        if (stremp1 == "")
                                        {
                                            stremp1 = emp;
                                        }
                                        else
                                        {
                                            stremp1 = stremp1 + ", " + emp;

                                        }

                                        stremp = stremp1;
                                    }
                                }
                                strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + stremp + "</td>";
                            }

                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
                            }

                            //    for (int count = 0; count < dtAssign.Rows.Count;count++ )
                            //    {
                            //        if (Convert.ToInt32(dt.Rows[intRowBodyCount]["IMGTNDTL_ID"].ToString()) == Convert.ToInt32(dtAssign.Rows[count]["IMGTNDTL_ID"].ToString()))
                            //        {




                            //        }
                            //            strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
                            //}

                            //   }

                            // }
                            strHtml += "</tr>";

                        }
                
                    }

                       

                    //  strHtml += "</tr>";
                    else
                    {
                        strHtml += "<tr  >";
                        //for (int intColumnBodyCount = 0; intColumnBodyCount < 7; intColumnBodyCount++)
                        //{
                        // if (intColumnBodyCount == 1)
                        //{
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CAND_NAME"].ToString() + "</td>";
                        //}
                        // else if (intColumnBodyCount == 2)
                        // {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + "</td>";
                        //}

                        // else if (intColumnBodyCount == 3)
                        // {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString() + "</td>";
                        //}
                        //else if (intColumnBodyCount == 4)
                        // {


                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dtcandDtl.Rows[intcandCount]["IMGRTNRND_NAME"].ToString() + "</td>";

                        // }
                        // else if (intColumnBodyCount == 5)
                        //{
                        int finishsts = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_FNSH_STS"].ToString());
                        int clssts = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_CLOSE_STS"].ToString());
                        if (clssts == 0)
                        {
                            if (finishsts == 0)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dtcandDtl.Rows[intcandCount]["IMGRTNRNDDTL_NAME"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >FINISHED</td>";
                            }
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >CLOSED</td>";
                        }

                        //}
                        //else if (intColumnBodyCount == 6)
                        //{
                        objEntityManpwrReqmt.ImgrtnId = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_ID"].ToString());

                        DataTable dtAssign = objBusinessManpwrReqmt.ReadEmployeebyDtlId(objEntityManpwrReqmt);
                        string stremp = "";
                        int intCount = 0;
                        intCount = dtAssign.Rows.Count;
                        if (dtAssign.Rows.Count != 0)
                        {
                            if (dtAssign.Rows.Count == 1)
                            {
                                stremp = dtAssign.Rows[0]["USR_NAME"].ToString();
                            }
                            else
                            {
                                string emp = "";
                                string stremp1 = "";
                                for (int i = 0; i < dtAssign.Rows.Count; i++)
                                {
                                    if (intCount != (i + 1))
                                    {
                                        emp = dtAssign.Rows[i]["USR_NAME"].ToString();
                                    }

                                    emp = dtAssign.Rows[i]["USR_NAME"].ToString();
                                    if (stremp1 == "")
                                    {
                                        stremp1 = emp;
                                    }
                                    else
                                    {
                                        stremp1 = stremp1 + ", " + emp;

                                    }

                                    stremp = stremp1;
                                }
                            }
                            strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + stremp + "</td>";
                        }

                        else
                        {
                         //   strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
                        }

                        //    for (int count = 0; count < dtAssign.Rows.Count;count++ )
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[intRowBodyCount]["IMGTNDTL_ID"].ToString()) == Convert.ToInt32(dtAssign.Rows[count]["IMGTNDTL_ID"].ToString()))
                        //        {




                        //        }
                        //            strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
                        //}

                        //   }

                        // }
                        strHtml += "</tr>";
                    }

                }
        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
   
             

    //It build the Html table by using the datatable provided
    public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp)
    {
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntity_ImmigrationTaskReport objEntityManpwrReqmt = new clsEntity_ImmigrationTaskReport();

        string strTitle = "";
        strTitle = "Immigration Task Report ";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "";
        if (Session["USERFULLNAME"] != null)
        {
            usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        }
        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
        }
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

        StringBuilder sbCap = new StringBuilder();
        string strUsrName = "";
        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr + "</td></tr>";
        string strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDiv\">" + usrName + "</td></tr>";
        }
        string strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        

        string div = "";
        
       

        //string strCaptionTabstop = "</table>";
        //string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strCaptionTabTitle + strCaptionTabstop +div;


       

        //sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
       


    


        string strdiv = "";
        if (ddlRound.SelectedItem.Text.ToString() == "--SELECT IMMIGRATION ROUND--")
        {
            strdiv = "";
        }
        else
        {
            strdiv = "<tr>Immigration Round : " + ddlRound.SelectedItem.Text.ToString() + "<br/></tr>";
        }

        string strdept = "";
        if (Hiddenselectedtext.Value == "")
        {
            strdept = "";
        }
        else
        {
            strdept = "<tr>Candidate : " + Hiddenselectedtext.Value.TrimEnd(" , ".ToCharArray()) + "<br/></tr>";
        }
        string strAcc = "";

        if (ddlProject.SelectedItem.Text.ToString() == "--SELECT PROJECT--")
        {
            strAcc = "";
        }
        else
        {
            strAcc = "<tr>Project : " + ddlProject.SelectedItem.Text.ToString() + "<br/></tr>";
        }
        string strFrom = "";

        if (ddlEmployee.Text == "--SELECT EMPLOYEE--")
        {
            strFrom = "";
        }
        else
        {
            strFrom = "<tr>Assigned To : " + ddlEmployee.SelectedItem.Text.ToString() + "<br/></tr>";
        }
       
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strUsrName + strCaptionTabTitle + strCaptionTabstop + strdiv + strdept + strAcc + strFrom ;

        sbCap.Append(strPrintCaptionTable);
        //write to  divPrintCaption
        divPrintCaption.InnerHtml = sbCap.ToString();
      //  divPrintCaption.InnerHtml = sbCap.ToString();
            //write to  lblPrintOnBrdDtls

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < 7; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)//Ref#
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";
            }
            if (intColumnHeaderCount == 2)//Approved Date
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
            }
            if (intColumnHeaderCount == 3)//Department
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
            }
            if (intColumnHeaderCount == 4)//Designation
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">IMMIGRATION ROUND</th>";
            }
            if (intColumnHeaderCount == 5)//Division
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">STATUS</th>";
            }
            if (intColumnHeaderCount == 6)//Project
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">ASSIGNED TO</th>";
            }


        }
        if (dt.Columns.Count == 0)
        {
            strHtml += "<td class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">CANDIDATE NAME</th>";
            strHtml += "<td class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">PROJECT</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">DEPARTMENT</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">IMMIGRATION ROUND</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">STATUS</th>";
            strHtml += "<td class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">ASSIGNED TO</th>";
            
        }


        strHtml += "</tr>";


        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";


        if (dt.Rows.Count == 0)
        {
            strHtml += "<tr  >";
            strHtml += "<td  class=\"thT\" colspan=\"6\" style=\"font-weight: unset;width:6%;word-break: break-all; word-wrap:break-word;text-align: center;\" >No data available</td>";
            strHtml += "</tr>";          
        }

        string imground = "";
        string employee = "";
        if (ddlRound.SelectedItem.Text != "--SELECT IMMIGRATION ROUND--")
        {
            imground = ddlRound.SelectedItem.Text;
        }
        else
        {
            imground = "--SELECT IMMIGRATION ROUND--";
        }
        if (ddlEmployee.SelectedItem.Text != "--SELECT EMPLOYEE--")
        {
            employee = ddlEmployee.SelectedItem.Text;
        }
        else
        {
            employee = "--SELECT EMPLOYEE--";
        }

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {



            objEntityManpwrReqmt.CandId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CAND_ID"].ToString());
            DataTable dtcandDtl = objBusinessManpwrReqmt.readCandidateById(objEntityManpwrReqmt);
            //strHtml += "<tr  >";



            //  strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\">";

            // strHtml += "</td>";




            for (int intcandCount = 0; intcandCount < dtcandDtl.Rows.Count; intcandCount++)
            {
                if (imground != "--SELECT IMMIGRATION ROUND--")
                {

                    if (imground == dtcandDtl.Rows[intcandCount]["IMGRTNRND_NAME"].ToString())
                    {
                        //if (intcandCount!=0)
                        strHtml += "<tr  >";
                        //for (int intColumnBodyCount = 0; intColumnBodyCount < 7; intColumnBodyCount++)
                        //{
                        // if (intColumnBodyCount == 1)
                        //{
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CAND_NAME"].ToString() + "</td>";
                        //}
                        // else if (intColumnBodyCount == 2)
                        // {
                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + "</td>";
                        //}

                        // else if (intColumnBodyCount == 3)
                        // {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString() + "</td>";
                        //}
                        //else if (intColumnBodyCount == 4)
                        // {


                        strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dtcandDtl.Rows[intcandCount]["IMGRTNRND_NAME"].ToString() + "</td>";

                        // }
                        // else if (intColumnBodyCount == 5)
                        //{
                        int finishsts = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_FNSH_STS"].ToString());
                        int clssts = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_CLOSE_STS"].ToString());
                        if (clssts == 0)
                        {
                            if (finishsts == 0)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dtcandDtl.Rows[intcandCount]["IMGRTNRNDDTL_NAME"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >FINISHED</td>";
                            }
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >CLOSED</td>";
                        }

                        //}
                        //else if (intColumnBodyCount == 6)
                        //{
                        objEntityManpwrReqmt.ImgrtnId = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_ID"].ToString());

                        DataTable dtAssign = objBusinessManpwrReqmt.ReadEmployeebyDtlId(objEntityManpwrReqmt);
                        string stremp = "";
                        int intCount = 0;
                        intCount = dtAssign.Rows.Count;
                        if (dtAssign.Rows.Count != 0)
                        {
                            if (dtAssign.Rows.Count == 1)
                            {
                                stremp = dtAssign.Rows[0]["USR_NAME"].ToString();
                            }
                            else
                            {
                                string emp = "";
                                string stremp1 = "";
                                for (int i = 0; i < dtAssign.Rows.Count; i++)
                                {
                                    if (intCount != (i + 1))
                                    {
                                        emp = dtAssign.Rows[i]["USR_NAME"].ToString();
                                    }

                                    emp = dtAssign.Rows[i]["USR_NAME"].ToString();
                                    if (stremp1 == "")
                                    {
                                        stremp1 = emp;
                                    }
                                    else
                                    {
                                        stremp1 = stremp1 + ", " + emp;

                                    }

                                    stremp = stremp1;
                                }
                            }
                            strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + stremp + "</td>";
                        }

                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
                        }

                        //    for (int count = 0; count < dtAssign.Rows.Count;count++ )
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[intRowBodyCount]["IMGTNDTL_ID"].ToString()) == Convert.ToInt32(dtAssign.Rows[count]["IMGTNDTL_ID"].ToString()))
                        //        {




                        //        }
                        //            strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
                        //}

                        //   }

                        // }
                        strHtml += "</tr>";

                    }

                }



                //  strHtml += "</tr>";
                else
                {
                    strHtml += "<tr  >";
                    //for (int intColumnBodyCount = 0; intColumnBodyCount < 7; intColumnBodyCount++)
                    //{
                    // if (intColumnBodyCount == 1)
                    //{
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CAND_NAME"].ToString() + "</td>";
                    //}
                    // else if (intColumnBodyCount == 2)
                    // {
                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + "</td>";
                    //}

                    // else if (intColumnBodyCount == 3)
                    // {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString() + "</td>";
                    //}
                    //else if (intColumnBodyCount == 4)
                    // {


                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dtcandDtl.Rows[intcandCount]["IMGRTNRND_NAME"].ToString() + "</td>";

                    // }
                    // else if (intColumnBodyCount == 5)
                    //{
                    int finishsts = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_FNSH_STS"].ToString());
                    int clssts = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_CLOSE_STS"].ToString());
                    if (clssts == 0)
                    {
                        if (finishsts == 0)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dtcandDtl.Rows[intcandCount]["IMGRTNRNDDTL_NAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >FINISHED</td>";
                        }
                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >CLOSED</td>";
                    }

                    //}
                    //else if (intColumnBodyCount == 6)
                    //{
                    objEntityManpwrReqmt.ImgrtnId = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_ID"].ToString());

                    DataTable dtAssign = objBusinessManpwrReqmt.ReadEmployeebyDtlId(objEntityManpwrReqmt);
                    string stremp = "";
                    int intCount = 0;
                    intCount = dtAssign.Rows.Count;
                    if (dtAssign.Rows.Count != 0)
                    {
                        if (dtAssign.Rows.Count == 1)
                        {
                            stremp = dtAssign.Rows[0]["USR_NAME"].ToString();
                        }
                        else
                        {
                            string emp = "";
                            string stremp1 = "";
                            for (int i = 0; i < dtAssign.Rows.Count; i++)
                            {
                                if (intCount != (i + 1))
                                {
                                    emp = dtAssign.Rows[i]["USR_NAME"].ToString();
                                }

                                emp = dtAssign.Rows[i]["USR_NAME"].ToString();
                                if (stremp1 == "")
                                {
                                    stremp1 = emp;
                                }
                                else
                                {
                                    stremp1 = stremp1 + ", " + emp;

                                }

                                stremp = stremp1;
                            }
                        }
                        strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + stremp + "</td>";
                    }

                    else
                    {
                      //  strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
                    }

                   
                    strHtml += "</tr>";
                }

            }
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();


    }

  

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntity_ImmigrationTaskReport objEntityManpwrReqmt = new clsEntity_ImmigrationTaskReport();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityManpwrReqmt.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityManpwrReqmt.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlRound.SelectedItem.Text != "--SELECT IMMIGRATION ROUND--")
        {
            objEntityManpwrReqmt.ImgrtnRndId = Convert.ToInt32(ddlRound.SelectedItem.Value);
        }
        if (Hiddenselectedtext.Value!= "")
        {
            objEntityManpwrReqmt.CandidateId = (hiddenselectedlist.Value);
        }
        if (ddlProject.SelectedItem.Text != "--SELECT PROJECT--")
        {
            objEntityManpwrReqmt.pjtId = Convert.ToInt32(ddlProject.SelectedItem.Value);
        }
        if (ddlEmployee.SelectedItem.Text != "--SELECT EMPLOYEE--")
        {
            objEntityManpwrReqmt.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }

        DataTable dtManpwr = new DataTable();
        dtManpwr = objBusinessManpwrReqmt.ReadImmigrationTask(objEntityManpwrReqmt);

        string strHtm = ConvertDataTableToHTMLLL(dtManpwr);
        divReport.InnerHtml = strHtm;

        DataTable dtCorp = objBusinessManpwrReqmt.ReadCorporateAddress(objEntityManpwrReqmt);
        string strPrintReport = ConvertDataTableForPrint(dtManpwr, dtCorp);
        divPrintReport.InnerHtml = strPrintReport;
    }
    protected void BtnCSV_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable();
        string strImagePath = "";
        string filepath = "";
        string strResult = DataTableToCSV(dt, ',');
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }

        try
        {
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.IMMIGRATION_TASK_REPRT_CSV);
            string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
            string newFilePath = Server.MapPath("/CustomFiles/HCM CSV/ImmigrationTask/Immigration_Task_" + strNextId + ".csv");
            System.IO.File.WriteAllText(newFilePath, strResult);
            filepath = "Immigration_Task_" + strNextId + ".csv";
            Response.ContentType = "csv";
            strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.IMMIGRATION_TASK_REPRT_CSV);
            Response.AddHeader("content-Disposition", "attachment;filename=\"" + filepath + "\"");
            Response.TransmitFile(Server.MapPath(strImagePath) + filepath);
            Response.End();
            if (File.Exists(MapPath(strImagePath) + filepath))
            {
                File.Delete(MapPath(strImagePath) + filepath);
            }

        }
        catch (Exception)
        { }
    }
    public string DataTableToCSV(DataTable dtSIFHeader, char seperator)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < dtSIFHeader.Columns.Count; i++)
        {
            sb.Append(dtSIFHeader.Columns[i]);
            if (i < dtSIFHeader.Columns.Count - 1)
                sb.Append(seperator);
        }
        sb.AppendLine();
        foreach (DataRow dr in dtSIFHeader.Rows)
        {
            for (int i = 0; i < dtSIFHeader.Columns.Count; i++)
            {
                sb.Append(dr[i].ToString());

                if (i < dtSIFHeader.Columns.Count - 1)
                    sb.Append(seperator);
            }
            sb.AppendLine();
        }
        return sb.ToString();

    }
    public DataTable GetTable()
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable table = new DataTable();

        table.Columns.Add("CANDIDATE NAME", typeof(string));
        table.Columns.Add("PROJECT", typeof(string));
        table.Columns.Add("DEPARTMENT", typeof(string));
        table.Columns.Add("IMMIGRATION ROUND", typeof(string));
        table.Columns.Add("STATUS", typeof(string));
        table.Columns.Add("ASSIGNED TO", typeof(string));


        clsEntity_ImmigrationTaskReport objEntityManpwrReqmt = new clsEntity_ImmigrationTaskReport();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityManpwrReqmt.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            hiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityManpwrReqmt.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
            hiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlRound.SelectedItem.Text != "--SELECT IMMIGRATION ROUND--")
        {
            objEntityManpwrReqmt.ImgrtnRndId = Convert.ToInt32(ddlRound.SelectedItem.Value);
        }
        if (Hiddenselectedtext.Value != "")
        {
            objEntityManpwrReqmt.CandidateId = (hiddenselectedlist.Value);
        }
        if (ddlProject.SelectedItem.Text != "--SELECT PROJECT--")
        {
            objEntityManpwrReqmt.pjtId = Convert.ToInt32(ddlProject.SelectedItem.Value);
        }
        if (ddlEmployee.SelectedItem.Text != "--SELECT EMPLOYEE--")
        {
            objEntityManpwrReqmt.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }

        DataTable dt = new DataTable();
        dt = objBusinessManpwrReqmt.ReadImmigrationTask(objEntityManpwrReqmt);

        //for printing table
        string CandName = "";
        string Project = "";
        string Department = "";
        string ImmigrationRound = "";
        string Status = "";
        string AssignedTo = "";
        string imground = "";
        string employee = "";
        if (ddlRound.SelectedItem.Text != "--SELECT IMMIGRATION ROUND--")
        {
            imground = ddlRound.SelectedItem.Text;
        }
        else
        {
            imground = "--SELECT IMMIGRATION ROUND--";
        }
        if (ddlEmployee.SelectedItem.Text != "--SELECT EMPLOYEE--")
        {
            employee = ddlEmployee.SelectedItem.Text;
        }
        else
        {
            employee = "--SELECT EMPLOYEE--";
        }

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {



            objEntityManpwrReqmt.CandId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CAND_ID"].ToString());
            DataTable dtcandDtl = objBusinessManpwrReqmt.readCandidateById(objEntityManpwrReqmt);
            //strHtml += "<tr  >";



            //  strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\">";

            // strHtml += "</td>";




            for (int intcandCount = 0; intcandCount < dtcandDtl.Rows.Count; intcandCount++)
            {
                if (imground != "--SELECT IMMIGRATION ROUND--")
                {

                    if (imground == dtcandDtl.Rows[intcandCount]["IMGRTNRND_NAME"].ToString())
                    {
                        CandName = dt.Rows[intRowBodyCount]["CAND_NAME"].ToString();
                        Project = dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString();
                        Department = dt.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString();

                        ImmigrationRound = dtcandDtl.Rows[intcandCount]["IMGRTNRND_NAME"].ToString();
                       
                        int finishsts = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_FNSH_STS"].ToString());
                        int clssts = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_CLOSE_STS"].ToString());
                        if (clssts == 0)
                        {
                            if (finishsts == 0)
                            {
                                Status = dtcandDtl.Rows[intcandCount]["IMGRTNRNDDTL_NAME"].ToString();
                            }
                            else
                            {
                                Status = "FINISHED";
                            }
                        }
                        else
                        {
                            Status = "CLOSED";
                        }

                        //}
                        //else if (intColumnBodyCount == 6)
                        //{
                        objEntityManpwrReqmt.ImgrtnId = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_ID"].ToString());

                        DataTable dtAssign = objBusinessManpwrReqmt.ReadEmployeebyDtlId(objEntityManpwrReqmt);
                        string stremp = "";
                        int intCount = 0;
                        intCount = dtAssign.Rows.Count;
                        if (dtAssign.Rows.Count != 0)
                        {
                            if (dtAssign.Rows.Count == 1)
                            {
                                stremp = dtAssign.Rows[0]["USR_NAME"].ToString();
                            }
                            else
                            {
                                string emp = "";
                                string stremp1 = "";
                                for (int i = 0; i < dtAssign.Rows.Count; i++)
                                {
                                    if (intCount != (i + 1))
                                    {
                                        emp = dtAssign.Rows[i]["USR_NAME"].ToString();
                                    }

                                    emp = dtAssign.Rows[i]["USR_NAME"].ToString();
                                    if (stremp1 == "")
                                    {
                                        stremp1 = emp;
                                    }
                                    else
                                    {
                                        stremp1 = stremp1 + ", " + emp;

                                    }

                                    stremp = stremp1;
                                }
                            }
                            AssignedTo = stremp;
                        }

                        else
                        {
                            AssignedTo = dt.Rows[intRowBodyCount]["USR_NAME"].ToString();
                        }

                       

                    }

                }


                else
                {

                    CandName = dt.Rows[intRowBodyCount]["CAND_NAME"].ToString();
                    Project = dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString();
                    Department = dt.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString();

                    ImmigrationRound = dtcandDtl.Rows[intcandCount]["IMGRTNRND_NAME"].ToString();

                                    
                    int finishsts = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_FNSH_STS"].ToString());
                    int clssts = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_CLOSE_STS"].ToString());
                    if (clssts == 0)
                    {
                        if (finishsts == 0)
                        {
                            Status = dtcandDtl.Rows[intcandCount]["IMGRTNRNDDTL_NAME"].ToString();
                        }
                        else
                        {
                            Status = "FINISHED";
                        }
                    }
                    else
                    {
                        Status = "CLOSED";
                    }

                   
                    objEntityManpwrReqmt.ImgrtnId = Convert.ToInt32(dtcandDtl.Rows[intcandCount]["IMGTNDTL_ID"].ToString());

                    DataTable dtAssign = objBusinessManpwrReqmt.ReadEmployeebyDtlId(objEntityManpwrReqmt);
                    string stremp = "";
                    int intCount = 0;
                    intCount = dtAssign.Rows.Count;
                    if (dtAssign.Rows.Count != 0)
                    {
                        if (dtAssign.Rows.Count == 1)
                        {
                            stremp = dtAssign.Rows[0]["USR_NAME"].ToString();
                        }
                        else
                        {
                            string emp = "";
                            string stremp1 = "";
                            for (int i = 0; i < dtAssign.Rows.Count; i++)
                            {
                                if (intCount != (i + 1))
                                {
                                    emp = dtAssign.Rows[i]["USR_NAME"].ToString();
                                }

                                emp = dtAssign.Rows[i]["USR_NAME"].ToString();
                                if (stremp1 == "")
                                {
                                    stremp1 = emp;
                                }
                                else
                                {
                                    stremp1 = stremp1 + ", " + emp;

                                }

                                stremp = stremp1;
                            }
                        }
                        AssignedTo = stremp;
                    }

                    else
                    {
                        //   strHtml += "<td class=\"tdT\" style=\" width:17%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["USR_NAME"].ToString() + "</td>";
                    }

                  
                }
                table.Rows.Add('"' + CandName + '"', '"' + Project + '"', '"' + Department + '"', '"' + ImmigrationRound + '"', '"' + Status + '"', '"' + AssignedTo + '"');
            }
           

        }

        return table;
    }
}