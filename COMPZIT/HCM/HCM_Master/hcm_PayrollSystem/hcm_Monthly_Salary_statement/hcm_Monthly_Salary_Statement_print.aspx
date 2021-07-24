<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="hcm_Monthly_Salary_Statement_print.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_statement_hcm_Monthly_Salary_Statement_print" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/js/Common/Common.js"></script>
 <link rel="stylesheet" type="text/css" href="/css/New css/hcm_ns.css"/>
 <style>
 .table-bordered>tbody>tr>td, .table-bordered>tbody>tr>th, .table-bordered>tfoot>tr>td, .table-bordered>tfoot>tr>th, .table-bordered>thead>tr>td, .table-bordered>thead>tr>th{padding:3px!important;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:HiddenField ID="HiddenFieldIndividualRound" runat="server" />
     <asp:HiddenField ID="HiddenFieldShowAdd" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldShowDed" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldNOTrate" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldHOTrate" runat="server" Value="0" />
    <asp:HiddenField ID="Hiddenddlpay" runat="server" Value="2"/>
        
<%--    0041--%>

    <asp:HiddenField ID="HiddenFieldSalaryProcess" runat="server" />

    <asp:HiddenField ID="hiddenDate" runat="server" />

    <asp:HiddenField ID="HiddenPaymentMode" runat="server" />


    <a href="hcm_Monthly_Salary_Statement.aspx" type="button" class="list_b" title="Back to List" id="list_b" runat="server">
       
 <i class="fa fa-arrow-circle-left"></i>
</a>



    <a href="#" type="button" onmouseover="opensave()" class="sta_but" title="Statements" id="sta_print" runat="server" >
  <i class="fa fa-list-alt"></i>
</a>
    <%--//end--%>

    

<div class="mySave1 ope_stat" id="mySave">
  <a href="#cphMain_divMSP" id="linkMSP" runat="server">
    <span class="btn bg2_btn clr_w fnt_sz" >Monthly Salary Statement</span>
  </a>
  <a href="#cphMain_divLSP" id="linkLSP" runat="server">
    <span class="btn bg2_btn clr_w fnt_sz" >Leave Settlement</span>
  </a>
  <a href="#cphMain_divESP" id="linkESP" runat="server">
    <span class="btn bg2_btn clr_w fnt_sz">End of Service Settlement</span>
  </a>
  <a href="#summary_1">
    <span class="btn bg2_btn clr_w fnt_sz">Summary</span>
  </a>
</div>

    <!---breadcrumb_section_started---->    
    <ol class="breadcrumb">
     <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Hcm.aspx">HCM</a></li>
      <li class="active">Monthly Salary Statement</li>
    </ol>
<!---breadcrumb_section_started----> 
    <a href="javascript:;" type="button" class="print_o" title="Print page" onclick="PrintClick();" runat="server" id="print_button" >
  <i class="fa fa-print"></i>
</a>
    <div class="content_sec2 cont_contr" onmouseover="closesave();">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con">Monthly Salary Statement</h1>

          <div class="form-group fg2 fg2_mr sa_fg1">
            <label for="email" class="fg2_la1 pad_l">Show primary Allowances:<span class="spn1"></span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                  <input type="checkbox" id="cbxAdd" runat="server"/>
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>

           <div class="form-group fg2 fg2_mr sa_fg1">
            <label for="email" class="fg2_la1 pad_l">Show primary Deductions:<span class="spn1"></span></label>
            <div class="check1">
              <div class="">
                <label class="switch">
                  <input type="checkbox" id="cbxDed" runat="server"/>
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>
          <%--  0041--%>

            <div class="fg2">
            <label for="email" class="fg2_la1" runat="server" id="labelpaymode">Payment Mode:<span class="spn1"></span></label>
                <asp:DropDownList ID="ddlpaymentmode" runat="server" class="form-control fg2_inp1 fg_chs2">

                    <asp:ListItem Value="2">Both</asp:ListItem>
                    <asp:ListItem Value="0">Bank</asp:ListItem>
                    <asp:ListItem Value="1">Cash</asp:ListItem>
                   
                </asp:DropDownList>
          </div>
          <%--  end--%>
        <div class="fg8 fg2_blk">
          <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
             <asp:Button ID="btnSearch" runat="server" class="submit_ser" OnClick="btnSearch_Click" />
             <asp:Button ID="btnPrint" runat="server" class="submit_ser" OnClick="btnPrint_Click" style="display:none;"/>
        <%--  <button class="submit_ser"></button>--%>
          <!-- <button class="btn tab_but1 butn5"><i class="fa fa-search"></i> Search</button>   -->
        </div>
<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="free_sp"></div>
      <div class="devider"></div>
<!---=================section_devider============--->
            <%--//0041--%>
             <div class="no_dta" id="nodata" runat="server" visible="false">
          <div class="n_dt1">
            <i class="fa fa-search"></i>
            <h3>No data available in table</h3>
          </div>
        </div>
          <%--  end--%>

      <h3 class="mar_bo1"><span class="pull-right" id="headMnthYear" runat="server"></span></h3>
        
        <div class="tab_res">
          <div class="col-md-12" style="visibility:hidden;">
            <p><span class="tbl_srt1">Showing </span> 
              <select class="form-control tbl_srt">
                <option>10</option>
                <option>25</option>
                <option>50</option>
                <option>100</option>
              </select> Entries
            </p>
          </div><!-- 
          <div class="col-md-2 pull-right tb_ser_hcm">
            <input type="text" class="form-control tbl_ser_n" placeholder="Search Items">
          </div> -->

          <div class="r_fl" id="divMSP" runat="server">       
          </div>
          <div class="r_fl" id="divLSP" runat="server">      
          </div>
          <div class="r_fl" id="divESP" runat="server">       
          </div>

        <div class="clearfix"></div><!-- 
        <div class="free_sp"></div> -->
        <div class="devider"></div>

        <div id="summary_1"></div>

                <%--     //0041--%>
        <h3 class="mar_bo1 flt_l" id="Statmnt_Sumry" runat="server">Statement Summary</h3>
       <%--     //end--%>
        <div class="r_800 mar_bo1" id="divEmpCnt" runat="server">            
        </div>
   
        <div class="r_800 mar_bo1" id="divSalary" runat="server">         
        </div>
        <div class="r_800 mar_bo1" id="divNetSummary" runat="server">           
        </div>
      </div>


<!---inner_content_sections area_closed--->

<!---frame_border_area_closed---->
        </div>
      </div>
    </div>
    <script>
        function PrintClick() {
            document.getElementById("cphMain_btnPrint").click();
        }
    </script>
    <!--save_pop up_open-->
<script>
    function opensave() {
        document.getElementById("mySave").style.width = "200px";
    }
    function closesave() {
        document.getElementById("mySave").style.width = "0px";
    }
    $(document).ready(function () {
        $('.bg2_btn').bind('click', function () {
            // remove the active class from all elements with active class
            $('.active').removeClass('active')
            // add active class to clicked element
            $(this).addClass('active');
        });
        $('#mySave span:first').addClass("active");
    });
</script>
<!--save_pop up_closed-->





</asp:Content>

