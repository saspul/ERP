<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Accommodation_Type_Master.aspx.cs" Inherits="Master_gen_Accommodation_Master_gen_Accommodation_Type_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
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
            if (document.getElementById("cphMain_lblEntry").innerText == "EDIT ACCOMMODATION TYPE") {
                $(".edit").css("display", "block");
            }
            if (document.getElementById("cphMain_lblEntry").innerText != "ADD ACCOMMODATION TYPE") {
                $(".add").css("display", "none");
            }
        });
    </script>
      <style>
        .fillform {
            width: 70%;
        }

        .subform {
            float: left;
            margin-left: 38.8%;
        }
         input[type="checkbox"][disabled="disabled"] {
           cursor: default !important;
        }
       
    </style>

  
    
   
  
    <script type="text/javascript">

        function DuplicationName() {

           
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
            $("#divWarning").html("Duplication Error!.Accommodation Type Can’t be Duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
          
        }
       
        function SuccessConfirmation() {
            $("#success-alert").html("Accommodation Type details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("Accommodation Type details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function HideLoading() {
            document.getElementById('divLoading').style.display = "";
        }
        function ErrorMsg() {
            $("#divWarning").html("Some error occured.Please review entered information !");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function Validate() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtName.ClientID%>").value = replaceText2;
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";
            var Name = document.getElementById("<%=txtName.ClientID%>").value.trim();
            //document.getElementById('divMessageArea').style.display = "none";
            //document.getElementById('imgMessageArea').src = "";
            if (Name == "") {
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

   

                if (Name == "") {


                    document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtName.ClientID%>").focus();
                    ret = false;
                }
            }
            //if (ret == true) {
               
            //}
            if (ret == false) {
                CheckSubmitZero();

            }

            return ret;
        }
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
                         window.location.href = "gen_Accommodation_Type_Master_List.aspx";
                         return false;
                     }
                     else {
                         return false;
                     }
                 });
                 return false;
             }
             else {
                 window.location.href = "gen_Accommodation_Type_Master_List.aspx";

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
                         window.location.href = "gen_Accommodation_Type_Master.aspx";
                         return false;
                     }
                     else {
                         return false;
                     }
                 });
                 return false;
             }
             else {
                 window.location.href = "gen_Accommodation_Type_Master.aspx";
                 return false;
             }
             return false;
         }
    </script>
     <%--<script src="../../../JavaScript/jquery-1.8.3.min.js"></script>--%>
    <script type="text/javascript" >
        // for not allowing <> tags  and enter
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
        // for not allowing <> tags
        function isTagEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

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

        // not to be taken for other form  other thsn this table creation
        function isNumber(objSource, evt) {
            // KEYCODE FOR. AND DELETE IS SAME IN KEY PRESS DIFFERENT IN KEY DOWN AND UP
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //  alert(keyCodes);
            var ObjVal = document.getElementById(objSource).value;


            //0-9
            if (keyCodes >= 48 && keyCodes <= 57) {
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



                var count = ObjVal.split('.').length - 1;

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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
    <!----new--->


      <ol class="breadcrumb">
        <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Hcm.aspx">HCM</a></li>
        <li><a href="gen_Accommodation_Type_Master_List.aspx">Accommodation Type</a></li>
         <li class="active" >Add Accommodation Type</li>
  </ol>

  <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">Add accommodation Type</h2>

        <div class="form-group fg4 sa_fg4 sa_480">
          <label for="email" class="fg2_la1">Type:<span class="spn1">*</span></label>
                            <asp:TextBox ID="txtName" class="form-control fg2_inp1 inp_mst" runat="server" onchange="IncrmntConfrmCounter();" placeholder="Accommodation Type" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onblur="RemoveTag('cphMain_txtName')" autocomplete="off"   MaxLength="100"  TextMode="SingleLine" ></asp:TextBox>

         
        </div>
              
        <div class="form-group fg4 fg2_mr sa_fg4 sa_480">
          <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
          <div class="check1">
            <div class="">
              <label class="switch">
                  <asp:CheckBox ID="cbxStatus" Text="" runat="server" Checked="true"/>
                <span class="slider_tog round"></span>
              </label>
            </div>
          </div>
        </div>
        
        
   
        <div class="clearfix"></div>
        <div class="free_sp"></div>
        <div class="devider"></div>

        <div class="sub_cont pull-right">
             <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                   <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2" Text="Clear"/>
              <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();"  />
       
        </div>
             </div>
    </div>
    </div>
            <div class="mySave1" id="mySave" runat="server">
                     <asp:Button ID="btnUpdatef" runat="server" class="btn sub1" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnUpdateClosef" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnAddf" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="btnAddClosef" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="btnCancelf" runat="server"  class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();"  />
                     <asp:Button ID="btnClearf" runat="server" class="btn sub2"  OnClientClick="return AlertClearAll();"   Text="Clear"/>
               
</div>
        
   
 <!--content_container_closed------>

<a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
<i class="fa fa-save"></i>
</a>

<a href="gen_Accommodation_Type_Master_List.aspx" type="button" class="list_b" title="Back to List">
<i class="fa fa-arrow-circle-left"></i>
</a>
    <script>
        function opensave() {
            document.getElementById("cphMain_mySave").style.width = "120px";
        }

        function closesave() {
            document.getElementById("cphMain_mySave").style.width = "0px";
        }
</script>
    <!----new--->


















     
</asp:Content>

