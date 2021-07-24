<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Emp_Conduct_Incident.aspx.cs" Inherits="HCM_HCM_Master_hcm_Emp_Conduct_Incident_hcm_Emp_Conduct_Incident" %>

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

    <script>


        //$(document).ready(function () {

        //    $('#check-show').change(function () {
        //        if ($(this).is(":checked")) {
        //            $('#show-div').slideDown();
        //        }
        //        else {
        //            $('#show-div').slideUp(300);
        //        }

        //    });
        //});

        function FunctMemoChkBx()
        {
            IncrmntConfrmCounter();
            if (document.getElementById("<%=checkMemo.ClientID%>").checked == true) {
                $('#show-div').slideDown();
            }
            else {
                $('#show-div').slideUp(300);
            }
        }
        
        var $noCon1 = jQuery.noConflict();
        $noCon1(window).load(function () {
            var SuccessMsg = '<%=Session["MESSG_CONDINCDNT"]%>';

            if (SuccessMsg == "INS") {
                SuccessConductInsident();
            }
            else if (SuccessMsg == "CONF") {
                SuccessConfirm();
            }
            else if (SuccessMsg == "UPD") {
                SuccessUpdate();
            }
            else if (SuccessMsg == "TERMNTN_UNDER_PRSS") {
                ValidateNotTerminate();
            }
            else if (SuccessMsg == "TERMINATED") {
                ValidateTerminated();
            }
            else if (SuccessMsg == "CLOSED") {
                ValidateNotClose();
            }

            
            if (document.getElementById("<%=Hiddentxtefctvedate.ClientID%>").value!="") {
                insert()
            }
            if (document.getElementById("<%=checkMemo.ClientID%>").checked == true) {
                $('#show-div').slideDown();
            }
            else {
                $('#show-div').slideUp(300);
            }
       
        });


        var $noCon = jQuery.noConflict();

        function SuccessConductInsident() {

            '<%Session["MESSG_CONDINCDNT"] = "' + null + '"; %>';

               $noCon("#success-alert").html("Employee conduct incident inserted successfully");
               $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
               });
               $noCon("#success-alert").alert();

               return false;
        }
        function SuccessUpdate() {

            '<%Session["MESSG_CONDINCDNT"] = "' + null + '"; %>';

                  $noCon("#success-alert").html("Employee conduct incident updated successfully");
                  $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                  });
                  $noCon("#success-alert").alert();

                  return false;
              }
        
        function ValidateTerminate() {



            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to terminate the employee?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=Bttnterminate.ClientID%>").click();
                    //  window.location.href = "hcm_Emp_Conduct_Incident_List.aspx";
                }

                else {
                    // window.location.href = "hcm_Emp_Conduct_Incident_List.aspx";
                    return false;
                }
            });
            return false;

        }
        function CancelEntry(IncidentSubID) {
            if (IncidentSubID != "") {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to delete this message?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        
                     var varId=   document.getElementById("<%=HiddenConductId.ClientID%>").value;
                        var Details = PageMethods.CancelMessage(IncidentSubID,varId, function (response) {
                            var SucessDetails = response;

                            document.getElementById('cphMain_DivMssgBox').innerHTML = response[0];
                            SuccessCancelMsg();
                            //if (SucessDetails == "Cancel") {
                            //    window.location = 'hcm_Emp_Conduct_Incident.aspx?InsUpd=CancelMsg';
                            //}
                            //else {
                            //    window.location = 'hcm_Emp_Conduct_Incident.aspx?InsUpd=Error';
                            //}
                        });
                    }
                });
                return false;
            }
        }
        function ValidateNotTerminate() {
            ezBSAlert({
                type: "alert",
                messageText: "This action is denied! Incident employee termination is under processing.",
                alertType: "info"

            });
            return false;
        }

        function ValidateTerminated() {
            ezBSAlert({
                type: "alert",
                messageText: "This action is  denied! Incident employee is already terminated.",
                alertType: "info"

            });
            return false;
        }
        function ValidateNotClose() {
            ezBSAlert({
                type: "alert",
                messageText: "This action is  denied! Incident employee is already closed .",
                alertType: "info"

            });
            return false;
        }
        function CloseValidate() {

          

            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to close this incident?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=BttnClose.ClientID%>").click();
                  //  window.location.href = "hcm_Emp_Conduct_Incident_List.aspx";
                }

                else {
                    // window.location.href = "hcm_Emp_Conduct_Incident_List.aspx";
                    return false;
                }
            });
            return false;

        }
        function ConfirmAlert() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to confirm this incident?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=BtnConfirm.ClientID%>").click();


                } else {
                    return false;
                }
            });
            return false;
        }
        function ConfirmMessage() {

            //  SuccessMsg("SAVE", "Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
            //$noCon("#success-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
            //$noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            //});
            //$noCon("#success-alert").alert();
           
            if (confirmbox > 1  ) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "hcm_Emp_Conduct_Incident_List.aspx";
                    }

                    else {
                        // window.location.href = "hcm_Emp_Conduct_Incident_List.aspx";
                        return false;
                    }
                });
            }
            else {
                window.location.href = "hcm_Emp_Conduct_Incident_List.aspx";
                return true;
            }
            return false;

        }
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        </script>
       <script>
       
           function DepChange(id)
           {
              
               IncrmntConfrmCounter();
               document.getElementById("<%=HiddenFocus.ClientID%>").value = id;
               var ddlDep = document.getElementById("<%=ddldep.ClientID%>").value;
               if (ddlDep != "--SELECT--") {
                   document.getElementById("<%=DeptSelectChange.ClientID%>").click();
               }
           
           }
      

           function AlldivisionEmployeeLoad(id)
           {
         
               IncrmntConfrmCounter();
              // alert(id + "AlldivisionEmployeeLoad");
               document.getElementById("<%=HiddenFocus.ClientID%>").value=id;
               var ddlBussnss = document.getElementById("<%=ddlBusnssUnit.ClientID%>").value;
               var ddlDep = document.getElementById("<%=ddldep.ClientID%>").value;
               var ddlDivs = document.getElementById("<%=ddlDivision.ClientID%>").value;
              
               if (id == "B")
               {
                  
                   document.getElementById("<%=BusSelectChane.ClientID%>").click();
               }
            
             else  if (ddlBussnss != "--SELECT--" && ddlDep != "--SELECT--" && ddlDivs != "--SELECT--")
               {
                   document.getElementById("<%=btnRedirect.ClientID%>").click();
               }
              else if (ddlBussnss != "--SELECT--" && ddlDep != "--SELECT--" ) {
                   document.getElementById("<%=btnRedirect.ClientID%>").click();
              }
              else if (ddlDep != "--SELECT--") {
                  document.getElementById("<%=DeptSelectChange.ClientID%>").click();
                    }
              else if (ddlBussnss != "--SELECT--" ) {
                  document.getElementById("<%=BusSelectChane.ClientID%>").click();
              }
           
              

           }
           
           function LoadEmployeename() {

               IncrmntConfrmCounter();
               var EmpId = document.getElementById("<%=ddlEmployee.ClientID%>").value;

               if (EmpId != "--SELECT NAME--") {

                   document.getElementById("<%=HiddenUserIdValidate.ClientID%>").value = EmpId;

                   //  $noCon("#divEmpId.cphMain_ddlEmpId input.ui-autocomplete-input").val(EmpId);
                   //var EmpVal = $au("#cphMain_ddlEmpId option:selected").text();
                   //alert(EmpVal);
                   //  $noCon('.cphMain_ddlEmpId option[value=EmpId]').attr('selected', 'selected');


                   var ddlCustomerConData = document.getElementById("<%=ddlEmpId.ClientID%>");

                   for (var i = 0; i < ddlCustomerConData.options.length; i++) {

                       if (ddlCustomerConData.options[i].value == EmpId) {

                           $noCon("div#divEmpId input.ui-autocomplete-input").val(ddlCustomerConData.options[i].text);
                           //   ddlCustomerConData.options[i].selected = true;
                           // ddlCustomerConData.selectedIndex = i;
                           break;
                       }
                   }



               }
               else {
                   document.getElementById("<%=HiddenUserIdValidate.ClientID%>").value = "";
                   $noCon("div#divEmpId input.ui-autocomplete-input").val("--SELECT ID--");
                   // document.getElementById("<%=ddlEmpId.ClientID%>").value =   "--SELECT ID--";
                   //  document.getElementById("<%=ddlEmployee.ClientID%>").value = "--SELECT NAME--";
               }


             }
           function LoadEmployeeId() {

               IncrmntConfrmCounter();
               var EmpId = document.getElementById("<%=ddlEmpId.ClientID%>").value;


               if (EmpId != "--SELECT ID--") {

                   document.getElementById("<%=HiddenUserIdValidate.ClientID%>").value = EmpId;
                   

                   var ddlCustomerConData = document.getElementById("<%=ddlEmployee.ClientID%>");

                   for (var i = 0; i < ddlCustomerConData.options.length; i++) {

                       if (ddlCustomerConData.options[i].value == EmpId) {

                           $noCon("div#divempName input.ui-autocomplete-input").val(ddlCustomerConData.options[i].text);
                           //   ddlCustomerConData.options[i].selected = true;
                           // ddlCustomerConData.selectedIndex = i;
                           break;
                       }
                   }



               }
               else {
                   document.getElementById("<%=HiddenUserIdValidate.ClientID%>").value = "";
                   $noCon("div#divempName input.ui-autocomplete-input").val("--SELECT NAME--");
                   //  document.getElementById("<%=ddlEmpId.ClientID%>").value =   "--SELECT ID--";
                   //  document.getElementById("<%=ddlEmployee.ClientID%>").value = "--SELECT NAME--";
               }



           }
           function LoadCategoryDescrption()
           {
               IncrmntConfrmCounter();
               var CategoryId = document.getElementById("<%=ddlCategory.ClientID%>").value;
              
               if (CategoryId != "--SELECT--") {
                   $.ajax({
                       type: "POST",
                       async: false,
                       contentType: "application/json; charset=utf-8",
                       url: "hcm_Emp_Conduct_Incident.aspx/ReadDescrption",
                       data: '{varCategoryId: "' + CategoryId + '"}',
                       dataType: "json",
                       success: function (data) {
                          
                           document.getElementById("<%=txtmemodes.ClientID%>").value = data.d;
                           

                           
                       }
                   });
               }

           }
           function PrintClick() {
               window.open("Conduct_Incident_Print.htm");
               return false;
           }

           function DateCurrentValue() {

               var DateVal = document.getElementById("txtDateFrom").value;
            
               if (DateVal == "") {

                   document.getElementById("txtDateFrom").value = document.getElementById("<%=Hiddentxtefctvedate.ClientID%>").value;

               }
               return false;
           }

           function ValidateConduct()
           {
               var ret = true;
              
               

               if (document.getElementById("<%=HiddenAllUserDivision.ClientID%>").value=="1")
               {
                   document.getElementById("<%=ddlBusnssUnit.ClientID%>").style.borderColor = "";
                   document.getElementById("<%=ddldep.ClientID%>").style.borderColor = "";
                   document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "";
               }
               $noCon("div#divEmpId input.ui-autocomplete-input").css("borderColor", "");
               $noCon("div#divempName input.ui-autocomplete-input").css("borderColor", "");
            //   document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "";
             //  document.getElementById("<%=ddlEmpId.ClientID%>").style.borderColor = "";
               document.getElementById("<%=txtCondtdescrp.ClientID%>").style.borderColor = "";
               document.getElementById("<%=ddlPriorty.ClientID%>").style.borderColor = "";
             //  document.getElementById("<%=ddlCategory.ClientID%>").style.borderColor = "";
               //document.getElementById("<%=txtmemodes.ClientID%>").style.borderColor = "";
               document.getElementById("txtDateFrom").style.borderColor = "";

               var condctDescrp = document.getElementById("<%=txtCondtdescrp.ClientID%>").value;
               var condTime = document.getElementById("txtDateFrom").value;
               var condSevrty = document.getElementById("<%=ddlPriorty.ClientID%>").value;

              // var ddlemp = document.getElementById("<%=ddlEmployee.ClientID%>").value;
               //var ddlempid = document.getElementById("<%=ddlEmpId.ClientID%>").value;

               if (document.getElementById("<%=checkMemo.ClientID%>").checked == true)
               {
                   document.getElementById("<%=ddlCategory.ClientID%>").style.borderColor = "";
                   document.getElementById("<%=txtmemodes.ClientID%>").style.borderColor = "";
                   var memodescrp = document.getElementById("<%=txtmemodes.ClientID%>").value;

                   if (memodescrp == "") {
                       document.getElementById("<%=txtmemodes.ClientID%>").style.borderColor = "Red";
                                       document.getElementById("<%=txtmemodes.ClientID%>").focus();

                       $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                       $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                       });
                       $noCon("#divWarning").alert();
                                       $noCon1(window).scrollTop(0);

                                       ret = false;
                                   }

                
              
               }
               //EVM-0024
               var ddlCat = document.getElementById("<%=ddlCategory.ClientID%>").value;

               if (ddlCat == "--SELECT--") {
                   document.getElementById("<%=ddlCategory.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=ddlCategory.ClientID%>").focus();

                   $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                   $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                   });
                   $noCon("#divWarning").alert();
                      $noCon1(window).scrollTop(0);

                      ret = false;
               }
               //END
               if (condSevrty == "--SELECT--") {
                   document.getElementById("<%=ddlPriorty.ClientID%>").style.borderColor = "Red";
                                  document.getElementById("<%=ddlPriorty.ClientID%>").focus();

                   $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                   $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                   });
                   $noCon("#divWarning").alert();
                                  $noCon1(window).scrollTop(0);

                                  ret = false;
                              }

               if (condTime == "") {
                   document.getElementById("txtDateFrom").style.borderColor = "Red";
                   document.getElementById("txtDateFrom").focus();
                   $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                   $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                   });
                   $noCon("#divWarning").alert();
                        $noCon1(window).scrollTop(0);

                        ret = false;
               }
           

               if (condctDescrp == "") {
                   document.getElementById("<%=txtCondtdescrp.ClientID%>").style.borderColor = "Red";
                           document.getElementById("<%=txtCondtdescrp.ClientID%>").focus();
                   $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                   $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                   });
                   $noCon("#divWarning").alert();
                           $noCon1(window).scrollTop(0);

                           ret = false;
                       }
               


               if (document.getElementById("<%=HiddenUserIdValidate.ClientID%>").value == "") {
                   $noCon("div#divEmpId input.ui-autocomplete-input").css("borderColor", "red");
                  // document.getElementById("<%=ddlEmpId.ClientID%>").style.borderColor = "Red";
                 //  document.getElementById("<%=ddlEmpId.ClientID%>").focus();
                   $noCon("div#divEmpId input.ui-autocomplete-input").focus();
                   $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                   $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                   });
                   $noCon("#divWarning").alert();
                   $noCon1(window).scrollTop(0);

                   ret = false;
               }
               if (document.getElementById("<%=HiddenUserIdValidate.ClientID%>").value == "") {
                   $noCon("div#divempName input.ui-autocomplete-input").css("borderColor", "red");
                   //  document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "Red";
                   $noCon("div#divempName input.ui-autocomplete-input").focus();
                       // document.getElementById("<%=ddlEmployee.ClientID%>").focus();
                   $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                   $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                   });
                   $noCon("#divWarning").alert();
                        $noCon1(window).scrollTop(0);

                        ret = false;
                    }

               if (document.getElementById("<%=HiddenAllUserDivision.ClientID%>").value == "1") {
                  var ddlBussns= document.getElementById("<%=ddlBusnssUnit.ClientID%>").value;
                  var ddldep= document.getElementById("<%=ddldep.ClientID%>").value;
                   var ddldivisn = document.getElementById("<%=ddlDivision.ClientID%>").value;


                   

                   if (ddldep == "--SELECT--") {
                       document.getElementById("<%=ddldep.ClientID%>").style.borderColor = "Red";
                              document.getElementById("<%=ddldep.ClientID%>").focus();
                       $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                       $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                       });
                       $noCon("#divWarning").alert();
                              $noCon1(window).scrollTop(0);

                              ret = false;
                          }

                   if (ddlBussns == "--SELECT--")
                   {
                       document.getElementById("<%=ddlBusnssUnit.ClientID%>").style.borderColor = "Red";
                       document.getElementById("<%=ddlBusnssUnit.ClientID%>").focus();
                    
                       $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                       $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                       });
                       $noCon("#divWarning").alert();
                       $noCon1(window).scrollTop(0);
                     
                       ret = false;
                   }
                   }
               return ret;
           }

           function Validatemessage()
           {
               var ret = true;
               
               document.getElementById("<%=txtmessg.ClientID%>").style.borderColor = "";

               var vartextmsg = document.getElementById("<%=txtmessg.ClientID%>").value;
               if (vartextmsg == "") {
                   document.getElementById("<%=txtmessg.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtmessg.ClientID%>").focus();
                   $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                   $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                   });
                   $noCon("#divWarning").alert();
                        $noCon1(window).scrollTop(0);

                        ret = false;
                    }
           }
           function FocusBusness()
           {
               document.getElementById("<%=ddlBusnssUnit.ClientID%>").focus();
           }
           function SuccessCancelMsg() {
               $noCon("#success-alert").html("Incident message removed successfully.");
               $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
               });
               $noCon("#success-alert").alert();
               return false;
           }
       </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
            <asp:HiddenField ID="hiddenupd" runat="server" />
     <asp:HiddenField ID="HiddenFieldQryString" runat="server" />
     <asp:HiddenField ID="HiddenAllUserDivision" runat="server" />
      <asp:HiddenField ID="HiddenConductInsId" runat="server" />
     <asp:HiddenField ID="HiddenEmailAddress" runat="server" />
      <asp:HiddenField ID="HiddenUserId" runat="server" />
    <asp:HiddenField ID="HiddenRoleUpd" runat="server" />
    <asp:HiddenField ID="HiddenFocus" runat="server" />
       <asp:HiddenField ID="HiddenUserIdValidate" runat="server" />
           <asp:HiddenField ID="HiddenConductId" runat="server" />
   <%-- <div class="cont_rght" style="width: 90%">--%>
        <%-- <div id="divMessageArea" style="display: none; margin: 0px 0 13px; width: 89%;">
            <img id="imgMessageArea" src="">
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>--%>
       <%--  <div class="alert alert-success" id="success-alert" style="display: none;margin-left: 0%;width: 98%;">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>--%>
         <%--<div class="alert alert-danger" id="divWarning" style="display:none">--%>
 <%--   <button type="button" class="close" data-dismiss="alert">x</button></div>--%>
       <%--  <div  id="divList"  class="list" runat="server" style="position: fixed; right: 5%; top: 42%; height: 26.5px;" onclick=" ConfirmMessage()">

           
        </div>--%>

      <%--  <br />--%>

    <%-- <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <asp:Label ID="lblEntry" runat="server"></asp:Label>
        </div>--%>

