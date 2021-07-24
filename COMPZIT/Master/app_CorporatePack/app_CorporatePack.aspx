<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_App.master" AutoEventWireup="true" CodeFile="app_CorporatePack.aspx.cs" Inherits="Master_app_CorporatePack_app_CorporatePackAdd" %>

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
                       window.location.href = "app_CorporatePackList.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "app_CorporatePackList.aspx";

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
            margin-left: 40.1%;
        }
    </style>

    <script type="text/javascript">

        function DuplicationName() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%= txtCorpPackName.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Duplication Error!. Corporate Name Can’t be Duplicated.";
        }
        function DuplicationCount() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=txtCorpPackCount.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Duplication Error!. Corporate Office Count Can’t be Duplicated";
        }
        function SuccessConfirmation() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Corporate Pack Details Inserted Successfully.";
        }
        function SuccessUpdation() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Corporate Pack Details Updated Successfully.";
        }
        function Validate() {
            //      CheckIsRepeat();
          
            var ret = true;

            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtCorpPackName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCorpPackName.ClientID%>").value = replaceText2;

            var Count = document.getElementById("<%=txtCorpPackCount.ClientID%>").value.trim();
            var Name = document.getElementById("<%=txtCorpPackName.ClientID%>").value.trim();

            document.getElementById("<%=txtCorpPackName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCorpPackCount.ClientID%>").style.borderColor = "";
            if ((Name == "") || (Count == "")) {
                document.getElementById('divErrorTotal').style.visibility = "visible";
                document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                if (Count == "") {

                    document.getElementById("<%=txtCorpPackCount.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtCorpPackCount.ClientID%>").focus();
                    ret = false;
                }
                if (Name == "") {

                    document.getElementById("<%=txtCorpPackName.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtCorpPackName.ClientID%>").focus();
                    ret = false;
                }
               
            }

            if (ret == false)
            {
                CheckSubmitZero();

            }
    
            return ret;
        }



    </script>
   
    <script type="text/javascript" language="javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //enter
            if (keyCodes == 13) {
             //   return false;
            }
                //0-9
            else if (keyCodes >= 48 && keyCodes <= 57) {
                return true;
            }
                //numpad 0-9
            else if (keyCodes >= 96 && keyCodes <= 105) {
                return true;
            }
                //left arrow key,right arrow key,home,end ,delete,UP ARROW ,DOWN ARROW
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                return true;

            }
            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                }
                return ret;
            }
        }
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
        function Range() {
            var txt = document.getElementById("<%=txtCorpPackCount.ClientID%>").value;

            if (txt != "") {

                if (isNaN(txt)) {
                    document.getElementById("<%=txtCorpPackCount.ClientID%>").value = "";
                    document.getElementById("<%=txtCorpPackCount.ClientID%>").focus();
                    return false;

                }
                var input = parseInt(txt);
                if (input < 1 || input > 99) {
                     alert("Corporate Pack Count should be between 0 - 100");

                    document.getElementById("<%=txtCorpPackCount.ClientID%>").value = "";
                    document.getElementById("<%=txtCorpPackCount.ClientID%>").focus();
                    return false;
                }

            }
        }

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="cont_rght">
        <div id="divErrorTotal" style="visibility: hidden">
            <asp:Label ID="lblErrorTotal" runat="server"></asp:Label>
        </div>
        <br />
        <br />
        <br />

         <div  id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:25%; top:42%; height:26.5px;">

            <%-- <a href="app_CorporatePackList.aspx">
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


                <h2>Corporate Pack Name*</h2>

                <asp:TextBox ID="txtCorpPackName" class="form1" runat="server" MaxLength="100" Height="30px" Width="350px" Style="text-transform: uppercase; margin-left: 15%;"></asp:TextBox>



            </div>
            <div class="eachform">

                <h2>Count of Corporate Offices*</h2>

                <asp:TextBox ID="txtCorpPackCount" runat="server" class="form1" Height="30px" Width="350px" onblur="return Range();" Style="margin-left: 10%;"></asp:TextBox>

            </div>
            <div class="eachform">


                <h2>Status</h2>
                <div class="subform">
                    <asp:CheckBox ID="cbxStatus" Text="" runat="server" Checked="true" class="form2" />

                    <h3>Active</h3>
                </div>


            </div>

            <br/>
            <div class="eachform" >
                <div class="subform" style="width:380px;margin-left:46.5%">
                
                        <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();  " />
                         <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                     <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return Validate(); " />
                         <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return Validate();" />
                     <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" PostBackUrl="app_CorporatePackList.aspx" />


                   
                </div>
            </div>



        </div>
    </div>
</asp:Content>
