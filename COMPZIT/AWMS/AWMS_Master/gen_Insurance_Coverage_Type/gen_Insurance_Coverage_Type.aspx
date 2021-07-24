<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Insurance_Coverage_Type.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Insurance_Coverage_Type_gen_Insurance_Coverage_Type" %>

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

    <script src="../../../JavaScript/jquery_2.1.3_jquery_min.js"></script>
    <link href="../../../JavaScript/ToolTip/jBox.css" rel="stylesheet" />
    <script src="../../../JavaScript/ToolTip/jBox.js"></script>

    <script>

        javascript
        new jBox('Tooltip', {
            attach: '.tooltip'
        });




    </script>
    <%--<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>--%>
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

    <script type="text/javascript">
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {



            //document.getElementById('cphMain_txtName').focus();
            //document.getElementById('cphMain_cbxStatus').checked = true;;
           // document.getElementById('cphMain_txtName').disabled = false;
          //  document.getElementById("<%=cbxStatus.ClientID%>").disabled = false;


        });
         

          function DuplicationName() {
         
          document.getElementById('divMessageArea').style.display = "";
          document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
              //evm-0023 changed alert command insurance category to insurance coverage for duplication
          document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.Insurance Coverage Name Can’t be Duplicated.";


        }


        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            //evm-0023 changed alert command insurance category to insurance coverage for insertion
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance Coverage Details Inserted Successfully.";
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            //evm-0023 changed alert command insurance category to insurance coverage for updation
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance Coverage Details Updated Successfully.";
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

           

                //}
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
                if (confirm("Are You Sure You Want To Leave This Page?")) {
                    window.location.href = "gen_Insurance_Coverage_Type_List.aspx";
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_Insurance_Coverage_Type_List.aspx";

            }
        }
        function AlertClearAll() {
            if (confirmbox > 0) {
                if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                    window.location.href = "gen_Insurance_Coverage_Type.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_Insurance_Coverage_Type.aspx";
                return false;
            }
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




    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="cont_rght">


        <div id="divMessageArea" style="display: none">
                 <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
     
        <br />

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 25%; top: 45%; height: 26.5px;">

            <%--<a href="gen_Vehicle_Class_Master_List.aspx">
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
                <h2>Coverage Type Name*</h2>
                
                <asp:TextBox ID="txtName" class="form1" runat="server"   MaxLength="100" Width="350px" Height="30px" TextMode="SingleLine" Style="resize:none; text-transform: uppercase; font-family: calibri;float: left;margin-left: 21.8%;"></asp:TextBox>
              
            </div>
             

           

            

            <div class="eachform" style="padding-top:8px;">
                <h2>Status*</h2>
                <div class="subform" style="margin-left: 36%;">
                    <asp:CheckBox ID="cbxStatus" Text="" runat="server" Checked="true" class="form2" />

                    <h3>Active</h3>

                </div>
            </div>
            <br />
            <div class="eachform">
                <div class="subform" style="width: 80%;margin-left:34.8%;padding-top: 5%;">

                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click"  />
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" PostBackUrl="gen_Insurance_Coverage_Type_List.aspx"  />
                     <asp:Button ID="btnClear" runat="server" style="margin-left: 19px;" OnClientClick="return AlertClearAll();"  class="cancel" Text="Clear"/>
                </div>
            </div>


        </div>
    </div>
</asp:Content>

