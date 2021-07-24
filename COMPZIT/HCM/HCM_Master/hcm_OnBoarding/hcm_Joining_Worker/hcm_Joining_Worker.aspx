<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Joining_Worker.aspx.cs" Inherits="HCM_HCM_Master_hcm_OnBoarding_hcm_Joining_Worker_hcm_JoiningWorker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style>
        .div-Contact-details {
            padding: 1% 2% 3% 2%;
            min-height: 104px;
            border: .5px solid;
            border-color: #9ba48b;
            background-color: #f3f3f3;
            width: 100%;
            margin-top: 0%;
        }

        .eachform {
            width: 100%;
            display: inline-block;
            margin: 0 0 6px;
        }

        .error {
            padding-top: 7%;
            padding-left: 29%;
            color: red;
            font-size: small;
            margin-left: 8%;
            font-family: Calibri;
        }
    </style>
    <style>
        .divbutton {
            display: inline-block;
            color: #0C7784;
            border: 1px solid #999;
            background: #CBCBCB;
            /*box-shadow: 0 0 5px -1px rgba(0,0,0,0.2);*/
            cursor: pointer;
            vertical-align: middle;
            width: 15.36%;
            padding: 5px;
            text-align: center;
            font-family: calibri;
        }

            .divbutton:active {
                color: red;
                box-shadow: 0 0 5px -1px rgba(0,0,0,0.6);
            }

        input[type="file"] {
            position: relative;
            z-index: 1;
            margin-left: -78px;
            display: none;
        }

        .custom-file-upload {
            border: 1px solid #ccc;
            display: inline-block;
            padding: 3px 8px;
            cursor: pointer;
            position: relative;
            z-index: 2;
            background: white;
        }
    </style>
    <style>
        .colmcenter {
            width: 75%;
        }


        a.lightbox img {
            height: 150px;
            border: 3px solid white;
            box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
            margin: 94px 20px 20px 20px;
        }

        /* Styles the lightbox, removes it from sight and adds the fade-in transition */
        .lightbox-target {
            position: fixed;
            top: -100%;
            width: 100%;
            background: rgba(0, 0, 0, 0.7);
            width: 60%;
            opacity: 0;
            -webkit-transition: opacity .5s ease-in-out;
            -moz-transition: opacity .5s ease-in-out;
            -o-transition: opacity .5s ease-in-out;
            transition: opacity .5s ease-in-out;
            overflow: hidden;
        }

            /* Styles the lightbox image, centers it vertically and horizontally, adds the zoom-in transition and makes it responsive using a combination of margin and absolute positioning */
            .lightbox-target img {
                margin: auto;
                position: absolute;
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                max-height: 0%;
                max-width: 0%;
                border: 3px solid white;
                box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
                box-sizing: border-box;
                -webkit-transition: .5s ease-in-out;
                -moz-transition: .5s ease-in-out;
                -o-transition: .5s ease-in-out;
                transition: .5s ease-in-out;
            }

        /* Styles the close link, adds the slide down transition */
        a.lightbox-close {
            display: block;
            width: 50px;
            height: 50px;
            box-sizing: border-box;
            background: white;
            color: black;
            text-decoration: none;
            position: absolute;
            top: -80px;
            right: 0;
            -webkit-transition: .5s ease-in-out;
            -moz-transition: .5s ease-in-out;
            -o-transition: .5s ease-in-out;
            transition: .5s ease-in-out;
        }

            /* Provides part of the "X" to eliminate an image from the close link */
            a.lightbox-close:before {
                content: "";
                display: block;
                height: 30px;
                width: 1px;
                background: black;
                position: absolute;
                left: 26px;
                top: 10px;
                -webkit-transform: rotate(45deg);
                -moz-transform: rotate(45deg);
                -o-transform: rotate(45deg);
                transform: rotate(45deg);
            }

            /* Provides part of the "X" to eliminate an image from the close link */
            a.lightbox-close:after {
                content: "";
                display: block;
                height: 30px;
                width: 1px;
                background: black;
                position: absolute;
                left: 26px;
                top: 10px;
                -webkit-transform: rotate(-45deg);
                -moz-transform: rotate(-45deg);
                -o-transform: rotate(-45deg);
                transform: rotate(-45deg);
            }

        /* Uses the :target pseudo-class to perform the animations upon clicking the .lightbox-target anchor */
        .lightbox-target:target {
            opacity: 1;
            top: 0;
            bottom: 0;
            right: 18%;
            z-index: 103;
        }

            .lightbox-target:target img {
                max-height: 100%;
                max-width: 80%;
            }

            .lightbox-target:target a.lightbox-close {
                top: 0px;
            }

        .form-group p {
            color: red;
            margin-top: 1%;
            margin-left: 40%;
        }



        #cphMain_mydiv {
            background: #C2DFEF;
            text-align: left;
            overflow: auto;
            margin-left: 14.5%;
            max-height: 220px;
            margin-top: -2%;
        }


        .form2 label {
            padding-left: 1.5%;
        }

        #cphMain_divImageDisplay a {
            color: rgb(40, 111, 150);
        }

            #cphMain_divImageDisplay a:hover {
                color: rgb(52, 165, 239);
            }

        .imgDescription {
            position: absolute;
            /*top: 511px;
            left: 6.5%;*/
            background: rgb(154, 163, 138);
            visibility: hidden;
            opacity: 0;
            padding: 0.1%;
            font-family: Calibri;
            /*remove comment if you want a gradual transition between states
  -webkit-transition: visibility opacity 0.2s;
  */
        }

        .imgWrap:hover .imgDescription {
            visibility: visible;
            opacity: 1;
        }

        #cphMain_mydiv td {
            border-right: 0px;
        }

        #cphMain_cbxlCorporateOffc {
            width: 100%;
        }

        #goofy {
            right: 17%;
            top: 51px;
            width: 60%;
        }

        .open > .dropdown-menu {
            display: none;
        }

        .eachform h2 {
            margin: 6px 0 6px;
        }


        #divCalculator {
            width: 90%;
            height: 200px;
            border: 2px ridge;
            background-image: url("/Images/Icons/calciBaground4.jpg");
            /*background-color: #f8f8f8;*/
            border-color: #d7d7d7;
            visibility: hidden;
            margin-left: 10%;
        }


        #divCalciHead {
            display: inline-block;
            text-align: center;
            height: 30px;
            width: 99%;
            background-image: url("/Images/Icons/calci_head.png");
            /*background-color: #8cd8d0;*/
            border: 2px ridge;
            /*border-style: inset;*/
            border-color: #dad8d5;
        }

        #cphMain_lblCalciAmnt {
            display: inline-block;
            text-align: right;
            height: 30px;
            width: 93%;
            font-family: calibri;
            font-size: 20px;
            color: #4A4A4A;
            float: right;
            margin-right: 2%;
            background-color: white;
            border: 1px solid;
            border-color: #9e9c9c;
            padding-right: 7px;
        }
    </style>
    <script src="/JavaScript/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">


        var FileCounterPer = 0;

        function AddFileUploadPer() {

            var FrecRow = '<tr id="FilerowId_' + FileCounterPer + '" >';
            var labelForStyle = '<label tabindex="0"  for="file' + FileCounterPer + '" class="custom-file-upload" style="margin-left: 0%;font-family: Calibri;"> <img src="/Images/Icons/cloud_upload.jpg"></img>Upload Document</label>';
            var tdInner = labelForStyle + '<input   id="file' + FileCounterPer + '" name = "file' + FileCounterPer +

                           '" type="file" onchange="ChangeFilePer(' + FileCounterPer + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/>';

            FrecRow += '<td  style="width: 34%;" >' + tdInner + '</td>';

            FrecRow += '<td  style="word-break: break-all;font-family: Calibri;" id="filePath' + FileCounterPer + '"  ></td  >';
            FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterPer + '"  style="width: 1.5%; padding-left: 4px;"> <input type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" title="Add" onclick="return CheckaddMoreRowsIndividualFilesPer(' + FileCounterPer + ');" style="  cursor: pointer;"></td>';
            FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" id="FieldId' + FileCounterPer + '" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete" title="Delete" onclick = "return RemoveFileUploadPer(' + FileCounterPer + ');"    style=" cursor: pointer;" ></td>';

            FrecRow += ' <td id="FileInx' + FileCounterPer + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + FileCounterPer + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + FileCounterPer + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId' + FileCounterPer + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName' + FileCounterPer + '" style="display: none;"></td>';
            FrecRow += '</tr>';
            jQuery('#TableFileUploadContainerPermit').append(FrecRow);



            document.getElementById('filePath' + FileCounterPer).innerHTML = 'No File Uploaded';

            FileCounterPer++;

        }
        function EditAttachmentPer(editTransDtlId, EditFileName, EditActualFileName) {

            var FrecRow = '<tr id="FilerowId_' + FileCounterPer + '" >';


            var labelForStyle = '<label for="file' + FileCounterPer + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
            var tdInner = labelForStyle + '<input   id="file' + FileCounterPer + '" name = "file' + FileCounterPer +

                           '" type="file" onchange="ChangeFilePer(' + FileCounterPer + ')" />';

            FrecRow += '<td style="width: 25%; display:none;" >' + tdInner + '</td>';

            var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

            FrecRow += '<td colspan="2"  id="filePath' + FileCounterPer + '" style="border-bottom: 1px dotted rgb(205, 237, 196); font-family:calibri;"' + '  >' + tdFileNameEdit + '</td  >';



            FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterPer + '"  style="width: 1.5%; padding-left: 4px;"> <input type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesPer(' + FileCounterPer + ');" style="  cursor: pointer;"></td>';
            FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadPer(' + FileCounterPer + ');"    style=" cursor: pointer;" ></td>';


            FrecRow += ' <td id="FileInx' + FileCounterPer + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + FileCounterPer + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + FileCounterPer + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId' + FileCounterPer + '" style="display: none;">' + editTransDtlId + '</td>';
            FrecRow += '<td id="DbFileName' + FileCounterPer + '" style="display: none;">' + EditFileName + '</td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadContainerPermit').append(FrecRow);
            document.getElementById("FileInx" + FileCounterPer).innerHTML = FileCounterPer;
            document.getElementById("FileIndvlAddMoreRow" + FileCounterPer).style.opacity = "0.3";
            // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
            FileLocalStorageAddPer(FileCounterPer);
            FileCounterPer++;

        }
        function RemoveFileUploadPer(removeNum) {
            if (confirm("Are you sure you want to delete selected file?")) {

                var Filerow_index = jQuery('#FilerowId_' + removeNum).index();

                FileLocalStorageDeletePer(Filerow_index, removeNum);
                jQuery('#FilerowId_' + removeNum).remove();




                // alert(Filerow_index);
                var $noC = jQuery.noConflict();
                var TableFileRowCount = document.getElementById("TableFileUploadContainerPermit").rows.length;

                if (TableFileRowCount != 0) {
                    var idlast = $noC('#TableFileUploadContainerPermit tr:last').attr('id');
                    //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                    //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                    if (idlast != "") {
                        var res = idlast.split("_");
                        //  alert(res[1]);
                        document.getElementById("FileInx" + res[1]).innerHTML = " ";
                        document.getElementById("FileIndvlAddMoreRow" + res[1]).style.opacity = "1";
                    }
                }
                else {
                    AddFileUploadPer();


                }




            }
            else {

                return false;
            }
        }
        function CheckaddMoreRowsIndividualFilesPer(x) {
            var check = document.getElementById("FileInx" + x).innerHTML;

            if (check == " ") {

                var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                if (Fevt != 'UPD') {
                    if (CheckFileUploaded(x) == true) {
                        document.getElementById("FileInx" + x).innerHTML = x;
                        document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                        AddFileUploadPer();
                        return false;
                    }
                }
                else {
                    document.getElementById("FileInx" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                    AddFileUploadPer();
                    return false;
                }
            }
            return false;
        }
        function ChangeFilePer(x) {
            if (ClearDivDisplayImage1(x)) {
                IncrmntConfrmCounter();
                if (document.getElementById('file' + x).value != "") {
                    document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;

                }
                else {
                    document.getElementById('filePath' + x).innerHTML = 'No File Uploaded';


                }
                var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                //   alert('hi SavedorNot' + SavedorNot);
                if (SavedorNot == "saved") {
                    var row_index = jQuery('#FilerowId_' + x).index();
                    FileLocalStorageEditPer(x, row_index);
                }
                else {
                    FileLocalStorageAddPer(x);
                }
            }
        }
        function ClearDivDisplayImage1(x) {

            var fuData = document.getElementById('file' + x);
            var FileUploadPath = fuData.value;
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();



            if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                        || Extension == "jpeg" || Extension == "jpg" || Extension == "xlsx" || Extension == "xls" || Extension == "doc" ||
                Extension == "docx" || Extension == "csv" || Extension == "ppt" || Extension == "pptx"
               || Extension == "txt" || Extension == "pdf") {


                return true;

            }
            else {
                document.getElementById('file' + x).value = "";
                document.getElementById('filePath' + x).innerHTML = 'No File Selected';
                alert("The specified file type could not be uploaded.Only support image files and document files");
                return false;
            }
        }


        function FileLocalStorageAddPer(x) {
            var tbClientPermitFileUpload = localStorage.getItem("tbClientPermitFileUpload");//Retrieve the stored data

            tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

            if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                tbClientPermitFileUpload = [];


            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            // alert('FilePath' + FilePath);
            //  alert('descrptn' + descrptn);
            if (Fevt == 'INS') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",

                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"

                });
            }
            else if (Fevt == 'UPD') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",

                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });
            }


            tbClientPermitFileUpload.push(client);
            localStorage.setItem("tbClientPermitFileUpload", JSON.stringify(tbClientPermitFileUpload));

            $addFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));
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
            $DelFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));





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




                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    FILENAME: "" + FileName + "",
                    // EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });

                //alert('delete db');

                tbClientPermitFileUploadCancel.push(client);
                localStorage.setItem("tbClientPermitFileUploadCancel", JSON.stringify(tbClientPermitFileUploadCancel));

                $addFile("#cphMain_hiddenPerFileCanclDtlId").val(JSON.stringify(tbClientPermitFileUploadCancel));





                //document.getElementById("FileSave" + x).innerHTML = "saved";
                //   alert('saved');
                return true;

            }

        }
        function FileLocalStorageEditPer(x, row_index) {
            var tbClientPermitFileUpload = localStorage.getItem("tbClientPermitFileUpload");//Retrieve the stored data

            tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

            if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                tbClientPermitFileUpload = [];

            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;

            if (Fevt == 'INS') {

                var $FileE = jQuery.noConflict();
                tbClientPermitFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",


                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"
                });//Alter the selected item on the table
            }
            else {

                var $FileE = jQuery.noConflict();
                tbClientPermitFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",


                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });//Alter the selected item on the table



            }



            localStorage.setItem("tbClientPermitFileUpload", JSON.stringify(tbClientPermitFileUpload));
            $FileE("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));
            return true;
        }
        function CheckFileUploaded(x) {

            if (document.getElementById('file' + x).value != "") {
                return true;
            }
            else {
                return false;
            }


        }
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            var delsts=document.getElementById("<%=HiddenDelView.ClientID%>").value;
            if (delsts == "true")
            {
                document.getElementById('img1').style.pointerEvents = "none";
                document.getElementById('img3').style.pointerEvents = "none";
                 document.getElementById('imgWrap1').style.pointerEvents = "none";
                 document.getElementById('imgWrap2').style.pointerEvents = "none";
                 document.getElementById('div-Contact-details1').style.pointerEvents = "none";
              
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
                        if (json[key].TransDtlId != "") {
                            EditAttachmentPer(json[key].TransDtlId, json[key].FileName, json[key].ActualFileName);

                        }
                    }
                }


                AddFileUploadPer();
            }
            else {
                AddFileUploadPer();
            }



        });

        function CheckPassno() {
            ret = true;
            var strOrgid = document.getElementById("<%=HiddenOrgid.ClientID%>").value;
            var strCrpid = document.getElementById("<%=HiddenCorpid.ClientID%>").value;
            var strPassno = "";
            var strWrkId = "";
             strPassno = document.getElementById("<%=txtPassportNo.ClientID%>").value;
            strWrkId = document.getElementById("<%=hiddenWrkId.ClientID%>").value;
             //string stores Receipt No(0), Employee id(1),ReceiptAmnt(2),VehicleId(3),UserId (4),OrgId(5),CorpId(6)
             $co = jQuery.noConflict();
             $co.ajax({
                 type: "POST",
                 async: false,
                 contentType: "application/json; charset=utf-8",
                 url: "hcm_Joining_Worker.aspx/CheckPassNo",
                 data: '{strWrkId:"' + strWrkId + '",strPassno:"' + strPassno + '",strOrgid:"' + strOrgid + '",strCrpid:"' + strCrpid + '"}',
                 
                 dataType: "json",
                 success: function (data) {

                     if (data.d == "0") {
                        // alert('valid');
                        // document.getElementById("<%=hiddenCheck.ClientID%>").value="0";
                         ret = true;

                     }
                     else {
                        // alert('Duplicate');
                        // document.getElementById("<%=hiddenCheck.ClientID%>").value = "1";
                         ret = false;
                     }

                 },
                 error: function (response) {

                 }

             });
             return ret;

         }
    </script>
    <script>

        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }

        function ClearDivDisplayImage() {

            IncrmntConfrmCounter();

            var hidnImageSize = document.getElementById("<%=hiddenLicenceFileSize.ClientID%>").value;
            var fuData = document.getElementById("<%=FileUploadLicence.ClientID%>");
            var size = fuData.files[0].size;
            var convertToKb = hidnImageSize / 1000;
            if (size > hidnImageSize) {
                document.getElementById("<%=FileUploadLicence.ClientID%>").value = "";
                document.getElementById("<%=Label3.ClientID%>").textContent = "No File Selected";
                alert(" Sorry Maximum file size exceeds. Please Upload Image of size less than " + convertToKb + "KB !.");
                //return false;
            }
            else {

                if (document.getElementById("<%=FileUploadLicence.ClientID%>").value != "") {
                    document.getElementById("<%=Label3.ClientID%>").textContent = document.getElementById("<%=FileUploadLicence.ClientID%>").value;
                    document.getElementById("<%=divImageDisplay.ClientID%>").innerHTML = "";
                    document.getElementById("<%=hiddenLicenceFileDeleted.ClientID%>").value = document.getElementById("<%=hiddenLicenceFile.ClientID%>").value;
                    document.getElementById("<%=hiddenLicenceFile.ClientID%>").value = "";
                }

                //    return true;

            }
        }
        //certificate
        function ClearDivDisplayImageCertificates() {
            IncrmntConfrmCounter();
            var hidnImageSize = document.getElementById("<%=hiddenLicenceFileSize.ClientID%>").value;
            var fuData = document.getElementById("<%=FileUploadCertificates.ClientID%>");
             var size = fuData.files[0].size;
             var convertToKb = hidnImageSize / 1000;
             if (size > hidnImageSize) {
                 document.getElementById("<%=FileUploadCertificates.ClientID%>").value = "";
                 document.getElementById("<%=Label3Certificates.ClientID%>").textContent = "No File Selected";
                 alert(" Sorry Maximum file size exceeds. Please Upload Image of size less than " + convertToKb + "KB !.");
                 //return false;
             }
             else {

                 if (document.getElementById("<%=FileUploadCertificates.ClientID%>").value != "") {
                     document.getElementById("<%=Label3Certificates.ClientID%>").textContent = document.getElementById("<%=FileUploadCertificates.ClientID%>").value;
                    document.getElementById("<%=divImageDisplayCertificates.ClientID%>").innerHTML = "";
                    document.getElementById("<%=hiddenCertificatesFileDeleted.ClientID%>").value = document.getElementById("<%=hiddenCertificatesFile.ClientID%>").value;
                    document.getElementById("<%=hiddenCertificatesFile.ClientID%>").value = "";
                }

                 //    return true;

            }
        }
        function ClearImage() {
            if (document.getElementById("<%=hiddenLicenceFile.ClientID%>").value != "" || document.getElementById("<%=FileUploadLicence.ClientID%>").value != "") {
                if (confirm("Do you want to remove selected file?")) {
                    IncrmntConfrmCounter();
                    document.getElementById("<%=FileUploadLicence.ClientID%>").value = "";
                     document.getElementById("<%=hiddenLicenceFileDeleted.ClientID%>").value = document.getElementById("<%=hiddenLicenceFile.ClientID%>").value;
                     document.getElementById("<%=hiddenLicenceFile.ClientID%>").value = "";
                     document.getElementById("<%=divImageDisplay.ClientID%>").innerHTML = "";
                     document.getElementById("<%=Label3.ClientID%>").textContent = "No File Selected";
                     //  alert("Image has been Removed Sucessfully. ");
                 }
                 else {

                 }

             }
         }
         function ClearImageCertificates() {
             if (document.getElementById("<%=hiddenLicenceFile.ClientID%>").value != "" || document.getElementById("<%=FileUploadLicence.ClientID%>").value != "") {
                if (confirm("Do you want to remove selected file?")) {
                    IncrmntConfrmCounter();
                    document.getElementById("<%=FileUploadCertificates.ClientID%>").value = "";
                      document.getElementById("<%=hiddenCertificatesFileDeleted.ClientID%>").value = document.getElementById("<%=hiddenLicenceFile.ClientID%>").value;
                      document.getElementById("<%=hiddenCertificatesFile.ClientID%>").value = "";
                      document.getElementById("<%=divImageDisplayCertificates.ClientID%>").innerHTML = "";
                      document.getElementById("<%=Label3Certificates.ClientID%>").textContent = "No File Selected";
                      //  alert("Image has been Removed Sucessfully. ");
                  }
                  else {

                  }

              }
          }
          function ConfirmMessage() {
              if (confirmbox > 0) {
                  if (confirm("Are you sure you want to leave this page?")) {
                      window.location.href = "hcm_Joining_WorkerList.aspx";
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {
                  window.location.href = "hcm_Joining_WorkerList.aspx";
                  return false;
              }
          }
          function ConfirmClear() {
              if (confirmbox > 0) {
                  if (confirm("Are you sure you want to clear?")) {
                      window.location.href = "hcm_Joining_Worker.aspx";
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {
                  window.location.href = "hcm_Joining_Worker.aspx";
                  return false;
              }
          }

          function validateWorker(mode) {
              var ret = true;
              //#ccc
              document.getElementById("<%=txtFormFillingDate.ClientID%>").style.borderColor = '';
              document.getElementById("lblLicence").style.borderColor = '';

              var filldate = document.getElementById("<%=txtFormFillingDate.ClientID%>").value;
              var licenceFile = document.getElementById("<%=FileUploadLicence.ClientID%>").value;
              var CertificateFile = document.getElementById("<%=FileUploadCertificates.ClientID%>").value;
              //alert(mode);
              if (mode == "add") {

                  document.getElementById("<%=ddlCandidateName.ClientID%>").style.borderColor = "";


                  if (CertificateFile == "") {
                      document.getElementById("lblCertificates").style.borderColor = 'red';
                      document.getElementById("lblCertificates").focus();
                      ret = false;
                  }

                  if (licenceFile == "") {

                      document.getElementById("lblLicence").style.borderColor = 'red';
                      document.getElementById("lblLicence").focus();
                      ret = false;
                  }

                  if (filldate == "") {
                      document.getElementById("<%=txtFormFillingDate.ClientID%>").style.borderColor = 'red';
                      document.getElementById("<%=txtFormFillingDate.ClientID%>").focus();
                      ret = false;
                  }

                  var ddlInterviewTemp = document.getElementById("<%=ddlCandidateName.ClientID%>").value;
                  if (ddlInterviewTemp == "--SELECT CANDIDATE--") {

                      //If the "Please Select" option is selected display error.
                      ErrMsg();
                      document.getElementById("<%=ddlCandidateName.ClientID%>").focus();
                      document.getElementById("<%=ddlCandidateName.ClientID%>").style.borderColor = 'red';

                      ret = false;
                  }



                  if (CheckPassno() == false) {
                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.Passport Number can’t be duplicated.";
                      document.getElementById("<%=txtPassportNo.ClientID%>").focus();
                      document.getElementById("<%=txtPassportNo.ClientID%>").style.borderColor = 'Red';
                      ret = false;
                  }
              }

              if (mode == "update") {

                  if (document.getElementById("<%=hiddenCertificatesFile.ClientID%>").value == "") {
                      if (CertificateFile == "") {
                          document.getElementById("lblCertificates").style.borderColor = 'red';
                          document.getElementById("lblCertificates").focus();
                          ret = false;
                      }
                  }


                  if (document.getElementById("<%=hiddenLicenceFile.ClientID%>").value == "") {
                      if (licenceFile == "") {
                          document.getElementById("lblLicence").style.borderColor = 'red';
                          document.getElementById("lblLicence").focus();
                          ret = false;
                      }
                  }


                  if (filldate == "") {
                      document.getElementById("<%=txtFormFillingDate.ClientID%>").style.borderColor = 'red';
                      document.getElementById("<%=txtFormFillingDate.ClientID%>").focus();
                      ret = false;
                  }


                  if (CheckPassno() == false) {
                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.Passport Number can’t be duplicated.";
                      document.getElementById("<%=txtPassportNo.ClientID%>").focus();
                      document.getElementById("<%=txtPassportNo.ClientID%>").style.borderColor = 'Red';
                      ret = false;
                  }

              }

              return ret;
          }
        function ErrMsg() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
        }
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
            IncrmntConfrmCounter();
            
            var txt = document.getElementById(obj).value;
            var replaceText1 = txt.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(obj).value = replaceText2;
           
        }
        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }

        function SuccessIns() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Worker details inserted successfully.";
              $(window).scrollTop(0);
          }
          //old
          function SuccessUpdation() {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Worker details updated successfully.";
          }
          function SuccessCancelation() {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Worker details cancelled successfully.";
        }
        function SuccessRecall() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Worker details recalled successfully.";
        }
        function SuccessStatusChange() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Worker details status changed successfully.";
        }
        function SuccessReOpen() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Worker details reOpened successfully.";
        }
        function SuccessConfirm() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Worker details confirmed successfully.";
        }
        function SuccessClose() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Worker details closed successfully.";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenFilePath" runat="server" />
    <asp:HiddenField ID="hiddenEdit" runat="server" />
    <asp:HiddenField ID="hiddenView" runat="server" />
    <asp:HiddenField ID="HiddenField2_FileUpload" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hiddenLicenceFileSize" runat="server" />
    <asp:HiddenField ID="hiddenLicenceFileDeleted" runat="server" />
    <asp:HiddenField ID="hiddenLicenceFile" runat="server" />

    <asp:HiddenField ID="hiddenCertificatesFileDeleted" runat="server" />
    <asp:HiddenField ID="hiddenCertificatesFile" runat="server" />
    <asp:HiddenField ID="hiddenPerFileCanclDtlId" runat="server" />

    <asp:HiddenField ID="hiddenLicenceFileAct" runat="server" />

    <asp:HiddenField ID="hiddenCertificatesFileAct" runat="server" />
    <asp:HiddenField ID="hiddenCandID" runat="server" />
    <asp:HiddenField ID="HiddenDelView" runat="server" />
    <asp:HiddenField ID="HiddenCnclId" runat="server" />
    <asp:HiddenField ID="hiddenWrkId" runat="server" />
  <asp:HiddenField ID="hiddenCheck" runat="server" />
    <asp:HiddenField ID="HiddenOrgid" runat="server" />
    <asp:HiddenField ID="HiddenCorpid" runat="server" />
    <asp:HiddenField ID="hiddenLicFile" runat="server" />
        <asp:HiddenField ID="hiddenCerFile" runat="server" />
    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div class="cont_rght">


        <div id="divErrorTotal" style="visibility: hidden">
            <asp:Label ID="lblErrorTotal" runat="server"></asp:Label>
        </div>
        <br />
        <br />
        <br />

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 5%; top: 42%; height: 26.5px;">
        </div>

        <div style="width: 100%;">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" Text="Worker" runat="server"></asp:Label>
            </div>
            <br />
            <br />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

               
            <div class="eachform" id="divCandidateName" runat="server" style="width: 100%; float: left;">
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="margin-top: 1%;">Candidate Name*</h2>
                    <asp:DropDownList ID="ddlCandidateName" Height="30px" Width="294px" class="form1" onchange="IncrmntConfrmCounter();" AutoPostBack="true" OnSelectedIndexChanged="ddlCandidateName_SelectedIndexChanged" onkeypress="return DisableEnter(event);" runat="server"></asp:DropDownList>

                </div>
            </div>
            <div class="eachform" style="width: 47%; float: left;">
                <h2 style="margin-top: 1%;">Name*</h2>
                <asp:TextBox ID="txtWorkerName" Height="30px" Width="275px" class="form1" runat="server" MaxLength="95" Style="text-transform: uppercase;" onkeypress="return isTag(event);"></asp:TextBox>

            </div>
            <div class="eachform" style="width: 47%; padding-left: 6%">
                <h2 style="margin-top: 1%;">Division*</h2>

                <asp:TextBox ID="txtDivision" Height="30px" Width="275px" class="form1" runat="server" MaxLength="95" Style="text-transform: uppercase;" onkeypress="return isTag(event);"></asp:TextBox>

            </div>

            
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="margin-top: 1%;">Designation*</h2>
                    <asp:TextBox ID="txtDesignation" Height="30px" Width="275px" onblur="RemoveTag('cphMain_txtDesignation');" class="form1" runat="server" MaxLength="95" Style="text-transform: uppercase;" onkeypress="return isTag(event);"></asp:TextBox>

                </div>
                 </ContentTemplate>
            </asp:UpdatePanel>
                <div class="eachform" style="width: 47%; padding-left: 6%">
                    <h2 style="margin-top: 1%;">Passport Number </h2>

                    <asp:TextBox ID="txtPassportNo" Height="30px" onblur="RemoveTag('cphMain_txtPassportNo');" Width="275px" class="form1" runat="server" MaxLength="95" Style="text-transform: uppercase;" onkeypress="return isTag(event);"></asp:TextBox>

                </div>
            </div>
            <div class="eachform" style="width: 47%; float: left;">
                <h2 style="margin-top: 1%;">Joining Date</h2>

                <div id="divJoiningDate" class="input-append date" style="font-family: Calibri; float: right; width: 63%;" onchange="IncrmntConfrmCounter();">
                    <asp:TextBox ID="txtJoiningDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return DisableEnter(event)" Style="width: 82.8%; height: 28px; float: left; font-family: calibri;" onchange="IncrmntConfrmCounter();"></asp:TextBox>

                    <img id="img1" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter();"  style="margin-left: .1%; height: 19.5px; width: 20px; cursor: pointer;" />
                    <link href="../../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                    <link href="../../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                    <script type="text/javascript"
                        src="../../../../JavaScript/Date/JavaScriptDate1_8_3.js">
                    </script>
                    <script type="text/javascript"
                        src="../../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                    </script>
                    <script type="text/javascript"
                        src="../../../../JavaScript/Date/bootstrap-datepicker.js">
                    </script>
                    <script type="text/javascript"
                        src="../../../../JavaScript/Date/bootstrap-datepicker_pt_br.js">
                    </script>
                    <script type="text/javascript">
                        var $noC = jQuery.noConflict();
                        $noC('#divJoiningDate').datetimepicker({
                            format: 'dd-MM-yyyy',
                            language: 'en',
                            pickTime: false,

                            //endDate: new Date(),
                        });

                    </script>
                </div>

            </div>
            <div class="eachform" style="width: 47%; padding-left: 6%">
                <h2 style="margin-top: 1%;">Form Filling Date*</h2>

                <div id="divFormFillingDate" class="input-append date" style="font-family: Calibri; float: right; width: 63%;">
                    <asp:TextBox ID="txtFormFillingDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return DisableEnter(event)" Style="width: 82.8%; height: 28px; float: left; font-family: calibri;" onchange="IncrmntConfrmCounter();"></asp:TextBox>

                    <img id="img3" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter();"  style="margin-left: .1%; height: 19.5px; width: 20px; cursor: pointer;" onchange="IncrmntConfrmCounter();" />
                    <link href="../../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                    <link href="../../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                    <script type="text/javascript"
                        src="../../../../JavaScript/Date/JavaScriptDate1_8_3.js">
                    </script>
                    <script type="text/javascript"
                        src="../../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                    </script>
                    <script type="text/javascript"
                        src="../../../../JavaScript/Date/bootstrap-datepicker.js">
                    </script>
                    <script type="text/javascript"
                        src="../../../../JavaScript/Date/bootstrap-datepicker_pt_br.js">
                    </script>
                    <script type="text/javascript">
                        var $noC = jQuery.noConflict();
                        $noC('#divFormFillingDate').datetimepicker({
                            format: 'dd-MM-yyyy',
                            language: 'en',
                            pickTime: false,

                            //endDate: new Date(),
                        });

                    </script>
                </div>

            </div>



            <div class="eachform" style="width: 47%; float: left;">
                <h2 style="margin-top: 1%;">Site Number</h2>

                <asp:TextBox ID="txtSiteNo" Height="30px" Width="275px" onblur="RemoveTag('cphMain_txtSiteNo');" class="form1" runat="server" MaxLength="95" Style="text-transform: uppercase;" onkeypress="return isTag(event);"></asp:TextBox>


            </div>
            <div class="eachform" style="width: 47%; padding-left: 6%">
                <h2 style="margin-top: 1%;">License Attach*</h2>
                <label for="cphMain_FileUploadLicence" id="lblLicence" class="custom-file-upload" tabindex="0" style="margin-left: 13.8%; font-family: Calibri;">
                    <img src="../../../../Images/Icons/cloud_upload.jpg" />Upload File</label>


                <asp:FileUpload ID="FileUploadLicence" class="fileUpload" runat="server" Style="height: 30px; display: none;" onchange="ClearDivDisplayImage()" Accept="All" />


                <div id="divImageEdit" runat="server" style="float: left; width: 54%; height: 20px; margin-top: 0%; margin-left:37%;">
                    <div id="imgWrap1" class="imgWrap">
                        <img id="ClearImageLicense" src="/Images/Icons/clear-image-green.png" alt="Clear" title="Remove File" onclick="ClearImage()" style="cursor: pointer; float: right;" />
                    </div>
                    <div id="divImageDisplay" runat="server">
                    </div>
                </div>
                <asp:Label ID="Label3" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
            </div>
            <div class="eachform" style="width: 47%; float: left;">
                <h2 style="margin-top: 1%;">Certificate Attach*</h2>
                <label for="cphMain_FileUploadCertificates" id="lblCertificates" class="custom-file-upload" tabindex="0" style="margin-left: 9.5%; font-family: Calibri;">
                    <img src="../../../../Images/Icons/cloud_upload.jpg" />Upload File</label>


                <asp:FileUpload ID="FileUploadCertificates" class="fileUpload" runat="server" Style="height: 30px; display: none;" onchange="ClearDivDisplayImageCertificates()" Accept="All" />


                <div id="divCertificates" runat="server" style="float: left; width: 54%; height: 20px; margin-top: 0%; margin-left:37%;">
                    <div  id="imgWrap2" class="imgWrap">
                        <img id="imgClearCertificates" src="/Images/Icons/clear-image-green.png" alt="Clear" title="Remove File" onclick="ClearImageCertificates()" style="cursor: pointer; float: right;" />
                    </div>
                    <div id="divImageDisplayCertificates" runat="server">
                    </div>
                </div>
                <asp:Label ID="Label3Certificates" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
            </div>
            <div class="eachform" style="width: 47%; padding-left: 6%">
                <h2 style="margin-top: 1%;">Comments</h2>
                <asp:TextBox ID="txtComments" class="form1"  Height="80px" Width="276px" Style="float: right; resize: none; font-family: Calibri;" runat="server" TextMode="MultiLine"  onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtComments,450);" onkeyup="textCounter(cphMain_txtComments,450);" onblur="RemoveTag('cphMain_txtComments');"></asp:TextBox>


            </div>



            <div id="div-Contact-details1" class="div-Contact-details" style="float: left; margin-left: -2%;">
                <div class="eachform" style="width: 100%; float: left;">
                    <h2>Other Document Attach</h2>
                </div>
                <div id="divPerAtch" runat="server" style="overflow-y: auto; height: 127px; width: 98%;">


                    <table id="TableFileUploadContainerPermit" style="width: 100%;">
                    </table>
                </div>



            </div>

            <br />
            <div class="eachform" style="margin-top: 3%;">
                <div class="subform" style="width: 60%;">
                     <asp:Button ID="btnRegCandidate" runat="server" class="save" Text="Register" OnClick="btnRegCandidate_Click" />
                     <asp:Button ID="btnCnfrmSts"  OnClientClick="return validateWorker('update');" runat="server" class="save" Text="Confirm" OnClick="btnCnfrmSts_Click"  />
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return validateWorker('update');" />
                    <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return validateWorker('update');" />
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClientClick="return validateWorker('add');" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return validateWorker('add');" />
                    <asp:Button ID="btnClear" runat="server" class="save" Text="Clear" OnClientClick="return ConfirmClear();" />
                    <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                </div>
            </div>



        </div>
    </div>
</asp:Content>

