<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" CodeFile="Performance_Evaluation_Analysis.aspx.cs" Inherits="HCM_HCM_Master_Employee_Performance_Mangmnt_Performance_Evaluation_Analysis_Performance_Evaluation_Analysis" %>

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
    <script src="js/jquery.min.js"></script>
<%--    <script src="../../../../js/bootstrap/bootstrap3.3.5.min.js"></script>--%>
<%--    <script src="js/jquery-1.11.2.min.js"></script> 
<script src="js/jquery.min.js"></script>
<script src="js/bootstrap3.3.5.min.js"></script>--%>

    <script>




        var $noCon1 = jQuery.noConflict();
        $noCon1(window).load(function () {
            

            document.getElementById("print_cap").focus();
            $('.hiddenn').removeClass('hiddenn').addClass('hiddenncopy');

            $('#lisum').removeClass('nav-item').addClass('nav-item active');
            
            document.getElementById("<%=divPrintReport.ClientID%>").style.display = "none";
            
         
        });
        var $NoConfi = jQuery.noConflict();
        $NoConfi(document).ready(function () {
            $('#loading').hide();

        });
        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

                var prm = Sys.WebForms.PageRequestManager.getInstance();
            
                prm.add_endRequest(EndRequest);


             

                $au('form').submit(function () {

                
                });
            });
        })(jQuery);


        function EndRequest(sender, args) {
           
          //  $('#Summaries').removeClass('tab-pane fade active in');
            $('.nav-item active').removeClass('nav-item active').addClass('nav-item');

            var varid = document.getElementById("cphMain_HiddenFieldTab").value;
           
           $('#' + varid).removeClass('nav-item').addClass('nav-item active');

           google.charts.load('current', { 'packages': ['corechart'] });
           google.charts.setOnLoadCallback(drawChart);
              document.getElementById("<%=divPrintReport.ClientID%>").style.display = "none";
        
        //    $("#cphMain_divPrintReport").hide().delay(2000);
        }



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
    
        function getDetails() {
           // document.getElementById("<%=divPrintReport.ClientID%>").value = "";
           // document.getElementById("<%=divPrintReport.ClientID%>").style.display = "block";
            document.getElementById("cphMain_HiddenFieldTab").value = "liself";
            document.getElementById("cphMain_btnSelf").click();
          
            
            return false;

        }
        function getRoDetls() {
           // document.getElementById("<%=divPrintReport.ClientID%>").value = "";
            //document.getElementById("<%=divPrintReport.ClientID%>").style.display = "block";
            document.getElementById("cphMain_HiddenFieldTab").value = "lirp";

            document.getElementById("cphMain_btnReptngOfficer").click();
           
            return false;

        }
        function getDmDetls() {
          //  document.getElementById("<%=divPrintReport.ClientID%>").value = "";
           // document.getElementById("<%=divPrintReport.ClientID%>").style.display = "block";
            document.getElementById("cphMain_HiddenFieldTab").value = "lidm";
            document.getElementById("cphMain_btnDm").click();
         

            return false;


        }
        function getGmDetls() {
           // document.getElementById("<%=divPrintReport.ClientID%>").value = "";
           // document.getElementById("<%=divPrintReport.ClientID%>").style.display = "block";
            document.getElementById("cphMain_HiddenFieldTab").value = "ligm";
            document.getElementById("cphMain_btnGm").click();
           
            return false;


        }
        function gethrDetls() {
            //document.getElementById("<%=divPrintReport.ClientID%>").value = "";
            //document.getElementById("<%=divPrintReport.ClientID%>").style.display = "block";
            document.getElementById("cphMain_HiddenFieldTab").value = "lihr";
            document.getElementById("cphMain_btnHr").click();

            return false;


        }
        function getAddtionalEmpDetls() {
           // document.getElementById("<%=divPrintReport.ClientID%>").value = "";
            //document.getElementById("<%=divPrintReport.ClientID%>").style.display = "block";
            document.getElementById("cphMain_HiddenFieldTab").value = "liadev";
            document.getElementById("cphMain_btnAditnlEmp").click();

            return false;


        } 
        function getSummaries() {
           // document.getElementById("<%=divPrintReport.ClientID%>").value = "";
            //document.getElementById("<%=divPrintReport.ClientID%>").style.display = "block";
            document.getElementById("cphMain_HiddenFieldTab").value = "lisum";
            document.getElementById("cphMain_btnSummaries").click();

            return false;


        }

        function ConfirmMessage() {

            //  SuccessMsg("SAVE", "Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
            //$noCon("#success-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
            //$noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            //});
            //$noCon("#success-alert").alert();

            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "../Issue_Performance_Form/Emp_Issue_Prfrmnce_List.aspx";
                    }

                    else {
                        // window.location.href = "hcm_Emp_Conduct_Incident_List.aspx";
                        return false;
                    }
                });
            }
            else {

                window.location.href = "../Issue_Performance_Form/Emp_Issue_Prfrmnce_List.aspx";
                // return true;
            }
            return false;

        }


        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
            return false;
        }
    </script>
      
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
         

     <asp:HiddenField ID="HiddenIssueId" runat="server" />
     <asp:HiddenField ID="HiddenEmpId" runat="server" />
         <asp:HiddenField ID="hiddenGrpId" runat="server" />
         <asp:HiddenField ID="HiddenQstnCount" runat="server" />
     <asp:HiddenField ID="HiddenFieldView" runat="server" />

      <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

     <div id="main" role="main">
      
        <div class="cont_rght" >
                  <div style="height:34px;">
  
                    <div class="alert alert-danger" id="divWarning" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>
                    <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button> 
        </div>
                                                 <div id="loading">
        <img src="/Images/Other%20Images/loading.gif" style="width: 12%; margin-left: 46%; margin-top: 4%;" />

    </div>
            <section id="widget-grid" class="">

                <div class="row">
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <div class="" id="wid-id-0">


        <div id="divReportCaption" runat="server" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <img src="/Images/BigIcons/ANALYZE PERFORMANCE EVALUATION.png" style="vertical-align: middle;" />
     <asp:Label ID="lblEntry" runat="server"> PERFORMANCE EVALUATION ANALYSIS</asp:Label>
        </div >

                                                          <div style="cursor: default; float: right; height: 29px; margin-right: 1.5%; margin-top: 0.5%; font-family: Calibri;margin-bottom:1%" class="print">
     <a id="print_cap" target="_blank" data-title="Visa Bundle" href="Common_print.htm" class="btn btn-info btn-sm">
      <%-- <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">--%>
         <span class="glyphicon glyphicon-print"></span>
        <span >Print</span></a>                                  
