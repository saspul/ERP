<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Leave_Application_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_Leave_Application_Report_hcm_Leave_Application_Report" %>

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

                 .cont_rght h2 {
    font-family: Calibri;
    font-size: 17px;
    float: left;
    text-align: left;
    color: #909c7b;
    padding: 0;
    margin: 0 0 6px;
    line-height: 1;
    font-weight: normal;
}
                    .open > .dropdown-menu {
    display: none;
}
</style>
    
    <script src="/JavaScript/jquery-1.8.3.min.js"></script>
 <script type="text/javascript">

     var $noCon = jQuery.noConflict();
     $noCon(window).load(function () {      
         document.getElementById("freezelayer").style.display = "none";      
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
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                // "pageLength": 25,
                "bLengthChange": false,
                "bPaginate": false
            });
        });

     </script>

    <script>
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
        function printsorted() {
            document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
            //    $('#cphMain_divPrintReportSorted table tr').find('td:eq(4),th:eq(4)').remove();
        }

        var $au = jQuery.noConflict();
        $au(function () {
            $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
        });

        function SearchValidate() {


            var dtFromDate = document.getElementById("cphMain_txtFromDate").value;
            var dtToDate = document.getElementById("cphMain_txtToDate").value;

            document.getElementById("cphMain_txtFromDate").style.borderColor = "";
            document.getElementById("cphMain_txtToDate").style.borderColor = "";
            if (dtFromDate != "" && dtToDate != "") {

                var RcptdatepickerDate = dtFromDate;
                var RarrDatePickerDate = RcptdatepickerDate.split("-");
                var RdateDateCntrlr = new Date(RarrDatePickerDate[2], RarrDatePickerDate[1] - 1, RarrDatePickerDate[0]);


                var CurrentDateDate = dtToDate;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                if (RdateDateCntrlr > dateCurrentDate) {
                    document.getElementById("cphMain_txtToDate").style.borderColor = "Red";
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,from date cannot be greater than to date !.";
                    document.getElementById("cphMain_txtToDate").focus();
                    return false;
                }

            }
            else {              
                if (dtToDate == "") {
                    document.getElementById("cphMain_txtToDate").style.borderColor = "Red";
                    document.getElementById("cphMain_txtToDate").focus();
                }
                if (dtFromDate == "") {
                    document.getElementById("cphMain_txtFromDate").style.borderColor = "Red";
                    document.getElementById("cphMain_txtFromDate").focus();
                }
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                return false;
            }
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

     
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
          <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:4.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A2"  data-title="Item Listing"  style="float: right; margin-top:4%;color:rgb(83, 101, 51);font-family:Calibri;width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left: 39%;" ><span style="margin-top: 3px; float: right;margin-right: 20%;">CSV</span> </a> 
        <div style="cursor: default; float: right; height: 25px; margin-right: -2.5%; margin-top: 4%; font-family: Calibri;" class="print" onclick="printsorted()">
     <a id="A1" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/sort_EmpDtlsRprt.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -22px; float: right;"> Print</span></a>                                  
</div>
  
    <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 4%; font-family: Calibri;display:none" class="print">
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
            <img src="/Images/BigIcons/Leave Application Report.png" style="vertical-align: middle;" />
     Leave Application Report
        </div >

    <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;width: 100%;margin-top:3%;height:131px;">

        
        <div style="width:100%;float:left;">
         <div class="eachform" style="float: left;width: 30%;margin-top:1.5%;">
                <h2 style="margin-top: 2%;margin-left: 7%;">From Date*</h2>
                
               <div id="divFrmDate" class="input-append date" style="float: left;width: 40%;margin-left: 6%;margin-top: 1%;">
                        
                 <asp:TextBox ID="txtFromDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  Style="height:30px;width:77.6%;margin-top: 0%;float:left;margin-left: -2.3%;" onkeydown="return isTag(event)" onkeypress="return isTag(event)"></asp:TextBox>

                        <input type="image"  id="Image1" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

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
                            $noC('#divFrmDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //endDate: new Date(),
                            });
                        </script>

                        <p style="visibility: hidden">Please enter</p>
                       </div>

            </div>
      

      <div class="eachform" style="float:left;width:27%;margin-top:1.5%;">
                <h2 style="margin-top: 2%;">To Date*</h2>
                
                 <div id="divToDate" class="input-append date" style="float:left;margin-left:3%;width: 52%;margin-top:1%">

                  <asp:TextBox ID="txtToDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  Style="height:30px;width:73.6%;margin-top: 0%;float:left;margin-left: 0%;" onkeydown="return isTag(event)" onkeypress="return isTag(event)"></asp:TextBox>

                        <input type="image" id="Image2" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;"  />
                       
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
           

       <div style="margin-top:2%;margin-left:2%;width:28%;float:left;">
         <h2>Leave Type</h2>
           <asp:DropDownList ID="ddlLeaveType" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="height: 30px; width: 50%; float: left; margin-left: 2%;" >
           </asp:DropDownList>
        </div>
        </div>

        <div style="width:100%;float:left;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
   <ContentTemplate> 
         <div style="margin-top:1%;margin-left:2%;width:25%;float:left;">
         <h2>Department</h2>
        <asp:DropDownList ID="ddlDepartment" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="height: 30px; width: 54%; float: left; margin-left: 5%;" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged1">
           </asp:DropDownList>
        </div>


        <div style="margin-top:1%;margin-left:3%;width:28%;float:left;">
         <h2>Division</h2>
        <asp:DropDownList ID="ddlDivision" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="height: 30px; width: 52%; float: left; margin-left: 4%;">
           </asp:DropDownList>
        </div>

         <div style="margin-top:1%;margin-left:1%;width:28%;float:left;">
         <h2>Status</h2>
        <asp:DropDownList ID="ddlStatus" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="height: 30px; width: 50%; float: left; margin-left: 11.5%;">
                    <asp:ListItem Text="--SELECT--" Value="9" ></asp:ListItem>
                    <asp:ListItem Text="PENDING" Value="0" ></asp:ListItem>
                    <asp:ListItem Text="REPORTING OFFICER APPROVED" Value="1"></asp:ListItem>
                    <asp:ListItem Text="DIVISION MANAGER APPROVED" Value="2"></asp:ListItem>
                    <asp:ListItem Text="GENERAL MANAGER APPROVED" Value="3"></asp:ListItem>
                    <asp:ListItem Text="HR APPROVED" Value="4"></asp:ListItem>
                    <asp:ListItem Text="REJECTED" Value="5"></asp:ListItem>
                    <asp:ListItem Text="CANCEL PENDING" Value="6"></asp:ListItem>
                    <asp:ListItem Text="CANCELLED" Value="7"></asp:ListItem>
                    <asp:ListItem Text="CLOSED" Value="8"></asp:ListItem>              
             </asp:DropDownList>
        </div>
         </ContentTemplate>
</asp:UpdatePanel>
    <asp:Button ID="btnSearch" style="cursor:pointer;float:right;margin-right:2%;margin-top:-1.5%;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidate();"  OnClick="btnSearch_Click"  />
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
     Leave Application Report
      </div>
               <div id="divPrintReportSorted" runat="server" style="display: none">
                                    <br />
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
    <style>
             .open > .dropdown-menu {
    display: none;
}
                     #ReportTable_filter input {
            height: 20px;
            width: 208px;
            color: #336B16;
            font-size: 14px;
            margin-bottom: 5%;
        }
</style>
</asp:Content>

