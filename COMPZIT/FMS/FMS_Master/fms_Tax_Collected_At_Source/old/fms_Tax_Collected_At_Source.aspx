<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzitFinance.master" AutoEventWireup="true" CodeFile="fms_Tax_Collected_At_Source.aspx.cs" Inherits="FMS_fms_Tax_Collected_At_Source_fms_Tax_Collected_At_Source" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

      <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>

    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/bootstrap.min.css" rel="stylesheet" />

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
    <script type="text/javascript">
        var $noCon1 = jQuery.noConflict();
        $noCon1(window).load(function () {
            if (document.getElementById("<%=Hiddentxtefctvedate.ClientID%>").value != "") {
                insertFromDate()
            }
            if (document.getElementById("<%=HiddentxtefctveTodate.ClientID%>").value != "") {
                insertToDate()
            }


        });
        function check($char, obj) {
            if (obj.value > 100.0) {
                return false;
            }
            if ($char == 60 || $char == 62 || $char == 13) {
                return false;
            }
            //  alert($char);
            if ($char >= 65 && $char <= 90) {
                return false;
            }
            if (obj.value.length == 0 || obj.value.length == 1) {
                if (($char >= 48 && $char <= 57) || ($char >= 96 && $char <= 105) || $char == 190 || $char == 8 || $char == 9 || $char == 46 || $char == 13 || $char == 9 || $char == 35 || $char == 36 || $char == 37 || $char == 39 || $char == 110) {
                    return true;
                }
            }
            else if (obj.value.length == 2) {
                if ((obj.value > 10) && ($char == 110 || $char == 190 || $char == 46 || $char == 8 || $char == 9 || $char == 37 || $char == 39 || $char == 35 || $char == 36)) {
                    return true;
                }
                else if ((obj.value == 10) && ($char == 48 || $char == 96 || $char == 110 || $char == 190 || $char == 46 || $char == 8 || $char == 9 || $char == 37 || $char == 39 || $char == 35 || $char == 36)) {
                    return true;
                }
                else if ((obj.value < 10) && (($char >= 48 && $char <= 57) || ($char >= 96 && $char <= 105) || $char == 190 || $char == 8 || $char == 9 || $char == 46 || $char == 13 || $char == 9 || $char == 35 || $char == 36 || $char == 37 || $char == 39 || $char == 110)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else if (obj.value.length == 3) {
                if ((obj.value == 100) && ($char == 110 || $char == 190 || $char == 46 || $char == 8 || $char == 37 || $char == 39 || $char == 35 || $char == 36)) {
                    return true;
                }
                else if ((obj.value.indexOf(".") != -1) && (($char >= 48 && $char <= 57) || ($char >= 96 && $char <= 105) || $char == 190 || $char == 8 || $char == 9 || $char == 46 || $char == 13 || $char == 9 || $char == 35 || $char == 36 || $char == 37 || $char == 39 || $char == 110)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else if (obj.value.length == 4) {
                if ((obj.value.indexOf(".") != -1) && (($char >= 48 && $char <= 57) || ($char >= 96 && $char <= 105) || $char == 190 || $char == 8 || $char == 9 || $char == 46 || $char == 13 || $char == 9 || $char == 35 || $char == 36 || $char == 37 || $char == 39 || $char == 110)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else if (($char == 46 || $char == 8 || $char == 9 || $char == 37 || $char == 39 || $char == 35 || $char == 36)) {
                return true;
            }
            else {
                return false;
            }
        }
        function AmountChecking(textboxid) {

            var txtPerVal = document.getElementById(textboxid).value;

            txtPerVal = txtPerVal.replace(/,/g, "");



            if (txtPerVal == "") {
                return false;
            }
            else {
                if (!isNaN(txtPerVal) == false) {
                    document.getElementById('' + textboxid + '').value = "";
                    return false;
                }
                else {
                    if (txtPerVal < 0) {
                        document.getElementById('' + textboxid + '').value = "";
                        return false;
                    }
                    var amt = parseFloat(txtPerVal);
                    var num = amt;
                    var n = 0;
                    // for floatting number adjustment from corp global
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        n = num.toFixed(FloatingValue);
                    }
                    else {
                        n = num;
                    }

                    document.getElementById(textboxid).style.borderColor = "";
                    document.getElementById('' + textboxid + '').value = n;

                    if (document.getElementById(textboxid).value != "") {
                        var NameWithoutReplace = document.getElementById(textboxid).value;
                        document.getElementById(textboxid).value = NameWithoutReplace.replace(/,/g, "");


                        var amtrnge1 = document.getElementById(textboxid).value;


                        if (100 < parseFloat(amtrnge1)) {

                            document.getElementById(textboxid).style.borderColor = "red";
                            document.getElementById(textboxid).value = "";
                            $noCon(window).scrollTop(0);
                            $noCon("#divWarning").html("Deductive percentage should  be less than hundered.");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                //  document.getElementById(textboxid).focus();

                            });

                            $noCon("#divWarning").alert();

                        }

                    }


                }
            }



              // alert("55");
            return true;
        }
        function ValidateTcs() {
            var ret = true;
            var flag = 0;
            var name = document.getElementById("<%=txtName.ClientID%>").value.trim();
            var prcntg = document.getElementById("<%=txtCltvPercng.ClientID%>").value.trim();
               var frmDate = document.getElementById("<%=txtDateFrom.ClientID%>").value.trim();
               var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value.trim();
               document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";
               document.getElementById("<%=txtCltvPercng.ClientID%>").style.borderColor = "";
               document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";
               document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";
            if (prcntg == "") {
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#divWarning").alert();
                document.getElementById("<%=txtCltvPercng.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCltvPercng.ClientID%>").focus();

                  ret = false;
              }
               if (name == "") {
                   $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                   $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                   });
                   $noCon("#divWarning").alert();
                   document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
                   document.getElementById("<%=txtName.ClientID%>").focus();

                ret = false;
            }

          
            if (frmDate == "" && ToDate == "") {

                document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                 // document.getElementById("<%=txtDateFrom.ClientID%>").focus();
                  $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                  $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                  });
                  // $noCon("#divWarning").alert();
                  $noCon1(window).scrollTop(0);
                  flag = 1;
                  ret = false;



              }

           else if (frmDate == "") {
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#divWarning").alert();
                document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                flag = 1;
       //document.getElementById("<%=txtDateFrom.ClientID%>").focus();

       ret = false;
            }
         else  if (ToDate == "") {
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#divWarning").alert();
                document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                  //document.getElementById("<%=txtDateFrom.ClientID%>").focus();

                  ret = false;
            }
            if (flag == 0) {


             
                var arrDatePickerDate1 = frmDate.split("-");
                frmDate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
                var arrDatePickerDate1 = ToDate.split("-");
                ToDate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
              //  alert(ToDate);
                if ((frmDate != "" && ToDate != "") && frmDate >= ToDate) {
                    document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                   // document.getElementById("<%=txtToDate.ClientID%>").focus();
                    $noCon("#divWarning").html("From date should be less than To date");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    // $noCon("#divWarning").alert();
                    $noCon1(window).scrollTop(0);

                    ret = false;
                }
            }
            if (DateChk() == false) {
               
                ret = false;
            }
            return ret;
        }
        function DateChk() {
            var ret = true;
           

            if (document.getElementById("cphMain_txtDateFrom").value != "" && document.getElementById("cphMain_txtToDate").value != "") {

                var datepickerDate = document.getElementById("cphMain_txtDateFrom").value;
                        var arrDatePickerDate = datepickerDate.split("-");
                        var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                        var datepickerDate = document.getElementById("cphMain_txtToDate").value;
                        var arrDatePickerDate = datepickerDate.split("-");
                        var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);



                        if (dateTxIss >= dateCompExp) {



                            $noCon("#divWarning").html("From date should be less than  to date");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            $noCon("#divWarning").alert();
                            $noCon(window).scrollTop(0);

                            document.getElementById("cphMain_txtToDate").focus();

                            document.getElementById("cphMain_txtToDate").style.borderColor = "red";
                            document.getElementById("cphMain_txtToDate").value = "";


                            ret = false;

                        }
                    }
                    return ret;
                }

