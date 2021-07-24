<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="flt_Time_Sheet_Report.aspx.cs" Inherits="AWMS_AWMS_Reports_flt_Time_Sheet_Report_flt_Time_Sheet_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <%--FOR DATE TIME PICKER--%>

    <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        //var $p = jQuery.noConflict();
        //$p(document).ready(function () {
        //    $p('#ReportTable').DataTable({
        //        "pagingType": "full_numbers",
        //        "bSort": true,
        //        "pageLength": 25
        //    });
        //});


    </script>



    <style>
        #cphMain_divReport {
            float: left;
            width: 100%;
        }



        #TableRprtRow .tdT {
            line-height: 100%;
        }


        .cont_rght {
            width: 98%;
        }

        input[type="radio"] {
            display: block;
            float: left;
        }

        #divRadio {
            font-size: 15px;
            color: rgb(83, 101, 51);
            font-family: Calibri;
        }

        #divRadio2 {
            font-size: 15px;
            color: rgb(83, 101, 51);
            font-family: Calibri;
        }

        .bootstrap-datetimepicker-widget {
            z-index: 100;
        }
          input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
            cursor:default;
        }
    </style>
    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
           // document.getElementById("<%=radioDaily.ClientID%>").focus();
                //document.getElementById("<%=RadioDivision.ClientID%>").checked = true;
                var searchMode = document.getElementById("<%=hiddenSrchMode.ClientID%>").value;
                var subSearchMode = document.getElementById("<%=hiddenSubSrchMode.ClientID%>").value;
                if (searchMode == "") {
                    document.getElementById("<%=radioDaily.ClientID%>").checked = true;
                    ShowOrHideDiv('Daily');
                }
                else if (searchMode == "Daily") {
                    document.getElementById("<%=radioDaily.ClientID%>").checked = true;
                    ShowOrHideDiv('Daily');
                }
                else if (searchMode == "Monthly") {
                    document.getElementById("<%=radioMonthly.ClientID%>").checked = true;
                    ShowOrHideDiv('Monthly');
                }
                else if (searchMode == "Quarterly") {
                    document.getElementById("<%=radioQuarterly.ClientID%>").checked = true;
                    ShowOrHideDiv('Quarterly');
                }
                else if (searchMode == "Yearly") {
                    document.getElementById("<%=RadioYearly.ClientID%>").checked = true;
                    ShowOrHideDiv('Yearly');
                }
                else if (searchMode == "Custom") {
                    document.getElementById("<%=RadioCustom.ClientID%>").checked = true;
                        ShowOrHideDiv('Custom');
                    }
                if (subSearchMode == "") {
                    document.getElementById("<%=RadioDivision.ClientID%>").checked = true;
                    ShowOrHideDdl('Division');
                }
                else if (subSearchMode == "Division") {
                    document.getElementById("<%=RadioDivision.ClientID%>").checked = true;
                    ShowOrHideDdl('Division');
                }
                else if (subSearchMode == "Dept") {
                    document.getElementById("<%=RadioDept.ClientID%>").checked = true;
                        ShowOrHideDdl('Dept');
                    }


            });

    </script>
    <script>
        function ShowOrHideDiv(mode) {
            if (mode == "Daily") {

                document.getElementById('divDaily').style.display = "";
                document.getElementById('divMonthly').style.display = "none";
                document.getElementById('divQuarterly').style.display = "none";
                document.getElementById('divYearly').style.display = "none";
                document.getElementById('divCustom').style.display = "none";
            }
            else if (mode == "Monthly") {
                document.getElementById('divDaily').style.display = "none";
                document.getElementById('divMonthly').style.display = "";
                document.getElementById('divQuarterly').style.display = "none";
                document.getElementById('divYearly').style.display = "none";
                document.getElementById('divCustom').style.display = "none";
            }
            else if (mode == "Quarterly") {
                document.getElementById('divDaily').style.display = "none";
                document.getElementById('divMonthly').style.display = "none";
                document.getElementById('divQuarterly').style.display = "";
                document.getElementById('divYearly').style.display = "none";
                document.getElementById('divCustom').style.display = "none";
            }
            else if (mode == "Yearly") {
                document.getElementById('divDaily').style.display = "none";
                document.getElementById('divMonthly').style.display = "none";
                document.getElementById('divQuarterly').style.display = "none";
                document.getElementById('divYearly').style.display = "";
                document.getElementById('divCustom').style.display = "none";
            }
            else if (mode == "Custom") {
                document.getElementById('divDaily').style.display = "none";
                document.getElementById('divMonthly').style.display = "none";
                document.getElementById('divQuarterly').style.display = "none";
                document.getElementById('divYearly').style.display = "none";
                document.getElementById('divCustom').style.display = "";
            }
        }
        function ShowOrHideDdl(mode) {
            if (mode == "Division") {
                document.getElementById("<%=ddlDivision.ClientID%>").style.display = '';
                document.getElementById("<%=ddlDepartment.ClientID%>").style.display = 'none';
            }
            else if (mode == "Dept") {
                document.getElementById("<%=ddlDivision.ClientID%>").style.display = 'none';
                document.getElementById("<%=ddlDepartment.ClientID%>").style.display = '';

            }
    }
        function validate() {
        document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "";
           document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
           document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
           if (document.getElementById("<%=radioDaily.ClientID%>").checked == true) {
               var Date = document.getElementById("<%=txtDate.ClientID%>").value;
               if (Date == "") {
                   document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "Red";
                   document.getElementById("<%=txtDate.ClientID%>").focus();
                   return false;
               }
           }
           else if (document.getElementById("<%=RadioCustom.ClientID%>").checked == true) {
               ret = true;
               if (document.getElementById("<%=txtTodate.ClientID%>").value == "") {
                   document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "Red";
                   document.getElementById("<%=txtTodate.ClientID%>").focus();

                   ret = false;
               }
               if (document.getElementById("<%=txtFromDate.ClientID%>").value == "") {
                   document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                   document.getElementById("<%=txtFromDate.ClientID%>").focus();

                   ret = false;
               }
               
               if(validateDates()==false)
               {
                   ret = false;
               }
            return ret;
           }
    }
        function validateDates() {
            retDate = true;
            if (document.getElementById("<%=RadioCustom.ClientID%>").checked == true) {
                var dateofrqstfld = document.getElementById("<%=txtFromDate.ClientID%>").value.trim();

                var dateofrqst = document.getElementById("<%=txtFromDate.ClientID%>").value.trim();
                var arrDatePickerDate1 = dateofrqst.split("-");
                dateofrqst = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
                var rqrddatefld = document.getElementById("<%=txtTodate.ClientID%>").value.trim();

                var rqrddate = document.getElementById("<%=txtTodate.ClientID%>").value.trim();
                var arrDatePickerDate1 = rqrddate.split("-");
                rqrddate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

                if (dateofrqst > rqrddate) { //3emp17

                    document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtFromDate.ClientID%>").focus();
                    retDate = false;
                }
            }
            return retDate;
        }
        function clearDivision() {
            textToFind = "--SELECT DIVISION--";
            var ddlGteeTypeData = document.getElementById("<%=ddlDivision.ClientID%>");
            for (var i = 0; i < ddlGteeTypeData.options.length; i++) {
                if (ddlGteeTypeData.options[i].text === textToFind) {
                    ddlGteeTypeData.selectedIndex = i;
                    break;
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField runat="server" ID="hiddenSrchMode" />
    <asp:HiddenField runat="server" ID="hiddenSubSrchMode" />
    <asp:HiddenField runat="server" ID="hiddenNext" />
    <asp:HiddenField runat="server" ID="hiddenTotalRowCount" />
    
    <asp:HiddenField runat="server" ID="hiddenPrevious" />
    <asp:HiddenField runat="server" ID="hiddenMemorySize" />
     <asp:HiddenField runat="server" ID="HiddenMonthlySrch" />
        <asp:HiddenField runat="server" ID="HiddenDailySrch" />
      <asp:HiddenField runat="server" ID="HiddenYearlySrch" />
      <asp:HiddenField runat="server" ID="HiddenQurterlySrch" />
      <asp:HiddenField runat="server" ID="HiddenCustomSrch" />
      <asp:HiddenField runat="server" ID="HiddenEmployeeSrch" />
      <asp:HiddenField runat="server" ID="HiddenDivSrch" />
      <asp:HiddenField runat="server" ID="HiddenDeptSrch" />

    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
    <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 3.5%; font-family: Calibri;" class="print" onclick="printredirect()">
        <a id="print_cap" target="_blank" data-title="Item Listing" href="/AWMS/AWMS_Reports/Print/28_Print.htm" style="color: rgb(83, 101, 51)">
            <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
            <span style="margin-top: 2px; float: right;">Print</span></a>  </a>                                    
    </div>
    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <%--evm-0023 Add Big icon for Time sheet report list--%>
            <img src="/Images/BigIcons/timesheetreport.png" style="vertical-align: middle;" />
            Time Sheet Report
        </div>
        <div id="divMessageArea" style="display: none; margin: 0px 0 13px;">
            <img id="imgMessageArea" src="">
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
        
        <div style="border: .5px solid; border-color: #9ba48b; background-color: #f3f3f3; width:99.7%; margin-top: 1%;">
            <div style="float: left; width: 100%">

                

                <div id="divRadio" class="subform" style="width: 96%; float: left; margin-top: 1%; margin-bottom: 1%; border: .5px solid; border-color: #9ba48b; padding: 1%; margin-left: 1%;">
                    <div style="width: 77px; float: left; margin-left: 10%">
                        <asp:RadioButton ID="radioDaily" Text="Daily" runat="server" onclick="ShowOrHideDiv('Daily');" onkeypress="return DisableEnter(event)" GroupName="RadioGroup" />
                    </div>
                    <div style="width: 95px; float: left; margin-left: 10%">
                        <asp:RadioButton ID="radioMonthly" Text="Monthly" runat="server" onclick="ShowOrHideDiv('Monthly');" onkeypress="return DisableEnter(event)" GroupName="RadioGroup" />
                    </div>
                    <div style="width: 93px; float: left; margin-left: 10%">
                        <asp:RadioButton ID="radioQuarterly" Text="Quarterly" runat="server" onclick="ShowOrHideDiv('Quarterly');" Checked="true" onkeypress="return DisableEnter(event)" GroupName="RadioGroup" />
                    </div>
                    <div style="width: 93px; float: left; margin-left: 10%">
                        <asp:RadioButton ID="RadioYearly" Text="Yearly" runat="server" onclick="ShowOrHideDiv('Yearly');" Checked="true" onkeypress="return DisableEnter(event)" GroupName="RadioGroup" />
                    </div>
                    <div style="width: 93px; float: left; margin-left: 10%">
                        <asp:RadioButton ID="RadioCustom" Text="Custom" runat="server" onclick="ShowOrHideDiv('Custom');" Checked="true" onkeypress="return DisableEnter(event)" GroupName="RadioGroup" />
                    </div>
                </div>

            </div>
            <div style="float: left; width: 100%">


                <div id="divRadio2" class="eachform" style="padding: 1%; margin-left: 1%; width: 18%; float: Left; border: .5px solid; border-color: #9ba48b;">
                    <div style="float: left; margin-left: 1%">
                        <asp:RadioButton ID="RadioDivision" Text="Division" onchange="return clearDivision();" runat="server" onclick="ShowOrHideDdl('Division');" onkeypress="return DisableEnter(event)" GroupName="RadioGroup2" />
                    </div>
                    <div style="float: left; margin-left: 8%">
                        <asp:RadioButton ID="RadioDept" OnCheckedChanged="RadioDept_CheckedChanged" AutoPostBack="true" Text="Department" runat="server" onclick="ShowOrHideDdl('Dept');" onkeypress="return DisableEnter(event)" GroupName="RadioGroup2" />
                    </div>

                    <asp:DropDownList ID="ddlDivision" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true" class="form1" Style="margin-left: 2%; width: 85%; margin-top: 4%; display: none; float: left; margin-right: 14%;" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlDepartment" class="form1" Style="margin-left: 2%; width: 85%; margin-top: 4%; display: none; float: left; margin-right: 14%;" runat="server">
                    </asp:DropDownList>
                </div>

                <div id="DivEmp" class="eachform" style="width: 24%; margin-top: 2.5%; margin-left: 2%; float: left;">

                    <h2 style="margin-top: 1%; width: 15%;">Employee </h2>

                    <asp:DropDownList ID="ddlEmployee" class="form1"  runat="server" Style="width: 160px; height: 29px; width: 66%; float: left; margin-left: 15%;">
                    </asp:DropDownList>


                </div>

                <div id="divDaily" class="eachform" style="display: none; width: 43%; float: left; margin-top: 2%;">
                    <div id="Div2" style="float: left; width: 100%; margin-top: 1%;">


                        <h2 style="margin-top: 1%; width: 16%; margin-left: 8%;">Date*</h2>
                        <div id="RechargeDate" class="input-append date" style="font-family: Calibri; float: right; width: 50%; margin-right: 21%;">
                            <asp:TextBox ID="txtDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return DisableEnter(event)" Style="width: 60.8%; height: 28px; float: left; font-family: calibri;"></asp:TextBox>

                            <img id="img1" class="add-on" src="../../../Images/Icons/CalandarIcon.png"  style="margin-left: .1%; height: 19.5px; width: 20px; cursor: pointer;" />
                            <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                            <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                            <script type="text/javascript"
                                src="../../../JavaScript/Date/JavaScriptDate1_8_3.js">
                            </script>
                            <script type="text/javascript"
                                src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                            </script>
                            <script type="text/javascript"
                                src="../../../JavaScript/Date/bootstrap-datepicker.js">
                            </script>
                            <script type="text/javascript"
                                src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js">
                            </script>
                            <script type="text/javascript">
                                var $noC = jQuery.noConflict();
                                $noC('#RechargeDate').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,

                                    //endDate: new Date(),
                                });

                            </script>
                        </div>
                    </div>
                </div>

                <div id="divMonthly" class="eachform" style="display: none; width: 43%; float: left; margin-top: 1%;">
                    <div id="Div4" style="float: left; width: 100%;">

                        <h2 style="margin-top: 1%; width: 16%; margin-left: 8%;">Month*</h2>

                        <asp:DropDownList ID="ddlMonth" Height="35px" Width="160px" class="form1" runat="server" Style="height: 30px; width: 160px; height: 30px; width: 40%; float: left; margin-left: 5%;">
                        </asp:DropDownList>
                    </div>
                    <div id="Div5" style="float: left; width: 100%; margin-top: 1%;">

                        <h2 style="margin-top: 1%; width: 16%; margin-left: 8%;">Year*</h2>

                        <asp:DropDownList ID="ddlMonthlyYear" Height="30px" Width="160px" class="form1" runat="server" Style="height: 30px; width: 160px; height: 30px; width: 40%; float: left; margin-left: 5%;">
                        </asp:DropDownList>



                    </div>
                </div>
                <div id="divQuarterly" class="eachform" style="display: none; width: 43%; float: left; margin-top: 1%;">
                    <div id="Div6" style="float: left; width: 100%;">

                        <h2 style="margin-top: 1%; width: 16%; margin-left: 8%;">Quarter*</h2>

                        <asp:DropDownList ID="ddlQuarter" Height="35px" Width="160px" class="form1" runat="server" Style="height: 30px; width: 160px; height: 30px; width: 40%; float: left; margin-left: 5%;">
                            <asp:ListItem Text="Quarter 1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Quarter 2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Quarter 3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Quarter 4" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="Div7" style="float: left; width: 100%; margin-top: 1%;">

                        <h2 style="margin-top: 1%; width: 16%; margin-left: 8%;">Year*</h2>

                        <asp:DropDownList ID="ddlQuarterlyYear" Height="30px" Width="160px" class="form1" runat="server" Style="height: 30px; width: 160px; height: 30px; width: 40%; float: left; margin-left: 5%;">
                        </asp:DropDownList>



                    </div>
                </div>
                <div id="divYearly" class="eachform" style="display: none; width: 43%; float: left; margin-top: 2%;">
                    <div id="Div8" style="float: left; width: 100%; margin-top: 1%;">

                        <h2 style="margin-top: 1%; width: 16%; margin-left: 8%;">Year*</h2>

                        <asp:DropDownList ID="ddlYearlyYear" Height="30px" Width="160px" class="form1" runat="server" Style="height: 30px; width: 160px; height: 30px; width: 40%; float: left; margin-left: 5%;">
                        </asp:DropDownList>



                    </div>
                </div>
                <div id="divCustom" class="eachform" style="display: none; width: 43%; float: left; margin-top: 0%;">
                    <div id="DivProject" style="float: left; width: 100%;">

                        <h2 style="margin-top: 1%; width: 18%; margin-left: 8%;">From Date *</h2>

                        <div id="divFromDate" class="input-append date" style="font-family: Calibri; float: right; width: 50%; margin-right: 21%;">
                            <asp:TextBox ID="txtFromDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return DisableEnter(event)" Style="width: 60.8%; height: 28px; float: left; font-family: calibri;"></asp:TextBox>

                            <img id="img2" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style="margin-left: .1%; height: 19.5px; width: 20px; cursor: pointer;" />
                            <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                            <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                            <script type="text/javascript"
                                src="../../../JavaScript/Date/JavaScriptDate1_8_3.js">
                            </script>
                            <script type="text/javascript"
                                src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                            </script>
                            <script type="text/javascript"
                                src="../../../JavaScript/Date/bootstrap-datepicker.js">
                            </script>
                            <script type="text/javascript"
                                src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js">
                            </script>
                            <script type="text/javascript">
                                var $noC = jQuery.noConflict();
                                $noC('#divFromDate').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,

                                    //endDate: new Date(),
                                });

                            </script>
                        </div>
                    </div>
                    <div id="Div1" style="float: left; width: 100%; margin-top: 1%;">

                        <h2 style="margin-top: 1%; width: 18%; margin-left: 8%;">To Date*</h2>

                        <div id="divTodate" class="input-append date" style="font-family: Calibri; float: right; width: 50%; margin-right: 21%;">
                            <asp:TextBox ID="txtTodate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return DisableEnter(event)" Style="width: 60.8%; height: 28px; float: left; font-family: calibri;"></asp:TextBox>

                            <img id="img3" class="add-on" src="../../../Images/Icons/CalandarIcon.png"  style="margin-left: .1%; height: 19.5px; width: 20px; cursor: pointer;" />
                            <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                            <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                            <script type="text/javascript"
                                src="../../../JavaScript/Date/JavaScriptDate1_8_3.js">
                            </script>
                            <script type="text/javascript"
                                src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                            </script>
                            <script type="text/javascript"
                                src="../../../JavaScript/Date/bootstrap-datepicker.js">
                            </script>
                            <script type="text/javascript"
                                src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js">
                            </script>
                            <script type="text/javascript">
                                var $noC = jQuery.noConflict();
                                $noC('#divTodate').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,

                                    //endDate: new Date(),
                                });

                            </script>
                        </div>


                    </div>
                </div>


                <div class="eachform" style="width: 7%; float: right; margin-right: 2%; margin-top: 2%;">
                    <asp:Button ID="btnSearch" Style="cursor: pointer; margin-top: 0%; float: right;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return validate();" OnClick="btnSearch_Click" />
                </div>
            </div>
            <br style="clear: both" />
        </div>
          <br />  
          <asp:Label ID="lblNumRec" runat="server" style="font-family: Calibri;font-size: 17px;color: rgb(83, 101, 51);"></asp:Label>
          <br />
        <br />
         <table style="width:35%;">
            <tr>
                <td style="width:28%;">
                    <asp:Button ID="btnPrevious" style=" float:left; font-size: 13px;" Enabled="false"  Width="98%" runat="server" class="searchlist_btn_rght" Text="Show Previous 500 Records" OnClick="btnPrevious_Click" OnClientClick="NextPrevValidation();"  />
          </td>
                <td style="width:25%;">

        <asp:Button ID="btnNext"  Width="98%" Margin-Left="5px"  style=" float:left; font-size: 13px;" runat="server" class="searchlist_btn_rght" Text="Show Next 500 Records" OnClick="btnNext_Click" OnClientClick="NextPrevValidation();" />
               </td>
               </tr>
        </table>

        <div id="divReport" class="table-responsive" runat="server">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        <div id="divPrintReport" runat="server" style="display: none">
            <br />
        </div>
        <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
        </div>
        <div id="divtile" runat="server" style="display: none"></div>


    </div>
</asp:Content>

