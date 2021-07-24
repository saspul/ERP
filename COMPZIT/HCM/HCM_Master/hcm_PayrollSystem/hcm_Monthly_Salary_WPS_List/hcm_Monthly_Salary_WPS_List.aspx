<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Monthly_Salary_WPS_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_WPS_List_hcm_Monthly_Salary_WPS_List" %>

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
    <link href="/css/HCM/main.css" rel="stylesheet" />
    <link href="../../../../css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="../../../../js/jQueryUI/jquery-ui.min.js"></script>
    <script src="../../../../js/jQueryUI/jquery-ui.js"></script>
    <script src="../../../../js/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../../js/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="/js/HCM/Common.js"></script>
 
  

  
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
             
              LoadEmpList();
              var SuccessMsg = '<%=Session["SALARPRSS_PAID"]%>';

              if (SuccessMsg == "PAID1") {
                  SuccessProcess();
              }
              ChangePayment();


          });


          </script>
   <script>


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
           var otable = $NoConfi('#datatable_fixed_column').DataTable({

               "bDestroy": true,
               "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6 hidden-xs'f><'col-sm-6 col-xs-12 hidden-xs'<'toolbar'>>r>" +
                       "t" +
                       "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
               "autoWidth": true,
               "oLanguage": {
                   "sSearch": '<span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span>'
               },
               "preDrawCallback": function () {
                   // Initialize the responsive datatables helper once.
                   if (!responsiveHelper_datatable_fixed_column) {
                       responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($NoConfi('#datatable_fixed_column'), breakpointDefinition);
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
           $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {
              
               otable
                   .column($NoConfi(this).parent().index() + ':visible')
                   .search(this.value)
                   .draw();

           });
           /* END COLUMN FILTER */

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
      function EditRow(x) {
          //alert(x);
          // var userName = x + "," + y + "," + z + "," + d;
          var data = document.getElementById("Para" + x).value;

          document.getElementById("<%=HiddenViewId.ClientID%>").value = data;
           document.getElementById("<%=btnRedirect.ClientID%>").click();

                 return false;
      }
    
          function Clickme(x) {
        
              document.getElementById("<%=HiddenRowId.ClientID%>").value = x;
            
        document.getElementById("<%=btnPrint.ClientID%>").click();
              return false;
     
    }
function PrintClick()
{
    window.open("WPS_List.aspx");
}

  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="HiddenRowId" runat="server" />
    <asp:HiddenField ID="HiddenViewId" runat="server" />
    <asp:HiddenField ID="HiddenCorpID" runat="server" />
        <asp:HiddenField ID="HiddenFieldIndividualRound" runat="server" value="0"/> 
    <asp:Button ID="btnRedirect" runat="server" Text="Button" style="display:none;" OnClick="btnRedirect_Click" />
     <%--<asp:Button ID="btnRedirect1" runat="server" Text="Button" style="display:none;" OnClick="btnRedirect1_Click" />--%>
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
            <img src="/Images/BigIcons/Genarate-WPS-List.png" style="vertical-align: middle;" />
         Monthly Salary WPS List
        </div >
      
        <br />
           <div style="float: left; width: 98%; background: white; margin-top: 2%; padding-left: 1%;">

        <div onclick="location.href='hcm_Monthly_WPS_List.aspx'"  id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;z-index: 1;">

       
        </div>
               <div class="smart-form" style="float: left; width: 100%;">
             <div style="width: 100%; float: left;" class="formdiv">
                                        <div style="width: 41%; float: left; """>

                                            <section style="width: 95%; margin-left: 5%;">
                                             <%--   <label class="lblh2" style="float: left;width: 27%;">Type*</label>--%>
                                              
                                                    <%--    <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px; width: 43%; float: left; border: 1px solid #04619c; margin-bottom: 1px;">

                                             <label class="radio" style="font-family: Calibri;">
                                                <input name="radioCustType" checked="true" onchange="ChangePayment();"  runat="server" onkeypress="return DisableEnter(event)" type="radio" id="radioCustType2"  />
                                                <i></i>Saved</label>
                                            <label class="radio" style="font-family: Calibri;">
                                                <input name="radioCustType" onchange="ChangePayment();"  runat="server" onkeypress="return DisableEnter(event)" type="radio" id="radioCustType1"  />
                                                <i></i>Confirmed</label>

                                        </div>--%>
                                            
                                            </section>


                                        </div>

         
                 
                                    </div>
                                   <div  class="jarviswidget-color-greenLight jarviswidget-sortable" id="wid-id-3" data-widget-editbutton="false" role="widget">

                   	<div  id="divlistview" style="width:100%;float:left;"  runat="server">
                                        </div>
                                       </div>
                   
  </div>
                
                       <asp:Button ID="btnPrint" runat="server" Style="display:none" Text="Print" OnClick="btnPrint_Click" /> 
              <div id="Div1" style="cursor: default; float: right; height: 25px; margin-right:7.5%;margin-top:4.5%;font-family:Calibri;display:none" class="print" runat="server" onclick="Clickme()">            
                                 <a id="print_cap" tabindex="1" target="_blank" data-title="Item Listing" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%"/>
                                  <span style="margin-top: 2px;float: right;"> Preview</span></a>                                     
                                </div> 
             <div id="divSIFHeader" runat="server" style="display: none">
                                    <br />
                                </div>
               <div id="divSIFbody" runat="server" style="display: none">
                                    <br />
                                </div>


                </div>
                            	
        

          
<%--    </div>--%>

  </div>  </article>  </div>  </section>  </div>  </div>
    <style>
        table.dataTable tbody td {
            word-break:break-all;          
        }
        
         .table {
            font-size:13px;
        }
          
        #datatable_fixed_column_wrapper {
            border: 1px solid #ddd;
        }
        .dataTables_filter .input-group-addon {
    height: 16px;
}
    </style>

</asp:Content>