</div>
      
      
        <div  id="divList"  class="list" runat="server" style="position: fixed; right: 2%; top: 42%; height: 26.5px;z-index: 90;" onclick="return ConfirmMessage()">

           
        </div>

                            <br>

  <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: #f6f6f6; float: left">
       
    <div class="auto1">
<div class="cont_rght" style="width:100%">
<div class="sect250">



  <div class="row">
      <div class="container" style="padding-top:18px;padding-bottom: 33px;">
          <div class="container" style="padding: 0px; width: 99%; float: left; margin-left: 0px; border: 0px solid; font-family: calibri; background-color: rgb(227, 228, 224); font-size: 14px;">

      <div style="clear:both"></div>
   <%--   <div class="container" style="padding:0px;margin-top:18px;">--%>
              <div class="row" style="margin-top:6px;">
      <div class="col-md-4" style="width: 41%; float: left; margin-left: 1%;">
   
      <div class="form-group">
        <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 16px; font-weight: bold; width: 30%;">Performance Form </label>
        <div class="col-md-8 col-sm-8">
              <asp:Label ID="lblPrfmncNam" runat="server" class="col-md-8" style="padding:0;"></asp:Label>
        <%--  <label class="col-md-8" style="padding:0;font-size:16px;"><b>EMP-5632</b></label>--%>
        </div>
      </div>
      </div>
      <div class="col-md-4" style="float: right; margin-right: 2.1%;">
        <div class="form-group">
          <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 16px; font-weight: bold;">Reference No.</label>
          <div class="col-md-8 col-sm-8">
               <asp:Label ID="lblRef" runat="server" class="col-md-8" style="padding:0;"></asp:Label>

    <%--        <label class="col-md-8" style="padding:0;font-size:16px;"><b>Akhil</b></label>--%>
          </div>
        </div>
      </div>

      </div>


      <%--  <label class="col-md-8" style="padding:0;font-size:16px;"><b>EMP-5632</b></label>--%>
      <div class="row" style="margin-top:6px;">
      <div class="col-md-4" style="width: 30%; float: left; margin-left: 1%;">
   
      <div class="form-group">
        <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 16px; font-weight: bold;">Employee Code </label>
        <div class="col-md-8 col-sm-8" style="float: left; margin-left: 9%; width: 56%;">
             <asp:Label ID="lblEmpId" runat="server" class="col-md-8" style="padding:0;"></asp:Label>
        <%--  <label class="col-md-8" style="padding:0;font-size:16px;"><b>EMP-5632</b></label>--%>
        </div>
      </div>
      </div>
      <div class="col-md-4">
        <div class="form-group">
          <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 16px; font-weight: bold;">Employee</label>
          <div class="col-md-8 col-sm-8">
               <asp:Label ID="lblEmpName" runat="server" class="col-md-8" style="padding:0;"></asp:Label>

    <%--        <label class="col-md-8" style="padding:0;font-size:16px;"><b>Akhil</b></label>--%>
          </div>
        </div>
      </div>
      <div class="col-md-4">
        <div class="form-group">
          <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 16px; font-weight: bold;">Designation</label>
          <div class="col-md-8 col-sm-8">
               <asp:Label ID="lblDesg" runat="server" class="col-md-8" style="padding:0;"></asp:Label>

            <%--<label class="col-md-8" style="padding:0;font-size:16px;"><b>Project consultant</b></label>--%>
          </div>
        </div>
      </div>
      </div>
      <div class="row" style="margin-top:6px;">
      <div class="col-md-4" style="width: 30%; float: left; margin-left: 1%;">
     
      <div class="form-group">

          

        <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 16px; font-weight: bold;">Department</label>
        <div class="col-md-8 col-sm-8" style="width: 58%; float: left; margin-left: 8%;">
                 <asp:Label ID="lblDept" runat="server" class="col-md-8" style="padding:0;"></asp:Label>
         <%-- <label class="col-md-8" style="padding:0;font-size:16px;"><b>Project consultant</b></label>--%>
        </div>
      </div>
      </div>
      <div class="col-md-4">
        <div class="form-group">
          <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 16px; font-weight: bold;">Job</label>
          <div class="col-md-8 col-sm-8">
               <asp:Label ID="lblJob" runat="server" class="col-md-8" style="padding:0;"></asp:Label>

            <%--<label class="col-md-8" style="padding:0;font-size:16px;"><b>Project consultant</b></label>--%>
          </div>
        </div>
      </div>
      <div class="col-md-4">
        <div class="form-group">
          <label class="col-md-4 col-sm-4" style="padding: 0px; font-size: 16px; float: left; font-weight: bold;">Date of Joining</label>
          <div class="col-md-8 col-sm-8">
        <asp:Label ID="lblJoinDate" runat="server" class="col-md-8" style="padding:0;"></asp:Label>
          <%--<label class="col-md-8" style="padding:0;font-size:16px;"><b>Project consultant</b></label>--%>
          </div>
        </div>
      </div>
      </div>
      <div class="row" style="margin-top:6px;">
      <div class="col-md-4" style="width: 72%; float: left; margin-left: 1%;">
     
        <div class="form-group">
          <label class="col-md-4 col-sm-4" style="padding: 0px; font-size: 16px; float: left; font-weight: bold; width: 17%;">Notes/Instruction</label>
          <div class="col-md-8 col-sm-8">
                    <asp:Label ID="lblNote" runat="server" class="col-md-8" style="padding:0;word-break: break-all;"></asp:Label>

            <%--<label class="col-md-8" style="padding:0;font-size:16px;"><b>Project consultant</b></label>--%>
          </div>
        </div>
        </div>
        </div>
     
   <%-- </div>--%>
    <div class="clearfix"></div>
