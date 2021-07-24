<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Emp_Exit_Process.aspx.cs" Inherits="HCM_HCM_Master_hcm_Exit_Management_hcm_Employee_Exit_Process_hcm_Emp_Exit_Process"  EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <style>
       
        input[type="radio"] {
            display: table-cell;
        }

    </style>


  

    <script src="/JavaScript/jquery-1.8.3.min.js"></script>

    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {


            document.getElementById("divEmployee").style.display = "none";

            $noCon(window).scrollTop(0);

            if (document.getElementById("<%=hiddenViewEdit.ClientID%>").value == "true") {

                EmpDisplay();
                document.getElementById("cphMain_radioStaff").disabled = true;
                document.getElementById("cphMain_radioWorker").disabled = true;
                document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;

                if (document.getElementById("<%=hiddenConfirm.ClientID%>").value == 1 || document.getElementById("<%=hiddenView.ClientID%>").value == "true") {

                    document.getElementById("Image1").disabled = true;
                }
                else {
                    document.getElementById("Image1").disabled = false;
                }

                if (document.getElementById("<%=hiddenView.ClientID%>").value == "true") {

                    document.getElementById("<%=ddlStatus.ClientID%>").disabled = true;
                    document.getElementById("<%=txtRsn.ClientID%>").disabled = true;
                    document.getElementById("<%=txtNoticePrd.ClientID%>").disabled = true;
                    document.getElementById("<%=txtTermntDate.ClientID%>").disabled = true;
                }

                document.getElementById("<%=ddlStatus.ClientID%>").focus();


                if (document.getElementById("<%=hiddenConfirm.ClientID%>").value == 1)
                {
                    document.getElementById("cphMain_imgbtnReOpen").style.display = "";
                }
                else
                {
                    document.getElementById("cphMain_imgbtnReOpen").style.display = "none";
                }
            }
            else
            {

                document.getElementById("<%=ddlEmployee.ClientID%>").focus();
               //  EmpDropDwnBind();

                
            }
        });
    </script>

    <script>

        function EmpDropDwnBind() {

            //Employees dropdown bind

            $co = jQuery.noConflict();

            //  $co("#ddlEmployee:input").attr("autocomplete", "off");

             if (document.getElementById("cphMain_radioStaff").checked == true) {
                var mode = "0";
            }
            else if (document.getElementById("cphMain_radioWorker").checked == true) {
                var mode = "1";
            }

            var varEmpddl = $co(document.getElementById("<%=ddlEmployee.ClientID%>"));

            var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;

          /*  var Details = PageMethods.EmpDropdownBind(mode,CorpId,OrgId, function (response) {
             
              
                    varEmpddl.children().remove();

                    var optionstart = $co("<option>--SELECT EMPLOYEE--</option>");
                    optionstart.attr("value", 0);
                    varEmpddl.append(optionstart);

                    $co(response).find("dtEmpTable").each(function () {

                        var optionvalue = $co(this).find('USR_ID').text();
                        var optiontext = $co(this).find('USR_NAME').text();
                        var option = $co("<option>" + optiontext + "</option>");
                        option.attr("value", optionvalue);
                   
                        varEmpddl.append(option);
                    });
              
            });*/
          
        //    $co('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
            return false;
        }

        

        function EmpDisplay() {

            //Employee details display
            document.getElementById("divEmployee").style.display = "";
            var EmpId = document.getElementById("<%=ddlEmployee.ClientID%>").value;
            document.getElementById("<%=hiddenEmpIdTemp.ClientID%>").value = document.getElementById("<%=hiddenEmpId.ClientID%>").value;            
            document.getElementById("<%=hiddenEmpId.ClientID%>").value = EmpId;           
            var Details = PageMethods.EmpDtls(EmpId, function (response) {
              

                document.getElementById("<%=lblEmp.ClientID%>").innerHTML = response[0];
                document.getElementById("<%=lblDesgntn.ClientID%>").innerHTML = response[1];
                document.getElementById("<%=lblPay.ClientID%>").innerHTML = response[2];
                document.getElementById("<%=lblDept.ClientID%>").innerHTML = response[3];
                document.getElementById("<%=lblDivsn.ClientID%>").innerHTML = response[4];

                if (document.getElementById("<%=hiddenNtcPrdPrevious.ClientID%>").value != "") {
                    document.getElementById("<%=txtNoticePrd.ClientID%>").value = document.getElementById("<%=hiddenNtcPrdPrevious.ClientID%>").value;
                }
                else {
                    if (response[5] != null && response[5] != "") {
                        document.getElementById("<%=txtNoticePrd.ClientID%>").value = response[5];
                        document.getElementById("<%=hiddenNotcprd.ClientID%>").value = response[5];
                        document.getElementById("<%=txtTermntDate.ClientID%>").value = addDays(response[5]);

                    }
                    else {
                        document.getElementById("<%=txtTermntDate.ClientID%>").value = addDays(0);
                        document.getElementById("<%=hiddenNotcprd.ClientID%>").value = 0;
                        document.getElementById("<%=txtNoticePrd.ClientID%>").value = 0;
                    }
                }
             //   document.getElementById("<%=hiddenEmpId.ClientID%>").value = EmpId;
              
            });

       

            if (document.getElementById("<%=hiddenEmpId.ClientID%>").value == "--SELECT EMPLOYEE--") {
                document.getElementById("<%=hiddenEmpId.ClientID%>").value = document.getElementById("<%=hiddenEmpIdTemp.ClientID%>").value;
            }            
            return false;

        }


        function addDays(days) {

            var x = days;
            var m = ["01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"];
            var d = ["00","01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"];
            var today = document.getElementById("<%=hiddenDate.ClientID%>").value;
            var arrDatePickerDate1 = today.split("-");
            var datetoday = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

            datetoday.setDate(datetoday.getDate() + parseInt(days));

            var dt = d[datetoday.getDate()] + "-" + m[datetoday.getMonth()] + "-" + datetoday.getFullYear();

            return (dt);
        }

 
        function Noticeprd() {           
            //getting notice period          
            if (document.getElementById("<%=hiddenConfirm.ClientID%>").value == 0 && document.getElementById("<%=hiddenView.ClientID%>").value != "true") {

                var today = document.getElementById("<%=hiddenDate.ClientID%>").value;
                var arrDatePickerDate1 = today.split("-");
                var datetoday = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

                var enddate = document.getElementById("<%=txtTermntDate.ClientID%>").value;
                var arrDatePickerDate1 = enddate.split("-");
                var dateend = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

                var months = monthDiff(datetoday, dateend);

                if (today != "") {
                    if (enddate != "") {
                        document.getElementById("<%=txtNoticePrd.ClientID%>").value = months;                        
                        document.getElementById("<%=hiddenNotcprd.ClientID%>").value = document.getElementById("<%=txtNoticePrd.ClientID%>").value;
                    }
                }
                else {
                    document.getElementById("<%=txtNoticePrd.ClientID%>").value = 0;
                    document.getElementById("<%=hiddenNotcprd.ClientID%>").value = document.getElementById("<%=txtNoticePrd.ClientID%>").value;
                }                             
                IncrmntConfrmCounter();
            }
            else {

                document.getElementById("Image1").disabled = true;
            }
        }
    
    function monthDiff(d1, d2) {
        var months;
        var diffDays = parseInt((d2 - d1) / (1000 * 60 * 60 * 24));
        return diffDays;
    }

    function ConfirmMessage() {

        if (confirm("Are you sure you want to leave this page?")) {
            window.location.href = "hcm_Emp_Exit_Process_List.aspx";
            return false;
        }
        else {
            return false;
        }
    }

    // for not allowing <> tags
    function isTag(evt) {

        evt = (evt) ? evt : window.event;
        var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

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

    var confirmbox = 0;

    function IncrmntConfrmCounter() {

        confirmbox++;
    }

    function ClearAll() {
        if (confirmbox > 0) {
            if (confirm("Are you sure you want clear all data in this page?")) {
                document.getElementById("<%=ddlStatus.ClientID%>").value = "0";
                document.getElementById("<%=txtRsn.ClientID%>").value = "";
                document.getElementById("<%=txtTermntDate.ClientID%>").value = "";
                document.getElementById("<%=txtNoticePrd.ClientID%>").value = "";
                return false;
            }
            else {
                return false;
            }
        }
        else {
            document.getElementById("<%=ddlStatus.ClientID%>").value = "0";
            document.getElementById("<%=txtRsn.ClientID%>").value = "";
            document.getElementById("<%=txtTermntDate.ClientID%>").value = "";
            document.getElementById("<%=txtNoticePrd.ClientID%>").value= "";
            return false;
        }
    }

        function Validate() {

            var ret = true;

            document.getElementById("<%=txtTermntDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtRsn.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlStatus.ClientID%>").style.borderColor = "";

            var NameWithoutReplace = document.getElementById("<%=txtRsn.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtRsn.ClientID%>").value = replaceText2;


            var datepickerDate = document.getElementById("<%=txtTermntDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateTrmntDt = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDate = document.getElementById("<%=hiddenDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateToday = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            if (document.getElementById("<%=txtTermntDate.ClientID%>").value != "" && dateTrmntDt <= dateToday) {

                document.getElementById("<%=txtTermntDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtTermntDate.ClientID%>").focus();
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, terminating date should be greater than current date !";
                ret = false;
            }

            var TermntDt = document.getElementById("<%=txtTermntDate.ClientID%>").value.trim();
            if (TermntDt == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtTermntDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtTermntDate.ClientID%>").focus();
                ret = false;
            }

            var Rsn = document.getElementById("<%=txtRsn.ClientID%>").value.trim();
            if (Rsn == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtRsn.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtRsn.ClientID%>").focus();
                ret = false;
            }

          //  var status = document.getElementById("<%=ddlStatus.ClientID%>").value.trim();
            if (document.getElementById("<%=ddlStatus.ClientID%>").value == "--SELECT STATUS--") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlStatus.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlStatus.ClientID%>").focus();
                ret = false;
            }

            $("#divddlEmployee input.ui-autocomplete-input").css("borderColor", "");
            if (document.getElementById("<%=ddlEmployee.ClientID%>").value == "--SELECT EMPLOYEE--" || document.getElementById("<%=ddlEmployee.ClientID%>").value == 0 || document.getElementById("<%=ddlEmployee.ClientID%>").value == "" || document.getElementById("<%=ddlEmployee.ClientID%>").value == null) {
                $("#divddlEmployee input.ui-autocomplete-input").css("borderColor", "red");
                ret = false;
            }
            else {

                document.getElementById("<%=hiddenEmpId.ClientID%>").value = document.getElementById("<%=ddlEmployee.ClientID%>").value
            }

            return ret;
        }

        function ConfirmCancel() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to cancel this page?")) {
                    window.location.href = "hcm_Emp_Exit_Process_List.aspx";
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                window.location.href = "hcm_Emp_Exit_Process_List.aspx";
                return false;
            }
        }

        function ConfirmReOpen() {
            if (confirm("Are you sure you want to reopen?")) {
         
                return true;
            }
            else {
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


    function SuccessIns() {
        document.getElementById('divMessageArea').style.display = "";
        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Exit Process inserted successfully.";
    }

   function SuccessUpdation() {
        document.getElementById('divMessageArea').style.display = "";
        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Exit Process updated successfully.";
   }
        function SuccessCancelation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Exit process cancelled successfully.";
        }
        function SuccessConfirm() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Exit process confirmed successfully.";
        }
        function SuccessReopened() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Exit process reopened successfully";
        }

       </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">


<asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="hiddenCorpId" runat="server" />
    <asp:HiddenField ID="hiddenOrgId" runat="server" />
    <asp:HiddenField ID="hiddenEmpId" runat="server" />
    <asp:HiddenField ID="hiddenExtPrcsId" runat="server" />
    <asp:HiddenField ID="hiddenNotcprd" runat="server" />
    <asp:HiddenField ID="hiddenNtcPrdPrevious" runat="server" />
    <asp:HiddenField ID="hiddenDate" runat="server" />
    <asp:HiddenField ID="hiddenViewEdit" runat="server" />
    <asp:HiddenField ID="hiddenView" runat="server" />
    <asp:HiddenField ID="hiddenConfirm" runat="server" />
    <asp:HiddenField ID="hiddenResign" runat="server" />
      <asp:HiddenField ID="hiddenReopenId" runat="server" />
     <asp:HiddenField ID="hiddenEmpIdTemp" runat="server" />
    <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    
    <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 5%; top: 40%; height: 26.5px;">
        </div>

    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; margin-bottom: 2%;">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
    
    <div id="divImage" style="float: right;margin-right:3%;margin-top:-7%">
                       
                        <asp:ImageButton ID="imgbtnReOpen" runat="server" OnClientClick="return ConfirmReOpen();" title="ReOpen" src="/Images/Icons/Reopen.png" Style="margin-left: 0%;" OnClick="imgbtnReOpen_Click" />
                         <p id="imgReOpen" class="imgDescription" style="color: white">ReOpen Confirmed Entry</p>   
                    </div>


     <%--div for selecting the employee--%>

             <asp:UpdatePanel ID="UpdatePanelTree" runat="server" UpdateMode="Conditional" >
            <ContentTemplate>     
    <div id="divSelect" style="float:left;width: 97%;padding: 17px;border: 1px solid #929292;font-family: Calibri;">


  
        <div style="float: left;width: 25%;margin-left: 8%;margin-top:  1%;"">
            <asp:RadioButton ID="radioStaff" Text="Staff" runat="server" AutoPostBack="true" OnCheckedChanged="radioStaff_CheckedChanged"  GroupName="Radio" Checked="true" Style="float: left; font-family: calibri" onkeypress="return DisableEnter(event)"  />
              <asp:RadioButton ID="radioWorker" Text="Worker" runat="server" AutoPostBack="true" OnCheckedChanged="radioStaff_CheckedChanged" GroupName="Radio"  Style="float: left; font-family: calibri; margin-left: 6%;" onkeypress="return DisableEnter(event)"  />
              <%--<asp:RadioButton ID="radioStaff" Text="Staff" runat="server" AutoPostBack="true" OnCheckedChanged="radioStaff_CheckedChanged"  GroupName="Radio" Checked="true" Style="float: left; font-family: calibri" onkeypress="return DisableEnter(event)" onChange="return EmpDropDwnBind()" />
              <asp:RadioButton ID="radioWorker" Text="Worker" runat="server" AutoPostBack="true" OnCheckedChanged="radioStaff_CheckedChanged" GroupName="Radio"  Style="float: left; font-family: calibri; margin-left: 6%;" onkeypress="return DisableEnter(event)" onChange="return EmpDropDwnBind()" />--%>
          </div>


       <div class="eachform" style="float: left;width: 41%;margin-top:  1%;"">
        <h2>Employee* </h2>
            <div id="divddlEmployee">
        <asp:DropDownList ID="ddlEmployee" class="form1" runat="server" Style="height: 28px; width: 63%;" onkeypress="return DisableEnter(event)" onchange="return EmpDisplay()" >
           </asp:DropDownList>
       </div>
      </div>

   </div>   

     </ContentTemplate>
    </asp:UpdatePanel>


    <br />          
    <br />
                
    <%--display div on selecting the employee--%>


   <div id="divEmployee" style="float:left;width:100%;">

       <div style="width: 98%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke; float: left;margin-top: 2%;">

       <div style="float: left; width: 96%;padding: 10px;margin-top: 1%;background-color: #c9c9c9;border:.5px solid #929292;font-family: Calibri;margin-left:1%">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="width: 22%;color: #603504;">Employee</h2>
                    <asp:Label ID="lblEmp" class="form1" runat="server" style="word-wrap: break-word;font-family: calibri;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="width: 28%;color: #603504;">Designation</h2>
                    <asp:Label ID="lblDesgntn" class="form1" runat="server" style="word-wrap: break-word;font-family: calibri;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="width: 22%;color: #603504;">Pay Grade</h2>
                    <asp:Label ID="lblPay" class="form1" runat="server" style="word-wrap: break-word;font-family: calibri;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="width: 28%;color: #603504;">Department</h2>
                    <asp:Label ID="lblDept" class="form1" runat="server" style="word-wrap: break-word;font-family: calibri;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;word-wrap: break-word;">
                    <h2 style="width: 22%;color: #603504;">Division</h2>
                    <asp:Label ID="lblDivsn" class="form1" runat="server" style="word-wrap: break-word;font-family: calibri;"></asp:Label>
                </div>
               
            </div>

       <div style="float:left;width:96%;margin-left: 1%;margin-top: 1%;border: 1px solid;padding: 10px;">

           <div>

     <div class="eachform" style="float: left;width: 44.5%;margin-top:2%;margin-left: 19%;">
        <h2 style="width: 47%;">Status* </h2>
        <asp:DropDownList ID="ddlStatus" class="form1" runat="server" Style="height: 28px; width: 53%;" onkeypress="return DisableEnter(event)" onchange="IncrmntConfrmCounter();">
