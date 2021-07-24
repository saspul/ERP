<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="Emp_Issue_Prfrmnce_Form.aspx.cs" Inherits="HCM_HCM_Master_Employee_Performance_Mangmnt_Issue_Performance_Form_Emp_Issue_Prfrmnce_Form" %>

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

      <link href="../../../../css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="../../../../js/jQueryUI/jquery-ui.min.js"></script>
    <script src="../../../../js/jQueryUI/jquery-ui.js"></script>
       <script src="/js/HCM/Common.js"></script>
        <script type="text/javascript">
            var $noCon = jQuery.noConflict();
            $noCon(window).load(function () {
                document.getElementById("<%=txtIssue.ClientID%>").focus();
        var EmpEdit = document.getElementById("<%=HiddenEditEmp.ClientID%>").value;
        var EvalEdit = document.getElementById("<%=HiddenEditEval.ClientID%>").value;
        if (EvalEdit == "" || EmpEdit == "") {
            document.getElementById("<%=cbxGMGoal.ClientID%>").disabled = true;
            document.getElementById("<%=cbxROGoal.ClientID%>").disabled = true;
            document.getElementById("<%=cbxselGoal.ClientID%>").disabled = true;
            document.getElementById("<%=cbxDMGoal.ClientID%>").disabled = true;
            document.getElementById("<%=cbxHRGoal.ClientID%>").disabled = true;
            document.getElementById("<%=ddlEvaluators.ClientID%>").value = 1;
            document.getElementById("<%=ddlEDD.ClientID%>").value = 1;
            document.getElementById('EvalDept').style.display = "none";
            document.getElementById('EvalDsgn').style.display = "none";
            document.getElementById('EvalEmp').style.display = "block";

            document.getElementById('SerchEmployee').style.display = "block";
            document.getElementById('SerchDepartment').style.display = "none";
            document.getElementById('SerchDesgination').style.display = "none";

            document.getElementById('TableselEvalDept').style.display = "none";
            document.getElementById('TableselEvalDsgn').style.display = "none";
            document.getElementById('TableSelectEval').style.display = "block";

            document.getElementById('cphMain_DivEvaluator').style.display = "block";
            document.getElementById('cphMain_divevalDept').style.display = "none";
            document.getElementById('cphMain_divEvalDsgn').style.display = "none";
        }
        if (EmpEdit != "") {
            var find2 = '\\"\\[';
            var re2 = new RegExp(find2, 'g');
            var res2 = EmpEdit.replace(re2, '\[');

            var find3 = '\\]\\"';
            var re3 = new RegExp(find3, 'g');
            var res3 = res2.replace(re3, '\]');
            var json = $noCon.parseJSON(res3);
            for (var key in json) {
                if (json.hasOwnProperty(key)) {
                    if (json[key].USR_ID != "" && json[key].USR_ID != null) {

                        SelectedEmpRows(json[key].ISSUE_EMP_ID, json[key].ISSUE_ID, json[key].USR_ID, json[key].USR);
                    }
                    else if (json[key].DEPT_ID != "" && json[key].DEPT_ID !=null) {
                        SelectedDeptRows(json[key].ISSUE_EMP_ID, json[key].ISSUE_ID, json[key].DEPT_ID, json[key].DEPT);
                    }
                    else if (json[key].DESGN_ID != "" && json[key].DESGN_ID !=null) {

                        SelectedDsgnRows(json[key].ISSUE_EMP_ID, json[key].ISSUE_ID, json[key].DESGN_ID, json[key].DESGN);
                    }
                }
            }
        }
        if (EvalEdit != "") {
            var find2 = '\\"\\[';
            var re2 = new RegExp(find2, 'g');
            var res2 = EvalEdit.replace(re2, '\[');

            var find3 = '\\]\\"';
            var re3 = new RegExp(find3, 'g');
            var res3 = res2.replace(re3, '\]');
            var json = $noCon.parseJSON(res3);
            for (var key in json) {
                if (json.hasOwnProperty(key)) {
                    if (json[key].IUSR_ID != "" && json[key].IUSR_ID !=null) {

                        SelectedEvalRows(json[key].IEVLTR_ID, json[key].IISSUE_ID, json[key].IUSR_ID, json[key].IUSR);
                    }
                    else if (json[key].IDEPT_ID != "" && json[key].IDEPT_ID !=null) {

                        SelectedEvalDepts(json[key].IEVLTR_ID, json[key].IISSUE_ID, json[key].IDEPT_ID, json[key].IDEPT);
                    }
                    else if (json[key].IDESGN_ID != "" && json[key].IDESGN_ID !=null) {
                        SelectedDsgnEvalRows(json[key].IEVLTR_ID, json[key].IISSUE_ID, json[key].IDESGN_ID, json[key].IDESGN);
                    }
                }
            }
        }
        var myEmp = document.getElementById("<%=ddlEDD.ClientID%>").value;
        if (myEmp == "1") {
                 document.getElementById('TableSelectedDept').style.display = "none";
            document.getElementById('TableSelectedDsgn').style.display = "none";
            document.getElementById('TableSelectedEmp').style.display = "block";
            document.getElementById('SerchEmployee').style.display = "block";
            document.getElementById('SerchDepartment').style.display = "none";
            document.getElementById('SerchDesgination').style.display = "none";
            document.getElementById('cphMain_divDsgnList').style.display = "none";
            document.getElementById('cphMain_divDeptList').style.display = "none";
            document.getElementById('cphMain_divEmpList').style.display = "block";
            document.getElementById('DivddlEmpDept').style.visibility = "visible";
            document.getElementById('DivddlEmpDsgn').style.visibility = "visible";
        }
                if (myEmp == "2") {
                    document.getElementById('TableSelectedDept').style.display = "block";
                    document.getElementById('TableSelectedDsgn').style.display = "none";
                    document.getElementById('TableSelectedEmp').style.display = "none";

                    document.getElementById('SerchEmployee').style.display = "none";
                    document.getElementById('SerchDepartment').style.display = "block";
                    document.getElementById('SerchDesgination').style.display = "none";
                    document.getElementById('cphMain_divDsgnList').style.display = "none";
                    document.getElementById('cphMain_divDeptList').style.display = "block";
                    document.getElementById('cphMain_divEmpList').style.display = "none";
                    document.getElementById('DivddlEmpDept').style.visibility = "hidden";
                    document.getElementById('DivddlEmpDsgn').style.visibility = "hidden";
                }
                if (myEmp == "3") {

                    document.getElementById('TableSelectedDept').style.display = "none";
                    document.getElementById('TableSelectedDsgn').style.display = "block";
                    document.getElementById('TableSelectedEmp').style.display = "none";
                    document.getElementById('SerchEmployee').style.display = "none";
                    document.getElementById('SerchDepartment').style.display = "none";
                    document.getElementById('SerchDesgination').style.display = "block";
                    document.getElementById('cphMain_divDsgnList').style.display = "block";
                    document.getElementById('cphMain_divDeptList').style.display = "none";
                    document.getElementById('cphMain_divEmpList').style.display = "none";
                    document.getElementById('DivddlEmpDept').style.visibility = "hidden";
                    document.getElementById('DivddlEmpDsgn').style.visibility = "hidden";
                }
                var myEval= document.getElementById("<%=ddlEvaluators.ClientID%>").value;
        if (myEval == "1") {
            document.getElementById('cphMain_DivEvaluator').style.display = "block";
            document.getElementById('cphMain_divevalDept').style.display = "none";
            document.getElementById('cphMain_divEvalDsgn').style.display = "none";
            document.getElementById('EvalDept').style.display = "none";
            document.getElementById('EvalDsgn').style.display = "none";
            document.getElementById('EvalEmp').style.display = "block";
            document.getElementById('TableselEvalDept').style.display = "none";
            document.getElementById('TableselEvalDsgn').style.display = "none";
            document.getElementById('TableSelectEval').style.display = "block";
            document.getElementById('DivddlEvalDept').style.visibility = "visible";
            document.getElementById('DivddlEvalDsgn').style.visibility = "visible";
        }
        if (myEval == "2") {
            document.getElementById('cphMain_DivEvaluator').style.display = "none";
            document.getElementById('cphMain_divevalDept').style.display = "block";
            document.getElementById('cphMain_divEvalDsgn').style.display = "none";
            document.getElementById('EvalDept').style.display = "block";
            document.getElementById('EvalDsgn').style.display = "none";
            document.getElementById('EvalEmp').style.display = "none";
            document.getElementById('TableselEvalDept').style.display = "block";
            document.getElementById('TableselEvalDsgn').style.display = "none";
            document.getElementById('TableSelectEval').style.display = "none";
            document.getElementById('DivddlEvalDept').style.visibility = "hidden";
            document.getElementById('DivddlEvalDsgn').style.visibility = "hidden";
        }
        if (myEval == "3") {
            document.getElementById('EvalDept').style.display = "none";
            document.getElementById('EvalDsgn').style.display = "block";
            document.getElementById('EvalEmp').style.display = "none";
            document.getElementById('cphMain_DivEvaluator').style.display = "none";
            document.getElementById('cphMain_divevalDept').style.display = "none";
            document.getElementById('cphMain_divEvalDsgn').style.display = "block";
            document.getElementById('TableselEvalDept').style.display = "none";
            document.getElementById('TableselEvalDsgn').style.display = "block";
            document.getElementById('TableSelectEval').style.display = "none";
            document.getElementById('DivddlEvalDept').style.visibility = "hidden";
            document.getElementById('DivddlEvalDsgn').style.visibility = "hidden";
        }
        if (document.getElementById("<%=HiddenConfirm.ClientID%>").value == "1") {
            $('table input[type=checkbox]').attr('disabled', 'true');
            document.getElementById('SerchEmployee').disabled = true;
            document.getElementById('SerchDepartment').disabled = true;
            document.getElementById('SerchDesgination').disabled = true;
            document.getElementById('EvalDept').disabled = true;
            document.getElementById('EvalDsgn').disabled = true;
            document.getElementById('EvalEmp').disabled = true;
        }
        if (document.getElementById("<%=HiddenEvalDsgnId.ClientID%>").value == "" && document.getElementById("<%=HiddenEvalDeptId.ClientID%>").value == "" && document.getElementById("<%=HiddenEvalId.ClientID%>").value == "") {
            document.getElementById('cphMain_cbxEvalGoal').disabled = true;
            document.getElementById('cphMain_cbxEvalGoal').checked = false;

        }
        else {
            document.getElementById('cphMain_cbxEvalGoal').disabled = false;
        }

               
        

    });

            var $NoConfi = jQuery.noConflict();
            $NoConfi(document).ready(function () {
                $('#loading').hide();

            });
    </script>
    <script>
        var DsgnEvalChk = "";
        var DsgnEvalId = "";
        var DsgnEvalName = "";
        var DeptEvalChk = "";
        var DeptEvalId = "";
        var DeptEvalName = "";
        var tempEval = "";
        var EvalId = "";
        var EvalName = "";
        function CheckedEvaluator() {

            var myEmp = document.getElementById("<%=ddlEvaluators.ClientID%>").value;
     
            if (myEmp == "1") {
                document.getElementById("<%=HiddenEvalId.ClientID%>").value = "";
                var ret = true;
                $('#TableAddEvaluator').find('tr').each(function () {
                    var row = $(this);
                    if (row.find('input[type="checkbox"]').is(':checked')) {
                        var rowid = row.find('input[type="checkbox"]').val();
                        row.find('input[type="checkbox"]').prop('checked', false);
                        var tdtext = row.find('#tdEvalUsrName' + rowid).html();
                        var tdIdtext = row.find('#tdEvalUsrId' + rowid).html();
                        row.css('display', 'none');
                        document.getElementById("EvalEmp").value = "";
                        var AddRow = "";
                        AddRow = '<tr class="list-group-item" style="width:380px;" id="SelectRowRemoveEval' + rowid + '" >';
                        AddRow += '<td class="smart-form" style=" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;" > <label class="checkbox " ><input type="checkbox" tabindex=\"27\" value="' + rowid + '" id="cbMandatoryEvalSelect' + rowid + '" onkeypress="return NotEnter(event);"><i  style="margin-top:-27%;"></i></label></td>';
                        AddRow += '  <td class="smart-form" id="tdEvalNameSelect' + rowid + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;">' + tdtext + '</td>';
                        AddRow += '<td id="tdEvalIdSelect' + rowid + '" style="display: none;">' + tdIdtext + '</td>';
                        AddRow += ' </tr>';
                        jQuery('#TableSelectEval').append(AddRow);
                        myEvaluator("EvalEmp");
                 
                    }
                });
      
          

            }
            if (myEmp == "2") {
              
                var ret = true;

                $('#TableEvalDept').find('tr').each(function () {
                    var row = $(this);
                    if (row.find('input[type="checkbox"]').is(':checked')) {
                        var rowid = row.find('input[type="checkbox"]').val();
                        row.find('input[type="checkbox"]').prop('checked', false);
                        var tdtext = row.find('#tdEvalDeptName' + rowid).html();
                        var tdIdtext = row.find('#tdEvalDeptId' + rowid).html();
                        row.css('display', 'none');
                        document.getElementById("EvalDept").value = "";

                        var AddRow = "";
                        AddRow = '<tr class="list-group-item" style="width:382px;" id="SelectDeptRowRemoveEval' + tdIdtext + '" >';
                        AddRow += '<td class="smart-form" style=" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;" > <label class="checkbox " ><input type="checkbox" tabindex=\"27\" value="' + rowid + '" id="cbEvalSelectDept' + rowid + '"><i  style="margin-top:-27%;"></i></label></td>';
                        AddRow += '  <td class="smart-form" id="tdEvaDeptlNameSelect' + rowid + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;">' + tdtext + '</td>';
                        AddRow += '<td id="tdEvalDeptIdSelect' + rowid + '" style="display: none;">' + tdIdtext + '</td>';
                        AddRow += ' </tr>';
                        jQuery('#TableselEvalDept').append(AddRow);
                        myEvaluator("EvalDept");
            
                    }
                });

              
            }
            if (myEmp == "3") {
              
                var ret = true;
                $('#TableEvalDsgn').find('tr').each(function () {
                    var row = $(this);
                    if (row.find('input[type="checkbox"]').is(':checked')) {
                        var rowid = row.find('input[type="checkbox"]').val();
                        row.find('input[type="checkbox"]').prop('checked', false);
                        var tdtext = row.find('#tdEvalDsgntName' + rowid).html();
                        var tdIdtext = row.find('#tdEvalDsgnId' + rowid).html();
                        row.css('display', 'none');
                        document.getElementById("EvalDsgn").value = "";
                        var AddRow = "";
                        AddRow = '<tr class="list-group-item" style="width: 379px;" id="SelectEvalDsgnRow' + tdIdtext + '" >';
                        AddRow += '<td class="smart-form" style=" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;" > <label class="checkbox " ><input type="checkbox" tabindex=\"27\" value="' + rowid + '" id="cbEvalSelectDsgn' + rowid + '"><i  style="margin-top:-25%;"></i></label></td>';
                        AddRow += '  <td class="smart-form" id="tdEvalNameSelect' + rowid + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;">' + tdtext + '</td>';
                        AddRow += '<td id="tdEvalIdSelect' + rowid + '" style="display: none;">' + tdIdtext + '</td>';
                        AddRow += ' </tr>';
                        jQuery('#TableselEvalDsgn').append(AddRow);
                        myEvaluator("EvalDsgn");

                    }
             
                });

            }
            CheckedAllSelect();
            return ret;
        }


        function validateEvaluator() {
            if (CheckedEvaluator()) {

         
            }
            return false;

        }
        function validateProcess() {
            if (CheckedEmployee()) {

    
                return false;
            }
        }
        var UsrId = "";
        var temp = "";
        var tempDgn = "";
        var DsgnId = "";
        var DsgnName = "";

        var UsrName = "";
        var tempDept = "";
        var DeptId = "";
        var DeptName = "";
        function CheckedEmployee() {

            var ret = true;
            var myEmp = document.getElementById("<%=ddlEDD.ClientID%>").value;

            if (myEmp == "1") {

                document.getElementById('TableSelectedDept').style.display = "none";
                document.getElementById('TableSelectedDsgn').style.display = "none";
                document.getElementById('TableSelectedEmp').style.display = "block";
                var table = document.getElementById("TableEmp");
                $('#TableEmp').find('tr').each(function () {
                    var row = $(this);
                    if (row.find('input[type="checkbox"]').is(':checked')) {
                        var rowid = row.find('input[type="checkbox"]').val();
                        row.find('input[type="checkbox"]').prop('checked', false);
                        var tdtext = row.find('#tdUsrName' + rowid).html();
                        var tdIdtext = row.find('#tdUsrId' + rowid).html();
                        row.css('display', 'none');
                        document.getElementById("SerchEmployee").value = "";
                        var AddRow = "";
                        AddRow = '<tr class="list-group-item" id="SelectRowRemove' + rowid + '" style="width:397px;" >';
                        AddRow += '<td class="smart-form" style=" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;" > <label class="checkbox " ><input type="checkbox" tabindex=\"11\" value="' + rowid + '" id="cbMandatoryEmpSelect' + rowid + '" ><i  style="margin-top:-27%;"></i></label></td>';
                        AddRow += '  <td class="smart-form" id="tdUsrNameSelect' + rowid + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;">' + tdtext + '</td>';
                        AddRow += '<td id="tdUsrIdSelect' + rowid + '" style="display: none;">' + tdIdtext + '</td>';
                        AddRow += ' </tr>';
                        jQuery('#TableSelectedEmp').append(AddRow);
                        myEmployee("SerchEmployee");

                    }
                });

            }
            else if (myEmp == "2") {
                document.getElementById('TableSelectedDept').style.display = "block";
                document.getElementById('TableSelectedDsgn').style.display = "none";
                document.getElementById('TableSelectedEmp').style.display = "none";
                document.getElementById('cphMain_divDsgnList').style.display = "none";
                document.getElementById('cphMain_divDeptList').style.display = "block";
                document.getElementById('cphMain_divEmpList').style.display = "none";

                $('#TableDept').find('tr').each(function () {
                    var row = $(this);
                    if (row.find('input[type="checkbox"]').is(':checked')) {
                        var rowid = row.find('input[type="checkbox"]').val();
                        row.find('input[type="checkbox"]').prop('checked', false);
                        var tdtext = row.find('#tdDeptName' + rowid).html();
                        var tdIdtext = row.find('#tdDeptId' + rowid).html();
                        row.css('display', 'none');
                        document.getElementById("SerchDepartment").value = "";
                        var AddRow = "";
                        AddRow = '<tr class="list-group-item" id="SelectDeptRowRemove' + rowid + '" style="width: 397px;" >';
                        AddRow += '<td class="smart-form" style=" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;" > <label class="checkbox " ><input type="checkbox" tabindex=\"11\" value="' + rowid + '" id="cbMandatorySelectDept' + rowid + '"  ><i  style="margin-top:-27%;"></i></label></td>';
                        AddRow += '  <td class="smart-form" id="tdDeptNameSelect' + rowid + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;">' + tdtext + '</td>';
                        AddRow += '<td id="tdDeptIdSelect' + rowid + '" style="display: none;">' + tdIdtext + '</td>';
                        AddRow += ' </tr>';
                        jQuery('#TableSelectedDept').append(AddRow);
                        myEmployee("SerchDepartment");
               
                    }
                });

            }
            else if (myEmp == "3") {
                document.getElementById('TableSelectedDept').style.display = "none";
                document.getElementById('TableSelectedDsgn').style.display = "block";
                document.getElementById('TableSelectedEmp').style.display = "none";

                document.getElementById('cphMain_divDsgnList').style.display = "block";
                document.getElementById('cphMain_divDeptList').style.display = "none";
                document.getElementById('cphMain_divEmpList').style.display = "none";


                $('#TableDsgn').find('tr').each(function () {
                    var row = $(this);
                    if (row.find('input[type="checkbox"]').is(':checked')) {
                        var rowid = row.find('input[type="checkbox"]').val();
                        row.find('input[type="checkbox"]').prop('checked', false);
                        var tdtext = row.find('#tdDsgnName' + rowid).html();
                        var tdIdtext = row.find('#tdDsgnId' + rowid).html();
                        row.css('display', 'none');
                        document.getElementById("SerchDesgination").value = "";

                        var AddRow = "";
                        AddRow = '<tr class="list-group-item" id="SelectDsgnRowRemove' + rowid + '" style="width:397px;">';
                        AddRow += '<td class="smart-form" style=" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;" > <label class="checkbox " ><input type="checkbox" tabindex=\"11\" value="' + rowid + '" id="cbMandatoryDsgnSelect' + rowid + '" ><i  style="margin-top:-27%;"></i></label></td>';
                        AddRow += '  <td class="smart-form" id="tdDsgnNameSelect' + rowid + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;">' + tdtext + '</td>';
                        AddRow += '<td id="tdDsgnIdSelect' + rowid + '" style="display: none;">' + tdIdtext + '</td>';
                        AddRow += ' </tr>';
                        jQuery('#TableSelectedDsgn').append(AddRow);
                        myEmployee("SerchDesgination");

                    }
                });

            }

            CheckedAllSelect();
            return ret;
        }

        var SelectDept = 0;
        var dept = "";
        function SelectedDeptRows(ISSUE_EMP_ID, ISSUE_ID, DEPT_ID, DEPT) {
            if (ISSUE_ID != "" && ISSUE_ID!=null) {
                SelectDept++;
                var recRow = '<tr class=\"list-group-item\" id="SelectDeptRowRemove' + DEPT_ID + '" style="width: 397px;">';
                recRow += '<td class=\"smart-form\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class="checkbox \" ><input type=\"checkbox\" value=\"' + DEPT_ID + '\" id=\"cbMandatorySelectDept' + DEPT_ID + '\"><i  style=\"margin-top:-27%;\"></i></label></td>';
                recRow += '<td id="tdDeptNameSelect' + DEPT_ID + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;">' + DEPT + '</td>';
                recRow += '<td id="tdDeptIdSelect' + DEPT_ID + '" style="display: none;">' + DEPT_ID + '</td>';
                    recRow += '</tr>';
                    jQuery('#TableSelectedDept').append(recRow);

                    if (dept == "") {
                        dept = DEPT_ID;
                    }
                    else {
                        dept = dept + "," + DEPT_ID;
                    }
                    document.getElementById("<%=HiddenDeptId.ClientID%>").value = dept;

                }
        }
        var SelectDgn = 0;
        var Dsgn = "";
        function SelectedDsgnRows(ISSUE_EMP_ID, ISSUE_ID, DESGN_ID, DESGN) {
            if (DESGN_ID != "" && DESGN_ID != null) {
                SelectDgn++;
                var recRow = '<tr class=\"list-group-item\" id="SelectDsgnRowRemove' + DESGN_ID + '" style="width:397px;">';
                recRow += '<td class=\"smart-form\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class="checkbox \" ><input type=\"checkbox\" value=\"' + DESGN_ID + '\" id=\"cbMandatoryDsgnSelect' + DESGN_ID + '\" ><i  style=\"margin-top:-27%;\"></i></label></td>';
                recRow += '<td id="tdDsgnNameSelect' + DESGN_ID + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;">' + DESGN + '</td>';
                recRow += '<td id="tdDsgnIdSelect' + DESGN_ID + '" style="display: none;">' + DESGN_ID + '</td>';
                recRow += '</tr>';
                jQuery('#TableSelectedDsgn').append(recRow);
                if (Dsgn == "") {
                    Dsgn = DESGN_ID;
                }

                else {
                    Dsgn = Dsgn + "," + DESGN_ID;
                }
                document.getElementById("<%=HiddenDsgnId.ClientID%>").value = Dsgn;
            }
        }
        var SelectNo = 0;
        var emp="";
        function SelectedEmpRows(ISSUE_EMP_ID, ISSUE_ID, USR_ID, USR) {
            if (ISSUE_EMP_ID != "" && ISSUE_EMP_ID != null) {
                SelectNo++;
                var recRow = '<tr class=\"list-group-item\" id="SelectRowRemove' + USR_ID + '" style="width: 397px;">';
                recRow += '<td class=\"smart-form\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class="checkbox \" ><input type=\"checkbox\" value=\"' + USR_ID + '\" id=\"cbMandatoryEmpSelect' + USR_ID + '\" ><i  style=\"margin-top:-27%;\"></i></label></td>';
                recRow += '<td id="tdUsrNameSelect' + USR_ID + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;">' + USR + '</td>';
                recRow += '<td id="tdUsrIdSelect' + USR_ID + '" style="display: none;">' + USR_ID + '</td>';
                recRow += '</tr>';
                jQuery('#TableSelectedEmp').append(recRow);
                if (emp == "") {
                    emp = USR_ID;
                }

                else {
                    emp = emp + "," + USR_ID;
                }
                document.getElementById("<%=HiddenUsrId.ClientID%>").value = emp;

            }

        }
        var SelectEvalNo = 0;
        var EmpEval = 0;
  
        function SelectedEvalRows( IEVLTR_ID, IISSUE_ID, IUSR_ID, IUSR) {

            if (IEVLTR_ID != "" && IEVLTR_ID != null) {
                SelectEvalNo++;
                var recRow = '<tr class=\"list-group-item\" id="SelectRowRemoveEval' + IUSR_ID + '" style="width:380px;">';
                recRow += '<td class=\"smart-form\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class="checkbox \" ><input type=\"checkbox\" value=\"' + IUSR_ID + '\" id=\"cbMandatoryEvalSelect' + IUSR_ID + '\" ><i  style=\"margin-top:-27%;\"></i></label></td>';
                recRow += '<td id="tdEvalNameSelect' + IUSR_ID + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;">' + IUSR + '</td>';
                recRow += '<td id="tdEvalIdSelect' + IUSR_ID + '" style="display: none;">' + IUSR_ID + '</td>';
                recRow += '</tr>';
                jQuery('#TableSelectEval').append(recRow);
                CheckedAllSelect();
            }

        }
        var SelectEvalDept = 0;

        var DeptEvalId = "";

        function SelectedEvalDepts(IEVLTR_ID, IISSUE_ID, IDEPT_ID, IDEPT) {
            if (IEVLTR_ID != "" && IEVLTR_ID != null) {
                SelectEvalDept++;
                var recRow = '<tr class=\"list-group-item\" id="SelectDeptRowRemoveEval' + IDEPT_ID + '" style="width:382px;">';
                recRow += '<td class=\"smart-form\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class="checkbox \" ><input type=\"checkbox\" value=\"' + IDEPT_ID + '\" id=\"cbEvalSelectDept' + IDEPT_ID + '\" ><i  style=\"margin-top:-27%;\"></i></label></td>';
                recRow += '<td id="tdEvalNameSelect' + IDEPT_ID + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;">' + IDEPT + '</td>';
                recRow += '<td id="tdEvalIdSelect' + IDEPT_ID + '" style="display: none;">' + IDEPT_ID + '</td>';
                recRow += '</tr>';
                jQuery('#TableselEvalDept').append(recRow);
                if (DeptEvalId == "") {
                    DeptEvalId = IDEPT_ID;
                }

                else {
                    DeptEvalId = DeptEvalId + "," + IDEPT_ID;
                }
                document.getElementById("<%=HiddenEvalDeptId.ClientID%>").value = DeptEvalId;
                if (document.getElementById("<%=HiddenEvalDeptId.ClientID%>").value != "") {
                    document.getElementById('cphMain_cbxEvalGoal').disabled = false;
                }
            }
        }
        var SelectEvalDsgn = 0;
        var DsgnEvalId = "";

        function SelectedDsgnEvalRows(IEVLTR_ID, IISSUE_ID, IDESGN_ID, IDESGN) {
            if (IDESGN_ID != "" && IDESGN_ID != null) {
                SelectEvalDsgn++;
                var recRow = '<tr class=\"list-group-item\" id=\"SelectEvalDsgnRow' + IDESGN_ID + '" style="width: 379px;">';
                recRow += '<td class=\"smart-form\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class="checkbox \" ><input type=\"checkbox\" value=\"' + IDESGN_ID + '\" id=\"cbEvalSelectDsgn' + IDESGN_ID + '\" ><i  style=\"margin-top:-27%;\"></i></label></td>';
                recRow += '<td id="tdEvalNameSelect' + IDESGN_ID + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;">' + IDESGN + '</td>';
                recRow += '<td id="tdEvalIdSelect' + IDESGN_ID + '" style="display: none;">' + IDESGN_ID + '</td>';
                recRow += '</tr>';
                jQuery('#TableselEvalDsgn').append(recRow);
                if (DsgnEvalId == "") {
                    DsgnEvalId = IDESGN_ID;
                }
                else {
                    DsgnEvalId = DsgnEvalId + "," + IDESGN_ID;
                }
                document.getElementById("<%=HiddenEvalDsgnId.ClientID%>").value = DsgnEvalId;
                if (document.getElementById("<%=HiddenEvalDsgnId.ClientID%>").value != "") {
                    document.getElementById('cphMain_cbxEvalGoal').disabled = false;
                }
            }
        }
     
    </script>
    <script>
        function CheckedAllSelect() {
            document.getElementById("<%=HiddenEvalId.ClientID%>").value = "";
            document.getElementById("<%=HiddenEvalDeptId.ClientID%>").value = "";
            document.getElementById("<%=HiddenEvalDsgnId.ClientID%>").value = "";
            document.getElementById("<%=HiddenDsgnId.ClientID%>").value = "";
            document.getElementById("<%=HiddenDeptId.ClientID%>").value = "";

            document.getElementById("<%=HiddenUsrId.ClientID%>").value = "";

            $('#TableSelectEval').find('tr').each(function () {
                var row = $(this);
                rowid = row.find('input[type="checkbox"]').val();
                if (document.getElementById("<%=HiddenEvalId.ClientID%>").value == "") {
                    document.getElementById("<%=HiddenEvalId.ClientID%>").value = rowid;
                }
                else {
                    document.getElementById("<%=HiddenEvalId.ClientID%>").value = document.getElementById("<%=HiddenEvalId.ClientID%>").value + "," + rowid;
                }
            });
            $('#TableselEvalDept').find('tr').each(function () {
                var row = $(this);
                var rowid = row.find('input[type="checkbox"]').val();
                if (document.getElementById("<%=HiddenEvalDeptId.ClientID%>").value == "") {
                    document.getElementById("<%=HiddenEvalDeptId.ClientID%>").value = rowid;
                }
                else {
                    document.getElementById("<%=HiddenEvalDeptId.ClientID%>").value = document.getElementById("<%=HiddenEvalDeptId.ClientID%>").value + "," + rowid;
                }
            });
            $('#TableselEvalDsgn').find('tr').each(function () {
                var row = $(this);
                var rowid = row.find('input[type="checkbox"]').val();
                if (document.getElementById("<%=HiddenEvalDsgnId.ClientID%>").value == "") {
                    document.getElementById("<%=HiddenEvalDsgnId.ClientID%>").value = rowid;
                }
                else {
                    document.getElementById("<%=HiddenEvalDsgnId.ClientID%>").value = document.getElementById("<%=HiddenEvalDsgnId.ClientID%>").value + "," + rowid;
                }
            });
            $('#TableSelectedEmp').find('tr').each(function () {
                var row = $(this);
                var rowid = row.find('input[type="checkbox"]').val();
                if (document.getElementById("<%=HiddenUsrId.ClientID%>").value == "") {
                           document.getElementById("<%=HiddenUsrId.ClientID%>").value = rowid;
                       }
                       else {
                           document.getElementById("<%=HiddenUsrId.ClientID%>").value = document.getElementById("<%=HiddenUsrId.ClientID%>").value + "," + rowid;
                       }
            });
            $('#TableSelectedDept').find('tr').each(function () {
                var row = $(this);
                rowid = row.find('input[type="checkbox"]').val();
                if (document.getElementById("<%=HiddenDeptId.ClientID%>").value == "") {
                           document.getElementById("<%=HiddenDeptId.ClientID%>").value = rowid;
                       }
                       else {
                           document.getElementById("<%=HiddenDeptId.ClientID%>").value = document.getElementById("<%=HiddenDeptId.ClientID%>").value + "," + rowid;
                       }
            });
            $('#TableSelectedDsgn').find('tr').each(function () {
                var row = $(this);
                var rowid = row.find('input[type="checkbox"]').val();
                if (document.getElementById("<%=HiddenDsgnId.ClientID%>").value == "") {
                    document.getElementById("<%=HiddenDsgnId.ClientID%>").value = rowid;
                }
                else {
                    document.getElementById("<%=HiddenDsgnId.ClientID%>").value = document.getElementById("<%=HiddenDsgnId.ClientID%>").value + "," + rowid;
                }
            });
            var EvalEmptable = document.getElementById("TableSelectEval");
            var EvalDepttable = document.getElementById("TableselEvalDept");
            var EvalDsgntable = document.getElementById("TableselEvalDsgn");
            if (EvalEmptable.rows.length <= 0 && EvalDepttable.rows.length <= 0 && EvalDsgntable.rows.length <= 0 && document.getElementById("<%=cbxDMEval.ClientID%>").checked == false && document.getElementById("<%=cbxSelfEval.ClientID%>").checked == false && document.getElementById("<%=cbxROEval.ClientID%>").checked == false && document.getElementById("<%=cbxHREval.ClientID%>").checked == false && document.getElementById("<%=cbxGMEval.ClientID%>").checked == false) {
                document.getElementById('cphMain_cbxEvalGoal').disabled = true;
                document.getElementById('cphMain_cbxEvalGoal').checked = false;

            }
            else {
                document.getElementById('cphMain_cbxEvalGoal').disabled = false;

            }
        }
        function RemoveEvaluator() {
            var myEmp = document.getElementById("<%=ddlEvaluators.ClientID%>").value;
            var IssueId = document.getElementById("<%=HiddenIssueId.ClientID%>").value;
            if (myEmp == "1") {
                $('#TableSelectEval').find('tr').each(function () {
                    var row = $(this);
                    if (row.find('input[type="checkbox"]').is(':checked')) {
                        rowid = row.find('input[type="checkbox"]').val();
                        row.find('input[type="checkbox"]').prop('checked', false);
                        var tdtext = row.find('#tdEvalNameSelect' + rowid).html();
                        var tdIdtext = row.find('#tdEvalIdSelect' + rowid).html();
                        jQuery('#SelectRowRemoveEval' + rowid).remove();
                        jQuery('#EvalEmpRow' + rowid).css('display', 'block');
                        var Details = PageMethods.RemoveEvaltorEmp('TableSelectEval', rowid, IssueId, function (response) {
                            var SucessDetails = response;
                            if (SucessDetails == "success") {
                            }
                        });
                    }
                });
            }
            else if (myEmp == "2") {
                $('#TableselEvalDept').find('tr').each(function () {
                    var row = $(this);
                    if (row.find('input[type="checkbox"]').is(':checked')) {
                        var rowid = row.find('input[type="checkbox"]').val();
                        row.find('input[type="checkbox"]').prop('checked', false);
                        var tdtext = row.find('#tdEvaDeptlNameSelect' + rowid).html();
                        var tdIdtext = row.find('#tdEvalDeptIdSelect' + rowid).html();
                        jQuery('#SelectDeptRowRemoveEval' + rowid).remove();
                        jQuery('#SelectDeptRow' + rowid).css('display', 'block');
                        var Details = PageMethods.RemoveEvaltorEmp('TableselEvalDept', rowid, IssueId, function (response) {
                            var SucessDetails = response;
                            if (SucessDetails == "success") {
                            }
                        });
                    }
                });
            }
            else if (myEmp == "3") {

                $('#TableselEvalDsgn').find('tr').each(function () {
                    var row = $(this);
                    if (row.find('input[type="checkbox"]').is(':checked')) {
                        var rowid = row.find('input[type="checkbox"]').val();
                        row.find('input[type="checkbox"]').prop('checked', false);
                        var tdtext = row.find('#tdEvalNameSelect' + rowid).html();
                        var tdIdtext = row.find('#tdEvalIdSelect' + rowid).html();
                        jQuery('#SelectEvalDsgnRow' + rowid).remove();
                        jQuery('#SelectRow' + rowid).css('display', 'block');
                        var Details = PageMethods.RemoveEvaltorEmp('TableselEvalDsgn', rowid, IssueId, function (response) {
                            var SucessDetails = response;
                            if (SucessDetails == "success") {
                            }
                        });
                    }
                });
            }
            CheckedAllSelect();
            return false;
        }
           function RemoveEmployee() {
             var myEmp = document.getElementById("<%=ddlEDD.ClientID%>").value;
               var IssueId= document.getElementById("<%=HiddenIssueId.ClientID%>").value;
               if (myEmp == "1") {
                   $('#TableSelectedEmp').find('tr').each(function () {
                       var row = $(this);
                       if (row.find('input[type="checkbox"]').is(':checked')) {
                           rowid = row.find('input[type="checkbox"]').val();
                           row.find('input[type="checkbox"]').prop('checked', false);
                           var tdtext = row.find('#tdUsrName' + rowid).html();
                           var tdIdtext = row.find('#tdUsrId' + rowid).html();
                           jQuery('#SelectRowRemove' + rowid).remove();
                           jQuery('#EmpRow' + rowid).css('display', 'block');
                           var Details = PageMethods.RemoveEmp('TableSelectedEmp', rowid, IssueId, function (response) {
                               var SucessDetails = response;
                               if (SucessDetails == "success") {
                               }
                           });
                       }
                   });
               
               }
               else if (myEmp == "2") {
                   $('#TableSelectedDept').find('tr').each(function () {
                       var row = $(this);
                       if (row.find('input[type="checkbox"]').is(':checked')) {
                           rowid = row.find('input[type="checkbox"]').val();
                           row.find('input[type="checkbox"]').prop('checked', false);
                           jQuery('#SelectDeptRowRemove' + rowid).remove();
                           jQuery('#SelectRowDept' + rowid).css('display', 'block');
                           var Details = PageMethods.RemoveEmp('TableSelectedDept', rowid, IssueId, function (response) {
                               var SucessDetails = response;
                               if (SucessDetails == "success") {
                               }
                           });
                       }
                   });
               }
               else if (myEmp == "3") {
                   $('#TableSelectedDsgn').find('tr').each(function () {
                       var row = $(this);
                       if (row.find('input[type="checkbox"]').is(':checked')) {
                           var rowid = row.find('input[type="checkbox"]').val();
                           row.find('input[type="checkbox"]').prop('checked', false);
                           var tdtext = row.find('#tdDsgnNameSelect' + rowid).html();
                           var tdIdtext = row.find('#tdDsgnIdSelect' + rowid).html();
                           jQuery('#SelectDsgnRowRemove' + rowid).remove();
                           jQuery('#SelectRowDsgn' + rowid).css('display', 'block');
                           var Details = PageMethods.RemoveEmp('TableSelectedDsgn', rowid, IssueId, function (response) {
                               var SucessDetails = response;
                               if (SucessDetails == "success") {
                               }
                           });
                       }
                   });
               }
               CheckedAllSelect();
            return false;
        }
    </script>
    <script>

        function CheckConfirm() {
            $noCon("#success-alert").html("Performance form is already confirmed .");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();
            $noCon(window).scrollTop(0);
            return false;
        }
        function SuccessInsertion() {
            $noCon("#success-alert").html("Performance form details inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();
            $noCon(window).scrollTop(0);
            return false;
        }

        function SuccessUpdation() {
            $noCon("#success-alert").html("Performance form details updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 700).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();
            $noCon(window).scrollTop(0);
            return false;
        }

        function CantConfirmation() {
            $noCon("#divWarning").html("Issue performance details already confirmed.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#divWarning").alert();
            $noCon(window).scrollTop(0);
            ret = false;
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
                        window.location.href = "Emp_Issue_Prfrmnce_List.aspx";
                    }
                    else {
                        // window.location.href = "hcm_Emp_welfare_service.aspx";
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "Emp_Issue_Prfrmnce_List.aspx";
            }
        }
        function AlertClearAll() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want clear all data in this page?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    window.location.href = "Emp_Issue_Prfrmnce_Form.aspx";
                }
            });
            return false;
        }
        function ServiceValidate() {

            var ret = true;
            document.getElementById("<%=txtIssue.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtIssuedate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTemplte.ClientID%>").style.borderColor = "";

            var Emptable = document.getElementById("TableSelectedEmp");
            var Depttable = document.getElementById("TableSelectedDept");
            var Dsgntable = document.getElementById("TableSelectedDsgn");
            var EvalEmptable = document.getElementById("TableSelectEval");
            var EvalDepttable = document.getElementById("TableselEvalDept");
            var EvalDsgntable = document.getElementById("TableselEvalDsgn");
            if (Emptable.rows.length <= 0 && Depttable.rows.length <= 0 && Dsgntable.rows.length <= 0) {
                $noCon("#divWarning").html("Choose any employee for issue performance");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#divWarning").alert();
                $noCon(window).scrollTop(0);
                ret = false;
            }

            if (EvalEmptable.rows.length <= 0 && EvalDepttable.rows.length <= 0 && EvalDsgntable.rows.length <= 0 && document.getElementById("<%=cbxDMEval.ClientID%>").checked == false && document.getElementById("<%=cbxSelfEval.ClientID%>").checked == false && document.getElementById("<%=cbxROEval.ClientID%>").checked == false && document.getElementById("<%=cbxHREval.ClientID%>").checked == false && document.getElementById("<%=cbxGMEval.ClientID%>").checked == false) {

                $noCon("#divWarning").html("Choose any evaluators for issue performance");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#divWarning").alert();
                $noCon(window).scrollTop(0);
                ret = false;
            }
            var issue=document.getElementById("<%=txtIssue.ClientID%>").value;
            issue = issue.trim();
            if (issue == "") {
                document.getElementById("<%=txtIssue.ClientID%>").style.borderColor = "Red";
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#divWarning").alert();
                $noCon(window).scrollTop(0);
                ret = false;
            }
            if (document.getElementById("<%=txtIssuedate.ClientID%>").value == "") {
                document.getElementById("<%=txtIssuedate.ClientID%>").style.borderColor = "Red";
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#divWarning").alert();
                $noCon(window).scrollTop(0);
                ret = false;
            }
            else {
                var today = new Date();
                var DateCurrent = document.getElementById("<%=txtIssuedate.ClientID%>").value;
                var arrCurrent = DateCurrent.split("-");
                DateCurrent = new Date(arrCurrent[2], arrCurrent[1]-1, arrCurrent[0]);
     
                var strippedTodaysDate = stripTime(today);
                var strippedParsedInputDate = stripTime(DateCurrent);
                if (strippedParsedInputDate < strippedTodaysDate) {
                    document.getElementById("<%=txtIssuedate.ClientID%>").style.borderColor = "Red";
                    $noCon("#divWarning").html("Issue date should be greater than the current date.");
                    $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    $noCon("#divWarning").alert();
                    $noCon(window).scrollTop(0);
                    ret = false;
                }
            }
            if (document.getElementById("<%=ddlTemplte.ClientID%>").value == "--SELECT TEMPLATE--") {
                document.getElementById("<%=ddlTemplte.ClientID%>").style.borderColor = "Red";
                            $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                            });
                            $noCon("#divWarning").alert();
                            $noCon(window).scrollTop(0);
                            ret = false;
                        }
   

            
            return ret;
        }
        function stripTime(inputDate) {
            var strippedInputDate = new Date(inputDate.getFullYear(), inputDate.getMonth() + 1, inputDate.getDate()); // Require to add one to the month as in JavaScript January is month 0
            return strippedInputDate;
        }
    </script>
        <script>
            function myEmployee(id) {
                var input, filter, table, tr, td, i,j, tdId, selecttd, Allselecttd='';
                if (id == "SerchEmployee")
                {
                    input = document.getElementById("SerchEmployee");
                    filter = input.value.toUpperCase();
                    filter = filter.trim();
                    table = document.getElementById("TableEmp");
                    tr = table.getElementsByTagName("tr");

                    var selecttable = document.getElementById("TableSelectedEmp");
                    var selecttr = selecttable.getElementsByTagName("tr");
                    if (selecttr.length > 0) {
                        for (j = 0; j < selecttr.length; j++) {
                            selecttd = selecttr[j].getElementsByTagName("td")[2];
                            selecttd = selecttd.innerHTML;
                            Allselecttd = Allselecttd + "," + selecttd;
                        }
                        for (i = 0; i < tr.length; i++) {
                            td = tr[i].getElementsByTagName("td")[1];

                            tdId = tr[i].getElementsByTagName("td")[2];
                            if (td) {
                                if (Allselecttd.includes(tdId.innerHTML) == false) {
                                    if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                                        tr[i].style.display = "";
                                    }
                                    else {
                                        tr[i].style.display = "none";
                                    }
                                }
                            }
                        }
                    }
                    else {
                        for (i = 0; i < tr.length; i++) {
                            td = tr[i].getElementsByTagName("td")[1];
                            tdId = tr[i].getElementsByTagName("td")[2];

                            if (td) {
                                if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                                    tr[i].style.display = "";
                                }
                                else {
                                    tr[i].style.display = "none";
                                }
                            }
                        }
                    }
                    //evm-0027
                    document.getElementById('SerchEmployee').focus();
                    //end
                }
                else if (id == "SerchDepartment") {
                    input = document.getElementById("SerchDepartment");
                    filter = input.value.toUpperCase();
                    table = document.getElementById("TableDept");
                    tr = table.getElementsByTagName("tr");

                    var selecttable = document.getElementById("TableSelectedDept");
                    var selecttr = selecttable.getElementsByTagName("tr");
                    if (selecttr.length > 0) {
                        for (j = 0; j < selecttr.length; j++) {
                            selecttd = selecttr[j].getElementsByTagName("td")[2];
                            selecttd = selecttd.innerHTML;
                            Allselecttd = Allselecttd + "," + selecttd;
                        }
                        for (i = 0; i < tr.length; i++) {
                            td = tr[i].getElementsByTagName("td")[1];

                            tdId = tr[i].getElementsByTagName("td")[2];
                            if (td) {
                                if (Allselecttd.includes(tdId.innerHTML) == false) {
                                    if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                                        tr[i].style.display = "";
                                    }
                                    else {
                                        tr[i].style.display = "none";
                                    }
                                }
                            }
                        }
                    }
                    else {
                        for (i = 0; i < tr.length; i++) {
                            td = tr[i].getElementsByTagName("td")[1];
                            tdId = tr[i].getElementsByTagName("td")[2];
                            if (td) {
                                if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                                    tr[i].style.display = "";
                                }
                                else {
                                    tr[i].style.display = "none";
                                }
                            }
                        }
                    }
                    //evm-0027
                    document.getElementById('SerchDepartment').focus();
                    //end
                }
                else if (id == "SerchDesgination") {
                    input = document.getElementById("SerchDesgination");
                    filter = input.value.toUpperCase();
                    table = document.getElementById("TableDsgn");
                    tr = table.getElementsByTagName("tr");

                    var selecttable = document.getElementById("TableSelectedDsgn");
                    var selecttr = selecttable.getElementsByTagName("tr");
                    if (selecttr.length > 0) {
                        for (j = 0; j < selecttr.length; j++) {
                            selecttd = selecttr[j].getElementsByTagName("td")[2];
                            selecttd = selecttd.innerHTML;
                            Allselecttd = Allselecttd + "," + selecttd;
                        }
                        for (i = 0; i < tr.length; i++) {
                            td = tr[i].getElementsByTagName("td")[1];

                            tdId = tr[i].getElementsByTagName("td")[2];
                            if (td) {
                                if (Allselecttd.includes(tdId.innerHTML) == false) {
                                    if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                                        tr[i].style.display = "";
                                    }
                                    else {
                                        tr[i].style.display = "none";
                                    }
                                }
                            }
                        }
                    }
                    else {
                        for (i = 0; i < tr.length; i++) {
                            td = tr[i].getElementsByTagName("td")[1];
                            tdId = tr[i].getElementsByTagName("td")[2];
                            if (td) {
                                if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                                    tr[i].style.display = "";
                                }
                                else {
                                    tr[i].style.display = "none";
                                }
                            }
                        }
                    }
                    //evm-0027
                    document.getElementById('SerchDesgination').focus();
                    //end
                }

            }

            function myEvaluator(id) {
                var input, filter, table, tr, td, i, j, tdId, selecttd, Allselecttd = '';
                if (id == "EvalEmp") {
                    input = document.getElementById("EvalEmp");
                    filter = input.value.toUpperCase();
                    table = document.getElementById("TableAddEvaluator");
                    tr = table.getElementsByTagName("tr");

                    var selecttable = document.getElementById("TableSelectEval");
                    var selecttr = selecttable.getElementsByTagName("tr");
                    if (selecttr.length > 0) {
                        for (j = 0; j < selecttr.length; j++) {
                            selecttd = selecttr[j].getElementsByTagName("td")[2];
                            selecttd = selecttd.innerHTML;
                            Allselecttd = Allselecttd + "," + selecttd;
                        }
                        for (i = 0; i < tr.length; i++) {
                            td = tr[i].getElementsByTagName("td")[1];

                            tdId = tr[i].getElementsByTagName("td")[2];
                            if (td) {
                                if (Allselecttd.includes(tdId.innerHTML) == false) {
                                    if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                                        tr[i].style.display = "";
                                    }
                                    else {
                                        tr[i].style.display = "none";
                                    }
                                }
                            }
                        }
                    }
                    else {
                        for (i = 0; i < tr.length; i++) {
                            td = tr[i].getElementsByTagName("td")[1];
                            tdId = tr[i].getElementsByTagName("td")[2];
                            if (td) {
                                if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                                    tr[i].style.display = "";
                                }
                                else {
                                    tr[i].style.display = "none";
                                }
                            }
                        }
                    }
                }
                else if (id == "EvalDept") {
                    input = document.getElementById("EvalDept");
                    filter = input.value.toUpperCase();
                    table = document.getElementById("TableEvalDept");
                    tr = table.getElementsByTagName("tr");

                    var selecttable = document.getElementById("TableselEvalDept");
                    var selecttr = selecttable.getElementsByTagName("tr");
                    if (selecttr.length > 0) {
                        for (j = 0; j < selecttr.length; j++) {
                            selecttd = selecttr[j].getElementsByTagName("td")[2];
                            selecttd = selecttd.innerHTML;
                            Allselecttd = Allselecttd + "," + selecttd;
                        }
                        for (i = 0; i < tr.length; i++) {
                            td = tr[i].getElementsByTagName("td")[1];

                            tdId = tr[i].getElementsByTagName("td")[2];
                            if (td) {
                                if (Allselecttd.includes(tdId.innerHTML) == false) {
                                    if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                                        tr[i].style.display = "";
                                    }
                                    else {
                                        tr[i].style.display = "none";
                                    }
                                }
                            }
                        }
                    }
                    else {
                        for (i = 0; i < tr.length; i++) {
                            td = tr[i].getElementsByTagName("td")[1];
                            tdId = tr[i].getElementsByTagName("td")[2];
                            if (td) {
                                if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                                    tr[i].style.display = "";
                                }
                                else {
                                    tr[i].style.display = "none";
                                }
                            }
                        }
                    }
                }
                else if (id == "EvalDsgn") {
                    input = document.getElementById("EvalDsgn");
                    filter = input.value.toUpperCase();
                    table = document.getElementById("TableEvalDsgn");
                    tr = table.getElementsByTagName("tr");

                    var selecttable = document.getElementById("TableselEvalDsgn");
                    var selecttr = selecttable.getElementsByTagName("tr");
                    if (selecttr.length > 0) {
                        for (j = 0; j < selecttr.length; j++) {
                            selecttd = selecttr[j].getElementsByTagName("td")[2];
                            selecttd = selecttd.innerHTML;
                            Allselecttd = Allselecttd + "," + selecttd;
                        }
                        for (i = 0; i < tr.length; i++) {
                            td = tr[i].getElementsByTagName("td")[1];

                            tdId = tr[i].getElementsByTagName("td")[2];
                            if (td) {
                                if (Allselecttd.includes(tdId.innerHTML) == false) {
                                    if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                                        tr[i].style.display = "";
                                    }
                                    else {
                                        tr[i].style.display = "none";
                                    }
                                }
                            }
                        }
                    }
                    else {
                        for (i = 0; i < tr.length; i++) {
                            td = tr[i].getElementsByTagName("td")[1];
                            tdId = tr[i].getElementsByTagName("td")[2];
                            if (td) {
                                if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                                    tr[i].style.display = "";
                                }
                                else {
                                    tr[i].style.display = "none";
                                }
                            }
                        }
                    }
                }
            }
            function ChangeEnable(field) {
                if (field == 'cphMain_cbxSelfEval') {
                    if (document.getElementById("<%=cbxSelfEval.ClientID%>").checked == true) {
                        document.getElementById("<%=cbxselGoal.ClientID%>").disabled = false;
                    }
                    else {
                        document.getElementById("<%=cbxselGoal.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxselGoal.ClientID%>").checked = false;

                    }
                }
                else if (field == 'cphMain_cbxROEval') {
                    if (document.getElementById("<%=cbxROEval.ClientID%>").checked == true) {
                        document.getElementById("<%=cbxROGoal.ClientID%>").disabled = false;
                    }
                    else {
                        document.getElementById("<%=cbxROGoal.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxROGoal.ClientID%>").checked = false;

                    }
                }
                else if (field == 'cphMain_cbxDMEval') {
                    if (document.getElementById("<%=cbxDMEval.ClientID%>").checked == true) {
                        document.getElementById("<%=cbxDMGoal.ClientID%>").disabled = false;
                    }
                    else {
                        document.getElementById("<%=cbxDMGoal.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxDMGoal.ClientID%>").checked = false;

                    }
                }
                else if (field == 'cphMain_cbxHREval') {
                    if (document.getElementById("<%=cbxHREval.ClientID%>").checked == true) {
                                document.getElementById("<%=cbxHRGoal.ClientID%>").disabled = false;
                    }
                    else {
                        document.getElementById("<%=cbxHRGoal.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxHRGoal.ClientID%>").checked = false;

                    }
                }
                else if (field == 'cphMain_cbxGMEval') {
                    if (document.getElementById("<%=cbxGMEval.ClientID%>").checked == true) {
                        document.getElementById("<%=cbxGMGoal.ClientID%>").disabled = false;
                    }
                    else {
                        document.getElementById("<%=cbxGMGoal.ClientID%>").disabled = true;
                        document.getElementById("<%=cbxGMGoal.ClientID%>").checked = false;

                    }
                }
            }
    </script>
    <script>
        function NotEnter(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (keyCodes == 13) {
                return false;
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
        function ValidateTerminate() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to issue this performance form?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
            }
            else {
                return false;
            }
            });
        return false;
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

      <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="HiddenEditEmp" runat="server" />
    <asp:HiddenField ID="HiddenEditEval" runat="server" />
    <asp:HiddenField ID="HiddenViewEmp" runat="server" />
    <asp:HiddenField ID="HiddenViewEval" runat="server" />
    <asp:HiddenField ID="HiddeEmp" runat="server" />
    <asp:HiddenField ID="HiddenDsgn" runat="server" />
    <asp:HiddenField ID="HiddenDept" runat="server" />
    <asp:HiddenField ID="HiddenRowCount" runat="server" />
    <asp:HiddenField ID="HiddenUsrId" runat="server" />
    <asp:HiddenField ID="HiddenUsrName" runat="server" />
    <asp:HiddenField ID="HiddenCheckEmp" runat="server" />
    <asp:HiddenField ID="HiddenCheckDept" runat="server" />
    <asp:HiddenField ID="HiddenDeptId" runat="server" />
    <asp:HiddenField ID="HiddenDeptName" runat="server" />
    <asp:HiddenField ID="HiddenCheckDsgn" runat="server" />
    <asp:HiddenField ID="HiddenDsgnId" runat="server" />
    <asp:HiddenField ID="HiddenDsgnName" runat="server" />
    <asp:HiddenField ID="HiddenEvalDsgnChk" runat="server" />
    <asp:HiddenField ID="HiddenEvalDsgnId" runat="server" />
    <asp:HiddenField ID="HiddenEvalDsgnName" runat="server" />
    <asp:HiddenField ID="HiddenEvalDeptCheck" runat="server" />
    <asp:HiddenField ID="HiddenEvalDeptId" runat="server" />
    <asp:HiddenField ID="HiddenEvalDeptName" runat="server" />
    <asp:HiddenField ID="HiddenCheckEval" runat="server" />
    <asp:HiddenField ID="HiddenEvalId" runat="server" />
    <asp:HiddenField ID="HiddenEvalName" runat="server" />
    <asp:HiddenField ID="HiddenIssueId" runat="server" />

                       <div id="main" role="main">
      
        <div class="cont_rght" >
                    <div class="alert alert-danger" id="divWarning" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>
                    <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button> 
        </div>


            <section id="widget-grid" class="">

                <div class="row">
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <div class="" id="wid-id-0">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <%--  <img src="/Images/BigIcons/Job_Delegation.png" style="vertical-align: middle;" />--%>
     <asp:Label ID="lblEntry" runat="server"></asp:Label>
        </div >
        </div >
      
        <div  id="divList"  class="list" runat="server" style="position: fixed; right: 2%; top: 42%; height: 26.5px;z-index: 90;" onclick="return ConfirmMessage()">

           
        </div>

                            <br>

  <div id="DivContent" runat="server" style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: #f6f6f6; float: left">
       
    <div class="auto1">
                           <div id="loading">
        <img src="/Images/Other%20Images/loading.gif" style="width: 12%; margin-left: 46%; margin-top: 4%;" />

    </div>
