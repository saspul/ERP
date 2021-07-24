<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Welfare_Service_Transaction.aspx.cs" Inherits="HCM_HCM_Master_hcm_Employee_Welfare_Service_hcm_Employee_Welfare_Service_Transaction_hcm_Welfare_Service_Transaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>

    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />
    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="/js/jQueryUI/jquery-ui.min.js"></script>
    <script src="/js/jQueryUI/jquery-ui.js"></script>
    <script src="/js/datepicker/bootstrap-datepicker.js"></script>
    <link href="/js/datepicker/datepicker3.css" rel="stylesheet" /> 
    <script src="/js/HCM/Common.js"></script>
 <style>
.font-sty {
    font-size:17px;
    color:#696969;
	font-weight: 400;
}
.button_sty {
    font-family: Calibri;
    font-size: 14px;
    color: #fff;
    padding:8px 24px 7px;
    margin: 0;
    line-height: 1;
    font-weight: normal;
    float: left;
    background:#818e6b;
    border: none;
    border-radius: 2px;
    cursor: pointer;
    text-transform: uppercase;
	margin-left: 30px;
	    margin-top: 10px;
}
.button_sty:hover
{background:#6cb3f0;color: #fff;}
.small-btn,.small-btn:focus
{
 background-color:#3276b1;
 color:#FFF;	
}
.small-btn:hover
{
	background-color:#6cb3f0;
	color:#FFF;
}
.btn-default.disabled, .btn-default.disabled.active, .btn-default.disabled.focus, .btn-default.disabled:active, .btn-default.disabled:focus, .btn-default.disabled:hover, .btn-default[disabled], .btn-default[disabled].active, .btn-default[disabled].focus, .btn-default[disabled]:active, .btn-default[disabled]:focus, .btn-default[disabled]:hover, fieldset[disabled] .btn-default, fieldset[disabled] .btn-default.active, fieldset[disabled] .btn-default.focus, fieldset[disabled] .btn-default:active, fieldset[disabled] .btn-default:focus, fieldset[disabled] .btn-default:hover {
    background-color: #8cb3d4;
    border-color: #ccc;
}
     #tableMain .form-control,td {
         font-size:12px;
     } 
     #myInput {
    background-image: url('/css/searchicon.png'); /* Add a search icon to input */
    background-position: 10px 12px; /* Position the search icon */
    background-repeat: no-repeat; /* Do not repeat the icon image */
    width: 22.4%; /* Full-width */
    font-size: 13px; /* Increase font-size */
    padding: 5px 11px 5px 13px; /* Add some padding */
    border: 1px solid #ddd; /* Add a grey border */
    margin-bottom: 5px; /* Add some space below the input */
}
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


                 #scrollToTop,#GoToBottom {
    cursor: pointer;
    background-color: #97c83a;
    display: inline-block;
    height: 40px;
    width: 40px;
    color: #fff;
    font-size: 16pt;
    text-align: center;
    text-decoration: none;
    line-height: 40px;
    border-radius: 35px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

     <asp:HiddenField ID="HiddenEnableModify" runat="server" />
     <asp:HiddenField ID="HiddenEnableConfirm" runat="server" />
     <asp:HiddenField ID="HiddenEnableAdd" runat="server" />


    <asp:HiddenField ID="HiddenFieldDesg" runat="server" />
    <asp:HiddenField ID="HiddenFieldDept" runat="server" />
    <asp:HiddenField ID="HiddenFieldDiv" runat="server" />
    <asp:HiddenField ID="HiddenFieldType" runat="server" />
    <asp:HiddenField ID="HiddenFieldEmp" runat="server" />
    <asp:HiddenField ID="HiddenFieldServ" runat="server" />

   

    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
     <div class="alert alert-success" id="success-alert" style="display: none;margin-left: 1%;width: 100%;">
        <button type="button" class="close" data-dismiss="alert">x</button>
     </div>
     <div class="alert alert-danger" id="divWarning" style="display:none;width: 100%;margin-left: 1%;">
     <button type="button" class="close" data-dismiss="alert">x</button></div>
       <asp:HiddenField ID="HiddenFieldEmpServData" runat="server" />
 <div class="cont_rght" style="width:100%;padding-top: 0%;margin-left: 1%;">
       <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:1.8%; top:30%;height:26.5px;z-index: 500;">
        </div>

<div class="sect250">
<div class="row">
<div class="col-xs-12">
<div class="box box-solid">
<div class="box-header">
  <h3 id="lblEntry" runat="server" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;margin-top:0%;">Add welfare service transaction</h3>
</div>
<div  class="box-body" >
<div class="container-fluid" style="padding-top: 0px;padding-bottom: 0px;
       border:none;padding-left:0px;padding-right:0px;">
       
<div class="col-sm-12 col-md-12 col-lg-12" style="padding-left:0px;padding-right:0px;">
<div class="col-lg-12 col-md-12 col-sm-12" style="background-color:rgb(226, 230, 217);height:auto;padding-top:20px;padding-bottom:20px;display:block;border: 1px solid #a4ad94;">

  
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
   <ContentTemplate> 

        <asp:HiddenField ID="HiddenFieldFocus" runat="server" />

<div class="col-sm-6 col-md-6">
<div class="form-group row">
  <label class="col-sm-5 col-form-label font-sty">Designation<span style="color:#F00;">*</span></label>
  <div id="divDesg" class="col-sm-7">
        <asp:DropDownList ID="ddlDesignation" TabIndex="1" class="form-control" runat="server" onkeydown="return isTag(event)" onkeypress="return isTag(event)"   AutoPostBack="true" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged">
        </asp:DropDownList>
  </div>
</div>


    <div class="form-group row">
  <label class="col-sm-5 col-form-label font-sty">Division</label>
  <div id="divDiv" class="col-sm-7">
         <asp:DropDownList ID="ddlDivision" TabIndex="3" class="form-control" runat="server"  onkeydown="return isTag(event)" onkeypress="return isTag(event)" AutoPostBack="true" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
         </asp:DropDownList>
  
  </div>
</div>

<div class="form-group row">
  <label class="col-sm-5 col-form-label font-sty">Employee</label>
  <div class="col-sm-7">
        <asp:DropDownList ID="ddlEmployee" TabIndex="6" class="form-control"  runat="server" onkeydown="return isTag(event)" onkeypress="return isTag(event)"  >
        <asp:ListItem Text="--SELECT EMPLOYEE--" Value="0"></asp:ListItem>  
        </asp:DropDownList>
  </div>
</div>
   
</div>
<div class="col-sm-6 col-md-6">

     <div class="form-group row">
  <label class="col-sm-5 col-form-label font-sty">Department</label>
  <div id="divDep" class="col-sm-7">
         <asp:DropDownList ID="ddlDepartment" TabIndex="2" class="form-control"  runat="server" onkeydown="return isTag(event)" onkeypress="return isTag(event)" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
         </asp:DropDownList>
  
  </div>
</div>
 
     <div class="form-group row">
  <label class="col-sm-5 col-form-label font-sty">Type</label>
  <div class="col-sm-7">
      <div class="smart-form" >
         <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px; width: 95%; float: left; border: 1px solid #04619c; margin-bottom: 1px;">
             <label class="radio" style="font-family: Calibri;">
               <input name="radioCustType" tabindex="4" checked="true"  runat="server" style="display:block"  onkeypress="return DisableEnter(event)" type="radio" id="radioCustType2" onchange="return radioChange();"   />
             <i></i>STAFF</label>
             <label class="radio" style="font-family: Calibri;">
               <input name="radioCustType" tabindex="5"  runat="server" style="display:block"   onkeypress="return DisableEnter(event)" type="radio" id="radioCustType1"  onchange="return radioChange();"  />
             <i></i>WORKER</label>
        </div>
         </div>
  
  </div>
</div>
     <div class="form-group row">
  <label class="col-sm-5 col-form-label font-sty">Service</label>
  <div class="col-sm-7">
         <asp:DropDownList ID="ddlService" TabIndex="7"  class="form-control" runat="server" onkeydown="return isTag(event)" onkeypress="return isTag(event)" AutoPostBack="false" >
         </asp:DropDownList>
  
  </div>
</div>
</div>
        <asp:Button ID="Button1" runat="server"  style="background-color: #3276b1;border-color: #2c699d;display:none;"  Text="Save"  OnClick="Button1_Click"/>
  </ContentTemplate>
</asp:UpdatePanel>

     <div style="float:right;display:none;position: fixed;right: 1%;top: 75%;height: 26.5px;z-index: 500;" align="right" id="divGoToBottom" runat="server">
                <a href="javascript:;" id="GoToBottom" title="Goto Bottom">&#x25BC;</a>
            </div> 
    <div class="col-lg-12" style="padding:0px;width:79%;margin-bottom:1%;">
<span style="float:right;padding-bottom:10px;">
<asp:Button ID="btnSearch" runat="server" TabIndex="8" Style="margin-left: 81%;height: 29px; margin-left: 5px;padding: 0 21px;cursor: pointer;" class="btn btn-primary" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />
</span> 
        
