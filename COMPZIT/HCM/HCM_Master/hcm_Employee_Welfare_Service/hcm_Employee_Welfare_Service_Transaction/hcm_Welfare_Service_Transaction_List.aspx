<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Welfare_Service_Transaction_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_Employee_Welfare_Service_hcm_Employee_Welfare_Service_Transaction_hcm_Welfare_Service_Transaction_List" %>

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
    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="/js/jQueryUI/jquery-ui.min.js"></script>
    <script src="/js/jQueryUI/jquery-ui.js"></script>
    <script src="/js/datepicker/bootstrap-datepicker.js"></script>
    <link href="/js/datepicker/datepicker3.css" rel="stylesheet" /> 
    <script src="/js/HCM/Common.js"></script>
    
      <style>
          .add {
    background: url(/Images/BigIcons/AddNew.png) no-repeat 0 0;
    width: 86px;
}
          .table > thead > tr > th {
    vertical-align: bottom;
    background:#eee;
   color: #5d7199;
   font-size:15px;
}
    
         .main_table > tbody > tr:nth-child(2n+1) > td, .main_table > tbody > tr:nth-child(2n+1) > th {
    height: 30px;
    background: #E9E9E9;
    font-size: 14px;
    color: #0d0d0e;
}
 .smart-form {
    margin: 0;
    outline: 0;
    color: #070708;
    position: relative;
}
 .ui-dialog .ui-dialog-title {
  text-align: center;
  width: 95%;
}
     </style>

       <script src="../../JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
              LoadEmployeeList();
              loadTableDesg();
              changeSts();
          });
          function loadTableDesg() {

              $noCon(function () {
                  $noCon('#dialog_simple').dialog({
                      autoOpen: false,
                      width: 600,
                      resizable: false,
                      modal: true,
                      title: "Employee Welfare Service Transaction",
                  });
              });
          }

          </script>
     <script type="text/javascript">
         var $Mo = jQuery.noConflict();

         function OpenCancelView(StrId) {

             ezBSAlert({
                 type: "confirm",
                 messageText: "Do you want to cancel this welfare service transaction?",
                 alertType: "info"
             }).done(function (e) {
                 if (e == true) {
                        var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                        document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                        var strCancelReason = "";
                        if (strCancelMust == 1) {
                          
                            document.getElementById("divErrMsgCnclRsn").style.display = "none";
                            document.getElementById("txtCancelReason").style.borderColor = "";
                            document.getElementById("txtCancelReason").value = "";
                            $noCon('#dialog_simple').dialog('open');

                        }
                        else {
                            DeleteByID(StrId, strCancelReason, strCancelMust);
                            $noCon('#dialog_simple').dialog('close');
                        }
                        return false;
                    }

                    else {
                        return false;
                    }
                });
                return false;

            }
            function CloseCancelView() {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to close  without completing cancellation process?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        $noCon('#dialog_simple').dialog('close');
                        document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = "";
                    }
                    else {
                        $noCon('#dialog_simple').dialog('open');
                        return false;
                    }
                });
                return false;
            }
         function DeleteByID(strId, strCancelReason, strCancelMust) {
             var strUserID = '<%=Session["USERID"]%>';
               if (strId != "" && strUserID != '') {
                 
                   var Details = PageMethods.CancelTransctn(strId, strCancelMust, strUserID, strCancelReason, function (response) {

                       var SucessDetails = response;
                       if (SucessDetails == "successcncl") {
                           window.location = 'hcm_Welfare_Service_Transaction_List.aspx?InsUpd=Cncl';
                       }
                       else if (SucessDetails == "confirm") {
                           window.location = 'hcm_Welfare_Service_Transaction_List.aspx?InsUpd=ConfPrev';
                       }
                       else if (SucessDetails == "dele") {
                           window.location = 'hcm_Welfare_Service_Transaction_List.aspx?InsUpd=ConfPrevDele';
                       }

                   });
               }

               return false;
           }
           //validation when cancel process
           function ValidateCancelReason() {
               // replacing < and > tags

               var ret = true;
               document.getElementById("divErrMsgCnclRsn").style.display = "none";
               document.getElementById("txtCancelReason").style.borderColor = "";
               var strCancelReason = document.getElementById("txtCancelReason").value;
               if (strCancelReason == "") {
                   document.getElementById("txtCancelReason").style.borderColor = "red";
                   document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
                   document.getElementById("divErrMsgCnclRsn").style.display = "";
                   return ret;
               }
               else {
                   strCancelReason = strCancelReason.replace(/(^\s*)|(\s*$)/gi, "");
                   strCancelReason = strCancelReason.replace(/[ ]{2,}/gi, " ");
                   strCancelReason = strCancelReason.replace(/\n /, "\n");
                   if (strCancelReason.length < "10") {
                       document.getElementById("lblErrMsgCancelReason").innerHTML = " Cancel reason should be minimum 10 characters";
                       document.getElementById("txtCancelReason").style.borderColor = "red";
                       document.getElementById("divErrMsgCnclRsn").style.display = "";
                       return ret;
                   }
                   else {

                   }
               }
               if (ret == true) {
                     var strId = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
                     var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                     DeleteByID(strId, strCancelReason, strCancelMust);
                     $noCon('#dialog_simple').dialog('close');
                 }
                 return false;
             }
         function changeSts() {
             var Sts = document.getElementById("cphMain_ddlStatus").value;
             if (Sts == 0) {
                 document.getElementById("divShowDele").style.visibility = "visible";
             }
             else {
                 document.getElementById("divShowDele").style.visibility = "hidden";
             }            
         }
    </script>
         <script>
             function getdetails(href) {
                 window.location = href;
                 return false;
             }
            
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
             // for not allowing enter
             function DisableEnter(evt) {
                 evt = (evt) ? evt : window.event;
                 var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                 if (keyCodes == 13) {
                     return false;
                 }
             }
          </script>

    <style>
        #cphMain_divReport {
            float: left;
            width: 93.5%;
        }

        #TableRprtRow .tdT {
            line-height: 100%;
        }


        .cont_rght {
            width: 98%;
        }
    </style>
     <script>     

    </script>
 
        

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
          
       <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
      <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
      <asp:HiddenField ID="HiddenEnableDelete" runat="server" />
      <asp:HiddenField ID="HiddenEnableModify" runat="server" />
     <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <div class="cont_rght" >

        <div class="alert alert-success" id="success-alert" style="display: none;margin-left: 0%;width: 98%;">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>

     <div class="alert alert-danger" id="divWarning" style="display:none;width: 98%;">
    <button type="button" class="close" data-dismiss="alert">x</button></div>


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <img src="/Images/BigIcons/welf_trans.png" style="vertical-align: middle;" /> Welfare Service Transaction
        </div>         
        <div class="SearchDiv" style="width:98%;border: 1px solid #79895f;margin-top: 1%;background:#f4f6f0;height: 70px;">

              <div class="" style="width: 22%;margin-top: 2%;margin-left:3%;float: left;margin-top: 1.5%;">

                <h2 style="margin-top:1%;">Status*</h2>

                <asp:DropDownList ID="ddlStatus" Height="30px"  Width="160px" class="form1" onchange="return changeSts();" onkeydown="return DisableEnter(event)" onkeypress="return DisableEnter(event)" runat="server" Style="margin-left: 15%;margin-bottom:2%;cursor: pointer;">
                    <asp:ListItem Text="Not Confirmed" Value="0" ></asp:ListItem>   
                    <asp:ListItem Text="Confirmed" Value="1" ></asp:ListItem>
                </asp:DropDownList>
            </div>

             <div class="" style="width: 18%;margin-left:2%;float: left;margin-top: 1.5%;">
                <h2 style="margin-top: 1%;">From</h2>
               <input id="txtFromdate" runat="server" type="text" style="width:65%;margin-left: 24%;" onkeydown="return DisableEnter(event)" onkeypress="return DisableEnter(event)" onchange="DateChk('cphMain_txtFromdate')" class="Tabletxt form-control datepicker" placeholder="dd-mm-yyyy" maxlength="10" />

            <script>
                $noCon('#cphMain_txtFromdate').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    timepicker: false
                });
       </script>
            </div>
           <div class="" style="width: 18%;margin-left:1%;float: left;margin-top: 1.5%;">
                <h2 style="margin-top: 1%;">To</h2>
               <input id="txtTodate" runat="server" type="text" style="width:65%;margin-left: 16%;" onkeydown="return DisableEnter(event)" onkeypress="return DisableEnter(event)" onchange="DateChk('cphMain_txtTodate')" class="Tabletxt form-control datepicker" placeholder="dd-mm-yyyy" maxlength="10" />

            <script>
                $noCon('#cphMain_txtTodate').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    timepicker: false
                });
       </script>
            </div>
      
            <div id="divShowDele" class="eachform" style="width:20%; margin-top: 1.8%;">               
                <div class="subform" style="width:215px;">
                    <span class="form2"><input id="cphMain_cbxCnclStatus" name="ctl00$cphMain$cbxCnclStatus" type="checkbox"></span>
                    <h3 style="margin-top:1%;">Show Deleted Entries</h3>
                  </div>
               </div>
          
                <div class="" style="width:13%;float: right;margin-top: 1.7%;">
                             <asp:Button ID="btnSearch"  style="cursor:pointer;width:70%;height:28px;padding:3px;" runat="server" class="btn btn-primary" Text="Search" OnClientClick="return LoadEmployeeList();"  /> 
                     </div>
            </div>     
        <br />

       <div onclick="location.href='hcm_Welfare_Service_Transaction.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px;right:0.7%;display:block">


        </div>
      <%--  <br />
        <br />--%>

    <div id="diEmployeeList" class="widget-body no-padding" style="margin-top: 0.5%;width: 98%;margin-left:0.2%;">
            <table id="datatable_fixed_column" class="table table-striped table-bordered" style="font-family: Calibri; width:100%">
                <thead>
                    <tr class="SearchRow" >
                        <th class="hasinput" style="width:25%">
                            <input  type="text" class="form-control" placeholder="DESIGNATION" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 25%">
                          <input  type="text" class="form-control" placeholder="DEPARTMENT" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 12%">
                             <input  type="text" class="form-control" placeholder="DATE" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 20%;">
                        <input  type="text" class="form-control" placeholder="TOTAL EMPLOYEES" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)" /></th>
                         <th class="hasinput" style="width: 13%;"></th>
                         <th class="hasinput" style="width: 5%;"></th>  
                         <th class="hasinput" style="width: 5%;"></th> 
                         <th class="hasinput" style="width: 5%;"></th>   
                    </tr>
                    <tr>
                        <th data-class="expand" style="color:#fff;">DESIGNATION</th>                   
                        <th data-class="expand" style="color:#fff;" >DEPARTMENT</th>
                        <th data-class="expand" style="text-align:center;color:#fff;" >DATE</th>
                        <th data-class="expand" style="text-align:center;color:#fff;" >TOTAL EMPLOYEES</th>
                        <th data-class="expand" style="text-align:center;color:#fff;" >STATUS</th>
                        <th data-class="expand" style="text-align:center;color:#fff;" >EDIT</th>
                        <th data-class="expand" style="text-align:center;color:#fff;" >DELETE</th>
                         <th data-class="expand" style="text-align:center;color:#fff;">VIEW</th>
                       
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td colspan="8" class="dataTables_empty">Loading details...</td>
                    </tr>
                </tbody>
            </table>
        </div>





        <div id="divReport" class="table-responsive" runat="server" style="display:none;">
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



          <div id="dialog_simple" title="Dialog Simple Title" style="display:none">
            <!-- widget content -->

            <div class="widget-body no-padding" id="divCancelPopUp">


                  <div class="alert alert-danger fade in" id="divErrMsgCnclRsn" style="display: none; margin-top: 1%">

                    <i class="fa-fw fa fa-times"></i>
                    <strong>Error!</strong>&nbsp;<label id="lblErrMsgCancelReason"> Please fill this out</label>
                </div>

                <div style="width: 100%; float: left; clear: both; margin-top: 5%">

                    <section style="width: 95%; margin-left: 5%;">
                        <label class="lblh2" style="float: left; width: 35%;">Cancel Reason*</label>

                        <label class="input" style="float: left; width: 60%;">
                            <textarea name="txtCancelReason" rows="2" cols="20" id="txtCancelReason" class="form-control" onblur="RemoveTag(txtCancelReason)" onkeypress="return isTag(event)" onkeydown="textCounter(txtCancelReason,450)" onkeyup="textCounter(txtCancelReason,450)" style="text-transform: uppercase; resize: none;"></textarea>
                        </label>

                    </section>


                </div>
                <div class="ui-dialog-buttonpane ui-widget-content ui-helper-clearfix" style="border-top: none;">
                    <div class="ui-dialog-buttonset">
                        <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-danger"><i class="fa fa-trash-o"></i>&nbsp; SAVE</button>
                        <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();"class="btn btn-default"><i class="fa fa-times"></i>&nbsp; Cancel</button>
                    </div>
                   
                </div>
            </div>
                </div>  





    </div>
   
    <script>
        //for search option
        var $NoConfi = jQuery.noConflict();
        var $NoConfi3 = jQuery.noConflict();
        function LoadEmployeeList() {
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var EnableEdit = document.getElementById("<%=HiddenEnableModify.ClientID%>").value;
            var EnableCncl = document.getElementById("<%=HiddenEnableDelete.ClientID%>").value;

           
            var dtFromDate = document.getElementById("cphMain_txtFromdate").value;
            var dtToDate = document.getElementById("cphMain_txtTodate").value;


            document.getElementById("cphMain_txtTodate").style.borderColor = "";
            if (dtFromDate != "" && dtToDate != "") {


                var RcptdatepickerDate = dtFromDate;
                var RarrDatePickerDate = RcptdatepickerDate.split("-");
                var RdateDateCntrlr = new Date(RarrDatePickerDate[2], RarrDatePickerDate[1] - 1, RarrDatePickerDate[0]);


                var CurrentDateDate = dtToDate;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                if (RdateDateCntrlr > dateCurrentDate) {
                    document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                    $("#divWarning").html("Sorry, From date cannot be greater than To date !.");
                    $("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    return false;
                }

            }

            var CancelSts = 0;
            if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {             
                CancelSts = 1;
            }
          
            var Sts = document.getElementById("cphMain_ddlStatus").value;           
            if (Sts == 1 || CancelSts == 1) {
                if (Sts == 1) {
                    CancelSts = 0;
                }              
            }

           
              var responsiveHelper_datatable_fixed_column = undefined;
              var breakpointDefinition = {
                  tablet: 1024,
                  phone: 480
              };

              var s = [];

              if (CancelSts == 1 || Sts == 1) {
                  s = [
                                  {
                                      "targets": [5],
                                      "visible": false
                                  },
                                   {
                                       "targets": [6],
                                       "visible": false
                                   },
                                  {
                                      "targets": [7],
                                      "visible": true
                                  }];
              }
              else {
                  if (EnableEdit == 0 && EnableCncl == 0) {
                      s = [
                                  {
                                      "targets": [5],
                                      "visible": false
                                  },
                                   {
                                       "targets": [6],
                                       "visible": false
                                   },
                                  {
                                      "targets": [7],
                                      "visible": false
                                  }];
                  }
                  else if (EnableEdit == 0 && EnableCncl == 1) {
                      s = [
                                   {
                                       "targets": [5],
                                       "visible": false
                                   },
                                   {
                                       "targets": [6],
                                       "visible": true
                                   },
                                  {
                                      "targets": [7],
                                      "visible": false
                                  }];
                  }
                  else if (EnableEdit == 1 && EnableCncl == 0) {
                      s = [
                                  {
                                      "targets": [5],
                                      "visible": true
                                  },
                                   {
                                       "targets": [6],
                                       "visible": false
                                   },
                                  {
                                      "targets": [7],
                                      "visible": false
                                  }];
                  }
                  else if (EnableEdit == 1 && EnableCncl == 1) {
                      s = [
                                  {
                                      "targets": [5],
                                      "visible": true
                                  },
                                   {
                                       "targets": [6],
                                       "visible": true
                                   },
                                  {
                                      "targets": [7],
                                      "visible": false
                                  }];
                  }
                
              }
            

                  /* COLUMN FILTER  */
                  var otable = $NoConfi3('#datatable_fixed_column').DataTable({

                      'bProcessing': false,
                      'bServerSide': true,
                      'sAjaxSource': 'data.ashx',
                      "order": [[0, 'asc']],

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
                          aoData.push({ "name": "EDIT_ROLE", "value": EnableEdit });
                          aoData.push({ "name": "STS", "value": Sts });
                          aoData.push({ "name": "FROMDATE", "value": dtFromDate });
                          aoData.push({ "name": "TODATE", "value": dtToDate });
                          aoData.push({ "name": "CNCL_STS", "value": CancelSts });

                      },
                    
                  
                      "columnDefs": s,
                  });


                  // Apply the filter

                  $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                      otable
                          .column($NoConfi(this).parent().index() + ':visible')
                          .search(this.value)
                          .draw();

                  });
                  /* END COLUMN FILTER */
                
             return false;
          }

    </script>
    <style>
        .table td + td+td,