</script>
    <script type="text/javascript">
        var $noCon = jQuery.noConflict();
   
 

         function isTag(evt) {
             IncrmntConfrmCounter();

             evt = (evt) ? evt : window.event;
             var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

             var charCode = (evt.which) ? evt.which : evt.keyCode;
             var ret = true;
             if (charCode == 60 || charCode == 62 || keyCodes == 13) {
                 ret = false;
             }
             return ret;
         }
         function textCounter(field, maxlimit) {        //emp25
             RemoveTag();
             RemoveDescTag();
             if (field.value.length > maxlimit) {
                 field.value = field.value.substring(0, maxlimit);
             } else {
                 isTag(event);
             }
         }
         function isTagEnter(evt) {
             IncrmntConfrmCounter();

             evt = (evt) ? evt : window.event;
             var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

             var charCode = (evt.which) ? evt.which : evt.keyCode;
             var ret = true;
             if (charCode == 60 || charCode == 62) {
                 ret = false;
             }
             return ret;
         }


         function SuccessConfirmation() {

             $noCon("#success-alert").html("Tax details inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;


        }
         function SuccessUpdation() {
             $noCon("#success-alert").html("Tax details updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;

        }
      function DuplicationName() {
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtName.ClientID%>").focus();

            $noCon("#divWarning").html("Duplication Error! TCS Name can’t be duplicated.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#divWarning").alert();

            return false;


      }
        function CanclUpdMsg() {
            $noCon("#divWarning").html("This TCS is already cancelled .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }


        function ConfirmMessage() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Tax_Collected_At_Source_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "fms_Tax_Collected_At_Source_List.aspx";
            }
        }

 

        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }


        function isTag(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
             <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
            <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
     <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <%-- <div id="main" role="main">--%>
      
        <div class="cont_rght" >
                  <div style="height:34px;">
  
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
            <%--  <img src="/Images/BigIcons/Job_Delegation.png" style="vertical-align: middle;" />--%>
     <asp:Label ID="lblEntry" runat="server"></asp:Label>
        </div >
      
        <div  id="divList"  class="list" runat="server" style="position: fixed; right: 1%; top: 42%; height: 26.5px;z-index: 90;" onclick="return ConfirmMessage()">

           
        </div>

                            <br>

  <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: #f6f6f6; float: left">
       
<%--    <div class="auto1">
<div class="cont_rght" style="width:100%">
<div class="sect250">--%>
<div class="row">
<div class="container" style="padding-top:18px;padding-bottom: 33px;">
<%--  <h3 class="box-title" style="text-transform:capitalize;margin-bottom:14px;color:#5e6b47;">
    <i class="fa fa-file-text-o" style="margin-right:10px;" aria-hidden="true"></i>Performance form template
  </h3>--%>
  
  <div class="col-lg-12" style="margin-top:-21px;">

<%--<button class="btn green" style="border-radius:0px;float:right;"><i class="fa fa-eye" style="margin-right:10px;"></i>Preview</button>--%>


<%--<button class="btn btn-primary" style="border-radius:0px;float:right;margin-right:11px;"><i class="fa fa-list-alt" style="margin-right:10px;"></i>List</button>--%>
</div>

<%--  <div class="form-row">
      <div class="col-md-6">
          <div class="form-group">
   
      <label for="inputEmail" class="col-md-4" style="margin-bottom:3px;">
      Name<span class="red">*</span>
       </label>
              <div class="col-md-8">        <asp:TextBox ID="txtPefmnceFrm" runat="server"  class="form-control" onblur="return  IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)"  onkeydown="textCounter(cphMain_txtPefmnceFrm,200)" onkeyup="textCounter(cphMain_txtPefmnceFrm,200)" style="float: right;width: 60%;" ></asp:TextBox>
</div>
    </div>

      </div>
    
  <div class="col-md-6">
       <div class="form-group">
   
      <label for="inputEmail4" class="col-md-4"  style="margin-bottom:3px;">
     Deductive Percentage<span class="red">*</span>
       </label>
           <div class="col-md-8"> 
   <asp:TextBox ID="txtRefNo"  runat="server"  class="form-control" style="width: 60%;float: right;"></asp:TextBox>
            </div>
    </div>
 
  </div>
      </div>--%>
  <div class="row">
      <div class="form-group col-md-6">
  <label for="example-text-input" class="col-md-2 col-form-label">Name*</label>
  <div class="col-md-10">
<%--    <input class="form-control" type="text" value="Artisanal kale" id="example-text-input">--%>

      <asp:TextBox  class="form-control"  id="txtName" runat="server" TabIndex="1" MaxLength="100" onkeypress="return  isTag(event);" onkeydown="return  IncrmntConfrmCounter();"   ></asp:TextBox>

  </div>
</div>
        <div class="form-group col-md-6">
  <label for="example-text-input" class="col-md-2 col-form-label" style="width: 30%;">Collective Percentage*</label>
            <div class="col-md-10" style="width: 69%;">
   <div class="col-md-11" style="width: 81%;">
       <asp:TextBox  class="form-control"  id="txtCltvPercng" runat="server" TabIndex="2" MaxLength="5" onkeypress="return  IncrmntConfrmCounter();"  onkeydown="return check(event.keyCode , this);" onblur="AmountChecking('cphMain_txtCltvPercng');"  ></asp:TextBox></div>  <div class="col-md-1" style="padding-top: 1.5%;"><i class="fa fa-percent" aria-hidden="true" style="font-size: large;"></i></div>
             <i  class="fa-fa-percent" ></i>
                </div>
</div>
  </div>
    <div class="row">
     <div class="form-group col-md-2" style="float: left;padding-left: 19%;width: 40%;">
  <label for="example-text-input" class="col-md-12 col-form-label" style="font-size: 18px;color: #2D5A81;">
Effective Date Range </label>
         </div>
 
</div>
      <div class="row col-md-6" style="padding:0px;">
     
        <div class="form-group col-md-6" >

              <label for="inputPassword4"  class="col-md-2 col-form-label" style="margin-bottom:3px;">From<span class="red">*</span></label>
  <div class="col-md-10">

     <%--      <input id="txtDateFrom" name="txtDateFrom" tabindex="7"   runat="server" readonly="readonly"  onblur="DateCurrentValue();" type="text" onkeypress="return DisableEnter(event)"   class="Tabletxt form-control datepicker"  data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" onchange="showFromDate()" />--%>
            <input id="txtDateFrom" runat="server"  name="txtDateFrom"   type="text" onkeypress="return DisableEnter(event)" tabindex="3"  class="Tabletxt form-control datepicker"  data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" onchange="showFromDate()" />
                                                    <asp:HiddenField ID="Hiddentxtefctvedate" runat="server"/>
                                                                        <script>
                                                                            var $noCon4 = jQuery.noConflict();
                                                                            var dateToday = new Date();
                                                                            $noCon4('#cphMain_txtDateFrom').datepicker({
                                                                                autoclose: true,
                                                                                format: 'dd-mm-yyyy',
                                                                                //endDate: 'today',


                                                                            });
                                                                            function showFromDate() {
                                                                                //DateCheck();
                                                                                IncrmntConfrmCounter();
                                                                              //  DateCurrentValue();
                                                                              //  $noCon4("#txtDateFrom").datetimepicker({ format: 'dd-mm-yyyy' })
                                                                                $noCon4('#cphMain_Hiddentxtefctvedate').val($noCon4('#cphMain_txtDateFrom').val().trim());


                                                                            }
                                                                            function insertFromDate() {

                                                                                IncrmntConfrmCounter();
                                                                                $noCon4('#cphMain_txtDateFrom').val($noCon4('#cphMain_Hiddentxtefctvedate').val().trim());

                                                                            }
                                                                             </script>
    </div>
                     


  
</div>

          <div class="form-group col-md-6" style="padding:0px;">
  <label for="inputPassword4"  class="col-md-2 col-form-label" style="margin-bottom:3px;">To<span class="red">*</span></label>
  <div class="col-md-10">
         <input id="txtToDate" name="txtToDate"  runat="server"  type="text" onkeypress="return DisableEnter(event)"  tabindex="4" class="Tabletxt form-control datepicker"  data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" onchange="showToDate()" />
<%--                       <input id="txtToDate" name="txtToDate" runat="server" tabindex="7" readonly="readonly"  onblur="DateCurrentValue();" type="text" onkeypress="return DisableEnter(event)"   class="Tabletxt form-control datepicker"  data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" onchange="showToDate()" />--%>
        <asp:HiddenField ID="HiddentxtefctveTodate" runat="server" />
                                                                        <script>
                                                                          
                                                                            $noCon4('#cphMain_txtToDate').datepicker({
                                                                                autoclose: true,
                                                                                format: 'dd-mm-yyyy',
                                                                                //endDate: 'today',


                                                                            });
                                                                            function showToDate() {
                                                                                //DateCheck();
                                                                                IncrmntConfrmCounter();
                                                                              //  DateCurrentValue();
                                                                              //  $noCon4("#txtDateFrom").datetimepicker({ format: 'dd-mm-yyyy' })
                                                                                $noCon4('#cphMain_HiddentxtefctveTodate').val($noCon4('#cphMain_txtToDate').val().trim());


                                                                            }
                                                                            function insertToDate() {

                                                                                IncrmntConfrmCounter();
                                                                                $noCon4('#cphMain_txtToDate').val($noCon4('#cphMain_HiddentxtefctveTodate').val().trim());

                                                                            }
                                                                             </script>
  </div>
</div>
     
   

  </div>

    <div class="row col-md-6 " style="margin-right: 1%;">
           <div class="col-md-8">
               
             <div   class="smart-form" style="float: left; width: 99%;">
                   <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px; float: left; border: 1px solid #04619c; margin-bottom: 1px;margin-left: 12%;">
      <label class="radio">
        <input type="radio"  tabindex="5" checked="true" onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" runat="server" id="typResident" style="display:block" name="optradio"  />
       <i></i>  Resident</label>
      <label class="radio">
        <input type="radio" id="typeNonResident" tabindex="6" onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" runat="server" style="display:block" name="optradio" />
        <i></i> Non-Resident</label>
                </div>
              </div>
               </div>
                  <div class="col-md-4" >
                       <div class="smart-form" >
    <label for="inputPassword" class="col-sm-4 col-form-label" style="margin-right:21px;">Status<span style="color:#F00"></span></label>
   
      <label class="checkbox" style="float:left" >Active
      
<input  type="checkbox" runat="server" tabindex="7" checked="checked" onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" id="Chksts" />
       <i></i> </label>
                 
        </div>




</div>
        </div>
   
   
         
          <div class="row col-md-6" style="padding:0px;">
              <div class="col-md-4"></div>
              <div class="col-md-4"></div>
              <div class="col-md-4"></div>
              </div>
   
  
  <div style="clear:both"></div>
  
      
            <script>

                $noCon('#cphMain_txtFromdate').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    startDate: new Date(),
                    timepicker: false
                });
                $noCon('#cphMain_txtTodate').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    startDate: new Date(),
                    timepicker: false
                });

       </script>
 <div style="clear:both"></div>   
    <div class="form-row form-inline">
    <div class="col-sm-4 col-md-4 padding-10" style="margin-top:3px;padding:0;width: 100%;float: right;margin-right: 1%;">

   

