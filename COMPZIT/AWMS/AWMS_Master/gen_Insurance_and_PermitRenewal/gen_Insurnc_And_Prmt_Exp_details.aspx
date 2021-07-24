<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" CodeFile="gen_Insurnc_And_Prmt_Exp_details.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Insurance_and_PermitRenewal_gen_Insurnc_And_Prmt_Exp_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
    <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/css/CssLeadIndividualModal.css" />



    <style>
       .tooltip {
    position: relative;
    z-index: 68;
    display: block;
    padding: 2.5px;
    font-size: 11px;
    opacity: 0;
    filter: alpha(opacity=0);
    visibility: visible;
   
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

                  
           #goofy {
            right:17%;
            top:53px;
            width:60%;
        }
          .imgDescription {
            position: absolute;
            /*top: 511px;
            left: 6.5%;*/
            background: rgba(123, 150, 100, 0.7);
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

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.7;
        }

        .modalPopup {
            background-color: #FFFFFF;
            width: 700px;
            border: 3px solid #7d8966;
            padding: 0;
            height: 528px;
        }

            .modalPopup .header {
                background-color: #91a172;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }
        input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;

        }
         #a_Caption:hover {
        color: rgb(83, 101, 51);
        
        }
        #a_Caption {
        color: rgb(88, 134, 7);
        
        }
        #a_Caption:focus {
        color: rgb(83, 101, 51);
        
        }
        #print_cap {
            font-size:17px;
        }
         #print_cap:hover {
        color: rgb(83, 101, 51);
        
        }
        #print_cap {
        color: rgb(88, 134, 7);
        
        }
        #print_cap:focus {
        color: rgb(83, 101, 51);
        
        }
          .searchlist_btn_rght {
            cursor: pointer;
        }
            input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
            cursor:default;
        }
        .searchlist_btn_lft:hover {
        background:url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        
        }
        .searchlist_btn_lft:focus {
        background:url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        
        }
         .searchlist_btn_rght:hover {
                background: #7B866A;
            }
             .searchlist_btn_rght:focus {
                background: #7B866A;
            }
        .input-append, .input-prepend {
            margin-bottom:8px;
        }
        .container {
            margin-top: 2%;
            display: none;
            border: .5px solid;
            border-color: #9ba48b;
            background-color: #f3f3f3;
            width: 100%;
        }
    .open > .dropdown-menu {
    display: none;
}
    .bootstrap-datetimepicker-widget {

    z-index: 100;

}


        .Previous {
    background: url(/Images/BigIcons/Previous.png) no-repeat 0 0;
    width: 90px;
}
    </style>

     <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

    <script>