<div class="cont_rght" style="width:100%">

<div class="sect250">
<div class="row">
<div class="col-xs-12">
<div class="box box-solid">

<%--<div class="box-header">
  <h3 class="box-title" style="text-transform:uppercase;margin-bottom:14px;">Employee conduct master</h3>
</div>--%>
          <div  class="box-body" >
<div class="container-fluid" style="background-color:#f3f3f3;padding-top:40px;padding-bottom:33px;"> 

  
  <div class="form-row">
    <div class="form-group col-md-4 padding5" style="width: 42%;">
   
      <label for="inputEmail4" style="margin-bottom:3px;margin-right: 10%;">
     Reference Number</label>
        <asp:TextBox id="txtReferenceNo" Enabled="false" runat="server"></asp:TextBox>
        <label id="txtRefNo" runat="server" for="inputEmail4"  style="margin-bottom:3px;color: #574d4d;font-size: 15px;display:none">
     </label>  <label id="txtRevNo" runat="server" for="inputEmail4" style="margin-bottom:3px;color: #574d4d;font-size: 15px;display:none;">
     </label>

    </div>

    <div class="form-group col-md-4 padding5" style="margin-left: 8%; width: 46%; visibility:hidden">
      <label for="inputPassword4" style="margin-bottom:3px;">Issue Date<span class="red">*</span></label>
                   <input id="txtdate" tabindex="2" runat="server" type="text" onkeypress="return DisableEnter(event)" style="width: 62%; float: right;"  class="Tabletxt form-control datepicker" placeholder="dd-mm-yyyy" maxlength="50" />
            <script src="/js/datepicker/bootstrap-datepicker.js"></script>
    <link href="/js/datepicker/datepicker3.css" rel="stylesheet" />
       <%-- <style>
         .datepicker.dropdown-menu {
            z-index: 10000;
        }</style> --%>
        <script>

            $noCon('#cphMain_txtIssuedate').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                startDate: new Date(),
                timepicker: false
            });
          
       </script>
        <style>
              .datepicker table tr td.disabled {
                color: #C58E8E;
            }
              .table {
    font-family: OpenSans Semibold;
    text-transform: uppercase;
    font-size: 12px;
    color: #605c5c;
}
        </style>
    </div>
  </div>
 
  <div class="form-row">
    <div class="form-group col-md-4 padding5" style="width: 42%;">
   
      <label for="inputEmail4" style="margin-bottom:3px;">
    Performance Form<span class="red">*</span>
       </label>
         <asp:TextBox ID="txtIssue" TabIndex="1" Height="30px" class="form-control" runat="server" MaxLength="50" onchange="IncrmntConfrmCounter();" onkeypress="return isTag(event);" onblur="return textCounter(cphMain_txtIssue,190)" onkeydown=" return textCounter(cphMain_txtIssue,150)" Style="height: 30px; text-transform: uppercase; float: right; width: 63%;" ></asp:TextBox>

    </div>
    <div class="form-group col-md-4 padding5" style="margin-left: 8%; width: 46%;">
   <%--     <label for="inputPassword4" style="margin-bottom: 3px;">Rev No<span class="red">*</span></label>
        <asp:TextBox ID="txtRevNo" TabIndex="4" Height="30px" Width="100%" class="form-control" runat="server" MaxLength="100" onkeydown="return isNumber(event,'cphMain_txtRevNo');" onchange="IncrmntConfrmCounter();" onkeypress="return isTag(event);" onblur="return textCounter(cphMain_txtRevNo,190)" Style="height: 30px; text-transform: uppercase; float: right; width: 62%; margin-left: -16%;"></asp:TextBox>--%>
    <label for="inputPassword4" style="margin-bottom:3px;">Issue Date<span class="red">*</span></label>
                   <input id="txtIssuedate" tabindex="2" runat="server" type="text" onkeypress="return DisableEnter(event)" style="width: 62%; float: right;"  class="Tabletxt form-control datepicker" placeholder="dd-mm-yyyy" maxlength="50" />
            <script src="/js/datepicker/bootstrap-datepicker.js"></script>
    <link href="/js/datepicker/datepicker3.css" rel="stylesheet" />
       <%-- <style>
         .datepicker.dropdown-menu {
            z-index: 10000;
        }</style> --%>
        <script>

            $noCon('#cphMain_txtIssuedate').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                startDate: new Date(),
                timepicker: false
            });

       </script>
        <style>
              .datepicker table tr td.disabled {
                color: #C58E8E;
            }
              .table {
    font-family: OpenSans Semibold;
    text-transform: uppercase;
    font-size: 12px;
    color: #605c5c;
}
        </style>
          </div>
    
  </div>

   <div class="form-group col-md-4 padding5" style="width: 42%;">
      <label for="inputState" style="margin-bottom:8px;">Recurrent Frequency</label>
               <asp:DropDownList ID="ddlFrequency" TabIndex="3" class="form-control col-xs-12"  runat="server" Style="height: 30px; float: right; width: 63%; margin-bottom: 2%; cursor: pointer;">
                   <asp:ListItem Text="--SELECT FREQUENCY--" Selected="True"></asp:ListItem>  
                    <asp:ListItem Text="Every 1 month" Value="1"></asp:ListItem>   
                    <asp:ListItem Text="Every 2 month" Value="2"></asp:ListItem>
                     <asp:ListItem Text="Every 4 month" Value="3"></asp:ListItem>
                   <asp:ListItem Text="Every 6 month" Value="4"></asp:ListItem>
                     <asp:ListItem Text="Every year" Value="5"></asp:ListItem>

                </asp:DropDownList>
    </div>
  <div class="form-row">
    <div class="form-group col-md-4 padding5" style="width: 46%; margin-left: 8%;">
      <label for="inputState" style="margin-bottom:8px;">Template *</label>
                    <asp:DropDownList ID="ddlTemplte" TabIndex="4" class="form-control col-xs-12"  runat="server" Style="height: 30px;text-transform:uppercase; float: right; width: 62%; margin-bottom: 2%; cursor: pointer;">
                        </asp:DropDownList>
        

    </div>
   <div class="form-group col-md-4 padding5">
    <label for="inputPassword" style="width: 25%; float: left;">Status</label>
    <div class="col-sm-8">
         <div id="divcbxStatus"  runat="server" class="smart-form" style="float: right; width: 68%;">    
      <label class="checkbox" style="float: left;">Active
        <input  type="checkbox" checked="checked" runat="server" tabindex="5" onkeypress="return DisableEnter(event)" id="cbxStatus" />
       <i  ></i> </label>
               </div>
    </div>
    </div>
 <div style="clear:both"></div>   
    </div>
