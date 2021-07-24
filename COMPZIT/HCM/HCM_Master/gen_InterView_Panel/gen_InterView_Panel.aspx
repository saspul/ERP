<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_InterView_Panel.aspx.cs" Inherits="HCM_HCM_Master_gen_InterView_Panel_gen_InterView_Panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script src="/JavaScript/jquery-1.8.3.min.js"></script>

    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
   
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            document.getElementById("<%=hiddenWindowCount.ClientID%>").value = "0";
             //localStorage.clear();
         });
    </script>
    <script>
  
        var $NonCon = jQuery.noConflict();
        function openPanel(Id, name) {
            document.getElementById("<%=hiddenTemplateDetailId.ClientID%>").value = Id;

            var windowcount = document.getElementById("<%=hiddenWindowCount.ClientID%>").value;
            if (windowcount == "0") {
                document.getElementById('TemplateDetailName').innerHTML = name;

                document.getElementById('divPanelFull').style.display = "block";

                var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
                var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
                var ReqstId = document.getElementById("<%=hiddenManPwrRqstId.ClientID%>").value;
                var PanelId = document.getElementById("<%=hiddenInterViewPanelId.ClientID%>").value; 
                if (PanelId != "0") {
                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "gen_InterView_Panel.aspx/ReadInterViewPanel",
                        data: '{intCorpId: "' + CorpId + '",intOrgId: "' + OrgId + '" ,PanelId: "' + PanelId + '",TempDetail: "' + Id + '"}',
                        dataType: "json",
                        success: function (data) {

                      
                            if (data.d != '' && data.d != null&&data.d != "[]") { 

                                var EditValDayWise = data.d;
                                if (EditValDayWise != "") {

                                    var find2 = '\\"\\[';
                                    var re2 = new RegExp(find2, 'g');
                                    var res2 = EditValDayWise.replace(re2, '\[');

                                    var find3 = '\\]\\"';
                                    var re3 = new RegExp(find3, 'g');
                                    var res3 = res2.replace(re3, '\]');
                                    //   alert('res3' + res3);
                                    var json = $noCon.parseJSON(res3);
                                    
                                    for (var key in json) {
                                        if (json.hasOwnProperty(key)) {
                                            if (json[key].PANELDTLID != "") {
                                                editMoreRows(json[key].PANELEMPID, json[key].ISDEFAULT,json[key].PANELDTLID);

                                            }
                                        }
                                    }
                                    CheckAddEachRowLoad();
                                }
                                //addMoreRows();

                                newCount = 0;
                                for (var EnCount = rowCount; EnCount > 0; EnCount--) {
                                    var AddButton = $noconfli("#FileIndvlAddMoreRow_" + EnCount);
                      
                                    if (AddButton.length) {
                                        newCount++;
                                        document.getElementById("inputAddRow_" + EnCount).disabled = false;
                                        document.getElementById("inputAddRow_" + EnCount).style.opacity = "1";
                                        break;
                                    }
                                }




                                
                            }
                            else {
                            
                                addMoreRows();
                                document.getElementById("chkbxDflt_" + 1).checked = true;

                              
                            }

                        }
                    });
                }
                else {
                    addMoreRows();

                    document.getElementById("chkbxDflt_" + 1).checked = true;
                }

                document.getElementById("<%=hiddenWindowCount.ClientID%>").value = "1";
            }
            else {
                alert("please close the current window");
            }
            
        }


        function CloseWindow() {
            if (confirmbox == 0) {
                document.getElementById('divPanelFull').style.display = "none";
                jQuery('#TableEachPanel tr').remove();
                document.getElementById("<%=hiddenWindowCount.ClientID%>").value = "0";
                InitializeCount();
                //localStorage.clear();
            }
            else {
                if (confirm("Are you sure.You want to close the window?")) {
                    document.getElementById('divPanelFull').style.display = "none";
                    jQuery('#TableEachPanel tr').remove();
                    document.getElementById("<%=hiddenWindowCount.ClientID%>").value = "0";
                InitializeCount();
                //localStorage.clear();
                }
            }
        }
        function ClearDataAll() {

            if (confirmbox == 0) {

                jQuery('#TableEachPanel tr').remove();
                InitializeCount();
                //localStorage.clear();
                addMoreRows();
                document.getElementById("chkbxDflt_" + 1).checked = true;
            }
            else {
                if (confirm("Are you sure you want to clear all data?")) {
                    jQuery('#TableEachPanel tr').remove();
                    InitializeCount();
                    //localStorage.clear();
                    addMoreRows();
                    document.getElementById("chkbxDflt_" + 1).checked = true;
                }
                else {
                    return false;
                }
            }
            
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
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        function ConfirmMessage() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href = "gen_InterView_Panel_List.aspx";
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_InterView_Panel_List.aspx";

            }
        }
        function SuccessConfirmation() {

            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Interview panel added sucessfully.";
        }  
    </script>


     <script language="javascript" type="text/javascript">
         var $noC = jQuery.noConflict();
        
         var rowCount = 0;
         var RowIndex = 0;
         var editCount = 0;
         var DeleteCount = 0;
         function InitializeCount() {
             rowCount = 0;
             RowIndex = 0;
             editCount = 0;
         }


         function addMoreRows() {
             rowCount++;
             RowIndex++;

             var recRow = '<tr id="rowId_' + rowCount + '" >';
             recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
             recRow += '<td style="width: 8%;text-align: center;border: 1px solid #048621;"><div id="divSlNum' + rowCount + '" style=" background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex + ' </div></td>';

             recRow += ' <td id="tdEmp' + rowCount + '" style="width: 62%;border: 1px solid #048621;"><div id="divCls' + rowCount + '">';
             recRow += ' <select  id="ddlEmployee_' + rowCount + '" onblur=\"BlurTextvalue(\'' + rowCount + '\');\" onchange=\"ChangeEntry(\'' + rowCount + '\');\" style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 92%;margin-left: 0.1%;" class="form1" /> ';
             recRow += ' </div> </td> ';

             recRow += ' <td style="width: 18%;border: 1px solid #048621;background-color:white;"><div style=><input  id="chkbxDflt_' + rowCount + '" class="form1" onchange=\"ChangeEntry(\'' + rowCount + '\');\"  type="radio" name="CheckList" style="text-align: right; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 89%;margin-left: -11.1%;"/></td>';

             recRow += '<td id="FileIndvlAddMoreRow_' + rowCount + '" style="width: 6%; padding-left: 4px;"> <input id="inputAddRow_' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckAddEachRow(' + rowCount + ');" title="ADD" style="  cursor: pointer;"></td>';
             recRow += '<td style="width: 6%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return CheckDelEachRow(' + rowCount + ',\'Are you sure you want to Delete this Entry?\');" title="DELETE"   style=" cursor: pointer;" ></td>';


             recRow += '<td id="FileInx_' + rowCount + '" style="display: none;" > </td>';
             recRow += '<td id="FileSave_' + rowCount + '" style="display: none;"> </td>';
             recRow += '<td id="FileEvt_' + rowCount + '" style="display: none;">INS</td>';
             recRow += '<td id="FileDtlId_' + rowCount + '" style="display: none;"></td>';



             recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
             recRow += '</tr>';

             // to append
             jQuery('#TableEachPanel').append(recRow);
             FillEmployeeDdl(rowCount);


         }
         function editMoreRows(empId, dfltSts, PanelDtl) {

             editCount++;
             
             rowCount++;
             RowIndex++;

             var recRow = '<tr id="rowId_' + rowCount + '" >';
             recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
             recRow += '<td style="width: 8%;text-align: center;border: 1px solid #dbd8d8;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';

             recRow += ' <td id="tdEmp' + rowCount + '" style="width: 62%;border: 1px solid #dbd8d8;"><div id="divCls' + rowCount + '">';
             recRow += ' <select  id="ddlEmployee_' + rowCount + '" onblur=\"BlurTextvalue(\'' + rowCount + '\');\" onchange=\"ChangeEntry(\'' + rowCount + '\');\" style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 92%;margin-left: 0.1%;" class="form1" /> ';
             recRow += ' </div> </td> ';


             recRow += ' <td style="width: 18%;border: 1px solid rgb(207, 204, 204);background-color:white;"><div style=><input  id="chkbxDflt_' + rowCount + '" class="form1" onchange=\"ChangeEntry(\'' + rowCount + '\');\"  type="radio"  name="CheckList"  style="text-align: right; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 89%;margin-left: -11.1%;"/></td>';

             recRow += '<td id="FileIndvlAddMoreRow_' + rowCount + '" style="width: 6%; padding-left: 4px;"> <input id="inputAddRow_' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckAddEachRow(' + rowCount + ');" title="ADD" style="  cursor: pointer;"></td>';
             recRow += '<td style="width: 6%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return CheckDelEachRow(' + rowCount + ',\'Are you sure you want to Delete this Entry?\');" title="DELETE"   style=" cursor: pointer;" ></td>';


             recRow += '<td id="FileInx_' + rowCount + '" style="display: none;" > </td>';
             recRow += '<td id="FileSave_' + rowCount + '" style="display: none;"> </td>';
             recRow += '<td id="FileEvt_' + rowCount + '" style="display: none;">UPD</td>';
             recRow += '<td id="FileDtlId_' + rowCount + '" style="display: none;">' + PanelDtl + '</td>';



             recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
             recRow += '</tr>';

             // to append
             jQuery('#TableEachPanel').append(recRow);
             FillEmployeeDdl(rowCount);
             var selectObj = document.getElementById("ddlEmployee_" + rowCount);
             for (var i = 0; i < selectObj.options.length; i++) {

                
                 if (selectObj.options[i].value == empId) {
                     selectObj.options[i].selected = true;

                     //var a = $noC("#cphMain_ddlTimeSlot_DayWise option:selected").text();
                     //$noC("div#divTimeSlotDayWise input.ui-autocomplete-input").val(a);

                     //check1
                     //alert(ddlEmployee_);
                     //alert(rowCount);
                     var a = $noC("#ddlEmployee_" + rowCount + " option:selected").text();
                     
                     $noC("div#divCls" + rowCount + " input.ui-autocomplete-input").val(a);
                     
                 }
             }

             document.getElementById("<%=hiddenEmployeeSelectedValues.ClientID%>").value = empId+","+document.getElementById("<%=hiddenEmployeeSelectedValues.ClientID%>").value;

             if (dfltSts == "1") {
                 document.getElementById("chkbxDflt_" + rowCount).checked = true;

             }


             document.getElementById("inputAddRow_" + rowCount).style.opacity = "0.3";
             document.getElementById("inputAddRow_" + rowCount).disabled = true;
         }


         function FillEmployeeDdl(rowCount) {
             var ddlTestDropDownListXML = $noC("#ddlEmployee_" + rowCount);
             // Provide Some Table name to pass to the WebMethod as a paramter.
             var tableName = "dtTableEmployee";
             if (document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value != 0) {
                ddlEmpdata = document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value;
                 var OptionStart = $noC("<option>--SELECT EMPLOYEE--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);
                // Now find the Table from response and loop through each item (row).
                $noC(ddlEmpdata).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noC(this).find('USR_ID').text();
                    var OptionText = $noC(this).find('USR_NAME').text();
                    // Create an Option for DropDownList.
                    var option = $noC("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    ddlTestDropDownListXML.append(option);
                });
                 //check1
                $noC("#ddlEmployee_" + rowCount).selectToAutocomplete1Letter();
            }

            else {
                var IntCorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
                var IntOrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
                 $noC.ajax({
                    type: "POST",
                    url: "gen_InterView_Panel.aspx/DropdownEmployeeBind",
                    data: '{tableName:"' + tableName + '",CorpId:"' + IntCorpId + '",OrgId:"' + IntOrgId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $noC("<option>--SELECT EMPLOYEE--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);
                        // Now find the Table from response and loop through each item (row).
                        $noC(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noC(this).find('USR_ID').text();
                            var OptionText = $noC(this).find('USR_NAME').text();
                            // Create an Option for DropDownList.
                            var option = $noC("<option>" + OptionText + "</option>");
                            option.attr("value", OptionValue);

                            ddlTestDropDownListXML.append(option);
                        });



                    },
                    failure: function (response) {

                    }
                 });
                 //check1
                 $noC("#ddlEmployee_" + rowCount).selectToAutocomplete1Letter();
            }
        }


 

         function CheckEachDdl(x) {
             IncrmntConfrmCounter();
             if (document.getElementById("ddlEmployee_" + x).value == 0) {
                 return false;
             }
             else {
                 return true;
             }
         }


         //function removeRow(removeNum) {
         //    if (confirm("Are you Sure you want to Delete?")) {
    
         //        if (document.getElementById("chkbxDflt_" + removeNum).checked == true) {
         //            if (removeNum != rowCount) {
         //                document.getElementById("chkbxDflt_" + rowCount).checked = true;
         //            }
         //            else {
                        
         //                for (var CCcount = rowCount; CCcount--;) {
         //                    if (document.getElementById("chkbxDflt_" + CCcount) != null) {
         //                        document.getElementById("chkbxDflt_" + CCcount).checked = true;
         //                        break;
         //                    }
         //                }
         //            }
         //            ChangeEntry(rowCount);
         //        }

         //        var Filerow_index = jQuery('#rowId_' + removeNum).index();
         //        //FileLocalStorageDelete(Filerow_index,removeNum);
         //        jQuery('#rowId_' + removeNum).remove();

    

         //        var TableFileRowCount = document.getElementById("TableEachPanel" ).rows.length;

         //        if (TableFileRowCount != 0) {
         //            var idlast = $noC('#TableEachPanel tr:last').attr('id');
          
         //            if (idlast != "") {
         //                var res = idlast.split("_"); 
                     
         //                document.getElementById("FileInx_" + res[1]).innerHTML = " ";
         //                document.getElementById("FileIndvlAddMoreRow_" + res[1]).style.opacity = "1";
         //                document.getElementById("inputAddRow_" + res[1]).disabled = false; 
         //            }


                     
         //        }
         //        else {
                    
         //            addMoreRows();
         //            document.getElementById("chkbxDflt_" + rowCount).checked = true;
         //            ChangeEntry(rowCount);
         //        }


         //        ReNumberTable();
         //    }
         //    else {

         //        return false;
         //    }
         //}
         function ChangeEntry(x) {
             return false;
             IncrmntConfrmCounter();

             var DropDownValue = document.getElementById("ddlEmployee_" + x).value;

                // CompareAPTNames(rowCount);
                 document.getElementById("ddlEmployee_" + x).value = "0";
                 document.getElementById("ddlEmployee_" + x).style.borderColor = "red";
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry.Employee name dupl455icated";
    
         }

         function ErrMsg() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = " Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
        }


         //new
         //evm-0023 Add Functions instead of local storage
         //Seriel Number Re numbering when add,delete 
         function ReNumberTable() {
             var table = "";


             table = document.getElementById("TableEachPanel");

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
                          
                         }
                     }


                 }
             }
         }
         //Add Rows When clicking - img add button
         var $noconfli = jQuery.noConflict();
         function CheckAddEachRow(CurrRow) {
             if (document.getElementById("ddlEmployee_" + CurrRow).value != "0") {
                 
                 
                 addMoreRows();
                 //alert();
                 CompareAPTNames(CurrRow);
                 
                 for (var DisCount = 1; DisCount < rowCount; DisCount++) {

                     var AddButton = $noconfli("#FileIndvlAddMoreRow_" + DisCount);
                     if (AddButton.length) {
                         document.getElementById("inputAddRow_" + DisCount).disabled = true;
                         document.getElementById("inputAddRow_" + DisCount).style.opacity = "0.3";
                     }
                 }
                 ReNumberTable();
                 
             }
             return false;
         }

         //Add rows Load 
         function CheckAddEachRowLoad() {
             
             for (var DisCount = 1; DisCount < rowCount; DisCount++) {
                
                 
                 var AddButton = $noconfli("#FileIndvlAddMoreRow_" + DisCount);
                 if (AddButton.length) {
                     document.getElementById("inputAddRow_" + DisCount).disabled = true;
                     document.getElementById("inputAddRow_" + DisCount).style.opacity = "0.3";
                     
                 }
                 
             }
             
             return false;
         }

         //var stsCheck = false;
         //alert("a");
         //if (document.getElementById('chkbxDflt_' + Delrowcount).checked == true) {
         //    stsCheck = true;
         //    if (stsCheck == true) {
         //        document.getElementById('chkbxDflt_' + EnCount).checked = true;

         //    }
         //}
         function CheckDelEachRow(Delrowcount) {
             
                 var newCount = 0;
                 if (confirm("Are you sure?. You want to remove.")) {
             

                         document.getElementById('divMessageArea').style.display = "";
                         document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                         document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Interview panel deleted sucessfully.";

                     AddDeleted(Delrowcount);

                     //var stsCheck = false;
                     //if (document.getElementById('chkbxDflt_' + EnCount).checked == false) {
                     //    document.getElementById('chkbxDflt_' + EnCount).checked = true;
                     //}
                     if (document.getElementById('chkbxDflt_' + Delrowcount).checked == true)
                     {
                         stsCheck = true;
                     }

                     jQuery('#rowId_' + Delrowcount).remove();
                     ReNumberTable(); 
                     for (var EnCount = rowCount; EnCount > 0; EnCount--) {
            
                         var AddButton = $noconfli("#FileIndvlAddMoreRow_" + EnCount);
                         if (AddButton.length) {
                             newCount++;
                             document.getElementById("inputAddRow_" + EnCount).disabled = false;
                             document.getElementById("inputAddRow_" + EnCount).style.opacity = "1";
                           
                             if (stsCheck == true) {
                                 document.getElementById('chkbxDflt_' + EnCount).checked = true;
                             }
                             break;
                         }
                     }
                     if (newCount == 0) {
                           
                         addMoreRows();
                         
                         ReNumberTable();
                         document.getElementById('chkbxDflt_' + rowCount).checked = true;
                     }
                 }
                 return false;
             }

             //
         function AddDeleted(Delrowcount) {

                 if (document.getElementById("FileEvt_" + Delrowcount).innerHTML == "UPD") {
                     var detailId = document.getElementById("<%=hiddenPanelDetailDelete.ClientID%>").value;
                     detailId = detailId + "," + document.getElementById("FileDtlId_" + Delrowcount).innerHTML;
                document.getElementById("<%=hiddenPanelDetailDelete.ClientID%>").value = detailId;
            }

             }

             function BlurTextvalue(count)
             {
                 var NameWithoutReplace = document.getElementById("ddlEmployee_" + count).value;
                 var replaceText1 = NameWithoutReplace.replace(/</g, "");
                 var replaceText2 = replaceText1.replace(/>/g, "");
                 document.getElementById("ddlEmployee_" + count).value = replaceText2;
                 CompareAPTNames(count);
             }

             function CompareAPTNames(x) {
                 var tableNameCh = document.getElementById("TableEachPanel");

                 ChAptName = document.getElementById("ddlEmployee_" + x).value;
                 ChAptName = ChAptName.toUpperCase();
                 if (tableNameCh.rows.length >= 1) {
                     for (var i = 0; i < tableNameCh.rows.length; i++) {

                         // FIX THIS
                         var row = tableNameCh.rows[i];

                         var xLoop = (tableNameCh.rows[i].cells[0].innerHTML);
                         if (xLoop != x) {
                             var txtName = document.getElementById("ddlEmployee_" + xLoop).value;
                             txtName = txtName.toUpperCase();
                             document.getElementById("ddlEmployee_" + xLoop).value = "";

                                 
                             if (txtName == ChAptName) {
                                 alert("Duplication not allowed in employees name");
                                 document.getElementById("ddlEmployee_" + x).value = "0";
                                 document.getElementById("ddlEmployee_" + x).style.borderColor = "red";
                                 document.getElementById('divMessageArea').style.display = "";
                                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                                 alert("aa");
                                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry.Employee name duplicated2";
       
                             }
                         }

                     }
                 }
                 return false;
             }


         //newClosed


         function Validate() {

             document.getElementById('divMessageArea').style.display = "none";

             //var Totalstring = localStorage.getItem("tbClientInterViewPanel");
             //tbClientTemplateUpload = JSON.parse(Totalstring);
             //document.getElementById("<%=hiddenTotalDetailOfPanel.ClientID%>").value = Totalstring;

             
             for (var count = 1; count <= rowCount; count++) {
                 var AddButton = $noconfli("#ddlEmployee_" + count);
                 if (AddButton.length) {
                     if (document.getElementById("ddlEmployee_" + count).value == "") {
                         document.getElementById("ddlEmployee_" + count).style.borderColor = "red";
                         document.getElementById("ddlEmployee_" + count).focus();
                         ErrMsg();
                         ret = false;
                     }
                 }
             }
            

             var ret = true;
             if (CheckIsRepeat() == true) {
             }
             else {
                 ret = false;
                 return ret;
             }



             if (ret == true) {

                 var tbClientTotalValues = '';
                 tbClientTotalValues = [];

                 for (var counting = 1; counting <= rowCount; counting++) {

                     var $add = jQuery.noConflict();
                     if ($add("#chkbxDflt_" + counting).length) {
                         var cbValue = 0;
                        
                         if ($add("#chkbxDflt_" + counting).is(":checked") == true) {

                             // it is checked
                             cbValue = 1;
                         }
                         var detailId = document.getElementById("FileDtlId_" + counting).innerHTML;
                         var evt = document.getElementById("FileEvt_" + counting).innerHTML;

                         var client = JSON.stringify({
                             ROWID: "" + counting + "",
                             DDLVALUE: $add("#ddlEmployee_" + counting).val(),
                             CHKBXVALUE: "" + cbValue + "",
                             EVTACTION: "" + evt + "",
                             DTLID: "" + detailId + "",
                         });

                         tbClientTotalValues.push(client);
                     }
                 }

                 document.getElementById("<%=hiddenTotalDetailOfPanel.ClientID%>").value = JSON.stringify(tbClientTotalValues);

             }



                 if (tbClientTotalValues == null || tbClientTotalValues == "[]") {
                     document.getElementById('divMessageArea').style.display = "";
                     document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                     document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please select atleast one default employee to continue.";
                     ret = false;

                 }
           

             var Cbx = true;
             
             for (var i = 0; i <= rowCount; i++) {
           
                 if (document.getElementById('chkbxDflt_' + i) != null)
                     if (document.getElementById('chkbxDflt_' + i).checked == true) {
                         
                         if (document.getElementById('ddlEmployee_' + i).value == "0") {
                             Cbx = false;
                             break;
                         }
                     }

             }
             

             if (Cbx==false)
             {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please select atleast one default employee to continue.";
               
                 ret = false;
             }

             if (ret == false) {
                 CheckSubmitZero();

             }
             else {
                 document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value = "0";
                // alert(document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value);
             }
             return ret;
         }
      
       
          </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    
     <asp:HiddenField ID="hiddenEmployeeDdlData" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenCorporateId" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenOrganisationId" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenInterViewPanelId" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenManPwrRqstId" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenWindowCount" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenPanelDetailDelete" runat="server"/>
  <asp:HiddenField ID="hiddenTotalDetailOfPanel" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenTemplateId" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenTemplateDetailId" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenEmployeeSelectedValues" runat="server" Value="0" />
    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 0%; top: 42%; height: 26.5px;">
    </div>
    <div class="cont_rght">



        <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke; float: left">
            <div id="divReportCaption" style="width: 100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; float: left">
                <asp:Label ID="lblEntry" runat="server">Interview Panel</asp:Label>
            </div>

            <div style="float: left; width: 98%; padding: 10px; margin-top: 2%; border: 1px solid #929292; background-color: #c9c9c9;">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Ref#</h2>
                    <asp:Label ID="lblRefNum" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Date Of Request</h2>
                    <asp:Label ID="lblDateOfReq" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">No.Of Resources</h2>
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

            <div style="float: left; width: 62%; margin-top: 3%;">

                <div id="divTemplateDetail" class="table-responsive" runat="server">
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
            </div>

            <div id="divPanelFull" style="float: right; width: 35%; margin-top: 3%;background-color: #ffe1c4;padding: 10px;display:none;">

                 <h2 id="TemplateDetailName" style="font-size: 17px;color: #9c4e01;" >
                    
                  </h2>

                <div style="float:left;width: 100%;background-color: white;">
                   
                 <table class="TableHeader" rules="all" style="width: 83%;">
                        <tr>
                           
                            <td style="font-size: 14px; width: 10%; padding-left: 0.5%; text-align: left;">SL#</td>
                            <td style="font-size: 14px; width:70%; padding-left: 0.5%; text-align: left;">EMPLOYEE</td>
                            <td style="font-size: 14px; width: 20%; padding-left: 0.5%; text-align: left;">DEFAULT</td>

                        </tr>
                    </table>
                <div style="width: 100%; min-height: 75px; overflow-y: auto;">
                    <div id="divPanelContainer" runat="server">
                        <table id="TableEachPanel" style="width: 98%;">
                        </table>
                    </div>

                </div>
                    </div>
                 <div style="float:left;width: 75%;padding: 5px;margin-left: 9%;margin-top: 5%;">

                     <asp:Button ID="btnSend"  runat="server" class="save" Text="Save" OnClientClick="return Validate();" OnClick="btnSend_Click"/>
                    <input type="button" id="btnClear"  class="save" value="clear" style="display:none" onclick="return ClearDataAll();"/>
                    <input type="button" id="btnCancel"  class="save" value="close"  onclick="return CloseWindow();"/>
       
                </div>


            </div>
        </div>

    </div>
    <style>
        .cont_rght {
            width: 97%;
        }

        .save {
            width: 27%;
        }

        .lblTop {
            width: 320px;
            padding: 0px 8px;
            border: 1px solid #cfcccc;
            float: right;
            color: #000;
            font-size: 14px;
            font-family: calibri;
            word-wrap: break-word;
        }
          .TableHeader {
            background-color: #A4B487;
            color: white;
            font-weight: bold;
            font-family: calibri;
            line-height: 15px;
        }

          input[type="radio"] {
    display: block;

}
   
           </style>

         <style type="text/css">
       
              .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            /*width: 52.6%;*/
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

   


</asp:Content>

