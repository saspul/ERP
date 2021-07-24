<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Cost_Center.aspx.cs" Inherits="FMS_FMS_Master_fms_Cost_Center_fms_Cost_Center" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>

    <script type="text/javascript">
       
        function ValidateCost() {
            var ret = true;
            var flag = 0;
            var name = document.getElementById("<%=txtName.ClientID%>").value.trim();
            var group = document.getElementById("<%=ddlCC.ClientID%>").value;

            
            if (group == "--SELECT GROUP--") {
                document.getElementById("<%=ddlCC.ClientID%>").style.borderColor = "Red";
              
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    document.getElementById("<%=ddlCC.ClientID%>").focus();
                });
               
               
               

                 ret = false;
             }
            if (name == "") {
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";

                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    document.getElementById("<%=txtName.ClientID%>").focus();
                });
               
                ret = false;
            }
            return ret;
        }

</script>
    <script type="text/javascript">
        var $noCon = jQuery.noConflict();
      
        $noCon(window).load(function () {
           
            changeAmnt('cphMain_txtblnce');
            if (document.getElementById("cphMain_lblEntry").innerText != "View Cost Centre") {
                if (document.getElementById("cphMain_txtblnce").value != "") {
                    //document.getElementById("cphMain_DandC").style.display = "block";
                    document.getElementById("cphMain_typdebit").disabled = false;
                    document.getElementById("cphMain_typecredit").disabled = false;
                }
                else {
                    document.getElementById("cphMain_typdebit").disabled = true;
                    document.getElementById("cphMain_typecredit").disabled = true;
                    //document.getElementById("cphMain_DandC").style.display = "none";
                    // document.getElementById("cphMain_ddlTDS").value = "--SELECT TDS--";
                }
            }
        });


        function changeAmnt(obj) {
           
            var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
           // alert(obj);
             var ObjVal = document.getElementById(obj).value.trim();
             if (FloatingValueMoney != "" && ObjVal != "") {
                 ObjVal = parseFloat(ObjVal);
                // alert(ObjVal);
                 document.getElementById(obj).value = ObjVal.toFixed(FloatingValueMoney);
                 addCommasSummry(ObjVal.toFixed(FloatingValueMoney));
             }
         }

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

        function AlreadyCancelMsg() {
            $noCon("#divWarning").html("Cost centre is already cancelled");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
           
            txtName.Focus();
        }
        function SuccessConfirmation() {
            document.getElementById("<%=txtName.ClientID%>").focus();
            $noCon("#success-alert").html("Cost centre details inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
           

            return false;


        }
        function SuccessUpdation() {
            document.getElementById("<%=txtName.ClientID%>").focus();
            $noCon("#success-alert").html("Cost centre details updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
           

            return false;

        }
        function DuplicationName() {
          document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
          document.getElementById("<%=txtName.ClientID%>").focus();
          document.getElementById("cphMain_typdebit").checked = true;
          $noCon("#divWarning").html("Duplication Error!.cost centre name can’t be duplicated.");
          $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
          });
         

          return false;


        }
        function DuplicationCstCntrCodeMsg() {
            document.getElementById("<%=txtCode.ClientID%>").style.borderColor = "Red";
              document.getElementById("<%=txtCode.ClientID%>").focus();
              document.getElementById("cphMain_typdebit").checked = true;
              $noCon("#divWarning").html("Duplication Error!.cost centre code can’t be duplicated.");
              $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
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
                      window.location.href = "fms_Cost_Center_List.aspx";
                  }
                  else {
                      return false;
                  }
              });
              return false;
          }
          else {
              window.location.href = "fms_Cost_Center_List.aspx";
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
      function AlertClearAll() {
          if (confirmbox > 0) {
              ezBSAlert({
                  type: "confirm",
                  messageText: "Are you sure you want clear all data in this page?",
                  alertType: "info"
              }).done(function (e) {
                  if (e == true) {
                      window.location.href = "fms_Cost_Center.aspx";
                  }
                  else {
                      return false;
                  }
              });
              return false;
          }
          else {
              window.location.href = "fms_Cost_Center.aspx";
              return false;
          }
      }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="HiddenCodeStatus" runat="server" />
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="HiddenFieldDecimalCnt" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="HiddenCodeFormate" runat="server" />

    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li><a href="fms_Cost_Center_List.aspx">Cost Centre List</a></li>
        <li class="active">Cost Centre</li>
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
                <h2>
                    <asp:Label ID="lblEntry" runat="server"> </asp:Label>
                </h2>

                <div class="form-group fg2">
                    <label for="email" class="fg2_la1">Cost Centre Name:<span class="spn1">*</span></label>
                      <asp:TextBox  class="form-control fg2_inp1 inp_mst"  id="txtName"  runat="server" autocomplete="off"   onchange="IncrmntConfrmCounter();"  MaxLength="100" onkeypress="return DisableEnter(event)"   onkeyup="textCounter(cphMain_txtName,100)"  ></asp:TextBox>
                </div>
 
                <div class="form-group fg2" id="DivCostCentreCode" runat="server">
                    <label for="email" class="fg2_la1">Code:<span class="spn1"></span></label>
                     <asp:TextBox  class="form-control fg2_inp1" autocomplete="off"    id="txtCode"   runat="server" onchange="IncrmntConfrmCounter();"  MaxLength="40" onkeypress="return DisableEnter(event)"   onkeyup="textCounter(cphMain_txtCode,40)" ></asp:TextBox>
                </div>

                <div class="form-group fg2">
                    <label for="email" class="fg2_la1">Cost Group:<span class="spn1">*</span></label>
                    <asp:DropDownList ID="ddlCC" Class="form-control fg2_inp1 inp_mst" runat="server" onchange="ChangeCostGroup();" onkeypress="return isTagEnter(event)">
                    </asp:DropDownList>
                </div>

                <div class="form-group fg2">
                    <label for="email" class="fg2_la1">Opening Balance:<span class="spn1">&nbsp;</span></label>
                    <asp:TextBox autocomplete="off" class="form-control fg2_inp1 tr_r" ID="txtblnce" runat="server" MaxLength="10" onblur="txtCCclick('cphMain_txtblnce');" onchange="IncrmntConfrmCounter();" onkeypress="return isDecimalNumber(event,'cphMain_txtblnce')" onkeydown="return isDecimalNumber(event,'cphMain_txtblnce')" Style="width: 84%; text-align: right;"></asp:TextBox>
                </div>


                <div class="clearfix"></div>
                <div class="free_sp"></div>
                <div class="devider divid"></div>
                <div class="clearfix"></div>

                <div class="form-group fg2" id="DandC" runat="server">
                    <label for="email" class="fg2_la1">Balance Type:<span class="spn1"></span></label>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" checked="true" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" runat="server" id="typdebit"  name="optradio" />
                        <label class="form-check-label" for="gridRadios1">
                            Debit
                        </label>
                    </div>

                    <div class="form-check">
                        <input class="form-check-input" type="radio" id="typecredit" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" runat="server"  name="optradio" />
                        <label class="form-check-label" for="gridRadios2">
                            Credit
                        </label>
                    </div>
                </div>

                <div class="form-group fg2" id="Div1" runat="server">
                    <label for="email" class="fg2_la1 ">Nature:<span class="spn1"></span></label>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" checked="true" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" runat="server" id="rdIncome" name="radioNature" />
                        <label class="form-check-label" for="gridRadios1">
                            Income
                        </label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" id="rdExpense" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" runat="server" name="radioNature" />
                        <label class="form-check-label" for="gridRadios2">
                            Expense
                        </label>
                    </div>
                </div>

                <div class="form-group fg2">
                    <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1"></span></label>
                    <div class="check1">
                        <div class="">
                            <label class="switch">
                                  <input type="checkbox" id="CheckBox1"   onchange="IncrmntConfrmCounter();" checked="checked"   onkeypress="return DisableEnter(event)" runat="server" />
                                   <span class="slider_tog round"></span>
                            </label>
                        </div>
                    </div>
                </div>

                <div id="divList" class="list_b" runat="server" style="cursor: pointer;" onclick="return ConfirmMessage()" title="Back to List">
                    <i class="fa fa-arrow-circle-left"></i>
                </div>

                <div class="clearfix"></div>
                <div class="free_sp"></div>
                <div class="devider divid"></div>

                 <div class="sub_cont pull-right">
                     <div class="save_sec">
                         <asp:Button ID="bttnsave" runat="server" OnClientClick="return ValidateCost();" class="btn sub1" Text="Save" OnClick="bttnsave_Click" />
                         <asp:Button ID="btnsaveAndClose" runat="server" OnClientClick="return ValidateCost();" class="btn sub3" Text="Save & Close" OnClick="bttnsave_Click" />
                         <asp:Button ID="btnUpdate" runat="server" OnClientClick="return ValidateCost();" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" />
                         <asp:Button ID="btnUpdateAndClose" runat="server" OnClientClick="return ValidateCost();" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" />
                         <input type="button" id="btnCancel" runat="server" onblur="IncrmntConfrmCounter();" onclick="    return ConfirmMessage()" value="Cancel" class="btn sub4" />
                         <asp:Button ID="ButtnClose" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                     </div>
                 </div>

            </div>
        </div>
    </div>

    <script>
        function ChangeCostGroup() {
            IncrmntConfrmCounter();

            var CstGrpId = document.getElementById("<%=ddlCC.ClientID%>").value;


            if (CstGrpId != 0 && CstGrpId != "--SELECT GROUP--") {

                var orgID = '<%= Session["ORGID"] %>';
                var corptID = '<%= Session["CORPOFFICEID"] %>';

                var ldsts = 1;
                var CodeSts = document.getElementById("<%=HiddenCodeFormate.ClientID%>").value;

                    if (CodeSts == 0) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            //url: "fms_Cost_Center.aspx/CrateCodeFormate", evm 0044
                            url: "fms_Cost_Center.aspx/CreateCodeFormate",
                            data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",CstGrpId: "' + CstGrpId + '"}',

                            dataType: "json",
                            success: function (data) {
                                if (data.d != "") {

                                    document.getElementById("<%=txtCode.ClientID%>").value = data.d;
                                }

                            }
                        });
                    }
                }

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
                    var n = num;
                    // for floatting number adjustment from corp global
                    var FloatingValue = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);

                    }
                    document.getElementById('' + textboxid + '').value = n;

                }
            }

          //  addCommas(textboxid);
        }

        function txtCCclick(x) {


           AmountChecking('cphMain_txtblnce');
            changeAmnt(x);
            if (document.getElementById("cphMain_txtblnce").value != "") {
                //document.getElementById("cphMain_DandC").style.display = "block";
                document.getElementById("cphMain_typdebit").disabled = false;
                document.getElementById("cphMain_typecredit").disabled = false;
            }
            else {
                document.getElementById("cphMain_typdebit").disabled = true;
                document.getElementById("cphMain_typecredit").disabled = true;
                //document.getElementById("cphMain_DandC").style.display = "none";
               // document.getElementById("cphMain_ddlTDS").value = "--SELECT TDS--";
            }
          
           
        }
        function addCommasSummry(nStr) {
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

                     if (isNaN(x2))
                         document.getElementById("<%=txtblnce.ClientID%>").value = x1;
                           //return x1;
                       else
                           document.getElementById("<%=txtblnce.ClientID%>").value = x1 + "." + x2;


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



