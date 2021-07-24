<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Immgrtn_Asgnmnt.aspx.cs" Inherits="HCM_HCM_Master_hcm_Immigration_hcm_Immigration_Assignment_hcm_Immgrtn_Asgnmnt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <%--    //for multy select dropdown--%>
    <script src="/JavaScript/multiselect/jQuery/jquery-3.1.1.min.js"></script>
    <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>

    <%-- for datetime picker--%>
    <script src="/JavaScript/datepicker/bootstrap-datepicker.js"></script>
    <link href="/JavaScript/datepicker/datepicker3.css" rel="stylesheet" />



    <script type="text/javascript">

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

        var $noC = jQuery.noConflict();

        $noCon = jQuery.noConflict();
        $noCon2 = jQuery.noConflict();
        $noCon(function () {

            document.getElementById("freezelayer").style.display = "none";
            document.getElementById("MyModalProcessMultiple").style.display = "none";
            $noCon('#cphMain_ddlEmployee').selectToAutocomplete();

        });

        var $NonCon = jQuery.noConflict();
        function LoadAssignSection() {
            if (document.getElementById("MyModalProcessMultiple").style.display == "none") { //evm-0023
            document.getElementById("freezelayer").style.display = "";
            document.getElementById('myModalLoadingMail').style.display = "block";
            document.getElementById("freezelayer").style.zIndex = "110";

            CounterInitialize();

            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "hcm_Immgrtn_Asgnmnt.aspx/ReadImmiRounds",
                data: '{intCorpId: "' + CorpId + '",intOrgId:"' + OrgId + '"}',
                dataType: "json",
                success: function (data) {
                    var RoundsData = data.d[0];
                    if (RoundsData != "" && RoundsData != null) {

                        var find2 = '\\"\\[';
                        var re2 = new RegExp(find2, 'g');
                        var res2 = RoundsData.replace(re2, '\[');

                        var find3 = '\\]\\"';
                        var re3 = new RegExp(find3, 'g');
                        var res3 = res2.replace(re3, '\]');
                        //   alert('res3' + res3);
                        var json = $noCon.parseJSON(res3);


                        for (var key in json) {
                            if (json.hasOwnProperty(key)) {
                                if (json[key].RoundId != "") {

                                    addMoreRows(json[key].RoundId, json[key].RoundName);

                                }
                            }
                        }


                        ShowProcess_Multy();
                        document.getElementById('myModalLoadingMail').style.display = "none";
                        document.getElementById("freezelayer").style.zIndex = "29";
                        return true;

                    }
                    else {

                        document.getElementById('myModalLoadingMail').style.display = "none";
                        document.getElementById("freezelayer").style.display = "none";
                        alert("Please add immigration round before proceed.");

                        return false;
                    }
                }
            });
            }
            else { //evm-0023
                return false;
            }
        }

    </script>

    <script type="text/javascript">



        var $noC = jQuery.noConflict();
        var rowCount = 0;
        //rowCount for uniquness
        //row index add(+) and (-)delete count based on action
        var RowIndex = 0;

        function CounterInitialize() {
            rowCount = 0;
            RowIndex = 0;
        }

        function addMoreRows(RoundId, RoundName) {

            rowCount++;
            RowIndex++;
            var recRow = '<tr id="rowId_' + rowCount + '" >';
            recRow += '  <td style="width: 4.8%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">' + rowCount + '</td>';
            recRow += '<td style="width: 25.2%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">' + RoundName + '</td>';

            recRow += ' <td style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">';
            recRow += ' <select style="height: 27px; width: 100%; float: left;" id="ddlStatus_' + rowCount + '" class="form1"  /> ';
            recRow += ' </td> ';
            recRow += '<td id="tdEmp_' + rowCount + '"  style="width: 40%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">';
            recRow += ' <select data-placeholder="select employee" onkeydown=\"return FuncRetFalse()\" style="width:100%" id="ddlEmployee_' + rowCount + '" class="form1 select2" multiple="multiple" /> ';
            recRow += '</td>';

            recRow += ' <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">';

            recRow += '<input type="text" id="txtTargetDate_' + rowCount + '" onkeydown=\"return DisableEnter(event);\" placeholder="dd/mm/yyyy" class="form-control pull-right" Style="width: 93%; height: 23px; font-family: calibri;" />';
            recRow += '</td>';



            recRow += ' <td id="RoundId_' + rowCount + '" style="display: none;" >' + RoundId + ' </td>';

            recRow += '</tr>';


            jQuery('#tblImmigrMult tbody').append(recRow);


            FillStatusDropDown(RoundId, rowCount, 0);
            FillEmployeeDropDown(rowCount, 0,0,0);

            $noC('#txtTargetDate_' + rowCount).datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date(),
                forceParse: false
            });

            $noC("#ddlEmployee_" + rowCount).select2();


        }



        function EditMoreRows(AsgnDtlId, RoundId, RoundName, RoundStatus, RoundDate, FinishSts, CloseSts, EmpIds,EmpNames,EmpSts) {

            rowCount++;
            RowIndex++;
            var recRow = '<tr id="rowId_' + rowCount + '" >';
            recRow += '  <td style="width: 4.8%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">' + rowCount + '</td>';
            recRow += '<td style="width: 25.2%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">' + RoundName + '</td>';

            recRow += ' <td style="width: 20%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">';
            recRow += ' <select style="height: 27px; width: 100%; float: left;" id="ddlStatus_' + rowCount + '" class="form1"  /> ';
            recRow += ' </td> ';
            recRow += '<td id="tdEmp_' + rowCount + '"  style="width: 30.4%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">';
            recRow += ' <select data-placeholder="select employee" onkeydown=\"return FuncRetFalse()\" style="width:305px" id="ddlEmployee_' + rowCount + '" class="form1 select2" multiple="multiple" /> ';
            recRow += '</td>';

            recRow += ' <td style="width: 10%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">';

            recRow += '<input type="text" id="txtTargetDate_' + rowCount + '" onkeydown=\"return DisableEnter(event);\" placeholder="dd/mm/yyyy" class="form-control pull-right" Style="width: 93%; height: 23px; font-family: calibri;" />';
            recRow += '</td>';

            recRow += ' <td style="width: 4.8%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">';
            recRow += ' <a id="btnFini_' + rowCount + '" class="tooltip" title="Finish" onclick="return FinishProcess(' + rowCount + ');"><img style="cursor: pointer; margin-left: 25%; opacity: 1;" src="/Images/Icons/success.png" /></a>';
            recRow += '</td>';

            recRow += '<td style="width: 4.8%; word-break: break-all; word-wrap: break-word; text-align: left; border-bottom: 1px solid #cbbdbd">';
            recRow += '<a id="btnClos_' + rowCount + '" class="tooltip" title="Close" onclick="return CloseProcess(' + rowCount + ');"><img style="cursor: pointer; margin-left: 25%;" src="/Images/Icons/close.png" /></a>';
            recRow += '<a id="btnRecall_' + rowCount + '" style="display:none" class="tooltip" title="Recall" onclick="return RecallProcess(' + rowCount + ');"> <img style="cursor: pointer; margin-left: 25%;" src="/Images/Icons/recallProcess.png" /></a>';

            recRow += '</td>';
            recRow += ' <td id="DtlId_' + rowCount + '" style="display: none;" >' + AsgnDtlId + ' </td>';
            recRow += ' <td id="RoundId_' + rowCount + '" style="display: none;" >' + RoundId + ' </td>';
            recRow += ' <td id="Finish_' + rowCount + '" style="display: none;" >0</td>';
            recRow += ' <td id="Close_' + rowCount + '" style="display: none;" >0</td>';
            recRow += '</tr>';


            jQuery('#tblImmigrSingle tbody').append(recRow);


            FillStatusDropDown(RoundId, rowCount, RoundStatus);
            FillEmployeeDropDown(rowCount, EmpIds,EmpNames,EmpSts);



            $noC('#txtTargetDate_' + rowCount).datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                startDate: new Date(),
                forceParse: false
            });

          
            $noC("#ddlEmployee_" + rowCount).select2();
            document.getElementById('txtTargetDate_' + rowCount).value = RoundDate;

            if (FinishSts == 1) {
                document.getElementById('txtTargetDate_' + rowCount).disabled = true;
                document.getElementById('ddlStatus_' + rowCount).disabled = true;
                document.getElementById('ddlEmployee_' + rowCount).disabled = true;

                $noC(document).on('select2:opening.disabled', ':disabled', function () { return false; })

                document.getElementById('Finish_' + rowCount).innerHTML = "1";
                document.getElementById('btnFini_' + rowCount).style.pointerEvents = "none";
                document.getElementById('btnFini_' + rowCount).style.opacity = ".25";
                document.getElementById('btnClos_' + rowCount).style.pointerEvents = "none";
                document.getElementById('btnClos_' + rowCount).style.opacity = ".25";
            }
            else {
                document.getElementById('cphMain_btnImmiAsgnSingleSave').style.visibility = "visible";
            }

            if (CloseSts == 1) {
                document.getElementById('txtTargetDate_' + rowCount).disabled = true;
                document.getElementById('ddlStatus_' + rowCount).disabled = true;
                document.getElementById('ddlEmployee_' + rowCount).disabled = true;

                document.getElementById('Close_' + rowCount).innerHTML = "1";
                document.getElementById('btnFini_' + rowCount).style.pointerEvents = "none";
                document.getElementById('btnFini_' + rowCount).style.opacity = ".25";
                document.getElementById('btnClos_' + rowCount).style.display = "none";
                document.getElementById('btnRecall_' + rowCount).style.display = "";
            }
        }
        function FuncRetFalse() {
            return false;
        
        }

        function FinishProcess(Count) {

            ret = true;

            if (document.getElementById('txtTargetDate_' + Count).value == "") {
                document.getElementById('txtTargetDate_' + Count).style.borderColor = "red";
                document.getElementById('txtTargetDate_' + Count).focus();
                ret = false;
            }
            if (document.getElementById('ddlStatus_' + Count).value == 0) {
                document.getElementById('ddlStatus_' + Count).style.borderColor = "red";
                document.getElementById('ddlStatus_' + Count).focus();
                ret = false;
            }
            if (document.getElementById("ddlEmployee_" + Count).value == "") {
                document.getElementById('ddlEmployee_' + Count).style.borderColor = "red";
                document.getElementById('ddlEmployee_' + Count).focus();
                ret = false;
            }

            if (ret == true) {
                if (confirm("Are you sure?.You want to finish this round.")) {
                    CheckAlreadyClsFnsh("F", Count);
                }
            }
        }
        function CloseProcess(Count) {
            ret = true;
          
            if (document.getElementById('txtTargetDate_' + Count).value == "") {
                document.getElementById('txtTargetDate_' + Count).style.borderColor = "red";
                document.getElementById('txtTargetDate_' + Count).focus();
                ret = false;
            }
            if (document.getElementById('ddlStatus_' + Count).value == 0)
            {
                document.getElementById('ddlStatus_' + Count).style.borderColor = "red";
                document.getElementById('ddlStatus_' + Count).focus();
                ret = false;
            }
            if (document.getElementById("ddlEmployee_" + Count).value == "") {
                document.getElementById('ddlEmployee_' + Count).style.borderColor = "red";
                document.getElementById('ddlEmployee_' + Count).focus();
                ret = false;
            }
           

            if (ret == true) {
                if (confirm("Are you sure?.You want to close this round.")) {
                    CheckAlreadyClsFnsh("C", Count);

                }
            }
        }
        function RecallProcess(Count) {
            if (confirm("Are you sure?.You want to recall this round.")) {

                document.getElementById('txtTargetDate_' + Count).disabled = false;
                document.getElementById('ddlStatus_' + Count).disabled = false;
                document.getElementById('ddlEmployee_' + Count).disabled = false;

                document.getElementById('btnFini_' + Count).style.pointerEvents = "";
                document.getElementById('btnFini_' + Count).style.opacity = "1";
                document.getElementById('btnClos_' + Count).style.pointerEvents = "";
                document.getElementById('Close_' + Count).innerHTML = "0";
                document.getElementById('btnClos_' + Count).style.display = "";
                document.getElementById('btnRecall_' + Count).style.display = "none";

                var DetailId = document.getElementById('DtlId_' + Count).innerHTML;
                $noCon.ajax({
                    type: "POST",
                    async: false,
                    url: "hcm_Immgrtn_Asgnmnt.aspx/RecallClosed",
                    data: '{strDetailId:"' + DetailId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                    },
                    failure: function (response) {

                    }
                });
            }
        }

        function CheckAlreadyClsFnsh(Process, Count) {

            var DetailId = document.getElementById('DtlId_' + Count).innerHTML;
            $noCon.ajax({
                type: "POST",
                async: false,
                url: "hcm_Immgrtn_Asgnmnt.aspx/CheckStatusAlreadyDone",
                data: '{strDetailId:"' + DetailId + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    if (Process == "F") {
                        if (response.d[0] == 1 || response.d[1] == 1) {
                            if (response.d[1] == 1) {
                                alert("Sorry.It is already closed");
                            }
                            else {
                                alert("Sorry.It is already finished");
                            }
                            document.getElementById('txtTargetDate_' + Count).disabled = true;
                            document.getElementById('ddlStatus_' + Count).disabled = true;
                            document.getElementById('ddlEmployee_' + Count).disabled = true;

                            //$noCon('select2-search-field > input.select2-input').on('keypress', function (e) {
                            //    alert();
                            //    if (e.keyCode === 13)
                            //        addToList($(this).val());
                            //});

                            //$noCon('select2-selection select2-selection--multiple').on('keypress', function (e) {
                            //    if (e.keyCode === 13)
                            //        addToList($(this).val());
                            //});
                            //$noCon("#ddlEmployee_" + Count).keypress(function (event) {
                            //    DisableEnter(event);
                            //});
        
                            document.getElementById('Finish_' + Count).innerHTML = "1";
                            document.getElementById('btnFini_' + Count).style.pointerEvents = "none";
                            document.getElementById('btnFini_' + Count).style.opacity = ".25";
                            document.getElementById('btnClos_' + Count).style.pointerEvents = "none";
                            return false;
                        }
                        else {
                            document.getElementById('txtTargetDate_' + Count).disabled = true;
                            document.getElementById('ddlStatus_' + Count).disabled = true;
                            document.getElementById('ddlEmployee_' + Count).disabled = true;

                            $noCon("#form1 select2").keypress(function (event) {
                                DisableEnter(event);
                            });
             
                            document.getElementById('Finish_' + Count).innerHTML = "1";
                            document.getElementById('btnFini_' + Count).style.pointerEvents = "none";
                            document.getElementById('btnFini_' + Count).style.opacity = ".25";
                            document.getElementById('btnClos_' + Count).style.pointerEvents = "none";
                            return true;
                        }

                    }

                    else {
                        if (response.d[0] == 1 || response.d[1] == 1) {
                            if (response.d[1] == 1) {
                                alert("Sorry.It is already closed");
                            }
                            else {
                                alert("Sorry.It is already finished");
                            }

                            document.getElementById('txtTargetDate_' + Count).disabled = true;
                            document.getElementById('ddlStatus_' + Count).disabled = true;
                            document.getElementById('ddlEmployee_' + Count).disabled = true;
                       
                            document.getElementById('Finish_' + Count).innerHTML = "1";
                            document.getElementById('btnFini_' + Count).style.pointerEvents = "none";
                            document.getElementById('btnFini_' + Count).style.opacity = ".25";
                            document.getElementById('btnClos_' + Count).style.pointerEvents = "none";
                            return false;
                        }
                        else {
                            document.getElementById('txtTargetDate_' + Count).disabled = true;
                            document.getElementById('ddlStatus_' + Count).disabled = true;
                            document.getElementById('ddlEmployee_' + Count).disabled = true;
                         
                            document.getElementById('btnFini_' + Count).style.pointerEvents = "none";
                            document.getElementById('btnFini_' + Count).style.opacity = ".25";
                            document.getElementById('btnClos_' + Count).style.pointerEvents = "none";
                            document.getElementById('Close_' + Count).innerHTML = "1";
                            document.getElementById('btnClos_' + Count).style.display = "none";
                            document.getElementById('btnRecall_' + Count).style.display = "";
                            return true;
                        }
                    }
                },
                failure: function (response) {

                }
            });

        }

        var $noCon = jQuery.noConflict();
        function FillStatusDropDown(RoundId, Count, RoundStatus) {
            var ddlTestDropDownListXML = $noCon("#ddlStatus_" + Count);

            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableStatus";

            var IntCorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
              var IntOrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
             $noCon.ajax({
                 type: "POST",
                 async: false,
                 url: "hcm_Immgrtn_Asgnmnt.aspx/DropdownRoundStatusBind",
                 data: '{tableName:"' + tableName + '",intRoundId:"' + RoundId + '"}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (response) {
                     var OptionStart = $noCon("<option>--SELECT STATUS--</option>");
                     OptionStart.attr("value", 0);
                     ddlTestDropDownListXML.append(OptionStart);

                     // Now find the Table from response and loop through each item (row).
                     $noCon(response.d).find(tableName).each(function () {
                         // Get the OptionValue and OptionText Column values.
                         var OptionValue = $noCon(this).find('IMGRTNRNDDTL_ID').text();
                         var OptionText = $noCon(this).find('IMGRTNRNDDTL_NAME').text();
                         // Create an Option for DropDownList.
                         var option = $noCon("<option>" + OptionText + "</option>");
                         option.attr("value", OptionValue);

                         ddlTestDropDownListXML.append(option);
                     });

                     if (RoundStatus != 0) {
                         document.getElementById('ddlStatus_' + Count).value = RoundStatus;
                     }
                 },
                 failure: function (response) {

                 }
             });

         }
        function FillEmployeeDropDown(Count, EmpIds, EmpNames, EmpSts) {
      
             var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
              var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
              var ddlTestDropDownListXML = $noCon("#ddlEmployee_" + Count);

              // Provide Some Table name to pass to the WebMethod as a paramter.
              var tableName = "dtTableEmp";

              var IntCorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
              var IntOrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
              $noCon.ajax({
                  type: "POST",
                  async: false,
                  url: "hcm_Immgrtn_Asgnmnt.aspx/DropdownEmployeeBind",
                  data: '{tableName:"' + tableName + '",intCorpId: "' + CorpId + '",intOrgId:"' + OrgId + '"}',
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (response) {

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
                      if (EmpIds != 0) {
                          var totalStringIds = EmpIds;
                          eachStringIds = totalStringIds.split(',');

                          var totalStringnames = EmpNames;
                          eachStringNames = totalStringnames.split(',');

                          var totalStringSts = EmpSts;
                          eachStringSts = totalStringSts.split(',');

                          var newVar = new Array();
                          for (count = 0; count < eachStringIds.length; count++) {


                              if (eachStringSts[count]=="0")
                              {

                                  var option = $noCon("<option>" + eachStringNames[count] + "</option>");
                                  option.attr("value", eachStringIds[count]);

                                  ddlTestDropDownListXML.append(option);

                              }

                              if (eachStringIds[count] != "") {
                                  newVar.push(eachStringIds[count]);
                              }

                         

                          }

                          $noC("#ddlEmployee_" + Count).val(newVar);
                          $noC("#ddlEmployee_" + Count).trigger("change");
                      }
                  },
                  failure: function (response) {

                  }
              });

          }
    </script>
    <script type="text/javascript">
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
        function SuccessIns() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Immigration Assignment added successfully.";
            $(window).scrollTop(0);
        }
        //old
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Immigration Assignment updated successfully.";
        }

        function SuccessRecall() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Immigration Assignment Recalled successfully.";
        }

        function getselected() {
            var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
            var strAmntList = "";
            checked = false;
            for (i = 0; i < RowCount; i++) {


                if (document.getElementById('cblcandidatelist' + i).checked) {

                    checked = true;
                    strAmntList = strAmntList + document.getElementById('tdcandiateid' + i).innerHTML + ',';

                }
            }
            if (checked == false) {
                return false;
            }

            document.getElementById("<%=Hiddenchecklist.ClientID%>").value = strAmntList;
            return true;
        }

        function selectAllCandidate() {
            var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
            var strAmntList = "";
            if (document.getElementById('cbxSelectAll').checked == true) {
                for (i = 0; i < RowCount; i++) {

                    document.getElementById('cblcandidatelist' + i).checked = true;

                }
            }
            else {
                for (i = 0; i < RowCount; i++) {

                    document.getElementById('cblcandidatelist' + i).checked = false;

                }
            }
        }

        function SearchValidation() {


            var ddlManPwr = document.getElementById("<%=ddlEmployee.ClientID%>").value;
            if (ddlManPwr == '--SELECT EMPLOYEE--') {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "red";
                return false;
            }
            else {

                return true;
            }
        }

        var $noConfli = jQuery.noConflict();
        function ShowProcess_Multy() {
            var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
            var strAmntList = "";
            checked = false;
            count = 0;
            for (i = 0; i < RowCount; i++) {
                if (document.getElementById('cblcandidatelist' + i).checked) {

                    checked = true;
                    count++;
                    strAmntList = strAmntList + document.getElementById('tdcandiateid' + i).innerHTML + ',';

                }
            }
            if (checked == false) {

                document.getElementById('divErrorlabel').style.visibility = "visible";
                document.getElementById("freezelayer").style.display = "none";
                return false;
            }
            else {

                document.getElementById('divErrorlabel').style.visibility = "hidden";

                if (count == 1) {
                    document.getElementById('lblImmiHead').innerHTML = "Immigration Individual Assignment";
                    strAmntList = strAmntList.replace(',', "");
                    $noConfli.ajax({
                        type: "POST",
                        async: false,
                        url: "hcm_Immgrtn_Asgnmnt.aspx/ReadEmpCandidateData",
                        data: '{intCandId:"' + strAmntList + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            document.getElementById("<%=lblRefNo.ClientID%>").innerHTML = response.d[0];
                            document.getElementById("<%=lblEmpId.ClientID%>").innerHTML = response.d[1];
                            document.getElementById("<%=lblFname.ClientID%>").innerHTML = response.d[2];
                            document.getElementById("<%=lblDesignation.ClientID%>").innerHTML = response.d[3];
                            document.getElementById("<%=lblEmpType.ClientID%>").innerHTML = response.d[4];
                            document.getElementById("<%=lblRole.ClientID%>").innerHTML = response.d[5];
                            document.getElementById("<%=lblJoinDate.ClientID%>").innerHTML = response.d[6];

                        }
                    });


                    document.getElementById('JbShdlTopSingle').style.display = "block";
                    document.getElementById('JbShdlTopMulty').style.display = "none";

                }
                else {
                    document.getElementById('lblImmiHead').innerHTML = "Immigration Bulk Assignment";
                    document.getElementById('JbShdlTopSingle').style.display = "none";
                    document.getElementById('JbShdlTopMulty').style.display = "block";
                    document.getElementById('lblNoOfselectedEmp').innerHTML = count;
                }

                document.getElementById("<%=Hiddenchecklist.ClientID%>").value = strAmntList;
                document.getElementById("MyModalProcessMultiple").style.display = "block";
                return true;
            }
        }

        function CloseProcessMulty() {
            if (confirm("Are you sure?. You want to close this window")) {

                document.getElementById("MyModalProcessMultiple").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
                jQuery('#tblImmigrMult tbody tr').remove();
                return true;
            }
            else {
                return false;
            }
        }

        function CloseProcessSingle() {
            if (confirm("Are you sure?. You want to close this window")) {
                document.getElementById("MymodalProcessSingle").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
                jQuery('#tblImmigrSingle tbody tr').remove();
                return true;
            }
            else {
                return false;
            }
        }

        function ValidateProcessSingle() {

            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            for (var count = 1; count <= rowCount; count++) {
                if (document.getElementById("ddlStatus_" + count).value == "0") {
                    document.getElementById("ddlStatus_" + count).style.borderColor = "red";
                    document.getElementById("ddlStatus_" + count).focus();
                    ret = false;
                }
                if (document.getElementById("ddlEmployee_" + count).value == "") {
                    document.getElementById("ddlEmployee_" + count).style.borderColor = "red";
                    document.getElementById("ddlEmployee_" + count).focus();
                    ret = false;
                }
                if (document.getElementById("txtTargetDate_" + count).value == "") {
                    document.getElementById("txtTargetDate_" + count).style.borderColor = "red";
                    document.getElementById("txtTargetDate_" + count).focus();
                    ret = false;
                }
            }
            if (ret == true) {


                var tbClientTotalValues = '';
                tbClientTotalValues = [];

                for (var counting = 1; counting <= rowCount; counting++) {

                    var RoundId = document.getElementById("RoundId_" + counting).innerHTML;
                    var $add = jQuery.noConflict();
                    var empIdsEach = "(" + $add("#ddlEmployee_" + counting).val() + ")";
                    var FinishSts = document.getElementById("Finish_" + counting).innerHTML;
                    var CloseSts = document.getElementById("Close_" + counting).innerHTML;
                    var DetailId = document.getElementById("DtlId_" + counting).innerHTML;

                    var client = JSON.stringify({
                        ROWID: "" + counting + "",
                        ROUND: "" + RoundId + "",
                        STATUS: $add("#ddlStatus_" + counting).val(),
                        EMPIDS: "" + empIdsEach + "",
                        DATEPASS: $add("#txtTargetDate_" + counting).val(),
                        FINISH: "" + FinishSts + "",
                        CLOSE: "" + CloseSts + "",
                        DETAILID: "" + DetailId + "",
                    });


                    tbClientTotalValues.push(client);
                }

                document.getElementById("<%=hiddenTotalData.ClientID%>").value = JSON.stringify(tbClientTotalValues);
                // $noConfli("#cphMain_hiddenTotalData").val(JSON.stringify(tbClientJobSheduling));
            }
            else {
                CheckSubmitZero();
            }
            return ret;
        }

        function ValidateProcessMulty() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

            for (var count = 1; count <= rowCount; count++) {
                if (document.getElementById("ddlStatus_" + count).value == "0") {
                    document.getElementById("ddlStatus_" + count).style.borderColor = "red";
                    document.getElementById("ddlStatus_" + count).focus();
                    ret = false;
                }
                if (document.getElementById("ddlEmployee_" + count).value == "") {
                    document.getElementById("ddlEmployee_" + count).style.borderColor = "red";
                    document.getElementById("ddlEmployee_" + count).focus();
                    ret = false;
                }
                if (document.getElementById("txtTargetDate_" + count).value == "") {
                    document.getElementById("txtTargetDate_" + count).style.borderColor = "red";
                    ret = false;
                }
            }



            if (ret == true) {


                var tbClientTotalValues = '';
                tbClientTotalValues = [];
                for (var counting = 1; counting <= rowCount; counting++) {

                    var RoundId = document.getElementById("RoundId_" + counting).innerHTML;
                    var $add = jQuery.noConflict();
                    var empIdsEach = "(" + $add("#ddlEmployee_" + counting).val() + ")";

                    var client = JSON.stringify({
                        ROWID: "" + counting + "",
                        ROUND: "" + RoundId + "",
                        STATUS: $add("#ddlStatus_" + counting).val(),
                        EMPIDS: "" + empIdsEach + "",
                        DATEPASS: $add("#txtTargetDate_" + counting).val(),
                        FINISH: "0",
                        CLOSE: "0",
                        DETAILID: "0",
                    });


                    tbClientTotalValues.push(client);
                }

                document.getElementById("<%=hiddenTotalData.ClientID%>").value = JSON.stringify(tbClientTotalValues);
                // $noConfli("#cphMain_hiddenTotalData").val(JSON.stringify(tbClientJobSheduling));
            }
            else {
                CheckSubmitZero();
            }

            return ret;
        }

        //FOR EDITING PAGE

        function ProcessEdit(EmpId, CandId) {
            CounterInitialize();
            document.getElementById("freezelayer").style.display = "";
            document.getElementById('myModalLoadingMail').style.display = "block";
            document.getElementById("freezelayer").style.zIndex = "110";

            $noConfli.ajax({
                type: "POST",
                async: false,
                url: "hcm_Immgrtn_Asgnmnt.aspx/ReadEmpCandidateData",
                data: '{intCandId:"' + CandId + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    document.getElementById("<%=lblRefNo2.ClientID%>").innerHTML = response.d[0];
                    document.getElementById("<%=lblEmpId2.ClientID%>").innerHTML = response.d[1];
                    document.getElementById("<%=lblFname2.ClientID%>").innerHTML = response.d[2];
                    document.getElementById("<%=lblDesignation2.ClientID%>").innerHTML = response.d[3];
                    document.getElementById("<%=lblEmpType2.ClientID%>").innerHTML = response.d[4];
                    document.getElementById("<%=lblRole2.ClientID%>").innerHTML = response.d[5];
                    document.getElementById("<%=lblJoinDate2.ClientID%>").innerHTML = response.d[6];

                }
            });

            $noConfli.ajax({
                type: "POST",
                async: false,
                url: "hcm_Immgrtn_Asgnmnt.aspx/ReadAsignedDetail",
                data: '{intCandId:"' + CandId + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var RoundsData = data.d[0];
                    if (RoundsData != "" && RoundsData != null) {
                        document.getElementById('cphMain_btnImmiAsgnSingleSave').style.visibility = "hidden";
                        var find2 = '\\"\\[';
                        var re2 = new RegExp(find2, 'g');
                        var res2 = RoundsData.replace(re2, '\[');

                        var find3 = '\\]\\"';
                        var re3 = new RegExp(find3, 'g');
                        var res3 = res2.replace(re3, '\]');
                        //   alert('res3' + res3);
                        var json = $noCon.parseJSON(res3);


                        for (var key in json) {
                            if (json.hasOwnProperty(key)) {
                                if (json[key].RoundId != "") {

                                    EditMoreRows(json[key].ImmiDtlId, json[key].RoundId, json[key].RoundName, json[key].RoundSts, json[key].TarDate, json[key].FnshSts, json[key].CloseSts, json[key].EmpIds, json[key].EmpNames, json[key].EmpSts);

                                }
                            }
                        }
                        
                        document.getElementById('myModalLoadingMail').style.display = "none";
                        document.getElementById("freezelayer").style.zIndex = "29";
                    }
                    else {
                        document.getElementById('myModalLoadingMail').style.display = "none";
                        document.getElementById("freezelayer").style.zIndex = "29";
                        alert("Please add immigration round to proceed.");
                    }
                }
            });

            document.getElementById("MymodalProcessSingle").style.display = "block";
            document.getElementById("freezelayer").style.display = "";

            return true;

        }



        function ConfirmCancel() {
            if (confirm("Are you sure? Do you want to cancel")) {

                window.location.href = "hcm_Immgrtn_Asgnmnt.aspx";
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenCandidateId" runat="server" />
    <asp:HiddenField ID="HiddenreqstId" runat="server" />
    <asp:HiddenField ID="HiddenShortlistMasterid" runat="server" />
    <asp:HiddenField ID="hiddenRowCount" runat="server" />
    <asp:HiddenField ID="Hiddenchecklist" runat="server" />
    <asp:HiddenField ID="hiddenFinishStatus" runat="server" />
    <asp:HiddenField ID="hiddenCloseStatus" runat="server" />
    <asp:HiddenField ID="hiddenRecallStatus" runat="server" />
    <asp:HiddenField ID="hiddenAlreadyClosed" runat="server" />
    <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="hiddenAsignId" runat="server" />
    <asp:HiddenField ID="HiddenRoleModify" runat="server" />

    <asp:HiddenField ID="hiddenTotalData" runat="server" />

    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div class="cont_rght">

        <div id="divReportCaption" style="width: 100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; float: left">
            <asp:Label ID="lblEntry" runat="server">Immigration Assignment</asp:Label>
        </div>
        <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke; float: left">


            <div style="float: left; width: 100%; margin-top: 1%">
                <div style="width: 30%; float: left; padding: 5px; border: 1px solid #c3c3c3;">
                    <h2>Immigration* :</h2>
                    <div style="float: right; margin-right: 0%; width: 61%;">
                        <asp:RadioButton ID="radioAssigned" Text="Assigned" runat="server" Checked="true" GroupName="RadioSkCer" Style="float: left; font-family: calibri" OnKeypress="return DisableEnter(event)" />
                        <asp:RadioButton ID="radioNotAssigned" Text="Not Assigned" runat="server" GroupName="RadioSkCer" Style="float: left; font-family: calibri; margin-left: 6%;" OnKeypress="return DisableEnter(event)" />
                    </div>
                </div>

                <div style="width: 63%; float: left; padding: 5px; margin-left: 4%;">
                    <h2>Employee* : </h2>

                    <asp:DropDownList ID="ddlEmployee" class="form1" runat="server" Style="height: 30px; width: 35%; float: left; margin-left: 2%;">
                    </asp:DropDownList>

                    <asp:Button ID="btnSearch" Style="cursor: pointer; margin-left: 10%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />

                </div>

            </div>

            <div id="divReport" class="table-responsive" runat="server" style="float: left; width: 100%; margin-top: 1%">
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>

            <div id="divErrorlabel" style="float: left; margin-left: 70%; visibility: hidden;">
                <label style="color: red; font-family: calibri;">Please select atleast one Employee</label>
            </div>
            <input type="button" id="btnAssign" runat="server" onkeypress="return DisableEnter(event)" style="width: 114px; float: left; margin-left: 0.5%; margin-top: 0%; background: #127c8f; border: 2px solid #c5c5c5;" class="save" value="Assign" onclick="LoadAssignSection()" />

        </div>

    </div>

    <%-- ----------------for immigration assignment multiple//-----%>

    <div>
        <div id="MyModalProcessMultiple" class="MyModalProcessMultiple">
            <div id="divJbFull">
                <div id="DivEmpHeader" style="height: 30px; background-color: #6f7b5a;">

                    <label id="lblImmiHead" style="margin-left: 38%; font-size: 18px; color: #fff; font-family: calibri;">Immigration Bulk Assignment</label>

                    <img class="closeCancelView" style="margin-top: .5%; margin-right: 1%; float: right; cursor: pointer;" onclick="return CloseProcessMulty();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
                </div>
                <div style="float: left; margin: 13px; border: 1px solid; border-color: #d7c9c9; background-color: #fff; margin-bottom: 6px; width: 97%;">
                    <div id="JbShdlTopMulty" style="width: 100%; float: left; margin-top: 1%;">
                        <h2 style="margin-left: 2%; width: 23%; float: left;">No.of selected persons : 
                        </h2>
                        <label id="lblNoOfselectedEmp" style="float: left; color: #042f95; font-family: calibri; width: 10%; cursor: inherit"></label>
                    </div>

                    <div id="JbShdlTopSingle" style="width: 91%; float: left; margin-top: .5%; padding: 16px; margin-left: 3%; background-color: #ded2d2;">

                        <div class="eachform" style="width: 47%; float: left;">
                            <h2 style="color: #603504;">Ref.No</h2>
                            <asp:Label ID="lblRefNo" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: right;">
                            <h2 style="color: #603504;">Employee Id</h2>
                            <asp:Label ID="lblEmpId" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: left;">
                            <h2 style="color: #603504;">First Name</h2>
                            <asp:Label ID="lblFname" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: right;">
                            <h2 style="color: #603504;">Designation</h2>
                            <asp:Label ID="lblDesignation" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: left;">
                            <h2 style="color: #603504;">Employee Type</h2>
                            <asp:Label ID="lblEmpType" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: right;">
                            <h2 style="color: #603504;">Role</h2>
                            <asp:Label ID="lblRole" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: left;">
                            <h2 style="color: #603504;">Joining Date</h2>
                            <asp:Label ID="lblJoinDate" class="lblTop" runat="server"></asp:Label>
                        </div>
                    </div>

                    <div id="divSheduleContainer" style="float: left; width: 100%;">
                        <div id="divErrorNotificationPrcsMlty" style="visibility: hidden">
                            <asp:Label ID="lblErrorNotificationPrcsMlty" runat="server"></asp:Label>
                        </div>
                        <div id="divTableProcessMlty" style="width: 98%; margin: 1%; padding-top: 0.6%; height: 255px;">

                            <table class="TableHeaderProcess" rules="all" style="width: 96%; margin-left: 2%; font-family: calibri;">
                               
                            </table>
                            <div style="max-height: 225px; overflow: auto">
                                <table id="tblImmigrMult" style="width: 97.7%; margin-left: 2%; font-family: calibri; background-color: #f6f6f6;">
                                <thead class="TableHeaderProcess" style="width: 96%; margin-left: 2%; font-family: calibri;">
                                    <tr>
                                        <td style="font-size: 14px; width: 5%; padding-left: 0.5%; text-align: center;">Sl#</td>
                                        <td style="font-size: 14px; width: 25%; padding-left: 0.5%; text-align: left;">Rounds</td>
                                        <td style="font-size: 14px; width: 20%; padding-left: 0.5%; text-align: left;">Status</td>
                                        <td style="font-size: 14px; width: 40%; padding-left: 0.5%; text-align: left;">Assigned To</td>
                                        <td style="font-size: 14px; width: 10%; padding-left: 0.5%; text-align: center;">Target</td>
                                    </tr>
                                </thead>
                                    <tbody>

                                    </tbody>
                                     </table>

                            </div>

                        </div>

                    </div>
                </div>

                <asp:Button ID="btnImmiAsgnMultySave" class="save" runat="server" Text="SAVE" Style="width: 105px; float: left; margin-left: 34%;" OnClientClick="return ValidateProcessMulty()" OnClick="btnImmiAsgnMultySave_Click" />

                <input type="button" id="btnProcessMultyCncl" onclick="ConfirmCancel();" class="save" style="width: 90px; float: left;" value="Cancel" />

            </div>

        </div>
    </div>

    <%-- ----------------for immigration single assignment//-----%>

    <div>
        <div id="MymodalProcessSingle" class="MyModalProcessMultiple">
            <div id="div2">
                <div id="Div3" style="height: 30px; background-color: #6f7b5a;">

                    <label style="margin-left: 38%; font-size: 18px; color: #fff; font-family: calibri;">IMMIGRATION ASSIGNMENT</label>

                    <img class="closeCancelView" style="margin-top: .5%; margin-right: 1%; float: right; cursor: pointer;" onclick="return CloseProcessSingle();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
                </div>
                <div style="float: left; margin: 13px; border: 1px solid; border-color: #d7c9c9; background-color: #fff; margin-bottom: 6px; width: 97%;">

                    <div id="JbShdlTopSingle2" style="width: 91%; float: left; margin-top: .5%; padding: 16px; margin-left: 3%; background-color: #ded2d2;">

                        <div class="eachform" style="width: 47%; float: left;">
                            <h2 style="color: #603504;">Ref.No</h2>
                            <asp:Label ID="lblRefNo2" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: right;">
                            <h2 style="color: #603504;">Employee Id</h2>
                            <asp:Label ID="lblEmpId2" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: left;">
                            <h2 style="color: #603504;">First Name</h2>
                            <asp:Label ID="lblFname2" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: right;">
                            <h2 style="color: #603504;">Designation</h2>
                            <asp:Label ID="lblDesignation2" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: left;">
                            <h2 style="color: #603504;">Employee Type</h2>
                            <asp:Label ID="lblEmpType2" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: right;">
                            <h2 style="color: #603504;">Role</h2>
                            <asp:Label ID="lblRole2" class="lblTop" runat="server"></asp:Label>
                        </div>
                        <div class="eachform" style="width: 47%; float: left;">
                            <h2 style="color: #603504;">Joining Date</h2>
                            <asp:Label ID="lblJoinDate2" class="lblTop" runat="server"></asp:Label>
                        </div>
                    </div>



                    <div id="div5" style="float: left; width: 100%;">
                        <div id="div6" style="visibility: hidden">
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                        </div>
                        <div id="div7" style="width: 98%; margin: 1%; padding-top: 0.6%; height: 270px;">

                            <table class="TableHeaderProcess" rules="all" style="width: 96%; margin-left: 2%; font-family: calibri;">
                               
                            </table>
                            <div style="max-height: 225px; overflow: auto">
                                <table id="tblImmigrSingle" style="width: 97.7%; margin-left: 2%; font-family: calibri; background-color: #f6f6f6;">
                                
                                 <thead class="TableHeaderProcess" style="width: 96%; margin-left: 2%; font-family: calibri;">
                                    <tr>
                                        <td style="font-size: 14px; width: 5%; padding-left: 0.5%; text-align: center;">Sl#</td>
                                        <td style="font-size: 14px; width: 25%; padding-left: 0.5%; text-align: left;">Rounds</td>
                                        <td style="font-size: 14px; width: 20%; padding-left: 0.5%; text-align: left;">Status</td>
                                        <td style="font-size: 14px; width: 30%; padding-left: 0.5%; text-align: left;">Assigned To</td>
                                        <td style="font-size: 14px; width: 10%; padding-left: 0.5%; text-align: center;">Target</td>
                                        <td style="font-size: 14px; width: 5%; padding-left: 0.5%; text-align: center;">Finish</td>
                                        <td style="font-size: 14px; width: 5%; padding-left: 0.5%; text-align: center;">Close</td>
                                    </tr>
                                </thead>
                                    <tbody>

                                    </tbody>

                                </table>

                            </div>

                        </div>

                    </div>
                </div>


                <asp:Button ID="btnImmiAsgnSingleSave" class="save" runat="server" Text="Update" Style="width: 105px; float: left; margin-left: 34%;" OnClientClick="return ValidateProcessSingle()" OnClick="btnImmiAsgnSingleSave_Click" />
                <%--<input type="button" id="btnProcessMultyClr" class="save" style="width: 90px; float: left;" value="Clear" />--%>
                <input type="button" id="btnProcessSingleCancel" onclick="ConfirmCancel();" class="save" style="width: 90px; float: left;" value="Cancel" />

            </div>

        </div>
    </div>


    <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: black; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.8; z-index: 29; height: auto !important;"
        class="freezelayer" id="freezelayer">
    </div>

    <div id="myModalLoadingMail" class="modalLoadingMail">

        <!-- Modal content -->
        <div>

            <img src="/Images/Other Images/LoadingMail.gif" style="width: 12%;" />


        </div>

    </div>



    <style>
        .modalLoadingMail {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 500; /* Sit on top */
            padding-top: 19%; /* Location of the box */
            left: 0;
            top: 0;
            width: 90%; /* Full width */
            /*height: 58%;*/ /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: transparent;
            padding-left: 45%; /* Location of the box */
        }

        .datepicker table tr td, .datepicker table tr th {
            text-align: center;
            width: 0px;
            height: 0px;
            border-radius: 4px;
            border: none;
        }

        .table > thead > tr > th {
            vertical-align: bottom;
            background: #7b7b7b;
            color: #fff;
        }

        .datepicker table tr td.disabled, .datepicker table tr td.disabled:hover {
            background: none;
            color: #c5c5c5;
            cursor: default;
        }

        #tblImmigrSingle > tbody > tr:nth-child(2n+1) > td, .main_table > tbody > tr:nth-child(2n+1) > th {
            height: 30px;
            background: #DDD;
            font-size: 14px;
            color: #5c5c5e;
        }

        #tblImmigrSingle > tbody > tr:nth-child(2n) > td, .main_table > tbody > tr:nth-child(2n) > th {
            height: 30px;
            background: #C2C2C2;
            font-size: 14px;
            color: #000;
        }

        #tblImmigrMult > tbody > tr:nth-child(2n+1) > td, .main_table > tbody > tr:nth-child(2n+1) > th {
            height: 30px;
            background: #DDD;
            font-size: 14px;
            color: #5c5c5e;
        }

        #tblImmigrMult > tbody > tr:nth-child(2n) > td, .main_table > tbody > tr:nth-child(2n) > th {
            height: 30px;
            background: #C2C2C2;
            font-size: 14px;
            color: #000;
        }

        .select2-container--default .select2-selection--multiple .select2-selection__choice {
            background-color: #a5a5a5;
            border-color: #8d8d8d;
            padding: 1px 5px;
            color: #fff;
            font-size: 14px;
            margin: 2px;
            max-width: 260px;
        }

        .select2-container--default .select2-selection--multiple .select2-selection__choice__remove {
            color: #fff;
            cursor: pointer;
            display: inline-block;
            font-weight: bold;
            margin-right: 5px;
        }

        .select2-container--default.select2-container--focus .select2-selection--multiple {
            border: solid #aeaeae 1px;
            outline: 0;
        }

        .select2-results__option[aria-selected] {
            cursor: pointer;
            font-size: small;
            font-family: calibri;
        }

        .TableHeaderProcess {
            background-color: #A4B487;
            color: white;
            font-weight: bold;
            font-family: calibri;
            line-height: 30px;
        }


        .MyModalProcessMultiple {
            display: none;
            position: fixed;
            z-index: 100;
            padding-top: 0%;
            left: 8%;
            top: 15%;
            width: 84%;
            height: 80%;
            overflow: auto;
            background-color: white;
            border: 3px solid;
            border-color: #6f7b5a;
        }


        .cont_rght {
            width: 97%;
        }

        .save {
            width: 100%;
        }

        input[type="radio"] {
            display: table-cell;
        }

        .cont_rght {
            width: 100%;
            padding-top: 1%;
        }

        .lblTop {
            width: 232px;
            padding: 0px 8px;
            float: right;
            color: #000;
            font-size: 14px;
            font-family: calibri;
            word-wrap: break-word;
        }

        .eachform {
            width: 100%;
            display: inline-block;
            margin: 0 0 5px;
        }
    </style>


</asp:Content>

