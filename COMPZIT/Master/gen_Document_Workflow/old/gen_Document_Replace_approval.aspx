<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Document_Replace_approval.aspx.cs" Inherits="Master_gen_Document_Replace_approval_gen_Document_Replace_approval" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
 <script src="/js/New%20js/date_pick/datepicker.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
 <script src="/js/Common/Common.js"></script>
   

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:HiddenField ID="HiddenFieldAprvlHierarchyId" runat="server" Value="0" />   
 <asp:HiddenField ID="hiddenMainCanclDbId" runat="server" />
 <asp:HiddenField ID="hiddenSubCanclDbId" runat="server" />
 <asp:HiddenField ID="HiddenFieldMainData" runat="server" />
 <asp:HiddenField ID="HiddenFieldSubData" runat="server" />
 
 <asp:HiddenField ID="HiddenFieldCurrentDtlId" runat="server" Value="0" /> 
 <asp:HiddenField ID="HiddenFieldCurrentLevel" runat="server" Value="0" /> 
 <asp:HiddenField ID="HiddenFieldView" runat="server" />
    <asp:HiddenField ID="HiddenHrchyId" runat="server" />
    <asp:HiddenField ID="HiddenEdit" runat="server"/>
    <asp:HiddenField ID="HiddenHrchyname" runat="server" />
    <asp:HiddenField ID="HiddenWrkname" runat="server" />
    <asp:HiddenField ID="HiddenWrkParentId" runat="server" />
    <asp:HiddenField ID="HiddenwrkflwId" runat="server" />

     <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>


    <!---breadcrumb_section_started---->    
    <ol class="breadcrumb">
      <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
      <li><a href="gen_Document_Workflow_List.aspx">Purchase order</a></li>
      <li class="active">Add Document Workflow</li>
    </ol>
<!---breadcrumb_section_started----> 

    <div class="content_sec2 cont_contr" id="sd" runat="server">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con">Add Document Workflow
              <asp:HiddenField ID="HiddenSubTable" runat="server" />
            </h1>

          <div class="form-group fg2 fg2_wf">
            <label for="email" class="fg2_la1">Name:<span class="spn1">*</span></label>
              <asp:TextBox ID="txtName"  class="form-control fg2_inp1 fg_chs1 inp_mst" placeholder="Name" runat="server"></asp:TextBox>     
          </div>

          <div class="form-group fg2 fg2_wf">
               <label for="email" class="fg2_la1">Document Section<span class="spn1"></span>:</label>
              <asp:DropDownList ID="docsection" class="form-control fg2_inp1 fg_chs1" runat="server" onclick="enable()">
                  <asp:ListItem Value="0">--select--</asp:ListItem>
              </asp:DropDownList>       
          </div>

      
          <div class="form-group fg2 fg2_wf1">
            <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                  <label class="switch">
                      <asp:CheckBox ID="cbxsts"  runat="server" Checked="true" /><span class="slider_tog round"></span> 
                </label>
              </div>
            </div>
          </div>
          <div class="form-group fg2 fg2_wf1">  
            <label for="email" class="fg2_la1 pad_l">Enable Approval Transfer:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                    <asp:CheckBox ID="cbxapr" runat="server" /><span class="slider_tog round"></span> 
                </label>
              </div>
            </div>
          </div>

     <!---=================section_devider============--->
                  <div class="clearfix"></div>
      <!---=================section_devider============--->

          <div class="form-group fg2 fg2_wf">
              <asp:HiddenField ID="HiddenFieldwrkId" runat="server" />
            <label for="email" class="fg2_la1 pad_l">Approver Can Modify:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                    <asp:CheckBox ID="cbxmdfy" runat="server" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>

          <div class="form-group fg2 fg2_wf">
            <label for="email" class="fg2_la1">Priority:<span class="spn1"></span></label>
            <div class="col-md-12 mar_a flt_l fg2_wf1">
              <div class="form-group fogp rati_1">
                <label for="radio" class="fg2_la1 pa_tp0">
                  <asp:RadioButton ID="rbMedium" runat="server" GroupName="a" Checked="true" />Medium
                </label>
              </div>
              <div class="form-group fogp rati_1">
                <label for="radio" class="fg2_la1">
                  <asp:RadioButton ID="rbHigh" runat="server" GroupName="a" />High
                </label>
              </div>
            </div>      
          </div>

          <div class="form-group fg6 fg2_wf1">
            <label for="email" class="fg2_la1">Description:<span class="spn1"></span></label>
              <asp:TextBox ID="txtDescr" class="form-control fg2_inp1 fg_chs1" runat="server" TextMode="MultiLine" Height="100px"></asp:TextBox>  
          </div>

      <!---=================section_devider============--->
                  <div class="clearfix"></div>
      <!---=================section_devider============--->

         <h3 class="h1_con">Applicable For</h3>

          <div class="form-group fg2_wf2 opt1">
            <label for="email" class="fg2_la1">Department:<span class="spn1">*</span></label>
            <asp:ListBox ID="lstDpt" class="form-control select2" multiple="multiple" runat="server" Width="90%" SelectionMode="Multiple" style="border-color:red"></asp:ListBox>
          </div>
            
          <div class="form-group fg2_wf2 opt1">
            <label for="email" class="fg2_la1">Division:<span class="spn1">*</span></label>
              <asp:ListBox ID="lstDiv" class="form-control select2" multiple="multiple" runat="server" SelectionMode="Multiple"></asp:ListBox>  
          </div>
          
<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="free_sp"></div>
      <div class="devider"></div>
