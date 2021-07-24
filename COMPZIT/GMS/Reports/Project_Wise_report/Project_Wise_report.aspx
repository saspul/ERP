﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Project_Wise_report.aspx.cs" MasterPageFile="~/MasterPage/MasterPage_Compzit_GMS.master" Inherits="GMS_Reports_Project_Wise_report_Project_Wise_report" %>

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
              document.getElementById('MymodalCancelView').style.display = "none";
           
          });


          </script>
      <script type="text/javascript">
          var $Mo = jQuery.noConflict();

      

          function ReCallAlert(href) {

              if (confirm("Do you want to Recall this Entry?")) {
                  window.location = href;
                  return false;
              }
              else {
                  return false;
              }
          }

    </script>
    <script type="text/javascript">
        
        function getdetails(href) {
            window.location = href;
            return false;
        }
        function CancelAlert(href) {

            if (confirm("Do you want to cancel this Entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }

        function CancelNotPossible() {
            alert("Sorry, Cancellation Denied. This Entry is Already Selected Somewhere Or It is a Confirmed Entry!");
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

        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
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
                "bLengthChange": false,
                "bSort": true,
                "pageLength": 25
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
            width: 102%;
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

       


        function SearchValidation() {
            ret = true;
            var ddlDivision = document.getElementById("<%=ddlDivision.ClientID%>").value;

            var ddlGCat = document.getElementById("<%=ddlGCatagry.ClientID%>").value;
            
            var ddlProject = document.getElementById("<%=ddlProjct.ClientID%>").value;



            if (ret == true) {

                document.getElementById("<%=HiddenSearchField.ClientID%>").value = ddlDivision + ',' + ddlGCat + ',' + ddlProject;
             }


             return ret;

         }

        function printredirect() {


            document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#PrintTable')[0].outerHTML;

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
                    if (index == 10) {

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

                   //  $p('#cphMain_divPrintReportSorted table ').last().append('<td style="text-align: right;" colspan=10 >Total<td style="text-align: right;">' + document.getElementById("<%=HiddenFieldAmount.ClientID%>").value + '<td  style="text-align: left;">' + document.getElementById("<%=HiddenCurrency.ClientID%>").value + '</td></td></td>')
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
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
        <asp:HiddenField ID="HiddenSearchField" runat="server" />
        <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
     <asp:HiddenField ID="HiddenFieldSuplier" runat="server" />
    <asp:HiddenField ID="HiddenFieldClient" runat="server" />

          <asp:HiddenField ID="HiddenFieldAmount" runat="server" />
      <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
      <asp:HiddenField ID="hiddenDecimalCount" runat="server" />

     <asp:HiddenField ID="HiddenCurrency" runat="server" />
    
    <%--<asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />--%>



    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
                  <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:4.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A2"  data-title="Item Listing"  style="float: right; margin-top:4.5%;color:rgb(83, 101, 51);font-family:Calibri;width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
                                <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;" ><span style="float: right;margin-top: 4%;margin-right: 60%;">CSV</span> </a> 
    <div style="cursor: default; float: right; height: 25px; margin-right:1.5%;margin-top:4.4%;font-family:Calibri;" class="print" onclick="printredirect()">            
                                 <a id="A1" target="_blank" data-title="Item Listing"  href="/Reports/Print/SortedPrint.htm" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%;"><span style="float: right;margin-top: 4%;">Print</span></a>                                    
                                </div>
      <div style="cursor: default; float: right; height: 25px; margin-right:1.5%;margin-top:4.5%;font-family:Calibri;display:none;" class="print" onclick="printredirectt()">            
                                 <a id="print_cap" tabindex="1" target="_blank" data-title="Item Listing"  href="/Reports/Print/28_Print.htm" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
                                  <span style="margin-top: 2px;float: right;"> Print</span></a>                                     
                                </div>
   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/Project-Wise-Bank-Guarantee-Report.png" style="vertical-align: middle;" />
             Project Wise Guarantee Report
        </div >
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 93.5%;margin-top:1%;">

         <div style="float:left;width:98%">
                       
               <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                   <ContentTemplate>

          
            <div id="divDivision " class="eachform" style="width: 40%; float: Left;margin-top: .5%;">
                    <h2 style="margin-left: 8%;margin-top: 2%;width: 16%;">Division</h2>
                   
                    <asp:DropDownList ID="ddlDivision"  tabindex="2" class="form1" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true" Style="float: right; width: 55.2% !important; margin-right: 14%;margin-top: 1%;" runat="server" >
                    </asp:DropDownList>
                </div>

        <div id="DivCGuarantee" class="eachform" style="width: 40%;margin-top:1%;">

                <h2 style="margin-top:1%;width: 35%;">Guarantee Method</h2>

                <asp:DropDownList ID="ddlGCatagry" Height="30px" TabIndex="3" Width="160px" class="form1" runat="server" Style="height:30px;width:56.2%;float:left; margin-left: 5%;">
                   
                </asp:DropDownList>


            </div>

                  <div id="DivProject" class="eachform" style="width: 39.5%;margin-top:1%;">

              <%--EVM-0016--%>  <h2 style="margin-top:1%;width: 16%;margin-left: 8%;">Project</h2><%--EVM-0016--%>

                <asp:DropDownList ID="ddlProjct" Height="30px" TabIndex="4" Width="160px" class="form1" runat="server" Style="height:30px;width:160px;height:30px;width:55.2%;float:left; margin-left: 7%;">
                   
                </asp:DropDownList>


            </div>
                                 <div id="Div1" class="eachform" style="width: 38.8%;margin-top:1%;">

    <h2 style="margin-top:1%;width: 16%;">Currency</h2>

                <asp:DropDownList ID="ddlCurrency" Height="30px" TabIndex="4" Width="160px" class="form1" runat="server" Style="height:30px;width:58%;float:left; margin-left: 25.5%;">
                   
                </asp:DropDownList>


            </div>

                       </ContentTemplate>
                       
               </asp:UpdatePanel>      
                
              
                <div class="eachform" style="width:12%;float: right;margin-right: 2%;margin-top: -4%;">
                <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: 0%;float:left;" TabIndex="5" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click"  />
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
        
                <div id="divTitle" runat="server" style="display: none">
                                    <br />
                                </div>
         <div id="divPrintReport" runat="server" style="display: none">
                                    <br />
                                </div>
         <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
    </div>
        <div id="divtile" runat="server" style="display: none"></div>
         <div id="divPrintReportSorted" runat="server" style="display: none">
                                    <br />
                                </div>

         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>
    </div>
</asp:Content>



