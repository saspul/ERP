<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Emp_Conduct.aspx.cs" Inherits="HCM_HCM_Master_hcm_Emp_Conduct_hcm_Emp_Conduct" %>

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

    <link href="../../../../css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="../../../../js/jQueryUI/jquery-ui.min.js"></script>
    <script src="../../../../js/jQueryUI/jquery-ui.js"></script>
    <script src="../../../../js/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../../js/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="/js/HCM/Common.js"></script>

    <script>


        $(document).ready(function () {

            $('#check-show').change(function () {
                if ($(this).is(":checked")) {
                    $('#showdiv').slideDown();
                }
                else {
                    $('#showdiv').slideUp(300);
                }

            });
        });

        
        var $noCon1 = jQuery.noConflict();
        $noCon1(window).load(function () {
           
            if (document.getElementById("<%=cbxResive.ClientID%>").checked == true || document.getElementById("<%=hiddenStatus.ClientID%>").value == "1") {
                if (document.getElementById("<%=HiddenMemo.ClientID%>").value == 1) {
                    document.getElementById('cphMain_txtreplay').style.display = "block";
                    document.getElementById('cphMain_MessageHead').style.display = "block";
                    document.getElementById('cphMain_btnSavenCls').style.visibility = "visible";
                    document.getElementById('cphMain_btnSave').style.visibility = "visible";
                }

            }
            else {
                document.getElementById('cphMain_txtreplay').style.display = "none";
                document.getElementById('cphMain_MessageHead').style.display = "none";
                document.getElementById('cphMain_btnSavenCls').style.visibility = "hidden";
                document.getElementById('cphMain_btnSave').style.visibility = "hidden";
            }
            
            var SuccessMsg = '<%=Session["MESSG_CONDINCDNT"]%>';
            if (SuccessMsg == "TERMNTN_UNDER_PRSS") {
                ValidateNotTerminate();
            }
            else if (SuccessMsg == "TERMINATED") {
                ValidateTerminated();
            }
            else if (SuccessMsg == "CLOSED") {
                ValidateNotClose();
            }

            
        });
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
        var $noCon = jQuery.noConflict();
        function ConfirmMessage() {

     

            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to leave this page?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    window.location.href = "hcm_Emp_Conduct_List.aspx";
                }

                else {
              
                    return false;
                }
            });
            return false;

        }
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        function checkStatus() {
           
            if (document.getElementById("<%=cbxResive.ClientID%>").checked == true || document.getElementById("<%=hiddenStatus.ClientID%>").value == "1"  ) {
                if (document.getElementById("<%=HiddenMemo.ClientID%>").value == "1") {

                    document.getElementById('cphMain_txtreplay').style.display = "block";
                    document.getElementById('cphMain_MessageHead').style.display = "block";
                    document.getElementById('cphMain_btnSavenCls').style.visibility = "visible";
                    document.getElementById('cphMain_btnSave').style.visibility = "visible";
                }

                }
                else {
                document.getElementById('cphMain_txtreplay').style.display = "none";
                document.getElementById('cphMain_MessageHead').style.display = "none";
                    document.getElementById('cphMain_btnSavenCls').style.visibility = "hidden";
                    document.getElementById('cphMain_btnSave').style.visibility = "hidden";
            }

            if (document.getElementById("<%=HiddenMemo.ClientID%>").value == "0") {
                document.getElementById('cphMain_btnSavenCls').style.visibility = "visible";
                document.getElementById('cphMain_btnSave').style.visibility = "visible";

            }

            }
       
        function validate() {
            var ret = true;

            if (document.getElementById("<%=cbxResive.ClientID%>").checked == true && document.getElementById("<%=hiddenStatus.ClientID%>").value == "1") {
                if (document.getElementById("<%=txtreplay.ClientID%>").value == "" && document.getElementById("<%=HiddenMemo.ClientID%>").value == "1") {
                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    $noCon("#divWarning").alert();
                    document.getElementById("<%=txtreplay.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtreplay.ClientID%>").focus();
                    return false;

                }

            }
            return ret;
        }
        </script>
       <script type="text/javascript">
           var $noCon = jQuery.noConflict();
           function ConductSuccessInsertion() {
               $noCon("#success-alert").html("Message send  successfully.");
               $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
               });
               $noCon("#success-alert").alert();

               return false;

           }

           function SuccessCancelMsg() {
               $noCon("#success-alert").html("Incident message removed successfully.");
               $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
               });
               $noCon("#success-alert").alert();
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
                           var UsrId = '<%=Session["USERID"]%>';
                           
                         var strId=  document.getElementById("<%=HiddenFieldQryString.ClientID%>").value;
                           var Details = PageMethods.CancelMessage(IncidentSubID,strId,UsrId, function (response) {
                               var SucessDetails = response;
                               document.getElementById('cphMain_divList').innerHTML = response[0];
                               if (response[1] == "T") {
                                   document.getElementById('cphMain_divMsg').style.display = "block";
                               }
                               else {
                                   document.getElementById('cphMain_divMsg').style.display = "none";
                               }
                               if (response[2] == "TERMNTN_UNDER_PRSS") {
                                   ValidateNotTerminate();
                               }
                               else if (response[2] == "TERMINATED") {
                                   ValidateTerminated();
                               }
                               else if (response[2] == "CLOSED") {
                                   ValidateNotClose();
                               }
                               else {
                                   SuccessCancelMsg();
                               }
                           });
                       }
                   });
                   return false;
               }
           }

        
       </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
          <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
            <asp:HiddenField ID="hiddenupd" runat="server" />
     <asp:HiddenField ID="HiddenFieldQryString" runat="server" />
     <asp:HiddenField ID="HiddenAllUserDivision" runat="server" />
    <asp:HiddenField ID="hiddenStatus" runat="server" />
     <asp:HiddenField ID="HiddenMemo" runat="server" />
    
      <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

     <div id="main" role="main">
      
        <div class="cont_rght" >

                    <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button> 
        </div>
              <div class="alert alert-danger" id="divWarning" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>
            <section id="widget-grid" class="">

                <div class="row">
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <div class="" id="wid-id-0">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
             
  Employee Conduct
        </div >
      
       
        <div  id="div1"  class="list" runat="server" style="position: fixed; right: 2%; top: 42%; height: 26.5px;z-index: 90;" onclick="return ConfirmMessage()">

           
        </div>
                            <br>

  <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: #f6f6f6; float: left">
       
  <div class="container-fluid" style="background-color:#f3f3f3;padding-top:40px;padding-bottom:33px;">
