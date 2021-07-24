<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_OnBording_Certificate_Bundle_Template.aspx.cs" Inherits="HCM_HCM_Master_hcm_OnBoarding_hcm_OnBoarding_Certificate_Template_hcm_OnBording_Certificate_Bundle_Template" %>



<asp:Content ID="Content2" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="../../../../Design/HTML%20-%2004.04.2016/js/bootstrap.min.js"></script>
    <link href="../../../../css/bootstrap.min.3.3.5.css" rel="stylesheet" />

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
            width: 95%;
        }
    </style>
    <script src="/JavaScript/jquery-1.8.3.min.js"></script>
    <script>
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {


            document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = "";

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
                        if (json[key].TempId != "") {

                            EditListRows(json[key].TEMDTL_NAME, json[key].DfltStatus, json[key].TEMDTL_ID);

                        }
                    }
                }
                CheckAddEachRowLoad();

            }

            else if (ViewVal != "") {



                document.getElementById("<%=txtName.ClientID%>").disabled = true;
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
                            if (json[key].IntwCatId != "") {

                                ViewListRows(json[key].TEMDTL_NAME, json[key].DfltStatus, json[key].IntwCatDtlId);

                            }
                        }
                    }
                    CheckAddEachRowLoad();
                }
              

            if (EditVal == "" && ViewVal=="") {


                addMoreRows();

                document.getElementById("<%=txtName.ClientID%>").focus();

            }


        });

     
    </script>

    <script type="text/javascript">



        var $noC = jQuery.noConflict();
        var rowCount = 0;

        var RowIndex = 0;


        function addMoreRows() {
            document.getElementById('divErrorNotification').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotification.ClientID%>").innerHTML = "";
            rowCount++;
            RowIndex++;



            nMoney = 0;

            document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


            var recRow = '<tr id="rowId_' + rowCount + '" >';
            recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
            recRow += '<td style="width: 8%;text-align: center;padding: 2px;padding-right: 5px;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


            recRow += ' <td id="tdAPTName' + rowCount + '"  style="width: 72%;padding: 4px;">';
            recRow += ' <input  id="txtAPTName' + rowCount + '"  class="BillngEntryField"  type="text" onblur=\"return BlurTextvalue(\'' + rowCount + '\');\"  onkeypress="return isTag(event)"  maxlength=95 style="text-align: left; text-transform: uppercase; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;margin-left: -0.5%;"/>';
            recRow += '   </td> ';


            recRow += ' <td style="width: 11%;padding: 4px;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 81%;margin-left: 2%;"><input checked="true" id="cbDefault' + rowCount + '" style="margin-left: 32%;margin-top: -3%;" class="BillngEntryField" type="checkbox" onchange="IncrmntConfrmCounter();" /></div></td>';

            recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 5.5%; padding-left: 4px;"> <input id="IndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="/Images/Icons/addEntry.png" alt="Add" onclick="return CheckAddEachRow(\'' + rowCount + '\');" title="ADD" style="  cursor: pointer;"></td>';
            recRow += '<td style="width: 5.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return CheckDelEachRow(' + rowCount + ');"  title="DELETE"  style=" cursor: pointer;" ></td>';

            recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">INS</td>';
            recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;"></td>';


            recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
            recRow += '</tr>';



            jQuery('#TableaddedRows').append(recRow);


        }


        function EditListRows(IntwCatDtlName, DfltStatus, IntwCatDtlId) {


                rowCount++;
                RowIndex++;


                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();


                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 8%;text-align: center;padding: 2px;padding-right: 5px;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


                recRow += ' <td id="tdAPTName' + rowCount + '"  style="width: 72%;padding: 4px;">';
                recRow += ' <input  id="txtAPTName' + rowCount + '"  class="BillngEntryField"  type="text" value="' + IntwCatDtlName + '"  onblur=\"return BlurTextvalue(\'' + rowCount + '\');\" onkeypress="return isTag(event)"   maxlength=95 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;margin-left: -0.5%;"/>';
                recRow += '   </td> ';

                if (DfltStatus == 0) {
                    recRow += ' <td style="width: 11%;padding: 4px;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 81%;margin-left: 2%;"><input  id="cbDefault' + rowCount + '" style="margin-left: 29%;margin-top: -3%;" class="BillngEntryField" type="checkbox"  onchange="IncrmntConfrmCounter();"  /></div></td>';
                }
                else {
                    recRow += ' <td style="width: 11%;padding: 4px;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 81%;margin-left: 2%;"><input  id="cbDefault' + rowCount + '" checked="true" style="margin-left: 29%;margin-top: -3%;"  class="BillngEntryField" type="checkbox" onchange="IncrmntConfrmCounter();"    /></div></td>';
                }

                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 5.5%; padding-left: 4px;"> <input id="IndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="/Images/Icons/addEntry.png"  alt="Add" onclick="return CheckAddEachRow(\'' + rowCount + '\');" title="ADD" style="  cursor: pointer;"></td>';
                recRow += '<td style="width: 5.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return CheckDelEachRow(' + rowCount + ');"  title="DELETE"  style=" cursor: pointer;" ></td>';

                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + IntwCatDtlId + '</td>';

                recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                recRow += '</tr>';
                jQuery('#TableaddedRows').append(recRow);

        }
        function ViewListRows(IntwCatDtlName, DfltStatus, IntwCatDtlId) {

            if (IntwCatDtlName != "" && DfltStatus != "" && IntwCatDtlId != "") {

                rowCount++;
                RowIndex++;

                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();

                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td style="width: 8%;text-align: center;padding: 2px;padding-right: 5px;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';


                recRow += ' <td id="tdAPTName' + rowCount + '"  style="width: 72%;padding: 4px;">';
                recRow += ' <input  id="txtAPTName' + rowCount + '" disabled class="BillngEntryField"  type="text" value="' + IntwCatDtlName + '"  onkeypress="return isTag(\'event\')"  maxlength=95 style="text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;margin-left: -0.5%;"/>';
                recRow += '   </td> ';

                if (DfltStatus == 0) {
                    recRow += ' <td style="width: 11%;padding: 4px;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 81%;margin-left: 2%;"><input  id="cbDefault' + rowCount + '" disabled style="margin-top: -3%;margin-left: 29%;" class="BillngEntryField" type="checkbox" /></div></td>';
                }
                else {
                    recRow += ' <td style="width: 11%;padding: 4px;"><div style="background-color: white;border: 1px solid #7A7A7A;line-height: 23px;margin-bottom: 4px; width: 81%;margin-left: 2%;"><input  id="cbDefault' + rowCount + '" checked="true" disabled style="margin-top: -3%;margin-left: 29%;" class="BillngEntryField" type="checkbox"  onchange="IncrmntConfrmCounter();"   /></div></td>';
                }
                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 5.5%; padding-left: 4px;"> <input disabled id="IndvlAddMoreRowPic' + rowCount + '"  type="image"  class="BillngEntryField" src="/Images/Icons/addEntry.png"  alt="Add" onclick="return CheckAddEachRow(\'' + rowCount + '\');" title="ADD"  style="  cursor: pointer;"></td>';
                recRow += '<td style="width: 5.5%; padding-left: 1px;"><input disabled type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return CheckDelEachRow(' + rowCount + ');"  title="DELETE"  style=" cursor: pointer;" ></td>';


                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">UPD</td>';
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + IntwCatDtlId + '</td>';
                recRow += '</tr>';
                jQuery('#TableaddedRows').append(recRow);




            }


        }

        function ReNumberTable() {

            var table = "";
            table = document.getElementById('TableaddedRows');

            for (var i = 0, row; row = table.rows[i]; i++) {
                var x = "";

                //iterate through rows
                //rows would be accessed using the "row" variable assigned in the for loop
                for (var j = 0, col; col = row.cells[j]; j++) {
                    if (j == 0) {
                        x = col.innerHTML;
                        if (x != "") {

                            var intRecount = parseInt(i) + 1;

                            document.getElementById("divSlNum" + x).innerText = intRecount

                        }
                    }
                }
            }
        }
        var $noconfli = jQuery.noConflict();
        function CheckAddEachRow(CurrRow) {

            if (document.getElementById("txtAPTName" + CurrRow).value != "") {

                addMoreRows();
                for (var DisCount = 1; DisCount < rowCount; DisCount++) {
              
                    var AddButton = $noconfli("#tdIndvlAddMoreRow" + DisCount);
                    if (AddButton.length) {
                        document.getElementById("IndvlAddMoreRowPic" + DisCount).disabled = true;
                        document.getElementById("IndvlAddMoreRowPic" + DisCount).style.opacity = "0.3";
                    }
                }
            }
            return false;
        }
        function CheckAddEachRowLoad() {

            for (var DisCount = 1; DisCount < rowCount; DisCount++) {

                var AddButton = $noconfli("#tdIndvlAddMoreRow" + DisCount);
                if (AddButton.length) {
                    document.getElementById("IndvlAddMoreRowPic" + DisCount).disabled = true;
                    document.getElementById("IndvlAddMoreRowPic" + DisCount).style.opacity = "0.3";
                }
            }
        
            return false;
        }
        function CheckDelEachRow(Delrowcount) {
            var newCount = 0;
            if (confirm("Are you sure?. You want to remove.")) {
                AddDeleted(Delrowcount);
                jQuery('#rowId_' + Delrowcount).remove();
                ReNumberTable();
                for (var EnCount = rowCountPartnr; EnCount > 0; EnCount--) {
                    var AddButton = $noconfli("#tdIndvlAddMoreRow" + EnCount);
                    if (AddButton.length) {
                        newCount++;
                        document.getElementById("IndvlAddMoreRowPic" + EnCount).disabled = false;
                        document.getElementById("IndvlAddMoreRowPic" + EnCount).style.opacity = "1";
                        break;
                    }

                }
                if (newCount == 0) {
                    addMoreRowsPartnr();
                }
            }
            return false;
        }

        function AddDeleted(Delrowcount) {
            if (document.getElementById("tdEvt" + Delrowcount).innerHTML == "UPD") {
                var detailId = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value;
                detailId = detailId + "," + document.getElementById("tdDtlId" + Delrowcount).innerHTML;
                document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = detailId;
            }

        }
      
        function BlurTextvalue(count)
        {
            var NameWithoutReplace = document.getElementById("txtAPTName" + count).value.trim();
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("txtAPTName" + count).value = replaceText2;

            CompareAPTNames(count);
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
                        var txtName = document.getElementById("txtAPTName" + xLoop).value;
                        txtName = txtName.toUpperCase();

                        if (txtName == ChAptName) {
                            alert("Duplication not allowed in certificates name");
                            document.getElementById("txtAPTName" + x).value = "";
                        }
                    }

                }
            }
        }


        function ValidateAndSave(mode) {

            ret = true;
            document.getElementById('divMessageArea').style.display = "none";
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";


              for (var count = 1; count <= rowCount; count++) {
                  var AddButton = $noconfli("#txtAPTName" + count);
                  if (AddButton.length) {
                      if (document.getElementById("txtAPTName" + count).value == "") {
                          document.getElementById("txtAPTName" + count).style.borderColor = "red";
                          document.getElementById("txtAPTName" + count).focus();
                          ErrMsg();
                          ret = false;
                      }

                  }
              }

              if (ret == true) {

                  var tbClientTotalValues = '';
                  tbClientTotalValues = [];

                  for (var counting = 1; counting <= rowCount; counting++) {

                      var $add = jQuery.noConflict();

                      var cbValue = 0;
                      if ($add("#cbDefault" + counting).is(":checked")) {
                          // it is checked
                          cbValue = 1;
                      }
                      var detailId = document.getElementById("tdDtlId" + counting).innerHTML;
                      var evt = document.getElementById("tdEvt" + counting).innerHTML;

                      var client = JSON.stringify({
                          ROWID: "" + counting + "",
                          APTNAME: $add("#txtAPTName" + counting).val(),
                          DEFLTSTATUS: "" + cbValue + "",
                          EVTACTION: "" + evt + "",
                          DTLID: "" + detailId + "",
                      });


                      tbClientTotalValues.push(client);
                  }
                
                  document.getElementById("<%=HiddenField1.ClientID%>").value = JSON.stringify(tbClientTotalValues);

              }
              else {
                  CheckSubmitZero();
              }

              IntwCatName = document.getElementById("<%=txtName.ClientID%>").value.trim();
              if (IntwCatName == "") {
                  ErrMsg();
                  document.getElementById("<%=txtName.ClientID%>").focus();
                  document.getElementById("<%=txtName.ClientID%>").style.borderColor = 'Red';
                  ret = false;
              }
              else {
                  var strOrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
                  var strCorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
                  var strCrtName = "";
                  var strCatId = "";
                  strCrtName = document.getElementById("<%=txtName.ClientID%>").value;
                  strCatId = document.getElementById("<%=hiddenIntwCatID.ClientID%>").value;
                  $co = jQuery.noConflict();
                  $co.ajax({
                      type: "POST",
                      async: false,
                      contentType: "application/json; charset=utf-8",
                      url: "hcm_OnBording_Certificate_Bundle_Template.aspx/CheckDupCertificateTemplate",
                      data: '{strCertfctTempId:"' + strCatId + '",strCertName:"' + strCrtName + '",strOrgId:"' + strOrgId + '",strCorpId:"' + strCorpId + '"}',

                      dataType: "json",
                      success: function (data) {

                          if (data.d == "0") {
                            
                          }
                          else {
                              DuplicateInterviewCategory();
                              ret = false;
                          }

                      },
                      error: function (response) {

                      }

                  });

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
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Certificate bundle template inserted successfully.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function DuplicateInterviewCategory() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Certificate bundle template can’t be duplicated.";
            document.getElementById("<%=txtName.ClientID%>").focus();
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = 'Red';

        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Certificate bundle template updated successfully.";
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
                        window.location.href = "hcm_OnBording_Certificate_Bundle_Template_List.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    window.location.href = "hcm_OnBording_Certificate_Bundle_Template_List.aspx";
                    return false;
                }
            }
        }
        function ConfirmClear() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to clear?")) {
                    window.location.href = "hcm_OnBording_Certificate_Bundle_Template.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "hcm_OnBording_Certificate_Bundle_Template.aspx";
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