<div style="clear:both"></div>
 <div class="container-fluid" id="group1" style="height:auto;border:1px solid #7c8272;padding:10px;margin:10px;margin-top:20px;">
 
 <div style="width:100%">
   <label for="inputState" style="margin-top:8px;margin-bottom:8px;float: left;bold: 3px;font-weight: bold;"> Add Employee</label></div>
<div style="clear:both"></div>
<hr/>
     <asp:UpdatePanel ID="UpdatePanel1" EnableViewState="true" UpdateMode="Conditional" runat="server">
   <ContentTemplate>
<div class="col-md-5">
   

<div class="col-md-5" style="padding:0;margin-bottom:10px;width: 100%;">
<label id="ddlEDDList"   for="inputState" style="margin-bottom:8px;float: left;margin-left:1%;">Section List</label>
         <asp:DropDownList ID="ddlEDD" TabIndex="6" class="form-control col-xs-12"  runat="server" onchange="DropEDDChange();" Style="height:30px;width:199px;margin-left: 28%;margin-bottom:2%;cursor: pointer;">
                    <asp:ListItem Text="Employee" Value="1" Selected="True"></asp:ListItem>   
                    <asp:ListItem Text="Department" Value="2"></asp:ListItem>
                     <asp:ListItem Text="Designation" Value="3"></asp:ListItem>               
         </asp:DropDownList>
    <script>

        function DropEDDChange() {
            var end = document.getElementById("<%=ddlEDD.ClientID%>").value;
            if (end == "1")
            {
                document.getElementById('SerchEmployee').style.display = "block";
                document.getElementById('SerchDepartment').style.display = "none";
                document.getElementById('SerchDesgination').style.display = "none";
  
                document.getElementById('TableSelectedDept').style.display = "none";
                document.getElementById('TableSelectedDsgn').style.display = "none";
                document.getElementById('TableSelectedEmp').style.display = "block";

                document.getElementById('cphMain_divDsgnList').style.display = "none";
                document.getElementById('cphMain_divDeptList').style.display = "none";
                document.getElementById('cphMain_divEmpList').style.display = "block";
           //     document.getElementById("ddlEDDList").innerHTML = 'Employee List';
                document.getElementById('DivddlEmpDept').style.visibility = "visible";
                document.getElementById('DivddlEmpDsgn').style.visibility = "visible";
              

            }
            if (end == "2") {
   
                document.getElementById('SerchEmployee').style.display = "none";
                document.getElementById('SerchDepartment').style.display = "block";
                document.getElementById('SerchDesgination').style.display = "none";

                document.getElementById('TableSelectedDept').style.display = "block";
                document.getElementById('TableSelectedDsgn').style.display = "none";
                document.getElementById('TableSelectedEmp').style.display = "none";

                document.getElementById('cphMain_divDsgnList').style.display = "none";
                document.getElementById('cphMain_divDeptList').style.display = "block";
                document.getElementById('cphMain_divEmpList').style.display = "none";
                document.getElementById('DivddlEmpDsgn').style.visibility = "hidden";
                document.getElementById('DivddlEmpDept').style.visibility = "hidden";
                //evm-0027
                document.getElementById('SerchEmployee').focus();
                //end

            }
            if (end == "3") {
       
                document.getElementById('SerchEmployee').style.display = "none";
                document.getElementById('SerchDepartment').style.display = "none";
                document.getElementById('SerchDesgination').style.display = "block";

                document.getElementById('TableSelectedDept').style.display = "none";
                document.getElementById('TableSelectedDsgn').style.display = "block";
                document.getElementById('TableSelectedEmp').style.display = "none";

                document.getElementById('cphMain_divDsgnList').style.display = "block";
                document.getElementById('cphMain_divDeptList').style.display = "none";
                document.getElementById('cphMain_divEmpList').style.display = "none";
           //     document.getElementById("ddlEDDList").innerHTML = 'Designation List';
                document.getElementById('DivddlEmpDept').style.visibility = "hidden";
                document.getElementById('DivddlEmpDsgn').style.visibility = "hidden";
                //evm-0027
                document.getElementById('SerchEmployee').focus();
                //end
            }
            // DdlEmpDeptDsgnChange();
        }
        </script>

