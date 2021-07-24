<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Document_Workflow.aspx.cs" Inherits="Master_gen_Document_Workflow_gen_Document_Workflow" %>
  

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
  <asp:HiddenField ID="HiddenDumpsub" runat="server" />
  <asp:HiddenField ID="HiddenFieldCurrentDtlId" runat="server" Value="0" /> 
  <asp:HiddenField ID="HiddenFieldCurrentLevel" runat="server" Value="0" /> 
  <asp:HiddenField ID="HiddenFieldView" runat="server" value="0"/>
  <asp:HiddenField ID="HiddenHrchyId" runat="server" />
  <asp:HiddenField ID="HiddenEdit" runat="server"/>
  <asp:HiddenField ID="HiddenHrchyname" runat="server" />
  <asp:HiddenField ID="HiddenWrkname" runat="server" />
  <asp:HiddenField ID="HiddenWrkParentId" runat="server" />
  <asp:HiddenField ID="Hiddenview" runat="server" Value="0" />
  <asp:HiddenField ID="HiddenFieldReopen" runat="server" Value="0"/>
  <asp:HiddenField ID="HiddenReopen" runat="server" Value="0" />
  <asp:HiddenField ID="Hiddenhrytest" runat="server" />
  <asp:HiddenField ID="Hiddensubsub" runat="server" />
  <asp:HiddenField ID="Hiddentrailrow" runat="server" />
  <asp:HiddenField ID="Hiddentrail3" runat="server" />
  <asp:HiddenField ID="Hiddentrailvalue" runat="server" />
  <asp:HiddenField ID="Hiddentrial" runat="server" />
  <asp:HiddenField ID="Hiddentrail2" runat="server" />
  <asp:HiddenField ID="Hiddenmaintable" runat="server" />
  <asp:HiddenField ID="HiddenSubTable" runat="server" />
  <asp:HiddenField ID="HiddenSun" runat="server"/>
  <asp:HiddenField ID="hiddenEditMode" runat="server"/>
  <asp:HiddenField ID="hiddenHrchyChngdMode" runat="server"/>

     <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>


    <!---breadcrumb_section_started---->    
    <ol class="breadcrumb">
      <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
      <li><a href="gen_Document_Workflow_List.aspx">Document Workflow</a></li>
      <li class="active">Add Document Workflow</li>
    </ol>
<!---breadcrumb_section_started----> 


    <div class="content_sec2 cont_contr" id="sd" runat="server">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con" id="lblEntry" runat="server">Add Document Workflow</h1>

          <div class="form-group fg2 fg2_wf">
            <label for="email" class="fg2_la1">Document Name:<span class="spn1">*</span></label>
              <asp:TextBox ID="txtName"  class="form-control fg2_inp1 fg_chs1 inp_mst" placeholder="Document Name" runat="server" MaxLength="100"></asp:TextBox>
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
              <asp:TextBox ID="txtDescr" class="form-control fg2_inp1 fg_chs1" runat="server" TextMode="MultiLine" Height="100px" onblur="RemoveTag('cphMain_txtDescr')" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtDescr,450)" onkeyup="textCounter(cphMain_txtDescr,450)" style="resize: none;"></asp:TextBox>
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
              <asp:ListBox ID="lstDiv" class="form-control select2 clslstDiv" multiple="multiple" runat="server" SelectionMode="Multiple"></asp:ListBox>      
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

            <script>
                var $au = jQuery.noConflict();
                $au(function () {
                    $au("#cphMain_dlHrchy").selectToAutocomplete1Letter();
                });
            </script>

         <div class="form-group fg2 fg2_wf" style="display: none" >
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
                    <asp:CheckBox ID="cbxaprpnd" runat="server" onclick="checkednot()" />
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
                    <asp:CheckBox ID="cbxTmExd" runat="server" onclick="checkedtm()"/>
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
                    <asp:CheckBox ID="cbxsm" runat="server" onclick="checkedsms()" />
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
                    <asp:CheckBox ID="cbxnt" runat="server" onclick="checkedsts()" />
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


        <div class="fg2 fg2_wf" id="dlhr" runat="server">
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
                <input class="form-control inp_bdr" disabled="disabled" maxlength="10" onchange="return changeDate(1);" type="text" id="dte_1_a"  runat="server"  />
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



        <!--Buttons_Area_started--->
         <!--- <div class="sub_cont pull-right">
            <div class="save_sec">

                <asp:Button ID="btnUpdateS" value="btnUpdateS" runat="server" class="btn sub1" Text="Update" OnClientClick="return subValidate();" onclick="btnUpdateS_Click" />
                <asp:Button ID="btnCancelS" runat="server" class="btn sub4 notv" Text="Cancel" OnClientClick="return ConfirmMessageSub();"/>
            </div>
         </div>--->
  </div>
<!--Buttons_area_closed--->

       <div class="sub_cont pull-right">
            <div class="save_sec">
                
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" OnClientClick="return ValidateWrkFlow();" class="btn sub1"/>
                <asp:Button ID="btnsaveclose" runat="server" OnClick="btnSave_Click" Text="Save & Close" OnClientClick="return ValidateWrkFlow();" class="btn sub3"/>
                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" OnClientClick="return ValidateWrkFlow();" class="btn sub1" Visible="False"/>
                <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return ValidateWrkFlow();" onclick="btnUpdate_Click" Visible="false" />
                <asp:Button ID="btnCnfrm1" runat="server" Text="Confirm" class="btn sub2"   OnClientClick="return ConfirmAlert();"  Visible="false" />
                <asp:Button ID="btnReopen1" runat="server" Text="Reopen"  class="btn sub3 notv" OnClientClick="return ConfirmReopen();" Enabled="true"/>
                <asp:Button ID="btnCancel" runat="server" class="btn sub4 notv" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                <asp:Button ID="btnClear" runat="server" class="btn sub2" Text="Clear" OnClientClick="return AlertClearAll();"  />

                <asp:Button ID="btnCnfrm" runat="server" Text="Confirm" class="btn sub2" OnClick="btnCnfrm_Click" style="display:none" />
                <asp:Button ID="btnReopen" runat="server" Text="Reopen"  class="btn sub3 notv" OnClick="btnReopen_Click" style="display:none"/>
                <asp:Button ID="btnReUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" class="btn sub1" Visible="False"/>
                <asp:Button ID="btnEcnfrm" runat="server" OnClick="btnEcnfrm_Click" Text="Confirm" class="btn sub1 bt_b" Visible="False"/>

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
        <asp:Button ID="btnSaveFloat" runat="server" OnClick="btnSave_Click" Text="Save" OnClientClick="return ValidateWrkFlow();" class="btn sub1"/>
        <asp:Button ID="btnsavecloseFloat" runat="server" OnClick="btnSave_Click" Text="Save & Close" OnClientClick="return ValidateWrkFlow();" class="btn sub3"/>
        <asp:Button ID="btnUpdateFloat" runat="server" OnClick="btnUpdate_Click" Text="Update" OnClientClick="return ValidateWrkFlow();" class="btn sub1" Visible="False"/>
        <asp:Button ID="btnUpdateCloseFloat" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return ValidateWrkFlow();" onclick="btnUpdate_Click" Visible="false" />
        <asp:Button ID="btnCnfrm1Float" runat="server" Text="Confirm" class="btn sub2"   OnClientClick="return ConfirmAlert();"  Visible="false" />
        <asp:Button ID="btnReopen1Float" runat="server" Text="Reopen"  class="btn sub3" OnClientClick="return ConfirmReopen();" Enabled="true"/>
        <asp:Button ID="btnCancelFloat" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />
        <asp:Button ID="btnClearFloat" runat="server" class="btn sub2" Text="Clear" OnClientClick="return AlertClearAll();"  />
    </div>
  </div>
