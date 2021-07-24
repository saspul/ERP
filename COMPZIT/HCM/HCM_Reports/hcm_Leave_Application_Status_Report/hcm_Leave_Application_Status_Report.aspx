<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="hcm_Leave_Application_Status_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_Leave_Application_Status_Report_hcm_Leave_Application_Status_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
  <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i" rel="stylesheet"/>
  <link rel="stylesheet" type="text/css" href="/css/New css/font_awe/css/font-awesome.min.css"/>
  <link rel="stylesheet" type="text/css" href="/css/New css/font_awe/css/font-awesome.css"/>

 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/js/Common/Common.js"></script>
 <link rel="stylesheet" type="text/css" href="/css/New css/hcm_ns.css"/>
 <script type="text/javascript" src="/js/New js/m_select/mock.js"></script>  
 <link rel="stylesheet" type="text/css" href="/js/New js/m_select/jquery.dropdown.css"/>
 <script src="/js/New js/m_select/jquery.dropdown.js"></script>   
 <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
 <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
 <link href="/css/plugins/morris.css" rel="stylesheet" />
 <script src="/JavaScript/plugins/morris/raphael.min.js"></script>
 <script src="/JavaScript/plugins/morris/morris.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:HiddenField ID="HiddenFieldGraphData" runat="server"/>
    <asp:HiddenField ID="HiddenFieldMainTotCnt" runat="server" value="0"/>
    <asp:HiddenField ID="HiddenFieldGrpChanged" runat="server" value="0"/>
    <asp:HiddenField ID="HiddenFieldDept" runat="server" />
    <asp:HiddenField ID="HiddenFieldDivision" runat="server" />
    <asp:HiddenField ID="HiddenFieldJob" runat="server" />
    <asp:HiddenField ID="HiddenFieldStatus" runat="server" />
    <asp:HiddenField ID="HiddenFieldLeaveType" runat="server" />
    <asp:HiddenField ID="HiddenFieldFromDate" runat="server" />
    <asp:HiddenField ID="HiddenFieldToDate" runat="server" />
    <asp:HiddenField ID="HiddenFieldCategory" runat="server" />
    <asp:HiddenField ID="HiddenFieldSummary" runat="server" />
    <asp:HiddenField ID="HiddenFieldSummaryIndvidual" runat="server" />
     <asp:HiddenField ID="HiddenFieldGraphShow" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
 <div class="myAlert-top alert alert-success" id="success-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Success!</strong> Changes completed succesfully
