using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using ServiceInsurance;
using System.Web.Services;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
public partial class WMS_Wms_Master_gen_Insurance_Provider_gen_Insurance_Provider_List : System.Web.UI.Page
{
    //enumeration for previous and next button
    private enum Button_type
    {
        Previous = 1,
        Next = 2
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        txtCancelReason.Attributes.Add("onkeypress", "return isTag(event)");
        if (!IsPostBack)
        {
            ddlProviderType.Focus();
            InsuraceTypeLoad();

            int intUserId = 0, intUsrRolMstrId,intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0,intEnableRecall=0;
           
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
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
                intEnableRecall = 1;
                hiddenRoleRecall.Value = "1";
            }
            else
            {
                intEnableRecall = 0;
                hiddenRoleRecall.Value = "0";
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Insurance_Provider);
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
                        HiddenFieldUpdRole.Value = intEnableModify.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldCnclRole.Value = intEnableCancel.ToString();
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
                    myBtn.Visible = true;

                }
                else
                {

                    myBtn.Visible = false;

                }

               

                //Creating objects for business layer
                
                clsBusinessLayerInsuranceProvider objBusinessLayerInsurance = new clsBusinessLayerInsuranceProvider();
                clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();
                int intCorpId = 0, intOrgId=0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityInsurance.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityInsurance.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                    intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

              
                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
                    DataTable dtCorpDetail = new DataTable();
                    dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        HiddenFieldCancelReasMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                                             
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
                        else if (strInsUpd == "ReclDup")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                        }
                        else if (strInsUpd == "Err")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ErrorCancelation", "ErrorCancelation();", true);
                        }
                        else if (strInsUpd == "StsCh")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessSts", "SuccessSts();", true);
                        }
                        else if (strInsUpd == "AlCncl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyCncl", "AlreadyCncl();", true);
                        }
                        else if (strInsUpd == "AlRecl")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyRecl", "AlreadyRecl();", true);
                        }
                        
                    }
            }
        }

    }



    //It build the Html table by using the datatable provided
    public static string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        string strHtml = "";
             
        int intReCallForTAble = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            if (intCnclUsrId != 0)
            {
                intReCallForTAble = 1;
            }
        }


        if (dt.Rows.Count > 0)
        {
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
             string strId = dt.Rows[intRowBodyCount][3].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][3].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";

             strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount][0].ToString() + "</td>";
            strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount][1].ToString() + "</td>";
            if (dt.Rows[intRowBodyCount][2].ToString() == "ACTIVE")
                strHtml += "<td class=\"td1\"><button class=\"btn tab_but1 butn1\" onclick=\"return ChangeStatus('" + Id + "','1','" + intCnclUsrId + "');\">Active</button></td>";
            else
                strHtml += "<td class=\"td1\"><button class=\"btn tab_but1 butn6\" onclick=\"return ChangeStatus('" + Id + "','0','" + intCnclUsrId + "');\">Inactive</button></td>";
            strHtml += "<td>";
            strHtml += " <div>";
          

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                if (intCnclUsrId == 0)
                {
                    strHtml += " <button class=\"btn act_btn bn1 bt_e\"  title=\"Edit\" onclick='return getdetails(\"gen_Insurance_Provider.aspx?Id=" + Id + "\");' >" +
                             "<i class=\"fa fa-edit\"></i>" + "</button>";
                }

                else
                {
                    strHtml += " <button  class=\"btn act_btn bn4 bt_v\" title=\"View\" onclick='return getdetails(\"gen_Insurance_Provider.aspx?ViewId=" + Id + "\");' >" +
                       "<i class=\"fa fa-list-alt\"></i>" + "</button>";                 
                }
            }
            if (intReCallForTAble == 0)
            {
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (intCnclUsrId == 0)
                    {
                        if (intCancTransaction == 0)
                        {

                            strHtml += "<button class=\"btn act_btn bn3\" onclick=\"return OpenCancelView('" + Id + "');\" title=\"Cancel\" >";
                                strHtml += " <i class=\"fa fa-trash\"></i>";
                                strHtml += "</button>";

                        }
                        else
                        {

                            strHtml += "<a class=\"btn act_btn bn3\" disabled=\"\" onclick='return CancelNotPossible();' title=\"Cancel\">";
                                strHtml += " <i class=\"fa fa-trash\"></i>";
                                strHtml += "</a>";

                        }



                    }
                }
            }
            if (intReCallForTAble == 1)
            {
                if (intEnableRecall == 1)
                {
                    if (intCnclUsrId == 0)
                    {
                       
                    }
                    else
                    {

                        strHtml += " <button class=\"btn act_btn bn2 bt_v\" title=\"Recall\" onclick=\"return ReCallAlert('" + Id + "');\" >" +
                            "<i class=\"fa fa-repeat\"></i>" + "</button>";

                    }
                }
            }
              strHtml += " </div>";
            strHtml += "</td>";
            strHtml += "</tr>";
        }
        }
        else
        {
            strHtml += "<td class=\"tr_c\" colspan=\"4\">No data available in table</td>";
        }
        return strHtml;
    }
   
    public void InsuraceTypeLoad()
    {
        Service_InsuranceProvider objServiceInsurance = new Service_InsuranceProvider();

        string jsonValue = objServiceInsurance.ReadInsuranceType();
        DataTable dtInsuranceType = (DataTable)JsonConvert.DeserializeObject(jsonValue, (typeof(DataTable)));


        if (dtInsuranceType.Rows.Count > 0)
        {
            ddlProviderType.DataSource = dtInsuranceType;
            ddlProviderType.DataTextField = "INSURTYP_NAME";
            ddlProviderType.DataValueField = "INSURTYP_ID";
            ddlProviderType.DataBind();
            ddlProviderType.Items.Insert(0, "--SELECT--");
        }

    }

    [WebMethod]
    public static string ReOpenConfByID(string orgID, string corptID, string userID, string MasterDbId, string Mode, string reasonmust, string cnclRsn)
    {
        string sts = "";
        try
        {
            string strRandomMixedId = MasterDbId;
            string id = strRandomMixedId;
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayerInsuranceProvider objBusinessLayerInsurance = new clsBusinessLayerInsuranceProvider();
            clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();
            objEntityInsurance.Organisation_id = Convert.ToInt32(orgID);
            objEntityInsurance.Corporate_id = Convert.ToInt32(corptID);
            objEntityInsurance.InsuranceId = Convert.ToInt32(strId);
            objEntityInsurance.User_Id = Convert.ToInt32(userID);
            objEntityInsurance.Date = System.DateTime.Now;
            if (Mode == "0")
            {
                if (reasonmust == "1")
                {
                    objEntityInsurance.CancelReason = cnclRsn;
                }
                else
                {
                    objEntityInsurance.CancelReason = objCommon.CancelReason();
                }
                Service_InsuranceProvider objServiceInsurance = new Service_InsuranceProvider();



                string JsonInsuranceDetails = objServiceInsurance.ReadInsuranceDetailById(Convert.ToInt32(strId));
                DataTable dtInsuranceDetails = (DataTable)JsonConvert.DeserializeObject(JsonInsuranceDetails, (typeof(DataTable)));
                if (dtInsuranceDetails.Rows.Count > 0)
                {
                    if (dtInsuranceDetails.Rows[0]["INSURPRVDR_CNCL_USR_ID"].ToString() == "" || dtInsuranceDetails.Rows[0]["INSURPRVDR_CNCL_USR_ID"].ToString() == null)
                    {
                        objServiceInsurance.CancelInsuranceProvider(objEntityInsurance.InsuranceId, objEntityInsurance.User_Id, objEntityInsurance.CancelReason);
                        sts = "Cncl";
                    }
                    else
                    {
                        sts = "AlCncl";
                    }
                }
            }
            else
            {
                Service_InsuranceProvider objServiceInsurance = new Service_InsuranceProvider();
                string JsonInsuranceDetails = objServiceInsurance.ReadInsuranceDetailById(Convert.ToInt32(strId));
                DataTable dtInsuranceDetails = (DataTable)JsonConvert.DeserializeObject(JsonInsuranceDetails, (typeof(DataTable)));
                string strInsuranceProviderName = "", strCnclId = "";
                
                if (dtInsuranceDetails.Rows.Count > 0)
                {
                    strInsuranceProviderName = dtInsuranceDetails.Rows[0]["INSURPRVDR_NAME"].ToString();
                    strCnclId = dtInsuranceDetails.Rows[0]["INSURPRVDR_CNCL_USR_ID"].ToString();
                }
                //Checking is there table have any name like this
                string strNameCount = objServiceInsurance.CheckInsuranceProviderName(objEntityInsurance.InsuranceId, strInsuranceProviderName, objEntityInsurance.Corporate_id, objEntityInsurance.Organisation_id);
                if (strNameCount == "0" && strCnclId != "" && strCnclId != null)
                {
                    objServiceInsurance.RecallInsuranceProvider(objEntityInsurance.InsuranceId, objEntityInsurance.User_Id);
                    sts = "Recl";
                }
                else if (strNameCount != "0")
                {
                    sts = "ReclDup";
                }
                else 
                {
                    sts = "AlRecl";
                }
            }
        }
        catch (Exception ex)
        {
            sts = "Err";
        }
        return sts;
    }
    [WebMethod]
    public static string ChangeStatus(string strmemotId, string strStatus, string UsrId)
    {
        string strRet = "success";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        clsBusinessLayerInsuranceProvider objBusinessLayerInsurance = new clsBusinessLayerInsuranceProvider();
        clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();
        objEntityInsurance.InsuranceId = Convert.ToInt32(strId);
        objEntityInsurance.User_Id = Convert.ToInt32(UsrId);
        objEntityInsurance.Date = System.DateTime.Now;
        if (strStatus == "1")
        {
            strStatus = "0";
        }
        else
        {
            strStatus = "1";
        }
        objEntityInsurance.Status_id = Convert.ToInt32(strStatus);
        objBusinessLayerInsurance.Update_Provider_Status(objEntityInsurance);
        return strRet;
    }
    [WebMethod]
    public static string PrintList(string orgID, string corptID, string Status, string CnclSts, string Type,string TypeText)
    {
        string strReturn = "";
        //end
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsBusinessLayerInsuranceProvider objBusinessLayerInsurance = new clsBusinessLayerInsuranceProvider();
        clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();
        objEntityInsurance.Status_id = Convert.ToInt32(Status);
        objEntityInsurance.CancelStatus = Convert.ToInt32(CnclSts);
        objEntityInsurance.Organisation_id = Convert.ToInt32(orgID);
        objEntityInsurance.Corporate_id = Convert.ToInt32(corptID);
        if (Type != "--SELECT--")
        {
            objEntityInsurance.InsuranceType = Convert.ToInt32(Type);
        }
        //for webservice calling
        int intOrg = 0, intCorp = 0, intStatus = 0, intCancelStatus = 0, intInsType = 0; ;
        intOrg = objEntityInsurance.Organisation_id;
        intCorp = objEntityInsurance.Corporate_id;
        intStatus = objEntityInsurance.Status_id;
        intCancelStatus = objEntityInsurance.CancelStatus;
        intInsType = objEntityInsurance.InsuranceType;

        Service_InsuranceProvider objServiceInsurance = new Service_InsuranceProvider();
        string jsonValue = objServiceInsurance.ReadInsuranceProviderListBySearch(intOrg, intCorp, intStatus, intCancelStatus, intInsType);      
        DataTable dtUser = new DataTable();
        dtUser = (DataTable)JsonConvert.DeserializeObject(jsonValue, (typeof(DataTable)));


        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_LIST_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_LIST_PDF);
        objEntityCommon.CorporateID = Convert.ToInt32(corptID);
        objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "InsuranceProviderList_" + corptID + "_" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 40f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        try
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();


                PdfPTable footrtable = new PdfPTable(3);
                float[] footrsBody1 = { 20, 5, 75 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;
                if (Type != "--SELECT--")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("INSURANCE TYPE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(TypeText, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });

                }

                footrtable.AddCell(new PdfPCell(new Phrase("STATUS  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (Status == "2")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Inactive", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                else if (Status == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Active", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("All", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                footrtable.AddCell(new PdfPCell(new Phrase("CANCELLED STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (CnclSts == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Not Cancelled", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Cancelled", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }

                document.Add(footrtable);


                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(3);
                float[] footrsBody = { 35, 50, 15 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("PROVIDER NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("INSURANCE TYPE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                string strRandom = objCommon.Random_Number();


                if (dtUser.Rows.Count > 0)
                {
                    for (int intRowBodyCount = 0; intRowBodyCount < dtUser.Rows.Count; intRowBodyCount++)
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][0].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][1].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtUser.Rows[intRowBodyCount][2].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                }
                else
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase(" No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 3 });
                }
                document.Add(TBCustomer);
                document.Close();
                strRet = strImagePath + strImageName;
            }
        }
        catch (Exception)
        {
            document.Close();
            strRet = "";
        }
        return strRet;
    }
    public class PDFHeader : PdfPageEventHelper
    {
        PdfContentByte cb;
        PdfTemplate footerTemplate;
        BaseFont bf = null;
        DateTime PrintTime = DateTime.Now;
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                footerTemplate = cb.CreateTemplate(200, 200);
            }
            catch (DocumentException de)
            {
                //handle exception here
            }
            catch (System.IO.IOException ioe)
            {
                //handle exception here
            }
        }
        public override void OnStartPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityCommon ObjEntityCommon = new clsEntityCommon();
            clsBusinessLayer objDataCommon = new clsBusinessLayer();
            ObjEntityCommon.CorporateID = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());
            ObjEntityCommon.Organisation_Id = Convert.ToInt32(HttpContext.Current.Session["ORGID"].ToString());
            DataTable dtCorp = objDataCommon.ReadCorpDetails(ObjEntityCommon);
            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "";
            string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
            if (dtCorp.Rows.Count > 0)
            {
                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
                {
                    string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                    string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
                    strImageLogo = imaeposition + icon;
                }
                strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
                strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
                strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
                strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            }
            string strAddress = "";
            strAddress = strCompanyAddr1;
            if (strCompanyAddr2 != "")
            {
                strAddress += ", " + strCompanyAddr2;
            }
            if (strCompanyAddr3 != "")
            {
                strAddress += ", " + strCompanyAddr3;
            }
            //Head Table
            PdfPTable headtable = new PdfPTable(2);
            headtable.AddCell(new PdfPCell(new Phrase("INSURANCE PROVIDER LIST ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            if (strImageLogo != "")
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                image.ScalePercent(PdfPCell.ALIGN_CENTER);
                image.ScaleToFit(60f, 40f);
                headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
            }
            else
            {
                headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            }
            headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            headtable.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
            headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
            float[] headersHeading = { 80, 20 };
            headtable.SetWidths(headersHeading);
            headtable.WidthPercentage = 100;
            document.Add(headtable);
            PdfPTable tableLine = new PdfPTable(1);
            float[] tableLineBody = { 100 };
            tableLine.SetWidths(tableLineBody);
            tableLine.WidthPercentage = 100;
            tableLine.TotalWidth = 650F;
            tableLine.AddCell(new PdfPCell(new Phrase("_____________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
            float pos9 = writer.GetVerticalPosition(false);
        }
        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            // base.OnEndPage(writer, document);
            string strUsername = HttpContext.Current.Session["USERFULLNAME"].ToString();
            PdfPTable table3 = new PdfPTable(1);
            float[] tableBody3 = { 100 };
            table3.SetWidths(tableBody3);
            table3.WidthPercentage = 100;
            table3.TotalWidth = 650F;
            table3.AddCell(new PdfPCell(new Phrase("_________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
            // document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
            PdfPTable headImg = new PdfPTable(3);
            string strImageLogo = "/Images/Design_Images/images/Compztlogo.png";
            //headImg.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });

            headImg.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3, PaddingTop = 5 });
            if (strImageLogo != "")
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                image.ScalePercent(PdfPCell.ALIGN_CENTER);
                image.ScaleToFit(60f, 40f);
                headImg.AddCell(new PdfPCell(image) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_TOP });
            }

            headImg.AddCell(new PdfPCell(new Paragraph("Report generated in Compzit by:" + strUsername + "\nReport generated on:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
            headImg.AddCell(new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });
            float[] headersHeading = { 20, 60, 20 };
            headImg.SetWidths(headersHeading);
            headImg.WidthPercentage = 100;
            headImg.TotalWidth = document.PageSize.Width - 80f;

            headImg.WriteSelectedRows(0, -1, 50, document.PageSize.GetBottom(50), writer.DirectContent);

            String text = "Page " + writer.PageNumber + " of ";
            //Add paging to footer
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetBottom(15));
                cb.ShowText(text);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 8);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetBottom(15));
            }
        }
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 8);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber).ToString());
            footerTemplate.EndText();
        }
    }
    [WebMethod]
    public static string[] GetData(string OrgId, string CorpId, string ddlStatus, string CancelStatus, string EnableModify, string EnableCancel, string PageNumber, string PageMaxSize, string strCommonSearchTerm, string OrderColumn, string OrderMethod, string strInputColumnSearch, string EnableRecall, string Type)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayerInsuranceProvider objBusinessLayerInsurance = new clsBusinessLayerInsuranceProvider();
        clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();
        objEntityInsurance.Status_id = Convert.ToInt32(ddlStatus);
        objEntityInsurance.CancelStatus = Convert.ToInt32(CancelStatus);
        objEntityInsurance.Organisation_id = Convert.ToInt32(OrgId);
        objEntityInsurance.Corporate_id = Convert.ToInt32(CorpId);
        if (Type != "--SELECT--")
        {
            objEntityInsurance.InsuranceType = Convert.ToInt32(Type);
        }
        //for webservice calling
        int intOrg = 0, intCorp = 0, intStatus = 0, intCancelStatus = 0, intInsType = 0; ;
        intOrg = objEntityInsurance.Organisation_id;
        intCorp = objEntityInsurance.Corporate_id;
        intStatus = objEntityInsurance.Status_id;
        intCancelStatus = objEntityInsurance.CancelStatus;
        intInsType = objEntityInsurance.InsuranceType;
        string[] strResults = new string[2];
        objEntityInsurance.PageNumber = Convert.ToInt32(PageNumber);
        objEntityInsurance.PageMaxSize = Convert.ToInt32(PageMaxSize);
        objEntityInsurance.OrderMethod = Convert.ToInt32(OrderMethod);
        objEntityInsurance.OrderColumn = Convert.ToInt32(OrderColumn);
        objEntityInsurance.CommonSearchTerm = strCommonSearchTerm;

        var values = Enum.GetValues(typeof(SearchInputColumns));
        int intSearchColumnCount = values.Length;

        string[] strSearchInputs = new string[intSearchColumnCount];
        //— ‡
        if (strInputColumnSearch != "")
        {
            string[] InputColumnSearchList = strInputColumnSearch.Split('—');
            foreach (var InputColumnSearch in InputColumnSearchList)
            {
                string[] strColumnSrch = InputColumnSearch.Split('‡');
                int intColumnNo = Convert.ToInt32(strColumnSrch[0]);
                string strSearchString = strColumnSrch[1];

                if (intColumnNo <= intSearchColumnCount)
                {
                    strSearchInputs[intColumnNo] = strSearchString;
                }
            }
        }
        objEntityInsurance.SearchName = strSearchInputs[Convert.ToInt32(SearchInputColumns.NAME)];
        objEntityInsurance.SearchType = strSearchInputs[Convert.ToInt32(SearchInputColumns.TYPE)];

        DataTable dt = new DataTable();
        dt = objBusinessLayerInsurance.ReadInsuranceProviderListBySearch(objEntityInsurance);

       
        int intEnableUpdate = Convert.ToInt32(EnableModify);
        int intEnableCancel = Convert.ToInt32(EnableCancel);
        strResults[0] = ConvertDataTableToHTML(dt, intEnableUpdate, intEnableCancel, Convert.ToInt32(EnableRecall));
        if (dt.Rows.Count > 0)
        {
            int intTotalItems = Convert.ToInt32(dt.Rows[0]["CNT"].ToString());
            int intCurrentRowCount = dt.Rows.Count;
            //Pagination
            strResults[1] = objBusinessLayer.GenereatePagination(intTotalItems, objEntityInsurance.PageNumber, objEntityInsurance.PageMaxSize, intCurrentRowCount);
        }

        return strResults;
    }
    [WebMethod]
    public static string[] LoadStaticDatafordt()//Filters
    {
        StringBuilder html = new StringBuilder();
        StringBuilder sbSearchInputColumns = new StringBuilder();

        string[] strResults = new string[3];
        html.Append("<div>");

        html.Append("<div class=\"col-md-2\" style=\"padding-left: 0px;\">");//length
        html.Append("<label><span>Show</span> <select onchange=\"getdata(1);\" id=\"ddl_page_size\" style=\"height: 24px;margin: 0px 2px;margin-right: 2px;\">");
        html.Append("<option value=\"10\">10</option><option value=\"25\">25</option><option value=\"50\">50</option><option value=\"100\">100</option></select> entries");
        html.Append("</label></div>");
        //page length ends
        //common filter
        html.Append("<div class=\"pull-right\" style=\"padding-right: 0px;\">");
        html.Append("<label>Search:");
        html.Append("<input  autocomplete=\"off\" onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"SettypingTimer(event);\" class=\"tbl_fil_s\" id=\"txtCommonSearch_dt\"  type=\"search\" aria-controls=\"example\">");
        html.Append("</label>");
        html.Append("</div>");
        //common filter ends
        html.Append("</div>");
        strResults[0] = html.ToString();

        //custom search fields
        var values = Enum.GetValues(typeof(SearchInputColumns));
        int intSearchColumnCount = values.Length;

        foreach (var item in values)
        {
            // use item number to customize names using if 
            if (Convert.ToInt32(item).ToString() == "0")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_1\" onclick=\"SetOrderByValue(1)\" class=\"sorting col-md-5 tr_l\" style=\"word-wrap:break-word;\">PROVIDER NAME<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"PROVIDER NAME\" placeholder=\"Provider Name\"></th>");
            }
            else if (Convert.ToInt32(item).ToString() == "1")
            {
                sbSearchInputColumns.Append("<th id=\"tdColumnHead_2\" onclick=\"SetOrderByValue(2)\" class=\"sorting col-md-4 tr_l\" style=\"word-wrap:break-word;\">INSURANCE TYPE<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input autocomplete=\"off\" id=\"txtSearchColumn_" + Convert.ToInt32(item) + "\"  onkeypress=\"return isTagEnter(event);\" onkeydown=\"return isTagEnter(event);\" onkeyup=\"return SettypingTimer(event);\" class=\"tb_inp_1 tb_in\" type=\"text\" title=\"INSURANCE TYPE\" placeholder=\"Insurance Type\"></th>");
            }
        }
        sbSearchInputColumns.Append("<th id=\"tdColumnHead_3\"  onclick=\"SetOrderByValue(3)\" class=\"sorting col-md-1 tr_c\" style=\"word-wrap:break-word;\">STATUS<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>");
        sbSearchInputColumns.Append("<th class=\"col-md-2\"  style=\"word-wrap:break-word;\">ACTIONS</th>");

        strResults[1] = sbSearchInputColumns.ToString();
        strResults[2] = intSearchColumnCount.ToString();
        return strResults;
    }

    public enum SearchInputColumns
    {
        //Must be sequential 
        NAME = 0,
        TYPE = 1,

    }

    }
