<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage_Compzit_GMS.master" AutoEventWireup="true" CodeFile="Compzit_Home_Gms.aspx.cs" Inherits="Home_Compzit_Home_Compzit_Home_Gms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    
    <script src="../../JavaScript/jquery-1.8.3.min.js"></script>

    <script src="/JavaScript/GMS_plugins/jquery.flot.categories.min.js"></script>
    <script src="/JavaScript/GMS_plugins/jquery.flot.min.js"></script>
    <script src="/JavaScript/GMS_plugins/jquery.flot.pie.min.js"></script>
    <script src="/JavaScript/GMS_plugins/jquery.flot.resize.min.js"></script>
    <script src="/JavaScript/GMS_plugins/jquery.knob.js"></script>
    <script src="../../JavaScript/GMS_plugins/jquery.knob.js"></script>


    <script>
        
    </script>
        <style>
        .spanstyle {
           display: block;
           width: 30px;
           height: 30px;
           border-radius: 50%;
         position: absolute;
top: 7px;
right: 7px;
font-family: OpenSans Semibold;
font-size: 15px;
color: #fff;
line-height: 2;
    border: 2px solid #ffffff;
        }
    </style>
    <style>
        
        .cont_rght {
            width: 98%;
            padding-top: 0%;
            padding-bottom: 2%;



        }
        .box-title {
    font-family: OpenSans Semibold;
    font-size: 19px;
    color: #555;
    width: 100%;
    text-align: left;
    padding: 4px 27px 10px;
    margin: 0
}
        .new_sq_7:hover {
    background: #0F5DD4 url(/images/GMS/new_sq_bg.png) repeat 0 0;
}
.new_sq{ box-sizing:border-box; padding:18px 20px; position:relative;height: 116px;}

