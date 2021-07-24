<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Cost_Group.aspx.cs" Inherits="FMS_FMS_Master_fms_Cost_Group_fms_Cost_Group" %>


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
            var group = document.getElementById("<%=ddlLevel.ClientID%>").value;
            document.getElementById("<%=ddlLevel.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";


            if (name == "") {
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
               
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtName.ClientID%>").focus();

                ret = false;
            }
            if (group == "--SELECT LEVEL--") {
                document.getElementById("<%=ddlLevel.ClientID%>").style.borderColor = "Red";

                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    document.getElementById("<%=ddlLevel.ClientID%>").focus();
                });
               



                ret = false;
            }

            return ret;
        }

</script>
    <script type="text/javascript">
        var $noCon = jQuery.noConflict();



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
        //function textCounter(field, maxlimit) {       
        //    RemoveTag();
        //    RemoveDescTag();
        //    if (field.value.length > maxlimit) {
        //        field.value = field.value.substring(0, maxlimit);
        //    } else {
        //        isTag(event);
        //    }
        //}
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


        function SuccessConfirmation() {
            document.getElementById("<%=txtName.ClientID%>").focus();
            $noCon("#success-alert").html("Cost group details inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            
            return false;


        }
        function SuccessUpdation() {
            document.getElementById("<%=txtName.ClientID%>").focus();
            $noCon("#success-alert").html("Cost group details updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            
            return false;
                    }
        function DuplicationName() {
          document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
          document.getElementById("<%=txtName.ClientID%>").focus();

          $noCon("#divWarning").html("Duplication Error!.Cost Group name can’t be duplicated.");
          $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
          });
         
          return false;


        }

        function DuplicationCode() {
            document.getElementById("<%=txtCode.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtCode.ClientID%>").focus();

                 $noCon("#divWarning").html("Duplication Error!.Cost Group code can’t be duplicated.");
                 $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                 });
                
                 return false;


             }


        function AlreadyCancelMsg() {
            $noCon("#divWarning").html("Cost group is already cancelled");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
           
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
                      window.location.href = "fms_Cost_Group_List.aspx";
                  }
                  else {
                      document.getElementById("<%=txtName.ClientID%>").focus();
                      return false;
                  }
              });
              return false;
          }
          else {
              window.location.href = "fms_Cost_Group_List.aspx";
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
                      window.location.href = "fms_Cost_Group.aspx";
                  }
                  else {
                      return false;
                  }
              });
              return false;
          }
          else {
              window.location.href = "fms_Cost_Group.aspx";
              return false;
          }
      }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="HiddenCodeFormate" runat="server" />
    <asp:HiddenField ID="HiddenCostGroupCode" runat="server" />

    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li><a href="fms_Cost_Group_List.aspx">Cost Group List</a></li>
        <li class="active">Cost Group</li>
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
                    <asp:Label ID="lblEntry" runat="server"></asp:Label>
                </h2>

                <div class="form-group fg2">
                    <label for="email" class="fg2_la1">Cost Group Name:<span class="spn1">*</span></label>
                    <asp:TextBox class="form-control fg2_inp1 inp_mst" ID="txtName" runat="server" autocomplete="off" onchange="IncrmntConfrmCounter();" MaxLength="100" onkeypress="return DisableEnter(event)" onkeyup="textCounter(cphMain_txtName,100)"></asp:TextBox>
                </div>

                <div class="form-group fg2">
                    <label for="email" class="fg2_la1">Level:<span class="spn1">*</span></label>
                    <asp:DropDownList ID="ddlLevel" Class="form-control fg2_inp1 inp_mst" runat="server" onchange="return  IncrmntConfrmCounter();" onkeypress="return isTagEnter(event)">
                    </asp:DropDownList>
                </div>

                <div class="form-group fg2" id="DivCostGroupCode" runat="server">
                    <label for="email" class="fg2_la1">Code:<span class="spn1"></span></label>
                    <asp:TextBox class="form-control fg2_inp1" Enabled="false" ID="txtCode" runat="server" autocomplete="off" onchange="IncrmntConfrmCounter();" MaxLength="40" onkeypress="return DisableEnter(event)" onkeyup="textCounter(cphMain_txtCode,40)"></asp:TextBox>
                </div>

                <div class="form-group fg2">
                    <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
                    <div class="check1">
                        <div class="">
                            <label class="switch">
                                <input type="checkbox" id="CheckBox1" onchange="IncrmntConfrmCounter();" checked="checked" onkeypress="return DisableEnter(event)" runat="server" />
                                <span class="slider_tog round"></span>
                            </label>
                        </div>
                    </div>
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
                        <input type="button" id="btnCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn sub4" />
                        <asp:Button ID="ButtnClose" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                    </div>
                </div>


            </div>
              <div id="divList" runat="server" class="list_b" style="cursor: pointer;" onclick="return ConfirmMessage()" title="Back to List">
                    <i class="fa fa-arrow-circle-left"></i>
                </div>
        </div>
    </div>

</asp:Content>



