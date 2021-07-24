<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Attendance_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_Attendance_Report_hcm_Attendance_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

        <script src="/JavaScript/jquery-1.8.3.min.js"></script>

        <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script> 
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>  
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>

          <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />


        <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />    
     <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />

   
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
                   
   .col-lg-3 {
    width: 28%;
}

    .dataTables_empty {
        text-align:center;
    }
   
</style>
    
   
 <script type="text/javascript">

     var $noCon = jQuery.noConflict();
     $noCon(window).load(function () {

         document.getElementById("freezelayer").style.display = "none";
         document.getElementById("<%=divPrintCaptionDetails.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=lblPrintOnBrdDtls.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=divPrintReportDetails.ClientID%>").style.visibility = "hidden";

         if (document.getElementById("cphMain_txtFromDate").value != "" && document.getElementById("cphMain_ddlDepartment").value != "--SELECT--") {
             SearchValidate();
         } 

     });
     function printsorted() {
         document.getElementById("cphMain_divPrintReportSorted").innerHTML = document.getElementById("divReportAttndncReportPrint").innerHTML;
     }
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

        var $au = jQuery.noConflict();
        function EndRequest(sender, args) {

            $au('#cphMain_ddlDepartment').selectToAutocomplete1Letter();
            $au('#cphMain_ddlDivision').selectToAutocomplete1Letter();
            $au('#cphMain_ddlProject').selectToAutocomplete1Letter();

            if (document.getElementById("<%=HiddenFieldFocus.ClientID%>").value == "div") {
                $("div#divDiv input.ui-autocomplete-input").focus();
            }
             else if (document.getElementById("<%=HiddenFieldFocus.ClientID%>").value == "dep") {
                $("div#divDep input.ui-autocomplete-input").focus();
            }
       }
        $au(function () {

            $au('#cphMain_ddlDepartment').selectToAutocomplete1Letter();
            $au('#cphMain_ddlDivision').selectToAutocomplete1Letter();
            $au('#cphMain_ddlProject').selectToAutocomplete1Letter();
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(EndRequest);
        });

        function SearchValidate() {
            var ret = true;
            var Dept = document.getElementById("cphMain_ddlDepartment").value;
            $("div#divDep input.ui-autocomplete-input").css("borderColor", "");

            if (Dept == "--SELECT--") {
                if (Dept == "--SELECT--") {
                    $("div#divDep input.ui-autocomplete-input").css("borderColor", "red");
                    $("div#divDep input.ui-autocomplete-input").focus();
                    $("div#divDep input.ui-autocomplete-input").select();
                }
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                ret = false;
            }


            if (document.getElementById("cphMain_txtFromDate").value == "") {
                document.getElementById("cphMain_txtFromDate").style.borderColor = "red";
                document.getElementById("cphMain_txtFromDate").focus();
                ret = false;
            }


            if (ret == true) {
                LoadAttendanceReport();
                LoadAttendanceReportPrint();
            }

            return false;
        }

        function CallCSVBtn() {
            document.getElementById("<%=BtnCSV.ClientID%>").click();
        }
</script>


