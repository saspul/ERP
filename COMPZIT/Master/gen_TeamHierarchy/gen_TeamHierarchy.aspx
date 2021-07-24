<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_TeamHierarchy.aspx.cs" Inherits="Master_gen_TeamHierarchy_gen_TeamHierarchy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">


    <script src="/JavaScript/jquery-1.8.3.min.js"></script>



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
        //start-0006
        var confirmbox = 0;
        
        function IncrmntConfrmCounter() {          
            confirmbox++;
            
        }
        function ConfirmMessage() {            
            if (confirmbox > 0) {

                if (confirm("Are you sure you want to leave this page?")) {                    
                    window.location.href = "gen_TeamHierarchyList.aspx";
                }
                else {                  
                    return false;
                }
            }
            else {
                window.location.href = "gen_TeamHierarchyList.aspx";

            }
        }
        //stop-0006
    </script>
    <style>

        .opClass {
    opacity:0.4;
   /*filter:alpha(opacity=40);*/  /* For IE8 and earlier */
}

        /* Styles the thumbnail */
        a.lightbox img {
            height: 100%;
            border: 1px solid white;
            box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
            margin: 4px 12px 4px 0px;
        }

        /* Styles the lightbox, removes it from sight and adds the fade-in transition */
        .lightbox-target {
            position: fixed;
            top: -100%;
            width: 100%;
            background: rgba(0, 0, 0, 0.7);
            width: 60%;
            opacity: 0;
            -webkit-transition: opacity .5s ease-in-out;
            -moz-transition: opacity .5s ease-in-out;
            -o-transition: opacity .5s ease-in-out;
            transition: opacity .5s ease-in-out;
            overflow: hidden;
        }

            /* Styles the lightbox image, centers it vertically and horizontally, adds the zoom-in transition and makes it responsive using a combination of margin and absolute positioning */
            .lightbox-target img {
                margin: auto;
                position: absolute;
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                max-height: 0%;
                max-width: 0%;
                border: 3px solid white;
                box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
                box-sizing: border-box;
                -webkit-transition: .5s ease-in-out;
                -moz-transition: .5s ease-in-out;
                -o-transition: .5s ease-in-out;
                transition: .5s ease-in-out;
            }

        /* Styles the close link, adds the slide down transition */
        a.lightbox-close {
            display: block;
            width: 50px;
            height: 50px;
            box-sizing: border-box;
            background: white;
            color: black;
            text-decoration: none;
            position: absolute;
            top: -80px;
            right: 0;
            -webkit-transition: .5s ease-in-out;
            -moz-transition: .5s ease-in-out;
            -o-transition: .5s ease-in-out;
            transition: .5s ease-in-out;
        }

            /* Provides part of the "X" to eliminate an image from the close link */
            a.lightbox-close:before {
                content: "";
                display: block;
                height: 30px;
                width: 1px;
                background: black;
                position: absolute;
                left: 26px;
                top: 10px;
                -webkit-transform: rotate(45deg);
                -moz-transform: rotate(45deg);
                -o-transform: rotate(45deg);
                transform: rotate(45deg);
            }

            /* Provides part of the "X" to eliminate an image from the close link */
            a.lightbox-close:after {
                content: "";
                display: block;
                height: 30px;
                width: 1px;
                background: black;
                position: absolute;
                left: 26px;
                top: 10px;
                -webkit-transform: rotate(-45deg);
                -moz-transform: rotate(-45deg);
                -o-transform: rotate(-45deg);
                transform: rotate(-45deg);
            }

        /* Uses the :target pseudo-class to perform the animations upon clicking the .lightbox-target anchor */
        .lightbox-target:target {
            opacity: 1;
            top: 0;
            bottom: 0;
            right: 18%;
            z-index: 33;
        }

            .lightbox-target:target img {
                max-height: 100%;
                max-width: 80%;
            }

            .lightbox-target:target a.lightbox-close {
                top: 0px;
            }
    </style>



    <style>
        .fillform {
            width: 100%;
        }

        .subform {
            float: left;
            margin-left: 27.4%;
        }

        /**/

       

        /*#TableEmployeeList {
        }*/

        #TableaddedRows {
        }

        .buttonSearchMember {
            font-family: OpenSans Semibold;
            color: #FFFFFF;
            font-size: 14px;
            padding: 3px 10px 3px 10px;
            background: #9ba48b;
            cursor: pointer;
        }

        .lblTeamDtl {
            font-family: Calibri;
            font-size: 20px;
            float: none;
            text-align: left;
            color: #909c7b;
            padding: 0;
            margin: 0 0 6px;
            line-height: 1;
            font-weight: normal;
        }
        tr.border_bottom td {
  border-bottom:1pt dotted #a9b496;

}
    </style>
    
     <style>

        .ui-widget-content {
            background: #ffffff;
            color: #333333;
        }
        .ui-widget {
            font-family: Arial,Helvetica,sans-serif;
            font-size: 1em;
        }
        .ui-menu {
            list-style: none;
            padding: 0;
            padding-right: 0px;
            margin: 0;
            display: block;
            outline: 0;
        }
            .ui-menu .ui-menu {
                position: absolute;
            }
        .ui-autocomplete {
            position: absolute;
            top: 0;
            left: 0;
            cursor: default;
            max-height: 200px;
            overflow-y: auto;
            /* prevent horizontal scrollbar */
            overflow-x: hidden;
        }
        .ui-front {
            z-index: 100;
        }
        .ui-menu .ui-menu-item {
            margin: 0;
            cursor: pointer;
        }
        .ui-menu .ui-menu-item-wrapper {
            position: relative;
            padding: 3px 1em 3px .4em;
            text-align:left!important;
        }
        .ui-menu .ui-menu-divider {
            margin: 5px 0;
            height: 0;
            font-size: 0;
            line-height: 0;
            border-width: 1px 0 0 0;
        }
        .ui-menu .ui-state-focus,
        .ui-menu .ui-state-active {
            margin: -1px;
        }
        .ui-state-active,
        .ui-widget-content .ui-state-active,
        .ui-widget-header .ui-state-active:hover {
            border: 1px solid #003eff;
            background: #007fff;
            font-weight: normal;
            color: #ffffff;
        }
        .ui-selectmenu-menu .ui-menu {
            overflow: auto;
            overflow-x: hidden;
            padding-bottom: 1px;
        }
            .ui-selectmenu-menu .ui-menu .ui-selectmenu-optgroup {
                font-size: 1em;
                font-weight: bold;
                line-height: 1.5;
                padding: 2px 0.4em;
                margin: 0.5em 0 0 0;
                height: auto;
                border: 0;
            }
        .ui-menu-icons .ui-menu-item-wrapper {
            padding-left: 2em;
        }
        .ui-menu-icons {
            position: relative;
        }
        .ui-menu .ui-icon {
            position: absolute;
            top: 0;
            bottom: 0;
            left: .2em;
            margin: auto 0;
        }
        .ui-menu .ui-menu-icon {
            left: auto;
            right: 0;
        }

    </style>


      <style>


          .dt-toolbar-footer {
              display:none;
          }
          .dataTables_filter {
            display:none;  
          }



       .table td + td+td+td,
