<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="flt_Duty_Roster_Report_EmpList.aspx.cs" Inherits="AWMS_AWMS_Reports_flt_Duty_Roster_Report_flt_Duty_Roster_Report_EmpList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/JavaScript/multiselect/jQuery/jquery-3.1.1.min.js"></script>
    <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
    <link href="/JavaScript/multiselect/AdminLTE.min.css" rel="stylesheet" />

    <style>
        input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
            cursor: default;
        }

        .searchlist_btn_rght {
            cursor: pointer;
            font-size: 13px;
            float: left;
        }

            .searchlist_btn_rght:hover {
                background: #7B866A;
            }

            .searchlist_btn_rght:focus {
                background: #7B866A;
            }

        #a_Caption:hover {
            color: rgb(83, 101, 51);
        }

        #a_Caption {
            color: rgb(88, 134, 7);
        }

            #a_Caption:focus {
                color: rgb(83, 101, 51);
            }

        .searchlist_btn_lft:hover {
            background: url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        }

        .searchlist_btn_lft:focus {
            background: url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        }

        #ReportTable_filter input {
            height: 19px;
            width: 208px;
            color: #336B16;
            font-size: 14px;
            margin-bottom: 5%;
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
    </style>
    <script type="text/javascript">

        function SearchValidation() {
            selected();
            
            document.getElementById("divSuccessUpd").style.display = "none";
            if (document.getElementById("<%=txtFromDate.ClientID%>").value == "") {
                document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtFromDate.ClientID%>").focus();
                document.getElementById("divSuccessUpd").style.display = "block";
                document.getElementById("<%=lblSuccessUpd.ClientID%>").innerHTML = "Please enter From Date.";
                    return false;
                }

                else if (document.getElementById("<%=txtToDate.ClientID%>").value == "") {
                    document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtToDate.ClientID%>").focus();
                    document.getElementById("divSuccessUpd").style.display = "block";
                    document.getElementById("<%=lblSuccessUpd.ClientID%>").innerHTML = "Please enter To Date.";
                    return false;
                }

            var RcptdatepickerDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var RarrDatePickerDate = RcptdatepickerDate.split("-");
            var RdateDateCntrlr = new Date(RarrDatePickerDate[2], RarrDatePickerDate[1] - 1, RarrDatePickerDate[0]);

            var RcptdatepickerDate1 = document.getElementById("<%=txtToDate.ClientID%>").value;
            var RarrDatePickerDate1 = RcptdatepickerDate1.split("-");
            var RdateDateCntrlr1 = new Date(RarrDatePickerDate1[2], RarrDatePickerDate1[1] - 1, RarrDatePickerDate1[0]);

            if (RdateDateCntrlr > RdateDateCntrlr1) {
                document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtToDate.ClientID%>").focus();  
                document.getElementById("divSuccessUpd").style.display = "block";
                document.getElementById("<%=lblSuccessUpd.ClientID%>").innerHTML = "Sorry,From Date cannot be Greater than To Date !.";
                return false;
                }


        }

        function selectedSomethng() {

            {
                var abcd;
                abcd = document.getElementById("<%=ddlmodeSearch.ClientID%>").value;
    
      document.getElementById("<%=hiddensearchby.ClientID%>").value = "0";


      //  alert(abcd);
      //    document.getElementById("<%=hiddenselectedlist.ClientID%>").value = abcd;
      //  alert(abcd + "dfffff");

  }

    // alert(hiddenselectedlist.value);

    return false;
}


          
    </script>
    <script type="text/javascript">



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

    </script>

    <%--  for giving pagination to the html table--%>
    <%--<script src="/JavaScript/JavaScriptPagination1.js"></script>--%>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />

    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            //  $noCon2("#cphMain_ddlmodeSearch").val('').trigger("change");

            var data = document.getElementById("<%=hiddenselectedlist.ClientID%>").value;
            //alert(data);
            var totalString = data;
            eachString = totalString.split(',');
            var newVar = new Array();
            for (count = 0; count < eachString.length; count++) {
                if (eachString[count] != "") {
                    newVar.push(eachString[count]);

                }
            }

            $p('#cphMain_ddlmodeSearch').val(newVar);
            $p("#cphMain_ddlmodeSearch").trigger("change");


        });


    </script>
    <style>
        #cphMain_divReport {
            float: left;
            width: 98.5%;
        }

        #cphMain_divAdd {
            position: fixed;
            /*right: 4%;*/
            padding-left: 83.5%;
        }

        #TableRprtRow .tdT {
            line-height: 100%;
        }


        .cont_rght {
            width: 98%;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">



    <asp:HiddenField ID="Hiddenstoretodate" runat="server" />


    <asp:HiddenField ID="hiddenNext" runat="server" />
    <asp:HiddenField ID="hiddenPrevious" runat="server" />
    <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
    <asp:HiddenField ID="hiddenDate" runat="server" />
    <asp:HiddenField ID="hiddensysdate" runat="server" />
    <asp:HiddenField ID="hiddenMemorySize" runat="server" />
    <asp:HiddenField ID="hiddenSearch" runat="server" Value="--SELECT ALL DIVISION--" />
    <asp:HiddenField ID="HiddenTYPE" runat="server" Value="--SELECT ALL TYPE--" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <asp:HiddenField ID="hiddenEmployee" runat="server" />
    <asp:HiddenField ID="hiddenOnDate" runat="server" />
    <asp:HiddenField ID="hiddensearchby" Value="0" runat="server" />
    <asp:HiddenField ID="hiddenselectedlist"  runat="server" />
    <asp:HiddenField ID="hiddenSelectdNo" runat="server" />
       <asp:HiddenField ID="Hiddenselectedtext" runat="server" />
    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
    <%--<div style="cursor: default; float: right; height: 25px; margin-right: 5.5%; margin-top: 5%; font-family: Calibri;" class="print" onclick="printredirect()">
        <a id="print_cap" target="_blank" data-title="Item Listing" href="../Print/28_Print.htm" style="color: rgb(83, 101, 51)">
            <img src="../../../Images/Other%20Images/imgPrint.png" style="max-width: 45%">
            Print</a>
    </div>--%>
    <script src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
                <script src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
                <script src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
                <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />

    <div id="divSuccessUpd" style="display:none;margin-top:1%;">
        <asp:Label ID="lblSuccessUpd" runat="server"></asp:Label>
    </div>
    <div class="cont_rght">




        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <%--EVM-0023 48 IMAGE Icon changed--%>
            <img src="../../../Images/BigIcons/dutyrosterreport.png" style="vertical-align: middle;" />
            Duty Roster Report
        </div>

        <br />
        <div style="border: .5px solid; border-color: #9ba48b; background-color: #f3f3f3; width: 98.5%; margin-top: 1%;">



            <div class="eachform" style="width: 100%; float: left;">

             

                <div class="eachform" id="divemplysearch" style="width: 29%; float: left; margin-top: 14px; margin-left: 13px; border: 1px solid; border-color: #9ba48b;">
                    <%-- <div class="eachform" style="width: 100%;margin-top:0%;">--%>

                    <h2 style="margin-top: 6%; margin-left: 5%">Employee</h2>
                    <%-- </div>--%>
                    <div class="eachform" style="width: 73%; padding-left: 30.5%; margin-top: -29px; float: left;">
                        <asp:DropDownList ID="ddlmodeSearch" class="form-control select2" multiple="multiple" data-placeholder="Select an Employee" Style="height: 25px; width: 90%; margin-left: 5%; margin-top: 0%; float: left; margin-bottom: 2%;" runat="server">
                        </asp:DropDownList>
                    </div>

                </div>


                <div class="eachform" id="divoption" style="width: 41%; float: left; margin-top: 15px; border: 1px solid; border-color: #9ba48b; padding: 4px; margin-left: 1%;">
                    <h2 style="margin-top: 1%; display: none; margin-left: 40%;">Date</h2>
                    <div class="eachform" style="width: 53%; padding-left: 0.5%; padding-top: 1%; float: left;">
                        <h2 style="margin-top: 3.5%; margin-left: 0%;">From Date*</h2>

                        <div id="Div3" class="input-append date" style="font-family: Calibri; float: right; width: 50%; margin-right: 3%; margin-top: 1%; ">
                            <asp:TextBox ID="txtFromDate" class="textDate form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width: 82.8%; height: 27px; font-family: calibri; float: left; margin-left: -29%;"></asp:TextBox>

                            <input type="image" id="img2" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return TextDateChange()" style="height: 19px; float: left; width: 18px; cursor: pointer;" />

                            <script type="text/javascript">
                                var $noC2 = jQuery.noConflict();
                                $noC2('#Div3').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    endDate: new Date(),


                                });

                            </script>

                        </div>



                    </div>

                    <div class="eachform" style="width: 46%; padding-left: -0.5%; padding-top: 1%; float: left;">
                        <h2 style="margin-top: 3.5%; margin-left: -3%;">To Date*</h2>

                        <div id="ClosingDate" class="input-append date" style="font-family: Calibri; float: right; width: 54%; margin-right: 3%; margin-top: 1%; margin-bottom: -3px;">
                            <asp:TextBox ID="txtToDate" class="textDate form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width: 82.8%; height: 27px; font-family: calibri; float: left; margin-left: -29%;"></asp:TextBox>

                            <input type="image" id="img1" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return TextDateChange()" style="height: 19px; float: left; width: 18px; cursor: pointer;" />

                            <script type="text/javascript">
                                var $noC2 = jQuery.noConflict();
                                $noC2('#ClosingDate').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    endDate: new Date(),


                                });

                            </script>

                        </div>

                    </div>
                </div>
                <div class="eachform" style="width: 12%; float: right; margin-right: 0%; margin-top: 30px;">
                    <asp:Button ID="btnSearch" Style="cursor: pointer; margin-top: -0.4%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click"/>
                </div>

            </div>

            <br style="clear: both" />
        </div>
        <br />
         <asp:Label ID="lblNumRec" runat="server" style="font-family: Calibri;font-size: 17px;color: rgb(83, 101, 51);"></asp:Label>
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
    </div>
    <div id="divtile" runat="server" style="display: none"></div>
    <div id="divPrintReport" runat="server" style="display: none">
        <br />
    </div>
    <div id="divPrintCaption" runat="server" style="display: none; height: 150px">

    </div>
    <script>
        $noCon = jQuery.noConflict();
        $noCon2 = jQuery.noConflict();
        $noCon(function () {
            //Initialize Select2 Elements
            $noCon2(".select2").select2();

          //  checkclickedradio();
            document.getElementById("<%=ddlmodeSearch.ClientID%>").style.borderColor = "";


        });
