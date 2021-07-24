<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="hcm_Employee_Addtn_Dedtn_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_Employee_Addtn_Dedtn_Report_hcm_Employee_Addtn_Dedtn_Report" %>

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
    <asp:HiddenField ID="HiddenFieldYear" runat="server" />
    <asp:HiddenField ID="HiddenFieldMonths" runat="server" />
    <asp:HiddenField ID="HiddenFieldDept" runat="server" />
    <asp:HiddenField ID="HiddenFieldDivision" runat="server" />
    <asp:HiddenField ID="HiddenFieldJob" runat="server" />
    <asp:HiddenField ID="HiddenFieldDesg" runat="server" />
    <asp:HiddenField ID="HiddenFieldEmployee" runat="server" />
    <asp:HiddenField ID="HiddenFieldAddition" runat="server" />
    <asp:HiddenField ID="HiddenFieldDeduction" runat="server" />
    <asp:HiddenField ID="HiddenFieldCategory" runat="server" />
    <asp:HiddenField ID="HiddenFieldMethod" runat="server" />
    <asp:HiddenField ID="HiddenFieldGraphData" runat="server" />
    <asp:HiddenField ID="HiddenFieldGrpChanged" runat="server" value="0"/>
    <asp:HiddenField ID="HiddenFieldLev2Month" runat="server" />
    <asp:HiddenField ID="HiddenFieldLev2Mode" runat="server" />
    <asp:HiddenField ID="HiddenFieldLev2Amnt" runat="server" />
    <asp:HiddenField ID="HiddenFieldCbxChangeLev3" runat="server" value="0"/>
    <asp:HiddenField ID="HiddenFieldLev3Dept" runat="server" />
    <asp:HiddenField ID="HiddenFieldLev3Divs" runat="server" />
    <asp:HiddenField ID="HiddenFieldLev3Ctgry" runat="server" />
    <asp:HiddenField ID="HiddenFieldLev3Mnths" runat="server" />
    <asp:HiddenField ID="HiddenFieldLev3mode" runat="server" />
    <asp:HiddenField ID="HiddenFieldDecCnt" runat="server" />
    <asp:HiddenField ID="HiddenFieldCrncyId" runat="server" />
    <asp:HiddenField ID="HiddenFieldNodataSts" runat="server" Value="0" />    
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
    <li class="active">Employee Addition & Deduction Report</li>
  </ol>

  <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr">
        <h2>Employee Addition & Deduction Report</h2>
        <button class="btn pull-right show_ser" title="show search area" style="display:none;" onclick="return false;">
          <i class="fa fa-caret-down"></i>
        </button>
        <div class="search_bo1 ser_box serch_bx1" style="display:block;">
          <div class="form-group fg2 sa_o_fg6 sa_480">
            <label for="email" class="fg2_la1">Year:<span class="spn1"></span></label>
            <select type="text" class="form-control fg2_inp1" id="ddlYear" runat="server">
            </select>
          </div>
          <div class="fg2 sa_o_fg6 sa_480 ma_bo4">
            <label for="pwd" class="fg2_la1">Month:<span class="spn1"></span> </label><br>
               <asp:DropDownList ID="ddlMonth" data-placeholder="All"  multiple="multiple" class="form-control fg2_inp1 grp1 select2" runat="server">
               </asp:DropDownList>
           
          </div>
          <div class="fg2 sa_o_fg6 sa_480 ma_bo4">
            <label for="pwd" class="fg2_la1">Department:<span class="spn1"></span> </label><br>
               <asp:DropDownList ID="ddlDepartment" data-placeholder="All" onchange="return changeEmp();"   multiple="multiple" class="form-control fg2_inp1 grp1 select2" runat="server">
               </asp:DropDownList>
          </div>
          <div class="fg2 sa_o_fg6 sa_480 ma_bo4">
            <label for="pwd" class="fg2_la1">Division:<span class="spn1"></span> </label><br>
            <asp:DropDownList ID="ddlDivision" data-placeholder="All" onchange="return changeEmp();"   multiple="multiple" class="form-control fg2_inp1 grp1 select2" runat="server">
             </asp:DropDownList>
          </div>
          <div class="fg2 sa_o_fg6 sa_480 ma_bo4">
            <label for="pwd" class="fg2_la1">Designation:<span class="spn1"></span> </label><br>
            <asp:DropDownList ID="ddlDesignation" data-placeholder="All" onchange="return changeEmp();"   multiple="multiple" class="form-control fg2_inp1 grp1 select2" runat="server">
             </asp:DropDownList>
          </div>
          <div class="fg2 sa_o_fg6 sa_480">
            <label for="pwd" class="fg2_la1">Category:<span class="spn1"></span> </label><br>
           <select class="form-control fg2_inp1 grp1" id="ddlCategory" onchange="return changeEmp();"  runat="server">
                 <option value="2">ALL</option>
                <option value="0">STAFF</option>
                <option value="1">WORKER</option>
               
              </select>
          </div>
          <div class="fg2 sa_o_fg6 sa_480 ma_bo4">
            <label for="pwd" class="fg2_la1">Job:<span class="spn1"></span> </label><br>
             <asp:DropDownList ID="ddlJob" data-placeholder="All"  multiple="multiple" class="form-control fg2_inp1 grp1 select2" runat="server">
             </asp:DropDownList>
          </div>
          <div class="fg2 sa_o_fg6 sa_480 ma_bo4">
            <label for="pwd" class="fg2_la1">Employee:<span class="spn1"></span> </label><br>
             <asp:DropDownList ID="ddlEmployee" data-placeholder="All"  multiple="multiple" class="form-control fg2_inp1 grp1 select2" runat="server">
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
          <div class="fg2 sa_o_fg6 sa_480 ma_bo4">
            <label for="pwd" class="fg2_la1">Additions:<span class="spn1"></span> </label><br>
           <asp:DropDownList ID="ddlAddition" data-placeholder="All"  multiple="multiple" class="form-control fg2_inp1 grp1 select2" runat="server">
             </asp:DropDownList>
          </div>
          <div class="fg2 sa_o_fg6 sa_480 ma_bo4">
            <label for="pwd" class="fg2_la1">Deductions:<span class="spn1"></span> </label><br>
          <asp:DropDownList ID="ddlDeduction" data-placeholder="All"  multiple="multiple" class="form-control fg2_inp1 grp1 select2" runat="server">
             </asp:DropDownList>
          </div>

          <div class="form-group fg7 sa_o_fg6 sa_480">
            <label for="email" class="fg2_la1">Display Method:<span class="spn1"></span></label>
            <select type="text" class="form-control fg2_inp1 met_1_2" id="ddlMethod" runat="server">
              <option value="1">Method 1</option>
              <option value="2">Method 2</option>
            </select>
          </div>
                  
          <div class="form-group fg8 sa_480 pull-right">
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
          <div class="fg12 sumry_1" style="display:block;width:50%;">
            <h3>Summary</h3>
            <div class="fg12 txt_01">
              <div class="fg13_n">
                <div class="tab_res">
                  <div class="r_1024">
                    <table class="display table-bordered pro_tab1 tbl_1024 tbl_ad_de" cellspacing="0" width="100%">
                      <thead class="thead1">
                        <tr>
                          <th class="th_b6 tr_l">Month</th>
                          <th class="th_b1 tr_r">Addition<br> Total</th>
                          <th class="th_b1 tr_r">Deduction<br> Total</th>
                          <th class="th_b8 tr_r">Manual<br> Addition Total</th>
                          <th class="th_b8 tr_r">Manual<br> Deduction Total</th>
                          <th class="th_b1 tr_r">Total<br> Addition</th>
                          <th class="th_b1 tr_r">Total<br> Deduction</th>
                        </tr>
                      </thead>
                      <tbody id="tBodyLevel1" runat="server">
                      
                      </tbody>
                      <tfoot class="clr_hrd" id="tFootLevel1" runat="server">
                      
                      </tfoot> 
                    </table>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="fg12 sumry_cls_2" style="display:none;width:100%;margin: auto;float: left;" id="divLev2M2">
            <h3>Summary</h3>
            <div class="fg12 txt_01">
              <div class="fg13_M2">
                <div class="tab_res">
                  <div class="r_fl">
                    <table class="display table-bordered pro_tab1 tbl_fl fl2000 tbl_ad_de" cellspacing="0" width="100%" id="tabLev2M2">                     
                    </table>
                  </div>
                </div>
              </div>
              <div class="fg13_r bg_slr">
                <button class="btn btn_comp ad_btn3" type="button" id="Button2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" onclick="return false;">
                  <i class="fa fa-compress"></i>
                </button>
                  <div class="ddwn ddwn_ad3" style="display:none;" id="liColLevel2M2">
                  </div>             
              </div>
            </div>
          </div>
          <div class="fg12 sumry_cls_3" style="display:none;width:50%;margin: auto;float: left;">
            <h3>Summary</h3>
            <div class="fg12 txt_01">
              <div class="fg13_n">
                <div class="tab_res">
                  <div class="r_fl" id="tabFirstMthd2" runat="server">
                  </div>
                </div>
              </div>
            </div>
          </div>   
          <div class="sumry_2_6 mar_bt10" style="display:none;" id="divLev2M1">
            <div class="fg12">
              <h3>Summary on "Month Name"</h3>
              <button class="btn tab_but1 butn3 flt_r back1_6" title="Back" onclick="return false;">
                <i class="fa fa-arrow-circle-left"></i>
              </button>
            </div>
            <div class="clearfix"></div>
            <div class="fg12">
              <div class="fg13_n flt_l">
                <div class="tab_res">
                  <div class="r_1024">
                    <table class="display table-bordered pro_tab1 tbl_1024" cellspacing="0" width="100%">
                      <thead class="thead1">
                        <tr>
                          <th class="th_b6 tr_l dep_1 grq0">Department
                          </th>
                          <th class="th_b6 tr_l div_1 grq1">Division
                          </th>
                          <th class="th_b6 tr_l cat_1 grq2">Category
                          </th>
                          <th class="th_b6 tr_l job_1 grq3">Job
                          </th>
                          <th class="th_b6 tr_c sta_1 grq4">Month
                          </th>
                          <th class="th_b7 tr_r m1">Addition</th>
                          <th class="th_b7 tr_r m2">Deduction</th>
                          <th class="th_b7 tr_r m3">Manual<br>Addition</th>
                          <th class="th_b7 tr_r m4">Manual<br>Deduction</th>
                          <th class="th_b7 tr_r m5">Total<br>Addition</th>
                          <th class="th_b7 tr_r m6">Total<br>Deduction</th>
                        </tr>
                      </thead>
                      <tbody id="tbodyLevel2">
                    
                      </tbody>
                      <tfoot class="clr_hrd" id="tFootLevel2">
                       
                      </tfoot>
                    </table>
                  </div>
                </div>
              </div>
              <div class="fg13_r bg_slr">
                <button class="btn btn_comp ad_btn" type="button" id="Button15" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                  <i class="fa fa-compress"></i>
                </button>
                <div class="ddwn ddwn_ad" style="display:none;" id="liColLevel2"> 
                  <button class="pull-right cls_ad3"><i class="fa fa-close" onclick="return false;"></i></button>
                    <li class="dropdown-item" href="#">
                      <label class="form1 mar_bo">
                        <span class="button-checkbox">
                          <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel2();" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                          <input type="checkbox" class="hidden" checked="" id="cbx2Lev0" value="0">
                        </span>
                        <p class="pz_s">Department</p>
                      </label>
                    </li>
                    <li class="dropdown-item" href="#">
                      <label class="form1 mar_bo">
                        <span class="button-checkbox">
                          <button type="button" class="active btn-p" data-color="p"  onclick="return ClickCbxColLevel2();" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                          <input type="checkbox" class="hidden" checked="" id="cbx2Lev1" value="1">
                        </span>
                        <p class="pz_s">Division</p>
                      </label>
                    </li>
                    <li class="dropdown-item" href="#">
                      <label class="form1 mar_bo">
                        <span class="button-checkbox">
                          <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel2();" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                          <input type="checkbox" class="hidden" checked="" id="cbx2Lev2" value="2">
                        </span>
                        <p class="pz_s">Category</p>
                      </label>
                    </li>
                    <li class="dropdown-item" href="#">
                      <label class="form1 mar_bo">
                        <span class="button-checkbox">
                          <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel2();" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                          <input type="checkbox" class="hidden" checked="" id="cbx2Lev3" value="3">
                        </span>
                        <p class="pz_s">Job</p>
                      </label>
                    </li>
                    <li class="dropdown-item" href="#">
                      <label class="form1 mar_bo">
                        <span class="button-checkbox">
                          <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxColLevel2();" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>&nbsp;</button>
                          <input type="checkbox" class="hidden" checked="" id="cbx2Lev4" value="4">
                        </span>
                        <p class="pz_s">Month</p>
                      </label>
                    </li>
                </div>
              </div>
              <div class="fg13_r bg_slr">
                <button class="btn btn_comp grp_btn" type="button" id="Button16" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                  <i class="fa fa-link"></i>
                </button>
                <div class="ddwn ddwn_grp" style="display:none;">
                  
                  <button class="pull-right cls_ad4"><i class="fa fa-close"></i></button>
                <li class="dropdown-item" href="#">
                  <li class="dropdown-item" href="#">
                    <input class="form-check-input flt_l" type="radio" name="radio_grp" id="Radio34" value="option2" checked="">
                    <p class="pz_s">Department</p>
                  </li>
                  <li class="dropdown-item" href="#">
                    <input class="form-check-input flt_l" type="radio" name="radio_grp" id="Radio35" value="option2">
                    <p class="pz_s">Division</p>
                  </li>
                  <li class="dropdown-item" href="#">
                    <input class="form-check-input flt_l" type="radio" name="radio_grp" id="Radio36" value="option2">
                    <p class="pz_s">Category</p>
                  </li>
                  <li class="dropdown-item" href="#">
                    <input class="form-check-input flt_l" type="radio" name="radio_grp" id="Radio37" value="option2">
                    <p class="pz_s">Job</p>
                  </li>
                  <li class="dropdown-item" href="#">
                    <input class="form-check-input flt_l" type="radio" name="radio_grp" id="Radio38" value="option2">
                    <p class="pz_s">Month</p>
                  </li>
                </div>
              </div>
            </div>
          </div>
          <div class="fg6 mr_at flt_l sum_grpz" style="display:block;width:50%;margin: auto;float: left;">
            <!-- <h3>Application Count: <a href="#area_sec1" class="bt_dtl_1"><span class="rd">100</span></a></h3> -->
            <div class="example-box">
              <div class="example__headline">
              </div>
                 <div id="graph1" width="90%;"></div> 
                 <div class="col-xs-12 dis_none" style="text-align: center; color: #999">                     
                        <span><span class="emp_box" style="background-color: rgba(78, 204, 93, 0.6)"></span><span style="margin-left: 3%;">Addition Total</span></span>
                        <span><span class="emp_box" style="background-color: rgba(223, 62, 66, 0.6)"></span><span style="margin-left: 3%;">Deduction Total</span></span>
                        <span><span class="emp_box" style="background-color: rgba(62, 153, 223, 0.6)"></span><span style="margin-left: 3%;">Manual Addition</span></span>
                        <span><span class="emp_box" style="background-color: rgba(251, 181, 139, 0.6)"></span><span style="margin-left: 3%;">Manual Deduction</span></span>
                    </div>               
             <%-- <canvas id="densityChart" width="90%;"></canvas>--%>
            </div>
          </div>
        </div>

        <div class="clearfix"></div>

        <div id="details_cls" class="details_cls" style="display:none;">
          <div class="free_sp"></div>
          <div class="devider"></div>
          <div class="fg12">
            <h3>Details section</h3>
            <button class="btn tab_but1 butn4 flt_r close1" title="Back" onclick="return false;">
              <i class="fa fa-close"></i>
            </button>
          </div>
          <div class="fg13_n mr_at flt_l">
            <div class="r_fl">
              <table class="display table-bordered pro_tab1 tbl_ad_de tbl_wdt_rpt" cellspacing="0" width="100%" id="tabLevel3">

              </table>
            </div>
          </div>
          <div class="fg13_r bg_slr">
            <button class="btn btn_comp ad_btn2" type="button" id="Button17" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" onclick="return false;">
              <i class="fa fa-compress"></i>
            </button>
            <div class="ddwn ddwn_ad2" style="display:none;" id="liColLevel3">    
                         
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
<a href="#" type="button" class="imprt_o" title="Export" onclick="import_1()" style="display:none;">
  <i class="fa fa-code-fork" aria-hidden="true"></i>