</div>

<br>   
<div class="col-md-12" style="padding:0;margin-bottom:10px;">
          <div class="form-group row">
    <div class="col-sm-9" style="width:100%">
               <div id="divEmp" runat="server" style="width:100%">
        <%-- <asp:TextBox ID="ddlEmployee"  placeholder="Search Employee." Height="30px" class="form-control" runat="server" MaxLength="100" onchange="IncrmntConfrmCounter();" onkeypress="return isTag(event);" onblur="return textCounter(cphMain_ddlEmployee,190)" onkeydown=" return textCounter(cphMain_ddlEmployee,150)" Style="height: 30px; width: 90%; float: left; margin-left: 2.5%;" ></asp:TextBox>--%>
  <input type="text" id="SerchEmployee" tabindex="9"  onkeydown="return DisableEnter(event);" onkeyup="myEmployee('SerchEmployee')" placeholder="Search Employee" title="Type in a name" style="margin-left: 1%; width: 96%;"/>
  <input type="text" id="SerchDepartment" tabindex="10" onkeydown="return DisableEnter(event);" onkeyup="myEmployee('SerchDepartment')" placeholder="Search Department" title="Type in a name" style="margin-left: 1%; width: 96%;"/>
  <input type="text" id="SerchDesgination" tabindex="11"  onkeydown="return DisableEnter(event);" onkeyup="myEmployee('SerchDesgination')" placeholder="Search Designation" title="Type in a name" style="margin-left: 1%; width: 96%;"/>

          </div>
    </div>

  </div>
 