</div>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>
                            <asp:HiddenField ID="HiddenType" runat="server" /> 
                   <asp:HiddenField ID="HiddenFieldTab" runat="server" />
      <asp:HiddenField ID="HiddenInnertml" runat="server" />
                           <div class="container-fluid" id="group1" style="height:auto;border:1px solid #7c8272;padding:10px;margin-top:45px;float: left;width: 98%;">
      <div class="col-6 col-md-12" style="margin-top:15px;">
                      <ul class="nav nav-tabs" id="myTab" role="tablist" style="font-size: 16px; font-family: calibri;">    <%-- emp00025--%>

          <li  id="lisum" class="nav-item"> <a class="nav-link active" id="Summaries-tab" data-toggle="tab" href="#Summaries" role="tab" aria-controls="home" aria-selected="true" aria-expanded="true" onclick="return getSummaries();">Summaries</a> </li>
          <li  id="liself" class="nav-item"> <a  class="nav-link" id="Self-tab" data-toggle="tab" href="#Self" role="tab" aria-controls="profile" aria-selected="false" aria-expanded="false" onclick="return getDetails();" >Self</a> </li>
          <li   id="lirp" class="nav-item"> <a   class="nav-link" id="Reportingofficer-tab" data-toggle="tab" href="#Reportingofficer" role="tab" aria-controls="profile" aria-selected="false" onclick="return getRoDetls();" aria-expanded="false">Reporting officer</a> </li>
          <li   id="lidm" class="nav-item"> <a   class="nav-link" id="Divisionmanager-tab" data-toggle="tab" href="#Divisionmanager" role="tab" aria-controls="profile" aria-selected="false" onclick="return getDmDetls();" aria-expanded="false">Division Manager</a> </li>
          <li   id="ligm" class="nav-item"> <a  class="nav-link" id="GM-tab" data-toggle="tab" href="#GM" role="tab" aria-controls="profile" aria-selected="false" aria-expanded="false" onclick="return getGmDetls();">GM</a> </li>
          <li   id="lihr" class="nav-item"> <a   class="nav-link" id="hr-tab" data-toggle="tab" href="#hr" role="tab" aria-controls="profile" aria-selected="false" aria-expanded="false" onclick="return gethrDetls();">HR</a> </li>
          <li    id="liadev" class="nav-item"> <a   class="nav-link" id="AdditionalEvaluators-tab" data-toggle="tab" href="#AdditionalEvaluators" role="tab" aria-controls="profile" aria-selected="false" onclick="return getAddtionalEmpDetls();" aria-expanded="false">Additional Evaluators</a> </li>
        </ul>
        <div class="tab-content" id="myTabContent">
        
       <div>
           



           <div style="width: 100%;margin-top: 1% !important;margin-left: 1%;" >
 <div id="divEmpLoad" runat="server"  style="display:none; " >

          <label class="col-md-4 col-sm-4" style="padding:0;float: left;font-size:16px;">Employee Name:</label>
    <div class="col-sm-8" style="width:55%">
        <div id="divempName">
      <asp:DropDownList ID="ddlEmployee" TabIndex="4"  class="form-control custom-select"   runat="server"  onkeypress="return DisableEnter(event)" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged"></asp:DropDownList> <%-- emp00025--%>
     
            </div>
         
    </div>


    </div>
               </div>