<%--    <div style="float: left;

width: 88%;

padding: 2%;
display: block;"
>--%>
      <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

     <div id="main" role="main">
      
        <div class="cont_rght" >
                    <div class="alert alert-danger" id="divWarning" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>
                    <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button> 
        </div>
            <section id="widget-grid" class="">

                <div class="row">
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <div class="" id="wid-id-0">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <%--  <img src="/Images/BigIcons/Job_Delegation.png" style="vertical-align: middle;" />--%>
  Employee Conduct Incident
        </div >
      
        <div  id="divList"  class="list" runat="server" style="position: fixed; right: 2%; top: 42%; height: 26.5px;z-index: 90;" onclick="return ConfirmMessage()">

           
        </div>

                            <br>

  <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: #f6f6f6; float: left">
       
    <div class="auto1">
<div class="cont_rght" style="width:100%">
<div class="sect250">
<div class="row">
<div class="col-xs-12">
<div class="box box-solid">
<%--<div class="box-header">
  <h3 class="box-title" style="text-transform:uppercase;margin-bottom:14px;">Employee conduct master</h3>
</div>--%>
<div  class="box-body" >
<div class="container-fluid" style="background-color:#f3f3f3;padding-top:40px;padding-bottom:33px;">
    <div id="div1" runat="server" class="col-sm-7 col-md-7 ">