</script>

    <style>
        .open > .dropdown-menu {
            display: none;
        }
    </style>
       <script>

           function selected() {
               var a;
               var sel = "";
            
          
                   a = $noCon2('#cphMain_ddlmodeSearch').val();
                   $noCon2("#cphMain_ddlmodeSearch option:selected").each(function () {
                       var $noCon2this = $noCon2(this);
                       if ($noCon2this.length) {
                           var selText = $noCon2this.text();
                           sel = sel + selText + ",";

                           document.getElementById("<%=Hiddenselectedtext.ClientID%>").value = sel;
                       }
                   });
               document.getElementById("<%=hiddensearchby.ClientID%>").value = "Employee";
               document.getElementById("<%=hiddenselectedlist.ClientID%>").value = a;
            
               return true;
               }
              

            
           
               </script>
    <style>
        
        #tblOnBoardMult > tbody > tr:nth-child(2n+1) > td, .main_table > tbody > tr:nth-child(2n+1) > th {
            height: 30px;
            background: #DDD;
            font-size: 14px;
            color: #5c5c5e;
        }

        #tblOnBoardMult > tbody > tr:nth-child(2n) > td, .main_table > tbody > tr:nth-child(2n) > th {
            height: 30px;
            background: #C2C2C2;
            font-size: 14px;
            color: #000;
        }

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
    </style>
</asp:Content>