<div class="tab-pane fade active in" id="Summaries" runat="server" role="tabpanel" aria-labelledby="home-tab" style="border-top:none;padding:10px;">
      

   
      
      <%-- <div class="sec_one">
            <div class="col-lg-12" style="padding:1px;">
              <i class="fa fa-object-group" aria-hidden="true"></i> Section 1 </div>
            <div style="clear:both"></div>
            <hr>
            <div class="col-md-12" id="boxhide" style="height:auto;border:1px solid #868686;padding:10px;">
              <div class="col-lg-12" style="padding:0px;"> <i class="fa fa-tasks" aria-hidden="true"></i> Question 1 </div>
              <div class="form-row">
                <div class="form-group col-md-8 padding5">
                  <label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label>
                  <p class="bold_text">6</p>
                </div>
              </div>
            </div>
            <div style="clear:both"></div>
            <hr />
            <div class="col-md-12" style="height:auto;border:1px solid #868686;padding:10px;">
              <div class="col-lg-12" style="padding:0px;"> <i class="fa fa-tasks" aria-hidden="true"></i> Question 2 </div>
              <div class="form-row">
                <div class="form-group col-md-8 padding5">
                  <label for="inputCity" style="margin-bottom:8px;">Ability to follow company rules and regulations</label>
                  <br />
                  <label for="inputCity" style="margin-bottom:8px;">Ability to follow company rules and regulations</label>
                </div>
              </div>
            </div>
            <div style="clear:both"></div>
            <hr />
            </div>--%>
            
      <%--      
           <div class="sec_two">
            
               <div class="col-lg-12" style="padding:1px;margin-top:12px;">
             
              <i class="fa fa-object-group" aria-hidden="true"></i> Question 3 </div>
            <div style="clear:both"></div>
            <hr>
            <div class="col-md-12" id="Div1" style="height:auto;border:1px solid #868686;padding:10px;">
              <div class="col-lg-12" style="padding:0px;"><b> <i class="fa fa-comments-o" aria-hidden="true"></i> Evaluator comments</b> </div>
              <div class="form-row">
                <div class="form-group col-md-12 padding5" >
                
<ul style="list-style-type:square">
  <li><label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label></li>
  <li><label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label></li>
 <li><label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label></li>
  <li><label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label></li>
   <li><label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label></li>
</ul>
<div class="col-md-12" style="padding:0px;margin-top:-15px;">
        <div style="float:right;">
          <button class="btn btn-primary  btn-grey  btn-width" onclick="return false"  data-toggle="modal" data-target="#exampleModalLong" style="border-radius:0px;"> <i class="fa fa-eye" style="margin-right:10px;"></i>View All </button>
        </div>
      </div>
  
                </div>
              </div>
            </div>
    </div> --%> 
 <%-- <div class="clearfix"></div>  
    <hr />--%>
    
<div class="sec_three">
            
               <div class="col-lg-12" style="padding:1px;margin-top:12px;">
             
              <i class="fa fa-object-group" aria-hidden="true"></i> Question N </div>
            <div style="clear:both"></div>
            <hr>
            <div class="col-md-6" id="Div2" style="height:auto;border:1px solid #868686;padding:10px;">
              <div class="col-lg-12" style="padding:0px;"><b> <i class="fa fa-comments-o" aria-hidden="true"></i>
               Do you recommend the renewal of employee's contract
              </b> </div>
              <div class="form-row">
                <div class="form-group col-md-12 padding5">
                <div id="chart_wrap">
                  <div id="piechart" style="width:500px; height:300px;"></div>
                    <%-- <div id="piechart1" style="width:500px; height:300px;"></div>--%>
                  </div>
                </div>
              </div>
            </div>
            
            <div class="col-md-6" id="Div3" style="height:auto;border:1px solid #868686;padding:10px;">
              <div class="col-lg-12" style="padding:0px;"><b> <i class="fa fa-dot-circle-o" aria-hidden="true"></i>
             Goals
              </b> </div>
              <div class="form-row">
                <div class="form-group col-md-12 padding5" >
                  <div class="col-md-12" id="Div4" style="height:auto;border:1px solid #868686;padding:10px;">
              <div class="col-lg-12" style="padding:0px;"><b> <i class="fa fa-comments-o" aria-hidden="true"></i> Evaluator comments</b> </div>
              <div class="form-row">
                <div class="form-group col-md-12 padding5">
                