<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenEdit" runat="server" />
    <asp:HiddenField ID="hiddenView" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
    <asp:HiddenField ID="hiddenIntwCatID" runat="server" />
    <asp:HiddenField ID="HiddenFieldClose" runat="server" />

    <asp:Label ID="lblIndex" runat="server" Text="Label" Style="display: none"></asp:Label>
    <div class="cont_rght">


        <%--  --%>

        <div id="divMessageArea" style="display: none; margin: 0px 0 13px;">
            <img id="imgMessageArea" src="">
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>



        <br />

        <div class="fillform" style="width: 100%;">
            <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 2%; top: 37%; height: 26.5px;">

                <%--   <a href="gen_ProductBrandList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
            </div>
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; width: 80%;">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
            <div style="float: left; width: 65%; background-color: #f4f6f0; border: 1px solid #a4b487;">
                <div id="divCardNumber" style="width: 60%; margin-top: 2.2%; margin-left: 5%;" class="eachform">
                    <h2 style="margin-top: 0%; float: left; padding-right: 7%;">Name *</h2>
                    <%--<asp:DropDownList ID="ddlCardNumber" class="form1" Style="width: 65.5%; float: left;" runat="server" onblur="return ChangeCardNumber();" onfocus="getPreviousDDLCardNumber_SelectedVal()" autofocus="autofocus" autocorrect="off" autocomplete="off"></asp:DropDownList>--%>
                    <asp:TextBox runat="server" ID="txtName" MaxLength="95" onkeypress="return isTag(event);" onblur="return RemoveTag('cphMain_txtName');" class="form1" Style="text-transform: uppercase; margin-right: 19%;" />

                </div>
                <div id="div1" style="width: 60%; margin-top: 0.2%; float: left; margin-left: 5%;" class="eachform">
                    <h2 style="margin-top: 0%; float: left; padding-right: 2%;">Status *</h2>
                    <%--<asp:CheckBox Text="Active" runat="server" />--%>
                    <div class="subform" style="width: 215px; float: right; margin-right: 23%;">
                        <asp:CheckBox ID="cbxCnclStatus" Text="" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server" Checked="true" class="form2" />
                        <h3 style="margin-top: 1%;">Active</h3>
                    </div>

                </div>
                <div style="float: left; width: 95%; background-color: #d9dbd6; margin-left: 2.5%; margin-bottom: 2%;">
                    <div id="divErrorNotification" style="visibility: hidden">
                        <asp:Label ID="lblErrorNotification" runat="server"></asp:Label>
                    </div>
                    <div id="divTables" style="width: 95%; margin: auto; padding-top: 0.6%;">
                        <h2 style="margin-top: 1%; color: #3b5645;">Certificates</h2>
                        <table id="TableHeaderBilling" rules="all" style="width: 100%;">

                            <tr>
                                <td style="font-size: 14px; width: 8%; padding-left: 0.5%;">Sl#</td>
                                <td style="font-size: 14px; width: 72%; padding-left: 0.5%;">Name</td>
                                <td style="font-size: 14px; width: 9%; padding-left: 0.5%;">Active</td>



                                <td id="spanAddRow" style="width: 11%; background: rgb(217, 219, 214) none repeat scroll 0% 0%;">
                                    <img src="../../../Images/imgAddRows.png" style="cursor: pointer; width: 100%; height: 30px; display: none" onclick="CheckaddMoreRows();" />

                                </td>
                            </tr>
                        </table>


                        <table id="TableaddedRows" style="width: 100%;">
                        </table>

                    </div>


                </div>





            </div>


            <div style="float: left; width: 34%">

                <div style="float: left; width: 80%; margin-left: 18%; background-color: #f4f6f0; min-height: 221px; border: 1px solid #a4b487;">
                    <label style="width: 100%; text-align: center; float: left; font-size: 19px; font-family: calibri; color: #214236;">Certificate Bundles </label>


                    <div id="divHistoryContainer" style="float: left; width: 100%; max-height: 190px; overflow: auto;" runat="server">
                    </div>

                </div>

            </div>


            <div class="eachform">

                <div class="subform" style="margin-left: 15.8%; width: 70%; margin-top: 2%; float: left;">


                    <asp:Button ID="btnSave" runat="server" class="save" Text="Save" OnClientClick="return ValidateAndSave('Save');" OnClick="btnSave_Click" />
                    <asp:Button ID="btnSaveClose" runat="server" class="save" Text="Save & Close" OnClientClick="return ValidateAndSave('Save');" OnClick="btnSave_Click" />
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClientClick="return ValidateAndSave('Update');" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClientClick="return ValidateAndSave('Update');" OnClick="btnUpdate_Click" />


                    <asp:Button ID="btnClear" runat="server" class="save" Text="Clear" OnClientClick="return ConfirmClear();" />
                    <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                </div>

            </div>


        </div>
    </div>

    <style>
        .panel-title {
            margin-top: 0;
            margin-bottom: 0;
            font-size: 15px;
            color: white;
        }

        .panel-heading {
            background-color: #439ecf;
            border: 2px solid #679dba;
            padding: 2px;
            margin: 3px;
            float: left;
            width: 95%;
        }

        .panel-body {
            width: 98%;
            background-color: white;
            margin-left: 1%;
            padding: 2px;
        }

        .EachDiv {
            float: left;
            width: 99%;
            margin: 1px;
            background-color: #f6f6f6;
            border: 1px solid #1a75ae;
            color: #051a59;
            padding-left: 2%;
        }


        .txt-color-green {
            color: #00c500 !important;
        }

        .txt-color-red {
            color: #a90329 !important;
        }
    </style>
</asp:Content>

