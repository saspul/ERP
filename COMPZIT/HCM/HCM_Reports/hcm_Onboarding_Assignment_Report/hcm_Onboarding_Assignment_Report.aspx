<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Onboarding_Assignment_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_Onboarding_Assignment_Report_hcm_Onboarding_Assignment_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

<style>
        .cont_rght {
            width: 100%;
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
        .select2-results__option {
    padding: 6px 12px;
    user-select: none;
    -webkit-user-select: none;
    font-size: 13px;
}
    .select2-container {
      width: 56.5% !important;
margin-left: 1% !important;
    } 
    .select2-container .select2-search--inline .select2-search__field {
    box-sizing: border-box;
    border: none;
    font-size: 84% !important;
    margin-top: 5px;
    padding: 0;
}
    .select2-selection__rendered {
      max-height: 47px;
overflow-y: auto !important;
    }
</style>

 <script src="/JavaScript/jquery-1.8.3.min.js"></script>

 <script type="text/javascript">

     var $noCon = jQuery.noConflict();
     $noCon(window).load(function () {
         document.getElementById("freezelayer").style.display = "none";

         document.getElementById("<%=ddlParticular.ClientID%>").focus();
         document.getElementById("<%=divPrintCaptionDetails.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=lblPrintOnBrdDtls.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=divPrintReportDetails.ClientID%>").style.visibility = "hidden";

     });

     </script>

     <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            //$p('#ReportTable').DataTable({
            //    "pagingType": "full_numbers",
            //    "bSort": true,
            //    "pageLength": 25,
            //});
        });
     
     </script>   
    <script>
        
        $noCon = jQuery.noConflict();
        $noCon2 = jQuery.noConflict();
        $noCon(function () {
            //Initialize Select2 Elements

            var prm = Sys.WebForms.PageRequestManager.getInstance();
            //  prm.add_initializeRequest(InitializeRequest);
            prm.add_endRequest(EndRequest);
            $noCon2(".select2").select2();

            var data = document.getElementById("<%=Hiddenselectedtext.ClientID%>").value;
                var totalString = data;
                var eachString = totalString.split(',');
                var newVar = new Array();
                for (count = 0; count < eachString.length; count++) {
                    if (eachString[count] != "") {
                        newVar.push(eachString[count]);
                        //alert(newVar);
                    }
                }

                $noCon2('#cphMain_ddlCandidate').val(newVar);
                $noCon2("#cphMain_ddlCandidate").trigger("change");

            });



            function EndRequest(sender, args) {
                // after update occur on UpdatePanel re-init the Autocomplete
                $noCon2(".select2").select2();
                var data = document.getElementById("<%=Hiddenselectedtext.ClientID%>").value;
              var totalString = data;
              var eachString = totalString.split(',');
              var newVar = new Array();
              for (count = 0; count < eachString.length; count++) {
                  if (eachString[count] != "") {
                      newVar.push(eachString[count]);
                      //alert(newVar);
                  }
              }

              $noCon2('#cphMain_ddlCandidate').val(newVar);
              $noCon2("#cphMain_ddlCandidate").trigger("change");

          }


        function isTag(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62 || charCode == 13) {
                ret = false;
            }
            return ret;
        }
        var $au = jQuery.noConflict();
        $au(function () {
            $au('#cphMain_ddlAssgndTo').selectToAutocomplete1Letter();
            $au('#cphMain_ddlProject').selectToAutocomplete1Letter();
        });

        $noCon = jQuery.noConflict();
        $noCon2 = jQuery.noConflict();
        function selected() {
            document.getElementById("<%=Hiddenselectedtext.ClientID%>").value = $noCon2('#cphMain_ddlCandidate').val();
            return true;
        }
        function CallCSVBtn() {
            document.getElementById("<%=BtnCSV.ClientID%>").click();
              }
        </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

 <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
<script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
<link href="/JavaScript/multiselect/AdminLTE.min.css" rel="stylesheet" />

    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenCorpId" runat="server" />
    <asp:HiddenField ID="hiddenOrgId" runat="server" />
    <asp:HiddenField ID="hiddenCandidateId" runat="server" />
     <asp:HiddenField ID="Hiddenselectedtext" runat="server" />
                 <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:4.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A2"  data-title="Item Listing"  style="float: right; margin-top:4%;color:rgb(83, 101, 51);font-family:Calibri;width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
                                <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left: 39%;" ><span style="margin-top: 2.7px; float: right;margin-right: 20%;">CSV</span> </a> 
    <div style="cursor: default; float: right; height: 25px; margin-right: -2.5%; margin-top: 4%; font-family: Calibri;" class="print">
     <a id="print_cap" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/Common_print.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -26px; float: right;">Print</span></a>                                  
</div>

    <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

<div class="cont_rght">
    
    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="/Images/BigIcons/On Boarding Job Assignment.png" style="vertical-align: middle;" />
     On Boarding Job Assignment Report
        </div >

    <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;width: 100%;margin-top:3%;min-height:150px;">

     
        <div style="width:100%;float:left;">

        <div style="margin-top:2.5%;margin-left:2%;width:40%;float:left;">
         <h2>Particular  </h2>
           <asp:DropDownList ID="ddlParticular" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="height: 28px; width: 56.5%; float: left; margin-left: 2%;" >
          <Items>
              <asp:ListItem Text="--SELECT PARTICULAR--" Value="0" />
              <asp:ListItem Text="VISA" Value="1" />
              <asp:ListItem Text="FLIGHT TICKET" Value="2" />
              <asp:ListItem Text="ROOM ALLOTMENT" Value="3" />
              <asp:ListItem Text="AIRPORT PICKUP" Value="4" />
           </Items>
          </asp:DropDownList>
        </div>

       
      
        <div style="margin-top:2.5%;margin-left:1%;width:45%;float:left;">
         <h2 style="width:17%;">Project  </h2>
        <asp:DropDownList ID="ddlProject" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="height: 28px; width: 50%; float: left; margin-left: 2%;">
           </asp:DropDownList>
        </div>

        </div>


       <div style="width:100%;float:left;">
         <div style="margin-top:2.5%;margin-left:2%;width:40%;float:left;">
         <h2 >Candidate   </h2>
        <asp:DropDownList ID="ddlCandidate" class="form-control select2" multiple="multiple" data-placeholder="--SELECT CANDIDATE--" onchange="return selected()"  runat="server" Style="height: 28px; width: 55%; float: left; margin-left: 2%;font-weight:10%;" >
           </asp:DropDownList>
        </div>
        <div style="margin-top:2.5%;margin-left:1%;width:40%;float:left;">
         <h2>Assigned To  </h2>
        <asp:DropDownList ID="ddlAssgndTo" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="height: 28px; width: 56%; float: left; margin-left: 2%;">
           </asp:DropDownList>
        </div>
  

    <asp:Button ID="btnSearch" style="cursor:pointer;float:right;margin-right:2%;margin-top:0%;"  runat="server" class="searchlist_btn_lft" Text="Search"  OnClick="btnSearch_Click"  />
       </div>   
   </div>

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
        </div>

    <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>


    <div id="divPrintReport" runat="server" style="display: none">
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>

      <div id="divTitle" runat="server" style="display: none">
     On Boarding Job Assignment Report
      </div>
    
      </div>



  

        <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>



    <div id="divPrintCaptionDetails" class="table-responsive" runat="server">
            </div>

   <label id="lblPrintOnBrdDtls" runat="server" style="float: left; cursor: inherit"></label>

    <div id="divPrintReportDetails" class="table-responsive" runat="server">
         <br />
       </div>




</asp:Content>

