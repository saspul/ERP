using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Text;
using CL_Compzit;
using System.Collections;
using System.IO;
using MailUtility_ERP;
using System.Web.Script.Serialization;
using System.Web.Services;
using Newtonsoft.Json;
using System.Text.RegularExpressions;


public partial class AWMS_AWMS_Master_gen_Vehicle_Master_gen_Vehicle_Master_Fileupload_CSV : System.Web.UI.Page
{
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        clsEntityLayerVehicleMaster objEntityVehicle = new clsEntityLayerVehicleMaster();
        string strVhclCatgry = "";


        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehicle.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (Session["USERID"] != null)
        {
            objEntityVehicle.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityVehicle.Date = System.DateTime.Now;

        string strFilePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);

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

            for (int intRow = OuterLinesCopy.Count - 1; intRow >= 0; intRow--)
            {

                
                for (int i = 0; i < 17; i++)
                {

                    //For removing <> 
                    string strItem = OuterLinesCopy[intRow][i].ToString().ToUpper();
                    strItem = strItem.Replace("<", string.Empty);
                    strItem = strItem.Replace(">", string.Empty);
                    OuterLinesCopy[intRow][i] = strItem;
                 
                        //checking missing values
                        if (OuterLinesCopy[intRow][i] == null || OuterLinesCopy[intRow][i] == "")
                        {
                            CodeMissingList.Add(OuterLinesCopy[intRow]);
                            if (OuterLines.Count >= intRow)
                                OuterLines.RemoveAt(intRow);
                            break;
                        }
                  
                   
                }            

               
            }


           //Start:-EMP-0009

            for (int intRow = OuterLinesCopy.Count - 1; intRow >= 0; intRow--)
            {

                string strVhclClass = OuterLinesCopy[intRow][0].ToString().ToUpper();
                DataTable dtVechlClassType = new DataTable();
                dtVechlClassType = objBusinessVehicle.readVhclClassDtls(strVhclClass);
                if (dtVechlClassType.Rows.Count > 0)
                {
                    strVhclCatgry = dtVechlClassType.Rows[0][3].ToString();
                }
                    if ( strVhclCatgry == "TANKER")
                    {
                        if (OuterLinesCopy[intRow].Length < 19)
                        {
                            CodeMissingList.Add(OuterLinesCopy[intRow]);
                            if (OuterLines.Count >= intRow)
                                OuterLines.RemoveAt(intRow);
                            break;
                        }
                        else
                        {

                            if (OuterLinesCopy[intRow][17] == null || OuterLinesCopy[intRow][17] == "" || OuterLinesCopy[intRow][18] == null || OuterLinesCopy[intRow][18] == "")
                            {
                                CodeMissingList.Add(OuterLinesCopy[intRow]);
                                if (OuterLines.Count >= intRow)
                                    OuterLines.RemoveAt(intRow);
                                break;
                            }
                        }
                    }
                    else if (strVhclCatgry == "TRAILER")
                    {
                        if (OuterLinesCopy[intRow].Length < 24)
                        {
                            CodeMissingList.Add(OuterLinesCopy[intRow]);
                            if (OuterLines.Count >= intRow)
                                OuterLines.RemoveAt(intRow);
                            break;
                        }
                        else
                        {

                            if (OuterLinesCopy[intRow][17] == null || OuterLinesCopy[intRow][17] == "" || OuterLinesCopy[intRow][18] == null || OuterLinesCopy[intRow][18] == "" || OuterLinesCopy[intRow][19] == null || OuterLinesCopy[intRow][19] == "" || OuterLinesCopy[intRow][20] == null || OuterLinesCopy[intRow][20] == "" || OuterLinesCopy[intRow][21] == null || OuterLinesCopy[intRow][21] == "" || OuterLinesCopy[intRow][22] == null || OuterLinesCopy[intRow][22] == "" || OuterLinesCopy[intRow][23] == null || OuterLinesCopy[intRow][23] == "")
                            {
                                CodeMissingList.Add(OuterLinesCopy[intRow]);
                                if (OuterLines.Count >= intRow)
                                    OuterLines.RemoveAt(intRow);
                                break;
                            }
                        }

                    }
               

            }
            //End:-EMP-0009


            OuterLinesCopy = OuterLines.ToList();
            //checking duplicate vehicle register number,RF Tag Number and insurance number inside the uploaded file
            for (int intRow = OuterLinesCopy.Count - 1; intRow >= 0; intRow--)
            {
                if (OuterLinesCopy.Count > intRow)
                {

                   
                    string strRegNumber = OuterLinesCopy[intRow][2].ToString();
                    string strRFTagNumber = OuterLinesCopy[intRow][9].ToString();
                    string strInsurNumber = OuterLinesCopy[intRow][12].ToString();
                   



                    for (int intSecondRow = OuterLines.Count - 1; intSecondRow >= 0; intSecondRow--)
                    {
                        if (intRow != intSecondRow)
                        {
                            if (strRegNumber == OuterLines[intSecondRow][2].ToString() || strRFTagNumber == OuterLines[intSecondRow][9].ToString() || strInsurNumber == OuterLines[intSecondRow][12].ToString())
                            {
                                if (OuterLines.Count > intRow)
                                {
                                    CodeMissingList.Add(OuterLines[intSecondRow]);
                                    OuterLines.RemoveAt(intSecondRow);
                                }
                            }
                            //Start:-EMP-0009
                            else
                            {                             
                                string strVhclCatgry1 = "", strVhclCatgry2 = "";
                                string strVhclClass1 = OuterLinesCopy[intRow][0].ToString().ToUpper();
                                DataTable dtVechlClassType1 = new DataTable();
                                dtVechlClassType1 = objBusinessVehicle.readVhclClassDtls(strVhclClass1);
                                if (dtVechlClassType1.Rows.Count > 0)
                                {
                                    strVhclCatgry1 = dtVechlClassType1.Rows[0][3].ToString();
                                }
                                string strVhclClass2 = OuterLines[intSecondRow][0].ToString().ToUpper();
                                DataTable dtVechlClassType2 = new DataTable();
                                dtVechlClassType2 = objBusinessVehicle.readVhclClassDtls(strVhclClass2);
                                if (dtVechlClassType2.Rows.Count > 0)
                                {
                                    strVhclCatgry2 = dtVechlClassType2.Rows[0][3].ToString();
                                }
                                if (strVhclCatgry1 == "TRAILER" && strVhclCatgry2 == "TRAILER")
                                {
                                    string strTrailrRegNum = OuterLinesCopy[intRow][17].ToString();
                                    string strTrailrInsurNum = OuterLinesCopy[intRow][19].ToString();

                                    if (strTrailrRegNum == OuterLines[intSecondRow][17].ToString() || strTrailrInsurNum == OuterLines[intSecondRow][19].ToString())
                                    {
                                        if (OuterLines.Count > intRow)
                                        {
                                            CodeMissingList.Add(OuterLines[intSecondRow]);
                                            OuterLines.RemoveAt(intSecondRow);
                                        }
                                    }

                                }
                            }
                         //End:-EMP-0009


                        }
                    }



                }
            }