<%--             <div class="col-sm-4 col-md-4 ">

            <a >
<button id="dtncpyGrps" onclick="return OpenGroupcopy();" class="btn btn-primary btn-width"data-toggle="modal" data-target=".bs-example-modal-lg"  style="border-radius:0px;margin-right:11px;" ><i class="fa fa-clipboard" style="margin-right:10px;"></i>Import groups from existing template</button></a>
        </div>--%>
</div>
</div>
    
   
<div style="clear:both"></div>

    <%--  <div id="DivGroup">
          <table id="tableGrp"  style="width: 100%;">
                                </table>

    </div>--%>


<div>
<div class="col-md-12" style="padding:9px;">
<div style="float:right;">
    <asp:Button ID="bttnsave" TabIndex="8"  runat="server" OnClientclick="return ValidateTcs();"  class="btn btn-primary btn-grey  btn-width" text="Save" OnClick="bttnsave_Click"  />
    <%-- <asp:Button ID="bttnsaveChk"   runat="server" OnClientclick="return validateTable();"  class="btn btn-primary btn-grey  btn-width" text="SaveChk"  />--%>
<%--<button class="btn btn-primary btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-save" style="margin-right:10px;"></i>Save</button>--%>
    <asp:Button ID="btnUpdate"  TabIndex="9" runat="server" OnClientclick="return ValidateTcs();"  class="btn btn-primary btn-grey  btn-width" text="Update" OnClick="btnUpdate_Click"/>
   <%-- <asp:Button ID="btnPublishConform"   runat="server" OnClientclick="return ValidateConduct();"  class="btn btn-primary btn-grey  btn-width" text="Publish/Conform"  />--%>
   <%-- <asp:Button ID="btnClear"   runat="server" OnClientclick="return ValidateConduct();"  class="btn btn-primary btn-grey  btn-width" text="Clear" />--%>
 <%--   <asp:Button ID="btnCancel"   runat="server" OnClientclick="return ConfirmMessage();"  class="btn btn-primary btn-grey  btn-width" text="Cancel"  />--%>
   <input type="button" tabindex="10" id="btnCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn btn-primary btn-grey  btn-width" />
 <%--    <asp:Button ID="ButtnClose"   runat="server" OnClientclick="return CloseWindow();"  class="btn btn-primary btn-grey  btn-width" text="Close"  />--%>


<%--<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-upload" style="margin-right:10px;"></i>Update</button>
<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-check" style="margin-right:10px;"></i>Publish/Conform</button>
<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-refresh" style="margin-right:10px;"></i>Clear</button>
<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-remove" style="margin-right:10px;"></i>Cancel</button>--%>
</div>
</div>  
</div>
  </div>




  
</div>
<%--</div>
</div>








</div>--%>
  
    </div>

  </div>  </article>  </div>  </section>  </div>  </div>    <br />
    <style>
        .padding5 {
    padding: 5px;
    margin: 0 !important;
}
    </style>
</asp:Content>

