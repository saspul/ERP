<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="app_settings.aspx.cs" Inherits="App_setting_app_settings" %>

<%-- START EVM040--%>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

 <!--------css_Included------->

    <link href="/css/New%20css/hcm_ns.css" rel="stylesheet" />
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>

<!--------css_Included_closed------->
    <style>
        .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
            padding: 3px!important;
        }
    </style>


<script>
    function SuccessUpdate() {
        var ret = false;
        $("#success-alert").html("Appsettings updated successfully.");
        $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        });
        return false;
    }
</script>


</asp:Content>

  
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:HiddenField ID="hiddenDefaultCurrencyId" runat="server" />


    <div class="myAlert-top alert alert-success" id="success-alert">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Success!</strong> Changes completed succesfully
    </div>

    <ol class="breadcrumb">
        <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">Home</a></li>
        <li class="active">Application Settings</li>
      </ol>
       
      <div class="content_sec2 cont_contr" onmouseover="closesave()">
        <div class="content_area_container cont_contr">

          <div class="content_box1 cont_contr">
            <h2>Application Settings</h2>

            <div class="tab_stf">
              <button class="tablinks" onclick="return open_box_St(event, 'dtl_human')" id="defaultOpen">
                
                <i class="ft_ico">
                    <img src="/Images/New%20Images/images/ft_ico4.png" /></i><span>HCM</span>
              </button>
              <button class="tablinks" onclick="return open_box_St(event, 'dtl_finance')">
                
                <i class="ft_ico">
                    <img src="/Images/New%20Images/images/ft_ico.png" /></i><span>FMS</span>
              </button>
                 <button class="tablinks" onclick="return open_box_St(event, 'dtl_general')" >
                
                <i class="ft_ico">
                    <img src="/Images/New%20Images/images/ft_ico4.png" /></i><span>GENERAL</span>
              </button>
              
             
            </div>

        
               <!-----Human section_started---->

            <div id="dtl_human" class="tabcontent_stf emply_ad_1" >
              <h1>Human Capital Management</h1>

                <div class="accordion-container">
                <button class="accordion_role sli_1" onclick="return false;"> Leave Settlement & Attendance </button>
                <div class="panel_role">
                  <div class="box_pro_2 pro_pa wi_tre">
                    <div class="tree well wi_tre_1">
                      <div class="fg12">
                        <h3>Allow holiday in leave start date </h3>
                       <div class="fg4 sa_2 sa_640_i sa_480">
                         
                  <label for="email" class="fg2_la1 pad_l"><span class="spn1"></span></label>
                  <div class="check1">
                   <div class="">
                    <label class="switch">
                   <input type="checkbox"  id="Checkboxholidaystart"  onkeypress="return DisableEnter(event)"  runat="server"  />
                    <span class="slider_tog round"></span>
                  </label>
                 </div>
                </div>
                 </div>

                      </div>
                          
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                         <div class="fg12">
                        <h3>Allow holiday in leave end date</h3>
                       <div class="fg4 sa_2 sa_640_i sa_480">
                         
                  <label for="email" class="fg2_la1 pad_l"><span class="spn1"></span></label>
                  <div class="check1">
                   <div class="">
                    <label class="switch">
                   <input type="checkbox"  id="Checkboxholidayend"  onkeypress="return DisableEnter(event)" runat="server" />
                    <span class="slider_tog round"></span>
                  </label>
                 </div>
                </div>
                 </div>
                      </div>
                        <div class="clearfix"></div>
                      <div class="free_sp"></div>
                   
                  
                    <div class="fg12">
                        <h3>Allow offday in leave start date</h3>
                       <div class="fg4 sa_2 sa_640_i sa_480">
                         
                  <label for="email" class="fg2_la1 pad_l"><span class="spn1"></span></label>
                  <div class="check1">
                   <div class="">
                    <label class="switch">
                   <input type="checkbox"  id="Checkboxoffdaystart"  onkeypress="return DisableEnter(event)" runat="server" />
                    <span class="slider_tog round"></span>
                  </label>
                 </div>
                </div>
                 </div>
                      </div>
                        
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                          <div class="fg12">
                        <h3>Allow offfay in leave end date </h3>
                       <div class="fg4 sa_2 sa_640_i sa_480">
                         
                  <label for="email" class="fg2_la1 pad_l"><span class="spn1"></span></label>
                  <div class="check1">
                   <div class="">
                    <label class="switch">
                   <input type="checkbox"  id="Checkboxoffdayend"  onkeypress="return DisableEnter(event)"  runat="server"/>
                    <span class="slider_tog round"></span>
                  </label>
                 </div>
                </div>
                 </div>
                      </div>
                        
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                         <div class="fg12">
                      <h3>Calculation of Off-Duty</h3>
                      <div class="fg4 sa_2 sa_640_i sa_480">
                          </div>
                             <div class="form-group fg2 fg2_blk">
                       
                      <asp:DropDownList ID="leaveddl1" class="form-control fg2_inp1 fg_chs2"  onkeypress="return DisableEnter(event)" runat="server">
                          
                      <asp:ListItem Text="Based on first Day" Value="0" Selected="True"></asp:ListItem>
                      <asp:ListItem Text="All days" Value="1" ></asp:ListItem>
                          <asp:ListItem Text="Need not consider" Value="2" ></asp:ListItem>

                      </asp:DropDownList>
                      </div> 
                            </div>  
                        
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                        <div class="fg12">
                        <h3>No. of days upto which leave settlement is eligible</h3>
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txteligibledays" runat="server" class="form-control fg2_inp1 inp_mst"  onkeypress="return isNumber(event)" placeholder="No. of days"/>
                          
                        </div>
                      
                      </div>
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                        <div class="fg12">
                        <h3>How many days in future need to be in attendace sheet</h3>
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtfuturedays" runat="server" class="form-control fg2_inp1 inp_mst"  onkeypress="return isNumber(event)" placeholder="No. of days"/>
                        </div>
                      
                      </div>
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                        <div class="fg12">
                        <h3>No. of days before employee need to be in leave settlement</h3>
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtleavesettlementdays" runat="server"  onkeypress="return isNumber(event)"  class="form-control fg2_inp1 inp_mst" placeholder="No. of days"/>
                        </div>
                      
                      </div>
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>

                    </div>
                  </div>
                
                  
                </div>

                <button class="accordion_role sli_1" onclick="return false;">Payroll</button>
                <div class="panel_role">
                  <div class="box_pro_2 pro_pa wi_tre">
                    <div class="tree well wi_tre_1">
                       <div class="fg12">
                      <h3>Basic Pay</h3>
                      <div class="fg4 sa_2 sa_640_i sa_480">
                          </div>
                             <div class="form-group fg2 fg2_blk">
                       
                      <asp:DropDownList ID="payrollddl1" class="form-control fg2_inp1 fg_chs2"  onkeypress="return DisableEnter(event)" runat="server">
                           
                      <asp:ListItem Text="Fixed" Value="0" Selected="True"></asp:ListItem>
                      <asp:ListItem Text="Variable" Value="1" ></asp:ListItem>

                      </asp:DropDownList>
                      </div> 
                            </div>  
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                         <div class="fg12">
                        <h3>Individual round of Payroll</h3>
                       <div class="fg4 sa_2 sa_640_i sa_480">
                         
                  <label for="email" class="fg2_la1 pad_l"><span class="spn1"></span></label>
                  <div class="check1">
                   <div class="">
                    <label class="switch">
                   <input type="checkbox" id="individualround" runat="server" />
                    <span class="slider_tog round"></span>
                  </label>
                 </div>
                </div>
                 </div>
                      </div>
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                                       
                          <div class="fg12">
                        <h3>Salary processing date</h3>
                        <div class="fg2 sa_2 sa_640_i sa_480 ma_bo10">
                          <div id="payrolldatepicker1" class="input-group date" data-date-format="dd-mm-yyyy" >
                            <input class="form-control inp_bdr" type="text" id="txtsalarydate" runat="server"  />
                            <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                          </div>
                        </div>
                      </div>
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                          <div class="fg12">
                        <h3>Gratuity start date</h3>
                        <div class="fg2 sa_2 sa_640_i sa_480 ma_bo10">
                          <div id="payrolldatepicker2" class="input-group date" data-date-format="dd-mm-yyyy">
                            <input class="form-control inp_bdr" type="text" id="txtgratuitydate" runat="server"  />
                            <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                          </div>
                        </div>
                      </div>
                         <div class="clearfix"></div>
                      <div class="free_sp"></div>
                         <div class="fg12">
                        <h3>Eligible days for gratuity</h3>
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtgratuitydays" runat="server" class="form-control fg2_inp1 inp_mst" onkeypress="return isNumber(event)"  placeholder="No. of days"/>
                        </div>
                      
                      </div>
                        <div class="clearfix"></div>
                      <div class="free_sp"></div>

                        <div class="fg12">
                      <h3>Addition/deduction calculation while salary processing based on working days  </h3>
                      <div class="fg4 sa_2 sa_640_i sa_480">
                          </div>
                             <div class="form-group fg2 fg2_blk">
                       
                      <asp:DropDownList ID="payrollddl2" class="form-control fg2_inp1 fg_chs2" onkeypress="return DisableEnter(event)" runat="server">
                           
                      <asp:ListItem Text="Fixed Amount on atleast 1 working day" Value="0" Selected="True"></asp:ListItem>
                      <asp:ListItem Text="Always consider fixed amount" Value="1" ></asp:ListItem>

                      </asp:DropDownList>
                      </div> 
                            </div>  
                              <div class="clearfix"></div>
                      <div class="free_sp"></div>
                             
                      <div class="fg12">
                      <h3>Addition/deduction calculation for joining month </h3>
                      <div class="fg4 sa_2 sa_640_i sa_480">
                          </div>
                             <div class="form-group fg2 fg2_blk">
                       
                      <asp:DropDownList ID="payrollddl3" class="form-control fg2_inp1 fg_chs2" onkeypress="return DisableEnter(event)" runat="server">
                          
                      <asp:ListItem Text="Fixed" Value="0" Selected="True"></asp:ListItem>
                      <asp:ListItem Text="Variable" Value="1" ></asp:ListItem>

                      </asp:DropDownList>
                      </div> 
                            </div>  
                              <div class="clearfix"></div>
                      <div class="free_sp"></div>

                    </div>
                  </div>
                </div>
            
                  <button class="accordion_role sli_1" onclick="return false;">Duty Rejoin</button>
                <div class="panel_role">
                  <div class="box_pro_2 pro_pa wi_tre">
                    <div class="tree well wi_tre_1">
                       <div class="fg12">
                        <h3>Direct Leave confirmation by HR</h3>
                       <div class="fg4 sa_2 sa_640_i sa_480">
                         
                  <label for="email" class="fg2_la1 pad_l"><span class="spn1"></span></label>
                  <div class="check1">
                   <div class="">
                    <label class="switch">
                   <input type="checkbox" id="checkboxhr" onkeypress="return DisableEnter(event)" runat="server"/>
                    <span class="slider_tog round"></span>
                  </label>
                 </div>
                </div>
                 </div>
                      </div>
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                          <div class="fg12">
                        <h3>Joining date limit</h3> 
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtjoininglimit" runat="server" class="form-control fg2_inp1 inp_mst" onkeypress="return isNumber(event)" placeholder="No. of days"/>
                        </div>
                      
                      </div>
                        <div class="clearfix"></div>
                      <div class="free_sp"></div>
                    </div>
                  </div>
                </div>
                   <button class="accordion_role sli_1" onclick="return false;">Employee Section</button>
                <div class="panel_role">
                  <div class="box_pro_2 pro_pa wi_tre">
                    <div class="tree well wi_tre_1">
                       
                          <div class="fg12">
                        <h3>Employee Reference ID format</h3> 
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtreferenceformat" runat="server" class="form-control fg2_inp1 inp_mst" onkeypress="return DisableEnter(event)" placeholder="reference id"/>
                        </div>
                      
                      </div>
                        <div class="clearfix"></div>
                      <div class="free_sp"></div>
                         <div class="fg12">
                      <h3>Edit employee code in Employee Master</h3>
                      <div class="fg4 sa_2 sa_640_i sa_480">
                          </div>
                             <div class="form-group fg2 fg2_blk">
                       
                      <asp:DropDownList ID="ddlempcode" class="form-control fg2_inp1 fg_chs2" runat="server">
                           
                     
                      <asp:ListItem Text="Do not allow" Value="0" Selected="True" ></asp:ListItem>
                           <asp:ListItem Text="Allow" Value="1" ></asp:ListItem>
                           

                      </asp:DropDownList>
                      </div> 
                            </div>  
                        <div class="clearfix"></div>
                      <div class="free_sp"></div>
                    </div>
                  </div>
                </div>
                  <button class="accordion_role sli_1" onclick="return false;">Mails</button>
                <div class="panel_role">
                  <div class="box_pro_2 pro_pa wi_tre">
                    <div class="tree well wi_tre_1">
                       
                          <div class="fg12">
                        <h3>H.R Email</h3> 
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtemailhr" runat="server" class="form-control fg2_inp1 inp_mst"    onkeypress="return DisableEnter(event)" placeholder="user@server.com"/>
  
                            
                          
 
                        </div>
                      
                      </div>
                        <div class="clearfix"></div>
                      <div class="free_sp"></div>
                     
                          <div class="fg12">
                        <h3>No-Reply mail from Corporate Office</h3> 
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtemailnoreply" runat="server" class="form-control fg2_inp1 inp_mst"   onkeypress="return DisableEnter(event)" placeholder="user@server.com"/>
                        </div>
                      
                      </div>
                        <div class="clearfix"></div>
                      <div class="free_sp"></div>
                    </div>
                  </div>
                </div>
                  
                
                  <button class="accordion_role sli_1" onclick="return false;">MESS</button>
                <div class="panel_role">
                  <div class="box_pro_2 pro_pa wi_tre">
                    <div class="tree well wi_tre_1">
                       <div class="fg12">
                        <h3>Food Authority number</h3> 
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtfoodcaption" runat="server" class="form-control fg2_inp1 inp_mst"  onkeypress="return DisableEnter(event)" placeholder="Enter authority number"/>
                        </div>
                      
                      </div>
                        <div class="clearfix"></div>
                      <div class="free_sp"></div>
                          <div class="fg12">
                        <h3>Food Safety Number</h3>
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtsafetynumber" runat="server" class="form-control fg2_inp1 inp_mst"  onkeypress="return DisableEnter(event)" placeholder="Enter food safety number"/>
                        </div>
                      
                      </div>
                        <div class="clearfix"></div>
                      <div class="free_sp"></div>
                    </div>
                  </div>
                </div>
                  <button class="accordion_role sli_1" onclick="return false;">General</button>
                <div class="panel_role">
                  <div class="box_pro_2 pro_pa wi_tre">
                    <div class="tree well wi_tre_1">
                        <div class="fg12">
                      <h3>Tab status on Menu bar</h3>
                      <div class="fg4 sa_2 sa_640_i sa_480">
                          </div>
                             <div class="form-group fg2 fg2_blk">
                       
                      <asp:DropDownList ID="generalddl1" class="form-control fg2_inp1 fg_chs2"  onkeypress="return DisableEnter(event)" runat="server">
                          
                      <asp:ListItem Text="Show both" Value="0" Selected="True"> </asp:ListItem>
                      <asp:ListItem Text="Recently used" Value="1" ></asp:ListItem>
                           <asp:ListItem Text="Frequently used" Value="2" ></asp:ListItem>
                         

                      </asp:DropDownList>
                      </div> 
                            </div>  
                        <div class="clearfix"></div>
                      <div class="free_sp"></div>
                         
                       <div class="fg12">
                        <h3>No. of Frequently used item</h3> 
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtfrequentlyused" runat="server" class="form-control fg2_inp1 inp_mst"  onkeypress="return isNumber(event)" placeholder="No. of items"/>
                        </div>
                      
                      </div>
                        <div class="clearfix"></div>
                      <div class="free_sp"></div>
                         <div class="fg12">
                        <h3>No. of Recently used item</h3> 
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtrecentlyused" runat="server" class="form-control fg2_inp1 inp_mst"  onkeypress="return isNumber(event)" placeholder="No. of items"/>
                        </div>
                      
                      </div>
                        <div class="clearfix"></div>
                      <div class="free_sp"></div>
                    </div>
                  </div>

                </div>
                  
              </div>
              <div class="clearfix"></div>
              <div class="free_sp"></div>

              
            </div>

            <!-----Human section_closed---->

            <!-----Finance section_started---->

            <div id="dtl_finance" class="tabcontent_stf emply_ad_1">
              <h1>Finance Management System</h1>
               
              <div class="modle_detl1 dis_set">
               
                <button class="accordion_role sli_1" onclick="return false;" >Account Code</button>
                <div class="panel_role">
                  <div class="box_pro_2 pro_pa wi_tre">
                    <div class="tree well wi_tre_1">
                      <div class="fg12">
                        <h3>Display all codes</h3>
                       <div class="fg4 sa_2 sa_640_i sa_480">
                         
                  <label for="email" class="fg2_la1 pad_l"><span class="spn1"></span></label>
                  <div class="check1">
                   <div class="">
                    <label class="switch">
                   <input type="checkbox" id="checkboxcode" runat="server" onkeypress="return DisableEnter(event)"  />
                    <span class="slider_tog round"></span>
                  </label>
                 </div>
                </div>
                 </div>
                      </div>
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                         <div class="fg12">
                        <h3>Manual typing of code</h3>
                       <div class="fg4 sa_2 sa_640_i sa_480">
                         
                  <label for="email" class="fg2_la1 pad_l"><span class="spn1"></span></label>
                  <div class="check1">
                   <div class="">
                    <label class="switch">
                   <input type="checkbox" id="checkboxmanualtype" onkeypress="return DisableEnter(event)" runat="server"/>
                    <span class="slider_tog round"></span>
                  </label>
                 </div>
                </div>
                 </div>
                      </div>
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                         <div class="fg12">
                        <h3>Addition of codes as number only</h3>
                       <div class="fg4 sa_2 sa_640_i sa_480">
                         
                  <label for="email" class="fg2_la1 pad_l"><span class="spn1"></span></label>
                  <div class="check1">
                   <div class="">
                    <label class="switch">
                   <input type="checkbox" id="checkboxcodeasnumber" onkeypress="return DisableEnter(event)" runat="server"/>
                    <span class="slider_tog round"></span>
                  </label>
                 </div>
                </div>
                 </div>
                      </div>
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                         
                        
                    </div>
                  </div>
                </div>
                   <button class="accordion_role sli_1" onclick="return false;" >Ledger and Product duplication</button>
                <div class="panel_role">
                  <div class="box_pro_2 pro_pa wi_tre">
                    <div class="tree well wi_tre_1">
                        <div class="fg12">
                        <h3>Allow ledger duplication</h3>
                       <div class="fg4 sa_2 sa_640_i sa_480">
                         
                  <label for="email" class="fg2_la1 pad_l"><span class="spn1"></span></label>
                  <div class="check1">
                   <div class="">
                    <label class="switch">
                   <input type="checkbox" id="checkboxledgerdup" onkeypress="return DisableEnter(event)" runat="server"/>
                    <span class="slider_tog round"></span>
                  </label>
                 </div>
                </div>
                 </div>
                      </div>
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                         <div class="fg12">
                        <h3>Allow Product duplication</h3>
                       <div class="fg4 sa_2 sa_640_i sa_480">
                         
                  <label for="email" class="fg2_la1 pad_l"><span class="spn1"></span></label>
                  <div class="check1">
                   <div class="">
                    <label class="switch">
                   <input type="checkbox" id="checkboxprddup" onkeypress="return DisableEnter(event)" runat="server"/>
                    <span class="slider_tog round"></span>
                  </label>
                 </div>
                </div>
                 </div>
                      </div>
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                      
                    </div>
                  </div>
                </div>
                   <button class="accordion_role sli_1" onclick="return false;" >Sales and Purchase</button>
                <div class="panel_role">
                  <div class="box_pro_2 pro_pa wi_tre">
                    <div class="tree well wi_tre_1">
                       <div class="fg12">
                        <h3>Make Sales and Purchase visible in journal</h3>
                       <div class="fg4 sa_2 sa_640_i sa_480">
                         
                  <label for="email" class="fg2_la1 pad_l"><span class="spn1"></span></label>
                  <div class="check1">
                   <div class="">
                    <label class="switch">
                   <input type="checkbox" id="checkboxjournal" onkeypress="return DisableEnter(event)" runat="server" />
                    <span class="slider_tog round"></span>
                  </label>
                 </div>
                </div>
                 </div>
                      </div>
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                        
                    </div>
                  </div>
                </div>
                   <button class="accordion_role sli_1" onclick="return false;" >Auditing & Account Closing</button>
                <div class="panel_role">
                  <div class="box_pro_2 pro_pa wi_tre">
                    <div class="tree well wi_tre_1">
                       <div class="fg12">
                      <h3>Audit Status </h3>
                      <div class="fg4 sa_2 sa_640_i sa_480">
                          </div>
                             <div class="form-group fg2 fg2_blk">
                       
                      <asp:DropDownList ID="ddlauditstatus" class="form-control fg2_inp1 fg_chs2" onkeypress="return DisableEnter(event)" runat="server">
                           
                      <asp:ListItem Text="Independant" Value="0" Selected="True"></asp:ListItem>
                      <asp:ListItem Text="Dependant" Value="1" ></asp:ListItem>

                      </asp:DropDownList>
                      </div> 
                            </div>  
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                         <div class="fg12">
                      <h3>Reference No. format after account closing</h3>
                      <div class="fg4 sa_2 sa_640_i sa_480">
                          </div>
                             <div class="form-group fg2 fg2_blk">
                       
                      <asp:DropDownList ID="ddlaccountclosing" class="form-control fg2_inp1 fg_chs2" onkeypress="return DisableEnter(event)" runat="server">
                           
                      <asp:ListItem Text="Continuation  of last Reference No." Value="0" Selected="True"></asp:ListItem>
                      <asp:ListItem Text="Create Sub Reference No." Value="1" ></asp:ListItem>

                      </asp:DropDownList>
                      </div> 
                            </div>  
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                        
                    </div>
                  </div>
                </div>


                  <%--emp-0043 start--%>
                  <button class="accordion_role sli_1" onclick="return false;" >Currency Settings</button>
                   <div class="panel_role">
                  <div class="box_pro_2 pro_pa wi_tre">
                    <div class="tree well wi_tre_1">
                       <div class="fg12">
                      <h3>Primary Currency </h3>
                            <div class="fg4 sa_2 sa_640_i sa_480">
                          </div>
                             <div class="form-group fg2 fg2_blk">
                                  <asp:DropDownList ID="ddlCurrency" class="form-control fg2_inp1 fg_chs2" onkeypress="return DisableEnter(event)" runat="server">
                           
                              </asp:DropDownList>
                                 </div> 
                            </div>  
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                        
                    </div>
                      </div> 
                </div>
                <%--end--%>



              </div>
                  
              <div class="clearfix"></div>
              <div class="free_sp"></div>


            </div>

            <!-----Finance section_closed---->

            <!-----General section_opened---->

                <div id="dtl_general" class="tabcontent_stf emply_ad_1" >
              <h1>GENERAL</h1>

              <%--<div class="modle_detl1 dis_set">--%>
                <div class="accordion-container">
                <%--<div class="set"--%>
                <button class="accordion_role sli_1" onclick="return false;"> TAX SETTINGS </button>
                <div class="panel_role">
                  <div class="box_pro_2 pro_pa wi_tre">
                    <div class="tree well wi_tre_1">
                      <div class="fg12">
                        <h3>Tax System</h3> 
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txttaxsystem" runat="server" class="form-control fg2_inp1 inp_mst" onkeypress="return onlyAlphabets(event,this);" placeholder="Enter tax system"/>
                        </div>
                      
                      </div>
                          
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                         <div class="fg12">
                        <h3>Enable Tax for Corporate office </h3>
                       <div class="fg4 sa_2 sa_640_i sa_480">
                         
                  <label for="email" class="fg2_la1 pad_l"><span class="spn1"></span></label>
                  <div class="check1">
                   <div class="">
                    <label class="switch">
                   <input type="checkbox"  id="checkboxenabletax"  onkeypress="return DisableEnter(event)" runat="server" />
                    <span class="slider_tog round"></span>
                  </label>
                 </div>
                </div>
                 </div>
                      </div>
                        <div class="clearfix"></div>
                      <div class="free_sp"></div>
                   
                  
                    <div class="fg12">
                        <h3>Number of decimal for tax system</h3>
                       <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txttaxdecimal" runat="server" class="form-control fg2_inp1 inp_mst" onkeypress="return isNumber(event)" placeholder="Enter number"/>
                        </div>
                      
                      </div>
                     
                         
                        
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                    </div>
                  </div>   
                </div>

                <button class="accordion_role sli_1" onclick="return false;">COLOR ATTRIBUTES</button>
                <div class="panel_role">
                  <div class="box_pro_2 pro_pa wi_tre">
                    <div class="tree well wi_tre_1">
                       <div class="fg12">
                      <h3>APPMASTER HEADER COLOUR</h3>
                     <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtappheader" runat="server" class="form-control fg2_inp1 inp_mst" onkeypress="return DisableEnter(event)" placeholder="Enter colour"/>
                        </div>                    
                      </div>
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>

                         <div class="fg12">
                        <h3>APPMASTER FOOTER COLOUR</h3>
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtappfooter" runat="server" class="form-control fg2_inp1 inp_mst" onkeypress="return DisableEnter(event)" placeholder="Enter colour"/>
                        </div>
                      
                      </div>
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                                       
                             <div class="fg12">
                        <h3>SALES MASTER HEADER COLOUR</h3>
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtsalesheader" runat="server" class="form-control fg2_inp1 inp_mst" onkeypress="return DisableEnter(event)" placeholder="Enter colour"/>
                        </div>
                      
                      </div>
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                         <div class="fg12">
                        <h3>SALES MASTER FOOTER COLOUR</h3>
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtsalesfooter" runat="server" class="form-control fg2_inp1 inp_mst" onkeypress="return DisableEnter(event)" placeholder="Enter colour"/>
                        </div>
                      
                      </div>
                         <div class="clearfix"></div>            
                    </div>
                  </div>
                </div>

            
                  <button class="accordion_role sli_1" onclick="return false;">LISTING MODES</button>
                <div class="panel_role">
                  <div class="box_pro_2 pro_pa wi_tre">
                    <div class="tree well wi_tre_1">
                      <div class="fg12">
                      <h3>MODE OF LISTING</h3>
                      <div class="fg4 sa_2 sa_640_i sa_480">
                          </div>
                             <div class="form-group fg2 fg2_blk">
                       
                      <asp:DropDownList ID="ddllistmode" class="form-control fg2_inp1 fg_chs2"  onkeypress="return DisableEnter(event)" runat="server">
                          
                      <asp:ListItem Text="Fixed" Value="1" Selected="True"> </asp:ListItem>
                      <asp:ListItem Text="Variable" Value="2" ></asp:ListItem>
                           
                         

                      </asp:DropDownList>
                      </div> 
                            </div>  
                      <div class="clearfix"></div>
                      <div class="free_sp"></div>
                         <div class="fg12">
                        <h3>LISTING SIZE</h3>
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtlistsize" runat="server" class="form-control fg2_inp1 inp_mst" onkeypress="return isNumber(event)" placeholder="Enter size in number"/>
                        </div>
                      
                      </div>
                        <div class="clearfix"></div>
                      <div class="free_sp"></div>
                        <div class="fg12">
                      <h3>ITEM LISTING MODE</h3>
                      <div class="fg4 sa_2 sa_640_i sa_480">
                          </div>
                             <div class="form-group fg2 fg2_blk">
                       
                      <asp:DropDownList ID="ddlitemlistingmode" class="form-control fg2_inp1 fg_chs2"  onkeypress="return DisableEnter(event)" runat="server">
                          
                      <asp:ListItem Text="Division based" Value="0" Selected="True"> </asp:ListItem>
                      <asp:ListItem Text="Common" Value="1" ></asp:ListItem>
                           
                         

                      </asp:DropDownList>
                      </div> 
                            </div>  
                         <div class="clearfix"></div>
                      <div class="free_sp"></div>
                    </div>
                  </div>
                </div>
                   <button class="accordion_role sli_1" onclick="return false;">OTHERS</button>
                <div class="panel_role">
                  <div class="box_pro_2 pro_pa wi_tre">
                    <div class="tree well wi_tre_1">
                       
                             <div class="fg12">
                        <h3>enable MANDATORY cancel reason </h3>
                       <div class="fg4 sa_2 sa_640_i sa_480">
                         
                  <label for="email" class="fg2_la1 pad_l"><span class="spn1"></span></label>
                  <div class="check1">
                   <div class="">
                    <label class="switch">
                   <input type="checkbox"  id="checkboxcancel"  onkeypress="return DisableEnter(event)" runat="server" />
                    <span class="slider_tog round"></span>
                  </label>
                 </div>
                </div>
                 </div>
                      </div>
                        <div class="clearfix"></div>
                      <div class="free_sp"></div>
                        <%--  <div class="fg12">
                        <h3>COMMON IMAGE PATH</h3>
                        <div class="fg4 sa_2 sa_640_i sa_480">                        
                        </div>
                        <div class="form-group fg4 sa_2 sa_640_i sa_480 ma_bo10">
                          <input type="text" id="txtcommonimagepath" runat="server" class="form-control fg2_inp1 inp_mst" onkeypress="return DisableEnter(event)" placeholder="Enter the path"/>
                        </div>
                      
                      </div>
                        <div class="clearfix"></div>
                      <div class="free_sp"></div>--%>
                           <div class="fg12">
                      <h3>COMMODITY STATUS</h3>
                      <div class="fg4 sa_2 sa_640_i sa_480">
                          </div>
                             <div class="form-group fg2 fg2_blk">
                       
                      <asp:DropDownList ID="ddlcomoditystatus" class="form-control fg2_inp1 fg_chs2"  onkeypress="return DisableEnter(event)" runat="server">
                          
                      <asp:ListItem Text="maintain commodity concept" Value="1" Selected="True"> </asp:ListItem>
                      <asp:ListItem Text="No Commodity concept" Value="2" ></asp:ListItem>
                           
                         

                      </asp:DropDownList>
                      </div> 
                            </div> 
                         <div class="clearfix"></div>
                      <div class="free_sp"></div>
                    </div>
                  </div>
                </div>
                
                  
              </div>
              <div class="clearfix"></div>
              <div class="free_sp"></div>

              
            </div>

            <!-----General section_closed---->

        </div>
      </div>

            </div>
    <a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
       <i class="fa fa-save"></i>
     </a>      
    