            //checking again duplication of register number,RF Tag number and insurance number in the list
            var CodeDuplicateListCopy = new List<string[]>(CodeDuplicateList);
            CodeDuplicateListCopy = CodeDuplicateList.ToList();

            for (int intRow = CodeDuplicateListCopy.Count - 1; intRow >= 0; intRow--)
            {
                if (CodeDuplicateListCopy.Count > intRow)
                {
                    string strRegNumber = OuterLinesCopy[intRow][2].ToString();
                    string strRFTagNumber = OuterLinesCopy[intRow][9].ToString();
                    string strInsurNumber = OuterLinesCopy[intRow][12].ToString();
                   
                    for (int intSecondRow = OuterLines.Count - 1; intSecondRow >= 0; intSecondRow--)
                    {

                        if (strRegNumber == OuterLines[intSecondRow][2].ToString() || strRFTagNumber == OuterLines[intSecondRow][9].ToString() || strInsurNumber == OuterLines[intSecondRow][12].ToString())
                        {
                            if (OuterLines.Count > intRow)
                            {
                                CodeMissingList.Add(OuterLines[intSecondRow]);
                                OuterLines.RemoveAt(intSecondRow);
                            }
                            
                        }
                        //Start:-EMP-0009
                        else
                        {
                            string strVhclCatgry1 = "", strVhclCatgry2 = "";
                            string strVhclClass1 = OuterLinesCopy[intRow][0].ToString().ToUpper();
                            DataTable dtVechlClassType1 = new DataTable();
                            dtVechlClassType1 = objBusinessVehicle.readVhclClassDtls(strVhclClass1);
                            if (dtVechlClassType1.Rows.Count > 0)
                            {
                                strVhclCatgry1 = dtVechlClassType1.Rows[0][3].ToString();
                            }
                            string strVhclClass2 = OuterLines[intSecondRow][0].ToString().ToUpper();
                            DataTable dtVechlClassType2 = new DataTable();
                            dtVechlClassType2 = objBusinessVehicle.readVhclClassDtls(strVhclClass2);
                            if (dtVechlClassType2.Rows.Count > 0)
                            {
                                strVhclCatgry2 = dtVechlClassType2.Rows[0][3].ToString();
                            }
                            if (strVhclCatgry1 == "TRAILER" && strVhclCatgry2 == "TRAILER")
                            {
                                string strTrailrRegNum = OuterLinesCopy[intRow][17].ToString();
                                string strTrailrInsurNum = OuterLinesCopy[intRow][19].ToString();

                                if (strTrailrRegNum == OuterLines[intSecondRow][17].ToString() || strTrailrInsurNum == OuterLines[intSecondRow][19].ToString())
                                {
                                    if (OuterLines.Count > intRow)
                                    {
                                        CodeMissingList.Add(OuterLines[intSecondRow]);
                                        OuterLines.RemoveAt(intSecondRow);
                                    }
                                }

                            }
                        }
                        //End:-EMP-0009





                    }
                }
            }




            //checking the register number,RF Tag number and insurance number exist or not in the vehicle master table
            for (int intRow = OuterLines.Count - 1; intRow >= 0; intRow--)
            {
                objEntityVehicle.VehicleNumber = OuterLines[intRow][2].ToString();
                objEntityVehicle.VehicleNumber = objEntityVehicle.VehicleNumber.ToUpper();
               
                objEntityVehicle.RfIdTagNum = OuterLines[intRow][9].ToString();
                objEntityVehicle.RfIdTagNum = objEntityVehicle.RfIdTagNum.ToUpper();

                objEntityVehicle.Insurance = OuterLines[intRow][12].ToString();
                objEntityVehicle.Insurance = objEntityVehicle.Insurance.ToUpper();


                string strRegCount = objBusinessVehicle.CheckVehicleNumber(objEntityVehicle);
                string strRFIDCount = objBusinessVehicle.CheckRF_IdNumber(objEntityVehicle);
                string strInsureCount = objBusinessVehicle.CheckInsuranceNumber(objEntityVehicle);
                //if not exist
                if (strRegCount != "0" || strRFIDCount != "0" || strInsureCount!="0")
                {

                    CodeMissingList.Add(OuterLines[intRow]);                  
                    OuterLines.RemoveAt(intRow);
                }
                //Start:-EMP-0009
                else
                {
                    string strVhclCatgry1 = "";
                    string strVhclClass1 = OuterLines[intRow][0].ToString().ToUpper();
                    DataTable dtVechlClassType1 = new DataTable();
                    dtVechlClassType1 = objBusinessVehicle.readVhclClassDtls(strVhclClass1);
                    if (dtVechlClassType1.Rows.Count > 0)
                    {
                        strVhclCatgry1 = dtVechlClassType1.Rows[0][3].ToString();
                        if (strVhclCatgry1 == "TRAILER")
                        {
                            objEntityVehicle.TrailerRegNum = OuterLines[intRow][17].ToString();
                            objEntityVehicle.TrailerRegNum = objEntityVehicle.TrailerRegNum.ToUpper();

                            objEntityVehicle.TrailerInsNum = OuterLines[intRow][19].ToString();
                            objEntityVehicle.TrailerInsNum = objEntityVehicle.TrailerInsNum.ToUpper();
                            string strTrlrRegCount = objBusinessVehicle.CheckTrailerNumber(objEntityVehicle);
                            string strTrlrInsCount = objBusinessVehicle.CheckTrailerInsNumber(objEntityVehicle);
                            if (strTrlrRegCount != "0" || strTrlrInsCount != "0")
                            {
                                CodeMissingList.Add(OuterLines[intRow]);
                                OuterLines.RemoveAt(intRow);
                            }
                        }
                    }
                }
                //End:-EMP-0009


            }



