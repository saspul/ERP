<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Sales.master" AutoEventWireup="true" CodeFile="Compzit_Home_Sales_Executive.aspx.cs" Inherits="Home_Compzit_Home_Compzit_Home_Sales_Executive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <style>
        .cont_rght {
            width: 100%;
        }
        .line-graph-container {
	box-sizing: border-box;
	
	padding: 20px 15px 15px 15px;
	border: 1px solid #ddd;
	background: #fff;
	background: linear-gradient(#f6f6f6 0, #fff 50px);
	background: -o-linear-gradient(#f6f6f6 0, #fff 50px);
	background: -ms-linear-gradient(#f6f6f6 0, #fff 50px);
	background: -moz-linear-gradient(#f6f6f6 0, #fff 50px);
	background: -webkit-linear-gradient(#f6f6f6 0, #fff 50px);
	box-shadow: 0 3px 10px rgba(0,0,0,0.15);
	-o-box-shadow: 0 3px 10px rgba(0,0,0,0.1);
	-ms-box-shadow: 0 3px 10px rgba(0,0,0,0.1);
	-moz-box-shadow: 0 3px 10px rgba(0,0,0,0.1);
	-webkit-box-shadow: 0 3px 10px rgba(0,0,0,0.1);
}
        .graph-h1 {
        font-family: Calibri;
font-size: 15px;
font-weight: lighter;
color: #67764b;
text-transform: uppercase;
        }

.line-graph-placeholder {
	width: 100%;
	height: 100%;
	font-size: 13px;
	line-height: 1.2em;
     font-family: Calibri;
     text-transform: uppercase;
}
.GraphColorsBoxes{
  
  width: 20px;
  height: 20px;
  margin: 5px;
  border: 1px solid rgba(0, 0, 0, .2);
}
.chart-legend {
  width:99%;
    margin: 5px auto; 
    font-size: 13px;
	line-height: 1.2em;
     font-family: Calibri;
     text-transform: uppercase;
}
    </style>
    <%--<link href="../../css/LineGraph/LineGraph.css" rel="stylesheet" />--%>
    
    <%--<link href="../LineGraph.css" rel="stylesheet" type="text/css">
	<!--[if lte IE 8]><script language="javascript" type="text/javascript" src="../../excanvas.min.js"></script><![endif]-->
	<script language="javascript" type="text/javascript" src="../../jquery.js"></script>
	<script language="javascript" type="text/javascript" src="../../jquery.flot.js"></script>
	<script language="javascript" type="text/javascript" src="../../jquery.flot.categories.js"></script>--%>
<%--<link href="../../css/LineGraph/LineGraph.css" rel="stylesheet" />--%>
<script src="../../JavaScript/LineGraph/jquery.js"></script>
<script src="../../JavaScript/LineGraph/jquery.flot.js"></script>
<script src="../../JavaScript/LineGraph/jquery.flot.categories.js"></script>
    <script src="../../JavaScript/LineGraph/jquery.flot.orderBars.js"></script>
    <script src="../../JavaScript/jquery-1.8.3.min.js"></script>
    
	<script type="text/javascript">
	   var $noCon = jQuery.noConflict();
	   $(function () {
	       var month = new Array();
	       month[1] = "Jan";
	       month[2] = "Feb";
	       month[3] = "Mar";
	       month[4] = "Apr";
	       month[5] = "May";
	       month[6] = "Jun";
	       month[7] = "Jul";
	       month[8] = "Aug";
	       month[9] = "Sep";
	       month[10] = "Oct";
	       month[11] = "Nov";
	       month[12] = "Dec";

	       data=document.getElementById("<%=hiddenLeadWonMonthly.ClientID%>").value;
	       res = data.split(",");
	       var arrayGraph = [];
	       for (var i = 1; i < res.length; i++) {
	           arrayGraph.push([month[i], res[i]]);
	          
	       }
	         //data = [ ["Apr", 13], ["May", 17], ["Jun", 9], ["Jul", 9], ["Aug", 9], ["Sept", 9], ["Oct", 0], ["Nov",0], ["Dec", 0]];
	       $.plot($("#placeholder"), [arrayGraph], {
	            series: {
	                lines: {
	                    show: true,
	                    //fill: true,
	                    //fillColor: { colors: [{ opacity: 0.7 }, { opacity: 0.1 }] }
	                },
	                points: {
	                    show: true
	                }
	                
	               

	            },
	            grid: {
	                hoverable: true,
	                clickable: true
	            },


	            xaxis: {
	                mode: "categories",
	                //tickLength: 0

	            },
	           //
	            
	          
	            colors: ["#4cd8ff", "#0022FF"]

	        }); 
	       //divGraphAmtMonthly
	       BookedAmtdata = document.getElementById("<%=hiddenBookedAmtMonthly.ClientID%>").value;
	       resBookedAmtdata = BookedAmtdata.split(",");
	       var GraphAmtMonthly = [];
	       for (var i = 1; i < resBookedAmtdata.length; i++) {
	           GraphAmtMonthly.push([month[i], resBookedAmtdata[i]]);

	       }
	       $.plot($("#divGraphAmtMonthly"), [GraphAmtMonthly], {
	           series: {
	               lines: {
	                   show: true
	               },
	               points: {
	                   show: true
	               }

	           },
	           grid: {
	               hoverable: true,
	               clickable: true
	           },


	           xaxis: {
	               mode: "categories",
	               //tickLength: 0
	           }
	          

	       });
	        $("<div id='tooltip'></div>").css({
	            position: "absolute",
	            display: "none",
	            border: "1px solid #fdd",
	            padding: "2px",
	            "background-color": "#fee",
	            opacity: 0.80
	        }).appendTo("body");

	        $("#placeholder").bind("plothover", function (event, pos, item) {



	            //this is show tooltip
	            if (item) {
	                var x = item.datapoint[0].toFixed(2),
						y = item.datapoint[1].toFixed(2);

	                $("#tooltip").html(y)
						.css({ top: item.pageY + 5, left: item.pageX + 5 })
						.fadeIn(200);
	            } else {
	                $("#tooltip").hide();
	            }

	        });
	        $("#divGraphAmtMonthly").bind("plothover", function (event, pos, item) {



	            //this is show tooltip
	            if (item) {
	                var x = item.datapoint[0].toFixed(2),
						y = item.datapoint[1].toFixed(2);

	                $("#tooltip").html(y)
						.css({ top: item.pageY + 5, left: item.pageX + 5 })
						.fadeIn(200);
	            } else {
	                $("#tooltip").hide();
	            }

	        });



	        // Add the Flot version string to the footer


	    });

	</script>
    
      
	<script type="text/javascript">
	    var $noCon = jQuery.noConflict();
	    
	    $(function () {
	        //hiddenTotalConvertedLead
	        TotalCnvrtdLeads = document.getElementById("<%=hiddenTotalConvertedLead.ClientID%>").value;
	        resTotalCnvrtdLeads = TotalCnvrtdLeads.split(",");
	        var DataTotalCnvrtdLeads = [];
	        for (var i = 1; i < resTotalCnvrtdLeads.length; i++) {
	            DataTotalCnvrtdLeads.push([i, resTotalCnvrtdLeads[i]]);

	        }

	        TotalLeads = document.getElementById("<%=hiddenTotalLead.ClientID%>").value;
	        resTotalLeads = TotalLeads.split(",");
	        var DataTotalLeads = [];
	        for (var i = 1; i < resTotalLeads.length; i++) {
	            DataTotalLeads.push([i, resTotalLeads[i]]);

	        }
	        //hiddenAvgLeads
	        AvgLeads = document.getElementById("<%=hiddenAvgLeads.ClientID%>").value;
	        resAvgLeads = AvgLeads.split(",");
	        var DataAvgLeads = [];
	        for (var i = 1; i < resAvgLeads.length; i++) {
	            DataAvgLeads.push([i, resAvgLeads[i]]);

	        }

	        var data = [["0", 0], ["1", 10], ["2", 0], ["3", 10], ["6", 20], ["7", 20], ["8", 20], ["9", 20], ["10", 20], ["11", 15]];
	        //var data2 = [["0", 0], ["1", 10], ["2", 11], ["3", 12], ["4", 13], ["5", 14], ["6", 15], ["7", 16], ["8", 20], ["9", 20], ["10", 20], ["11", 15]];

	        $.plot("#divGraphDivMgr", [{
	            label: "Converted to Opportunty", color: '#127be5', backgroundOpacity: 0,
	            data: DataTotalCnvrtdLeads,
	            //data: data,

	            bars: {
	                show: true,
	                
	              
	                lineWidth: 0,
	                order: 1,
	                barWidth: 0.09,
	                fill: 1,
	                align: "center",
	                
	            }

	        }, {
	            label: "Total Opportunity", color: '#97C83A', backgroundOpacity: 0,
	            data: DataTotalLeads,
	            //data: data2,
	            bars: {
	                show: true,
	              
	                lineWidth: 0,
	                order: 2,
	                barWidth: 0.09,
	                fill: 1,
	                align: "center",
	                
	            }

	        }, {
	            label: "Avg. Opportunity", color: '#f26522', backgroundOpacity: 0,
	            data: DataAvgLeads,
	            //data: data,
	            lines: {
	                show: true
	            },
	            points: {
	            show: true
	        }
	            //bars: {
	            //    show: true,

	            //    lineWidth: 0,
	            //    order: 2,
	            //    barWidth: 0.09,
	            //    fill: 1,
	            //    align: "center",

	            //}

	        }], {
	            //series: {
	            //    bars: {
	            //        show: true,
	            //        barWidth: 0.09,
	            //        fill:1,
	            //        align: "center",
	            //        //order: 1
	            //    }
	            //},
	            xaxis: {
	                mode: "categories",
	                ticks: [
                        [0, "Jan"],
                        [1, "Feb"],
                        [2, "Mar"],
                        [3, "Apr"],
                        [4, "May"],
                        [5, "Jun"],
                        [6, "Jul"],
                        [7, "Aug"],
                        [8, "Sept"],
                        [9, "Oct"],
                        [10, "Nov"],
                        [11, "Dec"],
	                ],
	                tickLength: 0,

	            },
	            legend: {
	                show: true,
	                noColumns: 3,
	                container: "#bar-legend"
	            },

	            grid: {
	                hoverable: true,
	                clickable: true
	            },
	            yAxis: {
	                allowDecimals: false,
	            }

	        });
	        // colors: ["#1c65db", "#94db1c"]
	        $("<div id='tooltip'></div>").css({
	            position: "absolute",
	            display: "none",
	            border: "1px solid #fdd",
	            padding: "2px",
	            "background-color": "#fee",
	            opacity: 0.80
	        }).appendTo("body");

	        $("#divGraphDivMgr").bind("plothover", function (event, pos, item) {



	            //this is show tooltip
	            if (item) {
	                var x = item.datapoint[0].toFixed(2),
						y = item.datapoint[1].toFixed(2);

	                $("#tooltip").html(y)
						.css({ top: item.pageY + 5, left: item.pageX + 5 })
						.fadeIn(200);
	            } else {
	                $("#tooltip").hide();
	            }

	        });
	        $("#divGraphAmtMonthly").bind("plothover", function (event, pos, item) {



	            //this is show tooltip
	            if (item) {
	                var x = item.datapoint[0].toFixed(2),
						y = item.datapoint[1].toFixed(2);

	                $("#tooltip").html(y)
						.css({ top: item.pageY + 5, left: item.pageX + 5 })
						.fadeIn(200);
	            } else {
	                $("#tooltip").hide();
	            }

	        });
	     
	    });
    </script>
    <script>
        function getdetailsMnthConvertedLead() {
            //Leads won
            window.location = "/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=MCNVRTD";
            return false;
        }
        function getdetailsMnthJunkLead() {
            window.location = "/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=MJUNK";
            return false;
        }
        //MOPEND
        function getdetailsMnthOpenLead() {
            window.location = "/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=MOPEND";
            return false;
        }
        //"TCNVRTD" || strLeadListMode == "TJUNK" || strLeadListMode == "TONOLD")
        function getdetailsTotalWonLead() {
            window.location = "/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=TCNVRTD";
            return false;
        }
        function getdetailsTotalLostLead() {
            window.location = "/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=TJUNK";
            return false;
        }
        function getdetailsTotalLeads() {
            window.location = "/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=TONOLD";
            return false;
        }
        
        
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    
   <asp:HiddenField runat="server" ID="hiddenLeadWonMonthly" />
   <asp:HiddenField runat="server" ID="hiddenBookedAmtMonthly" />
   
   <asp:HiddenField runat="server" ID="hiddenDfltCurrencyMstrId" />
   <asp:HiddenField runat="server" ID="hiddenTotalConvertedLead" />
   <asp:HiddenField runat="server" ID="hiddenTotalLead" />
   <asp:HiddenField runat="server" ID="hiddenAvgLeads" />
   <asp:HiddenField runat="server" ID="hiddenCurrencyAbbr" />

    

    <div class="contentarea">
    	<div class="auto1" style="width: 100%;">
        	
            <div class="cont_rght" style="width:100%">
                
                <div class="black_border" id="divSalesExec" runat="server" >
            <a href="/Transaction/gen_Lead/gen_LeadList.aspx">
                <img src="../../Images/Other Images/leads_more.gif" style="margin-right: 1%;float: right;margin-bottom: 1%;" /></a>
            <div style="clear: both"></div>
                    <div class="dash-sect-1" style="width: 49%;margin-right: 1%;display:none">
                        <div class="col-xs-12 col-sm-4 sbg p11 padding-10" >
                            <div class=" square_bg_1" style="min-height: 127px;">
                            <img src="/../Images/Design_Images/images/dash-icon-1.png" class="img-responsive">
                            <P>Bookings this month</P> 
                            </div>                
                            <div class="sq_btm_1" id="divBookingsMonthly" runat="server">
                                <p>QAR 100,000.00</p>
                            </div>
                        </div>
    
                        <div class="col-xs-12 col-sm-4 sbg p11 padding-10" >
                            <div class="square_bg_2" style="min-height: 127px;">
                            <img src="/../Images/Design_Images/images/dash-icon-2.png" class="img-responsive">
                            <p>total Booking</p>
                            </div>
                            <div class="sq_btm_2" id="divTotalBookings" runat="server">
                            <p>QAR 250,000.00</p>
                            </div>
                        </div>
    
                        <div class="col-xs-12 col-sm-4 sbg p11 padding-10">
                            <div class=" square_bg_3" style="min-height: 127px;">
                            <img src="/../Images/Design_Images/images/dash-icon-3.png" class="img-responsive">
                            <P>total number of opportunity in pipeline </P>
                            </div>
                            <div class="sq_btm_3" id="divLeadsInPipeLine" runat="server">
                                <p>25</p>
                            </div>
                        </div>
    
                        
    
    
                    </div>
                    
                    <div class="dash-sect-2" style="width: 49%;">
                        <div class="col-xs-12 col-sm-3 sbg p11  padding-10" onclick="getdetailsMnthOpenLead();" style="cursor:pointer" >
                            <div class=" square_bg_4" style="min-height: 162px;">
                            <img src="/../Images/Design_Images/images/dash-icon-4.png"   class="img-responsive">
                            <P>Number of opportunity opened <br />this month</P>            
                            <div class="hr_top" id="divLeadsOpenedMonthly" runat="server"> <!-- if a very long number comes you may adjust the width of this class -->
                                <p>10</p>
                            </div> 
                            </div>                
                        </div>
                
                        <div class="col-xs-12 col-sm-3 sbg p11 padding-10" onclick="getdetailsMnthConvertedLead();" style="cursor:pointer" >
                            <div class="square_bg_5" style="min-height: 162px;">
                            <img src="/../Images/Design_Images/images/dash-icon-5.png" class="img-responsive">
                            <p>Number of opportunity won<br />this month</p>        
                            <div class="hr_top" id="divLeadswonMonthly" runat="server">
                                <p></p>
                            </div> 
                            </div>
                        </div>
    
                        <div class="col-xs-12 col-sm-3 sbg p11 padding-10" onclick="getdetailsMnthJunkLead();" style="cursor:pointer" >
                            <div class=" square_bg_6" style="min-height: 162px;">
                            <img src="/../Images/Design_Images/images/dash-icon-6.png" class="img-responsive">
                            <P>Number of opportunity lost<br />this month</P>        
                            <div class="hr_top" id="divLeadsLostMonthly" runat="server">
                                <p>8</p>
                            </div> 
                            </div>
                        </div>
    
                        <div class="col-xs-12 col-sm-3 sbg p11 padding-10">
                            <div class=" square_bg_7" style="min-height: 162px;">
                            <img src="/../Images/Design_Images/images/dash-icon-7.png" class="img-responsive">
                            <P>rate of success for<br />this month</P>        
                            <div class="hr_top" id="divSucccesCountMonthly" runat="server">
                                <p>20%</p>
                            </div> 
                            </div>
                        </div>
                    </div>
                    
                      <div class="dash-sect-4" style="margin-left: 1%;width: 49%;">
                        <div class="col-xs-12 col-sm-3 sbg p10 padding-10"   onclick="getdetailsTotalLeads();" style="cursor:pointer">
                            <div class=" square_bg_8">
                            <img src="/../Images/Design_Images/images/dash-icon-8.png" class="img-responsive">
                            <P class="ph2">Total Number of opportunity</P>            
                            <div class="hr_top2" id="divTotalNoLeads" runat="server"> 
                                <p>10</p>
                            </div> 
                            </div>                
                        </div>
    
                        <div class="col-xs-12 col-sm-3 sbg p10 padding-10" onclick="getdetailsTotalWonLead();" style="cursor:pointer">
                            <div class="square_bg_9">
                            <img src="/../Images/Design_Images/images/dash-icon-9.png" class="img-responsive">
                            <p class="ph2">total Number of opportunity won</p>        
                            <div class="hr_top2" id="divLeadsWon" runat="server">
                                <p>2</p>
                            </div> 
                            </div>
                        </div>
    
                        <div class="col-xs-12 col-sm-3 sbg p10 padding-10" onclick="getdetailsTotalLostLead();" style="cursor:pointer">
                            <div class=" square_bg_10">
                            <img src="/../Images/Design_Images/images/dash-icon-10.png" class="img-responsive">
                            <P class="ph2">Total Number of opportunity lost</P>        
                            <div class="hr_top2" id="divLeadsLost" runat="server">
                                <p>8</p>
                            </div> 
                            </div>
                        </div>
    
                        <div class="col-xs-12 col-sm-3 sbg p10 padding-10">
                            <div class=" square_bg_11">
                            <img src="/../Images/Design_Images/images/dash-icon-11.png" class="img-responsive">
                            <P class="ph2">rate of success </P>        
                            <div class="hr_top2" id="divSucccesCount" runat="server">
                                <p>20%</p>
                            </div> 
                            </div>
                        </div>
                    </div>
                    <div class="dash-sect-3 bordergrey" style="margin-right: 1%;margin-top: 1%;min-height: 263px;width: 49%;">

                        <div class="col-xs-12 col-sm-6 padding-10">
                           <h1 class="graph-h1">NO OF OPPORTUNITY WON</h1>
                          <div id="placeholder" class="line-graph-placeholder" style="width: 100%;height:150px"></div>
                            <%--<img src="/../Images/Design_Images/images/graph-1.jpg" class="img-responsive">--%>    
                        </div>
    
                        <div class="col-xs-12 col-sm-6 padding-10" >
                           <h1 class="graph-h1" >AMOUNT BOOKED</h1>
                            <%--<img src="/../Images/Design_Images/images/graph-2.jpg" class="img-responsive">--%>
                            <div id="divGraphAmtMonthly" class="line-graph-placeholder" style="width: 100%;height:150px"></div>
                        </div>
                    </div>
                     <div class="col-xs-12 col-sm-4 padding-10" style="width: 42%;margin-top: 1%;">
                             <h1 class="graph-h1" >Opportunity conversion trend</h1>
                         <div id="divGraphDivMgr" class="line-graph-placeholder" style="width:585px;height:200px; "></div>
                            <div id="bar-legend" class="chart-legend"></div>
                            
                          
						</div>

                    
                </div>
                
                
                <div class="black_border" id="divDivisionMgr" runat="server" style="">
                
                        <div class="col-xs-12 col-sm-8  padding-0">
                        
                        <div class="col-xs-12 col-sm-4 padding-10" id="divMonthlyWonLeads" style="display:none" runat="server">
                            <div >

                            </div>
                <table cellpadding="0" cellspacing="0" class="table table-striped">
                	<thead>
                      <tr> 
                        <th colspan="3" >Top Deals</th>
                      </tr>
                      </thead>
                      <tbody>
                      <tr>
                        <th colspan="3" class="tbl">open deals current month</th>
                      </tr>
                      <tr >
                        <td  class="tbl2">opportunity name</td>
                        <td  class="tbl3">sum of amount</td>
                      </tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="tbl5">QAR 150,000,00</td>
                      <tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="tbl5">QAR 150,000,00</td>
                      </tr>
                      <tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="tbl5">QAR 150,000,00</td>
                      </tr>
                     </tbody> 
                  </table>
                
                        </div>
                <div class="col-xs-12 col-sm-4 padding-10" id="divMonthlyOpenLeads" style="display:none" runat="server">
                                            <div >

                            </div>
                <table cellpadding="0" cellspacing="0" class="table table-striped">
                	<thead><tr><th colspan="3" >Top Deals</th></tr></thead>
                      <tbody>
                      <tr><th colspan="3" class="tbl">open deals current month</th></tr>
                      <tr >
                        <td  class="tbl2">opportunity name</td>
                        <td  class="tbl3">sum of amount</td>
                      </tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="tbl5">QAR 150,000,00</td>
                      <tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="tbl5">QAR 150,000,00</td>
                      </tr>
                      <tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="tbl5">QAR 150,000,00</td>
                      </tr>
                     </tbody> 
                  </table>
                
                        </div>
                        
                        <div class="col-xs-12 col-sm-4 padding-10" id="divMonthlyClosedLeads" style="display:none" runat="server">
                 <div >

                            </div>
                <table cellpadding="0" cellspacing="0" class="table table-striped">
                	<thead>
                      <tr> 
                        <th colspan="3" >Top Deals</th>
                      </tr>
                      </thead>
                      <tbody>
                      <tr>
                        <th colspan="3" class="tbl">open deals current month</th>
                      </tr>
                      <tr >
                        <td  class="tbl2">opportunity name</td>
                        <td  class="tbl3">sum of amount</td>
                      </tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="tbl5">QAR 150,000,00</td>
                      <tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="tbl5">QAR 150,000,00</td>
                      </tr>
                      <tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="tbl5">QAR 150,000,00</td>
                      </tr>
                     </tbody> 
                  </table>
                
                        </div>
                        
                        <div class="col-xs-12 col-sm-4 padding-10" id="divMonthlyLostLeads" style="width: 37%;" runat="server">
                
                <table cellpadding="0" cellspacing="0" class="table table-striped">
                	<thead>
                      <tr> 
                        <th colspan="3" >Top Deals</th>
                      </tr>
                      </thead>
                      <tbody>
                      <tr>
                        <th colspan="3" class="tbl">open deals current month</th>
                      </tr>
                      <tr >
                        <td  class="tbl2">opportunity name</td>
                        <td  class="tbl3">sum of amount</td>
                      </tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="tbl5">QAR 150,000,00</td>
                      <tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="tbl5">QAR 150,000,00</td>
                      </tr>
                      <tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="tbl5">QAR 150,000,00</td>
                      </tr>
                     </tbody> 
                  </table>
                
                        </div>
                        
                        <div class="col-xs-12 col-sm-4 padding-10" id="divTopAgedLeads" style="width: 38%;" runat="server">
                
                <table cellpadding="0" cellspacing="0" class="table table-striped">
                	<thead>
                      <tr> 
                        <th colspan="3" >Top Deals</th>
                      </tr>
                      </thead>
                      <tbody>
                      <tr>
                        <th colspan="3" class="tbl">open deals current month</th>
                      </tr>
                      <tr >
                        <td  class="tbl2">opportunity name</td>
                        <td  class="tbl3">sum of amount</td>
                      </tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="red_colomn">QAR 150,000,00</td>
                      <tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="red_colomn">QAR 150,000,00</td>
                      </tr>
                      <tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="red_colomn">QAR 150,000,00</td>
                      </tr>
                     </tbody> 
                  </table>
                
                        </div>
                            <div class="col-xs-12 col-sm-4 padding-10" id="divProductCat" style="display:none" runat="server">
                
                <table cellpadding="0" cellspacing="0" class="table table-striped">
                	<thead>
                      <tr> 
                        <th colspan="3" >Top Deals</th>
                      </tr>
                      </thead>
                      <tbody>
                      <tr>
                        <th colspan="3" class="tbl">open deals current month</th>
                      </tr>
                      <tr >
                        <td  class="tbl2">opportunity name</td>
                        <td  class="tbl3">sum of amount</td>
                      </tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="tbl5">QAR 150,000,00</td>
                      <tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="tbl5">QAR 150,000,00</td>
                      </tr>
                      <tr>
                      	<td class="tbl4">lusail projet</td>
                        <td class="tbl5">QAR 150,000,00</td>
                      </tr>
                     </tbody> 
                  </table>
                
                        </div>
                        
                        
                        </div>
                                       
                       
                </div>
                
            </div>
        </div>
    </div>
   
    

</asp:Content>

