using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Collections;
using BL_Compzit;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Data;


public partial class HCM_HCM_Master_hcm_Immigration_hcm_Immigration_Rounds_hcm_Immigration_Round : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txtImmigratnRnd.Focus();

            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();


            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Immigration_Round);
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
                }


                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnSave.Visible = true;
                    btnSaveClose.Visible = true;
                }
                else
                {
                    btnSave.Visible = false;
                    btnSaveClose.Visible = false;
                }

                if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        btnUpdate.Visible = true;
                    }
                    else
                    {
                        btnUpdate.Visible = false;
                    }

                    btnUpdateClose.Visible = true;
                }
                else
                {
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                }



                //Creating objects for business layer

                clsEntityImmigratnRound objEntityImgratnRnd = new clsEntityImmigratnRound();
                clsBusinessImmigratnRound objBusinessImgratnRnd = new clsBusinessImmigratnRound();

                int intCorpId = 0;

                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityImgratnRnd.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                    hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();

                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

                int intOrgId = 0;

                if (Session["ORGID"] != null)
                {
                    objEntityImgratnRnd.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

                    intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                    hiddenOrganisationId.Value = Session["ORGID"].ToString();
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

                //when editing 
                if (Request.QueryString["Id"] != null)
                {
                    btnClear.Visible = false;
                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    hiddenImmigratnId.Value = strId;
                    int intRndId = Convert.ToInt32(strId);
                    EditView(intRndId, 1);//Edit
                    lblEntry.Text = "Edit Immigration Round";

                }

                //when  viewing on cancel status checked
                else if (Request.QueryString["ViewId"] != null)
                {
                    btnClear.Visible = false;
                    string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);
                    int intRndId = Convert.ToInt32(strId);
                    EditView(intRndId, 2);//View

                    lblEntry.Text = "View Immigration Round";
                }
                
                //when inserting
                else
                {
                    lblEntry.Text = "Add Immigration Round";
                    hiddenImmigratnId.Value = "0";
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                }

                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    if (strInsUpd == "Save")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
                    }
                    else if (strInsUpd == "Upd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                    }
                }

            }

        }

    }



    public class clsDTLData
    {
        public string DTLID { get; set; }
        public string DTLNAME { get; set; }
        public string DTLSTATUS { get; set; }
        public string DTLCMPLT { get; set; }
        public string EVTACTION { get; set; }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            Button clickedButton = sender as Button;

            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            clsEntityImmigratnRound objEntityImgratnRnd = new clsEntityImmigratnRound();
            clsBusinessImmigratnRound objBusinessImgratnRnd = new clsBusinessImmigratnRound();

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityImgratnRnd.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else 
            {
                Response.Redirect("~/Default.aspx");
            }


            if (Session["ORGID"] != null)
            {
                objEntityImgratnRnd.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else 
            {
                Response.Redirect("~/Default.aspx");
            }


            int intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else 
            {
                Response.Redirect("~/Default.aspx");
            }

            //Next Id Method
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.IMMIGRATION_ROUND);

            objEntityCommon.CorporateID = objEntityImgratnRnd.CorpId;
            objEntityCommon.Organisation_Id = objEntityImgratnRnd.OrgId;

            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            objEntityImgratnRnd.ImgratnRound_Id = Convert.ToInt32(strNextId);


            objEntityImgratnRnd.ImgratnRound_Name = txtImmigratnRnd.Text;

            if (cbxCnclStatus.Checked == true)
            {
                objEntityImgratnRnd.ImgratnRound_Status = 1;
            }
            else
            {
                objEntityImgratnRnd.ImgratnRound_Status = 0;
            }

            

            objEntityImgratnRnd.UserId = intUserId;
            objEntityImgratnRnd.Date = System.DateTime.Now;

            List<clsEntityImmigratnRoundDetails> objEntityImgratnDtlList = new List<clsEntityImmigratnRoundDetails>();

            string jsonData = HiddenField1.Value;

            //contains string local storage add values frm client side

            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");

            List<clsDTLData> objDTLDataList = new List<clsDTLData>();

            objDTLDataList = JsonConvert.DeserializeObject<List<clsDTLData>>(i);
            //deserializing json data

            foreach (clsDTLData objclsDTLData in objDTLDataList)
            {
                clsEntityImmigratnRoundDetails objImgRndDtls = new clsEntityImmigratnRoundDetails();

                objImgRndDtls.ImgratnRoundDtl_Name = objclsDTLData.DTLNAME;
                objImgRndDtls.ImgratnRoundDtl_Status = Convert.ToInt32(objclsDTLData.DTLSTATUS);
                objImgRndDtls.ImgratnRoundDtl_Cmplt = Convert.ToInt32(objclsDTLData.DTLCMPLT);
                objEntityImgratnDtlList.Add(objImgRndDtls);
            }

            

            objBusinessImgratnRnd.InsertImmigratnRound(objEntityImgratnRnd, objEntityImgratnDtlList);


            if (clickedButton.ID == "btnSave")
            {
                Response.Redirect("hcm_Immigration_Round.aspx?InsUpd=Save");
            }
            else if (clickedButton.ID == "btnSaveClose")
            {
                Response.Redirect("hcm_Immigration_Rounds_List.aspx?InsUpd=Save");
            }


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ErrMsg", "ErrMsg();", true);
        }

    }


    [WebMethod]
    public static string CheckDupImgRndName(string strImgrtnRndId, string strImgrtnRndName, string strOrgId, string strCorpId)
    {
        //Check duplicatn
        string strResult = "0";
        clsEntityImmigratnRound objEntityImgratnRnd = new clsEntityImmigratnRound();
        clsBusinessImmigratnRound objBusinessImgratnRnd = new clsBusinessImmigratnRound();
        objEntityImgratnRnd.ImgratnRound_Id = Convert.ToInt32(strImgrtnRndId);
        objEntityImgratnRnd.ImgratnRound_Name = strImgrtnRndName;
        objEntityImgratnRnd.OrgId = Convert.ToInt32(strOrgId);
        objEntityImgratnRnd.CorpId = Convert.ToInt32(strCorpId);
        strResult = objBusinessImgratnRnd.CheckDupImgratnRnd(objEntityImgratnRnd);
        return strResult;

    }



    private void EditView(int intId, int intEditOrView)
    {
        //intEditOrView if 1-Edit,2-View

        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityImmigratnRound objEntityImgratnRnd = new clsEntityImmigratnRound();
        clsBusinessImmigratnRound objBusinessImgratnRnd = new clsBusinessImmigratnRound();

        objEntityImgratnRnd.ImgratnRound_Id = intId;

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImgratnRnd.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }


        if (Session["ORGID"] != null)
        {
            objEntityImgratnRnd.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }


        DataTable dtImgratnRndByID = new DataTable();
        dtImgratnRndByID = objBusinessImgratnRnd.ReadImgratnRndByID(objEntityImgratnRnd);

        if (dtImgratnRndByID.Rows.Count > 0)
        {

            txtImmigratnRnd.Text = dtImgratnRndByID.Rows[0]["IMGRTNRND_NAME"].ToString();

            if (dtImgratnRndByID.Rows[0]["STATUS"].ToString() == "1")
            {
                cbxCnclStatus.Checked = true;
            }
            else
            {
                cbxCnclStatus.Checked = false;
            }

            DataTable dtRndDtl = new DataTable();
            dtRndDtl.Columns.Add("ImgratnRndId", typeof(int));
            dtRndDtl.Columns.Add("ImgratnRndDtlId", typeof(int));
            dtRndDtl.Columns.Add("ImgratnRndDtlName", typeof(string));
            dtRndDtl.Columns.Add("ImgratnRndDtlStatus", typeof(int));
            dtRndDtl.Columns.Add("ImgratnRndDtlComplt", typeof(int));

            for (int intcnt = 0; intcnt < dtImgratnRndByID.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtRndDtl.NewRow();

                drDtl["ImgratnRndId"] = Convert.ToInt32(dtImgratnRndByID.Rows[intcnt]["IMGRTNRND_ID"].ToString());
                drDtl["ImgratnRndDtlId"] = Convert.ToInt32(dtImgratnRndByID.Rows[intcnt]["IMGRTNRNDDTL_ID"].ToString());
                drDtl["ImgratnRndDtlName"] = dtImgratnRndByID.Rows[intcnt]["IMGRTNRNDDTL_NAME"].ToString();
                drDtl["ImgratnRndDtlStatus"] = Convert.ToInt32(dtImgratnRndByID.Rows[intcnt]["IMGRTNRNDDTL_STATUS"].ToString());
                drDtl["ImgratnRndDtlComplt"] = Convert.ToInt32(dtImgratnRndByID.Rows[intcnt]["IMGRTNRNDDTL_CMPLT"].ToString());

                clsEntityImmigratnRoundDetails objImgRndDtls = new clsEntityImmigratnRoundDetails();
                objImgRndDtls.ImgratnRoundDtl_Id = Convert.ToInt32(dtImgratnRndByID.Rows[intcnt]["IMGRTNRNDDTL_ID"].ToString());

                DataTable dtDelChck = new DataTable();
                dtDelChck = objBusinessImgratnRnd.CheckDeleteImgrtnRndDtlId(objImgRndDtls);

                if (dtDelChck.Rows.Count > 0)
                {
                    for (int intt = 0; intt < dtDelChck.Rows.Count; intt++)
                    {
                        if (Convert.ToInt32(dtDelChck.Rows[intt]["IMGRTNRNDDTL_ID"].ToString()) == Convert.ToInt32(dtImgratnRndByID.Rows[intcnt]["IMGRTNRNDDTL_ID"].ToString()))
                        {
                            hiddenDel.Value = dtDelChck.Rows[intt]["IMGRTNRNDDTL_ID"].ToString();
                        }
                    }
                }

                dtRndDtl.Rows.Add(drDtl);

            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtRndDtl);



            //serializing the datatable to client side

            if (intEditOrView == 1)
            {
                btnSave.Visible = false;
                btnSaveClose.Visible = false;

                hiddenEdit.Value = strJson;
            }
            else if (intEditOrView == 2)
            {
                cbxCnclStatus.Enabled = false;
                btnSave.Visible = false;
                btnSaveClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;

                hiddenView.Value = strJson;
            }


        }


    }


    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        //serializing the datatable
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
        try
        {
            Button clickedButton = sender as Button;

            if (Request.QueryString["Id"] != null)
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();

                clsEntityImmigratnRound objEntityImgratnRnd = new clsEntityImmigratnRound();
                clsBusinessImmigratnRound objBusinessImgratnRnd = new clsBusinessImmigratnRound();

                int intUserId = 0;
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityImgratnRnd.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }


                if (Session["ORGID"] != null)
                {
                    objEntityImgratnRnd.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

                if (Session["USERID"] != null)
                {
                    intUserId = Convert.ToInt32(Session["USERID"]);
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

                objEntityImgratnRnd.ImgratnRound_Id = int.Parse(hiddenImmigratnId.Value);

                objEntityImgratnRnd.UserId = intUserId;
                objEntityImgratnRnd.Date = System.DateTime.Now;

                objEntityImgratnRnd.ImgratnRound_Name = txtImmigratnRnd.Text.Trim();

                if (cbxCnclStatus.Checked == true)
                {
                    objEntityImgratnRnd.ImgratnRound_Status = 1;
                }
                else
                {
                    objEntityImgratnRnd.ImgratnRound_Status = 0;
                }

                List<clsEntityImmigratnRoundDetails> objEntityImgratnRndDtlINSERTList = new List<clsEntityImmigratnRoundDetails>();
                List<clsEntityImmigratnRoundDetails> objEntityImgratnRndDtlUPDATEList = new List<clsEntityImmigratnRoundDetails>();
                List<clsEntityImmigratnRoundDetails> objEntityImgratnRndDtlDELETEList = new List<clsEntityImmigratnRoundDetails>();

                string jsonData = HiddenField1.Value;

                //contains string local storage edit values frm client side

                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");

                List<clsDTLData> objDTLDataList = new List<clsDTLData>();

                objDTLDataList = JsonConvert.DeserializeObject<List<clsDTLData>>(i);

                //deserializing json data


                foreach (clsDTLData objclsDTLData in objDTLDataList)
                {
                    if (objclsDTLData.EVTACTION == "INS")
                    {

                        clsEntityImmigratnRoundDetails objImgRndDtls = new clsEntityImmigratnRoundDetails();

                        objImgRndDtls.ImgratnRoundDtl_Id = Convert.ToInt32(objclsDTLData.DTLID);
                        if (hiddenDtlID.Value != "")
                        {
                            if (objImgRndDtls.ImgratnRoundDtl_Id == Convert.ToInt32(hiddenDtlID.Value))
                            {
                                objImgRndDtls.ImgratnRoundDtl_Cmplt = 1;
                            }
                            else
                            {
                                objImgRndDtls.ImgratnRoundDtl_Cmplt = 0;
                            }
                        }
                        else
                        {
                            objImgRndDtls.ImgratnRoundDtl_Cmplt = Convert.ToInt32(objclsDTLData.DTLCMPLT);
                        }

                        objImgRndDtls.ImgratnRoundDtl_Name = objclsDTLData.DTLNAME;
                        objImgRndDtls.ImgratnRoundDtl_Status = Convert.ToInt32(objclsDTLData.DTLSTATUS);
                        objEntityImgratnRndDtlINSERTList.Add(objImgRndDtls);
                    }

                    if (objclsDTLData.EVTACTION == "UPD")
                    {
                        clsEntityImmigratnRoundDetails objImgRndDtls = new clsEntityImmigratnRoundDetails();

                        objImgRndDtls.ImgratnRoundDtl_Id = Convert.ToInt32(objclsDTLData.DTLID);
                        if (hiddenDtlID.Value != "")
                        {
                            if (objImgRndDtls.ImgratnRoundDtl_Id == Convert.ToInt32(hiddenDtlID.Value))
                            {
                                objImgRndDtls.ImgratnRoundDtl_Cmplt = 1;
                            }
                            else
                            {
                                objImgRndDtls.ImgratnRoundDtl_Cmplt = 0;
                            }
                        }
                        else
                        {
                              objImgRndDtls.ImgratnRoundDtl_Cmplt = 0;
                        }
                        
                        objImgRndDtls.ImgratnRoundDtl_Name = objclsDTLData.DTLNAME;
                        objImgRndDtls.ImgratnRoundDtl_Status = Convert.ToInt32(objclsDTLData.DTLSTATUS);
                        

                        objEntityImgratnRndDtlUPDATEList.Add(objImgRndDtls);

                    }
                }


                string strCanclDtlId = "";
                string[] strarrCancldtlIds = strCanclDtlId.Split(',');
                if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
                {
                    strCanclDtlId = hiddenCanclDtlId.Value;
                    strarrCancldtlIds = strCanclDtlId.Split(',');

                }
                //Cancel the rows that have been cancelled when editing in Detail table
                foreach (string strDtlId in strarrCancldtlIds)
                {
                    if (strDtlId != "" && strDtlId != null)
                    {
                        int intDtlId = Convert.ToInt32(strDtlId);
                        clsEntityImmigratnRoundDetails objImgRndDtls = new clsEntityImmigratnRoundDetails();

                        objImgRndDtls.ImgratnRoundDtl_Id = Convert.ToInt32(strDtlId);

                        DataTable dtDelChck = new DataTable();
                        dtDelChck = objBusinessImgratnRnd.CheckDeleteImgrtnRndDtlId(objImgRndDtls);

                        if (dtDelChck.Rows.Count > 0)
                        {
                            hiddenDel.Value = strDtlId;
                        }
                        else
                        {
                            objEntityImgratnRndDtlDELETEList.Add(objImgRndDtls);
                        }
                    }
                }

                objBusinessImgratnRnd.UpdateImmigratnRnd(objEntityImgratnRnd, objEntityImgratnRndDtlINSERTList, objEntityImgratnRndDtlUPDATEList, objEntityImgratnRndDtlDELETEList);


            }
            if (clickedButton.ID == "btnUpdate")
            {
                Response.Redirect("hcm_Immigration_Round.aspx?InsUpd=Upd");
            }
            else if (clickedButton.ID == "btnUpdateClose")
            {
                Response.Redirect("hcm_Immigration_Rounds_List.aspx?InsUpd=Upd");
            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "ErrorMsg();", true);
        }


    }








}