</a>
<div class="import_opt">
  <button class="csv_b"><i class="fa fa-file-excel-o" aria-hidden="true"></i>CSV</button> 
  <button class="pdf_b"><i class="fa fa-file-pdf-o" aria-hidden="true"></i>PDF</button>
</div>
<!---import_button_section_closed--->

<!---Back to top_section_strted-->
<a href="#" type="button" class="bck_opt" title="Print page" id="scroll" onclick="topbtn()">
  <i class="fa fa-angle-up"></i>
</a>
<!---Back to top_section_closed--->


<!----hide/Show_section---->
<script>
    $(document).ready(function () {
        $("#hide").click(function () {
            $(".c1h").hide();
        });
        $("#show").click(function () {
            $(".c1h").show();
        });
        $(".select2").select2({});
    });
</script>

<!----hide/Show_section2---->
<script>
    $(document).ready(function () {
        $("#hide").click(function () {
            $(".c2h").hide();
        });
        $("#show1").click(function () {
            $(".c2h").show();
        });
    });
</script>

<!-----Enable_disable script--->
<script>
    $(document).ready(function () {
        $(".bu1").click(function () {
            $("#mySe1").toggle();
        });
    });
</script>
<script>
    $(document).ready(function () {
        $(".bu").click(function () {
            $("#mySe").toggle();
        });
    });
