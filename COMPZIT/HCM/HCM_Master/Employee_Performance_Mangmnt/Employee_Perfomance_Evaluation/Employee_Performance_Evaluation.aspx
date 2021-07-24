<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" CodeFile="Employee_Performance_Evaluation.aspx.cs" Inherits="HCM_HCM_Master_Employee_Performance_Mangmnt_Employee_Perfomance_Evaluation_Employee_Performance_Evaluation" %>

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



    <script>



        var $noCon1 = jQuery.noConflict();
        $noCon1(window).load(function () {
           
    
          
         
           
        

        });


        var $noCon = jQuery.noConflict();

        function SuccessConductInsident() {

            '<%Session["MESSG_CONDINCDNT"] = "' + null + '"; %>';

            $noCon("#success-alert").html("Employee conduct incident inserted successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        }
        function SuccessUpdate() {

            '<%Session["MESSG_CONDINCDNT"] = "' + null + '"; %>';

            $noCon("#success-alert").html("Employee conduct incident updated successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        }

        function AlertClearAll() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want clear all data in this page?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    window.location.href = "Employee_Performance_Evaluation.aspx";
                }
                else {
                    window.location.href = "Employee_Performance_Evaluation.aspx";
                }
            });
            return false;
        }


    function FocusEvaluation() {
    

        var grpCnt = document.getElementById("<%=hiddenGrpCount.ClientID%>").value



                table = $('#ReportTable_' + 0 + ' > tbody > tr  ');



               //alert(Id);
                MainTable = $('#ReportTable_' + 0 + ' > tbody > tr  ');
                $(MainTable).each(function () {
                    var lgth = MainTable.length;
                    //  alert(lgth);
                    var RowId = $(this).attr('id');
                    // alert(RowId);
                    var tdval = $(this).attr('value');
                    var globalFileTypeId = tdval.split(',');
                    var id1 = globalFileTypeId[0];
                    var id2 = globalFileTypeId[1];
                    var id3 = globalFileTypeId[2];
                    var id4 = globalFileTypeId[3];
                    // alert(id1); alert(id2); alert(id3);

                    if (id3 == 2) {
                        // alert($('#txtComment_' + x + ":" + id1).val());

                        document.getElementById("txtComment_" + id4 + ":" + id1).focus();

                  
                        return false;
                      
                    }



                    else if (id3 == 3) {


                        document.getElementById("checkYes_" + id4 + ":" + id1).focus();

                        return false;

                    }
                    else if (id3 == 1) {


                        document.getElementById("checkYes_" + id4 + ":" + id1).focus();

                        return false;

                    }






                });


                

    }
      
        function ConfirmError() {



            $noCon("#divWarning").html("Performance evaluation already confirmed.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#divWarning").alert();

            return false;
        }
        function ConfirmEvaluvation() {
         
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to confirm this evaluation?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=bbtnConfirm.ClientID%>").click();


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

            if (confirmbox > 1) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "Employee_Perfomance_Evaluation_List.aspx";
                    }

                    else {
                       // window.location.href = "hcm_Emp_Conduct_Incident_List.aspx";
                        return false;
                    }
                });
            }
            else {
                window.location.href = "Employee_Perfomance_Evaluation_List.aspx";
                return false;
            }
            return false;

        }

 
    var confirmbox = 0;

    function IncrmntConfrmCounter() {
        confirmbox++;
    }
   

    function validateEvaluation() {
        var ret = true;
       
        var grpCnt = document.getElementById("<%=hiddenGrpCount.ClientID%>").value
     
        if (document.getElementById("<%=hiddenGoalsts.ClientID%>").value == "1") {
            document.getElementById("cphMain_txtGoal").style.borderColor = "";
            var goal = document.getElementById("<%=txtGoal.ClientID%>").value.trim();
            if (goal == "") {
                document.getElementById("<%=txtGoal.ClientID%>").style.borderColor = "Red";
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $noCon1(window).scrollTop(0);
                ret = false;
            }
            else {
                document.getElementById("<%=txtGoal.ClientID%>").style.borderColor = "none";
            }
        }



        for (var x = 0; x < grpCnt; x++) {
            table = $('#ReportTable_' + x + ' > tbody > tr  ');
          
              

               // alert(Id);
            MainTable = $('#ReportTable_'+ x+' > tbody > tr  ');
            $(MainTable).each(function () {
                var lgth = MainTable.length;
              //  alert(lgth);
                var RowId = $(this).attr('id');
               // alert(RowId);
                var tdval = $(this).attr('value');
                var globalFileTypeId = tdval.split(',');
                var id1 = globalFileTypeId[0];
                var id2 = globalFileTypeId[1];
                var id3 = globalFileTypeId[2];
                var id4 = globalFileTypeId[3];
               // alert(id1); alert(id2); alert(id3);
               
               
          
               
                    if (id3 == 2) {
                       // alert($('#txtComment_' + x + ":" + id1).val());
                        if (document.getElementById("txtComment_" + id4 + ":" + id1).value.trim() == "") {

                            document.getElementById("txtComment_" + id4 + ":" + id1).style.borderColor = "Red";
                            $('txtComment_' + id4 + ":" + id1).css('border-color', 'red');
                            $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            $noCon1(window).scrollTop(0);
                            ret = false;

                        }
                        else {
                            document.getElementById("txtComment_" + id4 + ":" + id1).style.borderColor = "";
                        }
                    }

                    if (id3 == 3) {

                        if (document.getElementById("checkYes_" + id4 + ":" + id1).checked == false && document.getElementById("CheckNo_" + id4 + ":" + id1).checked == false) {

                            document.getElementById("checkYes_" + id4 + ":" + id1).style.outline = "1px solid #F4F6FB;";
                            document.getElementById("CheckNo_" + id4 + ":" + id1).style.outline = "1px solid #F4F6FB;";
                            //  $('txtComment_' + id4 + ":" + id1).css('border-color', 'red');
                            $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            $noCon1(window).scrollTop(0);
                            ret = false;

                        }
                        else {
                            document.getElementById("checkYes_" + id4 + ":" + id1).style.outline = "";
                            document.getElementById("CheckNo_" + id4 + ":" + id1).style.outline = "";
                        }
                    }
                  
               
            });
           
        }
        return ret;

    }

    
    function ChangeddlRate(x, y) {
        IncrmntConfrmCounter();
        var ddratechg = document.getElementById("ddlRate_" + x + ":" + y).value;

        //  document.getElementById("txtddlValue_" + x + ":" +y).value = ddratechg;
       // document.getElementById("<%=HiddenRate.ClientID%>").value = ddratechg
        document.getElementById("txtddlValue_" + x + ":" + y).value = ddratechg;
       // alert(document.getElementById("txtddlValue_" + x + ":" + y).value);
       // $('#txtddlValue_' + x + ":" + y).val() = ddratechg;
        return false;
    }
        function ChangeChkSts(x, y) {

          
           // var ddratechg = document.getElementById("ddlRate_" + x + ":" + y).value;
            var chksts = 0;
            if (document.getElementById("checkYes_" + x + ":" + y).checked == true) {

                chksts = 1;
               //document.getElementById("CheckNo_" + x + ":" + y).checked = false;
            }
            if (document.getElementById("CheckNo_" + x + ":" + y).checked == true) {

                chksts = 0;
         //   document.getElementById("checkYes_" + x + ":" + y).checked = false;
            }
           // document.getElementById("CheckNo_" + x + ":" + y).checked = false;
            //document.getElementById("checkYes_" + x + ":" + y).checked = false;
            document.getElementById("txtchkValue_" + x + ":" + y).value = chksts;
           // alert(document.getElementById("txtchkValue_" + x + ":" + y).value);




             return false;
         }

        function isTagEnter(evt) {
      
           
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62 ) {
                ret = false;
            }
            return ret;
        }
        function textCounter(field, maxlimit) {

         
        //   alert(field.value.length);
            if (field.value.length > maxlimit) {

                field.value = field.value.substring(0, maxlimit);
            }

            else {

            }
            var txt = field.value;
            var replaceText1 = txt.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            field.value = replaceText2;



        }
        function BlurTextvalue(count) {
         //   alert(count);

            var NameWithoutReplace = document.getElementById("txtComment_" + count).value.trim();
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("txtComment_" + count).value = replaceText2;

          
        }
        </script>
       <script>

           $(function () {
           $('input[type=checkbox]').on('click', function () {
             //  alert();
               // in the handler, 'this' refers to the box clicked on
               var $box = $(this);
               if ($box.is(":checked")) {
                   // the name of the box is retrieved using the .attr() method
                   // as it is assumed and expected to be immutable
                   var group = "input:checkbox[name='" + $box.attr("name") + "']";
                   // the checked state of the group/box on the other hand will change
                   // and the current value is retrieved using .prop() method
                   $(group).prop("checked", false);
                   $box.prop("checked", true);
               } else {
                   $box.prop("checked", false);
               }
           });
           });
    </script>
      
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
            <asp:HiddenField ID="hiddenupd" runat="server" />
     <asp:HiddenField ID="HiddenFieldQryString" runat="server" />
     <asp:HiddenField ID="HiddenAllUserDivision" runat="server" />
      <asp:HiddenField ID="HiddenRate" runat="server" />
     <asp:HiddenField ID="HiddenEmailAddress" runat="server" />
      <asp:HiddenField ID="HiddenUserId" runat="server" />
    <asp:HiddenField ID="hiddenGrpId" runat="server" />
    <asp:HiddenField ID="hiddenGrpCount" runat="server" />
       <asp:HiddenField ID="HiddenQstnCount" runat="server" />
           <asp:HiddenField ID="HiddenIssueId" runat="server" />
     <asp:HiddenField ID="HiddenRespnsTyp" runat="server" /> 
     <asp:HiddenField ID="HiddenTypId" runat="server" /> 
           <asp:HiddenField ID="hiddenGoalsts" runat="server" />
        <asp:HiddenField ID="hiddenGrpCanclDtlId" runat="server" />
        <asp:HiddenField ID="HiddenEvltnId" runat="server" />
        <asp:HiddenField ID="HiddenView" runat="server" />
   <asp:HiddenField ID="HiddencnfrmSts" runat="server" />
     <asp:HiddenField ID="hidddenTemplateId" runat="server" />
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


        <div id="divReportCaption" runat="server" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <img src="/Images/BigIcons/Job_Delegation.png" style="vertical-align: middle;" />
     <asp:Label ID="lblEntry" runat="server" Text="Performance Evaluation"></asp:Label>
        </div >
      
        <div  id="divList"  class="list" runat="server" style="position: fixed; right: 2%; top: 42%; height: 26.5px;z-index: 90;" onclick="return ConfirmMessage()">

           
        </div>

                            <br>

  <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: #f6f6f6; float: left">
       
    <div class="auto1">
