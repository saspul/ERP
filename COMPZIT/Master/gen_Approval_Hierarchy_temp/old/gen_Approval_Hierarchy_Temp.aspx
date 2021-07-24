<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Approval_Hierarchy_Temp.aspx.cs" Inherits="Master_gen_Approval_Hierarchy_temp_gen_Approval_Hierarchy_Temp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
 <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
 <script src="/js/New%20js/date_pick/datepicker.js"></script>
 <script src="/js/Common/Common.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

 <asp:HiddenField ID="HiddenFieldAprvlHierarchyId" runat="server" Value="0" />   
 <asp:HiddenField ID="hiddenMainCanclDbId" runat="server" />
 <asp:HiddenField ID="hiddenSubCanclDbId" runat="server" />
 <asp:HiddenField ID="HiddenFieldMainData" runat="server" />
 <asp:HiddenField ID="HiddenFieldSubData" runat="server" />
 <asp:HiddenField ID="HiddenEdit" runat="server" />
 <asp:HiddenField ID="HiddenFieldCurrentDtlId" runat="server" Value="0" /> 
 <asp:HiddenField ID="HiddenFieldCurrentLevel" runat="server" Value="0" /> 
 <asp:HiddenField ID="HiddenFieldView" runat="server" Value="0" /> 

     <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

<!---breadcrumb_section_started---->    
    <ol class="breadcrumb">
      <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
      <li><a href="gen_Approval_Hierarchy_Temp_List.aspx">Approval Hierarchy Template</a></li>
      <li class="active" id="currPage" runat="server">Add Approval Hierarchy Template</li>
    </ol>
<!---breadcrumb_section_started----> 
      <!---alert_message_section---->
    <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
<!----alert_message_section_closed---->
    <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con" id="lblEntry" runat="server">Approved Hierarchy Template</h1>

          <div class="form-group fg2 fg2_ht">
            <label for="email" class="fg2_la1">Name of hierarchy:<span class="spn1">*</span></label>
            <input id="txtName" runat="server" onchange="IncrmntConfrmCounter();" maxlength="100" class="form-control fg2_inp1 fg_chs1 inp_mst" placeholder="Name of hierarchy" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onblur="RemoveTag('cphMain_txtName')" autocomplete="off"/>          
          </div>
          <div class="form-group fg2">
            <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                <input id="cbxSts" runat="server" type="checkbox" checked="checked" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>
          <div class="form-group fg2">
            <label for="email" class="fg2_la1 pad_l">Majority Approval:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                <input id="cbxMajorityApr" runat="server" type="checkbox" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>

<!---=================section_devider============--->
      <div class="clearfix"></div>
<!---=================section_devider============--->

        <div class="col-md-6">
          <div class="form-group fg6 fg2_dt">
            <label for="email" class="fg2_la1 pad_l">Set Start Date:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch" onclick="dte_m_1()">
                <input type="checkbox" id="cbx_dte1" runat="server" onchange="IncrmntConfrmCounter();" onkeypress="return isTagEnter(event)" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>

          <div class="form-group fg6 fg2_dt">
            <div class="tdte">
              <label for="pwd" class="fg2_la1">Start Date:<span class="spn1"></span> </label>
              <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
                <input id="txtFromdate" maxlength="10" onchange="return changeDate(1);" runat="server" class="form-control inp_bdr" type="text"  disabled="" onkeypress="return isTagEnter(event)" autocomplete="off" />
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
              </div>
            </div> 
          </div>
        </div>
        

        <div class="col-md-6">
          <div class="form-group fg6 fg2_dt">
            <label for="email" class="fg2_la1 pad_l">Set End Date:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch" onclick="dte_m()">
                <input type="checkbox" id="cbx_dte" runat="server" onchange="IncrmntConfrmCounter();" onkeypress="return isTagEnter(event)" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>

          <div class="form-group fg6 fg2_dt">
            <div class="tdte">
              <label for="pwd" class="fg2_la1">End Date:<span class="spn1"></span> </label>
              <div id="datepicker2" class="input-group date" data-date-format="mm-dd-yyyy">
                <input id="txtTodate" maxlength="10" runat="server" onchange="return changeDate(1);" class="form-control inp_bdr"  type="text" disabled="" onkeypress="return isTagEnter(event)" autocomplete="off"  />
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
              </div>
            </div> 
          </div>
        </div>
<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="free_sp"></div>
      <div class="devider"></div>
<!---=================section_devider============--->

        <div class="tb_res tb_s">
          <table class="table table-bordered tbl_fix">
            <thead class="thead1">
              <tr>
                <th class="th_b4 tr_l" rowspan="2">Designation</th>
                <th class="th_b2 tr_l" rowspan="2">Employee</th>
                <th class="th_b7" rowspan="2">Aprvl Mandatory</th>
                <th class="th_b7" rowspan="2">Substitute Employees</th>
                <th class="th_b4" rowspan="2">Threshold Period</th>
                <th class="th_b12">Notifications</th>
                <th class="th_b4" rowspan="2">ACTIONS</th>
              </tr>
              <tr>
                <th class="col_sp1">Apprvl Pending</th>
                <th class="col_sp1">TTC Exceeded</th>
                <th class="col_sp2">SMS</th>
                <th class="col_sp2">System</th>
              </tr>
            </thead>
            <tbody id="mainTable">
            </tbody>
          </table>
        </div><!---tb_res_closed--->


<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="free_sp"></div>
<!---=================section_devider============--->


<!--Buttons_Area_started--->
          <div class="sub_cont pull-right">
            <div class="save_sec">
                <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClientClick="return mainValidate();" onclick="btnUpdate_Click" />
                <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return mainValidate();" onclick="btnUpdate_Click" />
                <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClientClick="return mainValidate();" onclick="btnAdd_Click"/>
                <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClientClick="return mainValidate();" onclick="btnAdd_Click" />
                <asp:Button ID="btnCancel" runat="server" class="btn sub4 notv" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                <asp:Button ID="btnClear" runat="server" class="btn sub2" Text="Clear" OnClientClick="return AlertClearAll();"  />

            </div>
          </div>
<!--Buttons_area_closed--->

<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="free_sp"></div>
<!---=================section_devider============--->


<!---heirarchy_section_started--->

      <div class="box_pro_2_cont hire" style="display:none;">
<!------tree_section_started----->
        <div class="box_pro_2 pro_pa">
          <h3>Hierarchy</h3>
          <div class="tree well">
            <ul id="myTab1" runat="server">
            </ul>
          </div>
        </div>


