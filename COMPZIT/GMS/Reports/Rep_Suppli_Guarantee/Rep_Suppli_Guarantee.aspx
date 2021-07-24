<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage_Compzit_GMS.master" AutoEventWireup="true" CodeFile="Rep_Suppli_Guarantee.aspx.cs" Inherits="GMS_Reports_Rep_Suppli_Guarantee_Rep_Suppli_Guarantee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
     
     <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

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
                "pageLength": 25,
               // "paginate":false
            });



          
        });


        

    </script>

      <style>
     
        #cphMain_divReport {
            float: left;
            width: 93.5%;
        }

      

        #TableRprtRow .tdT {
            line-height: 100%;
        }


        .cont_rght {
            width: 98%;
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
    </script>
  
         <script type="text/javascript">
             var $noCon = jQuery.noConflict();
             $noCon(window).load(function () {

                 document.getElementById("freezelayer").style.display = "none";
                 document.getElementById('MymodalCancelView').style.display = "none";
                 var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
              if (CancelPrimaryId != "") {
                  OpenCancelView();
              }
          });


             function SearchValidation() {
               var  ret = true;
                 var ddlDivision = document.getElementById("<%=ddlDivision.ClientID%>").value;
                 var Ddlsupplier = document.getElementById("<%=Ddlsupplier.ClientID%>").value;
               //  document.getElementById("<%=Ddlsupplier.ClientID%>").style.borderColor = "";
                // if (Ddlsupplier == "--SELECT SUPPLIER--") {
                //     document.getElementById('divMessageArea').style.display = "";
                  //   document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  //   document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please select a supplier";
                  //   document.getElementById("<%=Ddlsupplier.ClientID%>").style.borderColor = "Red";
                  //   document.getElementById("<%=Ddlsupplier.ClientID%>").focus();

                  //   ret = false;
               //  }

                   if (ret == true) {
                       document.getElementById("<%=HiddenSearchField.ClientID%>").value = ddlDivision + ',' + Ddlsupplier;
                   }
               
             return ret;
             }
             function printredirect() {


                 document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;

                 // $("#cphMain_divPrintReportSorted table").dataTable();
                 var resultCurrcy = [];
                 var result = 0;
                 var incrmnt = 0;

                 $p('#cphMain_divPrintReportSorted table tr').each(function () {
                     //$p('td', this).each(function (index, val) {

                     //    if (index == 10) {
                     //        if (!resultCurrcy[10]) resultCurrcy[10] = "";

                     //        resultCurrcy[incrmnt] += $(val).text();
                     //        incrmnt++;
                     //    }

                     //});


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
          //  alert(n);
            addCommas(n);
                   // alert()

                   //  $("#DropDownlist:selected").val();

                 //  var Text = ddlReport.options[ddlReport.selectedIndex].text;
            var cnt = 0;
            var dec = cnt.toFixed(FloatingValue);
            if (document.getElementById("<%=HiddenFieldAmount.ClientID%>").value != dec) {

                $p('#cphMain_divPrintReportSorted table ').last().append('<td style="text-align: right;" colspan=9 >Total<td style="text-align: right;">' + document.getElementById("<%=HiddenFieldAmount.ClientID%>").value + '<td  style="text-align: left;">'+document.getElementById("<%=HiddenCurrency.ClientID%>").value+'</td></td></td>')  
                // });
            }
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



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

     <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
        <asp:HiddenField ID="HiddenSearchField" runat="server" />
        <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrency" runat="server" />

     <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
      <asp:HiddenField ID="HiddenFieldAmount" runat="server" />
      <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
      <asp:HiddenField ID="hiddenDecimalCount" runat="server" />

     <asp:HiddenField ID="HiddenCurrency" runat="server" />

    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
     <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:4.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A2"  data-title="Item Listing"  style="float: right; margin-top:4.5%;color:rgb(83, 101, 51);font-family:Calibri;margin-right: 6.5%;width: 4%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 50%"; >CSV </a> 
     <div style="cursor: default; float: right; height: 25px; margin-right:1.5%;margin-top:4.5%;font-family:Calibri;" class="print" onclick="printredirect()">            
                                 <a id="A1" target="_blank" data-title="Item Listing"  href="/Reports/Print/SortedPrint.htm" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 50%">
                               Print</a>                                    
                                </div>
      <div style="cursor: default; float: right; height: 25px; margin-right:1.5%;margin-top:4.5%;font-family:Calibri;display:none; " class="print" onclick="printredirectt()">            
                                 <a id="print_cap" target="_blank" data-title="Supplier Wise Guarantee Report"  href="/Reports/Print/28_Print.htm" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
                                 Print</a>                                    
                                </div>
   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/Supplier-Wise-Report.png" style="vertical-align: middle;" />
             Supplier Wise Guarantee Report
        </div >
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 93.5%;margin-top:1%;">

         <div style="float:left;width:98%">
                            
                 <div id="divDivision " class="eachform" style="width: 40%; float: Left;margin-top: .5%;">
                    <h2 style="margin-left: 8%;margin-top: 2%;width: 16%;">Division </h2>                   
                    <asp:DropDownList ID="ddlDivision"   class="form1" Style="float: right; width: 55.2% !important; margin-right: 14%;margin-top: 1%;" runat="server" >
                    </asp:DropDownList>
                </div>
                <div id="div1" class="eachform" style="width: 40%; float: Left;margin-top: .5%;">
                    <h2 style="margin-left: 8%;margin-top: 2%;width: 16%;">Supplier </h2>                   
                    <asp:DropDownList ID="Ddlsupplier"   class="form1" Style="float: right; width: 55.2% !important; margin-right: 14%;margin-top: 1%;" runat="server" >
                    </asp:DropDownList>
                </div>
                <div id="div2" class="eachform" style="width: 40%; float: Left;margin-top: .5%;">
                    <h2 style="margin-left: 8%;margin-top: 2%;width: 16%;">Currency </h2>                   
                    <asp:DropDownList ID="ddlCurrency"   class="form1" Style="float: right; width: 55.2% !important; margin-right: 14%;margin-top: 1%;" runat="server" >
                    </asp:DropDownList>
                </div>
                <div class="eachform" style="width:12%;float: right;margin-right: 2%;margin-top: 1%;">
                <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: 0%;float:left;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click"  />
                     </div>
                
                 </div>
            <br style="clear: both" />
            </div>
        <br />
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
         <div id="divPrintReport" runat="server" style="display: none">
                                    <br />
                                </div>
         <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
    </div>
        <div id="divTitle" runat="server" style="display: none"></div>
     </div>
           <div id="divPrintReportSorted" runat="server" style="display: none">
                                    <br />
                                </div>
    <style>
         .cont_rght {
    width: 102%;
}
    </style>
</asp:Content>