<!---date_picker_closed-->

<!--------tooltips------------>

    <script>

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }


   

        function onlyAlphabets(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
                    return true;
                else
                    return false;
            }
            catch (err) {
                alert(err.Description);
            }
        }

        function validateEmail(hrmail) {
            var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
            return emailPattern.test(hrmail);
        }


      </script>


<script>
    $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });
   

</script>

<script>
    $(document).ready(function () {
        $('[data-toggle="tooltip1"]').tooltip();
    });
</script>

<!--add new div---->
<script>
    $(document).ready(function () {
        $("#btx1").click(function () {
            $("p").append(" <b>Appended text</b>.");
        });
    });

   


</script>

<!--button_click_disable --->
<script>
    function myFunct() {
        document.getElementById("myinpb").disabled = false;
        document.getElementById("myinpc").disabled = true;
        document.getElementById("myinpc1").disabled = true;
        document.getElementById("myinpc2").disabled = true;
        document.getElementById("myinpc3").disabled = true;
    }
</script>

<script>
    function mysave() {
        var x = document.getElementById("mysav");
        if (x.style.display === "block") {
            x.style.display = "none";
        } else {
            x.style.display = "block";
        }
    }
</script>

<script>
    function issue_chk() {
        var x = document.getElementById("is_chk");
        if (x.style.display === "block") {
            x.style.display = "none";
        } else {
            x.style.display = "block";
        }
    }
