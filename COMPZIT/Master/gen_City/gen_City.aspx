<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_City.aspx.cs" Inherits="Master_gen_City_gen_CityAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
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
        var $au = jQuery.noConflict();
        $au(function () {
            $au('#cphMain_ddlCountry').selectToAutocomplete1Letter();
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
                         window.location.href = "gen_CityList.aspx";
                         return false;
                     }
                     else {
                         return false;
                     }
                 });
                 return false;
             }
             else {
                 window.location.href = "gen_CityList.aspx";

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
                         window.location.href = "gen_City.aspx";
                         return false;
                     }
                     else {
                         return false;
                     }
                 });
                 return false;
             }
             else {
                 window.location.href = "gen_City.aspx";
                 return false;
             }
             return false;
         }

    </script>
    <script type="text/javascript">

        function DuplicationName() {
            $("#divWarning").html("Duplication error!. City name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtCityName.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtCityName.ClientID%>").focus();
        }

        function SuccessConfirmation() {
            $("#success-alert").html("City details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("City details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function CityNameValidate() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtCityName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCityName.ClientID%>").value = replaceText2;
            var Name = document.getElementById("<%=txtCityName.ClientID%>").value.trim();
            var ddl = document.getElementById("<%=ddlCityStateName.ClientID%>").value.trim();
            var ddlC = document.getElementById("<%=ddlCountry.ClientID%>").value.trim();

            document.getElementById("<%=txtCityName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlCityStateName.ClientID%>").style.borderColor = "";
            $("div#divBnk input.ui-autocomplete-input").css("borderColor", "");


            if (ddl == "--SELECT--" || ddl == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=ddlCityStateName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlCityStateName.ClientID%>").focus();
                ret= false;
            }
            if (ddlC == "--SELECT--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $("div#divBnk input.ui-autocomplete-input").css("borderColor", "red");
                $("div#divBnk input.ui-autocomplete-input").select();
                $("div#divBnk input.ui-autocomplete-input").focus();
                ret = false;
             }
            if (Name == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtCityName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCityName.ClientID%>").focus();
                ret = false;
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
        function selectorToAutocompleteState(ev) {
            
            var $au = jQuery.noConflict();
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var countryID = document.getElementById("cphMain_ddlCountry").value;
           if (countryID != "--Select Country--" && countryID != "" && corptID != '' && corptID != null && (!isNaN(corptID)) && orgID != '' && orgID != null && (!isNaN(orgID))) {
               $au("#cphMain_ddlCityStateName").autocomplete({
             source: function (request, response) {
                 $.ajax({
                     url: "gen_City.aspx/changeState",
                     async: false,
                     data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'orgID': '" + parseInt(orgID) + "', 'corptID': '" + parseInt(corptID) + "', 'countryID': '" + parseInt(countryID) + "'}",
                     dataType: "json",
                     type: "POST",
                     contentType: "application/json; charset=utf-8",
                     success: function (data) {
                         
                         response($.map(data.d, function (item) {
                             return {
                                 val: item.split('<,>')[0],
                                 label: item.split('<,>')[1]
                             }
                         }))
                     },
                     error: function (response) {
                     },
                     failure: function (response) {
                     }
                 });
             },
             autoFocus: false,
             select: function (e, i) {
                 document.getElementById("<%=HiddenFieldState.ClientID%>").value = i.item.val;
                 document.getElementById("cphMain_ddlCityStateName").value = i.item.label;
                    },
                    change: function (event, ui) {
                        if (ui.item) {
                        }
                        else {
                            document.getElementById("cphMain_ddlCityStateName").value = "";
                            document.getElementById("<%=HiddenFieldState.ClientID%>").value = "";
                        }
                    }
                });
            }
        }
        function changeCountry() {
            document.getElementById("cphMain_ddlCityStateName").value = "";
            document.getElementById("<%=HiddenFieldState.ClientID%>").value = "";
            IncrmntConfrmCounter();
        }
        function changeState() {
            IncrmntConfrmCounter();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="HiddenFieldState" runat="server" />
     <ol class="breadcrumb">
       <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
      <li><a href="gen_CityList.aspx">City Master</a></li>
        <li id="lblEntryB" runat="server" class="active">Add City Master</li>
      </ol>
   <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>

    <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">  
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">Add City Master</h2>
 <!---------------------------==============frame===============--------> 
        
        <div class="form-group fg2 sa_o_fg6 sa_fg1">
          <label for="email" class="fg2_la1">City Name:<span class="spn1">*</span></label>
          <input id="txtCityName" runat="server" maxlength="250" style="text-transform: uppercase;" type="text" class="form-control fg2_inp1 inp_mst"  placeholder="City Name" name="">
        </div>
           <div class="form-group fg2 sa_o_fg6 sa_fg1" id="divBnk">
          <label for="email" class="fg2_la1">Country Name:<span class="spn1">*</span></label>
          <asp:DropDownList ID="ddlCountry" class="form-control fg2_inp1 inp_mst" runat="server"  onchange="changeCountry();"></asp:DropDownList>
        </div>
        <div class="form-group fg2 sa_o_fg6 sa_fg1">
          <label for="email" class="fg2_la1">State Name:<span class="spn1">*</span></label>
            <asp:TextBox ID="ddlCityStateName"  onchange="changeState();" class="form-control fg2_inp1 inp_mst"  placeholder="--SELECT--"   runat="server"  onkeypress="return selectorToAutocompleteState(event);" onkeydown="return selectorToAutocompleteState(event);"></asp:TextBox>
        </div>
             
        <div class="form-group fg2 fg2_mr sa_o_fg6 sa_fg1">
          <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
          <div class="check1">
            <div class="">
              <label class="switch">
                <input type="checkbox" id="cbCityStatus" runat="server" checked="checked">
                <span class="slider_tog round"></span>
              </label>
            </div>
          </div>
        </div>
               
        <div class="clearfix"></div>
        <div class="free_sp"></div>
        <div class="devider"></div>
             
        <div class="sub_cont pull-right">
          <div class="save_sec">
              <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClick="btnCityUpdate_Click" OnClientClick="return CityNameValidate(); " />
              <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClick="btnCityUpdate_Click" OnClientClick="return CityNameValidate(); " />
              <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return CityNameValidate();" />
              <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return CityNameValidate();" />
              <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2" Text="Clear"/>
              <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();"  />
          </div>
        </div>
          
<!----------------------------================frame================------------------------------->          
      </div>
<!-------working area_closed---->
    </div>    
   </div>
     <div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">
      <asp:Button ID="btnUpdateF" runat="server" class="btn sub1 bt_b" Text="Update" OnClick="btnCityUpdate_Click" OnClientClick="return CityNameValidate(); " />
              <asp:Button ID="btnUpdateCloseF" runat="server" class="btn sub3 bt_b" Text="Update & Close" OnClick="btnCityUpdate_Click" OnClientClick="return CityNameValidate(); " />
              <asp:Button ID="btnAddF" runat="server" class="btn sub1 bt_b" Text="Save" OnClick="btnAdd_Click" OnClientClick="return CityNameValidate();" />
              <asp:Button ID="btnAddCloseF" runat="server" class="btn sub3 bt_b" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return CityNameValidate();" />
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
<!--save_pop up_closed-->
<style>
         .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            width: 218px;
            border: 1px solid #B0BECA;
            max-height: 140px;
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
</asp:Content>

