<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Memo_Reason_Master.aspx.cs" Inherits="HCM_HCM_Master_hcm_Employee_Conduct_Management_hcm_Memo_Reason_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
        <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
    
    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="/js/jQueryUI/jquery-ui.min.js"></script>
    <script src="/js/jQueryUI/jquery-ui.js"></script>
    <script src="/js/HCM/Common.js"></script>
    
    <script type="text/javascript">
        var $noCon = jQuery.noConflict();
        function RemoveTag() {
            var SearchWithoutReplace = document.getElementById("<%=RsnNme.ClientID%>").value;
             var replaceText1 = SearchWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=RsnNme.ClientID%>").value = replaceText2;

            var SearchWithoutReplace = document.getElementById("<%=RsnNme.ClientID%>").value;
             var replaceText1 = SearchWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=RsnNme.ClientID%>").value = replaceText2;
        }
        function RemoveDescTag() {
            var SearchWithoutReplace = document.getElementById("<%=txtDesc.ClientID%>").value;
             var replaceText1 = SearchWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtDesc.ClientID%>").value = replaceText2;

             var SearchWithoutReplace = document.getElementById("<%=txtDesc.ClientID%>").value;
             var replaceText1 = SearchWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtDesc.ClientID%>").value = replaceText2;
         }

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
        function textCounter(field, maxlimit) {        //emp25
            RemoveTag();
            RemoveDescTag();
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {
                isTag(event);
            }
        }
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


        function ReasonValidate() {


            var RsnName = document.getElementById("<%=RsnNme.ClientID%>").value.trim();
            var RsnDesc = document.getElementById("<%=txtDesc.ClientID%>").value.trim();
            document.getElementById("<%=RsnNme.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtDesc.ClientID%>").style.borderColor = "";

            var ret = true;

            if (RsnName == "" && RsnDesc == "") {
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#divWarning").alert();
                document.getElementById("<%=RsnNme.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=RsnNme.ClientID%>").focus();
                 document.getElementById("<%=txtDesc.ClientID%>").style.borderColor = "Red";
              
                 return false;




             }
            if (RsnName == "") {
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#divWarning").alert();
                document.getElementById("<%=RsnNme.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=RsnNme.ClientID%>").focus();
                return false;

               
               

            }
           

            if (RsnDesc == "") {

                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#divWarning").alert();
                document.getElementById("<%=txtDesc.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtDesc.ClientID%>").focus();
                ret = false;

            }
            return ret;

        }
        function MemoSuccessConfirmation() {

            $noCon("#success-alert").html("Conduct category inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
          
         
        }
        function MemoSuccessUpdation() {
            $noCon("#success-alert").html("Conduct category updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
         
        }
        function DuplicationName() {
            document.getElementById("<%=RsnNme.ClientID%>").style.borderColor = "Red";
           document.getElementById("<%=RsnNme.ClientID%>").focus();

           $noCon("#divWarning").html("Duplication Error!.Conduct category name can’t be duplicated.");
           $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
           });
           $noCon("#divWarning").alert();

           return false;


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
                        window.location.href = "hcm_Memo_Reason_Master_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "hcm_Memo_Reason_Master_List.aspx";
            }
        }

        //EVM-0024
        //function ConfirmMessage() {

        //    ezBSAlert({
        //        type: "confirm",
        //        messageText: "Are you sure you want to leave this Page?",
        //        alertType: "info"
        //    }).done(function (e) {
        //        if (e == true) {
        //            window.location.href = "hcm_Memo_Reason_Master_List.aspx";
        //        }

        //        else {
        //            window.location.href = "hcm_Memo_Reason_Master.aspx";
        //        }
        //    });
        //    return false;

        //}
        //end

        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }
   

    </script>
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
            <asp:HiddenField ID="hiddenupd" runat="server" />
     <asp:HiddenField ID="HiddenFieldQryString" runat="server" />
    <div class="cont_rght" style="width: 90%">
         <div id="divMessageArea" style="display: none; margin: 0px 0 13px; width: 89%;">
            <img id="imgMessageArea" src="">
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
         <div class="alert alert-success" id="success-alert" style="display: none;margin-left: 0%;width: 98%;">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
         <div class="alert alert-danger" id="divWarning" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>
         <div  id="divList"  class="list" runat="server" style="position: fixed; right: 5%; top: 42%; height: 26.5px;" onclick=" ConfirmMessage()">

           
        </div>

        <br />

     <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <asp:Label ID="lblEntry" runat="server"></asp:Label>
        </div>
    <br />
        <br />
    <div style="float: left;

width: 88%;

padding: 2%;
display: block;"
>

           <div class="eachform" style="float: left; width: 63%;margin-left: 17%; font-family: calibri;">
                <h2 style="width: 38%;">Category Name*</h2>
                <asp:TextBox ID="RsnNme" class="form1" runat="server" MaxLength="50" Width="50%" Height="30px" onkeypress="return  isTag(event);" onblur="return textCounter(cphMain_RsnNme,190)" onkeydown=" return textCounter(cphMain_RsnNme,150)" Style="resize: none; text-transform: uppercase; font-family: calibri; " TabIndex="1"></asp:TextBox>
            </div>
            <div class="eachform" style="float: left; width: 63%;margin-left: 17%; font-family: calibri;">    <%--emp25--%>
                <h2 style="width: 38%;">Description*</h2>
                <asp:TextBox ID="txtDesc" class="form1" TextMode="MultiLine"  runat="server"  MaxLength="1000" Width="50%" Height="80px" onkeypress="return  isTagEnter(event);" onblur="return textCounter(cphMain_txtDesc,990)" onkeydown=" return textCounter(cphMain_txtDesc,990)"  Style="resize: none;  font-family: calibri;" TabIndex="2"></asp:TextBox>
            </div>
        


           
            <div class="eachform"  style="width:57%;padding-top: 2%;float: left;margin-left: 17%;">
                  <h2>Status</h2>
                <div class="subform" style="margin-right: 18%; ">


                    <asp:CheckBox ID="CbxStatus" Text="" runat="server" onkeydown="return DisableEnter(event)"  onchange="IncrmntConfrmCounter();" class="form2" style="float: left;margin-left: 44%;" TabIndex="3" Checked="true"/>
                    <h3>Active</h3>

                </div>                

            </div>

        </div>


            <br />
        <div class="eachform">
            <div class="subform" style="width: 72%; margin-top: 5%;float: left;margin-left: 43%;">


               
                <asp:Button ID="btnAdd" runat="server" class="btn btn-primary" Text="Save" OnClientClick=" return ReasonValidate();" OnClick="btnAdd_Click" TabIndex="4"/>
                <asp:Button ID="btnAddClose" runat="server" class="btn btn-primary" Text="Save & Close" TabIndex="5"  OnClientClick=" return ReasonValidate();" OnClick="btnAdd_Click" />
                <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary"  Text="Update" TabIndex="6"  OnClientClick=" return ReasonValidate();" OnClick="btnUpdate_Click"/>
                <asp:Button ID="btnUpdateClose" runat="server" class="btn btn-primary"  Text="Update & Close" TabIndex="7"   OnClientClick=" return ReasonValidate();" OnClick="btnUpdate_Click"/>
                 <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" OnClientClick="return ConfirmMessage();" TabIndex="8" />
            </div>
        </div>
        </div>


</asp:Content>

