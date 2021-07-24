<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="Compzit_Home_Hcm.aspx.cs" Inherits="Home_Compzit_Home_Compzit_Home_Hcm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <link href="../../css/Design-CSS/main.css" rel="stylesheet" />
    <link href="../../css/Design-CSS/responsive.css" rel="stylesheet" />

    <link href="../../css/HCM/Dashboard/wow-effects/css/libs/animate.css" rel="stylesheet" />
    <link href="../../JavaScript/Hcm_DashBoard/css/plugins/morris.css" rel="stylesheet" />

    <link href="../../css/HCM/Dashboard/dashboard.css" rel="stylesheet" />
    <link href="../../css/HCM/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:HiddenField ID="hiddenEmployeeBarDiaData" runat="server" />
    <asp:HiddenField ID="hiddenjsondtails" runat="server" />
    <asp:HiddenField ID="Hiddenrowcount" runat="server" />
    <asp:HiddenField ID="HiddenLoginUserId" runat="server" />
    <asp:HiddenField ID="HidddenAccodetails" runat="server" />
    <asp:HiddenField ID="HiddenFieldResgGobtn" runat="server" />
    <asp:HiddenField ID="HiddenCurncyAbrv" runat="server" />
    <asp:HiddenField ID="HiddenFlightAmt" runat="server" />
      <asp:HiddenField ID="HiddenResponseType" runat="server" />
     <asp:HiddenField ID="HiddenToCheckOthersConduct" runat="server" />

    <div id="divContentArea" runat="server" class="contentarea">
            
           <div id="divPopUpPerformance" runat="server" class="auto1 animated fadeInDown" style="position: absolute;
    z-index: 100;width:95%;display:none;margin-top: -2%;">
         <a href="#" data-modal-id="PopUpPerformance"><div id="card-alert" class="card-01 light-blue animated slideInRight" style="float:right">
     <div style="float: left;
    height: 20px;
    background-color: #8f5ee6;
    padding: 20px;
    border-radius: 1px;
    color: white;
    margin-right:17px;
margin-left: 1%;
margin-top: 1%;
margin-bottom: 1%;"><i class="fa fa-bell animate-flicker" aria-hidden="true" ></i></div>
                      <div class="card-content white-text" >
                     
                        <p><span class="numberCircle">
                            <asp:Label ID="lblIssuseCount" runat="server" ></asp:Label> </span>
                        Performance Form</p>
                      </div>
                    </div></a>
    </div>  
                         <div id="divPerfmncEvltn" runat="server" class="auto1 animated fadeInDown" style="position: absolute;   
    z-index: 100;width:95%; display:none;margin-top: 2.5%;"> 
                  
         <a href="../../HCM/HCM_Master/Employee_Performance_Mangmnt/Employee_Perfomance_Evaluation/Employee_Perfomance_Evaluation_List.aspx" ><div id="Div2" class="card-01 light-blue animated slideInRight" style="float:right" >
     <div style="float: left;
    height: 20px;
    background-color: #8f5ee6;
    padding: 20px;
    border-radius: 1px;
    color: white;
    margin-right:17px;