<script>
    var $NoConfi = jQuery.noConflict();
    var $NoConfi3 = jQuery.noConflict();
        function LoadAttendanceReport() {
            var OrgId = '<%= Session["ORGID"] %>';
            var UserId = '<%= Session["USERID"] %>';
            var CorpId = '<%= Session["CORPOFFICEID"] %>';

            if (OrgId == "" || UserId == "" || CorpId == "") {
                window.location = "Security/Login.aspx.aspx";
            }

            var Date = document.getElementById("cphMain_txtFromDate").value;
            var DeparmentId = document.getElementById("cphMain_ddlDepartment").value;
            var DivisionId = document.getElementById("cphMain_ddlDivision").value;
            var ProjectId = document.getElementById("cphMain_ddlProject").value;

            var OtType = "";
            if (document.getElementById("cphMain_ddlOtType").value != "0") {
                var e = document.getElementById("<%=ddlOtType.ClientID%>");
                OtType = e.options[e.selectedIndex].value;
               }

            var responsiveHelper_datatable_fixed_column = undefined;

            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };

            /* COLUMN FILTER  */

            var otable = $NoConfi3('#datatable_fixed_column').DataTable({
                'bProcessing': false,
                'bServerSide': true,
                'sAjaxSource': 'data.ashx',
                "bDestroy": true,
                "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6 hidden-xs'f><'col-sm-6 col-xs-12 hidden-xs'<'toolbar'>>r>" +
                        "t" +
                        "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
                "autoWidth": true,
                "oLanguage": {
                    "sSearch": ' <span  class="input-group-addon"><i  class="glyphicon glyphicon-search"></i></span>'

                },
                "preDrawCallback": function () {
                    // Initialize the responsive datatables helper once.
                    if (!responsiveHelper_datatable_fixed_column) {
                        responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($NoConfi3('#datatable_fixed_column'), breakpointDefinition);
                    }
                },
                "rowCallback": function (nRow) {
                    responsiveHelper_datatable_fixed_column.createExpandIcon(nRow);
                },
                "drawCallback": function (oSettings) {
                    responsiveHelper_datatable_fixed_column.respond();
                },
                "fnServerParams": function (aoData) {
                    aoData.push({ "name": "ORG_ID", "value": OrgId });
                    aoData.push({ "name": "USERID", "value": UserId });
                    aoData.push({ "name": "CORPOFFICEID", "value": CorpId });

                    aoData.push({ "name": "DEP_ID", "value": DeparmentId });
                    aoData.push({ "name": "DIV_ID", "value": DivisionId });                    
                    aoData.push({ "name": "PROJECT_ID", "value": ProjectId });
                    aoData.push({ "name": "OT_TYP", "value": OtType });
                    aoData.push({ "name": "DATE", "value": Date });
                }, 
            });

            // Apply the filter

            $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                otable
                    .column($NoConfi(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();

            });
            /* END COLUMN FILTER */
        }


        </script>


    <script> //For Print
        var $NoConfic = jQuery.noConflict();
        var $NoConfic3 = jQuery.noConflict();
        function LoadAttendanceReportPrint() {
            var OrgId = '<%= Session["ORGID"] %>';
            var UserId = '<%= Session["USERID"] %>';
            var CorpId = '<%= Session["CORPOFFICEID"] %>';

            if (OrgId == "" || UserId == "" || CorpId == "") {
                window.location = "Security/Login.aspx.aspx";
            }

            var Date = document.getElementById("cphMain_txtFromDate").value;
            var DeparmentId = document.getElementById("cphMain_ddlDepartment").value;
            var DivisionId = document.getElementById("cphMain_ddlDivision").value;
            var ProjectId = document.getElementById("cphMain_ddlProject").value;

            var OtType = "";
            if (document.getElementById("cphMain_ddlOtType").value != "0") {
                var e = document.getElementById("<%=ddlOtType.ClientID%>");
                OtType = e.options[e.selectedIndex].value;
            }


            var otable = $NoConfic3('#datatable_fixed_columnPrint').DataTable({
                "pageLength": 100000,
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                'bProcessing': false,
                'bServerSide': true,
                'sAjaxSource': 'data.ashx',               
                "bDestroy": true,
               

                "fnServerParams": function (aoData) {
                    aoData.push({ "name": "ORG_ID", "value": OrgId });
                    aoData.push({ "name": "USERID", "value": UserId });
                    aoData.push({ "name": "CORPOFFICEID", "value": CorpId });

                    aoData.push({ "name": "DEP_ID", "value": DeparmentId });
                    aoData.push({ "name": "DIV_ID", "value": DivisionId });
                    aoData.push({ "name": "PROJECT_ID", "value": ProjectId });
                    aoData.push({ "name": "OT_TYP", "value": OtType });
                    aoData.push({ "name": "DATE", "value": Date });
                },
            });
        }

        </script>


     <style>






        .table td + td+td+td,
