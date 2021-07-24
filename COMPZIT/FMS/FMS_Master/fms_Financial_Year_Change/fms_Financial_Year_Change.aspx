<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Financial_Year_Change.aspx.cs" Inherits="FMS_FMS_Master_fms_Financial_Year_Change_fms_Financial_Year_Change" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script>
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>


        <script>
            var $noCon1 = jQuery.noConflict();
            $noCon1(window).load(function () {
                var EditVal = document.getElementById("<%=HiddenFinancialYear.ClientID%>").value;
                if (EditVal != "") {
                    var find2 = '\\"\\[';
                    var re2 = new RegExp(find2, 'g');
                    var res2 = EditVal.replace(re2, '\[');

                    var find3 = '\\]\\"';
                    var re3 = new RegExp(find3, 'g');
                    var res3 = res2.replace(re3, '\]');
                    var json = $noCon1.parseJSON(res3);
                    for (var key in json) {
                        if (json.hasOwnProperty(key)) {
                            if (json[key].FINCYR_ID != "") {
                                EditListRows(json[key].FINCYR_ID, json[key].FINCYR_START_DT, json[key].FINCYR_END_DT, json[key].FINCYR_STATUS, json[key].FINCYR_DEFAULTNAME);
                            }
                        }
                    }
                }
            });
            function EditListRows(FINCYR_ID, FINCYR_START_DT, FINCYR_END_DT, FINCYR_STATUS, FINCYR_DEFAULTNAME) {

                if (FINCYR_ID != 0) {
                    AddNewGroup();
                    document.getElementById("tdidFYDtls" + currntx).innerHTML = currntx;
                    document.getElementById("tdInxGrp" + currntx).value = currntx;
                    document.getElementById("StartDateFY" + currntx).innerHTML = FINCYR_START_DT;
                    document.getElementById("EndDateFY" + currntx).innerHTML = FINCYR_END_DT;
                    document.getElementById("DefaultName" + currntx).innerHTML = FINCYR_DEFAULTNAME;
                    var FinId = '<%= Session["FINCYRID"] %>';
                    if (FinId == FINCYR_ID) {
                        document.getElementById("cbxStatus" + currntx).checked = true;
                    }
                    else {
                        document.getElementById("cbxStatus" + currntx).checked = false;
                    }
                    document.getElementById("tdDtlIdTempid" + currntx).value = FINCYR_ID;
                }
                if (currntx == 1) {
                    var StartDateFY = document.getElementById("StartDateFY" + currntx).innerHTML;
                    var EndDateFY = document.getElementById("EndDateFY" + currntx).innerHTML;
                    var arrstartYear = StartDateFY.split("-");
                    var arrEndYear = EndDateFY.split("-");
                    var defaultnm1 = parseInt(arrstartYear[2]);
                    var defaultnm2 = parseInt(arrEndYear[2]);
                    var last2 = defaultnm2.toString().slice(-2);
                    if (defaultnm1 == defaultnm2) {
                        document.getElementById("DefaultName" + currntx).innerHTML = defaultnm1;
                    }
                    else {
                        document.getElementById("DefaultName" + currntx).innerHTML = defaultnm1 + '-' + last2;
                    }
                }
            }
            function isTag(evt) {

                evt = (evt) ? evt : window.event;
                var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                //if (keyCodes == 13) {
                //    return false;
                //}
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
            function SuccessConfirmation() {
                $noCon1("#success-alert").html("Account settings inserted successfully.");
                $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon1("#success-alert").alert();
                return false;
            }
            function FinancialYear() {
                $noCon1("#divWarning").html("Current financial year can not be deleted.");
                $noCon1("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon1("#divWarning").alert();
                return false;
            }
            var confirmbox = 0;
            function IncrmntConfrmCounter() {
                confirmbox++;
            }
            var RowId = 0;
            var currntx = 0;
            function AddNewGroup() {
                RowId++;
                var FrecRow = '';
                FrecRow = '<tr id="SubFYRowId_' + RowId + '" ><td   id="tdidFYDtls' + RowId + '" style="display: none" >' + RowId + '</td>';
                FrecRow += ' <td id="StartDateFY' + RowId + '" ></td>';
                FrecRow += ' <td id="EndDateFY' + RowId + '" > </td>';
                FrecRow += ' <td id="DefaultName' + RowId + '"> </td>';
                FrecRow += '<td><div id=\"divcbxStatus' + RowId + '\" class=\"check1\"><div class=""> <label class="switch"><input name="cbxStatus' + RowId + '" type="checkbox" value="' + RowId + '" id="cbxStatus' + RowId + '"  onchange=\"CheckboxCheck(' + RowId + ');\" onkeypress="return DisableEnter(event)"> <span class="slider_tog round"></span> </label></div></div>';
                FrecRow += '</td>';
                FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdTempid' + RowId + '" name="tdDtlIdTempid' + RowId + '" placeholder=""/><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdGrp' + RowId + '" name="tdDtlIdGrp' + RowId + '" placeholder=""/></td>';
                FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdInxGrp' + RowId + '" name="tdInxGrp' + RowId + '" placeholder=""/> </td></tr>';


                jQuery('#tableFinacialYear').append(FrecRow);
                var Startdate = "";
                var Enddate = "";
                if (currntx != 0) {
                    var defaultnm1 = "";
                    var defaultnm2 = "";
                    var xLoop = "";
                    var tblFinacialYear = document.getElementById("tableFinacialYear");
                    for (var i = 1; i < tblFinacialYear.rows.length; i++) {
                        if (tblFinacialYear.rows[i].cells[0].innerHTML != "") {
                            xLoop = tblFinacialYear.rows[i].cells[0].innerHTML;
                            if (document.getElementById("EndDateFY" + xLoop).innerHTML != "") {
                                Startdate = document.getElementById("EndDateFY" + xLoop).innerHTML;
                            }
                        }
                    }
                    if (Startdate != "") {
                        // Startdate = document.getElementById("EndDateFY" + currntx).value;
                        var arrstartYear = Startdate.split("-");
                        if (parseInt(arrstartYear[1]) < 12) {
                            document.getElementById("StartDateFY" + RowId).innerHTML = ("01-" + parseInt(parseInt(arrstartYear[1]) + parseInt(1)) + "-" + arrstartYear[2]);
                            if (parseInt(arrstartYear[1]) < 10) {
                                document.getElementById("StartDateFY" + RowId).innerHTML = ("01-0" + parseInt(parseInt(arrstartYear[1]) + parseInt(1)) + "-" + arrstartYear[2]);
                            }
                            defaultnm1 = parseInt(arrstartYear[2]);
                        }
                        else {
                            document.getElementById("StartDateFY" + RowId).innerHTML = ("01-01" + "-" + parseInt(parseInt(arrstartYear[2]) + parseInt(1)));
                            defaultnm1 = parseInt(parseInt(arrstartYear[2]) + parseInt(1));
                        }
                    }
                    if (document.getElementById("StartDateFY" + RowId).innerHTML != "") {
                        Enddate = document.getElementById("StartDateFY" + RowId).innerHTML;
                        var arrEndYear = Enddate.split("-");
                        var newdate = new Date(arrEndYear[2], arrEndYear[1] - 1, arrEndYear[0]);

                        newdate.setMonth(newdate.getMonth() + 11);
                        //var day = newdate.getDate();
                        var day = new Date(newdate.getFullYear(), newdate.getMonth() + 1, 0);
                        day = day.getDate();
                        if (parseInt(day) < 10) {
                            day = "0" + day;
                        }
                        var month = newdate.getMonth() + 1;
                        if (parseInt(month) < 10) {
                            month = "0" + month;
                        }
                        var year = newdate.getFullYear();
                        defaultnm2 = year;
                        document.getElementById("EndDateFY" + RowId).innerHTML = day + '-' + month + '-' + year;

                    }
                    if (defaultnm1 != "" && defaultnm2 != "") {

                        if (defaultnm1 == defaultnm2) {

                            document.getElementById("DefaultName" + RowId).innerHTML = defaultnm1;
                        }
                        else {
                            var last2 = defaultnm2.toString().slice(-2);
                            document.getElementById("DefaultName" + RowId).innerHTML = defaultnm1 + '-' + last2;
                        }
                    }
                }

                currntx = RowId;
                return false;
            }

            function CheckboxCheck(RowId) {
                $('input[type="checkbox"]').each(function () {
                    var row = $(this).attr("id");
                    varSplit = row.split('cbxStatus');
                    if (varSplit[1] != "") {
                        document.getElementById('cbxStatus' + varSplit[1]).checked = false;
                    }
                });
                document.getElementById('cbxStatus' + RowId).checked = true;
                      
            }

            function ValidateFinancialYr() {

                var tbClientTotalValues = '';
                tbClientTotalValues = [];
                var tblFinacialYear = document.getElementById("tableFinacialYear");

                var YearId = "";
                var Startdate = "";
                var enddate = "";
                var defaultname = "";
                var checked = "";


                for (var i = 1; i < tblFinacialYear.rows.length; i++) {
                    var xLoop = (tblFinacialYear.rows[i].cells[0].innerHTML);

                    if (document.getElementById("cbxStatus" + xLoop).checked) {
                        checked = document.getElementById("tdDtlIdTempid" + xLoop).value;
                        Startdate = document.getElementById("StartDateFY" + xLoop).innerHTML;
                        enddate = document.getElementById("EndDateFY" + xLoop).innerHTML;
                    }
                }

                var FinyearId = checked;

                $.ajax({
                    type: "POST",
                    async: false,
                    url: 'fms_Financial_Year_Change.aspx/ChangeFinYear',
                    data: "{ id : '" + FinyearId + "' }",
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {

                        SuccessConfirmation(Startdate, enddate);

                    }
                });

                //EVM 040
                loadPage();

                return false;
            }

            function SuccessConfirmation(Startdate, enddate) {
                $noCon1("#success-alert").html("Financial year has been temporarily changed.");
                $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }


            //EVM 040
            function loadPage() {
                window.location.href = "fms_Financial_Year_Change.aspx";
                return false;
            }
            //EVM 040


    </script>
  


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <asp:HiddenField ID="HiddenFieldSaveAccount" runat="server" />
    <asp:HiddenField ID="HiddenFinancialYear" runat="server" />
    <asp:HiddenField ID="HiddenFYCnclId" runat="server" />
    <asp:HiddenField ID="HiddenModuleCount" runat="server" />
       <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Financial Year Change</li>
    </ol>
      <div class="myAlert-top alert alert-success" id="success-alert">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Success!</strong> Changes completed succesfully
    </div>

    <div class="myAlert-bottom alert alert-danger" id="divWarning">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Danger!</strong> Request not conmpleted
    </div>
    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">
            <div class="content_box1 cont_contr">
                
                    <h1>Financial Year Change</h1>

                <div class="table_box tb_scr" runat="server" id="DivFinacialYear">
                    <table class="table table-bordered" id="tableFinacialYear">
                        <thead class="thead1">
                            <tr>
                                <th class="col-md-3">Start Date</th>
                                <th class="col-md-3">End Date</th>
                                <th class="col-md-2">DEFAULT Name</th>
                                <th class="col-md-2">CURRENT FINANCIAL YEAR</th>

                            </tr>
                        </thead>
                        <tbody id="myTable">
                        </tbody>
                    </table>

                </div>
                <div class="sub_cont pull-right">
                    <div class="save_sec">
                        <asp:Button ID="btnsave" runat="server" OnClientClick="return ValidateFinancialYr();" class="btn sub1" Text="Change Fiscal Year" />
                    </div>
                </div>

            </div>
        </div>
    </div>
           
</asp:Content>