</div>
 <div class="myAlert-bottom alert alert-danger" id="divWarning">
   <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
   <strong>Danger!</strong> Request not conmpleted
 </div>
    <ol class="breadcrumb">
        <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Hcm.aspx">HCM</a></li>
        <li class="active">Leave Application And Status Report</li>
    </ol>

  <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr">
        <h2>Leave Application And Status Report</h2>
        <button class="btn pull-right show_ser" title="show search area" style="display:none;" onclick="return false;">
          <i class="fa fa-caret-down"></i>
        </button>

          <div class="search_bo1 ser_box serch_bx1" style="display:block;">
            <div class="form-group fg2 sa_o_fg6">
              <label for="pwd" class="fg2_la1">From Date:<span class="spn1"></span> </label>
              <div id="datepicker3" class="input-group date" data-date-format="mm-dd-yyyy">
                <input class="form-control inp_bdr" type="text" id="txtFromDate" runat="server"/>
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
              </div>
            </div>

            <div class="form-group fg2 sa_o_fg6">
              <label for="pwd" class="fg2_la1">To Date:<span class="spn1"></span> </label>
              <div id="datepicker4" class="input-group date" data-date-format="mm-dd-yyyy">
                <input class="form-control inp_bdr" type="text" id="txtToDate" runat="server"/>
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
              </div>
            </div>
            <div class="fg2 sa_o_fg6 sa_480 ma_bo4">
              <label for="pwd" class="fg2_la1">Leave Type:<span class="spn1"></span> </label>
                 <asp:DropDownList ID="ddlLeaveType" data-placeholder="All"  multiple="multiple" class="form-control fg2_inp1 grp1 select2" runat="server">
                </asp:DropDownList>
              
            </div>
            <div class="fg2 sa_o_fg6 sa_480 ma_bo4">
              <label for="pwd" class="fg2_la1">Department:<span class="spn1"></span> </label>
                 <asp:DropDownList ID="ddlDepartment" data-placeholder="All"  multiple="multiple" class="form-control fg2_inp1 grp1 select2" runat="server">
                </asp:DropDownList>
            </div>
            <div class="fg2 sa_o_fg6 sa_480 ma_bo4">
              <label for="pwd" class="fg2_la1">Division:<span class="spn1"></span> </label>
                 <asp:DropDownList ID="ddlDivision" data-placeholder="All"  multiple="multiple" class="form-control fg2_inp1 grp1 select2" runat="server">
                </asp:DropDownList>
            </div>
            <div class="form-group fg2 sa_o_fg6 sa_480">
              <label for="pwd" class="fg2_la1">Category:<span class="spn1"></span> </label>
              <select class="form-control fg2_inp1 grp1" id="ddlCategory" runat="server">
                   <option value="2">ALL</option>
                <option value="0">STAFF</option>
                <option value="1">WORKER</option>
               
              </select>
            </div>
            <div class="fg2 sa_o_fg6 sa_480 ma_bo4">
              <label for="pwd" class="fg2_la1">Job:<span class="spn1"></span> </label>
                  <asp:DropDownList ID="ddlJob" data-placeholder="All"  multiple="multiple" class="form-control fg2_inp1 grp1 select2" runat="server">
                </asp:DropDownList>
            </div>
            <div class="fg2 sa_o_fg6 sa_480 ma_bo4">
              <label for="pwd" class="fg2_la1">Application Status:<span class="spn1"></span> </label><br>
              <asp:DropDownList ID="ddlStatus" data-placeholder="All"  multiple="multiple" class="form-control fg2_inp1 grp1 select2" runat="server">                
                    <asp:ListItem Text="PENDING" Value="0" ></asp:ListItem>
                    <asp:ListItem Text="REPORTING OFFICER APPROVED" Value="1"></asp:ListItem>
                    <asp:ListItem Text="DIVISION MANAGER APPROVED" Value="2"></asp:ListItem>
                    <asp:ListItem Text="GENERAL MANAGER APPROVED" Value="3"></asp:ListItem>
                    <asp:ListItem Text="HR APPROVED" Value="4"></asp:ListItem>
                    <asp:ListItem Text="REJECTED" Value="5"></asp:ListItem>
                    <asp:ListItem Text="CANCEL PENDING" Value="6"></asp:ListItem>
                    <asp:ListItem Text="CANCELLED" Value="7"></asp:ListItem>
                    <asp:ListItem Text="CLOSED" Value="8"></asp:ListItem>    
              </asp:DropDownList>
            </div>

            <div class="form-group fg2 sa_o_fg6 sa_480">
              <label for="email" class="fg2_la1">Report Type:<span class="spn1"></span></label>
              <select type="text" class="form-control fg2_inp1 grp1" id="ddlReportType" runat="server">
                <option value="0">BOTH</option>
                <option value="1">TEXTUAL</option>
                <option value="2">GRAPHICAL</option>
              </select>
            </div>

            <div class="form-group fg2 sa_o_fg6 sa_480">
              <label for="email" class="fg2_la1">Summary Type:<span class="spn1"></span></label>
              <select type="text" class="form-control fg2_inp1" id="ddlSummaryType" runat="server">
                <option value="0">LEAVE TYPE</option>
                <option value="1">DEPARTMENT</option>
                <option value="2">DIVISION</option>
                <option value="3">CATEGORY</option>
               <%-- <option value="4">JOB</option>--%>
                <option value="5">STATUS</option>
              </select>
            </div>
                  
            <div class="form-group fg2 sa_480 pull-right">
              <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
              <asp:Button ID="btnSearch"  runat="server" class="submit_ser" OnClientClick="return ValidateSearch();" OnClick="btnSearch_Click"/>
            </div>
            <div class="clearfix"></div>
            <button class="btn pull-right hide_ser" title="hide search area" onclick="return false;">
              <i class="fa fa-caret-up"></i>
            </button>
          </div>

        <div class="summary_cls" style="display:block;">
          <div class="free_sp"></div>
          <div class="devider"></div>
          <div class="fg6 sumry_1" style="display:block;">
            <h3>Leave Application Summary</h3>
            <div class="fg12 txt_01">
              <div class="fg13_n">
              <div class="tab_res">
                <div class="r_800">
                  <table class="display table-bordered pro_tab1 tbl_800" cellspacing="0" width="100%">
                    <thead class="thead1">
                      <tr>
                        <th class="th_b8 tr_l" id="thHeadLevel1" runat="server">Leave Type<br>
                          <%--<label class="switch dis_tog" style="display: none;">
                            <input type="checkbox" checked="" class="dep_bt">
                            <span class="slider_tog round"></span>
                          </label>--%>
                        </th>
                        <th class="th_b4">Application Count <br>
                          <label class="switch dis_tog" style="display: none;">
                            <input type="checkbox" checked="" class="dep_bt">
                            <span class="slider_tog round"></span>
                          </label>
                        </th>
                        <th class="th_b5_01"></th>
                      </tr>
                    </thead>
                      
                    <tbody id="tbodyLevel1" runat="server">
                    </tbody>
                    <tfoot class="clr_hrd" id="tFootLevel1" runat="server">                     
                    </tfoot>
                  </table>
                </div>

              </div>
            </div>

          </div>
        </div>

        <div class="sumry_2 mar_bt10" style="display:none;" id="divLev2">
          <div class="fg12">
            <h3 id="headLevel2" runat="server"> Leave Type Summary</h3>
            <button class="btn tab_but1 butn3 flt_r back1" title="Back" onclick="return false;">
              <i class="fa fa-arrow-circle-left"></i>
            </button>
          </div>
          <div class="clearfix"></div>
          <div class="fg12">
            <div class="fg13_n flt_l">
              <div class="opn_grp" style="display:none;">
                <ul>
                  <li>
                    <input class="form-check-input flt_l" type="radio" name="radio_grp" id="gridRadios2" value="option2" checked="">
                    <p class="pz_s">Department</p>
                  </li>
                  <li>
                    <input class="form-check-input flt_l" type="radio" name="radio_grp" id="Radio1" value="option2">
                    <p class="pz_s">Division</p>
                  </li>
                  <li>
                    <input class="form-check-input flt_l" type="radio" name="radio_grp" id="Radio2" value="option2">
                    <p class="pz_s">Department</p>
                  </li>
                  <li>
                    <input class="form-check-input flt_l" type="radio" name="radio_grp" id="Radio3" value="option2">
                    <p class="pz_s">Division</p>
                  </li>
                  <li>
                    <input class="form-check-input flt_l" type="radio" name="radio_grp" id="Radio4" value="option2">
                    <p class="pz_s">Department</p>
                  </li>
                  <li>
                    <input class="form-check-input flt_l" type="radio" name="radio_grp" id="Radio5" value="option2">
                    <p class="pz_s">Division</p>
                  </li>
                  <li>
                    <input class="form-check-input flt_l" type="radio" name="radio_grp" id="Radio6" value="option2">
                    <p class="pz_s">Department</p>
                  </li>
                </ul>
              </div>
              <div class="tab_res">
                <div class="r_1024">
                  <table class="display table-bordered pro_tab1 tbl_1024" cellspacing="0" width="100%">
                    <thead class="thead1">
                      <tr>
                        <th class="th_b6 tr_l dep_1 grq1">Department
                        </th>
                        <th class="th_b6 tr_l div_1 grq2">Division
                        </th>
                        <th class="th_b6 tr_l lev_1 grq0">Leave Type
                        </th>
                        <th class="th_b6 tr_l cat_1 grq3">Category
                        </th>
                        <th class="th_b6 tr_l job_1 grq4">Job
                        </th>
                        <th class="th_b6 tr_l sta_1 grq5">Status
                        </th>
                        <th class="th_b6 tr_c">Application Count<br>
                          <span class="dis_tog_1" style="display: none;">
                            <label class="switch">
                              <input type="checkbox" checked="">
                              <span class="slider_tog round"></span>
                            </label>
                          </span>
                        </th>
                      </tr>
                    </thead>
                    <tbody id="tbodyLevel2">
                     
                    </tbody>
                    <tfoot class="clr_hrd">
                      <tr>
                        <th class="dep_1 grq1"></th>
                        <th class="div_1 grq2"></th>
                        <th class="lev_1 grq0"></th>
                        <th class="cat_1 grq3"></th>
                        <th class="job_1 grq4"></th>
                        <th class="tr_r grq5">Total</th>
                        <th>
                          <a onclick="return ShowSummaryLevel3('','','','','','','','tdTotalLevel2','L2');" href="#area_sec1" class="bt_dtl_1" id="tdTotalLevel2"></a>
                        </th>
                      </tr>
                    </tfoot>
                  </table>
                </div>
              </div>
            </div>
            <div class="fg13_r bg_slr">
              <button class="btn btn_comp ad_btn" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <i class="fa fa-compress"></i>
              </button>
              <div class="ddwn ddwn_ad" style="display:none;" id="liColLevel2">
                
                <button class="pull-right cls_ad3" onclick="return false;"><i class="fa fa-close"></i></button>
             
                <li class="dropdown-item li2L1" href="#">
                  <label class="form1 mar_bo">
                    <span class="button-checkbox">
                      <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel2(1);" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                      <input type="checkbox" class="hidden" checked="" value="1" id="cbx2Lev1">
                    </span>
                    <p class="pz_s">DEPARTMENT</p>
                  </label>
                </li>
                <li class="dropdown-item li2L2" href="#">
                  <label class="form1 mar_bo">
                    <span class="button-checkbox">
                      <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel2(2);" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                      <input type="checkbox" class="hidden" checked="" value="2" id="cbx2Lev2">
                    </span>
                    <p class="pz_s">DIVISION</p>
                  </label>
                </li>
                <li class="dropdown-item li2L0" href="#">
                  <label class="form1 mar_bo">
                    <span class="button-checkbox">
                      <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel2(0);" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                      <input type="checkbox" class="hidden" checked="" value="0" id="cbx2Lev0">
                    </span>
                    <p class="pz_s">LEAVE TYPE</p>
                  </label>
                </li>
                   <li class="dropdown-item li2L3" href="#">
                  <label class="form1 mar_bo">
                    <span class="button-checkbox">
                      <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel2(3);" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                      <input type="checkbox" class="hidden" checked="" value="3" id="cbx2Lev3">
                    </span>
                    <p class="pz_s">CATEGORY</p>
                  </label>
                </li>
                   <li class="dropdown-item li2L5" href="#">
                  <label class="form1 mar_bo">
                    <span class="button-checkbox">
                      <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel2(5);" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                      <input type="checkbox" class="hidden" checked="" value="5" id="cbx2Lev5">
                    </span>
                    <p class="pz_s">STATUS</p>
                  </label>
                </li>

              </div>



            </div>
            <div class="fg13_r bg_slr">
              <button class="btn btn_comp grp_btn" type="button" id="Button1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <i class="fa fa-link"></i>
              </button>
              <div class="ddwn ddwn_grp" style="display:none;">
                
                <button class="pull-right cls_ad4"><i class="fa fa-close" onclick="return false;"></i></button>
              <li class="dropdown-item" href="#">
                <li class="dropdown-item" href="#">
                  <input class="form-check-input flt_l" type="radio" name="radio_grp" id="TRadio0" value="0" checked="" runat="server">
                  <p class="pz_s">Leave Type</p>
                </li>
                <li class="dropdown-item" href="#">
                  <input class="form-check-input flt_l" type="radio" name="radio_grp" id="TRadio1" value="1" checked="" runat="server">
                  <p class="pz_s">Department</p>
                </li>
                   <li class="dropdown-item" href="#">
                  <input class="form-check-input flt_l" type="radio" name="radio_grp" id="TRadio2" value="2" checked="" runat="server">
                  <p class="pz_s">Division</p>
                </li>
                   <li class="dropdown-item" href="#">
                  <input class="form-check-input flt_l" type="radio" name="radio_grp" id="TRadio3" value="3" checked="" runat="server">
                  <p class="pz_s">Category</p>
                </li>
                   <li class="dropdown-item" href="#">
                  <input class="form-check-input flt_l" type="radio" name="radio_grp" id="TRadio5" value="5" checked="" runat="server">
                  <p class="pz_s">Status</p>
                </li>

              </div>
            </div>
          </div>
        </div>

        <div class="fg6 mr_at flt_l sum_grpz" style="display:block;">
          <h3>Application Count: <a onclick="return ShowSummaryLevel3('','','','','','','','cphMain_graphCnt','L1');" href="#area_sec1" class="bt_dtl_1"><span class="rd" id="graphCnt" runat="server"></span></a></h3>
          <div class="example-box">
            <div class="example__headline">
            </div>
            <div id="chart-1"></div>
          </div>
        </div>
        </div>

        <div class="clearfix"></div>

        <div id="details_cls" class="details_cls" style="display:none;">
          <div class="free_sp"></div>
          <div class="devider"></div>
          <div class="fg12">
            <h3 id="theadLevel3" runat="server">Leave Type Details</h3>
            <button class="btn tab_but1 butn4 flt_r close1" title="Back" onclick="return false;">
                <i class="fa fa-close"></i>
              </button>
          </div>
          <div class="fg13_n mr_at flt_l">
            <div class="r_fl">
              <table id="tableLevel3" class="display table-bordered pro_tab1 tbl_ap_wd tbl_apl" cellspacing="0" width="100%">
                <thead class="thead1">
                  <tr>
                    <th class="th_b7 tr_l ap_r col6">Application Ref#<br>
                      <span class="dis_tog_1" style="display: none;">
                        <label class="switch">
                          <input type="checkbox" checked="">
                          <span class="slider_tog round"></span>
                        </label>
                      </span>
                    </th>
                    <th class="th_b7 da_r col7">Date of Request<br>
                      <span class="dis_tog_2" style="display: none;">
                        <label class="switch">
                          <input type="checkbox" checked="">
                          <span class="slider_tog round"></span>
                        </label>
                      </span>
                    </th>
                    <th class="th_b7 tr_l em_r col8">Employee ID<br>
                      <span class="dis_tog_2" style="display: none;">
                        <label class="switch">
                          <input type="checkbox" checked="">
                          <span class="slider_tog round"></span>
                        </label>
                      </span>
                    </th>
                    <th class="th_b7 tr_l em_r1 col9">Employee<br>
                      <span class="dis_tog_2" style="display: none;">
                        <label class="switch">
                          <input type="checkbox" checked="">
                          <span class="slider_tog round"></span>
                        </label>
                      </span>
                    </th>
                    <th class="th_b7 tr_l de_r col10">Designation<br>
                      <span class="dis_tog_2" style="display: none;">
                        <label class="switch">
                          <input type="checkbox" checked="">
                          <span class="slider_tog round"></span>
                        </label>
                      </span>
                    </th>
                    <th class="th_b7 tr_l de_r1 col1">Department<br>
                      <span class="dis_tog_2" style="display: none;">
                        <label class="switch">
                          <input type="checkbox" checked="">
                          <span class="slider_tog round"></span>
                        </label>
                      </span>
                    </th>
                    <th class="th_b7 tr_l ca_r col3">Category<br>
                      <span class="dis_tog_2" style="display: none;">
                        <label class="switch">
                          <input type="checkbox" checked="">
                          <span class="slider_tog round"></span>
                        </label>
                      </span>
                    </th>
                    <th class="th_b7 tr_l le_r col0">Leave Type<br>
                      <span class="dis_tog_2" style="display: none;">
                        <label class="switch">
                          <input type="checkbox" checked="">
                          <span class="slider_tog round"></span>
                        </label>
                      </span>
                    </th>
                    <th class="th_b7 tr_l jo_r col11">Job<br>
                      <span class="dis_tog_2" style="display: none;">
                        <label class="switch">
                          <input type="checkbox" checked="">
                          <span class="slider_tog round"></span>
                        </label>
                      </span>
                    </th>
                      <th class="th_b7 tr_l jo_r col5">Status<br>
                      <span class="dis_tog_2" style="display: none;">
                        <label class="switch">
                          <input type="checkbox" checked="">
                          <span class="slider_tog round"></span>
                        </label>
                      </span>
                    </th>
                    <th class="th_b7 av_r col12">Available Leave#<br>
                      <span class="dis_tog_2" style="display: none;">
                        <label class="switch">
                          <input type="checkbox" checked="">
                          <span class="slider_tog round"></span>
                        </label>
                      </span>
                    </th>
                    <th class="th_b7 le_r1 col13">Leave From<br>
                      <span class="dis_tog_2" style="display: none;">
                        <label class="switch">
                          <input type="checkbox" checked="">
                          <span class="slider_tog round"></span>
                        </label>
                      </span>
                    </th>
                    <th class="th_b7 le_r2 col14">Leave To<br>
                      <span class="dis_tog_2" style="display: none;">
                        <label class="switch">
                          <input type="checkbox" checked="">
                          <span class="slider_tog round"></span>
                        </label>
                      </span>
                    </th>
                    <th class="th_b7 le_r3 col15">Leave Days#<br>
                      <span class="dis_tog_2" style="display: none;">
                        <label class="switch">
                          <input type="checkbox" checked="">
                          <span class="slider_tog round"></span>
                        </label>
                      </span>
                    </th>
                    <th class="th_b7 ba_r col16">Balance Leave#<br>
                      <span class="dis_tog_2" style="display: none;">
                        <label class="switch">
                          <input type="checkbox" checked="">
                          <span class="slider_tog round"></span>
                        </label>
                      </span>
                    </th>
                  </tr>
                </thead>
                <tbody id="tbodyLevel3">                
                </tbody>
                <tfoot class="clr_hrd">
                  <tr>
                    <th class="th_b7 ap_r col6"></th>
                    <th class="th_b7 da_r col7"></th>
                    <th class="th_b7 em_r col8"></th>
                    <th class="th_b7 em_r1 col9"></th>
                    <th class="th_b7 de_r col10"></th>
                    <th class="th_b7 ca_r col1"></th>
                    <th class="th_b7 le_r col3"></th>
                    <th class="th_b7 jo_r col0"></th>
                    <th class="th_b7 jo_r col11"></th>
                    <th class="th_b7 av_r col5"></th>
                    <th class="th_b7 le_r1 col12"></th>
                    <th class="th_b7 le_r2 col13"></th>
                    <th class="th_b7 le_r3 col14"></th>
                    <th class="th_b7 tr_r col15">Total</th>
                    <th class="th_b7 col16" id="tdLevelsTot"></th>
                  </tr>
                </tfoot>
              </table>
            </div>
          </div>
          <div class="fg13_r bg_slr">
            <button class="btn btn_comp ad_btn2" type="button" id="Button2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
              <i class="fa fa-compress"></i>
            </button>
            <div class="ddwn ddwn_ad2" style="display:none;" id="liColLevel3">
                <button class="pull-right cls_ad2"><i class="fa fa-close" onclick="return false;"></i></button>

             <%-- <li class="dropdown-item li6" href="#">
                <label class="form1 mar_bo">
                  <span class="button-checkbox">
                    <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel3(6);" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                    <input type="checkbox" class="hidden" checked="" value="6" id="cbx3Lev6" >
                  </span>
                  <p class="pz_s">APPLICATION REF#</p>
                </label>
              </li>--%>
              <li class="dropdown-item li7" href="#">
                <label class="form1 mar_bo">
                  <span class="button-checkbox">
                    <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel3(7);" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                    <input type="checkbox" class="hidden" checked="" value="7" id="cbx3Lev7">
                  </span>
                  <p class="pz_s">DATE OF REQUEST</p>
                </label>
              </li>
                <li class="dropdown-item li8" href="#">
                <label class="form1 mar_bo">
                  <span class="button-checkbox">
                    <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel3(8);" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                    <input type="checkbox" class="hidden" checked="" value="8" id="cbx3Lev8">
                  </span>
                  <p class="pz_s">EMPLOYEE ID</p>
                </label>
              </li>
                 <li class="dropdown-item li9" href="#">
                <label class="form1 mar_bo">
                  <span class="button-checkbox">
                    <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel3(9);" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                    <input type="checkbox" class="hidden" checked="" value="9" id="cbx3Lev9">
                  </span>
                  <p class="pz_s">EMPLOYEE</p>
                </label>
              </li>
                 <li class="dropdown-item li10" href="#">
                <label class="form1 mar_bo">
                  <span class="button-checkbox">
                    <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel3(10);" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                    <input type="checkbox" class="hidden" checked="" value="10" id="cbx3Lev10">
                  </span>
                  <p class="pz_s">DESIGNATION</p>
                </label>
              </li>
                 <li class="dropdown-item li1" href="#">
                <label class="form1 mar_bo">
                  <span class="button-checkbox">
                    <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel3(1);" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                    <input type="checkbox" class="hidden" checked="" value="1" id="cbx3Lev1">
                  </span>
                  <p class="pz_s">DEPARTMENT</p>
                </label>
              </li>                
                 <li class="dropdown-item li3" href="#">
                <label class="form1 mar_bo">
                  <span class="button-checkbox">
                    <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel3(3);" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                    <input type="checkbox" class="hidden" checked="" value="3" id="cbx3Lev3">
                  </span>
                  <p class="pz_s">CATEGORY</p>
                </label>
              </li>
                 <li class="dropdown-item li0" href="#">
                <label class="form1 mar_bo">
                  <span class="button-checkbox">
                    <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel3(0);" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                    <input type="checkbox" class="hidden" checked="" value="0" id="cbx3Lev0">
                  </span>
                  <p class="pz_s">LEAVE TYPE</p>
                </label>
              </li>
                 <li class="dropdown-item li11" href="#">
                <label class="form1 mar_bo">
                  <span class="button-checkbox">
                    <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel3(11);" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                    <input type="checkbox" class="hidden" checked="" value="11" id="cbx3Lev11">
                  </span>
                  <p class="pz_s">JOB</p>
                </label>
              </li>
                 <li class="dropdown-item li5" href="#">
                <label class="form1 mar_bo">
                  <span class="button-checkbox">
                    <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel3(5);" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                    <input type="checkbox" class="hidden" checked="" value="5" id="cbx3Lev5">
                  </span>
                  <p class="pz_s">STATUS</p>
                </label>
              </li>
                 <li class="dropdown-item li12" href="#">
                <label class="form1 mar_bo">
                  <span class="button-checkbox">
                    <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel3(12);" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                    <input type="checkbox" class="hidden" checked="" value="12" id="cbx3Lev12">
                  </span>
                  <p class="pz_s">AVAILABLE LEAVE#</p>
                </label>
              </li>



            </div>
          </div>
        </div>

        <div class="clearfix"></div>
        <div class="free_sp"></div>
        <div id="area_sec1"></div>