<div class="form-group row">
  <label for="staticEmail" class="lblh2">Ref<span style="color:#F00">*</span></label>
  <div class="col-sm-8">
<H2 runat="server" id="RefH2"></H2>
  </div>
</div>
</div>

 <asp:UpdatePanel ID="UpdatePanel1"  EnableViewState="true" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
<div id="divBissnss" runat="server" class="col-sm-6 col-md-6 " style="margin-right: 1%;">

<div class="form-group row">
  <label for="staticEmail" class="lblh2">Business Unit<span style="color:#F00">*</span></label>
  <div class="col-sm-8">
 <asp:DropDownList ID="ddlBusnssUnit" TabIndex="1" class="form-control custom-select" onchange="AlldivisionEmployeeLoad('B');"   runat="server"  onkeypress="return DisableEnter(event)" ></asp:DropDownList>
       <asp:Button ID="BusSelectChane" runat="server" Text="Button" style="display:none;" onclick="BusSelectChane_Click" />
  </div>
</div>
</div>
<div id="divDeprtmt" runat="server" class="col-sm-6 col-md-6 " style="width: 49%;">
  <div class="form-group row">
    <label for="staticEmail" class="lblh2">Department<span style="color:#F00">*</span></label>
    <div class="col-sm-8">
     <asp:DropDownList ID="ddldep" TabIndex="2" class="form-control custom-select" onchange="DepChange('Dep');"   runat="server"  onkeypress="return DisableEnter(event)" ></asp:DropDownList>
         <asp:Button ID="DeptSelectChange" runat="server" Text="Button" style="display:none;" onclick="DeptSelectChange_Click" />
    </div>
  </div>
