using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit;
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

public partial class HCM_HCM_Master_hcm_Immigration_hcm_Immigration_Task_hcm_Immigration_Task : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ddlVisaSts.Attributes.Add("onkeypress", "return isTagEnter(event)");
        txtVisaExptdDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtScdldDate.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {

            clsEntityImmigrationTasks objEntityImgrtnTasks = new clsEntityImmigrationTasks();
            clsBusinessImmigrationTasks objBusinessImgrtnTasks = new clsBusinessImmigrationTasks();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableClose = 0, intEnableHold = 0, intEnableReopen = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
            hiddenCurrentDate.Value = strCurrentDate;

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                HiddenFieldLogUserId.Value = Session["USERID"].ToString();
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Immigration_Tasks);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                    {
                        intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }

                }



                if (Session["USERID"] != null)
                {
                    objEntityImgrtnTasks.UserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityImgrtnTasks.CorpOffice = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityImgrtnTasks.Orgid = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                HiddenFieldRoundNo.Value = "0";
                if (Request.QueryString["x"] != null)
                {

                HiddenFieldRoundNo.Value = Request.QueryString["x"].ToString();
                }

                //string rBoxCheckId = Request.QueryString["Rid"].ToString();

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                HiddenFieldQryId.Value = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityImgrtnTasks.CandId = Convert.ToInt32(strId);
                HiddenFieldCandId.Value = strId;
                DataTable dt = objBusinessImgrtnTasks.ReadEmpInfoById(objEntityImgrtnTasks);
                if (dt.Rows.Count > 0)
                {

                    lblCandtName.Text = dt.Rows[0]["EMPERDTL_REF_NUM"].ToString();
                    lblLoctn.Text = dt.Rows[0]["EMPERDTL_EMPLOYEE_ID"].ToString();
                    lblRefEmp.Text = dt.Rows[0]["USR_NAME"].ToString();
                    lblResume.Text = dt.Rows[0]["DSGN_NAME"].ToString();
                    lblNation.Text = dt.Rows[0]["Type"].ToString();
                    lblVisa.Text = dt.Rows[0]["JOBRL_NAME"].ToString();
                    lblJoinDate.Text = dt.Rows[0]["JOIN DATE"].ToString();
                }
                objEntityImgrtnTasks.ImgrtnDetailId = Convert.ToInt32(strId);

                DataTable dtPartlrDtls = objBusinessImgrtnTasks.ReadEmpRoundDtls(objEntityImgrtnTasks);
                string strHtml = "";
                int count = 0;
                HiddenFieldShowDiv.Value = "false";
                foreach (DataRow Rowdt in dtPartlrDtls.Rows)
                {
                    objEntityImgrtnTasks.ImgrtnDetailId = Convert.ToInt32(Rowdt["IMGTNDTL_ID"].ToString());
                    DataTable dtAsgndEmpPartclr = objBusinessImgrtnTasks.ReadEmpAsgnedForRnd(objEntityImgrtnTasks);
                    if (dtAsgndEmpPartclr.Rows.Count > 0)
                    {
                        strHtml += "<div id=\"Tab" + count + "\" class=\"divbutton\" onclick='TabClick(" + count + ");'>" + Rowdt["IMGRTNRND_NAME"].ToString() + "</div>";
                        count++;
                        HiddenFieldShowDiv.Value = "true";
                    }
                }
                HiddenFieldNoRnd.Value=count.ToString();
                divTabs.InnerHtml = strHtml;


                hiddenMsgType.Value = "";
               
                if (Request.QueryString["Ins"] != null)
                {

                    string strInsUpd = Request.QueryString["Ins"].ToString();
                    if (strInsUpd == "Ins")
                    {
                        //ScriptManager.RegisterStartupScript(this, GetType(), "SuccessAdd", "SuccessAdd();", true);
                        hiddenMsgType.Value = "SuccessAdd";
                    }
                    else if (strInsUpd == "Resdl")
                    {
                        //ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRescdl", "SuccessRescdl();", true);
                        hiddenMsgType.Value = "SuccessRescdl";
                    }
                    else if (strInsUpd == "Finish")
                    {
                        //ScriptManager.RegisterStartupScript(this, GetType(), "SuccessFinish", "SuccessFinish();", true);
                        hiddenMsgType.Value = "SuccessFinish";
                    }
                    else if (strInsUpd == "Dup")
                    {
                        //ScriptManager.RegisterStartupScript(this, GetType(), "DupFinishCls", "DupFinishCls();", true);
                        hiddenMsgType.Value = "DupFinishCls";
                    }
                    
                }

            }
        }

    }
    protected void btnAddVisa_Click(object sender, EventArgs e)
    {
        saveDetails();
        Response.Redirect("hcm_Immigration_Task.aspx?Id=" + HiddenFieldQryId.Value + "&Ins=Ins&x=" + HiddenFieldRoundNo.Value);
    }

    public void saveDetails()
    {
        clsEntityImmigrationTasks objEntityImgrtnTasks = new clsEntityImmigrationTasks();
        clsBusinessImmigrationTasks objBusinessImgrtnTasks = new clsBusinessImmigrationTasks();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        objEntityImgrtnTasks.ImgrtnId = Convert.ToInt32(HiddenFieldImmgrtnId.Value);
        objEntityImgrtnTasks.ImgrtnDetailId = Convert.ToInt32(HiddenFieldImmgrtnDtlId.Value);

        objEntityImgrtnTasks.RoundStatusId = Convert.ToInt32(HiddenFieldDDlStsId.Value);

        if (txtVisaExptdDate.Text != "")
        {
            objEntityImgrtnTasks.CloseDate = objCommon.textToDateTime(txtVisaExptdDate.Text);
        }
        else
        {
            objEntityImgrtnTasks.CloseDate = objCommon.textToDateTime(HiddenFieldTrgtDate.Value);

        }
        if (txtScdldDate.Text != "")
        {
            objEntityImgrtnTasks.ScheduleDate = objCommon.textToDateTime(txtScdldDate.Text);
        }
        objEntityImgrtnTasks.CandId = Convert.ToInt32(HiddenFieldCandId.Value);
        objEntityImgrtnTasks.ImgrtnRndId = Convert.ToInt32(HiddenFieldRoundId.Value);
        if (FileUploadWrk.HasFile)
        {
            // GET FILE EXTENSION

            string strFileExt;
            strFileExt = FileUploadWrk.FileName.Substring(FileUploadWrk.FileName.LastIndexOf('.') + 1).ToLower();
            string strFileName = FileUploadWrk.FileName;
            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.IMMIGRATION);
            string strImageName = "WorkExp_" + intImageSection.ToString() + "_" + strFileName + "." + strFileExt;
            objEntityImgrtnTasks.Fname = strImageName;
            objEntityImgrtnTasks.ActFname = strFileName;

        }
        objEntityImgrtnTasks.UsrDate = System.DateTime.Now;
        objEntityImgrtnTasks.UserId = Convert.ToInt32(HiddenFieldLogUserId.Value);
        objBusinessImgrtnTasks.addRoundDtls(objEntityImgrtnTasks);
        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.IMMIGRATION);
        if (FileUploadWrk.HasFile)
        {
            FileUploadWrk.SaveAs(Server.MapPath(strImagePath) + objEntityImgrtnTasks.Fname);
        }
       
        
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        saveDetails();
        clsEntityImmigrationTasks objEntityImgrtnTasks = new clsEntityImmigrationTasks();
        clsBusinessImmigrationTasks objBusinessImgrtnTasks = new clsBusinessImmigrationTasks();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        objEntityImgrtnTasks.ImgrtnId = Convert.ToInt32(HiddenFieldImmgrtnId.Value);
        objEntityImgrtnTasks.ImgrtnDetailId = Convert.ToInt32(HiddenFieldImmgrtnDtlId.Value);
        objEntityImgrtnTasks.RoundStatusId = Convert.ToInt32(HiddenFieldDDlStsId.Value);

        objEntityImgrtnTasks.ImgrtnRndId = Convert.ToInt32(HiddenFieldRoundId.Value);
        objEntityImgrtnTasks.CandId = Convert.ToInt32(HiddenFieldCandId.Value);
        objEntityImgrtnTasks.UsrDate = System.DateTime.Now;
        objEntityImgrtnTasks.UserId = Convert.ToInt32(HiddenFieldLogUserId.Value);
        string radioCheck = "";
        if (radioAttend.Checked)
        {
            radioCheck = "Finish";
        }

        else
        {
            radioCheck = "Ins";
        }

        if (txtReshdlDate.Text != "")
        {
            objEntityImgrtnTasks.ScheduleDate = objCommon.textToDateTime(txtReshdlDate.Text);
            objBusinessImgrtnTasks.finisRound(objEntityImgrtnTasks);
            Response.Redirect("hcm_Immigration_Task.aspx?Id=" + HiddenFieldQryId.Value + "&Ins=Resdl&x=" + HiddenFieldRoundNo.Value);
        }
        else
        {
            DataTable dt = objBusinessImgrtnTasks.CheckRoundFinisdClsd(objEntityImgrtnTasks);
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("hcm_Immigration_Task.aspx?Id=" + HiddenFieldQryId.Value + "&Ins=Dup&x=");
            }
            else
            {
            objBusinessImgrtnTasks.finisRound(objEntityImgrtnTasks);
            Response.Redirect("hcm_Immigration_Task.aspx?Id=" + HiddenFieldQryId.Value + "&Ins=" + radioCheck + "&x=" + HiddenFieldRoundNo.Value);
            }
        }

        
       
    }
    [WebMethod]
    public static string CloseRound(int OnbrdId, int CandId, int UserId, int ImgrtnId, int ImgrtnDtlId, int StsId)
    {
        clsEntityImmigrationTasks objEntityImgrtnTasks = new clsEntityImmigrationTasks();
        clsBusinessImmigrationTasks objBusinessImgrtnTasks = new clsBusinessImmigrationTasks();
        string ret = "true";
        objEntityImgrtnTasks.ImgrtnId = ImgrtnId;
        objEntityImgrtnTasks.ImgrtnDetailId = ImgrtnDtlId;
        objEntityImgrtnTasks.RoundStatusId = StsId;

        objEntityImgrtnTasks.ImgrtnRndId = OnbrdId;
        objEntityImgrtnTasks.CandId = CandId;
        objEntityImgrtnTasks.UsrDate = System.DateTime.Now;
        objEntityImgrtnTasks.UserId = UserId;

        DataTable dt = objBusinessImgrtnTasks.CheckRoundFinisdClsd(objEntityImgrtnTasks);
        if (dt.Rows.Count > 0)
        {
            ret = "false";
        }
        else
        {
            objBusinessImgrtnTasks.CloseRound(objEntityImgrtnTasks);
        }

        return ret;
       
    }
    [WebMethod]
    public static void finisRound(int OnbrdId, int CandId, int UserId, string ReshdlDate)
    {
        clsEntityImmigrationTasks objEntityImgrtnTasks = new clsEntityImmigrationTasks();
        clsBusinessImmigrationTasks objBusinessImgrtnTasks = new clsBusinessImmigrationTasks();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityImgrtnTasks.ImgrtnRndId = OnbrdId;
        objEntityImgrtnTasks.CandId = CandId;
        objEntityImgrtnTasks.UsrDate = System.DateTime.Now;
        objEntityImgrtnTasks.UserId = UserId;
        if (ReshdlDate != "")
        {
            objEntityImgrtnTasks.ScheduleDate = objCommon.textToDateTime(ReshdlDate);
        }
        objBusinessImgrtnTasks.finisRound(objEntityImgrtnTasks);

    }
    public class RoundDtl
    {
        public int ImmgrtnId = 0;
        public int ImmgrtnDtlId = 0;
        public int RoundId = 0;
        public string TrgtDate = "";
        public int StsId = 0;
        public string ShdlDate = "";
        public string ExpTrgDate = "";
        public string Fname = "";
        public string ActFname = "";
        public string strImg = "";
        public int FinishSts = 0;
        public int CloseSts = 0;
        public string strDDLsts = "";
        public int CompleteStsId = 0;
        public int StsActiveStatus = 0;
        public string strStsName = "";
        public string ImageLoad(string Fname, string ActFname)
        {
            //for displaying photo
            string strImage = "";
            if (Fname != "")
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.IMMIGRATION) + Fname;
                strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofyEdu\" >Click to View Image Uploaded</a>";
                strImage += " <div class=\"lightbox-target\" id=\"goofyEdu\">";
                strImage += " <img src=\"" + strImagePath + "\"/>";
                strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                strImage += "</div>";

            }
            return strImage;
        }
    }

    [WebMethod]
    public static RoundDtl ReadRoundDtlsByCandId(int CandId, string RndName)
    {
        RoundDtl objRound = new RoundDtl();

       clsEntityImmigrationTasks objEntityImgrtnTasks = new clsEntityImmigrationTasks();
       clsBusinessImmigrationTasks objBusinessImgrtnTasks = new clsBusinessImmigrationTasks();
       objEntityImgrtnTasks.CandId = CandId;
       objEntityImgrtnTasks.RoundName = RndName;
       DataTable dt = objBusinessImgrtnTasks.ReadEmpRoundDtlsID(objEntityImgrtnTasks);

       if (dt.Rows.Count > 0)
       {
           objRound.ImmgrtnId = Convert.ToInt32(dt.Rows[0]["IMGRTN_ID"].ToString());
           objRound.ImmgrtnDtlId = Convert.ToInt32(dt.Rows[0]["IMGTNDTL_ID"].ToString());
           objRound.RoundId = Convert.ToInt32(dt.Rows[0]["IMGRTNRND_ID"].ToString());
           objRound.ExpTrgDate = dt.Rows[0]["TARGET DATE"].ToString();
           objRound.StsId = Convert.ToInt32(dt.Rows[0]["IMGRTNRNDDTL_ID"].ToString());
           objRound.ShdlDate = dt.Rows[0]["SCHDL DATE"].ToString();
           objRound.FinishSts = Convert.ToInt32(dt.Rows[0]["IMGTNDTL_FNSH_STS"].ToString());
           objRound.CloseSts = Convert.ToInt32(dt.Rows[0]["IMGTNDTL_CLOSE_STS"].ToString());
           objRound.Fname = dt.Rows[0]["IMGTNDTL_FILENAME"].ToString();
           objRound.ActFname = dt.Rows[0]["IMGTNDTL_FLNM_ACT"].ToString();
           objRound.strImg = objRound.ImageLoad(objRound.Fname, objRound.ActFname);
           //IMGRTNRNDDTL_STATUS IMGRTNRNDDTL_NAME
           objRound.StsActiveStatus = Convert.ToInt32(dt.Rows[0]["IMGRTNRNDDTL_STATUS"].ToString());
           objRound.strStsName = dt.Rows[0]["IMGRTNRNDDTL_NAME"].ToString();
       }
      
       return objRound;
    }


    [WebMethod]
    public static string DDLbind(string tableName, string RndId)
    {


        clsEntityImmigrationTasks objEntityImgrtnTasks = new clsEntityImmigrationTasks();
        clsBusinessImmigrationTasks objBusinessImgrtnTasks = new clsBusinessImmigrationTasks();
        objEntityImgrtnTasks.ImgrtnRndId = Convert.ToInt32(RndId);
        DataTable dtVehicles = objBusinessImgrtnTasks.ReadStatusDdl(objEntityImgrtnTasks);

        dtVehicles.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtVehicles.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }
}