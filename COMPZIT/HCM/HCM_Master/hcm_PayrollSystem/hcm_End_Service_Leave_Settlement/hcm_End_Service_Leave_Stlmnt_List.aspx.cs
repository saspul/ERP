using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using System.Text;

public partial class HCM_HCM_Master_hcm_PayrollSystem_hcm_End_Service_Leave_Settlement_hcm_End_Service_Leave_Stlmnt_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            LoadFormData();
            Session["EDIT_ID"] = null;
            Session["VIEW_ID"] = null;
            Session["READ"] = null;
            HiddenSuccessMsgType.Value = "0";
            if (Session["SuccessMsg"] != null)
            {
                HiddenSuccessMsgType.Value = Session["SuccessMsg"].ToString();
            }
            Session["SuccessMsg"] = null;
            //LoadCountry();
            //LoadConsultancyType();
            //ddlCnsltyType.Focus();
            int intUserId = 0, intUsrRolMstrId = 0, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableConfirm=0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.End_Of_Service_Leave_Settlement);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //future

                    }

                }

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    divAdd.Visible = true;

                }
                else
                {

                    divAdd.Visible = false;

                }

                hiddenEnableModify.Value = Convert.ToString(intEnableModify);
                hiddenEnableCancl.Value = Convert.ToString(intEnableCancel);
                hiddenEnableConfirm.Value = Convert.ToString(intEnableConfirm);





                //Creating objects for business layer
                clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
                clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();


                //  objEntityLayerEndOfServiceLeaveStlmnt.ConsultancyStatus = 1;
                DataTable dtCorpDetail = new DataTable();
                int intCorpId = 0;

                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLayerEndOfServiceLeaveStlmnt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else 
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityLayerEndOfServiceLeaveStlmnt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else 
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["USERID"] != null)
                {
                    objEntityLayerEndOfServiceLeaveStlmnt.UserId = Convert.ToInt32(Session["USERID"].ToString());
                }
                else 
                {
                    Response.Redirect("~/Default.aspx");
                }

                clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE 

                                                               };

                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);


                if (dtCorpDetail.Rows.Count > 0)
                {
                    string strListingMode = dtCorpDetail.Rows[0]["LISTING_MODE"].ToString();
                    string strLstingModeSize = dtCorpDetail.Rows[0]["LISTING_MODE_SIZE"].ToString();
                    string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();

                    hiddenCnclrsnMust.Value = CnclrsnMust;



                    DataTable dtProductSrch = new DataTable();

                    objEntityLayerEndOfServiceLeaveStlmnt.ConfirmStatus = 0;

                    dtProductSrch = objBusinessLayerEndOfServiceLeaveStlmnt.ReadSrvLevStlmntList(objEntityLayerEndOfServiceLeaveStlmnt);

                    string strHtm = ConvertDataTableToHTML(dtProductSrch, intEnableModify, intEnableCancel, intEnableConfirm);
                    //Write to divReport
                    divReport.InnerHtml = strHtm;


                }
            }
        }
    }


    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableConfirm)
    {


        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"dt_basic\" class=\"table table-striped table-bordered \"  >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr>";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th  style=\"width:15%;text-align: left; word-wrap:break-word;\">EMPLOYEE ID</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th  style=\"width:20%;text-align: left; word-wrap:break-word;\">EMPLOYEE NAME</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th   style=\"width:15%;text-align: center; word-wrap:break-word;\">DATE OF LEAVING</th>";
            }

            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th   style=\"width:10%;text-align: center; word-wrap:break-word;\">STATUS</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th   style=\"width:15%;text-align: right; word-wrap:break-word;\">NET AMOUNT</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th   style=\"width:10%;text-align: center; word-wrap:break-word;\">SETTLED DATE</th>";
            }

        }
        if (cbxCnclStatus.Checked == false )
        {
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active) || intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
               strHtml += "<th  style=\"width:5%; word-wrap:break-word;text-align: center;\">EDIT </th>";
            }

            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                strHtml += "<th  style=\"width:5%; word-wrap:break-word;text-align: center;\">DELETE </th>";
            }

            if (hiddenPaidMode.Value == "1"  )
            {
                if (dt.Rows.Count > 0)
                {
                    strHtml += " <th class=\"hasinput\" style=\"width:5%;\"><button id=\"btnPaidAll\"  onclick=\"return ToPaidAll();\" style=\"width: 100%;background-color: #88bdf2;border: 1px solid darkblue;\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\">paid</button>";
                }
                else
                {
                    strHtml += " <th class=\"hasinput\" style=\"width:5%;\"><button id=\"btnPaidAll\" onclick=\"return false;\"  style=\"width: 100%;background-color: #88bdf2;border: 1px solid darkblue;\" class=\"btn btn-xs btn-default\"  data-original-title=\"Edit Row\">paid</button>";
                }
            }


        }
        else
        {
            strHtml += "<th  style=\"width:5%; word-wrap:break-word;text-align: center;\">VIEW </th>";
        }


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            strHtml += "<tr  >";

            //SRVCLVE_STLMT_ID
            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class='tdT' style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <a   style=\"cursor:pointer;color: blue;\"  title=\"View\" onclick=\"return ViewPopUp('" + dt.Rows[intRowBodyCount][0] + "');\" >" + dt.Rows[intRowBodyCount]["USR_CODE"].ToString() + "</a></td>";
                }
                //EMP-0043 START
                else if (intColumnBodyCount == 2)
                {
                    if (ddlStatus.SelectedItem.Value == "1")
                    {
                        if (dt.Rows[intRowBodyCount]["EMPERDTL_PAYMENT_STS"].ToString() == "1")
                        {
                            strHtml += "<td class='tdT'  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "<img title=\"Cash\"src='/Images/Icons/csh.png'></img></td>";
                        }
                        else
                        {
                            strHtml += "<td class='tdT'  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
                        }
                    }
                    else
                    {
                        if (dt.Rows[intRowBodyCount]["SRVCLVE_PRE_MNTH_PAYMENT_TYPE"].ToString() == "1")
                        {
                            strHtml += "<td class='tdT'  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "<img title=\"Cash\"src='/Images/Icons/csh.png'></img></td>";
                        }
                        else
                        {
                            strHtml += "<td class='tdT'  style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["EMPLOYEE"].ToString() + "</td>";
                        }
                    }
                }
                //END
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class='tdT'  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["DATE OF LEAVING"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class='tdT'  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class='tdT'  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + dt.Rows[intRowBodyCount]["NET AMOUNT"].ToString() + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class='tdT'  style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount]["SETTLED DATE"].ToString() + "</td>";
                }

            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = strId;



            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active) || intEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (cbxCnclStatus.Checked == false)
                {
                    string strIcon = "fa fa-pencil";
                    if (dt.Rows[intRowBodyCount]["CNFRM_STS"].ToString() != "0")
                    {
                        strIcon = "fa fa-eye";
                    }
                    strHtml += " <td class='tdT' style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button title='Edit' class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" onclick=\"return EditItem(" + Id + ");\"><i class=\"" + strIcon + "\"></i></button>";

                   
                }


            }
            if (cbxCnclStatus.Checked == true)
            {
                strHtml += " <td class='tdT' style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button title='View' class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" onclick=\"return ViewItem(" + Id + ");\"><i class=\"fa fa-eye\"></i></button>";


            }
            if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (cbxCnclStatus.Checked == false)
                {
                    //fa fa-trash-o
                    if (dt.Rows[intRowBodyCount]["CNFRM_STS"].ToString() != "0")
                    {
                        strHtml += " <td class='tdT' style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button title='Delete' class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" onclick=\"return CancelNotPosible();\"><i style='opacity: 0.3;' class=\"fa fa-trash-o\"></i></button>";

                    }
                    else
                    {
                        strHtml += " <td class='tdT' style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button title='Delete' class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" onclick=\"return DeleteItem(" + Id + ");\"><i class=\"fa fa-trash-o\"></i></button>";

                    }

                    if (hiddenPaidMode.Value == "1")
                    {
                        if (dt.Rows[intRowBodyCount]["CNFRM_STS"].ToString() != "4")
                        {
                            strHtml += " <td style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button  style=\"width: 100%;background-color: #dedada;\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" disabled=\"true\" >paid</button></td>";
                        }
                        else
                        {
                            strHtml += " <td style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button id=\"btnPaid" + intRowBodyCount + "\"  style=\"width: 100%;background-color: #dedada;\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\"   onclick=\"return ToPaid(" + Id + "," + intRowBodyCount + ");\">paid</button>  </td>";
                        }
                    }

                }
                else
                {
                    
                }
            }
            strHtml += "</tr>";
        }




        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();      
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
        clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();
        clsCommonLibrary objCommon=new clsCommonLibrary();
        DataTable dtProductSrch = new DataTable();



        int intEnableModify = 0, intEnableCancel = 0, intEnableConfirm=0;
        intEnableModify = Convert.ToInt32(hiddenEnableModify.Value);
        intEnableCancel = Convert.ToInt32(hiddenEnableCancl.Value);
        intEnableConfirm = Convert.ToInt32(hiddenEnableConfirm.Value);

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLayerEndOfServiceLeaveStlmnt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLayerEndOfServiceLeaveStlmnt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityLayerEndOfServiceLeaveStlmnt.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (HiddentxtDateOfLeaving.Value!="0"&& HiddentxtDateOfLeaving.Value!="")
        {
            objEntityLayerEndOfServiceLeaveStlmnt.DateOfLeaving = objCommon.textToDateTime(HiddentxtDateOfLeaving.Value);
        }
        if (cbxCnclStatus.Checked==true)
        {
            objEntityLayerEndOfServiceLeaveStlmnt.CancelStatus = 1;
        }
        else
        {
            objEntityLayerEndOfServiceLeaveStlmnt.CancelStatus = 0; 
        }
        if (ddlEmployeeStatus.SelectedItem.Value!="0"&& ddlEmployeeStatus.SelectedItem.Value!="--SELECT STATUS--")
        {
             objEntityLayerEndOfServiceLeaveStlmnt.EmployeeStatus = Convert.ToInt32(ddlEmployeeStatus.SelectedItem.Value); 
        }
        if (ddlEmployee.SelectedItem.Value != "0" && ddlEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            objEntityLayerEndOfServiceLeaveStlmnt.EmployeeID = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }

        hiddenPaidMode.Value = "";

        if (ddlStatus.SelectedItem.Value == "1")
        {
            objEntityLayerEndOfServiceLeaveStlmnt.ConfirmStatus = 0;
        }
        else if (ddlStatus.SelectedItem.Value == "2")
        {
            objEntityLayerEndOfServiceLeaveStlmnt.ConfirmStatus = 1;
        }
        else if (ddlStatus.SelectedItem.Value == "3")
        {
            objEntityLayerEndOfServiceLeaveStlmnt.ConfirmStatus = 4;
            hiddenPaidMode.Value = "1";
        }
        else if (ddlStatus.SelectedItem.Value == "4")
        {
            objEntityLayerEndOfServiceLeaveStlmnt.ConfirmStatus = 3;
        }
        else if (ddlStatus.SelectedItem.Value == "5")
        {
            objEntityLayerEndOfServiceLeaveStlmnt.ConfirmStatus = 2;
        }


        dtProductSrch = objBusinessLayerEndOfServiceLeaveStlmnt.ReadSrvLevStlmntList(objEntityLayerEndOfServiceLeaveStlmnt);
        string strHtm = ConvertDataTableToHTML(dtProductSrch, intEnableModify, intEnableCancel, intEnableConfirm);
        //Write to divReport
        divReport.InnerHtml = strHtm;
    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {

    }
    [System.Web.Services.WebMethod]
    public static string CancelServiceStlmnt(string strServiceLveSttlmntID, string strUserID, string strCancelReason, string strCancelMust)
    {
        string strResult = "TRUE";
        clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
        clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();
        try
        {
            objEntityLayerEndOfServiceLeaveStlmnt.EndSrvLveStlmntID = Convert.ToInt32(strServiceLveSttlmntID);
            objEntityLayerEndOfServiceLeaveStlmnt.UserId = Convert.ToInt32(strUserID);
            if (strCancelMust == "0")
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();
                objEntityLayerEndOfServiceLeaveStlmnt.CancelReason = objCommon.CancelReason();
            }
            else
            {
                objEntityLayerEndOfServiceLeaveStlmnt.CancelReason = strCancelReason;
            }
            objBusinessLayerEndOfServiceLeaveStlmnt.CancelSrvLevStlmnt(objEntityLayerEndOfServiceLeaveStlmnt);
            Page objpage = new Page();
            objpage.Session["SuccessMsg"] = "DELETE"; 
        }
        catch (Exception ex)
        {
            strResult = "FALSE";
            throw ex;
        }
        return strResult;
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (hiddenEditID.Value!="0")
        {
            Session["EDIT_ID"] = hiddenEditID.Value;
            Session["VIEW_ID"] = null;
        }
        else if (hiddenViewID.Value != "0")
        {
            Session["VIEW_ID"] = hiddenViewID.Value;
            Session["EDIT_ID"] = null;

        }
        else
        {
            Response.Redirect("hcm_End_Service_Leave_Stlmnt_List.aspx");
        }
        Response.Redirect("hcm_End_Service_Leave_Settlement.aspx");
    }
    protected void LoadFormData()
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

       
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable DtLevAlloDetails = new DataTable();
        DtLevAlloDetails = objBusinessLayer.ReadEmployeeDtl(objEntityCommon);
        if (DtLevAlloDetails.Rows.Count > 0)
        {
            ddlEmployee.DataSource = DtLevAlloDetails;
            ddlEmployee.DataValueField = "USR_ID";
            ddlEmployee.DataTextField = "USR_NAME";
            ddlEmployee.DataBind();

        }
        ddlEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");

    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        if (hiddenViewValue.Value != "")
        {
            Session["EDIT"] = null;
            Session["VIEW"] = null;
            Session["READ"] = hiddenViewValue.Value;
            ScriptManager.RegisterStartupScript(this, GetType(), "openWindowLeave", "openWindowLeave();", true);
        }
    }


    [System.Web.Services.WebMethod]
    public static string UpdateSettledStatus(string Id)
    {
        string ret = "TRUE";
        clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
        clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();

        if (Id != "")
        {
            objEntityLayerEndOfServiceLeaveStlmnt.EndSrvLveStlmntID = Convert.ToInt32(Id);
        }
 
        objBusinessLayerEndOfServiceLeaveStlmnt.UpdateSettledStatus(objEntityLayerEndOfServiceLeaveStlmnt);
        Page objpage = new Page();
        objpage.Session["SUCCESS_MSG"] = "PAID"; 
        return ret;
    } 
    [System.Web.Services.WebMethod]
    public static string PaidAll_UpdateSettledStatus(string strOrgID, string strCorpID)
    {
        string ret = "TRUE";
        clsBusinessLayerEndOfServiceLeaveStlmnt objBusinessLayerEndOfServiceLeaveStlmnt = new clsBusinessLayerEndOfServiceLeaveStlmnt();
        clsEntityLayerEndOfServiceLeaveStlmnt objEntityLayerEndOfServiceLeaveStlmnt = new clsEntityLayerEndOfServiceLeaveStlmnt();

        if (strOrgID != "" && strCorpID!="")
        {
            objEntityLayerEndOfServiceLeaveStlmnt.OrgId = Convert.ToInt32(strOrgID);
            objEntityLayerEndOfServiceLeaveStlmnt.CorpId = Convert.ToInt32(strCorpID);
        }

        objBusinessLayerEndOfServiceLeaveStlmnt.PaidAll_UpdateSettledStatus(objEntityLayerEndOfServiceLeaveStlmnt);
        Page objpage = new Page();
        objpage.Session["SUCCESS_MSG"] = "PAID"; 
        return ret;
    }
}