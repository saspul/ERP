<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage_Compzit_GMS.master" AutoEventWireup="true" CodeFile="gen_Insurance_Type_Master.aspx.cs" Inherits="GMS_GMS_Master_gen_Insurance_Type_Master_gen_Insurance_Type_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
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

    <script src="../../../JavaScript/jquery-1.8.2.min.js"></script>
    <script type="text/javascript">

        function DuplicationName() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error!. Insurance type name can’t be duplicated.";
        }

        function CrossDeleted() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "This action is  denied! This insurance type is already cancelled.";
        }

        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance type details inserted successfully.";
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance type details updated successfully.";
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
            document.getElementById('divMessageArea').style.display = "none";
            document.getElementById('imgMessageArea').src = "";
            if (Name == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                if (Name == "") {
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtName.ClientID%>").focus();
                ret = false;
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
            var confirmbox = 0;

            function IncrmntConfrmCounter() {               
                confirmbox++;
            }

            function ConfirmMessage() {
                if (confirmbox > 0) {
                    if (confirm("Are you sure you want to leave this page?")) {
                        window.location.href = "gen_Insurance_Type_Master_List.aspx";
                    }
                    else {
                        return false;
                    }
                }
                else {
                    window.location.href = "gen_Insurance_Type_Master_List.aspx";

                }
            }

            function AlertClearAll() {
                if (confirmbox > 0) {
                    if (confirm("Are you sure you want clear all data in this page?")) {
                        window.location.href = "gen_Insurance_Type_Master.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    window.location.href = "gen_Insurance_Type_Master.aspx";
                    return false;
                }
            }


            function AlertCancel() {
                if (confirmbox > 0) {
                    if (confirm("Are you sure you want cancel this page?")) {
                        window.location.href = "gen_Insurance_Type_Master_List.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    window.location.href = "gen_Insurance_Type_Master_List.aspx";
                    return false;
                }
            }

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
    </script>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    
        <div id="divMessageArea" style="display: none">
                 <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
     
        <br />

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 25%; top: 42%; height: 26.5px;">

            <%--<a href="gen_Job_Master_List.aspx">
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
                <h2>Insurance type name*</h2>
                
                <asp:TextBox ID="txtName" class="form1" runat="server"   MaxLength="100" Width="325px" Height="30px" TextMode="SingleLine" Style="resize:none; font-family: calibri;float: left;margin-left: 17.5%;"></asp:TextBox>
              
            </div>

            <div class="eachform">
                <h2>Status*</h2>
                <div class="subform" style="margin-left: 32.3%;">
                    <asp:CheckBox ID="cbxStatus" Text="" runat="server" Checked="true" class="form2" />

                    <h3>Active</h3>

                </div>
            </div>
            <br />
            <div class="eachform" style="margin-top: 4%;">
                <div class="subform" style="width: 80%;">

                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click"  />
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" OnClientClick="return AlertCancel();"/>
                     <asp:Button ID="btnClear" runat="server" style="margin-left: 19px;" OnClientClick="return AlertClearAll();"  class="cancel" Text="Clear"/>
                </div>
            </div>


        </div>
</asp:Content>

