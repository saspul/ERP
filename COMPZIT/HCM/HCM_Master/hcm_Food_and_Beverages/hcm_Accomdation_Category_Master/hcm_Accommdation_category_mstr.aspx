<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Accommdation_category_mstr.aspx.cs" Inherits="HCM_HCM_Master_hcm_Food_and_Beverages_hcm_Accomdation_Category_Master_hcm_Accommdation_category_mstr" %>

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
     <script src="/JavaScript/jquery-1.8.3.min.js"></script>
     <script>
         var confirmbox = 0;
 var rowCountLocalStore = 0;
         function IncrmntConfrmCounter() {
             confirmbox++;
         }

         var $noCon = jQuery.noConflict();
         $noCon(window).load(function () {

             document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";
             document.getElementById('divBlink').style.visibility = "hidden";
             //EVM-0027 09-02-2019
             var rowCount = 0;
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
                         if (json[key].AccmdtnId != "") {
                             //EVM-0027 09-02-2019
                             rowCount++;
                             //end
                             EditListRows(json[key].ACCMDTNSUB_NAME, json[key].DfltStatus, json[key].ACCMDTNSUB_ID);
                         }
                     }
                 }


             }

             else if (ViewVal != "")
             {
              


                 var rowCount = 0;
                 document.getElementById("<%=txtCatName.ClientID%>").disabled = true;
                     $("div#divCardNumber input.ui-autocomplete-input").attr("disabled", "disabled");
                     var find2 = '\\"\\[';
                     var re2 = new RegExp(find2, 'g');
                     var res2 = ViewVal.replace(re2, '\[');

                     var find3 = '\\]\\"';
                     var re3 = new RegExp(find3, 'g');
                     var res3 = res2.replace(re3, '\]');
                     var json = $noCon.parseJSON(res3);
                     for (var key in json) {
                         if (json.hasOwnProperty(key)) {
                             if (json[key].AccmdtnId != "")
                             {
                                
                                 ViewListRows(json[key].ACCMDTNSUB_NAME, json[key].DfltStatus, json[key].ACCMDTNSUB_ID);
                             }
                         }
                     }

                 }
                 else {

               
                 }
             
             //evm-0027
             if (ViewVal == "" && EditVal == "") {
                 addMoreRows(this.form, false, false, 0);
             }
                 //End
           else  if (ViewVal == "") {

                 // addMoreRows(this.form, false, false, 0);
                 document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "1";
                 document.getElementById("tdIndvlAddMoreRowPic" + rowCount).disabled = false;
                 document.getElementById("<%=txtCatName.ClientID%>").focus();

             }
           

             document.getElementById("txtAPTName" + rowCount).style.borderColor = "";

         });

         //check by id
         function CheckDupCertificateTemplate() {
             retCheck = false;
             var strOrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
            var strCorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
             var strCrtName = "";
             var strCatId = "";
             strCrtName = document.getElementById("<%=txtCatName.ClientID%>").value;
             strCatId = document.getElementById("<%=hiddenIntwCatID.ClientID%>").value;

             $co = jQuery.noConflict();
             $co.ajax({
                 type: "POST",
                 async: false,
                 contentType: "application/json; charset=utf-8",
                 url: "hcm_Accommdation_category_mstr.aspx/CheckDupCertificateTemplate",
                 data: '{strCertfctTempId:"' + strCatId + '",strCertName:"' + strCrtName + '",strOrgId:"' + strOrgId + '",strCorpId:"' + strCorpId + '"}',
                 // CheckDupCertificateTemplate(string strCertfctTempId, string strCertName, string strOrgId, string strCorpId)
                 dataType: "json",
                 success: function (data) {

                     if (data.d == "0") {
                         retCheck = true;

                     }
                     else {
                         retCheck = false;
                     }

                 },
                 error: function (response) {

                 }
                 
             });
          return retCheck;


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
          var RowIndex = 0;


          function addMoreRows(frm, boolFocus, boolAppendorNot, row_index) {
              document.getElementById('divErrorNotification').style.visibility = "hidden";
              document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";
              rowCount++;
              RowIndex++;

              nMoney = 0;

              document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


              var recRow = '<tr id="rowId_' + rowCount + '" >';
              recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
              recRow += '<td style="width: 5.7%;text-align: center;padding: 2px;padding-right: 5px;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';

              recRow += ' <td id="tdAPTName' + rowCount + '"  style="width: 63%;padding: 4px;">';
              <%--  EVM-0027 09-02-2019 autocomplete--%>
              recRow += ' <input  id="txtAPTName' + rowCount + '" autocomplete="off" class="BillngEntryField"  type="text"  onkeypress="return isTag(event)"     onblur="return BlurValue(\'txtAPTName\',' + rowCount + ')"   maxlength=95 style="text-align: left;text-tranform:uppercase; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;margin-left: -0.5%;"/>';
              recRow += '   </td> ';

              recRow += ' <td style="width: 8%;padding: 4px;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 98%;"><input checked="true"  id="cbDefault' + rowCount + '" style="margin-left: 32%;" class="BillngEntryField" type="checkbox" onchange="IncrmntConfrmCounter();" onblur="return BlurValue(\'cbDefault\',' + rowCount + ')" /></div></td>';

              recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="/Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);" title="ADD" style="  cursor: pointer;"></td>';
              recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onkeypress="return DisableEnter(event);" onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this entry?\');"  title="DELETE"  style=" cursor: pointer;" ></td>';

              recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
              recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
              recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">INS</td>';
              recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;"></td>';

              recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
              recRow += '</tr>';

              jQuery('#TableaddedRows').append(recRow);
        
          }


          function EditListRows(ACCMDTNSUB_NAME, DfltStatus, ACCMDTNSUB_ID)
          {

             
              if (ACCMDTNSUB_NAME != "" && DfltStatus != "" && ACCMDTNSUB_ID != "")
              {

                  rowCount++;
                  RowIndex++;


                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();

                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 5.7%;text-align: center;padding: 2px;padding-right: 5px;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


                recRow += ' <td id="tdAPTName' + rowCount + '"  style="width: 63%;padding: 4px;">';
                   <%--  EVM-0027 09-02-2019 autocomplete--%>
                recRow += ' <input  id="txtAPTName' + rowCount + '" autocomplete="off"  class="BillngEntryField"  type="text" value="' + ACCMDTNSUB_NAME + '"  onkeypress="return isTag(event)" onblur="return BlurValue(\'txtAPTName\',' + rowCount + ')"    maxlength=95 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;margin-left: -0.5%;"/>';
                recRow += '   </td> ';

                if (DfltStatus == 0)
                {
                    recRow += ' <td style="width: 8%;padding: 4px;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 98%;"><input  id="cbDefault' + rowCount + '" style="margin-left: 29%;" class="BillngEntryField" type="checkbox"  onchange="IncrmntConfrmCounter();" onblur="return BlurValue(\'cbDefault\',' + rowCount + ')"  /></div></td>';
                }
                else
                {
                    recRow += ' <td style="width: 8%;padding: 4px;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 98%;"><input  id="cbDefault' + rowCount + '" checked="true" style="margin-left: 29%;"  class="BillngEntryField" type="checkbox" onchange="IncrmntConfrmCounter();"  onblur="return BlurValue(\'cbDefault\',' + rowCount + ')"   /></div></td>';
                }

                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="/Images/Icons/addEntry.png"  alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);" title="ADD" style="  cursor: pointer;"></td>';
                recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this entry?\');"  title="DELETE"  style=" cursor: pointer;" ></td>';

                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + ACCMDTNSUB_ID + '</td>';

                recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                recRow += '</tr>';

                jQuery('#TableaddedRows').append(recRow);
                document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";
               // debugger;
            }
              else
              {

            }

        }
          function ViewListRows(ACCMDTNSUB_NAME, DfltStatus, ACCMDTNSUB_ID)
          {

           

              if (ACCMDTNSUB_NAME != "" && DfltStatus != "" && ACCMDTNSUB_ID != "") {

                rowCount++;
                RowIndex++;

                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();

                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 5.7%;text-align: center;padding: 2px;padding-right: 5px;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


                recRow += ' <td id="tdAPTName' + rowCount + '"  style="width: 63%;padding: 4px;">';
                recRow += ' <input  id="txtAPTName' + rowCount + '" disabled class="BillngEntryField"  type="text" value="' + ACCMDTNSUB_NAME + '"  onkeypress="return isTag(\'event\')"  maxlength=95 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;margin-left: -0.5%;"/>';
                recRow += '   </td> ';

                if (DfltStatus == 0) {
                    recRow += ' <td style="width: 8%;padding: 4px;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 98%;"><input  id="cbDefault' + rowCount + '" disabled style="margin-left: 29%;" class="BillngEntryField" type="checkbox" /></div></td>';
                }
                else {
                    recRow += ' <td style="width: 8%;padding: 4px;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 98%;"><input  id="cbDefault' + rowCount + '" checked="true" disabled style="margin-left: 29%;" class="BillngEntryField" type="checkbox"  onchange="IncrmntConfrmCounter();"   /></div></td>';
                }
                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input disabled id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image"  class="BillngEntryField" src="/Images/Icons/addEntry.png"  alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);" title="ADD"  style="  cursor: pointer;"></td>';
                recRow += '<td style="width: 1.5%; padding-left: 1px;"><input disabled type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this entry?\');"  title="DELETE"  style=" cursor: pointer;" ></td>';


                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + ACCMDTNSUB_ID + '</td>';

                recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                recRow += '</tr>';

                jQuery('#TableaddedRows').append(recRow);
                document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";
            }
            else {

            }

        }

          function CheckaddMoreRowsIndividual(x, retBool) {
              //alert("");

              var check = document.getElementById("tdInx" + x).innerHTML;
             

              //for checking if to save  or elese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
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
                  //EVM-0027 09-02-2019
              else {
                    
                  var row_index = jQuery('#rowId_' + x).index();
                  //alert(row_index);
             
                      document.getElementById("tdInx" + x).innerHTML = x;
                      document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";

                      addMoreRows(this.form, retBool, false, 0);
                      document.getElementById('txtAPTName' + rowCount).focus();

                      return false
                
                  //END


              }
                  return false;
             
          }
        function removeRow(removeNum, CofirmMsg)
        {
            
                var $NonCon = jQuery.noConflict();
                row_index = removeNum;
                //tdEvt
                if (document.getElementById("tdEvt" + row_index).innerHTML == "UPD") {
                    //alert(removeNum);
                    dtlID = document.getElementById("tdDtlId" + row_index).innerHTML;
                    //ajax
                    $NonCon.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "hcm_Accommdation_category_mstr.aspx/checkSubCat",
                        data: '{intDetailID:"' + dtlID + '"}',
                        dataType: "json",
                        success: function (data) {
                            if (data.d == "true")
                            {
                                if (confirm(CofirmMsg))
                                {
                                    var BforeRmvTableRowCount = document.getElementById("TableaddedRows").rows.length;

                                    LocalStorageDelete(row_index, removeNum);

                                    jQuery('#rowId_' + removeNum).remove();
                                    RowIndex--;
                                    document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();
                                    var TableRowCount = document.getElementById("TableaddedRows").rows.length;

                                    if (TableRowCount != 0) {
                                        var idlast = $noC('#TableaddedRows tr:last').attr('id');
                                        if (idlast != "")
                                        {
                                            var res = idlast.split("_");
                                            document.getElementById("tdInx" + res[1]).innerHTML = " ";
                                            document.getElementById("tdIndvlAddMoreRow" + res[1]).style.opacity = "1";
                                        }
                                    }
                                    else
                                    {

                                        addMoreRows(this.form, true, false, 0);
                                    }

                                    if (BforeRmvTableRowCount > 1)
                                    {

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
                                        else
                                        {

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
                            else {
                                alert("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
                                return false;
                            }

                        }
                    });
                    return false;
                }
                    //EVM-0027 09-02-2019
                else
                {
                    var BforeRmvTableRowCount = document.getElementById("TableaddedRows").rows.length;
                    //debugger;
                    //alert(BforeRmvTableRowCount);
                    jQuery('#rowId_' + removeNum).remove();
                    var TableRowCount = document.getElementById("TableaddedRows").rows.length;

                    if (TableRowCount != 0)
                    {
                        var idlast = $noC('#TableaddedRows tr:last').attr('id');
                        if (idlast != "") {
                            var res = idlast.split("_");
                            document.getElementById("tdInx" + res[1]).innerHTML = " ";
                            document.getElementById("tdIndvlAddMoreRow" + res[1]).style.opacity = "1";
                            ReNumberTable();
                        }
                    }
                    else
                    {

                        addMoreRows(this.form, true, false, 0);
                    }
                    LocalStorageDelete(row_index, removeNum);

                }
            //END
        }
        // checks every field in row
        function CheckAllRowFieldAndHighlight(x, blFromBlurValue) {
            document.getElementById("txtAPTName" + x).style.borderColor = "";
            var AptName = document.getElementById("txtAPTName" + x).value;

            if (AptName == "") {
                return false;
            }

            return true;
        }
        function LocalStorageAdd(x) {

            var tbClientWtrBilling = localStorage.getItem("tbClientWtrBilling");//Retrieve the stored data
            tbClientWtrBilling = JSON.parse(tbClientWtrBilling); //Converts string to object

            if (tbClientWtrBilling == null) //If there is no data, initialize an empty array
                tbClientWtrBilling = [];
            var detailId = document.getElementById("tdDtlId" + x).innerHTML;
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

                 var h = document.getElementById("<%=HiddenField1.ClientID%>").value;

              var evt = document.getElementById("tdEvt" + x).innerHTML;
              if (evt == 'UPD') {
                  var detailId = document.getElementById("tdDtlId" + x).innerHTML;
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
                      var tbClientWtrBilling = localStorage.getItem("tbClientWtrBilling");//Retrieve the stored data

                      tbClientWtrBilling = JSON.parse(tbClientWtrBilling); //Converts string to object

                      if (tbClientWtrBilling == null) //If there is no data, initialize an empty array
                          tbClientWtrBilling = [];
                      var detailId = document.getElementById("tdDtlId" + x).innerHTML;
                      var evt = document.getElementById("tdEvt" + x).innerHTML;

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

            return true;
        }
        function CompareAPTNames(x) {

            var tableNameCh = document.getElementById("TableaddedRows");
            ChAptName = document.getElementById("txtAPTName" + x).value;
            ChAptName = ChAptName.toUpperCase();
            if (tableNameCh.rows.length >= 1) {
                for (var i = 0; i < tableNameCh.rows.length; i++) {

                    // FIX THIS
                    var row = tableNameCh.rows[i];

                    var xLoop = (tableNameCh.rows[i].cells[0].innerHTML);
                    if (xLoop != x) {
                        var txtCatName = document.getElementById("txtAPTName" + xLoop).value;
                        txtCatName = txtCatName.toUpperCase();

                        if (txtCatName == ChAptName) {
                            if (txtCatName !="" && ChAptName !="") {
                                alert("Duplication not allowed in Category Name");
                                document.getElementById("txtAPTName" + x).value = "";
                            }
                        }
                    }

                }
            }
        }
        function BlurValue(obj, x) {

            //for replacing ',",\,<,>
            // replacing < and > tags and backslash and single and double quotes
            var txtAPTNameWithoutReplace = document.getElementById("txtAPTName" + x).value;

            var replaceText1 = txtAPTNameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/'/g, "");
            var replaceText4 = replaceText3.replace(/"/g, "");
            var replaceText5 = replaceText4.replace(/\\/g, "");
            var replaceText6 = replaceText5.replace(/{/g, "");
            var replaceText7 = replaceText6.replace(/}/g, "");
            document.getElementById("txtAPTName" + x).value = replaceText7.trim();

            if (obj == 'txtAPTName') {

                CompareAPTNames(x);
            }
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
            document.getElementById('divMessageArea').style.display = "none";
            document.getElementById("<%=txtCatName.ClientID%>").style.borderColor = "";

            IntwCatName = document.getElementById("<%=txtCatName.ClientID%>").value.trim();
            document.getElementById("<%=txtCatName.ClientID%>").value = IntwCatName;
            if (IntwCatName == "") {
                ErrMsg();
                document.getElementById("<%=txtCatName.ClientID%>").focus();
        document.getElementById("<%=txtCatName.ClientID%>").style.borderColor = 'Red';
        return false;
    }
            else {
                if (CheckDupCertificateTemplate() != true) {
                    //msg dup
                    DuplicateInterviewCategory();
                    return false;
        }
    }

    var table = "";

    var x = document.getElementById("TableaddedRows").rows.length;
    
    if (x < 1) {
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
                    document.getElementById("txtAPTName" + xLoop).style.borderColor = "Red";
                    document.getElementById("txtAPTName" + xLoop).focus();
                    return false;
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
                    document.getElementById("txtAPTName" + xLoop).style.borderColor = "Red";
                    document.getElementById("txtAPTName" + xLoop).focus();
                    return false;
                    break;
                }


            }
        }
    }

    var xLast = (table.rows[table.rows.length - 1].cells[0].innerHTML);
    var AptName = document.getElementById("txtAPTName" + xLast).value;
    if (document.getElementById("cbDefault" + xLast).checked == true && AptName == "") {
        document.getElementById("txtAPTName" + xLast).style.borderColor = "Red";
        document.getElementById("txtAPTName" + xLast).focus();
        ret = false;

    }

   
        
            if (ret == true) {
                localStorage.clear();
                tbClientTotalValues = '';
                tbClientTotalValues = [];

                for (var i = 0; i < table.rows.length; i++) {
                    // var row = table.rows[i];

                    var validRowID = (table.rows[i].cells[0].innerHTML);

                    var GatePass = document.getElementById("txtAPTName" + validRowID).value.trim();
                    var cbGatePassStatus = document.getElementById("cbDefault" + validRowID).checked;
                    var tbDetailID = document.getElementById("tdDtlId" + validRowID).innerHTML;
                    var EvtAction = document.getElementById("tdEvt" + validRowID).innerHTML;
                    var DetailID = "";
                    if (tbDetailID == "") {
                        DetailID = 0;
                    }
                    else {
                        DetailID = tbDetailID;
                    }
                    var cbStatus = "";
                    if (cbGatePassStatus == true) {
                        cbStatus = "1";
                    }
                    else {
                        cbStatus = "0";
                    }
                 
                    if (GatePass != "") {
                        addToLocalStorage(GatePass, cbStatus,  DetailID,  EvtAction);
                    }

                }
            }
            // return ret;
            return ret;
        }


          function addToLocalStorage(GatePass, cbStatus, DetailID, EvtAction) {

              var $add = jQuery.noConflict();

              var client = JSON.stringify({
                  ROWID: "" + rowCountLocalStore + "",
                  APTNAME: "" + GatePass + "",
                  DEFLTSTATUS: "" + cbStatus + "",
                 
                  EVTACTION: "" + EvtAction + "",
              
                  DTLID: "" + DetailID + ""

              });
              tbClientTotalValues.push(client);
              document.getElementById("<%=HiddenField1.ClientID%>").value = JSON.stringify(tbClientTotalValues);

            rowCountLocalStore++;
              var h = document.getElementById("<%=HiddenField1.ClientID%>").value;
         
            return true;
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
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Accommodation Category inserted successfully.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function DuplicateInterviewCategory() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Accommodation Category can’t be duplicated.";
            document.getElementById("<%=txtCatName.ClientID%>").focus();
            document.getElementById("<%=txtCatName.ClientID%>").style.borderColor = 'Red';
            //var $Mo = jQuery.noConflict();
            //$Mo(window).scrollTop(0);
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Accommodation Category  updated successfully.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function ErrMsg() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = " Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
        }

        function isTag(event) {
            //for item name and unit name
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            //alert(keyCode);
            if (keyCode == 13) {
                return false;
            }
            else if (keyCode == 39) {
                //single quote also right arrow when key press
                return false;
            }
            else if (keyCode == 34) {//double quotes
                return false;
            }
            else if (keyCode == 92) {
                // \ back slash
                return false;
            }
            else if (keyCode == 60 || keyCode == 62) {
                //< and >
                return false;
            }
            else if (keyCode == 123 || keyCode == 125) {
                //219 221 {}
                return false;
            }
                //evm-0023 start
            else if (keyCode == 91 || keyCode == 93) {
                return false;
            }
            //evm-0023 end
        }

        // for not allowing <> tags
        function isTagForName(evt) {
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
           
            if (charCode == 60 || charCode == 62) {
                return false;

            }
            return true;
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
                        window.location.href = "hcm_accommodation_Category_list.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    window.location.href = "hcm_accommodation_Category_list.aspx";
                    return false;
                }
            }
        }
        function ConfirmClear() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to clear?")) {
                    window.location.href = "hcm_Accommdation_category_mstr.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "hcm_Accommdation_category_mstr.aspx";
                return false;
            }
        }
        function RemoveTag(obj) {
            //    IncrmntConfrmCounter();

            var txt = document.getElementById(obj).value.trim();
            var replaceText1 = txt.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
          
            var replaceText3 = replaceText2.replace(/'/g, "");
            var replaceText4 = replaceText3.replace(/"/g, "");
            var replaceText5 = replaceText4.replace(/\\/g, "");
            var replaceText6 = replaceText5.replace(/{/g, "");
            var replaceText7 = replaceText6.replace(/}/g, "");
            document.getElementById(obj).value = replaceText2;

        }
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenEdit" runat="server" />
    <asp:HiddenField ID="hiddenView" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
       <asp:HiddenField ID="hiddenIntwCatID" runat="server" />
     <asp:HiddenField ID="HiddenFieldClose" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
<asp:Label ID="lblIndex" runat="server" Text="Label" Style="display: none"></asp:Label>
    <div class="cont_rght" >

          <div id="divMessageArea" style="display: none; margin:0px 0 13px;">
                 <img id="imgMessageArea" src="" >
                <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>
         
        <br />
        
        <div class="fillform" style="width: 100%;">
              <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="height:26.5px;float:right;">

        </div>
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;width: 80%;">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
         
               <div id="divCardNumber" style="width: 46%; margin-top: 2.2%;" class="eachform">
            <h2 style="margin-bottom:-3%; float: left; padding-right: 7%;">Category Name *</h2>
                    <%--  EVM-0027 09-02-2019 autocomplete--%>
                   <asp:TextBox runat="server" ID="txtCatName" MaxLength="95" autocomplete="off" onkeypress="return isTagForName(event);" onblur="return RemoveTag('cphMain_txtCatName');" class="form1" style="text-transform:uppercase;margin-right:23%;" />

        </div>
               <div id="div1" style="width: 55%; margin-top: 0.2%;float: left;" class="eachform">
            <h2 style="margin-top: 0%; float: left; padding-right: 2%;">Status *</h2>
                   <div class="subform" style="width:215px;float: left;margin-left: 12.58%;">
                    <asp:CheckBox ID="cbxCnclStatus" Text="" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server" Checked="true" class="form2" />
                    <h3 style="margin-top:1%;">Active</h3>
                  </div>

        </div>
            <div class="leads_form">
                <div id="divErrorNotification" style="visibility: hidden">
                    <asp:Label ID="lblErrorNotification" runat="server"></asp:Label>
                </div>
                <div id="divTables" style="width: 50%; margin: auto; padding-top: 0.6%;">
                   <h2 style="margin-top:1%;">Accommodation Premises</h2>
                    <table id="TableHeaderBilling" rules="all" style="width: 100%;">

                        <tr>
                            <td style="font-size: 14px; width: 7%; padding-left: 0.5%;">Sl#</td>
                            <td style="font-size: 14px; width: 72%; padding-left: 0.5%;">Room Name</td>
                            <td style="font-size: 14px; width: 9%; padding-left: 0.5%;">Active</td>

                            <td id="spanAddRow" style="width: 11%;background: rgb(244, 246, 240) none repeat scroll 0% 0%;">
                                <%--  this not used  now if needed remove display none--%>
                                <img src="../../../Images/imgAddRows.png" style="cursor: pointer; width: 100%; height: 30px; display: none" onclick="CheckaddMoreRows();" />

                            </td>
                        </tr>
                    </table>
                    
                    <div style="width: 100%; min-height: 75px; overflow-y: auto;">
                        <table id="TableaddedRows" style="width: 100%;">
                        </table>
                    </div>
                  
                    <div id="divBlink" style="background-color: rgb(249, 246, 3); font-size: 10.5px; color: black; opacity: 0.6;"></div>

                </div>
            </div>

            <div class="eachform" style="margin-top: -1.5%;">

                <div class="subform" style="margin-left: 36.8%; width: 70%; margin-top: 2%;">


                    <asp:Button ID="btnSave" runat="server" class="save" Text="Save" OnClientClick="return ValidateAndSave('Save');" OnClick="btnSave_Click" OnBlur="isTag(event)" />
                        <asp:Button ID="btnSaveClose" runat="server" class="save" Text="Save & Close" OnClientClick="return ValidateAndSave('Save');" OnClick="btnSave_Click" />
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClientClick="return ValidateAndSave('Update');" OnClick="btnUpdate_Click" />
                       <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClientClick="return ValidateAndSave('Update');" OnClick="btnUpdate_Click"  />
                      
                     <asp:Button ID="btnClear" runat="server" class="save" Text="Clear" OnClientClick="return ConfirmClear();" />
                      <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" OnClientClick="return ConfirmMessage();" />

                </div>

            </div>

             
        </div>
    </div>
</asp:Content>

