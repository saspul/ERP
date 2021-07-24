<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Salary_Entry_Process.aspx.cs" Inherits="HCM_HCM_Master_hcm_Salary_Entry_Process_hcm_Salary_Entry_Process" %>

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
    <link href="../../../js/salary/toastr.min.css" rel="stylesheet" />
    <script src="../../../js/salary/toastr.min.js"></script>

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
    width: 20.7%; /* Full-width */
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
                 input[type="radio"] {
  display:block;
  width:10%;
  float:left;
  height: 20px;
  margin-top: 2.5%;
}
     label {
         float:left;
     }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

   <asp:HiddenField ID="HiddenEnableModify" runat="server" />
   <asp:HiddenField ID="HiddenEnableAdd" runat="server" />
   <asp:HiddenField ID="HiddenFieldEmpSalaryData" runat="server" />
   <asp:HiddenField ID="hiddenDecimalCount" runat="server" /> 
   <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />

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
     
 <div class="cont_rght" style="width:100%;padding-top: 0%;margin-left: 1%;">     
<div class="sect250">
<div class="row">
<div class="col-xs-12">
<div class="box box-solid">
<div class="box-header">
  <h3 id="lblEntry" runat="server" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;margin-top:0%;">Salary Entry Process</h3>
</div>
<div  class="box-body" >
<div class="container-fluid" style="padding-top: 0px;padding-bottom: 0px;
       border:none;padding-left:0px;padding-right:0px;">
       
<div class="col-sm-12 col-md-12 col-lg-12" style="padding-left:0px;padding-right:0px;">
<div class="col-lg-12 col-md-12 col-sm-12" style="background-color:rgb(226, 230, 217);height:auto;padding-top:20px;padding-bottom:20px;display:block;border: 1px solid #a4ad94;">
<div class="col-sm-6 col-md-6">
    
     <div class="form-group row">
  <label class="col-sm-5 col-form-label font-sty">Department*</label>
  <div id="divDep" class="col-sm-7">
         <asp:DropDownList ID="ddlDepartment"  class="form-control"  runat="server" onkeydown="return isTag(event)" onkeypress="return isTag(event)" >
         </asp:DropDownList>
  
  </div>
         
</div>
   
</div>
<div class="col-sm-6 col-md-6">

 
     <div class="form-group row">
  <label class="col-sm-5 col-form-label font-sty">Type*</label>
  <div class="col-sm-7">
      <div class="smart-form" >
         <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px; width: 95%; float: left; border: 1px solid #04619c; margin-bottom: 1px;">
             <label class="radio" style="font-family: Calibri;">
               <input name="radioCustType"  checked="true"  runat="server" style="display:block"  onkeypress="return DisableEnter(event)" type="radio" id="radioCustType2" />
             <i></i>STAFF</label>
             <label class="radio" style="font-family: Calibri;">
               <input name="radioCustType"   runat="server" style="display:block"   onkeypress="return DisableEnter(event)" type="radio" id="radioCustType1"    />
             <i></i>WORKER</label>
        </div>
         </div>
  
  </div>
</div>
    
</div>
  
    <div class="col-sm-6 col-md-6" style="visibility:hidden;">
     <div class="form-group row">
  <label class="col-sm-5 col-form-label font-sty">Sort By*</label>
  <div class="col-sm-7">
      <div class="smart-form" >
         <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px; width: 95%; float: left; border: 1px solid #04619c; margin-bottom: 1px;">
             <label class="radio" style="font-family: Calibri;">
               <input name="radioSortBy"  checked="true"  runat="server" style="display:block"  onkeypress="return DisableEnter(event)" type="radio" id="radioEmpName" />
             <i></i>EMPLOYEE</label>
             <label class="radio" style="font-family: Calibri;">
               <input name="radioSortBy"   runat="server" style="display:block"   onkeypress="return DisableEnter(event)" type="radio" id="radioEmpCode"    />
             <i></i>EMPLOYEE CODE</label>
        </div>
         </div>
  
  </div>
</div>
    
</div>


     <div style="float:right;display:none;position: fixed;right: 1%;top: 75%;height: 26.5px;z-index: 500;" align="right" id="divGoToBottom" runat="server">
                <a href="javascript:;" id="GoToBottom" title="Goto Bottom">&#x25BC;</a>
            </div> 
    <div class="col-sm-6 col-md-6" >