<!----save_quick_actions_closed--->

   
  <script>
      function dte_m_1() {
          if (document.getElementById("cphMain_cbsdate").checked == true) {
              document.getElementById("cphMain_dte_1_a").disabled = false;
          } else {
              document.getElementById("cphMain_dte_1_a").disabled = true;
              document.getElementById("cphMain_dte_1_a").value = "";
          }
          document.getElementById("<%=dte_1_a.ClientID%>").style.borderColor = "";
          document.getElementById("<%=dte_1.ClientID%>").style.borderColor = "";
          if (document.getElementById("<%=Hiddenview.ClientID%>").value == "1") {
              document.getElementById("cphMain_dte_1_a").disabled = true;
          }
          if (document.getElementById("<%=HiddenReopen.ClientID%>").value == "1") {
              document.getElementById("cphMain_dte_1_a").disabled = true;
          }
      }
      function dte_m() {
          if (document.getElementById("cphMain_cbEdate").checked == true) {
              document.getElementById("cphMain_dte_1").disabled = false;
          } else {
              document.getElementById("cphMain_dte_1").disabled = true;
              document.getElementById("cphMain_dte_1").value = "";
          }
          document.getElementById("<%=dte_1_a.ClientID%>").style.borderColor = "";
          document.getElementById("<%=dte_1.ClientID%>").style.borderColor = "";
          if (document.getElementById("<%=Hiddenview.ClientID%>").value == "1") {
              document.getElementById("cphMain_dte_1").disabled = true;
          }
          if (document.getElementById("<%=HiddenReopen.ClientID%>").value == "1") {
              document.getElementById("cphMain_dte_1").disabled = true;
          }
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
     
    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            var EditVal = document.getElementById("<%=HiddenEdit.ClientID%>").value;
            var EditSub = document.getElementById("<%=HiddenSun.ClientID%>").value;
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

                            EditListRows(json[key].DTLID, json[key].TRAIL, json[key].LEVEL, json[key].DESGID, json[key].EMPID, json[key].APPRVMANSTS, json[key].SUBEMPSTS, json[key].THRESMODE, json[key].PERIOD, json[key].APPRVPENSTS, json[key].TTCSTS, json[key].SMSSTS, json[key].SYSSTS, json[key].NAME, json[key].DESGNAME, json[key].PARENT);

                        }
                    }
                }
            }
            else {
                AddNewRowMain(null, null, null, null);
            }

            if (document.getElementById("<%=Hiddenview.ClientID%>").value == "1") {
                $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select").prop("disabled", true);
            }
        });
    </script>
    <script>
        var RowNumMain = 0;
      //  var trail = 0;
        function AddNewRowMain(dtlId,trail, Name,PARENT) {
            var FrecRow = '';
            var b = "";
           
            if ((document.getElementById("<%=HiddenFieldwrkId.ClientID%>").value) != "0") {
                b = "1";
            }
            else {
                b = "0";
            }
           // trail = RowNumMain;
            FrecRow += '<tr id="mainRowId_' + RowNumMain + '" class="tr_act">';
            FrecRow += '<td style="display: none"  >' + RowNumMain + '</td>';
         
            FrecRow += '<td id="dbId_' + RowNumMain + '" style="display: none" >' + dtlId + '</td>';
            FrecRow += '<td id="trail_' + RowNumMain + '" style="display: none" >'+trail+'</td>';
          
          
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
            if (document.getElementById("<%=cbxaprpnd.ClientID%>").checked == true) {
                FrecRow += '<input id="cbxAprPen_' + RowNumMain + '" type="checkbox" checked="true" onchange="IncrmntConfrmCounter();">';
            }
            else {
                FrecRow += '<input id="cbxAprPen_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            }
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="col_sp1">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            if (document.getElementById("<%=cbxTmExd.ClientID%>").checked == true) {
                FrecRow += '<input id="cbxTtcExc_' + RowNumMain + '" type="checkbox" checked="true" onchange="IncrmntConfrmCounter();">';
            }
            else {
                FrecRow += '<input id="cbxTtcExc_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            }
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="col_sp2">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            if (document.getElementById("<%=cbxsm.ClientID%>").checked == true) {
                FrecRow += '<input id="cbxSms_' + RowNumMain + '" type="checkbox" checked=="true" onchange="IncrmntConfrmCounter();">';
            }
            else {
                FrecRow += '<input id="cbxSms_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            }
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td class="col_sp2">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            if (document.getElementById("<%=cbxnt.ClientID%>").checked == true) {
                FrecRow += '<input id="cbxSys_' + RowNumMain + '" type="checkbox" checked="true" onchange="IncrmntConfrmCounter();">';
            }
            else {
                FrecRow += '<input id="cbxSys_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            }
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="td1">';
            FrecRow += '<div class="btn_stl1">';

            //if (b != "0") {
                FrecRow += '<button id="btnAdd_' + RowNumMain + '" onclick="return FuctionAddMain(\'' + RowNumMain + '\');" class="btn act_btn bn1 mainAdd" title="Add"><i class="fa fa-plus-circle"></i></button>';
                FrecRow += '<button id="btnDele_' + RowNumMain + '" Onclick="return FuctionDeleMain(\'' + RowNumMain + '\');" class="btn act_btn bn3" title="Delete"><i class="fa fa-trash"></i></button>';
            //}
            //else {
            //    FrecRow += '<button disabled id="btnAdd_' + RowNumMain + '" onclick="return FuctionAddMain(\'' + RowNumMain + '\');" class="btn act_btn bn1 mainAdd" title="Add"><i class="fa fa-plus-circle"></i></button>';
            //    FrecRow += '<button disabled id="btnDele_' + RowNumMain + '" Onclick="return FuctionDeleMain(\'' + RowNumMain + '\');" class="btn act_btn bn3" title="Delete"><i class="fa fa-trash"></i></button>';
            //}

            if (dtlId != "" && dtlId != null && b == "0" && PARENT!="0") {
              
                FrecRow += '<button id="btnOrg_' + RowNumMain + '" onclick="return FuctionOrganize(\'' + dtlId + '\',0,\'' + Name + '\',\''+trail+'\');" class="btn act_btn bn8 organiser notv" title="Organiser"><i class="fa fa-sitemap"></i></button>';

            }
            else if (dtlId != "" && dtlId != null && b == "1") {
                
                FrecRow += '<button id="btnOrg_' + RowNumMain + '" onclick="return FuctionOrganize1(\'' + dtlId + '\',0,\'' + Name + '\',\''+trail+'\');" class="btn act_btn bn8 organiser notv" title="Organiser"><i class="fa fa-sitemap"></i></button>';

            }
            else if (dtlId != "" && dtlId != null && b == "0" && PARENT=="0") {
               
                FrecRow += '<button disabled id="btnOrg_' + RowNumMain + '" class="btn act_btn bn8 organiser" title="Organiser"><i class="fa fa-sitemap"></i></button>';
               
            }
            FrecRow += '</div>';
            FrecRow += '</td>';


            FrecRow += '</tr>';
            jQuery('#mainTable').append(FrecRow);
            if (dtlId == "null" || dtlId == null || dtlId == "") {
               // document.getElementById("ddlDesgIdT_" + RowNumMain).focus();
            }
            $('.mainAdd').attr('disabled', 'disabled');
            var LastRowid = $("#mainTable tr:last td:first").html();
            //if (b != "0") {
                document.getElementById("btnAdd_" + LastRowid).disabled = false;
            //}
            //else {
            //    document.getElementById("btnAdd_" + LastRowid).disabled = true;
            //}
            RowNumMain++;
            return false;
        }


        function EditListRows(DTLID,TRAIL, LEVEL, DESGID, EMPID, APPRVMANSTS, SUBEMPSTS, THRESMODE, PERIOD, APPRVPENSTS, TTCSTS, SMSSTS, SYSSTS, NAME, DESGNAME,PARENT) {
            AddNewRowMain(DTLID,TRAIL, NAME,PARENT);
            
            var validRowID = RowNumMain - 1;

            document.getElementById("dbId_" + validRowID).innerHTML = DTLID;
            document.getElementById("trail_" + validRowID).innerHTML =TRAIL;
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
        function FuctionOrganize(DtlId, Level, Name,trail) {
            document.getElementById("headTree").innerHTML = Name;
            $(".hire").show();
            $("#subTable").empty();
            
            document.getElementById("cphMain_hiddenSubCanclDbId").value = "";
            document.getElementById("cphMain_HiddenFieldCurrentDtlId").value = DtlId;
            document.getElementById("cphMain_HiddenFieldCurrentLevel").value = Level;
            document.getElementById("cphMain_Hiddentrailvalue").value = trail;
          
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

                                    EditListRowsSub(json[key].DTLID,json[key].TRIAL, json[key].LEVEL, json[key].DESGID, json[key].EMPID, json[key].APPRVMANSTS, json[key].SUBEMPSTS, json[key].THRESMODE, json[key].PERIOD, json[key].APPRVPENSTS, json[key].TTCSTS, json[key].SMSSTS, json[key].SYSSTS, json[key].SUBORDNUM, json[key].NAME, json[key].DESGNAME,json[key].RO);

                                }
                            }
                        }
                    }
                    else {

                        AddNewRowSub(null,null, null, 0, null);

                    }
                }

            });
            if (document.getElementById("<%=Hiddenview.ClientID%>").value == "1") {
                $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select").prop("disabled", true);
                
            }
            return false;
        }

        function FuctionOrganizef(DtlId, Level, Name,trail) {
           
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
                data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",DtlId: "' + DtlId + '",trail:"'+trail+'"}',
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
                                    
                                    EditListRowsSub(json[key].DTLID, json[key].TRIAL, json[key].LEVEL, json[key].DESGID, json[key].EMPID, json[key].APPRVMANSTS, json[key].SUBEMPSTS, json[key].THRESMODE, json[key].PERIOD, json[key].APPRVPENSTS, json[key].TTCSTS, json[key].SMSSTS, json[key].SYSSTS, json[key].SUBORDNUM, json[key].NAME, json[key].DESGNAME);   
                                }
                            }
                        }
                        subValidate(DtlId);
                    }
                    else {

                        AddNewRowSub(null,trail, null, 0, null);

                    }
                }

            });
            if (document.getElementById("<%=Hiddenview.ClientID%>").value == "1") {
                $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select").prop("disabled", true);
              
            }
            return false;
        }
        function FuctionOrganize1(DtlId, Level, Name, trail) {
            document.getElementById("headTree").innerHTML = Name;
            $(".hire").show();
            $("#subTable").empty();

            document.getElementById("cphMain_hiddenSubCanclDbId").value = "";
            document.getElementById("cphMain_HiddenFieldCurrentDtlId").value = DtlId;
            document.getElementById("cphMain_HiddenFieldCurrentLevel").value = Level;
            document.getElementById("cphMain_Hiddentrailvalue").value = trail;
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

                                    EditListRowsSub(json[key].DTLID, json[key].TRIAL, json[key].LEVEL, json[key].DESGID, json[key].EMPID, json[key].APPRVMANSTS, json[key].SUBEMPSTS, json[key].THRESMODE, json[key].PERIOD, json[key].APPRVPENSTS, json[key].TTCSTS, json[key].SMSSTS, json[key].SYSSTS, json[key].SUBORDNUM, json[key].NAME, json[key].DESGNAME);

                                }
                            }
                        }
                    }
                    else {
                        AddNewRowSub(null, trail, null, 0, null);
                    }
                }

            });
            if (document.getElementById("<%=Hiddenview.ClientID%>").value == "1") {
                $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select").prop("disabled", true);
            }
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

        function checkednot() {
            var RowNum = RowNumMain - 1;
            //alert(RowNum);
            for (var i = 0; i <= RowNum; i++) {
                if (document.getElementById("<%=cbxaprpnd.ClientID%>").checked == true) {
                    document.getElementById("cbxAprPen_" + i).checked = true;

                }
                if (document.getElementById("<%=cbxaprpnd.ClientID%>").checked == false) {
                    document.getElementById("cbxAprPen_" +i).checked = false;

                }

            }
        }
        
        function checkedtm() {
            var RowNum = RowNumMain - 1;
            //alert(RowNum);
            for (var i = 0; i <= RowNum; i++) {
                if (document.getElementById("<%=cbxTmExd.ClientID%>").checked == true) {
                    document.getElementById("cbxTtcExc_" + i).checked = true;

                }
                if (document.getElementById("<%=cbxTmExd.ClientID%>").checked == false) {
                    document.getElementById("cbxTtcExc_" + i).checked = false;

                }

            }
        }
       
        function checkedsms() {
            var RowNum = RowNumMain - 1;
            //alert(RowNum);
            for (var i = 0; i <= RowNum; i++) {
                if (document.getElementById("<%=cbxsm.ClientID%>").checked == true) {
                    document.getElementById("cbxSms_" + i).checked = true;

                }
                if (document.getElementById("<%=cbxsm.ClientID%>").checked == false) {
                    document.getElementById("cbxSms_" + i).checked = false;

                }

            }
        }
        function checkedsts() {
            var RowNum = RowNumMain - 1;
            //alert(RowNum);
            for (var i = 0; i <= RowNum; i++) {
                if (document.getElementById("<%=cbxnt.ClientID%>").checked == true) {
                    document.getElementById("cbxSys_" + i).checked = true;

                }
                if (document.getElementById("<%=cbxnt.ClientID%>").checked == false) {
                    document.getElementById("cbxSys_" + i).checked = false;

                }

            }
        }
        function FuctionAddMain(RowNum) {
            if (checkMainRow(RowNum) == true) {
                IncrmntConfrmCounter();
                AddNewRowMain(null, null, null, null);
                //var FocusId = parseInt(RowNum) + 1;
                //document.getElementById("ddlDesgIdT_" + FocusId).focus();
            }
            return false;
        }

        
        function ConfirmAlert() {
            if (ValidateWrkFlow() == false) {
                return false;
            }
            else {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to confirm this Document workflow?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        document.getElementById("<%=btnCnfrm.ClientID%>").click();
                    }
                });
            }
            return false;
        }

        function ConfirmReopen() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to Reopen this Document workflow?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=btnReopen.ClientID%>").click();
                }
            });
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
                        AddNewRowMain(null,null,null, null);
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

            document.getElementById("ddlEmpIdT_" + RowNum).value = document.getElementById("ddlEmpIdT1_").value;

            return false;
        }
        function changeEmpMain1(RowNum) {
            document.getElementById("ddlemp_" + RowNum).style.borderColor = "";
            document.getElementById("ddlemp_" + RowNum).style.borderColor = "";
            IncrmntConfrmCounter();
            if (document.getElementById("ddlemp_" + RowNum).value.trim() == "") {
                document.getElementById("ddlemp_" + RowNum).value = "-Select-";
            }
            document.getElementById("ddlemp_" + RowNum).value = "-Select-";
            document.getElementById("ddlemp_" + RowNum).value = "";
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
                        //}
                        // }
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

        function ValidateWrkFlow() {

            var ret = true;

            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";
            $('.select2-selection').css('border-color', '');

            var NameWithoutReplace = document.getElementById("<%=txtName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtName.ClientID%>").value = replaceText2;

            var Name = document.getElementById("<%=txtName.ClientID%>").value.trim();
            var Deptmnt = document.getElementById("<%=lstDpt.ClientID%>").value;
            var Division = document.getElementById("<%=lstDiv.ClientID%>").value;
            var Hierchy = document.getElementById("<%=dlHrchy.ClientID%>").value;

            if (ValidateTables() == false) {
                ret = false;
            }

            if (Hierchy == "" || Hierchy == "--Select--") {
                document.getElementById("<%=dlHrchy.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=dlHrchy.ClientID%>").focus();
                ret = false;
            }
            if (Division == "") {
                $('.select2-selection').css('border-color', 'red');
                document.getElementById("<%=lstDiv.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=lstDiv.ClientID%>").focus();
                ret = false;
            }
            if (Deptmnt == "") {
                $('.select2-selection').css('border-color', 'red');
                document.getElementById("<%=lstDpt.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=lstDpt.ClientID%>").focus();
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
                ret = false;
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
                            Level = parseInt(Level) + 1;
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
                                    PARENT: "" + ParentId + "",//HrchyId or WrkflowId
                                    DTLID: "" + DetailId + "",//HrchyId or WrkflowId
                                });
                                tbClientSubValues.push(client);
                                tbClientSubSelctdValues.push(client);
                            }

                        }
                    }
                }

                //alert("HierchyRowParentId " + HierchyRowParentId);

                //alert("selected: " + tbClientSubSelctdValues);

                var tbClientHrchyValues = '';
                tbClientHrchyValues = [];

                if ((document.getElementById("<%=hiddenEditMode.ClientID%>").value == "") || (document.getElementById("<%=hiddenEditMode.ClientID%>").value != "" && document.getElementById("<%=hiddenHrchyChngdMode.ClientID%>").value != "")) {

                    //-----------------subtable from hierarchy----------------

                    var validRowValID = 1;

                    var EditSub = document.getElementById("<%=HiddenSun.ClientID%>").value;
                    var find2 = '\\"\\[';
                    var re2 = new RegExp(find2, 'g');
                    var res2 = EditSub.replace(re2, '\[');

                    var find3 = '\\]\\"';
                    var re3 = new RegExp(find3, 'g');
                    var res3 = res2.replace(re3, '\]');
                    var json = $noCon.parseJSON(res3);
                    for (var key in json) {
                        if (json.hasOwnProperty(key)) {
                            if (json[key].DTLID != "") {

                                var DetailId = json[key].DTLID;
                                var Level = json[key].LEVEL;
                                var DesgntnId = json[key].DESGID;
                                var EmpId = json[key].EMPID;
                                var Threshold = json[key].THRESMODE;
                                var Period = json[key].PERIOD;

                                var ApprvlMndtry = json[key].APPRVMANSTS;
                                var SubstuteEmp = json[key].SUBEMPSTS;
                                var ApprvlPending = json[key].APPRVPENSTS;
                                var TTCExceed = json[key].TTCSTS;
                                var SMS = json[key].SMSSTS;
                                var System = json[key].SYSSTS;
                                var ParentId = json[key].PARENTID;

                                if (json[key].PARENTID != "") {
                                    //alert("b4 " + ParentId);
                                    if ((HierchyRowParentId == "") || (HierchyRowParentId != "" && ParentId != HierchyRowParentId)) {
                                        //alert(ParentId);
                                        if (DesgntnId != "" && EmpId != "" && Period != "") {
                                            var client = JSON.stringify({
                                                ROWID: "" + validRowValID + "",
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
                                                PARENT: "" + ParentId + "",//HrchyId
                                                DTLID: "" + DetailId + "",//HrchyId
                                            });
                                            tbClientSubValues.push(client);
                                            tbClientHrchyValues.push(client);
                                        }
                                    }
                                }
                                validRowValID++;
                            }
                        }
                    }
                }

                //alert("hrchy: " + tbClientHrchyValues);

                document.getElementById("<%=HiddenFieldSubData.ClientID%>").value = JSON.stringify(tbClientSubValues);

                //alert("total: " + tbClientSubValues);
                //alert("HiddenFieldSubData: " + document.getElementById("<%=HiddenFieldSubData.ClientID%>").value);

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


        function mainValidate() {

            var ret = true;

            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";
            $('.select2-selection').css('border-color', '');

            var NameWithoutReplace = document.getElementById("<%=txtName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtName.ClientID%>").value = replaceText2;

            var Name2 = document.getElementById("<%=txtName.ClientID%>").value.trim();
            var dpt = document.getElementById("<%=lstDpt.ClientID%>").value;
            var divi = document.getElementById("<%=lstDiv.ClientID%>").value;
            var Name5 = document.getElementById("<%=HiddenHrchyname.ClientID%>").value;
            var dlhr = document.getElementById("<%=dlHrchy.ClientID%>").value;

            var dump = "0";
            var dumdtlid = "";
            var dumplevel = "";
            var dumprow = "";
            var sum1 = 0;
            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];
            var tbClientJobShedulingma = '';
            tbClientJobShedulingma = [];
            var tableOtherItem = document.getElementById("mainTable");
            var m = parseInt(tableOtherItem.rows.length) - 1;

            for (var a = m; a >= 0; a--) {
                var validRowID = (tableOtherItem.rows[a].cells[0].innerHTML);
                var as = parseInt(validRowID);

                if (checkMainRow(validRowID) == false) {
                    ret = false;
                }
                else {

                    document.getElementById("<%=Hiddenmaintable.ClientID%>").value = "";
                    var dtlId = (tableOtherItem.rows[a].cells[1].innerHTML);

                    var traila = (tableOtherItem.rows[a].cells[2].innerHTML);

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

                    //trail 
                    document.getElementById("<%=Hiddenmaintable.ClientID%>").value = "";
                    document.getElementById("<%=Hiddenmaintable.ClientID%>").value = client;

                    if (document.getElementById("<%=HiddenDumpsub.ClientID%>").value == "") {
                        document.getElementById("<%=HiddenDumpsub.ClientID%>").value = client;
                    }
                    else {
                        document.getElementById("<%=HiddenDumpsub.ClientID%>").value = document.getElementById("<%=HiddenDumpsub.ClientID%>").value + "," + client;
                    }



                    var EditSub = document.getElementById("<%=HiddenSun.ClientID%>").value;
                    var find2 = '\\"\\[';
                    var re2 = new RegExp(find2, 'g');
                    var res2 = EditSub.replace(re2, '\[');

                    var find3 = '\\]\\"';
                    var re3 = new RegExp(find3, 'g');
                    var res3 = res2.replace(re3, '\]');
                    var json = $noCon.parseJSON(res3);
                    for (var key in json) {
                        if (json.hasOwnProperty(key)) {
                            if (json[key].DTLID != "") {


                                var dtlId2 = json[key].DTLID;
                                var trail3 = json[key].TRAIL;
                                var level1 = json[key].LEVEL;

                                if (traila == trail3 && dtlId != dtlId2 && level1 != "0") {

                                    var tbClientJobSheduling1 = '';
                                    tbClientJobSheduling1 = [];
                                    var tableOtherItem1 = document.getElementById("subTable");
                                    var m1 = parseInt(tableOtherItem1.rows.length) - 1;

                                    if (m1 < 0) {

                                        if (level1 == "0") {
                                        }
                                        else {

                                            var dtlId2 = json[key].DTLID;
                                            var row1 = json[key].RO - 1;
                                            // var row1 = a;
                                            if (row1 <= 0) {
                                                row1 = 1;
                                            }

                                            var trail3 = json[key].TRAIL
                                            var DesgId = json[key].DESGID;
                                            var EmpId = json[key].EMPID;

                                            var AprvMandSts = json[key].APPRVMANSTS;
                                            var subsEmpSts = json[key].SUBEMPSTS;
                                            var ThresMode = json[key].THRESMODE;
                                            var Period = json[key].PERIOD;
                                            var AprvPendSts = json[key].APPRVPENSTS;
                                            var SmsSts = json[key].SMSSTS;
                                            var SystemSts = json[key].SYSSTS;

                                            var level = json[key].LEVEL;

                                            if (level == "null") {

                                                var level = parseInt(document.getElementById("cphMain_HiddenFieldCurrentLevel").value) + 1;
                                            }
                                            var $add = jQuery.noConflict();
                                            var client4 = JSON.stringify({

                                                DTLID: "" + dtlId2 + "",
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
                                                SYSSTS: "" + SystemSts + "",
                                                RO: "" + row1 + "",
                                                TRAIL: "" + trail3 + ""
                                            });
                                            // document.getElementById("<%=Hiddentrail3.ClientID%>").value = client3;

                                        }

                                        if (client4 != "") {
                                            sum1 = 1;
                                        }
                                        else {
                                            sum1 = 0;
                                        }

                                        if (document.getElementById("<%=HiddenSubTable.ClientID%>").value == "") {
                                            document.getElementById("<%=HiddenSubTable.ClientID%>").value = client4;
                                        }
                                        else {
                                            document.getElementById("<%=HiddenSubTable.ClientID%>").value = document.getElementById("<%=HiddenSubTable.ClientID%>").value + "," + client4;
                                        }


                                    }

                                    else {

                                        for (var a1 = m1; a1 >= 0; a1--) {
                                            sum1 = 1;
                                            var validRowID = (tableOtherItem1.rows[a1].cells[0].innerHTML);
                                            var trail1 = (tableOtherItem1.rows[a1].cells[17].innerHTML);

                                            var dtlId1 = (tableOtherItem1.rows[a1].cells[1].innerHTML);

                                            if (trail1 == trail3 && dtlId2 == dtlId1 && dump != dtlId1) {

                                                if (checkSubRow(validRowID) == false) {

                                                    ret = false;
                                                }

                                                else {
                                                    var level = (tableOtherItem1.rows[a1].cells[16].innerHTML);

                                                    if (level == "0") {
                                                    }
                                                    else {

                                                        var dtlId1 = (tableOtherItem1.rows[a1].cells[1].innerHTML);

                                                        dump = dtlId1;
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
                                                        var level = (tableOtherItem1.rows[a1].cells[16].innerHTML);

                                                        var trail2 = (tableOtherItem1.rows[a1].cells[17].innerHTML);
                                                        if (level == "null") {

                                                            var level = parseInt(document.getElementById("cphMain_HiddenFieldCurrentLevel").value) + 1;
                                                        }


                                                        if (dumplevel != level) {

                                                            var row1d = a;
                                                            if (row1d == 0) {
                                                                row1d = 1;

                                                                var row1 = row1d;
                                                            }
                                                            else {

                                                                var row1 = row1d;
                                                            }
                                                            dumprow = row1;
                                                        }
                                                        else {
                                                            var row1 = dumprow;
                                                        }
                                                        //  alert(row1);
                                                        dumplevel = level;
                                                        var $add = jQuery.noConflict();
                                                        var client1 = JSON.stringify({

                                                            DTLID: "" + dtlId1 + "",
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
                                                            SYSSTS: "" + SystemSts + "",
                                                            RO: "" + row1 + "",
                                                            TRAIL: "" + trail2 + ""
                                                        });


                                                        document.getElementById("<%=Hiddentrail2.ClientID%>").value = client1;
                                                    }
                                                }
                                            }
                                            else {
                                                if (dump == "0") {

                                                    if (traila == trail3 && dtlId2 != dtlId1 && dumdtlid != dtlId2) {


                                                        if (level1 == "0") {
                                                        }
                                                        else {
                                                            var dtlId2 = json[key].DTLID;
                                                            dumdtlid = dtlId2;

                                                            var row1 = json[key].RO - 1;

                                                            if (row1 == 0) {
                                                                row1 = 1;
                                                            }

                                                            var trail3 = json[key].TRAIL
                                                            var DesgId = json[key].DESGID;
                                                            var EmpId = json[key].EMPID;
                                                            var AprvMandSts = json[key].APPRVMANSTS;
                                                            var subsEmpSts = json[key].SUBEMPSTS;
                                                            var ThresMode = json[key].THRESMODE;
                                                            var Period = json[key].PERIOD;
                                                            var AprvPendSts = json[key].APPRVPENSTS;
                                                            var SmsSts = json[key].SMSSTS;
                                                            var SystemSts = json[key].SYSSTS;

                                                            var level = json[key].LEVEL;

                                                            if (level == "null") {

                                                                var level = parseInt(document.getElementById("cphMain_HiddenFieldCurrentLevel").value) + 1;
                                                            }
                                                            var $add = jQuery.noConflict();
                                                            var client3 = JSON.stringify({

                                                                DTLID: "" + dtlId2 + "",
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
                                                                SYSSTS: "" + SystemSts + "",
                                                                RO: "" + row1 + "",
                                                                TRAIL: "" + trail3 + ""
                                                            });
                                                            document.getElementById("<%=Hiddentrail3.ClientID%>").value = client3;
                                                            // alert(client3);
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        if (document.getElementById("<%=HiddenSubTable.ClientID%>").value == "") {

                                            if (document.getElementById("<%=Hiddentrail2.ClientID%>").value != "") {
                                                document.getElementById("<%=HiddenSubTable.ClientID%>").value = document.getElementById("<%=Hiddentrail2.ClientID%>").value;
                                            }
                                            if (document.getElementById("<%=Hiddentrail3.ClientID%>").value != "") {

                                                document.getElementById("<%=HiddenSubTable.ClientID%>").value = document.getElementById("<%=Hiddentrail3.ClientID%>").value;
                                            }
                                        }
                                        else {
                                            if (document.getElementById("<%=Hiddentrail2.ClientID%>").value != "") {
                                                document.getElementById("<%=HiddenSubTable.ClientID%>").value = document.getElementById("<%=HiddenSubTable.ClientID%>").value + "," + document.getElementById("<%=Hiddentrail2.ClientID%>").value;
                                            }
                                            if (document.getElementById("<%=Hiddentrail3.ClientID%>").value != "") {
                                                document.getElementById("<%=HiddenSubTable.ClientID%>").value = document.getElementById("<%=HiddenSubTable.ClientID%>").value + "," + document.getElementById("<%=Hiddentrail3.ClientID%>").value;
                                            }
                                        }
                                        document.getElementById("<%=Hiddentrail3.ClientID%>").value = "";
                                        document.getElementById("<%=Hiddentrail2.ClientID%>").value = "";

                                    }

                                }

                            }

                        }
                    }

                    if (document.getElementById("<%=Hiddenmaintable.ClientID%>").value != "") {
                        if (document.getElementById("<%=Hiddensubsub.ClientID%>").value == "") {
                            if (document.getElementById("<%=HiddenSubTable.ClientID%>").value == "") {
                                document.getElementById("<%=Hiddensubsub.ClientID%>").value = document.getElementById("<%=Hiddenmaintable.ClientID%>").value;

                            }
                            else {
                                document.getElementById("<%=Hiddensubsub.ClientID%>").value = document.getElementById("<%=HiddenSubTable.ClientID%>").value + "," + document.getElementById("<%=Hiddenmaintable.ClientID%>").value;

                            }
                        }
                        else {
                            if (document.getElementById("<%=HiddenSubTable.ClientID%>").value == "") {
                                document.getElementById("<%=Hiddensubsub.ClientID%>").value = document.getElementById("<%=Hiddensubsub.ClientID%>").value + "," + document.getElementById("<%=Hiddenmaintable.ClientID%>").value;

                            }
                            else {
                                document.getElementById("<%=Hiddensubsub.ClientID%>").value = document.getElementById("<%=Hiddensubsub.ClientID%>").value + "," + document.getElementById("<%=HiddenSubTable.ClientID%>").value + "," + document.getElementById("<%=Hiddenmaintable.ClientID%>").value;

                            }
                        }
                    }



                    document.getElementById("<%=Hiddenmaintable.ClientID%>").value = "";
                    document.getElementById("<%=HiddenSubTable.ClientID%>").value = "";
                    document.getElementById("<%=HiddenFieldMainData.ClientID%>").value = document.getElementById("<%=Hiddensubsub.ClientID%>").value;


                    if (sum1 == 0) {
                        document.getElementById("<%=HiddenFieldMainData.ClientID%>").value = document.getElementById("<%=HiddenDumpsub.ClientID%>").value;
                    }
                    else {
                        document.getElementById("<%=HiddenFieldMainData.ClientID%>").value = document.getElementById("<%=Hiddensubsub.ClientID%>").value;
                    }
                    // alert(document.getElementById("<%=HiddenFieldMainData.ClientID%>").value);

                }

            }


            if (changeDate(0) == false) {

                ret = false;

            }

            if (Name5 == "") {
                document.getElementById("<%=HiddenHrchyname.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=HiddenHrchyname.ClientID%>").focus();
                ret = false;
            }
            if (dlhr == "" || dlhr == "--Select--") {
                document.getElementById("<%=dlHrchy.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=dlHrchy.ClientID%>").focus();
                ret = false;
            }
            if (divi == "") {
                $('.select2-selection').css('border-color', 'red');
                document.getElementById("<%=lstDiv.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=lstDiv.ClientID%>").focus();
                ret = false;
            }
            if (dpt == "") {
                $('.select2-selection').css('border-color', 'red');
                document.getElementById("<%=lstDpt.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=lstDpt.ClientID%>").focus();
                ret = false;
            }
            if (Name2 == "") {
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

                tbClientJobSheduling.push(document.getElementById("<%=HiddenFieldMainData.ClientID%>").value);

                $add("#cphMain_HiddenFieldSubData").val(JSON.stringify(tbClientJobSheduling));

                //alert(document.getElementById("<%=HiddenFieldSubData.ClientID%>").value);
            }
            return ret;

        }

       
        function mainValidateupd() {

            var ret = true;

            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";
            $('.select2-selection').css('border-color', '');

            var NameWithoutReplace = document.getElementById("<%=txtName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtName.ClientID%>").value = replaceText2;

            var Name2 = document.getElementById("<%=txtName.ClientID%>").value.trim();
            var dpt = document.getElementById("<%=lstDpt.ClientID%>").value;
            var divi = document.getElementById("<%=lstDiv.ClientID%>").value;
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
                        //alert(dtlId);
                        subValidateupd();

                    }

                }
            }

            if (changeDate(0) == false) {
                ret = false;
            }

            

            if (Name5 == "") {
                document.getElementById("<%=HiddenHrchyname.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=HiddenHrchyname.ClientID%>").focus();
                ret = false;
            }
            if (divi == "") {
                $('.select2-selection').css('border-color', 'red');
                document.getElementById("<%=lstDiv.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=lstDiv.ClientID%>").focus();
                ret = false;
            }
            if (dpt == "") {
                $('.select2-selection').css('border-color', 'red');
                document.getElementById("<%=lstDpt.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=lstDpt.ClientID%>").focus();
                ret = false;
            }
            if (Name2 == "") {
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
                var dtlId = (tableOtherItem.rows[a1].cells[1].innerHTML);

                if (checkSubRow(validRowID) == false) {

                    ret = false;
                }
                else {
                    var dtlId = (tableOtherItem.rows[a1].cells[1].innerHTML);
                    dtl = dtlId;
                    var row1 = a1;
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
                    var level = (tableOtherItem.rows[a1].cells[16].innerHTML);

                    var trail = (tableOtherItem.rows[a1].cells[17].innerHTML);
                    if (trail == undefined) {
                        trail = document.getElementById("cphMain_Hiddentrailvalue").value;
                    }

                    if (level == "null") {

                        var level = parseInt(document.getElementById("cphMain_HiddenFieldCurrentLevel").value) + 1;
                    }
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
                        SYSSTS: "" + SystemSts + "",
                        RO: "" + row1 + "",
                        TRAIL: "" + trail + ""
                    });


                    tbClientJobSheduling1.push(client);
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
            if (ret == true) {

            }
            return ret;
        }


        function AddNewRowSub(DtlId, Trail, Level, SubordNum, Name) {
            var newtrail = '';
            if (document.getElementById("cphMain_Hiddentrailvalue").value == "" || document.getElementById("cphMain_Hiddentrailvalue").value == null || document.getElementById("cphMain_Hiddentrailvalue").value == undefined) {
                newtrail = Trail;

            }
            else {
                newtrail = document.getElementById("cphMain_Hiddentrailvalue").value;
                Trail = document.getElementById("cphMain_Hiddentrailvalue").value;
            }
            var FrecRow = '';
            var b = "";
            if ((document.getElementById("<%=HiddenFieldwrkId.ClientID%>").value) != "0") {
                b = "1";
            }
            else {
                b = "0";
            }
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
                if (DtlId != "" && DtlId != null && b == "0") {
                    FrecRow += '<button id="btnSubord_' + RowNumMain + '" onclick="return FuctionOrganize(\'' + DtlId + '\',\'' + Level + '\',\'' + Name + '\',\'' + Trail + '\');" class="btn act_btn bn6 notv" title="Subordinates"><i class="fa fa-cloud-download" aria-hidden="true"></i></button>';
                }
                else if (DtlId != "" && DtlId != null && b == "1") {
                    FrecRow += '<button id="btnSubord_' + RowNumMain + '" onclick="return FuctionOrganize1(\'' + DtlId + '\',\'' + Level + '\',\'' + Name + '\',\'' + Trail + '\');" class="btn act_btn bn6 notv" title="Subordinates"><i class="fa fa-cloud-download" aria-hidden="true"></i></button>';
                }
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
            if (document.getElementById("<%=cbxaprpnd.ClientID%>").checked == true) {
                FrecRow += '<input id="cbxAprPen_' + RowNumMain + '" type="checkbox" checked="true" onchange="IncrmntConfrmCounter();">';
            }
            else {
                FrecRow += '<input id="cbxAprPen_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            }
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="col_sp1">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            if (document.getElementById("<%=cbxTmExd.ClientID%>").checked == true) {
                FrecRow += '<input id="cbxTtcExc_' + RowNumMain + '" type="checkbox" checked="true" onchange="IncrmntConfrmCounter();">';
            }
            else {
                FrecRow += '<input id="cbxTtcExc_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            }
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="col_sp2">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            if (document.getElementById("<%=cbxsm.ClientID%>").checked == true) {
                FrecRow += '<input id="cbxSms_' + RowNumMain + '" type="checkbox" checked=="true" onchange="IncrmntConfrmCounter();">';
            }
            else {
                FrecRow += '<input id="cbxSms_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            }
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td class="col_sp2">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            if (document.getElementById("<%=cbxnt.ClientID%>").checked == true) {
                FrecRow += '<input id="cbxSys_' + RowNumMain + '" type="checkbox" checked="true" onchange="IncrmntConfrmCounter();">';
            }
            else {
                FrecRow += '<input id="cbxSys_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            }
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td class="td1">';

            FrecRow += '<div class="btn_stl1">';
            //if (b != "0") {
                FrecRow += '<button id="btnAdd_' + RowNumMain + '" onclick="return FuctionAddSub(\'' + RowNumMain + '\',\'' + newtrail + '\');" class="btn act_btn bn1 subAdd" title="Add"><i class="fa fa-plus-circle"></i></button>';
                FrecRow += '<button id="btnDele_' + RowNumMain + '" onclick="return FuctionDeleSub(\'' + RowNumMain + '\');" class="btn act_btn bn3" title="Delete"><i class="fa fa-trash"></i></button>';

            //}
            //else {
            //    FrecRow += '<button disabled id="btnAdd_' + RowNumMain + '" onclick="return FuctionAddSub(\'' + RowNumMain + '\',\'' + newtrail + '\');" class="btn act_btn bn1 subAdd" title="Add"><i class="fa fa-plus-circle"></i></button>';
            //    FrecRow += '<button disabled id="btnDele_' + RowNumMain + '" onclick="return FuctionDeleSub(\'' + RowNumMain + '\');" class="btn act_btn bn3" title="Delete"><i class="fa fa-trash"></i></button>';
            //}

            FrecRow += '</div>';
            FrecRow += '</td>';
            FrecRow += '<td id="dblevel_' + RowNumMain + '" style="display: none" >' + Level + '</td>';
            FrecRow += '<td id="trail_' + RowNumMain + '" style="display: none" >' + Trail + '</td>';
            FrecRow += '<td id="ro_' + RowNumMain + '" style="display: none" ></td>';
            FrecRow += '<td id="tdParentId' + RowNumMain + '" style="display: none" ></td>';

            FrecRow += '</tr>';

            jQuery('#subTable').append(FrecRow);

            document.getElementById("ddlDesgIdT_" + RowNumMain).focus();

            $('.subAdd').attr('disabled', 'disabled');
            var LastRowid = $("#subTable tr:last td:first").html();
            //if (b != "0") {
                document.getElementById("btnAdd_" + LastRowid).disabled = false;
            //}
            //else {
            //    document.getElementById("btnAdd_" + LastRowid).disabled = true;
            //}
            RowNumMain++;
            return false;
        }

        function EditListRowsSub(DTLID, TRAIL, LEVEL, DESGID, EMPID, APPRVMANSTS, SUBEMPSTS, THRESMODE, PERIOD, APPRVPENSTS, TTCSTS, SMSSTS, SYSSTS, SUBORDNUM, NAME, DESGNAME, RO) {

            AddNewRowSub(DTLID, TRAIL, LEVEL, SUBORDNUM, NAME);
            var validRowID = RowNumMain - 1;
            //alert(RO);
            document.getElementById("dbId_" + validRowID).innerHTML = DTLID;
            document.getElementById("ddlDesgId_" + validRowID).value = DESGID;
            document.getElementById("ddlDesgIdT_" + validRowID).value = DESGNAME;
            document.getElementById("ddlEmpId_" + validRowID).value = EMPID;
            document.getElementById("ddlEmpIdT_" + validRowID).value = NAME;
            document.getElementById("dblevel_" + validRowID).innerHTML = LEVEL;

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
            document.getElementById("ro_" + validRowID).innerHTML = RO;
        }

        function FuctionAddSub(RowNum, trail) {
            if (checkMainRow(RowNum) == true) {
                IncrmntConfrmCounter();
                //  alert(Trail);
                AddNewRowSub(null, trail, null, 0, null);
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
                        AddNewRowSub(null,null, null, 0, null);
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
            $("#success-alert").html("Docuemt Workflow details Confirmed successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessReopen() {
            $("#success-alert").html("Docuemt Workflow details Reopened successfully");
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
      
        function AlreadyDeleted() {
            $("#divWarning").html("Sorry, this purchase order is already deleted!");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
    </script>
     <script>
         $noCon = jQuery.noConflict();
         $noCon2 = jQuery.noConflict();
         $noCon(function () {
             $noCon2(".select2").select2();
         });
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
       
                 

                  
           