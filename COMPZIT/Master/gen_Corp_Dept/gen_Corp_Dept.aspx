<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="gen_Corp_Dept.aspx.cs" Inherits="MasterPage_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
     <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
       <script language="javascript" type="text/javascript">
           var submit = 0;
           var confirmbox = 0;
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
           function IncrmntConfrmCounter() {
               confirmbox++;
           }
           function preview(Id) {
          //alert(Id);            
               $('#dialog_simple').modal('show');
               var str = Id;
              
               var globalFileTypeId = str.split(',');
               var id1 = globalFileTypeId[0];
               var id2 = globalFileTypeId[1];
               var id3 = globalFileTypeId[2];
               document.getElementById("<%=divSeviceName.ClientID%>").innerHTML = id3
               document.getElementById("<%=HiddenWelfareId.ClientID%>").value = id1;
              // alert(id1); alert(id2);
              
               $.ajax({
                   type: "POST",
                   url: "gen_Corp_Dept.aspx/preview1",
                   data: '{strid: "' + id1 + '",strdeptid:"' + id2 + '"}',
                  
                   contentType: "application/json; charset=utf-8",
                   dataType: "json",
                   success: function (response) {
                       document.getElementById("<%=divReport1.ClientID%>").innerHTML = response.d; 
                       $('.button-checkbox').each(function () {

                           // Settings
                           var $widget = $(this),
                               $button = $widget.find('button'),
                               $checkbox = $widget.find('input:checkbox'),
                               color = $button.data('color'),
                               settings = {
                                   on: {
                                       icon: 'glyphicon glyphicon-check'
                                   },
                                   off: {
                                       icon: 'glyphicon glyphicon-unchecked'
                                   }
                               };

                           // Event Handlers
                           $button.on('click', function () {
                               $checkbox.prop('checked', !$checkbox.is(':checked'));
                               $checkbox.triggerHandler('change');
                               updateDisplay();
                           });
                           $checkbox.on('change', function () {
                               updateDisplay();
                           });

                           // Actions
                           function updateDisplay() {
                               var isChecked = $checkbox.is(':checked');

                               // Set the button's state
                               $button.data('state', (isChecked) ? "on" : "off");

                               // Set the button's icon
                               $button.find('.state-icon')
                                   .removeClass()
                                   .addClass('state-icon ' + settings[$button.data('state')].icon);

                               // Update the button's color
                               if (isChecked) {
                                   $button
                                       .removeClass('btn-d')
                                       .addClass('btn-' + color + ' active');
                               }
                               else {
                                   $button
                                       .removeClass('btn-' + color)
                                       .addClass('btn-d' + ' active');
                               }
                           }

                           // Initialization
                           function init() {

                               updateDisplay();

                               // Inject the icon if applicable
                               if ($button.find('.state-icon').length == 0) {
                                   $button.prepend('<i class="state-icon ' + settings[$button.data('state')].icon + '"></i> ');
                               }
                           }
                           init();
                       });
                   },
                   failure: function (response) {
                   }                 
               });
                return false;
                }


    </script>
     <script>
         var $au = jQuery.noConflict();
         $au(function () {
             $au('#cphMain_ddlMainDeptName').selectToAutocomplete1Letter();
         });
    </script>
    <script type="text/javascript">
        function ConfirmMessage() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "gen_Corp_DeptList.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "gen_Corp_DeptList.aspx";

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
                        window.location.href = "gen_Corp_Dept.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "gen_Corp_Dept.aspx";
                return false;
            }
            return false;
        }
        function UserLogoutConfirmation() {
            if (confirm("Are you Sure you want to logout ?")) {
                window.close();
                return true;
            }

            else
                return false;
        }
        function DuplicationName() {
            $("#divWarning").html("Duplication error!. Department name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtDeptName.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtDeptName.ClientID%>").focus();
        }

        function SuccessConfirmation() {
            $("#success-alert").html("Department details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("Department details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
         
        }
        function StateNameValidate() {           
            var ret = true;
            document.getElementById("<%=ddlBu.ClientID%>").style.borderColor = "";
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            var NameWithoutReplace = document.getElementById("<%=txtDeptName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtDeptName.ClientID%>").value = replaceText2;

            var Name = document.getElementById("<%=txtDeptName.ClientID%>").value.trim();
            $("div#divBu span.select2-selection--multiple").css("borderColor", "");
            document.getElementById("<%=txtDeptName.ClientID%>").style.borderColor = "";
            if (Name == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });              
                document.getElementById("<%=txtDeptName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtDeptName.ClientID%>").focus();
                ret= false;
            }
            // Show alert and return accordingly.
            if (document.getElementById("<%=ddlBu.ClientID%>").value == null || document.getElementById("<%=ddlBu.ClientID%>").value == "") {
                document.getElementById("<%=ddlBu.ClientID%>").style.borderColor = "Red";
                $("div#divBu span.select2-selection--multiple").css("borderColor", "red");
                $("#divBu").find(':input:visible:first').focus();
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                ret = false;
            }
            //return isAnyCheckBoxChecked;
            if (ret == false) {
                CheckSubmitZero();
            }
            else{
                document.getElementById("<%= HiddenFieldBusnsUnitValues.ClientID %>").value = "";
                document.getElementById("<%= HiddenFieldBusnsUnitValues.ClientID %>").value = $('#cphMain_ddlBu').val(); 
                document.getElementById("<%= HiddenFieldDivisionValues.ClientID %>").value = "";
                document.getElementById("<%= HiddenFieldDivisionValues.ClientID %>").value = $('#cphMain_ddlDiv').val(); 
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
       
        function SuccessMessage() {
            $("#success-alert").html("Welfare service saved successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function ValueNotFoundMessage() {

            $("#divWarning").html("Selected  welfare service not allowed.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("cphMain_divReport").style.borderColor = "Red";
        }     
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
      <asp:HiddenField ID="HiddenFieldDivisionValues" runat="server" />
       <asp:HiddenField ID="HiddenFieldBusnsUnitValues" runat="server" />
      <asp:HiddenField ID="HiddenDeptId" runat="server" />    <%--emp0025--%>
         <asp:HiddenField ID="hiddenRowCount" runat="server" /> 
     <asp:HiddenField ID="Hiddenchecklist" runat="server" /> 
       <asp:HiddenField ID="HiddenView" runat="server" /> 
     <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" /> 
    <asp:HiddenField ID="HiddenWelfareId" runat="server" /> 
       <asp:HiddenField ID="hiddenBuIds" runat="server" /> 
      <asp:HiddenField ID="hiddenDivIds" runat="server" /> 
    
    <ol class="breadcrumb">
       <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
      <li><a href="gen_Corp_DeptList.aspx">Corporate Department</a></li>
        <li id="lblEntryB" runat="server" class="active">Add Corporate Department</li>
      </ol>
   <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>

  <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">Add Corporate Department</h2>
        <div class="form-group fg4 sa_o_fg6 sa_2">
          <label for="email" class="fg2_la1">Department Name:<span class="spn1">*</span></label>
          <input id="txtDeptName"  runat="server" maxlength="150" style="text-transform: uppercase;" type="text"  class="form-control fg2_inp1 inp_mst"  placeholder="Department Name" name="" autocomplete="off">
        </div>
        <div class="form-group fg4 sa_o_fg6 sa_2">
          <label for="email" class="fg2_la1">Main Department:<span class="spn1"></span></label>
            <asp:DropDownList ID="ddlMainDeptName" class="form-control fg2_inp1" runat="server"></asp:DropDownList>
        </div>
        <div class="fg4 sa_2 sa_640_i ma_bo4" id="divBu">
          <label class="l_b">Business Units:<span class="spn1">*</span></label><br>
          <asp:DropDownList ID="ddlBu" onchange="ClickCbxCorp()"  class="form-control fg2_inp1 select2" data-placeholder="Select" multiple="multiple" runat="server">
          </asp:DropDownList>
        </div>
            <div class="clearfix"></div>
          <div class="fg4 sa_2 sa_640_i ma_bo4">
           <label class="l_b">Corporate Division:<span class="spn1"></span></label><br>
            <div class="fg8">
              <div class="input-group-addon date1 chec_bx act_cor">
                <div class="check1 c_flt_n">
                  <div class="">
                    <label class="switch">
                      <input type="checkbox" id="divCorpDivsns" onclick="enableDiv();">
                      <span class="slider_tog round"></span>
                    </label>
                  </div>
                </div>
              </div>
            </div>
               <div class="fg14">
            <asp:DropDownList ID="ddlDiv" onchange="ClickCbxDivsn();"  class="form-control fg2_inp1 tr_l divCs select2" data-placeholder="Select" multiple="multiple" runat="server">
          </asp:DropDownList>
            </div>
          </div>

          <div class="form-group fg7 fg2_mr sa_o_fg6">
            <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                  <input type="checkbox" id="cbDeptStatus" runat="server" checked="checked">
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>
          

        <div class="ed_se" style="display: block;" id="divWelfareService" runat="server">

          <div class="clearfix"></div>
          <div class="devider"></div>

          <h3>Welfare Services</h3>

          <div class="spl_hcm" id="divReport" runat="server">           
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


    <div class="modal fade" id="dialog_simple" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog mod1" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="divSeviceName" runat="server"></h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body md_bd">
          <div id="divErrorRsnAWMS" class="al-box war"></div>
          <div id="divReport1"  runat="server"> 
          </div>
        </div>
      <div class="modal-footer">

        <div class="sub_cont pull-right">
        <div class="save_sec">
           <asp:Button ID="btnRsnSave" class="btn sub1" runat="server" Text="Save" OnClientClick="return validateWelfare();" OnClick="btnRsnSave_Click"/>          
          <button type="submit" class="btn sub4" data-dismiss="modal">Close</button>
        </div>
      </div>
      </div>
    </div>
  </div>
</div>
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
    .fg14 .select2-container {
        width:335px !important;
    }
    </style>  
    <script>
        var ComInc = 1;
        var ComIncD = 1;
        function CheckBoxChange(count) {
            var RowCount = count;
            for (i = 0; i < RowCount; i++) {
                if (document.getElementById('cblwelfarescvc_' + i).checked == true) {
                    //document.getElementById('cbxSelectAll').checked = false;
                    $('#ReportTableWelfareH input[type=checkbox]:checked').click();
                    //$('#ReportTableWelfareH input[type=checkbox]:not(:checked)').click();
                }
            }
        }
        function selectAll(count) {  //EMP0025
          
            var RowCount = count;
         //   alert(RowCount);
                var strAmntList = "";
                if (document.getElementById('cbxSelectAll').checked == true) {
                    $('#ReportTableWelfare input[type=checkbox]:checked').click();
                    //for (i = 0; i < RowCount; i++) {
                    //    document.getElementById('cblwelfarescvc_' + i).checked = true;
                    //}
                }
                else {
                    $('#ReportTableWelfare input[type=checkbox]:not(:checked)').click();
                    //for (i = 0; i < RowCount; i++) {
                    //    document.getElementById('cblwelfarescvc_' + i).checked = false;
                    //}
                }
                document.getElementById("cbxSelectAll").click();
            }

        function getselected(rowCount) {   //EMP0025
   // alert('call');
            document.getElementById("<%=Hiddenchecklist.ClientID%>").value = [];
            $("#divWarning").html("Modified welfare limit will effect for all the employees in the selected department");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            //alert("Modified welfare limit will effect for all the employees in the selected department");

            // alert();
            var tbClientValues = '';
            tbClientValues = [];
            if (rowCount > 0) {
                MainTable = $('#ReportTableWelfare > tbody > tr');
                $(MainTable).each(function () {
                     
                    var RowId = $(this).attr('id');
                   
                
                    var SplitId = RowId.split('_');
                    var CntMain = SplitId[1];
                    //alert(CntMain+"ID");
                    if (SplitId[0] == "trId") {
                        if ($('#cblwelfarescvc_' + CntMain).length) {
                            //  alert('enter');
                            var checked = 0;
                            if ($('#cblwelfarescvc_' + CntMain).is(':checked')) {
                                checked = 1;
                            }
                            var chngsts = 0;
                           

                            // alert('enter2');
                           
                            // alert(document.getElementById('tdDepSubtId_' + CntMain).innerHTML + "LIMIT");
                            var MyTable = document.getElementById("tdchkSts_" + CntMain + "").innerHTML;
                            var DEPTID = document.getElementById("<%=HiddenDeptId.ClientID%>").value;
                            var SubId = document.getElementById('tdDepSubtId_' + CntMain).innerHTML;
                            //  alert(SubId+"sub");
                            var WELFARID = document.getElementById('tdWelfareId_' + CntMain).innerHTML;
                            var LIMIT = $('#txtlmt_' + CntMain).val();
                            var QtyLimt = document.getElementById('tdlimit1_' + CntMain).innerHTML;
                           // alert(DEPTID); alert(SubId); alert(WELFARID); alert(LIMIT);

                            var client = JSON.stringify({
                                DeptId: "" + DEPTID + "",
                                WelfareId: "" + WELFARID + "",
                                limit: "" + LIMIT + "",
                                WelfareSubId: "" + SubId + "",
                                chkSts: "" + MyTable + "",
                                CheckboxSts: "" + checked + "",
                                ActLimt: "" + QtyLimt + "",
                            });
                            tbClientValues.push(client);
                       
                    }
                    }
            
                });
            }
             //   alert(WelfareId);
     
            document.getElementById("<%=Hiddenchecklist.ClientID%>").value = JSON.stringify(tbClientValues);
      //alert(document.getElementById("<%=Hiddenchecklist.ClientID%>").value);
  
            //alert(DesgId);
        }




        function validateWelfare() {
            var ret = true;
            document.getElementById("divErrorRsnAWMS").style.display = "none";
            var totalRowCount = 0;

            var rowCount = 0;

            var table = document.getElementById("ReportTableWelfare");
          
            var rows = table.getElementsByTagName("tr")
        
            for (var i = 0; i < rows.length; i++) {

                totalRowCount++;

                if (rows[i].getElementsByTagName("td").length > 0) {

                    rowCount++;

                }

            }

            MainTable = $('#ReportTableWelfare > tbody > tr');

            var check = 0;
            for (var j = 0; j < rowCount; j++) {
                if ($('#cblwelfarescvc_' + j).is(':checked')) {
                    check = check + 1;
                    var LIMIT = $('#txtlmt_' + j).val().trim();
                    if (LIMIT == "") {
                        $('#txtlmt_' + j).css('border-color', 'red');

                        document.getElementById("divErrorRsnAWMS").innerHTML = "Welfare service limit should not be empty. Please check the highlighted fields below.";
                        document.getElementById("divErrorRsnAWMS").style.display = "";
                        ret = false;
                    }

                
                }
            }


           
            if (ret == true) {

                getselected(rowCount);
            }
            return ret;
                //alert(count);
                  
        }
        function isTagText(evt) {
            
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

            //0-9
            if (charCode >= 65 || charCode >= 90) {
                return false;
            }
            //numpad 0-9


            // . period and numpad . period
            if (keyCodes == 190 || keyCodes == 110) {
                var ret = false;

            }
            if (charCode == 8 || charCode == 46) {
                return true;
            }


            var tbClientValues = '';
            tbClientValues = [];
            //alert();
            MainTable = $('#ReportTable > li');

            $(MainTable).each(function () {
                var RowId = $(this).attr('id');
                // alert(RowId);
                var SplitId = RowId.split('_');
                var CntMain = SplitId[1];
                if (SplitId[0] == "trId") {


                    if ($('#cblwelfarescvc_' + CntMain).length) {

                       

                            var LIMIT = $('#txtlmt_' + CntMain).val().trim();
                            var QtyLimt = document.getElementById('tdlimit1_' + CntMain).innerHTML;
                            var mandatory = document.getElementById('tdChecked_' + CntMain).innerHTML;
                           
                                if (LIMIT == "") {
                                    $('#txtlmt_' + CntMain).css('border-color', 'red');


                                    document.getElementById("divErrorRsnAWMS").innerHTML = "Welfare service limit shoud not be empty. Please check the highlighted fields below.";
                                    document.getElementById("divErrorRsnAWMS").style.display = "";

                                   
                                
                                    return false;
                                }
                                else {
                                    $('#txtlmt_' + CntMain).css('border-color', '');
                                    document.getElementById("divErrorRsnAWMS").style.display = "none";
                                }
                                                 
                    }
                }
            });


            return ret;
        }

        function ClickCbxCorp() {
            // alert("2");
            if (ComInc == 0) {
                IncrmntConfrmCounter();
            }
            ComInc = 0;
            if ($('#cphMain_ddlBu').val() == null || $('#cphMain_ddlBu').val() == "") {
                document.getElementById("divCorpDivsns").disabled = true;
                $("#cphMain_ddlDiv").val(null).trigger("change");
                $(".fg14 .select2-selection__choice__remove").click();
                document.getElementById("cphMain_ddlDiv").disabled = true;
                document.getElementById("divCorpDivsns").checked = false;
            }
            else {
                document.getElementById("divCorpDivsns").disabled = false;
                var ChckedItems = $('#cphMain_ddlBu').val();
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "gen_Corp_Dept.aspx/GetDivisions",
                    data: '{ChckedItems:"' + ChckedItems + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function (response) {
                      //  alert(response.d);
                    },
                    error: function (response) {
                      //  alert(response.d);
                    }
                });
            }
        }


        function OnSuccess(response) {
            $("#cphMain_ddlDiv").val(null).trigger("change");
            if (response.d != "" && response.d != "null" && response.d != null) {
                document.getElementById("cphMain_ddlDiv").innerHTML = response.d;
                //New Code
                if (document.getElementById("<%= HiddenFieldDivisionValues.ClientID %>").value != "") {
                    var data = document.getElementById("<%=HiddenFieldDivisionValues.ClientID%>").value;
                    var eachString = data.split(',');
                    $noCon('#cphMain_ddlDiv').val(eachString);
                    $noCon("#cphMain_ddlDiv").trigger("change");
                    document.getElementById("divCorpDivsns").disabled = false;
                    document.getElementById("cphMain_ddlDiv").disabled = false;
                    document.getElementById("divCorpDivsns").checked = true;
                }
                else {
                    document.getElementById("divCorpDivsns").disabled = false;
                    document.getElementById("cphMain_ddlDiv").disabled = true;
                }
            }
            else {
                document.getElementById("divCorpDivsns").disabled = true;
                document.getElementById("cphMain_ddlDiv").disabled = true;
                document.getElementById("divCorpDivsns").checked = false;
            }
        }
        function enableDiv() {
            if (document.getElementById("divCorpDivsns").checked == true) {
                document.getElementById("cphMain_ddlDiv").disabled = false;
               
            }
            else {
              
                $("#cphMain_ddlDiv").val(null).trigger("change");
                $(".fg14 .select2-selection__choice__remove").click();
                document.getElementById("cphMain_ddlDiv").disabled = true;
            }
        }
        function ClickCbxDivsn() {
            if (ComIncD == 0) {
                IncrmntConfrmCounter();
            }
            ComIncD = 0;
        }
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            $noCon(".select2").select2();
            var data = document.getElementById("<%=HiddenFieldBusnsUnitValues.ClientID%>").value;
            var eachString = data.split(',');
            $noCon('#cphMain_ddlBu').val(eachString);
            $noCon("#cphMain_ddlBu").trigger("change");          
            if (document.getElementById("<%=lblEntry.ClientID%>").innerText == "VIEW CORPORATE DEPARTMENT") {              
                document.getElementById("divCorpDivsns").disabled = true;
                document.getElementById("cphMain_ddlDiv").disabled = true;
            }
        });
    </script>

    <style>
 .divCs{
    height: 32px;
    width: 100% !important;
    border-radius: 0px 4px 4px 0px;
}
    </style>
   

</asp:Content>

