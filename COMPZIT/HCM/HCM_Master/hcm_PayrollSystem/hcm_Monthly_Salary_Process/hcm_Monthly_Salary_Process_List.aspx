<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage/MasterPageNewHcm.master" CodeFile="hcm_Monthly_Salary_Process_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_Process_hcm_Monthly_Salary_Process_List" %>

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
              //document.getElementById("<%=radioCustType2.ClientID%>").focus();
              LoadEmpList();
              var SuccessMsg = '<%=Session["MESSG"]%>';

              if (SuccessMsg == "PROCSS") {
                  SuccessProcess();
              }
              else if (SuccessMsg == "CONF") {
                  SuccessConfirm();
              }


              var SuccessMsg = '<%=Session["SALARPRSS_PAID"]%>';
          
              if (SuccessMsg == "PAID1") {
                  SuccessProcess();
              }
              ChangePayment();
              
            
          });

          function SuccessConfirm() {

              '<%Session["MESSG"] = "' + null + '"; %>';

                $noCon("#success-alert").html("Monthly Salary process confirmed  successfully");
                $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#success-alert").alert();

                return false;
            }
            function SuccessProcess() {

                '<%Session["MESSG"] = "' + null + '"; %>';

                $noCon("#success-alert").html("Monthly Salary process Processed  successfully");
                $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#success-alert").alert();

                return false;
            }

          </script>
   <script>

       //EVM-0027 02-02-2019

       function PrintSalaryDetails(x, mode) {
           document.getElementById("<%=HiddenSaveConf.ClientID%>").value = mode;
           var data = document.getElementById("Para" + x).value;

           document.getElementById("<%=HiddenViewId.ClientID%>").value = data;
           document.getElementById("<%=btnRedirect2.ClientID%>").click();
           return false;
       }
       //END

     
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
               "bDestroy": false,
              
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

       function EditRow(x)
       {
           //alert(x);
         // var userName = x + "," + y + "," + z + "," + d;
           var data = document.getElementById("Para"+ x ).value;
        
           document.getElementById("<%=HiddenViewId.ClientID%>").value = data;
           document.getElementById("<%=btnRedirect.ClientID%>").click();
         
           return false;
       }
       function EditRowFinish(x) {
           //alert(x);
           // var userName = x + "," + y + "," + z + "," + d;
           var data = document.getElementById("ValuePaid" + x).value;

           document.getElementById("<%=HiddenViewId.ClientID%>").value = data;
           document.getElementById("<%=btnRedirect1.ClientID%>").click();

                 return false;
             }
       function ChangePayment()
       {
           if (document.getElementById("<%=radioCustType1.ClientID%>").checked == true)
           {
              // document.getElementById("PendingFinissh").style.display = "block";
           }
           if (document.getElementById("<%=radioCustType2.ClientID%>").checked == true) {
              // document.getElementById("PendingFinissh").style.display = "none";
           }
       }

       function DisableEnter(evt) {

           evt = (evt) ? evt : window.event;
           var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
           if (keyCodes == 13) {
               return false;
           }
       }
    </script>
  <script>

      function SuccessProcess() {
          '<%Session["SALARPRSS_PAID"] = "' + null + '"; %>';
        //    SuccessMsg("SAVE", "Monthly Salary payment process paid  successfully");
            $noCon("#success-alert").html("Monthly Salary payment process paid  successfully");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();
           // $noCon1(window).scrollTop(0);
      }
      function EditRowFinishNot()
      {
          return false;
      }
  </script>

        <script>

            function DeleteMnthlyPrcssList(CorpdepId, staffWrk, ddate, pMonth, pYear) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to cancel this entry?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        var objOrg2 = {};
                        objOrg2.CorpdepId = CorpdepId;
                        objOrg2.staffWrk = staffWrk;
                        objOrg2.ddate = ddate;
                        objOrg2.pMonth = pMonth;
                        objOrg2.pYear = pYear;
                        $noCon.ajax({
                            async: false,
                            type: "POST",
                            url: "hcm_Monthly_Salary_Process_List.aspx/DeleteMonthlyProcesList",
                            data: JSON.stringify(objOrg2),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                window.location.href = "hcm_Monthly_Salary_Process_List.aspx?Deleted=true";
                                return false;
                            },
                            failure: function (response) {
                                alert("Fail")

                            }
                        });
                        return false;

                    }
                    else {
                        return false;
                    }
                });
                return false;
            }

            function SuccessDelete() {

                '<%Session["MESSG"] = "' + null + '"; %>';

                            $noCon("#success-alert").html("Monthly Salary process deleted successfully");
                            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                            });
                            $noCon("#success-alert").alert();

                            return false;
                        }
    </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="HiddenViewId" runat="server" />
    <asp:HiddenField ID="HiddenSaveConf" runat="server" />

    <asp:Button ID="btnRedirect" runat="server" Text="Button" style="display:none;" OnClick="btnRedirect_Click" />
     <asp:Button ID="btnRedirect1" runat="server" Text="Button" style="display:none;" OnClick="btnRedirect1_Click" />
           <asp:Button ID="btnRedirect2" runat="server" Text="Button" style="display:none;" OnClick="btnRedirect2_Click" />


   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

     <div id="main" role="main">
      
        <div id="content">

                  <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button> 
        </div>
            <section id="widget-grid" class="">

                <div class="row">
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <div class="" id="wid-id-0">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/Mothly-salary-process.PNG" style="vertical-align: middle;" />
         Monthly Salary Process List
        </div >
      
        <br />
           <div style="float: left; width: 98%; background: white; margin-top: 2%; padding-left: 1%;">

        <div onclick="location.href='hcm_Monthly_Salary_Process.aspx'"  id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;z-index: 1;">

       
        </div>
               <div class="smart-form" style="float: left; width: 100%;">
             <div style="width: 100%; float: left;" class="formdiv">
                                        <div style="width: 40%; float: left; """>

                                            <section style="width: 95%; margin-left: 5%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Type*</label>
                                              
                                                        <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px; width: 57%; float: left; border: 1px solid #04619c; margin-bottom: 1px;">

                                            <label class="radio" style="font-family: Calibri;">
                                                <input name="radioCustType" checked="true" onchange="ChangePayment();"  runat="server" onkeypress="return DisableEnter(event)" type="radio" id="radioCustType2"  />
                                                <i></i>Saved</label>
                                            <label class="radio" style="font-family: Calibri;">
                                                <input name="radioCustType" onchange="ChangePayment();"  runat="server" onkeypress="return DisableEnter(event)" type="radio" id="radioCustType1"  />
                                                <i></i>Confirmed</label>

                                        </div>
                                            
                                            </section>


                                        </div>

                                        <div id="PendingFinissh" style="width: 40%; float: left;">

                                            <section style="width: 95%; margin-left: 7%;">
                                              
                                                 <label class="lblh2" style="float: left;width: 27%;">Payment*</label>
                                              
                                                        <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px; width: 49%; float: left; border: 1px solid #04619c; margin-bottom: 1px;">

                                            <label class="radio" style="font-family: Calibri;">
                                                <input name="radioCustType"   runat="server" onkeypress="return DisableEnter(event)" type="radio" id="radioPaymnt"  />
                                                <i></i>Pending</label>
                                            <label class="radio" style="font-family: Calibri;">
                                                <input name="radioCustType"  runat="server" onkeypress="return DisableEnter(event)" type="radio" id="radioPaymntFin"  />
                                                <i></i>Finished</label>

                                        </div>
                                            </section>


                                        </div>
                 <asp:Button ID="btnSrch" runat="server" Style="  margin-left: 81%;height: 31px; margin-left: 5px;padding: 0 22px;font: 300 15px/29px 'Open Sans',Helvetica,Arial,sans-serif;cursor: pointer;" class="btn btn-primary" Text="Search" OnClick="btnSrch_Click" OnClientClick="return validateSearch();" />
                                    </div>
                                   <div  class="jarviswidget-color-greenLight jarviswidget-sortable" id="wid-id-3" data-widget-editbutton="false" role="widget">

                   	<div  id="divlistview" style="width:100%;float:left;margin-top:1%"  runat="server">
                                        </div>
                                       </div>
                   
  </div>
                
                </div>

  </div>  </article>  </div>  </section>  </div>  </div>
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

</asp:Content>




