<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_Job_Notification.aspx.cs" Inherits="HCM_HCM_Master_gen_Job_Notification_gen_Job_Notification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="../../../JavaScript/jquery_2.1.3_jquery_min.js"></script>
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

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
    </style>
    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>

    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

    <script>


        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {
                //$au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();


            });
        })(jQuery);





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
      // evm-0023for not allowing enter
      function DisableEnter(evt) {
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


  </script>

    <script>
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }


        //evm-0023 Confirmation while Cancelling
        function ConfirmMessage() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href = "gen_Job_Notification_List.aspx";
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_Job_Notification_List.aspx";

            }
        }



        function SuccessConfirmation() {

            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Job notification sent sucessfully.";
        }
        function ShowLoading() {

            document.getElementById("myModalLoadingMail").style.display = "block";

            document.getElementById("freezelayer").style.display = "";
        }
        function HideLoading() {

            document.getElementById("myModalLoadingMail").style.display = "none";

            document.getElementById("freezelayer").style.display = "none";
        }

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            HideLoading();


            document.getElementById("<%=HiddenEmpIds.ClientID%>").value = "";

            if (document.getElementById("<%=cbxInterOffice.ClientID%>").checked == true) {
                $('#divInterOfficeContainer').css({ opacity: 0, display: "block" }).animate({ opacity: 1 }, 700);
            }
            else {
                $('#divInterOfficeContainer').css({ opacity: 1, display: "none" }).animate({ opacity: 0 }, 700);
            }


            if (document.getElementById("<%=HiddenEmpIdsEdit.ClientID%>").value != "") {
                var TotalEmp = document.getElementById("<%=HiddenEmpIdsEdit.ClientID%>").value;

                EachEmp = TotalEmp.split('|');
                EachEmp.forEach(function (EMPDATA) {
                    if (EMPDATA != "") {
                        empSplit = EMPDATA.split(',');
                        AddRows(empSplit[0], empSplit[1])
                    }
                });
            }

        });

        function AddEmpToDiv() {

            IncrmntConfrmCounter();
            var EmployDdl = document.getElementById("<%=ddlEmployee.ClientID%>");
            var EmployText = EmployDdl.options[EmployDdl.selectedIndex].text;
            var EmployVal = EmployDdl.options[EmployDdl.selectedIndex].value;


            if (EmployVal != "--SELECT EMPLOYEE--") {

                var EmpDataFull = document.getElementById("<%=HiddenEmpIds.ClientID%>").value;

                if (EmpDataFull.indexOf(EmployVal) !== -1) {
                    alert('Already selected employee.');
                }
                else {
                    AddRows(EmployVal, EmployText);
                }
            }
        }

        function RemoveEmpLoyeDiv(count, empId) {


            var Filerow_index = jQuery('#rowId_' + count).index();

            jQuery('#rowId_' + count).remove();

            var EmpDataFull = document.getElementById("<%=HiddenEmpIds.ClientID%>").value;
            if (EmpDataFull != "") {
                var EachEmp = EmpDataFull.split(',');
                var newFullEmp = ""
                for (var i = 0; i < EachEmp.length; i++) {

                    if (EachEmp[i] == empId) {

                    }
                    else {
                        newFullEmp = newFullEmp + ',' + EachEmp[i];
                    }

                    //Do something
                }
                document.getElementById("<%=HiddenEmpIds.ClientID%>").value = newFullEmp;
                }

            }

            function AddEmpTostring(Empid) {
                var EmpDataFull = document.getElementById("<%=HiddenEmpIds.ClientID%>").value;


            if (EmpDataFull != "") {
                EmpDataFull = EmpDataFull + ',' + Empid
            }
            else {
                EmpDataFull = Empid;
            }

            document.getElementById("<%=HiddenEmpIds.ClientID%>").value = EmpDataFull;

        }


        function validateNotify() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

            var chkDiv = $("#<%= cbxDivisionList.ClientID %> input:checkbox");

            var checkedornot = false;
            for (var i = 0; i < chkDiv.length; i++) {
                if (chkDiv[i].checked) {
                    checkedornot = true;
                    break;
                }
            }

            if (checkedornot == false) {
                var chkDep = $("#<%= cbxDepartmntList.ClientID %> input:checkbox");


                for (var i = 0; i < chkDep.length; i++) {
                    if (chkDep[i].checked) {
                        checkedornot = true;
                        break;
                    }
                }
            }
            if (checkedornot == false) {
                var chkConsl = $("#<%= chkbxListConsultancy.ClientID %> input:checkbox");


                for (var i = 0; i < chkConsl.length; i++) {
                    if (chkConsl[i].checked) {
                        checkedornot = true;
                        break;
                    }
                }
            }

            if (checkedornot == true) {
                ret = true
            }
            else {
                ret = false;
            }

            if (ret == false && document.getElementById("<%=HiddenEmpIds.ClientID%>").value == "") {

                ret = false;
            }
            else {
                ret = true;
            }
            if (ret == false) {
                CheckSubmitZero();

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please select atleast one recipient to continue.";
            }
            else {
                ShowLoading();
            }


            return ret;
        }
    </script>
    <script>

        var rowCountEmp = 0;

        function InitializeEmp() {
            rowCountEmp = 0;
        }
        function AddRows(Empid, EmpName) {
            rowCountEmp++;

            var recRow = '<tr id="rowId_' + rowCountEmp + '" style=\"font-size: 14px;font-family: calibri;\" >';
            recRow += '<td>';
            recRow += '<div style="float:left;width:95%;height: 40px;margin: 8px;border: 2px solid #105fa2;background: #d1ddff;max-width: 254px;">';
            recRow += '<div style="float:left;width:80%">';
            recRow += '<div id="EmpName_"' + rowCountEmp + '" style="float:left;width:100%;word-wrap: break-word;padding: 5px;height: 33px;overflow: auto;">' + EmpName + '</div>';
            recRow += '</div>';
            recRow += '<div style="float:right;width:19%">';
            recRow += '<input id="inputDeleteRow_' + rowCountEmp + '" src="/Images/Icons/eachtempclose.png" alt="delete" onclick ="RemoveEmpLoyeDiv(' + rowCountEmp + ',' + Empid + ');" style="cursor: pointer;margin-top: 9%;margin-left: 16%;" type="image" />'
            recRow += '</div>';
            recRow += '</div>';
            recRow += '</td>';
            recRow += '<td id="EmpId' + rowCountEmp + '" style="display: none;">' + Empid + '</td>';
            recRow += '</tr>'

            jQuery('#TableEmployee').append(recRow);

            AddEmpTostring(Empid);

        }



        function InterClick() {
            IncrmntConfrmCounter();
            if (document.getElementById("<%=cbxInterOffice.ClientID%>").checked == true) {
                //$("#divInterOfficeContainer").fadeOut("slow");
                $('#divInterOfficeContainer').css({ opacity: 0, display: "block" }).animate({ opacity: 1 }, 700);
            }
            else {
                $('#divInterOfficeContainer').css({ opacity: 1, display: "none" }).animate({ opacity: 0 }, 700);
            }
        }

        function selectNone() {
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="HiddenConsultancyId" runat="server" />
    <asp:HiddenField ID="HiddenEmpIds" runat="server" />
    <asp:HiddenField ID="HiddenEmpIdsEdit" runat="server" />
    <asp:HiddenField ID="HiddenIsInterOfice" runat="server" />
    <asp:HiddenField ID="HiddenFieldClose" runat="server" />
    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 5%; top: 42%; height: 26.5px;">
    </div>
    <div class="cont_rght">



        <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: white; float: left;margin-bottom: 2%;">
            <div id="divReportCaption" style="width: 100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; float: left">
                <asp:Label ID="lblEntry" runat="server">Job Notification</asp:Label>
            </div>

            <div style="float: left; width: 80%; padding: 10px; margin-top: 2%; border: 1px solid #929292; background-color: #c9c9c9; margin-left: 10%;">

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
                    <asp:Label ID="lblReqDate" class="lblTop" Style="display: none" runat="server"></asp:Label>
                    <asp:Label ID="lblPayRange" class="lblTop" Style="display: none" runat="server"></asp:Label>
                </div>
            </div>
            <div>

                <div style="float: left; width: 82%; margin-top: 2%; margin-left: 10%;">
                    <h2 style="color: #662f00; float: left; font-size: 18px;">Consultancies  : </h2>

                    <div style="float: right; width: 42.5%;  margin-right: 24%; padding: 10px; background-color: #f6f6f6; border: 1px solid #959393; overflow: auto;max-height: 158px;">
                        <div id="divCheckBox" runat="server" style="font-size: 14px;">
                            <asp:CheckBoxList ID="chkbxListConsultancy" onkeypress="return DisableEnter(event)" Style="font-family: calibri; color: #023b01;" runat="server">
                            </asp:CheckBoxList>
                        </div>
                    </div>


                </div>
                <div style="width: 82%; float: left; margin-top: 3%; margin-bottom: 1%; margin-left: 10%;">
                    <h2 style="color: #662f00; float: left; font-size: 18px;">Inter Office Communication : </h2>
                    <asp:CheckBox ID="cbxInterOffice" onkeypress="return DisableEnter(event)" Style="font-size: 18px; color: #013b20; font-family: Calibri; float: right; margin-right: 67%;" runat="server" onchange="InterClick()" Text="" />
                </div>
            <div id="divInterOfficeContainer" style="float: left; width: 98%; display: block; padding: 10px; opacity: 1;background-color: #efefef;">

                <div style="float:left;width:37%;margin-left: 9%;margin-top: 2%;">
                    <div style="float:left;width:20%;margin-top:20%">
                         <h2 style="color: #603504;">Divisions  :</h2>
                    </div>
                    <div style="float:left;width:70%;margin-left:9%;height: 160px;border: 2px solid #79a6b7;background-color: white;overflow:auto;font-size: 14px;">
                         <asp:CheckBoxList  ID="cbxDivisionList" onkeypress="return DisableEnter(event)" style="font-family: calibri;color: #003202;"  runat="server">

                        </asp:CheckBoxList>
                    </div>

                </div>
                <div style="float:left;width:37%;margin-left: 6%;margin-top: 2%;">
                    <div style="float:left;width:28%;margin-top:20%">
                         <h2 style="color: #603504;">Departments  :</h2>
                    </div>
                    <div style="float:left;width:70%;margin-left:1%;height: 160px;border: 2px solid #79a6b7;background-color: white;overflow:auto;font-size: 14px;">
                         <asp:CheckBoxList  ID="cbxDepartmntList" onkeypress="return DisableEnter(event)" style="font-family: calibri;color: #003202;"  runat="server">

                        </asp:CheckBoxList>
                    </div>
                     </div>

                <div style="width:98%;float:left;margin-top: 3%;background-color: #d3d8d7;padding: 10px;">
                    <div style="width:35%;margin-top:8%;float: left;border: 2px solid aliceblue;padding: 6px;margin-left: 9%;">
                        <h2 style="color: #603504;margin-top: 3px;">Employee  :</h2>
                         <asp:DropDownList ID="ddlEmployee" runat="server" onblur="selectNone();" onchange="AddEmpToDiv();" AutoPostBack="false" Style="height:24px;width:66%;float:left; margin-left: 8%;">
                         </asp:DropDownList>

                    </div>
                    <div style="float: left;margin-top: 8.3%;margin-left: 8%;">
                        <img src="../../../Images/Icons/right_length arrow.png" style="width: 73px;" />
                    </div>
                    <div style="float:left;width:25%;margin-left: 10%;height: 200px;margin-top: 1%;background-color: white;overflow:auto">
                        <table id="TableEmployee" style="width: 97%;">
                          
                    </table>
                    </div>
                </div>

            </div>
            </div>
            <div style="float: left; width: 28%; padding: 5px; background: white; margin-left: 35%; margin-top: 2%;">
                <asp:Button ID="btnSend" runat="server" class="save" Text="Send" OnClick="btnSend_Click" OnClientClick="return validateNotify()" onkeypress="return DisableEnter(event)"/>
                <asp:Button ID="btnCancel" runat="server" class="save" Text="Cancel" OnClientClick="return ConfirmMessage();" OnClick="btnClear_Click"/>
            </div>
        </div>

    </div>
    <div id="myModalLoadingMail" class="modalLoadingMail">

        <!-- Modal content -->
        <div>

            <img src="/Images/Other Images/LoadingMail.gif" style="width: 12%;" />


        </div>

    </div>
    <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
        class="freezelayer" id="freezelayer">
    </div>
    <style>
        .cont_rght {
            width: 97%;
        }

        .save {
            width: 44%;
        }

        .lblTop {
            width: 232px;
            padding: 0px 8px;
            border: 1px solid #cfcccc;
            float: right;
            color: #000;
            font-size: 14px;
            font-family: calibri;
            word-wrap: break-word;
        }

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

        /* Modal Content */
        .modal-contentLoadingMail {
            /*position: relative;*/
            background-color: #fefefe;
            margin: auto;
            padding: 0;
            /*border: 1px solid #888;*/
            width: 95.6%;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
        }
    </style>
</asp:Content>

