<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Mess_Exemption_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_Food_and_Beverages_hcm_Mess_Exemption_hcm_Mess_Exemption_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <style>
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

   
    <script type="text/javascript">

        function SuccessUpdate() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById('lblMessageArea').innerHTML = "Mess exemption details updated successfully.";
        }
        function MessDuplication() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById('lblMessageArea').innerHTML = "Sorry.Duplication occur in time";
        }
        function getdetails(href) {
            window.location = href;
            return false;
        }


    </script>

    <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
            });
        });


    </script>

   
        <script src="/JavaScript/multiselect/jQuery/jquery-3.1.1.min.js"></script>
       <%-- for datetime picker--%>
    <script src="/JavaScript/datepicker/bootstrap-datepicker.js"></script>
    <link href="/JavaScript/datepicker/datepicker3.css" rel="stylesheet" />




    <script>

        var $noCon = jQuery.noConflict();
        var $au = jQuery.noConflict();
        $noCon(function () {

            document.getElementById("freezelayer").style.display = "none";
            document.getElementById("MymodalPopUp").style.display = "none";
            $noCon('#cphMain_txtFromDate').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                forceParse: false,
                // startDate: new Date()
            });
            $noCon('#cphMain_txtToDate').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                forceParse: false,
                startDate: new Date()
            });
            $noCon('#cphMain_txtFromDateSrch').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
               // forceParse: false,
               // startDate: new Date()
            });
            $noCon('#cphMain_txtTodateSrch').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
               // forceParse: false,
              //  startDate: new Date()
            });

           
        });


      


    </script>
            <script src="/JavaScript/jquery-1.8.3.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>
        (function ($au) {
            $au(function () {

                $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
                $au("div#divempcontainer input.ui-autocomplete-input").focus();

            });
        })(jQuery);
    </script>
   

    <script>
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }
        function OpenPopUp(UserId,MessExId) {
          
                document.getElementById("<%=hiddenMessExId.ClientID%>").value = MessExId;
                document.getElementById("freezelayer").style.display = "";
                document.getElementById("MymodalPopUp").style.display = "block";

                var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
                var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;

                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "hcm_Mess_Exemption_List.aspx/ReadAndFillUserData",
                    data: '{intCorpId: "' + CorpId + '",intOrgId:"' + OrgId + '",intUserId:"' + UserId + '"}',
                    dataType: "json",
                    success: function (data) {
                        document.getElementById("<%=lblName.ClientID%>").innerHTML = data.d[0];
                    document.getElementById("<%=lblDesign.ClientID%>").innerText = data.d[1];
                    document.getElementById("<%=lblDivision.ClientID%>").innerText = data.d[3];
                    document.getElementById("<%=lblAccomod.ClientID%>").innerText = data.d[2];


                }

                });

            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "hcm_Mess_Exemption_List.aspx/ReadAndFillMessExcept",
                data: '{intCorpId: "' + CorpId + '",intOrgId:"' + OrgId + '",intMesExId: "' + MessExId + '"}',
                dataType: "json",
                success: function (data) {
                    document.getElementById("<%=txtFromDate.ClientID%>").value = data.d[0];
                    document.getElementById("<%=txtToDate.ClientID%>").value = data.d[1];

                    }

            });

        }

        function ClosePopUp() {
            document.getElementById("freezelayer").style.display = "none";
            document.getElementById("MymodalPopUp").style.display = "none";
        }
        function ValidateMessExcept() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            document.getElementById('divPopUpError').style.visibility = "hidden";

            document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";

            var frmdate = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var todate = document.getElementById("<%=txtToDate.ClientID%>").value.trim();

            var testFrm = frmdate.match(/^(\d{2})\-(\d{2})\-(\d{4})$/);
            if (testFrm === null) {
                document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                ret = false;
            }

            var testTo = todate.match(/^(\d{2})\-(\d{2})\-(\d{4})$/);
            if (testTo === null) {
                document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                ret = false;
            }


            if (frmdate != "" && todate != "") {
                var arrDatePickerDate1 = frmdate.split("-");
                frmdate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

                var arrDatePickerDate1 = todate.split("-");
                todate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
                if (frmdate > todate) {
                    document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtFromDate.ClientID%>").focus();
                    document.getElementById('divPopUpError').style.visibility = "visible";
                    document.getElementById('lblPopUpError').innerHTML = "Sorry,from date cannot be greater than to date !.";
                    ret = false;
                }
            }
            else {

                if (frmdate == "") {
                    document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtFromDate.ClientID%>").focus();
                }
                if (todate == "") {
                    document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                     document.getElementById("<%=txtToDate.ClientID%>").focus();
                 }

                ret = false;
            }
            if (ret == false) {
                CheckSubmitZero();

            }

            return ret;
        }

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

        function ConfirmMessage() {
            if (confirmbox > 0) {
                if (confirm("Are You Sure You Want To Leave This Page?")) {
                    window.location.href = "hcm_Mess_Exemption_List.aspx";
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "hcm_Mess_Exemption_List.aspx";

            }
        }

        function SearchValidation() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

            var $NocF = jQuery.noConflict();
            $NocF("div#divempcontainer input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById("<%=txtFromDateSrch.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTodateSrch.ClientID%>").style.borderColor = "";

            var frmdate = document.getElementById("<%=txtFromDateSrch.ClientID%>").value;
            var todate = document.getElementById("<%=txtTodateSrch.ClientID%>").value.trim();
            var Employee = document.getElementById("<%=ddlEmployee.ClientID%>").value.trim();
           

            var testFrm = frmdate.match(/^(\d{2})\-(\d{2})\-(\d{4})$/);
            //if (testFrm === null) {      emp25
                //document.getElementById("<%=txtFromDateSrch.ClientID%>").style.borderColor = "Red";
               // ret = false;
            //}

            var testTo = todate.match(/^(\d{2})\-(\d{2})\-(\d{4})$/);
           // if (testTo === null) {
               // document.getElementById("<%=txtTodateSrch.ClientID%>").style.borderColor = "Red";
              //  ret = false;
           // }
            if (frmdate != "" && todate != "") {
                var arrDatePickerDate1 = frmdate.split("-");
                frmdate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

                var arrDatePickerDate1 = todate.split("-");
                todate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
                if (frmdate > todate) {
            
                    document.getElementById("<%=txtFromDateSrch.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtFromDateSrch.ClientID%>").focus();
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('lblMessageArea').innerHTML = "Sorry,from date cannot be greater than to date !.";
 
                    ret = false;
                   
                }
            }
            else {



            }


            if (Employee == "--SELECT EMPLOYEE--") {
                //document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "Red";
                 //document.getElementById("<%=ddlEmployee.ClientID%>").focus();
                 var $NocF = jQuery.noConflict();
                 $NocF("div#divempcontainer input.ui-autocomplete-input").css("borderColor", "red");
                 $NocF("div#divempcontainer input.ui-autocomplete-input").focus();
                 ret = false;
             }
            if (ret == false) {
                CheckSubmitZero();

            }

            return ret;
        }
        function ConfirmCancel() {
            if (confirm("Are you sure you want to cancel") == true) {
                document.getElementById("freezelayer").style.display = "none";
                document.getElementById("MymodalPopUp").style.display = "none";

            }
            else
                return false;
        }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
      <asp:HiddenField ID="hiddenMessExId" runat="server" />
      <asp:HiddenField ID="hiddenCorporateId" runat="server" />
      <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />

    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea"></asp:Label>
    </div>

    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="/Images/BigIcons/mess exemption.png" style="vertical-align: middle;" />
            Employee Mess Exemption List
        </div>
        <div style="border: .5px solid; border-color: #9ba48b; background-color: #f3f3f3; width: 97.5%; margin-top: 0.5%; height: 10%;">




            <div style="width: 100%; float: left; margin-top: 14px">
                <div id="divempcontainer" class="eachform" style="width: 30%; margin-top: 0.5%; margin-left: 2%; float: left;">

                    <h2 style="margin-top: 1%;">Employee*</h2>
                    <div style="height: 30px; height: 25px; width: 69%; float: left; margin-left: 8%;">
                    <asp:DropDownList ID="ddlEmployee" runat="server" class="form1" txtFromDateSrchonkeypress="return DisableEnter(event)">
                    </asp:DropDownList>
                    </div>

                </div>
                   <div class="eachform" style="float:left;width:25%;margin-top:.5%;margin-left:4%;">
                <h2 style="margin-top: 2%;">From Date</h2>
                
               <div id="div1" class="input-append date" style="float:right;margin-right:25%;width: 42%;">

                        <asp:TextBox ID="txtFromDateSrch" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="height:30px;width:100%;margin-top: 0%;float:left;margin-left: -2.3%;"></asp:TextBox>

                       </div>
              

            </div>
      

      <div class="eachform" style="float:left;width:25%;margin-top:.5%;margin-left:0%;">
                <h2 style="margin-top: 2%;">To Date</h2>
                
               <div id="div2" class="input-append date" style="float:right;margin-right:25%;width: 42%;">

                        <asp:TextBox ID="txtTodateSrch" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="height:30px;width:100%;margin-top: 0%;float:left;margin-left: -2.3%;"></asp:TextBox>

                       
                       </div>
              

            </div>

                <div class="eachform" style="width: 13%; float: left;">
                    <asp:Button ID="btnSearch" Style="cursor: pointer; margin-top: 2.6%; margin-left: 10%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />
                </div>
            </div>


            <br style="clear: both" />
        </div>
        <br />
        
        <div onclick="location.href='hcm_Mess_Exemption.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;">
             </div>
        <div id="divReport" class="table-responsive" style="width: 97.5%;" runat="server">

        </div>


    </div>

     <div id="MymodalPopUp" class="MyModalPopUp">
        <div id="div3">
            <div id="Div4" style="height: 30px; background-color: #6f7b5a;">

                <label style="margin-left: 38%; font-size: 18px; color: #fff; font-family: calibri;">Edit Employee Mess Exemption</label>

                <img class="closeCancelView" style="margin-top: .5%; margin-right: 1%; float: right; cursor: pointer;" onclick="return ClosePopUp();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
            </div>
            <div id="divPopUpError" style="visibility: hidden; font-family: Calibri; float: left; width: 60%;">
               <span id="lblPopUpError" style="width: 99%;float: left;text-align: center;color: #438943;border: 2px solid;"></span>
             </div>
            <div style="float: left;height:100%; margin: 13px; border: 1px solid; border-color: #d7c9c9; background-color: #fff; margin-bottom: 6px; width: 97%;">

                <div id="divPopUpTop" style="width: 91%; float: left; margin-top: .5%; padding: 16px; margin-left: 3%; background-color: #ded2d2;">

                    <div class="eachform" style="width: 47%; float: left;">
                        <h2 style="color: #603504;">Employee</h2>
                        <asp:Label ID="lblName" class="lblTop" runat="server"></asp:Label>
                    </div>
                    <div class="eachform" style="width: 47%; float: right;">
                        <h2 style="color: #603504;">Designation</h2>
                        <asp:Label ID="lblDesign" class="lblTop" runat="server"></asp:Label>
                    </div>
                    <div class="eachform" style="width: 47%; float: left;">
                        <h2 style="color: #603504;">Division</h2>
                        <asp:Label ID="lblDivision" class="lblTop" runat="server"></asp:Label>
                    </div>
                    <div class="eachform" style="width: 47%; float: right;">
                        <h2 style="color: #603504;">Accommodation</h2>
                        <asp:Label ID="lblAccomod" class="lblTop" runat="server"></asp:Label>
                    </div>

                </div>



                <div id="div5" style="float: left; width: 100%;margin-top: 5%;">
                    <div class="eachform" style="width: 48%; margin-top: 2.5%; margin-left: 2%; float: left;">
                        <h2 style="margin-top: 1%;margin-left: 16%;">From Date</h2>
                        <asp:TextBox ID="txtFromDate" class="form1" OnChange="ddlAccoChange()" runat="server" Style="width: 43%; float: left; margin-left: 8%;">
                        </asp:TextBox>

                    </div>
                    <div class="eachform" style="width: 48%; margin-top: 2.5%; margin-left: 2%; float: left;">
                        <h2 style="margin-top: 1%;">To Date</h2>
                        <asp:TextBox ID="txtToDate" class="form1" OnChange="ddlAccoChange()" runat="server" Style="width: 43%; float: left; margin-left: 8%;">
                        </asp:TextBox>

                    </div>
                </div>


                <asp:Button ID="btnExceptUpdate" class="save" runat="server" Text="Update" Style="width: 105px;margin-top: 7%; float: left; margin-left: 38%;" OnClientClick="return ValidateMessExcept()" OnClick="btnExceptUpdate_Click" />
                <input type="button" id="btnProcessSingleCancel" onclick="return ConfirmCancel();" class="save" style="width: 105px;margin-top: 7%; float: left;" value="Cancel" />

            </div>
        </div>

    </div>

    <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: black; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.8; z-index: 29; height: auto !important;"
        class="freezelayer" id="freezelayer">
    </div>
     <style>
        .MyModalPopUp {
            display: none;
            position: fixed;
            z-index: 100;
            padding-top: 0%;
            left: 18%;
            top: 15%;
            width: 66%;
            height: 360px;
            overflow: auto;
            background-color: white;
            border: 3px solid;
            border-color: #6f7b5a;
        }

        .cont_rght {
            width: 97%;
        }
         .datepicker table tr td, .datepicker table tr th {
            text-align: center;
            width: 0px;
            height: 0px;
            border-radius: 4px;
            border: none;
        }

        .table > thead > tr > th {
            vertical-align: bottom;
            background: #7b7b7b;
            color: #fff;
        }

        .datepicker table tr td.disabled, .datepicker table tr td.disabled:hover {
            background: none;
            color: #c5c5c5;
            cursor: default;
        }
         .lblTop {
            width: 232px;
            padding: 0px 8px;
            float: right;
            color: #000;
            font-size: 14px;
            font-family: calibri;
            word-wrap: break-word;
        }
    </style>
</asp:Content>



