<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage/MasterPageCompzit.master" CodeFile="gen_Fuel_Type_Master.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Fuel_Type_Master_gen_Fuel_Type_Master" %>
           
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/js/Common/Common.js"></script>
    <link href="/css/New%20css/hcm_ns.css" rel="stylesheet" />

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
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "gen_Fuel_Type_Master_List.aspx";
                    }
                    else {
                        return false;
                    }
                })
            }
            else {
                window.location.href = "gen_Fuel_Type_Master_List.aspx";

            }
        }

        function AlertClearAll() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want clear all data in this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "gen_Fuel_Type_Master.aspx";
                    }
                    else {
                        return false;
                    }
                })
            }
            else {
                window.location.href = "gen_Fuel_Type_Master.aspx";
            }
        }

    </script>

    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

        });

        function SelectImage(ImageId) {

            IncrmntConfrmCounter();
            var oldImage = document.getElementById("<%=hiddenSelectedImage.ClientID%>").value;
            if (oldImage != "") {
                document.getElementById("btn-" + oldImage).style.backgroundColor = "";
            }
            document.getElementById("<%=hiddenSelectedImage.ClientID%>").value = ImageId;
            document.getElementById("btn-" + ImageId).style.backgroundColor = "#172643";
            return false;
        }

    </script>
    <script type="text/javascript">

        function FillVehicleClassTextBox(ImageId) {
            if (ImageId != "") {
                document.getElementById("btn-" + ImageId).style.backgroundColor = "#172643";
                document.getElementById("<%=hiddenSelectedImage.ClientID%>").value = ImageId;
            }
        }

        function DuplicationName() {
            $("#danger-alert").html("Duplication error!. Fuel type name can’t be duplicated.");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessConfirmation() {
            $("#success-alert").html("Fuel type details inserted successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpdation() {
            $("#success-alert").html("Fuel type details updated successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessReOpen() {
            $("#success-alert").html("Fuel type details reopened successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessConfirm() {
            $("#success-alert").html("Fuel type details confirmed successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function FuelTypeValidate() {

            var $noCon = jQuery.noConflict();
            var ret = true;
            if (CheckIsRepeat() == true) {

            }
            else {
                ret = false;
                return ret;
            }

            // replacing < and > tags 
            var CrdNumWithoutReplace = document.getElementById("<%=txtName.ClientID%>").value;
            var replaceText1 = CrdNumWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtName.ClientID%>").value = replaceText2;

            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";

            var CardNum = document.getElementById("<%=txtName.ClientID%>").value.trim();

            if (document.getElementById("<%=hiddenSelectedImage.ClientID%>").value == "") {
                $("#danger-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted field below.");
                $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                $('.box_veh').css("borderColor", "Red");
                ret = false;
            }
            else {
                document.getElementById('cphMain_divImageContainer').style.borderColor = "";
            }
            if (CardNum == "") {
                $("#danger-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted field below.");
                $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtName.ClientID%>").focus();
                ret = false;
            }
            else {
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";
            }

            if (ret == false) {
                CheckSubmitZero();
            }
            return ret;
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="hiddenCancelReason" runat="server" />
    <asp:HiddenField ID="hiddenRoleReOpen" runat="server" />
    <asp:HiddenField ID="hiddenRoleConfirm" runat="server" />
    <asp:HiddenField ID="hiddenSelectedImage" runat="server" />

<!---breadcrumb_section_started---->    
    <ol class="breadcrumb">
      <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_Awms.aspx">AWMS</a></li>
      <li><a href="/AWMS/AWMS_Master/gen_Fuel_Type_Master/gen_Fuel_Type_Master_List.aspx">Fuel Type</a></li>
      <li class="active">Add Fuel Type</li>
    </ol>

<!---breadcrumb_section_started----> 

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

  <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr">
        <h2><asp:Label ID="lblEntry" runat="server"></asp:Label></h2>

        <div class="form-group fg4 sa_fg1">
          <label for="email" class="fg2_la1">Fuel Type Name:<span class="spn1">*</span></label>
          <asp:TextBox ID="txtName" class="form-control fg2_inp1 inp_mst" runat="server" MaxLength="50" Style="text-transform: uppercase;" placeholder="Fuel Type Name"></asp:TextBox>
        </div>

        <div class="form-group fg2 sa_fg1">
          <div class="box_veh fuel">
              <div id="divImageContainer" runat="server"></div>
          </div>
        </div>

        <div class="form-group fg7 fg2_mr sa_fg1">
          <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
          <div class="check1">
            <div class="">
              <label class="switch">
                <input id="cbxStatus" type="checkbox" runat="server" onkeydown="return DisableEnter(event)" Checked="true" /> 
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
              <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return FuelTypeValidate();"/>
              <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return FuelTypeValidate();"/>
              <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return FuelTypeValidate();"/>
              <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return FuelTypeValidate();"/>
              <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" PostBackUrl="~/AWMS/AWMS_Master/gen_Fuel_Type_Master/gen_Fuel_Type_Master_List.aspx"/>
              <asp:Button ID="btnClear" runat="server" class="btn sub2" Text="Clear" OnClientClick="return AlertClearAll();" OnClick="btnClear_Click" />
          </div>
        </div>
        
      </div>
    </div>
    </div>

<a id="divList" href="javascript:;" runat="server" onclick="return ConfirmMessage()" type="button" class="list_b" title="Back to List">
<i class="fa fa-arrow-circle-left"></i>
</a>

 
</asp:Content>