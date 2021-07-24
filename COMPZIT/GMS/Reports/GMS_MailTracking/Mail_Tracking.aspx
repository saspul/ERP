<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mail_Tracking.aspx.cs" MasterPageFile="~/MasterPage/MasterPage_Compzit_GMS.master" Inherits="GMS_Reports_Mail_Tracking" %>

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
         


           


             return ret;

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
       <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
       <asp:HiddenField ID="HiddenField1" Value="0" runat="server" />
    <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenUserId" runat="server" />
        <asp:HiddenField ID="hiddenEnableModify" runat="server" />
    <asp:HiddenField ID="hiddenEnableCancel" runat="server" />
        <asp:HiddenField ID="hiddenEnableRecall" runat="server" />
    <asp:HiddenField ID="hiddenLastRow" Value="0" runat="server" />

    <%--<asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />--%>



    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
      <div style="cursor: default; float: right; height: 25px; margin-right:7.5%;margin-top:4.5%;font-family:Calibri;" class="print" onclick="printredirect()">            
                                 <a id="print_cap" tabindex="1" target="_blank" data-title="Item Listing"  href="/Reports/Print/28_Print.htm" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
                                  <span style="margin-top: 2px;float: right;"> Print</span></a>  </a>                                    
                                </div>
   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/Project-Wise-Bank-Guarantee-Report.png" style="vertical-align: middle;" />
             Mail Tracking Report
        </div >
          <br />

   
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
     

         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>
    </div>
    <script>
        $noCon(function () {
           
            $noCon(window).scroll(function () {
                if ($noCon(document).height() == $noCon(window).scrollTop() + $noCon(window).height()) {
                    var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
                      var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
                      var LstRow = document.getElementById("<%=hiddenLastRow.ClientID%>").value;
                  
                    $noCon.ajax({
                          type: "POST",
                          async: false,
                          contentType: "application/json; charset=utf-8",
                          url: "Mail_Tracking.aspx/LoadTableRows",
                          data: '{OrgId:"' + OrgId + '" ,CorpId: "' + CorpId + '",Rowstart:"' + LstRow +'"}',
                          dataType: "json",
                          success: function (data) {

                              if (data.d != "") {
                                  jQuery('#ReportTable').append(data.d);
                              }
                          }
                      });
                  }
              });
          });</script>
</asp:Content>



