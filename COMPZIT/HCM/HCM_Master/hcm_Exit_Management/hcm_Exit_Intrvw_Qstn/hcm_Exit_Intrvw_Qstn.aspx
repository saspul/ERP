<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Exit_Intrvw_Qstn.aspx.cs" Inherits="HCM_HCM_Master_hcm_Exit_Intrvw_Qstn_hcm_Exit_Intrvw_Qstn" %>

 <asp:Content ID="Content2" ContentPlaceHolderID="cphHead" Runat="Server">
     <style type="text/css">
        #TableHeaderBilling {
            background-color: #A4B487;
            color: white;
            font-weight: bold;
            font-family: calibri;
            line-height: 30px;
        }



        #TableFooterBilling {
            color: red;
            font-weight: bold;
            font-family: calibri;
            line-height: 25px;
        }



        #myTable {
            background-color: #039ED1;
            color: white;
            font-weight: bold;
            line-height: 30px;
        }
    </style>
    <style>
        
        .cont_rght {

    padding-bottom: 2%;
    padding-top: 2%;
    width:95%;
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
   
    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <%-- <script src="/JavaScript/jquery-1.8.3.min.js"></script>
  --%>   <script>
         var $au = jQuery.noConflict();

         (function ($au) {
             $au(function () {

                 $au('#cphMain_ddlDesg').selectToAutocomplete1Letter();

                 $au('form').submit(function () {


                 });
             });
         })(jQuery);

         var confirmbox = 0;

         function IncrmntConfrmCounter() {
             confirmbox++;
         }
         
         var $noCon = jQuery.noConflict();
         $noCon(window).load(function () {


             $("div#divCardNumber input.ui-autocomplete-input").select();

             document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";
             document.getElementById('divBlink').style.visibility = "hidden";

             localStorage.clear();
             

             var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;
             var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;
            

             // alert(ViewVal);
             if (EditVal != "") {


                 var find2 = '\\"\\[';
                 var re2 = new RegExp(find2, 'g');
                 var res2 = EditVal.replace(re2, '\[');

                 var find3 = '\\]\\"';
                 var re3 = new RegExp(find3, 'g');
                 var res3 = res2.replace(re3, '\]');
                 //   alert('res3' + res3);
                 var json = $noCon.parseJSON(res3);
                 for (var key in json) {
                     if (json.hasOwnProperty(key)) {
                         if (json[key].DTL_ID != "") {

                             //  alert('json[key].AddDesc ' + json[key].AddDesc);
                             EditListRows(json[key].QUESTION, json[key].DTL_ID);

                         }
                     }
                 }


             }

             else if (ViewVal != "") {
                 //document.getElementById("<%=ddlDesg.ClientID%>").disabled = true;
                   //  $("div#divCardNumber input.ui-autocomplete-input").attr("disabled", "disabled");

                     var find2 = '\\"\\[';
                     var re2 = new RegExp(find2, 'g');
                     var res2 = ViewVal.replace(re2, '\[');

                     var find3 = '\\]\\"';
                     var re3 = new RegExp(find3, 'g');
                     var res3 = res2.replace(re3, '\]');
                 //   alert('res3' + res3);
                     var json = $noCon.parseJSON(res3);
                     for (var key in json) {
                         if (json.hasOwnProperty(key)) {
                             if (json[key].DTL_ID != "") {

                                 ViewListRows(json[key].QUESTION, json[key].DTL_ID);

                             }
                         }
                     }

                 }
                 else {


                 }
             //  alert('hi');
             if (ViewVal == "") {

                 //alert("dfdfidofioidfodifoifsoi");
                 addMoreRows(this.form, false, false, 0);



                 //  alert('hi');
                

             }


             //    alert('loaded');

             document.getElementById("txtQuestions" + rowCount).style.borderColor = "";

         });

       
    </script>

      <script type="text/javascript">
          function PassSavedCustomerToLead() {

              var saved = "saved";
              if (window.opener != null && !window.opener.closed) {
                  window.opener.GetValueFromChild(saved);
              }
              window.close();
          }

          function CloseWindow() {
              window.close();

          }
</script>
      <script type="text/javascript">



          var $noC = jQuery.noConflict();
          var rowCount = 0;
          //rowCount for uniquness
          //row index add(+) and (-)delete count based on action
          var RowIndex = 0;

          function InitializeValues() {
              RowIndex = 0;
              rowCount = 0;
          }

          function addMoreRows(frm, boolFocus, boolAppendorNot, row_index) {
             // alert('addMoreRows');
              document.getElementById('divErrorNotification').style.visibility = "hidden";
              document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";
              rowCount++;
              RowIndex++;

              nMoney = 0;

              document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


              var recRow = '<tr id="rowId_' + rowCount + '" >';
              recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
              recRow += '<td style="width: 5.7%;text-align: center;padding: 2px;padding-right: 5px;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


              recRow += ' <td id="tdQuestions' + rowCount + '"  style="width: 63%;padding: 4px;">';
              recRow += ' <input  id="txtQuestions' + rowCount + '"  class="BillngEntryField"  type="text"  onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtQuestions\',' + rowCount + ')"   maxlength=95 style="text-align: left;text-tranform:uppercase; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;margin-left: -0.5%;"/>';
              recRow += '   </td> ';

              recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="/Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);" title="ADD" style="  cursor: pointer;"></td>';
              recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this entry?\');"  title="DELETE"  style=" cursor: pointer;" ></td>';


              recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
              recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
              recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">INS</td>';
              recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;"></td>';
              // recRow += '<td id="tdSlNumbr' + rowCount + '" style="display: none;"></td>';


              recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
              recRow += '</tr>';

              jQuery('#TableaddedRows').append(recRow);

          }


          function EditListRows(IntwCatDtlName, IntwCatDtlId) {


              if (IntwCatDtlName != "" && IntwCatDtlId != "") {

                  rowCount++;
                  RowIndex++;

                  document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();
                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 5.7%;text-align: center;padding: 2px;padding-right: 5px;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


                recRow += ' <td id="tdQuestions' + rowCount + '"  style="width: 63%;padding: 4px;">';
                recRow += ' <input  id="txtQuestions' + rowCount + '"  class="BillngEntryField"  type="text" value="' + IntwCatDtlName + '"  onkeypress="return isTag(event)" onblur="return BlurValue(\'txtQuestions\',' + rowCount + ')"    maxlength=95 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;margin-left: -0.5%;"/>';
                recRow += '   </td> ';

                

                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="/Images/Icons/addEntry.png"  alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);" title="ADD" style="  cursor: pointer;"></td>';

                if (document.getElementById("<%=HiddenSubCount.ClientID%>").value == 0) {
                    recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this entry?\');"  title="DELETE"  style=" cursor: pointer;" ></td>';
                }
                else {
                    recRow += '<td style="width: 1.5%; padding-left: 1px; opacity: 0.3;"><input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return notremoveRow(' + rowCount + ');"  title="DELETE"  style=" cursor: pointer;" ></td>';
                }

                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + IntwCatDtlId + '</td>';

                // recRow += '<td id="tdSlNumbr' + rowCount + '" style="display: none;"></td>';


                recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                recRow += '</tr>';




                jQuery('#TableaddedRows').append(recRow);
                document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";

                LocalStorageAdd(rowCount);
               
              }
              
            else {

                // alert('error');
            }
        }
        function ViewListRows(IntwCatDtlName, IntwCatDtlId) {


            //    alert('EditStockStatus' + EditStockStatus);// && EditHike != "" && EditAmount != "" && EditStockStatus != ""
            if (IntwCatDtlName != ""  && IntwCatDtlId != "") {

                //  alert('in view');
                rowCount++;
                RowIndex++;




                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();



                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 5.7%;text-align: center;padding: 2px;padding-right: 5px;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


                recRow += ' <td id="tdQuestions' + rowCount + '"  style="width: 63%;padding: 4px;">';
                recRow += ' <input  id="txtQuestions' + rowCount + '" disabled class="BillngEntryField"  type="text" value="' + IntwCatDtlName + '"  onkeypress="return isTag(\'event\')"  maxlength=95 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;margin-left: -0.5%;"/>';
                recRow += '   </td> ';

                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input disabled id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image"  class="BillngEntryField" src="/Images/Icons/addEntry.png"  alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);" title="ADD"  style="  cursor: pointer;"></td>';
                recRow += '<td style="width: 1.5%; padding-left: 1px; opacity : 0.3;"><input disabled type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this entry?\');"  title="DELETE"  style=" cursor: pointer;" ></td>';


                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + IntwCatDtlId + '</td>';

                // recRow += '<td id="tdSlNumbr' + rowCount + '" style="display: none;"></td>';


                recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                recRow += '</tr>';

                jQuery('#TableaddedRows').append(recRow);
                document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";
                //  document.getElementById("selectorItem" + rowCount).focus();
                // alert('add rows');




                LocalStorageAdd(rowCount);

            }
            else {

                // alert('error');
            }

        }

          function notremoveRow(removeNum)
          {
              alert("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
              return false;
          }

        function removeRow(removeNum, CofirmMsg) {
            if (confirm(CofirmMsg)) {

                var row_index = jQuery('#rowId_' + removeNum).index();
                var BforeRmvTableRowCount = document.getElementById("TableaddedRows").rows.length;

                LocalStorageDelete(row_index, removeNum);

                jQuery('#rowId_' + removeNum).remove();
                RowIndex--;
                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();
                var TableRowCount = document.getElementById("TableaddedRows").rows.length;

                if (TableRowCount != 0) {
                    var idlast = $noC('#TableaddedRows tr:last').attr('id');
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


                    addMoreRows(this.form, true, false, 0);

                    //    document.getElementById("spanAddRow").style.opacity = "1";

                }

                //for focussing to next or previous accordingly
                // While delete, then focus to be moved to next row (If there is any row below of current row) 
                // While delete, then focus to be moved to previous row (If there is any row above of current row) 
                if (BforeRmvTableRowCount > 1) {

                    if ((BforeRmvTableRowCount - 1) == row_index) {
                        var table = document.getElementById("TableaddedRows");
                        var preRowId = table.rows[row_index - 1].id;
                        if (preRowId != "") {
                            var res = preRowId.split("_");
                            if (res[1] != "") {


                                document.getElementById("txtQuestions" + res[1]).focus();
                                $noCon("#txtQuestions" + res[1]).select();
                                ReNumberTable();

                            }
                        }
                    }
                    else {

                        var table = document.getElementById("TableaddedRows");
                        var NxtRowId = table.rows[row_index].id;
                        //          alert('NxtRowId ' + NxtRowId);
                        if (NxtRowId != "") {
                            var res = NxtRowId.split("_");
                            if (res[1] != "") {

                                document.getElementById("txtQuestions" + res[1]).focus();
                                $noCon("#txtQuestions" + res[1]).select();
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
        }

        function CheckaddMoreRowsIndividual(x, retBool) {
            //alert('check add more row');
            // for add image in each row
            //addMoreRows(this.form, retBool, false, 0);
            // return false;

            var check = document.getElementById("tdInx" + x).innerHTML;
            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (check == " ") {

                if (retBool == true) {

                    if (CheckAllRowFieldAndHighlight(x, false) == true) {
                        document.getElementById("tdInx" + x).innerHTML = x;
                        document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";

                        addMoreRows(this.form, retBool, false, 0);
                        document.getElementById('txtQuestions' + rowCount).focus();
                        return false;
                    }
                }
                else if (retBool == false) {
                    var row_index = jQuery('#rowId_' + x).index();
                    if (CheckAllRowField(x, row_index) == true) {
                        document.getElementById("tdInx" + x).innerHTML = x;
                        document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";

                        addMoreRows(this.form, retBool, false, 0);
                        document.getElementById('txtQuestions' + rowCount).focus();

                        return false;
                    }
                }
            }
            return false;
        }
        function removeRow(removeNum, CofirmMsg) {
            if (confirm(CofirmMsg)) {

                var row_index = jQuery('#rowId_' + removeNum).index();
                var BforeRmvTableRowCount = document.getElementById("TableaddedRows").rows.length;

                LocalStorageDelete(row_index, removeNum);

                jQuery('#rowId_' + removeNum).remove();
                RowIndex--;
                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();
                var TableRowCount = document.getElementById("TableaddedRows").rows.length;

                if (TableRowCount != 0) {
                    var idlast = $noC('#TableaddedRows tr:last').attr('id');
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


                    addMoreRows(this.form, true, false, 0);

                    //    document.getElementById("spanAddRow").style.opacity = "1";

                }


                //  LocalStorageDelete(row_index,removeNum);

                //     alert('BforeRmvTableRowCount ' + BforeRmvTableRowCount);
                //    alert('row_index ' + row_index);
                //for focussing to next or previous accordingly
                // While delete, then focus to be moved to next row (If there is any row below of current row) 
                // While delete, then focus to be moved to previous row (If there is any row above of current row) 
                if (BforeRmvTableRowCount > 1) {

                    if ((BforeRmvTableRowCount - 1) == row_index) {
                        var table = document.getElementById("TableaddedRows");
                        var preRowId = table.rows[row_index - 1].id;
                        if (preRowId != "") {
                            var res = preRowId.split("_");
                            if (res[1] != "") {


                                document.getElementById("txtQuestions" + res[1]).focus();
                                $noCon("#txtQuestions" + res[1]).select();
                                ReNumberTable();

                            }
                        }
                    }
                    else {

                        var table = document.getElementById("TableaddedRows");
                        var NxtRowId = table.rows[row_index].id;
                        //          alert('NxtRowId ' + NxtRowId);
                        if (NxtRowId != "") {
                            var res = NxtRowId.split("_");
                            if (res[1] != "") {

                                document.getElementById("txtQuestions" + res[1]).focus();
                                $noCon("#txtQuestions" + res[1]).select();
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
        }
        // checks every field in row
        function CheckAllRowFieldAndHighlight(x, blFromBlurValue) {
            ret = true;
            var Questions = document.getElementById("txtQuestions" + x).value;

            if (Questions == "") {

                document.getElementById("txtQuestions" + x).style.borderColor = "Red";
                document.getElementById("txtQuestions" + x).focus();
               // $noCon("#txtQuestions" + x).select();
                ret = false;

            }
            return ret;
        }
        function LocalStorageAdd(x) {
          //var cbxSts = document.getElementById("<%=cbxCommonSts.ClientID%>");
            //if (cbxSts.checked == false) {
                //localStorage.clear();
            //}

            var tbClientWtrBilling = localStorage.getItem("tbClientWtrBilling");//Retrieve the stored data

            tbClientWtrBilling = JSON.parse(tbClientWtrBilling); //Converts string to object

            if (tbClientWtrBilling == null) //If there is no data, initialize an empty array
                tbClientWtrBilling = [];
            var detailId = document.getElementById("tdDtlId" + x).innerHTML;
            //  var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
            var evt = document.getElementById("tdEvt" + x).innerHTML;



            if (evt == 'INS') {
                var $add = jQuery.noConflict();               
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    QUESTIONS: $add("#txtQuestions" + x).val(),
                    EVTACTION: "" + evt + "",
                    DTLID: "0"

                });
            }
            else if (evt == 'UPD') {
                var $add = jQuery.noConflict();              
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    QUESTIONS: $add("#txtQuestions" + x).val(),
                    EVTACTION: "" + evt + "",
                    DTLID: "" + detailId + ""
                    

                });
            }
            
            var Commonqustn = document.getElementById("<%=HiddenCommonQuestions.ClientID%>").value;
            tbClientWtrBilling.push(client);
            localStorage.setItem("tbClientWtrBilling", JSON.stringify(tbClientWtrBilling));

            $add("#cphMain_HiddenQuestions").val(JSON.stringify(tbClientWtrBilling));





            document.getElementById("tdSave" + x).innerHTML = "saved";
            //CheckaddMoreRowsIndividual(x, true);
            // alert('gj');  
            var h = document.getElementById("<%=HiddenQuestions.ClientID%>").value;
              return true;

          }
          function LocalStorageDelete(row_index, x) {

              var tbClientWtrBilling = localStorage.getItem("tbClientWtrBilling");//Retrieve the stored data

              tbClientWtrBilling = JSON.parse(tbClientWtrBilling); //Converts string to object
              if (tbClientWtrBilling == null) //If there is no data, initialize an empty array
                  tbClientWtrBilling = [];

            

              // Using splice() we can specify the index to begin removing items, and the number of items to remove.
              tbClientWtrBilling.splice(row_index, 1);
              localStorage.setItem("tbClientWtrBilling", JSON.stringify(tbClientWtrBilling));
              $noCon("#cphMain_HiddenQuestions").val(JSON.stringify(tbClientWtrBilling));
              //   alert("Client deleted.");

              //   var h = document.getElementById("<%=HiddenQuestions.ClientID%>").value;
              //   alert(h);

             // alert(tbClientWtrBilling);
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
                      IncrmntConfrmCounter();
              // alert('gj');

                  }

                  function LocalStorageEdit(x, row_index) {
                      //  alert('edit start x ' + x);
                      //  alert('edit start row_index ' + row_index);
                      var tbClientWtrBilling = localStorage.getItem("tbClientWtrBilling");//Retrieve the stored data

                      tbClientWtrBilling = JSON.parse(tbClientWtrBilling); //Converts string to object

                      if (tbClientWtrBilling == null) //If there is no data, initialize an empty array
                          tbClientWtrBilling = [];
                      var detailId = document.getElementById("tdDtlId" + x).innerHTML;
                      // var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
                      var evt = document.getElementById("tdEvt" + x).innerHTML;

                      // alert('edit pmode ' + PrdctMode);
                      //  alert('additional:' + additional)




                      if (evt == 'INS') {

                          var $E = jQuery.noConflict();
                         
                         
                          tbClientWtrBilling[row_index] = JSON.stringify({
                              ROWID: "" + x + "",
                              QUESTIONS: $E("#txtQuestions" + x).val(),       
                              EVTACTION: "" + evt + "",
                              DTLID: "0"

                          });//Alter the selected item on the table
                      }
                      else {

                          var $E = jQuery.noConflict();
                        
                          tbClientWtrBilling[row_index] = JSON.stringify({
                              ROWID: "" + x + "",
                              QUESTIONS: $E("#txtQuestions" + x).val(),                           
                              EVTACTION: "" + evt + "",
                              DTLID: "" + detailId + ""

                          });//Alter the selected item on the table

                      }


                      localStorage.setItem("tbClientWtrBilling", JSON.stringify(tbClientWtrBilling));
                      $E("#cphMain_HiddenQuestions").val(JSON.stringify(tbClientWtrBilling));

            return true;
        }
        
        function BlurValue(obj, x) {
            //alert(obj+x);

            RemoveTag('txtQuestions' + x);
            if (obj == 'txtQuestions') {

            }
            // document.getElementById('divBlink').style.visibility = "hidden";
            var row_index = jQuery('#rowId_' + x).index();

            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (SavedorNot == "saved") {
                document.getElementById(obj + x).style.borderColor = "";
                // Update to local storage
                LocalStorageEdit(x, row_index);
            }
            else {

                if (CheckAllRowFieldAndHighlight(x, true) == true) {


                    if (SavedorNot == " ") {

                        //  id tdSAVE is made'saved ' in localStorageAdd
                        //add to local storage
                        LocalStorageAdd(x);

                    }

                }
                else {
                    document.getElementById(obj + x).value = "";

                }



            }
        }

        function ReNumberTable() {

            var table = "";


            table = document.getElementById("TableaddedRows");

            for (var i = 0, row; row = table.rows[i]; i++) {
                var x = "";

                for (var j = 0, col; col = row.cells[j]; j++) {
                    if (j == 0) {
                        x = col.innerHTML;
                        if (x != "") {

                            var intRecount = parseInt(i) + 1;
                            //   alert('i :' + intcount);
                            document.getElementById("divSlNum" + x).innerHTML = intRecount
                            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
                            if (SavedorNot == "saved") {

                            }
                        }
                    }

                }
            }
        }

        function ValidateAndSave(mode) {
            ret = true;
           // document.getElementById('divMessageArea').style.display = "";
           // document.getElementById("<%=ddlDesg.ClientID%>").style.borderColor = "";

            var cbxSts1 = document.getElementById("<%=cbxCommonSts.ClientID%>");
            if (cbxSts1.checked == false && document.getElementById("<%=ddlDesg.ClientID%>").value == "--SELECT--") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                $noCon("div#divDesg input.ui-autocomplete-input").css("borderColor", "red");
                
                document.getElementById('cbxCommon').style.borderColor = "Red";
                document.getElementById("<%=ddlDesg.ClientID%>").focus();
                $("div#divCardNumber input.ui-autocomplete-input").select();
                 return false;
            }
            
            var table = "";

            var x = document.getElementById("TableaddedRows").rows.length;
            // alert(x);
            if (x < 1) {
                ErrMsg();
                //document.getElementById("txtAPTName" + 1).focus();
                ret = false;
            }
            table = document.getElementById("TableaddedRows");

            if (table.rows.length == 1) {
                for (var i = 0; i < table.rows.length; i++) {
                    if (i != table.rows.length) {
                        // FIX THIS
                        var row = table.rows[i];

                        var xLoop = (table.rows[i].cells[0].innerHTML);

                        if (CheckAllRowFieldAndHighlight(xLoop, 0) == false) {
                            ret = false;
                            break;
                        }


                    }
                }
            }
            else {
                for (var i = 0; i < table.rows.length; i++) {
                    if (i != table.rows.length - 1) {
                        // FIX THIS
                        var row = table.rows[i];

                        var xLoop = (table.rows[i].cells[0].innerHTML);

                        if (CheckAllRowFieldAndHighlight(xLoop, 0) == false) {
                            ret = false;
                            break;
                        }


                    }
                }
            }


            //var Lastrow = table.rows[table.rows.length];
            var xLast = (table.rows[table.rows.length - 1].cells[0].innerHTML);
           //  alert(xLast);
            //var CbValue = document.getElementById("cbDefault" + xLast).cheked;
        //    if(mode=='Save')
        //    {
        //    var Questions = document.getElementById("txtQuestions" + xLast).value;
        //    if (Questions == "") {
        //        document.getElementById("txtQuestions" + xLast).focus();
        //        ret = false;    
        //    }
        //}
    //else if (mode == 'Update')
    //{
    //    document.getElementById("txtQuestions" + xLast).focus();
    //}

    if (document.getElementById("<%=HiddenQuestions.ClientID%>").value == "") {
                  ErrMsg();              
                  ret = false;
              }
    //alert(ret);
              IntwCatName = document.getElementById("<%=ddlDesg.ClientID%>").value.trim();
    if (IntwCatName == "") {
        ErrMsg();
        document.getElementById("<%=ddlDesg.ClientID%>").focus();
                  document.getElementById("<%=ddlDesg.ClientID%>").style.borderColor = 'Red';
        ret = false; 
              }
              
              return ret;
          }
    </script>
    <script>
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
        function SuccessIns() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Exit interview questions inserted successfully.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Exit interview questions updated successfully.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function ErrMsg() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = " Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
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
            if (charCode == 91 || charCode == 93) {
                ret = false;
            }
            if (charCode == 123 || charCode == 125) {
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
        function ConfirmMessage() {
            if (document.getElementById("<%=HiddenFieldClose.ClientID%>").value == "close") {
                CloseWindow();
            }
            else {
                if (confirmbox > 0) {
                    if (confirm("Are you sure you want to leave this page?")) {
                        window.location.href = "hcm_Exit_Intrvw_Qstn_List.aspx";

                        return false;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    window.location.href = "hcm_Exit_Intrvw_Qstn_List.aspx";
                    return false;
                }
            }
        }
        function ConfirmClear() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to clear?")) {
                    window.location.href = "hcm_Exit_Intrvw_Qstn.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "hcm_Exit_Intrvw_Qstn.aspx";
                return false;
            }
        }
        function RemoveTag(obj) {
            //    IncrmntConfrmCounter();

            var txt = document.getElementById(obj).value.trim();
            var replaceText1 = txt.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(obj).value = replaceText2;

        }
        function ChangedllDesg()
        {
            if (document.getElementById("<%=ddlDesg.ClientID%>").value != "--SELECT--") {
                document.getElementById("<%=cbxCommonSts.ClientID%>").disabled = true;
            }
            else {
                document.getElementById("<%=cbxCommonSts.ClientID%>").disabled = false;
            }
        }
        function ChangecbxCommonSts() {
            
            $noDesg = jQuery.noConflict();
            var cbxSts = document.getElementById("<%=cbxCommonSts.ClientID%>");
      
            if (cbxSts.checked) {

                //  $noCon("divDesg input.ui-autocomplete-input").display = none;
                //  document.getElementById(".form1 ui-autocomplete-input").disabled = true;
                $("#divDesg input.ui-autocomplete-input").prop("disabled", true);
                $("#divDesg input.ui-autocomplete-input").css("borderColor", "");
                jQuery('#TableaddedRows tr').remove();

                Commonquestion();
            } else {

                $("#divDesg input.ui-autocomplete-input").prop("disabled", false);
                jQuery('#TableaddedRows tr').remove();
                InitializeValues();
                localStorage.clear();
                addMoreRows(this.form, true, false, 0);
                
                          }
        }
        function Commonquestion() {
            localStorage.clear();
            //var $noCon2 = jQuery.noConflict();
            var Commonqustn = document.getElementById("<%=HiddenCommonQuestions.ClientID%>").value;
            var cbxSts = document.getElementById("<%=cbxCommonSts.ClientID%>");
            InitializeValues();
            if (cbxSts.checked) {
                if (Commonqustn != "") {

                    var find2 = '\\"\\[';
                    var re2 = new RegExp(find2, 'g');
                    var res2 = Commonqustn.replace(re2, '\[');

                    var find3 = '\\]\\"';
                    var re3 = new RegExp(find3, 'g');
                    var res3 = res2.replace(re3, '\]');
                    //   alert('res3' + res3);
                    var json = $noCon.parseJSON(res3);
                    for (var key in json) {
                        if (json.hasOwnProperty(key)) {
                            if (json[key].DTL_ID != "") {

                                //  alert('json[key].AddDesc ' + json[key].AddDesc);
                                EditListRows(json[key].QUESTION, json[key].DTL_ID);


                            }

                        }

                    }
                    addMoreRows(this.form, true, false, 0);
                }
                else { addMoreRows(this.form, true, false, 0); }
            }
            else {

                
            }
        }
        //document.getElementById("<%=HiddenCommonQuestions.ClientID%>").value = "";
          
         </script>
</asp:Content>




    <asp:Content ID="Content3" ContentPlaceHolderID="cphMain" Runat="Server">
        <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenEdit" runat="server" />
    <asp:HiddenField ID="hiddenView" runat="server" />
    <asp:HiddenField ID="HiddenQuestions" runat="server" />
        <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
       <asp:HiddenField ID="hiddenIntwCatID" runat="server" />
     <asp:HiddenField ID="HiddenFieldClose" runat="server" />
        <asp:HiddenField ID="HiddenCommonQuestions" runat="server" />
   <asp:HiddenField ID="HiddenSubCount" runat="server" />
<asp:Label ID="lblIndex" runat="server" Text="Label" Style="display: none"></asp:Label>
    <div class="cont_rght" >


        <%--  --%>

          <div id="divMessageArea" style="display: none; margin:0px 0 13px;">
                 <img id="imgMessageArea" src="" >
                <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>
      

     
        <br />
        
        <div class="fillform" style="width: 100%;">
              <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position: fixed; right: 5%; top: 40%; height: 26.5px;">

          <%--   <a href="gen_ProductBrandList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;width: 80%;">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
         
               <div id="divCardNumber" style="width: 46%; margin-top: 2.2%;" class="eachform">
            <h2 style="margin-top: 0%; float: left; padding-right: 7%;">Designation</h2>
            <%--<asp:DropDownList ID="ddlCardNumber" class="form1" Style="width: 65.5%; float: left;" runat="server" onblur="return ChangeCardNumber();" onfocus="getPreviousDDLCardNumber_SelectedVal()" autofocus="autofocus" autocorrect="off" autocomplete="off"></asp:DropDownList>--%>
                   <div id="divDesg">
                    <asp:DropDownList ID="ddlDesg" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 13.3%; height: 30px" onkeydown="return DisableEnter(event)" onchange="IncrmntConfrmCounter();"  runat="server">
                </asp:DropDownList>
        </div></div>
               <div id="div1" style="width: 55%; margin-top: 0.2%;float: left;" class="eachform">
            <h2 style="margin-top: 0%; float: left; padding-right: 2%;">Common</h2>
                   <%--<asp:CheckBox Text="Active" runat="server" />--%>
                   <div id="cbxCommon" class="subform" style="width:215px;float: left;margin-left: 12.58%;">
                    <asp:CheckBox ID="cbxCommonSts" Text="" onchange="ChangecbxCommonSts();" onclick="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server" class="form2" />
                  
                  </div>

        </div>
            <div class="leads_form">
                <div id="divErrorNotification" style="visibility: hidden">
                    <asp:Label ID="lblErrorNotification" runat="server"></asp:Label>
                </div>
                <div id="divTables" style="width: 50%; margin: auto; padding-top: 0.6%;">
                   <h2 style="margin-top:1%;">Interview Questions</h2>
                    <table id="TableHeaderBilling" rules="all" style="width: 100%;">

                        <tr>
                            <td style="font-size: 14px; width: 7%; padding-left: 0.5%;">Sl#</td>
                            <td style="font-size: 14px; width: 72%; padding-left: 0.5%;">Questions</td>



                            <td id="spanAddRow" style="width: 11%;background: rgb(244, 246, 240) none repeat scroll 0% 0%;">
                                <%--  this not used  now if needed remove display none--%>
                                <img src="../../../Images/imgAddRows.png" style="cursor: pointer; width: 100%; height: 30px; display: none" onclick="CheckaddMoreRows();" />

                            </td>
                        </tr>
                    </table>
                    
                    <div style="width: 100%; min-height: 75px; overflow-y: auto;">
                        <table id="TableaddedRows" style="width: 100%;">
                        </table>

                        <%--<table id="TableFooterBilling" rules="all" style="width: 95.4%; border: 1px none; background-color: beige;">

                            <tr>
                                <td style="font-size: 18px; width: 85%; padding-right: 1.2%; text-align: right; color: black;">Total</td>

                                <td id="tdFooterTotalAmount" style="font-size: 14px; width: 15%; text-align: right; padding-right: 0.3%;"></td>



                            </tr>
                        </table>--%>


                    </div>
                  
                    <div id="divBlink" style="background-color: rgb(249, 246, 3); font-size: 10.5px; color: black; opacity: 0.6;"></div>

                </div>




            </div>


            


            <div class="eachform" style="margin-top: -1.5%;">

                <div class="subform" style="margin-left: 36.8%; width: 70%; margin-top: 2%;">


                    <asp:Button ID="btnSave" runat="server" class="save" Text="Save" OnClientClick="return ValidateAndSave('Save');" OnClick="btnSave_Click" />
                        <asp:Button ID="btnSaveClose" runat="server" class="save" Text="Save & Close" OnClientClick="return ValidateAndSave('Save');" OnClick="btnSave_Click" />
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClientClick="return ValidateAndSave('Update');" OnClick="btnUpdate_Click" />
                       <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClientClick="return ValidateAndSave('Update');" OnClick="btnUpdate_Click" />
      
                  





                    <%--<asp:Button ID="Button1" runat="server" class="save" Text="show" OnClientClick="return ShowHidden();" />--%>
                     <%--<asp:Button ID="btnList" runat="server" class="save" Text="List"   OnClientClick="return ConfirmMessage();" />--%>
                     <asp:Button ID="btnClear" runat="server" class="save" Text="Clear" OnClientClick="return ConfirmClear();" />
                       <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                    <%--<asp:Button ID="btnClose" runat="server" class="save" Text="Close" OnClientClick="return ConfirmMessage();" />--%>
                </div>

            </div>

             
        </div>
    </div>
</asp:Content>