           //For checking mismatched values in the list

                            
           for (int intRow = OuterLines.Count - 1; intRow >= 0; intRow--)
            {
                int intValue;
                decimal decValue;
                DateTime dt;
                bool isYearNumeric = int.TryParse(OuterLines[intRow][5].ToString(), out intValue);
                bool isMilgeNumeric = int.TryParse(OuterLines[intRow][10].ToString(), out intValue);
                bool isInsAmntDecimal = decimal.TryParse(OuterLines[intRow][15].ToString(), out decValue);

               


                bool isPurchasedate = DateTime.TryParse(OuterLines[intRow][8].ToString(), out dt);
                bool isIstamaraExpdate = DateTime.TryParse(OuterLines[intRow][11].ToString(), out dt);
                bool isInsExpdate = DateTime.TryParse(OuterLines[intRow][14].ToString(), out dt);


               //Start:-EMP-0009
                    string strVhclCatgry1 = "";
                    string strVhclClass1 = OuterLines[intRow][0].ToString().ToUpper();
                    DataTable dtVechlClassType1 = new DataTable();
                    dtVechlClassType1 = objBusinessVehicle.readVhclClassDtls(strVhclClass1);
                    if (dtVechlClassType1.Rows.Count > 0)
                    {
                        strVhclCatgry1 = dtVechlClassType1.Rows[0][3].ToString();
                        if (strVhclCatgry1 == "TANKER")
                        {
                        bool isTankrCapctyDecimal = decimal.TryParse(OuterLines[intRow][17].ToString(), out decValue);
                        bool isAmntBrlDecimal = decimal.TryParse(OuterLines[intRow][18].ToString(), out decValue);
                        if (isTankrCapctyDecimal == false || isAmntBrlDecimal == false)
                        {
                            CodeMissingList.Add(OuterLines[intRow]);
                            OuterLines.RemoveAt(intRow);
                            break;
                        }

                        }

                        else if (strVhclCatgry1 == "TRAILER")
                        {
                            bool isInsAmntDecimalTR = decimal.TryParse(OuterLines[intRow][22].ToString(), out decValue);
                            bool isIstamaraExpdateTR = DateTime.TryParse(OuterLines[intRow][18].ToString(), out dt);
                            bool isInsExpdateTR = DateTime.TryParse(OuterLines[intRow][21].ToString(), out dt);
                            if (isInsAmntDecimalTR == false || isIstamaraExpdateTR == false || isInsExpdateTR == false)
                            {
                                CodeMissingList.Add(OuterLines[intRow]);
                                OuterLines.RemoveAt(intRow);
                                break;
                            }

                        }




                    }
               //End:-EMP-0009



                if (isYearNumeric == false || isMilgeNumeric == false || isInsAmntDecimal == false || isPurchasedate == false || isIstamaraExpdate == false || isInsExpdate==false)
                {
                    CodeMissingList.Add(OuterLines[intRow]);
                    OuterLines.RemoveAt(intRow);
                }
               
                else
                {
                    string year = OuterLines[intRow][5].ToString();
                    string milge = OuterLines[intRow][10].ToString();
                    string InsAmnt = OuterLines[intRow][15].ToString();
                    string regNum = OuterLines[intRow][2].ToString();
                    string make = OuterLines[intRow][3].ToString();
                    string model = OuterLines[intRow][4].ToString();
                    string RFTagNum = OuterLines[intRow][9].ToString();
                    string InsNum = OuterLines[intRow][12].ToString();
                    int intCurrYear = DateTime.Now.Year;
                    if (year.Length != 4)
                    {
                        CodeMissingList.Add(OuterLines[intRow]);
                        OuterLines.RemoveAt(intRow);
                    }
                    else if (Convert.ToInt32(year) > intCurrYear)
                    {
                        CodeMissingList.Add(OuterLines[intRow]);
                        OuterLines.RemoveAt(intRow);
                    }
                    else if (milge.Length > 7)
                    {
                        CodeMissingList.Add(OuterLines[intRow]);
                        OuterLines.RemoveAt(intRow);
                    }
                    else if (InsAmnt.Length > 15)
                    {
                        CodeMissingList.Add(OuterLines[intRow]);
                        OuterLines.RemoveAt(intRow);
                    }
                    else if (regNum.Length > 99)
                    {
                        CodeMissingList.Add(OuterLines[intRow]);
                        OuterLines.RemoveAt(intRow);
                    }
                    else if (make.Length > 100)
                    {
                        CodeMissingList.Add(OuterLines[intRow]);
                        OuterLines.RemoveAt(intRow);
                    }
                    else if (model.Length > 100)
                    {
                        CodeMissingList.Add(OuterLines[intRow]);
                        OuterLines.RemoveAt(intRow);
                    }
                    else if (RFTagNum.Length > 30)
                    {
                        CodeMissingList.Add(OuterLines[intRow]);
                        OuterLines.RemoveAt(intRow);
                    }
                    else if (InsNum.Length > 100)
                    {
                        CodeMissingList.Add(OuterLines[intRow]);
                        OuterLines.RemoveAt(intRow);
                    }
                        //Start:-EMP-0009
                    else
                    {
                       
                        if (strVhclCatgry1 == "TANKER")
                        {
                            string Col17 = OuterLines[intRow][17].ToString();
                            string Col18 = OuterLines[intRow][18].ToString();
                            if (Col17.Length > 9)
                            {
                                CodeMissingList.Add(OuterLines[intRow]);
                                OuterLines.RemoveAt(intRow);
                            }
                            else if (Col18.Length > 9)
                            {
                                CodeMissingList.Add(OuterLines[intRow]);
                                OuterLines.RemoveAt(intRow);
                            }
                        }
                        else if (strVhclCatgry1 == "TRAILER")
                        {
                            string Col17 = OuterLines[intRow][17].ToString();
                            string Col18 = OuterLines[intRow][19].ToString();
                            string Col22 = OuterLines[intRow][22].ToString();
                            if (Col17.Length > 99)
                            {
                                CodeMissingList.Add(OuterLines[intRow]);
                                OuterLines.RemoveAt(intRow);
                            }
                            else if (Col18.Length > 99)
                            {
                                CodeMissingList.Add(OuterLines[intRow]);
                                OuterLines.RemoveAt(intRow);
                            }
                            else if (Col22.Length > 15)
                            {
                                CodeMissingList.Add(OuterLines[intRow]);
                                OuterLines.RemoveAt(intRow);
                            }
                        }

                    }
                 //End:-EMP-0009



                }

            }