</div> 

 <div style="clear:both"></div>
<div id="divEmpList" runat="server"  style="height:300px;overflow:auto;line-height:2;border:1px solid #dddddd;padding: 3px; width: 98%;">
    <%-- <table id="TableEmp" class="list-group bg-grey" style=" width:100%;">
                        </table>--%>
</div>
     <div id="divDeptList" runat="server" style="height:300px;overflow:auto;line-height:2;border:1px solid #dddddd;padding: 3px; width: 98%;">
     <table id="TableDept" class="list-group bg-grey" style=" width:100%;">
                        </table></div>
              <div id="divDsgnList" runat="server" style="height:300px;overflow:auto;line-height:2;border:1px solid #dddddd;padding: 3px; width: 98%;">
     <table id="TableDsgn" class="list-group bg-grey" style=" width:100%;">
                        </table>
</div>


<%--<div class="col-sm-12" style="padding: 0px; margin-left: 93%; width: 17%; margin-top: -184px;">
      <button id="btnEmpAdd"  type="submit" tabindex="10" runat="server" class="btn btn-primary" style="float: right; width: 91%;" onclick="return CheckedEmployee();"><i class="fa fa-plus" style="margin-right:10px;"></i>Add</button>
    </div>--%>
</div>

<div class="col-sm-2">
    <div class="col-sm-12" style="padding: 0px; width: 63%; margin-top: 223px; cursor:pointer;margin-left: 10%;">
     <button id="btnEmpAdd" runat="server" type="submit" tabindex="12" class="btn btn-primary" style="float: right; width: 91%;" onclick="return validateProcess();"><i class="fa fa-plus" style="margin-right:9%;" ></i>Add</button>
    </div>
   <%-- <div class="col-sm-12" style="width: 14%; padding: 0px; margin-top: 166px; margin-left: -11%;">--%>
     <button id="btnrevmoveEmp" runat="server" type="submit" tabindex="13" class="btn btn-primary" style="float: left; margin-top: 12%;margin-left: 15%;" onclick="return RemoveEmployee();"><i class="fa fa-remove" style="margin-right:9%;" ></i>Remove</button>
