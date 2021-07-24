<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="gen_Corp_Office.aspx.cs"  Inherits="Master_gen_Corp_Ofiice_gen_Corp_OfficeAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
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
        }
        function CheckSubmitZero() {
            submit = 0;
        }
    </script>
     <script>
         var $au = jQuery.noConflict();
         $au(function () {
             $au('#cphMain_ddlCorpCountry').selectToAutocomplete1Letter();
             $au('#cphMain_ddlFiscalMonth').selectToAutocomplete1Letter();
             $au('#cphMain_ddlParent').selectToAutocomplete1Letter();
         });
    </script>
     <script>

         //start-0006
         var confirmbox = 0;

         function IncrmntConfrmCounter() {
             confirmbox++;
         }
         function ConfirmMessage() {
             if (confirmbox > 0) {
                 ezBSAlert({
                     type: "confirm",
                     messageText: "Do you want to leave this page?",
                     alertType: "info"
                 }).done(function (e) {
                     if (e == true) {
                         window.location.href = "gen_Corp_OfficeList.aspx";
                     }
                     else {
                         return false;
                     }
                 });
                 return false;
             }
             else {
                 window.location.href = "gen_Corp_OfficeList.aspx";

             }
         }
         function ConfirmCancel() {
             if (confirmbox > 0) {

                 ezBSAlert({
                     type: "confirm",
                     messageText: "Do you want to clear all the data from this page?",
                     alertType: "info"
                 }).done(function (e) {
                     if (e == true) {
                         window.location.href = "gen_Corp_OfficeList.aspx";
                         return false;
                     }
                     else {
                         return false;
                     }
                 });
                 return false;
             }
             else {

                 window.location.href = "gen_Corp_OfficeList.aspx";
                 return false
                
             }
         }

         //stop-0006
    </script>
    <style>
   
         .error {
              
               color: red;
               font-size: small;
                font-family: Calibri;
           }       
          /* Styles the thumbnail */
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
            z-index: 3;
            right: 18%;
            z-index: 2000;
        }

            .lightbox-target:target img {
                max-height: 100%;
                max-width: 80%;
            }

            .lightbox-target:target a.lightbox-close {
                top: 0px;
            }
    </style>
    
     <style type="text/css">
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
    </style>
   

 <%--   <script src="../../JavaScript/TimePicker/jquery.timepicker.js"></script>
    <link href="../../JavaScript/TimePicker/jquery.timepicker.css" rel="stylesheet" />--%>
     <script>
         //start-0006
         var $noCon = jQuery.noConflict();
         $noCon(window).load(function () {
           
            
             localStorage.clear();


             var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;
             var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;
            
          if (EditVal != "") {
            
              ChangeBsnsType();
              ChangeOfficeType();
                 if (document.getElementById("<%=hiddenEditPrmtAttchmnt.ClientID%>").value != "") {
                    var EditAttchmnt = document.getElementById("<%=hiddenEditPrmtAttchmnt.ClientID%>").value;
                    // alert('editval' + EditAttchmnt);
                    //        var findAtt1 = '\\\\';
                    //        var reAtt1 = new RegExp(findAtt1, 'g');
                    //        var resAtt1 = EditAttchmnt.replace(reAtt1, '');

                    var findAtt2 = '\\"\\[';
                    var reAtt2 = new RegExp(findAtt2, 'g');
                    var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                    var findAtt3 = '\\]\\"';
                    var reAtt3 = new RegExp(findAtt3, 'g');
                    var resAtt3 = resAtt2.replace(reAtt3, '\]');
                    //alert(res3);
                    var jsonAtt = $noCon.parseJSON(resAtt3);
                    for (var key in jsonAtt) {
                        if (jsonAtt.hasOwnProperty(key)) {
                            if (jsonAtt[key].TransDtlId != "") {

                                //   alert(jsonAtt[key].ActualFileName);
                                EditAttachmentPer(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                //  alert(json[key].Amount);
                            }
                        }
                    }


                }



                if (document.getElementById("<%=hiddenEditInsurAttchmnt.ClientID%>").value != "") {
                       var EditAttchmnt = document.getElementById("<%=hiddenEditInsurAttchmnt.ClientID%>").value;
                    // alert('editval' + EditAttchmnt);
                    //        var findAtt1 = '\\\\';
                    //        var reAtt1 = new RegExp(findAtt1, 'g');
                    //        var resAtt1 = EditAttchmnt.replace(reAtt1, '');

                    var findAtt2 = '\\"\\[';
                    var reAtt2 = new RegExp(findAtt2, 'g');
                    var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                    var findAtt3 = '\\]\\"';
                    var reAtt3 = new RegExp(findAtt3, 'g');
                    var resAtt3 = resAtt2.replace(reAtt3, '\]');
                    //alert(res3);
                    var jsonAtt = $noCon.parseJSON(resAtt3);
                    for (var key in jsonAtt) {
                        if (jsonAtt.hasOwnProperty(key)) {
                            if (jsonAtt[key].TransDtlId != "") {

                                //   alert(jsonAtt[key].ActualFileName);
                                EditAttachmentIns(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                //  alert(json[key].Amount);
                            }
                        }
                    }


                }



                if (document.getElementById("<%=hiddenEditVhclAttchmnt.ClientID%>").value != "") {
                       var EditAttchmnt = document.getElementById("<%=hiddenEditVhclAttchmnt.ClientID%>").value;
                    // alert('editval' + EditAttchmnt);
                    //        var findAtt1 = '\\\\';
                    //        var reAtt1 = new RegExp(findAtt1, 'g');
                    //        var resAtt1 = EditAttchmnt.replace(reAtt1, '');

                    var findAtt2 = '\\"\\[';
                    var reAtt2 = new RegExp(findAtt2, 'g');
                    var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                    var findAtt3 = '\\]\\"';
                    var reAtt3 = new RegExp(findAtt3, 'g');
                    var resAtt3 = resAtt2.replace(reAtt3, '\]');
                    //alert(res3);
                    var jsonAtt = $noCon.parseJSON(resAtt3);
                    for (var key in jsonAtt) {
                        if (jsonAtt.hasOwnProperty(key)) {
                            if (jsonAtt[key].TransDtlId != "") {

                                //   alert(jsonAtt[key].ActualFileName);
                                EditAttachmentVhcl(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                //  alert(json[key].Amount);
                            }
                        }
                    }


                }

                 AddFileUploadPer();
                 AddFileUploadIns();
                 AddFileUploadVhcl();
                 
                 
                 //edit table partnership
              var EditValP = document.getElementById("<%=HiddenField3.ClientID%>").value;
              if (EditValP != "[]") {
                  var find2 = '\\"\\[';
                  var re2 = new RegExp(find2, 'g');
                  var res2 = EditValP.replace(re2, '\[');

                  var find3 = '\\]\\"';
                  var re3 = new RegExp(find3, 'g');
                  var res3 = res2.replace(re3, '\]');
                  //   alert('res3' + res3);
                  var json = $noCon.parseJSON(res3);
                  for (var key in json) {
                      if (json.hasOwnProperty(key)) {
                          if (json[key].TransId != "") {


                              EditListRows(json[key].PartnerName, json[key].DocumentNo, json[key].SharePer, json[key].TransDtlId, json[key].PartnerId, json[key].Status);

                          }
                      }
                  }
              }
              else {
                 
                  addMoreRows(this.form, false, false, 0);

              }
              //Start:-For Bank details table

                 var EditValP = document.getElementById("<%=HiddenFieldEditBankData.ClientID%>").value;
              if (EditValP != "[]") {
                  var find2 = '\\"\\[';
                  var re2 = new RegExp(find2, 'g');
                  var res2 = EditValP.replace(re2, '\[');

                  var find3 = '\\]\\"';
                  var re3 = new RegExp(find3, 'g');
                  var res3 = res2.replace(re3, '\]');
                  var json = $noCon.parseJSON(res3);
                  for (var key in json) {
                      if (json.hasOwnProperty(key)) {
                          if (json[key].TransId != "") {

                              EditListRowsBank(json[key].BankId, json[key].Branch, json[key].IBAN, json[key].TransDtlId, 0, json[key].BankName, json[key].BankStatus);

                          }
                      }
                  }
              }
              else {

                  addMoreRowsBank(this.form, false, false, 0);
              }
               

              //End:-For Bank details table
               }




             else if (ViewVal != "") {

                

                 if (document.getElementById("<%=hiddenEditPrmtAttchmnt.ClientID%>").value != "") {
                     var EditAttchmnt = document.getElementById("<%=hiddenEditPrmtAttchmnt.ClientID%>").value;
                     //alert('editval' + EditAttchmnt);
                     //        var findAtt1 = '\\\\';
                     //        var reAtt1 = new RegExp(findAtt1, 'g');
                     //        var resAtt1 = EditAttchmnt.replace(reAtt1, '');

                     var findAtt2 = '\\"\\[';
                     var reAtt2 = new RegExp(findAtt2, 'g');
                     var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                     var findAtt3 = '\\]\\"';
                     var reAtt3 = new RegExp(findAtt3, 'g');
                     var resAtt3 = resAtt2.replace(reAtt3, '\]');
                     //alert(res3);
                     var jsonAtt = $noCon.parseJSON(resAtt3);
                     for (var key in jsonAtt) {
                         if (jsonAtt.hasOwnProperty(key)) {
                             if (jsonAtt[key].TransDtlId != "") {

                                 //   alert(jsonAtt[key].ActualFileName);
                                 ViewAttachmentPer(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                 //  alert(json[key].Amount);
                             }
                         }
                     }


                 }



                 if (document.getElementById("<%=hiddenEditInsurAttchmnt.ClientID%>").value != "") {
                     var EditAttchmnt = document.getElementById("<%=hiddenEditInsurAttchmnt.ClientID%>").value;
                     //alert('editval' + EditAttchmnt);
                     //        var findAtt1 = '\\\\';
                     //        var reAtt1 = new RegExp(findAtt1, 'g');
                     //        var resAtt1 = EditAttchmnt.replace(reAtt1, '');

                     var findAtt2 = '\\"\\[';
                     var reAtt2 = new RegExp(findAtt2, 'g');
                     var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                     var findAtt3 = '\\]\\"';
                     var reAtt3 = new RegExp(findAtt3, 'g');
                     var resAtt3 = resAtt2.replace(reAtt3, '\]');
                     //alert(res3);
                     var jsonAtt = $noCon.parseJSON(resAtt3);
                     for (var key in jsonAtt) {
                         if (jsonAtt.hasOwnProperty(key)) {
                             if (jsonAtt[key].TransDtlId != "") {

                                 //   alert(jsonAtt[key].ActualFileName);
                                 ViewAttachmentIns(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                 //  alert(json[key].Amount);
                             }
                         }
                     }


                 }



                 if (document.getElementById("<%=hiddenEditVhclAttchmnt.ClientID%>").value != "") {
                     var EditAttchmnt = document.getElementById("<%=hiddenEditVhclAttchmnt.ClientID%>").value;
                     // alert('editval' + EditAttchmnt);
                     //        var findAtt1 = '\\\\';
                     //        var reAtt1 = new RegExp(findAtt1, 'g');
                     //        var resAtt1 = EditAttchmnt.replace(reAtt1, '');

                     var findAtt2 = '\\"\\[';
                     var reAtt2 = new RegExp(findAtt2, 'g');
                     var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                     var findAtt3 = '\\]\\"';
                     var reAtt3 = new RegExp(findAtt3, 'g');
                     var resAtt3 = resAtt2.replace(reAtt3, '\]');
                     //alert(res3);
                     var jsonAtt = $noCon.parseJSON(resAtt3);
                     for (var key in jsonAtt) {
                         if (jsonAtt.hasOwnProperty(key)) {
                             if (jsonAtt[key].TransDtlId != "") {

                                 //   alert(jsonAtt[key].ActualFileName);
                                 ViewAttachmentVhcl(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                 //  alert(json[key].Amount);
                             }
                         }
                     }


                 }


                 //start view partnership
                 var EditValP = document.getElementById("<%=HiddenField3.ClientID%>").value;
                 if (EditValP != "") {
                     var find2 = '\\"\\[';
                     var re2 = new RegExp(find2, 'g');
                     var res2 = EditValP.replace(re2, '\[');

                     var find3 = '\\]\\"';
                     var re3 = new RegExp(find3, 'g');
                     var res3 = res2.replace(re3, '\]');
                     //alert(res3);
                     var json = $noCon.parseJSON(res3);
                     for (var key in json) {
                         if (json.hasOwnProperty(key)) {
                             if (json[key].TransId != "") {

                                 ViewListRows(json[key].PartnerName, json[key].DocumentNo, json[key].SharePer, json[key].TransDtlId, json[key].Status);

                             }
                         }
                     }
                 }
                 //stop view partnership

                 //Start:-For Bank details table                 


                 var EditValP = document.getElementById("<%=HiddenFieldEditBankData.ClientID%>").value;
                 if (EditValP != "") {
                     var find2 = '\\"\\[';
                     var re2 = new RegExp(find2, 'g');
                     var res2 = EditValP.replace(re2, '\[');

                     var find3 = '\\]\\"';
                     var re3 = new RegExp(find3, 'g');
                     var res3 = res2.replace(re3, '\]');
                     var json = $noCon.parseJSON(res3);
                     for (var key in json) {
                         if (json.hasOwnProperty(key)) {
                             if (json[key].TransId != "") {

                                 EditListRowsBank(json[key].BankId, json[key].Branch, json[key].IBAN, json[key].TransDtlId, 1);

                             }
                         }
                     }

                 }

                 //End:-For Bank details table




             }
             else {
                 
                 AddFileUploadPer();
                 AddFileUploadIns();
                 AddFileUploadVhcl();
                 addMoreRows(this.form, false, false, 0);
                 addMoreRowsBank(this.form, false, false, 0);
             }
             if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {
               
                IncrmntConfrmCounter();
             }


          
         });

        
             function changeTimeChk() {
                 var ChkIn = document.getElementById("<%=txtChkIn.ClientID%>").value.trim();
                     var ChkOut = document.getElementById("<%=txtChkOut.ClientID%>").value.trim();
                     document.getElementById("<%=txtChkIn.ClientID%>").style.borderColor = "";
                     document.getElementById("<%=txtChkOut.ClientID%>").style.borderColor = "";
                    
                     if (ChkOut == ChkIn && ChkIn != "" && ChkOut != "") {                         
                         $("#divWarning").html("Sorry, both Check-in time and Check-out time can't be same!");
                         $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                         });
                         document.getElementById("<%=txtChkOut.ClientID%>").style.borderColor = "Red";
                         document.getElementById("<%=txtChkIn.ClientID%>").style.borderColor = "Red";

                         ret = false;
                     }
                     if (ChkIn != "" && ChkOut != "" && ChkOut != ChkIn) {
                         var Frmatches = ChkIn.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/);
                         var FstChkIn = (parseInt(Frmatches[1]) + (Frmatches[3] == 'pm' ? 12 : 0)) + ':' + Frmatches[2] + ':00';
                         var FromDateTime = dateString2Date('01-01-2016 ' + FstChkIn);

                         var Tomatches = ChkOut.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/);
                         var LstChkOt = (parseInt(Tomatches[1]) + (Tomatches[3] == 'pm' ? 12 : 0)) + ':' + Tomatches[2] + ':00';
                         var ToDateTime = dateString2Date('01-01-2016 ' + LstChkOt);
                         if (FromDateTime > ToDateTime) {
                             document.getElementById("<%=txtChkIn.ClientID%>").style.borderColor = "Red";
                             document.getElementById("<%=txtChkOut.ClientID%>").style.borderColor = "Red";
                             $("#divWarning").html("Sorry, Check-in time cannot be greater than Check-out time!");
                             $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                             });                            
                             ret = false;
                         }
                         
                     }
                 }

    </script>
         <script type="text/javascript">


             var FileCounterPer = 0;
             var FileCounterIns = 100;
             var FileCounterVhcl = 200;
             var FileCounterIcon = 201;
             function AddFileUploadPer() {

                 var FrecRow = '<tr id="FilerowId_' + FileCounterPer + '" >';

                 FrecRow += '<td class=" tr_l">';
                 FrecRow += '<input type="file" id="file' + FileCounterPer + '" name = "file' + FileCounterPer + '" onchange="ChangeFilePer(' + FileCounterPer + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" multiple="" >';
                 FrecRow += '<label for="file' + FileCounterPer + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
                 FrecRow += ' <div id="filePath' + FileCounterPer + '" class="file_n"></div>';
                 FrecRow += '</td>';
                 FrecRow += '<td class=" tr_l"><input id="descrptn' + FileCounterPer + '" MaxLength="50" value="--Description--" onfocus="focusTxtDescrptn(' + FileCounterPer + ');" onkeypress="return DisableEnter(event);"  onblur="blurTxtDescrptnPer(' + FileCounterPer + ');" type="text" class="form-control fg2_inp2" placeholder="Description" name=""></td>';
                 FrecRow += '<td>'; 
                 FrecRow += '<div class="btn_stl1">';
                 FrecRow += '<button id="FileIndvlAddMoreRow' + FileCounterPer + '" onclick="return CheckaddMoreRowsIndividualFilesPer(' + FileCounterPer + ');" class="btn act_btn bn2"  title="Add">';
                 FrecRow += '<i class="fa fa-plus-circle"></i>';
                 FrecRow += ' </button>';
                 FrecRow += '<button id="FieldId' + FileCounterPer + '" class="btn act_btn bn3"  title="Delete" onclick = "return RemoveFileUploadPer(' + FileCounterPer + ');">';
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

                 jQuery('#TableFileCRN').append(FrecRow);

                 // $noCon('#divPerAtch').scrollTop($noCon('#divPerAtch')[0].scrollHeight);

                 //var objDiv = document.getElementById('divPerAtch');
                 //objDiv.scrollTop = objDiv.scrollHeight;


                 document.getElementById('filePath' + FileCounterPer).innerHTML = 'No File Uploaded';

                 FileCounterPer++;

             }

             //new code
             function AddFileUploadIcon() {

                 var FrecRow = '<tr id="FilerowId_' + FileCounterIcon + '" >';


                 var labelForStyle = '<label  for="file' + FileCounterIcon + '" class="custom-file-upload" style="margin-left: 0%;"> <img src="/Images/Icons/cloud_upload.jpg"></img>Upload Icon</label>';
                 var tdInner = labelForStyle + '<input   id="file' + FileCounterIcon + '" name = "file' + FileCounterIcon +

                                '" type="file" onchange="ChangeFileIcon(' + FileCounterIcon + ');" accept="image/*"/>';

                 FrecRow += '<td  style="width: 28%;" >' + tdInner + '</td>';

                 FrecRow += '<td  style="word-break: break-all;width:30%;" id="filePath' + FileCounterIcon + '"  ></td  >';

                 //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

                 //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';
               
               
                 FrecRow += ' <td id="FileInx' + FileCounterIcon + '" style="display: none;" > </td>';
                 FrecRow += '<td id="FileSave' + FileCounterIcon + '" style="display: none;"> </td>';
                 FrecRow += '<td id="FileEvt' + FileCounterIcon + '" style="display: none;">INS</td>';
                 FrecRow += '<td id="FileDtlId' + FileCounterIcon + '" style="display: none;"></td>';
                 FrecRow += '<td id="DbFileName' + FileCounterIcon + '" style="display: none;"></td>';
                 FrecRow += '</tr>';

                 jQuery('#TableFileIcon').append(FrecRow);

                 // $noCon('#divPerAtch').scrollTop($noCon('#divPerAtch')[0].scrollHeight);

                 //var objDiv = document.getElementById('divPerAtch');
                 //objDiv.scrollTop = objDiv.scrollHeight;


                 document.getElementById('filePath' + FileCounterIcon).innerHTML = 'No File Uploaded';

                 

             }

             //new code

             //start edit icon

             function EditAttachmentIcon() {
                 
                
                 var EditFileName = document.getElementById("<%=HiddenField4.ClientID%>").value;
                 var EditActualFileName = document.getElementById("<%=HiddenField5.ClientID%>").value;
                
                 
                 var FrecRow = '<tr id="FilerowId_' + FileCounterIcon + '" >';


                 var labelForStyle = '<label for="file' + FileCounterIcon + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
                 var tdInner = labelForStyle + '<input   id="file' + FileCounterIcon + '" name = "file' + FileCounterIcon +

                                '" type="file" onchange="ChangeFileIcon(' + FileCounterIcon + ')" />';

                 FrecRow += '<td style="width: 25%; display:none;" >' + tdInner + '</td>';

                 var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

                 FrecRow += '<td colspan="2"  id="filePath' + FileCounterIcon + '" style="border-bottom: 0px dotted rgb(205, 237, 196);"' + '  >' + tdFileNameEdit + '</td  >';


                 FrecRow += ' <td id="FileInx' + FileCounterIcon + '" style="display: none;" > </td>';
                 FrecRow += '<td id="FileSave' + FileCounterIcon + '" style="display: none;"> </td>';
                 FrecRow += '<td id="FileEvt' + FileCounterIcon + '" style="display: none;">UPD</td>';
                 
                 FrecRow += '<td id="DbFileName' + FileCounterIcon + '" style="display: none;">' + EditFileName + '</td>';
                 FrecRow += '</tr>';

                 jQuery('#TableFileIcon').append(FrecRow);
               
             }


             //stop edit icon

             function EditAttachmentPer(editTransDtlId, EditFileName, EditActualFileName, EditDescription) {

                 if (EditDescription == "") {
                     EditDescription = "--Description--";
                 }
                 var FrecRow = '<tr id="FilerowId_' + FileCounterPer + '" >';
                 var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';
                 FrecRow += '<td class=" tr_l">';
                 FrecRow += '<input style="display:none;" type="file" id="file' + FileCounterPer + '" name = "file' + FileCounterPer + '" onchange="ChangeFilePer(' + FileCounterPer + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" multiple="" >';
                 FrecRow += '<label style="display:none;" for="file' + FileCounterPer + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
                 FrecRow += ' <div id="filePath' + FileCounterPer + '" class="file_n">' + tdFileNameEdit + '</div>';
                 FrecRow += '</td>';
                 FrecRow += '<td class=" tr_l"><input id="descrptn' + FileCounterPer + '" MaxLength="50" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterPer + ');" onkeypress="return DisableEnter(event);"  onblur="blurTxtDescrptnPer(' + FileCounterPer + ');" type="text" class="form-control fg2_inp2" placeholder="Description" name=""></td>';
                 FrecRow += '<td>';
                 FrecRow += '<div class="btn_stl1">';
                 FrecRow += '<button disabled id="FileIndvlAddMoreRow' + FileCounterPer + '" onclick="return CheckaddMoreRowsIndividualFilesPer(' + FileCounterPer + ');" class="btn act_btn bn2"  title="Add">';
                 FrecRow += '<i class="fa fa-plus-circle"></i>';
                 FrecRow += ' </button>';
                 FrecRow += '<button id="FieldId' + FileCounterPer + '" class="btn act_btn bn3"  title="Delete" onclick = "return RemoveFileUploadPer(' + FileCounterPer + ');">';
                 FrecRow += '<i class="fa fa-trash"></i>';
                 FrecRow += '</button>';
                 FrecRow += '</div>';
                 FrecRow += '</td>';


             
             FrecRow += ' <td id="FileInx' + FileCounterPer + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterPer + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterPer + '" style="display: none;">UPD</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterPer + '" style="display: none;">' + editTransDtlId + '</td>';
             FrecRow += '<td id="DbFileName' + FileCounterPer + '" style="display: none;">' + EditFileName + '</td>';
             FrecRow += '</tr>';

             jQuery('#TableFileCRN').append(FrecRow);
             document.getElementById("FileInx" + FileCounterPer).innerHTML = FileCounterPer;
             //document.getElementById("FileIndvlAddMoreRow" + FileCounterPer).style.opacity = "0.3";
             // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
             FileLocalStorageAddPer(FileCounterPer);
             FileCounterPer++;

         }





            



         function EditAttachmentIns(editTransDtlId, EditFileName, EditActualFileName, EditDescription) {

             if (EditDescription == "") {
                 EditDescription = "--Description--";
             }
             var FrecRow = '<tr id="FilerowId_' + FileCounterIns + '" >';

             var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';
               FrecRow += '<td class=" tr_l">';
               FrecRow += '<input style="display:none;" type="file" id="file' + FileCounterIns + '" name = "file' + FileCounterIns + '" onchange="ChangeFileIns(' + FileCounterIns + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" multiple="" >';
               FrecRow += '<label style="display:none;" for="file' + FileCounterIns + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
               FrecRow += ' <div id="filePath' + FileCounterIns + '" class="file_n">' + tdFileNameEdit + '</div>';
               FrecRow += '</td>';
               FrecRow += '<td class=" tr_l"><input id="descrptn' + FileCounterIns + '" MaxLength="50" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterIns + ');" onkeypress="return DisableEnter(event);"  onblur="blurTxtDescrptnIns(' + FileCounterIns + ');" type="text" class="form-control fg2_inp2" placeholder="Description" name=""></td>';
               FrecRow += '<td>';
               FrecRow += '<div class="btn_stl1">';
               FrecRow += '<button disabled id="FileIndvlAddMoreRow' + FileCounterIns + '" onclick="return CheckaddMoreRowsIndividualFilesIns(' + FileCounterIns + ');" class="btn act_btn bn2"  title="Add">';
               FrecRow += '<i class="fa fa-plus-circle"></i>';
               FrecRow += ' </button>';
               FrecRow += '<button id="FieldId' + FileCounterIns + '" class="btn act_btn bn3"  title="Delete" onclick = "return RemoveFileUploadIns(' + FileCounterIns + ');">';
               FrecRow += '<i class="fa fa-trash"></i>';
               FrecRow += '</button>';
               FrecRow += '</div>';
               FrecRow += '</td>';


           FrecRow += ' <td id="FileInx' + FileCounterIns + '" style="display: none;" > </td>';
           FrecRow += '<td id="FileSave' + FileCounterIns + '" style="display: none;"> </td>';
           FrecRow += '<td id="FileEvt' + FileCounterIns + '" style="display: none;">UPD</td>';
           FrecRow += '<td id="FileDtlId' + FileCounterIns + '" style="display: none;">' + editTransDtlId + '</td>';
           FrecRow += '<td id="DbFileName' + FileCounterIns + '" style="display: none;">' + EditFileName + '</td>';
           FrecRow += '</tr>';

           jQuery('#TableFileTIN').append(FrecRow);
           document.getElementById("FileInx" + FileCounterIns).innerHTML = FileCounterIns;
          // document.getElementById("FileIndvlAddMoreRow" + FileCounterIns).style.opacity = "0.3";
             // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
           FileLocalStorageAddIns(FileCounterIns);
           FileCounterIns++;

       }

       function EditAttachmentVhcl(editTransDtlId, EditFileName, EditActualFileName, EditDescription) {

           if (EditDescription == "") {
               EditDescription = "--Description--";
           }
           var FrecRow = '<tr id="FilerowId_' + FileCounterVhcl + '" >';

           var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

             FrecRow += '<td class=" tr_l">';
             FrecRow += '<input style="display:none;" type="file" id="file' + FileCounterVhcl + '" name = "file' + FileCounterVhcl + '" onchange="ChangeFileVhcl(' + FileCounterVhcl + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" multiple="" >';
             FrecRow += '<label style="display:none;" for="file' + FileCounterVhcl + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
             FrecRow += ' <div id="filePath' + FileCounterVhcl + '" class="file_n">' + tdFileNameEdit + '</div>';
             FrecRow += '</td>';
             FrecRow += '<td class=" tr_l"><input id="descrptn' + FileCounterVhcl + '" MaxLength="50" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterVhcl + ');" onkeypress="return DisableEnter(event);"  onblur="blurTxtDescrptnVhcl(' + FileCounterVhcl + ');" type="text" class="form-control fg2_inp2" placeholder="Description" name=""></td>';
             FrecRow += '<td>';
             FrecRow += '<div class="btn_stl1">';
             FrecRow += '<button disabled id="FileIndvlAddMoreRow' + FileCounterVhcl + '" onclick="return CheckaddMoreRowsIndividualFilesVhcl(' + FileCounterVhcl + ');" class="btn act_btn bn2"  title="Add">';
             FrecRow += '<i class="fa fa-plus-circle"></i>';
             FrecRow += ' </button>';
             FrecRow += '<button id="FieldId' + FileCounterVhcl + '" class="btn act_btn bn3"  title="Delete" onclick = "return RemoveFileUploadVhcl(' + FileCounterVhcl + ');">';
             FrecRow += '<i class="fa fa-trash"></i>';
             FrecRow += '</button>';
             FrecRow += '</div>';
             FrecRow += '</td>';



             FrecRow += ' <td id="FileInx' + FileCounterVhcl + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterVhcl + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterVhcl + '" style="display: none;">UPD</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterVhcl + '" style="display: none;">' + editTransDtlId + '</td>';
             FrecRow += '<td id="DbFileName' + FileCounterVhcl + '" style="display: none;">' + EditFileName + '</td>';
             FrecRow += '</tr>';

             jQuery('#TableFileCCN').append(FrecRow);
             document.getElementById("FileInx" + FileCounterVhcl).innerHTML = FileCounterVhcl;
             //document.getElementById("FileIndvlAddMoreRow" + FileCounterVhcl).style.opacity = "0.3";
             // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
             FileLocalStorageAddVhcl(FileCounterVhcl);
             FileCounterVhcl++;

         }

         function ViewAttachmentPer(editTransDtlId, EditFileName, EditActualFileName, EditDescription) {
             if (EditDescription == "") {
                 EditDescription = "--Description--";
             }
             var FrecRow = '<tr id="FilerowId_' + FileCounterPer + '" >';
             var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';
             FrecRow += '<td class=" tr_l">';
             FrecRow += '<input style="display:none;" type="file" id="file' + FileCounterPer + '" name = "file' + FileCounterPer + '" onchange="ChangeFilePer(' + FileCounterPer + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" multiple="" >';
             FrecRow += '<label style="display:none;" for="file' + FileCounterPer + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
             FrecRow += ' <div id="filePath' + FileCounterPer + '" class="file_n">' + tdFileNameEdit + '</div>';
             FrecRow += '</td>';
             FrecRow += '<td class=" tr_l"><input disabled id="descrptn' + FileCounterPer + '" MaxLength="50" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterPer + ');" onkeypress="return DisableEnter(event);"  onblur="blurTxtDescrptnPer(' + FileCounterPer + ');" type="text" class="form-control fg2_inp2" placeholder="Description" name=""></td>';
             FrecRow += '<td>';
             FrecRow += '<div class="btn_stl1">';
             FrecRow += '<button disabled id="FileIndvlAddMoreRow' + FileCounterPer + '" onclick="return CheckaddMoreRowsIndividualFilesPer(' + FileCounterPer + ');" class="btn act_btn bn2"  title="Add">';
             FrecRow += '<i class="fa fa-plus-circle"></i>';
             FrecRow += ' </button>';
             FrecRow += '<button disabled id="FieldId' + FileCounterPer + '" class="btn act_btn bn3"  title="Delete" onclick = "return RemoveFileUploadPer(' + FileCounterPer + ');">';
             FrecRow += '<i class="fa fa-trash"></i>';
             FrecRow += '</button>';
             FrecRow += '</div>';
             FrecRow += '</td>';


             FrecRow += ' <td id="FileInx' + FileCounterPer + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterPer + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterPer + '" style="display: none;">UPD</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterPer + '" style="display: none;">' + editTransDtlId + '</td>';
             FrecRow += '<td id="DbFileName' + FileCounterPer + '" style="display: none;">' + EditFileName + '</td>';
             FrecRow += '</tr>';

             jQuery('#TableFileCRN').append(FrecRow);
             document.getElementById("FileInx" + FileCounterPer).innerHTML = FileCounterPer;
             //document.getElementById("FileIndvlAddMoreRow" + FileCounterPer).style.opacity = "0.3";
             // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
             FileLocalStorageAddPer(FileCounterPer);
             FileCounterPer++;

         }

         function ViewAttachmentIns(editTransDtlId, EditFileName, EditActualFileName, EditDescription) {
             if (EditDescription == "") {
                 EditDescription = "--Description--";
             }
             var FrecRow = '<tr id="FilerowId_' + FileCounterIns + '" >';

             var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

             FrecRow += '<td class=" tr_l">';
             FrecRow += '<input style="display:none;" type="file" id="file' + FileCounterIns + '" name = "file' + FileCounterIns + '" onchange="ChangeFileIns(' + FileCounterIns + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" multiple="" >';
             FrecRow += '<label style="display:none;" for="file' + FileCounterIns + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
             FrecRow += ' <div id="filePath' + FileCounterIns + '" class="file_n">' + tdFileNameEdit + '</div>';
             FrecRow += '</td>';
             FrecRow += '<td class=" tr_l"><input disabled id="descrptn' + FileCounterIns + '" MaxLength="50" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterIns + ');" onkeypress="return DisableEnter(event);"  onblur="blurTxtDescrptnIns(' + FileCounterIns + ');" type="text" class="form-control fg2_inp2" placeholder="Description" name=""></td>';
             FrecRow += '<td>';
             FrecRow += '<div class="btn_stl1">';
             FrecRow += '<button disabled id="FileIndvlAddMoreRow' + FileCounterIns + '" onclick="return CheckaddMoreRowsIndividualFilesIns(' + FileCounterIns + ');" class="btn act_btn bn2"  title="Add">';
             FrecRow += '<i class="fa fa-plus-circle"></i>';
             FrecRow += ' </button>';
             FrecRow += '<button disabled id="FieldId' + FileCounterIns + '" class="btn act_btn bn3"  title="Delete" onclick = "return RemoveFileUploadIns(' + FileCounterIns + ');">';
             FrecRow += '<i class="fa fa-trash"></i>';
             FrecRow += '</button>';
             FrecRow += '</div>';
             FrecRow += '</td>';


             FrecRow += ' <td id="FileInx' + FileCounterIns + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterIns + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterIns + '" style="display: none;">UPD</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterIns + '" style="display: none;">' + editTransDtlId + '</td>';
             FrecRow += '<td id="DbFileName' + FileCounterIns + '" style="display: none;">' + EditFileName + '</td>';
             FrecRow += '</tr>';

             jQuery('#TableFileTIN').append(FrecRow);
             document.getElementById("FileInx" + FileCounterIns).innerHTML = FileCounterIns;
             //document.getElementById("FileIndvlAddMoreRow" + FileCounterIns).style.opacity = "0.3";
             // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
             FileLocalStorageAddIns(FileCounterIns);
             FileCounterIns++;

         }

         function ViewAttachmentVhcl(editTransDtlId, EditFileName, EditActualFileName, EditDescription) {
             if (EditDescription == "") {
                 EditDescription = "--Description--";
             }
             var FrecRow = '<tr id="FilerowId_' + FileCounterVhcl + '" >';
             var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';
             FrecRow += '<td class=" tr_l">';
             FrecRow += '<input style="display:none;" type="file" id="file' + FileCounterVhcl + '" name = "file' + FileCounterVhcl + '" onchange="ChangeFileVhcl(' + FileCounterVhcl + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" multiple="" >';
             FrecRow += '<label style="display:none;" for="file' + FileCounterVhcl + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
             FrecRow += ' <div id="filePath' + FileCounterVhcl + '" class="file_n">' + tdFileNameEdit + '</div>';
             FrecRow += '</td>';
             FrecRow += '<td class=" tr_l"><input disabled id="descrptn' + FileCounterVhcl + '" MaxLength="50" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterVhcl + ');" onkeypress="return DisableEnter(event);"  onblur="blurTxtDescrptnVhcl(' + FileCounterVhcl + ');" type="text" class="form-control fg2_inp2" placeholder="Description" name=""></td>';
             FrecRow += '<td>';
             FrecRow += '<div class="btn_stl1">';
             FrecRow += '<button disabled id="FileIndvlAddMoreRow' + FileCounterVhcl + '" onclick="return CheckaddMoreRowsIndividualFilesVhcl(' + FileCounterVhcl + ');" class="btn act_btn bn2"  title="Add">';
             FrecRow += '<i class="fa fa-plus-circle"></i>';
             FrecRow += ' </button>';
             FrecRow += '<button disabled id="FieldId' + FileCounterVhcl + '" class="btn act_btn bn3"  title="Delete" onclick = "return RemoveFileUploadVhcl(' + FileCounterVhcl + ');">';
             FrecRow += '<i class="fa fa-trash"></i>';
             FrecRow += '</button>';
             FrecRow += '</div>';
             FrecRow += '</td>';

             FrecRow += ' <td id="FileInx' + FileCounterVhcl + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterVhcl + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterVhcl + '" style="display: none;">UPD</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterVhcl + '" style="display: none;">' + editTransDtlId + '</td>';
             FrecRow += '<td id="DbFileName' + FileCounterVhcl + '" style="display: none;">' + EditFileName + '</td>';
             FrecRow += '</tr>';

             jQuery('#TableFileCCN').append(FrecRow);
             document.getElementById("FileInx" + FileCounterVhcl).innerHTML = FileCounterVhcl;
             //document.getElementById("FileIndvlAddMoreRow" + FileCounterVhcl).style.opacity = "0.3";
             // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
             FileLocalStorageAddVhcl(FileCounterVhcl);
             FileCounterVhcl++;

         }
         function AddFileUploadIns() {

             var FrecRow = '<tr id="FilerowId_' + FileCounterIns + '" >';

             FrecRow += '<td class=" tr_l">';
             FrecRow += '<input  type="file" id="file' + FileCounterIns + '" name = "file' + FileCounterIns + '" onchange="ChangeFileIns(' + FileCounterIns + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" multiple="" >';
             FrecRow += '<label  for="file' + FileCounterIns + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
             FrecRow += ' <div id="filePath' + FileCounterIns + '" class="file_n"></div>';
             FrecRow += '</td>';
             FrecRow += '<td class=" tr_l"><input  id="descrptn' + FileCounterIns + '" MaxLength="50" value="--Description--" onfocus="focusTxtDescrptn(' + FileCounterIns + ');" onkeypress="return DisableEnter(event);"  onblur="blurTxtDescrptnIns(' + FileCounterIns + ');" type="text" class="form-control fg2_inp2" placeholder="Description" name=""></td>';
             FrecRow += '<td>';
             FrecRow += '<div class="btn_stl1">';
             FrecRow += '<button  id="FileIndvlAddMoreRow' + FileCounterIns + '" onclick="return CheckaddMoreRowsIndividualFilesIns(' + FileCounterIns + ');" class="btn act_btn bn2"  title="Add">';
             FrecRow += '<i class="fa fa-plus-circle"></i>';
             FrecRow += ' </button>';
             FrecRow += '<button  id="FieldId' + FileCounterIns + '" class="btn act_btn bn3"  title="Delete" onclick = "return RemoveFileUploadIns(' + FileCounterIns + ');">';
             FrecRow += '<i class="fa fa-trash"></i>';
             FrecRow += '</button>';
             FrecRow += '</div>';
             FrecRow += '</td>';

             FrecRow += ' <td id="FileInx' + FileCounterIns + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterIns + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterIns + '" style="display: none;">INS</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterIns + '" style="display: none;"></td>';
             FrecRow += '<td id="DbFileName' + FileCounterIns + '" style="display: none;"></td>';
             FrecRow += '</tr>';

             jQuery('#TableFileTIN').append(FrecRow);

             document.getElementById('filePath' + FileCounterIns).innerHTML = 'No File Uploaded';
             FileCounterIns++;


         }
         function AddFileUploadVhcl() {

             var FrecRow = '<tr id="FilerowId_' + FileCounterVhcl + '" >';

             FrecRow += '<td class=" tr_l">';
             FrecRow += '<input type="file" id="file' + FileCounterVhcl + '" name = "file' + FileCounterVhcl + '" onchange="ChangeFileVhcl(' + FileCounterVhcl + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf" multiple="" >';
             FrecRow += '<label  for="file' + FileCounterVhcl + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
             FrecRow += ' <div id="filePath' + FileCounterVhcl + '" class="file_n"></div>';
             FrecRow += '</td>';
             FrecRow += '<td class=" tr_l"><input  id="descrptn' + FileCounterVhcl + '" MaxLength="50" value="--Description--" onfocus="focusTxtDescrptn(' + FileCounterVhcl + ');" onkeypress="return DisableEnter(event);"  onblur="blurTxtDescrptnVhcl(' + FileCounterVhcl + ');" type="text" class="form-control fg2_inp2" placeholder="Description" name=""></td>';
             FrecRow += '<td>';
             FrecRow += '<div class="btn_stl1">';
             FrecRow += '<button  id="FileIndvlAddMoreRow' + FileCounterVhcl + '" onclick="return CheckaddMoreRowsIndividualFilesVhcl(' + FileCounterVhcl + ');" class="btn act_btn bn2"  title="Add">';
             FrecRow += '<i class="fa fa-plus-circle"></i>';
             FrecRow += ' </button>';
             FrecRow += '<button  id="FieldId' + FileCounterVhcl + '" class="btn act_btn bn3"  title="Delete" onclick = "return RemoveFileUploadVhcl(' + FileCounterVhcl + ');">';
             FrecRow += '<i class="fa fa-trash"></i>';
             FrecRow += '</button>';
             FrecRow += '</div>';
             FrecRow += '</td>';

             FrecRow += ' <td id="FileInx' + FileCounterVhcl + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterVhcl + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterVhcl + '" style="display: none;">INS</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterVhcl + '" style="display: none;"></td>';
             FrecRow += '<td id="DbFileName' + FileCounterVhcl + '" style="display: none;"></td>';
             FrecRow += '</tr>';

             jQuery('#TableFileCCN').append(FrecRow);

             document.getElementById('filePath' + FileCounterVhcl).innerHTML = 'No File Uploaded';
             FileCounterVhcl++;


         }





         function RemoveFileUploadPer(removeNum) {
             ezBSAlert({
                 type: "confirm",
                 messageText: "Are you Sure you want to Delete Selected File?",
                 alertType: "info"
             }).done(function (e) {
                 if (e == true) {
                     var Filerow_index = jQuery('#FilerowId_' + removeNum).index();

                     FileLocalStorageDeletePer(Filerow_index, removeNum);
                     jQuery('#FilerowId_' + removeNum).remove();




                     // alert(Filerow_index);

                     var TableFileRowCount = document.getElementById("TableFileCRN").rows.length;

                     if (TableFileRowCount != 0) {
                         var idlast = $noC('#TableFileCRN tr:last').attr('id');
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
             });
             return false;           
         }

         function RemoveFileUploadIns(removeNum) {
             ezBSAlert({
                 type: "confirm",
                 messageText: "Are you Sure you want to Delete Selected File?",
                 alertType: "info"
             }).done(function (e) {
                 if (e == true) {
                     var Filerow_index = jQuery('#FilerowId_' + removeNum).index();
                     FileLocalStorageDeleteIns(Filerow_index, removeNum);
                     jQuery('#FilerowId_' + removeNum).remove();




                     // alert(Filerow_index);

                     var TableFileRowCount = document.getElementById("TableFileTIN").rows.length;

                     if (TableFileRowCount != 0) {
                         var idlast = $noC('#TableFileTIN tr:last').attr('id');
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
                         AddFileUploadIns();


                     }
                 }
                 else {
                     return false;
                 }
             });
             return false;

         }
         function RemoveFileUploadVhcl(removeNum) {
             ezBSAlert({
                 type: "confirm",
                 messageText: "Are you Sure you want to Delete Selected File?",
                 alertType: "info"
             }).done(function (e) {
                 if (e == true) {
                     var Filerow_index = jQuery('#FilerowId_' + removeNum).index();
                     FileLocalStorageDeleteVhcl(Filerow_index, removeNum);
                     jQuery('#FilerowId_' + removeNum).remove();




                     // alert(Filerow_index);

                     var TableFileRowCount = document.getElementById("TableFileCCN").rows.length;

                     if (TableFileRowCount != 0) {
                         var idlast = $noC('#TableFileCCN tr:last').attr('id');
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
                         AddFileUploadVhcl();


                     }
                 }
                 else {
                     return false;
                 }
             });
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
         function ChangeFileIns(x) {
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
                     FileLocalStorageEditIns(x, row_index);
                 }
                 else {
                     FileLocalStorageAddIns(x);
                 }
             }
         }
         function ChangeFileIcon(x) {
             if (ClearDivDisplayImage(x)) {
                 IncrmntConfrmCounter();
                 if (document.getElementById('file' + x).value != "") {
                     document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;
                     
                     
                 }
                 else {
                     document.getElementById('filePath' + x).innerHTML = 'No File Uploaded';


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
                 $("#divWarning").html("The specified file type could not be uploaded.Only support image files and document files");
                 $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                 });               
                 return false;
             }
         }
         function ClearDivDisplayImage(x) {

             var fuData = document.getElementById('file' + x);
             var FileUploadPath = fuData.value;
             var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();



             if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                         || Extension == "jpeg" || Extension == "jpg") {


                 return true;

             }
             else {
                 document.getElementById('file' + x).value = "";
                 document.getElementById('filePath' + x).innerHTML = 'No File Selected';
                 $("#divWarning").html("The specified file type could not be uploaded.Only support image files");
                 $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                 });                
                 return false;
             }
         }
         function ChangeFileVhcl(x) {
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
                     FileLocalStorageEditVhcl(x, row_index);
                 }
                 else {
                     FileLocalStorageAddVhcl(x);
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
         function CheckaddMoreRowsIndividualFilesPer(x) {
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
                         document.getElementById("FileIndvlAddMoreRow" + x).disabled = true;
                         AddFileUploadPer();

                         return false;
                     }
                 }
                 else {

                     document.getElementById("FileInx" + x).innerHTML = x;
                     document.getElementById("FileIndvlAddMoreRow" + x).disabled = true;
                     AddFileUploadPer();

                     return false;
                 }
             }
             return false;
         }
         function CheckaddMoreRowsIndividualFilesIns(x) {
             // for add image in each row
             // alert(x);
             var check = document.getElementById("FileInx" + x).innerHTML;

             //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
             //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
             //  alert(check);
             if (check == " ") {

                 var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                 if (Fevt != 'UPD') {
                     if (CheckFileUploaded(x) == true) {
                         document.getElementById("FileInx" + x).innerHTML = x;
                         document.getElementById("FileIndvlAddMoreRow" + x).disabled = true;
                         AddFileUploadIns();
                         return false;
                     }
                 }
                 else {

                     document.getElementById("FileInx" + x).innerHTML = x;
                     document.getElementById("FileIndvlAddMoreRow" + x).disabled = true;
                     AddFileUploadIns();
                     return false;
                 }
             }
             return false;
         }
         function CheckaddMoreRowsIndividualFilesVhcl(x) {
             // for add image in each row
             //alert(x);
             var check = document.getElementById("FileInx" + x).innerHTML;

             //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
             //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
             //  alert(check);
             if (check == " ") {

                 var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                 if (Fevt != 'UPD') {
                     if (CheckFileUploaded(x) == true) {
                         document.getElementById("FileInx" + x).innerHTML = x;
                         document.getElementById("FileIndvlAddMoreRow" + x).disabled = true;
                         AddFileUploadVhcl();
                         return false;
                     }
                 }
                 else {

                     document.getElementById("FileInx" + x).innerHTML = x;
                     document.getElementById("FileIndvlAddMoreRow" + x).disabled = true;
                     AddFileUploadVhcl();
                     return false;
                 }
             }
             return false;
         }
         function focusTxtDescrptn(x) {
             document.getElementById("descrptn" + x).value = "";




         }
         function blurTxtDescrptnPer(x) {
             var val = document.getElementById("descrptn" + x).value;
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
                     FileLocalStorageEditPer(x, row_index);
                 }
             }
         }
         function blurTxtDescrptnIns(x) {
             var val = document.getElementById("descrptn" + x).value;
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
                     FileLocalStorageEditIns(x, row_index);
                 }
             }
         }
         function blurTxtDescrptnVhcl(x) {
             var val = document.getElementById("descrptn" + x).value;
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
                     FileLocalStorageEditVhcl(x, row_index);
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
        //For permit files
        function FileLocalStorageAddPer(x) {

            var tbClientPermitFileUpload = localStorage.getItem("tbClientPermitFileUpload");//Retrieve the stored data

            tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

            if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                tbClientPermitFileUpload = [];


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
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"

                });
            }
            else if (Fevt == 'UPD') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });
            }


            tbClientPermitFileUpload.push(client);
            localStorage.setItem("tbClientPermitFileUpload", JSON.stringify(tbClientPermitFileUpload));

            $addFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));



            // alert("The PERMIT FILE ADDED.");
            // var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
            // alert(h);

            document.getElementById("FileSave" + x).innerHTML = "saved";
            //  alert('saved');
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
            //   alert("FILE deleted.");

            //var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
            // alert(h);


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
            var descrptn = document.getElementById("descrptn" + x).value;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;

            if (Fevt == 'INS') {

                var $FileE = jQuery.noConflict();
                tbClientPermitFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",

                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"
                });//Alter the selected item on the table
            }
            else {

                var $FileE = jQuery.noConflict();
                tbClientPermitFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",

                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });//Alter the selected item on the table



            }



            localStorage.setItem("tbClientPermitFileUpload", JSON.stringify(tbClientPermitFileUpload));
            $FileE("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));

            //alert("The FILE EDITED.");

            //var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
            //alert(h);
            return true;
        }
        //for insurance files
        function FileLocalStorageAddIns(x) {

            var tbClientInsurFileUpload = localStorage.getItem("tbClientInsurFileUpload");//Retrieve the stored data

            tbClientInsurFileUpload = JSON.parse(tbClientInsurFileUpload); //Converts string to object

            if (tbClientInsurFileUpload == null) //If there is no data, initialize an empty array
                tbClientInsurFileUpload = [];


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

                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"

                });
            }
            else if (Fevt == 'UPD') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",

                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });
            }


            tbClientInsurFileUpload.push(client);
            localStorage.setItem("tbClientInsurFileUpload", JSON.stringify(tbClientInsurFileUpload));

            $addFile("#cphMain_HiddenField3_FileUpload").val(JSON.stringify(tbClientInsurFileUpload));



            //alert("The INSURANCE FILE ADDED.");
            // var h = document.getElementById("<%=HiddenField3_FileUpload.ClientID%>").value;
            // alert(h);

            document.getElementById("FileSave" + x).innerHTML = "saved";
            //  alert('saved');
            return true;

        }

        function FileLocalStorageDeleteIns(row_index, x) {

            var $DelFile = jQuery.noConflict();
            var tbClientInsurFileUpload = localStorage.getItem("tbClientInsurFileUpload");//Retrieve the stored data

            tbClientInsurFileUpload = JSON.parse(tbClientInsurFileUpload); //Converts string to object

            if (tbClientInsurFileUpload == null) //If there is no data, initialize an empty array
                tbClientInsurFileUpload = [];



            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            tbClientInsurFileUpload.splice(row_index, 1);
            localStorage.setItem("tbClientInsurFileUpload", JSON.stringify(tbClientInsurFileUpload));
            $DelFile("#cphMain_HiddenField3_FileUpload").val(JSON.stringify(tbClientInsurFileUpload));
            //   alert("FILE deleted.");

            //   var h = document.getElementById("<%=HiddenField3_FileUpload.ClientID%>").value;
            //  alert(h);


            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            if (Fevt == 'UPD') {
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

                if (FdetailId != '') {

                    DeleteFileLSTORAGEAddIns(x);
                }

            }

            function DeleteFileLSTORAGEAddIns(x) {

                var tbClientInsurFileUploadCancel = localStorage.getItem("tbClientInsurFileUploadCancel");//Retrieve the stored data

                tbClientInsurFileUploadCancel = JSON.parse(tbClientInsurFileUploadCancel); //Converts string to object

                if (tbClientInsurFileUploadCancel == null) //If there is no data, initialize an empty array
                    tbClientInsurFileUploadCancel = [];


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



                tbClientInsurFileUploadCancel.push(client);
                localStorage.setItem("tbClientInsurFileUploadCancel", JSON.stringify(tbClientInsurFileUploadCancel));

                $addFile("#cphMain_hiddenInsFileCanclDtlId").val(JSON.stringify(tbClientInsurFileUploadCancel));





                //document.getElementById("FileSave" + x).innerHTML = "saved";
                //   alert('saved');
                return true;

            }

        }

        function FileLocalStorageEditIns(x, row_index) {
            var tbClientInsurFileUpload = localStorage.getItem("tbClientInsurFileUpload");//Retrieve the stored data

            tbClientInsurFileUpload = JSON.parse(tbClientInsurFileUpload); //Converts string to object

            if (tbClientInsurFileUpload == null) //If there is no data, initialize an empty array
                tbClientInsurFileUpload = [];

            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var descrptn = document.getElementById("descrptn" + x).value;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;

            if (Fevt == 'INS') {

                var $FileE = jQuery.noConflict();
                tbClientInsurFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",

                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"
                });//Alter the selected item on the table
            }
            else {

                var $FileE = jQuery.noConflict();
                tbClientInsurFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",

                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });//Alter the selected item on the table



            }



            localStorage.setItem("tbClientInsurFileUpload", JSON.stringify(tbClientInsurFileUpload));
            $FileE("#cphMain_HiddenField3_FileUpload").val(JSON.stringify(tbClientInsurFileUpload));

            //alert("The FILE EDITED.");

            //var h = document.getElementById("<%=HiddenField3_FileUpload.ClientID%>").value;
            //alert(h);
            return true;
        }
        //for vehicle images
        function FileLocalStorageAddVhcl(x) {

            var tbClientVehicleFileUpload = localStorage.getItem("tbClientVehicleFileUpload");//Retrieve the stored data

            tbClientVehicleFileUpload = JSON.parse(tbClientVehicleFileUpload); //Converts string to object

            if (tbClientVehicleFileUpload == null) //If there is no data, initialize an empty array
                tbClientVehicleFileUpload = [];


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

                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"

                });
            }
            else if (Fevt == 'UPD') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",

                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });
            }


            tbClientVehicleFileUpload.push(client);
            localStorage.setItem("tbClientVehicleFileUpload", JSON.stringify(tbClientVehicleFileUpload));

            $addFile("#cphMain_HiddenField4_FileUpload").val(JSON.stringify(tbClientVehicleFileUpload));



            // alert("The VEHICLE FILE ADDED.");
            // var h = document.getElementById("<%=HiddenField4_FileUpload.ClientID%>").value;
            // alert(h);

            document.getElementById("FileSave" + x).innerHTML = "saved";
            //  alert('saved');
            return true;

        }

        function FileLocalStorageDeleteVhcl(row_index, x) {
            var $DelFile = jQuery.noConflict();
            var tbClientVehicleFileUpload = localStorage.getItem("tbClientVehicleFileUpload");//Retrieve the stored data

            tbClientVehicleFileUpload = JSON.parse(tbClientVehicleFileUpload); //Converts string to object

            if (tbClientVehicleFileUpload == null) //If there is no data, initialize an empty array
                tbClientVehicleFileUpload = [];



            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            tbClientVehicleFileUpload.splice(row_index, 1);
            localStorage.setItem("tbClientVehicleFileUpload", JSON.stringify(tbClientVehicleFileUpload));
            $DelFile("#cphMain_HiddenField4_FileUpload").val(JSON.stringify(tbClientVehicleFileUpload));
            //   alert("FILE deleted.");

            //   var h = document.getElementById("<%=HiddenField4_FileUpload.ClientID%>").value;
            //  alert(h);


            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            if (Fevt == 'UPD') {
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

                if (FdetailId != '') {

                    DeleteFileLSTORAGEAddVhcl(x);
                }

            }


            function DeleteFileLSTORAGEAddVhcl(x) {

                var tbClientVehicleFileUploadCancel = localStorage.getItem("tbClientVehicleFileUploadCancel");//Retrieve the stored data

                tbClientVehicleFileUploadCancel = JSON.parse(tbClientVehicleFileUploadCancel); //Converts string to object

                if (tbClientVehicleFileUploadCancel == null) //If there is no data, initialize an empty array
                    tbClientVehicleFileUploadCancel = [];


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



                tbClientVehicleFileUploadCancel.push(client);
                localStorage.setItem("tbClientVehicleFileUploadCancel", JSON.stringify(tbClientVehicleFileUploadCancel));

                $addFile("#cphMain_hiddenVhclFileCanclDtlId").val(JSON.stringify(tbClientVehicleFileUploadCancel));





                //document.getElementById("FileSave" + x).innerHTML = "saved";
                //   alert('saved');
                return true;

            }

        }

        function FileLocalStorageEditVhcl(x, row_index) {
            var tbClientVehicleFileUpload = localStorage.getItem("tbClientVehicleFileUpload");//Retrieve the stored data

            tbClientVehicleFileUpload = JSON.parse(tbClientVehicleFileUpload); //Converts string to object

            if (tbClientVehicleFileUpload == null) //If there is no data, initialize an empty array
                tbClientVehicleFileUpload = [];

            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var descrptn = document.getElementById("descrptn" + x).value;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;

            if (Fevt == 'INS') {

                var $FileE = jQuery.noConflict();
                tbClientVehicleFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",

                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"
                });//Alter the selected item on the table
            }
            else {

                var $FileE = jQuery.noConflict();
                tbClientVehicleFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",

                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });//Alter the selected item on the table



            }



            localStorage.setItem("tbClientVehicleFileUpload", JSON.stringify(tbClientVehicleFileUpload));
            $FileE("#cphMain_HiddenField4_FileUpload").val(JSON.stringify(tbClientVehicleFileUpload));

            //alert("The FILE EDITED.");

            //var h = document.getElementById("<%=HiddenField4_FileUpload.ClientID%>").value;
            //alert(h);
            return true;
        }
    </script>
      
    <script type="text/javascript">

        function DuplicationName() {
            $("#divWarning").html("Duplication Error!. Business Unit Name Can’t be Duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtCorpName.ClientID%>").style.borderColor = "Red";         
            document.getElementById("<%=txtCorpName.ClientID%>").focus();
        }
        function DuplicationCode() {
            $("#divWarning").html("Duplication Error!. Business Unit Code Can’t be Duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtCode.ClientID%>").style.borderColor = "Red";         
            document.getElementById("<%=txtCode.ClientID%>").focus();
         }
        function DuplicationCRN() {
            $("#divWarning").html("Duplication Error!. Commercial Registration Number Can’t be Duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtCRN.ClientID%>").style.borderColor = "Red";           
        }
        function DuplicationTIN() {
            $("#divWarning").html("Duplication Error!.Tax Identification Number Can’t be Duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtTIN.ClientID%>").style.borderColor = "Red";           
        }
        function DuplicationCCN() {
            $("#divWarning").html("Duplication Error!. Computer Card Number Can’t be Duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtCCN.ClientID%>").style.borderColor = "Red";           
         }
        function CorpOfficeCount() {
            $("#divWarning").html("Saved Successfully, You cannot Register more Business Units Because Business Pack Limit Reached!");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });          
        }
        function CorpOfficeCountReached() {
            $("#divWarning").html("You cannot Register more Business Units Because Business Pack Limit Reached!");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });           
        }
        function SuccessConfirmation() {
            $("#success-alert").html("Business Unit Details Inserted Successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });          
        }
        function SuccessUpdation() {
            $("#success-alert").html("Business Unit Details Updated Successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }

        function ReplaceTag() {

            IncrmntConfrmCounter();

            // replacing < and > tags
            var CorpNameWithoutReplace = document.getElementById("<%=txtCorpName.ClientID%>").value;
            var CorpNamereplaceText1 = CorpNameWithoutReplace.replace(/</g, "");
            var CorpNamereplaceText2 = CorpNamereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpName.ClientID%>").value = CorpNamereplaceText2;

            var Add1WithoutReplace = document.getElementById("<%=txtCorpAdd1.ClientID%>").value;
            var Add1replaceText1 = Add1WithoutReplace.replace(/</g, "");
            var Add1replaceText2 = Add1replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpAdd1.ClientID%>").value = Add1replaceText2;

            var Add2WithoutReplace = document.getElementById("<%=txtCorpAdd2.ClientID%>").value;
            var Add2replaceText1 = Add2WithoutReplace.replace(/</g, "");
            var Add2replaceText2 = Add2replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpAdd2.ClientID%>").value = Add2replaceText2;

            var Add3WithoutReplace = document.getElementById("<%=txtCorpAdd3.ClientID%>").value;
            var Add3replaceText1 = Add3WithoutReplace.replace(/</g, "");
            var Add3replaceText2 = Add3replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpAdd3.ClientID%>").value = Add3replaceText2;

            var DateWithoutReplace = document.getElementById("<%=txtDate.ClientID%>").value;
            var DatereplaceText1 = DateWithoutReplace.replace(/</g, "");
            var DatereplaceText2 = DatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtDate.ClientID%>").value = DatereplaceText2;


            var CCNumWithoutReplace = document.getElementById("<%=txtCustCareNumber.ClientID%>").value;
            var CCNumreplaceText1 = CCNumWithoutReplace.replace(/</g, "");
            var CCNumreplaceText2 = CCNumreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCustCareNumber.ClientID%>").value = CCNumreplaceText2;

            var ShortNameWithoutReplace = document.getElementById("<%=txtShortName.ClientID%>").value;
            var ShortNamereplaceText1 = ShortNameWithoutReplace.replace(/</g, "");
            var ShortNamereplaceText2 = ShortNamereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtShortName.ClientID%>").value = ShortNamereplaceText2;


            var ShortAddrWithoutReplace = document.getElementById("<%=txtShortAddress.ClientID%>").value;
            var ShortAddrreplaceText1 = ShortAddrWithoutReplace.replace(/</g, "");
            var ShortAddrreplaceText2 = ShortAddrreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtShortAddress.ClientID%>").value = ShortAddrreplaceText2;

            var ZipWithoutReplace = document.getElementById("<%=txtCorpZip.ClientID%>").value;
            var ZipreplaceText1 = ZipWithoutReplace.replace(/</g, "");
            var ZipreplaceText2 = ZipreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpZip.ClientID%>").value = ZipreplaceText2;

           

            var MobWithoutReplace = document.getElementById("<%=txtCorpMobile.ClientID%>").value;
            var MobreplaceText1 = MobWithoutReplace.replace(/</g, "");
            var MobreplaceText2 = MobreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpMobile.ClientID%>").value = MobreplaceText2;

            var WebsiteWithoutReplace = document.getElementById("<%=txtCorpWebsite.ClientID%>").value;
            var WebsitereplaceText1 = WebsiteWithoutReplace.replace(/</g, "");
            var WebsitereplaceText2 = WebsitereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpWebsite.ClientID%>").value = WebsitereplaceText2;

            var EmailWithoutReplace = document.getElementById("<%=txtCorpEmail.ClientID%>").value;
            var EmailreplaceText1 = EmailWithoutReplace.replace(/</g, "");
            var EmailreplaceText2 = EmailreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpEmail.ClientID%>").value = EmailreplaceText2;

            var TinWithoutReplace = document.getElementById("<%=txtTinNumber.ClientID%>").value;
            var TinreplaceText1 = TinWithoutReplace.replace(/</g, "");
            var TinreplaceText2 = TinreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTinNumber.ClientID%>").value = TinreplaceText2;

            var CinWithoutReplace = document.getElementById("<%=txtCinNumber.ClientID%>").value;
            var CinreplaceText1 = CinWithoutReplace.replace(/</g, "");
            var CinreplaceText2 = CinreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCinNumber.ClientID%>").value = CinreplaceText2;


            


            __doPostBack('', '');
            return false;

        }




        function CorpOfficeValidation() {


           
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

            // replacing < and > tags
            var CorpNameWithoutReplace = document.getElementById("<%=txtCorpName.ClientID%>").value;
            var CorpNamereplaceText1 = CorpNameWithoutReplace.replace(/</g, "");
            var CorpNamereplaceText2 = CorpNamereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpName.ClientID%>").value = CorpNamereplaceText2;

            var Add1WithoutReplace = document.getElementById("<%=txtCorpAdd1.ClientID%>").value;
            var Add1replaceText1 = Add1WithoutReplace.replace(/</g, "");
            var Add1replaceText2 = Add1replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpAdd1.ClientID%>").value = Add1replaceText2;

            var Add2WithoutReplace = document.getElementById("<%=txtCorpAdd2.ClientID%>").value;
            var Add2replaceText1 = Add2WithoutReplace.replace(/</g, "");
            var Add2replaceText2 = Add2replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpAdd2.ClientID%>").value = Add2replaceText2;

            var Add3WithoutReplace = document.getElementById("<%=txtCorpAdd3.ClientID%>").value;
            var Add3replaceText1 = Add3WithoutReplace.replace(/</g, "");
            var Add3replaceText2 = Add3replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpAdd3.ClientID%>").value = Add3replaceText2;

            var DateWithoutReplace = document.getElementById("<%=txtDate.ClientID%>").value;
            var DatereplaceText1 = DateWithoutReplace.replace(/</g, "");
            var DatereplaceText2 = DatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtDate.ClientID%>").value = DatereplaceText2;


            var CCNumWithoutReplace = document.getElementById("<%=txtCustCareNumber.ClientID%>").value;
            var CCNumreplaceText1 = CCNumWithoutReplace.replace(/</g, "");
            var CCNumreplaceText2 = CCNumreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCustCareNumber.ClientID%>").value = CCNumreplaceText2;

            var ShortNameWithoutReplace = document.getElementById("<%=txtShortName.ClientID%>").value;
            var ShortNamereplaceText1 = ShortNameWithoutReplace.replace(/</g, "");
            var ShortNamereplaceText2 = ShortNamereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtShortName.ClientID%>").value = ShortNamereplaceText2;


            var ShortAddrWithoutReplace = document.getElementById("<%=txtShortAddress.ClientID%>").value;
            var ShortAddrreplaceText1 = ShortAddrWithoutReplace.replace(/</g, "");
            var ShortAddrreplaceText2 = ShortAddrreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtShortAddress.ClientID%>").value = ShortAddrreplaceText2;

            var ZipWithoutReplace = document.getElementById("<%=txtCorpZip.ClientID%>").value;
            var ZipreplaceText1 = ZipWithoutReplace.replace(/</g, "");
            var ZipreplaceText2 = ZipreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpZip.ClientID%>").value = ZipreplaceText2;

           

            var MobWithoutReplace = document.getElementById("<%=txtCorpMobile.ClientID%>").value;
            var MobreplaceText1 = MobWithoutReplace.replace(/</g, "");
            var MobreplaceText2 = MobreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpMobile.ClientID%>").value = MobreplaceText2;

            var WebsiteWithoutReplace = document.getElementById("<%=txtCorpWebsite.ClientID%>").value;
            var WebsitereplaceText1 = WebsiteWithoutReplace.replace(/</g, "");
            var WebsitereplaceText2 = WebsitereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpWebsite.ClientID%>").value = WebsitereplaceText2;

            var EmailWithoutReplace = document.getElementById("<%=txtCorpEmail.ClientID%>").value;
            var EmailreplaceText1 = EmailWithoutReplace.replace(/</g, "");
            var EmailreplaceText2 = EmailreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpEmail.ClientID%>").value = EmailreplaceText2;

            var TinWithoutReplace = document.getElementById("<%=txtTinNumber.ClientID%>").value;
            var TinreplaceText1 = TinWithoutReplace.replace(/</g, "");
            var TinreplaceText2 = TinreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTinNumber.ClientID%>").value = TinreplaceText2;

            var CinWithoutReplace = document.getElementById("<%=txtCinNumber.ClientID%>").value;
            var CinreplaceText1 = CinWithoutReplace.replace(/</g, "");
            var CinreplaceText2 = CinreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCinNumber.ClientID%>").value = CinreplaceText2;

           
            var FaxWithoutReplace = document.getElementById("<%=txtCode.ClientID%>").value;
            var FaxreplaceText1 = FaxWithoutReplace.replace(/</g, "");
            var FaxreplaceText2 = FaxreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCode.ClientID%>").value = FaxreplaceText2;
           

            var CodeWithoutReplace = document.getElementById("<%=txtFax.ClientID%>").value;
            var CodereplaceText1 = CodeWithoutReplace.replace(/</g, "");
            var CodereplaceText2 = CodereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtFax.ClientID%>").value = CodereplaceText2;

            var EnqWithoutReplace = document.getElementById("<%=txtEnqMail.ClientID%>").value;
            var EnqreplaceText1 = EnqWithoutReplace.replace(/</g, "");
            var EnqreplaceText2 = EnqreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEnqMail.ClientID%>").value = EnqreplaceText2;

            var EnqWithoutReplace = document.getElementById("<%=txtMailStrg.ClientID%>").value;
            var EnqreplaceText1 = EnqWithoutReplace.replace(/</g, "");
            var EnqreplaceText2 = EnqreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtMailStrg.ClientID%>").value = EnqreplaceText2;

            var EnqWithoutReplace = document.getElementById("<%=txtCRN.ClientID%>").value;
            var EnqreplaceText1 = EnqWithoutReplace.replace(/</g, "");
            var EnqreplaceText2 = EnqreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCRN.ClientID%>").value = EnqreplaceText2;

            var EnqWithoutReplace = document.getElementById("<%=txtCRNExpDate.ClientID%>").value;
            var EnqreplaceText1 = EnqWithoutReplace.replace(/</g, "");
            var EnqreplaceText2 = EnqreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCRNExpDate.ClientID%>").value = EnqreplaceText2;

            var EnqWithoutReplace = document.getElementById("<%=txtCRNIssDate.ClientID%>").value;
            var EnqreplaceText1 = EnqWithoutReplace.replace(/</g, "");
            var EnqreplaceText2 = EnqreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCRNIssDate.ClientID%>").value = EnqreplaceText2;

            var EnqWithoutReplace = document.getElementById("<%=txtTIN.ClientID%>").value;
            var EnqreplaceText1 = EnqWithoutReplace.replace(/</g, "");
            var EnqreplaceText2 = EnqreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTIN.ClientID%>").value = EnqreplaceText2;

            var EnqWithoutReplace = document.getElementById("<%=txtTINExp.ClientID%>").value;
            var EnqreplaceText1 = EnqWithoutReplace.replace(/</g, "");
            var EnqreplaceText2 = EnqreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTINExp.ClientID%>").value = EnqreplaceText2;


            var EnqWithoutReplace = document.getElementById("<%=txtTINIss.ClientID%>").value;
            var EnqreplaceText1 = EnqWithoutReplace.replace(/</g, "");
            var EnqreplaceText2 = EnqreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTINIss.ClientID%>").value = EnqreplaceText2;

            var EnqWithoutReplace = document.getElementById("<%=txtCCN.ClientID%>").value;
            var EnqreplaceText1 = EnqWithoutReplace.replace(/</g, "");
            var EnqreplaceText2 = EnqreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCCN.ClientID%>").value = EnqreplaceText2;

            var EnqWithoutReplace = document.getElementById("<%=txtCCNExp.ClientID%>").value;
            var EnqreplaceText1 = EnqWithoutReplace.replace(/</g, "");
            var EnqreplaceText2 = EnqreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCCNExp.ClientID%>").value = EnqreplaceText2;

            var EnqWithoutReplace = document.getElementById("<%=txtCCNIss.ClientID%>").value;
            var EnqreplaceText1 = EnqWithoutReplace.replace(/</g, "");
            var EnqreplaceText2 = EnqreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCCNIss.ClientID%>").value = EnqreplaceText2;

            var cmpnySharePer = document.getElementById("<%=txtSharePer.ClientID%>").value;
            
            document.getElementById("<%=ddlBsnsTyp.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlShareTyp.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlParent.ClientID%>").style.borderColor = "";
            $("div#divddlParent input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById("<%=txtCode.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCRN.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCRNExpDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTIN.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTINExp.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCCN.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCCNExp.ClientID%>").style.borderColor = "";

           
            document.getElementById("<%=txtEnqMail.ClientID%>").style.borderColor = "";



            document.getElementById('ErrortxtCorpMobile').style.display = "none";
            document.getElementById('ErrortxtCorpWebsite').style.display = "none";
            document.getElementById('ErrorMsgCorpEmail').style.display = "none";
            document.getElementById('ErrorMsgCorpEnqEmail').style.display = "none";
            document.getElementById('ErrortxtMailStrg').style.display = "none";



            document.getElementById("<%=txtMailStrg.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlOfficeTyp.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlCorpCountry.ClientID%>").style.borderColor = "";
            $("div#divddlCorpCountry input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById("<%=txtCorpName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCorpAdd1.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCorpMobile.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCorpEmail.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlFiscalMonth.ClientID%>").style.borderColor = "";
            $("div#divddlFiscalMonth input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById("<%=txtCorpWebsite.ClientID%>").style.borderColor = "";
          
            
            var CorpaType = document.getElementById("<%=ddlOfficeTyp.ClientID%>");
            var CorpType = CorpaType.options[CorpaType.selectedIndex].text.trim();
            var CorpaCountry = document.getElementById("<%=ddlCorpCountry.ClientID%>");
            var CorpCountry = CorpaCountry.options[CorpaCountry.selectedIndex].text.trim();

            var CorpName = document.getElementById("<%=txtCorpName.ClientID%>").value.trim();

            var CorpAdd = document.getElementById("<%=txtCorpAdd1.ClientID%>").value.trim();

            var CorpMobile = document.getElementById("<%=txtCorpMobile.ClientID%>").value.trim();
            var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;

            var EmailAdd = document.getElementById("<%=txtCorpEmail.ClientID%>").value.trim();
            var Email = document.getElementById("<%=txtCorpEmail.ClientID%>");

            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            var CorpFiscalMonth = document.getElementById("<%=ddlFiscalMonth.ClientID%>");
            var CorpFiscal = CorpFiscalMonth.options[CorpFiscalMonth.selectedIndex].value.trim();
            //date
            var date = document.getElementById("<%=txtDate.ClientID%>").value.trim();


            var BsnsType = document.getElementById("<%=ddlBsnsTyp.ClientID%>");
            var BsnsTypeText = BsnsType.options[BsnsType.selectedIndex].text;

            var ShareType = document.getElementById("<%=ddlShareTyp.ClientID%>");
            var ShareTypeText = ShareType.options[ShareType.selectedIndex].text;

            var ParentType = document.getElementById("<%=ddlParent.ClientID%>");
            var ParentTypeText = ParentType.options[ParentType.selectedIndex].text;

            var code = document.getElementById("<%=txtCode.ClientID%>").value.trim();
            var CRN = document.getElementById("<%=txtCRN.ClientID%>").value.trim();
            var CRNExp = document.getElementById("<%=txtCRNExpDate.ClientID%>").value.trim();
            var TIN = document.getElementById("<%=txtTIN.ClientID%>").value.trim();
            var TINExp = document.getElementById("<%=txtTINExp.ClientID%>").value.trim();
            var CCN = document.getElementById("<%=txtCCN.ClientID%>").value.trim();
            var CCNExp = document.getElementById("<%=txtCCNExp.ClientID%>").value.trim();
           
         
            var EmailEnq = document.getElementById("<%=txtEnqMail.ClientID%>").value.trim();
            var EmailEnqq = document.getElementById("<%=txtEnqMail.ClientID%>");

            var EmailStrg = document.getElementById("<%=txtMailStrg.ClientID%>").value.trim();
            var EmailStrgg = document.getElementById("<%=txtMailStrg.ClientID%>");

            //// AFTER if validation is true in above case
            //check if software date is less than current date
            var datepickerDate = document.getElementById("<%=txtDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

           
            //new code

            if (document.getElementById("<%=ddlCity.ClientID%>").value != null && document.getElementById("<%=ddlCity.ClientID%>").value != "--Select City--" && document.getElementById("<%=ddlCity.ClientID%>").value != 0) {
                document.getElementById("<%=HiddenCityValue.ClientID%>").value = document.getElementById("<%=ddlCity.ClientID%>").value;
            }

            if (document.getElementById("<%=ddlCorpState.ClientID%>").value != null && document.getElementById("<%=ddlCorpState.ClientID%>").value != "--Select State--" && document.getElementById("<%=ddlCorpState.ClientID%>").value != 0) {

                document.getElementById("<%=HiddenStateValue.ClientID%>").value = document.getElementById("<%=ddlCorpState.ClientID%>").value;
            }

            var datepickerDateCRNE = document.getElementById("<%=txtCRNExpDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDateCRNE.split("-");
            var dateCRNExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDateCRNI = document.getElementById("<%=txtCRNIssDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDateCRNI.split("-");
            var dateCRNISS = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDateTINE = document.getElementById("<%=txtTINExp.ClientID%>").value;
            var arrDatePickerDate = datepickerDateTINE.split("-");
            var dateTINExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDateTINI = document.getElementById("<%=txtTINIss.ClientID%>").value;
            var arrDatePickerDate = datepickerDateTINI.split("-");
            var dateTINIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDateCCNE = document.getElementById("<%=txtCCNExp.ClientID%>").value;
            var arrDatePickerDate = datepickerDateCCNE.split("-");
            var dateCCNExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDateCCNI = document.getElementById("<%=txtCCNIss.ClientID%>").value;
            var arrDatePickerDate = datepickerDateCCNI.split("-");
            var dateCCNIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);



            var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
            var arrCurrentDate = CurrentDateDate.split("-");
            var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

            var CRNDate = CRNExp.split("-");
            var TINDate = TINExp.split("-");
            var CCNDate = CCNExp.split("-");
            var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;

            var re = /^(http[s]?:\/\/){0,1}(www\.){0,1}[a-zA-Z0-9\.\-]+\.[a-zA-Z]{2,5}[\.]{0,1}/;
             
            var web = document.getElementById("<%=txtCorpWebsite.ClientID%>").value;

            if (dateCCNIss > dateCurrentDate) {
                document.getElementById("<%=txtCCNIss.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCCNIss.ClientID%>").focus();
                $("#divWarning").html("Sorry, Issue Date cannot be Greater than Business Unit Creation Date !.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });              
                ret = false;
            }

            if (datepickerDateCCNE == datepickerDateCCNI) {
                document.getElementById("<%=txtCCNExp.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCCNExp.ClientID%>").focus();
                $("#divWarning").html("Sorry, Expiry Date cannot be Equal To Issue Date !.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });               
                ret = false;
            }
            if (isNaN(Date.parse(CCNDate[2] + "-" + CCNDate[1] + "-" + CCNDate[0]))) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });               
                document.getElementById("<%=txtCCNExp.ClientID%>").style.borderColor = "Red";
                var OrgnTypeFocus = document.getElementById("<%=txtCCNExp.ClientID%>").focus();
                ret = false;
            }
            if (EditVal == "") {
                if (dateCCNExp < dateCurrentDate) {
                    document.getElementById("<%=txtCCNExp.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtCCNExp.ClientID%>").focus();
                    $("#divWarning").html("Sorry, Expiry Date cannot be Less than Business Unit Creation Date !.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });                  
                    ret = false;
                }
            }
            if (CCN == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtCCN.ClientID%>").style.borderColor = "Red";
                var OrgnTypeFocus = document.getElementById("<%=txtCCN.ClientID%>").focus();
                ret = false;
            }




            if (dateTINIss > dateCurrentDate) {
                document.getElementById("<%=txtTINIss.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtTINIss.ClientID%>").focus();
                $("#divWarning").html("Sorry, Issue Date cannot be Greater than Business Unit Creation Date !.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });               
                ret = false;
            }

            if (datepickerDateTINE == datepickerDateTINI) {
                document.getElementById("<%=txtTINExp.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtTINExp.ClientID%>").focus();
                $("#divWarning").html("Sorry, Expiry Date cannot be Equal To Issue Date !.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });               
                ret = false;
            }
            if (isNaN(Date.parse(TINDate[2] + "-" + TINDate[1] + "-" + TINDate[0]))) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtTINExp.ClientID%>").style.borderColor = "Red";
                var OrgnTypeFocus = document.getElementById("<%=txtTINExp.ClientID%>").focus();
                ret = false;
            }
            if (EditVal == "") {
                if (dateTINExp < dateCurrentDate) {
                    document.getElementById("<%=txtTINExp.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTINExp.ClientID%>").focus();
                    $("#divWarning").html("Sorry, Expiry Date cannot be Less than  Business Unit Creation Date !.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });                 
                    ret = false;
                }

            }
            if (TIN == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtTIN.ClientID%>").style.borderColor = "Red";
                var OrgnTypeFocus = document.getElementById("<%=txtTIN.ClientID%>").focus();
                ret = false;
            }



            if (dateCRNISS > dateCurrentDate) {
                document.getElementById("<%=txtCRNIssDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCRNIssDate.ClientID%>").focus();
                $("#divWarning").html("Issue Date cannot be Greater than Business Unit Creation Date !.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });              
                ret = false;
            }
            if (datepickerDateCRNE == datepickerDateCRNI) {
                document.getElementById("<%=txtCRNExpDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCRNExpDate.ClientID%>").focus();
                $("#divWarning").html("Sorry, Expiry Date cannot be Equal To Issue Date !.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });               
                ret = false;
            }
            if (isNaN(Date.parse(CRNDate[2] + "-" + CRNDate[1] + "-" + CRNDate[0]))) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtCRNExpDate.ClientID%>").style.borderColor = "Red";
                var OrgnTypeFocus = document.getElementById("<%=txtCRNExpDate.ClientID%>").focus();
                ret = false;
            }
            if (EditVal == "") {
                if (dateCRNExp < dateCurrentDate) {
                    document.getElementById("<%=txtCRNExpDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtCRNExpDate.ClientID%>").focus();
                    $("#divWarning").html("Sorry, Expiry Date cannot be Less than  Business Unit Creation Date !.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });                   
                    ret = false;
                }
            }
           if (CRN == "") {
               $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
               $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
               });
                document.getElementById("<%=txtCRN.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCRN.ClientID%>").focus();
                ret = false;
           }

            var ChkIn = document.getElementById("<%=txtChkIn.ClientID%>").value.trim();
            var ChkOut = document.getElementById("<%=txtChkOut.ClientID%>").value.trim();
            document.getElementById("<%=txtChkIn.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtChkOut.ClientID%>").style.borderColor = "";
            if (ChkIn == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                         document.getElementById("<%=txtChkIn.ClientID%>").style.borderColor = "Red";

                         document.getElementById("<%=txtChkIn.ClientID%>").focus();

                         ret = false;
                     }
            if (ChkOut == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtChkOut.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtChkOut.ClientID%>").focus();
                ret = false;

            }
            if (ChkOut == ChkIn && ChkIn != "" && ChkOut != "") {
                $("#divWarning").html("Sorry, both Check-in time and Check-out time can't be same!");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
               
                         document.getElementById("<%=txtChkOut.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtChkIn.ClientID%>").style.borderColor = "Red";

                 ret = false;
             }
            if (ChkIn != "" && ChkOut != "" && ChkOut != ChkIn) {
                var Frmatches = ChkIn.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/);
                var FstChkIn = (parseInt(Frmatches[1]) + (Frmatches[3] == 'pm' ? 12 : 0)) + ':' + Frmatches[2] + ':00';
                var FromDateTime = dateString2Date('01-01-2016 ' + FstChkIn);

                var Tomatches = ChkOut.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/);
                var LstChkOt = (parseInt(Tomatches[1]) + (Tomatches[3] == 'pm' ? 12 : 0)) + ':' + Tomatches[2] + ':00';
                var ToDateTime = dateString2Date('01-01-2016 ' + LstChkOt);
                if (FromDateTime > ToDateTime) {
                    document.getElementById("<%=txtChkIn.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtChkOut.ClientID%>").style.borderColor = "Red";
                    $("#divWarning").html("Sorry, Check-in time cannot be greater than Check-out time!");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                  
                    ret = false;
                }
            }

            if (BsnsTypeText == "PARTNERSHIP") {

               

                var DeleteRowNumData = document.getElementById("<%=HiddenField6.ClientID%>").value;
                var DeleteRowNum = DeleteRowNumData.split(',');
                var count = DeleteRowNum.length;
                var rowCount = document.getElementById("<%=HiddenField7.ClientID%>").value;
                for (var x = 1; x <= rowCount; x++) {

                    var deleSTS = "false";
                    for (var i = 0; i < count; i++) {
                        if (x == DeleteRowNum[i]) {
                            deleSTS = "true";
                        }
                    }
                    

                    if (deleSTS != "true") {
                        
                        var FrmTime = document.getElementById("txtPartner" + x).value;
                        
                        var ToTime = document.getElementById("txtDocumentNo" + x).value;
                        var VhclId = document.getElementById("txtSharePerc" +x).value;
                            
                        if (x == rowCount-1 && FrmTime == 0 && ToTime == "" && VhclId == "") {
                            }
                            else {

                            document.getElementById("txtPartner" + x).style.borderColor = "";
                            $("div#divtxtPartner" + x + " input.ui-autocomplete-input").css("borderColor", "");

                                document.getElementById("txtDocumentNo" + x).style.borderColor = "";
                                document.getElementById("txtSharePerc" + x).style.borderColor = "";

                                if (FrmTime == 0 || FrmTime == "--SELECT PARTNER--") {

                                    document.getElementById("txtPartner" + x).style.borderColor = "Red";
                                    document.getElementById("txtPartner" + x).focus();
                                   
                                    $("div#divtxtPartner" + x + " input.ui-autocomplete-input").css("borderColor", "red");
                                    $("div#divtxtPartner" + x + " input.ui-autocomplete-input").select();
                                    $("div#divtxtPartner" + x + " input.ui-autocomplete-input").focus();

                                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                    });
                                    ret = false;
                                }
                                if (VhclId == "") {
                                    document.getElementById("txtSharePerc" + x).style.borderColor = "Red";
                                    document.getElementById("txtSharePerc" + x).focus();
                                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                    });
                                    ret = false;
                                }
                             
                                if (ToTime == "") {
                                    document.getElementById("txtDocumentNo" + x).style.borderColor = "Red";
                                    document.getElementById("txtDocumentNo" + x).focus();
                                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                    });
                                    ret = false;
                                }       
      
                            }
                       
                        }                  
                }
                if (cmpnySharePer == "") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                   document.getElementById("txtPartner1").style.borderColor = "Red";
                   document.getElementById("txtDocumentNo1").style.borderColor = "Red";
                   document.getElementById("txtSharePerc1").style.borderColor = "Red";
                   document.getElementById("txtPartner1").focus();

                   $("div#divtxtPartner1 input.ui-autocomplete-input").css("borderColor", "red");
                   $("div#divtxtPartner1 input.ui-autocomplete-input").select();
                   $("div#divtxtPartner1 input.ui-autocomplete-input").focus();
                  
                   ret = false;
                }

            }
            if (document.getElementById("<%=HiddenCorpChk.ClientID%>").value == "1") {
                //Start:-For bank validation

                //other tbl
                tableOtherItem = document.getElementById("TableBankDtlBody");
                if (tableOtherItem.rows.length == 1) {
                    for (var i = 0; i < tableOtherItem.rows.length; i++) {
                        if (i != tableOtherItem.rows.length) {
                            // FIX THIS
                            var row = tableOtherItem.rows[i];

                            var xLoop = (tableOtherItem.rows[i].cells[0].innerHTML);

                            if (CheckAllRowFieldAndHighlightBank(xLoop, false) == false) {
                                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                });
                                ret = false;
                                //break;
                            }
                        }
                    }
                }
                else {
                    for (var i = tableOtherItem.rows.length - 1; i >= 0 ; i--) {
                        if (i != tableOtherItem.rows.length) {
                            // FIX THIS
                            var row = tableOtherItem.rows[i];

                            var xLoop = (tableOtherItem.rows[i].cells[0].innerHTML);

                            if (CheckAllRowFieldAndHighlightBank(xLoop, false) == false) {
                                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                });
                                ret = false;
                                // break;
                            }
                        }
                    }
                }
            }

            //End:-For bank validation

            if (CorpType == "BRANCH OFFICE") {

                if (ParentTypeText == "--Select Parent Unit--") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=ddlParent.ClientID%>").style.borderColor = "Red";
                    var OrgnTypeFocus = document.getElementById("<%=ddlParent.ClientID%>").focus();
                    $("div#divddlParent input.ui-autocomplete-input").css("borderColor", "red");
                    $("div#divddlParent input.ui-autocomplete-input").select();
                    $("div#divddlParent input.ui-autocomplete-input").focus();

                    ret = false;
                }
            }
            if (CorpType == "--Select Office Type--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=ddlOfficeTyp.ClientID%>").style.borderColor = "Red";
                var OrgnTypeFocus = document.getElementById("<%=ddlOfficeTyp.ClientID%>").focus();
                ret = false;
            }

            var data = date.split("-");
            if (isNaN(Date.parse(data[2] + "-" + data[1] + "-" + data[0]))) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtDate.ClientID%>").focus();
                ret = false;

            }
            if (EditVal == "") {
                if (dateDateCntrlr < dateCurrentDate) {
                    document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtDate.ClientID%>").focus();
                    $("#divWarning").html("Sorry, Software Date cannot be Less than Business Unit Creation Date !.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });                  
                    ret = false;
                }
            }

            if (EmailStrg != "") {
                if (!filter.test(EmailStrgg.value)) {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById('ErrortxtMailStrg').style.display = "";
                    document.getElementById("<%=txtMailStrg.ClientID%>").focus();
                    document.getElementById("<%=txtMailStrg.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
            }


            if (CorpFiscal == "--Select Month--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                var OrgnLicPacFocus = document.getElementById("<%=ddlFiscalMonth.ClientID%>").focus();
                document.getElementById("<%=ddlFiscalMonth.ClientID%>").style.borderColor = "Red";

                $("div#divddlFiscalMonth input.ui-autocomplete-input").css("borderColor", "red");
                $("div#divddlFiscalMonth input.ui-autocomplete-input").select();
                $("div#divddlFiscalMonth input.ui-autocomplete-input").focus();
                 ret = false;
             }
            if (EmailEnq != "") {
                if (!filter.test(EmailEnqq.value)) {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById('ErrorMsgCorpEnqEmail').style.display = "";
                    document.getElementById("<%=txtEnqMail.ClientID%>").focus();
                    document.getElementById("<%=txtEnqMail.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
            }
           
            if (!filter.test(Email.value)) {

                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById('ErrorMsgCorpEmail').style.display = "";
                document.getElementById("<%=txtCorpEmail.ClientID%>").focus();
                document.getElementById("<%=txtCorpEmail.ClientID%>").style.borderColor = "Red";
                ret = false;
            }
            if (web != "") {
                if (!re.test(web)) {

                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById('ErrortxtCorpWebsite').style.display = "";
                    document.getElementById("<%=txtCorpWebsite.ClientID%>").focus();
                    document.getElementById("<%=txtCorpWebsite.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
            }
            if (!mobileregular.test(CorpMobile)) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById('ErrortxtCorpMobile').style.display = "";
                var OrgMobileFocus = document.getElementById("<%=txtCorpMobile.ClientID%>").focus();
                document.getElementById("<%=txtCorpMobile.ClientID%>").style.borderColor = "Red";
                ret = false;
            }
           

            if (CorpCountry == "--Select Country--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=ddlCorpCountry.ClientID%>").focus();
                document.getElementById("<%=ddlCorpCountry.ClientID%>").style.borderColor = "Red";

                $("div#divddlCorpCountry input.ui-autocomplete-input").css("borderColor", "red");
                $("div#divddlCorpCountry input.ui-autocomplete-input").select();
                $("div#divddlCorpCountry input.ui-autocomplete-input").focus();

                ret = false;
            }
            if (CorpAdd == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtCorpAdd1.ClientID%>").focus();
                document.getElementById("<%=txtCorpAdd1.ClientID%>").style.borderColor = "Red";
                ret = false;
            }

            if (BsnsTypeText == "PARTNERSHIP") {

                if (ShareTypeText == "--Select Share Type--") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=ddlShareTyp.ClientID%>").style.borderColor = "Red";
                    var OrgnTypeFocus = document.getElementById("<%=ddlShareTyp.ClientID%>").focus();
                    ret = false;
                }
            }

            if (code != "") {
                if (document.getElementById("<%=hiddenOldCode.ClientID%>").value != code) {
                    if (CheckDupCode() == false) {
                        DuplicationCode();
                        ret = false;
                    }
                }
            }

            if (CorpName != "") {
                if (document.getElementById("<%=hiddenOldName.ClientID%>").value != CorpName) {
                    if (CheckDupCorpName() == false) {
                        DuplicationName();
                        ret = false;
                    }
                }
            }

            if (code == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtCode.ClientID%>").style.borderColor = "Red";
                var OrgnTypeFocus = document.getElementById("<%=txtCode.ClientID%>").focus();
                ret = false;
            }


            if (BsnsTypeText == "--Select Business Type--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=ddlBsnsTyp.ClientID%>").style.borderColor = "Red";
                var OrgnTypeFocus = document.getElementById("<%=ddlBsnsTyp.ClientID%>").focus();
                ret = false;
            }

            if (CorpName == "") {

                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtCorpName.ClientID%>").focus();
                document.getElementById("<%=txtCorpName.ClientID%>").style.borderColor = "Red";
                ret = false;
            }



            if (ret == false) {
                CheckSubmitZero();

            }
            else {
                
                document.getElementById("<%=HiddenPartner.ClientID%>").value = "";

                document.getElementById("<%=hiddenEmpDdlData.ClientID%>").value = null;
                tbClientTotalValues = '';
                tbClientTotalValues = [];
                if (document.getElementById("<%=HiddenCorpChk.ClientID%>").value == "1") {
                tableOtherItem = document.getElementById("TableBankDtlBody");
                for (var i = 0; i < tableOtherItem.rows.length; i++) {

                    var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);

                    var BankId = document.getElementById("ddlBank" + validRowID).value;

                    var Branch = document.getElementById("txtBranch" + validRowID).value.trim();
                    NameWithoutReplace = Branch;
                    replaceText1 = NameWithoutReplace.replace(/</g, "");
                    replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("txtBranch" + validRowID).value = replaceText2;

                    Branch = document.getElementById("txtBranch" + validRowID).value;

                    var IBAN = document.getElementById("txtIBAN" + validRowID).value.trim();
                    NameWithoutReplace = IBAN;
                    replaceText1 = NameWithoutReplace.replace(/</g, "");
                    replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("txtIBAN" + validRowID).value = replaceText2;

                    IBAN = document.getElementById("txtIBAN" + validRowID).value;


                    var tbDetailID = document.getElementById("tdDtlId" + validRowID).innerHTML;
                    var EvtAction = document.getElementById("tdEvt" + validRowID).innerHTML;
                    var DetailID = "";
                    if (tbDetailID == "") {
                        DetailID = 0;
                    }
                    else {
                        DetailID = tbDetailID;
                    }
                                 
                    addToLocalStorage(BankId, Branch, IBAN, DetailID, EvtAction);
                    

                }
            }
            }
            $(window).scrollTop(0);
            return ret;

        }


        function ChangeBsnsType() {

            var BsnsType = document.getElementById("<%=ddlBsnsTyp.ClientID%>");

             var BsnsTypeText = BsnsType.options[BsnsType.selectedIndex].text;

             if (BsnsTypeText == "PARTNERSHIP") {
                 
                 document.getElementById("<%=ddlShareTyp.ClientID%>").disabled = false;                  
                 document.getElementById('divPrtnshp').style.display = "block";

                 
            }
            else {
                 document.getElementById("<%=ddlShareTyp.ClientID%>").disabled = true;
                 document.getElementById('divPrtnshp').style.display = "none";
            }
        }

        function ChangeOfficeType() {

            var OfficeType = document.getElementById("<%=ddlOfficeTyp.ClientID%>");
            var OfficeTypeText = OfficeType.options[OfficeType.selectedIndex].text;

            if (OfficeTypeText == "BRANCH OFFICE") {

                 document.getElementById("<%=ddlParent.ClientID%>").disabled = false;
                $("div#divddlParent input.ui-autocomplete-input").prop('disabled', false);

             }
             else {
                document.getElementById("<%=ddlParent.ClientID%>").disabled = true;
                $("div#divddlParent input.ui-autocomplete-input").prop('disabled', true);
                $("div#divddlParent input.ui-autocomplete-input").val("--Select Parent Unit--");
                document.getElementById("cphMain_ddlParent").value = "--Select Parent Unit--";
                $("div#divddlParent input.ui-autocomplete-input").css("borderColor", "");
             }
         }

        function selectorToAutocompleteState(ev) {
            var $au = jQuery.noConflict();
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var countryID = document.getElementById("cphMain_ddlCorpCountry").value;
           if (countryID != "--Select Country--" && countryID != "" && corptID != '' && corptID != null && (!isNaN(corptID)) && orgID != '' && orgID != null && (!isNaN(orgID))) {
               $au("#cphMain_ddlCorpState").autocomplete({
                   source: function (request, response) {
                       $.ajax({
                           url: "gen_Corp_Office.aspx/changeState",
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
                       document.getElementById("cphMain_ddlCorpState").value = i.item.label;
                    },
                    change: function (event, ui) {
                        if (ui.item) {
                        }
                        else {
                            document.getElementById("cphMain_ddlCorpState").value = "";
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
                $au("#cphMain_ddlCity").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "gen_Corp_Office.aspx/changeCity",
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
                        document.getElementById("cphMain_ddlCity").value = i.item.label;
                        document.getElementById("<%=HiddenFieldCity.ClientID%>").value = i.item.val;
                    },
                    change: function (event, ui) {
                        if (ui.item) {

                        }
                        else {
                            document.getElementById("cphMain_ddlCity").value = "";
                            document.getElementById("<%=HiddenFieldCity.ClientID%>").value = "";
                        }
                    }
                });
            }
        }
        function changeCountry() {
            document.getElementById("cphMain_ddlCorpState").value = "";
            document.getElementById("<%=HiddenFieldState.ClientID%>").value = "";
            document.getElementById("cphMain_ddlCity").value = "";
            document.getElementById("<%=HiddenFieldCity.ClientID%>").value = "";
            IncrmntConfrmCounter();
        }
        function changeState() {
            document.getElementById("cphMain_ddlCity").value = "";
            document.getElementById("<%=HiddenFieldCity.ClientID%>").value = "";
            if (document.getElementById("<%=HiddenFieldState.ClientID%>").value == "") {
                document.getElementById("cphMain_ddlCorpState").value = "";
            }
            IncrmntConfrmCounter();
        }
        function changeCity() {
            if (document.getElementById("<%=HiddenFieldCity.ClientID%>").value == "") {
                document.getElementById("cphMain_ddlCity").value = "";
            }
            IncrmntConfrmCounter();
        }
    </script>
    
<script type="text/javascript">
    function orgAdd() {
       
       
      var orgid=document.getElementById("<%=hiddenOrgId.ClientID%>").value;
       
        

            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_Corp_Office.aspx/ReadOrgInfo",
                data: '{orgId: "' + orgid + '"}',
                dataType: "json",
                success: function (data) {

                    if (data.d != '') {
                      
                       
                        if (document.getElementById('cphMain_CheckBox2').checked == true) {

                            document.getElementById("<%=txtCorpAdd1.ClientID%>").value = data.d.strAdd1;
                            document.getElementById("<%=txtCorpAdd2.ClientID%>").value = data.d.strAdd2;
                            document.getElementById("<%=txtCorpAdd3.ClientID%>").value = data.d.strAdd3;
                           
                        }
                        else {
                            document.getElementById("<%=txtCorpAdd1.ClientID%>").value = "";
                            document.getElementById("<%=txtCorpAdd2.ClientID%>").value = "";
                            document.getElementById("<%=txtCorpAdd3.ClientID%>").value = "";
                           
                        }
                      
                              }
                          },
                          error: function (result) {
                              
                          }
                      });

                  
        
    }

    function orgInfo() {


        var orgid = document.getElementById("<%=hiddenOrgId.ClientID%>").value;



         $.ajax({
             type: "POST",
             async: false,
             contentType: "application/json; charset=utf-8",
             url: "gen_Corp_Office.aspx/ReadOrgInfo",
             data: '{orgId: "' + orgid + '"}',
             dataType: "json",
             success: function (data) {

                 if (data.d != '') {


                    
                        if (document.getElementById('cphMain_cbxSameOrg').checked == true) {
                            document.getElementById("<%=txtCRN.ClientID%>").value = data.d.strCRN;
                            document.getElementById("<%=txtCRNExpDate.ClientID%>").value = data.d.strCRNexp;
                            document.getElementById("<%=txtCRNIssDate.ClientID%>").value = data.d.strCRNiss;
                            document.getElementById("<%=txtTIN.ClientID%>").value = data.d.strTIN;
                            document.getElementById("<%=txtTINExp.ClientID%>").value = data.d.strTINexp;
                            document.getElementById("<%=txtTINIss.ClientID%>").value = data.d.strTINiss;
                            document.getElementById("<%=txtCCN.ClientID%>").value = data.d.strCCN;
                            document.getElementById("<%=txtCCNExp.ClientID%>").value = data.d.strCCNexp;
                            document.getElementById("<%=txtCCNIss.ClientID%>").value = data.d.strCCNiss;



                        }
                        else {
                            document.getElementById("<%=txtCRN.ClientID%>").value = "";
                            document.getElementById("<%=txtCRNExpDate.ClientID%>").value = "";
                            document.getElementById("<%=txtCRNIssDate.ClientID%>").value = "";
                            document.getElementById("<%=txtTIN.ClientID%>").value = "";
                            document.getElementById("<%=txtTINExp.ClientID%>").value = "";
                            document.getElementById("<%=txtTINIss.ClientID%>").value = "";
                            document.getElementById("<%=txtCCN.ClientID%>").value = "";
                            document.getElementById("<%=txtCCNExp.ClientID%>").value = "";
                            document.getElementById("<%=txtCCNIss.ClientID%>").value = "";


                        }
                    }
                },
                error: function (result) {

                }
            });



        }
</script>

    <script type="text/javascript">
        function TinLength() {
            var TinNumber = document.getElementById("<%=txtTinNumber.ClientID%>").value;
            var TinLength = TinNumber.length;
            if (TinLength == 11) {
                document.getElementById("<%=txtTinNumber.ClientID%>").style.borderColor = "";
                document.getElementById('ErrorMsgTINNumber').style.visibility = "hidden";
            }
            else {
                document.getElementById('ErrorMsgTINNumber').style.visibility = "visible";

                document.getElementById("<%=txtTinNumber.ClientID%>").style.borderColor = "orange";
            }
        }
    </script>

    <script type="text/javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //enter
            if (keyCodes == 13 ) {
               
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
                //left arrow key,right arrow key,home,end ,delete,UP ARROW ,DOWN ARROW
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

        function isNumberPhone(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //enter
            if (keyCodes == 13 || keyCodes == 190|| keyCodes == 16) {

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
                //left arrow key,right arrow key,home,end ,delete,UP ARROW ,DOWN ARROW
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
        function isNumberDate(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //enter
            if (keyCodes == 13) {
                return false;
            }
                //dash
            else if (keyCodes == 173) {
                return true;
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46) {
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
        function AlertClearAll() {
            if (confirmbox > 0) {

                ezBSAlert({
                    type: "confirm",
                    messageText: "Are You Sure You Want Clear All Data In This Page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "gen_Corp_Office.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
              
            }
            else {
                window.location.href = "gen_Corp_Office.aspx";

            }
        }

    </script>

    <script type="text/javascript">

       
      
        function selectorToAutocompleteTextBox(obj, x) {

          

         var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
          
         var $cc = jQuery.noConflict();

        
        if (OrgId != '' && OrgId != null && (!isNaN(OrgId))) {
            
            $cc("#" + obj).autocomplete({
                
                source: function (uuuest, response) {
                   
                    $cc.ajax({
                        url: '<%=ResolveUrl("WebServiceAutoCompletePartner.asmx/GetPartner") %>',
                                  data: "{ 'strLikePartner': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'intOrgId': '" + parseInt(OrgId) + "'  }",
                                  dataType: "json",
                                  type: "POST",
                                  contentType: "application/json; charset=utf-8",
                                  success: function (data) {

                                      response($cc.map(data.d, function (item) {
                                          return {
                                              label: item.split('<->')[1],
                                              val: item.split('<->')[0]
                                          }
                                      }))
                                  },
                                  error: function (response) {

                                  },
                                  failure: function (response) {

                                  }
                              });
                          },
                          autoFocus: true,

                          select: function (e, i) {
                              document.getElementById("txtPartnerId" + x).value = i.item.val;
                              document.getElementById("txtPartnerName" + x).value = i.item.label;

                          },

                          minLength: 1

                      });
                  }
              }
    </script>

    <script>
        //For bank details table

        var $noBank = jQuery.noConflict();
        var rowCountBank = 100;
        var RowIndexBank = 100;
        var slNo = 0;


        function addMoreRowsBank(frm, boolFocus, boolAppendorNot, row_index) {

            rowCountBank++;
            RowIndexBank++;
            slNo++;

            var recRow = '<tr id="rowId_' + rowCountBank + '" >';
            recRow += '<td id="tdId' + rowCountBank + '" style="display: none;">' + rowCountBank.toString() + '</td>';
            recRow += '<td style="width: 2.8%;text-align: center;display: none;"><div id="divSlNum' + rowCountBank + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + slNo.toString() + ' </div></td>';


            recRow += '<td id="tdBank' + rowCountBank + '"  class="tr_l"><div id="divddlBank' + rowCountBank + '">';
            recRow += '<select id="ddlBank' + rowCountBank + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" onkeypress="return isTag(event);" onchange="IncrmntConfrmCounter();"/>';
            recRow += '</div></td> ';
         

            recRow += '<td id="tdBranch' + rowCountBank + '" >';
            recRow += '<input  id="txtBranch' + rowCountBank + '" class="form-control fg2_inp2" placeholder="Branch"  type="text"  onkeypress="return isTag(event)" onchange="IncrmntConfrmCounter();" maxlength=100 />';
            recRow += '</td> ';

            recRow += ' <td id="tdIBAN' + rowCountBank + '" >';
            recRow += ' <input class="form-control fg2_inp2" placeholder="IBAN#" id="txtIBAN' + rowCountBank + '"   onblur="return BlurIban(' + rowCountBank + ')" onchange="IncrmntConfrmCounter();"  type="text"  onkeypress="return isTag(event)"  maxlength=50 />';
            recRow += '   </td> ';

         
            recRow += '<td>'; 
            recRow += '<div class="btn_stl1">';
            recRow += '<button id="tdIndvlAddMoreRowPic' + rowCountBank + '" onclick="return CheckaddMoreRowsBank(\'' + rowCountBank + '\',true);" class="btn act_btn bn2" title="Add">';
            recRow += '<i class="fa fa-plus-circle"></i>';
            recRow += '</button>';           
            recRow += '<button class="btn act_btn bn3" onclick = "return removeRowBank(' + rowCountBank + ',\'Are you sure you want to Delete this Entry?\');"  title="Delete">';
            recRow += '<i class="fa fa-trash"></i>';
            recRow += '</button>';
            recRow += '</div>';
            recRow += '</td>';

            recRow += ' <td id="tdInx' + rowCountBank + '" style="display: none;" > </td>';
            recRow += '<td id="tdSave' + rowCountBank + '" style="display: none;"> </td>';
            recRow += '<td id="tdEvt' + rowCountBank + '" style="display: none;">INS</td>';
            recRow += '<td id="tdDtlId' + rowCountBank + '" style="display: none;"></td>';
            recRow += '<td id="tdChanged' + rowCountBank + '" style="display: none;"></td>';
            recRow += '</tr>';
    

            if (boolAppendorNot == false) {
                //to append
                jQuery('#TableBankDtlBody').append(recRow);
            }
            else {

                // to insert in perticular position
                var $NoAppnd = jQuery.noConflict();
                if (parseInt(row_index) != 0) {
                    $NoAppnd('#TableBankDtlBody > tbody > tr').eq(parseInt(row_index) - 1).after(recRow);
                }
                else {

                    var TableRowCount = document.getElementById("TableBankDtlBody").rows.length;

                    if (parseInt(TableRowCount) != 0) {
                        $NoAppnd('#TableBankDtlBody > tbody > tr').eq(parseInt(row_index)).before(recRow);
                    }
                    else {

                        jQuery('#TableBankDtlBody').append(recRow);
                    }
                }

            }
            FillddlEmployee(rowCountBank);
            $au('#ddlBank' + rowCountBank).selectToAutocomplete1Letter();


        }




        function EditListRowsBank(EditBankID, EditBranch, EditIBAN, EditDtlId,Mode,BankName,Status) {

            var RowCountTotal = document.getElementById("<%=HiddenFieldEditBankCountRow.ClientID%>").value; 

            if (EditBankID != "0" && EditBranch != "" && EditIBAN != "" && EditDtlId != "") {



                rowCountBank++;
                RowIndexBank++;
                slNo++;
                var recRow = '<tr id="rowId_' + rowCountBank + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCountBank.toString() + '</td>';
                recRow += '<td style="width: 2.8%;text-align: center;display: none;"><div id="divSlNum' + rowCountBank + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + slNo.toString() + ' </div></td>';

                recRow += '<td id="tdBank' + rowCountBank + '"  class="tr_l"><div id="divddlBank' + rowCountBank + '">';
                recRow += '<select id="ddlBank' + rowCountBank + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" onkeypress="return isTag(event);" onchange="IncrmntConfrmCounter();"/>';
                recRow += '<div></td> ';


                recRow += '<td id="tdBranch' + rowCountBank + '" >';
                recRow += '<input value="' + EditBranch + '" id="txtBranch' + rowCountBank + '" class="form-control fg2_inp2" placeholder="Branch"  type="text"  onkeypress="return isTag(event)" onchange="IncrmntConfrmCounter();" maxlength=100 />';
                recRow += '</td> ';

                recRow += ' <td id="tdIBAN' + rowCountBank + '" >';
                recRow += ' <input value="' + EditIBAN + '" class="form-control fg2_inp2" placeholder="IBAN#" id="txtIBAN' + rowCountBank + '"   onblur="return BlurIban(' + rowCountBank + ')" onchange="IncrmntConfrmCounter();"  type="text"  onkeypress="return isTag(event)"  maxlength=50 />';
                recRow += '   </td> ';


                recRow += '<td>';
                recRow += '<div class="btn_stl1">';
                recRow += '<button  id="tdIndvlAddMoreRowPic' + rowCountBank + '" onclick="return CheckaddMoreRowsBank(\'' + rowCountBank + '\',true);" class="btn act_btn bn2" title="Add">';
                recRow += '<i class="fa fa-plus-circle"></i>';
                recRow += '</button>';
                recRow += '<button id="tdRemovePic' + rowCountBank + '" class="btn act_btn bn3" onclick = "return removeRowBank(' + rowCountBank + ',\'Are you sure you want to Delete this Entry?\');"  title="Delete">';
                recRow += '<i class="fa fa-trash"></i>';
                recRow += '</button>';
                recRow += '</div>';
                recRow += '</td>';


                recRow += ' <td id="tdInx' + rowCountBank + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCountBank + '" style="display: none;"> </td>';
                recRow += '<td id="tdEvt' + rowCountBank + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCountBank + '" style="display: none;">' + EditDtlId + '</td>';

                recRow += '<td id="tdChanged' + rowCountBank + '" style="display: none;"></td>';
                recRow += '</tr>';


                jQuery('#TableBankDtlBody').append(recRow);
              
                if (RowCountTotal != slNo) {
                    document.getElementById("tdIndvlAddMoreRowPic" + rowCountBank).disabled = true;
                    document.getElementById("tdInx" + rowCountBank).innerHTML = rowCountBank;
                }
              




                FillddlEmployee(rowCountBank);

                if (Mode == 1) {

                    document.getElementById("ddlBank" + rowCountBank).disabled = true;
                    document.getElementById("txtBranch" + rowCountBank).disabled = true;
                    document.getElementById("txtIBAN" + rowCountBank).disabled = true;
                    document.getElementById("tdIndvlAddMoreRowPic" + rowCountBank).disabled = true;
                    document.getElementById("tdRemovePic" + rowCountBank).disabled = true;
                }


                if (EditBankID != "" ) {

                    elmnt = document.getElementById("ddlBank" + rowCountBank);

                    for (var i = 0; i < elmnt.options.length; i++) {

                        if (elmnt.options[i].value == EditBankID) {

                            elmnt.selectedIndex = i;
                        }
                        else if (Status == "0") {

                            var newOption = "<option value='" + EditBankID + "'>" + BankName + "</option>";

                            document.getElementById("ddlBank" + rowCountBank).innerHTML = newOption;

                            FillddlEmployee(rowCountBank);
                        }
                    }
                }

                $au('#ddlBank' + rowCountBank).selectToAutocomplete1Letter();

            }


        }

        function BlurIban(x) {
            var RcptNumberWithoutReplace = document.getElementById("txtIBAN" + x).value;
            //EVM-0027
            var Bank1 = document.getElementById("ddlBank" + x).value;
       
            var replaceText1 = RcptNumberWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/'/g, "");
            var replaceText4 = replaceText3.replace(/"/g, "");
            var replaceText5 = replaceText4.replace(/\\/g, "");

            var tableOtherItem = document.getElementById("TableBankDtlBody");
            for (var i = 0; i < tableOtherItem.rows.length; i++) {
                var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);               
                var Bank = document.getElementById("ddlBank" + validRowID).value;
                var IBanOld = document.getElementById("txtIBAN" + validRowID).value;


                if (validRowID != x && IBanOld == replaceText5.trim()) {
                    $("#divWarning").html("IBAN number cant be duplicated.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });                 
                    replaceText5 = "";
                }


                //if (validRowID != x && IBanOld == replaceText5.trim() && Bank == Bank1)                    
                //{
                //    alert("IBAN number cant be duplicated.");
                //    replaceText5 = "";
                //}
            }
            //EVM-0027
            document.getElementById("txtIBAN" + x).value = replaceText5.trim();
            //For check Iban duplication in other corp offices
            var IbanNew = document.getElementById("txtIBAN" + x).value;
          //  alert(IbanNew);
            if (IbanNew != "") {
                var corpId = document.getElementById("<%=HiddenFieldCorpID.ClientID%>").value;
                var ORGiD = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
                
                if (corpId == "")
                    corpId = 0;
                //var Details = PageMethods.CheckDupIban(corpId, IbanNew,ORGiD, function (response) {

                //    if (response == "true") {
                //        alert("IBAN number cant be duplicated.");
                //        document.getElementById("txtIBAN" + x).value = "";
                //    }

                //});
            }
        }



        function FillddlEmployee(rowCount) {
            var ddlTestDropDownListXML = "";
          
            ddlTestDropDownListXML = $noCon("#ddlBank" + rowCount);
           
              // Provide Some Table name to pass to the WebMethod as a paramter.
              var tableName = "dtTableEmployee";
              if (document.getElementById("<%=hiddenEmpDdlData.ClientID%>").value != 0) {
                  ddlEmpdata = document.getElementById("<%=hiddenEmpDdlData.ClientID%>").value;
                  var OptionStart = $noCon("<option>--SELECT--</option>");
                  OptionStart.attr("value", 0);
                  ddlTestDropDownListXML.append(OptionStart);
                  // Now find the Table from response and loop through each item (row).
                  $noCon(ddlEmpdata).find(tableName).each(function () {
                      // Get the OptionValue and OptionText Column values.
                      var OptionValue = $noCon(this).find('BANK_ID').text();
                      var OptionText = $noCon(this).find('BANK_NAME').text();
                      // Create an Option for DropDownList.
                      var option = $noCon("<option>" + OptionText + "</option>");
                      option.attr("value", OptionValue);

                      ddlTestDropDownListXML.append(option);
                  });
              }
              else {
                  var OptionStart = $noCon("<option>--SELECT--</option>");
                  OptionStart.attr("value", 0);
                  ddlTestDropDownListXML.append(OptionStart);
              }
           
        }

        //checking add more rows
        function CheckaddMoreRowsBank(x, retBool) {

            var check = document.getElementById("tdInx" + x).innerHTML;
             //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
             //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
             if (check == " ") {

                 if (retBool == true) {

                     if (CheckAllRowFieldAndHighlightBank(x, false) == true) {

                         document.getElementById("tdInx" + x).innerHTML = x;
                         document.getElementById("tdIndvlAddMoreRowPic" + x).disabled = true;
                         addMoreRowsBank(this.form, retBool, false, 0);
                         return false;
                     }
                 }

                 else if (retBool == false) {

                     var row_index = jQuery('#rowId_' + x).index();
                     if (CheckAllRowFieldBank(x, row_index) == true) {
                         document.getElementById("tdInx" + x).innerHTML = x;
                         document.getElementById("tdIndvlAddMoreRowPic" + x).disabled = true;
                         addMoreRowsBank(this.form, retBool, false, 0);
                         return false;
                     }
                 }
             }
             return false;
         }



         // checks every field in row
         function CheckAllRowFieldBank(x, row_index) {
             ret = true;

             // alert('check all row');

             var Bank = document.getElementById("ddlBank" + x).value;
             if (Bank == "--SELECT--" || Bank == 0) {
                 ret = false;
             }

             var Branch = document.getElementById("txtBranch" + x).value.trim();
             if (Branch == "") {
                 ret = false;
             }

             var IbanNo = document.getElementById("txtIBAN" + x).value;
             if (IbanNo == "") {
                 ret = false;
             }

             return ret;
         }




         // checks every field in row
         function CheckAllRowFieldAndHighlightBank(x, blFromBlurValue) {
             ret = true;

             document.getElementById("ddlBank" + x).style.borderColor = "";
             $("div#divddlBank"+x+" input.ui-autocomplete-input").css("borderColor", "");


             document.getElementById("txtBranch" + x).style.borderColor = "";
             document.getElementById("txtIBAN" + x).style.borderColor = "";

             var IbanNo = document.getElementById("txtIBAN" + x).value;
             if (IbanNo == "") {
                 document.getElementById("txtIBAN" + x).style.borderColor = "Red";
                 document.getElementById("txtIBAN" + x).focus();
                 $noCon("#txtIBAN" + x).select();
                 ret = false;
             }
             var Branch = document.getElementById("txtBranch" + x).value;
             if (Branch == "") {
                 document.getElementById("txtBranch" + x).style.borderColor = "Red";
                 document.getElementById("txtBranch" + x).focus();
                 $noCon("#txtBranch" + x).select();
                 ret = false;
             }

             var Bank = document.getElementById("ddlBank" + x).value;
             if (Bank == "--SELECT--"||Bank==0) {
                 document.getElementById("ddlBank" + x).style.borderColor = "Red";
                 document.getElementById("ddlBank" + x).focus();
                 $noCon("#ddlBank" + x).select();

                 $("div#divddlBank" + x + " input.ui-autocomplete-input").css("borderColor", "red");
                 $("div#divddlBank" + x + " input.ui-autocomplete-input").select();
                 $("div#divddlBank" + x + " input.ui-autocomplete-input").focus();
                 ret = false;
             }

             return ret;

         }


         //for removing row
         function removeRowBank(removeNum, CofirmMsg) {
             ezBSAlert({
                 type: "confirm",
                 messageText: CofirmMsg,
                 alertType: "info"
             }).done(function (e) {
                 if (e == true) {
                     var row_index = jQuery('#rowId_' + removeNum).index();
                     var BforeRmvTableRowCount = document.getElementById("TableBankDtlBody").rows.length;


                     jQuery('#rowId_' + removeNum).remove();
                     RowIndexBank--;
                     slNo--;
                     var TableRowCount = document.getElementById("TableBankDtlBody").rows.length;

                     if (TableRowCount != 0) {

                         var idlast = $noC('#TableBankDtlBody tr:last').attr('id');
                         //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                         //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                         if (idlast != "") {
                             var res = idlast.split("_");
                             //  alert(res[1]);
                             document.getElementById("tdInx" + res[1]).innerHTML = " ";
                             document.getElementById("tdIndvlAddMoreRowPic" + res[1]).disabled = false;
                         }
                     }
                     else {

                         addMoreRowsBank(this.form, true, false, 0);
                     }

                     if (BforeRmvTableRowCount > 1) {

                         if ((BforeRmvTableRowCount - 1) == row_index) {
                             var table = document.getElementById("TableBankDtlBody");
                             var preRowId = table.rows[row_index - 1].id;
                             if (preRowId != "") {
                                 var res = preRowId.split("_");
                                 if (res[1] != "") {
                                     ReNumberTableBank();

                                 }
                             }
                         }
                         else {
                             var table = document.getElementById("TableBankDtlBody");
                             var NxtRowId = table.rows[row_index].id;
                             if (NxtRowId != "") {
                                 var res = NxtRowId.split("_");
                                 if (res[1] != "") {

                                     //document.getElementById("txtPartner" + res[1]).focus();
                                     //$noCon("#txtPartner" + res[1]).select();
                                     ReNumberTableBank();

                                 }
                             }

                         }
                     }

                     return false;
                 }
                 else {
                     return false;
                 }
             });
             return false;

            
         }



         //this function is to RE-NUMBER table when deletion .as it show duplicate sl num when deleted othre than last row
         function ReNumberTableBank() {
             //if (idlast != "") {
             //    var res = idlast.split("_");

             //    document.getElementById("tdInx" + res[1]).innerHTML = " ";
             //    document.getElementById("tdIndvlAddMoreRow" + res[1]).style.opacity = "1";
             //}
             var table = "";


             table = document.getElementById("TableBankDtlBody");

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

                             //   alert('i :' + intcount);
                             document.getElementById("divSlNum" + x).innerHTML = intRecount;

                             var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
                             if (SavedorNot == "saved") {
                                 //  var row_index = jQuery('#rowId_' + x).index();

                                 // LocalStorageEdit(x, row_index);

                             }
                         }
                     }

                     //iterate through columns
                     //columns would be accessed using the "col" variable assigned in the for loop
                     // alert(col.innerHTML);
                 }
             }
         }
         var rowCountLocalStore = 0;
         function addToLocalStorage(BankId, Branch,IbanNo , DetailID, EvtAction) {
             //alert(textRemarks);
             var $add = jQuery.noConflict();

             var client = JSON.stringify({
                 ROWID: "" + rowCountLocalStore + "",
                 BANKID: "" + BankId + "",
                 BRANCH: "" + Branch + "",
                 IBAN: "" + IbanNo + "",
                 DETAILID: "" + DetailID + "",
                 EVTACTION: "" + EvtAction + ""
             });
             tbClientTotalValues.push(client);
             document.getElementById("<%=hiddenTotalData.ClientID%>").value = JSON.stringify(tbClientTotalValues);
            //alert(document.getElementById("<%=hiddenTotalData.ClientID%>").value);
             rowCountLocalStore++;
         }
    </script>

    <script type="text/javascript">



         var $noC = jQuery.noConflict();
         var rowCount = 0;
         //rowCount for uniquness
         //row index add(+) and (-)delete count based on action
         var RowIndex = 0;


         function addMoreRows(frm, boolFocus, boolAppendorNot, row_index) {
           
            rowCount++;
            RowIndex++;
            var recRow = '<tr id="rowId_' + rowCount + '" >';
            recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
            recRow += '<td style="width: 2.8%;text-align: center;display: none;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';
         
            recRow += ' <td id="tdPartner' + rowCount + '"  class="tr_l"><div id="divtxtPartner' + rowCount + '">';
            recRow += ' <select  id="txtPartner' + rowCount + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" type="text"   onblur="return BlurPartner(' + rowCount + ')" onkeypress="return DisableEnter(event)" onchange="return ReadDocument(' + rowCount + ')"  maxlength=100 />';
            recRow += ' </div></td> ';
            recRow += ' <td  style="display: none;"><input id="txtPartnerId' + rowCount + '"  value="--Select Partner--" type="text"   /></td>';
            recRow += ' <td  style="display: none;"><select id="txtPartnerName' + rowCount + '" value="--Select Partner--" type="text" maxlength=100  /></td>';

            recRow += ' <td id="tdDocumentNo' + rowCount + '"  class="tr_l">';
            recRow += ' <input  id="txtDocumentNo' + rowCount + '" class="form-control fg2_inp2" placeholder="Document#"  type="text" onblur="return BlurDocumentNo(' + rowCount + ')" onkeypress="return DisableEnter(event)" maxlength=100 />';
            recRow += '   </td> ';

            recRow += ' <td id="tdSharePer' + rowCount + '"  class="tr_c">';
            recRow += ' <input  id="txtSharePerc' + rowCount + '" class="form-control fg2_inp2 tr_c" placeholder="Share %"  type="text" onblur="return BlurSharePerc(' + rowCount + ')" onkeypress="return DisableEnter(event)" onkeydown="return isNumber(event);" maxlength=5 />';
            recRow += '   </td> ';


            recRow += '<td>'; 
            recRow += '<div class="btn_stl1">';
            recRow += '<button class="btn act_btn bn2"  id="tdIndvlAddMoreRowPic' + rowCount + '" onclick="return CheckaddMoreRows(\'' + rowCount + '\',true);" title="Add">';
            recRow += '<i class="fa fa-plus-circle"></i>';
            recRow += '</button>';                 
            recRow += '<button class="btn act_btn bn3" onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to Delete this Entry?\');" title="Delete">';
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


            document.getElementById("<%=HiddenField7.ClientID%>").value = rowCount;
            
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
            FilltxtPartner(rowCount);
            $au('#txtPartner' + rowCount).selectToAutocomplete1Letter();




        }

        function FilltxtPartner(rowCount) {

            var ddlTestDropDownListXML = $noCon("#txtPartner" + rowCount);

            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTablePartner";
            if (document.getElementById("<%=HiddenPartner.ClientID%>").value != 0) {
                ddlEmpdata = document.getElementById("<%=HiddenPartner.ClientID%>").value;
                var OptionStart = $noCon("<option>--SELECT PARTNER--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);
                // Now find the Table from response and loop through each item (row).
                $noCon(ddlEmpdata).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noCon(this).find('PRTNR_ID').text();
                    var OptionText = $noCon(this).find('PRTNR_NAME').text();

                    document.getElementById("<%=HiddenPartner.ClientID%>").value
                    // Create an Option for DropDownList.
                    var option = $noCon("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    ddlTestDropDownListXML.append(option);
                });
            }
        }
        //EVM-24
        // Read Document Number
        function ReadDocument(rowCount) {
            var partnerId = document.getElementById("txtPartner" + rowCount).value;
            var pId = PageMethods.partnerDocId(partnerId, function (response) {
                document.getElementById("txtDocumentNo" + rowCount).value = response;
            });



        }
        function ViewAttachment() {
            IncrmntConfrmCounter();
            orgInfo();
            $("#TableFileCRN").empty();
            $("#TableFileTIN").empty();
            $("#TableFileCCN").empty();
            if (document.getElementById("<%=cbxSameOrg.ClientID%>").checked == true) {



                var orgid = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
                var OrgAttchmnt = PageMethods.Org_Attachment(orgid, function (response) {
                    document.getElementById("<%=hiddenFilePath.ClientID%>").value = response[3];
                    if (response[0] != "") {


                        var EditAttchmnt = response[0];

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


                                    EditAttachmentPer(jsonAtt[key].ORGFLS_ID, jsonAtt[key].ORGFLS_FILENAME, jsonAtt[key].ORGFLS_FLNM_ACT, jsonAtt[key].ORGFLS_DSCRPTN);

                                }
                            }
                        }

                    }


                    if (response[1] != "") {

                        var EditAttchmnt = response[1];
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

                                    EditAttachmentIns(jsonAtt[key].ORGFLS_ID, jsonAtt[key].ORGFLS_FILENAME, jsonAtt[key].ORGFLS_FLNM_ACT, jsonAtt[key].ORGFLS_DSCRPTN);

                                }
                            }
                        }

                    }

                    if (response[2] != "") {

                        var EditAttchmnt = response[2];
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



                                    EditAttachmentVhcl(jsonAtt[key].ORGFLS_ID, jsonAtt[key].ORGFLS_FILENAME, jsonAtt[key].ORGFLS_FLNM_ACT, jsonAtt[key].ORGFLS_DSCRPTN);




                                }
                            }
                        }

                    }



                    AddFileUploadIns();
                    AddFileUploadPer();
                    AddFileUploadVhcl();

                });
            }
            else {
                AddFileUploadIns();
                AddFileUploadPer();
                AddFileUploadVhcl();
            }
               
}


       //table edit  partnership

        function EditListRows(EditPrtnerName, EditDocNo, EditSharePer, EditDtlId, PartnerId, Status) {

            var RowCountTotal = document.getElementById("<%=HiddenPartnerRowCount.ClientID%>").value;

            if (EditPrtnerName != "" && EditDocNo != "" && EditSharePer != "" && EditDtlId != "" && PartnerId != "") {

                rowCount++;
                RowIndex++;
                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 2.8%;text-align: center;display: none;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';
              
                recRow += ' <td id="tdPartner' + rowCount + '"  class="tr_l"><div id="divtxtPartner' + rowCount + '">';
                recRow += ' <select  id="txtPartner' + rowCount + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" type="text"   onblur="return BlurPartner(' + rowCount + ')" onkeypress="return DisableEnter(event)" onchange="return ReadDocument(' + rowCount + ')"  maxlength=100 />';
                recRow += ' <div></td> ';
                recRow += ' <td  style="display: none;"><input id="txtPartnerId' + rowCount + '"  value="' + EditPrtnerName + '" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><select id="txtPartnerName' + rowCount + '" value="' + EditPrtnerName + '" type="text" maxlength=100  /></td>';

                recRow += ' <td id="tdDocumentNo' + rowCount + '"  class="tr_l">';
                recRow += ' <input  id="txtDocumentNo' + rowCount + '" value="' + EditDocNo + '" class="form-control fg2_inp2" placeholder="Document#"  type="text" onblur="return BlurDocumentNo(' + rowCount + ')" onkeypress="return DisableEnter(event)" maxlength=100 />';
                recRow += '   </td> ';

                recRow += ' <td id="tdSharePer' + rowCount + '"  class="tr_c">';
                recRow += ' <input  id="txtSharePerc' + rowCount + '" value="' + EditSharePer + '" class="form-control fg2_inp2 tr_c" placeholder="Share %"  type="text" onblur="return BlurSharePerc(' + rowCount + ')" onkeypress="return DisableEnter(event)" onkeydown="return isNumber(event);" maxlength=5 />';
                recRow += '   </td> ';


                recRow += '<td>';
                recRow += '<div class="btn_stl1">';
                recRow += '<button  class="btn act_btn bn2"  id="tdIndvlAddMoreRowPic' + rowCount + '" onclick="return CheckaddMoreRows(\'' + rowCount + '\',true);" title="Add">';
                recRow += '<i class="fa fa-plus-circle"></i>';
                recRow += '</button>';
                recRow += '<button class="btn act_btn bn3" onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to Delete this Entry?\');" title="Delete">';
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


                //jQuery('#TableaddedRows').append(recRow);
                //document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                //document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";


                jQuery('#TableaddedRows').append(recRow);


                FilltxtPartner(rowCount);

                if (PartnerId != "") {

                    elmnt23 = document.getElementById("txtPartner" + rowCount);

                    for (var i = 0; i < elmnt23.options.length; i++) {

                        if (elmnt23.options[i].value == PartnerId) {

                            elmnt23.selectedIndex = i;
                        }
                        else if (Status == "0") {

                            var newOption = "<option value='" + PartnerId + "'>" + EditPrtnerName + "</option>";

                            document.getElementById("txtPartner" + rowCount).innerHTML = newOption;


                            FilltxtPartner(rowCount);
                        }
                    }
                }

                if (RowCountTotal != RowIndex) {
                    document.getElementById("tdIndvlAddMoreRowPic" + rowCount).disabled = true;
                    document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                }
                LocalStorageAdd(rowCount);


                $au('#txtPartner' + rowCount).selectToAutocomplete1Letter();
            }


        }



         //table view partnership

         function ViewListRows(EditPrtnerName, EditDocNo, EditSharePer, EditDtlId, PartnerId) {


             if (EditPrtnerName != "" && EditDocNo != "" && EditSharePer != "" && EditDtlId != "" && PartnerId!="") {


                 rowCount++;
                 RowIndex++;
                 var recRow = '<tr id="rowId_' + rowCount + '" >';
                 recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                 recRow += '<td style="width: 2.8%;text-align: center;display: none;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';

               
                 recRow += ' <td id="tdPartner' + rowCount + '"  class="tr_l"><div id="divtxtPartner' + rowCount + '">';
                 recRow += ' <select disabled id="txtPartner' + rowCount + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" type="text"   onblur="return BlurPartner(' + rowCount + ')" onkeypress="return DisableEnter(event)" onchange="return ReadDocument(' + rowCount + ')"  maxlength=100 />';
                 recRow += '<div></td> ';
                 recRow += ' <td  style="display: none;"><input id="txtPartnerId' + rowCount + '"  value="' + EditPrtnerName + '" type="text"   /></td>';
                 recRow += ' <td  style="display: none;"><select id="txtPartnerName' + rowCount + '" value="' + EditPrtnerName + '" type="text" maxlength=100  /></td>';

                 recRow += ' <td id="tdDocumentNo' + rowCount + '"  class="tr_l">';
                 recRow += ' <input  disabled id="txtDocumentNo' + rowCount + '" value="' + EditDocNo + '" class="form-control fg2_inp2" placeholder="Document#"  type="text" onblur="return BlurDocumentNo(' + rowCount + ')" onkeypress="return DisableEnter(event)" maxlength=100 />';
                 recRow += '   </td> ';

                 recRow += ' <td id="tdSharePer' + rowCount + '"  class="tr_c">';
                 recRow += ' <input disabled  id="txtSharePerc' + rowCount + '" value="' + EditSharePer + '" class="form-control fg2_inp2 tr_c" placeholder="Share %"  type="text" onblur="return BlurSharePerc(' + rowCount + ')" onkeypress="return DisableEnter(event)" onkeydown="return isNumber(event);" maxlength=5 />';
                 recRow += '   </td> ';


                 recRow += '<td>';
                 recRow += '<div class="btn_stl1">';
                 recRow += '<button  disabled class="btn act_btn bn2"  id="tdIndvlAddMoreRowPic' + rowCount + '" onclick="return CheckaddMoreRows(\'' + rowCount + '\',true);" title="Add">';
                 recRow += '<i class="fa fa-plus-circle"></i>';
                 recRow += '</button>';
                 recRow += '<button disabled class="btn act_btn bn3" onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to Delete this Entry?\');" title="Delete">';
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
                // document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";
                 LocalStorageAdd(rowCount);
                 $au('#txtPartner' + rowCount).selectToAutocomplete1Letter();

             }
             else {


             }

         }

         //checking add more rows
         function CheckaddMoreRows(x, retBool) {
        
             var check = document.getElementById("tdInx" + x).innerHTML;
             var CmpnyShare= document.getElementById("<%=txtSharePer.ClientID%>").value
             //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
             //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
             if (check == " " && CmpnyShare!=0) {
                
                 if (retBool == true) {
                     
                     if (CheckAllRowFieldAndHighlight(x, false) == true) {
                        
                         document.getElementById("tdInx" + x).innerHTML = x;
                         document.getElementById("tdIndvlAddMoreRowPic" + x).disabled = true;
                         addMoreRows(this.form, retBool, false, 0);
                         return false;
                     }
                 }
                 
                 else if (retBool == false) {
                     
                     var row_index = jQuery('#rowId_' + x).index();
                     if (CheckAllRowField(x, row_index) == true) {
                         document.getElementById("tdInx" + x).innerHTML = x;
                         document.getElementById("tdIndvlAddMoreRowPic" + x).disabled = true;
                         addMoreRows(this.form, retBool, false, 0);
                         return false;
                     }
                 }
             }
             return false;
         }



         // checks every field in row
         function CheckAllRowField(x, row_index) {
             ret = true;

             // alert('check all row');

             var partner = document.getElementById("txtPartner" + x).value;
             if (partner == 0) {
                 ret = false;
             }
            
             var documentNo = document.getElementById("txtDocumentNo" + x).value;
             if (documentNo == "") {
                 ret = false;
             }
            
             var sharePer = document.getElementById("txtSharePerc" + x).value;
             if (sharePer == "") {
                 ret = false;
             }

             return ret;
         }
        



         // checks every field in row
         function CheckAllRowFieldAndHighlight(x, blFromBlurValue) {
             ret = true;

             document.getElementById("txtPartner" + x).style.borderColor = "";
             $("div#divtxtPartner"+x+" input.ui-autocomplete-input").css("borderColor", "");

             document.getElementById("txtDocumentNo" + x).style.borderColor = "";
             document.getElementById("txtSharePerc" + x).style.borderColor = "";
           
             var partner = document.getElementById("txtPartner" + x).value;
             if (partner == 0 || partner == "--SELECT PARTNER--") {
                

                 document.getElementById("txtPartner" + x).style.borderColor = "Red";
                 document.getElementById("txtPartner" + x).focus();
                 $noCon("#txtPartner" + x).select();

                 $("div#divtxtPartner" + x + " input.ui-autocomplete-input").css("borderColor", "red");
                 $("div#divtxtPartner" + x + " input.ui-autocomplete-input").select();
                 $("div#divtxtPartner" + x + " input.ui-autocomplete-input").focus();

                 ret = false;
             }
             var sharePer = document.getElementById("txtSharePerc" + x).value;
             if (sharePer == "") {
                 document.getElementById("txtSharePerc" + x).style.borderColor = "Red";
                 document.getElementById("txtSharePerc" + x).focus();
                 $noCon("#txtSharePerc" + x).select();
                 ret = false;
             }
             var documentNo = document.getElementById("txtDocumentNo" + x).value;
             if (documentNo == "") {
                 document.getElementById("txtDocumentNo" + x).style.borderColor = "Red";
                 document.getElementById("txtDocumentNo" + x).focus();
                 $noCon("#txtDocumentNo" + x).select();
                 ret = false;
             }


            

           

           
             return ret;

         }


        //for removing row
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
                         var idlast = $noC('#TableaddedRows tr:last').attr('id');
                         //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                         //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                         if (idlast != "") {
                             var res = idlast.split("_");
                             //  alert(res[1]);
                             document.getElementById("tdInx" + res[1]).innerHTML = " ";
                             document.getElementById("tdIndvlAddMoreRowPic" + res[1]).disabled = false;
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


                                     document.getElementById("txtDate" + res[1]).focus();
                                     $noCon("#txtDate" + res[1]).select();
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

                                     $("div#divtxtPartner"+res[1]+" input.ui-autocomplete-input").select();
                                     $("div#divtxtPartner" + res[1] + " input.ui-autocomplete-input").focus();

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
                             //   alert('i :' + intcount);
                             document.getElementById("divSlNum" + x).innerHTML = intRecount
                             var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
                             if (SavedorNot == "saved") {
                                 //  var row_index = jQuery('#rowId_' + x).index();

                                 // LocalStorageEdit(x, row_index);

                             }
                         }
                     }

                     //iterate through columns
                     //columns would be accessed using the "col" variable assigned in the for loop
                     // alert(col.innerHTML);
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
             


             if (evt == 'INS') {
                 // alert('inside local add');
                 var $add = jQuery.noConflict();
                 var client = JSON.stringify({
                     ROWID: "" + x + "",
                     PARTNER: $add("#txtPartner" + x).val(),
                     DOCNUM: $add("#txtDocumentNo" + x).val(),
                     SHAREPER: $add("#txtSharePerc" + x).val(),
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
                     SHAREPER: $add("#txtSharePerc" + x).val(),
                     EVTACTION: "" + evt + "",
                     DTLID: "" + detailId + ""


                 });
             }




             tbClientTrficVltn.push(client);
             localStorage.setItem("tbClientTrficVltn", JSON.stringify(tbClientTrficVltn));

             $add("#cphMain_HiddenFieldAddTable").val(JSON.stringify(tbClientTrficVltn));


             //for calculation of total Amount
             CalculateTotalAmountFromHiddenField();



             // alert("The data was saved.");
             // var h = document.getElementById("<%=HiddenFieldAddTable.ClientID%>").value;
              //  alert(h);

              document.getElementById("tdSave" + x).innerHTML = "saved";
              //   alert('saved');
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
              $noCon("#cphMain_HiddenFieldAddTable").val(JSON.stringify(tbClientTrficVltn));
              //   alert("Client deleted.");

              //   var h = document.getElementById("<%=HiddenField1.ClientID%>").value;
    //   alert(h);


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


              var CanclRowNum = document.getElementById("<%=HiddenField6.ClientID%>").value;

              if (CanclRowNum == '') {
                  document.getElementById("<%=HiddenField6.ClientID%>").value = x;

            }
            else {

                document.getElementById("<%=HiddenField6.ClientID%>").value = document.getElementById("<%=HiddenField6.ClientID%>").value + ',' + x;
            }

            //for calculation of total Amount
            CalculateTotalAmountFromHiddenField();
            IncrmntConfrmCounter();
    // alert('gj');

        }

        function LocalStorageEdit(x, row_index) {
            
         
            //  alert('edit start row_index ' + row_index);
            var tbClientTrficVltn = localStorage.getItem("tbClientTrficVltn");//Retrieve the stored data

            tbClientTrficVltn = JSON.parse(tbClientTrficVltn); //Converts string to object

            if (tbClientTrficVltn == null) //If there is no data, initialize an empty array
                tbClientTrficVltn = [];
            var detailId = document.getElementById("tdDtlId" + x).innerHTML;
            // var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
            var evt = document.getElementById("tdEvt" + x).innerHTML;
            //alert('event'+evt);
            // alert('edit pmode ' + PrdctMode);
            //  alert('additional:' + additional)
            //alert('detailID'+detailId);
           


            if (evt == 'INS') {

                var $E = jQuery.noConflict();
                tbClientTrficVltn[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    PARTNER: $E("#txtPartner" + x).val(),
                    DOCNUM: $E("#txtDocumentNo" + x).val(),
                    SHAREPER: $E("#txtSharePerc" + x).val(),
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
                    SHAREPER: $E("#txtSharePerc" + x).val(),
                    EVTACTION: "" + evt + "",
                    DTLID: "" + detailId + ""

                });//Alter the selected item on the table

            }
            // alert('local edit');




            localStorage.setItem("tbClientTrficVltn", JSON.stringify(tbClientTrficVltn));
            $E("#cphMain_HiddenFieldAddTable").val(JSON.stringify(tbClientTrficVltn));


            //for calculation of total Amount
            CalculateTotalAmountFromHiddenField();

            return true;
        }

      //onblur functions for partner,document number and share percentage

        function BlurPartner(x) {



            document.getElementById('divBlink').style.visibility = "hidden";
            var RcptNumberWithoutReplace = document.getElementById("txtPartner" + x).value;
            var replaceText1 = RcptNumberWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/'/g, "");
            var replaceText4 = replaceText3.replace(/"/g, "");
            var replaceText5 = replaceText4.replace(/\\/g, "");



            //var tableOtherItem = document.getElementById("TableaddedRows");
            //for (var i = 0; i < tableOtherItem.rows.length; i++) {

            //    var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);

            //    var IBanOld = document.getElementById("#3####" + validRowID).value;
            //    if (validRowID != x && IBanOld == replaceText5.trim()) {
            //        replaceText5 = "";
            //    }

            //}

            //var y = x;
            //while (y > 1) {
            //    y = y - 1;
            //    if (document.getElementById("txtPartner" + y).value == replaceText5) {

            //    }

            //}

            var tableOtherItem = document.getElementById("TableaddedRows");
            for (var i = 0; i < tableOtherItem.rows.length; i++) {

                var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);

                var PartnerOld = document.getElementById("txtPartner" + validRowID).value;

                if (validRowID != x && PartnerOld == replaceText5.trim()) {
                    replaceText5 = "";
                    document.getElementById("txtDocumentNo" + x).value = "";
                    document.getElementById("txtSharePerc" + x).value = "";

                    $("#divWarning").html("Partners can't be duplicated.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    

                }
            }

            document.getElementById("txtPartner" + x).value = replaceText5.trim();


            var row_index = jQuery('#rowId_' + x).index();
            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (SavedorNot == "saved") {
                var RcptNumber = document.getElementById("txtPartner" + x).value.trim();
                if (RcptNumber != 0) {
                    document.getElementById("txtPartner" + x).style.borderColor = "";
                    $("div#divtxtPartner" + x + " input.ui-autocomplete-input").css("borderColor", "");
                    LocalStorageEdit(x, row_index);
                }
            }
            else {
                if (SavedorNot == " ") {
                    LocalStorageAdd(x);
                }

            }
        }



   
         function KeyPartner(x) {


            
             var $au = jQuery.noConflict();

             (function ($au) {
                 $au(function () {
                    
                     selectorToAutocompleteTextBox('txtPartner' + rowCount, rowCount);
                     $au('form').submit(function () {

                        
                     });
                 });
             })(jQuery);
            
            


         }

         function BlurDocumentNo(x) {
             

            
             document.getElementById('divBlink').style.visibility = "hidden";
             var RcptNumberWithoutReplace = document.getElementById("txtDocumentNo" + x).value;
             var replaceText1 = RcptNumberWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             var replaceText3 = replaceText2.replace(/'/g, "");
             var replaceText4 = replaceText3.replace(/"/g, "");
             var replaceText5 = replaceText4.replace(/\\/g, "");

             //var tableOtherItem = document.getElementById("TableaddedRows");
             //for (var i = 0; i < tableOtherItem.rows.length; i++) {

             //    var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);

             //    var IBanOld = document.getElementById("txtDocumentNo" + validRowID).value;
             //    if (validRowID != x && IBanOld == replaceText5.trim()) {
             //        replaceText5 = "";
             //    }

             //}
             var y = x;
             while (y > 1) {
                 y = y - 1;
                 if (document.getElementById("txtDocumentNo" + y).value == replaceText5) {
                     replaceText5 = "";
                 }

             }
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

         // For adjust to decimal point also used for checking
         function ValueCheck( x, rtn) {

             
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

       
         function BlurSharePerc(x) {
            
             
             document.getElementById('divBlink').style.visibility = "hidden";
             var RcptNumberWithoutReplace = document.getElementById("txtSharePerc" + x).value;
             var replaceText1 = RcptNumberWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             var replaceText3 = replaceText2.replace(/'/g, "");
             var replaceText4 = replaceText3.replace(/"/g, "");
             var replaceText5 = replaceText4.replace(/\\/g, "");

             if (isNaN(replaceText5) == true) {
                 replaceText5 = "";             
             }
             if (replaceText5 < 0 || replaceText5>100) {
                 replaceText5 = "";
             }
            

             var CmpnySharePer = document.getElementById("<%=txtSharePer.ClientID%>").value;
             if (x != 1) {
                 if (CmpnySharePer - replaceText5 < 0) {
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

            //alert(hiddenVal);

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
                            Total = Total + parseFloat(v);

                        }
                    });
                }

            }

            if (!isNaN(Total)) {

                document.getElementById("<%=txtSharePer.ClientID%>").value = (100 - Total).toFixed(2);
            }
        }


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


         function FocusPartner(x, event) {


           

             document.getElementById("<%=HiddenPartnerId.ClientID%>").value = "";
             document.getElementById("<%=HiddenPartnerName.ClientID%>").value = "";
             var TVEmpId = document.getElementById("txtPartnerId" + x).value;
              document.getElementById("<%=HiddenPartnerId.ClientID%>").value = TVEmpId;
             var TVEmpName = document.getElementById("txtPartnerName" + x).value;
            document.getElementById("<%=HiddenPartnerName.ClientID%>").value = TVEmpName;

             if (document.getElementById("txtPartner" + x).value == 0) {

                 document.getElementById("txtPartner" + x).value = "";
            }

            
        }



        
       

         //for icon
        function ClearDivDisplayImagei() {
            IncrmntConfrmCounter();

            var FileUploadPath = document.getElementById("<%=FileUploadProPic.ClientID%>").value.replace("C:\\fakepath\\", "");

            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();



            if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                        || Extension == "jpeg" || Extension == "jpg") {




            }
            else {
                document.getElementById("<%=FileUploadProPic.ClientID%>").value = "";
                document.getElementById("<%=Label1.ClientID%>").textContent = "No File Selected";             
                $("#divWarning").html("The specified file type could not be uploaded.Only support image file");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
            }







            var hidnImageSize = document.getElementById("<%=hiddenUserImageSize.ClientID%>").value;

            var fuData = document.getElementById("<%=FileUploadProPic.ClientID%>");
            var size = fuData.files[0].size;
            var convertToKb = hidnImageSize / 1000;
            if (size > hidnImageSize) {
                document.getElementById("<%=FileUploadProPic.ClientID%>").value = "";
                document.getElementById("<%=Label1.ClientID%>").textContent = "No File Selected";
                $("#divWarning").html(" Sorry Maximum file size exceeds. Please Upload Image of size less than " + convertToKb + "KB !.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });              
                //return false;
            }
            else {

                if (document.getElementById("<%=FileUploadProPic.ClientID%>").value != "") {
                    document.getElementById("<%=Label1.ClientID%>").textContent = document.getElementById("<%=FileUploadProPic.ClientID%>").value.replace("C:\\fakepath\\", "");
                    document.getElementById("<%=divImageDisplay.ClientID%>").innerHTML = "";
                    //document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";
                }

                //    return true;

            }
        }



                function ClearImagei() {
                    if (document.getElementById("<%=hiddenUserImage.ClientID%>").value != "" || document.getElementById("<%=FileUploadProPic.ClientID%>").value != "") {

                        ezBSAlert({
                            type: "confirm",
                            messageText: "Do You Want To Remove Selected Photo?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                IncrmntConfrmCounter();
                                document.getElementById("<%=FileUploadProPic.ClientID%>").value = "";
                              document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";
                                document.getElementById("<%=divImageDisplay.ClientID%>").innerHTML = "";
                                document.getElementById("<%=Label1.ClientID%>").textContent = "No File Selected";
                            }
                            else {
                                return false;
                            }
                        });
                        return false;

               

              }
          }
          function ImagePosition(object, obj2) {
              var $Mo = jQuery.noConflict();

              var offset = $Mo("#" + object).offset();

              var posY = 0;
              var posX = 0;
              posY = offset.top;

              posX = offset.left

              if (object == 'ClearImage') {
                  posX = 7.1;
              }

              var d = document.getElementById(obj2);
              d.style.position = "absolute";
              d.style.left = posX + '%';
              if (object == 'ClearImage') {
                  d.style.top = posY - 52 + 'px';
              }

          }
          function dateString2Date(dateString) {
              var dt = dateString.split(/\-|\s/);
              var TimeCheck = dt[3].split(':');
              if (TimeCheck[0] == 12) {
                  TimeCheck[0] = TimeCheck[0] - 12;
              }
              else if (TimeCheck[0] == 24) {
                  TimeCheck[0] = TimeCheck[0] - 12;
              }
              var Time = TimeCheck[0] + ":" + TimeCheck[1] + ":" + TimeCheck[2];
              //  alert('dt' + Time);
              return new Date(dt.slice(0, 3).reverse().join('-') + ' ' + Time);
          }
  
        
    </script>

    <script>
        function CheckDupCorpName() {

            ret = true;
            var strOrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
            var strName = "";
            strName = document.getElementById("<%=txtCorpName.ClientID%>").value;

            $co = jQuery.noConflict();
            $co.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_Corp_Office.aspx/CheckDupName",
                data: '{strName:"' + strName + '",strOrgId:"' + strOrgId + '"}',
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

        function CheckDupCode() {

            ret = true;
            var strOrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
            var strCode = "";
            strCode = document.getElementById("<%=txtCode.ClientID%>").value;

            $co = jQuery.noConflict();
            $co.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_Corp_Office.aspx/CheckDupCode",
                data: '{strCode:"' + strCode + '",strOrgId:"' + strOrgId + '"}',
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" ></asp:ScriptManager>
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
        <asp:HiddenField ID="hiddenConfirmValue" runat="server" />


     <asp:HiddenField ID="HiddenFieldCorpID" runat="server" />
    <asp:HiddenField ID="HiddenPartner" runat="server" />
    <asp:HiddenField ID="HiddenPartnerId" runat="server" />
    <asp:HiddenField ID="HiddenPartnerName" runat="server" />

     <asp:HiddenField ID="hiddenFilePath" runat="server" />
    <asp:HiddenField ID="hiddenFileCanclDtlId" runat="server" />
   
     <asp:HiddenField ID="hiddenEditAttchmnt" runat="server" />
      <asp:HiddenField ID="HiddenAtchmnt" runat="server" />

     <asp:HiddenField ID="hiddenOrgId" runat="server" />
     <asp:HiddenField ID="HiddenField1" runat="server" />
     <asp:HiddenField ID="HiddenField2" runat="server" />
     <asp:HiddenField ID="HiddenField2_FileUpload" runat="server" />
     <asp:HiddenField ID="HiddenField3_FileUpload" runat="server" />
     <asp:HiddenField ID="HiddenField4_FileUpload" runat="server" />
     <asp:HiddenField ID="HiddenAtchmntMode" runat="server" />
    
     <asp:HiddenField ID="hiddenAttchmntPrmtSlNumber" runat="server" />
     <asp:HiddenField ID="hiddenEditPrmtAttchmnt" runat="server" />
    <asp:HiddenField ID="hiddenAttchmntInsurSlNumber" runat="server" />
     <asp:HiddenField ID="hiddenEditInsurAttchmnt" runat="server" />
     <asp:HiddenField ID="hiddenAttchmntVhclSlNumber" runat="server" />
     <asp:HiddenField ID="hiddenEditVhclAttchmnt" runat="server" />
     <asp:HiddenField ID="hiddenEdit" runat="server" />
     <asp:HiddenField ID="hiddenView" runat="server" />
    <asp:HiddenField ID="hiddenPerFileCanclDtlId" runat="server" />
    <asp:HiddenField ID="hiddenInsFileCanclDtlId" runat="server" />
    <asp:HiddenField ID="hiddenVhclFileCanclDtlId" runat="server" />

      <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />  
     <asp:HiddenField ID="HiddenFieldAddTable" runat="server" />
     <asp:HiddenField ID="HiddenField3" runat="server" />
     <asp:HiddenField ID="HiddenField4" runat="server" />
     <asp:HiddenField ID="HiddenField5" runat="server" />
     <asp:HiddenField ID="HiddenStateValue" runat="server"/>
    <asp:HiddenField ID="HiddenCityValue" runat="server"/>
    <asp:HiddenField ID="hiddenUserImageSize" runat="server" />
    <asp:HiddenField ID="hiddenUserImage" runat="server" />
    <asp:HiddenField ID="hiddenImageName" runat="server" />
       <asp:HiddenField ID="HiddenPartnerRowCount" runat="server" />
      <asp:HiddenField ID="HiddenFieldEditBankCountRow" runat="server" Value="0" />
      <asp:HiddenField ID="HiddenFieldEditBankData" runat="server" />

      <asp:HiddenField ID="hiddenEmpDdlData" runat="server" />

      <asp:HiddenField ID="hiddenTotalData" runat="server" />

     <asp:HiddenField ID="HiddenField6" runat="server" />  
     <asp:HiddenField ID="HiddenField7" runat="server" /> 
    <asp:HiddenField ID="HiddenAddProvision" runat="server" />
        <asp:HiddenField ID="hiddenOldName" runat="server" />
            <asp:HiddenField ID="hiddenOldCode" runat="server" />
        <asp:HiddenField ID="HiddenCorpChk" runat="server" />
     <asp:HiddenField ID="HiddenFieldState" runat="server" />
     <asp:HiddenField ID="HiddenFieldCity" runat="server" />
    
  <ol class="breadcrumb">
    <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
     <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
     <li><a href="gen_Corp_OfficeList.aspx">Business Unit</a></li>      
     <li class="active" id="lblEntryP" runat="server">Add</li>
  </ol>
     <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
  <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">  
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">Add Business Unit</h2>
 <!---------------------------==============frame===============--------> 
        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Name:<span class="spn1">*</span></label>
          <input id="txtCorpName" runat="server" maxlength="100"  style="text-transform: uppercase" type="text" class="form-control fg2_inp1 inp_mst"  placeholder="Name" name="">
        </div>

        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Short Name:<span class="spn1"></span></label>
          <input id="txtShortName"  runat="server" maxlength="20" type="text" class="form-control fg2_inp1" placeholder="Short Name">
        </div>
        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Code:<span class="spn1">*</span></label>
          <input id="txtCode"  runat="server" maxlength="100"  style="text-transform: uppercase" type="text" class="form-control fg2_inp1 inp_mst"  placeholder="Code" name="">
        </div>
        <div class="form-group fg2 mar_at flt_l  sa_640_i sa_480">
          <label for="email" class="fg8_la1 pad_l">Logo:<span class="spn1">&nbsp;</span></label><br>
           <asp:FileUpload ID="FileUploadProPic" type="file" runat="server"  onchange="ClearDivDisplayImagei()" Accept="image/png, image/gif, image/jpeg" multiple  />
          <label for="cphMain_FileUploadProPic" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>
             <div id="Label1" class="file_n" runat="server">No File selected</div>
           <div id="divImageEdit" runat="server" style=" width: 100%;margin-left: 43.3%;float: right; height: 20px; margin-top: -1%;">
                    

                    <div class="imgWrap" id="divImgWrap" runat="server">
                        <img id="ClearImage" src="../../Images/Icons/clear-image-green.png" class="tooltip" style="position: relative;float: right;opacity: 1;z-index: 100;" title="Remove Selected Photo" alt="Clear" onclick="ClearImagei()"  style="cursor: pointer; float: right;" />
                        <%--<p id="RemovePhoto" class="imgDescription" style="color: white">Remove Selected Photo</p>--%>
                    </div>
                    <div id="divImageDisplay" runat="server">
                    </div>
                </div>

           
        </div> 

        <div class="clearfix"></div>
        
        
        <div class="form-group fg8 fg2_mr sa_fg3 sa_640_i1">
          <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
          <div class="check1">
            <label class="switch">
              <input type="checkbox" id="cbxStatus"  runat="server" checked="checked">
              <span class="slider_tog round"></span>
            </label>
          </div>
        </div>
        <div class="form-group fg7 fg2_mr sa_fg3 sa_640_i1">
          <label for="email" class="fg2_la1 pad_l">Same Organization Address:<span class="spn1"></span></label>
          <div class="check1">
            <label class="switch">
              <input type="checkbox" id="CheckBox2"  runat="server"  onclick="orgAdd();">
              <span class="slider_tog round"></span>
            </label>
          </div>
        </div>

        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Address 1:<span class="spn1">*</span></label>
          <input id="txtCorpAdd1"  runat="server" maxlength="150" type="text" class="form-control fg2_inp1 inp_mst" placeholder="Address 1" name="">
        </div>
        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Address 2:<span class="spn1"></span></label>
          <input id="txtCorpAdd2"  runat="server" maxlength="150" type="text" class="form-control fg2_inp1"  placeholder="Address 2" name="">
        </div>
        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Address 3:<span class="spn1"></span></label>
          <input id="txtCorpAdd3"  runat="server" maxlength="150" type="text" class="form-control fg2_inp1"  placeholder="Address 3" name="">
        </div>
        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Country:<span class="spn1">*</span></label>
            <asp:DropDownList ID="ddlCorpCountry" class="form-control fg2_inp1 inp_mst fg_chs1"  runat="server"  AutoPostBack="true"  onChange="return changeCountry();"></asp:DropDownList>       
        </div>
        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">State:<span class="spn1"></span></label>
             <asp:TextBox ID="ddlCorpState"  onchange="changeState();" class="form-control fg2_inp1 inp_mst"  placeholder="--Select State--"   runat="server"  onkeypress="return selectorToAutocompleteState(event);" onkeydown="return selectorToAutocompleteState(event);"></asp:TextBox>        
        </div>
        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">City:<span class="spn1"></span></label>
             <asp:TextBox ID="ddlCity"  onchange="changeCity();" class="form-control fg2_inp1 inp_mst"  placeholder="--Select City--"   runat="server"  onkeypress="return selectorToAutocompleteCity(event);" onkeydown="return selectorToAutocompleteCity(event);"></asp:TextBox>
        </div>
        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Postal Code:<span class="spn1"></span></label>
          <input id="txtCorpZip" runat="server" maxlength="10"  style="text-transform: uppercase" type="text" class="form-control fg2_inp1"  placeholder="Postal Code" name="">
        </div>

        <div class="clearfix"></div>
        <div class="fr_sp1"></div>
        <div class="devider devider_10"></div>

        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Phone#:<span class="spn1">*</span></label>
          <input id="txtCorpMobile"  runat="server" maxlength="50"  style="text-transform: uppercase" type="text" class="form-control fg2_inp1 inp_mst"  placeholder="Phone#" name="">
        <p class="error" id="ErrortxtCorpMobile" style="display:none; font-family:Calibri;">Please enter valid phone number</p>
             </div>  
        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Fax:<span class="spn1"></span></label>
          <input id="txtFax"   runat="server" maxlength="100" type="text" class="form-control fg2_inp1"  placeholder="Fax" name="">
        </div>
        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Website:<span class="spn1"></span></label>
          <input id="txtCorpWebsite"  runat="server" maxlength="100" type="text" class="form-control fg2_inp1"  placeholder="Website" name="">
              <p class="error" id="ErrortxtCorpWebsite" style="display:none; font-family:Calibri;">Please enter valid website address</p>
        </div>
        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Email:<span class="spn1">*</span></label>
          <input id="txtCorpEmail" runat="server" maxlength="100" type="text" class="form-control fg2_inp1 inp_mst"  placeholder="Email" name="">
            <p class="error" id="ErrorMsgCorpEmail" style="display:none; font-family:Calibri;">Please enter valid email address</p>
        </div>
        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1"> Enquiry Mail:<span class="spn1"></span></label>
          <input id="txtEnqMail"  runat="server" maxlength="100" type="text" class="form-control fg2_inp1"  placeholder="Enquiry Mail" name="">
             <p class="error" id="ErrorMsgCorpEnqEmail" style="display:none; font-family:Calibri;">Please enter valid email address</p>
        </div> 
        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Customer Care#:<span class="spn1"></span></label>
          <input id="txtCustCareNumber"  runat="server" maxlength="14" type="text" class="form-control fg2_inp1" placeholder="Customer Care#">
        </div>

        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Short Address:<span class="spn1"></span></label>
          <input id="txtShortAddress"  runat="server" maxlength="40" type="text" class="form-control fg2_inp1" placeholder="Short Address">
        </div>
        <div class="clearfix"></div>
        <div class="fr_sp1"></div>
        <div class="devider devider_10"></div>

        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480" id="divddlFiscalMonth">
          <label for="email" class="fg2_la1">Fiscal Start Month:<span class="spn1">*</span></label>
             <asp:DropDownList ID="ddlFiscalMonth" class="form-control fg2_inp1 inp_mst fg_chs1" runat="server" AutoPostBack="false">
                            <asp:ListItem>--Select Month--</asp:ListItem>
                            <asp:ListItem Value="1">January</asp:ListItem>
                            <asp:ListItem Value="2">February</asp:ListItem>
                            <asp:ListItem Value="3">March</asp:ListItem>
                            <asp:ListItem Value="4">April</asp:ListItem>
                            <asp:ListItem Value="5">May</asp:ListItem>
                            <asp:ListItem Value="6">June</asp:ListItem>
                            <asp:ListItem Value="7">July</asp:ListItem>
                            <asp:ListItem Value="8">August</asp:ListItem>
                            <asp:ListItem Value="9">September</asp:ListItem>
                            <asp:ListItem Value="10">October</asp:ListItem>
                            <asp:ListItem Value="11">November</asp:ListItem>
                            <asp:ListItem Value="12">December</asp:ListItem>
                        </asp:DropDownList>        
        </div>

        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Business Type:<span class="spn1">*</span></label>
          <select class="form-control fg2_inp1 inp_mst fg_chs1" id="ddlBsnsTyp" runat="server"  onclick="ChangeBsnsType();">
            <option>Sole Ownership</option>
            <option>Partnership</option>
          </select>
        </div>

        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Share Type:<span class="spn1">*</span></label>
          <select class="form-control fg2_inp1 inp_mst fg_chs1" id="ddlShareTyp" disabled="disabled" runat="server">           
          </select>
        </div>

        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">TIN#:<span class="spn1"></span></label>
          <input id="txtTinNumber"  runat="server" maxlength="50" type="text" class="form-control fg2_inp1"  placeholder="TIN#" name="">
             <p class="error" id="ErrorMsgTINNumber" style="display:none;">TIN contain 11 digits</p>
        </div>
        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">CIN#:<span class="spn1"></span></label>
          <input id="txtCinNumber"  runat="server" maxlength="50" type="text" class="form-control fg2_inp1" placeholder="CIN#" name="">
        </div>
        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="pwd" class="fg2_la1">Software Start Date:<span class="spn1">*</span> </label>
          <div id="datetimepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
            <input class="form-control inp_bdr" type="text"  id="txtDate"  placeholder="DD-MM-YYYY" maxlength="20" runat="server"/>
            <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
              <script>

                  $noCon('#cphMain_txtDate').datepicker({
                      autoclose: true,
                      format: 'dd-mm-yyyy',
                      timepicker: false,
                      startDate: new Date(),                     
                  });
                            </script>
          </div>
        </div>

        <div class="form-group fg2 sa_fg3 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Mail Storage Email:<span class="spn1"></span></label>
          <input id="txtMailStrg"  runat="server" maxlength="100" type="text" class="form-control fg2_inp1" placeholder="Mail Storage Email">
             <p class="error" id="ErrortxtMailStrg" style="display:none; font-family:Calibri;">Please enter valid email address</p>
        </div>
        <div class="form-group fg2 fg2_mr sa_fg3 sa_640_i mar_bo1">
          <label for="email" class="fg2_la1 pad_l">Remove Mails From Common Mail Storage:<span class="spn1"></span></label>
          <div class="check1">
            <label class="switch">
              <input type="checkbox" id="cbxRmveStrg"  runat="server">
              <span class="slider_tog round"></span>
            </label>
          </div>
        </div>

        <div class="clearfix"></div>
        <div class="fr_sp1"></div>
        <div class="devider devider_10"></div>

        <div class="fg6 pa_all sa_640_i sa_480">
          <div class="">
            <div class="fg6 tr_l sa_640_i1 sa_480">
              <label for="email" class="fg2_la1">Office Type:<span class="spn1">*</span></label>
              <select class="form-control fg2_inp1 inp_mst fg_chs1" id="ddlOfficeTyp"  runat="server"  onclick="ChangeOfficeType();">
                <option>Head Office</option>
                <option>Branch Office</option>
              </select>
            </div>
            <div class="form-group fg6 mar_bo1 sa_640_i1 sa_480" id="divddlParent">
              <label for="email" class="fg2_la1">Parent Unit:<span class="spn1">*</span></label>
              <select class="form-control fg2_inp1 inp_mst fg_chs1" id="ddlParent"  runat="server" disabled="disabled">
              </select>
            </div>
          </div>
        </div>
        <div class="fg6 pa_all  sa_640_i sa_480">
          <div class="">
            <div class="fg6 tr_l  sa_640_i1 sa_480">
              <label for="email" class="fg2_la1">Office Check-in Time:<span class="spn1"></span></label>
              <select class="form-control fg2_inp1 fg_chs1" id="txtChkIn"  onchange="return changeTimeChk();" runat="server">
                <option>12:00 AM</option>
                <option>12:30 AM</option>
                <option>01:00 AM</option>
                <option>01:30 AM</option>
                <option>02:00 AM</option>
                <option>02:30 AM</option>
                <option>03:00 AM</option>
                <option>03:30 AM</option>
                <option>04:00 AM</option>
                <option>04:30 AM</option>
                <option>05:00 AM</option>
                <option>05:30 AM</option>
                <option>06:00 AM</option>
                <option>06:30 AM</option>
                <option>07:00 AM</option>
                <option>07:30 AM</option>
                <option>08:00 AM</option>
                <option>08:30 AM</option>
                <option>09:00 AM</option>
                <option>09:30 AM</option>
                <option>10:00 AM</option>
                <option>10:30 AM</option>
                <option>11:00 AM</option>
                <option>11:30 AM</option>

                <option>12:00 PM</option>
                <option>12:30 PM</option>
                <option>01:00 PM</option>
                <option>01:30 PM</option>
                <option>02:00 PM</option>
                <option>02:30 PM</option>
                <option>03:00 PM</option>
                <option>03:30 PM</option>
                <option>04:00 PM</option>
                <option>04:30 PM</option>
                <option>05:00 PM</option>
                <option>05:30 PM</option>
                <option>06:00 PM</option>
                <option>06:30 PM</option>
                <option>07:00 PM</option>
                <option>07:30 PM</option>
                <option>08:00 PM</option>
                <option>08:30 PM</option>
                <option>09:00 PM</option>
                <option>09:30 PM</option>
                <option>10:00 PM</option>
                <option>10:30 PM</option>
                <option>11:00 PM</option>
                <option>11:30 PM</option>
              </select>
            </div>
            <div class="fg6 tr_l pad_lft sa_640_i1 sa_480">
              <label for="email" class="fg2_la1">Office Checkout Time:<span class="spn1"></span></label>
              <select class="form-control fg2_inp1 fg_chs1" id="txtChkOut"  onchange="return changeTimeChk();" runat="server">
                <option>12:00 AM</option>
                <option>12:30 AM</option>
                <option>01:00 AM</option>
                <option>01:30 AM</option>
                <option>02:00 AM</option>
                <option>02:30 AM</option>
                <option>03:00 AM</option>
                <option>03:30 AM</option>
                <option>04:00 AM</option>
                <option>04:30 AM</option>
                <option>05:00 AM</option>
                <option>05:30 AM</option>
                <option>06:00 AM</option>
                <option>06:30 AM</option>
                <option>07:00 AM</option>
                <option>07:30 AM</option>
                <option>08:00 AM</option>
                <option>08:30 AM</option>
                <option>09:00 AM</option>
                <option>09:30 AM</option>
                <option>10:00 AM</option>
                <option>10:30 AM</option>
                <option>11:00 AM</option>
                <option>11:30 AM</option>

                <option>12:00 PM</option>
                <option>12:30 PM</option>
                <option>01:00 PM</option>
                <option>01:30 PM</option>
                <option>02:00 PM</option>
                <option>02:30 PM</option>
                <option>03:00 PM</option>
                <option>03:30 PM</option>
                <option>04:00 PM</option>
                <option>04:30 PM</option>
                <option>05:00 PM</option>
                <option>05:30 PM</option>
                <option>06:00 PM</option>
                <option>06:30 PM</option>
                <option>07:00 PM</option>
                <option>07:30 PM</option>
                <option>08:00 PM</option>
                <option>08:30 PM</option>
                <option>09:00 PM</option>
                <option>09:30 PM</option>
                <option>10:00 PM</option>
                <option>10:30 PM</option>
                <option>11:00 PM</option>
                <option>11:30 PM</option>
              </select>
            </div>
          </div>
        </div>
        <div class="clearfix"></div>
        <div class="fr_sp1"></div>
        <div class="devider devider_10"></div>
          <div id="divBankDtls" runat="server">
        <h3><i class="fa fa-archive" style="font-size: 30px;margin-top: 6px;"></i> Bank Details</h3>
        <div class="r_1024 tbl_fx_hi">
          <table class="display table-bordered pro_tab1 tbl_800" cellspacing="0" width="100%">
            <thead class="thead1">
              <tr>
                <th class="col-md-4 tr_l">Bank</th>
                <th class="col-md-3 tr_l">Branch</th>
                <th class="col-md-2 tr_l">Iban#</th>
                <th class="col-md-2">Actions</th>
                </tr>
            </thead>
            <tbody id="TableBankDtlBody">
            
            </tbody>
          </table>
        </div>

        <div class="clearfix"></div>
        <div class="fr_sp1"></div>
        <div class="devider devider_10"></div>
</div>
      <div id="divPrtnshp" style="display:none;">
        <h3 style="width: auto;margin: auto;float: left;"><i class="fa fa-handshake-o" style="font-size: 30px;margin-top: 6px;"></i> Partnership<span class="spn1">*</span></h3>
        <div class="form-group fg7 sa_2 sa_480 flt_r" style="padding-bottom:10px;">
          <label for="email" class="fg2_la1">Company Share Percentage:<span class="spn1">*</span></label>
          <div class="input-group">
            <input id="txtSharePer" runat="server" maxlength="100" class="form-control inp_bdr tr_c inp_mst" type="text" placeholder="0" disabled="">
            <span class="input-group-addon date1">%</span>
          </div>
        </div>

        <div class="r_1024 tbl_fx_hi">
          <table class="display table-bordered pro_tab1 tbl_800" cellspacing="0" width="100%">
            <thead class="thead1">
              <tr>
                <th class="col-md-4 tr_l">Partner</th>
                <th class="col-md-3 tr_l">Document#</th>
                <th class="col-md-2 tr_c">Share %</th>
                <th class="col-md-2">Actions</th>
                </tr>
            </thead>
            <tbody id="TableaddedRows">          
            </tbody>
          </table>
            <div id="divBlink" style="background-color: rgb(249, 246, 3); font-size: 10.5px; color: black; opacity: 0.6;"></div>
        </div>

        <div class="clearfix"></div>
        <div class="fr_sp1"></div>
        <div class="devider devider_10"></div>
      </div>

        <div class="form-group fg2 fg2_mr sa_fg3 sa_640_i">
          <label for="email" class="fg2_la1 plc1 tr_l">Same as Organization Details:<span class="spn1"></span></label>
          <div class="check1">
            <label class="switch">
              <input type="checkbox" id="cbxSameOrg"  runat="server"  onchange="return ViewAttachment();">
              <span class="slider_tog round"></span>
            </label>
          </div>
        </div>
        <div class="clearfix"></div>

        <div class="">
          <div class="col-md-3 col-sm-6 sa_640_i1 mar_at flt_l sa_480">
            <div class="fg12 tr_l">
              <div class="ico_com">
                <i class="fa fa-balance-scale"></i><span class="fa fa-file-text-o"></span>
                <p>COMMERCIAL REGISTRATION</p>
              </div>
            </div>
          </div>

          <div class="col-md-9 mar_at flt_l">
            <div class="fg4 tr_l sa_o_fg6 sa_640_i1">
              <label for="email" class="fg2_la1">Commercial Registration#:<span class="spn1">*</span></label>
              <input id="txtCRN"  runat="server" maxlength="50"  style="text-transform: uppercase" type="text" class="form-control fg2_inp1 inp_mst"  placeholder="Commercial Registration#" name="">
            </div>
            <div class="form-group fg4 tr_l sa_o_fg6 sa_640_i1">
              <label for="pwd" class="fg2_la1">Issue Date:<span class="spn1"></span> </label>
              <div id="datetimepicker9" class="input-group date" data-date-format="mm-dd-yyyy">
                <input class="form-control inp_bdr" type="text" id="txtCRNIssDate"  placeholder="DD-MM-YYYY" maxlength="20" runat="server" />
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                  <script>

                      $noCon('#cphMain_txtCRNIssDate').datepicker({
                          autoclose: true,
                          format: 'dd-mm-yyyy',
                          timepicker: false,
                          endDate: new Date(),
                      });
                            </script>

              </div>
            </div>
            <div class="form-group fg4 tr_l sa_o_fg6 sa_640_i1">
              <label for="pwd" class="fg2_la1">Expiry Date:<span class="spn1">*</span> </label>
              <div id="datetimepicker4" class="input-group date" data-date-format="mm-dd-yyyy">
                <input class="form-control inp_bdr" type="text" id="txtTINExp"  placeholder="DD-MM-YYYY" maxlength="20" runat="server" />
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                  <script>

                      $noCon('#cphMain_txtTINExp').datepicker({
                          autoclose: true,
                          format: 'dd-mm-yyyy',
                          timepicker: false,
                          startDate: new Date(),
                      });
                            </script>
              </div>
            </div>
            
            <div class="clearfix"></div>
            <div class="free_sp"></div>
            <div class="r_1024 tbl_fx_hi">
              <table class="display table-bordered pro_tab1 tbl_800" cellspacing="0" width="100%">
                <thead class="thead1">
                  <tr>
                    <th class="col-md-4 tr_l">Attachment</th>
                    <th class="col-md-5 tr_l">Description</th>
                    <th class="col-md-3">Actions</th>
                    </tr>
                </thead>
                <tbody id="TableFileCRN">
              

                </tbody>
              </table>
            </div>

          </div>
        </div>

        <div class="clearfix"></div>
        <div class="fr_sp1"></div>
        <div class="devider devider_10"></div>

        <div class="">
          <!-- <p class="plc1 tr_l pad_lft">Tax Card</p> -->
          <div class="col-md-3 col-sm-6 sa_640_i1 mar_at flt_l sa_480">
            <div class="fg12 tr_l">
              <div class="ico_com">
                <i class="fa fa-calculator"></i><span class="fa fa-credit-card-alt"></span>
                <p>TAX CARD</p>
              </div>
            </div>
          </div>

          <div class="col-md-9 mar_at flt_l">
            <div class="fg4 tr_l sa_o_fg6 sa_640">
              <label for="email" class="fg2_la1">Tax Identification#:<span class="spn1">*</span></label>
              <input id="txtTIN"  runat="server" maxlength="50"  style="text-transform: uppercase" type="text" class="form-control fg2_inp1 inp_mst"  placeholder="Tax Identification#" name="">
            </div>
            <div class="form-group fg4 tr_l sa_o_fg6 sa_640">
              <label for="pwd" class="fg2_la1">Issue Date:<span class="spn1"></span> </label>
              <div id="datetimepicker5" class="input-group date" data-date-format="mm-dd-yyyy">
                <input class="form-control inp_bdr" type="text"  id="txtTINIss"  placeholder="DD-MM-YYYY" maxlength="20" runat="server"/>
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                  <script>

                      $noCon('#cphMain_txtTINIss').datepicker({
                          autoclose: true,
                          format: 'dd-mm-yyyy',
                          timepicker: false,
                          endDate: new Date(),
                      });
                            </script>
              </div>
            </div>
            <div class="form-group fg4 tr_l sa_o_fg6 sa_640">
              <label for="pwd" class="fg2_la1">Expiry Date:<span class="spn1">*</span> </label>
              <div id="datetimepicker2" class="input-group date" data-date-format="mm-dd-yyyy">
                <input class="form-control inp_bdr" type="text" id="txtCRNExpDate"  placeholder="DD-MM-YYYY" maxlength="20" runat="server" />
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                  <script>

                      $noCon('#cphMain_txtCRNExpDate').datepicker({
                          autoclose: true,
                          format: 'dd-mm-yyyy',
                          timepicker: false,
                          startDate: new Date(),
                      });
                            </script>
              </div>
            </div>
            
            <div class="clearfix"></div>
            <div class="free_sp"></div>
            <div class="r_1024 tbl_fx_hi">
              <table class="display table-bordered pro_tab1 tbl_800" cellspacing="0" width="100%">
                <thead class="thead1">
                  <tr>
                    <th class="col-md-4 tr_l">Attachment</th>
                    <th class="col-md-5 tr_l">Description</th>
                    <th class="col-md-3">Actions</th>
                    </tr>
                </thead>
                <tbody id="TableFileTIN">
              
                </tbody>
              </table>
            </div>

          </div>
        </div>

        <div class="clearfix"></div>
        <div class="fr_sp1"></div>
        <div class="devider devider_10"></div>

        <div class="">
          <!-- <p class="plc1 tr_l pad_lft">Computer Card</p> -->
          <div class="col-md-3 col-sm-6 sa_640_i1 mar_at flt_l sa_480">
            <div class="fg12 tr_l">
              <div class="ico_com">
                <i class="fa fa-laptop"></i><span class="fa fa-credit-card-alt"></span>
                <p>Computer Card</p>
              </div>
            </div>
          </div>

          <div class="col-md-9 mar_at flt_l">
            <div class="fg4 tr_l sa_o_fg6 sa_640">
              <label for="email" class="fg2_la1">Computer Card#:<span class="spn1">*</span></label>
              <input id="txtCCN" runat="server" maxlength="50"  style="text-transform: uppercase" type="text" class="form-control fg2_inp1 inp_mst"  placeholder="Computer Card#" name="">
            </div>
            <div class="form-group fg4 tr_l sa_o_fg6 sa_640">
              <label for="pwd" class="fg2_la1">Issue Date:<span class="spn1"></span> </label>
              <div id="datetimepicker7" class="input-group date" data-date-format="mm-dd-yyyy">
                <input class="form-control inp_bdr" type="text" id="txtCCNIss"  placeholder="DD-MM-YYYY" maxlength="20" runat="server" />
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                  <script>

                      $noCon('#cphMain_txtCCNIss').datepicker({
                          autoclose: true,
                          format: 'dd-mm-yyyy',
                          timepicker: false,
                          endDate: new Date(),
                      });
                            </script>
              </div>
            </div>
            <div class="form-group fg4 tr_l sa_o_fg6 sa_640">
              <label for="pwd" class="fg2_la1">Expiry Date:<span class="spn1">*</span> </label>
              <div id="datetimepicker6" class="input-group date" data-date-format="mm-dd-yyyy">
                <input class="form-control inp_bdr" type="text"  id="txtCCNExp"  placeholder="DD-MM-YYYY" maxlength="20" runat="server"/>
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                  <script>

                      $noCon('#cphMain_txtCCNExp').datepicker({
                          autoclose: true,
                          format: 'dd-mm-yyyy',
                          timepicker: false,
                          startDate: new Date(),
                      });
                            </script>
              </div>
            </div>
            <div class="clearfix"></div>
            <div class="free_sp"></div>
            <div class="r_1024 tbl_fx_hi">
              <table class="display table-bordered pro_tab1 tbl_800" cellspacing="0" width="100%">
                <thead class="thead1">
                  <tr>
                    <th class="col-md-4 tr_l">Attachment</th>
                    <th class="col-md-5 tr_l">Description</th>
                    <th class="col-md-3">Actions</th>
                    </tr>
                </thead>
                <tbody id="TableFileCCN">
              
                </tbody>
              </table>
            </div>
            
          </div>
        </div>

        <div class="clearfix"></div>
        <div class="fr_sp1"></div>
        <div class="devider devider_10"></div>

        <div class="sub_cont pull-right">
          <div class="save_sec">

              <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return CorpOfficeValidation(); " />
                         <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return CorpOfficeValidation(); " />
                         <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return CorpOfficeValidation();" />
                         <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return CorpOfficeValidation();" />
               <asp:Button ID="btnClear" runat="server" class="btn sub2" OnClientClick="return AlertClearAll();" onclick="btnClear_Click" Text="Clear"/>
                      <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmCancel();" />
                         

           
          </div>
         
        </div>
           <asp:FileUpload  runat="server" style="display:none;"/>
          

          <!----------------------------================frame================------------------------------->          
      </div>
<!-------working area_closed---->
    </div>    
   </div>
     <div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">

        <asp:Button ID="btnUpdateF" runat="server" class="btn sub1 bt_b" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return CorpOfficeValidation(); " />
                         <asp:Button ID="btnUpdateCloseF" runat="server" class="btn sub3 bt_b" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return CorpOfficeValidation(); " />
                         <asp:Button ID="btnAddF" runat="server" class="btn sub1 bt_b" Text="Save" OnClick="btnAdd_Click" OnClientClick="return CorpOfficeValidation();" />
                         <asp:Button ID="btnAddCloseF" runat="server" class="btn sub3 bt_b" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return CorpOfficeValidation();" />
               <asp:Button ID="btnClearF" runat="server" class="btn sub2 bt_b" OnClientClick="return AlertClearAll();" onclick="btnClear_Click" Text="Clear"/>
                      <asp:Button ID="btnCancelF" runat="server" class="btn sub4 bt_b" Text="Cancel" OnClientClick="return ConfirmCancel();" />


   
  </div>
  
</div>
     <a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
<i class="fa fa-save"></i>
</a>

       <!---back_button_fixed_section--->
  <a href="#" type="button" class="list_b" title="Back to List" onclick="return ConfirmMessage();" id="divList" runat="server">
    <i class="fa fa-arrow-circle-left"></i>
  </a>
<!---back_button_fixed_section--->
  <!--save_pop up_open-->
<script>
    function opensave() {
        document.getElementById("cphMain_mySave").style.width = "140px";
    }

    function closesave() {
        document.getElementById("cphMain_mySave").style.width = "0px";
    }
</script>
 <style>
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
    </style>
</asp:Content>