</script>
<!-----Enable_disable script_closed--->

<!------hide and visible div--->
<script>
    function sel1() {
        var x = document.getElementById('sel');
        if (x.style.display === 'none') {
            x.style.display = 'block';
        } else {
            x.style.display = 'none';
        }
    }
</script>
<!------hide and visible div_closed--->


<!-----table_sec_fixed--->
<script type="text/javascript">
    // requires jquery library
    jQuery(document).ready(function () {
        jQuery(".main-table").clone(true).appendTo('#table-scroll').addClass('clone');
    });

</script>

<!---multiple selection new_script--->
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
          data: json1.data,
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
            $(".sumry_1").fadeIn(1000);
        });
        $(".bt_sumry_2").click(function () {
            if (parseFloat($(this).text()) != "0") {
                $(".sumry_2").fadeIn(1000);
                $(".sumry_1").hide();
                $(".sum_grpz").hide(200);
            }
        });
    });
</script>
<script>
    $(document).ready(function () {
        $(".back1_1").click(function () {
            $(".sumry_2_1").hide();
            $(".sumry_1").fadeIn(1000);
        });
        $(".bt_sumry_2_1").click(function () {
            if (parseFloat($(this).text()) != "0") {
                $(".sumry_2_1").fadeIn(1000);
                $(".sumry_1").hide();
                $(".sum_grpz").hide(200);
            }
        });
    });
</script>


<script>
    $(document).ready(function () {
        $(".back1_2").click(function () {
            $(".sumry_2_2").hide();
            $(".sumry_1").fadeIn(1000);
        });
        $(".bt_sumry_2_2").click(function () {
            if (parseFloat($(this).text()) != "0") {
                $(".sumry_2_2").fadeIn(1000);
                $(".sumry_1").hide();
                $(".sum_grpz").hide(200);
            }
        });
    });
</script>
<script>
    $(document).ready(function () {
        $(".back1_3").click(function () {
            $(".sumry_2_3").hide();
            $(".sumry_1").fadeIn(1000);
        });
        $(".bt_sumry_2_3").click(function () {
            if (parseFloat($(this).text()) != "0") {
                $(".sumry_2_3").fadeIn(1000);
                $(".sumry_1").hide();
                $(".sum_grpz").hide(200);
            }
        });
    });
</script>
<script>
    $(document).ready(function () {
        $(".back1_4").click(function () {
            $(".sumry_2_4").hide();
            $(".sumry_1").fadeIn(1000);
        });
        $(".bt_sumry_2_4").click(function () {
            if (parseFloat($(this).text()) != "0") {
                $(".sumry_2_4").fadeIn(1000);
                $(".sumry_1").hide();
                $(".sum_grpz").hide(200);
            }
        });
    });
</script>
<script>
    $(document).ready(function () {
        $(".back1_5").click(function () {
            $(".sumry_2_5").hide();
            $(".sumry_1").fadeIn(1000);
        });
        $(".bt_sumry_2_5").click(function () {
            if (parseFloat($(this).text()) != "0") {
                $(".sumry_2_5").fadeIn(1000);
                $(".sumry_1").hide();
                $(".sum_grpz").hide(200);
            }
        });
    });