<%--            <asp:ListItem Text="--SELECT STATUS--" Value="0"></asp:ListItem>
            <asp:ListItem Text="Resign" Value="1"></asp:ListItem>
            <asp:ListItem Text="Retirement" Value="2"></asp:ListItem>
            <asp:ListItem Text="Termination" Value="3"></asp:ListItem>
            <asp:ListItem Text="Abscond" Value="4"></asp:ListItem>
            <asp:ListItem Text="Death" Value="5"></asp:ListItem>
            <asp:ListItem Text="Rejoin" Value="6"></asp:ListItem>
            <asp:ListItem Text="Under Police Custody" Value="7"></asp:ListItem>
            <asp:ListItem Text="Other" Value="8"></asp:ListItem>--%>
          </asp:DropDownList>
      </div>

    <div class="eachform" style="float: left;width: 80%;margin-top:2%;margin-left: 19%;">
        <h2 style="width: 26%;">Reason* </h2>
        <asp:TextBox ID="txtRsn" runat="server" class="form-control" MaxLength="500" Width="240px" Height="115px" TextMode="MultiLine" Style="height:115px;width:268px;resize:none;border: 1px solid #cfcccc;font-family: calibri;" onchange="IncrmntConfrmCounter();" onkeydown="textCounter(cphMain_txtRsn,450)" onkeyup="textCounter(cphMain_txtRsn,450)" onblur="return isTag(event)"></asp:TextBox>
         
     </div>

     <div class="eachform" style="width: 45%; float: left;margin-top: 2%;margin-left: 19%;">
         <h2 style="width: 46%;">Notice Period</h2>
         <asp:TextBox ID="txtNoticePrd" class="form1" runat="server" Enabled="false"  MaxLength="50" Style="width: 40%; margin-left: 0%; height: 30px;float: left;" onchange="IncrmntConfrmCounter();"></asp:TextBox>
         <div id="days" style="float: left;margin-left: 3%;margin-top: 2%;"><h2> Days</h2></div>
       </div>

     <div class="eachform" style="width: 80%; float: left;margin-top: 2%;margin-left: 19%;">
     <%--    EVM-0027--%>
         <h2 style="width: 26%;">As on date*</h2>
               <%-- END--%>
          <div id="divTermntDate" class="input-append date" style="float: left;width: 59%;">
                        
                 <asp:TextBox ID="txtTermntDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  Style="height:30px;width:41%;float:left;margin-left: 0%;" onkeypress="return DisableEnter(event)" onkeydown="return isTagEnter(event)"  onblur="Noticeprd()"  onchange="Noticeprd()"></asp:TextBox>

                        <input type="image"  id="Image1" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;" onblur="Noticeprd()"  onchange="Noticeprd()"/>

                           <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                               <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
                           <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate1_8_3.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker_pt_br.js">
                            </script>
                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divTermntDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),
                            });
                        </script>

                        <p style="visibility: hidden">Please enter</p>
                       </div>

         </div>

       <div class="eachform" style="margin-top: -1.5%;margin-left: 19%;">
            <div class="subform" style="width: 90%; margin-top: 3%;">
   

    <asp:Button ID="btnSave"  runat="server" class="save" Text="Save"  OnClientClick="return Validate();" OnClick="btnSave_Click" />
    <asp:Button ID="btnSaveClose"  runat="server" class="save" Text="Save & Close" OnClientClick="return Validate(); " OnClick="btnSave_Click" />
    <asp:Button ID="btnConfirm"  runat="server" style="margin-left: 1%;" class="save" Text="Confirm" OnClientClick="return Validate();" OnClick="btnConfirm_Click"/>     
    <asp:Button ID="btnUpdate"  runat="server" class="save" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnUpdateClose"  runat="server" class="save" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click"/>
    <asp:Button ID="btnCancel"  runat="server" class="cancel" OnClientClick="return ConfirmCancel();" Text="Cancel"   />
    <asp:Button ID="btnClear" runat="server" style="margin-left: 1%;" OnClientClick="return ClearAll();"  class="cancel" Text="Clear"/>
    
                </div>

           </div>
           </div>
            </div>
        </div>
</div>


    <style>
     .open > .dropdown-menu {
    display: none;
}

     .cont_rght {
    width: 98%;
}

    </style>




                        <style>
          .ui-autocomplete {
             padding: 0;
             list-style: none;
             background-color: #fff;
             width: 218px;
             border: 1px solid #B0BECA;
             max-height: 135px;
             overflow-x: auto;
             font-family: Calibri;
         }

             .ui-autocomplete .ui-menu-item {
                 border-top: 1px solid #B0BECA;
                 display: block;
                 padding: 4px 6px;
                 color: #353D44;
                 cursor: pointer;
                 font-family: Calibri;
             }

                 .ui-autocomplete .ui-menu-item:first-child {
                     border-top: none;
                     font-family: Calibri;
                 }

                 .ui-autocomplete .ui-menu-item.ui-state-focus {
                     background-color: #D5E5F4;
                     color: #161A1C;
                     font-family: Calibri;
                 }
    </style>
       

    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

    <script>
        var $au = jQuery.noConflict();
        $au(function () {
            $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
        });


        function AutoCompleteScrpt() {
            $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
        }

    </script>

    
</asp:Content>