<%--    </div>--%>
</div>

<div class="col-md-5" style="margin-top:-2px;">
        <div id="DivddlEmpDept" class="col-md-5" style="padding:0;margin-bottom:9px;width: 100%;">
<label id="Label1"   for="inputState" style="margin-bottom:8px;float: left;margin-left:1%;">Department</label>
         <asp:DropDownList ID="ddlEmpDept" TabIndex="7" class="form-control col-xs-12"  runat="server" Style="height:30px;width:231px;margin-left: 88px;margin-bottom:2%;cursor: pointer;" AutoPostBack="true" OnSelectedIndexChanged="ddlEmpDept_SelectedIndexChanged">
         </asp:DropDownList>
        </div>
       <div id="DivddlEmpDsgn" class="col-md-5" style="padding:0;margin-bottom:9px;width: 100%;">
<label id="Label2"   for="inputState" style="margin-bottom:8px;float: left;margin-left:1%;">Designation</label>
         <asp:DropDownList ID="ddlEmpDsgn" TabIndex="8" class="form-control col-xs-12"  runat="server"  Style="height:30px;width:231px;margin-left: 88px;margin-bottom:2%;cursor: pointer;" AutoPostBack="true" OnSelectedIndexChanged="ddlEmpDept_SelectedIndexChanged">
         </asp:DropDownList>
        </div>
