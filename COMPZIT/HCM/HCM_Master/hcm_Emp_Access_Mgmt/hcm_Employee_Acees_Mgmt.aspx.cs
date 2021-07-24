using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Data;
using BL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Text;
using CL_Compzit;
using System.IO;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

public partial class HCM_HCM_Master_hcm_Employee_Acees_Mgmt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnNextPage.Enabled = false;
            btnOverNext.Enabled = false;
            btnLateNext.Enabled = false;
            btnCorrectNext.Enabled = false;
            btnInCorrectNext.Enabled = false;
            if (Request.QueryString["InsUpd"] != null)
            {
                if (Request.QueryString["InsUpd"] == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AddSuccesMessage", "AddSuccesMessage();", true);
                }
            }
        }

    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityEmplyeeAccessMgmt objEntEmpAcesMgmt = new clsEntityEmplyeeAccessMgmt();
        clsBusinessEmpAcessMgmt objBusinessEmpAcessMgmt = new clsBusinessEmpAcessMgmt();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntEmpAcesMgmt.CorprtId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntEmpAcesMgmt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (Session["USERID"] != null)
        {
            objEntEmpAcesMgmt.UsrId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        string strFilePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMP_ACCESS_MGMT);
        if (fupImportCsv.HasFile)
        {
            fupImportCsv.SaveAs(Server.MapPath(strFilePath) + fupImportCsv.FileName);
            HiddenFile.Value = fupImportCsv.PostedFile.FileName;
        }

        string strData = Server.MapPath(strFilePath) + "/" + fupImportCsv.FileName;



        try
        {
          if (fupImportCsv.FileName != "")
          {
            var CorrectList = new List<string[]>();
            var IncorrectList = new List<string[]>();
            var DuplicateList = new List<string[]>();
            var EarlyGoingList = new List<string[]>();
            var LateComersList = new List<string[]>();
            var OverDutyList = new List<string[]>();
            var EmpIdWithMisngChkinChkout = new List<string[]>();
            bool blHeader = false;
            DateTime dt;
            using (CsvFileReader reader = new CsvFileReader(strData))
            {
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {
                    //check the uploaded file has headers
                    if (cbxImprtHasHeader.Checked == true)
                        if (blHeader == false)
                        {
                            blHeader = true;
                            goto rowOuter;
                        }
                    //string array for store the csv file row.
                    string[] Line = row.ToArray();

                    CorrectList.Add(Line);
                rowOuter: ;
                }

            }



            //var CorrectListCopy = new List<string[]>(CorrectList);
            //CorrectListCopy = CorrectList.ToList();
            DataTable dtChkinChkout = objBusinessEmpAcessMgmt.ReadChkinAndChkOut(objEntEmpAcesMgmt);
            for (int intRow = CorrectList.Count - 1; intRow >= 0; intRow--)
            {
                string strInHr = "";
                string strNewChkIn = "";
                DateTime dtChkInBus;
                string strOutHr = "";
                string strNewChkOt = "";
                string strcheckout = "";
                DateTime dtchkOutBus;
                Boolean empValid = true;


                int len = CorrectList[intRow].Length;
                if (len != 6)
                {
                    if (len == 5)
                    { //For removing <> 
                        string strItem = CorrectList[intRow][0].ToString().ToUpper();
                        strItem = strItem.Replace("<", string.Empty);
                        strItem = strItem.Replace(">", string.Empty);
                        CorrectList[intRow][0] = strItem;
                        //checking missing EmployeeId,date, checkin and checkout
                        if (CorrectList[intRow][0] == null || CorrectList[intRow][0] == "")
                        {
                            //evm-0023
                            IncorrectList.Add(CorrectList[intRow]);


                            if (CorrectList.Count >= intRow)
                            {
                                CorrectList.RemoveAt(intRow);
                                goto outerlabel;
                            }
                        }
                        else
                        { //Empcode is correct or not
                            string strEmpId = CorrectList[intRow][0].ToString().Replace("<", string.Empty);
                            objEntEmpAcesMgmt.EmpId = strEmpId;
                            DataTable dtEmp = objBusinessEmpAcessMgmt.checkEmpcode(objEntEmpAcesMgmt);
                            if (dtEmp.Rows.Count == 0)
                            {
                                empValid = false;
                            }
                            if (empValid == false)
                            {
                                IncorrectList.Add(CorrectList[intRow]);


                                CorrectList.RemoveAt(intRow);
                                goto outerlabel;

                            }
                            else
                            {
                                EmpIdWithMisngChkinChkout.Add(CorrectList[intRow]);
                                CorrectList.RemoveAt(intRow);
                                goto outerlabel;
                            }
                        }
                    }
                    else
                    {
                        CorrectList.RemoveAt(intRow);
                        goto outerlabel;
                    }


                }
                else
                {
                    //For removing <> 

                    for (int ColumnCount = 0; ColumnCount < 6; ColumnCount++)
                    {
                        string strItem = CorrectList[intRow][ColumnCount].ToString().ToUpper();
                        strItem = strItem.Replace("<", string.Empty);
                        strItem = strItem.Replace(">", string.Empty);
                        CorrectList[intRow][ColumnCount] = strItem;
                    }

                    //checking missing EmployeeId,date, checkin and checkout
                    if (CorrectList[intRow][0] == null || CorrectList[intRow][0] == "")
                    {
                        IncorrectList.Add(CorrectList[intRow]);

                        if (CorrectList.Count >= intRow)
                        {
                            CorrectList.RemoveAt(intRow);
                            goto outerlabel;
                        }
                    }
                    else
                    { //Empcode is correct or not
                        string strEmpId = CorrectList[intRow][0].ToString().Replace("<", string.Empty);
                        objEntEmpAcesMgmt.EmpId = strEmpId;
                        DataTable dtEmp = objBusinessEmpAcessMgmt.checkEmpcode(objEntEmpAcesMgmt);
                        if (dtEmp.Rows.Count == 0)
                        {
                            empValid = false;
                        }
                        if (empValid == false)
                        {
                            IncorrectList.Add(CorrectList[intRow]);

                            CorrectList.RemoveAt(intRow);
                            goto outerlabel;

                        }
                    }

                    //EmpId  with missing check-in and check-out time 
                    if (CorrectList[intRow][4] == null || CorrectList[intRow][4] == "" || CorrectList[intRow][5] == null || CorrectList[intRow][5] == "")
                    {
                        EmpIdWithMisngChkinChkout.Add(CorrectList[intRow]);
                        //CorrectList.RemoveAt(intRow);
                        // goto outerlabel;
                    }
                    // check the date format

                    if (CorrectList[intRow][3] == null || CorrectList[intRow][3] == "")
                    {
                        IncorrectList.Add(CorrectList[intRow]);


                        if (CorrectList.Count >= intRow)
                        {
                            CorrectList.RemoveAt(intRow);
                            goto outerlabel;
                        }
                    }
                    else
                    {
                          //bool boolAttenDate = DateTime.TryParse(CorrectList[intRow][3].ToString(), out dt);

                          //if (boolAttenDate == false)
                          //{
                          //    IncorrectList.Add(CorrectList[intRow]);

                          //    if (CorrectList.Count >= intRow)
                          //    {
                          //        CorrectList.RemoveAt(intRow);
                          //        goto outerlabel;
                          //    }
                          //}

                          string strdate = CorrectList[intRow][3].ToString();
                          Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$");
                          bool isValid = regex.IsMatch(strdate.Trim());
                          if (isValid == false)
                          {
                              IncorrectList.Add(CorrectList[intRow]);
                              if (CorrectList.Count >= intRow)
                              {
                                  CorrectList.RemoveAt(intRow);
                                  goto outerlabel;
                              }
                          }
                    }
                    decimal decValue;
                    bool isIndecimal = true;

                    if (CorrectList[intRow][4] == null || CorrectList[intRow][4] == "")
                    {
                        IncorrectList.Add(CorrectList[intRow]);


                        if (CorrectList.Count >= intRow)
                            CorrectList.RemoveAt(intRow);
                        goto outerlabel;
                    }
                    else
                    {
                        string[] strsplitspceIn = Convert.ToString(CorrectList[intRow][4]).Split(' ');
                        string[] strsplithrIn = strsplitspceIn[0].Split(':');
                        isIndecimal = decimal.TryParse(strsplithrIn[0].ToString(), out decValue);


                        bool ValidTym = false;
                        if (strsplitspceIn[0].Length == 5)
                        {
                            ValidTym = true;
                        }

                        if (ValidTym != false)
                        {
                            TimeSpan dummyOutput;
                            ValidTym = TimeSpan.TryParse(strsplitspceIn[0], out dummyOutput);
                        }
                        isIndecimal = ValidTym;


                        if (isIndecimal == false || strsplithrIn[0].ToString().Length > 8)
                        {
                            IncorrectList.Add(CorrectList[intRow]);


                            CorrectList.RemoveAt(intRow);
                            goto outerlabel;
                        }

                        if (strsplithrIn[0].Length < 2)
                        {
                            strInHr = "0" + strsplithrIn[0];
                            strNewChkIn = CorrectList[intRow][4].Replace(strsplithrIn[0], strInHr);

                        }
                        else
                        {
                            strNewChkIn = CorrectList[intRow][4].ToString();
                        }

                        if (strNewChkIn.Length == 5)
                        {
                            strNewChkIn = strNewChkIn + ":00";
                        }

                        string strcheckin = Convert.ToString("01-01-1000 " + strNewChkIn);

                        DateTime dtChkIn = objCommon.textWithTimeToDateTime(strcheckin);
                        // Checks Check-in time is greater than business unit's check-in time then add to latecomers list
                        if (dtChkinChkout.Rows[0]["CORPRT_CHECKIN"].ToString() != "")
                        {
                            dtChkInBus = Convert.ToDateTime(dtChkinChkout.Rows[0]["CORPRT_CHECKIN"].ToString());
                            string strBusChkIn = dtChkInBus.ToString("hh:mm:ss tt");
                            string strcheckinn = Convert.ToString("01-01-1000 " + strBusChkIn);
                            DateTime dtBusUnitChkIn = objCommon.textWithTimeToDateTime(strcheckinn);
                            if (dtChkIn > dtBusUnitChkIn)
                            {
                                LateComersList.Add(CorrectList[intRow]);
                            }
                        }
                    }
                    bool isOutdecimal = true;
                    if (CorrectList[intRow][5] == null || CorrectList[intRow][5] == "")
                    {
                        IncorrectList.Add(CorrectList[intRow]);


                        if (CorrectList.Count >= intRow)
                        {
                            CorrectList.RemoveAt(intRow);
                            goto outerlabel;
                        }
                    }
                    else
                    {
                        string[] strsplitspceOt = Convert.ToString(CorrectList[intRow][5]).Split(' ');
                        string[] strsplithr = strsplitspceOt[0].Split(':');

                        isOutdecimal = decimal.TryParse(strsplithr[0].ToString(), out decValue);

                        bool ValidTym = false;
                        if (strsplitspceOt[0].Length == 5)
                        {
                            ValidTym = true;
                        }

                        if (ValidTym != false)
                        {
                            TimeSpan dummyOutput;
                            ValidTym = TimeSpan.TryParse(strsplitspceOt[0], out dummyOutput);
                        }
                        isOutdecimal = ValidTym;


                        if (isOutdecimal == false || strsplithr[0].ToString().Length > 8)
                        {
                            IncorrectList.Add(CorrectList[intRow]);


                            CorrectList.RemoveAt(intRow);
                            goto outerlabel;
                        }

                        int intOtHr = strsplithr[0].Length;
                        if (intOtHr == 1)
                        {
                            strOutHr = "0" + strsplithr[0];
                            strNewChkOt = CorrectList[intRow][5].Replace(strsplithr[0], strOutHr);
                        }
                        else
                        {
                            strNewChkOt = CorrectList[intRow][5].ToString();
                        }

                        if (strNewChkOt.Length == 5)
                        {
                            strNewChkOt = strNewChkOt + ":00";
                        }

                        strcheckout = Convert.ToString("01-01-1000 " + strNewChkOt);
                        DateTime dtChkOut = objCommon.textWithTimeToDateTime(strcheckout);
                        // Checks Check-out time is less than business unit's check-out time then add to Earlygoing list
                        if (dtChkinChkout.Rows[0]["CORPRT_CHECKOUT"].ToString() != "")
                        {
                            dtchkOutBus = Convert.ToDateTime(dtChkinChkout.Rows[0]["CORPRT_CHECKOUT"].ToString());
                            string strBusChkout = dtchkOutBus.ToString("HH:mm:ss tt");
                            string strchkout = Convert.ToString("01-01-1000 " + strBusChkout);
                            DateTime dtChkBusOut = objCommon.textWithTimeToDateTime(strchkout);
                            if (dtChkOut < dtChkBusOut)
                            {
                                EarlyGoingList.Add(CorrectList[intRow]);
                            }
                        }
                    }

                    string strEmpCode = CorrectList[intRow][0].ToString();
                    string strAttDate = CorrectList[intRow][3].ToString();

                    for (int intSecondRow = 0; intSecondRow <= CorrectList.Count - 1; intSecondRow++)
                    {
                        if (intRow != intSecondRow)
                        {
                            if (strEmpCode == CorrectList[intSecondRow][0].ToString() && strAttDate == CorrectList[intSecondRow][3].ToString())
                            {
                                DuplicateList.Add(CorrectList[intSecondRow]);
                                CorrectList.RemoveAt(intSecondRow);
                                goto outerlabel;
                            }
                        }
                    }


                    // Checks the empployee is present is marked on the table
                    objEntEmpAcesMgmt.AttendenceDate = objCommon.textToDateTime(CorrectList[intRow][3].ToString());
                    DataTable dtAttendate = objBusinessEmpAcessMgmt.ReadAttendence(objEntEmpAcesMgmt);
                    if (dtAttendate.Rows.Count > 0)
                    {
                        DuplicateList.Add(CorrectList[intRow]);
                        CorrectList.RemoveAt(intRow);
                        goto outerlabel;
                    }

                }
            outerlabel: ;
            }
            //save Invalid data to hidden field
            if (EmpIdWithMisngChkinChkout.Count > 0)
            {

                string strMissListJson = ConvertArrayToJson(EmpIdWithMisngChkinChkout);
                HiddenMissingData.Value = strMissListJson;

            }

            //For duplicate list
            HiddenDupListCount.Value = DuplicateList.Count.ToString();
            if (DuplicateList.Count > 0)
            {

                string strDupListJson = ConvertArrayToJson(DuplicateList);
                HiddenDupJsonList.Value = strDupListJson;
                HiddenDupJsonListSave.Value = strDupListJson;
                string strDupList = CovertListToHTMLDup(DuplicateList);
                divDupTable.InnerHtml = strDupList;

            }


            //Early going List
            EarlyGoingList.Reverse();
            HiddenEarliListCount.Value = EarlyGoingList.Count.ToString();
            if (EarlyGoingList.Count > 0)
            {
                if (EarlyGoingList.Count < 100)
                {
                    btnEarlyNext.Enabled = false;

                    string strEarlylistJson = ConvertArrayToJson(EarlyGoingList);
                    HiddenEarlyJsonListSave.Value = strEarlylistJson;
                    string strEarlyListHtml = CovertListToHTMLEarly(EarlyGoingList);
                    divEmpEarlyGoingList.InnerHtml = strEarlyListHtml;
                }
                else
                {
                    btnEarlyNext.Enabled = true;
                    DataTable dtJsonEarlyList = new DataTable();
                    dtJsonEarlyList.Columns.Add("EmpId", typeof(string));
                    dtJsonEarlyList.Columns.Add("EmpFName", typeof(string));
                    dtJsonEarlyList.Columns.Add("EmpLName", typeof(string));
                    dtJsonEarlyList.Columns.Add("Date", typeof(string));
                    dtJsonEarlyList.Columns.Add("Checkin", typeof(string));
                    dtJsonEarlyList.Columns.Add("Checkout", typeof(string));
                    for (int intRow = 0; intRow <= EarlyGoingList.Count - 1; intRow++)
                    {
                        DataRow drEarlyList = dtJsonEarlyList.NewRow();
                        drEarlyList["EmpId"] = EarlyGoingList[intRow][0].ToString();
                        drEarlyList["EmpFName"] = EarlyGoingList[intRow][1].ToString();
                        drEarlyList["EmpLName"] = EarlyGoingList[intRow][2].ToString();
                        drEarlyList["Date"] = EarlyGoingList[intRow][3].ToString();
                        drEarlyList["Checkin"] = EarlyGoingList[intRow][4].ToString();
                        drEarlyList["Checkout"] = EarlyGoingList[intRow][5].ToString();
                        dtJsonEarlyList.Rows.Add(drEarlyList);
                    }
                    string strEarlylistJson = ConvertArrayToJson(EarlyGoingList);
                    HiddenEarlyJsonListSave.Value = strEarlylistJson;

                    string strJson = DataTableToJSONWithJavaScriptSerializer(dtJsonEarlyList);
                    HiddenEarlyJsonList.Value = strJson;
                    btnEarlyNext.Enabled = true;
                    var CurrentEarlyList = new List<string[]>();
                    for (int intRow = 0; intRow < 100; intRow++)
                    {
                        CurrentEarlyList.Add(EarlyGoingList[intRow]);
                    }
                    HiddenEarlyNext.Value = "100";
                    string strEarlyListHtml = CovertListToHTMLEarly(CurrentEarlyList);
                    divEmpEarlyGoingList.InnerHtml = strEarlyListHtml;
                }
            }

            //LateComeList
            LateComersList.Reverse();
            HiddenLateComeListCount.Value = LateComersList.Count.ToString();
            if (LateComersList.Count > 0)
            {
                if (LateComersList.Count < 100)
                {
                    btnLateNext.Enabled = false;
                    string strlatelistJson = ConvertArrayToJson(LateComersList);
                    HiddenLateComeJsonListSave.Value = strlatelistJson;
                    string strLateListHtml = CovertListToHTMLLate(LateComersList);
                    divEmpLateComers.InnerHtml = strLateListHtml;
                }
                else
                {
                    btnLateNext.Enabled = true;
                    DataTable dtJsonLatecomList = new DataTable();
                    dtJsonLatecomList.Columns.Add("EmpId", typeof(string));
                    dtJsonLatecomList.Columns.Add("EmpFName", typeof(string));
                    dtJsonLatecomList.Columns.Add("EmpLName", typeof(string));
                    dtJsonLatecomList.Columns.Add("Date", typeof(string));
                    dtJsonLatecomList.Columns.Add("Checkin", typeof(string));
                    dtJsonLatecomList.Columns.Add("Checkout", typeof(string));
                    for (int intRow = 0; intRow <= LateComersList.Count - 1; intRow++)
                    {
                        DataRow drInLateList = dtJsonLatecomList.NewRow();
                        drInLateList["EmpId"] = LateComersList[intRow][0].ToString();
                        drInLateList["EmpFName"] = LateComersList[intRow][1].ToString();
                        drInLateList["EmpLName"] = LateComersList[intRow][2].ToString();
                        drInLateList["Date"] = LateComersList[intRow][3].ToString();
                        drInLateList["Checkin"] = LateComersList[intRow][4].ToString();
                        drInLateList["Checkout"] = LateComersList[intRow][5].ToString();
                        dtJsonLatecomList.Rows.Add(drInLateList);
                    }
                    string strlatelistJson = ConvertArrayToJson(LateComersList);
                    HiddenLateComeJsonListSave.Value = strlatelistJson;

                    string strJson = DataTableToJSONWithJavaScriptSerializer(dtJsonLatecomList);
                    HiddenLateComeJsonList.Value = strJson;
                    btnLateNext.Enabled = true;
                    var CurrentLateList = new List<string[]>();
                    for (int intRow = 0; intRow < 100; intRow++)
                    {
                        CurrentLateList.Add(LateComersList[intRow]);
                    }
                    HiddenLateNext.Value = "100";
                    string strlateListHtml = CovertListToHTMLLate(CurrentLateList);
                    divEmpLateComers.InnerHtml = strlateListHtml;
                }
            }

            //Incorrect list
            IncorrectList.Reverse();
            HiddenIncrctListCount.Value = IncorrectList.Count.ToString();
            if (IncorrectList.Count > 0)
            {
                if (IncorrectList.Count < 100)
                {
                    btnInCorrectNext.Enabled = false;
                    string strInCorrectlistJson = ConvertArrayToJson(IncorrectList);
                    HiddenIncrctJsonList.Value = strInCorrectlistJson;
                    string strInCorrectListHtml = CovertListToHTMLincrct(IncorrectList);
                    divEmpIncorrectList.InnerHtml = strInCorrectListHtml;
                }
                else
                {
                    btnInCorrectNext.Enabled = true;
                    DataTable dtJsonInCrctList = new DataTable();
                    dtJsonInCrctList.Columns.Add("EmpId", typeof(string));
                    dtJsonInCrctList.Columns.Add("EmpFName", typeof(string));
                    dtJsonInCrctList.Columns.Add("EmpLName", typeof(string));
                    dtJsonInCrctList.Columns.Add("Date", typeof(string));
                    dtJsonInCrctList.Columns.Add("Checkin", typeof(string));
                    dtJsonInCrctList.Columns.Add("Checkout", typeof(string));
                    for (int intRow = 0; intRow <= IncorrectList.Count - 1; intRow++)
                    {
                        DataRow drInCrctList = dtJsonInCrctList.NewRow();
                        drInCrctList["EmpId"] = IncorrectList[intRow][0].ToString();
                        drInCrctList["EmpFName"] = IncorrectList[intRow][1].ToString();
                        drInCrctList["EmpLName"] = IncorrectList[intRow][2].ToString();
                        drInCrctList["Date"] = IncorrectList[intRow][3].ToString();
                        drInCrctList["Checkin"] = IncorrectList[intRow][4].ToString();
                        drInCrctList["Checkout"] = IncorrectList[intRow][5].ToString();
                        dtJsonInCrctList.Rows.Add(drInCrctList);
                    }
                    string strJson = DataTableToJSONWithJavaScriptSerializer(dtJsonInCrctList);
                    HiddenIncrctJsonList.Value = strJson;
                    btnInCorrectNext.Enabled = true;
                    var CurrentInCorrectList = new List<string[]>();
                    for (int intRow = 0; intRow < 100; intRow++)
                    {
                        CurrentInCorrectList.Add(IncorrectList[intRow]);
                    }
                    HiddenIncorrectNext.Value = "100";
                    string strInCorrectListHtml = CovertListToHTMLincrct(CurrentInCorrectList);
                    divEmpIncorrectList.InnerHtml = strInCorrectListHtml;
                }
            }


            HiddenCrctListCount.Value = CorrectList.Count.ToString();
            if (CorrectList.Count < 100)
            {
                btnCorrectNext.Enabled = false;
                string strCorrectlistJson = ConvertArrayToJson(CorrectList);
                HiddenCrctJsonListSave.Value = strCorrectlistJson;
                string strCorrectListHtml = CovertListToHTML(CorrectList);
                divEmpCorrectList.InnerHtml = strCorrectListHtml;
            }
            else
            {
                btnCorrectNext.Enabled = true;
                DataTable dtJsonCrctList = new DataTable();
                dtJsonCrctList.Columns.Add("EmpId", typeof(string));
                dtJsonCrctList.Columns.Add("EmpFName", typeof(string));
                dtJsonCrctList.Columns.Add("EmpLName", typeof(string));
                dtJsonCrctList.Columns.Add("Date", typeof(string));
                dtJsonCrctList.Columns.Add("Checkin", typeof(string));
                dtJsonCrctList.Columns.Add("Checkout", typeof(string));
                for (int intRow = 0; intRow <= CorrectList.Count - 1; intRow++)
                {
                    DataRow drCrctList = dtJsonCrctList.NewRow();
                    drCrctList["EmpId"] = CorrectList[intRow][0].ToString();
                    drCrctList["EmpFName"] = CorrectList[intRow][1].ToString();
                    drCrctList["EmpLName"] = CorrectList[intRow][2].ToString();
                    drCrctList["Date"] = CorrectList[intRow][3].ToString();
                    drCrctList["Checkin"] = CorrectList[intRow][4].ToString();
                    drCrctList["Checkout"] = CorrectList[intRow][5].ToString();
                    dtJsonCrctList.Rows.Add(drCrctList);
                }
                string strCorrectlistJson = ConvertArrayToJson(CorrectList);
                HiddenCrctJsonListSave.Value = strCorrectlistJson;

                string strJson = DataTableToJSONWithJavaScriptSerializer(dtJsonCrctList);
                HiddenCrctJsonList.Value = strJson;
                btnCorrectNext.Enabled = true;
                var CurrentCorrectList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    CurrentCorrectList.Add(CorrectList[intRow]);
                }
                HiddenCorrectNext.Value = "100";
                string strEmpCorrectHtml = CovertListToHTML(CurrentCorrectList);
                divEmpCorrectList.InnerHtml = strEmpCorrectHtml;

            }
            File.Delete(Server.MapPath(strFilePath) + fupImportCsv.FileName);
        }
        }
        catch (Exception ex)
        {
            throw ex;
        }
       
        btnNextPage.Enabled = true;
    }
    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
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



    public string CovertListToHTMLDup(List<string[]> DuplicateList)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"DupEmpList\" class=\"table table-bordered table-striped\" cellspacing=\"0\" cellpadding=\"2px\" style=\"width:100%;float:left;\">";
        //add rows
        int intSerialNumber = 0;

        strHtml += "<tbody>";
        if (DuplicateList.Count == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td  colspan='7'> <p style=\"text-align: center;font-family: calibri;\">No Data Available</p></td>";
            strHtml += "</tr>";
        }
        else
        {
            strHtml += "<thead>";
            strHtml += "<tr >";
            strHtml += "<th  style=\"width:5%;text-align: left; word-wrap:break-word;\"></th>";
            strHtml += "<th  style=\"width:15%;text-align: left; word-wrap:break-word;\">" + "Employee Code" + "</th>";
            strHtml += "<th  style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "First Name" + "</th>";
            strHtml += "<th  style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "Last Name" + "</th>";
            strHtml += "<th   style=\"width:15%;text-align:left; word-wrap:break-word;\">" + "Attendence Date" + "</th>";
            strHtml += "<th  style=\"width:12.5%;text-align: center; word-wrap:break-word;\">" + "Check-in" + "</th>";
            strHtml += "<th  style=\"width:12.5%;text-align: left; word-wrap:break-word;\">" + "Check-out" + "</th>";
            strHtml += "</tr>";
            strHtml += "</thead>";
            for (int intRowBodyCount = 0; intRowBodyCount < DuplicateList.Count; intRowBodyCount++)
            {
                intSerialNumber++;
                strHtml += "<tr id=\"Duprow_" + intSerialNumber + "\" >";
                //for serial number               
                strHtml += "<td style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >";
                strHtml += "<input id=\"Dupcbx_" + intSerialNumber + "\" name=\"Dupcbx" + intSerialNumber + "\"  type=checkbox   style=\" width:97%;\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\"  onchange=\"changeCbx(" + intSerialNumber + ");\" />";
                strHtml += "</td>";
                int len = DuplicateList[intRowBodyCount].Length;
                string EmployeeID = DuplicateList[intRowBodyCount][0].ToString().Replace("<", string.Empty);
                EmployeeID = EmployeeID.Replace(">", string.Empty);
                strHtml += "<td id=\"tdDupEmpFName_" + intSerialNumber + "\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeID + "</td>";

                string EmployeeFName = DuplicateList[intRowBodyCount][1].ToString().Replace("<", string.Empty);
                EmployeeFName = EmployeeFName.Replace(">", string.Empty);
                strHtml += "<td id=\"tdDupEmpFName_" + intSerialNumber + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeFName + "</td>";

                string EmployeeLName = DuplicateList[intRowBodyCount][2].ToString().Replace("<", string.Empty);
                EmployeeLName = EmployeeLName.Replace(">", string.Empty);
                strHtml += "<td id=\"tdDupEmpLName_" + intSerialNumber + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeLName + "</td>";

                DateTime AttendDate = objCommon.textToDateTime(DuplicateList[intRowBodyCount][3].ToString());
                strHtml += "<td id=\"tdDupAttendDate_" + intSerialNumber + "\" name=\"tdDupAttendDate" + intSerialNumber + "\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + AttendDate.ToString("dd-MM-yyyy") + "</td>";

                string FirstCheckIn = DuplicateList[intRowBodyCount][4].ToString();
                strHtml += "<td id=\"tdDupFirstCheckIn_" + intSerialNumber + "\" name=\"tdDupFirstCheckIn" + intSerialNumber + "\"  style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + FirstCheckIn + "</td>";

                string LastCheckOut = DuplicateList[intRowBodyCount][5].ToString();
                strHtml += "<td id=\"tdDupLastCheckOut_" + intSerialNumber + "\" name=\"tdDupLastCheckOut" + intSerialNumber + "\"   style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + LastCheckOut + "</td>";

                strHtml += "<td id=\"tdDupRowCount_" + intSerialNumber + "\" name=\"tdDupRowCount_" + intSerialNumber + "\"   style=\"display:none; width:12.5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + intRowBodyCount + "</td>";

                strHtml += "<td class=\"tdT\" style=\"display:none;width:3%; word-break: break-all; word-wrap:break-word;text-align: center;padding:0px;height:20px;\">" + " <a  style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left:1%;z-index: 29;\" title=\"Cancel\" onclick='return DeleteRow(" + intSerialNumber + ");' >"
                                               + "<img style=\"cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";
                strHtml += "</tr>";
            }
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public string CovertListToHTMLincrct(List<string[]> IncorrectList)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"InCorrectEmpList\" class=\"tableCsv dataTable \" cellspacing=\"0\" cellpadding=\"2px\" style=\"width:100%;float:left;\">";
        //add rows
        int intSerialNumber = 0;
        int RowIndex = 0;

        strHtml += "<tbody>";
        if (IncorrectList.Count == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td  colspan='7'> <p style=\"text-align: center;font-family: calibri;\">No Data Available</p></td>";
            strHtml += "</tr>";
        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < IncorrectList.Count; intRowBodyCount++)
            {
                RowIndex++;
                intSerialNumber++;
                string strInHr = "";
                string strNewChkIn = "";
                string strOutHr = "";
                string strNewChkOt = "";
                string EmployeeID = "";
                string EmployeeFName = "";
                string EmployeeLName = "";
                DateTime AttendDate;
                strHtml += "<tr id=\"Inrow" + intSerialNumber + "\" >";
                strHtml += "<td id=\"tdInRowIndex" + intSerialNumber + "\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + RowIndex + "</td>";
                if (IncorrectList[intRowBodyCount][0].ToString() == "")
                {
                    EmployeeID = "";
                }
                else
                {
                    EmployeeID = IncorrectList[intRowBodyCount][0].ToString().Replace("<", string.Empty);
                    EmployeeID = EmployeeID.Replace(">", string.Empty);
                }
                strHtml += "<td id=\"tdInEmpId" + intSerialNumber + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeID + "</td>";

                EmployeeFName = IncorrectList[intRowBodyCount][1].ToString().Replace("<", string.Empty);
                EmployeeFName = EmployeeFName.Replace(">", string.Empty);
                strHtml += "<td id=\"tdInEmpFName" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeFName + "</td>";

                EmployeeLName = IncorrectList[intRowBodyCount][2].ToString().Replace("<", string.Empty);
                EmployeeLName = EmployeeLName.Replace(">", string.Empty);
                strHtml += "<td id=\"tdInEmpLName" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeLName + "</td>";

                strHtml += "<td id=\"tdInAttendDate" + intSerialNumber + "\" name=\"tdInAttendDate" + intSerialNumber + "\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + IncorrectList[intRowBodyCount][3].ToString() + "</td>";

                strNewChkIn = IncorrectList[intRowBodyCount][4].ToString();
                strHtml += "<td id=\"tdInFirstCheckIn" + intSerialNumber + "\" name=\"tdInFirstCheckIn" + intSerialNumber + "\"  style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strNewChkIn + "</td>";

                strNewChkOt = IncorrectList[intRowBodyCount][5].ToString();
                strHtml += "<td id=\"tdInLastCheckOut" + intSerialNumber + "\" name=\"tdInLastCheckOut" + intSerialNumber + "\"   style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strNewChkOt + "</td>";

                strHtml += "</tr>";
            }
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public string CovertListToHTML(List<string[]> CorrectList)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"CorrectEmpList\" class=\"tableCsv dataTable \" cellspacing=\"0\" cellpadding=\"2px\" style=\"width:100%;float:left;\">";
        //add rows
        int intSerialNumber = 0;
        int RowIndex = 0;

        strHtml += "<tbody>";
        if (CorrectList.Count == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td  colspan='7'> <p style=\"text-align: center;font-family: calibri;\">No Data Available</p></td>";
            strHtml += "</tr>";
        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < CorrectList.Count; intRowBodyCount++)
            {
                RowIndex++;
                intSerialNumber++;
                string strInHr = "";
                string strNewChkIn = "";
                string strOutHr = "";
                string strNewChkOt = "";
                strHtml += "<tr id=\"row" + intSerialNumber + "\" >";
                strHtml += "<td id=\"tdRowIndex" + intSerialNumber + "\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + RowIndex + "</td>";
                int len = CorrectList[intRowBodyCount].Length;
                string EmployeeID = CorrectList[intRowBodyCount][0].ToString().Replace("<", string.Empty);
                EmployeeID = EmployeeID.Replace(">", string.Empty);
                strHtml += "<td id=\"tdEmpId" + intSerialNumber + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeID + "</td>";

                string EmployeeFName = CorrectList[intRowBodyCount][1].ToString().Replace("<", string.Empty);
                EmployeeFName = EmployeeFName.Replace(">", string.Empty);
                strHtml += "<td id=\"tdEmpFName" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeFName + "</td>";

                string EmployeeLName = CorrectList[intRowBodyCount][2].ToString().Replace("<", string.Empty);
                EmployeeLName = EmployeeLName.Replace(">", string.Empty);
                strHtml += "<td id=\"tdEmpLName" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeLName + "</td>";

                DateTime AttendDate = objCommon.textToDateTime(CorrectList[intRowBodyCount][3].ToString());
                strHtml += "<td id=\"tdAttendDate" + intSerialNumber + "\" name=\"tdAttendDate" + intSerialNumber + "\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + AttendDate.ToString("dd-MM-yyyy") + "</td>";

                string[] strsplitspceIn = Convert.ToString(CorrectList[intRowBodyCount][4]).Split(' ');
                string[] strsplithrIn = strsplitspceIn[0].Split(':');
                int intInHr = strsplithrIn[0].Length;
                if (intInHr == 1)
                {
                    strInHr = "0" + strsplithrIn[0];
                    strNewChkIn = CorrectList[intRowBodyCount][4].Replace(strsplithrIn[0], strInHr);
                }
                else
                {
                    strNewChkIn = CorrectList[intRowBodyCount][4].ToString();
                }
                strHtml += "<td id=\"tdFirstCheckIn" + intSerialNumber + "\" name=\"tdFirstCheckIn" + intSerialNumber + "\"  style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strNewChkIn + "</td>";

                string[] strsplitspceOt = Convert.ToString(CorrectList[intRowBodyCount][5]).Split(' ');
                string[] strsplithr = strsplitspceOt[0].Split(':');
                int intOtHr = strsplithr[0].Length;
                if (intOtHr == 1)
                {
                    strOutHr = "0" + strsplithr[0];
                    strNewChkOt = CorrectList[intRowBodyCount][5].Replace(strsplithr[0], strOutHr);
                }
                else
                {
                    strNewChkOt = CorrectList[intRowBodyCount][5].ToString();
                }
                strHtml += "<td id=\"tdLastCheckOut" + intSerialNumber + "\" name=\"tdLastCheckOut" + intSerialNumber + "\"   style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strNewChkOt + "</td>";


                strHtml += "</tr>";
            }
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public string CovertListToHTMLEarly(List<string[]> EarliList)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"EarlyEmpList\" class=\"tableCsv dataTable \" cellspacing=\"0\" cellpadding=\"2px\" style=\"width:100%;float:left;\">";
        //add rows
        int intSerialNumber = 0;
        int RowIndex = 0;

        strHtml += "<tbody>";
        if (EarliList.Count == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td  colspan='7'> <p style=\"text-align: center;font-family: calibri;\">No Data Available</p></td>";
            strHtml += "</tr>";
        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < EarliList.Count; intRowBodyCount++)
            {
                RowIndex++;
                intSerialNumber++;
                string strInHr = "";
                string strNewChkIn = "";
                string strOutHr = "";
                string strNewChkOt = "";
                strHtml += "<tr id=\"Earow" + intSerialNumber + "\" >";
                strHtml += "<td id=\"tdEaRowIndex" + intSerialNumber + "\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + RowIndex + "</td>";
                int len = EarliList[intRowBodyCount].Length;
                string EmployeeID = EarliList[intRowBodyCount][0].ToString().Replace("<", string.Empty);
                EmployeeID = EmployeeID.Replace(">", string.Empty);
                strHtml += "<td id=\"tdEaEmpId" + intSerialNumber + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeID + "</td>";

                string EmployeeFName = EarliList[intRowBodyCount][1].ToString().Replace("<", string.Empty);
                EmployeeFName = EmployeeFName.Replace(">", string.Empty);
                strHtml += "<td id=\"tdEaEmpFName" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeFName + "</td>";

                string EmployeeLName = EarliList[intRowBodyCount][2].ToString().Replace("<", string.Empty);
                EmployeeLName = EmployeeLName.Replace(">", string.Empty);
                strHtml += "<td id=\"tdEaEmpLName" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeLName + "</td>";

                DateTime AttendDate = objCommon.textToDateTime(EarliList[intRowBodyCount][3].ToString());
                strHtml += "<td id=\"tdEaAttendDate" + intSerialNumber + "\" name=\"tdEaAttendDate" + intSerialNumber + "\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + AttendDate.ToString("dd-MM-yyyy") + "</td>";

                string[] strsplitspceIn = Convert.ToString(EarliList[intRowBodyCount][4]).Split(' ');
                string[] strsplithrIn = strsplitspceIn[0].Split(':');
                int intInHr = strsplithrIn[0].Length;
                if (intInHr == 1)
                {
                    strInHr = "0" + strsplithrIn[0];
                    strNewChkIn = EarliList[intRowBodyCount][4].Replace(strsplithrIn[0], strInHr);
                }
                else
                {
                    strNewChkIn = EarliList[intRowBodyCount][4].ToString();
                }
                strHtml += "<td id=\"tdEaFirstCheckIn" + intSerialNumber + "\" name=\"tdEaFirstCheckIn" + intSerialNumber + "\"  style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strNewChkIn + "</td>";

                string[] strsplitspceOt = Convert.ToString(EarliList[intRowBodyCount][5]).Split(' ');
                string[] strsplithr = strsplitspceOt[0].Split(':');
                int intOtHr = strsplithr[0].Length;
                if (intOtHr == 1)
                {
                    strOutHr = "0" + strsplithr[0];
                    strNewChkOt = EarliList[intRowBodyCount][5].Replace(strsplithr[0], strOutHr);
                }
                else
                {
                    strNewChkOt = EarliList[intRowBodyCount][5].ToString();
                }
                strHtml += "<td id=\"tdEaLastCheckOut" + intSerialNumber + "\" name=\"tdEaLastCheckOut" + intSerialNumber + "\"   style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strNewChkOt + "</td>";


                strHtml += "</tr>";
            }
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }


    public string CovertListToHTMLLate(List<string[]> LateComeList)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"LateEmpList\" class=\"tableCsv dataTable \" cellspacing=\"0\" cellpadding=\"2px\" style=\"width:100%;float:left;\">";
        //add rows
        int intSerialNumber = 0;
        int RowIndex = 0;

        strHtml += "<tbody>";
        if (LateComeList.Count == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td  colspan='7'> <p style=\"text-align: center;font-family: calibri;\">No Data Available</p></td>";
            strHtml += "</tr>";
        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < LateComeList.Count; intRowBodyCount++)
            {
                RowIndex++;
                intSerialNumber++;
                string strInHr = "";
                string strNewChkIn = "";
                string strOutHr = "";
                string strNewChkOt = "";
                strHtml += "<tr id=\"Larow" + intSerialNumber + "\" >";
                strHtml += "<td id=\"tdLaRowIndex" + intSerialNumber + "\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + RowIndex + "</td>";
                int len = LateComeList[intRowBodyCount].Length;
                string EmployeeID = LateComeList[intRowBodyCount][0].ToString().Replace("<", string.Empty);
                EmployeeID = EmployeeID.Replace(">", string.Empty);
                strHtml += "<td id=\"tdLaEmpId" + intSerialNumber + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeID + "</td>";

                string EmployeeFName = LateComeList[intRowBodyCount][1].ToString().Replace("<", string.Empty);
                EmployeeFName = EmployeeFName.Replace(">", string.Empty);
                strHtml += "<td id=\"tdLaEmpFName" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeFName + "</td>";

                string EmployeeLName = LateComeList[intRowBodyCount][2].ToString().Replace("<", string.Empty);
                EmployeeLName = EmployeeLName.Replace(">", string.Empty);
                strHtml += "<td id=\"tdLaEmpLName" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeLName + "</td>";

                DateTime AttendDate = objCommon.textToDateTime(LateComeList[intRowBodyCount][3].ToString());
                strHtml += "<td id=\"tdLaAttendDate" + intSerialNumber + "\" name=\"tdLaAttendDate" + intSerialNumber + "\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + AttendDate.ToString("dd-MM-yyyy") + "</td>";

                string[] strsplitspceIn = Convert.ToString(LateComeList[intRowBodyCount][4]).Split(' ');
                string[] strsplithrIn = strsplitspceIn[0].Split(':');
                int intInHr = strsplithrIn[0].Length;
                if (intInHr == 1)
                {
                    strInHr = "0" + strsplithrIn[0];
                    strNewChkIn = LateComeList[intRowBodyCount][4].Replace(strsplithrIn[0], strInHr);
                }
                else
                {
                    strNewChkIn = LateComeList[intRowBodyCount][4].ToString();
                }
                strHtml += "<td id=\"tdLaFirstCheckIn" + intSerialNumber + "\" name=\"tdLaFirstCheckIn" + intSerialNumber + "\"  style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strNewChkIn + "</td>";

                string[] strsplitspceOt = Convert.ToString(LateComeList[intRowBodyCount][5]).Split(' ');
                string[] strsplithr = strsplitspceOt[0].Split(':');
                int intOtHr = strsplithr[0].Length;
                if (intOtHr == 1)
                {
                    strOutHr = "0" + strsplithr[0];
                    strNewChkOt = LateComeList[intRowBodyCount][5].Replace(strsplithr[0], strOutHr);
                }
                else
                {
                    strNewChkOt = LateComeList[intRowBodyCount][5].ToString();
                }
                strHtml += "<td id=\"tdLaLastCheckOut" + intSerialNumber + "\" name=\"tdLaLastCheckOut" + intSerialNumber + "\"   style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strNewChkOt + "</td>";

                strHtml += "</tr>";
            }
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }  /// <summary>
    /// Class to read data from a CSV file
    /// </summary>
    public class CsvFileReader : StreamReader
    {
        public CsvFileReader(Stream stream)
            : base(stream)
        {
        }

        public CsvFileReader(string filename)
            : base(filename)
        {
        }

        /// <summary>
        /// Reads a row of data from a CSV file
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool ReadRow(CsvRow row)
        {
            row.LineText = ReadLine();
            if (String.IsNullOrEmpty(row.LineText))
                return false;

            int pos = 0;
            int rows = 0;

            while (pos < row.LineText.Length)
            {
                string value;

                // Special handling for quoted field
                if (row.LineText[pos] == '"')
                {
                    // Skip initial quote
                    pos++;

                    // Parse quoted value
                    int start = pos;
                    while (pos < row.LineText.Length)
                    {
                        // Test for quote character
                        if (row.LineText[pos] == '"')
                        {
                            // Found one
                            pos++;

                            // If two quotes together, keep one
                            // Otherwise, indicates end of value
                            if (pos >= row.LineText.Length || row.LineText[pos] != '"')
                            {
                                pos--;
                                break;
                            }
                        }
                        pos++;
                    }
                    value = row.LineText.Substring(start, pos - start);
                    value = value.Replace("\"\"", "\"");
                }
                else
                {
                    // Parse unquoted value
                    int start = pos;
                    while (pos < row.LineText.Length && row.LineText[pos] != ',')
                        pos++;
                    value = row.LineText.Substring(start, pos - start);
                }

                // Add field to list
                if (rows < row.Count)
                    row[rows] = value;
                else
                    row.Add(value);
                rows++;

                // Eat up to and including next comma
                while (pos < row.LineText.Length && row.LineText[pos] != ',')
                    pos++;
                if (pos < row.LineText.Length)
                    pos++;
            }
            // Delete any unused items
            while (row.Count > rows)
                row.RemoveAt(rows);

            // Return true if any columns read
            return (row.Count > 0);
        }
    }
    //converting string array list to json
    private string ConvertArrayToJson(List<string[]> strArrayList)
    {
        string strjson = JsonConvert.SerializeObject(strArrayList);
        return strjson;
    }

    public class clsEmpAcesMgmtDtl
    {
        public string EMPID { get; set; }
        public string EMPFNAME { get; set; }
        public string EMPLNAME { get; set; }
        public string DATE { get; set; }
        public string CHECKIN { get; set; }
        public string CHECKOUT { get; set; }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveData();
    }

    [WebMethod]
    public static string[] ServiceCorrectListToHtml(string strList, string strCount, string strMode, string strTotalCount)
    {
        string[] strOutput = new string[2];
        if (strList != "")
        {
            string jsonDataPW = strList;
            string R1PW = jsonDataPW.Replace("\"{", "\\{");
            string R2PW = R1PW.Replace("\\n", "\r\n");
            string R3PW = R2PW.Replace("\\", "");
            string R4PW = R3PW.Replace("}\"]", "}]");
            string R5PW = R4PW.Replace("}\",", "},");
            List<clsEmpAcesMgmtDtl> objWBDataPWList = new List<clsEmpAcesMgmtDtl>();
            objWBDataPWList = JsonConvert.DeserializeObject<List<clsEmpAcesMgmtDtl>>(R5PW);
            int intCount = Convert.ToInt32(strCount);
            int intFinalCount = 0;

            if (intCount < 100)
                intCount = 0;

            //strMode=1 for next and 0 for previous.
            if (strMode == "1")
            {
                intFinalCount = intCount + 100;
                if (intFinalCount > Convert.ToInt32(strTotalCount))
                    intFinalCount = Convert.ToInt32(strTotalCount);
            }
            else
            {
                if (intCount % 100 == 0)
                {
                    intFinalCount = intCount - 100;
                    intCount = intFinalCount - 100;
                    if (intCount < 0)
                        intCount = 0;
                }
                else
                {
                    intFinalCount = intCount - (intCount % 100);
                    intCount = intFinalCount - 100;
                    if (intCount < 0)
                        intCount = 0;
                }
            }


            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"CorrectEmpList\" class=\"tableCsv dataTable \" cellspacing=\"0\" cellpadding=\"2px\" style=\"width:100%;float:left;\">";

            //add rows
            int intSerialNumber = 0;
            strHtml += "<tbody>";

            foreach (clsEmpAcesMgmtDtl objclsJSData in objWBDataPWList)
            {


                intSerialNumber++;

                if (intSerialNumber > intCount && intSerialNumber <= intFinalCount)
                {
                    string strInHr = "";
                    string strNewChkIn = "";
                    string strOutHr = "";
                    string strNewChkOt = "";
                    strHtml += "<tr id=\"row" + intSerialNumber + "\" >";
                    //for serial number
                    strHtml += "<td id=\"tdRowIndex" + intSerialNumber + "\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + intSerialNumber + "</td>";

                    string EmployeeID = objclsJSData.EMPID.ToString().Replace("<", string.Empty);
                    EmployeeID = EmployeeID.Replace(">", string.Empty);
                    strHtml += "<td id=\"tdEmpId" + intSerialNumber + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeID + "</td>";

                    string EmployeeFName = objclsJSData.EMPFNAME.ToString().Replace("<", string.Empty);
                    EmployeeFName = EmployeeFName.Replace(">", string.Empty);
                    strHtml += "<td id=\"tdEmpFName" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeFName + "</td>";

                    string EmployeeLName = objclsJSData.EMPLNAME.ToString().Replace("<", string.Empty);
                    EmployeeLName = EmployeeLName.Replace(">", string.Empty);
                    strHtml += "<td id=\"tdEmpLName" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeLName + "</td>";

                    if (objclsJSData.DATE != "")
                    {
                        DateTime AttendDate = objCommon.textToDateTime(objclsJSData.DATE);
                        strHtml += "<td id=\"tdAttendDate" + intSerialNumber + "\" name=\"tdAttendDate" + intSerialNumber + "\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + AttendDate.ToString("dd-MM-yyyy") + "</td>";
                    }
                    else
                    {
                        strHtml += "<td id=\"tdAttendDate" + intSerialNumber + "\" name=\"tdAttendDate" + intSerialNumber + "\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  ></td>";
                    }

                    string[] strsplitspceIn = Convert.ToString(objclsJSData.CHECKIN).Split(' ');
                    string[] strsplithrIn = strsplitspceIn[0].Split(':');
                    int intInHr = strsplithrIn[0].Length;
                    if (intInHr == 1)
                    {
                        strInHr = "0" + strsplithrIn[0];
                        strNewChkIn = objclsJSData.CHECKIN.Replace(strsplithrIn[0], strInHr);
                    }
                    else
                    {
                        strNewChkIn = objclsJSData.CHECKIN.ToString();
                    }
                    strHtml += "<td id=\"tdFirstCheckIn" + intSerialNumber + "\" name=\"tdFirstCheckIn" + intSerialNumber + "\"  style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strNewChkIn + "</td>";

                    string[] strsplitspceOt = Convert.ToString(objclsJSData.CHECKOUT).Split(' ');
                    string[] strsplithr = strsplitspceOt[0].Split(':');
                    int intOtHr = strsplithr[0].Length;
                    if (intOtHr == 1)
                    {
                        strOutHr = "0" + strsplithr[0];
                        strNewChkOt = objclsJSData.CHECKOUT.Replace(strsplithr[0], strOutHr);
                    }
                    else
                    {
                        strNewChkOt = objclsJSData.CHECKOUT.ToString();
                    }
                    strHtml += "<td id=\"tdLastCheckOut" + intSerialNumber + "\" name=\"tdLastCheckOut" + intSerialNumber + "\"   style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strNewChkOt + "</td>";

                    strHtml += "</tr>";
                }
            }
            strHtml += "</tbody>";

            strHtml += "</table>";



            sb.Append(strHtml);
            strOutput[0] = sb.ToString();
            strOutput[1] = intFinalCount.ToString();
        }
        return strOutput;
    }

    [WebMethod]
    public static string[] ServiceInCorrectListToHtml(string strList, string strCount, string strMode, string strTotalCount)
    {
        string[] strOutput = new string[2];
        if (strList != "")
        {
            string jsonDataPW = strList;
            string R1PW = jsonDataPW.Replace("\"{", "\\{");
            string R2PW = R1PW.Replace("\\n", "\r\n");
            string R3PW = R2PW.Replace("\\", "");
            string R4PW = R3PW.Replace("}\"]", "}]");
            string R5PW = R4PW.Replace("}\",", "},");
            List<clsEmpAcesMgmtDtl> objWBDataPWList = new List<clsEmpAcesMgmtDtl>();
            objWBDataPWList = JsonConvert.DeserializeObject<List<clsEmpAcesMgmtDtl>>(R5PW);
            int intCount = Convert.ToInt32(strCount);
            int intFinalCount = 0;

            if (intCount < 100)
                intCount = 0;

            //strMode=1 for next and 0 for previous.
            if (strMode == "1")
            {
                intFinalCount = intCount + 100;
                if (intFinalCount > Convert.ToInt32(strTotalCount))
                    intFinalCount = Convert.ToInt32(strTotalCount);
            }
            else
            {
                if (intCount % 100 == 0)
                {
                    intFinalCount = intCount - 100;
                    intCount = intFinalCount - 100;
                    if (intCount < 0)
                        intCount = 0;
                }
                else
                {
                    intFinalCount = intCount - (intCount % 100);
                    intCount = intFinalCount - 100;
                    if (intCount < 0)
                        intCount = 0;
                }
            }


            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"InCorrectEmpList\" class=\"tableCsv dataTable \" cellspacing=\"0\" cellpadding=\"2px\" style=\"width:100%;float:left;\">";

            //add rows
            int intSerialNumber = 0;
            strHtml += "<tbody>";

            foreach (clsEmpAcesMgmtDtl objclsJSData in objWBDataPWList)
            {


                intSerialNumber++;

                if (intSerialNumber > intCount && intSerialNumber <= intFinalCount)
                {
                    string strInHr = "";
                    string strNewChkIn = "";
                    string strOutHr = "";
                    string strNewChkOt = "";
                    string strChkInFormat = "";
                    string strChkOutFormat = "";


                    strHtml += "<tr id=\"Inrow" + intSerialNumber + "\" >";
                    //for serial number
                    strHtml += "<td id=\"tdInRowIndex" + intSerialNumber + "\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + intSerialNumber + "</td>";

                    string empid = objclsJSData.EMPID.Replace("<", string.Empty);
                    empid = empid.Replace(">", string.Empty);
                    strHtml += "<td id=\"tdInEmpId" + intSerialNumber + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + empid + "</td>";


                    string EmpFname = objclsJSData.EMPFNAME.Replace("<", string.Empty);
                    EmpFname = EmpFname.Replace(">", string.Empty);
                    strHtml += "<td id=\"tdInEmpFName" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmpFname + "</td>";


                    string EmpLname = objclsJSData.EMPLNAME.Replace("<", string.Empty);
                    EmpLname = EmpLname.Replace(">", string.Empty);
                    strHtml += "<td id=\"tdInEmpLName" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmpLname + "</td>";

                    if (objclsJSData.DATE.ToString() == "")
                    {
                        strHtml += "<td id=\"tdInAttendDate" + intSerialNumber + "\" name=\"tdInAttendDate" + intSerialNumber + "\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  ></td>";
                    }
                    else
                    {
                        DateTime AttendDate = objCommon.textToDateTime(objclsJSData.DATE);
                        strHtml += "<td id=\"tdInAttendDate" + intSerialNumber + "\" name=\"tdInAttendDate" + intSerialNumber + "\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + AttendDate.ToString("dd-MM-yyyy") + "</td>";
                    }

                    if (objclsJSData.CHECKIN.ToString() == "")
                    {
                        strChkInFormat = "";
                    }
                    else
                    {
                        string[] strsplitspceIn = Convert.ToString(objclsJSData.CHECKIN).Split(' ');
                        string[] strsplithrIn = strsplitspceIn[0].Split(':');
                        int intInHr = strsplithrIn[0].Length;
                        if (intInHr == 1)
                        {
                            strInHr = "0" + strsplithrIn[0];
                            strNewChkIn = objclsJSData.CHECKIN.Replace(strsplithrIn[0], strInHr);
                        }
                        else
                        {
                            strNewChkIn = objclsJSData.CHECKIN.ToString();
                        }
                        string strcheckin = Convert.ToString("01-01-1000 " + strNewChkIn);
                        //DateTime dtChkIn = objCommon.textWithTimeToDateTime(strcheckin);
                        //strChkInFormat = dtChkIn.ToString("HH:mm:ss tt"); //24 hr format
                    }
                    strHtml += "<td id=\"tdInFirstCheckIn" + intSerialNumber + "\" name=\"tdInFirstCheckIn" + intSerialNumber + "\"  style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strChkInFormat + "</td>";

                    if (objclsJSData.CHECKOUT == "")
                    {
                        strChkOutFormat = "";
                    }
                    else
                    {
                        string[] strsplitspceOt = Convert.ToString(objclsJSData.CHECKOUT).Split(' ');
                        string[] strsplithr = strsplitspceOt[0].Split(':');
                        int intOtHr = strsplithr[0].Length;
                        if (intOtHr == 1)
                        {
                            strOutHr = "0" + strsplithr[0];
                            strNewChkOt = objclsJSData.CHECKOUT.Replace(strsplithr[0], strOutHr);
                        }
                        else
                        {
                            strNewChkOt = objclsJSData.CHECKOUT.ToString();
                        }
                        string strcheckout = Convert.ToString("01-01-1000 " + strNewChkOt);
                        //DateTime dtChkOut = objCommon.textWithTimeToDateTime(strcheckout);
                        //strChkOutFormat = dtChkOut.ToString("HH:mm:ss tt");
                    }
                    strHtml += "<td id=\"tdInLastCheckOut" + intSerialNumber + "\" name=\"tdInLastCheckOut" + intSerialNumber + "\"   style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strChkOutFormat + "</td>";


                    strHtml += "</tr>";
                }
            }
            strHtml += "</tbody>";

            strHtml += "</table>";



            sb.Append(strHtml);
            strOutput[0] = sb.ToString();
            strOutput[1] = intFinalCount.ToString();

        }
        return strOutput;
    }


    [WebMethod]
    public static string[] ServiceEarlygoToHtml(string strList, string strCount, string strMode, string strTotalCount)
    {
        string[] strOutput = new string[2];
        if (strList != "")
        {
            string jsonDataPW = strList;
            string R1PW = jsonDataPW.Replace("\"{", "\\{");
            string R2PW = R1PW.Replace("\\n", "\r\n");
            string R3PW = R2PW.Replace("\\", "");
            string R4PW = R3PW.Replace("}\"]", "}]");
            string R5PW = R4PW.Replace("}\",", "},");
            List<clsEmpAcesMgmtDtl> objWBDataPWList = new List<clsEmpAcesMgmtDtl>();
            objWBDataPWList = JsonConvert.DeserializeObject<List<clsEmpAcesMgmtDtl>>(R5PW);
            int intCount = Convert.ToInt32(strCount);
            int intFinalCount = 0;

            if (intCount < 100)
                intCount = 0;

            //strMode=1 for next and 0 for previous.
            if (strMode == "1")
            {
                intFinalCount = intCount + 100;
                if (intFinalCount > Convert.ToInt32(strTotalCount))
                    intFinalCount = Convert.ToInt32(strTotalCount);
            }
            else
            {
                if (intCount % 100 == 0)
                {
                    intFinalCount = intCount - 100;
                    intCount = intFinalCount - 100;
                    if (intCount < 0)
                        intCount = 0;
                }
                else
                {
                    intFinalCount = intCount - (intCount % 100);
                    intCount = intFinalCount - 100;
                    if (intCount < 0)
                        intCount = 0;
                }
            }


            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"EarlyEmpList\" class=\"tableCsv dataTable \" cellspacing=\"0\" cellpadding=\"2px\" style=\"width:100%;float:left;\">";
            //add rows
            int intSerialNumber = 0;
            strHtml += "<tbody>";

            foreach (clsEmpAcesMgmtDtl objclsJSData in objWBDataPWList)
            {


                intSerialNumber++;

                if (intSerialNumber > intCount && intSerialNumber <= intFinalCount)
                {
                    string strInHr = "";
                    string strNewChkIn = "";
                    string strOutHr = "";
                    string strNewChkOt = "";
                    string strChkInFormat = "";
                    string strChkOutFormat = "";


                    strHtml += "<tr id=\"Earow" + intSerialNumber + "\" >";
                    strHtml += "<td id=\"tdEaRowIndex" + intSerialNumber + "\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + intSerialNumber + "</td>";

                    string EmployeeID = objclsJSData.EMPID.ToString().Replace("<", string.Empty);
                    EmployeeID = EmployeeID.Replace(">", string.Empty);
                    strHtml += "<td id=\"tdEaEmpId" + intSerialNumber + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeID + "</td>";


                    string EmpFname = objclsJSData.EMPFNAME.Replace("<", string.Empty);
                    EmpFname = EmpFname.Replace(">", string.Empty);
                    strHtml += "<td id=\"tdEaEmpFName" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmpFname + "</td>";


                    string EmpLname = objclsJSData.EMPLNAME.Replace("<", string.Empty);
                    EmpLname = EmpLname.Replace(">", string.Empty);
                    strHtml += "<td id=\"tdEaEmpLName" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmpLname + "</td>";

                    if (objclsJSData.DATE.ToString() == "")
                    {
                        strHtml += "<td id=\"tdEaAttendDate" + intSerialNumber + "\" name=\"tdEaAttendDate" + intSerialNumber + "\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  ></td>";
                    }
                    else
                    {
                        DateTime AttendDate = objCommon.textToDateTime(objclsJSData.DATE);
                        strHtml += "<td id=\"tdEaAttendDate" + intSerialNumber + "\" name=\"tdEaAttendDate" + intSerialNumber + "\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + AttendDate.ToString("dd-MM-yyyy") + "</td>";
                    }

                    if (objclsJSData.CHECKIN.ToString() == "")
                    {
                        strChkInFormat = "";
                    }
                    else
                    {
                        string[] strsplitspceIn = Convert.ToString(objclsJSData.CHECKIN).Split(' ');
                        string[] strsplithrIn = strsplitspceIn[0].Split(':');
                        int intInHr = strsplithrIn[0].Length;
                        if (intInHr == 1)
                        {
                            strInHr = "0" + strsplithrIn[0];
                            strNewChkIn = objclsJSData.CHECKIN.Replace(strsplithrIn[0], strInHr);
                        }
                        else
                        {
                            strNewChkIn = objclsJSData.CHECKIN.ToString();
                        }
                        string strcheckin = Convert.ToString("01-01-1000 " + strNewChkIn);
                        //DateTime dtChkIn = objCommon.textWithTimeToDateTime(strcheckin);
                        //strChkInFormat = dtChkIn.ToString("HH:mm:ss tt"); //24 hr format
                    }
                    strHtml += "<td id=\"tdEaFirstCheckIn" + intSerialNumber + "\" name=\"tdEaFirstCheckIn" + intSerialNumber + "\"  style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strNewChkIn + "</td>";

                    if (objclsJSData.CHECKOUT == "")
                    {
                        strChkOutFormat = "";
                    }
                    else
                    {
                        string[] strsplitspceOt = Convert.ToString(objclsJSData.CHECKOUT).Split(' ');
                        string[] strsplithr = strsplitspceOt[0].Split(':');
                        int intOtHr = strsplithr[0].Length;
                        if (intOtHr == 1)
                        {
                            strOutHr = "0" + strsplithr[0];
                            strNewChkOt = objclsJSData.CHECKOUT.Replace(strsplithr[0], strOutHr);
                        }
                        else
                        {
                            strNewChkOt = objclsJSData.CHECKOUT.ToString();
                        }
                        string strcheckout = Convert.ToString("01-01-1000 " + strNewChkOt);
                        //DateTime dtChkOut = objCommon.textWithTimeToDateTime(strcheckout);
                        //strChkOutFormat = dtChkOut.ToString("HH:mm:ss tt");
                    }
                    strHtml += "<td id=\"tdEaLastCheckOut" + intSerialNumber + "\" name=\"tdEaLastCheckOut" + intSerialNumber + "\"   style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strNewChkOt + "</td>";

                    strHtml += "</tr>";
                }
            }
            strHtml += "</tbody>";

            strHtml += "</table>";



            sb.Append(strHtml);
            strOutput[0] = sb.ToString();
            strOutput[1] = intFinalCount.ToString();


        }
        return strOutput;
    }

    [WebMethod]
    public static string[] ServiceLateComeListToHtml(string strList, string strCount, string strMode, string strTotalCount)
    {
        string[] strOutput = new string[2];
        if (strList != "")
        {
            string jsonDataPW = strList;
            string R1PW = jsonDataPW.Replace("\"{", "\\{");
            string R2PW = R1PW.Replace("\\n", "\r\n");
            string R3PW = R2PW.Replace("\\", "");
            string R4PW = R3PW.Replace("}\"]", "}]");
            string R5PW = R4PW.Replace("}\",", "},");
            List<clsEmpAcesMgmtDtl> objWBDataPWList = new List<clsEmpAcesMgmtDtl>();
            objWBDataPWList = JsonConvert.DeserializeObject<List<clsEmpAcesMgmtDtl>>(R5PW);
            int intCount = Convert.ToInt32(strCount);
            int intFinalCount = 0;

            if (intCount < 100)
                intCount = 0;

            //strMode=1 for next and 0 for previous.
            if (strMode == "1")
            {
                intFinalCount = intCount + 100;
                if (intFinalCount > Convert.ToInt32(strTotalCount))
                    intFinalCount = Convert.ToInt32(strTotalCount);
            }
            else
            {
                if (intCount % 100 == 0)
                {
                    intFinalCount = intCount - 100;
                    intCount = intFinalCount - 100;
                    if (intCount < 0)
                        intCount = 0;
                }
                else
                {
                    intFinalCount = intCount - (intCount % 100);
                    intCount = intFinalCount - 100;
                    if (intCount < 0)
                        intCount = 0;
                }
            }


            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"LateEmpList\" class=\"tableCsv dataTable \" cellspacing=\"0\" cellpadding=\"2px\" style=\"width:100%;float:left;\">";
            //add rows
            int intSerialNumber = 0;
            strHtml += "<tbody>";

            foreach (clsEmpAcesMgmtDtl objclsJSData in objWBDataPWList)
            {


                intSerialNumber++;

                if (intSerialNumber > intCount && intSerialNumber <= intFinalCount)
                {
                    string strInHr = "";
                    string strNewChkIn = "";
                    string strOutHr = "";
                    string strNewChkOt = "";


                    strHtml += "<tr id=\"Larow" + intSerialNumber + "\" >";
                    strHtml += "<td id=\"tdLaRowIndex" + intSerialNumber + "\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + intSerialNumber + "</td>";

                    string EmployeeID = objclsJSData.EMPID.ToString().Replace("<", string.Empty);
                    EmployeeID = EmployeeID.Replace(">", string.Empty);
                    strHtml += "<td id=\"tdLaEmpId" + intSerialNumber + "\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmployeeID + "</td>";


                    string EmpFname = objclsJSData.EMPFNAME.Replace("<", string.Empty);
                    EmpFname = EmpFname.Replace(">", string.Empty);
                    strHtml += "<td id=\"tdLaEmpFName" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmpFname + "</td>";


                    string EmpLname = objclsJSData.EMPLNAME.Replace("<", string.Empty);
                    EmpLname = EmpLname.Replace(">", string.Empty);
                    strHtml += "<td id=\"tdLaEmpLName" + intSerialNumber + "\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + EmpLname + "</td>";

                    if (objclsJSData.DATE.ToString() == "")
                    {
                        strHtml += "<td id=\"tdLaAttendDate" + intSerialNumber + "\" name=\"tdLaAttendDate" + intSerialNumber + "\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  ></td>";
                    }
                    else
                    {
                        DateTime AttendDate = objCommon.textToDateTime(objclsJSData.DATE);
                        strHtml += "<td id=\"tdLaAttendDate" + intSerialNumber + "\" name=\"tdLaAttendDate" + intSerialNumber + "\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + AttendDate.ToString("dd-MM-yyyy") + "</td>";
                    }

                    if (objclsJSData.CHECKIN.ToString() == "")
                    {
                        strNewChkIn = "";
                    }
                    else
                    {
                        string[] strsplitspceIn = Convert.ToString(objclsJSData.CHECKIN).Split(' ');
                        string[] strsplithrIn = strsplitspceIn[0].Split(':');
                        int intInHr = strsplithrIn[0].Length;
                        if (intInHr == 1)
                        {
                            strInHr = "0" + strsplithrIn[0];
                            strNewChkIn = objclsJSData.CHECKIN.Replace(strsplithrIn[0], strInHr);
                        }
                        else
                        {
                            strNewChkIn = objclsJSData.CHECKIN.ToString();
                        }
                        //string strcheckin = Convert.ToString("01-01-1000 " + strNewChkIn);
                        //DateTime dtChkIn = objCommon.textWithTimeToDateTime(strcheckin);
                        //strChkInFormat = dtChkIn.ToString("HH:mm:ss tt"); //24 hr format
                    }
                    strHtml += "<td id=\"tdLaFirstCheckIn" + intSerialNumber + "\" name=\"tdLaFirstCheckIn" + intSerialNumber + "\"  style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strNewChkIn + "</td>";

                    if (objclsJSData.CHECKOUT == "")
                    {
                        strNewChkOt = "";
                    }
                    else
                    {
                        string[] strsplitspceOt = Convert.ToString(objclsJSData.CHECKOUT).Split(' ');
                        string[] strsplithr = strsplitspceOt[0].Split(':');
                        int intOtHr = strsplithr[0].Length;
                        if (intOtHr == 1)
                        {
                            strOutHr = "0" + strsplithr[0];
                            strNewChkOt = objclsJSData.CHECKOUT.Replace(strsplithr[0], strOutHr);
                        }
                        else
                        {
                            strNewChkOt = objclsJSData.CHECKOUT.ToString();
                        }
                        //string strcheckout = Convert.ToString("01-01-1000 " + strNewChkOt);
                        //DateTime dtChkOut = objCommon.textWithTimeToDateTime(strcheckout);
                        //strChkOutFormat = dtChkOut.ToString("HH:mm:ss tt");
                    }
                    strHtml += "<td id=\"tdLaLastCheckOut" + intSerialNumber + "\" name=\"tdLaLastCheckOut" + intSerialNumber + "\"   style=\" width:12.5%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strNewChkOt + "</td>";
                    strHtml += "<td style=\"display:none;background-color: #fcfff7;width:3%; word-break: break-all; word-wrap:break-word;text-align: center;padding:0px;height:20px;\">" + " <a  style=\"cursor:pointer;margin-top:-1.5%;opacity:1;margin-left:1%;z-index: 29;\" title=\"Cancel\" onclick='return DeleteRow(" + intSerialNumber + ");' >"
                                                   + "<img style=\"cursor: pointer; \" src='/Images/Icons/delete.png' /> " + "</a> </td>";

                    strHtml += "</tr>";
                }
            }
            strHtml += "</tbody>";

            strHtml += "</table>";

            sb.Append(strHtml);
            strOutput[0] = sb.ToString();
            strOutput[1] = intFinalCount.ToString();

        }
        return strOutput;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("hcm_Employee_Acees_Mgmt.aspx");
    }
    protected void btnOverWrite_Click(object sender, EventArgs e)
    {
        //SaveData();

    }


    public void SaveData()
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityEmplyeeAccessMgmt objEntityEmpAcsMgmt = new clsEntityEmplyeeAccessMgmt();
        clsBusinessEmpAcessMgmt objBusinessEmpAcsMgmt = new clsBusinessEmpAcessMgmt();



        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmpAcsMgmt.CorprtId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEmpAcsMgmt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (Session["USERID"] != null)
        {
            objEntityEmpAcsMgmt.UsrId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        string strCorrectDataList = HiddenCrctJsonListSave.Value;
        string[][] strCorrectDataArrayList = JsonConvert.DeserializeObject<string[][]>(strCorrectDataList);

        try
        {
            if (strCorrectDataArrayList != null)
            {
                int intRow = 1;
                string strInHr = "";
                string strNewChkIn = "";
                string strOutHr = "";
                string strNewChkOt = "";
                string strcheckout = "";
                string strcheckinn = "";
                string strcheckoutt = "";
                List<clsEntityEmplyeeAccessMgmt> objEntityEmpAcsMgmtList = new List<clsEntityEmplyeeAccessMgmt>();
                for (int intRowLoop = 0; intRowLoop < strCorrectDataArrayList.Length; intRowLoop++)
                {


                    bool flag = true;
                    string[] strarrCancldtlIds = HiddenCancelId.Value.Split(',');
                    foreach (string strDtlId in strarrCancldtlIds)
                    {
                        if (strDtlId == intRow.ToString())
                        {
                            flag = false;
                        }
                    }
                    if (flag == true)
                    {
                        clsEntityEmplyeeAccessMgmt ObjEmpAss = new clsEntityEmplyeeAccessMgmt();
                        ObjEmpAss.EmpId = strCorrectDataArrayList[intRowLoop][0];
                        ObjEmpAss.EmpFirstName = strCorrectDataArrayList[intRowLoop][1];
                        ObjEmpAss.EmpLastName = strCorrectDataArrayList[intRowLoop][2];
                        ObjEmpAss.AttendenceDate = objCommon.textToDateTime(strCorrectDataArrayList[intRowLoop][3]);
                        ObjEmpAss.InsertDate = objBusinessLayer.LoadCurrentDate();

                        string[] strsplitspceIn = Convert.ToString(strCorrectDataArrayList[intRowLoop][4]).Split(' ');
                        string[] strsplithrIn = strsplitspceIn[0].Split(':');
                        int intInHr = strsplithrIn[0].Length;
                        if (intInHr == 1)
                        {
                            strInHr = "0" + strsplithrIn[0];
                            strNewChkIn = strCorrectDataArrayList[intRowLoop][4].Replace(strsplithrIn[0], strInHr);
                        }
                        else
                        {
                            strNewChkIn = strCorrectDataArrayList[intRowLoop][4].ToString();
                        }
                        string strcheckin = Convert.ToString("01-01-1000 " + strNewChkIn);
                        DateTime dtChkIn = objCommon.textWithTimeToDateTime(strcheckin);
                        string strChkInFormat = dtChkIn.ToString("HH:mm:ss tt"); //24 hr format
                        strcheckinn = Convert.ToString("01-01-1000 " + strChkInFormat);

                        string[] strsplitspceOt = Convert.ToString(strCorrectDataArrayList[intRowLoop][5]).Split(' ');
                        string[] strsplithr = strsplitspceOt[0].Split(':');
                        int intOtHr = strsplithr[0].Length;
                        if (intOtHr == 1)
                        {
                            strOutHr = "0" + strsplithr[0];
                            strNewChkOt = strCorrectDataArrayList[intRowLoop][5].Replace(strsplithr[0], strOutHr);
                        }
                        else
                        {
                            strNewChkOt = strCorrectDataArrayList[intRowLoop][5].ToString();
                        }
                        strcheckout = Convert.ToString("01-01-1000 " + strNewChkOt);
                        DateTime dtChkOut = objCommon.textWithTimeToDateTime(strcheckout);
                        string strChkOutFormat = dtChkOut.ToString("HH:mm:ss tt");
                        strcheckoutt = Convert.ToString("01-01-1000 " + strChkOutFormat);

                        ObjEmpAss.FirstCheckIn = objCommon.textWithTimeToDateTime(strcheckinn);
                        ObjEmpAss.LastCheckOut = objCommon.textWithTimeToDateTime(strcheckoutt);
                        objEntityEmpAcsMgmtList.Add(ObjEmpAss);
                    }

                    intRow++;

                }

                objBusinessEmpAcsMgmt.InsertAttendenceSheet(objEntityEmpAcsMgmt, objEntityEmpAcsMgmtList);


            }

            string strEarlyGoDataList = HiddenEarlyJsonListSave.Value;
            string[][] strEarlyGoDataArrayList = JsonConvert.DeserializeObject<string[][]>(strEarlyGoDataList);

            if (strEarlyGoDataArrayList != null)
            {
                int intRow = 1;
                string strInHr = "";
                string strNewChkIn = "";
                string strOutHr = "";
                string strNewChkOt = "";
                string strcheckout = "";
                string strcheckinn = "";
                string strcheckoutt = "";
                List<clsEntityEmplyeeAccessMgmt> objEntityEmpAcsMgmtList = new List<clsEntityEmplyeeAccessMgmt>();
                for (int intRowLoop = 0; intRowLoop < strEarlyGoDataArrayList.Length; intRowLoop++)
                {


                    bool flag = true;
                    string[] strarrCancldtlIds = HiddenCancelId.Value.Split(',');
                    foreach (string strDtlId in strarrCancldtlIds)
                    {
                        if (strDtlId == intRow.ToString())
                        {
                            flag = false;
                        }
                    }
                    if (flag == true)
                    {
                        clsEntityEmplyeeAccessMgmt ObjEmpAss = new clsEntityEmplyeeAccessMgmt();
                        ObjEmpAss.EmpId = strEarlyGoDataArrayList[intRowLoop][0];
                        ObjEmpAss.EmpFirstName = strEarlyGoDataArrayList[intRowLoop][1];
                        ObjEmpAss.EmpLastName = strEarlyGoDataArrayList[intRowLoop][2];
                        ObjEmpAss.AttendenceDate = objCommon.textToDateTime(strEarlyGoDataArrayList[intRowLoop][3]);
                        ObjEmpAss.InsertDate = objBusinessLayer.LoadCurrentDate();

                        string[] strsplitspceIn = Convert.ToString(strEarlyGoDataArrayList[intRowLoop][4]).Split(' ');
                        string[] strsplithrIn = strsplitspceIn[0].Split(':');
                        int intInHr = strsplithrIn[0].Length;
                        if (intInHr == 1)
                        {
                            strInHr = "0" + strsplithrIn[0];
                            strNewChkIn = strEarlyGoDataArrayList[intRowLoop][4].Replace(strsplithrIn[0], strInHr);
                        }
                        else
                        {
                            strNewChkIn = strEarlyGoDataArrayList[intRowLoop][4].ToString();
                        }
                        string strcheckin = Convert.ToString("01-01-1000 " + strNewChkIn);
                        DateTime dtChkIn = objCommon.textWithTimeToDateTime(strcheckin);
                        string strChkInFormat = dtChkIn.ToString("HH:mm:ss tt"); //24 hr format
                        strcheckinn = Convert.ToString("01-01-1000 " + strChkInFormat);

                        string[] strsplitspceOt = Convert.ToString(strEarlyGoDataArrayList[intRowLoop][5]).Split(' ');
                        string[] strsplithr = strsplitspceOt[0].Split(':');
                        int intOtHr = strsplithr[0].Length;
                        if (intOtHr == 1)
                        {
                            strOutHr = "0" + strsplithr[0];
                            strNewChkOt = strEarlyGoDataArrayList[intRowLoop][5].Replace(strsplithr[0], strOutHr);
                        }
                        else
                        {
                            strNewChkOt = strEarlyGoDataArrayList[intRowLoop][5].ToString();
                        }
                        strcheckout = Convert.ToString("01-01-1000 " + strNewChkOt);
                        DateTime dtChkOut = objCommon.textWithTimeToDateTime(strcheckout);
                        string strChkOutFormat = dtChkOut.ToString("HH:mm:ss tt");
                        strcheckoutt = Convert.ToString("01-01-1000 " + strChkOutFormat);

                        ObjEmpAss.FirstCheckIn = objCommon.textWithTimeToDateTime(strcheckinn);
                        ObjEmpAss.LastCheckOut = objCommon.textWithTimeToDateTime(strcheckoutt);

                        ObjEmpAss.Status = 1;
                        objEntityEmpAcsMgmtList.Add(ObjEmpAss);
                    }

                    intRow++;

                }

                objBusinessEmpAcsMgmt.InsertIncorrectAttendenceSheet(objEntityEmpAcsMgmt, objEntityEmpAcsMgmtList);
            }

            string strLateComeDataList = HiddenLateComeJsonListSave.Value;
            string[][] strLateComeDataArrayList = JsonConvert.DeserializeObject<string[][]>(strLateComeDataList);

            if (strLateComeDataArrayList != null)
            {
                int intRow = 1;
                string strInHr = "";
                string strNewChkIn = "";
                string strOutHr = "";
                string strNewChkOt = "";
                string strcheckout = "";
                string strcheckinn = "";
                string strcheckoutt = "";
                List<clsEntityEmplyeeAccessMgmt> objEntityEmpAcsMgmtList = new List<clsEntityEmplyeeAccessMgmt>();
                for (int intRowLoop = 0; intRowLoop < strLateComeDataArrayList.Length; intRowLoop++)
                {


                    bool flag = true;
                    string[] strarrCancldtlIds = HiddenCancelId.Value.Split(',');
                    foreach (string strDtlId in strarrCancldtlIds)
                    {
                        if (strDtlId == intRow.ToString())
                        {
                            flag = false;
                        }
                    }
                    if (flag == true)
                    {
                        clsEntityEmplyeeAccessMgmt ObjEmpAss = new clsEntityEmplyeeAccessMgmt();
                        ObjEmpAss.EmpId = strLateComeDataArrayList[intRowLoop][0];
                        ObjEmpAss.EmpFirstName = strLateComeDataArrayList[intRowLoop][1];
                        ObjEmpAss.EmpLastName = strLateComeDataArrayList[intRowLoop][2];
                        ObjEmpAss.AttendenceDate = objCommon.textToDateTime(strLateComeDataArrayList[intRowLoop][3]);
                        ObjEmpAss.InsertDate = objBusinessLayer.LoadCurrentDate();

                        string[] strsplitspceIn = Convert.ToString(strLateComeDataArrayList[intRowLoop][4]).Split(' ');
                        string[] strsplithrIn = strsplitspceIn[0].Split(':');
                        int intInHr = strsplithrIn[0].Length;
                        if (intInHr == 1)
                        {
                            strInHr = "0" + strsplithrIn[0];
                            strNewChkIn = strLateComeDataArrayList[intRowLoop][4].Replace(strsplithrIn[0], strInHr);
                        }
                        else
                        {
                            strNewChkIn = strLateComeDataArrayList[intRowLoop][4].ToString();
                        }
                        string strcheckin = Convert.ToString("01-01-1000 " + strNewChkIn);
                        DateTime dtChkIn = objCommon.textWithTimeToDateTime(strcheckin);
                        string strChkInFormat = dtChkIn.ToString("HH:mm:ss tt"); //24 hr format
                        strcheckinn = Convert.ToString("01-01-1000 " + strChkInFormat);

                        string[] strsplitspceOt = Convert.ToString(strLateComeDataArrayList[intRowLoop][5]).Split(' ');
                        string[] strsplithr = strsplitspceOt[0].Split(':');
                        int intOtHr = strsplithr[0].Length;
                        if (intOtHr == 1)
                        {
                            strOutHr = "0" + strsplithr[0];
                            strNewChkOt = strLateComeDataArrayList[intRowLoop][5].Replace(strsplithr[0], strOutHr);
                        }
                        else
                        {
                            strNewChkOt = strLateComeDataArrayList[intRowLoop][5].ToString();
                        }
                        strcheckout = Convert.ToString("01-01-1000 " + strNewChkOt);
                        DateTime dtChkOut = objCommon.textWithTimeToDateTime(strcheckout);
                        string strChkOutFormat = dtChkOut.ToString("HH:mm:ss tt");
                        strcheckoutt = Convert.ToString("01-01-1000 " + strChkOutFormat);

                        ObjEmpAss.FirstCheckIn = objCommon.textWithTimeToDateTime(strcheckinn);
                        ObjEmpAss.LastCheckOut = objCommon.textWithTimeToDateTime(strcheckoutt);

                        ObjEmpAss.Status = 2;
                        objEntityEmpAcsMgmtList.Add(ObjEmpAss);
                    }

                    intRow++;

                }

                objBusinessEmpAcsMgmt.InsertIncorrectAttendenceSheet(objEntityEmpAcsMgmt, objEntityEmpAcsMgmtList);
            }


            string strMissingDataList = HiddenMissingData.Value;
            string[][] strMissingDataArrayList = JsonConvert.DeserializeObject<string[][]>(strMissingDataList);

            if (strMissingDataArrayList != null)
            {
                int intRow = 1;
                string strInHr = "";
                string strNewChkIn = "";
                string strOutHr = "";
                string strNewChkOt = "";
                string strcheckout = "";
                string strcheckinn = "";
                string strcheckoutt = "";
                List<clsEntityEmplyeeAccessMgmt> objEntityEmpAcsMgmtList = new List<clsEntityEmplyeeAccessMgmt>();
                for (int intRowLoop = 0; intRowLoop < strMissingDataArrayList.Length; intRowLoop++)
                {


                    bool flag = true;
                    string[] strarrCancldtlIds = HiddenCancelId.Value.Split(',');
                    foreach (string strDtlId in strarrCancldtlIds)
                    {
                        if (strDtlId == intRow.ToString())
                        {
                            flag = false;
                        }
                    }
                    if (flag == true)
                    {
                        clsEntityEmplyeeAccessMgmt ObjEmpAss = new clsEntityEmplyeeAccessMgmt();
                        ObjEmpAss.EmpId = strMissingDataArrayList[intRowLoop][0];
                        ObjEmpAss.EmpFirstName = strMissingDataArrayList[intRowLoop][1];
                        ObjEmpAss.EmpLastName = strMissingDataArrayList[intRowLoop][2];
                        ObjEmpAss.AttendenceDate = objCommon.textToDateTime(strMissingDataArrayList[intRowLoop][3]);
                        ObjEmpAss.InsertDate = objBusinessLayer.LoadCurrentDate();

                        if (strMissingDataArrayList[intRowLoop][4] != "")
                        {
                            string[] strsplitspceIn = Convert.ToString(strMissingDataArrayList[intRowLoop][4]).Split(' ');
                            string[] strsplithrIn = strsplitspceIn[0].Split(':');
                            int intInHr = strsplithrIn[0].Length;
                            if (intInHr == 1)
                            {
                                strInHr = "0" + strsplithrIn[0];
                                strNewChkIn = strMissingDataArrayList[intRowLoop][4].Replace(strsplithrIn[0], strInHr);
                            }
                            else
                            {
                                strNewChkIn = strMissingDataArrayList[intRowLoop][4].ToString();
                            }

                            string strcheckin = Convert.ToString("01-01-1000 " + strNewChkIn);
                            DateTime dtChkIn = objCommon.textWithTimeToDateTime(strcheckin);
                            string strChkInFormat = dtChkIn.ToString("HH:mm:ss tt"); //24 hr format
                            strcheckinn = Convert.ToString("01-01-1000 " + strChkInFormat);

                            ObjEmpAss.FirstCheckIn = objCommon.textWithTimeToDateTime(strcheckinn);
                        }

                        if (strMissingDataArrayList[intRowLoop][5] != "")
                        {
                            string[] strsplitspceOt = Convert.ToString(strMissingDataArrayList[intRowLoop][5]).Split(' ');
                            string[] strsplithr = strsplitspceOt[0].Split(':');
                            int intOtHr = strsplithr[0].Length;
                            if (intOtHr == 1)
                            {
                                strOutHr = "0" + strsplithr[0];
                                strNewChkOt = strMissingDataArrayList[intRowLoop][5].Replace(strsplithr[0], strOutHr);
                            }
                            else
                            {
                                strNewChkOt = strMissingDataArrayList[intRowLoop][5].ToString();
                            }
                            strcheckout = Convert.ToString("01-01-1000 " + strNewChkOt);
                            DateTime dtChkOut = objCommon.textWithTimeToDateTime(strcheckout);
                            string strChkOutFormat = dtChkOut.ToString("HH:mm:ss tt");
                            strcheckoutt = Convert.ToString("01-01-1000 " + strChkOutFormat);
                            ObjEmpAss.LastCheckOut = objCommon.textWithTimeToDateTime(strcheckoutt);
                        }



                        ObjEmpAss.Status = 3;
                        objEntityEmpAcsMgmtList.Add(ObjEmpAss);
                    }

                    intRow++;

                }

                objBusinessEmpAcsMgmt.InsertIncorrectAttendenceSheet(objEntityEmpAcsMgmt, objEntityEmpAcsMgmtList);


            }


            string strDupDataList = HiddenDupJsonListSave.Value;
            string[][] strDupDataArrayList = JsonConvert.DeserializeObject<string[][]>(strDupDataList);
            if (strDupDataArrayList != null)
            {
                string strInHr = "";
                string strNewChkIn = "";
                string strOutHr = "";
                string strNewChkOt = "";
                string strcheckout = "";
                string strcheckinn = "";
                string strcheckoutt = "";
                List<clsEntityEmplyeeAccessMgmt> objEntityEmpAcsMgmtList = new List<clsEntityEmplyeeAccessMgmt>();



                string ReplaceduplicatedRowId = HiddenDupRows.Value;

                if (ReplaceduplicatedRowId != "")
                {
                    string[] DupRowArr = ReplaceduplicatedRowId.Split(',');

                    foreach (string DupRowId in DupRowArr)
                    {

                        if (DupRowId != "")
                        {
                            int intRowLoop = Convert.ToInt32(DupRowId);
                            clsEntityEmplyeeAccessMgmt ObjEmpAss = new clsEntityEmplyeeAccessMgmt();
                            ObjEmpAss.EmpId = strDupDataArrayList[intRowLoop][0];
                            ObjEmpAss.EmpFirstName = strDupDataArrayList[intRowLoop][1];
                            ObjEmpAss.EmpLastName = strDupDataArrayList[intRowLoop][2];
                            ObjEmpAss.AttendenceDate = objCommon.textToDateTime(strDupDataArrayList[intRowLoop][3]);
                            ObjEmpAss.InsertDate = objBusinessLayer.LoadCurrentDate();

                            string[] strsplitspceIn = Convert.ToString(strDupDataArrayList[intRowLoop][4]).Split(' ');
                            string[] strsplithrIn = strsplitspceIn[0].Split(':');
                            int intInHr = strsplithrIn[0].Length;
                            if (intInHr == 1)
                            {
                                strInHr = "0" + strsplithrIn[0];
                                strNewChkIn = strDupDataArrayList[intRowLoop][4].Replace(strsplithrIn[0], strInHr);
                            }
                            else
                            {
                                strNewChkIn = strDupDataArrayList[intRowLoop][4].ToString();
                            }
                            string strcheckin = Convert.ToString("01-01-1000 " + strNewChkIn);
                            DateTime dtChkIn = objCommon.textWithTimeToDateTime(strcheckin);
                            string strChkInFormat = dtChkIn.ToString("HH:mm:ss tt"); //24 hr format
                            strcheckinn = Convert.ToString("01-01-1000 " + strChkInFormat);

                            string[] strsplitspceOt = Convert.ToString(strDupDataArrayList[intRowLoop][5]).Split(' ');
                            string[] strsplithr = strsplitspceOt[0].Split(':');
                            int intOtHr = strsplithr[0].Length;
                            if (intOtHr == 1)
                            {
                                strOutHr = "0" + strsplithr[0];
                                strNewChkOt = strDupDataArrayList[intRowLoop][5].Replace(strsplithr[0], strOutHr);
                            }
                            else
                            {
                                strNewChkOt = strDupDataArrayList[intRowLoop][5].ToString();
                            }
                            strcheckout = Convert.ToString("01-01-1000 " + strNewChkOt);
                            DateTime dtChkOut = objCommon.textWithTimeToDateTime(strcheckout);
                            string strChkOutFormat = dtChkOut.ToString("HH:mm:ss tt");
                            strcheckoutt = Convert.ToString("01-01-1000 " + strChkOutFormat);

                            ObjEmpAss.FirstCheckIn = objCommon.textWithTimeToDateTime(strcheckinn);
                            ObjEmpAss.LastCheckOut = objCommon.textWithTimeToDateTime(strcheckoutt);

                            ObjEmpAss.Status = 1;
                            objEntityEmpAcsMgmtList.Add(ObjEmpAss);
                        }
                    }

                    objBusinessEmpAcsMgmt.UpdateDuplicateAttendenceSheet(objEntityEmpAcsMgmt, objEntityEmpAcsMgmtList);
                }

            }

           
            //ScriptManager.RegisterStartupScript(this, GetType(), "AddSuccesMessage", "AddSuccesMessage();", true);
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "ShowError", "ShowError();", true);
        }

        Response.Redirect("hcm_Employee_Acees_Mgmt.aspx?InsUpd=Ins");
    }
}