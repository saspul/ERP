<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit.master" CodeFile="fms_Account_Setting.aspx.cs" Inherits="FMS_FMS_Master_fms_Account_Setting_fms_Account_Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
     <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
        <script>
            var $au = jQuery.noConflict();
            $au(function () {
                $au(".ddl").selectToAutocomplete1Letter();
            });
         </script>
     <style>
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



   

        <script>
            var $noCon1 = jQuery.noConflict();
            $noCon1(window).load(function () {
                document.getElementById("ddlPrmryAccountGrp0").focus();
                var EditVal = document.getElementById("<%=HiddenFinancialYear.ClientID%>").value;
                if (EditVal != "") {
                    var find2 = '\\"\\[';
                    var re2 = new RegExp(find2, 'g');
                    var res2 = EditVal.replace(re2, '\[');

                    var find3 = '\\]\\"';
                    var re3 = new RegExp(find3, 'g');
                    var res3 = res2.replace(re3, '\]');
                    var json = $noCon1.parseJSON(res3);
                    for (var key in json) {
                        if (json.hasOwnProperty(key)) {
                            if (json[key].FINCYR_ID != "") {
                                EditListRows(json[key].FINCYR_ID, json[key].FINCYR_START_DT, json[key].FINCYR_END_DT, json[key].FINCYR_STATUS, json[key].FINCYR_DEFAULTNAME);
                            }
                        }
                    }
                   buttnVisibile();
                }
                if (document.getElementById("<%=HiddenRestritionStatus.ClientID%>").value == "1")
                    document.getElementById("cphMain_btnPrimaryDtlsSave").style.display = "none";
                else
                    document.getElementById("cphMain_btnPrimaryDtlsSave").style.display = "block";
                var tblPrimaryGrp = document.getElementById("tblPrimaryAccntGrp");
                for (var i = 1; i < tblPrimaryGrp.rows.length; i++) {
                    var xLoop = (tblPrimaryGrp.rows[i].cells[0].innerHTML);
                    document.getElementById("ddlPrmryAccountGrp" + xLoop).style.borderColor = "";
                    if (document.getElementById("ddlPrmryAccountGrp" + xLoop).value != "-Select Account Group-")
                        document.getElementById("cphMain_btnPrimaryDtlsSave").style.display = "none";
                    else
                        document.getElementById("cphMain_btnPrimaryDtlsSave").style.display = "block";
                }
            });
            function EditListRows(FINCYR_ID, FINCYR_START_DT, FINCYR_END_DT, FINCYR_STATUS, FINCYR_DEFAULTNAME) {

                if (FINCYR_ID != 0) {
                    AddNewGroup();
                    document.getElementById("tdidFYDtls" + currntx).innerHTML = currntx;
                    document.getElementById("tdInxGrp" + currntx).value = currntx;
                    document.getElementById("YearADD" + currntx).style.opacity = "0.3";
                    document.getElementById("bttnRemovGrp" + currntx).style.opacity = "0.3";
                    document.getElementById("bttnRemovGrp" + currntx).disabled = true;

                    document.getElementById("StartDateFY" + currntx).value = FINCYR_START_DT;
                    document.getElementById("EndDateFY" + currntx).value = FINCYR_END_DT;
                    document.getElementById("DefaultName" + currntx).value = FINCYR_DEFAULTNAME;

                    if (FINCYR_STATUS == "1") {
                        document.getElementById("cbxStatus" + currntx).checked = true;
                    }
                    else {
                        document.getElementById("cbxStatus" + currntx).checked = false;
                    }
                    document.getElementById("tdDtlIdTempid" + currntx).value = FINCYR_ID;
                    document.getElementById("tdCurrentFin" + currntx).value = FINCYR_STATUS;
                    
                }
                else {
                    AddNewGroup();
                }
                //Kooiii
                if (currntx == 1) {
                    var StartDateFY = document.getElementById("StartDateFY" + currntx).value;
                    var EndDateFY = document.getElementById("EndDateFY" + currntx).value;
                    var arrstartYear = StartDateFY.split("-");
                    var arrEndYear = EndDateFY.split("-");
                    var defaultnm1 = parseInt(arrstartYear[2]);
                    var defaultnm2 = parseInt(arrEndYear[2]);
                    var last2 = defaultnm2.toString().slice(-2);
                    if (defaultnm1 == defaultnm2) {
                        document.getElementById("DefaultName" + currntx).value = defaultnm1;
                    }
                    else {
                        document.getElementById("DefaultName" + currntx).value = defaultnm1 + '-' + last2;
                    }
                }
                document.getElementById("bttnRemovGrp1").style.opacity = "0.3";
                document.getElementById("bttnRemovGrp1").disabled = true;
            }

            function ChangePrimaryGrp(RowId) {
                if (document.getElementById("ddlPrmryAccountGrp" + RowId).value != "" && document.getElementById("ddlPrmryAccountGrp" + RowId).value != "-Select Account Group-") {
                    document.getElementById("cphMain_btnPrimaryDtlsSave").style.display = "block";
                }
                else {
                    document.getElementById("cphMain_btnPrimaryDtlsSave").style.display = "none";
                }
            }
            function buttnVisibile() {
                var TableRowCount = document.getElementById("tableFinacialYear").rows.length;
                addRowtable = document.getElementById("tableFinacialYear");

                var TableRowCount1 = document.getElementById("tableFinacialYear").rows.length;
                    if (TableRowCount1 != 0) {
                        var idlast1 = $noCon1('#tableFinacialYear tr:last').attr('id');
                        if (idlast1 != "") {
                            var res1 = idlast1.split("_");
                            document.getElementById("tdInxGrp" + res1[1]).value = "";
                            document.getElementById("YearADD" + res1[1]).style.opacity = "1";
                            document.getElementById("bttnRemovGrp" + res1[1]).style.opacity = "1";
                            document.getElementById("bttnRemovGrp" + res1[1]).disabled = false;

                        }
                    }
                    document.getElementById("bttnRemovGrp1").style.opacity = "0.3";
                    document.getElementById("bttnRemovGrp1").disabled = true;
            }
            function isTag(evt) {

                evt = (evt) ? evt : window.event;
                var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                //if (keyCodes == 13) {
                //    return false;
                //}
                var charCode = (evt.which) ? evt.which : evt.keyCode;
                var ret = true;
                if (charCode == 60 || charCode == 62) {
                    ret = false;
                }
                return ret;
            }
            // for not allowing enter
            function DisableEnter(evt) {
                //  var b = new Date(); alert(b);

                evt = (evt) ? evt : window.event;
                var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                if (keyCodes == 13) {
                    return false;
                }
            }
            function SuccessConfirmation() {
                $noCon1("#success-alert").html("Account settings inserted successfully.");
                $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                
                $(window).scrollTop(0);
                return false;
            }
            function FinancialYear() {
                $noCon1("#divWarning").html("Current financial year can not be deleted.");
                $noCon1("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                
                $(window).scrollTop(0);
                return false;
            }
            function PrimaryAccountInsertion() {
                $noCon1("#success-alert").html("Primary account groups inserted successfully.");
                $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                
                $(window).scrollTop(0);
                $(window).scrollTop(0);
                return false;
            }
            var confirmbox = 0;

            function IncrmntConfrmCounter() {
                confirmbox++;
            }
            
            function changePrintVersion(RowCount) {
                var AccountHead = document.getElementById("ddlPrintVersion" + RowCount).value;
                document.getElementById("ddlPrintVersion_Id" + RowCount).value = AccountHead;
            }
            function changeLedger(RowCount)
            {
                var AccountHead = document.getElementById("ddlAccountHead" + RowCount).value;
                document.getElementById("ddlAccountHead_Id" + RowCount).value = AccountHead;
            }
            function changeAccount(RowCount) {
                var AccountHead = document.getElementById("ddlAccountGrp" + RowCount).value;
                document.getElementById("ddlAccountGrp_Id" + RowCount).value = AccountHead;
            }
 
            var RowId = 0;
            var currntx = 0;
            function AddNewGroup() {
                RowId++;
                var FrecRow = '';
                FrecRow = '<tr id="SubFYRowId_' + RowId + '" ><td   id="tdidFYDtls' + RowId + '" style="display: none" >' + RowId + '</td>';
                FrecRow += '<div style="clear:both"></div>';
                FrecRow += ' <td class=" tr_l">';
                FrecRow += '<input name="StartDateFY' + RowId + '" readonly="readonly" value="" id="StartDateFY' + RowId + '" style="border: none;"  type="text"></td>';
                FrecRow += '</td > <td class=" tr_l"><input style="border: none;" name="EndDateFY' + RowId + '" readonly="readonly"   value="" id="EndDateFY' + RowId + '" maxlength="10" type="text" > </td>';
                FrecRow += ' <td class="tr_l"><input style="border: none;" name="DefaultName' + RowId + '"  value="" id="DefaultName' + RowId + '" readonly="readonly"  maxlength="20" type="text"> </td>';
               FrecRow += '<td class=" tr_l"><div id=\"divcbxStatus' + RowId + '\" class=\"check1\"> <div class=""> <label class="switch" ><input name="cbxStatus' + RowId + '" type="checkbox" value="' + RowId + '" id="cbxStatus' + RowId + '"  onchange=\"CheckboxCheck(' + RowId + ');\" onkeypress="return DisableEnter(event)">  <span class="slider_tog round"></span> </label></div></div>';
                FrecRow += '</td>';
                
                FrecRow += '<td class=" tr_l"><div class="btn_stl1"><button title="DELETE" id="bttnRemovGrp' + RowId + '"   onclick="return removeRowGrps(' + RowId + ',\'Are you sure you want to delete this financial year?\')" class="btn act_btn bn3" >';
                FrecRow += ' <i class="fa fa-trash"></i></button>';
                FrecRow += '<button title="ADD"  id="YearADD' + RowId + '" onclick="return CheckAddNewRow(\'' + RowId + '\')" class="btn act_btn bn2" ><i class="fa fa-plus-circle"></i></button>';
                FrecRow += '</div></td>';
                FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdTempid' + RowId + '" name="tdDtlIdTempid' + RowId + '" placeholder=""/><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdGrp' + RowId + '" name="tdDtlIdGrp' + RowId + '" placeholder=""/></td>';

                FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdInxGrp' + RowId + '" name="tdInxGrp' + RowId + '" placeholder=""/> </td>';
                FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdCurrentFin' + RowId + '" name="tdCurrentFin' + RowId + '" placeholder=""/> </td></tr>';


                jQuery('#tableFinacialYear').append(FrecRow);
                var Startdate = "";
                var Enddate = "";
                if (currntx != 0) {
                    var defaultnm1 = "";
                    var defaultnm2 = "";
                    var xLoop = "";
                    var tblFinacialYear = document.getElementById("tableFinacialYear");
                    for (var i = 1; i < tblFinacialYear.rows.length; i++) {
                        if (tblFinacialYear.rows[i].cells[0].innerHTML != "") {
                            xLoop = tblFinacialYear.rows[i].cells[0].innerHTML;
                            if (document.getElementById("EndDateFY" + xLoop).value != "") {
                                Startdate = document.getElementById("EndDateFY" + xLoop).value;
                            }
                        }
                    }
                    if (Startdate != "") {
                       // Startdate = document.getElementById("EndDateFY" + currntx).value;
                        var arrstartYear = Startdate.split("-");
                        if (parseInt(arrstartYear[1]) < 12) {
                            document.getElementById("StartDateFY" + RowId).value = ("01-" + parseInt(parseInt(arrstartYear[1]) + parseInt(1)) + "-" + arrstartYear[2]);
                             if (parseInt(arrstartYear[1]) <10) {
                                document.getElementById("StartDateFY" + RowId).value = ("01-0" + parseInt(parseInt(arrstartYear[1]) + parseInt(1)) + "-" + arrstartYear[2]);
                            }
                            defaultnm1 = parseInt(arrstartYear[2]);
                        }
                        else {
                            document.getElementById("StartDateFY" + RowId).value = ("01-01" + "-" +  parseInt(parseInt(arrstartYear[2]) + parseInt(1)));
                            defaultnm1 = parseInt(parseInt(arrstartYear[2]) + parseInt(1));
                        }
                    }
                    if (document.getElementById("StartDateFY" + RowId).value != "") {
                        Enddate = document.getElementById("StartDateFY" + RowId).value;
                        var arrEndYear = Enddate.split("-");
                        var newdate = new Date(arrEndYear[2], arrEndYear[1] - 1, arrEndYear[0]);

                        newdate.setMonth(newdate.getMonth() + 11);
                        //var day = newdate.getDate();
                        var day = new Date(newdate.getFullYear(), newdate.getMonth() + 1, 0);
                        day = day.getDate();
                        if (parseInt(day) < 10) {
                            day = "0" + day;
                        }
                        var month = newdate.getMonth()+1;
                        if (parseInt(month) < 10) {
                            month = "0" + month;
                        }
                        var year= newdate.getFullYear();
                        defaultnm2 = year;
                        document.getElementById("EndDateFY" + RowId).value = day + '-' + month + '-' + year;

                    }
                    if (defaultnm1 != "" && defaultnm2 != "") {
                  
                        if (defaultnm1 == defaultnm2) {
                        
                            document.getElementById("DefaultName" + RowId).value = defaultnm1;
                        }
                        else {
                            var last2 = defaultnm2.toString().slice(-2);
                            document.getElementById("DefaultName" + RowId).value = defaultnm1 + '-' + last2;
                        }
                    }
                }
    
                currntx = RowId;
                return false;
            }

            function CheckAddNewRow(RowId) {
                var ret = true;
                var check = document.getElementById("tdInxGrp" + RowId).value;
                if (check == "") {
                    var startYear = document.getElementById("StartDateFY" + RowId).value;
                    var endYear = document.getElementById("EndDateFY" + RowId).value;
                    var DefaultName = document.getElementById("DefaultName" + RowId).value;
                    document.getElementById("DefaultName" + RowId).style.borderColor = "";
                    document.getElementById("EndDateFY" + RowId).style.borderColor = "";
                    document.getElementById("StartDateFY" + RowId).style.borderColor = "";

                  
                    if (DefaultName == "") {
                        document.getElementById("DefaultName" + RowId).style.borderColor = "Red";
                        document.getElementById("DefaultName" + RowId).focus();
                        ret = false;
                    }
                    if (endYear == "") {
                        document.getElementById("EndDateFY" + RowId).style.borderColor = "Red";
                        document.getElementById("EndDateFY" + RowId).focus();

                        ret = false;
                    }
                    if (startYear == "") {
                        document.getElementById("StartDateFY" + RowId).style.borderColor = "Red";
                        document.getElementById("StartDateFY" + RowId).focus();

                        ret = false;
                    }
                
                    if (ret == false) {
                        $noCon1("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $noCon1("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        
                        $noCon1(window).scrollTop(0);
                        
                    }
                    else {

                        document.getElementById("tdInxGrp" + RowId).value = RowId;
                        document.getElementById("YearADD" + RowId).style.opacity = "0.3";
                        document.getElementById("bttnRemovGrp" + RowId).style.opacity = "0.3";
                        document.getElementById("bttnRemovGrp" + RowId).disabled = true;

                        AddNewGroup();
                    }
                }
                return false;
            }
            function CheckboxCheck(RowId) {
                $('input[type="checkbox"]').each(function () {
                    var row = $(this).attr("id");
                    varSplit = row.split('cbxStatus');
                    if (varSplit[1] != "") {
                        document.getElementById('cbxStatus' + varSplit[1]).checked = false;
                    }
                });
                document.getElementById('cbxStatus' + RowId).checked = true;
            }

            function ValidatePrimaryAccountGrp() {
                var ret = true;
                var orgid  = '<%= Session["ORGID"] %>';
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                var userid = '<%= Session["USERID"] %>';
                var RestritionStatus = document.getElementById("<%=HiddenRestritionStatus.ClientID%>").value;

                var tblPrimaryGrp = document.getElementById("tblPrimaryAccntGrp");
                for (var i = 1; i < tblPrimaryGrp.rows.length; i++) {
                    var xLoop = (tblPrimaryGrp.rows[i].cells[0].innerHTML);
                    document.getElementById("ddlPrmryAccountGrp" + xLoop).style.borderColor = "";
                    $("#divPrmryAccntGrps" + xLoop + "> input").css("borderColor", "none");
                    if (document.getElementById("ddlPrmryAccountGrp" + xLoop).value == "-Select Account Group-" || document.getElementById("ddlPrmryAccountGrp" + xLoop).value == "") {
                        document.getElementById("ddlPrmryAccountGrp" + xLoop).focus();
                        $("#divPrmryAccntGrps" + xLoop + "> input").css("borderColor", "red");
                        ret = false;
                    }
                }
                if (ret == true) {
                    for (var i = 1; i < tblPrimaryGrp.rows.length; i++) {
                        var xLoop = (tblPrimaryGrp.rows[i].cells[0].innerHTML);
                        var PrimaryGrp = "";
                        var PrimaryGrpId = "";
                        var PrmryAccountGrp = "";
                        if (tblPrimaryGrp.rows[i].cells[0].innerHTML != "") {
                            PrimaryGrpId = tblPrimaryGrp.rows[i].cells[0].innerHTML;
                            if (document.getElementById("ddlPrmryAccountGrp" + PrimaryGrpId).value != 0 && document.getElementById("ddlPrmryAccountGrp" + PrimaryGrpId).value != "") {
                                PrmryAccountGrp = document.getElementById("ddlPrmryAccountGrp" + PrimaryGrpId).value;
                            }
                            if (document.getElementById("tdPrmryId" + PrimaryGrpId).value != 0 && document.getElementById("tdPrmryId" + PrimaryGrpId).value != "") {
                                PrimaryGrp = document.getElementById("tdPrmryId" + PrimaryGrpId).value;
                            }
                            $noCon1.ajax({
                                type: "POST",
                                async:false,
                                url: "fms_Account_Setting.aspx/AccountSetting",
                                data: '{intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '"  ,PrimaryGrp:"' + PrimaryGrp + '" ,PrmryAccountGrp:"' + PrmryAccountGrp + '"}',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (response) {
                                },
                                failure: function (response) {
                                }
                            });
                        }
                    }
                    $noCon1.ajax({
                        type: "POST",
                        async: false,
                        url: "fms_Account_Setting.aspx/LoadOthetsAccountSetting",
                        data: '{intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",RestritionStatus:"' + RestritionStatus + '" }',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                                if (response.d[0] != "") {
                                    document.getElementById("cphMain_ModuleGrp").innerHTML = response.d[0];
                                }
                                if (response.d[1] != "") {
                                    document.getElementById("cphMain_HeadMap").innerHTML = response.d[1];
                                }
                                if (response.d[3] != "") {
                                    document.getElementById("divPrimaryAccntGrps").innerHTML = response.d[3];
                                }
                        },
                        failure: function (response) {
                        }
                    });

                    PrimaryAccountInsertion();

                    document.getElementById("cphMain_btnPrimaryDtlsSave").style.display = "none";
                    setTimeout(function () { ValidatAccountGrp(); }, 2500);

                }
                return false;
            }

            function ValidatAccountGrp() {
                var tbClientTotalValues = '';
                tbClientTotalValues = [];
                var ret = true;
                var flag = 0;

                var tblPrimaryGrp = document.getElementById("tblPrimaryAccntGrp");
                for (var i = 1; i < tblPrimaryGrp.rows.length; i++) {

                    var xLoop = (tblPrimaryGrp.rows[i].cells[0].innerHTML);
                    document.getElementById("ddlPrmryAccountGrp" + xLoop).style.borderColor = "";
                    $("#divPrmryAccntGrps" + xLoop + "> input").css("borderColor", "none");

                    if (document.getElementById("ddlPrmryAccountGrp" + xLoop).value == "-Select Account Group-" || document.getElementById("ddlPrmryAccountGrp" + xLoop).value == "") {
                      
                        document.getElementById("ddlPrmryAccountGrp" + xLoop).focus();
                        $("#divPrmryAccntGrps" + xLoop + "> input").css("borderColor", "red");
                        //document.getElementById("divPrmryAccntGrps" + xLoop).style.borderColor = "red";
                        ret = false;

                    }
                }

                var tblFinacialYear = document.getElementById("tableFinacialYear");
                for (var i = 1; i < tblFinacialYear.rows.length; i++) {
                    var xLoop = (tblFinacialYear.rows[i].cells[0].innerHTML);
                    if (document.getElementById("DefaultName" + xLoop).value == "") {
                        document.getElementById("DefaultName" + xLoop).focus();
                        document.getElementById("DefaultName" + xLoop).style.borderColor = "red";
                        ret = false;
                    }
                    if (document.getElementById("EndDateFY" + xLoop).value == "") {
                        document.getElementById("EndDateFY" + xLoop).focus();
                        document.getElementById("EndDateFY" + xLoop).style.borderColor = "red";
                        ret = false;
                    }
                    if (document.getElementById("StartDateFY" + xLoop).value == "") {
                        document.getElementById("StartDateFY" + xLoop).focus();
                        document.getElementById("StartDateFY" + xLoop).style.borderColor = "red";
                        ret = false;
                    }
                    if (document.getElementById("cbxStatus" + xLoop).checked) {
                        flag++;
                    }

                }
                var tblModuleHead = document.getElementById("tblHeadModule");
                for (var i = 1; i < tblModuleHead.rows.length; i++) {
                    var xLoop = (tblModuleHead.rows[i].cells[0].innerHTML);
                    if (document.getElementById("ddlAccountHead" + xLoop).value == "-Select Ledger-" || document.getElementById("ddlAccountHead" + xLoop).value == "") {
                        document.getElementById("ddlAccountHead" + xLoop).focus();
                        document.getElementById("ddlAccountHead" + xLoop).style.borderColor = "red";
                        $("#divLedDeb" + xLoop + "> input").css("borderColor", "red");
                        ret = false;
                    }
                }


                var tblModuleGrp = document.getElementById("tblAccountGroup");
                var ModuleGrpId = "";
                var AccountGrpId = "";
                for (var i = 1; i < tblModuleGrp.rows.length; i++) {
                    var xLoop = (tblModuleGrp.rows[i].cells[0].innerHTML);
                    if (document.getElementById("ddlAccountGrp" + xLoop).value == "-Select Account Group-" || document.getElementById("ddlAccountGrp" + xLoop).value == "") {
                        document.getElementById("ddlAccountGrp" + xLoop).focus();
                        document.getElementById("ddlAccountGrp" + xLoop).style.borderColor = "red";
                        $("#divAcntDeb" + xLoop + " > input").css("borderColor", "red");
                        ret = false;
                    }
                }

                if (ret == false) {
                    $noCon1("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon1("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    $noCon1(window).scrollTop(0);
                }
                if (ret == true) {
                    if (flag == 0) {
                        $noCon1("#divWarning").html("Select current financial year.");
                        $noCon1("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });

                        $noCon1(window).scrollTop(0);
                        ret = false;
                    }
                }



                var ModuleGrpId = "";
                var AccountGrpId = "";
                for (var i = 1; i < tblModuleGrp.rows.length; i++) {
                    var xLoop = (tblModuleGrp.rows[i].cells[0].innerHTML);

                    if (tblModuleGrp.rows[i].cells[0].innerHTML != "") {
                        if (ModuleGrpId == "") {
                            ModuleGrpId = tblModuleGrp.rows[i].cells[0].innerHTML;
                        }
                        else {
                            ModuleGrpId = ModuleGrpId + "," + tblModuleGrp.rows[i].cells[0].innerHTML;
                        }
                    }
                }

                var ModuleHeadId = "";
                var LedgerId = "";
                for (var i = 1; i < tblModuleHead.rows.length; i++) {
                    var xLoop = (tblModuleHead.rows[i].cells[0].innerHTML);

                    if (tblModuleHead.rows[i].cells[0].innerHTML != "") {
                        if (ModuleHeadId == "") {
                            ModuleHeadId = tblModuleHead.rows[i].cells[0].innerHTML;
                        }
                        else {
                            ModuleHeadId = ModuleHeadId + "," + tblModuleHead.rows[i].cells[0].innerHTML;
                        }
                    }
                }

                var YearId = "";
                var Startdate = "";
                var enddate = "";
                var defaultname = "";
                var checked = "";
                for (var i = 1; i < tblFinacialYear.rows.length; i++) {
                    var xLoop = (tblFinacialYear.rows[i].cells[0].innerHTML);
                    if (tblFinacialYear.rows[i].cells[0].innerHTML != "") {
                        if (YearId == "") {
                            YearId = tblFinacialYear.rows[i].cells[0].innerHTML;
                        }
                        else {
                            YearId = YearId + "," + tblFinacialYear.rows[i].cells[0].innerHTML;
                        }
                    }
                    if (document.getElementById("cbxStatus" + xLoop).checked) {
                        checked = xLoop;
                    }

                }

                var VersioNId = "";
                for (var i = 1; i < tblPrintVersions.rows.length; i++) {
                    var xLoop = (tblPrintVersions.rows[i].cells[0].innerHTML);
                    if (tblPrintVersions.rows[i].cells[0].innerHTML != "") {
                        if (VersioNId == "") {
                            VersioNId = tblPrintVersions.rows[i].cells[0].innerHTML;
                        }
                        else {
                            VersioNId = VersioNId + "," + tblPrintVersions.rows[i].cells[0].innerHTML;
                        }
                    }
                }


                var $add = jQuery.noConflict();
                var client = JSON.stringify({
                    MODULEGROUPID: "" + ModuleGrpId + "",
                    MODULEHEADID: "" + ModuleHeadId + "",
                    FYID: "" + YearId + "",
                    CHECK: "" + checked + "",
                    VERSIONID: "" + VersioNId + "",
                    //   PRIMARYGRP: "" + PrimaryGrp + "",

                });
                tbClientTotalValues.push(client);
                document.getElementById("<%=HiddenFieldSaveAccount.ClientID%>").value = JSON.stringify(tbClientTotalValues);
                return ret;
            }
            function removeRowGrps(removeNum, CofirmMsg) {
                IncrmntConfrmCounter();
                //alert(removeNum);
                ezBSAlert({
                    type: "confirm",
                    messageText: CofirmMsg,
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {

                        var detailId = document.getElementById("tdDtlIdTempid" + removeNum).value;
                        var CanclIds = document.getElementById("cphMain_HiddenFYCnclId").value;
                        var CurrentFin = document.getElementById("tdCurrentFin" + removeNum).value;
                        if (CurrentFin == "1") {
                            FinancialYear();
                        }
                        else {
                            if (CanclIds == '') {
                                document.getElementById("cphMain_HiddenFYCnclId").value = detailId;
                            }
                            else {
                                document.getElementById("cphMain_HiddenFYCnclId").value = document.getElementById("cphMain_HiddenFYCnclId").value + ',' + detailId;
                            }
                            jQuery('#SubFYRowId_' + removeNum).remove();
                            var tblFinacialYear = document.getElementById("tableFinacialYear");
                            var TableRowCount = tblFinacialYear.rows.length;
                            if (TableRowCount <= 1) {
                                AddNewGroup();
                            }
                            else {
                                buttnVisibile();
                            }
                        }
                    }
                });
                return false;
            }
    </script>
  
<%--    <style>
        input[type="radio"] {
            display: table-cell;
        }
                      .inptxtDisable {
    width: 282px;
    background-color: #efefef;
    border: 1px solid #ccc;
    border-radius: 0px;
    font-family: OpenSans Regular;
    box-shadow: 0 1px 1px rgba(0, 0, 0, 0.075) inset;
    font-size: 14px;
    height: 30px;
    padding: 0 12px;
}
    </style>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <asp:HiddenField ID="HiddenPrimaryDetails" runat="server" />
    <asp:HiddenField ID="HiddenFieldSaveAccount" runat="server" />
    <asp:HiddenField ID="HiddenFinancialYear" runat="server" />
    <asp:HiddenField ID="HiddenFYCnclId" runat="server" />
    <asp:HiddenField ID="HiddenRestritionStatus" runat="server" />
    <asp:HiddenField ID="HiddenModuleCount" runat="server" />
    <asp:HiddenField ID="HiddenFinancialYrID" runat="server" />

    <ol class="breadcrumb sticky1">
         <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Account Setting</li>
    </ol>
    <!---alert_message_section---->
    <div class="myAlert-top alert alert-success" id="success-alert">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Success!</strong> Changes completed succesfully
    </div>

    <div class="myAlert-bottom alert alert-danger" id="divWarning">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Danger!</strong> Request not conmpleted
    </div>

    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">

            <div class="content_box1 cont_contr">

                <h1>
                    <asp:Label ID="lblEntry" runat="server"></asp:Label></h1>
                <div class="table_box tb_scr">
                    <h3>Primary Account Groups</h3>
                    <div id="divPrimaryAccntGrps" runat="server">
                    </div>
                </div>
                 <div class="sub_cont pull-right" >
                <div class="save_sec">
                <asp:Button ID="btnPrimaryDtlsSave" runat="server" OnClientClick="return ValidatePrimaryAccountGrp();" class="btn sub1" Text="Save" />
                    </div>
                     </div>

                <div class="clearfix"></div>
                <div class="devider divid"></div>

                <div class="table_box tb_scr">
                    <h3>Default Account Group</h3>
                    <div runat="server" id="ModuleGrp"></div>
                </div>

                <div class="clearfix"></div>
                <div class="devider divid"></div>
                <div class="table_box tb_scr">
                    <h3>Default Account Head</h3>
                    <div runat="server" id="HeadMap"></div>
                </div>
                <div class="clearfix"></div>
                <div class="devider divid"></div>

                <div class="table_box tb_scr">
                    <h3>Default Print Versions</h3>
                    <div runat="server" id="DivPrintVersion"></div>
                </div>
                <div class="clearfix"></div>
                <div class="devider divid"></div>


                <div class="table_box tb_scr">
                    <h3>Financial Year</h3>
                    <div runat="server" id="DivFinacialYear">
                        <table id="tableFinacialYear" class="table table-bordered">
                            <thead class="thead1">
                                <tr>
                                    <th class="col-md-3 tr_l">Start Year</th>
                                    <th class="col-md-3 tr_l">End Year</th>
                                    <th class="col-md-3 tr_l">Default Name</th>
                                    <th class="col-md-2">Current Financial Year</th>
                                    <th class="col-md-2">Actions</th>

                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
                <div class="sub_cont pull-right" >
                <div class="save_sec">
                    <asp:Button ID="btnsave" runat="server" OnClientClick="return ValidatAccountGrp();" OnClick="btnsave_Click" class="btn sub1" Text="Save" />
                </div>
                </div>
               
                <div class="clearfix"></div>
                <div class="devider divid"></div>
            </div>

        </div>
    </div>
</asp:Content>
