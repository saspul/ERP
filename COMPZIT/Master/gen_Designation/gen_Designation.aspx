﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Designation.aspx.cs" Inherits="Master_gen_Designation_gen_DesignationAdd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/hcm_ns.css" rel="stylesheet" />
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
     <script>
         var $au = jQuery.noConflict();
         $au(function () {
             $au('#cphMain_ddlDesignationType').selectToAutocomplete1Letter();
          
         });
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
         //start-0006
         var $noCon = jQuery.noConflict();
         $noCon(window).load(function () {
             if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {
                IncrmntConfrmCounter();
            }
            var FramewrkId = '<%= Session["FRMWRK_ID"] %>';
            var FramewrkTyp = '<%= Session["FRMWRK_TYPE"] %>';
            if (FramewrkTyp == "1" && FramewrkId != "" && FramewrkId != null) {


                $(".btn_app").addClass("selected7");
                $(".btn_app1").addClass("selected7");
                $(".btn_sls1, .btn_aws1, .btn_guar1, .btn_hcm1, .btn_fin1, .btn_pro1").removeClass("selected7");
                $(".btn_app1_a").fadeIn(600);
                $(".btn_sls1_a, .btn_aws1_a, .btn_guar1_a, .btn_hcm1_a, .btn_fin1_a, .btn_pro1_a").fadeOut(200);

                document.getElementById("divAPPSelect").style.display = "none";
                document.getElementById("divAPPCbx").style.display = "none";
                document.getElementById("hApp").style.display = "none";

            }
            else {

                var checkbox = document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value.split(',');

                for (var i = 0; i < checkbox.length; i++) {

                    if (checkbox[i].toString() == '1')//IF APP ADMINISTRATION
                    {
                        $(".btn_app").addClass("selected7");
                        $(".btn_app1").toggle(100);
                    }
                    else if (checkbox[i].toString() == '2')//IF SALES FORCE AUTOMATION 
                    {
                        $(".btn_sls1").toggle(100);
                        $(".btn_sls").addClass("selected7");
                    }
                    else if (checkbox[i].toString() == '3')//IF AUTO WORKSHOP MANAGEMENT
                    {
                        $(".btn_aws1").toggle(100);
                        $(".btn_aws").addClass("selected7");
                    }
                    else if (checkbox[i].toString() == '4')//IF GUARANTEE MANAGEMENT
                    {
                        $(".btn_guar1").toggle(100);
                        $(".btn_guar").addClass("selected7");
                    }
                    else if (checkbox[i].toString() == '5')//IF GUARANTEE MANAGEMENT
                    {
                        $(".btn_hcm1").toggle(100);
                        $(".btn_hcm").addClass("selected7");
                    }
                    else if (checkbox[i].toString() == '6')//IF FINANCE MANAGEMENT
                    {
                        $(".btn_fin1").toggle(100);
                        $(".btn_fin").addClass("selected7");
                    }
                    else if (checkbox[i].toString() == '7')//IF PROCUREMENT MANAGEMENT//PMS
                    {
                        $(".btn_pro1").toggle(100);
                        $(".btn_pro").addClass("selected7");
                    }

                }
            }
            var checkbox = document.getElementById("<%=HiddenFieldcbxChecked.ClientID%>").value.split(',');
            for (var i = 0; i < checkbox.length; i++) {
                $('input[value="' + checkbox[i].toString() + '"]').attr('checked', true);
            }
            if (document.getElementById("<%=lblEntry.ClientID%>").innerText == "VIEW EMPLOYEE ROLE ALLOCATION") {
                $(".btn_app").attr('disabled', true);
                $(".btn_sls").attr('disabled', true);
                $(".btn_aws").attr('disabled', true);
                $(".btn_guar").attr('disabled', true);
                $(".btn_hcm").attr('disabled', true);
                $(".btn_fin").attr('disabled', true);
                $(".btn_pro").attr('disabled', true);
                $('.btn-d,.btn-p').attr('disabled', 'true');
            }
        });
    </script>
      <script>

          //start-0006
          var confirmbox = 0;

          function IncrmntConfrmCounter() {
              confirmbox++;
          }
          function ConfirmMessage() {
              if (confirmbox > 0) {
                  ezBSAlert({
                      type: "confirm",
                      messageText: "Do you want to leave this page?",
                      alertType: "info"
                  }).done(function (e) {
                      if (e == true) {
                          window.location.href = "gen_DesignationList.aspx";
                          return false;
                      }
                      else {
                          return false;
                      }
                  });
                  return false;
              }
              else {
                  window.location.href = "gen_DesignationList.aspx";

              }
              return false;
          }
          function AlertClearAll() {
              if (confirmbox > 0) {
                  ezBSAlert({
                      type: "confirm",
                      messageText: "Do you want to clear all the data from this page?",
                      alertType: "info"
                  }).done(function (e) {
                      if (e == true) {
                          window.location.href = "gen_Designation.aspx";
                          return false;
                      }
                      else {
                          return false;
                      }
                  });
                  return false;
              }
              else {
                  window.location.href = "gen_Designation.aspx";
                  return false;
              }
              return false;
          }
          //stop-0006
    </script>
   
    <%--<script src="../../../JavaScript/jquery-1.8.3.min.js"></script>--%>

    <%-- <script>
        //start-0006
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            // document.getElementById("freezelayer").style.display = "none";

            //document.getElementById('MymodalCancelView').style.display = "none";

            if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {

                IncrmntConfrmCounter();
            }

            var FramewrkId = '<%= Session["FRMWRK_ID"] %>';
            var FramewrkTyp = '<%= Session["FRMWRK_TYPE"] %>';
            if (FramewrkTyp == "1" && FramewrkId != "" && FramewrkId != null) {
                document.getElementById('divAccordionAppAdmin').style.display = "";
                document.getElementById('accordion-1').style.display = "block";
                document.getElementById('cphMain_cbxlCompzitModules_0').checked = true;
                document.getElementById('cphMain_cbxlCompzitModules_1').checked = false;
                document.getElementById('cphMain_cbxlCompzitModules_2').checked = false;
                document.getElementById('cphMain_cbxlCompzitModules_3').checked = false;
                document.getElementById('cphMain_cbxlCompzitModules_4').checked = false;
                document.getElementById('cphMain_cbxlCompzitModules_5').checked = false;
                document.getElementById('cphMain_cbxlCompzitModules_6').checked = false;
                document.getElementById('divCompzitModules').style.display = "none";
                $(".accordion-section-title").hide();
                if (document.getElementById("<%=ddlDesignationType.ClientID%>").value == "--SELECT--") {
                    document.getElementById('accordion-1').style.display = "none";
                }
            }
            else {

                document.getElementById('divCompzitModules').style.display = "block";

                var CHK = document.getElementById("<%=cbxlCompzitModules.ClientID%>");

                var checkbox = CHK.getElementsByTagName("input");

                var label = CHK.getElementsByTagName("label");

                for (var i = 0; i < checkbox.length; i++) {

                    if (checkbox[i].checked) {

                        //  alert("Selected = " + checkbox[i].value);
                        if (checkbox[i].value.toString() == '1')//IF APP ADMINISTRATION
                        {
                            document.getElementById('divAccordionAppAdmin').style.display = "";
                        }
                        else if (checkbox[i].value.toString() == '2')//IF SALES FORCE AUTOMATION 
                        {
                            document.getElementById('divAccordionSFA').style.display = "";
                        }
                        else if (checkbox[i].value.toString() == '3')//IF AUTO WORKSHOP MANAGEMENT
                        {
                            document.getElementById('divAccordionAWMS').style.display = "";
                        }
                        else if (checkbox[i].value.toString() == '4')//IF GUARANTEE MANAGEMENT
                        {
                            document.getElementById('divAccordionGMS').style.display = "";
                        }
                        else if (checkbox[i].value.toString() == '5')//IF HUMAN CAPITAL MANAGEMENT
                        {
                            document.getElementById('divAccordionHCM').style.display = "";
                        }
                        else if (checkbox[i].value.toString() == '6')//IF FINANCE MANAGEMENT
                        {
                            document.getElementById('divAccordionFMS').style.display = "";
                        }
                        else if (checkbox[i].value.toString() == '7')//IF PROCUREMENT MANAGEMENT//PMS
                        {
                            document.getElementById('divAccordionPMS').style.display = "";
                        }

                    }

                }

            }
        });
    </script>--%>
  
    <script>

        //function CheckBoxChange(count) {
        //    var RowCount = count;
        //    for (i = 0; i < RowCount; i++) {
        //        if (document.getElementById('cblwelfarescvc_' + i).checked == false) {
        //            document.getElementById('cbxSelectAll').checked = false;
        //        }
        //    }

       // }
        function selectAll() {  //EMP0025

            var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
            var strAmntList = "";
            if (document.getElementById('cbxSelectAll').checked == true) {
                for (i = 0; i < RowCount; i++) {

                    document.getElementById('cblwelfarescvc_' + i).checked = true;


                }
            }
            else {
                for (i = 0; i < RowCount; i++) {

                    document.getElementById('cblwelfarescvc_' + i).checked = false;

                }
            }


        }



        function SuccessMessage() {
            $("#success-alert").html("Welfare service saved successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });

        }
        function ValueNotFoundMessage() {
            $("#divWarning").html("Selected  welfare service not allowed.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

        }
        function getselected(rowCount) {   //EMP0025
            //   alert('call');
            document.getElementById("<%=Hiddenchecklist.ClientID%>").value = [];
            alert("Modified welfare limit will effect for all the employees in the selected designation");

            // alert();
            var tbClientValues = '';
            tbClientValues = [];
            if (rowCount > 0) {
                MainTable = $('#ReportTableWelfare > tbody > tr');
                $(MainTable).each(function () {

                    var RowId = $(this).attr('id');


                    var SplitId = RowId.split('_');
                    var CntMain = SplitId[1];
                    if (SplitId[0] == "trId") {

                        if ($('#cblwelfarescvc_' + CntMain).length) {
                            // alert('enter');
                            var checked = 0;
                            if ($('#cblwelfarescvc_' + CntMain).is(':checked')) {
                                checked = 1;
                            }
                            var MyTable = document.getElementById("tdchkSts_" + CntMain + "").innerHTML;
                            var DESGID = document.getElementById("<%=HiddenDesgId.ClientID%>").value;
                            var SubId = document.getElementById('tdSubtId_' + CntMain).innerHTML;
                            //alert(SubId);
                            var WELFARID = document.getElementById('tdWelfareId_' + CntMain).innerHTML;
                            var QtyLimt = document.getElementById('tdlimit1_' + CntMain).innerHTML;
                            var LIMIT = $('#txtlmt_' + CntMain).val();
                            var client = JSON.stringify({
                                DesgId: "" + DESGID + "",
                                WelfareId: "" + WELFARID + "",
                                limit: "" + LIMIT + "",
                                WelfareSubId: "" + SubId + "",
                                chkSts: "" + MyTable + "",
                                CheckboxSts: "" + checked + "",
                                ActLimt: "" + QtyLimt + "",
                            });
                            tbClientValues.push(client);

                        }
                    }
                });
            }


            document.getElementById("<%=Hiddenchecklist.ClientID%>").value = JSON.stringify(tbClientValues);
            //    alert(document.getElementById("<%=Hiddenchecklist.ClientID%>").value);
            //alert(DesgId);
        }

        function preview(Id) {
            //  alert(Id);

            //document.getElementById("freezelayer").style.display = "";
            //  document.getElementById('MymodalCancelView').style.display = "block";
            var str = Id;

            var globalFileTypeId = str.split(',');
            var id1 = globalFileTypeId[0];
            var id2 = globalFileTypeId[1];
            var id3 = globalFileTypeId[2];
<%--            document.getElementById("<%=divSeviceName.ClientID%>").innerHTML = id3--%>
            document.getElementById("<%=HiddenWelfareId.ClientID%>").value = id1;
            //alert(document.getElementById("<%=HiddenWelfareId.ClientID%>").value);

            // alert(id1); alert(id2);

            $.ajax({
                type: "POST",
                url: "gen_Designation.aspx/preview1",
                data: '{strid: "' + id1 + '",strdesgid:"' + id2 + '"}',

                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // alert(response.d);
                    document.getElementById("<%=divReport1.ClientID%>").innerHTML = response.d;
                    //  document.getElementById('divReport1').innerHTML = response.d;

                },
                failure: function (response) {

                }

            });

            // OpenCancelView();
                $nooC('#dialog_simple').dialog('open');
                $nooC('.ui-dialog-titlebar-close').attr('title', 'Close');
            // document.getElementById("txtefctvedate").value = "";




                return false;
            }

            function CloseCancelView() {



                //  document.getElementById("MymodalCancelView").style.display = "none";
                //    document.getElementById("freezelayer").style.display = "none";
                // document.getElementById('divErrorRsnAWMS').style.visibility = "hidden";

            }

            //stop-0006
    </script>
    <%-- /*--------------------------------------------------for modal Cancel Reason------------------------------------------------------*/--%>


    <script type="text/javascript">
        function DuplicationName() {


            document.getElementById("<%=txtDesignationName.ClientID%>").style.borderColor = "Red";
            $("#divWarning").html("Duplication Error!. Designation Name Can’t be Duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

        }

        function SuccessConfirmation() {
            $("#success-alert").html("Designation Details Inserted Successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("Designation Details Updated Successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }


       
        function Validate() {

            //   getselected();
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;

                return ret;
            }

            if ($('#CbxAllocateAll').length) { // evm-0023 

                if (document.getElementById("<%=CbxAllocateAll.ClientID%>").checked == true) {
                    if (confirm("Are You Sure You Want To Allocate Selected Roles to Existing Users and Job Roles")) {

                    }
                    else {

                        ret = false
                    }

                }
            }


            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtDesignationName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtDesignationName.ClientID%>").value = replaceText2;

            var Type = document.getElementById("<%=ddlDesignationType.ClientID%>").value;
            var Name = document.getElementById("<%=txtDesignationName.ClientID%>").value.trim();

            document.getElementById("<%=txtDesignationName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlDesignationType.ClientID%>").style.borderColor = "";


            if ((Name == "") || (Type == "--SELECT--")) {

                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                if (Type == "--SELECT--") {

                    document.getElementById("<%=ddlDesignationType.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddlDesignationType.ClientID%>").focus();
                    ret = false;
                }
                if (Name == "") {

                    document.getElementById("<%=txtDesignationName.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtDesignationName.ClientID%>").focus();
                    ret = false;
                }

            }
            if (ret == false) {
                CheckSubmitZero();

            }
            else
            {
                document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value = "";
                if ($(".btn_app").hasClass("selected7")) {
                    document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value += ",1";
                    document.getElementById("<%=HiddenFieldApp.ClientID%>").value = "";
                    $('#cphMain_treeApp input[type=checkbox]:checked').each(function () {
                        document.getElementById("<%=HiddenFieldApp.ClientID%>").value += "," + $(this).val();
                    });
                }
                if ($(".btn_sls").hasClass("selected7")) {
                    document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value += ",2";
                    document.getElementById("<%=HiddenFieldSfa.ClientID%>").value = "";
                    $('#cphMain_treeSfa input[type=checkbox]:checked').each(function () {
                        document.getElementById("<%=HiddenFieldSfa.ClientID%>").value += "," + $(this).val();
                    });
                }
                if ($(".btn_aws").hasClass("selected7")) {
                    document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value += ",3";
                    document.getElementById("<%=HiddenFieldAwms.ClientID%>").value = "";
                    $('#cphMain_treeAwms input[type=checkbox]:checked').each(function () {
                        document.getElementById("<%=HiddenFieldAwms.ClientID%>").value += "," + $(this).val();
                    });
                }
                if ($(".btn_guar").hasClass("selected7")) {
                    document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value += ",4";
                    document.getElementById("<%=HiddenFieldGms.ClientID%>").value = "";
                    $('#cphMain_treeGms input[type=checkbox]:checked').each(function () {
                        document.getElementById("<%=HiddenFieldGms.ClientID%>").value += "," + $(this).val();
                    });
                }
                if ($(".btn_hcm").hasClass("selected7")) {
                    document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value += ",5";
                    document.getElementById("<%=HiddenFieldHcm.ClientID%>").value = "";
                    $('#cphMain_treeHcm input[type=checkbox]:checked').each(function () {
                        document.getElementById("<%=HiddenFieldHcm.ClientID%>").value += "," + $(this).val();
                    });
                }
                if ($(".btn_fin").hasClass("selected7")) {
                    document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value += ",6";
                    document.getElementById("<%=HiddenFieldFms.ClientID%>").value = "";
                    $('#cphMain_treeFms input[type=checkbox]:checked').each(function () {
                        document.getElementById("<%=HiddenFieldFms.ClientID%>").value += "," + $(this).val();
                    });
                }
                if ($(".btn_pro").hasClass("selected7")) {
                    document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value += ",7";
                    document.getElementById("<%=HiddenFieldPms.ClientID%>").value = "";
                    $('#cphMain_treePms input[type=checkbox]:checked').each(function () {
                        document.getElementById("<%=HiddenFieldPms.ClientID%>").value += "," + $(this).val();
                    });
                }

            }
            return ret;
        }


    </script>
    <script type="text/javascript">

        (function () {
            if ("-ms-user-select" in document.documentElement.style && navigator.userAgent.match(/IEMobile\/10\.0/)) {
                var msViewportStyle = document.createElement("style");
                msViewportStyle.appendChild(
                    document.createTextNode("@-ms-viewport{width:auto!important}")
                );
                document.getElementsByTagName("head")[0].appendChild(msViewportStyle);
            }
        })();
    </script>
    <script type="text/javascript" language="javascript">
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
        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }
        function controlTab(obj, event) {
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 9) {
                document.getElementById(obj).focus();
                return false;
            }

            else {
                return true;
            }
        }
      <%--  function ClickCompzitModule() {

            IncrmntConfrmCounter();

            document.getElementById('divAccordionAppAdmin').style.display = "none";
            document.getElementById('divAccordionSFA').style.display = "none";
            document.getElementById('divAccordionAWMS').style.display = "none";
            document.getElementById('divAccordionGMS').style.display = "none";
            document.getElementById('divAccordionHCM').style.display = "none";
            document.getElementById('divAccordionFMS').style.display = "none";
            document.getElementById('divAccordionPMS').style.display = "none";

            var CHK = document.getElementById("<%=cbxlCompzitModules.ClientID%>");

            var checkbox = CHK.getElementsByTagName("input");

            var label = CHK.getElementsByTagName("label");

            for (var i = 0; i < checkbox.length; i++) {

                if (checkbox[i].checked) {

                    //  alert("Selected = " + checkbox[i].value);
                    if (checkbox[i].value.toString() == '1')//IF APP ADMINISTRATION
                    {
                        document.getElementById('divAccordionAppAdmin').style.display = "";
                    }
                    else if (checkbox[i].value.toString() == '2')//IF SALES FORCE AUTOMATION 
                    {
                        document.getElementById('divAccordionSFA').style.display = "";
                    }
                    else if (checkbox[i].value.toString() == '3')//IF AUTO WORKSHOP MANAGEMENT
                    {
                        document.getElementById('divAccordionAWMS').style.display = "";
                    }
                    else if (checkbox[i].value.toString() == '4')//IF AUTO WORKSHOP MANAGEMENT
                    {
                        document.getElementById('divAccordionGMS').style.display = "";
                    }
                    else if (checkbox[i].value.toString() == '5')//IF HUMAN CAPITAL MANAGEMENT
                    {
                        document.getElementById('divAccordionHCM').style.display = "";
                    }
                    else if (checkbox[i].value.toString() == '6')//IF FINANCE MANAGEMENT
                    {
                        document.getElementById('divAccordionFMS').style.display = "";
                    }
                    else if (checkbox[i].value.toString() == '7')//IF PROCUREMENT MANAGEMENT//PMS
                    {
                        document.getElementById('divAccordionPMS').style.display = "";
                    }

                }

            }
            return false;

        }--%>

        function validateWelfare() {

            var ret = true;
            //  document.getElementById('divErrorRsnAWMS').style.visibility = "hidden";

            var totalRowCount = 0;

            var rowCount = 0;

            var table = document.getElementById("ReportTableWelfare");

            var rows = table.getElementsByTagName("tr")

            for (var i = 0; i < rows.length; i++) {

                totalRowCount++;

                if (rows[i].getElementsByTagName("td").length > 0) {

                    rowCount++;

                }

            }

            MainTable = $('#ReportTableWelfare > tbody > tr');




            var check = 0;
            for (var j = 0; j < rowCount; j++) {
                if ($('#cblwelfarescvc_' + j).is(':checked')) {
                    check = check + 1;
                    var LIMIT = $('#txtlmt_' + j).val().trim();
                    if (LIMIT == "") {
                        $('#txtlmt_' + j).css('border-color', 'red');

                        //document.getElementById('divErrorRsnAWMS').style.visibility = "visible";

                        ret = false;
                    }


                }
            }


            // if (check == 0) {

            //  document.getElementById('divErrorRsnAWMS').style.visibility = "visible";

            //   ret = false;



            //   }
            if (ret == true) {
                getselected(rowCount);
            }
            return ret;
            //alert(count);

        }
    </script>
    <%--    <style>
        #gvUserRole input[type="radio"], input[type="checkbox"] {
            margin: 6px 6px 6px;
        }
    </style>--%>




    <script>
        function blurRemoveTags() {
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtDesignationName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtDesignationName.ClientID%>").value = replaceText2.trim();

        }
    </script>
    <script type="text/javascript">
        // for not allowing <> tags  and enter

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
        function controlTab(obj, event) {
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 9) {
                document.getElementById(obj).focus();
                return false;
            }

            else {
                return true;
            }
        }
        function ClickCompzitModule() {
            IncrmntConfrmCounter();
            return false;
        }



    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
    <asp:HiddenField ID="hiddenPrimaryDecision" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />
    <asp:HiddenField ID="HiddenDesgId" runat="server" />
    <asp:HiddenField ID="hiddenRowCount" runat="server" />
    <asp:HiddenField ID="Hiddenchecklist" runat="server" />
    <%-- EMP0025--%>
    <asp:HiddenField ID="HiddenView" runat="server" />
    <asp:HiddenField ID="HiddenWelfareId" runat="server" />
    <asp:HiddenField ID="HiddenWelfareSubId" runat="server" />


    <asp:HiddenField ID="HiddenFieldcbxChecked" runat="server" />
    <asp:HiddenField ID="HiddenFieldAppChecked" runat="server" />

    <asp:HiddenField ID="HiddenFieldApp" runat="server" />
    <asp:HiddenField ID="HiddenFieldSfa" runat="server" />
    <asp:HiddenField ID="HiddenFieldAwms" runat="server" />
    <asp:HiddenField ID="HiddenFieldGms" runat="server" />
    <asp:HiddenField ID="HiddenFieldHcm" runat="server" />
    <asp:HiddenField ID="HiddenFieldFms" runat="server" />
    <asp:HiddenField ID="HiddenFieldPms" runat="server" />

    <%--  <br />
        <br />--%>
    <br />



    <!----new--->
    <ol class="breadcrumb">
        <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Hcm.aspx">HCM</a></li>
        <li><a href="/Master/gen_Designation/gen_DesignationList.aspx">Designation Master</a></li>
        <li class="active">Add Designation</li>
    </ol>

    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">

            <div class="content_box1 cont_contr">
                <h2 id="lblEntry" runat="server">Add Designation</h2>
                <div class="form-group fg2 sa_2 sa_480">
                    <label for="email" class="fg2_la1">Designation:<span class="spn1">*</span></label>

                    <asp:TextBox ID="txtDesignationName" class="form-control fg2_inp1 inp_mst" placeholder="Designation" runat="server" MaxLength="100" Style="text-transform: uppercase" onblur="RemoveTag('cphMain_txtDesignationName')" onchange="IncrmntConfrmCounter();" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);"></asp:TextBox>

                </div>
                <div class="form-group fg2 sa_2 sa_480">
                    <label for="email" class="fg2_la1">Type:<span class="spn1">*</span></label>
                    <asp:DropDownList ID="ddlDesignationType" class="form-control fg2_inp1 inp_mst" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDesignationType_SelectedIndexChanged"></asp:DropDownList>


                </div>



                <div class="subform" style="margin-left: 24.5%;">
                </div>
                <div id="divRadioType" class="form-group fg7 sa_2 sa_640 sa_480">
                    <label for="email" class="fg2_la1">Staff/Worker:<span class="spn1">*</span></label>
                    <div class="row rl_prt">
                        <div class="prtd_rat">
                            <div class="form-check">
                                <input id="RadioStaff" type="radio" runat="server" checked="true" class="form-check-input" groupname="RadioType" />
                                <label for="cphMain_RadioStaff" class="form-check-label">Staff</label>
                                <input id="RadioLabour" type="radio" runat="server" groupname="RadioType" class="form-check-input" />
                                <label for="cphMain_RadioLabour" class="form-check-label">Worker</label>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="form-group fg2 sa_2 sa_480">
                    <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
                    <div class="check1">
                        <div class="">
                            <label class="switch">
                                <asp:CheckBox ID="cbxStatus" runat="server" Checked="true" />

                                <span class="slider_tog round"></span>
                            </label>
                        </div>
                    </div>
                </div>

                <div class="clearfix"></div>
                <div class="devider"></div>

                <h3> Compzit Modules</h3>


                <div class="clearfix"></div>

                <div class="col-md-12">
                    <div class="col-md-2" id="divAPPCbx">
                        <div class="prod_sect" id="divCompzitModuleList" runat="server">
                            <button class="prod_ic k1 btn_app" onclick="return false;">
                                <img src="../../Images/New%20Images/images/des_ico/app_7.png" title="App Administration"></button>
                            <button class="prod_ic k2 btn_sls" onclick="return false;">
                                <img src="../../Images/New%20Images/images/des_ico/sls7.png" title="Sales Force Automation"></button>
                            <button class="prod_ic k3 btn_aws" onclick="return false;">
                                <img src="../../Images/New%20Images/images/des_ico/aws7.png" title="Auto Workshop Management System"></button>
                            <button class="prod_ic k4 btn_guar" onclick="return false;">
                                <img src="../../Images/New%20Images/images/des_ico/guaran_7.png" title="Guarantee Management System"></button>
                            <button class="prod_ic k5 btn_hcm" onclick="return false;">
                                <img src="../../Images/New%20Images/images/des_ico/hcm7.png" title="Human Capital Management"></button>
                            <button class="prod_ic k6 btn_fin" onclick="return false;">
                                <img src="../../Images/New%20Images/images/des_ico/fin7.png" title="Finance Management System"></button>
                            <button class="prod_ic k7 btn_pro" onclick="return false;">
                                <img src="../../Images/New%20Images/images/des_ico/pro7.png" title="Procurement Management System"></button>
                        </div>
                        <div id="divCompzitModuleNoList" runat="server">
                            <asp:Label ID="Label1" runat="server" Text="No Modules Available."></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-10">
                        <div class="col-md-4" id="divAPPSelect">
                            <div class="prod_sel">
                                <button class="prod_sel2 btn_app1 prod_ic btn_app1 tablinks hei_adbtn" onclick="return false;" style="display: none;">
                                    <img src="../../Images/New%20Images/images/app_7.png" >
                                    App Administration<span class="spn1"></span></button>
                            </div>
                            <div class="prod_sel">
                                <button class="prod_sel2 btn_sls1 prod_ic btn_app2 tablinks hei_adbtn" onclick="return false;" style="display: none;">
                                    <img src="../../Images/New%20Images/images/sls7.png">
                                    Sales Force Automation<span class="spn1"></span></button>
                            </div>
                            <div class="prod_sel">
                                <button class="prod_sel2 btn_aws1 prod_ic btn_app3 tablinks hei_adbtn" onclick="return false;" style="display: none;">
                                    <img src="../../Images/New%20Images/images/aws7.png">
                                    Auto Workshop Management System<span class="spn1"></span></button>
                            </div>
                            <div class="prod_sel">
                                <button class="prod_sel2 btn_guar1 prod_ic btn_app4 tablinks hei_adbtn" onclick="return false;" style="display: none;">
                                    <img src="../../Images/New%20Images/images/guaran_7.png">
                                    Guarantee Management System<span class="spn1"></span></button>
                            </div>
                            <div class="prod_sel">
                                <button class="prod_sel2 btn_hcm1 prod_ic btn_app5 tablinks hei_adbtn" onclick="return false;" style="display: none;">
                                    <img src="../../Images/New%20Images/images/hcm7.png">
                                    Human Capital Management<span class="spn1"></span></button>
                            </div>
                            <div class="prod_sel">
                                <button class="prod_sel2 btn_fin1 prod_ic btn_app6 tablinks hei_adbtn" onclick="return false;" style="display: none;">
                                    <img src="../../Images/New%20Images/images/fin7.png">
                                    Finance Management System<span class="spn1"></span></button>
                            </div>
                            <div class="prod_sel">
                                <button class="prod_sel2 btn_pro1 prod_ic btn_app7 tablinks hei_adbtn" onclick="return false;" style="display: none;">
                                    <img src="../../Images/New%20Images/images/pro7.png">
                                    Procurement Management System<span class="spn1"></span></button>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="prod_tree">

                                <!---heirarchy_section_started-->

                                <div class="">
                                    <!------tree_section_started-->
                                    <div class="box_pro_7 pro_pa">
                                        <div class="tree7">
                                            <div class="tree7 wi_tre_1">
                                                <ul id="myTab1" class="sc_hei btn_app1_a" style="display: none;">
                                                    <h3 class="mar_bo1" id="hApp">App Administration</h3>

                                                    <li id="treeApp" runat="server"></li>
                                                </ul>


                                                <!------tree_section_started-->
                                                <ul id="Ul1" class="sc_hei btn_sls1_a" style="display: none;">
                                                    <h3>Sales Force Automation</h3>
                                                    <li id="treeSfa" runat="server"></li>
                                                </ul>
                                                <!------tree_section_closed----->

                                                <!------tree_section_started-->
                                                <ul id="Ul2" class="sc_hei btn_aws1_a" style="display: none;">
                                                    <h3>Auto Workshop Management System</h3>
                                                    <li id="treeAwms" runat="server"></li>
                                                </ul>
                                                <!------tree_section_closed----->

                                                <!------tree_section_started-->
                                                <ul id="Ul3" class="sc_hei btn_guar1_a" style="display: none;">
                                                    <h3>Guarantee Management System</h3>
                                                    <li id="treeGms" runat="server"></li>
                                                </ul>

                                                <!------tree_section_closed----->

                                                <!------tree_section_started-->
                                                <ul id="Ul4" class="sc_hei btn_hcm1_a" style="display: none;">
                                                    <h3>Human Capital Management</h3>
                                                    <li id="treeHcm" runat="server"></li>
                                                </ul>
                                                <!------tree_section_closed----->

                                                <!------tree_section_started-->
                                                <ul id="Ul5" class="sc_hei btn_fin1_a" style="display: none;">
                                                    <h3>Finance Management System</h3>
                                                    <li id="treeFms" runat="server"></li>
                                                </ul>
                                                <!------tree_section_closed----->

                                                <!------tree_section_started-->
                                                <ul id="Ul6" class="sc_hei btn_pro1_a" style="display: none;">
                                                    <h3>Procurement Management System</h3>
                                                    <li id="treePms" runat="server"></li>
                                                </ul>



                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <!------tree_section_closed----->


                            </div>
                        </div>
                    </div>


                    <div class="sub_cont pull-right">
                        <div class="save_sec">
                            <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return Validate(); " />
                            <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return Validate(); " />
                            <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();  " />
                            <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();  " />
                            <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                            <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />

                        </div>


                    </div>

                </div>
            </div>
        </div>
    </div>
   
    <div class="mySave1" id="mySave" runat="server">
        <asp:Button ID="btnUpdatef" runat="server" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return Validate(); " />
        <asp:Button ID="btnUpdateClosef" runat="server" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return Validate(); " />
        <asp:Button ID="btnAddf" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();  " />
        <asp:Button ID="btnAddClosef" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();  " />
        <asp:Button ID="btnClearf" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
        <asp:Button ID="btnCancelf" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />


    </div>
    <a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
        <i class="fa fa-save"></i>
    </a>

    <a href="gen_DesignationList.aspx" type="button" class="list_b" title="Back to List">
        <i class="fa fa-arrow-circle-left"></i>
    </a>
    <script>
        function opensave() {
            document.getElementById("cphMain_mySave").style.width = "120px";
        }

        function closesave() {
            document.getElementById("cphMain_mySave").style.width = "0px";
        }
    </script>
    <!--content_container_closed------>



    <!----tree_jquery---->

    <!-- <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script> -->
    <script type="text/javascript">
        $(function () {
            $('.tree li:has(ul)').addClass('parent_li').find(' > span').attr('title', 'Collapse this');
            $('.tree li.parent_li > span').on('click', function (e) {
                var children = $(this).parent('li.parent_li').find(' > ul > li');
                if (children.is(":visible")) {
                    children.hide('fast');
                } else {
                    children.show('fast');
                }
                e.stopPropagation();
            });
        });
    </script>
    <!----tree_jquery_closed---->


    <!----module section_details_started---->
    <script>
        $(document).ready(function () {
            $(".module1").click(function () {
                $(".modle_detl1").toggle(100);
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $(".module2").click(function () {
                $(".modle_detl2").toggle(100);
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $(".module3").click(function () {
                $(".modle_detl3").toggle(100);
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $(".module4").click(function () {
                $(".modle_detl4").toggle(100);
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $(".module5").click(function () {
                $(".modle_detl5").toggle(100);
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $(".module6").click(function () {
                $(".modle_detl6").toggle(100);
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $(".module7").click(function () {
                $(".modle_detl7").toggle(100);
            });
        });
    </script>

    <!----module section_details_closed---->

    <script type="text/javascript">
        $("#war-btn").click(function () {
            $("div.war").fadeIn(200).delay(500).fadeOut(400);
        });
    </script>

    <script>
        $(document).ready(function () {
            $(".imprt_o").click(function () {
                $(".import_opt").toggle(300);
            });
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".cont_contr").scroll(function () {
                if ($(this).scrollTop() > 100) {
                    $('#scroll').fadeIn();
                } else {
                    $('#scroll').fadeOut();
                }
            });
            $('#scroll').click(function () {
                $(".cont_contr").animate({ scrollTop: 0 }, 600);
                return false;
            });
        });
    </script>

    <!----prodct selected script_section started--->
    <script>
        $(document).ready(function () {
            $(".k1").click(function () {
                $(".k1").toggleClass("selected7");
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $(".k2").click(function () {
                $(".k2").toggleClass("selected7");
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $(".k3").click(function () {
                $(".k3").toggleClass("selected7");
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $(".k4").click(function () {
                $(".k4").toggleClass("selected7");
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $(".k5").click(function () {
                $(".k5").toggleClass("selected7");
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $(".k6").click(function () {
                $(".k6").toggleClass("selected7");
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $(".k7").click(function () {
                $(".k7").toggleClass("selected7");
            });
        });
    </script>
    <!----prodct selected script_section closed-->

    <!----tree_jquery---->

    <!-- <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script> -->
    <script type="text/javascript">
        $(function () {
            $('.tree li:has(ul)').addClass('parent_li').find(' > span').attr('title', 'Collapse this branch');
            $('.tree li.parent_li > span').on('click', function (e) {
                var children = $(this).parent('li.parent_li').find(' > ul > li');
                if (children.is(":visible")) {
                    children.hide('fast');
                    $(this).attr('title', 'Expand this branch').find(' > i').addClass('icon-plus-sign').removeClass('icon-minus-sign');
                } else {
                    children.show('fast');
                    $(this).attr('title', 'Collapse this branch').find(' > i').addClass('icon-minus-sign').removeClass('icon-plus-sign');
                }
                e.stopPropagation();
            });
        });
    </script>
    <!----tree_jquery_closed---->

    <!----tab_script_for heirarchy page---->
    <script>
        function openCity(evt, cityName) {
            var i, tabcontent, tablinks;
            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }
            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
            document.getElementById(cityName).style.display = "block";
            evt.currentTarget.className += " active";
        }
    </script>

    <!----heirarchy_section_script_started--->
    <script>
        $(document).ready(function () {
            $(".organiser").click(function () {
                $(".hire").toggle();
            });
        });
    </script>
    <!----heirarchy_section_script_closed-->

    <script>
        function ck_tog() {
            if (document.getElementById("ck_toz").checked == true) {
                document.getElementById("ck_toz1").checked = false;
            } else {
                document.getElementById("ck_toz1").checked = true;
            }
        }
        function ck_tog1() {
            if (document.getElementById("ck_toz1").checked == true) {
                document.getElementById("ck_toz").checked = false;
            } else {
                document.getElementById("ck_toz").checked = true;
            }
        }
    </script>

    <script>
        onload = function () {

            // create the tree
            var theTree = new wijmo.nav.TreeView('#theTree', {
                itemsSource: getData(),
                displayMemberPath: 'header',
                childItemsPath: 'items'
            });
            theTree.selectedItem = theTree.itemsSource[0];

            // handle buttons
            document.getElementById('btnFirst').addEventListener('click', function () {
                var newItem = { header: document.getElementById('theInput').value },
                    node = theTree.selectedNode;
                if (node) {
                    theTree.selectedNode = node.addChildNode(0, newItem);
                } else {
                    theTree.selectedNode = theTree.addChildNode(0, newItem);
                }
            });
            document.getElementById('btnLast').addEventListener('click', function () {
                var newItem = { header: document.getElementById('theInput').value },
                    node = theTree.selectedNode;
                if (node) {
                    var index = node.nodes ? node.nodes.length : 0;
                    theTree.selectedNode = node.addChildNode(index, newItem);
                } else {
                    var index = theTree.nodes ? theTree.nodes.length : 0;
                    theTree.selectedNode = theTree.addChildNode(index, newItem);
                }
            });
            document.getElementById('btnNoSel').addEventListener('click', function () {
                theTree.selectedNode = null;
            });

            // create some data
            function getData() {
                return [
                  {
                      header: 'Parent 1', items: [
                      { header: 'Child 1.1' },
                      { header: 'Child 1.2' },
                      { header: 'Child 1.3' }]
                  },
                  {
                      header: 'Parent 2', items: [
                      { header: 'Child 2.1' },
                      { header: 'Child 2.2' }]
                  },
                  {
                      header: 'Parent 3', items: [
                      { header: 'Child 3.1' }]
                  }
                ];
            }
        }
    </script>

    <script>
        $(document).ready(function () {
            $(".hei_adbtn").click(function () {
                $("#add_hei").fadeIn();
                $(".sc_hei1").hide();
                $(".sc_hei").show();
                $("#ceo, #sal, #man").fadeOut(100);
                $(".man, .ceo, .sal").removeClass("act_hie");
            });
            $(".ceo_btn").click(function () {
                $("#ceo").fadeIn();
                $("#add_hei, #sal, #man").fadeOut(100);
                $(".ceo").addClass("act_hie");
                $(".add_hei, .sal, .man").removeClass("act_hie");
            });
            $(".sal_btn").click(function () {
                $("#sal").fadeIn();
                $("#add_hei, #ceo, #man").fadeOut(100);
                $(".sal").addClass("act_hie");
                $(".man, .ceo").removeClass("act_hie");
            });
            $(".man_btn").click(function () {
                $("#man").fadeIn();
                $("#add_hei, #ceo, #sal").fadeOut(100);
                $(".man").addClass("act_hie");
                $(".ceo, .sal").removeClass("act_hie");
            });
        });
    </script>

    <!---new_script-->

    <script>
        $(document).ready(function () {
            $(".btn_app").click(function () {
                $(".btn_app1").toggle(100);
                IncrmntConfrmCounter();
                return false;
            });
            $(".btn_sls").click(function () {
                $(".btn_sls1").toggle(100);
                IncrmntConfrmCounter();
                return false;
            });
            $(".btn_aws").click(function () {
                $(".btn_aws1").toggle(100);
                IncrmntConfrmCounter();
                return false;
            });
            $(".btn_guar").click(function () {
                $(".btn_guar1").toggle(100);
                IncrmntConfrmCounter();
                return false;
            });
            $(".btn_hcm").click(function () {
                $(".btn_hcm1").toggle(100);
                IncrmntConfrmCounter();
                return false;
            });
            $(".btn_fin").click(function () {
                $(".btn_fin1").toggle(100);
                IncrmntConfrmCounter();
                return false;
            });
            $(".btn_pro").click(function () {
                $(".btn_pro1").toggle(100);
                IncrmntConfrmCounter();
                return false;
            });

            $(".btn_app1").click(function () {
                $(".btn_app1").addClass("selected7");
                $(".btn_sls1, .btn_aws1, .btn_guar1, .btn_hcm1, .btn_fin1, .btn_pro1").removeClass("selected7");
                $(".btn_app1_a").fadeIn(600);
                $(".btn_sls1_a, .btn_aws1_a, .btn_guar1_a, .btn_hcm1_a, .btn_fin1_a, .btn_pro1_a").fadeOut(200);
                return false;
            });
            $(".btn_sls1").click(function () {
                $(".btn_sls1").addClass("selected7");
                $(".btn_app1, .btn_aws1, .btn_guar1, .btn_hcm1, .btn_fin1, .btn_pro1").removeClass("selected7");
                $(".btn_sls1_a").fadeIn(600);
                $(".btn_app1_a, .btn_aws1_a, .btn_guar1_a, .btn_hcm1_a, .btn_fin1_a, .btn_pro1_a").fadeOut(200);
                return false;
            });
            $(".btn_aws1").click(function () {
                $(".btn_aws1").addClass("selected7");
                $(".btn_sls1, .btn_app1, .btn_guar1, .btn_hcm1, .btn_fin1, .btn_pro1").removeClass("selected7");
                $(".btn_aws1_a").fadeIn(600);
                $(".btn_sls1_a, .btn_app1_a, .btn_guar1_a, .btn_hcm1_a, .btn_fin1_a, .btn_pro1_a").fadeOut(200);
                return false;
            });
            $(".btn_guar1").click(function () {
                $(".btn_guar1").addClass("selected7");
                $(".btn_sls1, .btn_aws1, .btn_app1, .btn_hcm1, .btn_fin1, .btn_pro1").removeClass("selected7");
                $(".btn_guar1_a").fadeIn(600);
                $(".btn_sls1_a, .btn_aws1_a, .btn_app1_a, .btn_hcm1_a, .btn_fin1_a, .btn_pro1_a").fadeOut(200);
                return false;
            });
            $(".btn_hcm1").click(function () {
                $(".btn_hcm1").addClass("selected7");
                $(".btn_sls1, .btn_aws1, .btn_guar1, .btn_app1, .btn_fin1, .btn_pro1").removeClass("selected7");
                $(".btn_hcm1_a").fadeIn(600);
                $(".btn_sls1_a, .btn_aws1_a, .btn_guar1_a, .btn_app1_a, .btn_fin1_a, .btn_pro1_a").fadeOut(200);
                return false;
            });
            $(".btn_fin1").click(function () {
                $(".btn_fin1").addClass("selected7");
                $(".btn_sls1, .btn_aws1, .btn_guar1, .btn_hcm1, .btn_app1, .btn_pro1").removeClass("selected7");
                $(".btn_fin1_a").fadeIn(600);
                $(".btn_sls1_a, .btn_aws1_a, .btn_guar1_a, .btn_hcm1_a, .btn_app1_a, .btn_pro1_a").fadeOut(200);
                return false;
            });
            $(".btn_pro1").click(function () {
                $(".btn_pro1").addClass("selected7");
                $(".btn_sls1, .btn_aws1, .btn_guar1, .btn_hcm1, .btn_fin1, .btn_app1").removeClass("selected7");
                $(".btn_pro1_a").fadeIn(600);
                $(".btn_sls1_a, .btn_aws1_a, .btn_guar1_a, .btn_hcm1_a, .btn_fin1_a, .btn_app1_a").fadeOut(200);
                return false;
            });
        });
    </script>

    <!---accodition section_script_opened--->
    <script>
        var acc = document.getElementsByClassName("accordion_role");
        var i;

        for (i = 0; i < acc.length; i++) {
            acc[i].addEventListener("click", function () {
                this.classList.toggle("active");
                var panel_role = this.nextElementSibling;
                if (panel_role.style.maxHeight) {
                    panel_role.style.maxHeight = null;
                } else {
                    panel_role.style.maxHeight = panel_role.scrollHeight + "px";
                }
            });
        }
    </script>
    <!---accodition section_script_closed--->

    <!----tree_jquery---->

    <!-- <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script> -->
    <script type="text/javascript">
        $(function () {
            $('.tree7 li:has(ul)').addClass('parent_li').find(' > span').attr('title', 'Collapse this');
            $('.tree7 li.parent_li > span').on('click', function (e) {
                var children = $(this).parent('li.parent_li').find(' > ul > li');
                if (children.is(":visible")) {
                    children.hide('fast');
                } else {
                    children.show('fast');
                }
                e.stopPropagation();
            });
        });
    </script>
    <!----tree_jquery_closed---->
    <!----new--->


     <style>
         .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            width: 218px;
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


























    <!--start 0009 leave type checkbox list-->
    <div class="eachform" style="display: none;">
        <h2>Leave Types</h2>
        <div id="divLeaveType">
            <div class="subform" id="divLeaveTypeList" style="margin-left: 0%; width: 70%; padding-top: 0%;" runat="server">

                <asp:CheckBoxList ID="cbxlLeaveTypes" runat="server">
                </asp:CheckBoxList>


            </div>
            <div id="divLeaveTypeNoList" runat="server" style="margin-left: 47.4%; color: #3b5113; font-family: Calibri;">
                <asp:Label ID="Label2" runat="server" Text="No Leave Type Available."></asp:Label>



            </div>
        </div>
    </div>
    <div id="divAllocateAllUsr" style="padding-top: 1%; display: none;" runat="server" class="eachform">
        <h2>Allocate Selected Types to Existing Users </h2>
        <div class="subform" style="padding-left: 7.3%; margin-top: -4%;">

            <asp:CheckBox ID="cbxAllocateAllUsr" runat="server" Checked="false" class="form2" />
            <h3 style="margin-top: 2%;">Allocate</h3>
        </div>

    </div>
    <!--stop 0009 leave type checkbox list--->

    <!-- emp25-->







    <div id="divAllocateAll" style="padding-top: 1%; display: none;" runat="server" class="eachform">
        <h2>Allocate Selected Roles to Existing Users </h2>
        <div class="subform" style="padding-left: 7%; margin-top: -4%;">

            <asp:CheckBox ID="CbxAllocateAll" runat="server" Checked="false" class="form2" />
            <h3 style="margin-top: 2%;">Allocate</h3>
        </div>

    </div>
    <br />



    <div id="divWelfareService" class="fillform2" runat="server" style="display: none">
        <%--EMP0025--%>
        <div id="div1" runat="server" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <asp:Label ID="lblWelfareSrvc" runat="server" Text="Welfare Services"></asp:Label>
        </div>

        <div id="divReport" class="table-responsive" runat="server" style="max-height: 500px; overflow: auto; font-family: Calibri; font-weight: bold; font-size: 15px; border: 1px solid #fff;">
        </div>

        <br />
        <br />
    </div>

    <%--    <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>--%>


    <%--<div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    
                   
                              <%--  <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>--%>





    <div id="divReport1" class="table-responsive" runat="server">
        <br />
        <br />
        <br />
        <br />
        <br />


    </div>
    <asp:Button ID="btnRsnSave" class="btn sub1" runat="server" Text="Save" OnClientClick="return validateWelfare();" OnClick="btnRsnSave_Click" Style="width: 90px; float: left; margin-left: 39%; margin-top: 3%;" visible="false"/>



    <%--<input type="button" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%; " onclick="CloseCancelView();" value="Close" />--%>
    <%--                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCancelView();" runat="server" Text="Close" />--%>
    <%--</div>--%>


    <%--</div>--%>
             
  
</asp:Content>
