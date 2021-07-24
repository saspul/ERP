<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Ledger.aspx.cs" Inherits="FMS_FMS_Master_fms_Ledger_fms_Ledger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />  
    <script src="/js/Common/Common.js"></script>
    <link href="/js/New js/date_pick/datepicker.css" rel="stylesheet" type="text/css" />
    <script src="/js/New js/date_pick/datepicker.js"></script>
   <style>
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

        <script>
            function AlertClearAll() {
            
                if (confirmbox > 0) {
                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure you want clear all data in this page?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            window.location.href = "fms_Ledger.aspx";
                        }
                        else {
                            return false;
                        }
                    });
                    return false;
                }
                else {
                    return true;
                }
            }
            var $au = jQuery.noConflict();
            $au(function () {
                $au('#cphMain_ddlAccountGrp').selectToAutocomplete1Letter();
                $au('#cphMain_ddlLedger').selectToAutocomplete1Letter();
            });

        </script>
    
    <style>
        .auto1 {
    width: 92%;
    margin-left: 17px;
}
         input[type="radio"] {
            display: table-cell;
        }
         input[type="checkbox"] {
    margin: 0px 0 0;
    line-height: normal;
}
    </style>
    <script>
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
            return false;
        }
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            radioTCSclick();
            radioTDSclick()
            ledgerStsClick();
            changeAmnt('cphMain_txtOpenBalanceDeb',0);
            changeAcntgrp(0);
            ChangeLedgerAccount(0);
            txtCCclick('cphMain_txtOpenBalanceDeb');

            CreditLimitChange('cphMain_txtCreditLimit');
            CreditPeriodChange('cphMain_txtCreditPeriod');
        });
        function SuccessMsg() {

            $noCon("#success-alert").html("Ledger details inserted successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpdMsg() {

            $noCon("#success-alert").html("Ledger details updated successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }

        function CanclUpdMsg() {
            $noCon("#divWarning").html("This action is  denied! This ledger is already cancelled.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function DupName() {

            $noCon("#divWarning").html("Duplication Error!. Ledger name can’t be duplicated.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                
            });
            document.getElementById("cphMain_txtName").style.borderColor = "red";
            document.getElementById("cphMain_txtName").focus();
            return false;
        }
        function DuplicationBank() {

            $noCon("#divWarning").html("Duplication Error!. Ledger name can’t be duplicated with bank name.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

            });
            document.getElementById("cphMain_txtName").style.borderColor = "red";
            document.getElementById("cphMain_txtName").focus();
            return false;
        }
        function DuplicationLedgrCodeMsg() {

            $noCon("#divWarning").html("Duplication Error!. Ledger code can’t be duplicated.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

            });
            if ($("#cphMain_txtCode").length) {
                document.getElementById("cphMain_txtCode").style.borderColor = "red";
                document.getElementById("cphMain_txtCode").focus();
            }
            return false;

        }
        function DuplicationCstCntrCodeMsg() {
            $noCon("#divWarning").html("Duplication Error!. Cost centre code can’t be duplicated.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

            });
            if ($("#cphMain_txtCostCntrCode").length) {
                document.getElementById("cphMain_txtCostCntrCode").style.borderColor = "red";
                document.getElementById("cphMain_txtCostCntrCode").focus();
            }
            return false;
        }

        function DupNameCost() {

            $noCon("#divWarning").html("Duplication Error!. Cost centre name can’t be duplicated.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
               
            });
            document.getElementById("cphMain_txtName").style.borderColor = "red";
            document.getElementById("cphMain_txtName").focus();
            return false;
        }
        function ConfirmMessage() {

           if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Ledger_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
            }
            else {
               window.location.href = "fms_Ledger_List.aspx";
            }
            return false;

        }
        function addCommas(textboxid) {
            // alert(textboxid);
            nStr = document.getElementById(textboxid).value;
            nStr += '';
            var x = nStr.split('.');
            var x1 = x[0];
            var x2 = x[1];

            if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "1") {
                  var rgx = /(\d+)(\d{7})/;
                  if (rgx.test(x1)) {
                      x1 = x1.replace(rgx, '$1' + ',' + '$2');
                  }
                  rgx = /(\d+)(\d{5})/;
                  if (rgx.test(x1)) {
                      x1 = x1.replace(rgx, '$1' + ',' + '$2');
                  }
                  rgx = /(\d+)(\d{3})/;
                  if (rgx.test(x1)) {
                      x1 = x1.replace(rgx, '$1' + ',' + '$2');
                  }
              }

              if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "2") {
               var rgx = /(\d+)(\d{9})/;
               if (rgx.test(x1)) {
                   x1 = x1.replace(rgx, '$1' + ',' + '$2');
               }

               rgx = /(\d+)(\d{6})/;
               if (rgx.test(x1)) {
                   x1 = x1.replace(rgx, '$1' + ',' + '$2');
               }
               rgx = /(\d+)(\d{5})/;
               if (rgx.test(x1)) {
                   x1 = x1.replace(rgx, '$1' + ',' + '$2');
               }
               rgx = /(\d+)(\d{3})/;
               if (rgx.test(x1)) {
                   x1 = x1.replace(rgx, '$1' + ',' + '$2');
               }
           }
           if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "3") {
               var rgx = /(\d+)(\d{9})/;
               if (rgx.test(x1)) {
                   x1 = x1.replace(rgx, '$1' + ',' + '$2');
               }
               rgx = /(\d+)(\d{6})/;
               if (rgx.test(x1)) {
                   x1 = x1.replace(rgx, '$1' + ',' + '$2');
               }
               rgx = /(\d+)(\d{3})/;
               if (rgx.test(x1)) {
                   x1 = x1.replace(rgx, '$1' + ',' + '$2');
               }
           }



           //alert(x1);
           if (isNaN(x2))
               document.getElementById('' + textboxid + '').value = x1;
               //return x1;
           else
               document.getElementById('' + textboxid + '').value = x1 + "." + x2;
           // return x1 + "." + x2;
           //    alert(document.getElementById('' + textboxid + '').value);
        }
        function AmountChecking(textboxid) {

            var txtPerVal = document.getElementById(textboxid).value;
            //  alert(txtPerVal);

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
                    var FloatingValue = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);

                    }
                    document.getElementById('' + textboxid + '').value = n;

                }
            }

            addCommas(textboxid);
        }


        function isDecimalNumber(evt, textboxid) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            var txtPerVal = document.getElementById(textboxid).value;
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 38 || keyCodes == 40) {
                return false;

            }
            else if (keyCodes == 46) {
                return true;
            }

                // . period and numpad . period
            else if (keyCodes == 190 || keyCodes == 110) {
                var ret = true;

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
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                }
                return ret;
            }
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
</asp:ScriptManager>

     <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
     <asp:HiddenField ID="hiddenupd" runat="server" />
     <asp:HiddenField ID="HiddenFieldQryString" runat="server" />  
     <asp:HiddenField ID="HiddenFieldDecimalCnt" runat="server" />     
     <asp:HiddenField ID="HiddenCodeStatus" runat="server" /> 
     <asp:HiddenField ID="HiddenMode" runat="server" /> 
     <asp:HiddenField ID="hiddenTaxEnabled" runat="server" />     
     <asp:HiddenField ID="hiddenCostCntrId" runat="server" /> 
     <asp:HiddenField ID="HiddenCostCntrCnclId" runat="server" /> 
     <asp:HiddenField ID="HiddenAccntSts" runat="server" /> 
     <asp:HiddenField ID="HiddenCodeFormate" runat="server" />
     <asp:HiddenField ID="hiddenVouchrId" runat="server" />
     <asp:HiddenField ID="hiddenOBBalncAmnt" runat="server" />
    <asp:HiddenField ID="hiddenVBAmount" runat="server" />
    <asp:HiddenField ID="hiddenCodeNumberFrmt" runat="server" />

      <!---alert_message_section---->