</script>
<script>
    $(document).ready(function () {
        $(".back1_6").click(function () {
            $(".sumry_2_6").hide();
            $(".sumry_1").fadeIn(1000);
        });
        $(".bt_sumry_2_6").click(function () {
            if (parseFloat($(this).text()) != "0") {
                $(".sumry_2_6").fadeIn(1000);
                $(".sumry_1").hide();
                $(".sum_grpz").hide(200);
            }
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
<!---details section script_closed--->
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
            var Dept = document.getElementById("<%=HiddenFieldLev3Dept.ClientID%>").value;
            var Divs = document.getElementById("<%=HiddenFieldLev3Divs.ClientID%>").value;
            var Ctgry = document.getElementById("<%=HiddenFieldLev3Ctgry.ClientID%>").value;
            var Mnths = document.getElementById("<%=HiddenFieldLev3Mnths.ClientID%>").value;
            var mode = document.getElementById("<%=HiddenFieldLev3mode.ClientID%>").value;
            var ChangeSts = document.getElementById("<%=HiddenFieldCbxChangeLev3.ClientID%>").value;
            if (ChangeSts == "1")
                ShowSummaryLevel3(Dept, Divs, Ctgry, Mnths, mode, 1);
        });
        $(".fg13_n").mouseover(function () {
            $(".ddwn_ad2").hide(200);
            var Dept = document.getElementById("<%=HiddenFieldLev3Dept.ClientID%>").value;
            var Divs = document.getElementById("<%=HiddenFieldLev3Divs.ClientID%>").value;
            var Ctgry = document.getElementById("<%=HiddenFieldLev3Ctgry.ClientID%>").value;
            var Mnths = document.getElementById("<%=HiddenFieldLev3Mnths.ClientID%>").value;
            var mode = document.getElementById("<%=HiddenFieldLev3mode.ClientID%>").value;
            var ChangeSts = document.getElementById("<%=HiddenFieldCbxChangeLev3.ClientID%>").value;
            if (ChangeSts == "1")
                ShowSummaryLevel3(Dept, Divs, Ctgry, Mnths, mode, 1);
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
            var Mnth=document.getElementById("<%=HiddenFieldLev2Month.ClientID%>").value; 
            var Mode=document.getElementById("<%=HiddenFieldLev2Mode.ClientID%>").value; 
            var Amnt=document.getElementById("<%=HiddenFieldLev2Amnt.ClientID%>").value;  
            var ChangeSts=document.getElementById("<%=HiddenFieldGrpChanged.ClientID%>").value; 
            if (ChangeSts == "1")
                ShowLevel2(Mnth, Mode, Amnt);
        });
        $(".fg13_n").mouseover(function () {
            $(".ddwn_ad").hide(200);
            $(".ddwn_grp").hide(200);
            var Mnth = document.getElementById("<%=HiddenFieldLev2Month.ClientID%>").value;
            var Mode = document.getElementById("<%=HiddenFieldLev2Mode.ClientID%>").value;
            var Amnt = document.getElementById("<%=HiddenFieldLev2Amnt.ClientID%>").value;
            var ChangeSts = document.getElementById("<%=HiddenFieldGrpChanged.ClientID%>").value;
            if (ChangeSts == "1")
                ShowLevel2(Mnth, Mode, Amnt);
        });
        $(".grp_btn").click(function () {
            $(".ddwn_grp").toggle(200);
            $(".ddwn_ad").hide(200);
            var Mnth = document.getElementById("<%=HiddenFieldLev2Month.ClientID%>").value;
            var Mode = document.getElementById("<%=HiddenFieldLev2Mode.ClientID%>").value;
            var Amnt = document.getElementById("<%=HiddenFieldLev2Amnt.ClientID%>").value;
            var ChangeSts = document.getElementById("<%=HiddenFieldGrpChanged.ClientID%>").value;
            if (ChangeSts == "1")
                ShowLevel2(Mnth, Mode, Amnt);
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
        $(".met_1_2").click(function () {
            //$(".sumry_1").hide(100);
            //$(".sumry_cls_3").fadeIn(1000);
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(".btn_met2").click(function () {
            $(".sum_grpz").hide(100);
            $(".details_cls").fadeIn(1000);
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(".bt_spl1").click(function () {
            if ($(this).text() != "0") {
                $(".sumry_cls_3").hide(100);
                $(".sum_grpz").hide(100);
                $(".sumry_cls_2").fadeIn(1000);
            }
        });
        $(".back1_mtd2").click(function () {
            $(".sumry_cls_2").hide(100);
            $(".sum_grpz").fadeIn(1000);
            $(".sumry_cls_3").fadeIn(1000);
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(".ad_btn3").click(function () {
            $(".ddwn_ad3").toggle(200);
            var Mnth = document.getElementById("<%=HiddenFieldLev2Month.ClientID%>").value;
            var Mode = document.getElementById("<%=HiddenFieldLev2Mode.ClientID%>").value;
            var PayrlId = document.getElementById("<%=HiddenFieldLev2Amnt.ClientID%>").value;
            var ChangeSts = document.getElementById("<%=HiddenFieldGrpChanged.ClientID%>").value;
            if (ChangeSts == "1")
                ShowLevel2M2(Mnth, PayrlId, Mode, 1, 1);
        });
        $(".cls_adM2, .fg13_M2").click(function () {
            $(".ddwn_ad3").hide(200);
            var Mnth = document.getElementById("<%=HiddenFieldLev2Month.ClientID%>").value;
            var Mode = document.getElementById("<%=HiddenFieldLev2Mode.ClientID%>").value;
            var PayrlId = document.getElementById("<%=HiddenFieldLev2Amnt.ClientID%>").value;
            var ChangeSts = document.getElementById("<%=HiddenFieldGrpChanged.ClientID%>").value;
            if (ChangeSts == "1")
                ShowLevel2M2(Mnth, PayrlId, Mode, 1, 1);
        });
        $(".fg13_M2").mouseover(function () {
            $(".ddwn_ad3").hide(200);
            var Mnth = document.getElementById("<%=HiddenFieldLev2Month.ClientID%>").value;
            var Mode = document.getElementById("<%=HiddenFieldLev2Mode.ClientID%>").value;
            var PayrlId = document.getElementById("<%=HiddenFieldLev2Amnt.ClientID%>").value;
            var ChangeSts = document.getElementById("<%=HiddenFieldGrpChanged.ClientID%>").value;
            if (ChangeSts == "1")
                ShowLevel2M2(Mnth, PayrlId, Mode, 1, 1);
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(".bt_sumry_2_md").click(function () {
            $(".sum_grpz").hide(100);
            $("sumry_cls_3").hide(100);
            $(".details_cls").fadeIn(1000);
        });
    });
</script>

<script>
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


        var TotalData = document.getElementById("<%=HiddenFieldGraphData.ClientID%>").value;
        var TotalDataBarChart = "";
        if (TotalData != "") {
            TotalDataBarChart = ConvertToJson(TotalData);
            Morris.Bar({
                element: 'graph1',
                data: TotalDataBarChart,
                xkey: 'MONTH',
                ykeys: ['BA', 'BD','MA','MD'],
                labels: ['Addition Total', 'Deduction Total','Manual Addition','Manual Deduction'],
                resize: 'true',
                barColors: ['rgba(78, 204, 93, 0.6)', 'rgba(223, 62, 66, 0.6)', 'rgba(62, 153, 223, 0.6)', 'rgba(251, 181, 139, 0.6)'],
                hideHover: false,
                xLabelAngle: 90,
                gridTextWeight: "bold",
                legends: 'true'
            }).on('click', function (i, row) {
                console.log(i, row);
            });
        }

        if (document.getElementById("<%=ddlReportType.ClientID%>").value == "1") {
            $(".sum_grpz").hide(100);
            if (document.getElementById("<%=HiddenFieldMethod.ClientID%>").value == "2") {
                $(".sumry_1").hide(100);
                $(".sumry_cls_3").fadeIn(1000);
            }
            //else {
            //    $(".sumry_1").show(100);
            //}
        }
        else if (document.getElementById("<%=ddlReportType.ClientID%>").value == "2") {
             $(".sum_grpz").show(100);
             $(".sumry_1").hide(100);
             $(".sumry_cls_3").hide(100);
         }
         else {
            $(".sum_grpz").show(100);
            if (document.getElementById("<%=HiddenFieldMethod.ClientID%>").value == "2") {
                $(".sumry_1").hide(100);
                $(".sumry_cls_3").fadeIn(1000);
            }
             //$(".sumry_1").show(100);
        }
        
    });
</script>
    <script>
        function changeEmp() {          
            $("#cphMain_ddlEmployee").val(null).trigger("change");
            var orgID = '<%= Session["ORGID"] %>';
            var corpId = '<%= Session["CORPOFFICEID"] %>';
            var Dept = $('#cphMain_ddlDepartment').val();
            var Divs = $('#cphMain_ddlDivision').val();
            var Desg = $('#cphMain_ddlDesignation').val();
            var Catgry = $('#cphMain_ddlCategory').val();
            Dept = String(Dept).replace(/,/g, '-');
            Divs = String(Divs).replace(/,/g, '-');
            Desg = String(Desg).replace(/,/g, '-');

            if (orgID != null && orgID != "" && orgID != "null" && corpId != null && corpId != "" && corpId != "null") {
                var objInp = {};
                objInp.orgID = orgID;
                objInp.corpId = corpId;
                objInp.Dept = Dept;
                objInp.Divs = Divs;
                objInp.Desg = Desg;
                objInp.Catgry = Catgry;
                $.ajax({
                    async: false,
                    type: "POST",
                    url: "hcm_Employee_Addtn_Dedtn_Report.aspx/changeEmployee",
                    data: JSON.stringify(objInp),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                            document.getElementById("cphMain_ddlEmployee").innerHTML = data.d;
                    }
                });
            }
            return false;
        }
        function ValidateSearch() {           
            document.getElementById("<%=HiddenFieldYear.ClientID%>").value = $('#cphMain_ddlYear').val();
            document.getElementById("<%=HiddenFieldMonths.ClientID%>").value = $('#cphMain_ddlMonth').val();
            document.getElementById("<%=HiddenFieldDept.ClientID%>").value = $('#cphMain_ddlDepartment').val();
            document.getElementById("<%=HiddenFieldDivision.ClientID%>").value = $('#cphMain_ddlDivision').val();
            document.getElementById("<%=HiddenFieldJob.ClientID%>").value = $('#cphMain_ddlJob').val();
            document.getElementById("<%=HiddenFieldDesg.ClientID%>").value = $('#cphMain_ddlDesignation').val();
            document.getElementById("<%=HiddenFieldEmployee.ClientID%>").value = $('#cphMain_ddlEmployee').val();
            document.getElementById("<%=HiddenFieldAddition.ClientID%>").value = $('#cphMain_ddlAddition').val();
            document.getElementById("<%=HiddenFieldDeduction.ClientID%>").value = $('#cphMain_ddlDeduction').val();
            document.getElementById("<%=HiddenFieldCategory.ClientID%>").value = $('#cphMain_ddlCategory').val();
            document.getElementById("<%=HiddenFieldMethod.ClientID%>").value = $('#cphMain_ddlMethod').val();
            document.getElementById("<%=HiddenFieldLev2Month.ClientID%>").value = "";
            document.getElementById("<%=HiddenFieldLev2Mode.ClientID%>").value = "";
            document.getElementById("<%=HiddenFieldLev2Amnt.ClientID%>").value = "";

            document.getElementById("<%=HiddenFieldLev3Dept.ClientID%>").value = "";
            document.getElementById("<%=HiddenFieldLev3Divs.ClientID%>").value = "";
            document.getElementById("<%=HiddenFieldLev3Ctgry.ClientID%>").value = "";
            document.getElementById("<%=HiddenFieldLev3Mnths.ClientID%>").value = "";
            document.getElementById("<%=HiddenFieldLev3mode.ClientID%>").value = "";
        }
    </script>
    <style>
        .emp_box {
    width: 10px;
    height: 10px;
    position: absolute;
    margin: 5px;
}
    </style>
    <script>
        function ClickCbxColLevel2() {
            document.getElementById("<%=HiddenFieldGrpChanged.ClientID%>").value = "1";
            return false;
        }
        var objInp = {};
        function ShowLevel2(Mnth, Mode, Amnt) {
            if (Amnt != "0") {
                document.getElementById("<%=HiddenFieldGrpChanged.ClientID%>").value = "0";
                document.getElementById("<%=HiddenFieldLev2Month.ClientID%>").value = Mnth; 
                document.getElementById("<%=HiddenFieldLev2Mode.ClientID%>").value = Mode; 
                document.getElementById("<%=HiddenFieldLev2Amnt.ClientID%>").value = Amnt; 
                objInp = {};
                objInp.orgID = '<%= Session["ORGID"] %>';
                objInp.corpId = '<%= Session["CORPOFFICEID"] %>';
                objInp.year = document.getElementById("<%=HiddenFieldYear.ClientID%>").value;
                objInp.month = document.getElementById("<%=HiddenFieldMonths.ClientID%>").value;
                objInp.dept = document.getElementById("<%=HiddenFieldDept.ClientID%>").value;
                objInp.divsn = document.getElementById("<%=HiddenFieldDivision.ClientID%>").value;
                objInp.job = document.getElementById("<%=HiddenFieldJob.ClientID%>").value;
                objInp.desg = document.getElementById("<%=HiddenFieldDesg.ClientID%>").value;
                objInp.emp = document.getElementById("<%=HiddenFieldEmployee.ClientID%>").value;
                objInp.Addtn = document.getElementById("<%=HiddenFieldAddition.ClientID%>").value;
                objInp.Dedtn = document.getElementById("<%=HiddenFieldDeduction.ClientID%>").value;
                objInp.catgry = document.getElementById("<%=HiddenFieldCategory.ClientID%>").value;
                objInp.method = document.getElementById("<%=HiddenFieldMethod.ClientID%>").value;
                if (Mnth != "") {
                    objInp.month = Mnth;
                }
                if (document.getElementById("cbx2Lev0").checked == true) {
                    objInp.ShowDep = 1;
                }
                else {
                    objInp.ShowDep = 0;
                }
                if (document.getElementById("cbx2Lev1").checked == true) {
                    objInp.ShowDiv = 1;
                }
                else {
                    objInp.ShowDiv = 0;
                }
                if (document.getElementById("cbx2Lev2").checked == true) {
                    objInp.ShowCat = 1;
                }
                else {
                    objInp.ShowCat = 0;
                }
                if (document.getElementById("cbx2Lev3").checked == true) {
                    objInp.ShowJob = 1;
                }
                else {
                    objInp.ShowJob = 0;
                }
                if (document.getElementById("cbx2Lev4").checked == true) {
                    objInp.ShowMon = 1;
                }
                else {
                    objInp.ShowMon = 0;
                }
                objInp.Dcm = document.getElementById("<%=HiddenFieldDecCnt.ClientID%>").value;
                objInp.Crn = document.getElementById("<%=HiddenFieldCrncyId.ClientID%>").value;
                objInp.mode = Mode;
                if (objInp.orgID != null && objInp.orgID != "" && objInp.orgID != "null" && objInp.corpId != null && objInp.corpId != "" && objInp.corpId != "null") {
                    $.ajax({
                        async: false,
                        type: "POST",
                        url: "hcm_Employee_Addtn_Dedtn_Report.aspx/ShowLevel2",
                        data: JSON.stringify(objInp),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            document.getElementById("tbodyLevel2").innerHTML = data.d[0];
                            document.getElementById("tFootLevel2").innerHTML = data.d[1];
                            $("#liColLevel2 input[type=checkbox]").each(function () {
                                var valCbx = $(this).val();
                                if (document.getElementById("cbx2Lev" + valCbx).checked == false) {
                                    $(".grq" + valCbx).hide();
                                }
                                else {
                                    $(".grq" + valCbx).show();
                                }
                            });
                            if (Mode == "1") {
                                $(".m1").show();
                                $(".m2,.m3,.m4,.m5,.m6").hide();
                            }
                            else if (Mode == "2") {
                                $(".m2").show();
                                $(".m1,.m3,.m4,.m5,.m6").hide();
                            }
                            else if (Mode == "3") {
                                $(".m3").show();
                                $(".m2,.m1,.m4,.m5,.m6").hide();
                            }
                            else if (Mode == "4") {
                                $(".m4").show();
                                $(".m2,.m3,.m1,.m5,.m6").hide();
                            }
                            else if (Mode == "5") {
                                $(".m1,.m3,.m5").show();
                                $(".m2,.m4,.m6").hide();
                            }
                            else if (Mode == "6") {
                                $(".m1,.m3,.m5").hide();
                                $(".m2,.m4,.m6").show();
                            }
                            else {
                                $(".m1,.m2,.m3,.m4,.m5,.m6").show();
                            }
                            $(".sumry_2_6").show();

                        }
                    });
                }
            }           
            return false;
        }
        var objInpC = {};
        function ShowLevel2M2(Mnth, PayrlId, Mode, source, currAmt) {
            if (currAmt != 0) {
                document.getElementById("<%=HiddenFieldGrpChanged.ClientID%>").value = "0";
                document.getElementById("<%=HiddenFieldLev2Month.ClientID%>").value = Mnth;
                document.getElementById("<%=HiddenFieldLev2Mode.ClientID%>").value = Mode;
                document.getElementById("<%=HiddenFieldLev2Amnt.ClientID%>").value = PayrlId;
                objInpC = {};
                objInpC.orgID = '<%= Session["ORGID"] %>';
                objInpC.corpId = '<%= Session["CORPOFFICEID"] %>';
                objInpC.year = document.getElementById("<%=HiddenFieldYear.ClientID%>").value;
                objInpC.month = document.getElementById("<%=HiddenFieldMonths.ClientID%>").value;
                objInpC.dept = document.getElementById("<%=HiddenFieldDept.ClientID%>").value;
                objInpC.divsn = document.getElementById("<%=HiddenFieldDivision.ClientID%>").value;
                objInpC.job = document.getElementById("<%=HiddenFieldJob.ClientID%>").value;
                objInpC.desg = document.getElementById("<%=HiddenFieldDesg.ClientID%>").value;
                objInpC.emp = document.getElementById("<%=HiddenFieldEmployee.ClientID%>").value;
                objInpC.Addtn = document.getElementById("<%=HiddenFieldAddition.ClientID%>").value;
                objInpC.Dedtn = document.getElementById("<%=HiddenFieldDeduction.ClientID%>").value;
                objInpC.catgry = document.getElementById("<%=HiddenFieldCategory.ClientID%>").value;
                objInpC.method = document.getElementById("<%=HiddenFieldMethod.ClientID%>").value;
                if (Mnth != "") {
                    objInpC.month = Mnth;
                }
                objInpC.source = source;
                objInpC.ShowDep = 1;
                objInpC.ShowDiv = 1;
                objInpC.ShowCat = 1;
                objInpC.ShowJob = 1;
                if (Mode == 1) {
                    objInpC.BAids = PayrlId;
                    objInpC.BDids = "0";
                    objInpC.MAids = "0";
                    objInpC.MDids = "0";
                }
                else if (Mode == 2) {
                    objInpC.BAids = "0";
                    objInpC.BDids = PayrlId;
                    objInpC.MAids = "0";
                    objInpC.MDids = "0";
                }
                else if (Mode == 3) {
                    objInpC.BAids = "0";
                    objInpC.BDids = "0";
                    objInpC.MAids = PayrlId;
                    objInpC.MDids = "0";
                }
                else if (Mode == 4) {
                    objInpC.BAids = "0";
                    objInpC.BDids = "0";
                    objInpC.MAids = "0";
                    objInpC.MDids = PayrlId;
                }
                else if (Mode == 5) {
                    objInpC.BAids = "ALL";
                    objInpC.BDids = "0";
                    objInpC.MAids = "ALL";
                    objInpC.MDids = "0";
                }
                else if (Mode == 6) {
                    objInpC.BAids = "0";
                    objInpC.BDids = "ALL";
                    objInpC.MAids = "0";
                    objInpC.MDids = "ALL";
                }
                else {
                    objInpC.BAids = "ALL";
                    objInpC.BDids = "ALL";
                    objInpC.MAids = "ALL";
                    objInpC.MDids = "ALL";
                }
                objInpC.Mode = Mode;
                if (source != 0) {
                    var BAids = "0", BDids = "0", MAids = "0", MDids = "0";
                    if (Mode == 1 || Mode == 5 || Mode == "") {
                        $("#lev2MBA input[type=checkbox]:checked").each(function () {
                            if ($(this).val() != "on") {
                                if (BAids == "") {
                                    BAids = $(this).val();
                                }
                                else {
                                    BAids += "," + $(this).val();
                                }
                            }
                        });
                    }
                    if (Mode == 2 || Mode == 6 || Mode == "") {
                        $("#lev2MBD input[type=checkbox]:checked").each(function () {
                            if ($(this).val() != "on") {
                                if (BDids == "") {
                                    BDids = $(this).val();
                                }
                                else {
                                    BDids += "," + $(this).val();
                                }
                            }
                        });
                    }
                    if (Mode == 3 || Mode == 5 || Mode == "") {
                        $("#lev2MMA input[type=checkbox]:checked").each(function () {
                            if ($(this).val() != "on") {
                                if (MAids == "") {
                                    MAids = $(this).val();
                                }
                                else {
                                    MAids += "," + $(this).val();
                                }
                            }
                        });
                    }
                    if (Mode == 4 || Mode == 6 || Mode == "") {
                        $("#lev2MMD input[type=checkbox]:checked").each(function () {
                            if ($(this).val() != "on") {
                                if (MDids == "") {
                                    MDids = $(this).val();
                                }
                                else {
                                    MDids += "," + $(this).val();
                                }
                            }
                        });
                    }
                    objInpC.BAids = BAids;
                    objInpC.BDids = BDids;
                    objInpC.MAids = MAids;
                    objInpC.MDids = MDids;
                    if (document.getElementById("cbx2M2Lev0").checked == false) {
                        objInpC.ShowDep = 0;
                    }
                    if (document.getElementById("cbx2M2Lev1").checked == false) {
                        objInpC.ShowDiv = 0;
                    }
                    if (document.getElementById("cbx2M2Lev2").checked == false) {
                        objInpC.ShowCat = 0;
                    }
                    if (document.getElementById("cbx2M2Lev3").checked == false) {
                        objInpC.ShowJob = 0;
                    }
                }
                objInpC.Dcm = document.getElementById("<%=HiddenFieldDecCnt.ClientID%>").value;
                objInpC.Crn = document.getElementById("<%=HiddenFieldCrncyId.ClientID%>").value;
                if (objInpC.orgID != null && objInpC.orgID != "" && objInpC.orgID != "null" && objInpC.corpId != null && objInpC.corpId != "" && objInpC.corpId != "null") {
                    $.ajax({
                        async: false,
                        type: "POST",
                        url: "hcm_Employee_Addtn_Dedtn_Report.aspx/ShowLevel2M2",
                        data: JSON.stringify(objInpC),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            document.getElementById("tabLev2M2").innerHTML = data.d[0];
                            if (source == 0) {
                                document.getElementById("liColLevel2M2").innerHTML = data.d[1];

                                $(function () {

                                    $(".cls_adM2, .fg13_M2").click(function () {
                                        $(".ddwn_ad3").hide(200);
                                        var Mnth = document.getElementById("<%=HiddenFieldLev2Month.ClientID%>").value;
                                         var Mode = document.getElementById("<%=HiddenFieldLev2Mode.ClientID%>").value;
                                         var PayrlId = document.getElementById("<%=HiddenFieldLev2Amnt.ClientID%>").value;
                                         var ChangeSts = document.getElementById("<%=HiddenFieldGrpChanged.ClientID%>").value;
                                         if (ChangeSts == "1")
                                             ShowLevel2M2(Mnth, PayrlId, Mode, 1, 1);
                                     });

                                    $('.button-checkbox').each(function () {
                                        // Settings
                                        var $widget = $(this),
                                            $button = $widget.find('button'),
                                            $checkbox = $widget.find('input:checkbox'),
                                            color = $button.data('color'),
                                            settings = {
                                                on: {
                                                    icon: 'glyphicon glyphicon-check'
                                                },
                                                off: {
                                                    icon: 'glyphicon glyphicon-unchecked gly2'
                                                }
                                            };

                                        // Event Handlers
                                        $button.on('click', function () {
                                            $checkbox.prop('checked', !$checkbox.is(':checked'));
                                            $checkbox.triggerHandler('change');
                                            updateDisplay();
                                        });
                                        $checkbox.on('change', function () {
                                            updateDisplay();
                                        });

                                        // Actions
                                        function updateDisplay() {
                                            var isChecked = $checkbox.is(':checked');

                                            // Set the button's state
                                            $button.data('state', (isChecked) ? "on" : "off");

                                            // Set the button's icon
                                            $button.find('.state-icon')
                                                .removeClass()
                                                .addClass('state-icon ' + settings[$button.data('state')].icon);

                                            // Update the button's color
                                            if (isChecked) {
                                                $button
                                                .removeClass('btn-d')
                                                .addClass('btn-' + color + ' active');
                                            }
                                            else {
                                                $button
                                                .removeClass('btn-' + color)
                                                .addClass('btn-d' + ' active');
                                            }
                                        }

                                        // Initialization
                                        function init() {

                                            updateDisplay();

                                            // Inject the icon if applicable
                                            if ($button.find('.state-icon').length == 0) {
                                                $button.prepend('<i class="state-icon ' + settings[$button.data('state')].icon + '"></i> ');
                                            }
                                        }
                                        init();
                                    });
                                });
                            }
                        }
                    });
                }
            }
            return false;
        }
        function ClickCbxColLevel2M2(id) {
            if (id != "") {
                if (document.getElementById("lev2Mcbx" + id).checked == true) {
                    $('#lev2M' + id + ' input[type=checkbox]:checked').click();
                }
                else {
                    $('#lev2M' + id + ' input[type=checkbox]:not(:checked)').click();
                }
                document.getElementById("lev2Mcbx" + id).click();
            }
            document.getElementById("<%=HiddenFieldGrpChanged.ClientID%>").value = "1";
            return false;
        }
        function ClickCbxColLevel3(id) {
            if (id != "") {
                if (document.getElementById("lev3cbx" + id).checked == true) {
                    $('#lev3'+id+' input[type=checkbox]:checked').click();                    
                }
                else {
                    $('#lev3' + id + ' input[type=checkbox]:not(:checked)').click();
                }
                document.getElementById("lev3cbx" + id).click();
            }    
            document.getElementById("<%=HiddenFieldCbxChangeLev3.ClientID%>").value = "1";
            return false;
        }

        var objInpD = {};
        function ShowSummaryLevel3(Dept, Divs, Ctgry, Mnths, mode, source) {

            document.getElementById("<%=HiddenFieldLev3Dept.ClientID%>").value = Dept;
            document.getElementById("<%=HiddenFieldLev3Divs.ClientID%>").value = Divs;
            document.getElementById("<%=HiddenFieldLev3Ctgry.ClientID%>").value = Ctgry;
            document.getElementById("<%=HiddenFieldLev3Mnths.ClientID%>").value = Mnths;
            document.getElementById("<%=HiddenFieldLev3mode.ClientID%>").value = mode;

            objInpD = {};
            document.getElementById("tabLevel3").innerHTML = "";
            document.getElementById("<%=HiddenFieldCbxChangeLev3.ClientID%>").value = "0";
            $("#tabLevel3 th").show();
            $("#liColLevel3 li").show();
            var Level = 0;
               if (document.getElementById("Radio35").checked == true) {
                    Level = 1;
                }
               else if (document.getElementById("Radio36").checked == true) {
                    Level = 2;
                }
               else if (document.getElementById("Radio37").checked == true) {
                    Level = 3;
                }
               else if (document.getElementById("Radio38").checked == true) {
                   Level = 4;
               }

               objInpD.orgID = '<%= Session["ORGID"] %>';
            objInpD.corpId = '<%= Session["CORPOFFICEID"] %>';
            objInpD.year = document.getElementById("<%=HiddenFieldYear.ClientID%>").value;
            objInpD.month = document.getElementById("<%=HiddenFieldMonths.ClientID%>").value;
            objInpD.dept = document.getElementById("<%=HiddenFieldDept.ClientID%>").value;
            objInpD.divsn = document.getElementById("<%=HiddenFieldDivision.ClientID%>").value;
            objInpD.job = document.getElementById("<%=HiddenFieldJob.ClientID%>").value;
            objInpD.desg = document.getElementById("<%=HiddenFieldDesg.ClientID%>").value;
            objInpD.emp = document.getElementById("<%=HiddenFieldEmployee.ClientID%>").value;
            objInpD.Addtn = document.getElementById("<%=HiddenFieldAddition.ClientID%>").value;
            objInpD.Dedtn = document.getElementById("<%=HiddenFieldDeduction.ClientID%>").value;
            objInpD.catgry = document.getElementById("<%=HiddenFieldCategory.ClientID%>").value;
            objInpD.method = document.getElementById("<%=HiddenFieldMethod.ClientID%>").value;
            if (Dept != "") {
                objInpD.dept = Dept;
               }
            if (Divs != "") {
                objInpD.divsn = Divs;
               }
            if (Ctgry != "") {
                objInpD.catgry = Ctgry;
               }
            if (Mnths != "") {
                objInpD.month = Mnths;
               }
            objInpD.Level = Level;
            objInpD.source = source;
            objInpD.ShowEmpCode = 1;
            objInpD.ShowEmpName = 1;
            objInpD.ShowDept = 1;
            objInpD.ShowDesg = 1;
            objInpD.ShowJob = 1;
            objInpD.BAids = "";
            objInpD.BDids = "";
            objInpD.MAids = "";
            objInpD.MDids = "";
            if (source != 0) {

                var BAids = "", BDids = "", MAids = "", MDids = "";


                $("#lev3BA input[type=checkbox]:checked").each(function () {
                    if ($(this).val() != "on") {
                        if (BAids == "") {
                            BAids = $(this).val();
                        }
                        else {
                            BAids += "," + $(this).val();
                        }
                    }
                });
                $("#lev3BD input[type=checkbox]:checked").each(function () {
                    if ($(this).val() != "on") {
                        if (BDids == "") {
                            BDids = $(this).val();
                        }
                        else {
                            BDids += "," + $(this).val();
                        }
                    }
                });
                $("#lev3MA input[type=checkbox]:checked").each(function () {
                    if ($(this).val() != "on") {
                        if (MAids == "") {
                            MAids = $(this).val();
                        }
                        else {
                            MAids += "," + $(this).val();
                        }
                    }
                });
                $("#lev3MD input[type=checkbox]:checked").each(function () {
                    if ($(this).val() != "on") {
                        if (MDids == "") {
                            MDids = $(this).val();
                        }
                        else {
                            MDids += "," + $(this).val();
                        }
                    }
                });

                objInpD.BAids = BAids;
                objInpD.BDids = BDids;
                objInpD.MAids = MAids;
                objInpD.MDids = MDids;

                if (document.getElementById("cbx3Lev0").checked == false) {
                    objInpD.ShowEmpCode = 0;
                }
                if (document.getElementById("cbx3Lev1").checked == false) {
                    objInpD.ShowEmpName = 0;
                }
                if (document.getElementById("cbx3Lev2").checked == false) {
                    objInpD.ShowDept = 0;
                }
                if (document.getElementById("cbx3Lev3").checked == false) {
                    objInpD.ShowDesg = 0;
                }
                if (document.getElementById("cbx3Lev4").checked == false) {
                    objInpD.ShowJob = 0;
                }
            }
            objInpD.Dcm = document.getElementById("<%=HiddenFieldDecCnt.ClientID%>").value;
            objInpD.Crn = document.getElementById("<%=HiddenFieldCrncyId.ClientID%>").value;
            if (objInpD.orgID != null && objInpD.orgID != "" && objInpD.orgID != "null" && objInpD.corpId != null && objInpD.corpId != "" && objInpD.corpId != "null") {
                $.ajax({
                    async: false,
                    type: "POST",
                    url: "hcm_Employee_Addtn_Dedtn_Report.aspx/ShowLevel3",
                    data: JSON.stringify(objInpD),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $(".details_cls").show(100);
                        document.getElementById("tabLevel3").innerHTML = data.d[0];
                        if (source == 0) {
                            document.getElementById("liColLevel3").innerHTML = data.d[1];

                            $(function () {

                                $(".cls_ad2, .fg13_n").click(function () {
                                    $(".ddwn_ad2").hide(200);
                                     var Dept = document.getElementById("<%=HiddenFieldLev3Dept.ClientID%>").value;
                                     var Divs = document.getElementById("<%=HiddenFieldLev3Divs.ClientID%>").value;
                                     var Ctgry = document.getElementById("<%=HiddenFieldLev3Ctgry.ClientID%>").value;
                                     var Mnths = document.getElementById("<%=HiddenFieldLev3Mnths.ClientID%>").value;
                                     var mode = document.getElementById("<%=HiddenFieldLev3mode.ClientID%>").value;
                                     var ChangeSts = document.getElementById("<%=HiddenFieldCbxChangeLev3.ClientID%>").value;
                                     if (ChangeSts == "1")
                                         ShowSummaryLevel3(Dept, Divs, Ctgry, Mnths, mode, 1);
                                 });

                                $('.button-checkbox').each(function () {
                                    // Settings
                                    var $widget = $(this),
                                        $button = $widget.find('button'),
                                        $checkbox = $widget.find('input:checkbox'),
                                        color = $button.data('color'),
                                        settings = {
                                            on: {
                                                icon: 'glyphicon glyphicon-check'
                                            },
                                            off: {
                                                icon: 'glyphicon glyphicon-unchecked gly2'
                                            }
                                        };

                                    // Event Handlers
                                    $button.on('click', function () {
                                        $checkbox.prop('checked', !$checkbox.is(':checked'));
                                        $checkbox.triggerHandler('change');
                                        updateDisplay();
                                    });
                                    $checkbox.on('change', function () {
                                        updateDisplay();
                                    });

                                    // Actions
                                    function updateDisplay() {
                                        var isChecked = $checkbox.is(':checked');

                                        // Set the button's state
                                        $button.data('state', (isChecked) ? "on" : "off");

                                        // Set the button's icon
                                        $button.find('.state-icon')
                                            .removeClass()
                                            .addClass('state-icon ' + settings[$button.data('state')].icon);

                                        // Update the button's color
                                        if (isChecked) {
                                            $button
                                            .removeClass('btn-d')
                                            .addClass('btn-' + color + ' active');
                                        }
                                        else {
                                            $button
                                            .removeClass('btn-' + color)
                                            .addClass('btn-d' + ' active');
                                        }
                                    }

                                    // Initialization
                                    function init() {

                                        updateDisplay();

                                        // Inject the icon if applicable
                                        if ($button.find('.state-icon').length == 0) {
                                            $button.prepend('<i class="state-icon ' + settings[$button.data('state')].icon + '"></i> ');
                                        }
                                    }
                                    init();
                                });
                            });
                        }
                    }
                });
            }
            return false;
        }

        function PrintSummary() {

            if (document.getElementById("<%=HiddenFieldMethod.ClientID%>").value == "1") {
                if (document.getElementById("divLev2M1").style.display == "") {
                    $.ajax({
                        async: false,
                        type: "POST",
                        url: "hcm_Employee_Addtn_Dedtn_Report.aspx/PrintSummaryM1Lev2",
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
                else if (document.getElementById("<%=HiddenFieldNodataSts.ClientID%>").value != "1") {
                    var objInpSea = {};
                    objInpSea.orgID = '<%=Session["ORGID"]%>';;
                    objInpSea.corpId = '<%=Session["CORPOFFICEID"]%>';
                    objInpSea.year = document.getElementById("<%=HiddenFieldYear.ClientID%>").value;
                    objInpSea.month = document.getElementById("<%=HiddenFieldMonths.ClientID%>").value;
                    objInpSea.dept = document.getElementById("<%=HiddenFieldDept.ClientID%>").value;
                    objInpSea.divsn = document.getElementById("<%=HiddenFieldDivision.ClientID%>").value;
                    objInpSea.job = document.getElementById("<%=HiddenFieldJob.ClientID%>").value;
                    objInpSea.desg = document.getElementById("<%=HiddenFieldDesg.ClientID%>").value;
                    objInpSea.emp = document.getElementById("<%=HiddenFieldEmployee.ClientID%>").value;
                    objInpSea.Addtn = document.getElementById("<%=HiddenFieldAddition.ClientID%>").value;
                    objInpSea.Dedtn = document.getElementById("<%=HiddenFieldDeduction.ClientID%>").value;
                    objInpSea.catgry = document.getElementById("<%=HiddenFieldCategory.ClientID%>").value;
                    objInpSea.Dcm = document.getElementById("<%=HiddenFieldDecCnt.ClientID%>").value;
                    objInpSea.Crn = document.getElementById("<%=HiddenFieldCrncyId.ClientID%>").value;
                    objInpSea.Method = 1;
                    $.ajax({
                        async: false,
                        type: "POST",
                        url: "hcm_Employee_Addtn_Dedtn_Report.aspx/PrintSummaryM1",
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
            }
            else {
                if (document.getElementById("divLev2M2").style.display == "") {                   
                    $.ajax({
                        async: false,
                        type: "POST",
                        url: "hcm_Employee_Addtn_Dedtn_Report.aspx/PrintSummaryM2Lev2",
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
                else if (document.getElementById("<%=HiddenFieldNodataSts.ClientID%>").value != "1") {                  
                    var objInpSea = {};
                    objInpSea.orgID = '<%=Session["ORGID"]%>';;
                    objInpSea.corpId = '<%=Session["CORPOFFICEID"]%>';
                    objInpSea.year = document.getElementById("<%=HiddenFieldYear.ClientID%>").value;
                    objInpSea.month = document.getElementById("<%=HiddenFieldMonths.ClientID%>").value;
                    objInpSea.dept = document.getElementById("<%=HiddenFieldDept.ClientID%>").value;
                    objInpSea.divsn = document.getElementById("<%=HiddenFieldDivision.ClientID%>").value;
                    objInpSea.job = document.getElementById("<%=HiddenFieldJob.ClientID%>").value;
                    objInpSea.desg = document.getElementById("<%=HiddenFieldDesg.ClientID%>").value;
                    objInpSea.emp = document.getElementById("<%=HiddenFieldEmployee.ClientID%>").value;
                    objInpSea.Addtn = document.getElementById("<%=HiddenFieldAddition.ClientID%>").value;
                    objInpSea.Dedtn = document.getElementById("<%=HiddenFieldDeduction.ClientID%>").value;
                    objInpSea.catgry = document.getElementById("<%=HiddenFieldCategory.ClientID%>").value;
                    objInpSea.Dcm = document.getElementById("<%=HiddenFieldDecCnt.ClientID%>").value;
                    objInpSea.Crn = document.getElementById("<%=HiddenFieldCrncyId.ClientID%>").value;
                    objInpSea.Method = 2;
                    $.ajax({
                        async: false,
                        type: "POST",
                        url: "hcm_Employee_Addtn_Dedtn_Report.aspx/PrintSummaryM1",
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

            }
    return false;
}
        function PrintDetail() {
            if (document.getElementById("details_cls").style.display == "") {
                $.ajax({
                    async: false,
                    type: "POST",
                    url: "hcm_Employee_Addtn_Dedtn_Report.aspx/PrinLev3",
                    data: JSON.stringify(objInpD),
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

    </script>
    <style>
        .fg13_M2 {
    width: 98%;
    margin: auto;
    float: left;
}
         .cls_adM2 {
    background-color: transparent;
    border: none;
    color: #d66363;
}
    </style>
</asp:Content>

