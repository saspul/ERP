<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Duty_Roster.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Duty_Roster_gen_Duty_Roster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <%--auto completion files--%>

    <script type="text/javascript" src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script type="text/javascript" src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script type="text/javascript" src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link rel="stylesheet" href="/css/Autocomplete/jquery-ui.css" />

    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

   
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
    <style>
#divErrorNotificationDW {
    border-radius: 8px;
    background: #fff;
    padding: 0px;
    font-weight: bold;
    text-align: center;
    font-size: 15px;
    color: #53844E;
    margin-top: -0.5%;
    font-family: Calibri;
    border: 1px solid #53844E;
    width: 72%;
    margin-left: 14%;
}

         #divErrorNotificationSb {
   border-radius: 8px;
background: #fff;
padding: 0px;
font-weight: bold;
text-align: center;
font-size: 17px;
color: #53844E;
margin-top: 4.5%;
font-family: Calibri;
border: 2px solid #53844E;
width: 99%;
margin-bottom: 2%;
}
table {
    border-collapse: collapse;
    width: 100%;
}

th, td {
    text-align: left;
    padding: 8px;
}

.EmpTabCls tr:nth-child(even){background-color: #d6e4e7}
</style>
        <style>
        .fillform {
            width: 100%;
        }

        .subform {
            float: left;
            margin-left: 38.8%;
        }

        .leads_field:focus {
            box-shadow: 0px 0px 4px 2.5px #bbf2cf;
            border: 1px solid #bbf2cf;
        }

        .BillngEntryField:focus {
            box-shadow: 0px 0px 3px 2px #bbf2cf;
            border: 0px solid #bbf2cf;
        }

        .BillngEntryFieldCopy:focus {
            box-shadow: 0px 0px 3px 2px #bbf2cf;
          
        }

        .leads_form {
            font-family: Calibri;
            padding-bottom: 2%;
            overflow-x: auto;
            background: #f4f6f0;
            margin: 0 0 5px;
        }

        .leads_field_txtarea2 {
            width: 99.5% !important;
            resize: none;
        }

        .leads_des {
            margin: 0% 1.5% 0.5%;
            width: 96%;
        }

        .leads_form_right {
         
        }

        .leads_form_left {
          
        }

        input[type="radio"] {
            display: inline;
            cursor: pointer;
        }

            input[type="radio"]:hover, input[type="radio"]:focus {
                box-shadow: 0px 0px 4px 2.5px #bbf2cf;
                border: 1px solid #bbf2cf;
            }

        .leads_field {
            height: 25px;
            font-family: calibri;
            font-size: 15px;
        }

        .leads_name {
            width: 296px !important;
        }

        .leads_form h3 {
            font-size: 15px;
        }

        .cont_rght {
            width: 99.5%;
            padding-top :0.5% !important;
        }

            .cont_rght h2 {
                float: none;
                color: rgb(83, 101, 51);
                margin: 0 0 0px;
                font-size: 17px;
            }
           .ui-autocomplete {
          
            max-width:32% !important;
            max-height: 190px !important;
        }
       .TimeEntry .ui-autocomplete {
      
            max-height: 190px !important;
        }
    </style>

    <style type="text/css">
        .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
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
  



      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          //var $noConauto = jQuery.noConflict();
          $noCon(window).load(function () {

              localStorage.clear();
          

              $('#cphMain_ddlTimeSlot_DayWise').selectToAutocomplete1Letter();
              $('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
              document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value = "";
              document.getElementById("<%=HiddenFieldCancelAddtnJobDtlId.ClientID%>").value = "";
              document.getElementById("freezelayer").style.display = "none";
              $("body").css('overflow', 'auto');

              document.getElementById("myModalLoadingMail").style.display = "none";
          });


          </script>
     <script>
         var rowCountVeh = 0;

         function InitializeVehi() {
             rowCountVeh = 0;
         }
         function EditVehicleRows(VehId, VehNum, VehMileg) {
             rowCountVeh++;

             var recRow = '<tr id="rowId_' + rowCountVeh + '" style=\"font-size: 14px;font-family: calibri;\" >';
             recRow += '<td id="tdId' + rowCountVeh + '" style="display: none;">' + VehId.toString() + '</td>';
             recRow += '<td style="width: 4.8%;text-align: center;"><div id="divSlNum' + rowCountVeh + '" style="background-color: rgb(108, 108, 108); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -3%;" >' + rowCountVeh.toString() + ' </div></td>';
             recRow += '<td style="width: 65%;word-break: break-all;border-left: 1px solid;">' + VehNum.toString() + ' </td>';
             recRow += '<td style="width: 30%;word-break: break-all;border-left: 1px solid;">' + VehMileg.toString() + '</td>';
             recRow += '</tr>'

             jQuery('#TableVehicle').append(recRow);
         }
    </script>
    <script type="text/javascript">



        var $noC = jQuery.noConflict();
        var rowCount = 0;
        //rowCount for uniquness
        //row index add(+) and (-)delete count based on action
        var RowIndex = 0;


        function addMoreRows(frm, boolFocus, JobMode, boolAppendorNot, row_index, TableName) {

            rowCount++;
            RowIndex++;

            document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


        var recRow = '<tr id="rowId_' + rowCount + '" >';
        recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
        recRow += '<td style="width: 3.2%;text-align: center;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -3%;" >' + RowIndex.toString() + ' </div></td>';
        if (JobMode == 1) {
            recRow += ' <td id="tdJobSelect' + rowCount + '" style="width: 19.9%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 100%;" id="txtselectorJob' + rowCount + '" class="BillngEntryField" type="text"  value="--Select Job--"  onkeypress="return isTagName(\'txtselectorJob' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return ChangeJobMode(\'txtselectorJob\',' + rowCount + ',\'' + TableName + '\', event)"   onblur="return BlurJSJobVhclPrjct(\'txtselectorJob\',' + rowCount + ',\'Job\',\'' + TableName + '\')" onfocus="return FocusJSValue(\'txtselectorJob\',' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' <td  style="display: none;"><input id="txtselectorJobId' + rowCount + '"  value="--Select Job--" type="text"   /></td>';
            recRow += ' <td  style="display: none;"><input id="txtselectorJobName' + rowCount + '"  value="--Select Job--" type="text" maxlength=100  /></td>';

        }
        else if (JobMode == 2) {


            recRow += ' <td id="tdJobText' + rowCount + '"  style="width: 19.9%;">';
            recRow += ' <input id="txtJob' + rowCount + '"  class="BillngEntryField"  type="text" onkeypress="return isTagName(\'txtJob' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)" onkeydown="return ChangeJobMode(\'txtJob\',' + rowCount + ',\'' + TableName + '\', event)"    onblur="return BlurJSTXTJob(\'txtJob\',' + rowCount + ',\'' + TableName + '\')" onfocus="FocusTXTJob(\'txtJob\',' + rowCount + ',event)" maxlength=100 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%; background-color: rgb(231, 255, 185);"/>';
            recRow += '   </td> ';
        }

        recRow += ' <td id="tdVhclSelect' + rowCount + '" style="width: 19%;"><div class="Cls' + rowCount + '">';
        recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 100%;margin-left: 0.1%;" id="txtselectorVhcl' + rowCount + '" class="BillngEntryField" type="text"  value="--Select Vehicle--" onkeydown="return  DisableEnter(event);" onkeypress="return isTagName(\'txtselectorVhcl' + rowCount + '\',\'txtselectorPrjct' + rowCount + '\',' + rowCount + ', event)"     onblur="return BlurJSJobVhclPrjct(\'txtselectorVhcl\',' + rowCount + ',\'Vehicle\',\'' + TableName + '\')" onfocus="return FocusJSValue(\'txtselectorVhcl\',' + rowCount + ',event)"  maxlength=100 /> ';
        recRow += ' </div> </td> ';
        recRow += ' <td  style="display: none;"><input id="txtselectorVhclId' + rowCount + '"  value="--Select Vehicle--" type="text"   /></td>';
        recRow += ' <td  style="display: none;"><input id="txtselectorVhclName' + rowCount + '"  value="--Select Vehicle--" type="text" maxlength=100  /></td>';

        recRow += ' <td id="tdPrjctSelect' + rowCount + '" style="width: 19%;"><div class="Cls' + rowCount + '">';
        recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 97.8%;margin-left: 0.1%;" id="txtselectorPrjct' + rowCount + '" class="BillngEntryField" type="text"  value="--Select Project--"  onkeypress="return isTagName(\'txtselectorPrjct' + rowCount + '\',\'txtselectorFrmTime' + rowCount + '\',' + rowCount + ', event)"   onkeydown="return  DisableEnter(event);"  onblur="return BlurJSJobVhclPrjct(\'txtselectorPrjct\',' + rowCount + ',\'Project\',\'' + TableName + '\')" onfocus="return FocusJSValue(\'txtselectorPrjct\',' + rowCount + ',event)"  maxlength=100 /> ';
        recRow += ' </div> </td> ';
        recRow += ' <td  style="display: none;"><input id="txtselectorPrjctId' + rowCount + '"  value="--Select Project--" type="text"   /></td>';
        recRow += ' <td  style="display: none;"><input id="txtselectorPrjctName' + rowCount + '"  value="--Select Project--" type="text" maxlength=100  /></td>';


        recRow += ' <td id="tdFrmTimeSelect' + rowCount + '" style="width: 10%;"><div class="Cls' + rowCount + '">';
        recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtselectorFrmTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text"  value="--Select Time--"  onkeypress="return isTagName(\'txtselectorFrmTime' + rowCount + '\',\'txtselectorToTime' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return  DisableEnter(event);"   onblur="return BlurJSTimeSHDL(\'txtselectorFrmTime\',' + rowCount + ',\'Time\',\'' + TableName + '\')" onfocus="return FocusJSTime(\'txtselectorFrmTime\',' + rowCount + ',event)"  maxlength=100 /> ';
        recRow += ' </div> </td> ';
        recRow += ' <td  style="display: none;"><input id="txtselectorFrmTimeId' + rowCount + '"  value="--Select Time--" type="text" maxlength=100  /></td>';

        recRow += ' <td id="tdToTimeSelect' + rowCount + '" style="width: 10%;"><div class="Cls' + rowCount + '">';
        recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtselectorToTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text"  value="--Select Time--"  onkeypress="return isTagName(\'txtselectorToTime' + rowCount + '\',\'tdIndvlAddMoreRowPic' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return  DisableEnter(event);"   onblur="return BlurJSTimeSHDL(\'txtselectorToTime\',' + rowCount + ',\'Time\',\'' + TableName + '\')" onfocus="return FocusJSTime(\'txtselectorToTime\',' + rowCount + ',event)"  maxlength=100 /> ';
        recRow += ' </div> </td> ';
        recRow += ' <td  style="display: none;"><input id="txtselectorToTimeId' + rowCount + '"  value="--Select Time--" type="text" maxlength=100  /></td>';




        recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividualschdl(' + rowCount + ',true,\'' + TableName + '\',false);"  style="  cursor: pointer;"></td>';
        recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to Delete this Entry?\',true,\'' + TableName + '\');"    style=" cursor: pointer;" ></td>';

        recRow += ' <td id="tdDutyOrJobShdl' + rowCount + '" style="display: none;" >JOBSHDL</td>';
        recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
        recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
        recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">INS</td>';
        recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;"></td>';
            
        if (JobMode == 1) {
            recRow += '<td id="tdJobMode' + rowCount + '" style="display: none;">1</td>';
        }
        else if (JobMode == 2) {
            recRow += '<td id="tdJobMode' + rowCount + '" style="display: none;">2</td>';
        }

        recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
        recRow += '</tr>';





        if (boolAppendorNot == false) {
            //to append
            jQuery('#' + TableName).append(recRow);
        }
        else {

            // to insert in perticular position
            var $NoAppnd = jQuery.noConflict();
            if (parseInt(row_index) != 0) {
                $NoAppnd('#' + TableName + ' > tbody > tr').eq(parseInt(row_index) - 1).after(recRow);
            }
            else {

                var TableRowCount = document.getElementById(TableName).rows.length;

                if (parseInt(TableRowCount) != 0) {
                    $NoAppnd('#' + TableName + ' > tbody > tr').eq(parseInt(row_index)).before(recRow);
                }
                else {
                    //if table row count is 0
                    jQuery('#' + TableName).append(recRow);
                }
            }




        }


        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {
                selectorToAutocompleteVehicle('txtselectorVhcl', rowCount);
                selectorToAutocompleteProject('txtselectorPrjct', rowCount);
                selectorToAutocompleteTime('txtselectorFrmTime', rowCount, TableName);
                selectorToAutocompleteTime('txtselectorToTime', rowCount, TableName);
               

                $au('form').submit(function () {

                  
                });
            });
        })(jQuery);

            //for renumbering
        ReNumberTable(TableName);


        if (JobMode == 1) {
           

            (function ($au) {
                $au(function () {
                    selectorToAutocompleteJob('txtselectorJob', rowCount);
                

                    $au('form').submit(function () {

                      
                    });
                });
            })(jQuery);
            //have to look into it
            //  PopulateList(rowCount);
            //-------------------------------------------------------------

            if (boolFocus == true) {
                document.getElementById("txtselectorJob" + rowCount).focus();
             
                $noC("#txtselectorJob" + rowCount).select();
            }

        }

        else if (JobMode == 2) {

            if (boolFocus == true) {
                document.getElementById("txtJob" + rowCount).focus();

            }
        }


           

    }


    function EditListRows(EditJobId, EditJobName, EditVhclNumbr, EditVhclId, EditPrjctId, EditPrjctName, EditFromTime, EditToTime, EditJobMode, EditTxtJobName, EditDtlId,DutyOrJobShdl, TableName, ModeEdit) {
      
       
        if (EditJobId.toString() != "" && EditVhclNumbr != "" && EditVhclId != "" && EditPrjctId != "" && EditPrjctName != "" && EditFromTime != "" && EditToTime != "" && EditJobMode != "" && EditDtlId != "" && TableName != "") {

            rowCount++;
            RowIndex++;

            document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


            var recRow = '<tr id="rowId_' + rowCount + '" >';
            recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
            recRow += '<td style="width: 3.2%;text-align: center;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -3%;" >' + RowIndex.toString() + ' </div></td>';
            if (parseInt(EditJobMode) == 1) {
                recRow += ' <td id="tdJobSelect' + rowCount + '" style="width: 19.9%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98.2%;margin-left: 0.1%;" id="txtselectorJob' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditJobName + '"  onkeypress="return isTagName(\'txtselectorJob' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return ChangeJobMode(\'txtselectorJob\',' + rowCount + ',\'' + TableName + '\', event)"   onblur="return BlurJSJobVhclPrjct(\'txtselectorJob\',' + rowCount + ',\'Job\',\'' + TableName + '\')" onfocus="return FocusJSValue(\'txtselectorJob\',' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorJobId' + rowCount + '"  value="' + EditJobId + '" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><input id="txtselectorJobName' + rowCount + '"  value="' + EditJobName + '" type="text" maxlength=100  /></td>';

            }
            else if (parseInt(EditJobMode) == 2) {


                recRow += ' <td id="tdJobText' + rowCount + '"  style="width: 19.9%;">';
                recRow += ' <input id="txtJob' + rowCount + '"  class="BillngEntryField"  type="text" value="' + EditTxtJobName + '" onkeypress="return isTagName(\'txtJob' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)" onkeydown="return ChangeJobMode(\'txtJob\',' + rowCount + ',\'' + TableName + '\', event)"    onblur="return BlurJSTXTJob(\'txtJob\',' + rowCount + ',\'' + TableName + '\')" onfocus="FocusTXTJob(\'txtJob\',' + rowCount + ',event)" maxlength=100 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%; background-color: rgb(231, 255, 185);"/>';
                recRow += '   </td> ';
            }

            recRow += ' <td id="tdVhclSelect' + rowCount + '" style="width: 19%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%;" id="txtselectorVhcl' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditVhclNumbr + '"  onkeypress="return isTagName(\'txtselectorVhcl' + rowCount + '\',\'txtselectorPrjct' + rowCount + '\',' + rowCount + ', event)" onkeydown="return  DisableEnter(event);"    onblur="return BlurJSJobVhclPrjct(\'txtselectorVhcl\',' + rowCount + ',\'Vehicle\',\'' + TableName + '\')" onfocus="return FocusJSValue(\'txtselectorVhcl\',' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' <td  style="display: none;"><input id="txtselectorVhclId' + rowCount + '"  value="' + EditVhclId + '" type="text"   /></td>';
            recRow += ' <td  style="display: none;"><input id="txtselectorVhclName' + rowCount + '"  value="' + EditVhclNumbr + '" type="text" maxlength=100  /></td>';

            recRow += ' <td id="tdPrjctSelect' + rowCount + '" style="width: 19%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 97.8%;margin-left: 0.1%;" id="txtselectorPrjct' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditPrjctName + '"  onkeypress="return isTagName(\'txtselectorPrjct' + rowCount + '\',\'txtselectorFrmTime' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return  DisableEnter(event);"   onblur="return BlurJSJobVhclPrjct(\'txtselectorPrjct\',' + rowCount + ',\'Project\',\'' + TableName + '\')" onfocus="return FocusJSValue(\'txtselectorPrjct\',' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' <td  style="display: none;"><input id="txtselectorPrjctId' + rowCount + '"  value="' + EditPrjctId + '" type="text"   /></td>';
            recRow += ' <td  style="display: none;"><input id="txtselectorPrjctName' + rowCount + '"  value="' + EditPrjctName + '" type="text" maxlength=100  /></td>';


            recRow += ' <td id="tdFrmTimeSelect' + rowCount + '" style="width: 10%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtselectorFrmTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text"  value="' + EditFromTime + '"  onkeypress="return isTagName(\'txtselectorFrmTime' + rowCount + '\',\'txtselectorToTime' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return  DisableEnter(event);"   onblur="return BlurJSTimeSHDL(\'txtselectorFrmTime\',' + rowCount + ',\'Time\',\'' + TableName + '\')" onfocus="return FocusJSTime(\'txtselectorFrmTime\',' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' <td  style="display: none;"><input id="txtselectorFrmTimeId' + rowCount + '"  value="' + EditFromTime + '" type="text" maxlength=100  /></td>';

            recRow += ' <td id="tdToTimeSelect' + rowCount + '" style="width: 10%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtselectorToTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text"  value="' + EditToTime + '"  onkeypress="return isTagName(\'txtselectorToTime' + rowCount + '\',\'tdIndvlAddMoreRowPic' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return  DisableEnter(event);"   onblur="return BlurJSTimeSHDL(\'txtselectorToTime\',' + rowCount + ',\'Time\',\'' + TableName + '\')" onfocus="return FocusJSTime(\'txtselectorToTime\',' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' <td  style="display: none;"><input id="txtselectorToTimeId' + rowCount + '"  value="' + EditToTime + '" type="text" maxlength=100  /></td>';


            recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividualschdl(' + rowCount + ',true,\'' + TableName + '\',false);"  style="  cursor: pointer;"></td>';
            recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to Delete this Entry?\',true,\'' + TableName + '\');"    style=" cursor: pointer;" ></td>';

            
            recRow += ' <td id="tdDutyOrJobShdl' + rowCount + '" style="display: none;" >' + DutyOrJobShdl + '</td>';
            recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
            recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
            recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">' + ModeEdit + '</td>';
            recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + EditDtlId + '</td>';
          
            if (parseInt(EditJobMode) == 1) {
                recRow += '<td id="tdJobMode' + rowCount + '" style="display: none;">1</td>';
            }
            else if (parseInt(EditJobMode) == 2) {
                recRow += '<td id="tdJobMode' + rowCount + '" style="display: none;">2</td>';
            }

            recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
            recRow += '</tr>';





            jQuery('#' + TableName).append(recRow);
            document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
            document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";
          


         


            var $au = jQuery.noConflict();

            (function ($au) {
                $au(function () {

                    selectorToAutocompleteVehicle('txtselectorVhcl', rowCount);
                    selectorToAutocompleteProject('txtselectorPrjct', rowCount);
                    selectorToAutocompleteTime('txtselectorFrmTime', rowCount, TableName);
                    selectorToAutocompleteTime('txtselectorToTime', rowCount, TableName);
                   
                    $au('form').submit(function () {

                   
                    });
                });
            })(jQuery);

            selectorToAutocompleteTimeEdit('txtselectorFrmTime', rowCount, TableName);
            selectorToAutocompleteTimeEdit('txtselectorToTime', rowCount, TableName);

            //for renumbering
            ReNumberTable(TableName);



            if (parseInt(EditJobMode) == 1) {
              

                (function ($au) {
                    $au(function () {
                        selectorToAutocompleteJob('txtselectorJob', rowCount);
                      

                        $au('form').submit(function () {

                            
                        });
                    });
                })(jQuery);
                //have to look into it
                //  PopulateList(rowCount);
                //-------------------------------------------------------------



            }

            //Start:-EVM-0009

            LocalStorageAdd(rowCount, TableName);
            //Stop:-EVM-0009

        }
        else {

            // alert('error');
        }
       
    }

    //Start:-EVM-0009


        function BlurJSJobVhclPrjct(obj, x, DefaultTxt, TableName) {
            if (obj == "txtselectorVhcl") {
                LoadVehicleDataRow();
            }

        if (document.getElementById(obj + "Id" + x).value == "" || document.getElementById(obj + "Id" + x).value == "--Select " + DefaultTxt + "--") {

            document.getElementById(obj + x).value = "--Select " + DefaultTxt + "--";
        }

        var TxtName = document.getElementById(obj + x).value.trim();

        if (TxtName == "" || TxtName == "--Select " + DefaultTxt + "--") {
            document.getElementById(obj + "Id" + x).value = "--Select " + DefaultTxt + "--";
            document.getElementById(obj + "Name" + x).value = "--Select " + DefaultTxt + "--";
            document.getElementById(obj + x).value = "--Select " + DefaultTxt + "--";
        }

        var JSName = document.getElementById(obj + "Name" + x).value.trim();
        if (JSName != "" || JSName != "--Select " + DefaultTxt + "--") {
            document.getElementById(obj + x).value = JSName;
        }

       

        var row_index = jQuery('#rowId_' + x).index();

        var SavedorNot = document.getElementById("tdSave" + x).innerHTML;

        if (SavedorNot == "saved") {

            if (IsTimeSlotSelected(TableName) == true) {
                var ValueId = document.getElementById(obj + "Id" + x).value;

                var hiddenIdFocus = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                    if (ValueId != hiddenIdFocus) {

                        if (ValueId != "--Select " + DefaultTxt + "--") {
                            document.getElementById(obj + x).style.borderColor = "";

                            //Update to local storage


                            if (TableName == "TableaddedRowsDW") {
                                document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
                                document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";

                            }


                            LocalStorageEdit(x, row_index, TableName);


                        }

                        else {
                            var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                            var hiddenHeadValText = document.getElementById("<%=hiddenJSNameFocus.ClientID%>").value;
                            if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                                document.getElementById(obj + x).value = hiddenHeadValText;
                                document.getElementById(obj + "Id" + x).value = hiddenHeadValId;
                                document.getElementById(obj + "Name" + x).value = hiddenHeadValText;

                            }
                        }
                    }

                }
                else {
                    var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                    var hiddenHeadValText = document.getElementById("<%=hiddenJSNameFocus.ClientID%>").value;
                    if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                        document.getElementById(obj + x).value = hiddenHeadValText;
                        document.getElementById(obj + "Id" + x).value = hiddenHeadValId;
                        document.getElementById(obj + "Name" + x).value = hiddenHeadValText;

                    }
                }

            }

            else {

                var ValueId = document.getElementById(obj + "Id" + x).value;
                var hiddenIdFocus = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                if (IsTimeSlotSelected(TableName) == true) {
                    if (ValueId != hiddenIdFocus) {
                        if (ValueId != "--Select " + DefaultTxt + "--") {
                            // alert(WBVhclId);


                            if (TableName == "TableaddedRowsDW") {
                                document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
                                document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";

                            }

                            document.getElementById(obj + x).style.borderColor = "";


                            //for saving


                            if (CheckAllRowField(x, row_index, TableName) == false) {

                                return false;

                            }

                            if (SavedorNot == " ") {
                                //  id tdSAVE is made'saved ' in localStorageAdd
                                //add to local storage
                                LocalStorageAdd(x, TableName);

                            }


                        }

                    }
                }
                else {

                    var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                    var hiddenHeadValText = document.getElementById("<%=hiddenJSNameFocus.ClientID%>").value;
                    if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                        document.getElementById(obj + x).value = hiddenHeadValText;
                        document.getElementById(obj + "Id" + x).value = hiddenHeadValId;
                        document.getElementById(obj + "Name" + x).value = hiddenHeadValText;

                    }
                    // alert('h');
                }
            }
        }


        function BlurJSTimeSHDL(obj, x, DefaultTxt, TableName) {

            //     alert('BlurJSTime-TableName ' + TableName);


            if (document.getElementById(obj + "Id" + x).value == "" || document.getElementById(obj + "Id" + x).value == "--Select " + DefaultTxt + "--") {

                document.getElementById(obj + x).value = "--Select " + DefaultTxt + "--";
            }

            var TxtName = document.getElementById(obj + x).value.trim();

            if (TxtName == "" || TxtName == "--Select " + DefaultTxt + "--") {
                document.getElementById(obj + "Id" + x).value = "--Select " + DefaultTxt + "--";
                document.getElementById(obj + x).value = "--Select " + DefaultTxt + "--";
            }

            var JSName = document.getElementById(obj + "Id" + x).value.trim();
            if (JSName != "" || JSName != "--Select " + DefaultTxt + "--") {
                document.getElementById(obj + x).value = JSName;
            }
            //////////////////////////////
            var row_index = jQuery('#rowId_' + x).index();

            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (SavedorNot == "saved") {
                if (IsTimeSlotSelected(TableName) == true) {
                    var ValueId = document.getElementById(obj + "Id" + x).value;

                    var hiddenIdFocus = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                    if (ValueId != hiddenIdFocus) {

                        if (ValueId != "--Select " + DefaultTxt + "--") {
                            if (SameFromAndToTime(x, TableName) == true) {
                                if (DuplicationTimeCheck(obj, x, row_index, TableName) == true) {
                                    document.getElementById(obj + x).style.borderColor = "";

                                    //Update to local storage
                                    if (TableName == "TableaddedRowsDW") {
                                        document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
                                        document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";

                                    }

                                    LocalStorageEdit(x, row_index, TableName);
                                }
                                else {
                                    var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;

                                    if (hiddenHeadValId != "") {

                                        document.getElementById(obj + x).value = hiddenHeadValId;
                                        document.getElementById(obj + "Id" + x).value = hiddenHeadValId;

                                    }
                                }
                            }
                            else {
                                var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;

                                if (hiddenHeadValId != "") {

                                    document.getElementById(obj + x).value = hiddenHeadValId;
                                    document.getElementById(obj + "Id" + x).value = hiddenHeadValId;

                                }
                            }
                        }

                        else {
                            var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;

                            if (hiddenHeadValId != "") {

                                document.getElementById(obj + x).value = hiddenHeadValId;
                                document.getElementById(obj + "Id" + x).value = hiddenHeadValId;

                            }
                        }
                    }

                }
                else {
                    var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;

                    if (hiddenHeadValId != "") {

                        document.getElementById(obj + x).value = hiddenHeadValId;
                        document.getElementById(obj + "Id" + x).value = hiddenHeadValId;

                    }
                }

            }

            else {

                var ValueId = document.getElementById(obj + "Id" + x).value;
                var hiddenIdFocus = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                if (IsTimeSlotSelected(TableName) == true) {

                    if (ValueId != hiddenIdFocus) {
                        //  alert('hi' + ValueId);
                        if (ValueId != "--Select " + DefaultTxt + "--") {
                            // alert(WBVhclId);
                            //  alert('row_Index' + row_Index);
                            if (SameFromAndToTime(x, TableName) == true) {
                                if (DuplicationTimeCheck(obj, x, row_index, TableName) == true) {
                                    if (TableName == "TableaddedRowsDW") {
                                        document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
                                        document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";

                                    }

                                    document.getElementById(obj + x).style.borderColor = "";


                                    //for saving


                                    if (CheckAllRowField(x, row_index, TableName) == false) {

                                        return false;

                                    }

                                    if (SavedorNot == " ") {
                                        //  id tdSAVE is made'saved ' in localStorageAdd
                                        //add to local storage
                                        LocalStorageAdd(x, TableName);

                                    }
                                }
                                else {

                                    var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;

                                    if (hiddenHeadValId != "") {

                                        document.getElementById(obj + x).value = hiddenHeadValId;
                                        document.getElementById(obj + "Id" + x).value = hiddenHeadValId;
                                    }
                                    // alert('h');
                                }
                            }
                            else {

                                var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;

                                if (hiddenHeadValId != "") {

                                    document.getElementById(obj + x).value = hiddenHeadValId;
                                    document.getElementById(obj + "Id" + x).value = hiddenHeadValId;
                                }
                                // alert('h');
                            }
                        }

                    }
                }
                else {

                    var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;

                    if (hiddenHeadValId != "") {

                        document.getElementById(obj + x).value = hiddenHeadValId;
                        document.getElementById(obj + "Id" + x).value = hiddenHeadValId;
                    }
                    // alert('h');
                }
            }
        }

        //Stop:-EVM-0009


        function removeRow(removeNum, CofirmMsg, boolAskConfirm, TableName) {
            // alert('removeRow-TableName' + TableName);
            var blConfirm = true;
            if (boolAskConfirm == true) {
                if (confirm(CofirmMsg)) {
                    blConfirm = true;
                }
                else {
                    blConfirm = false;
                }
            }

            if (blConfirm == true) {

                var row_index = jQuery('#rowId_' + removeNum).index();
                var BforeRmvTableRowCount = document.getElementById(TableName).rows.length;
                // alert('BforeRmvTableRowCount' + BforeRmvTableRowCount);
                LocalStorageDelete(row_index, removeNum, TableName);
                //alert('call');
                jQuery('#rowId_' + removeNum).remove();
                RowIndex--;
                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();
                var TableRowCount = document.getElementById(TableName).rows.length;

                if (TableRowCount != 0) {
                    var idlast = $noC('#' + TableName + ' tr:last').attr('id');
                    //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                    //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                    if (idlast != "") {
                        var res = idlast.split("_");
                        //  alert(res[1]);
                        document.getElementById("tdInx" + res[1]).innerHTML = " ";
                        document.getElementById("tdIndvlAddMoreRow" + res[1]).style.opacity = "1";
                    }
                }
                else {

                    if (TableName == "TableaddedRowsDW") {


                        document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>").disabled = false;
                    $("div#divTimeSlotDayWise input.ui-autocomplete-input").removeAttr('disabled');

                }
                addMoreRows(this.form, true, 1, false, 0, TableName);

                    //    document.getElementById("spanAddRow").style.opacity = "1";

            }

            if (BforeRmvTableRowCount > 1) {

                if ((BforeRmvTableRowCount - 1) == row_index) {

                    var table = document.getElementById(TableName);
                    var preRowId = table.rows[row_index - 1].id;

                    if (preRowId != "") {
                        var res = preRowId.split("_");
                        if (res[1] != "") {


                            document.getElementById("txtselectorJob" + res[1]).focus();
                            $noCon("#txtselectorJob" + res[1]).select();
                            ReNumberTable(TableName);

                        }
                    }
                }
                else {
                    //     alert('entered 2 case');
                    var table = document.getElementById(TableName);
                    var NxtRowId = table.rows[row_index].id;
                    //  alert('NxtRowId ' + NxtRowId);
                    if (NxtRowId != "") {
                        var res = NxtRowId.split("_");
                        if (res[1] != "") {

                            document.getElementById("txtselectorJob" + res[1]).focus();
                            $noCon("#txtselectorJob" + res[1]).select();
                            ReNumberTable(TableName);

                        }
                    }


                }
            }
                //   alert('removeRow-end' );
            return false;
        }
        else {
                //    alert('removeRow-end' );
            return false;

        }
    }


    function removeRowJobMode(removeNum, CofirmMsg, boolAskConfirm, TableName) {
        var blConfirm = true;
        if (boolAskConfirm == true) {
            if (confirm(CofirmMsg)) {
                blConfirm = true;
            }
            else {
                blConfirm = false;
            }
        }


        if (blConfirm == true) {

            var evt = document.getElementById("tdEvt" + removeNum).innerHTML;
            var detailId = document.getElementById("tdDtlId" + removeNum).innerHTML;
            //   var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;




            var Jmode = document.getElementById('tdJobMode' + removeNum).innerText;

            var row_index = jQuery('#rowId_' + removeNum).index();

            jQuery('#rowId_' + removeNum).remove();
            RowIndex--;
            document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


                if (Jmode == "1") {

                    addMoreRows(this.form, true, 2, true, row_index, TableName);
                    //    alert('fyn1');
                    ReNumberTable(TableName);


                }
                else if (Jmode == "2") {

                    addMoreRows(this.form, true, 1, true, row_index, TableName);
                    ReNumberTable(TableName);



                }


                //to get id of the row in table by row index
                var RowIdNewRow = $noC('#' + TableName + ' tr').eq(row_index).attr('id');
                if (RowIdNewRow != "") {
                    var resNew = RowIdNewRow.split("_");
                    //  alert(res[1]);
                    var xNewRow = resNew[1];

                }
                // alert('xNewRow' + xNewRow.toString());
                document.getElementById("tdEvt" + xNewRow).innerHTML = evt;
                document.getElementById("tdDtlId" + xNewRow).innerHTML = detailId;
                //update to default value when adding row
                LocalStorageEdit(xNewRow, row_index, TableName);
                document.getElementById("tdSave" + xNewRow).innerHTML = "saved";
                document.getElementById("tdChanged" + xNewRow).innerHTML = "Changed";

                var TableRowCount = document.getElementById(TableName).rows.length;
                //   alert(TableRowCount);
                if (TableRowCount != row_index + 1) {



                    document.getElementById("tdInx" + xNewRow).innerHTML = xNewRow;
                    document.getElementById("tdIndvlAddMoreRow" + xNewRow).style.opacity = "0.3";

                }
                else {

                }

                return true;
            }
            else {
                return false;
            }

        }
        </script>

      <script>
          var $noCon = jQuery.noConflict();
          function ChangeTimeSlot(obj) {
             
              var $noCT = jQuery.noConflict();
              var PreviousVal = document.getElementById("<%=hiddenPreviousTimeSlot.ClientID%>").value;
              //     alert('PreviousVal' + PreviousVal);
              var DropdownTimeSlot = '';
              if (obj == 'ddlTimeSlot_DayWise') {
                  DropdownTimeSlot = document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>");
              }


              var SelectedValueTimeSlot = DropdownTimeSlot.value;

              if (SelectedValueTimeSlot != PreviousVal) {
                
                  if (SelectedValueTimeSlot == '--SELECT TIME SLOT--') {

                      SelectedValueTimeSlot = 0;
                  }
                  if (SelectedValueTimeSlot != 0) {

                      if (obj == 'ddlTimeSlot_DayWise') {
                          TimeSlotSelected(SelectedValueTimeSlot, 'DayWise');
                          $noCon("div#divTimeSlotDayWise input.ui-autocomplete-input").css("borderColor", "");


                      }
                      //IncrmntConfrmCounter();
                  }
                  else {
                      if (obj == 'ddlTimeSlot_DayWise') {
                          TimeSlotSelected('0', 'DayWise');

                      }
                      // IncrmntConfrmCounter();
                      return false;
                  }
              }
              else {
                  return false;
              }
          }
          function IsDateSelected(TableName) {
              var DropdownTimeSlot = '';
              var SelectedValueTimeSlot = '';
              if (TableName == "TableaddedRowsDW") {
                  DropdownTimeSlot = document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>");
                  SelectedValueTimeSlot = DropdownTimeSlot.value;
              }

              if (SelectedValueTimeSlot == '--SELECT TIME SLOT--' || SelectedValueTimeSlot == '') {

                  if (TableName == "TableaddedRowsDW") {
                      $noCon("div#divTimeSlotDayWise input.ui-autocomplete-input").css("borderColor", "Red");
                      $noCon("div#divTimeSlotDayWise input.ui-autocomplete-input").focus();
                      $noCon("div#divTimeSlotDayWise input.ui-autocomplete-input").select();
                      document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>").focus();

                }
                //     alert('IsTimeSlotPeriodWiseSelected');
                return false;
            }
            else {
                return true;

            }
        }




        function IsTimeSlotSelected(TableName) {
            var DropdownTimeSlot = '';
            var SelectedValueTimeSlot = '';
            if (TableName == "TableaddedRowsDW") {
                DropdownTimeSlot = document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>");
                SelectedValueTimeSlot = DropdownTimeSlot.value;
            }

            if (SelectedValueTimeSlot == '--SELECT TIME SLOT--' || SelectedValueTimeSlot == '') {

                if (TableName == "TableaddedRowsDW") {
                    $noCon("div#divTimeSlotDayWise input.ui-autocomplete-input").css("borderColor", "Red");
                    $noCon("div#divTimeSlotDayWise input.ui-autocomplete-input").focus();
                    $noCon("div#divTimeSlotDayWise input.ui-autocomplete-input").select();
                    document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>").focus();

                }
                //     alert('IsTimeSlotPeriodWiseSelected');
                return false;
            }
            else {
                return true;

            }
        }

        function getPreviousDDLTimeSlot_SelectedVal(objName) {
            //   alert('getPreviousDDLTimeSlot_SelectedVal' + objName)
            document.getElementById("<%=hiddenPreviousTimeSlot.ClientID%>").value = '--SELECT TIME SLOT--';
              var DropdownList = '';
              if (objName == 'ddlTimeSlot_DayWise') {
                  DropdownList = document.getElementById('<%=ddlTimeSlot_DayWise.ClientID %>');

           }
           var SelectedValue = DropdownList.value;
           document.getElementById("<%=hiddenPreviousTimeSlot.ClientID%>").value = SelectedValue;
    }

    //this function is to RE-NUMBER table when deletion .as it show duplicate sl num when deleted othre than last row
    function ReNumberTable(TableName) {

        var table = "";


        table = document.getElementById(TableName);

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

                    }
                }

               
            }
        }
    }

    function ChangeJobMode(obj, x, TableName, evt) {

        evt = (evt) ? evt : window.event;
        var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
        var charCode = (evt.which) ? evt.which : evt.keyCode;

        if (keyCodes == 13) {
            return false;
        }

        if (keyCodes == 120) {// both F9 AND 'x' has same code in keypress
            //return false;

            if (obj == 'txtselectorJob') {
                var boolAskConfirm = false;
                var ValueId = document.getElementById(obj + "Id" + x).value;
                //     alert(QtnItemId);
                if (ValueId != "--Select Job--") {
                    boolAskConfirm = true;
                }

                if (removeRowJobMode(x, 'Are you sure you  want to clear this row ?', boolAskConfirm, TableName) == true) {
                    //for
                }
            }
            else if (obj == 'txtJob') {
                var boolAskConfirm = false;
                var ValueName = document.getElementById(obj + x).value;

                if (ValueName != "") {
                    boolAskConfirm = true;
                }

                if (removeRowJobMode(x, 'Are you sure you  want to clear this row ?', boolAskConfirm, TableName) == true) {

                }

            }

        }
    }


    function FocusJSValue(obj, x, event) {


        document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value = "";
            document.getElementById("<%=hiddenJSNameFocus.ClientID%>").value = "";
            var ValueId = document.getElementById(obj + 'Id' + x).value;
            document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value = ValueId;
                  var ValueName = document.getElementById(obj + 'Name' + x).value;
                  document.getElementById("<%=hiddenJSNameFocus.ClientID%>").value = ValueName;
            //for removing text for typing friendly
        if ((document.getElementById(obj + x).value == ("--Select Job--")) || (document.getElementById(obj + x).value == ("--Select Vehicle--")) || (document.getElementById(obj + x).value == ("--Select Project--"))) {
            document.getElementById(obj + x).value = "";
        }

    }

    function FocusJSTime(obj, x, event) {





        document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value = "";
            var ValueId = document.getElementById(obj + 'Id' + x).value;
            document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value = ValueId;

            //for removing text for typing friendly
            if (document.getElementById(obj + x).value == "--Select Time--") {
                document.getElementById(obj + x).value = "";
            }

        }


        function LocalStorageAdd(x, TableName) {


            document.getElementById("<%=HiddenField2.ClientID%>").value = "";


            var tbClientJobSheduling = '';
            if (TableName == "TableaddedRowsDW") {
                tbClientJobSheduling = localStorage.getItem("tbClientJobShedulingDW");//Retrieve the stored data

            }
            tbClientJobSheduling = JSON.parse(tbClientJobSheduling); //Converts string to object
            //alert(tbClientJobSheduling);
            if (tbClientJobSheduling == null) //If there is no data, initialize an empty array
                tbClientJobSheduling = [];
            var detailId = document.getElementById("tdDtlId" + x).innerHTML;
            //  var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
            var evt = document.getElementById("tdEvt" + x).innerHTML;
            var JobMode = document.getElementById("tdJobMode" + x).innerText;

            if (JobMode == "1") {
                if (evt == 'INS') {
                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        ROWID: "" + x + "",
                        JOBID: $add("#txtselectorJobId" + x).val(),
                        JOBNAME: $add("#txtselectorJobName" + x).val(),
                        VHCLID: $add("#txtselectorVhclId" + x).val(),
                        PRJCTID: $add("#txtselectorPrjctId" + x).val(),
                        FROMTIME: $add("#txtselectorFrmTimeId" + x).val(),
                        TOTIME: $add("#txtselectorToTimeId" + x).val(),
                        EVTACTION: "" + evt + "",
                        DTLID: "0",
                        JOBMODE: "" + JobMode + ""

                    });
                }
                else if (evt == 'UPD') {
                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        ROWID: "" + x + "",
                        JOBID: $add("#txtselectorJobId" + x).val(),
                        JOBNAME: $add("#txtselectorJobName" + x).val(),
                        VHCLID: $add("#txtselectorVhclId" + x).val(),
                        PRJCTID: $add("#txtselectorPrjctId" + x).val(),
                        FROMTIME: $add("#txtselectorFrmTimeId" + x).val(),
                        TOTIME: $add("#txtselectorToTimeId" + x).val(),
                        EVTACTION: "" + evt + "",
                        DTLID: "" + detailId + "",
                        JOBMODE: "" + JobMode + ""

                    });
                }

            }

            else if (JobMode == "2") {
                if (evt == 'INS') {
                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        ROWID: "" + x + "",
                        JOBID: "0",
                        JOBNAME: $add("#txtJob" + x).val(),
                        VHCLID: $add("#txtselectorVhclId" + x).val(),
                        PRJCTID: $add("#txtselectorPrjctId" + x).val(),
                        FROMTIME: $add("#txtselectorFrmTimeId" + x).val(),
                        TOTIME: $add("#txtselectorToTimeId" + x).val(),
                        EVTACTION: "" + evt + "",
                        DTLID: "0",
                        JOBMODE: "" + JobMode + ""
                    });
                }
                else if (evt == 'UPD') {
                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        ROWID: "" + x + "",
                        JOBID: "0",
                        JOBNAME: $add("#txtJob" + x).val(),
                        VHCLID: $add("#txtselectorVhclId" + x).val(),
                        PRJCTID: $add("#txtselectorPrjctId" + x).val(),
                        FROMTIME: $add("#txtselectorFrmTimeId" + x).val(),
                        TOTIME: $add("#txtselectorToTimeId" + x).val(),
                        EVTACTION: "" + evt + "",
                        DTLID: "" + detailId + "",
                        JOBMODE: "" + JobMode + ""

                    });
                }

            }
            tbClientJobSheduling.push(client);
            if (TableName == "TableaddedRowsDW") {
                localStorage.setItem("tbClientJobShedulingDW", JSON.stringify(tbClientJobSheduling));
                $add("#cphMain_HiddenField2").val(JSON.stringify(tbClientJobSheduling));

                document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>").disabled = true;
                $("div#divTimeSlotDayWise input.ui-autocomplete-input").attr("disabled", "disabled");


                
            }




            //for calculation of total Amount
            //  CalculateTotalAmountFromHiddenField();




            // alert(h);

            document.getElementById("tdSave" + x).innerHTML = "saved";
            //  alert('TableName ' + TableName);

            CheckaddMoreRowsIndividualschdl(x, false, TableName,true);

            //IncrmntConfrmCounter();
            // alert('gj');

            return true;

        }
        function LocalStorageDelete(row_index, x, TableName) {

            var tbClientJobSheduling = '';
            if (TableName == "TableaddedRowsDW") {
                tbClientJobSheduling = localStorage.getItem("tbClientJobShedulingDW");//Retrieve the stored data
            }
            tbClientJobSheduling = JSON.parse(tbClientJobSheduling); //Converts string to object
            //alert(tbClientJobSheduling);
            if (tbClientJobSheduling == null) //If there is no data, initialize an empty array
                tbClientJobSheduling = [];



            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            tbClientJobSheduling.splice(row_index, 1);
            if (TableName == "TableaddedRowsDW") {
                localStorage.setItem("tbClientJobShedulingDW", JSON.stringify(tbClientJobSheduling));
                $noCon("#cphMain_HiddenField2").val(JSON.stringify(tbClientJobSheduling));
            }

            // alert("Client deleted.");




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
            //   CalculateTotalAmountFromHiddenField();
            //  IncrmntConfrmCounter();
            // alert('gj');

        }

        function LocalStorageEdit(x, row_index, TableName) {
            //  alert('edit start x ' + x);
            //  alert('edit start row_index ' + row_index);
            var tbClientJobSheduling = '';
            if (TableName == "TableaddedRowsDW") {
                tbClientJobSheduling = localStorage.getItem("tbClientJobShedulingDW");//Retrieve the stored data
            }
            tbClientJobSheduling = JSON.parse(tbClientJobSheduling); //Converts string to object

            if (tbClientJobSheduling == null) //If there is no data, initialize an empty array
                tbClientJobSheduling = [];
            var detailId = document.getElementById("tdDtlId" + x).innerHTML;
            // var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
            var evt = document.getElementById("tdEvt" + x).innerHTML;
            var JobMode = document.getElementById("tdJobMode" + x).innerText;
            // alert('edit pmode ' + PrdctMode);
            //  alert('additional:' + additional)




            if (JobMode == "1") {
                if (evt == 'INS') {
                    var $E = jQuery.noConflict();
                    tbClientJobSheduling[row_index] = JSON.stringify({
                        ROWID: "" + x + "",
                        JOBID: $E("#txtselectorJobId" + x).val(),
                        JOBNAME: $E("#txtselectorJobName" + x).val(),
                        VHCLID: $E("#txtselectorVhclId" + x).val(),
                        PRJCTID: $E("#txtselectorPrjctId" + x).val(),
                        FROMTIME: $E("#txtselectorFrmTimeId" + x).val(),
                        TOTIME: $E("#txtselectorToTimeId" + x).val(),
                        EVTACTION: "" + evt + "",
                        DTLID: "0",
                        JOBMODE: "" + JobMode + ""

                    });
                }
                else if (evt == 'UPD') {
                    var $E = jQuery.noConflict();
                    tbClientJobSheduling[row_index] = JSON.stringify({
                        ROWID: "" + x + "",
                        JOBID: $E("#txtselectorJobId" + x).val(),
                        JOBNAME: $E("#txtselectorJobName" + x).val(),
                        VHCLID: $E("#txtselectorVhclId" + x).val(),
                        PRJCTID: $E("#txtselectorPrjctId" + x).val(),
                        FROMTIME: $E("#txtselectorFrmTimeId" + x).val(),
                        TOTIME: $E("#txtselectorToTimeId" + x).val(),
                        EVTACTION: "" + evt + "",
                        DTLID: "" + detailId + "",
                        JOBMODE: "" + JobMode + ""

                    });
                }

            }

            else if (JobMode == "2") {
                if (evt == 'INS') {
                    var $E = jQuery.noConflict();
                    tbClientJobSheduling[row_index] = JSON.stringify({
                        ROWID: "" + x + "",
                        JOBID: "0",
                        JOBNAME: $E("#txtJob" + x).val(),
                        VHCLID: $E("#txtselectorVhclId" + x).val(),
                        PRJCTID: $E("#txtselectorPrjctId" + x).val(),
                        FROMTIME: $E("#txtselectorFrmTimeId" + x).val(),
                        TOTIME: $E("#txtselectorToTimeId" + x).val(),
                        EVTACTION: "" + evt + "",
                        DTLID: "0",
                        JOBMODE: "" + JobMode + ""
                    });
                }
                else if (evt == 'UPD') {
                    var $E = jQuery.noConflict();
                    tbClientJobSheduling[row_index] = JSON.stringify({
                        ROWID: "" + x + "",
                        JOBID: "0",
                        JOBNAME: $E("#txtJob" + x).val(),
                        VHCLID: $E("#txtselectorVhclId" + x).val(),
                        PRJCTID: $E("#txtselectorPrjctId" + x).val(),
                        FROMTIME: $E("#txtselectorFrmTimeId" + x).val(),
                        TOTIME: $E("#txtselectorToTimeId" + x).val(),
                        EVTACTION: "" + evt + "",
                        DTLID: "" + detailId + "",
                        JOBMODE: "" + JobMode + ""

                    });
                }

            }


            if (TableName == "TableaddedRowsDW") {
                localStorage.setItem("tbClientJobShedulingDW", JSON.stringify(tbClientJobSheduling));
                $E("#cphMain_HiddenField2").val(JSON.stringify(tbClientJobSheduling));

                // alert(document.getElementById("<%=HiddenField2.ClientID%>").value);
                }
                //for calculation of total Amount
                //    CalculateTotalAmountFromHiddenField();



           

            // alert(h);
          
                CheckaddMoreRowsIndividualschdl(x, false, TableName, false);
          
               

                return true;
            }
    </script>

    <script>
        var $noCon = jQuery.noConflict();
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
        function SameFromAndToTime(x, TableName) {

            var TimeDifferenceSts = '';
            if (TableName == 'TableaddedRowsDW') {
                TimeDifferenceSts = document.getElementById("<%=hiddenDayWiseTimeDifferenceSts.ClientID%>").value;
           }
           var ret = true;
           var FromTime = document.getElementById('txtselectorFrmTimeId' + x).value;
           var ToTime = document.getElementById('txtselectorToTimeId' + x).value;
           if (FromTime == ToTime) {
               ret = false;
               if (TableName == "TableaddedRowsDW") {
                   document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                   document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Sorry, both From Time and To Time can't be same!";
                }
            }
            if (FromTime != "--Select Time--" && FromTime != "" && ToTime != "--Select Time--" && ToTime != "") {

                var Frinput = FromTime, Frmatches = Frinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
    Froutput = (parseInt(Frmatches[1]) + (Frmatches[3] == 'pm' ? 12 : 0)) + ':' + Frmatches[2] + ':00';
                var FromDateTime = dateString2Date('01-01-2016 ' + Froutput);

                var Toinput = ToTime, Tomatches = Toinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
    Tooutput = (parseInt(Tomatches[1]) + (Tomatches[3] == 'pm' ? 12 : 0)) + ':' + Tomatches[2] + ':00';
                var ToDateTime = dateString2Date('01-01-2016 ' + Tooutput);
                //  alert('FromDateTime' + FromDateTime);
                //  alert('ToDateTime' + ToDateTime);
                if (FromDateTime > ToDateTime) {
                    // alert(TimeDifferenceSts);
                    if (TimeDifferenceSts == '0') {
                        ret = false;
                        if (TableName == "TableaddedRowsDW") {
                            document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                            document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Sorry,'From Time' cannot be greater than 'To Time'!";
                        }
                    }
                }
            }
            if (ret == false) {


            }
            return ret;
        }
        function DuplicationTimeCheck(obj, x, row_Index, TableName) {
            var dup = false;
       
            var TimeDifferenceSts = '';
            var DefaultStartValue = '';
            var DefaultEndValue = '';
            if (TableName == 'TableaddedRowsDW') {
                TimeDifferenceSts = document.getElementById("<%=hiddenDayWiseTimeDifferenceSts.ClientID%>").value;
       DefaultStartValue = document.getElementById("<%=hidden_DefalultStartTimeDayWise.ClientID%>").value;
       DefaultEndValue = document.getElementById("<%=hidden_DefalultEndTimeDayWise.ClientID%>").value;
   }
    // alert('TimeDifferenceSts ' + TimeDifferenceSts);

    var TimeObj = document.getElementById(obj + "Id" + x);

    //  var selectedText = QtnItem.options[QtnItem.selectedIndex].text;
    var selectedText = TimeObj.value;
    var TimeValue = selectedText;


    var DfltStartinput = DefaultStartValue, DfltStartmatches = DfltStartinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
DfltStartoutput = (parseInt(DfltStartmatches[1]) + (DfltStartmatches[3] == 'pm' ? 12 : 0)) + ':' + DfltStartmatches[2] + ':00';
    var DfltStartDateTime = dateString2Date('01-01-2016 ' + DfltStartoutput);

    var DfltStopinput = DefaultEndValue, DfltStopmatches = DfltStopinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
DfltStopoutput = (parseInt(DfltStopmatches[1]) + (DfltStopmatches[3] == 'pm' ? 12 : 0)) + ':' + DfltStopmatches[2] + ':00';
    var DfltStopDateTime = dateString2Date('01-01-2016 ' + DfltStopoutput);
    if (TimeDifferenceSts != '0') {

        DfltStopDateTime = dateString2Date('02-01-2016 ' + DfltStopoutput);
    }
    var input = TimeValue, matches = input.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
output = (parseInt(matches[1]) + (matches[3] == 'pm' ? 12 : 0)) + ':' + matches[2] + ':00';
    var objDateTime = dateString2Date('01-01-2016 ' + output);

    if (TimeDifferenceSts != '0') {
        // alert(DfltStartDateTime);
        if (objDateTime < DfltStartDateTime) {

            objDateTime = dateString2Date('02-01-2016 ' + output);

        }
    }
    //     alert(objDateTime)
    var ret = true;


    if (obj == "txtselectorFrmTime") {
        //for checking withing the range

        var NxtTimeObj = document.getElementById("txtselectorToTimeId" + x);
        var NxtTimeValue = NxtTimeObj.value;
        if (NxtTimeValue != "--Select Time--" && NxtTimeValue != "") {
            var Nxtinput = NxtTimeValue, Nxtmatches = Nxtinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
Nxtoutput = (parseInt(Nxtmatches[1]) + (Nxtmatches[3] == 'pm' ? 12 : 0)) + ':' + Nxtmatches[2] + ':00';
            var NxtDateTime = dateString2Date('01-01-2016 ' + Nxtoutput);
            if (TimeDifferenceSts != '0') {
                // alert(DfltStartDateTime);
                if (NxtDateTime < DfltStartDateTime) {

                    NxtDateTime = dateString2Date('02-01-2016 ' + Nxtoutput);

                }
            }

             //  alert('objDateTime' + objDateTime);
             // alert('DfltStartDateTime' + DfltStartDateTime);
             //   alert('NxtDateTime' + NxtDateTime);
             //alert('DfltStopDateTime' + DfltStopDateTime);

            if (objDateTime >= DfltStartDateTime && NxtDateTime <= DfltStopDateTime) {
                // alert('error');
                if (objDateTime > NxtDateTime) {
                    ret = false;
                }
            }
            else {
                ret = false;
            }

        }

    }
    else if (obj == "txtselectorToTime") {
        //for checking withing the range

        var NxtTimeObj = document.getElementById("txtselectorFrmTimeId" + x);
        var NxtTimeValue = NxtTimeObj.value;
        if (NxtTimeValue != "--Select Time--" && NxtTimeValue != "") {
            var Nxtinput = NxtTimeValue, Nxtmatches = Nxtinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
Nxtoutput = (parseInt(Nxtmatches[1]) + (Nxtmatches[3] == 'pm' ? 12 : 0)) + ':' + Nxtmatches[2] + ':00';
            var NxtDateTime = dateString2Date('01-01-2016 ' + Nxtoutput);
            if (TimeDifferenceSts != '0') {
                if (NxtDateTime < DfltStartDateTime) {
                    
                    NxtDateTime = dateString2Date('02-01-2016 ' + Nxtoutput);

                }
            }


               // alert('NxtDateTime ' + NxtDateTime);
               //alert('objDateTime ' + objDateTime);
               //alert('DfltStartDateTime ' + DfltStartDateTime);
               //alert('DfltStopDateTime ' + DfltStopDateTime);
            if (NxtDateTime >= DfltStartDateTime && objDateTime <= DfltStopDateTime) {
                if (NxtDateTime > objDateTime) {
                 
                    ret = false;
                }
            }
            else {
              
                ret = false;
            }

        }

    }

    //   alert(ret);
    if (ret == true) {

        var objDateTime12AM = dateString2Date('01-01-2016 12:00:00');
        //      alert(output);
        //      alert(objDateTime);

        //  var resultJSON = '{"FirstName":"John","LastName":"Doe","Email":"johndoe@johndoe.com","Phone":"123 dead drive"}","{"FirstName":"Johni","LastName":"Doioe","Email":"johndoe@johndoe.com","Phone":"123 dead drive"}';
        var hiddenVal = '';
        //  alert(hiddenVal);
        if (TableName == "TableaddedRowsDW") {

            hiddenVal = document.getElementById("<%=HiddenField2.ClientID%>").value;
             }

             if (document.getElementById("<%=hiddenAllowJobDuplication.ClientID%>").value == "1") {
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
                          var FrTm = '';
                          var ToTm = '';
                          var resultJSON = "";
                          if (i == 0) {
                              resultJSON = jdatas[i];

                          }
                          else {

                              resultJSON = "{" + jdatas[i];

                          }

                          var result = $noCon.parseJSON(resultJSON);
                          $noCon.each(result, function (k, v) {
                              if (k == "FROMTIME") {
                                  FrTm = v.trim();
                              }
                              if (k == "TOTIME") {
                                  ToTm = v.trim();
                              }
                          });
                          var Rindex = parseInt(row_Index);

                          if (i != Rindex) {


                              var Frinput = FrTm, Frmatches = Frinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
  Froutput = (parseInt(Frmatches[1]) + (Frmatches[3] == 'pm' ? 12 : 0)) + ':' + Frmatches[2] + ':00';
                              var FromDateTime = dateString2Date('01-01-2016 ' + Froutput);

                              if (TimeDifferenceSts != '0') {
                                  if (FromDateTime < DfltStartDateTime) {

                                      FromDateTime = dateString2Date('02-01-2016 ' + Froutput);
                                  }
                              }

                              var Toinput = ToTm, Tomatches = Toinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
  Tooutput = (parseInt(Tomatches[1]) + (Tomatches[3] == 'pm' ? 12 : 0)) + ':' + Tomatches[2] + ':00';
                              var ToDateTime = dateString2Date('01-01-2016 ' + Tooutput);

                              if (TimeDifferenceSts != '0') {
                                  if (ToDateTime < DfltStartDateTime) {

                                      ToDateTime = dateString2Date('02-01-2016 ' + Tooutput);
                                  }
                              }


                              //if (TimeDifferenceSts != '0') {
                              //    if (FromDateTime > ToDateTime) {
                              //        ToDateTime = dateString2Date('02-01-2016 ' + Tooutput);

                              //    }
                              //}

                              if (obj == "txtselectorFrmTime") {
                                  //for same cheching and oterbound checking
                                  if (FrTm == TimeValue) {
                                      ret = false;
                                  }

                                  if (ret == true) {
                                      var NxtTimeObj = document.getElementById("txtselectorToTimeId" + x);
                                      var NxtTimeValue = NxtTimeObj.value;
                                      if (NxtTimeValue != "--Select Time--" && NxtTimeValue != "") {
                                          var Nxtinput = NxtTimeValue, Nxtmatches = Nxtinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
  Nxtoutput = (parseInt(Nxtmatches[1]) + (Nxtmatches[3] == 'pm' ? 12 : 0)) + ':' + Nxtmatches[2] + ':00';
                                          var NxtDateTime = dateString2Date('01-01-2016 ' + Nxtoutput);
                                          if (TimeDifferenceSts != '0') {
                                              if (NxtDateTime < DfltStartDateTime) {

                                                  NxtDateTime = dateString2Date('02-01-2016 ' + Nxtoutput);

                                              }
                                          }

                                          if (FromDateTime > objDateTime && NxtDateTime > ToDateTime) {
                                              ret = false;
                                          }


                                      }

                                  }
                              }
                              else if (obj == "txtselectorToTime") {
                                  //for same cheching and oterbound checking
                                  if (ToTm == TimeValue) {
                                      ret = false;
                                  }

                                  if (ret == true) {
                                      var NxtTimeObj = document.getElementById("txtselectorFrmTimeId" + x);
                                      var NxtTimeValue = NxtTimeObj.value;
                                      if (NxtTimeValue != "--Select Time--" && NxtTimeValue != "") {
                                          var Nxtinput = NxtTimeValue, Nxtmatches = Nxtinput.toLowerCase().match(/(\d{1,2}):(\d{2}) ([ap]m)/),
                                       Nxtoutput = (parseInt(Nxtmatches[1]) + (Nxtmatches[3] == 'pm' ? 12 : 0)) + ':' + Nxtmatches[2] + ':00';
                                          var NxtDateTime = dateString2Date('01-01-2016 ' + Nxtoutput);

                                          if (TimeDifferenceSts != '0') {
                                              if (NxtDateTime < DfltStartDateTime) {

                                                  NxtDateTime = dateString2Date('02-01-2016 ' + Nxtoutput);

                                              }
                                          }

                                          if (FromDateTime > NxtDateTime && objDateTime > ToDateTime) {
                                              ret = false;
                                          }


                                      }

                                  }

                              }
                              //inner bound
                              if (ret == true) {
                                  if (FromDateTime < objDateTime && objDateTime < ToDateTime) {
                                      ret = false;
                                  }
                              }


                          }

                      }


                      if (ret == false) {
                          if (TableName == "TableaddedRowsDW") {
                              document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                              document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Sorry, You have already selected this Time!";
                            }

                        }

                    }
                }
            }
    else if (ret == false) {

      
                if (TableName == "TableaddedRowsDW") {
                    document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Sorry, Please select time within range of Time Slot!";
                }

            }
        return ret;

    }



    function SelectWeekdays(WkId) {
        var blCheckedPrevious = false;
        var PreviousSlctdValues = document.getElementById("<%=hiddenWeekDayId.ClientID%>").value;
    var arrWeekDays = PreviousSlctdValues.split(",");
    //  alert('bla' +PreviousSlctdValues);

    //  alert(WkId);
    //  alert( arrWeekDays.length);
    for (i = 0; i < arrWeekDays.length; i++) {
        if (arrWeekDays[i].toString() == WkId.toString() && arrWeekDays[i].toString() != "") {
            blCheckedPrevious = true;
            document.getElementById("liWeekdays" + WkId).style.border = ".5px solid";
            document.getElementById("liWeekdays" + WkId).style.backgroundColor = "";

        }
    }



    // var oldImage = document.getElementById("<%=hiddenWeekDayId.ClientID%>").value;
    //if (oldImage != "") {
    //    document.getElementById("divImageLicenseType-" + oldImage).style.border = ".5px solid";
    //    document.getElementById("divImageLicenseType-" + oldImage).style.borderColor = "#ceb6b6";
    //    document.getElementById("divImageLicenseType-" + oldImage).style.backgroundColor = "";
    //}
    if (blCheckedPrevious == false) {// if not selected previously
        document.getElementById("liWeekdays" + WkId).style.border = ".5px solid";
        document.getElementById("liWeekdays" + WkId).style.backgroundColor = "rgb(138, 195, 34)";
        if (document.getElementById("<%=hiddenWeekDayId.ClientID%>").value == "") {
                    document.getElementById("<%=hiddenWeekDayId.ClientID%>").value = WkId + ",";
                }
                else {
                    document.getElementById("<%=hiddenWeekDayId.ClientID%>").value = document.getElementById("<%=hiddenWeekDayId.ClientID%>").value + WkId + ",";

                }
            }
            else {

                var replacedValue = PreviousSlctdValues.replace(WkId + ",", "");
                document.getElementById("<%=hiddenWeekDayId.ClientID%>").value = replacedValue;

            }


        }

        function testWeekdays() {

            alert(document.getElementById("<%=hiddenWeekDayId.ClientID%>").value);
            return false;
        }




        function CheckaddMoreRowsIndividualschdl(x, retBool, TableName, y) {
        
            // for add image in each row
            vhclCheck(x, retBool, TableName, y);
            return false;
        }


        function vhclCheck(x, retBool, TableName, y) {
        
            var ret = true;
            var Fromdate = document.getElementById("lblTodayDate").innerText;
            var Todate = document.getElementById("lblTodayDate").innerText;
             var FromTime = document.getElementById('txtselectorFrmTimeId' + x).value;
             var ToTime = document.getElementById('txtselectorToTimeId' + x).value;
             var VhclId = document.getElementById("txtselectorVhclId" + x).value;
            // var edit = document.getElementById("<%=hiddenDutyMasterId.ClientID%>").value;
             var DutyOrJobShdl = document.getElementById("tdDutyOrJobShdl" + x).innerHTML;
             var edit = document.getElementById("tdDtlId" + x).innerHTML;


            
             if (Fromdate != "" && Todate != "" && FromTime != "--Select Time--" && ToTime != "--Select Time--" && VhclId != "--Select Vehicle--") {

              

                     var Details = PageMethods.VhclCheck(Fromdate, Todate, FromTime, ToTime, VhclId, edit, function (response) {


                       



                         if (response == "false" ) {

                             CheckAddIntervl(x, retBool, TableName, false);

                         }

                         //if (response == "false" && edit == "0") {
                          
                         //    CheckAddIntervl(x, retBool, TableName, false);

                         //}

                         //else if (response == "false" && edit != "0" && y == true) {
                           
                         //    CheckAddIntervl(x, retBool, TableName, false);

                         //}
                         else {

                             CheckAddIntervl(x, retBool, TableName, true);
                         }
                     });

               


             }
             else {
                     CheckAddIntervl(x, retBool, TableName, true);
                 }
         }


        function CheckAddIntervl(x, retBool, TableName, a) {
           

           
            if (a==true) {

               

                var check = document.getElementById("tdInx" + x).innerHTML;

                //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
                //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
                if (check == " ") {

                    if (retBool == true) {

                        if (CheckAllRowFieldAndHighlight(x) == true) {

                            document.getElementById("tdInx" + x).innerHTML = x;
                            document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";

                       
                            addMoreRows(this.form, retBool, 1, false, 0, TableName);


                            return false;
                        }
                    }
                    else if (retBool == false) {
                        var row_index = jQuery('#rowId_' + x).index();
                        if (CheckAllRowField(x, row_index, TableName) == true) {
                            document.getElementById("tdInx" + x).innerHTML = x;
                            document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";
                            //   alert('TableName ' + TableName);
                            addMoreRows(this.form, retBool, 1, false, 0, TableName);


                            return false;
                        }
                    }
                }
                return false;
            }
            else {
                
                document.getElementById("txtselectorFrmTime" + x).value = "--Select Time--";
                document.getElementById("txtselectorFrmTimeId" + x).value = "--Select Time--";

                document.getElementById("txtselectorToTime" + x).value = "--Select Time--";
                document.getElementById("txtselectorToTimeId" + x).value = "--Select Time--";


                document.getElementById("txtselectorFrmTime" + x).style.borderColor = "Red";
                document.getElementById("txtselectorToTime" + x).style.borderColor = "Red";

                document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Sorry, Vehicle is already scheduled within the time range!";
            }
        }







       
      

        function LoadVehicleDataRow() {

            $E = jQuery.noConflict();
           

            jQuery('#TableVehicle tr').remove();
            InitializeVehi();
            var totalveh = "";
            for (count = 0; count <= rowCount; count++) {
                var VehId = $E("#txtselectorVhclId" + count).val();

                if (VehId != 'undefined'&&VehId != null) {
 
                    if (totalveh.indexOf(VehId) >= 0) {
                        
                    }
                    else {
                        var totalveh = totalveh + "," + VehId;
                        $NonCon.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "gen_Duty_Roster.aspx/VehicleInsertNewRow",
                            data: '{VehId: "' + VehId + '"}',
                            dataType: "json",
                            success: function (data) {

                                EditVehicleRows(data.d[0], data.d[1], data.d[2]);
                            }
                        });
                    }
                }
            }
        }



        // checks every field in row
        function CheckIfAnyAdded(x) {
            ret = false;
            var JMode = document.getElementById("tdJobMode" + x).innerText;
            if (JMode == "1") {
                var Job = document.getElementById("txtselectorJobId" + x).value;
                if (Job != "--Select Job--") {
                    ret = true;

                }

            }
            else {
                var Job = document.getElementById("txtJob" + x).value;
                if (Job != "") {
                    ret = true;

                }

            }
            var Vhcl = document.getElementById("txtselectorVhclId" + x).value;
            if (Vhcl != "--Select Vehicle--") {
                ret = true;

            }
            var Prjct = document.getElementById("txtselectorPrjctId" + x).value;
            if (Prjct != "--Select Project--") {
                ret = true;

            }
            var FrmTime = document.getElementById("txtselectorFrmTimeId" + x).value;
            if (FrmTime != "--Select Time--") {
                ret = true;

            }
            var ToTime = document.getElementById("txtselectorToTimeId" + x).value;
            if (ToTime != "--Select Time--") {
                ret = true;

            }

            return ret;
        }


        // checks every field in row
        function CheckAllRowField(x, row_index, TableName) {
            ret = true;
            var JMode = document.getElementById("tdJobMode" + x).innerText;
            if (JMode == "1") {
                var Job = document.getElementById("txtselectorJobId" + x).value;
                if (Job == "--Select Job--") {
                    ret = false;

                }

            }
            else {
                var Job = document.getElementById("txtJob" + x).value;
                if (Job == "") {
                    ret = false;

                }

            }
            var Vhcl = document.getElementById("txtselectorVhclId" + x).value;
            if (Vhcl == "--Select Vehicle--") {
                ret = false;

            }
            var Prjct = document.getElementById("txtselectorPrjctId" + x).value;
            if (Prjct == "--Select Project--") {
                ret = false;

            }
            var FrmTime = document.getElementById("txtselectorFrmTimeId" + x).value;
            if (FrmTime == "--Select Time--") {
                ret = false;

            } else {

                if (DuplicationTimeCheck('txtselectorFrmTime', x, row_index, TableName) == true) {
                    if (TableName == "TableaddedRowsDW") {
                        document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
                        document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";
                    }
                }
                else {

                    document.getElementById("txtselectorFrmTime" + x).value = "--Select Time--";
                    document.getElementById("txtselectorFrmTimeId" + x).value = "--Select Time--";

                    document.getElementById("txtselectorFrmTime" + x).style.borderColor = "Red";


                    ret = false;
                }
            }
            var ToTime = document.getElementById("txtselectorToTimeId" + x).value;
            if (ToTime == "--Select Time--") {
                ret = false;

            }
            else {

                if (DuplicationTimeCheck('txtselectorToTime', x, row_index, TableName) == true) {
                    if (TableName == "TableaddedRowsDW") {
                        document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
                        document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";
                    }
                }
                else {

                    document.getElementById("txtselectorToTime" + x).value = "--Select Time--";
                    document.getElementById("txtselectorToTimeId" + x).value = "--Select Time--";

                    document.getElementById("txtselectorToTime" + x).style.borderColor = "Red";


                    ret = false;
                }
            }

            return ret;
        }


        // checks every field in row
        function CheckRcptNumberFieldAndHighlight(x) {
            ret = true;
            var RcptNumber = document.getElementById("txtRcptNumber" + x).value;
            if (RcptNumber == "") {
                document.getElementById("txtRcptNumber" + x).style.borderColor = "Red";
                document.getElementById("txtRcptNumber" + x).focus();
                $noCon("#txtRcptNumber" + x).select();
                return false;
            }


            return true;
        }

        function CheckDate(blCheckWithCurrntDate) {
            var ret = true;

            document.getElementById('divMessageArea').style.display = "none";
            document.getElementById('imgMessageArea').src = "";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";

            if (ret == true) {
                //// AFTER if validation is true in above case
                //check if  date is less than current date


            }
            else {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";
            }
            return ret;
        }

        function ValidateAndSave() {

            var ret = true;

            if (CheckIsRepeat() == true) {

            }
            else {
                ret = false;
            }
               

            // alert('aa');
            document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";
          


            if (IsTimeSlotSelected('TableaddedRowsDW') == true) {

               
                var DropdownTimeSlotDW = document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>");
                    var SelectedValueTimeSlotDW = DropdownTimeSlotDW.value;
                    document.getElementById("<%=hiddenddlTimeSlotDWVal.ClientID%>").value = SelectedValueTimeSlotDW;
                    document.getElementById("<%=hiddenddlTimeSlotPWVal.ClientID%>").value = SelectedValueTimeSlotDW;
                // alert(document.getElementById("<%=hiddenddlTimeSlotPWVal.ClientID%>").value);
              
                if (validatePeriodorDayWiseTable('TableaddedRowsDW') == false) {
                  
                        ret = false;
                       
                    }
                    else {
                        //  return true;
                   
                    }

                }
                else {
               
                document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                    //document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";
                    ret = false;
                }




                if (ret == false) {

                    CheckSubmitZero();

                }
                else {
                    clearSTS();
                }
         
                return ret;
            }




            function validatePeriodorDayWiseTable(TableName) {
                var TableRowCount = document.getElementById(TableName).rows.length;
                //  alert(TableRowCount);
                if (TableRowCount != 0) {
                    if (TableRowCount == 1) {
                        var ret = true;
                        //if added a row not entered any value validate

                        var idlast = $noCon('#' + TableName + ' tr:last').attr('id');
                        if (idlast != "") {
                            var res = idlast.split("_");
                            var x = res[1];

                           
                            if (CheckAllRowFieldAndHighlight(x) == false) {
                            
                                ret = false;
                            }

                          
                            if (ret == false) {
                                if (TableName == "TableaddedRowsDW") {
                                    document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                                    document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                            }

                        }
                        else if (ret == true) {




                        }

                    }
                    else {
                        ret = false;

                    }


                    return ret;
                }


                else {

                    var ret = true;
                    var table = document.getElementById(TableName);
                    // alert(table.rows.length);
                    for (var i = 0; i < table.rows.length; i++) {
                        if (i != table.rows.length - 1) {
                            // FIX THIS
                            var row = table.rows[i];

                            var xLoop = (table.rows[i].cells[0].innerHTML);
                            if (CheckAllRowFieldAndHighlight(xLoop) == false) {
                                ret = false;
                            }


                        }
                        else {
                            //last row


                            var xLoop = (table.rows[i].cells[0].innerHTML);
                            if (document.getElementById("tdChanged" + xLoop).innerHTML == "Changed") {
                                if (CheckAllRowFieldAndHighlight(xLoop) == false) {
                                    ret = false;
                                }
                            }

                        }
                    }
                    if (ret == true) {
                        var idlast = $noCon('#' + TableName + ' tr:last').attr('id');
                        //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                        //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");


                        if (idlast != "") {
                            var res = idlast.split("_");
                            var x = res[1];
                            //  alert(res[1]);
                            if (CheckIfAnyAdded(x) == true)//if any added value
                            {
                                if (CheckAllRowFieldAndHighlight(x) == false) {
                                    ret = false;
                                }
                            }


                            if (ret == false) {
                                if (TableName == "TableaddedRowsDW") {
                                    document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                                    document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                                }
                            }
                            else if (ret == true) {





                            }

                        }
                        else {

                            ret = false;
                        }
                    }

                    else if (ret == false) {
                        if (TableName == "TableaddedRowsDW") {
                            document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                            document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                        }
                    }


                return ret;
            }
        }
        else {


            if (TableName == "TableaddedRowsDW") {
                document.getElementById('divErrorNotificationDW').style.visibility = "visible";
                document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "Sorry, Please add atleast one Item to Save!";

                }


                return false;

            }

        }

    </script>

  
        <script>
            var $au = jQuery.noConflict();
            function selectorToAutocompleteJob(obj, x) {

                var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;

                var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;


                if (CorpId != '' && CorpId != null && (!isNaN(CorpId)) && OrgId != '' && OrgId != null && (!isNaN(OrgId))) {

                    $("#" + obj + x).autocomplete({
                        source: function (request, response) {

                            $.ajax({
                                url: '<%=ResolveUrl("WebServiceJobshdlData.asmx/GetJob") %>',
                            data: "{ 'strLikeJobName': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'intOrgId': '" + parseInt(OrgId) + "', 'intCorpId': '" + parseInt(CorpId) + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('<->')[0],
                                        val: item.split('<->')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                                //  alert(response.responseText);
                            },
                            failure: function (response) {
                                //  alert(response.responseText);
                            }
                        });
                    },
                    autoFocus: true,

                    select: function (e, i) {
                        document.getElementById("txtselectorJobId" + x).value = i.item.val;
                        document.getElementById("txtselectorJobName" + x).value = i.item.label;
                        //  alert(i.item.val);
                        //  alert(i.item.label);
                    },

                    minLength: 1

                });
            }


        }

        function selectorToAutocompleteVehicle(obj, x) {
            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;

            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;

            if (CorpId != '' && CorpId != null && (!isNaN(CorpId)) && OrgId != '' && OrgId != null && (!isNaN(OrgId))) {

                $("#" + obj + x).autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: '<%=ResolveUrl("WebServiceJobshdlData.asmx/GetVehicle") %>',
                            data: "{ 'strLikeVehicleNumbr': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'intOrgId': '" + parseInt(OrgId) + "', 'intCorpId': '" + parseInt(CorpId) + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('<->')[0],
                                        val: item.split('<->')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                                //  alert(response.responseText);
                            },
                            failure: function (response) {
                                //  alert(response.responseText);
                            }
                        });
                    },
                    autoFocus: true,

                    select: function (e, i) {
                        document.getElementById("txtselectorVhclId" + x).value = i.item.val;
                        document.getElementById("txtselectorVhclName" + x).value = i.item.label;
                        // alert(i.item.val);
                        //alert(i.item.label);
                    },

                    minLength: 1

                });

            }

        }
        function selectorToAutocompleteProject(obj, x) {

            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;

            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;



            if (CorpId != '' && CorpId != null && (!isNaN(CorpId)) && OrgId != '' && OrgId != null && (!isNaN(OrgId))) {

                $("#" + obj + x).autocomplete({
                    source: function (request, response) {

                        $.ajax({
                            url: '<%=ResolveUrl("WebServiceJobshdlData.asmx/GetProject") %>',
                            data: "{ 'strLikeProjectName': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'intOrgId': '" + parseInt(OrgId) + "', 'intCorpId': '" + parseInt(CorpId) + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('<->')[0],
                                        val: item.split('<->')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                                //  alert(response.responseText);
                            },
                            failure: function (response) {
                                //  alert(response.responseText);
                            }
                        });
                    },
                    autoFocus: true,

                    select: function (e, i) {
                        document.getElementById("txtselectorPrjctId" + x).value = i.item.val;
                        document.getElementById("txtselectorPrjctName" + x).value = i.item.label;
                        // alert(i.item.val);
                        //alert(i.item.label);
                    },

                    minLength: 1

                });
            }

        }
        function selectorToAutocompleteTime(obj, x, TableName) {
         
           

            $("#" + obj + x).autocomplete({
                source: function (request, response) {

                  
                    var StartTime = '';
                    var StopTime = '';

                   
                  
                    if (TableName == 'TableaddedRowsDW') {
                        StartTime = document.getElementById("<%=hidden_DefalultStartTimeDayWise.ClientID%>").value.trim();
                        StopTime = document.getElementById("<%=hidden_DefalultEndTimeDayWise.ClientID%>").value.trim();

                       
                        

                       
                            }
                   

                
                            $.ajax({
                                url: '<%=ResolveUrl("WebServiceJobshdlData.asmx/GetTime") %>',
                                data: "{ 'strLikeTime': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'strStartTime': '" + StartTime.trim() + "', 'strStopTime': '" + StopTime.trim() + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                              
                                response($.map(data.d, function (item) {
                                 
                                    if (TableName == 'TableaddedRowsDW') {
                                        document.getElementById("<%=hiddenDayWiseTimeDifferenceSts.ClientID%>").value = item.split('<->')[2];
                                    }
                                    return {
                                        label: item.split('<->')[0],
                                        val: item.split('<->')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                                //  alert(response.responseText);
                            },
                            failure: function (response) {
                                // alert(response.responseText);
                            }
                        });
                        },
                        autoFocus: true,

                        select: function (e, i) {

                         

                            document.getElementById(obj + "Id" + x).value = i.item.label;

                        },

                        minLength: 1

                    });


          
            }

            function updateStartEnd() {
              

                var StartTime = '';
                var StopTime = '';

                var halfdatSts = '';
                var halfdaySection = '';
                var min = 0;
                  
              
                        StartTime = document.getElementById("<%=hidden_DefalultStartTimeDayWise.ClientID%>").value.trim();
                        StopTime = document.getElementById("<%=hidden_DefalultEndTimeDayWise.ClientID%>").value.trim();

                       
                        var elem = StartTime.split(' ');
                        var stSplit = elem[0].split(":");
                        var stHour = stSplit[0];
                        var stMin = stSplit[1];
                        var stAmPm = elem[1].toUpperCase();
                       

                        var elem1 = StopTime.split(' ');
                        var stSplit1 = elem1[0].split(":");
                        var stHour1 = stSplit1[0];
                        var stMin1 = stSplit1[1];
                        var stAmPm1 = elem1[1].toUpperCase();


                        var date1 = convertDateTo24Hour("06/10/2017 " + StartTime);
                        var date2 = convertDateTo24Hour("06/10/2017 " + StopTime);


                        if (stAmPm == stAmPm1) {
                            if (stAmPm == "AM") {
                                if (stHour > stHour1) {
                                    date1 = convertDateTo24Hour("06/10/2017 " + StartTime);
                                    date2 = convertDateTo24Hour("07/10/2017 " + StopTime);
                                }
                                else if (stHour == stHour1) {
                                    if (stMin > stMin1) {
                                        date1 = convertDateTo24Hour("06/10/2017 " + StartTime);
                                        date2 = convertDateTo24Hour("07/10/2017 " + StopTime);
                                    }
                                }
                            }



                            else {
                                if (stHour == stHour1) {
                                    if (stMin > stMin1) {
                                        date1 = convertDateTo24Hour("06/10/2017 " + StartTime);
                                        date2 = convertDateTo24Hour("07/10/2017 " + StopTime);
                                    }
                                }

                                else if (stHour1==12) {
                                    date1 = convertDateTo24Hour("06/10/2017 " + StartTime);
                                    date2 = convertDateTo24Hour("07/10/2017 " + StopTime);
                                
                                }
                            }
                        }
                        else if (stAmPm == "PM" && stAmPm1 == "AM") {
                            date1 = convertDateTo24Hour("06/10/2017 " + StartTime);
                            date2 = convertDateTo24Hour("07/10/2017 " + StopTime);
                        }



                        halfdatSts = document.getElementById("<%=HiddenHalfdayStatus.ClientID%>").value;
                        halfdaySection = document.getElementById("<%=HiddenHalfdaySection.ClientID%>").value;
                      

                        if (halfdatSts == "true") {

                          

                            var date1Split = date1.split(" ");
                            var date1Date = date1Split[0];
                            var date1DateDMY = date1Date.split("/");
                            var date1DateD = date1DateDMY[0];
                            var date1DateM = date1DateDMY[1];
                            var date1DateY = date1DateDMY[2];
                            var date1Time = date1Split[1];
                            var date1TimeSplit = date1Time.split(":");
                            var date1TimeHR = date1TimeSplit[0];
                            var date1TimeMn = date1TimeSplit[1];

                            var date2Split = date2.split(" ");
                            var date2Date = date2Split[0];
                            var date2DateDMY = date2Date.split("/");
                            var date2DateD = date2DateDMY[0];
                            var date2DateM = date2DateDMY[1];
                            var date2DateY = date2DateDMY[2];
                            var date2Time = date2Split[1];
                            var date2TimeSplit = date2Time.split(":");
                            var date2TimeHR = date2TimeSplit[0];
                            var date2TimeMn = date2TimeSplit[1];


                            var firstDate = new Date(date1DateY, date1DateM, date1DateD, date1TimeHR, date1TimeMn);
                            var secondDate = new Date(date2DateY, date2DateM, date2DateD, date2TimeHR, date2TimeMn);


                            var diff = (firstDate.getTime() - secondDate.getTime()) / 1000;
                            diff /= 60;
                            min = Math.abs(Math.round(diff)) / 2;
                            min = parseInt(min);
                        }

                       
                    
                   

                
                   
                   var Details = PageMethods.updateStartEnd(StartTime.trim(), StopTime.trim(), min, halfdaySection, function (response) {

                  
                       document.getElementById("<%=hidden_DefalultStartTimeDayWise.ClientID%>").value = response[0];
                       document.getElementById("<%=hidden_DefalultEndTimeDayWise.ClientID%>").value = response[1];
                });


            }


            function selectorToAutocompleteTimeEdit(obj, x, TableName) {

              
                var objVal = document.getElementById(obj + "Id" + x).value;

            
            

                        var StartTime = '';
                        var StopTime = '';

                        var halfdatSts = '';
                        var halfdaySection = '';
                        var min = 0;

                        if (TableName == 'TableaddedRowsDW') {

                           
                            StartTime = document.getElementById("<%=hidden_DefalultStartTimeDayWise.ClientID%>").value.trim();
                        StopTime = document.getElementById("<%=hidden_DefalultEndTimeDayWise.ClientID%>").value.trim();


                        var elem = StartTime.split(' ');
                        var stSplit = elem[0].split(":");
                        var stHour = stSplit[0];
                        var stMin = stSplit[1];
                        var stAmPm = elem[1].toUpperCase();


                        var elem1 = StopTime.split(' ');
                        var stSplit1 = elem1[0].split(":");
                        var stHour1 = stSplit1[0];
                        var stMin1 = stSplit1[1];
                        var stAmPm1 = elem1[1].toUpperCase();


                        var date1 = convertDateTo24Hour("06/10/2017 " + StartTime);
                        var date2 = convertDateTo24Hour("06/10/2017 " + StopTime);


                        if (stAmPm == stAmPm1) {
                            if (stAmPm == "AM") {
                                if (stHour > stHour1) {
                                    date1 = convertDateTo24Hour("06/10/2017 " + StartTime);
                                    date2 = convertDateTo24Hour("07/10/2017 " + StopTime);
                                }
                                else if (stHour == stHour1) {
                                    if (stMin > stMin1) {
                                        date1 = convertDateTo24Hour("06/10/2017 " + StartTime);
                                        date2 = convertDateTo24Hour("07/10/2017 " + StopTime);
                                    }
                                }
                            }



                            else {
                                if (stHour == stHour1) {
                                    if (stMin > stMin1) {
                                        date1 = convertDateTo24Hour("06/10/2017 " + StartTime);
                                        date2 = convertDateTo24Hour("07/10/2017 " + StopTime);
                                    }
                                }

                                else if (stHour1 == 12) {
                                    date1 = convertDateTo24Hour("06/10/2017 " + StartTime);
                                    date2 = convertDateTo24Hour("07/10/2017 " + StopTime);

                                }
                            }
                        }
                        else if (stAmPm == "PM" && stAmPm1 == "AM") {
                            date1 = convertDateTo24Hour("06/10/2017 " + StartTime);
                            date2 = convertDateTo24Hour("07/10/2017 " + StopTime);
                        }



                        halfdatSts = document.getElementById("<%=HiddenHalfdayStatus.ClientID%>").value;
                        halfdaySection = document.getElementById("<%=HiddenHalfdaySection.ClientID%>").value;


                        if (halfdatSts == "true") {

                           

                            var date1Split = date1.split(" ");
                            var date1Date = date1Split[0];
                            var date1DateDMY = date1Date.split("/");
                            var date1DateD = date1DateDMY[0];
                            var date1DateM = date1DateDMY[1];
                            var date1DateY = date1DateDMY[2];
                            var date1Time = date1Split[1];
                            var date1TimeSplit = date1Time.split(":");
                            var date1TimeHR = date1TimeSplit[0];
                            var date1TimeMn = date1TimeSplit[1];

                            var date2Split = date2.split(" ");
                            var date2Date = date2Split[0];
                            var date2DateDMY = date2Date.split("/");
                            var date2DateD = date2DateDMY[0];
                            var date2DateM = date2DateDMY[1];
                            var date2DateY = date2DateDMY[2];
                            var date2Time = date2Split[1];
                            var date2TimeSplit = date2Time.split(":");
                            var date2TimeHR = date2TimeSplit[0];
                            var date2TimeMn = date2TimeSplit[1];


                            var firstDate = new Date(date1DateY, date1DateM, date1DateD, date1TimeHR, date1TimeMn);
                            var secondDate = new Date(date2DateY, date2DateM, date2DateD, date2TimeHR, date2TimeMn);


                            var diff = (firstDate.getTime() - secondDate.getTime()) / 1000;
                            diff /= 60;
                            min = Math.abs(Math.round(diff)) / 2;
                            min = parseInt(min);
                        }


                    }
              

                  
                    $.ajax({
                        url: '<%=ResolveUrl("WebServiceJobshdlData.asmx/GetTimeDutyrstr") %>',
                        data: "{ 'strLikeTime': '" + objVal + "', 'strStartTime': '" + StartTime.trim() + "', 'strStopTime': '" + StopTime.trim() + "','strHalfTime': '" + min + "','strHalfSec': '" + halfdaySection + "'}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {
                                   
                                 
                                    if (data.d == "") {
                                        document.getElementById(obj + "Id" + x).value = "--Select Time--";
                                        document.getElementById(obj + x).value = "--Select Time--";
                                    }
                                  
                                    response($.map(data.d, function (item) {
                                      
                                      

                                        if (TableName == 'TableaddedRowsDW') {
                                            document.getElementById("<%=hiddenDayWiseTimeDifferenceSts.ClientID%>").value = item.split('<->')[2];
                                    }
                                    return {
                                        label: item.split('<->')[0],
                                        val: item.split('<->')[1]
                                    }
                                    }))


                                   
                                  
                                      
                                      


                                  
                            },
                                error: function (response) {
                                    //  alert(response.responseText);
                                },
                                failure: function (response) {
                                    // alert(response.responseText);
                                }
                            });
              
               
            }





            function TimeSlotSelected(SlotId, PeriodOrDayWise) {
               
                var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;

            if (CorpId != '' && CorpId != null && OrgId != '' && OrgId != null && SlotId.toString() != '' && SlotId != null && SlotId != '--SELECT TIME SLOT--') {
                //   alert('hi entered');
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_Duty_Roster.aspx/TimeSlotDetails",
                    data: '{corporateId: "' + CorpId + '",organisationId:"' + OrgId + '" ,SLOTID:"' + SlotId + '"}',
                    dataType: "json",
                    success: function (data) {

                        if (data.d != '') {
                            if (PeriodOrDayWise == 'DayWise') {

                               
                                     document.getElementById("<%=hidden_DefalultStartTimeDayWise.ClientID%>").value = data.d.strStartTime;
                                     document.getElementById("<%=hidden_DefalultEndTimeDayWise.ClientID%>").value = data.d.strEndTime;

                                     updateStartEnd();
                                 }
                                
                             }
                         },
                         error: function (result) {
                             // alert("Error");
                         }
                     });

                 }
             }
             function fun() {

                 alert('dfg');
             }
             function ClearAll(TableName, ClearAllDayWiseField) {
                 var $noC = jQuery.noConflict();
                 //$("#TableaddedRowsDW tr").remove();
                 //  addMoreRows(this.form, false, 1, false, 0, 'TableaddedRowsDW');
                 //   alert('clearall');

                 var table = document.getElementById(TableName);

                 //  for (var i = 0, row; row = table.rows[i]; i++) {
                 for (var i = table.rows.length - 1; i >= 0; i--) {

                     var row = table.rows[i];
                     if (row != null) {
                         //iterate through rows
                         //rows would be accessed using the "row" variable assigned in the for loop
                         for (var j = 0, col; col = row.cells[j]; j++) {
                             if (j == 0) {
                                 x = col.innerHTML;
                                 // alert('1 ' + x);
                                 removeRow(x, 'Are you sure you want to Delete this Entry?', false, TableName);

                             }

                             //iterate through columns
                             //columns would be accessed using the "col" variable assigned in the for loop
                             // alert(col.innerHTML);
                         }
                     }
                 }

                 return false;

             }
    </script>

    <script>
        var $NonCon = jQuery.noConflict();
        function ShowJobShedule(EmpName, EmpId, TodayDate,HalfDayStatus,HalfDaySection) {

            document.getElementById("<%=HiddenHalfdayStatus.ClientID%>").value = HalfDayStatus;
            document.getElementById("<%=HiddenHalfdaySection.ClientID%>").value = HalfDaySection;


            document.getElementById("lblTodayDate").innerHTML = TodayDate;
            document.getElementById("lblEmployeeName").innerText = EmpName;
            document.getElementById("<%=HiddenFieldEmployeeId.ClientID%>").value = EmpId;
            document.getElementById("<%=HiddenFieldDate.ClientID%>").value = TodayDate;


           


            document.getElementById("<%=hiddenLeaveMarkDetails.ClientID%>").value = EmpId + "," + TodayDate;
            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
            $NonCon.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_Duty_Roster.aspx/DayWiseJobShdl",
                data: '{intCorpId: "' + CorpId + '",intOrgId:"' + OrgId + '" ,EmpId:"' + EmpId + '",DatePass:"' + TodayDate + '"}',
                dataType: "json",
                success: function (data) {


                    if (data.d[0] != '' && data.d[0] != null) {

                        var EditValDayWise = data.d[0];
                        if (EditValDayWise != "") {

                            var find2 = '\\"\\[';
                            var re2 = new RegExp(find2, 'g');
                            var res2 = EditValDayWise.replace(re2, '\[');

                            var find3 = '\\]\\"';
                            var re3 = new RegExp(find3, 'g');
                            var res3 = res2.replace(re3, '\]');
                       
                            var json = $noCon.parseJSON(res3);

                          
                            //Start:-Emp-0009
                            document.getElementById("<%=hiddenDutyMasterId.ClientID%>").value = "0";
                     
                            document.getElementById("<%=hiddenddlTimeSlotPWVal.ClientID%>").value = json[0].TmsltId;

                            document.getElementById("<%=hiddenddlTimeSlotDWVal.ClientID%>").value = json[0].TmsltId;

                            document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>").value = json[0].TmsltId;

                            var a = $noC("#cphMain_ddlTimeSlot_DayWise option:selected").text();
                            $noC("div#divTimeSlotDayWise input.ui-autocomplete-input").val(a);

                            ChangeTimeSlot('ddlTimeSlot_DayWise');
                          
                            //Stop:-Emp-0009


                            for (var key in json) {
                                if (json.hasOwnProperty(key)) {
                                    if (json[key].TransId != "") {

                                          var TableName = "TableAddtnlJobs";
                                        
                                             

                                        EditListRows(json[key].JobId, json[key].JobName, json[key].VhclNumbr, json[key].VhclId, json[key].PrjctId, json[key].PrjctName, json[key].FromTime, json[key].ToTime, json[key].JobMode, json[key].txtJobName, json[key].TransDtlId, json[key].DutyOrJobShdl, 'TableaddedRowsDW', 'INS');

                                       
                                    }
                                }
                            }
                        }

                        addMoreRows(this.form, false, 1, false, 0, 'TableaddedRowsDW');

                    }
                    else if (data.d[2] != '' && data.d[2] != null) {
                        var EditValDayWise = data.d[2];
                        if (EditValDayWise != "") {

                            var find2 = '\\"\\[';
                            var re2 = new RegExp(find2, 'g');
                            var res2 = EditValDayWise.replace(re2, '\[');

                            var find3 = '\\]\\"';
                            var re3 = new RegExp(find3, 'g');
                            var res3 = res2.replace(re3, '\]');
                            //   alert('res3' + res3);
                            var json = $noCon.parseJSON(res3);

                           
                            //Start:-Emp-0009
                            document.getElementById("<%=hiddenDutyMasterId.ClientID%>").value = json[0].TransId;
                      
                            document.getElementById("<%=hiddenddlTimeSlotPWVal.ClientID%>").value = json[0].TmsltId;

                            document.getElementById("<%=hiddenddlTimeSlotDWVal.ClientID%>").value = json[0].TmsltId;

                            document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>").value = json[0].TmsltId;

                            var a = $noC("#cphMain_ddlTimeSlot_DayWise option:selected").text();
                            $noC("div#divTimeSlotDayWise input.ui-autocomplete-input").val(a);

                            ChangeTimeSlot('ddlTimeSlot_DayWise');
                           
                            //Stop:-Emp-0009


                            for (var key in json) {
                                if (json.hasOwnProperty(key)) {
                                    if (json[key].TransId != "") {

                                        

                                        EditListRows(json[key].JobId, json[key].JobName, json[key].VhclNumbr, json[key].VhclId, json[key].PrjctId, json[key].PrjctName, json[key].FromTime, json[key].ToTime, json[key].JobMode, json[key].txtJobName, json[key].TransDtlId, json[key].DutyOrJobShdl, 'TableaddedRowsDW', 'UPD');

                                    }
                                }
                            }
                        }

                        addMoreRows(this.form, false, 1, false, 0, 'TableaddedRowsDW');
                    }

                    else {
                        addMoreRows(this.form, false, 1, false, 0, 'TableaddedRowsDW');
                        document.getElementById("<%=hiddenDutyMasterId.ClientID%>").value = "0";
                    }


                    if (data.d[1] != "" && data.d[1] != null) {
                        var EditValVeh = data.d[1];
                        if (EditValVeh != "") {

                            var find2 = '\\"\\[';
                            var re2 = new RegExp(find2, 'g');
                            var res2 = EditValVeh.replace(re2, '\[');

                            var find3 = '\\]\\"';
                            var re3 = new RegExp(find3, 'g');
                            var res3 = res2.replace(re3, '\]');
                            //   alert('res3' + res3);
                            var json = $noCon.parseJSON(res3);
                            for (var key in json) {
                                if (json.hasOwnProperty(key)) {
                                    if (json[key].VhclId != "") {

                                       
                                        EditVehicleRows(json[key].VhclId, json[key].VhclNumbr, json[key].Mileage);

                                     
                                    }
                                }
                            }
                        }
                        document.getElementById("divVehicleDataContainer").style.display = "block";
                    }

                    else {
                    

                    }
                },
                error: function (result) {
                  
                }
            });
            $("body").css('overflow', 'hidden');
            document.getElementById("MyModalJobShedule").style.display = "block";
            document.getElementById("freezelayer").style.display = "";
        return false;
    }


    function ClosJobShedule() {
        document.getElementById("MyModalJobShedule").style.display = "none";
        document.getElementById("freezelayer").style.display = "none";
        jQuery('#TableaddedRowsDW tr').remove();
        jQuery('#TableVehicle tr').remove();
        InitializeVehi();

        document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>").value = '--SELECT TIME SLOT--';

            var a = $noC("#cphMain_ddlTimeSlot_DayWise option:selected").text();
            $noC("div#divTimeSlotDayWise input.ui-autocomplete-input").val(a);

            document.getElementById("<%=ddlTimeSlot_DayWise.ClientID%>").disabled = false;
            $("div#divTimeSlotDayWise input.ui-autocomplete-input").removeAttr('disabled');

            document.getElementById("<%=HiddenField2.ClientID%>").value = "";
        document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";

        document.getElementById('divErrorNotificationDW').style.visibility = "hidden";
        document.getElementById("<%=lblErrorNotificationDW.ClientID%>").innerHTML = "";
        localStorage.clear();

        $("body").css('overflow', 'auto');
        }
    </script>
    
    <script>
        //Start:-EVM-0009
        var $cc = jQuery.noConflict();
        //For creating dutyslip
        function createDutySlip(TodayDate) {

            document.getElementById("myModalLoadingMail").style.display = "block";
            document.getElementById("freezelayer").style.display = "";

            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
            var LogUserId = document.getElementById("<%=HiddenFieldLoginUserId.ClientID%>").value;
            $cc.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_Duty_Roster.aspx/createDutySlip",
                data: '{intCorpId: "' + CorpId + '",intOrgId:"' + OrgId + '",intLogUserId:"' + LogUserId + '" ,DatePass:"' + TodayDate + '"}',
                dataType: "json",
                success: function (data) {

                    SuccessCreationDutySlp();

                },
                error: function (result) {

                }
            });
            document.getElementById("myModalLoadingMail").style.display = "none";
            document.getElementById("freezelayer").style.display = "none";
            return false;

        }
        function ShowJobSheduleSubmit(EmpName, EmpId, TodayDate,printSts) {

            document.getElementById("<%=HiddenFieldSubmissionId.ClientID%>").value = "";

            document.getElementById("<%=HiddenFieldEmployeeId.ClientID%>").value = EmpId;
             document.getElementById("<%=HiddenFieldDate.ClientID%>").value = TodayDate;

             document.getElementById("MyModalJobSubmit").style.display = "block";
             document.getElementById("freezelayer").style.display = "";
             document.getElementById("lblSubDate").innerHTML = TodayDate;
             document.getElementById("lblSubName").innerText = EmpName;

          

             var dateFill = TodayDate.replace(/-/g, "/");


             var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
             $NonCon.ajax({
                 type: "POST",
                 async: false,
                 contentType: "application/json; charset=utf-8",
                 url: "gen_Duty_Roster.aspx/DayWiseDutySlipDtl",
                 data: '{intCorpId: "' + CorpId + '",intOrgId:"' + OrgId + '" ,EmpId:"' + EmpId + '",DatePass:"' + TodayDate + '"}',
                 dataType: "json",
                 success: function (data) {

                     document.getElementById("cphMain_btnSubSave").style.display = "block";

                   


                         if (data.d[0] != '' && data.d[0] != null && printSts == "1") {

                             var EditValDayWise = data.d[0];
                             if (EditValDayWise != "") {

                                 var rowCount = 0;
                                 var recRow = "";
                                 var nrmlWrkHr = 0;

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
                                         if (json[key].TransId != "") {


                                             document.getElementById("<%=HiddenFieldDutyRostrId.ClientID%>").value = json[key].TransId;

                                             rowCount++;
                                             recRow += '<label style="color: #0948b6;font-size: 19px;margin-top: 3px;float: left;width: 100%;cursor:inherit;font-family: calibri;">Schedule Job</label>';
                                             recRow += '<table id="tableScdlJob' + rowCount + '" style="width:60%;border: 1px solid;">';

                                             recRow += '<tr >';
                                             recRow += '<td class="TableHeader">From</td>';
                                             recRow += '<td class="TableHeader">To</td>';
                                             recRow += '<td class="TableHeader">Vehicle</td>';
                                             recRow += '<td class="TableHeader">Job</td>';
                                             recRow += '</tr>';

                                             recRow += '<td id="tdDutyrstrDtlID' + rowCount + '" style="display: none;">' + json[key].TransDtlId + '</td>';

                                             recRow += ' <td id="tdFrmTimeSelect' + rowCount + '" style="width: 8%;"><div class="Cls' + rowCount + '">';
                                             recRow += ' <input disabled style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtScdlJobFrmTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text"  value="' + json[key].FromTime + '" /> ';
                                             recRow += ' </div> </td> ';

                                             recRow += ' <td id="tdToTimeSelect' + rowCount + '" style="width: 8%;"><div class="Cls' + rowCount + '">';
                                             recRow += ' <input disabled style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtScdlJobToTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text"  value="' + json[key].ToTime + '" /> ';
                                             recRow += ' </div> </td> ';

                                             recRow += ' <td id="tdVhclSelect' + rowCount + '" style="width: 19.5%;"><div class="Cls' + rowCount + '">';
                                             recRow += ' <input disabled style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%;" id="txtScdlJobVhcl' + rowCount + '" class="BillngEntryField" type="text"  value="' + json[key].VhclNumbr + '"  /> ';
                                             recRow += ' </div> </td> ';
                                             recRow += ' <td  style="display: none;"><input id="txtselectorVhclId' + rowCount + '"  value="' + json[key].VhclId + '" type="text"   /></td>';

                                             recRow += ' <td id="tdJobText' + rowCount + '"  style="width: 20%;">';
                                             recRow += ' <input disabled id="txtScdlJobName' + rowCount + '"  class="BillngEntryField"  type="text" value="' + json[key].txtJobName + '" style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%;" />';
                                             recRow += '   </td> ';

                                             recRow += '</tr>';
                                             recRow += '</table>';

                                             recRow += '<label style="color: #962a00;font-size: 19px;margin-top: 3px;float: left;width: 100%;cursor:inherit;font-family: calibri;">Job Submission</label>';
                                             recRow += '<table id="tableJobSbmsn' + rowCount + '" style="width:90%;border: 1px solid;">';
                                             recRow += '<tr >';
                                             recRow += '<td class="TableHeader">Date & Time From</td>';
                                             recRow += '<td class="TableHeader">Date & Time To</td>';
                                             recRow += '<td class="TableHeader">Status</td>';
                                             recRow += '<td class="TableHeader">Present Mileage</td>';
                                             recRow += '<td class="TableHeader">Description</td>';
                                             recRow += '</tr>';

                                             recRow += ' <td id="tdFrmDateTimeSelect' + rowCount + '" style="width: 20%;"><div class="Cls' + rowCount + '">';







                                             recRow += ' <input  placeholder="DD/MM/YYYY HH:MM PM"  style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtselectorFrmDateTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text" onkeydown="return isTagDate(event)"  onblur=" BlurJSTime(\'txtselectorFrmDateTime\',' + rowCount + ',\'Time\')"  value="' + dateFill+" "+json[key].FromTime + '" /> ';
                                             //recRow += ' <span class="add-on"><i data-time-icon="icon-time" data-date-icon="icon-calendar"> </i>  </span> ';
                                             recRow += ' </div> </td> ';

                                             recRow += ' <td id="tdToDateTimeSelect' + rowCount + '" style="width: 20%;"><div class="Cls' + rowCount + '">';
                                             recRow += ' <input placeholder="DD/MM/YYYY HH:MM PM"  style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtselectorToDateTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text" onkeydown="return isTagDate(event)" onblur=" BlurJSTime(\'txtselectorToDateTime\',' + rowCount + ',\'Time\')" value="' +dateFill+" "+ json[key].ToTime + '"   /> ';
                                             recRow += ' </div> </td> ';

                                             recRow += ' <td id="tdStatusSelect' + rowCount + '" style="width: 13%;"><div class="Cls' + rowCount + '">';
                                             //recRow += ' <input  style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%;" id="txtselectorStatus' + rowCount + '" class="BillngEntryField" type="text" value="complete"   /> ';
                                             recRow += '<select id="txtselectorStatus' + rowCount + '" style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%;height:26px;" onkeydown="return isTag(event)" ></select>';
                                             recRow += ' </div> </td> ';

                                             recRow += ' <td id="tdPrntMlge' + rowCount + '"  style="width: 13%;">';
                                             recRow += ' <input  id="txtPrsntMlge' + rowCount + '"  class="BillngEntryField"  type="text"  maxlength=7  style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%;" onkeydown="return isNumber(event)" />';
                                             recRow += '   </td> ';

                                             recRow += ' <td id="tdDescpnText' + rowCount + '"  style="width: 34%;">';
                                             recRow += ' <input  id="txtDescpn' + rowCount + '"  class="BillngEntryField"  type="text" maxlength=500  style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%;" onkeydown="return isTag(event)" onblur="return BlurDesc(' + rowCount + ')" />';
                                             recRow += ' </td> ';

                                             recRow += '</tr>';
                                             recRow += '</table>';




                                             //Start:-To calculate Normal Work Hour                                    
                                             var timeStart = new Date("01/01/2007 " + json[key].FromTime);
                                             var timeEnd = new Date("01/01/2007 " + json[key].ToTime);
                                             nrmlWrkHr = nrmlWrkHr + (Math.abs(timeEnd - timeStart) / 36e5);
                                             //End:-To calculate Normal Work Hour


                                            


                                         }
                                     }
                                 }
                                 document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value = rowCount;
                                 document.getElementById("divTableSdlJob&JobSub").innerHTML = recRow;

                                
                              

                                 for (var i = 1; i <= rowCount; i++) {
                                     bindStatus(i);




                                     //                          var $noC = jQuery.noConflict();

                                     //                          $noC('#txtselectorFrmDateTime' + i).datetimepicker({
                                     //    language: 'en',
                                     //    pick12HourFormat: true
                                     //});


                                     //var $noC = jQuery.noConflict();
                                     //$noC('#txtselectorFrmDateTime'+i).datetimepicker({
                                     //     format: 'dd/MM/yyyy hh:mm A',
                                     //     language: 'en',
                                     //     pickTime: true,
                                     //     startDate: new Date(),
                                     //     pick12HourFormat: true,
                                     //     pickSeconds: false,                             


                                     // });
                                     //$noC('#txtselectorToDateTime' + i).datetimepicker({
                                     //    format: 'dd/MM/yyyy hh:mm A',
                                     //    language: 'en',
                                     //    pickTime: true,
                                     //    startDate: new Date(),
                                     //    pick12HourFormat: true,
                                     //    pickSeconds: false,

                                     //});

                                     var $NonConfli = jQuery.noConflict();
                                     $NonConfli.datetimepicker.setLocale('en');
                                     $NonConfli('#txtselectorFrmDateTime' + i).datetimepicker({
                                         dayOfWeekStart: 1,
                                         lang: 'en',
                                         startDate: new Date,
                                         step: 10,
                                         format: 'd/m/Y h:i a',
                                     });

                                     $NonConfli('#txtselectorToDateTime' + i).datetimepicker({
                                         dayOfWeekStart: 1,
                                         lang: 'en',
                                         startDate: new Date,
                                         step: 10,
                                         format: 'd/m/Y h:i a',
                                     });

                                 }

                                 //For time sheet table
                                 var recRow = '<h2 >Time Sheet</h2>'
                                 recRow += '<table id="tableTimeSheet" style="width:100%;">';

                                 recRow += '<tr >';
                                 recRow += '<td class="TableHeader">Date & Time Start</td>';
                                 recRow += '<td class="TableHeader">Date & Time End</td>';
                                 recRow += '<td class="TableHeader">Total Work Hour</td>';
                                 recRow += '<td class="TableHeader">Normal Work Hour</td>';
                                 recRow += '<td class="TableHeader">Idle Hours</td>';
                                 recRow += '<td class="TableHeader">Final O.T</td>';
                                 recRow += '<td class="TableHeader">Rounded O.T</td>';
                                 recRow += '</tr>';

                                 recRow += ' <td id="tdTimeSheetStartDate&Time" style="width: 20%;"><div class="Cls">';
                                 recRow += ' <input disabled placeholder="DD/MM/YYYY HH:MM PM"  style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtTimeSheetStartDateTime" class="BillngEntryField TimeEntry" type="text" onblur=" BlurJSTime(\'txtTimeSheetStartDateTime\',\'\',\'Time\')"  /> ';
                                 recRow += ' </div> </td> ';

                                 recRow += ' <td id="tdTimeSheetEndDate&Time" style="width: 20%;"><div class="Cls">';
                                 recRow += ' <input disabled placeholder="DD/MM/YYYY HH:MM PM"  style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtTimeSheetEndDateTime" class="BillngEntryField TimeEntry" type="text" onblur=" BlurJSTime(\'txtTimeSheetEndDateTime\',\'\',\'Time\')"   /> ';
                                 recRow += ' </div> </td> ';

                                 recRow += ' <td id="tdTotalWrkHr" style="width: 12%;"><div class="Cls">';
                                 recRow += ' <input disabled style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%;" id="txtTotalWrkHr" class="BillngEntryField" type="text"   /> ';
                                 recRow += ' </div> </td> ';

                                 recRow += ' <td id="tdNrmlWrkHr"  style="width: 12%;">';
                                 recRow += ' <input disabled id="txtNrmlWrkHr"  class="BillngEntryField"  type="text"  style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%;" />';
                                 recRow += '   </td> ';

                                 recRow += ' <td id="tdIdleHrs"  style="width: 12%;">';
                                 recRow += ' <input disabled id="txtIdleHrs"  class="BillngEntryField"  type="text"  style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%;" maxlength=8 onblur="return BlurIdleHr()" onkeydown="return isNumberDec(event)" />';
                                 recRow += ' </td> ';

                                 recRow += ' <td id="tdFianlOT"  style="width: 12%;">';
                                 recRow += ' <input disabled  id="txtFinalOT"  class="BillngEntryField"  type="text"  style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%;" />';
                                 recRow += ' </td> ';

                                 recRow += ' <td id="tdRoundedOT"  style="width: 12%;">';
                                 recRow += ' <input disabled  id="txtRoundedOT"  class="BillngEntryField"  type="text"  style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%;" maxlength=8 onblur="return BlurRoundedOT()" onkeydown="return isNumberDec(event)" />';
                                 recRow += ' </td> ';

                                 recRow += '</tr>';
                                 recRow += '</table>';

                                 document.getElementById("divTimeSheet").innerHTML = recRow;

                                 document.getElementById("txtNrmlWrkHr").value = nrmlWrkHr.toFixed(2);


                             }

                             document.getElementById("cphMain_btnSubSave").value = "SAVE";
                             //Start:-For Showing already submitted details if any

                             //For time sheet table
                             if (data.d[1] != '' && data.d[1] != null) {
                                 var EditValDayWise = data.d[1];
                                 if (EditValDayWise != "") {
                                     var find2 = '\\"\\[';
                                     var re2 = new RegExp(find2, 'g');
                                     var res2 = EditValDayWise.replace(re2, '\[');
                                     var find3 = '\\]\\"';
                                     var re3 = new RegExp(find3, 'g');
                                     var res3 = res2.replace(re3, '\]');
                                     var json = $noCon.parseJSON(res3);
                                     document.getElementById("<%=HiddenFieldSubmissionId.ClientID%>").value = json[0].TransId;
                                     for (var key in json) {
                                         if (json.hasOwnProperty(key)) {
                                             if (json[key].TransId != "") {


                                                 document.getElementById("txtTimeSheetStartDateTime").value = json[key].FromTime;
                                                 document.getElementById("txtTimeSheetEndDateTime").value = json[key].ToTime;
                                                 document.getElementById("txtTotalWrkHr").value = json[key].TotalWrkHr;
                                                 document.getElementById("txtNrmlWrkHr").value = json[key].NrmlWrkHr;
                                                 document.getElementById("txtIdleHrs").value = json[key].IdleHr;
                                                 document.getElementById("txtFinalOT").value = json[key].FinalOT;
                                                 document.getElementById("txtRoundedOT").value = json[key].RoundedOT;

                                             }
                                         }
                                     }
                                 }

                                 document.getElementById("cphMain_btnSubConfirm").style.display = "block";
                                 document.getElementById("cphMain_btnSubSave").value = "UPDATE";

                                 document.getElementById("txtIdleHrs").disabled = false;
                                 if (json[0].FinalOT != "") {
                                     document.getElementById("txtRoundedOT").disabled = false;
                                 }
                                 if (json[0].CnfrmStsId == "1") {

                                     document.getElementById("<%=HiddenFieldConfrmSts.ClientID%>").value = "1";
                                     document.getElementById("cphMain_btnSubConfirm").style.display = "none";
                                     document.getElementById("cphMain_btnSubSave").style.display = "none";
                                     document.getElementById("cphMain_btnSubReopen").style.display = "block";
                                     document.getElementById("txtIdleHrs").disabled = true;
                                     document.getElementById("txtRoundedOT").disabled = true;
                                 }
                             }

                             //For job submission tables
                             if (data.d[2] != '' && data.d[2] != null) {

                                 var EditValDayWise = data.d[2];
                                 if (EditValDayWise != "") {

                                     var x = 0;
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
                                             if (json[key].TransId != "") {

                                                 x++;
                                                 document.getElementById("txtselectorFrmDateTime" + x).value = json[key].FromTime;
                                                 document.getElementById("txtselectorToDateTime" + x).value = json[key].ToTime;
                                                 document.getElementById("txtselectorStatus" + x).value = json[key].SbmsnStsId;
                                                 document.getElementById("txtPrsntMlge" + x).value = json[key].VhclPrsntMlg;
                                                 document.getElementById("txtDescpn" + x).value = json[key].Desc;

                                                 if (document.getElementById("<%=HiddenFieldConfrmSts.ClientID%>").value == "1") {
                                                     document.getElementById("txtselectorFrmDateTime" + x).disabled = true;
                                                     document.getElementById("txtselectorToDateTime" + x).disabled = true;
                                                     document.getElementById("txtselectorStatus" + x).disabled = true;
                                                     document.getElementById("txtPrsntMlge" + x).disabled = true;
                                                     document.getElementById("txtDescpn" + x).disabled = true;


                                                 }


                                             }
                                         }
                                     }
                                 }
                             }
                             //For additional jobs table
                             if (data.d[3] != '' && data.d[3] != null) {

                                 var EditValDayWise = data.d[3];
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
                                             if (json[key].TransId != "") {

                                                 EditListRowsAddtnlJobs(json[key].JobId, json[key].JobName, json[key].VhclNumbr, json[key].VhclId, json[key].FromTime, json[key].ToTime, json[key].txtJobName, json[key].TransDtlId);

                                             }
                                         }
                                     }
                                 }
                                 addMoreRowsAddtnlJobs(this.form, false, 1, false, 0);

                                 if (document.getElementById("<%=HiddenFieldConfrmSts.ClientID%>").value == "1") {
                                     var x = document.getElementById("<%= HiddenFieldAddtnlJobRowCount.ClientID%>").value;


                                     for (var i = 1; i <= x; i++) {
                                         document.getElementById("txtselectorFrmTime" + i).disabled = true;
                                         document.getElementById("txtselectorToTime" + i).disabled = true;
                                         document.getElementById("txtselectorVhcl" + i).disabled = true;
                                         document.getElementById("txtselectorJob" + i).disabled = true;
                                         document.getElementById("divAddtnlJobs").style.pointerEvents = "none";

                                     }

                                 }

                             }
                             else {

                                 addMoreRowsAddtnlJobs(this.form, false, 1, false, 0);
                                 if (document.getElementById("<%=HiddenFieldConfrmSts.ClientID%>").value == "1") {
                                     var x = document.getElementById("<%= HiddenFieldAddtnlJobRowCount.ClientID%>").value;
                                     for (var i = 1; i <= x; i++) {
                                         document.getElementById("txtselectorFrmTime" + i).disabled = true;
                                         document.getElementById("txtselectorToTime" + i).disabled = true;
                                         document.getElementById("txtselectorVhcl" + i).disabled = true;
                                         document.getElementById("txtselectorJob" + i).disabled = true;
                                        
                                     }

                                 }
                             }
                             //End:-For Showing already submitted details if any

                             BlurJSTime("txtselectorFrmDateTime", 1, "Time");
                             BlurJSTime("txtselectorToDateTime", 1, "Time");
                         }


                         else {

                             ClosJobSubmit();
                             if (data.d[0] == '' || data.d[0] == null) {
                                 alert('DutySlip Is Not Created For the day.');
                             }
                             else if (printSts!="1") {
                                 alert('DutySlip Is Not Printed For the day.');
                             }
                         }
                    
                },
                error: function (result) {

                }
            });


            return false;

        }
        function bindStatus(x) {


            var $coo = jQuery.noConflict();
            var ddlTestDropDownListXML = $coo(document.getElementById("txtselectorStatus" + x));

            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableDivision";
            if (document.getElementById("<%=HiddenFieldStatusDropdown.ClientID%>").value != 0) {
                dropdowndata = document.getElementById("<%=HiddenFieldStatusDropdown.ClientID%>").value;
                $noCon(dropdowndata).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $coo(this).find('SUBMTNSTS_ID').text();
                    var OptionText = $coo(this).find('SUBMTNSTS_NAME').text();
                    // Create an Option for DropDownList.
                    var option = $coo("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);
                    ddlTestDropDownListXML.append(option);
                });

            }

        }
        function ClosJobSubmit() {

            document.getElementById("MyModalJobSubmit").style.display = "none";
            document.getElementById("freezelayer").style.display = "none";
            jQuery('#TableAddtnlJobs tr').remove();
            document.getElementById("cphMain_btnSubConfirm").style.display = "none";
            document.getElementById("cphMain_btnSubReopen").style.display = "none";
            document.getElementById("<%=HiddenFieldConfrmSts.ClientID%>").value = "";
            document.getElementById("<%=HiddenFieldCancelAddtnJobDtlId.ClientID%>").value = "";
            document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value = "";
            document.getElementById("<%= HiddenFieldAddtnlJobRowCount.ClientID%>").value = "";
            InitializeAdd();
            document.getElementById('divErrorNotificationSb').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "";
        }


    </script>
    <script type="text/javascript">

        var $noC = jQuery.noConflict();
        var rowCount = 0;
        //rowCount for uniquness
        //row index add(+) and (-)delete count based on action
        function InitializeAdd() {
            rowCount = 0;
        }
        var RowIndex = 0;
        function addMoreRowsAddtnlJobs(frm, boolFocus, JobMode, boolAppendorNot, row_index) {

            rowCount++;
            RowIndex++;

            document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


            var recRow = '<tr id="rowId_' + rowCount + '" >';
            recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';



            recRow += ' <td id="tdFrmTimeSelect' + rowCount + '" style="width: 17%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input placeholder="DD/MM/YYYY HH:MM PM" style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtselectorFrmTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text"    onkeypress="return isTagName(\'txtselectorFrmTime' + rowCount + '\',\'txtselectorToTime' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return isTagDate(event)"     onblur=" BlurJSTime(\'txtselectorFrmTime\',' + rowCount + ',\'Time\')" onfocus="return FocusJSTime(\'txtselectorFrmTime\',' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' <td  style="display: none;"><input id="txtselectorFrmTimeId' + rowCount + '"  value="--Select Time--" type="text" maxlength=100  /></td>';


            recRow += ' <td id="tdToTimeSelect' + rowCount + '" style="width: 17%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input placeholder="DD/MM/YYYY HH:MM PM" style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtselectorToTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text"   onkeypress="return isTagName(\'txtselectorToTime' + rowCount + '\',\'tdIndvlAddMoreRowPic' + rowCount + '\',' + rowCount + ', event)" onkeydown="return isTagDate(event)"     onblur=" BlurJSTime(\'txtselectorToTime\',' + rowCount + ',\'Time\')" onfocus="return FocusJSTime(\'txtselectorToTime\',' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' <td  style="display: none;"><input id="txtselectorToTimeId' + rowCount + '"  value="--Select Time--" type="text" maxlength=100  /></td>';


            recRow += ' <td id="tdVhclSelect' + rowCount + '" style="width: 17%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 100%;margin-left: 0.1%;" id="txtselectorVhcl' + rowCount + '" class="BillngEntryField" type="text"  value="--Select Vehicle--"  onkeypress="return isTagName(\'txtselectorVhcl' + rowCount + '\',\'txtselectorPrjct' + rowCount + '\',' + rowCount + ', event)" onkeydown="return isTag(event)"     onblur="return BlurAddtnlJob(\'txtselectorVhcl\',' + rowCount + ',\'Vehicle\')" onfocus="return FocusJSValue(\'txtselectorVhcl\',' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' <td  style="display: none;"><input id="txtselectorVhclId' + rowCount + '"  value="--Select Vehicle--" type="text"   /></td>';
            recRow += ' <td  style="display: none;"><input id="txtselectorVhclName' + rowCount + '"  value="--Select Vehicle--" type="text" maxlength=100  /></td>';


            recRow += ' <td id="tdJobSelect' + rowCount + '" style="width: 36%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 96%;" id="txtselectorJob' + rowCount + '" class="BillngEntryField" type="text"  value="--Select Job--" onkeydown="return isTag(event)"  onkeypress="return isTagName(\'txtselectorJob' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return ChangeJobMode(\'txtselectorJob\',' + rowCount + ',\'' + TableName + '\', event)"   onblur="return BlurAddtnlJob(\'txtselectorJob\',' + rowCount + ',\'Job\')" onfocus="return FocusJSValue(\'txtselectorJob\',' + rowCount + ',event)"  maxlength=100 /> ';
            recRow += ' </div> </td> ';
            recRow += ' <td  style="display: none;"><input id="txtselectorJobId' + rowCount + '"  value="--Select Job--" type="text"   /></td>';
            recRow += ' <td  style="display: none;"><input id="txtselectorJobName' + rowCount + '"  value="--Select Job--" type="text" maxlength=100  /></td>';


            recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);"  style="  cursor: pointer;"></td>';
            recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowAddtnlJobs(' + rowCount + ',\'Are you sure you want to Delete this Entry?\',true);" style=" cursor: pointer;" ></td>';


            recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
            recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
            recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">INS</td>';
            recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;"></td>';
            recRow += '<td id="tdJobMode' + rowCount + '" style="display: none;">1</td>';

            recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
            recRow += '</tr>';

            document.getElementById("<%= HiddenFieldAddtnlJobRowCount.ClientID%>").value = rowCount;



            if (boolAppendorNot == false) {

                jQuery('#TableAddtnlJobs').append(recRow);
            }
            else {

                // to insert in perticular position
                var $NoAppnd = jQuery.noConflict();
                if (parseInt(row_index) != 0) {
                    $NoAppnd('#TableAddtnlJobs' > tbody > tr).eq(parseInt(row_index) - 1).after(recRow);
                }
                else {

                    var TableRowCount = document.getElementById(TableName).rows.length;

                    if (parseInt(TableRowCount) != 0) {
                        $NoAppnd('#TableAddtnlJobs' > tbody > tr).eq(parseInt(row_index)).before(recRow);
                    }
                    else {
                        //if table row count is 0
                        jQuery('#TableAddtnlJobs').append(recRow);
                    }
                }
            }

            var TableName = "TableAddtnlJobs";
            var $au = jQuery.noConflict();

            (function ($au) {
                $au(function () {
                    selectorToAutocompleteVehicle('txtselectorVhcl', rowCount);
                    selectorToAutocompleteTime('txtselectorFrmTime', rowCount, TableName);
                    selectorToAutocompleteTime('txtselectorToTime', rowCount, TableName);
                    selectorToAutocompleteJob('txtselectorJob', rowCount);

                    $au('form').submit(function () {

                    });
                });
            })(jQuery);

            var $NonConfli = jQuery.noConflict();
            $NonConfli('#txtselectorFrmTime' + rowCount).datetimepicker({
                dayOfWeekStart: 1,
                lang: 'en',
                startDate: new Date,
                step: 10,
                format: 'd/m/Y h:i a',
            });
            $NonConfli('#txtselectorToTime' + rowCount).datetimepicker({
                dayOfWeekStart: 1,
                lang: 'en',
                startDate: new Date,
                step: 10,
                format: 'd/m/Y h:i a',
            });
            //ReNumberTable(TableName);

        }



        function EditListRowsAddtnlJobs(EditJobId, EditJobName, EditVhclNumbr, EditVhclId, EditFromTime, EditToTime, EditTxtJobName, EditDtlId) {
          
            //  alert('EditDtlId ' + EditDtlId);// && EditHike != "" && EditAmount != "" && EditStockStatus != ""
            if (EditJobId.toString() != "" && EditVhclNumbr != "" && EditVhclId != "" && EditFromTime != "" && EditToTime != "" && EditDtlId != "") {


                rowCount++;
                RowIndex++;

                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += ' <td id="tdFrmTimeSelect' + rowCount + '" style="width: 17%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtselectorFrmTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text"  value="' + EditFromTime + '" onkeydown="return isTagDate(event)"   onkeypress="return isTagName(\'txtselectorFrmTime' + rowCount + '\',\'txtselectorToTime' + rowCount + '\',' + rowCount + ', event)"     onblur=" BlurJSTime(\'txtselectorFrmTime\',' + rowCount + ',\'Time\')" onfocus="return FocusJSTime(\'txtselectorFrmTime\',' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorFrmTimeId' + rowCount + '"  value="' + EditFromTime + '" type="text" maxlength=100  /></td>';


                recRow += ' <td id="tdToTimeSelect' + rowCount + '" style="width: 17%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 94%;margin-left: 0.1%;" id="txtselectorToTime' + rowCount + '" class="BillngEntryField TimeEntry" type="text"  value="' + EditToTime + '" onkeydown="return isTagDate(event)"   onkeypress="return isTagName(\'txtselectorToTime' + rowCount + '\',\'tdIndvlAddMoreRowPic' + rowCount + '\',' + rowCount + ', event)"     onblur=" BlurJSTime(\'txtselectorToTime\',' + rowCount + ',\'Time\')" onfocus="return FocusJSTime(\'txtselectorToTime\',' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorToTimeId' + rowCount + '"  value="' + EditToTime + '" type="text" maxlength=100  /></td>';


                recRow += ' <td id="tdVhclSelect' + rowCount + '" style="width: 17%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 100%;margin-left: 0.1%;" id="txtselectorVhcl' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditVhclNumbr + '"  onkeypress="return isTagName(\'txtselectorVhcl' + rowCount + '\',\'txtselectorPrjct' + rowCount + '\',' + rowCount + ', event)"     onblur="return BlurAddtnlJob(\'txtselectorVhcl\',' + rowCount + ',\'Vehicle\')" onfocus="return FocusJSValue(\'txtselectorVhcl\',' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorVhclId' + rowCount + '"  value="' + EditVhclId + '" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><input id="txtselectorVhclName' + rowCount + '"  value="' + EditVhclNumbr + '" type="text" maxlength=100  /></td>';


                recRow += ' <td id="tdJobSelect' + rowCount + '" style="width: 36%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 96%;" id="txtselectorJob' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditJobName + '"  onkeypress="return isTagName(\'txtselectorJob' + rowCount + '\',\'txtselectorVhcl' + rowCount + '\',' + rowCount + ', event)"  onkeydown="return ChangeJobMode(\'txtselectorJob\',' + rowCount + ',\'' + TableName + '\', event)"   onblur="return BlurAddtnlJob(\'txtselectorJob\',' + rowCount + ',\'Job\')" onfocus="return FocusJSValue(\'txtselectorJob\',' + rowCount + ',event)"  maxlength=100 /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorJobId' + rowCount + '"  value="' + EditJobId + '" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><input id="txtselectorJobName' + rowCount + '"  value="' + EditJobName + '" type="text" maxlength=100  /></td>';


                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);"  style="  cursor: pointer;"></td>';
                recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowAddtnlJobs(' + rowCount + ',\'Are you sure you want to Delete this Entry?\',true);" style=" cursor: pointer;" ></td>';


                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + EditDtlId + '</td>';
                recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                recRow += '<td id="tdJobMode' + rowCount + '" style="display: none;">1</td>';
                recRow += '</tr>';


                document.getElementById("<%= HiddenFieldAddtnlJobRowCount.ClientID%>").value = rowCount;


                jQuery('#TableAddtnlJobs').append(recRow);
                document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";


                var TableName = "TableAddtnlJobs";

             
             


                var $au = jQuery.noConflict();

                (function ($au) {
                    $au(function () {
                        selectorToAutocompleteVehicle('txtselectorVhcl', rowCount);
                        selectorToAutocompleteTime('txtselectorFrmTime', rowCount, TableName);
                        selectorToAutocompleteTime('txtselectorToTime', rowCount, TableName);
                        selectorToAutocompleteJob('txtselectorJob', rowCount);


                     
                     


                        $au('form').submit(function () {

                        });
                    });
                })(jQuery);



                var $NonConfli = jQuery.noConflict();
                $NonConfli('#txtselectorFrmTime' + rowCount).datetimepicker({
                    dayOfWeekStart: 1,
                    lang: 'en',
                    startDate: new Date,
                    step: 10,
                    format: 'd/m/Y h:i a',
                });
                $NonConfli('#txtselectorToTime' + rowCount).datetimepicker({
                    dayOfWeekStart: 1,
                    lang: 'en',
                    startDate: new Date,
                    step: 10,
                    format: 'd/m/Y h:i a',
                });

            }

        }

        function CheckaddMoreRowsIndividual(x, retBool) {

            var check = document.getElementById("tdInx" + x).innerHTML;

            if (check == " ") {

                if (retBool == true) {
                  
                    if (CheckAllRowFieldAndHighlight(x) == true) {
                       

                        document.getElementById("tdInx" + x).innerHTML = x;
                        document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";
                        addMoreRowsAddtnlJobs(this.form, retBool, 1, false, 0);

                        return false;
                    }
                }
                else if (retBool == false) {
                    var row_index = jQuery('#rowId_' + x).index();
                    if (CheckAllRowField(x, row_index, TableName) == true) {
                        document.getElementById("tdInx" + x).innerHTML = x;
                        document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";
                        addMoreRowsAddtnlJobs(this.form, retBool, 1, false, 0);


                        return false;
                    }
                }
            }
            return false;
        }


        // checks every field in row
        function CheckAllRowFieldAndHighlight(x) {

           

            var ret = true;
          
            var JMode = document.getElementById("tdJobMode" + x).innerText;
            if (JMode == "1") {
                document.getElementById("txtselectorJob" + x).style.borderColor = "";

            }
            else {
                document.getElementById("txtJob" + x).style.borderColor = "";
            }
            document.getElementById("txtselectorVhcl" + x).style.borderColor = "";
            document.getElementById("txtselectorFrmTime" + x).style.borderColor = "";
            document.getElementById("txtselectorToTime" + x).style.borderColor = "";
         
            var FrmTime = document.getElementById("txtselectorFrmTime" + x).value;
            if (FrmTime == "--Select Time--" || FrmTime == "") {
                document.getElementById("txtselectorFrmTime" + x).style.borderColor = "Red";
                document.getElementById("txtselectorFrmTime" + x).focus();
                $noCon("#txtselectorFrmTime" + x).select();
                return false;

            }
            var ToTime = document.getElementById("txtselectorToTime" + x).value;
            if (ToTime == "--Select Time--" || ToTime == "") {
                document.getElementById("txtselectorToTime" + x).style.borderColor = "Red";
                // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                document.getElementById("txtselectorToTime" + x).focus();
                $noCon("#txtselectorToTime" + x).select();
                return false;

            }
            var VhclId = document.getElementById("txtselectorVhclId" + x).value;
            if (VhclId == "--Select Vehicle--" || VhclId == "") {
                document.getElementById("txtselectorVhcl" + x).style.borderColor = "Red";
                // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                document.getElementById("txtselectorVhcl" + x).focus();
                $noCon("#txtselectorVhcl" + x).select();
                return false;

            }


            if (JMode == "1") {
                var Job = document.getElementById("txtselectorJobId" + x).value;
                if (Job == "--Select Job--") {
                    document.getElementById("txtselectorJob" + x).style.borderColor = "Red";
                    // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                    document.getElementById("txtselectorJob" + x).focus();
                    $noCon("#txtselectorJob" + x).select();
                    return false;

                }
            }
            else {
                var Job = document.getElementById("txtJob" + x).value;
                if (Job == "") {
                  
                    document.getElementById("txtJob" + x).style.borderColor = "Red";
                    document.getElementById("txtJob" + x).focus();
                    $noCon("#txtJob" + x).select();
                    return false;
                }

            }

           


            return true;
        }



        function removeRowAddtnlJobs(removeNum, CofirmMsg, boolAskConfirm) {

            var blConfirm = true;
            if (boolAskConfirm == true) {
                if (confirm(CofirmMsg)) {
                    blConfirm = true;
                }
                else {
                    blConfirm = false;
                }
            }

            if (blConfirm == true) {


                var TableName = "TableAddtnlJobs";
                var row_index = jQuery('#rowId_' + removeNum).index();
                var BforeRmvTableRowCount = document.getElementById(TableName).rows.length;

                LocalStorageDeletejobAddtnl(row_index, removeNum, TableName);

                jQuery('#rowId_' + removeNum).remove();
                RowIndex--;
                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();
                var TableRowCount = document.getElementById(TableName).rows.length;

                if (TableRowCount != 0) {
                    var idlast = $noC('#' + TableName + ' tr:last').attr('id');
                    if (idlast != "") {
                        var res = idlast.split("_");
                        //  alert(res[1]);
                        document.getElementById("tdInx" + res[1]).innerHTML = " ";
                        document.getElementById("tdIndvlAddMoreRow" + res[1]).style.opacity = "1";
                    }
                }
                else {

                    addMoreRowsAddtnlJobs(this.form, true, 1, false, 0);

                }


                //for focussing to next or previous accordingly
                // While delete, then focus to be moved to next row (If there is any row below of current row) 
                // While delete, then focus to be moved to previous row (If there is any row above of current row) 
                if (BforeRmvTableRowCount > 1) {

                    if ((BforeRmvTableRowCount - 1) == row_index) {

                        var table = document.getElementById(TableName);
                        var preRowId = table.rows[row_index - 1].id;

                        if (preRowId != "") {
                            var res = preRowId.split("_");
                            if (res[1] != "") {


                                //document.getElementById("txtselectorJob" + res[1]).focus();
                                //$noCon("#txtselectorJob" + res[1]).select();
                                //ReNumberTable(TableName);

                            }
                        }
                    }
                    else {
                        //     alert('entered 2 case');
                        var table = document.getElementById(TableName);
                        var NxtRowId = table.rows[row_index].id;
                        //  alert('NxtRowId ' + NxtRowId);
                        if (NxtRowId != "") {
                            var res = NxtRowId.split("_");
                            if (res[1] != "") {

                                //document.getElementById("txtselectorJob" + res[1]).focus();
                                //$noCon("#txtselectorJob" + res[1]).select();
                                //ReNumberTable(TableName);

                            }
                        }


                    }
                }
                //   alert('removeRow-end' );
                return false;
            }
            else {
                //    alert('removeRow-end' );
                return false;

            }
        }


        function validateSubmit() {


            var ret = true;
            if (CheckIsRepeat() == true) {

            }
            else {
                ret = false;
                return ret;
            }


            document.getElementById('divErrorNotificationSb').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "";

            var rowcount = document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value;

            for (var i = rowcount; i > 0; i--) {

                document.getElementById("txtselectorFrmDateTime" + i).style.borderColor = "";
                document.getElementById("txtselectorToDateTime" + i).style.borderColor = "";
                document.getElementById("txtPrsntMlge" + i).style.borderColor = "";


                var JobSbmnDtTimeFrom = document.getElementById("txtselectorFrmDateTime" + i).value;
                var JobSbmnDtTimeTo = document.getElementById("txtselectorToDateTime" + i).value;
                var JobSbmnPesntMlg = document.getElementById("txtPrsntMlge" + i).value;

                if (JobSbmnPesntMlg == "") {
                    document.getElementById("txtPrsntMlge" + i).style.borderColor = "red";
                    document.getElementById("txtPrsntMlge" + i).focus();
                    document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    ret = false;
                }
                if (JobSbmnDtTimeTo == "") {
                    document.getElementById("txtselectorToDateTime" + i).style.borderColor = "red";
                    document.getElementById("txtselectorToDateTime" + i).focus();
                    document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    ret = false;
                }
                if (JobSbmnDtTimeFrom == "") {

                    document.getElementById("txtselectorFrmDateTime" + i).style.borderColor = "red";
                    document.getElementById("txtselectorFrmDateTime" + i).focus();
                    document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    ret = false;

                }


            }

            var rowcount = document.getElementById("<%=HiddenFieldAddtnlJobRowCount.ClientID%>").value;

            var DeleteRowNumData = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;
            var DeleteRowNum = DeleteRowNumData.split(',');
            var count = DeleteRowNum.length;
            for (var x = rowcount; x > 0; x--) {

                var deleSTS = "false";
                for (var i = 0; i < count; i++) {
                    if (x == DeleteRowNum[i]) {
                        deleSTS = "true";
                    }
                }


                if (deleSTS == "false") {

                    for (var i = 0; i < count; i++) {
                        if (rowcount == DeleteRowNum[i]) {
                            var STS = "true";
                        }
                    }


                    if (STS != "true") {
                        var FrmTime = document.getElementById("txtselectorFrmTime" + rowcount).value;
                        var ToTime = document.getElementById("txtselectorToTime" + rowcount).value;
                        var VhclId = document.getElementById("txtselectorVhcl" + rowcount).value;
                        var Job = document.getElementById("txtselectorJob" + rowcount).value;
                        if (x == rowcount && FrmTime == "" && ToTime == "" && VhclId == "--Select Vehicle--" && Job == "--Select Job--") {
                        }
                        else {

                            document.getElementById("txtselectorJob" + x).style.borderColor = "";
                            document.getElementById("txtselectorVhcl" + x).style.borderColor = "";
                            document.getElementById("txtselectorFrmTime" + x).style.borderColor = "";
                            document.getElementById("txtselectorToTime" + x).style.borderColor = "";

                            var FrmTime = document.getElementById("txtselectorFrmTime" + x).value;
                            if (FrmTime == "--Select Time--" || FrmTime == "") {
                                document.getElementById("txtselectorFrmTime" + x).style.borderColor = "Red";
                                document.getElementById("txtselectorFrmTime" + x).focus();
                                $noCon("#txtselectorFrmTime" + x).select();
                                document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                                ret = false;

                            }
                            var ToTime = document.getElementById("txtselectorToTime" + x).value;
                            if (ToTime == "--Select Time--" || ToTime == "") {
                                document.getElementById("txtselectorToTime" + x).style.borderColor = "Red";
                                // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                                document.getElementById("txtselectorToTime" + x).focus();
                                $noCon("#txtselectorToTime" + x).select();
                                document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                                ret = false;

                            }
                            var VhclId = document.getElementById("txtselectorVhcl" + x).value;
                            if (VhclId == "--Select Vehicle--" || VhclId == "") {
                                document.getElementById("txtselectorVhcl" + x).style.borderColor = "Red";
                                // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                                document.getElementById("txtselectorVhcl" + x).focus();
                                $noCon("#txtselectorVhcl" + x).select();
                                document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                                ret = false;

                            }


                            var Job = document.getElementById("txtselectorJob" + x).value;
                            if (Job == "--Select Job--") {
                                document.getElementById("txtselectorJob" + x).style.borderColor = "Red";
                                // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                                document.getElementById("txtselectorJob" + x).focus();
                                $noCon("#txtselectorJob" + x).select();
                                document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                                ret = false;

                            }
                        }
                    }
                    else {
                        document.getElementById("txtselectorJob" + x).style.borderColor = "";
                        document.getElementById("txtselectorVhcl" + x).style.borderColor = "";
                        document.getElementById("txtselectorFrmTime" + x).style.borderColor = "";
                        document.getElementById("txtselectorToTime" + x).style.borderColor = "";

                        var FrmTime = document.getElementById("txtselectorFrmTime" + x).value;
                        if (FrmTime == "--Select Time--" || FrmTime == "") {
                            document.getElementById("txtselectorFrmTime" + x).style.borderColor = "Red";
                            document.getElementById("txtselectorFrmTime" + x).focus();
                            $noCon("#txtselectorFrmTime" + x).select();
                            document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                            document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            ret = false;

                        }
                        var ToTime = document.getElementById("txtselectorToTime" + x).value;
                        if (ToTime == "--Select Time--" || ToTime == "") {
                            document.getElementById("txtselectorToTime" + x).style.borderColor = "Red";
                            document.getElementById("txtselectorToTime" + x).focus();
                            $noCon("#txtselectorToTime" + x).select();
                            document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                            document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            ret = false;

                        }
                        var VhclId = document.getElementById("txtselectorVhcl" + x).value;
                        if (VhclId == "--Select Vehicle--" || VhclId == "") {
                            document.getElementById("txtselectorVhcl" + x).style.borderColor = "Red";
                            // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                            document.getElementById("txtselectorVhcl" + x).focus();
                            $noCon("#txtselectorVhcl" + x).select();
                            document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                            document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            ret = false;

                        }


                        var Job = document.getElementById("txtselectorJob" + x).value;
                        if (Job == "--Select Job--") {
                            document.getElementById("txtselectorJob" + x).style.borderColor = "Red";
                            // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                            document.getElementById("txtselectorJob" + x).focus();
                            $noCon("#txtselectorJob" + x).select();
                            document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                            document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            ret = false;

                        }
                    }

                }
            }



            if (document.getElementById("txtTimeSheetStartDateTime").value == "" || document.getElementById("txtTimeSheetEndDateTime").value == "") {
                ret = false;
            }



            if (ret == true) {

                document.getElementById("<%=HiddenFieldStatusDropdown.ClientID%>").value = "";


                //For Time sheet table
                var tbClientJobSheduling = '';
                tbClientJobSheduling = [];

                var $add = jQuery.noConflict();
                var client = JSON.stringify({
                    FROMTIME: $add("#txtTimeSheetStartDateTime").val(),
                    TOTIME: $add("#txtTimeSheetEndDateTime").val(),
                    TOTALWRKHR: $add("#txtTotalWrkHr").val(),
                    NORMALWRKHR: $add("#txtNrmlWrkHr").val(),
                    IDLEHR: $add("#txtIdleHrs").val(),
                    TOTALOT: $add("#txtFinalOT").val(),
                    ROUNDEDOT: $add("#txtRoundedOT").val(),

                });



                tbClientJobSheduling.push(client);
                $add("#cphMain_HiddenFieldTimeSheet").val(JSON.stringify(tbClientJobSheduling));

                //For job submission table
                var tbClientJobSheduling = '';
                tbClientJobSheduling = [];
                var rowCount = document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value;
                for (var x = 1; x <= rowCount; x++) {
                    var dutyDtlId = document.getElementById("tdDutyrstrDtlID" + x).innerHTML;
                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        DUTYDTLID: "" + dutyDtlId + "",
                        FROMTIME: $add("#txtselectorFrmDateTime" + x).val(),
                        TOTIME: $add("#txtselectorToDateTime" + x).val(),
                        SUBMSNSTS: $add("#txtselectorStatus" + x).val(),
                        VHCLID: $add("#txtselectorVhclId" + x).val(),
                        PRSNTMLG: $add("#txtPrsntMlge" + x).val(),
                        DESC: $add("#txtDescpn" + x).val(),

                    });
                    tbClientJobSheduling.push(client);
                }
                $add("#cphMain_HiddenFieldJobSbmsnDtls").val(JSON.stringify(tbClientJobSheduling));
                //alert(document.getElementById("<%=HiddenFieldJobSbmsnDtls.ClientID%>").value);

            }




            if (ret == false) {

                CheckSubmitZero();

            }
            else {

                clearSTS();

            }


            setTimeout(function () {
                return ret
                //do what you need here
            }, 500);

            return ret;
        }


        </script>
    <script>


        function LocalStorageAddjobAddtnl(x) {

            var tbClientJobSheduling = '';
            tbClientJobSheduling = localStorage.getItem("tbClientAddtnlJobs");//Retrieve the stored data      
            tbClientJobSheduling = JSON.parse(tbClientJobSheduling); //Converts string to object

            if (tbClientJobSheduling == null) //If there is no data, initialize an empty array
                tbClientJobSheduling = [];
            var detailId = document.getElementById("tdDtlId" + x).innerHTML;
            var evt = document.getElementById("tdEvt" + x).innerHTML;



            if (evt == 'INS') {
                var $add = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    JOBID: $add("#txtselectorJobId" + x).val(),
                    JOBNAME: $add("#txtselectorJobName" + x).val(),
                    VHCLID: $add("#txtselectorVhclId" + x).val(),
                    FROMTIME: $add("#txtselectorFrmTime" + x).val(),
                    TOTIME: $add("#txtselectorToTime" + x).val(),
                    EVTACTION: "" + evt + "",
                    DTLID: "0"

                });
            }
            else if (evt == 'UPD') {
                var $add = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    JOBID: $add("#txtselectorJobId" + x).val(),
                    JOBNAME: $add("#txtselectorJobName" + x).val(),
                    VHCLID: $add("#txtselectorVhclId" + x).val(),
                    FROMTIME: $add("#txtselectorFrmTime" + x).val(),
                    TOTIME: $add("#txtselectorToTime" + x).val(),
                    EVTACTION: "" + evt + "",
                    DTLID: "" + detailId + ""

                });
            }


            tbClientJobSheduling.push(client);
            localStorage.setItem("tbClientAddtnlJobs", JSON.stringify(tbClientJobSheduling));
            $add("#cphMain_HiddenFieldAddtnlJobs").val(JSON.stringify(tbClientJobSheduling));

            document.getElementById("tdSave" + x).innerHTML = "saved";

            return true;

        }
        function LocalStorageDeletejobAddtnl(row_index, x, TableName) {


            var tbClientJobSheduling = '';
            tbClientJobSheduling = localStorage.getItem("tbClientAddtnlJobs");//Retrieve the stored data
            tbClientJobSheduling = JSON.parse(tbClientJobSheduling); //Converts string to object

            if (tbClientJobSheduling == null) //If there is no data, initialize an empty array
                tbClientJobSheduling = [];

            tbClientJobSheduling.splice(row_index, 1);
            localStorage.setItem("tbClientAddtnlJobs", JSON.stringify(tbClientJobSheduling));


            var evt = document.getElementById("tdEvt" + x).innerHTML;
            if (evt == 'UPD') {
                var detailId = document.getElementById("tdDtlId" + x).innerHTML;

                if (detailId != '') {
                    var CanclIds = document.getElementById("<%=HiddenFieldCancelAddtnJobDtlId.ClientID%>").value;

                    if (CanclIds == '') {
                        document.getElementById("<%=HiddenFieldCancelAddtnJobDtlId.ClientID%>").value = detailId;

                    }
                    else {

                        document.getElementById("<%=HiddenFieldCancelAddtnJobDtlId.ClientID%>").value = document.getElementById("<%=HiddenFieldCancelAddtnJobDtlId.ClientID%>").value + ',' + detailId;
                    }

                }

            }

            var CanclRowNum = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;

            if (CanclRowNum == '') {
                document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value = x;

            }
            else {

                document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value + ',' + x;
            }



            //Start:-For update time sheet table after delete

            //For From time
            var y = document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value;
            var StartDateTime = new Date();
            var EndDateTime = new Date();
            var StartDateTime1 = new Date();
            var EndDateTime1 = new Date();

            StartDateTime = document.getElementById("txtselectorFrmDateTime1").value;
            StartDateTime1 = StartDateTime;
            if (StartDateTime != "") {
                StartDateTime = convertDateTo24Hour(StartDateTime);
            }



            if (y > 1) {

                for (var i = 2; i <= y; i++) {

                    EndDateTime = document.getElementById("txtselectorFrmDateTime" + i).value;
                    EndDateTime1 = EndDateTime;
                    if (EndDateTime != "") {
                        EndDateTime = convertDateTo24Hour(EndDateTime);
                        if (StartDateTime == "" || EndDateTime < StartDateTime) {

                            StartDateTime = EndDateTime;
                            StartDateTime1 = EndDateTime1;
                        }

                    }
                }
            }

            var z = document.getElementById("<%= HiddenFieldAddtnlJobRowCount.ClientID%>").value;

            var DeleteRowNumData = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;
            var DeleteRowNum = DeleteRowNumData.split(',');
            var count = DeleteRowNum.length;

            for (var i = 1; i <= z; i++) {

                var deleSTS = "false";
                for (var x = 0; x < count; x++) {
                    if (i == DeleteRowNum[x]) {
                        deleSTS = "true";
                    }
                }

                if (deleSTS == "false") {

                    EndDateTime = document.getElementById("txtselectorFrmTime" + i).value;
                    EndDateTime1 = EndDateTime;
                    if (EndDateTime != "") {

                        EndDateTime = convertDateTo24Hour(EndDateTime);
                        if (StartDateTime == "" || EndDateTime < StartDateTime) {

                            StartDateTime = EndDateTime;
                            StartDateTime1 = EndDateTime1;
                        }

                    }
                }
            }
            document.getElementById("txtTimeSheetStartDateTime").value = StartDateTime1;



            //For To Time
            var y = document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value;
            var StartDateTime = new Date();
            var EndDateTime = new Date();
            var StartDateTime1 = new Date();
            var EndDateTime1 = new Date();

            StartDateTime = document.getElementById("txtselectorToDateTime1").value;
            StartDateTime1 = StartDateTime;
            if (StartDateTime != "") {
                StartDateTime = convertDateTo24Hour(StartDateTime);
            }



            if (y > 1) {
              
                for (var i = 2; i <= y; i++) {

                    EndDateTime = document.getElementById("txtselectorToDateTime" + i).value;
                    EndDateTime1 = EndDateTime;
                    if (EndDateTime != "") {
                        EndDateTime = convertDateTo24Hour(EndDateTime);
                        if (StartDateTime == "" || EndDateTime > StartDateTime) {
                         
                            StartDateTime = EndDateTime;
                            StartDateTime1 = EndDateTime1;
                        }

                    }
                }
            }

            var z = document.getElementById("<%= HiddenFieldAddtnlJobRowCount.ClientID%>").value;

            var DeleteRowNumData = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;
            var DeleteRowNum = DeleteRowNumData.split(',');
            var count = DeleteRowNum.length;

            for (var i = 1; i <= z; i++) {

                var deleSTS = "false";
                for (var x = 0; x < count; x++) {
                    if (i == DeleteRowNum[x]) {
                        deleSTS = "true";
                    }
                }

                if (deleSTS == "false") {

                    EndDateTime = document.getElementById("txtselectorToTime" + i).value;
                    EndDateTime1 = EndDateTime;
                    if (EndDateTime != "") {

                        EndDateTime = convertDateTo24Hour(EndDateTime);
                        if (StartDateTime == "" || EndDateTime > StartDateTime) {

                            StartDateTime = EndDateTime;
                            StartDateTime1 = EndDateTime1;
                        }

                    }
                }
            }

          
            document.getElementById("txtTimeSheetEndDateTime").value = StartDateTime1;

            //End:-For update time sheet table after delete


        }

        function LocalStorageEditjobAddtnl(x, row_index) {

            var tbClientJobSheduling = '';
            tbClientJobSheduling = localStorage.getItem("tbClientAddtnlJobs");//Retrieve the stored data
            tbClientJobSheduling = JSON.parse(tbClientJobSheduling); //Converts string to object

            if (tbClientJobSheduling == null) //If there is no data, initialize an empty array
                tbClientJobSheduling = [];
            var detailId = document.getElementById("tdDtlId" + x).innerHTML;
            var evt = document.getElementById("tdEvt" + x).innerHTML;



            if (evt == 'INS') {
                var $E = jQuery.noConflict();
                tbClientJobSheduling[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    JOBID: $E("#txtselectorJobId" + x).val(),
                    JOBNAME: $E("#txtselectorJobName" + x).val(),
                    VHCLID: $E("#txtselectorVhclId" + x).val(),
                    FROMTIME: $E("#txtselectorFrmTime" + x).val(),
                    TOTIME: $E("#txtselectorToTime" + x).val(),
                    EVTACTION: "" + evt + "",
                    DTLID: "0"

                });
            }
            else if (evt == 'UPD') {
                var $E = jQuery.noConflict();
                tbClientJobSheduling[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    JOBID: $E("#txtselectorJobId" + x).val(),
                    JOBNAME: $E("#txtselectorJobName" + x).val(),
                    VHCLID: $E("#txtselectorVhclId" + x).val(),
                    FROMTIME: $E("#txtselectorFrmTime" + x).val(),
                    TOTIME: $E("#txtselectorToTime" + x).val(),
                    EVTACTION: "" + evt + "",
                    DTLID: "" + detailId + ""


                });
            }

            localStorage.setItem("tbClientAddtnlJobs", JSON.stringify(tbClientJobSheduling));
            $E("#cphMain_HiddenFieldAddtnlJobs").val(JSON.stringify(tbClientJobSheduling));

            return true;
        }




        function BlurAddtnlJob(obj, x, DefaultTxt) {

            $('body').css({ 'overflow': 'visible' });
            $(document.getElementById("MyModalJobSubmit")).css({ 'overflow': 'auto' });


            if (document.getElementById(obj + "Id" + x).value == "" || document.getElementById(obj + "Id" + x).value == "--Select " + DefaultTxt + "--") {

                document.getElementById(obj + x).value = "--Select " + DefaultTxt + "--";
            }

            var TxtName = document.getElementById(obj + x).value.trim();

            if (TxtName == "" || TxtName == "--Select " + DefaultTxt + "--") {
                document.getElementById(obj + "Id" + x).value = "--Select " + DefaultTxt + "--";
                document.getElementById(obj + "Name" + x).value = "--Select " + DefaultTxt + "--";
                document.getElementById(obj + x).value = "--Select " + DefaultTxt + "--";
            }

            var JSName = document.getElementById(obj + "Name" + x).value.trim();
            if (JSName != "" || JSName != "--Select " + DefaultTxt + "--") {
                document.getElementById(obj + x).value = JSName;
            }

            //////////////////////////////
            //document.getElementById('divBlink').style.visibility = "hidden";

            var row_index = jQuery('#rowId_' + x).index();

            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;

            if (SavedorNot == "saved") {



                var ValueId = document.getElementById(obj + "Id" + x).value;

                var hiddenIdFocus = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                if (ValueId != hiddenIdFocus) {

                    if (ValueId != "--Select " + DefaultTxt + "--") {
                        document.getElementById(obj + x).style.borderColor = "";

                        //Update to local storage


                        LocalStorageEditjobAddtnl(x, row_index);


                    }

                    else {
                        var hiddenHeadValId = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;
                            var hiddenHeadValText = document.getElementById("<%=hiddenJSNameFocus.ClientID%>").value;
                            if (hiddenHeadValId != "" && hiddenHeadValText != "") {

                                document.getElementById(obj + x).value = hiddenHeadValText;
                                document.getElementById(obj + "Id" + x).value = hiddenHeadValId;
                                document.getElementById(obj + "Name" + x).value = hiddenHeadValText;

                            }
                        }
                    }




                }

                else {

                    var ValueId = document.getElementById(obj + "Id" + x).value;
                    var hiddenIdFocus = document.getElementById("<%=hiddenJSIdFocus.ClientID%>").value;



                    if (ValueId != hiddenIdFocus) {
                        if (ValueId != "--Select " + DefaultTxt + "--") {

                            document.getElementById(obj + x).style.borderColor = "";

                            //for saving

                            if (CheckAllRowFieldAddtnlJobs(x, row_index) == false) {

                                return false;

                            }

                            if (SavedorNot == " ") {

                                LocalStorageAddjobAddtnl(x);

                            }


                        }

                    }


                }
            }


            function BlurIdleHr() {
                document.getElementById('divErrorNotificationSb').style.visibility = "hidden";
                document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "";


            document.getElementById("txtIdleHrs").style.borderColor = "";


            var idleHr = document.getElementById("txtIdleHrs").value;
            if (isNaN(parseFloat(idleHr)) == false && document.getElementById("txtTotalWrkHr").value != "") {
                var idleHr = parseFloat(document.getElementById("txtIdleHrs").value);
                var totalHr = parseFloat(document.getElementById("txtTotalWrkHr").value);
                var NrmlHr = parseFloat(document.getElementById("txtNrmlWrkHr").value);
                if (idleHr < totalHr) {
                    var FinalOT = totalHr - (NrmlHr + idleHr);
                    if (FinalOT > 0) {
                        document.getElementById("txtFinalOT").value = FinalOT.toFixed(2);
                        document.getElementById("txtRoundedOT").value = FinalOT.toFixed(2);
                    }
                    else {
                        document.getElementById("txtFinalOT").value = "";
                        document.getElementById("txtRoundedOT").value = "";
                    }
                }
                else {
                    document.getElementById("txtIdleHrs").value = "";
                    document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Idle Hour Cannot Be Greater Than Total Work Hour";
                    document.getElementById("txtIdleHrs").style.borderColor = "Red";
                    document.getElementById("txtIdleHrs").focus();
                }
            }
            else {
                document.getElementById("txtIdleHrs").value = "";
            }
        }
        function BlurRoundedOT() {

            var RoundedOT = document.getElementById("txtRoundedOT").value;
            var totalHr = parseFloat(document.getElementById("txtTotalWrkHr").value);
            var NrmlHr = parseFloat(document.getElementById("txtNrmlWrkHr").value);
            if (isNaN(parseFloat(RoundedOT)) == false && document.getElementById("txtTotalWrkHr").value != "" && totalHr > NrmlHr) {
                document.getElementById("txtRoundedOT").value = RoundedOT.toFixed(2);
            }
            else {
                document.getElementById("txtRoundedOT").value = document.getElementById("txtFinalOT").value;
            }
        }




        function convertDateTo24Hour(date) {
            var elem = date.split(' ');
            var stSplit = elem[1].split(":");// alert(stSplit);
            var stHour = stSplit[0];
            var stMin = stSplit[1];
            var stAmPm = elem[2].toUpperCase();
            var newhr = 0;
            var ampm = '';
            var newtime = '';

            if (stAmPm == 'PM') {
                if (stHour != 12) {
                    stHour = stHour * 1 + 12;
                }

            } else if (stAmPm == 'AM' && stHour == '12') {
                stHour = stHour - 12;
            } else {
                stHour = stHour;
            }

            return elem[0] + " " + stHour + ':' + stMin;
        }

        function DisplayTime(obj, StartDateTime1) {
            if (obj == "txtselectorFrmDateTime" || obj == "txtselectorFrmTime") {
                document.getElementById("txtTimeSheetStartDateTime").value = StartDateTime1;
            }
            else {
                document.getElementById("txtTimeSheetEndDateTime").value = StartDateTime1;
            }

        }
        function BlurDesc(x) {
            var data = document.getElementById("txtDescpn" + x).value;
            var replaceText1 = data.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("txtDescpn" + x).value = replaceText2;
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





        function isNumberDec(evt) {

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
            else if (keyCodes == 190 || keyCodes == 110) {
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
        // FOR TYPING NUMBER ONLY
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

        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }
        function isTagDate(event) {

            //    alert("The Unicode key code is: " + event.keyCode);
            var keyCodes = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            var charCode = (event.which) ? event.which : event.keyCodes;
            // alert('isTagDate');

            //    alert(keyCodes);
            if (keyCodes == 13) {

                return false;

            }
            else if (keyCodes == 191 || keyCodes == 111 || keyCodes == 59 || keyCodes == 32 || keyCodes == 65 || keyCodes == 80 || keyCodes == 77 || keyCodes == 17 || keyCodes == 86 || keyCodes == 186) {
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40 || keyCodes == 67) {
                return true;

            }
                // -   given or as'-' have different keycode in browsers
            else if (keyCodes == 173 || keyCodes == 189) {
                return true;

            }

            else {
                var ret = true;

                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    return false;
                }
                return ret;
            }


        }

        function FromToDateCheck(obj, x) {
            var ret = true;
            var date1 = new Date();
            var date2 = new Date();
            date1 = convertDateTo24Hour(document.getElementById(obj + x).value);
            var date1Split = date1.split(" ");
            var date1Date = date1Split[0];
            var date1DateDMY = date1Date.split("/");
            var date1DateD = date1DateDMY[0];
            var date1DateM = date1DateDMY[1];
            var date1DateY = date1DateDMY[2];
            var date1Time = date1Split[1];
            var date1TimeSplit = date1Time.split(":");
            var date1TimeHR = date1TimeSplit[0];
            var date1TimeMn = date1TimeSplit[1];
            var firstDate = new Date(date1DateY, date1DateM, date1DateD, date1TimeHR, date1TimeMn);

            document.getElementById('divErrorNotificationSb').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "";
            document.getElementById(obj + x).style.borderColor = "";


            if (obj == "txtselectorFrmDateTime") {
                date2 = document.getElementById("txtselectorToDateTime" + x).value;
                document.getElementById("txtselectorToDateTime" + x).style.borderColor = "";
                if (date2 != "") {
                    date2 = convertDateTo24Hour(date2);
                    var date2Split = date2.split(" ");
                    var date2Date = date2Split[0];
                    var date2DateDMY = date2Date.split("/");
                    var date2DateD = date2DateDMY[0];
                    var date2DateM = date2DateDMY[1];
                    var date2DateY = date2DateDMY[2];
                    var date2Time = date2Split[1];
                    var date2TimeSplit = date2Time.split(":");
                    var date2TimeHR = date2TimeSplit[0];
                    var date2TimeMn = date2TimeSplit[1];
                    var secondDate = new Date(date2DateY, date2DateM, date2DateD, date2TimeHR, date2TimeMn);
                    if (secondDate <= firstDate) {
                        document.getElementById(obj + x).value = "";
                        document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                        document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "From Date Cannot Be Greater Than Or Equal To ToDate";
                        document.getElementById(obj + x).style.borderColor = "Red";
                        document.getElementById(obj + x).focus();
                        ret = false;
                    }
                    else {


                        var StartDatetime = new Date();
                        var EndDatetime = new Date();
                        var CurrStartDatetime = new Date();
                        var CurrEndDatetime = new Date();

                        var y = document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value;
                        for (var i = 1; i <= y; i++) {
                            StartDatetime = document.getElementById("txtselectorFrmDateTime" + i).value;
                            EndDatetime = document.getElementById("txtselectorToDateTime" + i).value;

                            CurrStartDatetime = document.getElementById("txtselectorFrmDateTime" + x).value;
                            CurrEndDatetime = document.getElementById("txtselectorToDateTime" + x).value;
                            if (i != x && StartDatetime != "" && EndDatetime != "") {

                                StartDatetime = convertDateTo24Hour(StartDatetime);
                                EndDatetime = convertDateTo24Hour(EndDatetime);
                                CurrStartDatetime = convertDateTo24Hour(CurrStartDatetime);
                                CurrEndDatetime = convertDateTo24Hour(CurrEndDatetime);
                                if (StartDatetime > CurrStartDatetime && StartDatetime < CurrEndDatetime || CurrStartDatetime > StartDatetime && CurrStartDatetime < EndDatetime || CurrStartDatetime == StartDatetime) {
                                    document.getElementById("txtselectorFrmDateTime" + x).value = "";
                                    document.getElementById("txtselectorToDateTime" + x).value = "";
                                    document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                    document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Date Cannot Be Overlapped";
                                    document.getElementById("txtselectorFrmDateTime" + x).style.borderColor = "Red";
                                    document.getElementById("txtselectorToDateTime" + x).style.borderColor = "Red";
                                    document.getElementById("txtselectorFrmDateTime" + x).focus();
                                    ret = false;
                                }
                               
                            }
                        }




                        if (ret != false) {
                            var empid = document.getElementById("<%=HiddenFieldEmployeeId.ClientID%>").value;
                            var fromdate = document.getElementById("txtselectorFrmDateTime" + x).value;
                            var todate = document.getElementById("txtselectorToDateTime" + x).value;
                            var SubmsnId = document.getElementById("<%=HiddenFieldSubmissionId.ClientID%>").value; 
                            var Details = PageMethods.CheckEmpDuplctn(empid, fromdate, todate,SubmsnId, function (response) {

                                if (response == "false") {
                                    document.getElementById("txtselectorFrmDateTime" + x).value = "";
                                    document.getElementById("txtselectorToDateTime" + x).value = "";
                                    document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                    document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Another job is submitted with the selected dates";
                                    document.getElementById("txtselectorFrmDateTime" + x).style.borderColor = "Red";
                                    document.getElementById("txtselectorToDateTime" + x).style.borderColor = "Red";
                                    document.getElementById("txtselectorFrmDateTime" + x).focus();
                                    ret = false;
                                }

                            });
                        }

                        if (ret != false) {


                            var z = document.getElementById("<%= HiddenFieldAddtnlJobRowCount.ClientID%>").value;
                            var DeleteRowNumData = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;
                            var DeleteRowNum = DeleteRowNumData.split(',');
                            var count = DeleteRowNum.length;

                            for (var i = 1; i <= z; i++) {

                                var deleSTS = "false";
                                for (var j = 0; j < count; j++) {
                                    if (i == DeleteRowNum[j]) {
                                        deleSTS = "true";
                                    }
                                }

                                if (deleSTS == "false") {


                                    StartDatetime = document.getElementById("txtselectorFrmTime" + i).value;
                                    EndDatetime = document.getElementById("txtselectorToTime" + i).value;
                                    if (StartDatetime != "" && EndDatetime != "") {

                                        StartDatetime = convertDateTo24Hour(StartDatetime);
                                        EndDatetime = convertDateTo24Hour(EndDatetime);
                                        if (StartDatetime > CurrStartDatetime && StartDatetime < CurrEndDatetime || CurrStartDatetime > StartDatetime && CurrStartDatetime < EndDatetime || CurrStartDatetime == StartDatetime) {
                                            document.getElementById("txtselectorFrmDateTime" + x).value = "";
                                            document.getElementById("txtselectorToDateTime" + x).value = "";
                                            document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                            document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Date Cannot Be Overlapped";
                                            document.getElementById("txtselectorFrmDateTime" + x).style.borderColor = "Red";
                                            document.getElementById("txtselectorToDateTime" + x).style.borderColor = "Red";
                                            document.getElementById("txtselectorFrmDateTime" + x).focus();
                                            ret = false;
                                        }
                                    }


                                }
                            }

                        }







                    }
                }
            }
            if (obj == "txtselectorToDateTime") {

                date2 = document.getElementById("txtselectorFrmDateTime" + x).value;
                document.getElementById("txtselectorFrmDateTime" + x).style.borderColor = "";
                if (date2 != "") {
                    date2 = convertDateTo24Hour(date2);
                    var date2Split = date2.split(" ");
                    var date2Date = date2Split[0];
                    var date2DateDMY = date2Date.split("/");
                    var date2DateD = date2DateDMY[0];
                    var date2DateM = date2DateDMY[1];
                    var date2DateY = date2DateDMY[2];
                    var date2Time = date2Split[1];
                    var date2TimeSplit = date2Time.split(":");
                    var date2TimeHR = date2TimeSplit[0];
                    var date2TimeMn = date2TimeSplit[1];
                    var secondDate = new Date(date2DateY, date2DateM, date2DateD, date2TimeHR, date2TimeMn);
                   

                    if (secondDate >= firstDate) {
                        document.getElementById(obj + x).value = "";
                        document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                        document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "To Date Cannot Be Less Than Or Equal To From Date";
                        document.getElementById(obj + x).style.borderColor = "Red";
                        document.getElementById(obj + x).focus();
                        ret = false;
                    }
                    else {


                        var StartDatetime = new Date();
                        var EndDatetime = new Date();
                        var CurrStartDatetime = new Date();
                        var CurrEndDatetime = new Date();

                        var y = document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value;
                        for (var i = 1; i <= y; i++) {
                            StartDatetime = document.getElementById("txtselectorFrmDateTime" + i).value;
                            EndDatetime = document.getElementById("txtselectorToDateTime" + i).value;

                            CurrStartDatetime = document.getElementById("txtselectorFrmDateTime" + x).value;
                            CurrEndDatetime = document.getElementById("txtselectorToDateTime" + x).value;
                            if (i != x && StartDatetime != "" && EndDatetime != "") {

                                StartDatetime = convertDateTo24Hour(StartDatetime);
                                EndDatetime = convertDateTo24Hour(EndDatetime);
                                CurrStartDatetime = convertDateTo24Hour(CurrStartDatetime);
                                CurrEndDatetime = convertDateTo24Hour(CurrEndDatetime);
                                if (StartDatetime > CurrStartDatetime && StartDatetime < CurrEndDatetime || CurrStartDatetime > StartDatetime && CurrStartDatetime < EndDatetime || CurrStartDatetime == StartDatetime) {
                                    document.getElementById("txtselectorFrmDateTime" + x).value = "";
                                    document.getElementById("txtselectorToDateTime" + x).value = "";
                                    document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                    document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Date Cannot Be Overlapped";
                                    document.getElementById("txtselectorFrmDateTime" + x).style.borderColor = "Red";
                                    document.getElementById("txtselectorToDateTime" + x).style.borderColor = "Red";
                                    document.getElementById("txtselectorFrmDateTime" + x).focus();
                                    ret = false;
                                   
                                }
                            }
                        }









                        if (ret != false) {
                            var empid = document.getElementById("<%=HiddenFieldEmployeeId.ClientID%>").value;
                            var fromdate = document.getElementById("txtselectorFrmDateTime" + x).value;
                            var todate = document.getElementById("txtselectorToDateTime" + x).value;
                            var SubmsnId = document.getElementById("<%=HiddenFieldSubmissionId.ClientID%>").value; 
                            var Details = PageMethods.CheckEmpDuplctn(empid, fromdate, todate,SubmsnId, function (response) {

                                if (response == "false") {
                                    document.getElementById("txtselectorFrmDateTime" + x).value = "";
                                    document.getElementById("txtselectorToDateTime" + x).value = "";
                                    document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                    document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Another job is submitted with the selected dates";
                                    document.getElementById("txtselectorFrmDateTime" + x).style.borderColor = "Red";
                                    document.getElementById("txtselectorToDateTime" + x).style.borderColor = "Red";
                                    document.getElementById("txtselectorFrmDateTime" + x).focus();
                                    ret = false;
                                  
                                }

                            });
                        }





                        if (ret != false) {




                            var z = document.getElementById("<%= HiddenFieldAddtnlJobRowCount.ClientID%>").value;
                            var DeleteRowNumData = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;
                            var DeleteRowNum = DeleteRowNumData.split(',');
                            var count = DeleteRowNum.length;

                            for (var i = 1; i <= z; i++) {

                                var deleSTS = "false";
                                for (var j = 0; j < count; j++) {
                                    if (i == DeleteRowNum[j]) {
                                        deleSTS = "true";
                                    }
                                }

                                if (deleSTS == "false") {


                                    StartDatetime = document.getElementById("txtselectorFrmTime" + i).value;
                                    EndDatetime = document.getElementById("txtselectorToTime" + i).value;
                                    if (StartDatetime != "" && EndDatetime != "") {

                                        StartDatetime = convertDateTo24Hour(StartDatetime);
                                        EndDatetime = convertDateTo24Hour(EndDatetime);
                                        if (StartDatetime > CurrStartDatetime && StartDatetime < CurrEndDatetime || CurrStartDatetime > StartDatetime && CurrStartDatetime < EndDatetime || CurrStartDatetime == StartDatetime) {
                                            document.getElementById("txtselectorFrmDateTime" + x).value = "";
                                            document.getElementById("txtselectorToDateTime" + x).value = "";
                                            document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                            document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Date Cannot Be Overlapped";
                                            document.getElementById("txtselectorFrmDateTime" + x).style.borderColor = "Red";
                                            document.getElementById("txtselectorToDateTime" + x).style.borderColor = "Red";
                                            document.getElementById("txtselectorFrmDateTime" + x).focus();
                                            ret = false;
                                        }
                                    }


                                }
                            }
                        }

                    }
                }
            }
            if (obj == "txtselectorFrmTime") {
                date2 = document.getElementById("txtselectorToTime" + x).value;
                document.getElementById("txtselectorToTime" + x).style.borderColor = "";
                if (date2 != "") {
                    date2 = convertDateTo24Hour(date2);
                    var date2Split = date2.split(" ");
                    var date2Date = date2Split[0];
                    var date2DateDMY = date2Date.split("/");
                    var date2DateD = date2DateDMY[0];
                    var date2DateM = date2DateDMY[1];
                    var date2DateY = date2DateDMY[2];
                    var date2Time = date2Split[1];
                    var date2TimeSplit = date2Time.split(":");
                    var date2TimeHR = date2TimeSplit[0];
                    var date2TimeMn = date2TimeSplit[1];
                    var secondDate = new Date(date2DateY, date2DateM, date2DateD, date2TimeHR, date2TimeMn);
                    if (secondDate <= firstDate) {
                        document.getElementById(obj + x).value = "";
                        document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                        document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "From Date Cannot Be Greater Than Or Equal To ToDate";
                        document.getElementById(obj + x).style.borderColor = "Red";
                        document.getElementById(obj + x).focus();
                        ret = false;
                    }
                    else {


                        var StartDatetime = new Date();
                        var EndDatetime = new Date();
                        var CurrStartDatetime = new Date();
                        var CurrEndDatetime = new Date();

                        var y = document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value;
                        for (var i = 1; i <= y; i++) {
                            StartDatetime = document.getElementById("txtselectorFrmDateTime" + i).value;
                            EndDatetime = document.getElementById("txtselectorToDateTime" + i).value;

                            CurrStartDatetime = document.getElementById("txtselectorFrmTime" + x).value;
                            CurrEndDatetime = document.getElementById("txtselectorToTime" + x).value;
                            if (StartDatetime != "" && EndDatetime != "") {

                                StartDatetime = convertDateTo24Hour(StartDatetime);
                                EndDatetime = convertDateTo24Hour(EndDatetime);
                                CurrStartDatetime = convertDateTo24Hour(CurrStartDatetime);
                                CurrEndDatetime = convertDateTo24Hour(CurrEndDatetime);
                                if (StartDatetime > CurrStartDatetime && StartDatetime < CurrEndDatetime || CurrStartDatetime > StartDatetime && CurrStartDatetime < EndDatetime || CurrStartDatetime == StartDatetime) {
                                    document.getElementById("txtselectorFrmTime" + x).value = "";
                                    document.getElementById("txtselectorToTime" + x).value = "";
                                    document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                    document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Date Cannot Be Overlapped";
                                    document.getElementById("txtselectorFrmTime" + x).style.borderColor = "Red";
                                    document.getElementById("txtselectorToTime" + x).style.borderColor = "Red";
                                    document.getElementById("txtselectorFrmTime" + x).focus();
                                    ret = false;
                                   
                                }
                            }
                        }

                        if (ret != false) {
                            var empid = document.getElementById("<%=HiddenFieldEmployeeId.ClientID%>").value;
                            var fromdate = document.getElementById("txtselectorFrmTime" + x).value;
                            var todate = document.getElementById("txtselectorToTime" + x).value;
                            var SubmsnId = document.getElementById("<%=HiddenFieldSubmissionId.ClientID%>").value;
                            var Details = PageMethods.CheckEmpDuplctn(empid, fromdate, todate,SubmsnId, function (response) {

                                if (response == "false") {
                                    document.getElementById("txtselectorFrmTime" + x).value = "";
                                    document.getElementById("txtselectorToTime" + x).value = "";
                                    document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                    document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Another job is submitted with the selected dates";
                                    document.getElementById("txtselectorFrmTime" + x).style.borderColor = "Red";
                                    document.getElementById("txtselectorToTime" + x).style.borderColor = "Red";
                                    document.getElementById("txtselectorFrmTime" + x).focus();
                                    ret = false;
                                }

                            });
                        }
                        if (ret != false) {

                            var z = document.getElementById("<%= HiddenFieldAddtnlJobRowCount.ClientID%>").value;
                            var DeleteRowNumData = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;
                            var DeleteRowNum = DeleteRowNumData.split(',');
                            var count = DeleteRowNum.length;

                            for (var i = 1; i <= z; i++) {

                                var deleSTS = "false";
                                for (var j = 0; j < count; j++) {
                                    if (i == DeleteRowNum[j]) {
                                        deleSTS = "true";
                                    }
                                }

                                if (deleSTS == "false") {


                                    StartDatetime = document.getElementById("txtselectorFrmTime" + i).value;
                                    EndDatetime = document.getElementById("txtselectorToTime" + i).value;
                                    if (i != x && StartDatetime != "" && EndDatetime != "") {

                                        StartDatetime = convertDateTo24Hour(StartDatetime);
                                        EndDatetime = convertDateTo24Hour(EndDatetime);
                                       

                                        if (StartDatetime > CurrStartDatetime && StartDatetime < CurrEndDatetime || CurrStartDatetime > StartDatetime && CurrStartDatetime < EndDatetime || CurrStartDatetime == StartDatetime) {
                                            document.getElementById("txtselectorFrmTime" + x).value = "";
                                            document.getElementById("txtselectorToTime" + x).value = "";
                                            document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                            document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Date Cannot Be Overlapped";
                                            document.getElementById("txtselectorFrmTime" + x).style.borderColor = "Red";
                                            document.getElementById("txtselectorToTime" + x).style.borderColor = "Red";
                                            document.getElementById("txtselectorFrmTime" + x).focus();
                                            ret = false;
                                           
                                        }
                                    }


                                }
                            }

                        }

                    }
                }
               
            }
            if (obj == "txtselectorToTime") {
                date2 = document.getElementById("txtselectorFrmTime" + x).value;
                document.getElementById("txtselectorFrmTime" + x).style.borderColor = "";
                if (date2 != "") {
                    date2 = convertDateTo24Hour(date2);
                    var date2Split = date2.split(" ");
                    var date2Date = date2Split[0];
                    var date2DateDMY = date2Date.split("/");
                    var date2DateD = date2DateDMY[0];
                    var date2DateM = date2DateDMY[1];
                    var date2DateY = date2DateDMY[2];
                    var date2Time = date2Split[1];
                    var date2TimeSplit = date2Time.split(":");
                    var date2TimeHR = date2TimeSplit[0];
                    var date2TimeMn = date2TimeSplit[1];
                    var secondDate = new Date(date2DateY, date2DateM, date2DateD, date2TimeHR, date2TimeMn);
                    if (secondDate >= firstDate) {
                        document.getElementById(obj + x).value = "";
                        document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                        document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "To Date Cannot Be Less Than Or Equal To From Date";
                        document.getElementById(obj + x).style.borderColor = "Red";
                        document.getElementById(obj + x).focus();
                        ret = false;
                    }
                    else {




                        var StartDatetime = new Date();
                        var EndDatetime = new Date();
                        var CurrStartDatetime = new Date();
                        var CurrEndDatetime = new Date();

                        var y = document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value;
                        for (var i = 1; i <= y; i++) {
                            StartDatetime = document.getElementById("txtselectorFrmDateTime" + i).value;
                            EndDatetime = document.getElementById("txtselectorToDateTime" + i).value;

                            CurrStartDatetime = document.getElementById("txtselectorFrmTime" + x).value;
                            CurrEndDatetime = document.getElementById("txtselectorToTime" + x).value;
                            if (StartDatetime != "" && EndDatetime != "") {

                                StartDatetime = convertDateTo24Hour(StartDatetime);
                                EndDatetime = convertDateTo24Hour(EndDatetime);
                                CurrStartDatetime = convertDateTo24Hour(CurrStartDatetime);
                                CurrEndDatetime = convertDateTo24Hour(CurrEndDatetime);
                                if (StartDatetime > CurrStartDatetime && StartDatetime < CurrEndDatetime || CurrStartDatetime > StartDatetime && CurrStartDatetime < EndDatetime || CurrStartDatetime == StartDatetime) {
                                    document.getElementById("txtselectorFrmTime" + x).value = "";
                                    document.getElementById("txtselectorToTime" + x).value = "";
                                    document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                    document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Date Cannot Be Overlapped";
                                    document.getElementById("txtselectorFrmTime" + x).style.borderColor = "Red";
                                    document.getElementById("txtselectorToTime" + x).style.borderColor = "Red";
                                    document.getElementById("txtselectorFrmTime" + x).focus();
                                    ret = false;
                                }
                            }
                        }





                        if (ret != false) {

                            var empid = document.getElementById("<%=HiddenFieldEmployeeId.ClientID%>").value;
                            var fromdate = document.getElementById("txtselectorFrmTime" + x).value;
                            var todate = document.getElementById("txtselectorToTime" + x).value;
                            var SubmsnId = document.getElementById("<%=HiddenFieldSubmissionId.ClientID%>").value;
                            var Details = PageMethods.CheckEmpDuplctn(empid, fromdate, todate,SubmsnId, function (response) {

                                if (response == "false") {
                                    document.getElementById("txtselectorFrmTime" + x).value = "";
                                    document.getElementById("txtselectorToTime" + x).value = "";
                                    document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                    document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Another job is submitted with the selected dates";
                                    document.getElementById("txtselectorFrmTime" + x).style.borderColor = "Red";
                                    document.getElementById("txtselectorToTime" + x).style.borderColor = "Red";
                                    document.getElementById("txtselectorFrmTime" + x).focus();
                                    ret = false;
                                }

                            });
                        }








                        if (ret != false) {

                            var z = document.getElementById("<%= HiddenFieldAddtnlJobRowCount.ClientID%>").value;
                            var DeleteRowNumData = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;
                            var DeleteRowNum = DeleteRowNumData.split(',');
                            var count = DeleteRowNum.length;

                            for (var i = 1; i <= z; i++) {

                                var deleSTS = "false";
                                for (var j = 0; j < count; j++) {
                                    if (i == DeleteRowNum[j]) {
                                        deleSTS = "true";
                                    }
                                }

                                if (deleSTS == "false") {


                                    StartDatetime = document.getElementById("txtselectorFrmTime" + i).value;
                                    EndDatetime = document.getElementById("txtselectorToTime" + i).value;
                                    if (i != x && StartDatetime != "" && EndDatetime != "") {

                                        StartDatetime = convertDateTo24Hour(StartDatetime);
                                        EndDatetime = convertDateTo24Hour(EndDatetime);
                                        if (StartDatetime > CurrStartDatetime && StartDatetime < CurrEndDatetime || CurrStartDatetime > StartDatetime && CurrStartDatetime < EndDatetime || CurrStartDatetime == StartDatetime) {
                                            document.getElementById("txtselectorFrmTime" + x).value = "";
                                            document.getElementById("txtselectorToTime" + x).value = "";
                                            document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                            document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Date Cannot Be Overlapped";
                                            document.getElementById("txtselectorFrmTime" + x).style.borderColor = "Red";
                                            document.getElementById("txtselectorToTime" + x).style.borderColor = "Red";
                                            document.getElementById("txtselectorFrmTime" + x).focus();
                                            ret = false;
                                        }
                                    }


                                }
                            }

                        }


                    }
                }
            }

          
            if (ret == false)
            {
               
                //Start:-For update time sheet table after delete

                //For From time
            var y = document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value;
            var StartDateTime = new Date();
            var EndDateTime = new Date();
            var StartDateTime1 = new Date();
            var EndDateTime1 = new Date();

            StartDateTime = document.getElementById("txtselectorFrmDateTime1").value;
            StartDateTime1 = StartDateTime;
            if (StartDateTime != "") {
                StartDateTime = convertDateTo24Hour(StartDateTime);
            }



            if (y > 1) {

                for (var i = 2; i <= y; i++) {

                    EndDateTime = document.getElementById("txtselectorFrmDateTime" + i).value;
                    EndDateTime1 = EndDateTime;
                    if (EndDateTime != "") {
                        EndDateTime = convertDateTo24Hour(EndDateTime);
                        if (StartDateTime == "" || EndDateTime < StartDateTime) {

                            StartDateTime = EndDateTime;
                            StartDateTime1 = EndDateTime1;
                        }

                    }
                }
            }

            var z = document.getElementById("<%= HiddenFieldAddtnlJobRowCount.ClientID%>").value;

            var DeleteRowNumData = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;
            var DeleteRowNum = DeleteRowNumData.split(',');
            var count = DeleteRowNum.length;

            for (var i = 1; i <= z; i++) {

                var deleSTS = "false";
                for (var x = 0; x < count; x++) {
                    if (i == DeleteRowNum[x]) {
                        deleSTS = "true";
                    }
                }

                if (deleSTS == "false") {

                    EndDateTime = document.getElementById("txtselectorFrmTime" + i).value;
                    EndDateTime1 = EndDateTime;
                    if (EndDateTime != "") {

                        EndDateTime = convertDateTo24Hour(EndDateTime);
                        if (StartDateTime == "" || EndDateTime < StartDateTime) {

                            StartDateTime = EndDateTime;
                            StartDateTime1 = EndDateTime1;
                        }

                    }
                }
            }
            document.getElementById("txtTimeSheetStartDateTime").value = StartDateTime1;



            //For To Time
            var y = document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value;
            var StartDateTime = new Date();
            var EndDateTime = new Date();
            var StartDateTime1 = new Date();
            var EndDateTime1 = new Date();

            StartDateTime = document.getElementById("txtselectorToDateTime1").value;
            StartDateTime1 = StartDateTime;
            if (StartDateTime != "") {
                StartDateTime = convertDateTo24Hour(StartDateTime);
            }



            if (y > 1) {
              
                for (var i = 2; i <= y; i++) {

                    EndDateTime = document.getElementById("txtselectorToDateTime" + i).value;
                    EndDateTime1 = EndDateTime;
                    if (EndDateTime != "") {
                        EndDateTime = convertDateTo24Hour(EndDateTime);
                        if (StartDateTime == "" || EndDateTime > StartDateTime) {
                         
                            StartDateTime = EndDateTime;
                            StartDateTime1 = EndDateTime1;
                        }

                    }
                }
            }

            var z = document.getElementById("<%= HiddenFieldAddtnlJobRowCount.ClientID%>").value;

            var DeleteRowNumData = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;
            var DeleteRowNum = DeleteRowNumData.split(',');
            var count = DeleteRowNum.length;

            for (var i = 1; i <= z; i++) {

                var deleSTS = "false";
                for (var x = 0; x < count; x++) {
                    if (i == DeleteRowNum[x]) {
                        deleSTS = "true";
                    }
                }

                if (deleSTS == "false") {

                    EndDateTime = document.getElementById("txtselectorToTime" + i).value;
                    EndDateTime1 = EndDateTime;
                    if (EndDateTime != "") {

                        EndDateTime = convertDateTo24Hour(EndDateTime);
                        if (StartDateTime == "" || EndDateTime > StartDateTime) {

                            StartDateTime = EndDateTime;
                            StartDateTime1 = EndDateTime1;
                        }

                    }
                }
            }

          
            document.getElementById("txtTimeSheetEndDateTime").value = StartDateTime1;

            //End:-For update time sheet table after delete
            }


            return ret;

        }



        function BlurJSTime(obj, x, DefaultTxt) {



            document.getElementById('divErrorNotificationSb').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "";
            var Rcptdate = document.getElementById(obj + x).value;
            if (Rcptdate == "") {
                //return true;
            }
            if (DateCheck(obj, x, true) == true) {
                if (FromToDateCheck(obj, x) == true ) {



                    var y = document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value;
                    var StartDateTime = new Date();
                    var EndDateTime = new Date();
                    var StartDateTime1 = new Date();
                    var EndDateTime1 = new Date();
                    if (obj == "txtselectorFrmDateTime" || obj == "txtselectorFrmTime") {

                        StartDateTime = document.getElementById("txtselectorFrmDateTime1").value;
                        StartDateTime1 = StartDateTime;
                        if (StartDateTime != "") {
                            StartDateTime = convertDateTo24Hour(StartDateTime);
                        }

                    }
                    else {
                        StartDateTime = document.getElementById("txtselectorToDateTime1").value;
                        StartDateTime1 = StartDateTime;
                        if (StartDateTime != "") {
                            StartDateTime = convertDateTo24Hour(StartDateTime);
                        }

                    }


                    if (y > 1) {

                        for (var i = 2; i <= y; i++) {


                            if (obj == "txtselectorFrmDateTime" || obj == "txtselectorFrmTime") {

                                EndDateTime = document.getElementById("txtselectorFrmDateTime" + i).value;
                                EndDateTime1 = EndDateTime;
                                if (EndDateTime != "") {
                                    EndDateTime = convertDateTo24Hour(EndDateTime);
                                    if (StartDateTime == "" || EndDateTime < StartDateTime) {

                                        StartDateTime = EndDateTime;
                                        StartDateTime1 = EndDateTime1;
                                    }

                                }
                            }
                            else {
                                EndDateTime = document.getElementById("txtselectorToDateTime" + i).value;
                                EndDateTime1 = EndDateTime;
                                if (EndDateTime != "") {
                                    EndDateTime = convertDateTo24Hour(EndDateTime);
                                    if (StartDateTime == "" || EndDateTime > StartDateTime) {

                                        StartDateTime = EndDateTime;
                                        StartDateTime1 = EndDateTime1;
                                    }
                                }
                            }

                        }
                    }

                    var z = document.getElementById("<%= HiddenFieldAddtnlJobRowCount.ClientID%>").value;

                    var DeleteRowNumData = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;
                    var DeleteRowNum = DeleteRowNumData.split(',');
                    var count = DeleteRowNum.length;

                    for (var i = 1; i <= z; i++) {

                        var deleSTS = "false";
                        for (var x = 0; x < count; x++) {
                            if (i == DeleteRowNum[x]) {
                                deleSTS = "true";
                            }
                        }

                        if (deleSTS == "false") {

                            if (obj == "txtselectorFrmDateTime" || obj == "txtselectorFrmTime") {


                                EndDateTime = document.getElementById("txtselectorFrmTime" + i).value;
                                EndDateTime1 = EndDateTime;
                                if (EndDateTime != "") {

                                    EndDateTime = convertDateTo24Hour(EndDateTime);
                                    if (StartDateTime == "" || EndDateTime < StartDateTime) {

                                        StartDateTime = EndDateTime;
                                        StartDateTime1 = EndDateTime1;
                                    }

                                }
                            }
                            else {
                                EndDateTime = document.getElementById("txtselectorToTime" + i).value;
                                EndDateTime1 = EndDateTime;
                                if (EndDateTime != "") {
                                    EndDateTime = convertDateTo24Hour(EndDateTime);
                                    if (StartDateTime == "" || EndDateTime > StartDateTime) {

                                        StartDateTime = EndDateTime;
                                        StartDateTime1 = EndDateTime1;
                                    }
                                }
                            }

                        }
                    }
                    setTimeout(DisplayTime(obj, StartDateTime1), 20);
                    DisplayTime(obj, StartDateTime1);


                    //Start:-To calculate total work hour
                    if (document.getElementById("txtTimeSheetStartDateTime").value != "" && document.getElementById("txtTimeSheetEndDateTime").value != "") {

                        document.getElementById("txtIdleHrs").disabled = false;


                        var date1 = convertDateTo24Hour(document.getElementById("txtTimeSheetEndDateTime").value);
                        var date2 = convertDateTo24Hour(document.getElementById("txtTimeSheetStartDateTime").value);

                        var date1Split = date1.split(" ");
                        var date1Date = date1Split[0];
                        var date1DateDMY = date1Date.split("/");
                        var date1DateD = date1DateDMY[0];
                        var date1DateM = date1DateDMY[1];
                        var date1DateY = date1DateDMY[2];
                        var date1Time = date1Split[1];
                        var date1TimeSplit = date1Time.split(":");
                        var date1TimeHR = date1TimeSplit[0];
                        var date1TimeMn = date1TimeSplit[1];

                        var date2Split = date2.split(" ");
                        var date2Date = date2Split[0];
                        var date2DateDMY = date2Date.split("/");
                        var date2DateD = date2DateDMY[0];
                        var date2DateM = date2DateDMY[1];
                        var date2DateY = date2DateDMY[2];
                        var date2Time = date2Split[1];
                        var date2TimeSplit = date2Time.split(":");
                        var date2TimeHR = date2TimeSplit[0];
                        var date2TimeMn = date2TimeSplit[1];


                        var firstDate = new Date(date1DateY, date1DateM, date1DateD, date1TimeHR, date1TimeMn);
                        var secondDate = new Date(date2DateY, date2DateM, date2DateD, date2TimeHR, date2TimeMn);

                        var hours = Math.abs(firstDate - secondDate) / 36e5;
                        document.getElementById("txtTotalWrkHr").value = hours.toFixed(2);

                        var totalHr = parseFloat(document.getElementById("txtTotalWrkHr").value);
                        var NrmlHr = parseFloat(document.getElementById("txtNrmlWrkHr").value);
                        if (document.getElementById("txtIdleHrs").value != "") {
                            var idlHr = parseFloat(document.getElementById("txtIdleHrs").value);
                        }
                        else {
                            var idlHr = 0;
                        }
                        if (totalHr > NrmlHr) {
                            var FinalOT = totalHr - (NrmlHr + idlHr);
                            document.getElementById("txtFinalOT").value = FinalOT.toFixed(2);
                            document.getElementById("txtRoundedOT").value = FinalOT.toFixed(2);
                            document.getElementById("txtRoundedOT").disabled = false;
                        }
                        else {
                            document.getElementById("txtFinalOT").value = "";
                            document.getElementById("txtRoundedOT").value = "";
                            document.getElementById("txtRoundedOT").disabled = true;
                        }
                    }
                    else {
                        document.getElementById("txtTotalWrkHr").value = "";
                        document.getElementById("txtFinalOT").value = "";
                        document.getElementById("txtRoundedOT").value = "";
                        document.getElementById("txtIdleHrs").value = "";
                        document.getElementById("txtRoundedOT").disabled = true;
                        document.getElementById("txtIdleHrs").disabled = true;
                    }
                    //End:-To calculate total work hour




                    var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
                    if (SavedorNot == "saved") {

                        LocalStorageEditjobAddtnl(x, row_index);

                    }

                    else {

                        LocalStorageAddjobAddtnl(x);

                    }
                }
            }
            else {
                return false;
            }

        }
        function DateCheck(obj, x, rtn) {


            var ret = true;
            var Val = document.getElementById(obj + x).value;
            var Rcptdate = document.getElementById(obj + x).value;

            document.getElementById('divErrorNotificationSb').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "";
            if (Rcptdate == "") {
                ret = false;
            }
            else {
                var Date1st = Rcptdate.split(" ");
                var RCPTdate = Date1st[0];

                if (Date1st[1] == undefined || Date1st[2] == undefined) {
                    document.getElementById(obj + x).value = "";

                    ret = false;
                }
                else {

                    var RCPTtime = Date1st[1];
                    var RCPTampm = Date1st[2];

                    if (RCPTampm != "AM" && RCPTampm != "PM" && RCPTampm != "am" && RCPTampm != "pm") {

                        document.getElementById(obj + x).value = "";

                        ret = false;

                    }
                    var RCPTtimeData = RCPTtime.split(":");
                    if (RCPTtimeData[0] == undefined || RCPTtimeData[1] == undefined) {
                        document.getElementById(obj + x).value = "";

                        ret = false;
                    }
                    else {
                        var RCPTtimeHr = RCPTtimeData[0];
                        if (RCPTtimeHr < 10) {
                            RCPTtimeHr = "0" + parseInt(RCPTtimeHr);

                        }
                        var RCPTtimeMn = RCPTtimeData[1];
                        if (RCPTtimeMn < 10) {
                            RCPTtimeMn = "0" + parseInt(RCPTtimeMn);

                        }
                    }
                }

                if (ret != false) {

                    var RCPTdata = RCPTdate.split("/");
                    if (isNaN(parseInt(RCPTdata[0])) == true || isNaN(parseInt(RCPTdata[1])) == true || isNaN(parseInt(RCPTdata[2])) == true || isNaN(parseInt(RCPTtimeHr)) == true || isNaN(parseInt(RCPTtimeMn)) == true) {
                        ret = false;

                    }
                    else {


                        if (isNaN(Date.parse(RCPTdata[2] + "/" + RCPTdata[1] + "/" + RCPTdata[0] + " " + RCPTtimeHr + ":" + RCPTtimeMn + " " + RCPTampm))) {
                            ret = false;

                        }
                        else {

                            var FormatDatearr = Rcptdate.split(" ");
                            var FormatDatearr1 = FormatDatearr[0].split("/");
                            var txtDay = FormatDatearr1[0];
                            var txtMonth = FormatDatearr1[1];
                            var txtYear = FormatDatearr1[2];

                            if (txtDay < 10) {
                                txtDay = "0" + parseInt(txtDay);
                            }
                            if (txtMonth < 10) {
                                txtMonth = "0" + parseInt(txtMonth);
                            }
                            document.getElementById(obj + x).value = txtDay + '/' + txtMonth + '/' + txtYear + ' ' + RCPTtimeHr + ':' + RCPTtimeMn + ' ' + RCPTampm;

                            if (isNaN(Date.parse(txtYear + "/" + txtMonth + "/" + txtDay))) {

                                ret = false;

                            }


                        }


                    }

                }


            }

            if (ret == false) {

                document.getElementById(obj + x).value = "";
                document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Invalid Date & Time Format";
                document.getElementById(obj + x).style.borderColor = "Red";
                //document.getElementById(obj + x).focus();
            }

            if (rtn == true) {

                var Rcptdate = document.getElementById(obj + x).value;
                var Date1st = Rcptdate.split(" ");
                var RCPTdate = Date1st[0];


                var RcptdatepickerDate = RCPTdate;
                var RarrDatePickerDate = RcptdatepickerDate.split("/");
                var RdateDateCntrlr = new Date(RarrDatePickerDate[2], RarrDatePickerDate[1] - 1, RarrDatePickerDate[0]);


                var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                if (RdateDateCntrlr > dateCurrentDate) {
                    document.getElementById(obj + x).style.borderColor = "Red";
                    document.getElementById(obj + x).value = "";
                    document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Sorry,Date cannot be Greater than Current Date !.";
                    ret = false;
                }

            }



            if (ret == false) {

                //Start:-For update time sheet table after delete

                //For From time
                var y = document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value;
                  var StartDateTime = new Date();
                  var EndDateTime = new Date();
                  var StartDateTime1 = new Date();
                  var EndDateTime1 = new Date();

                  StartDateTime = document.getElementById("txtselectorFrmDateTime1").value;
                  StartDateTime1 = StartDateTime;
                  if (StartDateTime != "") {
                      StartDateTime = convertDateTo24Hour(StartDateTime);
                  }



                  if (y > 1) {

                      for (var i = 2; i <= y; i++) {

                          EndDateTime = document.getElementById("txtselectorFrmDateTime" + i).value;
                          EndDateTime1 = EndDateTime;
                          if (EndDateTime != "") {
                              EndDateTime = convertDateTo24Hour(EndDateTime);
                              if (StartDateTime == "" || EndDateTime < StartDateTime) {

                                  StartDateTime = EndDateTime;
                                  StartDateTime1 = EndDateTime1;
                              }

                          }
                      }
                  }

                  var z = document.getElementById("<%= HiddenFieldAddtnlJobRowCount.ClientID%>").value;

            var DeleteRowNumData = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;
                  var DeleteRowNum = DeleteRowNumData.split(',');
                  var count = DeleteRowNum.length;

                  for (var i = 1; i <= z; i++) {

                      var deleSTS = "false";
                      for (var x = 0; x < count; x++) {
                          if (i == DeleteRowNum[x]) {
                              deleSTS = "true";
                          }
                      }

                      if (deleSTS == "false") {

                          EndDateTime = document.getElementById("txtselectorFrmTime" + i).value;
                          EndDateTime1 = EndDateTime;
                          if (EndDateTime != "") {

                              EndDateTime = convertDateTo24Hour(EndDateTime);
                              if (StartDateTime == "" || EndDateTime < StartDateTime) {

                                  StartDateTime = EndDateTime;
                                  StartDateTime1 = EndDateTime1;
                              }

                          }
                      }
                  }
                  document.getElementById("txtTimeSheetStartDateTime").value = StartDateTime1;



                  //For To Time
                  var y = document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value;
            var StartDateTime = new Date();
            var EndDateTime = new Date();
            var StartDateTime1 = new Date();
            var EndDateTime1 = new Date();

            StartDateTime = document.getElementById("txtselectorToDateTime1").value;
            StartDateTime1 = StartDateTime;
            if (StartDateTime != "") {
                StartDateTime = convertDateTo24Hour(StartDateTime);
            }



            if (y > 1) {

                for (var i = 2; i <= y; i++) {

                    EndDateTime = document.getElementById("txtselectorToDateTime" + i).value;
                    EndDateTime1 = EndDateTime;
                    if (EndDateTime != "") {
                        EndDateTime = convertDateTo24Hour(EndDateTime);
                        if (StartDateTime == "" || EndDateTime > StartDateTime) {

                            StartDateTime = EndDateTime;
                            StartDateTime1 = EndDateTime1;
                        }

                    }
                }
            }

            var z = document.getElementById("<%= HiddenFieldAddtnlJobRowCount.ClientID%>").value;

            var DeleteRowNumData = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;
                  var DeleteRowNum = DeleteRowNumData.split(',');
                  var count = DeleteRowNum.length;

                  for (var i = 1; i <= z; i++) {

                      var deleSTS = "false";
                      for (var x = 0; x < count; x++) {
                          if (i == DeleteRowNum[x]) {
                              deleSTS = "true";
                          }
                      }

                      if (deleSTS == "false") {

                          EndDateTime = document.getElementById("txtselectorToTime" + i).value;
                          EndDateTime1 = EndDateTime;
                          if (EndDateTime != "") {

                              EndDateTime = convertDateTo24Hour(EndDateTime);
                              if (StartDateTime == "" || EndDateTime > StartDateTime) {

                                  StartDateTime = EndDateTime;
                                  StartDateTime1 = EndDateTime1;
                              }

                          }
                      }
                  }


                  document.getElementById("txtTimeSheetEndDateTime").value = StartDateTime1;

                  //End:-For update time sheet table after delete
              }


            return ret;
        }

        // checks every field in row
        function CheckAllRowFieldAddtnlJobs(x, row_index) {
            ret = true;

            var Job = document.getElementById("txtselectorJobId" + x).value;
            if (Job == "--Select Job--") {
                ret = false;

            }


            var Vhcl = document.getElementById("txtselectorVhclId" + x).value;
            if (Vhcl == "--Select Vehicle--") {
                ret = false;

            }

            var FrmTime = document.getElementById("txtselectorFrmTime" + x).value;
            if (FrmTime == "--Select Time--") {
                ret = false;

            }
            var ToTime = document.getElementById("txtselectorToTime" + x).value;
            if (ToTime == "--Select Time--") {
                ret = false;

            }


            return ret;
        }

        function SuccessLeaveSubmit() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave allocated to the employee sucessfully.";

        }
        function SuccessCreationDutySlp() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duty slip created successfully.";

        }
        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Job submission saved successfully.";

        }
        function SuccessSchedule() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Job sheduled successfully.";

        }

        function clearSTS() {
            document.getElementById("<%=HiddenFieldStatusDropdown.ClientID%>").value = "";
        }
        function SuccessConfirm() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Job submission confirmed successfully.";

        }

        function confirmSub() {

            if (confirm("Are You Sure You Want To Confirm this entry?")) {
                if (validateSubmit() == true) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }

        function SuccessConfirmSubmit() {

            //if (confirm("Are You Sure You Want To Confirm this entry?")) {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Job submission confirmed successfully.";
            //}
            //else {
            //    return false;
            //}

        }
        function SuccessReopenSubmit() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Job submission re-opened successfully.";

        }
        function DutySlipSubmited()
        {
            alert('Duty Slip Submitted Already');
        }

        function ConfirmMarkLeave() {

            var ret = true;

            if (CheckIsRepeat() == true) {

            }
            else {
                ret = false;
            }

            if (confirm("Are you sure?.You want mark leave.")) {
                ret= true;
            }
            else {

                ret= false;
            }


            if (ret == false) {

                CheckSubmitZero();

            }
            else {
                clearSTS();
            }
           
            return ret;
        }


        function ValidateSearch() {
            var ret = true;

            if (CheckIsRepeat() == true) {

            }
            else {
                ret = false;
            }


            var EmpSear = document.getElementById("<%=ddlEmployee.ClientID%>");
            var EmpSearText = EmpSear.options[EmpSear.selectedIndex].text;
            //if (EmpSearText != "--SELECT EMPLOYEE--") {
            //    ret = true;
            //}
            //else {
            //    ret = false;
            //}

            if (ret == false) {

                CheckSubmitZero();

            }
            else {
                clearSTS();
            }

            return ret;
        }

    </script>
    <script src="/JavaScript/DateTimeForDtyRstr/build/jquery.datetimepicker.full.js"></script>
    <link href="/JavaScript/DateTimeForDtyRstr/build/jquery.datetimepicker.min.css" rel="stylesheet" />
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
      <asp:HiddenField ID="hiddenAllowJobDuplication" runat="server" Value="1" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
     <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
    <asp:HiddenField ID="hiddenDataDayWise" runat="server" />
    <asp:HiddenField ID="hiddenddlTimeSlotDWVal" runat="server" />
    <asp:HiddenField ID="hiddenWeekDayId" runat="server" />
     <asp:HiddenField ID="hiddenPreviousTimeSlot" runat="server" />
     <asp:HiddenField ID="hiddenDayWiseTimeDifferenceSts" runat="server" />
     <asp:HiddenField ID="hidden_DefalultEndTimeDayWise" runat="server" />
    <asp:HiddenField ID="hidden_DefalultStartTimeDayWise" runat="server" />
      <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenFirstDate" runat="server" />
    <asp:HiddenField ID="hiddenLastDate" runat="server" />
     <asp:HiddenField ID="hiddenPrevious" runat="server" />
    <asp:HiddenField ID="hiddenNext" runat="server" />
    <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />

    <%------------- Start:-EMP-0009  ------------%>
    <asp:HiddenField ID="hiddenJSIdFocus" runat="server" />
    <asp:HiddenField ID="hiddenJSNameFocus" runat="server" />
    <asp:HiddenField ID="hiddenddlTimeSlotPWVal" runat="server" />
    <asp:HiddenField ID="HiddenFieldEmployeeId" runat="server" />
    <asp:HiddenField ID="HiddenFieldDate" runat="server" />
    <asp:HiddenField ID="HiddenFieldLoginUserId" runat="server" />
    <asp:HiddenField ID="HiddenFieldRowCount" runat="server" />
    <asp:HiddenField ID="HiddenFieldAddtnlJobs" runat="server" />
    <asp:HiddenField ID="HiddenFieldDutyRostrId" runat="server" />
    <asp:HiddenField ID="HiddenFieldTimeSheet" runat="server" />
    <asp:HiddenField ID="HiddenFieldJobSbmsnDtls" runat="server" />
    <asp:HiddenField ID="HiddenFieldSubmissionId" runat="server" />
    <asp:HiddenField ID="HiddenFieldStatusDropdown" runat="server" />
    <asp:HiddenField ID="HiddenFieldAddtnlJobRowCount" runat="server" />
    <asp:HiddenField ID="HiddenFieldConfrmSts" runat="server" />
   <asp:HiddenField ID="HiddenFieldCancelAddtnJobDtlId" runat="server" />
         <asp:HiddenField ID="HiddenFieldCancelAddtnJobRowNum" runat="server" />

    <asp:HiddenField ID="hiddenDutyMasterId" runat="server" />
      <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
     <asp:HiddenField ID="hiddenLeaveMarkDetails" runat="server" />


     <asp:HiddenField ID="HiddenHalfdayStatus" runat="server" />
     <asp:HiddenField ID="HiddenHalfdaySection" runat="server" />

   <%------------- End:-EMP-0009  ------------%>
     <asp:Label ID="lblIndex" runat="server" Text="Label" Style="display: none"></asp:Label>
     <div class="cont_rght" style="width:1171px;margin-left:10px">
    
                   <div id="divMessageArea" style="display: none; margin:0px 0 13px;">
                 <img id="imgMessageArea" src="" >
                <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>

         
        <div class="fillform" style="width:100%;">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server">Duty Roster</asp:Label>
            </div>
            <br />
            
            <div id="divTotal">

                <div style="width:100%;border:10px solid;padding: 2px;border-color: #83a2a8;">
                    <div style="width:100%;">
                    <div style="width:29.9%;height:179px;float:left;border:1px solid;border-color: #1b4d60;background-color: #e4e4e4;">
                         
                        <div style="margin-left: 32%;margin-top: 22px;float: left;">
                         <label style="font-size: 29px;color: #024c5c;font-family: calibri;cursor: inherit;">Employee</label>
                   
                            </div>
                        <div id="divSearch" style="float: left;width: 91%;margin-top: 25px;padding: 2%;margin-left: 2%;background: #adadad;">

                           <asp:Button ID="btnEmployeeSearch" class="save" runat="server" Text="Search" OnClick="btnEmployeeSearch_Click" OnClientClick="return ValidateSearch()" style="width: 25%; float:right;margin-right: 9%;background: #034c59;margin: 2px 11px 0px 2px;" />     
                         <asp:DropDownList ID="ddlEmployee" class="form1"  style="height:25px;width:58%;margin-right: 4%;" runat="server"></asp:DropDownList>
                             </div>

                        <div  id="divNarateBtns" style="float: left;width: 95%;margin-top: 20px;margin-left: 2%;">

                            <asp:Button ID="btnPrevious" Width="49%" runat="server" class="Emplist_btn_rght" Text="Show Previous 25 Employee" OnClientClick="return ValidateSearch()" OnClick="btnPrevious_Click" />

                           <asp:Button ID="btnNext" style="width:49%;margin-left: 2%;" runat="server" class="Emplist_btn_rght" Text="Show Next 25 Employee" OnClientClick="return ValidateSearch()" OnClick="btnNext_Click"/>

                        </div>

                    </div>
                    <div style="width:69.7%;height:179px;float:right;border:1px solid;border-color: #1b4d60;background-color: #e4e4e4;">
                        <div>
                           <div style="width:10%;float:left">
                                 <asp:ImageButton ID="DateBack" runat="server" src="/Images/Icons/DateArrowLeft.png" OnClick="DateBack_Click" OnClientClick="clearSTS()" alt="back" style="cursor: pointer;margin-left: 19px;width: 65%;"/>
                            </div>
                        <div id="divMonthAndYear" runat="server" style="width:78%;float:left;height: 49px;background-color: #f5f5f5;margin-left: 1%;">
                            <div id="divYear" runat="server" style="width:60%;margin-left:20%;font-size: 23px;margin-top: 2%;color: #071f75;font-family: calibri;">

                                <label id="lblFromDuty" style="width: 40%;display: block;text-align: center;float:left" runat="server"></label>
                                <label style="display: block;color: #700;width: 20%;float: left;text-align: center;">To</label>
                                 <label style="width: 40%;display: block;text-align: center;float:left" id="lblToDuty" runat="server"></label>
                            </div>
                       
                        </div>
                             <div style="width:10%;float:right">
                                 <asp:ImageButton ID="DateFront" runat="server" src="/Images/Icons/DateArrowRight.png" OnClick="DateFront_Click" OnClientClick="clearSTS()" alt="back" style="cursor: pointer;width: 65%;margin-left: 10px;"/>

                            </div>
                          </div>
                        <div id="divTopMainContainer" runat="server" style="width:100%;height:100px;float: left;">


                        </div>
                    </div>
                        </div>
                     
                    <div  style="width:100%;">
                         <div id="divEmployeeContain" runat="server" style="font-family: calibri;">
                         </div>
                    </div>



                </div>

               
            </div>
   
        
            <br />
         
        </div>
    </div>


   <%-- ----------------for job shedule window//-----%>

    <div>
     <div id="MyModalJobShedule" class="MyModalJobShedule" >
         <div id="divJbFull">
             <div id="DivEmpHeader" style="height: 30px;background-color: #6f7b5a;">
                 
            <label style="margin-left: 43%;font-size: 22px;color: #fff;font-family: calibri;">Job Schedule</label>

                   <img class="closeCancelView" style= "margin-top: .5%; margin-right: 1%;float: right; cursor: pointer;" onclick="ClosJobShedule();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
             </div>
             <div style="float: left;margin: 13px;border: 1px solid;border-color: #d7c9c9;background-color: #efefef;margin-bottom: 6px;">
              <div id="JbShdlTop" style="width: 100%;float: left;margin-top: 1%;">
                  <h2 style="margin-left: 2%;width: 5%;float: left;">
                      Name  : 
                  </h2>
                 <label id="lblEmployeeName" style="float: left;color: #042f95;font-family: calibri;width: 55%;cursor:inherit"></label>
                 <h2 style="float: left;margin-left: 1%;width: 5%;">Date : </h2>
                  <label id="lblTodayDate" style="float: left;color: #042f87;width: 20%;margin-left: 3%;cursor:inherit"></label>
             </div>

              <div id="divTimeSlotDayWise" style="width: 30%; float: right; padding-left: 2%; margin-top: 1%;margin-right: 7%;" class="eachform">
                <h2 style="float: left; margin-top: 1.5%;">Time Slot *</h2>
                <asp:DropDownList ID="ddlTimeSlot_DayWise" class="form1" Style="width: 70.5%; float: right;" runat="server" onkeydown="return  DisableEnter(event);" onblur="return ChangeTimeSlot('ddlTimeSlot_DayWise');" onfocus="getPreviousDDLTimeSlot_SelectedVal('ddlTimeSlot_DayWise')"></asp:DropDownList>

            </div>

             <div id="divSheduleContainer" style="float: left;width: 100%;">
                  <div id="divErrorNotificationDW" style="visibility: hidden">
                    <asp:Label ID="lblErrorNotificationDW" runat="server"></asp:Label>
                </div>
                   <div id="divTablesDayWise" style="width: 98%; margin: 1%; padding-top: 0.6%;height:200px;overflow:auto;border:1px solid">

                    <table class="TableHeader" rules="all" style="width: 91%;margin-left: 2%;">
                        <tr>
                            <td style="font-size: 14px; width: 4%; padding-left: 0.5%; text-align: center;">Sl#</td>
                            <td style="font-size: 14px; width: 24%; padding-left: 0.5%; text-align: left;">Job</td>
                            <td style="font-size: 14px; width: 23%; padding-left: 0.5%; text-align: left;">Vehicle</td>
                            <td style="font-size: 14px; width: 23%; padding-left: 0.5%; text-align: left;">Project</td>
                            <td style="font-size: 14px; width:12%; padding-left: 0.5%; text-align: center;">From Time</td>
                            <td style="font-size: 14px; width: 12%; padding-left: 0.5%; text-align: center;">To Time</td>

                        </tr>
                    </table>

                    <div style="width: 100%; min-height: 75px; overflow-y: auto;">
                        <table id="TableaddedRowsDW" style="width: 98%;margin-left:2%">
                        </table>
                       
                    </div>
                        <span style="font-family: calibri; color: rgb(65, 78, 42);font-size: 14px;margin-top: 5%;float: left;"> *NOTE: You can use F9 key to toggle between direct  Job entry and existing Job selection.</span>
                    
                </div>

             </div>
             </div>
                <asp:Button ID="btnMarkLeave" class="save" runat="server" Text="Mark Leave" style="width: 114px; float:left;margin-left:88.5%;margin-top: 0%;background: #034c59;" OnClientClick="return ConfirmMarkLeave()" OnClick="btnMarkLeave_Click" />     
             <div style="float: left;margin: 13px;border: 1px solid;border-color: #d7c9c9;background-color: #efefef;width:97.5%;margin-top:1px">
                  <h2 style="margin-left: 2%;width: 16%;float: left;margin-bottom: 7px;">
                     VEHICLE DETAILS
                  </h2>
                 <div id="divVehicleDataContainer"style="width: 100%; margin: auto; padding-top: 0%;overflow:auto">
                     

                  <table class="TableHeaderVeh" rules="all" style="width: 96%;margin-left: 1.9%;">
                        <tr>
                            <td style="font-size: 14px; width: 5%; padding-left: 0.5%; text-align: center;">Sl#</td>
                            <td style="font-size: 14px; width: 65%; padding-left: 0.5%; text-align: left;">Vehicle</td>
                            <td style="font-size: 14px; width: 30%; padding-left: 0.5%; text-align: left;">Present Mileage</td>
                        </tr>
                    </table>
                 <div style="width: 98.8%; height:90px;">
                        <table id="TableVehicle" style="width: 97%;margin-left:2.1%;">
                        </table>
                       
                    </div>
             </div>
           </div>


               <asp:Button ID="btnSchedule" class="save" runat="server" Text="Schedule" style="width: 105px; float:left;margin-left:39%;margin-top: 0%;" OnClick="btnSchedule_Click" onclientclick="return ValidateAndSave();" />     
               <input type="button" id="btnScheduleCncl" class="save" style="width: 90px; float:right;margin-right:42%;margin-top: 0%;" onclick="ClosJobShedule();" value="Cancel" />

         </div>

         </div>
        </div>


     <%------------------ Start EMP-0009 -----------%>
     <%-- ----------------for job submitting window//-----%>

     <div id="MyModalJobSubmit" class="MyModalJobShedule" >
         <div id="divJobSubmit">
             <div id="divSubHeader" style="height: 30px;background-color: #6f7b5a;">
                 
            <label style="margin-left: 43%;font-size: 22px;color: #fff;font-family: calibri;">Job Submitting</label>

                   <img class="closeCancelView" style= "margin-top: .5%; margin-right: 1%;float: right; cursor: pointer;" onclick="ClosJobSubmit();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
             </div>            
              <div id="divSubTop" style="width: 100%;float: left;margin-top: 1%;">
                  <h2 style="margin-left: 2%;width: 5%;float: left;">
                      Name  : 
                  </h2>
                 <label id="lblSubName" style="float: left;color: #042f95;font-family: calibri;width: 55%;cursor:inherit"></label>
                 <h2 style="float: left;margin-left: 1%;width: 5%;">Date : </h2>
                  <label id="lblSubDate" style="float: left;color: #042f87;width: 20%;margin-left: 3%;cursor:inherit;font-family: calibri;Schedule Job"></label>
             </div>
             <div id="divErrorNotificationSb" style="visibility: hidden">
                    <asp:Label ID="lblErrorNotificationSb" runat="server"></asp:Label>
                </div>

             <div id="divTableSdlJob&JobSub" style="float: left;width: 98%;margin-left: 1%;background-color: #fff1f1;padding: 11px;">
             </div>
             <div id="divAddtnlJobs" style="float: left;width: 98%;margin-left: 1%;margin-top: 8px;background-color: #e7e7e7;padding: 11px;">
                  <h2 >
                     Additional Jobs
                  </h2>
                 <table class="TableHeader" rules="all" style="width: 90%;">
                        <tr>
                           
                            <td style="font-size: 14px; width: 20%; padding-left: 0.5%; text-align: left;">Date & Time From</td>
                            <td style="font-size: 14px; width: 20%; padding-left: 0.5%; text-align: left;">Date & Time To</td>
                            <td style="font-size: 14px; width: 20%; padding-left: 0.5%; text-align: left;">Vehicle</td>
                            <td style="font-size: 14px; width:40%; padding-left: 0.5%; text-align: center;">Job</td>

                        </tr>
                    </table>

                    <div style="width: 100%; min-height: 75px; overflow-y: auto;">
                        <table id="TableAddtnlJobs" style="width: 98%;">
                        </table>
                       
                    </div>
             </div>
             <div id="divTimeSheet" style="float: left;width: 98%;margin-left: 1%;margin-top: 6px;background-color: #eaeaea;padding: 7px;">                
             </div>
                       

               <asp:Button ID="btnSubConfirm" class="save" runat="server" Text="Confirm" style="width: 105px; float:left;margin-left:31%;margin-top: 3%;display:none;" OnClientClick="return confirmSub();" OnClick="btnSubConfirm_Click"  />     
               <asp:Button ID="btnSubReopen" class="save" runat="server" Text="Re-Open" style="width: 105px; float:left;margin-left:31%;margin-top: 3%;display:none;" OnClientClick="clearSTS()"  OnClick="btnSubReopen_Click"  />  
             <asp:Button ID="btnSubSave" class="save" runat="server" Text="Save" style="width: 90px; float:left;margin-left:1%;margin-top: 3%;" OnClientClick="return validateSubmit();" OnClick="btnSubSave_Click" />     
               <input type="button" id="btnSubCncl" class="save" style="width: 90px; float:left;margin-left:1%;margin-top: 3%;" onclick="ClosJobSubmit();" value="Cancel" />

         </div>

         </div>

     <div id="divMOdalPrintSlip" class="MyModalPrintSlip" >
         <div id="SlipPrintMain">
             <div id="divHeadPrint" style="height: 30px;background-color: #6f7b5a;">
                   <label style="margin-left: 43%;font-size: 22px;color: #fff;font-family: calibri;">Print Duty Slip</label>

                   <img class="closeCancelView" style= "margin-top: .5%; margin-right: 1%;float: right; cursor: pointer;" onclick="ClosPrintSlip();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
            
                 </div>
               <div id="div1" style="width: 28%;float: left;margin-top: 1%;">
                  <h2 style="margin-left: 2%;width: 25%;float: left;">
                     Date : 
                  </h2>
                 <label id="lblDatePrint" style="float: left;color: #042f95;font-family: calibri;width: 70%;"></label>
                   </div>
                   <div style="cursor: default; float: right;  margin-right:3.5%;margin-top:0.5%;font-family:Calibri;" class="print" onclick="CreatePrintredirect()">            
                                 <a id="print_cap" target="_blank" data-title="Item Listing"  href="/AWMS/AWMS_Master/gen_Duty_Roster/print/DutySlipPrint.html" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
                                  <span style="margin-top: 2px;float: right;"> Print</span></a>                                   
                                </div>
              <div id="div2" style="width: 59%;float: left;margin-top: 1%;margin-left: 36%;">
                  <h2 style="margin-left: 2%;width: 100%;float: left;">
                    Select Employee*
                  </h2>
                   </div>

             <div id="divSelectAll"  style="width: 21%;float: left;margin-top: 1%;margin-left: 75%;font-family: calibri;color: red;">
                 <asp:CheckBox ID="ChkSelectAllPrint" runat="server" Text="Select All" onclick="SelectAllPrint()" />
                 
             </div>
                   <div id="divEmployee container" style="width: 79%;font-family:Calibri; float: left;margin-top: 1%;margin-left: 10%;background-color: #afc7cc;height: 430px;overflow: auto;"> 
                       <div id="divCheckBox" runat="server">
                       <asp:CheckBoxList  ID="chkbxListEmployee"  runat="server">

                       </asp:CheckBoxList>
                   </div>

                   </div>



             
             </div>
         </div>

             <div id="divPrintReport" runat="server" style="display: none">
                                    <br />
                                </div>
         <div id="divPrintCaption" runat="server" style="display: none;">
    </div>
        <div id="divtile" runat="server" style="display: none"></div>

     <%--------------- Start EMP-0009  -----------------%>
     <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: black; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.8; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>

       <div id="myModalLoadingMail" class="modalLoadingMail">

                <!-- Modal content -->
                <div>

                    <img src="/Images/Other Images/LoadingMail.gif" style="width: 12%;" />


                </div>

            </div>
      <script>


          function SelectAllPrint() {
             
                  var intIndex = 0;
                  var rowCount = document.getElementById('cphMain_chkbxListEmployee').getElementsByTagName("input").length;

              for (i = 0; i < rowCount; i++) {
                      if (document.getElementById('cphMain_ChkSelectAllPrint').checked == true) {
                          if (document.getElementById("cphMain_chkbxListEmployee" + "_" + i)) {
                              if (document.getElementById("cphMain_chkbxListEmployee" + "_" + i).disabled != true)
                                  document.getElementById("cphMain_chkbxListEmployee" + "_" + i).checked = true;
                          }
                      }
                      else {
                          if (document.getElementById("cphMain_chkbxListEmployee" + "_" + i)) {
                              if (document.getElementById("cphMain_chkbxListEmployee" + "_" + i).disabled != true)
                                  document.getElementById("cphMain_chkbxListEmployee" + "_" + i).checked = false;
                          }
                      }
                  }
              
          }

          var $NonCon = jQuery.noConflict();
          function CreatePrintredirect() {
              var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
              var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
              var UserId = document.getElementById("<%=HiddenFieldLoginUserId.ClientID%>").value;
            var EmpIds = [];
            var chks = $("#<%=chkbxListEmployee.ClientID %> input:checkbox");
            hasChecked = false;
            for (var i = 0; i < chks.length; i++) {

                if (chks[i].checked) {
                    EmpIds.push(chks[i].value);
                    //alert(EmpIds);
                }
            }
            var TodayDate = document.getElementById("lblDatePrint").innerText;


            $NonCon.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_Duty_Roster.aspx/CreateDutySlipPrint",
                data: '{intCorpId: "' + CorpId + '",intOrgId:"' + OrgId + '" ,intUserid:"' + UserId + '" ,EmployeIds:"' + EmpIds + '",strDate:"' + TodayDate + '"}',
                dataType: "json",
                success: function (data) {

                    if (data.d != '' && data.d != null) {

                        document.getElementById("<%=divPrintReport.ClientID%>").innerHTML = data.d[0];
                        document.getElementById("<%=divPrintCaption.ClientID%>").innerHTML = data.d[1];
                    }
                }
            });
              window.location.href="gen_Duty_Roster.aspx";
        }

        function PrintDutySlip(TodayDate) {
            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
            var LogUserId = document.getElementById("<%=HiddenFieldLoginUserId.ClientID%>").value;
            $NonCon.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_Duty_Roster.aspx/DayWiseDutySlipCreateOrNot",
                data: '{intCorpId: "' + CorpId + '",intOrgId:"' + OrgId + '" ,DatePass:"' + TodayDate + '"}',
                dataType: "json",
                success: function (data) {

                    document.getElementById("cphMain_btnSubSave").style.display = "block";

                    //alert(data.d);
                    if (data.d != '' && data.d != null) {
                        if (data.d == "true") {
     
                            document.getElementById("lblDatePrint").innerText = TodayDate;

                            document.getElementById("divMOdalPrintSlip").style.display = "block";
                            document.getElementById("freezelayer").style.display = "";

                        }
                        else {
                            alert("DutySlip Is Not Created For the day.");
                        }

                    }
                }
            });


            //document.getElementById("lblDatePrint").innerText = TodayDate;

            //document.getElementById("divMOdalPrintSlip").style.display = "block";
            //document.getElementById("freezelayer").style.display = "";


            return false;
        }

        function ClosPrintSlip() {
            document.getElementById("divMOdalPrintSlip").style.display = "none";
            document.getElementById("freezelayer").style.display = "none";
        }




    </script>

    <style>
         .modalLoadingMail {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 30; /* Sit on top */
            padding-top: 19%; /* Location of the box */
            left: 0;
            top: 0;
            width: 90%; /* Full width */
            /*height: 58%;*/ /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: transparent;
            padding-left: 45%; /* Location of the box */
        }
     .MyModalJobShedule {
    display: none;
    position: fixed;
    z-index: 100;
    padding-top: 0%;
    left: 8%;
    top: 8%;
    width: 84%;
    height: 88%;
    overflow: auto;
    background-color: white;
    border: 3px solid;
    border-color: #6f7b5a;
}
      .MyModalPrintSlip {
    display: none;
    position: fixed;
    z-index: 100;
    padding-top: 0%;
    left: 25%;
    top: 10%;
    width: 52%;
    height: 85%;
    overflow: auto;
    background-color: white;
    border: 3px solid;
    border-color: #6f7b5a;
}
        .TableHeader {
            background-color: #A4B487;
            color: white;
            font-weight: bold;
            font-family: calibri;
            line-height: 15px;
        }
        .TableHeaderVeh {
    background-color: #6C6C6C;
    color: #02052a;
    font-weight: bold;
    font-family: calibri;
    line-height: 15px;
}

        #TableVehicle tr:nth-child(2n) {
    background-color: #e9e9e9;
}
        .tooltip {
    position: relative;
    z-index: 10;
    display: block;
    padding: 0px;
    font-size: 11px;
    opacity: 1;
    filter: alpha(opacity=0);
    visibility: visible;
}

.Emplist_btn_rght {
    float: left;
    font-family: Calibri;
    color: #FFF;
    font-size: 12px;
    padding: 5px 0px 5px 1px;
    background: #034c59;
}

input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
            cursor:default;
        }

            .Emplist_btn_rght:hover {
                background: #022c33;
            }
             .Emplist_btn_rght:focus {
                background: #022c33;
            }

            
    </style>
</asp:Content>

