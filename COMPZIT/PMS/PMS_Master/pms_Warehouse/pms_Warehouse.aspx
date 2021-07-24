<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="pms_Warehouse.aspx.cs" Inherits="PMS_PMS_Master_pms_Warehouse_pms_Warehouse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/js/Common/Common.js"></script>


    <script>

        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }

        var $noCon = jQuery.noConflict();

        $noCon(window).load(function () {

        });


        function ConfirmMessageList() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "pms_Warehouse_List.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "pms_Warehouse_List.aspx";
                return false;
            }
            return false;
        }

        function AlertClearAll() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want clear all data in this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "pms_Warehouse.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "pms_Warehouse.aspx";
                return false;
            }
            return false;
        }

        function ConfirmMessage() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "pms_Warehouse_List.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
            }
            else {
                window.location.href = "pms_Warehouse_List.aspx";
                return false;
            }
            return false;
        }

        function ValidateWrhs() {

            var ret = true;

            document.getElementById("<%=ddlCountry.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAddress1.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtWrhsCode.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtWrhsName.ClientID%>").style.borderColor = "";

            var CntryId = document.getElementById("<%=ddlCountry.ClientID%>").value;
            var Address1 = document.getElementById("<%=txtAddress1.ClientID%>").value.trim();
            var Code = document.getElementById("<%=txtWrhsCode.ClientID%>").value.trim();
            var Name = document.getElementById("<%=txtWrhsName.ClientID%>").value.trim();

            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;

            var Phone = document.getElementById("<%=txtPhone.ClientID%>").value.trim();
            var Email = document.getElementById("<%=txtEmail.ClientID%>").value.trim();

            var flagPhone = 0;

            if (Email != "") {
                if (!filter.test(Email)) {
                    document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtEmail.ClientID%>").focus();
                    ret = false;
                }
            }
            if (Phone != "") {
                if (!mobileregular.test(Phone)) {
                    document.getElementById("<%=txtPhone.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtPhone.ClientID%>").focus();
                    ret = false;
                }
            }
            if (CntryId == "--Select Country--") {
                document.getElementById("<%=ddlCountry.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlCountry.ClientID%>").focus();
                ret = false;
            }
            if (Address1 == "") {
                document.getElementById("<%=txtAddress1.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtAddress1.ClientID%>").focus();
                ret = false;
            }
            if (Code == "") {
                document.getElementById("<%=txtWrhsCode.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtWrhsCode.ClientID%>").focus();
                ret = false;
            }
            if (Name == "") {
                document.getElementById("<%=txtWrhsName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtWrhsName.ClientID%>").focus();
                ret = false;
            }

            if (ret == false) {
                $("#danger-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
            }

            return ret;
        }

        function SuccessInsertion() {
            $("#success-alert").html("Warehouse inserted successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function SuccessUpdation() {
            $("#success-alert").html("Warehouse updated successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function DuplicationMsg() {
            document.getElementById("<%=txtWrhsName.ClientID%>").style.borderColor = "Red";
            $("#danger-alert").html("Duplication error! Warehouse name cannot be duplicated.");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function Error() {
            $("#danger-alert").html("Some error occured!");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <ol class="breadcrumb">
          <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Pms.aspx">Procurement Management</a></li>
        <li><a href="pms_Warehouse_List.aspx">Warehouse</a></li>
        <li class="active">Add Warehouse</li>
    </ol>

<!---alert_message_section---->
<div class="myAlert-top alert alert-success" id="success-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Success!</strong> Changes completed succesfully
</div>

<div class="myAlert-bottom alert alert-danger" id="danger-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Danger!</strong> Request not conmpleted
</div>
<!----alert_message_section_closed---->


  <a id="divList" href="javascript:;" onclick="return ConfirmMessageList()" type="button" class="list_b" title="Back to List">
    <i class="fa fa-arrow-circle-left"></i>
  </a>

    <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">

          <h1 class="h1_con"><asp:Label ID="lblEntry" runat="server">Add Warehouse</asp:Label></h1>

          <div class="form-group fg2 fg2_b">
            <label for="cphMain_txtWrhsName" class="fg2_la1">Warehouse Name:<span class="spn1">*</span></label>
            <asp:TextBox ID="txtWrhsName" runat="server" autocomplete="off" MaxLength="100" class="form-control fg2_inp1 fg_chs1 inp_mst" placeholder="Warehouse Name" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_txtWrhsName')"></asp:TextBox>   
          </div>
          <div class="form-group fg2 fg2_b">
            <label for="cphMain_txtWrhsCode" class="fg2_la1">Warehouse Code:<span class="spn1">*</span></label>
            <asp:TextBox ID="txtWrhsCode" runat="server" autocomplete="off" MaxLength="50" class="form-control fg2_inp1 fg_chs1 inp_mst" placeholder="Warehouse Code" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_txtWrhsCode')"></asp:TextBox>       
          </div>
          <div class="form-group fg2 fg2_b">
            <label for="email" class="fg2_la1">Address 1:<span class="spn1">*</span></label>
            <asp:TextBox ID="txtAddress1" runat="server" autocomplete="off" MaxLength="100" class="form-control fg2_inp1 fg_chs1 inp_mst" placeholder="Address 1" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_txtAddress1')"></asp:TextBox>           
          </div>

          <div class="form-group fg2 fg2_b">
            <label for="cphMin_txtAddress2" class="fg2_la1">Address 2:<span class="spn1"></span></label>
            <asp:TextBox ID="txtAddress2" runat="server" autocomplete="off" MaxLength="100" class="form-control fg2_inp1 fg_chs1" placeholder="Address 2" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_txtAddress2')"></asp:TextBox>           
          </div>

          <div class="form-group fg2 fg2_b">
            <label for="cphMain_txtxAddress3" class="fg2_la1">Address 3:<span class="spn1"></span></label>
            <asp:TextBox ID="txtAddress3" runat="server" autocomplete="off" MaxLength="100" class="form-control fg2_inp1 fg_chs1" placeholder="Address 2" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_txtAddress3')"></asp:TextBox>        
          </div>

          <asp:UpdatePanel ID="updPanelTempl" runat="server" EnableViewState="true" UpdateMode="Conditional">
              <ContentTemplate>

          <div class="form-group fg2 fg2_b">
            <label for="email" class="fg2_la1">Country:<span class="spn1">*</span></label>
            <asp:DropDownList ID="ddlCountry" class="form-control fg2_inp1 fg_chs1 inp_mst" runat="server" onkeypress="return DisableEnter(event)" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>          
          </div>

          <div class="form-group fg2 fg2_b">
            <label for="email" class="fg2_la1">State:<span class="spn1"></span></label>
            <asp:DropDownList ID="ddlState" class="form-control fg2_inp1 fg_chs1" runat="server" onkeypress="return DisableEnter(event)" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>           
          </div>

          <div class="form-group fg2 fg2_b">
            <label for="email" class="fg2_la1">City:<span class="spn1"></span></label>
            <asp:DropDownList ID="ddlCity" class="form-control fg2_inp1 fg_chs1" runat="server" onkeypress="return DisableEnter(event)"></asp:DropDownList>             
          </div>

             </ContentTemplate>
          </asp:UpdatePanel>

          <div class="form-group fg2 fg2_b">
            <label for="email" class="fg2_la1">Postal Code:<span class="spn1"></span></label>
            <asp:TextBox ID="txtPostalCode" runat="server" autocomplete="off" MaxLength="20" class="form-control fg2_inp1 fg_chs1" placeholder="Postal Code" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_txtPostalCode')"></asp:TextBox>               
          </div>

          <div class="form-group fg2 fg2_b">
            <label for="email" class="fg2_la1">Phone#:<span class="spn1"></span></label>
            <asp:TextBox ID="txtPhone" runat="server" autocomplete="off" MaxLength="20" class="form-control fg2_inp1 fg_chs1" placeholder="Phone#" onkeydown="return isNumber(event);" onkeypress="return isNumber(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveNaN_OnBlur('cphMain_txtPhone')"></asp:TextBox>              
          </div>

          <div class="form-group fg2 fg2_b">
            <label for="email" class="fg2_la1">Email ID:<span class="spn1"></span></label>
            <asp:TextBox ID="txtEmail" runat="server" autocomplete="off" MaxLength="100" class="form-control fg2_inp1 fg_chs1" placeholder="Email ID" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" onblur="RemoveTag('cphMain_txtEmail')"></asp:TextBox>                  
          </div>

          <div class="form-group fg2 fg2_b">
            <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
                <label class="switch">
                  <input id="cbxStatus" type="checkbox" runat="server"  checked="checked" onkeypress="return DisableEnter(event)" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
          </div>

      <div class="clearfix"></div>
      <div class="free_sp"></div>

          <div class="sub_cont pull-right">
            <div class="save_sec">
              <asp:Button ID="btnSave"  runat="server" OnClientClick="return ValidateWrhs();" class="btn sub1" Text="Save" OnClick="btnSave_Click" />
              <asp:Button ID="btnSaveAndClose"  runat="server" OnClientClick="return ValidateWrhs();" class="btn sub3" Text="Save & Close" OnClick="btnSave_Click" />
              <asp:Button ID="btnUpdate"  runat="server" OnClientClick="return ValidateWrhs();" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" />
              <asp:Button ID="btnUpdateAndClose"  runat="server" OnClientClick="return ValidateWrhs();" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" />
              <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
              <asp:Button ID="btnCancel" runat="server" OnClientClick="return ConfirmMessage();" class="btn sub4" Text="Cancel" />
            </div>
          </div>


        </div>
      </div>
  </div>

</asp:Content>