<!------tree_section_closed----->
      
<!----Tree_table_section_box_opened--->

      <div class="box_pro_10 tab-content" >
          <div id="ceo" class="tabcontent">
          <h3 id="headTree"></h3>
          <div class="tb_res tb_s">
          <table class="table table-bordered tbl_fix">
            <thead class="thead1">
              <tr>
                <th class="th_b8 tr_l" rowspan="2">Designation</th>
                <th class="th_b2 tr_l" rowspan="2">Employee</th>
                <th class="th_b1" rowspan="2">Aprvl Mandatory</th>
                <th class="th_b1" rowspan="2">Number of Subordinates</th>
                <th class="th_b5" rowspan="2">Subordinates</th>
                <th class="th_b5" rowspan="2">Substitute Employees</th>
                <th class="th_b4" rowspan="2">Threshold Period</th>
                <th class="th_b12">Notifications</th>
                <th class="th_b4" rowspan="2">ACTIONS</th>
              </tr>
              <tr>
                <th class="col_sp1">Apprvl Pending</th>
                <th class="col_sp1">TTC Exceeded</th>
                <th class="col_sp2">SMS</th>
                <th class="col_sp2">System</th>
              </tr>
            </thead>
            <tbody id="subTable">
            </tbody>
          </table>
        </div>
        </div>
      </div>
<!----Tree_table_section_box_closed--->

<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="free_sp"></div>
<!---=================section_devider============--->



        <!--Buttons_Area_started--->
          <div class="sub_cont pull-right">
            <div class="save_sec">
                <asp:Button ID="btnUpdateS" runat="server" class="btn sub1" Text="Update" OnClientClick="return subValidate();" onclick="btnUpdateS_Click" />
                <asp:Button ID="btnCancelS" runat="server" class="btn sub4 notv" Text="Cancel" OnClientClick="return ConfirmMessageSub();" />
            </div>
         </div>
<!--Buttons_area_closed--->

      </div>
<!---heirarchy_section_started--->

<!---inner_content_sections area_closed--->

<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="free_sp"></div>
<!---=================section_devider============--->

<!---frame_border_area_closed---->
        </div>
      </div>
    </div>
 
    <!---back_button_fixed_section--->
  <a href="#" type="button" class="list_b" title="Back to List" onclick="return ConfirmMessage();">
    <i class="fa fa-arrow-circle-left"></i>
  </a>
<!---back_button_fixed_section--->

<!---select_popup_section_script--->
<link href="/css/New css/select2.min.css" rel="stylesheet" />
<script src="/js/New js/js/select2.min.js"></script>


<!---Start_date section--->
<script>
    function dte_m() {
        if (document.getElementById("cphMain_cbx_dte").checked == true) {
            document.getElementById("cphMain_txtTodate").disabled = false;
        } else {
            document.getElementById("cphMain_txtTodate").disabled = true;
            document.getElementById("cphMain_txtTodate").value = "";
        }
        document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "";
        document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
    }
    function dte_m_1() {
        if (document.getElementById("cphMain_cbx_dte1").checked == true) {
            document.getElementById("cphMain_txtFromdate").disabled = false;
        } else {
            document.getElementById("cphMain_txtFromdate").disabled = true;
            document.getElementById("cphMain_txtFromdate").value = "";
        }
        document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "";
        document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
    }
   
</script>