<div class="cont_rght" style="width:100%">
    <div class="sect250">
        <div class="row">
          <div class="container" style="padding-top:18px;padding-bottom: 33px;">
          
      
      <div class="col-md-12" style="padding:9px;margin-top:-15px;">
          <div class="col-md-8 col-sm-8" style="width: 100%; text-align: center; font-family: calibri; font-size: 16px; font-weight: bold;">
             <asp:Label ID="lblTyp" runat="server"  style="padding:0;"></asp:Label>
        <%--<asp:Label ID="lblTmpltNName" runat="server"  style="font-weight: 700; margin-bottom: 3%;float: left;  "></asp:Label>--%>
     <%-- <label class="col-md-8" style="padding:0;float: left;" > F 120</label>--%>
      </div>
<div style="float:right;">
<%--<button class="btn btn-primary btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-save" style="margin-right:10px;"></i>Submit</button>
<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-check " style="margin-right:10px;"></i>Confirm</button>
<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-refresh " style="margin-right:10px;"></i>Clear</button>
<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-remove" style="margin-right:10px;"></i>Cancel</button>--%>
</div>
</div>
               
   <div style="clear:both"></div>     

<div class="container" style="padding: 0px; width: 99%; float: left; margin-left: 0px; border: 0px solid; font-family: calibri; background-color: rgb(227, 228, 224); font-size: 14px;">
    



    <div class="row" style="margin-top:6px;">
  <div class="col-md-4" style="margin-left: 2%; width: 33%; float: left;"> 
 <form>
    <div class="form-group">
       
      <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 15px; font-family: calibri ! important; font-style: normal;font-weight: bold;"> Performance Form</label>
      <div class="col-md-8 col-sm-8">
            <asp:Label ID="lblTmpltNName" runat="server" class="col-md-8" style="padding:0;"></asp:Label>
        <%--<asp:Label ID="lblTmpltNName" runat="server"  style="font-weight: 700; margin-bottom: 3%;float: left;  "></asp:Label>--%>
     <%-- <label class="col-md-8" style="padding:0;float: left;" > F 120</label>--%>
      </div>
    </div>
      </div>

    

