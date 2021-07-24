<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_Interview_Category.aspx.cs" Inherits="HCM_HCM_Master_gen_Interview_Category_gen_Interview_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
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
     <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
     <script>
         var confirmbox = 0;

         function IncrmntConfrmCounter() {
             confirmbox++;
         }

         var $noCon = jQuery.noConflict();
         $noCon(window).load(function () {

            

           
          
             document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";
             document.getElementById('divBlink').style.visibility = "hidden";

             // Run code
             //     alert('loaded statr');
        
             
            localStorage.clear();
            
            //document.getElementById("<%=hiddenEdit.ClientID%>").value = "";
             //document.getElementById("<%=hiddenView.ClientID%>").value = "";



            var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;
             var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;
            if (EditVal != "") {


                // alert('edit  ' + EditVal);

                // var find1 = '\\\\';
                //  var re1 = new RegExp(find1, 'g');
                //  var res1 = EditVal.replace(re1, '');

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
                        if (json[key].IntwCatId != "") {

                            //  alert('json[key].AddDesc ' + json[key].AddDesc);
                            EditListRows(json[key].IntwCatDtlName, json[key].DfltStatus, json[key].IntwCatDtlId);

                            //  alert(json[key].LdgrHeadId);
                            //  alert(json[key].Amount);
                        }
                    }
                }


            }

            else if (ViewVal != "") {



                document.getElementById("<%=txtIntwCategory.ClientID%>").disabled = true;
                $("div#divCardNumber input.ui-autocomplete-input").attr("disabled", "disabled");
                //   alert('View  ' + ViewVal);

                //    var find1 = '\\\\';
                //      var re1 = new RegExp(find1, 'g');
                //     var res1 = ViewVal.replace(re1, '');

                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = ViewVal.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');
                //alert(res3);
                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        if (json[key].IntwCatId != "") {

                            ViewListRows(json[key].IntwCatDtlName, json[key].DfltStatus, json[key].IntwCatDtlId);


                            //  alert(json[key].LdgrHeadId);
                            //  alert(json[key].Amount);
                        }
                    }
                }

            }
            else {

                //   var num = 0;
                //  var n = 0;
                // for floatting number adjustment from corp global
                
                //       var n = num.toFixed(FloatingValue);
                //  }
                // write  to Total Label
               

                //    document.getElementById('tdFooterTotalAmount').innerText = n;

            }
            //  alert('hi');
             if (ViewVal == "" ) {


                addMoreRows(this.form, false, false, 0);



                //  alert('hi');
                document.getElementById("<%=txtIntwCategory.ClientID%>").focus();
                
            }


            //    alert('loaded');

             document.getElementById("txtAPTName" + rowCount).style.borderColor = "";

         });

         //check by id
         function CheckDupIntwCatName() {
             ret = false;
            var strOrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
            var strCorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var strCatName = "";
            var strCatId = "";
            strCatName = document.getElementById("<%=txtIntwCategory.ClientID%>").value;
             strCatId = document.getElementById("<%=hiddenIntwCatID.ClientID%>").value;
            //string stores Receipt No(0), Employee id(1),ReceiptAmnt(2),VehicleId(3),UserId (4),OrgId(5),CorpId(6)
                $co = jQuery.noConflict();
                $co.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_Interview_Category.aspx/CheckDupIntwCatName",
                    data: '{strIntwCategoryId:"' + strCatId + '",strIntwCategoryName:"' + strCatName + '",strOrgId:"' + strOrgId + '",strCorpId:"' + strCorpId + '"}',
                   // CheckDupIntwCatName(string strIntwCategoryId, string strIntwCategoryName, string strOrgId, string strCorpId)
                    dataType: "json",
                    success: function (data) {

                        if (data.d == "0") {
                            //alert('valid');
                            ret = true;

                        }
                        else {
                            //alert('Duplicate');
                            ret = false;
                        }

                    },
                    error: function (response) {

                    }

                });
                return ret;



            }
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


          function addMoreRows(frm, boolFocus, boolAppendorNot, row_index) {
              // alert('addMoreRows');
              document.getElementById('divErrorNotification').style.visibility = "hidden";
              document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";
            rowCount++;
            RowIndex++;
           


            nMoney = 0;



            //    alert('ADD');
            //   alert(RowIndex.toString());
            document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


            var recRow = '<tr id="rowId_' + rowCount + '" >';
            recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
            recRow += '<td style="width: 5.7%;text-align: center;padding: 2px;padding-right: 5px;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


            recRow += ' <td id="tdAPTName' + rowCount + '"  style="width: 63%;padding: 4px;">';
            recRow += ' <input  id="txtAPTName' + rowCount + '"  class="BillngEntryField"  type="text"  onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtAPTName\',' + rowCount + ')"   maxlength=95 style="text-transform: uppercase;text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;margin-left: -0.5%;"/>';
            recRow += '   </td> ';


            recRow += ' <td style="width: 8%;padding: 4px;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 98%;"><input  id="cbDefault' + rowCount + '" style="margin-left: 29%;" class="BillngEntryField" type="checkbox" onchange="IncrmntConfrmCounter();" onblur="return BlurValue(\'cbDefault\',' + rowCount + ')" /></div></td>';

            recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);" title="ADD" style="  cursor: pointer;"></td>';
            recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this entry?\');"  title="DELETE"  style=" cursor: pointer;" ></td>';


            recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
            recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
            recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">INS</td>';
            recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;"></td>';
            // recRow += '<td id="tdSlNumbr' + rowCount + '" style="display: none;"></td>';


            recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
            recRow += '</tr>';



            jQuery('#TableaddedRows').append(recRow);

            //if (boolAppendorNot == false) {
            //    //to append
               
            //}
            //else {

            //    // to insert in perticular position
            //    var $NoAppnd = jQuery.noConflict();
            //    if (parseInt(row_index) != 0) {
            //        $NoAppnd('#TableaddedRows > tbody > tr').eq(parseInt(row_index) - 1).after(recRow);
            //    }
            //    else {

            //        var TableRowCount = document.getElementById("TableaddedRows").rows.length;

            //        if (parseInt(TableRowCount) != 0) {
            //            $NoAppnd('#TableaddedRows > tbody > tr').eq(parseInt(row_index)).before(recRow);
            //        }
            //        else {
            //            //if table row count is 0
            //            jQuery('#TableaddedRows').append(recRow);
            //        }
            //    }




            //}








           

          


            //   alert('add rows');


        }


          function EditListRows(IntwCatDtlName, DfltStatus, IntwCatDtlId) {


             
   

                if (IntwCatDtlName != "" && DfltStatus != "" && IntwCatDtlId != "") {

                rowCount++;
                RowIndex++;


              
              

                


                //      document.getElementById("spanAddRowTax").style.opacity = "0.3";



                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 5.7%;text-align: center;padding: 2px;padding-right: 5px;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


                recRow += ' <td id="tdAPTName' + rowCount + '"  style="width: 63%;padding: 4px;">';
                recRow += ' <input  id="txtAPTName' + rowCount + '"  class="BillngEntryField"  type="text" value="' + IntwCatDtlName + '"  onkeypress="return isTag(event)" onblur="return BlurValue(\'txtAPTName\',' + rowCount + ')"    maxlength=95 style="text-transform: uppercase;text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;margin-left: -0.5%;"/>';
                recRow += '   </td> ';

                if (DfltStatus == 0) {
                    recRow += ' <td style="width: 8%;padding: 4px;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 98%;"><input  id="cbDefault' + rowCount + '" style="margin-left: 29%;" class="BillngEntryField" type="checkbox"  onchange="IncrmntConfrmCounter();" onblur="return BlurValue(\'cbDefault\',' + rowCount + ')"  /></div></td>';
                }
                else {
                    recRow += ' <td style="width: 8%;padding: 4px;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 98%;"><input  id="cbDefault' + rowCount + '" checked="true" style="margin-left: 29%;"  class="BillngEntryField" type="checkbox" onchange="IncrmntConfrmCounter();"  onblur="return BlurValue(\'cbDefault\',' + rowCount + ')"   /></div></td>';
                }

                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png"  alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);" title="ADD" style="  cursor: pointer;"></td>';
                recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this entry?\');"  title="DELETE"  style=" cursor: pointer;" ></td>';


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
          function ViewListRows(IntwCatDtlName, DfltStatus, IntwCatDtlId) {


            //    alert('EditStockStatus' + EditStockStatus);// && EditHike != "" && EditAmount != "" && EditStockStatus != ""
              if (IntwCatDtlName != "" && DfltStatus != "" && IntwCatDtlId != "") {

                //  alert('in view');
                rowCount++;
                RowIndex++;




                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();



                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 5.7%;text-align: center;padding: 2px;padding-right: 5px;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


                recRow += ' <td id="tdAPTName' + rowCount + '"  style="width: 63%;padding: 4px;">';
                recRow += ' <input  id="txtAPTName' + rowCount + '" disabled class="BillngEntryField"  type="text" value="' + IntwCatDtlName + '"  onkeypress="return isTag(\'event\')"  maxlength=95 style="text-transform: uppercase;text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;margin-left: -0.5%;"/>';
                recRow += '   </td> ';

                if (DfltStatus == 0) {
                    recRow += ' <td style="width: 8%;padding: 4px;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 98%;"><input  id="cbDefault' + rowCount + '" disabled style="margin-left: 29%;" class="BillngEntryField" type="checkbox" /></div></td>';
                }
                else {
                    recRow += ' <td style="width: 8%;padding: 4px;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 98%;"><input  id="cbDefault' + rowCount + '" checked="true" disabled style="margin-left: 29%;" class="BillngEntryField" type="checkbox"  onchange="IncrmntConfrmCounter();"   /></div></td>';
                }
                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input disabled id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image"  class="BillngEntryField" src="../../../Images/Icons/addEntry.png"  alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);" title="ADD"  style="  cursor: pointer;"></td>';
                recRow += '<td style="width: 1.5%; padding-left: 1px;"><input disabled type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this entry?\');"  title="DELETE"  style=" cursor: pointer;" ></td>';


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


                                document.getElementById("txtAPTName" + res[1]).focus();
                                $noCon("#txtAPTName" + res[1]).select();
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

                                document.getElementById("txtAPTName" + res[1]).focus();
                                $noCon("#txtAPTName" + res[1]).select();
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
                          document.getElementById('txtAPTName' + rowCount).focus();
                          return false;
                      }
                      else {
                         
                          document.getElementById('txtAPTName' + rowCount).style.borderColor = "Red";
                          document.getElementById('txtAPTName' + rowCount).focus();

                      }
                  }
                  else if (retBool == false) {
                      var row_index = jQuery('#rowId_' + x).index();
                      if (CheckAllRowField(x, row_index) == true) {
                          document.getElementById("tdInx" + x).innerHTML = x;
                          document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";

                          addMoreRows(this.form, retBool, false, 0);
                          document.getElementById('txtAPTName' + rowCount).focus();

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


                                //document.getElementById("txtAPTName" + res[1]).focus();
                                $noCon("#txtAPTName" + res[1]).select();
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

                               // document.getElementById("txtAPTName" + res[1]).focus();
                                $noCon("#txtAPTName" + res[1]).select();
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
             
              var AptName = document.getElementById("txtAPTName" + x).value;
              document.getElementById("txtAPTName" + x).style.borderColor = "";
              if (AptName == "") {

                  //document.getElementById("txtAPTName" + x).style.borderColor = "Red";
                  //document.getElementById("txtAPTName" + x).focus();
                  //$noCon("#txtAPTName" + x).select();
                  return false;
              }
              else {

                  return true;
              }
          }
          function LocalStorageAdd(x) {
           
              var tbClientWtrBilling = localStorage.getItem("tbClientWtrBilling");//Retrieve the stored data

              tbClientWtrBilling = JSON.parse(tbClientWtrBilling); //Converts string to object

              if (tbClientWtrBilling == null) //If there is no data, initialize an empty array
                  tbClientWtrBilling = [];
              var detailId = document.getElementById("tdDtlId" + x).innerHTML;
              //  var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
              var evt = document.getElementById("tdEvt" + x).innerHTML;



              if (evt == 'INS') {
                  var $add = jQuery.noConflict();
                  var cbValue = 0;
                  if ($add("#cbDefault" + x).is(":checked")) {
                      // it is checked
                      cbValue = 1;
                  }
                  var client = JSON.stringify({
                      ROWID: "" + x + "",
                      APTNAME: $add("#txtAPTName" + x).val(),
                      DEFLTSTATUS: "" + cbValue + "",
                      EVTACTION: "" + evt + "",
                      DTLID: "0"

                  });
              }
              else if (evt == 'UPD') {
                  var $add = jQuery.noConflict();
                  var cbValue = 0;
                  if ($add("#cbDefault" + x).is(":checked")) {
                      // it is checked
                      cbValue = 1;
                  }
                  var client = JSON.stringify({
                      ROWID: "" + x + "",
                      APTNAME: $add("#txtAPTName" + x).val(),
                      DEFLTSTATUS: "" + cbValue + "",
                      EVTACTION: "" + evt + "",
                      DTLID: "" + detailId + ""


                  });
              }



             
              tbClientWtrBilling.push(client);
              localStorage.setItem("tbClientWtrBilling", JSON.stringify(tbClientWtrBilling));

              $add("#cphMain_HiddenField1").val(JSON.stringify(tbClientWtrBilling));


              


              document.getElementById("tdSave" + x).innerHTML = "saved";
              //CheckaddMoreRowsIndividual(x, true);
              // alert('gj');  
              var h = document.getElementById("<%=HiddenField1.ClientID%>").value;
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
              $noCon("#cphMain_HiddenField1").val(JSON.stringify(tbClientWtrBilling));
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
        var cbValue = 0;
        if ($E("#cbDefault" + x).is(":checked")) {
            // it is checked
            cbValue = 1;
        }
        tbClientWtrBilling[row_index] = JSON.stringify({
            ROWID: "" + x + "",
            APTNAME: $E("#txtAPTName" + x).val(),
            DEFLTSTATUS: "" + cbValue + "",
            EVTACTION: "" + evt + "",
            DTLID: "0"

        });//Alter the selected item on the table
    }
    else {

        var $E = jQuery.noConflict();
        var cbValue = 0;
        if ($E("#cbDefault" + x).is(":checked")) {
            // it is checked
            cbValue = 1;
        }
        tbClientWtrBilling[row_index] = JSON.stringify({
            ROWID: "" + x + "",
            APTNAME: $E("#txtAPTName" + x).val(),
            DEFLTSTATUS: "" + cbValue + "",
            EVTACTION: "" + evt + "",
            DTLID: "" + detailId + ""

        });//Alter the selected item on the table

    }





    localStorage.setItem("tbClientWtrBilling", JSON.stringify(tbClientWtrBilling));
    $E("#cphMain_HiddenField1").val(JSON.stringify(tbClientWtrBilling));


    




    //  alert("The data was edited.");
    //  operation = "A"; //Return to default value
    // var h = document.getElementById("<%=HiddenField1.ClientID%>").value;
    // alert(h);
    //CheckaddMoreRowsIndividual(x, true);
    //alert('cal stop');
    //  IncrmntConfrmCounter();
    // alert('gj');
    return true;
}
          function CompareAPTNames(x) {
              //alert('compare' + x);
              var tableNameCh = document.getElementById("TableaddedRows");

              //var table = document.getElementById('TableaddedRows');
              //alert(table.rows.length);
              // alert(table.rows.length);
              ChAptName = document.getElementById("txtAPTName" + x).value;
              ChAptName= ChAptName.toUpperCase();
              if (tableNameCh.rows.length >= 1) {
                  for (var i = 0; i < tableNameCh.rows.length; i++) {
                    
                          // FIX THIS
                          var row = tableNameCh.rows[i];

                          var xLoop = (tableNameCh.rows[i].cells[0].innerHTML);
                          if (xLoop != x) {
                              //if (CheckAllRowFieldAndHighlight(xLoop, 0) == false) {
                              //    ret = false;
                              //    break;
                              //}
                              var txtName= document.getElementById("txtAPTName" + xLoop).value;
                              txtName=  txtName.toUpperCase();
                           
                              if (txtName == ChAptName) {
                                  alert("Duplication not allowed in assessment name");
                                  document.getElementById("txtAPTName" + x).value = "";
                              }
                          }
                      
                  }
              }
          }
          function BlurValue(obj, x) {
            //  alert(obj+x);

              RemoveTag('txtAPTName' + x);
              if (obj == 'txtAPTName') {
                  document.getElementById("txtAPTName" + x).style.borderColor = "";
                  CompareAPTNames(x);
              }
             // document.getElementById('divBlink').style.visibility = "hidden";
              var row_index = jQuery('#rowId_' + x).index();

              var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
              if (SavedorNot == "saved") {

                          document.getElementById(obj + x).style.borderColor = "";
                         
                          LocalStorageEdit(x, row_index);
            }
            else {
                   
                    if (CheckAllRowFieldAndHighlight(x, true) == true) {
                        

                        //document.getElementById(obj + x).style.borderColor = "";
                        
                     

                       
                        if (SavedorNot == " ") {

                            //  id tdSAVE is made'saved ' in localStorageAdd
                            //add to local storage
                            LocalStorageAdd(x);

                        }

                    }
                    else {
                        //document.getElementById(obj + x).value = "";
                       

                    }


                 
            }
          }

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
         
          function ValidateAndSave(mode)
          {
              
              ret = true;
              
              document.getElementById("<%=txtIntwCategory.ClientID%>").style.borderColor = "";
              
              IntwCatName = document.getElementById("<%=txtIntwCategory.ClientID%>").value.trim();
              if (IntwCatName == "") {
                  ErrMsg();
                  document.getElementById("<%=txtIntwCategory.ClientID%>").focus();
                  document.getElementById("<%=txtIntwCategory.ClientID%>").style.borderColor = 'Red';
                  return false;
              }
              else {
                  if (CheckDupIntwCatName() != true) {
                      //msg dup
                      DuplicateInterviewCategory();
                      return false;
                  }
              }
              
              var table = "";

              var x = document.getElementById("TableaddedRows").rows.length;
             // alert(x);
              if (x <1) {
                  ErrMsg();
                  //document.getElementById("txtAPTName" + 1).focus();
                  ret = false;
              }
              table = document.getElementById("TableaddedRows");
              
              //var table = document.getElementById('TableaddedRows');
              //alert(table.rows.length);
             // alert(table.rows.length);
             
              if (table.rows.length == 1) {
                  for (var i = 0; i < table.rows.length; i++) {
                      if (i != table.rows.length) {
                          // FIX THIS
                          var row = table.rows[i];

                          var xLoop = (table.rows[i].cells[0].innerHTML);

                          if (CheckAllRowFieldAndHighlight(xLoop, 0) == false) {
                              document.getElementById("txtAPTName" + xLoop).style.borderColor = "Red";
                              return false;
                              break;
                          }


                      }
                  }
              }
              else {
                  for (var i = 0; i < table.rows.length; i++) {
                      if (i != table.rows.length-1) {
                          // FIX THIS
                          var row = table.rows[i];

                          var xLoop = (table.rows[i].cells[0].innerHTML);

                          if (CheckAllRowFieldAndHighlight(xLoop, 0) == false) {
                              document.getElementById("txtAPTName" + xLoop).style.borderColor = "Red";
                              return false;
                              break;
                          }


                      }
                  }
              }
                 
              
              //var Lastrow = table.rows[table.rows.length];
              var xLast = (table.rows[table.rows.length-1].cells[0].innerHTML);
              //var CbValue = document.getElementById("cbDefault" + xLast).cheked;
              var AptName = document.getElementById("txtAPTName" + xLast).value;
              if (document.getElementById("cbDefault" + xLast).checked == true && AptName == "") {
                  document.getElementById("txtAPTName" + xLast).style.borderColor = "Red";
                  document.getElementById("txtAPTName" + xLast).focus();
                  ret = false;

              }

              //for (var i = 1; i<x; i++) {
              //    {
                      
              //        //txtAPTName+i
              //        if (document.getElementById("txtAPTName" + i).value == "") {
              //            document.getElementById("txtAPTName" + i).focus();
              //            ret=false;
              //        }
              //    }
              //}
              if (document.getElementById("<%=HiddenField1.ClientID%>").value == "") {
                  ErrMsg();
                  //document.getElementById("txtAPTName" + 1).focus();
                  ret = false;
              }
              //alert(ret);
             
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
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Interview category details inserted successfully.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function DuplicateInterviewCategory() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Interview category name can’t be duplicated.";
            document.getElementById("<%=txtIntwCategory.ClientID%>").focus();
            document.getElementById("<%=txtIntwCategory.ClientID%>").style.borderColor = 'Red';
            //var $Mo = jQuery.noConflict();
            //$Mo(window).scrollTop(0);
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Interview category details updated successfully.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function ErrMsg() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
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
                        window.location.href = "gen_Interview_CategoryList.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    window.location.href = "gen_Interview_CategoryList.aspx";
                    return false;
                }
            }
        }
        function ConfirmClear() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to clear?")) {
                    window.location.href = "gen_Interview_Category.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_Interview_Category.aspx";
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
        <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenEdit" runat="server" />
    <asp:HiddenField ID="hiddenView" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
       <asp:HiddenField ID="hiddenIntwCatID" runat="server" />
     <asp:HiddenField ID="HiddenFieldClose" runat="server" />
   
