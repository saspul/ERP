<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Payment_Closing_Process_Master.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Employee_Deduction_hcm_Employee_Deduction_Master" %>

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
<%--     <script src="/js/HCM/Common.js"></script>--%>
      <script type="text/javascript">
      
           var confirmbox = 0;
          function IncrmntConfrmCounter() {

              confirmbox++;   
         
          }
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
           
              $noCon(window).scrollTop(0);

              LoadCustomerList();
              ChangeMode("0");
              var sessionValue = '<%= Session["Succes"] %>';

              if (sessionValue == "confirmed")
                  SuccesMessage();

          });
         
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
              else if(Mode!=0)
                  $noCon('#processdatediv').show();
                  
              return false;
          }

          function validateSearch() {
              var flag = true;
              $NoConfi('#cphMain_ddlmode,#cphMain_ddlEmployee').each(function () {

                  if ($NoConfi.trim($NoConfi(this).val()) == '0' || $NoConfi.trim($NoConfi(this).val()) == '--SELECT BUSINESS UNIT--') {
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
   <script>

       //for search option
       var $NoConfi = jQuery.noConflict();
       var $NoConfi3 = jQuery.noConflict();


       function LoadCustomerList() {
          
           var orgID = '<%= Session["ORGID"] %>';
           var corptID = '<%= Session["CORPOFFICEID"] %>';
           var Mode = $NoConfi('#cphMain_ddlmode').val();
           var BusnsUnit = $NoConfi('#cphMain_ddlEmployee').val();
           var Month = $NoConfi('#cphMain_DropDownList2').val();
           var Year = $NoConfi('#cphMain_DropDownList3').val();
           var ProcessDate = $NoConfi('#txtefctvedate').val();
           var Type = 0;
           if ($NoConfi("#cphMain_radioCustType1").prop("checked")) {
           Type = 1;
           }
           var IndRnd = document.getElementById("<%=HiddenFieldIndividualRound.ClientID%>").value;

           var responsiveHelper_datatable_fixed_column = undefined;


           var breakpointDefinition = {
               tablet: 1024,
               phone: 480
           };

           /* COLUMN FILTER  */

           var otable = $NoConfi3('#datatable_fixed_column').DataTable({

               'bProcessing': true,
               'bServerSide': true,
               'sAjaxSource': 'dataVIewpaymentclose.ashx',
           
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
                   aoData.push({ "name": "MODE", "value": Mode });
                   aoData.push({ "name": "BSNS_UNIT", "value": BusnsUnit });
                   aoData.push({ "name": "MONTH", "value": Month });
                   aoData.push({ "name": "YEAR", "value": Year });
                   aoData.push({ "name": "PRCS_DATE", "value": ProcessDate });
                   aoData.push({ "name": "TYPE", "value": Type });
                   aoData.push({ "name": "IND_RND", "value": IndRnd });
                   
               }
           });


           // Apply the filter

           $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

               otable
                   .column($NoConfi(this).parent().index() + ':visible')
                   .search(this.value)
                   .draw();

           });



           return false;
       }



       function Close(id,Mode) {
           var userId = '<%= Session["USERID"] %>';
           var Paid="";
           if (Mode != "1") {
               Paid = $NoConfi('#txtPaid' + id).val();                  
           }
           ConfirmClose(userId, id, Mode, Paid);
           return false;
       }


       function CloseAll() {
           // var Ids = $NoConfi('#allIds1').val();

           var CountOfID = document.getElementsByClassName("all_Ids");
           if (CountOfID.length > 0) {
               // elements with class "all_Ids" exist

               var Ids = document.getElementsByClassName("all_Ids")[0].value;

               if (Ids == undefined)
                   return false;
               var userId = '<%= Session["USERID"] %>';
           var Mode = $noCon('#cphMain_ddlmode').val();
           ConfirmCloseAll(userId, Ids, Mode);

           }
         


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
                           $NoConfi("#success-alert").html("Payment process closed successfully");
                           $NoConfi("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                           });
                           $NoConfi("#success-alert").alert();
                           $NoConfi(window).scrollTop(0);
                           LoadCustomerList();
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
                       $NoConfi("#success-alert").html("Payment process closed successfully");
                       $NoConfi("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                       });
                       $NoConfi("#success-alert").alert();
                       $NoConfi(window).scrollTop(0);
                       LoadCustomerList();
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
               ConfirmMessage("hcm_Payment_Closing_Process_List.aspx");
           else
               window.location.href = "hcm_Payment_Closing_Process_List.aspx";
           return false;
       }
       function DateCheck() {
          
           var ret = true;
        
           var Rcptdate = document.getElementById("txtefctvedate").value;


           if (Rcptdate == "") {
              
           }
           else {
               var RCPTdata = Rcptdate.split("/");
             
               if (isNaN(parseInt(RCPTdata[0])) == true || isNaN(parseInt(RCPTdata[1])) == true || isNaN(parseInt(RCPTdata[2])) == true) {
                   ret = false;              
                }
                else {

                    if (isNaN(Date.parse(RCPTdata[2] + "/" + RCPTdata[1] + "/" + RCPTdata[0]))) {
                      
                        ret = false;
                       
                    }
                    else {
                      
                        var FormatDatearr = Rcptdate.split("/");
                        var txtDay = FormatDatearr[0];
                        var txtMonth = FormatDatearr[1];
                        var txtYear = FormatDatearr[2];

                        if (txtDay < 10) {
                            txtDay = "0" + parseInt(txtDay);
                        }
                        if (txtMonth < 10) {
                            txtMonth = "0" + parseInt(txtMonth);
                        }
                        if (txtYear.length != 4) {
                            ret = false;
                        }

                        document.getElementById("txtefctvedate").value = txtDay + '/' + txtMonth + '/' + txtYear;
                      
                        if (isNaN(Date.parse(txtYear + "/" + txtMonth + "/" + txtDay))) {

                            ret = false;
                           
                        }
                       
                      
                        
                    }

                }
            }
            if (ret == false) {
                $NoConfi("#txtefctvedate").datepicker().datepicker("setDate", new Date());            
            }
          
        }
    </script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
       <asp:HiddenField ID="hiddenTodate" runat="server" />
       <asp:HiddenField ID="HiddenFieldIndividualRound" runat="server" value="0"/> 
   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">


         <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button>  
        </div>

        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/payment closing process.png" style="vertical-align: middle;" />
           Payment Closing Process
        </div >
      
        <br />
       
        <div onclick="ConfirmCancel();" id="divlis" class="list" runat="server" style=" position: fixed; height:26.5px; right:1%;z-index:1;">

       
        </div>
                      <div class="smart-form" style="float: left;width: 93.5%;">
                                <div style="float: left; width: 98%; background: white; margin-top: 2%; margin-bottom: 2%; padding-left: 1%;background-color:#ddd;border:.5px solid;border-color: #9ba48b;">

                                    <div  style="width: 100%; float: left;" class="formdiv">
                                        <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 5%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Mode*</label>
                                                 <div id="div1">

                                            <label class="select">
                                                <asp:DropDownList runat="server" ID="ddlmode" style="float: left;width: 60%;" onkeypress="return IsEnter(event);" onchange="ChangeMode(1)"  >
                                                      <asp:ListItem Text="---SELECT MODE---" Value="0"></asp:ListItem>
                                                     <asp:ListItem Text="Salary process" Value="1"></asp:ListItem>
                                                       <asp:ListItem Text="Leave settlement" Value="2"></asp:ListItem>
                                                       <asp:ListItem Text="End of service settlement" Value="3"></asp:ListItem>
                                                </asp:DropDownList>

                                            </label>
                                        </div>
                                            </section>


                                        </div>
                                        <div id="dedctndiv" style="width: 50%; float: left;display:none">

                                            <section style="width: 95%; margin-left: 7%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Salary Month & Year</label>
                                                  <div id="div2">

                                            <label class="select">
                                                <asp:DropDownList runat="server" ID="DropDownList2" style="float: left;width: 30%;" onkeypress="return IsEnter(event);" onchange="IncrmntConfrmCounter()" >
                                                </asp:DropDownList>
                                                                   <asp:DropDownList runat="server" ID="DropDownList3" onchange="IncrmntConfrmCounter()" style="float: left;width: 30%;" onkeypress="return IsEnter(event);" >
                                                </asp:DropDownList>

                                            </label>
                                        </div>
                                            </section>


                                        </div>
                                          <div id="processdatediv" style="width: 50%; float: left;display:none">

                                            <div style="width: 100%; float: left;">

                                            <section style="width: 95%; margin-left: 7%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Settled Date</label>
                                                <label class="input" style="float: left;width: 60%;">
                                                <input id="txtefctvedate" name="txtefctvedate" type="text" class="Tabletxt form-control datepicker"  data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" onchange="GetDate()" style="width:73%;" />
                                                    <asp:HiddenField ID="Hiddentxtefctvedate" runat="server" value="0"/>
                                                                        <script>
                                                                            var $noCon4 = jQuery.noConflict();
                                                                            $noCon4('#txtefctvedate').datepicker({
                                                                                autoclose: true,
                                                                                format: 'dd/mm/yyyy',                                                          
                                                                                timepicker:false
                                                                            });
                                                                            function GetDate()
                                                                            {
                                                                                DateCheck();
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
                                  
              <div style="width: 100%; float: left;" class="formdiv">
                                        <div style="width: 50%; float: left; ">

                                            <section style="width: 95%; margin-left: 5%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Busines Unit*</label>
                                            
                                                         <div id="divDdlEmployee">

                                            <label class="select">
                                                <asp:DropDownList runat="server"  onchange="IncrmntConfrmCounter()" ID="ddlEmployee" style="float: left;width: 60%;" onkeypress="return IsEnter(event);" ></asp:DropDownList>

                                            </label>
                                        </div>
                                                
                                            </section>


                                        </div>

                                        <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 7%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Type*</label>
                                                <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px; width: 39%; float: left; border: 1px solid #04619c; margin-bottom: 1px;">

                                            <label class="radio" >
                                                <input name="radioCustType" checked="true"  runat="server" type="radio" id="radioCustType2" onchange="IncrmntConfrmCounter()" />
                                                <i></i>Staff</label>
                                            <label class="radio">
                                                <input name="radioCustType"  runat="server" type="radio" id="radioCustType1" onchange="IncrmntConfrmCounter()" />
                                                <i></i>Worker</label>

                                        </div>
                                                    <asp:Button ID="btnsearch" runat="server" Style="background-color: #1c74a4; width: 75px; height: 27px; padding: 2px;float:left;margin-left:7%"  class="btn btn-info" Text="Search" OnClientClick="return validateSearch();" />

                                            </section>


                                        </div>
                
                                    </div>   
                                         
                                       
   <br style="clear: both" />  <br />
            </div>
      
        <div id="divList" runat="server" class="widget-body no-padding">

            <table id="datatable_fixed_column" class="table table-striped table-bordered" width="100%" style="font-family:Calibri;" >
                <thead>
                    <tr>
                         <th class="hasinput" style="width: 20%"><input type="text" class="form-control" placeholder="EMPLOYEE ID" onkeydown="return DisableEnter(event)" /></th>                        
                          <th class="hasinput" style="width: 15%"><input type="text" class="form-control" placeholder="EMPLOYEE" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width:15%"><input type="text" class="form-control" placeholder="DESIGNATION" onkeydown="return DisableEnter(event)"/></th>
                          <th class="hasinput" style="width:20%;"><input style="text-align:right;" type="text" class="form-control" placeholder="TOTAL AMOUNT" onkeydown="return DisableEnter(event)" /></th>                       
                            <th class="hasinput" style="width:20%"><input style="text-align:right;" type="text" class="form-control" placeholder="PAID AMOUNT" onkeydown="return DisableEnter(event)" /></th>
                         <th class="hasinput" style="width: 15%"> <asp:Button ID="btnCloseAll" runat="server" Style="float: left;" class="btn btn-primary" Text="Close All"  OnClientClick="return CloseAll();" /></th>
                    </tr>
<tr >
   
    <th data-class="expand">EMPLOYEE ID</th>
      <th data-class="expand">EMPLOYEE</th>
    <th data-class="expand">DESIGNATION</th>   
    <th data-class="expand">TOTAL AMOUNT</th> 
      <th data-class="expand">PAID AMOUNT</th> 
    <th data-class="expand">CLOSE</th>
    
  
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
           td:nth-child(4),th:nth-child(4),td:nth-child(5),th:nth-child(5) {
   text-align: right;
}
              td:nth-child(6),th:nth-child(6) {
   text-align: center;
}
       .dt-toolbar {
    display: block;
    position: relative;
    padding: 6px 7px 1px;
    width: 98.8%;
    float: left;
    border-bottom: 1px solid #ccc;
    background: #fafafa;
}
       .dataTables_filter .input-group-addon {
    width: 32px;
    margin-top: 0;
    float: left;
    height: 16px;
    padding-top: 8px;
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

