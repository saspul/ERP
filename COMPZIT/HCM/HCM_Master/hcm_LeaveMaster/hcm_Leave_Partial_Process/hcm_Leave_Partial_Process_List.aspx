<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Leave_Partial_Process_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_LeaveMaster_hcm_Leave_Partial_Process_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <style>
        .cont_rght {
            width: 98%;
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

         input[type="radio"] {
            display: table-cell;
        }
</style>
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
    <script src="/JavaScript/jquery-1.8.3.min.js"></script>
    <script>
    var $noCon = jQuery.noConflict();
    $noCon(window).load(function () {
        document.getElementById("<%=txtAssgndDate.ClientID%>").focus();
    });
    </script>

    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

    <script>
        var $au = jQuery.noConflict();
        (function ($au) {
            $au(function () {
                $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
                $au('form').submit(function () {
                });
            });
        })(jQuery);

    </script>

    <script>
        function getdetails(href) {
            window.location = href;
            return false;
        }

        // for not allowing <> tags
        function isTag(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

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

        function SearchValidation() {

            var ret = true;

            var datepickerDate = document.getElementById("<%=txtAssgndDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateFrmDt = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDate = document.getElementById("<%=txtToDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateToDt = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            if (dateFrmDt > dateToDt) {

                document.getElementById("<%=txtAssgndDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtAssgndDate.ClientID%>").focus();
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, from date cannot be less than to date!.";
                ret = false;
            }

            return ret;
        }

        function PartPrssId(id, levId) {

            var nWindow = window.open('/HCM/HCM_Master/hcm_LeaveMaster/hcm_Leave_Partial_Process/hcm_Leave_Partial_Process.aspx?Id=' + id + '&RFGP=VW&levId=' + levId + '', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
            // nWindow.focus();
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">


<asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenEnableModify" runat="server" />
    <asp:HiddenField ID="hiddenEnableAdd" runat="server" />

    <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">
    
    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="/Images/BigIcons/Leave Partial process.PNG" />
     Leave Partial Process
        </div >
        <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;width: 98%;margin-top:2%;padding: 1%;float: left;">

            <div style="float: left;width: 40%;border: .5px solid #9ba48b;">
            <h2 style="float: left;width: 30%;margin-left: 39%;color: #536533;font-size: 16px;">Assigned Date : </h2>

            <div class="eachform" style="float:left;width:48%;">
                <h2 style="margin-top: 4%;margin-left: 2%;">From Date</h2>
                
               <div id="divAssgndDate" class="input-append date" style="float: left;width: 59%;margin-left: 6%;">
                        
                 <asp:TextBox ID="txtAssgndDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  Style="height:30px;width:60.6%;margin-top: 4%;float:left;margin-left: 0%;" onkeypress="return DisableEnter(event)" onkeydown="return isTagEnter(event)" onblur="return isTag(event)"></asp:TextBox>

                        <input type="image"  id="Image1" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:4%;" />

                           <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                               <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
                           <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate1_8_3.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker_pt_br.js">
                            </script>
                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divAssgndDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //endDate: new Date(),
                            });
                        </script>

                        <p style="visibility: hidden">Please enter</p>
                       </div>

            </div>
      

      <div class="eachform" style="float:left;width:48%;margin-left: 3%;">
                <h2 style="margin-top: 4%;">To Date</h2>
                
                 <div id="divToDate" class="input-append date" style="float: left;width: 59%;margin-left: 6%;">

                  <asp:TextBox ID="txtToDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  Style="height:30px;width:60.6%;margin-top: 4%;float:left;margin-left: 0%;" onkeypress="return DisableEnter(event)" onkeydown="return isTagEnter(event)" onblur="return isTag(event)"></asp:TextBox>

                        <input type="image" id="Image2" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:4%;"  />
                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divToDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //startDate: new Date(),
                            });

                        </script>

                        <p style="visibility: hidden">Please enter</p>
                       </div>
            </div>
                    </div>
            <div style="float:left;width: 40%;margin-left:2%">
            <div class="eachform" style="margin-top:1%;width: 99%;float: left;">
         <h2 style="padding-top: 1%;">Employee : </h2>
        <asp:DropDownList ID="ddlEmployee" class="form1" runat="server" Style="height: 28px; width: 54%; float: left; margin-left: 7%;" onkeypress="return DisableEnter(event)">
           </asp:DropDownList>
        </div>

                <div class="eachform" style="margin-top:1%;margin-left:0.5%;">
                    <h2>Mode* :</h2>
                    <div style="float: right;width: 50%;margin-right: 28%;">
                        <asp:RadioButton ID="radioStaff" Text="Staff" runat="server" GroupName="Radio" Style="float: left; font-family: calibri" onkeypress="return DisableEnter(event)" />
                        <asp:RadioButton ID="radioWorker" Text="Worker" runat="server" GroupName="Radio" Style="float: left; font-family: calibri; margin-left: 6%;" onkeypress="return DisableEnter(event)" />
                        <asp:RadioButton ID="radioAll" Text="All" runat="server" Checked="true" GroupName="Radio" Style="float: left; font-family: calibri; margin-left: 6%;" onkeypress="return DisableEnter(event)" />
                    </div>
                 </div>

               </div>
             <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: 1.5%;float:right;margin-right:5%;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />

  </div>

          
        <br />
            <div id="divReport" class="table-responsive" style="float: left;width: 100%;margin-top: 2%;" runat="server">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>

        </div>


    <style>
     .open > .dropdown-menu {
    display: none;
}
     #ReportTable_filter input {
    height: 16px;
    width: 180px;
    color: #336B16;
    font-size: 14px;
}


    </style>


</asp:Content>