<ul style="list-style-type:square">
<label for="inputCity" style="margin-bottom:8px;font-weight:600">Ability to learn</label>
  <li><label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label></li>
</ul>
<ul style="list-style-type:square">
<label for="inputCity" style="margin-bottom:8px;font-weight:600">Ability to learn</label>
  <li><label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label></li>
</ul>
<ul style="list-style-type:square">
<label for="inputCity" style="margin-bottom:8px;font-weight:600">Ability to learn</label>
  <li><label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label></li>
</ul>

<div class="col-md-12" style="padding:0px;margin-top:14px;">
        <div style="float:right;">
          <button class="btn btn-primary  btn-grey  btn-width"  data-toggle="modal" data-target="#exampleModalLong" style="border-radius:0px;"> <i class="fa fa-eye" style="margin-right:10px;"></i>View All </button>
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
           <div   runat="server" class="col-md-6" id="boxhide" style="height:auto;border:1px solid #868686;padding:10px; width: 100%;">
              <div class="col-lg-12" style="padding:0px;"><b> <i class="fa fa-dot-circle-o" aria-hidden="true"></i>
             Goals
              </b> </div>
              <div class="form-row">
                <div class="form-group col-md-12 padding5" >
                  <div class="col-md-12" id="Div1" style="height:auto;border:1px solid #868686;padding:10px;">
              <div class="col-lg-12" style="padding:0px;"><b> <i class="fa fa-comments-o" aria-hidden="true"></i> Evaluator comments</b> </div>
              <div class="form-row">
                <div id="SummeryGoal" runat="server"  class="form-group col-md-12 padding5">
                


  
                </div>
              </div>
            </div>
                </div>
              </div>
            </div>
            <div id="divGoal" runat="server" class="form-group col-md-7 padding5" style=" margin-top: 10px;">

      <label for="inputCity" style="margin-left: 6px;">Goal</label>
       <asp:TextBox ID="txtGoal" TextMode="MultiLine" runat="server" CssClass="form-control" rows="3" style="resize:none; " onkeypress="return isTagEnter(event);"  onkeydown="textCounter(cphMain_txtGoal,230)" onkeyup="textCounter(cphMain_txtGoal,230)"   onblur="textCounter(cphMain_txtGoal,230)"></asp:TextBox>
  <%--   <textarea class="form-control" id="Textarea1" rows="3" style="resize:none"></textarea>--%>
    </div>
           </div> 
          
            <asp:Button ID="btnSummaries"  runat="server" class="btn btn-primary btn-grey  btn-width"  Text="Save" OnClick="btnSummaries_Click" style="display: none;"   />    
    
     <asp:Button ID="btnSelf"  runat="server" class="btn btn-primary btn-grey  btn-width"  Text="Save" OnClick="btnSelf_Click" style="display: none;"   />    
     
        <asp:Button ID="btnReptngOfficer"  runat="server" class="btn btn-primary btn-grey  btn-width"  Text="Save" OnClick="btnReptngOfficer_Click" style="display: none;"   />    
   <asp:Button ID="btnDm"  runat="server" class="btn btn-primary btn-grey  btn-width"  Text="Save" OnClick="btnDm_Click" style="display: none;"   />    
  
    <asp:Button ID="btnGm"  runat="server" class="btn btn-primary btn-grey  btn-width"  Text="Save" OnClick="btnGm_Click" style="display: none;"   />    
  
       <asp:Button ID="btnHr"  runat="server" class="btn btn-primary btn-grey  btn-width"  Text="Save" OnClick="btnHr_Click" style="display: none;"   />    
  
      <asp:Button ID="btnAditnlEmp"  runat="server" class="btn btn-primary btn-grey  btn-width"  Text="Save" OnClick="btnAditnlEmp_Click" style="display: none;"   />         
          
          
   
          
          
          
          <div class="tab-pane fade" id="Self" role="tabpanel" aria-labelledby="profile-tab" style="border: 1px solid #dddddd;
