<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Payment_Closing_Process_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Employee_Deduction_hcm_Employee_Deduction_List" %>

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
    <link href="../../../../css/HCM/CommonCss.css" rel="stylesheet" />

           <script src="/js/HCM/Common.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
             
              LoadCustomerList();
              var sessionValue = '<%= Session["Succes"] %>';
          
              if (sessionValue == "confirmed")
                  SuccesMessage();
              $noCon("input.form-control:first").focus();
          });
         
          function SuccesMessage() {
             
              SuccessMsg("SAVE", "Confirmed Successfully.");
            
           
              return false;
          }
          </script>
   <script>
     
       //for search option
       var $NoConfi = jQuery.noConflict();
       var $NoConfi3 = jQuery.noConflict();


       function LoadCustomerList() {
         
           document.getElementById("divPrint").style.display = "none";
           var orgID = '<%= Session["ORGID"] %>';
           var corptID = '<%= Session["CORPOFFICEID"] %>';
           var IndRnd = document.getElementById("<%=HiddenFieldIndividualRound.ClientID%>").value;

           var Year = $NoConfi('#cphMain_ddlYear').val();
           var Month = $NoConfi('#cphMain_ddlMonth').val();
           var Mode = $NoConfi('#cphMain_ddlMode').val();

           document.getElementById("<%=HiddenFieldMonth.ClientID%>").value = Month;
           document.getElementById("<%=HiddenFieldYear.ClientID%>").value = Year;
           

           if (Month < 10)
           {
               Month = '0' + Month;
           }

           var responsiveHelper_datatable_fixed_column = undefined;


           var breakpointDefinition = {
               tablet: 1024,
               phone: 480
           };

           /* COLUMN FILTER  */

           var otable = $NoConfi3('#datatable_fixed_column').DataTable({

               'bProcessing': true,
               'bServerSide': true,
               'sAjaxSource': 'dataVIewpaymentclose_List.ashx',

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
                   if (document.getElementById("cphMain_ddlMode").value == "1") {
                       document.getElementById("divPrint").style.display = "block";
                   }
               },
               "drawCallback": function (oSettings) {
                   responsiveHelper_datatable_fixed_column.respond();
               },
               "fnServerParams": function (aoData) {
                   aoData.push({ "name": "ORG_ID", "value": orgID });
                   aoData.push({ "name": "CORPT_ID", "value": corptID });
                   aoData.push({ "name": "MONTH", "value": Month });
                   aoData.push({ "name": "YEAR", "value": Year });
                   aoData.push({ "name": "IND_RND", "value": IndRnd });
                   aoData.push({ "name": "MODE", "value": Mode });
                   
               }
           });


           // Apply the filter

           $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

               otable
                   .column($NoConfi(this).parent().index() + ':visible')
                   .search(this.value)
                   .draw();

           });
          
       }



       function ViewRow(id) {
          

           document.getElementById("<%=HiddenViewId.ClientID%>").value = id;
           document.getElementById("<%=btnRedirect.ClientID%>").click();
           return false;

          // window.location = "/HCM/HCM_Master/hcm_PayrollSystem/hcm_Employee_Daily_Hour/hcm_Employee_Daily_Hour_View.aspx?id=" + id;
           return false;
       }
       function PrintSalaryDetails() {
           document.getElementById("<%=btnRedirect2.ClientID%>").click();
            return false;
        }
       function validateSearch() {
           var ret = true;

           //if (confirmbox > 0) {

               $NoConfi('#cphMain_ddlYear,#cphMain_ddlMonth').each(function () {

                   if ($NoConfi.trim($NoConfi(this).val()) == '--SELECT YEAR--' || $NoConfi.trim($NoConfi(this).val()) == '--SELECT MONTH--') {
                       isValid = false;
                       $NoConfi(this).css({
                           "border": "1px solid red",
                           "background": ""
                       });
                       ret = false;
                   }
                   else {
                       $NoConfi(this).css({
                           "border": "",
                           "background": ""
                       });
                   }
               });
               if (ret == true) {


                   LoadCustomerList();
                 
               }
               return false;
           //}
       }

       var confirmbox = 0;
       function IncrmntConfrmCounter() {

           confirmbox++;

       }

    </script>
  
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
         <asp:Button ID="btnRedirect" runat="server" Text="Button" style="display:none;" OnClick="btnRedirect_Click" />
    <asp:HiddenField ID="HiddenViewId" runat="server" />
     <asp:HiddenField ID="HiddenFieldIndividualRound" runat="server" value="0"/> 
     <asp:HiddenField ID="HiddenFieldMonth" runat="server" />
     <asp:HiddenField ID="HiddenFieldYear" runat="server" />
   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/payment closing process.png" style="vertical-align: middle;" />
           Payment Closing List
        </div >
      
        <br />

        <div onclick="location.href='hcm_Payment_Closing_Process_Master.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;z-index:1">

       
        </div>
         


         <div id="divList" runat="server" class="widget-body no-padding">        </div>


        <div style="width: 93.5%;">