</div>
<div id="divDiv" runat="server" class="col-sm-6 col-md-6 " style="margin-right: 1%;">
  <div class="form-group row">
    <label for="inputPassword" class="lblh2">Division</label>
    <div class="col-sm-8">
 <asp:DropDownList ID="ddlDivision" TabIndex="3" onchange="AlldivisionEmployeeLoad('D');" class="form-control custom-select"   runat="server"  onkeypress="return DisableEnter(event)" ></asp:DropDownList>
    </div>
  </div>
</div>
            
<div  class="col-sm-6 col-md-6 " style="width: 49%;">
  <div class="form-group row">
     <label for="inputPassword" class="lblh2">Employee Name<span style="color:#F00">*</span></label>
    <div class="col-sm-8" style="width:67%">
        <div id="divempName">
      <asp:DropDownList ID="ddlEmployee" TabIndex="4" onchange="LoadEmployeename();" class="form-control custom-select"   runat="server"  onkeypress="return DisableEnter(event)" ></asp:DropDownList>
     
            </div>
           <asp:Button ID="btnRedirect" runat="server" Text="Button" style="display:none;" onclick="btnRedirect_Click" />
    </div>
     
  </div>
</div>
                 

<div class="col-sm-6 col-md-6 " style="margin-right: 1%;">
  <div class="form-group row">
    <label for="inputPassword" class="lblh2">Description<span style="color:#F00">*</span></label>
    <div class="col-sm-8">
      <asp:TextBox  class="form-control" TabIndex="6" id="txtCondtdescrp" runat="server" TextMode="MultiLine" MaxLength="1800" onkeydown="textCounter(cphMain_txtCondtdescrp,1800)" onkeyup="textCounter(cphMain_txtCondtdescrp,1800)" style="height:80px;resize:none;" ></asp:TextBox>
    </div>
  </div>