           string strCodeCorrectListCopyJson = ConvertArrayToJson(OuterLines);
           HiddenCorrectListCopy.Value = strCodeCorrectListCopyJson;

           

           //for getting the id's of dropdown items for adding into the vehicle master table
           for (int intRow = OuterLines.Count - 1; intRow >= 0; intRow--)
           {
               string strVhclClassName = OuterLines[intRow][0].ToString().Replace("<", string.Empty);
               string strFuelType = OuterLines[intRow][1].ToString().Replace("<", string.Empty);
               string strRegType = OuterLines[intRow][6].ToString().Replace("<", string.Empty);
               string strOwnership = OuterLines[intRow][7].ToString().Replace("<", string.Empty);
               string strInsurPrvdr = OuterLines[intRow][13].ToString().Replace("<", string.Empty);
               string strInsurCovrgtyp = OuterLines[intRow][16].ToString().Replace("<", string.Empty);
               string strMakeTyp = OuterLines[intRow][3].ToString().Replace("<", string.Empty);

               string strVhclClassName1 = objBusinessVehicle.readVhclClassID(strVhclClassName).ToString();
               string strFuelType1 = objBusinessVehicle.readFuelTypeID(strFuelType).ToString();
               string strRegType1 = objBusinessVehicle.readRegTypeID(strRegType).ToString();
               string strOwnership1 = objBusinessVehicle.readOwnershipID(strOwnership).ToString();
               string strInsurPrvdr1 = objBusinessVehicle.readInsurPrvdrID(strInsurPrvdr).ToString();
               string strInsurCovrgtyp1 = objBusinessVehicle.readInsurCovrgTypeID(strInsurCovrgtyp).ToString();
               string strMakeTyp1 = objBusinessVehicle.readMakeTypId(strMakeTyp).ToString();

               if (strVhclClassName1 == "0" || strFuelType1 == "0" || strRegType1 == "0" || strOwnership1 == "0" || strInsurPrvdr1 == "0" || strInsurCovrgtyp1 == "0" || strMakeTyp1=="0")
               {
                   CodeMissingList.Add(OuterLines[intRow]);
                   OuterLines.RemoveAt(intRow);
               }
               else
               {
                   
                   OuterLines[intRow][0] = strVhclClassName1;
                   OuterLines[intRow][1] = strFuelType1;
                   OuterLines[intRow][6] = strRegType1;
                   OuterLines[intRow][7] = strOwnership1;
                   OuterLines[intRow][13] = strInsurPrvdr1;
                   OuterLines[intRow][16] = strInsurCovrgtyp1;
                   OuterLines[intRow][3] = strMakeTyp1;
               }




               string strVhclCatgry1 = "";
               string strVhclClass1 = strVhclClassName.ToUpper();
               DataTable dtVechlClassType1 = new DataTable();
               dtVechlClassType1 = objBusinessVehicle.readVhclClassDtls(strVhclClass1);
               if (dtVechlClassType1.Rows.Count > 0)
               {
                   strVhclCatgry1 = dtVechlClassType1.Rows[0][3].ToString();
                   if (strVhclCatgry1 == "TRAILER")
                   {

                       string strInsurPrvdrTR = OuterLines[intRow][20].ToString().Replace("<", string.Empty);
                       string strInsurCovrgtypTR = OuterLines[intRow][23].ToString().Replace("<", string.Empty);

                       string strInsurPrvdr1TR = objBusinessVehicle.readInsurPrvdrID(strInsurPrvdrTR).ToString();
                       string strInsurCovrgtyp1TR = objBusinessVehicle.readInsurCovrgTypeID(strInsurCovrgtypTR).ToString();


                       if (strInsurPrvdr1TR == "0" || strInsurCovrgtyp1TR == "0" )
                       {
                           CodeMissingList.Add(OuterLines[intRow]);
                           OuterLines.RemoveAt(intRow);
                       }
                       else
                       {

                           OuterLines[intRow][20] = strInsurPrvdr1TR;
                           OuterLines[intRow][23] = strInsurCovrgtyp1TR;

                       }

                   }
               }





           }



