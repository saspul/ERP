<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Employee_Deduction_Details_Report.aspx.cs" Inherits="HCM_hcm_Employee_Deduction_Details_Report_hcm_Employee_Deduction_Details_Reportaspx" %>

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
            width:92.5%;
            margin-left:1%;
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
         #divErrorMV {
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
     input[type="checkbox"] {
         margin-left:31%;
     }
     </style>
     <%--  for giving pagination to the html table--%>
    <script src="../../../JavaScript/JavaScriptPagination1.js"></script>
    <script src="../../../JavaScript/JavaScriptPagination2.js"></script>
    <link href="../../../css/StyleSheetPagination.css" rel="stylesheet" />
    <script>
        var $p= jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                //   "pageLength": 25
                "bLengthChange": false,
                "bPaginate": false
            });
        });


    </script>

    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
              

              document.getElementById("<%=divPrintCaption.ClientID%>").style.visibility = "hidden";
          
              document.getElementById("<%=divPrintReportDetails.ClientID%>").style.visibility = "hidden";
 
          });
          function printsorted() {
              document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
              //    $('#cphMain_divPrintReportSorted table tr').find('td:eq(4),th:eq(4)').remove();
          }

          </script>
      <script type="text/javascript">
          var $Mo = jQuery.noConflict();

 
      


    </script>
    <script>
        var confirmbox = 0;

     
  
    </script>
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

        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }
        </script>

  

     <style type="text/css">
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
                $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
            });





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

            var ret = true;

          
            document.getElementById("<%=ddlDep.ClientID%>").style.borderColor = "";
            var dept = document.getElementById("<%=ddlDep.ClientID%>").value;
            if(dept=="--SELECT DEPARTMENT--")
            {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please select department";
                 document.getElementById("<%=ddlDep.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlDep.ClientID%>").focus();

                ret = false;
            }
            return ret;
        }


        function CallCSVBtn() {
            document.getElementById("<%=BtnCSV.ClientID%>").click();
      }




        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
       <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
        <asp:HiddenField ID="HiddenSearchField" runat="server" />
        <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <%--<asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />--%>
     <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    

     <asp:HiddenField ID="HiddenFieldCbxCount" runat="server" />
     <asp:HiddenField ID="HiddenFieldReqrmntIds" runat="server" />
     <asp:HiddenField ID="HiddenFieldHRallocation" runat="server" />
     <asp:HiddenField ID="HiddenFieldSelfAllocation" runat="server" />
     <asp:HiddenField ID="HiddenFieldEditAllocation" runat="server" />
     <asp:HiddenField ID="HiddenFieldReAlctnIds" runat="server" />
         <asp:HiddenField ID="hiddenAllocateReallocate" runat="server" />

      <asp:HiddenField ID="hiddenOrgId" runat="server" />
      <asp:HiddenField ID="hiddenCorpId" runat="server" />
    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
           <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:4.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
        <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 3.5%; font-family: Calibri;" class="print" >
     <a id="A2" data-title="Visa Bundle"  href="javascript:;" onclick="CallCSVBtn();" style="color: rgb(83, 101, 51);margin-right:15%;">
       <img src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 60%;margin-right:15%;height: 96%;">
        <span style="margin-top: -28px; float: right;">CSV</span></a>                                  
</div>
          <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 3.5%; font-family: Calibri;" class="print" onclick="printsorted()">
     <a id="A1" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/sort_EmpDtlsRprt.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -28px; float: right;"> Print</span></a>                                  
</div>
      <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 3.5%; font-family: Calibri;display:none" class="print">
     <a id="print_cap" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/Employee_DeductionReport.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -28px; float: right;">Print</span></a>                                  
</div>

   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="/Images/BigIcons/Employee Deduction Details.png" style="vertical-align: middle;" />
   Employee Deduction Details Report
        </div >
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;margin-top:0.5%;height:10%;">

            <div style="width:100%;float:left;margin-top:14px">
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>

            <div class="eachform" style="width: 30%;margin-top:0.5%;margin-left:3%;float: left;">
            <h2 style="margin-top:1%;"> Department*</h2>

            <asp:DropDownList ID="ddlDep" class="form1"   style="height:25px;width:160px;height:25px;width:65%;float:left; margin-left: 8%;" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlDep_SelectedIndexChanged">      </asp:DropDownList>
             
        </div>
                        <div class="eachform" style="width: 27%; padding-top:0.5%;float: left;margin-left: 3%;">

                <h2 style="margin-top: 0.5%;margin-left: 0%;">Division</h2>

                <asp:DropDownList ID="ddlDivision" Height="25px"   class="form1" runat="server" Style="height:25px;width:60%;float: left;margin-left: 6%;" onchange="IncrmntConfrmCounter()" >
             
      
                </asp:DropDownList>


            </div> 
                  
                  <div class="eachform" style="width: 30%; padding-top:0.5% ;float: left;">
            <h2 style="margin-top: 0.5%;margin-left: 0%;"> Designation</h2>

            <asp:DropDownList ID="ddlDesignation" class="form1"   style="height:25px;width:60%;float: left;margin-left: 6%;" runat="server" onchange="IncrmntConfrmCounter()">      </asp:DropDownList>
             
        </div> 
           
          <div class="eachform" style="padding-top:0.5%;float: left;">
              <div style="width: 29%; float: left; padding: 5px; border: 1px solid #c3c3c3;margin-left: 3%;">
                  <h2 style="margin-top: 0.5%;margin-left: 0%;"> Type*</h2>
                    <div style="float: right; margin-right: 0%; width: 68%;">
                         <asp:RadioButton ID="radioStaff" Text="Staff" runat="server" Checked="true" GroupName="RadioSkCer" Style="float: left; font-family: calibri; margin-left: 6%;" OnKeypress="return DisableEnter(event)" />
                        <asp:RadioButton ID="radioWorker" Text="Worker" runat="server" GroupName="RadioSkCer" Style="float: left; font-family: calibri" OnKeypress="return DisableEnter(event)" />
                    </div>
                </div>
           </div>
                           
               
                      </ContentTemplate>
   </asp:UpdatePanel>
               
   
                </div>
             <div style="width:10%;float:right;margin-top:-8%;margin-left: 0%;">
        
                <div class="eachform" style="width:95%;float:right;margin-right: 18%;">
                <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: 45.6%;width:100%;float: right;margin-right: 87%;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click"  />
                     </div>
                 </div>
            <br style="clear: both" />
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
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>


        
    <div id="divPrintCaption" class="table-responsive" runat="server" style="display:none;" >
            </div>

   

    <div id="divPrintReportDetails" class="table-responsive" runat="server" style="display:none;" >
         <br />
       </div>

             <div id="divTitle" runat="server" style="display: none">
     Employee Deduction Details Report
      </div>
             <div id="divPrintReportSorted" runat="server" style="display: none">
                                    <br />
                                </div>
         <%--------------------------------For Allocation window--------------------------%>







      <%--   <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>--%>
    </div>


    <style>
        input[type="radio"] {
            display: table-cell;
        }
                #ReportTable_filter input {
            height: 22px;
            width: 208px;
            color: #336B16;
            font-size: 14px;
            margin-bottom: 5%;
        }
    </style>



</asp:Content>


