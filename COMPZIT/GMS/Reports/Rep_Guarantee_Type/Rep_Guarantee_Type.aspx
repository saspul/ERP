<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage_Compzit_GMS.master" AutoEventWireup="true" CodeFile="Rep_Guarantee_Type.aspx.cs" Inherits="GMS_Reports_Rep_Guarantee_Type_Rep_Guarantee_Type" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
        <style>
     

         input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
            cursor:default;
        }
        .searchlist_btn_rght {
        
         cursor:pointer;
         font-size: 13px; 
         float:left;
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
        background:url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        
        }
        .searchlist_btn_lft:focus {
        background:url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        
        }

    </style>

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
      <%--  function SearchValidation() {
            var ret = true;
            var ddlGuarentee = document.getElementById("<%=ddlCategorySearch.ClientID%>").value;
               var DdlCategory = document.getElementById("<%=ddlmodeSearch.ClientID%>").value;
            if (ddlGuarentee == "--SELECT ALL METHOD--") {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                     document.getElementById("<%=ddlCategorySearch.ClientID%>").style.borderColor = "Red";
                     document.getElementById("<%=ddlCategorySearch.ClientID%>").focus();

                     ret = false;
                 }

            if (DdlCategory == "--SELECT ALL CATEGORY--") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                 document.getElementById("<%=ddlmodeSearch.ClientID%>").style.borderColor = "Red";
                     document.getElementById("<%=ddlmodeSearch.ClientID%>").focus();

                     ret = false;
                 }
                   return ret;
               }--%>
    </script>

  <%--  for giving pagination to the html table--%>


    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>