</div>
    <div  class="col-sm-6 col-md-6 " style="width: 49%;">
  <div class="form-group row">
     <label for="inputPassword" class="lblh2">Employee ID<span style="color:#F00">*</span></label>
     <div class="col-sm-8" style="width:67%">
         <div id="divEmpId">
      <asp:DropDownList ID="ddlEmpId" TabIndex="5" onchange="LoadEmployeeId();" class="form-control custom-select"   runat="server"  onkeypress="return DisableEnter(event)" ></asp:DropDownList>
           </div>
    </div>
           
  </div>
</div>
                      
                         </ContentTemplate>
                     
                     </asp:UpdatePanel>

     <div class="col-sm-6 col-md-6 " style="margin-left: 0%; width: 49%;">
  <div class="form-group row">
    <label for="inputPassword" class="lblh2">Incident Date<span style="color:#F00">*</span></label>
    <div class="col-sm-8">
           <input id="txtDateFrom" tabindex="7" readonly="readonly" name="txtDateFrom" onblur="DateCurrentValue();" type="text" onkeypress="return DisableEnter(event)"   class="Tabletxt form-control datepicker"  data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" onchange="show()" />
                                                    <asp:HiddenField ID="Hiddentxtefctvedate" runat="server" value="0"/>
                                                                        <script>
                                                                            var $noCon4 = jQuery.noConflict();
                                                                            var dateToday = new Date();
                                                                            $noCon4('#txtDateFrom').datepicker({
                                                                                autoclose: true,
                                                                                format: 'dd-mm-yyyy',
                                                                                //endDate: 'today',
                                                                              

                                                                            });
                                                                            function show() {
                                                                                //DateCheck();
                                                                                IncrmntConfrmCounter();
                                                                                DateCurrentValue();
                                                                                // $noCon4("#txtDateFrom").datetimepicker({ format: 'dd-mm-yyyy' })
                                                                                $noCon4('#cphMain_Hiddentxtefctvedate').val($noCon4('#txtDateFrom').val().trim());
                                                                             

                                                                            }
                                                                            function insert() {

                                                                                IncrmntConfrmCounter();
                                                                                $noCon4('#txtDateFrom').val($noCon4('#cphMain_Hiddentxtefctvedate').val().trim());

                                                                            }
                                                                             </script>
    </div>
  </div>
