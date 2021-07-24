<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Immigration_Round.aspx.cs" Inherits="HCM_HCM_Master_hcm_Immigration_hcm_Immigration_Rounds_hcm_Immigration_Round" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <style>
        .cont_rght {
            padding-bottom: 2%;
            padding-top: 2%;
            width: 95%;
        }

        input[type="radio"] {
            display: table-cell;
        }
    </style>

    <style>
        #TableHeaderRounds {
            background-color: #A4B487;
            color: white;
            font-weight: bold;
            font-family: calibri;
            line-height: 30px;
        }
    </style>

    <script src="/JavaScript/jquery-1.8.3.min.js"></script>

    <script>
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }

        //load fn
        var $noCon = jQuery.noConflict();

        $noCon(window).load(function () {

            document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";
        document.getElementById('divBlank').style.visibility = "hidden";

        document.getElementById("<%=lblIndex.ClientID%>").style.visibility = "hidden";

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
                    if (json[key].ImgratnRndId != "") {



                        EditListRows(json[key].ImgratnRndDtlId, json[key].ImgratnRndDtlName, json[key].ImgratnRndDtlStatus, json[key].ImgratnRndDtlComplt);


                    }
                }
            }


        }

        else if (ViewVal != "") {

            document.getElementById("<%=txtImmigratnRnd.ClientID%>").disabled = true;
                $("div#divtxtImmigratn input.ui-autocomplete-input").attr("disabled", "disabled");


                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = ViewVal.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');

                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        if (json[key].ImgratnRndId != "") {

                            ViewListRows(json[key].ImgratnRndDtlId, json[key].ImgratnRndDtlName, json[key].ImgratnRndDtlStatus, json[key].ImgratnRndDtlComplt);

                        }
                    }
                }

            }

        if (ViewVal == "") {

            //add rows except for view

            AddMoreRows(this.form, false, false, 0);

            if (EditVal == "" && ViewVal == "") {

                //1st radiobtn checked on adding

                document.getElementById("radioComplt" + 1).checked = true;


            }
        }
    });

    </script>

    <script>
        function ConfirmMessage() {

            if (confirmbox > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href = "hcm_Immigration_Rounds_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "hcm_Immigration_Rounds_List.aspx";
                return false;
            }
        }


        function ConfirmClear() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to clear?")) {
                    window.location.href = "hcm_Immigration_Round.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "hcm_Immigration_Round.aspx";
                return false;
            }
        }


    </script>

    <script>
        function CheckDupImgRndName() {
            //check duplication of round name
            ret = false;
            var strOrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
            var strCorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var strRndName = "";
            var strRndId = "";
            strRndName = document.getElementById("<%=txtImmigratnRnd.ClientID%>").value;
            strRndId = document.getElementById("<%=hiddenImmigratnId.ClientID%>").value;
            $co = jQuery.noConflict();
            $co.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "hcm_Immigration_Round.aspx/CheckDupImgRndName",
                data: '{strImgrtnRndId:"' + strRndId + '",strImgrtnRndName:"' + strRndName + '",strOrgId:"' + strOrgId + '",strCorpId:"' + strCorpId + '"}',
                dataType: "json",
                success: function (data) {

                    if (data.d == "0") {
                        //valid
                        ret = true;

                    }
                    else {
                        //Duplicated
                        ret = false;
                    }

                },
                error: function (data) {

                }

            });
            return ret;
        }
    </script>


    <script>

        var $noC = jQuery.noConflict();
        var rowCount = 0;
        var RowIndex = 0;


        function AddMoreRows(frm, boolFocus, boolAppendorNot, row_index) {

            document.getElementById('divErrorNotification').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";

            document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();

            RowIndex++;
            rowCount++;

            var recRow = '<tr id="rowId_' + rowCount + '" >';
            recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
            recRow += '<td style="width: 6%;text-align: center;padding: 2px;padding-right: 5px;"><div id="divSlNo' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


            recRow += ' <td id="tdDTLName' + rowCount + '"  style="width: 71%;padding: 4px;">';
            recRow += ' <input  id="txtDTLName' + rowCount + '"  class="BillngEntryField"  type="text"  onkeypress="return isTag(event)" onblur="return BlurValue(\'txtDTLName\',' + rowCount + ')"   maxlength=100 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;text-transform: uppercase;"/>';
            recRow += ' </td> ';


            recRow += ' <td style="width: 8%;padding: 4px;"><div id="divcbStatus' + rowCount + '" style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 100%;margin-left: 12%;"><input  id="cbStatus' + rowCount + '" checked="true" style="margin-left: 40%;" class="BillngEntryField" type="checkbox"  onchange="IncrmntConfrmCounter();" onblur="return BlurValue(\'cbStatus\',' + rowCount + ')" /></div></td>';
            recRow += ' <td style="width: 8%;padding: 4px;"><div id="divradioComplt' + rowCount + '" style="background-color: white;border: 1px solid #7A7A7A;line-height: 24px;margin-bottom: 4px; width: 100%;margin-left: 9%;"><input  id="radioComplt' + rowCount + '" style="margin-left: 40%;" class="BillngEntryField" type="radio" name="RadioSkCer" onchange="IncrmntConfrmCounter();" onblur="return BlurValue(\'radioComplt\',' + rowCount + ')"/></div></td>';

            recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 4%; padding-left: 4px;margin-left:20%"> <input id="tdIndvlAddMoreRowPic' + rowCount + '" type="image" class="BillngEntryField" src="/Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);" title="ADD" style="cursor: pointer;margin-left: 18%;"></td>';
            recRow += '<td id="tdIndvlDeleteMoreRow' + rowCount + '" style="width: 3%; padding-left: 2px;"><input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this entry?\');"  title="DELETE"  style=" cursor: pointer;" ></td>';


            recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
            recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
            recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">INS</td>';
            recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;"></td>';


            recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
            recRow += '</tr>';



            jQuery('#TableaddedRows').append(recRow);



        }


        function EditListRows(ImgratnRndDtlId, ImgratnRndDtlName, ImgratnRndDtlStatus, ImgratnRndDtlComplt) {

            //edit


            if (ImgratnRndDtlId != "" && ImgratnRndDtlName != "") {

                rowCount++;
                RowIndex++;
                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 6%;text-align: center;padding: 2px;padding-right: 5px;"><div id="divSlNo' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


                recRow += ' <td id="tdDTLName' + rowCount + '"  style="width: 71%;padding: 4px;">';
                recRow += ' <input  id="txtDTLName' + rowCount + '"  class="BillngEntryField"  type="text" value="' + ImgratnRndDtlName + '"  onkeypress="return isTag(event)" onblur="return BlurValue(\'txtDTLName\',' + rowCount + ')"   maxlength=95 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;text-transform: uppercase;"/>';
                recRow += ' </td> ';


                recRow += '<td style="width: 8%;padding: 4px;"><div id="divcbStatus' + rowCount + '" style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 100%;margin-left: 12%;"><input  id="cbStatus' + rowCount + '" style="margin-left: 40%;" class="BillngEntryField" type="checkbox" onchange="IncrmntConfrmCounter();"  onblur="return BlurValue(\'cbStatus\',' + rowCount + ')" /></div></td>';

                recRow += '<td style="width: 8%;padding: 4px;"><div id="divradioComplt' + rowCount + '" style="background-color: white;border: 1px solid #7A7A7A;line-height: 24px;margin-bottom: 4px; width: 100%;margin-left: 9%;"><input  id="radioComplt' + rowCount + '" style="margin-left: 40%;" class="BillngEntryField" type="radio" name="RadioSkCer" onchange="IncrmntConfrmCounter();"  onblur="return BlurValue(\'radioComplt\',' + rowCount + ')"/></div></td>';

                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 4%; padding-left: 4px;margin-left:20%"> <input id="tdIndvlAddMoreRowPic' + rowCount + '" type="image" class="BillngEntryField" src="/Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);" title="ADD" style="cursor: pointer;margin-left: 18%;"></td>';
                recRow += '<td id="tdIndvlDeleteMoreRow' + rowCount + '" style="width: 3%; padding-left: 2px;"><input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this entry?\');"  title="DELETE"  style=" cursor: pointer;" ></td>';


                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + ImgratnRndDtlId + '</td>';


                recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                recRow += '</tr>';


                jQuery('#TableaddedRows').append(recRow);
                document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";

                if (ImgratnRndDtlStatus == "1") {
                    document.getElementById("cbStatus" + rowCount).checked = true;
                }
                if (ImgratnRndDtlComplt == "1") {
                    document.getElementById("radioComplt" + rowCount).checked = true;
                }
                else {
                    document.getElementById("radioComplt" + rowCount).checked = false;
                }

                var DelImgrtnRndDtl = document.getElementById("<%=hiddenDel.ClientID%>").value;

                if (DelImgrtnRndDtl == ImgratnRndDtlId) {
                    document.getElementById("tdIndvlDeleteMoreRow" + rowCount).style.opacity = "0.3";
                    document.getElementById("tdIndvlDeleteMoreRow" + rowCount).style.pointerEvents = "none";
                }

                LocalStorageAdd(rowCount);

            }
            else {


            }

        }
        function ViewListRows(ImgratnRndDtlId, ImgratnRndDtlName, ImgratnRndDtlStatus, ImgratnRndDtlComplt) {

            if (ImgratnRndDtlId != "" && ImgratnRndDtlName != "") {

                //view
                rowCount++;
                RowIndex++;

                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();

                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 6%;text-align: center;padding: 2px;padding-right: 5px;"><div id="divSlNo' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


                recRow += ' <td id="tdDTLName' + rowCount + '"  style="width: 71%;padding: 4px;">';
                recRow += ' <input disabled id="txtDTLName' + rowCount + '"  class="BillngEntryField"  type="text" value="' + ImgratnRndDtlName + '" onkeypress="return isTag(event)" onblur="return BlurValue(\'txtDTLName\',' + rowCount + ')"   maxlength=95 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;text-transform: uppercase;"/>';
                recRow += ' </td> ';


                recRow += '<td style="width: 8%;padding: 4px;"><div id="divcbStatus' + rowCount + '" style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 100%;margin-left: 12%;"><input disabled id="cbStatus' + rowCount + '" style="margin-left: 40%;" class="BillngEntryField" type="checkbox" onchange="IncrmntConfrmCounter();" onblur="return BlurValue(\'cbStatus\',' + rowCount + ')" /></div></td>';

                recRow += '<td style="width: 8%;padding: 4px;"><div id="divradioComplt' + rowCount + '" style="background-color: white;border: 1px solid #7A7A7A;line-height: 24px;margin-bottom: 4px; width: 100%;margin-left: 9%;"><input disabled id="radioComplt' + rowCount + '" style="margin-left: 40%;" class="BillngEntryField" type="radio" name="RadioSkCer" onchange="IncrmntConfrmCounter();" onblur="return BlurValue(\'radioComplt\',' + rowCount + ')"/></div></td>';


                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 4%; padding-left: 4px;margin-left:20%"> <input disabled id="tdIndvlAddMoreRowPic' + rowCount + '" type="image" class="BillngEntryField" src="/Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);" title="ADD" style="cursor: pointer;margin-left: 18%;"></td>';
                recRow += '<td id="tdIndvlDeleteMoreRow' + rowCount + '" style="width: 3%; padding-left: 2px;"><input type="image" class="BillngEntryField" disabled="disabled" src="/Images/Icons/deleteEntry.png" alt="Delete" title="DELETE"  style=" cursor: pointer;" ></td>';

                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + ImgratnRndDtlId + '</td>';

                recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                recRow += '</tr>';


                jQuery('#TableaddedRows').append(recRow);
                document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";


                if (ImgratnRndDtlStatus == "1") {
                    document.getElementById("cbStatus" + rowCount).checked = true;
                }
                if (ImgratnRndDtlComplt == "1") {
                    document.getElementById("radioComplt" + rowCount).checked = true;
                }
                else {
                    document.getElementById("radioComplt" + rowCount).checked = false;
                }

                LocalStorageAdd(rowCount);

            }
            else {


            }

        }


        function BlurValue(obj, x) {

            RemoveTag('txtDTLName' + x);

            if (obj == 'txtDTLName') {

                CompareDTLNames(x);
            }

            var row_index = jQuery('#rowId_' + x).index();

            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;

            if (SavedorNot == "saved") {

                // if saved, Update to local storage

                LocalStorageEdit(x, row_index);
            }
            else {

                if (CheckAllRowFieldAndHighlight(x, true) == true) {

                    if (SavedorNot == " ") {

                        //if not saved, Add to local storage

                        LocalStorageAdd(x);
                    }
                }
                else {
                    document.getElementById(obj + x).value = "";
                }
            }
        }


        function CompareDTLNames(x) {
            //comparing if rnd details are same values

            var tableNameCh = document.getElementById("TableaddedRows");

            ChDtlName = document.getElementById("txtDTLName" + x).value;
            ChDtlName = ChDtlName.toUpperCase();
            if (tableNameCh.rows.length >= 1) {
                for (var i = 0; i < tableNameCh.rows.length; i++) {

                    // FIX THIS
                    var row = tableNameCh.rows[i];

                    var xLoop = (tableNameCh.rows[i].cells[0].innerHTML);
                    if (xLoop != x) {

                        var txtName = document.getElementById("txtDTLName" + xLoop).value;
                        txtName = txtName.toUpperCase();

                        if (txtName == ChDtlName) {
                            alert("Duplication not allowed in Round status");
                            document.getElementById("txtDTLName" + x).value = "";
                            document.getElementById("txtDTLName" + x).style.borderColor = "Red";
                            document.getElementById("txtDTLName" + x).focus();
                        }
                    }

                }
            }
        }

        // checks every field in row filled
        function CheckAllRowFieldAndHighlight(x, blFromBlurValue) {
            ret = true;
            var DtlName = document.getElementById("txtDTLName" + x).value;

            document.getElementById("txtDTLName" + x).style.borderColor = "";

            if (DtlName == "") {
                document.getElementById("txtDTLName" + x).style.borderColor = "Red";
                return false;
            }
            return true;
        }

        //Store
        function LocalStorageAdd(x) {
            //when adding
            var tbClientRndDtl = localStorage.getItem("tbClientRndDtl");//Retrieve the stored data

            tbClientRndDtl = JSON.parse(tbClientRndDtl); //Converts string to object

            if (tbClientRndDtl == null) //If there is no data, initialize an empty array
                tbClientRndDtl = [];
            var detailId = document.getElementById("tdDtlId" + x).innerHTML;
            var evt = document.getElementById("tdEvt" + x).innerHTML;

            //add inserting
            if (evt == 'INS') {
                var $add = jQuery.noConflict();
                var cbValue = 0;
                if ($add("#cbStatus" + x).is(":checked")) {
                    // staus is checked
                    cbValue = 1;
                }
                var radioValue = 0;
                if ($add("#radioComplt" + x).is(":checked")) {
                    // radiobtn is checked

                    radioValue = 1;
                }
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    DTLNAME: $add("#txtDTLName" + x).val(),
                    DTLSTATUS: "" + cbValue + "",
                    DTLCMPLT: "" + radioValue + "",
                    EVTACTION: "" + evt + "",
                    DTLID: "0"

                });

            }
            else if (evt == 'UPD') {
                var $add = jQuery.noConflict();
                var cbValue = 0;
                if ($add("#cbStatus" + x).is(":checked")) {
                    // status is checked
                    cbValue = 1;
                }
                var radioValue = 0;
                if ($add("#radioComplt" + x).is(":checked")) {
                    // radiobtn is checked
                    radioValue = 1;
                }
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    DTLNAME: $add("#txtDTLName" + x).val(),
                    DTLSTATUS: "" + cbValue + "",
                    DTLCMPLT: "" + radioValue + "",
                    EVTACTION: "" + evt + "",
                    DTLID: "" + detailId + ""
                });
            }

            tbClientRndDtl.push(client);
            localStorage.setItem("tbClientRndDtl", JSON.stringify(tbClientRndDtl));

            $add("#cphMain_HiddenField1").val(JSON.stringify(tbClientRndDtl));



            document.getElementById("tdSave" + x).innerHTML = "saved";
            var h = document.getElementById("<%=HiddenField1.ClientID%>").value;
            return true;
        }

        function LocalStorageEdit(x, row_index) {
            //when editing
            var tbClientRndDtl = localStorage.getItem("tbClientRndDtl");//Retrieve the stored data


            tbClientRndDtl = JSON.parse(tbClientRndDtl); //Converts string to object

            if (tbClientRndDtl == null) //If there is no data, initialize an empty array
                tbClientRndDtl = [];

            var detailId = document.getElementById("tdDtlId" + x).innerHTML;
            var evt = document.getElementById("tdEvt" + x).innerHTML;


            //edit inserting
            if (evt == 'INS') {

                var $add = jQuery.noConflict();
                var cbValue = 0;
                if ($add("#cbStatus" + x).is(":checked")) {
                    // staus is checked
                    cbValue = 1;

                }
                var radioValue = 0;
                if ($add("#radioComplt" + x).is(":checked")) {
                    // radiobtn is checked
                    radioValue = 1;
                }

                tbClientRndDtl[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    DTLNAME: $add("#txtDTLName" + x).val(),
                    DTLSTATUS: "" + cbValue + "",
                    DTLCMPLT: "" + radioValue + "",
                    EVTACTION: "" + evt + "",
                    DTLID: "0"

                });//Alter the selected item on the table

            }
            else {
                //edit updating
                var $add = jQuery.noConflict();
                var cbValue = 0;
                if ($add("#cbStatus" + x).is(":checked")) {
                    // staus is checked
                    cbValue = 1;

                }
                var radioValue = 0;
                if ($add("#radioComplt" + x).is(":checked")) {
                    // radiobtn is checked

                    radioValue = 1;
                }

                tbClientRndDtl[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    DTLNAME: $add("#txtDTLName" + x).val(),
                    DTLSTATUS: "" + cbValue + "",
                    DTLCMPLT: "" + radioValue + "",
                    EVTACTION: "" + evt + "",
                    DTLID: "" + detailId + ""

                });//Alter the selected item on the table

            }


            localStorage.setItem("tbClientRndDtl", JSON.stringify(tbClientRndDtl));
            $add("#cphMain_HiddenField1").val(JSON.stringify(tbClientRndDtl));

            return true;
        }


        function CheckaddMoreRowsIndividual(x, retBool) {

            // for add image in each row

            IncrmntConfrmCounter();
            var check = document.getElementById("tdInx" + x).innerHTML;

            //check=null as innerhtml

            //for checking if to save  or else if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            if (check == " ") {


                if (retBool == true) {

                    if (CheckAllRowFieldAndHighlight(x, false) == true) {


                        document.getElementById("tdInx" + x).innerHTML = x;
                        document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";

                        AddMoreRows(this.form, retBool, false, 0);

                        document.getElementById('txtDTLName' + rowCount).focus();
                        ReNumberTable();
                        return false;

                    }
                }
                else if (retBool == false) {
                    var row_index = jQuery('#rowId_' + x).index();
                    if (CheckAllRowField(x, row_index) == true) {
                        document.getElementById("tdInx" + x).innerHTML = x;
                        document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";

                        AddMoreRows(this.form, retBool, false, 0);
                        document.getElementById('txtDTLName' + rowCount).focus();
                        ReNumberTable();
                        return false;
                    }
                }

            }

            return false;
        }



        function removeRow(removeNum, CofirmMsg) {
            //delete rows
            if (confirm(CofirmMsg)) {



                //if deleting radiobtn checkd row
                if (document.getElementById("radioComplt" + removeNum).checked == true) {

                    var row_index = jQuery('#rowId_' + removeNum).index();

                    LocalStorageDelete(row_index, removeNum);

                    jQuery('#rowId_' + removeNum).remove();

 

                    RowIndex--;
                    document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();

                    var TableRowCount = document.getElementById("TableaddedRows").rows.length;

                    if (TableRowCount != 0) {
                        var idlast = $noC('#TableaddedRows tr:last').attr('id');

                        if (idlast != "") {


                            var res = idlast.split("_");

                            document.getElementById("tdInx" + res[1]).innerHTML = " ";
                            document.getElementById("tdIndvlAddMoreRow" + res[1]).style.opacity = "1";
                            document.getElementById("tdIndvlAddMoreRowPic" + res[1]).disabled = false;

                        }

                    }

                    else {

                        AddMoreRows(this.form, true, false, 0);

                        for (var Rwi = rowCount; Rwi >= 0; Rwi--) {
                            if (document.getElementById("radioComplt" + Rwi) != null) {
                                document.getElementById("radioComplt" + Rwi).checked = true;
                                BlurValue('radioComplt', Rwi);
                                break;
                            }
                        }
                    }


                    if (removeNum != rowCount) {

                        for (var Rwi = rowCount; Rwi >= 0; Rwi--) {

                            if (document.getElementById("radioComplt" + Rwi) != null) {
                                document.getElementById("radioComplt" + Rwi).checked = true;
                                BlurValue('radioComplt', Rwi);
                                break;

                            }
                        }
                    }

                    else {

                        for (var CCcount = rowCount; CCcount >= 0; CCcount--) {

                            if (document.getElementById("radioComplt" + CCcount) != null) {
                                document.getElementById("radioComplt" + CCcount).checked = true;
                                BlurValue('radioComplt', Rwi);
                                break;
                            }
                        }
                    }

                }
                else {

                    //if deleting radibtn not checkd row

                    var row_index = jQuery('#rowId_' + removeNum).index();

                    LocalStorageDelete(row_index, removeNum);

                    jQuery('#rowId_' + removeNum).remove();

                    RowIndex--;
                    document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();

                    var TableRowCount = document.getElementById("TableaddedRows").rows.length;

                    if (TableRowCount != 0) {
                        var idlast = $noC('#TableaddedRows tr:last').attr('id');

                        if (idlast != "") {


                            var res = idlast.split("_");

                            document.getElementById("tdInx" + res[1]).innerHTML = " ";
                            document.getElementById("tdIndvlAddMoreRow" + res[1]).style.opacity = "1";
                            document.getElementById("tdIndvlAddMoreRowPic" + res[1]).disabled = false;

                        }

                    }

                    else {
                        

                        AddMoreRows(this.form, true, false, 0);

                        for (var Rwi = rowCount; Rwi >= 0; Rwi--) {
                            if (document.getElementById("radioComplt" + Rwi) != null) {
                                document.getElementById("radioComplt" + Rwi).checked = true;
                                BlurValue('radioComplt', Rwi);
                                break;
                            }
                        }

                    }
                }

                ReNumberTable();
            }


            else {
                return false;
            }
        }


        function LocalStorageDelete(row_index, x) {

            var tbClientRndDtl = localStorage.getItem("tbClientRndDtl");//Retrieve the stored data

            tbClientRndDtl = JSON.parse(tbClientRndDtl); //Converts string to object

            if (tbClientRndDtl == null) //If there is no data, initialize an empty array
                tbClientRndDtl = [];

            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            tbClientRndDtl.splice(row_index, 1);
            localStorage.setItem("tbClientRndDtl", JSON.stringify(tbClientRndDtl));
            $noCon("#cphMain_HiddenField1").val(JSON.stringify(tbClientRndDtl));



            var evt = document.getElementById("tdEvt" + x).innerHTML;
            if (evt == 'UPD') {
                var detailId = document.getElementById("tdDtlId" + x).innerHTML;

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

                                      document.getElementById("divSlNo" + x).innerHTML = intRecount
                                      var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
                                      if (SavedorNot == "saved") {
                                      }
                                  }
                              }

                              //iterate through columns
                              //columns would be accessed using the "col" variable assigned in the for loop

                          }
                      }
                  }





                  function ValidateAndSave(mode) {

                      var ret = true;

                      document.getElementById("<%=txtImmigratnRnd.ClientID%>").style.borderColor = "";

                      var table = "";

                      var x = document.getElementById("TableaddedRows").rows.length;

                      if (x < 1) {
                          ErrMsg();

                          ret= false;
                      }

                      table = document.getElementById("TableaddedRows");


                      var xLast = (table.rows[table.rows.length - 1].cells[0].innerHTML);
                      document.getElementById("txtDTLName" + xLast).style.borderColor = "";

                      var DtlName = document.getElementById("txtDTLName" + xLast).value;

                      //checking if radiobtn clicked and rnd detail not entered for the last row

                      if (document.getElementById('radioComplt' + xLast).checked == true && DtlName == "") {
                          document.getElementById("txtDTLName" + xLast).style.borderColor = "Red";
                          document.getElementById("txtDTLName" + xLast).focus();
                          ErrMsg();
                          ret= false;
                      }

                      if (document.getElementById("<%=HiddenField1.ClientID%>").value == "") {
                          ErrMsg();
                          ret= false;
                      }

                      ImgRndName = document.getElementById("<%=txtImmigratnRnd.ClientID%>").value.trim();
                      if (ImgRndName == "") {
                          document.getElementById("<%=txtImmigratnRnd.ClientID%>").style.borderColor = 'Red';
                          document.getElementById("<%=txtImmigratnRnd.ClientID%>").focus();
                          ErrMsg();
                          ret = false;
                      }
                      else {

                          if (CheckDupImgRndName() != true) {
                              //rnd name dup msg
                              DuplicateImgRndName();
                              ret = false;
                          }
                      }

                      if (ret == true) {

                          //to find the row with radiobtn clicked
                          var Cbx = true;
                          for (var i = 0; i <= rowCount; i++) {
                              if (document.getElementById('radioComplt' + i) != null)
                                  if (document.getElementById('radioComplt' + i).checked == true) {

                                      var dtlname = document.getElementById('txtDTLName' + i).value;

                                      var dtlstatus = 0;
                                      if (document.getElementById('cbStatus' + i).checked == true)
                                          dtlstatus = 1;

                                      //checking if radiobutton clicked when checkbox not checked
                                      if (dtlstatus == 0) {

                                          document.getElementById('divcbStatus' + i).style.borderColor = "Red";
                                          document.getElementById('divcbStatus' + i).focus();

                                          document.getElementById('divradioComplt' + i).style.borderColor = "Red";
                                          document.getElementById('divradioComplt' + i).focus();
                                          ErrMsg();
                                          ret = false;
                                      }

                                      var dtlid = document.getElementById("tdDtlId" + i).innerHTML;

                                      //contains id of row with radiobtn clicked

                                      document.getElementById("<%=hiddenDtlID.ClientID%>").value = dtlid;

                                      Cbx = false;

                                  }
                          }
                      }

                      return ret;

                  }


    </script>


    <script>

        function CancelNotPossible() {
            alert("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
            return false;
        }


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

        // for not allowing <> tags
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

        function isTagWithEnter(evt) {
            IncrmntConfrmCounter();
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }
        // for not allowing enter
        function DisableEnter(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
            else {
                return true;
            }
        }


        function RemoveTag(obj) {

            var txt = document.getElementById(obj).value.trim();
            var replaceText1 = txt.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(obj).value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtImmigratnRnd.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtImmigratnRnd.ClientID%>").value = replaceText2;
        }


        function SuccessIns() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Immigration Round status inserted successfully.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function DuplicateImgRndName() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Immigration Round name can’t be duplicated.";
            document.getElementById("<%=txtImmigratnRnd.ClientID%>").focus();
            document.getElementById("<%=txtImmigratnRnd.ClientID%>").style.borderColor = 'Red';
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Immigration Round status updated successfully.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function ErrMsg() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
        }
        function SuccessStatusChange() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Immigration Round status changed successfully.";
        }

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">

    <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hiddenImmigratnId" runat="server" />
    <asp:HiddenField ID="HiddenFieldClose" runat="server" />
    <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
    <asp:HiddenField ID="hiddenEdit" runat="server" />
    <asp:HiddenField ID="hiddenView" runat="server" />
    <asp:HiddenField ID="hiddenDtlID" runat="server" />
     <asp:HiddenField ID="hiddenDel" runat="server" />


    <asp:Label ID="lblIndex" runat="server"></asp:Label>


    <div id="divMessageArea" style="display: none; margin: 0px 0 13px;">
        <img id="imgMessageArea" src="">
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>

    <div id="div1" class="list" onclick="ConfirmMessage();" runat="server" style="height: 26.5px; float: right;"></div>

    <div class="cont_rght">

        <div class="fillform" style="width: 100%;">

            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">

                <asp:Label ID="lblEntry" runat="server" Style="margin-left: 15%"></asp:Label>

            </div>

            <div id="divtxtImmigratn" style="width: 46%; margin-top: 5%; margin-left: 23%;" class="eachform">
                <h2 style="margin-top: 0%; float: left; padding-right: 7%;">Immigration Round *</h2>
                <asp:TextBox runat="server" ID="txtImmigratnRnd" Style="width: 50%; margin-left: 10%; text-transform: uppercase;" MaxLength="95" onkeypress="return isTag(event);" onblur="return RemoveTag('cphMain_txtImmigratnRnd');" class="form1" />
            </div>

            <div id="divStatus" style="width: 55%; margin-top: 0.2%; float: left; margin-left: 23%;" class="eachform">
                <h2 style="margin-top: 0%; float: left; padding-right: 2%;">Status *</h2>
                <div class="subform" style="width: 215px; float: left; margin-left: 31.58%;">
                    <asp:CheckBox ID="cbxCnclStatus" Text="" Style="margin-left: -10%" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server" Checked="true" class="form2" />
                    <h3 style="margin-top: 1%;">Active</h3>
                </div>
            </div>

            <div class="leads_form" style="width: 80%; margin-left: 10%; margin-top: 2%">

                <div id="divErrorNotification" style="visibility: hidden">
                    <asp:Label ID="lblErrorNotification" runat="server"></asp:Label>
                </div>

                <div id="divTables" style="width: 95%; margin: auto; margin-top: -3%; margin-left: 20% padding-top: 0.6%;">

                    <h2 style="margin-top: 1%;">Statuses</h2>

                    <table id="TableHeaderRounds" rules="all" style="width: 100%; margin-top: 6%">

                        <tr>
                            <td style="font-size: 14px; width: 6%; padding-left: 0.5%;">Sl#</td>
                            <td style="font-size: 14px; width: 71%; padding-left: 0.5%;">Name</td>
                            <td style="font-size: 14px; width: 8%; padding-left: 0.5%;">Active</td>
                            <td style="font-size: 14px; width: 8%; padding-left: 0.5%;">Complete</td>

                            <td id="spanAddRow" style="width: 7%; background: rgb(244, 246, 240) none repeat scroll 0% 0%;">
                                <img src="/Images/Icons/addEntry.png" style="cursor: pointer; width: 100%; height: 30px; display: none" onclick="CheckaddMoreRowsIndividual();" />
                            </td>
                        </tr>
                    </table>

                    <div style="width: 100%; min-height: 75px; overflow-y: auto;">
                        <table id="TableaddedRows" style="width: 100%;">
                        </table>
                    </div>

                    <div id="divBlank" style="background-color: rgb(249, 246, 3); font-size: 10.5px; color: black; opacity: 0.6;"></div>


                </div>

            </div>


            <div class="eachform" style="margin-top: -1.5%;">
                <div class="subform" style="margin-left: 36.8%; width: 70%; margin-top: 3%;">

                    <asp:Button ID="btnSave" runat="server" class="save" Text="Save" OnClientClick="return ValidateAndSave('Save');" OnClick="btnSave_Click" />
                    <asp:Button ID="btnSaveClose" runat="server" class="save" Text="Save & Close" OnClientClick="return ValidateAndSave('Save');" OnClick="btnSave_Click" />
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClientClick="return ValidateAndSave('Update');" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClientClick="return ValidateAndSave('Update');" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnClear" runat="server" class="save" Text="Clear" OnClientClick="return ConfirmClear();" />
                    <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" OnClientClick="return ConfirmMessage();" />

                </div>
            </div>


        </div>


    </div>



</asp:Content>

