<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_App.master" AutoEventWireup="true" CodeFile="gen_OrganisationType.aspx.cs" Inherits="Master_gen_OrganisationType_gen_OrganisationTypeAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

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
    </script>
     <script>
         //start-0006
         var confirmbox = 0;

         function IncrmntConfrmCounter() {
             confirmbox++;
         }
         function ConfirmMessage() {
             if (confirmbox > 0) {
                 if (confirm("Are You Sure You Want To Leave This Page?")) {
                     window.location.href = "gen_OrganisationtypeList.aspx";
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_OrganisationtypeList.aspx";

             }
         }
         //stop-0006

    </script>
    <style>
        .fillform {
            width: 70%;
        }

        .subform {
            float: left;
            margin-left: 38.8%;
        }

        /**/

        /*.aspNetDisabled {
            margin-left: -31%;
        }


        input[type=text][disabled="disabled"] {
            margin-left: 18.5% !important;
            height: 30px !important;
        }

        select[disabled="disabled"] {
            margin-left: 28% !important;
            width: 358px!important;
            height: 30px !important;
        }*/
    </style>
     <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script>
        //for disable second click
        $(function () {

            $('#btnAdd').click(function () {

                $(this).attr("disabled", true);
                $(this).val('Please wait Processing');

            })
        })
    </script>
    <script type="text/javascript">

        function DuplicationName() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=txtOrgTypeName.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Duplication Error!. Organisation Type Name Can’t be Duplicated.";
        }

        function SuccessConfirmation() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Organisation Type Details Inserted Successfully.";
        }
        function SuccessUpdation() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Organisation Type Details Updated Successfully.";
        }
        function Validate() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            var NameWithoutReplace = document.getElementById("<%=txtOrgTypeName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgTypeName.ClientID%>").value = replaceText2;

            document.getElementById('divErrorTotal').style.visibility = "hidden";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "";
            document.getElementById("<%=txtOrgTypeName.ClientID%>").style.borderColor = "";
            var Name = document.getElementById("<%=txtOrgTypeName.ClientID%>").value.trim();
            if (Name == "") {
                document.getElementById('divErrorTotal').style.visibility = "visible";
                document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtOrgTypeName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtOrgTypeName.ClientID%>").focus();
                ret= false;
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

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">

    <asp:HiddenField ID="hiddenDsgnTypId" runat="server" />

    <div class="cont_rght">
        <div id="divErrorTotal" style="visibility: hidden">
            <asp:Label ID="lblErrorTotal" runat="server"></asp:Label>
        </div>
        <br />
        <br />
        <br />
        <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:25%; top:42%; height:26.5px;">

           <%--  <a href="gen_OrganisationtypeList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>

        <div class="fillform">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
            <br />

            <div class="eachform">
            
              
                        <h2>Organisation Type Name*</h2>

                        <asp:TextBox ID="txtOrgTypeName" class="form1" Height="30px" Width="350px" runat="server" MaxLength="100" Style="text-transform: uppercase;margin-left: 15%;"></asp:TextBox>
                    
               
            </div>
            <div class="eachform">
                 <h2>Status*</h2>
              
                    <div class="subform">
                     

                        <asp:CheckBox ID="cbxStatus" Text="" runat="server" Checked="true" class="form2" />
                         <h3>Active</h3>

                    </div>

            </div>
            <br />
            <div class="eachform">
                <div class="subform" style="width: 53%;">
                 
                       
                        <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return Validate(); " />
                      <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return Validate(); " />
                        <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate(); " />
                    <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate(); " />
                     <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" PostBackUrl="gen_OrganisationTypeList.aspx" />
                   
                </div>
            </div>
        </div>

    </div>
</asp:Content>