<!---closed_date section--->

     <script>
         $('#cphMain_txtFromdate').datepicker({
             autoclose: true,
             format: 'dd-mm-yyyy',
             startDate: new Date(),
             timepicker: false
         });
         $('#cphMain_txtTodate').datepicker({
             autoclose: true,
             format: 'dd-mm-yyyy',
             startDate: new Date(),
             timepicker: false
         });
 </script>
    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            var EditVal = document.getElementById("<%=HiddenEdit.ClientID%>").value;
            if (EditVal != "") {

                dte_m();
                dte_m_1();

                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = EditVal.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');
                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        if (json[key].DTLID != "") {
                            EditListRows(json[key].DTLID, json[key].LEVEL, json[key].DESGID, json[key].EMPID, json[key].APPRVMANSTS, json[key].SUBEMPSTS, json[key].THRESMODE, json[key].PERIOD, json[key].APPRVPENSTS, json[key].TTCSTS, json[key].SMSSTS, json[key].SYSSTS, json[key].NAME, json[key].DESGNAME);
                        }
                    }
                }
            }
            else {
                AddNewRowMain(null,null);
            }
            if (document.getElementById("<%=HiddenFieldView.ClientID%>").value == "1") {
                $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select").prop("disabled", true);                
            }
        });
    </script>
    <script>      
        var RowNumMain = 0;     
        function AddNewRowMain(dtlId,Name) {
            var FrecRow = '';

            FrecRow += '<tr id="mainRowId_' + RowNumMain + '" class="tr_act">';
            FrecRow += '<td style="display: none" >' + RowNumMain + '</td>';
            FrecRow += '<td id="dbId_' + RowNumMain + '" style="display: none" >' + dtlId + '</td>';
            
            FrecRow += '<td><input placeholder="-Select-" id="ddlDesgIdT_' + RowNumMain + '" onchange="return changeDesgMain(\'' + RowNumMain + '\');"  maxlength="100" onkeypress="return selectorToAutocompleteTextBox(' + RowNumMain + ',0,event);" onkeydown="return selectorToAutocompleteTextBox(' + RowNumMain + ',0,event);" onkeyup="return selectorToAutocompleteTextBox(' + RowNumMain + ',0,event);" type="text" class="form-control fg2_inp2" autocomplete="off"></td>';
            FrecRow += '<td style="display: none;"><input id="ddlDesgId_' + RowNumMain + '" value="-Select-"></td>';

            FrecRow += '<td><input placeholder="-Select-" id="ddlEmpIdT_' + RowNumMain + '" onchange="return changeEmpMain(\'' + RowNumMain + '\');"  maxlength="100" onkeypress="return selectorToAutocompleteTextBox(' + RowNumMain + ',1,event);" onkeydown="return selectorToAutocompleteTextBox(' + RowNumMain + ',1,event);" onkeyup="return selectorToAutocompleteTextBox(' + RowNumMain + ',1,event);" type="text" class="form-control fg2_inp2" autocomplete="off"></td>';
            FrecRow += '<td style="display: none;"><input id="ddlEmpId_' + RowNumMain + '" value="-Select-"></td>';


            FrecRow += '<td>';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxAprMand_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td>';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxSubstSts_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" >';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td>';
            FrecRow += '<div class="input-group ing2 dh_inp">';
            FrecRow += '<select id="ddlThresId_' + RowNumMain + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)">';
            FrecRow += '<option value="0">Days</option>';
            FrecRow += '<option value="1">Hours</option>';
            FrecRow += '</select>';
            FrecRow += '</div>';
            FrecRow += '<div class="input-group ing1">';
            FrecRow += '<input id="txtPeriod_' + RowNumMain + '" onchange="return BlurNotNumber(\'txtPeriod_' + RowNumMain + '\')" maxlength="3" onkeydown="return isNumber(event)" onkeydown="return isNumber(event)" type="text" class="form-control fg2_inp2 tr_r" autocomplete="off">';
            FrecRow += '</div>';
            FrecRow += '</td>';

            FrecRow += '<td class="col_sp1">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxAprPen_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="col_sp1">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxTtcExc_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="col_sp2">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxSms_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td class="col_sp2">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxSys_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="td1">';
            FrecRow += '<div class="btn_stl1">';
            FrecRow += '<button id="btnAdd_' + RowNumMain + '" onclick="return FuctionAddMain(\'' + RowNumMain + '\');" class="btn act_btn bn1 mainAdd" title="Add"><i class="fa fa-plus-circle"></i></button>';
            FrecRow += '<button id="btnDele_' + RowNumMain + '" onclick="return FuctionDeleMain(\'' + RowNumMain + '\');" class="btn act_btn bn3" title="Delete"><i class="fa fa-trash"></i></button>';
            if (dtlId != "" && dtlId != null) {
                FrecRow += '<button id="btnOrg_' + RowNumMain + '" onclick="return FuctionOrganize(\'' + dtlId + '\',0,\'' + Name + '\');" class="btn act_btn bn8 organiser notv" title="Organiser"><i class="fa fa-sitemap"></i></button>';
            }
            else {
                FrecRow += '<button disabled id="btnOrg_' + RowNumMain + '" class="btn act_btn bn8 organiser" title="Organiser"><i class="fa fa-sitemap"></i></button>';
            }
            FrecRow += '</div>';
            FrecRow += '</td>';

           
            FrecRow += '</tr>';
            jQuery('#mainTable').append(FrecRow);
            if (dtlId == "null" || dtlId == null || dtlId == "") {
                //document.getElementById("ddlDesgIdT_" + RowNumMain).focus();
            }
            $('.mainAdd').attr('disabled', 'disabled');
            var LastRowid = $("#mainTable tr:last td:first").html();
            document.getElementById("btnAdd_" + LastRowid).disabled = false;
            RowNumMain++;
            return false;
        }
        function EditListRows(DTLID,LEVEL,DESGID,EMPID,APPRVMANSTS,SUBEMPSTS,THRESMODE,PERIOD,APPRVPENSTS,TTCSTS,SMSSTS,SYSSTS,NAME,DESGNAME) {
            AddNewRowMain(DTLID,NAME);
            var validRowID = RowNumMain - 1;
            document.getElementById("dbId_" + validRowID).innerHTML = DTLID;
            document.getElementById("ddlDesgId_" + validRowID).value = DESGID;
            document.getElementById("ddlDesgIdT_" + validRowID).value = DESGNAME;
            document.getElementById("ddlEmpId_" + validRowID).value = EMPID;
            document.getElementById("ddlEmpIdT_" + validRowID).value = NAME;
            if (APPRVMANSTS == "1") {
                document.getElementById("cbxAprMand_" + validRowID).checked = true;
            }
            if (SUBEMPSTS == "1") {
                document.getElementById("cbxSubstSts_" + validRowID).checked = true;
            }
            document.getElementById("ddlThresId_" + validRowID).value = THRESMODE;
            document.getElementById("txtPeriod_" + validRowID).value = PERIOD;
            if (APPRVPENSTS == "1") {
                document.getElementById("cbxAprPen_" + validRowID).checked = true;
            }
            if (TTCSTS == "1") {
                document.getElementById("cbxTtcExc_" + validRowID).checked = true;
            }
            if (SMSSTS == "1") {
                document.getElementById("cbxSms_" + validRowID).checked = true;
            }
            if (SYSSTS == "1") {
                document.getElementById("cbxSys_" + validRowID).checked = true;
            }
        }       
        function FuctionOrganize(DtlId, Level, Name) {
            document.getElementById("headTree").innerHTML = Name;
            $(".hire").show();
            $("#subTable").empty();
            document.getElementById("cphMain_hiddenSubCanclDbId").value = "";
            document.getElementById("cphMain_HiddenFieldCurrentDtlId").value = DtlId;
            document.getElementById("cphMain_HiddenFieldCurrentLevel").value = Level;
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_Approval_Hierarchy_Temp.aspx/ReadSubtableDtls",
                data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",DtlId: "' + DtlId + '"}',
                dataType: "json",
                success: function (data) {
                    if (data.d != "" && data.d != null) {
                       
                        var find2 = '\\"\\[';
                        var re2 = new RegExp(find2, 'g');
                        var res2 = data.d.replace(re2, '\[');

                        var find3 = '\\]\\"';
                        var re3 = new RegExp(find3, 'g');
                        var res3 = res2.replace(re3, '\]');
                        var json = $noCon.parseJSON(res3);
                        for (var key in json) {
                            if (json.hasOwnProperty(key)) {
                                if (json[key].DTLID != "") {
                                    EditListRowsSub(json[key].DTLID, json[key].LEVEL, json[key].DESGID, json[key].EMPID, json[key].APPRVMANSTS, json[key].SUBEMPSTS, json[key].THRESMODE, json[key].PERIOD, json[key].APPRVPENSTS, json[key].TTCSTS, json[key].SMSSTS, json[key].SYSSTS, json[key].SUBORDNUM, json[key].NAME,json[key].DESGNAME);
                                }
                            }
                        }
                        document.getElementById("cphMain_btnUpdateS").value = "Update";
                    }
                    else {
                        document.getElementById("cphMain_btnUpdateS").value = "Save";
                        AddNewRowSub(null,null,0,null);
                    }
                }
            });
            if (document.getElementById("<%=HiddenFieldView.ClientID%>").value == "1") {
                $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select").prop("disabled", true);
                document.getElementById("cphMain_btnUpdateS").style.display = "none";
            }

            var FocusId = parseInt(RowNumMain) - 1;
            document.getElementById("ddlDesgIdT_" + FocusId).focus();
            return false;
        }

        function selectorToAutocompleteTextBox(x, mode, event) {

            if (event != null) {
                if (isTagEnter(event) == false) {
                    return false;
                }
            }

            var $au = jQuery.noConflict();
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            if (corptID != '' && corptID != null && (!isNaN(corptID)) && orgID != '' && orgID != null && (!isNaN(orgID))) {

                if (mode == "0") {
                    $au("#ddlDesgIdT_" + x).autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: "gen_Approval_Hierarchy_Temp.aspx/ReadDesgDdl",
                                data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'orgID': '" + parseInt(orgID) + "', 'corptID': '" + parseInt(corptID) + "'}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {
                                    response($.map(data.d, function (item) {
                                        return {
                                            label: item.split('<->')[1],
                                            val: item.split('<->')[0]
                                        }
                                    }))
                                },
                                error: function (response) {
                                },
                                failure: function (response) {
                                }
                            });
                        },
                        autoFocus: true,
                        //focus: function (event, ui) {
                        //    $("#ddlDesgIdT_" + x).val(ui.item.label);
                        //    $("#ddlDesgId_" + x).val(ui.item.id);
                        //    return false;
                        //},
                        select: function (e, i) {
                            document.getElementById("ddlDesgId_" + x).value = i.item.val;
                            document.getElementById("ddlDesgIdT_" + x).value = i.item.label;
                        },
                        change: function (event, ui) {
                            if (ui.item) {
                            }
                            else {
                                document.getElementById("ddlDesgId_" + x).value = "-Select-";
                                document.getElementById("ddlDesgIdT_" + x).value = "";
                            }
                        },
                        minLength: 1

                    });
                }
                else {
                    var DesgId = document.getElementById("ddlDesgId_" + x).value;
                    if (DesgId != "-Select-") {
                        $au("#ddlEmpIdT_" + x).autocomplete({
                            source: function (request, response) {
                                $.ajax({
                                    url: "gen_Approval_Hierarchy_Temp.aspx/changeDesg",
                                    data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'orgID': '" + parseInt(orgID) + "', 'corptID': '" + parseInt(corptID) + "','DesgId': '" + DesgId + "'}",
                                    dataType: "json",
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    success: function (data) {
                                        response($.map(data.d, function (item) {
                                            return {
                                                label: item.split('<->')[1],
                                                val: item.split('<->')[0]
                                            }
                                        }))
                                    },
                                    error: function (response) {
                                    },
                                    failure: function (response) {
                                    }
                                });
                            },
                            autoFocus: true,
                            //focus: function (event, ui) {
                            //    $("#ddlEmpIdT_" + x).val(ui.item.label);
                            //    $("#ddlEmpId_" + x).val(ui.item.id);
                            //    return false;
                            //},
                            select: function (e, i) {
                                document.getElementById("ddlEmpId_" + x).value = i.item.val;
                                document.getElementById("ddlEmpIdT_" + x).value = i.item.label;
                            },
                            change: function (event, ui) {
                                if (ui.item) {
                                }
                                else {
                                    document.getElementById("ddlEmpId_" + x).value = "-Select-";
                                    document.getElementById("ddlEmpIdT_" + x).value = "";
                                }
                            },
                            minLength: 1

                        });
                    }
                }
            }
        }
        function FuctionAddMain(RowNum) {           
            if (checkMainRow(RowNum) == true) {
                IncrmntConfrmCounter();
                AddNewRowMain(null, null);

                var FocusId = parseInt(RowNumMain) - 1;
                document.getElementById("ddlDesgIdT_" + FocusId).focus();
            }
            return false;
        }
        function FuctionDeleMain(RowNum) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to delete this hierarchy?",
                alertType: "info"
             }).done(function (e) {
                 if (e == true) {
                    IncrmntConfrmCounter();
                    var detailId = document.getElementById("dbId_" + RowNum).innerHTML;
                    if (detailId != "") {
                        var CanclIds = document.getElementById("cphMain_hiddenMainCanclDbId").value;
                        if (CanclIds == '') {
                            document.getElementById("cphMain_hiddenMainCanclDbId").value = detailId;
                        }
                        else {
                            document.getElementById("cphMain_hiddenMainCanclDbId").value = document.getElementById("cphMain_hiddenMainCanclDbId").value + ',' + detailId;
                        }
                    }
                    $('#mainRowId_' + RowNum).remove();
                    var TableRowCount = document.getElementById("mainTable").rows.length;
                    if (TableRowCount != 0) {
                        var LastRowid = $("#mainTable tr:last td:first").html();
                        document.getElementById("btnAdd_" + LastRowid).disabled = false;
                    }
                    else {
                        AddNewRowMain(null,null);
                    }
                    if (document.getElementById("cphMain_HiddenFieldCurrentDtlId").value == detailId) {
                        $(".hire").hide();
                        $("#subTable").empty();
                        document.getElementById("cphMain_hiddenSubCanclDbId").value = "";
                    }
                }
                else {
                }
            });
            return false;
        }
        function changeDesgMain(RowNum) {
            document.getElementById("ddlDesgIdT_" + RowNum).style.borderColor = "";
            document.getElementById("ddlEmpIdT_" + RowNum).style.borderColor = "";
            IncrmntConfrmCounter();
            if (document.getElementById("ddlDesgIdT_" + RowNum).value.trim() == "") {
                document.getElementById("ddlDesgId_" + RowNum).value = "-Select-";
            }
            document.getElementById("ddlEmpId_" + RowNum).value = "-Select-";
            document.getElementById("ddlEmpIdT_" + RowNum).value = "";
            return false;
        }
        function changeEmpMain(RowNum) {
            IncrmntConfrmCounter();
            document.getElementById("ddlEmpIdT_" + RowNum).style.borderColor = "";
            if (document.getElementById("ddlEmpIdT_" + RowNum).value.trim() == "" || document.getElementById("ddlDesgId_" + RowNum).value == "-Select-") {
                document.getElementById("ddlEmpId_" + RowNum).value = "-Select-";
                document.getElementById("ddlEmpIdT_" + RowNum).value = "";
                return false;
            }
            var EmpId = document.getElementById("ddlEmpId_" + RowNum).value;
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            if (EmpId != "-Select-") {
                var tableOtherItem = document.getElementById("mainTable");
                var m = parseInt(tableOtherItem.rows.length) - 1;
                for (var a = m; a >= 0; a--) {
                    var validRowID = (tableOtherItem.rows[a].cells[0].innerHTML);
                    var CheckEmpId = document.getElementById("ddlEmpId_" + validRowID).value;
                    if (RowNum != validRowID && EmpId == CheckEmpId) {
                        $("#divWarning").html("Duplication Error!.Employee can’t be duplicated in a hierarchy.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        document.getElementById("ddlEmpIdT_" + RowNum).style.borderColor = "red";
                        document.getElementById("ddlEmpIdT_" + RowNum).focus();
                        document.getElementById("ddlEmpIdT_" + RowNum).value = "";
                        document.getElementById("ddlEmpId_" + RowNum).value = "-Select-";
                        return false;
                    }
                }
                var tableOtherItem = document.getElementById("subTable");
                var m = parseInt(tableOtherItem.rows.length) - 1;
                for (var a = m; a >= 0; a--) {
                    var validRowID = (tableOtherItem.rows[a].cells[0].innerHTML);
                    var CheckEmpId = document.getElementById("ddlEmpId_" + validRowID).value;
                    if (RowNum != validRowID && EmpId == CheckEmpId) {
                        $("#divWarning").html("Duplication Error!.Employee can’t be duplicated in a hierarchy.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        document.getElementById("ddlEmpIdT_" + RowNum).style.borderColor = "red";
                        document.getElementById("ddlEmpIdT_" + RowNum).focus();
                        document.getElementById("ddlEmpIdT_" + RowNum).value = "";
                        document.getElementById("ddlEmpId_" + RowNum).value = "-Select-";
                        return false;
                    }
                }
                var Id = document.getElementById("<%=HiddenFieldAprvlHierarchyId.ClientID%>").value;
                if (Id != "" && Id != "0") {
                    var DtlId = 0;
                    if (document.getElementById("dbId_" + RowNum).innerHTML != "null"&& document.getElementById("dbId_" + RowNum).innerHTML != "" && document.getElementById("dbId_" + RowNum).innerHTML != null) {
                        DtlId = document.getElementById("dbId_" + RowNum).innerHTML;
                    }

                    var CanclIds = "";
                    if (document.getElementById("cphMain_hiddenSubCanclDbId").value != "" && document.getElementById("cphMain_hiddenSubCanclDbId").value != null) {
                        CanclIds = document.getElementById("cphMain_hiddenSubCanclDbId").value;
                    }
                    if (CanclIds == "" && document.getElementById("cphMain_hiddenMainCanclDbId").value!="" && document.getElementById("cphMain_hiddenMainCanclDbId").value!=null) {
                        CanclIds=document.getElementById("cphMain_hiddenMainCanclDbId").value;
                    }
                    else if (CanclIds != "" && document.getElementById("cphMain_hiddenMainCanclDbId").value != "" && document.getElementById("cphMain_hiddenMainCanclDbId").value != null) {
                        CanclIds = CanclIds+"," + document.getElementById("cphMain_hiddenMainCanclDbId").value;
                    }
                    CanclIds = CanclIds.trim().replace(/,/g, '-');
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_Approval_Hierarchy_Temp.aspx/checkEmpDuplication",
                    data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",Id: "' + Id + '",DtlId: "' + DtlId + '",EmpId: "' + EmpId + '",CanclIds: "' + CanclIds + '"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d == "dup") {
                            $("#divWarning").html("Duplication Error!.Employee can’t be duplicated in a hierarchy.");
                            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            document.getElementById("ddlEmpIdT_" + RowNum).style.borderColor = "red";
                            document.getElementById("ddlEmpIdT_" + RowNum).focus();
                            document.getElementById("ddlEmpIdT_" + RowNum).value = "";
                            document.getElementById("ddlEmpId_" + RowNum).value = "-Select-";
                        }
                    }
                });
              }
            }
            return false;
         }
        function checkMainRow(RowNum) {
            var ret = true;
            var DesgId = document.getElementById("ddlDesgId_" + RowNum).value;
            var EmpId = document.getElementById("ddlEmpId_" + RowNum).value;
            var Period = document.getElementById("txtPeriod_" + RowNum).value.trim();
            document.getElementById("ddlDesgIdT_" + RowNum).style.borderColor = "";
            document.getElementById("ddlEmpIdT_" + RowNum).style.borderColor = "";
            document.getElementById("txtPeriod_" + RowNum).style.borderColor = "";
            if (Period == "") {
                document.getElementById("txtPeriod_" + RowNum).style.borderColor = "red";
                document.getElementById("txtPeriod_" + RowNum).focus();
                ret = false;
            }
            if (EmpId == "" || EmpId=="-Select-") {
                document.getElementById("ddlEmpIdT_" + RowNum).style.borderColor = "red";
                document.getElementById("ddlEmpIdT_" + RowNum).focus();
                ret = false;
            }
            if (DesgId == "" || DesgId == "-Select-") {
                document.getElementById("ddlDesgIdT_" + RowNum).style.borderColor = "red";
                document.getElementById("ddlDesgIdT_" + RowNum).focus();
                ret = false;
            }
            return ret;
        }

        function checkSubRow(RowNum) {
            var ret = true;
           
            var Savests = "1";
            if (document.getElementById("cphMain_btnUpdateS").value == "Save") {
                Savests = "0";
            }
            var DesgId = document.getElementById("ddlDesgId_" + RowNum).value;
            var EmpId = document.getElementById("ddlEmpId_" + RowNum).value;
            var Period = document.getElementById("txtPeriod_" + RowNum).value.trim();
            document.getElementById("ddlDesgIdT_" + RowNum).style.borderColor = "";
            document.getElementById("ddlEmpIdT_" + RowNum).style.borderColor = "";
            document.getElementById("txtPeriod_" + RowNum).style.borderColor = "";


            var AprvMandSts = 0;
            if (document.getElementById("cbxAprMand_" + RowNum).checked == true) {
                AprvMandSts = 1;
            }
            var subsEmpSts = 0;
            if (document.getElementById("cbxSubstSts_" + RowNum).checked == true) {
                subsEmpSts = 1;
            }
            var ThresMode = document.getElementById("ddlThresId_" + RowNum).value;
            var AprvPendSts = 0;
            if (document.getElementById("cbxAprPen_" + RowNum).checked == true) {
                AprvPendSts = 1;
            }
            var TtcSts = 0;
            if (document.getElementById("cbxTtcExc_" + RowNum).checked == true) {
                TtcSts = 1;
            }
            var SmsSts = 0;
            if (document.getElementById("cbxSms_" + RowNum).checked == true) {
                SmsSts = 1;
            }
            var SystemSts = 0;
            if (document.getElementById("cbxSys_" + RowNum).checked == true) {
                SystemSts = 1;
            }


            if (ThresMode!="0" || SystemSts != "0" || TtcSts != "0" || SmsSts != "0" || AprvMandSts != "0" || subsEmpSts != "0" || AprvPendSts != "0" || Period != "" || EmpId != "-Select-" || DesgId != "-Select-" || Savests == "0") {

            if (Period == "") {
                document.getElementById("txtPeriod_" + RowNum).style.borderColor = "red";
                document.getElementById("txtPeriod_" + RowNum).focus();
                ret = false;
            }
            if (EmpId == "" || EmpId == "-Select-") {
                document.getElementById("ddlEmpIdT_" + RowNum).style.borderColor = "red";
                document.getElementById("ddlEmpIdT_" + RowNum).focus();
                ret = false;
            }
            if (DesgId == "" || DesgId == "-Select-") {
                document.getElementById("ddlDesgIdT_" + RowNum).style.borderColor = "red";
                document.getElementById("ddlDesgIdT_" + RowNum).focus();
                ret = false;
            }
        }
            return ret;
        }

        function BlurNotNumber(obj) {
            document.getElementById(obj).style.borderColor = "";
            IncrmntConfrmCounter();
            var txt = document.getElementById(obj).value;
            if (txt != "") {
                if (isNaN(txt)) {
                    document.getElementById(obj).value = "";
                    document.getElementById(obj).focus();                   
                }
            }
            return false;
        }
        function changeDate(mode) {
            var ret = true;
            document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
            var fromdate = document.getElementById("cphMain_txtFromdate").value;
            var toDate = document.getElementById("cphMain_txtTodate").value;
            if (mode == "0") {
                if (document.getElementById("cphMain_cbx_dte1").checked == true && fromdate == "") {
                    document.getElementById("cphMain_txtFromdate").style.borderColor = "Red";
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    $(window).scrollTop(0);
                    ret = false;
                }
                if (document.getElementById("cphMain_cbx_dte").checked == true && toDate == "") {
                    document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    $(window).scrollTop(0);
                    ret = false;
                }
            }
            else {
               IncrmntConfrmCounter();
            }
            if (fromdate != "" && toDate != "") {
                var arrDateFromchk = fromdate.split("-");
                dateDateFromchk = new Date(arrDateFromchk[2], arrDateFromchk[1] - 1, arrDateFromchk[0]);
                var arrDateTochk = toDate.split("-");
                dateDateTochk = new Date(arrDateTochk[2], arrDateTochk[1] - 1, arrDateTochk[0]);
                if (dateDateFromchk > dateDateTochk) {
                    $("#divWarning").html("From date should not be greater than to date.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    $(window).scrollTop(0);
                    document.getElementById("cphMain_txtFromdate").style.borderColor = "Red";
                    document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                    ret = false;
                }
            }
            return ret;
        }
        function mainValidate() {
            var ret = true;
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";
            var NameWithoutReplace = document.getElementById("<%=txtName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtName.ClientID%>").value = replaceText2;
            var Name = document.getElementById("<%=txtName.ClientID%>").value.trim();

            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];

            var tableOtherItem = document.getElementById("mainTable");
            var m = parseInt(tableOtherItem.rows.length) - 1;
            for (var a = m; a >= 0; a--) {
                var validRowID = (tableOtherItem.rows[a].cells[0].innerHTML);               
                if (checkMainRow(validRowID) == false) {
                    ret = false;
                }
                else {

                    var dtlId = (tableOtherItem.rows[a].cells[1].innerHTML);
                    var DesgId = document.getElementById("ddlDesgId_" + validRowID).value;
                    var EmpId = document.getElementById("ddlEmpId_" + validRowID).value;
                    var AprvMandSts = 0;
                    if (document.getElementById("cbxAprMand_" + validRowID).checked == true) {
                        AprvMandSts = 1;
                    }
                    var subsEmpSts = 0;
                    if (document.getElementById("cbxSubstSts_" + validRowID).checked == true) {
                        subsEmpSts = 1;
                    }
                    var ThresMode = document.getElementById("ddlThresId_" + validRowID).value;
                    var Period = document.getElementById("txtPeriod_" + validRowID).value.trim();
                    var AprvPendSts = 0;
                    if (document.getElementById("cbxAprPen_" + validRowID).checked == true) {
                        AprvPendSts = 1;
                    }
                    var TtcSts = 0;
                    if (document.getElementById("cbxTtcExc_" + validRowID).checked == true) {
                        TtcSts = 1;
                    }
                    var SmsSts = 0;
                    if (document.getElementById("cbxSms_" + validRowID).checked == true) {
                        SmsSts = 1;
                    }
                    var SystemSts = 0;
                    if (document.getElementById("cbxSys_" + validRowID).checked == true) {
                        SystemSts = 1;
                    }

                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        DTLID: "" + dtlId + "",
                        LEVEL: "0",                        
                        DESGID: "" + DesgId + "",
                        EMPID: "" + EmpId + "",
                        APPRVMANSTS: "" + AprvMandSts + "",
                        SUBEMPSTS: "" + subsEmpSts + "",
                        THRESMODE: "" + ThresMode + "",
                        PERIOD: "" + Period + "",
                        APPRVPENSTS: "" + AprvPendSts + "",
                        TTCSTS: "" + TtcSts + "",
                        SMSSTS: "" + SmsSts + "",
                        SYSSTS: "" + SystemSts + ""
                    });
                    tbClientJobSheduling.push(client);

                }
            }
            if (changeDate(0) == false) {
                ret = false;
            }
            if (Name == "") {
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=txtName.ClientID%>").focus();
                ret = false;
            }             
            if (ret == false) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            else {
                var Id = document.getElementById("<%=HiddenFieldAprvlHierarchyId.ClientID%>").value; 
                var orgID = '<%= Session["ORGID"] %>';
                var corptID = '<%= Session["CORPOFFICEID"] %>';
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_Approval_Hierarchy_Temp.aspx/checkDup",
                    data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",Id: "' + Id + '",Name: "' + Name + '"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d == "dup") {
                            DupName();
                            ret = false;
                        }
                    }
                });
            }
            if (ret == true) {
                $add("#cphMain_HiddenFieldMainData").val(JSON.stringify(tbClientJobSheduling));
            }
            return ret;
        }
        function subValidate() {
            var ret = true;
            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];

            var tableOtherItem = document.getElementById("subTable");
            var m = parseInt(tableOtherItem.rows.length) - 1;
            for (var a = m; a >= 0; a--) {
                var validRowID = (tableOtherItem.rows[a].cells[0].innerHTML);
                if (checkSubRow(validRowID) == false) {
                    ret = false;
                }
                else {

                    var dtlId = (tableOtherItem.rows[a].cells[1].innerHTML);
                    var DesgId = document.getElementById("ddlDesgId_" + validRowID).value;
                    var EmpId = document.getElementById("ddlEmpId_" + validRowID).value;
                    var AprvMandSts = 0;
                    if (document.getElementById("cbxAprMand_" + validRowID).checked == true) {
                        AprvMandSts = 1;
                    }
                    var subsEmpSts = 0;
                    if (document.getElementById("cbxSubstSts_" + validRowID).checked == true) {
                        subsEmpSts = 1;
                    }
                    var ThresMode = document.getElementById("ddlThresId_" + validRowID).value;
                    var Period = document.getElementById("txtPeriod_" + validRowID).value.trim();
                    var AprvPendSts = 0;
                    if (document.getElementById("cbxAprPen_" + validRowID).checked == true) {
                        AprvPendSts = 1;
                    }
                    var TtcSts = 0;
                    if (document.getElementById("cbxTtcExc_" + validRowID).checked == true) {
                        TtcSts = 1;
                    }
                    var SmsSts = 0;
                    if (document.getElementById("cbxSms_" + validRowID).checked == true) {
                        SmsSts = 1;
                    }
                    var SystemSts = 0;
                    if (document.getElementById("cbxSys_" + validRowID).checked == true) {
                        SystemSts = 1;
                    }
                    var level = parseInt(document.getElementById("cphMain_HiddenFieldCurrentLevel").value)+1;
                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        DTLID: "" + dtlId + "",
                        LEVEL: "" + level + "",
                        DESGID: "" + DesgId + "",
                        EMPID: "" + EmpId + "",
                        APPRVMANSTS: "" + AprvMandSts + "",
                        SUBEMPSTS: "" + subsEmpSts + "",
                        THRESMODE: "" + ThresMode + "",
                        PERIOD: "" + Period + "",
                        APPRVPENSTS: "" + AprvPendSts + "",
                        TTCSTS: "" + TtcSts + "",
                        SMSSTS: "" + SmsSts + "",
                        SYSSTS: "" + SystemSts + ""
                    });
                    tbClientJobSheduling.push(client);

                }
            }
            if (ret == false) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            if (ret == true) {
                $add("#cphMain_HiddenFieldSubData").val(JSON.stringify(tbClientJobSheduling));
            }
            return ret;
        }
        function AddNewRowSub(DtlId, Level, SubordNum,Name) {
            var FrecRow = '';
            FrecRow += '<tr id="mainRowId_' + RowNumMain + '" class="">';
            FrecRow += '<td style="display: none" >' + RowNumMain + '</td>';
            FrecRow += '<td id="dbId_' + RowNumMain + '" style="display: none" >' + DtlId + '</td>';

            FrecRow += '<td><input placeholder="-Select-" id="ddlDesgIdT_' + RowNumMain + '" onchange="return changeDesgMain(\'' + RowNumMain + '\');"  maxlength="100" onkeypress="return selectorToAutocompleteTextBox(' + RowNumMain + ',0,event);" onkeydown="return selectorToAutocompleteTextBox(' + RowNumMain + ',0,event);" onkeyup="return selectorToAutocompleteTextBox(' + RowNumMain + ',0,event);" type="text" class="form-control fg2_inp2" autocomplete="off"></td>';
            FrecRow += '<td style="display: none;"><input id="ddlDesgId_' + RowNumMain + '" value="-Select-"></td>';

            FrecRow += '<td><input placeholder="-Select-" id="ddlEmpIdT_' + RowNumMain + '" onchange="return changeEmpMain(\'' + RowNumMain + '\');"  maxlength="100" onkeypress="return selectorToAutocompleteTextBox(' + RowNumMain + ',1,event);" onkeydown="return selectorToAutocompleteTextBox(' + RowNumMain + ',1,event);" onkeyup="return selectorToAutocompleteTextBox(' + RowNumMain + ',1,event);" type="text" class="form-control fg2_inp2" autocomplete="off"></td>';
            FrecRow += '<td style="display: none;"><input id="ddlEmpId_' + RowNumMain + '" value="-Select-"></td>';

            FrecRow += '<td>';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxAprMand_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" >';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td id="tdNumsubord_' + RowNumMain + '">' + SubordNum + '</td>';
            FrecRow += '<td>';
            if (SubordNum != "0" && SubordNum != null && SubordNum != "") {
                FrecRow += '<button id="btnSubord_' + RowNumMain + '" onclick="return FuctionOrganize(\'' + DtlId + '\',\'' + Level + '\',\'' + Name + '\');" class="btn act_btn bn6 notv" title="Subordinates"><i class="fa fa-cloud-download" aria-hidden="true"></i></button>';
            }
            else {
                FrecRow += '<button disabled id="btnSubord_' + RowNumMain + '" class="btn act_btn bn6" title="Subordinates"><i class="fa fa-cloud-download" aria-hidden="true"></i></button>';
            }
            FrecRow += '</td>';
            FrecRow += '<td>';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxSubstSts_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';
              
            FrecRow += '<td>';
            FrecRow += '<div class="input-group ing2 dh_inp">';
            FrecRow += '<select id="ddlThresId_' + RowNumMain + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)">';
            FrecRow += '<option value="0">Days</option>';
            FrecRow += '<option value="1">Hours</option>';
            FrecRow += '</select>';
            FrecRow += '</div>';
            FrecRow += '<div class="input-group ing1">';
            FrecRow += '<input id="txtPeriod_' + RowNumMain + '" onchange="return BlurNotNumber(\'txtPeriod_' + RowNumMain + '\')" maxlength="3" onkeydown="return isNumber(event)" onkeydown="return isNumber(event)" type="text" class="form-control fg2_inp2 tr_r" autocomplete="off" >';
            FrecRow += '</div>';
            FrecRow += '</td>';

            FrecRow += '<td class="col_sp1">';
            FrecRow += '<div class="check1 swt"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxAprPen_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td class="col_sp1">';
            FrecRow += '<div class="check1 swt"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxTtcExc_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td class="col_sp2">';
            FrecRow += '<div class="check1 swt"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxSms_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td class="col_sp2">';
            FrecRow += '<div class="check1 swt"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxSys_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td class="td1">';
            FrecRow += '<div class="btn_stl1">';
            FrecRow += '<button id="btnAdd_' + RowNumMain + '" onclick="return FuctionAddSub(\'' + RowNumMain + '\');" class="btn act_btn bn1 subAdd" title="Add"><i class="fa fa-plus-circle"></i></button>';
            FrecRow += '<button id="btnDele_' + RowNumMain + '" onclick="return FuctionDeleSub(\'' + RowNumMain + '\');" class="btn act_btn bn3" title="Delete"><i class="fa fa-trash"></i></button>';
            FrecRow += '</div>';
            FrecRow += '</td>';

            FrecRow += '</tr>';

            jQuery('#subTable').append(FrecRow);
            if (DtlId == "null" || DtlId == null || DtlId == "") {
                document.getElementById("ddlDesgIdT_" + RowNumMain).focus();
            }

            $('.subAdd').attr('disabled', 'disabled');
            var LastRowid = $("#subTable tr:last td:first").html();
            document.getElementById("btnAdd_" + LastRowid).disabled = false;
            RowNumMain++;
            return false;
        }
        function EditListRowsSub(DTLID, LEVEL, DESGID, EMPID, APPRVMANSTS, SUBEMPSTS, THRESMODE, PERIOD, APPRVPENSTS, TTCSTS, SMSSTS, SYSSTS, SUBORDNUM,NAME,DESGNAME) {
            AddNewRowSub(DTLID, LEVEL, SUBORDNUM, NAME);
            var validRowID = RowNumMain - 1;
            document.getElementById("dbId_" + validRowID).innerHTML = DTLID;
            document.getElementById("ddlDesgId_" + validRowID).value = DESGID;
            document.getElementById("ddlDesgIdT_" + validRowID).value = DESGNAME;
            document.getElementById("ddlEmpId_" + validRowID).value = EMPID;
            document.getElementById("ddlEmpIdT_" + validRowID).value = NAME;
            if (APPRVMANSTS == "1") {
                document.getElementById("cbxAprMand_" + validRowID).checked = true;
            }
            if (SUBEMPSTS == "1") {
                document.getElementById("cbxSubstSts_" + validRowID).checked = true;
            }
            document.getElementById("ddlThresId_" + validRowID).value = THRESMODE;
            document.getElementById("txtPeriod_" + validRowID).value = PERIOD;
            if (APPRVPENSTS == "1") {
                document.getElementById("cbxAprPen_" + validRowID).checked = true;
            }
            if (TTCSTS == "1") {
                document.getElementById("cbxTtcExc_" + validRowID).checked = true;
            }
            if (SMSSTS == "1") {
                document.getElementById("cbxSms_" + validRowID).checked = true;
            }
            if (SYSSTS == "1") {
                document.getElementById("cbxSys_" + validRowID).checked = true;
            }
        }
        function FuctionAddSub(RowNum) {
            if (checkMainRow(RowNum) == true) {
                IncrmntConfrmCounter();
                AddNewRowSub(null, null, 0, null);

                var FocusId = parseInt(RowNumMain) - 1;
                document.getElementById("ddlDesgIdT_" + FocusId).focus();
            }
            return false;
        }
        function FuctionDeleSub(RowNum) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to delete this hierarchy?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    IncrmntConfrmCounter();
                    var detailId = document.getElementById("dbId_" + RowNum).innerHTML;
                    if (detailId != "") {
                        var CanclIds = document.getElementById("cphMain_hiddenSubCanclDbId").value;
                        if (CanclIds == '') {
                            document.getElementById("cphMain_hiddenSubCanclDbId").value = detailId;
                        }
                        else {
                            document.getElementById("cphMain_hiddenSubCanclDbId").value = document.getElementById("cphMain_hiddenSubCanclDbId").value + ',' + detailId;
                        }
                    }
                    $('#mainRowId_' + RowNum).remove();
                    var TableRowCount = document.getElementById("subTable").rows.length;
                    if (TableRowCount != 0) {
                        var LastRowid = $("#subTable tr:last td:first").html();
                        document.getElementById("btnAdd_" + LastRowid).disabled = false;
                    }
                    else {
                        AddNewRowSub(null, null, 0,null);
                    }
                }
                else {
                }
            });
            return false;
        }
    </script>
    <script>
        function SuccessIns() {
            $("#success-alert").html("Approval hierarchy details inserted successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpd() {
            $("#success-alert").html("Approval hierarchy details updated successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function DupName() {
            $("#divWarning").html("Duplication Error!.Hierarchy name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("cphMain_txtName").style.borderColor = "red";
            document.getElementById("cphMain_txtName").focus();
            return false;
        }
        function ConfirmMessage() {
                 if (confirmbox > 0) {
                     ezBSAlert({
                         type: "confirm",
                         messageText: "Are you sure you want to leave this page?",
                         alertType: "info"
                     }).done(function (e) {
                         if (e == true) {
                             window.location.href = "gen_Approval_Hierarchy_Temp_List.aspx";
                         }
                         else {
                             return false;
                         }
                     });
                     return false;
                 }
                 else {
                     window.location.href = "gen_Approval_Hierarchy_Temp_List.aspx";
                     return false;
                 }
        }
        function ConfirmMessageSub() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to cancel?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        $(".hire").hide();
                        $("#subTable").empty();
                        document.getElementById("cphMain_hiddenSubCanclDbId").value = "";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                $(".hire").hide();
                $("#subTable").empty();
                document.getElementById("cphMain_hiddenSubCanclDbId").value = "";
                return false;
            }
        }
         function AlertClearAll() {        
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want clear all data in this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "gen_Approval_Hierarchy_Temp.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                return true;
            }
         }
         var confirmbox = 0;
         function IncrmntConfrmCounter() {
             confirmbox++;
             return false;
         }
    </script>
    <style>
         .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            width: 218px;
            border: 1px solid #B0BECA;
            max-height: 140px;
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
</asp:Content>

