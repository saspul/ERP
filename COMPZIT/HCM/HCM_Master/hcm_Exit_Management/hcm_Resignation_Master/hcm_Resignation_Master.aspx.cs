using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using BL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Web.Services;
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Xml;
using System.Web.Script.Serialization;
using System.Globalization;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public partial class HCM_HCM_Master_hcm_Exit_Management_hcm_Resignation_Master_hcm_Resignation_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtPrfrdDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtPrfrdDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtReason.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtReason.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtPrfrdDate.Focus();
          if (!IsPostBack)
          {

              btnConfirm.Visible = false;

              clsBusinessLayerResignation objBusinessResignation = new clsBusinessLayerResignation();
              clsEntityLayerResignation objEntityResignation = new clsEntityLayerResignation();
              clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
              clsCommonLibrary objCommon = new clsCommonLibrary();

              string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
              hiddenCurrentDate.Value = strCurrentDate;

              int intUserId = 0, intUsrRolMstrId, intEnableCancel=0, intEnableEdit=0, intEnableAdd=0;

              if (Session["CORPOFFICEID"] != null)
              {
                  objEntityResignation.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

              }

              if (Session["ORGID"] != null)
              {
                  objEntityResignation.OrgId =Convert.ToInt32( Session["ORGID"].ToString());

              }
              if (Session["USERID"] != null)
              {
                  intUserId = Convert.ToInt32(Session["USERID"].ToString());
                  HiddenFieldEmpId.Value=Session["USERID"].ToString();
                  objEntityResignation.UserId = Convert.ToInt32(Session["USERID"].ToString());
              }
              else if (Session["USERID"] == null)
              {
                  Response.Redirect("/Default.aspx");
              }
              //Allocating child roles
              intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Resignation_Form);

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
                          intEnableEdit = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                         
                      }
                      else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                      {
                          intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                          HiddenFieldCancelUsrRole.Value = "1";
                      }
                     

                  }


                 DataTable dtEmpDetails = objBusinessResignation.ReadEmpDetails(objEntityResignation);
                 if (dtEmpDetails.Rows.Count > 0)
                 {

                    DataTable dtDivisions = objBusinessResignation.ReadDivisionOfEmp(objEntityResignation);
                    string strDivisions = "";
                    foreach (DataRow dtDiv in dtDivisions.Rows)
                    {
                        if (strDivisions == "")
                        {
                            strDivisions = dtDiv["CPRDIV_NAME"].ToString().ToUpper();
                        }
                        else
                        {
                            strDivisions = strDivisions + "," + dtDiv["CPRDIV_NAME"].ToString().ToUpper();
                        }
                    }


                    lblDivision.Text = strDivisions;


                    string strDate = dtEmpDetails.Rows[0]["EMPERDTL_FNAME"].ToString();
                    if (strDate != "")
                    {
                        strDate = dtEmpDetails.Rows[0]["EMPERDTL_FNAME"].ToString().ToUpper() + " " + dtEmpDetails.Rows[0]["EMPERDTL_MNAME"].ToString().ToUpper() + " " + dtEmpDetails.Rows[0]["EMPERDTL_LNAME"].ToString().ToUpper();
                    }
                    else
                    {
                        strDate = dtEmpDetails.Rows[0]["USR_NAME"].ToString().ToUpper();
                    }


                    lblEmpname.Text = strDate;
                    lblDesg.Text = dtEmpDetails.Rows[0]["DESIGNATION"].ToString().ToUpper();
                    lblDeprtmnt.Text = dtEmpDetails.Rows[0]["DEPARTMENT"].ToString().ToUpper();
                    lblPaygrade.Text = dtEmpDetails.Rows[0]["PYGRD_NAME"].ToString().ToUpper();
                 





                }

                 DataTable dtNtcprd = objBusinessResignation.ReadNoticePrd(objEntityResignation);
                 if (dtNtcprd.Rows.Count > 0)
                 {
                     lblResgnMsg.Text = "You have " + dtNtcprd.Rows[0][0].ToString() + " days of notice period for leaving from this organisation";
                 }
                 

           DataTable dtEmpCheck = objBusinessResignation.CheckEmp(objEntityResignation);
           if(dtEmpCheck.Rows.Count>0)
           {
               if (dtEmpCheck.Rows[0]["END_SRVC_STLMNT_STS"].ToString() == "1" || dtEmpCheck.Rows[0]["END_SRVC_STLMNT_STS"].ToString() == "2")
               {
                    HiddenFieldEndServiceSts.Value = "1";
               }

               btnAdd.Visible=false;
               btnClear.Visible=false;
               txtPrfrdDate.Text = dtEmpCheck.Rows[0]["PRFRD_DATE"].ToString();
               txtReason.Text = dtEmpCheck.Rows[0]["RSGNTN_USR_REASON"].ToString();

               HiddenFieldResgntnSts.Value = dtEmpCheck.Rows[0]["RSGNTN_STATUS"].ToString();
               HiddenFieldResgntnId.Value = dtEmpCheck.Rows[0]["RSGNTN_ID"].ToString();

               if (dtEmpCheck.Rows[0]["RSGNTN_STATUS"].ToString() == "0")
               {
                   btnConfirm.Visible = true;
                   if (intEnableEdit == 1)
                   {
                       btnUpdate.Visible = true;
                   }
                   else
                   {
                       btnUpdate.Visible = false;
                   }
               }
               else
               {
                   btnUpdate.Visible = false;
                   btnConfirm.Visible = false;


                   txtPrfrdDate.Enabled = false;
                   txtReason.Enabled = false;

                   if (dtEmpCheck.Rows[0]["RSGNTN_STATUS"].ToString() == "1")
                   {
                       status1.InnerText = "Approval Pending";
                       status2.InnerText = "";
                   }
                   else if (dtEmpCheck.Rows[0]["RSGNTN_STATUS"].ToString() == "2")
                   {
                       status1.InnerText = "Reporting Officer Approved";
                       status2.InnerText = "Waiting For Division Manager Decision";
                   }
                   else if (dtEmpCheck.Rows[0]["RSGNTN_STATUS"].ToString() == "3")
                   {
                       status1.InnerText = "Division Manager Approved";
                       status2.InnerText = "Waiting For HR Decision";
                   }
                   else if (dtEmpCheck.Rows[0]["RSGNTN_STATUS"].ToString() == "4")
                   {
                       status1.InnerText = "HR Approved";
                       status2.InnerText = "Waiting For GM Decision";
                   }
                   else if (dtEmpCheck.Rows[0]["RSGNTN_STATUS"].ToString() == "5")
                   {
                       status1.InnerText = "GM Approved";
                       status2.InnerText = "Waiting For Final HR Decision";
                   }
                   else if (dtEmpCheck.Rows[0]["RSGNTN_STATUS"].ToString() == "6")
                   {
                       status1.InnerText = "Resignation Approved";
                       status2.InnerText = "";
                   }

                   else if (dtEmpCheck.Rows[0]["RSGNTN_STATUS"].ToString() == "7")
                   {
                       status1.InnerText = "Rejected";
                       status2.InnerText = "";
                   }
                   else if (dtEmpCheck.Rows[0]["RSGNTN_STATUS"].ToString() == "8")
                   {
                       status1.InnerText = "Cancelled";
                       status2.InnerText = "";
                   }
                   else if (dtEmpCheck.Rows[0]["RSGNTN_STATUS"].ToString() == "9")
                   {
                       status1.InnerText = "Closed";
                       status2.InnerText = "";
                   }
                  
                 
               }

           }
           else{
            btnUpdate.Visible=false;
            btnClear.Visible=true;
            btnConfirm.Visible=false;
            if (intEnableAdd == 1)
            {
                btnAdd.Visible = true;
            }
            else
            {
                btnAdd.Visible = false;
            }

           }
                 
                 
                 if (Request.QueryString["Ins"] != null)
                 {

                     string strInsUpd = Request.QueryString["Ins"].ToString();
                     if (strInsUpd == "Ins")
                     {
                         ScriptManager.RegisterStartupScript(this, GetType(), "SuccessAdd", "SuccessAdd();", true);
                     }
                     else if (strInsUpd == "Upd")
                     {
                         ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpd", "SuccessUpd();", true);
                     }
                     else if (strInsUpd == "Cnfrm")
                     {
                         ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCnfrm", "SuccessCnfrm();", true);
                     }
                     else if (strInsUpd == "Cncl")
                     {
                         ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancel", "SuccessCancel();", true);
                     }
                     
                      else if (strInsUpd == "InsStf")
                     {
                         ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsClrnce", "SuccessInsClrnce();", true);
                     }
                     else if (strInsUpd == "UpdStf")
                     {
                         ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdClrnce", "SuccessUpdClrnce();", true);
                     }

                     
                         
                     
                 }

              }        
              
          }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        clsBusinessLayerResignation objBusinessResignation = new clsBusinessLayerResignation();
        clsEntityLayerResignation objEntityResignation = new clsEntityLayerResignation();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityResignation.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }

        if (Session["ORGID"] != null)
        {
            objEntityResignation.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        if (Session["USERID"] != null)
        {
          
            objEntityResignation.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }

       
        if (txtPrfrdDate.Text != "")
        {
            objEntityResignation.PreferdDate = objCommon.textToDateTime(txtPrfrdDate.Text);
        }

        objEntityResignation.Reason = txtReason.Text;
        objEntityResignation.UserDate = System.DateTime.Now;
        objBusinessResignation.AddResignation(objEntityResignation);
        Response.Redirect("hcm_Resignation_Master.aspx?Ins=Ins");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        clsBusinessLayerResignation objBusinessResignation = new clsBusinessLayerResignation();
        clsEntityLayerResignation objEntityResignation = new clsEntityLayerResignation();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityResignation.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }

        if (Session["ORGID"] != null)
        {
            objEntityResignation.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        if (Session["USERID"] != null)
        {

            objEntityResignation.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }


        if (txtPrfrdDate.Text != "")
        {
            objEntityResignation.PreferdDate = objCommon.textToDateTime(txtPrfrdDate.Text);
        }
        objEntityResignation.ResgntnId = Convert.ToInt32(HiddenFieldResgntnId.Value);
     
       
        objEntityResignation.Reason = txtReason.Text;
        objEntityResignation.UserDate = System.DateTime.Now;
        objBusinessResignation.UpdateResignation(objEntityResignation);
        Response.Redirect("hcm_Resignation_Master.aspx?Ins=Upd");
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {

        clsBusinessLayerResignation objBusinessResignation = new clsBusinessLayerResignation();
        clsEntityLayerResignation objEntityResignation = new clsEntityLayerResignation();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityResignation.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }

        if (Session["ORGID"] != null)
        {
            objEntityResignation.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

        }
        if (Session["USERID"] != null)
        {

            objEntityResignation.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }


        if (txtPrfrdDate.Text != "")
        {
            objEntityResignation.PreferdDate = objCommon.textToDateTime(txtPrfrdDate.Text);
        }
        objEntityResignation.ResgntnId = Convert.ToInt32(HiddenFieldResgntnId.Value);
        objEntityResignation.Reason = txtReason.Text;
        objEntityResignation.UserDate = System.DateTime.Now;
        objBusinessResignation.UpdateResignation(objEntityResignation);
        objBusinessResignation.ConfirmResignation(objEntityResignation);
        Response.Redirect("hcm_Resignation_Master.aspx?Ins=Cnfrm");
    }

    protected void btnClrnceLink_Click(object sender, EventArgs e)
    {
        Response.Redirect("/HCM/HCM_Master/hcm_LeaveMaster/hcm_Clearance_Form_Staff/hcm_Clearance_Form_Staff.aspx?ResgId=" + HiddenFieldResgntnId.Value + "");
    }
    [WebMethod]
    public static void CancelRqst(int ResgntnId, int UserId)
    {
        clsBusinessLayerResignation objBusinessResignation = new clsBusinessLayerResignation();
        clsEntityLayerResignation objEntityResignation = new clsEntityLayerResignation();
        objEntityResignation.ResgntnId = ResgntnId;
        objEntityResignation.UserId = UserId;
        objEntityResignation.UserDate = System.DateTime.Now;
        
        DataTable LvStfId = objBusinessResignation.ReadLvStfId(objEntityResignation);
        if (LvStfId.Rows.Count > 0)
        {
            int StafId = 0;
            if (LvStfId.Rows[0]["LVECLRSTF_ID"].ToString()!="")
            {
                StafId =Convert.ToInt32(LvStfId.Rows[0]["LVECLRSTF_ID"].ToString());
                
            }
            objEntityResignation.LvStfClrId =  StafId;
        }
        objBusinessResignation.CancelClearnce(objEntityResignation);
        objBusinessResignation.CancelClearnceDtls(objEntityResignation);
        objBusinessResignation.CancelResignation(objEntityResignation);
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("hcm_Resignation_Master.aspx");
    }
}