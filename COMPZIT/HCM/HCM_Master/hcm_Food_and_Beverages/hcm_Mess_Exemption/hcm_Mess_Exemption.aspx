<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Mess_Exemption.aspx.cs" Inherits="HCM_HCM_Master_hcm_Food_and_Beverages_hcm_Mess_Exemption_hcm_Mess_Exemption" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

 <script src="/JavaScript/multiselect/jQuery/jquery-3.1.1.min.js"></script>
       <%-- for datetime picker--%>
    <script src="/JavaScript/datepicker/bootstrap-datepicker.js"></script>
    <link href="/JavaScript/datepicker/datepicker3.css" rel="stylesheet" />
    <script type="text/javascript">

        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }

        function SuccessSave() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Mess exemption details inserted successfully.";
        }
        function MessDuplication() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry.Duplication occur in time";
        }
        // for not allowing enter
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

       var $noCon = jQuery.noConflict();
        
       $noCon(function () {
            ddlAccoChange();
            document.getElementById("freezelayer").style.display = "none";
            document.getElementById("MymodalPopUp").style.display = "none";
            document.getElementById('divPopUpError').style.display = "";
            $noCon('#cphMain_txtFromDate').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
               // startDate: new Date()
            });
            $noCon('#cphMain_txtToDate').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                //startDate: new Date()
            });



            confirmbox = 0;
        });

       function ddlAccoChange() {
           IncrmntConfrmCounter();
            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
           var AccoId = document.getElementById("<%=ddlAccomo.ClientID%>").value;
           var skillsSelect = document.getElementById("<%=ddlAccomo.ClientID%>");
           var AccoName = skillsSelect.options[skillsSelect.selectedIndex].text;
           var From_date2 = document.getElementById("<%=txtFromDate2.ClientID%>").value;
           
           var To_date2 = document.getElementById("<%=txtToDate2.ClientID%>").value;
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "hcm_Mess_Exemption.aspx/ConvertDataTableToHTML",
                //data: '{intCorpId: "' + CorpId + '",intOrgId:"' + OrgId + '",intAccoId:"' + AccoId +'"}',
                //evm-0023
                 data: '{intCorpId: "' + CorpId + '",intOrgId:"' + OrgId + '",intAccoId:"' + AccoId +'", strAccoName:"' + AccoName + '",datFrom:"' + From_date2 + '",datTo:"' + To_date2 + '"}',
                dataType: "json",
                success: function (data) {
                    document.getElementById("<%=divReport.ClientID%>").innerHTML = data.d[0];
                    document.getElementById("<%=lblNo_OfEmp.ClientID%>").innerText = data.d[1];
                  
                }

            });
        }

        function OpenPopUp(UserId) {
            document.getElementById('divPopUpError').style.visibility = "hidden"; //evm-0023
            document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";

            
         

            document.getElementById("<%=hiddenEmployeeId.ClientID%>").value = UserId;
            document.getElementById("freezelayer").style.display = "";
            document.getElementById("MymodalPopUp").style.display = "block";

            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
            var AccoId = document.getElementById("<%=ddlAccomo.ClientID%>").value;
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "hcm_Mess_Exemption.aspx/ReadAndFillUserData",
                data: '{intCorpId: "' + CorpId + '",intOrgId:"' + OrgId + '",intUserId:"' + UserId + '"}',
                dataType: "json",
                success: function (data) {
                    document.getElementById("<%=lblName.ClientID%>").innerHTML = data.d[0];
                    document.getElementById("<%=lblDesign.ClientID%>").innerText = data.d[1];
                    document.getElementById("<%=lblDivision.ClientID%>").innerText = data.d[3];
                    document.getElementById("<%=lblAccomod.ClientID%>").innerText = data.d[2];
                }

            });

        }

        function ClosePopUp()
        {
            document.getElementById("freezelayer").style.display = "none";
            document.getElementById("MymodalPopUp").style.display = "none";
            ClearTextBx();
        }


        //evm-0023 fn
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
     
   

            //evm-0023
            var From_date2 = document.getElementById("<%=txtFromDate2.ClientID%>").value.trim();
            var To_date2 = document.getElementById("<%=txtToDate2.ClientID%>").value.trim();
            var frmdate = document.getElementById("<%=txtFromDate.ClientID%>").value.trim();
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
                
                var arrDatePickerDate = todate.split("-");
                todate = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);
               
                var arrDatePickerDate2 = From_date2.split("-");
                From_date2 = new Date(arrDatePickerDate2[2], arrDatePickerDate2[1] - 1, arrDatePickerDate2[0]);
                var arrDatePickerDate3 = To_date2.split("-");

                To_date2 = new Date(arrDatePickerDate3[2], arrDatePickerDate3[1] - 1, arrDatePickerDate3[0]);
              
                if (frmdate > todate) {
                    document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtFromDate.ClientID%>").focus();
                    document.getElementById('divPopUpError').style.visibility = "visible";
                    document.getElementById('lblPopUpError').innerHTML = "Sorry,from date cannot be greater than to date !.";
                    ret = false;
                    }


                   if (todate < From_date2) {
                   document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                   document.getElementById("<%=txtToDate.ClientID%>").focus();
                   document.getElementById('divPopUpError').style.visibility = "visible";
                   document.getElementById('lblPopUpError').innerHTML = "Sorry, invalid date !.";
                   ret = false;
                   }

                if (frmdate > To_date2) {
                    document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtFromDate.ClientID%>").focus();
                    document.getElementById('divPopUpError').style.visibility = "visible";
                    //document.getElementById('lblPopUpError').innerHTML = "";
                    document.getElementById('lblPopUpError').innerHTML = "Sorry, invalid date !.";
                  ret = false;
                }



            }
            else {
                if (todate == "") {
                    document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtToDate.ClientID%>").focus();
                }
                if (frmdate == "") {
                    document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtFromDate.ClientID%>").focus();
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
            if (confirmbox > 0 ) {
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


        function ConfirmCancel()
        {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to close the window?")) {
                    ClosePopUp();
                    ClearTextBx();
                    confirmbox = 0;
                }
                else {
                    return false;
                }
            }
            else {
                ClosePopUp();
                ClearTextBx();

            }
        }

        function ClearTextBx() {
            document.getElementById("<%=txtToDate.ClientID%>").value="";
            document.getElementById("<%=txtFromDate.ClientID%>").value = "";

            //evm-0023
            document.getElementById("<%=txtToDate2.ClientID%>").value = "";
            document.getElementById("<%=txtFromDate2.ClientID%>").value = "";
        }
    </script>

    <%--//evm-0023--%>
        <script>
            var $noConfi = jQuery.noConflict();
            $noConfi(function () {
                $noConfi('#cphMain_txtFromDate2').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    language: 'en',               
                });
                $noConfi('#cphMain_txtToDate2').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    language: 'en',                  
                });
            });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">

    <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="hiddenMessExceptionId" runat="server" />

     <asp:HiddenField ID="hiddenEmployeeId" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
     <div id="div1" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 0%; top: 22%; height: 26.5px;">


        </div>
    <div class="cont_rght">

        <div id="divReportCaption" style="width: 100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; float: left">
            <asp:Label ID="lblEntry" runat="server">Employee Mess Exemption</asp:Label>
        </div>

        <%--evm-0023 grey style--%>
         <div style="border: .5px solid #9ba48b; background-color: #f3f3f3; width: 100%; margin-top: 0.5%; float: left">
        <div class="eachform" style="width: 49%; margin-top: 2.5%; margin-left: 2%; float: left;">
            <h2 style="margin-top: 1%;">Accommodation</h2>
            <asp:DropDownList ID="ddlAccomo" class="form1" OnChange="ddlAccoChange()" runat="server" Style="width: 43%; float: right; margin-right: 29%;">
            </asp:DropDownList>

        </div>

            <%-- evm-0023 From Date*  To Date*--%>
          <div class="eachform" style="width: 49%; margin-top: -3.5%; margin-left: 49%; float: left;">
                <h2 style="margin-top: 1%; margin-left: 13%;">From Date*</h2>
                <asp:TextBox ID="txtFromDate2" class="form1" runat="server" OnChange="ddlAccoChange()" onkeydown="return DisableEnter(event)" Style="width: 40%; float: right; margin-right: 15%;">
                </asp:TextBox>
            </div>


        <div class="eachform" style="width: 49%; margin-top: 0.5%; margin-left: 2%; float: left;">
            <h2 style="margin-top: 1%;">No Of Employees</h2>
            <asp:Label ID="lblNo_OfEmp" class="form1" runat="server" Style="width: 40%; float: right; margin-right: 29%;font-size: 15px;padding-top: 4px;height: 25px;">
            </asp:Label>

        </div>

           <div class="eachform" style="width: 49%; margin-top: -3.5%; float: left;margin-left: 54%;">
                <h2 style="margin-top: 1%; margin-left: 3%;">To Date*</h2>
                <asp:TextBox ID="txtToDate2" class="form1" runat="server" OnChange="ddlAccoChange()" onkeydown="return DisableEnter(event)" Style="width: 40%; float: right; margin-right: 25%;">
                </asp:TextBox>

            </div>
            </div>

        <%--evm-0023 width nd margin top--%>

        <div id="divReport" class="table-responsive" runat="server" style="float: left; width: 100%; margin-top: 2%;">
        </div>

    </div>
    <div id="MymodalPopUp" class="MyModalPopUp">
        <div id="div2">
            <div id="Div3" style="height: 30px; background-color: #6f7b5a;">

                <label style="margin-left: 38%; font-size: 18px; color: #fff; font-family: calibri;">Add Mess Exemption</label>

                <img class="closeCancelView" style="margin-top: .5%; margin-right: 1%; float: right; cursor: pointer;" onclick="return ClosePopUp();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
            </div>
            <div id="divPopUpError" style="visibility: visible; font-family: Calibri; float: left; width: 60%;margin-left: 21%;margin-top: 1%;">
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
                        <%--evm-0023 ***--%>
                        <h2 style="margin-top: 1%;margin-left: 16%;">From Date*</h2>
                        <asp:TextBox ID="txtFromDate" class="form1" OnChange="ddlAccoChange()" runat="server" Style="width: 43%; float: left; margin-left: 8%;">
                        </asp:TextBox>

                    </div>
                    <div class="eachform" style="width: 48%; margin-top: 2.5%; margin-left: 2%; float: left;">
                        <%--evm-0023 ***--%>
                        <h2 style="margin-top: 1%;">To Date*</h2>
                        <asp:TextBox ID="txtToDate" class="form1" OnChange="ddlAccoChange()" runat="server" Style="width: 43%; float: left; margin-left: 8%;">
                        </asp:TextBox>

                    </div>
                </div>


                <asp:Button ID="btnExceptSave" class="save" runat="server" Text="Save" Style="width: 105px;margin-top: 7%; float: left; margin-left: 38%;" OnClientClick="return ValidateMessExcept()" OnClick="btnExceptSave_Click" />
                <input type="button" id="btnProcessSingleCancel" onclick="ConfirmCancel();" class="save" style="width: 105px;margin-top: 7%; float: left;" value="Cancel" />

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

