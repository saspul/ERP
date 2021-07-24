<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" enableEventValidation="false" AutoEventWireup="true" CodeFile="Gen_Orgnization.aspx.cs" Inherits="Master_gen_Organization_Gen_Orgnization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
    <link href="/css/New css/hcm_ns.css" rel="stylesheet" />
     <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>
     <script language="javascript" type="text/javascript">
         var submit = 0;
         function CheckIsRepeat() {
             if (++submit > 1) {

                 return false;
             }
             else {
                 return true;
             }
         } function CheckSubmitZero() {
             submit = 0;
         }
    </script>
     <script>
         var $au = jQuery.noConflict();
         $au(function () {
             $au('#cphMain_ddlOrgCountry').selectToAutocomplete1Letter();
             $au('#cphMain_ddlOrgLicPac').selectToAutocomplete1Letter();
             $au('#cphMain_ddlOrgCorPac').selectToAutocomplete1Letter();
             $au('#cphMain_ddlOrgType').selectToAutocomplete1Letter();
         });
    </script>
    <script>
        function ConfirmMessage() {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "/Home/Compzit_Home/Compzit_Home_App.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });         
            return false;
        }
        function textbox() {
            document.getElementById("cphMain_txtOrgNewPwd").value = "";
            document.getElementById("cphMain_txtOrgPwd").value = "";
        }
        function SuccessUpdation() {
            $("#success-alert").html("Organization details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }



        function onChange() {


            if (document.getElementById("<%= cbxPswdVisible.ClientID %>").checked == true) {
                document.getElementById("<%= txtOrgPwd.ClientID %>").type = 'text';
                document.getElementById("<%= txtOrgConPwd.ClientID %>").type = 'text';
                document.getElementById("<%= txtOrgNewPwd.ClientID %>").type = 'text';

            }
            else {
                document.getElementById("<%= txtOrgPwd.ClientID %>").type = 'password';
                document.getElementById("<%= txtOrgConPwd.ClientID %>").type = 'password';
                document.getElementById("<%= txtOrgNewPwd.ClientID %>").type = 'password';

            }
            return false;
        }
    </script>
    <script>
        function RemoveTag(control) {

            var text = control.value;
            var replaceText1 = text.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            control.value = replaceText2;
        }
    </script>
    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            localStorage.clear();

          
            if (document.getElementById("<%=hiddenFileCR_Attach.ClientID%>").value != "") {

                var EditAttchmnt = document.getElementById("<%=hiddenFileCR_Attach.ClientID%>").value;

                var findAtt2 = '\\"\\[';
                var reAtt2 = new RegExp(findAtt2, 'g');
                var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                var findAtt3 = '\\]\\"';
                var reAtt3 = new RegExp(findAtt3, 'g');
                var resAtt3 = resAtt2.replace(reAtt3, '\]');
                var jsonAtt = $noCon.parseJSON(resAtt3);

                for (var key in jsonAtt) {

                    if (jsonAtt.hasOwnProperty(key)) {
                        if (jsonAtt[key].ORGFLS_ID != "") {

                            EditAttachmentCR(jsonAtt[key].ORGFLS_ID, jsonAtt[key].ORGFLS_FILENAME, jsonAtt[key].ORGFLS_FLNM_ACT, jsonAtt[key].ORGFLS_DSCRPTN);

                        }
                    }
                }
                AddFileUploadCr();
            }
            else {
                AddFileUploadCr();
            }

            if (document.getElementById("<%=hiddenFileTX_Attach.ClientID%>").value != "") {

                var EditAttchmnt = document.getElementById("<%=hiddenFileTX_Attach.ClientID%>").value;
                var findAtt2 = '\\"\\[';
                var reAtt2 = new RegExp(findAtt2, 'g');
                var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                var findAtt3 = '\\]\\"';
                var reAtt3 = new RegExp(findAtt3, 'g');
                var resAtt3 = resAtt2.replace(reAtt3, '\]');
                var jsonAtt = $noCon.parseJSON(resAtt3);

                for (var key in jsonAtt) {

                    if (jsonAtt.hasOwnProperty(key)) {
                        if (jsonAtt[key].ORGFLS_ID != "") {

                            EditAttachmentTX(jsonAtt[key].ORGFLS_ID, jsonAtt[key].ORGFLS_FILENAME, jsonAtt[key].ORGFLS_FLNM_ACT, jsonAtt[key].ORGFLS_DSCRPTN);

                        }
                    }
                }
                AddFileUploadTX();
            }
            else {
                AddFileUploadTX();
            }
            if (document.getElementById("<%=hiddenFileCOMP_Attach.ClientID%>").value != "") {

                var EditAttchmnt = document.getElementById("<%=hiddenFileCOMP_Attach.ClientID%>").value;
                var findAtt2 = '\\"\\[';
                var reAtt2 = new RegExp(findAtt2, 'g');
                var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                var findAtt3 = '\\]\\"';
                var reAtt3 = new RegExp(findAtt3, 'g');
                var resAtt3 = resAtt2.replace(reAtt3, '\]');
                var jsonAtt = $noCon.parseJSON(resAtt3);

                for (var key in jsonAtt) {

                    if (jsonAtt.hasOwnProperty(key)) {
                        if (jsonAtt[key].ORGFLS_ID != "") {



                            EditAttachmentCOMP(jsonAtt[key].ORGFLS_ID, jsonAtt[key].ORGFLS_FILENAME, jsonAtt[key].ORGFLS_FLNM_ACT, jsonAtt[key].ORGFLS_DSCRPTN);




                        }
                    }
                }
                AddFileUploadComp();
            }
            else {
                AddFileUploadComp();
            }

            if (document.getElementById("<%=hiddenPartner.ClientID%>").value != "" && document.getElementById("<%=hiddenPartner.ClientID%>").value != "[]") {

                var EditAttchmnt = document.getElementById("<%=hiddenPartner.ClientID%>").value;

                var findAtt2 = '\\"\\[';
                var reAtt2 = new RegExp(findAtt2, 'g');
                var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                var findAtt3 = '\\]\\"';
                var reAtt3 = new RegExp(findAtt3, 'g');
                var resAtt3 = resAtt2.replace(reAtt3, '\]');
                var jsonAtt = $noCon.parseJSON(resAtt3);

                for (var key in jsonAtt) {

                    if (jsonAtt.hasOwnProperty(key)) {
                        if (jsonAtt[key].ORGFLS_ID != "") {


                            EditListRows(jsonAtt[key].TransDtlId, jsonAtt[key].PartnerName, jsonAtt[key].DocumentNo, jsonAtt[key].CrNo, jsonAtt[key].ContyNo, jsonAtt[key].SharePer, jsonAtt[key].Status);

                        }
                    }
                }
                //addMoreRows(this.form, false, false, 0);
                var idlast = $noc1('#TableaddedRows tr:last').attr('id');
                if (idlast != "") {
                    var res = idlast.split("_");
                    document.getElementById("tdInx" + res[1]).innerHTML = " ";
                    document.getElementById("tdIndvlAddMoreRow" + res[1]).disabled = false;
                }
            }

            else {
                addMoreRows(this.form, false, false, 0);

            }
            FillDllLicPackLoad();
            FillDllCorpPackLoad();

            textbox();
            $("div#divLpack input.ui-autocomplete-input").select();
            $("div#divLpack input.ui-autocomplete-input").focus();
        });




    </script>
    <script type="text/javascript">
        var FileCounterPer = 0;
        var FileCounterIns = 100;
        var FileCounterVhcl = 200;

        function AddFileUploadCr() {


            var FrecRow = '<tr id="FilerowId_' + FileCounterPer + '" >';

            FrecRow += '<td class=" tr_l">';
            FrecRow += '<input type="file" id="filecr' + FileCounterPer + '" name = "filecr' + FileCounterPer + '" onchange="ChangeFilePer(\'filecr\',' + FileCounterPer + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" multiple="" >';
            FrecRow += '<label for="filecr' + FileCounterPer + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
            FrecRow += ' <div id="filePath' + FileCounterPer + '" class="file_n"></div>';
            FrecRow += '</td>';
            FrecRow += '<td class=" tr_l"><input id="descrptn' + FileCounterPer + '" MaxLength="100" value="--Description--" onfocus="focusTxtDescrptn(' + FileCounterPer + ');" onkeypress="return DisableEnter(event);"  onblur="blurTxtDescrptnPer(\'filecr\',' + FileCounterPer + ');" type="text" class="form-control fg2_inp2" placeholder="Description" name=""></td>';
            FrecRow += '<td>';
            FrecRow += '<div class="btn_stl1">';
            FrecRow += '<button id="FileIndvlAddMoreRow' + FileCounterPer + '" onclick="return CheckaddMoreRowsIndividualFilesCr(\'filecr\',' + FileCounterPer + ');" class="btn act_btn bn2"  title="Add">';
            FrecRow += '<i class="fa fa-plus-circle"></i>';
            FrecRow += ' </button>';
            FrecRow += '<button id="FieldId' + FileCounterPer + '" class="btn act_btn bn3"  title="Delete" onclick = "return RemoveFileUploadCr(' + FileCounterPer + ');">';
            FrecRow += '<i class="fa fa-trash"></i>';
            FrecRow += '</button>';
            FrecRow += '</div>';
            FrecRow += '</td>';

            FrecRow += ' <td id="FileInx' + FileCounterPer + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + FileCounterPer + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + FileCounterPer + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId' + FileCounterPer + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName' + FileCounterPer + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadCrAttachment').append(FrecRow);

            // $noCon('#divPerAtch').scrollTop($noCon('#divPerAtch')[0].scrollHeight);

            //var objDiv = document.getElementById('divPerAtch');
            //objDiv.scrollTop = objDiv.scrollHeight;


            document.getElementById('filePath' + FileCounterPer).innerHTML = 'No File Uploaded';

            //FileLocalStorageAddPer(FileCounterPer);
            FileCounterPer++;

        }
        function ClickFile() {
            //$("body").css("overflow", "hidden");
        }
        function AddFileUploadTX() {

            var FrecRow = '<tr id="FilerowId_' + FileCounterPer + '" >';


          
            FrecRow += '<td class=" tr_l">';
            FrecRow += '<input type="file" id="filetx' + FileCounterPer + '" name = "filetx' + FileCounterPer + '" onchange="ChangeFilePer(\'filetx\',' + FileCounterPer + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" multiple="" >';
            FrecRow += '<label for="filetx' + FileCounterPer + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
            FrecRow += ' <div id="filePath' + FileCounterPer + '" class="file_n"></div>';
            FrecRow += '</td>';
            FrecRow += '<td class=" tr_l"><input id="descrptn' + FileCounterPer + '" MaxLength="100" value="--Description--" onfocus="focusTxtDescrptn(' + FileCounterPer + ');" onkeypress="return DisableEnter(event);"  onblur="blurTxtDescrptnPer(\'filetx\',' + FileCounterPer + ');" type="text" class="form-control fg2_inp2" placeholder="Description" name=""></td>';
            FrecRow += '<td>';
            FrecRow += '<div class="btn_stl1">';
            FrecRow += '<button id="FileIndvlAddMoreRow' + FileCounterPer + '" onclick="return CheckaddMoreRowsIndividualFilesTX(\'filetx\',' + FileCounterPer + ');" class="btn act_btn bn2"  title="Add">';
            FrecRow += '<i class="fa fa-plus-circle"></i>';
            FrecRow += ' </button>';
            FrecRow += '<button id="FieldId' + FileCounterPer + '" class="btn act_btn bn3"  title="Delete" onclick = "return RemoveFileUploadTx(' + FileCounterPer + ');">';
            FrecRow += '<i class="fa fa-trash"></i>';
            FrecRow += '</button>';
            FrecRow += '</div>';
            FrecRow += '</td>';


            FrecRow += ' <td id="FileInx' + FileCounterPer + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + FileCounterPer + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + FileCounterPer + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId' + FileCounterPer + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName' + FileCounterPer + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadTXAttachment').append(FrecRow);

            // $noCon('#divPerAtch').scrollTop($noCon('#divPerAtch')[0].scrollHeight);

            //var objDiv = document.getElementById('divPerAtch');
            //objDiv.scrollTop = objDiv.scrollHeight;


            document.getElementById('filePath' + FileCounterPer).innerHTML = 'No File Uploaded';

            FileCounterPer++;

        }
        function AddFileUploadComp() {

            var FrecRow = '<tr id="FilerowId_' + FileCounterPer + '" >';

            FrecRow += '<td class=" tr_l">';
            FrecRow += '<input type="file" id="filecomp' + FileCounterPer + '" name = "filecomp' + FileCounterPer + '" onchange="ChangeFilePer(\'filecomp\',' + FileCounterPer + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" multiple="" >';
            FrecRow += '<label for="filecomp' + FileCounterPer + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
            FrecRow += ' <div id="filePath' + FileCounterPer + '" class="file_n"></div>';
            FrecRow += '</td>';
            FrecRow += '<td class=" tr_l"><input id="descrptn' + FileCounterPer + '" MaxLength="100" value="--Description--" onfocus="focusTxtDescrptn(' + FileCounterPer + ');" onkeypress="return DisableEnter(event);"  onblur="blurTxtDescrptnPer(\'filecomp\',' + FileCounterPer + ');" type="text" class="form-control fg2_inp2" placeholder="Description" name=""></td>';
            FrecRow += '<td>';
            FrecRow += '<div class="btn_stl1">';
            FrecRow += '<button id="FileIndvlAddMoreRow' + FileCounterPer + '" onclick="return CheckaddMoreRowsIndividualFilesComp(\'filecomp\',' + FileCounterPer + ');" class="btn act_btn bn2"  title="Add">';
            FrecRow += '<i class="fa fa-plus-circle"></i>';
            FrecRow += ' </button>';
            FrecRow += '<button id="FieldId' + FileCounterPer + '" class="btn act_btn bn3"  title="Delete" onclick = "return RemoveFileUploadComp(' + FileCounterPer + ');">';
            FrecRow += '<i class="fa fa-trash"></i>';
            FrecRow += '</button>';
            FrecRow += '</div>';
            FrecRow += '</td>';

            FrecRow += ' <td id="FileInx' + FileCounterPer + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + FileCounterPer + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + FileCounterPer + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId' + FileCounterPer + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName' + FileCounterPer + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadCompCardAttachment').append(FrecRow);

            // $noCon('#divPerAtch').scrollTop($noCon('#divPerAtch')[0].scrollHeight);

            //var objDiv = document.getElementById('divPerAtch');
            //objDiv.scrollTop = objDiv.scrollHeight;


            document.getElementById('filePath' + FileCounterPer).innerHTML = 'No File Uploaded';

            FileCounterPer++;

        }
        //jsonAtt[key].ORGFLS_ID, jsonAtt[key].ORGFLS_FILENAME, jsonAtt[key].ORGFLS_FLNM_ACT, jsonAtt[key].ORGFLS_DSCRPTN
        function EditAttachmentCR(editOrgFlsId, EditFileName, EditActualFileName, EditDescription) {

            if (EditDescription == "") {
                EditDescription = "--Description--";
            }
            else if (EditDescription == null) {
                EditDescription = "";
            }
            var FrecRow = '<tr id="FilerowId_' + FileCounterPer + '" >';


            var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=HiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';
    

            FrecRow += '<td class=" tr_l">';
            FrecRow += '<input style="display:none;" type="file" id="filecr' + FileCounterPer + '" name = "filecr' + FileCounterPer + '" onchange="ChangeFilePer(\'filecr\',' + FileCounterPer + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" multiple="" >';
            FrecRow += '<label style="display:none;" for="filecr' + FileCounterPer + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
            FrecRow += ' <div id="filePath' + FileCounterPer + '" class="file_n">' + tdFileNameEdit + '</div>';
            FrecRow += '</td>';
            FrecRow += '<td class=" tr_l"><input id="descrptn' + FileCounterPer + '" MaxLength="100" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterPer + ');" onkeypress="return DisableEnter(event);"  onblur="blurTxtDescrptnPer(\'filecr\',' + FileCounterPer + ');" type="text" class="form-control fg2_inp2" placeholder="Description" name=""></td>';
            FrecRow += '<td>';
            FrecRow += '<div class="btn_stl1">';
            FrecRow += '<button disabled id="FileIndvlAddMoreRow' + FileCounterPer + '" onclick="return CheckaddMoreRowsIndividualFilesCr(\'filecr\',' + FileCounterPer + ');" class="btn act_btn bn2"  title="Add">';
            FrecRow += '<i class="fa fa-plus-circle"></i>';
            FrecRow += ' </button>';
            FrecRow += '<button id="FieldId' + FileCounterPer + '" class="btn act_btn bn3"  title="Delete" onclick = "return RemoveFileUploadCr(' + FileCounterPer + ');">';
            FrecRow += '<i class="fa fa-trash"></i>';
            FrecRow += '</button>';
            FrecRow += '</div>';
            FrecRow += '</td>';


            FrecRow += ' <td id="FileInx' + FileCounterPer + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + FileCounterPer + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + FileCounterPer + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId' + FileCounterPer + '" style="display: none;">' + editOrgFlsId + '</td>';
            FrecRow += '<td id="DbFileName' + FileCounterPer + '" style="display: none;">' + EditFileName + '</td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadCrAttachment').append(FrecRow);
            document.getElementById("FileInx" + FileCounterPer).innerHTML = FileCounterPer;
            //document.getElementById("FileIndvlAddMoreRow" + FileCounterPer).style.opacity = "0.3";
            // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;

            FileLocalStorageAddPer('filecr', FileCounterPer);
            FileCounterPer++;

        }

        function EditAttachmentTX(editOrgFlsId, EditFileName, EditActualFileName, EditDescription) {

            if (EditDescription == "") {
                EditDescription = "--Description--";
            }
            else if (EditDescription == null) {
                EditDescription = "";
            }
            var FrecRow = '<tr id="FilerowId_' + FileCounterPer + '" >';


         

            var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=HiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

          
            FrecRow += '<td class=" tr_l">';
            FrecRow += '<input style="display:none;" type="file" id="filetx' + FileCounterPer + '" name = "filetx' + FileCounterPer + '" onchange="ChangeFilePer(\'filetx\',' + FileCounterPer + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" multiple="" >';
            FrecRow += '<label style="display:none;" for="filetx' + FileCounterPer + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
            FrecRow += ' <div id="filePath' + FileCounterPer + '" class="file_n">' + tdFileNameEdit + '</div>';
            FrecRow += '</td>';
            FrecRow += '<td class=" tr_l"><input id="descrptn' + FileCounterPer + '" MaxLength="100" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterPer + ');" onkeypress="return DisableEnter(event);"  onblur="blurTxtDescrptnPer(\'filetx\',' + FileCounterPer + ');" type="text" class="form-control fg2_inp2" placeholder="Description" name=""></td>';
            FrecRow += '<td>';
            FrecRow += '<div class="btn_stl1">';
            FrecRow += '<button disabled id="FileIndvlAddMoreRow' + FileCounterPer + '" onclick="return CheckaddMoreRowsIndividualFilesTX(\'filetx\',' + FileCounterPer + ');" class="btn act_btn bn2"  title="Add">';
            FrecRow += '<i class="fa fa-plus-circle"></i>';
            FrecRow += ' </button>';
            FrecRow += '<button id="FieldId' + FileCounterPer + '" class="btn act_btn bn3"  title="Delete" onclick = "return RemoveFileUploadTx(' + FileCounterPer + ');">';
            FrecRow += '<i class="fa fa-trash"></i>';
            FrecRow += '</button>';
            FrecRow += '</div>';
            FrecRow += '</td>';



            FrecRow += ' <td id="FileInx' + FileCounterPer + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + FileCounterPer + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + FileCounterPer + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId' + FileCounterPer + '" style="display: none;">' + editOrgFlsId + '</td>';
            FrecRow += '<td id="DbFileName' + FileCounterPer + '" style="display: none;">' + EditFileName + '</td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadTXAttachment').append(FrecRow);
            document.getElementById("FileInx" + FileCounterPer).innerHTML = FileCounterPer;
            //document.getElementById("FileIndvlAddMoreRow" + FileCounterPer).style.opacity = "0.3";
            // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;

            FileLocalStorageAddPer('filetx', FileCounterPer);
            FileCounterPer++;

        }

        function EditAttachmentCOMP(editOrgFlsId, EditFileName, EditActualFileName, EditDescription) {

            if (EditDescription == "") {
                EditDescription = "--Description--";
            }
            else if (EditDescription == null) {
                EditDescription = "";
            }
            var FrecRow = '<tr id="FilerowId_' + FileCounterPer + '" >';


          

            var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=HiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';
         
            FrecRow += '<td class=" tr_l">';
            FrecRow += '<input style="display:none;" type="file" id="filecomp' + FileCounterPer + '" name = "filecomp' + FileCounterPer + '" onchange="ChangeFilePer(\'filecomp\',' + FileCounterPer + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" multiple="" >';
            FrecRow += '<label style="display:none;" for="filecomp' + FileCounterPer + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
            FrecRow += ' <div id="filePath' + FileCounterPer + '" class="file_n">' + tdFileNameEdit + '</div>';
            FrecRow += '</td>';
            FrecRow += '<td class=" tr_l"><input id="descrptn' + FileCounterPer + '" MaxLength="100" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterPer + ');" onkeypress="return DisableEnter(event);"  onblur="blurTxtDescrptnPer(\'filecomp\',' + FileCounterPer + ');" type="text" class="form-control fg2_inp2" placeholder="Description" name=""></td>';
            FrecRow += '<td>';
            FrecRow += '<div class="btn_stl1">';
            FrecRow += '<button disabled id="FileIndvlAddMoreRow' + FileCounterPer + '" onclick="return CheckaddMoreRowsIndividualFilesComp(\'filecomp\',' + FileCounterPer + ');" class="btn act_btn bn2"  title="Add">';
            FrecRow += '<i class="fa fa-plus-circle"></i>';
            FrecRow += ' </button>';
            FrecRow += '<button id="FieldId' + FileCounterPer + '" class="btn act_btn bn3"  title="Delete" onclick = "return RemoveFileUploadComp(' + FileCounterPer + ');">';
            FrecRow += '<i class="fa fa-trash"></i>';
            FrecRow += '</button>';
            FrecRow += '</div>';
            FrecRow += '</td>';


            FrecRow += ' <td id="FileInx' + FileCounterPer + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + FileCounterPer + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + FileCounterPer + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId' + FileCounterPer + '" style="display: none;">' + editOrgFlsId + '</td>';
            FrecRow += '<td id="DbFileName' + FileCounterPer + '" style="display: none;">' + EditFileName + '</td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadCompCardAttachment').append(FrecRow);
            document.getElementById("FileInx" + FileCounterPer).innerHTML = FileCounterPer;
            //document.getElementById("FileIndvlAddMoreRow" + FileCounterPer).style.opacity = "0.3";
            // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;

            FileLocalStorageAddPer('filecomp', FileCounterPer);
            FileCounterPer++;

        }

        function CheckaddMoreRowsIndividualFilesCr(name, x) {

            // for add image in each row


            var check = document.getElementById("FileInx" + x).innerHTML;

            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield


            if (check == " ") {

                var Fevt = document.getElementById("FileEvt" + x).innerHTML;

                if (Fevt != 'UPD') {

                    if (CheckFileUploaded(name, x) == true) {
                        document.getElementById("FileInx" + x).innerHTML = x;
                        document.getElementById("FileIndvlAddMoreRow" + x).disabled = true;
                        AddFileUploadCr();

                        return false;
                    }
                }
                else {

                    document.getElementById("FileInx" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRow" + x).disabled = true;
                    AddFileUploadCr();

                    return false;
                }
            }

            return false;
        }

        function CheckaddMoreRowsIndividualFilesTX(name, x) {
            // for add image in each row

            var check = document.getElementById("FileInx" + x).innerHTML;

            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;

            if (check == " ") {

                var Fevt = document.getElementById("FileEvt" + x).innerHTML;

                if (Fevt != 'UPD') {
                    if (CheckFileUploaded(name, x) == true) {
                        document.getElementById("FileInx" + x).innerHTML = x;
                        document.getElementById("FileIndvlAddMoreRow" + x).disabled = true;
                        AddFileUploadTX();

                        return false;
                    }
                }
                else {

                    document.getElementById("FileInx" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRow" + x).disabled = true;
                    AddFileUploadTX();

                    return false;
                }
            }

            return false;
        }

        function CheckaddMoreRowsIndividualFilesComp(name, x) {
            // for add image in each row

            var check = document.getElementById("FileInx" + x).innerHTML;

            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;

            if (check == " ") {

                var Fevt = document.getElementById("FileEvt" + x).innerHTML;

                if (Fevt != 'UPD') {
                    if (CheckFileUploaded(name, x) == true) {
                        document.getElementById("FileInx" + x).innerHTML = x;
                        document.getElementById("FileIndvlAddMoreRow" + x).disabled = true;
                        AddFileUploadComp();

                        return false;
                    }
                }
                else {

                    document.getElementById("FileInx" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRow" + x).disabled = true;
                    AddFileUploadComp();

                    return false;
                }
            }

            return false;
        }
        var $nonConft = jQuery.noConflict();
        function RemoveFileUploadCr(removeNum) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to delete selected file?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var Filerow_index = jQuery('#FilerowId_' + removeNum).index();

                    FileLocalStorageDeletePer(Filerow_index, removeNum);
                    jQuery('#FilerowId_' + removeNum).remove();



                    var TableFileRowCount = document.getElementById("TableFileUploadCrAttachment").rows.length;


                    if (TableFileRowCount != 0) {

                        var idlast = $nonConft('#TableFileUploadCrAttachment tr:last').attr('id');

                        //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                        //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                        if (idlast != "") {

                            var res = idlast.split("_");

                            document.getElementById("FileInx" + res[1]).innerHTML = " ";
                            document.getElementById("FileIndvlAddMoreRow" + res[1]).disabled = false;
                        }
                    }
                    else {
                        AddFileUploadCr();
                    }
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
        }
        function RemoveFileUploadTx(removeNum) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to delete selected file?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var Filerow_index = jQuery('#FilerowId_' + removeNum).index();

                    FileLocalStorageDeletePer(Filerow_index, removeNum);
                    jQuery('#FilerowId_' + removeNum).remove();



                    var TableFileRowCount = document.getElementById("TableFileUploadTXAttachment").rows.length;

                    if (TableFileRowCount != 0) {
                        var idlast = $nonConft('#TableFileUploadTXAttachment tr:last').attr('id');
                        //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                        //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                        if (idlast != "") {
                            var res = idlast.split("_");

                            document.getElementById("FileInx" + res[1]).innerHTML = " ";
                            document.getElementById("FileIndvlAddMoreRow" + res[1]).disabled = false;
                        }
                    }
                    else {
                        AddFileUploadTX();
                    }
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }
        function RemoveFileUploadComp(removeNum) {
           

            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to delete selected file?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var Filerow_index = jQuery('#FilerowId_' + removeNum).index();

                    FileLocalStorageDeletePer(Filerow_index, removeNum);
                    jQuery('#FilerowId_' + removeNum).remove();






                    var TableFileRowCount = document.getElementById("TableFileUploadCompCardAttachment").rows.length;

                    if (TableFileRowCount != 0) {
                        var idlast = $nonConft('#TableFileUploadCompCardAttachment tr:last').attr('id');
                        //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                        //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                        if (idlast != "") {
                            var res = idlast.split("_");

                            document.getElementById("FileInx" + res[1]).innerHTML = " ";
                            document.getElementById("FileIndvlAddMoreRow" + res[1]).disabled = false;
                        }
                    }
                    else {
                        AddFileUploadComp();


                    }
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }

        function ChangeFilePer(name, x) {

            //IncrmntConfrmCounter();
            if (document.getElementById(name + x).value != "") {
                document.getElementById('filePath' + x).innerHTML = document.getElementById(name + x).value;

            }
            else {
                document.getElementById('filePath' + x).innerHTML = 'No File Uploaded';


            }
            var SavedorNot = document.getElementById("FileSave" + x).innerHTML;

            if (SavedorNot == "saved") {

                var row_index = jQuery('#FilerowId_' + x).index();
                FileLocalStorageEditPer(name, x, row_index);
            }
            else {

                FileLocalStorageAddPer(name, x);
            }
        }

        function FileLocalStorageEditPer(name, x, row_index) {
            var rowindex = 0;
            var tbClientPermitFileUpload = localStorage.getItem("tbClientPermitFileUpload");//Retrieve the stored data

            tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

            if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                tbClientPermitFileUpload = [];


            var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
            var r = 0;
            if (SavedorNot == "saved") {
                var rowChk = 0;
                var hiddenVal = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;

                if (hiddenVal != "" && hiddenVal != "[]") {

                    var find1 = '\\\\';
                    var re1 = new RegExp(find1, 'g');

                    var res1 = hiddenVal.replace(re1, '');

                    var find2 = '\\["';
                    var re2 = new RegExp(find2, 'g');

                    var res2 = res1.replace(re2, '');

                    var find3 = '\\"]';
                    var re3 = new RegExp(find3, 'g');

                    var res3 = res2.replace(re3, '');

                    var jdatas = res3.split("\",\"{");


                    var i;
                    for (i = 0; i < jdatas.length; i++) {

                        var resultJSON = "";
                        if (i == 0) {
                            resultJSON = jdatas[i];

                        }
                        else {

                            resultJSON = "{" + jdatas[i];

                        }

                        var result = $noCon.parseJSON(resultJSON);

                        $noCon.each(result, function (k, v) {

                            if (k == "ROWID") {


                                v = v.split(',').join('');

                                if ("" + name + "" + x + "" == v) {
                                    rowChk = r;
                                    rowindex = 1;
                                }

                                r = r + 1;

                            }

                        });
                    }

                }
            }
            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var descrptn = document.getElementById("descrptn" + x).value;

            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            if (rowindex == 0) {


                if (Fevt == 'INS') {

                    var $FileE = jQuery.noConflict();
                    tbClientPermitFileUpload[row_index] = JSON.stringify({
                        ROWID: "" + name + "" + x + "",

                        DESCRPTN: "" + descrptn + "",
                        EVTACTION: "" + Fevt + "",
                        DTLID: "0"
                    });//Alter the selected item on the table
                }
                else {

                    var $FileE = jQuery.noConflict();
                    tbClientPermitFileUpload[row_index] = JSON.stringify({
                        ROWID: "" + name + "" + x + "",

                        DESCRPTN: "" + descrptn + "",
                        EVTACTION: "" + Fevt + "",
                        DTLID: "" + FdetailId + ""

                    });//Alter the selected item on the table



                }

            }
            else {
                var $FileE = jQuery.noConflict();
                tbClientPermitFileUpload[rowChk] = JSON.stringify({
                    ROWID: "" + name + "" + x + "",

                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"
                });//Alter the selected item on the table

            }

            localStorage.setItem("tbClientPermitFileUpload", JSON.stringify(tbClientPermitFileUpload));
            //$FileE("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));
            document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value = JSON.stringify(tbClientPermitFileUpload);


            //var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;

            return true;
        }

        function CheckFileUploaded(name, x) {

            if (document.getElementById(name + x).value != "") {

                return true;
            }
            else {
                return false;
            }


        }

        function FileLocalStorageAddPer(name, x) {

            var tbClientPermitFileUpload = localStorage.getItem("tbClientPermitFileUpload");//Retrieve the stored data

            tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

            if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                tbClientPermitFileUpload = [];


            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var descrptn = document.getElementById("descrptn" + x).value;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;


            if (Fevt == 'INS') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + name + "" + x + "",
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0",


                });
            }
            else if (Fevt == 'UPD') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + name + "" + x + "",
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });
            }


            tbClientPermitFileUpload.push(client);

            localStorage.setItem("tbClientPermitFileUpload", JSON.stringify(tbClientPermitFileUpload));

            var $FileZ = jQuery.noConflict();
            // $FileZ("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));
            document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value = JSON.stringify(tbClientPermitFileUpload);


            // var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;


            document.getElementById("FileSave" + x).innerHTML = "saved";

            return true;

        }

        function FileLocalStorageDeletePer(row_index, x) {

            var $DelFile = jQuery.noConflict();
            var tbClientPermitFileUpload = localStorage.getItem("tbClientPermitFileUpload");//Retrieve the stored data

            tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

            if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                tbClientPermitFileUpload = [];



            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            tbClientPermitFileUpload.splice(row_index, 1);

            localStorage.setItem("tbClientPermitFileUpload", JSON.stringify(tbClientPermitFileUpload));

            //$DelFile("#cphMain_HiddenDlet_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));



            //var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;



            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            if (Fevt == 'UPD') {
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

                if (FdetailId != '') {

                    DeleteFileLSTORAGEAddPer(x);
                }

            }

            function DeleteFileLSTORAGEAddPer(x) {

                var tbClientPermitFileUploadCancel = localStorage.getItem("tbClientPermitFileUploadCancel");//Retrieve the stored data

                tbClientPermitFileUploadCancel = JSON.parse(tbClientPermitFileUploadCancel); //Converts string to object

                if (tbClientPermitFileUploadCancel == null) //If there is no data, initialize an empty array
                    tbClientPermitFileUploadCancel = [];


                var FileName = document.getElementById("DbFileName" + x).innerHTML;
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
                var descrptn = document.getElementById("descrptn" + x).value;



                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",

                    DESCRPTN: "" + descrptn + "",
                    // EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });



                tbClientPermitFileUploadCancel.push(client);
                localStorage.setItem("tbClientPermitFileUploadCancel", JSON.stringify(tbClientPermitFileUploadCancel));

                //$addFile("#cphMain_hiddenPerFileCanclDtlId").val(JSON.stringify(tbClientPermitFileUploadCancel));
                document.getElementById("<%=HiddenDlet_FileUpload.ClientID%>").value = JSON.stringify(tbClientPermitFileUploadCancel);




                //document.getElementById("FileSave" + x).innerHTML = "saved";

                return true;

            }

        }

        function focusTxtDescrptn(x) {
            var val = document.getElementById("descrptn" + x).value;
            if (val == "--Description--")
                document.getElementById("descrptn" + x).value = "";
        }

        function blurTxtDescrptnPer(name, x) {

            //var we_index = jQuery('#FilerowId_' + x).index();

            var val = document.getElementById("descrptn" + x).value;

            if (val == "") {

                document.getElementById("descrptn" + x).value = "--Description--";
            }
            else {

                if (val != "--Description--") {

                    //IncrmntConfrmCounter();

                    var WithoutReplace = val;

                    var replaceText1 = WithoutReplace.replace(/</g, "");
                    var replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("descrptn" + x).value = replaceText2.trim();

                }
                var SavedorNot = document.getElementById("FileSave" + x).innerHTML;

                if (SavedorNot == "saved") {

                    var tbrow_index = jQuery('#FilerowId_' + x).index();

                    FileLocalStorageEditPer(name, x, tbrow_index);

                }
            }
        }
        var rowCount = 0;
        var RowIndex = 0;
        function addMoreRows(frm, boolFocus, boolAppendorNot, row_index) {

            rowCount++;
            RowIndex++;
            var recRow = '<tr id="rowId_' + rowCount + '" >';
            recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
            recRow += '<td colspan="1" style="width: 2.5%;text-align: center;display: none;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%; width:89%;margin-left:-2%;" >' + RowIndex.toString() + ' </div></td>';

            recRow += ' <td class="tr_l" id="tdPartner' + rowCount + '">';
            recRow += ' <input  id="txtPartner' + rowCount + '" class="form-control fg2_inp2" placeholder="Name" onkeydown="return DisableEnter(event);" type="text" onblur="return BlurPartner(' + rowCount + ')"  maxlength=50  style=" text-transform: uppercase;" />';
            recRow += '   </td> ';

            recRow += ' <td class="tr_l" id="tdDocumentNo' + rowCount + '" >';
            recRow += ' <input  id="txtDocumentNo' + rowCount + '" class="form-control fg2_inp2" placeholder="Document#" onkeydown="return DisableEnter(event);" type="text" onblur="return BlurDocumentNo(' + rowCount + ')"  maxlength=50 />';
            recRow += '   </td> ';

            recRow += ' <td class="tr_l" id="tdCRNo' + rowCount + '" >';
            recRow += ' <input  id="txtCRNo' + rowCount + '" class="form-control fg2_inp2" placeholder="CR#" onkeydown="return DisableEnter(event);" type="text" onblur="return BlurCrNo(' + rowCount + ')"  maxlength=50/>';
            recRow += '   </td> ';

            recRow += ' <td class="tr_l" id="tdNation' + rowCount + '" ><div id="divddlDivision_' + rowCount + '">';
            //recRow += ' <input  id="txtNation' + rowCount + '"  type="text" onblur="return BlurNationNo(' + rowCount + ')"  maxlength=50 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 1611%;margin-left: -4227.5%;"/>';
            recRow += '<select id="ddlDivision_' + rowCount + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw CntryP" onkeydown="return DisableEnter(event);" ></select>';
            recRow += '</div></td> ';

            recRow += ' <td class="tr_l" id="tdSharePer' + rowCount + '" >';
            recRow += ' <input  id="txtSharePerc' + rowCount + '"  class="form-control fg2_inp2 tr_c" placeholder="0" type="text" onkeydown="return isNumber(event)" onfocus="return FocusSharePerc(' + rowCount + ')" onblur="return BlurSharePerc(' + rowCount + ')"   maxlength=6 style="text-align: right;"/>';
            recRow += '   </td> ';


            recRow += '<td class="tr_c" id="tdStatus' + rowCount + '" >';
            recRow += '<div class="check1">';
            recRow += '<div class="">';
            recRow += '<label class="switch">';
            recRow += '<input type="checkbox" id="cbStatus' + rowCount + '" onkeydown="return DisableEnter(event);"  type="checkbox" onblur="return BlurStatus(' + rowCount + ')">';
            recRow += '<span class="slider_tog round"></span>';
            recRow += '</label>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '</td>';

            recRow += '<td>';
            recRow += '<div class="btn_stl1">';
            recRow += '<button id="tdIndvlAddMoreRow' + rowCount + '" onclick="return CheckaddMoreRows(\'' + rowCount + '\',true);"  class="btn act_btn bn2" title="Add">';
            recRow += '<i class="fa fa-plus-circle"></i>';
            recRow += '</button>';
            recRow += '<button class="btn act_btn bn3" onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this entry?\');"  title="Delete">';
            recRow += '<i class="fa fa-trash"></i>';
            recRow += '</button>';
            recRow += '</div>';
            recRow += '</td>';


            recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
            recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
            recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">INS</td>';
            recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;"></td>';
            recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
            recRow += '</tr>';



            if (boolAppendorNot == false) {
                //to append
                jQuery('#TableaddedRows').append(recRow);
            }
            else {

                // to insert in perticular position
                var $NoAppnd = jQuery.noConflict();
                if (parseInt(row_index) != 0) {
                    $NoAppnd('#TableaddedRows > tbody > tr').eq(parseInt(row_index) - 1).after(recRow);
                }
                else {

                    var TableRowCount = document.getElementById("TableaddedRows").rows.length;

                    if (parseInt(TableRowCount) != 0) {
                        $NoAppnd('#TableaddedRows > tbody > tr').eq(parseInt(row_index)).before(recRow);
                    }
                    else {

                        jQuery('#TableaddedRows').append(recRow);
                    }
                }

            }
            FillDllContryDdl(rowCount);
            $au('#ddlDivision_' + rowCount).selectToAutocomplete1Letter();
        }


        //table edit  partnership

        function EditListRows(EditDtlId, EditPrtnerName, EditDocNo, EditCrNum, EditNation, EditSharePer, EditStatus) {



            if (EditDtlId != "" && EditPrtnerName != "" && EditDocNo != "" && EditCrNum != "" && EditNation != null && EditSharePer != null) {
                //EditDtlId = 0;
                var cbxChecked;
                if (EditStatus == 1) {
                    cbxChecked = true;
                }
                else {
                    cbxChecked = false;
                }
                rowCount++;
                RowIndex++;

               
                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td colspan="1" style="width: 2.5%;text-align: center;display: none;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%; width:89%;margin-left:-2%;" >' + RowIndex.toString() + ' </div></td>';

                recRow += ' <td class="tr_l" id="tdPartner' + rowCount + '">';
                recRow += ' <input  id="txtPartner' + rowCount + '" class="form-control fg2_inp2" placeholder="Name" value="' + EditPrtnerName + '" onkeydown="return DisableEnter(event);" type="text" onblur="return BlurPartner(' + rowCount + ')"  maxlength=50  style=" text-transform: uppercase;" />';
                recRow += '   </td> ';

                recRow += ' <td class="tr_l" id="tdDocumentNo' + rowCount + '" >';
                recRow += ' <input  id="txtDocumentNo' + rowCount + '" class="form-control fg2_inp2" placeholder="Document#" value="' + EditDocNo + '" onkeydown="return DisableEnter(event);" type="text" onblur="return BlurDocumentNo(' + rowCount + ')"  maxlength=50 />';
                recRow += '   </td> ';

                recRow += ' <td class="tr_l" id="tdCRNo' + rowCount + '" >';
                recRow += ' <input  id="txtCRNo' + rowCount + '" value="' + EditCrNum + '" class="form-control fg2_inp2" placeholder="CR#" onkeydown="return DisableEnter(event);" type="text" onblur="return BlurCrNo(' + rowCount + ')"  maxlength=50/>';
                recRow += '   </td> ';

                recRow += ' <td class="tr_l" id="tdNation' + rowCount + '" ><div id="divddlDivision_' + rowCount + '">';
                //recRow += ' <input  id="txtNation' + rowCount + '"  type="text" onblur="return BlurNationNo(' + rowCount + ')"  maxlength=50 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 1611%;margin-left: -4227.5%;"/>';
                recRow += '<select id="ddlDivision_' + rowCount + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw CntryP" onkeydown="return DisableEnter(event);" onblur="return BlurNationNo(' + rowCount + ')"></select>';
                recRow += '</div></td> ';

                recRow += ' <td class="tr_l" id="tdSharePer' + rowCount + '" >';
                recRow += ' <input  id="txtSharePerc' + rowCount + '"  value="' + EditSharePer + '" class="form-control fg2_inp2 tr_c" placeholder="0" type="text" onkeydown="return isNumber(event)" onfocus="return FocusSharePerc(' + rowCount + ')" onblur="return BlurSharePerc(' + rowCount + ')"   maxlength=6 style="text-align: right;"/>';
                recRow += '   </td> ';


                recRow += '<td class="tr_c" id="tdStatus' + rowCount + '" >';
                recRow += '<div class="check1">';
                recRow += '<div class="">';
                recRow += '<label class="switch">';
                recRow += '<input type="checkbox" id="cbStatus' + rowCount + '" onkeydown="return DisableEnter(event);"  type="checkbox" onblur="return BlurStatus(' + rowCount + ')">';
                recRow += '<span class="slider_tog round"></span>';
                recRow += '</label>';
                recRow += '</div>';
                recRow += '</div>';
                recRow += '</td>';

                recRow += '<td>';
                recRow += '<div class="btn_stl1">';
                recRow += '<button disabled id="tdIndvlAddMoreRow' + rowCount + '" onclick="return CheckaddMoreRows(\'' + rowCount + '\',true);"  class="btn act_btn bn2" title="Add">';
                recRow += '<i class="fa fa-plus-circle"></i>';
                recRow += '</button>';
                recRow += '<button class="btn act_btn bn3" onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this entry?\');"  title="Delete">';
                recRow += '<i class="fa fa-trash"></i>';
                recRow += '</button>';
                recRow += '</div>';
                recRow += '</td>';


                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + EditDtlId + '</td>';




                recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                recRow += '</tr>';


                jQuery('#TableaddedRows').append(recRow);

                //document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                //document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";
                FillDllContryDdl(rowCount);


                document.getElementById("ddlDivision_" + rowCount).value = EditNation;
                document.getElementById("cbStatus" + rowCount).checked = cbxChecked;


                LocalStorageAdd(rowCount);
                $au('#ddlDivision_' + rowCount ).selectToAutocomplete1Letter();
            }
            else {


            }

        }

        function ViewListRows(EditPrtnerName, EditDocNo, EditSharePer, EditDtlId) {


            if (EditPrtnerName != "" && EditDocNo != "" && EditSharePer != "" && EditDtlId != "") {


                rowCount++;
                RowIndex++;
                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td colspan="1" style="width: 2.5%;text-align: center;display: none;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%; width:89%;margin-left:-2%;" >' + RowIndex.toString() + ' </div></td>';

                recRow += ' <td class="tr_l" id="tdPartner' + rowCount + '">';
                recRow += ' <input  disabled id="txtPartner' + rowCount + '" class="form-control fg2_inp2" placeholder="Name" value="' + EditPrtnerName + '" onkeydown="return DisableEnter(event);" type="text" onblur="return BlurPartner(' + rowCount + ')"  maxlength=50  style=" text-transform: uppercase;" />';
                recRow += '   </td> ';

                recRow += ' <td class="tr_l" id="tdDocumentNo' + rowCount + '" >';
                recRow += ' <input  disabled id="txtDocumentNo' + rowCount + '" class="form-control fg2_inp2" placeholder="Document#" value="' + EditDocNo + '" onkeydown="return DisableEnter(event);" type="text" onblur="return BlurDocumentNo(' + rowCount + ')"  maxlength=50 />';
                recRow += '   </td> ';

                recRow += ' <td class="tr_l" id="tdCRNo' + rowCount + '" >';
                recRow += ' <input  disabled id="txtCRNo' + rowCount + '" value="' + EditCrNum + '" class="form-control fg2_inp2" placeholder="CR#" onkeydown="return DisableEnter(event);" type="text" onblur="return BlurCrNo(' + rowCount + ')"  maxlength=50/>';
                recRow += '   </td> ';

                recRow += ' <td class="tr_l" id="tdNation' + rowCount + '" >';
                //recRow += ' <input  id="txtNation' + rowCount + '"  type="text" onblur="return BlurNationNo(' + rowCount + ')"  maxlength=50 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 1611%;margin-left: -4227.5%;"/>';
                recRow += '<select disabled id="ddlDivision_' + rowCount + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" onkeydown="return DisableEnter(event);" onblur="return BlurNationNo(' + rowCount + ')"></select>';
                recRow += '   </td> ';

                recRow += ' <td class="tr_l" id="tdSharePer' + rowCount + '" >';
                recRow += ' <input  disabled id="txtSharePerc' + rowCount + '"  value="' + EditSharePer + '" class="form-control fg2_inp2 tr_c" placeholder="0" type="text" onkeydown="return isNumber(event)" onfocus="return FocusSharePerc(' + rowCount + ')" onblur="return BlurSharePerc(' + rowCount + ')"   maxlength=6 style="text-align: right;"/>';
                recRow += '   </td> ';


                recRow += '<td class="tr_c" id="tdStatus' + rowCount + '" >';
                recRow += '<div class="check1">';
                recRow += '<div class="">';
                recRow += '<label class="switch">';
                recRow += '<input disabled type="checkbox" id="cbStatus' + rowCount + '" onkeydown="return DisableEnter(event);"  type="checkbox" onblur="return BlurStatus(' + rowCount + ')">';
                recRow += '<span class="slider_tog round"></span>';
                recRow += '</label>';
                recRow += '</div>';
                recRow += '</div>';
                recRow += '</td>';

                recRow += '<td>';
                recRow += '<div class="btn_stl1">';
                recRow += '<button disabled id="tdIndvlAddMoreRow' + rowCount + '" onclick="return CheckaddMoreRows(\'' + rowCount + '\',true);"  class="btn act_btn bn2" title="Add">';
                recRow += '<i class="fa fa-plus-circle"></i>';
                recRow += '</button>';
                recRow += '<button disabled class="btn act_btn bn3" onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this entry?\');"  title="Delete">';
                recRow += '<i class="fa fa-trash"></i>';
                recRow += '</button>';
                recRow += '</div>';
                recRow += '</td>';


                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + EditDtlId + '</td>';




                recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                recRow += '</tr>';


                jQuery('#TableaddedRows').append(recRow);
                document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                //document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";
                LocalStorageAdd(rowCount);

            }
            else {


            }

        }

        //checking add more rows
        function CheckaddMoreRows(x, retBool) {
            CalculateTotalAmountFromHiddenField();
            var check = document.getElementById("tdInx" + x).innerHTML;

            var str = document.getElementById("<%=totelShare.ClientID%>").value;
           // alert(str);
            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (str > 0 && str <100) {
                if (check == " ") {

                    if (retBool == true) {
                        if (CheckAllRowFieldAndHighlight(x, false) == true) {
                          
                            document.getElementById("tdInx" + x).innerHTML = x;
                            document.getElementById("tdIndvlAddMoreRow" + x).disabled = true;
                            addMoreRows(this.form, retBool, false, 0);
                            return false;
                        }
                    }

                    else if (retBool == false) {
                        var row_index = jQuery('#rowId_' + x).index();
                        if (CheckAllRowField(x, row_index) == true) {
                            document.getElementById("tdInx" + x).innerHTML = x;
                            document.getElementById("tdIndvlAddMoreRow" + x).disabled = true;
                            addMoreRows(this.form, retBool, false, 0);
                            return false;
                        }
                    }
                }

            }
            return false;
        }
        // checks every field in row
        function CheckAllRowField(x, row_index) {
            ret = true;



            var partner = document.getElementById("txtPartner" + x).value;
            if (partner == "") {
                ret = false;
            }

            var documentNo = document.getElementById("txtDocumentNo" + x).value;
            if (documentNo == "") {
                ret = false;
            }
            var documentNo = document.getElementById("txtCRNo" + x).value;
            if (documentNo == "") {
                ret = false;
            }
            var documentNo = document.getElementById("ddlDivision_" + x).value;
            if (documentNo == "") {
                ret = false;
            }
            var sharePer = document.getElementById("txtSharePerc" + x).value;
            if (sharePer == "") {
                ret = false;
            }
            var documentNo = document.getElementById("cbStatus" + x).value;
            if (documentNo == "") {
                ret = false;
            }

            return ret;
        }
        // checks every field in row
        function CheckAllRowFieldAndHighlight(x, blFromBlurValue) {
            ret = true;

            document.getElementById("txtPartner" + x).style.borderColor = "";
            document.getElementById("txtDocumentNo" + x).style.borderColor = "";
            document.getElementById("txtCRNo" + x).style.borderColor = "";

            document.getElementById("ddlDivision_" + x).style.borderColor = "";
            $("div#divddlDivision_" + x+" input.ui-autocomplete-input").css("borderColor", "");

            document.getElementById("txtSharePerc" + x).style.borderColor = "";
            document.getElementById("cbStatus" + x).style.borderColor = "";

            var partner = document.getElementById("txtPartner" + x).value;
            var documentNo = document.getElementById("txtDocumentNo" + x).value;
            var crNo = document.getElementById("txtCRNo" + x).value;
            var Nation = document.getElementById("ddlDivision_" + x).value;
            var sharePer = document.getElementById("txtSharePerc" + x).value;
            var status = document.getElementById("cbStatus" + x).value;
            if (partner == "" && documentNo == "" && crNo == "" && Nation == "0" && sharePer == "" && status == "") {

                ret = true;
            }
            else {
                if (partner == "") {

                    document.getElementById("txtPartner" + x).style.borderColor = "Red";
                    document.getElementById("txtPartner" + x).focus();
                    $noCon("#txtPartner" + x).select();
                    ret = false;
                }



                if (documentNo == "") {
                    document.getElementById("txtDocumentNo" + x).style.borderColor = "Red";
                    document.getElementById("txtDocumentNo" + x).focus();
                    $noCon("#txtDocumentNo" + x).select();
                    ret = false;
                }



                if (crNo == "") {
                    document.getElementById("txtCRNo" + x).style.borderColor = "Red";
                    document.getElementById("txtCRNo" + x).focus();
                    $noCon("#txtCRNo" + x).select();
                    ret = false;
                }



                if (Nation == "" || Nation == "0") {

                    $("div#divddlDivision_" + x + " input.ui-autocomplete-input").css("borderColor", "red");
                    $("div#divddlDivision_" + x + " input.ui-autocomplete-input").select();
                    $("div#divddlDivision_" + x + " input.ui-autocomplete-input").focus();

                    document.getElementById("ddlDivision_" + x).style.borderColor = "Red";
                    document.getElementById("ddlDivision_" + x).focus();
                    $noCon("#ddlDivision_" + x).select();
                    ret = false;
                }


                if (sharePer == "") {
                    document.getElementById("txtSharePerc" + x).style.borderColor = "Red";
                    document.getElementById("txtSharePerc" + x).focus();
                    $noCon("#txtSharePerc" + x).select();
                    ret = false;
                }


                if (status == "") {

                    document.getElementById("cbStatus" + x).style.borderColor = "Red";
                    document.getElementById("cbStatus" + x).focus();
                    $noCon("#cbStatus" + x).select();
                    ret = false;
                }
            }
            return ret;

        }
        //for removing row
        var $noc1 = jQuery.noConflict();
        function removeRow(removeNum, CofirmMsg) {
            ezBSAlert({
                type: "confirm",
                messageText: CofirmMsg,
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var row_index = jQuery('#rowId_' + removeNum).index();
                    var BforeRmvTableRowCount = document.getElementById("TableaddedRows").rows.length;


                    LocalStorageDelete(row_index, removeNum);

                    jQuery('#rowId_' + removeNum).remove();
                    RowIndex--;
                    var TableRowCount = document.getElementById("TableaddedRows").rows.length;

                    if (TableRowCount != 0) {

                        var idlast = $noc1('#TableaddedRows tr:last').attr('id');

                        //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                        //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                        if (idlast != "") {

                            var res = idlast.split("_");

                            document.getElementById("tdInx" + res[1]).innerHTML = " ";
                            document.getElementById("tdIndvlAddMoreRow" + res[1]).disabled = false;
                        }
                    }
                    else {

                        addMoreRows(this.form, true, false, 0);
                    }

                    if (BforeRmvTableRowCount > 1) {

                        if ((BforeRmvTableRowCount - 1) == row_index) {

                            var table = document.getElementById("TableaddedRows");
                            var preRowId = table.rows[row_index - 1].id;
                            if (preRowId != "") {
                                var res = preRowId.split("_");
                                if (res[1] != "") {


                                    //document.getElementById("txtDate" + res[1]).focus();
                                    //$noCon("#txtDate" + res[1]).select();
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

                                    document.getElementById("txtPartner" + res[1]).focus();
                                    $noCon("#txtPartner" + res[1]).select();
                                    ReNumberTable();

                                }
                            }

                        }
                    }
                    document.getElementById("<%=hiddenNation.ClientID%>").value = "";

                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
        }
        //this function is to RE-NUMBER table when deletion .as it show duplicate sl num when deleted othre than last row
        function ReNumberTable() {
            //if (idlast != "") {
            //    var res = idlast.split("_");

            //    document.getElementById("tdInx" + res[1]).innerHTML = " ";
            //    document.getElementById("tdIndvlAddMoreRow" + res[1]).style.opacity = "1";
            //}
            var table = "";


            table = document.getElementById("TableaddedRows");

            for (var i = 0, row; row = table.rows[i]; i++) {
                var x = "";
                // RwId = row.innerHTML;

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
                                var row_index = jQuery('#rowId_' + x).index();

                                LocalStorageEdit(x, row_index);

                            }
                        }
                    }

                    //iterate through columns
                    //columns would be accessed using the "col" variable assigned in the for loop

                }
            }
        }
        //local storage adding,deleting and editing

        function LocalStorageAdd(x) {


            var tbClientTrficVltn = localStorage.getItem("tbClientTrficVltn");//Retrieve the stored data

            tbClientTrficVltn = JSON.parse(tbClientTrficVltn); //Converts string to object

            if (tbClientTrficVltn == null) //If there is no data, initialize an empty array
                tbClientTrficVltn = [];

            var detailId = document.getElementById("tdDtlId" + x).innerHTML;

            //  var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
            var evt = document.getElementById("tdEvt" + x).innerHTML;

            var s = 0;
            if (document.getElementById("cbStatus" + x).checked == true) {
                s = 1;
            }
            else {
                s = 0;
            }


            if (evt == 'INS') {

                var $add = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    PARTNER: $add("#txtPartner" + x).val(),
                    DOCNUM: $add("#txtDocumentNo" + x).val(),
                    CRNUM: $add("#txtCRNo" + x).val(),
                    NATION: $add("#ddlDivision_" + x).val(),
                    SHAREPER: $add("#txtSharePerc" + x).val(),
                    STATUS: "" + s + "",

                    EVTACTION: "" + evt + "",
                    DTLID: "0"

                });
            }
            else if (evt == 'UPD') {

                var $add = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    PARTNER: $add("#txtPartner" + x).val(),
                    DOCNUM: $add("#txtDocumentNo" + x).val(),
                    CRNUM: $add("#txtCRNo" + x).val(),
                    NATION: $add("#ddlDivision_" + x).val(),
                    SHAREPER: $add("#txtSharePerc" + x).val(),
                    STATUS: "" + s + "",

                    EVTACTION: "" + evt + "",
                    DTLID: "" + detailId + ""


                });
            }




            tbClientTrficVltn.push(client);
            localStorage.setItem("tbClientTrficVltn", JSON.stringify(tbClientTrficVltn));

            //$add("#cphMain_HiddenFieldAddTable").val(JSON.stringify(tbClientTrficVltn));
            document.getElementById("<%=HiddenFieldAddTable.ClientID%>").value = JSON.stringify(tbClientTrficVltn);

            //for calculation of total Amount
            CalculateTotalAmountFromHiddenField();




            // var h = document.getElementById("<%=HiddenFieldAddTable.ClientID%>").value;


            document.getElementById("tdSave" + x).innerHTML = "saved";

            //CheckaddMoreRows(x, false);
            //IncrmntConfrmCounter();

            return true;

        }
        function LocalStorageDelete(row_index, x) {

            var tbClientTrficVltn = localStorage.getItem("tbClientTrficVltn");//Retrieve the stored data

            tbClientTrficVltn = JSON.parse(tbClientTrficVltn); //Converts string to object

            if (tbClientTrficVltn == null) //If there is no data, initialize an empty array
                tbClientTrficVltn = [];



            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            tbClientTrficVltn.splice(row_index, 1);
            localStorage.setItem("tbClientTrficVltn", JSON.stringify(tbClientTrficVltn));

            //$noCon("#cphMain_hiddenDelt_Partner").val(JSON.stringify(tbClientTrficVltn));
            document.getElementById("<%=hiddenDelt_Partner.ClientID%>").value = JSON.stringify(tbClientTrficVltn);




            var evt = document.getElementById("tdEvt" + x).innerHTML;

            if (evt == 'UPD') {
                var detailId = document.getElementById("tdDtlId" + x).innerHTML;
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

            //for calculation of total Amount
             CalculateTotalAmountFromHiddenField();
            //IncrmntConfrmCounter();


         }

         function LocalStorageEdit(x, row_index) {

             var tbClientTrficVltn = localStorage.getItem("tbClientTrficVltn");//Retrieve the stored data

             tbClientTrficVltn = JSON.parse(tbClientTrficVltn); //Converts string to object

             if (tbClientTrficVltn == null) //If there is no data, initialize an empty array
                 tbClientTrficVltn = [];

             var detailId = document.getElementById("tdDtlId" + x).innerHTML;
             var s = 0;
             if (document.getElementById("cbStatus" + x).checked == true) {
                 var s = 1;
             }
             else {
                 s = 0;
             }
             // var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
             var evt = document.getElementById("tdEvt" + x).innerHTML;
             var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
             if (SavedorNot == "saved") {
                 //evt = "UPD";

                 var $E = jQuery.noConflict();
                 tbClientTrficVltn[row_index] = JSON.stringify({
                     ROWID: "" + x + "",
                     PARTNER: $E("#txtPartner" + x).val(),
                     DOCNUM: $E("#txtDocumentNo" + x).val(),
                     CRNUM: $E("#txtCRNo" + x).val(),
                     NATION: $E("#ddlDivision_" + x).val(),
                     SHAREPER: $E("#txtSharePerc" + x).val(),

                     STATUS: "" + s + "",
                     EVTACTION: "" + evt + "",
                     DTLID: "0"

                 });
             }





             if (evt == 'INS') {

                 var $E = jQuery.noConflict();
                 tbClientTrficVltn[row_index] = JSON.stringify({
                     ROWID: "" + x + "",
                     PARTNER: $E("#txtPartner" + x).val(),
                     DOCNUM: $E("#txtDocumentNo" + x).val(),
                     CRNUM: $E("#txtCRNo" + x).val(),
                     NATION: $E("#ddlDivision_" + x).val(),
                     SHAREPER: $E("#txtSharePerc" + x).val(),

                     STATUS: "" + s + "",
                     EVTACTION: "" + evt + "",
                     DTLID: "0"

                 });//Alter the selected item on the table
             }
             else {

                 var $E = jQuery.noConflict();
                 tbClientTrficVltn[row_index] = JSON.stringify({
                     ROWID: "" + x + "",
                     PARTNER: $E("#txtPartner" + x).val(),
                     DOCNUM: $E("#txtDocumentNo" + x).val(),
                     CRNUM: $E("#txtCRNo" + x).val(),
                     NATION: $E("#ddlDivision_" + x).val(),
                     SHAREPER: $E("#txtSharePerc" + x).val(),
                     STATUS: "" + s + "",
                     EVTACTION: "" + evt + "",
                     DTLID: "" + detailId + ""

                 });//Alter the selected item on the table

             }





             localStorage.setItem("tbClientTrficVltn", JSON.stringify(tbClientTrficVltn));

             //$E("#cphMain_HiddenFieldAddTable").val(JSON.stringify(tbClientTrficVltn));
             document.getElementById("<%=HiddenFieldAddTable.ClientID%>").value = JSON.stringify(tbClientTrficVltn);

              //for calculation of total Amount
              CalculateTotalAmountFromHiddenField();


              return true;
          }

          function BlurPartner(x) {

              //document.getElementById('divBlink').style.display="none";

              var RcptNumberWithoutReplace = document.getElementById("txtPartner" + x).value;

              var replaceText1 = RcptNumberWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              var replaceText3 = replaceText2.replace(/'/g, "");
              var replaceText4 = replaceText3.replace(/"/g, "");
              var replaceText5 = replaceText4.replace(/\\/g, "");
              document.getElementById("txtPartner" + x).value = replaceText5.trim();
              var row_index = jQuery('#rowId_' + x).index();
              var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
              if (SavedorNot == "saved") {
                  var RcptNumber = document.getElementById("txtPartner" + x).value.trim();
                  if (RcptNumber != "") {
                      document.getElementById("txtPartner" + x).style.borderColor = "";
                      LocalStorageEdit(x, row_index);
                  }
                  else {
                      CheckAllRowFieldAndHighlight(x, false);
                  }
              }
              else {
                  if (SavedorNot == " ") {
                      LocalStorageAdd(x);
                  }

              }
          }
          function BlurDocumentNo(x) {

              //document.getElementById('divBlink').style.display="none";
              var RcptNumberWithoutReplace = document.getElementById("txtDocumentNo" + x).value;
              var replaceText1 = RcptNumberWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              var replaceText3 = replaceText2.replace(/'/g, "");
              var replaceText4 = replaceText3.replace(/"/g, "");
              var replaceText5 = replaceText4.replace(/\\/g, "");
              document.getElementById("txtDocumentNo" + x).value = replaceText5.trim();
              var row_index = jQuery('#rowId_' + x).index();
              var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
              if (SavedorNot == "saved") {
                  var RcptNumber = document.getElementById("txtDocumentNo" + x).value.trim();
                  if (RcptNumber != "") {

                      document.getElementById("txtDocumentNo" + x).style.borderColor = "";
                      LocalStorageEdit(x, row_index);
                  }
              }
              else {
                  if (SavedorNot == " ") {
                      LocalStorageAdd(x);
                  }

              }
          }
          function BlurCrNo(x) {

              //document.getElementById('divBlink').style.display="none";
              var RcptNumberWithoutReplace = document.getElementById("txtCRNo" + x).value;

              var replaceText1 = RcptNumberWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              var replaceText3 = replaceText2.replace(/'/g, "");
              var replaceText4 = replaceText3.replace(/"/g, "");
              var replaceText5 = replaceText4.replace(/\\/g, "");
              document.getElementById("txtCRNo" + x).value = replaceText5.trim();
              var row_index = jQuery('#rowId_' + x).index();
              var SavedorNot = document.getElementById("tdSave" + x).innerHTML;

              if (SavedorNot == "saved") {

                  var RcptNumber = document.getElementById("txtCRNo" + x).value.trim();
                  if (RcptNumber != "") {
                      document.getElementById("txtCRNo" + x).style.borderColor = "";
                      LocalStorageEdit(x, row_index);
                  }
              }
              else {
                  if (SavedorNot == " ") {
                      LocalStorageAdd(x);
                  }

              }
          }
          function BlurNationNo(x) {

              //document.getElementById('divBlink').style.display="none";
              var RcptNumberWithoutReplace = document.getElementById("ddlDivision_" + x).value;
              var replaceText1 = RcptNumberWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              var replaceText3 = replaceText2.replace(/'/g, "");
              var replaceText4 = replaceText3.replace(/"/g, "");
              var replaceText5 = replaceText4.replace(/\\/g, "");
              document.getElementById("ddlDivision_" + x).value = replaceText5.trim();
              var row_index = jQuery('#rowId_' + x).index();
              var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
              if (SavedorNot == "saved") {
                  var RcptNumber = document.getElementById("ddlDivision_" + x).value.trim();

                  if (RcptNumber != "") {
                      document.getElementById("ddlDivision_" + x).style.borderColor = "";
                      $("div#divddlDivision_"+x+" input.ui-autocomplete-input").css("borderColor", "");
                      LocalStorageEdit(x, row_index);
                  }
              }
              else {
                  if (SavedorNot == " ") {
                      LocalStorageAdd(x);
                  }

              }
          }
          function BlurStatus(x) {

              //document.getElementById('divBlink').style.display="none";
              if (document.getElementById("cbStatus" + x).checked == true) {


                  var row_index = jQuery('#rowId_' + x).index();
                  var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
                  if (SavedorNot == "saved") {
                      var RcptNumber = document.getElementById("cbStatus" + x).value.trim();
                      //var RcptNumber = "1";

                      if (RcptNumber != "") {
                          document.getElementById("cbStatus" + x).style.borderColor = "";
                          LocalStorageEdit(x, row_index);
                      }
                  }
                  else {

                      if (SavedorNot == " ") {

                          LocalStorageAdd(x);
                      }

                  }

              }
              else {
                  var row_index = jQuery('#rowId_' + x).index();
                  var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
                  if (SavedorNot == "saved") {
                      var RcptNumber = document.getElementById("cbStatus" + x).value.trim();
                      //var RcptNumber = "1";

                      if (RcptNumber != "") {
                          document.getElementById("cbStatus" + x).style.borderColor = "";
                          LocalStorageEdit(x, row_index);
                      }
                  }
                  else {
                      if (SavedorNot == " ") {

                          LocalStorageAdd(x);
                      }
                  }

              }
          }
          // For adjust to decimal point also used for checking
          function ValueCheck(x, rtn) {


              var ret = true;
              var Val = document.getElementById("txtSharePerc" + x).value;
              if (Val == "") {
                  ret = false;
              }
              else {

                  var amt = parseFloat(Val);

                  if (amt == 0) {

                      ret = false;

                  }
              }
              if (ret == false) {

                  document.getElementById("txtSharePerc" + x).value = "";
              }
              if (rtn == true) {
                  return ret;
              }
          }
          function FocusSharePerc(x) {
              var RcptNumberWithoutReplace = document.getElementById("txtSharePerc" + x).value;

              var replaceText1 = RcptNumberWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              var replaceText3 = replaceText2.replace(/'/g, "");
              var replaceText4 = replaceText3.replace(/"/g, "");
              var replaceText5 = replaceText4.replace(/\\/g, "");

              if (isNaN(replaceText5) == true) {

                  replaceText5 = "";

              }
              if (replaceText5 < 0 || replaceText5 >= 100) {
                  replaceText5 = "";
              }

              document.getElementById("<%=HiddenFocus.ClientID%>").value = replaceText5;

    // CalculateTotalAmountFromHiddenField();
}

        function BlurSharePerc(x) {

    //document.getElementById('divBlink').style.display="none";
    var RcptNumberWithoutReplace = document.getElementById("txtSharePerc" + x).value;

    var replaceText1 = RcptNumberWithoutReplace.replace(/</g, "");
    var replaceText2 = replaceText1.replace(/>/g, "");
    var replaceText3 = replaceText2.replace(/'/g, "");
    var replaceText4 = replaceText3.replace(/"/g, "");
    var replaceText5 = replaceText4.replace(/\\/g, "");

    if (isNaN(replaceText5) == true) {

        replaceText5 = "";

    }
    if (document.getElementById("<%=totelShare.ClientID%>").value == "") {
        document.getElementById("<%=totelShare.ClientID%>").value = 0;

    }
    if (replaceText5 < 0 || replaceText5 > 100) {
        replaceText5 = "";
    }
 
    //   CalculateTotalAmountFromHiddenField();
    if (document.getElementById("<%=HiddenFocus.ClientID%>").value != "")
                CalculateTotalAmountFromHiddenField();
            var CmpnySharePer = document.getElementById("<%=totelShare.ClientID%>").value;
            

            if (x != 1) {
                if (parseFloat(CmpnySharePer) + parseFloat(replaceText5) > 100) {

                    replaceText5 = "";
                }
            }



            document.getElementById("txtSharePerc" + x).value = replaceText5.trim();
            var row_index = jQuery('#rowId_' + x).index();
            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (SavedorNot == "saved") {
                var RcptNumber = document.getElementById("txtSharePerc" + x).value.trim();
                if (RcptNumber != "") {
                    document.getElementById("txtSharePerc" + x).style.borderColor = "";
                    if (ValueCheck(x, true) == true) {
                        LocalStorageEdit(x, row_index);
                    }
                }
            }
            else {
                if (SavedorNot == " ") {
                    if (ValueCheck(x, true) == true) {
                        LocalStorageAdd(x);
                    }
                }

            }
        }




        //calculate total of share%
        function CalculateTotalAmountFromHiddenField() {

            var Total = 0;

            var hiddenVal = document.getElementById("<%=HiddenFieldAddTable.ClientID%>").value;

            if (hiddenVal != "" && hiddenVal != "[]") {

                var find1 = '\\\\';
                var re1 = new RegExp(find1, 'g');

                var res1 = hiddenVal.replace(re1, '');

                var find2 = '\\["';
                var re2 = new RegExp(find2, 'g');

                var res2 = res1.replace(re2, '');

                var find3 = '\\"]';
                var re3 = new RegExp(find3, 'g');

                var res3 = res2.replace(re3, '');

                var jdatas = res3.split("\",\"{");


                var i;
                for (i = 0; i < jdatas.length; i++) {

                    var resultJSON = "";
                    if (i == 0) {
                        resultJSON = jdatas[i];

                    }
                    else {

                        resultJSON = "{" + jdatas[i];

                    }

                    var result = $noCon.parseJSON(resultJSON);

                    $noCon.each(result, function (k, v) {

                        if (k == "SHAREPER") {


                            v = v.split(',').join('');
                            v = parseFloat(v);
                            if (!isNaN(v)) {
                                Total = Total + parseFloat(v);
                            }
                        }
                    });
                }

            }
            var focusper = 0;
            if (document.getElementById("<%=HiddenFocus.ClientID%>").value != "") {
                focusper = document.getElementById("<%=HiddenFocus.ClientID%>").value;
                focusper=parseFloat(focusper);
                if (!isNaN(focusper)) {
                    Total = Total - focusper;
                }

            }
            document.getElementById("<%=totelShare.ClientID%>").value = Total;

            //alert(Total+"a");
            // var focusper = 0;
            // if (document.getElementById("<%=HiddenFocus.ClientID%>").value != "") {
            //    focusper = document.getElementById("<%=HiddenFocus.ClientID%>").value;
            //  alert(focusper+"f");
            // Total = Total - focusper;
            // }
            // alert(Total+"b");
            //if (Total != "" && Total != null && (!isNaN(Total))) {

            //   document.getElementById("<%=totelShare.ClientID%>").value = 100- Total;

            //  }
            // alert(Total+"final")
        }
        function DuplicationPwd() {
            if (document.getElementById('iLogin').style.display == "none") {
                $(".bt_info1").click();
            }
            $("#divWarning").html("Current password is wrong.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtOrgPwd.ClientID%>").style.borderColor = "Red";
            //document.getElementById('LoginInfo').style.height = "170px"
            //document.getElementById('LoginInfo').style.display = "block";

        }
        function DuplicationTx() {
            $("#divWarning").html("Duplication error!. Tax card number can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtTiNumber.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtTiNumber.ClientID%>").focus();
        }
        function DuplicationCr() {
            $("#divWarning").html("Duplication error!. Commercial registration card number can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtCrNumber.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtCrNumber.ClientID%>").focus();
        } function DuplicationComp() {
            $("#divWarning").html("Duplication error!. Computer card number can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtCompNo.ClientID%>").style.borderColor = "Red";            
            document.getElementById("<%=txtCompNo.ClientID%>").focus();
        }
        function DuplicationName() {
            $("#divWarning").html("Duplication error!. Organization name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtOrgName.ClientID%>").style.borderColor = "Red";           
            document.getElementById("<%=txtOrgName.ClientID%>").focus();
        }
        function DuplicationEmail() {
            $("#divWarning").html("Email address already exists, Please change your email and try again");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtOrgEmail.ClientID%>").style.borderColor = "Red";         
            document.getElementById("<%=txtOrgEmail.ClientID%>").focus();
        }
        function ReplaceTag() {

            // replacing < and > tags
            var OrgNameWithoutReplace = document.getElementById("<%=txtOrgName.ClientID%>").value;
            var OrgNamereplaceText1 = OrgNameWithoutReplace.replace(/</g, "");
            var OrgNamereplaceText2 = OrgNamereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgName.ClientID%>").value = OrgNamereplaceText2;
            var OrgAdd1WithoutReplace = document.getElementById("<%=txtOrgAdd1.ClientID%>").value;
            var OrgAdd1replaceText1 = OrgAdd1WithoutReplace.replace(/</g, "");
            var OrgAdd1replaceText2 = OrgAdd1replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgAdd1.ClientID%>").value = OrgAdd1replaceText2;
            var OrgAdd2WithoutReplace = document.getElementById("<%=txtOrgAdd2.ClientID%>").value;
            var OrgAdd2replaceText1 = OrgAdd2WithoutReplace.replace(/</g, "");
            var OrgAdd2replaceText2 = OrgAdd2replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgAdd2.ClientID%>").value = OrgAdd2replaceText2;
            var OrgAdd3WithoutReplace = document.getElementById("<%=txtOrgAdd3.ClientID%>").value;
            var OrgAdd3replaceText1 = OrgAdd3WithoutReplace.replace(/</g, "");
            var OrgAdd3replaceText2 = OrgAdd3replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgAdd3.ClientID%>").value = OrgAdd3replaceText2;
            var OrgZipWithoutReplace = document.getElementById("<%=txtOrgZip.ClientID%>").value;
            var OrgZipreplaceText1 = OrgZipWithoutReplace.replace(/</g, "");
            var OrgZipreplaceText2 = OrgZipreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgZip.ClientID%>").value = OrgZipreplaceText2;
            var OrgPhoneWithoutReplace = document.getElementById("<%=txtOrgPhone.ClientID%>").value;
            var OrgPhonereplaceText1 = OrgPhoneWithoutReplace.replace(/</g, "");
            var OrgPhonereplaceText2 = OrgPhonereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgPhone.ClientID%>").value = OrgPhonereplaceText2;

            var OrgWebsiteWithoutReplace = document.getElementById("<%=txtOrgWebsite.ClientID%>").value;
            var OrgWebsitereplaceText1 = OrgWebsiteWithoutReplace.replace(/</g, "");
            var OrgWebsitereplaceText2 = OrgWebsitereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgWebsite.ClientID%>").value = OrgWebsitereplaceText2;

            var OrgEmailWithoutReplace = document.getElementById("<%=txtOrgEmail.ClientID%>").value;
            var OrgEmailreplaceText1 = OrgEmailWithoutReplace.replace(/</g, "");
            var OrgEmailreplaceText2 = OrgEmailreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgEmail.ClientID%>").value = OrgEmailreplaceText2;
            var OrgPwdWithoutReplace = document.getElementById("<%=txtOrgPwd.ClientID%>").value;
            var OrgPwdreplaceText1 = OrgPwdWithoutReplace.replace(/</g, "");
            var OrgPwdreplaceText2 = OrgPwdreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgPwd.ClientID%>").value = OrgPwdreplaceText2;
            var OrgConPwdWithoutReplace = document.getElementById("<%=txtOrgConPwd.ClientID%>").value;
            var OrgConPwdreplaceText1 = OrgConPwdWithoutReplace.replace(/</g, "");
            var OrgConPwdreplaceText2 = OrgConPwdreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgConPwd.ClientID%>").value = OrgConPwdreplaceText2;
            var OrgNewPwdWithoutReplace = document.getElementById("<%=txtOrgNewPwd.ClientID%>").value;
            var OrgNewPwdreplaceText1 = OrgNewPwdWithoutReplace.replace(/</g, "");
            var OrgNewPwdreplaceText2 = OrgNewPwdreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgNewPwd.ClientID%>").value = OrgNewPwdreplaceText2;
            __doPostBack('', '');
            return false;
        }




        function OrgParkingNullValidation() {

            var ret = true;
            //if (CheckIsRepeat() == true) {
            //}
            //else {
            //    ret = false;
            //    return ret;
            //}

            // replacing < and > tags
            document.getElementById("<%=hiddenNation.ClientID%>").value = "";
            var OrgNameWithoutReplace = document.getElementById("<%=txtOrgName.ClientID%>").value;
            var OrgNamereplaceText1 = OrgNameWithoutReplace.replace(/</g, "");
            var OrgNamereplaceText2 = OrgNamereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgName.ClientID%>").value = OrgNamereplaceText2;

            var OrgAdd1WithoutReplace = document.getElementById("<%=txtOrgAdd1.ClientID%>").value;
            var OrgAdd1replaceText1 = OrgAdd1WithoutReplace.replace(/</g, "");
            var OrgAdd1replaceText2 = OrgAdd1replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgAdd1.ClientID%>").value = OrgAdd1replaceText2;

            var OrgAdd2WithoutReplace = document.getElementById("<%=txtOrgAdd2.ClientID%>").value;
            var OrgAdd2replaceText1 = OrgAdd2WithoutReplace.replace(/</g, "");
            var OrgAdd2replaceText2 = OrgAdd2replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgAdd2.ClientID%>").value = OrgAdd2replaceText2.trim();
            var OrgAdd3WithoutReplace = document.getElementById("<%=txtOrgAdd3.ClientID%>").value;
            var OrgAdd3replaceText1 = OrgAdd3WithoutReplace.replace(/</g, "");
            var OrgAdd3replaceText2 = OrgAdd3replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgAdd3.ClientID%>").value = OrgAdd3replaceText2.trim();
            var OrgZipWithoutReplace = document.getElementById("<%=txtOrgZip.ClientID%>").value;
            var OrgZipreplaceText1 = OrgZipWithoutReplace.replace(/</g, "");
            var OrgZipreplaceText2 = OrgZipreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgZip.ClientID%>").value = OrgZipreplaceText2;
            var OrgPhoneWithoutReplace = document.getElementById("<%=txtOrgPhone.ClientID%>").value;
            var OrgPhonereplaceText1 = OrgPhoneWithoutReplace.replace(/</g, "");
            var OrgPhonereplaceText2 = OrgPhonereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgPhone.ClientID%>").value = OrgPhonereplaceText2;
            var OrgWebsiteWithoutReplace = document.getElementById("<%=txtOrgWebsite.ClientID%>").value;
            var OrgWebsitereplaceText1 = OrgWebsiteWithoutReplace.replace(/</g, "");
            var OrgWebsitereplaceText2 = OrgWebsitereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgWebsite.ClientID%>").value = OrgWebsitereplaceText2;
            var OrgEmailWithoutReplace = document.getElementById("<%=txtOrgEmail.ClientID%>").value;
            var OrgEmailreplaceText1 = OrgEmailWithoutReplace.replace(/</g, "");
            var OrgEmailreplaceText2 = OrgEmailreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgEmail.ClientID%>").value = OrgEmailreplaceText2;
            var OrgPwdWithoutReplace = document.getElementById("<%=txtOrgPwd.ClientID%>").value;
            var OrgPwdreplaceText1 = OrgPwdWithoutReplace.replace(/</g, "");
            var OrgPwdreplaceText2 = OrgPwdreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgPwd.ClientID%>").value = OrgPwdreplaceText2;
            var OrgConPwdWithoutReplace = document.getElementById("<%=txtOrgConPwd.ClientID%>").value;
            var OrgConPwdreplaceText1 = OrgConPwdWithoutReplace.replace(/</g, "");
            var OrgConPwdreplaceText2 = OrgConPwdreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgConPwd.ClientID%>").value = OrgConPwdreplaceText2;
            var OrgNewPwdWithoutReplace = document.getElementById("<%=txtOrgNewPwd.ClientID%>").value;
            var OrgNewPwdreplaceText1 = OrgNewPwdWithoutReplace.replace(/</g, "");
            var OrgNewPwdreplaceText2 = OrgNewPwdreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgNewPwd.ClientID%>").value = OrgNewPwdreplaceText2;
            //0013 

            var CrNumWithoutReplace = document.getElementById("<%=txtCrNumber.ClientID%>").value;
            var CrNumreplaceText1 = CrNumWithoutReplace.replace(/</g, "");
            var CrNumreplaceText2 = CrNumreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCrNumber.ClientID%>").value = CrNumreplaceText2;
            var ExpCrDateWithoutReplace = document.getElementById("<%=txtExpCrDate.ClientID%>").value;
            var ExpCrDatereplaceText1 = ExpCrDateWithoutReplace.replace(/</g, "");
            var ExpCrDatereplaceText2 = ExpCrDatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtExpCrDate.ClientID%>").value = ExpCrDatereplaceText2;
            //0013+

            //0013+

            var IssueCrDateWithoutReplace = document.getElementById("<%=txtIssueCrDate.ClientID%>").value;
            var IssueCrDatereplaceText1 = IssueCrDateWithoutReplace.replace(/</g, "");
            var IssueCrDatereplaceText2 = IssueCrDatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtIssueCrDate.ClientID%>").value = IssueCrDatereplaceText2;
            var TiNumberWithoutReplace = document.getElementById("<%=txtTiNumber.ClientID%>").value;
            var TiNumberreplaceText1 = TiNumberWithoutReplace.replace(/</g, "");
            var TiNumberreplaceText2 = TiNumberreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTiNumber.ClientID%>").value = TiNumberreplaceText2;
            var ExpTxDateWithoutReplace = document.getElementById("<%=txtExpTxDate.ClientID%>").value;
            var ExpTxDatereplaceText1 = ExpTxDateWithoutReplace.replace(/</g, "");
            var ExpTxDatereplaceText2 = ExpTxDatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtExpTxDate.ClientID%>").value = ExpTxDatereplaceText2;
            //0013+


            //0013+
            var IssueTxDateWithoutReplace = document.getElementById("<%=txtIssueTxDate.ClientID%>").value;
            var IssueTxDatereplaceText1 = IssueTxDateWithoutReplace.replace(/</g, "");
            var IssueTxDatereplaceText2 = IssueTxDatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtIssueTxDate.ClientID%>").value = IssueTxDatereplaceText2;
            var CompNoWithoutReplace = document.getElementById("<%=txtCompNo.ClientID%>").value;
            var CompNoreplaceText1 = CompNoWithoutReplace.replace(/</g, "");
            var CompNoreplaceText2 = CompNoreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCompNo.ClientID%>").value = CompNoreplaceText2;
            var ExpCompDateWithoutReplace = document.getElementById("<%=txtExpCompDate.ClientID%>").value;
            var ExpCompDatereplaceText1 = ExpCompDateWithoutReplace.replace(/</g, "");
            var ExpCompDatereplaceText2 = ExpCompDatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtExpCompDate.ClientID%>").value = ExpCompDatereplaceText2;
            //0013+


            //0013+
            var IssueCompDateWithoutReplace = document.getElementById("<%=txtIssueCompDate.ClientID%>").value;
            var IssueCompDatereplaceText1 = IssueCompDateWithoutReplace.replace(/</g, "");
            var IssueCompDatereplaceText2 = IssueCompDatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtIssueCompDate.ClientID%>").value = IssueCompDatereplaceText2;

            var OrgnType = document.getElementById("<%=ddlOrgType.ClientID%>");

            var OrgType = OrgnType.options[OrgnType.selectedIndex].text;

            var OrgnCountry = document.getElementById("<%=ddlOrgCountry.ClientID%>");
            var OrgCountry = OrgnCountry.options[OrgnCountry.selectedIndex].text;

            var OrgName = document.getElementById("<%=txtOrgName.ClientID%>").value.trim();

            var OrgAdd = document.getElementById("<%=txtOrgAdd1.ClientID%>").value.trim();

            var OrgMobile = document.getElementById("<%=txtOrgMobile.ClientID%>").value;
            var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;

            //email


            var web = document.getElementById("<%=txtOrgWebsite.ClientID%>").value;
            var re = /^(http[s]?:\/\/){0,1}(www\.){0,1}[a-zA-Z0-9\.\-]+\.[a-zA-Z]{2,5}[\.]{0,1}/;
            var Email = document.getElementById("<%=txtOrgEmail.ClientID%>");
            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            var OrgPwd = document.getElementById("<%=txtOrgNewPwd.ClientID%>").value;

            var minNumberofChars = 6;
            var maxNumberofChars = 16;
            //var regularExpression = /(?=.*\d)(?=.*[~!@#$%^&*])(?=.*[a-z])|(?=.*[A-Z])[0-9!@#$%^&*].{6,16}/;
            var regularExpression = /(?=.*\d)(?=.*[~!@#$%^&*])(?=.*[A-Za-z])|(?=.*[A-Z])[0-9!@#$%^&*].{6,16}/;
            var OrgConPwd = document.getElementById("<%=txtOrgConPwd.ClientID%>").value;

            var OrgnLicPac = document.getElementById("<%=ddlOrgLicPac.ClientID%>");
            var OrgLicPac = OrgnLicPac.options[OrgnLicPac.selectedIndex].text;

            var OrgnCorPac = document.getElementById("<%=ddlOrgCorPac.ClientID%>");
            var OrgCorPac = OrgnCorPac.options[OrgnCorPac.selectedIndex].text;

            //0013
            var CRnum = document.getElementById("<%=txtCrNumber.ClientID%>").value;
            var CrExDate = document.getElementById("<%=txtExpCrDate.ClientID%>").value;
            //0013+
            var CrIssuDate = document.getElementById("<%=txtIssueCrDate.ClientID%>").value;

            var TxNum = document.getElementById("<%=txtTiNumber.ClientID%>").value;
            var TxExDate = document.getElementById("<%=txtExpTxDate.ClientID%>").value;
            //0013+

            var TxIssuDate = document.getElementById("<%=txtIssueTxDate.ClientID%>").value;

            var CompNum = document.getElementById("<%=txtCompNo.ClientID%>").value;
            var CompExDate = document.getElementById("<%=txtExpCompDate.ClientID%>").value;
            //0013+

            var CompIssuDate = document.getElementById("<%=txtIssueCompDate.ClientID%>").value;

            var CaptchaWithoutReplace = document.getElementById('txtCaptcha').value;
            var CaptchareplaceText1 = CaptchaWithoutReplace.replace(/</g, "");
            var CaptchareplaceText2 = CaptchareplaceText1.replace(/>/g, "");
            document.getElementById('txtCaptcha').value = CaptchareplaceText2;
            document.getElementById('txtCaptcha').style.borderColor = "";
            var Captcha = document.getElementById('txtCaptcha').value;
            var CaptchaHidden = document.getElementById("<%=hiddenCaptcha.ClientID%>").value;
            document.getElementById('lblcaptcha').style.display = "none";


            if (document.getElementById("<%=ddlOrgCity.ClientID%>").value != null && document.getElementById("<%=ddlOrgCity.ClientID%>").value != "--Select City--" && document.getElementById("<%=ddlOrgCity.ClientID%>").value != 0) {
                document.getElementById("<%=HiddenCityValue.ClientID%>").value = document.getElementById("<%=ddlOrgCity.ClientID%>").value;
            }

            if (document.getElementById("<%=ddlOrgState.ClientID%>").value != null && document.getElementById("<%=ddlOrgState.ClientID%>").value != "--Select State--" && document.getElementById("<%=ddlOrgState.ClientID%>").value != 0) {

                document.getElementById("<%=HiddenStateValue.ClientID%>").value = document.getElementById("<%=ddlOrgState.ClientID%>").value;
            }

            document.getElementById("<%=txtOrgConPwd.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtOrgPwd.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtOrgEmail.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlOrgCorPac.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlOrgLicPac.ClientID%>").style.borderColor = "";
            $("div#divLpack input.ui-autocomplete-input").css("borderColor", "");
            $("div#divCpack input.ui-autocomplete-input").css("borderColor", "");      
            document.getElementById("<%=txtOrgMobile.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlOrgCountry.ClientID%>").style.borderColor = "";
            $("div#divCntry input.ui-autocomplete-input").css("borderColor", "");

            document.getElementById("<%=txtOrgAdd1.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtOrgName.ClientID%>").style.borderColor = "";
            document.getElementById("<%= ddlOrgType.ClientID%>").style.borderColor = "";
            $("div#divOtype input.ui-autocomplete-input").css("borderColor", "");
            
            document.getElementById("<%= txtOrgWebsite.ClientID%>").style.borderColor = "";
            //0013
            document.getElementById("<%= txtCrNumber.ClientID%>").style.borderColor = "";
            document.getElementById("<%= txtExpCrDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%= txtIssueCrDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%= txtTiNumber.ClientID%>").style.borderColor = "";
            document.getElementById("<%= txtExpTxDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%= txtIssueTxDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%= txtCompNo.ClientID%>").style.borderColor = "";
            document.getElementById("<%= txtExpCompDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%= txtIssueCompDate.ClientID%>").style.borderColor = "";

            document.getElementById('ErrorMsgOrgType').style.display="none";
            document.getElementById('ErrorMsgOrgName').style.display="none";
            document.getElementById('ErrorMsgOrgAdd1').style.display="none";
            document.getElementById('ErrorMsgOrgCountry').style.display="none";
            document.getElementById('ErrorMsgOrgMobile').style.display="none";
            document.getElementById('ErrorMsgOrgLicPac').style.display="none";
            document.getElementById('ErrorMsgOrgCorPac').style.display="none";

            document.getElementById('ErrorMsgOrgEmail').style.display="none";
            document.getElementById('PwdMsg').style.display="none";
            document.getElementById('PwdMsg').innerHTML = "";
            document.getElementById('ErrorMsgOrgConPwd').style.display="none";
            //document.getElementById('divMessageArea').style.display="none";
           

            var datepickerDate = document.getElementById("<%=txtExpCrDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateCRExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDate = document.getElementById("<%=txtIssueCrDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateCRIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDate = document.getElementById("<%=txtExpTxDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateTxExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDate = document.getElementById("<%=txtIssueTxDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDate = document.getElementById("<%=txtExpCompDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDate = document.getElementById("<%=txtIssueCompDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateCompIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);


            if (web != "") {
                if (!re.test(web)) {
                    document.getElementById('ErrorMsgOrgWebsite').style.display = "";
                    document.getElementById("<%=txtOrgWebsite.ClientID%>").focus();
                    document.getElementById("<%=txtOrgWebsite.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }

            }

            var TableRowCount = document.getElementById("TableaddedRows").rows.length;

            if (TableRowCount != 0) {

                if (TableRowCount == 1) {
                    //if added a row not entered any value validate

                    var idlast = $noCon('#TableaddedRows tr:last').attr('id');

                    if (idlast != "") {
                        var res = idlast.split("_");
                        var x = res[1];

                        if (CheckAllRowFieldAndHighlight(x, false) == false) {
                            ret = false;
                        }

                        if (ret == false) {

                            $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                        }

                    }
                    else {
                        ret = false;
                    }

                    if (ret == false) {
                        CheckSubmitZero();
                    }

                    //return ret;

                }

                else { //ok

                    var table = document.getElementById('TableaddedRows');
                    for (var i = 0; i < table.rows.length; i++) {// FIX THIS
                        var row = table.rows[i];
                        var xLoop = (table.rows[i].cells[0].innerHTML);
                        if (CheckAllRowFieldAndHighlight(xLoop, false) == false) {
                            ret = false;
                        }

                    }
                    if (ret == true) {
                        var idlast = $noCon('#TableaddedRows tr:last').attr('id');
                        if (idlast != "") {
                            var res = idlast.split("_");
                            var x = res[1];
                            var VioltnDate = document.getElementById("txtSharePerc" + x).value.trim();
                            if (VioltnDate != "") {
                                if (CheckAllRowFieldAndHighlight(x, false) == false) {
                                    ret = false;
                                }
                            }
                            if (ret == false) {

                                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                });
                            }
                        }
                        else {
                            ret = false;
                        }

                    }
                    else if (ret == false) {

                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                    }
                    //return ret;

            }


        }//ok
        else {
                $("#divWarning").html("Sorry, Please add atleast one item to save!");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
             CheckSubmitZero();
             ret = false;
                //return false;
         }

         if (dateCRIss > dateCRExp) {

             document.getElementById("<%=txtIssueCrDate.ClientID%>").style.borderColor = "Red";
              document.getElementById("<%=txtIssueCrDate.ClientID%>").focus();
             $("#divWarning").html("Sorry, Issue date of commercial registration card cannot be greater than expiry date !.");
             $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
             });
            ret = false;
        }
        if (dateTxIss > dateTxExp) {
            document.getElementById("<%=txtIssueTxDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtIssueTxDate.ClientID%>").focus();
            $("#divWarning").html("Sorry, Issue date of tax card cannot be greater than expiry date !.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
               
                ret = false;
            }
            if (dateCompIss > dateCompExp) {
                document.getElementById("<%=txtIssueCompDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtIssueCompDate.ClientID%>").focus();
                $("#divWarning").html("Sorry, Issue date of computer card cannot be greater than expiry date !.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });              
                    ret = false;
                }



            if (Captcha == "") {
                document.getElementById('txtCaptcha').style.borderColor = "Red";
                document.getElementById('lblcaptcha').textContent = "Captcha required";
                document.getElementById('lblcaptcha').style.display = "";
                document.getElementById('txtCaptcha').focus();
                ret = false;
            }
            else {


                if (Captcha != CaptchaHidden) {

                    //$.alert("Enter Valid Captcha Code");

                    //alert('Enter Valid Captcha Code');
                    document.getElementById('txtCaptcha').style.borderColor = "Red";
                    document.getElementById('lblcaptcha').textContent = " Captcha mismatch";
                    document.getElementById('lblcaptcha').style.display = "";
                    document.getElementById('txtCaptcha').focus();
                    ret = false;
                }
            }

            //fileupload

            if (OrgPwd != null && OrgPwd != "") {

     

                    if (document.getElementById("<%=txtOrgPwd.ClientID%>").value.trim() == "") {
                            
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                            document.getElementById("<%=txtOrgPwd.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtOrgPwd.ClientID%>").focus();
                            ret = false;
                        }

                if (OrgPwd.length < minNumberofChars || OrgPwd.length > maxNumberofChars || !regularExpression.test(OrgPwd) || OrgConPwd != OrgPwd) {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    if (OrgConPwd != OrgPwd) {

                        if (document.getElementById('iLogin').style.display == "none") {
                            $(".bt_info1").click();
                        }

                        document.getElementById('ErrorMsgOrgConPwd').style.display = "";
                        document.getElementById("<%=txtOrgConPwd.ClientID%>").focus();
                        document.getElementById("<%=txtOrgConPwd.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtOrgNewPwd.ClientID%>").style.borderColor = "Red";
                        //document.getElementById('LoginInfo').style.height = "170px"
                        //document.getElementById('LoginInfo').style.display = "block";
                        ret = false;
                    }

                    if (!regularExpression.test(OrgPwd)) {
                        document.getElementById('PwdMsg').style.display = "";
                        //document.getElementById('PwdMsg').innerHTML = "Password Must Contain 6-16 Characters with atleast one number, special character and alphabet";
                        document.getElementById("<%=txtOrgNewPwd.ClientID%>").focus();
                        document.getElementById("<%=txtOrgNewPwd.ClientID%>").style.borderColor = "Red";
                        ret = false;
                    }
                    if (OrgPwd.length < minNumberofChars || OrgPwd.length > maxNumberofChars) {

                        document.getElementById('PwdMsg').style.display = "";
                        //document.getElementById('PwdMsg').innerHTML = "Password Must Contain 6-16 Characters with atleast one number, special character and alphabet";
                        document.getElementById("<%=txtOrgNewPwd.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtOrgNewPwd.ClientID%>").focus();
                        ret = false;
                    }
                }
            }
            
                if (OrgType == "--Select Organization Type--" || OrgName == "" || OrgAdd == "" || OrgCountry == "--Select Your Country--" || OrgMobile.length < "10" || !filter.test(Email.value) || OrgLicPac == "--Choose Your License Pack--" || OrgCorPac == "--Choose Your Corporate Pack--" || CRnum == "" || CrExDate == "" || CrIssuDate == "" || TxNum == "" || TxExDate == "" || TxIssuDate == "" || CompNum == "" || CompExDate == "" || CompIssuDate == "") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });


                    if (OrgPwd != null && OrgPwd != "") {

             

                            if (document.getElementById("<%=txtOrgPwd.ClientID%>").value.trim() == "") {
                            
                                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                });
                            document.getElementById("<%=txtOrgPwd.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtOrgPwd.ClientID%>").focus();
                            ret = false;
                        }
                        if (OrgPwd.length < minNumberofChars || OrgPwd.length > maxNumberofChars || !regularExpression.test(OrgPwd) || OrgConPwd != OrgPwd) {
                            $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });

                            if (OrgConPwd != OrgPwd) {
                                if (document.getElementById('iLogin').style.display == "none") {
                                    $(".bt_info1").click();
                                }
                                document.getElementById('ErrorMsgOrgConPwd').style.display = "";
                                document.getElementById("<%=txtOrgConPwd.ClientID%>").focus();
                                document.getElementById("<%=txtOrgConPwd.ClientID%>").style.borderColor = "Red";
                                //document.getElementById('LoginInfo').style.height = "170px"
                                //document.getElementById('LoginInfo').style.display = "block";

                            ret = false;
                        }

                        if (!regularExpression.test(OrgPwd)) {
                            document.getElementById('PwdMsg').style.display = "";
                            //document.getElementById('PwdMsg').innerHTML = "Password Must Contain 6-16 Characters with atleast one number, special character and alphabet";
                            document.getElementById("<%=txtOrgPwd.ClientID%>").focus();
                            document.getElementById("<%=txtOrgPwd.ClientID%>").style.borderColor = "Red";
                            ret = false;
                        }
                        if (OrgPwd.length < minNumberofChars || OrgPwd.length > maxNumberofChars) {

                            document.getElementById('PwdMsg').style.display = "";
                            //document.getElementById('PwdMsg').innerHTML = "Password Must Contain 6-16 Characters with atleast one number, special character and alphabet";
                            document.getElementById("<%=txtOrgPwd.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtOrgPwd.ClientID%>").focus();
                            ret = false;
                        }
                    }
                }


                if (!filter.test(Email.value)) {
                    document.getElementById('ErrorMsgOrgEmail').style.display = "";
                    EmailAdd = "";
                    if (document.getElementById('iLogin').style.display == "none") {
                        $(".bt_info1").click();
                    }
                    document.getElementById("<%=txtOrgEmail.ClientID%>").focus();
                    document.getElementById("<%=txtOrgEmail.ClientID%>").style.borderColor = "Red";
                    //document.getElementById('LoginInfo').style.height = "170px"
                    //document.getElementById('LoginInfo').style.display = "block";

                    ret = false;
                }
                if (OrgCorPac == "--Choose Your Corporate Pack--") {
                    

                    $("div#divCpack input.ui-autocomplete-input").css("borderColor", "red");
                    $("div#divCpack input.ui-autocomplete-input").select();
                    $("div#divCpack input.ui-autocomplete-input").focus();
                    document.getElementById("<%=ddlOrgCorPac.ClientID%>").focus();
                    document.getElementById("<%=ddlOrgCorPac.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (OrgLicPac == "--Choose Your License Pack--") {

                    $("div#divLpack input.ui-autocomplete-input").css("borderColor", "red");
                    $("div#divLpack input.ui-autocomplete-input").select();
                    $("div#divLpack input.ui-autocomplete-input").focus();

                    document.getElementById("<%=ddlOrgLicPac.ClientID%>").focus();
                    document.getElementById("<%=ddlOrgLicPac.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (!mobileregular.test(OrgMobile)) {
                    document.getElementById('ErrorMsgOrgMobile').style.display = "";
                    document.getElementById("<%=txtOrgMobile.ClientID%>").focus();
                    document.getElementById("<%=txtOrgMobile.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (OrgCountry == "--Select Your Country--") {

                    document.getElementById("<%=ddlOrgCountry.ClientID%>").focus();
                    document.getElementById("<%=ddlOrgCountry.ClientID%>").style.borderColor = "Red";

                    $("div#divCntry input.ui-autocomplete-input").css("borderColor", "red");
                    $("div#divCntry input.ui-autocomplete-input").select();
                    $("div#divCntry input.ui-autocomplete-input").focus();

                    ret = false;
                }
                if (OrgAdd == "") {

                    document.getElementById("<%=txtOrgAdd1.ClientID%>").focus();
                    document.getElementById("<%=txtOrgAdd1.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (OrgName == "") {
                    document.getElementById("<%=txtOrgName.ClientID%>").focus();
                    document.getElementById("<%=txtOrgName.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (OrgType == "--Select Organization Type--") {
                    
                    $("div#divOtype input.ui-autocomplete-input").css("borderColor", "red");
                    $("div#divOtype input.ui-autocomplete-input").select();
                    $("div#divOtype input.ui-autocomplete-input").focus();
                    document.getElementById("<%= ddlOrgType.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%= ddlOrgType.ClientID%>").focus();
                    ret = false;
                }
                    //0013
                if (CRnum == "") {
                    document.getElementById("<%=txtCrNumber.ClientID%>").focus();
                    document.getElementById("<%=txtCrNumber.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (CrExDate == "") {
                    document.getElementById("<%=txtExpCrDate.ClientID%>").focus();
                    document.getElementById("<%=txtExpCrDate.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (CrIssuDate == "") {
                    document.getElementById("<%=txtIssueCrDate.ClientID%>").focus();
                    document.getElementById("<%=txtIssueCrDate.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (TxNum == "") {
                    document.getElementById("<%=txtTiNumber.ClientID%>").focus();
                    document.getElementById("<%=txtTiNumber.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (TxExDate == "") {
                    document.getElementById("<%=txtExpTxDate.ClientID%>").focus();
                    document.getElementById("<%=txtExpTxDate.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (TxIssuDate == "") {
                    document.getElementById("<%=txtIssueTxDate.ClientID%>").focus();
                    document.getElementById("<%=txtIssueTxDate.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (CompNum == "") {
                    document.getElementById("<%=txtCompNo.ClientID%>").focus();
                    document.getElementById("<%=txtCompNo.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (CompExDate == "") {
                    document.getElementById("<%=txtExpCompDate.ClientID%>").focus();
                    document.getElementById("<%=txtExpCompDate.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (CompIssuDate == "") {
                    document.getElementById("<%=txtIssueCompDate.ClientID%>").focus();
                    document.getElementById("<%=txtIssueCompDate.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }



            }

          
            if (ret == false) {
                CheckSubmitZero();
            }
            $noConflict = jQuery.noConflict();

            $noConflict('html, body').animate({ scrollTop: 0 }, 500);
            return ret;

        }
    </script>
    <script type="text/javascript">
        function isNumber(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //enter
            if (keyCodes == 13) {
                // return false;
            }
                //0-9
            else if (keyCodes >= 48 && keyCodes <= 57) {
                return true;
            }
                //numpad 0-9
            else if (keyCodes >= 96 && keyCodes <= 105) {
                return true;
            }
                //left arrow key,right arrow key,home,end ,delete,UP ARROW ,DOWN ARROW
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                return true;

            }
            else if (keyCodes == 190 || keyCodes == 110) {
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
        function isNumberDot(evt, textboxid) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            var txtPerVal = document.getElementById(textboxid).value;
            //enter
            if (keyCodes == 13) {

                //if (textboxid == "cphMain_txtCalciText") {
                //    CalculateAmount();
                //    return false;
                //} else {
                return false;
                //}

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
                // . period and numpad . period
            else if (keyCodes == 190 || keyCodes == 110) {
                var ret = true;

                var count = txtPerVal.split('.').length - 1;

                if (count > 0) {

                    ret = false;
                }
                else {
                    ret = true;
                }
                return ret;

            }

            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                }
                return ret;
            }

        }
        // for not allowing <> tags
        function isTag(evt) {

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
        // for not allowing <> tags
        function RemoveTag(evt) {

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
        }
        function controlTab(obj, event) {
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 9) {
                document.getElementById(obj).focus();
                return false;
            }

            else {
                return true;
            }
        }
        function BlurNotNumber(obj) {
            var txt = document.getElementById(obj).value;

            if (txt != "") {

                if (isNaN(txt)) {
                    document.getElementById(obj).value = "";
                    document.getElementById(obj).focus();
                    return false;

                }


            }
        }
        function Password_Strength(event) {

            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            var charCode = (event.which) ? event.which : event.keyCode;
            var OrgPwd = document.getElementById("<%=txtOrgNewPwd.ClientID%>").value;
            var ErrorMsg = document.getElementById('PwdMsg').style.display="none";
            if (keyCode == 13) {

                return false;
            }
            else if (charCode == 60 || charCode == 62) {
                return false;

            }
            else {
                if (OrgPwd.length < 10) {

                    document.getElementById('PwdMsg').style.display = "visible";
                    document.getElementById('PwdMsg').style.color = "red";
                    document.getElementById('PwdMsg').innerHTML = "WEAK";
                    return true;
                }
                if (OrgPwd.length >= 10 && OrgPwd.length < 13) {
                    document.getElementById('PwdMsg').style.display = "visible";
                    document.getElementById('PwdMsg').style.color = "orange";
                    document.getElementById('PwdMsg').innerHTML = "MEDUIM";
                    return true;
                }
                if (OrgPwd.length >= 13) {
                    document.getElementById('PwdMsg').style.display = "visible";
                    document.getElementById('PwdMsg').style.color = "green";
                    document.getElementById('PwdMsg').innerHTML = "STRONG";
                    return true;
                }
                return true;
            }
        }
        function Paste() {

        }

    </script>
    <script>

        $noCon2 = jQuery.noConflict();
        //ddlOrgCorPac load
        function FillDllCorpPackLoad() {
            var ddlTestDropDownListXML = $noCon2("#ddlOrgCorPac");
            var tableName = "dtTableCorp";
            if (document.getElementById("<%=hiddenCorp.ClientID%>").value != 0) {

                var dataLicPack = document.getElementById("<%=hiddenCorp.ClientID%>").value;
                var OptionStart = $noCon2("<option>--Choose Your Corporate Pack--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);

                // Now find the Table from response and loop through each item (row).
                $noCon2(dataLicPack).find(tableName).each(function () {

                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noCon2(this).find('CORP_PACK_ID').text();
                    var OptionText = $noCon2(this).find('CORP_PACK_NAME').text();
                    // Create an Option for DropDownList.

                    var option = $noCon2("<option>" + OptionText + "</option>");

                    option.attr("value", OptionValue);
                    ddlTestDropDownListXML.append(option);

                });

            }
            else {



                $noCon2.ajax({
                    type: "POST",
                    url: "Gen_Orgnization.aspx/DropdownCorpBind",
                    data: '{tableName:"' + tableName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $noCon2("<option>--Choose Your Corporate Pack--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);

                        // Now find the Table from response and loop through each item (row).
                        $noCon2(response.d).find(tableName).each(function () {

                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noCon2(this).find('CORP_PACK_ID').text();
                            var OptionText = $noCon2(this).find('CORP_PACK_NAME').text();
                            // Create an Option for DropDownList.

                            var option = $noCon2("<option>" + OptionText + "</option>");

                            option.attr("value", OptionValue);
                            ddlTestDropDownListXML.append(option);

                        });
                    },
                    failure: function (response) {

                    }
                });
            }
        }
        //ddlLicPack load
        function FillDllLicPackLoad() {
            var ddlTestDropDownListXML = $noCon2("#ddlOrgLicPac");
            var tableName = "dtTableLic";
            if (document.getElementById("<%=hiddenLic.ClientID%>").value != 0) {

                var dataLicPack = document.getElementById("<%=hiddenLic.ClientID%>").value;
                var OptionStart = $noCon2("<option>--Choose Your License Pack--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);

                // Now find the Table from response and loop through each item (row).
                $noCon2(dataLicPack).find(tableName).each(function () {

                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noCon2(this).find('LIC_PACK_ID').text();
                    var OptionText = $noCon2(this).find('LIC_PACK_NAME').text();
                    // Create an Option for DropDownList.

                    var option = $noCon2("<option>" + OptionText + "</option>");

                    option.attr("value", OptionValue);
                    ddlTestDropDownListXML.append(option);

                });

            }
            else {



                $noCon2.ajax({
                    type: "POST",
                    url: "Gen_Orgnization.aspx/DropdownLicBind",
                    data: '{tableName:"' + tableName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $noCon2("<option>--Choose Your License Pack--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);

                        // Now find the Table from response and loop through each item (row).
                        $noCon2(response.d).find(tableName).each(function () {

                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noCon2(this).find('LIC_PACK_ID').text();
                            var OptionText = $noCon2(this).find('LIC_PACK_NAME').text();
                            // Create an Option for DropDownList.

                            var option = $noCon2("<option>" + OptionText + "</option>");

                            option.attr("value", OptionValue);
                            ddlTestDropDownListXML.append(option);

                        });
                    },
                    failure: function (response) {

                    }
                });
            }
        }

        //ddlorgcountry load
        function FillDllContryDdl(rowCount) {
            var ddlTestDropDownListXML = $noCon2("#ddlDivision_" + rowCount);
            var tableName = "dtTableNation";
            if (document.getElementById("<%=hiddenNation.ClientID%>").value != "") {

                var dataNation = document.getElementById("<%=hiddenNation.ClientID%>").value;
                var OptionStart = $noCon2("<option>--SELECT NATION--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);

                // Now find the Table from response and loop through each item (row).
                $noCon2(dataNation).find(tableName).each(function () {

                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noCon2(this).find('CNTRY_ID').text();
                    var OptionText = $noCon2(this).find('CNTRY_NAME').text();
                    // Create an Option for DropDownList.

                    var option = $noCon2("<option>" + OptionText + "</option>");

                    option.attr("value", OptionValue);
                    ddlTestDropDownListXML.append(option);

                });

            }
            else {

                //var ddlTestDropDownListXML = $noCon2("#ddlDivision_" + rowCount);

                $noCon2.ajax({
                    type: "POST",
                    url: "Gen_Orgnization.aspx/DropdownContryBind",
                    data: '{tableName:"' + tableName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $noCon2("<option>--SELECT NATION--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);

                        // Now find the Table from response and loop through each item (row).
                        $noCon2(response.d).find(tableName).each(function () {

                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noCon2(this).find('CNTRY_ID').text();
                            var OptionText = $noCon2(this).find('CNTRY_NAME').text();
                            // Create an Option for DropDownList.

                            var option = $noCon2("<option>" + OptionText + "</option>");

                            option.attr("value", OptionValue);
                            ddlTestDropDownListXML.append(option);

                        });
                    },
                    failure: function (response) {

                    }
                });
            }
        }

        function CorpPackCount() {

            var CorpPacId = document.getElementById("<%=ddlOrgCorPac.ClientID%>").value;
            var $coo = jQuery.noConflict();
            if (CorpPacId != "--Choose Your Corporate Pack--") {

                $coo.ajax({
                    type: "POST",
                    url: "Gen_Orgnization.aspx/changeCorpPack",
                    data: '{CorpPacId:"' + CorpPacId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        document.getElementById("<%=txtCorPacCount.ClientID%>").innerHTML = "Count<i class=\"fa fa-hashtag\"></i>: " + response.d;
                        document.getElementById("<%=HiddenFieldCpack.ClientID%>").value = response.d;
                    },
                    failure: function (response) {

                    }
                });

            }
            else {
                document.getElementById("<%=txtCorPacCount.ClientID%>").innerHTML = "";
                document.getElementById("<%=HiddenFieldCpack.ClientID%>").value = "";
            }
            return false;
        }


        function LicPackCount() {

            var LicPacId = document.getElementById("<%=ddlOrgLicPac.ClientID%>").value;
            var $coo = jQuery.noConflict();
            if (LicPacId != "--Choose Your License Pack--") {

                $coo.ajax({
                    type: "POST",
                    url: "Gen_Orgnization.aspx/changeLiscencePack",
                    data: '{LicPacId:"' + LicPacId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        document.getElementById("<%=txtLicPacCount.ClientID%>").innerHTML = "Count<i class=\"fa fa-hashtag\"></i>: " + response.d;
                        document.getElementById("<%=HiddenFieldLpack.ClientID%>").value = response.d;
                    },
                    failure: function (response) {

                    }
                });
            }
            else {
                document.getElementById("<%=txtLicPacCount.ClientID%>").innerHTML = "";
                document.getElementById("<%=HiddenFieldLpack.ClientID%>").value = "";
            }
            return false;
        }   
        function selectorToAutocompleteState(ev) {
            var $au = jQuery.noConflict();
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var countryID = document.getElementById("cphMain_ddlOrgCountry").value;
            if (countryID != "--Select Country--" && countryID != "" && corptID != '' && corptID != null && (!isNaN(corptID)) && orgID != '' && orgID != null && (!isNaN(orgID))) {
                $au("#cphMain_ddlOrgState").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "Gen_Orgnization.aspx/changeState",
                            async: false,
                            data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'orgID': '" + parseInt(orgID) + "', 'corptID': '" + parseInt(corptID) + "', 'countryID': '" + parseInt(countryID) + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        val: item.split('<,>')[0],
                                        label: item.split('<,>')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                            },
                            failure: function (response) {
                            }
                        });
                    },
                    autoFocus: false,
                    select: function (e, i) {
                        document.getElementById("<%=HiddenFieldState.ClientID%>").value = i.item.val;
                        document.getElementById("cphMain_ddlOrgState").value = i.item.label;
                    },
                    change: function (event, ui) {
                        if (ui.item) {
                        }
                        else {
                            document.getElementById("cphMain_ddlOrgState").value = "";
                            document.getElementById("<%=HiddenFieldState.ClientID%>").value = "";
                        }
                    }
                });
            }
        }
        function selectorToAutocompleteCity(ev) {
            var $au = jQuery.noConflict();
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var stateID = document.getElementById("<%=HiddenFieldState.ClientID%>").value;
            if (stateID != "" && corptID != '' && corptID != null && (!isNaN(corptID)) && orgID != '' && orgID != null && (!isNaN(orgID))) {
                $au("#cphMain_ddlOrgCity").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "Gen_Orgnization.aspx/changeCity",
                            async: false,
                            data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'orgID': '" + parseInt(orgID) + "', 'corptID': '" + parseInt(corptID) + "', 'stateID': '" + parseInt(stateID) + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        val: item.split('<,>')[0],
                                        label: item.split('<,>')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                            },
                            failure: function (response) {
                            }
                        });
                    },
                    autoFocus: false,
                    select: function (e, i) {
                        document.getElementById("cphMain_ddlOrgCity").value = i.item.label;
                        document.getElementById("<%=HiddenFieldCity.ClientID%>").value = i.item.val;
                    },
                    change: function (event, ui) {
                        if (ui.item) {

                        }
                        else {
                            document.getElementById("cphMain_ddlOrgCity").value = "";
                            document.getElementById("<%=HiddenFieldCity.ClientID%>").value = "";
                        }
                    }
                });
            }
        }
        function changeCountry() {
            document.getElementById("cphMain_ddlOrgState").value = "";
            document.getElementById("<%=HiddenFieldState.ClientID%>").value = "";
            document.getElementById("cphMain_ddlOrgCity").value = "";
            document.getElementById("<%=HiddenFieldCity.ClientID%>").value = "";
            IncrmntConfrmCounter();
        }
        function changeState() {
            document.getElementById("cphMain_ddlOrgCity").value = "";
            document.getElementById("<%=HiddenFieldCity.ClientID%>").value = "";
            if (document.getElementById("<%=HiddenFieldState.ClientID%>").value == "") {
                document.getElementById("cphMain_ddlOrgState").value = "";
            }
            IncrmntConfrmCounter();
        }
        function changeCity() {
            if (document.getElementById("<%=HiddenFieldCity.ClientID%>").value == "") {
                document.getElementById("cphMain_ddlOrgCity").value = "";
            }
            IncrmntConfrmCounter();
        }
        function ValidateCaptcha() {

            document.getElementById('txtCaptcha').style.borderColor = "";
            document.getElementById('lblcaptcha').style.display = "none";
            var Captcha = document.getElementById('txtCaptcha').value;
            var CaptchaHidden = document.getElementById("<%=hiddenCaptcha.ClientID%>").value;
            if (Captcha == "") {
                document.getElementById('txtCaptcha').style.borderColor = "Red";
                document.getElementById('lblcaptcha').textContent = "Captcha required ";
                document.getElementById('lblcaptcha').style.display = "";
                return false;
            }
            else {
                if (Captcha != CaptchaHidden) {
                    document.getElementById('txtCaptcha').style.borderColor = "Red";
                    document.getElementById('lblcaptcha').textContent = " Captcha mismatch";
                    document.getElementById('lblcaptcha').style.display = "";
                    document.getElementById('txtCaptcha').focus();
                    return false;
                }

            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:HiddenField ID="hiddenlblOnCloudOrNot" runat="server" />
            <asp:HiddenField ID="HiddenField2_FileUpload" runat="server" Value="0" />
            <asp:HiddenField ID="hiddenFileCR_Attach" runat="server" Value="0" />
            <asp:HiddenField ID="hiddenFileTX_Attach" runat="server" Value="0" />
            <asp:HiddenField ID="hiddenFileCOMP_Attach" runat="server" Value="0" />
            <asp:HiddenField ID="HiddenFilePath" runat="server" Value="0" />
            <asp:HiddenField ID="hiddenIsPrmtRenwed" runat="server" />
            <asp:HiddenField ID="HiddenDlet_FileUpload" runat="server" />
            <asp:HiddenField ID="HiddenFieldAddTable" runat="server" />
            <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
            <asp:HiddenField ID="hiddenEdit" runat="server" />
            <asp:HiddenField ID="HiddenField3" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="hiddenNation" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:HiddenField ID="hiddenDelt_Partner" runat="server" />
            <asp:HiddenField ID="hiddenPartner" runat="server" />
            <asp:HiddenField ID="HiddenStateValue" runat="server" />
            <asp:HiddenField ID="hiddenOrgName" runat="server" />
            <asp:HiddenField ID="hiddenLic" runat="server" />
            <asp:HiddenField ID="hiddenCorp" runat="server" />
            <asp:HiddenField ID="HiddenCityValue" runat="server" />
            <asp:HiddenField ID="totelShare" runat="server" />
            <asp:HiddenField ID="HiddenFocus" runat="server" />
          
     <asp:HiddenField ID="HiddenFieldLpack" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldCpack" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldState" runat="server" />
     <asp:HiddenField ID="HiddenFieldCity" runat="server" />
     <asp:HiddenField ID="hiddenCaptcha" runat="server" />
          <ol class="breadcrumb">
       <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
        <li id="lblEntryB" runat="server" class="active">Edit Organization</li>
      </ol>
   <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div> 

     
    <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">     
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2>Edit Organization</h2>
        <div class="form-group fg2 sa_fg4" id="divLpack">
          <label for="email" class="fg2_la1">License Pack:<span class="spn1">*</span>
            <span class="input-group-addon cur2 sp_c scnt" id="txtLicPacCount" runat="server"></span>
          </label>
         <asp:DropDownList ID="ddlOrgLicPac" class="form-control fg2_inp1 inp_mst" runat="server" onChange="return LicPackCount();"></asp:DropDownList>
         <p class="error" id="ErrorMsgOrgLicPac" style="display:none;">Please select license pack</p>
        </div>
        <div class="form-group fg2 sa_fg4" id="divCpack">
          <label for="email" class="fg2_la1">Corporate Pack:<span class="spn1">*</span>
            <span class="input-group-addon cur2 sp_c scnt1"  id="txtCorPacCount" runat="server" ></span>
          </label>
         <asp:DropDownList ID="ddlOrgCorPac" class="form-control fg2_inp1 inp_mst" runat="server" onChange="return CorpPackCount();"></asp:DropDownList>
         <p id="ErrorMsgOrgCorPac" class="error" style="display:none;">Please fill this out</p>
        </div>

        <div class="form-group fg2 sa_fg4" id="divOtype">
          <label for="email" class="fg2_la1">Organization Type:<span class="spn1">*</span></label>
            <asp:DropDownList ID="ddlOrgType" class="form-control fg2_inp1 inp_mst" runat="server"></asp:DropDownList>
            <p class="error" id="ErrorMsgOrgType" style="display:none;">Please select</p>
        </div>
        <div class="form-group fg2 sa_fg4">
          <label for="email" class="fg2_la1">Organization Name:<span class="spn1">*</span></label>
             <asp:TextBox ID="txtOrgName" class="form-control fg2_inp1 inp_mst" placeholder="Organization Name" runat="server" MaxLength="100" Style="text-transform: uppercase" onblur="RemoveTag(this)"></asp:TextBox>
             <p class="error" id="ErrorMsgOrgName" style="display:none;">Please fill this out</p>
        </div>
        <div class="clearfix"></div>
        <div class="form-group fg2 sa_fg4">
          <label for="email" class="fg2_la1">Address 1:<span class="spn1">*</span></label>
             <asp:TextBox ID="txtOrgAdd1" class="form-control fg2_inp1 inp_mst" placeholder="Address 1" runat="server" MaxLength="150"  Style="text-transform: uppercase" onblur="RemoveTag(this)"></asp:TextBox>
             <p class="error" id="ErrorMsgOrgAdd1" style="display:none;">Please fill this out</p>
        </div>
        <div class="form-group fg2 sa_fg4">
          <label for="email" class="fg2_la1">Address 2:<span class="spn1"></span></label>
             <asp:TextBox ID="txtOrgAdd2" class="form-control fg2_inp1" placeholder="Address 2" runat="server" MaxLength="150"  Style="text-transform: uppercase" onblur="RemoveTag(this)"></asp:TextBox>
             <p class="error" id="ErrorMsgOrgAdd2" style="display:none;">Please fill this out</p>
       
        </div>
        <div class="form-group fg2 sa_fg4">
          <label for="email" class="fg2_la1">Address 3:<span class="spn1"></span></label>
             <asp:TextBox ID="txtOrgAdd3" class="form-control fg2_inp1" placeholder="Address 3" runat="server" MaxLength="150"  Style="text-transform: uppercase" onblur="RemoveTag(this)"></asp:TextBox>
             <p class="error" id="ErrorMsgOrgAdd3" style="display:none;">Please fill this out</p>
        </div>
        <div class="form-group fg2 sa_fg4" id="divCntry">
          <label for="email" class="fg2_la1">Country:<span class="spn1">*</span></label>
            <asp:DropDownList ID="ddlOrgCountry" class="form-control fg2_inp1 inp_mst" runat="server"  onchange="changeCountry();"></asp:DropDownList>
            <p class="error" id="ErrorMsgOrgCountry" style="display:none;">Please select</p>
        </div>
        <div class="form-group fg2 sa_fg4">
          <label for="email" class="fg2_la1">State:<span class="spn1"></span></label>
             <asp:TextBox ID="ddlOrgState"  onchange="changeState();" class="form-control fg2_inp1 inp_mst"  placeholder="--Select State--"   runat="server"  onkeypress="return selectorToAutocompleteState(event);" onkeydown="return selectorToAutocompleteState(event);"></asp:TextBox>
            <p class="error" id="ErrorMsgOrgState" style="display:none;">Please fill this out</p>
        </div>
        <div class="form-group fg2 sa_fg4">
          <label for="email" class="fg2_la1">City:<span class="spn1"></span></label>
             <asp:TextBox ID="ddlOrgCity"  onchange="changeCity();" class="form-control fg2_inp1 inp_mst"  placeholder="--Select City--"   runat="server"  onkeypress="return selectorToAutocompleteCity(event);" onkeydown="return selectorToAutocompleteCity(event);"></asp:TextBox>
            <p class="error" id="ErrorMsgOrgCity" style="display:none;">Please fill this out</p>
        </div>
        <div class="form-group fg2 sa_fg4">
          <label for="email" class="fg2_la1">Postal Code:<span class="spn1"></span></label>
            <asp:TextBox ID="txtOrgZip" class="form-control fg2_inp1" placeholder="Postal Code" runat="server" MaxLength="10" Style="text-transform: uppercase" onblur="RemoveTag(this)"></asp:TextBox>
             <p class="error" id="ErrorMsgOrgZip" style="display:none;">Please fill this out</p>
        </div>
        <div class="form-group fg2 sa_fg4">
          <label for="email" class="fg2_la1">Phone#:<span class="spn1"></span></label>
            <asp:TextBox ID="txtOrgPhone" class="form-control fg2_inp1" placeholder="Phone#" runat="server" MaxLength="50"  Style="text-transform: uppercase"></asp:TextBox>
            <p class="error" id="ErrorMsgOrgPhone" style="display:none;">Please fill this out</p>
        </div>
        <div class="form-group fg2 sa_fg4">
          <label for="email" class="fg2_la1">Mobile#:<span class="spn1">*</span></label>
             <asp:TextBox ID="txtOrgMobile" class="form-control fg2_inp1 inp_mst" placeholder="Mobile#" runat="server" MaxLength="50"  onPaste="return false" Style="text-transform: uppercase"></asp:TextBox>
             <p class="error" id="ErrorMsgOrgMobile" style="display:none;">Please enter valid mobile number</p>
        </div>
        <div class="form-group fg2 sa_fg4">
          <label for="email" class="fg2_la1">Website:<span class="spn1"></span></label>
              <asp:TextBox ID="txtOrgWebsite" class="form-control fg2_inp1" placeholder="Website" runat="server" MaxLength="100"  onblur="RemoveTag(this)"></asp:TextBox>
              <p class="error" id="ErrorMsgOrgWebsite" style="display:none;">Please enter valid website</p>
        </div>

        <div class="clearfix"></div>
        <div class="free_sp"></div>
        <div class="devider"></div>

        <a href="#" class="bt_i bt_info1"> 
          <h3 style="width:30%;margin-bottom: 16px;"> <i class="fa fa-unlock"></i> <span class="fa fa-file-text sht_ico"></span> Login Information<span class="spn1">*</span> <i class="fa fa-caret-down down_arw1 flt_r sht_ico" id="iLogin"></i> <i class="fa fa-caret-up up_arw1 flt_r sht_ico" style="display: none;"></i></h3></a>
        <div class="add_info1" style="display:block;">
          <div class="form-group fg2 sa_fg4">
            <label for="email" class="fg2_la1">Email:<span class="spn1">*</span></label>
             <asp:TextBox ID="txtOrgEmail" class="form-control fg2_inp1 inp_mst" placeholder="Email" runat="server" MaxLength="100" onblur="RemoveTag(this)"></asp:TextBox>
             <p class="error" id="ErrorMsgOrgEmail" style="display:none;">Please enter valid email address</p>
          </div>
          <div class="form-group fg2 sa_fg4">
            <label for="email" class="fg2_la1">Current Password:<span class="spn1">*</span></label>
               <asp:TextBox ID="txtOrgPwd" class="form-control fg2_inp1 inp_mst" placeholder="Current Password" onPaste="return false" runat="server" MaxLength="16"  TextMode="Password" onblur="RemoveTag(this)"></asp:TextBox>
                          
                                <div class='form-tooltip'>Password Must Contain 6-16 Characters with atleast one number, special character & alphabet</div>
                                
                                  <p class="error" id="PwdMsg" style="display:none;"></p>
          </div>
          <div class="form-group fg2 sa_fg4">
            <label for="email" class="fg2_la1">New Password:<span class="spn1">*</span></label>
               <asp:TextBox ID="txtOrgNewPwd" class="form-control fg2_inp1 inp_mst" placeholder="New Password" onPaste="return false" runat="server" MaxLength="16" TextMode="Password" onblur="RemoveTag(this)"></asp:TextBox>

                                <div class='form-tooltip'>Password Must Contain 6-16 Characters with atleast one number, special character & alphabet</div>
                                <p class="error" id="ErrorMsgOrgNewPwd" style=" display:none;">Password does not match</p>
          </div>
          <div class="form-group fg2 sa_fg4">
            <label for="email" class="fg2_la1">Confirm Password:<span class="spn1">*</span></label>
               <asp:TextBox ID="txtOrgConPwd" class="form-control fg2_inp1 inp_mst" placeholder="Confirm Password" onPaste="return false" runat="server" MaxLength="16"  onblur="RemoveTag(this)"></asp:TextBox>

                                <div class='form-tooltip'>Password Must Contain 6-16 Characters with atleast one number, special character & alphabet</div>
 <p class="error" id="ErrorMsgOrgConPwd" style="display:none;">Password does not match</p>
          </div>
          <div class="form-group fg2 sa_fg4">
            <label for="email" class="fg2_la1">Show Password:<span class="spn1">*</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                  <input type="checkbox" id="cbxPswdVisible" runat="server" onchange="return onChange();">
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>
          <div class="fg6" style="margin-top:1%;"> 
            <div class="form-group">
                <%-- <label for="email" class="fg2_la1">&nbsp</label>--%>
              <div class="fg4">
                <input class="form-control d-none" id="txtCaptcha" type="text" placeholder="Captcha Code" onchange="ValidateCaptcha();">
                   <p class="error" id="lblcaptcha" style=" display:none;"></p>
                  
              </div>
              <asp:Image ID="imgCaptcha" runat="server"   Style="width: 25%; height: 34px;margin-left:1%;" />
            </div>
          </div>
          <div class="clearfix"></div>
          <div class="free_sp"></div>
            </div>
        <div class="devider"></div>

        <a href="#" class="bt_i bt_info2"> 
          <h3 style="width:30%;margin-bottom: 16px;">
            <i class="fa fa-balance-scale"></i><span class="fa fa-file-text-o sht_ico"></span> Commercial Registration<span class="spn1">*</span> <i class="fa fa-caret-down down_arw2 flt_r sht_ico"></i> <i class="fa fa-caret-up up_arw2 flt_r sht_ico" style="display: none;"></i>
          </h3>
        </a>
        <div class="add_info2" style="display:none;">

          <div class="form-group fg2 sa_fg4">
            <label for="email" class="fg2_la1">Commercial Registration#:<span class="spn1">*</span></label>
                <asp:TextBox ID="txtCrNumber" runat="server" class="form-control fg2_inp1 inp_mst" placeholder="Commercial Registration#" onblur="RemoveTag(this);" MaxLength="16" ></asp:TextBox>
          </div>
          <div class="form-group fg2 sa_fg4">
            <label for="pwd" class="fg2_la1">Issue Date:<span class="spn1">*</span> </label>
              <div id="IssueDate" class="input-group date" data-date-format="mm-dd-yyyy">
                <input class="form-control inp_bdr inp_mst" type="text" id="txtIssueCrDate"  placeholder="DD-MM-YYYY" maxlength="20" runat="server" />
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                  <script>

                      $noCon('#cphMain_txtIssueCrDate').datepicker({
                          autoclose: true,
                          format: 'dd-mm-yyyy',
                          timepicker: false,
                          endDate: new Date(),
                      });
                            </script>

              </div>
          </div>
          <div class="form-group fg2 sa_fg4">
            <label for="pwd" class="fg2_la1">Expiry Date:<span class="spn1">*</span> </label>
            <div id="ClosingDate" class="input-group date" data-date-format="mm-dd-yyyy">
                <input class="form-control inp_bdr inp_mst" type="text" id="txtExpCrDate"  placeholder="DD-MM-YYYY" maxlength="20" runat="server" />
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                  <script>

                      $noCon('#cphMain_txtExpCrDate').datepicker({
                          autoclose: true,
                          format: 'dd-mm-yyyy',
                          timepicker: false,
                         
                      });
                            </script>

              </div>
          </div>

          <div class="clearfix"></div>

          <div class="r_1024 tbl_fx_hi">
            <table class="display table-bordered pro_tab1 tbl_800" cellspacing="0" width="100%">
              <thead class="thead1">
                <tr>
                  <th class="col-md-5 tr_l">Attachments</th>
                  <th class="col-md-5 tr_l">Description</th>
                  <th class="col-md-2">Actions</th>
                  </tr>
              </thead>
              <tbody id="TableFileUploadCrAttachment">
              </tbody>
            </table>
          </div>
          <div class="clearfix"></div>
          <div class="free_sp"></div>
        </div>
        <div class="devider"></div>



        <a href="#" class="bt_i bt_info3"> 
          <h3 style="width:30%;margin-bottom: 16px;"> <i class="fa fa-handshake-o"></i> <span class="fa fa-users sht_ico"></span> Partners<span class="spn1">*</span> <i class="fa fa-caret-down down_arw3 flt_r sht_ico"></i> <i class="fa fa-caret-up up_arw3 flt_r sht_ico" style="display: none;"></i></h3></a>
        <div class="add_info3" style="display:none;">
          <div class="r_1024 tbl_fx_hi">
            <table class="display table-bordered pro_tab1 tbl_800" cellspacing="0" width="100%">
              <thead class="thead1">
                <tr>
                  <th class="th_b11 tr_l">Name</th>
                  <th class="th_b13 tr_l">Document#</th>
                  <th class="th_b2 tr_l">CR#</th>
                  <th class="th_b11 tr_l">Nationality</th>
                  <th class="th_b4 tr_c">Percentage%</th>
                  <th class="col-md-1">Status</th>
                  <th class="col-md-2">Actions</th>
                </tr>
              </thead>
              <tbody id="TableaddedRows">           
              </tbody>
            </table>
          </div>
          <div class="clearfix"></div>
          <div class="free_sp"></div>
        </div>
        <div class="devider"></div>

        <a href="#" class="bt_i bt_info4"> 
          <h3 style="width:30%;margin-bottom: 16px;">
                <i class="fa fa-calculator"></i><span class="fa fa-credit-card-alt sht_ico"></span> Tax Card<span class="spn1">*</span> <i class="fa fa-caret-down down_arw4 flt_r sht_ico"></i> <i class="fa fa-caret-up up_arw4 flt_r sht_ico" style="display: none;"></i></h3></a>
        <div class="add_info4" style="display:none;">
          <div class="form-group fg2 sa_fg4">
            <label for="email" class="fg2_la1">Tax Identification#:<span class="spn1">*</span></label>
               <asp:TextBox ID="txtTiNumber" runat="server"  MaxLength="16" class="form-control fg2_inp1 inp_mst" placeholder="Tax Identification#"></asp:TextBox>
          </div>
          <div class="form-group fg2 sa_fg4">
            <label for="pwd" class="fg2_la1">Issue Date:<span class="spn1">*</span> </label>
            <div id="IssueDate1" class="input-group date" data-date-format="mm-dd-yyyy">
                <input class="form-control inp_bdr inp_mst" type="text" id="txtIssueTxDate"  placeholder="DD-MM-YYYY" maxlength="20" runat="server" />
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                  <script>

                      $noCon('#cphMain_txtIssueTxDate').datepicker({
                          autoclose: true,
                          format: 'dd-mm-yyyy',
                          timepicker: false,
                          endDate: new Date(),
                      });
                            </script>

              </div>
          </div>
          <div class="form-group fg2 sa_fg4">
            <label for="pwd" class="fg2_la1">Expiry Date:<span class="spn1">*</span> </label>
            <div id="ClosingDate1" class="input-group date" data-date-format="mm-dd-yyyy">
                <input class="form-control inp_bdr inp_mst" type="text" id="txtExpTxDate"  placeholder="DD-MM-YYYY" maxlength="20" runat="server" />
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                  <script>

                      $noCon('#cphMain_txtExpTxDate').datepicker({
                          autoclose: true,
                          format: 'dd-mm-yyyy',
                          timepicker: false,
                      });
                            </script>

              </div>
          </div>

          <div class="r_1024 tbl_fx_hi">
            <table class="display table-bordered pro_tab1 tbl_800" cellspacing="0" width="100%">
              <thead class="thead1">
                <tr>
                  <th class="col-md-5 tr_l">Attachments</th>
                  <th class="col-md-5 tr_l">Description</th>
                  <th class="col-md-2">Actions</th>
                  </tr>
              </thead>
              <tbody id="TableFileUploadTXAttachment">
              </tbody>
            </table>
          </div>
          <div class="clearfix"></div>
          <div class="free_sp"></div>
        </div>
        <div class="devider"></div>

        <a href="#" class="bt_i bt_info5"> 
          <h3 style="width:30%;margin-bottom: 16px;">
          <i class="fa fa-laptop"></i><span class="fa fa-credit-card-alt sht_ico"></span> Computer Card<span class="spn1">*</span> <i class="fa fa-caret-down down_arw5 flt_r sht_ico"></i> <i class="fa fa-caret-up up_arw5 flt_r sht_ico" style="display: none;"></i></h3></a>
        <div class="add_info5" style="display:none;">

        <div class="form-group fg2 sa_fg4">
          <label for="email" class="fg2_la1">Computer Card#:<span class="spn1">*</span></label>
             <asp:TextBox ID="txtCompNo" runat="server"  MaxLength="16" class="form-control fg2_inp1 inp_mst" placeholder="Computer Card#"></asp:TextBox>
        </div>
        <div class="form-group fg2 sa_fg4">
          <label for="pwd" class="fg2_la1">Issue Date:<span class="spn1">*</span> </label>
         <div id="IssueDate2" class="input-group date" data-date-format="mm-dd-yyyy">
                <input class="form-control inp_bdr inp_mst" type="text" id="txtIssueCompDate"  placeholder="DD-MM-YYYY" maxlength="20" runat="server" />
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                  <script>

                      $noCon('#cphMain_txtIssueCompDate').datepicker({
                          autoclose: true,
                          format: 'dd-mm-yyyy',
                          timepicker: false,
                          endDate: new Date(),
                      });
                            </script>

              </div>
        </div>
        <div class="form-group fg2 sa_fg4">
          <label for="pwd" class="fg2_la1">Expiry Date:<span class="spn1">*</span> </label>
          <div id="ClosingDate2" class="input-group date" data-date-format="mm-dd-yyyy">
                <input class="form-control inp_bdr inp_mst" type="text" id="txtExpCompDate"  placeholder="DD-MM-YYYY" maxlength="20" runat="server" />
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                  <script>

                      $noCon('#cphMain_txtExpCompDate').datepicker({
                          autoclose: true,
                          format: 'dd-mm-yyyy',
                          timepicker: false,
                      });
                            </script>

              </div>
        </div>

        <div class="r_1024 tbl_fx_hi">
          <table class="display table-bordered pro_tab1 tbl_800" cellspacing="0" width="100%">
            <thead class="thead1">
              <tr>
                <th class="col-md-5 tr_l">Attachments</th>
                <th class="col-md-5 tr_l">Description</th>
                <th class="col-md-2">Actions</th>
                </tr>
            </thead>
            <tbody id="TableFileUploadCompCardAttachment">
            </tbody>
          </table>
        </div>
          <div class="clearfix"></div>
          <div class="free_sp"></div>
        </div>
        <div class="devider"></div>
        <div class="sub_cont pull-right">
          <div class="save_sec">
               <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Update" OnClick="btnAddUp_Click" OnClientClick="return OrgParkingNullValidation();" />
                        <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel"  OnClientClick="return ConfirmMessage();" />

          </div>
        </div>

        </div>
       </div>
</div>

 <div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">
       <asp:Button ID="btnAddF" runat="server" class="btn sub1 bt_b" Text="Update" OnClick="btnAddUp_Click" OnClientClick="return OrgParkingNullValidation();" />
                        <asp:Button ID="btnCancelF" runat="server" class="btn sub4 bt_b" Text="Cancel"  OnClientClick="return ConfirmMessage();" />
     
        </div>
              </div>
    <a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
<i class="fa fa-save"></i>
</a>
<a href="#" id="scroll" style="display: none;"><span class="fa fa-angle-up"></span></a>
<script>
    function opensave() {
        document.getElementById("cphMain_mySave").style.width = "140px";
    }

    function closesave() {
        document.getElementById("cphMain_mySave").style.width = "0px";
    }
</script>
    <style>
        .error {
              
               color: red;
               font-size: small;
                font-family: Calibri;
                width: 95%;
           }  
         .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            width: 218px;
            border: 1px solid #B0BECA;
            max-height: 140px;
            overflow-x: auto;
            font-family: Calibri;
        }

            .ui-autocomplete .ui-menu-item {
                border-top: 1px solid #B0BECA;
                display: block;
                padding: 4px 6px;
                color: #353D44;
                cursor: pointer;
                font-family: Calibri;
            }

                .ui-autocomplete .ui-menu-item:first-child {
                    border-top: none;
                    font-family: Calibri;
                }

                .ui-autocomplete .ui-menu-item.ui-state-focus {
                    background-color: #D5E5F4;
                    color: #161A1C;
                    font-family: Calibri;
                }
                .form-tooltip {
            display: table-cell;
            visibility: hidden;
            position: absolute;
            box-sizing: content-box;
            height: 0;
            /*margin-left: 17%;*/
            margin-top: 4%;
            /*margin-bottom: -8px;*/
            cursor: help;
            width: 254px;
            word-break: break-all;
            word-wrap: break-word;
            padding: 4px 5px;
            background: #bbb;
            color: #fff;
            font-weight: 600;
            font-size: 12px;
            /*line-height: 16px;*/
            font-family: Calibri;
        }

        :focus + .form-tooltip {
            margin-bottom: 0;
            height: auto;
            visibility: visible;
        }
    </style>
    <script>
        $(document).ready(function () {
            $(".bt_info1").click(function () {
                $(".add_info1").toggle(200);
                $(".up_arw1").toggle(200);
                $(".down_arw1").toggle(200);
                $(".add_info2, .add_info3, .add_info4, .add_info5").hide(200);

            });
        });
        $(document).ready(function () {
            $(".bt_info2").click(function () {
                $(".add_info2").toggle(200);
                $(".up_arw2").toggle(200);
                $(".down_arw2").toggle(200);
                $(".add_info1, .add_info3, .add_info4, .add_info5").hide(200);
            });
        });
        $(document).ready(function () {
            $(".bt_info3").click(function () {
                $(".add_info3").toggle(200);
                $(".up_arw3").toggle(200);
                $(".down_arw3").toggle(200);
                $(".add_info1, .add_info2, .add_info4, .add_info5").hide(200);
            });
        });
        $(document).ready(function () {
            $(".bt_info4").click(function () {
                $(".add_info4").toggle(200);
                $(".up_arw4").toggle(200);
                $(".down_arw4").toggle(200);
                $(".add_info1, .add_info3, .add_info2, .add_info5").hide(200);
            });
        });
        $(document).ready(function () {
            $(".bt_info5").click(function () {
                $(".add_info5").toggle(200);
                $(".up_arw5").toggle(200);
                $(".down_arw5").toggle(200);
                $(".add_info1, .add_info3, .add_info4, .add_info2").hide(200);
            });
        });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        $(".cont_contr").scroll(function () {
            if ($(this).scrollTop() > 100) {
                $('#scroll').fadeIn();
            } else {
                $('#scroll').fadeOut();
            }
        });
        $('#scroll').click(function () {
            $(".cont_contr").animate({ scrollTop: 0 }, 600);
            return false;
        });
    });
</script>
</asp:Content>