//new
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            localStorage.clear();
            MoneyCheck('cphMain_txtOldInsAmount');
          
                AddFileUpload();              
              
         
        });
    </script>
    <script type="text/javascript">

        var Filecounter = 0;

        function AddFileUpload() {
            var FrecRow = '<tr id="FilerowId_' + Filecounter + '" >';


            var labelForStyle = '<label for="file' + Filecounter + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
            var tdInner = labelForStyle + '<input   id="file' + Filecounter + '" name = "file' + Filecounter +

                           '" type="file" onchange="ChangeFile(' + Filecounter + ')" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/>';

            FrecRow += '<td style="width: 27%;" >' + tdInner + '</td>';

            FrecRow += '<td style="word-break: break-all;" id="filePath' + Filecounter + '"  ></td  >';

            //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

            //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';
            FrecRow += '<td style="width: 1.5%; padding-left: 1px;font-family: calibri;"><textarea id="descrptn' + Filecounter + '"    style="resize: none;border: 1px solid #ccc;height: 45px;font-family: calibri;"  MaxLength="50" value="--Description--" onfocus="focusTxtDescrptn(' + Filecounter + ');" onkeypress="return RemoveTag(event);"  onblur="blurTxtDescrptn(' + Filecounter + ');" onkeydown="textCounter(descrptn' + Filecounter + ',99);" onkeyup="textCounter(descrptn' + Filecounter + ',99);"></textarea></td>';
            FrecRow += '<td id="FileIndvlAddMoreRow' + Filecounter + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFiles(' + Filecounter + ');" style="  cursor: pointer;"></td>';
            FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUpload(' + Filecounter + ');"    style=" cursor: pointer;" ></td>';

            FrecRow += ' <td id="FileInx' + Filecounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + Filecounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + Filecounter + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId' + Filecounter + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName' + Filecounter + '" style="display: none;"></td>';
            FrecRow += '</tr>';
            var mode = document.getElementById("<%=HiddenAtchmnt.ClientID%>").value;
            if (mode == "PRMT") {
                jQuery('#TableFileUploadContainer').append(FrecRow);
                $noCon('#divPrmmtTableFileUpload').scrollTop($noCon('#divPrmmtTableFileUpload')[0].scrollHeight);
            }
            if (mode == "INSUR") {
                jQuery('#TableFileUploadContainerIns').append(FrecRow);
                $noCon('#divInsTableFileUpload').scrollTop($noCon('#divInsTableFileUpload')[0].scrollHeight);
            }
            document.getElementById('filePath' + Filecounter).innerHTML = 'No File Uploaded';

            document.getElementById("descrptn" + Filecounter).value = "--Description--";
            Filecounter++;

        }



        function EditAttachment(editTransDtlId, EditFileName, EditActualFileName) {
            var FrecRow = '<tr id="FilerowId_' + Filecounter + '" >';


            var labelForStyle = '<label for="file' + Filecounter + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
            var tdInner = labelForStyle + '<input   id="file' + Filecounter + '" name = "file' + Filecounter +

                           '" type="file" onchange="ChangeFile(' + Filecounter + ')" />';

            FrecRow += '<td style="width: 25%; display:none;" >' + tdInner + '</td>';

            var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

            FrecRow += '<td colspan="2"  id="filePath' + Filecounter + '" style="border-bottom: 1px dotted rgb(205, 237, 196);"' + '  >' + tdFileNameEdit + '</td  >';

            //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

            //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';

            FrecRow += '<td id="FileIndvlAddMoreRow' + Filecounter + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFiles(' + Filecounter + ');" style="  cursor: pointer;"></td>';
            FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUpload(' + Filecounter + ');"    style=" cursor: pointer;" ></td>';

            FrecRow += ' <td id="FileInx' + Filecounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + Filecounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + Filecounter + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId' + Filecounter + '" style="display: none;">' + editTransDtlId + '</td>';
            FrecRow += '<td id="DbFileName' + Filecounter + '" style="display: none;">' + EditFileName + '</td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadContainer').append(FrecRow);
            document.getElementById("FileInx" + Filecounter).innerHTML = Filecounter;
            document.getElementById("FileIndvlAddMoreRow" + Filecounter).style.opacity = "0.3";
            // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
            FileLocalStorageAdd(Filecounter);
            Filecounter++;

        }

        function ViewAttachment(editTransDtlId, EditFileName, EditActualFileName) {
            var FrecRow = '<tr id="FilerowId_' + Filecounter + '" >';


            var labelForStyle = '<label for="file' + Filecounter + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
            var tdInner = labelForStyle + '<input   id="file' + Filecounter + '" name = "file' + Filecounter +

                           '" type="file" onchange="ChangeFile(' + Filecounter + ')" />';

            FrecRow += '<td style="width: 25%; display:none;" >' + tdInner + '</td>';

            var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

            FrecRow += '<td colspan="2"  id="filePath' + Filecounter + '"  >' + tdFileNameEdit + '</td  >';

            //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

            //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';

            FrecRow += '<td id="FileIndvlAddMoreRow' + Filecounter + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFiles(' + Filecounter + ');" style="  cursor: pointer;"></td>';
            FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUpload(' + Filecounter + ');"    style=" cursor: pointer;" ></td>';

            FrecRow += ' <td id="FileInx' + Filecounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + Filecounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + Filecounter + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId' + Filecounter + '" style="display: none;">' + editTransDtlId + '</td>';
            FrecRow += '<td id="DbFileName' + Filecounter + '" style="display: none;">' + EditFileName + '</td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadContainer').append(FrecRow);
            document.getElementById("FileInx" + Filecounter).innerHTML = Filecounter;
            document.getElementById("FileIndvlAddMoreRow" + Filecounter).style.opacity = "0.3";
            // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
            FileLocalStorageAdd(Filecounter);
            Filecounter++;

        }


        function RemoveFileUpload(removeNum) {
            if (confirm("Are you Sure you want to Delete Selected File?")) {
                //  alert('ASD');
                var Filerow_index = jQuery('#FilerowId_' + removeNum).index();
                FileLocalStorageDelete(Filerow_index, removeNum);
                jQuery('#FilerowId_' + removeNum).remove();

                
                var mode = document.getElementById("<%=HiddenAtchmnt.ClientID%>").value;

                // alert(Filerow_index);
                if(mode == "PRMT"){
                var TableFileRowCount = document.getElementById("TableFileUploadContainer").rows.length;

                if (TableFileRowCount != 0) {
                    var idlast = $noC('#TableFileUploadContainer tr:last').attr('id');
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
                    AddFileUpload();


                }
            }

                if (mode == "INSUR") {
                    var TableFileRowCount = document.getElementById("TableFileUploadContainerIns").rows.length;

            if (TableFileRowCount != 0) {
                var idlast = $noC('#TableFileUploadContainerIns tr:last').attr('id');
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
                AddFileUpload();


            }
        }
            }
            else {

                return false;
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

        function ChangeFile(x) {
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
                    FileLocalStorageEdit(x, row_index);
                }
                else {
                    FileLocalStorageAdd(x);
                }
            }
        }
        function CheckFileUploaded(x) {

            if (document.getElementById('file' + x).value != "") {
                return true;
            }
            else {
                return false;
            }


        }
        function CheckaddMoreRowsIndividualFiles(x) {
            // for add image in each row
           
            var check = document.getElementById("FileInx" + x).innerHTML;

            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            //  alert(check);
            if (check == " ") {

                var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                if (Fevt != 'UPD') {
                    if (CheckFileUploaded(x) == true) {
                        document.getElementById("FileInx" + x).innerHTML = x;
                        document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                        AddFileUpload();
                        return false;
                    }
                }
                else {

                    document.getElementById("FileInx" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                    AddFileUpload();
                    return false;
                }
            }
            return false;
        }
        function focusTxtDescrptn(x) {
           if (document.getElementById("descrptn" + x).value == "--Description--")
            document.getElementById("descrptn" + x).value = "";
           

            

        }
        function blurTxtDescrptn(x) {
            var val=document.getElementById("descrptn" + x).value;
            if (val == "") {
                document.getElementById("descrptn" + x).value = "--Description--";
            }
            else {
                if (val != "--Description--") {
                    IncrmntConfrmCounter();
                    var WithoutReplace = val;

                    var replaceText1 = WithoutReplace.replace(/</g, "");
                    var replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("descrptn" + x).value = replaceText2.trim();
                }
                var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                if (SavedorNot == "saved") {
                    var row_index = jQuery('#FilerowId_' + x).index();
                    FileLocalStorageEdit(x, row_index);
                }
            }
        }
        // for not allowing enter
        function DisableEnter(evt) {
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
         </script>
   
    <script>
        function FileLocalStorageAdd(x) {
           
            var tbClientQuotationFileUpload = localStorage.getItem("tbClientQuotationFileUpload");//Retrieve the stored data

            tbClientQuotationFileUpload = JSON.parse(tbClientQuotationFileUpload); //Converts string to object

            if (tbClientQuotationFileUpload == null) //If there is no data, initialize an empty array
                tbClientQuotationFileUpload = [];


            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var descrptn = document.getElementById("descrptn" + x).value;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
         // alert('FilePath' + FilePath);
          //  alert('descrptn' + descrptn);
            if (Fevt == 'INS') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    FILEPATH: "" + FilePath + "",
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"

                });
            }
            else if (Fevt == 'UPD') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    FILEPATH: "" + FilePath + "",
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });
            }


            tbClientQuotationFileUpload.push(client);
            localStorage.setItem("tbClientQuotationFileUpload", JSON.stringify(tbClientQuotationFileUpload));

            $addFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientQuotationFileUpload));



           //alert("The FILE ADDED.");
             //var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
              //alert(h);

             document.getElementById("FileSave" + x).innerHTML = "saved";
        //  alert('saved');
             return true;

         }

         function FileLocalStorageDelete(row_index, x) {
             var $DelFile = jQuery.noConflict();
             var tbClientQuotationFileUpload = localStorage.getItem("tbClientQuotationFileUpload");//Retrieve the stored data

             tbClientQuotationFileUpload = JSON.parse(tbClientQuotationFileUpload); //Converts string to object

             if (tbClientQuotationFileUpload == null) //If there is no data, initialize an empty array
                 tbClientQuotationFileUpload = [];



             // Using splice() we can specify the index to begin removing items, and the number of items to remove.
             tbClientQuotationFileUpload.splice(row_index, 1);
             localStorage.setItem("tbClientQuotationFileUpload", JSON.stringify(tbClientQuotationFileUpload));
             $DelFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientQuotationFileUpload));
             //   alert("FILE deleted.");

             //   var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
            //  alert(h);


            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            if (Fevt == 'UPD') {
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

                if (FdetailId != '') {
                    //      var FCanclIds = document.getElementById("<%=hiddenFileCanclDtlId.ClientID%>").value;

                    //  if (FCanclIds == '') {
                    //      document.getElementById("<%=hiddenFileCanclDtlId.ClientID%>").value = FdetailId;

                    //  }
                    //  else {

                    //      document.getElementById("<%=hiddenFileCanclDtlId.ClientID%>").value = document.getElementById("<%=hiddenFileCanclDtlId.ClientID%>").value + ',' + FdetailId;
                    // }
                    DeleteFileLSTORAGEAdd(x);
                }

            }

            function DeleteFileLSTORAGEAdd(x) {

                var tbClientQuotationFileCancel = localStorage.getItem("tbClientQuotationFileCancel");//Retrieve the stored data

                tbClientQuotationFileCancel = JSON.parse(tbClientQuotationFileCancel); //Converts string to object

                if (tbClientQuotationFileCancel == null) //If there is no data, initialize an empty array
                    tbClientQuotationFileCancel = [];


                var FileName = document.getElementById("DbFileName" + x).innerHTML;
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
                var descrptn = document.getElementById("descrptn" + x).value;



                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    FILEPATH: "" + FilePath + "",
                    DESCRPTN: "" + descrptn + "",
                    // EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });



                tbClientQuotationFileCancel.push(client);
                localStorage.setItem("tbClientQuotationFileCancel", JSON.stringify(tbClientQuotationFileCancel));

                $addFile("#cphMain_hiddenFileCanclDtlId").val(JSON.stringify(tbClientQuotationFileCancel));



                //     alert("The FILEDELETED ADDED.");
                //     var h = document.getElementById("<%=hiddenFileCanclDtlId.ClientID%>").value;
                //   alert(h);

                //document.getElementById("FileSave" + x).innerHTML = "saved";
                //   alert('saved');
                return true;

            }

        }

        function FileLocalStorageEdit(x, row_index) {
            var tbClientQuotationFileUpload = localStorage.getItem("tbClientQuotationFileUpload");//Retrieve the stored data

            tbClientQuotationFileUpload = JSON.parse(tbClientQuotationFileUpload); //Converts string to object

            if (tbClientQuotationFileUpload == null) //If there is no data, initialize an empty array
                tbClientQuotationFileUpload = [];

            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var descrptn = document.getElementById("descrptn" + x).value;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;

            if (Fevt == 'INS') {

                var $FileE = jQuery.noConflict();
                tbClientQuotationFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    FILEPATH: "" + FilePath + "",
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"
                });//Alter the selected item on the table
            }
            else {

                var $FileE = jQuery.noConflict();
                tbClientQuotationFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    FILEPATH: "" + FilePath + "",
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });//Alter the selected item on the table



            }



            localStorage.setItem("tbClientQuotationFileUpload", JSON.stringify(tbClientQuotationFileUpload));
            $FileE("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientQuotationFileUpload));

          //alert("The FILE EDITED.");

            //var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
             //alert(h);
            return true;
        }
    </script>
     <script language="javascript" type="text/javascript">


         //for permit file uploader

        
        


        //for insurance file upload

       



         var confirmbox = 0;

         function IncrmntConfrmCounter() {
             confirmbox++;
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


         function ConfirmMessage() {
             if (confirmbox > 0) {
            
                 if (confirm("Are You Sure You Want To Leave This Page?")) {
                     if (document.getElementById("<%=hiddenRedirect.ClientID%>").value == "") {
                         window.location.href = "gen_Insurance_and_PermitRenewal.aspx";
                     }
                     else {
                         if (document.getElementById("<%=hiddenRedirectMode.ClientID%>").value == "PRMT") {
                             var VehId = document.getElementById("<%=hiddenRedirect.ClientID%>").value;
                             window.location.href = "/AWMS/AWMS_Master/gen_Vehicle_Master/gen_Vehicle_Master.aspx?Id=" + VehId + "&&MODE=PER&TR=" + document.getElementById("<%=HiddenFieldTR.ClientID%>").value;
                         }
                        else if (document.getElementById("<%=hiddenRedirectMode.ClientID%>").value == "INSUR") {
                             var VehId = document.getElementById("<%=hiddenRedirect.ClientID%>").value;
                            window.location.href = "/AWMS/AWMS_Master/gen_Vehicle_Master/gen_Vehicle_Master.aspx?Id=" + VehId + "&&MODE=INS&TR=" + document.getElementById("<%=HiddenFieldTR.ClientID%>").value;
                          }
                     }
                 }
                 else {
                     return false;
                 }
             }
             else {
                 if (document.getElementById("<%=hiddenRedirect.ClientID%>").value == "") {
                     window.location.href = "gen_Insurance_and_PermitRenewal.aspx";
                 }

                 else {
                     if (document.getElementById("<%=hiddenRedirectMode.ClientID%>").value == "PRMT") {
                         var VehId = document.getElementById("<%=hiddenRedirect.ClientID%>").value;
                         window.location.href = "/AWMS/AWMS_Master/gen_Vehicle_Master/gen_Vehicle_Master.aspx?Id=" + VehId + "&&MODE=PER&TR=" + document.getElementById("<%=HiddenFieldTR.ClientID%>").value;
                         }
                         else if (document.getElementById("<%=hiddenRedirectMode.ClientID%>").value == "INSUR") {
                             var VehId = document.getElementById("<%=hiddenRedirect.ClientID%>").value;
                             window.location.href = "/AWMS/AWMS_Master/gen_Vehicle_Master/gen_Vehicle_Master.aspx?Id=" + VehId + "&&MODE=INS&TR=" + document.getElementById("<%=HiddenFieldTR.ClientID%>").value;
                        }
                }

             }
         }
         
         

         function AlertClearAll() {
             if (confirmbox > 0) {
                 if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                     //exceptional case for remove the data in the special text box
                     document.getElementById('cphMain_txtNewInsuranceAmount').value = "";
                     return true;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 //exceptional case for remove the data in the special text box
                 document.getElementById('cphMain_txtNewInsuranceAmount').value = "";
                 return true;

             }
         }


         function ImagePosition(object) {

             var $Mo = jQuery.noConflict();

             var offset = $Mo("#" + object).offset();

             var posY = 0;
             var posX = 0;
             posY = offset.top;

             posX = offset.left

             posX = 48.1;

             var d = document.getElementById('RemovePhoto');

             d.style.position = "absolute";
             d.style.left = posX + '%';
             d.style.top = posY + 15 + 'px';
         }
         function ImagePositionInsur(object) {

             var $Mo = jQuery.noConflict();

             var offset = $Mo("#" + object).offset();

             var posY = 0;
             var posX = 0;
             posY = offset.top;

             posX = offset.left

             posX = 48.1;

             var d = document.getElementById('RemovePhotoInsur');

             d.style.position = "absolute";
             d.style.left = posX + '%';
             d.style.top = posY + 15 + 'px';
         }


         function textCounter(field, maxlimit) {
             if (field.value.length > maxlimit) {
                 field.value = field.value.substring(0, maxlimit);
             } else {

             }
         }

         function RemoveTag(evt) {

             var charCode = (evt.which) ? evt.which : evt.keyCode;
             var ret = true;
             if (charCode == 60 || charCode == 62) {
                 ret = false;
             }
             return ret;
         }
    </script>



     <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

    <script>

        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance Renewal details Inserted Successfully.";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
        }
        function SuccessPermtConfirmation() {
            var permitname = "";
            if (document.getElementById("<%=hiddenPermitLabelName.ClientID%>").value != "") {
                  permitname = document.getElementById("<%=hiddenPermitLabelName.ClientID%>").value;
            }
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "" + permitname + " Renewal details Inserted Successfully.";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
        }


       
        function DuplicationInsurance() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=txtNewInsrncNmbr.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtNewInsrncNmbr.ClientID%>").focus();
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Insurance Number Can’t be Duplicated.";
            }
        //for validating permit


        function ValidatePermit() {


            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }


           

            var DateWithoutReplace = document.getElementById("<%=txtNewPerDate.ClientID%>").value;
            var replaceText1 = DateWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtNewPerDate.ClientID%>").value = replaceText2;

         

            document.getElementById("<%=txtNewPerDate.ClientID%>").style.borderColor = "";

            var DatePer = document.getElementById("<%=txtNewPerDate.ClientID%>").value.trim();
           



            if (DatePer == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtNewPerDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtNewPerDate.ClientID%>").focus();
                ret = false;
            }

            else {

                var TaskdatepickerDate = document.getElementById("<%=txtNewPerDate.ClientID%>").value;
                var arrDatePickerDate = TaskdatepickerDate.split("-");
                var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);
                if (dateDateCntrlr < dateCurrentDate) {
                    document.getElementById("<%=txtNewPerDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtNewPerDate.ClientID%>").focus();
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, Renewal Date should be less than Current Date !";
                    ret = false;

                }

            }
            

            if (ret == false) {
                CheckSubmitZero();

            }
            return ret;
        }



        //for validating insurance
        function ValidateInsurance() {
        
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
     
            var NumbrWithoutReplace = document.getElementById("<%=txtNewInsrncNmbr.ClientID%>").value;
            var replaceText1 = NumbrWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtNewInsrncNmbr.ClientID%>").value = replaceText2;
        
            var DateWithoutReplace = document.getElementById("<%=txtNewInsrncDate.ClientID%>").value;
            var replaceText1 = DateWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtNewInsrncDate.ClientID%>").value = replaceText2;

            var AmountWithoutReplace = document.getElementById("<%=txtNewInsuranceAmount.ClientID%>").value;
            var replaceText1 = AmountWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtNewInsuranceAmount.ClientID%>").value = replaceText2;

            document.getElementById("<%=txtNewInsuranceAmount.ClientID%>").style.borderColor = "";

            document.getElementById("<%=txtNewInsrncNmbr.ClientID%>").style.borderColor = "";
            
            document.getElementById("<%=txtNewInsrncDate.ClientID%>").style.borderColor = "";
           
            document.getElementById("<%=ddlInsrncPrvdrId.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlNewCoverageType.ClientID%>").style.borderColor = "";

            var DateIns = document.getElementById("<%=txtNewInsrncDate.ClientID%>").value.trim();
            var Number = document.getElementById("<%=txtNewInsrncNmbr.ClientID%>").value.trim();
            var Amount = document.getElementById("<%=txtNewInsuranceAmount.ClientID%>").value.trim();

            var PrvdrId = document.getElementById("<%=ddlInsrncPrvdrId.ClientID%>");
            var PrvdrText = PrvdrId.options[PrvdrId.selectedIndex].text;

            var CoverageType= document.getElementById("<%=ddlNewCoverageType.ClientID%>");
            var CoverageTypeText = CoverageType.options[CoverageType.selectedIndex].text;
            if (CoverageTypeText == "--SELECT COVERAGE TYPE--") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlNewCoverageType.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlNewCoverageType.ClientID%>").focus();
                ret = false;
            }
            
            if (Amount == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtNewInsuranceAmount.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtNewInsuranceAmount.ClientID%>").focus();
                 ret = false;
             }

            if (PrvdrText == "--SELECT INSURANCE PROVIDER--") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlInsrncPrvdrId.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=ddlInsrncPrvdrId.ClientID%>").focus();
                 ret = false;
             }
            if (DateIns == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtNewInsrncDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtNewInsrncDate.ClientID%>").focus();
                ret = false;
            }

            else {

                var TaskdatepickerDate = document.getElementById("<%=txtNewInsrncDate.ClientID%>").value;
                var arrDatePickerDate = TaskdatepickerDate.split("-");
                var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                            var arrCurrentDate = CurrentDateDate.split("-");
                            var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                            if (dateDateCntrlr < dateCurrentDate) {
                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, Expiry Date should be greater than Current Date !.";
                    document.getElementById("<%=txtNewInsrncDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtNewInsrncDate.ClientID%>").focus();
                    ret = false;
                }

            }

            if (Number == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtNewInsrncNmbr.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtNewInsrncNmbr.ClientID%>").focus();
                ret = false;
            }


            if (ret == false) {
                CheckSubmitZero();

            }
            
            return ret;
        }



        function MoneyCheck(textboxid) {

            IncrmntConfrmCounter();
            var txtPerVal = document.getElementById(textboxid).value.split(',').join('');
            if (txtPerVal == "") {
                return false;
            }
            else {
                if (!isNaN(txtPerVal) == false) {
                    document.getElementById('' + textboxid + '').value = "";
                    return false;
                }
                else {
                    if (txtPerVal < 0) {
                        document.getElementById('' + textboxid + '').value = "";
                        return false;
                    }
                    var amt = parseFloat(txtPerVal);
                    var num = amt;
                    var n = 0;
                    // for floatting number adjustment from corp global

                    var FloatingValue = document.getElementById("<%=hiddenDecimalCountMoney.ClientID%>").value;
                        if (FloatingValue != "") {
                            var n = num.toFixed(FloatingValue);
                        }
                        document.getElementById('' + textboxid + '').value = addCommas(n);

                    }
                }
            return false;
        }
        function addCommas(nStr) {

            nStr += '';
            var x = nStr.split('.');
            var x1 = x[0];
            var x2 = x[1];
            //var a = document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value;
              //alert('hi'+a);
              if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "1") {

                  var rgx = /(\d+)(\d{7})/;
                  if (rgx.test(x1)) {
                      x1 = x1.replace(rgx, '$1' + ',' + '$2');
                  }
                  rgx = /(\d+)(\d{5})/;
                  if (rgx.test(x1)) {
                      x1 = x1.replace(rgx, '$1' + ',' + '$2');
                  }
                  rgx = /(\d+)(\d{3})/;
                  if (rgx.test(x1)) {
                      x1 = x1.replace(rgx, '$1' + ',' + '$2');
                  }
              }

              if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "2") {

                  var rgx = /(\d+)(\d{9})/;
                  if (rgx.test(x1)) {
                      x1 = x1.replace(rgx, '$1' + ',' + '$2');
                  }

                  rgx = /(\d+)(\d{6})/;
                  if (rgx.test(x1)) {
                      x1 = x1.replace(rgx, '$1' + ',' + '$2');
                  }
                  rgx = /(\d+)(\d{5})/;
                  if (rgx.test(x1)) {
                      x1 = x1.replace(rgx, '$1' + ',' + '$2');
                  }
                  rgx = /(\d+)(\d{3})/;
                  if (rgx.test(x1)) {
                      x1 = x1.replace(rgx, '$1' + ',' + '$2');
                  }
              }
              if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "3") {

                  var rgx = /(\d+)(\d{9})/;
                  if (rgx.test(x1)) {
                      x1 = x1.replace(rgx, '$1' + ',' + '$2');
                  }
                  rgx = /(\d+)(\d{6})/;
                  if (rgx.test(x1)) {
                      x1 = x1.replace(rgx, '$1' + ',' + '$2');
                  }
                  rgx = /(\d+)(\d{3})/;
                  if (rgx.test(x1)) {
                      x1 = x1.replace(rgx, '$1' + ',' + '$2');
                  }
              }




              if (isNaN(x2))
                  return x1;
              else
                  return x1 + "." + x2;
          }
        function isDecimalNumber(evt, textboxid) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            var txtPerVal = document.getElementById(textboxid).value;
            //enter
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

    </script>
         

    </asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:HiddenField ID="hiddenInsudate" runat="server" />
     <asp:HiddenField ID="hiddenPrmtdate" runat="server" />
     <asp:HiddenField ID="hiddenVehId" runat="server" />
    <asp:HiddenField ID="hiddenInsPrvdr" runat="server" />
    <asp:HiddenField ID="hiddenInsCovrgtyp" runat="server" />
    <asp:HiddenField ID="hiddenRoleAdd" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="hiddenRedirect" runat="server" />
    <asp:HiddenField ID="hiddenRedirectMode" runat="server" />
    <asp:HiddenField ID="hiddenPermitLabelName" runat="server" />
    <asp:HiddenField ID="hiddenDecimalCountMoney" runat="server" />

    <asp:HiddenField ID="hiddenPermitFileSize" runat="server" />
    <asp:HiddenField ID="hiddenPermitFile" runat="server" />
    <asp:HiddenField ID="hiddenPermitFileDeleted" runat="server" />
    <asp:HiddenField ID="hiddenInsuranceFile" runat="server" />
    <asp:HiddenField ID="hiddenInsuranceFileDeleted" runat="server" />

    <asp:HiddenField ID="hiddenFilePath" runat="server" />
    <asp:HiddenField ID="hiddenLeadActiveUser" runat="server" />
    <asp:HiddenField ID="hiddenFileCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenField2_FileUpload" runat="server" />
     <asp:HiddenField ID="hiddenEditAttchmnt" runat="server" />
      <asp:HiddenField ID="HiddenAtchmnt" runat="server" />
     <asp:HiddenField ID="HiddenFieldTR" runat="server" />
     <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
     <div class="cont_rght" style="width:99%;padding-top:0%">

         <div id="divMessageArea" style="display: none; margin:0px 0 13px;">
                 <img id="imgMessageArea" src="" >
                <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>
         <div id="divList" class="Previous"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:0%; top:31%;height:26.5px;cursor:pointer"></div>
          <div class="fillform" style="width:99%;">
            <div id="divCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>

              <%--for insurance renewal--%>

              <div id="divInsuranceContainer" runat="server" class="container">                     
              <div style="margin-top:2%; margin-left:1%;">



             <div class="eachform" style="width: 50%;">

                <asp:Label ID="lblVehicleNumber" style="padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;" runat="server">Registration Number</asp:Label>
                <asp:TextBox ID="txtVehicleNumber" class="form1" runat="server" MaxLength="100" Width="50%"  Style="height: 30px; text-transform: uppercase; "></asp:TextBox>

            </div>
          
           <div class="eachform" style="width: 47%;float:right;">

                <asp:Label ID="lblVehiclClass" style="padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left: 8%;" runat="server">Vehicle Class</asp:Label>
                <asp:TextBox ID="txtVehicleClass" class="form1" runat="server" MaxLength="100" Width="50%"  Style="height: 30px; text-transform: uppercase;margin-right: 1%;"></asp:TextBox>

            </div>
          




               <div class="eachform" style="width: 50%;">

               <asp:Label ID="lblOldNmbr" style="padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;" runat="server">Previous Insurance Number</asp:Label>
                <asp:TextBox ID="txtOldInsrncNumbr" class="form1" runat="server" MaxLength="100" Width="50%" Style="height: 30px;"></asp:TextBox>

            </div>

                   <div id="divNewInsNum" runat="server" class="eachform" style="width: 47%;float:right;">

                <asp:Label ID="lblNewNmbr" style="padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left:8%;" runat="server">New Insurance Number*</asp:Label>
                <asp:TextBox ID="txtNewInsrncNmbr" class="form1" runat="server" MaxLength="100" Width="50%" Style="height: 30px; margin-right: 1%;" ></asp:TextBox>

            </div>





                 <div class="eachform" style="width: 50%;">

               <asp:Label ID="lblOldInsDate" style="padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;" runat="server">Previous Insurance Date</asp:Label>
                <asp:TextBox ID="txtOldInsrncDate" class="form1" runat="server" MaxLength="100" Width="50%" Style="height: 30px; text-transform: uppercase; "></asp:TextBox>

            </div>

                   <div id="divInsDate" runat="server" class="eachform" style="width: 47%;float:right;margin-top: -3%;">
             <div id="datetimepickerFrom" class="input-append date" style="font-family: Calibri; width: 92%; height:37px;float:right;white-space: normal;">
                                <span style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left:0%;">New Insurance Date*</span>
                                <div style="float: right; width: 65%; margin-top:0%;">  
                                    
                               <asp:TextBox ID="txtNewInsrncDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width: 47%; margin-top:0%;  font-family: calibri; float: left;font-size:15px;margin-left:9%;" onkeydown="return isNumberDate(event);"></asp:TextBox>                                                                   
                                    <img class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style="height: 22px; float:left; cursor:pointer;margin-top: -10%;margin-left: 61%;" />

                                
                                   <script type="text/javascript"
                            src="../../../JavaScript/Date/JavaScriptDate1_8_3.js"></script>
                        
                        <script type="text/javascript"
                            src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                        </script>
                        <script type="text/javascript"
                            src="../../../JavaScript/Date/bootstrap-datepicker.js">
                        </script>
                        <script type="text/javascript"
                            src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js">
                        </script>
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#datetimepickerFrom').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,

                                startDate: new Date(),

                            });


                                </script>
                            </div>
                               </div> 
                       </div>






                   <div class="eachform" style="width:50%;">

                <asp:Label ID="lblInsurncPrvdrId" style="padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;" runat="server">Insurance Provider</asp:Label>
                <asp:TextBox ID="txtInsurncPrvdrid" class="form1" runat="server" MaxLength="20" Width="50%" Style="height: 30px; text-transform: uppercase;"></asp:TextBox>

            </div>
                  <div id="divNewInsurPrvdr" runat="server" class="eachform" style="width: 47%;float:right;margin-top: -3%;">

                <asp:Label ID="lblNwInsurncPrvdrId" style="padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left: -91%;" runat="server">New Insurance Provider*</asp:Label>
                <asp:DropDownList ID="ddlInsrncPrvdrId" CssClass="leads_field leads_field_dd dd2" style="width: 53% !important;height: 28px !important; margin-left: 46%;" runat="server"  autofocus="autofocus" autocorrect="off" autocomplete="off">      
                 </asp:DropDownList>

            </div>








                   <div class="eachform" style="width:50%;float:left">

                <asp:Label ID="lblOldInsuranceAmnt" style="padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;" runat="server">Previous Insurance Amount</asp:Label>
                <asp:TextBox ID="txtOldInsAmount" class="form1" runat="server" MaxLength="20" Width="50%" Style="height: 30px; text-transform: uppercase;"></asp:TextBox>

            </div>
             <div id="divInsureAmount" runat="server" class="eachform" style="width: 47%;float:right;margin-right:.5%; margin-top:0%;">

                <asp:Label ID="lblInsuranceAmnt" style="margin-left: 9%;padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;" runat="server">New Insurance Amount*</asp:Label>
                <asp:TextBox ID="txtNewInsuranceAmount" class="form1" runat="server" MaxLength="15" Width="50%" Style="height: 30px;text-align:right;" onkeydown="return isDecimalNumber(event,'cphMain_txtNewInsuranceAmount');" onblur="MoneyCheck('cphMain_txtNewInsuranceAmount');" ></asp:TextBox>

            </div>



              
                <div class="eachform" style="width:50%;">

                <asp:Label ID="lblOldCoverageType" style="padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;" runat="server">Insurance Coverage Type</asp:Label>
                <asp:TextBox ID="txtOldCoverageType" class="form1" runat="server" MaxLength="20" Width="50%" Style="height: 30px; text-transform: uppercase;"></asp:TextBox>

            </div>
                  <div id="divNewCoverageType" runat="server" class="eachform" style="width: 47%;float:right;margin-top: -2.5%;">

                <asp:Label ID="lblNewCoverageType" style="padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left: -91%;" runat="server">New  Coverage Type*</asp:Label>
                <asp:DropDownList ID="ddlNewCoverageType" CssClass="leads_field leads_field_dd dd2" style="width: 53% !important;height: 28px !important; margin-left: 46%;" runat="server"  autofocus="autofocus" autocorrect="off" autocomplete="off">      
                 </asp:DropDownList>

            </div>




                  <div class="eachform" style="width:50%;float:left">
                   <asp:Label ID="Label1" style="margin-left:0%;padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;" runat="server">Previous Insurance File*</asp:Label>
                   <div id="divOldImageDisplayInsur" runat="server" style="width: 53%;float: right;">
                    </div>
                  </div>
                  <div id="divInsImgUpload" style="display:none;width: 43%;margin-top: 0%;margin-right: 2%;float:right">
