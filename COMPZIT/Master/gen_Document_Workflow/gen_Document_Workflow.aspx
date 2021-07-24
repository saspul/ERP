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
 <link href="/css/New css/select2.min.css" rel="stylesheet" />
 <script src="/js/New js/js/select2.min.js"></script>
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />

    
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
  <asp:HiddenField ID="HiddenFieldwrkId" runat="server" />
  <asp:HiddenField ID="hiddenApprovalDtls" runat="server" />
  <asp:HiddenField ID="hiddenReplaceApproverSts" runat="server" />
  <asp:HiddenField ID="hiddenCnclApprvlData" runat="server" />
  <asp:HiddenField ID="hiddenApprvlRuleSts" runat="server" />
  <asp:HiddenField ID="hiddenConditionChng" runat="server" />

     <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>


    <!---breadcrumb_section_started---->    
    <ol id="ulLink" runat="server" class="breadcrumb">
      <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
      <li><a href="gen_Document_Workflow_List.aspx">Document Workflow</a></li>
      <li class="active">Add Document Workflow</li>
    </ol>
<!---breadcrumb_section_started----> 


    <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con" id="lblEntry" runat="server">Add Document Workflow</h1>

          <div class="form-group fg2">
            <label for="email" class="fg2_la1">Name:<span class="spn1">*</span></label>
            <asp:TextBox ID="txtName"  class="form-control fg2_inp1 fg_chs1 inp_mst" placeholder="Name" runat="server" MaxLength="100"></asp:TextBox>
          </div>

          <div class="form-group fg2">
            <label for="email" class="fg2_la1">Document Section<span class="spn1"></span>:</label>
            <asp:DropDownList ID="docsection" class="form-control fg2_inp1 fg_chs1" runat="server" onchange="return ChangeApprovalRules();">
                  <asp:ListItem Value="0">--select--</asp:ListItem>
              </asp:DropDownList>           
          </div>

          <div class="form-group fg2">
            <label for="email" class="fg2_la1 pad_l">Enable Approval Transfer:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                  <asp:CheckBox ID="cbxapr" runat="server" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>

          <div class="form-group fg2">
            <label for="email" class="fg2_la1 pad_l">Approver Can Modify:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch" onclick="ChangeModifyUser();">
                  <asp:CheckBox ID="cbxmdfy" runat="server" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>

     <!---=================section_devider============--->
                  <div class="clearfix"></div>
      <!---=================section_devider============--->

         <div class="form-group fg2 fg2_wf1">
            <label for="email" class="fg2_la1">Description:<span class="spn1"></span></label>
            <asp:TextBox ID="txtDescr" class="form-control dt_wdt" runat="server" TextMode="MultiLine" rows="3" placeholder="Description" onblur="RemoveTag('cphMain_txtDescr')" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtDescr,450)" onkeyup="textCounter(cphMain_txtDescr,450)" style="resize: none;"></asp:TextBox>                   
          </div>

          <div class="form-group fg2 fg2_wf">
            <div class="spl_hcm wid_at100 apr_hei">
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
          </div>

          <div class="form-group fg2 fg2_wf1">
            <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">&nbsp;</span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                <asp:CheckBox ID="cbxsts"  runat="server" Checked="true" />
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>

      <!---=================section_devider============--->
                  <div class="clearfix"></div>
                  <div class="devider"></div>
      <!---=================section_devider============-->

        <h3 class="h1_con">Applicable For</h3>

        <div class="fg6 sa_2 sa_640_i">
          <label class="l_b">Department:<span class="spn1">*</span></label><br>
          <div class="dropdown-mul-1 imp_se" style="margin-right: 10px!important;width: 94%;">
             <asp:ListBox ID="lstDpt" class="form-control select2 inp_mst" multiple="multiple" runat="server" Width="90%" SelectionMode="Multiple" placeholder="Select"></asp:ListBox>
          </div>
        </div>
        <div class="fg6 sa_2 sa_640_i">
          <label class="l_b">Division:<span class="spn1">*</span></label><br>
          <div class="dropdown-mul-1 imp_se" style="margin-right: 10px!important;width: 94%;">
            <asp:ListBox ID="lstDiv" class="form-control select2 inp_mst clslstDiv" multiple="multiple" runat="server" SelectionMode="Multiple" placeholder="Select"></asp:ListBox>
          </div>
        </div>

          
<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="free_sp"></div>
      <div class="devider"></div>
<!---=================section_devider============-->

    <h3>
    <div class="check1" style="width: auto;margin-right:6px;">
      <div class="">
        <label class="switch" onclick="ChangeApprovalRules();">
         <asp:CheckBox ID="cbxApprvlRules"  runat="server" Checked="false" />
          <span class="slider_tog round"></span>
        </label>
      </div>
    </div>
    Approval rules
    </h3>
    
<!---table_Set_started--->
    <div id="divTableApprvlRules" class="tabl_set" style="display: none;">
      <table class="table table-bordered tbl_set_fix">
        <thead class="thead1">
          <tr>
            <th class="th_b5">SL#</th>
            <th class="th_b9 tr_l">Conditions</th>
            <th class="th_b4 tr_c">Type</th>
            <th class="th_b10">Value</th>
            <th class="th_b4">Actions</th>
          </tr>
        </thead>
        <tbody id="tableApprvlRules"></tbody>
          </table>
        </div>
<!---table_Set_closed--->


<!---inner_content_sections area_closed--->

<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="free_sp"></div>
      <div class="devider"></div>
<!---=================section_devider============-->

        <h3 class="h1_con">Approval Heirarchy</h3>


          <div class="form-group fg2 fg2_ht">
            <label for="email" class="fg2_la1">Name of hierarchy:<span class="spn1">*</span></label>
            <div id="divddlHrchy">
            <asp:DropDownList ID="dlHrchy" runat="server" class="form-control fg2_inp1 fg_chs1 inp_mst" OnSelectedIndexChanged="dlHrchy_SelectedIndexChanged" AutoPostBack="True" >                  
                <asp:ListItem  Value="0">--select--</asp:ListItem>
            </asp:DropDownList>
            </div>       
          </div>

            <script>
               var $au = jQuery.noConflict();
               $au(function () {
                   $au("#cphMain_dlHrchy").selectToAutocomplete1Letter();
               });
            </script>

        <div class="fg2 fg2_wf" id="dlhr" runat="server" style="display:none;">
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

        <div class="form-group fg2 fg2_wf" style="display:none;">
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

          <div class="fg6">
            <div class="form-group fg6 fg2_dt">
              <div class="tdte">
                <label for="pwd" class="fg2_la1">Start Date:<span class="spn1"></span> </label>
                <div id="datepicker1" class="input-group date" data-date-format="dd-mm-yyyy">
                  <input class="form-control inp_bdr" maxlength="10" onchange="return changeDate(1);" type="text" id="dte_1_a"  runat="server" />
                  <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                </div>
              </div> 
            </div>

            <div class="form-group fg6 fg2_dt">
              <div class="tdte">
                <label for="pwd" class="fg2_la1">End Date:<span class="spn1"></span> </label>
                <div id="datepicker2" class="input-group date" data-date-format="dd-mm-yyyy">
                  <input class="form-control inp_bdr" maxlength="10" onchange="return changeDate(1);" id="dte_1" type="text"  runat="server" />
                  <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                </div>
              </div> 
            </div>
          </div>

          <div class="form-group fg2">
            <div class=" spl_hcm wid_at100 apr_hei">
              <div class="fg6">
                <label for="email" class="fg2_la1 pad_l">Majority Approval:<span class="spn1">&nbsp;</span></label>
                <div class="check1">
                  <div class="">
                    <label class="switch" onclick="ChangeApproval(1);">
                    <asp:CheckBox ID="cbxMajorityApprvl"  runat="server" Checked="false" />
                      <span class="slider_tog round"></span>
                    </label>
                  </div>
                </div>
              </div>
            <div class="form-group fg6">
              <label for="email" class="fg2_la1 pad_l">Single Approval:<span class="spn1">&nbsp;</span></label>
              <div class="check1">
                <div class="">
                  <label class="switch" onclick="ChangeApproval(2);">
                  <asp:CheckBox ID="cbxSingleApproval"  runat="server" Checked="false" />
                    <span class="slider_tog round"></span>
                  </label>
                </div>
              </div>
            </div>
          </div>
        </div>

        <script>
            function ChangeApproval(Mode) {
                IncrmntConfrmCounter();

                if (Mode == "1") {
                    if (document.getElementById("cphMain_cbxMajorityApprvl").checked == true) {
                        document.getElementById("cphMain_cbxSingleApproval").checked = false;
                    }
                }
                if (Mode == "2") {
                    if (document.getElementById("cphMain_cbxSingleApproval").checked == true) {
                        document.getElementById("cphMain_cbxMajorityApprvl").checked = false;
                    }
                }
            }
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

        <div class="fg6 fg2_wf1" style="display: none">

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
      <div class="devider"></div>
<!---=================section_devider============-->
<!---heirarchy_section_started-->

      <div>


        <!------tree_section_started-->
        <div class="box_pro_2 pro_pa">
          <h3>Hierarchy</h3>
          <div class="tree well tr_l_z">
            <ul class="sc_hei">
              <li>
                <button onclick="return FuctionOrganizeMain();" class="pls_1 tablinks hei_adbtn notv" title="Add New"><i class="fa fa-plus-circle"></i></button>

                <ul id="myTab1" runat="server">
                </ul>

            </li>
            </ul>
          </div>
        </div>


<!------tree_section_closed----->
      
<!----Tree_table_section_box_opened-->

        <div class="box_pro_10 tab-content" >
          <div id="add_hei" class="tabcontent">
            <h2 id="headTree">Add New</h2>


            <div id="divMainTable" class="tb_res tb_s">
              <table class="table table-bordered tbl_fix hei_tbl">
                <thead class="thead1">
                  <tr>
                    <th class="th_b1_4" rowspan="2">Level</th>
                    <th class="th_b13 tr_l" rowspan="2">Designation</th>
                    <th class="th_b2 tr_l" rowspan="2">Employee</th>
                    <th class="th_b6" rowspan="2">Substitute</th>
                    <th class="th_b8" rowspan="2">Threshold</th>
                    <th class="" colspan="2">Notification Source</th>
                    <th class="th_b12" colspan="3">Notification Mode</th>
                    <th class="th_b1" rowspan="2">Can<br> Modify</th>
                    <th class="th_b7" rowspan="3">Skip To <br>Next<br>Level</th>
                    <th class="th_b2" rowspan="2">ACTIONS</th>
                  </tr>
                  <tr>
                    <th class="th_b6">Approval<br> Pending</th>
                    <th class="th_b6">Threshold<br> Exceeded</th>
                    <th class="th_b1">System</th>
                    <th class="th_b1">Mail</th>
                    <th class="th_b1">SMS</th>
                  </tr>
                </thead>

            <tbody id="mainTable">
            </tbody>
                
              </table>
            </div>


            <div id="divSubTable" class="tb_res tb_s" style="display:none;">
              <table class="table table-bordered tbl_fix hei_tbl">
                <thead class="thead1">
                  <tr>
                    <th class="th_b1_4" rowspan="2">Level</th>
                    <th class="th_b13 tr_l" rowspan="2">Designation</th>
                    <th class="th_b2 tr_l" rowspan="2">Employee</th>
                    <th class="th_b6" rowspan="2">Substitute</th>
                    <th class="th_b8" rowspan="2">Threshold</th>
                    <th class="" colspan="2">Notification Source</th>
                    <th class="th_b12" colspan="3">Notification Mode</th>
                    <th class="th_b1" rowspan="2">Can<br> Modify</th>
                    <th class="th_b7" rowspan="3">Skip To <br>Next<br>Level</th>
                    <th class="th_b2" rowspan="2">ACTIONS</th>
                  </tr>
                  <tr>
                    <th class="th_b6">Approval<br> Pending</th>
                    <th class="th_b6">Threshold<br> Exceeded</th>
                    <th class="th_b1">System</th>
                    <th class="th_b1">Mail</th>
                    <th class="th_b1">SMS</th>
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
      <div class="devider"></div>
<!---=================section_devider============-->


 <!--Buttons_Area_started-->
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
<!--Buttons_area_closed--->

      </div>

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
    <!----save_quick_actions_closed--->

  <div class="mySave1" id="mySave">
    <div class="save_sec">
        <asp:Button ID="btnSaveFloat" runat="server" OnClick="btnSave_Click" Text="Save" OnClientClick="return ValidateWrkFlow();" class="btn sub1 notv"/>
        <asp:Button ID="btnsavecloseFloat" runat="server" OnClick="btnSave_Click" Text="Save & Close" OnClientClick="return ValidateWrkFlow();" class="btn sub3 notv"/>
        <asp:Button ID="btnUpdateFloat" runat="server" OnClick="btnUpdate_Click" Text="Update" OnClientClick="return ValidateWrkFlow();" class="btn sub1 notv" Visible="False"/>
        <asp:Button ID="btnUpdateCloseFloat" runat="server" class="btn sub3 notv" Text="Update & Close" OnClientClick="return ValidateWrkFlow();" onclick="btnUpdate_Click" Visible="false" />
        <asp:Button ID="btnCnfrm1Float" runat="server" Text="Confirm" class="btn sub2 notv"   OnClientClick="return ConfirmAlert();"  Visible="false" />
        <asp:Button ID="btnReopen1Float" runat="server" Text="Reopen"  class="btn sub3 notv" OnClientClick="return ConfirmReopen();" Enabled="true"/>
        <asp:Button ID="btnCancelFloat" runat="server" class="btn sub4 notv" Text="Cancel" OnClientClick="return ConfirmMessage();" />
        <asp:Button ID="btnClearFloat" runat="server" class="btn sub2 notv" Text="Clear" OnClientClick="return AlertClearAll();"  />
    </div>
  </div>
<!----save_quick_actions_closed--->



<!----modal popup_section for Substitute Employees_opened--->

<div class="modal fade" id="ModalSubstituteEmp" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog mod2 mo3" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h3 class="modal-title mod1 flt_l mar_tp_0" id="H1"><i class="fa fa-business-time"></i> Substitute</h3>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true"><i class="fa fa-close"></i></span>
        </button>
      </div>
      <div class="modal-body md_bd1 dbt_nte pa_al mod_bdy">
       <table class="table table-bordered">
            <thead class="thead1">
              <tr>
                <th class="col-md-5 tr_l">Designation</th>
                <th class="col-md-5 tr_l">Employee</th>
                <th class="col-md-2">Actions</th>
              </tr>
            </thead>
          <tbody id="tableSubstituteEmps">
          </tbody>
        </table>
      </div>
      <div class="modal-footer">
        <button id="btnSaveSubstitute" type="button" class="btn btn-success" onclick="return ValidateSubstituteDtls();">Save</button>
        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>