margin-left: 1%;
margin-top: 1%;
margin-bottom: 1%;"><i class="fa fa-bell animate-flicker" aria-hidden="true" ></i></div>
                      <div class="card-content white-text" >
                     
                        <p><span class="numberCircle">
                            <asp:Label ID="lblPrfmncEvltn" runat="server" ></asp:Label> </span>
                        Performance Evaluation</p>
                      </div>
                    </div></a>
    </div>  
        <div class="auto1 animated fadeInDown" style="width: 100%">




            <div class="col_3" style="margin-top: 16px; padding-right: 0; background-color: white; padding: 8px; box-shadow: 1px 1px 5px #CCCCCC;">
                <i class="fa fa-tasks" style="color: #6d89a5; font-size: 24px;"></i><span style="font-size: 22px; margin-left: 2%; color: #6d89a5;">Your Task</span>
            </div>
            <div class="col_3" style="margin-top: 6px; padding-right: 0;">
                 <a href="/Hcm/Hcm_Master/hcm_OnBoarding/hcm_OnBoarding_Partial_Process/hcm_OnBoarding_Partial_Process_List.aspx">
                <div class="col-sm-4 col-md-4 widget widget1">

                    <div class="r3_counter_box">
                        <i class="pull-left fa fa-plane icon-rounded"></i>
                        <div class="stats">
                            <h5 id="lblOnboarding" runat="server"><strong>10</strong></h5>
                            <span>Onboarding</span>
                        </div>
                    </div>
                </div></a>
                 <a href="/Hcm/Hcm_Master/hcm_Immigration/hcm_Immigration_Task/hcm_Immigration_Task_List.aspx">
                <div class="col-sm-4 col-md-4 widget widget1">
                    <div class="r3_counter_box">
                        <i class="pull-left fa fa-check user1 icon-rounded green-bg"></i>
                        <div class="stats">
                            <h5 id="lblImmigration" runat="server"><strong>50</strong></h5>
                            <span>Immigration</span>
                        </div>
                    </div>
                </div></a>
                 <a href="/Hcm/Hcm_Master/gen_Candidate_Selection/gen_Candidate_SelectionList.aspx">
                <div class="col-sm-4 col-md-4 widget widget1">
                    <div class="r3_counter_box">
                        <i class="pull-left fa fa-users user2 icon-rounded magenta-bg"></i>
                        <div class="stats">
                            <h5 id="lblRecruitment" runat="server"><strong>30</strong></h5>
                            <span>Recruitment</span>
                        </div>
                    </div>
                </div></a>
                <div class="col-sm-4 col-md-4 widget widget1">

                    <div class="r3_counter_box">
                        <a href="javascript:;" id="menu-toggle1">
                            <i class="pull-left fa fa-pie-chart dollar1 icon-rounded rose-bg"></i>
                            <div class="stats">
                                <h5 id="lblcountClearance" runat="server"><strong></strong></h5>
                                <span>Clearance</span>
                            </div>
                        </a>
                    </div>
                </div>


          <a href="/Hcm/Hcm_Master/hcm_Employee_Conduct_Management/hcm_Emp_Conduct/hcm_Emp_Conduct_List.aspx">
       <div class="col-sm-4 col-md-4 widget widget1">
                    <div class="r3_counter_box">
                        <i class="pull-left   fa fa fa-file icon-rounded magenta-bg"></i>
                        <div class="stats">
                      
  <h5 id="h5ConductCount" runat="server"><strong>0</strong></h5> 
                            <span>Self Conduct</span>
                        </div>
                          
                    </div>
          
                </div></a>


                  <a id="OtherCondid" style="display:none" runat="server" href="/Hcm/Hcm_Master/hcm_Employee_Conduct_Management/hcm_Emp_Conduct/hcm_Emp_Conduct_List.aspx">
       <div class="col-sm-4 col-md-4 widget widget1">
                    <div class="r3_counter_box">
                        <i class="pull-left   fa fa fa-file icon-rounded magenta-bg"></i>
                        <div class="stats">
                      
  <h5 id="h5OthersCond" runat="server"><strong>0</strong></h5> 
                            <span>Others Conduct</span>
                        </div>
                          
                    </div>
          
                </div></a>


                <ul class="menu_drop" data-menu style="top: 43px; right: 50px" data-menu-toggle="#menu-toggle1, #menu-toggle2" runat="server" id="handovernotify">
                </ul>

                <div class="clearfix"></div>
            </div>

            <div class="cont_rght" style="width: 100%; padding-right: 0; padding-top: 7em;">

                <div class="col-md-8 col-sm-12 bargraph_dis_none" style="margin-top: 4px; padding: 18px; overflow: hidden; box-shadow: 1px 1px 5px #CCCCCC; background-color: #FFF; margin-bottom: 7px;">
                    <div class="col-xs-12 chan_graph">
                        <ul>
                            <li><a href="#graph1" class="active">DIVISION</a> </li>
                            <%--                 <li> <a href="#">WORK SITE</a>  </li> 
                   <li><a href="#">PROJECT</a></li> --%>
                            <%--<li><a href="graph2"> DEPARTMENT</a></li>--%>
                        </ul>
                    </div>

                    <h3 class="text-center">Employee Availability</h3>
                    <div id="graph1" style="height: 250px;"></div>
                    <%--<div id="graph2" style="height: 250px;"></div>--%>
                    <div class="col-xs-12 dis_none" style="text-align: center; color: #999">
                       <%-- <span><span class="emp_box" style="background-color: #0095f2"></span><span style="margin-left: 2%;">Allocate</span></span>--%>
                        <span><span class="emp_box sm_bg_02"></span><span style="margin-left: 2%;">Available</span></span>
                       <%-- <span><span class="emp_box sm_bg_03"></span><span style="margin-left: 2%;">On Leave</span></span>--%>
                        <span><span class="emp_box" style="background-color: #0095f2"></span><span style="margin-left: 2%;">On Leave</span></span>
                    </div>
                    <span class="total-no">Total number of employees:<label>500</label></span>
                </div>

                <div class="col-md-2" style="margin-top: 4px; padding-right: 0; padding-left: 6px; background-color: #cfc3c3;">
                    <div class="market-updates">

                        <div class="col-xs-12 market-update-gd" style="padding: 0;">
                              <a href="/HCM/HCM_Master/gen_Manpower_Recruitment/gen_Manpower_Recruitment_List.aspx">
                            <div class="market-update-block clr-block-1">
                                <div class="col-md-7 col-sm-10 market-update-left flot-left">
                                    <h3 id="lblTotalManPower" runat="server"></h3>
                                    <h4>Total Manpower Requirement <span style="font-size: 9px;">( this year )</span></h4>

                                </div>
                                <div class="col-md-2 col-sm-2 market-update-right">
                                    <i class="fa fa-users fa-male-text-o"></i>
                                </div>
                                <div class="clearfix"></div>
                            </div></a>
                        </div>
                        <div class="col-xs-12 market-update-gd" style="padding: 0;">
                            <a href="/HCM/HCM_Master/gen_Manpower_Recruitment/gen_Manpower_Recruitment_List.aspx">
                            <div class="market-update-block clr-block-2">
                                <div class="col-md-7 col-sm-10 market-update-left flot-left">
                                    <h3 id="lblManPowerPndng" runat="server"></h3>
                                    <h4>Manpower Requirement <span style="font-size: 9px;">(Approval Pending)</span></h4>
                                    <p></p>
                                </div>
                                <div class="col-md-2 col-xs-2 market-update-right">
                                    <i class="fa fa-eye fa-male"></i>
                                </div>
                                <div class="clearfix"></div>
                            </div></a>
                        </div>
                        <div class="col-xs-12 market-update-gd" style="padding: 0;">
                            <a href="/HCM/HCM_Master/gen_Manpower_Recruitment/gen_Manpower_Recruitment_List.aspx">
                            <div class="market-update-block clr-block-3">
                                <div class="col-md-7 col-sm-10 market-update-left flot-left">
                                    <h3 id="lblManPowerAprvd" runat="server"></h3>
                                    <h4>Manpower Requirement  <span style="font-size: 9px;">(Approved)</span> </h4>

                                </div>
                                <div class="col-md-2 col-xs-2 market-update-right">
                                    <i class="fa fa-check fa-envelope-o"></i>
                                </div>
                                <div class="clearfix"></div>
                            </div></a>
                        </div>
                        <div class="col-xs-12 market-update-gd" style="padding: 0;">
                            <a href="/HCM/HCM_Master/gen_Interview_Process/gen_Interview_Process_List.aspx">
                            <div class="market-update-block clr-block-4">
                                <div class="col-md-7 col-sm-10 market-update-left flot-left">
                                    <h3 id="lblInterviewprocess" runat="server">23</h3>
                                    <h4>Interview Process </h4>

                                </div>
                                <div class="col-md-2 col-xs-2 market-update-right">
                                    <i class="fa fa-handshake-o fa-envelope-o" style="color: #33bba1;"></i>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                                </a>
                        </div>
                        <div class="col-xs-12 market-update-gd" style="padding: 0;">
                             <a href="/Hcm/Hcm_Master/hcm_OnBoarding/hcm_OnBoarding_Process/hcm_OnBoarding_Process_List.aspx">
                            <div class="market-update-block clr-block-5">
                                <div class="col-md-7 col-sm-10 market-update-left flot-left">
                                    <h3 id="lblOnboardingProcess" runat="server">23</h3>
                                    <h4>Onboarding Process</h4>
                                </div>
                                <div class="col-md-2 col-xs-2 market-update-right">
                                    <i class="fa fa-plane fa-envelope-o" style="color: #b60576;"></i>
                                </div>
                                <div class="clearfix"></div>
                            </div></a>
                        </div>


                    </div>
                </div>
                

                <div class="col-md-2" style="margin-top: 4px; padding-right: 0; padding-left: 6px; background-color: #e3e3e3;">

                    <h2 style="font-family: calibri; color: #4b2159; margin-bottom: 10px; font-weight: bold; font-size: 18px; padding: 26px;">Today's Attendance</h2>
                    <div class="col-xs-12 market-update-gd" style="padding: 0;">
                           <a href="/HCM/HCM_Master/hcm_PayrollSystem/hcm_Employee_Daily_Hour/hcm_Employee_Daily_Hour_List.aspx">
                        <div class="market-update-block clr-block-5">
                            <div class="col-md-7 col-sm-10 market-update-left flot-left">
                                <h3 id="lblEmpPresent" runat="server">23</h3>
                                <h4>Present</h4>
                            </div>
                            <div class="col-md-2 col-xs-2 market-update-right">
                                <i class="fa fa-male fa-envelope-o" style="color: #197cd4;"></i>
                            </div>
                            <div class="clearfix"></div>
                        </div></a>
                    </div>
                    <div class="col-xs-12 market-update-gd" style="padding: 0;">
                         <a href="/HCM/HCM_Master/hcm_PayrollSystem/hcm_Employee_Daily_Hour/hcm_Employee_Daily_Hour_List.aspx">
                        <div class="market-update-block clr-block-5">
                            <div class="col-md-7 col-sm-10 market-update-left flot-left">
                                <h3 id="lblEmpAbsent" runat="server">23</h3>
                                <h4>Absent</h4>
                            </div>
                            <div class="col-md-2 col-xs-2 market-update-right">
                                <i class="fa fa-times fa-envelope-o" style="color: #fb1e06;"></i>
                            </div>
                            <div class="clearfix"></div>
                        </div></a>
                    </div>
                    <div class="col-xs-12 market-update-gd" style="padding: 0;">
                           <a href="/HCM/HCM_Master/hcm_LeaveMaster/hcm_Leave_Request/hcm_Leave_Request_List.aspx">
                        <div class="market-update-block clr-block-5">
                            <div class="col-md-7 col-sm-10 market-update-left flot-left">
                                <h3 id="lblMyLeaveCount" runat="server">23</h3>
                                <h4>Leave clearance approved current year
                                </h4>
                            </div>
                            <div class="col-md-2 col-xs-2 market-update-right">
                                <i class="fa fa-arrow-right fa-envelope-o" style="color: #b60576;"></i>
                            </div>
                            <div class="clearfix"></div>
                        </div></a>
                    </div>
                    <div class="col-xs-12 market-update-gd" style="padding: 0;">
                        <div class="market-update-block clr-block-5">
                            <div class="col-md-7 col-sm-10 market-update-left flot-left">
                                <h3 id="lblNextLeave" runat="server">23</h3>
                                <h4>Next Leave on</h4>
                            </div>
                            <div class="col-md-2 col-xs-2 market-update-right">
                                <i class="fa fa-pie-chart fa-envelope-o" style="color: #2c568f;"></i>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12" style="padding: 0; padding-top: 1em;">
                    <div class="col-lg-8 col-md-8 col-sm-12 clearance_div animated" style="margin-top: 1%; padding: 0;">

                        <div class="col-xs-12" style="background-color: #E3E3E3; box-shadow: 1px 1px 5px #CCCCCC; padding: 17px 7px 0 9px; min-height: 284px;">
                              <a href="/Hcm/Hcm_Master/hcm_OnBoarding/hcm_OnBoarding_Partial_Process/hcm_OnBoarding_Partial_Process_List.aspx">
                            <div class="box_div_2 on">
                                <p>
                                    Applied visa
                                </p>
                                <label id="lblVisaApplied" runat="server"></label>
                            </div>
                            <div class="box_div_2 on">
                                <p>
                                    Pending visa
                                </p>

                                <label id="lblVisaPending" runat="server"></label>
                            </div>
                            <div class="box_div_2 on">
                                <p>
                                    Rejected visa
                                </p>

                                <label id="lblVisaRejected" runat="server"></label>
                            </div>
                            <div class="box_div_2 on">
                                <p>
                                    Approved visa
                                </p>

                                <label id="lblVisaApproved" runat="server"></label>
                            </div>
                                  </a>
                            <div style="margin-top: 10px">
                                  <a href="#" data-modal-id="popupFlightApplied">
                                <div class="box_div_2 on" style="border-bottom-color: #0095f2;">
                                    <p>Applied Flight tickets</p>

                                    <label id="lblTcktApplied" runat="server"></label>
                                </div>
                                      </a>
                                  <a href="#" data-modal-id="popupFlightBuy">
                                <div class="box_div_2 on" style="border-bottom-color: #0095f2;">
                                    <p>Buy Flight tickets</p>

                                    <label id="lblTcktBuy" runat="server"></label>
                                </div>
                                      </a>
                                <a href="#" data-modal-id="popupFlightAmount">
                                <div class="box_div_2 on" style="border-bottom-color: #0095f2;">
                                    <p>Total Amount Flight ticket</p>

                                    <label id="lblTcktAmount" runat="server"></label>
                                </div>
                                    </a>
                                 <a href="#" data-modal-id="popUpEmpBirthday">
                                <div class="box_div_2 on" style="border-bottom-color: #0095f2;">
                                    <p>Birthday's Today</p>

                                    <label id="lblBirthdayToday" runat="server"></label>
                                </div></a>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-12 clearance_div animated " style="padding-right: 0; padding-left: 7px;">

                        <div class="clearance_header_div">
                            <span>CLEARANCE</span>
                        </div>
                         <a href="/Hcm/Hcm_Master/hcm_LeaveMaster/hcm_Clearance_Form_Approval/hcm_Clearance_Form_Approval_List.aspx">
                        <div class="col-xs-12" style="background-color: #2c568f; padding-bottom: 3px;">
                            <div class="box_div on">
                                <p style="padding-bottom: 6px;">PENDING</p>
                                <h1 class="red">EXIT</h1>
                                <label id="lblExitCount" runat="server"></label>
                            </div>
                            <div class="box_div on">
                                <p style="padding-bottom: 6px;">PENDING</p>
                                <h1 class="yellow">LEAVE</h1>
                                <label id="lblLeaveCount" runat="server"></label>
                            </div>
                        </div></a>
                        <div style="clear: both"></div>
                        <div class="clearance_header_div" style="padding: 0;">
                            <span>Employee</span>
                        </div>
                        <div class="col-xs-12" style="background-color: #2c568f; padding-bottom: 12px;">
                             <a href="/Hcm/Hcm_Master/hcm_LeaveMaster/hcm_Clearance_Form_Approval/hcm_Clearance_Form_Approval_List.aspx">
                            <div class="box_div on">
                                 <p style="padding-bottom: 6px;">APPROVED</p>
                                <h1 class="red" >EXIT</h1>
                                <label id="lblExitAproved" runat="server" ></label>
                            </div></a>
                             <a href="/HCM/HCM_Master/hcm_PayrollSystem/hcm_Duty_Rejoin/hcm_Duty_Rejoin_List.aspx">
                            <div class="box_div on">
                                <p style="padding-bottom: 6px;">APPROVED</p>
                                <h1 class="yellow" style="color: #3f9e10;">RESUME</h1>
                                <label id="lblRejoinCount" runat="server" ></label>
                            </div></a>
                        </div>

                    </div>
                </div>


            </div>

            <div style="clear: both"></div>

            <div class="col-lg-12" style="padding: 0px; padding-top: 1em;">

                <div class="col-lg-4 col-md-8 col-sm-12 clearance_div animated  mar-top-air-div" style="padding: 0; padding-left: 5px;">

                    <div class="clearance_header_div" style="background-color: #74237a; height: 41px;">

                        <span style="padding-top: 6px;">AIRPORT</span>
                    </div>
                    <div class="col-xs-12 airport_div" style="">
                          <a href="#" data-modal-id="popupEmpArr">
                        <div class="col-sm-4 col-md-4 air_port_box on">
                            <br />
                            <label id="lblArriveCount" runat="server">100</label>
                            <p>
                                EMPLOYEE
                                <br />
                                 ARRIVED
                            </p>


                        </div>
                              </a>
                          <a href="#" data-modal-id="popUpEmpDepart">
                        <div class="col-sm-4 col-md-4 air_port_box on">
                            <br />
                            <label id="lblDepartCount" runat="server">1000</label>
                            <p>
                                EMPLOYEE
                                <br />
                                 DEPARTED
                            </p>



                        </div>
                              </a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-12 accomodation_div animated " style="padding: 0px; padding-left: 8px;">
                    <div class="clearance_header_div accomodation_head" style="height: 41px">
                        <img src="/Images/HCM/hcm_dashboard/accomodation_icon.png" />
                        <p>ACCOMODATION</p>
                    </div>

                    <div class="col-xs-12 col-sm-12" style="background-color: #FFFFFF; box-shadow: 1px 1px 5px #CCCCCC; height: auto; font-family: Arial, Helvetica, sans-serif; color: gray; font-size: 13px; padding: 0px;">
                        <div class="col-lg-7">
                            <div class="text-center">
                                <div id="graph" style="height: 180px;"></div>
                            </div>
                        </div>
                        <div class="col-lg-5" style="padding: 0;">

                            <p style="margin-top: 78px;"><span class="sm_box sm_bg_01"></span>&nbsp;Filled Rooms</p>
                            <p><span class="sm_box sm_bg_02"></span>&nbsp;Immediate vacate</p>
                            <p><span class="sm_box sm_bg_03"></span>&nbsp;Available Rooms</p>
                            <h3 id="TotalRooms" runat="server" class="accomoda_h3">Total Rooms :1500</h3>
                        </div>
                    </div>
                </div>


            </div>
        </div>

    </div>


    <div id="popupFlyToday" class="modal-box">
        <header style="background-color: #184e7d; border-bottom: 2px solid #184e7d;">
            <h3>Ready To Fly Today List</h3>
        </header>
        <div class="modal-body col-xs-12" style="padding: 0px;">
            <div runat="server" class="customers" id="divFlyToday">
            </div>
        </div>
        <footer><a class="btn btn-small js-modal-close">Close</a> </footer>

    </div>

    <div id="popupFlightApplied" class="modal-box">
        <header style="background-color: #327f96; border-bottom: 2px solid #327f96;">
            <h3>Flight Applied List</h3>
        </header>
        <div class="modal-body col-xs-12" style="padding: 0px;">
            <div runat="server" class="customers" id="divFlightApplied">
            </div>
        </div>
        <footer><a class="btn btn-small js-modal-close">Close</a> </footer>

    </div>
    <div id="popupFlightBuy" class="modal-box">
        <header style="background-color: #327f96; border-bottom: 2px solid #327f96;">
            <h3>Flight Ticket List</h3>
        </header>
        <div class="modal-body col-xs-12" style="padding: 0px;">
            <div runat="server" class="customers" id="divFlightBuy">
            </div>
        </div>
        <footer><a class="btn btn-small js-modal-close">Close</a> </footer>

    </div>

    <div id="popupFlightAmount" class="modal-box">
        <header style="background-color: #327f96; border-bottom: 2px solid #327f96;">
            <h3>Flight Amount List</h3>
        </header>
        <div class="modal-body col-xs-12" style="padding: 0px;">
            <div runat="server" class="customers" id="divFlightAmount">
            </div>
        </div>
        <footer><a class="btn btn-small js-modal-close">Close</a> </footer>

    </div>

    <div id="popupEmpArr" class="modal-box">
        <header>
            <h3>Employee Arrive list</h3>
        </header>
        <div class="modal-body col-xs-12" style="padding: 0px;">
            <div runat="server" class="customers" id="divEmpArrive">
            </div>
        </div>
        <footer><a class="btn btn-small js-modal-close">Close</a> </footer>

    </div>


    <div id="popUpEmpDepart" class="modal-box">
        <header>
            <h3>Employee Depart List</h3>
        </header>
        <div class="modal-body col-xs-12" style="padding: 0px;">
            <div runat="server" class="customers" id="divEmpDepart">
            </div>
        </div>
        <footer><a class="btn btn-small js-modal-close">Close</a> </footer>

    </div>
          <div id="PopUpPerformance" class="modal-box">
        <header>
            <h3>Employee Performance</h3>
        </header>
        <div class="modal-body col-xs-12" style="padding: 0px;">
            <div runat="server" class="customers" id="divEmpPerformance">
            </div>
        </div>
        <footer><a class="btn btn-small js-modal-close">Close</a> </footer>

    </div>



    <div id="popUpEmpBirthday" class="modal-box">
        <header>
            <h3>Employee Birthday List</h3>
        </header>
        <div class="modal-body col-xs-12" style="padding: 0px;">
            <div runat="server" class="customers" id="divBirthdayList">
            </div>
        </div>
        <footer><a class="btn btn-small js-modal-close">Close</a> </footer>

    </div>


    <div id="pg-following" class="pignose-popup table_design">
        <div class="item_header">
            <span class="txt_title">Mark the status</span>
            <a href="#" class="btn_close">
                <img src="/Images/Icons/icon_close.gif" alt="close modal" /></a>
        </div>
        <div class="scroll_design">
            <div class="item_content">
                <div></div>
                <div id="divhandovernotifc" runat="server"></div>
                <div style="margin-top: 7%;">
                    <asp:Button ID="btnProcessSingleSave" CssClass="pop_button" runat="server" Text="Submit" Style="margin-right: 9%" OnClientClick="return ValidateProcessSinglehcmMastr()" OnClick="btnProcessSingleSave_Click" />

                    <asp:Button ID="btnCancel" CssClass="pop_button" runat="server" Text="Cancel" OnClientClick="return CloseModal()" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>



    </div>


    <script src="../../JavaScript/Hcm_DashBoard/js/jquery-1.11.2.min.js"></script>

    <script src="../../JavaScript/Hcm_DashBoard/js/jquery.min.js"></script>
    <script src="../../JavaScript/Hcm_DashBoard/js/bootstrap.min.js"></script>
    <script src="../../JavaScript/Hcm_DashBoard/js/jquery-1.12.4.js"></script>
    <script src="../../JavaScript/Hcm_DashBoard/js/plugins/circleChart/circleChart.js"></script>
    <script src="../../css/HCM/Dashboard/wow-effects/dist/wow.min.js"></script>
    <script>
        wow = new WOW(
        {
        }
        );
        wow.init();
    </script>
    <script>
        $(".circleChart#0").circleChart({
            color: "#09d76f",
            backgroundColor: "#e6e6e6",
            background: true,
            speed: 4000,
            widthRatio: 0.2,
            value: 0,
            unit: 'percent',
            counterclockwise: false,
            size: 180,
            startAngle: 125,
            animate: true,
            backgroundFix: true,
            lineCap: "square", // butt, round, square
            animation: "easeInOutCubic", // linearTween, easeInQuad, easeOutQuad, easeInOutQuad, easeInCubic, easeOutCubic, easeInOutCubic, easeInQuart, easeOutQuart, easeInOutQuart, easeInQuint, easeOutQuint, easeInOutQuint, easeInSine, easeOutSine, easeInOutSine, easeInExpo, easeOutExpo, easeInOutExpo, easeInCirc, easeOutCirc, easeInOutCirc
            text: 0,
            redraw: true,
            cAngle: 0.1,
            textCenter: true,
            textSize: true,
            relativeTextSize: 5 / 10,
            autoCss: true,
            onDraw: function () { }
        });

        $(".circleChart#1").circleChart({
            color: "#f57a34",
            backgroundColor: "#e6e6e6",
            background: true,
            speed: 4000,
            widthRatio: 0.2,
            value: 0,
            unit: 'percent',
            counterclockwise: false,
            size: 180,
            startAngle: 125,
            animate: true,
            backgroundFix: true,
            lineCap: "square", // butt, round, square
            animation: "easeInOutCubic", // linearTween, easeInQuad, easeOutQuad, easeInOutQuad, easeInCubic, easeOutCubic, easeInOutCubic, easeInQuart, easeOutQuart, easeInOutQuart, easeInQuint, easeOutQuint, easeInOutQuint, easeInSine, easeOutSine, easeInOutSine, easeInExpo, easeOutExpo, easeInOutExpo, easeInCirc, easeOutCirc, easeInOutCirc
            text: 0,
            redraw: true,
            cAngle: 0.1,
            textCenter: true,
            textSize: true,
            relativeTextSize: 5 / 10,
            autoCss: true,
            onDraw: function () { }
        });
        $(".circleChart#2").circleChart({
            color: "#2c568f",
            backgroundColor: "#e6e6e6",
            background: true,
            speed: 4000,
            widthRatio: 0.2,
            value: 0,
            unit: 'percent',
            counterclockwise: false,
            size: 180,
            startAngle: 125,
            animate: true,
            backgroundFix: true,
            lineCap: "square", // butt, round, square
            animation: "easeInOutCubic", // linearTween, easeInQuad, easeOutQuad, easeInOutQuad, easeInCubic, easeOutCubic, easeInOutCubic, easeInQuart, easeOutQuart, easeInOutQuart, easeInQuint, easeOutQuint, easeInOutQuint, easeInSine, easeOutSine, easeInOutSine, easeInExpo, easeOutExpo, easeInOutExpo, easeInCirc, easeOutCirc, easeInOutCirc
            text: 0,
            redraw: true,
            cAngle: 0.1,
            textCenter: true,
            textSize: true,
            relativeTextSize: 5 / 10,
            autoCss: true,
            onDraw: function () { }
        });

    </script>

    <style>
        .font_sty_1 {
            font-size: 42px;
            color: #09d76f;
        }

        .font_sty_2 {
            font-size: 42px;
            color: #f57a34;
        }

        .font_sty_3 {
            font-size: 42px;
            color: #2c568f;
        }

        .exp {
            width: 100%;
            text-align: center;
        }




        .col-md-4.widget {
            width: 16.46%;
            /*-webkit-transition: 0.5s all;
    -moz-transition: 0.5s all;
    -o-transition: 0.5s all;
    -ms-transition: 0.5 sall;
    transition: 0.5s all;*/
        }

        .widget1 {
            margin-right: 0.2%;
        }

        .widget {
            padding: 0;
        }

        .widget {
            width: 32%;
            border: 1px solid #F5F1F1;
            padding: 0px;
            -webkit-box-shadow: 0px 0px 5px -2px rgba(0,0,0,0.75);
            -moz-box-shadow: 0px 0px 5px -2px rgba(0,0,0,0.75);
            box-shadow: 0px 0px 5px -2px rgba(0,0,0,0.75);
        }

        .r3_counter_box {
            min-height: 57px;
            background: #ffffff;
            padding: 15px;
            box-shadow: 1px 1px 5px #CCCCCC;
        }

            .r3_counter_box .fa {
                font-size: 23px;
                width: 60px;
                height: 60px;
                line-height: 60px;
            }

        .fa.pull-left {
            margin-right: 5% !important;
        }

        .r3_counter_box .fa {
            margin-right: 0px;
            font-size: 25px;
            width: 66px;
            height: 66px;
            text-align: center;
            line-height: 65px;
            -webkit-transition: 0.5s all;
            -moz-transition: 0.5s all;
            -o-transition: 0.5s all;
            -ms-transition: 0.5 sall;
            transition: 0.5s all;
        }

        .stats {
            overflow: hidden;
        }

        .r3_counter_box h5 {
            margin: 10px 0 5px 0;
            color: #000;
            font-weight: 600;
            font-size: 30px;
            font-family: calibri;
        }

        .stats span {
            color: #777;
            font-size: 16px;
        }

        .widget:hover i.fa {
            -webkit-transform: scale(1.1);
            -moz-transform: scale(1.3);
            -o-transform: scale(1.3);
            -ms-transform: scale(1.3);
            transform: scale(1.1);
            -webkit-transition: 0.5s all;
            -moz-transition: 0.5s all;
            -o-transition: 0.5s all;
            -ms-transition: 0.5 sall;
            transition: 0.5s all;
        }

        .icon-rounded {
            background-color: #7460ee;
            color: #ffffff;
            border-radius: 50px;
            -webkit-border-radius: 50px;
            -moz-border-radius: 50px;
            -o-border-radius: 50px;
            -ms-border-radius: 50px;
            font-size: 25px;
        }

        .green-bg {
            background-color: #3aaa94;
        }

        .magenta-bg {
            background-color: #b60576;
        }

        .rose-bg {
            background: #fc4b6c;
        }


        .market-update-block.clr-block-1 {
            background: #FFFFFF;
            /*    margin-right: 0.8em;*/
            box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
            transition: 0.5s all;
            -webkit-transition: 0.5s all;
            -moz-transition: 0.5s all;
            -o-transition: 0.5s all;
        }

        .market-update-block {
            padding: 11px;
            background: #999;
            height: 60px;
            overflow: hidden;
        }

        .market-update-left {
            padding: 0px;
        }

        .market-update-block h3 {
            color: #333;
            font-size: 23px;
            font-family: 'Carrois Gothic', sans-serif;
        }

        .market-update-block h4 {
            font-size: 10px;
            color: #828080;
            margin: 0.3em 0em;
            font-family: 'Carrois Gothic', sans-serif;
        }

        .market-update-block p {
            color: #fff;
            font-size: 0.8em;
            line-height: 1.8em;
        }

        .market-update-right i.fa.fa-male-text-o {
            font-size: 26px;
            color: #68AE00;
            width: 43px;
            height: 44px;
            background: #fff;
            text-align: center;
            border-radius: 49px;
            -webkit-border-radius: 49px;
            -moz-border-radius: 49px;
            -o-border-radius: 49px;
            line-height: 1.7em;
        }

        .market-update-block.clr-block-2 {
            background: #FFFFFF;
            /*margin-right: 0.8em;*/
            box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
            transition: 0.5s all;
            -webkit-transition: 0.5s all;
            -moz-transition: 0.5s all;
            -o-transition: 0.5s all;
        }

        .market-update-right i.fa.fa-eye {
            font-size: 26px;
            color: #FC8213;
            width: 44px;
            height: 44px;
            background: #fff;
            text-align: center;
            border-radius: 49px;
            -webkit-border-radius: 49px;
            -moz-border-radius: 49px;
            -o-border-radius: 49px;
            line-height: 1.7em;
        }

        .market-update-block.clr-block-3 {
            background: #FFFFFF;
            box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
            transition: 0.5s all;
            -webkit-transition: 0.5s all;
            -moz-transition: 0.5s all;
            -o-transition: 0.5s all;
        }

        .market-update-block.clr-block-4 {
            background-color: #FFFFFF;
            box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
            transition: 0.5s all;
            -webkit-transition: 0.5s all;
            -moz-transition: 0.5s all;
            -o-transition: 0.5s all;
        }

        .market-update-block.clr-block-5 {
            background-color: #FFFFFF;
            box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
            transition: 0.5s all;
            -webkit-transition: 0.5s all;
            -moz-transition: 0.5s all;
            -o-transition: 0.5s all;
        }

        .market-update-right i.fa.fa-envelope-o {
            font-size: 26px;
            color: #337AB7;
            width: 44px;
            height: 44px;
            background: #fff;
            text-align: center;
            border-radius: 49px;
            -webkit-border-radius: 49px;
            -moz-border-radius: 49px;
            -o-border-radius: 49px;
            line-height: 1.7em;
        }

        .market-update-block.clr-block-2:hover {
            background: #f3f3f3;
            transition: 0.5s all;
            -webkit-transition: 0.5s all;
            -moz-transition: 0.5s all;
            -o-transition: 0.5s all;
        }

        .market-update-block.clr-block-1:hover {
            background: #f3f3f3;
            transition: 0.5s all;
            -webkit-transition: 0.5s all;
            -moz-transition: 0.5s all;
            -o-transition: 0.5s all;
        }

        .market-update-block.clr-block-3:hover {
            background: #f3f3f3;
            transition: 0.5s all;
            -webkit-transition: 0.5s all;
            -moz-transition: 0.5s all;
            -o-transition: 0.5s all;
        }

        .market-update-block.clr-block-4:hover {
            background: #f3f3f3;
            transition: 0.5s all;
            -webkit-transition: 0.5s all;
            -moz-transition: 0.5s all;
            -o-transition: 0.5s all;
        }

        .market-update-block.clr-block-5:hover {
            background: #f3f3f3;
            transition: 0.5s all;
            -webkit-transition: 0.5s all;
            -moz-transition: 0.5s all;
            -o-transition: 0.5s all;
        }

        .contentarea {
            width: 100%;
            background: #fafafa;
            display: inline-block;
        }

        .mar-lef-div {
            width: 48%;
            margin-left: 2%;
        }
        
               #cphMain_divEmpPerformance {
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
            max-height: 600px;
            overflow: auto;
        }

            #cphMain_divEmpPerformance > table > tr {
                border-bottom: 1px solid #999;
            }

            #cphMain_divEmpPerformance td, #cphMain_divEmpPerformance th {
                padding: 12px;
                font-size: 13px;
                font-weight: lighter;
            }

            #cphMain_divEmpPerformance tr {
                border-bottom: 1px solid #999;
            }

                #cphMain_divEmpPerformance tr:nth-child(even) {
                    background-color: #f2f2f2;
                }

                #cphMain_divEmpPerformance tr:hover {
                    background-color: #ddd;
                }

            #cphMain_divEmpPerformance th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #FFF;
                color: #999;
                font-size: 15px;
                text-align: center;
            }

            
       .card-01  {   
 position: relative;
background-color: #fff;
transition: box-shadow .25s;
border-radius: 2px;
box-shadow: 0 6px 5px 0 rgba(0,0,0,0.16), 0 2px 10px 0 rgba(0,0,0,0.12);
z-index: 99;
cursor: pointer;
min-width: 294px;
height: 53px;
}
.card-01 {
    overflow: hidden;
}
.card-01 .card-content { 
    padding:7px;
    border-radius: 0 0 2px 2px;
}