<%--     <button id="btnEmpSearch" runat="server" type="submit" tabindex="7" class="btn btn-primary" style="float: right; margin-bottom: 4%;margin-right: 1%;" onclick="return SearchEmp()" ><i class="fa fa-search" style="margin-right:11%;" ></i>Search</button>
  <asp:Button ID="EmpSearch" TabIndex="7" runat="server"  class="btn btn-primary" style="display:none" OnClick="EmpSearch_Click" />--%>
     </div> 
           </ContentTemplate>        
 </asp:UpdatePanel>
<div id="DivSelectedEmp" style="height:300px;overflow:auto;line-height:2;border:1px solid #dddddd;padding: 3px;width: 402px; float: right;">
     <table id="TableSelectedEmp" class="list-group bg-grey" style=" width:100%;">
                        </table>

<%--</div>--%>
    <%--<div id="DivSelectedDsgn" style="height:300px;overflow:auto;line-height:2;border:1px solid #dddddd;padding: 3px;width: 85%; float: right;">--%>
     <table id="TableSelectedDsgn" class="list-group bg-grey" style=" width:100%;">
                        </table><%--</div>--%>
        <%--    <div id="DivSelectedDept" style="height:300px;overflow:auto;line-height:2;border:1px solid #dddddd;padding: 3px;width: 85%; float: right;">--%>
     <table id="TableSelectedDept" class="list-group bg-grey" style=" width:100%;">
                        </table>

<%--</div>--%></div> 
   

<div style="clear:both"></div>


   
<%-- <div class="container-fluid" id="group2" style="height:auto;border:1px solid #7c8272;padding:10px;margin:10px;margin-top:20px;">--%>

</div>

</div>
     <div class="container-fluid" id="group2" style=" height:auto;border:1px solid #7c8272;padding:10px;margin:10px;margin-top:20px;">
 <div style="width:100%">
   <label for="inputState" style="margin-top:8px;margin-bottom:25px;float: left;bold: 3px;font-weight: bold;"> Add Evaluator</label></div>
 <div class="col-lg-12" style="padding:1px;">

    <div class="col-md-6">
<div class="table-responsive">
<table class="table table-bordered" style="width:100%;">
  <thead style="background-color: rgb(21, 62, 81); color: rgb(6, 69, 90);">
    <tr>
      <th scope="col" >Evaluator</th>
      <th scope="col" style="text-align:center;">Evaluate</th>
      <th scope="col" style="text-align:center;">Set goals</th>
      
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">Self</th>
      <td>   <div id="divcbxSelfEval"  runat="server" class="smart-form" style="float: left; width: 66%;">    
      <label class="checkbox" style="float: right;">
        <input id="cbxSelfEval" tabindex="13" type="checkbox" runat="server" onkeypress="return DisableEnter(event)"  onchange="ChangeEnable('cphMain_cbxSelfEval');" />
       <i  ></i> </label>
               </div></td>
      <td><div id="divcbxselGoal"  runat="server" class="smart-form" style="float: left; width: 66%;">    
      <label class="checkbox" style="float: right;">
        <input id="cbxselGoal"  tabindex="14" type="checkbox" runat="server" onkeypress="return DisableEnter(event)" />
       <i  ></i> </label>
               </div></td>
     
    </tr>
    <tr>
      <th scope="row">Reporting officer</th>
      <td> <div id="divcbxROEval"  runat="server" class="smart-form" style="float: left; width: 66%;">    
      <label class="checkbox" style="float: right;">
        <input id="cbxROEval" tabindex="15" type="checkbox" runat="server" onchange="ChangeEnable('cphMain_cbxROEval');" onkeypress="return DisableEnter(event)"   />
       <i  ></i> </label>
               </div></td>
      <td><div id="divcbxROGoal"  runat="server" class="smart-form" style="float: left; width: 66%;">    
      <label class="checkbox" style="float: right;">
        <input id="cbxROGoal" tabindex="16" type="checkbox" runat="server" onkeypress="return DisableEnter(event)" />
       <i  ></i> </label>
               </div></td>
     
    </tr>
    <tr>
      <th scope="row">Division Manager</th>
      <td><div id="divcbxDMEval"  runat="server" class="smart-form" style="float: left; width: 66%;">    
      <label class="checkbox" style="float: right;">
        <input id="cbxDMEval" tabindex="17" type="checkbox" runat="server" onchange="ChangeEnable('cphMain_cbxDMEval');" onkeypress="return DisableEnter(event)"  />
       <i  ></i> </label>
               </div></td>
      <td><div id="divcbxDMGoal"  runat="server" class="smart-form" style="float: left; width: 66%;">    
      <label class="checkbox" style="float: right;">
        <input id="cbxDMGoal" tabindex="18"  type="checkbox" runat="server" onkeypress="return DisableEnter(event)" />
       <i  ></i> </label>
               </div></td>
     
    </tr><tr>
      <th scope="row">HR</th>
      <td><div id="divcbxHREval"  runat="server" class="smart-form" style="float: left; width: 66%;">    
      <label class="checkbox" style="float: right;">
        <input  type="checkbox" runat="server" onkeypress="return DisableEnter(event)" id="cbxHREval" tabindex="19" onchange="ChangeEnable('cphMain_cbxHREval');" />
       <i  ></i> </label>
               </div></td>
      <td><div id="divcbxHRGoal"  runat="server" class="smart-form" style="float: left; width: 66%;">    
      <label class="checkbox" style="float: right;">
        <input  type="checkbox" runat="server" onkeypress="return DisableEnter(event)" id="cbxHRGoal" tabindex="20" />
       <i  ></i> </label>
               </div></td>
      
    </tr>
    <tr>
      <th scope="row"> General Manager</th>
      <td><div id="divcbxGMEval"  runat="server" class="smart-form" style="float: left; width: 66%;">    
      <label class="checkbox" style="float: right;">
        <input  type="checkbox" runat="server" onkeypress="return DisableEnter(event)" id="cbxGMEval" tabindex="21" onchange="ChangeEnable('cphMain_cbxGMEval');"/>
       <i  ></i> </label>
               </div></td>
      <td><div id="divcbxGMGoal"  runat="server" class="smart-form" style="float: left; width: 66%;">    
      <label class="checkbox" style="float: right;">
        <input  type="checkbox" runat="server" onkeypress="return DisableEnter(event)" id="cbxGMGoal" tabindex="22"/>
       <i  ></i> </label>
               </div></td>
    </tr>

    
  </tbody>
</table>
 <div>
</div>
</div>
</div>
   </div>
     <div style="width:100%">
   <label for="inputState" style="margin-bottom:25px;float: left;bold: 2px;font-weight: bold;">Additional Evaluators</label></div>

<div class="col-lg-12" style="padding:1px;">

</div>

<hr>
     <asp:UpdatePanel ID="UpdatePanel2" EnableViewState="true" UpdateMode="Conditional" runat="server">
   <ContentTemplate>

     
<div class="col-md-5">

