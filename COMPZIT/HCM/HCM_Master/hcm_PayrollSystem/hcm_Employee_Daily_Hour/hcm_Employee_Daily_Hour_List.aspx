<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Employee_Daily_Hour_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Employee_Daily_Hour_hcm_Employee_Daily_Hour_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
 
    <script src="../../../../css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="../../../../css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
    <script src="../../../../css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../../../../css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="../../../../css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>

    <link href="../../../../css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../../css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="../../../../css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="../../../../css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />
      <%--<link href="../../../../css/HCM/main.css" rel="stylesheet" />--%>
    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />

     <script src="/js/HCM/Common.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
              HideLoading();
              LoadCustomerList();
              $noCon("input.form-control:first").focus();
          });


          </script>
   <script>
       //for search option
       var $NoConfi = jQuery.noConflict();
       var $NoConfi3 = jQuery.noConflict();


       function LoadCustomerList() {
          

           var orgID = '<%= Session["ORGID"] %>';
           var corptID = '<%= Session["CORPOFFICEID"] %>';
           var Month = $NoConfi('#cphMain_DropDownList2').val();
           var Year = $NoConfi('#cphMain_DropDownList3').val();
          
          
            var responsiveHelper_datatable_fixed_column = undefined;


            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };

            /* COLUMN FILTER  */
            
            var otable = $NoConfi3('#datatable_fixed_column').DataTable({
               
                'bProcessing': true,
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
                    aoData.push({ "name": "ORG_ID", "value": orgID });
                    aoData.push({ "name": "CORPT_ID", "value": corptID });
                    aoData.push({ "name": "MONTH", "value": Month });
                    aoData.push({ "name": "YEAR", "value": Year });
                }
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
       function ViewRow(Month, Year, TableSts) {
           document.getElementById("<%=HiddenViewId.ClientID%>").value = Month + "-" + Year + "$" + TableSts;
           document.getElementById("<%=btnRedirect.ClientID%>").click();
           return false;        
       }
       function ConfirmAll(Month, Year, Mode, TableSts) {
           var strMODE="";
           if (Mode == "1") {
               strMODE = "REOPEN";               
           } else {
               strMODE = "CONFIRM";
           }

           ezBSAlert({
               type: "confirm",
               messageText: "Are you sure you want to " + strMODE.toLocaleLowerCase() + "?",
               alertType: "info"
           }).done(function (e) {
               if (e == true) {

                   if (strMODE == "REOPEN") {

                       ShowLoading();
                   }

                    var orgID = '<%= Session["ORGID"] %>';
                    var corptID = '<%= Session["CORPOFFICEID"] %>';
                    var userID = '<%= Session["USERID"] %>';
                    var Id = Month + "-" + Year;
                    if (orgID == "" || corptID == "" || userID == "") {
                        window.location.href = "/Default.aspx";
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "hcm_Employee_Daily_Hour_List.aspx/ConfirmDtlsAll",
                        data: '{Id: "' + Id + '",orgID: "' + orgID + '",corptID: "' + corptID + '",userID: "' + userID + '",Mode: "' + Mode + '",TableSts: "' + TableSts + '"}',
                        dataType: "json",
                        success: function (data) {
                            if (data.d == "SUCCESS") {
                                var successMsg = "Confirmed successfully."
                                if (strMODE == "REOPEN") {
                                    successMsg = "Reopened successfully."
                                }
                                window.location.href = "hcm_Employee_Daily_Hour_List.aspx?InsUpd=" + strMODE;
                            }
                            else if (data.d == "NO_LOA") {
                                $noCon("#warning-alert").html("There is no leave type defined with \"leave-on-absence\" property");
                                $noCon("#warning-alert").fadeTo(9000, 500).slideUp(500, function () {
                                });
                                $noCon("#warning-alert").alert();
                            }
                            else if (data.d == "ERROR") {
                                //error
                                $noCon("#warning-alert").html("Some error occured. Please contact system administrator.");
                                $noCon("#warning-alert").fadeTo(9000, 500).slideUp(500, function () {
                                });
                                $noCon("#warning-alert").alert();
                            }
                            else if (data.d == "ALL_CONF") {
                                if (Mode == "0") {
                                    $noCon("#warning-alert").html("Daily attendance sheets already confirmed");
                                }
                                else {
                                    $noCon("#warning-alert").html("Daily attendance sheets already reopened");

                                   
                                }
                                $noCon("#warning-alert").fadeTo(9000, 500).slideUp(500, function () {
                                });
                                $noCon("#warning-alert").alert();

                                //0041
                                HideLoading();
                                //end
                            }
                        }
                    });
                    return false;
                }
               else {
                   HideLoading();
                    return false;
                }
            });
            return false;
       }
       function SuccessConfirmation() {
           $noCon("#success-alert").html("Daily attendance sheets confirmed successfully.");
           $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
           });
           $noCon("#success-alert").alert();
           return false;
       }
       function SuccessReopen() {
           $noCon("#success-alert").html("Daily attendance sheets reopened successfully.");
           $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
           });
           $noCon("#success-alert").alert();
           return false;
       }
       function ReOpenNotPossible() {
           alert("Sorry, reopen denied!");
           return false;
       }
       function ConfNotPossible() {
           alert("Sorry, confirmation denied!");
           return false;
       }
    </script>
  
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="btnRedirect" runat="server" Text="Button" style="display:none;" OnClick="btnRedirect_Click" />
    <asp:HiddenField ID="HiddenViewId" runat="server" />
   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">
         <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button>  
        </div>
          <div class="alert alert-warning" id="warning-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button>  
        </div>

        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/employee-daily-hour-calculation.png" style="vertical-align: middle;" />
           Daily Attendance List
        </div >
      
        <br />

        <div onclick="location.href='hcm_Employee_Daily_Hour.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;">

       
        </div>



          <div class="smart-form" style="float: left;width: 93.5%;display:none;">
         <div id="dedctndiv" style="width: 60%; float: right;">

                                            <section style="width: 95%; margin-left: 7%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Month & Year</label>
                                                  <div id="div2">

                                            <label class="select">
                                                <asp:DropDownList runat="server" ID="DropDownList2" style="float: left;width: 22%;" onkeypress="return IsEnter(event);" onchange="IncrmntConfrmCounter()" >
                                                </asp:DropDownList>
                                                                   <asp:DropDownList runat="server" ID="DropDownList3" onchange="IncrmntConfrmCounter()" style="float: left;width: 22%;" onkeypress="return IsEnter(event);" >
                                                </asp:DropDownList>

                                            </label>
                                        </div>
                                                 <asp:Button ID="btnsearch" runat="server" Style="background-color: #1c74a4; width: 75px; height: 27px; padding: 2px;float:left;margin-left:7%"  class="btn btn-info" Text="Search" OnClientClick="return validateSearch();" />
                                            </section>

            
                                        </div>
              </div>






         <div id="divOrgBranchList" class="widget-body no-padding" style="width: 93.5%;">

            <table id="datatable_fixed_column" class="table table-striped table-bordered" width="100%" style="font-family:Calibri;" >
                <thead>
                    <tr>
                         <th class="hasinput" style="width: 30%"><input type="text" class="form-control" placeholder="Month" onkeydown="return DisableEnter(event)"  /></th>                        
                          <th class="hasinput" style="width: 15%"><input type="text" class="form-control" placeholder="Year" onkeydown="return DisableEnter(event)" style="text-align:center;" /></th>
                        <th class="hasinput" style="width:13%"><input type="text" class="form-control" placeholder="Number Of Records" onkeydown="return DisableEnter(event)" style="text-align:center;"  /></th>
                        <%--  <th class="hasinput" style="width:30%"><input type="text" class="form-control" placeholder="File Name" onkeydown="return DisableEnter(event)" /></th>--%>
                         <th class="hasinput" style="width: 7%;"></th>
                    </tr>