</div>
    </div>
</div><!--content_container_closed------>

<a href="#" type="button" class="print_o" title="Print page">
  <i class="fa fa-print"></i>
</a>

<div class="print_opt">
  <button class="csv_b csv_b1" onclick="return PrintSummary();"><i class="fa fa-newspaper-o " aria-hidden="true"></i>Summary</button> 
  <button class="pdf_b csv_b1" onclick="return PrintDetail();"><i class="fa fa-file-text" aria-hidden="true"></i>Detail</button>
</div>

<!---import_button_section--->
<%--<a href="#" type="button" class="imprt_o" title="Export" onclick="import_1()">
  <i class="fa fa-code-fork" aria-hidden="true"></i>
</a>
<div class="import_opt">
  <button class="csv_b"><i class="fa fa-file-excel-o" aria-hidden="true"></i>CSV</button> 
  <button class="pdf_b"><i class="fa fa-file-pdf-o" aria-hidden="true"></i>PDF</button>
</div>--%>
<!---import_button_section_closed--->

<!---Back to top_section_strted-->
<a href="#" type="button" class="bck_opt" title="Print page" id="scroll" onclick="topbtn()">
  <i class="fa fa-angle-up"></i>
</a>
<!---Back to top_section_closed--->

    <script type="text/javascript">
        $(function () {
            $("#datepicker3").datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                todayHighlight: true
            });
        });
