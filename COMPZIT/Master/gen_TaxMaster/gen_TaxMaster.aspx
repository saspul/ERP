<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_TaxMaster.aspx.cs" Inherits="Master_gen_TaxMaster_gen_TaxMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/hcm_ns.css" rel="stylesheet" />
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">
        var submit = 0;
        function CheckIsRepeat() {
            if (++submit > 1) {

                return false;
            }
            else {
                return true;
            }
        }
        function CheckSubmitZero() {
            submit = 0;
        }
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
        });
    </script>
      <script>

          //start-0006
          var confirmbox = 0;

          function IncrmntConfrmCounter() {
              confirmbox++;
          }
          function ConfirmMessage() {
              if (confirmbox > 0) {
                  ezBSAlert({
                      type: "confirm",
                      messageText: "Do you want to leave this page?",
                      alertType: "info"
                  }).done(function (e) {
                      if (e == true) {
                          window.location.href = "gen_TaxMasterList.aspx";
                          return false;
                      }
                      else {
                          return false;
                      }
                  });
                  return false;
              }
              else {
                  window.location.href = "gen_TaxMasterList.aspx";

              }
              return false;
          }
          function AlertClearAll() {
              if (confirmbox > 0) {
                  ezBSAlert({
                      type: "confirm",
                      messageText: "Do you want to clear all the data from this page?",
                      alertType: "info"
                  }).done(function (e) {
                      if (e == true) {
                          window.location.href = "gen_TaxMaster.aspx";
                          return false;
                      }
                      else {
                          return false;
                      }
                  });
                  return false;
              }
              else {
                  window.location.href = "gen_TaxMaster.aspx";
                  return false;
              }
              return false;
          }
          //stop-0006
    </script>
    <script type="text/javascript">

        function DuplicationName() {
            $("#divWarning").html("Duplication error!. Tax name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtTaxName.ClientID%>").style.borderColor = "Red";
        }

        function SuccessConfirmation() {
            $("#success-alert").html("Tax details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("Tax details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });

        }
        function NameValidate() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtTaxName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTaxName.ClientID%>").value = replaceText2;

            document.getElementById("<%=txtTaxName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaxPercentage.ClientID%>").style.borderColor = "";

            var Name = document.getElementById("<%=txtTaxName.ClientID%>").value.trim();
            var Percentage = document.getElementById("<%=txtTaxPercentage.ClientID%>").value;
          
          
            if (Name == "" || Percentage == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                if (Percentage == "") {
                    document.getElementById("<%=txtTaxPercentage.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTaxPercentage.ClientID%>").focus();
                    ret = false;

                }
                if (Name == "") {


                    document.getElementById("<%=txtTaxName.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTaxName.ClientID%>").focus();
                    ret = false;
                }
            }
            if (ret == false) {
                CheckSubmitZero();

            }
            return ret;
        }
    </script>
    <script type="text/javascript" language="javascript">

        var $noCon = jQuery.noConflict();


        // for not allowing <> tags
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
        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            var txtPerVal = document.getElementById("<%=txtTaxPercentage.ClientID%>").value;
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
            else if (keyCodes == 190 || keyCodes == 110)
            {
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



     

        function AmountCheck() {
       //     var ret = true;
            var txtPerVal = document.getElementById("<%=txtTaxPercentage.ClientID%>").value;
            if (txtPerVal == "") {
               return false;
            }
            else {
                if (!isNaN(txtPerVal) == false) {
                    document.getElementById("<%=txtTaxPercentage.ClientID%>").value = "";
                    return false;
                }
                else {
                    var amt = parseFloat(txtPerVal);
                    var num = amt;
                    var n = 0;
                    // for floatting number adjustment from corp global
                    var FloatingValue = document.getElementById("<%=hiddenFloatingValue.ClientID%>").value;
                    if (FloatingValue != "") {
                        if(String(num).includes('.'))
                            var n = num.toFixed(FloatingValue);
                        else
                            var n = num;
                }
                document.getElementById("<%=txtTaxPercentage.ClientID%>").value = n;

                }             
            }          
        }
     

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <ol class="breadcrumb">
       <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
      <li><a href="gen_TaxMasterList.aspx">Tax Master</a></li>
        <li id="lblEntryB" runat="server" class="active">Add Tax Master</li>
      </ol>
   <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
     <asp:HiddenField ID="hiddenFloatingValue" runat="server" />


    <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">Add Tax Master</h2>

        <div class="form-group fg2 sa_fg4 sa_640">
          <label for="email" class="fg2_la1">Tax Name:<span class="spn1">*</span></label>
             <asp:TextBox autocomplete="off" ID="txtTaxName"  runat="server" MaxLength="50" Style="text-transform: uppercase;"  class="form-control fg2_inp1 inp_mst" placeholder="Tax Name"></asp:TextBox>
        </div>
        <div class="form-group fg5 sa_fg4 sa_640">
          <label for="email" class="fg2_la1">Percentage:<span class="spn1">*</span></label>
          <div class=" dt_wdt">
             <asp:TextBox autocomplete="off" ID="txtTaxPercentage" placeholder="100" class="form-control fg2_inp1 inp_st tr_r inp_mst br_1pro" runat="server" MaxLength="7"  onblur="return AmountCheck();" Style="text-transform: uppercase;"></asp:TextBox>
          <span class="input-group-addon cur3 r3">%</span>
          </div>
        </div>
              
        <div class="form-group fg2 fg2_mr">
          <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
          <div class="check1">
            <div class="">
              <label class="switch">
                <input type="checkbox" id="cbxStatus"  runat="server" checked="checked"/>
                <span class="slider_tog round"></span>
              </label>
            </div>
          </div>
        </div>
               
        <div class="clearfix"></div>
        <div class="devider"></div>

        <div class="sub_cont pull-right">
          <div class="save_sec">
               <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
                  <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
                 <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2" Text="Clear"/>
              <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();"  />
            
          </div>
        </div>

<!---content_closed_area--->
          </div>
        </div>
      </div>


       <div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">
         <asp:Button ID="btnUpdateF" runat="server" class="btn sub1 bt_b" Text="Update" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnUpdateCloseF" runat="server" class="btn sub3 bt_b" Text="Update & Close" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnAddF" runat="server" class="btn sub1 bt_b" Text="Save" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
                  <asp:Button ID="btnAddCloseF" runat="server" class="btn sub3 bt_b" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
               <asp:Button ID="btnClearF" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2 bt_b" Text="Clear"/>
              <asp:Button ID="btnCancelF" runat="server" class="btn sub4 bt_b" Text="Cancel" OnClientClick="return ConfirmMessage();"  />
  </div> 
</div>
<a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
<i class="fa fa-save"></i>
</a>

       <!---back_button_fixed_section--->
  <a href="#" type="button" class="list_b" title="Back to List" onclick="return ConfirmMessage();" id="divList" runat="server">
    <i class="fa fa-arrow-circle-left"></i>
  </a>
<!---back_button_fixed_section--->
  <!--save_pop up_open-->
<script>
    function opensave() {
        document.getElementById("cphMain_mySave").style.width = "140px";
    }

    function closesave() {
        document.getElementById("cphMain_mySave").style.width = "0px";
    }
</script>


</asp:Content>
