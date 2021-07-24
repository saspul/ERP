<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_Candidate_Selection.aspx.cs" Inherits="HCM_HCM_Master_gen_Candidate_Selection_gen_Candidate_Selection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style type="text/css">
        #TableHeaderBilling {
            background-color: #A4B487;
            color: white;
            font-weight: bold;
            font-family: calibri;
            line-height: 25px;
        }



        #TableFooterBilling {
            color: red;
            font-weight: bold;
            font-family: calibri;
            line-height: 25px;
        }



        #myTable {
            background-color: #039ED1;
            color: white;
            font-weight: bold;
            line-height: 30px;
        }

        .custom-file-upload {
            margin-left: 13.3%;
            border: 1px solid #ccc;
            display: inline-block;
            padding: 2px 4px;
            cursor: pointer;
            position: relative;
            z-index: 2;
            font-family: Calibri;
            background: white;
        }

        #divErrorNotification {
            border-radius: 8px;
            background: #fff;
            padding: 5px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: -1.5%;
            font-family: Calibri;
            border: 2px solid #53844E;
            width: 93%;
        }

        input[type="radio"] {
            display: inline-block;
        }
    </style>
    <script src="../../../JavaScript/jquery_2.1.3_jquery_min.js"></script>
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

    <script type="text/javascript">



        var $noC = jQuery.noConflict();
        var rowCount = 0;
        var RowIndex = 0;
        var fileCount = 0;



        function addMoreRows(frm, boolFocus, boolAppendorNot, row_index) {

            document.getElementById('divErrorNotification').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";
            if (rowCount < 1) {
                jQuery('#TableaddedRows tr').remove();
            }
            rowCount++;
            RowIndex++;
            nMoney = 0;
            document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


              var recRow = '<tr id="rowId_' + rowCount + '" >';
              recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';

              recRow += '<td style="width: 3%;text-align: center;padding-right: 3px;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';

              recRow += ' <td id="tdCandName' + rowCount + '"  style="width: 12%;">';
              recRow += ' <input  id="txtCandName' + rowCount + '"  class="BillngEntryField"  type="text"  onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtCandName\',' + rowCount + ')"   maxlength=50 style="text-transform: uppercase; text-align: left; line-height: 20px; margin-bottom: 3px; width: 97%;"/>';
              recRow += '   </td> ';

              recRow += ' <td id="tdLocation' + rowCount + '"  style="width: 7%;">';
              recRow += ' <input  id="txtLocation' + rowCount + '"  class="BillngEntryField"  type="text"  onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtLocation\',' + rowCount + ')"   maxlength=50 style=" text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 95%;"/>';
              recRow += '   </td> ';

            //recRow += '<select id="ddlCountry' + rowCount + '" onchange="ChangeFile(\'ddlCountry\',' + rowCount + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
              recRow += '<td id="tdCountry' + rowCount + '"  style="width: 10%;">';
              recRow += '<select id="ddlCountry' + rowCount + '" class="form1" onchange="BlurValue(\'ddlCountry\',' + rowCount + ')"   style="margin-bottom: 3px;margin-left: 3px; width: 100%;"/>';
              recRow += '</td> ';

            //cb
              recRow += ' <td style="width: 3%"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px;"><input  id="cbvisa' + rowCount + '"  class="BillngEntryField" type="checkbox" onkeypress="return isTag(event);" onchange="IncrmntConfrmCounter();" onblur="return BlurValue(\'cbvisa\',' + rowCount + ')"    style="margin-left: 25%;"/></div></td>';

            //cb
              recRow += ' <td style="width: 5%;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 100%;"><input  id="cbLicense' + rowCount + '"  class="BillngEntryField" type="checkbox" onkeypress="return isTag(event);" onchange="IncrmntConfrmCounter();" onblur="return BlurValue(\'cbLicense\',' + rowCount + ')"    style="margin-left: 33%;"/></div></td>';
            //txt
              recRow += ' <td id="tdPassport' + rowCount + '"  style="width: 10%;">';
              recRow += ' <input  id="txtPassport' + rowCount + '"  class="BillngEntryField"  type="text"  onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtPassport\',' + rowCount + ')"   maxlength=50 style=" text-align: left; line-height: 20px; margin-top: 0px; margin-bottom: 3px; width: 96%;"/>';
              recRow += '   </td> ';
            //txt
              recRow += ' <td id="tdEmail' + rowCount + '"  style="width: 11%;">';
              recRow += ' <input  id="txtEmail' + rowCount + '"  class="BillngEntryField"  type="text"  onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtEmail\',' + rowCount + ')"   maxlength=50 style="text-align: left; line-height: 20px; margin-top: 0px; margin-bottom: 3px; width: 98%;"/>';
              recRow += '   </td> ';

              recRow += ' <td id="tdMobile' + rowCount + '"  style="width: 8%;">';
              recRow += ' <input  id="txtMobile' + rowCount + '"  class="BillngEntryField"  type="text"  onkeypress="return isTag(event)" onkeydown="return isNumber(event)"  onblur="return BlurValue(\'txtMobile\',' + rowCount + ')"   maxlength=12 style="text-align: left; line-height: 20px; margin-top: 0px; margin-bottom: 3px; width: 98%;"/>';
              recRow += '   </td> ';

              recRow += '<td id="tdGender' + rowCount + '"  style="width: 6%;">';
              recRow += '<select id="ddlGender' + rowCount + '" class="form1" onblur="return BlurValue(\'ddlGender\',' + rowCount + ')" style="margin-bottom: 3px;margin-left: 3px; width: 100%;">';
              recRow += '<option value="0">Male</option>';
              recRow += '<option value="1">Female</option>';
              recRow += '</select>';
              recRow += '</td> ';

              recRow += ' <td title="' + frm + '"  style="width: 19%;"><div style="max-height: 25px;max-width: 213px;overflow: hidden;background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 98%;font-family: calibri;"><a id="atag' + rowCount + '" target="_blank" >' + frm + '<a/></div></td>';

              recRow += '<td id="tdMoreInfo_' + rowCount + '" style="width: 3%; padding-left: 4px;"> <input  id="imgMoreInfo_' + rowCount + '" class="QuotnEntryFieldCopy" type="image" src="/Images/Icons/add.png" alt="MI" title="Additional Fields" onclick="return OpenModal(\'imgMoreInfo_\',' + rowCount + ');" style="  cursor: pointer;width: 70%;"></td>';

              recRow += '<td style="width: 3%;" title="Delete"><input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this Entry?\');"    style=" cursor: pointer;" ></td>';

              recRow += ' <td id="tdRefTyp' + rowCount + '" style="display: none;" >0</td>';
              recRow += ' <td id="tdRefVal' + rowCount + '" style="display: none;" >0</td>';
              recRow += ' <td id="tdSkipIn' + rowCount + '" style="display: none;" >0</td>';
              recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
              recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
              recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">INS</td>';
              recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;"></td>';
              recRow += '<td id="tdFileCount' + rowCount + '" style="display: none;">' + fileCount + '</td>';


              recRow += '<td id="tdFileName' + rowCount + '" style="display: none;">' + frm + '</td>';

              recRow += '</tr>';



              jQuery('#TableaddedRows').append(recRow);

              FillddlCountry(rowCount);
              fileCount++;

              LocalStorageAdd(rowCount);


          }


        function EditImportRows(CAND_NAME, CAND_LOC, CNTRY_ID, CAND_VISA, CAND_LICENSE, CAND_PASSPORTNO, CAND_EMAIL, CAND_RESUMENAME, CAND_REF, CAND_VAL, CAND_SKPINT, CAND_MOBILE, CAND_GENDER) {

            document.getElementById('divErrorNotification').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

            
            
            rowCount = document.getElementById("<%=HiddenRowCount.ClientID%>").value
            rowCount++;
            RowIndex++;


            nMoney = 0;

            document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


            var recRow = '<tr id="rowId_' + rowCount + '" >';
            recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
            recRow += '<td style="width: 3%;text-align: center;padding-right: 3px;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


            recRow += ' <td id="tdCandName' + rowCount + '"  style="width: 12%;">';
            recRow += ' <input  id="txtCandName' + rowCount + '" value="' + CAND_NAME + '"  class="BillngEntryField"  type="text"  onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtCandName\',' + rowCount + ')"   maxlength=50 style="text-transform: uppercase; text-align: left; line-height: 20px; margin-bottom: 3px; width: 97%;"/>';
            recRow += '   </td> ';

            recRow += ' <td id="tdLocation' + rowCount + '"  style="width: 7%;">';
            recRow += ' <input  id="txtLocation' + rowCount + '"  class="BillngEntryField" value="' + CAND_LOC + '" type="text"  onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtLocation\',' + rowCount + ')"   maxlength=50 style=" text-transform: uppercase; text-align: left; line-height: 20px; margin-top: 0px; margin-bottom: 3px; width: 95%;"/>';
            recRow += '   </td> ';
            recRow += '<td id="tdCountry' + rowCount + '"  style="width: 10%;">';
            recRow += '<select id="ddlCountry' + rowCount + '" class="form1" onchange="BlurValue(\'ddlCountry\',' + rowCount + ')"   style="margin-bottom: 3px; width: 100%;"/>';
            recRow += '</td> ';

            recRow += ' <td style="width: 3%;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px;"><input  id="cbvisa' + rowCount + '"  class="BillngEntryField" type="checkbox" onkeypress="return isTag(event);" onchange="IncrmntConfrmCounter();" onblur="return BlurValue(\'cbvisa\',' + rowCount + ')"    style="margin-left: 25%;"/></div></td>';


            recRow += ' <td style="width: 5%;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 98%;"><input  id="cbLicense' + rowCount + '"  class="BillngEntryField" type="checkbox" onkeypress="return isTag(event);" onchange="IncrmntConfrmCounter();" onblur="return BlurValue(\'cbLicense\',' + rowCount + ')"    style="margin-left: 33%;"/></div></td>';

            recRow += ' <td id="tdPassport' + rowCount + '"  style="width: 10%">';
            recRow += ' <input  id="txtPassport' + rowCount + '"  class="BillngEntryField"  type="text" value="' + CAND_PASSPORTNO + '"  onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtPassport\',' + rowCount + ')"   maxlength=50 style=" text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;margin-left: -0.5%;"/>';
            recRow += '   </td> ';

            recRow += ' <td id="tdEmail' + rowCount + '"  style="width: 11%;">';
            recRow += ' <input  id="txtEmail' + rowCount + '"  class="BillngEntryField"  type="text" value="' + CAND_EMAIL + '"  onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtEmail\',' + rowCount + ')"   maxlength=50 style=" text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 98%;margin-left: -0.5%;"/>';
            recRow += '   </td> ';

            recRow += ' <td id="tdMobile' + rowCount + '"  style="width: 8%;">';
            recRow += ' <input  id="txtMobile' + rowCount + '"  class="BillngEntryField"  type="text" value="' + CAND_MOBILE + '" onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtMobile\',' + rowCount + ')"   maxlength=12 style="text-align: left; line-height: 20px; margin-top: 0px; margin-bottom: 3px; width: 98%;"/>';
            recRow += '   </td> ';

            recRow += '<td id="tdGender' + rowCount + '"  style="width: 6%;">';
            recRow += '<select id="ddlGender' + rowCount + '" class="form1" onblur="return BlurValue(\'ddlGender\',' + rowCount + ')"  style="margin-bottom: 3px;margin-left: 3px; width: 100%;">';
            recRow += '<option value="0">Male</option>';
            recRow += '<option value="1">Female</option>';
            recRow += '</select>';
            recRow += '</td> ';


            recRow += ' <td style="width: 19%;" ><div style="max-height: 25px;max-width: 213px;overflow: hidden;background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 98%;font-family: calibri;" ><a id="atag' + rowCount + '" target="_blank" >' + CAND_RESUMENAME + '<a/></div></td>';
            recRow += '<td id="tdMoreInfo_' + rowCount + '" style="width: 3%; padding-left: 4px;"> <input  id="imgMoreInfo_' + rowCount + '" class="QuotnEntryFieldCopy" type="image" src="/Images/Icons/add.png" alt="MI" title="Additional Fields" onclick="return OpenModal(\'imgMoreInfo_\',' + rowCount + ');" style="  cursor: pointer; width:70%;"></td>';
            recRow += '<td style="width: 3%; padding-left: 1px;" title="Delete"><input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this Entry?\');"    style=" cursor: pointer;" ></td>';

            recRow += ' <td id="tdRefTyp' + rowCount + '" style="display: none;" >' + CAND_REF + '</td>';
            recRow += ' <td id="tdRefVal' + rowCount + '" style="display: none;" >' + CAND_VAL + '</td>';
            recRow += ' <td id="tdSkipIn' + rowCount + '" style="display: none;" >' + CAND_SKPINT + '</td>';

            recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
            recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
            recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">INS</td>';
            recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;"></td>';
            recRow += '<td id="tdFileCount' + rowCount + '" style="display: none;">' + fileCount + '</td>';

            recRow += '<td id="tdFileName' + rowCount + '" style="display: none;">' + CAND_RESUMENAME + '</td>';

            recRow += '</tr>';



            jQuery('#TableaddedRows').append(recRow);


            FillddlCountry(rowCount);
            if (CNTRY_ID != "") {

                elmnt = document.getElementById("ddlCountry" + rowCount);

                for (var i = 0; i < elmnt.options.length; i++) {

                    if (elmnt.options[i].text == CNTRY_ID)
                        elmnt.selectedIndex = i;
                }


            }

            if (CAND_VISA == "YES") {
                document.getElementById("cbvisa" + rowCount).checked = true;
            }
            else {
                document.getElementById("cbvisa" + rowCount).checked = false;
            }
            if (CAND_LICENSE == "YES") {
                document.getElementById("cbLicense" + rowCount).checked = true;
            }
            else {
                document.getElementById("cbLicense" + rowCount).checked = false;
            }

            document.getElementById("ddlGender" + rowCount).value = CAND_GENDER;

            fileCount++;

            LocalStorageAdd(rowCount);

            if (fileCount > 0) {
                document.getElementById("csvResumesUpload").style.display = "";
            }
            else {
                document.getElementById("csvResumesUpload").style.display = "none";
            }


        }

        function EditListRows(CAND_ID, CAND_NAME, CAND_LOC, CNTRY_ID, CAND_VISA, CAND_LICENSE, CAND_PASSPORTNO, CAND_RESUMENAME, CAND_ACT_RESUMENAME, CAND_EMAIL, CAND_REF, CAND_VAL, CAND_SKPINT, CAND_MOBILE, CAND_GENDER) {


            if (CAND_RESUMENAME != "" && CAND_ACT_RESUMENAME != "") {

                rowCount++;
                RowIndex++;

                var FilePath = document.getElementById("<%=HiddenFilePath.ClientID%>").value;
                var NoDelIDs = document.getElementById("<%=HiddenNoDelIDs.ClientID%>").value;

                FilePath = FilePath + CAND_RESUMENAME;


                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 3%;text-align: center;padding-right: 3px;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;" >' + RowIndex.toString() + ' </div></td>';



                recRow += ' <td id="tdCandName' + rowCount + '"  style="width: 12%;">';
                recRow += ' <input  id="txtCandName' + rowCount + '"  value="' + CAND_NAME + '" type="text"  onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtCandName\',' + rowCount + ')"   maxlength=50 style="text-transform: uppercase;text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 97%;"/>';
                recRow += '   </td> ';

                recRow += ' <td id="tdLocation' + rowCount + '"  style="width: 7%;">';
                recRow += ' <input  id="txtLocation' + rowCount + '"  class="BillngEntryField" value="' + CAND_LOC + '" type="text"  onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtLocation\',' + rowCount + ')"   maxlength=50 style="text-transform: uppercase; text-align: left; line-height: 20px; margin-top: 0px; margin-bottom: 3px; width: 95%;"/>';
                recRow += '   </td> ';

                recRow += '<td id="tdCountry' + rowCount + '"  style="width: 10%;">';
                recRow += '<select id="ddlCountry' + rowCount + '" class="form1" onchange="BlurValue(\'ddlCountry\',' + rowCount + ')"   style="margin-bottom: 3px;margin-left: 3px; width: 100%;"/>';
                recRow += '</td> ';

                //cb
                recRow += ' <td style="width: 3%;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px;"><input  id="cbvisa' + rowCount + '"  class="BillngEntryField" type="checkbox" onkeypress="return isTag(event);" onchange="IncrmntConfrmCounter();" onblur="return BlurValue(\'cbvisa\',' + rowCount + ')"    style="margin-left: 25%;"/></div></td>';

                //cb
                recRow += ' <td style="width: 5%;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; "><input  id="cbLicense' + rowCount + '"  class="BillngEntryField" type="checkbox" onkeypress="return isTag(event);" onchange="IncrmntConfrmCounter();" onblur="return BlurValue(\'cbLicense\',' + rowCount + ')"    style="margin-left: 32%;"/></div></td>';
                //txt
                recRow += ' <td id="tdPassport' + rowCount + '"  style="width: 10%;">';
                recRow += ' <input  id="txtPassport' + rowCount + '"  class="BillngEntryField" value="' + CAND_PASSPORTNO + '" type="text"  onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtPassport\',' + rowCount + ')"   maxlength=50 style="text-align: left; line-height: 20px; margin-top: 0px; margin-bottom: 3px; width: 96%;"/>';
                recRow += '   </td> ';
                //txt
                recRow += ' <td id="tdEmail' + rowCount + '"  style="width: 11%;">';
                recRow += ' <input  id="txtEmail' + rowCount + '"  class="BillngEntryField" value="' + CAND_EMAIL + '" type="text"  onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtEmail\',' + rowCount + ')"   maxlength=50 style=" text-align: left; line-height: 20px; margin-top: 0px; margin-bottom: 3px; width: 98%;"/>';
                recRow += '   </td> ';

                recRow += ' <td id="tdMobile' + rowCount + '"  style="width: 8%;">';
                recRow += ' <input  id="txtMobile' + rowCount + '"  class="BillngEntryField" value="' + CAND_MOBILE + '"  type="text"  onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtMobile\',' + rowCount + ')"  maxlength=12 style="text-align: left; line-height: 20px; margin-top: 0px; margin-bottom: 3px; width: 98%;"/>';
                recRow += '   </td> ';

                recRow += '<td id="tdGender' + rowCount + '"  style="width: 6%;">';
                recRow += '<select id="ddlGender' + rowCount + '" class="form1" onblur="return BlurValue(\'ddlGender\',' + rowCount + ')"  style="margin-bottom: 3px;margin-left: 3px; width: 100%;">';
                recRow += '<option value="0">Male</option>';
                recRow += '<option value="1">Female</option>';
                recRow += '</select>';
                recRow += '</td> ';


                recRow += ' <td title="' + CAND_ACT_RESUMENAME + '" style="width: 19%;"><div style="max-height: 23px;overflow: hidden;background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 96%;font-family: calibri;"><a target="_blank" href="' + FilePath + '">' + CAND_ACT_RESUMENAME + '<a/></div></td>';

                recRow += '<td id="tdMoreInfo_' + rowCount + '" style="width: 3%; padding-left: 4px;"> <input  id="imgMoreInfo_' + rowCount + '" class="QuotnEntryFieldCopy" type="image" src="/Images/Icons/add.png" alt="MI" title="Additional Fields" onclick="return OpenModal(\'imgMoreInfo_\',' + rowCount + ');" style="  cursor: pointer; width:70%;"></td>';

                var checkDel = NoDelIDs.search(CAND_ID);
                if (checkDel == -1) {
                    recRow += '<td title="Delete" style="width: 3%;  padding-left: 1px;"><input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this Entry?\');"    style=" cursor: pointer;" ></td>';
                }
                else {
                    recRow += '<td title="Delete" style="width: 3%;  padding-left: 1px;"><input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return CancelNotPossible();"    style=" cursor: pointer;opacity: 0.2;" ></td>';
                }

                recRow += ' <td id="tdRefTyp' + rowCount + '" style="display: none;" >' + CAND_REF + '</td>';
                recRow += ' <td id="tdRefVal' + rowCount + '" style="display: none;" >' + CAND_VAL + '</td>';
                recRow += ' <td id="tdSkipIn' + rowCount + '" style="display: none;" >' + CAND_SKPINT + '</td>';

                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;">saved</td>';
                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + CAND_ID + '</td>';
                // recRow += '<td id="td8" style="display: none;"></td>';
                recRow += '<td id="tdFileCount' + rowCount + '" style="display: none;"></td>';

                recRow += '<td id="tdFileName' + rowCount + '" style="display: none;">' + CAND_RESUMENAME + '</td>';
                recRow += '</tr>';

                jQuery('#TableaddedRows').append(recRow);

                FillddlCountry(rowCount);
                if (CNTRY_ID != "") {
                    elmnt = document.getElementById("ddlCountry" + rowCount);

                    for (var i = 0; i < elmnt.options.length; i++) {
                        if (elmnt.options[i].value == CNTRY_ID)
                            elmnt.selectedIndex = i;
                    }


                }
                if (CAND_VISA != 0) {
                    document.getElementById("cbvisa" + rowCount).checked = true;
                }
                else {
                    document.getElementById("cbvisa" + rowCount).checked = false;
                }
                if (CAND_LICENSE != 0) {
                    document.getElementById("cbLicense" + rowCount).checked = true;
                }
                else {
                    document.getElementById("cbLicense" + rowCount).checked = false;
                }

                document.getElementById("ddlGender" + rowCount).value = CAND_GENDER;

                LocalStorageAdd(rowCount);
            }
            else {


            }

        }

        function CheckaddMoreRowsIndividual(x, retBool) {

            var check = document.getElementById("tdInx" + x).innerHTML;

            if (check == " ") {

                if (retBool == true) {

                    if (CheckAllRowFieldAndHighlight(x, false) == true) {
                        document.getElementById("tdInx" + x).innerHTML = x;

                        addMoreRows(this.form, retBool, false, 0);

                        return false;
                    }
                }
                else if (retBool == false) {
                    var row_index = jQuery('#rowId_' + x).index();
                    if (CheckAllRowField(x, row_index) == true) {
                        document.getElementById("tdInx" + x).innerHTML = x;

                        addMoreRows(this.form, retBool, false, 0);


                        return false;
                    }
                }
            }
            return false;
        }
        function removeRow(removeNum, CofirmMsg) {
            if (confirm(CofirmMsg)) {

                var row_index = jQuery('#rowId_' + removeNum).index();
                var BforeRmvTableRowCount = document.getElementById("TableaddedRows").rows.length;

                LocalStorageDelete(row_index, removeNum);

                jQuery('#rowId_' + removeNum).remove();
                RowIndex--;
                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();
                var TableRowCount = document.getElementById("TableaddedRows").rows.length;

                if (TableRowCount != 0) {
                    var idlast = $noC('#TableaddedRows tr:last').attr('id');

                    if (idlast != "") {
                        var res = idlast.split("_");

                    }
                }
                else {

                }

                if (BforeRmvTableRowCount > 1) {

                    if ((BforeRmvTableRowCount - 1) == row_index) {
                        var table = document.getElementById("TableaddedRows");
                        var preRowId = table.rows[row_index - 1].id;
                        if (preRowId != "") {
                            var res = preRowId.split("_");
                            if (res[1] != "") {


                                document.getElementById("txtCandName" + res[1]).focus();
                                $noCon("#txtCandName" + res[1]).select();
                                ReNumberTable();

                            }
                        }
                    }
                    else {

                        var table = document.getElementById("TableaddedRows");
                        var NxtRowId = table.rows[row_index].id;
                       
                        if (NxtRowId != "") {
                            var res = NxtRowId.split("_");
                            if (res[1] != "") {

                                document.getElementById("txtCandName" + res[1]).focus();
                                $noCon("#txtCandName" + res[1]).select();
                                ReNumberTable();

                            }
                        }


                    }
                }

                return false;
            }
            else {
                return false;

            }
        }
        // checks every field in row
        function CheckAllRowFieldAndHighlight(x, blFromBlurValue) {
         

            document.getElementById("txtEmail" + x).style.borderColor = "";
            var Email = document.getElementById("txtEmail" + x).value;
            if (Email != "") {
                var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                if ((!filter.test(Email)) && (Email != "")) {
                    document.getElementById("txtEmail" + x).style.borderColor = "Red";
                    return false;
                }
            }

        }
        function LocalStorageAdd(x) {
         

            document.getElementById("<%=HiddenRowCount.ClientID%>").value = x;
              var tbClientWtrBilling = localStorage.getItem("tbClientWtrBilling");//Retrieve the stored data

              tbClientWtrBilling = JSON.parse(tbClientWtrBilling); //Converts string to object

              if (tbClientWtrBilling == null) //If there is no data, initialize an empty array
                  tbClientWtrBilling = [];
              var detailId = document.getElementById("tdDtlId" + x).innerHTML;
              var FileCount = document.getElementById("tdFileCount" + x).innerHTML;
              var evt = document.getElementById("tdEvt" + x).innerHTML;


              var varddlCat = document.getElementById("ddlCountry" + x);
              var ddlCountryVal = varddlCat.options[varddlCat.selectedIndex].value;
              if (ddlCountryVal == "--SELECT--")
                  ddlCountryVal = 0;
              var varddlRefTyp = document.getElementById("tdRefTyp" + x).innerHTML;
              var ddlReffVal = document.getElementById("tdRefVal" + x).innerHTML;
              var skipInt = document.getElementById("tdSkipIn" + x).innerHTML;

              var ddlGenderVal = document.getElementById("ddlGender" + x).value;

              if (evt == 'INS') {
                  var $add = jQuery.noConflict();
                  var cbvisa = 0;
                  if ($add("#cbvisa" + x).is(":checked")) {
                      // it is checked
                      cbvisa = 1;
                  }
                  var cbLicense = 0;
                  if ($add("#cbLicense" + x).is(":checked")) {
                      // it is checked
                      cbLicense = 1;
                  }

                  var client = JSON.stringify({
                      ROWID: "" + x + "",
                      CANDNAME: $add("#txtCandName" + x).val(),
                      CANDLOCAION: $add("#txtLocation" + x).val(),
                      CANDCOUNTRY: "" + ddlCountryVal + "",
                      CANDREFTYP: "" + varddlRefTyp + "",
                      CANDREFVAL: "" + ddlReffVal + "",
                      CANDSKPINT: "" + skipInt + "",
                      CANDVISA: "" + cbvisa + "",
                      CANDLICENSE: "" + cbLicense + "",
                      CANDPASSPORT: $add("#txtPassport" + x).val(),
                      CANDEMAIL: $add("#txtEmail" + x).val(),
                      CANDMOBILE: $add("#txtMobile" + x).val(),
                      CANDGENDER: "" + ddlGenderVal + "",
                      CANDDOCNAME: $add("#atag" + x).text(),
                      EVTACTION: "" + evt + "",
                      DTLID: "0",
                      FILECOUNT: "" + FileCount + ""
                  });
              }
              else if (evt == 'UPD') {

                  var $add = jQuery.noConflict();
                  var cbvisa = 0;
                  if ($add("#cbvisa" + x).is(":checked")) {
                      // it is checked
                      cbvisa = 1;
                  }
                  var cbLicense = 0;
                  if ($add("#cbLicense" + x).is(":checked")) {
                      // it is checked
                      cbLicense = 1;
                  }
                  var client = JSON.stringify({
                      ROWID: "" + x + "",
                      CANDNAME: $add("#txtCandName" + x).val(),
                      CANDLOCAION: $add("#txtLocation" + x).val(),
                      CANDCOUNTRY: "" + ddlCountryVal + "",
                      CANDREFTYP: "" + varddlRefTyp + "",
                      CANDREFVAL: "" + ddlReffVal + "",
                      CANDSKPINT: "" + skipInt + "",
                      CANDVISA: "" + cbvisa + "",
                      CANDLICENSE: "" + cbLicense + "",
                      CANDPASSPORT: $add("#txtPassport" + x).val(),
                      CANDEMAIL: $add("#txtEmail" + x).val(),
                      CANDMOBILE: $add("#txtMobile" + x).val(),
                      CANDGENDER: "" + ddlGenderVal + "",
                      CANDDOCNAME: $add("#atag" + x).text(),
                      EVTACTION: "" + evt + "",
                      DTLID: "" + detailId + "",
                      FILECOUNT: ""
                  });
              }

              tbClientWtrBilling.push(client);
              localStorage.setItem("tbClientWtrBilling", JSON.stringify(tbClientWtrBilling));

              $add("#cphMain_HiddenField1").val(JSON.stringify(tbClientWtrBilling));

              document.getElementById("tdSave" + x).innerHTML = "saved";  
              var h = document.getElementById("<%=HiddenField1.ClientID%>").value;


              return true;

          }
          function LocalStorageDelete(row_index, x) {

              var tbClientWtrBilling = localStorage.getItem("tbClientWtrBilling");//Retrieve the stored data

              tbClientWtrBilling = JSON.parse(tbClientWtrBilling); //Converts string to object

              if (tbClientWtrBilling == null) //If there is no data, initialize an empty array
                  tbClientWtrBilling = [];
              // Using splice() we can specify the index to begin removing items, and the number of items to remove.
              tbClientWtrBilling.splice(row_index, 1);
              localStorage.setItem("tbClientWtrBilling", JSON.stringify(tbClientWtrBilling));
              $noCon("#cphMain_HiddenField1").val(JSON.stringify(tbClientWtrBilling));

              var evt = document.getElementById("tdEvt" + x).innerHTML;
              if (evt == 'UPD') {
                  var detailId = document.getElementById("tdDtlId" + x).innerHTML;
                  var FileName = document.getElementById("tdFileName" + x).innerHTML;
                  if (FileName != '') {
                      var DelFiles = document.getElementById("<%=HiddenDelFiles.ClientID%>").value;
                      if (DelFiles == '') {
                          document.getElementById("<%=HiddenDelFiles.ClientID%>").value = FileName;
                              }
                              else {
                                  document.getElementById("<%=HiddenDelFiles.ClientID%>").value = document.getElementById("<%=HiddenDelFiles.ClientID%>").value + ',' + FileName;
                              }
                          }
                  //   var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
                          if (detailId != '') {
                              var CanclIds = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value;

                              if (CanclIds == '') {
                                  document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = detailId;

                              }
                              else {

                                  document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value + ',' + detailId;
                              }

                          }

                      }

                      IncrmntConfrmCounter();

                  }

                  function LocalStorageEdit(x, row_index) {
                      var tbClientWtrBilling = localStorage.getItem("tbClientWtrBilling");//Retrieve the stored data

                      tbClientWtrBilling = JSON.parse(tbClientWtrBilling); //Converts string to object
                      var FileCount = document.getElementById("tdFileCount" + x).innerHTML;
                      if (tbClientWtrBilling == null) //If there is no data, initialize an empty array
                          tbClientWtrBilling = [];
                      var detailId = document.getElementById("tdDtlId" + x).innerHTML;
                      var evt = document.getElementById("tdEvt" + x).innerHTML;
                      var varddlCat = document.getElementById("ddlCountry" + x);
                      var ddlCountryVal = varddlCat.options[varddlCat.selectedIndex].value;
                      if (ddlCountryVal == "--SELECT--")
                          ddlCountryVal = 0;
                      var varddlRefTyp = document.getElementById("tdRefTyp" + x).innerHTML;
                      var ddlReffVal = document.getElementById("tdRefVal" + x).innerHTML;
                      var skipInt = document.getElementById("tdSkipIn" + x).innerHTML;

                      var ddlGenderVal = document.getElementById("ddlGender" + x).value;

                      if (evt == 'INS') {


                          var $add = jQuery.noConflict();

                          var cbvisa = 0;
                          if ($add("#cbvisa" + x).is(":checked")) {
                              // it is checked
                              cbvisa = 1;
                          }
                          var cbLicense = 0;
                          if ($add("#cbLicense" + x).is(":checked")) {
                              // it is checked
                              cbLicense = 1;
                          }
                          tbClientWtrBilling[row_index] = JSON.stringify({
                              ROWID: "" + x + "",
                              CANDNAME: $add("#txtCandName" + x).val(),
                              CANDLOCAION: $add("#txtLocation" + x).val(),
                              CANDCOUNTRY: "" + ddlCountryVal + "",
                              CANDREFTYP: "" + varddlRefTyp + "",
                              CANDREFVAL: "" + ddlReffVal + "",
                              CANDSKPINT: "" + skipInt + "",
                              CANDVISA: "" + cbvisa + "",
                              CANDLICENSE: "" + cbLicense + "",
                              CANDPASSPORT: $add("#txtPassport" + x).val(),
                              CANDEMAIL: $add("#txtEmail" + x).val(),
                              CANDMOBILE: $add("#txtMobile" + x).val(),
                              CANDGENDER: "" + ddlGenderVal + "",
                              CANDDOCNAME: $add("#atag" + x).text(),
                              EVTACTION: "" + evt + "",
                              DTLID: "0",
                              FILECOUNT: "" + FileCount + ""


                          });//Alter the selected item on the table
                      }
                      else if (evt == 'UPD') {

                          var $add = jQuery.noConflict();
                          var cbvisa = 0;
                          if ($add("#cbvisa" + x).is(":checked")) {
                              // it is checked
                              cbvisa = 1;
                          }
                          var cbLicense = 0;
                          if ($add("#cbLicense" + x).is(":checked")) {
                              // it is checked
                              cbLicense = 1;
                          }
                          tbClientWtrBilling[row_index] = JSON.stringify({
                              ROWID: "" + x + "",
                              CANDNAME: $add("#txtCandName" + x).val(),
                              CANDLOCAION: $add("#txtLocation" + x).val(),
                              CANDCOUNTRY: "" + ddlCountryVal + "",
                              CANDREFTYP: "" + varddlRefTyp + "",
                              CANDREFVAL: "" + ddlReffVal + "",
                              CANDSKPINT: "" + skipInt + "",
                              CANDVISA: "" + cbvisa + "",
                              CANDLICENSE: "" + cbLicense + "",
                              CANDPASSPORT: $add("#txtPassport" + x).val(),
                              CANDEMAIL: $add("#txtEmail" + x).val(),
                              CANDMOBILE: $add("#txtMobile" + x).val(),
                              CANDGENDER: "" + ddlGenderVal + "",
                              CANDDOCNAME: $add("#atag" + x).text(),
                              EVTACTION: "" + evt + "",
                              DTLID: "" + detailId + "",
                              FILECOUNT: ""

                          });//Alter the selected item on the table

                      }





                      localStorage.setItem("tbClientWtrBilling", JSON.stringify(tbClientWtrBilling));
                      $add("#cphMain_HiddenField1").val(JSON.stringify(tbClientWtrBilling));

            return true;
        }
        function BlurValue(obj, x) {

            RemoveTag('txtCandName' + x);
            RemoveTag('txtLocation' + x);
            RemoveTag('txtPassport' + x);
            RemoveTag('txtEmail' + x);
            RemoveTag('txtMobile' + x);

            var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;

            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

            var Email = document.getElementById("txtEmail" + x).value;
            if (Email != "") {
                if (!filter.test(Email)) {
                    alert("Please enter valid email-id");
                    document.getElementById("txtEmail" + x).style.borderColor = "Red";
                    return false;
                }
            }
            var Mobile = document.getElementById("txtMobile" + x).value;
            if (Mobile != "") {
                if (!mobileregular.test(Mobile)) {
                    alert("Please enter valid mobile number");
                    document.getElementById("txtMobile" + x).style.borderColor = "Red";
                    return false;
                }
            }

            IncrmntConfrmCounter();

            var row_index = jQuery('#rowId_' + x).index();
            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (SavedorNot == "saved") {

                document.getElementById(obj + x).style.borderColor = "";
                // Update to local storage
                LocalStorageEdit(x, row_index);
            }
            else {
                if (SavedorNot == " ") {
                    LocalStorageAdd(x);

                }
            }
        }

        function ReNumberTable() {
            var table = "";


            table = document.getElementById("TableaddedRows");

            for (var i = 0, row; row = table.rows[i]; i++) {
                var x = "";
                 //iterate through rows
                //rows would be accessed using the "row" variable assigned in the for loop
                for (var j = 0, col; col = row.cells[j]; j++) {
                    if (j == 0) {
                        x = col.innerHTML;
                        if (x != "") {

                            var intRecount = parseInt(i) + 1;
                            document.getElementById("divSlNum" + x).innerHTML = intRecount
                            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
                            if (SavedorNot == "saved") {

                            }
                        }
                    }

                }
            }
        }


        function FillddlCountry(rowCount) {

            var ddlTestDropDownListXML = $noCon("#ddlCountry" + rowCount);

            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableCountry";
            if (document.getElementById("<%=hiddenCountryDdlData.ClientID%>").value != 0) {
        ddlEmpdata = document.getElementById("<%=hiddenCountryDdlData.ClientID%>").value;
        var OptionStart = $noCon("<option>--SELECT--</option>");
        OptionStart.attr("value", 0);
        ddlTestDropDownListXML.append(OptionStart);
        // Now find the Table from response and loop through each item (row).
        $noCon(ddlEmpdata).find(tableName).each(function () {
            // Get the OptionValue and OptionText Column values.
            var OptionValue = $noCon(this).find('CNTRY_ID').text();
            var OptionText = $noCon(this).find('CNTRY_NAME').text();
            // Create an Option for DropDownList.
            var option = $noCon("<option>" + OptionText + "</option>");
            option.attr("value", OptionValue);

            ddlTestDropDownListXML.append(option);
        });
    }

    else {
        $noCon.ajax({
            type: "POST",
            url: "gen_Candidate_Selection.aspx/DropdownCountryBind",
            data: '{tableName:"' + tableName + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                var OptionStart = $noCon("<option>--SELECT--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);
                // Now find the Table from response and loop through each item (row).
                $noCon(response.d).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noCon(this).find('CNTRY_ID').text();
                    var OptionText = $noCon(this).find('CNTRY_NAME').text();
                    // Create an Option for DropDownList.
                    var option = $noCon("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    ddlTestDropDownListXML.append(option);
                });
            },
            failure: function (response) {

            }
        });
    }
}

    </script>
    <script>
        var confirmbox = 0;
        var focusFileupload = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        function FocusFileUplod() {
            focusFileupload = 1;
        }
        function addrowimport() {
            var importdata = document.getElementById("<%=HiddenjsonImport.ClientID%>").value;

            if (importdata != "") {

                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = importdata.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');
              
                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {

                        EditImportRows(json[key].CAND_NAME, json[key].CAND_LOC, json[key].CNTRY_ID, json[key].CAND_VISA, json[key].CAND_LICENSE, json[key].CAND_PASSPORTNO, json[key].CAND_EMAIL, json[key].CAND_RESUMENAME, json[key].CAND_REF, json[key].CAND_VAL, json[key].CAND_SKPINT, json[key].CAND_MOBILE, json[key].CAND_GENDER);

                    }
                }


            }
        }
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            rowCount = 0;
            document.getElementById("fileUpload1").value = "";
            document.getElementById("uploadimportFiles").value = "";
            document.getElementById("<%=HiddenField1.ClientID%>").value = "";
            document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";
            document.getElementById('divBlink').style.visibility = "hidden";
            document.getElementById("freezelayer").style.display = "none";
            if (document.getElementById('cphMain_radioBascPay').checked) {

                document.getElementById('divFileUploader').style.display = "none";
                document.getElementById('divSelectFiles').style.display = "block";
                document.getElementById('btnprcd').style.display = "none";
                document.getElementById('div1Import').style.display = "none";
                document.getElementById('divImportDummy').style.display = "none";
                document.getElementById("<%=HiddenImportCheck.ClientID%>").value = "";

            }
            else if (document.getElementById('cphMain_radioTotlAmnt').checked) {

                document.getElementById('divFileUploader').style.display = "block";
                document.getElementById('divSelectFiles').style.display = "none";
                document.getElementById('btnprcd').style.display = "block";
                document.getElementById('div1Import').style.display = "block";
                document.getElementById('divSelectFilesDummy').style.display = "none";
                document.getElementById('divImportDummy').style.display = "none";
                document.getElementById("<%=HiddenImportCheck.ClientID%>").value = "1";

            }

            localStorage.clear();
            var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;
            var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;

            if (EditVal != "") {

                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = EditVal.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');
                
                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        if (json[key].CAND_ID != "") {
                            EditListRows(json[key].CAND_ID, json[key].CAND_NAME, json[key].CAND_LOC, json[key].CNTRY_ID, json[key].CAND_VISA, json[key].CAND_LICENSE, json[key].CAND_PASSPORTNO, json[key].CAND_RESUMENAME, json[key].CAND_ACT_RESUMENAME, json[key].CAND_EMAIL, json[key].CAND_REF, json[key].CAND_VAL, json[key].CAND_SKPINT, json[key].CAND_MOBILE, json[key].CAND_GENDER);

                        }
                    }
                }

            }
            else {

            }
            var importdata = document.getElementById("<%=HiddenjsonImport.ClientID%>").value;

            if (importdata != "") {

                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = importdata.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');
               
                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {

                        EditImportRows(json[key].CAND_NAME, json[key].CAND_LOC, json[key].CNTRY_ID, json[key].CAND_VISA, json[key].CAND_LICENSE, json[key].CAND_PASSPORTNO, json[key].CAND_EMAIL, json[key].CAND_RESUMENAME, json[key].CAND_REF, json[key].CAND_VAL, json[key].CAND_SKPINT, json[key].CAND_MOBILE, json[key].CAND_GENDER);

                    }
                }


            }
            var x = document.getElementById("TableaddedRows").rows.length;
            if (x < 1) {
                //var recRow = '<tr id="trNodata"  ><td style="width:90;text-align: center;background: #E9E9E9;font-size: 14px;font-family: Calibri;color: #5c5c5e;">No Data Available</td><td style="width:10;text-align: center;background: #E9E9E9;font-size: 14px;font-family: Calibri;>bmhvhbm</td></tr>';
                var recRow = '<tr id="trNodata"><td style="width:97.2%;text-align: center;background: #E9E9E9;font-size: 14px;font-family: Calibri;color: #5c5c5e;">No Data Available</td><td style="visibility:hidden;">0</td></tr>';
                jQuery('#TableaddedRows').append(recRow);
            }
            if (focusFileupload == 1) {
                document.getElementById('fileUpload1').focus();

            }
            else {
                document.getElementById("<%=ddlInterviewTemp.ClientID%>").focus();
             }

        });
        function ConfirmMessage() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    document.getElementById("<%=hiddenCountryDdlData.ClientID%>").value = "";
                    window.location.href = "gen_Candidate_SelectionList.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                document.getElementById("<%=hiddenCountryDdlData.ClientID%>").value = "";
                window.location.href = "gen_Candidate_SelectionList.aspx";
                return false;
            }
        }
        function ConfirmMessageImp() {
            document.getElementById("<%=hiddenCountryDdlData.ClientID%>").value = "";
            return true;

        }
        function SuccessSave() {

            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Candidate details saved successfully.";
        }
        function SuccessUpdate() {

            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Candidate details updated successfully.";
        }

        function ErrMsg() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
        }


        function countFile() {
            if (ValidateExtensions()) {
                IncrmntConfrmCounter();

                var FileCount = document.getElementById('fileUpload1').files.length;
                for (i = 0; i < FileCount; i++) {
                   
                    var name = document.getElementById('fileUpload1').files[i].name;
                    addMoreRows(name, true, false, 0);
                }

                document.getElementById('divSelectFiles').style.pointerEvents = "none";
                document.getElementById('divSelectFiles').style.display = "none";
                document.getElementById('HdFileCount').innerHTML = FileCount + " File(s) selected.";
                document.getElementById('divSelectFilesDummy').style.display = "";

            }
            else {
                document.getElementById("fileUpload1").value = "";
                return false;
            }
        }
        function countFileImport() {

            if (ValidateExtensionsImport()) {

                IncrmntConfrmCounter();

                var FileCount = document.getElementById('uploadimportFiles').files.length;
                
                var table = document.getElementById('TableaddedRows');

                for (var y = 0; y < table.rows.length; y++) {

                    var row = table.rows[y];

                    var xLoop = (table.rows[y].cells[0].innerHTML);

                    for (i = 0; i < FileCount; i++) {

                        var name = document.getElementById('uploadimportFiles').files[i].name;

                        var $add = jQuery.noConflict();
                        var namebrwse = $add("#atag" + xLoop).text();

                        if (namebrwse.toUpperCase() == name.toUpperCase()) {

                            $add("#atag" + xLoop).css('color', '#ED6525');
                        }
                        // addMoreRows(name, true, false, 0);
                    }
                }

                for (i = 0; i < FileCount; i++) {
                    var name = document.getElementById('uploadimportFiles').files[i].name;
                }

                document.getElementById('fileUpload1').disabled = true;

                document.getElementById('div1Import').style.pointerEvents = "none";
                document.getElementById('div1Import').style.display = "none";
                document.getElementById('impfilecount').innerHTML = FileCount + " File(s) selected.";
                document.getElementById('divImportDummy').style.display = "";

            }
            else {
                document.getElementById("uploadimportFiles").value = "";
                return false;
            }
        }
        function ValidateExtensionsImport() {
            var fuData = document.getElementById('uploadimportFiles');
            var FileCount = document.getElementById('uploadimportFiles').files.length;
            ret = true;
            for (i = 0; i < FileCount; i++) {
                var FileUploadPath = document.getElementById('uploadimportFiles').files[i].name;
                //var FileUploadPath = fuData.value;
                var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();



                if (Extension == "rtf" || Extension == "html"
                            || Extension == "odf" || Extension == "xlsx" || Extension == "xls" || Extension == "doc" ||
                    Extension == "docx" || Extension == "csv" || Extension == "txt" || Extension == "pdf") {
                }
                else {
                    document.getElementById('uploadimportFiles').files[i].value = "";
                    ret = false;
                }
            }
            if (ret == false) {
                alert("The specified file type could not be uploaded.Only support document files");
            }
            return ret;

        }
        function ValidateExtensions() {
            var fuData = document.getElementById('fileUpload1');
            var FileCount = document.getElementById('fileUpload1').files.length;
            ret = true;
            for (i = 0; i < FileCount; i++) {
                var FileUploadPath = document.getElementById('fileUpload1').files[i].name;
                //var FileUploadPath = fuData.value;
                var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();
                if (Extension == "rtf" || Extension == "html"
                            || Extension == "odf" || Extension == "xlsx" || Extension == "xls" || Extension == "doc" ||
                    Extension == "docx" || Extension == "csv" || Extension == "txt" || Extension == "pdf") {
                }
                else {
                    document.getElementById('fileUpload1').files[i].value = "";
                    ret = false;
                }
            }
            if (ret == false) {
                alert("The specified file type could not be uploaded.Only support document files");
                //document.getElementById("fileUpload1").value = "";
            }
            return ret;

        }
        function RemoveTag(id) {
            obj = document.getElementById(id);
            var txt = document.getElementById(id).value;
            var replaceText1 = txt.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(id).value = replaceText2;

        }
        // for not allowing <> tags  and enter
        function isTag(evt) {
            IncrmntConfrmCounter();
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

            if (keyCodes == 13) {
                return false;
            }
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }

            return ret;
        }
        function IsEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;

            if (charCode == 13) {
                ret = false;
            }

            return ret;
        }
        function ValidateAndSave() {
            ret = true;
            document.getElementById('divErrorNotification').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";
            document.getElementById("<%=ddlInterviewTemp.ClientID%>").style.borderColor = "";
            var ddlInterviewTemp = document.getElementById("<%=ddlInterviewTemp.ClientID%>").value;
            if (ddlInterviewTemp == "--SELECT INTERVIEW TEMPLATE--") {
                //If the "Please Select" option is selected display error.
                ErrMsg();
                document.getElementById("<%=ddlInterviewTemp.ClientID%>").focus();
                document.getElementById("<%=ddlInterviewTemp.ClientID%>").style.borderColor = 'red';
                return false;
            }
            var xRows = document.getElementById("TableaddedRows").rows.length;
            if (xRows < 1) {

                ErrMsg();
                alert('At least one resume file is required');
                return false;
            }
            else if (xRows == 1) {
                //trNodata
                var table = "";
                table = document.getElementById("TableaddedRows");
                var Nodata = (table.rows[0].cells[1].innerHTML);

                if (Nodata == "0") {
                    alert('At least one resume file is required');
                    return false;
                }

            }

            var table = "";
            table = document.getElementById("TableaddedRows");
            for (var i = 0; i < table.rows.length; i++) {
                if (i != table.rows.length) {
                    // FIX THIS
                    var row = table.rows[i];

                    var xLoop = (table.rows[i].cells[0].innerHTML);

                    if (CheckAllRowFieldAndHighlight(xLoop, 0) == false) {
                        document.getElementById('divErrorNotification').style.visibility = "visible";
                        document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Please enter a valid email ID";
                        document.getElementById('divMessageArea').style.display = "none";
                        $(window).scrollTop(0);
                        ret = false;
                        //break;
                    }


                }
            }
            if (document.getElementById("<%=HiddenImportCheck.ClientID%>").value == "1") {

                if (document.getElementById('uploadimportFiles').files.length == 0) {

                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please select the resumes";
                    document.getElementById("uploadimportFiles").style.borderColor = "Red";
                    document.getElementById("uploadimportFiles").focus();
                    ret = false;
                }
            }

            if (ret == true) {

                document.getElementById("<%=hiddenCountryDdlData.ClientID%>").value = "";
            }
            return ret;
        }

        function ConfirmClear() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to clear?")) {
                    //window.location.href = "gen_Candidate_Selection.aspx";
                    document.getElementById("<%=hiddenCountryDdlData.ClientID%>").value = "";
                return true;
            }
            else {
                return false;
            }
        }
        else {
            //window.location.href = "gen_Candidate_Selection.aspx";
            document.getElementById("<%=hiddenCountryDdlData.ClientID%>").value = "";
            return true;
        }
    }
    function CancelNotPossible() {
        alert("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
        return false;

    }
    function RadioBrowseClick() {
        document.getElementById('divFileUploader').style.display = "none";
        document.getElementById('divSelectFiles').style.display = "block";
        document.getElementById('btnprcd').style.display = "none";
        document.getElementById('div1Import').style.display = "none";
        document.getElementById('divImportDummy').style.display = "block";
        document.getElementById("<%=HiddenImportCheck.ClientID%>").value = "";
            jQuery('#TableaddedRows tr').remove();
            localStorage.clear();
            RowIndex = 0;

            var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;
            var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;

            if (EditVal != "") {




                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = EditVal.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');
                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        if (json[key].CAND_ID != "") {

                            EditListRows(json[key].CAND_ID, json[key].CAND_NAME, json[key].CAND_LOC, json[key].CNTRY_ID, json[key].CAND_VISA, json[key].CAND_LICENSE, json[key].CAND_PASSPORTNO, json[key].CAND_RESUMENAME, json[key].CAND_ACT_RESUMENAME, json[key].CAND_EMAIL, json[key].CAND_REF, json[key].CAND_VAL, json[key].CAND_SKPINT, json[key].CAND_MOBILE, json[key].CAND_GENDER);

                        }
                    }
                }

            }
          
        }
        function RadioImportClick() {

            document.getElementById('divFileUploader').style.display = "block";
            document.getElementById('divSelectFiles').style.display = "none";
            document.getElementById('btnprcd').style.display = "block";
            document.getElementById('div1Import').style.display = "block";
            document.getElementById('divSelectFilesDummy').style.display = "none";
            document.getElementById('divImportDummy').style.display = "none";
            document.getElementById("<%=HiddenImportCheck.ClientID%>").value = "1";
            jQuery('#TableaddedRows tr').remove();
            localStorage.clear();

            RowIndex = 0;

            var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;
            var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;

            if (EditVal != "") {

                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = EditVal.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');
                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        if (json[key].CAND_ID != "") {
                            EditListRows(json[key].CAND_ID, json[key].CAND_NAME, json[key].CAND_LOC, json[key].CNTRY_ID, json[key].CAND_VISA, json[key].CAND_LICENSE, json[key].CAND_PASSPORTNO, json[key].CAND_RESUMENAME, json[key].CAND_ACT_RESUMENAME, json[key].CAND_EMAIL, json[key].CAND_REF, json[key].CAND_VAL, json[key].CAND_SKPINT, json[key].CAND_MOBILE, json[key].CAND_GENDER);

                        }
                    }
                }
            }
        }
        function FupSelectedFileName() {

            document.getElementById('<%=Label1.ClientID%>').innerHTML = document.getElementById('<%=FileUploader.ClientID %>').value;

            IncrmntConfrmCounter();
        }

        function FileValidate() {
            var ret = true;
            //if (CheckIsRepeat() == true) {
            //}
            //else {
            //    ret = false;
            //    return ret;
            //}
            // replacing < and > tags
            document.getElementById("<%=hiddenCountryDdlData.ClientID%>").value = "";

            var fileUploader = document.getElementById("<%=FileUploader.ClientID%>").value;

            var Extension = fileUploader.substring(fileUploader.lastIndexOf('.') + 1).toLowerCase();
            document.getElementById('divMessageArea').style.visibility = "none";
            document.getElementById("<%=FileUploader.ClientID%>").style.borderColor = "";

            if (fileUploader == "") {

                document.getElementById("<%=FileUploader.ClientID%>").style.borderColor = "Red";


                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please choose CSV file";
                document.getElementById("<%=FileUploader.ClientID%>").focus();
                ret = false;
            }
            else {

                if (Extension == "csv") {
                    ret = true;
                }
                else {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "The specified file could not be uploaded. File type not supported. Allowed type is csv";
                    document.getElementById("<%=FileUploader.ClientID%>").focus();
                    ret = false;
                }
            }
            if (ret == false) {

                //CheckSubmitZero();

            }
            if (ret == true) {

            }
            return ret;
        }


        

    </script>
    <script language="javascript" type="text/javascript">
        var submit = 0;
        function CheckIsRepeat() {
            if (++submit > 1) {

                return false;
            }
            else {
                return true;
            }
        }
        function CheckSubmitZero() {
            submit = 0;
        }
    </script>
    <script>
        var $Mo = jQuery.noConflict();


        function OpenModal(objname, CntMain) {


            var offset = $Mo("#" + objname + CntMain).offset();
            var posY = 0;
            var posX = 0;
            posY = offset.top;

            posX = offset.left - 680;

            posX = 59.86;
            document.getElementById("pRowCount").innerHTML = CntMain;

            var RefTyp = document.getElementById("tdRefTyp" + CntMain).innerHTML;
            var Refval = document.getElementById("tdRefVal" + CntMain).innerHTML;
            var SkipIn = document.getElementById("tdSkipIn" + CntMain).innerHTML;

            if (SkipIn == "1") {
                document.getElementById("<%=cbxSkipIntrw.ClientID%>").checked = true;
            } else {
                document.getElementById("<%=cbxSkipIntrw.ClientID%>").checked = false;
            }
            if (RefTyp != "" && RefTyp != "0") {
                document.getElementById("<%=ddlReference.ClientID%>").value = RefTyp;
                if (RefTyp == "1") {
                    document.getElementById("<%=ddlConsultancy.ClientID%>").value=Refval;
                } else if (RefTyp == "2") {
                    document.getElementById("<%=ddlDivision.ClientID%>").value=Refval;
                } else if (RefTyp == "3") {
                    document.getElementById("<%=ddlDepartment.ClientID%>").value=Refval;
                } else if (RefTyp == "4") {
                    document.getElementById("<%=ddlEmployee.ClientID%>").value = Refval;
                }

                ddlreferenceChange();
            } else {
                document.getElementById("<%=ddlReference.ClientID%>").value = "0";
                ddlreferenceChange();
            }

            document.getElementById('divErrorRsn').style.visibility = "hidden";
            document.getElementById("<%=lblErrorRsn.ClientID%>").innerHTML = "";

            document.getElementById("myModal").style.display = "block";
            document.getElementById("freezelayer").style.display = "";
            var d = document.getElementById('myModal');
            d.style.position = "absolute";
            d.style.left = posX + '%';
            d.style.top = posY + 'px';

            return false;
        }
        function CloseModal() {

            document.getElementById("myModal").style.display = "none";
            document.getElementById("freezelayer").style.display = "none";
            return false;
        }
        function SaveAdditional() {
            if (document.getElementById("pRowCount").innerHTML != "") {
                var x = document.getElementById("pRowCount").innerHTML;
                var RefTyp= document.getElementById("<%=ddlReference.ClientID%>").value;
                
                var ret = true;
                if (RefTyp == "1") {
                    if (document.getElementById("<%=ddlConsultancy.ClientID%>").value != "--SELECT CONSULTANCY--") {
                        document.getElementById("tdRefTyp" + x).innerHTML = RefTyp;
                        document.getElementById("tdRefVal" + x).innerHTML = document.getElementById("<%=ddlConsultancy.ClientID%>").value;
                    } else {
                        ret = false;
                        document.getElementById("cphMain_lblErrorRsn").innerHTML = "Please select a consultancy to continue.";
                        document.getElementById("divErrorRsn").style.visibility = "visible";
                     
                    }
                    
                } else if (RefTyp == "2") {
                    if (document.getElementById("<%=ddlDivision.ClientID%>").value != "--SELECT DIVISION--") {
                        document.getElementById("tdRefTyp" + x).innerHTML = RefTyp;
                        document.getElementById("tdRefVal" + x).innerHTML = document.getElementById("<%=ddlDivision.ClientID%>").value;
                    } else {
                        ret = false;
                        document.getElementById("cphMain_lblErrorRsn").innerHTML = "Please select a division to continue.";
                        document.getElementById("divErrorRsn").style.visibility = "visible";
                    }
                } else if (RefTyp == "3") {
                    if (document.getElementById("<%=ddlDepartment.ClientID%>").value != "--SELECT DEPARTMENT--") {
                        document.getElementById("tdRefTyp" + x).innerHTML = RefTyp;
                        document.getElementById("tdRefVal" + x).innerHTML = document.getElementById("<%=ddlDepartment.ClientID%>").value;
                    } else {
                        ret = false;
                        document.getElementById("cphMain_lblErrorRsn").innerHTML = "Please select a department to continue.";
                        document.getElementById("divErrorRsn").style.visibility = "visible";
                    }
                } else if (RefTyp == "4") {
                    if (document.getElementById("<%=ddlEmployee.ClientID%>").value != "--SELECT EMPLOYEE--") {
                        document.getElementById("tdRefTyp" + x).innerHTML = RefTyp;
                        document.getElementById("tdRefVal" + x).innerHTML = document.getElementById("<%=ddlEmployee.ClientID%>").value;

                    } else {
                        ret = false;
                        document.getElementById("cphMain_lblErrorRsn").innerHTML = "Please select a employee to continue.";
                        document.getElementById("divErrorRsn").style.visibility = "visible";
                    }

                }

                if (document.getElementById("<%=cbxSkipIntrw.ClientID%>").checked == true) {
                    document.getElementById("tdSkipIn" + x).innerHTML = "1";
                } else {
                    document.getElementById("tdSkipIn" + x).innerHTML = "0";
                }
                if (ret == true) {
                    BlurValue("tdRefVal", x);
                    document.getElementById("cphMain_lblErrorRsn").innerHTML = "Details saved sucessfully.";
                    document.getElementById("divErrorRsn").style.visibility = "visible";
                }

            }
            else {//if no id has been received

                document.getElementById("myModal").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
            }

            document.getElementById("imgMoreInfo_" + x).focus();

            return false;
        }
     
        function ddlreferenceChange() {
            document.getElementById("divConsultAdd").style.display = "none";
            document.getElementById("divDivAdd").style.display = "none";
            document.getElementById("divDepartAdd").style.display = "none";
            document.getElementById("divEmpAdd").style.display = "none";
            //EVM-0024
            if (document.getElementById("<%=ddlConsultancy.ClientID%>").value == "") {
                document.getElementById("<%=ddlConsultancy.ClientID%>").value = "--SELECT CONSULTANCY--";
            }
            if (document.getElementById("<%=ddlDivision.ClientID%>").value == "") {
                document.getElementById("<%=ddlDivision.ClientID%>").value = "--SELECT DIVISION--";
            }
            if (document.getElementById("<%=ddlDepartment.ClientID%>").value == "") {
                document.getElementById("<%=ddlDepartment.ClientID%>").value = "--SELECT DEPARTMENT--";
            }
            if (document.getElementById("<%=ddlEmployee.ClientID%>").value == "") {
                document.getElementById("<%=ddlEmployee.ClientID%>").value = "--SELECT EMPLOYEE--";
            }
            if(document.getElementById("<%=ddlReference.ClientID%>").value=="1")
            {
                document.getElementById("divConsultAdd").style.display = "";
            }
            else if(document.getElementById("<%=ddlReference.ClientID%>").value=="2")
            {
                document.getElementById("divDivAdd").style.display = "";
            }
            else if(document.getElementById("<%=ddlReference.ClientID%>").value=="3")
            {
                document.getElementById("divDepartAdd").style.display = "";
            }
            else if (document.getElementById("<%=ddlReference.ClientID%>").value == "4") {
                document.getElementById("divEmpAdd").style.display = "";
            } else {
            }

        }


        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //at enter
            if (keyCodes == 13) {
                return false;
            }
                //0-9
            else if (keyCodes >= 48 && keyCodes <= 57) {
                return true;
            }
                //numpad 0-9
            else if (keyCodes >= 96 && keyCodes <= 105) {
                return true;
            }
                //left arrow key,right arrow key,home,end ,delete
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                return true;

            }
            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                }
                return ret;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="HiddenDeptId" runat="server" />
    <asp:HiddenField ID="HiddenConsultancyId" runat="server" />
    <asp:HiddenField ID="HiddenEmpIds" runat="server" />
    <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
    <asp:HiddenField ID="hiddenEdit" runat="server" />
    <asp:HiddenField ID="hiddenView" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hiddenCountryDdlData" runat="server" />
    <asp:HiddenField ID="hiddenCorporateId" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenCandMasterID" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFilePath" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenDelFiles" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenNoDelIDs" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenCorrectListCopy" runat="server" />
    <asp:HiddenField ID="HiddenCodeMissingCount" runat="server" />

    <asp:HiddenField ID="HiddenjsonImport" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenRowCount" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenImportCheck" runat="server" />


        <asp:HiddenField ID="hiddenManpwrId" runat="server" />

    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 0%; top: 42%; height: 26.5px;">
    </div>
    <asp:Label ID="lblIndex" runat="server" Text="Label" Style="display: none"></asp:Label>
    <div class="cont_rght" style="width: 100%;">



        <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke; float: left">

            <div id="divReportCaption" style="width: 100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; float: left">
                <asp:Label ID="lblEntry" runat="server">Candidate Selection</asp:Label>
            </div>

            <div style="float: left; width: 98%; padding: 10px; margin-top: 2%; border: 1px solid #929292; background-color: #c9c9c9; max-height: 125px;">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Ref#</h2>
                    <asp:Label ID="lblRefNum" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Date Of Request</h2>
                    <asp:Label ID="lblDateOfReq" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">No.of Resources</h2>
                    <asp:Label ID="lblNumber" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Designation</h2>
                    <asp:Label ID="lblDesign" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Department</h2>
                    <asp:Label ID="lblDeprtmnt" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Project</h2>
                    <asp:Label ID="lblPrjct" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Experience</h2>
                    <asp:Label ID="lblExprnce" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Pay Grade</h2>
                    <asp:Label ID="lblPaygrd" class="lblTop" runat="server"></asp:Label>
                </div>

            </div>

            <div class="fillform" style="width: 100%;">
                <div class="eachform" style="width: 50%; margin-top: 2%; margin-left: 2%; float: left;">

                    <h2 style="margin-top: 1%;">Interview Template*</h2>

                    <asp:DropDownList ID="ddlInterviewTemp" class="form1" runat="server" onchange="IncrmntConfrmCounter();" Style="width: 160px; height: 30px; width: 45%; float: left; margin-left: 8%;">
                    </asp:DropDownList>
                    <div>
                    </div>
                </div>
                <div class="eachform" style="width: 36%; float: left; margin-top: 2.5%; /*! height: 130px; */margin-left: 0.4%;">

                    <div style="width: 39%; float: left; margin-left: 5.8%;">
                        <input id="radioBascPay" type="radio" runat="server" onchange="RadioBrowseClick()" name="radTypenxt" />
                        <label style="font-family: Calibri" for="cphMain_radioOpen">Browse Resumes</label>
                    </div>


                    <div style="width: 44%; /*! float: left; */margin-left: 44%;">
                        <input id="radioTotlAmnt" type="radio" runat="server" onchange="RadioImportClick()" name="radTypenxt" />
                        <label style="font-family: Calibri" for="cphMain_radioLimited">Import Resumes</label>
                    </div>

                </div>


                <div id="divFileuploadAndBrws" style="width:100%; margin-top: 6%;" >
                <div id="divFileUploader" class="eachform" style="height: 40px; margin-top: 2%; float: left; width: 51%;">
                    <h2 style="padding-top: 0.4%; padding-left: 2%;">Choose CSV File*</h2>


                    <label id="lblFileUpload" for="cphMain_FileUploader" class="custom-file-upload" style="margin-left: 13.6%; color: black">
                        <img src="/../Images/Icons/cloud_upload.jpg" />Upload File
                    </label>
                    <asp:FileUpload ID="FileUploader" class="imageUpload" onchange="FupSelectedFileName()" runat="server" Accept=".csv"
                        Style="display: none; padding-left: 24.5%;" />

                    <!--<asp:TextBox ID="TextBox1" Text="No File selected"  runat="server"></asp:TextBox>-->
                    <asp:Label ID="Label1" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
                </div>
                <div id="divImportDummy" class="eachform" style="width: 45%; float: right; display: none;">
                    <h2 style="margin-top: 1%;">Select Resumes:</h2>
                    <h2 id="impfilecount" style="margin-left: 13%; margin-top: 1%;">0</h2>
                    <asp:Button ID="btnupploadimp" ToolTip="Clear" class="cancel" runat="server" Style="margin-left: 10%;" Text="Clear" OnClientClick="return ConfirmClear();" OnClick="btnClear_Click" />
                   
                </div>
                    </div>
                <div id="btnprcd" class="eachform" style="margin-top: 1%; float: left;">
                    <div class="subform" style="margin-left: 17.8%; float: left;">
                        <asp:Button ID="btnAdd" runat="server" class="save" Text="Proceed" Style="width: 38%;" OnClick="btnCSVPrcd_Click" OnClientClick="return FileValidate();" />
                        <asp:Button ID="BtnCancelImport" runat="server" class="cancel" Text="Cancel" OnClientClick="return ConfirmMessageImp();" PostBackUrl="gen_Candidate_Selection.aspx" />
                    </div>
                </div>

               <%-- CSV--%>

                 <div id="div1Import" class="eachform" style="width: 42%; margin-top: -8%; margin-left: 53%; float: left;">

                    <div id="csvResumesUpload" style="display:none;">
                    <h2 style="margin-top: 1%;">Select Resumes*:</h2>

                    <input id="uploadimportFiles" onchange="countFileImport();" type="file" name="img1" accept=".xls,.xlsx,.rtf,.html,.odf,.xlsx,.xls,.doc,.docx,.csv,.txt,.pdf" multiple="multiple" style="height: 25px; width: 160px; height: 25px; width: 45%; float: left; margin-left: 13%;" />
                    
                   </div>

                    <a href="/CustomFiles/csvTemplate/Candidate%20Selection.csv">  <img src="../../../Images/Icons/CSV.PNG" title="Sample CSV File" style="margin-left: -8%"; /></a>
                </div>

               <%-- UPLOAD--%>

                <div id="divSelectFiles" class="eachform" style="width: 50%; margin-top: 2%; margin-left: 2%; float: left;">
                    <h2 style="margin-top: 1%;">Select Resumes:</h2>

                    <input id="fileUpload1" onchange="countFile();" type="file" name="img" accept=".xls,.xlsx,.rtf,.html,.odf,.xlsx,.xls,.doc,.docx,.csv,.txt,.pdf" multiple="multiple" style="width: 160px; height: 25px; width: 45%; float: left; margin-left: 13%;" />
                </div>


                <div id="divSelectFilesDummy" class="eachform" style="display: none; width: 50%; margin-top: 2%; margin-left: 2%; float: left;">
                    <h2 style="margin-top: 1%;">Select Resumes:</h2>
                    <h2 id="HdFileCount" style="margin-left: 13%; margin-top: 1%;">0</h2>
                    <%--<img id="ClearImage" src="/Images/Icons/clear-image-green.png" alt="Clear" onclick="return ConfirmClear();" style="cursor: pointer; float: right;" />--%>
                    <asp:Button ID="imgbtnCLear" ToolTip="Clear" class="cancel" runat="server" Style="margin-left: 10%;" Text="Clear" OnClientClick="return ConfirmClear();" OnClick="btnClear_Click" />
                    <%--<input id="fileUpDummy"  type="file" disabled name="imgDummy" accept=".xls,.xlsx,.rtf,.html,.odf,.xlsx,.xls,.doc,.docx,.csv,.txt,.pdf"  multiple style="height:25px;width:160px;height:25px;width:45%;float:left; margin-left: 13%;"/>--%>
                </div>
                <div class="leads_form">
                    <div id="divErrorNotification" style="visibility: hidden">
                        <asp:Label ID="lblErrorNotification" runat="server"></asp:Label>
                    </div>
                    <div id="divTables" style="width: 100%; margin: auto; padding-top: 0.6%;">
                        <h2 style="margin-top: 1%;"></h2>
                        <table id="TableHeaderBilling" rules="all" style="width: 100%;">

                            <tr>
                                <td style="font-size: 14px; width: 3%; padding-left: 0.5%;">Sl#</td>
                                <td style="font-size: 14px; width: 12%; padding-left: 0.5%;">Candidate Name</td>
                                <td style="font-size: 14px; width: 7%; padding-left: 0.5%;">Location</td>
                                <td style="font-size: 14px; width: 10%; padding-left: 0.5%;">Country</td>
                                <td style="font-size: 14px; width: 3%; padding-left: 0.5%;">Visa</td>
                                <td style="font-size: 14px; width: 5%; padding-left: 0.5%;">License</td>
                                <td style="font-size: 14px; width: 10%; padding-left: 0.5%;">Passport No.</td>
                                <td style="font-size: 14px; width: 11%; padding-left: 0.5%;">Email</td>
                                <td style="font-size: 14px; width: 8%; padding-left: 0.5%;">Mobile No.</td>
                                <td style="font-size: 14px; width: 6%; padding-left: 0.5%;">Gender</td>
                                <td style="font-size: 14px; width: 19%; padding-left: 0.5%;">File Name</td>
                                <td id="spanAddRow" style="width: 3%;"></td>
                                <td id="spanAddAdtn" style="width: 3%;"></td>
                            </tr>
                        </table>

                        <div style="width: 100%; min-height: 75px; overflow: auto;">
                            <table id="TableaddedRows" style="width: 100%;">
                            </table>

                        </div>

                        <div id="divBlink" style="background-color: rgb(249, 246, 3); font-size: 10.5px; color: black; opacity: 0.6;"></div>

                    </div>




                </div>

                <div class="eachform" style="margin-top: -1.5%;">

                    <div class="subform" style="width: 65%; margin-top: 2%;">


                        <asp:Button ID="btnSave" runat="server" class="cancel" Style="margin-left: 2%;" Text="Save" OnClientClick="return ValidateAndSave();" OnClick="btnSave_Click" />
                        <asp:Button ID="btnSaveClose" runat="server" class="cancel" Style="margin-left: 2%;" Text="Save & Close" OnClientClick="return ValidateAndSave();" OnClick="btnSave_Click" />
                        <asp:Button ID="btnUpdate" runat="server" class="cancel" Style="margin-left: 2%;" Text="Update" OnClientClick="return ValidateAndSave();" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnUpdateClose" runat="server" class="cancel" Style="margin-left: 2%;" Text="Update & Close" OnClientClick="return ValidateAndSave();" OnClick="btnUpdate_Click" />

                        <asp:Button ID="btnClear" runat="server" class="cancel" Style="margin-left: 2%;" Text="Clear" OnClientClick="return ConfirmClear();" OnClick="btnClear_Click" />
                        <asp:Button ID="btnCancel" runat="server" class="cancel" Style="margin-left: 2%;" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                        <%--<asp:Button ID="btnClose" runat="server" class="save" Text="Close" OnClientClick="return ConfirmMessage();" />--%>
                    </div>

                </div>
            </div>

        </div>


    </div>

                <!-- The Modal -->
            <div id="myModal" class="modalAdd">
                <img id="imgGreenArrow" src="/Images/Icons/green-arrow-20x20.png" style="float: right; margin-top: 0.8%;">
                <!-- Modal content -->
                <div class="modal-contentAdd">
                    <div id="ModalHeader" class="modal-headerAdd">

                        <img class="closeAdd" style="margin-top: 0.5%;cursor:pointer;" id="ModalClose" onclick="return CloseModal();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px">
                        <h3 id="hHeaderModalText" style="font-family: Calibri;">Additional Information</h3>
                    </div>
                    <div id="ModalBody" class="modal-bodyQtn">
                        <div id="divErrorRsn" style="visibility: hidden; font-size: 15px; padding-top: 0.5%; padding-bottom: 0.5%;float: left;width: 100%;color: #53844E;">
                            <asp:Label ID="lblErrorRsn" style="text-align: center;width: 100%;float: left;" runat="server"></asp:Label>
                        </div>
                        <div style="padding-top: 1%;">

                            <div class="eachform" style="padding:5px;width:97%;margin-bottom: 0px;">
                                <h2 style="float: left;margin-top: 4px;margin-left: 5%;" >Reference </h2>
                                <div class="subform" style="margin-left: 2%;float: right;" >
                                   <asp:DropDownList ID="ddlReference" class="form2"   style="width: 75%; text-transform: uppercase; margin-right: 6.4%; height: 30px" onchange="ddlreferenceChange();" onkeypress=" return DisableEnter(event);" runat="server">
                                    <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="CONSULTANCY" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="DIVISION" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="DEPARTMENT" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="EMPLOYEE" Value="4"></asp:ListItem>
                                   </asp:DropDownList>

                                </div>
                            </div>

                             <div id="divConsultAdd" class="eachform" style="padding:5px;width:97%;margin-bottom: 0px;display:none;">
                                <h2 style="float: left;margin-top: 4px;margin-left: 5%;" >Consultancy </h2>
                                <div class="subform" style="margin-left: 2%;float: right;" >
                                   <asp:DropDownList ID="ddlConsultancy" class="form2"   style="width: 75%; text-transform: uppercase; margin-right: 6.4%; height: 30px"  onkeypress=" return DisableEnter(event);" runat="server">
                                   </asp:DropDownList>

                                </div>
                            </div>

                             <div id="divDivAdd" class="eachform" style="padding:5px;width:97%;margin-bottom: 0px;display:none;">
                                <h2 style="float: left;margin-top: 4px;margin-left: 5%;" >Division </h2>
                                <div class="subform" style="margin-left: 2%;float: right;" >
                                   <asp:DropDownList ID="ddlDivision" class="form2"   style="width: 75%; text-transform: uppercase; margin-right: 6.4%; height: 30px"  onkeypress=" return DisableEnter(event);" runat="server">
                                   </asp:DropDownList>

                                </div>
                            </div>

                             <div id="divDepartAdd" class="eachform" style="padding:5px;width:97%;margin-bottom: 0px;display:none;">
                                <h2 style="float: left;margin-top: 4px;margin-left: 5%;" >Department </h2>
                                <div class="subform" style="margin-left: 2%;float: right;" >
                                   <asp:DropDownList ID="ddlDepartment" class="form2"   style="width: 75%; text-transform: uppercase; margin-right: 6.4%; height: 30px"  onkeypress=" return DisableEnter(event);" runat="server">
                                   </asp:DropDownList>

                                </div>
                            </div>

                             <div id="divEmpAdd" class="eachform" style="padding:5px;width:97%;margin-bottom: 0px;display:none;">
                                <h2 style="float: left;margin-top: 4px;margin-left: 5%;" >Employee </h2>
                                <div class="subform" style="margin-left: 2%;float: right;" >
                                   <asp:DropDownList ID="ddlEmployee" class="form2"   style="width: 75%; text-transform: uppercase; margin-right: 6.4%; height: 30px"  onkeypress=" return DisableEnter(event);" runat="server">
                                   </asp:DropDownList>

                                </div>
                            </div>
                             <div id="div2" class="eachform" style="padding:5px;width:97%;margin-bottom: 0px;">
                                <h2 style="float: left;margin-top: 4px;margin-left: 5%;" >Skip Interview </h2>
                                 <asp:CheckBox class="form2" Style="margin-left: 3%;font-family: calibri;color: #738f3e;" ID="cbxSkipIntrw" Text="YES" runat="server" />
                                 </div>
                               <p id="pRowCount" style="display: none;"></p>
                     <div id="div1" class="eachform" style="padding:5px;width:97%;margin-bottom: 0px;">
                        <div class="subform" style="width: 35%;margin-right: 31%;">

                            <button id="btnSaveAdditional" type="button" class="save" onclick="return SaveAdditional();">Save</button>
                        </div>
                     </div>
                    </div>
                     </div>
                </div>

            </div>

     <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
            </div>



    <style>
        .cont_rght {
            width: 97%;
        }

        .save {
            width: 100%;
        }

        .lblTop {
            width: 232px;
            padding: 0px 8px;
            border: 1px solid #cfcccc;
            float: right;
            color: #000;
            font-size: 14px;
            font-family: calibri;
            word-wrap: break-word;
        }

        .modalAdd {
            display: none;
position: fixed;
z-index: 30;
padding-top: 0%;
left: 0;
top: 0;
width: 30%;
overflow: auto;
background-color: transparent;
padding-bottom: 2%;
        }
        .modal-contentAdd {
            position: relative;
background-color: #fefefe;
margin: auto;
padding: 0;
border: 1px solid #888;
width: 96.3%;
box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
-webkit-animation-name: animatetop;
-webkit-animation-duration: 0.70s;
animation-name: animatetop;
animation-duration: 0.70s;
        }
.modal-headerAdd {
    padding: 0% 1%;
    background-color: #9ba48b;
    color: white;
}
        .closeAdd {
            color: white;
float: right;
font-size: 28px;
font-weight: bold;
        }
    </style>
</asp:Content>