<table id="datatable_fixed_column" class="table table-striped table-bordered"  style="font-family:Calibri;" >
                  <div class="widget-body smart-form" style="float: left; width: 100%;">
                       <div style="width: 40%; float: left;margin-top: 1%;">
                                <section style="width: 95%; margin-left: 50%;">
                                     <label class="lblh2" style="float: left;width: 15%;">Mode*</label>
                                    <div id="div1">
                                     <label class="select">
                                                <asp:DropDownList runat="server" ID="ddlMode" style="float: left;width: 42%;" onkeypress="return IsEnter(event);" >
                                                 <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                 <asp:ListItem Text="Salary process" Value="1"></asp:ListItem>
                                                 <asp:ListItem Text="Leave settlement" Value="2"></asp:ListItem>
                                                 <asp:ListItem Text="End of service settlement" Value="3"></asp:ListItem>

                                                </asp:DropDownList>
                                            </label>
                                        </div>
                                </section>
                         </div>
                       <div style="width: 60%; float: right;margin-top: 1%;">
                                <section style="width: 95%; margin-left: 7%;">
                                     <label class="lblh2" style="float: left;width: 20%;">Month & Year*</label>
                                    <div id="div2">
                                     <label class="select">
                                                <asp:DropDownList runat="server" ID="ddlYear" style="float: left;width: 25%;" onkeypress="return IsEnter(event);" onchange="IncrmntConfrmCounter()" >
                                                </asp:DropDownList>
                                                 <asp:DropDownList runat="server" ID="ddlMonth" onchange="IncrmntConfrmCounter()" style="float: left;width: 25%;" onkeypress="return IsEnter(event);" >
                                                </asp:DropDownList>
                                            </label>
                                        <asp:Button ID="btnsearch" runat="server" Style="background-color: #1c74a4; width: 75px; height: 27px; padding: 3px;float:left;margin-left: 6%;"  class="btn btn-info" Text="Search" OnClientClick="return validateSearch();" />
                                        <asp:Button ID="btnRedirect2" runat="server" Style="background-color: #1c74a4; width: 75px; height: 27px; padding: 3px;float:left;margin-left: 6%;display:none;"  class="btn btn-info" Text="Search" OnClick="btnRedirect2_Click" />
    <div id="divPrint" style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: -7.5%; font-family: Calibri;display:none;" class="print">
        <a id="print_cap" target="_blank" onclick="return PrintSalaryDetails();" data-title="Visa Bundle" href="#" style="color: rgb(83, 101, 51); margin-right: 15%">
            <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%; margin-right: 15%"/>
            <span style="margin-top: -28px; float: right;">Print</span></a>
    </div>
                                    
                                    </div>
                                </section>
                         </div>
                      
                      </div>
                
                
                
                 <thead>
                    <tr>
                         <th class="hasinput" style="width: 18%"><input type="text" class="form-control" placeholder="EMPLOYEE ID" onkeydown="return DisableEnter(event)" /></th>                        
                         <th class="hasinput" style="width: 18%"><input type="text" class="form-control" placeholder="EMPLOYEE NAME" onkeydown="return DisableEnter(event)" /></th>
                         <th class="hasinput" style="width:18%"><input type="text" class="form-control" placeholder="PROCESS" onkeydown="return DisableEnter(event)" /></th>
                         <th class="hasinput" style="width:10%;"><input style="text-align:center;" type="text" class="form-control" placeholder="CLOSED DATE" onkeydown="return DisableEnter(event)" /></th>                       
                         <th class="hasinput" style="width:15%"><input style="text-align:right;" type="text" class="form-control" placeholder="PAID AMOUNT" onkeydown="return DisableEnter(event)" /></th>     
                         <th class="hasinput" style="width:15%"><input style="text-align:right;" type="text" class="form-control" placeholder="TOTAL AMOUNT" onkeydown="return DisableEnter(event)" /></th>     
                   </tr>
<tr >
   
    <th data-class="expand">EMPLOYEE ID</th>
      <th data-class="expand">EMPLOYEE NAME</th>
    <th data-class="expand">PROCESS</th>   
    <th data-class="expand">CLOSED DATE</th> 
      <th data-class="expand">PAID AMOUNT</th> 
         <th data-class="expand">TOTAL AMOUNT</th> 
   
   
   
    
  
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
          
    <style>
        table.dataTable tbody td {
            word-break:break-all;          
        }
        
         .table {
            font-size:13px;
        }
          .glyphicon-search::before {
    content:url(/Images/HCM/Img/Icons/search.png);
    margin-left: -43%;
}
        #datatable_fixed_column_wrapper {
            border: 1px solid #c8b6b6;
        }
         td:nth-child(5),th:nth-child(5) {
   text-align: right;
}
              td:nth-child(6),th:nth-child(6),td:nth-child(4),th:nth-child(4) {
   text-align: right;
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
</asp:Content>