            //assigning the records have missing ,duplicate and mismatch values
            CodeMissingList.Reverse();
            HiddenCodeMissingCount.Value = CodeMissingList.Count.ToString();
            if (CodeMissingList.Count < 100)
            {
                btnMissingCodeNextRecords.Enabled = false;

                string strCodeMissingHtml = CovertListToHTML(CodeMissingList);
                divMissingCodeReport.InnerHtml = strCodeMissingHtml;
            }
            else
            {
                btnMissingCodeNextRecords.Enabled = true;

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




            //filling exceed length records to the table
            ExceedLengthItem.Reverse();
            HiddenExceedLengthCount.Value = ExceedLengthItem.Count.ToString();
            if (ExceedLengthItem.Count < 100)
            {
                btnExceedlengthNextRecords.Enabled = false;

                string strExceedLength = CovertListToHTML(ExceedLengthItem);
                divExceedLengthReport.InnerHtml = strExceedLength;
            }
            else
            {
                btnExceedlengthNextRecords.Enabled = true;

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







            //correct vehicle list-CORRECT
           // OuterLines.Reverse();
            HiddenCostPriceMissingCount.Value = OuterLines.Count.ToString();


            if (OuterLines.Count < 100)
            {
                string strRateAmendmentJson = ConvertArrayToJson(OuterLines);
                HiddenRateAmendmentList.Value = strRateAmendmentJson;

                btnRateMissingUpdate.Enabled = true;
                if (HiddenCostPriceMissingCount.Value == "0")
                {
                    btnRateMissingUpdate.Enabled = false;
                }
                btnCostPriceMissingNextRecords.Enabled = false;

                //NEW CODE


                for (int intRow = OuterLines.Count - 1; intRow >= 0; intRow--)
                {
                    string strVhclClassName = OuterLines[intRow][0].ToString();
                    string strFuelType = OuterLines[intRow][1].ToString();
                    string strRegType = OuterLines[intRow][6].ToString();
                    string strOwnership = OuterLines[intRow][7].ToString();
                    string strInsurPrvdr = OuterLines[intRow][13].ToString();
                    string strInsurCovrgtyp = OuterLines[intRow][16].ToString();
                    string strMakeTyp = OuterLines[intRow][3].ToString();
                    DataTable strVhclClassName1 = new DataTable();
                    DataTable strFuelType1 = new DataTable();
                    DataTable strRegType1 = new DataTable();
                    DataTable strOwnership1 = new DataTable();
                    DataTable strInsurPrvdr1 = new DataTable();
                    DataTable strInsurCovrgtyp1 = new DataTable();
                    DataTable strMakeTyp1= new DataTable();

                   strVhclClassName1 = objBusinessVehicle.readVhclClassName(strVhclClassName);
                   strFuelType1 = objBusinessVehicle.readFuelTypeName(strFuelType);
                   strRegType1 = objBusinessVehicle.readRegTypeName(strRegType);
                   strOwnership1 = objBusinessVehicle.readOwnershipName(strOwnership);
                   strInsurPrvdr1 = objBusinessVehicle.readInsurPrvdrName(strInsurPrvdr);
                   strInsurCovrgtyp1 = objBusinessVehicle.readInsurCovrgTypeName(strInsurCovrgtyp);
                   strMakeTyp1 = objBusinessVehicle.readMakeTypName(strMakeTyp);


                   OuterLines[intRow][0] = strVhclClassName1.Rows[0][0].ToString();
                   OuterLines[intRow][1] = strFuelType1.Rows[0][0].ToString();
                   OuterLines[intRow][6] = strRegType1.Rows[0][0].ToString();
                   OuterLines[intRow][7] = strOwnership1.Rows[0][0].ToString();
                   OuterLines[intRow][13] = strInsurPrvdr1.Rows[0][0].ToString();
                   OuterLines[intRow][16] = strInsurCovrgtyp1.Rows[0][0].ToString();
                   OuterLines[intRow][3] = strMakeTyp1.Rows[0][0].ToString();






                   string strVhclCatgry1 = "";
                   string strVhclClass1 = OuterLines[intRow][0].ToString().ToUpper();
                   DataTable dtVechlClassType1 = new DataTable();
                   dtVechlClassType1 = objBusinessVehicle.readVhclClassDtls(strVhclClass1);
                   if (dtVechlClassType1.Rows.Count > 0)
                   {
                       strVhclCatgry1 = dtVechlClassType1.Rows[0][3].ToString();
                       if (strVhclCatgry1 == "TRAILER")
                       {

                           string strInsurPrvdrTR = OuterLines[intRow][20].ToString();
                           string strInsurCovrgtypTR = OuterLines[intRow][23].ToString();                         
                           DataTable strInsurPrvdr1TR = new DataTable();
                           DataTable strInsurCovrgtyp1TR = new DataTable();
                           strInsurPrvdr1TR = objBusinessVehicle.readInsurPrvdrName(strInsurPrvdrTR);
                           strInsurCovrgtyp1TR = objBusinessVehicle.readInsurCovrgTypeName(strInsurCovrgtypTR);

                           OuterLines[intRow][20] = strInsurPrvdr1TR.Rows[0][0].ToString();
                           OuterLines[intRow][23] = strInsurCovrgtyp1TR.Rows[0][0].ToString();
                        

                       }
                   }







                }
                string strupdatelist = ConvertArrayToJson(OuterLines);
                HiddenCorrectListCopy.Value = strupdatelist;
                //END NEW CODE
                string strRateMissing = CovertListToHTML(OuterLines);
                divCostPriceMissingReport.InnerHtml = strRateMissing;
            }
           else
            {
                string strRateAmendmentJson = ConvertArrayToJson(OuterLines);
                HiddenRateAmendmentList.Value = strRateAmendmentJson;
                btnRateMissingUpdate.Enabled = true;
                btnCostPriceMissingNextRecords.Enabled = true;
                //new code
                for (int intRow = OuterLines.Count - 1; intRow >= 0; intRow--)
                {
                    string strVhclClassName = OuterLines[intRow][0].ToString();
                    string strFuelType = OuterLines[intRow][1].ToString();
                    string strRegType = OuterLines[intRow][6].ToString();
                    string strOwnership = OuterLines[intRow][7].ToString();
                    string strInsurPrvdr = OuterLines[intRow][13].ToString();
                    string strInsurCovrgtyp = OuterLines[intRow][16].ToString();
                    string strMakeTyp = OuterLines[intRow][3].ToString();
                    DataTable strVhclClassName1 = new DataTable();
                    DataTable strFuelType1 = new DataTable();
                    DataTable strRegType1 = new DataTable();
                    DataTable strOwnership1 = new DataTable();
                    DataTable strInsurPrvdr1 = new DataTable();
                    DataTable strInsurCovrgtyp1 = new DataTable();
                    DataTable strMakeTyp1 = new DataTable();

                    strVhclClassName1 = objBusinessVehicle.readVhclClassName(strVhclClassName);
                    strFuelType1 = objBusinessVehicle.readFuelTypeName(strFuelType);
                    strRegType1 = objBusinessVehicle.readRegTypeName(strRegType);
                    strOwnership1 = objBusinessVehicle.readOwnershipName(strOwnership);
                    strInsurPrvdr1 = objBusinessVehicle.readInsurPrvdrName(strInsurPrvdr);
                    strInsurCovrgtyp1 = objBusinessVehicle.readInsurCovrgTypeName(strInsurCovrgtyp);
                    strMakeTyp1 = objBusinessVehicle.readMakeTypName(strMakeTyp);


                    OuterLines[intRow][0] = strVhclClassName1.Rows[0][0].ToString();
                    OuterLines[intRow][1] = strFuelType1.Rows[0][0].ToString();
                    OuterLines[intRow][6] = strRegType1.Rows[0][0].ToString();
                    OuterLines[intRow][7] = strOwnership1.Rows[0][0].ToString();
                    OuterLines[intRow][13] = strInsurPrvdr1.Rows[0][0].ToString();
                    OuterLines[intRow][16] = strInsurCovrgtyp1.Rows[0][0].ToString();
                    OuterLines[intRow][3] = strMakeTyp1.Rows[0][0].ToString();


                    string strVhclCatgry1 = "";
                    string strVhclClass1 = OuterLines[intRow][0].ToString().ToUpper();
                    DataTable dtVechlClassType1 = new DataTable();
                    dtVechlClassType1 = objBusinessVehicle.readVhclClassDtls(strVhclClass1);
                    if (dtVechlClassType1.Rows.Count > 0)
                    {
                        strVhclCatgry1 = dtVechlClassType1.Rows[0][3].ToString();
                        if (strVhclCatgry1 == "TRAILER")
                        {

                            string strInsurPrvdrTR = OuterLines[intRow][20].ToString();
                            string strInsurCovrgtypTR = OuterLines[intRow][23].ToString();
                            DataTable strInsurPrvdr1TR = new DataTable();
                            DataTable strInsurCovrgtyp1TR = new DataTable();
                            strInsurPrvdr1TR = objBusinessVehicle.readInsurPrvdrName(strInsurPrvdrTR);
                            strInsurCovrgtyp1TR = objBusinessVehicle.readInsurCovrgTypeName(strInsurCovrgtypTR);

                            OuterLines[intRow][20] = strInsurPrvdr1TR.Rows[0][0].ToString();
                            OuterLines[intRow][23] = strInsurCovrgtyp1TR.Rows[0][0].ToString();


                        }
                    }


                }
                string strupdatelist = ConvertArrayToJson(OuterLines);
                HiddenCorrectListCopy.Value = strupdatelist;


                //end new code


                string strRateMissingJson = ConvertArrayToJson(OuterLines);
                HiddenCostPriceMissingList.Value = strRateMissingJson;

                var CostPriceMissList = new List<string[]>();
                for (int intRow = 0; intRow < 100; intRow++)
                {
                    CostPriceMissList.Add(OuterLines[intRow]);
                }
                HiddenCostPriceMissingNext.Value = "100";
                string strRateMissingHtml = CovertListToHTML(CostPriceMissList);
                divCostPriceMissingReport.InnerHtml = strRateMissingHtml;


                
            }
          



            ScriptManager.RegisterStartupScript(this, GetType(), "ViewMissingProductCode", "ViewMissingProductCode();", true);
           
        }
        catch
        {
            Response.Redirect("gen_Vehicle_Master_Fileupload_CSV.aspx?InsUpd=Err");
        }


    }
    //When Update Button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayerVehicleMaster objBusinessVehicle = new clsBusinessLayerVehicleMaster();
        List<clsEntityLayerVehicleMaster> objEntityVhclList = new List< clsEntityLayerVehicleMaster>();

