<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Opening_Leave_Allocation.aspx.cs" Inherits="HCM_HCM_Master_hcm_LeaveMaster_hcm_Opening_Leave_Allocation_hcm_Opening_Leave_Allocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    
    <script src="/JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
   
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
              LoadEmployeeList();
              
          });

          //$noCon(window).ready(function () {
          //   LoadEmployeeList();
          //});

          //$noCon(document).ready(function () {
          //    // LoadEmployeeList();
             
          //}); 

          </script>
    
   

         <script>
             function SuccessConfirmation() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave details inserted successfully.";
                 ScrollTop();
             }
             function SuccessUpdation() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave details updated successfully.";
                 ScrollTop();
             }

             function MarkConfirm() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave details confirmed successfully.";
                 ScrollTop();
             }
             
             function ScrollTop() {
                 document.body.scrollTop = 0;
                 document.documentElement.scrollTop = 0;
             }

             function getdetails(href) {
                 window.location = href;
                 return false;
             }
             

           
             function CancelNotPossible() {
                 alert("Sorry, Cancellation Denied. This Entry is Already Selected Somewhere Or It is a Confirmed Entry!");
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

             //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
             function textCounter(field, maxlimit) {
                 if (field.value.length > maxlimit) {
                     field.value = field.value.substring(0, maxlimit);
                 } else {

                 }
             }
             // for not allowing enter
             function DisableEnter(evt) {
                 evt = (evt) ? evt : window.event;
                 var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                 if (keyCodes == 13) {
                     return false;
                 }
             }

             function isNum(evt) {
                
                 evt = (evt) ? evt : window.event;
                 var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                 var charCode = (evt.which) ? evt.which : evt.keyCode;
                 //at enter
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
                 else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40 || keyCodes == 190 || keyCodes == 110) {
                     return true;

                 }
                 else {
                     var ret = true;
                     if (charCode > 31 && (charCode < 48 || charCode > 57)) {                       

                         ret = false;
                     }
                     return ret;
                 }
             }
             function changeisNum(ts) {               
                 if (isNaN(ts.value)) {
                     ts.value = "";
                 }
                 else {                    
                     if (parseFloat(ts.value) >= 1000) {
                         ts.value = "";
                     }
                 }
                 return false;
             }
          </script>     
 
     


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
<br />
      <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
       <asp:HiddenField ID="hiddenSearchField" runat="server" />
     <asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />

       <asp:HiddenField ID="HiddenFieldCorpId" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
<asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
<asp:HiddenField ID="hiddenDecimalCount" runat="server" />
     <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

            <div id="divMessageArea" style="display: none">
                 <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div class="cont_rght" >

        


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <img src="/Images/BigIcons/Open_Leave_Alloc.png" style="vertical-align: middle;" /> Opening Leave Allocation
        </div>          
        <div style="width:98%;border: 1px solid #065757;margin-top: 1%;background:#f4f6f0;">        
            </div>        
        <br />    
    

       
          <div id="diEmployeeList" class="widget-body no-padding dataTables_wrapper" style="margin-top: 0.5%;width: 100%;margin-left:0.2%;">
            <table id="datatable_fixed_column" class="table table-striped table-bordered" width="100%" style="font-family: Calibri;">
                <thead>
                    <tr class="SearchRow" >
                         <th class="hasinput" style="width: 11.25%">
                            <input id="empid" type="text" class="form-control" placeholder="EMPLOYEE ID" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 11.25%">
                            <input  type="text" class="form-control" placeholder="EMPLOYEE" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 11.25%">
                            <input  type="text" class="form-control" placeholder="LEAVE TYPE" onkeydown="return DisableEnter(event)" /></th>
                        
                        <th class="hasinput" style="width: 11.25%">
                            <input  type="text" class="form-control" placeholder="OPENING LEAVE" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 11.25%">
                            <input  type="text" class="form-control" placeholder="BALANCE LEAVE" onkeydown="return DisableEnter(event)" /></th>
                       <%-- <th class="hasinput" style="width: 11.25%">
                            <input  type="text" class="form-control" placeholder="AMOUNT" onkeydown="return DisableEnter(event)" /></th>--%>
                       <%-- <th class="hasinput" style="width: 11.25%">
                            <input  type="text" class="form-control" placeholder="BALANCE AMOUNT" onkeydown="return DisableEnter(event)" /></th>--%>
                          <th class="hasinput" style="width: 11.25%">
                            <input  type="text" class="form-control" placeholder="YEAR" onkeydown="return DisableEnter(event)" /></th>
                        
                      
                        <th class="hasinput" style="width: 5%"></th>
                         <th class="hasinput" style="width: 5%"></th>
                    </tr>
                    <tr>
                        <th data-class="expand">Employee ID</th>
                        <th data-class="expand">Employee</th>
                        <th data-class="expand">Leave Type</th>

                        <th data-class="expand">Opening Leave</th>
                        <th data-class="expand">Balance Leave</th>
                       
                        <th data-class="expand">Year</th>                     
                                            
                        <th data-class="expand">Update</th>
                          <th data-class="expand">Confirm</th>

                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td colspan="10" class="dataTables_empty">Loading details...</td>
                    </tr>
                </tbody>
            </table>
        </div>      
           
                               
                   

    </div>

     <asp:HiddenField ID="HiddenFieldLmtdUser" runat="server" />
     <asp:HiddenField ID="HiddenFieldUserDesgId" runat="server" />

       
    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    

     <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />


    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script> 
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>  
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
 
      <script>
          //for search option
          var $NoConfi = jQuery.noConflict();
          var $NoConfi3 = jQuery.noConflict();

          function LoadEmployeeList() {
            
              var orgID = '<%= Session["ORGID"] %>';
              var corptID = document.getElementById("<%=HiddenFieldCorpId.ClientID%>").value;
              var DesgID = document.getElementById("<%=HiddenFieldUserDesgId.ClientID%>").value;
              var LmtdUser = document.getElementById("<%=HiddenFieldLmtdUser.ClientID%>").value;
              var Status = 1;
              var CnclSts = 0;            

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
                      "sSearch": '<span class="input-group-addon"><i  class="glyphicon glyphicon-search"></i></span>'

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
                      aoData.push({ "name": "STATUS", "value": Status });
                      aoData.push({ "name": "CNCL_STS", "value": CnclSts });
                      aoData.push({ "name": "DESG_ID", "value": DesgID });
                      aoData.push({ "name": "LMTD_USER", "value": LmtdUser });

                  },
                  aoColumnDefs: [
                    {
                        bSortable: false,
                        aTargets: [-1,-2,-3,-4,-5,-6,-7]
                    }
                     ]
              });


              // Apply the filter

              $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                  otable
                      .column($NoConfi(this).parent().index() + ':visible')
                      .search(this.value)
                      .draw();

              });
              /* END COLUMN FILTER */
              ScrollTop();
              
              document.getElementById("empid").focus();          
             
          }
          //27
          function yearValidation(year, EmpId, LeaveTiD) {
             
              var text = /^[0-9]+$/;
              var ret = "true";
              document.getElementById('divMessageArea').style.display = "none";
              document.getElementById('imgMessageArea').src = "";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
              if (year != 0)
              {
                  if ((year != "") && (!text.test(year)))
                  {
                      document.getElementById("Year_" + EmpId + LeaveTiD).style.borderColor = "red";
                      document.getElementById("Year_" + EmpId + LeaveTiD).focus();
                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please enter valid year";
                      ScrollTop();
                      //alert("Please Enter Numeric Values Only");
                      ret = "false";
                  }

                  if (year.length != 4) {
                      document.getElementById("Year_" + EmpId + LeaveTiD).style.borderColor = "red";
                      document.getElementById("Year_" + EmpId + LeaveTiD).focus();
                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please enter valid year";
                      ScrollTop();
                      //alert("Year is not proper. Please check");
                      ret = "false";
                  }
                  var current_year = new Date().getFullYear();
                  if ((year < 1920) || (year > current_year)) {
                      document.getElementById("Year_" + EmpId + LeaveTiD).style.borderColor = "red";
                      document.getElementById("Year_" + EmpId + LeaveTiD).focus();
                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please enter valid year";
                      ScrollTop();
                      //alert("Year should be in range 1920 to current year");
                      ret = "false";
                  }
              }
            
              if (ret == "false") {
                  return false;
              }
              else {

                  return true;
              }
             
          }
          function SaveLeaveDetails(EmpId, LeaveTiD,MSG) {
           
              //20-03-2019
              var OrgID = '<%= Session["ORGID"] %>';
              var CorpID = '<%= Session["CORPOFFICEID"] %>';
              var text = /^[0-9]+$/;
              //end
              var $noCon = jQuery.noConflict();
              var strEmpId = EmpId;
              var strLeaveTypId = LeaveTiD;
              var Msg = MSG;
              document.getElementById('divMessageArea').style.display = "none";
              document.getElementById('imgMessageArea').src = "";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
              var strOpngLeave = document.getElementById("opnglv_" + EmpId + LeaveTiD).value;
              var strBlncLeave = document.getElementById("blnclv_" + EmpId + LeaveTiD).value;
              //var strLeaveAmnt = document.getElementById("amnt_" + EmpId + LeaveTiD).value;
              //var strBlncLeaveAmnt = document.getElementById("blncamnt_" + EmpId + LeaveTiD).value;
              var strYear = document.getElementById("Year_" + EmpId + LeaveTiD).value;
        
              //yearValidation(strYear, EmpId, LeaveTiD)
              document.getElementById("opnglv_" + EmpId + LeaveTiD).style.borderColor = "";
              document.getElementById("blnclv_" + EmpId + LeaveTiD).style.borderColor = "";
              //document.getElementById("amnt_" + EmpId + LeaveTiD).style.borderColor = "";
              //document.getElementById("blncamnt_" + EmpId + LeaveTiD).style.borderColor = "";
              document.getElementById("Year_" + EmpId + LeaveTiD).style.borderColor = "";
              var ret = "";
              if(strYear == "" && strBlncLeave=="" && strOpngLeave=="")
              {
                  document.getElementById("opnglv_" + EmpId + LeaveTiD).style.borderColor = "red";
                  document.getElementById("blnclv_" + EmpId + LeaveTiD).style.borderColor = "red";
                  document.getElementById("Year_" + EmpId + LeaveTiD).style.borderColor = "red";
                  document.getElementById("opnglv_" + EmpId + LeaveTiD).focus();
                  ret = "false";
              }
                       
              if (strYear == "") {

                  document.getElementById("Year_" + EmpId + LeaveTiD).style.borderColor = "red";
                  document.getElementById("Year_" + EmpId + LeaveTiD).focus();
                  ret = "false";
              }
             

              if (strBlncLeave == "") {
                  document.getElementById("blnclv_" + EmpId + LeaveTiD).style.borderColor = "red";
                  document.getElementById("blnclv_" + EmpId + LeaveTiD).focus();
                  ret = "false";
              }
              if (strOpngLeave == "") {
                  document.getElementById("opnglv_" + EmpId + LeaveTiD).style.borderColor = "red";
                  document.getElementById("opnglv_" + EmpId + LeaveTiD).focus();
                  ret = "false";
              }
              if (!yearValidation(strYear, EmpId, LeaveTiD))
              {
                  return false;
              }
            
              if (ret == "false") {
                  return false;

              }
    
           
              if (Msg == "UPD") {
                  strEmpId = LeaveTiD;  //primary key
              }
              $noCon.ajax({
                  type: "POST",
                  url: "hcm_Opening_Leave_Allocation.aspx/Insert_Leave_Details",
                  data: '{strEmpId:"' + strEmpId + '",strOpngLeave:"' + strOpngLeave + '",strBlncLeave:"' + strBlncLeave + '",strLeaveTypId:"' + strLeaveTypId + '",strYear:"' + strYear + '",Msg:"' + Msg + '",strOrgID:"' + OrgID + '",strCorpID:"' + CorpID + '"}',
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (response) {
                      if (response.d == "TRUE") {
                          // alert("true");
                          if (MSG == "INS") {
                              SuccessConfirmation();
                          }
                          else {
                              SuccessUpdation();
                          }
                          LoadEmployeeList();
                      }
                      else {
                          alert("Oops!. Something error occured.");
                      }
                  },
                  failure: function (response) {

                  }
              });

              

          }

          function ConfirmLeaveDetails(Id) {
              var ret = true;
              var r = confirm("Are you sure to confirm?");
              if (r == true) {
                  
              } else {
                  ret = false;
              }
              if (ret == true) {
                  var strId = Id;
                  var strCnfrmUsrId = '<%= Session["USERID"] %>';
                  if (strId != "") {
                      $noCon.ajax({
                          type: "POST",
                          url: "hcm_Opening_Leave_Allocation.aspx/Confirm_Leave_Details",
                          data: '{strId:"' + strId + '",strCnfrmUsrId:"' + strCnfrmUsrId + '"}',
                          contentType: "application/json; charset=utf-8",
                          dataType: "json",
                          success: function (response) {
                              if (response.d == "TRUE") {
                                  MarkConfirm();
                                  LoadEmployeeList();
                                  
                              }
                              else {
                                  alert("Oops!. Something error occured.");
                              }

                          },
                          failure: function (response) {

                          }
                      });
                  }
              }
          }

          function AlrdyCnfrmd() {
              alert("Sorry.Leave details already confirmed");
              return false;
          }

         

         

         
    </script>
    
        <script src="/js/jQuery/jquery-2.2.3.min.js"></script>  
       <script src="/js/jQueryUI/jquery-ui.min.js"></script>
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


        input[type=text] {
  width: 100%;
 
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


    </style>
</asp:Content>

