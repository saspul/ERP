<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_Accommodation_Master.aspx.cs" Inherits="Master_gen_Accommodation_Master_gen_Accommodation_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style>
        .fillform {
            width: 70%;
        }

        .subform {
            float: left;
            margin-left: 30.3%;
        }

        input[type="checkbox"][disabled="disabled"] {
            cursor: default !important;
        }

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
     <style>
        
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
         .select2-selection__choice {
             color:black !important;
         }
    </style>
    <script src="/JavaScript/jquery-1.8.3.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

     <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
     <script type="text/javascript">
         var $noCon = jQuery.noConflict();
         $noCon(window).load(function () {
             $noCon(".select2").select2(
                 {
                 });
             var data = document.getElementById("<%=HiddenFieldBu.ClientID%>").value;
             var totalString = data;
             var eachString = totalString.split(',');
             var newVar = new Array();
             for (count = 0; count < eachString.length; count++) {
                 if (eachString[count] != "") {
                     newVar.push(eachString[count]);
                     //alert(newVar);
                 }
             }
             $noCon('#cphMain_ddlBus').val(newVar);
             $noCon("#cphMain_ddlBus").trigger("change");
          });
          </script>
    <script type="text/javascript">
     
        var $au = jQuery.noConflict();

        function scrolltodiv() {
            $(document).scrollTo('#cphMain_divSubcatContainer');
        }

        (function ($au) {
            $au(function () {
                $au('#cphMain_ddlCoordinator').selectToAutocomplete1Letter();

                $au('form').submit(function () {

                    //   alert($au(this).serialize());


                    //   return false;
                });
            });
        })(jQuery);


        function DuplicationName() {

            document.getElementById('divMessageArea').style.display = "";
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.Accommodation Name Can’t be Duplicated.";
        }


        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Accommodation Details Inserted Successfully.";
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Accommodation Details Updated Successfully.";
        }
        function BlurNotNumber(obj) {

            var txt = document.getElementById(obj).value;

            if (txt != "") {

                if (isNaN(txt)) {
                    document.getElementById(obj).value = "";
                    document.getElementById(obj).focus();
                    return false;

                }
                else {
                    if (txt.indexOf(".") > 0) {
                        document.getElementById(obj).value = "";
                        document.getElementById(obj).focus();
                        return false;
                    }
                }
            }
        }
        function RemoveTag(obj) {
            var txt = document.getElementById(obj).value;
            if (txt != "") {

                //evm-0023 start
                replaceText1 = txt.replace(/</g, "");
                replaceText2 = replaceText1.replace(/>/g, "");

                replaceText3 = replaceText2.replace(/]/g, "");
                replaceText4 = replaceText3.replace(/\[/g, "");

                replaceText5 = replaceText4.replace(/}/g, "");
                replaceText6 = replaceText5.replace(/{/g, "");

                replaceText7 = replaceText6.replace(/,/g, "");
                replaceText8 = replaceText7.replace(/"/g, "");

                replaceText9 = replaceText8.replace(/\)/g, "");
                replaceText10 = replaceText9.replace(/\(/g, "");

                replaceText11 = replaceText10.replace(/\//g, "");
                replaceText12 = replaceText11.replace(/\\/g, "");

                document.getElementById(obj).value = replaceText12;
                //evm-0023 end
            }

        }
        function CompareNames(DisCount) {
            //comparing if rnd details are same values
            RemoveTag("txtName_" + DisCount);
            var tableNameCh = document.getElementById("tblPopContent");
            var newName = document.getElementById("txtName_" + DisCount).value;

            if (tableNameCh.rows.length >= 1) {
                for (var i = 1; i <= rowCountPop; i++) {

                    if (i != DisCount) {
                        ChDtlName = document.getElementById("txtName_" + i).value;
                        if (document.getElementById("txtName_" + DisCount).value != "" && document.getElementById("txtName_" + DisCount).value != null) {
                            if (ChDtlName == newName) {
                                alert("Sorry.It is already selected.");
                                document.getElementById("txtName_" + DisCount).value = "";
                            }
                        }

                    }
                }
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
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtName.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtAdrss.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAdrss.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtLocation.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtLocation.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtNoOfFloor.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtNoOfFloor.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtNoOfSubscribr.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtNoOfSubscribr.ClientID%>").value = replaceText2;

            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAdrss.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlAccmdtnType.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtNoOfFloor.ClientID%>").style.borderColor = "";

            $au("div#divMessContainer input.ui-autocomplete-input").css("borderColor", ""); //evm-0023

            document.getElementById("<%=txtNoOfSubscribr.ClientID%>").style.borderColor = "";
            var Name = document.getElementById("<%=txtName.ClientID%>").value.trim();
            var DropdownAccmdtnType = document.getElementById("<%=ddlAccmdtnType.ClientID%>");
            var SelectedValueAccmdtnType = DropdownAccmdtnType.value;
            var NumFloor = document.getElementById("<%=txtNoOfFloor.ClientID%>").value.trim();
            var Coordinator = document.getElementById("<%=ddlCoordinator.ClientID%>").value;
            var Subscriber = document.getElementById("<%=txtNoOfSubscribr.ClientID%>").value.trim();
            document.getElementById('divMessageArea').style.display = "none";
            document.getElementById('imgMessageArea').src = "";
            //evm-0023  change "--SELECT TYPE--" to "--SELECT CATEGORY--" in if condition
            if (Name == "" || SelectedValueAccmdtnType == "--SELECT CATEGORY--" || NumFloor == "" || Coordinator == "--SELECT COORDINATOR--" || Subscriber=="") {

                if (NumFloor == "") {
                    document.getElementById("<%=txtNoOfFloor.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtNoOfFloor.ClientID%>").focus();
                    ret = false;
                }

                if (SelectedValueAccmdtnType == "--SELECT CATEGORY--") {
                    document.getElementById("<%=ddlAccmdtnType.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddlAccmdtnType.ClientID%>").focus();
                    ret = false;

                }

                if (document.getElementById("<%=cbxHaveMess.ClientID%>").checked == true) {

                    //evm-0023 start
                    if (Coordinator == "--SELECT COORDINATOR--" || Subscriber == "") {

                        if (Subscriber == "") {
                            document.getElementById("<%=txtNoOfSubscribr.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtNoOfSubscribr.ClientID%>").focus();
                            ret = false;
                        }
                        if (Coordinator == "--SELECT COORDINATOR--") {
                            $au("div#divMessContainer input.ui-autocomplete-input").css("borderColor", "red");
                            $au("div#divMessContainer input.ui-autocomplete-input").focus();
                            $au("div#divMessContainer input.ui-autocomplete-input").select();
                            ret = false;
                        }                      
                    }
                    //evm-0023 end
                }

                if (Name == "") {

                    document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtName.ClientID%>").focus();
                    ret = false;
                }

            }



            if (ret == false) {
                CheckSubmitZero();

            }
            document.getElementById("<%=HiddenFieldBu.ClientID%>").value = $('#cphMain_ddlBus').val();
            return ret;
        }
    </script>

    <script type="text/javascript">
        var submit = 0;
        function CheckIsRepeat() {
            if (++submit > 1) {
                // alert('An attempt was made to submit this form more than once; this extra attempt will be ignored.');
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
        //start-0006
        var Counterbox = 0;
        function IncrmntCounterbox() {
            Counterbox++;
        }
        function InitializeCounterbox() {
            Counterbox = 0;
        }
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        function ConfirmMessage() {
            if (confirmbox > 0) {
                if (confirm("Are You Sure You Want To Leave This Page?")) {
                    window.location.href = "gen_Accommodation_Master_List.aspx";
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_Accommodation_Master_List.aspx";

            }
        }
        function AlertClearAll() {
            if (confirmbox > 0) {
                if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                    window.location.href = "gen_Accommodation_Master.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_Accommodation_Master.aspx";
                return false;
            }
        }

        //stop-0006
    </script>

    <script type="text/javascript">
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

        function DontDisplayPopUp() {
            var AccOId = document.getElementById("<%=hiddenAccomodationId.ClientID%>").value;
            if (AccOId != "") {
                alert("Please upadte the accomodation to continue.");
            } else {
                alert("Please save the accomodation to continue.");
            }

        }
        function showhide() {
            if (document.getElementById) {
                var divid = document.getElementById('divMessContainer');

                if (document.getElementById('cphMain_cbxHaveMess').checked == false) {

                    $(divid).animate({ height: 0 }, "slow");
                    $(divid).hide(10);
                }
                else {
                    $(divid).show(10);
                    $(divid).animate({ height: 102 }, "slow");

                }
            }
            return false;
        }

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            if (document.getElementById) {
                document.getElementById('divMessContainer');

                if (document.getElementById('cphMain_cbxHaveMess').checked == false) {


                    document.getElementById('divMessContainer').style.display = "none";
                }
                else {
                    document.getElementById('divMessContainer').style.display = "";

                }
            }

            if (document.getElementById("<%=hiddenViewTrue.ClientID%>").value == "1") {
                document.getElementById("<%=txtNoOfFloor.ClientID%>").disabled = true;
            } else {
                document.getElementById("<%=txtNoOfFloor.ClientID%>").disabled = false;
            }
            document.getElementById("<%=txtNoOfFloor.ClientID%>").value = document.getElementById("<%=hiddenNo_Of_Flr.ClientID%>").value;
            ddlCatChangeLoad();
            if (document.getElementById("<%=hiddenViewTrue.ClientID%>").value == "1") {
                document.getElementById("<%=divSubcatContainer.ClientID%>").style.pointerEvents = "none";
            }
        });

        var $noconfi = jQuery.noConflict();
        function ddlCatChange() {
            IncrmntConfrmCounter();
            var AccOId = document.getElementById("<%=hiddenAccomodationId.ClientID%>").value;
            var divid = document.getElementById('cphMain_divSubcatContainer');

            var CatId = document.getElementById("<%=ddlAccmdtnType.ClientID%>").value;
            if (AccOId != "") {
                if (confirm("Are you sure?. The accommodation premises data may lost.")) {

                    if (CatId != "--SELECT CATEGORY--") {

                        $noconfi.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "gen_Accommodation_Master.aspx/SubCategoryLoad",
                            data: '{strCatId: "' + CatId + '",strAccoId: "' + 0 + '"}',
                            dataType: "json",
                            success: function (data) {
                                document.getElementById('cphMain_divSubcatContainer').innerHTML = data.d[0];

                                if (data.d[1] == "false") {

                                    document.getElementById("<%=txtNoOfFloor.ClientID%>").disabled = true;

                                }
                                else {
                                    if (document.getElementById("<%=hiddenViewTrue.ClientID%>").value != "1") {
                                        document.getElementById("<%=txtNoOfFloor.ClientID%>").disabled = false;
                                    }
                                }

                            }
                        });
                        $(divid).show(1);
                        //$(divid).animate({ height: 253 }, "slow");
                    }
                    else {

                        //$(divid).animate({ height: 0 }, "slow");
                        $(divid).hide(10);
                    }

                }
                else {


                }
            }
            else {

                if (CatId != "--SELECT CATEGORY--") {

                    $noconfi.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "gen_Accommodation_Master.aspx/SubCategoryLoad",
                        data: '{strCatId: "' + CatId + '",strAccoId: "' + 0 + '"}',
                        dataType: "json",
                        success: function (data) {
                            document.getElementById('cphMain_divSubcatContainer').innerHTML = data.d[0];

                            if (data.d[1] == "false") {
                                document.getElementById("<%=txtNoOfFloor.ClientID%>").disabled = true;
                            }
                            else {
                                if (document.getElementById("<%=hiddenViewTrue.ClientID%>").value != "1") {

                                    document.getElementById("<%=txtNoOfFloor.ClientID%>").disabled = false;
                                }
                            }

                        }
                    });
                    $(divid).show(1);
                    //$(divid).animate({ height: 253 }, "slow");
                }
                else {

                    //$(divid).animate({ height: 0 }, "slow");
                    $(divid).hide(10);
                }
            }
        }

        function ddlCatChangeLoad() {
            var AccOId = document.getElementById("<%=hiddenAccomodationId.ClientID%>").value;
            var divid = document.getElementById('cphMain_divSubcatContainer');

            var CatId = document.getElementById("<%=ddlAccmdtnType.ClientID%>").value;
            if (AccOId != "") {
                if (CatId != "--SELECT CATEGORY--") {
                    //$(divid).hide(10);
                    // $(divid).animate({ height: 0 }, "slow");

                    $noconfi.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "gen_Accommodation_Master.aspx/SubCategoryLoad",
                        data: '{strCatId: "' + CatId + '",strAccoId: "' + AccOId + '"}',
                        dataType: "json",
                        success: function (data) {
                            document.getElementById('cphMain_divSubcatContainer').innerHTML = data.d[0];

                            if (data.d[1] == "false") {
                                document.getElementById("<%=txtNoOfFloor.ClientID%>").disabled = true;
                            }
                            else {
                                if (document.getElementById("<%=hiddenViewTrue.ClientID%>").value != "1") {

                                    document.getElementById("<%=txtNoOfFloor.ClientID%>").disabled = false;
                                }
                            }

                        }
                    });
                    $(divid).show(1);
                    //$(divid).animate({ height: 253 }, "slow");
                }
                else {

                    //$(divid).animate({ height: 0 }, "slow");
                    $(divid).hide(10);
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="cont_rght">
        <asp:HiddenField ID="hiddenTotalData" runat="server" />
        <asp:HiddenField ID="hiddenAccomodationId" runat="server" />
        <asp:HiddenField ID="hiddenDeletedDetail" runat="server" />
        <asp:HiddenField ID="hiddenNo_Of_Flr" runat="server" />
        <asp:HiddenField ID="hiddenViewTrue" runat="server" />
        <asp:HiddenField ID="HiddenFieldBu" runat="server" />        
        <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

        <br />

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 1%; top: 42%; height: 26.5px;">
        </div>

        <div class="fillform" style="width: 100%">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
            <br />
            <div style="float: left;">
                <div class="eachform" style="float: left; margin-left: 2%; width: 49%;">
                    <h2>Name*</h2>
                      <%--  EVM-0027 09-02-2019 autocomplete--%>
                    <asp:TextBox ID="txtName" autocomplete="off" TabIndex="1" class="form1" runat="server" MaxLength="100" TextMode="SingleLine" Style="height: 30px; width: 300px; resize: none; text-transform: uppercase; font-family: calibri; float: right; margin-right: 10%;"></asp:TextBox>

                </div>
                <div style="float: right; margin-right: 0%; width: 49%; height: 150px;">
                    <div class="eachform" style="margin-bottom: 0px; margin-left: 1%;">

                        <div class="subform" style="margin-left: 9.3%; float: left;">
                            <asp:CheckBox ID="cbxHaveMess" TabIndex="2" Text="" onclick="showhide();" runat="server" Checked="true" class="form2" />

                            <label for="cphMain_cbxHaveMess" style="font-size: 19px; color: #004b0e; margin-top: -2px; cursor: pointer; font-family: Calibri">Have a mess enabled</label>

                        </div>
                    </div>



                    <div id="divMessContainer" style="width: 95%; margin-left: 5%; border: 1px solid #cbc0c0; background-color: #f4f6f0; margin-bottom: 10px; display: block; height: 100px;">
                        <div class="eachform" style="width: 91%; margin-left: 3%; margin-top: 2%;">
                            <h2>Coordinator*</h2>

                            <asp:DropDownList ID="ddlCoordinator" TabIndex="3" class="form1" runat="server" Style="height: 30px; width: 308px; margin-left: 7%; text-align: left; float: left"></asp:DropDownList>
                        </div>
                        <div class="eachform" style="width: 91%; margin-left: 3%; margin-top: 0%">
                            <h2 style="width: 16%;">Number Of Subscribers*</h2>
                          <%--  EVM-0027 09-02-2019 autocomplete--%>
                            <asp:TextBox ID="txtNoOfSubscribr" autocomplete="off" TabIndex="4" class="form1" runat="server" MaxLength="6" onkeydown="return isNumber(event);" onblur="return BlurNotNumber('cphMain_txtNoOfSubscribr');" TextMode="SingleLine" Style="resize: none; text-transform: uppercase; font-family: calibri; float: right; margin-right: 47%; width: 24%;"></asp:TextBox>

                        </div>
                    </div>


                    <div class="eachform" style="width: 87%; margin-left: 7%; margin-top: 3%">
                        <h2>Location</h2>
                        <asp:TextBox ID="txtLocation" TabIndex="6" class="form1" runat="server" MaxLength="100" TextMode="SingleLine" Style="height: 30px; width: 300px; resize: none; text-transform: uppercase; font-family: calibri; float: right; margin-right: 10%;"></asp:TextBox>
                    </div>
                    <div class="eachform" style="float: left; width: 87%; margin-left: 7%;">
                        <h2>Status*</h2>
                        <div class="subform" style="margin-left: 16.3%; float: left;">
                            <asp:CheckBox ID="cbxStatus" TabIndex="8" Text="" runat="server" Checked="true" class="form2" />

                            <h3>Active</h3>

                        </div>
                    </div>

                         <div class="eachform" style="width: 87%; margin-left: 7%; margin-top: 1%">
                    <h2 style="width:27%;">Business Unit</h2>                                   
                     <asp:DropDownList ID="ddlBus" onchange="IncrmntConfrmCounter();"  Width="62%"  data-placeholder="select business unit"  multiple="multiple" class="form1 select2" runat="server"  onkeypress="return DisableEnter(event)" Style="cursor: pointer;margin-left:5%;"></asp:DropDownList>                               
                </div>

                </div>
                <div class="eachform" style="float: left; width: 49%; margin-left: 2%;">
                    <h2>Category*</h2>

                    <asp:DropDownList ID="ddlAccmdtnType" TabIndex="5" class="form1" onchange="ddlCatChange();" runat="server" Style="height: 30px; width: 318px; float: right; margin-right: 10%;"></asp:DropDownList>

                </div>
                <div class="eachform" style="float: left; width: 49%; margin-left: 2%;">
                    <h2>Number Of Floors*</h2>
                      <%--  EVM-0027 09-02-2019 autocomplete--%>
                    <asp:TextBox ID="txtNoOfFloor" autocomplete="off" TabIndex="7" class="form1" runat="server" MaxLength="3" onkeydown="return isNumber(event);" onblur="return BlurNotNumber('cphMain_txtNoOfFloor');" TextMode="SingleLine" Style="resize: none; text-transform: uppercase; font-family: calibri; float: right; margin-right: 37.5%; width: 24%;"></asp:TextBox>

                </div>
                <div class="eachform" style="float: left; width: 49%; margin-left: 2%;">
                    <h2>Address</h2>

                    <asp:TextBox ID="txtAdrss" TabIndex="9" class="form1" runat="server" MaxLength="500" TextMode="MultiLine" Style="height: 115px; width: 300px; resize: none; font-family: calibri; float: right; margin-right: 10%;" onkeydown="textCounter(cphMain_txtAdrss,450)" onkeyup="textCounter(cphMain_txtAdrss,450)"></asp:TextBox>

                </div>

            
            




                <div class="eachform" style="margin-top: 4%;">
                    <div class="subform" style="width: 80%;">

                        <asp:Button ID="btnUpdate" runat="server" TabIndex="10" class="save" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnUpdateClose" TabIndex="11" runat="server" class="save" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnAdd" runat="server" TabIndex="12" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                        <asp:Button ID="btnAddClose" runat="server" TabIndex="13" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                        <asp:Button ID="btnCancel" runat="server" TabIndex="14" class="cancel" Text="Cancel" PostBackUrl="gen_Accommodation_Master_List.aspx" />
                        <asp:Button ID="btnClear" runat="server" TabIndex="15" Style="margin-left: 19px;" OnClientClick="return AlertClearAll();" class="cancel" Text="Clear" />
                    </div>
                </div>


            </div>
            <h2 style="font-weight: 700; font-size: 17px; color: #688375; margin-top: 1%;">Accommodation Premises*</h2>
            <div style="float: left; width: 100%; min-height: 257px; background-color: #f4f6f0; border: 1px solid #cbc0c0; padding: 5px; margin-bottom: 15%;">
                <div style="float: left; width: 100%;">
                    <div id="divSubCatError" style="visibility: hidden; font-family: Calibri; float: left; width: 60%;">
                        <asp:Label ID="lblSubCatError" runat="server" Style="width: 99%; float: left; text-align: center; color: #438943; border: 2px solid;"></asp:Label>
                    </div>
                    <div id="divSubcatContainer" runat="server" style="width: 60%; float: left;">
                        <h3 style="color: #b6b6b6; font-size: 16px;">Please save the accomodation to continue...</h3>


                    </div>
                </div>

            </div>

            <br />



        </div>
    </div>

    <!-- The Modal ErrorReason -->
    <div id="myModalPopUp" class="modalPopUp">
        <img src="/Images/Icons/left-arrow.png" style="float: left; margin-top: 6px;" />
        <!-- Modal content -->
        <div class="modal-contentPopUp">

            <div class="modal-bodyPopUp">
                <div id="divErrorRsnPopUp" style="visibility: hidden; font-family: Calibri;">
                    <asp:Label ID="lblErrorRsnPopUp" runat="server"></asp:Label>
                </div>
                <div style="font-family: Calibri;">
                    <table style="width: 100%">
                        <thead>
                            <tr>
                                <td class="HeadRow1">Premises Name </td>
                                <td class="HeadRow2">Floor </td>
                                <td style="width: 5%; visibility: hidden"></td>
                                <td style="width: 5%; visibility: hidden"></td>
                            </tr>
                        </thead>
                    </table>
                    <table id="tblPopContent" style="width: 100%">
                    </table>

                </div>

            </div>

            <div class="modal-footerPopUp">
                <div style="margin-top: 1%">
                    <asp:Button ID="btnPopSave" runat="server" Style="margin-left: 26%; width: 76px; border: 1px solid #0e9090; padding: 2px" OnClientClick="return SaveSubCatDetail()" OnClick="btnPopSave_Click" Text="save" />
                    <input id="btnPopCancel" onclick="return HidePopUp();" style="width: 76px; margin-left: 10%; border: 1px solid #0e9090; padding: 2px" value="cancel" type="button" />
                </div>
            </div>
        </div>

    </div>

    <script>
        var $nobn = jQuery.noConflict();
        function DetailsaveSucess() {
            document.getElementById('divSubCatError').style.visibility = "visible";
            document.getElementById("<%=lblSubCatError.ClientID%>").innerHTML = "Details Added Sucessfully.";
            $nobn('html,body').animate({
                scrollTop: $nobn("#cphMain_divSubcatContainer").offset().top
            }, 'slow');
        }


        var rowCountPop = 0;

        function InitializePop() {
            rowCountPop = 0;
        }
        function AddEachRow(DtlId) {
            rowCountPop++;
            var recRow = '<tr id="rowId_' + rowCountPop + '" style=\"font-size: 14px;font-family: calibri;\" >';

             <%--  EVM-0027 09-02-2019 autocomplete--%>
            recRow += ' <td class="OtherRow1"><input type="text" autocomplete="off"  id=\"txtName_' + rowCountPop + '\" maxlength=\"99\" onblur=\"return CompareNames(' + rowCountPop + ');\" onchange=\"IncrmntCounterbox()\" onkeyDown=\"return DisableEnter(event)\" onkeypress=\"return isTag(event)\" placeholder="Enter Name" style=\"width: 97%;\"/> </td>';
            recRow += '<td class="OtherRow2"><select id=\"ddlFloor_' + rowCountPop + '\" style=\"width: 97%;\" onchange=\"ddlFloorChange(' + rowCountPop + ')\"></select> </td>';
            recRow += '<td id=\"tdAdd_' + rowCountPop + '\" style=\"width:5%\"><input type=\"image\" id=\"ImgAdd_' + rowCountPop + '\" onclick=\"return CheckAddEachRow(' + DtlId + ',' + rowCountPop + ');\" src=\"/Images/Icons/addFile.png\" style=\"width: 100%;margin-top:15%;cursor:pointer;\"/></td>';
            recRow += '<td id=\"tdDel_' + rowCountPop + '\" style=\"width:5%\"> <input type=\"image\" onclick=\"return CheckDelEachRow(' + rowCountPop + ');\" src=\"/Images/Icons/deleteEntry.png\"  style=\"width: 100%;margin-top: 15%;cursor:pointer;\"/></td>';
            recRow += '<td id=\"tdDtlId_' + rowCountPop + '\" style="display: none;" />' + DtlId + '</td>';
            recRow += '<td id=\"tdEvent_' + rowCountPop + '\" style="display: none;" /></td>';
            recRow += '<td id=\"tdSubDtl_' + rowCountPop + '\" style="display: none;" /></td>';
            recRow += '</tr>';

            jQuery('#tblPopContent').append(recRow);

            FillFloorDropDown(rowCountPop);
            //EVM-0027 09-02-2019
            document.getElementById("txtName_" + rowCountPop).focus();
            //END
            //txtName_3
            document.getElementById("tdDtlId_" + rowCountPop).innerHTML = DtlId;
            document.getElementById("tdEvent_" + rowCountPop).innerHTML = "INS";
            return false;

        }

        function EditEachRow(SubDtlId, SubId, SubName, SubFloor, SubId_Del_Chk) {

            rowCountPop++;
            var recRow = '<tr id="rowId_' + rowCountPop + '" style=\"font-size: 14px;font-family: calibri;\" >';
              <%--  EVM-0027 09-02-2019 autocomplete--%>
            recRow += ' <td class="OtherRow1"><input type="text"  autocomplete = "off" id=\"txtName_' + rowCountPop + '\" maxlength=\"99\" onchange=\"IncrmntCounterbox()\" onblur=\"return RemoveTag(\'txtName_' + rowCountPop + '\');\" onkeyDown=\"return DisableEnter(event)\" onkeypress=\"return isTag(event)\" placeholder="Enter Name" style=\"width: 97%;\"/> </td>';
            recRow += '<td class="OtherRow2"><select id=\"ddlFloor_' + rowCountPop + '\" style=\"width: 97%;\" onchange=\"ddlFloorChange(' + rowCountPop + ')\"></select> </td>';
            recRow += '<td id=\"tdAdd_' + rowCountPop + '\" style=\"width:5%\"><input type=\"image\" id=\"ImgAdd_' + rowCountPop + '\" onclick=\"return CheckAddEachRow(' + SubId + ',' + rowCountPop + ');\" src=\"/Images/Icons/addFile.png\" style=\"width: 100%;margin-top:15%;cursor:pointer;\"/></td>';
            if (SubId_Del_Chk != "" && SubId_Del_Chk != null) {
                recRow += '<td id=\"tdDel_' + rowCountPop + '\" style=\"width:5%;opacity: 0.3;\"> <input type=\"image\" disabled src=\"/Images/Icons/deleteEntry.png\"  style=\"width: 100%;margin-top: 15%;cursor:pointer;\"/></td>';
            }
            else {
                recRow += '<td id=\"tdDel_' + rowCountPop + '\" style=\"width:5%\"> <input type=\"image\" onclick=\"return CheckDelEachRow(' + rowCountPop + ');\" src=\"/Images/Icons/deleteEntry.png\"  style=\"width: 100%;margin-top: 15%;cursor:pointer;\"/></td>';
            }
            recRow += '<td id=\"tdDtlId_' + rowCountPop + '\" style="display: none;" />' + SubId + '</td>';
            recRow += '<td id=\"tdEvent_' + rowCountPop + '\" style="display: none;" /></td>';
            recRow += '<td id=\"tdSubDtl_' + rowCountPop + '\" style="display: none;" /></td>';
            recRow += '</tr>';

            jQuery('#tblPopContent').append(recRow);
            FillFloorDropDown(rowCountPop);
            document.getElementById("tdDtlId_" + rowCountPop).innerHTML = SubId;
            document.getElementById("tdSubDtl_" + rowCountPop).innerHTML = SubDtlId;
            document.getElementById("tdEvent_" + rowCountPop).innerHTML = "UPD";
            document.getElementById("txtName_" + rowCountPop).value = SubName;
            document.getElementById("ddlFloor_" + rowCountPop).value = SubFloor;          
            return false;

        }

        var $noconfli = jQuery.noConflict();
        function CheckAddEachRow(DtlId,RowCount)
        {
            IncrmntConfrmCounter();

            document.getElementById("txtName_" + RowCount).style.borderColor = "";
            document.getElementById("ddlFloor_" + RowCount).style.borderColor = "";

            if (document.getElementById("txtName_" + RowCount).value == "" || document.getElementById("ddlFloor_" + RowCount).value == "--SELECT--") {
                if (document.getElementById("ddlFloor_" + RowCount).value == "--SELECT--") {
                    document.getElementById("ddlFloor_" + RowCount).focus();
                    document.getElementById("ddlFloor_" + RowCount).style.borderColor = "red";
                }
                if (document.getElementById("txtName_" + RowCount).value == "") {
                    document.getElementById("txtName_" + RowCount).focus();
                    document.getElementById("txtName_" + RowCount).style.borderColor = "red";
                }
                return false;
            }

            AddEachRow(DtlId);
            for (var DisCount = 1; DisCount < rowCountPop; DisCount++) {
                var AddButton = $noconfli("#tdAdd_" + DisCount);
                if (AddButton.length) {


                    document.getElementById("ImgAdd_" + DisCount).disabled = true;
                    document.getElementById("tdAdd_" + DisCount).style.opacity = "0.3";
                    
                }
            }
            return false;
        }

        function ddlFloorChange(RowCount) {
            IncrmntCounterbox();
            IncrmntConfrmCounter();
            return true;


            for (var DisCount = 1; DisCount <= rowCountPop; DisCount++) {
                var AddButton = $noconfli("#ddlFloor_" + DisCount);
                if (AddButton.length) {
                    if (RowCount != DisCount) {
                        if (document.getElementById("ddlFloor_" + RowCount).value == document.getElementById("ddlFloor_" + DisCount).value) {
                            alert("Sorry.It is already selected.");
                            document.getElementById("ddlFloor_" + RowCount).value = "--SELECT--";
                        }
                    }
                }
            }
        }
        function CheckDelEachRow(Delrowcount) {
            if (confirm("Are you sure?. You want to remove.")) {
                IncrmntConfrmCounter();
                AddDeleted(Delrowcount);
                jQuery('#rowId_' + Delrowcount).remove();
                for (var EnCount = rowCountPop; EnCount > 0; EnCount--) {
                    var AddButton = $noconfli("#tdAdd_" + EnCount);
                    if (AddButton.length) {
                        document.getElementById("ImgAdd_" + EnCount).disabled = false;
                        document.getElementById("tdAdd_" + EnCount).style.opacity = "1";
                        break;
                    }

                }
            }
            return false;
        }

        function AddDeleted(Delrowcount) {
            IncrmntConfrmCounter();
            if (document.getElementById("tdEvent_" + Delrowcount).innerHTML == "UPD") {
                var detailId = document.getElementById("<%=hiddenDeletedDetail.ClientID%>").value;
                detailId = detailId + "," + document.getElementById("tdSubDtl_" + Delrowcount).innerHTML;
                document.getElementById("<%=hiddenDeletedDetail.ClientID%>").value = detailId;
            }

        }
        var $noCon = jQuery.noConflict();
        function FillFloorDropDown(ddlCount) {

            var ddlFloorDropDownListXML = $noCon("#ddlFloor_" + ddlCount);
            var OptionStart = $noCon("<option>--SELECT--</option>");

            ddlFloorDropDownListXML.append(OptionStart);
            var TotCount = document.getElementById('cphMain_txtNoOfFloor').value;
            if (TotCount > 0) {
                for (var counts = 0; counts < TotCount; counts++) {

                   // samcounts = ordinalInWord(counts) +" Floor";

                    var option = $noCon("<option>" + counts + "</option>");
                    option.attr("value", counts);
                    ddlFloorDropDownListXML.append(option);
                }
            }

        }


        //function ordinalInWord(cardinal) {
        //    var ordinals = ['Ground', 'First', 'Second', 'Third', 'Fourth', 'Fifth', 'Sixth', 'Seventh', 'Eighth', 'Ninth', 'Tenth', 'Eleventh', 'Twelveth', 'Thirteenth', 'Fourteenth', 'Fifteenth', 'Sixteenth', 'Seventeenth', 'Eighteenth', 'Nineteenth', 'Twentieth'
        //    ];
        //    var tens = {
        //        20: 'Twenty',
        //        30: 'Thirty',
        //        40: 'Fourty', /* and so on */
        //        50: 'Fifty',
        //        60: 'Sixty',
        //        70: 'Seventy',
        //        80: 'Seventy',
        //        90: 'Ninty'
        //    };
        //    var ordinalTens = {
        //        30: 'Thirtieth',
        //        40: 'Fourtieth',
        //        50: 'Fiftieth',
        //        60: 'Sixtieth',
        //        70: 'Seventieth',
        //        80: 'Eightieth',
        //        90: 'Ninetieth',
        //    };

        //    if (cardinal <= 20) {
        //        return ordinals[cardinal];
        //    }

        //    if (cardinal % 10 === 0) {
        //        return ordinalTens[cardinal];
        //    }

        //    return tens[cardinal - (cardinal % 10)] + ordinals[cardinal % 10];
        //}



        function HidePopUp() {
            if (Counterbox > 0) {
                if (confirm("Are you sure?.You want to close.")) {
                    document.getElementById('myModalPopUp').style.display = "none";
                    InitializeCounterbox();
                }
                else {
                    return false;
                }
            }
            else {
                document.getElementById('myModalPopUp').style.display = "none";
                InitializeCounterbox();
                return false;
            }
        }

        var $MRD = jQuery.noConflict();
        function DisplayPopUp(objId, DtlId) {
            IncrmntConfrmCounter();
            if (Counterbox > 0) {
                if (confirm("Are you sure?.You want to close the current window.")) {
                    InitializeCounterbox();
                    var TotCount = document.getElementById('cphMain_txtNoOfFloor').value;
                    if (TotCount > 0) {
                        InitializePop();
                        jQuery('#tblPopContent tr').remove();
                        LoadAddedSucatDetail(DtlId);


                        localStorage.clear();
                        document.getElementById("<%=hiddenDeletedDetail.ClientID%>").value = "";
                        document.getElementById('divSubCatError').style.visibility = "hidden";
                        document.getElementById('myModalPopUp').style.display = "none";
                        if (document.getElementById('myModalPopUp').style.display == "" || document.getElementById('myModalPopUp').style.display == "none") {

                            var offset = $MRD("#" + objId).offset();
                            var posY = 0;
                            var posX = 0;
                            posY = offset.top - 205;

                            posX = offset.left;

                            posX = 1.5;

                            $MRD("#myModalPopUp").show(10);
                            var d = document.getElementById('myModalPopUp');
                            d.style.position = "absolute";
                            d.style.left = posX + '%';
                            d.style.top = posY + 'px';

                            //var div = $MRD("#myModalPopUp");
                            //div.animate({ top: '+=30px' }, "slow");


                        }
                        else {
                            // document.getElementById("freezelayer").style.display = "none";
                            var div = $MRD("#cphMain_divReopenDescription");
                            //   div.animate({ left: '+=35%' }, "slow");
                            div.animate({ top: '-=30px' }, "slow");
                            $MRD("#cphMain_divReopenDescription").hide(500);

                        }
                        return false;


                    }
                    else {
                        document.getElementById('divSubCatError').style.visibility = "visible";
                        document.getElementById("<%=lblSubCatError.ClientID%>").innerHTML = "No.of floor should be greater than zero.";
                        document.getElementById('cphMain_txtNoOfFloor').style.borderColor = "red";

                    }
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
             

                var TotCount = document.getElementById('cphMain_txtNoOfFloor').value;
                if (TotCount > 0) {
                    InitializePop();
                    jQuery('#tblPopContent tr').remove();

                    //alert(DtlId);
                    LoadAddedSucatDetail(DtlId);


                    localStorage.clear();
                    document.getElementById("<%=hiddenDeletedDetail.ClientID%>").value = "";
                    document.getElementById('divSubCatError').style.visibility = "hidden";
                    document.getElementById('myModalPopUp').style.display = "none";
                    if (document.getElementById('myModalPopUp').style.display == "" || document.getElementById('myModalPopUp').style.display == "none") {                       
                        var offset = $MRD("#" + objId).offset();
                        var posY = 0;
                        var posX = 0;
                        posY = offset.top - 205;

                        posX = offset.left;

                        posX = 1.5;

                        $MRD("#myModalPopUp").show(10);
                        var d = document.getElementById('myModalPopUp');
                        d.style.position = "absolute";
                        d.style.left = posX + '%';
                        d.style.top = posY + 'px';

                        //var div = $MRD("#myModalPopUp");
                        //div.animate({ top: '+=30px' }, "slow");
                     //   document.getElementById("txtName_1").focus();                        

                    }
                    else {
                        // document.getElementById("freezelayer").style.display = "none";
                        var div = $MRD("#cphMain_divReopenDescription");
                        //   div.animate({ left: '+=35%' }, "slow");
                        div.animate({ top: '-=30px' }, "slow");
                        $MRD("#cphMain_divReopenDescription").hide(500);

                    }
                    return false;


                }
                else {
                    document.getElementById('divSubCatError').style.visibility = "visible";
                    document.getElementById("<%=lblSubCatError.ClientID%>").innerHTML = "No.of floor should be greater than zero.";
                     document.getElementById('cphMain_txtNoOfFloor').style.borderColor = "red";
                     return false;
                 }
             }
         }

         function CloseReopenDescription() {
             var div = $MRD("#cphMain_divReopenDescription");
             //   div.animate({ left: '+=35%' }, "slow");
             div.animate({ top: '-=30px' }, "slow");
             $MRD("#cphMain_divReopenDescription").hide(500);

             return false;
         }
         var $noconflit = jQuery.noConflict();
         function SaveSubCatDetail() {
             var ret = true;
             //var strCount=[];
             for (var DisCount = 1; DisCount <= rowCountPop; DisCount++) {

                 var txtBox = $noconflit("#txtName_" + DisCount);
                 var ddlFlr = $noconflit("#ddlFloor_" + DisCount);
                 if (txtBox.length) {

                     var txtName = document.getElementById('txtName_' + DisCount).value.trim();
                     var ddlFlrVal = document.getElementById('ddlFloor_' + DisCount).value;
                     if (txtName != "") {
                         document.getElementById('txtName_' + DisCount).style.borderColor = "";
                     } else {
                         document.getElementById('txtName_' + DisCount).style.borderColor = "red";
                         ret = false;
                     }

                     if (ddlFlrVal != "--SELECT--") {
                         document.getElementById('ddlFloor_' + DisCount).style.borderColor = "";
                     }
                     else {
                         document.getElementById('ddlFloor_' + DisCount).style.borderColor = "red";
                         ret = false;
                     }

                 }
             }
             if (ret == true) {
                 var tbClientTotalValues = '';
                 tbClientTotalValues = [];

                 for (var DisCount = 1; DisCount <= rowCountPop; DisCount++) {

                     var txtBox = $noconflit("#txtName_" + DisCount);
                     var ddlFlr = $noconflit("#ddlFloor_" + DisCount);
                     if (txtBox.length) {
                         var txtName = document.getElementById('txtName_' + DisCount).value;
                         var ddlFlrVal = document.getElementById('ddlFloor_' + DisCount).value;
                         var DetailId = document.getElementById('tdDtlId_' + DisCount).innerHTML;
                         var SubDetailId = document.getElementById('tdSubDtl_' + DisCount).innerHTML;
                         var EventAction = document.getElementById('tdEvent_' + DisCount).innerHTML;
                         var client = JSON.stringify({
                             ROWID: "" + DisCount + "",
                             NAME: "" + txtName + "",
                             FLOOR: ddlFlrVal,
                             DETAILID: "" + DetailId + "",
                             SUBDTLID: "" + SubDetailId + "",
                             EVENTNAME: "" + EventAction + "",
                         });

                         tbClientTotalValues.push(client);
                     }
                 }

                 document.getElementById("<%=hiddenTotalData.ClientID%>").value = JSON.stringify(tbClientTotalValues);


             }

             return ret;
         }
         var $NonConfli = jQuery.noConflict();
         function LoadAddedSucatDetail(DtlId) {
             var AccoId = document.getElementById("<%=hiddenAccomodationId.ClientID%>").value;
             $NonConfli.ajax({
                 type: "POST",
                 async: false,
                 contentType: "application/json; charset=utf-8",
                 url: "gen_Accommodation_Master.aspx/ReadSuCatDetail",
                 data: '{intAccId: "' + AccoId + '",intSubCatId:"' + DtlId + '"}',
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
                         var json = $NonConfli.parseJSON(res3);


                         for (var key in json) {
                             if (json.hasOwnProperty(key)) {
                                 if (json[key].SubDtlId != "") {


                                     EditEachRow(json[key].SubDtlId, json[key].SubId, json[key].DtlName, json[key].DtlFloor,json[key].SubId_Del_Chk);

                                 }
                             }
                         }

                         for (var DisCount = 1; DisCount < rowCountPop; DisCount++) {
                             var AddButton = $noconfli("#tdAdd_" + DisCount);
                             if (AddButton.length) {
                                 document.getElementById("ImgAdd_" + DisCount).disabled = true;
                                 document.getElementById("tdAdd_" + DisCount).style.opacity = "0.3";
                             }
                         }

                     }
                     else {

                         AddEachRow(DtlId);
                     }
                 }
             });
         }

    </script>


    <style>
        /*--------------------------------------------------for modal Reopen Reason------------------------------------------------------*/
        .modalPopUp {
            display: none;
            position: fixed;
            z-index: 30;
            margin-top: 15%;
            left: 0;
            top: 0;
            width: 31%;
            height: auto;
            overflow: auto;
            background-color: transparent;
            margin-left: 57%;
        }


        .modal-contentPopUp {
            position: relative;
            background-color: #fefefe;
            margin-left: 0%;
            padding: 0;
            border: 1px solid #888;
            width: 93%;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
            float: left;
        }



        /* The Close Button */
        .closePopUp {
            color: white;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }


        .modal-headerPopUp {
            color: white;
            border: 1px solid #cec2c2;
            float: left;
            width: 100%;
        }

        .modal-footerSlice1 {
            width: 49%;
            border: 1px solid #d7d7d7;
            height: 15px;
            float: left;
        }

        .modal-footerSlice2 {
            width: 49%;
            border: 1px solid #d7d7d7;
            height: 15px;
            float: left;
        }

        .modal-bodyPopUp {
            float: left;
            width: 100%;
        }


        .modal-footerPopUp {
            background-color: #6d775d;
            color: #050505;
            float: left;
            width: 100%;
            margin-top: 3%;
            /*border: 1px solid #0e0f0e;*/
            height: 29px;
        }





        .eachform {
            width: 55%;
            display: inline-block;
            margin: 0 0 10px;
            margin-left: 0px;
            margin-left: 11%;
        }

        .cont_rght {
            width: 98%;
        }

        .OtherRow1 {
            width: 60%;
            text-align: center;
            /*border: 1px solid #c2afaf;*/
        }

        .OtherRow2 {
            width: 30%;
            text-align: center;
            /*border: 1px solid #c2afaf;*/
        }

        .HeadRow1 {
            width: 60%;
            text-align: center;
            /*border: 1px solid;*/
            background-color: #6d775d;
            color: #050505;
        }

        .HeadRow2 {
            width: 30%;
            text-align: center;
            /*border: 1px solid;*/
            background-color: #6d775d;
            color: #050505;
        }
    </style>
</asp:Content>