<div class="col-md-5" style="padding:0;margin-bottom:10px;width:100%">
<label id="ddlEvalList" for="inputState" style="margin-bottom:8px;float: left;margin-left: 1%;">Section List</label>
              <asp:DropDownList ID="ddlEvaluators" class="form-control col-xs-12"  runat="server" TabIndex="23" onchange="DropChange();" Style="height:30px;width:199px;margin-left: 28%;margin-bottom:2%;cursor: pointer;">
                    <asp:ListItem Text="Employee" Value="1" Selected="True"></asp:ListItem>   
                    <asp:ListItem Text="Department" Value="2"></asp:ListItem>
                     <asp:ListItem Text="Designation" Value="3"></asp:ListItem>               
         </asp:DropDownList>
        <script>

            function DropChange() {
                var end = document.getElementById("<%=ddlEvaluators.ClientID%>").value;
                if (end == "1") {
                    document.getElementById('cphMain_DivEvaluator').style.display = "block";
                    document.getElementById('cphMain_divevalDept').style.display = "none";
                    document.getElementById('cphMain_divEvalDsgn').style.display = "none";
                    document.getElementById('EvalDept').style.display = "none";
                    document.getElementById('EvalDsgn').style.display = "none";
                    document.getElementById('EvalEmp').style.display = "block";

                    document.getElementById('TableselEvalDept').style.display = "none";
                    document.getElementById('TableselEvalDsgn').style.display = "none";
                    document.getElementById('TableSelectEval').style.display = "block";
                    document.getElementById('DivddlEvalDept').style.visibility = "visible";
                    document.getElementById('DivddlEvalDsgn').style.visibility = "visible";
                }
                if (end == "2") {
                    document.getElementById('cphMain_DivEvaluator').style.display = "none";
                    document.getElementById('cphMain_divevalDept').style.display = "block";
                    document.getElementById('cphMain_divEvalDsgn').style.display = "none";
                    document.getElementById('EvalDept').style.display = "block";
                    document.getElementById('EvalDsgn').style.display = "none";
                    document.getElementById('EvalEmp').style.display = "none";

                    document.getElementById('TableselEvalDept').style.display = "block";
                    document.getElementById('TableselEvalDsgn').style.display = "none";
                    document.getElementById('TableSelectEval').style.display = "none";
                    document.getElementById('DivddlEvalDept').style.visibility = "hidden";
                    document.getElementById('DivddlEvalDsgn').style.visibility = "hidden";


                }
                if (end == "3") {
                    document.getElementById('EvalDept').style.display = "none";
                    document.getElementById('EvalDsgn').style.display = "block";
                    document.getElementById('EvalEmp').style.display = "none";

                    document.getElementById('cphMain_DivEvaluator').style.display = "none";
                    document.getElementById('cphMain_divevalDept').style.display = "none";
                    document.getElementById('cphMain_divEvalDsgn').style.display = "block";


                    document.getElementById('TableselEvalDept').style.display = "none";
                    document.getElementById('TableselEvalDsgn').style.display = "block";
                    document.getElementById('TableSelectEval').style.display = "none";
                    document.getElementById('DivddlEvalDept').style.visibility = "hidden";
                    document.getElementById('DivddlEvalDsgn').style.visibility = "hidden";
                }
                // DdlEmpDeptDsgnChange();
            }

            function searchChange()
            {
                var myEmp = document.getElementById("<%=ddlEDD.ClientID%>").value;
                var myEval = document.getElementById("<%=ddlEvaluators.ClientID%>").value;
                alert(myEmp);
                if (myEmp == "1") {
                
                    document.getElementById('SerchEmployee').style.display = "block";
                    document.getElementById('SerchDepartment').style.display = "none";
                    document.getElementById('SerchDesgination').style.display = "none";
                    document.getElementById('cphMain_divDsgnList').style.display = "none";
                    document.getElementById('cphMain_divDeptList').style.display = "none";
                    document.getElementById('cphMain_divEmpList').style.display = "block";
                    //evm-0027
                    document.getElementById('cphMain_ddlEmpDept').focus();
                    //end
                }
                else if (myEmp == "2") {
                   
                    document.getElementById('SerchEmployee').style.display = "none";
                    document.getElementById('SerchDepartment').style.display = "block";
                    document.getElementById('SerchDesgination').style.display = "none";
                    document.getElementById('cphMain_divDsgnList').style.display = "none";
                    document.getElementById('cphMain_divDeptList').style.display = "block";
                    document.getElementById('cphMain_divEmpList').style.display = "none";
                }
                else if (myEmp == "3") {
                   
                    document.getElementById('SerchEmployee').style.display = "none";
                    document.getElementById('SerchDepartment').style.display = "none";
                    document.getElementById('SerchDesgination').style.display = "block";
                    document.getElementById('cphMain_divDsgnList').style.display = "block";
                    document.getElementById('cphMain_divDeptList').style.display = "none";
                    document.getElementById('cphMain_divEmpList').style.display = "none";
                }
                if (myEval == "1") {
                    document.getElementById('EvalDept').style.display = "none";
                    document.getElementById('EvalDsgn').style.display = "none";
                    document.getElementById('EvalEmp').style.display = "block";
                    document.getElementById('cphMain_DivEvaluator').style.display = "block";
                    document.getElementById('cphMain_divevalDept').style.display = "none";
                    document.getElementById('cphMain_divEvalDsgn').style.display = "none";
                    //evm-0027
                    document.getElementById('cphMain_ddlEmpDsgn').focus();
                    //end
                }
                else if (myEval == "2") {
                    document.getElementById('EvalDept').style.display = "block";
                    document.getElementById('EvalDsgn').style.display = "none";
                    document.getElementById('EvalEmp').style.display = "none";
                    document.getElementById('cphMain_DivEvaluator').style.display = "none";
                    document.getElementById('cphMain_divevalDept').style.display = "block";
                    document.getElementById('cphMain_divEvalDsgn').style.display = "none";
                }
               else if (myEval == "3") {
                    document.getElementById('EvalDept').style.display = "none";
                    document.getElementById('EvalDsgn').style.display = "block";
                    document.getElementById('EvalEmp').style.display = "none";
                    document.getElementById('cphMain_DivEvaluator').style.display = "none";
                    document.getElementById('cphMain_divevalDept').style.display = "none";
                    document.getElementById('cphMain_divEvalDsgn').style.display = "block";
               }

            }
        </script>
</div>
<br>   
<div class="col-md-12" style="padding:0;margin-bottom:68px;">
          <div class="form-group row">
    <div class="col-sm-9" style="width:100%">
  <input type="text" id="EvalEmp" tabindex="24" onkeydown="return DisableEnter(event);" onkeyup="myEvaluator('EvalEmp')" placeholder="Search Employee" title="Type in a name" style="margin-left: 1%; width: 97%;">
  <input type="text" id="EvalDept" tabindex="24" onkeydown="return DisableEnter(event);" onkeyup="myEvaluator('EvalDept')" placeholder="Search Department" title="Type in a name" style="margin-left: 1%; width: 97%;">
  <input type="text" id="EvalDsgn" tabindex="24" onkeydown="return DisableEnter(event);" onkeyup="myEvaluator('EvalDsgn')" placeholder="Search Designation" title="Type in a name" style="margin-left: 1%; width: 97%;">

    </div>
  </div>
</div> 


    <div id="DivEvaluator" runat="server" style="height: 300px; overflow: auto; line-height: 2; border: 1px solid rgb(221, 221, 221); padding: 3px; width: 98%; display: block;">
  
</div>
         <div id="divevalDept" runat="server" style="height: 300px; overflow: auto; line-height: 2; border: 1px solid rgb(221, 221, 221); padding: 3px; width: 98%; display: block;">
     <table id="TableEvalDept" class="list-group bg-grey" style=" width:100%;">
                        </table></div>
              <div id="divEvalDsgn" runat="server" style="height: 300px; overflow: auto; line-height: 2; border: 1px solid rgb(221, 221, 221); padding: 3px; width: 98%; display: block;">
     <table id="TableEvalDsgn" class="list-group bg-grey" style=" width:100%;">
                        </table>
</div>
<div class="col-sm-12" style="padding: 0px; margin-left: 93%; width: 17%; margin-top: -184px; cursor:pointer; z-index: 31;">
    </div>
</div>

       <div class="col-sm-2">
    <div class="col-sm-12" style="padding: 0px; width: 63%; margin-top: 223px; cursor:pointer;margin-left: 10%;">
        <button id="BtnAddEval" type="submit" tabindex="26" runat="server" class="btn btn-primary" style="float: right; width: 96%;" onclick="return validateEvaluator();"><i class="fa fa-plus" style="margin-right:8px;"></i>Add</button>
     <button id="btnRemoveEval" tabindex="28" runat="server" type="submit"  class="btn btn-primary" style="float: left;margin-left: 4%;margin-top: 21%;width:96%;" onclick="return RemoveEvaluator();"><i class="fa fa-remove" style="margin-right:9%;" ></i>Remove</button>

    </div>
   <%-- <div class="col-sm-12" style="width: 14%; padding: 0px; margin-top: 166px; margin-left: -11%;">--%>
<%--    </div>--%>
</div>
<div class="col-md-5" style="margin-top:5px;">
            <div id="DivddlEvalDept" class="col-md-5" style="padding:0;margin-bottom:9px;width: 100%;">
<label id="Label3"   for="inputState" style="margin-bottom:8px;float: left;margin-left:1%;">Department</label>
         <asp:DropDownList ID="ddlEvalDept" TabIndex="23" class="form-control col-xs-12"  runat="server" Style="height:30px;width:231px;margin-left: 88px;margin-bottom:2%;cursor: pointer;"  AutoPostBack="true" OnSelectedIndexChanged="ddlEvalDept_SelectedIndexChanged">
         </asp:DropDownList>
        </div>
       <div id="DivddlEvalDsgn" class="col-md-5" style="padding:0;margin-bottom:9px;width: 100%;">
<label id="Label4"   for="inputState" style="margin-bottom:8px;float: left;margin-left:1%;">Designation</label>
         <asp:DropDownList ID="ddlEvalDsgn" TabIndex="23" class="form-control col-xs-12"  runat="server"  Style="height:30px;width:231px;margin-left: 88px;margin-bottom:2%;cursor: pointer;"  AutoPostBack="true" OnSelectedIndexChanged="ddlEvalDept_SelectedIndexChanged" >
         </asp:DropDownList>
        </div>
<%--     <button id="Button1" runat="server" type="submit" tabindex="7" class="btn btn-primary" style="float: right; margin-bottom: 4%;margin-right: 1%;" onclick="return SearchEmp()" ><i class="fa fa-search" style="margin-right:11%;" ></i>Search</button>
  <asp:Button ID="Button2" TabIndex="7" runat="server"  class="btn btn-primary" style="display:none" OnClick="EmpSearch_Click" />--%>

    <div class="col-md-12" style="padding:0;margin-bottom:34px;">
    <div id="divcbxEvalGoal"  runat="server" class="smart-form" style="float: left; width: 99%;">    
      <label class="checkbox" style="float: left;">Set Evaluators Goal
        <input  type="checkbox" runat="server"  onkeypress="return DisableEnter(event)" id="cbxEvalGoal" tabindex="26"/>
       <i  ></i> </label>
               </div>
</div> 


<%--</div>--%>

     <asp:Button ID="BtnDemoConfirm" runat="server"  class="btn btn-primary btn-grey  btn-width" Text="Update" style="border-radius:0px;display:none" OnClick="btnUpdate_Click"/>
    <script>
        function ConfirmMsg() {
            if (ServiceValidate()) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to confirm this performance form?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        document.getElementById("<%=BtnDemoConfirm.ClientID%>").click();
                }

                else {
                    return false;
                }
                });
        }
        return false;

    }
    </script>
    </div> 
       </ContentTemplate>
         </asp:UpdatePanel>
<div id="DivSelectEval" style="height:300px;overflow:auto;line-height:2;border:1px solid #dddddd;padding: 3px;width: 395px; float: right;">
     <table id="TableSelectEval" class="list-group bg-grey" style=" width:100%;">
                        </table>
            <%-- <div id="divselEvalDept"  style="height:300px;overflow:auto;float: right;line-height:2;border:1px solid #dddddd;padding: 3px; width: 85%;">--%>
     <table id="TableselEvalDept" class="list-group bg-grey" style=" width:100%;">
                        </table>

      <%--       </div>--%>
             <%-- <div id="divselEvalDsgn" style="height:300px;overflow:auto;line-height:2;float: right;border:1px solid #dddddd;padding: 3px; width: 85%;">--%>
     <table id="TableselEvalDsgn" class="list-group bg-grey" style=" width:100%;">
                        </table>
    </div>











</div>
</div>

</div>
</div>

</div>
</div>

       <div class="col-md-12" style="padding:9px;">
<div style="float:right;">

  <asp:Button ID="btnSave" TabIndex="30" runat="server"  class="btn btn-primary btn-grey  btn-width" Text="Save" style="border-radius:0px;" OnClientClick="return ServiceValidate();" OnClick="btnSave_Click" />
  <asp:Button ID="btnUpdate" TabIndex="31" runat="server"  class="btn btn-primary btn-grey  btn-width" Text="Update" style="border-radius:0px;" OnClientClick="return ServiceValidate();" OnClick="btnUpdate_Click"/>
  <asp:Button ID="btnConfirm" TabIndex="32" runat="server"  class="btn btn-primary btn-grey  btn-width" Text="Confirm & Issue" style="border-radius:0px;" OnClientClick="return ConfirmMsg();" />
  <asp:Button ID="btnClear" TabIndex="33" runat="server"  class="btn btn-primary btn-grey  btn-width" Text="Clear" style="border-radius:0px;" OnClientClick="return AlertClearAll();" />
  <asp:Button ID="btnCancel" TabIndex="34" runat="server"  class="btn btn-primary btn-grey  btn-width" Text="Cancel" style="border-radius:0px;" OnClientClick="return ConfirmMessage();" />

</div>
</div>   

          
    </div>

  </div>  </article>  </div>  </section>  </div>  </div>



    </div>

    <asp:HiddenField ID="HiddenConfirm" runat="server" />

    <asp:HiddenField ID="HiddenDelEmpId" runat="server" />
    <asp:HiddenField ID="HiddenDelDsgnId" runat="server" />
    <asp:HiddenField ID="HiddenDelDeptId" runat="server" />
        <asp:HiddenField ID="HiddenDelEvalEmpId" runat="server" />
    <asp:HiddenField ID="HiddenDelEvalDsgnId" runat="server" />
    <asp:HiddenField ID="HiddenDelEvalDeptId" runat="server" />
</asp:Content>