.table th + th+th
{
    text-align:center;
}
          #datatable_fixed_column_wrapper {
            border: 1px solid #79895f;
        }
        .dt-toolbar  {
    border-bottom: 1px solid  #c8b6b6;
    background: #f4f6f0;
}
.dt-toolbar-footer  {
    border-top: 1px solid  #c8b6b6;
    background: #f4f6f0;
}
.table-bordered, .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
    border-bottom: 1px solid #c8b6b6;
    border-right: 1px solid  #c8b6b6;
}
#datatable_fixed_column {
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
       .SearchDiv  h2 {
    font-family: Calibri;
    font-size: 17px;
    float: left;
    text-align: left;
    color: #909c7b;
    padding: 0;
    margin: 0 0 6px;
    margin-top: 0px;
    line-height: 1;
    font-weight: normal;
    float: left;
}

        .datepicker-days > table > thead > tr > th {
    vertical-align: bottom;
    background: #eee;
    color: #5d7199;
    font-size: 12px;
}

        </style>
    <script>
        function SuccessConfirmation() {
            $("#success-alert").html("Welfare service transaction details inserted successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function SuccessUpdation() {
            $("#success-alert").html("Welfare service transaction details updated successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpdationConfirm() {
            $("#success-alert").html("Welfare service transaction details confirmed successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessCancelation() {
            $("#success-alert").html("Welfare service transaction cancelled successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
       
        function SuccessConfirmationPre() {
            $("#divWarning").html("Welfare service transaction details already confirmed.");
            $("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessConfirmationPreDele() {
            $("#divWarning").html("Welfare service transaction details already cancelled.");
            $("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        
        function editNotPossible() {
                ezBSAlert({
                    type: "alert",
                    messageText: "Sorry, edit not possible !",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                }
                else {
                    return false;
                }
            });
            return false;
        }
    </script>

</asp:Content>