<!---=================section_devider============--->

        <h3 class="h1_con">Approval Heirarchy</h3>

        <div class="form-group fg2 fg2_wf">
          <label for="email" class="fg2_la1">Approval Heirarchy:<span class="spn1">*</span></label>
            <asp:DropDownList ID="dlHrchy" runat="server" class="form-control fg2_inp1 fg_chs1 inp_mst" OnSelectedIndexChanged="dlHrchy_SelectedIndexChanged" AutoPostBack="True" >                       
               <asp:ListItem  Value="0">--select--</asp:ListItem>
            </asp:DropDownList> 
        </div>

         <div class="form-group fg2 fg2_wf">
            <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                    <asp:CheckBox ID="cbxhrsts" runat="server" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>

        <div class="fg6 fg2_wf1">
          <label for="email" class="fg2_la1">Notifications:</label>

          <div class="col-md-6 fg2_wf opt1">
            <label for="email" class="fg2_la1 pad_l">Approval Pending:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                    <asp:CheckBox ID="cbxaprpnd" runat="server" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>
          <div class="col-md-6 fg2_wf opt1">
            <label for="email" class="fg2_la1 pad_l">Time Exceeded:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                    <asp:CheckBox ID="cbxTmExd" runat="server" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>
          <div class="col-md-6 fg2_wf opt1">
            <label for="email" class="fg2_la1 pad_l">SMS:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                    <asp:CheckBox ID="cbxsm" runat="server" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>
          <div class="col-md-6 fg2_wf opt1">
            <label for="email" class="fg2_la1 pad_l">System Notification:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                    <asp:CheckBox ID="cbxnt" runat="server" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>

        </div>
 
<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="free_sp"></div>
      <div class="devider"></div>
<!---=================section_devider============--->


        <div class="fg2 fg2_wf">
            <label for="email" class="fg2_la1 pad_l">Set Start Date:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch" onclick="dte_m_1()">
                    <asp:CheckBox ID="cbsdate" runat="server" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>

          <div class="form-group fg2 fg2_wf">
            <div class="tdte">
              <label for="pwd" class="fg2_la1">Start Date:<span class="spn1"></span> </label>
              <div id="datepicker1" class="input-group date" data-date-format="dd-mm-yyyy">
                <input class="form-control inp_bdr" maxlength="10" onchange="return changeDate(1);" type="text" id="dte_1_a"  runat="server" disabled="disabled"  />
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
              </div>
            </div> 
          </div>
        

          <div class="form-group fg2 fg2_wf">
            <label for="email" class="fg2_la1 pad_l">Set End Date:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch" onclick="dte_m()">
                    <asp:CheckBox ID="cbEdate" runat="server" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>

          <div class="form-group fg2 fg2_wf">
            <div class="tdte">
              <label for="pwd" class="fg2_la1">End Date:<span class="spn1"></span> </label>
              <div id="datepicker2" class="input-group date" data-date-format="dd-mm-yyyy">
                <input class="form-control inp_bdr" maxlength="10" onchange="return changeDate(1);" id="dte_1" type="text"  runat="server" disabled="disabled" />
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
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

  </div>
<!--Buttons_area_closed--->

       <div class="sub_cont pull-right">
           <div class="save_sec">
               <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" OnClientClick="return ValidateTables();" class="btn sub1" />
               <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return ValidateTables();" onclick="btnUpdate_Click" />
               <asp:Button ID="btnCancel" runat="server" class="btn sub4 notv" Text="Cancel" OnClientClick="return ConfirmMessage();" />
           </div>
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
   <div id="divList" runat="server" class="list_b" style="cursor: pointer;" onclick="return ConfirmMessage()" title="Back to List">
       <i class="fa fa-arrow-circle-left"></i>
   </div>
<!---back_button_fixed_section--->


<!----save_quick_actions_started--->
  <a id="btnFloat" href="javascript:;" onmouseover="opensave()" type="button" class="save_b" title="Save">
    <i class="fa fa-save"></i>
  </a>

<script>
    function opensave() {
        document.getElementById("mySave").style.width = "140px";
    }

    function closesave() {
        document.getElementById("mySave").style.width = "0px";
    }
</script>

  <div class="mySave1" id="mySave">
    <div class="save_sec">
         <asp:Button ID="btnUpdateFloat" runat="server" OnClick="btnUpdate_Click" Text="Update" OnClientClick="return ValidateTables();" class="btn sub1" />
         <asp:Button ID="btnUpdateCloseFloat" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return ValidateTables();" onclick="btnUpdate_Click" />
         <asp:Button ID="btnCancelFloat" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />
    </div>
  </div>
<!----save_quick_actions_closed--->


    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server" >
    </asp:ScriptManager>

  <script>
      function dte_m_1() {
          if (document.getElementById("cphMain_cbsdate").checked == true) {
              document.getElementById("cphMain_dte_1_a").disabled = true;
          } else {
              document.getElementById("cphMain_dte_1_a").disabled = true;
              document.getElementById("cphMain_dte_1_a").value = "";
          }
          document.getElementById("<%=dte_1_a.ClientID%>").style.borderColor = "";
          document.getElementById("<%=dte_1.ClientID%>").style.borderColor = "";
      }
      function dte_m() {
          if (document.getElementById("cphMain_cbEdate").checked == true) {
              document.getElementById("cphMain_dte_1").disabled = true;
          } else {
              document.getElementById("cphMain_dte_1").disabled = true;
              document.getElementById("cphMain_dte_1").value = "";
          }
          document.getElementById("<%=dte_1_a.ClientID%>").style.borderColor = "";
          document.getElementById("<%=dte_1.ClientID%>").style.borderColor = "";
      }

</script>
    <script>
        $('#cphMain_dte_1_a').datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            startDate: new Date(),
            timepicker: false
        });
        $('#cphMain_dte_1').datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            startDate: new Date(),
            timepicker: false
        });
 </script>
  
<!---select_popup_section_script--->
    
<link href="/css/New css/select2.min.css" rel="stylesheet" />
<script src="/js/New js/js/select2.min.js"></script>

<script type="text/javascript">
    $("#e1").select2();
    $("#checkbox").click(function () {
        if ($("#checkbox").is(':checked')) {
            $("#e1 > option").prop("selected", "selected");
            $("#e1").trigger("change");
        } else {
            $("#e1 > option").removeAttr("selected");
            $("#e1").trigger("change");
        }
    });
    $("#button1").click(function () {
        alert($("#e1").val());
    });
</script>
<!---select_popup_section_script_closed--->