<%--    <script src="/js/New%20folder/buttons.print.js"></script>
    <script src="/js/New%20folder/dataTables.buttons.min.js"></script>--%>
    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bLengthChange": false,
                "bSort": true,
                "pageLength": 25,
               // "paginate": false
            });

         
         
            //$p('#ReportTable').DataTable({
            //        dom: 'Bfrtip',
            //        buttons: [
            //            'print'
            //        ]
            //    });
        
         
          

        //    $(function () {
        //        $('button[type="submit"]').click(function () {
        //            var pageTitle = 'Page Title',
        //                stylesheet = '../../../css/New%20Plugins/bootstrap.min.css',
        //                win = window.open('', 'Print', 'width=500,height=300');
        //            win.document.write('<html><head><title>' + pageTitle + '</title>' +
        //                '<link rel="stylesheet" href="' + stylesheet + '">' +
        //                '</head><body>' + $('#ReportTable')[0].outerHTML + '</body></html>');
        //            win.document.close();
        //            win.print();
        //            win.close();
        //            return false;
        //        });
        //    });
        });


        function printredirect() {


            document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#PrintTable')[0].outerHTML;

            // $("#cphMain_divPrintReportSorted table").dataTable();
            var resultCurrcy = [];
            var result = 0;
            var incrmnt = 0;
            var MainTable = $p('#cphMain_divPrintReportSorted table tr');
            $p('#cphMain_divPrintReportSorted table tr').each(function () {

       
                var lgth = MainTable.length;
              
                //$p('td', this).each(function (index, val) {

                //    if (index == 10) {
                //        if (!resultCurrcy[10]) resultCurrcy[10] = "";

                //        resultCurrcy[incrmnt] += $(val).text();
                //        incrmnt++;
                //    }

                //});
               // alert($p('#cphMain_divPrintReportSorted table tr'));

                //$p(resultCurrcy).each(function () {

                //});
                //  alert($(val).text());
               
                $p('td', this).each(function (index, val) {
                    if (index == 9) {

                        //  if (!result[index]) result[index] = 0;

                        result += parseFloat($(val).text().replace(/,/g, ""));
                    }

                });




            });

            $p('#cphMain_divPrintReportSorted table').append('<tr ></tr>');

            //$p(result).each(function (index, val) {
            // alert(index);
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var n = result;
            if (FloatingValue != "") {
                n = result.toFixed(FloatingValue);
            }
           
            addCommas(n);
           // alert()

           //  $("#DropDownlist:selected").val();
        
            //  var Text = ddlReport.options[ddlReport.selectedIndex].text; $p('#cphMain_divPrintReportSorted table tr')
            var cnt = 0;
            var dec = cnt.toFixed(FloatingValue);
            if (document.getElementById("<%=HiddenFieldAmount.ClientID%>").value != dec) {
               // $p('#cphMain_divPrintReportSorted table ').last().append('<td style="text-align: right;" colspan=9 >Total<td style="text-align: right;">' + document.getElementById("<%=HiddenFieldAmount.ClientID%>").value + '<td  style="text-align: left;">' + document.getElementById("<%=HiddenCurrency.ClientID%>").value + '</td></td></td>')
            }
           // });

        }




        function CallCSVBtn() {
            document.getElementById("<%=BtnCSV.ClientID%>").click();

                }
    </script>
    <script>
        function addCommas(amnt) {

            nStr = amnt;
            nStr += '';
            var x = nStr.split('.');
            var x1 = x[0];
            var x2 = x[1];

            if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "1") {
                       var rgx = /(\d+)(\d{7})/;
                       if (rgx.test(x1)) {
                           x1 = x1.replace(rgx, '$1' + ',' + '$2');
                       }
                       rgx = /(\d+)(\d{5})/;
                       if (rgx.test(x1)) {
                           x1 = x1.replace(rgx, '$1' + ',' + '$2');
                       }
                       rgx = /(\d+)(\d{3})/;
                       if (rgx.test(x1)) {
                           x1 = x1.replace(rgx, '$1' + ',' + '$2');
                       }
                   }

                   if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "2") {
                           var rgx = /(\d+)(\d{9})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }

                           rgx = /(\d+)(\d{6})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }
                           rgx = /(\d+)(\d{5})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }
                           rgx = /(\d+)(\d{3})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }
                       }
                       if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "3") {
                           var rgx = /(\d+)(\d{9})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }
                           rgx = /(\d+)(\d{6})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }
                           rgx = /(\d+)(\d{3})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }
                       }




                       if (isNaN(x2))
                           document.getElementById("<%=HiddenFieldAmount.ClientID%>").value = x1;
                       //return x1;
                   else
                       document.getElementById("<%=HiddenFieldAmount.ClientID%>").value = x1 + "." + x2;
                       // return x1 + "." + x2;

               }

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
    <script>
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <asp:HiddenField ID="hiddenNext" runat="server" />
    <asp:HiddenField ID="hiddenPrevious" runat="server" />
    <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
    <asp:HiddenField ID="hiddenMemorySize" runat="server" />
    <asp:HiddenField ID="hiddenSearch" runat="server" Value="--SELECT ALL DIVISION--" />
      <asp:HiddenField ID="HiddenField1" runat="server" />
      <asp:HiddenField ID="HiddenFieldAmount" runat="server" />
      <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
      <asp:HiddenField ID="hiddenDecimalCount" runat="server" />

        <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    
         <asp:HiddenField ID="HiddenCurrency" runat="server" />

    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>

    <%-- <button class="btn btn-sm pull-right btn-default" type="submit">Print Item</button>--%>
        <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:4.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A2"  data-title="Item Listing"  style="float: right; margin-top:7.6%;color:rgb(83, 101, 51);font-family:Calibri;margin-right: 4.5%;width: 4%;" href="javascript:;" onclick="CallCSVBtn();">
                                <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 50%"; >CSV </a> 
      <div style="cursor: default; float: right; height: 25px; margin-right:1.5%;margin-top:7.5%;font-family:Calibri;" class="print" onclick="printredirect()">            
                                 <a id="A1" target="_blank" data-title="Item Listing"  href="../../../Reports/Print/SortedPrint.htm" style="color:rgb(83, 101, 51)" >
                                <img src="../../../Images/Other%20Images/imgPrint.png" style="max-width: 45%">
                              Print</a>                                    
                                </div>


    <div style="cursor: default; float: right; height: 25px; margin-right:1.5%;margin-top:7.5%;font-family:Calibri;display:none;" class="print" onclick="printredirectt()">            
                                 <a id="print_cap" target="_blank" data-title="Item Listing"  href="../../../Reports/Print/28_Print.htm" style="color:rgb(83, 101, 51)" >
                                <img src="../../../Images/Other%20Images/imgPrint.png" style="max-width: 45%">
                                 Print</a>                                    
                                </div>



    <div id="divSuccessUpd" style="visibility: hidden">
        <asp:Label ID="lblSuccessUpd" runat="server"></asp:Label>
    </div>
       <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
    <div class="cont_rght">




        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="../../../Images/BigIcons/Guarantee-Type-Wise-Report.png" style="vertical-align: middle;" />
         Guarantee Mode Wise Report
        </div>
        
        <br />
                <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width:98.3%;margin-top:1%;">

            <div style="width:36%;float:left;margin-top:14px">
             <div class="eachform" style="width: 100%; padding-left: 0.5%;padding-top:1% ;float: left;">
            <h2 style="margin-top: 0.5%;margin-left: 5%;">Division </h2>

            <asp:DropDownList ID="ddlDivisionSearch" class="form1" TabIndex="1"  style="height:25px;width:52%;margin-right: 4%;" runat="server"></asp:DropDownList>


        </div>

            <div class="eachform" style="width: 100%; padding-left: 0.5%;padding-top:1% ;float: left;">
            <h2 style="margin-top: 0.5%;margin-left: 5%;">Guarantee Method  </h2>

            <asp:DropDownList ID="ddlCategorySearch" class="form1" TabIndex="2"  style="height:25px;width:52%;margin-right: 4%;" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategorySearch_SelectedIndexChanged2">

                </asp:DropDownList>
        </div>
                </div>
             <div style="width:64%;float:right;margin-top:14px">
        <div class="eachform" style="width: 51%;margin-top:0%;">

                <h2 style="margin-top:1%;"> Guarantee Mode</h2>

                       <asp:DropDownList ID="ddlmodeSearch" class="form1" TabIndex="3"  style="height:25px;width:52%;margin-right: 4%;" runat="server">

                </asp:DropDownList>


            </div>
                     <div class="eachform" style="width: 51%;margin-top:0%;">

                <h2 style="margin-top:1%;"> Currency</h2>

                       <asp:DropDownList ID="ddlCurrency" class="form1" TabIndex="3"  style="height:25px;width:52%;margin-right: 4%;" runat="server">

                </asp:DropDownList>


            </div>
            <div class="eachform" style="width:51%;">               
                <div class="subform" style="width:215px;float: left;margin-left: 15%;">


                   <%-- <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" TabIndex="4" Checked="false" class="form2" />
                    <h3 style="margin-top:1%;">Show Deleted Entries</h3>--%>
                  </div>
                </div>
                <div class="eachform" style="width:25%;float: right;margin-right: 24%;margin-top: -4%;">
                <asp:Button ID="Button1" style="cursor:pointer;margin-top: -0.4%; margin-top: -8.4%; margin-left: 53%;" TabIndex="5" runat="server" class="searchlist_btn_lft" Text="Search"  OnClick="btnSearch_Click"  />
                     </div>
                 </div>
            <br style="clear: both" />
            </div>
        <br />