<div class="myAlert-top alert alert-success" id="success-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Success!</strong> Changes completed succesfully
</div>

<div class="myAlert-bottom alert alert-danger" id="divWarning">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Danger!</strong> Request not conmpleted
</div>
<!----alert_message_section_closed---->

      <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li><a href="fms_Ledger_List.aspx">Ledger</a></li>
        <li class="active" id="pathCurr" runat="server">Add Ledger</li>
 </ol>

	<div class="content_sec2 cont_contr">
		<div class="content_area_container cont_contr">
      
		<div class="content_box1 cont_contr">
      <h2 id="lblEntry" runat="server">Add Ledger</h2>

      <div class="form-group fg5 fg2_mr">
        <label for="txtName" class="fg2_la1">Account Name:<span class="spn1">*</span></label>
            <asp:TextBox ID="txtName" runat="server" MaxLength="100" autocomplete="off"  class="form-control fg2_inp1 inp_mst"  placeholder="Account Name" onchange="return  IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)"  onkeyup="textCounter(cphMain_txtName,100)" ></asp:TextBox>
       
      </div>
      <div class="form-group fg5 fg2_mr" id="DivLedgerCode" runat="server">
        <label for="email" class="fg2_la1">Account Code:<span class="spn1"></span></label>
             <asp:TextBox id="txtCode" runat="server" autocomplete="off"  class="form-control fg2_inp1" placeholder="Code" Enabled="false" onchange="IncrmntConfrmCounter();" MaxLength="50"  onkeyup="textCounter(cphMain_txtCode,50)"  ></asp:TextBox>
      </div>
      <div class="form-group fg7 fg2_mr">
        <label for="email" class="fg2_la1 pad_l">Sub Ledger:<span class="spn1">&nbsp;</span></label>
        <div class="check1">
          <div class="">
            <label class="switch">
              <input type="checkbox" id="cbxSubLedger"  onchange="return ChangeLedgerAccount(1);" onkeypress="return DisableEnter(event)" runat="server" >
              <span class="slider_tog round"></span>
            </label>
          </div>
        </div>
      </div>               
      <div class="form-group fg5 fg2_mr">
        <label for="email" class="fg2_la1">Account Group:<span class="spn1">*</span></label>
           <div  id="divddlAccountGrp">
              <asp:DropDownList ID="ddlAccountGrp" class="form-control fg2_inp1 fg_chs2 inp_mst acgrp"  runat="server"  onchange="CheckAccountGroup();"  onblur="ChkDisplayComunicatnDtls();" onkeypress="return DisableEnter(event)" ></asp:DropDownList>
          <script>
              function CheckAccountGroup() {

                  document.getElementById("cphMain_divCustomer").style.display = "none";
                  document.getElementById("cphMain_divSupplier").style.display = "none";
                  document.getElementById("<%=hiddenCustmrSupplierMode.ClientID%>").value = "0";

                  var AcntGrpId = 0; var SubLedgerId = 0;
                  if (document.getElementById("<%=ddlAccountGrp.ClientID%>").value != "" && document.getElementById("<%=ddlAccountGrp.ClientID%>").value != "0" && document.getElementById("<%=ddlAccountGrp.ClientID%>").value != "--SELECT ACCOUNT GROUP--") {
                      AcntGrpId = document.getElementById("<%=ddlAccountGrp.ClientID%>").value;
                  }
                  if (document.getElementById("<%=ddlLedger.ClientID%>").value != "" && document.getElementById("<%=ddlLedger.ClientID%>").value != "0" && document.getElementById("<%=ddlLedger.ClientID%>").value != "--SELECT LEDGER--") {
                      SubLedgerId = document.getElementById("<%=ddlLedger.ClientID%>").value;
                  }

                  var orgid = '<%=Session["ORGID"]%>';
                  var corpid = '<%=Session["CORPOFFICEID"]%>';
                  if (AcntGrpId != 0 || SubLedgerId != 0) {
                      $.ajax({
                          async: false,
                          type: "POST",
                          url: "fms_Ledger.aspx/LoadCheckAccountGroup",
                          data: '{AcntGrpId:"' + AcntGrpId + '",orgid:"' + orgid + '",corpid:"' + corpid + '",SubLedgerId:"' + SubLedgerId + '"}',
                          contentType: "application/json; charset=utf-8",
                          dataType: "json",
                          success: function (response) {

                              if (response.d[0] == "1") {
                                  ezBSAlert({
                                      type: "confirm",
                                      messageText: "Do you want cheque book?",
                                      alertType: "info"
                                  }).done(function (e) {
                                      if (e == true) {
                                          document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";
                                          var LdgrName = document.getElementById("<%=txtName.ClientID%>").value;
                                          if (LdgrName != "") {
                                              var nWindow = window.open('/Master/gen_Bank_Master/gen_Bank_Master.aspx?RFGP=RFG&Name=' + LdgrName + '', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                                              nWindow.focus();
                                          }
                                          else {
                                              document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
                                              document.getElementById("<%=txtName.ClientID%>").focus();
                                              $au('input.acgrp').val("--SELECT ACCOUNT GROUP--");
                                          }
                                          document.getElementById("<%=hiddenPostBankId.ClientID%>").value = "";
                                          return false;
                                      }
                                      else {
                                          return false;
                                      }
                                  });
                              }
                                  //else if (response.d[0] == "5" || response.d[0] == "6" || response.d[0] == "7" || response.d[0] == "8") {
                                  //    if (response.d[0] == "5" || response.d[0] == "6") {
                                  //        document.getElementById("cphMain_divSupplier").style.display = "block";
                                  //        document.getElementById("<%=hiddenCustmrSupplierMode.ClientID%>").value = "2";
                                  //   }
                                  //   else if (response.d[0] == "7" || response.d[0] == "8") {
                                  //       document.getElementById("cphMain_divCustomer").style.display = "block";
                                  //       document.getElementById("<%=hiddenCustmrSupplierMode.ClientID%>").value = "1";
                                  //   }
                                  //}
                              else {
                                  if (response.d[1] == "1") {
                                      document.getElementById("cphMain_divCreditDtls").style.display = "block";
                                  }
                                  else {
                                      document.getElementById("cphMain_divCreditDtls").style.display = "none";
                                  }
                              }
                          },
                          failure: function (response) {

                          }
                      });
                  }

                  if (AcntGrpId != 0) {
                      var orgID = '<%= Session["ORGID"] %>';
                      var corptID = '<%= Session["CORPOFFICEID"] %>';

                      var ldsts = 0;
                      var CodeSts = document.getElementById("<%=HiddenCodeFormate.ClientID%>").value;
                      var CodeNumberFormat = document.getElementById("<%=hiddenCodeNumberFrmt.ClientID%>").value;

                      if (CodeSts == 0) {

                          $.ajax({
                              type: "POST",
                              async: false,
                              contentType: "application/json; charset=utf-8",
                              url: "fms_Ledger.aspx/CrateCodeFormate",
                              data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",AcntGrpId: "' + AcntGrpId + '",ldsts: "' + ldsts + '",CodeNumberFormat: "' + CodeNumberFormat + '"}',

                              dataType: "json",
                              success: function (data) {
                                  if (data.d != "") {
                                      if ($("#cphMain_txtCode").length) {
                                          document.getElementById("<%=txtCode.ClientID%>").value = data.d;
                                      }
                                  }

                              }
                          });
                      }
                  }
              }

                     function GetValueFromChildProject(myVal) {
                         if (myVal != '') {
                             document.getElementById("<%=hiddenPostBankId.ClientID%>").value = myVal;
                         }
                     }
                     function ledgerStsClick() {

                         if (document.getElementById("<%=HiddenMode.ClientID%>").value != "1") {
                             if (document.getElementById("cphMain_cbxCsCntrSts").checked == true) {



                                 document.getElementById("cphMain_ddlCC").disabled = false;
                                 document.getElementById("cphMain_rdIncome").disabled = false;
                                 document.getElementById("cphMain_rdExpense").disabled = false;


                                 if (document.getElementById("<%=HiddenCodeFormate.ClientID%>").value == "1") {


                                     if (document.getElementById("<%=HiddenMode.ClientID%>").value != "1") {
                                         if ($("#cphMain_txtCostCntrCode").length) {
                                             document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = false;
                                         }
                                     }
                                 }
                                 else {
                                     if ($("#cphMain_txtCostCntrCode").length) {
                                         document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = true;
                                     }
                                 }





                             }
                             else {
                                 if ($("#cphMain_txtCostCntrCode").length) {
                                     document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = true;
                                 }
                                 document.getElementById("cphMain_ddlCC").value = "--SELECT COST GROUP--";
                                 document.getElementById("cphMain_rdIncome").checked = true;
                                 document.getElementById("cphMain_ddlCC").disabled = true;
                                 document.getElementById("cphMain_rdIncome").disabled = true;
                                 document.getElementById("cphMain_rdExpense").disabled = true;
                             }
                         }
                         else {

                             if (document.getElementById("cphMain_cbxCsCntrSts").checked == true) {



                                 document.getElementById("cphMain_ddlCC").disabled = true;
                                 document.getElementById("cphMain_rdIncome").disabled = true;
                                 document.getElementById("cphMain_rdExpense").disabled = true;


                                 if (document.getElementById("<%=HiddenCodeFormate.ClientID%>").value == "1") {


                                     if (document.getElementById("<%=HiddenMode.ClientID%>").value != "1") {
                                         if ($("#cphMain_txtCostCntrCode").length) {
                                             document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = true;
                                         }
                                     }
                                 }
                                 else {
                                     if ($("#cphMain_txtCostCntrCode").length) {
                                         document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = true;
                                     }
                                 }





                             }
                             else {
                                 if ($("#cphMain_txtCostCntrCode").length) {
                                     document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = true;
                                 }
                                 document.getElementById("cphMain_ddlCC").value = "--SELECT COST GROUP--";
                                 document.getElementById("cphMain_rdIncome").checked = true;
                                 document.getElementById("cphMain_ddlCC").disabled = true;
                                 document.getElementById("cphMain_rdIncome").disabled = true;
                                 document.getElementById("cphMain_rdExpense").disabled = true;
                             }
                         }
                     }

              function CreditLimitChange(obj) {

                  if (document.getElementById(obj).value != "" && document.getElementById("<%=HiddenMode.ClientID%>").value != "1") {
                      document.getElementById("<%=cbxCrdtLmtRestrict.ClientID%>").disabled = false;
                      document.getElementById("<%=cbxCrdtLmtWarn.ClientID%>").disabled = false;
                  }
                  else {
                      document.getElementById("<%=cbxCrdtLmtRestrict.ClientID%>").disabled = true;
                      document.getElementById("<%=cbxCrdtLmtWarn.ClientID%>").disabled = true;
                  }

                  AmountChecking(obj);
              }


              function CreditPeriodChange(obj) {

                  if (document.getElementById(obj).value != "" && document.getElementById("<%=HiddenMode.ClientID%>").value != "1") {
                      document.getElementById("<%=cbxCrdtPeriodRestrict.ClientID%>").disabled = false;
                      document.getElementById("<%=cbxCrdtPeriodWarn.ClientID%>").disabled = false;
                  }
                  else {
                      document.getElementById("<%=cbxCrdtPeriodRestrict.ClientID%>").disabled = true;
                      document.getElementById("<%=cbxCrdtPeriodWarn.ClientID%>").disabled = true;
                  }
              }

             </script>

      <asp:HiddenField ID="hiddenPostBankId" runat="server" /> 
      <asp:HiddenField ID="hiddenCustmrSupplierMode" runat="server" /> 
  </div>
      </div>
      <div class="form-group fg5 fg2_mr">
        <label for="email" class="fg2_la1">Account Head:<span class="spn1">*</span></label>
          <div  id="divddlLedger">
      <asp:DropDownList ID="ddlLedger"  class="form-control fg2_inp1 fg_chs2 inp_mst ldgr" runat="server" onchange="return changeAcntgrp(1);" onblur="return  IncrmntConfrmCounter();"   onkeypress="return isTagEnter(event)" onkeydown="return DisableEnter(event);" >
                            </asp:DropDownList>
                                      </div>
      </div>

    <div class="clearfix"></div>
    <div class="free_sp"></div>
    <div class="devider divid"></div>

             <div id="DivTdcTcs"  runat="server">
                 <div style="display:none;" class="form-group col-md-6 padding5">
   
      <label for="ddlCurrency" style="margin-bottom:3px;">Currency*</label>
       <asp:DropDownList ID="ddlCurrency"  CssClass="form-control" class="form1" runat="server" onchange="return  IncrmntConfrmCounter();"   onkeypress="return isTagEnter(event)" onkeydown="return DisableEnter(event);" style="float: right;width:75%;">
                            </asp:DropDownList>
    </div>

              <div class="form-group fg2 fg2_mr">
                <label for="email" class="fg2_la1 pad_l">TDS Applicable:<span class="spn1">*</span></label>
                <div class="check1 mar_btm1" >
                  <div class="">
                    <label class="switch">
                      <input type="checkbox" class="bu"  onclick="radioTDSclick();" onchange="IncrmntConfrmCounter();" onkeypress="return isTagEnter(event)" onkeydown="return DisableEnter(event);" runat="server" id="radioTDSyes">
                      <span class="slider_tog round"></span>
                    </label>
                  </div>
                </div>

                  <asp:DropDownList ID="ddlTDS"  CssClass="form-control fg2_inp1 fg_chs1" class="form1" runat="server" onchange="return  IncrmntConfrmCounter();"   onkeypress="return isTagEnter(event)" onkeydown="return DisableEnter(event);" >
                            </asp:DropDownList>
              </div>

              <div class="form-group fg2 fg2_mr">
                <label for="email" class="fg2_la1 pad_l">TCS Applicable:<span class="spn1">*</span></label>
                <div class="check1 mar_btm1">
                  <div class="">
                    <label class="switch">
                      <input type="checkbox" class="bu1"  onclick="radioTCSclick();" onchange="IncrmntConfrmCounter();" onkeypress="return isTagEnter(event)" onkeydown="return DisableEnter(event);" runat="server" id="radioTCSyes" >
                      <span class="slider_tog round"></span>
                    </label>
                  </div>
                </div>
                    <asp:DropDownList ID="ddlTCS"  CssClass="form-control fg2_inp1 fg_chs1" class="form1" runat="server" onchange="return  IncrmntConfrmCounter();"   onkeypress="return isTagEnter(event)" onkeydown="return DisableEnter(event);">
                            </asp:DropDownList>
              </div>
               
              <div class="clearfix"></div>
              <div class="free_sp"></div>
              <div class="devider divid"></div>

              </div>

              <div class="form-group fg2 fg2_mr">
      <label for="email" class="fg2_la1">Opening Balance:<span class="spn1">&nbsp;</span></label>
                  <asp:TextBox ID="txtOpenBalanceDeb" autocomplete="off" runat="server" MaxLength="12"  class="form-control fg2_inp1 tr_r" onblur="txtCCclick('cphMain_txtOpenBalanceDeb');" onchange="return changeAmnt('cphMain_txtOpenBalanceDeb',1);"  onkeypress="return isDecimalNumber(event,'cphMain_txtOpenBalanceDeb')" onkeydown="return isDecimalNumber(event,'cphMain_txtOpenBalanceDeb')"
           style="text-align:right;" ></asp:TextBox>
    </div>
  <div style="display:none;" class="form-group col-md-6 padding5">
   
      <label for="txtOpenBalanceCre" style="margin-bottom:3px;">Credit Balance </label>
        <asp:TextBox ID="txtOpenBalanceCre" runat="server" MaxLength="12"  class="form-control" onblur="return  IncrmntConfrmCounter();" onchange="return changeAmnt('cphMain_txtOpenBalanceCre',1);"  onkeypress="return isDecimalNumber(event,'cphMain_txtOpenBalanceCre')" onkeydown="return isDecimalNumber(event,'cphMain_txtOpenBalanceCre')"  style="float: right;width: 75%;text-align:right;" ></asp:TextBox>
    </div>
    <div class="form-group fg2 fg2_mr">
      <div class="row">
        <div class="">
          <div class="form-check">
            <input class="form-check-input" type="radio" name="gridRadios2" onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" runat="server" id="typdebit" value="option1" checked="true" />
            <label class="form-check-label" for="gridRadios1">Debit</label>
          </div>
          <div class="form-check">
            <input class="form-check-input" type="radio" name="gridRadios2" id="typecredit"  onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" runat="server" value="option2"/>
            <label class="form-check-label" for="gridRadios2">Credit</label>
          </div>
        </div>
      </div>
    </div>
    
             <div class="form-group fg5 fg2_mr" id="divEffctveDate" style="display:none;">
                <div class="tdte">
                  <label for="pwd" class="fg2_la1">Effective Date*:<span class="spn1"></span> </label>
                  <div id="datepicker2" class="input-group date" data-date-format="dd-mm-yyyy">
                    <input class="form-control inp_bdr" type="text" id="txtDateFrom" runat="server"  name="txtDateFrom"  readonly="readonly" maxlength="50" onchange="showFromDate()" onkeypress="return DisableEnter(event)"/>
                    <span id="spanFromDate" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                  </div>
                </div> 
                 <asp:HiddenField ID="Hiddentxtefctvedate" runat="server"/>
            <script>
                var $noCon4 = jQuery.noConflict();
                var dateToday = new Date();
               
                $noCon4(function () {
                $noCon4("#datepicker2").datepicker({
                autoclose: true, 
                todayHighlight: true,
                startDate: 'today',
                }).datepicker('update', new Date());
            });

                function showFromDate() {
                   // alert("");
                    //IncrmntConfrmCounter();
                    $noCon4('#cphMain_Hiddentxtefctvedate').val($noCon4('#cphMain_txtDateFrom').val().trim());
                }
                function insertFromDate() {
                   
                    IncrmntConfrmCounter();
                    $noCon4('#cphMain_txtDateFrom').val($noCon4('#cphMain_Hiddentxtefctvedate').val().trim());
                }
           </script>                                                            
  
       </div>

    <div class="form-group fg2 fg2_mr">
      <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
      <div class="check1">
        <div class="">
          <label class="switch">
            <input type="checkbox" id="Chksts"  onchange="IncrmntConfrmCounter();" checked="true" onkeypress="return DisableEnter(event)" runat="server">
            <span class="slider_tog round"></span>
          </label>
        </div>
      </div>
    </div>

    <div class="clearfix"></div>
    <div class="free_sp"></div>
    <div class="devider divid"></div>

    <div class="form-group fg7 fg2_mr">
              <label for="email" class="fg2_la1 pad_l">Consider as Cost Centre:<span class="spn1">&nbsp;</span></label>
              <div class="check1">
                <div class="">
                  <label class="switch">
                    <input type="checkbox" id="cbxCsCntrSts" onclick="ledgerStsClick();"  onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" runat="server"  >
                    <span class="slider_tog round"></span>
                  </label>
                </div>
              </div>
            </div>
             <div   class="smart-form"  style="display:none">
        <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px; float: left;  margin-bottom: 1px;">
       <label class="radio">
        <input  name="CostCenter" type="radio" checked="true"  onchange="IncrmntConfrmCounter();" onkeypress="return isTagEnter(event)" onkeydown="return DisableEnter(event);" runat="server" id="radioCostYes" style="display:block"  />
       <i></i>  Yes</label>
      <label class="radio">
        <input  name="CostCenter" type="radio"     id="radioCostNo"  onchange="IncrmntConfrmCounter();"  onkeypress="return isTagEnter(event)" onkeydown="return DisableEnter(event);" runat="server" style="display:block"  />
        <i></i> No</label>
</div>
                      </div>

             <div style="display:none">
       <div id="divSupplier" runat="server" class="form-group col-md-6 padding5" style="display:none;">
           <label for="cphMain_cbxSupplier" style="margin-bottom:3px;width:22.5%;float: left;"> Consider as Supplier</label>
               <div class="col-sm-8">
                 <div class="smart-form" style="float: left;">
                     <label class="checkbox">Yes<input type="checkbox" id="cbxSupplier"  onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" runat="server" /><i></i> </label>
                 </div>
               </div>
       </div>

       <div id="divCustomer" runat="server" class="form-group col-md-6 padding5" style="display:none;">
           <label for="cphMain_cbxSupplier" style="margin-bottom:3px;width:22.5%;float: left;"> Consider as Customer</label>
               <div class="col-sm-8">
                 <div class="smart-form" style="float: left;">
                     <label class="checkbox">Yes<input type="checkbox" id="cbxCustomer"  onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" runat="server" /><i></i> </label>
                 </div>
               </div>
       </div>
           </div>



            <div class="form-group fg2 fg2_mr" id="div2" runat="server">
              <label for="email" class="fg2_la1">Cost Group:<span class="spn1">*</span></label>
                 <asp:DropDownList ID="ddlCC"  CssClass="form-control fg2_inp1 fg_chs2" class="form1" runat="server" onchange="ChangeCostGroup();"    onkeypress="return isTagEnter(event)" >
                            </asp:DropDownList>
            
            </div>  
            <div class="form-group fg2 fg2_mr" id="divCostCntrCode" runat="server">
              <label for="email" class="fg2_la1">Cost Centre Code:<span class="spn1"></span></label>
                  <asp:TextBox  class="form-control fg2_inp1" placeholder="Cost Centre Code"   id="txtCostCntrCode"  runat="server"  MaxLength="50"  onclick="IncrmntConfrmCounter();" autocomplete="off"  onkeypress="return DisableEnter(event)"  onkeyup="textCounter(cphMain_txtCostCntrCode,50)"  ></asp:TextBox>
            </div>
            <div class="form-group fg2 fg2_mr">
               <label for="email" class="fg2_la1">Cost Centre Nature:<span class="spn1"></span></label>
              <div class="row">
                <div class="">
                  <div class="form-check">
                    <input class="form-check-input" type="radio" name="gridRadios" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" runat="server" id="rdIncome" value="option1" checked>
                    <label class="form-check-label" for="gridRadios1">Income</label>
                  </div>
                  <div class="form-check">
                    <input class="form-check-input" type="radio" name="gridRadios" id="rdExpense" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" runat="server" value="option2">
                    <label class="form-check-label" for="gridRadios2">Expense</label>
                  </div>
                </div>
              </div>
            </div>


               <div class="clearfix"></div>
              <div class="free_sp"></div>
              <div class="devider divid"></div>

   <div id="divCreditDtls" runat="server" style="display:none;">

    <div class="form-group fg2 fg2_mr sa_fg3">
      <label for="email" class="fg2_la1">Credit Period (Days):<span class="spn1">&nbsp;</span></label>
      <asp:TextBox ID="txtCreditPeriod" class="form-control fg2_inp1" runat="server" MaxLength="3" placeholder="Credit Period (Days)" onkeydown="return isNumber(event)" onblur="return CreditPeriodChange('cphMain_txtCreditPeriod')" ></asp:TextBox>
    </div>

    <div class="form-group fg2 sa_fg2 sa_fg2_tog">
      <div class="row">
        <div class="">
          <div class="form-check">
            <input id="cbxCrdtPeriodRestrict" runat="server" class="form-check-input" type="radio" name="gridRadios3" />
            <label class="form-check-label" for="gridRadios3">Delimit</label>
          </div>
          <div class="form-check">
            <input id="cbxCrdtPeriodWarn" runat="server" class="form-check-input" type="radio" name="gridRadios3" checked="true" />
            <label class="form-check-label" for="gridRadios3">Warn</label>
          </div>
        </div>
      </div>
    </div>


    <div class="form-group fg2 fg2_mr sa_fg3">
      <label for="email" class="fg2_la1">Credit Limit:<span class="spn1">&nbsp;</span></label>
      <asp:TextBox ID="txtCreditLimit" class="form-control fg2_inp1" runat="server" placeholder="Credit Limit" MaxLength="13" onkeypress="return isDecimalNumber(event,'cphMain_txtCreditLimit')" onkeydown="return isDecimalNumber(event,'cphMain_txtCreditLimit');" onblur="return CreditLimitChange('cphMain_txtCreditLimit');"></asp:TextBox>
    </div>

    <div class="form-group fg2 sa_fg2 sa_fg2_tog">
      <div class="row">
        <div class="">
          <div class="form-check">
            <input id="cbxCrdtLmtRestrict" runat="server" class="form-check-input" type="radio" name="gridRadios4" />
            <label class="form-check-label" for="gridRadios4">Delimit</label>
          </div>
          <div class="form-check">
            <input id="cbxCrdtLmtWarn" runat="server" class="form-check-input" type="radio" name="gridRadios4" checked="true" />
            <label class="form-check-label" for="gridRadios4">Warn</label>
          </div>
        </div>
      </div>
    </div>

</div>

    <div class="clearfix"></div>
    <div class="free_sp"></div>


    <div  runat="server" id="divDisplayCommunication" style="display:none;">
    <div class="text_area_container box_leg" style="height:170px">
      <div class="form-group fg2">
       <label for="email" class="fg2_la1">Customer Name: <span class="spn1">&nbsp;</span></label>
            <asp:TextBox ID="txtCommName" MaxLength="100" runat="server"  class="form-control fg2_inp1 tr_l" placeholder="Customer Name"  onchange="return  IncrmntConfrmCounter();"  onkeypress="return isTagEnter(event)" onkeydown="return DisableEnter(event);" ></asp:TextBox>
      </div>
   
      <div class="form-group fg2">
       <label for="email" class="fg2_la1">Pin/Zip Code: <span class="spn1">&nbsp;</span></label>
            <asp:TextBox ID="txtPinCode" runat="server" MaxLength="8"  class="form-control fg2_inp1 tr_l" placeholder="Enter Pin Code" onchange="return  IncrmntConfrmCounter();" onkeydown="return isNumberAmountAA(event)"  onkeypress="return isNumberAmountAA(event)"  ></asp:TextBox>
      </div>

      <div class="form-group fg2">
       <label for="email" class="fg2_la1" id="lblTaxSystem" runat="server">GST: <span class="spn1">&nbsp;</span></label>
           <asp:TextBox ID="txtTAXno" runat="server" MaxLength="20"  class="form-control fg2_inp1 tr_l" onchange="return  IncrmntConfrmCounter();"  onkeypress="return isTagEnter(event)"  ></asp:TextBox>
      </div>

      <div class="clearfix"></div>

      <div class="form-group fg2">
       <label for="email" class="fg2_la1">Address: <span class="spn1">&nbsp;</span></label>
           <asp:TextBox class="form-control fg2_inp1 tr_l" id="txtAddress"  onchange="return  IncrmntConfrmCounter();"   TextMode="MultiLine" onkeydown="textCounter(cphMain_txtAddress,500)" onkeyup="textCounter(cphMain_txtAddress,500)" runat="server"  style="resize: none; height: 50px;" ></asp:TextBox>
      </div>
   
      <%--<div class="form-group fg2">
       <label for="email" class="fg2_la1">Address 2: <span class="spn1">&nbsp;</span></label>
      <input id="Text6" type="text" class="form-control fg2_inp1 tr_l" id="email" placeholder="Address 2" name="email">
      </div>

      <div class="form-group fg2">
       <label for="email" class="fg2_la1">Address 3: <span class="spn1">&nbsp;</span></label>
      <input id="Text7" type="text" class="form-control fg2_inp1 tr_l" id="email" placeholder="Address 3" name="email">
      </div>--%>

    </div>


<div class="clearfix"></div>
<div class="free_sp"></div>
<div class="devider divid"></div>
  </div>        

 <!--Buttons_Area_started--->
 <div class="sub_cont pull-right">
  <div class="save_sec">

        <asp:Button ID="bttnsave"   runat="server" OnClientclick="return ValidateLedger();"  class="btn sub1" text="Save"  OnClick="bttnsave_Click"/>
       <asp:Button ID="btnSaveAndClose"   runat="server" OnClientclick="return ValidateLedger();"  class="btn sub3" text="Save & Close"  OnClick="bttnsave_Click"/>
    <asp:Button ID="btnUpdate"   runat="server" OnClientclick="return ValidateLedger();"  class="btn sub1" text="Update" OnClick="btnUpdate_Click" />
       <asp:Button ID="btnUpdateAndClose"   runat="server" OnClientclick="return ValidateLedger();"  class="btn sub3" text="Update & Close" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnCancel"   runat="server" OnClientclick="return ConfirmMessage();"  class="btn sub4" text="Cancel"  />
       <asp:Button ID="ButnClear"  runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
  </div>

 
</div>
<!--buttons_area_closed--->

<!----frame_closed section to footer script section--->
  </div>
<!-------working area_closed---->

    </div>    
  </div>
    <a onclick="return ConfirmMessage();"  id="divList" runat="server" type="button" class="list_b" title="Back to List" href="javascript:;">
<i class="fa fa-arrow-circle-left"></i>
</a>
     
    <script>
        function txtCCclick(x) {
            //   changeAmnt(x);
            AmountChecking('cphMain_txtOpenBalanceDeb');
            if (document.getElementById("cphMain_txtOpenBalanceDeb").value != "") {
             //   document.getElementById("cphMain_DandC").style.display = "block";
            }
            else {

            //    document.getElementById("cphMain_DandC").style.display = "none";
                // document.getElementById("cphMain_ddlTDS").value = "--SELECT TDS--";
            }
        }
        
        function ChangeLedgerAccount(str) {
          
          
          // 
           
            if (document.getElementById("<%=HiddenMode.ClientID%>").value != "1") {

                
               
                if (document.getElementById("cphMain_cbxSubLedger").checked == true) {

                    $au('input.acgrp').val("--SELECT ACCOUNT GROUP--");
                    $au('input.acgrp').attr('disabled', 'disabled');
                    // document.getElementById("cphMain_ddlLedger").disabled = false;
                    $('input.ldgr').attr("disabled", false);

                    document.getElementById("cphMain_divDisplayCommunication").style.display = "none";

                }
                else {
                    //  $au("div#divddlAccountGrp input.ui-autocomplete-input").focus();
                    
                    if (str == 1)
                    {
                        $au("div#divddlAccountGrp input.ui-autocomplete-input").select();
                        IncrmntConfrmCounter();
                   }

                    if (document.getElementById("<%=HiddenAccntSts.ClientID%>").value != "1")
                    {

                        $('input.acgrp').attr("disabled", false);
                    }
                    else {
                        $('input.acgrp').attr("disabled", true);
                        // document.getElementById("cphMain_cbxSubLedger").disabled = true;
                    }

                    //$au('input.ui-autocomplete-input').attr('enabled', 'enabled');
                    //   document.getElementById("cphMain_ddlLedger").disabled = true;
                    $au('input.ldgr').attr('disabled', 'disabled');
                    $au('input.ldgr').val("--SELECT LEDGER--");
                    //document.getElementById("cphMain_ddlLedger").value = "--SELECT LEDGER--";
                    //$au('input.ui-autocomplete-input').val("--SELECT ACCOUNT GROUP--");
                }
            }
            else {
                $('input.acgrp').attr("disabled", true);
                document.getElementById("cphMain_cbxSubLedger").disabled = true
                $au('input.ldgr').attr('disabled', 'disabled');
            }
        }
        function ValidateLedger() {
            var ret = true;

            var Name = document.getElementById("cphMain_txtName").value.trim();
            var AccntGrp = document.getElementById("cphMain_ddlAccountGrp").value;
            var SubLedger = document.getElementById("cphMain_ddlLedger").value;
            //       var Currency = document.getElementById("cphMain_ddlCurrency").value;
            if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == "1") {
                    var TDS = document.getElementById("cphMain_ddlTDS").value;
                    var TCS = document.getElementById("cphMain_ddlTCS").value;
                    document.getElementById("cphMain_ddlTDS").style.borderColor = "";
                    document.getElementById("cphMain_ddlTCS").style.borderColor = "";
                    $au("div#divddlAccountGrp input.ui-autocomplete-input").css("borderColor", "");
                }
       //     document.getElementById("cphMain_ddlCurrency").style.borderColor = "";
            document.getElementById("cphMain_ddlAccountGrp").style.borderColor = "";
           // document.getElementById("cphMain_ddlLedger").style.borderColor = "";

            $au("div#divddlLedger input.ui-autocomplete-input").css("borderColor", "");
            
            document.getElementById("cphMain_txtName").style.borderColor = "";
 
            document.getElementById("cphMain_txtDateFrom").style.borderColor = "";

            var skillsSelect = document.getElementById("cphMain_ddlAccountGrp");
            var selectedText = skillsSelect.options[skillsSelect.selectedIndex].text;
            //if (selectedText == "BANK" && document.getElementById("cphMain_txtDateFrom").value.trim()=="") {
            //    document.getElementById("cphMain_txtDateFrom").style.borderColor = "Red";
            //    document.getElementById("cphMain_txtDateFrom").focus();
            //    ret = false;
            //}

          // if (document.getElementById("cphMain_hiddenTaxEnabled").value == "1") {
                var CostGrp = document.getElementById("cphMain_ddlCC").value;
                document.getElementById("cphMain_ddlCC").style.borderColor = "";
                if (document.getElementById("cphMain_cbxCsCntrSts").checked == true && CostGrp == "--SELECT COST GROUP--") {
                    document.getElementById("cphMain_ddlCC").style.borderColor = "Red";
                    document.getElementById("cphMain_ddlCC").focus();
                    ret = false;
                }
          //}

                if($("#cphMain_DivTdcTcs").length){
                    if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == "1") {
                        if (document.getElementById("cphMain_radioTCSyes").checked == true && TCS == "--SELECT TCS--") {
                            document.getElementById("cphMain_ddlTCS").style.borderColor = "Red";
                            document.getElementById("cphMain_ddlTCS").focus();
                            ret = false;
                        }

                        if (document.getElementById("cphMain_radioTDSyes").checked == true && TDS == "--SELECT TDS--") {
                            document.getElementById("cphMain_ddlTDS").style.borderColor = "Red";
                            document.getElementById("cphMain_ddlTDS").focus();
                            ret = false;
                        }
                    }
                }
            //if (Currency == "" || Currency == "--SELECT CURRENCY--") {
            //    document.getElementById("cphMain_ddlCurrency").style.borderColor = "Red";
            //    document.getElementById("cphMain_ddlCurrency").focus();
            //     ret = false;
            //}
            //  
            if (document.getElementById("cphMain_cbxSubLedger").checked == true) {
                if (SubLedger == "" || SubLedger == "--SELECT LEDGER--") {

                    $au("div#divddlLedger input.ui-autocomplete-input").css("borderColor", "Red");

                    $au("div#divddlLedger input.ui-autocomplete-input").focus();
                    $au("div#divddlLedger input.ui-autocomplete-input").select();
                    //document.getElementById("cphMain_ddlLedger").style.borderColor = "Red";
                    //document.getElementById("cphMain_ddlLedger").focus();
                    ret = false;
                }
            }
            else {
                if (AccntGrp == "" || AccntGrp == "--SELECT ACCOUNT GROUP--") {
                  
                    $au("div#divddlAccountGrp input.ui-autocomplete-input").css("borderColor", "red");


                    $au("div#divddlAccountGrp input.ui-autocomplete-input").focus();
                    $au("div#divddlAccountGrp input.ui-autocomplete-input").select();
                    ret = false;
                }
            }
            if (Name == "") {
                document.getElementById("cphMain_txtName").style.borderColor = "Red";
                document.getElementById("cphMain_txtName").focus();
                ret = false;
            }
            if (ret == false) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
            }

            if (ret == true) {
                if ($("#cphMain_txtCostCntrCode").length) {
                    document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = false;
                }
            }


            return ret;

        }
        function isNumberAmountAA(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
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
            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    ret = false;
                }
                return ret;
            }
        }

        function radioTDSclick() {
            if ($("#cphMain_DivTdcTcs").length) {
                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == "1") {
                    if (document.getElementById("<%=HiddenMode.ClientID%>").value == 1) {
                        document.getElementById("cphMain_ddlTCS").disabled = true;

                    }
                    else {

                        if (document.getElementById("cphMain_radioTDSyes").checked == true) {
                            document.getElementById("cphMain_ddlTDS").disabled = false;
                        }
                        else {
                            document.getElementById("cphMain_ddlTDS").disabled = true;
                            document.getElementById("cphMain_ddlTDS").value = "--SELECT TDS--";
                        }
                    }
                }
            }
        }
        function radioTCSclick() {
            if ($("#cphMain_DivTdcTcs").length) {
                if (document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value == "1") {

                    if (document.getElementById("<%=HiddenMode.ClientID%>").value == 1) {
                        document.getElementById("cphMain_ddlTCS").disabled = true;

                    }
                    else {
                        if (document.getElementById("cphMain_radioTCSyes").checked == true) {
                            document.getElementById("cphMain_ddlTCS").disabled = false;
                        }
                        else {
                            document.getElementById("cphMain_ddlTCS").disabled = true;
                            document.getElementById("cphMain_ddlTCS").value = "--SELECT TCS--";
                        }
                    }
                }
            }
                }

        function changeAmnt(obj, mode) {
            
         
                if (document.getElementById("<%=typdebit.ClientID%>").checked == true) {
                    var OpeningBalance = document.getElementById("<%=hiddenOBBalncAmnt.ClientID%>").value;
                }
                else {
                    var OpeningBalance = document.getElementById("<%=hiddenOBBalncAmnt.ClientID%>").value;
                    OpeningBalance = Math.abs(OpeningBalance);
                }

                if (OpeningBalance != document.getElementById("<%=hiddenVBAmount.ClientID%>").value) {
                    document.getElementById("<%=typdebit.ClientID%>").disabled = true;
                    document.getElementById("<%=typecredit.ClientID%>").disabled = true;
                    if (mode == 1) {
                        if (document.getElementById("<%=hiddenOBBalncAmnt.ClientID%>").value != "" && document.getElementById("<%=hiddenVBAmount.ClientID%>").value != "") {
                            //var OpeningBalance = document.getElementById("<%=hiddenOBBalncAmnt.ClientID%>").value;
                            var LedgerBalance = document.getElementById("<%=hiddenVBAmount.ClientID%>").value;
                            var txtOB = document.getElementById("<%=txtOpenBalanceDeb.ClientID%>").value;
                            if (document.getElementById("<%=typdebit.ClientID%>").checked == true) {

                                if (parseFloat(txtOB) < parseFloat(OpeningBalance)) {
                                    $("#divWarning").html("Opening balance cannot be lesser than " + OpeningBalance + "");
                                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                    });
                                    return false;
                                }
                            }
                            else {
                                if (parseFloat(txtOB) > parseFloat(OpeningBalance)) {
                                    $("#divWarning").html("Opening balance cannot be greater than " + OpeningBalance + "");
                                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                    });
                                    return false;
                                }
                            }
                        }
                    }
                }
            //}
            //else
            //{

            //}


       //    if (document.getElementById("<%=hiddenOBBalncAmnt.ClientID%>").value != "") {

       //         var Balnc = document.getElementById("<%=hiddenOBBalncAmnt.ClientID%>").value;
        //      
        //        var OBDEBIT = document.getElementById("<%=txtOpenBalanceDeb.ClientID%>").value;
        //        var OBCREDIT = document.getElementById("<%=txtOpenBalanceCre.ClientID%>").value;
                
        //        if (document.getElementById("<%=typdebit.ClientID%>").checked == true) {
        //           if (parseFloat(OB) < parseFloat(Balnc)) {
        //               $("#divWarning").html("Opening balance cannot be lesser than " + Balnc + "");
        //              $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
        //             });
        //              return false;
        //          }
        //        }
         //       else {
          //         if (parseFloat(OB) > parseFloat(Balnc)) {
          //              $("#divWarning").html("Opening balance cannot be greater than " + Balnc + "");
           //             $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
           //             });
           //             return false;
            //        }
          //      }
          //  }

            var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
            var ObjVal = document.getElementById(obj).value.trim().replace(/,/g, "");
            if (FloatingValueMoney != "" && ObjVal != "") {
                ObjVal = parseFloat(ObjVal);
                document.getElementById(obj).value = ObjVal.toFixed(FloatingValueMoney);
            }
            addCommas(obj);
        }

        function changeAcntgrp(str) {

            var skillsSelect = document.getElementById("cphMain_ddlAccountGrp");
            var selectedText = skillsSelect.options[skillsSelect.selectedIndex].text;
            if (selectedText == "BANK") {
                document.getElementById("divEffctveDate").style.display = "block";
            }
            else {
                document.getElementById("divEffctveDate").style.display = "none";
            }
            var AcntGrpId = document.getElementById("<%=ddlLedger.ClientID%>").value;
            if (str == "1") {

                if (AcntGrpId != 0 && AcntGrpId != "--SELECT LEDGER--") {

                    var orgID = '<%= Session["ORGID"] %>';
                    var corptID = '<%= Session["CORPOFFICEID"] %>';

                    var ldsts = 1;
                    var CodeSts = document.getElementById("<%=HiddenCodeFormate.ClientID%>").value;
                    var CodeNumberFormat = document.getElementById("<%=hiddenCodeNumberFrmt.ClientID%>").value;
                    if (CodeSts == 0) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "fms_Ledger.aspx/CrateCodeFormate",
                            data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",AcntGrpId: "' + AcntGrpId + '",ldsts: "' + ldsts + '",CodeNumberFormat: "' + CodeNumberFormat + '"}',

                            dataType: "json",
                            success: function (data) {
                                if (data.d != "") {
                                    if ($("#cphMain_txtCode").length) {
                                        document.getElementById("<%=txtCode.ClientID%>").value = data.d;
                                    }
                                }

                            }
                        });
                    }

                    CheckAccountGroup();
                }
            }
        }

        function ChkDisplayComunicatnDtls() {
         
            var orgid = '<%=Session["ORGID"]%>';
            var corpid = '<%=Session["CORPOFFICEID"]%>';
            var AcntGrpId = document.getElementById("<%=ddlAccountGrp.ClientID%>").value;
            
       
            $noCon.ajax({
                type: "POST",
                url: "fms_Ledger.aspx/ChkDisplayCommunicationDtl",
                async: false,
                data: '{orgid:"' + orgid + '",corpid:"' + corpid + '",AcntGrpId:"' + AcntGrpId + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        document.getElementById("cphMain_divDisplayCommunication").style.display = "block";
                    }
                    else {
                        document.getElementById("cphMain_divDisplayCommunication").style.display = "none";
                    }

                },
                failure: function (response) {

                }
            });
        }


        function ChangeCostGroup() {
           
            IncrmntConfrmCounter();

            if (document.getElementById("<%=HiddenCodeStatus.ClientID%>").value == "1") {

                if (document.getElementById("<%=HiddenCodeFormate.ClientID%>").value == "1") {

                    if ($("#cphMain_txtCostCntrCode").length) {
                        document.getElementById("<%=txtCostCntrCode.ClientID%>").disabled = false;
                    }
                }
                else {

                    var CstGrpId = document.getElementById("<%=ddlCC.ClientID%>").value;


                    if (CstGrpId != 0 && CstGrpId != "--SELECT COST GROUP--") {

                        var orgID = '<%= Session["ORGID"] %>';
                        var corptID = '<%= Session["CORPOFFICEID"] %>';

                        var ldsts = 1;
                        var CodeSts = document.getElementById("<%=HiddenCodeFormate.ClientID%>").value;

                        if (CodeSts == 0) {

                            $.ajax({
                                type: "POST",
                                async: false,
                                contentType: "application/json; charset=utf-8",
                                //url: "fms_Ledger.aspx/CrateCodeFormateCostCntr",
                                url: "fms_Ledger.aspx/CreateCodeFormateCostCntr",
                                data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",CstGrpId: "' + CstGrpId + '"}',

                                dataType: "json",
                                success: function (data) {
                                    if (data.d != "") {
                                        if ($("#cphMain_txtCostCntrCode").length) {
                                            document.getElementById("<%=txtCostCntrCode.ClientID%>").value = data.d;
                                        }
                                    }

                                }
                            });
                        }
                    }
                    else {
                        if ($("#cphMain_txtCostCntrCode").length) {
                            document.getElementById("<%=txtCostCntrCode.ClientID%>").value = "";
                        }
                    }

                }

            }
        }
       </script>

</asp:Content>