<div class="col-sm-6 col-md-6 ">

<div class="form-group row">
  <label for="staticEmail" class="col-sm-3 col-form-label font-sty">Employee</label>
  <div class="col-sm-8">
    <div class="panel" style="margin:0;padding:7px;    background-color: #bfc3b7;
    color: white;"><asp:Label ID="lblEmpName" runat="server"></asp:Label></div> 
  </div>
</div>
</div>
<div class="col-sm-6 col-md-6 ">
  <div class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label font-sty">Type</label>
    <div class="col-sm-8">
     <div class="panel" style="margin:0;padding:7px;    background-color:#bfc3b7;
    color: white;"><asp:Label ID="lblType" runat="server"></asp:Label></div> 
    
    </div>
  </div>
</div>
<div class="col-sm-6 col-md-6 ">
  <div class="form-group row">
    <label for="inputPassword" class="col-sm-3 col-form-label font-sty">Description</label>
    <div class="col-sm-8">
          <div class="panel" style="margin:0;padding:7px;    background-color:#bfc3b7;
    color: white;"><asp:Label ID="lblDescription" runat="server" style="word-wrap: break-word;"></asp:Label></div>

    </div>
  </div>
</div>
<div class="col-sm-6 col-md-6 ">
  <div class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label font-sty">Priority</label>
    <div class="col-sm-8">
       <div class="panel" style="margin:0;padding:7px;    background-color:#bfc3b7;
    color: white;"><asp:Label ID="lblPriority" runat="server"></asp:Label></div> 
    </div>
  </div>
</div>
<div class="col-sm-6 col-md-6 ">
  <div class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label font-sty">Incident Date</label>
    <div class="col-sm-8">
   <div class="panel" style="margin:0;padding:7px;    background-color:#bfc3b7;
    color: white;"><asp:Label ID="lblDate" runat="server"></asp:Label></div> 
    </div>
  </div>
</div>