<%--        <div class="eachform" style="width: 66%; float: right;">
            
            <asp:Button ID="btnSearch" style="cursor:pointer; padding: 3px 19px 3px 38px;margin-top: -0.4%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClick="btnSearch_Click" OnClientClick="return SearchValidation();" />

        </div>--%>

        <br />
        <table>
            <tr>
                <td style="width:50%;">
                    <asp:Button ID="btnPrevious"   Width="98%" runat="server" class="searchlist_btn_rght" Text="Show Previous 500 Records" OnClick="btnPrevious_Click" Visible="false" OnClientClick="SetHiddenSearchCriteria(); " />
                </td>
                <td style="width:50%;">

                    <asp:Button ID="btnNext" Width="98%"  runat="server" Visible="false" class="searchlist_btn_rght" Text="Show Next 500 Records" OnClick="btnNext_Click" OnClientClick="SetHiddenSearchCriteria();"/>
                </td>

            </tr>
        </table>
         
       
        <%--  <br />
        <br />--%>
            <table style="width:72%;">
            <tr>
                           <td style="width: 19%;color: #6e7464;"> <asp:Label ID="Label1" runat="server" > Total number of records:</asp:Label></td>
                 <td > <asp:Label style="color: #6e7464;" ID="lblToalRowCount" runat="server" ></asp:Label></td>
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
                <style>#ReportTable_filter input {
    height: 20px;
    width: 200px;
    color: #336B16;
    font-size: 14px;
}
 .cont_rght {
    width: 102%;
}
                </style>
        <div id="divTitle" runat="server" style="display: none"></div>
         <div id="divPrintReport" runat="server" style="display: none">
                                    <br />
                                </div>
               <div id="divPrintReportSorted" runat="server" style="display: none">
                                    <br />
                                </div>
        <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
    </div>
   </div>
</asp:Content>



