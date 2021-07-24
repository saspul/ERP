<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/MasterPage/MasterPageNewHcm.master" CodeFile="hcm_Salary_Payment_Process.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_Process_hcm_Salary_Payment_Process" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
 


       <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>

    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />
    <%--<link href="/css/HCM/main.css" rel="stylesheet" />--%>
    <link href="../../../../css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="../../../../js/jQueryUI/jquery-ui.min.js"></script>
    <script src="../../../../js/jQueryUI/jquery-ui.js"></script>
    <script src="../../../../js/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../../js/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="/js/HCM/Common.js"></script>
    
 
  

  
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
              
              if (document.getElementById("<%=HiddenFinishOrPend.ClientID%>").value == "0") {
                  RemovePagn();
                  var RowCount = document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value;
                  for (i = 0; i < RowCount; i++) {
                      AmountChecking("cbMandatory" + i);
                  }
              }
              LoadEmpList();
              var SuccessMsg = '<%=Session["SALARPRSS_PAID"]%>';

              if (SuccessMsg == "PAID") {
                  SuccessProcess();
              }
              else if (SuccessMsg == "CONF") {
                  SuccessConfirm();
              }

          });


          </script>
   <script>
       function SuccessProcess() {
        
           $noCon("#success-alert").html("Monthly Salary payment process paid  successfully");
           $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
           });
           $noCon("#success-alert").alert();
           '<%Session["SALARPRSS_PAID"] = "' + null + '"; %>';
           $noCon(window).scrollTop(0);
        

        }
       //for search option
       var $NoConfi = jQuery.noConflict();
       var $NoConfi3 = jQuery.noConflict();


       function LoadEmpList() {


           var orgID = '<%= Session["ORGID"] %>';
           var corptID = '<%= Session["CORPOFFICEID"] %>';



           var responsiveHelper_datatable_fixed_column = undefined;


           var breakpointDefinition = {
               tablet: 1024,
               phone: 480
           };

           /* COLUMN FILTER  */
           var otable = $NoConfi3('#datatable_fixed_column').DataTable({
               //"bFilter": false,
               //"bInfo": false,
               //"bLengthChange": false
               //"bAutoWidth": false,
               //"bPaginate": false,
               //"bStateSave": true // saves sort state using localStorage
               "bDestroy": true,

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
               }

           });

           // custom toolbar
           //$NoConfi("div.toolbar").html('<div class="text-right"><select / style="Margin-top:10px;"></div>');

           // Apply the filter
           $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

               otable
                   .column($NoConfi(this).parent().index() + ':visible')
                   .search(this.value)
                   .draw();

           });




           /* END COLUMN FILTER */

       }

       function RemovePagn() {
           var responsiveHelper_datatable_fixed_column = undefined;


           var breakpointDefinition = {
               tablet: 1024,
               phone: 480
           };

           /* COLUMN FILTER  */
           var otable = $NoConfi3('#datatable_fixed_column').DataTable({
               //"bFilter": false,
               //"bInfo": false,
               //"bLengthChange": false
               //"bAutoWidth": false,
               "bPaginate": false,
               //"bStateSave": true // saves sort state using localStorage
               "bDestroy": true,

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
               }

           });

           // custom toolbar
           //$NoConfi("div.toolbar").html('<div class="text-right"><select / style="Margin-top:10px;"></div>');

           // Apply the filter
           $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

               otable
                   .column($NoConfi(this).parent().index() + ':visible')
                   .search(this.value)
                   .draw();

           });
       }

     


    </script>
       <script>
           function DisableEnter(evt) {

               evt = (evt) ? evt : window.event;
               var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
               if (keyCodes == 13) {
                   return false;
               }
           }
     function AmountChecking(textboxid) {
            
           var txtPerVal = document.getElementById(textboxid).value;

           txtPerVal = txtPerVal.replace(/,/g, "");



           if (txtPerVal == "") {
               return false;
           }
           else {
               if (!isNaN(txtPerVal) == false) {
                   document.getElementById('' + textboxid + '').value = "";
                   return false;
               }
               else {
                   if (txtPerVal < 0) {
                       document.getElementById('' + textboxid + '').value = "";
                       return false;
                   }
                   var amt = parseFloat(txtPerVal);
                   var num = amt;
                   var n = 0;
                   // for floatting number adjustment from corp global
                   var FloatingValue = 2;
                   //document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                  
                   

                   if (FloatingValue != "") {
                       if (document.getElementById("<%=HiddenFieldIndividualRound.ClientID%>").value == "1") {
                           var n = Math.round(num);
                           n = n.toFixed(FloatingValue);
                       }
                       else {
                           var n = num.toFixed(FloatingValue);
                       }
                    }
                    document.getElementById('' + textboxid + '').value = n;

                }
            }

         //   addCommas(textboxid);
        }
        function isNumberSalary(evt, textboxid) {
            //  alert('a');
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //  alert(textboxid);
            // alert(keyCode);
            // var txtPerVal = document.getElementById(textboxid).value;
            // alert(txtPerVal);
            //enter
            //if(keyCodes==86||keyCodes==17)
            //    return true;
           
            if (keyCodes == 13) {

                return false;

            }
                //0-9
            else if (keyCodes >= 48 && keyCodes <= 57) {
                return true;
            }
                //numpad 0-9
            else if (keyCodes >= 96 && keyCodes <= 105) {
                return true;
            }
                //left arrow key,right arrow key,home,end ,delete
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40 ||keyCodes==118||keyCodes==17) {
                return true;

            }
                // . period and numpad . period
            else if (keyCodes == 190 || keyCodes == 110) {
                var ret = true;
                if (textboxid == textboxid) {
                    var count = txtPerVal.split('.').length - 1;

                    if (count > 0) {

                        ret = false;
                    }
                    else {
                        ret = true;
                    }
                    return ret;
                }
                else {
                    //alert("55");
                    return false;
                }

            }

            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                    if(keyCodes==118||keyCodes==17)
                        ret=true;
                }
                if(keyCodes==86||keyCodes==17 || keyCodes==67)
                    ret=true;
             
              
                return ret;
            }
        }
        function ToPaidAll()
        {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to pay all the listed monthly salary?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

            RemovePagn();
            var ret = true;
            var RowCount = document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value;
            for (i = 0; i < RowCount; i++) {
                if (document.getElementById("cbMandatory" + i).value == "" || document.getElementById("cbMandatory" + i).value == null) {

                    ret = false;

                    document.getElementById("cbMandatory" + i).style.borderColor = "Red";

                   // document.getElementById("cbMandatory" + i).focus();

                 

                }
            }
            if (ret == true) {

             //   document.getElementById("<%=HiddenForPayment.ClientID%>").value = x + "-" + y + "-" + z;
                 document.getElementById("<%=btnRedirectAll.ClientID%>").click();
             }
            if (ret == false)
            {
             

                $noCon("#success-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#success-alert").alert();
             
           $noCon(window).scrollTop(0);
            }
            LoadEmpList();
                }
                else {
                    return false;

                }
            });
            
            return false;
        }
        function ToPaid(x,y,z,a,b)
        {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to pay the monthly salary?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    RemovePagn();
                    var ret = true;
          
                    if (document.getElementById("cbMandatory" + x).value == "" || document.getElementById("cbMandatory" + x).value == null)
                    {
               
                        ret = false;
           
                        document.getElementById("cbMandatory" + x).style.borderColor = "Red";
           
                        document.getElementById("cbMandatory" + x).focus();
            
                        SuccessMsg("SAVE", "Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
               
                    }
                    if (ret == true)
                    {
                
                        document.getElementById("<%=HiddenForPayment.ClientID%>").value = x + "-" + y + "-" + z+"-"+a+"-"+b;
                        document.getElementById("<%=btnRedirect.ClientID%>").click();
                    }
                }
                else {
                    return false;

                }
            });
            return false;
        }
         </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
  <%--  EVM-0027--%>
      <asp:HiddenField ID="hiddenAllEmpid" runat="server" />