<div id="divSts" runat="server" class="col-sm-6 col-md-6 ">
  <div class="form-group row">
    <label for="inputPassword" class="col-sm-3 col-form-label font-sty">Status<span style="color:#F00">*</span></label>
    <div class="col-sm-8">
      <label class="ch">Recieved
         <asp:CheckBox ID="cbxResive" runat="server" onchange="checkStatus(); " />
      <%--<input type="checkbox">--%>
        <span class="checkmark"></span> </label>
    </div>
  </div>
</div>


<div id="showdiv" runat="server"  class ="col-lg-12 col-md-12 col-sm-12"  style="background-color:rgb(228, 228, 228);height:auto;padding-top:20px;padding-bottom:20px;" >
<div class="col-sm-6 col-md-6 ">

<div class="form-group row">
  <label for="staticEmail" class="col-sm-3 col-form-label font-sty">From</label>
  <div class="col-sm-8">
       <asp:TextBox ID="txtEmpname" class="form-control" runat="server"></asp:TextBox>
   
  </div>
</div>
</div>

<div style="clear:both"></div>
<div class="col-sm-6 col-md-6 ">
  <div class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label font-sty">Issue Date</label>
    <div class="col-sm-8">
          <asp:TextBox ID="txtDate" class="form-control" runat="server"></asp:TextBox>
       
    </div>
  </div>
</div>
<div class="col-sm-6 col-md-6 ">
  <div class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label font-sty">Reason</label>
    <div class="col-sm-8">
          <asp:TextBox ID="txtReason" class="form-control" runat="server"></asp:TextBox>
       
    </div>
  </div>
</div>
<div class="col-sm-6 col-md-6 ">
  <div class="form-group row">
    <label for="inputPassword" class="col-sm-3 col-form-label font-sty">Description</label>
    <div class="col-sm-8">
        <asp:TextBox id="txtMemoDesc" runat="server"  TextMode="MultiLine" class="form-control"  style="height:60px;resize:none;" rows="3"></asp:TextBox>
     <%-- <textarea  runat="server" class="form-control" id="txtMemoDesc" style="height:60px;resize:none;" rows="3"></textarea>--%>
    </div>
  </div>
</div> 
    <div id="divMsg" runat="server" style="display:block">
<div class="panel col-xs-12 font-sty" style="clear:both;background-color:transparent;font-weight: bold;font-family:Calibri">Conversation</div>
<div class="col-lg-12 col-md-12 col-sm-12"  style="background-color: #FFFFFF;height: auto; max-height:230px;overflow: auto;padding-top: 20px;padding-bottom: 20px;
    padding-left: 3px;
    padding-right: 3px;">
   

    
     <div  id="divList"  runat="server">

           
        </div>


   
  </div>
    </div>
  </div>
 <div class="col-sm-12 col-md-12 padding-0">
  <div class="form-group row" style="padding-top:20px;">
    <div class="col-sm-6">
         <div id="MessageHead" runat="server" class="panel col-xs-12 font-sty" style="clear:both;background-color:transparent;font-weight: bold;font-family:Calibri;display:none">Message</div>
          <asp:TextBox ID="txtreplay" class="form-control" runat="server" TextMode="MultiLine" placeholder="Type message here..." style="height: 60px;resize:none;display:none; "  onkeydown="textCounter(cphMain_txtreplay,1500)" onkeyup="textCounter(cphMain_txtreplay,1500)"></asp:TextBox>
   
    </div>
    <div class="col-sm-12 col-md-12 padding-0" style="margin-top:20px;">
 <div class="col-md-6 col-sm-12" style="float:right;">
 <span style="float:right; width: 43%;">
       <asp:Button ID="btnSave" runat="server"  class="btn btn-info" Text="Save" style="visibility:hidden;" OnClick="btnSave_Click" OnClientClick=" return validate();"/>
     <asp:Button ID="btnSavenCls" runat="server" class="btn btn-info" Text="Save&Close " style="visibility:hidden;"  OnClick="btnSave_Click" OnClientClick=" return validate();"/>
    <%-- <asp:Button ID="btnSavenConfirm" runat="server" class="btn btn-success" Text="Save&Confirm "/>--%>
     <asp:Button ID="btnCncl" runat="server" class="btn btn-info" Text="Cancel " OnClientClick="return ConfirmMessage();"/>

   </span> 
    </div>
</div>
  </div>

 </div> 
</div>

</div>
      

          
    </div>

  </div>    </div>    </div>  
  

</asp:Content>