.table th + th+th+th
{
    text-align:center;
}
          #datatable_fixed_column_wrapper {
            border: 1px solid #065757;
        }
        .dt-toolbar  {
    border-bottom: 1px solid  #c8b6b6;
    background: #f4f6f0;
}
.dt-toolbar-footer  {
    border-top: 1px solid  #c8b6b6;
    background: #f4f6f0;
}
.table > thead > tr > th {
    background: #eee;
    color:#fff;
}
.table-bordered, .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
    border-bottom: 1px solid #c8b6b6;
    border-right: 1px solid  #c8b6b6;
}
.table {
    font-size: 13px;
}
.table-striped > tbody > tr:nth-of-type(2n+1) {
    background-color: #eaeaea;
}
        table.dataTable thead .sorting {
              background-color: #79895f;
        }
        table.dataTable thead .sorting_asc, table.dataTable thead .sorting_desc {
    background-color: #92a276;
}
        .table > thead > tr > th {
            padding: 8px 10px;
        }
        .table > tbody > tr > td {
            padding: 5px 10px;
            border-bottom: none;
        }

        .table {
            color: #3e3737;
            font-weight: bolder;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

     
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
      <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:4.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A2"  data-title="Item Listing"  style="float: right; margin-top:4%;color:rgb(83, 101, 51);font-family:Calibri;width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left: 39%;" ><span style="margin-top: 3px; float: right;margin-right: 20%;">CSV</span> </a> 
   
    
     <div style="cursor: default; float: right; height: 25px; margin-right: -2.5%; margin-top: 4%; font-family: Calibri;" class="print" onclick="printsorted()">
     <a id="A1" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/sort_EmpDtlsRprt.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -26px; float: right;"> Print</span></a>                                  
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
            <img src="/Images/BigIcons/Attendance Report.png" style="vertical-align: middle;" />
     Attendance Report
        </div >

    <div  style="border:.5px solid #9ba48b; background-color: #f3f3f3;margin-top:2%;width:100%;">
      
        <div class="row" style="margin-top:1.5%;margin-left:1%">


       <div class="col-lg-3"  >

            <h2 style="margin-top: 2%;">From Date*</h2>
                
               <div id="divFrmDate" class="input-append date" style="float: left;width: 40%;margin-left: 6%;margin-top: 1%;">
                        
                 <asp:TextBox ID="txtFromDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  Style="height:30px;width:100%;margin-top: 0%;float:left;margin-left: 6%;" onkeypress="return DisableEnter(event)"></asp:TextBox>

                        <input type="image"  id="Image1" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:30px; width:30px;margin-top:0%;" />

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
                                endDate: new Date(),
                            });
                        </script>

                        <p style="visibility: hidden">Please enter</p>
                       </div>

            </div>


           <div class="col-lg-3"  >

         <h2>OT Type</h2>
           <asp:DropDownList ID="ddlOtType" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="width:56%;height: 30px;  float: left; margin-left: 8%;" >
             <asp:ListItem Text="--SELECT--" Value="0" ></asp:ListItem>
             <asp:ListItem Text="NORMAL OT" Value="1" ></asp:ListItem>
             <asp:ListItem Text="HOLIDAY OT" Value="2"></asp:ListItem>
           </asp:DropDownList>
        </div>
        </div>

        <div style="display:none">
                     <div class="col-lg-3" id="divMon"  >
         <h2 style="">Month* </h2>
          <asp:DropDownList ID="ddlMonth" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="width:56%;height: 30px;  float: left; margin-left: 18%;">                 
         </asp:DropDownList>
        </div>
            <div class="col-lg-3" id="divYea"  >
         <h2>Year* </h2>
         <asp:DropDownList ID="ddlYear" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="width:56%;height: 30px;  float: left; margin-left: 15%;">                 
         </asp:DropDownList>
        </div>

        </div>
       
        <div class="row" style="margin-top:1.5%;margin-left:1%;margin-bottom:1.5%;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
   <ContentTemplate> 

         <asp:HiddenField ID="HiddenFieldFocus" runat="server" />
<%--         <asp:HiddenField ID="hiddenYear" runat="server" />--%>
         <div id="divDep" class="col-lg-3"  >
         <h2>Department*</h2>
        <asp:DropDownList ID="ddlDepartment" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="width:56%;height: 30px;  float: left; margin-left: 5%;" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged1">
           </asp:DropDownList>
        </div>


        <div id="divDiv" class="col-lg-3" >
         <h2>Division</h2>
        <asp:DropDownList ID="ddlDivision" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="width:56%;height: 30px;  float: left; margin-left: 9%;" AutoPostBack="true"  OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
        </asp:DropDownList>          
        </div>

         <div class="col-lg-3" >
         <h2>Project</h2>
         <asp:DropDownList ID="ddlProject" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="width:56%;height: 30px;  float: left; margin-left: 11.5%;">                 
         </asp:DropDownList>
        </div>
         </ContentTemplate>