<%--    END--%>
    <asp:Button ID="btnRedirectAll" runat="server" Text="Button" Style="display: none;" OnClick="btnRedirectAll_Click" />
    <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display: none;" OnClick="btnRedirect_Click" />
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="HiddenViewId" runat="server" />
    <asp:HiddenField ID="HiddenFieldRowCount" runat="server" />
    <asp:HiddenField ID="HiddenForPayment" runat="server" />
    <asp:HiddenField ID="HiddenFinishOrPend" runat="server" />
    <asp:HiddenField ID="HiddenEmployeeId" runat="server" />
    <asp:HiddenField ID="HiddenRowCount" runat="server" />
    <asp:HiddenField ID="hiddenSalaryPrcsdId" runat="server" />
    <asp:HiddenField ID="HiddenFieldIndividualRound" runat="server" Value="0"/>
    
    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>

    <div id="main" role="main">

        <div class="cont_rght">

            <div class="alert alert-success" id="success-alert" style="display: none">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
            <section id="widget-grid" class="">

                <div class="row">
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <div class="" id="wid-id-0">


                            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                                Monthly Salary Process List
                            </div>

                            <br />
                            <div style="float: left; width: 98%; background: white; margin-top: 2%; padding-left: 1%;">

                                <div style="float: left; width: 100%; padding: 10px; margin-top: 2%; border: 1px solid #929292; background-color: #c9c9c9; font-family: Calibri;">
                                     <div class="eachform" style="width: 47%; float: left;">
                                        <h2 style="color: #603504;">Month & Year</h2>
                                        <asp:Label ID="lblRefEmp" class="form1" runat="server" Style="word-wrap: break-word;"></asp:Label>
                                    </div>
                                    <div class="eachform" style="width: 47%; float: right;">
                                        <h2 style="color: #603504;">Date</h2>
                                        <asp:Label ID="lblCandtName" class="form1" runat="server" Style="word-wrap: break-word;"></asp:Label>
                                    </div>
                                    <div class="eachform" style="width: 47%; float: left;">
                                        <h2 style="color: #603504;">Business Unit</h2>
                                        <asp:Label ID="lblLoctn" class="form1" runat="server" Style="word-wrap: break-word;"></asp:Label>
                                    </div>
                                   
                                    <div class="eachform" style="width: 47%; float: right;">
                                        <h2 style="color: #603504;">Type</h2>
                                        <asp:Label ID="lblResume" class="form1" runat="server" Style="word-wrap: break-word;"></asp:Label>
                                    </div>
 
                                </div>

                             <%--   EVM-0027--%>
                                  <asp:Button ID="btnDownloadAllClick" runat="server"  Text="Download All Payslip" style="float: right;display:none;" OnClick="btnDownloadAll_Click" />
                              <%--  END--%>
                                <div onclick="location.href='hcm_Monthly_Salary_Process_List.aspx'" id="divList" class="list" runat="server" style="position: fixed; height: 26.5px; right: 0%; z-index: 1;">
                                </div>
                                <div class="smart-form" style="float: left; width: 100%;">




                                    <div class="jarviswidget-color-greenLight jarviswidget-sortable" id="wid-id-3" data-widget-editbutton="false" role="widget">

                                        <div id="divlistview" style="width: 100%; float: left; margin-top: 4%" runat="server">
                                        </div>
                                    </div>

                                </div>

                            </div>

                            <asp:Button ID="btnPrintPaySlip" runat="server" Style="display: none" Text="Print" OnClick="btnPrintPaySlip_Click" />
                            <asp:Button ID="btnPrint" runat="server" Style="display: none" Text="Print" OnClick="btnPrint_Click" />
                            <div id="Div1" style="cursor: default; float: right; height: 25px; margin-right: 7.5%; margin-top: 4.5%; font-family: Calibri; display: none" class="print" runat="server" onclick="Clickme()">
                                <a id="print_cap" tabindex="1" target="_blank" data-title="Item Listing" style="color: rgb(83, 101, 51)">
                                    <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%" />
                                    <span style="margin-top: 2px; float: right;">Preview</span></a>
                            </div>
                            <div id="divSIFHeader" runat="server" style="display: none">
                                <br />
                            </div>
                            <div id="divSIFbody" runat="server" style="display: none">
                                <br />
                            </div>

                            <div id="divSIFbody2" runat="server" style="display: none">
                                <br />
                            </div>
                            <script>
                                function Clickme(x, y, z) {

                                    document.getElementById("<%=HiddenEmployeeId.ClientID%>").value = x;
        document.getElementById("<%=HiddenRowCount.ClientID%>").value = y;
        document.getElementById("<%=hiddenSalaryPrcsdId.ClientID%>").value = z;

        document.getElementById("<%=btnPrint.ClientID%>").click();
        return false;

    }

    //evm-0023
    function PaySlip(UserId, count, Id) {

        document.getElementById("<%=HiddenEmployeeId.ClientID%>").value = UserId;
        document.getElementById("<%=HiddenRowCount.ClientID%>").value = count;
        document.getElementById("<%=hiddenSalaryPrcsdId.ClientID%>").value = Id;

        document.getElementById("<%=btnPrintPaySlip.ClientID%>").click();
        return false;
    }
//EVM-0027

       function DownloadAll() {
           document.getElementById("<%=btnDownloadAllClick.ClientID%>").click();
           return false;
       }
                                //END
    function PrintClick() {
        window.open("Employee_Salary_print.htm");
    }
    function PrintClick1() {

        // document.getElementById('footerBottom').style.display = 'none';
        window.open("Employee_PaySlip_print.htm");
    }
                            </script>


                            <%--    </div>--%>
                        </div>
                    </article>
                </div>
            </section>
        </div>
    </div>
    <style>
        table.dataTable tbody td {
            word-break: break-all;
        }

        .table {
            font-size: 13px;
        }

        #datatable_fixed_column_wrapper {
            border: 1px solid #b0adad;
            padding-top: 1%;
            padding: 2%;
        }

        #footerBottom {
            display: none;
        }
    </style>

</asp:Content>