</div>


 <%--<h4 class="bold_text" style="font-weight:700;margin-bottom: 3%"> Performance review for renewal of employee contract</h4> 
 --%>
<div class="row" style="margin-top:6px;">
  <div class="col-md-4" style="margin-left: 2%; width: 32%; float: left;"> 
 <form>
    <div class="form-group">
       
      <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 15px; font-family: calibri ! important; font-style: normal;font-weight: bold;"> Reference No.</label>  <%--emp0025--%>
      <div class="col-md-8 col-sm-8">
           <asp:Label ID="lblRef" runat="server" class="col-md-8" style="padding:0;"></asp:Label>
     <%-- <label class="col-md-8" style="padding:0;float: left;" > F 120</label>--%>
      </div>
    </div>
      </div>
<div class="col-md-4" style="float: left; margin-left: 2%; width: 32%; display:none"> 
    <div class="form-group">
      <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 15px; font-family: calibri ! important; font-style: normal;font-weight: bold;">Rev No</label>
      <div class="col-md-8 col-sm-8">
               <asp:Label ID="lblRevNo" runat="server" class="col-md-8" style="padding:0;"></asp:Label>
      <%--<label class="col-md-8 " style="padding:0;">6</label>--%>
      </div>
    </div>
</div>
    

<div class="col-md-4" style="width: 30%; float: right;"> 
    <div class="form-group">
      <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 15px; font-family: calibri ! important; font-style: normal;font-weight: bold;">Issued Date</label>
      <div class="col-md-8 col-sm-8">
               <asp:Label ID="lblDate" runat="server" class="col-md-8" style="padding:0;"></asp:Label>
      
     <%-- <label class="col-md-8" style="padding:0;">22.03.2018</label>--%>
      </div>
    </div>