.new_sq p{font-family:OpenSans Semibold; font-size:13px; color:#fff; text-transform:uppercase;text-shadow: -1px 1px 1px #212121;}

.new_sq_1{ background: rgba(211, 85,21, 1) url(/images/GMS/new_sq_bg.png) repeat 0 0}

.new_sq_2{ background: rgba(71, 139, 85, 1) url(/images/GMS/new_sq_bg.png) repeat 0 0}

	.new_sq_3{ background: rgba(0, 169,187, 1) url(/images/GMS/new_sq_bg.png) repeat 0 0}

    .new_sq_4{ background: rgba(115, 69,129, 1) url(/images/GMS/new_sq_bg.png) repeat 0 0}

    .new_sq_5{ background:#369 url(/images/GMS/new_sq_bg.png) repeat 0 0}
    .new_sq_6{ background:#C6F url(/images/GMS/new_sq_bg.png) repeat 0 0}
    .new_sq_7{ background: #0066FF url(/images/GMS/new_sq_bg.png) repeat 0 0}
      /*EVM-0027*/
    .new_sq img {
    width: 45px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
            <asp:HiddenField ID="hiddenMixedTeamId" runat="server" />
        <asp:HiddenField ID="hiddenUserId" runat="server" />
        <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
        <asp:HiddenField ID="hiddenCorporateId" runat="server" />
          
 
    <div class="contentarea">
    	<div class="auto1" style="width:97%">
        	<div class="cont_lft">
            	<div class="menuarea">


</div>
            </div>
           <%-- EVM-0027--%>
            <div class="cont_rght" style="width:100%;   padding-top: 0%;">
               <%-- END--%>
                
             <%--         <div class="sect250">
                      <div class="row">
        <div class="col-xs-12">
          <div class="box box-solid">
            <div class="box-header">

              <h3 class="box-title">Heading</h3>

              
            </div>
            <!-- /.box-header -->
            <div class="box-body">
                
                <!-- ./col -->
                <a href="#">
                <div class="col-sm-6 col-md-3 text-center hoverbg">
                  <input type="text" class="knob" data-thickness="0.2" data-angleArc="250" data-angleOffset="-125" value="20" data-width="120" data-height="120" data-fgColor="#ec960c">
                  <div class="knob-label">status 1 (in %)</div>
                </div>
                </a>
                <!-- ./col -->
                <a href="#">
                <div class="col-sm-6 col-md-3 text-center hoverbg">
                  <input type="text" class="knob" data-thickness="0.2" data-angleArc="250" data-angleOffset="-125" value="80" data-width="120" data-height="120" data-fgColor="#4bad51">
                  <div class="knob-label">status 2 (in %)</div>
                </div>
                </a>
                <!-- ./col -->
                <a href="#">
                <div class="col-sm-6 col-md-3 text-center hoverbg">
                  <input type="text" class="knob" data-thickness="0.2" data-angleArc="250" data-angleOffset="-125" value="10" data-width="120" data-height="120" data-fgColor="#05c7c6">
                  <div class="knob-label">status 3 (in %)</div>
                </div>
                </a>
                <!-- ./col -->
                <a href="#">
                <div class="col-sm-6 col-md-3 text-center  hoverbg">
                  <input type="text" class="knob" data-thickness="0.2" data-angleArc="250" data-angleOffset="-125" value="100" data-width="120" data-height="120" data-fgColor="#ca6ea3">
                  <div class="knob-label">status 4 (in %)</div>
                </div>
                </a>
                <!-- ./col -->
              </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
        </div>
        <!-- /.col -->
      </div>
                      </div>        --%>
                
         
         <div class="sect250">
                      <div class="row">
                          <div class="col-xs-12">
                              <div class="box box-solid">
                                  <div class="box-header">

                                      <h3 class="box-title"></h3>


                                  </div>
                                  <!-- /.box-header -->
                                   <div class="col-md-6 col-sm-12 md-6" style="border: 1px solid #c2bfbf;padding:14px 3px 40px 2px;">   
                    <h3 class="box-title">Bank Guarantees</h3> 

                                  <div class="box-body">
                                      <!-- ./col -->
                                      <div id="div1" class="col-sm-12 col-md-6 text-center" style="margin-top: 1%" runat="server">
                                          <div class="col-sm-12 new_sq new_sq_7">
                                              <a href="../../GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default=CurrntlyrungSup">
                                                  <img src="/images/GMS/new_dashboard/Supplier_currently_running.png" class="img-responsive" />
                                                  <p>Supplier Guarantees 
                                                    
                                                      Currently running </p>
                                              </a>
                                              <a href="../../GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default=CurrntlyrungSup">
                                                  <div id="divGuarntRunngSup" class="new_sq_n7 spanstyle" runat="server">0</div>
                                                  <%--<span class="new_sq_n1">04</span>--%>
                                              </a>
                                          </div>
                                      </div>
                                      <!-- ./col -->
                                      <!-- ./col -->

                                       <div id="divGuarntRunng" class="col-sm-12 col-md-6 text-center" style="margin-top: 1%" runat="server">
                                          <div class="col-sm-12 new_sq new_sq_6">
                                              <a href="../../GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default=CurrntlyrungCus">
                                                  <img src="/images/GMS/new_dashboard/Customer_currently_running.png" class="img-responsive" />
                                                  <p>Customer Guarantees 
                                                     
                                                      Currently running </p>
                                              </a>
                                              <a href="../../GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default=CurrntlyrungCus">
                                                  <div id="divGuarntRunngCnt" class="new_sq_n6 spanstyle" runat="server">0</div>
                                                  <%--<span class="new_sq_n1">04</span>--%>
                                              </a>
                                          </div>
                                      </div>


                                     <div id="divGuarantee0" class="col-sm-12 col-md-6 text-center" style="margin-top: 1%" runat="server">
                                          <div class="col-sm-12 new_sq new_sq_4">
                                              <a href="../../GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default=newsup">

                                                  <img src="/images/GMS/new_dashboard/Supplier_open_status.png" class="img-responsive" />
                                                  <p>Supplier Guarantees <br />
                                                      Under Open Status</p>
                                              </a>
                                              <a href="../../GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default=newsup">
                                                  <div id="divGteeOpenSts" class="new_sq_n3 spanstyle" runat="server">0</div>
                                                  <!--K  <%--<span class="new_sq_n3">09</span>--%>-->
                                              </a>
                                          </div>
                                      </div>

                                     

                                      <!-- ./col -->

                                  


                                 <%-- <div class="box-body">--%>
                                      <!-- ./col -->
                                      <div id="divGuarantee01" class="col-sm-12 col-md-6 text-center" style="margin-top: 1%" runat="server">
                                          <div class="col-sm-12 new_sq new_sq_5">
                                              <a href="../../GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default=newcus">

                                                  <img src="/images/GMS/new_dashboard/CustomerGuaranteesUnderOpenStatus.png" class="img-responsive" />
                                                  <p>Customer Guarantees<br />
                                                      Under Open Status</p>
                                              </a>
                                              <a href="../../GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default=newcus">
                                                  <div id="divGteeOpenStsCus" class="new_sq_n5 spanstyle" runat="server">0</div>
                                                  <!--K  <%--<span class="new_sq_n3">09</span>--%>-->
                                              </a>
                                          </div>
                                      </div>


                                      <div id="divGuarantee" class="col-sm-12 col-md-6 text-center" style="margin-top: 1%" runat="server">
                                          <div class="col-sm-12 new_sq new_sq_1">
                                              <a href="../../GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default=3monthssup">
                                                  <img src="/images/GMS/new_dashboard/supplierguaranteesexpiringin3months.png" class="img-responsive" />
                                                 <p>Supplier Guarantees  <br />Expiring in 3 months</p>
                                              </a>
                                              <a href="../../GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default=3monthssup">
                                                  <div id="divGteeExpiring" class="new_sq_n1 spanstyle" runat="server">0</div>
                                                  <%--<span class="new_sq_n1">04</span>--%>
                                              </a>
                                          </div>
                                      </div>
                                      <!-- ./col -->

                                     <div id="divGuar3monthCus" class="col-sm-12 col-md-6 text-center" style="margin-top: 1%" runat="server">
                                          <div class="col-sm-12 new_sq new_sq_7">
                                              <a href="../../GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default=3monthscus">
                                                  <img src="/images/GMS/new_dashboard/Customer_Guarantees_Expiring_in3months.png" class="img-responsive" />
                                                  <p>Customer Guarantees <br />
                                                   
                                                      Expiring in 3 months</p>
                                              </a>
                                              <a href="../../GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default=3monthscus">
                                                  <div id="divGteeExpiringcus" class="new_sq_n7 spanstyle" runat="server">0</div>
                                                  <%--<span class="new_sq_n1">04</span>--%>
                                              </a>
                                          </div>
                                      </div>



                                      <!-- ./col -->

                                      <!-- ./col -->
                                      <!-- ./col -->


                                      <div id="divGuarExpSup" class="col-sm-12 col-md-6 text-center" style="margin-top: 1%" runat="server">
                                          <div class="col-sm-12 new_sq new_sq_2">
                                              <a href="../../GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default=expiredsup">
                                                  <img src="/images/GMS/new_dashboard/Supplier_expired.png" class="img-responsive" />
                                                  <p>Expired Supplier <br />
                                                      Guarantees</p>
                                              </a>
                                              <a href="../../GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default=expiredsup">
                                                  <div id="divExpiredGtees" class="new_sq_n1 spanstyle" runat="server">0</div>
                                                  <!--<%--<span class="new_sq_n4">04</span>--%>-->
                                              </a>
                                          </div>
                                      </div>

                                     <div id="divGuarantee1" class="col-sm-12 col-md-6 text-center" style="margin-top: 1%" runat="server">
                                          <div class="col-sm-12 new_sq new_sq_6">
                                              <a href="../../GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default=expiredcus">
                                                  <img src="/images/GMS/new_dashboard/Customer_Expired _Guarantees.png" class="img-responsive" />
                                                  <p>Expired Customer <br />
                                                      Guarantees</p>
                                              </a>
                                              <a href="../../GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default=expiredcus">
                                                  <div id="divExpiredGteescus" class="new_sq_n6 spanstyle" runat="server">0</div>
                                                  <!--<%--<span class="new_sq_n4">04</span>--%>-->
                                              </a>
                                          </div>
                                      </div>

                                       <div id="divRFQ" class="col-sm-12 col-md-6 text-center" style="margin-top: 1%" runat="server">
                                          <div class="col-sm-12 new_sq new_sq_3">
                                              <a href="../../GMS/GMS_Master/gen_Request_For_Guarantee/gen_Request_For_Guarantee_List.aspx">

                                                  <img src="/images/GMS/new_dashboard/RFG_under_pending.png" class="img-responsive" />
                                                   <p>RFG Under<br />pending Status</p>
                                              </a>
                                              <a href="../../GMS/GMS_Master/gen_Request_For_Guarantee/gen_Request_For_Guarantee_List.aspx">
                                                  <div id="divRfgPending" class="new_sq_n2 spanstyle" runat="server">0</div>
                                                  <!--<%--<span class="new_sq_n2">12</span>--%>-->
                                              </a>
                                          </div>
                                      </div>




                                       </div>
                                  
                                  <%-- EVM-0027--%>
                       <%--   </div>--%>
                                   </div>
                               <%-- </div>--%>
                                
                               <div class="col-md-6 col-sm-12 md-6" style="border:1px solid #c2bfbf;padding:14px 3px 40px 2px;">
                       <h3 class="box-title">Insurances  </h3> 
                                     <div class="box-body">
                                 
                                      <div id="div2" class="col-sm-12 col-md-6 text-center" style="margin-top: 1%" runat="server">
                                          <div class="col-sm-12 new_sq new_sq_5">
                                              <a href="/GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default_INSRNC=CurrntlyRunng">
                                                  <img src="/images/GMS/new_dashboard/insurancecurrentlyrunning.png" class="img-responsive">
                                                  <p>INSURANCE 
                                                      Currently running </p>
                                              </a>
                                              <a href="/GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default_INSRNC=CurrntlyRunng">
                                                  <div id="divRun" class="new_sq_5 spanstyle" runat="server">0</div>
                                                  <%--<span class="new_sq_n1">04</span>--%>
                                              </a>
                                          </div>
                                      </div>


                                      <div id="div6" class="col-sm-12 col-md-6 text-center" style="margin-top: 1%" runat="server">
                                          <div class="col-sm-12 new_sq new_sq_1">
                                              <a href="/GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default_INSRNC=new">
                                                 <img src="/images/GMS/new_dashboard/insurance_open_status.png" class="img-responsive">
                                                  <p>INSURANCE 
                                                    
                                                      OPEN STATUS</p>
                                              </a>
                                              <a href="/GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default_INSRNC=new">
                                                  <div id="divOpen" class="new_sq_1 spanstyle" runat="server">0</div>
                                                  <%--<span class="new_sq_n1">04</span>--%>
                                              </a>
                                          </div>
                                      </div>

                                        <div id="divMonth" class="col-sm-12 col-md-6 text-center" style="margin-top: 1%">
                                            <div class="col-sm-12 new_sq new_sq_7">
                                                <a href="/GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default_INSRNC=3months">

                                                    <img src="/images/GMS/new_dashboard/Insurance_Expired.png" class="img-responsive">
                                                    <p>Insurance Expiring in 3 months</p>
                                                </a>
                                               <a href="/GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default_INSRNC=3months">
                                                       <div id="divMonths" class="new_sq_7 spanstyle" runat="server">0</div>
                                                    
                                                </a>
                                            </div>
                                        </div>


                                      <div id="div4" class="col-sm-12 col-md-6 text-center" style="margin-top: 1%"  runat="server">
                                          <div class="col-sm-12 new_sq new_sq_2">
                                              <a href="/GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default_INSRNC=expired">
                                                   <img src="/images/GMS/new_dashboard/insurancecurrently running_ex.png" class="img-responsive">
                                                  <p>EXPIRED INSURANCE </p>                                              
                                                     
                                              </a>
                                              <a href="/GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee_List.aspx?default_INSRNC=expired">
                                                  <div id="divExpired" class="new_sq_2 spanstyle" runat="server">0</div>
                                                 
                                              </a>
                                          </div>
                                      </div>


                                         </div>
                              <%--    </div>
                           </div>--%>
                                  <%--END--%>
                             
                      <!-- ./col -->
                                </div>
                                <!-- /.box-body -->
                            </div>
                            <!-- /.box -->
                        </div>
                    <!-- /.col -->
                    </div>
                </div>
                
                        
          

                
                
            </div>
        </div>
    </div>


    
<script src="js/jquery-1.11.2.min.js"></script>
    <script src="js/jquery.min.js"></script><!-- import -->
    <script src="js/bootstrap.min.js"></script><!-- import -->


<!-- FLOT CHARTS -->
<script src="new/jquery.flot.min.js"></script>
<!-- FLOT RESIZE PLUGIN - allows the chart to redraw when the window is resized -->
<script src="new/jquery.flot.resize.min.js"></script>
<!-- FLOT PIE PLUGIN - also used to draw donut charts -->
<script src="new/jquery.flot.pie.min.js"></script>
<!-- FLOT CATEGORIES PLUGIN - Used to draw bar charts -->
<script src="new/jquery.flot.categories.min.js"></script>
<!-- Page script -->
<script>

  /*
   * Custom Label formatter
   * ----------------------
   */
  function labelFormatter(label, series) {
    return '<div style="font-size:13px; text-align:center; padding:2px; color: #fff; font-weight: 600;">'
        + label
        + "<br>"
        + Math.round(series.percent) + "%</div>";
  }
</script>
<!-- jQuery Knob -->
<script src="new/jquery.knob.js"></script>


<script>
  $(function () {
    /* jQueryKnob */

    $(".knob").knob({
      /*change : function (value) {
       //console.log("change : " + value);
       },
       release : function (value) {
       console.log("release : " + value);
       },
       cancel : function () {
       console.log("cancel : " + this.value);
       },*/
      draw: function () {

        // "tron" case
        if (this.$.data('skin') == 'tron') {

          var a = this.angle(this.cv)  // Angle
              , sa = this.startAngle          // Previous start angle
              , sat = this.startAngle         // Start angle
              , ea                            // Previous end angle
              , eat = sat + a                 // End angle
              , r = true;

          this.g.lineWidth = this.lineWidth;

          this.o.cursor
          && (sat = eat - 0.3)
          && (eat = eat + 0.3);

          if (this.o.displayPrevious) {
            ea = this.startAngle + this.angle(this.value);
            this.o.cursor
            && (sa = ea - 0.3)
            && (ea = ea + 0.3);
            this.g.beginPath();
            this.g.strokeStyle = this.previousColor;
            this.g.arc(this.xy, this.xy, this.radius - this.lineWidth, sa, ea, false);
            this.g.stroke();
          }

          this.g.beginPath();
          this.g.strokeStyle = r ? this.o.fgColor : this.fgColor;
          this.g.arc(this.xy, this.xy, this.radius - this.lineWidth, sat, eat, false);
          this.g.stroke();

          this.g.lineWidth = 2;
          this.g.beginPath();
          this.g.strokeStyle = this.o.fgColor;
          this.g.arc(this.xy, this.xy, this.radius - this.lineWidth + 1 + this.lineWidth * 2 / 3, 0, 2 * Math.PI, false);
          this.g.stroke();

          return false;
        }
      }
    });
    /* END JQUERY KNOB */

    //INITIALIZE SPARKLINE CHARTS
    //$(".sparkline").each(function () {
    //  var $this = $(this);
    //  $this.sparkline('html', $this.data());
    //});

    /* SPARKLINE DOCUMENTATION EXAMPLES http://omnipotent.net/jquery.sparkline/#s-about */
    //drawDocSparklines();
    //drawMouseSpeedDemo();

  });
 
  /**
   ** Draw the little mouse speed animated graph
   ** This just attaches a handler to the mousemove event to see
   ** (roughly) how far the mouse has moved
   ** and then updates the display a couple of times a second via
   ** setTimeout()
   **/
  function drawMouseSpeedDemo() {
    var mrefreshinterval = 500; // update display every 500ms
    var lastmousex = -1;
    var lastmousey = -1;
    var lastmousetime;
    var mousetravel = 0;
    var mpoints = [];
    var mpoints_max = 30;
    $('html').mousemove(function (e) {
      var mousex = e.pageX;
      var mousey = e.pageY;
      if (lastmousex > -1) {
        mousetravel += Math.max(Math.abs(mousex - lastmousex), Math.abs(mousey - lastmousey));
      }
      lastmousex = mousex;
      lastmousey = mousey;
    });
    var mdraw = function () {
      var md = new Date();
      var timenow = md.getTime();
      if (lastmousetime && lastmousetime != timenow) {
        var pps = Math.round(mousetravel / (timenow - lastmousetime) * 1000);
        mpoints.push(pps);
        if (mpoints.length > mpoints_max)
          mpoints.splice(0, 1);
        mousetravel = 0;
        $('#mousespeed').sparkline(mpoints, {width: mpoints.length * 2, tooltipSuffix: ' pixels per second'});
      }
      lastmousetime = timenow;
      setTimeout(mdraw, mrefreshinterval);
    };
    // We could use setInterval instead, but I prefer to do it this way
    setTimeout(mdraw, mrefreshinterval);
  }
</script>



   
    


<script>
var op=document.getElementById("hidden_circle").style.opacity;
if(op==0)
{
//alert "help";
document.getElementById("hidden_circle").style.display="none";
}
</script>


          <style>
.toggler {
    -webkit-background-clip: padding-box;
    background-clip: padding-box;
    width:25px;
    height: 48px;
    position: absolute;
    top: 45%;
    cursor: pointer;
	position: fixed;
	transition: all 0.3s ease;
    left: 0;
	z-index:100;
	background-color: #222d32;
color: white;
border: none;
}
.toggler > span {
    margin:17px 6px;
}
#overlay {
    position: fixed; /* Sit on top of the page content */
    display: none; /* Hidden by default */
    width: 100%; /* Full width (cover the whole page) */
    height: 100%; /* Full height (cover the whole page) */
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background-color:transparent; /* Black background with opacity */
    z-index:110; /* Specify a stack order in case you're using a different order for other elements */
 
}
.md-6
{
	width:48%;
	margin-right:2%;
}
@media all and (max-width:800px) {
.md-6
{
	width:100%;
	/*margin-right:2%;*/
}
}
</style>
</asp:Content>