<!---Start_date section--->

<!---closed_date section--->


<!----tree_jquery---->

<!-- <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script> -->
  <script type="text/javascript">
      $(function () {
          $('.tree li:has(ul)').addClass('parent_li').find(' > span').attr('title', 'Collapse this branch');
          $('.tree li.parent_li > span').on('click', function (e) {
              var children = $(this).parent('li.parent_li').find(' > ul > li');
              if (children.is(":visible")) {
                  children.hide('fast');
                  $(this).attr('title', 'Expand this branch').find(' > i').addClass('icon-plus-sign').removeClass('icon-minus-sign');
              } else {
                  children.show('fast');
                  $(this).attr('title', 'Collapse this branch').find(' > i').addClass('icon-minus-sign').removeClass('icon-plus-sign');
              }
              e.stopPropagation();
          });
      });
  </script>
<!----tree_jquery_closed---->

<!----tab_script_for heirarchy page---->
<script>
    function openCity(evt, cityName) {
        var i, tabcontent, tablinks;
        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }
        tablinks = document.getElementsByClassName("tablinks");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].className = tablinks[i].className.replace(" active", "");
        }
        document.getElementById(cityName).style.display = "block";
        evt.currentTarget.className += " active";
    }
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
               // AddNewRowMain(null, null);
            }
            if (document.getElementById("<%=HiddenFieldView.ClientID%>").value == "1") {
                $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select").prop("disabled", false);
            }
        });
    </script>
    <script>
        var RowNumMain = 0;

        function AddNewRowMain(dtlId, Name) {
            var FrecRow = '';
            var b = "";
            if ((document.getElementById("<%=HiddenFieldwrkId.ClientID%>").value) != "0") {
                b = "1";
            }
            else {
                b = "0";
            }

            FrecRow += '<tr id="mainRowId_' + RowNumMain + '" class="tr_act">';
            FrecRow += '<td style="display: none" >' + RowNumMain + '</td>';
            FrecRow += '<td id="dbId_' + RowNumMain + '" style="display: none" >' + dtlId + '</td>';

            FrecRow += '<td><input placeholder="-Select-" id="ddlDesgIdT_' + RowNumMain + '" onchange="return changeDesgMain(\'' + RowNumMain + '\');"  maxlength="100" onkeypress="return selectorToAutocompleteTextBox(' + RowNumMain + ',0);" onkeydown="return selectorToAutocompleteTextBox(' + RowNumMain + ',0);" onkeyup="return selectorToAutocompleteTextBox(' + RowNumMain + ',0);" type="text" class="form-control fg2_inp2"></td>';
            FrecRow += '<td style="display: none;"><input id="ddlDesgId_' + RowNumMain + '" value="-Select-"></td>';

            FrecRow += '<td><input placeholder="-Select-" id="ddlEmpIdT_' + RowNumMain + '" onchange="return changeEmpMain(\'' + RowNumMain + '\');"  maxlength="100" onkeypress="return selectorToAutocompleteTextBox(' + RowNumMain + ',1);" onkeydown="return selectorToAutocompleteTextBox(' + RowNumMain + ',1);" onkeyup="return selectorToAutocompleteTextBox(' + RowNumMain + ',1);" type="text" class="form-control fg2_inp2"></td>';
            FrecRow += '<td style="display: none;"><input id="ddlEmpId_' + RowNumMain + '" value="-Select-"></td>';


            FrecRow += '<td>';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxAprMand_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td>';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxSubstSts_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();" >';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';
            FrecRow += '<td>';
            FrecRow += '<div class="input-group ing2 dh_inp">';
            FrecRow += '<select id="ddlThresId_' + RowNumMain + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" onchange="IncrmntConfrmCounter();">';
            FrecRow += '<option value="0">Days</option>';
            FrecRow += '<option value="1">Hours</option>';
            FrecRow += '</select>';
            FrecRow += '</div>';
            FrecRow += '<div class="input-group ing1">';
            FrecRow += '<input id="txtPeriod_' + RowNumMain + '" onchange="return BlurNotNumber(\'txtPeriod_' + RowNumMain + '\')" maxlength="3" onkeydown="return isNumber(event)" onkeydown="return isNumber(event)" type="text" class="form-control fg2_inp2 tr_r">';
            FrecRow += '</div>';
            FrecRow += '</td>';

            FrecRow += '<td class="col_sp1">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxAprPen_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="col_sp1">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxTtcExc_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="col_sp2">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxSms_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td class="col_sp2">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxSys_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="td1">';
            FrecRow += '<div class="btn_stl1">';
            FrecRow += '<button id="btnAdd_' + RowNumMain + '" class="btn act_btn bn1 mainAdd" title="Add" disabled="disabled"><i class="fa fa-plus-circle" disabled="disabled"></i></button>';
            FrecRow += '<button id="btnDele_' + RowNumMain + '" disabled="disabled" class="btn act_btn bn3" title="Delete"><i class="fa fa-trash" disabled="disabled"></i></button>';


            if (dtlId != "" && dtlId != null && b == "0") {
                FrecRow += '<button id="btnOrg_' + RowNumMain + '" onclick="return FuctionOrganize(\'' + dtlId + '\',0,\'' + Name + '\');" class="btn act_btn bn8 organiser notv" title="Organiser"><i class="fa fa-sitemap"></i></button>';

            }
            else if (dtlId != "" && dtlId != null && b == "1") {
                FrecRow += '<button id="btnOrg_' + RowNumMain + '" onclick="return FuctionOrganize1(\'' + dtlId + '\',0,\'' + Name + '\');" class="btn act_btn bn8 organiser notv" title="Organiser"><i class="fa fa-sitemap"></i></button>';

            }
            else {
                FrecRow += '<button disabled id="btnOrg_' + RowNumMain + '" class="btn act_btn bn8 organiser" title="Organiser"><i class="fa fa-sitemap"></i></button>';
            }
            FrecRow += '</div>';
            FrecRow += '</td>';


            FrecRow += '</tr>';
            jQuery('#mainTable').append(FrecRow);
            if (dtlId == "null" || dtlId == null || dtlId == "") {
                document.getElementById("ddlDesgIdT_" + RowNumMain).focus();
            }
            $('.mainAdd').attr('disabled', 'disabled');
            var LastRowid = $("#mainTable tr:last td:first").html();
            document.getElementById("btnAdd_" + LastRowid).disabled = true;
            RowNumMain++;
            return false;
        }


        function EditListRows(DTLID, LEVEL, DESGID, EMPID, APPRVMANSTS, SUBEMPSTS, THRESMODE, PERIOD, APPRVPENSTS, TTCSTS, SMSSTS, SYSSTS, NAME, DESGNAME) {
            AddNewRowMain(DTLID, NAME);

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
                url: "gen_Document_Workflow.aspx/ReadSubtableDtls",
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

                                    EditListRowsSub(json[key].DTLID, json[key].LEVEL, json[key].DESGID, json[key].EMPID, json[key].APPRVMANSTS, json[key].SUBEMPSTS, json[key].THRESMODE, json[key].PERIOD, json[key].APPRVPENSTS, json[key].TTCSTS, json[key].SMSSTS, json[key].SYSSTS, json[key].SUBORDNUM, json[key].NAME, json[key].DESGNAME);

                                }
                            }
                        }




                    }
                    else {

                       // AddNewRowSub(null, null, 0, null);

                    }
                }

            });

            return false;
        }

        function FuctionOrganizef(DtlId, Level, Name) {
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
                url: "gen_Document_Workflow.aspx/ReadSubtableDtls",
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

                                    EditListRowsSub(json[key].DTLID, json[key].LEVEL, json[key].DESGID, json[key].EMPID, json[key].APPRVMANSTS, json[key].SUBEMPSTS, json[key].THRESMODE, json[key].PERIOD, json[key].APPRVPENSTS, json[key].TTCSTS, json[key].SMSSTS, json[key].SYSSTS, json[key].SUBORDNUM, json[key].NAME, json[key].DESGNAME);

                                }
                            }
                        }
                        subValidate(DtlId);



                    }
                    else {

                       // AddNewRowSub(null, null, 0, null);

                    }
                }

            });

            return false;
        }
        function FuctionOrganize1(DtlId, Level, Name) {
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
                url: "gen_Document_Workflow.aspx/ReadSubtableDOCDtls",
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
                                    EditListRowsSub(json[key].DTLID, json[key].LEVEL, json[key].DESGID, json[key].EMPID, json[key].APPRVMANSTS, json[key].SUBEMPSTS, json[key].THRESMODE, json[key].PERIOD, json[key].APPRVPENSTS, json[key].TTCSTS, json[key].SMSSTS, json[key].SYSSTS, json[key].SUBORDNUM, json[key].NAME, json[key].DESGNAME);

                                }
                            }
                        }



                    }
                    else {



                       // AddNewRowSub(null, null, 0, null);
                    }
                }

            });

            return false;
        }
        function selectorToAutocompleteTextBox(x, mode) {
            var $au = jQuery.noConflict();
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            if (corptID != '' && corptID != null && (!isNaN(corptID)) && orgID != '' && orgID != null && (!isNaN(orgID))) {

                if (mode == "0") {
                    $au("#ddlDesgIdT_" + x).autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: "gen_Document_Workflow.aspx/ReadDesgDdl",
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
                                    url: "gen_Document_Workflow.aspx/changeDesg",
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
                //AddNewRowMain(null, null);
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
                       // AddNewRowMain(null, null);
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

        function chanemp(RowNum) {

            document.getElementById("ddlEmpIdT_" + RowNum).style.borderColor = "";
            document.getElementById("ddlEmpIdT_" + RowNum).style.borderColor = "";

            document.getElementById("ddlEmpIdT_" + RowNum).value = document.getElementById("ddlEmpIdT1_").valu;

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
                    }
                }
                var Id = document.getElementById("<%=HiddenHrchyId.ClientID%>").value;
                if (Id != "" && Id != "0") {
                    var DtlId = 0;
                    if (document.getElementById("dbId_" + RowNum).innerHTML != "null" && document.getElementById("dbId_" + RowNum).innerHTML != "" && document.getElementById("dbId_" + RowNum).innerHTML != null) {
                        DtlId = document.getElementById("dbId_" + RowNum).innerHTML;
                    }

                    var CanclIds = "";
                    if (document.getElementById("cphMain_hiddenSubCanclDbId").value != "" && document.getElementById("cphMain_hiddenSubCanclDbId").value != null) {
                        CanclIds = document.getElementById("cphMain_hiddenSubCanclDbId").value;
                    }
                    if (CanclIds == "" && document.getElementById("cphMain_hiddenMainCanclDbId").value != "" && document.getElementById("cphMain_hiddenMainCanclDbId").value != null) {
                        CanclIds = document.getElementById("cphMain_hiddenMainCanclDbId").value;
                    }
                    else if (CanclIds != "" && document.getElementById("cphMain_hiddenMainCanclDbId").value != "" && document.getElementById("cphMain_hiddenMainCanclDbId").value != null) {
                        CanclIds = CanclIds + "," + document.getElementById("cphMain_hiddenMainCanclDbId").value;
                    }
                    CanclIds = CanclIds.trim().replace(/,/g, '-');
                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "gen_Document_Workflow.aspx/checkEmpDuplication",
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
            return ret;
        }

        function checkSubRow(RowNum) {
            var ret = true;

            var Savests = "1";

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


            if (ThresMode != "0" || SystemSts != "0" || TtcSts != "0" || SmsSts != "0" || AprvMandSts != "0" || subsEmpSts != "0" || AprvPendSts != "0" || Period != "" || EmpId != "-Select-" || DesgId != "-Select-" || Savests == "0") {

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
            document.getElementById("<%=dte_1_a.ClientID%>").style.borderColor = "";
            document.getElementById("<%=dte_1.ClientID%>").style.borderColor = "";
            var fromdate = document.getElementById("cphMain_dte_1_a").value;
            var toDate = document.getElementById("cphMain_dte_1").value;
            if (mode == "0") {
                if (document.getElementById("cphMain_cbsdate").checked == true && fromdate == "") {
                    document.getElementById("cphMain_dte_1_a").style.borderColor = "Red";
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    $(window).scrollTop(0);
                    ret = false;
                }
                if (document.getElementById("cphMain_cbEdate").checked == true && toDate == "") {
                    document.getElementById("cphMain_dte_1").style.borderColor = "Red";
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
                    document.getElementById("cphMain_dte_1_a").style.borderColor = "Red";
                    document.getElementById("cphMain_dte_1").style.borderColor = "Red";
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
            var Name2 = document.getElementById("<%=txtName.ClientID%>").value.trim();


            var dpt = document.getElementById("<%=lstDpt.ClientID%>");
            var divi = document.getElementById("<%=lstDiv.ClientID%>");
            var Name5 = document.getElementById("<%=HiddenHrchyname.ClientID%>").value;










            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];

            var tableOtherItem = document.getElementById("mainTable");
            var m = parseInt(tableOtherItem.rows.length) - 1;

            for (var a = m; a >= 0; a--) {
                var validRowID = (tableOtherItem.rows[a].cells[0].innerHTML);
                var as = parseInt(validRowID);

                if (checkMainRow(validRowID) == false) {
                    ret = false;
                }
                else {

                    var dtlId = (tableOtherItem.rows[a].cells[1].innerHTML);

                    var DesgId = document.getElementById("ddlDesgId_" + validRowID).value;
                    var EmpId = document.getElementById("ddlEmpId_" + validRowID).value;
                    var Name = document.getElementById("ddlEmpIdT_" + validRowID).value;

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
            if (Name2 == "") {
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=txtName.ClientID%>").focus();
                ret = false;
            }
            if (dpt.value == "") {

                document.getElementById("<%=lstDpt.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=lstDpt.ClientID%>").focus();
                ret = false;
            }
            if (divi.value == "") {

                document.getElementById("<%=lstDiv.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=lstDiv.ClientID%>").focus();
                ret = false;
            }
            if (Name5 == "") {
                document.getElementById("<%=HiddenHrchyname.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=HiddenHrchyname.ClientID%>").focus();
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




                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_Document_Workflow.aspx/checkDup",
                    data: '{Name2: "' + Name2 + '"}',
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


                FuctionOrganizef(dtlId, 0, Name);
            }
            return ret;

        }


        function ValidateTables() {

            var ret = true;
            var flag = 0;

            var MainTable = document.getElementById("mainTable");

            for (var x = 0; x < MainTable.rows.length; x++) {
                if (MainTable.rows[x].cells[0].innerHTML != "") {
                    var validRowID = (MainTable.rows[x].cells[0].innerHTML);

                    var Desgntn = document.getElementById("ddlDesgIdT_" + validRowID).value.trim();
                    var EmpId = document.getElementById("ddlEmpIdT_" + validRowID).value.trim();
                    var Period = document.getElementById("txtPeriod_" + validRowID).value.trim();

                    if (MainTable.rows.length > 0) {
                        if (CheckAndHighlightTables(validRowID) == false) {
                            ret = false;
                        }
                    }
                }
            }

            var SubTable = document.getElementById("subTable");

            if (SubTable.rows.length > 0) {
                for (var x = 0; x < SubTable.rows.length; x++) {
                    if (SubTable.rows[x].cells[0].innerHTML != "") {
                        var validRowID = (SubTable.rows[x].cells[0].innerHTML);

                        var Desgntn = document.getElementById("ddlDesgIdT_" + validRowID).value.trim();
                        var EmpId = document.getElementById("ddlEmpIdT_" + validRowID).value.trim();
                        var Period = document.getElementById("txtPeriod_" + validRowID).value.trim();

                        if (SubTable.rows.length > 0) {
                            if (CheckAndHighlightTables(validRowID) == false) {
                                ret = false;
                            }
                        }
                    }
                }
            }

            document.getElementById("<%=HiddenFieldSubData.ClientID%>").value = "";
            document.getElementById("<%=HiddenFieldMainData.ClientID%>").value = "";

    var tbClientValues = '';
    tbClientValues = [];

    if (ret == true) {

        //-----------------Main table--------------

        for (var x = 0; x < MainTable.rows.length; x++) {
            if (MainTable.rows[x].cells[0].innerHTML != "") {
                var validRowID = (MainTable.rows[x].cells[0].innerHTML);

                var Level = 0;
                var DesgntnId = document.getElementById("ddlDesgId_" + validRowID).value;
                var EmpId = document.getElementById("ddlEmpId_" + validRowID).value;
                var Threshold = document.getElementById("ddlThresId_" + validRowID).value;
                var Period = document.getElementById("txtPeriod_" + validRowID).value.trim();

                var ApprvlMndtry = 0;
                if (document.getElementById("cbxAprMand_" + validRowID).checked == true) {
                    ApprvlMndtry = 1;
                }
                var SubstuteEmp = 0;
                if (document.getElementById("cbxSubstSts_" + validRowID).checked == true) {
                    SubstuteEmp = 1;
                }
                var ApprvlPending = 0;
                if (document.getElementById("cbxAprPen_" + validRowID).checked == true) {
                    ApprvlPending = 1;
                }
                var TTCExceed = 0;
                if (document.getElementById("cbxTtcExc_" + validRowID).checked == true) {
                    TTCExceed = 1;
                }
                var SMS = 0;
                if (document.getElementById("cbxSms_" + validRowID).checked == true) {
                    SMS = 1;
                }
                var System = 0;
                if (document.getElementById("cbxSys_" + validRowID).checked == true) {
                    System = 1;
                }

                var ParentId = "";
                var DetailId = document.getElementById("dbId_" + validRowID).innerHTML;

                if (DesgntnId != "" && EmpId != "" && Period != "") {
                    var client = JSON.stringify({
                        ROWID: "" + validRowID + "",
                        LEVEL: "" + Level + "",
                        DESGID: "" + DesgntnId + "",
                        EMPID: "" + EmpId + "",
                        THRESMODE: "" + Threshold + "",
                        PERIOD: "" + Period + "",
                        APPRVMANSTS: "" + ApprvlMndtry + "",
                        SUBEMPSTS: "" + SubstuteEmp + "",
                        APPRVPENSTS: "" + ApprvlPending + "",
                        TTCSTS: "" + TTCExceed + "",
                        SMSSTS: "" + SMS + "",
                        SYSSTS: "" + System + "",
                        PARENT: "" + ParentId + "",
                        DTLID: "" + DetailId + "",
                    });
                    tbClientValues.push(client);
                }

            }
        }

        //alert("main: " + tbClientValues);

        document.getElementById("<%=HiddenFieldMainData.ClientID%>").value = JSON.stringify(tbClientValues);

                //-------------------Sub table----------------

                var tbClientSubValues = '';
                tbClientSubValues = [];

                var tbClientSubSelctdValues = '';
                tbClientSubSelctdValues = [];

                var HierchyRow = ""; var HierchyRowParentId = "";
                if (SubTable.rows.length == 0) {
                    //No Hierarchy selected
                }
                else {
                    //Hierarchy one level selected
                    HierchyRowParentId = document.getElementById("cphMain_HiddenFieldCurrentDtlId").value;

                    for (var x = 0; x < SubTable.rows.length; x++) {
                        if (SubTable.rows[x].cells[0].innerHTML != "") {
                            var validRowID = (SubTable.rows[x].cells[0].innerHTML);

                            var Level = document.getElementById("cphMain_HiddenFieldCurrentLevel").value;
                            var DesgntnId = document.getElementById("ddlDesgId_" + validRowID).value;
                            var EmpId = document.getElementById("ddlEmpId_" + validRowID).value;
                            var Threshold = document.getElementById("ddlThresId_" + validRowID).value;
                            var Period = document.getElementById("txtPeriod_" + validRowID).value;

                            var ApprvlMndtry = 0;
                            if (document.getElementById("cbxAprMand_" + validRowID).checked == true) {
                                ApprvlMndtry = 1;
                            }
                            var SubstuteEmp = 0;
                            if (document.getElementById("cbxSubstSts_" + validRowID).checked == true) {
                                SubstuteEmp = 1;
                            }
                            var ApprvlPending = 0;
                            if (document.getElementById("cbxAprPen_" + validRowID).checked == true) {
                                ApprvlPending = 1;
                            }
                            var TTCExceed = 0;
                            if (document.getElementById("cbxTtcExc_" + validRowID).checked == true) {
                                TTCExceed = 1;
                            }
                            var SMS = 0;
                            if (document.getElementById("cbxSms_" + validRowID).checked == true) {
                                SMS = 1;
                            }
                            var System = 0;
                            if (document.getElementById("cbxSys_" + validRowID).checked == true) {
                                System = 1;
                            }

                            var ParentId = document.getElementById("cphMain_HiddenFieldCurrentDtlId").value;
                            var DetailId = document.getElementById("dbId_" + validRowID).innerHTML;

                            if (DesgntnId != "" && EmpId != "" && Period != "") {
                                var client = JSON.stringify({
                                    ROWID: "" + validRowID + "",
                                    LEVEL: "" + Level + "",
                                    DESGID: "" + DesgntnId + "",
                                    EMPID: "" + EmpId + "",
                                    THRESMODE: "" + Threshold + "",
                                    PERIOD: "" + Period + "",
                                    APPRVMANSTS: "" + ApprvlMndtry + "",
                                    SUBEMPSTS: "" + SubstuteEmp + "",
                                    APPRVPENSTS: "" + ApprvlPending + "",
                                    TTCSTS: "" + TTCExceed + "",
                                    SMSSTS: "" + SMS + "",
                                    SYSSTS: "" + System + "",
                                    PARENT: "" + ParentId + "",//WrkflowId
                                    DTLID: "" + DetailId + "",//WrkflowId
                                });
                                tbClientSubValues.push(client);
                                tbClientSubSelctdValues.push(client);
                            }

                        }
                    }
                }

                //alert("HierchyRowParentId " + HierchyRowParentId);

                //alert("selected: " + tbClientSubSelctdValues);

                document.getElementById("<%=HiddenFieldSubData.ClientID%>").value = JSON.stringify(tbClientSubValues);

            }

            return ret;
        }

        function CheckAndHighlightTables(x) {

            var ret = true;

            document.getElementById("ddlDesgIdT_" + x).style.borderColor = "";
            document.getElementById("ddlEmpIdT_" + x).style.borderColor = "";
            document.getElementById("txtPeriod_" + x).style.borderColor = "";

            if (document.getElementById("txtPeriod_" + x).value.trim() == "") {
                document.getElementById("txtPeriod_" + x).style.borderColor = "Red";
                document.getElementById("txtPeriod_" + x).focus();
                ret = false;
            }
            if (document.getElementById("ddlEmpIdT_" + x).value.trim() == "") {
                document.getElementById("ddlEmpIdT_" + x).style.borderColor = "Red";
                document.getElementById("ddlEmpIdT_" + x).focus();
                ret = false;
            }
            if (document.getElementById("ddlDesgIdT_" + x).value.trim() == "") {
                document.getElementById("ddlDesgIdT_" + x).style.borderColor = "Red";
                document.getElementById("ddlDesgIdT_" + x).focus();
                ret = false;
            }

            //var Flag = 0;
            //if (ret == true) {
            //    if (CheckEmpDuplication(x, Table) == false) {
            //        Flag++;
            //        ret = false;
            //    }
            //}

            if (ret == false) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                ret = false;
            }

            return ret;
        }


        function mainValidateupd() {

            var ret = true;
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";
            var NameWithoutReplace = document.getElementById("<%=txtName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtName.ClientID%>").value = replaceText2;
            var Name2 = document.getElementById("<%=txtName.ClientID%>").value.trim();


            var dpt = document.getElementById("<%=lstDpt.ClientID%>");
            var divi = document.getElementById("<%=lstDiv.ClientID%>");
            var Name5 = document.getElementById("<%=HiddenHrchyname.ClientID%>").value;




            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];

            var tableOtherItem = document.getElementById("mainTable");
            var m = parseInt(tableOtherItem.rows.length) - 1;

            for (var a = m; a >= 0; a--) {
                var validRowID = (tableOtherItem.rows[a].cells[0].innerHTML);
                var as = parseInt(validRowID);

                if (checkMainRow(validRowID) == false) {

                    ret = false;
                }
                else {

                    var dtlId = (tableOtherItem.rows[a].cells[1].innerHTML);

                    var DesgId = document.getElementById("ddlDesgId_" + validRowID).value;
                    var EmpId = document.getElementById("ddlEmpId_" + validRowID).value;
                    var Name = document.getElementById("ddlEmpIdT_" + validRowID).value;

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
                    $add("#cphMain_HiddenFieldMainData").val(JSON.stringify(tbClientJobSheduling));
                    if (document.getElementById("cphMain_HiddenFieldCurrentDtlId").value == dtlId) {

                        subValidateupd();

                    }

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
            if (Name2 == "") {
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=txtName.ClientID%>").focus();
                ret = false;
            }
            if (dpt.value == "") {

                document.getElementById("<%=lstDpt.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=lstDpt.ClientID%>").focus();
                ret = false;
            }
            if (divi.value == "") {

                document.getElementById("<%=lstDiv.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=lstDiv.ClientID%>").focus();
                ret = false;
            }
            if (Name5 == "") {
                document.getElementById("<%=HiddenHrchyname.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=HiddenHrchyname.ClientID%>").focus();
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




                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    //url: "gen_Document_Workflow.aspx/checkDup",
                    data: '{Name2: "' + Name2 + '"}',
                    dataType: "json",
                    success: function (data) {

                        if (data.d == "dup") {

                            DupName();
                            ret = false;
                        }
                    }
                });
            }


            return ret;
        }
        function subValidate(DtlId) {
            var ret = true;
            var tbClientJobSheduling1 = '';
            tbClientJobSheduling1 = [];
            var tableOtherItem = document.getElementById("subTable");
            var m1 = parseInt(tableOtherItem.rows.length) - 1;

            for (var a1 = m1; a1 >= 0; a1--) {

                var validRowID = (tableOtherItem.rows[a1].cells[0].innerHTML);

                if (checkSubRow(validRowID) == false) {

                    ret = false;
                }
                else {
                    document.getElementById("cphMain_HiddenFieldCurrentDtlId").value = DtlId;

                    var dtlId = (tableOtherItem.rows[a1].cells[1].innerHTML);

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
                    var level = parseInt(document.getElementById("cphMain_HiddenFieldCurrentLevel").value) + 1;
                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        DL: "" + DtlId + "",
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
                    if (document.getElementById("<%=HiddenSubTable.ClientID%>").value == "") {
                        document.getElementById("<%=HiddenSubTable.ClientID%>").value = client;
                    }
                    else {
                        document.getElementById("<%=HiddenSubTable.ClientID%>").value = document.getElementById("<%=HiddenSubTable.ClientID%>").value + "," + client;
                    }

                    tbClientJobSheduling1.push(document.getElementById("<%=HiddenSubTable.ClientID%>").value);

                    $add("#cphMain_HiddenFieldSubData").val(JSON.stringify(tbClientJobSheduling1));

                }
            }

            if (ret == false) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }

            return ret;
        }


        function subValidateupd() {
            var ret = true;
            var tbClientJobSheduling1 = '';
            tbClientJobSheduling1 = [];
            var tableOtherItem = document.getElementById("subTable");
            var m1 = parseInt(tableOtherItem.rows.length) - 1;
            for (var a1 = m1; a1 >= 0; a1--) {

                var validRowID = (tableOtherItem.rows[a1].cells[0].innerHTML);

                if (checkSubRow(validRowID) == false) {

                    ret = false;
                }
                else {


                    var dtlId = (tableOtherItem.rows[a1].cells[1].innerHTML);

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
                    var level = parseInt(document.getElementById("cphMain_HiddenFieldCurrentLevel").value) + 1;
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


                    tbClientJobSheduling1.push(client);




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
                $add("#cphMain_HiddenFieldSubData").val(JSON.stringify(tbClientJobSheduling1));
            }
            return ret;
        }


        function AddNewRowSub(DtlId, Level, SubordNum, Name) {
            var FrecRow = '';

            FrecRow += '<tr id="mainRowId_' + RowNumMain + '" class="">';
            FrecRow += '<td style="display: none" >' + RowNumMain + '</td>';
            FrecRow += '<td id="dbId_' + RowNumMain + '" style="display: none" >' + DtlId + '</td>';

            FrecRow += '<td><input placeholder="-Select-" id="ddlDesgIdT_' + RowNumMain + '" onchange="return changeDesgMain(\'' + RowNumMain + '\');"  maxlength="100" onkeypress="return selectorToAutocompleteTextBox(' + RowNumMain + ',0);" onkeydown="return selectorToAutocompleteTextBox(' + RowNumMain + ',0);" onkeyup="return selectorToAutocompleteTextBox(' + RowNumMain + ',0);" type="text" class="form-control fg2_inp2"></td>';
            FrecRow += '<td style="display: none;"><input id="ddlDesgId_' + RowNumMain + '" value="-Select-"></td>';

            FrecRow += '<td><input placeholder="-Select-" id="ddlEmpIdT_' + RowNumMain + '" onchange="return changeEmpMain(\'' + RowNumMain + '\');"  maxlength="100" onkeypress="return selectorToAutocompleteTextBox(' + RowNumMain + ',1);" onkeydown="return selectorToAutocompleteTextBox(' + RowNumMain + ',1);" onkeyup="return selectorToAutocompleteTextBox(' + RowNumMain + ',1);" type="text" class="form-control fg2_inp2"></td>';
            FrecRow += '<td style="display: none;"><input id="ddlEmpId_' + RowNumMain + '" value="-Select-"></td>';

            FrecRow += '<td>';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxAprMand_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td id="tdNumsubord_' + RowNumMain + '">' + SubordNum + '</td>';
            FrecRow += '<td>';
            if (SubordNum != "0" && SubordNum != null && SubordNum != "") {
                FrecRow += '<button id="btnSubord_' + RowNumMain + '" onclick="return FuctionOrganize1(\'' + DtlId + '\',\'' + Level + '\',\'' + Name + '\');" class="btn act_btn bn6 notv" title="Subordinates"><i class="fa fa-cloud-download" aria-hidden="true"></i></button>';
            }
            else {
                FrecRow += '<button disabled id="btnSubord_' + RowNumMain + '" class="btn act_btn bn6" title="Subordinates"><i class="fa fa-cloud-download" aria-hidden="true"></i></button>';
            }
            FrecRow += '</td>';
            FrecRow += '<td>';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxSubstSts_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td>';
            FrecRow += '<div class="input-group ing2 dh_inp">';
            FrecRow += '<select id="ddlThresId_' + RowNumMain + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" onchange="IncrmntConfrmCounter();">';
            FrecRow += '<option value="0">Days</option>';
            FrecRow += '<option value="1">Hours</option>';
            FrecRow += '</select>';
            FrecRow += '</div>';
            FrecRow += '<div class="input-group ing1">';
            FrecRow += '<input id="txtPeriod_' + RowNumMain + '" onchange="return BlurNotNumber(\'txtPeriod_' + RowNumMain + '\')" maxlength="3" onkeydown="return isNumber(event)" onkeydown="return isNumber(event)" type="text" class="form-control fg2_inp2 tr_r" >';
            FrecRow += '</div>';
            FrecRow += '</td>';

            FrecRow += '<td class="col_sp1">';
            FrecRow += '<div class="check1 swt"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxAprPen_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td class="col_sp1">';
            FrecRow += '<div class="check1 swt"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxTtcExc_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td class="col_sp2">';
            FrecRow += '<div class="check1 swt"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxSms_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td class="col_sp2">';
            FrecRow += '<div class="check1 swt"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxSys_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td class="td1">';
            FrecRow += '<div class="btn_stl1">';
            FrecRow += '<button id="btnAdd_' + RowNumMain + '" onclick="return FuctionAddSub(\'' + RowNumMain + '\');" class="btn act_btn bn1 subAdd" title="Add" disabled="disabled"><i class="fa fa-plus-circle" disabled="disabled"></i></button>';
            FrecRow += '<button id="btnDele_' + RowNumMain + '"  class="btn act_btn bn3" title="Delete" disabled="disabled"><i class="fa fa-trash" disabled="disabled"></i></button>';
            FrecRow += '</div>';
            FrecRow += '</td>';

            FrecRow += '</tr>';

            jQuery('#subTable').append(FrecRow);

            document.getElementById("ddlDesgIdT_" + RowNumMain).focus();

            $('.subAdd').attr('disabled', 'disabled');
            var LastRowid = $("#subTable tr:last td:first").html();
            document.getElementById("btnAdd_" + LastRowid).disabled = true;
            RowNumMain++;
            return false;
        }
        function EditListRowsSub(DTLID, LEVEL, DESGID, EMPID, APPRVMANSTS, SUBEMPSTS, THRESMODE, PERIOD, APPRVPENSTS, TTCSTS, SMSSTS, SYSSTS, SUBORDNUM, NAME, DESGNAME) {
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
               // AddNewRowSub(null, null, 0, null);
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
                       // AddNewRowSub(null, null, 0, null);
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
            $("#success-alert").html("Document Workflow details inserted successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpd() {
            $("#success-alert").html("Docuemt Workflow details updated successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessCnfm() {
            $("#success-alert").html("Docuemt Workflow details Confirm successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function DupName() {
            $("#divWarning").html("Duplication Error!.Document name can’t be duplicated.");
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
                        window.location.href = "gen_Document_Workflow_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "gen_Document_Workflow_List.aspx";
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
                        window.location.href = "gen_Document_Workflow.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "gen_Document_Workflow.aspx";
                return false;
            }
            return false;
        }
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
            return false;
        }


    </script>
     <script>
         $noCon = jQuery.noConflict();
         $noCon2 = jQuery.noConflict();
         $noCon(function () {
             //Initialize Select2 Elements
             $noCon2(".select2").select2();

             //  checkclickedradio();
             document.getElementById("<%=lstDpt.ClientID%>").style.borderColor = "red";


         });
    </script>

    <style>
        .open > .dropdown-menu {
            display: none;
            border-color:red;
        }
    </style>

    <style>
        .select2-container--default .select2-selection--multiple .select2-selection__choice {
            background-color: #a5a5a5;
            border-color: red;
            padding: 1px 5px;
            color: black;
            font-size: 14px;
            margin: 2px;
            max-width: 260px;
            font-family: Calibri;
        }

        .select2-container--default .select2-selection--multiple .select2-selection__choice__remove {
            color: #fff;
            cursor: pointer;
            display: inline-block;
            font-weight: bold;
            margin-right: 5px;
        }

        .select2-container--default.select2-container--focus .select2-selection--multiple {
            border: solid #aeaeae 1px;
            outline: 0;
        }

        .select2-results__option[aria-selected] {
            cursor: pointer;
            font-size: small;
            font-family: calibri;
        }
            .select2-search__field {
            font-family: Calibri;

        }
    </style>
    <!---<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>   
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />  
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>  
    <script type="text/javascript">
        $(function () {
            $('[id*=lstDpt]').multiselect({
                includeSelectAllOption: true
            });
        });
    </script>  
    <style type="text/css">
    .multiselect-container > li > a > label.checkbox
    {
        width: 850px;
    }
    .btn-group > .btn:first-child
    {
        width: 850px;
    }
</style>--->
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
       
                 

                  
           