border-top: none;
    padding:15px;">
           <%-- <div class="col-lg-12" style="padding:1px;">
              <div class="btn btn-hide" onclick="myFunction()" data-toggle="modal" data-target=".bs-example-modal-sm" style="float:right;"> </div>
              <i class="fa fa-object-group" aria-hidden="true"></i> Group 1 </div>
            <div style="clear:both"></div>
            <hr>--%>
   <%--         <div class="col-md-12" id="Div5" style="height:auto;background-color:#eaeaea;padding:10px;">
              <div class="col-lg-12" style="padding:0px;"> <i class="fa fa-tasks" aria-hidden="true"></i> Question 1 </div>
              <div class="form-row">
                <div class="form-group col-md-8 padding5">
                  <label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label>
                  <select id="inputState" class="form-control" style="width:50%;">
                    <option selected="">0</option>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                  </select>
                </div>
              </div>
            </div>
            <div style="clear:both"></div>
            <hr>
            <div style="clear:both"></div>
            <hr />--%>
         <%--   <div class="col-md-12" style="height:auto;background-color:#eaeaea;margin-top:4px;padding:10px;overflow: auto;">
              <div class="col-lg-12" style="padding:0px;"> <i class="fa fa-tasks" aria-hidden="true"></i> Question 3 </div>
              <div class="form-row">
                <div class="form-group col-md-8 padding5">
                  <label for="inputCity" style="margin-bottom:8px;">Evaluator comments</label>
                  <textarea class="form-control" id="exampleFormControlTextarea1" rows="3" style="resize:none"></textarea>
                </div>
              </div>
            </div>--%>
           <%-- <div style="clear:both"></div>--%>
             
          </div>
          <%--<div class="tab-pane fade" id="Reportingofficer" role="tabpanel" aria-labelledby="Reportingofficer-tab" style="border: 1px solid #dddddd;
border-top: none;
    padding:15px;">
            <div class="col-lg-12" style="padding:1px;">
              <div class="btn btn-hide" onclick="myFunction()" data-toggle="modal" data-target=".bs-example-modal-sm" style="float:right;"> </div>
              <i class="fa fa-object-group" aria-hidden="true"></i> Group 1 </div>
            <div style="clear:both"></div>
            <hr>
            <div class="col-md-12" id="Div6" style="height:auto;background-color:#eaeaea;padding:10px;">
              <div class="col-lg-12" style="padding:0px;"> <i class="fa fa-tasks" aria-hidden="true"></i> Question 1 </div>
              <div class="form-row">
                <div class="form-group col-md-8 padding5">
                  <label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label>
                  <select id="Select1" class="form-control" style="width:50%;">
                    <option selected="">0</option>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                  </select>
                </div>
              </div>
            </div>
            <div style="clear:both"></div>
            <hr>
            <div style="clear:both"></div>
            <hr />
            <div class="col-md-12" style="height:auto;background-color:#eaeaea;margin-top:4px;padding:10px;overflow: auto;">
              <div class="col-lg-12" style="padding:0px;"> <i class="fa fa-tasks" aria-hidden="true"></i> Question 3 </div>
              <div class="form-row">
                <div class="form-group col-md-8 padding5">
                  <label for="inputCity" style="margin-bottom:8px;">Evaluator comments</label>
                  <textarea class="form-control" id="Textarea1" rows="3" style="resize:none"></textarea>
                </div>
              </div>
            </div>
            <div style="clear:both"></div>
          </div>--%>
          <%--<div class="tab-pane fade" id="Divisionmanager" role="tabpanel" aria-labelledby="Divisionmanager-tab" style="border: 1px solid #dddddd;
border-top: none;
    padding:15px;">
            <div class="col-lg-12" style="padding:1px;">
              <div class="btn btn-hide" onclick="myFunction()" data-toggle="modal" data-target=".bs-example-modal-sm" style="float:right;"> </div>
              <i class="fa fa-object-group" aria-hidden="true"></i> Group 1 </div>
            <div style="clear:both"></div>
            <hr>
            <div class="col-md-12" id="Div7" style="height:auto;background-color:#eaeaea;padding:10px;">
              <div class="col-lg-12" style="padding:0px;"> <i class="fa fa-tasks" aria-hidden="true"></i> Question 1 </div>
              <div class="form-row">
                <div class="form-group col-md-8 padding5">
                  <label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label>
                  <select id="Select2" class="form-control" style="width:50%;">
                    <option selected="">0</option>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                  </select>
                </div>
              </div>
            </div>
            <div style="clear:both"></div>
            <hr />
            <div class="col-md-12" style="height:auto;background-color:#eaeaea;margin-top:4px;padding:10px;overflow: auto;">
              <div class="col-lg-12" style="padding:0px;"> <i class="fa fa-tasks" aria-hidden="true"></i> Question 3 </div>
              <div class="form-row">
                <div class="form-group col-md-8 padding5">
                  <label for="inputCity" style="margin-bottom:8px;">Evaluator comments</label>
                  <textarea class="form-control" id="Textarea2" rows="3" style="resize:none"></textarea>
                </div>
              </div>
            </div>
            <div style="clear:both"></div>
          </div>--%>
          <%--<div class="tab-pane fade" id="GM" role="tabpanel" aria-labelledby="GM-tab" style="border: 1px solid #dddddd;