.table th + th+th+th
{
    text-align:center;
}
          #datatable_fixed_column_wrapper {
            border: 1px solid #065757;
        }
        .dt-toolbar  {
    border-bottom: 1px solid  #c8b6b6;
    background: #f4f6f0;
}
.dt-toolbar-footer  {
    border-top: 1px solid  #c8b6b6;
    background: #f4f6f0;
}
.table > thead > tr > th {
    background: #eee;
    color:#fff;
}
.table-bordered, .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
    border-bottom: 1px solid #c8b6b6;
    border-right: 1px solid  #c8b6b6;
}
.table {
    font-size: 13px;
}
.table-striped > tbody > tr:nth-of-type(2n+1) {
    background-color: #eaeaea;
}
        table.dataTable thead .sorting {
              background-color: #79895f;
        }
        table.dataTable thead .sorting_asc, table.dataTable thead .sorting_desc {
    background-color: #92a276;
}
        .table > thead > tr > th {
            padding: 8px 10px;
        }
        .table > tbody > tr > td {
            padding: 5px 10px;
            border-bottom: none;
        }

        .table {
            color: #3e3737;
            font-weight: bolder;
        }


 
      .cont_rght {
            width: 98%;
        }  


div.dataTables_wrapper div.dataTables_processing {   
   top: 600%;
}