</div>

<div class="col-sm-6 col-md-6 " style="margin-right: 1%;">
  <div class="form-group row">
    <label for="inputPassword" class="lblh2">Type<span style="color:#F00">*</span></label>
    <div class="col-sm-8">
        

             <div   class="smart-form" style="float: left; width: 99%;">
                   <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px; float: left; border: 1px solid #04619c; margin-bottom: 1px;">
      <label class="radio">
        <input type="radio" checked="true" tabindex="8" onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" runat="server" id="typGood" style="display:block" name="optradio" />
       <i></i>  Positive</label>
      <label class="radio">
        <input type="radio" id="typNegtve" tabindex="9" onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" runat="server" style="display:block" name="optradio" />
        <i></i> Negative</label>
                </div>
              </div>
    </div>
  </div>
</div>
<div class="col-sm-6 col-md-6 " style="float: right; width: 49%;">
  <div class="form-group row" style="width: 100%;">
    <label id="Label1" for="inputPassword" runat="server" class="lblh2">Severity <span style="color:#F00">*</span></label>
    <div class="col-sm-8" style="width: 71%;">
     
              <asp:DropDownList ID="ddlPriorty" TabIndex="10" CssClass="form-control" class="form1" runat="server" style="margin-left: 2%;" onkeypress="return DisableEnter(event)">
                    <asp:ListItem Text="--SELECT--" Value="--SELECT--"></asp:ListItem>
                            <asp:ListItem Text="CRITICAL" Value="1"></asp:ListItem>
                            <asp:ListItem Text="HIGH" Value="2"></asp:ListItem>
                            <asp:ListItem Text="MEDIUM" Value="3"></asp:ListItem>
                            <asp:ListItem Text="LOW" Value="4"></asp:ListItem>
                            </asp:DropDownList>
    </div>
  </div>
</div>
    <div class="col-sm-6 col-md-6 "  style="margin-right: 1%;">

<div class="form-group row">
  <label for="staticEmail" class="lblh2">Category<span style="color:#F00">*</span></label>
  <div class="col-sm-8">
   <asp:DropDownList ID="ddlCategory" TabIndex="11" onchange="LoadCategoryDescrption();" class="form-control custom-select"   runat="server"  onkeypress="return DisableEnter(event)" ></asp:DropDownList>
  </div>
</div>
</div>
    <div class="col-sm-6 col-md-6 " style="width: 49%;"> 
  <div class="form-group row" style="width: 625px;">
    <label for="inputPassword" class="lblh2" style="width: 20%;">Notification<span style="color:#F00">*</span></label>
    <div class="col-sm-8">
                    <div   class="smart-form" style="float: left; width: 99%;">    
                         <div class="inline-group" style=" padding-left: 4%; padding-top: 3px; float: left; height:0px; margin-bottom: 1px;">
                                  
                        <label class="checkbox" style="margin-bottom: 13%; margin-right: 10px;" >
        <input type="checkbox" id="ChkBxReprtOff" tabindex="12" onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" runat="server" />
     Reporting Officer <i  ></i></label>
            <label class="checkbox" style="margin-bottom: 13%; margin-right: 10px;" >
        <input type="checkbox" id="ChkBxDivMngr" tabindex="13" onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" runat="server" />
       <%-- <span class="checkmark"></span>--%>  Division Manager <i  ></i></label>
 <label class="checkbox" >
        <input type="checkbox" id="ChkBxEmployee" tabindex="14" onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" runat="server" />
       <%-- <span class="checkmark"></span>--%>  Employee <i  ></i></label>
                             </div>
                        </div>
    </div>
  </div>
</div>





    <div class="col-sm-6 col-md-6 ">
  <div class="form-group row">
    <label for="inputPassword" class="lblh2">Issue memo</label>
    <div class="col-sm-8">
           <div   class="smart-form" style="float: left;">    
      <label class="checkbox">Yes
        <input type="checkbox" runat="server" tabindex="15"  onchange="FunctMemoChkBx();"  onkeypress="return DisableEnter(event)" id="checkMemo" />
       <i  ></i> </label>
               </div>
    </div>
  </div>
</div>

       <div class="col-sm-6 col-md-6 ">
  <div class="form-group row">
  
    <div class="col-sm-8" style="margin-left: 29%;">
      
   <div class="col-sm-6 col-md-6 " style="text-align:right">  <button id="BtnClose" tabindex="23" runat="server" onclick="return CloseValidate();"    class="btn btn-info"  > <span class="glyphicon glyphicon-remove"></span> CLOSE INCIDENT </button></div>