<%--                <h2 style="margin-top: 1%;float: left;margin-left: 4%;font-size: 17px;">Upload Document</h2>
                <label for="cphMain_FileUploadInsurance" class="custom-file-upload" style="margin-left:15.5%" tabindex="0">
                    <img src="/Images/Icons/cloud_upload.jpg" />Upload File</label>--%>
                <asp:FileUpload ID="FileUpload1"  runat="server" Style="height: 30px; display:none;" onchange="return ClearDivDisplayImageInsur()" Accept="all" />


<%--                <div id="div2" runat="server" style="float: right; width: 54%; height: 20px; margin-top: -1%;">
                    <div class="imgWrap">
                        <img id="ClearImgInsur" src="/Images/Icons/clear-image-green.png" alt="Clear" onclick="ClearImageInsur()" onmouseover="ImagePositionInsur('ClearImgInsur')"; style="cursor: pointer; float: right;" />
                        <p id="RemovePhotoInsur" class="imgDescription" style="color: white">Remove Selected File</p>
                    </div>
                   
                </div>--%>
               <%-- <asp:Label ID="LabelIns" runat="server" Text="No File Uploaded" Style="font-family: Calibri; font-size: medium;"></asp:Label>--%>
            </div> 
             <div id="divFileuploadScrollIns" style="margin-top:0%;float:right;margin-right:-3%; width:48%;max-height: 265px;">
                       <div class="leads_form_left" style="width: 100%;height: 135px;">
                        <div id="Div2" style="width: 88%; background-color: rgb(147, 164, 116); color: white; font-size: 17px; font-weight: bold; padding-bottom: 0.3%; padding-top: 0.3%; margin-bottom: -1%; padding-left: 1%;">Add Files</div>
                        &nbsp;&nbsp;

    <%--<input id="Button1" class="save" type="button" value="add" onclick="AddFileUpload()" />--%>

                         <div id="divInsTableFileUpload" style="overflow-y: auto;height: 94px;width: 89%;">
                        <table id="TableFileUploadContainerIns" style="width: 100%;">
                        </table>
                        </div>
                        <br />

                        <%--  <asp:Button ID="btnUpload" runat="server" 
                            Text="Upload" OnClick="btnUploadFile_Click" />--%>
                    </div>
               </div>     
                 


                  



                  <div class="eachform" style="margin-top:3%">
                <div class="subform" style="width: 48%;">
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return ValidateInsurance();"/>
                     <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Clear" OnClientClick="return AlertClearAll()" OnClick="btnCancel_Click"/>
               
                </div>
                </div>
                  </div>
                        </div>


              <%--for permit renewal--%>

               <div id="divPermitContainer" runat="server" class="container">   
                
                    <div style="margin-top:2%; margin-left:1%;">
             <div class="eachform" style="width: 50%;float:left;">

                <asp:Label ID="lblVehNUmberPer" style="padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;" runat="server">Registration Number</asp:Label>
                <asp:TextBox ID="txtVehNumberPer" class="form1" runat="server" MaxLength="100" Width="50%" Style="height: 30px; text-transform: uppercase; "></asp:TextBox>

            </div>
          
           <div class="eachform" style="width: 47%;float:right;">

                <asp:Label ID="lblVehicleClassPer" style="padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left: 8%;" runat="server">Vehicle Class</asp:Label>
                <asp:TextBox ID="txtVehicleClassPer" class="form1" runat="server" MaxLength="100" Width="50%" Style="height: 30px; text-transform: uppercase;margin-right: 1%;"></asp:TextBox>

            </div>
                   

             <%--<div class="eachform" style="width: 50%;float:left;">

               <asp:Label ID="lblOldPermitNum" style="padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;" runat="server">Old Permit Number</asp:Label>
                <asp:TextBox ID="txtOldPermitNum" class="form1" runat="server" MaxLength="100" Width="50%" Style="height: 30px; text-transform: uppercase; "></asp:TextBox>

            </div>--%>
           
          <div id="divPermitDate" runat="server" class="eachform" style="width: 47%;float:right;margin-top: 0%;">
               <div id="divDatePermitNew" class="input-append date" style="font-family: Calibri; width: 92%; height:37px;float:right;">
                                <%--<asp:Label ID="lbl"runat="server" style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left:14%;">New Insurance Date*</asp:Label>--%>
                   <span id="lblNewPrmtdate" runat="server" style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left:0%;">New Permit Date*</span>
                             <div style="float: left;margin-left:35.5%; width: 65%; margin-top:-5%;">     
                              <asp:TextBox ID="txtNewPerDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width: 47%; margin-top:0%;  font-family: calibri; float: left;font-size:15px;margin-left:9%;" onkeydown="return isNumberDate(event);" ></asp:TextBox>                                                                    
                             <img class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style="height: 22px; float:left; cursor:pointer;margin-top: -10%;margin-left: 61%;" />
                                  <script type="text/javascript"
                            src="../../../JavaScript/Date/JavaScriptDate1_8_3.js"></script>
                        
                        <script type="text/javascript"
                            src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                        </script>
                        <script type="text/javascript"
                            src="../../../JavaScript/Date/bootstrap-datepicker.js">
                        </script>
                        <script type="text/javascript"
                            src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js">
                        </script>
                        <script type="text/javascript">

                            var $noC = jQuery.noConflict();
                            $noC('#divDatePermitNew').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,

                                startDate: new Date(),

                            });

                                </script>
                            </div>
                               </div> 
           </div>
                   <%--<div id="divNewPermNum" runat="server" class="eachform" style="width: 47%;float:right;">

                <asp:Label ID="lblNewPermitNum" style="padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left:8%;" runat="server">New Permit Number*</asp:Label>
                <asp:TextBox ID="txtNewPermitNum" class="form1" runat="server" MaxLength="100" Width="50%" Style="height: 30px;text-transform:uppercase; margin-right: 1%; " ></asp:TextBox>

            </div>--%>

 
                                <%--<span style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;">Old Insurance Date*</span>--%>
              <div class="eachform" style="width: 50%;float:left">

               <asp:Label ID="lblOldPermitDate" style="padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;" runat="server">Old Permit Date</asp:Label>
                <asp:TextBox ID="txtOldPermitDate"  class="form1" runat="server" MaxLength="100"  Width="50%"  Style="height: 30px; text-transform: uppercase; "></asp:TextBox>

            </div>
              <div class="eachform" style="width: 50%;float:left">
                 <asp:Label ID="lblOldPermitFile" style="padding-top:1%;color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left:0%;" runat="server">New Permit Number*</asp:Label>
                  <div id="divOldImageDisplayPermit" runat="server" style="width: 53%;float: right;">
                  </div>
               </div>



            <div id="divFileuploadScroll" style="margin-top:-1%;float:right;margin-right:-3%; width:48%;max-height: 265px;">
                   <div class="leads_form_left" style="width: 100%;height: 135px;">
                        <div id="headingFileUploadVhclImage" style="width: 88%; background-color: rgb(147, 164, 116); color: white; font-size: 17px; font-weight: bold; padding-bottom: 0.3%; padding-top: 0.3%; margin-bottom: -1%; padding-left: 1%;">Add Files</div>
                        &nbsp;&nbsp;

    <%--<input id="Button1" class="save" type="button" value="add" onclick="AddFileUpload()" />--%>

                         <div id="divPrmmtTableFileUpload" style="overflow-y: auto;height: 94px;width: 89%;">
                        <table id="TableFileUploadContainer" style="width: 100%;">
                        </table>
                        </div>
                        <br />

                        <%--  <asp:Button ID="btnUpload" runat="server" 
                            Text="Upload" OnClick="btnUploadFile_Click" />--%>
                    </div>
               </div>



              




                <div class="eachform"  style="margin-top:3%">
                <div class="subform" style="width: 48%;">
                    <asp:Button ID="SavePermit" runat="server" class="save" Text="Save" OnClick="SavePermit_Click" OnClientClick="return ValidatePermit();"/>
                     <asp:Button ID="CancelPermit" runat="server" class="cancel" Text="Clear" OnClientClick="return AlertClearAll()" OnClick="CancelPermit_Click"/>
               
                </div>
                </div>

                      </div>


              
          </div>
         </div>
         </div>
   

  </asp:Content>