<!----modal popup_section for Substitute Employees_closed--->


<!-- ModalSelectCondition -->
<div class="modal fade" id="ModalSelect" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog mod2" role="document">
    <div class="modal-content">

      <div class="modal-header">
        <h5 id="CondtnHead" class="modal-title">Aproval set- department</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
        
        <div class="modal-body">
            <div class="col-md-12">
                
                <div class="subject-info-box-1 box2">
                    <h3>Choose Items</h3>
                    <div><input id="txtConditionList" type="text" placeholder="Search" class="ser_set" onkeydown="return LoadConditionValues(event);" onkeypress="return LoadConditionValues(event);" onkeyup="return LoadConditionValues(event);" /></div>
                    <select id='ddlListFull' multiple="multiple" class="sub_1"></select>
                </div>
                
                <div class="subject-info-box-2 box2">
                    <h3>Selected Items</h3>
                    <div><input id="txtSelectedList" type="text" placeholder="Search" class="ser_set"  onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="return LoadSelectedValues(event);" /></div>
                    <select id='ddlListSelected' multiple="multiple" class="sub_2 clsSelctd"></select>
                </div>

                <input id="txtCount" style="display:none;" />

            </div>
        </div>
        
        <div class="modal-footer" style="text-align: center;">
            <div class="subject-info-arrows text-center arrows">
                <input type='button' id='btnRight' value='Add to list' class="btn btn-success bt_ad" onclick="return AddOptions();" /><br />
                <input type='button' id='btnLeft' value='Remove from list' class="btn btn-danger bt_ad" onclick="return RemoveOptions();" /><br />
            </div>
        </div>

    </div>
  </div>
</div>
<!-- ModalCondition_closed -->

    <!-- ModalCondition -->
<div class="modal fade" id="ModalCondition" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h3 class="modal-title mod1 flt_l mar_tp_0" id="exampleModalLabel"><i class="fa fa-business-time"></i> Overlapping condition workflows</h3>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body md_bd1 dbt_nte pa_al mod_bdy">
        <div class="fg12">
          <div class="fg5 mar_at flt_l pa_lft_0p">
              <div id="divModalConditon"></div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
