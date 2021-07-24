<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Monthly_WPS_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Employee_Deduction_hcm_Employee_Deduction_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>

    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />
    <link href="/css/HCM/main.css" rel="stylesheet" />
    <link href="../../../../css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="../../../../js/jQueryUI/jquery-ui.min.js"></script>
    <script src="../../../../js/jQueryUI/jquery-ui.js"></script>
    <script src="../../../../js/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../../js/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="/js/HCM/Common.js"></script>
    <%--     <script src="/js/HCM/Common.js"></script>--%>
    <script type="text/javascript">

        var $NoConfii = jQuery.noConflict();
        $NoConfii(document).ready(function () {
            $('#loading').hide();

        });
        var confirmbox = 0;
        function IncrmntConfrmCounter() {

            confirmbox++;

        }
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            LoadEmpList();
            document.getElementById("<%= btnExportToCSV.ClientID%>").style.display = "none";

           // LoadCustomerRemovePagnation();
            
            ChangeMode("0");
            var sessionValue = '<%= Session["Succes"] %>';

              if (sessionValue == "confirmed")
                  SuccesMessage();
              SetDate();

          });
          //$noCon(document).ready(function () {
          //    var RowCount = document.getElementById("datatable_fixed_column").rows.length;
          //    RowCount = RowCount - 2;
          //});
          function SuccesMessage() {

              SuccessMsg("SAVE", "Confirmed Successfully.");


              return false;
          }


          function ChangeMode(x) {

              if (x != "0") {
                  IncrmntConfrmCounter();
              }
              $noCon('#dedctndiv').hide();
              $noCon('#processdatediv').hide();

              var Mode = $noCon('#cphMain_ddlmode').val();

              if (Mode == 1)

                  $noCon('#dedctndiv').show();
              else if (Mode != 0)
                  $noCon('#processdatediv').show();

              return false;
          }
          var $NoConfi = jQuery.noConflict();
          function validateSearch()
          {
              var flag = true;
              flag = MonthYear();
              $NoConfi('#cphMain_ddlmode,#cphMain_ddlEmployee,#cphMain_ddlPayerBank,#cphMain_ddlBank').each(function () {

                  if ($NoConfi.trim($NoConfi(this).val()) == '0' || $NoConfi.trim($NoConfi(this).val()) == '--SELECT BUSINESS UNIT--' || $NoConfi.trim($NoConfi(this).val()) == '--SELECT BANK--' || $NoConfi.trim($NoConfi(this).val()) == '--SELECT BANK--') {
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

              if (flag == true)
                  $('#loading').show();
             
              return flag;
          }
          function MonthYear()
          {
            
              document.getElementById("<%=ddlMonth.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddlYear.ClientID%>").style.borderColor = "";
              var flag = true;
              if (document.getElementById("<%=ddlmode.ClientID%>").value == "1") {

                  if (document.getElementById("<%=ddlMonth.ClientID%>").value == "--SELECT MONTH--") {
                      document.getElementById("<%=ddlMonth.ClientID%>").style.borderColor = "Red";
                      flag = false;
                  }

                  if (document.getElementById("<%=ddlYear.ClientID%>").value == "--SELECT YEAR--") {
                      document.getElementById("<%=ddlYear.ClientID%>").style.borderColor = "Red";
                      flag = false;
                  }
              }
              if (document.getElementById("<%=ddlmode.ClientID%>").value == "2" || document.getElementById("<%=ddlmode.ClientID%>").value == "3") {
                  if (document.getElementById("txtefctvedate").value == "")
                  {
                     
                      //document.getElementById("txtefctvedate").style.borderColor = "Red";
                      //flag = false;
                  }
                  else {
                      document.getElementById("txtefctvedate").style.borderColor = "";
                      flag = true;
                  }
              }
              return flag;
          }
    </script>
    <script>

        //for search option
       // var $NoConfi = jQuery.noConflict();
      //  var $NoConfi3 = jQuery.noConflict();

<%--
        function LoadCustomerList()
        {

            var orgID = '<%= Session["ORGID"] %>';
           var corptID = '<%= Session["CORPOFFICEID"] %>';
           var Mode = $NoConfi('#cphMain_ddlmode').val();
           var BusnsUnit = $NoConfi('#cphMain_ddlEmployee').val();

           var Month = $NoConfi('#cphMain_ddlMonth').val();
           var Year = $NoConfi('#cphMain_ddlYear').val();
           var ProcessDate = $NoConfi('#cphMain_Hiddentxtefctvedate').val();
           var ProcessDate1 = $NoConfi('#txtDateFrom').val();
           if (ProcessDate == "") {
               ProcessDate = ProcessDate1;           }
           if (ProcessDate1 != "") {
               document.getElementById("<%=HiddenPrsDate.ClientID%>").value = ProcessDate1;
                          }
           var Bank = $NoConfi('#cphMain_ddlBank').val();
           var Designation = $NoConfi('#cphMain_ddldesg').val();
           var Department = $NoConfi('#cphMain_ddlDep').val();
           var Division = $NoConfi('#cphMain_ddlDivision').val();
           var Type = 0;
           if ($NoConfi("#cphMain_radioCustType1").prop("checked")) {
               Type = 1;
           }

           document.getElementById("<%=HiddenType.ClientID%>").value = Type;
           var responsiveHelper_datatable_fixed_column = undefined;


           var breakpointDefinition = {
               tablet: 1024,
               phone: 480
           };

            /* COLUMN FILTER  */
     

           var otable = $NoConfi3('#datatable_fixed_column').DataTable({
               //// "bPaginate": true,
               //'bProcessing': true,
               //'bServerSide': true,
               //"bSort": false,
               ////   "bSortable": false, "aTargets": [0],
               //'sAjaxSource': 'dataVIewWPSList.ashx',
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
               }//,
               //"fnServerParams": function (aoData) {
               //    aoData.push({ "name": "ORG_ID", "value": orgID });
               //    aoData.push({ "name": "CORPT_ID", "value": corptID });
               //    aoData.push({ "name": "MODE", "value": Mode });
               //    aoData.push({ "name": "BSNS_UNIT", "value": BusnsUnit });
               //    aoData.push({ "name": "MONTH", "value": Month });
               //    aoData.push({ "name": "YEAR", "value": Year });
               //    aoData.push({ "name": "PRCS_DATE", "value": ProcessDate });
               //    aoData.push({ "name": "TYPE", "value": Type });
               //    aoData.push({ "name": "BANK", "value": Bank });
               //    aoData.push({ "name": "DESIG_ID", "value": Designation });
               //    aoData.push({ "name": "DEP_ID", "value": Department });
               //    aoData.push({ "name": "DIV_ID", "value": Division });
               //}
           });

           document.getElementById("<%= btnExportToCSV.ClientID%>").style.display = "none";
        }
        --%>
    
        var $NoConfig = jQuery.noConflict();
        var $NoConfi4 = jQuery.noConflict();


        function LoadEmpList() {


              var orgID = '<%= Session["ORGID"] %>';
              var corptID = '<%= Session["CORPOFFICEID"] %>';



              var responsiveHelper_datatable_fixed_column = undefined;


              var breakpointDefinition = {
                  tablet: 1024,
                  phone: 480
              };
            /* COLUMN FILTER  */
              var otable = $NoConfi4('#datatable_fixed_column').DataTable({
                  //"bFilter": false,

                  //"bInfo": false,
                  //"bLengthChange": false
                  //"bAutoWidth": false,
                  //"bPaginate": false,
                  //"bStateSave": true // saves sort state using localStorage
                 // "bSortable": false, "aTargets": [0],
                  "bDestroy": true,

                  "preDrawCallback": function () {
                      // Initialize the responsive datatables helper once.
                      if (!responsiveHelper_datatable_fixed_column) {
                          responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($NoConfi4('#datatable_fixed_column'), breakpointDefinition);
                      }
                  },
                  "rowCallback": function (nRow) {

                      responsiveHelper_datatable_fixed_column.createExpandIcon(nRow);
                  },
                  "drawCallback": function (oSettings) {

                      responsiveHelper_datatable_fixed_column.respond();
                  }

              });

              // custom toolbar
              //$NoConfi("div.toolbar").html('<div class="text-right"><select / style="Margin-top:10px;"></div>');

              // Apply the filter
              $NoConfig("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                  otable
                      .column($NoConfig(this).parent().index() + ':visible')
                      .search(this.value)
                      .draw();

              });


          }
        function RemovePagn() {
            var responsiveHelper_datatable_fixed_column = undefined;
            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };
            /* COLUMN FILTER  */
            var otable = $NoConfi4('#datatable_fixed_column').DataTable({
              
                "bPaginate": false,
                "bDestroy": true,
                "preDrawCallback": function () {
                    // Initialize the responsive datatables helper once.
                    if (!responsiveHelper_datatable_fixed_column) {
                        responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($NoConfi4('#datatable_fixed_column'), breakpointDefinition);
                    }
                },
                "rowCallback": function (nRow) {

                    responsiveHelper_datatable_fixed_column.createExpandIcon(nRow);
                },
                "drawCallback": function (oSettings) {

                    responsiveHelper_datatable_fixed_column.respond();
                }
            });
            // Apply the filter
            $NoConfig("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                otable
                    .column($NoConfig(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();

            });

        }
      
       function Close(id, Mode) {
           var userId = '<%= Session["USERID"] %>';
           var Paid = "";
           if (Mode != "1") {
               Paid = $NoConfi('#txtPaid' + id).val();

           }
           ConfirmClose(userId, id, Mode, Paid);
           return false;
       }


       function CloseAll() {
           var Ids = $NoConfi('#allIds1').val();
           if (Ids == undefined)
               return false;
           var userId = '<%= Session["USERID"] %>';
           var Mode = $noCon('#cphMain_ddlmode').val();
           ConfirmCloseAll(userId, Ids, Mode);
           return false;
       }
       function ConfirmCloseAll(userId, Ids, Mode) {
           ezBSAlert({
               type: "confirm",
               messageText: "Are you sure you want to close payment process?",
               alertType: "info"
           }).done(function (e) {
               if (e == true) {
                   var Paid = "";
                   var DeleteRowNum = Ids.split(',');
                   for (var i = 0; i < DeleteRowNum.length; i++) {
                       if (Mode != "1") {
                           Paid = $NoConfi('#txtPaid' + DeleteRowNum[i]).val();
                       }
                       var Details = PageMethods.PaymentClose(userId, DeleteRowNum[i], Mode, Paid, function (response) {
                          // LoadCustomerList();
                       });
                   }
                   return false;
               }
               else {
                   return false;
               }
           });
           return false;
       }

       function ConfirmClose(userId, id, Mode, Paid) {
           ezBSAlert({
               type: "confirm",
               messageText: "Are you sure you want to close payment process?",
               alertType: "info"
           }).done(function (e) {
               if (e == true) {

                   var Details = PageMethods.PaymentClose(userId, id, Mode, Paid, function (response) {
                       SuccessMsg("SAVE", "Payment process closed successfully.");
                      // LoadCustomerList();
                   });
                   return false;
               }
               else {
                   return false;
               }
           });
           return false;
       }
       function ConfirmCancel() {
           if (confirmbox > 0)
               CancelAlert("hcm_Monthly_Salary_WPS_List.aspx");
           else
               window.location.href = "hcm_Monthly_Salary_WPS_List.aspx";
           return false;
       }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
       <asp:HiddenField ID="HiddenFieldIndividualRound" runat="server" value="0"/> 
    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>

    <div class="cont_rght" style="padding: 0px 0 0;">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/Genarate-WPS-List.png" style="vertical-align: middle;" />
            Generate WPS List
        </div>

        <br />

        <div onclick="ConfirmCancel();" id="divlis" class="list" runat="server" style="top:22%; position: fixed; height: 26.5px; right: 1%; z-index: 1">
        </div>
        <div class="smart-form" style="float: left; width: 100%;">
            <div style="float: left; width: 98%; background: white; margin-top: 2%; margin-bottom: 2%; padding-left: 1%; background-color: #ddd; border: .5px solid; border-color: #9ba48b;">

                <div style="width: 100%; float: left;" class="formdiv">
                    <div style="width: 50%; float: left;">

                        <section style="width: 95%; margin-left: 5%;">
                            <label class="lblh2" style="float: left; width: 27%;">Mode*</label>
                            <div id="div1">

                                <label class="select">
                                    <asp:DropDownList runat="server" ID="ddlmode" Style="float: left; width: 60%;" onkeypress="return IsEnter(event);" onchange="ChangeMode(1)">
                                        <asp:ListItem Text="---SELECT MODE---" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Salary process" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Leave settlement" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="End of service settlement" Value="3"></asp:ListItem>
                                    </asp:DropDownList>

                                </label>
                            </div>
                        </section>


                    </div>
                    <div id="dedctndiv" style="width: 50%; float: left; display: none">

                        <section style="width: 95%; margin-left: 7%;">
                            <label class="lblh2" style="float: left; width: 27%;">Salary Month & Year</label>
                            <div id="div2">

                                <label class="select">
                                    <asp:DropDownList runat="server" ID="ddlMonth" Style="float: left; width: 30%;" onkeypress="return IsEnter(event);" onchange="IncrmntConfrmCounter()">
                                    </asp:DropDownList>
                                    <asp:DropDownList runat="server" ID="ddlYear" onchange="IncrmntConfrmCounter()" Style="float: left; width: 30%;" onkeypress="return IsEnter(event);">
                                    </asp:DropDownList>

                                </label>
                            </div>
                        </section>


                    </div>
                    <div id="processdatediv" style="width: 50%; float: left; display: none">

                        <div style="width: 100%; float: left;">

                            <section style="width: 95%; margin-left: 7%;">
                                <label class="lblh2" style="float: left; width: 27%;">Settled Date</label>
                                <label class="input" style="float: left; width: 60%;">
                                    <input id="txtefctvedate" name="txtefctvedate" type="text" class="Tabletxt form-control datepicker" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" onchange="GetDate()" style="width: 73%;" />
                                    <asp:HiddenField ID="Hiddentxtefctvedate" runat="server" />
                                    <asp:HiddenField ID="HiddennXTid" runat="server" />
                                    <asp:HiddenField ID="HiddenEID" runat="server" />
                                    <asp:HiddenField ID="HiddenDATE" runat="server" />
                                    <asp:HiddenField ID="HiddenTIME" runat="server" />
                                    <asp:HiddenField ID="HiddenBANK" runat="server" />
                                    <asp:HiddenField ID="HiddenIBAN" runat="server" />
                                    <asp:HiddenField ID="HiddenT_SAL" runat="server" />
                                    <asp:HiddenField ID="HiddenRECORD" runat="server" />
                                    <asp:HiddenField ID="HiddenQID" runat="server" />
                                    <asp:HiddenField ID="HiddenVISA" runat="server" />
                                    <asp:HiddenField ID="HiddenNAME" runat="server" />
                                    <asp:HiddenField ID="HiddenACCOUNT" runat="server" />
                                    <asp:HiddenField ID="HiddenFREQ" runat="server" />
                                    <asp:HiddenField ID="Hiddendays" runat="server" />
                                    <asp:HiddenField ID="HiddenNETSAL" runat="server" />
                                    <asp:HiddenField ID="HiddenBASICSAL" runat="server" />
                                    <asp:HiddenField ID="HiddenEXTRA_HR" runat="server" />
                                     <asp:HiddenField ID="HiddenEXTRAINC" runat="server" />
                                    <asp:HiddenField ID="HiddenDEDUCTN" runat="server" />
                                    <asp:HiddenField ID="HiddenCOMMENTS" runat="server" />
                                    <asp:HiddenField ID="HiddenEMPQID" runat="server" />
                                     <asp:HiddenField ID="HiddenFilePath" runat="server" />
                                     <asp:HiddenField ID="HiddenMonth" runat="server" />
                                    <asp:HiddenField ID="HiddenYear" runat="server" />
                              
                                    <script>
                                        var $noCon4 = jQuery.noConflict();
                                        $noCon4('#txtefctvedate').datepicker({
                                            autoclose: true,
                                            format: 'dd/mm/yyyy',

                                            timepicker: false
                                        });
                                        function GetDate() {

                                            IncrmntConfrmCounter();
                                            $noCon4('#cphMain_Hiddentxtefctvedate').val($noCon4('#txtefctvedate').val());

                                        }
                                        function SetDate() {
                                            IncrmntConfrmCounter();

                                            $noCon4('#txtefctvedate').val($noCon4('#cphMain_Hiddentxtefctvedate').val());

                                        }
                                    </script>
                                </label>
                            </section>


                        </div>
                    </div>
                </div>
            <%--    EVM-0027--%>
                <div style="width: 100%; float: left;" class="formdiv">

                     <div style="width: 50%; float: left;">

                        <section style="width: 95%; margin-left: 5%;">
                            <label class="lblh2" style="float: left; width: 27%;">Busines Unit*</label>

                            <div id="divDdlEmployee">

                                <label class="select">
                                    <asp:DropDownList runat="server" onchange="IncrmntConfrmCounter()" ID="ddlEmployee" Style="float: left; width: 60%;" onkeypress="return IsEnter(event);"></asp:DropDownList>

                                </label>
                            </div>

                        </section>


                    </div>
                <%--   END--%>
                    <div style="width: 50%; float: left;">

                        <section style="width: 95%; margin-left: 7%;">
                            <label class="lblh2" style="float: left; width: 27%;">Type*</label>
                            <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px; width: 39%; float: left; border: 1px solid #04619c; margin-bottom: 1px;">

                                <label class="radio">
                                    <input name="radioCustType" checked="true" runat="server" type="radio" id="radioCustType2" onchange="IncrmntConfrmCounter()" />
                                    <i></i>Staff</label>
                                <label class="radio">
                                    <input name="radioCustType" runat="server" type="radio" id="radioCustType1" onchange="IncrmntConfrmCounter()" />
                                    <i></i>Worker</label>

                            </div>
                            <asp:Button ID="btnsearch" runat="server" Style="background-color: #1c74a4; width: 75px; height: 27px; padding: 2px; float: left; margin-left: 7%" class="btn btn-info" Text="Search" OnClientClick="return validateSearch();" OnClick="btnsearch_Click"/>

                        </section>


                    </div>

                </div>

                   <%--    EVM-0027--%>
                <div style="width: 100%; float: left;" class="formdiv">

                      <div style="width: 50%; float: left;">

                        <section style="width: 95%; margin-left: 5%;">
                            <label class="lblh2" style="float: left; width: 27%;">Bank*</label>

                            <label class="select" style="float: left; width: 60%;">
                                <asp:DropDownList ID="ddlBank" runat="server" onkeypress="return IsEnter(event);"></asp:DropDownList>


                            </label>


                        </section>


                    </div>

                  <%--   END--%>
                    <div style="width: 50%; float: left;">

                        <section style="width: 95%; margin-left: 7%;">
                            <label class="lblh2" style="float: left; width: 27%;">Designation</label>

                            <label class="select" style="float: left; width: 60%;">
                                <asp:DropDownList ID="ddldesg" runat="server" onkeypress="return IsEnter(event);"></asp:DropDownList>


                            </label>


                        </section>


                    </div>

                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                <div style="width: 100%; float: left;" class="formdiv">
                    <div style="width: 50%; float: left;">

                        <section style="width: 95%; margin-left: 5%;">
                            <label class="lblh2" style="float: left; width: 27%;">Department</label>

                            <label class="select" style="float: left; width: 60%;">
                                <asp:DropDownList ID="ddlDep" runat="server" onkeypress="return IsEnter(event);" AutoPostBack="true" OnSelectedIndexChanged="ddlDep_selectedIndexChange"></asp:DropDownList>


                            </label>

                        </section>


                    </div>

                    <div style="width: 50%; float: left;">

                        <section style="width: 95%; margin-left: 7%;">
                            <label class="lblh2" style="float: left; width: 27%;">Division</label>
                            <label class="select" style="float: left; width: 60%;">
                                <asp:DropDownList ID="ddlDivision" runat="server" onkeypress="return IsEnter(event);"></asp:DropDownList>


                            </label>
                        </section>


                    </div>
                </div>
                        </ContentTemplate>
                </asp:UpdatePanel>
                <div style="width: 100%; float: left;" class="formdiv">
                    <div style="width: 50%; float: left;">

                        <section style="width: 95%; margin-left: 5%;">
                            <label class="lblh2" style="float: left; width: 27%;">Processed Date</label>

                            <label class="input" style="float: left; width: 60%;">
                                <%--<label class="input" style="float: left;width: 77%;margin-left: 0%;">--%>
                                <%--  <asp:TextBox ID="txtDateFrom" class="textDate"  placeholder="DD-MM-YYYY" MaxLength="20" runat="server"    Style="  font-family: calibri;width: 99%;margin-left: -1%;" ></asp:TextBox>--%>
                                <input id="txtDateFrom" name="txtDateFrom" type="text" onkeypress="return DisableEnter(event)" class="Tabletxt form-control datepicker" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" onchange="show()" />
                                <asp:HiddenField ID="HiddenBankName" runat="server" Value="0" />
                                <asp:HiddenField ID="hiddenDecimalCount" runat="server" Value="0" />
                                <asp:HiddenField ID="HiddenFieldEmpName" runat="server" Value="0" />
                                <asp:HiddenField ID="HiddenNetAmount" runat="server" Value="0" />
                                <asp:HiddenField ID="HiddenNoOfRecords" runat="server" Value="0" />
                                <asp:HiddenField ID="HiddenFieldComment" runat="server" Value="0" />
                                <asp:HiddenField ID="HiddenprocessedDate" runat="server" Value="0" />
                                <asp:HiddenField ID="HiddenPrsDate" runat="server" Value="0" />
                                <asp:HiddenField ID="HiddenType" runat="server" />
                                <asp:HiddenField ID="HiddenSettledID" runat="server" Value="0" />
                                <%--//0041--%>
                                <asp:HiddenField ID="Hiddenlevsettledate" runat="server" />
                                <asp:HiddenField ID="Hiddenespsettledate" runat="server" />
                                <asp:HiddenField ID="Hiddenmode" runat="server" />


                               <%-- end--%>
                                <script>
                                    var $noCon4 = jQuery.noConflict();
                                    $noCon4('#txtDateFrom').datepicker({
                                        autoclose: true,
                                        format: 'dd-mm-yyyy',

                                    });
                                    function show() {


                                        $noCon4('#cphMain_HiddenprocessedDate').val($noCon4('#txtDateFrom').val().trim());

                                    }
                                    function insert() {


                                        $noCon4('#txtDateFrom').val($noCon4('#cphMain_HiddenprocessedDate').val().trim());

                                    }
                                </script>
                            </label>



                            <%--  </label>--%>
                        </section>


                    </div>
                    
                    <div style="width: 50%; float: left;">

                        <section style="width: 95%; margin-left: 7%;">
                            <label class="lblh2" style="float: left; width: 27%;">Payer Bank*</label>
                            <label class="select" style="float: left; width: 60%;">
                                <asp:DropDownList ID="ddlPayerBank" runat="server" onkeypress="return IsEnter(event);"></asp:DropDownList>


                            </label>
                        </section>


                    </div>

                </div>

                 <div style="width: 100%; float: left;" class="formdiv">
                       <div style="width: 50%; float: left;">
                        <section style="width: 95%; margin-left: 5%;">
                            <label class="lblh2" style="float: left; width: 27%;">Sponsor</label>
                            <label class="select" style="float: left; width: 60%;">
                                <asp:DropDownList ID="ddlSponsor" runat="server" onkeypress="return IsEnter(event);"></asp:DropDownList>
                            </label>
                        </section>
                    </div>
                 <//div>


                <br style="clear: both" />
                <br />
                                                              <asp:Button ID="btnExportToCSV" runat="server" Text="Generate WPS List" OnClientClick="return GetId()" Style="background-color: rgb(28, 116, 164); margin-left: 978px; margin-bottom: 8px;height: 40px;width: 127px;" class="btn btn-info" OnClick="ExportToCSV_Click" />
        <div style="cursor: default; display: none; float: right; height: 25px; margin-right: 7.5%; margin-top: 4.5%; font-family: Calibri;" class="print" onclick="Clickme()">
            <a id="print_cap" tabindex="1" target="_blank" data-title="Item Listing" href="../../../HCM_Reports/Print/Report27_print.htm" style="color: rgb(83, 101, 51)">
                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%" />
                <span style="margin-top: 2px; float: right;">Preview</span></a>
        </div>
            </div>

             <div id="loading">
        <img src="/Images/Other%20Images/loading.gif" style="width: 12%; margin-left: 46%; margin-top: 4%;" />

    </div>

            <div id="divList" runat="server" class="widget-body no-padding">
  
            <%--    <table id="datatable_fixed_column" class="table table-striped table-bordered" width="100%" style="font-family: Calibri;">
                    <thead>
                        <tr>
                            <th class="hasinput"></th>
                             <th class="hasinput">
                                <input type="text" class="form-control" placeholder="EMPLOYEE ID" /></th>
                            <th class="hasinput">
                                <input type="text" class="form-control" placeholder="EMPLOYEE NAME" /></th>
                            <th class="hasinput">
                                <input type="text" class="form-control" placeholder="DESIGNATION" /></th>
                            <th class="hasinput">
                                <input type="text" class="form-control" placeholder="PAYGRADE" /></th>
                            <th class="hasinput">
                                <input style="text-align: right;" type="text" class="form-control" placeholder="TOTAL AMOUNT" /></th>
                      
                            <th class="hasinput">
                                <input style="text-align: left;" type="text" class="form-control" placeholder="COMMENTS" /></th>
                             <th class="hasinput">
                                <input style="text-align: left;display:none" type="text" class="form-control" placeholder="" /></th>

                        </tr>
                        <tr>
                            <th>
                                <label class="checkbox" style="margin-bottom: 13%;">
                                    <input type="checkbox" title="SELECT ALL" onkeypress='return DisableEnter(event)' onchange="return changeAll()" id="cbMandatory" /><i style="margin-left: 30%;"></i></label>
                            </th>
                            <th data-class="expand">EMPLOYEE ID</th>
                            <th data-class="expand">EMPLOYEE NAME</th>
                            <th data-class="expand">DESIGNATION</th>
                            <th data-class="expand">PAYGRADE</th>
                            <th data-class="expand">TOTAL AMOUNT</th>
                          
                            <th data-class="expand">COMMENTS</th>
                             <th data-class="expand" style="text-align: left;display:none"></th>

                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td colspan="7" class="dataTables_empty">Loading details...</td>
                        </tr>
                    </tbody>
                </table>--%>
            </div>

        </div>

        <div id="divSIFHeader" runat="server" style="display: none">
            <br />
        </div>
        <div id="divSIFbody" runat="server" style="display: none">
            <br />
        </div>
      
        <asp:Button ID="btn_Excel" runat="server" Text="Preview & Download" Style="margin-left: 924px; margin-top: 75px; background-color: #1c74a4;display: none" CssClass="btn btn-info" />
    </div>
    <script>
        function Clickme() {
            document.getElementById("<%=btnExportToCSV.ClientID%>").click();

        }
        function PrintClick() {

            window.open("WPS_List.aspx");

            
        }
        function isTag(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }
    </script>
    <style>
        table.dataTable tbody td {
            word-break:break-all;          
        }
        
         .table {
            font-size:13px;
        }
          
        #datatable_fixed_column_wrapper {
            border: 1px solid #b0adad;
             padding-top: 1%;
             padding: 2%;
        }
    </style>

    <script type="text/javascript">
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }

     
        function check() {

        
            var RowCount = document.getElementById("<%=HiddenRECORD.ClientID%>").value;
            IncrmntConfrmCounter();

            var no = 0;
            RemovePagn();

            for (var i = 0; i < RowCount; i++) {


                if (document.getElementById("cbMandatory" + i).checked == true) {

                    no++;
                }
                else {

                    if (document.getElementById("cbMandatory").checked == true) {
                        $("#cbMandatory").each(function () {

                            $(this).prop('checked', false);
                        });
                    }
                }

            }
            LoadEmpList();
            if (no == 0) {
                document.getElementById("<%= btnExportToCSV.ClientID%>").style.display = "none";


                  }
                  else {
                
                document.getElementById("<%= btnExportToCSV.ClientID%>").style.display = "";
               // document.getElementById("cphMain_btn_Excel").style.display = "none";

                  }
                  $('input.example').on('change', function () {
                      $('input.example').not(this).prop('checked', false);
                  });

                  return no;
        }


    
        function changeAll() {
            //  LoadCustomerRemovePagnation();
            IncrmntConfrmCounter();
            var RowCount = document.getElementById("<%=HiddenRECORD.ClientID%>").value;
            RemovePagn();
            if (document.getElementById("cbMandatory").checked == true) {


                for (var i = 0; i < RowCount; i++) {
                    if (document.getElementById("cbMandatory" + i).disabled == false) {
                        document.getElementById("cbMandatory" + i).checked = true;
                    }

                }



            }
            else {

                for (var i = 0; i < RowCount; i++) {
                    if (document.getElementById("cbMandatory" + i).disabled == false) {
                        document.getElementById("cbMandatory" + i).checked = false;
                    }

                }

            }
            LoadEmpList();

          check();

            return false;
        }
        var $NoConf1 = jQuery.noConflict();
              function GetId() {
                  var RowCount = document.getElementById("<%=HiddenRECORD.ClientID%>").value;

                  RemovePagn();
                  document.getElementById("cphMain_HiddenFieldComment").value = "";
                 // RowCount = RowCount - 2;
                  IncrmntConfrmCounter();

                  var no = 0;
                  document.getElementById("<%=HiddenFieldEmpName.ClientID%>").value = "";
                  document.getElementById("<%=Hiddenlevsettledate.ClientID%>").value = "";
                  document.getElementById("<%=Hiddenespsettledate.ClientID%>").value = "";
                  document.getElementById("<%=HiddenSettledID.ClientID%>").value = "";
                      document.getElementById("<%=HiddenFieldComment.ClientID%>").value = "";
                  for (var i = 0; i <= RowCount; i++) {


                      if (document.getElementById("cbMandatory" + i).checked == true) {

                          // document.getElementById("<%=HiddenFieldEmpName.ClientID%>").value = document.getElementById("allIds"+i).value;

                              var empId = document.getElementById("<%=HiddenFieldEmpName.ClientID%>").value;

                              if (empId == '') {
                                  document.getElementById("<%=HiddenFieldEmpName.ClientID%>").value = document.getElementById("allIds" + i).value;

                              }
                              else {

                                  document.getElementById("<%=HiddenFieldEmpName.ClientID%>").value = document.getElementById("<%=HiddenFieldEmpName.ClientID%>").value + ',' + document.getElementById("allIds" + i).value;
                              }
                              var idlist = document.getElementById("allIds" + i).value;
                              idlist = idlist.split(',');
                              //Settled Id
                              var StledId = document.getElementById("<%=HiddenSettledID.ClientID%>").value;

                          if (StledId == '') {
                                  document.getElementById("<%=HiddenSettledID.ClientID%>").value = document.getElementById("STl_id" + i).value;

                              }
                              else {

                                  document.getElementById("<%=HiddenSettledID.ClientID%>").value = document.getElementById("<%=HiddenSettledID.ClientID%>").value + ',' + document.getElementById("STl_id" + i).value;
                              }


                          //0041
                        

    
                         
     
                          if (document.getElementById("<%=Hiddenmode.ClientID%>").value == "2") {

                         

                              var levStledate = document.getElementById("<%=Hiddenlevsettledate.ClientID%>").value;

                              if (levStledate == '') {
                                  document.getElementById("<%=Hiddenlevsettledate.ClientID%>").value = document.getElementById("levstldate" + i).value;

                              }
                       
                          else {

                                  document.getElementById("<%=Hiddenlevsettledate.ClientID%>").value = document.getElementById("<%=Hiddenlevsettledate.ClientID%>").value + ',' + document.getElementById("levstldate" + i).value;
                          }


                          }



                          if (document.getElementById("<%=Hiddenmode.ClientID%>").value == "3") {



                              var espStledate = document.getElementById("<%=Hiddenespsettledate.ClientID%>").value;

                               if (espStledate == '') {
                                   document.getElementById("<%=Hiddenespsettledate.ClientID%>").value = document.getElementById("espstldate" + i).value;

                               }
                               else {

                                   document.getElementById("<%=Hiddenespsettledate.ClientID%>").value = document.getElementById("<%=Hiddenespsettledate.ClientID%>").value + ',' + document.getElementById("espstldate" + i).value;

                               }


                           }

                         
                      //end
                      

                              var myarray = [];
                             
                              var Paid = document.getElementById("<%=HiddenFieldComment.ClientID%>").value
                          if (Paid == "") {
                              document.getElementById("<%=HiddenFieldComment.ClientID%>").value = $NoConf1('#txtPaid' + idlist[no]).val();
                                  }
                                  else {
                              document.getElementById("<%=HiddenFieldComment.ClientID%>").value = document.getElementById("<%=HiddenFieldComment.ClientID%>").value + '~' + $NoConf1('#txtPaid' + idlist[no]).val();
                                  }
                              
                          }
                  }
                  LoadEmpList();

                      var a = check();
                      if (a == 0) {
                          return false;
                      }
               

             }

                  function blurcomments(field, maxlimit) {
                      var value = $NoConfi(field).val();
                      if (value.length > maxlimit) {

                          $NoConfi(field).val(value.substring(0, maxlimit));
                      }
                      RemoveTagforCommnts(field);
                  }
                  function RemoveTagforCommnts(obj) {
                      var value = $NoConfi(obj).val();
                      var txt = value.trim();
                      var replaceText1 = txt.replace(/</g, "");
                      var replaceText2 = replaceText1.replace(/>/g, "");
                      $NoConfi(obj).val(replaceText2);
                  }
                  function getdetails(href) {
                      window.location = href;
                      return false;
                  }
    </script>
    </div>
</asp:Content>