</script>
<script type="text/javascript">
    $(function () {
        $("#datepicker4").datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            todayHighlight: true
        });
    });
</script>
 <link href="/js/New js/date_pick/datepicker.css" rel="stylesheet" type="text/css" />
 <script src="/js/New js/date_pick/datepicker.js"></script>



<link href="/css/New css/select2.min.css" rel="stylesheet" />
<script src="/js/New js/select2.min.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        $('.js-example-basic-multiple').select2();
    });
</script>

<!---multiple selection new_script--->
  <script>
      var Random = Mock.Random;
      var json1 = Mock.mock({
          "data|10-50": [{
              name: function () {
                  return Random.name(false)
              },
              "id|+1": 1,
              "disabled|1-2": true,
              groupName: 'Group Name',
              "groupId|1-4": 1,
              "selected": false
          }]
      });
      $('.dropdown-mul-1').dropdown({
          //data: json1.data,
          limitCount: 40,
          multipleMode: 'label',
          choice: function () {
              // console.log(arguments,this);
          }
      });
  </script>
<!---multiple selection new_script_closed--->

<script>
    $(document).ready(function () {
        $(".btn_m").click(function () {
            $(".fg20_r").toggle(100);
        });
    });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        $(".btn_m1").click(function () {
            $(".fg20_r1").toggle(100);
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(".dep_bt").click(function () {
            $(".dep_1").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".div_bt").click(function () {
            $(".div_1").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".lev_bt").click(function () {
            $(".lev_1").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".cat_bt").click(function () {
            $(".cat_1").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".job_bt").click(function () {
            $(".job_1").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".sta_bt").click(function () {
            $(".sta_1").toggle(100);
        });
    });
</script>
<script>
    $(document).ready(function () {
        $(".back1").click(function () {
            $(".sumry_2").hide();
            if (document.getElementById("<%=HiddenFieldGraphShow.ClientID%>").value == "1") {
                $(".sum_grpz").hide(100);
                $(".sumry_1").show(100);
            }
            else if (document.getElementById("<%=HiddenFieldGraphShow.ClientID%>").value == "2") {
                 $(".sum_grpz").show(100);
                 $(".sumry_1").hide(100);
             }
             else {
                 $(".sum_grpz").show(100);
                 $(".sumry_1").show(100);
             }
            //$(".sumry_1").fadeIn(1000);
        });
        $(".bt_sumry_2").click(function () {
            $(".sumry_2").fadeIn(1000);
            $(".sumry_1").hide();
            $(".sum_grpz").hide(200);
        });
    });
</script>

<!---detail_section_script--->
<script>
    $(document).ready(function () {
        $(".bt_dtl_1").click(function () {
            $(".details_cls").show(100);
        });
    });
</script>

<script>
    function dtl_info1() {
        var x = document.getElementById("#details_cls");
        if (x.style.display === "none") {
            x.style.display = "block";
        } else {
            x.style.display = "none";
        }
    }
</script>

<script>
    $(document).ready(function () {
        $(".ap_r_bt").click(function () {
            $(".ap_r").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".da_r_bt").click(function () {
            $(".da_r").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".em_r_bt").click(function () {
            $(".em_r").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".em_r1_bt").click(function () {
            $(".em_r1").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".de_r_bt").click(function () {
            $(".de_r").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".de_r1_bt").click(function () {
            $(".de_r1").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".ca_r_bt").click(function () {
            $(".ca_r").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".le_r_bt").click(function () {
            $(".le_r").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".jo_r_bt").click(function () {
            $(".jo_r").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".av_r_bt").click(function () {
            $(".av_r").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".le_r1_bt").click(function () {
            $(".le_r1").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".le_r2_bt").click(function () {
            $(".le_r2").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".le_r3_bt").click(function () {
            $(".le_r3").toggle(100);
        });
    });
    $(document).ready(function () {
        $(".ba_r_bt").click(function () {
            $(".ba_r").toggle(100);
        });
    });
</script>

<!---details section script_closed--->

<!-----graphical css_and script_included------>


<script type="text/javascript">
    $(window).load(function () {
        if (document.getElementById("<%=HiddenFieldMainTotCnt.ClientID%>").value != "0") {
            var TypeData = document.getElementById("<%=HiddenFieldGraphData.ClientID%>").value;
            var VehicleByTypeData = [{
                'CLASS NAME': '0',
                'COUNT': '0',
            }];
            if (TypeData != "") {
                VehicleByTypeData = ConvertToJson(TypeData);
            }
            // Bar Chart
            Morris.Bar({
                element: 'chart-1',
                data: VehicleByTypeData,
                xkey: 'CLASS NAME',
                ykeys: ['COUNT'],
                labels: ['COUNT'],
                barRatio: 0.7,
                xLabelAngle: 90,
                hideHover: 'auto',
                barColosr: "#ed7e30",
                resize: true,
                yLabelFormat: function (y) { return y != Math.round(y) ? '' : y; },
                gridTextFamily: 'Calibri',
            });
            $('#chart-1 svg').height(538);
        }
        if (document.getElementById("<%=ddlReportType.ClientID%>").value == "1") {
            $(".sum_grpz").hide(100);
            $(".sumry_1").show(100);
        }
        else if (document.getElementById("<%=ddlReportType.ClientID%>").value == "2") {
             $(".sum_grpz").show(100);
             $(".sumry_1").hide(100);
         }
         else {
             $(".sum_grpz").show(100);
             $(".sumry_1").show(100);
         }
    });
</script>

<%--<link rel="stylesheet" href="/js/New js/graph/rumca.min.css"/>
<link rel="stylesheet" href="/js/New js/graph/example.css"/>
<script src="/js/New js/graph/rumca.min.js"></script>--%>


<script type="text/javascript">
    $(document).ready(function () {
        $(".grp1").click(function () {
            //$(".sum_grpz").show(100);
            //$(".sumry_1").hide(100);
        });
    });
</script>

<!---graph _css_closed---->

<!-- <script type="text/javascript">
  $(document).ready(function(){
  $(".close1").click(function(){
    $(".details_cls").fadeOut(1000);
  });
</script> -->
<script>
    $(document).ready(function () {
        $(".close1").click(function () {
            $(".details_cls").fadeOut(1000);
        });
    });
</script>

<!---table_1_script--->
<script>
    $(document).ready(function () {
        $(".btn_tog").click(function () {
            $(".dis_tog").toggle(100);
        });
    });
</script>

<!---table_script1_closed--->
<!---table_1_script--->
<script>
    $(document).ready(function () {
        $(".btn_tog1").click(function () {
            $(".dis_tog_1").toggle(100);
        });
    });
</script>

<!---table_script1_closed--->
<!---table_1_script--->
<script>
    $(document).ready(function () {
        $(".btn_tog2").click(function () {
            $(".dis_tog_2").toggle(100);
        });
    });
</script>

<!---table_script1_closed--->

<script>
    $(document).ready(function () {
        $(".imprt_o").click(function () {
            $(".import_opt").toggle(300);
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(".print_o").click(function () {
            $(".print_opt").toggle(200);
        });
    });
</script>


<script>
    $(document).ready(function () {
        $(".btn_grp").click(function () {
            $(".opn_grp").toggle(200);
        });
        $(".btn_comp").click(function () {
            $(".opn_grp").hide(200);
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(".bt_op_ovr").mouseover(function () {
            $(".spn_bt_opn").show(200);
        });
        $(".bt_op_ovr").mouseout(function () {
            $(".spn_bt_opn").hide(200000);
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(".ad_btn1").click(function () {
            $(".ddwn_ad1").toggle(200);
        });
        $(".cls_ad1, .fg13_n").click(function () {
            $(".ddwn_ad1").hide(200);
        });
        $(".fg13_n").mouseover(function () {
            $(".ddwn_ad1").hide(200);
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(".ad_btn2").click(function () {
            $(".ddwn_ad2").toggle(200);
        });
        $(".cls_ad2, .fg13_n").click(function () {
            $(".ddwn_ad2").hide(200);
        });
        $(".fg13_n").mouseover(function () {
            $(".ddwn_ad2").hide(200);
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(".ad_btn").click(function () {
            $(".ddwn_ad").toggle(200);
            $(".ddwn_grp").hide(200);
        });
        $(".cls_ad3, .fg13_n").click(function () {
            $(".ddwn_ad").hide(200);
            var SumTypeId = document.getElementById("<%=HiddenFieldSummaryIndvidual.ClientID%>").value; 
            var ChangeSts=document.getElementById("<%=HiddenFieldGrpChanged.ClientID%>").value; 
            if (SumTypeId != "" && ChangeSts=="1")
            ShowSummarySingle(SumTypeId,'');

        });
        $(".fg13_n").mouseover(function () {
            $(".ddwn_ad").hide(200);
            $(".ddwn_grp").hide(200);
            var SumTypeId = document.getElementById("<%=HiddenFieldSummaryIndvidual.ClientID%>").value;
            var ChangeSts = document.getElementById("<%=HiddenFieldGrpChanged.ClientID%>").value;
            if (SumTypeId != "" && ChangeSts == "1")
            ShowSummarySingle(SumTypeId, '');
        });
        $(".grp_btn").click(function () {
            $(".ddwn_grp").toggle(200);
            $(".ddwn_ad").hide(200);
            var SumTypeId = document.getElementById("<%=HiddenFieldSummaryIndvidual.ClientID%>").value;
            var ChangeSts = document.getElementById("<%=HiddenFieldGrpChanged.ClientID%>").value;
            if (SumTypeId != "" && ChangeSts == "1")
            ShowSummarySingle(SumTypeId, '');
        });
        $(".cls_ad4, .fg13_n").click(function () {
            $(".ddwn_grp").hide(200);
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(".hide_ser").click(function () {
            $(".ser_box").hide(400);
            $(".show_ser").show(400);
        });
        $(".show_ser").click(function () {
            $(".ser_box").show(400);
            $(".show_ser").hide(400);
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(window).scroll(function () {
            if ($(this).scrollTop() > 20) {
                $('#scroll').fadeIn();
            } else {
                $('#scroll').fadeOut();
            }
        });
        $('#scroll').click(function () {
            $(".content_container").animate({ scrollTop: 0 }, 600);
            return false;
        });
        $(".select2").select2({});


        var data = document.getElementById("<%=HiddenFieldDept.ClientID%>").value;
        var totalString = data;
        var eachString = totalString.split(',');
        var newVar = new Array();
        for (count = 0; count < eachString.length; count++) {
            if (eachString[count] != "") {
                newVar.push(eachString[count]);
            }
        }
        $('#cphMain_ddlDepartment').val(newVar);
        $("#cphMain_ddlDepartment").trigger("change");
        var data = document.getElementById("<%=HiddenFieldDivision.ClientID%>").value;
        var totalString = data;
        var eachString = totalString.split(',');
        var newVar = new Array();
        for (count = 0; count < eachString.length; count++) {
            if (eachString[count] != "") {
                newVar.push(eachString[count]);
            }
        }
        $('#cphMain_ddlDivision').val(newVar);
        $("#cphMain_ddlDivision").trigger("change");
        var data = document.getElementById("<%=HiddenFieldJob.ClientID%>").value;
        var totalString = data;
        var eachString = totalString.split(',');
        var newVar = new Array();
        for (count = 0; count < eachString.length; count++) {
            if (eachString[count] != "") {
                newVar.push(eachString[count]);
            }
        }
        $('#cphMain_ddlJob').val(newVar);
        $("#cphMain_ddlJob").trigger("change");
        var data = document.getElementById("<%=HiddenFieldStatus.ClientID%>").value;
        var totalString = data;
        var eachString = totalString.split(',');
        var newVar = new Array();
        for (count = 0; count < eachString.length; count++) {
            if (eachString[count] != "") {
                newVar.push(eachString[count]);
            }
        }
        $('#cphMain_ddlStatus').val(newVar);
        $("#cphMain_ddlStatus").trigger("change");
        var data = document.getElementById("<%=HiddenFieldLeaveType.ClientID%>").value;
        var totalString = data;
        var eachString = totalString.split(',');
        var newVar = new Array();
        for (count = 0; count < eachString.length; count++) {
            if (eachString[count] != "") {
                newVar.push(eachString[count]);
            }
        }
        $('#cphMain_ddlLeaveType').val(newVar);
        $("#cphMain_ddlLeaveType").trigger("change");
    });

</script>
    <script>

        function ValidateSearch() {

            var dtFromDate = document.getElementById("cphMain_txtFromDate").value;
            var dtToDate = document.getElementById("cphMain_txtToDate").value;

            document.getElementById("cphMain_txtFromDate").style.borderColor = "";
            document.getElementById("cphMain_txtToDate").style.borderColor = "";
            if (dtFromDate != "" && dtToDate != "") {

                var RcptdatepickerDate = dtFromDate;
                var RarrDatePickerDate = RcptdatepickerDate.split("-");
                var RdateDateCntrlr = new Date(RarrDatePickerDate[2], RarrDatePickerDate[1] - 1, RarrDatePickerDate[0]);


                var CurrentDateDate = dtToDate;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                if (RdateDateCntrlr > dateCurrentDate) {
                    document.getElementById("cphMain_txtToDate").style.borderColor = "Red";
                    $("#divWarning").html("Sorry,from date cannot be greater than to date !.");
                    $("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    document.getElementById("cphMain_txtToDate").focus();
                    return false;
                }

            }
            else {
                if (dtToDate == "") {
                    document.getElementById("cphMain_txtToDate").style.borderColor = "Red";
                    document.getElementById("cphMain_txtToDate").focus();
                }
                if (dtFromDate == "") {
                    document.getElementById("cphMain_txtFromDate").style.borderColor = "Red";
                    document.getElementById("cphMain_txtFromDate").focus();
                }
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                return false;
            }
            
            document.getElementById("<%=HiddenFieldGraphShow.ClientID%>").value = document.getElementById("<%=ddlReportType.ClientID%>").value;
            document.getElementById("<%=HiddenFieldDept.ClientID%>").value = $('#cphMain_ddlDepartment').val();
            document.getElementById("<%=HiddenFieldDivision.ClientID%>").value = $('#cphMain_ddlDivision').val();
            document.getElementById("<%=HiddenFieldJob.ClientID%>").value = $('#cphMain_ddlJob').val();
            document.getElementById("<%=HiddenFieldStatus.ClientID%>").value = $('#cphMain_ddlStatus').val();
            document.getElementById("<%=HiddenFieldLeaveType.ClientID%>").value = $('#cphMain_ddlLeaveType').val();


            document.getElementById("<%=HiddenFieldFromDate.ClientID%>").value = $('#cphMain_txtFromDate').val();
            document.getElementById("<%=HiddenFieldToDate.ClientID%>").value = $('#cphMain_txtToDate').val();
            document.getElementById("<%=HiddenFieldCategory.ClientID%>").value = $('#cphMain_ddlCategory').val();
            document.getElementById("<%=HiddenFieldSummary.ClientID%>").value = $('#cphMain_ddlSummaryType').val();
            var sumType=$('#cphMain_ddlSummaryType').val();
            document.getElementById("<%=HiddenFieldSummaryIndvidual.ClientID%>").value = "";
            document.getElementById("cphMain_TRadio" + sumType).checked = true;         
        }

        var objInp = {};

        function ShowSummarySingle(SumTypeId, CountLeave) {
            document.getElementById("<%=HiddenFieldGrpChanged.ClientID%>").value = "0";
            document.getElementById("<%=HiddenFieldSummaryIndvidual.ClientID%>").value = SumTypeId;          
            var OrgIdID = '<%=Session["ORGID"]%>';
            var CorpID = '<%=Session["CORPOFFICEID"]%>';
            var DeptIds=document.getElementById("<%=HiddenFieldDept.ClientID%>").value;
            var DivsIds=document.getElementById("<%=HiddenFieldDivision.ClientID%>").value;
            var JobIds=document.getElementById("<%=HiddenFieldJob.ClientID%>").value;
            var StatusIds=document.getElementById("<%=HiddenFieldStatus.ClientID%>").value;
            var LeaveTypIds=document.getElementById("<%=HiddenFieldLeaveType.ClientID%>").value;
            var FromDate=document.getElementById("<%=HiddenFieldFromDate.ClientID%>").value;
            var ToDate=document.getElementById("<%=HiddenFieldToDate.ClientID%>").value;
            var CategoryID=document.getElementById("<%=HiddenFieldCategory.ClientID%>").value;
            var SummaryID=document.getElementById("<%=HiddenFieldSummary.ClientID%>").value;
            objInp = {};
           
            objInp.OrgIdID = OrgIdID;
            objInp.CorpID = CorpID;
            objInp.DeptIds = DeptIds;
            objInp.DivsIds = DivsIds;
            objInp.JobIds = JobIds;
            objInp.StatusIds = StatusIds;
            objInp.LeaveTypIds = LeaveTypIds;
            objInp.FromDate = FromDate;
            objInp.ToDate = ToDate;
            objInp.CategoryID = CategoryID;
            objInp.SummaryID = SummaryID;
            objInp.SumTypeId = SumTypeId;
            if (document.getElementById("cbx2Lev0").checked == true) {
                objInp.ShowLeavTyp = 1;
            }
            else {
                objInp.ShowLeavTyp = 0;
            }
            if (document.getElementById("cbx2Lev1").checked == true) {
                objInp.ShowDept = 1;
            }
            else {
                objInp.ShowDept = 0;
            }
            if (document.getElementById("cbx2Lev2").checked == true) {
                objInp.ShowDivs = 1;
            }
            else {
                objInp.ShowDivs = 0;
            }
            if (document.getElementById("cbx2Lev3").checked == true) {
                objInp.ShowCtgry = 1;
            }
            else {
                objInp.ShowCtgry = 0;
            }
            if (document.getElementById("cbx2Lev5").checked == true) {
                objInp.ShowStatus = 1;
            }
            else {
                objInp.ShowStatus = 0;
            }


            $.ajax({
                async: false,
                type: "POST",
                url: "hcm_Leave_Application_Status_Report.aspx/LoadSummarySingleDtls",
                data: JSON.stringify(objInp),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    document.getElementById("tbodyLevel2").innerHTML = response.d;
                    if (CountLeave != "") {
                        document.getElementById("tdTotalLevel2").innerHTML = CountLeave;
                    }
                    $(".li2L" + SummaryID).hide();


                    $("#liColLevel2 input[type=checkbox]").each(function () {
                        var valCbx = $(this).val();
                        if (document.getElementById("cbx2Lev" + valCbx).checked == false) {
                            $(".grq" + valCbx).hide();
                        }
                        else {
                            $(".grq" + valCbx).show();
                        }
                    });


                    },
                    failure: function (response) {                       
                    }
                });
            return false;
        }
        var objInpC = {};
        function ShowSummaryLevel3(DeptIds, DivsIds, LeaveTypIds, CategoryID, StatusIds, totCnt, IndSumTypeId, CntTrgt, Level) {
            objInpC = {};
            document.getElementById("tbodyLevel3").innerHTML = "";
            $("#tableLevel3 th").show();
            $("#liColLevel3 li").show();
            if (Level == "L1") {
                Level = document.getElementById("<%=HiddenFieldSummary.ClientID%>").value;
            }
            else {
                if (document.getElementById("cphMain_TRadio0").checked == true) {
                    Level = 0;
                }
                else if (document.getElementById("cphMain_TRadio1").checked == true) {
                    Level = 1;
                }
                else if (document.getElementById("cphMain_TRadio2").checked == true) {
                    Level = 2;
                }
                else if (document.getElementById("cphMain_TRadio3").checked == true) {
                    Level = 3;
                }
                else if (document.getElementById("cphMain_TRadio5").checked == true) {
                    Level = 5;
                }
            }


            if (totCnt == "") {
                totCnt = document.getElementById(CntTrgt).innerHTML;
            }
            if (CntTrgt == "tdTotalLevel2") {
                IndSumTypeId = document.getElementById("<%=HiddenFieldSummaryIndvidual.ClientID%>").value;
            }
            var OrgIdID = '<%=Session["ORGID"]%>';
            var CorpID = '<%=Session["CORPOFFICEID"]%>';
            var FromDate = document.getElementById("<%=HiddenFieldFromDate.ClientID%>").value;
            var ToDate = document.getElementById("<%=HiddenFieldToDate.ClientID%>").value;           
            objInpC.OrgIdID = OrgIdID;
            objInpC.CorpID = CorpID;
            objInpC.FromDate = FromDate;
            objInpC.ToDate = ToDate;
            objInpC.SummaryID = document.getElementById("<%=HiddenFieldSummary.ClientID%>").value;
            objInpC.IndSumTypeId = IndSumTypeId;
            objInpC.Level = Level;
            if (DeptIds != "") {
                objInpC.DeptIds = DeptIds;
            }
            else {
                objInpC.DeptIds = document.getElementById("<%=HiddenFieldDept.ClientID%>").value;
            }
            if (DivsIds != "") {
                objInpC.DivsIds = DivsIds;
            }
            else {
                objInpC.DivsIds = document.getElementById("<%=HiddenFieldDivision.ClientID%>").value;
            }
            objInpC.JobIds = "";
            if (StatusIds != "") {
                objInpC.StatusIds = StatusIds;
            }
            else {
                objInpC.StatusIds = document.getElementById("<%=HiddenFieldStatus.ClientID%>").value;
            }
            if (LeaveTypIds != "") {
                objInpC.LeaveTypIds = LeaveTypIds;
            }
            else {
                objInpC.LeaveTypIds = document.getElementById("<%=HiddenFieldLeaveType.ClientID%>").value;
            }
            if (CategoryID != "") {
                objInpC.CategoryID = CategoryID;
            }
            else {
                objInpC.CategoryID = document.getElementById("<%=HiddenFieldCategory.ClientID%>").value;
            }
            objInpC.HideCols = "";
            $.ajax({
                async: false,
                type: "POST",
                url: "hcm_Leave_Application_Status_Report.aspx/ShowSummaryLevel3",
                data: JSON.stringify(objInpC),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    document.getElementById("tbodyLevel3").innerHTML = response.d;
                    document.getElementById("details_cls").style.display = "block";
                    document.getElementById("tdLevelsTot").innerHTML = totCnt;
                    $("#tableLevel3 .col" + objInpC.Level).hide();
                    $(".li" + objInpC.Level).hide();

                    $("#liColLevel3 input[type=checkbox]").each(function () {
                        var valCbx = $(this).val();
                        if (document.getElementById("cbx3Lev" + valCbx).checked == false && valCbx != objInpC.Level) {
                            $("#tableLevel3 .col" + valCbx).hide();
                        }                       
                    });
                },
                failure: function (response) {
                }
            });
            return false;
        }
        function ClickCbxColLevel3(id) {
            if (document.getElementById("cbx3Lev" + id).checked == true) {
                $("#tableLevel3 .col" + id).hide();
            }
            else {
                $("#tableLevel3 .col" + id).show();
            }                   
            return false;
        }
        function ClickCbxColLevel2(id) {
            document.getElementById("<%=HiddenFieldGrpChanged.ClientID%>").value = "1";            
            return false;
        }
        function PrintDetail() {

            if (document.getElementById("details_cls").style.display == "block") {

                var HideCols = objInpC.Level;
                if (HideCols == 10) {
                    HideCols = "A";
                }
                else if (HideCols == 11) {
                    HideCols = "B";
                }
                else if (HideCols == 12) {
                    HideCols = "C";
                }
                $("#liColLevel3 input[type=checkbox]").each(function () {
                    var valCbx = $(this).val();
                    if (document.getElementById("cbx3Lev" + valCbx).checked == false && valCbx != objInpC.Level) {
                        if (valCbx == 10) {
                            valCbx = "A";
                        }
                        else if (valCbx == 11) {
                            valCbx = "B";
                        }
                        else if (valCbx == 12) {
                            valCbx = "C";
                        }

                        HideCols = HideCols + "," + valCbx;
                    }
                });
                objInpC.HideCols = HideCols;


                $.ajax({
                    async: false,
                    type: "POST",
                    url: "hcm_Leave_Application_Status_Report.aspx/ShowSummaryLevel3Print",
                    data: JSON.stringify(objInpC),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {
                            window.open(data.d, '_blank');
                        }
                    }
                });
            }
            return false;
        }
        function PrintSummary() {            
            if (document.getElementById("divLev2").style.display == "") {
                $.ajax({
                    async: false,
                    type: "POST",
                    url: "hcm_Leave_Application_Status_Report.aspx/LoadSummarySingleDtlsPrint",
                    data: JSON.stringify(objInp),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {
                            window.open(data.d, '_blank');
                        }
                    }
                });
            }
        else if(document.getElementById("<%=HiddenFieldMainTotCnt.ClientID%>").value!="0"){
            var objInpSea = {};     
            objInpSea.OrgIdID = '<%=Session["ORGID"]%>';;
            objInpSea.CorpID = '<%=Session["CORPOFFICEID"]%>';
            objInpSea.DeptIds = document.getElementById("<%=HiddenFieldDept.ClientID%>").value;
            objInpSea.DivsIds = document.getElementById("<%=HiddenFieldDivision.ClientID%>").value;
            objInpSea.JobIds = document.getElementById("<%=HiddenFieldJob.ClientID%>").value;
            objInpSea.StatusIds = document.getElementById("<%=HiddenFieldStatus.ClientID%>").value;
            objInpSea.LeaveTypIds = document.getElementById("<%=HiddenFieldLeaveType.ClientID%>").value;
            objInpSea.FromDate = document.getElementById("<%=HiddenFieldFromDate.ClientID%>").value;
            objInpSea.ToDate = document.getElementById("<%=HiddenFieldToDate.ClientID%>").value;
            objInpSea.CategoryID = document.getElementById("<%=HiddenFieldCategory.ClientID%>").value;
            objInpSea.SummaryID = document.getElementById("<%=HiddenFieldSummary.ClientID%>").value;
                $.ajax({
                    async: false,
                    type: "POST",
                    url: "hcm_Leave_Application_Status_Report.aspx/LoadSummaryMainPrint",
                    data: JSON.stringify(objInpSea),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {
                            window.open(data.d, '_blank');
                        }
                    }
                });
            }
           return false;
        }
        function ConvertToJson(dataObj) {
            var find2 = '\\"\\[';
            var re2 = new RegExp(find2, 'g');
            var res2 = dataObj.replace(re2, '\[');

            var find3 = '\\]\\"';
            var re3 = new RegExp(find3, 'g');
            var res3 = res2.replace(re3, '\]');
            var json = $.parseJSON(res3);
            return json;
        }
    </script>
</asp:Content>