.white-text {
       color: #fff !important;
    font-family: calibri;
    font-size: 15px;
}
.light-blue {
    background-color:#673ab7 !important;
}
.light-blue:hover
{ background-color:#8f5ee6  !important;}
.numberCircle {
background: #fefefe;
border-radius: 1.8em;
color: #673ab7;
display: inline-block;
font-weight: bold;
line-height: 2.7em;
margin-right: 5px;
text-align: center;
width: 2.7em;
}
@keyframes flickerAnimation {
  0%   { opacity:1; }
  50%  { opacity:0; }
  100% { opacity:1; }
}
@-o-keyframes flickerAnimation{
  0%   { opacity:1; }
  50%  { opacity:0; }
  100% { opacity:1; }
}
@-moz-keyframes flickerAnimation{
  0%   { opacity:1; }
  50%  { opacity:0; }
  100% { opacity:1; }
}
@-webkit-keyframes flickerAnimation{
  0%   { opacity:1; }
  50%  { opacity:0; }
  100% { opacity:1; }
}
.animate-flicker {
   -webkit-animation: flickerAnimation 1s infinite;
   -moz-animation: flickerAnimation 1s infinite;
   -o-animation: flickerAnimation 1s infinite;
    animation: flickerAnimation 1s infinite;
}
        @media (max-width: 1366px) {
            .r3_counter_box .fa {
                font-size: 23px;
                width: 60px;
                height: 60px;
                line-height: 60px;
            }
        }

        @media (max-width:991px) {
            .widget {
                width: auto;
                -webkit-transition: 0.5s all;
                -moz-transition: 0.5s all;
                -o-transition: 0.5s all;
                -ms-transition: 0.5 sall;
                transition: 0.5s all;
            }

            .col-md-3.widget-01.widget1 {
                width: auto;
            }
        }

        @media (max-width:767px) {
            .flot-left {
                float: right;
                text-align: right;
            }
        }

        @media (max-width:766px) {
            .col-md-4.widget {
                width: 100%;
            }
        }
    </style>
    <script src="../../JavaScript/Hcm_DashBoard/js/plugins/morris/morris.min.js"></script>
    <script src="../../JavaScript/Hcm_DashBoard/js/plugins/morris/raphael.min.js"></script>
    <script>
        var $noCon = jQuery.noConflict();
        $noCon(function () {
            LoadEmployeeBarDia();
            LoadAccoData();
        });



        function ConvertToJson(dataObj) {
            var find2 = '\\"\\[';
            var re2 = new RegExp(find2, 'g');
            var res2 = dataObj.replace(re2, '\[');

            var find3 = '\\]\\"';
            var re3 = new RegExp(find3, 'g');
            var res3 = res2.replace(re3, '\]');
            var json = $noCon.parseJSON(res3);
            return json;
        }
        function LoadEmployeeBarDia() {

            var TotalData = document.getElementById("<%=hiddenEmployeeBarDiaData.ClientID%>").value;
            var TotalDataBarChart = "";
            if (TotalData != "") {
                TotalDataBarChart = ConvertToJson(TotalData);
            }
            else {
                TotalDataBarChart = [{
                    Division: '0',
                   // Alloted: 0,
                    OnLeave: 0,
                    Available: 0,
                }]
            }
            Morris.Bar({

                element: 'graph1',
                data: TotalDataBarChart,
                xkey: 'Division',
                //ykeys: ['Alloted', 'OnLeave', 'Available'],
                ykeys: [ 'OnLeave', 'Available'],
                //  labels: ['Alloted', 'On leave', 'Available'],
                labels: [ 'On leave', 'Available'],
                resize: 'true',
                barColors: ['#0095f2', '#f47920', '#09d76f'],
                hideHover: false,
                xLabelAngle: 90,
                gridTextWeight: "bold",
                legends: 'true'
            }).on('click', function (i, row) {
                console.log(i, row);
            });
        }

    </script>
    <script>
        function LoadAccoData() {
            var TotalData = document.getElementById("<%=HidddenAccodetails.ClientID%>").value;
            var SplitData = TotalData.split(',');

            Morris.Donut({
                element: 'graph',
                data: [
                  { value: SplitData[1], label: 'Filled Rooms', color: "#2c568f" },
                  { value: SplitData[2], label: ' Immediate vacate', color: "#f57a34" },
                  { value: SplitData[0], label: 'Available Rooms', color: "#09d76f" },

                ],
                formatter: function (x) { return x }
            }).on('click', function (i, row) {
                console.log(i, row);
            });
        }


        $(document).keydown(function (e) {
            // ESCAPE key pressed

            if ((e.keyCode == 27) || ($(".js-modal-close, .modal-overlay").click())) {

                $(".modal-box, .modal-overlay").fadeOut(500, function () {
                    $(".modal-overlay").remove();
                });

            }


        });

        window.onclick = function (event) {

            if (event.target == document.getElementById("modal-overlay")) {
                $(".modal-box, .modal-overlay").fadeOut(500, function () {
                    $(".modal-overlay").remove();
                });
            }
        }


        $(function () {

            var appendthis = ("<div id='modal-overlay' class='modal-overlay js-modal-close'></div>");

            $('a[data-modal-id]').click(function (e) {
                e.preventDefault();
                $("body").append(appendthis);
                $(".modal-overlay").fadeTo(500, 0.7);
                //$(".js-modalbox").fadeIn(500);
                var modalBox = $(this).attr('data-modal-id');
                $('#' + modalBox).fadeIn($(this).data());

            });


            $(".js-modal-close, .modal-overlay").click(function () {
                $(".modal-box, .modal-overlay").fadeOut(500, function () {
                    $(".modal-overlay").remove();
                });

            });

            $(window).resize(function () {
                $(".modal-box").css({
                    top: ($(window).height() - $(".modal-box").outerHeight()) / 2,
                    left: ($(window).width() - $(".modal-box").outerWidth()) / 2
                });
            });

            $(window).resize();

        });

    </script>
    <style>
        .cont_rght {
            width: 100%;
        }

        #cphMain_divEmpDepart {
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
            max-height: 600px;
            overflow: auto;
        }

            #cphMain_divEmpDepart > table > tr {
                border-bottom: 1px solid #999;
            }

            #cphMain_divEmpDepart td, #cphMain_divEmpDepart th {
                padding: 12px;
                font-size: 13px;
                font-weight: lighter;
            }

            #cphMain_divEmpDepart tr {
                border-bottom: 1px solid #999;
            }

                #cphMain_divEmpDepart tr:nth-child(even) {
                    background-color: #f2f2f2;
                }

                #cphMain_divEmpDepart tr:hover {
                    background-color: #ddd;
                }

            #cphMain_divEmpDepart th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #FFF;
                color: #999;
                font-size: 15px;
                text-align: center;
            }

            
              #cphMain_divBirthdayList {
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
            max-height: 600px;
            overflow: auto;
        }

            #cphMain_divBirthdayList > table > tr {
                border-bottom: 1px solid #999;
            }

            #cphMain_divBirthdayList td, #cphMain_divBirthdayList th {
                padding: 12px;
                font-size: 13px;
                font-weight: lighter;
            }

            #cphMain_divBirthdayList tr {
                border-bottom: 1px solid #999;
            }

                #cphMain_divBirthdayList tr:nth-child(even) {
                    background-color: #f2f2f2;
                }

                #cphMain_divBirthdayList tr:hover {
                    background-color: #ddd;
                }

            #cphMain_divBirthdayList th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #FFF;
                color: #999;
                font-size: 15px;
                text-align: center;
            }



        #cphMain_divEmpArrive {
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
            max-height: 600px;
            overflow: auto;
        }

            #cphMain_divEmpArrive > table > tr {
                border-bottom: 1px solid #999;
            }

            #cphMain_divEmpArrive td, #cphMain_divEmpArrive th {
                padding: 12px;
                font-size: 13px;
                font-weight: lighter;
            }

            #cphMain_divEmpArrive tr {
                border-bottom: 1px solid #999;
            }

                #cphMain_divEmpArrive tr:nth-child(even) {
                    background-color: #f2f2f2;
                }

                #cphMain_divEmpArrive tr:hover {
                    background-color: #ddd;
                }

            #cphMain_divEmpArrive th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #FFF;
                color: #999;
                font-size: 15px;
                text-align: center;
            }


        #cphMain_divFlightAmount {
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
            max-height: 600px;
            overflow: auto;
        }

            #cphMain_divFlightAmount > table > tr {
                border-bottom: 1px solid #999;
            }

            #cphMain_divFlightAmount td, #cphMain_divFlightAmount th {
                padding: 12px;
                font-size: 13px;
                font-weight: lighter;
            }

            #cphMain_divFlightAmount tr {
                border-bottom: 1px solid #999;
            }

                #cphMain_divFlightAmount tr:nth-child(even) {
                    background-color: #f2f2f2;
                }

                #cphMain_divFlightAmount tr:hover {
                    background-color: #ddd;
                }

            #cphMain_divFlightAmount th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #FFF;
                color: #999;
                font-size: 15px;
                text-align: center;
            }


        #cphMain_divFlightBuy {
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
            max-height: 600px;
            overflow: auto;
        }

            #cphMain_divFlightBuy > table > tr {
                border-bottom: 1px solid #999;
            }

            #cphMain_divFlightBuy td, #cphMain_divFlightBuy th {
                padding: 12px;
                font-size: 13px;
                font-weight: lighter;
            }

            #cphMain_divFlightBuy tr {
                border-bottom: 1px solid #999;
            }

                #cphMain_divFlightBuy tr:nth-child(even) {
                    background-color: #f2f2f2;
                }

                #cphMain_divFlightBuy tr:hover {
                    background-color: #ddd;
                }

            #cphMain_divFlightBuy th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #FFF;
                color: #999;
                font-size: 15px;
                text-align: center;
            }


        #cphMain_divFlightApplied {
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
            max-height: 600px;
            overflow: auto;
        }

            #cphMain_divFlightApplied > table > tr {
                border-bottom: 1px solid #999;
            }

            #cphMain_divFlightApplied td, #cphMain_divFlightApplied th {
                padding: 12px;
                font-size: 13px;
                font-weight: lighter;
            }

            #cphMain_divFlightApplied tr {
                border-bottom: 1px solid #999;
            }

                #cphMain_divFlightApplied tr:nth-child(even) {
                    background-color: #f2f2f2;
                }

                #cphMain_divFlightApplied tr:hover {
                    background-color: #ddd;
                }

            #cphMain_divFlightApplied th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #FFF;
                color: #999;
                font-size: 15px;
                text-align: center;
            }


        #cphMain_divFlyToday {
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
            max-height: 600px;
            overflow: auto;
        }

            #cphMain_divFlyToday > table > tr {
                border-bottom: 1px solid #999;
            }

            #cphMain_divFlyToday td, #cphMain_divFlyToday th {
                padding: 12px;
                font-size: 13px;
                font-weight: lighter;
            }

            #cphMain_divFlyToday tr {
                border-bottom: 1px solid #999;
            }

                #cphMain_divFlyToday tr:nth-child(even) {
                    background-color: #f2f2f2;
                }

                #cphMain_divFlyToday tr:hover {
                    background-color: #ddd;
                }

            #cphMain_divFlyToday th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #FFF;
                color: #999;
                font-size: 15px;
                text-align: center;
            }



        .menu_drop a, .menu_drop li {
            display: block;
            width: 100%;
            font-size: 14px;
            list-style: none;
        }

        .menu_drop ul {
            list-style: none;
        }

        .menu_drop {
            background: #fafafa;
            border-radius: 4px;
            box-shadow: 0 2px 4px 0 rgba(0,0,0,.16), 0 2px 8px 0 rgba(0,0,0,.12);
            color: #757575;
            font-size: 14px;
            padding: 16px 0;
            position: absolute;
            top: 48px;
            transform: scale(0);
            transition: transform .2s;
            z-index: 300;
            font-family: Verdana, Geneva, sans-serif;
            border: #28446F 1px solid;
        }

            .menu_drop li.menu-separator:hover, .menu li:hover {
            }

            .menu_drop.show {
                transform: scale(1);
            }

            .menu_drop.menu--right {
                transform-origin: top right;
            }

            .menu_drop.menu--left {
                transform-origin: top right;
            }

            .menu_drop li {
                min-height: 32px;
                line-height: 16px;
                margin: 8px 0;
                padding: 0 16px;
                list-style: none;
            }

                .menu_drop li.menu-separator {
                    background: #eee;
                    height: 1px;
                    min-height: 0;
                    margin: 12px 0;
                    padding: 0;
                }

                .menu_drop li:first-child {
                    margin-top: 0;
                }

                .menu_drop li:last-child {
                    margin-bottom: 0;
                }

            .menu_drop a {
                color: inherit;
                height: 32px;
                line-height: 32px;
                padding: 0;
                text-decoration: none;
                white-space: nowrap;
                width: 94%;
            }

                .menu_drop a:hover {
                    color: #444;
                }
    </style>

    <%-- script drop_down_notification --%>

      <link rel="shortcut icon" href="/css/Login/image/short-icon.png"/>
    <script src="/JavaScript/droplist_plugin/menu.min.js"></script>
    <script src="/JavaScript/Popup/pignose.popup.js"></script>
    <link href="/css/plugins/pignose.popup.css" rel="stylesheet" />
    <script>
        var $NoConfi = jQuery.noConflict();
        $NoConfi('[data-menu]').menu();

    </script>

    <script>

        var $NoConfi2 = jQuery.noConflict();
        $NoConfi(function () {
            var row = document.getElementById("<%=Hiddenrowcount.ClientID%>").value;

            for (i = 1; i <= row; i++) {

                $NoConfi('#Notificbutton' + i).bind('click', function (event) {
                    //   alert('#Notificbutton' + i+"inside");
                    event.preventDefault();
                    $NoConfi2('#pg-following').pignosePopup({
                        scroll: true
                    });

                });
            }
            //To Check Others conduct To Show
          
            var OthersConduct = document.getElementById("<%=HiddenToCheckOthersConduct.ClientID%>").value;
           
          
            if (OthersConduct == "1") {
                $(".col-md-4.widget").css('width', 16.46+"%");
            }
            else {
             
                $(".col-md-4.widget").css('width', 19.80+"%");
            }

        });

        function getusernotifications(userid) {
            var $NoConfi2 = jQuery.noConflict();
            //alert(userid);
            var loginuser = document.getElementById("<%=HiddenLoginUserId.ClientID%>").value;
            $NoConfi2.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "/MasterPage/WebServiceMaster.asmx/GetEmployeeCount",
                data: '{userid: "' + userid + '",LoginId: "' + loginuser + '"}',
                dataType: "json",
                success: function (response) {
                    var details = response.d;
                    document.getElementById("<%=divhandovernotifc.ClientID%>").innerHTML = response.d;

                }
            });


        }


        function ValidateProcessSinglehcmMastr() {

            getdata();

            var ret = true;




            return ret;
        }
        function getdata() {
            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];
            var rowCount = $NoConfi('#ReportTablehandover tr').length - 1;
            for (var x = 0; x < rowCount; x++) {


                var Decsn = document.getElementById("ddlDecision" + x).value;
                //alert(Decsn);
                var Comments = document.getElementById("txtComments" + x).value;


                var tableid = document.getElementById("tdid" + x).innerHTML;
                var $add = jQuery.noConflict();
                var client = JSON.stringify({
                    DECSNID: "" + Decsn + "",
                    COMNTS: "" + Comments + "",
                    TBLID: "" + tableid + ""
                });
                //   alert(client);
                tbClientJobSheduling.push(client);
                //}
            }
            document.getElementById("<%=hiddenjsondtails.ClientID%>").value = JSON.stringify(tbClientJobSheduling);
            $add("#cphMain_hiddenjsondtails").val(JSON.stringify(tbClientJobSheduling));
           
        }
        function CloseModal() {

            if (confirm("Are you sure you want to cancel?")) {
                document.getElementById('pg-following').style.display = "none";
                return true;
            }
            else {
                return false;
            }
        }
    </script>

    <style>
        #ReportTablehandover tr td {
            border: #e1e1e1 .5px solid;
        }

        .pignose-popup {
            height: 400px;
        }

        .main_table_head1 {
            width: 100%;
            border: 1px solid #9ba48b;
            border-top-color: rgb(155, 164, 139);
            border-right-color: rgb(155, 164, 139);
            border-bottom-color: rgb(155, 164, 139);
            border-left-color: rgb(155, 164, 139);
            background-color: #99ca3c;
            background-color: rgb(155, 164, 139);
            color: #fff;
            font-size: 13px;
            text-align: left;
            height: 36px;
        }

        #ReportTablehandover th {
            background-color: #99ca3c;
            border-color: #c9c9c9;
        }

        #ReportTablehandover_length select {
            width: 50px;
            font-weight: bold;
            font-family: calibri;
            color: #336B16;
            font-size: 14px;
        }

        #ReportTablehandover_length {
            font-family: Calibri;
            font-weight: bold;
            font-size: 14px;
            padding-bottom: 0.7%;
        }

        #ReportTablehandover_filter input {
            height: 23px;
            width: 200px;
            color: #336B16;
            font-size: 14px;
        }

        #ReportTablehandover_filter {
            font-family: Calibri;
            font-weight: bold;
            font-size: 14px;
        }

        #ReportTablehandover_paginate {
            font-family: Calibri;
            font-size: 13px;
        }

        #ReportTablehandover_info {
            font-family: Calibri;
            font-weight: 600;
            font-size: 14px;
        }
        .menu_drop a, .menu_drop li {
            display: block;
            width: 100%;
            font-size: 14px;
            list-style: none;
        }

        .menu_drop ul {
            list-style: none;
        }

        .menu_drop {
            background: #fafafa;
            border-radius: 4px;
            box-shadow: 0 2px 4px 0 rgba(0,0,0,.16), 0 2px 8px 0 rgba(0,0,0,.12);
            color: #757575;
            font-size: 14px;
            padding: 16px 0;
            position: absolute;
            top: 48px;
            transform: scale(0);
            transition: transform .2s;
            z-index: 300;
            font-family: Verdana, Geneva, sans-serif;
            border: #28446F 1px solid;
        }

            .menu_drop li.menu-separator:hover, .menu li:hover {
            }

            .menu_drop.show {
                transform: scale(1);
            }

            .menu_drop.menu--right {
                transform-origin: top right;
            }

            .menu_drop.menu--left {
                transform-origin: top right;
            }

            .menu_drop li {
                min-height: 32px;
                line-height: 16px;
                margin: 8px 0;
                padding: 0 16px;
                list-style: none;
            }

                .menu_drop li.menu-separator {
                    background: #eee;
                    height: 1px;
                    min-height: 0;
                    margin: 12px 0;
                    padding: 0;
                }

                .menu_drop li:first-child {
                    margin-top: 0;
                }

                .menu_drop li:last-child {
                    margin-bottom: 0;
                }

            .menu_drop a {
                color: inherit;
                height: 32px;
                line-height: 32px;
                padding: 0;
                text-decoration: none;
                white-space: nowrap;
                width: 94%;
            }

                .menu_drop a:hover {
                    color: #444;
                }

                .btn {
    border-radius: 3px;
    -webkit-box-shadow: none;
    box-shadow: none;
    border: 1px solid #240a0a00;
    background-color: #bfaaaa;
    cursor: pointer;
}
    
    </style>

    <style>
        tbody {
            display:block;
 overflow:auto;
 max-height:200px;
}
thead, tbody tr {
    display:table;
    width:100%;
    table-layout:fixed;/* even columns width , fix width of table too*/
}

thead {
    width: calc( 100% - 1em )/* scrollbar is average 1em/16px width, remove it from thead width */
}
        .table {
            margin-bottom: 8px;
        }
        .modal-box {
   
    top: 100px !important;
}
        .btn {
    border-radius: 3px;
    -webkit-box-shadow: none;
    box-shadow: none;
    border: 3px solid #c5bbbb00;
    background-color: #bbb1bf;
    cursor: pointer;
}

        /*.col-md-4.widget {
    width: 19.8%;

}*/

    </style>
</asp:Content>