border-top: none;
    padding:15px;">
            <div class="col-lg-12" style="padding:1px;">
              <div class="btn btn-hide" onclick="myFunction()" data-toggle="modal" data-target=".bs-example-modal-sm" style="float:right;"> </div>
              <i class="fa fa-object-group" aria-hidden="true"></i> Group 1 </div>
            <div style="clear:both"></div>
            <hr>
            <div class="col-md-12" id="Div8" style="height:auto;background-color:#eaeaea;padding:10px;">
              <div class="col-lg-12" style="padding:0px;"> <i class="fa fa-tasks" aria-hidden="true"></i> Question 1 </div>
              <div class="form-row">
                <div class="form-group col-md-8 padding5">
                  <label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label>
                  <select id="Select3" class="form-control" style="width:50%;">
                    <option selected="">0</option>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                  </select>
                </div>
              </div>
            </div>
            <div style="clear:both"></div>
            <hr />
            <div class="col-md-12" style="height:auto;background-color:#eaeaea;margin-top:4px;padding:10px;overflow: auto;">
              <div class="col-lg-12" style="padding:0px;"> <i class="fa fa-tasks" aria-hidden="true"></i> Question 3 </div>
              <div class="form-row">
                <div class="form-group col-md-8 padding5">
                  <label for="inputCity" style="margin-bottom:8px;">Evaluator comments</label>
                  <textarea class="form-control" id="Textarea3" rows="3" style="resize:none"></textarea>
                </div>
              </div>
            </div>
            <div style="clear:both"></div>
          </div>
          <div class="tab-pane fade" id="AdditionalEvaluators" role="tabpanel" aria-labelledby="AdditionalEvaluators-tab" style="border: 1px solid #dddddd;
border-top: none;
    padding:15px;">
            <div class="col-lg-12" style="padding:1px;">
              <div class="btn btn-hide" onclick="myFunction()" data-toggle="modal" data-target=".bs-example-modal-sm" style="float:right;"> </div>
              <i class="fa fa-object-group" aria-hidden="true"></i> Group 1 </div>
            <div style="clear:both"></div>
            <hr>
            <div class="col-md-12" id="Div9" style="height:auto;background-color:#eaeaea;padding:10px;">
              <div class="col-lg-12" style="padding:0px;"> <i class="fa fa-tasks" aria-hidden="true"></i> Question 1 </div>
              <div class="form-row">
                <div class="form-group col-md-8 padding5">
                  <label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label>
                  <select id="Select4" class="form-control" style="width:50%;">
                    <option selected="">0</option>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                  </select>
                </div>
              </div>
            </div>
            <div style="clear:both"></div>
            <hr>
            <div style="clear:both"></div>
            <hr />
            <div class="col-md-12" style="height:auto;background-color:#eaeaea;margin-top:4px;padding:10px;overflow: auto;">
              <div class="col-lg-12" style="padding:0px;"> <i class="fa fa-tasks" aria-hidden="true"></i> Question 3 </div>
              <div class="form-row">
                <div class="form-group col-md-8 padding5">
                  <label for="inputCity" style="margin-bottom:8px;">Evaluator comments</label>
                  <textarea class="form-control" id="Textarea4" rows="3" style="resize:none"></textarea>
                </div>
              </div>
            </div>
            <div style="clear:both"></div>
          </div>
          <div class="tab-pane fade" id="hr" role="tabpanel" aria-labelledby="hr-tab" style="border: 1px solid #dddddd;
border-top: none;
    padding:15px;">
            <div class="col-lg-12" style="padding:1px;">
              <div class="btn btn-hide" onclick="myFunction()" data-toggle="modal" data-target=".bs-example-modal-sm" style="float:right;"> </div>
              <i class="fa fa-object-group" aria-hidden="true"></i> Group 1 </div>
            <div style="clear:both"></div>
            <hr>
            <div class="col-md-12" id="Div10" style="height:auto;background-color:#eaeaea;padding:10px;">
              <div class="col-lg-12" style="padding:0px;"> <i class="fa fa-tasks" aria-hidden="true"></i> Question 1 </div>
              <div class="form-row">
                <div class="form-group col-md-8 padding5">
                  <label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label>
                  <select id="Select5" class="form-control" style="width:50%;">
                    <option selected="">0</option>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                  </select>
                </div>
              </div>
            </div>
            <div style="clear:both"></div>
            <hr>
            <div class="col-md-12" id="Div11" style="height:auto;background-color:#eaeaea;padding:10px;"> </div>
            <div style="clear:both"></div>
            <hr />
            <div class="col-md-12" style="height:auto;background-color:#eaeaea;margin-top:4px;padding:10px;overflow: auto;">
              <div class="col-lg-12" style="padding:0px;"> <i class="fa fa-tasks" aria-hidden="true"></i> Question 3 </div>
              <div class="form-row">
                <div class="form-group col-md-8 padding5">
                  <label for="inputCity" style="margin-bottom:8px;">Evaluator comments</label>
                  <textarea class="form-control" id="Textarea5" rows="3" style="resize:none"></textarea>
                </div>
              </div>
            </div>
            <div style="clear:both"></div>
          </div>--%>
        </div>













      </div>
    </div>
                             <div id="divPrintCaption" runat="server" style="display: none">
       
 </div>
                                <div id="divPrintReport" runat="server" >
        
        </div>

                      