</div>
</div>

<div class="row" style="margin-top:6px;">
  <div class="col-md-4" style="width: 32%; float: left; margin-left: 2%;"> 
 <form>
    <div class="form-group">
      <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 15px; font-family: calibri ! important; font-style: normal;font-weight: bold;">Employee Code </label>  <%--emp0025--%>
      <div class="col-md-8 col-sm-8">
               <asp:Label ID="lblEmpId" runat="server" class="col-md-8" style="padding:0;"></asp:Label>

   <%--   <label class="col-md-8" style="padding:0;">EMP-5632</label>--%>
      </div>
    </div>
      </div>
<div class="col-md-4" style="float: left; margin-left: 2%; width: 32%;"> 
    <div class="form-group">
      <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 15px; font-family: calibri ! important; font-style: normal;font-weight: bold;">Employee</label>
      <div class="col-md-8 col-sm-8">
               <asp:Label ID="lblEmpName" runat="server" class="col-md-8" style="padding:0;"></asp:Label>

   <%--   <label class="col-md-8" style="padding:0;">Akhil</label>--%>
      </div>
    </div>
</div>
    

<div class="col-md-4" style="width: 30%; float: right;"> 
    <div class="form-group">
      <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 15px; font-family: calibri ! important; font-style: normal;font-weight: bold;">Designation</label>
      <div class="col-md-8 col-sm-8">
               <asp:Label ID="lblDesg" runat="server" class="col-md-8" style="padding:0;"></asp:Label>

    <%--  <label class="col-md-8" style="padding:0;">Project consultant</label>--%>
      </div>
    </div>
</div>
</div>

<div class="row" style="margin-top:6px;">
  <div class="col-md-4" style="width: 31%; float: left; margin-left: 2%;"> 
 <form>
    <div class="form-group">
      <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 15px; font-family: calibri ! important; font-style: normal;font-weight: bold;">Department</label>
      <div class="col-md-8 col-sm-8">
               <asp:Label ID="lblDept" runat="server" class="col-md-8" style="padding:0;"></asp:Label>

    <%--  <label class="col-md-8" style="padding:0;">Project consultant</label>--%>
      </div>
    </div>
      </div>
<div class="col-md-4" style="float: left; margin-left: 3%;width:30%;"> 
    <div class="form-group">
      <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 15px; font-family: calibri ! important; font-style: normal;font-weight: bold; width: 11%;">Job</label>
      <div class="col-md-8 col-sm-8" style="float: right; width: 58%; margin-left: 10%; margin-right: 6%;">
               <asp:Label ID="lblJob" runat="server" class="col-md-8" style="padding:0;"></asp:Label>

    <%--  <label class="col-md-8" style="padding:0;">Project consultant</label>--%>
      </div>
    </div>