table.dataTable thead > tr > th.sorting_disabled {   
    background-color: #79895f;
}


    </style>


    <%--<script src="/JavaScript/jquery-1.8.3.min.js"></script>--%>

     <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
     

     <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    

     <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />


    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script> 
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>     
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>


      <script src="/js/libs/jquery-ui/1.8/jquery-ui.min.js"></script>     
     <link href="/js/libs/jquery-ui/1.8/jquery-ui.css" rel="stylesheet" />


    <script type="text/javascript">


        var $noC = jQuery.noConflict();
       
        $noC(function () {
      
        $noC("#cphMain_txtTeamLead").autocomplete({
            source: function (request, response) {
               

                var objSearchMstr = {};
                var CorpId = '<%= Session["CORPOFFICEID"] %>';
                var OrgId = '<%= Session["ORGID"] %>';
                var prefix = request.term;
                if (CorpId == "" || OrgId == "") {
                    window.location.href = "Default.aspx";
                }
                objSearchMstr.prefix = request.term;
                objSearchMstr.CorpId = CorpId;
                objSearchMstr.OrgId = OrgId;

                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_TeamHierarchy.aspx/GetTeamLlead",                    
                    data: JSON.stringify(objSearchMstr),
                    dataType: "json",
                    
                    success: function (data) {
                        response($noC.map(data.d, function (item) {
                            return {
                                label: item.split('—')[0].trim(),
                                val: item.split('—')[1].trim(),                                                               
                            }
                        }))
                    },
                    error: function (response) {

                    },
                    failure: function (response) {
                        alert("fail");
                    }
                });
            },
            select: function (e, i) {
                var srtSearchItemMstr = i.item.label;
                var srtSearchItemId = i.item.val;
                document.getElementById("<%=hiddenFieldTeamLeadEmp_Id.ClientID%>").value = srtSearchItemId                    
               // LoadTeamDetailsList();
            },

            change: function() {

            },

            minLength: 1
        });
        });



        function LoadTeamDetailsList() {
           


            var OrgId = '<%= Session["ORGID"] %>';
            var CorpId = '<%= Session["CORPOFFICEID"] %>';

            if (OrgId == "" || CorpId == "") {
                window.location = "Default.aspx";
            }

            var TeamLeadEmp_Id = document.getElementById("<%=hiddenFieldTeamLeadEmp_Id.ClientID%>").value;
            var TeamId = document.getElementById("<%=hiddenFieldTeamId.ClientID%>").value;


            if (TeamLeadEmp_Id == "") {
                document.getElementById("TeamDetails").style.display = "none";
            }
            else {
                document.getElementById("TeamDetails").style.display = "block";
            }


            var DivisionId = "0";

            if (document.getElementById("<%=ddlDivision.ClientID%>").value != "--SELECT DIVISION--") {
                var e = document.getElementById("<%=ddlDivision.ClientID%>");
                DivisionId = e.options[e.selectedIndex].value;
            }
                       


            var responsiveHelper_datatable_fixed_column = undefined;


            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };

            /* COLUMN FILTER  */

            var $NoConfi = jQuery.noConflict();
            var $NoConfi3 = jQuery.noConflict();

            var otable = $noC('#datatable_fixed_column').DataTable({
                "pageLength": 100000,
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                'bProcessing': true,
                'bServerSide': true,
                'sAjaxSource': 'data.ashx',
               // 'bPaginate': false,
                "bDestroy": true,
                "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6 hidden-xs'f><'col-sm-6 col-xs-12 hidden-xs'<'toolbar'>>r>" +
                        "t" +
                        "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
                "autoWidth": true,
                "oLanguage": {
                    "sSearch": '<span class="input-group-addon"><i  class="glyphicon glyphicon-search"></i></span>'

                },
                "preDrawCallback": function () {
                    // Initialize the responsive datatables helper once.
                    if (!responsiveHelper_datatable_fixed_column) {
                        responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($noC('#datatable_fixed_column'), breakpointDefinition);
                    }
                },
                "rowCallback": function (nRow) {
                    responsiveHelper_datatable_fixed_column.createExpandIcon(nRow);
                },
                "drawCallback": function (oSettings) {
                    responsiveHelper_datatable_fixed_column.respond();
                    SearchCheckedEmployeeMembers();
                },
                "fnServerParams": function (aoData) {
                    aoData.push({ "name": "ORG_ID", "value": OrgId });
                    aoData.push({ "name": "CORPOFFICEID", "value": CorpId });
                    aoData.push({ "name": "TEAMLEAD_EMPID", "value": TeamLeadEmp_Id });
                    aoData.push({ "name": "TEAM_ID", "value": TeamId });
                    aoData.push({ "name": "DIV_ID", "value": DivisionId });
                },
                aoColumnDefs: [
                  {
                      bSortable: false,
                      aTargets: [-1,-2,-3]
                  }
                ]
            });


            // Apply the filter

            $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                otable
                    .column($NoConfi(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();
         

            });
            /* END COLUMN FILTER */

      //      SearchCheckedEmployeeMembers();
}






        var rowCount = 0;
        //rowCount for uniquness
        //row index add(+) and (-)delete count based on action
        var RowIndex = 0;

        function addMoreRows(strImagePath, strUserName, UsrId,CheckEdit) {
            //for checking checkboxes in employee list on editing,postck and on viewing
            CheckCheckBoxOfEmployeeMembers(UsrId);
            if (CheckEdit == "NoEdit")
            { }
            else
            {
                document.getElementById("<%=hiddenCheckEdit.ClientID%>").value = "Edited";
            }


        //    document.getElementById('divErrorTotal').style.visibility = "hidden";
          //  document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "";
            rowCount++;
            RowIndex++;




            var oldInnerHtmlForGoofyMembers = document.getElementById("divForgoofyMembers").innerHTML;
            var NewInnerHtmlForGoofyMembers = "";
            document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();

          

            var recRow = "<tr id='rowId_" + rowCount + "' class=\"border_bottom\"  >";
            recRow += " <td id='tdMemberId_" + rowCount + "' style=\"display: none;\" >" + UsrId + "</td>";
            recRow += " <td id='tdUserImagePath_" + rowCount + "' style=\"display: none;\" >" + strImagePath + "</td>";
            recRow += "<td  style=\"width:10%;height:40px; word-wrap:break-word;text-align: center;\"> ";

            if (document.getElementById("<%=hiddenViewMode.ClientID%>").value == "1") {
                recRow += " <a  class=\"lightbox\" >" + "<img  id='imgMemberId_" + rowCount + "' src='" + strImagePath + "' /> " + "</a> </td>";
            }
            else {
                recRow += " <a  class=\"lightbox\" href=\"#goofyMember_" + rowCount + "\"  >" + "<img  id='imgMemberId_" + rowCount + "' src='" + strImagePath + "' /> " + "</a> </td>";
            }
            NewInnerHtmlForGoofyMembers = " <div class=\"lightbox-target\" id=\"goofyMember_" + rowCount + "\">";

            NewInnerHtmlForGoofyMembers += " <img src=\"" + strImagePath + "\"/>";

            NewInnerHtmlForGoofyMembers += " <a class=\"lightbox-close\" href=\"#\"></a>";

            NewInnerHtmlForGoofyMembers += "</div>";

            recRow += "<td id='tdUserName_" + rowCount + "'  style=\" font-family: Calibri;color: #a9b496;font-size: 14px;vertical-align: bottom;padding-bottom: 2.5%;padding-left: 0%; width:80%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + strUserName + "</td>";

           
            if (document.getElementById("<%=hiddenViewMode.ClientID%>").value == "1") {
                recRow += "<td  style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;vertical-align: bottom;padding-bottom: 2.5%;padding-left: 0;\"><input type=\"image\" src='../../Images/Icons/delete.png' alt=\"Remove\" style=\" pointer-events: none; opacity:0.5\" onclick = \"return false;\"  ></td>";
            }
            else {
                recRow += "<td  style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;vertical-align: bottom;padding-bottom: 2.5%;padding-left: 0;\"><input type=\"image\" src='../../Images/Icons/delete.png' alt=\"Remove\"  onclick = \"return removeRow(" + rowCount + ");\"   style=\" cursor: pointer;\" ></td>";
            }

            recRow += '</tr>';

            jQuery('#TableaddedRows').append(recRow);
            document.getElementById("divForgoofyMembers").innerHTML = oldInnerHtmlForGoofyMembers + NewInnerHtmlForGoofyMembers;
            LocalStorageAdd(rowCount, UsrId, strImagePath, strUserName);

        }

        function removeRow(removeNum) {

            if (confirm("Are you sure you want to remove selected member ?")) {               
                var row_index = jQuery('#rowId_' + removeNum).index();


                //  var BforeRmvTableRowCount = document.getElementById("TableaddedRows").rows.length;

                  document.getElementById("<%=hiddenCheckEdit.ClientID%>").value = "Edited";
                  LocalStorageDelete(row_index, removeNum);

               //   jQuery('#rowId_' + removeNum).remove();
             //     $noC('table#TableaddedRows tr#rowId_' + removeNum).remove();
                RowIndex--;
                document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();
                
               __doPostBack('', '');


                return false;
           }
            else {
                return false;

            }
        }
        </script>
    <script>
        function AddMembers() {            
            IncrmntConfrmCounter();
            CheckForEmployeeMembers();
        }
        //this function add emplotees checked to member list i no duplication in member list
        function CheckForEmployeeMembers() {   
            var arr = [];
            $(".theClass:checked").each(function () {
                arr.push($(this).attr('id'));               
            });
            for (var i = 0; i < arr.length; i++) {
                    var strImagePath = "";
                    var strUserName = "";
                    var UsrId = "";
                var UserID = arr[i];               
                UserID = UserID.substring(5);

                UsrId = UserID;
                strImagePath = document.getElementById('imgId_' + UsrId).getAttribute('src');
                strUserName = document.getElementById('EmpName_' + UsrId).innerHTML;
                if (CheckDuplicationMemberOnAdding(UsrId) == false)//if no duplication
                {                 
                    addMoreRows(strImagePath, strUserName, UsrId, 'Edit');
                }
               
            }

            if ($('#TableaddedRows').length) {
                if ($("#TableaddedRows tr").length == 0) {
                    document.getElementById('IdNoTeamMembers').style.display = "block";
                }
                else {
                    document.getElementById('IdNoTeamMembers').style.display = "none";
                }
            }

        }




        function SearchCheckedEmployeeMembers() {
            var arr2 = [];

    $("input:checkbox[class=theClass]").each(function () {
                            arr2.push($(this).attr("id").replace("chbx_", ""));

                        });
    var table = document.getElementById("TableaddedRows");
                for (var i = 0, row; row = table.rows[i]; i++) {
                        col = row.cells[0];                       
                        var UsrIdAddeddRow = col.innerHTML;                    
                        var n = arr2.includes(UsrIdAddeddRow);

                        if (n == true) {
                            document.getElementById('chbx_' + UsrIdAddeddRow).checked = true;
                        }                        
                }
            return false;
        }



        //for checking the check boxes of added members in employee table  while editing and postback and viewing
        function CheckCheckBoxOfEmployeeMembers(UsrId) {
            var delayInMilliseconds = 1000; //1 second
            setTimeout(function () {
                var table = document.getElementById("datatable_fixed_column");
                var arr1 = [];
                $("input:checkbox[class=theClass]").each(function () {
                    arr1.push($(this).attr("id"));

                });
                var UsrIdAddeddRow = "";
                for (var i = 0; i < arr1.length; i++) {
                    var UsrID = arr1[i];
                    UsrIdAddeddRow = UsrID.substring(5);
                    if (UsrId == UsrIdAddeddRow) {
                        document.getElementById('chbx_' + UsrId).checked = true;
                    }
                }
            }, delayInMilliseconds);
                           
        }


        function CheckDuplicationMemberOnAdding(UsrId) {
            var table = document.getElementById("TableaddedRows");
           // var table = document.getElementById("datatable_fixed_column");

            var Found = 0;
            for (var i = 0, row; row = table.rows[i]; i++) {


                //iterate through rows
                //rows would be accessed using the "row" variable assigned in the for loop
                for (var j = 0, col; col = row.cells[j]; j++) {
                    if (j == 0) {
                          var UsrIdAddeddRow = col.innerHTML;                        
                        if (UsrId == UsrIdAddeddRow) {
                            Found = 1;

                        }
                    }
                }
            }
            if (Found == 0) {
                return false;
            }
            else {
                return true;
            }
        }

        function CheckDuplicationOfLeadinMemberList(UsrId) {
            var table = document.getElementById("TableaddedRows");
            var Found = 0;
            for (var i = 0, row; row = table.rows[i]; i++) {


                //iterate through rows
                //rows would be accessed using the "row" variable assigned in the for loop
                for (var j = 0, col; col = row.cells[j]; j++) {
                    if (j == 0) {
                        var UsrIdAddeddRow = col.innerHTML;                        
                        if (UsrId == UsrIdAddeddRow) {
                            Found = 1;

                        }
                    }

                    //iterate through columns
                    //columns would be accessed using the "col" variable assigned in the for loop
                }
            }
            if (Found == 0) {
                return false;
            }
            else {

                return true;
            }
        }
        function validateChange() {
            document.getElementById("<%=txtTeamLead.ClientID%>").style.borderColor = "";
            var PreviousVal = document.getElementById("<%=hiddenPreviousLead.ClientID%>").value;
            var DropdownListTeamLead = document.getElementById('<%=txtTeamLead.ClientID %>');
            var SelectedValueTeamLead = DropdownListTeamLead.value;
            if (SelectedValueTeamLead != "--SELECT TEAM LEAD--") {
                if (CheckDuplicationOfLeadinMemberList(SelectedValueTeamLead) == true) {


                    // if duplication
                    var desiredValue = PreviousVal;

                    var el = document.getElementById(("<%=txtTeamLead.ClientID%>"));
                    for (var i = 0; i < el.options.length; i++) {
                        if (el.options[i].value == desiredValue) {
                            el.selectedIndex = i;
                            break;
                        }
                    }
                    document.getElementById('divErrorTotal').style.visibility = "visible";
                    document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Sorry Team Lead Already Selected As Team Member.Please Remove From Member List in Order To Assign Employee As Team Lead .";
                    document.getElementById("<%=txtTeamLead.ClientID%>").style.borderColor = "Red";
                    return false;


                }
                else {
                    if (document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML == "Sorry Team Lead Already Selected As Team Member.Please Remove From Member List in Order To Assign Employee As Team Lead .") {
                        document.getElementById('divErrorTotal').style.visibility = "hidden";
                        document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "";
                        document.getElementById("<%=txtTeamLead.ClientID%>").style.borderColor = "";

                    }
                //   location.reload();
                    return false;
                }

            }
            else {
                document.getElementById('TeamDetails').style.display = "none";
                return false;
            }

            }
    
        function getPreviousDDL_SelectedVal() {// on click
            var DropdownList = document.getElementById('<%=txtTeamLead.ClientID %>');
               var SelectedIndex = DropdownList.selectedIndex;
               var SelectedValue = DropdownList.value;
               document.getElementById("<%=hiddenPreviousLead.ClientID%>").value = SelectedValue;

    }
        function LocalStorageAdd(x, UserId, ImagePath, UserName)
        {
           
                var tbClientTeam = localStorage.getItem("tbClientTeam");//Retrieve the stored data

                tbClientTeam = JSON.parse(tbClientTeam); //Converts string to object

                if (tbClientTeam == null) //If there is no data, initialize an empty array
                    tbClientTeam = [];
             

             
                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        ROWID: "" + x + "",
                        USERID: "" + UserId + "",
                        USERIMAGEPATH: "" + ImagePath + "",
                        USERNAME: "" + UserName + ""
                       
                    });
              
              
                tbClientTeam.push(client);
                localStorage.setItem("tbClientTeam", JSON.stringify(tbClientTeam));

                $add("#cphMain_HiddenField1").val(JSON.stringify(tbClientTeam));


            
                 //  var h = document.getElementById("<%=HiddenField1.ClientID%>").value;

               return true;
            
        }
        function LocalStorageDelete(row_index, x) {
            var $remove = jQuery.noConflict();
            var tbClientTeam = localStorage.getItem("tbClientTeam");//Retrieve the stored data

            tbClientTeam = JSON.parse(tbClientTeam); //Converts string to object

            if (tbClientTeam == null) //If there is no data, initialize an empty array
                tbClientTeam = [];



            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            tbClientTeam.splice(row_index, 1);
            localStorage.setItem("tbClientTeam", JSON.stringify(tbClientTeam));
            $remove("#cphMain_HiddenField1").val(JSON.stringify(tbClientTeam));

             // var h = document.getElementById("<%=HiddenField1.ClientID%>").value;

          //  return true;
        



        }

        $noC(window).load(function () {

           

            if (document.getElementById("<%=hiddenViewMode.ClientID%>").value == "1") {
                document.getElementById("<%=txtTeamName.ClientID%>").disabled = true;
                document.getElementById("<%=cbxStatus.ClientID%>").disabled = true;
                document.getElementById("<%=txtTeamLead.ClientID%>").disabled = true;
                document.getElementById("<%=btnUpdate.ClientID%>").style.display = "none";
                document.getElementById("<%=btnUpdateClose.ClientID%>").style.display = "none";
                document.getElementById("idbuttonSearchMember").style.visibility = "hidden";
                $("#TeamDetails").find("input,button,textarea,select").attr("disabled", "disabled");              
            }


            if (document.getElementById("<%=hiddenFieldTeamLeadEmp_Id.ClientID%>").value == "") {
                document.getElementById("TeamDetails").style.display = "none";
            }
            else {
              //  LoadTeamDetailsList();
                document.getElementById("TeamDetails").style.display = "block";
            }
            

          
            if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {

                IncrmntConfrmCounter();
            }
            // Run code
            localStorage.clear();
            if (document.getElementById("<%=HiddenField1.ClientID%>").value == "" || document.getElementById("<%=HiddenField1.ClientID%>").value == "[]") {      

            }
      
            else {
              //  $('#rowId').hide();

                var hiddenVal = document.getElementById("<%=HiddenField1.ClientID%>").value;
                document.getElementById("<%=HiddenField1.ClientID%>").value = "";
                //clear value of HiddenField1 value as it would be entered once more
                    var find1 = '\\\\';
                    var re1 = new RegExp(find1, 'g');

                    var res1 = hiddenVal.replace(re1, '');

                    var find2 = '\\["';
                    var re2 = new RegExp(find2, 'g');

                    var res2 = res1.replace(re2, '');

                    var find3 = '\\"]';
                    var re3 = new RegExp(find3, 'g');

                    var res3 = res2.replace(re3, '');

                    var jdatas = res3.split("\",\"{");


                    var i;
                    for (i = 0; i < jdatas.length; i++) {

                        var resultJSON = "";
                        if (i == 0) {
                            resultJSON = jdatas[i];

                        }
                        else {

                            resultJSON = "{" + jdatas[i];

                        }
                        var result = $noC.parseJSON(resultJSON);
                        var hUserId = "";
                        var hImagePath = "";
                        var hUsername = "";
                        $noC.each(result, function (k, v) {

                            if (k == "USERID") {
                                hUserId = v;

                            }
                            else if (k == "USERIMAGEPATH") {
                                hImagePath = v;

                            }
                            else if (k == "USERNAME") {
                               hUsername = v;

                            }
                        });
                        if (hUserId !="")
                        {
                            addMoreRows(hImagePath, hUsername, hUserId,'NoEdit');
                        }
                    }


            }

            var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;
            var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;

            


            var DropdownListTeamLead = document.getElementById('<%=txtTeamLead.ClientID %>');
            var SelectedValueTeamLead = DropdownListTeamLead.value;

            if (ViewVal == "") {
                if (SelectedValueTeamLead == "--SELECT TEAM LEAD--") {
                   // document.getElementById('TeamDetails').style.display = "none"; //cmt
                }
                else {
                    //  document.getElementById('TeamDetails').style.display = "";  //cmt
                }
            }

            if (EditVal != "") {
                var find1 = '\\\\';
                var re1 = new RegExp(find1, 'g');
                var res1 = EditVal.replace(re1, '');

                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = res1.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');
                var json = $noC.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        if (json[key].UsrId != "") {
                            addMoreRows(json[key].UsrImg, json[key].UsrName, json[key].UsrId, 'NoEdit')
                          
                        }
                    }
                }

                document.getElementById("<%=hiddenEdit.ClientID%>").value = "";

            }

            if (ViewVal != "") {
                document.getElementById('TeamDetails').style.display = "none";
                document.getElementById('TeamDetailsView').style.display = "";


            }
            else {

                document.getElementById('TeamDetailsView').style.display = "none";

            }

            if ($('#TableaddedRows').length) {
                if ($("#TableaddedRows tr").length ==0) {                    
                    document.getElementById('IdNoTeamMembers').style.display = "block";
                }
            }

        });


    </script>

    <script type="text/javascript">
        function ReplaceTag() {
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtTeamName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTeamName.ClientID%>").value = replaceText2;
        }
        function DuplicationName() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=txtTeamName.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Duplication Error!. Team Name Can’t be Duplicated.";
        }

        function SuccessConfirmation() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Team Details Inserted Successfully.";
        }
        function SuccessUpdation() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Team Details Updated Successfully.";
        }
        function NameValidate() {

            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtTeamName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTeamName.ClientID%>").value = replaceText2;


            document.getElementById("<%=txtTeamName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTeamLead.ClientID%>").style.borderColor = "";

            var Name = document.getElementById("<%=txtTeamName.ClientID%>").value.trim();                       
            var Lead = document.getElementById("<%=hiddenFieldTeamLeadEmp_Id.ClientID%>").value;
            if (document.getElementById("<%=HiddenField1.ClientID%>").value == "[]")
            {

                document.getElementById("<%=HiddenField1.ClientID%>").value = "";

            }



            if (Name == "" || Lead == "") {
                document.getElementById('divErrorTotal').style.visibility = "visible";
                document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                if (Lead == "") {
                    document.getElementById("<%=txtTeamLead.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTeamLead.ClientID%>").focus();
                    ret = false;

                }
                if (Name == "") {
                   document.getElementById("<%=txtTeamName.ClientID%>").style.borderColor = "Red";
                   document.getElementById("<%=txtTeamName.ClientID%>").focus();
                    ret = false;
                }
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

        function RemoveTag(control) {
            var text = document.getElementById(control).value;
            var replaceText1 = text.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(control).value = replaceText2;
        }


    </script>

    <script>
        function SearchClick() {

            var ret = true;

            document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "";

            if (document.getElementById("cphMain_ddlDivision").value == "--SELECT DIVISION--") {
                document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ddlDivision.ClientID%>").focus();

                ret = false;
            }
            if (ret == true) {
                LoadTeamDetailsList();
              
            }
        }
 
        function EmployeeSearch() {
            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("EmpSearchFilter");
            filter = input.value.toUpperCase();
            table = document.getElementById("datatable_fixed_column");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {                
                td = tr[i].getElementsByTagName("td")[2];               
                if (td) {
                    txtValue = td.textContent || td.innerText;
                    
                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }

        function TeamSearch() {
            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("TeamSearchFilter");
            filter = input.value.toUpperCase();
            table = document.getElementById("TableaddedRows");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[3];
                if (td) {
                    txtValue = td.textContent || td.innerText;

                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="cont_rght">
                <asp:HiddenField ID="hiddenPreviousLead" runat="server" />
        <asp:HiddenField ID="hiddenUserImagePath" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="hiddenDivsnId" runat="server" />
        <asp:HiddenField ID="hiddenEdit" runat="server" />
        <%--for checking if any editing done for members or not.This is if when editing team name only or team lead only without addin or removing team members then no need to delete and enter all again --%>
           <asp:HiddenField ID="hiddenCheckEdit" runat="server" />
        <asp:HiddenField ID="hiddenView" runat="server" />
            <asp:HiddenField ID="hiddenConfirmValue" runat="server" />

            <asp:HiddenField ID="hiddenFieldTeamLeadEmp_Id" runat="server" />
            <asp:HiddenField ID="hiddenFieldTeamId" runat="server" />

            <asp:HiddenField ID="hiddenForgoofy" runat="server" />
  
            <asp:HiddenField ID="hiddenViewMode" runat="server" />




        <div id="divErrorTotal" style="visibility: hidden">
            <asp:Label ID="lblErrorTotal" runat="server"></asp:Label>
        </div>
        <br />
        <br />
        <br />

          <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:6%; top:42%;height:26.5px;">

            <%-- <a href="gen_TeamHierarchyList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>

        <div class="fillform">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
            <br />
            <asp:Label ID="lblIndex" runat="server" Text="Label"  style="display:none;"></asp:Label>
            <div class="eachform">
                <h2>Team Name*</h2>

                <asp:TextBox ID="txtTeamName" Height="30px" Width="350px" class="form1" runat="server" MaxLength="100" Style="text-transform: uppercase; margin-right: 40%;" onkeypress="IncrmntConfrmCounter();" onblur="ReplaceTag();"></asp:TextBox>


            </div>
            <div class="eachform">
                <h2>Status*</h2>
                <div class="subform">
                    <asp:CheckBox ID="cbxStatus" Text="" runat="server" Checked="true" class="form2" />

                    <h3>Active</h3>

                </div>
            </div>
            
                    <div class="eachform">
                        <h2>Team Lead*</h2>

                        <div id="divTeamLead">
                        <%--<asp:DropDownList ID="ddlTeamLead" Height="30px" Width="350px" class="form1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTeamLead_SelectedIndexChanged" Style="margin-right: 30%;" onChange="return validateChange();" onclick="getPreviousDDL_SelectedVal()"></asp:DropDownList>--%>
                        <asp:TextBox ID="txtTeamLead"  onkeydown="DisableEnter(event)" onkeypress="return isTag(event);" onblur="return RemoveTag('cphMain_txtTeamLead');" Height="30px" Width="350px" class="form1" runat="server" MaxLength="100" Style="text-transform: uppercase; margin-right: 40%;"></asp:TextBox>

                        </div>
                    </div> 


                     <br />
                     <br />
             <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                    <div id="TeamDetails" style="display:none;height: 363px;">
                         <div id="div1" style="font-weight: bold; font-size: 10px; font-weight: bold; background: rgb(144, 162, 112) none repeat scroll 0% 0%; color: white; font-family: Calibri;text-align: center;padding-top:0.2%;height: 45px;">
                <h1>MEMBER DETAILS</h1>
            </div>
                        <br/>
                        <br />
                         <div class="eachform">
                      

                        <asp:DropDownList ID="ddlDivision" onchange="IncrmntConfrmCounter();" Height="25px" Width="340px" class="form1" runat="server" Style="float:left;"></asp:DropDownList>
                         <input id="imgBtnSearch" type="image" src="/Images/Icons/searchMedium.png"   style="padding-top: 0.5%; margin-left:1%" alt="Search" onclick="SearchClick(); return false;"  />  <%--onclick="return SearchClick();"--%>

                    </div>
                         <div class="eachform" style="margin-bottom:0px;">
                      <h2 class="lblTeamDtl" style="float: left; background-color:rgb(176, 192, 152);font-weight: bold;margin-bottom: -0.5%;color: white;font-size: 16px;width: 37.5%;padding-top: 0.7%;padding-bottom: 0.8%;padding-left: 0.5%;">EMPLOYEE LIST</h2>
                        <h2 class="lblTeamDtl" style="float: right;  background-color: rgb(176, 192, 152);font-weight: bold;margin-bottom: -0.5%;color: white;font-size: 16px;width: 37.5%;padding-top: 0.7%;padding-bottom: 0.8%;padding-left: 0.5%;">TEAM MEMBERS</h2>

                    </div>
<%--                        <div id="divUsers" runat="server" style="width: 38%; float: left;max-height: 239px;overflow: auto;">
                            <table id="TableEmployeeList"  style="border: 1px solid #afb6a2;" cellspacing="0" cellpadding="2px">
                            </table> 
                        </div>--%>

                        <div id="divdatatable_fixed_column" runat="server" style="width: 37.5%; float: left;max-height: 239px;overflow: auto;">

                            <div id="divEmpfilter" style="float: right;">
                                 <br>
                                    <span> Filter :  </span>                    
                                  <input type="text" id="EmpSearchFilter" onkeyup="EmployeeSearch()" /> 
                                <br/>                               
                                   </div>
                            
                              <table id="datatable_fixed_column" class="table table-striped table-bordered" width="100%" style="font-family: Calibri;">
                                 
                <thead style="display:none">
                    <tr class="SearchRow" >
                         <th class="hasinput" style="width: 11.25%">
                            <input id="empid" type="text" class="form-control" placeholder="1" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 11.25%">
                            <input  type="text" class="form-control" placeholder="2" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 11.25%">
                            <input  type="text" class="form-control" placeholder="3" onkeydown="return DisableEnter(event)" /></th>                                                                      
                        <th class="hasinput" style="width: 5%"></th>
                    </tr>
                    <tr>
                        <th data-class="expand" style="display:none">1</th>
                        <th data-class="expand">2</th>
                        <th data-class="expand">3</th>
                        <th data-class="expand">4</th>
                    </tr>
                </thead>
                <tbody>                    
                    <tr>
                        <td colspan="5" class="dataTables_empty">No data available.</td>
                    </tr>
                </tbody>
            </table>
                        </div>

                        <div style="width: 15%; margin-left: 42.5%;">
                            <div id="idbuttonSearchMember" class="buttonSearchMember" onclick="AddMembers();" style="text-align: center;">Select Members</div>
                        </div>
                        <div  style="width: 37.5%; float: right; margin-top: -2.7%;max-height: 239px;overflow: auto;">
                         <br>

                            <div id="divTeamfilter" style="float: right;">
                            <span> Filter :  </span>                            
                            <input type="text" id="TeamSearchFilter" onkeyup="TeamSearch()" />
                            </div>
                            <br>
                            <h5  id="IdNoTeamMembers" class="table table-striped table-bordered dataTables_empty" style="display:none; font-family: Calibri; height:52px;width:100%;">No team members available</h5>
                            <br>
                            <table  id="TableaddedRows" class="table table-striped no-footer dataTable" style="font-family: Calibri; height:52px;width:100%;"  cellspacing="0" cellpadding="2px">


                            </table>


                        </div>
                         <div id="divForgoofy" runat="server">
                    </div>
                    <div id="divForgoofyMembers">
                    </div>
                    </div>


               <div id="TeamDetailsView" style="display:none;height: 363px;">
                         <div id="div3"  style="font-weight: bold; font-size: 10px; font-weight: bold; background: rgb(144, 162, 112) none repeat scroll 0% 0%; color: white; font-family: Calibri;text-align: center;padding-top:0.2%;height: 27px;">
                <h1>MEMBER DETAILS</h1>
            </div>
                        <br/>
                        <br />
                       
                         <div class="eachform" style="margin-bottom:0px;">
                     
                        <h2 class="lblTeamDtl" style=" padding: 0.7% 37.8% 0.7% 0.7%;background-color:rgb(176, 192, 152);font-weight: bold;margin-bottom: -0.5%;color: white;font-size: 16px;">TEAM MEMBERS</h2>
                    </div>
                        <div id="divMembersView" runat="server" style="width: 50%; float: left;max-height: 239px;overflow: auto;">
                            
                           <table  id="TableMemberViewList" style="border: 1px solid #afb6a2; height:52px;width:100%;"  cellspacing="0" cellpadding="2px">
                            </table>
                        </div>

                      
                       
                         <div id="divForgoofyView" runat="server">
                    </div>
                 
                    </div>
                <%--       </ContentTemplate>
                        </asp:UpdatePanel>--%>
               
            <br />
            <div class="eachform">
                <div class="subform" style="margin-left: 30%; width: 40%; margin-top: 3%;">

                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
                     <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
                    <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
                        <%--<asp:Button ID="btnCancel" OnClientClick="ConfirmMessage();" runat="server" class="cancel" Text="Cancel"/>--%>
                    <input type="button" id="btnCancel" onclick="ConfirmMessage();" runat="server" class="cancel" Value="Cancel" />
                </div>
            </div>

        </div>

    </div>


   

</asp:Content>
