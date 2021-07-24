<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Tax_deducted_atSource.aspx.cs" Inherits="FMS_FMS_Master_fms_Tax_deducted_atSource_fms_Tax_deducted_atSource" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="../../../../js/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../../js/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
    <script>
    
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            //insert();
            FunctStsChkBxFill();
            
            if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                document.getElementById("cphMain_radioNonResident").disabled = true;
                document.getElementById("cphMain_radioNonResident").disabled = true;
                document.getElementById("cphMain_checkSts").disabled = true;                     
            }
        });

    </script>
    <script>


        function isNumber(evt, textboxid) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //  alert(textboxid);
            var txtPerVal = document.getElementById(textboxid).value;
            // alert(txtPerVal);
            //enter
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                return true;

            }
                // . period and numpad . period
            else if (keyCodes == 190 || keyCodes == 110) {
                var ret = true;
                if (textboxid == textboxid) {
                    var count = txtPerVal.split('.').length - 1;

                    if (count > 0) {

                        ret = false;
                    }
                    else {
                        ret = true;
                    }
                    return ret;
                }
                else {
                    //alert("55");
                    return false;
                }

            }

            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                }
                return ret;
            }
        }
        function AmountChecking(textboxid) {
            IncrmntConfrmCounter();
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
                        
                           if (100 < parseFloat(amtrnge1))
                           {
                                   document.getElementById(textboxid).style.borderColor = "red";
                                   document.getElementById(textboxid).value = "";
                                   $noCon(window).scrollTop(0);
                                   $noCon("#divWarning").html("Deductive percentage should  be less than hundered.");
                                   $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                  
                                   });

                                  

                               }

                           }
                       

                   }
               }


             
                       // alert("55");
               return true;
        }

        function check( obj) {
            if (obj.value > 100.0) {
                return false;
            }
            //  alert($char);
          
            if (obj.value.length == 0 || obj.value.length == 1) {
              
            }
            else if (obj.value.length == 2) {
                if ((obj.value > 10)) {
                    return true;
                }
                else if ((obj.value == 10)) {
                    return true;
                }
                else if ((obj.value < 10) ) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else if (obj.value.length == 3) {
                if ((obj.value == 100)) {
                    return true;
                }
                else if ((obj.value.indexOf(".") != -1) ) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else if (obj.value.length == 4) {
                if ((obj.value.indexOf(".") != -1)) {
                    return true;
                }
                else {
                    return false;
                }
            }
          
            else {
                return false;
            }
        }

        function check($char, obj) {
            if (obj.value > 100.0) {
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

       // function DateCurrentValue() {

          //  var DateVal = document.getElementById("cphMain_txtFromdate").value;

          //  if (DateVal == "") {

             //   document.getElementById("cphMain_txtFromdate").value = document.getElementById("<%=Hiddentxtefctvedate.ClientID%>").value;

            //   }
            //   return false;
       // }

       // function DateCurrentValueTo() {

          //  var DateVal = document.getElementById("cphMain_txtTodate").value;

          //  if (DateVal == "") {

          //      document.getElementById("cphMain_txtTodate").value = document.getElementById("<%=HiddentxtefctvedateTo.ClientID%>").value;

            //}
            //return false;
        //}

        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }

        function FunctStsChkBxFill() {
           // IncrmntConfrmCounter();
            if (document.getElementById("<%=HiddenChkSts.ClientID%>").value == "1") {
                document.getElementById("<%=checkSts.ClientID%>").checked = true;

            }
            else {
                document.getElementById("<%=checkSts.ClientID%>").checked = false;
            }
        }

        function FunctStsChkBx() {
            IncrmntConfrmCounter();
            if (document.getElementById("<%=checkSts.ClientID%>").checked == true) {
                document.getElementById("<%=HiddenChkSts.ClientID%>").value = "1"; 
                
            }
            else {
                document.getElementById("<%=HiddenChkSts.ClientID%>").value = "0";
            }
        }

        function DuplicationCheck() {
            

            var varGrpName = document.getElementById("cphMain_txtName").value.trim();
           

            var replaceText1 = varGrpName.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("cphMain_txtName").value = replaceText2;
            if (varGrpName != "") {
                IncrmntConfrmCounter();
                document.getElementById("cphMain_txtName").style.borderColor = "";
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                var orgid = '<%= Session["ORGID"] %>';
                var userid = '<%= Session["USERID"] %>';
             
       
                    Taxid = document.getElementById("<%=HiddenFieldTaxId.ClientID%>").value;
                    //  var per

                    $noCon.ajax({
                        type: "POST",
                        url: "fms_Tax_deducted_atSource.aspx/DupChkForTaxName",
                        data: '{intTaxid:"' + Taxid + '",intGrpname:"' + varGrpName + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" }',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {


                            if (response.d == "false") {
                                document.getElementById("cphMain_txtName").value = "";
                                document.getElementById("cphMain_txtName").style.borderColor = "Red";


                                $noCon(window).scrollTop(0);
                                $noCon("#divWarning").html("Tax name cannot be duplicated.");
                                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                    document.getElementById("cphMain_txtName").focus();

                                });

                               
                            }






                        },
                        failure: function (response) {

                        }


                    });
                

          
            }

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
                        window.location.href = "fms_Tax_deducted_atSource_List.aspx";
                    }

                    else {
                        // window.location.href = "hcm_Emp_Conduct_Incident_List.aspx";
                        return false;
                    }
                });
            }
            else {
                window.location.href = "fms_Tax_deducted_atSource_List.aspx";
                return true;
            }
            return false;

        }
        function ValidateTaxDeducted() {
            var ret = true;
            var prfmncName = document.getElementById("<%=txtName.ClientID%>").value;
            var percentege = document.getElementById("<%=txtperctg.ClientID%>").value;
            var FromDate = document.getElementById("<%=txtFromdate.ClientID%>").value;
            var Todate = document.getElementById("<%=txtTodate.ClientID%>").value;
            document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtperctg.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";

            if (FromDate == "") {
                document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "Red";
                //  document.getElementById("<%=txtFromdate.ClientID%>").focus();

                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
               
                $noCon(window).scrollTop(0);

                ret = false;
            }
            else {
               // DateChk();
            }
            if (Todate == "") {
                document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "Red";
                // document.getElementById("<%=txtTodate.ClientID%>").focus();

                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
               
                $noCon(window).scrollTop(0);

                ret = false;
            }
             else {
               // DateChk();
            }
            

            if (percentege == "") {
                document.getElementById("<%=txtperctg.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtperctg.ClientID%>").focus();

                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                   
                    $noCon(window).scrollTop(0);

                    ret = false;
                }
            if (prfmncName == "") {
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtName.ClientID%>").focus();

                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
               
                $noCon(window).scrollTop(0);

                ret = false;
            }

            if (!DateChk()) {
                ret = false;
            }

            return ret;

        }

        function SuccessMsg() {
            $noCon("#success-alert").html("Tax details inserted successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        

            return false;

        }

        function SuccessUpdMsg() {
            $noCon("#success-alert").html("Tax details updated successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        
            return false;
        }

        function CanclUpdMsg() {
            $noCon("#divWarning").html("Tax details already cancelled");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
           
            return false;
        }
      
        function DateChk() {
            var ret = true;
             if (document.getElementById("cphMain_txtFromdate").value != "" && document.getElementById("cphMain_txtTodate").value != "") {

                 var datepickerDate = document.getElementById("cphMain_txtFromdate").value;
                 var arrDatePickerDate = datepickerDate.split("-");
                 var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                 var datepickerDate = document.getElementById("cphMain_txtTodate").value;
                 var arrDatePickerDate = datepickerDate.split("-");
                 var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                 if (dateTxIss >= dateCompExp) {
              

                    $noCon("#divWarning").html("From date should be less than  to date");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                   
                    $noCon(window).scrollTop(0);
                    document.getElementById("cphMain_txtTodate").style.borderColor = "red";
                    document.getElementById("cphMain_txtTodate").value = "";
             
                   ret = false;

                }
              }
            return ret;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="Hiddentxtefctvedate" runat="server" />
    <asp:HiddenField ID="HiddentxtefctvedateTo" runat="server" />
    <asp:HiddenField ID="HiddenFieldTaxId" runat="server" />
    <asp:HiddenField ID="HiddenChkSts" runat="server" />
    <asp:HiddenField ID="HiddenView" runat="server" />
    <asp:HiddenField ID="HiddenCurrentDate" runat="server" />
  
    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li><a href="fms_Tax_deducted_atSource_List.aspx">TDS</a></li>
        <li class="active">Add TDS</li>
    </ol>
           <div class="myAlert-bottom alert alert-danger" id="divWarning" style="display: none">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
            <div class="myAlert-top alert alert-success" id="success-alert" style="display: none">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">
     
            <div class="content_box1 cont_contr">
                    <h1><asp:Label ID="lblEntry" runat="server"></asp:Label></h1>

         <div class="clearfix"></div>

              <div class="free_sp"></div>

          <div class="">
              <div class="">
                  <div class="form-group fg4">
                      <label for="example-text-input" class="fg2_la1">Name<span class="spn1">*</span></label>
                      <asp:TextBox ID="txtName" runat="server" MaxLength="150" class="form-control fg2_inp1 inp_mst" onblur="return  DuplicationCheck();" onkeypress="return DisableEnter(event)" onkeydown="textCounter('cphMain_txtName',180)" onkeyup="textCounter('cphMain_txtName',180)"></asp:TextBox>
                  </div>
                  <div class="form-group fg4">
                      <label for="example-text-input" class="fg2_la1">Deductive Percentage<span class="spn1">*</span></label>
                      <asp:TextBox ID="txtperctg" class="form-control fg2_inp1 inp_st tr_r inp_mst br_1pro" runat="server" MaxLength="5" Style="text-align: right;" onkeydown="return check(event.keyCode, this);" onblur="AmountChecking('cphMain_txtperctg');"></asp:TextBox>
                      <span class="input-group-addon cur3 r3">%</span>
                  </div>
              </div>
                </div>

                <div class="clearfix"></div>
                <div class="free_sp"></div>
                <div class="devider divid"></div>

                  <div class="">
                      <div class="">
                          <p class="plc1">Effective date range<span class="spn1">*</span></p>
                          <div class="form-group fg4">
                              <div class="tdte" id ="divFromDate">
                                  <label for="pwd" class="fg2_la1">From Date:<span class="spn1">*</span> </label>
                                  <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
                                      <input id="txtFromdate" runat="server" type="text" onkeypress="return DisableEnter(event)" onchange="show()" class="form-control inp_bdr" placeholder="dd-mm-yyyy" maxlength="50" />
                                      <span id="spanFromdate"   runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                                  </div>
                              </div>
                          </div>

                          <div class="form-group fg4">
                              <div class="tdte" id="divToDate">
                                  <label for="pwd" class="fg2_la1">To Date:<span class="spn1">*</span> </label>
                                  <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
                                      <input id="txtTodate" runat="server" type="text" onkeypress="return DisableEnter(event)" onchange="showTo()" class="form-control inp_bdr" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                                      <span id="spanTodate"   runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                                  </div>
                              </div>
                          </div>
                      </div>
                      <script>
                          $noCon('#datepicker').datepicker({
                              autoclose: true,
                              format: 'dd-mm-yyyy',
                              // startDate: new Date(),
                              timepicker: false
                          });
                          $noCon('#datepicker1').datepicker({
                              autoclose: true,
                              format: 'dd-mm-yyyy',
                              // startDate: new Date(),
                              timepicker: false
                          });
                      </script>

                      <script>
                          var $noCon4 = jQuery.noConflict();
                          function show() {
                              //DateCheck();
                              IncrmntConfrmCounter();
                              //  DateCurrentValue();
                              // $noCon4("#txtDateFrom").datetimepicker({ format: 'dd-mm-yyyy' })
                              $noCon4('#cphMain_Hiddentxtefctvedate').val($noCon4('#cphMain_txtFromdate').val().trim());
                          }

                          function showTo() {
                              //DateCheck();
                              IncrmntConfrmCounter();
                              //  DateCurrentValueTo();
                              // $noCon4("#txtDateFrom").datetimepicker({ format: 'dd-mm-yyyy' })
                              $noCon4('#cphMain_HiddentxtefctvedateTo').val($noCon4('#cphMain_txtTodate').val().trim());
                          }
                          function insert() {
                              IncrmntConfrmCounter();
                              $noCon4('#cphMain_txtFromdate').val($noCon4('#cphMain_Hiddentxtefctvedate').val().trim());
                          }
                          function insertTO() {

                              IncrmntConfrmCounter();
                              $noCon4('#cphMain_txtFromdate').val($noCon4('#cphMain_HiddentxtefctvedateTo').val().trim());

                          }
                      </script>

                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                      <div class="devider divid"></div>

                      <div class="form-group fg2 fg2_mr">
                          <div class="">
                              <div class="form-check">
                                  <input class="form-check-input" type="radio" checked="true" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" runat="server" id="radioResident"  name="optradio" />
                                  <label class="form-check-label" for="gridRadios1"> Resident  </label>
                              </div>
                              <div class="form-check">
                                  <input class="form-check-input" type="radio" id="radioNonResident" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" runat="server"  name="optradio" />
                                  <label class="form-check-label" for="gridRadios2">  Non-Resident
                                  </label>
                              </div>
                          </div>
                      </div>

<div class="form-group fg2 fg2_mr">
  <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
  <div class="check1">
    <div class="">
      <label class="switch">
           <input type="checkbox" runat="server"  checked  onchange="FunctStsChkBx();"  onkeypress="return DisableEnter(event)" id="checkSts" />
        <span class="slider_tog round"></span>
      </label>
    </div>
  </div>
</div>
</div>

<div class="clearfix"></div>
<div class="free_sp"></div>
    <div id="divList" runat="server" class="list_b" style="cursor: pointer;" onclick="return ConfirmMessage()" title="Back to List">
            <i class="fa fa-arrow-circle-left"></i>
        </div>
                <div class="sub_cont pull-right">
                    <div class="save_sec">
                        <asp:Button ID="bttnsave" runat="server" OnClientClick="return ValidateTaxDeducted();" class="btn sub1" Text="Save" OnClick="bttnsave_Click" />
                        <asp:Button ID="btnUpdate" runat="server" OnClientClick="return ValidateTaxDeducted();" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" />
                        <input type="button" id="btnCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn sub4" />
                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="free_sp"></div>
            </div>
  </div>
        </div>
    
</asp:Content>