</script>

<!--save_pop up_open-->
<script>
    function opensave() {
        document.getElementById("mySave").style.width = "140px";
    }

    function closesave() {
        document.getElementById("mySave").style.width = "0px";
    }
   
 












</script>
<!--save_pop up_closed-->

<!----hide/Show_section---->
<script>
    $(document).ready(function () {
        $("#hide").click(function () {
            $(".c1h").hide();
        });
        $("#show").click(function () {
            $(".c1h").show();
        });
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


<script>
    function open_box_St(evt, cityName) {
        var i, tabcontent, tablinks;
        tabcontent = document.getElementsByClassName("tabcontent_stf");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }
        tablinks = document.getElementsByClassName("tablinks");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].className = tablinks[i].className.replace(" active", "");
        }
        document.getElementById(cityName).style.display = "block";
        evt.currentTarget.className += " active";
        return false;
    }

    // Get the element with id="defaultOpen" and click on it
    //document.getElementById("defaultOpen").click();
</script>







<!---accodition section_script_opened--->
<script>
    var acc = document.getElementsByClassName("accordion_role");
    var i;

    for (i = 0; i < acc.length; i++) {
        acc[i].addEventListener("click", function () {
            this.classList.toggle("active");
            var panel_role = this.nextElementSibling;
            if (panel_role.style.maxHeight) {
                panel_role.style.maxHeight = null;
            } else {
                panel_role.style.maxHeight = panel_role.scrollHeight + "px";
            }

        });

    }