        string strFilePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.VEHICLE_MASTER);


        string strData = Server.MapPath(strFilePath) + "/" + HiddenFile.Value;

        string strRateAmendmentList = HiddenRateAmendmentList.Value;
        string[][] strRateChangeList = JsonConvert.DeserializeObject<string[][]>(strRateAmendmentList);


        string strCodeCorrectListCopy = HiddenCorrectListCopy.Value;
        string[][] strRateChangeList1 = JsonConvert.DeserializeObject<string[][]>(strCodeCorrectListCopy);
        try
        {
            if (strRateChangeList != null)
            {
                for (int intRow = 0; intRow < strRateChangeList.Length; intRow++)
                {
                    clsEntityLayerVehicleMaster objEntityVhcl = new clsEntityLayerVehicleMaster();

                    if (Session["CORPOFFICEID"] != null)
                    {
                        objEntityVhcl.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    if (Session["ORGID"] != null)
                    {
                        objEntityVhcl.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }

                    if (Session["USERID"] != null)
                    {
                        objEntityVhcl.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx");
                    }



                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.VEHICLE_MASTER);
                    objEntityCommon.CorporateID = objEntityVhcl.Corporate_id;
                    objEntityCommon.Organisation_Id = objEntityVhcl.Organisation_id;
                    string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                    objEntityVhcl.NextIdForVehicle = Convert.ToInt32(strNextId);


                    objEntityVhcl.VehicleClassId = Convert.ToInt32(strRateChangeList[intRow][0]);
                    objEntityVhcl.FuelTypeId = Convert.ToInt32(strRateChangeList[intRow][1]);
                    objEntityVhcl.VehicleNumber = strRateChangeList[intRow][2].ToUpper();
                    objEntityVhcl.Make = Convert.ToInt32(strRateChangeList[intRow][3]);
                    objEntityVhcl.Model = strRateChangeList[intRow][4].ToUpper();
                    objEntityVhcl.ModalYear = Convert.ToInt32(strRateChangeList[intRow][5]);
                    objEntityVhcl.RegTypeId = Convert.ToInt32(strRateChangeList[intRow][6]);
                    objEntityVhcl.VehicleTypeId = Convert.ToInt32(strRateChangeList[intRow][7]);
                    //objEntityVhcl.VehPurchaseDate =objCommon.textToDateTime(strRateChangeList[intRow][8]);
                    objEntityVhcl.RfIdTagNum = strRateChangeList[intRow][9].ToUpper();
                    objEntityVhcl.Mileage = Convert.ToDecimal(strRateChangeList[intRow][10]);
                    //objEntityVhcl.PermitExpiryDate = objCommon.textToDateTime(strRateChangeList[intRow][11]);
                    objEntityVhcl.Insurance = strRateChangeList[intRow][12].ToUpper();
                    objEntityVhcl.InsureProviderId = Convert.ToInt32(strRateChangeList[intRow][13]);
                    //objEntityVhcl.InsuranceExpirydate = objCommon.textToDateTime(strRateChangeList[intRow][14]);
                    objEntityVhcl.InsuranceAmount = Convert.ToDecimal(strRateChangeList[intRow][15]);
                    objEntityVhcl.CoverageTypeId = Convert.ToInt32(strRateChangeList[intRow][16]);
                    
                    //Start:-EMP-0009
                    DataTable dt=objBusinessVehicle.ReadVhclCtgryByClsId(objEntityVhcl);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][1].ToString() == "TRAILER")
                        {
                             objEntityVhcl.TrailerRegNum=strRateChangeList[intRow][17].ToUpper();
                             //objEntityVhcl.TRregstrnExpDate = objCommon.textToDateTime(strRateChangeList[intRow][18]);
                             objEntityVhcl.TrailerInsNum = strRateChangeList[intRow][19].ToUpper();
                             objEntityVhcl.TRinsrncePrvdrId = Convert.ToInt32(strRateChangeList[intRow][20]);
                             //objEntityVhcl.TRinsrnceExpDate = objCommon.textToDateTime(strRateChangeList[intRow][21]);
                             objEntityVhcl.TRinsuranceAmnt = Convert.ToDecimal(strRateChangeList[intRow][22]);
                             objEntityVhcl.TRinsrnceCvrgTypId = Convert.ToInt32(strRateChangeList[intRow][23]);
                        }
                        else if (dt.Rows[0][1].ToString() == "TANKER")
                        {
                            objEntityVhcl.TankCapacity = Convert.ToDecimal(strRateChangeList[intRow][17]);
                            objEntityVhcl.AmountPerBarrel = Convert.ToDecimal(strRateChangeList[intRow][18]);
                        }
                    }
                    //End:-EMP-0009


                    try
                    {
                        objEntityVhcl.VehPurchaseDate = objCommon.textToDateTime(strRateChangeList[intRow][8]);
                        objEntityVhcl.PermitExpiryDate = objCommon.textToDateTime(strRateChangeList[intRow][11]);
                        objEntityVhcl.InsuranceExpirydate = objCommon.textToDateTime(strRateChangeList[intRow][14]);
                        if (dt.Rows[0][1].ToString() == "TRAILER")
                        {
                            objEntityVhcl.TRregstrnExpDate = objCommon.textToDateTime(strRateChangeList[intRow][18]);
                            objEntityVhcl.TRinsrnceExpDate = objCommon.textToDateTime(strRateChangeList[intRow][21]);
                        }
                    }
                    catch
                    {
                        hiddenError.Value = "1";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowErrorDate", "ShowErrorDate();", true);
                    }

                    objEntityVhclList.Add(objEntityVhcl);

                }

                if (hiddenError.Value != "1")
                {
                    objBusinessVehicle.AddVehicleList(objEntityVhclList);

                    //store final product rate amendment list to the table
                }


                    if (strRateChangeList1.Length < 100)
                    {
                        btnRateAmendmentNextRecords.Enabled = false;
                        string strRateUpdate = CovertArrayToHTML(strRateChangeList1, "New Rate");
                        divRateAmendmentReport.InnerHtml = strRateUpdate;
                    }

                    else
                    {

                        var RateAmendmentList = new List<string[]>();
                        for (int intRow = 0; intRow < 100; intRow++)
                        {
                            RateAmendmentList.Add(strRateChangeList1[intRow]);
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
    public string CovertListToHTML(List<string[]> ProuctList, string strProductRateName = null)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "Vehicle Class" + "</th>";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "Register Number" + "</th>";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "Make" + "</th>";
        strHtml += "<th class=\"thT\"  style=\"width:10%;text-align:center; word-wrap:break-word;\">" + "Model Year" + "</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + "Istamara Expiry" + "</th>";
      
       


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        int intSerialNumber = 0;
        strHtml += "<tbody>";
        if (ProuctList.Count == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" colspan='6'> <p style=\"text-align: center;font-family: calibri;\">No Data Available</p></td>";
            strHtml += "</tr>";

        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < ProuctList.Count; intRowBodyCount++)
            {
                intSerialNumber++;
                strHtml += "<tr  >";
                //for serial number
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: left;\">" + intSerialNumber + "</td>";
                string strProductCode = ProuctList[intRowBodyCount][0].ToString().Replace("<", string.Empty);
                strProductCode = strProductCode.Replace(">", string.Empty);
                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strProductCode + "</td>";
                if (ProuctList[intRowBodyCount].GetLength(0) > 1)
                {
                    string strProductName = ProuctList[intRowBodyCount][2].ToString().Replace("<", string.Empty);
                    strProductName = strProductName.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + strProductName + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + "" + "</td>";
                }
                if (ProuctList[intRowBodyCount].GetLength(0) > 2)
                {
                    string strCostPrice = ProuctList[intRowBodyCount][3].ToString().Replace("<", string.Empty);
                    strCostPrice = strCostPrice.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + strCostPrice + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + "" + "</td>";
                }


                if (ProuctList[intRowBodyCount].GetLength(0) > 3)
                {
                    string strCostPrice = ProuctList[intRowBodyCount][5].ToString().Replace("<", string.Empty);
                    strCostPrice = strCostPrice.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strCostPrice + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + "" + "</td>";
                }
                if (ProuctList[intRowBodyCount].GetLength(0) > 4)
                {
                    string strCostPrice = ProuctList[intRowBodyCount][11].ToString().Replace("<", string.Empty);
                    strCostPrice = strCostPrice.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strCostPrice + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + "" + "</td>";
                }

                strHtml += "</tr>";
            }
        }
        strHtml += "</tbody>";

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
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
       


        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "Vehicle Class" + "</th>";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "Register Number" + "</th>";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "Make" + "</th>";
        strHtml += "<th class=\"thT\"  style=\"width:10%;text-align:center; word-wrap:break-word;\">" + "Model Year" + "</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + "Istamara Expiry" + "</th>";
       


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        int intSerialNumber = 0;
        strHtml += "<tbody>";
        if (ProuctList.Length == 0)
        {
            strHtml += "<tr>";
            strHtml += "<td class=\"tdT\" colspan='6'> <p style=\"text-align: center;font-family: calibri;\">No Data Available</p></td>";
            strHtml += "</tr>";

        }
        else
        {
            for (int intRowBodyCount = 0; intRowBodyCount < ProuctList.Length; intRowBodyCount++)
            {
                intSerialNumber++;
                strHtml += "<tr  >";
                //for serial number
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: left;\">" + intSerialNumber + "</td>";
                string strProductCode = ProuctList[intRowBodyCount][0].ToString().Replace("<", string.Empty);
                strProductCode = strProductCode.Replace(">", string.Empty);
                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strProductCode + "</td>";
                if (ProuctList[intRowBodyCount].GetLength(0) > 1)
                {
                    string strProductName = ProuctList[intRowBodyCount][2].ToString().Replace("<", string.Empty);
                    strProductName = strProductName.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + strProductName + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + "" + "</td>";
                }
                if (ProuctList[intRowBodyCount].GetLength(0) > 2)
                {
                    string strCostPrice = ProuctList[intRowBodyCount][3].ToString().Replace("<", string.Empty);
                    strCostPrice = strCostPrice.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + strCostPrice + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + "" + "</td>";
                }


                if (ProuctList[intRowBodyCount].GetLength(0) > 3)
                {
                    string strCostPrice = ProuctList[intRowBodyCount][5].ToString().Replace("<", string.Empty);
                    strCostPrice = strCostPrice.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strCostPrice + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + "" + "</td>";
                }
                if (ProuctList[intRowBodyCount].GetLength(0) > 4)
                {
                    string strCostPrice = ProuctList[intRowBodyCount][11].ToString().Replace("<", string.Empty);
                    strCostPrice = strCostPrice.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strCostPrice + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + "" + "</td>";
                }

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

    //remove tags from array
    private List<string[]> ListRemoveTags(List<string[]> strArrayList)
    {
        var TagRemoveArray = new List<string[]>();

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
    [WebMethod]
    public static string[] ServiceListToHtml(string strList, string strCount, string strMode, string strTotalCount)
    {
        string[][] strArrayList = JsonConvert.DeserializeObject<string[][]>(strList);
        int intCount = Convert.ToInt32(strCount);
        int intFinalCount = 0;
        string[] strOutput = new string[2];

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
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";



        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "Vehicle Class" + "</th>";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "Register Number" + "</th>";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "Make" + "</th>";
        strHtml += "<th class=\"thT\"  style=\"width:10%;text-align:center; word-wrap:break-word;\">" + "Model Year" + "</th>";
        strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + "Istamara Expiry" + "</th>";



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
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: left;\">" + intSerialNumber + "</td>";
                string strProductCode = strArrayList[intRow][0].ToString().Replace("<", string.Empty);
                strProductCode = strProductCode.Replace(">", string.Empty);
                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strProductCode + "</td>";
                if (strArrayList[intRow].GetLength(0) > 1)
                {
                    string strProductName = strArrayList[intRow][2].ToString().Replace("<", string.Empty);
                    strProductName = strProductName.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + strProductName + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + "" + "</td>";
                }
                if (strArrayList[intRow].GetLength(0) > 2)
                {
                    string strCostPrice = strArrayList[intRow][3].ToString().Replace("<", string.Empty);
                    strCostPrice = strCostPrice.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + strCostPrice + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + "" + "</td>";
                }


                if (strArrayList[intRow].GetLength(0) > 3)
                {
                    string strCostPrice = strArrayList[intRow][5].ToString().Replace("<", string.Empty);
                    strCostPrice = strCostPrice.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strCostPrice + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + "" + "</td>";
                }
                if (strArrayList[intRow].GetLength(0) > 4)
                {
                    string strCostPrice = strArrayList[intRow][11].ToString().Replace("<", string.Empty);
                    strCostPrice = strCostPrice.Replace(">", string.Empty);
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strCostPrice + "</td>";
                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + "" + "</td>";
                }

                strHtml += "</tr>";
        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        strOutput[0] = sb.ToString();
        strOutput[1] = intFinalCount.ToString();
        return strOutput;
    }

}