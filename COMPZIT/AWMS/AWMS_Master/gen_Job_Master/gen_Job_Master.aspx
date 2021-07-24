<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Job_Master.aspx.cs" Inherits="AWMS_AWMS_Master_Job_Master_Job_mater" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/js/Common/Common.js"></script>
    <link href="/css/New%20css/hcm_ns.css" rel="stylesheet" />

    <script type="text/javascript">

        function DuplicationName() {
            $("#danger-alert").html("Duplication error!. Job title can’t be duplicated.");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessConfirmation() {
            $("#success-alert").html("Job details inserted successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpdation() {
            $("#success-alert").html("Job details updated successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
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

            NameWithoutReplace = document.getElementById("<%=txtDescpn.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtDescpn.ClientID%>").value = replaceText2;

            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";
            var Name = document.getElementById("<%=txtName.ClientID%>").value.trim();

            if (Name == "") {
                $("#danger-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtName.ClientID%>").focus();
                ret = false;
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
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "gen_Job_Master_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
            }
            else {
                window.location.href = "gen_Job_Master_List.aspx";

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
                        window.location.href = "gen_Job_Master.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
            }
            else {
                window.location.href = "gen_Job_Master.aspx";
                return false;
            }
        }

        //stop-0006
    </script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
 
<!---breadcrumb_section_started---->    
    <ol class="breadcrumb">
      <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_Awms.aspx">AWMS</a></li>
      <li><a href="/AWMS/AWMS_Master/gen_Job_Master/gen_Job_Master_List.aspx">Fuel Type</a></li>
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

        <div class="form-group fg2 sa_2 sa_480">
          <label for="email" class="fg2_la1">Job Tittle:<span class="spn1">*</span></label>
          <asp:TextBox ID="txtName" runat="server" class="form-control fg2_inp1 inp_mst" placeholder="Job Tittle" MaxLength="100" Style=" text-transform: uppercase;"></asp:TextBox>
        </div>

        <div class="form-group fg4 sa_640">
              <label for="email" class="fg2_la1">Job Description:<span class="spn1"></span></label>
              <asp:TextBox ID="txtDescpn" runat="server" MaxLength="500" rows="3" cols="30" class="form-control flt_l tb_in" placeholder="Job Description" TextMode="MultiLine" Style="resize:none;" onkeydown="textCounter(cphMain_txtDescpn,450)" onkeyup="textCounter(cphMain_txtDescpn,450)"></asp:TextBox>
            </div>

            <div class="form-group fg2 fg2_mr sa_fg1">
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
              <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
              <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click"  />
              <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
              <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
              <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" PostBackUrl="gen_Job_Master_List.aspx"  />
              <asp:Button ID="btnClear" runat="server" class="btn sub2" Text="Clear" OnClientClick="return AlertClearAll();" />
          </div>
        </div>
        
      </div>
    </div>
    </div>

<a id="divList" href="javascript:;" runat="server" onclick="return ConfirmMessage();" type="button" class="list_b" title="Back to List">
<i class="fa fa-arrow-circle-left"></i>
</a>


</asp:Content>