</asp:UpdatePanel>
   
       </div>
           <div class="row">
           <div class="col-lg-12">
             <asp:Button ID="btnSearch" style="cursor:pointer;float:right;margin-right:2%;margin-top:-6%;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidate();" OnClick="btnSearch_Click" />
             <%--<input id="btnSearch" type="button"  style="cursor:pointer;float:right;margin-right:2%;margin-top:-6%;"  runat="server" class="searchlist_btn_lft" Value="Search" onclick="return SearchValidate();" />--%>
       </div>
                 </div>  
       

   </div>

    <br />


     <div id="divReport"  class="table-responsive" runat="server">
            <br />
         <br /> <br /> <br />   
         </div>



    <div id="divReportAttndncReport" class="widget-body no-padding dataTables_wrapper" style="margin-top: 0.5%;width: 100%;margin-left:0.2%;">
          <table id="datatable_fixed_column" class="table table-striped table-bordered" width="100%" style="font-family: Calibri;">
                <thead>
                    <tr>
                        <th data-class="expand">DATE</th>
                        <th data-class="expand">EMPLOYEE ID</th>
                        <th data-class="expand">EMPLOYEE</th>
                        <th data-class="expand">DESIGNATION</th>
                        <th data-class="expand">PROJECT</th>
                        <th data-class="expand">IDLE HOURS</th>
                        <th data-class="expand">OT TYPE</th>
                        <th data-class="expand">OT HOURS</th>
                        <th data-class="expand">TOTAL HOURS</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td style="text-align:center;" colspan="9" class="dataTables_empty">No data available in table</td>
                    </tr>
                </tbody>
            </table>          
        </div>



     <div id="divReportAttndncReportPrint" class="widget-body no-padding dataTables_wrapper" style="display:none;margin-top: 0.5%;width: 100%;margin-left:0.2%;">
          <table id="datatable_fixed_columnPrint" class="main_table dataTable no-footer" width="100%" style="font-family: Calibri;">
                <thead>
                    <tr class="main_table_head">
                        <th class="thT sorting" >DATE</th>
                        <th class="thT sorting" >EMPLOYEE ID</th>
                        <th class="thT sorting" >EMPLOYEE</th>
                        <th class="thT sorting" >DESIGNATION</th>
                        <th class="thT sorting" >PROJECT</th>
                        <th class="thT sorting" >IDLE HOURS</th>
                        <th class="thT sorting" >OT TYPE</th>
                        <th class="thT sorting" >OT HOURS</th>
                        <th class="thT sorting" >TOTAL HOURS</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td colspan="9" class="dataTables_empty">No data available...</td>
                    </tr>
                </tbody>
            </table>          
        </div>


    <div id="divAttdncreport" class="widget-body no-padding" style="margin-top: 0.5%;width: 98%;margin-left:0.2%;"> 
   
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
      Attendance Report
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
                #ReportTable_filter input {
            height: 22px;
            width: 208px;
            color: #336B16;
            font-size: 14px;
            margin-bottom: 5%;
        }
    </style>

      <style>
       .table td + td+td+td,
.table th + th+th+th
{
    text-align:center;
}
          #datatable_fixed_column_wrapper {
            border: 1px solid #065757;
        }
        .dt-toolbar  {
    border-bottom: 1px solid  #c8b6b6;
    background: #f4f6f0;
}
.dt-toolbar-footer  {
    border-top: 1px solid  #c8b6b6;
    background: #f4f6f0;
}
.table > thead > tr > th {
    background: #eee;
    color:#fff;
}
.table-bordered, .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
    border-bottom: 1px solid #c8b6b6;
    border-right: 1px solid  #c8b6b6;
}
.table {
    font-size: 13px;
}
.table-striped > tbody > tr:nth-of-type(2n+1) {
    background-color: #eaeaea;
}
        table.dataTable thead .sorting {
              background-color: #79895f;
        }
        table.dataTable thead .sorting_asc, table.dataTable thead .sorting_desc {
    background-color: #92a276;
}
        .table > thead > tr > th {
            padding: 8px 10px;
        }
        .table > tbody > tr > td {
            padding: 5px 10px;
            border-bottom: none;
        }

        .table {
            color: #3e3737;
            font-weight: bolder;
        }



      .cont_rght {
            width: 98%;
        }  


div.dataTables_wrapper div.dataTables_processing {   
   top: 600%;
}


table.dataTable thead > tr > th.sorting_disabled {   
    background-color: #79895f;
}

    .form-control {
        height: 18px;
    }

    table.dataTable thead .sorting {
    background-color: #79895f;
}

    .table > thead > tr > th {
    background: #79895f;
    color: #fff;
}

          .dataTables_empty {
             text-align: center !important; 
          }

    </style>
   
</asp:Content>

