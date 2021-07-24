using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using System.Text;
using CL_Compzit;
using System.Collections;
using System.IO;
using MailUtility_ERP;
using System.Web.Script.Serialization;
using System.Web.Services;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

// CREATED BY:EVM-0002
// CREATED DATE:24/03/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Transaction_gen_Product_Rate_Amendment_gen_Product_Rate_Amendment : System.Web.UI.Page
{
     //Creating objects for businesslayer
    clsBusinessLayerCustomerGroup objBusinessLayerCustmrGrp = new clsBusinessLayerCustomerGroup();
    clsBusinessLayerProductRateAmendment objBusinessLayerRateUpdate = new clsBusinessLayerProductRateAmendment();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {


            if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");               
            }
            else
            {
                HiddenUserId.Value = Session["USERID"].ToString();
            }

            if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                HiddenOrgId.Value = Session["ORGID"].ToString();
            }

            if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            }

            FileUploader.Focus();

            //when editing 
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Upd")
                {
                   
                }
                else if (strInsUpd == "Err")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMessage", "ErrorMessage();", true);
                }
            }
        }
    }

 
    //when submit button is clicked
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityProductRateAmendment objEntityRateAmendment = new clsEntityProductRateAmendment();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityRateAmendment.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityRateAmendment.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (Session["USERID"] != null)
        {
            objEntityRateAmendment.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityRateAmendment.D_Date = System.DateTime.Now;

        //read divisions based on user id
        DataTable dtDivisions = objBusinessLayerRateUpdate.Read_Divisions(objEntityRateAmendment);

        if (dtDivisions.Rows.Count == 0)
            dtDivisions = objBusinessLayerRateUpdate.Read_All_Divisions(objEntityRateAmendment);

        //fill divisions to the drop down list
        FillDivision(dtDivisions);

        string strFilePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Rate_Amendment);

        //for delete all the files in the specific folder.
        Array.ForEach(Directory.GetFiles(Server.MapPath(strFilePath)), File.Delete);

        if (FileUploader.HasFile)
        {
            FileUploader.SaveAs(Server.MapPath(strFilePath) + FileUploader.PostedFile.FileName);
        }

        string strData = Server.MapPath(strFilePath) + "/" + FileUploader.PostedFile.FileName;
        try
        {
            var OuterLines = new List<string[]>();
            var CodeCorrectList = new List<string[]>();
            var CodeMissingList = new List<string[]>();
            var CodeIncorrectList = new List<string[]>();
            var CodeDuplicateList = new List<string[]>();
            var NameMissingList = new List<string[]>();
            var NameDuplicateList = new List<string[]>();
            var RateMissingList = new List<string[]>();
            var ItemCreateList = new List<string[]>();
            var ExceedLengthItem = new List<string[]>();
            bool blHeader = false;

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

                    OuterLines.Add(Line);
                rowOuter: ;
                }

            }

            var OuterLinesCopy = new List<string[]>(OuterLines);
            OuterLinesCopy = OuterLines.ToList();

            //checking missing product code
            for (int intRow = OuterLinesCopy.Count - 1; intRow >= 0; intRow--)
            {
                if (OuterLinesCopy[intRow][0] == null || OuterLinesCopy[intRow][0] == "")
                {
                    CodeMissingList.Add(OuterLinesCopy[intRow]);
                    if (OuterLines.Count >= intRow)
                        OuterLines.RemoveAt(intRow);

                }
            }

            OuterLinesCopy = OuterLines.ToList();
            //checking duplicate product code inside the uploaded file
            for (int intRow = OuterLinesCopy.Count - 1; intRow >= 0; intRow--)
            {
                if (OuterLinesCopy.Count > intRow)
                {
                    string strProductCode = OuterLinesCopy[intRow][0].ToString();
                    for (int intSecondRow = OuterLines.Count - 1; intSecondRow >= 0; intSecondRow--)
                    {
                        if (intRow != intSecondRow)
                        {
                            if (strProductCode == OuterLines[intSecondRow][0].ToString())
                            {
                                if (OuterLines.Count > intRow)
                                {
                                    CodeDuplicateList.Add(OuterLines[intSecondRow]);
                                    OuterLines.RemoveAt(intSecondRow);
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                }
            }

            //checking again duplication of product code in the list
            var CodeDuplicateListCopy = new List<string[]>(CodeDuplicateList);
            CodeDuplicateListCopy = CodeDuplicateList.ToList();

            for (int intRow = CodeDuplicateListCopy.Count - 1; intRow >= 0; intRow--)
            {
                if (CodeDuplicateListCopy.Count > intRow)
                {
                    string strProductCode = CodeDuplicateListCopy[intRow][0].ToString();
                    for (int intSecondRow = OuterLines.Count - 1; intSecondRow >= 0; intSecondRow--)
                    {

                        if (strProductCode == OuterLines[intSecondRow][0].ToString())
                        {
                            if (OuterLines.Count > intRow)
                            {
                                CodeDuplicateList.Add(OuterLines[intSecondRow]);
                                OuterLines.RemoveAt(intSecondRow);
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }


            //checking the product code is exist or not in the product master table
            for (int intRow = OuterLines.Count - 1; intRow >= 0; intRow--)
            {
                objEntityRateAmendment.Product_Ext_Code = OuterLines[intRow][0].ToString();
                objEntityRateAmendment.Product_Ext_Code = objEntityRateAmendment.Product_Ext_Code.ToUpper();
                //removing tags
                objEntityRateAmendment.Product_Ext_Code = objEntityRateAmendment.Product_Ext_Code.ToString().Replace("<", string.Empty);
                objEntityRateAmendment.Product_Ext_Code = objEntityRateAmendment.Product_Ext_Code.ToString().Replace(">", string.Empty);
                string strCount = objBusinessLayerRateUpdate.CheckProductCode(objEntityRateAmendment);
                //if not exist
                if (strCount == "0")
                {
                    CodeIncorrectList.Add(OuterLines[intRow]);
                }
                else
                {
                    CodeCorrectList.Add(OuterLines[intRow]);
                }
            }

            var CodeCorrectListCopy = new List<string[]>(CodeCorrectList);
            CodeCorrectListCopy = CodeCorrectList.ToList();

            //checking the missed product rate and non numeric product rate
            for (int intRow = CodeCorrectListCopy.Count - 1; intRow >= 0; intRow--)
            {
                if (CodeCorrectListCopy[intRow].Length > 1)
                {
                    if (CodeCorrectListCopy[intRow].Length > 2)
                    {
                        if (CodeCorrectListCopy[intRow][2].ToString() == "" || CodeCorrectListCopy[intRow][2] == null)
                        {
                            RateMissingList.Add(CodeCorrectListCopy[intRow]);
                            CodeCorrectList.RemoveAt(intRow);
                        }
                        else
                        {
                            CodeCorrectListCopy[intRow][2] = CodeCorrectListCopy[intRow][2].ToString().Replace("<", string.Empty);
                            CodeCorrectListCopy[intRow][2] = CodeCorrectListCopy[intRow][2].ToString().Replace(">", string.Empty);
                            int intValue;
                            decimal decValue;
                            bool isNumeric = int.TryParse(CodeCorrectListCopy[intRow][2].ToString(), out intValue);
                            bool isDecimal = Decimal.TryParse(CodeCorrectListCopy[intRow][2].ToString(), out decValue);
                            if (isNumeric == false && isDecimal == false)
                            {
                                RateMissingList.Add(CodeCorrectListCopy[intRow]);
                                CodeCorrectList.RemoveAt(intRow);
                            }
                            else
                            {
                                string strCostPrice = CodeCorrectListCopy[intRow][2].ToString();
                                if (strCostPrice.Length > 17)
                                {
                                    RateMissingList.Add(CodeCorrectListCopy[intRow]);
                                    CodeCorrectList.RemoveAt(intRow);
                                }
                                else
                                {
                                    string[] strPrice = strCostPrice.Split('.');
                                    string strDigits = strPrice[0];
                                    if (strDigits.Length > 11)
                                    {
                                        RateMissingList.Add(CodeCorrectListCopy[intRow]);
                                        CodeCorrectList.RemoveAt(intRow);
                                    }
                                    else
                                    {
                                        if (strPrice.Length > 1)
                                        {
                                            strDigits = strPrice[1];
                                            if (strDigits.Length > 6)
                                            {
                                                int intDigitLength = strDigits.Length;
                                                intDigitLength = intDigitLength - 6;
                                                CodeCorrectList[intRow][2] = CodeCorrectList[intRow][2].ToString().Remove(CodeCorrectList[intRow][2].ToString().Length - intDigitLength);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        RateMissingList.Add(CodeCorrectListCopy[intRow]);
                        CodeCorrectList.RemoveAt(intRow);
                    }
                }
                else
                {
                    RateMissingList.Add(CodeCorrectListCopy[intRow]);
                    CodeCorrectList.RemoveAt(intRow);
                }
            }

            //checking duplication on the incorrect product code list and remove the same from the list
            for (int intRow = CodeIncorrectList.Count - 1; intRow >= 0; intRow--)
            {
                if (CodeIncorrectList.Count > intRow)
                {
                    string strProductCode = CodeIncorrectList[intRow][0].ToString().ToUpper();
                    //removing tags
                    strProductCode = strProductCode.ToString().Replace("<", string.Empty);
                    strProductCode = strProductCode.ToString().Replace(">", string.Empty);
                    for (int intSecondRow = CodeIncorrectList.Count - 1; intSecondRow >= 0; intSecondRow--)
                    {
                        if (intRow != intSecondRow)
                        {
                            if (CodeIncorrectList.Count > intSecondRow)
                            {
                                string strSecondCode = CodeIncorrectList[intSecondRow][0].ToString().ToUpper();
                                strSecondCode = strSecondCode.ToString().Replace("<", string.Empty);
                                strSecondCode = strSecondCode.ToString().Replace(">", string.Empty);

                                if (strProductCode == strSecondCode)
                                {
                                    CodeIncorrectList.RemoveAt(intSecondRow);
                                }
                            }
                        }
                    }
                }
            }


            //assigning the records have missing product code
            CodeMissingList.Reverse();
            HiddenCodeMissingCount.Value = CodeMissingList.Count.ToString();
            if (CodeMissingList.Count < 101)
            {
                btnMissingCodeNextRecords.Enabled = false;
                btnMissingCodeNextRecordsB.Enabled = false;
                string strCodeMissingHtml = CovertListToHTML(CodeMissingList);
                divMissingCodeReport.InnerHtml = strCodeMissingHtml;
            }
            else
            {
                btnMissingCodeNextRecords.Enabled = true;
                btnMissingCodeNextRecordsB.Enabled = true;
                string strCodeMissingJson = ConvertArrayToJson(CodeMissingList);
                HiddenCodeMissingList.Value = strCodeMissingJson;
                var NewCodeMissingList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    NewCodeMissingList.Add(CodeMissingList[intRow]);
                }
                HiddenCodeMissingNext.Value = "100";
                string strCodeMissingHtml = CovertListToHTML(NewCodeMissingList);
                divMissingCodeReport.InnerHtml = strCodeMissingHtml;
            }

            //the records have duplicate product code
            CodeDuplicateList.Reverse();
            HiddenCodeDuplicateCount.Value = CodeDuplicateList.Count.ToString();
            if (CodeDuplicateList.Count < 100)
            {
                btnDuplicationCodeNextRecords.Enabled = false;
                btnDuplicationCodeNextRecordsB.Enabled = false;
                string strDuplicateCode = CovertListToHTML(CodeDuplicateList);
                divDuplicationCodeReport.InnerHtml = strDuplicateCode;
            }
            else
            {
                btnDuplicationCodeNextRecords.Enabled = true;
                btnDuplicationCodeNextRecordsB.Enabled = true;
                string strCodeDuplicateJson = ConvertArrayToJson(CodeDuplicateList);
                HiddenCodeDuplicateList.Value = strCodeDuplicateJson;
                var NewCodeDuplicateList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    NewCodeDuplicateList.Add(CodeDuplicateList[intRow]);
                }
                HiddenCodeDuplicateNext.Value = "100";
                string strCodeDuplicateHtml = CovertListToHTML(NewCodeDuplicateList);
                divDuplicationCodeReport.InnerHtml = strCodeDuplicateHtml;
            }
            //the records have mismatch product code with product master
            CodeIncorrectList.Reverse();
            HiddenCodeMismatchcount.Value = CodeIncorrectList.Count.ToString();
            if (CodeIncorrectList.Count < 100)
            {
                btnMismatchCodeNextRecords.Enabled = false;
                btnMismatchCodeNextRecordsB.Enabled = false;
                string strMismatchCode = CovertListToHTML(CodeIncorrectList);
                divMismatchCodeReport.InnerHtml = strMismatchCode;
            }
            else
            {
                btnMismatchCodeNextRecords.Enabled = true;
                btnMismatchCodeNextRecordsB.Enabled = true;
                string strCodeMismatchJson = ConvertArrayToJson(CodeIncorrectList);
                HiddenCodeMismatchList.Value = strCodeMismatchJson;
                var NewCodeMismatchList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    NewCodeMismatchList.Add(CodeIncorrectList[intRow]);
                }
                HiddenCodeMismatchNext.Value = "100";
                string strCodeMismatchHtml = CovertListToHTML(NewCodeMismatchList);
                divMismatchCodeReport.InnerHtml = strCodeMismatchHtml;
            }

            //checking the missing item name from item create list
            var CodeIncorrectListCopy = new List<string[]>(CodeIncorrectList);
            CodeIncorrectListCopy = CodeIncorrectList.ToList();

            for (int intRow = CodeIncorrectListCopy.Count - 1; intRow >= 0; intRow--)
            {
                if (CodeIncorrectListCopy[intRow].Length > 1)
                {
                    if (CodeIncorrectListCopy[intRow][1] == null || CodeIncorrectListCopy[intRow][1] == "")
                    {
                        if (CodeIncorrectList.Count > intRow)
                        {
                            NameMissingList.Add(CodeIncorrectList[intRow]);
                            CodeIncorrectList.RemoveAt(intRow);
                        }
                    }
                }
            }
            int intFirstLoop = 0;
            int intSecondLoop = 0;
                //checking the item name duplication on item create list
                CodeIncorrectListCopy = CodeIncorrectList.ToList();
                for (int intRow = CodeIncorrectList.Count - 1; intRow >= 0; intRow--)
                {
                    intFirstLoop = intRow;
                    if (CodeIncorrectList.Count > intRow)
                    {
                        if (CodeIncorrectList[intRow].Length > 1)
                        {
                            string strProductName = CodeIncorrectList[intRow][1].ToString().ToUpper();
                            //removing tags
                            strProductName = strProductName.ToString().Replace("<", string.Empty);
                            strProductName = strProductName.ToString().Replace(">", string.Empty);
                            for (int intSecondRow = CodeIncorrectList.Count - 1; intSecondRow >= 0; intSecondRow--)
                            {
                                intSecondLoop = intSecondRow;
                                if (intRow != intSecondRow)
                                {
                                    if (CodeIncorrectList.Count > intSecondRow)
                                    {
                                        if (CodeIncorrectList[intSecondRow].Length > 1)
                                        {
                                            string strSecondProductName = CodeIncorrectList[intSecondRow][1].ToString().ToUpper();
                                            strSecondProductName = strSecondProductName.ToString().Replace("<", string.Empty);
                                            strSecondProductName = strSecondProductName.ToString().Replace(">", string.Empty);
                                            if (strSecondProductName == strProductName)
                                            {
                                                if (CodeIncorrectList.Count > intSecondRow)
                                                {
                                                    NameDuplicateList.Add(CodeIncorrectList[intSecondRow]);
                                                    CodeIncorrectList.RemoveAt(intSecondRow);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            CodeIncorrectListCopy = CodeIncorrectList.ToList(); ;
            //checking item name duplicate in the database or not
            for (int intRow = CodeIncorrectListCopy.Count - 1; intRow >= 0; intRow--)
            {
                if (CodeIncorrectListCopy[intRow].Length > 1)
                {
                    objEntityRateAmendment.Product_Name = CodeIncorrectListCopy[intRow][1].ToString().ToUpper();
                    //removing tags
                    objEntityRateAmendment.Product_Name = objEntityRateAmendment.Product_Name.ToString().Replace("<", string.Empty);
                    objEntityRateAmendment.Product_Name = objEntityRateAmendment.Product_Name.ToString().Replace(">", string.Empty);
                    string strCount = objBusinessLayerRateUpdate.CheckProductName(objEntityRateAmendment);
                    if (strCount == "0") { }
                    else
                    {
                        if (CodeIncorrectList.Count > intRow)
                        {
                            NameDuplicateList.Add(CodeIncorrectList[intRow]);
                            CodeIncorrectList.RemoveAt(intRow);
                        }
                    }
                }
            }

            //after both filteration making item creation list
            ItemCreateList = CodeIncorrectList;

            var ItemCreateListCopy = new List<string[]>(ItemCreateList);
            ItemCreateListCopy = ItemCreateList.ToList();
            //checking the length of each field
            for (int intRow = ItemCreateListCopy.Count - 1; intRow >= 0; intRow--)
            {
                //checking product code length
                if (ItemCreateListCopy[intRow][0] != null && ItemCreateListCopy[intRow][0] != "")
                {
                    if (ItemCreateListCopy[intRow][0].ToString().Length > 25)
                    {
                        ItemCreateList.RemoveAt(intRow);
                        ExceedLengthItem.Add(ItemCreateListCopy[intRow]);
                    }
                    else
                    {
                        if (ItemCreateListCopy[intRow].Length > 1)
                        {
                            //checking product code name
                            if (ItemCreateListCopy[intRow][1] != null && ItemCreateListCopy[intRow][1] != "")
                            {
                                if (ItemCreateListCopy[intRow][1].ToString().Length > 150)
                                {
                                    ItemCreateList.RemoveAt(intRow);
                                    ExceedLengthItem.Add(ItemCreateListCopy[intRow]);
                                }
                                else
                                {
                                    if (ItemCreateListCopy[intRow].Length > 2)
                                    {

                                        //checking product code code
                                        if (ItemCreateListCopy[intRow][2] != null && ItemCreateListCopy[intRow][2] != "")
                                        {
                                            if (ItemCreateListCopy[intRow][2].ToString().Length > 17)
                                            {
                                                //check the decimal places count
                                                decimal decCostPrice = 0;
                                                bool isDecimal = Decimal.TryParse(ItemCreateListCopy[intRow][2].ToString(), out decCostPrice);
                                                if (isDecimal == true)
                                                {
                                                    string strCostPrice = ItemCreateListCopy[intRow][2].ToString();
                                                    string[] strPrice = strCostPrice.Split('.');

                                                    string strDigits = strPrice[0];
                                                    if (strDigits.Length > 11)
                                                    {
                                                        ItemCreateList.RemoveAt(intRow);
                                                        ExceedLengthItem.Add(ItemCreateListCopy[intRow]);
                                                    }
                                                    else
                                                    {
                                                        if (strDigits.Length > 6)
                                                        {
                                                            strDigits = strPrice[1];
                                                            if (strDigits.Length > 6)
                                                            {
                                                                ItemCreateList.RemoveAt(intRow);
                                                                ExceedLengthItem.Add(ItemCreateListCopy[intRow]);
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    ItemCreateList.RemoveAt(intRow);
                                                    ExceedLengthItem.Add(ItemCreateListCopy[intRow]);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            var NewItemCreateList = new List<string[]>();
            NewItemCreateList = ListRemoveTags(ItemCreateList);
            ItemCreateList = NewItemCreateList.ToList();
            ItemCreateList.Reverse();
            string strItemCreate = ConvertArrayToJson(ItemCreateList);
            HiddenItemCreateList.Value = strItemCreate;
            HiddenNewProductsCount.Value = ItemCreateList.Count.ToString();

            //filling missing item name to the table
            NameMissingList.Reverse();
            HiddenNameMissingCount.Value = NameMissingList.Count.ToString();
            if (NameMissingList.Count < 100)
            {
                btnNameMissingNextRecords.Enabled = false;
                btnNameMissingNextRecordsB.Enabled = false;
                string strMissingName = CovertListToHTML(NameMissingList);
                divProductNameMissingReport.InnerHtml = strMissingName;
            }
            else
            {
                btnNameMissingNextRecords.Enabled = true;
                btnNameMissingNextRecordsB.Enabled = true;
                string strNameMissingJson = ConvertArrayToJson(NameMissingList);
                HiddenNameMissingList.Value = strNameMissingJson;
                var NewNameMissingList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    NewNameMissingList.Add(NameMissingList[intRow]);
                }
                HiddenNameMissingNext.Value = "100";
                string strNameMissingHtml = CovertListToHTML(NewNameMissingList);
                divProductNameMissingReport.InnerHtml = strNameMissingHtml;
            }

            //filling duplicate item name to the table
            NameDuplicateList.Reverse();
            HiddenNameDuplicateCount.Value = NameDuplicateList.Count.ToString();
            if (NameDuplicateList.Count < 100)
            {
                btnNameDuplicateNextRecords.Enabled = false;
                btnNameDuplicateNextRecordsB.Enabled = false;
                string strDuplicateName = CovertListToHTML(NameDuplicateList);
                divProductNameDuplicateReport.InnerHtml = strDuplicateName;
            }
            else
            {
                btnNameDuplicateNextRecords.Enabled = true;
                btnNameDuplicateNextRecordsB.Enabled = true;
                string strNameDuplicateJson = ConvertArrayToJson(NameDuplicateList);
                HiddenNameDuplicateList.Value = strNameDuplicateJson;
                var NewNameDuplicateList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    NewNameDuplicateList.Add(NameDuplicateList[intRow]);
                }
                HiddenNameDuplicateNext.Value = "100";
                string strNameDuplicateHtml = CovertListToHTML(NewNameDuplicateList);
                divProductNameDuplicateReport.InnerHtml = strNameDuplicateHtml;
            }

            //filling exceed length records to the table
            ExceedLengthItem.Reverse();
            HiddenExceedLengthCount.Value = ExceedLengthItem.Count.ToString();
            if (ExceedLengthItem.Count < 100)
            {
                btnExceedlengthNextRecords.Enabled = false;
                btnExceedlengthNextRecordsB.Enabled = false;
                string strExceedLength = CovertListToHTML(ExceedLengthItem);
                divExceedLengthReport.InnerHtml = strExceedLength;
            }
            else
            {
                btnExceedlengthNextRecords.Enabled = true;
                btnExceedlengthNextRecordsB.Enabled = true;
                string strExceedLengthJson = ConvertArrayToJson(ExceedLengthItem);
                HiddenExceedLengthList.Value = strExceedLengthJson;
                var NewExceedLengthList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    NewExceedLengthList.Add(ExceedLengthItem[intRow]);
                }
                HiddenExceedLengthNext.Value = "100";
                string strNameDuplicateHtml = CovertListToHTML(NewExceedLengthList);
                divExceedLengthReport.InnerHtml = strNameDuplicateHtml;
            }



            //filling created item list to the table
            CodeIncorrectList.Reverse();
            HiddenNewProductsCount.Value = CodeIncorrectList.Count.ToString();
            if (CodeIncorrectList.Count < 100)
            {
                btnNewItemsNextRecords.Enabled = false;
                btnNewItemsNextRecordsB.Enabled = false;
                string strNewItems = CovertListToHTML(CodeIncorrectList);
                divNewItemsReport.InnerHtml = strNewItems;
            }
            else
            {
                btnNewItemsNextRecords.Enabled = true;
                btnNewItemsNextRecordsB.Enabled = true;
                string strNewItemsJson = ConvertArrayToJson(CodeIncorrectList);
                HiddenNewProductList.Value = strNewItemsJson;
                var NewItemsList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    NewItemsList.Add(CodeIncorrectList[intRow]);
                }
                HiddenNewProductsNext.Value = "100";
                string strNewItemsHtml = CovertListToHTML(NewItemsList);
                divNewItemsReport.InnerHtml = strNewItemsHtml;
            }


            //missing or invalid cost price list to the table
            RateMissingList.Reverse();
            HiddenCostPriceMissingCount.Value = RateMissingList.Count.ToString();

            if (RateMissingList.Count < 100)
            {
                btnCostPriceMissingNextRecords.Enabled = false;
                btnCostPriceMissingNextRecordsB.Enabled = false;
                string strRateMissing = CovertListToHTML(RateMissingList);
                divCostPriceMissingReport.InnerHtml = strRateMissing;
            }
            else
            {
                btnCostPriceMissingNextRecords.Enabled = true;
                btnCostPriceMissingNextRecordsB.Enabled = true;
                string strRateMissingJson = ConvertArrayToJson(RateMissingList);
                HiddenCostPriceMissingList.Value = strRateMissingJson;
                var CostPriceMissList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    CostPriceMissList.Add(RateMissingList[intRow]);
                }
                HiddenCostPriceMissingNext.Value = "100";
                string strRateMissingHtml = CovertListToHTML(CostPriceMissList);
                divCostPriceMissingReport.InnerHtml = strRateMissingHtml;
            }

            //store the final rate amendment list
            CodeCorrectList.Reverse();
            HiddenRateUpdateCount.Value = CodeCorrectList.Count.ToString();
            if (CodeCorrectList.Count < 100)
            {
                btnRateAmendmentNextRecords.Enabled = false;
                btnRateAmendmentNextRecordsB.Enabled = false;
                string strRateAmendmentJson = ConvertArrayToJson(CodeCorrectList);
                HiddenRateAmendmentList.Value = strRateAmendmentJson;
                string strRateUpdate = CovertListToHTML(CodeCorrectList);
                divRateAmendmentReport.InnerHtml = strRateUpdate;

            }
            else
            {
                btnRateAmendmentNextRecords.Enabled = true;
                btnRateAmendmentNextRecordsB.Enabled = true;
                string strRateAmendmentJson = ConvertArrayToJson(CodeCorrectList);
                HiddenRateAmendmentList.Value = strRateAmendmentJson;
                var RateAmendmentList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    RateAmendmentList.Add(CodeCorrectList[intRow]);
                }
                HiddenRateUpdateNext.Value = "100";
                string strRateUpdateHtml = CovertListToHTML(RateAmendmentList);
                divRateAmendmentReport.InnerHtml = strRateUpdateHtml;
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "ViewMissingProductCode", "ViewMissingProductCode();", true);
        }

        catch
        {            
            Response.Redirect("gen_Product_Rate_Amendment.aspx?InsUpd=Err");
        }
    }
    
    //When Update Button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        List<clsEntityProductRateAmendment> objEntityRateAmendmentList = new List<clsEntityProductRateAmendment>();

        string strFilePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Rate_Amendment);


        string strData = Server.MapPath(strFilePath) + "/" + HiddenFile.Value;

        string strRateAmendmentList = HiddenRateAmendmentList.Value;
        string[][] strRateChangeList = JsonConvert.DeserializeObject<string[][]>(strRateAmendmentList);
        try
        {
            if (strRateChangeList != null)
            {
                for (int intRow = 0; intRow < strRateChangeList.Length; intRow++)
                {
                    clsEntityProductRateAmendment objEntityRateAmendment = new clsEntityProductRateAmendment();

                    if (Session["CORPOFFICEID"] != null)
                    {
                        objEntityRateAmendment.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    if (Session["ORGID"] != null)
                    {
                        objEntityRateAmendment.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }

                    if (Session["USERID"] != null)
                    {
                        objEntityRateAmendment.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx");
                    }

                    objEntityRateAmendment.Product_Ext_Code = strRateChangeList[intRow][0];
                    objEntityRateAmendment.Product_Ext_Code = objEntityRateAmendment.Product_Ext_Code.ToUpper();

                    decimal decValue = Convert.ToDecimal(strRateChangeList[intRow][2]);
                    if (decValue <= 99999999999)
                    {
                        objEntityRateAmendment.Product_Rate = decValue;
                        objEntityRateAmendmentList.Add(objEntityRateAmendment);
                    }

                }

                objBusinessLayerRateUpdate.RateUpdation(objEntityRateAmendmentList);
                //store final product rate amendment list to the table

                if (strRateChangeList.Length < 100)
                {
                    btnRateAmendmentNextRecords.Enabled = false;
                    btnRateAmendmentNextRecordsB.Enabled = false;
                    string strRateUpdate = CovertArrayToHTML(strRateChangeList, "New Rate");
                    divRateAmendmentReport.InnerHtml = strRateUpdate;
                }

                else
                {
                    var RateAmendmentList = new List<string[]>();
                    for (int intRow = 0; intRow < 100; intRow++)
                    {
                        RateAmendmentList.Add(strRateChangeList[intRow]);
                    }
                    HiddenRateUpdateNext.Value = "100";
                    string strRateUpdateHtml = CovertListToHTML(RateAmendmentList, "New Rate");
                    divRateAmendmentReport.InnerHtml = strRateUpdateHtml;
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "RateUpdateList", "RateUpdateList();", true);
            }
        }
        catch
        {
            //store final product rate amendment list to the table
            string strRateAmendment = CovertArrayToHTML(strRateChangeList, "New Rate");
            divRateAmendmentReport.InnerHtml = strRateAmendment;
            ScriptManager.RegisterStartupScript(this, GetType(), "RateUpdateList", "RateUpdateList();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowError", "ShowError();", true);
        }

        ScriptManager.RegisterStartupScript(this, GetType(), "RateUpdateList", "RateUpdateList();", true);
         
    }

    //create html table corresponding to the array list
    public string ConvertListStringToHTML(List<string[]> MismatchRecords)
    {


        clsCommonLibrary objCommon = new clsCommonLibrary();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        strHtml += "<td class=\"thT\" style=\"width:25%;text-align: left; font-weight: bold; word-wrap:break-word;\">" + "Product Code" + "</td>";
        strHtml += "<td class=\"thT\" style=\"width:25%;text-align: left; font-weight: bold; word-wrap:break-word;\">" + "Product Rate" + "</td>";

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";

        for (int intRowCount = 0; intRowCount < MismatchRecords.Count; intRowCount++)
        {
            strHtml += "<tr>";
                strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word; text-align: justify;\" >" + MismatchRecords[intRowCount][0].ToString() + "</td>";

                if (MismatchRecords[intRowCount].GetLength(0) > 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + MismatchRecords[intRowCount][1].ToString().TrimEnd(';') + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + "" + "</td>";
                }
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    //create html table corresponding to the array list
    public string ConvertDataTableToHTML(DataTable dt)
    {


        clsCommonLibrary objCommon = new clsCommonLibrary();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        strHtml += "<td class=\"thT\" style=\"width:20%;text-align: left; font-weight: bold; word-wrap:break-word;\">" + "Product Code" + "</td>";
        strHtml += "<td class=\"thT\" style=\"width:50%;text-align: left; font-weight: bold; word-wrap:break-word;\">" + "Product Name" + "</td>";
        strHtml += "<td class=\"thT\" style=\"width:15%;text-align: right; font-weight: bold; word-wrap:break-word;\">" + "Current Rate" + "</td>";
        strHtml += "<td class=\"thT\" style=\"width:15%;text-align: right; font-weight: bold; word-wrap:break-word;\">" + "New Rate" + "</td>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";

        for (int intRowCount = 0; intRowCount < dt.Rows.Count; intRowCount++)
        {
            strHtml += "<tr>";

            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word; text-align: left;\" >" + dt.Rows[intRowCount]["Product_Code"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:50%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowCount]["Product_Name"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word; text-align: right;\" >" + dt.Rows[intRowCount]["Current_Rate"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + dt.Rows[intRowCount]["New_Rate"].ToString() + "</td>";
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    //create a datatable corresponding to the string array
    public string CovertListToHTML(List<string[]> ProuctList, string strProductRateName=null)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"display table-bordered tbl_640\" cellspacing=\"0\" width=\"100%\" >";
        //add header row
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr>";
      

        strHtml += "<th class=\"col-md-3 tr_l\">" + "Product Code" + "</th>";

        strHtml += "<th class=\"col-md-6 tr_l\">" + "Product Name" + "</th>";
                if (strProductRateName == null)
                    strHtml += "<th class=\"col-md-4 tr_r\">" + "Product Rate" + "</th>";
                else
                    strHtml += "<th class=\"col-md-4 tr_r\">" + strProductRateName + "</th>";


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        int intSerialNumber = 0;
        strHtml += "<tbody>";
        decimal decTot = 0;
        if (ProuctList.Count == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tr_c\" colspan='3'>No Data Available</td>";
            strHtml += "</tr>";

        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < ProuctList.Count; intRowBodyCount++)
            {
                intSerialNumber++;
                strHtml += "<tr  >";
                string strProductCode = ProuctList[intRowBodyCount][0].ToString().Replace("<", string.Empty);
                strProductCode = strProductCode.Replace(">", string.Empty);
                strHtml += "<td class=\"tr_l\" >" + strProductCode + "</td>";
                if (ProuctList[intRowBodyCount].GetLength(0) > 1)
                {
                    string strProductName = ProuctList[intRowBodyCount][1].ToString().Replace("<", string.Empty);
                    strProductName = strProductName.Replace(">", string.Empty);
                    strHtml += "<td class=\"tr_l\"  >" + strProductName + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tr_l\"  >" + "" + "</td>";
                }
                if (ProuctList[intRowBodyCount].GetLength(0) > 2)
                {
                    string strCostPrice = ProuctList[intRowBodyCount][2].ToString().Replace("<", string.Empty);
                    strCostPrice = strCostPrice.Replace(">", string.Empty);
                    strHtml += "<td class=\"tr_r\"  >" + strCostPrice + "</td>";
                    if (strCostPrice != "" && strCostPrice != null && strProductRateName != null)
                        decTot += Convert.ToDecimal(strCostPrice);
                }
                else
                {
                    strHtml += "<td class=\"tr_r\"  >" + "" + "</td>";
                }

                strHtml += "</tr>";
            }
        }
        strHtml += "</tbody>";
        if (strProductRateName != null && ProuctList.Count > 0)
        {
              strHtml += "<tfoot>";
               strHtml += "<tr style=\"background-color:#eceff1!important;\">";
                 strHtml += "<td class=\"txt_rd tr_l\" colspan=\"2\" style=\"background-color:#eceff1!important;\">Total</td>";
                 strHtml += " <td class=\"txt_rd tr_r\">" + decTot + "</td>";
               strHtml += " </tr>";
               strHtml += " </tfoot>";
        }
        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    //create a datatable corresponding to the string array
    public string CovertArrayToHTML(string[][] ProuctList, string strProductRateName = null)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"display table-bordered tbl_640\" cellspacing=\"0\" width=\"100%\" >";
        //add header row
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr>";
        strHtml += "<th class=\"col-md-3 tr_l\">" + "Product Code" + "</th>";
        strHtml += "<th class=\"col-md-6 tr_l\">" + "Product Name" + "</th>";
        if (strProductRateName == null)
            strHtml += "<th class=\"col-md-4 tr_r\">" + "Product Rate" + "</th>";
        else
            strHtml += "<th class=\"col-md-4 tr_r\">" + strProductRateName + "</th>";


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        int intSerialNumber = 0;
        decimal decTot = 0;
        strHtml += "<tbody>";
        if (ProuctList.Length == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tr_c\" colspan='3'>No Data Available</td>";
            strHtml += "</tr>";

        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < ProuctList.Length; intRowBodyCount++)
            {
                intSerialNumber++;
                strHtml += "<tr  >";
                string strProductCode = ProuctList[intRowBodyCount][0].ToString().Replace("<", string.Empty);
                strProductCode = strProductCode.Replace(">", string.Empty);
                strHtml += "<td class=\"tr_l\" >" + strProductCode + "</td>";
                if (ProuctList[intRowBodyCount].GetLength(0) > 1)
                {
                    string strProductName = ProuctList[intRowBodyCount][1].ToString().Replace("<", string.Empty);
                    strProductName = strProductName.Replace(">", string.Empty);
                    strHtml += "<td class=\"tr_l\" >" + strProductName + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tr_l\"  >" + "" + "</td>";
                }
                if (ProuctList[intRowBodyCount].GetLength(0) > 2)
                {
                    string strCostPrice = ProuctList[intRowBodyCount][2].ToString().Replace("<", string.Empty);
                    strCostPrice = strCostPrice.Replace(">", string.Empty);
                    strHtml += "<td class=\"tr_r\"  >" + strCostPrice + "</td>";
                    if (strCostPrice != "" && strCostPrice != null && strProductRateName != null)
                        decTot += Convert.ToDecimal(strCostPrice);
                }
                else
                {
                    strHtml += "<td class=\"tr_r\" >" + "" + "</td>";
                }

                strHtml += "</tr>";
            }
        }
        strHtml += "</tbody>";
        if (strProductRateName != null && ProuctList.Length > 0)
        {
            strHtml += "<tfoot>";
            strHtml += "<tr style=\"background-color:#eceff1!important;\">";
            strHtml += "<td class=\"txt_rd tr_l\" colspan=\"2\" style=\"background-color:#eceff1!important;\">Total</td>";
            strHtml += " <td class=\"txt_rd tr_r\">" + decTot + "</td>";
            strHtml += " </tr>";
            strHtml += " </tfoot>";
        }
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
    //fill divisions on the drop down list
    private void FillDivision(DataTable dtDivision)
    {
        ddlDivision.Items.Clear();

        ddlDivision.DataSource = dtDivision;

        ddlDivision.DataTextField = "CPRDIV_NAME";
        ddlDivision.DataValueField = "CPRDIV_ID";
        ddlDivision.DataBind();
        if (dtDivision.Rows.Count > 1)
            ddlDivision.Items.Insert(0, "--Select A Division--");

    }

    //converting string array list to json
    private string ConvertArrayToJson(List<string[]> strArrayList)
    {
        string strjson = JsonConvert.SerializeObject(strArrayList);
        return strjson;
    }

    //remove tags from array
    private List<string[]> ListRemoveTags(List<string[]> strArrayList)
    {
        var TagRemoveArray =new List<string[]>();

        for (int intRowBodyCount = 0; intRowBodyCount < strArrayList.Count; intRowBodyCount++)
        {
            string[] strProductList = new string[3];
            string strProductCode = strArrayList[intRowBodyCount][0].ToString().Replace("<", string.Empty);
            strProductCode = strProductCode.Replace(">", string.Empty);
            strProductList[0] = strProductCode;

            if (strArrayList[intRowBodyCount].GetLength(0) > 1)
            {
                string strProductName = strArrayList[intRowBodyCount][1].ToString().Replace("<", string.Empty);
                strProductName = strProductName.Replace(">", string.Empty);
                strProductList[1] = strProductName;
            }
            else
            {
                
            }
            if (strArrayList[intRowBodyCount].GetLength(0) > 2)
            {
                string strCostPrice = strArrayList[intRowBodyCount][2].ToString().Replace("<", string.Empty);
                strCostPrice = strCostPrice.Replace(">", string.Empty);
                strProductList[2] = strCostPrice;
            }
            else
            {
                
            }

            TagRemoveArray.Add(strProductList);
        }
        return TagRemoveArray;
    }
    
    //create items through web service
    [WebMethod]
    public static string[] Create_Products(string strOrgId, string strCorpId, string strUserId, string strDivisionId, string strItemCreateList)
    {
        List<clsEntityProduct_Master> objEntityProductList = new List<clsEntityProduct_Master>();
        clsBusinessLayerProductMaster objBusinessLayerProduct = new clsBusinessLayerProductMaster();
        string[][] strItemArrayList = JsonConvert.DeserializeObject<string[][]>(strItemCreateList);
        string[] strOutput = new string[2];
        try
        {
            for (int intRow = 0; intRow < strItemArrayList.Length; intRow++)
            {
                clsEntityProduct_Master objEntityProduct = new clsEntityProduct_Master();
                objEntityProduct.Org_Id = Convert.ToInt32(strOrgId);
                objEntityProduct.Corp_Id = Convert.ToInt32(strCorpId);
                objEntityProduct.User_Id = Convert.ToInt32(strUserId);
                objEntityProduct.DivsionId = Convert.ToInt32(strDivisionId);
                objEntityProduct.Product_GrpId = 0;//as default
                objEntityProduct.ProductBrand = 0;//as default
                objEntityProduct.Product_MainCtgryId = 0;//as default
                objEntityProduct.Product_Code = strItemArrayList[intRow][0].ToString();
                objEntityProduct.Product_Code = Regex.Replace(objEntityProduct.Product_Code, "<>", string.Empty);
                objEntityProduct.ExternalAppCode = objEntityProduct.Product_Code;
                objEntityProduct.ExternalAppCode = Regex.Replace(objEntityProduct.ExternalAppCode, "<>", string.Empty);
                objEntityProduct.Product_name = strItemArrayList[intRow][1].ToString();
                objEntityProduct.Product_name = Regex.Replace(objEntityProduct.Product_name, "<>", string.Empty);
                objEntityProduct.Product_name = objEntityProduct.Product_name.ToUpper();
                objEntityProduct.Product_Code = objEntityProduct.Product_Code.ToUpper();
                objEntityProduct.ExternalAppCode = objEntityProduct.ExternalAppCode.ToUpper();

                objEntityProduct.Status = 1;
                if (strItemArrayList[intRow].Length > 2)
                {
                    if (strItemArrayList[intRow][2] == null || strItemArrayList[intRow][0] == "")
                    {
                        objEntityProduct.ProductCostPrice = 0;
                    }
                    else
                    {
                        int intValue;
                        decimal decValue;
                        bool isNumeric = int.TryParse(strItemArrayList[intRow][2].ToString(), out intValue);
                        bool isDecimal = Decimal.TryParse(strItemArrayList[intRow][2].ToString(), out decValue);
                        if (isNumeric == true || isDecimal == true)
                            objEntityProduct.ProductCostPrice = Convert.ToDecimal(strItemArrayList[intRow][2]);
                        else
                            objEntityProduct.ProductCostPrice = 0;
                    }
                }
                else
                    objEntityProduct.ProductCostPrice = 0;
                objEntityProductList.Add(objEntityProduct);
            }
            //entering the products into the product master table
            objBusinessLayerProduct.AddBulkProductDetails(objEntityProductList);            
            strOutput[1] = strItemArrayList.Length.ToString();
            
        }
        catch
        {
            strOutput[0] = "Fail";
            strOutput[1] = "0";
        }
        return strOutput;

    }
     [WebMethod]
    public static string GetText()
    {
        for (int i = 0; i < 10; i++)
        {
            i--;
        }
        return "Download Complete...";
    }
     [WebMethod]
     public static string[] ServiceListToHtml(string strList, string strCount, string strMode, string strTotalCount,string sts)
     {
         string[][] strArrayList = JsonConvert.DeserializeObject<string[][]>(strList);
         int intCount = Convert.ToInt32(strCount);
         int intFinalCount = 0;
         string[] strOutput = new string[2];

         if (intCount < 100)
             intCount = 0;
         decimal decTot = 0;
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
                 intCount = intCount - 200;
                 if (intCount < 0)
                     intCount = 0;
             }
             else
             {
                 intFinalCount = (intCount / 100) * 100;
                 intCount = intFinalCount - 100;
                 if (intCount < 0)
                     intCount = 0;
             }
         }

         if (intFinalCount % 100 != 0)
         {
             intCount = intFinalCount % 100;
             intCount = intFinalCount - intCount;
         }


        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"display table-bordered tbl_640\" cellspacing=\"0\" width=\"100%\" >";
        //add header row
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr >";
      
           
                strHtml += "<th class=\"col-md-3 tr_l\">" + "Product Code" + "</th>";

                strHtml += "<th class=\"col-md-6 tr_l\">" + "Product Name" + "</th>";

                strHtml += "<th class=\"col-md-4 tr_r\">" + "Product Rate" + "</th>";



        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        int intSerialNumber = 0;
        strHtml += "<tbody>";

        for (int intRow = intCount; intRow < intFinalCount; intRow++)
        {
            intSerialNumber++;
            strHtml += "<tr  >";
            //for serial number
            string strProductCode = strArrayList[intRow][0].ToString().Replace("<", string.Empty);
            strProductCode = strProductCode.Replace(">", string.Empty);
            strHtml += "<td class=\"tr_l\">" + strProductCode + "</td>";
            if (strArrayList[intRow].GetLength(0) > 1)
            {
                string strProductName = strArrayList[intRow][1].ToString().Replace("<", string.Empty);
                strProductName = strProductName.Replace(">", string.Empty);
                strHtml += "<td class=\"tr_l\"  >" + strProductName + "</td>";
            }
            else
            {
                strHtml += "<td class=\"tr_l\"  >" + "" + "</td>";
            }
            if (strArrayList[intRow].GetLength(0) > 2)
            {
                string strCostPrice = strArrayList[intRow][2].ToString().Replace("<", string.Empty);
                strCostPrice = strCostPrice.Replace(">", string.Empty);
                strHtml += "<td class=\"tr_r\"  >" + strCostPrice + "</td>";
                if (strCostPrice != "" && strCostPrice != null && sts == "1")
                    decTot += Convert.ToDecimal(strCostPrice);
            }
            else
            {
                strHtml += "<td class=\"tr_r\"  >" + "" + "</td>";
            }

            strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        if (sts == "1")
        {
            strHtml += "<tfoot>";
            strHtml += "<tr style=\"background-color:#eceff1!important;\">";
            strHtml += "<td class=\"txt_rd tr_l\" colspan=\"2\" style=\"background-color:#eceff1!important;\">Total</td>";
            strHtml += " <td class=\"txt_rd tr_r\">" + decTot + "</td>";
            strHtml += " </tr>";
            strHtml += " </tfoot>";
        }
        strHtml += "</table>";



        sb.Append(strHtml);
        strOutput[0] = sb.ToString();
        strOutput[1] = intFinalCount.ToString();
        return strOutput;
     }
}