<div class="col-sm-6 col-md-6 " style="text-align:right">  <button id="BtnTerminate" tabindex="24" runat="server" onclick="return ValidateTerminate()"    class="btn btn-info"  > <span class="fa fa-user-times"></span> TERMINATION </button></div>
   <div class="col-sm-6 col-md-6 " style="text-align:right">  <button id="BtnNotClose" tabindex="25" runat="server" onclick="return ValidateNotClose();"    class="btn btn-info"  > <span class="glyphicon glyphicon-remove"></span> CLOSE INCIDENT </button></div>

<div class="col-sm-6 col-md-6 " style="text-align:right">  <button id="BtnNotTerminate" tabindex="26" runat="server" onclick="return ValidateNotTerminate()"    class="btn btn-info"  > <span class="fa fa-user-times"></span> TERMINATION </button></div>

           <asp:Button ID="Bttnterminate" runat="server" Text="Button" style="display:none;" onclick="bttnTerminate_Click" />
          <asp:Button ID="BttnClose" runat="server" Text="Button" style="display:none;" onclick="bttnClose_Click" />
           <asp:Button ID="BtnConfirm" runat="server" Text="Button" style="display:none;" onclick="bttnUpdate_Click" />
    </div>
  </div>
</div>



<div class="col-lg-12 col-md-12 col-sm-12" id="show-div" style="background-color:#e4e4e4;height:auto;padding-top:20px;padding-bottom:20px;display:none;">
      

  <div class="col-sm-6 col-md-6 " style="width: 100%;">
    <div runat="server" id="DivPrint" style="float:right;margin-right: 3.5%;display:none">
      <button id="print" onclick="return PrintClick();"   class="btn btn-info"  > <span class="glyphicon glyphicon-print"></span> PRINT MEMO </button>
    </div>
      </div>

    
    
<div class="col-sm-6 col-md-6 ">
  <div class="form-group row">
    <label for="inputPassword" class="lblh2">Description <span style="color:#F00">*</span></label>
    <div class="col-sm-8">
      <asp:TextBox class="form-control" id="txtmemodes" TabIndex="16"  TextMode="MultiLine" MaxLength="850" onkeydown="textCounter(cphMain_txtmemodes,850)" onkeyup="textCounter(cphMain_txtmemodes,850)" runat="server" style="height:85px;resize:none;" ></asp:TextBox>
    </div>
  </div>
</div>

<div class="col-sm-6 col-md-6 " >
  <div class="form-group row">
    <label for="inputPassword" class="lblh2">Mail Notification</label>
    <div class="col-sm-8">

            <div   class="smart-form" style="float: left; width: 99%;">    
      <label class="checkbox">Yes
      <input type="checkbox" id="ChkBxMailNotfcn" tabindex="17" onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" runat="server" />
       <i ></i> </label>
               </div>


    
    </div>
  </div>
</div>
<div style="clear:both"></div>

    <div runat="server" id="DivChatMsg" style="display:none">
        <div class="panel col-xs-12 font-sty" style="clear:both;background-color:transparent;font-weight: bold;font-family:Calibri">Conversation</div>
<div class="col-lg-12 col-md-12 col-sm-12"   style="background-color: #FFFFFF;height: auto; max-height:230px;overflow: auto;padding-top: 20px;padding-bottom: 20px;
    padding-left: 3px;
    padding-right: 3px;">
    <div id="DivMssgBox" runat="server"></div>
 <%-- <div class="col-xs-12" style="height:auto;text-align:left;padding-bottom:10px;">
    <div class="panel panel-info col-xs-10 arrow_left_box padding-0">
      <div class="panel-heading">“All Division” sub user role available for this module role, it is for give the provision to an employee to report a conduct against all division’s employee
         <div   style="color:#a9a7a7;
    padding-left: 10px;
    font-size: 12px;
    margin-top: 7px;">22/05/2019 5pm</div>
    </div>
    </div>
  
  </div>  --%>
  
  <%--  <div class="col-xs-12" style="height:auto;text-align:right;padding-bottom:10px;">
      <div class="panel panel-default col-xs-11 arrow_right_box padding-0" style="float:right;">
        <div class="panel-heading">Panel with panel-info class
          <div   style="color:#a9a7a7;
    padding-left: 10px;
    font-size: 12px;
    margin-top: 7px;">22/05/2019 5pm</div>
        </div>
      </div>
    </div>--%>
    
  
  
    
 
    
  </div>
   </div>
   
 <div class="col-sm-12 col-md-12 padding-0">
  <div class="form-group row" style="padding-top:20px;">
       <div runat="server" id="divReplyMssg" style="display:none;">
           
    <div  class="col-sm-6" >
          <div class="panel col-xs-12 font-sty" style="clear:both;background-color:transparent;font-weight: bold;font-family:Calibri">Message</div>
<%--    <asp:TextBox type="text" runat="server" class="form-control"  onkeypress="return DisableEnter(event)"  onblur="return RemoveTag('cphMain_txtmessg')"  id="txtmessg" placeholder="Type reply here..." style="height: 60px;resize:none;" ></asp:TextBox>--%>

           <asp:TextBox  class="form-control" id="txtmessg" runat="server" TextMode="MultiLine" placeholder="Type message here..." MaxLength="1500" onkeydown="textCounter(cphMain_txtmessg,1500)" onkeyup="textCounter(cphMain_txtmessg,1500)" style="height:80px;resize:none;" ></asp:TextBox>
    </div>
       </div>
  </div>

 </div> 


  