</script>
<!---accodition section_script_closed--->

<!---emergency contact section_script--->
<script>
    $(document).ready(function () {
        $(".ad_emrgy").click(function () {
            $(".emrgcy_cntct").toggle();
        });

    });
</script>
   <script type="text/javascript">
       $(function () {

           $('#payrolldatepicker1').datepicker({
               autoclose: true,
               format: 'dd-mm-yyyy',
           });

           $("#payrolldatepicker2").datepicker({
               autoclose: true,
               format: 'dd-mm-yyyy',
           });

       });
</script>

<script>
    $(document).ready(function () {
        $(".des_1").click(function () {
            $(".des_1_opn").show(100);
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(".act_typ").click(function () {
            $(".act_typ_py").show(100);
        });
    });
</script>
   
<script>
    function per_adrs() {
        if (document.getElementById("per_adrs").checked == true) {
            document.getElementById("per_adrs_dsb").disabled = true;
            document.getElementById("per_adrs_dsb1").disabled = true;
            document.getElementById("per_adrs_dsb2").disabled = true;
            document.getElementById("per_adrs_dsb3").disabled = true;
            document.getElementById("per_adrs_dsb4").disabled = true;
            document.getElementById("per_adrs_dsb5").disabled = true;
            document.getElementById("per_adrs_dsb6").disabled = true;
            document.getElementById("per_adrs_dsb7").disabled = true;
            document.getElementById("per_adrs_dsb8").disabled = true;
            document.getElementById("per_adrs_dsb9").disabled = true;
            document.getElementById("per_adrs_dsb10").disabled = true;
        } else {
            document.getElementById("per_adrs_dsb").disabled = false;
            document.getElementById("per_adrs_dsb1").disabled = false;
            document.getElementById("per_adrs_dsb2").disabled = false;
            document.getElementById("per_adrs_dsb3").disabled = false;
            document.getElementById("per_adrs_dsb4").disabled = false;
            document.getElementById("per_adrs_dsb5").disabled = false;
            document.getElementById("per_adrs_dsb6").disabled = false;
            document.getElementById("per_adrs_dsb7").disabled = false;
            document.getElementById("per_adrs_dsb8").disabled = false;
            document.getElementById("per_adrs_dsb9").disabled = false;
            document.getElementById("per_adrs_dsb10").disabled = false;
        }
    }
</script>

<script>
    $(document).ready(function () {
        $(".per_sel").click(function () {
            $(".amnt_1").hide(100);
            $(".percn_1_a").show(100);
        });
        $(".amt_sel").click(function () {
            $(".amnt_1").show(100);
            $(".percn_1_a").hide(100);
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(".per_sel_d").click(function () {
            $(".amnt_1_d").hide(100);
            $(".percn_1_d").show(100);
        });
        $(".amt_sel_d").click(function () {
            $(".amnt_1_d").show(100);
            $(".percn_1_d").hide(100);
        });
        open_box_St(event, 'dtl_human');
    });
</script>

<script>
    function per_adrs1() {
        if (document.getElementById("chkv1").checked == true) {
            document.getElementById("des_1").disabled = false;
            document.getElementById("des_2").disabled = false;
        } else {
            document.getElementById("des_1").disabled = true;
            document.getElementById("des_2").disabled = true;
        }
    }
</script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".set > a").on("click", function () {
                if ($(this).hasClass("active")) {
                    $(this).removeClass("active");
                    $(this)
                      .siblings(".content_acr")
                      .slideUp(200);
                    $(".set > a i")
                      .removeClass("fa-minus")
                      .addClass("fa-plus");
                } else {
                    $(".set > a i")
                      .removeClass("fa-minus")
                      .addClass("fa-plus");
                    $(this)
                      .find("i")
                      .removeClass("fa-plus")
                      .addClass("fa-minus");
                    $(".set > a").removeClass("active");
                    $(this).addClass("active");
                    $(".content_acr").slideUp(200);
                    $(this)
                      .siblings(".content_acr")
                      .slideDown(200);
                }
            });
        });
        </script>


    <div class="mySave1" id="mySave">
  <div class="save_sec" >
      <asp:Button ID="Btnsaveappsettings" runat="server" Text="SAVE SETTINGS"   class="btn sub1 bt_b" OnClientClick="return ValidateRegForm();" OnClick="Btnsaveappsettings_Click" />     
  </div>

 
    </div>
</asp:Content>
<%-- END EVM040--%>

  
     
 