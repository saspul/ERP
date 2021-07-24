<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Insurance_Provider.aspx.cs" Inherits="WMS_Wms_Master_gen_Insurance_Provider_gen_Insurance_Provider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
     <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
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
    </script>
       <script>
         
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
                           window.location.href = "gen_Insurance_Provider_List.aspx";
                           return false;
                       }
                       else {
                           return false;
                       }
                   });
                   return false;
               }
               else {
                   window.location.href = "gen_Insurance_Provider_List.aspx";

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
                           window.location.href = "gen_Insurance_Provider.aspx";
                           return false;
                       }
                       else {
                           return false;
                       }
                   });
                   return false;
               }
               else {
                   window.location.href = "gen_Insurance_Provider.aspx";
                   return false;
               }
               return false;
           }
              
    </script>
    <script>
        var ComIn = 1;
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {

                IncrmntConfrmCounter();
            }
            $noCon(".select2").select2();
            var data = document.getElementById("<%=HiddenFieldTypeValues.ClientID%>").value;
             var eachString = data.split(',');
             $noCon('#cphMain_ddlType').val(eachString);
             $noCon("#cphMain_ddlType").trigger("change");
        });
        function ChangeTyp() {
            if (ComIn == 0) {
                IncrmntConfrmCounter();
            }
            ComIn = 0;
        }
    </script>

        <script type="text/javascript">

            function DuplicationName() {
                $("#divWarning").html("Duplication error!. Insurance provider name can’t be duplicated.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtProviderName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtProviderName.ClientID%>").focus();
        }


        function SuccessConfirmation() {
            $("#success-alert").html("Insurance provider details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }

        function SuccessUpdation() {
            $("#success-alert").html("Insurance provider details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }

            function InsuranceValidate() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtProviderName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtProviderName.ClientID%>").value = replaceText2;

            var AddressWithoutReplace = document.getElementById("<%=txtProviderAddress.ClientID%>").value;
            var replaceCode1 = AddressWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtProviderAddress.ClientID%>").value = replaceCode2;

            document.getElementById("<%=txtProviderName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtProviderAddress.ClientID%>").style.borderColor = "";
                $("div#divBu span.select2-selection--multiple").css("borderColor", "");
            var Name = document.getElementById("<%=txtProviderName.ClientID%>").value.trim();

               
                if (document.getElementById("<%=ddlType.ClientID%>").value == null || document.getElementById("<%=ddlType.ClientID%>").value == "") {
                    $("div#divBu span.select2-selection--multiple").css("borderColor", "red");
                    $("#divBu").find(':input:visible:first').focus();
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                ret = false;
            }


                if (Name == "") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtProviderName.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtProviderName.ClientID%>").focus();
                    ret = false;
                }

                if (ret == false) {
                    CheckSubmitZero();

                }
                else {
                    document.getElementById("<%= HiddenFieldTypeValues.ClientID %>").value = "";
                    document.getElementById("<%= HiddenFieldTypeValues.ClientID %>").value = $('#cphMain_ddlType').val();
                }
                return ret;
            }


    </script>



        <script type="text/javascript" language="javascript">
            // for not allowing <> tags
            function isTag(evt) {

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
           
            //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
            function textCounter(field, maxlimit) {
                if (field.value.length > maxlimit) {
                    field.value = field.value.substring(0, maxlimit);
                } else {

                }
            }
           
              
    </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
     <asp:HiddenField ID="HiddenFieldTypeValues" runat="server" />


     <ol class="breadcrumb">
       <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
      <li><a href="gen_Insurance_Provider_List.aspx">Insurance Provider</a></li>
        <li id="lblEntryB" runat="server" class="active">Add Insurance Provider</li>
      </ol>
   <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>


    <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">Add Insurance Provider</h2>

        <div class="form-group fg2 sa_2 sa_480">
          <label for="email" class="fg2_la1">Provider Name:<span class="spn1">*</span></label>
          <input autocomplete="off" id="txtProviderName"  runat="server" maxlength="98" style="text-transform: uppercase;" type="text" class="form-control fg2_inp1 inp_mst" placeholder="Provider Name"/>
        </div>
        <div class="fg4 sa_2 sa_640_i ma_bo4" id="divBu">
          <label class="l_b">Insurance Type:<span class="spn1">*</span></label><br>
          <asp:DropDownList ID="ddlType" onchange="ChangeTyp();"  class="form-control fg2_inp1 select2" data-placeholder="--Select--" multiple="multiple" runat="server">
          </asp:DropDownList>
        </div>

        <div class="form-group fg2 sa_2 sa_480 tr_l">
            <label for="email" class="fg2_la1">Address:<span class="spn1">&nbsp;</span></label>
            <textarea id="txtProviderAddress"  maxlength="450"  style="resize:none;" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtProviderAddress,450)" onkeyup="textCounter(cphMain_txtProviderAddress,450)" runat="server" rows="4" cols=31 class="form-control flt_l wdt_94" placeholder="Address"></textarea>
        </div>
           
        <div class="form-group fg7 fg2_mr sa_480">
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
                <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return InsuranceValidate();"/>
                      <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return InsuranceValidate();"/>
                    <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return InsuranceValidate();"/>
                     <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return InsuranceValidate();"/>
                    <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2" Text="Clear"/>
                   <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();"  />
          
          </div>
        </div>

        </div>
       </div>
      </div>


     <div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">
          
       <asp:Button ID="btnUpdateF" runat="server" class="btn sub1 bt_b" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return InsuranceValidate();"/>
                      <asp:Button ID="btnUpdateCloseF" runat="server" class="btn sub3 bt_b" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return InsuranceValidate();"/>
                    <asp:Button ID="btnAddF" runat="server" class="btn sub1 bt_b" Text="Save" OnClick="btnAdd_Click" OnClientClick="return InsuranceValidate();"/>
                     <asp:Button ID="btnAddCloseF" runat="server" class="btn sub3 bt_b" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return InsuranceValidate();"/>
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
                  
       <style>             
    .ma_bo4 {
    margin-bottom: 16px !important;
}
                .select2-container--default.select2-container--focus .select2-selection--multiple {
    border: solid #ccc 1px;
    outline: 0;
}
    .select2-container {
        width:376px !important;
    }
    </style>              
     <script>
         function opensave() {
             document.getElementById("cphMain_mySave").style.width = "140px";
         }

         function closesave() {
             document.getElementById("cphMain_mySave").style.width = "0px";
         }
</script>       
</asp:Content>

