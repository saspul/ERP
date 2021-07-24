<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" CodeFile="gen_Holiday_Master.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Holiday_Master_gen_Holiday_Master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

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
                   if (confirm("Are You Sure You Want To Leave This Page?")) {
                       window.location.href = "gen_Holiday_Master_List.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "gen_Holiday_Master_List.aspx";

               }
           }

           function AlertClearAll() {
               if (confirmbox > 0) {
                   if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                       window.location.href = "gen_Holiday_Master.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "gen_Holiday_Master.aspx";

               }
           }


    </script>

     <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            //document.getElementById("<%=txtDate.ClientID%>").focus();

            if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {

                IncrmntConfrmCounter();
            }

       
        });
    </script>

        <script type="text/javascript">

           
            function DuplicationName() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=txtHolidayTitle.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtHolidayTitle.ClientID%>").focus();
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Holiday Title Can’t be Duplicated.";
               
            }
            function DuplicationDate() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtDate.ClientID%>").focus();
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Holiday Date Can’t be Duplicated.";

            }
     
            function SalaryProcessed() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = " Sorry!. Salary have been already  proccessed for this holiday date .";
             }

            function SuccessConfirmation() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Holiday Details Inserted Successfully.";
            }

            function SuccessUpdation() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Holiday Details Updated Successfully.";
            }

            function SuccessReOpen() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Holiday Details Re-Opened Successfully.";
            }

            function SuccessConfirm() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Holiday Details Confirmed Successfully.";
            }

            function WaterCardValidate() {
               
            var $noCon = jQuery.noConflict();
            var ret = true;
            if (CheckIsRepeat() == true) {
            
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var CrdNumWithoutReplace = document.getElementById("<%=txtHolidayTitle.ClientID%>").value;
            var replaceText1 = CrdNumWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtHolidayTitle.ClientID%>").value = replaceText2;

                var CrdExpWithoutReplace = document.getElementById("<%=txtDate.ClientID%>").value;
                var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
                var replaceCode2 = replaceCode1.replace(/>/g, "");
                document.getElementById("<%=txtDate.ClientID%>").value = replaceCode2;
 
               document.getElementById("<%=txtHolidayTitle.ClientID%>").style.borderColor = "";
               document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "";
            
                var CardNum = document.getElementById("<%=txtHolidayTitle.ClientID%>").value.trim();
                var HolDat = document.getElementById("<%=txtDate.ClientID%>").value.trim();
 
                var Moddl = document.getElementById("<%=ddlHolMode.ClientID%>");
                var HolMod = Moddl.options[Moddl.selectedIndex].text;

                var Typddl = document.getElementById("<%=ddlHolType.ClientID%>");
                var HolTyp = Typddl.options[Typddl.selectedIndex].text;
                var hiddnstrid=  document.getElementById("<%=hiddenstrid.ClientID%>").value;
                if (hiddnstrid == "0") {
                    if (HolDat != "") {

                        var TaskdatepickerDate = document.getElementById("<%=txtDate.ClientID%>").value;
                        var arrDatePickerDate = TaskdatepickerDate.split("-");
                        var dateDateCntrlr = new Date(arrDatePickerDate[2]);

                        var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                        var arrCurrentDate = CurrentDateDate.split("-");
                        var dateCurrentDate = new Date(arrCurrentDate[2]);
                        if (dateDateCntrlr < dateCurrentDate) {

                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, Issue Year Should Be Greater or Equal to Current Year !";
                            ret = false;

                        }

                    }
                }
  

               

            if (HolTyp == "--SELECT HOLIDAY TYPE--") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                     document.getElementById("<%=ddlHolType.ClientID%>").style.borderColor = "Red";
                                 document.getElementById("<%=ddlHolType.ClientID%>").focus();
                    ret = false;
            }
                else
            {
                document.getElementById("<%=ddlHolType.ClientID%>").style.borderColor = "";
            }
                if (HolMod == "--SELECT HOLIDAY MODE--") {

                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=ddlHolMode.ClientID%>").style.borderColor = "Red";

                       document.getElementById("<%=ddlHolMode.ClientID%>").focus();
                       ret = false;
                   }
                   else {

                       document.getElementById("<%=ddlHolMode.ClientID%>").style.borderColor = "";
                   }
                               
                if (CardNum == "") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtHolidayTitle.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtHolidayTitle.ClientID%>").focus();
                    ret = false;
                }
                else {
                    document.getElementById("<%=txtHolidayTitle.ClientID%>").style.borderColor = "";

                }


                if (HolDat == "") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtDate.ClientID%>").focus();
                    ret = false;
                }
                else {
                    document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "";
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
              //  var b = new Date(); alert(b);

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

            function isNumber(evt, textboxid) {
                evt = (evt) ? evt : window.event;
                var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                var charCode = (evt.which) ? evt.which : evt.keyCode;

                var txtPerVal = document.getElementById(textboxid).value;
                //enter
                if (keyCodes == 13) {
                    return false;
                }
                    //0-9
                else if (keyCodes >= 48 && keyCodes <= 57) {
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

                    var count = txtPerVal.split('.').length - 1;

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
           

            function ConfirmReOpen() {
                if (confirm("Are You Sure You Want To Re-Open This Page?")) {
                    return true;
                }
                else {
                    return false;
                }
            }
            function ConfirmAlert()
            {
                if (WaterCardValidate() == true)
                {
                    if (confirm("Are You Sure You Want To Confirm ?")) {
                        return true;
                    }
                    else {
                        CheckSubmitZero();
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
    </script>
         <style type="text/css">
       
                
              
                        .imgDescription {
            position: absolute;
            /*top: 511px;
            left: 6.5%;*/
            background: rgb(154, 163, 138);
            visibility: hidden;
            opacity: 0;
            padding: 0.1%;
            font-family: Calibri;
            /*remove comment if you want a gradual transition between states
  -webkit-transition: visibility opacity 0.2s;
  */
        }

        .imgWrap:hover .imgDescription {
            visibility: visible;
            opacity: 1;
        }
   
    </style>
 
    <script>




        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

      

                $au('form').submit(function () {

                 
                });
            });
        })(jQuery);





                    </script>
   
    <%--FOR DATE TIME PICKER--%>
<script type="text/javascript" src="../../../JavaScript/Date/JavaScriptDate1_8_3.js"></script>                      
<script type="text/javascript" src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
<script type="text/javascript" src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
<script type="text/javascript"src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
<link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
<link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />

     <style>

           .textDate:focus {
            border: 1px solid #bbf2cf;
            box-shadow: 0px 0px 4px 2.5px #bbf2cf;
        }
        .textDate {
            border: 1px solid #cfcccc;
        }
            .open > .dropdown-menu {
    display: none;
             }

            .bootstrap-datetimepicker-widget {

    z-index: 100;
}
              .eachform h2 {
                margin: 6px 0 6px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
     <asp:HiddenField ID="hiddenCancelReason" runat="server" />
    <asp:HiddenField ID="hiddenRoleReOpen" runat="server" />
    <asp:HiddenField ID="hiddenRoleConfirm" runat="server" />
      <asp:HiddenField ID="hiddenRoleAdd" runat="server" />
    <asp:HiddenField ID="hiddenstrid" runat="server" />
    <div class="cont_rght">


                   <div id="divMessageArea" style="display: none; margin:0px 0 13px;">
                 <img id="imgMessageArea" src="" >
                <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>

     <br />

          <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:5%; top:42%;height:26.5px;">

            <%-- <a href="gen_ProductBrandList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>

        <div class="fillform" style="width:100%;">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
            <br />

                   <div id="divImage" style="float: right;margin-right:30%;margin-top:-7%">
                       
                        <asp:ImageButton ID="imgbtnReOpen" runat="server" OnClientClick="return ConfirmReOpen();" Style="margin-left: 0%;" OnClick="imgbtnReOpen_Click" />
                         <p id="imgReOpen" class="imgDescription" style="color: white">Re-Open Confirmed Entry</p>
                    </div>
         <div class="eachform" style="width:49%">
              <h2>Date*</h2>
               <div id="WaterCardExpiry" class="input-append date" style="font-family:Calibri;float:right;width:57.5%">
                 <asp:TextBox ID="txtDate" class="textDate" onchange="IncrmntConfrmCounter()" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width:83%;height:23px; font-family: calibri;" ></asp:TextBox>

                        <img id= "imgDate" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style=" height:17px; width:12px; cursor:pointer;" />

                        <script type="text/javascript">
                            var $noCo = jQuery.noConflict();
                            var year = (new Date).getFullYear();

                             $noCo('#WaterCardExpiry').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                
                                startDate: new Date(year, '0','2'),

                            });
                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                   </div>
                         <div class="eachform"" style="width:49%;float: right;">
                              <h2>Holiday Title*</h2>
                <asp:TextBox ID="txtHolidayTitle" Height="30px" Width="50%" class="form1" runat="server" MaxLength="50" Style="text-transform: uppercase; margin-right: 4%;"></asp:TextBox>
                  </div>
            <div id="divBank" class="eachform"  style="width:49%">

                <h2>Holiday Mode*</h2>
                <asp:DropDownList ID="ddlHolMode" Height="30px" Width="53%" class="form1" onkeydown="return DisableEnter(event)" runat="server" Style="margin-right: 4%;">
                      <asp:ListItem Text="--SELECT HOLIDAY MODE--" Value="0"></asp:ListItem>
                     <asp:ListItem Text="Declared" Value="1"></asp:ListItem>
                     <asp:ListItem Text="Un-expected" Value="2"></asp:ListItem>
                                   </asp:DropDownList>

            </div>
             <div class="eachform"  style="width:49%;float: right;">
                  <h2>Holiday Type*</h2>
               
                  <asp:DropDownList ID="ddlHolType" Height="30px" Width="54%" class="form1" onkeydown="return DisableEnter(event)" runat="server" Style="margin-right: 4%;"></asp:DropDownList>
               

            </div>
        
        
            <br />
            <div class="eachform">
                <div class="subform" style="width: 62%; margin-top:5%">

                      <asp:Button ID="btnConfirm" runat="server" class="save" Text="Confirm" OnClick="btnConfirm_Click" OnClientClick="return ConfirmAlert();"/>
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return WaterCardValidate();"/>
                      <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return WaterCardValidate();"/>
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return WaterCardValidate();"/>
                     <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return WaterCardValidate();"/>
                     <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" PostBackUrl="~/AWMS/AWMS_Master/gen_Holiday_Master/gen_Holiday_Master_List.aspx"/>
                 <asp:Button ID="btnClear" runat="server" style="margin-left: 13px;" OnClientClick="return AlertClearAll();" OnClick="btnClear_Click" class="cancel" Text="Clear"/>
                </div>
            </div>

        </div>
    </div>

</asp:Content>

