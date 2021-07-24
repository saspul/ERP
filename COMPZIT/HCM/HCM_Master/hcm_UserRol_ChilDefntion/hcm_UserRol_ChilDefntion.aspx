<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage/MasterPageNewHcm.master" CodeFile="hcm_UserRol_ChilDefntion.aspx.cs" Inherits="HCM_HCM_Master_hcm_UserRol_ChilDefntion_hcm_UserRol_ChilDefntion" %>

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

           //   if (document.getElementById("<%=HiddenFinishOrPend.ClientID%>").value == "0") {
              //    RemovePagn();
                //  var RowCount = document.getElementById("<%=HiddenFieldRowCount.ClientID%>").value;
                //  for (i = 0; i < RowCount; i++) {
                  //    AmountChecking("cbMandatory" + i);
                //  }
            //  }
            //  LoadEmpList();
            var SuccessMsg = '<%=Session["MESSGASSGNROL"]%>';

              if (SuccessMsg == "ROLE") {
                  SuccessProcess();
              }
            

          });


          </script>
   <script>
       function SuccessProcess() {

           $noCon("#success-alert").html("User role assigned successfully");
           $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
           });
           $noCon("#success-alert").alert();
           '<%Session["MESSGASSGNROL"] = "' + null + '"; %>';
          $noCon(window).scrollTop(0);


       }
       //  if ($("#ddlUSers option[value=" + x + "]").length == 0) {


       //  var $Mo = jQuery.noConflict();
       //    var newOption = "<option value='" + X + "'>" + UsrName + "</option>";

       //   $('#<%=ddlUSers.ClientID%>').append(newOption);
       //SORTING DDL
       //      var options = $("#<%=ddlUSers.ClientID%> option");                    // Collect options         
       //      options.detach().sort(function (a, b) {               // Detach from select, then Sort
       //   var at = $(a).text();
       //   var bt = $(b).text();
       //    return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
       //  });
       //  options.appendTo('#<%=ddlUSers.ClientID%>');
       //   document.getElementById("<%=ddlUSers.ClientID%>").value = x;
       //  }
       //   else {
       //        document.getElementById("<%=ddlUSers.ClientID%>").value = x;
       //    }
       var confirmbox = 0;

       function IncrmntConfrmCounter() {

           confirmbox++;
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

       function changeSingle(x,y,ChildrolNum,UsrName) {
          
        
           var RowCount = document.getElementById("<%=HiddenRowCount.ClientID%>").value;
                     IncrmntConfrmCounter();
                     for (var i = 0; i < RowCount; i++) {
                         if (document.getElementById("cbMandatory" + i).checked == false) {

                             document.getElementById("cbMandatory").checked = false;
                            // return false;
                         }

                     }
                  
                    // var RowCount = document.getElementById("<%=HiddenChildRole.ClientID%>").value;
          
             
           var temp = 0, flag = 0;
           if (x != "") {
               if (document.getElementById("cbMandatory" + y).checked) {
                   for (i = 0; i < RowCount; i++) {
                       //  if (i != y) {
                       if (document.getElementById("cbMandatory" + i).checked) {
                           temp++;
                           if (document.getElementById("AssgnUserid" + i).value == x) {
                               if (ChildrolNum == document.getElementById("<%=HiddenChildRole.ClientID%>").value) {
                                   document.getElementById("<%=ddlUSers.ClientID%>").value = x;
                                  
                               }

                           }
                           else {
                               flag = 1;
                           }
                       }
                       //  }
                   }
               }
           }
          
           if (temp == 0 || flag==1)
           {
               document.getElementById("<%=ddlUSers.ClientID%>").value = "--SELECT EMPLOYEE--";
           }
      

       


           document.getElementById("<%=HiddenChbxUserid.ClientID%>").value = x;
                    // document.getElementById("<%=btnRedirectAll.ClientID%>").click();

                 }
       function changeAll() {
           // IncrmntConfrmCounter();
           var RowCount = document.getElementById("<%=HiddenRowCount.ClientID%>").value;
                

                   IncrmntConfrmCounter();
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
                 
                   return false;
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
    
     
    
           function validateProcess() {

               var ret = true;
               //if (CheckIsRepeat() == true) {
               //}
               //else {
               //    ret = false;
               //    return ret;
               //}
            
             

         var RowCount = document.getElementById("<%=HiddenRowCount.ClientID%>").value;
             
         var temp = "";
         var amount = "";
         var specialAmt = "";
         var AssgnUserid = "";
         var AssgnUserRole = "";
         var AssgnUserTempSts = "";

         for (i = 0; i < RowCount; i++) {
             // alert("dddddd");




             if (temp == "") {

                 if (document.getElementById("cbMandatory" + i).checked) {
                     temp = document.getElementById("cbMandatory" + i).value;
                     AssgnUserid = document.getElementById("AssgnUserid" + i).value;
                     AssgnUserRole = document.getElementById("AssgnUserRol" + i).value;
                     AssgnUserTempSts = document.getElementById("AssgnTempSts" + i).value;
                     
                 }
             }
             else {
                 if (document.getElementById("cbMandatory" + i).checked)
                     temp = temp + "," + document.getElementById("cbMandatory" + i).value;
                 AssgnUserid = AssgnUserid + "," + document.getElementById("AssgnUserid" + i).value;
                 AssgnUserRole =AssgnUserRole+"|"+ document.getElementById("AssgnUserRol" + i).value;
                 AssgnUserTempSts =AssgnUserTempSts+","+ document.getElementById("AssgnTempSts" + i).value;
             }


         }
         document.getElementById("<%=HiddenAssgnUSrRol.ClientID%>").value = AssgnUserRole;
               document.getElementById("<%=HiddenAssgnTempSts.ClientID%>").value = AssgnUserTempSts;
         
         document.getElementById("<%=HiddenAssgnUsrID.ClientID%>").value = AssgnUserid;
         document.getElementById("<%=HiddenEmployeeId.ClientID%>").value = temp;
               var ddlUSer = document.getElementById("<%=ddlUSers.ClientID%>").value;
             
               if (ddlUSer == "--SELECT EMPLOYEE--")
               {
                   ret = false;
               }
               if (temp == "") {
                   ret = false;
               }
               if (ret == false) {
             // SuccessMsg("SAVE", "Please select the employee to continue.");

             $noCon("#success-alert").html("Please select the employee to continue.");
             $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
             });
             $noCon("#success-alert").alert();
                     $noCon(window).scrollTop(0);
             // return false;
             ret = false;
         }

         //if (date == "") {
         //    document.getElementById("txtDateFrom").style.borderColor = "Red";
         //    document.getElementById("txtDateFrom").focus();
         //    //   SuccessMsg("SAVE", "Some of the information you entered is not correct or missing. Please check the highlighted fields below.");

         //    $noCon("#success-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
         //    $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
         //    });
         //    $noCon("#success-alert").alert();
         //    $noCon1(window).scrollTop(0);
         //    // return false;
         //    ret = false;
         //}
         //if (ret == false) {
         //    CheckSubmitZero();

         //}
             
         return ret;
     }

         </script>

         
                       
                                 <script language="javascript" type="text/javascript">

                                     $(document).ready(function () {



                                         $(":input[name= 'selector']").on('change', function () {
                                             if ($("input[name='selector']:checked").val() == '7') {

                                               
                                                 ezBSAlert({
                                                     type: "confirm",
                                                     messageText: "Are you sure you want to change the user role?",
                                                     alertType: "info"
                                                 }).done(function (e) {
                                                     if (e == true) {
                                                         document.getElementById("<%=HiddenChildRole.ClientID%>").value = "7";
                                                         document.getElementById("<%=ddlUSers.ClientID%>").value = "--SELECT EMPLOYEE--";
                                                         loadChildRoles();
                                                            }
                                                     else {
                                                         $('input[type=radio][value=' + document.getElementById("<%=HiddenChildRole.ClientID%>").value + ']').prop('checked', true);
                                                            }
                                                           });






                                               
                                               
                                             }
                                             else if ($("input[name='selector']:checked").val() == '22') {

                                                 // document.getElementById("divValidity").style.display = "";


                                                 ezBSAlert({
                                                     type: "confirm",
                                                     messageText: "Are you sure you want to change the user role?",
                                                     alertType: "info"
                                                 }).done(function (e) {
                                                     if (e == true) {
                                                         document.getElementById("<%=HiddenChildRole.ClientID%>").value = "22";
                                                         document.getElementById("<%=ddlUSers.ClientID%>").value = "--SELECT EMPLOYEE--";
                                                         loadChildRoles();
                                                     }
                                                     else {
                                                         $('input[type=radio][value=' + document.getElementById("<%=HiddenChildRole.ClientID%>").value + ']').prop('checked', true);
                                                     }
                                                 });
                                               
                                               
                                             }
                                             else if ($("input[name='selector']:checked").val() == '25') {
                                                 //  document.getElementById("divValidity").style.display = "";
                                                



                                                 ezBSAlert({
                                                     type: "confirm",
                                                     messageText: "Are you sure you want to change the user role?",
                                                     alertType: "info"
                                                 }).done(function (e) {
                                                     if (e == true) {
                                                         document.getElementById("<%=HiddenChildRole.ClientID%>").value = "25";
                                                         document.getElementById("<%=ddlUSers.ClientID%>").value = "--SELECT EMPLOYEE--";
                                                         loadChildRoles();
                                                     }
                                                     else {
                                                         $('input[type=radio][value=' + document.getElementById("<%=HiddenChildRole.ClientID%>").value + ']').prop('checked', true);
                                                     }
                                                 });
                                             
                                           }
                                   
                                      



                                         });
                                     })
                                     function loadChildRoles() {
                                         var corpid = '<%= Session["CORPOFFICEID"] %>';
                                         var orgid = '<%= Session["ORGID"] %>';
                                         var userid = '<%= Session["USERID"] %>';
                                         var ChildRl=document.getElementById("<%=HiddenChildRole.ClientID%>").value;
                                         $noCon.ajax({
                                             type: "POST",
                                             url: "hcm_UserRol_ChilDefntion.aspx/LoadChildRol",
                                             data: '{intChildRl:"' + ChildRl + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" }',
                                             contentType: "application/json; charset=utf-8",
                                             dataType: "json",
                                             success: function (response) {


                                                 document.getElementById("cphMain_divlistview").innerHTML = response.d[0];

                                                 document.getElementById("<%=HiddenRowCount.ClientID%>").value = response.d[1];






                                             },
                                             failure: function (response) {

                                             }


                                         });
                                     }
            </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
          
        <asp:Button ID="btnRedirect" runat="server" Text="Button" style="display:none;" />
     <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="HiddenViewId" runat="server" />
   
 <asp:HiddenField ID="HiddenForPayment" runat="server" />
     <asp:HiddenField ID="HiddenFinishOrPend" runat="server" />
    <asp:HiddenField ID="HiddenEmployeeId" runat="server" />

     <asp:HiddenField ID="HiddenRowCount" runat="server" />
        <asp:HiddenField ID="HiddenChildRole" runat="server" />
       <asp:HiddenField ID="HiddenFieldRowCount" runat="server" />
      <asp:HiddenField ID="HiddenChbxUserid" runat="server" />
       <asp:HiddenField ID="HiddenAssgnUsrID" runat="server" />
    
       <asp:HiddenField ID="HiddenAssgnUSrRol" runat="server" />
    
       <asp:HiddenField ID="HiddenAssgnTempSts" runat="server" />
   
   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

     <div id="main" role="main">
      
        <div class="cont_rght" >

                    <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button> 
        </div>
            <section id="widget-grid" class="">

                <div class="row">
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <div class="" id="wid-id-0">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            
     ssssssssssssssssssssssss
        </div >
      
        <br />
        
            
                                 <div style="float: left; width: 98%; background: white; margin-top: 2%; padding-left: 1%;">

              
   <div class="eachform" style="width: 30%; float: left;">
         <label class="lblh2" style="">User Role* </label>
       </div>
                <div class="eachform" style="width: 70%; float: left;">
                             <div id="DivCatDtls"  runat="server">
                                       
                                  
                                <style>
                                    .weekDays-selector input {
                                        display: none!important;
                                    }

                                        .weekDays-selector input[type=radio] + label {
                                            display: inline-block;
                                            border-radius: 6px;
                                            background: #dddddd;
                                            height: 40px;
                                            width: 14%;
                                            margin-right: 3px;
                                            line-height: 40px;
                                            text-align: center;
                                            cursor: pointer;
                                            font-family: Calibri;
                                        }

                                        .weekDays-selector input[type=radio]:checked + label {
                                            background-color: #115e99;
                                            border-color: #115e99;
                                            /*background: #2AD705;*/
                                            color: #ffffff;
                                        }
                                </style>
                                <asp:HiddenField runat="server" ID="HiddenField1" />
                                     
                                <div class="colmcenter" style="margin-top: 0%;">
                                   
                                    <div class="weekDays-selector">
                                          
                                 <input  value="7" checked  type="radio" onkeypress="return isTag(event);" id="RadApprv" name="selector"><label style="width:21%" for="RadApprv">APPROVE</label>
             
                   <input type="radio"  value="22"  id="RadHrAlloctn" onkeypress="return isTag(event);" name="selector"><label style="width:21%" for="RadHrAlloctn">HR ALLOCATION</label>
               <input type="radio"  id="RadGmAlloctn"   value="25"  onkeypress="return isTag(event);" name="selector"><label style="width:21%" for="RadGmAlloctn">GM ALLOCATION</label>
                                             
                                    </div>
                                  
                                </div>
                                <script>
                                   

                                </script>

                          

 

  </div>
                </div>
             
               
          
     
               <div class="smart-form" style="float: left; width: 60%;">



           
                                   <div  class="jarviswidget-color-greenLight jarviswidget-sortable" id="wid-id-3" data-widget-editbutton="false" role="widget">

                   	<div  id="divlistview" style="width:85%;float:left;margin-top:4%"  runat="server">
                               
                                        </div>
                                   
                                       </div>
                     
                   
  </div>
      <%--                                <asp:UpdatePanel ID="UpdatePanelTree" runat="server"  >
       <ContentTemplate>--%>
      <asp:Button ID="btnRedirectAll" runat="server" Text="Button" style="display:none;"  />
         
                                      <div style="width: 39%; float: left;margin-top: 3%;" class="smart-form">
                                          <div style="width: 100%; float: left;">

                                            <section style="width: 95%; margin-left: 2%;">
                                                  <label class="lblh2" style="float: left;width: 30%;">Employee</label>
                                               
                                              <label class="select" style="float: left;width: 70%;">
                                                      <asp:DropDownList ID="ddlUSers" onchange="IncrmntConfrmCounter();" style="width: 100%;margin-left: 0%;"  runat="server"  onkeypress="return DisableEnter(event)" ></asp:DropDownList>

                                                   
                                                </label>

                                             
                                            </section>


                                        </div>
                                          </div>
           <%--  </ContentTemplate>
               </asp:UpdatePanel>--%>

                                         <label  style="float: left;width: 11%;margin-top: 3%;margin-left: 29%;">
                                       <asp:Button ID="BtnPross" runat="server" Style="  margin-left: 81%;height: 31px; margin-left: 5px;padding: 0 22px;font: 300 15px/29px 'Open Sans',Helvetica,Arial,sans-serif;cursor: pointer;" class="btn btn-primary" Text="Asssign"  OnClick="butnprsstemp_Click"  OnClientClick="return validateProcess();" />
                                                      <asp:Button ID="butnprsstemp" runat="server"  Text="Button" Style="display:none" />     </label>
                
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
            border: 1px solid #b0adad;
             padding-top: 1%;
             padding: 2%;
        }
    </style>


</asp:Content>