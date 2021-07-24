<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage_Compzit_GMS.master" AutoEventWireup="true" CodeFile="gen_Insurance_Master.aspx.cs" Inherits="GMS_GMS_Master_gen_Insurance_Master_gen_Insurance_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <style>

        .cont_rght {
            width: 98%;
        }

      #divGreySection {
          background-color: #efefef;
          border: 1px solid;
          border-color: #cfcfcf;
          padding: 15px;
          height: auto;
      }

      #divAwardedContainer {
          width: 46%;
          float: right;
          margin-top: -17%;
          margin-left: 3%;
          border: 1px solid;
          height: auto;
          border-color: #11839c;
          background-color: white;
          min-height: 180px;
      }

      #divMessageArea {
          border-radius: 8px;
          background: #fff;
          padding: 10px;
          font-weight: bold;
          text-align: center;
          font-size: 17px;
          color: #53844E;
          margin-top: 0%;
          font-family: Calibri;
          border: 2px solid #53844E;
      }

      #imgMessageArea {
          float: left;
          margin-left: 1%;
          margin-top: -0.2%;
      }

        .eachform h2 {
            margin: 8px 0 6px;
        }

       .form1 {
              width: 232px;
              height: 31px;
              padding: 0px 8px;
              border: 1px solid #cfcccc;
              float: right;
              color: #000;
              font-size: 13px;
          }
          .form11
          {
              width: 232px;
              height: 26px;
              padding: 0px 8px;
              border: 1px solid #cfcccc;
              float: right;
              color: #000;
              font-size: 13px;
          }

        input[type="radio"] {
            display: inline-block;
        }

        .imgDescription {
            position: absolute;
            background: rgb(154, 163, 138);
            visibility: hidden;
            opacity: 0;
            padding: 0.1%;
            font-family: Calibri;
        }
        .imgWrap:hover .imgDescription {
            visibility: visible;
            opacity: 1;
        }

        .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            width: 218px;
            border: 1px solid #B0BECA;
            max-height: 135px;
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

       /*for file upload*/
        input[type="file"] {
            position: relative;
            z-index: 1;
            margin-left: -78px;
            display: none;
        }

        .AnchorAttachmntEdit, .AnchorAttachmntEdit:hover, .AnchorAttachmntEdit:focus {
            color: #1884c7;
            font-family: OpenSans Regular;
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

         #scrollToTop {
             cursor: pointer;
             background-color: #97c83a;
             display: inline-block;
             height: 40px;
             width: 40px;
             color: #fff;
             font-size: 16pt;
             text-align: center;
             text-decoration: none;
             line-height: 40px;
             border-radius: 35px;
         }

         .textareaa {
             height: 28px;
             padding: 0px 4px;
             border: 1px solid #cfcccc;
             float: right;
             color: #000;
             font-family: Calibri;
             font-size: 15px;
             border-radius: 0px;
             width: 282px;
             background-color: #e3e3e3;
             cursor: auto;
         }

        #DivTemplateContainer {
            width: 90%;
            min-height: 200px;
            float: left;
            margin-left: 5%;
            border: 1px solid;
            border-color: #0b9aab;
            background: #fffcf2;
        }
        .ClearDur {
            font-family: Calibri;
            font-size: 12px;
            color: #45ff00;
            padding: 5px 18px 5px;
            margin: 0 11px 6px 2px;
            line-height: 1;
            font-weight: normal;
            float: left;
            background: #1280a4;
            border: none;
            border-radius: 2px;
            cursor: pointer;
            text-transform: uppercase;
        }

        .clsSmallDiv {
            border: 1px solid;
            padding: 2px;
            border-color: #229ed8;
        }
        .fillform {
            background-color: #efefef;
    border: 1px solid;
    border-color: #cfcfcf;
    padding: 15px;
    height: auto;
        }

    </style>

        <script src="/JavaScript/jquery-1.8.3.min.js"></script>

     <script src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="../../../css/Autocomplete/jquery-ui.css" rel="stylesheet" />
   
       <script>
           var $au = jQuery.noConflict();

           (function ($au) {
               $au(function () {
                   $au('#cphMain_ddlProjects').selectToAutocomplete1Letter();
                   $au('#cphMain_ddlExistingEmp').selectToAutocomplete1Letter();
                   $au('#cphMain_ddlInsurncPrvdr').selectToAutocomplete1Letter();

                   $au("div#divddlInsurncPrvdr input.ui-autocomplete-input").focus();
                   $au("div#divddlInsurncPrvdr input.ui-autocomplete-input").select();
               });
           })(jQuery);
      </script>

        <script>

            function CbxChange() {
                IncrmntConfrmCounter();
                if (document.getElementById("<%=cbxExistingEmployee.ClientID%>").checked == false) {
                    document.getElementById("divExistingEmp").style.display = "none";
                    document.getElementById("divNewEmp").style.display = "";
                    document.getElementById("<%=ddlExistingEmp.ClientID%>").value = "--SELECT EMPLOYEE--";
                    document.getElementById("<%=txtCntctMail.ClientID%>").value = "";
                }
                else {
                    $noC = jQuery.noConflict();
                    document.getElementById("divNewEmp").style.display = "none";
                    document.getElementById("divExistingEmp").style.display = "";
                    document.getElementById("<%=ddlExistingEmp.ClientID%>").value = "--SELECT EMPLOYEE--";
                }
                return false;
            }

            function RadioopenClick() {
                IncrmntConfrmCounter();
                document.getElementById("<%=img1.ClientID%>").disabled = true;
                document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;
                document.getElementById("<%=img1.ClientID%>").style.pointerEvents = "none";
            }

            function RadioLimitedClick() {
                IncrmntConfrmCounter();
                document.getElementById("<%=img1.ClientID%>").disabled = false;
                document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = false;
                document.getElementById("<%=img1.ClientID%>").style.pointerEvents = "";
            }

        function NewProjectLoad() {
            var $noC = jQuery.noConflict();
            if (confirm('Are you sure you want to add new project?') == true) {

                var PrjctNme = '';

                var nWindow = window.open('/Master/gen_Projects/gen_Projects.aspx?PRFG=' + PrjctNme + '&RFGP=RFG', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                nWindow.focus();
            }
            return false;
        }

        function GetValueFromChildProject(myVal) {
            if (myVal != '') {
                PostbackFunProject(myVal);
            }
        }

        function PostbackFunProject(myValPrj) {
            clearhidd();
            document.getElementById("<%=hiddenNewProjectId.ClientID%>").value = myValPrj;
            __doPostBack("<%=btnNewProject.UniqueID %>", "");
            return false;
        }

        function addCommas() {

            nStr = document.getElementById("<%=txtAmount.ClientID%>").value;
            nStr += '';
            var x = nStr.split('.');
            var x1 = x[0];
            var x2 = x[1];

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
                document.getElementById("<%=txtAmount.ClientID%>").value = x1;
                //return x1;
            else
                document.getElementById("<%=txtAmount.ClientID%>").value = x1 + "." + x2;
            // return x1 + "." + x2;
            document.getElementById("<%=HiddenFieldAmount.ClientID%>").value = document.getElementById("<%=txtAmount.ClientID%>").value;
        }

    </script>



    <script>
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }

        function ConfirmMessage() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href = "gen_Insurance_Master_List.aspx";
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_Insurance_Master_List.aspx";

            }
        }


        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            localStorage.clear();

            if (document.getElementById("<%=cbxExistingEmployee.ClientID%>").checked == false) {
                document.getElementById("divExistingEmp").style.display = "none";
                document.getElementById("divNewEmp").style.display = "";
            }
            else {
                document.getElementById("divNewEmp").style.display = "none";
                document.getElementById("divExistingEmp").style.display = "";
            }

            if (document.getElementById("<%=radioLimited.ClientID%>").checked == true) {

                document.getElementById("<%=img1.ClientID%>").disabled = false;
                document.getElementById("<%=img1.ClientID%>").style.pointerEvents = "";

                if (document.getElementById("<%=HiddenGuarStatus.ClientID%>").value == "2") {
                    document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;
                    document.getElementById("<%=img1.ClientID%>").disabled = true;
                    document.getElementById("<%=txtAmount.ClientID%>").disabled = true;
                    document.getElementById("<%=img1.ClientID%>").style.pointerEvents = "none";
                }
                if (document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
                    document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = false;
                    document.getElementById("<%=img1.ClientID%>").disabled = false;
                    document.getElementById("<%=txtAmount.ClientID%>").disabled = false;
                    document.getElementById("<%=img1.ClientID%>").style.pointerEvents = "";
                }
                else {
                    if (document.getElementById("<%=HiddenFieldUpdate.ClientID%>").value == "1") {
                        document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = false;
                        document.getElementById("<%=img1.ClientID%>").disabled = false;
                        document.getElementById("<%=img1.ClientID%>").style.pointerEvents = "";
                    }
                    else {
                        document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;
                        document.getElementById("<%=img1.ClientID%>").disabled = true;
                        document.getElementById("<%=img1.ClientID%>").style.pointerEvents = "none";
                    }
                }
            }
            else if (document.getElementById("<%=radioOpen.ClientID%>").checked == true) {

                document.getElementById("<%=img1.ClientID%>").disabled = true;
                document.getElementById("<%=img1.ClientID%>").style.pointerEvents = "none";
                document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;

                if (document.getElementById("<%=HiddenGuarStatus.ClientID%>").value == "2") {
                    document.getElementById("<%=txtAmount.ClientID%>").disabled = true;
                }
                if (document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
                    document.getElementById("<%=txtAmount.ClientID%>").disabled = false;
                    document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;
                    document.getElementById("<%=img1.ClientID%>").disabled = true;
                    document.getElementById("<%=img1.ClientID%>").style.pointerEvents = "none";
                }
                else {
                    document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;
                    document.getElementById("<%=img1.ClientID%>").disabled = true;
                    document.getElementById("<%=img1.ClientID%>").style.pointerEvents = "none";
                }
            }

            if (document.getElementById("<%=HiddenDuplictnchk.ClientID%>").value == "1") {
                document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = false;
                document.getElementById("<%=img1.ClientID%>").disabled = false;
                document.getElementById("<%=img1.ClientID%>").style.pointerEvents = "";
                TextDateChange();
            }

            AmountChecking('cphMain_txtAmount');

            addCommas();

            //----attachmnt----

            if (document.getElementById("<%=HiddenFieldUpdate.ClientID%>").value == "1" || document.getElementById("<%=HiddenFieldView.ClientID%>").value == "1" || document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {

                if (document.getElementById("<%=hiddenEditAttchmnt.ClientID%>").value != "") {

                    var EditAttchmnt = document.getElementById("<%=hiddenEditAttchmnt.ClientID%>").value;

                    var findAtt2 = '\\"\\[';
                    var reAtt2 = new RegExp(findAtt2, 'g');
                    var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                    var findAtt3 = '\\]\\"';
                    var reAtt3 = new RegExp(findAtt3, 'g');
                    var resAtt3 = resAtt2.replace(reAtt3, '\]');
                    var jsonAtt = $noCon.parseJSON(resAtt3);
                    for (var key in jsonAtt) {
                        if (jsonAtt.hasOwnProperty(key)) {
                            if (jsonAtt[key].PictureAttchmntDtlId != "") {

                                AddAttachment(jsonAtt[key].PictureAttchmntDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);
                            }
                        }
                    }

                    if (document.getElementById("<%=HiddenFieldView.ClientID%>").value != "1") {
                        AddFileUpload();
                    }

                    document.getElementById("<%=hiddenValueChangeNtfr.ClientID%>").value = "0";
                    if (document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
                        document.getElementById("divfleupld").style.display = "block";
                        AddFileUpload();
                    }

                }
                else {
                    if (document.getElementById("<%=HiddenFieldView.ClientID%>").value == "1") {
                        if (document.getElementById("<%=HiddenRenew.ClientID%>").value != "1") {
                            document.getElementById("divfleupld").style.display = "none";
                        }
                        else {
                            AddFileUpload();
                        }
                    }
                    else {
                        AddFileUpload();
                    }
                }
            }
            else {
                if (document.getElementById("<%=HiddenFieldView.ClientID%>").value != "1") {
                    AddFileUpload();
                }
                if (document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
                    AddFileUpload();
                }
            }

            //----notification template----


            if (document.getElementById("<%=hiddenTemplateLoadingMode.ClientID%>").value == "FromTemp") {

                if (document.getElementById("<%=hiddenEachTemplateDetail.ClientID%>").value != 0) {
                    var EditEachTemplate = document.getElementById("<%=hiddenEachTemplateDetail.ClientID%>").value;
                    var findAtt2 = '\\"\\[';
                    var reAtt2 = new RegExp(findAtt2, 'g');
                    var resAtt2 = EditEachTemplate.replace(reAtt2, '\[');

                    var findAtt3 = '\\]\\"';
                    var reAtt3 = new RegExp(findAtt3, 'g');
                    var resAtt3 = resAtt2.replace(reAtt3, '\]');

                    var jsonAtt = $noCon.parseJSON(resAtt3);
                    for (var key in jsonAtt) {
                        if (jsonAtt.hasOwnProperty(key)) {

                            if (jsonAtt[key].TempDetailId != "") {

                                EditMoreEachTemplate(jsonAtt[key].TempDetailId, jsonAtt[key].NotifyMod, jsonAtt[key].NotifyVia, jsonAtt[key].NotifyDur);

                            }
                        }
                    }
                }
                else {

                    addMoreEachTemplate();
                }
            }
            else if (document.getElementById("<%=hiddenTemplateLoadingMode.ClientID%>").value == "FromBnk") {


                if (document.getElementById("<%=hiddenEachTemplateDetail.ClientID%>").value != 0) {
                    var EditEachTemplate = document.getElementById("<%=hiddenEachTemplateDetail.ClientID%>").value;
                    var findAtt2 = '\\"\\[';
                    var reAtt2 = new RegExp(findAtt2, 'g');
                    var resAtt2 = EditEachTemplate.replace(reAtt2, '\[');

                    var findAtt3 = '\\]\\"';
                    var reAtt3 = new RegExp(findAtt3, 'g');
                    var resAtt3 = resAtt2.replace(reAtt3, '\]');

                    var jsonAtt = $noCon.parseJSON(resAtt3);
                    for (var key in jsonAtt) {
                        if (jsonAtt.hasOwnProperty(key)) {

                            if (jsonAtt[key].TempDetailId != "") {


                                EditMoreEachTemplateBnk(jsonAtt[key].TempDetailId, jsonAtt[key].NotifyMod, jsonAtt[key].NotifyVia, jsonAtt[key].NotifyDur);

                            }
                        }
                    }

                }
                else {

                    addMoreEachTemplate();
                }
            }
            if (document.getElementById("<%=hiddenEachTemplateDetail.ClientID%>").value == 0) {
                clearhidd();
            }
        });

        function clearhidd() {
            document.getElementById("<%=hiddenDivisionddlData.ClientID%>").value = 0;
            document.getElementById("<%=hiddenDesignationddlData.ClientID%>").value = 0;
            document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value = 0;
        }


        function TextDateChange() {

            var chk = document.getElementById("<%=txtOpngDate.ClientID%>").value;

            if (document.getElementById("<%=txtOpngDate.ClientID%>").value != "" && document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value != "") {

                var OPeningDate = document.getElementById("<%=txtOpngDate.ClientID%>").value;
                var arrOPeningDate = OPeningDate.split("-");
                var dateOPeningDate = new Date(arrOPeningDate[2], arrOPeningDate[1] - 1, arrOPeningDate[0]);

                var ExpireDate = document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value.trim();
                var arrDateExpireDate = ExpireDate.split("-");
                var datearrDateExpireDate = new Date(arrDateExpireDate[2], arrDateExpireDate[1] - 1, arrDateExpireDate[0]);

                var timeDiff = Math.abs(datearrDateExpireDate.getTime() - dateOPeningDate.getTime());
                var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
                diffDays = diffDays + 1;
                document.getElementById("<%=txtValidity.ClientID%>").value = diffDays;
                document.getElementById("<%=HiddenTextValidty.ClientID%>").value = diffDays;
                document.getElementById("<%=HiddenValidatedays.ClientID%>").value = diffDays;
            }
        }


    </script>


    <script>

        //----------------for file upload----------------

        var Filecounter = 0;

        function AddFileUpload() {

            var FrecRow = '<tr id="FilerowId_' + Filecounter + '" >';

            var labelForStyle = '<label  for="file' + Filecounter + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
            var tdInner = labelForStyle + '<input   id="file' + Filecounter + '" name = "file' + Filecounter + '" type="file" onchange="ChangeFile(\'' + Filecounter + '\')" accept="image/*,.pdf,.jpeg,.jpg,.png"/>';

            FrecRow += '<td style="width:22%;border:none;padding-left: 3%;" >' + tdInner + '</td>';

            FrecRow += '<td style="font-family: Calibri;border-right:none;width: 37%;word-break: break-all;" id="filePath' + Filecounter + '"  ></td  >';

            FrecRow += '<td style="width: 23%;border:none;" > <input   id="textbx' + Filecounter + '" name = "textbx' + Filecounter + '" type="text" class="form1" placeholder="Caption"  MaxLength="100" onkeypress="return isTag(event);" onkeydown="return DisableEnter(event);" onfocus="prevValueChk(\'' + Filecounter + '\');"  onblur="LinkChangeFile(\'' + Filecounter + '\',event);"  style="text-transform:uppercase;" /> </td>';

            FrecRow += '<td id="FileIndvlAddMoreRow' + Filecounter + '"  style="width: 1.5%;border:none; padding-left: 4px;"> <input type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFiles(\'' + Filecounter + '\');" style="  cursor: pointer;"></td>';
            FrecRow += '<td style="width: 1.5%;border:none; padding-left: 1px;"><input type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUpload(\'' + Filecounter + '\');"    style=" cursor: pointer;" ></td><br/>';


            FrecRow += ' <td id="FileInx' + Filecounter + '" style="display: none;" ></td>';
            FrecRow += '<td id="FileSave' + Filecounter + '" style="display: none;"></td>';
            FrecRow += '<td id="FileEvt' + Filecounter + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId' + Filecounter + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName' + Filecounter + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadContainer').append(FrecRow);

            document.getElementById('filePath' + Filecounter).innerHTML = 'No File Selected';

            $('#divfileupl').scrollTop($('#divfileupl')[0].scrollHeight);
            Filecounter++;

        }


        function AddAttachment(editTransDtlId, EditFileName, EditActualFileName, EditDescrptn) {

            var FrecRow = '<tr id="FilerowId_' + Filecounter + '" >';

            var labelForStyle = '<label  for="file' + Filecounter + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
            var tdInner = labelForStyle + '<input   id="file' + Filecounter + '" name = "file' + Filecounter + '" type="file" onchange="ChangeFile(\'' + Filecounter + '\')" />';

            FrecRow += '<td style="width:22%;border:none;padding-left: 3%;display:none;" >' + tdInner + '</td>';


            var tdFileNameEdit = '<a class="AnchorAttachmntEdit" style="word-wrap: break-word;" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

            FrecRow += '<td colspan="2" id="filePath' + Filecounter + '" style="font-family: Calibri;;border-right:none;border-bottom: 1px dotted rgb(205, 237, 196);word-break: break-all;"' + '  ><div style="width: 93%;float: right;">' + tdFileNameEdit + '</div></td >';

            FrecRow += '<td style="width: 23%;border:none;" > <input disabled="true"  id="textbx' + Filecounter + '" name = "textbx' + Filecounter + '" value="' + EditDescrptn + '" type="text" class="form1" placeholder="Caption"  MaxLength="100" onkeypress="return isTag(event);" onkeydown="return DisableEnter(event);" onfocus="prevValueChk(\'' + Filecounter + '\');"  onblur="LinkChangeFile(\'' + Filecounter + '\',event);"  style="text-transform:uppercase;" /> </td>';

            FrecRow += '<td id="FileIndvlAddMoreRow' + Filecounter + '"  style="width: 1.5%; padding-left: 4px;border:none;"> <input type="image"  class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFiles(\'' + Filecounter + '\');" style="  cursor: pointer;"></td>';
            FrecRow += '<td style="width: 1.5%; padding-left: 1px;border:none;"><input type="image" AutoPostBack="true" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete" onclick = "return RemoveFileUpload(\'' + Filecounter + '\');" style=" cursor: pointer;" ></td>';

            FrecRow += ' <td id="FileInx' + Filecounter + '" style="display: none;" ></td>';
            FrecRow += '<td id="FileSave' + Filecounter + '" style="display: none;"></td>';
            FrecRow += '<td id="FileEvt' + Filecounter + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId' + Filecounter + '" style="display: none;">' + editTransDtlId + '</td>';
            FrecRow += '<td id="DbFileName' + Filecounter + '" style="display: none;">' + EditFileName + '</td>';

            FrecRow += '</tr>';


            jQuery('#TableFileUploadContainer').append(FrecRow);


            document.getElementById("FileInx" + Filecounter).innerHTML = Filecounter;
            document.getElementById("FileIndvlAddMoreRow" + Filecounter).style.opacity = "0.3";

            FileLocalStorageAdd(Filecounter);
            Filecounter++;

        }

        function ChangeFile(x) {
            if (ClearDivDisplayImage(x)) {

                IncrmntConfrmCounter();
                if (document.getElementById('file' + x).value != "") {
                    document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;

                    var tbClientImageValidation = localStorage.getItem("tbClientImageValidation");//Retrieve the stored data

                    tbClientImageValidation = JSON.parse(tbClientImageValidation);
                    if (tbClientImageValidation == null) //If there is no data, initialize an empty array
                        tbClientImageValidation = [];
                    var $addFile = jQuery.noConflict();
                    var client = JSON.stringify({
                        ROWID: "" + x + "",

                    });


                    if (client != "") {

                        tbClientImageValidation.push(client);
                        localStorage.setItem("tbClientImageValidation", JSON.stringify(tbClientImageValidation));

                        $addFile("#cphMain_HiddenFieldValidation").val(JSON.stringify(tbClientImageValidation));

                    }
                    else {
                        document.getElementById('filePath' + x).innerHTML = 'No File Uploaded';


                    }
                    var SavedorNot = document.getElementById("FileSave" + x).innerHTML;

                    if (SavedorNot == "saved") {
                        var row_index = jQuery('#FilerowId_' + x).index();
                    }
                    else {
                    }
                }


            }
        }
        function prevValueChk(x) {

            document.getElementById("<%=hiddenFieldPrevValueChk.ClientID%>").value = document.getElementById('textbx' + x).value;
        }

        function LinkChangeFile(x, y) {

            if (isTag(y)) {


                document.getElementById("file" + x).style.borderColor = "";

                if (document.getElementById('textbx' + x).value != "") {

                    var prevtxtValue = document.getElementById("<%=hiddenFieldPrevValueChk.ClientID%>").value;
                    var vartxtbox = document.getElementById('textbx' + x).value;

                    IncrmntConfrmCounter();

                    if (prevtxtValue != vartxtbox) {

                        var SavedorNot = document.getElementById("FileSave" + x).innerHTML;

                        if (SavedorNot == "saved") {
                            var row_index = jQuery('#FilerowId_' + x).index();


                            FileLocalStorageEdit(x, row_index);
                        }
                        else {


                            FileLocalStorageAdd(x);
                        }
                    }
                    document.getElementById("<%=hiddenValueChangeNtfr.ClientID%>").value = "1";

                }
            }
            else {


            }

        }

        function FileLocalStorageAdd(x) {

            var tbClientPicLinkUpload = localStorage.getItem("tbClientPicLinkUpload");//Retrieve the stored data
            var tbClientPictureUpload = localStorage.getItem("tbClientPictureUpload");//Retrieve the stored data

            tbClientPictureUpload = JSON.parse(tbClientPictureUpload); //Converts string to object
            tbClientPicLinkUpload = JSON.parse(tbClientPicLinkUpload); //Converts string to object

            if (tbClientPictureUpload == null) //If there is no data, initialize an empty array
                tbClientPictureUpload = [];

            if (tbClientPicLinkUpload == null) //If there is no data, initialize an empty array
                tbClientPicLinkUpload = [];

            // var Linktxt = document.getElementById("textbx" + x).innerHTML;


            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;

            if (Fevt == 'INS') {

                var $addFile = jQuery.noConflict();

                var client = JSON.stringify({

                    ROWID: "" + x + "",
                    //   FILEPATH: "" + FilePath + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"

                });

                var clientLink = JSON.stringify({
                    ROWID: "" + x + "",
                    // FILEPATH: "" + FilePath + "",
                    EVTACTION: "" + Fevt + "",
                    // LNKTXT: "" + Linktxt + "",

                    DTLID: "0"
                });

            }
            else if (Fevt == 'UPD') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    //   FILEPATH: "" + FilePath + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });

                var clientLink = JSON.stringify({
                    ROWID: "" + x + "",
                    // FILEPATH: "" + FilePath + "",
                    EVTACTION: "" + Fevt + "",
                    //LNKTXT: "" + Linktxt + "",

                    DTLID: "" + FdetailId + ""

                });
            }


            tbClientPictureUpload.push(client);
            localStorage.setItem("tbClientPictureUpload", JSON.stringify(tbClientPictureUpload));

            $addFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPictureUpload));
            if (clientLink != "" && clientLink != null) {
                tbClientPicLinkUpload.push(clientLink);
                localStorage.setItem("tbClientPicLinkUpload", JSON.stringify(tbClientPicLinkUpload));
                $addFile("#cphMain_HiddenField2_FileUploadLnk").val(JSON.stringify(tbClientPicLinkUpload));

            }

            document.getElementById("FileSave" + x).innerHTML = "saved";


            return true;

        }

        function FileLocalStorageEdit(x, row_index) {
            var tbClientPicLinkUpload = localStorage.getItem("tbClientPicLinkUpload");
            var tbClientPictureUpload = localStorage.getItem("tbClientPictureUpload");//Retrieve the stored data

            tbClientPictureUpload = JSON.parse(tbClientPictureUpload); //Converts string to object
            tbClientPicLinkUpload = JSON.parse(tbClientPicLinkUpload);

            if (tbClientPictureUpload == null) //If there is no data, initialize an empty array
                tbClientPictureUpload = [];

            if (tbClientPicLinkUpload == null) //If there is no data, initialize an empty array
                tbClientPicLinkUpload = [];

            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

            var Fevt = document.getElementById("FileEvt" + x).innerHTML;

            if (Fevt == 'INS') {

                var $FileE = jQuery.noConflict();
                tbClientPictureUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    //     FILEPATH: "" + FilePath + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"
                });//Alter the selected item on the table
                tbClientPicLinkUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    // FILEPATH: "" + FilePath + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"

                });

            }
            else {

                var $FileE = jQuery.noConflict();
                tbClientPictureUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    //   FILEPATH: "" + FilePath + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });//Alter the selected item on the table

                tbClientPicLinkUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    // FILEPATH: "" + FilePath + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });



            }



            localStorage.setItem("tbClientPictureUpload", JSON.stringify(tbClientPictureUpload));
            $FileE("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPictureUpload));
            localStorage.setItem("tbClientPicLinkUpload", JSON.stringify(tbClientPicLinkUpload));
            $addFile("#cphMain_HiddenField2_FileUploadLnk").val(JSON.stringify(tbClientPicLinkUpload));



            return true;
        }

        

        function CheckaddMoreRowsIndividualFiles(x) {

            var check = document.getElementById("FileInx" + x).innerHTML;
            if (check == "") {

                var Fevt = document.getElementById("FileEvt" + x).innerHTML;

                if (Fevt != 'UPD') {

                    if (CheckFileUploaded(x) == true) {

                        document.getElementById("FileInx" + x).innerHTML = x;
                        document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";

                        if (document.getElementById("<%=HiddenFieldView.ClientID%>").value != "1") {
                            AddFileUpload();
                        }
                        else if (document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
                            AddFileUpload();
                        }


                        return false;
                    }
                }
                else {

                    document.getElementById("FileInx" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                    if (document.getElementById("<%=HiddenFieldView.ClientID%>").value != "1") {
                        AddFileUpload();
                    }
                    else if (document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
                        AddFileUpload();
                    }
                    return false;
                }
            }
            return false;

        }

        function CheckFileUploaded(x) {

            if (document.getElementById('file' + x).value != "") {

                return true;
            }
            else {

                return false;
            }

            return false;
        }

        function RemoveFileUpload(removeNum) {


            var ret = true;
            if (document.getElementById("<%=HiddenFieldView.ClientID%>").value != "1" || document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
                if (confirm("Are you sure you want to delete selected row?")) {

                    var Filerow_index = jQuery('#FilerowId_' + removeNum).index();

                    FileLocalStorageDelete(Filerow_index, removeNum);
                    jQuery('#FilerowId_' + removeNum).remove();



                    var TableFileRowCount = document.getElementById("TableFileUploadContainer").rows.length;


                    if (TableFileRowCount != 0) {
                        var idlast = $('#TableFileUploadContainer tr:last').attr('id');
                        //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                        //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                        if (idlast != "") {
                            var res = idlast.split("_");

                            document.getElementById("FileInx" + res[1]).innerHTML = "";
                            document.getElementById("FileIndvlAddMoreRow" + res[1]).style.opacity = "1";

                            ret = true;
                        }

                    }
                    else {

                        AddFileUpload();

                        ret = true;

                    }

                }
                else {

                    ret = false;
                }
            }

            else {
                ret = false;
            }

            document.getElementById("<%=hiddenValueChangeNtfr.ClientID%>").value = "1"

            return ret;

        }

        function FileLocalStorageDelete(row_index, x) {

            var $DelFile = jQuery.noConflict();
            var tbClientPictureUpload = localStorage.getItem("tbClientPictureUpload");//Retrieve the stored data
            var tbClientPicLinkUpload = localStorage.getItem("tbClientPicLinkUpload");

            tbClientPictureUpload = JSON.parse(tbClientPictureUpload); //Converts string to object
            tbClientPicLinkUpload = JSON.parse(tbClientPicLinkUpload);
            if (tbClientPictureUpload == null) //If there is no data, initialize an empty array
                tbClientPictureUpload = [];

            if (tbClientPicLinkUpload == null) //If there is no data, initialize an empty array
                tbClientPicLinkUpload = [];

            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            for (var i = 0; i < tbClientPictureUpload.length; i++) {

                var rowid = tbClientPictureUpload[i];
                rowid = rowid.split(",");
                rowid = rowid[0];
                rowid = rowid.split(":");
                rowid = rowid[1];
                rowid = rowid.replace(/"/g, "");


                if (rowid == x) {

                    tbClientPictureUpload.splice(i, 1);

                    break;
                }

            }

            // tbClientPictureUpload.splice(row_index, 1);
            localStorage.setItem("tbClientPictureUpload", JSON.stringify(tbClientPictureUpload));
            $DelFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPictureUpload));
            var hidd = document.getElementById("<%=HiddenField2_FileUploadLnk.ClientID%>").value;


            for (var i = 0; i < tbClientPicLinkUpload.length; i++) {
                var rowid = tbClientPicLinkUpload[i];
                rowid = rowid.split(",");
                rowid = rowid[0];
                rowid = rowid.split(":");
                rowid = rowid[1];
                rowid = rowid.replace(/"/g, "");


                if (rowid == x) {

                    tbClientPicLinkUpload.splice(i, 1);

                    break;
                }
            }

            // tbClientPicLinkUpload.splice(row_index, 1);
            localStorage.setItem("tbClientPicLinkUpload", JSON.stringify(tbClientPicLinkUpload));
            $DelFile("#cphMain_HiddenField2_FileUploadLnk").val(JSON.stringify(tbClientPicLinkUpload));
            var hiddn = document.getElementById("<%=HiddenField2_FileUploadLnk.ClientID%>").value;

            var Fevt = document.getElementById("FileEvt" + x).innerHTML;

            if (Fevt == 'UPD') {
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

                if (FdetailId != '') {

                    DeleteFileLSTORAGEAddFile(x);
                }

            }

        }

        function DeleteFileLSTORAGEAddFile(x) {


            var tbClientPictureFileCancel = localStorage.getItem("tbClientPictureFileCancel");//Retrieve the stored data

            tbClientPictureFileCancel = JSON.parse(tbClientPictureFileCancel); //Converts string to object

            if (tbClientPictureFileCancel == null) //If there is no data, initialize an empty array
                tbClientPictureFileCancel = [];


            var FileName = document.getElementById("DbFileName" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;



            var $addFile = jQuery.noConflict();
            var client = JSON.stringify({
                ROWID: "" + x + "",
                FILENAME: "" + FileName + "",
                // EVTACTION: "" + Fevt + "",
                DTLID: "" + FdetailId + ""
            });



            if (client != "") {

                tbClientPictureFileCancel.push(client);
                localStorage.setItem("tbClientPictureFileCancel", JSON.stringify(tbClientPictureFileCancel));

                $addFile("#cphMain_hiddenFileCanclDtlId").val(JSON.stringify(tbClientPictureFileCancel));

                ret = true;
            }

            return ret;

        }

        

        function CheckValidation(x) {

            if (document.getElementById('file' + x) != undefined) {


                if (document.getElementById('file' + x).value != "" && document.getElementById('textbx' + x).value != "") {

                    return true;
                }
                else {
                    if (document.getElementById('file' + x).value != "") {
                        if (document.getElementById('textbx' + x).value == "") {
                            document.getElementById('textbx' + x).style.borderColor = "RED";
                            document.getElementById('textbx' + x).focus();
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        }
                    }


                    return false;
                }
            }

            return true;
        }

        function ClearDivDisplayImage(x) {

            var fuData = document.getElementById('file' + x);
            var FileUploadPath = fuData.value;
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

            if (Extension == "png" || Extension == "pdf" || Extension == "jpeg" || Extension == "jpg") {


                return true;

            }
            else {
                document.getElementById('file' + x).value = "";
                document.getElementById('filePath' + x).innerHTML = 'No File Selected';
                alert("The specified file could not be uploaded. Image type not supported. Allowed types are png, jpeg, gif");
                return false;
            }
        }

    </script>


    <script>

        //----------------for notification template-----------------

        var $noC = jQuery.noConflict();
        var EachTemp = 0;

        
        function EditMoreEachTemplate(TempDetailId, NotifyMod, NotifyVia, NotifyDur) {//default

            EachTemp++;

            var recRow = '<tr id="TemplateRowId_' + EachTemp + ' >';

            recRow = '<div id=\"divEachTemplate_' + EachTemp + '\" style=\"float:left;margin-top:1%;padding:10px; width:80%;min-height: 170px;margin-left: 10%;border: 1px dotted;border-color: green;\">';
            recRow += '<div id=\"divTempLeftPart_' + EachTemp + '\" class=\"eachform\" style=\"float:left;width: 25%;height: 169px;border-right: 1px dotted;border-color: green;\">';
            recRow += '<h2 style=\"margin-left: 33%;font-size: 20px;color: #006475;\">Period *</h2>';


            recRow += '<div style=\"width:70%;margin-top: 19%;margin-left: 14%;background-color: wheat;color: #076309;border: 1px solid;\" >';

            recRow += '<input id=\"radioDays_' + EachTemp + '\" type=\"radio\" checked="true" onclick=\"UpdateNotifyMOde(' + EachTemp + ');\" name=\"radType' + EachTemp + '\" onkeypress="return DisableEnter(event)" />';

            recRow += '<label style=\"font-family:Calibri\" for=\"radioDays_' + EachTemp + '\">Days</label>';


            recRow += '<input id=\"radioHours_' + EachTemp + '\" type=\"radio\" onclick=\"UpdateNotifyMOde(' + EachTemp + ');\" name=\"radType' + EachTemp + '\" style=\"margin-left: 26px;\" onkeypress="return DisableEnter(event)"/>';
            recRow += '<label style=\"font-family:Calibri\" for=\"radioHours_' + EachTemp + '\">Hours</label>';

            recRow += '</div>';
            recRow += '<div style=\"width: 97%;margin-top: 6%;\">';

            recRow += ' <input type=\"text\" id=\"txtDuration_' + EachTemp + '\" class=\"form1\" onblur=\"UpdateNotifyDuration(' + EachTemp + ');\" onkeydown=\"return isNumber(event);\"  MaxLength=\"4\" Style=\"width: 30%; text-transform: uppercase; margin-right: 31.7%; height: 30px\" onkeypress="return DisableEnter(event)" />';

            recRow += ' <input type=\"button\" id=\"btnDurClear_' + EachTemp + '\" onclick=\"return ClearDur(' + EachTemp + ');\" class=\"ClearDur\" value=\"Clear\" style=\"margin-top: 13%;margin-left: 29%;\" />';
            recRow += ' </div></div>';


            recRow += '<div id="divTempRightPart_' + EachTemp + '" style="float:right;width: 74%;">';
            recRow += '<h2 style="margin-left: 42%;font-size: 20px;color: #006475;">Intimation *</h2>';

            recRow += '<div id=\"divTempRightContainer_' + EachTemp + '\" style=\"height: 135px;overflow: auto;width: 100%;\">';
            recRow += '<table id=\"TableEachTempSliceContainer_' + EachTemp + '\" style=\"width: 100%;\">';
            recRow += '</table>';

            recRow += ' </div>';
            recRow += '<div id=\"divBtmPortion_' + EachTemp + '\">';
            recRow += '<h2 style=\"float:left; margin-left: 1%;font-size: 16px;color: #000;padding-top: 3px;margin-top: 0px;\">Notification*</h2>';
            recRow += '<input type=\"checkbox\" id=\"cbxDashboard_' + EachTemp + '\" onchange=\"UpdateNotifyVia(' + EachTemp + ',\'cbxDashboard_\');\" style=\"float: left;margin-left: 2%\;" Checked=\"true\" class=\"form2\ " onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">DashBoard</h3>';
            recRow += '<input type=\"checkbox\" id="cbxEmail_' + EachTemp + '" onchange=\"UpdateNotifyVia(' + EachTemp + ',\'cbxEmail_\');\" style="float: left;margin-left: 3%;" Checked="true" class="form2" onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">Email</h3>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '<div style=\"float:right;\"><input id="AddEachTempButton_' + EachTemp + '" type=\"image\" src=\"/Images/Icons/black add.png\" onclick="return EachTemplateAddition();" alt=\"Add\" style=\"cursor: pointer;\" /></div>';
            recRow += '<div id="TemplateId_' + EachTemp + '" style="display: none;"></div>';
            recRow += '<div id="TemplateEvent_' + EachTemp + '" style="display: none;">INS</div>';

            jQuery('#TableTemplateContainer').append(recRow);
            document.getElementById("<%=hiddenTemplateCount.ClientID%>").value = EachTemp;

            document.getElementById("txtDuration_" + EachTemp).value = NotifyDur;
            document.getElementById("cbxDashboard_" + EachTemp).checked = false;
            document.getElementById("cbxEmail_" + EachTemp).checked = false;
            if (NotifyMod == 1) {
                document.getElementById("radioHours_" + EachTemp).checked = true;
            }
            else if (NotifyMod == 2) {
                document.getElementById("radioDays_" + EachTemp).checked = true;
            }
            if (NotifyVia != "") {
                if (NotifyVia.indexOf("D") >= 0) {
                    document.getElementById("cbxDashboard_" + EachTemp).checked = true;
                }

                if (NotifyVia.indexOf("E") >= 0) {
                    document.getElementById("cbxEmail_" + EachTemp).checked = true;
                }
            }


            AddDefaultTemplateValues(EachTemp);

            //FOR FILLING EACH SLICE DATA
            var EditEachSliceFullData = document.getElementById("<%=hiddenTemplateAlertData.ClientID%>").value;
            var EditEachTempliceData = EditEachSliceFullData.split("!");

            var findAtt2 = '\\"\\[';
            var reAtt2 = new RegExp(findAtt2, 'g');
            var resAtt2 = EditEachTempliceData[EachTemp].replace(reAtt2, '\[');

            var findAtt3 = '\\]\\"';
            var reAtt3 = new RegExp(findAtt3, 'g');
            var resAtt3 = resAtt2.replace(reAtt3, '\]');

            $noCon = jQuery.noConflict();
            var jsonAtt = $noCon.parseJSON(resAtt3);
            for (var key in jsonAtt) {
                if (jsonAtt.hasOwnProperty(key)) {
                    if (jsonAtt[key].TempAlertId != "") {


                        EditEachTempSlice(EachTemp, jsonAtt[key].TempAlertId, jsonAtt[key].AlertOpt, jsonAtt[key].AlertNtfyId);


                    }
                }
            }

            if (document.getElementById("<%=hiddenEditMode.ClientID%>").value == "View") {
                document.getElementById("cbxDashboard_" + EachTemp).disabled = true;
                document.getElementById("cbxEmail_" + EachTemp).disabled = true;
                document.getElementById("radioDays_" + EachTemp).disabled = true;
                document.getElementById("radioHours_" + EachTemp).disabled = true;
                document.getElementById("txtDuration_" + EachTemp).disabled = true;
                document.getElementById("AddEachTempButton_" + EachTemp).disabled = true;
            }


            return false;
        }

        function EditMoreEachTemplateBnk(TempDetailId, NotifyMod, NotifyVia, NotifyDur) {//edit


            EachTemp++;

            var recRow = '<tr id="TemplateRowId_' + EachTemp + ' >';

            recRow = '<div id=\"divEachTemplate_' + EachTemp + '\" style=\"float:left;margin-top:1%;padding:10px; width:80%;min-height: 170px;margin-left: 10%;border: 1px dotted;border-color: green;\">';
            recRow += '<div id=\"divTempLeftPart_' + EachTemp + '\" class=\"eachform\" style=\"float:left;width: 25%;height: 169px;border-right: 1px dotted;border-color: green;\">';
            recRow += '<h2 style=\"margin-left: 33%;font-size: 20px;color: #006475;\">Period *</h2>';


            recRow += '<div style=\"width:70%;margin-top: 19%;margin-left: 14%;background-color: wheat;color: #076309;border: 1px solid;\" >';

            recRow += '<input id=\"radioDays_' + EachTemp + '\" type=\"radio\" checked="true" onclick=\"UpdateNotifyMOde(' + EachTemp + ');\" name=\"radType' + EachTemp + '\" onkeypress="return DisableEnter(event)" />';

            recRow += '<label style=\"font-family:Calibri\" for=\"radioDays_' + EachTemp + '\">Days</label>';


            recRow += '<input id=\"radioHours_' + EachTemp + '\" type=\"radio\" onclick=\"UpdateNotifyMOde(' + EachTemp + ');\" name=\"radType' + EachTemp + '\" style=\"margin-left: 26px;\" onkeypress="return DisableEnter(event)"/>';
            recRow += '<label style=\"font-family:Calibri\" for=\"radioHours_' + EachTemp + '\">Hours</label>';

            recRow += '</div>';
            recRow += '<div style=\"width: 97%;margin-top: 6%;\">';

            recRow += ' <input type=\"text\" id=\"txtDuration_' + EachTemp + '\" class=\"form1\" onblur=\"UpdateNotifyDuration(' + EachTemp + ');\" onkeydown=\"return isNumber(event);\"  MaxLength=\"4\" Style=\"width: 30%; text-transform: uppercase; margin-right: 31.7%; height: 30px\" onkeypress="return DisableEnter(event)" />';

            recRow += ' <input type=\"button\" id=\"btnDurClear_' + EachTemp + '\" onclick=\"return ClearDur(' + EachTemp + ');\" class=\"ClearDur\" value=\"Clear\" style=\"margin-top: 13%;margin-left: 29%;\" />';
            recRow += ' </div></div>';


            recRow += '<div id="divTempRightPart_' + EachTemp + '" style="float:right;width: 74%;">';
            recRow += '<h2 style="margin-left: 42%;font-size: 20px;color: #006475;">Intimation *</h2>';

            recRow += '<div id=\"divTempRightContainer_' + EachTemp + '\" style=\"height: 135px;overflow: auto;width: 100%;\">';
            recRow += '<table id=\"TableEachTempSliceContainer_' + EachTemp + '\" style=\"width: 100%;\">';
            recRow += '</table>';

            recRow += ' </div>';
            recRow += '<div id=\"divBtmPortion_' + EachTemp + '\">';
            recRow += '<h2 style=\"float:left; margin-left: 1%;font-size: 16px;color: #000;padding-top: 3px;margin-top: 0px;\">Notification*</h2>';
            recRow += '<input type=\"checkbox\" id=\"cbxDashboard_' + EachTemp + '\" onchange=\"UpdateNotifyVia(' + EachTemp + ',\'cbxDashboard_\');\" style=\"float: left;margin-left: 2%\;" Checked=\"true\" class=\"form2\ " onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">DashBoard</h3>';
            recRow += '<input type=\"checkbox\" id="cbxEmail_' + EachTemp + '" onchange=\"UpdateNotifyVia(' + EachTemp + ',\'cbxEmail_\');\" style="float: left;margin-left: 3%;" Checked="true" class="form2" onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">Email</h3>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '<div style=\"float:right;\"><input id="AddEachTempButton_' + EachTemp + '" type=\"image\" src=\"/Images/Icons/black add.png\" onclick="return EachTemplateAddition();" alt=\"Add\" style=\"cursor: pointer;\" /></div>';
            recRow += '<div id="TemplateId_' + EachTemp + '" style="display: none;">' + TempDetailId + '</div>';
            recRow += '<div id="TemplateEvent_' + EachTemp + '" style="display: none;">UPD</div>';

            jQuery('#TableTemplateContainer').append(recRow);
            document.getElementById("<%=hiddenTemplateCount.ClientID%>").value = EachTemp;

            document.getElementById("txtDuration_" + EachTemp).value = NotifyDur;
            document.getElementById("cbxDashboard_" + EachTemp).checked = false;
            document.getElementById("cbxEmail_" + EachTemp).checked = false;
            if (NotifyMod == 1) {
                document.getElementById("radioHours_" + EachTemp).checked = true;
            }
            else if (NotifyMod == 2) {
                document.getElementById("radioDays_" + EachTemp).checked = true;
            }
            if (NotifyVia != "") {
                if (NotifyVia.indexOf("D") >= 0) {
                    document.getElementById("cbxDashboard_" + EachTemp).checked = true;
                }

                if (NotifyVia.indexOf("E") >= 0) {
                    document.getElementById("cbxEmail_" + EachTemp).checked = true;
                }
            }

            AddDefaultTemplateValues(EachTemp);

            //FOR FILLING EACH SLICE DATA
            var EditEachSliceFullData = document.getElementById("<%=hiddenTemplateAlertData.ClientID%>").value;
            var EditEachTempliceData = EditEachSliceFullData.split("!");

            var findAtt2 = '\\"\\[';
            var reAtt2 = new RegExp(findAtt2, 'g');
            var resAtt2 = EditEachTempliceData[EachTemp].replace(reAtt2, '\[');

            var findAtt3 = '\\]\\"';
            var reAtt3 = new RegExp(findAtt3, 'g');
            var resAtt3 = resAtt2.replace(reAtt3, '\]');

            $noCon = jQuery.noConflict();
            var jsonAtt = $noCon.parseJSON(resAtt3);
            for (var key in jsonAtt) {
                if (jsonAtt.hasOwnProperty(key)) {
                    if (jsonAtt[key].TempAlertId != "") {


                        EditEachTempSliceBnk(EachTemp, jsonAtt[key].TempAlertId, jsonAtt[key].AlertOpt, jsonAtt[key].AlertNtfyId);


                    }
                }
            }

            if (document.getElementById("<%=hiddenEditMode.ClientID%>").value == "View") {
                document.getElementById("cbxDashboard_" + EachTemp).disabled = true;
                document.getElementById("cbxEmail_" + EachTemp).disabled = true;
                document.getElementById("radioDays_" + EachTemp).disabled = true;
                document.getElementById("radioHours_" + EachTemp).disabled = true;
                document.getElementById("txtDuration_" + EachTemp).disabled = true;
                document.getElementById("AddEachTempButton_" + EachTemp).disabled = true;
            }


            return false;
        }


        function addMoreEachTemplate() {//add

            EachTemp++;

            var recRow = '<tr id="TemplateRowId_' + EachTemp + ' >';
            recRow = '<div id=\"divEachTemplate_' + EachTemp + '\" style=\"float:left;margin-top:1%;padding:10px; width:80%;min-height: 170px;margin-left: 10%;border: 1px dotted;border-color: green;\">';
            recRow += '<div id=\"divTempLeftPart_' + EachTemp + '\" class=\"eachform\" style=\"float:left;width: 25%;height: 169px;border-right: 1px dotted;border-color: green;\">';
            recRow += '<h2 style=\"margin-left: 33%;font-size: 20px;color: #006475;\">Period *</h2>';


            recRow += '<div style=\"width:70%;margin-top: 19%;margin-left: 14%;background-color: wheat;color: #076309;border: 1px solid;\" >';
            recRow += '<input id=\"radioDays_' + EachTemp + '\" type=\"radio\" checked="true" onclick=\"UpdateNotifyMOde(' + EachTemp + ');\" name=\"radType' + EachTemp + '\" onkeypress="return DisableEnter(event)" />';
            recRow += '<label style=\"font-family:Calibri\" for=\"radioDays_' + EachTemp + '\">Days</label>';


            recRow += '<input id=\"radioHours_' + EachTemp + '\" type=\"radio\" onclick=\"UpdateNotifyMOde(' + EachTemp + ');\" name=\"radType' + EachTemp + '\" style=\"margin-left: 26px;\" onkeypress="return DisableEnter(event)"/>';
            recRow += '<label style=\"font-family:Calibri\" for=\"radioHours_' + EachTemp + '\">Hours</label>';

            recRow += '</div>';
            recRow += '<div style=\"width: 97%;margin-top: 6%;\">';


            recRow += ' <input type=\"text\" id=\"txtDuration_' + EachTemp + '\" class=\"form1\" onblur=\"UpdateNotifyDuration(' + EachTemp + ');\" onkeydown=\"return isNumber(event);\"  MaxLength=\"4\" Style=\"width: 30%; text-transform: uppercase; margin-right: 31.7%; height: 30px\" onkeypress="return DisableEnter(event)" />';
            recRow += ' <input type=\"button\" id=\"btnDurClear_' + EachTemp + '\" onclick=\"return ClearDur(' + EachTemp + ');\" class=\"ClearDur\" value=\"Clear\" style=\"margin-top: 13%;margin-left: 29%;\" />';
            recRow += ' </div></div>';


            recRow += '<div id="divTempRightPart_' + EachTemp + '" style="float:right;width: 74%;">';
            recRow += '<h2 style="margin-left: 42%;font-size: 20px;color: #006475;">Intimation *</h2>';

            recRow += '<div id=\"divTempRightContainer_' + EachTemp + '\" style=\"height: 135px;overflow: auto;width: 100%;\">';

            recRow += '<table id=\"TableEachTempSliceContainer_' + EachTemp + '\" style=\"width: 100%;\">';
            recRow += '</table>';

            recRow += ' </div>';
            recRow += '<div id=\"divBtmPortion_' + EachTemp + '\">';
            recRow += '<h2 style=\"float:left; margin-left: 1%;font-size: 16px;color: #000;padding-top: 3px;margin-top: 0px;\">Notification*</h2>';
            recRow += '<input type=\"checkbox\" id=\"cbxDashboard_' + EachTemp + '\" checked="true" onchange=\"UpdateNotifyVia(' + EachTemp + ',\'cbxDashboard_\');\" style=\"float: left;margin-left: 2%\;" Checked=\"true\" class=\"form2\ " onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">DashBoard</h3>';
            recRow += '<input type=\"checkbox\" id="cbxEmail_' + EachTemp + '" checked="true" onchange=\"UpdateNotifyVia(' + EachTemp + ',\'cbxEmail_\');\" style="float: left;margin-left: 3%;" Checked="true" class="form2" onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">Email</h3>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '<div style=\"float:right;\"><input type=\"image\" src=\"/Images/Icons/black add.png\" onclick="return EachTemplateAddition();" alt=\"Add\" style=\"cursor: pointer;\" /></div>';
            recRow += '<div id="TemplateId_' + EachTemp + '" style="display: none;"> </div>';
            recRow += '<div id="TemplateEvent_' + EachTemp + '" style="display: none;">INS</div>';

            jQuery('#TableTemplateContainer').append(recRow);
            AddDefaultTemplateValues(EachTemp);
            AddEachTempSlice(EachTemp);
            document.getElementById("<%=hiddenTemplateCount.ClientID%>").value = EachTemp;

            return false;
        }

        var SliceCounter = 0;

        var EachTeCou = 0;
        var blurcounter = 0;



        function InitialiseCount() {
            EachTemp = 0;
            SliceCounter = 0;
            EachTeCou = 0;
            blurcounter = 0;
        }

        function EditEachTempSlice(EachTempCount, AlertId, AlertOpt, AlrtNtfyId) {//default sub

            var FrecRow = '<tr id="EachSliceRowId_' + EachTempCount + '_' + SliceCounter + '" >';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDivi_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/divisions.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DivisionClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div></td>';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDesig_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/designation.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DesignationClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';

            FrecRow += '<td style=\"width:5%\"><div id="divSmallEmp_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/employee.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return EmployeeClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div>  </td>';
            FrecRow += '<td style=\"width:5%\"><div id="divSmallMail_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/generic mail.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return GenericMailClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';
            FrecRow += '<td style=\"width:63%;background-color: #e7e7e7;\">';
            FrecRow += '<select id="ddlDivision_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlDivision_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;" />';
            FrecRow += '<select id="ddlDesignation_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlDesignation_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<select id="ddlEmployee_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlEmployee_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<input type=\"text\" id="txtGenMail_' + EachTempCount + '_' + SliceCounter + '" onblur="TempChangeFile(\'txtGenMail_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;display:none;" MaxLength=\"100\" placeholder="Enter Generic Mail Id" onkeypress="return DisableEnter(event)" />';
            FrecRow += '</td>';
            FrecRow += '<td id="FileIndvlAddMoreRow_' + EachTempCount + '_' + SliceCounter + '"  style=\"width:7%;opacity:1;\"><input id="inputAddRow_' + EachTempCount + '_' + SliceCounter + '" type=\"image\" src=\"/Images/Icons/eachtempadd.png\" alt=\"Add\" onclick="return TempCheckaddMoreRowsIndividualFiles(' + EachTempCount + ',' + SliceCounter + ');" style=\"cursor: pointer;\" /> </td>';
            FrecRow += '<td style=\"width:10%\"><input id="inputDeleteRow_' + EachTempCount + '_' + SliceCounter + '" type=\"image\" src=\"/Images/Icons/eachtempclose.png\" alt=\"Add\" onclick = "return RemoveEachSlice(' + EachTempCount + ',' + SliceCounter + ');"  style=\"cursor: pointer;\" /> </td>';

            FrecRow += '<td id="FileInx_' + EachTempCount + '_' + SliceCounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">' + AlertId + '</td>';
            FrecRow += '<td id="DbFileName_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '<td id="Replace_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">NO</td>';
            FrecRow += '<td id="ReplaceRow_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableEachTempSliceContainer_' + EachTempCount).append(FrecRow);

            // $('#divTempRightContainer_' + EachTempCount).scrollTop($('#divTempRightContainer_' + EachTempCount)[0].scrollHeight);

            document.getElementById("inputAddRow_" + EachTempCount + "_" + SliceCounter).disabled = false;

            if (EachTeCou != EachTempCount && EachTeCou != 0) {
                blurcounter = 0;
            }

            EachTeCou = EachTempCount;

            if (blurcounter != 0) {
                blurSlice = SliceCounter - 1;
                document.getElementById("FileIndvlAddMoreRow_" + EachTempCount + "_" + blurSlice).style.opacity = "0.3";
                document.getElementById("inputAddRow_" + EachTempCount + "_" + blurSlice).disabled = true;
            }

            blurcounter++;

            if (AlertOpt == 0) {
                FillDivisionDdl(EachTempCount, SliceCounter);
                document.getElementById("divSmallDivi_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";
                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "block";
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "none";

                setTimeout(selectDropDown("ddlDivision_", EachTempCount, SliceCounter, AlrtNtfyId), 100);
                FillDesignationDdl(EachTempCount, SliceCounter);
                FillEmployeeDdl(EachTempCount, SliceCounter);

                TempChangeFile('ddlDivision_', EachTempCount, SliceCounter);
            }
            else if (AlertOpt == 1) {
                FillDesignationDdl(EachTempCount, SliceCounter);
                document.getElementById("divSmallDesig_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";

                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "block";
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "none";

                setTimeout(selectDropDown("ddlDesignation_", EachTempCount, SliceCounter, AlrtNtfyId), 100);
                FillDivisionDdl(EachTempCount, SliceCounter);
                FillEmployeeDdl(EachTempCount, SliceCounter);
                TempChangeFile('ddlDesignation_', EachTempCount, SliceCounter);
            }
            else if (AlertOpt == 2) {
                FillEmployeeDdl(EachTempCount, SliceCounter);
                document.getElementById("divSmallEmp_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";

                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "block";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "none";


                setTimeout(selectDropDown("ddlEmployee_", EachTempCount, SliceCounter, AlrtNtfyId), 100);
                FillDesignationDdl(EachTempCount, SliceCounter);
                FillDivisionDdl(EachTempCount, SliceCounter);
                TempChangeFile('ddlEmployee_', EachTempCount, SliceCounter);
            }
            else if (AlertOpt == 3) {

                document.getElementById("divSmallMail_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";
                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "block";

                selectDropDown("txtGenMail_", EachTempCount, SliceCounter, AlrtNtfyId);
                FillEmployeeDdl(EachTempCount, SliceCounter);
                FillDesignationDdl(EachTempCount, SliceCounter);
                FillDivisionDdl(EachTempCount, SliceCounter);
                TempChangeFile('txtGenMail_', EachTempCount, SliceCounter);
            }


            if (document.getElementById("<%=hiddenEditMode.ClientID%>").value == "View") {
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("inputAddRow_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("inputDeleteRow_" + EachTempCount + "_" + SliceCounter).disabled = true;

                document.getElementById("divSmallMail_" + EachTempCount + "_" + SliceCounter).style.pointerEvents = "none";
                document.getElementById("divSmallEmp_" + EachTempCount + "_" + SliceCounter).style.pointerEvents = "none";
                document.getElementById("divSmallDesig_" + EachTempCount + "_" + SliceCounter).style.pointerEvents = "none";
                document.getElementById("divSmallDivi_" + EachTempCount + "_" + SliceCounter).style.pointerEvents = "none";

                document.getElementById("btnDurClear_" + EachTemp).style.pointerEvents = "none";
            }

            SliceCounter++;

            return false;
        }

        function EditEachTempSliceBnk(EachTempCount, AlertId, AlertOpt, AlrtNtfyId) {//edit sub

  
            var FrecRow = '<tr id="EachSliceRowId_' + EachTempCount + '_' + SliceCounter + '" >';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDivi_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/divisions.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DivisionClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div></td>';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDesig_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/designation.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DesignationClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';

            FrecRow += '<td style=\"width:5%\"><div id="divSmallEmp_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/employee.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return EmployeeClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div>  </td>';
            FrecRow += '<td style=\"width:5%\"><div id="divSmallMail_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/generic mail.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return GenericMailClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';
            FrecRow += '<td style=\"width:63%;background-color: #e7e7e7;\">';
            FrecRow += '<select id="ddlDivision_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlDivision_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;" />';
            FrecRow += '<select id="ddlDesignation_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlDesignation_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<select id="ddlEmployee_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlEmployee_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<input type=\"text\" id="txtGenMail_' + EachTempCount + '_' + SliceCounter + '" onblur="TempChangeFile(\'txtGenMail_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;display:none;" MaxLength=\"100\" placeholder="Enter Generic Mail Id" onkeypress="return DisableEnter(event)" />';
            FrecRow += '</td>';
            FrecRow += '<td id="FileIndvlAddMoreRow_' + EachTempCount + '_' + SliceCounter + '"  style=\"width:7%;opacity:1;\"><input id="inputAddRow_' + EachTempCount + '_' + SliceCounter + '" type=\"image\" src=\"/Images/Icons/eachtempadd.png\" alt=\"Add\" onclick="return TempCheckaddMoreRowsIndividualFiles(' + EachTempCount + ',' + SliceCounter + ');" style=\"cursor: pointer;\" /> </td>';
            FrecRow += '<td style=\"width:10%\"><input id="inputDeleteRow_' + EachTempCount + '_' + SliceCounter + '" type=\"image\" src=\"/Images/Icons/eachtempclose.png\" alt=\"Add\" onclick = "return RemoveEachSlice(' + EachTempCount + ',' + SliceCounter + ');"  style=\"cursor: pointer;\" /> </td>';

            FrecRow += '<td id="FileInx_' + EachTempCount + '_' + SliceCounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">' + AlertId + '</td>';
            FrecRow += '<td id="DbFileName_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '<td id="Replace_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">NO</td>';
            FrecRow += '<td id="ReplaceRow_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableEachTempSliceContainer_' + EachTempCount).append(FrecRow);

            document.getElementById("inputAddRow_" + EachTempCount + "_" + SliceCounter).disabled = false;

            if (EachTeCou != EachTempCount && EachTeCou != 0) {

                blurcounter = 0;
            }
            EachTeCou = EachTempCount;

            if (blurcounter != 0) {
                blurSlice = SliceCounter - 1;
                document.getElementById("FileIndvlAddMoreRow_" + EachTempCount + "_" + blurSlice).style.opacity = "0.3";
                document.getElementById("inputAddRow_" + EachTempCount + "_" + blurSlice).disabled = true;

            }

            blurcounter++;

            if (AlertOpt == 0) {
                FillDivisionDdl(EachTempCount, SliceCounter);
                document.getElementById("divSmallDivi_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";
                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "block";
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "none";

                setTimeout(selectDropDown("ddlDivision_", EachTempCount, SliceCounter, AlrtNtfyId), 100);
                FillDesignationDdl(EachTempCount, SliceCounter);
                FillEmployeeDdl(EachTempCount, SliceCounter);

                TempChangeFile('ddlDivision_', EachTempCount, SliceCounter);
            }
            else if (AlertOpt == 1) {
                FillDesignationDdl(EachTempCount, SliceCounter);
                document.getElementById("divSmallDesig_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";

                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "block";
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "none";

                setTimeout(selectDropDown("ddlDesignation_", EachTempCount, SliceCounter, AlrtNtfyId), 100);
                FillDivisionDdl(EachTempCount, SliceCounter);
                FillEmployeeDdl(EachTempCount, SliceCounter);
                TempChangeFile('ddlDesignation_', EachTempCount, SliceCounter);
            }
            else if (AlertOpt == 2) {
                FillEmployeeDdl(EachTempCount, SliceCounter);
                document.getElementById("divSmallEmp_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";

                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "block";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "none";


                setTimeout(selectDropDown("ddlEmployee_", EachTempCount, SliceCounter, AlrtNtfyId), 100);
                FillDesignationDdl(EachTempCount, SliceCounter);
                FillDivisionDdl(EachTempCount, SliceCounter);
                TempChangeFile('ddlEmployee_', EachTempCount, SliceCounter);
            }
            else if (AlertOpt == 3) {

                document.getElementById("divSmallMail_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";
                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "block";

                selectDropDown("txtGenMail_", EachTempCount, SliceCounter, AlrtNtfyId);
                FillEmployeeDdl(EachTempCount, SliceCounter);
                FillDesignationDdl(EachTempCount, SliceCounter);
                FillDivisionDdl(EachTempCount, SliceCounter);
                TempChangeFile('txtGenMail_', EachTempCount, SliceCounter);
            }


            if (document.getElementById("<%=hiddenEditMode.ClientID%>").value == "View") {
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("inputAddRow_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("inputDeleteRow_" + EachTempCount + "_" + SliceCounter).disabled = true;

                document.getElementById("divSmallMail_" + EachTempCount + "_" + SliceCounter).style.pointerEvents = "none";
                document.getElementById("divSmallEmp_" + EachTempCount + "_" + SliceCounter).style.pointerEvents = "none";
                document.getElementById("divSmallDesig_" + EachTempCount + "_" + SliceCounter).style.pointerEvents = "none";
                document.getElementById("divSmallDivi_" + EachTempCount + "_" + SliceCounter).style.pointerEvents = "none";

                document.getElementById("btnDurClear_" + EachTemp).style.pointerEvents = "none";
            }

            SliceCounter++;

            return false;
        }

        function AddEachTempSlice(EachTempCount) {//add sub


            var FrecRow = '<tr id="EachSliceRowId_' + EachTempCount + '_' + SliceCounter + '" >';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDivi_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/divisions.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DivisionClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div></td>';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDesig_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/designation.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DesignationClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';

            FrecRow += '<td style=\"width:5%\"><div id="divSmallEmp_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/employee.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return EmployeeClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div>  </td>';
            FrecRow += '<td style=\"width:5%\"><div id="divSmallMail_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/generic mail.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return GenericMailClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';
            FrecRow += '<td style=\"width:63%;background-color: #e7e7e7;\">';
            FrecRow += '<select id="ddlDivision_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlDivision_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;" />';
            FrecRow += '<select id="ddlDesignation_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlDesignation_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<select id="ddlEmployee_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlEmployee_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<input type=\"text\" id="txtGenMail_' + EachTempCount + '_' + SliceCounter + '" onblur="TempChangeFile(\'txtGenMail_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;display:none;" placeholder="Enter Generic Mail Id" onkeypress="return DisableEnter(event)" />';
            FrecRow += '</td>';
            FrecRow += '<td id="FileIndvlAddMoreRow_' + EachTempCount + '_' + SliceCounter + '"  style=\"width:7%;opacity:1;\"><input id="inputAddRow_' + EachTempCount + '_' + SliceCounter + '" type=\"image\" src=\"/Images/Icons/eachtempadd.png\" alt=\"Add\" onclick="return TempCheckaddMoreRowsIndividualFiles(' + EachTempCount + ',' + SliceCounter + ');" style=\"cursor: pointer;\" /> </td>';
            FrecRow += '<td style=\"width:10%\"><input type=\"image\" src=\"/Images/Icons/eachtempclose.png\" alt=\"Add\" onclick = "return RemoveEachSlice(' + EachTempCount + ',' + SliceCounter + ');"  style=\"cursor: pointer;\" /> </td>';

            FrecRow += '<td id="FileInx_' + EachTempCount + '_' + SliceCounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '<td id="Replace_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">NO</td>';
            FrecRow += '<td id="ReplaceRow_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableEachTempSliceContainer_' + EachTempCount).append(FrecRow);
            // $('#divTempRightContainer_' + EachTempCount).scrollTop($('#divTempRightContainer_' + EachTempCount)[0].scrollHeight);
            FillDivisionDdl(EachTempCount, SliceCounter);
            FillDesignationDdl(EachTempCount, SliceCounter);
            FillEmployeeDdl(EachTempCount, SliceCounter);
            document.getElementById("divSmallDivi_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";
            SliceCounter++;

            return false;
        }


        function AddEachTempSliceReplace(EachTempCount, Slice, SelectDiv, SelectDrp, opacity) {


            var FrecRow = '<tr id="EachSliceRowId_' + EachTempCount + '_' + SliceCounter + '" >';
            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDivi_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/divisions.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DivisionClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div></td>';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDesig_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/designation.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DesignationClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';

            FrecRow += '<td style=\"width:5%\"><div id="divSmallEmp_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/employee.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return EmployeeClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div>  </td>';
            FrecRow += '<td style=\"width:5%\"><div id="divSmallMail_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/generic mail.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return GenericMailClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';
            FrecRow += '<td style=\"width:63%;background-color: #e7e7e7;\">';
            FrecRow += '<select id="ddlDivision_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlDivision_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<select id="ddlDesignation_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlDesignation_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<select id="ddlEmployee_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlEmployee_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<input type=\"text\" id="txtGenMail_' + EachTempCount + '_' + SliceCounter + '" onblur="TempChangeFile(\'txtGenMail_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;display:none;" placeholder="Enter Generic Mail Id" />';
            FrecRow += '</td>';
            FrecRow += '<td id="FileIndvlAddMoreRow_' + EachTempCount + '_' + SliceCounter + '"  style=\"width:7%;opacity:1;\"><input id="inputAddRow_' + EachTempCount + '_' + SliceCounter + '" type=\"image\" src=\"/Images/Icons/eachtempadd.png\" alt=\"Add\" onclick="return TempCheckaddMoreRowsIndividualFiles(' + EachTempCount + ',' + SliceCounter + ');" style=\"cursor: pointer;\" /> </td>';
            FrecRow += '<td style=\"width:10%\"><input type=\"image\" src=\"/Images/Icons/eachtempclose.png\" alt=\"Add\" onclick = "return RemoveEachSlice(' + EachTempCount + ',' + SliceCounter + ');"  style=\"cursor: pointer;\" /> </td>';

            FrecRow += '<td id="FileInx_' + EachTempCount + '_' + SliceCounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '<td id="Replace_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">YES</td>';
            FrecRow += '<td id="ReplaceRow_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            $('#EachSliceRowId_' + EachTempCount + '_' + Slice).replaceWith(FrecRow);
            FillDivisionDdl(EachTempCount, SliceCounter);
            FillDesignationDdl(EachTempCount, SliceCounter);
            FillEmployeeDdl(EachTempCount, SliceCounter);
            document.getElementById(SelectDiv + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";
            document.getElementById(SelectDrp + EachTempCount + "_" + SliceCounter).style.display = "block";

            if (opacity == 0.3) {
                document.getElementById("FileIndvlAddMoreRow_" + EachTempCount + "_" + SliceCounter).style.opacity = "0.3";
                document.getElementById("inputAddRow_" + EachTempCount + "_" + SliceCounter).disabled = true;
            }
            else {
                document.getElementById("FileIndvlAddMoreRow_" + EachTempCount + "_" + SliceCounter).style.opacity = "1";
                document.getElementById("inputAddRow_" + EachTempCount + "_" + SliceCounter).disabled = false;
            }

            SliceCounter++;

            return false;
        }

        //----------Template slice-----------

        function selectDropDown(ddlid, TempCount, SliceCount, ddlvalue) {
            //alert('j');
            document.getElementById(ddlid + TempCount + "_" + SliceCount).value = ddlvalue;

        }

        function ClearDur(EachTemp) {
            IncrmntConfrmCounter();
            document.getElementById("txtDuration_" + EachTemp).value = "";
            return false;
        }

        //for selection process
        function ChangeBGColor(divName, Temp, Slice) {
            document.getElementById("divSmallDivi_" + Temp + "_" + Slice).style.backgroundColor = "#fff";
            document.getElementById("divSmallDesig_" + Temp + "_" + Slice).style.backgroundColor = "#fff";
            document.getElementById("divSmallEmp_" + Temp + "_" + Slice).style.backgroundColor = "#fff";
            document.getElementById("divSmallMail_" + Temp + "_" + Slice).style.backgroundColor = "#fff";

            document.getElementById(divName + Temp + "_" + Slice).style.backgroundColor = "#0246bd";
        }

        function DivisionClick(Temp, Slice) {

            IncrmntConfrmCounter();
            ChangeBGColor("divSmallDivi_", Temp, Slice);
            document.getElementById("ddlDivision_" + Temp + "_" + Slice).style.display = "block";
            document.getElementById("ddlDesignation_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlEmployee_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("txtGenMail_" + Temp + "_" + Slice).style.display = "none";

            document.getElementById("ddlDesignation_" + Temp + "_" + Slice).value = 0;
            document.getElementById("ddlEmployee_" + Temp + "_" + Slice).value = 0;
            document.getElementById("txtGenMail_" + Temp + "_" + Slice).value = "";
            var Filerow_index = jQuery('#EachSliceRowId_' + Temp + '_' + Slice).index();
            TempFileLocalStorageDelete(Filerow_index, Temp, Slice);

            document.getElementById("FileEvt_" + Temp + '_' + Slice).innerHTML = "INS";
            document.getElementById("FileSave_" + Temp + '_' + Slice).innerHTML = " ";

            opacitypass = document.getElementById("FileIndvlAddMoreRow_" + Temp + "_" + Slice).style.opacity;

            AddEachTempSliceReplace(Temp, Slice, "divSmallDivi_", "ddlDivision_", opacitypass);
            return false;
        }

        function DesignationClick(Temp, Slice) {
            IncrmntConfrmCounter();
            ChangeBGColor("divSmallDesig_", Temp, Slice);
            document.getElementById("ddlDivision_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlDesignation_" + Temp + "_" + Slice).style.display = "block";
            document.getElementById("ddlEmployee_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("txtGenMail_" + Temp + "_" + Slice).style.display = "none";

            document.getElementById("ddlDivision_" + Temp + "_" + Slice).value = 0;
            document.getElementById("ddlEmployee_" + Temp + "_" + Slice).value = 0;
            document.getElementById("txtGenMail_" + Temp + "_" + Slice).value = "";
            var Filerow_index = jQuery('#EachSliceRowId_' + Temp + '_' + Slice).index();
            TempFileLocalStorageDelete(Filerow_index, Temp, Slice);
            document.getElementById("FileEvt_" + Temp + '_' + Slice).innerHTML = "INS";
            document.getElementById("FileSave_" + Temp + '_' + Slice).innerHTML = " ";

            opacitypass = document.getElementById("FileIndvlAddMoreRow_" + Temp + "_" + Slice).style.opacity;
            AddEachTempSliceReplace(Temp, Slice, "divSmallDesig_", "ddlDesignation_", opacitypass);
            return false;
        }
        function EmployeeClick(Temp, Slice) {
            IncrmntConfrmCounter();

            document.getElementById("ddlDivision_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlDesignation_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlEmployee_" + Temp + "_" + Slice).style.display = "block";
            document.getElementById("txtGenMail_" + Temp + "_" + Slice).style.display = "none";

            document.getElementById("ddlDivision_" + Temp + "_" + Slice).value = 0;
            document.getElementById("ddlDesignation_" + Temp + "_" + Slice).value = 0;
            document.getElementById("txtGenMail_" + Temp + "_" + Slice).value = "";

            ChangeBGColor("divSmallEmp_", Temp, Slice);
            var Filerow_index = jQuery('#EachSliceRowId_' + Temp + '_' + Slice).index();
            TempFileLocalStorageDelete(Filerow_index, Temp, Slice);
            document.getElementById("FileEvt_" + Temp + '_' + Slice).innerHTML = "INS";
            document.getElementById("FileSave_" + Temp + '_' + Slice).innerHTML = " ";

            opacitypass = document.getElementById("FileIndvlAddMoreRow_" + Temp + "_" + Slice).style.opacity;
            AddEachTempSliceReplace(Temp, Slice, "divSmallEmp_", "ddlEmployee_", opacitypass);
            return false;
        }
        function GenericMailClick(Temp, Slice) {
            IncrmntConfrmCounter();
            ChangeBGColor("divSmallMail_", Temp, Slice);
            document.getElementById("ddlDivision_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlDesignation_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlEmployee_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("txtGenMail_" + Temp + "_" + Slice).style.display = "block";

            document.getElementById("ddlDivision_" + Temp + "_" + Slice).value = 0;
            document.getElementById("ddlDesignation_" + Temp + "_" + Slice).value = 0;
            document.getElementById("ddlEmployee_" + Temp + "_" + Slice).value = 0;

            var Filerow_index = jQuery('#EachSliceRowId_' + Temp + '_' + Slice).index();
            TempFileLocalStorageDelete(Filerow_index, Temp, Slice);
            document.getElementById("FileEvt_" + Temp + '_' + Slice).innerHTML = "INS";
            document.getElementById("FileSave_" + Temp + '_' + Slice).innerHTML = " ";

            opacitypass = document.getElementById("FileIndvlAddMoreRow_" + Temp + "_" + Slice).style.opacity;
            AddEachTempSliceReplace(Temp, Slice, "divSmallMail_", "txtGenMail_", opacitypass);
            return false;
        }


        function FillDivisionDdl(Temp, Slice) {

            var ddlTestDropDownListXML = $noCon("#ddlDivision_" + Temp + "_" + Slice);

            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableDivision";
            if (document.getElementById("<%=hiddenDivisionddlData.ClientID%>").value != 0) {

                dropdowndata = document.getElementById("<%=hiddenDivisionddlData.ClientID%>").value;
                var OptionStart = $noCon("<option>--SELECT DIVISION--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);
                $noCon(dropdowndata).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noCon(this).find('CPRDIV_ID').text();
                    var OptionText = $noCon(this).find('CPRDIV_NAME').text();
                    // Create an Option for DropDownList.
                    var option = $noCon("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    ddlTestDropDownListXML.append(option);
                });

            }
            else {

                var IntCorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                var IntOrgId = document.getElementById("<%=HiddenOrgansId.ClientID%>").value;
                $noCon.ajax({
                    type: "POST",
                    url: "gen_Insurance_Master.aspx/DropdownDivisionBind",
                    data: '{tableName:"' + tableName + '",CorpId:"' + IntCorpId + '",OrgId:"' + IntOrgId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $noCon("<option>--SELECT DIVISION--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);

                        // Now find the Table from response and loop through each item (row).
                        $noCon(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noCon(this).find('CPRDIV_ID').text();
                            var OptionText = $noCon(this).find('CPRDIV_NAME').text();
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
              // alert('delay');
        }

        function FillDesignationDdl(Temp, Slice) {

            var ddlTestDropDownListXML = $noCon("#ddlDesignation_" + Temp + "_" + Slice);

            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableDesignation";
            if (document.getElementById("<%=hiddenDesignationddlData.ClientID%>").value != 0) {
                dropdownDesData = document.getElementById("<%=hiddenDesignationddlData.ClientID%>").value;
                var OptionStart = $noCon("<option>--SELECT DESIGNATION--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);
                // Now find the Table from response and loop through each item (row).
                $noCon(dropdownDesData).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noCon(this).find('DSGN_ID').text();
                    var OptionText = $noCon(this).find('DSGN_NAME').text();
                    // Create an Option for DropDownList.
                    var option = $noCon("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    ddlTestDropDownListXML.append(option);
                });
            }
            else {

                var IntCorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                var IntOrgId = document.getElementById("<%=HiddenOrgansId.ClientID%>").value;
                $noCon.ajax({
                    type: "POST",
                    url: "gen_Insurance_Master.aspx/DropdownDesignationBind",
                    data: '{tableName:"' + tableName + '",CorpId:"' + IntCorpId + '",OrgId:"' + IntOrgId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $noCon("<option>--SELECT DESIGNATION--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);
                        // Now find the Table from response and loop through each item (row).
                        $noCon(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noCon(this).find('DSGN_ID').text();
                            var OptionText = $noCon(this).find('DSGN_NAME').text();
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

        function FillEmployeeDdl(Temp, Slice) {

            var ddlTestDropDownListXML = $noCon("#ddlEmployee_" + Temp + "_" + Slice);

            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableEmployee";
            if (document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value != 0) {
                ddlEmpdata = document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value;
                var OptionStart = $noCon("<option>--SELECT EMPLOYEE--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);
                // Now find the Table from response and loop through each item (row).
                $noCon(ddlEmpdata).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noCon(this).find('USR_ID').text();
                    var OptionText = $noCon(this).find('USR_NAME').text();
                    // Create an Option for DropDownList.
                    var option = $noCon("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    ddlTestDropDownListXML.append(option);
                });
            }

            else {
                var IntCorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                var IntOrgId = document.getElementById("<%=HiddenOrgansId.ClientID%>").value;
                $noCon.ajax({
                    type: "POST",
                    url: "gen_Insurance_Master.aspx/DropdownEmployeeBind",
                    data: '{tableName:"' + tableName + '",CorpId:"' + IntCorpId + '",OrgId:"' + IntOrgId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $noCon("<option>--SELECT EMPLOYEE--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);
                        // Now find the Table from response and loop through each item (row).
                        $noCon(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noCon(this).find('USR_ID').text();
                            var OptionText = $noCon(this).find('USR_NAME').text();
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

        function TemplateLoad() {

            localStorage.clear();
            document.getElementById("<%=hiddenNotificationMOde.ClientID%>").value = 0;
            document.getElementById("<%=hiddenNotifyVia.ClientID%>").value = 0;
            document.getElementById("<%=hiddenNotificationDuration.ClientID%>").value = 0;

            if (document.getElementById("<%=hiddenEachTemplateDetail.ClientID%>").value != 0) {
                var EditEachTemplate = document.getElementById("<%=hiddenEachTemplateDetail.ClientID%>").value;
                var findAtt2 = '\\"\\[';
                var reAtt2 = new RegExp(findAtt2, 'g');
                var resAtt2 = EditEachTemplate.replace(reAtt2, '\[');

                var findAtt3 = '\\]\\"';
                var reAtt3 = new RegExp(findAtt3, 'g');
                var resAtt3 = resAtt2.replace(reAtt3, '\]');
                //alert(res3);
                var jsonAtt = $noCon.parseJSON(resAtt3);
                for (var key in jsonAtt) {
                    if (jsonAtt.hasOwnProperty(key)) {

                        if (jsonAtt[key].TempDetailId != "") {

                            EditMoreEachTemplate(jsonAtt[key].TempDetailId, jsonAtt[key].NotifyMod, jsonAtt[key].NotifyVia, jsonAtt[key].NotifyDur);
                        }
                    }
                }
            }
            else {

                addMoreEachTemplate();
            }

            document.getElementById("<%=ddlTemplate.ClientID%>").focus();
        }

        function TempChangeFile(DDL, TempCount, Slice) {

            IncrmntConfrmCounter();
            ret = true;
            if (DDL == "txtGenMail_") {
                var NameWithoutReplace = document.getElementById(DDL + TempCount + "_" + Slice).value;
                var replaceText1 = NameWithoutReplace.replace(/</g, "");
                var replaceText2 = replaceText1.replace(/>/g, "");
                document.getElementById(DDL + TempCount + "_" + Slice).value = replaceText2;

                document.getElementById(DDL + TempCount + "_" + Slice).style.borderColor = "";
                var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                var ToMail = document.getElementById(DDL + TempCount + "_" + Slice).value;
                var ToMailSplit = [];
                ToMailSplit = ToMail.split(',');
                if (ToMailSplit != "") {
                    for (ArrCount = 0; ArrCount < ToMailSplit.length; ArrCount++) {


                        if (!filter.test(ToMailSplit[ArrCount])) {
                            document.getElementById(DDL + TempCount + "_" + Slice).style.borderColor = "red";

                            ret = false;
                        }

                    }
                }
            }
            if (DDL == "txtGenMail_") {
                if (ret == true) {
                    var SavedorNot = document.getElementById("FileSave_" + TempCount + "_" + Slice).innerHTML;

                    if (SavedorNot == "saved") {

                        var row_index = jQuery('#EachSliceRowId_' + TempCount + '_' + Slice).index();

                        TempFileLocalStorageEdit(DDL, TempCount, Slice, row_index);
                    }
                    else {

                        TempFileLocalStorageAdd(DDL, TempCount, Slice);
                    }
                }
                else {
                    var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_" + TempCount);//Retrieve the stored data

                    tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload);

                    if (tbClientTemplateUpload != null && tbClientTemplateUpload != []) {
                        var Filerow_index = jQuery('#EachSliceRowId_' + TempCount + '_' + Slice).index();
                        TempFileLocalStorageDelete(Filerow_index, Temp, Slice);

                    }
                }
            }
            else {
                var DropDownValue = document.getElementById(DDL + TempCount + '_' + Slice).value;
                if (DropDownValue != 0) {
                    //------for deciding add or edit---------

                    var SavedorNot = document.getElementById("FileSave_" + TempCount + "_" + Slice).innerHTML;

                    if (SavedorNot == "saved") {

                        var row_index = jQuery('#EachSliceRowId_' + TempCount + '_' + Slice).index();

                        TempFileLocalStorageEdit(DDL, TempCount, Slice, row_index);
                    }
                    else {

                        TempFileLocalStorageAdd(DDL, TempCount, Slice);
                    }
                }
                else {

                    var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_" + TempCount);//Retrieve the stored data

                    tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload);
                    if (tbClientTemplateUpload != null && tbClientTemplateUpload != []) {
                        var Filerow_index = jQuery('#EachSliceRowId_' + TempCount + '_' + Slice).index();
                        TempFileLocalStorageDelete(Filerow_index, TempCount, Slice);
                    }
                }

            }

        }

        function TempCheckaddMoreRowsIndividualFiles(TempCount, x) {

            if (CheckEachDdl(TempCount, x)) {

                var check = document.getElementById("FileInx_" + TempCount + "_" + x).innerHTML;
                if (check == " ") {
                    var Fevt = document.getElementById("FileEvt_" + TempCount + "_" + x).innerHTML;
                    if (Fevt != 'UPD') {

                        document.getElementById("FileInx_" + TempCount + "_" + x).innerHTML = TempCount + "_" + x;
                        document.getElementById("FileIndvlAddMoreRow_" + TempCount + "_" + x).style.opacity = "0.3";


                        AddEachTempSlice(TempCount);
                        document.getElementById("inputAddRow_" + TempCount + "_" + x).disabled = true;
                        return false;

                    }
                    else {

                        document.getElementById("FileInx_" + TempCount + "_" + x).innerHTML = TempCount + "_" + x;
                        document.getElementById("FileIndvlAddMoreRow_" + TempCount + "_" + x).style.opacity = "0.3";

                        AddEachTempSlice(TempCount);
                        document.getElementById("inputAddRow_" + TempCount + "_" + x).disabled = true;
                        return false;
                    }
                }
            }
            else {
                return false;
            }

        }

        function CheckEachDdl(Temp, Slice) {

            if (document.getElementById("ddlDivision_" + Temp + "_" + Slice).value == 0 && document.getElementById("ddlDesignation_" + Temp + "_" + Slice).value == 0 && document.getElementById("ddlEmployee_" + Temp + "_" + Slice).value == 0 && document.getElementById("txtGenMail_" + Temp + "_" + Slice).value == "") {
                return false;
            }
            else {
                return true;
            }

        }


        function TempFileLocalStorageAdd(ddl, TempCount, Slice) {


            var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_" + TempCount);//Retrieve the stored data

            tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload); //Converts string to object

            if (tbClientTemplateUpload == null) //If there is no data, initialize an empty array
                tbClientTemplateUpload = [];

            if (document.getElementById("Replace_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML == "") {

                editedIndex = tbClientTemplateUpload.length;
                document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML = editedIndex;
            }


            var DropDownValue = document.getElementById(ddl + TempCount + '_' + Slice).value;
            var FdetailId = document.getElementById("FileDtlId_" + TempCount + '_' + Slice).innerHTML;
            var Fevt = document.getElementById("FileEvt_" + TempCount + '_' + Slice).innerHTML;
            //   alert('FilePath' + FilePath);

            if (Fevt == 'INS') {
                var client = JSON.stringify({
                    ROWID: "" + Slice + "",
                    DDLVALUE: "" + DropDownValue + "",
                    DDLMODE: "" + ddl + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"

                });
            }
            else if (Fevt == 'UPD') {
                var client = JSON.stringify({
                    ROWID: "" + Slice + "",
                    DDLVALUE: "" + DropDownValue + "",
                    DDLMODE: "" + ddl + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });
            }

            tbClientTemplateUpload.push(client);
            localStorage.setItem("tbClientTemplateUpload_" + TempCount, JSON.stringify(tbClientTemplateUpload));

            document.getElementById("FileSave_" + TempCount + '_' + Slice).innerHTML = "saved";
            //   alert('saved');
            return true;

        }

        function TempFileLocalStorageEdit(ddl, TempCount, Slice, row_index) {

            if (document.getElementById("Replace_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML != "") {
                row_index = document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML;
            }


            var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_" + TempCount);//Retrieve the stored data

            tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload); //Converts string to object

            if (tbClientTemplateUpload == null) //If there is no data, initialize an empty array
                tbClientTemplateUpload = [];
            var DropDownValue = document.getElementById(ddl + TempCount + '_' + Slice).value;
            var FdetailId = document.getElementById("FileDtlId_" + TempCount + '_' + Slice).innerHTML;
            var Fevt = document.getElementById("FileEvt_" + TempCount + '_' + Slice).innerHTML;

            var tbClientTemplateUploadCancel = localStorage.getItem("tbClientTemplateUploadDelete_" + TempCount);//Retrieve the stored data

            tbClientTemplateUploadCancel = JSON.parse(tbClientTemplateUploadCancel);
            if (tbClientTemplateUploadCancel == null) //If there is no data, initialize an empty array
                tbClientTemplateUploadCancel = [];
            deleteLength = tbClientTemplateUploadCancel.length;

            if (document.getElementById("Replace_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML != "") {
                row_index = document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML;

            }
            else if (document.getElementById("Replace_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML == "") {

            }
            else {

                row_index = row_index - deleteLength;

            }


            if (Fevt == 'INS') {


                tbClientTemplateUpload[row_index] = JSON.stringify({
                    ROWID: "" + Slice + "",
                    DDLVALUE: "" + DropDownValue + "",
                    DDLMODE: "" + ddl + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"
                });//Alter the selected item on the table

            }
            else {
                tbClientTemplateUpload[row_index] = JSON.stringify({
                    ROWID: "" + Slice + "",
                    DDLVALUE: "" + DropDownValue + "",
                    DDLMODE: "" + ddl + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });//Alter the selected item on the table



            }

            localStorage.setItem("tbClientTemplateUpload_" + TempCount, JSON.stringify(tbClientTemplateUpload));
            return true;
        }

        function TempFileLocalStorageDelete(row_index, TempCount, Slice) {

            var $DelFile = jQuery.noConflict();
            var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_" + TempCount);//Retrieve the stored data

            tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload); //Converts string to object
            if (tbClientTemplateUpload == null) //If there is no data, initialize an empty array
                tbClientTemplateUpload = [];

            ContentCount = tbClientTemplateUpload.length;
            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            var tbClientTemplateUploadCancel = localStorage.getItem("tbClientTemplateUploadDelete_" + TempCount);//Retrieve the stored data

            tbClientTemplateUploadCancel = JSON.parse(tbClientTemplateUploadCancel);
            if (tbClientTemplateUploadCancel == null) //If there is no data, initialize an empty array
                tbClientTemplateUploadCancel = [];
            deleteLength = tbClientTemplateUploadCancel.length;



            if (document.getElementById("Replace_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML != "") {
                row_index = document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML;

                if (ContentCount == 1) {
                    row_index = 0;
                }

                tbClientTemplateUpload.splice(row_index, 1);
            }
            else if (document.getElementById("Replace_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML == "") {

            }
            else {

                row_index = row_index - deleteLength;


                if (ContentCount == 1) {
                    row_index = 0;
                }

                tbClientTemplateUpload.splice(row_index, 1);
            }
            localStorage.setItem("tbClientTemplateUpload_" + TempCount, JSON.stringify(tbClientTemplateUpload));

            var Fevt = document.getElementById("FileEvt_" + TempCount + '_' + Slice).innerHTML;
            if (Fevt == 'UPD') {
                var FdetailId = document.getElementById("FileDtlId_" + TempCount + '_' + Slice).innerHTML;

                if (FdetailId != '') {

                    DeleteFileLSTORAGEAdd(TempCount, Slice);
                }

            }
        }

        function DeleteFileLSTORAGEAdd(TempCount, Slice) {

            var tbClientTemplateUploadCancel = localStorage.getItem("tbClientTemplateUploadDelete_" + TempCount);//Retrieve the stored data

            tbClientTemplateUploadCancel = JSON.parse(tbClientTemplateUploadCancel); //Converts string to object

            if (tbClientTemplateUploadCancel == null) //If there is no data, initialize an empty array
                tbClientTemplateUploadCancel = [];

            var FdetailId = document.getElementById("FileDtlId_" + TempCount + "_" + Slice).innerHTML;

            var $addFile = jQuery.noConflict();
            var client = JSON.stringify({
                ROWID: "" + Slice + "",
                // FILENAME: "" + FileName + "",
                // EVTACTION: "" + Fevt + "",
                DTLID: "" + FdetailId + ""

            });



            tbClientTemplateUploadCancel.push(client);
            localStorage.setItem("tbClientTemplateUploadDelete_" + TempCount, JSON.stringify(tbClientTemplateUploadCancel));

            $addFile("#cphMain_hiddenDeleteSliceData").val(JSON.stringify(tbClientTemplateUploadCancel));


            return true;

        }

        //-------------Template-----------
        function EachTemplateAddition() {
            IncrmntConfrmCounter();
            if (confirm("Are you sure you want to add new template section?.You will not be able to delete it in future")) {

                if (CheckEachTemp() == true) {
                    addMoreEachTemplate();
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }

        function CheckEachTemp() {

            var Count = document.getElementById("<%=hiddenTemplateCount.ClientID%>").value;

            var TempValue = ""
            for (intCount = 1; intCount <= Count; intCount++) {

                TempValue = localStorage.getItem("tbClientTemplateUpload_" + intCount);
                if (TempValue == null) {
                    return false;
                }
            }

            return true;
        }


        function AddDefaultTemplateValues(TempCount) {

            var Fevt = document.getElementById("TemplateEvent_" + TempCount).innerHTML;
            var TemplateId = document.getElementById("TemplateId_" + TempCount).innerHTML;

            //----for notification mode
            var Mode = "";
            if (document.getElementById("radioDays_" + TempCount).checked == true) {
                Mode = "D";
            }
            else if (document.getElementById("radioHours_" + TempCount).checked == true) {
                Mode = "H";
            }


            var tbClientNotifyMode = localStorage.getItem("tbClientNotifyMode");
            tbClientNotifyMode = JSON.parse(tbClientNotifyMode); //Converts string to object

            if (tbClientNotifyMode == null) {//If there is no data, initialize an empty array
                var $FileZ = jQuery.noConflict();

                if ($FileZ("#cphMain_hiddenNotificationMOde").val() != 0) {
                    var HiddenValue = $FileZ("#cphMain_hiddenNotificationMOde").val();
                    tbClientNotifyMode = JSON.parse(HiddenValue);
                }
                else {

                    tbClientNotifyMode = [];
                }
            }
            if (Fevt == 'INS') {
                var client = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTMODE: "" + Mode + "",
                    TEMPID: "0"

                });
            }
            else if (Fevt == 'UPD') {
                var client = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTMODE: "" + Mode + "",
                    TEMPID: "" + TemplateId + ""

                });
            }
            tbClientNotifyMode.push(client);
            localStorage.setItem("tbClientNotifyMode", JSON.stringify(tbClientNotifyMode));

            var $FileE = jQuery.noConflict();
            $FileE("#cphMain_hiddenNotificationMOde").val(JSON.stringify(tbClientNotifyMode));

            //---for notify via what---
            var Via = "";
            if (document.getElementById("cbxEmail_" + TempCount).checked == true) {
                Via = Via + "E";
            }
            if (document.getElementById("cbxDashboard_" + TempCount).checked == true) {
                Via = Via + "," + "D";
            }

            var tbClientNotifyVia = localStorage.getItem("tbClientNotifyVia");
            tbClientNotifyVia = JSON.parse(tbClientNotifyVia); //Converts string to object

            if (tbClientNotifyVia == null) {//If there is no data, initialize an empty array
                var $FileW = jQuery.noConflict();
                if ($FileW("#cphMain_hiddenNotifyVia").val() != 0) {
                    var HiddenViaValue = $FileW("#cphMain_hiddenNotifyVia").val();
                    tbClientNotifyVia = JSON.parse(HiddenViaValue);
                }
                else {
                    tbClientNotifyVia = [];
                }
            }

            if (Fevt == 'INS') {


                var client2 = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTVIA: "" + Via + "",
                    TEMPID: "0"
                });//Alter the selected item on the table

            }
            else {
                var client2 = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTVIA: "" + Via + "",
                    TEMPID: "" + TemplateId + ""

                });

            }

            tbClientNotifyVia.push(client2);
            localStorage.setItem("tbClientNotifyVia", JSON.stringify(tbClientNotifyVia));
            var $FileF = jQuery.noConflict();
            $FileF("#cphMain_hiddenNotifyVia").val(JSON.stringify(tbClientNotifyVia));

            //----for notification duration--
            var Duration = document.getElementById("txtDuration_" + TempCount).value;
            var tbClientNotifyDur = localStorage.getItem("tbClientNotifyDur");
            tbClientNotifyDur = JSON.parse(tbClientNotifyDur); //Converts string to object

            if (tbClientNotifyDur == null) { //If there is no data, initialize an empty array
                var $FileA = jQuery.noConflict();
                if ($FileA("#cphMain_hiddenNotificationDuration").val() != 0) {
                    var HiddenDurValue = $FileA("#cphMain_hiddenNotificationDuration").val();
                    tbClientNotifyDur = JSON.parse(HiddenDurValue);
                }
                else {
                    tbClientNotifyDur = [];
                }
            }

            if (Fevt == 'INS') {


                var client3 = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTDUR: "" + Duration + "",
                    TEMPID: "0"
                });//Alter the selected item on the table

            }
            else {
                var client3 = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTDUR: "" + Duration + "",
                    TEMPID: "" + TemplateId + ""

                });

            }

            tbClientNotifyDur.push(client3);
            localStorage.setItem("tbClientNotifyDur", JSON.stringify(tbClientNotifyDur));
            var $FileG = jQuery.noConflict();
            $FileG("#cphMain_hiddenNotificationDuration").val(JSON.stringify(tbClientNotifyDur));
            return false;
        }


        function UpdateNotifyMOde(TempCount) {

            var Fevt = document.getElementById("TemplateEvent_" + TempCount).innerHTML;
            var TemplateId = document.getElementById("TemplateId_" + TempCount).innerHTML;

            var Mode = "";
            if (document.getElementById("radioDays_" + TempCount).checked == true) {
                Mode = "D";
            }
            else if (document.getElementById("radioHours_" + TempCount).checked == true) {
                Mode = "H";
            }

            var row_index = TempCount - 1;

            var tbClientNotifyMode = localStorage.getItem("tbClientNotifyMode");
            if (tbClientNotifyMode == null) {
                var $FileG = jQuery.noConflict();
                tbClientNotifyMode = $FileG("#cphMain_hiddenNotificationMOde").val();
            }


            tbClientNotifyMode = JSON.parse(tbClientNotifyMode); //Converts string to object


            if (tbClientNotifyMode == null) //If there is no data, initialize an empty array
                tbClientNotifyMode = [];


            if (Fevt == 'INS') {

                tbClientNotifyMode[row_index] = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTMODE: "" + Mode + "",
                    TEMPID: " 0"
                });//Alter the selected item on the table
            }
            else {
                tbClientNotifyMode[row_index] = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTMODE: "" + Mode + "",
                    TEMPID: "" + TemplateId + ""

                });

            }

            localStorage.setItem("tbClientNotifyMode", JSON.stringify(tbClientNotifyMode));
            var $FileE = jQuery.noConflict();
            $FileE("#cphMain_hiddenNotificationMOde").val(JSON.stringify(tbClientNotifyMode));

        }

        function UpdateNotifyDuration(TempCount) {


            var NameWithoutReplace = document.getElementById("txtDuration_" + TempCount).value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("txtDuration_" + TempCount).value = replaceText2;

            var txtPerVal = document.getElementById("txtDuration_" + TempCount).value;
            document.getElementById("txtDuration_" + TempCount).style.borderColor = "";

            if (txtPerVal.indexOf('.') !== -1) {
                document.getElementById("txtDuration_" + TempCount).value = "";
                document.getElementById("txtDuration_" + TempCount).style.borderColor = "red";

            }
            if (!isNaN(txtPerVal) == false) {

                document.getElementById("txtDuration_" + TempCount).value = "";
                document.getElementById("txtDuration_" + TempCount).style.borderColor = "red";

            }
            else {
                if (txtPerVal < 0) {
                    document.getElementById("txtDuration_" + TempCount).value = "";
                    document.getElementById("txtDuration_" + TempCount).style.borderColor = "red";

                }
            }


            var Fevt = document.getElementById("TemplateEvent_" + TempCount).innerHTML;
            var TemplateId = document.getElementById("TemplateId_" + TempCount).innerHTML;
            var Duration = document.getElementById("txtDuration_" + TempCount).value;
            var row_index = TempCount - 1;

            var tbClientNotifyDur = localStorage.getItem("tbClientNotifyDur");

            if (tbClientNotifyDur == null) {
                var $FileM = jQuery.noConflict();
                tbClientNotifyDur = $FileM("#cphMain_hiddenNotificationDuration").val();

            }

            tbClientNotifyDur = JSON.parse(tbClientNotifyDur); //Converts string to object

            if (tbClientNotifyDur == null) //If there is no data, initialize an empty array
                tbClientNotifyDur = [];

            if (Fevt == 'INS') {


                tbClientNotifyDur[row_index] = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTDUR: "" + Duration + "",
                    TEMPID: "0"
                });//Alter the selected item on the table

            }
            else {
                tbClientNotifyDur[row_index] = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTDUR: "" + Duration + "",
                    TEMPID: "" + TemplateId + ""

                });

            }

            localStorage.setItem("tbClientNotifyDur", JSON.stringify(tbClientNotifyDur));
            var $FileG = jQuery.noConflict();
            $FileG("#cphMain_hiddenNotificationDuration").val(JSON.stringify(tbClientNotifyDur));

        }

        function UpdateNotifyVia(TempCount, ClickedCbx) {

            var Fevt = document.getElementById("TemplateEvent_" + TempCount).innerHTML;
            var TemplateId = document.getElementById("TemplateId_" + TempCount).innerHTML;
            var Via = "";
            if (document.getElementById("cbxEmail_" + TempCount).checked == true) {

                Via = Via + "," + "E";
            }
            if (document.getElementById("cbxDashboard_" + TempCount).checked == true) {

                Via = Via + "," + "D";
            }

            var row_index = TempCount - 1;

            var tbClientNotifyVia = localStorage.getItem("tbClientNotifyVia");

            if (tbClientNotifyVia == null) {
                var $FileH = jQuery.noConflict();
                tbClientNotifyVia = $FileH("#cphMain_hiddenNotifyVia").val();

            }

            tbClientNotifyVia = JSON.parse(tbClientNotifyVia); //Converts string to object

            if (tbClientNotifyVia == null) //If there is no data, initialize an empty array
                tbClientNotifyVia = [];

            if (Fevt == 'INS') {


                tbClientNotifyVia[row_index] = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTVIA: "" + Via + "",
                    TEMPID: "0"
                });//Alter the selected item on the table

            }
            else {
                tbClientNotifyVia[row_index] = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTVIA: "" + Via + "",
                    TEMPID: "" + TemplateId + ""

                });

            }

            localStorage.setItem("tbClientNotifyVia", JSON.stringify(tbClientNotifyVia));
            var $FileF = jQuery.noConflict();
            $FileF("#cphMain_hiddenNotifyVia").val(JSON.stringify(tbClientNotifyVia));

        }

        function RemoveEachSlice(TempCount, removeNum) {
            if (confirm("Are you sure you want to delete?")) {
                var Filerow_index = jQuery('#EachSliceRowId_' + TempCount + '_' + removeNum).index();
                TempFileLocalStorageDelete(Filerow_index, TempCount, removeNum);
                jQuery('#EachSliceRowId_' + TempCount + '_' + removeNum).remove();

                var TableFileRowCount = document.getElementById("TableEachTempSliceContainer_" + TempCount).rows.length;

                if (TableFileRowCount != 0) {
                    var idlast = $noC('#TableEachTempSliceContainer_' + TempCount + ' tr:last').attr('id');

                    if (idlast != "") {
                        var res = idlast.split("_");
                        document.getElementById("FileInx_" + TempCount + '_' + res[2]).innerHTML = " ";
                        document.getElementById("FileIndvlAddMoreRow_" + TempCount + '_' + res[2]).style.opacity = "1";
                        document.getElementById("inputAddRow_" + TempCount + "_" + res[2]).disabled = false;
                    }
                }
                else {
                    AddEachTempSlice(TempCount);


                }

            }
            else {

                return false;
            }
        }

    </script>


    <script>

        function Validate() {

            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            document.getElementById('divMessageArea').style.display = "none";
            document.getElementById('imgMessageArea').src = "";

            if (document.getElementById("<%=HiddenGurntNumDupChk.ClientID%>").value == "1") {
                Duplication();
                CheckSubmitZero();
                return false;
            }

            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtOpngDate.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOpngDate.ClientID%>").value = replaceText2;


            var NameWithoutReplace = document.getElementById("<%=txtInsuranceno.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtInsuranceno.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtAmount.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAmount.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtDescrptn.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtDescrptn.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtEmpName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEmpName.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtCntctMail.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCntctMail.ClientID%>").value = replaceText2;

            document.getElementById("<%=txtPrjctClsngDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtOpngDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtInsuranceno.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAmount.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtDescrptn.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtEmpName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCntctMail.ClientID%>").style.borderColor = "";

            $noCon("div#divProject input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById("<%=ddlTemplate.ClientID%>").style.borderColor = "";

            var InsuranceNo = document.getElementById("<%=txtInsuranceno.ClientID%>").value.trim();

            var InsrPrvdr = document.getElementById("<%=ddlInsurncPrvdr.ClientID%>");
            var InsrPrvdrText = InsrPrvdr.options[InsrPrvdr.selectedIndex].text;

            var CloseDate = document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value.trim();
            var opengDate = document.getElementById("<%=txtOpngDate.ClientID%>").value.trim();
            var Amount = document.getElementById("<%=txtAmount.ClientID%>").value.trim();
            var Currency = document.getElementById("<%=ddlCurrency.ClientID%>");
            var CurrencyText = Currency.options[Currency.selectedIndex].text;
            var Validity = document.getElementById("<%=txtValidity.ClientID%>").value.trim();

            var ddlExistEmp = document.getElementById("<%=ddlExistingEmp.ClientID%>");
            var ddlExistEmpText = ddlExistEmp.options[ddlExistEmp.selectedIndex].value;

            var ddlTemplate = document.getElementById("<%=ddlTemplate.ClientID%>");
            var ddlTemplateText = ddlTemplate.options[ddlTemplate.selectedIndex].value;

            var ContactEmail = document.getElementById("<%=txtCntctMail.ClientID%>").value;
            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

            document.getElementById('divMessageArea').style.display = "none";
            document.getElementById('imgMessageArea').src = "";


            var tbClientImageValidation = localStorage.getItem("tbClientImageValidation");//Retrieve the stored data

            tbClientImageValidation = JSON.parse(tbClientImageValidation); //Converts string to object

            if (tbClientImageValidation == null) //If there is no data, initialize an empty array
                tbClientImageValidation = [];

            for (var i = 0; i < tbClientImageValidation.length; i++) {

                var rowid = tbClientImageValidation[i];
                rowid = rowid.split(":");
                rowid = rowid[1];
                rowid = rowid.replace(/"/g, "");
                rowid = rowid.replace(/}/g, "");

                if (CheckValidation(rowid)) {

                    ret = true;

                }
                else {
                    ret = false;
                    break;
                }

            }

            if (ContactEmail != "") {
                if (!filter.test(ContactEmail)) {

                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please enter a valid email address.";
                    document.getElementById("<%=txtCntctMail.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtCntctMail.ClientID%>").focus();
                    ret = false;
                }
                else {

                    document.getElementById("<%=txtCntctMail.ClientID%>").style.borderColor = "";
                }
            }


            if (ddlTemplateText == "--SELECT TEMPLATE--") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlTemplate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlTemplate.ClientID%>").focus();
                ret = false;
            }

            if (document.getElementById("<%=radioLimited.ClientID%>").checked == true) {

                if (CloseDate == "") {

                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtPrjctClsngDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtPrjctClsngDate.ClientID%>").focus();
                    ret = false;
                }

                else {

                    var presentdate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                    var arrpresentdate = presentdate.split("-");
                    var datepresentdate = new Date(arrpresentdate[2], arrpresentdate[1] - 1, arrpresentdate[0]);

                    document.getElementById("<%=txtPrjctClsngDate.ClientID%>").style.borderColor = "";
                    var TaskdatepickerDate = document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value;
                    var arrDatePickerDate = TaskdatepickerDate.split("-");
                    var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                    var arrCurrentDate = opengDate.split("-");
                    var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);
                    if (dateDateCntrlr < dateCurrentDate) {
                        document.getElementById("<%=txtPrjctClsngDate.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtPrjctClsngDate.ClientID%>").focus();
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, expiry date should be greater than insurance date !";
                        ret = false;

                    }

                    if (dateDateCntrlr < datepresentdate) {

                        if (confirm("Insurance has been already expired. Are you sure you want to continue?")) {

                        }
                        else {
                            ret = false;
                        }
                    }
                }
            }

            if (opengDate == "") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtOpngDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtOpngDate.ClientID%>").focus();
                ret = false;
            }
            else {

                document.getElementById("<%=txtOpngDate.ClientID%>").style.borderColor = "";
            }

            if (CurrencyText == "--SELECT CURRENCY--") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlCurrency.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlCurrency.ClientID%>").focus();
                ret = false;
            }
            else {
                document.getElementById("<%=ddlCurrency.ClientID%>").style.borderColor = "";
            }
            if (Amount == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtAmount.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtAmount.ClientID%>").focus();
                ret = false;
            }
            else {

                document.getElementById("<%=txtAmount.ClientID%>").style.borderColor = "";
            }

            var IsValidInput = validateUserInputData();
            if (IsValidInput == false) {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.Please import the necessary datas. ";

                ret = false;
            }

            if (InsuranceNo == "") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtInsuranceno.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtInsuranceno.ClientID%>").focus();
                ret = false;
            }
            else {
                document.getElementById("<%=txtInsuranceno.ClientID%>").style.borderColor = "";
            }

            if (InsrPrvdrText == "--SELECT INSURANCE PROVIDER--") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                //document.getElementById("<%=ddlInsurncPrvdr.ClientID%>").style.borderColor = "Red";
                //document.getElementById("<%=ddlInsurncPrvdr.ClientID%>").focus();

                $noCon("div#divddlInsurncPrvdr input.ui-autocomplete-input").css("borderColor", "red");
                $noCon("div#divddlInsurncPrvdr input.ui-autocomplete-input").focus();
                $noCon("div#divddlInsurncPrvdr input.ui-autocomplete-input").select();
                ret = false;
            }

            var Count = document.getElementById("<%=hiddenTemplateCount.ClientID%>").value;

            var TotalValue = "";
            var DeletedValue = "";
            for (intCount = 1; intCount <= Count; intCount++) {

                if (localStorage.getItem("tbClientTemplateUpload_" + intCount) != null && localStorage.getItem("tbClientTemplateUpload_" + intCount) != "[]") {

                    document.getElementById('divEachTemplate_' + intCount).style.border = "1px dotted";
                    document.getElementById('divEachTemplate_' + intCount).style.borderColor = "green";

                    TotalValue = TotalValue + "!" + localStorage.getItem("tbClientTemplateUpload_" + intCount);
                    DeletedValue = DeletedValue + "!" + localStorage.getItem("tbClientTemplateUploadDelete_" + intCount);

                }
                else {
                    document.getElementById('divEachTemplate_' + intCount).style.border = "2px dotted";
                    document.getElementById('divEachTemplate_' + intCount).style.borderColor = "red";



                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    CheckSubmitZero();
                    return false;
                }

                document.getElementById("txtDuration_" + intCount).style.borderColor = "";
                if (document.getElementById("txtDuration_" + intCount).value == "") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("txtDuration_" + intCount).style.borderColor = "red";
                    CheckSubmitZero();
                    return false;
                }
            }

            document.getElementById("<%=hiddenEachSliceData.ClientID%>").value = TotalValue;
            document.getElementById("<%=hiddenDeleteSliceData.ClientID%>").value = DeletedValue;


            if (ret == false) {
                CheckSubmitZero();

            }
            if (ret == true) {

                document.getElementById("<%=hiddenDivisionddlData.ClientID%>").value = 0;
                document.getElementById("<%=hiddenDesignationddlData.ClientID%>").value = 0;
                document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value = 0;
            }

            $(window).scrollTop(0);
            return ret;
        }

        function validateUserInputData() {

            ret = true;

            var NameWithoutReplace = document.getElementById("<%=txtAmount.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var AmountText = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAmount.ClientID%>").value = AmountText;

            $noCon("div#divProjectsDdl input.ui-autocomplete-input").css("borderColor", "");

            var DdlProject = document.getElementById("<%=ddlProjects.ClientID%>");
            var DdlProjectText = DdlProject.options[DdlProject.selectedIndex].text;

            if (DdlProjectText == "--SELECT PROJECT--") {
                $noCon("div#divProjectsDdl input.ui-autocomplete-input").css("borderColor", "red");
                ret = false;
            }

            if (AmountText <= 0) {
                document.getElementById("<%=txtAmount.ClientID%>").style.borderColor = "Red";
                ret = false;
            }
            if (document.getElementById("<%=txtAmount.ClientID%>").value != 1) {
                if (AmountText <= 0) {
                    document.getElementById("<%=txtAmount.ClientID%>").focus();
                }
                if (DdlProjectText == "--SELECT PROJECT--") {
                    $noCon("div#divProjectsDdl input.ui-autocomplete-input").focus();
                    $noCon("div#divProjectsDdl input.ui-autocomplete-input").select();
                }
            }
            return ret;
        }


        function ConfirmAlert() {
            var chck = Validate();

            if (chck == true) {

                if (confirm("Are you sure you want to confirm?")) {
                    return true;
                }
                else {

                    CheckSubmitZero();
                    return false;
                }
            } else {

                CheckSubmitZero();
                return false;
            }

        }

        function ConfirmReOpen() {

            if (confirm("Are you sure you want to reopen?")) {
                document.getElementById("<%=hiddenDivisionddlData.ClientID%>").value = 0;
                document.getElementById("<%=hiddenDesignationddlData.ClientID%>").value = 0;
                document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value = 0;
                return true;
            }
            else {

                CheckSubmitZero();
                return false;
            }

        }
        function ConfirmClose() {


            if (confirm("Are you sure you want to close?")) {
                document.getElementById("<%=hiddenDivisionddlData.ClientID%>").value = 0;
                document.getElementById("<%=hiddenDesignationddlData.ClientID%>").value = 0;
                document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value = 0;
                return true;
            }
            else {

                CheckSubmitZero();
                return false;
            }

        }

        function Alertrenew() {
            if (confirm("Are you sure you want renew the insurance?")) {
                var ret = Validate();

                if (ret == true) {
                    return true;
                }
                else
                    return false;
            }
            else {
                return false;
            }
        }

        function closeWindow() {
            window.close();
        }

        function SuccessGuaranteeRenewed() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance details renewed successfully.";
         }

         function SuccessUpdation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance details updated successfully.";
         }
         function SuccessUpdationPrjct() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance updated successfully.";
         }

         function SuccessConfirmation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance details inserted successfully.";
         }
         function SuccessConfirmationCntrct() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance inserted successfully.";
         }
         function SuccessConfirmationPrjct() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance inserted successfully.";
         }

         function SuccessReOpen() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance details reopened successfully.";
         }
         function SuccessConfirm() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance details confirmed successfully.";
         }
         function StsChkClsRenew() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Renew denied.This insurance is already closed.";
         }
         function StsChkReopnRenew() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Renew Denied.This insurance is already reopened.";
         }
        function Duplication() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error!. Insurance number can’t be duplicated.";
            document.getElementById("<%=txtInsuranceno.ClientID%>").style.borderColor = "Red";
        }
        function StatusCheck() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Confirm denied.This insurance is already confirmed.";
        }

        function StatusCheckReopn() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Reopen denied.This insurance is already reopened.";
        }
        function StatusCheckClsReopn() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Reopen denied.This insurance is already closed.";
        }


        function cancelClickClearHidd() {
           

            if (confirmbox > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href = "gen_Insurance_Master.aspx";
                    clearhidd();
                    clearHidden();
                    clearHiddenTemp();

                    return true;
                }
                else {
                    return false;
                }
            }
            else {
               // window.location.href = "gen_Insurance_Master.aspx";
                clearhidd();
                clearHidden();
                clearHiddenTemp();
                return true;
            }
            return false;


        }

        function clearHiddenTemp() {
            IncrmntConfrmCounter();
            document.getElementById("<%=hiddenDivisionddlData.ClientID%>").value = 0;
            document.getElementById("<%=hiddenDesignationddlData.ClientID%>").value = 0;
            document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value = 0;
            return ret;
        }

        function clearHidden() {
            IncrmntConfrmCounter();
            document.getElementById("<%=hiddenDivisionddlData.ClientID%>").value = 0;
            document.getElementById("<%=hiddenDesignationddlData.ClientID%>").value = 0;
            document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value = 0;
            document.getElementById("<%=hiddenTemplateChange.ClientID%>").value = "CHANGED";
            InitialiseCount();
            return true;
        }

        function AlertClearAll() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want clear all data in this page?")) {
                    window.location.href = "gen_Insurance_Master.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_Insurance_Master.aspx";
                return false;
            }
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

        function AmountChecking(textboxid) {
            var txtPerVal = document.getElementById(textboxid).value;

            txtPerVal = txtPerVal.replace(/,/g, "");

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
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);
                    }
                    document.getElementById('' + textboxid + '').value = n;

                }
            }

            addCommas();
        }



        function isNumber(evt, textboxid) {
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
                if (textboxid == "cphMain_txtAmount") {
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
                    return false;
                }

            }

            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                }
                return ret;
            }
        }

        // for not allowing <> tags  and enter
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

        // for not allowing enter
        function DisableEnter(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }

        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

        <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>


     <asp:HiddenField ID="hiddenDup" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenRsnid" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenRoleReOpen" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenRoleConfirm" runat="server" Value="0" />
            <asp:HiddenField ID="hiddenRoleAdd" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenRoleClose" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenCurrentDate" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" Value="0" />
       <asp:HiddenField ID="hiddenConfirmOrNot" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" Value="0" />
         <asp:HiddenField ID="HiddenField2_FileUploadLnk" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenField2_FileUpload" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenValueChangeNtfr" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFileCanclDtlId" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenFieldPrevValueChk" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFieldRefNumber" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenFieldUserId" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenAttchmntSlNumber" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenFilePath" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenBankGuarenteeId" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldValidation" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldCurrcy" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldCustmor" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldMode" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenEditAttchmnt" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldUpdate" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldRefNumber2" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldView" runat="server" Value="0" />
       <asp:HiddenField ID="HiddenFieldPRJCTID" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenGuarStatus" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenRenew" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenTextValidty" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenSearchField" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldRequestCltId" runat="server" Value="0" />
   <asp:HiddenField ID="HiddenFieldAmount" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenImportaddchk" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenOrgansId" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenCorpId" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenUserId" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenDuplictnchk" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenDeleteSliceData" runat="server" Value="0" />
   <asp:HiddenField ID="hiddenTemplateLoadingMode" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenTemplateChange" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenExpireDate" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenValidatedays" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenRFGImportedGtee" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenFieldGuarntId" runat="server" Value="0" />
      <asp:HiddenField ID="HiddenGurntNumDupChk" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenNewProjectId" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenRoleAddProjct" runat="server" Value="0" />
      <asp:HiddenField ID="HiddenProjctsave" runat="server" Value="0" />


       <div class="cont_rght">
        
        <div id="divMessageArea" style="display: none; margin: 0px 0 13px;">
            <img id="imgMessageArea" src="">
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 0%; top: 22%; height: 26.5px;">
        </div>
    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
        <div class="fillform" style="width: 100%">

        
               
                <div id="divImage" style="float: right;margin-right:3%;margin-top:-7%">
                       <asp:ImageButton ID="imgbtnReOpen" runat="server" OnClientClick="return ConfirmReOpen();" src="/Images/Icons/Reopen.png" Style="margin-left: 0%;" OnClick="imgbtnReOpen_Click"  />
                       <p id="imgReOpen" class="imgDescription" style="color: white">ReOpen Confirmed Entry</p>
                </div>


                <div class="eachform" style="width: 49%; float: left; margin-top: .5%;">
                    <h2 style="margin-left: 8%">Ref*</h2>
                    <asp:Label ID="LabelRefnum" class="form11" runat="server" Style="padding-top:2px; margin-right: 8%;font-family:Calibri;font-size:15px;background-color: #e3e3e3;width: 46%;overflow: hidden;"></asp:Label>   
                </div>

               <div class="eachform" style="width: 49%; float: right;margin-top: .5%;">
                    <h2 style="margin-left: 10%">Insurance Provider*</h2>
                   <div id="divddlInsurncPrvdr" >
 <asp:DropDownList ID="ddlInsurncPrvdr" tabindex="4"  class="form1" Style="float: right; width: 43.4%; margin-right: 10%;" runat="server" AutoPostBack="false" autofocus="autofocus" autocorrect="off" autocomplete="off">
                    </asp:DropDownList>
                   </div>
                   
              </div>
                    
               <div class="eachform" style="width: 49%; float: left; margin-top: .5%;">
                    <h2 style="margin-left: 8%">Insurance No.*</h2>
                      <asp:TextBox ID="txtInsuranceno" tabindex="5"  class="form1" runat="server" MaxLength="90" onblur="return DuplctnGuarntNum();" Style="width: 46%; text-transform: uppercase; margin-right: 8%; height: 30px"></asp:TextBox>
               </div>

                <div class="eachform" style="width: 49%; float: right;margin-top:.5%">
                  <h2 style="margin-left: 10%">Project* </h2>
                    <div id="divProjectsDdl" style="display:block;">
                      <asp:DropDownList ID="ddlProjects" AutoPostBack="false"  class="form1" tabindex="6"  Style="float: left; width: 43.4%; margin-left: 24%;"    runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off" ></asp:DropDownList>
                      <asp:Button ID="btnNewProject" runat="server" class="save" style="margin-left: -0.5%;  padding: 1%;border-radius: 0px;padding-bottom: 1.7%; padding-top:6px;float: left;height: 33px;" ToolTip="Add Project" Text="+" OnClientClick="return NewProjectLoad()" OnClick="btnNewProject_Click" />
                    </div>
                 </div>
                   
                 <div class="eachform" style="width: 100%; float: left; margin-top: .5%;height: 100px;">     
                   <h2 style="margin-left: 4%;margin-top:3%;">Insurance Type *</h2>

                   <div id="Div2" runat="server" style="float:left;width:23.5%;margin-left: 7%;padding: 6px;background-color: #e1e1e1;">
                       
                      <div style="width:49%;float:left;margin-left: 0%;">
                        <img src="/Images/Icons/Open_Guarantee.png" alt="X" style="margin-left: 33%; margin-top: 0%; float:left"/>
                            <div style="width:51%;float:left;margin-left: 25%;">
                          <input id="radioOpen" type="radio" runat="server" tabindex="7" onchange="RadioopenClick()" name="radTypenxt" onkeypress="return DisableEnter(event)"  />
                                <label style="font-family:Calibri" for="cphMain_radioOpen">Open</label>
                            </div>
                      </div>

                      <div style="width:49%;float:left;margin-left: 0%;">
                          <img src="/Images/Icons/Closed_Guarantee.png" alt="X" style="margin-left: 21%; margin-top: 0%; "/>
                            <div style="width:59%;float:left;margin-left: 15%;">
                             <input id="radioLimited" type="radio" runat="server"  tabindex="8" onchange="RadioLimitedClick()" name="radTypenxt" onkeypress="return DisableEnter(event)" />
                                <label style="font-family:Calibri" for="cphMain_radioLimited">Limited</label>
                            </div>
                      </div>
                      
                    </div>      
                </div>
                        
                 <div class="eachform" style="width: 49%; float: left;margin-top:1%">
                  <h2 style="margin-left: 8%">Amount * </h2>
                    <asp:TextBox ID="txtAmount" TabIndex="9" class="form1" runat="server" MaxLength="12" Style="width: 47%; text-transform: uppercase;text-align:right; margin-right: 8%; height: 30px" onkeydown="return isNumber(event,'cphMain_txtAmount');" onkeyup="addCommas()" onblur="AmountChecking('cphMain_txtAmount');"></asp:TextBox>
                </div>

                <div id="divCurrency" class="eachform" style="width: 49%; float: right; margin-top: 1%;">
                    <h2 style="margin-left: 10%">Currency *</h2>
                      <div id="CurrencyLabl"  style="width: 62%;float: right;">
                        </div>
                      <div id="Currencyddl" style="width: 62%;float: right;">
                         <asp:DropDownList ID="ddlCurrency" TabIndex="10" class="form1" Style="float: right; width: 77.8% !important; margin-right: 14%;" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                           </asp:DropDownList>
                      </div>
                </div>
               
                <div class="eachform" style="width: 52%; float: left;">
                 <h2 style="margin-left: 7.6%;float:left">Date*</h2>

                   <div id="Div3" class="input-append date" style="font-family:Calibri;float:right;width:50%;margin-right:7%;margin-top: 1%;">
                      <asp:TextBox ID="txtOpngDate" TabIndex="11" class="textDate form1" onkeypress="return isTag(event)" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onblur="return TextDateChange()" Style="width:44.8%;height:27px; font-family: calibri;float: left;margin-left: -7%;" ></asp:TextBox>
                      <input type="image" id= "img2" runat="server" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return TextDateChange()" style=" height:19px;float:left; width:12px; cursor:pointer;" />

                   <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
                   <script src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
                   <script src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
                   <script src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
                   <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                   <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                        <script type="text/javascript">
                            var $noC2 = jQuery.noConflict();
                            $noC2('#Div3').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //startDate: new Date(),


                            });
                            function FocusDate() {

                                $noC2('#Div3').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    // startDate: new Date(),


                                });
                            }
                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>
                  <asp:TextBox ID="txtValidity" TabIndex="12" class="form1" placeholder="No. Of Days" runat="server"  MaxLength="8"  Style="width: 7%;text-align:right; text-transform: uppercase; /*! margin-right: 1.7%; */ height: 29px;float:left;margin-left: -15.5%;margin-top: 4px;"></asp:TextBox>
                  

              <div id="divProjectClosingDate" class="eachform" runat="server" style="width: 48%;float:right">
                 <h2 id="Project_Closing_Date" style="font-size:17px;margin-left:8%" runat="server">Expiry Date*</h2>
                 
                  <div id="ClosingDate" class="input-append date" style="font-family:Calibri;float:right;width:52%;margin-right:6%;margin-top: 1%;">
                  
                      <asp:TextBox ID="txtPrjctClsngDate" TabIndex="13" class="textDate form1" placeholder="DD-MM-YYYY" onkeypress="return isTag(event);" MaxLength="20" runat="server" onblur="return TextDateChange()" Style="width:78.8%;height:27px; font-family: calibri;float: left;" ></asp:TextBox>
                      <input type="image" id="img1" runat="server" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return TextDateChange()" style=" height:19px;float:left; width:12px; cursor:pointer;" />

                   <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
                   <script src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
                   <script src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
                   <script src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
                   <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                   <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                        <script type="text/javascript">
                            var $noC2 = jQuery.noConflict();
                            $noC2('#ClosingDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                // startDate: new Date(),


                            });
                            function FocusOnDate() {

                                $noC2('#ClosingDate').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    //  startDate: new Date(),


                                });
                            }
                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>

               <div class="eachform" style="width:100%; float: left;margin-top:0.5%">
                  <h2 style="margin-left: 4%">Description </h2>
                    <asp:TextBox ID="txtDescrptn" TabIndex="17" class="form1" runat="server" TextMode="MultiLine" MaxLength="950" onkeydown="textCounter(cphMain_txtDescrptn,1950)" onkeyup="textCounter(cphMain_txtDescrptn,950)" Style="resize:none; width: 74%;height:100px;font-family:Calibri; margin-right: 4%;"></asp:TextBox>
               </div>

               <div class="eachform" style="width: 49%; float: left;margin-top:0%">
                   <div class="subform" style="width: 30%; margin-right: 27.5%; padding-top: 7px;">
                       <span>
                          <asp:CheckBox ID="cbxExistingEmployee" TabIndex="18" Text="" onkeypress="return isTag(event);" runat="server" Checked="true" onchange="CbxChange()" class="form2" />
                          <label style="color: rgb(135, 146, 116); font-family: Calibri;" for="cphMain_cbxExistingCustomer">Select Employee</label>
                       </span>
                   </div>
                </div>
                
                   
                 <div id="divContactPersn" class="eachform" style="width: 52%; float: left">
                            <h2 style="margin-left: 7.6%">Contact Person </h2>
                            <div style="width: 57.5%; float: right;">
                                <div id="divNewEmp">
                                    <asp:TextBox ID="txtEmpName" TabIndex="19" class="form1" runat="server" MaxLength="45" onblur="RemoveTag(this)" Style="float: left; width: 80%!important; margin-left: -5.5%; text-transform: uppercase;"></asp:TextBox>
                                 </div>

                                <div id="divExistingEmp">
                                    <asp:DropDownList ID="ddlExistingEmp" TabIndex="20" class="form1"  Style="float: left; width: 83% !important; margin-left: -5.5%;" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off" >
                                    </asp:DropDownList>
                               </div>
                            </div>
                  </div>

                <div class="eachform" style="width: 49%; float: right;margin-top:-3.5%">
                  <h2 style="margin-left:10%">Contact Person Email </h2>
                    <asp:TextBox ID="txtCntctMail" TabIndex="21" onkeypress="return isTag(event);" class="form1" runat="server" MaxLength="90" Style="width:45%; margin-right: 8%; height: 30px"></asp:TextBox>
                </div>
               
               <div id="divfleupld" class="eachform"  style="width: 100%; float: left">

                 <h2  style="margin-left: 4%;margin-top: 3%;">Attachments </h2>
                  <div id="divfileupl" class="form-group"  style="margin-top: -4%;float: left;width: 73%; height: 97px;overflow: auto;margin-left: 20.5%;border: 1px solid rgb(207, 204, 204);font-family: Calibri;background-color: white;padding: 13px;">
                     <div id="divFileuploadScroll"  style="margin-top:1%;float:right;margin-right:2.5%; width:95.5%;max-height: 265px;overflow: auto;">
                        <table id="TableFileUploadContainer" style="width: 99%;">
                        </table>
                        <br />
                     </div>
                     <div id="div1" style="margin-top:1%;float:right;margin-right:2.5%; width:65.5%;max-height: 265px;overflow: auto;">
                        <table id="Table1" style="width: 99%;">
                        </table>
                        <br />
                     </div>   
                 </div>
                    
               </div>


             <div  class="eachform"  style="display:none; width: 49%; float: left;margin-top:0.5%; ">
                 <label for="cphMain_FileUploadProPic" class="custom-file-upload" tabindex="">
                    <img src="../../Images/Icons/cloud_upload.jpg" />Upload File</label>
                    <asp:FileUpload ID="FileUploadProPic" class="fileUpload"  runat="server" Style="height: 30px; display:none;" onchange="ClearDivDisplayImage()" Accept="image/png, image/gif, image/jpeg" />
                    <asp:Label ID="Label1" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
             </div>


              <%--for notification template--%>

      <asp:UpdatePanel ID="updPanelTempl" runat="server" EnableViewState="true" UpdateMode="Conditional">
       <ContentTemplate>
                           
     <asp:HiddenField ID="hiddenTemplateCount" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenTemplateAlertData" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenEditMode" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenDivisionddlData" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenDesignationddlData" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenEmployeeDdlData" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenNotificationDuration" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenNotificationMOde" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenNotifyVia" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenEachTemplateDetail" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenEachSliceData" runat="server" Value="0" />
                        

                 <div class="eachform" style="width: 100%; float: left;margin-top:0%">
                   <h2 style="margin-left: 4%;margin-top: 2%;">Template* </h2>
                    <div class="subform" style="width: 52%; margin-right: 27.5%; padding-top: 7px;">
                      <div  style="float: left;width: 55%;margin-top: 2%;">
                         <asp:DropDownList ID="ddlTemplate" TabIndex="23" AutoPostBack="true" class="form1" Style=" width: 93% !important; margin-left: 0%;float: left;" runat="server" onchange="clearHidden()" autofocus="autofocus" autocorrect="off" autocomplete="off" OnSelectedIndexChanged="ddlTemplate_SelectedIndexChanged" >
                         </asp:DropDownList>
                        </div>
                        <div style="float: left;border: 1px solid;width: 67px;border-color: #6a8a32;background-color: #e0efee;">
                            <div style="width:100%;padding: 3px;float: left;">
                                <label style="font-family: calibri;font-size: 12px;color: #a50505;">Don't Notify</label>
                            </div>
                             <label for="cphMain_cbxDontNotify"><img src="/Images/Icons/DontNotify.png" style="margin-left: 8px;margin-bottom: 3px;" /></label>
                            <span>
                              <asp:CheckBox ID="cbxDontNotify" TabIndex="24" runat="server" onchange="CbxChange()" onkeypress="return DisableEnter(event)" />
                               
                            </span>
                        </div>
                    </div>
                </div>
                   

              <div class="eachform"  style="width: 95%; float: left;margin-top:2.5%; margin-left: 2.5%;background-color: white;">
                 <div id="DivTemplateContainer" style="width:86%;min-height:200px;padding: 25px;margin-top: 3%;background-color: #e0efee;margin-left: 4%;margin-bottom: 3%;" >
                    <table id="TableTemplateContainer" style="width: 100%;">
                    
                     </table>
                </div>
              </div>

             </ContentTemplate>
          </asp:UpdatePanel>



               <div class="eachform" style="width: 99%; margin-top: 3%; float: left">
                   <div class="subform" style="width: 70%; margin-left: 38%">

                    <asp:Button ID="btnConfirm" TabIndex="24" runat="server" class="save" Text="Confirm" OnClientClick="return ConfirmAlert();" OnClick="btnConfirm_Click"/>
                    <asp:Button ID="btnUpdate" TabIndex="25" runat="server" class="save" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click"/>
                    <asp:Button ID="btnUpdateClose" TabIndex="26" runat="server" class="save" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click"/>
                    <asp:Button ID="btnAdd"  runat="server" TabIndex="27" class="save" Text="Save" OnClientClick="return Validate();" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnAddClose" TabIndex="28" runat="server" class="save" Text="Save & Close" OnClientClick="return Validate();" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnrenew" TabIndex="29" runat="server"  OnClientClick="return Alertrenew();"  class="save" Text="Renew" OnClick="btnrenew_Click"/>   
                    <asp:Button ID="btnCancel"  TabIndex="30" runat="server" class="cancel" Text="Cancel"  OnClientClick="return cancelClickClearHidd();" OnClick="btnCancel_Click" />
                    <asp:Button ID="btnClear" TabIndex="31" runat="server" style="margin-left: 19px;" OnClientClick="return AlertClearAll();"  class="cancel" Text="Clear"/>

                   </div>
               </div>


       </div>

      </div>

    <style>
        .open > .dropdown-menu {
            display: none;
        }
    </style>
</asp:Content>

