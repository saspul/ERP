<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="AccountGroup.aspx.cs" Inherits="FMS_Account_Group_AccountGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
    
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
            var $noCon1 = jQuery.noConflict();
            $noCon1(window).load(function () {
               
               
            });
            function isTag(evt) {

                evt = (evt) ? evt : window.event;
                var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                //if (keyCodes == 13) {
                //    return false;
                //}
                var charCode = (evt.which) ? evt.which : evt.keyCode;
                var ret = true;
                if (charCode == 60 || charCode == 62) {
                    ret = false;
                }
                return ret;
            }
            // for not allowing enter
            function DisableEnter(evt) {
                //  var b = new Date(); alert(b);

                evt = (evt) ? evt : window.event;
                var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                if (keyCodes == 13) {
                    return false;
                }
            }
            function SuccessConfirmation() {
                $noCon("#success-alert").html("Account group inserted successfully.");
                $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                return false;
            }

            function SuccessUpdation() {
                $noCon("#success-alert").html("Account group updated successfully.");
                $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                return false;
            }
            function DuplicationMsg() {
                document.getElementById("<%=txtAccountName.ClientID%>").style.borderColor = "Red";
                $noCon("#divWarning").html("Duplication error! Group name cannot be duplicated.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                return false;
            }
            function DuplicationCodeMsg() {
                document.getElementById("<%=txtGrpCode.ClientID%>").style.borderColor = "Red";
                $noCon("#divWarning").html("Duplication error! Group code cannot be duplicated.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                return false;
            }

            function AlreadyCancelMsg() {
                $noCon("#divWarning").html("Account group is already cancelled");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                return false;
            }
            var confirmbox = 0;

            function IncrmntConfrmCounter() {
                confirmbox++;
            }

            //function AutoCompletePrntGrp() {
            //    $au('#cphMain_ddlParntGrp').selectToAutocomplete1Letter();
            //    return false;
            //}
            function ConfirmMessage() {
                if (confirmbox > 0) {
                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure you want to leave this page?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            window.location.href = "Account_Group_List.aspx";
                        }
                        else {
                            return false;
                        }
                    });
                    return false;
                }
                else {
                    document.getElementById("<%=BtnList.ClientID%>").click();
                    //  return true;
                }
                return false;
            }

            function ConfirmMessageList() {
                if (confirmbox > 0) {
                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure you want to leave this page?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            window.location.href = "Account_Group_List.aspx";
                        }
                        else {
                            return false;
                        }
                    });
                    return false;
                }
                else {
                    document.getElementById("<%=BtnList.ClientID%>").click();
                }
                return false;
            }
    </script>
  
    <style>
        input[type="radio"] {
            display: table-cell;
        }
                      .inptxtDisable {
    width: 82%;
    background-color: #efefef;
    border: 1px solid #ccc;
    border-radius: 0px;
    font-family: OpenSans Regular;
    box-shadow: 0 1px 1px rgba(0, 0, 0, 0.075) inset;
    font-size: 14px;
    height: 30px;
    padding: 0 12px;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:HiddenField ID="HiddenEditable" runat="server" />
    <asp:HiddenField ID="HiddenDirctIndirect" runat="server" />
    <asp:HiddenField ID="HiddenCodeFormate" runat="server" />
    <asp:HiddenField ID="HiddenView" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>


    <ol class="breadcrumb sticky1">
          <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li><a href="Account_Group_List.aspx">Account Group</a></li>
        <li class="active">Add Account Group</li>
    </ol>

    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">
            <div class="alert alert-danger" id="divWarning1" style="display: none">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
            <div class="alert alert-success" id="success-alert1" style="display: none">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
            <div class="content_box1 cont_contr">
                <div id="divReportCaption" runat="server" >
                   
             <h2>      <asp:Label ID="lblEntry" runat="server"> Add Account Group</asp:Label></h2> 
                </div>
                

                <div class="form-group fg5">
                    <label for="email" class="fg2_la1">Group Name:<span class="spn1">*</span></label>
                    <asp:TextBox ID="txtAccountName" runat="server" autocomplete="off"  MaxLength="100" class="form-control fg2_inp1 inp_mst" onkeydown="return  IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" onkeyup="textCounter(cphMain_txtAccountName,100)" Style=""></asp:TextBox>
                </div>
                <div class="form-group fg5">
                    <label for="email" class="fg2_la1">Group Code:<span class="spn1"></span></label>
                    <asp:TextBox ID="txtGrpCode" runat="server" autocomplete="off"  MaxLength="40" class="form-control fg2_inp1" onkeydown="return  IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" onkeyup="textCounter(cphMain_txtGrpCode,40)"></asp:TextBox>
                   
                </div>


                <asp:UpdatePanel ID="UpdatePanel1" EnableViewState="true" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>


                        <div class="form-group fg5">
                            <label for="email" class="fg2_la1">Parent Group:<span class="spn1">*</span></label>
                            <div id="divddlParntGrp">
                                <asp:DropDownList ID="ddlParntGrp" Style="" class="form-control fg2_inp1 inp_mst"  runat="server"  onkeypress="return DisableEnter(event)" AutoPostBack="true" OnSelectedIndexChanged="ddlParntGrp_SelectedIndexChanged1"  ></asp:DropDownList><%--OnSelectedIndexChanged="ddlParntGrp_SelectedIndexChanged1"--%>
                            </div>
                        </div>


                        <div class="form-group fg5">
                            <label for="email" class="fg2_la1">Nature:<span class="spn1">*</span></label>
                           <%-- <asp:DropDownList ID="ddlNature" class="form-control fg2_inp1 inp_mst fg_chs1" runat="server" onchange="NatureChange(1);" onkeypress="return DisableEnter(event)" Style="">--%>
                             <asp:DropDownList ID="ddlNature" class="form-control fg2_inp1 inp_mst fg_chs1" runat="server" onkeypress="return DisableEnter(event)" Style="">

                                <asp:ListItem Text="Asset" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Liability" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Expense" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Income" Value="3"></asp:ListItem>

                            </asp:DropDownList>
                            <script>
                               
                                function NatureChange(x) {
                                    var end = document.getElementById("<%=ddlNature.ClientID%>").value;

                                    //alert(document.getElementById("<%=HiddenEditable.ClientID%>").value);

                                    if (end == "3") {

                                        document.getElementById("<%=DivNature.ClientID%>").style.display = "block";
                                        document.getElementById("<%=divtype.ClientID%>").style.display = "block";
                                        if (document.getElementById("<%=HiddenEditable.ClientID%>").value == "") {

                                            if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                                                document.getElementById("<%=radioDirect.ClientID%>").disabled = false;
                                                document.getElementById("<%=radioIndirect.ClientID%>").disabled = false;
                                                document.getElementById("<%=cbxGrossProfit.ClientID%>").disabled = false;
                                            }

                                            else {
                                                document.getElementById("<%=radioDirect.ClientID%>").disabled = true;
                                                document.getElementById("<%=radioIndirect.ClientID%>").disabled = true;
                                                document.getElementById("<%=cbxGrossProfit.ClientID%>").disabled = true;

                                            }
                                        }
                                        else {
                                            document.getElementById("<%=radioDirect.ClientID%>").disabled = true;
                                            document.getElementById("<%=radioIndirect.ClientID%>").disabled = true;
                                            document.getElementById("<%=cbxGrossProfit.ClientID%>").disabled = true;
                                        }

                                        document.getElementById("<%=divtype.ClientID%>").style.marginTop = "0%";
                                    }
                                    else if (end == "2") {
                                        document.getElementById("<%=DivNature.ClientID%>").style.display = "block";
                                        document.getElementById("<%=divtype.ClientID%>").style.display = "block";
                                        if (document.getElementById("<%=HiddenEditable.ClientID%>").value == "") {
                                            if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                                                document.getElementById("<%=radioDirect.ClientID%>").disabled = false;
                                                document.getElementById("<%=radioIndirect.ClientID%>").disabled = false;
                                                document.getElementById("<%=cbxGrossProfit.ClientID%>").disabled = false;
                                            }
                                            else {
                                                document.getElementById("<%=radioDirect.ClientID%>").disabled = true;
                                                document.getElementById("<%=radioIndirect.ClientID%>").disabled = true;
                                                document.getElementById("<%=cbxGrossProfit.ClientID%>").disabled = true;

                                            }
                                        }
                                        else {
                                            document.getElementById("<%=radioDirect.ClientID%>").disabled = true;
                                            document.getElementById("<%=radioIndirect.ClientID%>").disabled = true;
                                            document.getElementById("<%=cbxGrossProfit.ClientID%>").disabled = true;
                                        }
                                    }
                                    else {
                                        document.getElementById("<%=DivNature.ClientID%>").style.display = "block";
                                        document.getElementById("<%=divtype.ClientID%>").style.display = "block";
                                        document.getElementById("<%=radioDirect.ClientID%>").disabled = true;
                                        document.getElementById("<%=radioIndirect.ClientID%>").disabled = true;

                                        document.getElementById("<%=cbxGrossProfit.ClientID%>").disabled = true;
                                        if (x == 1) {
                                            document.getElementById("<%=cbxGrossProfit.ClientID%>").checked = false;
                                        }

                                    }
                                    if (x == 1) {

                                        var orgID = '<%= Session["ORGID"] %>';
                                        var corptID = '<%= Session["CORPOFFICEID"] %>';
                                        var acntgrpId = document.getElementById("<%=ddlParntGrp.ClientID%>").value;


                                        var CodeSts = document.getElementById("<%=HiddenCodeFormate.ClientID%>").value;
                                        if (CodeSts == 0) {
                                            
                                           $.ajax({
                                            type: "POST",
                                            async: false,
                                            contentType: "application/json; charset=utf-8",
                                             url: "AccountGroup.aspx/CrateCodeFormate",
                                            data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",AcntGrpIdId: "' + acntgrpId + '"}',

                                            dataType: "json",
                                             success: function (data) {
                                              if (data.d != "") {

                                               document.getElementById("<%=txtGrpCode.ClientID%>").value = data.d;
                                               }

                                            }
                                             });
                                        }
                                    }

                                }

                    var $noCon = jQuery.noConflict();
                    function ValidatAccountGrp() {
                        var ret = true;
                        $au("div#divddlParntGrp input.ui-autocomplete-input").css("borderColor", "");
                        var AccountName = document.getElementById("<%=txtAccountName.ClientID%>").value;
                        AccountName = AccountName.trim();
                        var AccountParent = document.getElementById("<%=ddlParntGrp.ClientID%>").value;
                    var nat = document.getElementById("<%=ddlNature.ClientID%>").value;
                        //alert(AccountParent);
                        if (AccountName == "") {
                            document.getElementById("<%=txtAccountName.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtAccountName.ClientID%>").focus();
                        ret = false;
                    }
                    if (AccountParent == "") {
                        $au("div#divddlParntGrp input.ui-autocomplete-input").css("borderColor", "Red");
                        $au("div#divddlParntGrp input.ui-autocomplete-input").focus();
                        $au("div#divddlParntGrp input.ui-autocomplete-input").select();
                        //document.getElementById("<%=ddlParntGrp.ClientID%>").style.borderColor = "Red";
                            //  document.getElementById("<%=ddlParntGrp.ClientID%>").focus();
                            ret = false;
                        }
                        if (nat == "") {
                            $au("div#divddlParntGrp input.ui-autocomplete-input").css("borderColor", "Red");
                            $au("div#divddlParntGrp input.ui-autocomplete-input").focus();
                            $au("div#divddlParntGrp input.ui-autocomplete-input").select();
                            //   document.getElementById("<%=ddlParntGrp.ClientID%>").style.borderColor = "Red";
                            //   document.getElementById("<%=ddlParntGrp.ClientID%>").focus();
                            ret = false;
                        }
                        if (ret == false) {
                            $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            //  $noCon("#divWarning").alert();
                            $noCon1(window).scrollTop(0);
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
                                    window.location.href = "AccountGroup.aspx";
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

                            </script>


                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="form-group fg5">
                    <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">&nbsp;</span></label>
                    <div class="check1">
                            <label class="switch">
                                <input type="checkbox" runat="server"  checked="checked" onkeypress="return DisableEnter(event)" id="ChkStatus" />
                                <span class="slider_tog round"></span>
                            </label>
                    </div>
                </div>

                <div class="clearfix"></div>
                <div class="free_sp"></div>
                <div class="devider"></div>


                <!---text_Area_section_started--->
  <div class="text_area_container"   id="DivNature" runat="server">
    <div class="col-md-6 mar_a flt_l" id="divGrossProfit" runat="server">
        <div class="col-md-6 mar_a flt_l">
               <div class="form1 mar_bo">
                    <div class="check2">
                            <label class="switch">
                                <input type="checkbox" runat="server"  checked="checked" onkeypress="return DisableEnter(event)" id="cbxGrossProfit" />
                                <span class="slider_tog round"></span>
                            </label>
                    </div>
                   <label for="cphMain_cbxGrossProfit" class="pz_s pa_tp0">Does it effect profit statement?</label>
                </div>
            </div>
         <div class="col-md-6 mar_a flt_l">
        <div id="divtype" runat="server" style="display:none;">
            <div  class="form-group fogp rati_1">
              <label for="cphMain_radioDirect" class="fg2_la1 pa_tp0">
                  <input name="radioDirect" type="radio" id="radioDirect" onchange="CheckDirect();" onkeypress="return DisableEnter(event)" runat="server" style="display: block;" class="pa_tp0" />         
              Direct</label>
           </div>

            <div class="form-group fogp rati_1">
              <label for="cphMain_radioIndirect" class="fg2_la1 pa_tp0">
                <input name="radioDirect" type="radio" id="radioIndirect" onchange="Checkindirect();" onkeypress="return DisableEnter(event)" runat="server" style=" display: block;" class="pa_tp0" />
              Indirect</label>
            </div>
            </div>
             </div>
          </div>
      
      <div class="col-md-6 mar_a flt_l">
                <div class="form1 mar_bo">
                    <div class="check2">
                            <label class="switch">
                                <input type="checkbox" runat="server"  checked="checked" onkeypress="return DisableEnter(event)" id="ChkAddressSts" />
                                <span class="slider_tog round"></span>
                            </label>
                     </div>
                    <label for="cphMain_ChkAddressSts" class="pz_s pa_tp0">Whether address entry allowed while account head creation?</label>
                </div>
          <br />
      </div>
  </div>
                <div class="sub_cont pull-right" style="padding: 9px;">
                    <div class="save_sec">
                        <asp:Button ID="btnsave"  runat="server" OnClientClick="return ValidatAccountGrp();" class="btn sub1" Text="Save" OnClick="btnsave_Click" />
                        <asp:Button ID="btnsaveAndClose"  runat="server" OnClientClick="return ValidatAccountGrp();" class="btn sub3" Text="Save & Close" OnClick="btnsave_Click" />
                        <asp:Button ID="btnUpdate"  runat="server" OnClientClick="return ValidatAccountGrp();" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnUpdateAndClose"  runat="server" OnClientClick="return ValidatAccountGrp();" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnCancel" runat="server" OnClientClick="return ConfirmMessage();" class="btn sub4" Text="Cancel" OnClick="btnCancel_Click" />

                        <asp:Button ID="ButtnClose"  runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                        <asp:Button ID="BtnList" runat="server" Style="display: none" OnClick="BtnList_Click" />
                    </div>
                    <div class="edit_sec">
                    </div>
                </div>
            </div>
 </div>
        </div>
      <!---alert_message_section---->
<div class="myAlert-top alert alert-success" id="success-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Success!</strong> Changes completed succesfully
</div>

        <div class="myAlert-bottom alert alert-danger" id="divWarning">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Danger!</strong> Request not conmpleted
        </div>
        <script>
            function opensave() {
                document.getElementById("mySave").style.width = "140px";
                mysave();
            }
            function closesave() {
                document.getElementById("mySave").style.width = "0px";
            }
            function mysave() {
                var x = document.getElementById("mySave");
                if (x.style.display === "block") {
                    x.style.display = "none";
                } else {
                    x.style.display = "block";
                }
            }

        </script>


        <div id="divList" class="list_b" style="cursor: pointer;" onclick="return ConfirmMessageList()" title="Back to List">
            <i class="fa fa-arrow-circle-left"></i>
        </div>

     <script>

         var $au = jQuery.noConflict();

         (function ($au) {
             $au(function () {

                 NatureChange(0);


                 var prm = Sys.WebForms.PageRequestManager.getInstance();
                 //  prm.add_initializeRequest(InitializeRequest);
                 prm.add_endRequest(EndRequest);


                 $au('#cphMain_ddlParntGrp').selectToAutocomplete1Letter();
               
                 //  $au('#cphMain_ddlLeavTyp').selectToAutocomplete1Letter();

                 $au('form').submit(function () {

                     //   alert($au(this).serialize());


                     //   return false;
                 });
             });
         })(jQuery);

         //function InitializeRequest(sender, args) {
         //}
         function CheckDirect() {
             IncrmntConfrmCounter();
           
             document.getElementById("<%=HiddenDirctIndirect.ClientID%>").value ="0";
          
            
         }
         function Checkindirect() {
             IncrmntConfrmCounter();
             document.getElementById("<%=HiddenDirctIndirect.ClientID%>").value = "1";
      
 
            
         }

         function EndRequest(sender, args) {
             // after update occur on UpdatePanel re-init the Autocomplete
             NatureChange(1);
             $au('#cphMain_ddlParntGrp').selectToAutocomplete1Letter();
         
             // $au('#cphMain_ddlEmployee').autocomplete("destroy");

         }





                    </script>



</asp:Content>