</div>


         <div class="col-sm-12 col-md-12 padding-0" style="margin-top:20px;">
 <div class="col-md-6 col-sm-12" style="float:right;">
 <span style="float:right;">
 <asp:Button ID="bttnsave" OnClick="bttnsave_Click" TabIndex="18"  runat="server" OnClientclick="return ValidateConduct();"  class="btn btn-info" text="Save" />
  <asp:Button ID="btnSaveCls" OnClick="bttnsave_Click" TabIndex="19" runat="server" OnClientclick="return ValidateConduct();" class="btn btn-info" text="Save&Close" />
     <asp:Button ID="bttnUpdate" OnClick="bttnUpdate_Click" TabIndex="20" runat="server" OnClientclick="return ValidateConduct();" class="btn btn-info" text="Update" />
     <asp:Button ID="bttnUpdateCls" OnClick="bttnUpdate_Click" TabIndex="21" runat="server" OnClientclick="return ValidateConduct();" class="btn btn-info" text="Update&Close" />
      <asp:Button ID="bttnCofrm" runat="server" TabIndex="22" OnClientclick="return ConfirmAlert();" OnClick="bttnUpdate_Click" class="btn btn-info" text="Confirm" />
  <%-- <input type="button" class="btn btn-success" value="Save&Confirm">
    <input type="button" class="btn btn-danger" value="Cancel">--%>
   </span> 
    </div>
</div>

    
     <div id="divPrintReport" runat="server" style="display: none;">
          
        </div>

</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
      

          
    </div>

  </div>  </article>  </div>  </section>  </div>  </div>





        
    <%--    <div class="eachform" style="float: left; width: 63%;margin-left: 17%;">
                <h2>Status*</h2>
                <asp:CheckBox ID="CbxStatus" Text="" runat="server" onkeydown="return DisableEnter(event)"  onchange="IncrmntConfrmCounter();" class="form2" style="float: left;margin-left: 42%;" TabIndex="3" Checked="true"/>
             <asp:Label ID="lblStatus" style="font-family: calibri;" runat="server" Text="Active"></asp:Label>
        </div>--%>

      <%--  <div class="contentarea">--%>
        



      <%--  </div>--%>
  <%--  </div>--%>

            <br />
       <%-- <div class="eachform">
            <div class="subform" style="width: 72%; margin-top: 5%;float: left;margin-left: 43%;">


               
                <asp:Button ID="btnAdd" runat="server" class="btn btn-primary" Text="Save" OnClientClick=" return ReasonValidate();" OnClick="btnAdd_Click" TabIndex="4"/>
                <asp:Button ID="btnAddClose" runat="server" class="btn btn-primary" Text="Save & Close" TabIndex="5"  OnClientClick=" return ReasonValidate();" OnClick="btnAdd_Click" />
                <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary"  Text="Update" TabIndex="6"  OnClientClick=" return ReasonValidate();" OnClick="btnUpdate_Click"/>
                <asp:Button ID="btnUpdateClose" runat="server" class="btn btn-primary"  Text="Update & Close" TabIndex="7"   OnClientClick=" return ReasonValidate();" OnClick="btnUpdate_Click"/>
                 <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" OnClientClick="return ConfirmMessage();" />
            </div>
        </div>--%>
        <%--</div>--%>
    <style>

        


/*.datepicker table tr td.old{
    color:red;
}*/


    </style>
       <style type="text/css">
        .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            width: 218px;
            border: 1px solid #B0BECA;
            max-height: 135px;
            overflow-x: auto;
            font-family: Calibri;
        }

            .ui-autocomplete .ui-menu-item {
                border-top: 1px solid #B0BECA;
                display: block;
                padding: 4px 6px;
                color: #353D44;
                cursor: pointer;
                font-family: Calibri;
            }

                .ui-autocomplete .ui-menu-item:first-child {
                    border-top: none;
                    font-family: Calibri;
                }

                .ui-autocomplete .ui-menu-item.ui-state-focus {
                    background-color: #D5E5F4;
                    color: #161A1C;
                    font-family: Calibri;
                }
    </style>
  <%--  <script src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>--%>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>




        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

                var prm = Sys.WebForms.PageRequestManager.getInstance();
                //  prm.add_initializeRequest(InitializeRequest);
                prm.add_endRequest(EndRequest);


                $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
                $au('#cphMain_ddlEmpId').selectToAutocomplete1Letter();
                //  $au('#cphMain_ddlLeavTyp').selectToAutocomplete1Letter();

                $au('form').submit(function () {

                    //   alert($au(this).serialize());


                    //   return false;
                });
            });
        })(jQuery);

        //function InitializeRequest(sender, args) {
        //}

        function EndRequest(sender, args) {
            // after update occur on UpdatePanel re-init the Autocomplete
         
            $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
            $au('#cphMain_ddlEmpId').selectToAutocomplete1Letter();
           // $au('#cphMain_ddlEmployee').autocomplete("destroy");

        }





                    </script>




</asp:Content>
