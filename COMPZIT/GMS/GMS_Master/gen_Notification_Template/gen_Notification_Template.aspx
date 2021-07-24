<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage_Compzit_GMS.master" AutoEventWireup="true" CodeFile="gen_Notification_Template.aspx.cs" Inherits="GMS_GMS_Master_gen_Notification_Template_gen_Notification_Template" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
      <style type="text/css">
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
    </style>
    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>

    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

    <script>


        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {
               


            });
        })(jQuery);





    </script>
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

        .eachform h2 {
            margin: 8px 0 6px;
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
    </style>
     <style type="text/css">
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


               #DivTemplateContainer {
    width: 90%;
    min-height: 200px;
    float: left;
    margin-left: 5%;
    border: 1px solid;
    border-color: #0b9aab;
    background: #e0efee;
}
                input[type="radio"] {
    display: inline-block;
}



                .ClearDur{
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
    </style>
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            localStorage.clear();


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
                         
                            
                            //   alert(jsonAtt[key].ActualFileName);
                            EditMoreEachTemplate(jsonAtt[key].TempDetailId, jsonAtt[key].NotifyMod, jsonAtt[key].NotifyVia, jsonAtt[key].NotifyDur);



                            //  alert(json[key].Amount);
                        }
                    }
                }


            }
            else {

                addMoreEachTemplate();
            }


        });
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

         var confirmbox = 0;

         function IncrmntConfrmCounter() {
             confirmbox++;
         }
         function ConfirmMessage() {
             if (confirmbox > 0) {
                 if (confirm("Are You Sure You Want To Leave This Page?")) {
                     window.location.href = "gen_Notification_Template_List.aspx";
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Notification_Template_List.aspx";

             }
         }
         function AlertClearAll() {
             if (confirmbox > 0) {
                 if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                     window.location.href = "gen_Notification_Template.aspx";
                     return false;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Notification_Template.aspx";
                 return false;
             }
         }


      
         function SuccessUpdation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Notification Template Details Updated Successfully.";
         }
         function SuccessConfirmation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Notification Template Details Inserted Successfully.";
         }
         function FailedConfirmation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Notification Template Details Insertion Failed.Please Try Again";
         }
         function DuplicationName() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Template Name Can’t be Duplicated.";
         }
    </script>
     
    <script type="text/javascript" >
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

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

                return false;


            }

            else if (charCode > 31 && (charCode < 48 || charCode > 57)) {

                return false;

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
          // for not allowing <> tags
          function isTagEnter(evt) {

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
          }

          //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
          function textCounter(field, maxlimit) {
              if (field.value.length > maxlimit) {
                  field.value = field.value.substring(0, maxlimit);
              } else {

              }
          }
    </script>
   
    <script type="text/javascript">



        var $noC = jQuery.noConflict();
        var EachTemp = 0;

        function EditMoreEachTemplate(TempDetailId, NotifyMod, NotifyVia, NotifyDur) {

            EachTemp++;

            var recRow = '<tr id="TemplateRowId_' + EachTemp + ' >';
            //recRow += '<td>';
            recRow = '<div id=\"divEachTemplate_' + EachTemp + '\" style=\"float:left;margin-top:1%;padding:10px; width:80%;min-height: 170px;margin-left: 10%;border: 1px dotted;border-color: green;\">';
            recRow += '<div id=\"divTempLeftPart_' + EachTemp + '\" class=\"eachform\" style=\"float:left;width: 25%;height: 169px;border-right: 1px dotted;border-color: green;\">';
            recRow += '<h2 style=\"margin-left: 33%;font-size: 20px;color: #006475;\">Period *</h2>';


            recRow += '<div style=\"width:69%;margin-top: 19%;margin-left: 14%;background-color: wheat;color: #076309;border: 1px solid;\" >';

            recRow += '<input id=\"radioDays_' + EachTemp + '\" type=\"radio\" checked="true" onclick=\"UpdateNotifyMOde(' + EachTemp + ');\" name=\"radType' + EachTemp + '\" />';

            recRow += '<label style=\"font-family:Calibri\" for=\"radioDays_' + EachTemp + '\">Days</label>';


            recRow += '<input id=\"radioHours_' + EachTemp + '\" type=\"radio\" onclick=\"UpdateNotifyMOde(' + EachTemp + ');\" name=\"radType' + EachTemp + '\" style=\"margin-left: 0px;\"/>';
            recRow += '<label style=\"font-family:Calibri\" for=\"radioHours_' + EachTemp + '\">Hours</label>';

            recRow += '</div>';
            recRow += '<div style=\"width: 97%;margin-top: 6%;\">';

            recRow += ' <input type=\"text\" id=\"txtDuration_' + EachTemp + '\" class=\"form1\" onblur=\"UpdateNotifyDuration(' + EachTemp + ');\" onkeydown=\"return isNumber(event);\"  MaxLength=\"4\" Style=\"width: 30%; text-transform: uppercase; margin-right: 31.7%; height: 30px\" />';

            recRow += ' <input type=\"button\" id=\"btnDurClear_' + EachTemp + '\" onclick=\"return ClearDur(' + EachTemp + ');\" class=\"ClearDur\" value=\"Clear\" style=\"margin-top: 13%;margin-left: 29%;\" />';
            recRow += ' </div></div>';


            recRow += '<div id="divTempRightPart_' + EachTemp + '" style="float:right;width: 74%;">';
            recRow += '<h2 style="margin-left: 42%;font-size: 20px;color: #006475;">Intimation *</h2>';

            recRow += '<div id=\"divTempRightContainer_' + EachTemp + '\" style=\"height: 135px;overflow: auto;width: 100%;\">';
            recRow += '<table id=\"TableEachTempSliceContainer_' + EachTemp + '\" style=\"width: 100%;\">';
            recRow += '</table>';

            recRow += ' </div>';
            recRow += '<div id=\"divBtmPortion_' + EachTemp + '\">';
            recRow += '<h2 style=\"float:left; margin-left: 1%;font-size: 16px;color: #000;padding-top: 3px;\">Notification*</h2>';
            recRow += '<input type=\"checkbox\" id=\"cbxDashboard_' + EachTemp + '\" onchange=\"UpdateNotifyVia(' + EachTemp + ',\'cbxDashboard_\');\" style=\"float: left;margin-left: 2%\;" Checked=\"true\" class=\"form2\ " />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">DashBoard</h3>';
            recRow += '<input type=\"checkbox\" id="cbxEmail_' + EachTemp + '" onchange=\"UpdateNotifyVia(' + EachTemp + ',\'cbxEmail_\');\" style="float: left;margin-left: 3%;" Checked="true" class="form2" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">Email</h3>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '<div style=\"float:right;\"><input id="AddEachTempButton_' + EachTemp + '" type=\"image\" src=\"/Images/Icons/black add.png\" onclick="return EachTemplateAddition();" alt=\"Add\" style=\"cursor: pointer;\" /></div>';
            recRow += '<div id="TemplateId_' + EachTemp + '" style="display: none;">' + TempDetailId + '</div>';
            recRow += '<div id="TemplateEvent_' + EachTemp + '" style="display: none;">UPD</div>';

            //recRow += '</td>';
            // recRow += '</tr>';

            jQuery('#TableTemplateContainer').append(recRow);
            document.getElementById("<%=hiddenTemplateCount.ClientID%>").value = EachTemp;

            document.getElementById("txtDuration_" + EachTemp).value = NotifyDur;
            document.getElementById("cbxDashboard_" + EachTemp).checked = false;
            document.getElementById("cbxEmail_" + EachTemp).checked = false;
            if (NotifyMod==1)
            {
                document.getElementById("radioHours_" + EachTemp).checked = true;
            }
            else if (NotifyMod == 2)
            {
                document.getElementById("radioDays_" + EachTemp).checked = true;
            }
            if (NotifyVia!="")
            {
               if (NotifyVia.indexOf("D") >= 0)
               {
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
            //alert(res3);
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
                document.getElementById("btnDurClear_" + EachTemp).disabled = true;
                
            }
            

            return false;
        }

        function addMoreEachTemplate() {

            EachTemp++;

 
            var recRow = '<tr id="TemplateRowId_' + EachTemp + ' >';
            //recRow += '<td>';
            recRow = '<div id=\"divEachTemplate_' + EachTemp + '\" style=\"float:left;margin-top:1%;padding:10px; width:80%;min-height: 170px;margin-left: 10%;border: 1px dotted;border-color: green;\">';
            recRow += '<div id=\"divTempLeftPart_' + EachTemp + '\" class=\"eachform\" style=\"float:left;width: 25%;height: 169px;border-right: 1px dotted;border-color: green;\">';
            recRow += '<h2 style=\"margin-left: 33%;font-size: 20px;color: #006475;\">Period *</h2>';


            recRow += '<div style=\"width:70%;margin-top: 19%;margin-left: 14%;background-color: wheat;color: #076309;border: 1px solid;\" >';
            recRow += '<input id=\"radioDays_' + EachTemp + '\" type=\"radio\" checked="true" onclick=\"UpdateNotifyMOde(' + EachTemp + ');\" name=\"radType' + EachTemp + '\" />';
            recRow += '<label style=\"font-family:Calibri\" for=\"radioDays_' + EachTemp + '\">Days</label>';


            recRow += '<input id=\"radioHours_' + EachTemp + '\" type=\"radio\" onclick=\"UpdateNotifyMOde(' + EachTemp + ');\" name=\"radType' + EachTemp + '\" style=\"margin-left: 26px;\"/>';
            recRow += '<label style=\"font-family:Calibri\" for=\"radioHours_' + EachTemp + '\">Hours</label>';

            recRow += '</div>';
            recRow += '<div style=\"width: 97%;margin-top: 6%;\">';


            recRow += ' <input type=\"text\" id=\"txtDuration_' + EachTemp + '\" class=\"form1\" onblur=\"UpdateNotifyDuration(' + EachTemp + ');\" onkeydown=\"return isNumber(event);\"  MaxLength=\"4\" Style=\"width: 30%; text-transform: uppercase; margin-right: 31.7%; height: 30px\" />';
            recRow += ' <input type=\"button\" id=\"btnDurClear_' + EachTemp + '\" onclick=\"return ClearDur(' + EachTemp + ');\" class=\"ClearDur\" value=\"Clear\" style=\"margin-top: 13%;margin-left: 29%;\" />';
            recRow += ' </div></div>';


            recRow += '<div id="divTempRightPart_' + EachTemp + '" style="float:right;width: 74%;">';
            recRow += '<h2 style="margin-left: 42%;font-size: 20px;color: #006475;">Intimation *</h2>';
           
            recRow += '<div id=\"divTempRightContainer_' + EachTemp + '\" style=\"height: 135px;overflow: auto;width: 100%;\">';

            recRow += '<table id=\"TableEachTempSliceContainer_' + EachTemp + '\" style=\"width: 100%;\">';
            recRow +='</table>';
            
            recRow += ' </div>';
            recRow += '<div id=\"divBtmPortion_' + EachTemp + '\">';
            recRow +='<h2 style=\"float:left; margin-left: 1%;font-size: 16px;color: #000;padding-top: 3px;\">Notification*</h2>';
            recRow += '<input type=\"checkbox\" id=\"cbxDashboard_' + EachTemp + '\" checked="true" onchange=\"UpdateNotifyVia(' + EachTemp + ',\'cbxDashboard_\');\" style=\"float: left;margin-left: 2%\;" Checked=\"true\" class=\"form2\ " />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">DashBoard</h3>';
            recRow += '<input type=\"checkbox\" id="cbxEmail_' + EachTemp + '" checked="true" onchange=\"UpdateNotifyVia(' + EachTemp + ',\'cbxEmail_\');\" style="float: left;margin-left: 3%;" Checked="true" class="form2" />';
            recRow +='<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">Email</h3>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '<div style=\"float:right;\"><input type=\"image\" src=\"/Images/Icons/black add.png\" onclick="return EachTemplateAddition();" alt=\"Add\" style=\"cursor: pointer;\" /></div>';
            recRow += '<div id="TemplateId_' + EachTemp + '" style="display: none;"> </div>';
            recRow += '<div id="TemplateEvent_' + EachTemp + '" style="display: none;">INS</div>';

            //recRow += '</td>';
            // recRow += '</tr>';

            jQuery('#TableTemplateContainer').append(recRow);
            AddDefaultTemplateValues(EachTemp);
            AddEachTempSlice(EachTemp,"Div");
            document.getElementById("<%=hiddenTemplateCount.ClientID%>").value = EachTemp;
            
            return false;
        }



        var SliceCounter = 0;

        var EachTeCou = 0;
        var blurcounter = 0;
        function EditEachTempSlice(EachTempCount, AlertId, AlertOpt, AlrtNtfyId) {

            var FrecRow = '<tr id="EachSliceRowId_' + EachTempCount + '_' + SliceCounter + '" >';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDivi_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/divisions.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DivisionClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div></td>';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDesig_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/designation.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DesignationClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';

            FrecRow += '<td style=\"width:5%\"><div id="divSmallEmp_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/employee.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return EmployeeClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div>  </td>';
            FrecRow += '<td style=\"width:5%\"><div id="divSmallMail_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/generic mail.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return GenericMailClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';
            FrecRow += '<td style=\"width:63%;background-color: #c5c5c5;\">';
            FrecRow += '<div id="divddlDivision_' + EachTempCount + '_' + SliceCounter + '" >';
            FrecRow += '<select id="ddlDivision_' + EachTempCount + '_' + SliceCounter + '" onchange="ChangeFile(\'ddlDivision_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;" />';
            FrecRow += '</div>';
            FrecRow += '<div id="divddlDesignation_' + EachTempCount + '_' + SliceCounter + '" >';
            FrecRow += '<select id="ddlDesignation_' + EachTempCount + '_' + SliceCounter + '" onchange="ChangeFile(\'ddlDesignation_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;" />';
            FrecRow += '</div>';
            FrecRow += '<div id="divddlEmployee_' + EachTempCount + '_' + SliceCounter + '" >';
            FrecRow += '<select id="ddlEmployee_' + EachTempCount + '_' + SliceCounter + '" onchange="ChangeFile(\'ddlEmployee_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;" />';
            FrecRow += '</div>';
            FrecRow += '<input type=\"text\" id="txtGenMail_' + EachTempCount + '_' + SliceCounter + '" onblur="ChangeFile(\'txtGenMail_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;display:none;" placeholder="Enter Generic Mail Id" />';
            FrecRow += '</td>';
            FrecRow += '<td id="FileIndvlAddMoreRow_' + EachTempCount + '_' + SliceCounter + '"  style=\"width:7%;opacity:1;\"><input id="inputAddRow_' + EachTempCount + '_' + SliceCounter + '" type=\"image\" src=\"/Images/Icons/eachtempadd.png\" alt=\"Add\" onclick="return CheckaddMoreRowsIndividualFiles(' + EachTempCount + ',' + SliceCounter + ');" style=\"cursor: pointer;\" /> </td>';
            FrecRow += '<td style=\"width:10%\"><input id="inputDeleteRow_' + EachTempCount + '_' + SliceCounter + '" type=\"image\" src=\"/Images/Icons/eachtempclose.png\" alt=\"Add\" onclick = "return RemoveEachSlice(' + EachTempCount + ',' + SliceCounter + ');"  style=\"cursor: pointer;\" /> </td>';

            FrecRow += '<td id="FileInx_' + EachTempCount + '_' + SliceCounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">' + AlertId + '</td>';
            FrecRow += '<td id="DbFileName_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableEachTempSliceContainer_' + EachTempCount).append(FrecRow);

           // $('#divTempRightContainer_' + EachTempCount).scrollTop($('#divTempRightContainer_' + EachTempCount)[0].scrollHeight);

            document.getElementById("inputAddRow_" + EachTempCount + "_" + SliceCounter).disabled = false;


            if (EachTeCou != EachTempCount && EachTeCou != 0) {

                blurcounter = 0;
            }
            EachTeCou = EachTempCount;

            if (blurcounter != 0)
            {
                blurSlice = SliceCounter - 1;
                document.getElementById("FileIndvlAddMoreRow_" + EachTempCount + "_" + blurSlice).style.opacity = "0.3";
                document.getElementById("inputAddRow_" + EachTempCount + "_" + blurSlice).disabled = true;
                
            }

            blurcounter++;


            if (AlertOpt == 0) {
                FillDivisionDdl(EachTempCount, SliceCounter); 
                document.getElementById("divSmallDivi_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";
                document.getElementById("divddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "block";
                document.getElementById("divddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("divddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "none";

                setTimeout(selectDropDown("ddlDivision_", EachTempCount, SliceCounter, AlrtNtfyId),100);
                FillDesignationDdl(EachTempCount, SliceCounter);
                FillEmployeeDdl(EachTempCount, SliceCounter);

                ChangeFile('ddlDivision_',EachTempCount ,SliceCounter);
            }
            else if (AlertOpt == 1) {
                FillDesignationDdl(EachTempCount, SliceCounter);
               document.getElementById("divSmallDesig_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";

               document.getElementById("divddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "none";
               document.getElementById("divddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "block";
               document.getElementById("divddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "none";
               document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "none";

               setTimeout(selectDropDown("ddlDesignation_", EachTempCount, SliceCounter, AlrtNtfyId),100);
               FillDivisionDdl(EachTempCount, SliceCounter);
               FillEmployeeDdl(EachTempCount, SliceCounter);
               ChangeFile('ddlDesignation_', EachTempCount, SliceCounter);
            }
            else if (AlertOpt == 2) {
                FillEmployeeDdl(EachTempCount, SliceCounter);
               document.getElementById("divSmallEmp_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";

               document.getElementById("divddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "none";
               document.getElementById("divddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "none";
               document.getElementById("divddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "block";
               document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "none";

               
               setTimeout(selectDropDown("ddlEmployee_", EachTempCount, SliceCounter, AlrtNtfyId),100);
               FillDesignationDdl(EachTempCount, SliceCounter);
               FillDivisionDdl(EachTempCount, SliceCounter);
               ChangeFile('ddlEmployee_', EachTempCount, SliceCounter);
            }
            else if (AlertOpt == 3) {
      
                document.getElementById("divSmallMail_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";
                document.getElementById("divddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("divddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("divddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "block";

                selectDropDown("txtGenMail_", EachTempCount, SliceCounter, AlrtNtfyId);
                FillEmployeeDdl(EachTempCount, SliceCounter);
                FillDesignationDdl(EachTempCount, SliceCounter);
                FillDivisionDdl(EachTempCount, SliceCounter);
                ChangeFile('txtGenMail_', EachTempCount, SliceCounter);
            }
       
            if (document.getElementById("<%=hiddenEditMode.ClientID%>").value == "View") {
                
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("inputAddRow_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("inputDeleteRow_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).disabled = true;
                $("div#divddlEmployee_" + EachTempCount + "_" + SliceCounter + " input.ui-autocomplete-input").attr("disabled", "disabled");
                $("div#divddlDesignation_" + EachTempCount + "_" + SliceCounter + " input.ui-autocomplete-input").attr("disabled", "disabled");
                $("div#divddlDivision_" + EachTempCount + "_" + SliceCounter + " input.ui-autocomplete-input").attr("disabled", "disabled");
                document.getElementById("divSmallDivi_" + EachTempCount + "_" + SliceCounter).style.pointerEvents = "none";
                document.getElementById("divSmallDesig_" + EachTempCount + "_" + SliceCounter).style.pointerEvents = "none";
                document.getElementById("divSmallEmp_" + EachTempCount + "_" + SliceCounter).style.pointerEvents = "none";
                document.getElementById("divSmallMail_" + EachTempCount + "_" + SliceCounter).style.pointerEvents = "none";
            }
            //else {
            //    $au('#ddlDivision_' + EachTempCount + "_" + SliceCounter).selectToAutocomplete1Letter();
            //    $au('#ddlDesignation_' + EachTempCount + "_" + SliceCounter).selectToAutocomplete1Letter();
            //    $au('#ddlEmployee_' + EachTempCount + "_" + SliceCounter).selectToAutocomplete1Letter();
            //}

           
            SliceCounter++;

            return false;
        }


        function AddEachTempSlice(EachTempCount, AutoOpenDiv) {

            var FrecRow = '<tr id="EachSliceRowId_' + EachTempCount + '_' + SliceCounter + '" >';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDivi_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/divisions.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DivisionClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div></td>';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDesig_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/designation.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DesignationClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';

            FrecRow += '<td style=\"width:5%\"><div id="divSmallEmp_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/employee.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return EmployeeClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div>  </td>';
            FrecRow += '<td style=\"width:5%\"><div id="divSmallMail_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/generic mail.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return GenericMailClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';
            FrecRow += '<td style=\"width:63%;background-color: #c5c5c5;\">';
            FrecRow += '<div id="divddlDivision_' + EachTempCount + '_' + SliceCounter + '" >';
            FrecRow += '<select id="ddlDivision_' + EachTempCount + '_' + SliceCounter + '" onchange="ChangeFile(\'ddlDivision_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;" />';
            FrecRow += '</div>';
            FrecRow += '<div id="divddlDesignation_' + EachTempCount + '_' + SliceCounter + '" >';
            FrecRow += '<select id="ddlDesignation_' + EachTempCount + '_' + SliceCounter + '" onchange="ChangeFile(\'ddlDesignation_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;" />';
            FrecRow += '</div>';
            FrecRow += '<div id="divddlEmployee_' + EachTempCount + '_' + SliceCounter + '" >';
            FrecRow += '<select id="ddlEmployee_' + EachTempCount + '_' + SliceCounter + '" onchange="ChangeFile(\'ddlEmployee_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;" />';
            FrecRow += '</div>';
            FrecRow += '<input type=\"text\" id="txtGenMail_' + EachTempCount + '_' + SliceCounter + '" onblur="ChangeFile(\'txtGenMail_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;display:none;" placeholder="Enter Generic Mail Id" />';
            FrecRow += '</td>';
            FrecRow += '<td id="FileIndvlAddMoreRow_' + EachTempCount + '_' + SliceCounter + '"  style=\"width:7%;opacity:1;\"><input id="inputAddRow_' + EachTempCount + '_' + SliceCounter + '" type=\"image\" src=\"/Images/Icons/eachtempadd.png\" alt=\"Add\" onclick="return CheckaddMoreRowsIndividualFiles(' + EachTempCount + ',' + SliceCounter + ');" style=\"cursor: pointer;\" /> </td>';
            FrecRow += '<td style=\"width:10%\"><input type=\"image\" src=\"/Images/Icons/eachtempclose.png\" alt=\"Add\" onclick = "return RemoveEachSlice(' + EachTempCount + ',' + SliceCounter + ');"  style=\"cursor: pointer;\" /> </td>';

            FrecRow += '<td id="FileInx_' + EachTempCount + '_' + SliceCounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableEachTempSliceContainer_' + EachTempCount).append(FrecRow);
            // $('#divTempRightContainer_' + EachTempCount).scrollTop($('#divTempRightContainer_' + EachTempCount)[0].scrollHeight);
            FillDivisionDdl(EachTempCount, SliceCounter);
            FillDesignationDdl(EachTempCount, SliceCounter);
            FillEmployeeDdl(EachTempCount, SliceCounter);
            document.getElementById("divSmallDivi_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";
        

            if (AutoOpenDiv == "Div") {
                DivisionClick(EachTempCount, SliceCounter);
            }
            else if (AutoOpenDiv == "Des") {
                DesignationClick(EachTempCount, SliceCounter);
            }
            else if (AutoOpenDiv == "Emp") {
                EmployeeClick(EachTempCount, SliceCounter);
            }
            else if (AutoOpenDiv == "Mail") {
                GenericMailClick(EachTempCount, SliceCounter);
            }


            SliceCounter++;


            var objDiv = document.getElementById("divTempRightContainer_" + EachTempCount);
            objDiv.scrollTop = objDiv.scrollHeight;
            return false;



        }


        function selectDropDown(ddlid, TempCount, SliceCount, ddlvalue) {
            //alert('j');
            document.getElementById(ddlid + TempCount + "_" + SliceCount).value = ddlvalue;

            if (ddlid == "ddlDivision_")
            {
                var EmpVal = $au("#ddlDivision_" + TempCount + "_" + SliceCount + " option:selected").text();

                $au("div#divddlDivision_"+TempCount + "_" + SliceCount+" input.ui-autocomplete-input").val(EmpVal);
            }
            else if (ddlid == "ddlDesignation_") {
                var EmpVal = $au("#ddlDesignation_" + TempCount + "_" + SliceCount + " option:selected").text();

                $au("div#divddlDesignation_" + TempCount + "_" + SliceCount + " input.ui-autocomplete-input").val(EmpVal);
            }
            else if (ddlid == "ddlEmployee_") {
                var EmpVal = $au("#divddlEmployee_" + TempCount + "_" + SliceCount + " option:selected").text();

                $au("div#divddlEmployee_" + TempCount + "_" + SliceCount + " input.ui-autocomplete-input").val(EmpVal);
            }
           }
        
           function ClearDur(EachTemp) {
               IncrmntConfrmCounter();
               document.getElementById("txtDuration_" + EachTemp).value = "";
               return false;
           }
         //----------for selection process------//
           function ChangeBGColor(divName, Temp, Slice) {
               document.getElementById("divSmallDivi_" + Temp + "_" + Slice).style.backgroundColor = "#fff";
               document.getElementById("divSmallDesig_" + Temp + "_" + Slice).style.backgroundColor = "#fff";
               document.getElementById("divSmallEmp_" + Temp + "_" + Slice).style.backgroundColor = "#fff";
               document.getElementById("divSmallMail_" + Temp + "_" + Slice).style.backgroundColor = "#fff";

               document.getElementById(divName + Temp + "_" + Slice).style.backgroundColor = "#0246bd";

           }
           function DivisionClick(Temp, Slice)
           {
               IncrmntConfrmCounter();
               ChangeBGColor("divSmallDivi_", Temp, Slice);

               document.getElementById("divddlDivision_" + Temp + "_" + Slice).style.display = "block";
               document.getElementById("divddlDesignation_" + Temp + "_" + Slice).style.display = "none";
               document.getElementById("divddlEmployee_" + Temp + "_" + Slice).style.display = "none";
               document.getElementById("txtGenMail_" + Temp + "_" + Slice).style.display = "none";
               document.getElementById("ddlDesignation_" + Temp + "_" + Slice).value = 0;
               document.getElementById("ddlEmployee_" + Temp + "_" + Slice).value = 0;
               document.getElementById("txtGenMail_" + Temp + "_" + Slice).value = "";
               var Filerow_index = jQuery('#EachSliceRowId_' + Temp + '_' + Slice).index();
               FileLocalStorageDelete(Filerow_index, Temp, Slice);
               document.getElementById("FileEvt_" + Temp + "_" + Slice).innerHTML = "INS";

               return false;
           }
           function DesignationClick(Temp, Slice)
           {
               IncrmntConfrmCounter();
               ChangeBGColor("divSmallDesig_", Temp, Slice);
               document.getElementById("divddlDivision_" + Temp + "_" + Slice).style.display = "none";
               document.getElementById("divddlDesignation_" + Temp + "_" + Slice).style.display = "block";
               document.getElementById("divddlEmployee_" + Temp + "_" + Slice).style.display = "none";
               document.getElementById("txtGenMail_" + Temp + "_" + Slice).style.display = "none";

               document.getElementById("ddlDivision_" + Temp + "_" + Slice).value = 0;
               document.getElementById("ddlEmployee_" + Temp + "_" + Slice).value = 0;
               document.getElementById("txtGenMail_" + Temp + "_" + Slice).value = "";
               var Filerow_index = jQuery('#EachSliceRowId_' + Temp + '_' + Slice).index();
               FileLocalStorageDelete(Filerow_index, Temp, Slice);
               document.getElementById("FileEvt_" + Temp + "_" + Slice).innerHTML = "INS";
               return false;
           }
           function EmployeeClick(Temp, Slice)
           {
               IncrmntConfrmCounter();
              
               document.getElementById("divddlDivision_" + Temp + "_" + Slice).style.display = "none";
               document.getElementById("divddlDesignation_" + Temp + "_" + Slice).style.display = "none";
               document.getElementById("divddlEmployee_" + Temp + "_" + Slice).style.display = "block";
               document.getElementById("txtGenMail_" + Temp + "_" + Slice).style.display = "none";

               document.getElementById("ddlDivision_" + Temp + "_" + Slice).value = 0;
               document.getElementById("ddlDesignation_" + Temp + "_" + Slice).value = 0;
               document.getElementById("txtGenMail_" + Temp + "_" + Slice).value = "";

               ChangeBGColor("divSmallEmp_", Temp, Slice);
               var Filerow_index = jQuery('#EachSliceRowId_' + Temp + '_' + Slice).index();
               FileLocalStorageDelete(Filerow_index, Temp, Slice);
               document.getElementById("FileEvt_" + Temp + "_" + Slice).innerHTML = "INS";
               return false;
           }
          function GenericMailClick(Temp, Slice)
          {
              IncrmntConfrmCounter();
              ChangeBGColor("divSmallMail_",Temp, Slice);
              document.getElementById("divddlDivision_" + Temp + "_" + Slice).style.display = "none";
              document.getElementById("divddlDesignation_" + Temp + "_" + Slice).style.display = "none";
              document.getElementById("divddlEmployee_" + Temp + "_" + Slice).style.display = "none";
               document.getElementById("txtGenMail_" + Temp + "_" + Slice).style.display = "block";

               document.getElementById("ddlDivision_" + Temp + "_" + Slice).value = 0;
               document.getElementById("ddlDesignation_" + Temp + "_" + Slice).value = 0;
               document.getElementById("ddlEmployee_" + Temp + "_" + Slice).value = 0;

               var Filerow_index = jQuery('#EachSliceRowId_' + Temp + '_' + Slice).index();
               FileLocalStorageDelete(Filerow_index, Temp, Slice);
               document.getElementById("FileEvt_" + Temp + "_" + Slice).innerHTML = "INS";
               return false;
           }
        //----------end selection process------//
        
        //--------for binding dropdown list----------//


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
                  $au('#ddlDivision_' + Temp + "_" + Slice).selectToAutocomplete1Letter();
              }
              else {
                  var IntCorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
                  var IntOrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
                  $noCon.ajax({
                      type: "POST",
                      url: "gen_Notification_Template.aspx/DropdownDivisionBind",
                      data: '{tableName:"' + tableName + '",CorpId:"'+IntCorpId+'",OrgId:"'+IntOrgId+'"}',
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

                          $au('#ddlDivision_' + Temp + "_" + Slice).selectToAutocomplete1Letter();
                      },
                      failure: function (response) {

                      }
                  });
              }
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
                  $au('#ddlDesignation_' + Temp + "_" + Slice).selectToAutocomplete1Letter();
              }
              else {

                  var IntCorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
                  var IntOrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
                  $noCon.ajax({
                      type: "POST",
                      url: "gen_Notification_Template.aspx/DropdownDesignationBind",
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

                          $au('#ddlDesignation_' + Temp + "_" + Slice).selectToAutocomplete1Letter();
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
                ddlEmpdata=document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value ;
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
                $au('#ddlEmployee_' + Temp + "_" + Slice).selectToAutocomplete1Letter();
                }
        
            else {
                var IntCorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
                var IntOrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
                  $noCon.ajax({
                      type: "POST",
                      url: "gen_Notification_Template.aspx/DropdownEmployeeBind",
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
                          $au('#ddlEmployee_' + Temp + "_" + Slice).selectToAutocomplete1Letter();
                      },
                      failure: function (response) {

                      }
                  });
              }
          }


        //---------end dropdown bind-------//

        function EachTemplateAddition() {
            IncrmntConfrmCounter();
              if (confirm("Are You Sure.You want to add new template section?.You are not able to delete it in future")) {

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
                      TEMPID: "" + TemplateId + "",
                      TEMPIDG: "0"
                  });
              }
              tbClientNotifyMode.push(client);
              localStorage.setItem("tbClientNotifyMode", JSON.stringify(tbClientNotifyMode));

              var $FileE = jQuery.noConflict();
              $FileE("#cphMain_hiddenNotificationMOde").val(JSON.stringify(tbClientNotifyMode));

              //---------
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
              //-----

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


          function UpdateNotifyMOde(TempCount)
          {

              var Fevt = document.getElementById("TemplateEvent_" + TempCount).innerHTML;
              var TemplateId = document.getElementById("TemplateId_" + TempCount).innerHTML;

              var Mode="";
              if (document.getElementById("radioDays_" + TempCount).checked == true) {
                  Mode = "D";
              }
              else if (document.getElementById("radioHours_" + TempCount).checked == true) {
                  Mode = "H";
              }

              var row_index = TempCount - 1;
              //var row_index = jQuery('#TemplateRowId_' + TempCount ).index();

              var tbClientNotifyMode = localStorage.getItem("tbClientNotifyMode");
              if (tbClientNotifyMode == null)
              {
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
              document.getElementById("txtDuration_" + TempCount).style.borderColor="";
             
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
              //var row_index = jQuery('#TemplateRowId_' + TempCount).index();

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
          function UpdateNotifyVia(TempCount,ClickedCbx) {

              var Fevt = document.getElementById("TemplateEvent_" + TempCount).innerHTML;
              var TemplateId = document.getElementById("TemplateId_" + TempCount).innerHTML;
              var Via = "";
              if (document.getElementById("cbxEmail_" + TempCount).checked == true) {

                  Via = Via+","+"E";
              }
              if (document.getElementById("cbxDashboard_" + TempCount).checked == true) {

                  Via = Via + "," + "D";
              }

              var row_index = TempCount - 1;

              //var row_index = jQuery('#TemplateRowId_' + TempCount).index();

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

        function RemoveEachSlice(TempCount,removeNum) {
            if (confirm("Are you Sure you want to Delete?")) {
                //  alert('ASD');
                var Filerow_index = jQuery('#EachSliceRowId_' + TempCount+'_' + removeNum).index();
                FileLocalStorageDelete(Filerow_index,TempCount, removeNum);
                jQuery('#EachSliceRowId_' + TempCount + '_' + removeNum).remove();

                // alert(Filerow_index);

                var TableFileRowCount = document.getElementById("TableEachTempSliceContainer_" + TempCount).rows.length;

                if (TableFileRowCount != 0) {
                    var idlast = $noC('#TableEachTempSliceContainer_' + TempCount + ' tr:last').attr('id');
              
                    //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                    //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                    if (idlast != "") {
                        var res = idlast.split("_");
                        //  alert(res[1]);
                        document.getElementById("FileInx_" + TempCount + '_' + res[2]).innerHTML = " ";
                        document.getElementById("FileIndvlAddMoreRow_" + TempCount + '_' + res[2]).style.opacity = "1";
                        document.getElementById("inputAddRow_" + TempCount + "_" + res[2]).disabled = false;
                    }
                }
                else {
                    AddEachTempSlice(TempCount, "Div");


                }

            }
            else {

                return false;
            }
        }

    </script>
    <script>
        function ChangeFile(DDL, TempCount, Slice) {
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

                        FileLocalStorageEdit(DDL, TempCount, Slice, row_index);
                    }
                    else {

                        FileLocalStorageAdd(DDL, TempCount, Slice);
                    }
                }
                else {
                    var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_" + TempCount);//Retrieve the stored data

                    tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload);

                    if (tbClientTemplateUpload != null && tbClientTemplateUpload != []) {
                        var Filerow_index = jQuery('#EachSliceRowId_' + TempCount + '_' + Slice).index();
                        FileLocalStorageDelete(Filerow_index, Temp, Slice);

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

                        FileLocalStorageEdit(DDL, TempCount, Slice, row_index);
                    }
                    else {

                        FileLocalStorageAdd(DDL, TempCount, Slice);
                    }
                }
                else {
                    var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_" + TempCount);//Retrieve the stored data

                    tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload);
                    if (tbClientTemplateUpload != null && tbClientTemplateUpload != []) {
                        var Filerow_index = jQuery('#EachSliceRowId_' + TempCount + '_' + Slice).index();
                        FileLocalStorageDelete(Filerow_index, TempCount, Slice);
                    }
                }

            }

        }
      
        function CheckaddMoreRowsIndividualFiles(TempCount, x) {
           
            if (CheckEachDdl(TempCount, x)) {

                var AutoOpenDiv = "";
                if (document.getElementById("divddlDivision_" + TempCount + "_" + x).style.display != "none") {
                    AutoOpenDiv = "Div";

                } else if (document.getElementById("divddlDesignation_" + TempCount + "_" + x).style.display != "none") {
                    AutoOpenDiv = "Des";
                }
                else if (document.getElementById("divddlEmployee_" + TempCount + "_" + x).style.display != "none") {
                    AutoOpenDiv = "Emp";
                }
                else if (document.getElementById("txtGenMail_" + TempCount + "_" + x).style.display != "none") {
                    AutoOpenDiv = "Mail";
                }

                var check = document.getElementById("FileInx_" + TempCount + "_" + x).innerHTML;
                if (check ==" ") {
                    var Fevt = document.getElementById("FileEvt_" + TempCount + "_" + x).innerHTML;
                    if (Fevt != 'UPD') {

                        document.getElementById("FileInx_" + TempCount + "_" + x).innerHTML = TempCount + "_" + x;
                        document.getElementById("FileIndvlAddMoreRow_" + TempCount + "_" + x).style.opacity = "0.3";

                       
                        AddEachTempSlice(TempCount, AutoOpenDiv);
                        document.getElementById("inputAddRow_" + TempCount + "_" + x).disabled = true;
                        return false;

                    }
                    else {

                        document.getElementById("FileInx_" + TempCount + "_" + x).innerHTML = TempCount + "_" + x;
                        document.getElementById("FileIndvlAddMoreRow_" + TempCount + "_" + x).style.opacity = "0.3";

                        AddEachTempSlice(TempCount, AutoOpenDiv);
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


        function FileLocalStorageAdd(ddl,TempCount,Slice) {

            var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_" + TempCount);//Retrieve the stored data

            tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload); //Converts string to object

            if (tbClientTemplateUpload == null) //If there is no data, initialize an empty array
                tbClientTemplateUpload = [];


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
                    DTLID: "" + FdetailId + "",
                    DTLIDG: "0"

                });
            }

            tbClientTemplateUpload.push(client);
            localStorage.setItem("tbClientTemplateUpload_" + TempCount, JSON.stringify(tbClientTemplateUpload));

           // $addFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientQuotationFileUpload));




            document.getElementById("FileSave_" + TempCount +'_'+ Slice).innerHTML = "saved";
            //   alert('saved');
            return true;

        }

        function FileLocalStorageEdit(ddl, TempCount, Slice, row_index) {
         
            var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_" + TempCount);//Retrieve the stored data

            tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload); //Converts string to object

            if (tbClientTemplateUpload == null) //If there is no data, initialize an empty array
                tbClientTemplateUpload = [];
            var DropDownValue = document.getElementById(ddl + TempCount + '_' + Slice).value; 
            var FdetailId = document.getElementById("FileDtlId_" + TempCount + '_' + Slice).innerHTML; 
            var Fevt = document.getElementById("FileEvt_" + TempCount + '_' + Slice).innerHTML;

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
            //$FileE("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientTemplateUpload));
            return true;
        }

        function FileLocalStorageDelete(row_index, TempCount, Slice) {
            var $DelFile = jQuery.noConflict();
            var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_" + TempCount);//Retrieve the stored data

            tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload); //Converts string to object
            if (tbClientTemplateUpload == null) //If there is no data, initialize an empty array
                tbClientTemplateUpload = [];

            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            tbClientTemplateUpload.splice(row_index, 1);
            localStorage.setItem("tbClientTemplateUpload_" + TempCount, JSON.stringify(tbClientTemplateUpload)); 
            // $DelFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientTemplateUpload));


            var Fevt = document.getElementById("FileEvt_" + TempCount + '_' + Slice).innerHTML;
            if (Fevt == 'UPD') {
                var FdetailId = document.getElementById("FileDtlId_" + TempCount + '_' + Slice).innerHTML;

                if (FdetailId != '') {

                    DeleteFileLSTORAGEAdd(TempCount,Slice);
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

        

      
    </script>

     <script type="text/javascript">
         var $noCon = jQuery.noConflict();
         function Validate() {

             var ret = true;
             if (CheckIsRepeat() == true) {
             }
             else {
                 ret = false;
                 return ret;
             }
             // replacing < and > tags
             var VehNumberWithoutReplace = document.getElementById("<%=txtTemplateName.ClientID%>").value;
             var replaceText1 = VehNumberWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtTemplateName.ClientID%>").value = replaceText2;

             var TempType = document.getElementById("<%=ddlTempType.ClientID%>");
             var TempTypeText = TempType.options[TempType.selectedIndex].text;


             var TempName = document.getElementById("<%=txtTemplateName.ClientID%>").value.trim();
             document.getElementById("<%=txtTemplateName.ClientID%>").style.borderColor = "";
             document.getElementById("<%=ddlTempType.ClientID%>").style.borderColor = "";
             if (TempName=="")
             {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                 document.getElementById("<%=txtTemplateName.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtTemplateName.ClientID%>").focus();
                 ret = false;
             }

             if (TempTypeText == "--SELECT TEMPLATE TYPE--") {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                 document.getElementById("<%=ddlTempType.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=ddlTempType.ClientID%>").focus();
                   ret = false;
               }


             var Count = document.getElementById("<%=hiddenTemplateCount.ClientID%>").value;


             var TotalValue = "";
             var DeletedValue = "";
             for (intCount = 1; intCount <= Count; intCount++) {
                 if (localStorage.getItem("tbClientTemplateUpload_" + intCount) != null && localStorage.getItem("tbClientTemplateUpload_" + intCount)!="[]") {

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

             return ret;
         }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenTemplateCount" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenCorporateId" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenOrganisationId" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenNotificationMOde" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenNotificationDuration" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenNotifyVia" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenEachSliceData" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenDeleteSliceData" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenEachTemplateDetail" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenTemplateAlertData" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenDivisionddlData" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenDesignationddlData" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenEmployeeDdlData" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenEditMode" runat="server" Value="0" />
    <asp:HiddenField ID="hiddensliceCounter" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenNoValueIdentify" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenTemplateChange" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenGuaranteeId" runat="server" />
        <asp:HiddenField ID="HiddenInsuranceId" runat="server" />

    <div class="cont_rght">

        <div id="divMessageArea" style="display: none; margin: 0px 0 13px;">
            <img id="imgMessageArea" src="">
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 0%; top: 22%; height: 26.5px;">

            <%--   <a href="gen_ProjectsList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>

        <div class="fillform" style="width: 100%">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>

            <div id="divGreySection">
                <div id="divTempType" class="eachform" style="width: 49%; float: left; margin-top: 2%;">
                    <h2 style="margin-left: 10%;margin-top:4px">Template Type *</h2>

                    <asp:DropDownList ID="ddlTempType" class="form1" Style="float: right; width: 50% !important; margin-right: 4.5%;" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                    </asp:DropDownList>

                </div>

                    <div class="eachform" style="width: 49%; float: right; margin-top: 2%;">
                       <h2 style="margin-left: 8%">Template Name *</h2>
                        <asp:TextBox ID="txtTemplateName" class="form1" runat="server" MaxLength="100" Style="width: 50%; text-transform: uppercase; margin-right: 9.7%; height: 30px"></asp:TextBox>
                       </div>
               
                  <div class="eachform" style="width: 49%; float: left; margin-top: 0%">
                    <h2 style="margin-left: 10%">Status*</h2>
                    <div class="subform" style="width: 30%; margin-right: 25%; padding-top: 7px;">
                        <asp:CheckBox ID="cbxStatus" Text="" runat="server" Checked="true" class="form2" />

                        <h3>Active</h3>

                    </div>
                </div>
              
                 <div class="eachform" style="width: 49%; float: left; margin-top: 0%">
                   <div class="subform" style="width: 30%; margin-right: 24%; padding-top: 7px;">
                        <asp:CheckBox ID="cbxDefault" Text="" runat="server" Checked="true" class="form2" />

                        <h3>Set As Default</h3>

                    </div>
                </div>

                 <table id="Table1" style="width: 100%;">
                     </table>

                <div id="DivTemplateContainer" style="width:86%;min-height:200px;padding: 25px;margin-top: 3%;" >


                    <table id="TableTemplateContainer" style="width: 100%;">
                    
                     </table>

                </div>
     

                <div class="eachform" style="width: 99%; margin-top: 3%; float: left">
                    <div class="subform" style="width: 65%; margin-left: 38%">
                          <asp:Button ID="btnModifyIns"  runat="server" class="save" Text="Modify Insurance" OnClientClick="return Validate();" OnClick="btnModifyIns_Click" />
                          <asp:Button ID="btnModify"  runat="server" class="save" Text="Modify Guarantee" OnClientClick="return Validate();" OnClick="btnModify_Click" />
                
                    <asp:Button ID="btnUpdate"  runat="server" class="save" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnUpdateClose"  runat="server" class="save" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click"  />
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="btnAddClose"  runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="btnCancel"  runat="server" class="cancel" Text="Cancel" PostBackUrl="gen_Notification_Template_List.aspx"  />
                    
                    </div>
                </div>


                <br style="clear: both" />
            </div>




        </div>
    </div>

</asp:Content>