</div>
    

<div class="col-md-4" style="width: 30%; float: right;width:30%;"> 
    <div class="form-group">
      <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 15px; font-family: calibri ! important; font-style: normal;font-weight: bold;">Date of Joining</label>
      <div class="col-md-8 col-sm-8">
        <asp:Label ID="lblJoinDate" runat="server" class="col-md-8" style="padding:0;"></asp:Label>

      </div>
    </div>
</div>
</div>

<div class="row" style="margin-top:6px;">
  <div class="col-md-4" style="float: left; margin-left: 2%; width: 73%;"> 
 <form>
    <div class="form-group">
      <label class="col-md-4 col-sm-4" style="padding: 0px; float: left; font-size: 15px; font-family: calibri ! important; font-style: normal;font-weight: bold; width: 13.5%;">Notes/Instruction</label>
      <div class="col-md-8 col-sm-8" style="width: 56%;">
                    <asp:Label ID="lblNote" runat="server" class="col-md-8" style="padding:0;word-break: break-all;"></asp:Label>

      </div>
    </div>
      </div>
</div>
</form> 
</div> 
 <div class="container-fluid" id="group1" runat="server" style="height:auto;border:1px solid #7c8272;padding:10px;margin-top:45px;width: 99%;
float: left;">
 

    </div>
    <div class="form-row" style="margin-top:16px;">
   <div id="divGoal" runat="server" class="form-group col-md-7 padding5" style=" margin-top: 10px;">
      <label for="inputCity" style="margin-left: 6px;">Goal</label>
       <asp:TextBox ID="txtGoal" TextMode="MultiLine" runat="server" CssClass="form-control" rows="3" style="resize:none" onkeypress="return isTagEnter(event);"  onkeydown="textCounter(cphMain_txtGoal,230)" onkeyup="textCounter(cphMain_txtGoal,230)"   onblur="textCounter(cphMain_txtGoal,230)"></asp:TextBox>
  <%--   <textarea class="form-control" id="Textarea1" rows="3" style="resize:none"></textarea>--%>
    </div>

<div class="col-md-5" style="padding:9px;margin-top:26px;">
<div style="float:right;">
<asp:Button ID="btnSave"  runat="server" class="btn btn-primary btn-grey  btn-width" Text="Save"  OnClientClick="return validateEvaluation();"    OnClick="btnSave_Click"  />     
<asp:Button ID="btnUpdate"  runat="server" class="btn btn-primary btn-grey  btn-width" Text="Update"   OnClick="btnUpdate_Click" OnClientClick="return validateEvaluation();"  />     
<asp:Button ID="btnConfirm"  runat="server" class="btn btn-primary btn-grey  btn-width" Text="Confirm" OnClientClick="return ConfirmEvaluvation(); "   OnClick="btnUpdate_Click"  />
<asp:Button ID="btncancel"  runat="server" class="btn btn-primary btn-grey  btn-width" Text="Cancel"    OnClientClick=" return ConfirmMessage();" />    
          <asp:Button ID="bbtnConfirm" runat="server" Text="Button" style="display:none;" OnClick="btnUpdate_Click" OnClientClick="return validateEvaluation();" />
 <%-- <button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;" onclick="btnSave_Click();"><i class="fa fa-check " style="margin-right:10px;"></i>Confirm</button>--%>
<%--<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-refresh " style="margin-right:10px;"></i>Clear</button>--%>
<%--<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;" onclick="return ConfirmMessage();"><i class="fa fa-remove" style="margin-right:10px;"></i>Cancel</button>--%>
</div></div>
</div>
</div>
     </div>
    </div>
</div>
</div>
      

          
    </div>

  </div>  </article>  </div>  </section>  </div>  </div>





  

            <br />
  
    <style>

        


/*.datepicker table tr td.old{
    color:red;
}*/


    </style>
       <style type="text/css">
        /*.ui-autocomplete {
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
                }*/
    </style>
  <%--  <script src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>--%>
  <%--  <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />--%>

    <script>


        function myFunction() {

            $("#yesbtn").click(function () { $("#group1").hide(); });

        }
        function closebox() {
            $("#boxhide").hide();
        }

       

    
       

       </script>



    <script>
        //  var $noConn = jQuery.noConflict();
     



     




        // checks every field in row
     

             

         

       </script>

    
      

</asp:Content>