<asp:Label ID="lblIndex" runat="server" Text="Label" Style="display: none"></asp:Label>
    <div class="cont_rght" >


        <%--  --%>

          <div id="divMessageArea" style="display: none; margin:0px 0 13px;">
                 <img id="imgMessageArea" src="" >
                <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>
      

     
        <br />
        
        <div class="fillform" style="width: 100%;">
              <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="height:26.5px;float:right;">

          <%--   <a href="gen_ProductBrandList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;width: 80%;">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
         
               <div id="divCardNumber" style="width: 46%; margin-top: 2.2%;" class="eachform">
            <h2 style="margin-top: 0%; float: left; padding-right: 7%;">Interview Category *</h2>
            <%--<asp:DropDownList ID="ddlCardNumber" class="form1" Style="width: 65.5%; float: left;" runat="server" onblur="return ChangeCardNumber();" onfocus="getPreviousDDLCardNumber_SelectedVal()" autofocus="autofocus" autocorrect="off" autocomplete="off"></asp:DropDownList>--%>
                   <asp:TextBox runat="server" ID="txtIntwCategory" MaxLength="95" onkeypress="return isTag(event);" style="text-transform: uppercase;" onblur="return RemoveTag('cphMain_txtIntwCategory');" class="form1" />

        </div>
               <div id="div1" style="width: 55%; margin-top: 0.2%;float: left;" class="eachform">
            <h2 style="margin-top: 0%; float: left; padding-right: 2%;">Status *</h2>
                   <%--<asp:CheckBox Text="Active" runat="server" />--%>
                   <div class="subform" style="width:215px;float: left;margin-left: 31.58%;">
                    <asp:CheckBox ID="cbxCnclStatus" Text="" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server" Checked="true" class="form2" />
                    <h3 style="margin-top:1%;">Active</h3>
                  </div>

        </div>
            <div class="leads_form">
                <div id="divErrorNotification" style="visibility: hidden">
                    <asp:Label ID="lblErrorNotification" runat="server"></asp:Label>
                </div>
                <div id="divTables" style="width: 50%; margin: auto; padding-top: 0.6%;">
                   <h2 style="margin-top:1%;"> Assessment Points</h2>
                    <table id="TableHeaderBilling" rules="all" style="width: 100%;">

                        <tr>
                            <td style="font-size: 14px; width: 7%; padding-left: 0.5%;">Sl#</td>
                            <td style="font-size: 14px; width: 72%; padding-left: 0.5%;">Name</td>
                            <td style="font-size: 14px; width: 9%; padding-left: 0.5%;">Default</td>



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

