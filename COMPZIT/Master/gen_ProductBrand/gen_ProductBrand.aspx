<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_ProductBrand.aspx.cs" Inherits="MasterPage_Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
  <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/js/Common/Common.js"></script>
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
        } function CheckSubmitZero() {
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
                          window.location.href = "gen_ProductBrandList.aspx";
                          return false;
                      }
                      else {
                          return false;
                      }
                  });
                  return false;
              }
              else {
                  window.location.href = "gen_ProductBrandList.aspx";

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
                          window.location.href = "gen_ProductBrand.aspx";
                          return false;
                      }
                      else {
                          return false;
                      }
                  });
                  return false;
              }
              else {
                  window.location.href = "gen_ProductBrand.aspx";
                  return false;
              }
              return false;
          }
          //stop-0006
    </script>   
    <script type="text/javascript">
        function DuplicationName() {
            $("#divWarning").html("Duplication error!. Product brand name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtPrdctBrndName.ClientID%>").style.borderColor = "Red";
        }
        function DuplicationCode() {
            $("#divWarning").html("Duplication error!. Product brand code can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtPrdctCodeName.ClientID%>").style.borderColor = "Red";
        }

        function SuccessConfirmation() {
            $("#success-alert").html("Product brand details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("Product brand details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function StateNameValidate() {

            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

            var NameWithoutReplace = document.getElementById("<%=txtPrdctBrndName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtPrdctBrndName.ClientID%>").value = replaceText2;

            var CodeWithoutReplace = document.getElementById("<%=txtPrdctCodeName.ClientID%>").value;
            var CodereplaceText1 = CodeWithoutReplace.replace(/</g, "");
            var CodereplaceText2 = CodereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtPrdctCodeName.ClientID%>").value = CodereplaceText2;

          
            var Name = document.getElementById("<%=txtPrdctBrndName.ClientID%>").value.trim();
            document.getElementById("<%=txtPrdctBrndName.ClientID%>").style.borderColor = "";
            if (Name == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                document.getElementById("<%=txtPrdctBrndName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtPrdctBrndName.ClientID%>").focus();
                ret= false;
            }
            if (ret == false) {
                CheckSubmitZero();

            }

            return ret;
        }
    </script>
    <script type="text/javascript" language="javascript">


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

        function controlTab(obj, event) {
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 9) {
                document.getElementById(obj).focus();
                return false;
            }

            else {
                return true;
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
      <li><a href="gen_ProductBrandList.aspx">Product Brand</a></li>
        <li id="lblEntryB" runat="server" class="active">Add Product Brand</li>
      </ol>
   <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
    <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">Add Product Brand</h2>

        <div class="form-group fg2">
          <label for="email" class="fg2_la1">Brand Name:<span class="spn1">*</span></label>
         <asp:TextBox runat="server" AutoCompleteType="Disabled" ID="txtPrdctBrndName" MaxLength="100" Style="text-transform: uppercase;" class="form-control fg2_inp1 inp_mst"  placeholder="Brand Name" ></asp:TextBox>
        </div>

        <div class="form-group fg2">
          <label for="email" class="fg2_la1">Brand Code:<span class="spn1"></span></label>
           <asp:TextBox AutoCompleteType="Disabled" MaxLength="50" Style="text-transform: uppercase;" runat="server" ID="txtPrdctCodeName" class="form-control fg2_inp1"  placeholder="Brand Code" ></asp:TextBox>
        </div>

             
        <div class="form-group fg2 fg2_mr">
          <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
          <div class="check1">
            <div class="">
              <label class="switch">
                <input type="checkbox" id="cbxStatus"  runat="server" checked="checked">
                <span class="slider_tog round"></span>
              </label>
            </div>
          </div>
        </div>
   
        <div class="clearfix"></div>
        <div class="devider"></div>

        <div class="sub_cont pull-right">
          <div class="save_sec">
               <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return StateNameValidate();"/>
               <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return StateNameValidate();"/>
               <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return StateNameValidate();"/>
               <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return StateNameValidate();"/>
               <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2" Text="Clear"/>
              <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();"  />
           
          </div>
        </div>
        
      </div>
    </div>
    </div>
        <div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">
         <asp:Button ID="btnUpdateF" runat="server" class="btn sub1 bt_b" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return StateNameValidate();"/>
               <asp:Button ID="btnUpdateCloseF" runat="server" class="btn sub3 bt_b" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return StateNameValidate();"/>
               <asp:Button ID="btnAddF" runat="server" class="btn sub1 bt_b" Text="Save" OnClick="btnAdd_Click" OnClientClick="return StateNameValidate();"/>
               <asp:Button ID="btnAddCloseF" runat="server" class="btn sub3 bt_b" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return StateNameValidate();"/>
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
