<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage_Compzit_GMS.master" AutoEventWireup="true" CodeFile="Rep_Ims_Insurance_Expiry.aspx.cs" Inherits="GMS_Reports_Rep_Ims_Insurance_Expiry_Rep_Ims_Insurance_Expiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
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
               /*--------------------------------------------------for modal Cancel Reason------------------------------------------------------*/
         .modalCancelView {
             display: none; /* Hidden by default */
             position: fixed; /* Stay in place */
             z-index: 30; /* Sit on top */
             padding-top: 0%; /* Location of the box */
             left: 23%;
             top: 30%;
             width: 50%; /* Full width */
             /*height: 58%;*/ /* Full height */
             overflow: auto; /* Enable scroll if needed */
             background-color: transparent;
         }


         /* Modal Content */
         .modal-CancelView {
             /*position: relative;*/
             background-color: #fefefe;
             margin: auto;
             padding: 0;
             /*border: 1px solid #888;*/
             width: 95.6%;
             box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
         }


         /* The Close Button */
         .closeCancelView {
             color: white;
             float: right;
             font-size: 28px;
             font-weight: bold;
         }

             .closeCancelView:hover,
             .closeCancelView:focus {
                 color: #000;
                 text-decoration: none;
                 cursor: pointer;
             }

         .modal-headerCancelView {
             /*padding: 1% 1%;*/
            background-color: #91a172;
             color: white;
         }

         .modal-bodyCancelView {
             padding: 4% 4% 7% 4%;
         }

         .modal-footerCancelView {
             padding: 2% 1%;
           background-color: #91a172;
             color: white;
         }
         #divErrorRsnAWMS {
    border-radius: 4px;
    background: #fff;
    color: #53844E;
    font-size: 12.5px;
    font-family: Calibri;
    font-weight: bold;
    border: 2px solid #53844E;
    margin-top: -3.5%;
    margin-bottom: 2%;
}

     </style>
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {

              document.getElementById("freezelayer").style.display = "none";
             
              
             
          });


          </script>
      <script type="text/javascript">
          var $Mo = jQuery.noConflict();

          

    </script>
          <style>

        #cphMain_btnNext.aspNetDisabled {
            width: 202px;
            height: 33px;
            margin-top: -5px;
            font-size: 13px;
            cursor: default;
        }
        #cphMain_btnPrevious.aspNetDisabled {
            width: 202px;
            height: 33px;
            margin-top: -5px;
            font-size: 13px;
            cursor: default;
        }
        .searchlist_btn_rght {
            cursor: pointer;
        }
           input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
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
        input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
            cursor:default;
        }
         .searchlist_btn_rght:hover {
                background: #7B866A;
            }
             .searchlist_btn_rght:focus {
                background: #7B866A;
            }
    </style>
    <script type="text/javascript">
       
      
     
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

        function CallCSVBtn() {
            document.getElementById("<%=BtnCSV.ClientID%>").click();

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
                //"pageLength": 25
                "bLengthChange": false,
            });
        });


    </script>



    <style>
        #cphMain_divReport {
            float: left;
            width:100%;
        }

      

        #TableRprtRow .tdT {
            line-height: 100%;
        }


        .cont_rght {
            width: 100%;
        }
    </style>

    <script>

        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }

        //validation when cancel process
       


        function SearchValidation() {
            ret = true;
            var ddlDivision = document.getElementById("<%=ddlDivision.ClientID%>").value;

          

            var ddlBank = document.getElementById("<%=ddlBank.ClientID%>").value;





            if (ret == true) {

                document.getElementById("<%=HiddenSearchField.ClientID%>").value = ddlDivision + ','  + ddlBank;
             }


             return ret;

         }
        function printredirect() {


            document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
            var resultCurrcy = [];
            var result = 0;
            var incrmnt = 0;

            $p('#cphMain_divPrintReportSorted table tr').each(function () {
                            
                $p('td', this).each(function (index, val) {
                    
                    if (index == 7) {

                     

                        result += parseFloat($(val).text().replace(/,/g, ""));
                    }

                });
   
            });

            $p('#cphMain_divPrintReportSorted table').append('<tr ></tr>');

          
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                 var n = result;
                 if (FloatingValue != "") {
                     n = result.toFixed(FloatingValue);
                 }
               
                 addCommas(n);
             
                 var cnt = 0;
                 var dec = cnt.toFixed(FloatingValue);
                
               
                 if (document.getElementById("<%=HiddenFieldAmount.ClientID%>").value != dec) {

                $p('#cphMain_divPrintReportSorted table ').last().append('<td style="text-align: right;" colspan=7 >Total<td style="text-align: right;">' + document.getElementById("<%=HiddenFieldAmount.ClientID%>").value + '<td  style="text-align: center;">' + document.getElementById("<%=HiddenCurrency.ClientID%>").value + '</td></td></td>')
                
            }
        }


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

        //function printredirect() {
        //    document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
        //    // $('#cphMain_divPrintReportSorted table tr').find('td:eq(8),th:eq(8),td:eq(9),th:eq(9),td:eq(10),th:eq(10),td:eq(11),th:eq(11),td:eq(12),th:eq(12)').remove();

        //}
        </script>
     <style>


    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
        <asp:HiddenField ID="HiddenSearchField" runat="server" />
       <asp:HiddenField ID="HiddenFieldAmount" runat="server" />
  
     <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
     <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
     <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
        <asp:HiddenField ID="HiddenCurrency" runat="server" />
     <asp:HiddenField ID="hiddenNext" runat="server" />
    <asp:HiddenField ID="hiddenPrevious" runat="server" />
      <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
     <asp:HiddenField ID="hiddenMemorySize" runat="server" />

    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
    
    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
    <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:2.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A2"  data-title="Item Listing"  style="float: right; margin-top:4.5%;color:rgb(83, 101, 51);font-family:Calibri;margin-right: 6.5%;width: 6%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 36%"; >CSV </a> 
     <div style="cursor: default; float: right; height: 25px; margin-right:1.5%;margin-top:2.5%;font-family:Calibri;" class="print" onclick="printredirect()">            
                                 <a id="A1" target="_blank" data-title="Item Listing"  href="/Reports/Print/SortedPrint.htm" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 50%">
                                 Print</a>                                    
                                </div>
    <%--  <div style="cursor: default; float: right; height: 25px; margin-right:1.5%;margin-top:4.5%;font-family:Calibri;" class="print" onclick="printredirectt()">            
                                 <a id="print_cap" target="_blank" data-title="Supplier Wise Guarantee Report"  href="/Reports/Print/28_Print.htm" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
                                 Print</a>                                    
                                </div>--%>
   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/Expiry_report.png" style="vertical-align: middle;" />
          Expired Insurance Report
        </div >
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 100%;margin-top:1%;">

         <div style="float:left;width:98%">
                      
          
                 <div class="row">
                     <div class="col-sm-4">
                    <h2 style="margin-left: 8%;margin-top: 5%;" >Division </h2>
       
                   
                    <asp:DropDownList ID="ddlDivision"   class="form1" Style="float: right; width: 55.2% !important; margin-right: 14%;margin-top: 5%;" runat="server" >
                    </asp:DropDownList>
         
                         </div>
                      <div class="col-sm-4">
               
            <h2 style="margin-top: 5%;margin-left: -14%;" >Insurance Provider</h2>

            <asp:DropDownList ID="ddlBank" class="form1"   style=" margin-top: 5%" runat="server">

                </asp:DropDownList>
                          
                      <style>
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

        $au(function () {
            $au('#cphMain_ddlBank').selectToAutocomplete1Letter();
        });
    </script>

        </div>
                    
                      <div class="col-sm-4">


               <h2 style="margin-top: 5%;" >Currency </h2>

                <asp:DropDownList ID="ddlCurrency"  class="form1" runat="server" style="height:28px;width:55%;margin-left: 5.7%; float:left; margin-top: 5%" >
                   
                </asp:DropDownList>
                 </div>   
                      
                </div>

        
              <br />
            <div class="row">
                 

                <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: 1%;margin-right: 8%;float:right;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click"  />
               

          
               
                
             
                 </div>
             </div>
            <br style="clear: both" />
            </div>
        <br />


        <table style="width:72%;">
            <tr>
                <td style="width:28%;">
                    <asp:Button ID="btnPrevious" style=" float:left; font-size: 13px;" Enabled="false"  Width="98%" runat="server" class="searchlist_btn_rght" Text="Show Previous 500 Records" OnClick="btnPrevious_Click"  />
          </td>
                <td style="width:25%;">

        <asp:Button ID="btnNext"  Width="98%" Margin-Left="5px"  style=" float:left; font-size: 13px;" runat="server" class="searchlist_btn_rght" Text="Show Next 500 Records" OnClick="btnNext_Click"  />
               </td>
                <td style="width: 19%;color: #6e7464;"> <asp:Label ID="Label1" runat="server" >Total number of records:</asp:Label></td>
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
         <div id="divPrintReportSorted" runat="server" style="display: none">
                                    <br />
                                </div>
            

         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>
    </div>

</asp:Content>