</div>
<div id="divEmployeeTable" runat="server"></div>
<div class="col-xs-12 col-sm-12" style="margin-top:10px;width:95%;" id="divButtons" runat="server">
 <span style="float:right">

     

      <asp:Button ID="btnSave" runat="server" class="btn button_sty" style="background-color: #3276b1;border-color: #2c699d;"  Text="Save" OnClientClick="return ServiceValidate(this);" OnClick="btnSave_Click"/>
      <asp:Button ID="btnSaveClose" runat="server" class="btn button_sty" style="background-color: #3276b1;border-color: #2c699d;"  Text="Save&Close" OnClientClick="return ServiceValidate(this);" OnClick="btnSave_Click"/>
      <asp:Button ID="btnUpdate" runat="server" class="btn button_sty" style="background-color: #3276b1;border-color: #2c699d;"  Text="Update" OnClientClick="return ServiceValidate(this);" OnClick="btnUpdate_Click"/>
      <asp:Button ID="btnUpdateClose" runat="server" class="btn button_sty" style="background-color: #3276b1;border-color: #2c699d;"  Text="Update&Close" OnClientClick="return ServiceValidate(this);" OnClick="btnUpdate_Click"/>
      <asp:Button ID="btnConfirm" runat="server" class="btn button_sty" style="background-color: #3276b1;border-color: #2c699d;"  Text="Confirm" OnClientClick="return ServiceValidate(this);" OnClick="btnUpdate_Click"/>
      <asp:Button ID="btnCancel" runat="server" class="btn button_sty" style="background-color: #3276b1;border-color: #2c699d;"  Text="Cancel" OnClientClick="return ConfirmMessage();" />
</span>
</div>

            <div style="float:right;margin-top:1%;display:none;position: fixed;right: 1%;top: 60%;height: 26.5px;z-index: 500;" align="right" id="divscrollToTop" runat="server">
                <a href="javascript:;" id="scrollToTop" title="Goto Top">&#x25B2;</a>
            </div>

