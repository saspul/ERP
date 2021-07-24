<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Vehicle_Other_Status.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Vehicle_Status_Management_gen_Vehicle_Other_Status" %>

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

            var confirmbox = 0;

            function IncrmntConfrmCounter() {
                confirmbox++;
            }
            function ConfirmMessage() {
                var Mode = document.getElementById("<%=hiddenMode.ClientID%>").value;
                var VehId = document.getElementById("<%=hiddenVehicleId.ClientID%>").value;
                if ((document.getElementById("<%=HiddenBackPage.ClientID%>").value) != "") {
                    window.location.href = "gen_Vehicle_Status_Management.aspx?VhclID=" + document.getElementById("<%=HiddenBackPage.ClientID%>").value + "";
                }
                else {
                    if (confirmbox > 0) {
                        if (confirm("Are You Sure You Want To Leave This Page?")) {

                            if (Mode == "ADD") {
                                window.location.href = "gen_Vehicle_Status_Management.aspx";
                            }
                            else {
                                window.location.href = "gen_Vehicle_Assigned_List.aspx?VehId=" + VehId + "";
                            }
                        }
                        else {
                            return false;
                        }
                    }
                    else {
                        if (Mode == "ADD") {
                            window.location.href = "gen_Vehicle_Status_Management.aspx";
                        }
                        else {
                            window.location.href = "gen_Vehicle_Assigned_List.aspx?VehId=" + VehId + "";
                        }

                    }
                }
            }

            function AlertClearAll() {
                if (confirmbox > 0) {
                    if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {

                    return true;


                }
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

                function AssignValidate() {

                    var $noCon = jQuery.noConflict();
                    var ret = true;
                    if (CheckIsRepeat() == true) {
                    }
                    else {
                        ret = false;
                        return ret;
                    }

                    document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=ddlStatus.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=ddlStatusType.ClientID%>").style.borderColor = "";
                    // replacing < and > tags
                    var FromDateWithoutReplace = document.getElementById("<%=txtFromDate.ClientID%>").value;
                    var replaceText1 = FromDateWithoutReplace.replace(/</g, "");
                    var replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("<%=txtFromDate.ClientID%>").value = replaceText2;

                     var ToDateWithoutReplace = document.getElementById("<%=txtToDate.ClientID%>").value;
                    var replaceText1 = ToDateWithoutReplace.replace(/</g, "");
                    var replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("<%=txtToDate.ClientID%>").value = replaceText2;

                    var DescrWithoutReplace = document.getElementById("<%=txtDescription.ClientID%>").value;
                    var replaceText1 = DescrWithoutReplace.replace(/</g, "");
                    var replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("<%=txtDescription.ClientID%>").value = replaceText2;

                    var FromDate = document.getElementById("<%=txtFromDate.ClientID%>").value.trim();
                    var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value.trim();

                    var ddlStsTyp = document.getElementById("<%=ddlStatusType.ClientID%>");
                    var StsTypText = ddlStsTyp.options[ddlStsTyp.selectedIndex].text;

                    var ddlSts = document.getElementById("<%=ddlStatus.ClientID%>");
                    var StsText = ddlSts.options[ddlSts.selectedIndex].text;


                    if (FromDate != "" && ToDate != "") {

                        var TaskdatepickerDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
                        var arrDatePickerDate = TaskdatepickerDate.split("-");
                        var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                        var CurrentDateDate = document.getElementById("<%=txtToDate.ClientID%>").value;
                        var arrCurrentDate = CurrentDateDate.split("-");
                        var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                        if (dateDateCntrlr > dateCurrentDate) {

                            document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtToDate.ClientID%>").focus();
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,  To Date should be Greater than From Date!.";

                            ret = false;
                        }
                    }
                    if (ToDate != "") {
                        var TaskdatepickerDate = document.getElementById("<%=txtToDate.ClientID%>").value;
                         var arrDatePickerDate = TaskdatepickerDate.split("-");
                         var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                         var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                        var arrCurrentDate = CurrentDateDate.split("-");
                        var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                        if (dateDateCntrlr < dateCurrentDate) {

                            document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtToDate.ClientID%>").focus();
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,To Date should be Greater than Current Date!.";

                            ret = false;
                        }
                    }
                    if (FromDate != "") {
                        var TaskdatepickerDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
                        var arrDatePickerDate = TaskdatepickerDate.split("-");
                        var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                        var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                        var arrCurrentDate = CurrentDateDate.split("-");
                        var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                        if (dateDateCntrlr < dateCurrentDate) {

                            document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtFromDate.ClientID%>").focus();
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,  From Date should be greater than Current Date!.";

                            ret = false;
                        }
                    }

                    if (FromDate == "") {
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                         document.getElementById("<%=txtFromDate.ClientID%>").focus();
                         ret = false;
                     }
                    if (StsText == "--SELECT--") {

                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById("<%=ddlStatus.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=ddlStatus.ClientID%>").focus();
                        ret = false;
                    }
                    if (StsTypText == "--SELECT--") {

                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById("<%=ddlStatusType.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=ddlStatusType.ClientID%>").focus();
                        ret = false;
                    }





                    if (ret == false) {
                        CheckSubmitZero();

                    }
                    return ret;
                }

                //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
                function textCounter(field, maxlimit) {
                    if (field.value.length > maxlimit) {
                        field.value = field.value.substring(0, maxlimit);
                    } else {

                    }
                }

                function ddlFocus()
                {
                    document.getElementById("<%=ddlStatusType.ClientID%>").focus();
                }
    </script>
         <%--FOR DATE TIME PICKER--%>
<script type="text/javascript" src="../../../JavaScript/Date/JavaScriptDate1_8_3.js"></script>                      
<script type="text/javascript" src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
<script type="text/javascript" src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
<script type="text/javascript"src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
<link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
<link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
    <style>
        .eachform h2 {
    font-family: Calibri;
    font-size: 17px;
    float: left;
    text-align: left;
    color: #909c7b;
    padding: 0;
    margin: 8px 0 6px;
    line-height: 1;
    font-weight: normal;
    float: left;
}
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
         input[type="radio"] {
    display: block;
    float:left;
}
           #divAsignCapt {
            font-size: 19px;
            color: rgb(83, 101, 51);
            font-family: Calibri;
            width: 128px;
            margin-left:32%;
       

        }
        #divRadio {
           font-size: 15px;
            color: rgb(83, 101, 51);
            font-family: Calibri;
            margin-top:4%;
        }
        .bootstrap-datetimepicker-widget {
            z-index:100;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenVehicleId" runat="server" />
    <asp:HiddenField ID="hiddenMode" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="HiddenBackPage" runat="server" />
        <br />
     <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
     <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:8%; top:20%;height:26.5px;">
        </div>
        <div class="cont_rght">
            <div class="fillform" style="width:95%;">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <img src="/Images/BigIcons/vehicle-management_status_change.png" style="vertical-align: middle;"  />
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
                <br />
                <div style="background-color: #efefef;border: 1px solid;border-color: #c5c5c5;">
                     <div style="width:98%;margin-top: 2%;color: red;float: left;margin-left: 1%;">
                         <h2 style="margin-bottom:0%;margin-top: 0.2%;">Vehicle No:</h2>
                          <asp:label id="lblVehicleNum" runat="server" style="font-family:Calibri;word-wrap:break-word; color:#536533;font-size:19px;margin-left: 1%;"></asp:label>
                    </div>

                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                        <ContentTemplate>
                <div style="width:48%;float:right;margin-top:4%">
                
               <div id="divProject_Employee" class="eachform" style="width:90%;float:left">

                <h2>Status*</h2>
               <asp:DropDownList ID="ddlStatus" Height="30px" Width="58%" class="form1" TabIndex="2" onkeydown="return DisableEnter(event)" runat="server" Style="margin-right: 1%;"></asp:DropDownList>
           
            </div>
                    </div>
                     <div id="divContentContainer" style="width: 48%;float: left;margin-top:4%;margin-left: 2%;"">

                <div id="Division" class="eachform" style="width:90%;float:left">

                <h2>Status Type*</h2>
               <asp:DropDownList ID="ddlStatusType" Height="30px" Width="58%" class="form1" TabIndex="1" onkeydown="return DisableEnter(event)" OnSelectedIndexChanged="ddlStatusType_SelectedIndexChanged" AutoPostBack="true" runat="server" Style="margin-right: 1%;"></asp:DropDownList>
           
            </div>
                     </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    <div style="width:48%;float:right;margin-top:0%">
                  <div class="eachform" style="width:90%;float:left;margin-top:3px">
                 <h2>From Date*</h2>
               <div id="divFromDate" class="input-append date" style="font-family:Calibri;float:right;width:51%;margin-right: 8%;">
                 <asp:TextBox ID="txtFromDate" class="textDate" TabIndex="4" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return DisableEnter(event)" Style="width:98.8%;height:23px; font-family: calibri;" ></asp:TextBox>

                        <img id= "img1" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style=" height:17px; width:12px; cursor:pointer;" />

                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divFromDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,

                                startDate: new Date(),
                            });

                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>

                
                <div class="eachform" style="width:90%;float:left;margin-top:3px">
                 <h2>To Date</h2>
               <div id="divToDate" class="input-append date" style="font-family:Calibri;float:right;width:51%;margin-right: 8%;">
                 <asp:TextBox ID="txtToDate" class="textDate" TabIndex="5" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return DisableEnter(event)" Style="width:98.8%;height:23px; font-family: calibri;" ></asp:TextBox>

                        <img id= "img2" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style=" height:17px; width:12px; cursor:pointer;" />

                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divToDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,

                                startDate: new Date(),
                            });

                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>



                    </div>

                
                     <div id="div2" style="width: 48%;float: left;margin-top:0%;margin-left: 2%;"">
          <div id="Div1" class="eachform" style="width:90%;float:left">

             <h2>Description</h2>
             <asp:TextBox ID="txtDescription" class="form1" runat="server" TabIndex="3" MaxLength="500" Width="53.5%" Height="90px" TextMode="MultiLine" Style="resize: none; margin-right: 1%;font-family:Calibri" onkeydown="textCounter(cphMain_txtDescription,450)" onkeyup="textCounter(cphMain_txtDescription,450)"></asp:TextBox>
          </div>

            </div>
                    
                 <div class="eachform" style="margin-top: 2%;">
                <div class="subform" style="width: 62%; margin-top:5%;margin-right: 0%;">
                    <asp:Button ID="btnAssign" runat="server" class="save" Text="Save" TabIndex="6" OnClientClick="return AssignValidate();" OnClick="btnAssign_Click"/>
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" TabIndex="7"  OnClientClick="return AssignValidate();" OnClick="btnUpdate_Click"/>
                    <asp:Button ID="btnCancel" runat="server" style="margin-left: 19px;" TabIndex="8" OnClientClick="return AlertClearAll();" OnClick="btnCancel_Click" class="cancel" Text="Cancel"/>
               
                </div>
            </div>

                </div>
                 </div>
            </div>
</asp:Content>