<!-- ModalCondition_closed -->
   
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
        var $noCon = jQuery.noConflict();
        $noCon('#cphMain_dte_1_a').datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            startDate: new Date(),
            timepicker: false
        });
        $noCon('#cphMain_dte_1').datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            startDate: new Date(),
            timepicker: false
        });
 </script>


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
        $noCon(window).load(function () {

            document.getElementById("<%=hiddenCnclApprvlData.ClientID%>").value = "";

            ChangeApprovalRules();

            var EditVal = document.getElementById("<%=HiddenEdit.ClientID%>").value;
            var EditSub = document.getElementById("<%=HiddenSun.ClientID%>").value;
            if (EditVal != "") {

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
                            EditListRows(json[key].DTLID, json[key].TRAIL, json[key].LEVEL, json[key].DESGID, json[key].EMPID, json[key].APPRVMANSTS, json[key].SUBEMPSTS, json[key].THRESMODE, json[key].PERIOD, json[key].APPRVPENSTS, json[key].TTCSTS, json[key].SMSSTS, json[key].SYSSTS, json[key].NAME, json[key].DESGNAME, json[key].PARENT, json[key].MAILSTS, json[key].SKIPLVLSTS, json[key].SUBSTUTVAL, json[key].PARENTID, json[key].CANMODIFY);
                        }
                    }
                }
            }
            else {
                AddNewRowMain(null, null, null, null);

                ChangeModifyUser();
            }

            if (document.getElementById("<%=Hiddenview.ClientID%>").value == "1") {
                $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select").prop("disabled", true);
            }

            if (document.getElementById("<%=hiddenConditionChng.ClientID%>").value == "1") {
                document.getElementById("<%=lstDpt.ClientID%>").disabled = true;
                document.getElementById("<%=lstDiv.ClientID%>").disabled = true;
                document.getElementById("<%=dte_1_a.ClientID%>").disabled = true;
                document.getElementById("<%=dte_1.ClientID%>").disabled = true;
            }
        });
    </script>
    <script>

        var confirmboxEdit = 0;
        function IncrmntConfrmCounterEdit() {
            confirmboxEdit++;
            return false;
        }


        var RowNumMain = 0;
      //  var trail = 0;
        function AddNewRowMain(dtlId, trail, Name, PARENT) {

            var FrecRow = '';
            var b = "";

            if ((document.getElementById("<%=HiddenFieldwrkId.ClientID%>").value) != "0") {
                b = "1";
            }
            else {
                b = "0";
            }

            FrecRow += '<tr id="mainRowId_' + RowNumMain + '" class="tr_act">';

            FrecRow += '<td style="display: none"  >' + RowNumMain + '</td>';
            FrecRow += '<td id="dbId_' + RowNumMain + '" style="display: none" >' + dtlId + '</td>';
            FrecRow += '<td id="trail_' + RowNumMain + '" style="display: none" >' + trail + '</td>';

            FrecRow += '<td id="tdLevel' + RowNumMain + '">0</td>';
            FrecRow += '<td><input placeholder="-Select-" id="ddlDesgIdT_' + RowNumMain + '" onchange="return changeDesgMain(\'' + RowNumMain + '\');"  maxlength="100" onkeypress="return selectorToAutocompleteTextBox(' + RowNumMain + ',0);" onkeydown="return selectorToAutocompleteTextBox(' + RowNumMain + ',0);" onkeyup="return selectorToAutocompleteTextBox(' + RowNumMain + ',0);" type="text" class="form-control fg2_inp2 fg2_inp3 fg_chs1 in_flw"></td>';
            FrecRow += '<td style="display: none;"><input id="ddlDesgId_' + RowNumMain + '" value="-Select-"></td>';

            FrecRow += '<td><input placeholder="-Select-" id="ddlEmpIdT_' + RowNumMain + '" onchange="return changeEmpMain(\'' + RowNumMain + '\');"  maxlength="100" onkeypress="return selectorToAutocompleteTextBox(' + RowNumMain + ',1);" onkeydown="return selectorToAutocompleteTextBox(' + RowNumMain + ',1);" onkeyup="return selectorToAutocompleteTextBox(' + RowNumMain + ',1);" type="text" class="form-control fg2_inp2 fg2_inp3 fg_chs1 in_flw"></td>';
            FrecRow += '<td style="display: none;"><input id="ddlEmpId_' + RowNumMain + '" value="-Select-"></td>';

            FrecRow += '<td style="display:none;">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxAprMand_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();" onchange="BlurValue(\'' + RowNumMain + '\')">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            FrecRow += '<td>';
            FrecRow += '<button id="cbxSubstSts_' + RowNumMain + '" class="btn act_btn bn7 notv" title="Substitute Employees" data-toggle="modal" data-target="#ModalSubstituteEmp" onclick="return OpenSubstituteModal(\'' + RowNumMain + '\');" onchange="BlurValue(\'' + RowNumMain + '\')"><i class="fa fa-exchange" aria-hidden="true"></i></button>';
            FrecRow += '<td style="display: none;"><input id="tdSubstituteVal_' + RowNumMain + '" value=""></td>';
            FrecRow += '</td>';

            FrecRow += '<td>';
            FrecRow += '<div class="input-group ing2 dh_inp">';
            FrecRow += '<select id="ddlThresId_' + RowNumMain + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" onchange="BlurValue(\'' + RowNumMain + '\')">';
            FrecRow += '<option value="0">Days</option>';
            FrecRow += '<option value="1">Hours</option>';
            FrecRow += '</select>';
            FrecRow += '</div>';
            FrecRow += '<div class="input-group ing1">';
            FrecRow += '<input id="txtPeriod_' + RowNumMain + '" type="text" class="form-control fg2_inp2 tr_r" onchange="return ChangePeriod(\'txtPeriod_' + RowNumMain + '\',\'' + RowNumMain + '\')" maxlength="3" onkeydown="return isNumber(event)" onkeydown="return isNumber(event)">';
            FrecRow += '</div>';
            FrecRow += '</td>';

            FrecRow += '<td class="">';
            FrecRow += '<div class="check1">';
            FrecRow += '<div class=""><label class="switch">';
            if (document.getElementById("<%=cbxaprpnd.ClientID%>").checked == true) {
                FrecRow += '<input id="cbxAprPen_' + RowNumMain + '" type="checkbox" checked="true" onchange="BlurValue(\'' + RowNumMain + '\')">';
            }
            else {
                FrecRow += '<input id="cbxAprPen_' + RowNumMain + '" type="checkbox" onchange="BlurValue(\'' + RowNumMain + '\')">';
            }
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            if (document.getElementById("<%=cbxTmExd.ClientID%>").checked == true) {
                FrecRow += '<input id="cbxTtcExc_' + RowNumMain + '" type="checkbox" checked="true" onchange="BlurValue(\'' + RowNumMain + '\')">';
            }
            else {
                FrecRow += '<input id="cbxTtcExc_' + RowNumMain + '" type="checkbox" onchange="BlurValue(\'' + RowNumMain + '\')">';
            }
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="">';
            FrecRow += '<div class="check1 tb_ck1"><div class=""><label class="switch">';
            if (document.getElementById("<%=cbxnt.ClientID%>").checked == true) {
                FrecRow += '<input id="cbxSys_' + RowNumMain + '" type="checkbox" checked="true" onchange="BlurValue(\'' + RowNumMain + '\')">';
            }
            else {
                FrecRow += '<input id="cbxSys_' + RowNumMain + '" type="checkbox" onchange="BlurValue(\'' + RowNumMain + '\')">';
            }
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="">';
            FrecRow += '<div class="check1 tb_ck1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxMail_' + RowNumMain + '" type="checkbox"  onchange="BlurValue(\'' + RowNumMain + '\')" onkeypress="return DisableEnter(event)">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="">';
            FrecRow += '<div class="check1 tb_ck1"><div class=""><label class="switch">';
            if (document.getElementById("<%=cbxsm.ClientID%>").checked == true) {
                FrecRow += '<input id="cbxSms_' + RowNumMain + '" type="checkbox" checked=="true" onchange="BlurValue(\'' + RowNumMain + '\')">';
            }
            else {
                FrecRow += '<input id="cbxSms_' + RowNumMain + '" type="checkbox" onchange="BlurValue(\'' + RowNumMain + '\')">';
            }
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="">';
            FrecRow += '<div class="check1 tb_ck1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxCanModify_' + RowNumMain + '" type="checkbox" class="clsModify" onchange="BlurValue(\'' + RowNumMain + '\')" onkeypress="return DisableEnter(event)">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxSkipLvl_' + RowNumMain + '" type="checkbox"  onchange="BlurValue(\'' + RowNumMain + '\')" onkeypress="return DisableEnter(event)">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="td1">';
            FrecRow += '<div class="btn_stl1">';
            FrecRow += '<button id="btnAdd_' + RowNumMain + '" onclick="return FuctionAddMain(\'' + RowNumMain + '\');" class="btn act_btn bn1 mainAdd" title="Add"><i class="fa fa-plus-circle"></i></button>';
            FrecRow += '<button disabled id="btnSave_' + RowNumMain + '" onclick="return FuctionSaveMain(\'' + RowNumMain + '\');" class="btn act_btn bn2" title="Save"><i class="fa fa-save"></i></button>';
            FrecRow += '<button id="btnDele_' + RowNumMain + '" Onclick="return FuctionDeleMain(\'' + RowNumMain + '\');" class="btn act_btn bn3" title="Delete"><i class="fa fa-trash"></i></button>';


            //if (dtlId != "" && dtlId != null && b == "0" && PARENT != "0") {
            //    FrecRow += '<button id="btnOrg_' + RowNumMain + '" onclick="return FuctionOrganize(\'' + dtlId + '\',0,\'' + Name + '\',\'' + trail + '\');" class="btn act_btn bn8 organiser notv" title="Organiser"><i class="fa fa-sitemap"></i></button>';
            //}
            //else if (dtlId != "" && dtlId != null && b == "1") {
            //    FrecRow += '<button id="btnOrg_' + RowNumMain + '" onclick="return FuctionOrganize1(\'' + dtlId + '\',0,\'' + Name + '\',\'' + trail + '\');" class="btn act_btn bn8 organiser notv" title="Organiser"><i class="fa fa-sitemap"></i></button>';
            //}
            //else if (dtlId != "" && dtlId != null && b == "0" && PARENT == "0") {
            //    FrecRow += '<button disabled id="btnOrg_' + RowNumMain + '" class="btn act_btn bn8 organiser" title="Organiser"><i class="fa fa-sitemap"></i></button>';
            //}

            FrecRow += '</div>';
            FrecRow += '</td>';

            FrecRow += '<td style="display: none;"><input id="tdParentId' + RowNumMain + '" value="0"></td>';

            FrecRow += '</tr>';
            jQuery('#mainTable').append(FrecRow);
            if (dtlId == "null" || dtlId == null || dtlId == "") {

            }
            $('.mainAdd').attr('disabled', 'disabled');
            var LastRowid = $("#mainTable tr:last td:first").html();

            if (document.getElementById("<%=hiddenReplaceApproverSts.ClientID%>").value == "1") {
                document.getElementById("btnDele_" + RowNumMain).disabled = true;
                document.getElementById("btnAdd_" + RowNumMain).disabled = true;
            }
            else {
                document.getElementById("btnAdd_" + LastRowid).disabled = false;
            }

            if (document.getElementById("<%=hiddenConditionChng.ClientID%>").value == "1") {
                document.getElementById("btnDele_" + RowNumMain).disabled = true;
                document.getElementById("btnAdd_" + RowNumMain).disabled = true;
                document.getElementById("ddlDesgIdT_" + RowNumMain).disabled = true;
                document.getElementById("ddlEmpIdT_" + RowNumMain).disabled = true;
                document.getElementById("ddlThresId_" + RowNumMain).disabled = true;
                document.getElementById("txtPeriod_" + RowNumMain).disabled = true;
                document.getElementById("cbxAprPen_" + RowNumMain).disabled = true;
                document.getElementById("cbxTtcExc_" + RowNumMain).disabled = true;
                document.getElementById("cbxSys_" + RowNumMain).disabled = true;
                document.getElementById("cbxMail_" + RowNumMain).disabled = true;
                document.getElementById("cbxSms_" + RowNumMain).disabled = true;
                document.getElementById("cbxCanModify_" + RowNumMain).disabled = true;
                document.getElementById("cbxSkipLvl_" + RowNumMain).disabled = true;
            }

            RowNumMain++;
            return false;
        }


        function EditListRows(DTLID, TRAIL, LEVEL, DESGID, EMPID, APPRVMANSTS, SUBEMPSTS, THRESMODE, PERIOD, APPRVPENSTS, TTCSTS, SMSSTS, SYSSTS, NAME, DESGNAME, PARENT, MAILSTS, SKIPLVLSTS, SUBSTUTVAL, PARENTID, CANMODIFY) {

            AddNewRowMain(DTLID, TRAIL, NAME, PARENT);

            var validRowID = RowNumMain - 1;

            document.getElementById("dbId_" + validRowID).innerHTML = DTLID;
            document.getElementById("trail_" + validRowID).innerHTML = TRAIL;
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

            if (MAILSTS == "1") {
                document.getElementById("cbxMail_" + validRowID).checked = true;
            }
            if (SKIPLVLSTS == "1") {
                document.getElementById("cbxSkipLvl_" + validRowID).checked = true;
            }
            if (CANMODIFY == "1") {
                document.getElementById("cbxCanModify_" + validRowID).checked = true;
            }
            document.getElementById("tdSubstituteVal_" + validRowID).value = SUBSTUTVAL;
            document.getElementById("tdParentId" + validRowID).value = PARENTID;

            if (document.getElementById("<%=hiddenReplaceApproverSts.ClientID%>").value == "1") {
                document.getElementById("btnAdd_" + validRowID).disabled = true;
                document.getElementById("btnDele_" + validRowID).disabled = true;
            }
        }

        function FuctionOrganizeMain() {

            if (confirmboxEdit > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to change level without saving?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        confirmboxEdit = 0;
                        LoadMainRows();
                    }
                })
            }
            else {
                LoadMainRows();
            }
            return false;
        }

        function LoadMainRows() {

            document.getElementById("headTree").innerHTML = "Add New";
            $("#divMainTable").fadeIn();
            $("#divSubTable").fadeOut(100);

            var idlast = $('#mainTable tr:last').attr('id');
            var LastId = "";
            if (idlast != "") {
                var res = idlast.split("_");
                LastId = res[1];
            }
            document.getElementById("ddlDesgIdT_" + LastId).focus();
        }


        function FuctionOrganize(DtlId, Level, Name, trail) {

            if (confirmboxEdit > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to change level without saving?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        confirmboxEdit = 0;
                        LoadHrchyRows(DtlId, Level, Name, trail);
                    }
                })
            }
            else {
                LoadHrchyRows(DtlId, Level, Name, trail);
            }
            return false;
        }

        function LoadHrchyRows(DtlId, Level, Name, trail) {

            document.getElementById("headTree").innerHTML = Name;
            $("#divMainTable").hide();
            $("#divSubTable").fadeOut(100);

            $(".Chkcls").removeClass("act_hie");
            $("#span_" + DtlId).addClass("act_hie");


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
                    if (data.d[0] != "" && data.d[0] != null) {

                        var find2 = '\\"\\[';
                        var re2 = new RegExp(find2, 'g');
                        var res2 = data.d[0].replace(re2, '\[');

                        var find3 = '\\]\\"';
                        var re3 = new RegExp(find3, 'g');
                        var res3 = res2.replace(re3, '\]');
                        var json = $noCon.parseJSON(res3);
                        for (var key in json) {
                            if (json.hasOwnProperty(key)) {
                                if (json[key].DTLID != "") {
                                    EditListRowsSub(json[key].DTLID, json[key].TRIAL, json[key].LEVEL, json[key].DESGID, json[key].EMPID, json[key].APPRVMANSTS, json[key].SUBEMPSTS, json[key].THRESMODE, json[key].PERIOD, json[key].APPRVPENSTS, json[key].TTCSTS, json[key].SMSSTS, json[key].SYSSTS, json[key].SUBORDNUM, json[key].NAME, json[key].DESGNAME, json[key].RO, json[key].MAILSTS, json[key].SKIPLVLSTS, json[key].SUBSTUTVAL, json[key].PARENTID, "0");
                                }
                            }
                        }

                        if (parseInt(data.d[1]) <= 1) {
                            AddNewRowSub(null, null, null, 0, null);

                            ChangeModifyUser();
                        }
                    }
                    else {
                        AddNewRowSub(null, null, null, 0, null);

                        ChangeModifyUser();
                    }
                }

            });

            $("#divSubTable").fadeIn();

            if (document.getElementById("<%=Hiddenview.ClientID%>").value == "1" || document.getElementById("<%=hiddenConditionChng.ClientID%>").value == "1") {
                $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select").prop("disabled", true);
            }
        }

        function FuctionOrganize1(DtlId, Level, Name, trail) {

            if (confirmboxEdit > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to change level without saving?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        confirmboxEdit = 0;
                        LoadRows(DtlId, Level, Name, trail);
                    }
                })
            }
            else {
                LoadRows(DtlId, Level, Name, trail);
            }
            return false;
        }

        function LoadRows(DtlId, Level, Name, trail) {

            document.getElementById("headTree").innerHTML = Name;
            $("#divMainTable").hide();
            $("#divSubTable").fadeOut(100);

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
                    if (data.d[0] != "" && data.d[0] != null) {

                        var find2 = '\\"\\[';
                        var re2 = new RegExp(find2, 'g');
                        var res2 = data.d[0].replace(re2, '\[');

                        var find3 = '\\]\\"';
                        var re3 = new RegExp(find3, 'g');
                        var res3 = res2.replace(re3, '\]');
                        var json = $noCon.parseJSON(res3);
                        for (var key in json) {
                            if (json.hasOwnProperty(key)) {
                                if (json[key].DTLID != "") {
                                    EditListRowsSub(json[key].DTLID, json[key].TRIAL, json[key].LEVEL, json[key].DESGID, json[key].EMPID, json[key].APPRVMANSTS, json[key].SUBEMPSTS, json[key].THRESMODE, json[key].PERIOD, json[key].APPRVPENSTS, json[key].TTCSTS, json[key].SMSSTS, json[key].SYSSTS, json[key].SUBORDNUM, json[key].NAME, json[key].DESGNAME, json[key].RO, json[key].MAILSTS, json[key].SKIPLVLSTS, json[key].SUBSTUTVAL, json[key].PARENTID, json[key].CANMODIFY);
                                }
                            }
                        }

                        if (parseInt(data.d[1]) <= 1) {
                            AddNewRowSub(null, trail, null, 0, null);

                            ChangeModifyUser();
                        }
                    }
                    else {
                        AddNewRowSub(null, trail, null, 0, null);

                        ChangeModifyUser();
                    }
                }

            });

            $("#divSubTable").fadeIn();

            if (document.getElementById("<%=Hiddenview.ClientID%>").value == "1" || document.getElementById("<%=hiddenConditionChng.ClientID%>").value == "1") {
                $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select").prop("disabled", true);
            }
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

                var FocusId = parseInt(RowNumMain) - 1;
                document.getElementById("ddlDesgIdT_" + FocusId).focus();
            }
            ChangeModifyUser();

            return false;
        }

        
        function ConfirmAlert() {
            if (ValidateWrkFlow() == false) {
                return false;
            }
            else {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to confirm this document workflow?",
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
                messageText: "Are you sure you want to Reopen this document workflow?",
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
                        if (document.getElementById("<%=hiddenReplaceApproverSts.ClientID%>").value != "1") {
                            document.getElementById("btnAdd_" + LastRowid).disabled = false;
                        }
                    }
                    else {
                        AddNewRowMain(null,null,null, null);
                    }
                    if (document.getElementById("cphMain_HiddenFieldCurrentDtlId").value == detailId) {
                        $("#divMainTable").fadeIn();
                        $("#divSubTable").fadeOut(100);
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

            BlurValue(RowNum);

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

        function ChangePeriod(obj, RowNum) {
            BlurNotNumber(obj);
            BlurValue(RowNum);
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

            BlurValue(RowNum);

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
            document.getElementById("<%=dlHrchy.ClientID%>").style.borderColor = "";
            $('#divddlHrchy').css('border-color', '');

            var NameWithoutReplace = document.getElementById("<%=txtName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtName.ClientID%>").value = replaceText2;

            var Name = document.getElementById("<%=txtName.ClientID%>").value.trim();
            var Deptmnt = document.getElementById("<%=lstDpt.ClientID%>").value;
            var Division = document.getElementById("<%=lstDiv.ClientID%>").value;
            var Hierchy = document.getElementById("<%=dlHrchy.ClientID%>").value;

            if (document.getElementById("<%=cbxApprvlRules.ClientID%>").checked == true) {
                if (ValidateConditions() == false) {
                    ret = false;
                }
            }

            if (ValidateTables() == false) {
                ret = false;
            }

            if (document.getElementById("<%=cbxApprvlRules.ClientID%>").checked == true) {
                if (ValidateApprvDtls() == false) {
                    ret = false;
                }
            }

            if (Hierchy == "" || Hierchy == "--Select--") {
                $('#divddlHrchy >input').css('border-color', 'red');
                $('#divddlHrchy >input').select();
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

                        var Level = document.getElementById("tdLevel" + validRowID).innerHTML;
                        var DesgntnId = document.getElementById("ddlDesgId_" + validRowID).value;
                        var EmpId = document.getElementById("ddlEmpId_" + validRowID).value;
                        var Threshold = document.getElementById("ddlThresId_" + validRowID).value;
                        var Period = document.getElementById("txtPeriod_" + validRowID).value.trim();

                        var ApprvlMndtry = 0;
                        var SubstuteEmp = 0;
                        if (document.getElementById("tdSubstituteVal_" + validRowID).value != "") {
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
                        var MailSts = 0;
                        if (document.getElementById("cbxMail_" + validRowID).checked == true) {
                            MailSts = 1;
                        }
                        var SkipLvlSts = 0;
                        if (document.getElementById("cbxSkipLvl_" + validRowID).checked == true) {
                            SkipLvlSts = 1;
                        }
                        var AprvrModify = 0;
                        if (document.getElementById("cbxCanModify_" + validRowID).checked == true) {
                            AprvrModify = 1;
                        }
                        var SubstituteVal = document.getElementById("tdSubstituteVal_" + validRowID).value;

                        var ParentId = document.getElementById("tdParentId" + validRowID).value;
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
                                MAILSTS: "" + MailSts + "",
                                SKIPLVLSTS: "" + SkipLvlSts + "",
                                APRVRMODIFY: "" + AprvrModify + "",
                                SUBSTUTVAL: "" + SubstituteVal + "",
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

                            var Level = document.getElementById("tdLevel" + validRowID).innerHTML;
                            var DesgntnId = document.getElementById("ddlDesgId_" + validRowID).value;
                            var EmpId = document.getElementById("ddlEmpId_" + validRowID).value;
                            var Threshold = document.getElementById("ddlThresId_" + validRowID).value;
                            var Period = document.getElementById("txtPeriod_" + validRowID).value;

                            var ApprvlMndtry = 0;
                            var SubstuteEmp = 0;
                            if (document.getElementById("tdSubstituteVal_" + validRowID).value != "") {
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
                            var MailSts = 0;
                            if (document.getElementById("cbxMail_" + validRowID).checked == true) {
                                MailSts = 1;
                            }
                            var SkipLvlSts = 0;
                            if (document.getElementById("cbxSkipLvl_" + validRowID).checked == true) {
                                SkipLvlSts = 1;
                            }
                            var AprvrModify = 0;
                            if (document.getElementById("cbxCanModify_" + validRowID).checked == true) {
                                AprvrModify = 1;
                            }
                            var SubstituteVal = document.getElementById("tdSubstituteVal_" + validRowID).value;

                            var ParentId = document.getElementById("tdParentId" + validRowID).value;
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
                                    MAILSTS: "" + MailSts + "",
                                    SKIPLVLSTS: "" + SkipLvlSts + "",
                                    APRVRMODIFY: "" + AprvrModify + "",
                                    SUBSTUTVAL: "" + SubstituteVal + "",
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
                                var SubstuteEmp = json[key].SUBEMPSTS;

                                var ApprvlMndtry = json[key].APPRVMANSTS;
                                var ApprvlPending = json[key].APPRVPENSTS;
                                var TTCExceed = json[key].TTCSTS;
                                var SMS = json[key].SMSSTS;
                                var System = json[key].SYSSTS;
                                var MailSts = json[key].MAILSTS;
                                var SkipLvlSts = json[key].SKIPLVLSTS;
                                var SubstituteVal = json[key].SUBSTUTVAL;

                                var ParentId = json[key].PARENTID;

                                if (json[key].PARENTID != "") {
                                    //alert("b4 " + ParentId);
                                    if ((HierchyRowParentId == "") || ((HierchyRowParentId != "") && (ParentId != HierchyRowParentId) && (DetailId != HierchyRowParentId))) {
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
                                                MAILSTS: "" + MailSts + "",
                                                SKIPLVLSTS: "" + SkipLvlSts + "",
                                                APRVRMODIFY: "0",
                                                SUBSTUTVAL: "" + SubstituteVal + "",
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

            if (document.getElementById("<%=HiddenFieldMainData.ClientID%>").value == "") {
                ret = false;
            }

            var m = parseInt(SubTable.rows.length) - 1;

            var idlast = "";
            if (SubTable.rows.length > 0) {
                idlast = $('#subTable tr:last').attr('id');
            }
            var LastId = "";
            if (idlast != "") {
                var res = idlast.split("_");
                LastId = res[1];
            }
            var LvlChk = "0";
            if (LastId != "") {
                LvlChk = document.getElementById("tdLevel" + LastId).innerHTML;
            }

            if (document.getElementById("cphMain_cbxSingleApproval").checked == true) {
                if ((parseInt(m) > 1) || (parseInt(m) == 1 && LvlChk != "0")) {
                    $("#divWarning").html("Single approval allowed only for single hierarchy level!");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    ret = false;
                }
            }

            return ret;
        }

        function ValidateConditions() {
            var ret = true;

            if (document.getElementById("<%=hiddenConditionChng.ClientID%>").value != "1") {
                var ListDept = $("#cphMain_lstDpt").val();
                var ListDiv = $("#cphMain_lstDiv").val();

                var FullValues = "";
                var Table = document.getElementById("tableApprvlRules");
                for (var x = 0; x < Table.rows.length; x++) {

                    if (Table.rows[x].cells[0].innerHTML != "") {

                        var validRowID = (Table.rows[x].cells[0].innerHTML);

                        var ddlConditions = document.getElementById("ddlConditions" + validRowID).value;
                        var ddlCndtnTypes = document.getElementById("ddlCndtnTypes" + validRowID).value;

                        var MinVal = "", MaxVal = "", CondtnValues = "";
                        if (ddlConditions == "1") {
                            MinVal = document.getElementById("txtMinVal" + validRowID).value;
                            MaxVal = document.getElementById("txtMaxVal" + validRowID).value;
                        }
                        else {
                            CondtnValues = document.getElementById("tdConditionValuesApprv" + validRowID).value;
                        }

                        if (FullValues == "") {
                            FullValues = ddlConditions + "%" + ddlCndtnTypes + "%" + MinVal + "%" + MaxVal + "%" + CondtnValues;
                        }
                        else {
                            FullValues = FullValues + "—" + ddlConditions + "%" + ddlCndtnTypes + "%" + MinVal + "%" + MaxVal + "%" + CondtnValues;
                        }
                    }
                }
                var OrgId = '<%= Session["ORGID"] %>';
                var CorpId = '<%= Session["CORPOFFICEID"] %>';
                var DocId = document.getElementById("<%=docsection.ClientID%>").value;
                var Id = document.getElementById("<%=HiddenFieldAprvlHierarchyId.ClientID%>").value;

                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_Document_Workflow.aspx/CheckConditionOverlaps",
                    data: '{CorpId: "' + CorpId + '",OrgId: "' + OrgId + '",Id: "' + Id + '",DocId: "' + DocId + '",ListDept: "' + ListDept + '",ListDiv: "' + ListDiv + '",FullValues: "' + FullValues + '"}',
                    dataType: "json",
                    success: function (data) {

                        if (data.d != "" && data.d != null) {
                            $("#ModalCondition").modal("show");
                            $("#divModalConditon").empty();
                            var Result = data.d;
                            var ResultSplit = Result.split('¦');
                            var RecRow = '';
                            for (var i = 0; i < ResultSplit.length; i++) {
                                var ResultValSplit = ResultSplit[i].split('‡');
                                RecRow += '<button class="btn btn_dfw b_dfw1" onclick="return OpenWrkflow(\'' + ResultValSplit[0] + '\');" >' + ResultValSplit[1] + '</button>';
                            }
                            $("#divModalConditon").append(RecRow);
                            ret = false;
                        }
                    }
                });
            }

            return ret;
        }

        function OpenWrkflow(Id) {
            var nWindow = window.open('/Master/gen_Document_Workflow/gen_Document_Workflow.aspx?Id=' + Id + '&VId=1', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
            nWindow.focus();
            return false;
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

            if (document.getElementById("cphMain_HiddenFieldCurrentLevel").value == Level) {
                FrecRow += '<tr id="mainRowId_' + RowNumMain + '" class="tr_act">';
            }
            else {
                FrecRow += '<tr id="mainRowId_' + RowNumMain + '" class="">';
            }

            FrecRow += '<td style="display: none" >' + RowNumMain + '</td>';
            FrecRow += '<td id="dbId_' + RowNumMain + '" style="display: none" >' + DtlId + '</td>';

            if (Level != "" && Level != null && Level != "null") {
                FrecRow += '<td id="tdLevel' + RowNumMain + '">' + Level + '</td>';
            }
            else {
                var CurrentLevel = document.getElementById("cphMain_HiddenFieldCurrentLevel").value;
                var NewLevel = parseInt(CurrentLevel) + 1;
                FrecRow += '<td id="tdLevel' + RowNumMain + '">' + NewLevel + '</td>';
            }
            FrecRow += '<td><input placeholder="-Select-" id="ddlDesgIdT_' + RowNumMain + '" onchange="return changeDesgMain(\'' + RowNumMain + '\');"  maxlength="100" onkeypress="return selectorToAutocompleteTextBox(' + RowNumMain + ',0);" onkeydown="return selectorToAutocompleteTextBox(' + RowNumMain + ',0);" onkeyup="return selectorToAutocompleteTextBox(' + RowNumMain + ',0);" type="text" class="form-control fg2_inp2 fg2_inp3 fg_chs1 in_flw"></td>';
            FrecRow += '<td style="display: none;"><input id="ddlDesgId_' + RowNumMain + '" value="-Select-"></td>';

            FrecRow += '<td><input placeholder="-Select-" id="ddlEmpIdT_' + RowNumMain + '" onchange="return changeEmpMain(\'' + RowNumMain + '\');"  maxlength="100" onkeypress="return selectorToAutocompleteTextBox(' + RowNumMain + ',1);" onkeydown="return selectorToAutocompleteTextBox(' + RowNumMain + ',1);" onkeyup="return selectorToAutocompleteTextBox(' + RowNumMain + ',1);" type="text" class="form-control fg2_inp2 fg2_inp3 fg_chs1 in_flw"></td>';
            FrecRow += '<td style="display: none;"><input id="ddlEmpId_' + RowNumMain + '" value="-Select-"></td>';

            FrecRow += '<td style="display:none;">';
            FrecRow += '<div class="check1">';
            FrecRow += '<div class=""><label class="switch">';
            FrecRow += '<input id="cbxAprMand_' + RowNumMain + '" type="checkbox" onchange="BlurValue(\'' + RowNumMain + '\')">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';

            //FrecRow += '<td id="tdNumsubord_' + RowNumMain + '">' + SubordNum + '</td>';
            //FrecRow += '<td>';
            //if (SubordNum != "0" && SubordNum != null && SubordNum != "") {
            //    if (DtlId != "" && DtlId != null && b == "0") {
            //        FrecRow += '<button id="btnSubord_' + RowNumMain + '" onclick="return FuctionOrganize(\'' + DtlId + '\',\'' + Level + '\',\'' + Name + '\',\'' + Trail + '\');" class="btn act_btn bn6 notv" title="Subordinates"><i class="fa fa-cloud-download" aria-hidden="true"></i></button>';
            //    }
            //    else if (DtlId != "" && DtlId != null && b == "1") {
            //        FrecRow += '<button id="btnSubord_' + RowNumMain + '" onclick="return FuctionOrganize1(\'' + DtlId + '\',\'' + Level + '\',\'' + Name + '\',\'' + Trail + '\');" class="btn act_btn bn6 notv" title="Subordinates"><i class="fa fa-cloud-download" aria-hidden="true"></i></button>';
            //    }
            //}
            //else {
            //    FrecRow += '<button disabled id="btnSubord_' + RowNumMain + '" class="btn act_btn bn6" title="Subordinates"><i class="fa fa-cloud-download" aria-hidden="true"></i></button>';
            //}
            //FrecRow += '</td>';

            FrecRow += '<td>';
            FrecRow += '<button id="cbxSubstSts_' + RowNumMain + '" class="btn act_btn bn7 notv" title="Substitute Employees" data-toggle="modal" data-target="#ModalSubstituteEmp" onclick="return OpenSubstituteModal(\'' + RowNumMain + '\');" onchange="BlurValue(\'' + RowNumMain + '\')"><i class="fa fa-exchange" aria-hidden="true"></i></button>';
            FrecRow += '<td style="display: none;"><input id="tdSubstituteVal_' + RowNumMain + '" value=""></td>';
            FrecRow += '</td>';

            FrecRow += '<td>';
            FrecRow += '<div class="input-group ing2 dh_inp">';
            FrecRow += '<select id="ddlThresId_' + RowNumMain + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" onchange="BlurValue(\'' + RowNumMain + '\')">';
            FrecRow += '<option value="0">Days</option>';
            FrecRow += '<option value="1">Hours</option>';
            FrecRow += '</select>';
            FrecRow += '</div>';
            FrecRow += '<div class="input-group ing1">';
            FrecRow += '<input id="txtPeriod_' + RowNumMain + '" onchange="return ChangePeriod(\'txtPeriod_' + RowNumMain + '\',\'' + RowNumMain + '\')" maxlength="3" onkeydown="return isNumber(event)" onkeydown="return isNumber(event)" type="text" class="form-control fg2_inp2 tr_r" >';
            FrecRow += '</div>';
            FrecRow += '</td>';

            FrecRow += '<td class="">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            if (document.getElementById("<%=cbxaprpnd.ClientID%>").checked == true) {
                FrecRow += '<input id="cbxAprPen_' + RowNumMain + '" type="checkbox" checked="true" onchange="BlurValue(\'' + RowNumMain + '\')">';
            }
            else {
                FrecRow += '<input id="cbxAprPen_' + RowNumMain + '" type="checkbox" onchange="BlurValue(\'' + RowNumMain + '\')">';
            }
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            if (document.getElementById("<%=cbxTmExd.ClientID%>").checked == true) {
                FrecRow += '<input id="cbxTtcExc_' + RowNumMain + '" type="checkbox" checked="true" onchange="BlurValue(\'' + RowNumMain + '\')">';
            }
            else {
                FrecRow += '<input id="cbxTtcExc_' + RowNumMain + '" type="checkbox" onchange="BlurValue(\'' + RowNumMain + '\')">';
            }
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="">';
            FrecRow += '<div class="check1 tb_ck1"><div class=""><label class="switch">';
            if (document.getElementById("<%=cbxnt.ClientID%>").checked == true) {
                FrecRow += '<input id="cbxSys_' + RowNumMain + '" type="checkbox" checked="true" onchange="BlurValue(\'' + RowNumMain + '\')">';
            }
            else {
                FrecRow += '<input id="cbxSys_' + RowNumMain + '" type="checkbox" onchange="IncrmntConfrmCounter();">';
            }
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="">';
            FrecRow += '<div class="check1 tb_ck1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxMail_' + RowNumMain + '" type="checkbox"  onchange="BlurValue(\'' + RowNumMain + '\')" onkeypress="return DisableEnter(event)">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="">';
            FrecRow += '<div class="check1 tb_ck1"><div class=""><label class="switch">';
            if (document.getElementById("<%=cbxsm.ClientID%>").checked == true) {
                FrecRow += '<input id="cbxSms_' + RowNumMain + '" type="checkbox" checked=="true" onchange="BlurValue(\'' + RowNumMain + '\')">';
            }
            else {
                FrecRow += '<input id="cbxSms_' + RowNumMain + '" type="checkbox" onchange="BlurValue(\'' + RowNumMain + '\')">';
            }
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="">';
            FrecRow += '<div class="check1 tb_ck1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxCanModify_' + RowNumMain + '" type="checkbox" class="clsModify" onchange="BlurValue(\'' + RowNumMain + '\')" onkeypress="return DisableEnter(event)">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="">';
            FrecRow += '<div class="check1"><div class=""><label class="switch">';
            FrecRow += '<input id="cbxSkipLvl_' + RowNumMain + '" type="checkbox"  onchange="BlurValue(\'' + RowNumMain + '\')" onkeypress="return DisableEnter(event)">';
            FrecRow += '<span class="slider_tog round"></span></label></div></div>';
            FrecRow += '</td>';


            FrecRow += '<td class="td1">';
            FrecRow += '<div class="btn_stl1">';
            FrecRow += '<button id="btnAdd_' + RowNumMain + '" onclick="return FuctionAddSub(\'' + RowNumMain + '\',\'' + newtrail + '\');" class="btn act_btn bn1 subAdd" title="Add"><i class="fa fa-plus-circle"></i></button>';
            FrecRow += '<button disabled id="btnSave_' + RowNumMain + '" onclick="return FuctionSaveMain(\'' + RowNumMain + '\');" class="btn act_btn bn2" title="Save"><i class="fa fa-save"></i></button>';
            FrecRow += '<button id="btnDele_' + RowNumMain + '" onclick="return FuctionDeleSub(\'' + RowNumMain + '\');" class="btn act_btn bn3" title="Delete"><i class="fa fa-trash"></i></button>';
            FrecRow += '</div>';
            FrecRow += '</td>';

            FrecRow += '<td id="dblevel_' + RowNumMain + '" style="display: none" >' + Level + '</td>';
            FrecRow += '<td id="trail_' + RowNumMain + '" style="display: none" >' + Trail + '</td>';
            FrecRow += '<td id="ro_' + RowNumMain + '" style="display: none" ></td>';

            var ParentId = 0;
            if (document.getElementById("cphMain_HiddenFieldCurrentDtlId").value != "") {
                ParentId = document.getElementById("cphMain_HiddenFieldCurrentDtlId").value;
            }
            FrecRow += '<td style="display: none;"><input id="tdParentId' + RowNumMain + '" value="' + ParentId + '"></td>';

            FrecRow += '</tr>';

            jQuery('#subTable').append(FrecRow);

            document.getElementById("ddlDesgIdT_" + RowNumMain).focus();

            $('.subAdd').attr('disabled', 'disabled');
            var LastRowid = $("#subTable tr:last td:first").html();

            if (document.getElementById("<%=hiddenReplaceApproverSts.ClientID%>").value == "1") {
                document.getElementById("btnAdd_" + RowNumMain).disabled = true;
                document.getElementById("btnDele_" + RowNumMain).disabled = true;
            }
            else {
                document.getElementById("btnAdd_" + LastRowid).disabled = false;
            }

            if (document.getElementById("<%=hiddenConditionChng.ClientID%>").value == "1") {
                document.getElementById("btnDele_" + RowNumMain).disabled = true;
                document.getElementById("btnAdd_" + RowNumMain).disabled = true;
                document.getElementById("ddlDesgIdT_" + RowNumMain).disabled = true;
                document.getElementById("ddlEmpIdT_" + RowNumMain).disabled = true;
                document.getElementById("ddlThresId_" + RowNumMain).disabled = true;
                document.getElementById("txtPeriod_" + RowNumMain).disabled = true;
                document.getElementById("cbxAprPen_" + RowNumMain).disabled = true;
                document.getElementById("cbxTtcExc_" + RowNumMain).disabled = true;
                document.getElementById("cbxSys_" + RowNumMain).disabled = true;
                document.getElementById("cbxMail_" + RowNumMain).disabled = true;
                document.getElementById("cbxSms_" + RowNumMain).disabled = true;
                document.getElementById("cbxCanModify_" + RowNumMain).disabled = true;
                document.getElementById("cbxSkipLvl_" + RowNumMain).disabled = true;
            }

            RowNumMain++;
            return false;
        }

        function EditListRowsSub(DTLID, TRAIL, LEVEL, DESGID, EMPID, APPRVMANSTS, SUBEMPSTS, THRESMODE, PERIOD, APPRVPENSTS, TTCSTS, SMSSTS, SYSSTS, SUBORDNUM, NAME, DESGNAME, RO, MAILSTS, SKIPLVLSTS, SUBSTUTVAL, PARENTID, CANMODIFY) {

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

            if (MAILSTS == "1") {
                document.getElementById("cbxMail_" + validRowID).checked = true;
            }
            if (SKIPLVLSTS == "1") {
                document.getElementById("cbxSkipLvl_" + validRowID).checked = true;
            }
            if (CANMODIFY == "1") {
                document.getElementById("cbxCanModify_" + validRowID).checked = true;
            }
            document.getElementById("tdSubstituteVal_" + validRowID).value = SUBSTUTVAL;
            document.getElementById("tdParentId" + validRowID).value = PARENTID;

            if (document.getElementById("cphMain_HiddenFieldCurrentLevel").value == LEVEL) {
                document.getElementById("btnDele_" + validRowID).disabled = true;
                document.getElementById("btnAdd_" + validRowID).disabled = false;
                document.getElementById("btnAdd_" + validRowID).innerHTML = "<i class=\"fa fa-edit\"></i>";
                $("#btnAdd_" + validRowID).attr("onclick", "return FunctionEditMain('" + validRowID + "')");
                $("#btnAdd_" + validRowID).removeClass().addClass("btn act_btn bn1");
                $("#btnAdd_" + validRowID).attr("title", "Edit");
            }

            if (document.getElementById("<%=hiddenReplaceApproverSts.ClientID%>").value == "1") {
                document.getElementById("btnAdd_" + validRowID).disabled = true;
                document.getElementById("btnDele_" + validRowID).disabled = true;
            }

        }

        function FuctionAddSub(RowNum, trail) {

            if (checkMainRow(RowNum) == true) {
                IncrmntConfrmCounter();
                AddNewRowSub(null, trail, null, 0, null);

                var FocusId = parseInt(RowNumMain) - 1;
                document.getElementById("ddlDesgIdT_" + FocusId).focus();
            }
            ChangeModifyUser();

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
                        if (document.getElementById("<%=hiddenReplaceApproverSts.ClientID%>").value != "1") {
                            document.getElementById("btnAdd_" + LastRowid).disabled = false;
                        }
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
                        $("#divMainTable").fadeIn();
                        $("#divSubTable").fadeOut(100);
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
                $("#divMainTable").fadeIn();
                $("#divSubTable").fadeOut(100);
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

    <script>

        function OpenSubstituteModal(MainRowId) {

            $("#tableSubstituteEmps").empty();
            EditRowsSubstute(MainRowId);

            $('#ModalSubstituteEmp').on('shown.bs.modal', function () {

                var idlast = $('#tableSubstituteEmps tr:last').attr('id');
                var LastId = "";
                if (idlast != "") {
                    var res = idlast.split("_");
                    LastId = res[1];
                }
                document.getElementById("ddlDesgSub_" + LastId).focus();

                if (document.getElementById("<%=HiddenFieldView.ClientID%>").value == "1" || document.getElementById("<%=hiddenConditionChng.ClientID%>").value == "1") {
                    document.getElementById("btnSaveSubstitute").disabled = true;
                }
            });
            return false;
        }

        function selectorToAutocompleteTextBoxSubstitute(x, mode, event) {

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
                    $au("#ddlDesgSub_" + x).autocomplete({
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
                        //    $("#ddlDesgSub_" + x).val(ui.item.label);
                        //    $("#ddlDesgSubId_" + x).val(ui.item.id);
                        //    return false;
                        //},
                        select: function (e, i) {
                            document.getElementById("ddlDesgSubId_" + x).value = i.item.val;
                            document.getElementById("ddlDesgSub_" + x).value = i.item.label;
                        },
                        change: function (event, ui) {
                            if (ui.item) {
                            }
                            else {
                                document.getElementById("ddlDesgSubId_" + x).value = "-Select-";
                                document.getElementById("ddlDesgSub_" + x).value = "";
                            }
                        },
                        minLength: 1

                    });
                }
                else {
                    var DesgId = document.getElementById("ddlDesgSubId_" + x).value;
                    if (DesgId != "-Select-") {
                        $au("#ddlEmpSub_" + x).autocomplete({
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
                            //    $("#ddlEmpSub_" + x).val(ui.item.label);
                            //    $("#ddlEmpSubId_" + x).val(ui.item.id);
                            //    return false;
                            //},
                            select: function (e, i) {
                                document.getElementById("ddlEmpSubId_" + x).value = i.item.val;
                                document.getElementById("ddlEmpSub_" + x).value = i.item.label;
                            },
                            change: function (event, ui) {
                                if (ui.item) {
                                }
                                else {
                                    document.getElementById("ddlEmpSubId_" + x).value = "-Select-";
                                    document.getElementById("ddlEmpSub_" + x).value = "";
                                }
                            },
                            minLength: 1

                        });
                    }
                }
            }
        }

        var CountSub = 0;

        function AddMoreRowsSubstute(Mode, MainRowId) {

            if (Mode != "0") {
                CountSub++;
            }

            var RecRow = '';

            RecRow += '<tr id="trRowSubId_' + CountSub + '" class="tr1">';
            RecRow += '<td id="tdSubId' + CountSub + '" style="display: none;">' + CountSub + '</td>';
            RecRow += '<td>';
            RecRow += '<input placeholder="-Select-" id="ddlDesgSub_' + CountSub + '"  maxlength="100" onkeypress="return selectorToAutocompleteTextBoxSubstitute(' + CountSub + ',0,event);" onkeydown="return selectorToAutocompleteTextBoxSubstitute(' + CountSub + ',0,event);" onkeyup="return selectorToAutocompleteTextBoxSubstitute(' + CountSub + ',0,event);" type="text" class="form-control fg2_inp2 fg_chs1 in_br" autocomplete="off">';
            RecRow += '<td style="display: none;"><input id="ddlDesgSubId_' + CountSub + '" value="-Select-"></td>';
            RecRow += '</td>';
            RecRow += '<td>';
            RecRow += '<input placeholder="-Select-" id="ddlEmpSub_' + CountSub + '"  maxlength="100" onkeypress="return selectorToAutocompleteTextBoxSubstitute(' + CountSub + ',1,event);" onkeydown="return selectorToAutocompleteTextBoxSubstitute(' + CountSub + ',1,event);" onkeyup="return selectorToAutocompleteTextBoxSubstitute(' + CountSub + ',1,event);" type="text" class="form-control fg2_inp2 fg_chs1 in_br" autocomplete="off">';
            RecRow += '<td style="display: none;"><input id="ddlEmpSubId_' + CountSub + '" value="-Select-"></td>';
            RecRow += '</td>';
            RecRow += '<td class="td1">';
            RecRow += '<div class="btn_stl1">';
            RecRow += '<button id="btnAddSub' + CountSub + '" class="btn act_btn bn2" title="Add" onclick="return CheckaddMoreRowsSub(' + CountSub + ',' + MainRowId + ');"><i class="fa fa-plus-circle"></i></button>';
            RecRow += '<button id="btnDeleteSub' + CountSub + '" class="btn act_btn bn3" title="Delete" onclick="return RemoveRowsSub(' + CountSub + ',' + MainRowId + ');"><i class="fa fa-trash"></i></button>';
            RecRow += '</div>';
            RecRow += '</td>';
            RecRow += '<td id="tdMainRowId' + CountSub + '" style="display: none;">' + MainRowId + '</td>';
            RecRow += '<td id="tdEvtSub' + CountSub + '" style="width:0%;display: none;">INS</td>';
            RecRow += '<td id="tdDtlIdSub' + CountSub + '" style="width:0%;display: none;">0</td>';
            RecRow += '</tr>';

            $("#tableSubstituteEmps").append(RecRow);

            if (document.getElementById("<%=HiddenFieldView.ClientID%>").value == "1" || document.getElementById("<%=hiddenConditionChng.ClientID%>").value == "1") {
                document.getElementById("ddlDesgSub_" + CountSub).disabled = true;
                document.getElementById("ddlEmpSub_" + CountSub).disabled = true;
                document.getElementById("btnAddSub" + CountSub).disabled = true;
                document.getElementById("btnDeleteSub" + CountSub).disabled = true;
            }
        }


        function EditRowsSubstute(MainRowId) {

            var SubstituteDtls = document.getElementById("tdSubstituteVal_" + MainRowId).value;

            if (SubstituteDtls != "") {
                var SubstituteDtlsSplit = SubstituteDtls.split('¦');

                for (var Count = 0; Count < SubstituteDtlsSplit.length; Count++) {

                    CountSub = Count;
                    AddMoreRowsSubstute(Count, MainRowId);

                    var SubstituteVals = SubstituteDtlsSplit[Count].split('‡');

                    var Desg = SubstituteVals[0];
                    var Emp = SubstituteVals[1];
                    var DesgName = SubstituteVals[2];
                    var EmpName = SubstituteVals[3];
                    var DtlId = SubstituteVals[4];

                    document.getElementById("ddlDesgSubId_" + Count).value = Desg;
                    document.getElementById("ddlEmpSubId_" + Count).value = Emp;
                    document.getElementById("ddlDesgSub_" + Count).value = DesgName;
                    document.getElementById("ddlEmpSub_" + Count).value = EmpName;
                    document.getElementById('tdDtlIdSub' + Count).innerHTML = DtlId;

                    document.getElementById("btnAddSub" + Count).disabled = true;

                    if (document.getElementById("<%=HiddenFieldView.ClientID%>").value == "1" || document.getElementById("<%=hiddenConditionChng.ClientID%>").value == "1") {
                        document.getElementById("ddlDesgSub_" + Count).disabled = true;
                        document.getElementById("ddlEmpSub_" + Count).disabled = true;
                        document.getElementById("btnAddSub" + Count).disabled = true;
                        document.getElementById("btnDeleteSub" + Count).disabled = true;
                    }
                }

                var LastRowId = parseInt(SubstituteDtlsSplit.length) - 1;
                if (document.getElementById("<%=HiddenFieldView.ClientID%>").value != "1") {
                    document.getElementById("btnAddSub" + LastRowId).disabled = false;
                }
            }
            else {
                AddMoreRowsSubstute(Count, MainRowId);
            }
        }

        function CheckaddMoreRowsSub(x, MainRowId) {

            if (CheckAndHighlightSub(x, 1, "") == true) {

                AddMoreRowsSubstute(1, MainRowId);
                var idlast = $('#tableSubstituteEmps tr:last').attr('id');
                var LastId = "";
                if (idlast != "") {
                    var res = idlast.split("_");
                    LastId = res[1];
                }
                document.getElementById("ddlDesgSub_" + LastId).focus();
                document.getElementById("btnAddSub" + x).disabled = true;
                return false;
            }
            else {
                return false;
            }

            return false;
        }

        function CheckAndHighlightSub(x, Mode, obj) {

            var ret = true;

            var Table = document.getElementById("tableSubstituteEmps");

            document.getElementById("ddlDesgSub_" + x).style.borderColor = "";
            document.getElementById("ddlEmpSub_" + x).style.borderColor = "";

            if (Mode == "0") {

                if ((obj == "ddlEmpSub_" + x) && (document.getElementById("ddlEmpSub_" + x).value.trim() == "")) {
                    document.getElementById("ddlEmpSub_" + x).style.borderColor = "Red";
                    ret = false;
                }
                if ((obj == "ddlDesgSub_" + x) && (document.getElementById("ddlDesgSub_" + x).value.trim() == "")) {
                    document.getElementById("ddlDesgSub_" + x).style.borderColor = "Red";
                    ret = false;
                }
            }
            else {
                if (document.getElementById("ddlEmpSub_" + x).value.trim() == "") {
                    document.getElementById("ddlEmpSub_" + x).style.borderColor = "Red";
                    document.getElementById("ddlEmpSub_" + x).focus();
                    ret = false;
                }
                if (document.getElementById("ddlDesgSub_" + x).value.trim() == "") {
                    document.getElementById("ddlDesgSub_" + x).style.borderColor = "Red";
                    document.getElementById("ddlDesgSub_" + x).focus();
                    ret = false;
                }
            }
            var Flag = 0;
            if (ret == true) {
                if (CheckSubDuplication(x) == false) {
                    Flag++;
                    ret = false;
                }
            }

            if (ret == false && Flag == 0) {
                $("#danger-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
                });
                ret = false;
            }

            return ret;
        }

        function CheckSubDuplication(x) {

            var ret = true;
            var Table = document.getElementById("tableSubstituteEmps");

            for (var i = 0; i < Table.rows.length; i++) {
                var xLoop = (Table.rows[i].cells[0].innerHTML);
                var xLoopId = "";
                var Id = "";
                xLoopId = $("#ddlEmpSub_" + xLoop).val();
                Id = $("#ddlEmpSub_" + x).val();
                if (xLoop != x) {
                    if (xLoopId == Id) {
                        $noCon("#danger-alert").html("Substitute employees should not be duplicated.");
                        $noCon("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
                        });
                        $noCon("#ddlEmpSub_" + x).css("borderColor", "red");
                        $noCon("#ddlEmpSub_" + x).select();
                        $noCon(window).scrollTop(0);
                        return false;
                    }
                }
            }
            return ret;
        }

        function RemoveRowsSub(x, MainRowId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to cancel selected substitute employee?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    jQuery('#trRowSubId_' + x).remove();

                    var idlast = $('#tableSubstituteEmps tr:last').attr('id');

                    if (idlast != undefined) {
                        var LastId = "";
                        if (idlast != "") {
                            var res = idlast.split("_");
                            LastId = res[1];
                        }
                        if (document.getElementById("<%=HiddenFieldView.ClientID%>").value != "1") {
                            document.getElementById("btnAddSub" + LastId).disabled = false;
                        }
                    }

                    var Table = document.getElementById("tableSubstituteEmps");
                    if (Table.rows.length < 1) {
                        AddMoreRowsSubstute(0, MainRowId);
                    }
                }
                else {
                    return false;
                }
            });
            return false;
        }

        function ValidateSubstituteDtls() {

            var ret = true;
            var flag = 0;

            var Table = document.getElementById("tableSubstituteEmps");

            for (var x = 0; x < Table.rows.length; x++) {

                if (Table.rows[x].cells[0].innerHTML != "") {

                    var validRowID = (Table.rows[x].cells[0].innerHTML);

                    var Desg = document.getElementById("ddlDesgSub_" + validRowID).value.trim();
                    var Emp = document.getElementById("ddlEmpSub_" + validRowID).value.trim();

                    if (Table.rows.length > 0 && (Desg != "" || Emp != "")) {
                        if (CheckAndHighlightSub(validRowID, 1, "") == false) {
                            ret = false;
                        }
                        flag = 1;
                    }

                }
            }

            if (ret == true) {

                var tbClientTotalValues = '';
                tbClientTotalValues = [];

                var RowID = (Table.rows[0].cells[0].innerHTML);
                var MainRowId = document.getElementById("tdMainRowId" + RowID).innerHTML;

                document.getElementById("tdSubstituteVal_" + MainRowId).value = "";

                for (var x = 0; x < Table.rows.length; x++) {

                    if (Table.rows[x].cells[0].innerHTML != "") {

                        var validRowID = (Table.rows[x].cells[0].innerHTML);

                        var DesgId = document.getElementById("ddlDesgSubId_" + validRowID).value;
                        var EmpId = document.getElementById("ddlEmpSubId_" + validRowID).value;
                        var DesgName = document.getElementById("ddlDesgSub_" + validRowID).value.trim();
                        var EmpName = document.getElementById("ddlEmpSub_" + validRowID).value.trim();
                        var DetailId = document.getElementById("tdDtlIdSub" + validRowID).innerHTML;

                        if (document.getElementById("tdSubstituteVal_" + MainRowId).value == "") {
                            document.getElementById("tdSubstituteVal_" + MainRowId).value = DesgId + "‡" + EmpId + "‡" + DesgName + "‡" + EmpName + "‡" + DetailId;
                        }
                        else {
                            document.getElementById("tdSubstituteVal_" + MainRowId).value = document.getElementById("tdSubstituteVal_" + MainRowId).value + "¦" + DesgId + "‡" + EmpId + "‡" + DesgName + "‡" + EmpName + "‡" + DetailId;
                        }

                    }
                }

                $('#ModalSubstituteEmp').modal('hide');
            }

            return ret;
        }

        function BlurValue(RowNum) {
            if (document.getElementById("<%=HiddenFieldAprvlHierarchyId.ClientID%>").value != "0") {
                if (document.getElementById("<%=hiddenHrchyChngdMode.ClientID%>").value != "1") {
                    document.getElementById("btnSave_" + RowNum).disabled = false;
                }
            }
            IncrmntConfrmCounter();
            IncrmntConfrmCounterEdit();
        }

        function FuctionSaveMain(validRowID) {

            var ret = true;
            if (checkMainRow(validRowID) == false) {
                ret = false;
            }

            var LevelChk = document.getElementById("tdLevel" + validRowID).innerHTML;
            if (document.getElementById("cphMain_cbxSingleApproval").checked == true && LevelChk != "0") {
                ret = false;
            }

            if (ret == true) {

                var Id = document.getElementById("<%=HiddenFieldAprvlHierarchyId.ClientID%>").value;
                var OrgId = '<%= Session["ORGID"] %>';
                var CorpId = '<%= Session["CORPOFFICEID"] %>';
                var UserId = '<%= Session["USERID"] %>';

                var Name = document.getElementById("<%=txtName.ClientID%>").value;
                var DocId = document.getElementById("<%=docsection.ClientID%>").value;
                var ApprvlTrnsfr = 0;
                if (document.getElementById("<%=cbxapr.ClientID%>").checked == true) {
                    ApprvlTrnsfr = 1;
                }
                var ApprvlModify = 0;
                if (document.getElementById("<%=cbxmdfy.ClientID%>").checked == true) {
                    ApprvlModify = 1;
                }
                var Descrptn = document.getElementById("<%=txtDescr.ClientID%>").value;
                var Priority = 0;
                if (document.getElementById("<%=rbHigh.ClientID%>").checked == true) {
                    Priority = 1;
                }
                var Status = 0;
                if (document.getElementById("<%=cbxsts.ClientID%>").checked == true) {
                    Status = 1;
                }
                var Dept = document.getElementById("<%=lstDpt.ClientID%>").value;
                var Divsn = document.getElementById("<%=lstDiv.ClientID%>").value;
                var HrchyId = document.getElementById("<%=dlHrchy.ClientID%>").value;

                var StrtDate = document.getElementById("<%=dte_1_a.ClientID%>").value;
                var EndDate = document.getElementById("<%=dte_1.ClientID%>").value;
                var MajrtyApprvl = 0;
                if (document.getElementById("<%=cbxMajorityApprvl.ClientID%>").checked == true) {
                    MajrtyApprvl = 1;
                }
                var SingleApprvl = 0;
                if (document.getElementById("<%=cbxSingleApproval.ClientID%>").checked == true) {
                    SingleApprvl = 1;
                }
                var ApprvlRuleSts = 0;
                if (document.getElementById("<%=cbxApprvlRules.ClientID%>").checked == true) {
                    ApprvlRuleSts = 1;
                }

                var HrchyChngdMode = document.getElementById("<%=hiddenHrchyChngdMode.ClientID%>").value;
                var ReplaceApprvrSts = document.getElementById("<%=hiddenReplaceApproverSts.ClientID%>").value;

                var tbClientJobSheduling = '';
                tbClientJobSheduling = [];

                var dtlId = document.getElementById("dbId_" + validRowID).innerHTML;
                var DesgId = document.getElementById("ddlDesgId_" + validRowID).value;
                var DesgName = document.getElementById("ddlDesgIdT_" + validRowID).value;
                var EmpId = document.getElementById("ddlEmpId_" + validRowID).value;
                var EmpName = document.getElementById("ddlEmpIdT_" + validRowID).value;
                var AprvMandSts = 0;
                var subsEmpSts = 0;
                if (document.getElementById("tdSubstituteVal_" + validRowID).value != "") {
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
                var MailSts = 0;
                if (document.getElementById("cbxMail_" + validRowID).checked == true) {
                    MailSts = 1;
                }
                var SmsSts = 0;
                if (document.getElementById("cbxSms_" + validRowID).checked == true) {
                    SmsSts = 1;
                }
                var CanModifySts = 0;
                if (document.getElementById("cbxCanModify_" + validRowID).checked == true) {
                    CanModifySts = 1;
                }
                var SkipLvlSts = 0;
                if (document.getElementById("cbxSkipLvl_" + validRowID).checked == true) {
                    SkipLvlSts = 1;
                }
                var SubstituteVal = document.getElementById("tdSubstituteVal_" + validRowID).value;

                //var level = parseInt(document.getElementById("cphMain_HiddenFieldCurrentLevel").value)+1;
                var level = document.getElementById("tdLevel" + validRowID).innerHTML;
                var ParentId = document.getElementById("tdParentId" + validRowID).value;

                var objData = {};
                objData.CorpId = CorpId;
                objData.OrgId = OrgId;
                objData.UserId = UserId;
                objData.Id = Id;
                objData.Name = Name;
                objData.DocId = DocId;
                objData.ApprvlTrnsfr = ApprvlTrnsfr;
                objData.ApprvlModify = ApprvlModify;
                objData.Descrptn = Descrptn;
                objData.Priority = Priority;
                objData.Status = Status;
                objData.Dept = Dept;
                objData.Divsn = Divsn;
                objData.HrchyId = HrchyId;
                objData.StrtDate = StrtDate;
                objData.EndDate = EndDate;
                objData.MajrtyApprvl = MajrtyApprvl;
                objData.SingleApprvl = SingleApprvl;
                objData.HrchyChngdMode = HrchyChngdMode;
                objData.ReplaceApprvrSts = ReplaceApprvrSts

                objData.DTLID = dtlId;
                objData.LEVEL = level;
                objData.DESGID = DesgId;
                objData.EMPID = EmpId;
                objData.APPRVMANSTS = AprvMandSts;
                objData.SUBEMPSTS = subsEmpSts;
                objData.THRESMODE = ThresMode;
                objData.PERIOD = Period;
                objData.APPRVPENSTS = AprvPendSts;
                objData.TTCSTS = TtcSts;
                objData.SMSSTS = SmsSts;
                objData.SYSSTS = SystemSts;
                objData.MAILSTS = MailSts;
                objData.APRVRMODIFY = CanModifySts;
                objData.SKIPLVLSTS = SkipLvlSts;
                objData.SUBSTUTVAL = SubstituteVal;
                objData.PARENTID = ParentId;

                $.ajax({
                    async: false,
                    type: 'POST',
                    data: JSON.stringify(objData),
                    dataType: 'json',
                    contentType: "application/json; charset=utf-8",
                    url: "gen_Document_Workflow.aspx/SaveDetails",
                    success: function (data) {
                        if (data.d != "" && data.d != "error") {
                            document.getElementById("dbId_" + validRowID).innerHTML = data.d;
                            SuccessUpd();
                            document.getElementById("btnSave_" + validRowID).disabled = true;

                            EditRowsSubstute(validRowID);
                            LoadHierachy(Id);
                        }
                    },
                    failure: function (data) {
                        alert("error");
                    }
                });
            }
            else {

                if (document.getElementById("cphMain_cbxSingleApproval").checked == true && LevelChk != "0") {
                    $("#divWarning").html("Single approval allowed only for single hierarchy level!");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                }
                else {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    $(window).scrollTop(0);
                }
            }
            return false;
        }

        function LoadHierachy(Id) {

            $.ajax({
                async: false,
                type: 'POST',
                data: '{Id: "' + Id + '"}',
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                url: "gen_Document_Workflow.aspx/LoadHierarchy",
                success: function (data) {
                    document.getElementById("<%=myTab1.ClientID%>").innerHTML = data.d;
                },
                failure: function (data) {
                    alert("error");
                }
            });
        }

        function ChangeModifyUser() {

            if (document.getElementById("cphMain_cbxmdfy").checked == true) {
                $('.clsModify').prop('checked', true);
                $('.clsModify').attr('disabled', 'disabled');
            }
            else {
                $('.clsModify').prop('checked', false);
                $('.clsModify').removeAttr('disabled');
            }
        }
    </script>

    <script>

        function ChangeApprovalRules() {

            if (document.getElementById("cphMain_cbxApprvlRules").checked == true) {
                document.getElementById("divTableApprvlRules").style.display = "block";
                LoadApprovalRules(0);
            }
            else {
                document.getElementById("divTableApprvlRules").style.display = "none";
            }

            if (document.getElementById("<%=Hiddenview.ClientID%>").value == "1" || document.getElementById("<%=hiddenConditionChng.ClientID%>").value == "1") {
                document.getElementById("cphMain_cbxApprvlRules").style.pointerEvents = "none";
            }
        }

        var CountApprv = 0;

        function LoadApprovalRules(Mode) {

            if (Mode != "0") {
                IncrmntConfrmCounter();
            }

            CountApprv = 0;

            $("#tableApprvlRules").empty();

            var CorpId = '<%= Session["CORPOFFICEID"] %>';
            var OrgId = '<%=Session["ORGID"]%>';
            var Id = document.getElementById("<%=HiddenFieldAprvlHierarchyId.ClientID%>").value;
            var DocId = document.getElementById("<%=docsection.ClientID%>").value;
            var ApprvlSts = document.getElementById("<%=hiddenApprvlRuleSts.ClientID%>").value;

            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_Document_Workflow.aspx/LoadConditionsTable",
                data: '{CorpId: "' + CorpId + '",OrgId: "' + OrgId + '",DocId: "' + DocId + '",Id: "' + Id + '",ApprvlSts: "' + ApprvlSts + '"}',
                dataType: "json",
                success: function (data) {

                    if (data.d[0] != "" && data.d[0] != null) {

                        var Count = 0;

                        var EditVal = data.d[0];
                        var findAtt2 = '\\"\\[';
                        var reAtt2 = new RegExp(findAtt2, 'g');
                        var resAtt2 = EditVal.replace(reAtt2, '\[');

                        var findAtt3 = '\\]\\"';
                        var reAtt3 = new RegExp(findAtt3, 'g');
                        var resAtt3 = resAtt2.replace(reAtt3, '\]');

                        var jsonAtt = $.parseJSON(resAtt3);
                        for (var key in jsonAtt) {
                            if (jsonAtt.hasOwnProperty(key)) {
                                EditRowsApprv(jsonAtt[key].DTLID, jsonAtt[key].CONDITION, jsonAtt[key].CONDITIONTYPE, jsonAtt[key].MAXVAL, jsonAtt[key].MINVAL, jsonAtt[key].VALUES, jsonAtt[key].VALUESNAMES, jsonAtt[key].PACKAGE, jsonAtt[key].PROCEDURE, jsonAtt[key].CONDITIONNAME, jsonAtt[key].CONDITIONTYPENAME);

                                if (data.d[1] == "1") {
                                    if (parseInt(Count + 1) < parseInt(jsonAtt.length)) {
                                        document.getElementById("btnAddApprv" + Count).disabled = true;
                                    }
                                }
                                else {
                                    document.getElementById("btnAddApprv" + Count).disabled = true;
                                }
                                Count++;
                            }
                        }
                    }
                    else {
                        AddMoreRowsApprv(0, 0);
                    }

                }
            });
        }

        function LoadConditions(Count) {

            var Id = document.getElementById("<%=HiddenFieldAprvlHierarchyId.ClientID%>").value;
            var DocId = document.getElementById("<%=docsection.ClientID%>").value;

            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_Document_Workflow.aspx/LoadConditions",
                data: '{DocId: "' + DocId + '"}',
                dataType: "json",
                success: function (data) {

                    if (data.d != "" && data.d != null) {
                        Conditions = data.d;

                        $("#ddlConditions" + Count).empty();

                        var ConditionSplit = Conditions.split('¦');
                        for (var i = 0; i < ConditionSplit.length; i++) {
                            var ConditionTypValSplit = ConditionSplit[i].split('‡');
                            var CONDITIONNAME = ConditionTypValSplit[1];
                            var CONDITION = ConditionTypValSplit[0];
                            if (CONDITION != "") {
                                var COptions = new Option(CONDITIONNAME, CONDITION);
                                $(COptions).html(CONDITIONNAME);
                                $("#ddlConditions" + Count).append(COptions);
                            }
                        }

                        var Table = document.getElementById("tableApprvlRules");
                        for (var i = 0; i < Table.rows.length; i++) {
                            var xLoop = (Table.rows[i].cells[0].innerHTML);
                            if ($("#ddlConditions" + xLoop).val() != 0) {
                                var xLoopLdgrId = $("#ddlConditions" + xLoop).val();
                                if (xLoop != Count) {
                                    $noCon("#ddlConditions" + Count + " option[value='" + xLoopLdgrId + "']").remove();
                                }
                            }
                        }

                        var CONDITION = $("#ddlConditions" + Count).val();
                        var CONDITIONNAME = $("#ddlConditions" + Count + " option:selected").text();

                        LoadConditionsTypes(CONDITION, Count);

                        if (Table.rows.length == ConditionSplit.length) {
                            $('.clsAddApprv').attr('disabled', 'disabled');
                        }

                        var RecRow = '';
                        if (CONDITION == "1") {

                            RecRow += '<span class="inp_grp">';
                            RecRow += '<input id="txtMinVal' + Count + '" type="text" class="fg2_inp2 fg2_inp3 fg_chs1 inp_wd1 tr_r">';
                            RecRow += '<input id="txtMaxVal' + Count + '" type="text" class="fg2_inp2 fg2_inp3 fg_chs1 inp_wd2 tr_r">';
                            RecRow += '</span>';
                        }
                        else {

                            RecRow += '<span class="inp_add">';
                            RecRow += '<button id="btnSelect' + Count + '" class="btn act_btn bn6" title="' + CONDITIONNAME + '" data-toggle="modal" onclick="return OpenModalConditionValues(' + Count + ');" >';
                            RecRow += '<i class="fa fa-cubes"></i>';
                            RecRow += '</button>';
                            RecRow += '<a id="aSelect' + Count + '" href="javascript:;" data-toggle="modal" onclick="return OpenModalConditionValues(' + Count + ');"><span id="spanSelect' + Count + '">0 Option(s) Selected</span></a>';
                            RecRow += '</span>';
                        }
                        document.getElementById("CondtnValues" + Count).innerHTML = RecRow;
                    }
                }
            });
        }

        function LoadConditionsTypes(ConditionId, Count) {

            var DocId = document.getElementById("<%=docsection.ClientID%>").value;
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_Document_Workflow.aspx/LoadConditionTypes",
                data: '{DocId: "' + DocId + '",ConditionId: "' + ConditionId + '"}',
                dataType: "json",
                success: function (data) {

                    if (data.d[0] != "" && data.d[0] != null) {
                        ConditionTypes = data.d[0];

                        $("#ddlCndtnTypes" + Count).empty();

                        var ConditionTypeSplit = ConditionTypes.split('¦');
                        for (var i = 0; i < ConditionTypeSplit.length; i++) {
                            var ConditionTypValSplit = ConditionTypeSplit[i].split('‡');
                            var CONDITIONTYPENAME = ConditionTypValSplit[1];
                            var CONDITIONTYPE = ConditionTypValSplit[0];
                            if (CONDITIONTYPE != "") {
                                var CTOptions = new Option(CONDITIONTYPENAME, CONDITIONTYPE);
                                $(CTOptions).html(CONDITIONTYPENAME);
                                $("#ddlCndtnTypes" + Count).append(CTOptions);
                            }
                        }

                        if (data.d[1] != "" && data.d[1] != null && data.d[2] != "" && data.d[2] != null) {
                            document.getElementById("tdPackage" + Count).value = data.d[1];
                            document.getElementById("tdProcedure" + Count).value = data.d[2];
                        }
                    }
                }
            });

        }


        function AddMoreRowsApprv(Mode, CONDITION) {

            var RecRow = '';

            RecRow += '<tr id="trRowApprvId_' + CountApprv + '" >';
            RecRow += '<td id="tdApprvId' + CountApprv + '" style="display: none;">' + CountApprv + '</td>';
            RecRow += '<td id="tdSLNo' + CountApprv + '">' + (CountApprv + 1) + '</td>';
            RecRow += '<td>';
            RecRow += '<select id="ddlConditions' + CountApprv + '" name="ddlConditions' + CountApprv + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw clsCndtn" onchange="CheckDuplicated(' + CountApprv + ')"></select>';
            RecRow += '</td>';
            RecRow += '<td>';
            RecRow += '<select id="ddlCndtnTypes' + CountApprv + '" name="ddlCndtnTypes' + CountApprv + '" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw clsType" onchange="ChangeTypes(' + Mode + ',' + CountApprv + ');"></select>';
            RecRow += '</td>';
            RecRow += '<td id="CondtnValues' + CountApprv + '">';
            RecRow += '</td>';
            RecRow += '<td class="td1">';
            RecRow += '<div class="btn_stl1">';
            RecRow += '<button id="btnAddApprv' + CountApprv + '" class="btn act_btn bn2 clsAddApprv" title="Add New" onclick="return CheckaddMoreRowsApprv(' + CountApprv + ',' + CONDITION + ');"><i class="fa fa-plus-circle"></i></button>';
            RecRow += '<button id="btnDeleteApprv' + CountApprv + '" class="btn act_btn bn3" title="Delete" onclick="return RemoveRowsApprv(' + CountApprv + ',' + CONDITION + ');"><i class="fa fa-trash"></i></button>';
            RecRow += '</div>';
            RecRow += '</td>';
            RecRow += '<td style="display: none;"><input id="tdConditionValApprv' + CountApprv + '" /></td>';
            RecRow += '<td style="display: none;"><input id="tdConditionValuesApprv' + CountApprv + '" /></td>';
            RecRow += '<td style="display: none;"><input id="tdPackage' + CountApprv + '" /></td>';
            RecRow += '<td style="display: none;"><input id="tdProcedure' + CountApprv + '" /></td>';
            RecRow += '<td id="tdEvtApprv' + CountApprv + '" style="display: none;">INS</td>';
            RecRow += '<td id="tdDtlIdApprv' + CountApprv + '" style="display: none;">0</td>';
            RecRow += '</tr>';

            $("#tableApprvlRules").append(RecRow);

            if (document.getElementById("<%=Hiddenview.ClientID%>").value == "1") {
                document.getElementById("ddlConditions" + CountApprv).disabled = true;
                document.getElementById("ddlCndtnTypes" + CountApprv).disabled = true;
                document.getElementById("btnAddApprv" + CountApprv).disabled = true;
                document.getElementById("btnDeleteApprv" + CountApprv).disabled = true;
            }
        }

        function EditRowsApprv(DTLID, CONDITION, CONDITIONTYPE, MAXVAL, MINVAL, VALUES, VALUESNAMES, PACKAGE, PROCEDURE, CONDITIONNAME, CONDITIONTYPENAME) {

            AddMoreRowsApprv("0", CONDITION);

            document.getElementById('tdDtlIdApprv' + CountApprv).innerHTML = DTLID;

            var COptions = new Option(CONDITIONNAME, CONDITION);
            $(COptions).html(CONDITIONNAME);
            $("#ddlConditions" + CountApprv).append(COptions);
            document.getElementById("ddlConditions" + CountApprv).value = CONDITION;

            LoadConditionsTypes(CONDITION, CountApprv);

            var RecRow = '';
            if (CONDITION == "1") {

                RecRow += '<span class="inp_grp">';
                RecRow += '<input id="txtMinVal' + CountApprv + '" type="text" class="fg2_inp2 fg2_inp3 fg_chs1 inp_wd1 tr_r">';
                RecRow += '<input id="txtMaxVal' + CountApprv + '" type="text" class="fg2_inp2 fg2_inp3 fg_chs1 inp_wd2 tr_r">';
                RecRow += '</span>';
            }
            else {

                RecRow += '<span class="inp_add">';
                RecRow += '<button id="btnSelect' + CountApprv + '" class="btn act_btn bn6" title="' + CONDITIONNAME + '" data-toggle="modal" onclick="return OpenModalConditionValues(' + CountApprv + ');" >';
                RecRow += '<i class="fa fa-cubes"></i>';
                RecRow += '</button>';
                RecRow += '<a id="aSelect' + CountApprv + '" href="javascript:;" data-toggle="modal" onclick="return OpenModalConditionValues(' + CountApprv + ');"><span id="spanSelect' + CountApprv + '">0 Option(s) Selected</span></a>';
                RecRow += '</span>';
            }
            document.getElementById("CondtnValues" + CountApprv).innerHTML = RecRow;

            if (CONDITIONTYPE != "") {
                document.getElementById("ddlCndtnTypes" + CountApprv).value = CONDITIONTYPE;
                if (CONDITION == "1") {

                    document.getElementById("txtMinVal" + CountApprv).value = MINVAL;
                    document.getElementById("txtMaxVal" + CountApprv).value = MAXVAL;
                }
                else {

                    document.getElementById("tdConditionValApprv" + CountApprv).value = VALUESNAMES;
                    document.getElementById("tdConditionValuesApprv" + CountApprv).value = VALUES;

                    var VALUESNAMESSplit = VALUESNAMES.split('¦');
                    document.getElementById("spanSelect" + CountApprv).innerHTML = VALUESNAMESSplit.length + " Option(s) Selected";
                }
            }
            ChangeTypes("0", CountApprv);

            document.getElementById("tdPackage" + CountApprv).value = PACKAGE;
            document.getElementById("tdProcedure" + CountApprv).value = PROCEDURE;

            if (DTLID != "") {
                document.getElementById("tdEvtApprv" + CountApprv).innerHTML = "UPD";
            }

            if (document.getElementById("<%=Hiddenview.ClientID%>").value == "1") {
                document.getElementById("ddlConditions" + CountApprv).disabled = true;
                document.getElementById("ddlCndtnTypes" + CountApprv).disabled = true;
                if (CONDITION == "1") {
                    document.getElementById("txtMinVal" + CountApprv).disabled = true;
                    document.getElementById("txtMaxVal" + CountApprv).disabled = true;
                }
                else {

                }
                document.getElementById("btnAddApprv" + CountApprv).disabled = true;
                document.getElementById("btnDeleteApprv" + CountApprv).disabled = true;
            }

            CountApprv++;
        }

        function CheckDuplicated(Count) {
            IncrmntConfrmCounter();

            CheckApprvDuplication(Count);

            var CONDITION = document.getElementById("ddlConditions" + Count).value;
            LoadConditionsTypes(CONDITION, Count);

            var RecRow = '';
            if (CONDITION == "1") {

                RecRow += '<span class="inp_grp">';
                RecRow += '<input id="txtMinVal' + Count + '" type="text" class="fg2_inp2 fg2_inp3 fg_chs1 inp_wd1 tr_r">';
                RecRow += '<input id="txtMaxVal' + Count + '" type="text" class="fg2_inp2 fg2_inp3 fg_chs1 inp_wd2 tr_r">';
                RecRow += '</span>';
            }
            else {

                RecRow += '<span class="inp_add">';
                RecRow += '<button id="btnSelect' + Count + '" class="btn act_btn bn6" title="Approval Set Department" data-toggle="modal" onclick="return OpenModalConditionValues(' + Count + ');" >';
                RecRow += '<i class="fa fa-cubes"></i>';
                RecRow += '</button>';
                RecRow += '<a id="aSelect' + Count + '" href="javascript:;" data-toggle="modal" onclick="return OpenModalConditionValues(' + Count + ');"><span id="spanSelect' + Count + '">0 Option(s) Selected</span></a>';
                RecRow += '</span>';
            }
            document.getElementById("CondtnValues" + Count).innerHTML = RecRow;

        }

        function ChangeTypes(Mode, Count) {
            if (Mode != "0") {
                IncrmntConfrmCounter();
            }

            var CONDITION = document.getElementById("ddlConditions" + Count).value;
            var CONDITIONTYPE = document.getElementById("ddlCndtnTypes" + Count).value;

            if (CONDITION == "1") {
                document.getElementById("txtMinVal" + Count).disabled = false;
                document.getElementById("txtMaxVal" + Count).disabled = false;

                if (CONDITIONTYPE == "1") {

                }
                else if (CONDITIONTYPE == "2") {
                    document.getElementById("txtMinVal" + Count).disabled = true;
                    document.getElementById("txtMinVal" + Count).value = "";
                }
                else if (CONDITIONTYPE == "3") {
                    document.getElementById("txtMaxVal" + Count).disabled = true;
                    document.getElementById("txtMaxVal" + Count).value = "";
                }
            }
        }

        function CheckaddMoreRowsApprv(x, CONDITION) {

            if (CheckAndHighlightApprv(x, 1, "") == true) {

                AddMoreRowsApprv(1, CONDITION);

                var idlast = $('#tableApprvlRules tr:last').attr('id');
                var LastId = "";
                if (idlast != "") {
                    var res = idlast.split("_");
                    LastId = res[1];
                }
                document.getElementById("ddlConditions" + LastId).focus();
                document.getElementById("btnAddApprv" + x).disabled = true;

                LoadConditions(CountApprv);
                ReNumberTable();

                CountApprv++;

                return false;
            }
            else {
                return false;
            }

            return false;
        }

        function CheckAndHighlightApprv(x, Mode, obj) {

            var ret = true;

            var Table = document.getElementById("tableApprvlRules");

            var Condition = document.getElementById("ddlConditions" + x).value;
            document.getElementById("ddlConditions" + x).style.borderColor = "";
            document.getElementById("ddlCndtnTypes" + x).style.borderColor = "";
            if (Condition != "") {
                if (Condition == "1") {
                    document.getElementById("txtMinVal" + x).style.borderColor = "";
                    document.getElementById("txtMaxVal" + x).style.borderColor = "";
                }
                else {
                    document.getElementById("btnSelect" + x).style.borderColor = "";
                }
            }

            if (Mode == "0") {

                if (Condition != "") {
                    if (Condition == "1") {
                        var ConditionType = document.getElementById("ddlCndtnTypes" + x).value.trim();
                        if (ConditionType != "") {
                            if ((ConditionType == "1" || ConditionType == "3") && (obj == "txtMinVal" + x) && (document.getElementById("txtMinVal" + x).value.trim() == "")) {
                                if (document.getElementById("txtMinVal" + x).value.trim() == "") {
                                    document.getElementById("txtMinVal" + x).style.borderColor = "Red";
                                }
                            }
                            if ((ConditionType == "1" || ConditionType == "2") && (obj == "txtMaxVal" + x) && (document.getElementById("txtMaxVal" + x).value.trim() == "")) {
                                if (document.getElementById("txtMaxVal" + x).value.trim() == "") {
                                    document.getElementById("txtMaxVal" + x).style.borderColor = "Red";
                                }
                                ret = false;
                            }
                        }
                    }
                    else {
                        if ((obj == "btnSelect" + x) && (document.getElementById("tdConditionValApprv" + x).value.trim() == "")) {
                            document.getElementById("btnSelect" + x).style.borderColor = "Red";
                            ret = false;
                        }
                    }
                }
                if ((obj == "ddlCndtnTypes" + x) && (document.getElementById("ddlCndtnTypes" + x).value.trim() == "")) {
                    document.getElementById("ddlCndtnTypes" + x).style.borderColor = "Red";
                    ret = false;
                }
                if ((obj == "ddlConditions" + x) && (document.getElementById("ddlConditions" + x).value.trim() == "")) {
                    document.getElementById("ddlConditions" + x).style.borderColor = "Red";
                    ret = false;
                }
            }
            else {
                if (Condition != "") {
                    if (Condition == "1") {
                        var ConditionType = document.getElementById("ddlCndtnTypes" + x).value.trim();
                        if (ConditionType != "") {
                            if ((ConditionType == "1" || ConditionType == "3") && document.getElementById("txtMinVal" + x).value.trim() == "") {
                                if (document.getElementById("txtMinVal" + x).value.trim() == "") {
                                    document.getElementById("txtMinVal" + x).style.borderColor = "Red";
                                    document.getElementById("txtMinVal" + x).focus();
                                }
                            }
                            if ((ConditionType == "1" || ConditionType == "2") && document.getElementById("txtMaxVal" + x).value.trim() == "") {
                                if (document.getElementById("txtMaxVal" + x).value.trim() == "") {
                                    document.getElementById("txtMaxVal" + x).style.borderColor = "Red";
                                    document.getElementById("txtMaxVal" + x).focus();
                                }
                                ret = false;
                            }
                        }
                    }
                    else {
                        if (document.getElementById("tdConditionValApprv" + x).value.trim() == "") {
                            document.getElementById("btnSelect" + x).style.borderColor = "Red";
                            document.getElementById("btnSelect" + x).focus();
                            ret = false;
                        }
                    }
                }

                if (document.getElementById("ddlCndtnTypes" + x).value.trim() == "") {
                    document.getElementById("ddlCndtnTypes" + x).style.borderColor = "Red";
                    document.getElementById("ddlCndtnTypes" + x).focus();
                    ret = false;
                }

                if (document.getElementById("ddlConditions" + x).value.trim() == "") {
                    document.getElementById("ddlConditions" + x).style.borderColor = "Red";
                    document.getElementById("ddlConditions" + x).focus();
                    ret = false;
                }
            }
            var Flag = 0;
            if (ret == true) {
                if (CheckApprvDuplication(x) == false) {
                    Flag++;
                    ret = false;
                }
            }

            if (ret == false && Flag == 0) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                ret = false;
            }

            return ret;
        }

        function CheckApprvDuplication(x) {

            var ret = true;

            $noCon("#ddlConditions" + x).css("borderColor", "");

            var Table = document.getElementById("tableApprvlRules");

            for (var i = 0; i < Table.rows.length; i++) {
                var xLoop = (Table.rows[i].cells[0].innerHTML);
                var xLoopId = "";
                var Id = "";
                xLoopId = $("#ddlConditions" + xLoop).val();
                Id = $("#ddlConditions" + x).val();
                if (xLoop != x) {
                    if (xLoopId == Id) {
                        $noCon("#divWarning").html("Approval conditions should not be duplicated.");
                        $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                        });
                        $noCon("#ddlConditions" + x).css("borderColor", "red");
                        $noCon("#ddlConditions" + x).select();
                        $noCon(window).scrollTop(0);
                        return false;
                    }
                }
            }
            return ret;
        }

        function RemoveRowsApprv(x, CONDITION) {

            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to cancel selected approval rule?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    var evt = document.getElementById("tdEvtApprv" + x).innerHTML;

                    if (evt == "UPD") {
                        var detailId = document.getElementById("tdDtlIdApprv" + x).innerHTML;

                        var CanclIds = document.getElementById("<%=hiddenCnclApprvlData.ClientID%>").value;
                        if (CanclIds == '') {
                            document.getElementById("<%=hiddenCnclApprvlData.ClientID%>").value = detailId;
                        }
                        else {
                            document.getElementById("<%=hiddenCnclApprvlData.ClientID%>").value = document.getElementById("<%=hiddenCnclApprvlData.ClientID%>").value + ',' + detailId;
                        }
                    }


                    jQuery('#trRowApprvId_' + x).remove();

                    ReNumberTable();

                    var idlast = $('#tableApprvlRules tr:last').attr('id');

                    if (idlast != undefined) {
                        var LastId = "";
                        if (idlast != "") {
                            var res = idlast.split("_");
                            LastId = res[1];
                        }
                        document.getElementById("btnAddApprv" + LastId).disabled = false;
                    }

                    var Table = document.getElementById("tableApprvlRules");
                    if (Table.rows.length < 1) {
                        AddMoreRowsApprv(0, CONDITION);

                        LoadConditions(CountApprv);
                        ReNumberTable();

                        CountApprv++;

                    }
                }
                else {
                    return false;
                }
            });
            return false;
        }

        function ValidateApprvDtls() {

            var ret = true;
            var flag = 0;

            var Table = document.getElementById("tableApprvlRules");

            for (var x = 0; x < Table.rows.length; x++) {

                if (Table.rows[x].cells[0].innerHTML != "") {
                    var validRowID = (Table.rows[x].cells[0].innerHTML);

                    var ddlConditions = document.getElementById("ddlConditions" + validRowID).value;
                    var ddlCndtnTypes = document.getElementById("ddlCndtnTypes" + validRowID).value;

                    if ((Table.rows.length > 1) || (Table.rows.length == 1 && (ddlConditions != "" || ddlCndtnTypes != ""))) {
                        if (CheckAndHighlightApprv(validRowID, 1, "") == false) {
                            ret = false;
                        }
                        flag = 1;
                    }

                }
            }

            if (ret == true) {

                document.getElementById("<%=hiddenApprovalDtls.ClientID%>").value = "";

                var tbClientTotalValues = '';
                tbClientTotalValues = [];

                for (var x = 0; x < Table.rows.length; x++) {

                    if (Table.rows[x].cells[0].innerHTML != "") {

                        var validRowID = (Table.rows[x].cells[0].innerHTML);

                        var ddlConditions = document.getElementById("ddlConditions" + validRowID).value;
                        var ddlCndtnTypes = document.getElementById("ddlCndtnTypes" + validRowID).value;

                        var MinVal = "", MaxVal = "", CondtnValues = "";
                        if (ddlConditions == "1") {
                            MinVal = document.getElementById("txtMinVal" + validRowID).value;
                            MaxVal = document.getElementById("txtMaxVal" + validRowID).value;
                        }
                        else {
                            CondtnValues = document.getElementById("tdConditionValuesApprv" + validRowID).value;
                        }

                        var Evt = document.getElementById("tdEvtApprv" + validRowID).innerHTML;
                        var DetailId = document.getElementById("tdDtlIdApprv" + validRowID).innerHTML;

                        if (ddlConditions != "") {
                            var client = JSON.stringify({
                                ROWID: "" + validRowID + "",
                                CONDITION: "" + ddlConditions + "",
                                CONDITIONTYP: "" + ddlCndtnTypes + "",
                                MINVAL: "" + MinVal + "",
                                MAXVAL: "" + MaxVal + "",
                                CONDITIONVALUES: "" + CondtnValues + "",
                                EVTACTION: "" + Evt + "",
                                DTLID: "" + DetailId + "",
                            });
                            tbClientTotalValues.push(client);
                        }

                    }
                }

                document.getElementById("<%=hiddenApprovalDtls.ClientID%>").value = JSON.stringify(tbClientTotalValues);
            }

            //alert(document.getElementById("<%=hiddenApprovalDtls.ClientID%>").value);

            return ret;
        }

        function OpenModalConditionValues(Count) {

            document.getElementById("txtCount").value = Count;
            $("#ModalSelect").modal("show");
            $('#ModalSelect').on('shown.bs.modal', function () {
                document.getElementById("txtConditionList").focus();
            });

            document.getElementById("txtConditionList").value = "";
            document.getElementById("txtSelectedList").value = "";

            var ConditionSelect = document.getElementById("ddlConditions" + Count);
            var ConditionText = ConditionSelect.options[ConditionSelect.selectedIndex].text;
            document.getElementById("CondtnHead").innerHTML = ConditionText;

            LoadConditionValues(null);
            LoadSelectedValues(null);

            $('#ddlListFull').empty();
            $('#ddlListSelected').empty();

            if (document.getElementById("tdConditionValApprv" + Count).value != "") {
                var ConditionVal = document.getElementById("tdConditionValApprv" + Count).value;
                var ConditionValSplit = ConditionVal.split('¦');
                for (var i = 0; i < ConditionValSplit.length; i++) {
                    var ConditionSplit = ConditionValSplit[i].split('‡');
                    var CONDITIONVALUE = ConditionSplit[0];
                    var CONDITIONTEXT = ConditionSplit[1];

                    var COptions = new Option(CONDITIONTEXT, CONDITIONVALUE);
                    $(COptions).html(CONDITIONTEXT);
                    $("#ddlListSelected").append(COptions);
                }
            }

            if (document.getElementById("<%=Hiddenview.ClientID%>").value == "1") {
                document.getElementById("btnRight").disabled = true;
                document.getElementById("btnLeft").disabled = true;
                document.getElementById("txtConditionList").disabled = true;
            }

            return false;
        }

        function LoadConditionValues(event) {

            if (event != null) {
                if (isTagEnter(event) == false) {
                    return false;
                }
            }

            var CorpId = '<%= Session["CORPOFFICEID"] %>';
            var OrgId = '<%=Session["ORGID"]%>';

            var Count = document.getElementById("txtCount").value;
            var Package = document.getElementById("tdPackage" + Count).value;
            var Procedure = document.getElementById("tdProcedure" + Count).value;
            var ConditionId = document.getElementById("ddlConditions" + Count).value;

            $('#ddlListFull').empty();

            $noCon('#txtConditionList').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        async: false,
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        url: "gen_Document_Workflow.aspx/LoadConditionValues",
                        data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",Package:"' + Package + '",Procedure:"' + Procedure + '",ConditionId:"' + ConditionId + '",strText:"' + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + '"}',
                        success: function (data) {
                            if (data.d != "") {
                                $('#ddlListFull').append(data.d);
                            }
                        }
                    });
                }
            });
        }

        function LoadSelectedValues(event) {

            if (event != null) {
                if (isTagEnter(event) == false) {
                    return false;
                }
            }

            var input, filter, ul, li, a, i;
            input = document.getElementById("txtSelectedList");
            filter = input.value.toUpperCase();
            div = document.getElementById("ddlListSelected");
            a = div.getElementsByTagName("option");
            for (i = 0; i < a.length; i++) {
                txtValue = a[i].textContent || a[i].innerText;
                if (txtValue.toUpperCase().indexOf(filter) > -1) {
                    a[i].style.display = "";
                } else {
                    a[i].style.display = "none";
                }
            }
        }

        function AddOptions() {

            var selectedOpts = $('#ddlListFull option:selected');
            if (selectedOpts.length == 0) {
                $noCon("#divWarning").html("Nothing to move.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                return false;
            }
            else {
                $('#ddlListSelected').append($(selectedOpts).clone());
                $(selectedOpts).remove();
            }

            var Count = document.getElementById("txtCount").value;
            document.getElementById("spanSelect" + Count).innerHTML = $('#ddlListSelected > option').length + " Option(s) Selected";

            var strSelected = ""; var strSelectedVals = "";
            $("#ddlListSelected option").each(function () {
                if (strSelected == "") {
                    strSelected = $(this).val() + "‡" + $(this).text();
                    strSelectedVals = $(this).val();
                }
                else {
                    strSelected = strSelected + "¦" + $(this).val() + "‡" + $(this).text();
                    strSelectedVals = strSelectedVals + "¦" + $(this).val();
                }
            });
            document.getElementById("tdConditionValApprv" + Count).value = strSelected;
            document.getElementById("tdConditionValuesApprv" + Count).value = strSelectedVals;
            return false;
        }

        function RemoveOptions() {

            var selectedOpts = $('#ddlListSelected option:selected');
            if (selectedOpts.length == 0) {
                $noCon("#divWarning").html("Nothing to move.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                return false;
            }
            else {
                $('#ddlListFull').append($(selectedOpts).clone());
                $(selectedOpts).remove();
            }

            var Count = document.getElementById("txtCount").value;
            document.getElementById("spanSelect" + Count).innerHTML = $('#ddlListSelected > option').length + " Option(s) Selected";

            var strSelected = ""; var strSelectedVals = "";
            $("#ddlListSelected option").each(function () {
                if (strSelected == "") {
                    strSelected = $(this).val() + "‡" + $(this).text();
                    strSelectedVals = $(this).val();
                }
                else {
                    strSelected = strSelected + "¦" + $(this).val() + "‡" + $(this).text();
                    strSelectedVals = strSelectedVals + "¦" + $(this).val();
                }
            });
            document.getElementById("tdConditionValApprv" + Count).value = strSelected;
            document.getElementById("tdConditionValuesApprv" + Count).value = strSelectedVals;
            return false;
        }

        function ReNumberTable() {
            var table = document.getElementById("tableApprvlRules");
            for (var i = 0, row; row = table.rows[i]; i++) {
                var x = "";
                for (var j = 0, col; col = row.cells[j]; j++) {
                    if (j == 0) {
                        x = col.innerHTML;
                        if (x != "") {
                            var intRecount = parseInt(i) + 1;
                            document.getElementById("tdSLNo" + x).innerHTML = intRecount;
                        }
                    }
                }
            }
        }

        function PassSavedValues() {
            window.close();
            $("#ModalCondition").modal("hide");
        }

    </script>


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

           .ui-autocomplete {
               position: absolute;
               cursor: default;
               z-index: 4000 !important;
           }
    </style>
</asp:Content>
       
                 

                  
           