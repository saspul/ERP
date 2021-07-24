<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Timeslot_Master.aspx.cs" Inherits="Master_gen_Timeslot_Master_gen_Timeslot_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/hcm_ns.css" rel="stylesheet" /> 
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
    <script type="text/javascript">

        function DuplicationName() {

            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtName.ClientID%>").focus();
            $("#divWarning").html("Duplication error!.Time slot name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function CheckTimeslot() {
          
                   
                    var ddlStartHr = document.getElementById("<%=ddlStartTime1.ClientID%>");
                    var SelectedStartHr = ddlStartHr.value;             
                   
                    var ddlStartMn = document.getElementById("<%=ddlStartTime2.ClientID%>");
                    var SelectedStartMn = ddlStartMn.value;

                    var ddlStartAm_Pm = document.getElementById("<%=ddlStartTime3.ClientID%>");
                     var SelectedStartAm_Pm = ddlStartAm_Pm.value;
             
                    
                    var ddlEndHr = document.getElementById("<%=ddlEndTime1.ClientID%>");
                    var SelectedEndHr = ddlEndHr.value;
             
                    var ddlEndMn = document.getElementById("<%=ddlEndTime2.ClientID%>");
                    var SelectedEndMn = ddlEndMn.value;
                    var ddlEndAm_Pm = document.getElementById("<%=ddlEndTime3.ClientID%>");
                   var SelectedEndAm_Pm = ddlEndAm_Pm.value;
                   
          
                  
                     
                     
                        if (SelectedStartAm_Pm == 2 && SelectedStartHr != 12) {
                           
                            SelectedStartHr =parseInt(SelectedStartHr) + 12;
                        
                        }
                        if (SelectedStartAm_Pm == 1 && SelectedStartHr == 12) {

                            SelectedStartHr = 0;
                        }

                        SelectedStartHr = parseInt(SelectedStartHr);
                        SelectedStartMn = parseInt(SelectedStartMn);

                        if (SelectedEndAm_Pm == 2 && SelectedEndHr != 12) {

                            SelectedEndHr = parseInt(SelectedEndHr) + 12;
                        }
                        if (SelectedEndAm_Pm == 1 && SelectedEndHr == 12) {

                            SelectedEndHr = 0;
                        }
                        SelectedEndHr = parseInt(SelectedEndHr);
                        SelectedEndMn = parseInt(SelectedEndMn);
                      
                  

                        if (SelectedStartAm_Pm == SelectedEndAm_Pm && SelectedStartHr == SelectedEndHr) {




                            if (SelectedStartMn == SelectedEndMn) {


                                $("#divWarning").html("Time slot error!. End time must be greater than start time.");
                                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                });
                                document.getElementById("<%=ddlEndTime1.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=ddlEndTime1.ClientID%>").focus();
                                return false;

                            }

                        }
                        else {
                            return true;
                        }
          
             
        
                  
           
        }

        function SuccessConfirmation() {
            $("#success-alert").html("Time slot details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("Time slot details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
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
            document.getElementById("<%=ddlEndTime1.ClientID%>").style.borderColor = "";
           document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlStartTime1.ClientID%>").style.borderColor = ""; 

            var Name = document.getElementById("<%=txtName.ClientID%>").value.trim();
            if (Name == "" ) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                    document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtName.ClientID%>").focus();
                    ret = false;
            }
            if (ret == true) {
                if (CheckTimeslot() == false) {
                    ret = false;
                    document.getElementById("<%=ddlEndTime1.ClientID%>").focus();
                }
            }
            if (ret == false) {
                CheckSubmitZero();
            }           
            return ret;
        }
    </script>

    <script  type="text/javascript">
        var submit = 0;
        function CheckIsRepeat() {
            if (++submit > 1) {
                // alert('An attempt was made to submit this form more than once; this extra attempt will be ignored.');
                return false;
            }
            else {
                return true;
            }
        } function CheckSubmitZero() {
            submit = 0;
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
                        window.location.href = "gen_Timeslot_Master_List.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "gen_Timeslot_Master_List.aspx";

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
                        window.location.href = "gen_Timeslot_Master.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "gen_Timeslot_Master.aspx";
                return false;
            }
            return false;
        }
        //stop-0006
    </script>

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
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
        });
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server"> 
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <ol class="breadcrumb">
       <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
      <li><a href="gen_Timeslot_Master_List.aspx">Time Slot</a></li>
        <li id="lblEntryB" runat="server" class="active">Add Time Slot</li>
      </ol>
   <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>

    <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">Add Time Slot</h2>        

        <div class="form-group fg2 sa_2 sa_480">
          <label for="email" class="fg2_la1">Time Slot Name:<span class="spn1">*</span></label>
            <asp:TextBox ID="txtName"  runat="server"  class="form-control fg2_inp1 inp_mst" placeholder="Time Slot Name" MaxLength="100" Style="text-transform: uppercase;"></asp:TextBox>
          
        </div>
        <div class="form-group sa_o_fg5 sa_640_i mar_at flt_l" style="width: 30%;">
          <label for="email" class="fg2_la1">Start Time:<span class="spn1">*</span></label>
          <div class="input-group flt_l mar_at" style="width:31%;">
             <asp:DropDownList class="form-control inp_bdr tr_c" type="text" id="ddlStartTime1" runat="server"></asp:DropDownList>
            <span class="input-group-addon date1">Hrs</span>
          </div>
          <div class="input-group fg4 ma_r1 sa_640_i2 sa_480_1 mar_4" style="width:31%;">
             <asp:DropDownList class="form-control inp_bdr tr_c" type="text" id="ddlStartTime2" runat="server"></asp:DropDownList>
             
            <span class="input-group-addon date1">Min</span>
          </div>
          <div class="fg2 sa_640_i2 sa_480_1 mar_4">
            <asp:DropDownList class="form-control inp_bdr tr_c" type="text" id="ddlStartTime3" runat="server">
              <asp:ListItem Text="AM" Value="1"></asp:ListItem>
                    <asp:ListItem Text="PM" Value="2"></asp:ListItem>
            </asp:DropDownList>
          </div>
        </div>
        
        <div class="form-group sa_o_fg5 sa_640_i mar_at flt_l" style="width: 28%;">
          <label for="email" class="fg2_la1">End Time:<span class="spn1">*</span></label>
          <div class="input-group flt_l mar_at" style="width:31%;">
            <asp:DropDownList class="form-control inp_bdr tr_c" type="text" id="ddlEndTime1" runat="server"></asp:DropDownList>
              
            <span class="input-group-addon date1">Hrs</span>
          </div>
          <div class="input-group fg4 ma_r1 sa_640_i2 sa_480_1 mar_4" style="width:33%;">
             <asp:DropDownList class="form-control inp_bdr tr_c" type="text" id="ddlEndTime2" runat="server"></asp:DropDownList>
            <span class="input-group-addon date1">Min</span>
          </div>
          <div class="fg2 sa_640_i2 sa_480_1 mar_4">
             <asp:DropDownList class="form-control inp_bdr tr_c" type="text" id="ddlEndTime3" runat="server">
              <asp:ListItem Text="AM" Value="1"></asp:ListItem>
                    <asp:ListItem Text="PM" Value="2"></asp:ListItem>
            </asp:DropDownList>
          </div>
        </div>

        <div class="form-group fg7 fg2_mr sa_2">
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
        <div class="free_sp"></div>
        <div class="devider"></div>

        <div class="sub_cont pull-right">
          <div class="save_sec">
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
      </div>
     <div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">
          <asp:Button ID="btnUpdateF" runat="server" class="btn sub1 bt_b" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnUpdateCloseF" runat="server" class="btn sub3 bt_b" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnAddF" runat="server" class="btn sub1 bt_b" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="btnAddCloseF" runat="server" class="btn sub3 bt_b" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
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
</asp:Content>