</ContentTemplate>
                           </asp:UpdatePanel>


  </div>
  <div class="clearfix"></div>
</div>










</div>


       





</div>
</div>
      

          
    </div>
                         </article> 

  </div>  

              </section>  </div>    </div>  </div>

         

              <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLongTitle">Modal title</h5>
        
      </div>
      <div class="modal-body">
      <div class="col-md-12" id="Div12" style="height:auto;border:1px solid #868686;padding:10px;">
              <div class="col-lg-12" style="padding:0px;"><b> <i class="fa fa-comments-o" aria-hidden="true"></i> Evaluator comments</b> </div>
              <div class="form-row">
                <div class="form-group col-md-12 padding5">
                
<ul style="list-style-type:square">
  <li><label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label></li>
  <li><label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label></li>
 <li><label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label></li>
  <li><label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label></li>
   <li><label for="inputCity" style="margin-bottom:8px;">Ability to learn new skills and put then into pratice</label></li>
</ul>

  
                </div>
              </div>
            </div>
            <div class="clearfix"></div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>


      </div>
            
      <div style="clear:both"></div>
            <hr>
    
         <script src="../../../../js/loader.js"></script>
       
<script>

    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {


        var EditVal = document.getElementById("<%=HiddenFieldView.ClientID%>").value;

        if (EditVal != "") {




            var find2 = '\\"\\[';
            var re2 = new RegExp(find2, 'g');
            var res2 = EditVal.replace(re2, '\[');

            var find3 = '\\]\\"';
            var re3 = new RegExp(find3, 'g');
            var res3 = res2.replace(re3, '\]');
            //   alert('res3' + res3);
            var json = $noCon.parseJSON(res3);
            for (var key in json) {
                if (json.hasOwnProperty(key)) {
              
                      
                      //  EditGraphRows( json[key].PIEDGRM_ID, json[key].NUMYES, json[key].NUMNO);

                        var data = google.visualization.arrayToDataTable([
                           
         ['Task', 'Hours per Day'],
         ['yes', json[key].NUMYES],
         ['No', json[key].NUMNO],

                        ]);

                        var options = {
                            'width': 400,
                            'height': 300,
                        //    chartArea: {
                        //    width: '40%',
                            //}
                            //'is3D': true,
                        };

                        var chart = new google.visualization.PieChart(document.getElementById('piechart' + json[key].PIEDGRM_ID));
                        //   var chart1 = new google.visualization.PieChart(document.getElementById('piechart1'));

                        chart.draw(data, options);

                      //  var chart1 = new google.visualization.PieChart(document.getElementById('piechartPrint' + json[key].PIEDGRM_ID));
                    //   var chart1 = new google.visualization.PieChart(document.getElementById('piechart1'));

                       // chart1.draw(data, options);


                }
            }


        }

       
      //  chart1.draw(data, options);

    }
    function toggler(divId) {
       
        $("#" + divId).toggle();
        //return false;
    }

    //var $au = jQuery.noConflict();

    //(function ($au) {
    //    $au(function () {

    //        var prm = Sys.WebForms.PageRequestManager.getInstance();
    //        //  prm.add_initializeRequest(InitializeRequest);
    //        prm.add_endRequest(EndRequest);


       

    //        $au('form').submit(function () {

            
    //        });
    //    });
    //})(jQuery);

    //function InitializeRequest(sender, args) {
    //}

    //function EndRequest(sender, args) {
    //    // after update occur on UpdatePanel re-init the Autocomplete
    //    if (document.getElementById("cphMain_HiddenFieldTab").value == "lisum") {
    //        document.getElementById("cphMain_lisum").focus();
    //    }
    //    else if (document.getElementById("cphMain_HiddenFieldTab").value == "liself") {
    //        document.getElementById("cphMain_liself").focus();
    //    }
    //    else if (document.getElementById("cphMain_HiddenFieldTab").value == "lirp") {
    //        document.getElementById("cphMain_lirp").focus();
    //    }
    //    else if (document.getElementById("cphMain_HiddenFieldTab").value == "lidm") {
    //        document.getElementById("cphMain_lidm").focus();
    //    }
    //    else if (document.getElementById("cphMain_HiddenFieldTab").value == "ligm") {
    //        document.getElementById("cphMain_ligm").focus();
    //    }
    //    else if (document.getElementById("cphMain_HiddenFieldTab").value == "lihr") {
    //        document.getElementById("cphMain_lihr").focus();
    //    }
    //    else if (document.getElementById("cphMain_HiddenFieldTab").value == "liadev") {
    //        document.getElementById("cphMain_liadev").focus();
    //    }
    //    else

    //        document.getElementById("cphMain_lisum").focus();
    //}

</script>
   
    <style>

        .hiddenn {
     display:block;
}
        .hiddenncopy {
     display:none;
}
    </style>
</asp:Content>