<span style="float:left;padding-bottom:10px;margin-left: 42.7%;">
<asp:Button ID="btnSearch" runat="server"  Style="margin-left: 81%;height: 29px; margin-left: 5px;padding: 0 21px;cursor: pointer;" class="btn btn-primary" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />
</span> 
        
</div>
<div id="divEmployeeTable" runat="server"></div>
<div class="col-xs-12 col-sm-12" style="margin-top:10px;width:55%;" id="divButtons" runat="server">
 <span style="float:right">
   <asp:Button ID="btnSave" runat="server" class="btn button_sty" style="background-color: #3276b1;border-color: #2c699d;width:100%;"  Text="Close" OnClientClick="return cancelPage();" OnClick="btnSave_Click"/>
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
    $au(function () {
        $au('#cphMain_ddlDepartment').selectToAutocomplete1Letter();
        $("div#divDep input.ui-autocomplete-input").focus();
        $("div#divDep input.ui-autocomplete-input").select();
        addCommasUpdate();
        $("#sl").parent().addClass("sort");
    });

    function myFunction() {
        // Declare variables
        var input, filter, table, tr, td, i,td1;
        input = document.getElementById("myInput");
        filter = input.value.toUpperCase().toString().replace(/\s/g, '');
        tr = $("#tableMain > tbody > tr")
        // Loop through all table rows, and hide those who don't match the search query
        var flag = 0;
        for (i = 0; i < tr.length; i++) {
            td = tr[i].getElementsByTagName("td")[1];
            td1 = tr[i].getElementsByTagName("td")[2];
            if (td) {
                if (td.innerHTML.toUpperCase().toString().replace(/\s/g, '').indexOf(filter) > -1 || td1.innerHTML.toUpperCase().toString().replace(/\s/g, '').indexOf(filter) > -1) {
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
    

    function SearchValidation() {


        $("div#divDep input.ui-autocomplete-input").css("borderColor", "");
        if (document.getElementById("<%=ddlDepartment.ClientID%>").value == "--SELECT DEPARTMENT--") {
                document.getElementById("<%=ddlDepartment.ClientID%>").style.borderColor = "Red";
                $("div#divDep input.ui-autocomplete-input").css("borderColor", "red");
                $("div#divDep input.ui-autocomplete-input").focus();
                $("div#divDep input.ui-autocomplete-input").select();
                toastr.error('Some of the information you entered is not correct or missing. Please check the highlighted fields below.', '', { timeOut: 1500 });
                return false;
            }
        }

       
        function changeAmount(EmpId, AddDedId, Obj) {

            IncrmntConfrmCounter();
            if (confirmbox > 0) {
                var tableOtherItem = document.getElementById("tableMain");
                for (var i = tableOtherItem.rows.length - 1; i > 0; i--) {
                    var EmpId1 = (tableOtherItem.rows[i].cells[0].innerHTML);
                    if (EmpId1 != "No data available" && EmpId1 != EmpId) {
                        $("#tableEmp" + EmpId1 + " :input").attr("disabled", true);
                    }
                }
            }


            document.getElementById("tableMain").style.borderColor = "";
            var PayGrade = document.getElementById("ddlPayGrade" + EmpId).value;
            var Objval = "";
            var CurrObj = "";
            if (Obj == "txtBasicPay") {
                CurrObj = document.getElementById(Obj + EmpId);            
            }
            else {
                CurrObj = document.getElementById(Obj + EmpId + AddDedId);
            }
            CurrObj.value = CurrObj.value.trim().replace(/,/g, "");
            Objval = CurrObj.value.trim();        
            CurrObj.style.borderColor = "";
            if (Objval.match(/^\d+(\.\d+)?$/) && Objval != "" && PayGrade != "-Select-") {
                if (Obj == "txtAmntDed" && document.getElementById("radio2" + EmpId + AddDedId).checked == true && parseFloat(Objval) > 100) {
                    CurrObj.style.borderColor = "red";
                    toastr.error('Percentage should not exceed hundred.', '', { timeOut: 1500 });
                    //CurrObj.value = "";
                    var amt = parseFloat(CurrObj.value);
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                     if (FloatingValue != "") {
                         CurrObj.value = amt.toFixed(FloatingValue);
                     }
                     addCommas(CurrObj);
                    return false;
                }
            }
            else {
                CurrObj.value = "";
                return false;
            }
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var PayGrade = document.getElementById("ddlPayGrade" + EmpId).value;
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "hcm_Salary_Entry_Process.aspx/ReadRangeInfo",
                data: '{PayGrade: "' + PayGrade + '",orgID: "' + orgID + '",corptID: "' + corptID + '",AddDedId: "' + AddDedId + '",Obj: "' + Obj + '"}',
                dataType: "json",
                success: function (data) {

                    if (Obj == "txtAmntDed" && document.getElementById("radio2" + EmpId + AddDedId).checked == true) {                      
                    }
                    else if (data.d[2] == "1" && (parseFloat(Objval) > parseFloat(data.d[1]) || Objval) < parseFloat(data.d[0]))
                    {
                            CurrObj.focus();
                            CurrObj.style.borderColor = "red";
                            toastr.error("Amount restricted within the range of " + data.d[0] + " - " + data.d[1], '', { timeOut: 1500 });
                            //CurrObj.value = "";
                    }
                    if (CurrObj.value != "") {
                        var amt = parseFloat(CurrObj.value);
                        var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                        if (FloatingValue != "") {
                            CurrObj.value = amt.toFixed(FloatingValue);
                        }
                        addCommas(CurrObj);
                    }
                }
            });
           
        }
        function addCommasUpdate() {
            var tableOtherItem = document.getElementById("tableMain");
            for (var i = tableOtherItem.rows.length - 2; i > 0; i--) {
                var EmpId = (tableOtherItem.rows[i].cells[0].innerHTML);
                var tableOtherItemSub = document.getElementById("tableEmp" + EmpId);
                for (var j = tableOtherItemSub.rows.length - 1; j >= 0; j--) {
                   
                    var Mode = "";
                    var Amount = "";
                    var AddDedId = "";

                    if (j == 0) {
                        if (document.getElementById("txtBasicPay" + EmpId).value.trim() != "") {
                            addCommas(document.getElementById("txtBasicPay" + EmpId));
                        }
                    }
                    else if (j > 0) {
                        AddDedId = (tableOtherItemSub.rows[j].cells[0].innerHTML);
                        Mode = (tableOtherItemSub.rows[j].cells[1].innerHTML);
                        if (Mode == "Add" && document.getElementById("txtAmntAdd" + EmpId + AddDedId).value.trim() != "") {
                            addCommas(document.getElementById("txtAmntAdd" + EmpId + AddDedId));
                        }
                        else if (Mode == "Ded" && document.getElementById("txtAmntDed" + EmpId + AddDedId).value.trim() != "") {
                            addCommas(document.getElementById("txtAmntDed" + EmpId + AddDedId));
                        }
                    }
                }
            }
        }
        function addCommas(textboxid) {
          
            nStr = textboxid.value;
            nStr += '';
            var x = nStr.split('.');
            var x1 = x[0];
            var x2 = x[1];
            if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "1") {
                       var rgx = /(\d+)(\d{7})/;
                       if (rgx.test(x1)) {
                           x1 = x1.replace(rgx, '$1' + ',' + '$2');
                       }
                       rgx = /(\d+)(\d{5})/;
                       if (rgx.test(x1)) {
                           x1 = x1.replace(rgx, '$1' + ',' + '$2');
                       }
                       rgx = /(\d+)(\d{3})/;
                       if (rgx.test(x1)) {
                           x1 = x1.replace(rgx, '$1' + ',' + '$2');
                       }
                   }

                   if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "2") {
                var rgx = /(\d+)(\d{9})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }

                rgx = /(\d+)(\d{6})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{5})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{3})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
            }
            if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "3") {
                var rgx = /(\d+)(\d{9})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{6})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{3})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
            }




            if (isNaN(x2))
                textboxid.value = x1;
                //return x1;
            else
                textboxid.value = x1 + "." + x2;
            // return x1 + "." + x2;

        }
        function changePayGrade(EmpId) {
            
            var flag = true;
            var oldVal = document.getElementById("OldValue" + EmpId).innerHTML;          
            var newVal = document.getElementById("ddlPayGrade" + EmpId).value;
            if (oldVal != "") {
                if (!confirm("Are you sure you want to change pay grade?")) {
                    document.getElementById("ddlPayGrade" + EmpId).value = oldVal;
                    flag = false;
                }
                else {
                    if (newVal == "-Select-") {
                        newVal = "";
                    }
                    document.getElementById("OldValue" + EmpId).innerHTML = newVal;
                }
            }
            else {
                document.getElementById("OldValue" + EmpId).innerHTML = newVal;
            }
            if (flag == true) {
                IncrmntConfrmCounter();
                if (confirmbox > 0) {
                    var tableOtherItem = document.getElementById("tableMain");
                    for (var i = tableOtherItem.rows.length - 1; i > 0; i--) {
                        var EmpId1 = (tableOtherItem.rows[i].cells[0].innerHTML);
                        if (EmpId1 != "No data available" && EmpId1 != EmpId) {
                            $("#tableEmp" + EmpId1 + " :input").attr("disabled", true);
                        }
                    }
                }

                document.getElementById("tableMain").style.borderColor = "";
                document.getElementById("ddlPayGrade" + EmpId).style.borderColor = "";
                document.getElementById("txtBasicPay" + EmpId).value = "";
                var PayGrade = document.getElementById("ddlPayGrade" + EmpId).value;
                var orgID = '<%= Session["ORGID"] %>';
                var corptID = '<%= Session["CORPOFFICEID"] %>';
                var userID = '<%= Session["USERID"] %>';
                var tableOtherItemSub = document.getElementById("tableEmp" + EmpId);
                var EmpCode = (tableOtherItemSub.rows[0].cells[0].innerHTML);
                var EmpName = (tableOtherItemSub.rows[0].cells[1].innerHTML);
                var BtnText = document.getElementById("btnadd" + EmpId).innerHTML;
                jQuery('#tableEmp' + EmpId).find("tr").remove();             
                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "hcm_Salary_Entry_Process.aspx/ReadPayGradedtls",
                        data: '{PayGrade: "' + PayGrade + '",orgID: "' + orgID + '",corptID: "' + corptID + '",EmpId: "' + EmpId + '",EmpCode: "' + EmpCode + '",EmpName: "' + EmpName + '",BtnText: "' + BtnText + '",userID: "' + userID + '"}',
                        dataType: "json",
                        success: function (data) {
                            jQuery('#tableEmp' + EmpId).append(data.d[0]);
                        }
                    });
            }
            document.getElementById("ddlPayGrade" + EmpId).focus();
        }
        function changeRadioGroup1(EmpId, DedctnId) {
            IncrmntConfrmCounter();
            document.getElementById("txtAmntDed" + EmpId + DedctnId).value = "";
            if (document.getElementById("radio2" + EmpId + DedctnId).checked == true) {
                document.getElementById("divRadio" + EmpId + DedctnId).style.display = "block";
            }
            else {
                document.getElementById("divRadio" + EmpId + DedctnId).style.display = "none";
            }

            if (confirmbox > 0) {
                var tableOtherItem = document.getElementById("tableMain");
                for (var i = tableOtherItem.rows.length - 1; i >0; i--) {
                    var EmpId1 = (tableOtherItem.rows[i].cells[0].innerHTML);
                    if (EmpId1 != "No data available" && EmpId1 != EmpId) {
                        $("#tableEmp" + EmpId1+" :input").attr("disabled", true);
                    }
                }                     
            }

        }

        //EVM-0023-25-2
        function changeRadioGroupAllwnce(EmpId, AllwncId) {
            IncrmntConfrmCounter();
            document.getElementById("txtAmntAdd" + EmpId + AllwncId).value = "";

            if (confirmbox > 0) {
                var tableOtherItem = document.getElementById("tableMain");
                for (var i = tableOtherItem.rows.length - 1; i > 0; i--) {
                    var EmpId1 = (tableOtherItem.rows[i].cells[0].innerHTML);
                    if (EmpId1 != "No data available" && EmpId1 != EmpId) {
                        $("#tableEmp" + EmpId1 + " :input").attr("disabled", true);
                    }
                }
            }

        }


        function changeRadioGroup2(EmpId) {
            IncrmntConfrmCounter();
            if (confirmbox > 0) {
                var tableOtherItem = document.getElementById("tableMain");
                for (var i = tableOtherItem.rows.length - 1; i > 0; i--) {
                    var EmpId1 = (tableOtherItem.rows[i].cells[0].innerHTML);
                    if (EmpId1 != "No data available" && EmpId1 != EmpId) {
                        $("#tableEmp" + EmpId1 + " :input").attr("disabled", true);
                    }
                }
            }
        }

        function CancelEmpData(EmpId) {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to cancel without save?")) {
                    confirmbox = 0;
                    var tableOtherItem = document.getElementById("tableMain");
                    for (var i = tableOtherItem.rows.length - 1; i > 0; i--) {
                        var EmpId1 = (tableOtherItem.rows[i].cells[0].innerHTML);
                        if (EmpId1 != "No data available") {
                            $("#tableEmp" + EmpId1 + " :input").attr("disabled", false);
                        }
                    }
                    cancelLoadData(EmpId);
                }
                else {
                    return false;
                }
            }
            else {
                if ($("#show" + EmpId).get(0)) {
                    $("#show" + EmpId).parent().click();
                }
            }
           
        }



        function cancelLoadData(EmpId) {
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var userID = '<%= Session["USERID"] %>';
            var tableOtherItemSub = document.getElementById("tableEmp" + EmpId);
            var EmpCode = (tableOtherItemSub.rows[0].cells[0].innerHTML);
            var EmpName = (tableOtherItemSub.rows[0].cells[1].innerHTML);
            var BtnText = document.getElementById("btnadd" + EmpId).innerHTML;
            if (BtnText == "UPDATE") {
                document.getElementById("OldValue" + EmpId).innerHTML = document.getElementById("PayGradeIdSaved" + EmpId).innerHTML;
            }
            jQuery('#tableEmp' + EmpId).find("tr").remove();
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "hcm_Salary_Entry_Process.aspx/ReadPayGradedtlsCancel",
                data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",EmpId: "' + EmpId + '",EmpCode: "' + EmpCode + '",EmpName: "' + EmpName + '",BtnText: "' + BtnText + '",userID: "' + userID + '"}',
                dataType: "json",
                success: function (data) {
                    jQuery('#tableEmp' + EmpId).append(data.d[0]);
                    document.getElementById("btnadd" + EmpId).focus();                   
                }
            });
        }


        function SaveEmpData(EmpId) {

            toastr.clear();
            var ret = true;
            var BtnText = document.getElementById("btnadd" + EmpId).innerHTML;

            var tableOtherItemSub = document.getElementById("tableEmp" + EmpId);

            for (var j = tableOtherItemSub.rows.length-1; j >=0; j--) {
                var PayGrade = document.getElementById("ddlPayGrade" + EmpId).value;
                var BasicPay = document.getElementById("txtBasicPay" + EmpId).value.trim();
                var MainTableId = document.getElementById("SalaryId" + EmpId).innerHTML;

                var Mode = "";
                var Amount = "";
                var SubTableId = "";
                var AddDedId = "";
                if (j == 0) {
                    document.getElementById("txtBasicPay" + EmpId).style.borderColor = "";
                    document.getElementById("ddlPayGrade" + EmpId).style.borderColor = "";
                    if (BasicPay == "") {
                        document.getElementById("txtBasicPay" + EmpId).style.borderColor = "red";
                        document.getElementById("txtBasicPay" + EmpId).focus();
                        ret = false;
                    }
                    if (PayGrade == "-Select-") {
                        document.getElementById("ddlPayGrade" + EmpId).style.borderColor = "red";
                        document.getElementById("ddlPayGrade" + EmpId).focus();
                        ret = false;
                    }
                }
                else if (j > 0) {
                    AddDedId = (tableOtherItemSub.rows[j].cells[0].innerHTML);
                    Mode = (tableOtherItemSub.rows[j].cells[1].innerHTML);
                    SubTableId = (tableOtherItemSub.rows[j].cells[2].innerHTML);


                    if (Mode == "Add") {
                        document.getElementById("txtAmntAdd" + EmpId + AddDedId).style.borderColor = "";
                        Amount = document.getElementById("txtAmntAdd" + EmpId + AddDedId).value.trim();
                        if (Amount == "" && SubTableId != "") {
                            document.getElementById("txtAmntAdd" + EmpId + AddDedId).style.borderColor = "red";
                            document.getElementById("txtAmntAdd" + EmpId + AddDedId).focus();
                            ret = false;
                        }
                        Amount = Amount.replace(/,/g, "");
                        if (document.getElementById("radioPerc" + EmpId + AddDedId).checked == true && parseFloat(Amount) > 100) {
                            document.getElementById("txtAmntAdd" + EmpId + AddDedId).style.borderColor = "red";
                            document.getElementById("txtAmntAdd" + EmpId + AddDedId).focus();
                            toastr.error('Percentage should not exceed hundred.', '', { timeOut: 1500 });
                            ret = false;
                        }
                    }


                    else if (Mode == "Ded" ) {
                        document.getElementById("txtAmntDed" + EmpId + AddDedId).style.borderColor = "";
                        Amount = document.getElementById("txtAmntDed" + EmpId + AddDedId).value.trim();
                        if (Amount == "" && SubTableId != "") {
                            document.getElementById("txtAmntDed" + EmpId + AddDedId).style.borderColor = "red";
                            document.getElementById("txtAmntDed" + EmpId + AddDedId).focus();
                            ret = false;
                        }
                        Amount = Amount.replace(/,/g, "");
                        if (document.getElementById("radio2" + EmpId + AddDedId).checked == true && parseFloat(Amount) > 100) {
                            document.getElementById("txtAmntDed" + EmpId + AddDedId).style.borderColor = "red";
                            document.getElementById("txtAmntDed" + EmpId + AddDedId).focus();
                            toastr.error('Percentage should not exceed hundred.', '', { timeOut: 1500 });
                            ret = false;
                        }
                    }
                }
                var Obj = "";
                var Objval = "";
                var CurrObj = "";
                var PercAmt = "";

                if (j == 0) {
                    Obj = "txtBasicPay";
                    CurrObj = document.getElementById("txtBasicPay" + EmpId);
                }
                else if (j > 0 && Mode == "Add") {
                    Obj = "txtAmntAdd";
                    CurrObj = document.getElementById("txtAmntAdd" + EmpId + AddDedId);

                    if (document.getElementById("radioAmt" + EmpId + AddDedId).checked == true) {
                        PercAmt = 0;
                    }
                    else if (document.getElementById("radioPerc" + EmpId + AddDedId).checked == true) {
                        PercAmt = 1;
                    }
                }
                else {
                    Obj = "txtAmntDed";
                    CurrObj = document.getElementById("txtAmntDed" + EmpId + AddDedId);


                    if (document.getElementById("radio1" + EmpId + AddDedId).checked == true) {
                        PercAmt = 0;
                    }
                    else if (document.getElementById("radio2" + EmpId + AddDedId).checked == true) {
                        PercAmt = 1;
                    }
                }


                Objval = CurrObj.value.trim();
                Objval = Objval.replace(/,/g, "");
                if (Objval != "") {
                    var orgID = '<%= Session["ORGID"] %>';
                    var corptID = '<%= Session["CORPOFFICEID"] %>';
                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "hcm_Salary_Entry_Process.aspx/ReadRangeInfo",
                        data: '{PayGrade: "' + PayGrade + '",orgID: "' + orgID + '",corptID: "' + corptID + '",AddDedId: "' + AddDedId + '",Obj: "' + Obj + '",PercAmt: "' + PercAmt + '"}',
                        dataType: "json",
                        success: function (data) {

                            var strPercAmt = "";
                            if (PercAmt == 0 || PercAmt=="") {
                                strPercAmt = "Amount";
                            }
                            else if (PercAmt == 1) {
                                strPercAmt = "Percentage";
                            }

                            
                            if (data.d[2] == "1" && (parseFloat(Objval) > parseFloat(data.d[1]) || Objval) < parseFloat(data.d[0])) {
                            CurrObj.style.borderColor = "red";
                            toastr.clear();
                            toastr.error(strPercAmt + " restricted within the range of " + data.d[0] + " - " + data.d[1], '', { timeOut: 1500 });
                            CurrObj.focus();
                            ret = false;
                        }





                           // if (Obj == "txtAmntDed" && document.getElementById("radio2" + EmpId + AddDedId).checked == true) {
                           // }
                           // else if (data.d[2] == "1" && (parseFloat(Objval) > parseFloat(data.d[1]) || Objval) < parseFloat(data.d[0])) {
                           //     CurrObj.style.borderColor = "red";
                           //     toastr.clear();
                           //     toastr.error("Amount restricted within the range of " + data.d[0] + " - " + data.d[1], '', { timeOut: 1500 });
                           //     CurrObj.focus();
                           //     ret = false;
                           //}

                        }
                    });
                }
            }

                if (ret == false) {
                    toastr.error('Some of the information you entered is not correct or missing. Please check the highlighted fields below.', '', { timeOut: 1500 });
                    return false;
                }


            var tableOtherItemSub = document.getElementById("tableEmp" + EmpId);
            for (var j = 0; j < tableOtherItemSub.rows.length; j++) {
                    var PayGrade = document.getElementById("ddlPayGrade" + EmpId).value;
                    var BasicPay = document.getElementById("txtBasicPay" + EmpId).value.trim();
                    BasicPay = BasicPay.replace(/,/g, "");
                    var MainTableId = document.getElementById("SalaryId" + EmpId).innerHTML;
                    var PayGradeSaved = document.getElementById("PayGradeIdSaved" + EmpId).innerHTML;
                    var ChangeSts = 0;
                    if (PayGradeSaved != "" && PayGradeSaved != PayGrade) {
                        ChangeSts = 1;
                    }                  
                    var AddDedId = "";
                    var Mode = "";
                    var Amount = "";
                    var AmntPerSts = "";
                    var TotBasicSts = "";
                    var SubTableId = "";
                    if (j > 0) {
                     
                        AddDedId = (tableOtherItemSub.rows[j].cells[0].innerHTML);
                        Mode = (tableOtherItemSub.rows[j].cells[1].innerHTML);
                        SubTableId = (tableOtherItemSub.rows[j].cells[2].innerHTML);
                       if (Mode == "Add") {
                           Amount = document.getElementById("txtAmntAdd" + EmpId + AddDedId).value.trim();
                           Amount = Amount.replace(/,/g, "");
                           AmntPerSts = 0;
                           if (document.getElementById("radioPerc" + EmpId + AddDedId).checked == true) {
                               AmntPerSts = 1;
                           }
                        }
                       else {
                           Amount = document.getElementById("txtAmntDed" + EmpId + AddDedId).value.trim();
                           Amount = Amount.replace(/,/g, "");
                            AmntPerSts = 0;
                            TotBasicSts = 0;
                            if (document.getElementById("radio2" + EmpId + AddDedId).checked == true) {
                                AmntPerSts = 1;
                                if (document.getElementById("radio4" + EmpId + AddDedId).checked == true) {
                                    TotBasicSts = 1;
                                }
                            }
                        }
                    }
                    if (PayGrade != "-Select-" && BasicPay != "" && ((Mode == "" && Amount == "") || (Mode != "" && Amount != ""))) {
                      
                        var orgID = '<%= Session["ORGID"] %>';
                        var corptID = '<%= Session["CORPOFFICEID"] %>';
                        var userId = '<%= Session["USERID"] %>';
                       
                        $.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "hcm_Salary_Entry_Process.aspx/SaveEmpData",
                            data: '{userId: "' + userId + '",orgID: "' + orgID + '",corptID: "' + corptID + '",EmpId: "' + EmpId + '",PayGrade: "' + PayGrade + '",BasicPay: "' + BasicPay + '",Mode: "' + Mode + '",AddDedId: "' + AddDedId + '",AmntPerSts: "' + AmntPerSts + '",TotBasicSts: "' + TotBasicSts + '",Amount: "' + Amount + '",MainTableId: "' + MainTableId + '",SubTableId: "' + SubTableId + '",ChangeSts: "' + ChangeSts + '"}',
                            dataType: "json",
                            success: function (data) {
                                if (data.d[0] != "" && data.d[0] != null) {
                                    document.getElementById("btnadd" + EmpId).innerHTML = "UPDATE";
                                    document.getElementById("SalaryId" + EmpId).innerHTML = data.d[0];
                                    MainTableId = data.d[0];
                                }
                                document.getElementById("PayGradeIdSaved" + EmpId).innerHTML = data.d[1];
                                if (j > 0 && data.d[2] != "" && data.d[2] != null) {
                                   
                                    tableOtherItemSub.rows[j].cells[2].innerHTML = data.d[2];
                                }
                            }
                        });
                    }
            }
            confirmbox = 0;
            var tableOtherItem = document.getElementById("tableMain");
            for (var i = tableOtherItem.rows.length - 1; i > 0; i--) {
                var EmpId1 = (tableOtherItem.rows[i].cells[0].innerHTML);
                if (EmpId1 != "No data available" ) {
                    $("#tableEmp" + EmpId1 + " :input").attr("disabled", false);
                }
            }
            if ($("#show" + EmpId).get(0)) {
                $("#show" + EmpId).parent().click();
            }
           
            if (BtnText == "SAVE") {
                toastr.success('Salary details saved successfully.', '', { timeOut: 1500 });
            }
            else {
                toastr.success('Salary details updated successfully.', '', { timeOut: 1500 });
            }          
            return true;
        }
    </script>
    <script>      
        function SuccessConfirmation() {
            $("#success-alert").html("Salary details saved successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpdation() {
            $("#success-alert").html("Salary details updated successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function isNumberDec(evt) {
         
            var str = $(evt.target).attr("id");
            var res = str.split("y");
            if (res[0] == "txtBasicPa") {
                if ($("#show" + res[1]).get(0)) {
                    if ($("#show" + res[1]).hasClass('glyphicon-chevron-down')) {
                        $("#show" + res[1]).parent().click();
                    }
                }              
            }

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
                var height = $(window).scrollTop();
                if (height == 0)
                    return false;

                $GoTop('html, body').animate({ scrollTop: 0 }, 2000);

                return false;
            });
            $GoTop('#GoToBottom').bind("click", function () {
                if ($(window).scrollTop() + $(window).height() == $(document).height()) {
                    return false;
                }
                $GoTop('html, body').animate({ scrollTop: $(document).height() }, 2000);
                return false;
            });

            scrollFunc();

        });
        function scrollFunc() {
            if ($(document).height() > 2000) {
                document.getElementById("cphMain_divGoToBottom").style.display = "block";
                document.getElementById("cphMain_divscrollToTop").style.display = "block";
            }
            else {
                document.getElementById("cphMain_divGoToBottom").style.display = "none";
                document.getElementById("cphMain_divscrollToTop").style.display = "none";
            }
        }
    </script>
    <script>
        function sortTable(f, n,x) {
            var tbl = $('#tableMain');
            var rows = tbl.find("> tbody > tr");
            //var rows = $('#tableMain tbody > tr').get();

            rows.sort(function (a, b) {

                var A = getVal(a,x);
                var B = getVal(b,x);
                           
                if (A < B) {
                    return -1 * f;
                }
                if (A > B) {
                    return 1 * f;
                }
                return 0;
            });

            function getVal(elm) {
                var v = $(elm).children('td').eq(x).text().toUpperCase();
                return v;
            }

            $.each(rows, function (index, row) {
                $('#tableMain').children('tbody').append(row);
            });
        }
        var f_sl = 1; // flag to toggle the sorting order
        var f_nm = 1; // flag to toggle the sorting order
        $("#thsl").click(function () {
            f_sl *= -1; // toggle the sorting order
            var n = $(this).prevAll().length;
            sortTable(f_sl, n,2);
            $("#sl").toggleClass("glyphicon-arrow-down glyphicon-arrow-up");
            $("#sl").parent().addClass("sort");
            $("#nm").parent().removeClass("sort");
        });
        $("#thnm").click(function () {
            f_nm *= -1; // toggle the sorting order
            var n = $(this).prevAll().length;
            sortTable(f_nm, n,1);
            $("#nm").toggleClass("glyphicon-arrow-down glyphicon-arrow-up");
            $("#nm").parent().addClass("sort");
            $("#sl").parent().removeClass("sort");
        });
        

        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        function cancelPage() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to close this page?")) {
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
        function ShowHide(EmpId) {          
            $("#show" + EmpId).toggleClass("glyphicon-chevron-down glyphicon-chevron-up");
            if ($("#show" + EmpId).hasClass('glyphicon-chevron-down')) {
                $("#tableEmp" + EmpId + " tr:not(:first-child)").hide();
            }
            else {
                $("#tableEmp" + EmpId + " tr:not(:first-child)").show();
            }
        }
    </script>
    <style>
        .sort {
          background-color: #edefea !important;
        }
        #toast-container {
            /*margin-top:10%;*/
            margin-right:3%;
        }
        #toast-container > div {
    width: 400px;
}
    </style>
</asp:Content>

