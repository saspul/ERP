<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Vehicle_Assign.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Vehicle_Status_Management_gen_Vehicle_Assign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
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
        var $au = jQuery.noConflict();//evm-20

            $au(function () {
                $au('#cphMain_ddlProject_Employee').selectToAutocomplete1Letter();
            });
    </script>



       <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
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
               if ((document.getElementById("<%=HiddenBackPage.ClientID%>").value) != "") {
                   window.location.href = "gen_Vehicle_Status_Management.aspx?VhclID=" + document.getElementById("<%=HiddenBackPage.ClientID%>").value + "";
               }
               else {
                   if (confirmbox > 0) {
                       if (confirm("Are You Sure You Want To Leave This Page?")) {
                           window.location.href = "gen_Vehicle_Status_Management.aspx";
                       }
                       else {
                           return false;
                       }
                   }
                   else {
                       window.location.href = "gen_Vehicle_Status_Management.aspx";

                   }
               }
           }

           function AlertClearAll() {
               if (confirmbox > 0) {
                   if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                       window.location.href = "gen_Vehicle_Assign.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "gen_Vehicle_Assign.aspx";

               }
           }


           var $noCon = jQuery.noConflict();
           $noCon(window).load(function () {

               if (document.getElementById("<%=radioGeneral.ClientID%>").checked == true) {
                   document.getElementById("<%=ddlProject_Employee.ClientID%>").disabled = true;
                   document.getElementById('cphMain_lblproject_emp').textContent = "Project/Employee";
               }
               else {
                   document.getElementById('cphMain_lblproject_emp').textContent = "Project/Employee*";
               
               }
           });

       
        function InvalidDateAlert() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "The Date You Entered Are Invalid.";
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
                    // replacing < and > tags
                     var FromDateWithoutReplace = document.getElementById("<%=txtFromDate.ClientID%>").value;
                     var replaceText1 = FromDateWithoutReplace.replace(/</g, "");
                     var replaceText2 = replaceText1.replace(/>/g, "");
                     document.getElementById("<%=txtFromDate.ClientID%>").value = replaceText2;

                    var ToDateWithoutReplace = document.getElementById("<%=txtToDate.ClientID%>").value;
                    var replaceText1 = ToDateWithoutReplace.replace(/</g, "");
                    var replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("<%=txtToDate.ClientID%>").value = replaceText2;

                    document.getElementById("<%=ddlProject_Employee.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";

                    var FromDate = document.getElementById("<%=txtFromDate.ClientID%>").value.trim();
                    var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value.trim();

                    var ddlDiv = document.getElementById("<%=ddlDivision.ClientID%>");
                    var DivText = ddlDiv.options[ddlDiv.selectedIndex].text;

                    var ddlEmp = document.getElementById("<%=ddlProject_Employee.ClientID%>");
                    var EmpText = ddlEmp.options[ddlEmp.selectedIndex].text;


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

                    if(FromDate == "")
                    {
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtFromDate.ClientID%>").focus();
                        ret = false;
                    }

                    if (document.getElementById("<%=radioGeneral.ClientID%>").checked != true) {

                        if (EmpText == "--SELECT--") {

                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            document.getElementById("<%=ddlProject_Employee.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=ddlProject_Employee.ClientID%>").focus();
                            ret = false;
                        }


                    }


                    if (DivText == "--SELECT--") {

                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=ddlDivision.ClientID%>").focus();
                        ret = false;
                    }

                   
                    if (ret == false) {
                        CheckSubmitZero();

                    }
                    return ret;

                }

              

    </script>

    <script>

        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }


                    </script>


    <script>
        $noCon = jQuery.noConflict();

        function VisibleDropDown() {
       

            //$noCon("div#divProject_Employee input.ui-autocomplete-input").attr('disabled', 'false');
            var ddlDiv = document.getElementById('cphMain_ddlDivision');
            ddlDiv.options[0].selected = true;
            __doPostBack('<%= ddlDivision.UniqueID%>', '');
            var ddlEmp = document.getElementById("<%=ddlProject_Employee.ClientID%>");
            ddlEmp.options[0].selected = true;
            setTimeout(ddlEnable, 50);
           
            }
            function ddlEnable()
            {
             document.getElementById('cphMain_lblproject_emp').textContent = "Project/Employee*";
             document.getElementById("<%=ddlProject_Employee.ClientID%>").disabled = false;
             setTimeout(SetTime(), 25); //evm-20
            }
        function HideDropDown() {
          
            if (document.getElementById("<%=radioGeneral.ClientID%>").checked == true) {
                var ddlDiv = document.getElementById("<%=ddlDivision.ClientID%>");
                ddlDiv.options[0].selected = true;
                __doPostBack('<%= ddlDivision.UniqueID%>', '');
                var ddlEmp = document.getElementById("<%=ddlProject_Employee.ClientID%>");
                ddlEmp.options[0].selected = true;

                setTimeout(ddlDisable, 50);

            }
        }
        function ddlDisable() {
            document.getElementById("<%=ddlProject_Employee.ClientID%>").disabled = true;
            document.getElementById('cphMain_lblproject_emp').textContent = "Project/Employee";
            setTimeout(SetTime(), 25);//evm-20
        }
        function ddlFocusonUpdate() {
            document.getElementById("<%=ddlDivision.ClientID%>").focus();
        }

        function ddlFocus() { 
            if (document.getElementById("<%=radioGeneral.ClientID%>").checked == true) {
            var ddlEmp = document.getElementById("<%=ddlProject_Employee.ClientID%>");
            ddlEmp.options[0].selected = true;
            document.getElementById("<%=ddlProject_Employee.ClientID%>").disabled = true;
            document.getElementById('cphMain_lblproject_emp').textContent = "Project/Employee";
        }
        else
            {
             
            document.getElementById('cphMain_lblproject_emp').textContent = "Project/Employee*";
            document.getElementById("<%=ddlProject_Employee.ClientID%>").disabled = false;
             var ddlEmp = document.getElementById("<%=ddlProject_Employee.ClientID%>");
            ddlEmp.options[0].selected = true;
        }

            document.getElementById("<%=ddlDivision.ClientID%>").focus();
            setTimeout(SetTime(), 25);//evm-20

        }

        function SetTime() {
            $au(function () {
                $au('#cphMain_ddlProject_Employee').selectToAutocomplete1Letter();
            });
        }//evm-20

        function ddlChangeEvent()
        {
            IncrmntConfrmCounter();
            
            if (document.getElementById("<%=radioGeneral.ClientID%>").checked == true) {
                document.getElementById("<%=ddlProject_Employee.ClientID%>").disabled = true;
                document.getElementById('cphMain_lblproject_emp').textContent = "Project/Employee";
            }
            else
            { 
            document.getElementById("<%=ddlProject_Employee.ClientID%>").disabled = false;
                document.getElementById("<%=lblproject_emp.ClientID%>").textContent = "Project/Employee*";
              
            }
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
        <asp:HiddenField ID="hiddenVehicleId" runat="server" />
     <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
     <asp:HiddenField ID="HiddenBackPage" runat="server" />
        <br />
        <div class="cont_rght" style="padding-top: 0%;">
                 <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>
            
          <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:6%; top:42%;height:26.5px;">

        </div>
            <div class="fillform" style="width:95%;">
                
            <div id="divReportCaption" style="margin-top: 1%;font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <img src="/Images/BigIcons/vehicle-management_assign.png" style="vertical-align: middle;"  />
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
                <br/>

                <div style="background-color: #efefef;border: 1px solid;border-color: #c5c5c5;">

                     <div style="width:98%;margin-top: 2%;color: red;float: left;margin-left: 1%;">
                         <h2 style="margin-bottom:0%;margin-top: 0.2%;">Vehicle No:</h2>
                          <asp:label id="lblVehicleNum" runat="server" style="font-family:Calibri;word-wrap:break-word; color:#536533;font-size:19px;margin-left: 1%;"></asp:label>
                    </div>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    
                     <div id="divContentContainer" style="width: 50%;float: left;margin-top: 8%;">

                    <div id="AssignTo" class="eachform" style="width:95%;float:right">
                     <div id="divAsignCapt">
                 <asp:Label ID="lblAssignTo" runat="server">Assign To*</asp:Label>
                         </div>
               <div id="divRadio" class="subform" style="width:90%;float:right">
                   <div style="width:77px;float:left;margin-left: 5px">
                   <asp:RadioButton  ID ="radioProject" Text="Project" runat="server" onclick="VisibleDropDown();" onkeypress="return DisableEnter(event)" GroupName ="RadioGroup"/> 
                   </div> 
                    <div style="width:95px;float:left;margin-left: 5px">
                   <asp:RadioButton  ID ="radioEmployee" Text="Employee" runat="server" onclick="VisibleDropDown();" onkeypress="return DisableEnter(event)" GroupName ="RadioGroup"/> 
                     </div> 
                    <div style="width:93px;float:left;margin-left: 5px">
                 <asp:RadioButton  ID ="radioGeneral" Text="General" runat="server" onclick="HideDropDown();"  Checked="true" onkeypress="return DisableEnter(event)" GroupName ="RadioGroup" />  
                </div>
                  </div>
           
            </div>


          </div>


                <div style="width:50%;float:right;margin-top:3%">
                   


                 <div id="Division" class="eachform" style="width:90%;float:left">

                <h2>Division*</h2>
               <asp:DropDownList ID="ddlDivision" Height="30px" Width="58%" class="form1" onchange="ddlChangeEvent()" onkeydown="return DisableEnter(event)" AutoPostBack="true" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" runat="server" Style="margin-right: 1%;"></asp:DropDownList>
           
            </div>
                <div id="divProject_Employee" class="eachform" style="width:90%;float:left">
               <div style="width: 126px;float: left;">
                <asp:label id="lblproject_emp" runat="server" style="font-family:Calibri;color:#909c7b;font-size:17px">Project/Employee</asp:label>
             </div>
              <asp:DropDownList ID="ddlProject_Employee" Height="30px" Width="54%" class="form1" onkeydown="return DisableEnter(event)" runat="server" Style="margin-right: 1%;"></asp:DropDownList>
           
            </div>
               </div>
          
                          </ContentTemplate>
                    </asp:UpdatePanel>

                     <div style="width:50%;float:right;margin-top:0%">
                  <div class="eachform" style="width:90%;float:left">
                 <h2>From Date*</h2>
               <div id="divFromDate" class="input-append date" style="font-family:Calibri;float:right;width:51%;margin-right: 8%;">
                 <asp:TextBox ID="txtFromDate" class="textDate" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return DisableEnter(event)" Style="width:98.8%;height:23px; font-family: calibri;" ></asp:TextBox>

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

                
                <div class="eachform" style="width:90%;float:left">
                 <h2>To Date</h2>
               <div id="divToDate" class="input-append date" style="font-family:Calibri;float:right;width:51%;margin-right: 8%;">
                 <asp:TextBox ID="txtToDate" class="textDate" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return DisableEnter(event)" Style="width:98.8%;height:23px; font-family: calibri;" ></asp:TextBox>

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
                 <div class="eachform" style="margin-top: 2%;">
                <div class="subform" style="width: 62%; margin-top:5%;margin-right: 3%;">
                    <asp:Button ID="btnAssign" runat="server" class="save" Text="Assign"  OnClientClick="return AssignValidate();" OnClick="btnAssign_Click"/>
                      <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update"  OnClientClick="return AssignValidate();" OnClick="btnUpdate_Click"/>
                    <asp:Button ID="btnCancel" runat="server" style="margin-left: 19px;" OnClientClick="return AlertClearAll();" OnClick="btnCancel_Click"  class="cancel" Text="Cancel"/>
               

                </div>
            </div>
        </div>
                
                 </div>
            </div>

</asp:Content>

