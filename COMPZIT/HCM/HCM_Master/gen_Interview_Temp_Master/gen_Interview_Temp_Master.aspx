<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_Interview_Temp_Master.aspx.cs" Inherits="HCM_HCM_Master_gen_Interview_Temp_Master_gen_Interview_Temp_Master" %>

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

        .eachform h2 {
            margin: 8px 0 6px;
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
                .error {
               padding-top: 7%;
               padding-left: 35%;
               color: red;
               font-size: small;
                margin-left: 8%;
           }
    </style>
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
           #divErrorNotification {
            border-radius: 8px;
            background: #fff;
            padding: 5px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: -1.5%;
            font-family: Calibri;
            border: 2px solid #53844E;
            width: 94%;
        }
    </style>
      <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            //  addMoreRowsss();
            localStorage.clear();
            // addMoreRows();
            document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";
            document.getElementById("<%=HiddenIntervw_Tem.ClientID%>").value = "";
            
            var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;

            var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;
          
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
                        if (json[key].TempDetlId != "") {

                            //  alert('json[key].AddDesc ' + json[key].AddDesc);
                            EditListRows(json[key].SheduleName, json[key].CatgoryId, json[key].TempTypId, json[key].ScoreSts, json[key].TempDetlId, json[key].CatgryName, json[key].Catgrysts);
                          //  Selectddl( json[key].CatgoryId);

                            //  alert(json[key].LdgrHeadId);
                            //  alert(json[key].Amount);
                        }
                    }
                }
                addMoreRows();

            }
            else if (ViewVal != "")
            {
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
                        if (json[key].TempDetlId != "") {

                            //  alert('json[key].AddDesc ' + json[key].AddDesc);
                            ViewListRows(json[key].SheduleName, json[key].CatgoryId, json[key].TempTypId, json[key].ScoreSts, json[key].TempDetlId,json[key].CatgryName);

                            //  alert(json[key].LdgrHeadId);
                            //  alert(json[key].Amount);
                        }
                    }
                }

            }
            else {
                
               // if(document.getElementById("<%=HiddenFieldDuplcnChk.ClientID%>").value!="1")
                addMoreRows();
            }

            document.getElementById("<%=txtTemplateName.ClientID%>").focus();
        });
    </script>
    <script src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="../../../css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>




        //var $au = jQuery.noConflict();

        //(function ($au) {
        //    $au(function () {
        //        $au('#cphMain_ddlExistingCntrctr').selectToAutocomplete1Letter();
        //        $au('#cphMain_ddlProject').selectToAutocomplete1Letter();
        //        $au('#cphMain_ddlContractType').selectToAutocomplete1Letter();
        //        $au('#cphMain_ddlJobCtgry').selectToAutocomplete1Letter();
        //        $au('#cphMain_ddlParentCntrct').selectToAutocomplete1Letter();
        //        $au('form').submit(function () {

        //            //   alert($au(this).serialize());


        //            //   return false;
        //        });
        //    });
        //})(jQuery);





    </script>
      <script language="javascript" type="text/javascript">
      var $noC = jQuery.noConflict();
        var rowCount = 0;
        //rowCount for uniquness
        //row index add(+) and (-)delete count based on action
        var RowIndex = 0;
        //function addMoreRowsss() {

        //    var recRow = '<tr id="rowId_' + rowCount + '" >';
           
        //    recRow += ' <td id="tdShduleTyp' + rowCount + '" style="width: 27%;">';
        //    recRow += ' <select style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 96%;margin-left: -0.9%;" id="txtSheduleTypName" class="form1"/> ';
        //    recRow += '</td> ';
        //    recRow += '</tr>';
           
        //    jQuery('#TableaddedRows').append(recRow);
        //    LoadSheduleTypddl(rowCount);
        //}

        function addMoreRows() {
            // alert('addMoreRows');
          
            rowCount++;
            RowIndex++;
            var num = 0;
            var nMoney = 0;
            
            var AmntMaxLen = 12;
            var CatgryName="";
            // for floatting number adjustment from corp global
          
            //floating value show the lenght of floating decimal 
            //added one for fullstop

            // }
            var boolAppendorNot = false;

            var TempTypId = 0;
            var CatgoryId = 0;



          


            var recRow = '<tr id="rowId_' + rowCount + '" >';
            recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
            recRow += '<td style="width: 3%;text-align: center;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


            recRow += ' <td id="tdSheduleName' + rowCount + '"  style="width: 36.3%;">';
            recRow += ' <input  id="txtSheduleName' + rowCount + '"   type="text"  onkeypress="return isTag(event);" onkeydown="return DisableEnter(event);" onfocus="prevValueChk(\'' + rowCount + '\');" onblur="LinkChangeFile(\'' + rowCount + '\',event);"    maxlength=85 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 99%;margin-left: -0.5%;text-transform:uppercase;"/>';
            recRow += '   </td> ';


            recRow += ' <td id="tdCatagory' + rowCount + '" style="width: 24.3%;"><div class="Cls' + rowCount + '">';
            recRow += ' <select  onchange=\"Changeddl(\'' + rowCount + '\',event);\" style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 99%;margin-left: 0.1%;" id="txtCatagryddl' + rowCount + '" class="form1" /> ';
            recRow += ' </div> </td> ';
            //  recRow += ' <td  style="display: none;"><input id="txtselectorVhclId' + rowCount + '"  value="--Select Vehicle--" type="text"   /></td>';
            //  recRow += ' <td  style="display: none;"><input id="txtselectorVhclName' + rowCount + '"  value="--Select Vehicle--" type="text" maxlength=100  /></td>';


            recRow += ' <td id="tdShduleTyp' + rowCount + '" style="width: 24.3%;"><div class="Cls' + rowCount + '">';
            recRow += ' <select  onchange=\"Changeddl(\'' + rowCount + '\',event);\" style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 99%;margin-left: 0.1%;float: left;" id="txtSheduleTyp' + rowCount + '" class="form1" /> ';
            recRow += ' </div> </td> ';
            // recRow += ' <td  style="display: none;"><input id="txtSheduleTypId' + rowCount + '"  value="--Select Vehicle--" type="text"   /></td>';
            //recRow += ' <td  style="display: block;"><select id="txtSheduleTypName' + rowCount + '"  value="--Select Vehicle--"  maxlength=100  /></td>';


            recRow += ' <td style="width: 9.3%;border: 1px solid rgb(207, 204, 204);background-color:white;"><div style=><input  id="txtChekbox' + rowCount + '" class="form1" onchange=\"UpdateCbxScore(\'' + rowCount + '\',event);\"  type="checkbox"  onkeypress="return isTag(event);"  style="text-align: right; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 89%;margin-left: -11.1%;"/></td>';

            recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ');" title="ADD" style="  cursor: pointer;"></td>';
            recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to Delete this Entry?\');" title="DELETE"   style=" cursor: pointer;" ></td>';


            recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
            recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
            recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">INS</td>';
            recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;"></td>';
            // recRow += '<td id="tdSlNumbr' + rowCount + '" style="display: none;"></td>';


            recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
            recRow += '</tr>';
            cbxchk = 0;
            // to append
            jQuery('#TableaddedRows').append(recRow);
            LoadSheduleTypddl(rowCount, TempTypId);
            var Catsts = 2;
            LoadCatgryddl(rowCount, CatgoryId, CatgryName, Catsts);
       

            //if (boolAppendorNot == false) {
            //    //to append
            //    jQuery('#TableaddedRows').append(recRow);
            //    LoadSheduleTypddl(rowCount);
            //    LoadCatgryddl(rowCount);
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

          
          
        
            document.getElementById("txtSheduleName" + rowCount).focus();
            $noCon("#txtSheduleName" + rowCount).select();
           

          
            //var $au = jQuery.noConflict();

            //(function ($au) {
            //    $au(function () {
            //        selectorToAutocompleteTextBox('txtselectorVhcl' + rowCount, rowCount);
                  

            //        $au('form').submit(function () {

                  


            //        });
            //    });
            //})(jQuery);

            //have to look into it
       
            //-------------------------------------------------------------
            //if (boolFocus == true) {
             
            //    document.getElementById("txtRcptNumber" + rowCount).focus();
              
            //    $noC("#txtRcptNumber" + rowCount).select();
            //}

        }


       
        // checks every field in row
        function CheckAllRowFieldAndHighlight(x) {
           
            ret = true;
            var SheduleName = document.getElementById("txtSheduleName" + x).value.trim();
            if (SheduleName == "") {
                document.getElementById("txtSheduleName" + x).style.borderColor = "Red";
               // document.getElementById("txtSheduleName" + x).focus();
              
                if (document.getElementById("<%=hiddenEdit.ClientID%>").value != "1") {
                    $noCon("#txtSheduleName" + x).select();
                   // alert(x+"nme");
                    $noCon("#txtSheduleName" + x).focus();
                    document.getElementById("<%=hiddenEdit.ClientID%>").value = "1";
                }
                ret= false;
            }
            else {
                document.getElementById("txtSheduleName" + x).style.borderColor = "";
            }
           
            var Catagoryddl = document.getElementById("txtCatagryddl" + x).value;
          
            if (Catagoryddl == "--SELECT CATEGORY--" || Catagoryddl == "" || Catagoryddl == 0) {
                document.getElementById("txtCatagryddl" + x).style.borderColor = "Red";
                // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
               // document.getElementById("txtCatagryddl" + x).focus();
              
                if (document.getElementById("<%=hiddenEdit.ClientID%>").value != "1") {
                    $noCon("#txtCatagryddl" + x).select();
                   // alert(x + "cat");
                    $noCon("#txtCatagryddl" + x).focus();
                    document.getElementById("<%=hiddenEdit.ClientID%>").value = "1";
                }
                ret= false;

            }
            else {
                document.getElementById("txtCatagryddl" + x).style.borderColor = "";
            }
            var ShedlTypddl = document.getElementById("txtSheduleTyp" + x).value;
            if (ShedlTypddl == "--SELECT CATEGORY--" || ShedlTypddl == "" || ShedlTypddl == 0) {
                document.getElementById("txtSheduleTyp" + x).style.borderColor = "Red";
                // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
              //  document.getElementById("txtSheduleTyp" + x).focus();
             
                if (document.getElementById("<%=hiddenEdit.ClientID%>").value != "1") {
                    $noCon("#txtSheduleTyp" + x).select();
                    $noCon("#txtSheduleTyp" + x).focus();
                    document.getElementById("<%=hiddenEdit.ClientID%>").value = "1";
                }
                ret= false;

            }
            else {
                document.getElementById("txtSheduleTyp" + x).style.borderColor = "";
            }

          
            return ret;
        }
          var cbxchk = 0;
        function CheckAllRowFieldAndHighlightValidate(x) {

            ret = true;
          
            var SheduleName = document.getElementById("txtSheduleName" + x).value.trim();
            var Catagoryddl = document.getElementById("txtCatagryddl" + x).value;
            var ShedlTypddl = document.getElementById("txtSheduleTyp" + x).value;
            var cbxStatus = document.getElementById("txtChekbox" + x);
            var cbx = 0;
          
            if (cbxStatus.checked) {
                cbx = 1;
                cbxchk++;
            }
            else {
                cbx = 0;
            }
            if (SheduleName != "" || Catagoryddl != 0 || ShedlTypddl != 0 || cbx != 0 || cbxchk!=0)
            {
                if (SheduleName == "") {
                    document.getElementById("txtSheduleName" + x).style.borderColor = "Red";
                    // document.getElementById("txtSheduleName" + x).focus();
                    $noCon("#txtSheduleName" + x).select();
                    ret = false;
                }
                else {
                    document.getElementById("txtSheduleName" + x).style.borderColor = "";
                }

                //   var Catagoryddl = document.getElementById("txtCatagryddl" + x).value;

                if (Catagoryddl == "--SELECT CATEGORY--" || Catagoryddl == "" || Catagoryddl == 0) {
                    document.getElementById("txtCatagryddl" + x).style.borderColor = "Red";
                    // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                    // document.getElementById("txtCatagryddl" + x).focus();
                    $noCon("#txtCatagryddl" + x).select();
                    ret = false;

                }
                else {
                    document.getElementById("txtCatagryddl" + x).style.borderColor = "";
                }
                //  var ShedlTypddl = document.getElementById("txtSheduleTyp" + x).value;
                if (ShedlTypddl == "--SELECT CATEGORY--" || ShedlTypddl == "" || ShedlTypddl == 0) {
                    document.getElementById("txtSheduleTyp" + x).style.borderColor = "Red";
                    // $noCon("div.Cls" + x + " input.ui-autocomplete-input").css("borderColor", "Red");
                    //  document.getElementById("txtSheduleTyp" + x).focus();
                    $noCon("#txtSheduleTyp" + x).select();
                    ret = false;

                }
                else {
                    document.getElementById("txtSheduleTyp" + x).style.borderColor = "";
                }
            }

            return ret;
        }
        
        function LocalStorageDelete(row_index, x) {

            var tbClientPicLinkUpload = localStorage.getItem("tbClientPicLinkUpload");//Retrieve the stored data

            tbClientPicLinkUpload = JSON.parse(tbClientPicLinkUpload); //Converts string to object

            if (tbClientPicLinkUpload == null) //If there is no data, initialize an empty array
                tbClientPicLinkUpload = [];



            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            tbClientPicLinkUpload.splice(row_index, 1);
            localStorage.setItem("tbClientPicLinkUpload", JSON.stringify(tbClientPicLinkUpload));
            $noCon("#cphMain_HiddenIntervw_Tem").val(JSON.stringify(tbClientPicLinkUpload));
            //   alert("Client deleted.");


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
    //CalculateTotalAmountFromHiddenField();
    IncrmntConfrmCounter();
                 // alert('gj');

}

        function CheckaddMoreRowsIndividual(x) {
            // for add image in each row
            
            var check = document.getElementById("tdInx" + x).innerHTML;
           
            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (check == " ") {
               
              //  if (retBool == true) {

                if (CheckAllRowFieldAndHighlight(x) == true) {
                   
                        document.getElementById("tdInx" + x).innerHTML = x;
                        document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";
                     
                        addMoreRows();
                        var a = x;
                        a++;
                    // document.getElementById("txtSheduleName" + a).focus();
                        //$noCon("#txtSheduleName" + a).select();
                        return false;
                    }
             //   }
              //  else if (retBool == false) {
               //     var row_index = jQuery('#rowId_' + x).index();
               //     if (CheckAllRowField(x, row_index) == true) {
               //         document.getElementById("tdInx" + x).innerHTML = x;
               //         document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";

               //         addMoreRows();


               //         return false;
               //     }
               //// }
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
                    var idlast = $noCon('#TableaddedRows tr:last').attr('id');
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


                    addMoreRows();

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


                                document.getElementById("txtSheduleName" + res[1]).focus();
                                $noCon("#txtSheduleName" + res[1]).select();
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

                                document.getElementById("txtSheduleName" + res[1]).focus();
                                $noCon("#txtSheduleName" + res[1]).select();
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

          function LoadSheduleTypddl(x, TempTypId) {

           
              //  var $coo = jQuery.noConflict();

              var ddlTestDropDownListXML = $noCon("#txtSheduleTyp" + x);

              var OptionStart = $noCon("<option>--SELECT TYPE--</option>");
              OptionStart.attr("value", 0);
              ddlTestDropDownListXML.append(OptionStart);
            //  alert(ddlTestDropDownListXML);
            
              var tableName = "dtTableShdleTyp";

              if (document.getElementById("<%=Hiddenddltyp.ClientID%>").value != 0) {
                  ddlEmpdata = document.getElementById("<%=Hiddenddltyp.ClientID%>").value;


                  // Now find the Table from response and loop through each item (row).
                  $noCon(ddlEmpdata).find(tableName).each(function () {
                      // Get the OptionValue and OptionText Column values.
                      var OptionValue = $noCon(this).find('SHEDL_TYP_ID').text();
                      var OptionText = $noCon(this).find('SHEDL_TYP_NAME').text();
                      // Create an Option for DropDownList.
                      var option = $noCon("<option>" + OptionText + "</option>");
                      option.attr("value", OptionValue);

                      ddlTestDropDownListXML.append(option);
                  });
                  if (TempTypId != 0)
                      document.getElementById("txtSheduleTyp" + x).value = TempTypId;
                  //if (CatgoryId != 0)
                  // document.getElementById("txtCatagryddl" + x).value = CatgoryId;
              }
              else {
                  var Details = PageMethods.LoadSheduleTypddl1(function (response) {





                      // ddlTestDropDownListXML.empty();


                      // Now find the Table from response and loop through each item (row).
                      $noCon(response).find(tableName).each(function () {
                          // Get the OptionValue and OptionText Column values.
                          var OptionValue = $noCon(this).find('SHEDL_TYP_ID').text();
                          var OptionText = $noCon(this).find('SHEDL_TYP_NAME').text();
                          // Create an Option for DropDownList.
                          var option = $noCon("<option>" + OptionText + "</option>");
                          // alert(OptionText); alert(OptionValue);
                          option.attr("value", OptionValue);
                          ddlTestDropDownListXML.append(option);

                          if (TempTypId != 0)
                              document.getElementById("txtSheduleTyp" + x).value = TempTypId;
                      });
                      return false;
                  });
              }
               return false;
        }
          function LoadCatgryddl(x, CatgoryId, CatgryName, Catsts) {


              //  var $coo = jQuery.noConflict();
              var IntCorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
              var IntOrgId = document.getElementById("<%=HiddenOrgid.ClientID%>").value;
              var ddlTestDropDownListXML = $noCon("#txtCatagryddl" + x);

              var OptionStart = $noCon("<option>--SELECT CATEGORY--</option>");
              OptionStart.attr("value", 0);
              ddlTestDropDownListXML.append(OptionStart);
              //  alert(ddlTestDropDownListXML);
           
              var tableName = "dtTableCatgryTyp";
              if (document.getElementById("<%=HiddenddlLoad.ClientID%>").value != 0) {
                  ddlEmpdata = document.getElementById("<%=HiddenddlLoad.ClientID%>").value;
                
                  
                 
                  // Now find the Table from response and loop through each item (row).
                  $noCon(ddlEmpdata).find(tableName).each(function () {
                      // Get the OptionValue and OptionText Column values.
                      var OptionValue = $noCon(this).find('INTWCTGRY_ID').text();
                      var OptionText = $noCon(this).find('INTWCTGRY_NAME').text();
                      // Create an Option for DropDownList.
                      var option = $noCon("<option>" + OptionText + "</option>");
                      option.attr("value", OptionValue);

                      ddlTestDropDownListXML.append(option);
                  });
                  if (Catsts != 2) {
                      if (Catsts == 0) {
                          var OptionValue = CatgoryId;
                          var OptionText = CatgryName;
                          // alert(CatgoryId);
                          // alert(CatgryName);
                          //  ddlTestDropDownListXML.append(newOption);
                          var option = $noCon("<option>" + OptionText + "</option>");

                          // alert(OptionText); alert(OptionValue);
                          option.attr("value", OptionValue);
                          ddlTestDropDownListXML.append(option);
                          //SORTING DDL
                          var options = $noCon("#txtCatagryddl" + x + " option");
                          //var options = ("ddlTestDropDownListXML option");
                          // Collect options
                          options.detach().sort(function (a, b) {               // Detach from select, then Sort
                              var at = $noCon(a).text();
                              var bt = $noCon(b).text();
                              return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                          });
                          options.appendTo(ddlTestDropDownListXML);
                          if (CatgoryId != 0)
                              document.getElementById("txtCatagryddl" + x).value = CatgoryId;
                      }
                  }
                  if (CatgoryId != 0)
                  document.getElementById("txtCatagryddl" + x).value = CatgoryId;
                  //if (CatgoryId != 0)
                     // document.getElementById("txtCatagryddl" + x).value = CatgoryId;
              }
              else {
               

                  var Details = PageMethods.LoadCatgryddl1(IntCorpId, IntOrgId, function (response) {



                      //   ddlTestDropDownListXML.empty();

                      var cancelChk = 2;
                      // Now find the Table from response and loop through each item (row).
                      $noCon(response).find(tableName).each(function () {
                          // Get the OptionValue and OptionText Column values.
                          var OptionValue = $noCon(this).find('INTWCTGRY_ID').text();
                          var OptionText = $noCon(this).find('INTWCTGRY_NAME').text();
                          // Create an Option for DropDownList.
                          var option = $noCon("<option>" + OptionText + "</option>");
                          // alert(OptionText); alert(OptionValue);
                          option.attr("value", OptionValue);
                          ddlTestDropDownListXML.append(option);
                          if (OptionValue == CatgoryId) {
                              cancelChk = 1;


                          }
                          else {
                              cancelChk = 0;

                          }
                          //  if (jQuery(this).text() == CatgoryId)
                          ///    cancelChk = 1;

                          //if (CatgoryId!=0)
                          // document.getElementById('ddlTestDropDownListXML').value = CatgoryId;
                          if (CatgoryId != 0)
                              document.getElementById("txtCatagryddl" + x).value = CatgoryId;

                      });
                      if (CatgoryId != 0) {
                          if (cancelChk == 0) {

                              var OptionValue = CatgoryId;
                              var OptionText = CatgryName;
                              // alert(CatgoryId);
                              // alert(CatgryName);
                              //  ddlTestDropDownListXML.append(newOption);
                              var option = $noCon("<option>" + OptionText + "</option>");

                              // alert(OptionText); alert(OptionValue);
                              option.attr("value", OptionValue);
                              ddlTestDropDownListXML.append(option);
                              //SORTING DDL
                              var options = $noCon("#txtCatagryddl" + x + " option");
                              //var options = ("ddlTestDropDownListXML option");
                              // Collect options
                              options.detach().sort(function (a, b) {               // Detach from select, then Sort
                                  var at = $noCon(a).text();
                                  var bt = $noCon(b).text();
                                  return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                              });
                              options.appendTo(ddlTestDropDownListXML);
                              if (CatgoryId != 0)
                                  document.getElementById("txtCatagryddl" + x).value = CatgoryId;

                          }

                          //  return false;
                      }
                  });
              }
           
              return false;
          }
          function prevValueChk(x) {

              document.getElementById("<%=hiddenFieldPrevValueChk.ClientID%>").value = document.getElementById('txtSheduleName' + x).value;
          }
          function CheckSheduleNameDupl(xLoop, x) {
              if (xLoop != x) {
                  var SheduleName = document.getElementById("txtSheduleName" + x).value.trim(); 
                  SheduleName = SheduleName.toUpperCase();
                  var SheduleNamedup = document.getElementById("txtSheduleName" + xLoop).value.trim();
                  SheduleNamedup = SheduleNamedup.toUpperCase();
                  if (SheduleName == SheduleNamedup) {
                      alert("Duplication not allowed in shedule name");
                      document.getElementById("txtSheduleName" + x).value = "";
                      document.getElementById("txtSheduleName" + x).focus();
                      $noCon("#txtSheduleName" + x).select();
                      // ret = false;
                  }
              }

          }
          
          function LinkChangeFile(x, y) {

           
             // if (isTag(y)) {
                
               //   document.getElementById("file" + x).style.borderColor = "";

              //   if (document.getElementById('txtSheduleName' + x).value != "") {

              var table = document.getElementById('TableaddedRows');
              // alert(table.rows.length);
              for (var i = 0; i < table.rows.length; i++) {
                  if (i != table.rows.length - 1) {
                      // FIX THIS
                      var row = table.rows[i];

                      var xLoop = (table.rows[i].cells[0].innerHTML);
                     
                      if (CheckSheduleNameDupl(xLoop,x) == false) {
                          ret = false;
                      }


                  }
              }
              var NameWithoutReplace = document.getElementById('txtSheduleName' + x).value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById('txtSheduleName' + x).value = replaceText2;

                     var prevtxtValue = document.getElementById("<%=hiddenFieldPrevValueChk.ClientID%>").value;
                     // alert(prevtxtValue);
                      var vartxtbox = document.getElementById('txtSheduleName' + x).value;

                       IncrmntConfrmCounter();
                       //if (document.getElementById('file' + x).value != "") {

                       //    document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;

                       //}
                       if (prevtxtValue != vartxtbox) {
                          
                           //var tbClientImageValidation = localStorage.getItem("tbClientImageValidation");//Retrieve the stored data

                           //tbClientImageValidation = JSON.parse(tbClientImageValidation);
                           //if (tbClientImageValidation == null) //If there is no data, initialize an empty array
                           //    tbClientImageValidation = [];
                           //var $addFile = jQuery.noConflict();
                           //var client = JSON.stringify({
                           //    ROWID: "" + x + "",

                           //});


                           //if (client != "") {

                           //    tbClientImageValidation.push(client);
                           //    localStorage.setItem("tbClientImageValidation", JSON.stringify(tbClientImageValidation));

                           //    $addFile("#cphMain_HiddenFieldValidation").val(JSON.stringify(tbClientImageValidation));


                           var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
                           //var SavedorNot = document.getElementById("FileSave" + x).innerHTML;

                           if (SavedorNot == "saved") {
                             //  var row_index = jQuery('#FilerowId_' + x).index();
                               var row_index = jQuery('#rowId_' + x).index();
                             
                               FileLocalStorageEdit(x, row_index);
                           }
                           else {

                               var CatgoryId = 0; var TempTypId = 0;
                               FileLocalStorageAdd(x, CatgoryId, TempTypId);
                           }
                       }
                   

                  // }
               //}
               //else {


               //}

          }
          function UpdateCbxScore(x,y)
          {
             
              isTag(y);
            
              IncrmntConfrmCounter();
              var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
              //var SavedorNot = document.getElementById("FileSave" + x).innerHTML;

              if (SavedorNot == "saved") {
                  //  var row_index = jQuery('#FilerowId_' + x).index();
                  var row_index = jQuery('#rowId_' + x).index();

                  FileLocalStorageEdit(x, row_index);
              }
              else {

                  var CatgoryId = 0; var TempTypId = 0;
                  FileLocalStorageAdd(x, CatgoryId, TempTypId);
              }
          }
          function Changeddl(x,y)
          {
              IncrmntConfrmCounter();
              var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
              //var SavedorNot = document.getElementById("FileSave" + x).innerHTML;

              if (SavedorNot == "saved") {
                  //  var row_index = jQuery('#FilerowId_' + x).index();
                  var row_index = jQuery('#rowId_' + x).index();

                  FileLocalStorageEdit(x, row_index);
              }
              else {

                  var CatgoryId = 0; var TempTypId = 0;
                  FileLocalStorageAdd(x, CatgoryId, TempTypId);
              }
          }
          function FileLocalStorageEdit(x, row_index) {
             
              var tbClientPicLinkUpload = localStorage.getItem("tbClientPicLinkUpload");
             

             
              tbClientPicLinkUpload = JSON.parse(tbClientPicLinkUpload);

         

              if (tbClientPicLinkUpload == null) //If there is no data, initialize an empty array
                  tbClientPicLinkUpload = [];

              var SheduleName = document.getElementById("txtSheduleName" + x).value.trim();
            
             
              var varddlCat = document.getElementById("txtCatagryddl"+x);
              var ddlCatText = varddlCat.options[varddlCat.selectedIndex].value;
              if (ddlCatText == "--SELECT CATEGORY--")
                  ddlCatText = 0;
            
              var varddlTyp = document.getElementById("txtSheduleTyp" + x);
              var ddlTypText = varddlTyp.options[varddlTyp.selectedIndex].value;
              if (ddlTypText == "--SELECT TYPE--")
                  ddlTypText = 0;
              
              var cbxStatus = document.getElementById("txtChekbox" + x);
              var cbx = 0;

              if (cbxStatus.checked) {
                  cbx = 1;
              }
              else {
                  cbx = 0;
              }
             
              var detailId = document.getElementById("tdDtlId" + x).innerHTML;
              var evt = document.getElementById("tdEvt" + x).innerHTML;
             
              if (evt == 'INS') {

                  var $FileE = jQuery.noConflict();
              
                  tbClientPicLinkUpload[row_index] = JSON.stringify({
                      ROWID: "" + x + "",
                      LNKTXT: "" + SheduleName + "",
                      CATID: "" + ddlCatText + "",
                      SHEDTYPID: "" + ddlTypText + "",
                      SCORECHK: "" + cbx + "",
                      EVTACTION: "" + evt + "",
                      DTLID: "0"

                  });

              }
              else {

                  var $FileE = jQuery.noConflict();
                 
                  tbClientPicLinkUpload[row_index] = JSON.stringify({
                      ROWID: "" + x + "",
                      LNKTXT: "" + SheduleName + "",
                      CATID: "" + ddlCatText + "",
                      SHEDTYPID: "" + ddlTypText + "",
                      SCORECHK: "" + cbx + "",
                      EVTACTION: "" + evt + "",
                      DTLID: "" + detailId + ""

                  });



              }
            
             // tbClientPicLinkUpload.push(client);
              localStorage.setItem("tbClientPicLinkUpload", JSON.stringify(tbClientPicLinkUpload));

              $FileE("#cphMain_HiddenIntervw_Tem").val(JSON.stringify(tbClientPicLinkUpload));
            
            
              //localStorage.setItem("tbClientPictureUpload", JSON.stringify(tbClientPictureUpload));
              //$FileE("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPictureUpload));
              //localStorage.setItem("tbClientPicLinkUpload", JSON.stringify(tbClientPicLinkUpload));
              //$addFile("#cphMain_HiddenField2_FileUploadLnk").val(JSON.stringify(tbClientPicLinkUpload));



              return true;
          }

          function FileLocalStorageAdd(x, CatgoryId, TempTypId) {

             
              var tbClientPicLinkUpload = localStorage.getItem("tbClientPicLinkUpload");//Retrieve the stored data
             // var tbClientPictureUpload = localStorage.getItem("tbClientPictureUpload");//Retrieve the stored data

             // tbClientPictureUpload = JSON.parse(tbClientPictureUpload); //Converts string to object
              tbClientPicLinkUpload = JSON.parse(tbClientPicLinkUpload); //Converts string to object

          //    if (tbClientPictureUpload == null) //If there is no data, initialize an empty array
                 // tbClientPictureUpload = [];

              if (tbClientPicLinkUpload == null) //If there is no data, initialize an empty array
                  tbClientPicLinkUpload = [];

              // var Linktxt = document.getElementById("textbx" + x).innerHTML;

            
              var SheduleName = document.getElementById("txtSheduleName" + x).value.trim();
             // if (CatgoryId != 0)
                //  document.getElementById("txtCatagryddl" + x) = CatgoryId;
              var varddlCat = document.getElementById("txtCatagryddl" + x);
              var ddlCatText = varddlCat.options[varddlCat.selectedIndex].value;
            
              if (ddlCatText == "--SELECT CATEGORY--")
                  ddlCatText = 0;
            
              var varddlTyp = document.getElementById("txtSheduleTyp" + x);
              var ddlTypText = varddlTyp.options[varddlTyp.selectedIndex].value;
              if (ddlTypText == "--SELECT TYPE--")
                  ddlTypText = 0;
              
              var cbxStatus = document.getElementById("txtChekbox" + x);
              var cbx = 0;

              if (cbxStatus.checked) {
                  cbx = 1;
              }
              else {
                  cbx = 0;
              }
             
              var detailId = document.getElementById("tdDtlId" + x).innerHTML;
            
              var evt = document.getElementById("tdEvt" + x).innerHTML;
              if (CatgoryId != 0)
                  ddlCatText = CatgoryId;
              if (TempTypId != 0)
                  ddlTypText = TempTypId;
           
              if (evt == 'INS') {

                  var $addFile = jQuery.noConflict();

                  var client = JSON.stringify({

                      ROWID: "" + x + "",
                      LNKTXT: "" + SheduleName + "",
                      CATID: "" + ddlCatText + "",
                      SHEDTYPID: "" + ddlTypText + "",
                      SCORECHK: "" + cbx + "",
                      EVTACTION: "" + evt + "",
                      DTLID: "0"

                  });

                
              }
              else if (evt == 'UPD') {
                  var $addFile = jQuery.noConflict();
                  var client = JSON.stringify({
                      ROWID: "" + x + "",
                      LNKTXT: "" + SheduleName + "",
                      CATID: "" + ddlCatText + "",
                      SHEDTYPID: "" + ddlTypText + "",
                      SCORECHK: "" + cbx + "",
                      EVTACTION: "" + evt + "",
                      DTLID: "" + detailId + ""

                  });

                
              }

              if (client != "" && client != null) {
                  tbClientPicLinkUpload.push(client);
                  localStorage.setItem("tbClientPicLinkUpload", JSON.stringify(tbClientPicLinkUpload));

                  $addFile("#cphMain_HiddenIntervw_Tem").val(JSON.stringify(tbClientPicLinkUpload));
              }
            
           
              document.getElementById("tdSave" + x).innerHTML = "saved";


              return true;

          }

          function EditListRows(SheduleName, CatgoryId, TempTypId, ScoreSts, TempDetlId, CatgryName,Catsts) {
              SheduleName = SheduleName.toUpperCase();
             
                              rowCount++;
                  RowIndex++;
                  var stsCheck=true;

                //  var nAmnt = EditAmount;

               //   var AmntMaxLen = 12;

                  // for floatting number adjustment from corp global
          




                //      document.getElementById("spanAddRowTax").style.opacity = "0.3";



                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();

            
              var recRow = '<tr id="rowId_' + rowCount + '" >';
              recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
              recRow += '<td style="width: 3%;text-align: center;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


              recRow += ' <td id="tdSheduleName' + rowCount + '"  style="width: 24.3%;">';
              recRow += ' <input  id="txtSheduleName' + rowCount + '"   type="text" onkeypress="return isTag(event);" onkeydown="return DisableEnter(event);" onfocus="prevValueChk(\'' + rowCount + '\');" onblur="LinkChangeFile(\'' + rowCount + '\',event);"    maxlength=85 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 99%;margin-left: -0.5%;"/>';
              recRow += '   </td> ';


              recRow += ' <td id="tdCatagory' + rowCount + '" style="width: 24.3%;"><div class="Cls' + rowCount + '">';
              recRow += ' <select  onchange=\"Changeddl(\'' + rowCount + '\',event);\" style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 99%;margin-left: 0.1%;" id="txtCatagryddl' + rowCount + '" class="form1" /> ';
              recRow += ' </div> </td> ';
              //  recRow += ' <td  style="display: none;"><input id="txtselectorVhclId' + rowCount + '"  value="--Select Vehicle--" type="text"   /></td>';
              //  recRow += ' <td  style="display: none;"><input id="txtselectorVhclName' + rowCount + '"  value="--Select Vehicle--" type="text" maxlength=100  /></td>';


              recRow += ' <td id="tdShduleTyp' + rowCount + '" style="width: 24.3%;"><div class="Cls' + rowCount + '">';
              recRow += ' <select  onchange=\"Changeddl(\'' + rowCount + '\',event);\" style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 99%;margin-left: 0.1%;float: left;" id="txtSheduleTyp' + rowCount + '" class="form1" /> ';
              recRow += ' </div> </td> ';
              // recRow += ' <td  style="display: none;"><input id="txtSheduleTypId' + rowCount + '"  value="--Select Vehicle--" type="text"   /></td>';
              //recRow += ' <td  style="display: block;"><select id="txtSheduleTypName' + rowCount + '"  value="--Select Vehicle--"  maxlength=100  /></td>';
            
              if (ScoreSts == 0)
                  stsCheck =false;
            //  alert(stsCheck);
              recRow += ' <td style="width: 9.3%;border: 1px solid rgb(207, 204, 204);background-color:white;"><input   id="txtChekbox' + rowCount + '" class="form1" onchange=\"UpdateCbxScore(\'' + rowCount + '\',event  );\"  type="checkbox" onkeypress="return isTag(event);"   style="text-align: right; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 89%;margin-left: -11.1%;"/></td>';

              recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ');" title="ADD" style="  cursor: pointer;"></td>';
              recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to Delete this Entry?\');" title="DELETE"   style=" cursor: pointer;" ></td>';



                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + TempDetlId + '</td>';

                // recRow += '<td id="tdSlNumbr' + rowCount + '" style="display: none;"></td>';


                recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                recRow += '</tr>';






                jQuery('#TableaddedRows').append(recRow);
                document.getElementById("txtSheduleName" + rowCount).value = SheduleName;
                document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";
                //  document.getElementById("selectorItem" + rowCount).focus();
                // alert('add rows');
                LoadSheduleTypddl(rowCount, TempTypId);
                LoadCatgryddl(rowCount, CatgoryId, CatgryName, Catsts);
                scoreStsCheck(rowCount, stsCheck);
             //   setTimeout(Selectddl(rowCount, CatgoryId), 100);
                var $au = jQuery.noConflict();
            

                //(function ($au) {
                //    $au(function () {
                //        selectorToAutocompleteTextBox('txtselectorVhcl' + rowCount, rowCount);
                //        //   $('#selectorItem' + rowCount).selectToAutocomplete();

                //        $au('form').submit(function () {

                //            //   alert($au(this).serialize());


                //            //   return false;
                //        });
                //    });
                //})(jQuery);
               
               
                FileLocalStorageAdd(rowCount, CatgoryId, TempTypId);

         

          }
         function Selectddl(x,CatgoryId)
          {
             // var x = 0;
           
             document.getElementById("txtCatagryddl" + x).value = CatgoryId;
             // x++;
          }
         function ViewListRows(SheduleName, CatgoryId, TempTypId, ScoreSts, TempDetlId, CatgryName, Catsts) {

              rowCount++;
              RowIndex++;
              var stsCheck = true;

              //  var nAmnt = EditAmount;

              //   var AmntMaxLen = 12;

              // for floatting number adjustment from corp global





              //      document.getElementById("spanAddRowTax").style.opacity = "0.3";



              document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();

                 
                  var recRow = '<tr id="rowId_' + rowCount + '" >';
                  recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                  recRow += '<td style="width: 3%;text-align: center;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


                  recRow += ' <td id="tdSheduleName' + rowCount + '"  style="width: 36.3%;">';
                  recRow += ' <input disabled value=' + SheduleName + ' id="txtSheduleName' + rowCount + '"   type="text" onkeypress="return isTag(event);" onkeydown="return DisableEnter(event);" onfocus="prevValueChk(\'' + rowCount + '\');" onblur="LinkChangeFile(\'' + rowCount + '\',event);"    maxlength=85 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 99%;margin-left: -0.5%;"/>';
                  recRow += '   </td> ';


                  recRow += ' <td id="tdCatagory' + rowCount + '" style="width: 24.3%;"><div class="Cls' + rowCount + '">';
                  recRow += ' <select disabled  onchange=\"Changeddl(\'' + rowCount + '\',event);\" style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 99%;margin-left: 0.1%;" id="txtCatagryddl' + rowCount + '" class="form1" /> ';
                  recRow += ' </div> </td> ';
                 //  recRow += ' <td  style="display: none;"><input id="txtselectorVhclId' + rowCount + '"  value="--Select Vehicle--" type="text"   /></td>';
                 //  recRow += ' <td  style="display: none;"><input id="txtselectorVhclName' + rowCount + '"  value="--Select Vehicle--" type="text" maxlength=100  /></td>';


                  recRow += ' <td id="tdShduleTyp' + rowCount + '" style="width: 24.3%;"><div class="Cls' + rowCount + '">';
                  recRow += ' <select disabled  onchange=\"Changeddl(\'' + rowCount + '\',event);\" style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 99%;margin-left: 0.1%;float: left;" id="txtSheduleTyp' + rowCount + '" class="form1" /> ';
                  recRow += ' </div> </td> ';
                 // recRow += ' <td  style="display: none;"><input id="txtSheduleTypId' + rowCount + '"  value="--Select Vehicle--" type="text"   /></td>';
                 //recRow += ' <td  style="display: block;"><select id="txtSheduleTypName' + rowCount + '"  value="--Select Vehicle--"  maxlength=100  /></td>';

                  if (ScoreSts == 0)
                      stsCheck = false;
                 //  alert(stsCheck);
                  recRow += ' <td style="width: 9.3%;border: 1px solid rgb(207, 204, 204);background-color:white;"><input disabled  id="txtChekbox' + rowCount + '" class="form1" onchange=\"UpdateCbxScore(\'' + rowCount + '\',event  );\"  type="checkbox"   onkeypress="return isTag(event);" style="text-align: right; line-height: 20px; margin-top:0px; margin-bottom: 2px; width: 89%;margin-left: -11.1%;"/></td>';

                  recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input disabled id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ');" title="ADD"  style="  cursor: pointer;"></td>';
                  recRow += '<td style="width: 1.5%; padding-left: 1px;"><input disabled type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to Delete this Entry?\');"  title="DELETE"  style=" cursor: pointer;" ></td>';



                  recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                  recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
                  recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                  recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + TempDetlId + '</td>';

                 // recRow += '<td id="tdSlNumbr' + rowCount + '" style="display: none;"></td>';


                  recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                  recRow += '</tr>';






                  jQuery('#TableaddedRows').append(recRow);
                  document.getElementById("txtSheduleName" + rowCount).value = SheduleName;
                  document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                  document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";
                 //  document.getElementById("selectorItem" + rowCount).focus();
                 // alert('add rows');
                  LoadSheduleTypddl(rowCount, TempTypId);
                  LoadCatgryddl(rowCount, CatgoryId, CatgryName, Catsts);
                  scoreStsCheck(rowCount, stsCheck);
                  var $au = jQuery.noConflict();

                 //(function ($au) {
                 //    $au(function () {
                 //        selectorToAutocompleteTextBox('txtselectorVhcl' + rowCount, rowCount);
                 //        //   $('#selectorItem' + rowCount).selectToAutocomplete();

                 //        $au('form').submit(function () {

                 //            //   alert($au(this).serialize());


                 //            //   return false;
                 //        });
                 //    });
                 //})(jQuery);


                  FileLocalStorageAdd(rowCount, CatgoryId, TempTypId);



              }
          function scoreStsCheck(rowCount, stsCheck)
          {
              document.getElementById("txtChekbox" + rowCount).checked = stsCheck;
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
                     window.location.href = "gen_Interview_Temp_Master_List.aspx";
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Interview_Temp_Master_List.aspx";

             }
         }
         function AlertClearAll() {
             if (confirmbox > 0) {
                 if (confirm("Are you sure you want clear all data in this page?")) {
                     window.location.href = "gen_Interview_Temp_Master_List.aspx";
                     return false;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Interview_Temp_Master_List.aspx";
                 return false;
             }
         }
         function ClearAll() {
             if (confirmbox > 0) {
                 if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                     window.location.href = "gen_Interview_Temp_Master.aspx";
                     return false;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Interview_Temp_Master.aspx";
                 return false;
             }
         }

         function SuccessUpdation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Interview template updated successfully.";
         }
         function SuccessConfirmation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Interview template inserted successfully.";
         }
         function SuccessUpdationPrj() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Interview template updated successfully.";
         }

         function DuplicationName() {
             document.getElementById('divMessageArea').style.display = "";

             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.Sponsor name can’t be duplicated.";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=txtTemplateName.ClientID%>").focus();
         }

         function DuplicationIntervwTemName()
         {
             document.getElementById('divMessageArea').style.display = "";

             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.Template name can’t be duplicated..";
 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
         }

    </script>
      <script type="text/javascript" >
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



          function Validate() {

              var ret = true;
              if (CheckIsRepeat() == true) {
              }
              else {
                  ret = false;
                  return ret;
              }
              document.getElementById("<%=hiddenEdit.ClientID%>").value = "";
              document.getElementById('divErrorNotification').style.visibility = "hidden";
              document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";
              document.getElementById('divMessageArea').style.display = "hidden";
            
              // replacing < and > tags
              var NameWithoutReplace = document.getElementById("<%=txtTemplateName.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtTemplateName.ClientID%>").value = replaceText2;


           

              document.getElementById("<%=txtTemplateName.ClientID%>").style.borderColor = "";
            

              //document.getElementById('divMessageArea').style.display = "none";
              //document.getElementById('imgMessageArea').src = "";

              var Sumrypos = document.getElementById("<%=txtTemplateName.ClientID%>").value.trim();
             



              if (Sumrypos == "") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txtTemplateName.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtTemplateName.ClientID%>").focus();

                  ret = false;
              }
              else {
            
                 // if (document.getElementById("<%=HiddenUpdateChk.ClientID%>").value == "") {
                      if (document.getElementById("<%=HiddenFieldDuplcnChk.ClientID%>").value == "1") {
                          document.getElementById('divMessageArea').style.display = "";

                          document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.Template name can’t be duplicated.";
                          document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                          document.getElementById("<%=txtTemplateName.ClientID%>").style.borderColor = "Red";
                          document.getElementById("<%=txtTemplateName.ClientID%>").focus();
                          CheckSubmitZero();
                          return false;
                      }
                //  }
              }

              var table = document.getElementById('TableaddedRows');
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


                      //var xLoop = (table.rows[i].cells[0].innerHTML);
                      //if (document.getElementById("tdChanged" + xLoop).innerHTML == "Changed") {
                      //    if (CheckAllRowFieldAndHighlight(xLoop, false) == false) {
                      //        ret = false;
                      //    }
                      //}

                  }
                  if (ret == false)
                  {
                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                      //document.getElementById('divErrorNotification').style.visibility = "visible";
                     // document.getElementById('divErrorNotification').style.visibility = "visible";
                     // document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  }
              }
              var TableRowCount = document.getElementById("TableaddedRows").rows.length;
           
              if (TableRowCount != 0) {
                  // if (TableRowCount == 1) {
                  //if added a row not entered any value validate

                  var idlast = $noCon('#TableaddedRows tr:last').attr('id');
                  if (idlast != "") {
                      var res = idlast.split("_");
                      var x = res[1];

                      if (document.getElementById("<%=HiddenUpdateChk.ClientID%>").value != "") {
                         
                          if (CheckAllRowFieldAndHighlightValidate(x) == false) {
                              ret = false;
                          }
                          if (TableRowCount == 1)
                          {
                              
                              if (CheckAllRowFieldAndHighlight(x) == false) {
                                  ret = false;
                              }
                          }
                      }
                      else {
                          if (CheckAllRowFieldAndHighlight(x) == false) {
                              ret = false;
                          }
                      }

                      if (ret == false) {
                         
                          document.getElementById('divMessageArea').style.display = "";
                          document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                          document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                         // document.getElementById('divErrorNotification').style.visibility = "visible";
                         // document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                           }
                       }
                   // }
                   }



              if (Sumrypos == "") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txtTemplateName.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtTemplateName.ClientID%>").focus();

                  ret = false;
              }
              else {

                  // if (document.getElementById("<%=HiddenUpdateChk.ClientID%>").value == "") {
                  if (document.getElementById("<%=HiddenFieldDuplcnChk.ClientID%>").value == "1") {
                      document.getElementById('divMessageArea').style.display = "";

                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.Template name can’t be duplicated.";
                          document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                          document.getElementById("<%=txtTemplateName.ClientID%>").focus();
                          CheckSubmitZero();
                          return false;
                      }
                  //  }
                  }

             
             
              CheckSubmitZero();
              if (ret == true) {
                  document.getElementById("<%=HiddenddlLoad.ClientID%>").value = 0;
                  document.getElementById("<%=Hiddenddltyp.ClientID%>").value = 0;
              }
              return ret;

          }

    </script>
    <script>





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

        function RemoveTag() {
            // replacing < and > tags
            //var NameWithoutReplace = document.getElementById(obj).value;
            //      var replaceText1 = NameWithoutReplace.replace(/</g, "");
            //      var replaceText2 = replaceText1.replace(/>/g, "");
            //      document.getElementById(obj).value = replaceText2.trim();

        }
        function DuplcnNameChk()
        {
            var IntCorpId=  document.getElementById("<%=HiddenCorpId.ClientID%>").value;
            var IntOrgId= document.getElementById("<%=HiddenOrgid.ClientID%>").value;
            var name;
            var TempId = document.getElementById("<%=hiddenTemNextId.ClientID%>").value;
            
            var NameWithoutReplace = document.getElementById("<%=txtTemplateName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            name = replaceText2;
            var Details = PageMethods.DuplcnTempNameChk(name,IntCorpId, IntOrgId,TempId, function (response) {
                document.getElementById("<%=HiddenFieldDuplcnChk.ClientID%>").value = response;
               // alert(document.getElementById("<%=HiddenFieldDuplcnChk.ClientID%>").value);
            });
        }

    </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenNewCustId" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenDup" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenCustomerFocus" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenJobId" runat="server" />
     <asp:HiddenField ID="HiddenCorpId" runat="server" />
     <asp:HiddenField ID="HiddenOrgid" runat="server" />
    <asp:HiddenField ID="HiddenIntervw_Tem" runat="server" />
      <asp:HiddenField ID="hiddenFieldPrevValueChk" runat="server" />
      <asp:HiddenField ID="hiddenTemNextId" runat="server" />
      <asp:HiddenField ID="hiddenEdit" runat="server" />
       <asp:HiddenField ID="HiddenTempDetailId" runat="server" />
      <asp:HiddenField ID="hiddenView" runat="server" />
     <asp:HiddenField ID="HiddenUpdateChk" runat="server" />
    
   <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
     <asp:HiddenField ID="HiddenTabFocus" runat="server" />
     <asp:HiddenField ID="HiddenFieldDuplcnChk" runat="server" />
    <asp:HiddenField ID="HiddenddlLoad" runat="server" />
       <asp:HiddenField ID="Hiddenddltyp" runat="server" />
        <asp:Label ID="lblIndex" runat="server" Text="Label" Style="display: none"></asp:Label>
    <div class="cont_rght" style="padding-top: 1%;">

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
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; margin-bottom: 2%;">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <div style="width:100%;float:left">
                  

        
                  <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Template Name*</h2>
                       <asp:TextBox ID="txtTemplateName"  class="form1" runat="server" MaxLength="80" onblur="DuplcnNameChk();" onkeydown="textCounter(cphMain_txtTemplateName,80)" onkeyup="textCounter(cphMain_txtTemplateName,80)" Style="resize:none; width: 49%;height:32px; text-transform: uppercase;font-family:Calibri; margin-right: 4.5%;"></asp:TextBox>
                    
                     
                </div>
             
                <div class="subform" style=" margin-left: -28%;width: 8%;float: left;margin-top: 5%;">


                    <asp:CheckBox ID="cbxStatus" Text="" runat="server" onkeydown="return DisableEnter(event)" Checked="true" class="form2" />
                    <h3>Active</h3>

                </div>
                   <div class="subform" style=" width: 17%; float: left;margin-top: 5%;margin-left: -18%; ">


                    <asp:CheckBox ID="cbxValidateSts" Text="" runat="server" onkeydown="return DisableEnter(event)" Checked="true" class="form2" />
                    <h3>Validate Levels in Order</h3>

                </div>
              


             

                
                  </div>
                    <div class="leads_form">
                <div id="divErrorNotification" style="visibility: hidden">
                    <asp:Label ID="lblErrorNotification" runat="server"></asp:Label>
                </div>
                <div id="divTables" style="width: 100%; margin: auto; padding-top: 0.6%;">

                    <table id="TableHeaderBilling" rules="all" style="width: 97.5%;">

                        <tr>
                            <td style="font-size: 14px; width: 3%; padding-left: 0.5%;">Sl#</td>
                            <td style="font-size: 14px; width: 36.3%; padding-left: 0.5%;">Schedule Name</td>
                            <td style="font-size: 14px; width: 24.3%; padding-left: 0.5%;text-align: left;">Category</td>
                            <td style="font-size: 14px; width: 24.3%; text-align: left; padding-left: 0.5%;">Type</td>
                            <td style="font-size: 14px; width: 9.3%; text-align: center; padding-right: 1%;">Scoring</td>

                             <td  style="  font-size: 14px; width: 3%; text-align: center; padding-right: 1%;background: #f4f6f0;"></td>

                            
                                <%--  this not used  now if needed remove display none--%>
                                <img src="../../../Images/imgAddRows.png" style="cursor: pointer; width: 100%; height: 30px; display: none" onclick="CheckaddMoreRows();" />

                            </td>
                        </tr>
                    </table>

                    <div style="width: 100%; min-height: 75px; overflow-y: auto;">
                        <table id="TableaddedRows" style="width: 100%;">
                        </table>

<%--                        <table id="TableFooterBilling" rules="all" style="width: 95.4%; border: 1px none; background-color: beige;">

                            <tr>
                                <td style="font-size: 18px; width: 85%; padding-right: 1.2%; text-align: right; color: black;">Total</td>

                                <td id="tdFooterTotalAmount" style="font-size: 14px; width: 15%; text-align: right; padding-right: 0.3%;"></td>



                            </tr>
                        </table>--%>


                    </div>
                    <div id="divBlink" style="background-color: rgb(249, 246, 3); font-size: 10.5px; color: black; opacity: 0.6;"></div>

                </div>

             <%--    <select style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 96%;margin-left: -0.9%;" id="txtSheduleTypName"/>--%>


            </div>
           
            	   <div class="eachform" style="width: 49%;  float: right;margin-top: 0%;">
                    <div class="subform" style="width: 70%; padding: 2%;margin-right: 67%;">

                    <asp:Button ID="btnUpdate"  runat="server" class="save" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnUpdateClose"  runat="server" class="save" Text="Update & Close" OnClientClick="return Validate(); " OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnAdd"  runat="server" class="save" Text="Save"  OnClientClick="return Validate();" OnClick="btnAdd_Click"  />
       
                    <asp:Button ID="btnAddClose"  runat="server" class="save" Text="Save & Close" OnClientClick="return Validate();" OnClick="btnAdd_Click"  />
                    <asp:Button ID="btnCancel"  runat="server" class="cancel" OnClientClick="return AlertClearAll();" Text="Cancel" PostBackUrl="gen_Interview_Temp_Master.aspx"  />
                    <asp:Button ID="btnClear"  runat="server" style="margin-left: 19px;" OnClientClick="return ClearAll();"  class="cancel" Text="Clear"/>
                       
        
               </div>
                </div>

                

                <br style="clear: both" />
            </div>




        </div>
 

    <style>

        .form1 {
            
            height: 27px;
        }
    </style>
</asp:Content>