<tr >
   
    <th data-class="expand">Month</th>
      <th data-class="expand">Year</th>
    <th data-class="expand">Number of records</th>   
   <%-- <th data-class="expand">File Name</th> --%>
    <th data-class="expand">ACTION</th>
    
  
    </tr>
                    </thead>
                <tbody> 
            <tr> 
                <td colspan="7" class="dataTables_empty">Loading details...</td> 
            </tr> 
            </tbody> 
                    </table>
        </div>

          
    </div>


    <div id="myModalLoadingMail" class="modalLoadingMail">
        <!-- Modal content -->
        <div>
            <img src="/Images/Other Images/LoadingMail.gif" style="width: 12%;" />
        </div>
    </div>

    <style>
        table.dataTable tbody td {
            word-break:break-all;          
        }
        
         .table {
            font-size:13px;
        }
          
        #datatable_fixed_column_wrapper {
            border: 1px solid  #c8b6b6;
        }
 
    td:nth-child(2),th:nth-child(2),td:nth-child(3),th:nth-child(3),td:nth-child(4),th:nth-child(4) {
   text-align: center;
}
                            .dt-toolbar  {
    border-bottom: 1px solid  #c8b6b6;
}
.dt-toolbar-footer  {
    border-top: 1px solid  #c8b6b6;
}
.table-bordered, .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
    border-bottom: 1px solid #c8b6b6;
    border-right: 1px solid  #c8b6b6;
}
    </style>
    <script>
        function validateSearch() {
            var flag = true;
            $NoConfi('#cphMain_DropDownList2,#cphMain_DropDownList3').each(function () {

                if ($NoConfi.trim($NoConfi(this).val()) == '0' || $NoConfi.trim($NoConfi(this).val()) == '--SELECT MONTH--' || $NoConfi.trim($NoConfi(this).val()) == '--SELECT YEAR--') {
                    isValid = false;
                    $NoConfi(this).css({
                        "border": "1px solid red",
                        "background": ""
                    });
                    flag = false;
                }
                else {
                    $NoConfi(this).css({
                        "border": "",
                        "background": ""
                    });
                }
            });
            if (flag == true) {
                LoadCustomerList();
            }
            return false;
        }
    </script>


    <style>
                .modalLoadingMail {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 30; /* Sit on top */
            padding-top: 19%; /* Location of the box */
            left: 0;
            top: 0;
            width: 90%; /* Full width */
            /*height: 58%;*/ /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: transparent;
            padding-left: 45%; /* Location of the box */
        }

        /* Modal Content */
        .modal-contentLoadingMail {
            /*position: relative;*/
            background-color: #fefefe;
            margin: auto;
            padding: 0;
            /*border: 1px solid #888;*/
            width: 95.6%;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
        }
    </style>

    <script>
        function ShowLoading() {

            document.getElementById("myModalLoadingMail").style.display = "block";

            //document.getElementById("freezelayer").style.display = "";
        }

        function HideLoading() {

            document.getElementById("myModalLoadingMail").style.display = "none";

            //document.getElementById("freezelayer").style.display = "none";
        }

    </script>
</asp:Content>