</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
    <script>
     
        var $au = jQuery.noConflict();
        function EndRequest(sender, args) {
           
           
            $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
            $au('#cphMain_ddlDesignation').selectToAutocomplete1Letter();
            $au('#cphMain_ddlDepartment').selectToAutocomplete1Letter();
            $au('#cphMain_ddlDivision').selectToAutocomplete1Letter();
            $au('#cphMain_ddlService').selectToAutocomplete1Letter();
                   
            
          
            if (document.getElementById("<%=HiddenFieldFocus.ClientID%>").value == "div") {
                $("div#divDiv input.ui-autocomplete-input").focus();
            }
            else if (document.getElementById("<%=HiddenFieldFocus.ClientID%>").value == "des") {              
                $("div#divDesg input.ui-autocomplete-input").focus();
            }
            else if (document.getElementById("<%=HiddenFieldFocus.ClientID%>").value == "dep") {
                $("div#divDep input.ui-autocomplete-input").focus();
            }
        }
        
        $au(function () {
            $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
            $au('#cphMain_ddlDesignation').selectToAutocomplete1Letter();
            $au('#cphMain_ddlDepartment').selectToAutocomplete1Letter();
            $au('#cphMain_ddlDivision').selectToAutocomplete1Letter();
            $au('#cphMain_ddlService').selectToAutocomplete1Letter();

            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(EndRequest);

        });
       
        function myFunction() {
            // Declare variables
            var input, filter, table, tr, td, i;
            input = document.getElementById("myInput");
            filter = input.value.toUpperCase().toString().replace(/\s/g, '');
            tr = $("#tableMain > tbody > tr")
            // Loop through all table rows, and hide those who don't match the search query
            var flag = 0;
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[1];
                if (td) {
                    if (td.innerHTML.toUpperCase().toString().replace(/\s/g, '').indexOf(filter) > -1) {
                        tr[i].style.display = "";
                        flag = 1;
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
            if (flag == 1) {
                document.getElementById("trLast").style.display = "none";
            }
            else {
                document.getElementById("trLast").style.display = "block";
            }
            scrollFunc();
        }
        function radioChange() {      
            document.getElementById("cphMain_Button1").click();
            return false;
        }

        function SearchValidation() {

           
            $("div#divDesg input.ui-autocomplete-input").css("borderColor", "");
            if (document.getElementById("<%=ddlDesignation.ClientID%>").value == "--SELECT DESIGNATION--") {
                document.getElementById("<%=ddlDesignation.ClientID%>").style.borderColor = "Red";
                $("div#divDesg input.ui-autocomplete-input").css("borderColor", "red");
                $("div#divDesg input.ui-autocomplete-input").focus();
                $("div#divDesg input.ui-autocomplete-input").select();
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                return false;              
            }
        }

        function addRow(EmpId, RowNum,DesgId) {
          
            var SerCtgry = document.getElementById("ddlService" + EmpId + RowNum).value;
            var AllDate = document.getElementById("AllotDate" + EmpId + RowNum).value.trim();
            var Allot = document.getElementById("allot" + EmpId + RowNum).value.trim();
            if (SerCtgry != "-Select-" && AllDate != "" && Allot != "") {
                var x = RowNum + 1;
                var recRow = '<tr id="empRow' + EmpId + x + '">';
                recRow += '<td style="display:none;">' + EmpId + x + '</td>';
                recRow += '<td id="Mandatory' + EmpId + x + '" style="display:none;"></td>';
                recRow += '<td id="Freqncy' + EmpId + x + '" style="display:none;"></td>';
                recRow += '<td id="ServiceDateId' + EmpId + x + '" style="display:none;"></td>';
                recRow += '<td style="width:19%;"><select id="ddlService' + EmpId + x + '" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form-control" onchange="return changeService(' + EmpId + ',' + x + ');"></select> </td>';
                recRow += '<td style="width:13%;"><input id="AllotDate' + EmpId + x + '" maxlength=10 onkeydown="return isTag(event)" onkeypress="return isTag(event)" onchange="return changeAllotDate(' + EmpId + ',' + x + ');" type="text" placeholder="dd-mm-yyyy" class="form-control datepicker" /></td>';
                recRow += '<td style="width:14%;"><label id="availability' + EmpId + x + '"></label></td>';
                recRow += '<td style="width:12%;" id="limit' + EmpId + x + '"></td>';
                recRow += '<td style="width:10%;" id="allotted' + EmpId + x + '"></td>';
                recRow += '<td style="width:10%;" id="remaining' + EmpId + x + '"></td>';
                recRow += '<td style="width:12%;"><input id="allot' + EmpId + x + '" maxlength=8 onkeydown="return isNumberDec(event)" onkeypress="return isNumberDec(event)" onchange="return changeAllotNum(' + EmpId + ',' + x + ');" type="text"  class="form-control" /></td>';
                recRow += '<td style="width:10%;"><button id="btnadd' + EmpId + x + '" style="width:100%;" type="button" class="btn btn-default btn-sm small-btn" onclick="return addRow(' + EmpId + ',' + x + ',' + DesgId + ');"><span class="glyphicon glyphicon-plus"></span> Add </button><button id="btnDele' + EmpId + x + '" type="button" class="btn btn-default btn-sm small-btn" onclick="return deleRow(' + EmpId + ',' + x + ',' + DesgId + ');"><span class="glyphicon glyphicon-trash"></span> Delete </button></td>';
                recRow += '</tr>';
                jQuery('#tableEmp' + EmpId).append(recRow);
                document.getElementById("btnadd" + EmpId + RowNum).disabled = true;

                var $options = $("#ddlService" + EmpId +RowNum+"  > option").clone();
                $("#ddlService" + EmpId + x).append($options);

                document.getElementById("ddlService" + EmpId + x).value = "-Select-";

                $p('.datepicker').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    timepicker: false
                });
                scrollFunc();
            }
            else {
                if (Allot == "") {
                    document.getElementById("allot" + EmpId + RowNum).style.borderColor = "red";
                    document.getElementById("allot" + EmpId + RowNum).focus();
                }
                if (AllDate == "") {
                    document.getElementById("AllotDate" + EmpId + RowNum).style.borderColor = "red";
                }
                if (SerCtgry == "-Select-") {
                    document.getElementById("ddlService" + EmpId + RowNum).style.borderColor = "red";
                    document.getElementById("ddlService" + EmpId + RowNum).focus();
                }
                $('html,body').scrollTop(0);
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
            }        
        }

        function deleRow(EmpId, RowNum, DesgId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to remove the service details?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var AllotNum = document.getElementById("allot" + EmpId + RowNum).value.trim();
                    var service = document.getElementById("ddlService" + EmpId + RowNum).value;
                    var allotDate = document.getElementById("AllotDate" + EmpId + RowNum).value.trim();
                    var mandatory = document.getElementById("Mandatory" + EmpId + RowNum).innerHTML;
                    var remainings = parseFloat(document.getElementById("remaining" + EmpId + RowNum).innerHTML);
                    var freqncy = document.getElementById("Freqncy" + EmpId + RowNum).innerHTML;
                    var limit = document.getElementById("limit" + EmpId + RowNum).innerHTML;
                    var serviceDateId = document.getElementById("ServiceDateId" + EmpId + RowNum).innerHTML;
                    var Availbty = document.getElementById("availability" + EmpId + RowNum).innerHTML;
                    var arra = Availbty.split(' ');
                    var totSerAllotPage = 0;

                    var $options = $("#ddlService" + EmpId + RowNum + " > option").clone();
                    var row = document.getElementById("empRow" + EmpId + RowNum);
                    row.parentNode.removeChild(row);

                    var tableOtherItemSub = document.getElementById("tableEmp" + EmpId);
                    if (tableOtherItemSub.rows.length == 1) {

                        //Start:-Add new row
                        var x = 1;
                        var recRow = '<tr id="empRow' + EmpId + x + '">';
                        recRow += '<td style="display:none;">' + EmpId + x + '</td>';
                        recRow += '<td id="Mandatory' + EmpId + x + '" style="display:none;"></td>';
                        recRow += '<td id="Freqncy' + EmpId + x + '" style="display:none;"></td>';
                        recRow += '<td id="ServiceDateId' + EmpId + x + '" style="display:none;"></td>';
                        recRow += '<td style="width:19%;"><select id="ddlService' + EmpId + x + '" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form-control" onchange="return changeService(' + EmpId + ',' + x + ');"></select> </td>';
                        recRow += '<td style="width:13%;"><input id="AllotDate' + EmpId + x + '" maxlength=10 onkeydown="return isTag(event)" onkeypress="return isTag(event)" onchange="return changeAllotDate(' + EmpId + ',' + x + ');" type="text" placeholder="dd-mm-yyyy" class="form-control datepicker" /></td>';
                        recRow += '<td style="width:14%;"><label id="availability' + EmpId + x + '"></label></td>';
                        recRow += '<td style="width:12%;" id="limit' + EmpId + x + '"></td>';
                        recRow += '<td style="width:10%;" id="allotted' + EmpId + x + '"></td>';
                        recRow += '<td style="width:10%;" id="remaining' + EmpId + x + '"></td>';
                        recRow += '<td style="width:12%;"><input id="allot' + EmpId + x + '" maxlength=8 onkeydown="return isNumberDec(event)" onkeypress="return isNumberDec(event)" onchange="return changeAllotNum(' + EmpId + ',' + x + ');" type="text"  class="form-control" /></td>';
                        recRow += '<td style="width:10%;"><button id="btnadd' + EmpId + x + '" style="width:100%;" type="button" class="btn btn-default btn-sm small-btn" onclick="return addRow(' + EmpId + ',' + x + ',' + DesgId + ');"><span class="glyphicon glyphicon-plus"></span> Add </button><button id="btnDele' + EmpId + x + '" type="button" class="btn btn-default btn-sm small-btn" onclick="return deleRow(' + EmpId + ',' + x + ',' + DesgId + ');"><span class="glyphicon glyphicon-trash"></span> Delete </button></td>';
                        recRow += '</tr>';
                        jQuery('#tableEmp' + EmpId).append(recRow);
                        $("#ddlService" + EmpId + x).append($options);
                        document.getElementById("ddlService" + EmpId + x).value = "-Select-";

                        $p('.datepicker').datepicker({
                            autoclose: true,
                            format: 'dd-mm-yyyy',
                            timepicker: false
                        });
                        //End:-Add new row
                    }

                        //Start:-For reordering allot number
                    else if (AllotNum != "") {

                        for (var j = 1; j < tableOtherItemSub.rows.length; j++) {
                            var validRowIDSub = (tableOtherItemSub.rows[j].cells[0].innerHTML);
                            var servId = document.getElementById("ddlService" + validRowIDSub).value;
                            var allotDates = document.getElementById("AllotDate" + validRowIDSub).value.trim();
                            var remaining = document.getElementById("remaining" + validRowIDSub).innerHTML;
                            var TotAllot = document.getElementById("allotted" + validRowIDSub).innerHTML;
                            var AllotNums = document.getElementById("allot" + validRowIDSub).value.trim();
                            var serviceDateIdsub = document.getElementById("ServiceDateId" + validRowIDSub).innerHTML;


                            var datepickerDate = allotDates.trim();
                            var arrDatePickerDate1 = datepickerDate.split("-");

                            var datepickerDate = allotDate;
                            var arrDatePickerDate2 = datepickerDate.split("-");

                            if (serviceDateIdsub == serviceDateId) {

                                if (freqncy == "1 month") {
                                    var Today = arrDatePickerDate1[1] + "-" + arrDatePickerDate1[2];
                                    var dateToDt = arrDatePickerDate2[1] + "-" + arrDatePickerDate2[2];

                                    if (Today == dateToDt && AllotNums != "") {

                                        AllotNums = parseFloat(AllotNums);
                                        totSerAllotPage = totSerAllotPage + AllotNums;
                                        document.getElementById("allot" + validRowIDSub).style.borderColor = "";
                                        document.getElementById("allot" + validRowIDSub).style.backgroundColor = "";

                                        if (totSerAllotPage > parseFloat(remainings) && mandatory != "1") {
                                            document.getElementById("allot" + validRowIDSub).style.backgroundColor = "#fcb8b8";
                                        }
                                        else if (totSerAllotPage > parseFloat(remainings) && mandatory == "1") {
                                            document.getElementById("allot" + validRowIDSub).style.borderColor = "red";
                                        }
                                    }
                                }
                                else if (freqncy == "2 month") {

                                    var datepickerDate = arra[0].trim();
                                    var arrDatePickerDatess = datepickerDate.split("-");
                                    var m1 = parseInt(arrDatePickerDatess[1]);

                                    var m2 = parseInt(arrDatePickerDate2[1]);

                                    if (m1 % 2 == 0) {
                                        if (m2 % 2 == 0) {
                                            m2 = m2 + 1;
                                        }
                                        else {
                                            m2 = m2 - 1;
                                        }
                                    }
                                    else {
                                        if (m2 % 2 == 0) {
                                            m2 = m2 - 1;
                                        }
                                        else {
                                            m2 = m2 + 1;
                                        }
                                    }
                                    var mnth2 = m2.toString();
                                    if (mnth2.length == 1) {
                                        mnth2 = "0" + mnth2;
                                    }

                                    var Today = arrDatePickerDate1[1] + "-" + arrDatePickerDate1[2];
                                    var dateToDt1 = mnth2 + "-" + arrDatePickerDate2[2];
                                    var dateToDt2 = arrDatePickerDate2[1] + "-" + arrDatePickerDate2[2];
                                    if (Today == dateToDt1 || Today == dateToDt2) {


                                        if (AllotNums != "") {
                                            AllotNums = parseFloat(AllotNums);
                                            totSerAllotPage = totSerAllotPage + AllotNums;

                                            document.getElementById("allot" + validRowIDSub).style.borderColor = "";
                                            document.getElementById("allot" + validRowIDSub).style.backgroundColor = "";

                                            if (totSerAllotPage > parseFloat(remainings) && mandatory != "1") {
                                                document.getElementById("allot" + validRowIDSub).style.backgroundColor = "#fcb8b8";
                                            }
                                            else if (totSerAllotPage > parseFloat(remainings) && mandatory == "1") {
                                                document.getElementById("allot" + validRowIDSub).style.borderColor = "red";
                                            }
                                        }

                                    }

                                }
                                else if (freqncy == "1 year") {
                                    var Today = arrDatePickerDate1[2];
                                    var dateToDt = arrDatePickerDate2[2];
                                    if (Today == dateToDt && AllotNums != "") {
                                        AllotNums = parseFloat(AllotNums);
                                        totSerAllotPage = totSerAllotPage + AllotNums;

                                        document.getElementById("allot" + validRowIDSub).style.borderColor = "";
                                        document.getElementById("allot" + validRowIDSub).style.backgroundColor = "";

                                        if (totSerAllotPage > parseFloat(remainings) && mandatory != "1") {
                                            document.getElementById("allot" + validRowIDSub).style.backgroundColor = "#fcb8b8";
                                        }
                                        else if (totSerAllotPage > parseFloat(remainings) && mandatory == "1") {
                                            document.getElementById("allot" + validRowIDSub).style.borderColor = "red";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //End:-For reordering allot number

                    var LastRowid = $("#tableEmp" + EmpId + " tr:last").attr('id');
                    var rowids = LastRowid.split('w');
                    document.getElementById("btnadd" + rowids[1]).disabled = false;
                }
                else {
                    return false;
                }
            });
            scrollFunc();
            return false;      
        }
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('.datepicker').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                timepicker: false,
               
            });

            $("div#divDesg input.ui-autocomplete-input").focus();
            $("div#divDesg input.ui-autocomplete-input").select();
        });    
        function changeService(EmpId, RowNum) {
            document.getElementById("tableMain").style.borderColor = "";
            IncrmntConfrmCounter();
            var service = document.getElementById("ddlService" + EmpId + RowNum).value;
            var dateOfAllot = document.getElementById("AllotDate" + EmpId + RowNum).value.trim();
            document.getElementById("ddlService" + EmpId + RowNum).style.borderColor = "";
            document.getElementById("availability" + EmpId + RowNum).innerHTML = "";
            document.getElementById("limit" + EmpId + RowNum).innerHTML = "";
            document.getElementById("allotted" + EmpId + RowNum).innerHTML = "";
            document.getElementById("remaining" + EmpId + RowNum).innerHTML = "";
            document.getElementById("AllotDate" + EmpId + RowNum).value = "";
            document.getElementById("allot" + EmpId + RowNum).value = "";
            document.getElementById("Mandatory" + EmpId + RowNum).innerHTML = "";
            document.getElementById("Freqncy" + EmpId + RowNum).innerHTML = "";
            document.getElementById("ServiceDateId" + EmpId + RowNum).innerHTML = "";       
            return false;     
        }

        function changeAllotDate(EmpId, RowNum) {
          
            var EmpIdIn = EmpId;
            //Start:-For check date change in welfare service
            var tableOtherItem = document.getElementById("tableMain");
            for (var i = 1; i < tableOtherItem.rows.length - 1; i++) {

                var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);
                var tableOtherItemSub = document.getElementById("tableEmp" + validRowID);

                for (var j = 1; j < tableOtherItemSub.rows.length; j++) {

                    var validRowIDSub = (tableOtherItemSub.rows[j].cells[0].innerHTML);
                    var DesgId = document.getElementById("DsgnId" + validRowID).innerHTML;
                    var service = document.getElementById("ddlService" + validRowIDSub).value;
                    var allotDate = document.getElementById("AllotDate" + validRowIDSub).value.trim();
                    var serviceDateIdsub = document.getElementById("ServiceDateId" + validRowIDSub).innerHTML;
                    var EmpId = validRowID;
                    if (serviceDateIdsub != "" && allotDate != "") {

                        $.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "hcm_Welfare_Service_Transaction.aspx/ReadServDtlDate",
                            data: '{service: "' + service + '",EmpId: "' + EmpId + '",allotDate: "' + allotDate + '",DesgId: "' + DesgId + '"}',
                            dataType: "json",
                            success: function (data) {
                                if (data.d[6] != "" && data.d[6] != null) {


                                    document.getElementById("availability" + validRowIDSub).innerHTML = data.d[6];
                                    document.getElementById("limit" + validRowIDSub).innerHTML = data.d[7];
                                    document.getElementById("Mandatory" + validRowIDSub).innerHTML = data.d[2];
                                    document.getElementById("Freqncy" + validRowIDSub).innerHTML = data.d[3];
                                    document.getElementById("ServiceDateId" + validRowIDSub).innerHTML = data.d[10];
                                    var Availbty = document.getElementById("availability" + validRowIDSub).innerHTML;
                                    var arra = Availbty.split(' ');
                                    if (data.d[3] == "visit") {
                                        document.getElementById("allot" + validRowIDSub).value = data.d[0];
                                        document.getElementById("allot" + validRowIDSub).style.borderColor = "";
                                    }

                                }

                                else {
                                    document.getElementById("AllotDate" + validRowIDSub).style.borderColor = "red";
                                    alert("Service not available on the selected date !");
                                    document.getElementById("AllotDate" + validRowIDSub).value = "";
                                    document.getElementById("availability" + validRowIDSub).innerHTML = "";
                                    document.getElementById("limit" + validRowIDSub).innerHTML = "";
                                    document.getElementById("allotted" + validRowIDSub).innerHTML = "";
                                    document.getElementById("remaining" + validRowIDSub).innerHTML = "";
                                    document.getElementById("allot" + validRowIDSub).value = "";
                                    document.getElementById("Mandatory" + validRowIDSub).innerHTML = "";
                                    document.getElementById("Freqncy" + validRowIDSub).innerHTML = "";
                                    document.getElementById("ServiceDateId" + validRowIDSub).innerHTML = "";
                                    document.getElementById("allot" + validRowIDSub).style.backgroundColor = "";
                                    document.getElementById("allot" + validRowIDSub).style.borderColor = "";


                                    document.getElementById("myInput").value = "";
                                    myFunction();
                                }
                            }
                        });
                    }
                }
            }
            //End:-For check date change in welfare service
           
            EmpId = EmpIdIn;

            document.getElementById("tableMain").style.borderColor = "";
            IncrmntConfrmCounter();         
            var currRowID = EmpId.toString() + RowNum.toString();
            var service = document.getElementById("ddlService" + EmpId + RowNum).value;
            var allotDate = document.getElementById("AllotDate" + EmpId + RowNum).value.trim();
            var totSerAllotPage = 0;
            if (allotDate != "") {
                document.getElementById("AllotDate" + EmpId + RowNum).style.borderColor = "";
            }
           
            if (service != "-Select-" && allotDate != "") {
                    //Start:-For service ctgry & date duplication
                    var tableOtherItemSub = document.getElementById("tableEmp" + EmpId);
                    if (tableOtherItemSub.rows.length > 2) {
                        for (var j = 1; j < tableOtherItemSub.rows.length; j++) {
                            var validRowIDSub = (tableOtherItemSub.rows[j].cells[0].innerHTML);
                            var DesgId = document.getElementById("DsgnId" + EmpId).innerHTML;

                            if (validRowIDSub != currRowID) {
                                var servId = document.getElementById("ddlService" + validRowIDSub).value;
                                var allotDates = document.getElementById("AllotDate" + validRowIDSub).value.trim();
                                if (servId == service && allotDate == allotDates) {
                                    document.getElementById("AllotDate" + EmpId + RowNum).style.borderColor = "red";
                                    alert("Date cannot be duplicated on same service !");
                                    document.getElementById("AllotDate" + EmpId + RowNum).value = "";
                                    document.getElementById("availability" + EmpId + RowNum).innerHTML = "";
                                    document.getElementById("limit" + EmpId + RowNum).innerHTML = "";
                                    document.getElementById("allotted" + EmpId + RowNum).innerHTML = "";
                                    document.getElementById("remaining" + EmpId + RowNum).innerHTML = "";
                                    document.getElementById("allot" + EmpId + RowNum).value = "";
                                    document.getElementById("Mandatory" + EmpId + RowNum).innerHTML = "";
                                    document.getElementById("Freqncy" + EmpId + RowNum).innerHTML = "";
                                    document.getElementById("ServiceDateId" + EmpId + RowNum).innerHTML = "";
                                    document.getElementById("allot" + EmpId + RowNum).style.backgroundColor = "";
                                    document.getElementById("allot" + EmpId + RowNum).style.borderColor = "";
                                    return false;
                                }
                            }
                        }
                    }

                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "hcm_Welfare_Service_Transaction.aspx/CheckServDtlDateDup",
                    data: '{service: "' + service + '",EmpId: "' + EmpId + '",allotDate: "' + allotDate + '"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d[0] == "1") {
                            document.getElementById("AllotDate" + EmpId + RowNum).style.borderColor = "red";
                            alert("Date cannot be duplicated on same service !");
                            document.getElementById("AllotDate" + EmpId + RowNum).value = "";
                            document.getElementById("availability" + EmpId + RowNum).innerHTML = "";
                            document.getElementById("limit" + EmpId + RowNum).innerHTML = "";
                            document.getElementById("allotted" + EmpId + RowNum).innerHTML = "";
                            document.getElementById("remaining" + EmpId + RowNum).innerHTML = "";
                            document.getElementById("allot" + EmpId + RowNum).value = "";
                            document.getElementById("Mandatory" + EmpId + RowNum).innerHTML = "";
                            document.getElementById("Freqncy" + EmpId + RowNum).innerHTML = "";
                            document.getElementById("ServiceDateId" + EmpId + RowNum).innerHTML = "";
                            document.getElementById("allot" + EmpId + RowNum).style.backgroundColor = "";
                            document.getElementById("allot" + EmpId + RowNum).style.borderColor = "";
                            return false;
                        }
                        else {

                            $.ajax({
                                type: "POST",
                                async: false,
                                contentType: "application/json; charset=utf-8",
                                url: "hcm_Welfare_Service_Transaction.aspx/ReadServDtlDate",
                                data: '{service: "' + service + '",EmpId: "' + EmpId + '",allotDate: "' + allotDate + '",DesgId:"'+DesgId+'"}',
                                dataType: "json",
                                success: function (data) {
                                    if (data.d[6] != "" && data.d[6] != null) {

                                        document.getElementById("availability" + EmpId + RowNum).innerHTML = data.d[6];
                                        document.getElementById("limit" + EmpId + RowNum).innerHTML = data.d[7];
                                        document.getElementById("Mandatory" + EmpId + RowNum).innerHTML = data.d[2];
                                        document.getElementById("Freqncy" + EmpId + RowNum).innerHTML = data.d[3];
                                        document.getElementById("ServiceDateId" + EmpId + RowNum).innerHTML = data.d[10];
                                        var Availbty = document.getElementById("availability" + EmpId + RowNum).innerHTML;
                                        var arra = Availbty.split(' ');

                                        if (data.d[3] == "visit") {
                                            document.getElementById("allot" + EmpId + RowNum).value = data.d[0];
                                            document.getElementById("allot" + EmpId + RowNum).style.borderColor = "";
                                        }

                                        //Start:-For service ctgry & date duplication
                                        var tableOtherItemSub = document.getElementById("tableEmp" + EmpId);
                                        for (var j = 1; j < tableOtherItemSub.rows.length; j++) {

                                            var validRowIDSub = (tableOtherItemSub.rows[j].cells[0].innerHTML);
                                            var servId = document.getElementById("ddlService" + validRowIDSub).value;
                                            var allotDates = document.getElementById("AllotDate" + validRowIDSub).value.trim();
                                            var remaining = document.getElementById("remaining" + validRowIDSub).innerHTML;
                                            var TotAllot = document.getElementById("allotted" + validRowIDSub).innerHTML;
                                            var AllotNums = document.getElementById("allot" + validRowIDSub).value.trim();
                                            var serviceDateIdsub = document.getElementById("ServiceDateId" + validRowIDSub).innerHTML;


                                            var datepickerDate = allotDates.trim();
                                            var arrDatePickerDate1 = datepickerDate.split("-");
                                            var datepickerDate = allotDate;
                                            var arrDatePickerDate2 = datepickerDate.split("-");


                                            if (serviceDateIdsub == data.d[10]) {

                                                //Start:-new modification
                                                document.getElementById("availability" + validRowIDSub).innerHTML = data.d[6];
                                                document.getElementById("limit" + validRowIDSub).innerHTML = data.d[7];
                                                document.getElementById("Mandatory" + validRowIDSub).innerHTML = data.d[2];
                                                document.getElementById("Freqncy" + validRowIDSub).innerHTML = data.d[3];                                             
                                                //End:-new modification

                                                if (data.d[3] == "1 month") {
                                                    var Today = arrDatePickerDate1[1] + "-" + arrDatePickerDate1[2];
                                                    var dateToDt = arrDatePickerDate2[1] + "-" + arrDatePickerDate2[2];

                                                    if (Today == dateToDt) {
                                                        document.getElementById("allotted" + validRowIDSub).innerHTML = data.d[8];
                                                        document.getElementById("remaining" + validRowIDSub).innerHTML = data.d[9];


                                                        if (AllotNums != "") {
                                                            AllotNums = parseFloat(AllotNums);
                                                            totSerAllotPage = totSerAllotPage + AllotNums;
                                                            document.getElementById("allot" + validRowIDSub).style.borderColor = "";
                                                            document.getElementById("allot" + validRowIDSub).style.backgroundColor = "";

                                                            if (totSerAllotPage > parseFloat(data.d[9])) {

                                                                if (data.d[2] == "1") {
                                                                    document.getElementById("allot" + validRowIDSub).style.borderColor = "red";
                                                                    alert("Allot count should not be greater than remaining count !");
                                                                    document.getElementById("allot" + validRowIDSub).value = "";
                                                                }
                                                                else {
                                                                    document.getElementById("allot" + validRowIDSub).style.backgroundColor = "#fcb8b8";
                                                                }
                                                            }
                                                        }
                                                    }

                                                }
                                                else if (data.d[3] == "2 month") {

                                                    var datepickerDate = arra[0].trim();
                                                    var arrDatePickerDatess = datepickerDate.split("-");
                                                    var m1 = parseInt(arrDatePickerDatess[1]);

                                                    var m2 = parseInt(arrDatePickerDate2[1]);

                                                    if (m1 % 2 == 0) {
                                                        if (m2 % 2 == 0) {
                                                            m2 = m2 + 1;
                                                        }
                                                        else {
                                                            m2 = m2 - 1;
                                                        }
                                                    }
                                                    else {
                                                        if (m2 % 2 == 0) {
                                                            m2 = m2 - 1;
                                                        }
                                                        else {
                                                            m2 = m2 + 1;
                                                        }
                                                    }
                                                    var mnth2 = m2.toString();
                                                    if (mnth2.length == 1) {
                                                        mnth2 = "0" + mnth2;
                                                    }

                                                    var Today = arrDatePickerDate1[1] + "-" + arrDatePickerDate1[2];
                                                    var dateToDt1 = mnth2 + "-" + arrDatePickerDate2[2];
                                                    var dateToDt2 = arrDatePickerDate2[1] + "-" + arrDatePickerDate2[2];
                                                    if (Today == dateToDt1 || Today == dateToDt2) {
                                                        document.getElementById("allotted" + validRowIDSub).innerHTML = data.d[8];
                                                        document.getElementById("remaining" + validRowIDSub).innerHTML = data.d[9];

                                                        if (AllotNums != "") {
                                                            AllotNums = parseFloat(AllotNums);
                                                            totSerAllotPage = totSerAllotPage + AllotNums;

                                                            document.getElementById("allot" + validRowIDSub).style.borderColor = "";
                                                            document.getElementById("allot" + validRowIDSub).style.backgroundColor = "";

                                                            if (totSerAllotPage > parseFloat(data.d[9])) {

                                                                if (data.d[2] == "1") {
                                                                    document.getElementById("allot" + validRowIDSub).style.borderColor = "red";
                                                                    alert("Allot count should not be greater than remaining count !");
                                                                    document.getElementById("allot" + validRowIDSub).value = "";
                                                                }
                                                                else {
                                                                    document.getElementById("allot" + validRowIDSub).style.backgroundColor = "#fcb8b8";
                                                                }
                                                            }
                                                        }

                                                    }

                                                }
                                                else if (data.d[3] == "1 year") {
                                                    var Today = arrDatePickerDate1[2];
                                                    var dateToDt = arrDatePickerDate2[2];
                                                    if (Today == dateToDt) {
                                                        document.getElementById("allotted" + validRowIDSub).innerHTML = data.d[8];
                                                        document.getElementById("remaining" + validRowIDSub).innerHTML = data.d[9];

                                                        if (AllotNums != "") {
                                                            AllotNums = parseFloat(AllotNums);
                                                            totSerAllotPage = totSerAllotPage + AllotNums;

                                                            document.getElementById("allot" + validRowIDSub).style.borderColor = "";
                                                            document.getElementById("allot" + validRowIDSub).style.backgroundColor = "";

                                                            if (totSerAllotPage > parseFloat(data.d[9])) {

                                                                if (data.d[2] == "1") {
                                                                    document.getElementById("allot" + validRowIDSub).style.borderColor = "red";
                                                                    alert("Allot count should not be greater than remaining count !");
                                                                    document.getElementById("allot" + validRowIDSub).value = "";
                                                                }
                                                                else {
                                                                    document.getElementById("allot" + validRowIDSub).style.backgroundColor = "#fcb8b8";
                                                                }
                                                            }
                                                        }

                                                    }
                                                }
                                                else if (data.d[3] == "visit") {
                                                    document.getElementById("allotted" + validRowIDSub).innerHTML = data.d[8];
                                                    document.getElementById("remaining" + validRowIDSub).innerHTML = "";
                                                }
                                            }
                                        }
                                    }
                                    else {
                                        document.getElementById("AllotDate" + EmpId + RowNum).style.borderColor = "red";
                                        alert("Service not available on the selected date !");
                                        document.getElementById("AllotDate" + EmpId + RowNum).value = "";
                                        document.getElementById("availability" + EmpId + RowNum).innerHTML = "";
                                        document.getElementById("limit" + EmpId + RowNum).innerHTML = "";
                                        document.getElementById("allotted" + EmpId + RowNum).innerHTML = "";
                                        document.getElementById("remaining" + EmpId + RowNum).innerHTML = "";
                                        document.getElementById("allot" + EmpId + RowNum).value = "";
                                        document.getElementById("Mandatory" + EmpId + RowNum).innerHTML = "";
                                        document.getElementById("Freqncy" + EmpId + RowNum).innerHTML = "";
                                        document.getElementById("ServiceDateId" + EmpId + RowNum).innerHTML = "";
                                        document.getElementById("allot" + EmpId + RowNum).style.backgroundColor = "";
                                        document.getElementById("allot" + EmpId + RowNum).style.borderColor = "";
                                    }
                                }
                            });

                        }
                    }
                });
                //End:-For service ctgry & date duplication
                                
            }
            else {
                document.getElementById("AllotDate" + EmpId + RowNum).value = "";
            }
        }
        function changeAllotNum(EmpId, RowNum) {
            document.getElementById("tableMain").style.borderColor = "";
            IncrmntConfrmCounter();
            document.getElementById("allot" + EmpId + RowNum).style.borderColor = "";
            document.getElementById("allot" + EmpId + RowNum).style.backgroundColor = "";

            var currRowID = EmpId.toString() + RowNum.toString();

            var AllotNum = document.getElementById("allot" + EmpId + RowNum).value.trim();
            var service = document.getElementById("ddlService" + EmpId + RowNum).value;
            var allotDate = document.getElementById("AllotDate" + EmpId + RowNum).value.trim();
            var mandatory = document.getElementById("Mandatory" + EmpId + RowNum).innerHTML;
            var remainings = parseFloat(document.getElementById("remaining" + EmpId + RowNum).innerHTML);
            var freqncy = document.getElementById("Freqncy" + EmpId + RowNum).innerHTML;
            var limit = document.getElementById("limit" + EmpId + RowNum).innerHTML;
            var serviceDateId = document.getElementById("ServiceDateId" + EmpId + RowNum).innerHTML;



            if (AllotNum.match(/^\d+(\.\d+)?$/) && AllotNum != "" && allotDate != "" && service != "-Select-" && parseFloat(AllotNum) != "0") {
               
                    if (freqncy == "visit") {
                        var limitArr = limit.split(' ');
                        var LimitAmnt = parseFloat(limitArr[0]);
                        var AllotNumAmnt = parseFloat(AllotNum);
                        if (AllotNumAmnt > LimitAmnt) {
                           
                            if (mandatory == "1") {
                                document.getElementById("allot" + EmpId + RowNum).style.borderColor = "red";
                                alert("Allot count should not be greater than remaining count !");
                                document.getElementById("allot" + EmpId + RowNum).value = "";
                               
                            }
                            else {
                                document.getElementById("allot" + EmpId + RowNum).style.backgroundColor = "#fcb8b8";
                            }
                        }
                    }
                    else {

                        var Availbty = document.getElementById("availability" + EmpId + RowNum).innerHTML;
                        var arra = Availbty.split(' ');
                        var totSerAllotPage = 0;
                        var tableOtherItemSub = document.getElementById("tableEmp" + EmpId);
                        for (var j = 1; j < tableOtherItemSub.rows.length; j++) {

                            var validRowIDSub = (tableOtherItemSub.rows[j].cells[0].innerHTML);

                            var servId = document.getElementById("ddlService" + validRowIDSub).value;
                            var remaining = document.getElementById("remaining" + validRowIDSub).innerHTML;
                            var AllotNums = document.getElementById("allot" + validRowIDSub).value.trim();
                            var allotDates = document.getElementById("AllotDate" + validRowIDSub).value.trim();
                            var TotAllot = document.getElementById("allotted" + validRowIDSub).innerHTML;
                            var serviceDateIdSub = document.getElementById("ServiceDateId" + validRowIDSub).innerHTML;
                           

                            if (serviceDateId == serviceDateIdSub && AllotNums != "") {

                                var datepickerDate = allotDates.trim();
                                var arrDatePickerDate1 = datepickerDate.split("-");

                                var datepickerDate = allotDate;
                                var arrDatePickerDate2 = datepickerDate.split("-");


                                if (freqncy == "1 month") {
                                    var Today = arrDatePickerDate1[1] + "-" + arrDatePickerDate1[2];
                                    var dateToDt = arrDatePickerDate2[1] + "-" + arrDatePickerDate2[2];
                                    if (Today == dateToDt) {
                                        AllotNums = parseFloat(AllotNums);
                                        totSerAllotPage = totSerAllotPage + AllotNums;

                                            document.getElementById("allot" + validRowIDSub).style.borderColor = "";
                                            document.getElementById("allot" + validRowIDSub).style.backgroundColor = "";
                                      
                                         if (totSerAllotPage > remainings) {

                                             if (mandatory == "1") {
                                                document.getElementById("allot" + validRowIDSub).style.borderColor = "red";
                                                alert("Allot count should not be greater than remaining count !");
                                                document.getElementById("allot" + validRowIDSub).value = "";
                                              
                                            }
                                            else {
                                                document.getElementById("allot" + validRowIDSub).style.backgroundColor = "#fcb8b8";
                                            }
                                        }
                                    }
                                }
                                else if (freqncy == "2 month") {


                                    var datepickerDate = arra[0].trim();
                                    var arrDatePickerDatess = datepickerDate.split("-");
                                    var m1 = parseInt(arrDatePickerDatess[1]);

                                    var m2 = parseInt(arrDatePickerDate2[1]);

                                    if (m1 % 2 == 0) {
                                        if (m2 % 2 == 0) {
                                            m2 = m2 + 1;
                                        }
                                        else {
                                            m2 = m2 - 1;
                                        }
                                    }
                                    else {
                                        if (m2 % 2 == 0) {
                                            m2 = m2 - 1;
                                        }
                                        else {
                                            m2 = m2 + 1;
                                        }
                                    }

                                    var mnth2 = m2.toString();
                                    if (mnth2.length == 1) {
                                        mnth2 = "0" + mnth2;
                                    }

                                    var Today = arrDatePickerDate1[1] + "-" + arrDatePickerDate1[2];
                                    var dateToDt1 = mnth2 + "-" + arrDatePickerDate2[2];
                                    var dateToDt2 = arrDatePickerDate2[1] + "-" + arrDatePickerDate2[2];


                                    if (Today == dateToDt1 || Today == dateToDt2) {
                                        AllotNums = parseFloat(AllotNums);
                                        totSerAllotPage = totSerAllotPage + AllotNums;

                                        document.getElementById("allot" + validRowIDSub).style.borderColor = "";
                                        document.getElementById("allot" + validRowIDSub).style.backgroundColor = "";
                                       
                                        if (totSerAllotPage > remainings) {

                                            if (mandatory == "1") {
                                                document.getElementById("allot" + validRowIDSub).style.borderColor = "red";
                                                alert("Allot count should not be greater than remaining count !");
                                                document.getElementById("allot" + validRowIDSub).value = "";
                                               
                                            }
                                            else {
                                                document.getElementById("allot" + validRowIDSub).style.backgroundColor = "#fcb8b8";
                                            }
                                        }
                                    }

                                }
                                else if (freqncy == "1 year") {
                                    var Today = arrDatePickerDate1[2];
                                    var dateToDt = arrDatePickerDate2[2];
                                    if (Today == dateToDt) {

                                        AllotNums = parseFloat(AllotNums);
                                        totSerAllotPage = totSerAllotPage + AllotNums;

                                       
                                        document.getElementById("allot" + validRowIDSub).style.borderColor = "";
                                        document.getElementById("allot" + validRowIDSub).style.backgroundColor = "";
                                      
                                        if (totSerAllotPage > remainings) {

                                            if (mandatory == "1") {
                                                document.getElementById("allot" + validRowIDSub).style.borderColor = "red";
                                                alert("Allot count should not be greater than remaining count !");
                                                document.getElementById("allot" + validRowIDSub).value = "";
                                                
                                            }
                                            else {
                                                document.getElementById("allot" + validRowIDSub).style.backgroundColor = "#fcb8b8";
                                            }
                                        }
                                    }
                                }


                            }

                        }
                        
                    }
            }
            else {
                document.getElementById("allot" + EmpId + RowNum).value = "";
            }
           
        }


        function ServiceValidate(ClickedBtn) {

            var ret = true;
            //Start:-For check date change in welfare service
            document.getElementById("myInput").value = "";
            myFunction();
            var tableOtherItem = document.getElementById("tableMain");
            for (var i = 1; i < tableOtherItem.rows.length - 1; i++) {

                var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);
                var tableOtherItemSub = document.getElementById("tableEmp" + validRowID);

                for (var j = 1; j < tableOtherItemSub.rows.length; j++) {

                    var validRowIDSub = (tableOtherItemSub.rows[j].cells[0].innerHTML);
                    var DesgId = document.getElementById("DsgnId" + validRowID).innerHTML;
                    var service = document.getElementById("ddlService" + validRowIDSub).value;
                    var allotDate = document.getElementById("AllotDate" + validRowIDSub).value.trim();
                    var serviceDateIdsub = document.getElementById("ServiceDateId" + validRowIDSub).innerHTML;
                    var EmpId = validRowID;

                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "hcm_Welfare_Service_Transaction.aspx/ReadServDtlDate",
                        data: '{service: "' + service + '",EmpId: "' + EmpId + '",allotDate: "' + allotDate + '",DesgId:"' + DesgId + '"}',
                        dataType: "json",
                        success: function (data) {


                            document.getElementById("ddlService" + validRowIDSub).options.length = 0;
                            var tableName = "dtServiceCtgry";
                            var $coo = jQuery.noConflict();
                            var ddlTestDropDownListXML = $coo(document.getElementById("ddlService" + validRowIDSub));
                            var OptionStart = $coo("<option>-Select-</option>");
                            OptionStart.attr("value", "-Select-");
                            ddlTestDropDownListXML.append(OptionStart);
                            if (data.d[11] != "" && data.d[11] != null) {
                              
                                // Now find the Table from response and loop through each item (row).
                                $coo(data.d[11]).find(tableName).each(function () {
                                    // Get the OptionValue and OptionText Column values.
                                    var OptionValue = $coo(this).find('WLFRSRVC_ID').text();
                                    var OptionText = $coo(this).find('WLFRSRVC_NAME').text();
                                    // Create an Option for DropDownList.
                                    var option = $coo("<option>" + OptionText + "</option>");
                                    option.attr("value", OptionValue);
                                    ddlTestDropDownListXML.append(option);
                                });                              
                            }

                            if (data.d[6] != "" && data.d[6] != null && data.d[11] != "" && data.d[11] != null) {
                                
                                document.getElementById("availability" + validRowIDSub).innerHTML = data.d[6];
                                document.getElementById("limit" + validRowIDSub).innerHTML = data.d[7];
                                document.getElementById("Mandatory" + validRowIDSub).innerHTML = data.d[2];
                                document.getElementById("Freqncy" + validRowIDSub).innerHTML = data.d[3];
                                document.getElementById("ServiceDateId" + validRowIDSub).innerHTML = data.d[10];
                                var Availbty = document.getElementById("availability" + validRowIDSub).innerHTML;
                                var arra = Availbty.split(' ');
                                if (data.d[3] == "visit") {
                                    document.getElementById("allot" + validRowIDSub).value = data.d[0];
                                    document.getElementById("allot" + validRowIDSub).style.borderColor = "";
                                }
                                if (data.d[12] == "Y") {
                                    document.getElementById("ddlService" + validRowIDSub).value = service;
                                }
                                else {
                                    document.getElementById("ddlService" + validRowIDSub).style.borderColor = "red";
                                    alert("Selected welfare service not allowed !");
                                    document.getElementById("ddlService" + validRowIDSub).style.borderColor = "";
                                    document.getElementById("AllotDate" + validRowIDSub).value = "";
                                    document.getElementById("availability" + validRowIDSub).innerHTML = "";
                                    document.getElementById("limit" + validRowIDSub).innerHTML = "";
                                    document.getElementById("allotted" + validRowIDSub).innerHTML = "";
                                    document.getElementById("remaining" + validRowIDSub).innerHTML = "";
                                    document.getElementById("allot" + validRowIDSub).value = "";
                                    document.getElementById("Mandatory" + validRowIDSub).innerHTML = "";
                                    document.getElementById("Freqncy" + validRowIDSub).innerHTML = "";
                                    document.getElementById("ServiceDateId" + validRowIDSub).innerHTML = "";
                                    document.getElementById("allot" + validRowIDSub).style.backgroundColor = "";
                                    document.getElementById("allot" + validRowIDSub).style.borderColor = "";
                                }
                            }
                            
                            else {
                                if (serviceDateIdsub != "" && allotDate != "" && data.d[12] == "Y") {
                                    document.getElementById("AllotDate" + validRowIDSub).style.borderColor = "red";
                                    alert("Service not available on the selected date !");
                                }
                                document.getElementById("AllotDate" + validRowIDSub).value = "";
                                document.getElementById("availability" + validRowIDSub).innerHTML = "";
                                document.getElementById("limit" + validRowIDSub).innerHTML = "";
                                document.getElementById("allotted" + validRowIDSub).innerHTML = "";
                                document.getElementById("remaining" + validRowIDSub).innerHTML = "";
                                document.getElementById("allot" + validRowIDSub).value = "";
                                document.getElementById("Mandatory" + validRowIDSub).innerHTML = "";
                                document.getElementById("Freqncy" + validRowIDSub).innerHTML = "";
                                document.getElementById("ServiceDateId" + validRowIDSub).innerHTML = "";
                                document.getElementById("allot" + validRowIDSub).style.backgroundColor = "";
                                document.getElementById("allot" + validRowIDSub).style.borderColor = "";
                            }
                        }
                    });
                }
            }
            //End:-For check date change in welfare service



            document.getElementById("<%=HiddenFieldEmpServData.ClientID%>").value = "";
            //Start:-For check missing fields
            var tableOtherItem = document.getElementById("tableMain");
            var m = parseInt(tableOtherItem.rows.length) - 2;
            for (var a = m; a >0; a--) {

                var validRowID = (tableOtherItem.rows[a].cells[0].innerHTML);             
                var tableOtherItemSub = document.getElementById("tableEmp" + validRowID);
                var n = parseInt(tableOtherItemSub.rows.length)-1;
                for (var b = n; b > 0; b--) {

                    var validRowIDSub = (tableOtherItemSub.rows[b].cells[0].innerHTML);
                    document.getElementById("ddlService" + validRowIDSub).style.borderColor = "";
                    document.getElementById("AllotDate" + validRowIDSub).style.borderColor = "";
                    document.getElementById("allot" + validRowIDSub).style.borderColor = "";
               
                    var servId = document.getElementById("ddlService" + validRowIDSub).value;
                    var allotDate = document.getElementById("AllotDate" + validRowIDSub).value.trim();
                    var allot = document.getElementById("allot" + validRowIDSub).value.trim();
                    var remaining = document.getElementById("remaining" + validRowIDSub).innerHTML;
                    var TotAllot = document.getElementById("allotted" + validRowIDSub).innerHTML;
                    if ( allotDate != "" || allot != "") {
                        if (allot == "" || allot == "0") {
                            document.getElementById("allot" + validRowIDSub).style.borderColor = "red";
                            document.getElementById("allot" + validRowIDSub).focus();
                            ret = false;
                        }
                        if (allotDate == "") {
                            document.getElementById("AllotDate" + validRowIDSub).style.borderColor = "red";
                            //document.getElementById("AllotDate" + validRowIDSub).focus();
                            ret = false;
                        }          
                    }
                }
            }
            if (ret == false) {
                $('html,body').scrollTop(0);
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                document.getElementById("myInput").value = "";
                myFunction();
                return false;
            }
            //End:-For check missing fields

            //Start:-For check date duplication
            var tableOtherItem = document.getElementById("tableMain");
            for (var i = 1; i < tableOtherItem.rows.length-1; i++) {
                var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);
                var tableOtherItemSub = document.getElementById("tableEmp" + validRowID);

                for (var j = 1; j < tableOtherItemSub.rows.length; j++) {

                    var validRowIDSub = (tableOtherItemSub.rows[j].cells[0].innerHTML);
                    var servId = document.getElementById("ddlService" + validRowIDSub).value;
                    var serviceDateId = document.getElementById("ServiceDateId" + validRowIDSub).innerHTML;
                    var allotDate = document.getElementById("AllotDate" + validRowIDSub).value.trim();
                    var allot = document.getElementById("allot" + validRowIDSub).value.trim();
                    var remaining = document.getElementById("remaining" + validRowIDSub).innerHTML;
                    var TotAllot = document.getElementById("allotted" + validRowIDSub).innerHTML;
                    var freqncy = document.getElementById("Freqncy" + validRowIDSub).innerHTML;
                    var mandatory = document.getElementById("Mandatory" + validRowIDSub).innerHTML;
                    var Availbty = document.getElementById("availability" + validRowIDSub).innerHTML;
                    var EmpId = validRowID;
                    var service = servId;

                    if (servId != "-Select-" && allotDate != "" && allot != "") {
                        $.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "hcm_Welfare_Service_Transaction.aspx/CheckServDtlDateDup",
                            data: '{service: "' + service + '",EmpId: "' + EmpId + '",allotDate: "' + allotDate + '"}',
                            dataType: "json",
                            success: function (data) {
                                if (data.d[0] == "1") {
                                    document.getElementById("AllotDate" + validRowIDSub).style.borderColor = "red";                              
                                    ret = false;
                                }
                            }
                        });
                    }
                }
            }
            if (ret == false) {
                alert("Date cannot be duplicated on same service!");
                document.getElementById("myInput").value = "";
                myFunction();
                return false;
            }
         //End:-For check date duplication



            //Start:-For check with database
            var tableOtherItem = document.getElementById("tableMain");
            for (var i = 1; i < tableOtherItem.rows.length-1; i++) {
                var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);
                var tableOtherItemSub = document.getElementById("tableEmp" + validRowID);

                var serviceids = "";

                for (var j = 1; j < tableOtherItemSub.rows.length; j++) {

                    var validRowIDSub = (tableOtherItemSub.rows[j].cells[0].innerHTML);
                    var DesgId = document.getElementById("DsgnId" + validRowID).innerHTML;
                    var servId = document.getElementById("ddlService" + validRowIDSub).value;
                    var serviceDateId = document.getElementById("ServiceDateId" + validRowIDSub).innerHTML;

                    if (serviceids.toString().indexOf(serviceDateId.toString()) == "-1") {
                        serviceids = serviceids + "," + serviceDateId;

                    var allotDate = document.getElementById("AllotDate" + validRowIDSub).value.trim();
                    var allot = document.getElementById("allot" + validRowIDSub).value.trim();
                    var remaining = document.getElementById("remaining" + validRowIDSub).innerHTML;
                    var TotAllot = document.getElementById("allotted" + validRowIDSub).innerHTML;             
                    var freqncy = document.getElementById("Freqncy" + validRowIDSub).innerHTML;
                    var mandatory = document.getElementById("Mandatory" + validRowIDSub).innerHTML;
                    var Availbty = document.getElementById("availability" + validRowIDSub).innerHTML;                  

                    var arra = Availbty.split(' ');
                    var totSerAllotPage = 0;

                    var EmpId = validRowID;
                    var service = servId;


                    if (servId != "-Select-" && allotDate != "" && allot != "") {


                        $.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "hcm_Welfare_Service_Transaction.aspx/ReadServDtlDate",
                            data: '{service: "' + service + '",EmpId: "' + EmpId + '",allotDate: "' + allotDate + '",DesgId:"'+DesgId+'"}',
                            dataType: "json",
                            success: function (data) {
                                       
                                //Start:-For service ctgry & date duplication
                                for (var k = 1; k < tableOtherItemSub.rows.length; k++) {

                                    var validRowIDSubk = (tableOtherItemSub.rows[k].cells[0].innerHTML);
                                    var servIdk = document.getElementById("ddlService" + validRowIDSubk).value;
                                    var allotDatesk = document.getElementById("AllotDate" + validRowIDSubk).value.trim();
                                    var remainingk = document.getElementById("remaining" + validRowIDSubk).innerHTML;
                                    var TotAllotk = document.getElementById("allotted" + validRowIDSubk).innerHTML;
                                    var AllotNumsk = document.getElementById("allot" + validRowIDSubk).value.trim();
                                    var serviceDateIdk = document.getElementById("ServiceDateId" + validRowIDSubk).innerHTML;

                                    if (serviceDateId == serviceDateIdk && allotDatesk != "" && AllotNumsk != "") {


                                        document.getElementById("allot" + validRowIDSubk).style.borderColor = "";
                                        document.getElementById("allot" + validRowIDSubk).style.backgroundColor = "";


                                        var datepickerDate = allotDatesk.trim();
                                        var arrDatePickerDate1 = datepickerDate.split("-");

                                        var datepickerDate = allotDate;
                                        var arrDatePickerDate2 = datepickerDate.split("-");


                                        if (freqncy == "1 month") {

                                            var Today = arrDatePickerDate1[1] + "-" + arrDatePickerDate1[2];
                                            var dateToDt = arrDatePickerDate2[1] + "-" + arrDatePickerDate2[2];

                                            if (Today == dateToDt) {
                                                document.getElementById("allotted" + validRowIDSubk).innerHTML = data.d[8];
                                                document.getElementById("remaining" + validRowIDSubk).innerHTML = data.d[9];

                                                       

                                                AllotNumsk = parseFloat(AllotNumsk);
                                                totSerAllotPage = totSerAllotPage + AllotNumsk;

                                                if (totSerAllotPage > parseFloat(data.d[9])) {
                                                               
                                                    if (mandatory == "1") {
                                                        document.getElementById("allot" + validRowIDSubk).style.borderColor = "red";
                                                        ret = false;
                                                    }
                                                    else {
                                                        document.getElementById("allot" + validRowIDSubk).style.backgroundColor = "#fcb8b8";
                                                    }
                                                }
                                                       

                                            }

                                        }
                                        else if (freqncy == "2 month") {

                                            var datepickerDate = arra[0].trim();
                                            var arrDatePickerDatess = datepickerDate.split("-");
                                            var m1 = parseInt(arrDatePickerDatess[1]);

                                            var m2 = parseInt(arrDatePickerDate2[1]);

                                            if (m1 % 2 == 0) {
                                                if (m2 % 2 == 0) {
                                                    m2 = m2 + 1;
                                                }
                                                else {
                                                    m2 = m2 - 1;
                                                }
                                            }
                                            else {
                                                if (m2 % 2 == 0) {
                                                    m2 = m2 - 1;
                                                }
                                                else {
                                                    m2 = m2 + 1;
                                                }
                                            }
                                            var mnth2 = m2.toString();
                                            if (mnth2.length == 1) {
                                                mnth2 = "0" + mnth2;
                                            }

                                            var Today = arrDatePickerDate1[1] + "-" + arrDatePickerDate1[2];
                                            var dateToDt1 = mnth2 + "-" + arrDatePickerDate2[2];
                                            var dateToDt2 = arrDatePickerDate2[1] + "-" + arrDatePickerDate2[2];
                                            if (Today == dateToDt1 || Today == dateToDt2) {
                                                document.getElementById("allotted" + validRowIDSubk).innerHTML = data.d[8];
                                                document.getElementById("remaining" + validRowIDSubk).innerHTML = data.d[9];
                                                       

                                                AllotNumsk = parseFloat(AllotNumsk);
                                                totSerAllotPage = totSerAllotPage + AllotNumsk;

                                                if (totSerAllotPage > parseFloat(data.d[9])) {
                                                               
                                                    if (mandatory == "1") {
                                                        document.getElementById("allot" + validRowIDSubk).style.borderColor = "red";
                                                        ret = false;
                                                    }
                                                    else {
                                                        document.getElementById("allot" + validRowIDSubk).style.backgroundColor = "#fcb8b8";
                                                    }
                                                }
                                                       
                                            }

                                        }
                                        else if (freqncy == "1 year") {
                                            var Today = arrDatePickerDate1[2];
                                            var dateToDt = arrDatePickerDate2[2];
                                            if (Today == dateToDt) {
                                                document.getElementById("allotted" + validRowIDSubk).innerHTML = data.d[8];
                                                document.getElementById("remaining" + validRowIDSubk).innerHTML = data.d[9];
                                                       
                                                AllotNumsk = parseFloat(AllotNumsk);
                                                totSerAllotPage = totSerAllotPage + AllotNumsk;

                                                if (totSerAllotPage > parseFloat(data.d[9])) {
                                                                
                                                    if (mandatory == "1") {
                                                        document.getElementById("allot" + validRowIDSubk).style.borderColor = "red";
                                                        ret = false;
                                                    }
                                                    else {
                                                        document.getElementById("allot" + validRowIDSubk).style.backgroundColor = "#fcb8b8";
                                                    }
                                                }
                                                       
                                            }
                                        }
                                        else if (freqncy == "visit") {
                                            document.getElementById("allotted" + validRowIDSubk).innerHTML = data.d[8];
                                            document.getElementById("remaining" + validRowIDSubk).innerHTML = "";
                                        }


                                    }
                                }

                            }
                           
                        });
                    }
                  }
                }
            }
           
            if (ret == false) {
                alert("Allot count should not be greater than remaining count !");
                document.getElementById("myInput").value = "";
                myFunction();
                return false;
            }
            //End:-For check with database


          


            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];
            var tableOtherItem = document.getElementById("tableMain");
            for (var i = 1; i < tableOtherItem.rows.length-1; i++) {

                var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);
                var tableOtherItemSub = document.getElementById("tableEmp" + validRowID);
                for (var j = 1; j < tableOtherItemSub.rows.length; j++) {

                    var validRowIDSub = (tableOtherItemSub.rows[j].cells[0].innerHTML);
                    var servId = document.getElementById("ddlService" + validRowIDSub).value;
                    var allotDate = document.getElementById("AllotDate" + validRowIDSub).value.trim();
                    var allot = document.getElementById("allot" + validRowIDSub).value.trim();
                    var remaining = document.getElementById("remaining" + validRowIDSub).innerHTML;
                    var TotAllot = document.getElementById("allotted" + validRowIDSub).innerHTML;
                    var serviceDateId = document.getElementById("ServiceDateId" + validRowIDSub).innerHTML;
                    var colorSts = 0;
                    if (document.getElementById("allot" + validRowIDSub).style.backgroundColor == "rgb(252, 184, 184)") {
                        colorSts = 1;
                    }
                    var availability = document.getElementById("availability" + validRowIDSub).innerHTML;
                    var limit = document.getElementById("limit" + validRowIDSub).innerHTML;
                    limit = limit.toString().replace('<br>', '');

                    if (servId != "-Select-" && allotDate != "" && allot != "" && availability != "" && limit != "" && TotAllot!="") {
                        var $add = jQuery.noConflict();
                        var client = JSON.stringify({
                            EMPID: "" + validRowID + "",
                            SERVID: "" + servId + "",
                            ALLOTDATE: "" + allotDate + "",
                            ALLOTNUM: "" + allot + "",
                            REMAIN: "" + remaining + "",
                            TOTALLOT: "" + TotAllot + "",
                            COLORSTS: "" + colorSts + "",
                            AVABLTY: "" + availability + "",
                            LIMIT: "" + limit + "",
                            SERVDATEID: "" + serviceDateId + ""
                        });
                        tbClientJobSheduling.push(client);
                    }
                }
            }
            if (tbClientJobSheduling == "") {
                $('html,body').scrollTop(0);
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                document.getElementById("tableMain").style.borderColor = "red";
                document.getElementById("myInput").value = "";
                myFunction();
                return false;
            }

            if (ClickedBtn.id == "cphMain_btnConfirm") {
                if (confirm("Are you sure you want to confirm?")) {

                }
                else {
                    return false;
                }
            }

            $add("#cphMain_HiddenFieldEmpServData").val(JSON.stringify(tbClientJobSheduling));
            return ret;
        }

      


    </script>
    <script>
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
                        window.location.href = "hcm_Welfare_Service_Transaction_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "hcm_Welfare_Service_Transaction_List.aspx";
                return false;
            }
        }
        function SuccessConfirmation() {
            $("#success-alert").html("Welfare service transaction details inserted successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpdation() {
            $("#success-alert").html("Welfare service transaction details updated successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpdationConfirm() {
            $("#success-alert").html("Welfare service transaction details confirmed successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

       


        function isNumberDec(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //at enter
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
            else if (keyCodes == 190 || keyCodes == 110) {
                return true;
            }
                //left arrow key,right arrow key,home,end ,delete
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
        function isTag(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62 || charCode == 13) {
                ret = false;
            }
            return ret;
        }
       
        var $GoTop = jQuery.noConflict();
        $GoTop(function () {
            $GoTop('#scrollToTop').bind("click", function () {
                $GoTop('html, body').animate({ scrollTop: 0 }, 2000);

                return false;
            });
            $GoTop('#GoToBottom').bind("click", function () {
                $GoTop('html, body').animate({ scrollTop: $(document).height() }, 2000);
                return false;
            });
            
            scrollFunc();
            
        });
        function scrollFunc() {
            if ($(document).height() > 1800) {
                document.getElementById("cphMain_divGoToBottom").style.display = "block";
                document.getElementById("cphMain_divscrollToTop").style.display = "block";
            }
            else {
                document.getElementById("cphMain_divGoToBottom").style.display = "none";
                document.getElementById("cphMain_divscrollToTop").style.display = "none";
            }
        }
    </script>
</asp:Content>

