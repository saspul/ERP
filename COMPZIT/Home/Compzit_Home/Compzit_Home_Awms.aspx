<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="Compzit_Home_Awms.aspx.cs" Inherits="Home_Compzit_Home_Compzit_Home_Awms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

     
    <!-- Custom CSS -->
    <link href="../../css/plugins/sb-admin.css" rel="stylesheet" />
    <!-- Morris Charts CSS -->
    <link href="../../css/plugins/morris.css" rel="stylesheet" />

    <script src="../../JavaScript/jquery-1.11.2.min.js"></script>
    <%--  <script src="js/bootstrap.min.js"></script><!-- import -->
    <script src="../../JavaScript/bootstrap.min.js"></script>--%>
    <script src="../../JavaScript/jquery.min.js"></script>

    

    <!-- Flot Charts JavaScript -->
    <!--[if lte IE 8]><script src="js/excanvas.min.js"></script><![endif]-->
    

    <script src="../../JavaScript/plugins/flot/jquery.flot.js"></script>
    <script src="../../JavaScript/plugins/flot/jquery.flot.tooltip.min.js"></script>
    <script src="../../JavaScript/plugins/flot/jquery.flot.resize.js"></script>
    <script src="../../JavaScript/plugins/flot/jquery.flot.pie.js"></script>


    <%--<script src="../../JavaScript/plugins/flot/flot-data.js"></script>--%>


  

    <!-- Morris Charts JavaScript -->
    <script src="../../JavaScript/plugins/morris/raphael.min.js"></script>
    <script src="../../JavaScript/plugins/morris/morris.min.js"></script>


    <%--<script src="../../JavaScript/plugins/morris/morris-data.js"></script>--%>

    <%--<script src="../../JavaScript/jquery-1.8.3.min.js"></script>--%>



       <%--  for giving pagination to the html table--%>
    <script src="../../JavaScript/Infinite_Vertical_Scrolling/jquery.dataTables.min.js"></script>
    <%--<script src="../../JavaScript/Infinite_Vertical_Scrolling/jquery-1.12.4.js"></script>--%>

<script>
    var $noCon = jQuery.noConflict();
    $noCon(document).ready(function () {
        $noCon(this).scrollTop(0);
    });
    $noCon(document).ready(function () {
        $noCon('#ReportTable0').dataTable({
            "bScrollInfinite": true,
            "bScrollCollapse": true,
            "sScrollY": "200px",
            "paging": false,
            "info": false,
            "ordering": false
        });
    });
    $noCon(document).ready(function () {
        $noCon('#ReportTable1').dataTable({
            "bScrollInfinite": true,
            "bScrollCollapse": true,
            "sScrollY": "200px",
            "paging": false,
            "info": false,
            "ordering": false
        });
    });
   
</script>
    <style>

        input[type=search] {
margin-left: 3%;
}
         #ReportTable0_filter {
             width: 17.5%;
  float: right;
margin-bottom: 1%;
font-family: Calibri;
font-size: 15px;
color: #7f8770;


    }
#ReportTable1_filter {
         width: 17.5%;
  float: right;
margin-bottom: 1%;
font-family: Calibri;
font-size: 15px;
color: #7f8770;

    }
    </style>


    <style>
        body {
            margin-top: 0%;
            background-color: #222;
        }

        @media(min-width:768px) {
            body;

        {
            margin-top: 0%;
        }

        }

        .cont_rght {
            padding-bottom: 2%;
            padding-top: 2%;
            width: 100%;
        }
   .morris-hover {
    position: absolute;
    z-index: 100;
}
   .tdT {
    height: 30px;
    padding: 0 4px 0 4px;
    border-right: 1px solid #c9c9c9;
    font-family: Calibri;
    font-size: 14px;
}
        #scll_sty
{
	height: 138px;
	width:98.6%;
	overflow-x: auto;
	margin-bottom:40px;

}
        .panel-title {
        color: #000;
        }
        /*scroll bar*/
/*#scll_sty::-webkit-scrollbar-track
{
	-webkit-box-shadow: inset 0 0 10px rgba(0,0,0,0.3);
	background-color:#F5F5F5;
}

#scll_sty::-webkit-scrollbar
{
	width:8px;
	background-color: #F5F5F5;cursor:pointer;
}

#scll_sty::-webkit-scrollbar-thumb
{
	background-color:#26a59a;
	
}
#scll_sty::-webkit-scrollbar-thumb:hover
{
    cursor:pointer;
	background-color:#999;
}*/
    </style>
        <style type="text/css">
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
                  .divSettlmntDetls {
            font-family: Calibri;
            padding-bottom: 2%;
            overflow-x: auto;
            background: #f4f6f0;
            margin: 0 0 5px;
            border: 1px solid #9BA48B;
        }
                  .cont_rght {
            width: 99.5%;
        }
    </style>
     
    <script type="text/javascript" src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script type="text/javascript" src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script type="text/javascript" src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link rel="stylesheet" href="/css/Autocomplete/jquery-ui.css" />
    <script>
        // Morris.js Charts sample data for SB Admin template
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
        var $MstrnoCon = jQuery.noConflict();
        $MstrnoCon(window).load(function () {
            $MstrnoCon('#cphMain_ddlFromYearPermit').selectToAutocomplete1Letter();
            $MstrnoCon('#cphMain_ddlToYearPermit').selectToAutocomplete1Letter();
            

            $MstrnoCon('#cphMain_ddlFromYearInsu').selectToAutocomplete1Letter();
            $MstrnoCon('#cphMain_ddlToYearInsu').selectToAutocomplete1Letter();

            //VECHICLE BY YEAR DATA
            var data = document.getElementById("<%=hiddenVehicleByYearData.ClientID%>").value;
            var VehicleByYearData = [{
                'YEAR': '0',
                'COUNT': '0',
            }];
            if (data != "") {
                VehicleByYearData = ConvertToJson(data);
                
            }
           
            
        
            var ServiceData = document.getElementById("<%=hiddenVhclByServiceDataPie.ClientID%>").value;
            var VhclServiceData = [{
                label: "No Data",
                    data: 1, color: '#2f71e4'
                
            }];
            if (ServiceData != "") {
                 VhclServiceData = ConvertToJson(ServiceData);
            }
            var DriverAvailChart = document.getElementById("<%=hiddenDriverAvailChart.ClientID%>").value;
            var DriverAvailChartDat = [{
                label: "No Data",
                data: 1, color: '#2f71e4'

            }];
            if (DriverAvailChart != "") {
                DriverAvailChartDat = ConvertToJson(DriverAvailChart);
            }
            
          
           
            

         




            // Bar Chart
            Morris.Bar({
                element: 'divVehiclesCount',
              
                data: VehicleByYearData,
                xkey: 'YEAR',
                ykeys: ['COUNT'],
                labels: ['COUNT'],
                barRatio: 0.7,
                xLabelAngle: 90,
                hideHover: 'auto',
                resize: true,
                yLabelFormat: function (y) { return y != Math.round(y) ? '' : y; },
                gridTextFamily: 'Calibri'
                //gridIntegers: true,
                //ymin: 0
            });


          



          



         
            var plotObj = $MstrnoCon.plot($MstrnoCon("#flot-pie-chart"), VhclServiceData, {
                series: {
                    pie: {
                        show: true
                    }
                },
               
                grid: {
                    hoverable: true
                },
                tooltip: true,
                tooltipOpts: {
                    //content: "%p.0%, %s", // show percentages, rounding to 2 decimal places
                    content: function (label, xval, yval) {
                        var content = label + ": " + yval;
                        return content;
                    },
                    shifts: {
                        x: 20,
                        y: 0
                    },
                    defaultTheme: false
                }
            });
            //PIE2
            var data = [{
                label: "Serdddies 0",
                data: 50
            }, {
                label: "Series 1",
                data: 3
            }, {
                label: "Series 2",
                data: 9
            }, {
                label: "Series 3",
                data: 20
            }];

            

            var plotObj = $MstrnoCon.plot($MstrnoCon("#flot-pie-chart-2"), DriverAvailChartDat, {
                series: {
                    pie: {
                        show: true
                    }
                },
                grid: {
                    hoverable: true
                },
               
                tooltip: true,
                tooltipOpts: {
                    //content: "%y.0, %s", // show value to 0 decimals
                    //content: "%p.0%, %s", // show percentages, rounding to 2 decimal places
                    content: function(label, xval, yval) {
                        var content = label+": " + yval;
                        return content;
                    },
                    shifts: {
                        x: 20,
                        y: 0
                    },
                    defaultTheme: false
                }
            });
            $MstrnoCon('svg').height(400);
            //LoadGraph('Insu');
            //LoadGraph('Permit');
        });

        function LoadVhclAllotment() {


            var projectvhcldata = document.getElementById("<%=HiddenProjectVhclData.ClientID%>").value;
            var ProjectVhclDataBarChart = "";
            if (projectvhcldata != "") {
                var ProjectVhclDataBarChart = ConvertToJson(projectvhcldata);


            }

            //  var projectdata = document.getElementById("<%=HiddenProjectData.ClientID%>").value;
            //  if (projectdata != "") {
            //      var projectdatabarchart = ConvertToJson(projectdata);
            //  }

            var vhcldata = document.getElementById("<%=HiddenVhclData.ClientID%>").value;

            if (vhcldata != "") {
                // var vhcldatabarchart = ConvertToJson(vhcldata);
            }

            BookedAmtdata = document.getElementById("<%=HiddenVhclData.ClientID%>").value;
            var vhclDataArr = [];
            if (BookedAmtdata != "") {
                var resBookedAmtdata = BookedAmtdata.split(",");

                for (var i = 0; i < resBookedAmtdata.length; i++) {
                    vhclDataArr.push(resBookedAmtdata[i]);

                }
            }
            //colors
            var ColorListdata = document.getElementById("<%=HiddenColorList.ClientID%>").value;
            var ColorLisArr = [];
            if (ColorListdata != "") {
                var resColorListdata = ColorListdata.split(",");

                for (var i = 0; i < resColorListdata.length; i++) {
                    ColorLisArr.push(resColorListdata[i]);

                }
            }


            var projectdata = document.getElementById("<%=HiddenProjectData.ClientID%>").value;
            var ProjectDataArr = [];
            if (projectdata != "") {
                var resPrjdata = projectdata.split(",");

                for (var i = 0; i < resPrjdata.length; i++) {
                    ProjectDataArr.push(resPrjdata[i]);

                }
            }

            (function () {
                var a, b, c, d, e = [].slice, f = function (a, b) { return function () { return a.apply(b, arguments) } }, g = {}.hasOwnProperty, h = function (a, b) { function c() { this.constructor = a } for (var d in b) g.call(b, d) && (a[d] = b[d]); return c.prototype = b.prototype, a.prototype = new c, a.__super__ = b.prototype, a }, i = [].indexOf || function (a) { for (var b = 0, c = this.length; c > b; b++) if (b in this && this[b] === a) return b; return -1 }; b = window.Morris = {}, a = jQuery, b.EventEmitter = function () { function a() { } return a.prototype.on = function (a, b) { return null == this.handlers && (this.handlers = {}), null == this.handlers[a] && (this.handlers[a] = []), this.handlers[a].push(b), this }, a.prototype.fire = function () { var a, b, c, d, f, g, h; if (c = arguments[0], a = 2 <= arguments.length ? e.call(arguments, 1) : [], null != this.handlers && null != this.handlers[c]) { for (g = this.handlers[c], h = [], d = 0, f = g.length; f > d; d++) b = g[d], h.push(b.apply(null, a)); return h } }, a }(), b.commas = function (a) { var b, c, d, e; return null != a ? (d = 0 > a ? "-" : "", b = Math.abs(a), c = Math.floor(b).toFixed(0), d += c.replace(/(?=(?:\d{3})+$)(?!^)/g, ","), e = b.toString(), e.length > c.length && (d += e.slice(c.length)), d) : "-" }, b.pad2 = function (a) { return (10 > a ? "0" : "") + a }, b.Grid = function (c) { function d(b) { this.resizeHandler = f(this.resizeHandler, this); var c = this; if (this.el = a("string" == typeof b.element ? document.getElementById(b.element) : b.element), null == this.el || 0 === this.el.length) throw new Error("Graph container element not found"); "static" === this.el.css("position") && this.el.css("position", "relative"), this.options = a.extend({}, this.gridDefaults, this.defaults || {}, b), "string" == typeof this.options.units && (this.options.postUnits = b.units), this.raphael = new Raphael(this.el[0]), this.elementWidth = null, this.elementHeight = null, this.dirty = !1, this.selectFrom = null, this.init && this.init(), this.setData(this.options.data), this.el.bind("mousemove", function (a) { var b, d, e, f, g; return d = c.el.offset(), g = a.pageX - d.left, c.selectFrom ? (b = c.data[c.hitTest(Math.min(g, c.selectFrom))]._x, e = c.data[c.hitTest(Math.max(g, c.selectFrom))]._x, f = e - b, c.selectionRect.attr({ x: b, width: f })) : c.fire("hovermove", g, a.pageY - d.top) }), this.el.bind("mouseleave", function () { return c.selectFrom && (c.selectionRect.hide(), c.selectFrom = null), c.fire("hoverout") }), this.el.bind("touchstart touchmove touchend", function (a) { var b, d; return d = a.originalEvent.touches[0] || a.originalEvent.changedTouches[0], b = c.el.offset(), c.fire("hovermove", d.pageX - b.left, d.pageY - b.top) }), this.el.bind("click", function (a) { var b; return b = c.el.offset(), c.fire("gridclick", a.pageX - b.left, a.pageY - b.top) }), this.options.rangeSelect && (this.selectionRect = this.raphael.rect(0, 0, 0, this.el.innerHeight()).attr({ fill: this.options.rangeSelectColor, stroke: !1 }).toBack().hide(), this.el.bind("mousedown", function (a) { var b; return b = c.el.offset(), c.startRange(a.pageX - b.left) }), this.el.bind("mouseup", function (a) { var b; return b = c.el.offset(), c.endRange(a.pageX - b.left), c.fire("hovermove", a.pageX - b.left, a.pageY - b.top) })), this.options.resize && a(window).bind("resize", function () { return null != c.timeoutId && window.clearTimeout(c.timeoutId), c.timeoutId = window.setTimeout(c.resizeHandler, 100) }), this.el.css("-webkit-tap-highlight-color", "rgba(0,0,0,0)"), this.postInit && this.postInit() } return h(d, c), d.prototype.gridDefaults = { dateFormat: null, axes: !0, grid: !0, gridLineColor: "#aaa", gridStrokeWidth: .5, gridTextColor: "#888", gridTextSize: 12, gridTextFamily: "sans-serif", gridTextWeight: "normal", hideHover: !1, yLabelFormat: null, xLabelAngle: 0, numLines: 5, padding: 25, parseTime: !0, postUnits: "", preUnits: "", ymax: "auto", ymin: "auto 0", goals: [], goalStrokeWidth: 1, goalLineColors: ["#666633", "#999966", "#cc6666", "#663333"], events: [], eventStrokeWidth: 1, eventLineColors: ["#005a04", "#ccffbb", "#3a5f0b", "#005502"], rangeSelect: null, rangeSelectColor: "#eef", resize: !1 }, d.prototype.setData = function (a, c) { var d, e, f, g, h, i, j, k, l, m, n, o, p, q, r; return null == c && (c = !0), this.options.data = a, null == a || 0 === a.length ? (this.data = [], this.raphael.clear(), void (null != this.hover && this.hover.hide())) : (o = this.cumulative ? 0 : null, p = this.cumulative ? 0 : null, this.options.goals.length > 0 && (h = Math.min.apply(Math, this.options.goals), g = Math.max.apply(Math, this.options.goals), p = null != p ? Math.min(p, h) : h, o = null != o ? Math.max(o, g) : g), this.data = function () { var c, d, g; for (g = [], f = c = 0, d = a.length; d > c; f = ++c) j = a[f], i = { src: j }, i.label = j[this.options.xkey], this.options.parseTime ? (i.x = b.parseDate(i.label), this.options.dateFormat ? i.label = this.options.dateFormat(i.x) : "number" == typeof i.label && (i.label = new Date(i.label).toString())) : (i.x = f, this.options.xLabelFormat && (i.label = this.options.xLabelFormat(i))), l = 0, i.y = function () { var a, b, c, d; for (c = this.options.ykeys, d = [], e = a = 0, b = c.length; b > a; e = ++a) n = c[e], q = j[n], "string" == typeof q && (q = parseFloat(q)), null != q && "number" != typeof q && (q = null), null != q && (this.cumulative ? l += q : null != o ? (o = Math.max(q, o), p = Math.min(q, p)) : o = p = q), this.cumulative && null != l && (o = Math.max(l, o), p = Math.min(l, p)), d.push(q); return d }.call(this), g.push(i); return g }.call(this), this.options.parseTime && (this.data = this.data.sort(function (a, b) { return (a.x > b.x) - (b.x > a.x) })), this.xmin = this.data[0].x, this.xmax = this.data[this.data.length - 1].x, this.events = [], this.options.events.length > 0 && (this.events = this.options.parseTime ? function () { var a, c, e, f; for (e = this.options.events, f = [], a = 0, c = e.length; c > a; a++) d = e[a], f.push(b.parseDate(d)); return f }.call(this) : this.options.events, this.xmax = Math.max(this.xmax, Math.max.apply(Math, this.events)), this.xmin = Math.min(this.xmin, Math.min.apply(Math, this.events))), this.xmin === this.xmax && (this.xmin -= 1, this.xmax += 1), this.ymin = this.yboundary("min", p), this.ymax = this.yboundary("max", o), this.ymin === this.ymax && (p && (this.ymin -= 1), this.ymax += 1), ((r = this.options.axes) === !0 || "both" === r || "y" === r || this.options.grid === !0) && (this.options.ymax === this.gridDefaults.ymax && this.options.ymin === this.gridDefaults.ymin ? (this.grid = this.autoGridLines(this.ymin, this.ymax, this.options.numLines), this.ymin = Math.min(this.ymin, this.grid[0]), this.ymax = Math.max(this.ymax, this.grid[this.grid.length - 1])) : (k = (this.ymax - this.ymin) / (this.options.numLines - 1), this.grid = function () { var a, b, c, d; for (d = [], m = a = b = this.ymin, c = this.ymax; k > 0 ? c >= a : a >= c; m = a += k) d.push(m); return d }.call(this))), this.dirty = !0, c ? this.redraw() : void 0) }, d.prototype.yboundary = function (a, b) { var c, d; return c = this.options["y" + a], "string" == typeof c ? "auto" === c.slice(0, 4) ? c.length > 5 ? (d = parseInt(c.slice(5), 10), null == b ? d : Math[a](b, d)) : null != b ? b : 0 : parseInt(c, 10) : c }, d.prototype.autoGridLines = function (a, b, c) { var d, e, f, g, h, i, j, k, l; return h = b - a, l = Math.floor(Math.log(h) / Math.log(10)), j = Math.pow(10, l), e = Math.floor(a / j) * j, d = Math.ceil(b / j) * j, i = (d - e) / (c - 1), 1 === j && i > 1 && Math.ceil(i) !== i && (i = Math.ceil(i), d = e + i * (c - 1)), 0 > e && d > 0 && (e = Math.floor(a / i) * i, d = Math.ceil(b / i) * i), 1 > i ? (g = Math.floor(Math.log(i) / Math.log(10)), f = function () { var a, b; for (b = [], k = a = e; i > 0 ? d >= a : a >= d; k = a += i) b.push(parseFloat(k.toFixed(1 - g))); return b }()) : f = function () { var a, b; for (b = [], k = a = e; i > 0 ? d >= a : a >= d; k = a += i) b.push(k); return b }(), f }, d.prototype._calc = function () { var a, b, c, d, e, f, g, h, i; return f = this.el.width(), d = this.el.height(), (this.elementWidth !== f || this.elementHeight !== d || this.dirty) && (this.elementWidth = f, this.elementHeight = d, this.dirty = !1, this.left = this.options.padding, this.right = this.elementWidth - this.options.padding, this.top = this.options.padding, this.bottom = this.elementHeight - this.options.padding, ((h = this.options.axes) === !0 || "both" === h || "y" === h) && (g = function () { var a, b, d, e; for (d = this.grid, e = [], a = 0, b = d.length; b > a; a++) c = d[a], e.push(this.measureText(this.yAxisFormat(c)).width); return e }.call(this), this.options.horizontal ? this.bottom -= Math.max.apply(Math, g) : this.left += Math.max.apply(Math, g)), ((i = this.options.axes) === !0 || "both" === i || "x" === i) && (a = this.options.horizontal ? -90 : -this.options.xLabelAngle, b = function () { var b, c, d; for (d = [], e = b = 0, c = this.data.length; c >= 0 ? c > b : b > c; e = c >= 0 ? ++b : --b) d.push(this.measureText(this.data[e].label, a).height); return d }.call(this), this.options.horizontal ? this.left += Math.max.apply(Math, b) : this.bottom -= Math.max.apply(Math, b)), this.width = Math.max(1, this.right - this.left), this.height = Math.max(1, this.bottom - this.top), this.options.horizontal ? (this.dx = this.height / (this.xmax - this.xmin), this.dy = this.width / (this.ymax - this.ymin), this.yStart = this.left, this.yEnd = this.right, this.xStart = this.top, this.xEnd = this.bottom, this.xSize = this.height, this.ySize = this.width) : (this.dx = this.width / (this.xmax - this.xmin), this.dy = this.height / (this.ymax - this.ymin), this.yStart = this.bottom, this.yEnd = this.top, this.xStart = this.left, this.xEnd = this.right, this.xSize = this.width, this.ySize = this.height), this.calc) ? this.calc() : void 0 }, d.prototype.transY = function (a) { return this.options.horizontal ? this.left + (a - this.ymin) * this.dy : this.bottom - (a - this.ymin) * this.dy }, d.prototype.transX = function (a) { var b, c; return this.options.horizontal ? (c = this.left, b = this.right) : (c = this.top, b = this.bottom), 1 === this.data.length ? (c + b) / 2 : c + (a - this.xmin) * this.dx }, d.prototype.redraw = function () { return this.raphael.clear(), this._calc(), this.drawGrid(), this.drawGoals(), this.drawEvents(), this.draw ? this.draw() : void 0 }, d.prototype.measureText = function (a, b) { var c, d; return null == b && (b = 0), d = this.raphael.text(100, 100, a).attr("font-size", this.options.gridTextSize).attr("font-family", this.options.gridTextFamily).attr("font-weight", this.options.gridTextWeight).rotate(b), c = d.getBBox(), d.remove(), c }, d.prototype.yAxisFormat = function (a) { return this.yLabelFormat(a) }, d.prototype.yLabelFormat = function (a) { return "function" == typeof this.options.yLabelFormat ? this.options.yLabelFormat(a) : "" + this.options.preUnits + b.commas(a) + this.options.postUnits }, d.prototype.getYAxisLabelX = function () { return this.left - this.options.padding / 2 }, d.prototype.drawGrid = function () { var a, b, c, d, e, f, g, h, i; if (this.options.grid !== !1 || (f = this.options.axes) === !0 || "both" === f || "y" === f) { for (a = this.options.horizontal ? this.getXAxisLabelY() : this.getYAxisLabelX(), g = this.grid, i = [], d = 0, e = g.length; e > d; d++) b = g[d], c = this.transY(b), ((h = this.options.axes) === !0 || "both" === h || "y" === h) && (this.options.horizontal ? this.drawXAxisLabel(c, a, this.yAxisFormat(b)) : this.drawYAxisLabel(a, c, this.yAxisFormat(b))), i.push(this.options.grid ? this.options.horizontal ? this.drawGridLine("M" + c + "," + this.xStart + "V" + this.xEnd) : this.drawGridLine("M" + this.xStart + "," + c + "H" + this.xEnd) : void 0); return i } }, d.prototype.drawGoals = function () { var a, b, c, d, e, f, g; for (f = this.options.goals, g = [], c = d = 0, e = f.length; e > d; c = ++d) b = f[c], a = this.options.goalLineColors[c % this.options.goalLineColors.length], g.push(this.drawGoal(b, a)); return g }, d.prototype.drawEvents = function () { var a, b, c, d, e, f, g; for (f = this.events, g = [], c = d = 0, e = f.length; e > d; c = ++d) b = f[c], a = this.options.eventLineColors[c % this.options.eventLineColors.length], g.push(this.drawEvent(b, a)); return g }, d.prototype.drawGoal = function (a, b) { var c; return c = this.options.horizontal ? "M" + this.transY(a) + "," + this.xStart + "V" + this.xEnd : "M" + this.xStart + "," + this.transY(a) + "H" + this.xEnd, this.raphael.path(c).attr("stroke", b).attr("stroke-width", this.options.goalStrokeWidth) }, d.prototype.drawEvent = function (a, b) { var c; return c = this.options.horizontal ? "M" + this.yStart + "," + this.transX(goal) + "H" + this.yEnd : "M" + this.transX(goal) + "," + this.yStart + "V" + this.yEnd, this.raphael.path(c).attr("stroke", b).attr("stroke-width", this.options.eventStrokeWidth) }, d.prototype.drawYAxisLabel = function (a, b, c) { return this.raphael.text(a, b, c).attr("font-size", this.options.gridTextSize).attr("font-family", this.options.gridTextFamily).attr("font-weight", this.options.gridTextWeight).attr("fill", this.options.gridTextColor).attr("text-anchor", "end") }, d.prototype.drawGridLine = function (a) { return this.raphael.path(a).attr("stroke", this.options.gridLineColor).attr("stroke-width", this.options.gridStrokeWidth) }, d.prototype.startRange = function (a) { return this.hover.hide(), this.selectFrom = a, this.selectionRect.attr({ x: a, width: 0 }).show() }, d.prototype.endRange = function (a) { var b, c; return this.selectFrom ? (c = Math.min(this.selectFrom, a), b = Math.max(this.selectFrom, a), this.options.rangeSelect.call(this.el, { start: this.data[this.hitTest(c)].x, end: this.data[this.hitTest(b)].x }), this.selectFrom = null) : void 0 }, d.prototype.resizeHandler = function () { return this.timeoutId = null, this.raphael.setSize(this.el.width(), this.el.height()), this.redraw() }, d }(b.EventEmitter), b.parseDate = function (a) { var b, c, d, e, f, g, h, i, j, k, l; return "number" == typeof a ? a : (c = a.match(/^(\d+) Q(\d)$/), e = a.match(/^(\d+)-(\d+)$/), f = a.match(/^(\d+)-(\d+)-(\d+)$/), h = a.match(/^(\d+) W(\d+)$/), i = a.match(/^(\d+)-(\d+)-(\d+)[ T](\d+):(\d+)(Z|([+-])(\d\d):?(\d\d))?$/), j = a.match(/^(\d+)-(\d+)-(\d+)[ T](\d+):(\d+):(\d+(\.\d+)?)(Z|([+-])(\d\d):?(\d\d))?$/), c ? new Date(parseInt(c[1], 10), 3 * parseInt(c[2], 10) - 1, 1).getTime() : e ? new Date(parseInt(e[1], 10), parseInt(e[2], 10) - 1, 1).getTime() : f ? new Date(parseInt(f[1], 10), parseInt(f[2], 10) - 1, parseInt(f[3], 10)).getTime() : h ? (k = new Date(parseInt(h[1], 10), 0, 1), 4 !== k.getDay() && k.setMonth(0, 1 + (4 - k.getDay() + 7) % 7), k.getTime() + 6048e5 * parseInt(h[2], 10)) : i ? i[6] ? (g = 0, "Z" !== i[6] && (g = 60 * parseInt(i[8], 10) + parseInt(i[9], 10), "+" === i[7] && (g = 0 - g)), Date.UTC(parseInt(i[1], 10), parseInt(i[2], 10) - 1, parseInt(i[3], 10), parseInt(i[4], 10), parseInt(i[5], 10) + g)) : new Date(parseInt(i[1], 10), parseInt(i[2], 10) - 1, parseInt(i[3], 10), parseInt(i[4], 10), parseInt(i[5], 10)).getTime() : j ? (l = parseFloat(j[6]), b = Math.floor(l), d = Math.round(1e3 * (l - b)), j[8] ? (g = 0, "Z" !== j[8] && (g = 60 * parseInt(j[10], 10) + parseInt(j[11], 10), "+" === j[9] && (g = 0 - g)), Date.UTC(parseInt(j[1], 10), parseInt(j[2], 10) - 1, parseInt(j[3], 10), parseInt(j[4], 10), parseInt(j[5], 10) + g, b, d)) : new Date(parseInt(j[1], 10), parseInt(j[2], 10) - 1, parseInt(j[3], 10), parseInt(j[4], 10), parseInt(j[5], 10), b, d).getTime()) : new Date(parseInt(a, 10), 0, 1).getTime()) }, b.Hover = function () { function c(c) { null == c && (c = {}), this.options = a.extend({}, b.Hover.defaults, c), this.el = a("<div class='" + this.options["class"] + "'></div>"), this.el.hide(), this.options.parent.append(this.el) } return c.defaults = { "class": "morris-hover morris-default-style" }, c.prototype.update = function (a, b, c, d) { return a ? (this.html(a), this.show(), this.moveTo(b, c, d)) : this.hide() }, c.prototype.html = function (a) { return this.el.html(a) }, c.prototype.moveTo = function (a, b, c) { var d, e, f, g, h, i; return h = this.options.parent.innerWidth(), g = this.options.parent.innerHeight(), e = this.el.outerWidth(), d = this.el.outerHeight(), f = Math.min(Math.max(0, a - e / 2), h - e), null != b ? c === !0 ? (i = b - d / 2, 0 > i && (i = 0)) : (i = b - d - 10, 0 > i && (i = b + 10, i + d > g && (i = g / 2 - d / 2))) : i = g / 2 - d / 2, this.el.css({ left: f + "px", top: parseInt(i) + "px" }) }, c.prototype.show = function () { return this.el.show() }, c.prototype.hide = function () { return this.el.hide() }, c }(), b.Line = function (a) { function c(a) { return this.hilight = f(this.hilight, this), this.onHoverOut = f(this.onHoverOut, this), this.onHoverMove = f(this.onHoverMove, this), this.onGridClick = f(this.onGridClick, this), this instanceof b.Line ? void c.__super__.constructor.call(this, a) : new b.Line(a) } return h(c, a), c.prototype.init = function () { return "always" !== this.options.hideHover ? (this.hover = new b.Hover({ parent: this.el }), this.on("hovermove", this.onHoverMove), this.on("hoverout", this.onHoverOut), this.on("gridclick", this.onGridClick)) : void 0 }, c.prototype.defaults = { lineWidth: 3, pointSize: 4, lineColors: ["#0b62a4", "#7A92A3", "#4da74d", "#afd8f8", "#edc240", "#cb4b4b", "#9440ed"], pointStrokeWidths: [1], pointStrokeColors: ["#ffffff"], pointFillColors: [], smooth: !0, xLabels: "auto", xLabelFormat: null, xLabelMargin: 24, hideHover: !1, trendLine: !1, trendLineWidth: 2, trendLineColors: ["#689bc3", "#a2b3bf", "#64b764"] }, c.prototype.calc = function () { return this.calcPoints(), this.generatePaths() }, c.prototype.calcPoints = function () { var a, b, c, d, e, f; for (e = this.data, f = [], c = 0, d = e.length; d > c; c++) a = e[c], a._x = this.transX(a.x), a._y = function () { var c, d, e, f; for (e = a.y, f = [], c = 0, d = e.length; d > c; c++) b = e[c], f.push(null != b ? this.transY(b) : b); return f }.call(this), f.push(a._ymax = Math.min.apply(Math, [this.bottom].concat(function () { var c, d, e, f; for (e = a._y, f = [], c = 0, d = e.length; d > c; c++) b = e[c], null != b && f.push(b); return f }()))); return f }, c.prototype.hitTest = function (a) { var b, c, d, e, f; if (0 === this.data.length) return null; for (f = this.data.slice(1), b = d = 0, e = f.length; e > d && (c = f[b], !(a < (c._x + this.data[b]._x) / 2)) ; b = ++d); return b }, c.prototype.onGridClick = function (a, b) { var c; return c = this.hitTest(a), this.fire("click", c, this.data[c].src, a, b) }, c.prototype.onHoverMove = function (a) { var b; return b = this.hitTest(a), this.displayHoverForRow(b) }, c.prototype.onHoverOut = function () { return this.options.hideHover !== !1 ? this.displayHoverForRow(null) : void 0 }, c.prototype.displayHoverForRow = function (a) { var b; return null != a ? ((b = this.hover).update.apply(b, this.hoverContentForRow(a)), this.hilight(a)) : (this.hover.hide(), this.hilight()) }, c.prototype.hoverContentForRow = function (a) { var b, c, d, e, f, g, h; for (d = this.data[a], b = "<div class='morris-hover-row-label'>" + d.label + "</div>", h = d.y, c = f = 0, g = h.length; g > f; c = ++f) e = h[c], this.options.labels[c] !== !1 && (b += "<div class='morris-hover-point' style='color: " + this.colorFor(d, c, "label") + "'>\n  " + this.options.labels[c] + ":\n  " + this.yLabelFormat(e) + "\n</div>"); return "function" == typeof this.options.hoverCallback && (b = this.options.hoverCallback(a, this.options, b, d.src)), [b, d._x, d._ymax] }, c.prototype.generatePaths = function () { var a, c, d, e; return this.paths = function () { var f, g, h, j; for (j = [], c = f = 0, g = this.options.ykeys.length; g >= 0 ? g > f : f > g; c = g >= 0 ? ++f : --f) e = "boolean" == typeof this.options.smooth ? this.options.smooth : (h = this.options.ykeys[c], i.call(this.options.smooth, h) >= 0), a = function () { var a, b, e, f; for (e = this.data, f = [], a = 0, b = e.length; b > a; a++) d = e[a], void 0 !== d._y[c] && f.push({ x: d._x, y: d._y[c] }); return f }.call(this), j.push(a.length > 1 ? b.Line.createPath(a, e, this.bottom) : null); return j }.call(this) }, c.prototype.draw = function () { var a; return ((a = this.options.axes) === !0 || "both" === a || "x" === a) && this.drawXAxis(), this.drawSeries(), this.options.hideHover === !1 ? this.displayHoverForRow(this.data.length - 1) : void 0 }, c.prototype.drawXAxis = function () { var a, c, d, e, f, g, h, i, j, k, l = this; for (h = this.bottom + this.options.padding / 2, f = null, e = null, a = function (a, b) { var c, d, g, i, j; return c = l.drawXAxisLabel(l.transX(b), h, a), j = c.getBBox(), c.transform("r" + -l.options.xLabelAngle), d = c.getBBox(), c.transform("t0," + d.height / 2 + "..."), 0 !== l.options.xLabelAngle && (i = -.5 * j.width * Math.cos(l.options.xLabelAngle * Math.PI / 180), c.transform("t" + i + ",0...")), d = c.getBBox(), (null == f || f >= d.x + d.width || null != e && e >= d.x) && d.x >= 0 && d.x + d.width < l.el.width() ? (0 !== l.options.xLabelAngle && (g = 1.25 * l.options.gridTextSize / Math.sin(l.options.xLabelAngle * Math.PI / 180), e = d.x - g), f = d.x - l.options.xLabelMargin) : c.remove() }, d = this.options.parseTime ? 1 === this.data.length && "auto" === this.options.xLabels ? [[this.data[0].label, this.data[0].x]] : b.labelSeries(this.xmin, this.xmax, this.width, this.options.xLabels, this.options.xLabelFormat) : function () { var a, b, c, d; for (c = this.data, d = [], a = 0, b = c.length; b > a; a++) g = c[a], d.push([g.label, g.x]); return d }.call(this), d.reverse(), k = [], i = 0, j = d.length; j > i; i++) c = d[i], k.push(a(c[0], c[1])); return k }, c.prototype.drawSeries = function () { var a, b, c, d, e, f; for (this.seriesPoints = [], a = b = d = this.options.ykeys.length - 1; 0 >= d ? 0 >= b : b >= 0; a = 0 >= d ? ++b : --b) (this.options.trendLine !== !1 && this.options.trendLine === !0 || this.options.trendLine[a] === !0) && this._drawTrendLine(a), this._drawLineFor(a); for (f = [], a = c = e = this.options.ykeys.length - 1; 0 >= e ? 0 >= c : c >= 0; a = 0 >= e ? ++c : --c) f.push(this._drawPointFor(a)); return f }, c.prototype._drawPointFor = function (a) { var b, c, d, e, f, g; for (this.seriesPoints[a] = [], f = this.data, g = [], d = 0, e = f.length; e > d; d++) c = f[d], b = null, null != c._y[a] && (b = this.drawLinePoint(c._x, c._y[a], this.colorFor(c, a, "point"), a)), g.push(this.seriesPoints[a].push(b)); return g }, c.prototype._drawLineFor = function (a) { var b; return b = this.paths[a], null !== b ? this.drawLinePath(b, this.colorFor(null, a, "line"), a) : void 0 }, c.prototype._drawTrendLine = function (a) { var c, d, e, f, g, h, i, j, k, l, m, n, o, p, q; for (h = 0, k = 0, i = 0, j = 0, f = 0, q = this.data, o = 0, p = q.length; p > o; o++) l = q[o], m = l.x, n = l.y[a], void 0 !== n && (f += 1, h += m, k += n, i += m * m, j += m * n); return c = (f * j - h * k) / (f * i - h * h), d = k / f - c * h / f, e = [{}, {}], e[0].x = this.transX(this.data[0].x), e[0].y = this.transY(this.data[0].x * c + d), e[1].x = this.transX(this.data[this.data.length - 1].x), e[1].y = this.transY(this.data[this.data.length - 1].x * c + d), g = b.Line.createPath(e, !1, this.bottom), g = this.raphael.path(g).attr("stroke", this.colorFor(null, a, "trendLine")).attr("stroke-width", this.options.trendLineWidth) }, c.createPath = function (a, c, d) { var e, f, g, h, i, j, k, l, m, n, o, p, q, r; for (k = "", c && (g = b.Line.gradients(a)), l = { y: null }, h = q = 0, r = a.length; r > q; h = ++q) e = a[h], null != e.y && (null != l.y ? c ? (f = g[h], j = g[h - 1], i = (e.x - l.x) / 4, m = l.x + i, o = Math.min(d, l.y + i * j), n = e.x - i, p = Math.min(d, e.y - i * f), k += "C" + m + "," + o + "," + n + "," + p + "," + e.x + "," + e.y) : k += "L" + e.x + "," + e.y : c && null == g[h] || (k += "M" + e.x + "," + e.y)), l = e; return k }, c.gradients = function (a) { var b, c, d, e, f, g, h, i; for (c = function (a, b) { return (a.y - b.y) / (a.x - b.x) }, i = [], d = g = 0, h = a.length; h > g; d = ++g) b = a[d], null != b.y ? (e = a[d + 1] || { y: null }, f = a[d - 1] || { y: null }, i.push(null != f.y && null != e.y ? c(f, e) : null != f.y ? c(f, b) : null != e.y ? c(b, e) : null)) : i.push(null); return i }, c.prototype.hilight = function (a) { var b, c, d, e, f; if (null !== this.prevHilight && this.prevHilight !== a) for (b = c = 0, e = this.seriesPoints.length - 1; e >= 0 ? e >= c : c >= e; b = e >= 0 ? ++c : --c) this.seriesPoints[b][this.prevHilight] && this.seriesPoints[b][this.prevHilight].animate(this.pointShrinkSeries(b)); if (null !== a && this.prevHilight !== a) for (b = d = 0, f = this.seriesPoints.length - 1; f >= 0 ? f >= d : d >= f; b = f >= 0 ? ++d : --d) this.seriesPoints[b][a] && this.seriesPoints[b][a].animate(this.pointGrowSeries(b)); return this.prevHilight = a }, c.prototype.colorFor = function (a, b, c) { return "function" == typeof this.options.lineColors ? this.options.lineColors.call(this, a, b, c) : "point" === c ? this.options.pointFillColors[b % this.options.pointFillColors.length] || this.options.lineColors[b % this.options.lineColors.length] : "line" === c ? this.options.lineColors[b % this.options.lineColors.length] : this.options.trendLineColors[b % this.options.trendLineColors.length] }, c.prototype.drawXAxisLabel = function (a, b, c) { return this.raphael.text(a, b, c).attr("font-size", this.options.gridTextSize).attr("font-family", this.options.gridTextFamily).attr("font-weight", this.options.gridTextWeight).attr("fill", this.options.gridTextColor) }, c.prototype.drawLinePath = function (a, b, c) { return this.raphael.path(a).attr("stroke", b).attr("stroke-width", this.lineWidthForSeries(c)) }, c.prototype.drawLinePoint = function (a, b, c, d) { return this.raphael.circle(a, b, this.pointSizeForSeries(d)).attr("fill", c).attr("stroke-width", this.pointStrokeWidthForSeries(d)).attr("stroke", this.pointStrokeColorForSeries(d)) }, c.prototype.pointStrokeWidthForSeries = function (a) { return this.options.pointStrokeWidths[a % this.options.pointStrokeWidths.length] }, c.prototype.pointStrokeColorForSeries = function (a) { return this.options.pointStrokeColors[a % this.options.pointStrokeColors.length] }, c.prototype.lineWidthForSeries = function (a) { return this.options.lineWidth instanceof Array ? this.options.lineWidth[a % this.options.lineWidth.length] : this.options.lineWidth }, c.prototype.pointSizeForSeries = function (a) { return this.options.pointSize instanceof Array ? this.options.pointSize[a % this.options.pointSize.length] : this.options.pointSize }, c.prototype.pointGrowSeries = function (a) { return 0 !== this.pointSizeForSeries(a) ? Raphael.animation({ r: this.pointSizeForSeries(a) + 3 }, 25, "linear") : void 0 }, c.prototype.pointShrinkSeries = function (a) { return Raphael.animation({ r: this.pointSizeForSeries(a) }, 25, "linear") }, c }(b.Grid), b.labelSeries = function (c, d, e, f, g) { var h, i, j, k, l, m, n, o, p, q, r; if (j = 200 * (d - c) / e, i = new Date(c), n = b.LABEL_SPECS[f], void 0 === n) for (r = b.AUTO_LABEL_ORDER, p = 0, q = r.length; q > p; p++) if (k = r[p], m = b.LABEL_SPECS[k], j >= m.span) { n = m; break } for (void 0 === n && (n = b.LABEL_SPECS.second), g && (n = a.extend({}, n, { fmt: g })), h = n.start(i), l = []; (o = h.getTime()) <= d;) o >= c && l.push([n.fmt(h), o]), n.incr(h); return l }, c = function (a) { return { span: 60 * a * 1e3, start: function (a) { return new Date(a.getFullYear(), a.getMonth(), a.getDate(), a.getHours()) }, fmt: function (a) { return "" + b.pad2(a.getHours()) + ":" + b.pad2(a.getMinutes()) }, incr: function (b) { return b.setUTCMinutes(b.getUTCMinutes() + a) } } }, d = function (a) { return { span: 1e3 * a, start: function (a) { return new Date(a.getFullYear(), a.getMonth(), a.getDate(), a.getHours(), a.getMinutes()) }, fmt: function (a) { return "" + b.pad2(a.getHours()) + ":" + b.pad2(a.getMinutes()) + ":" + b.pad2(a.getSeconds()) }, incr: function (b) { return b.setUTCSeconds(b.getUTCSeconds() + a) } } }, b.LABEL_SPECS = { decade: { span: 1728e8, start: function (a) { return new Date(a.getFullYear() - a.getFullYear() % 10, 0, 1) }, fmt: function (a) { return "" + a.getFullYear() }, incr: function (a) { return a.setFullYear(a.getFullYear() + 10) } }, year: { span: 1728e7, start: function (a) { return new Date(a.getFullYear(), 0, 1) }, fmt: function (a) { return "" + a.getFullYear() }, incr: function (a) { return a.setFullYear(a.getFullYear() + 1) } }, month: { span: 24192e5, start: function (a) { return new Date(a.getFullYear(), a.getMonth(), 1) }, fmt: function (a) { return "" + a.getFullYear() + "-" + b.pad2(a.getMonth() + 1) }, incr: function (a) { return a.setMonth(a.getMonth() + 1) } }, week: { span: 6048e5, start: function (a) { return new Date(a.getFullYear(), a.getMonth(), a.getDate()) }, fmt: function (a) { return "" + a.getFullYear() + "-" + b.pad2(a.getMonth() + 1) + "-" + b.pad2(a.getDate()) }, incr: function (a) { return a.setDate(a.getDate() + 7) } }, day: { span: 864e5, start: function (a) { return new Date(a.getFullYear(), a.getMonth(), a.getDate()) }, fmt: function (a) { return "" + a.getFullYear() + "-" + b.pad2(a.getMonth() + 1) + "-" + b.pad2(a.getDate()) }, incr: function (a) { return a.setDate(a.getDate() + 1) } }, hour: c(60), "30min": c(30), "15min": c(15), "10min": c(10), "5min": c(5), minute: c(1), "30sec": d(30), "15sec": d(15), "10sec": d(10), "5sec": d(5), second: d(1) }, b.AUTO_LABEL_ORDER = ["decade", "year", "month", "week", "day", "hour", "30min", "15min", "10min", "5min", "minute", "30sec", "15sec", "10sec", "5sec", "second"], b.Area = function (c) { function d(c) { var f; return this instanceof b.Area ? (f = a.extend({}, e, c), this.cumulative = !f.behaveLikeLine, "auto" === f.fillOpacity && (f.fillOpacity = f.behaveLikeLine ? .8 : 1), void d.__super__.constructor.call(this, f)) : new b.Area(c) } var e; return h(d, c), e = { fillOpacity: "auto", behaveLikeLine: !1 }, d.prototype.calcPoints = function () { var a, b, c, d, e, f, g; for (f = this.data, g = [], d = 0, e = f.length; e > d; d++) a = f[d], a._x = this.transX(a.x), b = 0, a._y = function () { var d, e, f, g; for (f = a.y, g = [], d = 0, e = f.length; e > d; d++) c = f[d], this.options.behaveLikeLine ? g.push(this.transY(c)) : (b += c || 0, g.push(this.transY(b))); return g }.call(this), g.push(a._ymax = Math.max.apply(Math, a._y)); return g }, d.prototype.drawSeries = function () { var a, b, c, d, e, f, g, h; for (this.seriesPoints = [], b = this.options.behaveLikeLine ? function () { f = []; for (var a = 0, b = this.options.ykeys.length - 1; b >= 0 ? b >= a : a >= b; b >= 0 ? a++ : a--) f.push(a); return f }.apply(this) : function () { g = []; for (var a = e = this.options.ykeys.length - 1; 0 >= e ? 0 >= a : a >= 0; 0 >= e ? a++ : a--) g.push(a); return g }.apply(this), h = [], c = 0, d = b.length; d > c; c++) a = b[c], this._drawFillFor(a), this._drawLineFor(a), h.push(this._drawPointFor(a)); return h }, d.prototype._drawFillFor = function (a) { var b; return b = this.paths[a], null !== b ? (b += "L" + this.transX(this.xmax) + "," + this.bottom + "L" + this.transX(this.xmin) + "," + this.bottom + "Z", this.drawFilledPath(b, this.fillForSeries(a))) : void 0 }, d.prototype.fillForSeries = function (a) { var b; return b = Raphael.rgb2hsl(this.colorFor(this.data[a], a, "line")), Raphael.hsl(b.h, this.options.behaveLikeLine ? .9 * b.s : .75 * b.s, Math.min(.98, this.options.behaveLikeLine ? 1.2 * b.l : 1.25 * b.l)) }, d.prototype.drawFilledPath = function (a, b) { return this.raphael.path(a).attr("fill", b).attr("fill-opacity", this.options.fillOpacity).attr("stroke", "none") }, d }(b.Line), b.Bar = function (c) {
                    function d(c) { return this.onHoverOut = f(this.onHoverOut, this), this.onHoverMove = f(this.onHoverMove, this), this.onGridClick = f(this.onGridClick, this), this instanceof b.Bar ? void d.__super__.constructor.call(this, a.extend({}, c, { parseTime: !1 })) : new b.Bar(c) } return h(d, c), d.prototype.init = function () { return this.cumulative = this.options.stacked, "always" !== this.options.hideHover ? (this.hover = new b.Hover({ parent: this.el }), this.on("hovermove", this.onHoverMove), this.on("hoverout", this.onHoverOut), this.on("gridclick", this.onGridClick)) : void 0 }, d.prototype.defaults = { barSizeRatio: .75, barGap: 3, barColors: ["#0b62a4", "#7a92a3", "#4da74d", "#afd8f8", "#edc240", "#cb4b4b", "#9440ed"], barOpacity: 1, barRadius: [0, 0, 0, 0], xLabelMargin: 50, horizontal: !1 }, d.prototype.calc = function () { var a; return this.calcBars(), this.options.hideHover === !1 ? (a = this.hover).update.apply(a, this.hoverContentForRow(this.data.length - 1)) : void 0 }, d.prototype.calcBars = function () { var a, b, c, d, e, f, g; for (f = this.data, g = [], a = d = 0, e = f.length; e > d; a = ++d) b = f[a], b._x = this.xStart + this.xSize * (a + .5) / this.data.length, g.push(b._y = function () { var a, d, e, f; for (e = b.y, f = [], a = 0, d = e.length; d > a; a++) c = e[a], f.push(null != c ? this.transY(c) : null); return f }.call(this)); return g }, d.prototype.draw = function () { var a; return ((a = this.options.axes) === !0 || "both" === a || "x" === a) && this.drawXAxis(), this.drawSeries() }, d.prototype.drawXAxis = function () { var a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q; for (b = this.options.horizontal ? this.getYAxisLabelX() : this.getXAxisLabelY(), j = null, i = null, q = [], c = o = 0, p = this.data.length; p >= 0 ? p > o : o > p; c = p >= 0 ? ++o : --o) k = this.data[this.data.length - 1 - c], d = this.options.horizontal ? this.drawYAxisLabel(b, k._x - .5 * this.options.gridTextSize, k.label) : this.drawXAxisLabel(k._x, b, k.label), a = this.options.horizontal ? 0 : this.options.xLabelAngle, n = d.getBBox(), d.transform("r" + -a), e = d.getBBox(), d.transform("t0," + e.height / 2 + "..."), 0 !== a && (h = -.5 * n.width * Math.cos(a * Math.PI / 180), d.transform("t" + h + ",0...")), this.options.horizontal ? (m = e.y, l = e.height, g = this.el.height()) : (m = e.x, l = e.width, g = this.el.width()), (null == j || j >= m + l || null != i && i >= m) && m >= 0 && g > m + l ? (0 !== a && (f = 1.25 * this.options.gridTextSize / Math.sin(a * Math.PI / 180), i = m - f), q.push(this.options.horizontal ? j = m : j = m - this.options.xLabelMargin)) : q.push(d.remove()); return q }, d.prototype.getXAxisLabelY = function () { return this.bottom + (this.options.xAxisLabelTopPadding || this.options.padding / 2) }, d.prototype.drawSeries = function () { var a, b, c, d, e, f, g, h, i, j, k, l, m, n, o; return h = this.options.stacked ? 1 : this.options.ykeys.length, c = this.xSize / this.options.data.length, a = (c * this.options.barSizeRatio - this.options.barGap * (h - 1)) / h, this.options.barSize && (a = Math.min(a, this.options.barSize)), l = c - a * h - this.options.barGap * (h - 1), g = l / 2, o = this.ymin <= 0 && this.ymax >= 0 ? this.transY(0) : null, this.bars = function () { var h, l, p, q; for (p = this.data, q = [], d = h = 0, l = p.length; l > h; d = ++h) i = p[d], e = 0, q.push(function () { var h, l, p, q; for (p = i._y, q = [], j = h = 0, l = p.length; l > h; j = ++h) n = p[j], null !== n ? (o ? (m = Math.min(n, o), b = Math.max(n, o)) : (m = n, b = this.bottom), f = this.xStart + d * c + g, this.options.stacked || (f += j * (a + this.options.barGap)), k = b - m, this.options.verticalGridCondition && this.options.verticalGridCondition(i.x) && (this.options.horizontal ? this.drawBar(this.yStart, this.xStart + d * c, this.ySize, c, this.options.verticalGridColor, this.options.verticalGridOpacity, this.options.barRadius) : this.drawBar(this.xStart + d * c, this.yEnd, c, this.ySize, this.options.verticalGridColor, this.options.verticalGridOpacity, this.options.barRadius)), this.options.stacked && (m -= e), this.options.horizontal ? (this.drawBar(m, f, k, a, this.colorFor(i, j, "bar"), this.options.barOpacity, this.options.barRadius), q.push(e -= k)) : (this.drawBar(f, m, a, k, this.colorFor(i, j, "bar"), this.options.barOpacity, this.options.barRadius), q.push(e += k))) : q.push(null); return q }.call(this)); return q }.call(this) }, d.prototype.colorFor = function (a, b, c) { var d, e; return "function" == typeof this.options.barColors ? (d = { x: a.x, y: a.y[b], label: a.label }, e = { index: b, key: this.options.ykeys[b], label: this.options.labels[b] }, this.options.barColors.call(this, d, e, c)) : this.options.barColors[b % this.options.barColors.length] }, d.prototype.hitTest = function (a, b) { var c; return 0 === this.data.length ? null : (c = this.options.horizontal ? b : a, c = Math.max(Math.min(c, this.xEnd), this.xStart), Math.min(this.data.length - 1, Math.floor((c - this.xStart) / (this.xSize / this.data.length)))) }, d.prototype.onGridClick = function (a, b) { var c; return c = this.hitTest(a), this.fire("click", c, this.data[c].src, a, b) }, d.prototype.onHoverMove = function (a, b) { var c, d; return c = this.hitTest(a, b), (d = this.hover).update.apply(d, this.hoverContentForRow(c)) }, d.prototype.onHoverOut = function () { return this.options.hideHover !== !1 ? this.hover.hide() : void 0 }, d.prototype.hoverContentForRow = function (a) {
                        var b, c, d, e, f, g, h, i; for (d = this.data[a], b = "<div class='morris-hover-row-label'>" + d.label + "</div>", i = d.y, c = g = 0, h = i.length; h > g; c = ++g) f = i[c], this.options.labels[c] !== !1 && (b += "<div class='morris-hover-point' style='color: " + this.colorFor(d, c, "label") + "'>\n  " + this.options.labels[c] + ":\n  " + this.yLabelFormat(f) + "\n</div>");
                        return "function" == typeof this.options.hoverCallback && (b = this.options.hoverCallback(a, this.options, b, d.src)), this.options.horizontal ? (e = this.left + .5 * this.width, f = this.top + (a + .5) * this.height / this.data.length, [b, e, f, !0]) : (e = this.left + (a + .5) * this.width / this.data.length, [b, e])
                    }, d.prototype.drawXAxisLabel = function (a, b, c) { var d; return d = this.raphael.text(a, b, c).attr("font-size", this.options.gridTextSize).attr("font-family", this.options.gridTextFamily).attr("font-weight", this.options.gridTextWeight).attr("fill", this.options.gridTextColor) }, d.prototype.drawBar = function (a, b, c, d, e, f, g) { var h, i; return h = Math.max.apply(Math, g), i = 0 === h || h > d ? this.raphael.rect(a, b, c, d) : this.raphael.path(this.roundedRect(a, b, c, d, g)), i.attr("fill", e).attr("fill-opacity", f).attr("stroke", "none") }, d.prototype.roundedRect = function (a, b, c, d, e) { return null == e && (e = [0, 0, 0, 0]), ["M", a, e[0] + b, "Q", a, b, a + e[0], b, "L", a + c - e[1], b, "Q", a + c, b, a + c, b + e[1], "L", a + c, b + d - e[2], "Q", a + c, b + d, a + c - e[2], b + d, "L", a + e[3], b + d, "Q", a, b + d, a, b + d - e[3], "Z"] }, d
                }(b.Grid), b.Donut = function (c) { function d(c) { this.resizeHandler = f(this.resizeHandler, this), this.select = f(this.select, this), this.click = f(this.click, this); var d = this; if (!(this instanceof b.Donut)) return new b.Donut(c); if (this.options = a.extend({}, this.defaults, c), this.el = a("string" == typeof c.element ? document.getElementById(c.element) : c.element), null === this.el || 0 === this.el.length) throw new Error("Graph placeholder not found."); void 0 !== c.data && 0 !== c.data.length && (this.raphael = new Raphael(this.el[0]), this.options.resize && a(window).bind("resize", function () { return null != d.timeoutId && window.clearTimeout(d.timeoutId), d.timeoutId = window.setTimeout(d.resizeHandler, 100) }), this.setData(c.data)) } return h(d, c), d.prototype.defaults = { colors: ["#0B62A4", "#3980B5", "#679DC6", "#95BBD7", "#B0CCE1", "#095791", "#095085", "#083E67", "#052C48", "#042135"], backgroundColor: "#FFFFFF", labelColor: "#000000", formatter: b.commas, resize: !1 }, d.prototype.redraw = function () { var a, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x; for (this.raphael.clear(), c = this.el.width() / 2, d = this.el.height() / 2, n = (Math.min(c, d) - 10) / 3, l = 0, u = this.values, o = 0, r = u.length; r > o; o++) m = u[o], l += m; for (i = 5 / (2 * n), a = 1.9999 * Math.PI - i * this.data.length, g = 0, f = 0, this.segments = [], v = this.values, e = p = 0, s = v.length; s > p; e = ++p) m = v[e], j = g + i + a * (m / l), k = new b.DonutSegment(c, d, 2 * n, n, g, j, this.data[e].color || this.options.colors[f % this.options.colors.length], this.options.backgroundColor, f, this.raphael), k.render(), this.segments.push(k), k.on("hover", this.select), k.on("click", this.click), g = j, f += 1; for (this.text1 = this.drawEmptyDonutLabel(c, d - 10, this.options.labelColor, 15, 800), this.text2 = this.drawEmptyDonutLabel(c, d + 10, this.options.labelColor, 14), h = Math.max.apply(Math, this.values), f = 0, w = this.values, x = [], q = 0, t = w.length; t > q; q++) { if (m = w[q], m === h) { this.select(f); break } x.push(f += 1) } return x }, d.prototype.setData = function (a) { var b; return this.data = a, this.values = function () { var a, c, d, e; for (d = this.data, e = [], a = 0, c = d.length; c > a; a++) b = d[a], e.push(parseFloat(b.value)); return e }.call(this), this.redraw() }, d.prototype.click = function (a) { return this.fire("click", a, this.data[a]) }, d.prototype.select = function (a) { var b, c, d, e, f, g; for (g = this.segments, e = 0, f = g.length; f > e; e++) c = g[e], c.deselect(); return d = this.segments[a], d.select(), b = this.data[a], this.setLabels(b.label, this.options.formatter(b.value, b)) }, d.prototype.setLabels = function (a, b) { var c, d, e, f, g, h, i, j; return c = 2 * (Math.min(this.el.width() / 2, this.el.height() / 2) - 10) / 3, f = 1.8 * c, e = c / 2, d = c / 3, this.text1.attr({ text: a, transform: "" }), g = this.text1.getBBox(), h = Math.min(f / g.width, e / g.height), this.text1.attr({ transform: "S" + h + "," + h + "," + (g.x + g.width / 2) + "," + (g.y + g.height) }), this.text2.attr({ text: b, transform: "" }), i = this.text2.getBBox(), j = Math.min(f / i.width, d / i.height), this.text2.attr({ transform: "S" + j + "," + j + "," + (i.x + i.width / 2) + "," + i.y }) }, d.prototype.drawEmptyDonutLabel = function (a, b, c, d, e) { var f; return f = this.raphael.text(a, b, "").attr("font-size", d).attr("fill", c), null != e && f.attr("font-weight", e), f }, d.prototype.resizeHandler = function () { return this.timeoutId = null, this.raphael.setSize(this.el.width(), this.el.height()), this.redraw() }, d }(b.EventEmitter), b.DonutSegment = function (a) { function b(a, b, c, d, e, g, h, i, j, k) { this.cx = a, this.cy = b, this.inner = c, this.outer = d, this.color = h, this.backgroundColor = i, this.index = j, this.raphael = k, this.deselect = f(this.deselect, this), this.select = f(this.select, this), this.sin_p0 = Math.sin(e), this.cos_p0 = Math.cos(e), this.sin_p1 = Math.sin(g), this.cos_p1 = Math.cos(g), this.is_long = g - e > Math.PI ? 1 : 0, this.path = this.calcSegment(this.inner + 3, this.inner + this.outer - 5), this.selectedPath = this.calcSegment(this.inner + 3, this.inner + this.outer), this.hilight = this.calcArc(this.inner) } return h(b, a), b.prototype.calcArcPoints = function (a) { return [this.cx + a * this.sin_p0, this.cy + a * this.cos_p0, this.cx + a * this.sin_p1, this.cy + a * this.cos_p1] }, b.prototype.calcSegment = function (a, b) { var c, d, e, f, g, h, i, j, k, l; return k = this.calcArcPoints(a), c = k[0], e = k[1], d = k[2], f = k[3], l = this.calcArcPoints(b), g = l[0], i = l[1], h = l[2], j = l[3], "M" + c + "," + e + ("A" + a + "," + a + ",0," + this.is_long + ",0," + d + "," + f) + ("L" + h + "," + j) + ("A" + b + "," + b + ",0," + this.is_long + ",1," + g + "," + i) + "Z" }, b.prototype.calcArc = function (a) { var b, c, d, e, f; return f = this.calcArcPoints(a), b = f[0], d = f[1], c = f[2], e = f[3], "M" + b + "," + d + ("A" + a + "," + a + ",0," + this.is_long + ",0," + c + "," + e) }, b.prototype.render = function () { var a = this; return this.arc = this.drawDonutArc(this.hilight, this.color), this.seg = this.drawDonutSegment(this.path, this.color, this.backgroundColor, function () { return a.fire("hover", a.index) }, function () { return a.fire("click", a.index) }) }, b.prototype.drawDonutArc = function (a, b) { return this.raphael.path(a).attr({ stroke: b, "stroke-width": 2, opacity: 0 }) }, b.prototype.drawDonutSegment = function (a, b, c, d, e) { return this.raphael.path(a).attr({ fill: b, stroke: c, "stroke-width": 3 }).hover(d).click(e) }, b.prototype.select = function () { return this.selected ? void 0 : (this.seg.animate({ path: this.selectedPath }, 150, "<>"), this.arc.animate({ opacity: 1 }, 150, "<>"), this.selected = !0) }, b.prototype.deselect = function () { return this.selected ? (this.seg.animate({ path: this.path }, 150, "<>"), this.arc.animate({ opacity: 0 }, 150, "<>"), this.selected = !1) : void 0 }, b }(b.EventEmitter)
            }).call(this);


            Morris.Bar({
                element: 'morris-bar-chart-4',
                //Data Sample
                //data: [
                //  { y: '123456789abcdefghijklmnopqrstuvwxyz', a: 10, b: 30, c: 30, d: 30, f: 29 },
                //  { y: 'Project 7', a: 100, b: 20, c: 30, d: 30, e: 30 },
                //  { y: 'Project 6', a: 75, b: 45, c: 60, e: 15, g: 0 },
                //  { y: 'Project 5', a: 50, b: 20, d: 50, f: 70, g: 10 },
                //  { y: 'Project 4', a: 75, b: 35, c: 00, f: 50, h: 80 },
                //  { y: 'Project 3', a: 50, b: 30, c: 40, g: 20, h: 20 },
                //  { y: 'Project 2', a: 75, b: 25, c: 80, d: 00, e: 30 },
                //  { y: 'Project 1', a: 50, b: 20, d: 80, f: 40, g: 60 }
                //],
                //ykeys: ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'],
                //xkey: 'y',
                //ykeys: ProjectDataArr,
                //labels: ['Car', 'Pick Up', 'Trailer', 'Mini van', 'Bus', 'SUV', 'Bike', 'Crane'],

                //DataFrom DB
                data: ProjectVhclDataBarChart,
                xkey: 'PROJECT',
                ykeys: vhclDataArr,
                labels: vhclDataArr,
                barColors: ColorLisArr,
                ////barColors: ["#5b9bd5", "#ee7c30", "#a5a5a5", "#ffc000", "#4472c4", "#6eac45", "#ce26fe", "#9e480e", "#d6f316", "#ff91df"],
                horizontal: true,
                stacked: true,
                resize: true,
                gridTextFamily: 'Calibri',
                yLabelFormat: function (y) { return y != Math.round(y) ? '' : y; }
                //gridIntegers: true,
                // ymin: 0,

            });
        }
        function LoadVioMonthwise() {

            var ViolationData = document.getElementById("<%=hiddenViolationData.ClientID%>").value;
            var ViolationDataBarChart = "";
            if (ViolationData != "") {
                ViolationDataBarChart = ConvertToJson(ViolationData);
            }
            else {
                ViolationDataBarChart = [{
                    MONTH: '0',
                    Settled: '0',
                    Pending: 0
                }]
            }

            // Bar Chart
            Morris.Bar({
                element: 'divViolations',
             
                data: ViolationDataBarChart,
                //xkey: 'device',
                //ykeys: ['geekbench'],
                //labels: ['Geekbench'],
                barRatio: 0.7,
                xLabelAngle: 90,
                hideHover: 'auto',
                // resize: true,
                xkey: 'MONTH',
                ykeys: ['Settled', 'Pending'],
                labels: ['Settled', 'Pending'],
                resize: true,
                barColors: ["#5b9bd5", "#ed7d31", "#a4a4a4"],
                hideHover: true,
                stacked: true,
                gridTextFamily: 'Calibri'
            });
        }


        function LoadVhclByClass() {


            var TypeData = document.getElementById("<%=hiddenVehicleByTypeData.ClientID%>").value;
            var VehicleByTypeData = [{
                'CLASS NAME': '0',
                'COUNT': '0',
            }];
            if (TypeData != "") {
                VehicleByTypeData = ConvertToJson(TypeData);
            }
            // Bar Chart
            Morris.Bar({
                element: 'divVehicleByType',
                //data: [{
                //    device: 'iPhone',
                //    geekbench: 136
                //}, {
                //    device: 'iPhone 3G',
                //    geekbench: 137
                //}, {
                //    device: 'iPhone 3GS',
                //    geekbench: 275
                //}, {
                //    device: 'iPhone 4',
                //    geekbench: 380
                //}, {
                //    device: 'iPhone 4S',
                //    geekbench: 655
                //}, {
                //    year: 'iPhone 5',
                //    geekbench: 1571
                //}],
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
                //barColors: ["#5b9bd5", "#ed7d31", "#a4a4a4"],
                gridTextFamily: 'Calibri',
                

            });
            $MstrnoCon('#divVehicleByType svg').height(538);
        }


        function LoadGraph(Mode) {
            var $NonCon = jQuery.noConflict();
            var OrgId = '<%= Session["ORGID"] %>';
            var CorpId = '<%= Session["CORPOFFICEID"] %>';
            var BarType = 0;
            var FromYear = 0;
            var ToYear = 0;
            var ToMonth = 0;
            var FromMonth = 0;
            var divToLoadChart = "";
            if (Mode == "Insu") {
                var BarType = 0;
                 FromYear = document.getElementById("<%=ddlFromYearInsu.ClientID%>").value;
                 ToYear = document.getElementById("<%=ddlToYearInsu.ClientID%>").value;
                 ToMonth = document.getElementById("<%=ddlToMonthInsu.ClientID%>").value;
                FromMonth = document.getElementById("<%=ddlFromMonthInsu.ClientID%>").value;
                divToLoadChart = "divInsuBarChart";
            }
            else {
                BarType = 1;
                 FromYear = document.getElementById("<%=ddlFromYearPermit.ClientID%>").value;
                 ToYear = document.getElementById("<%=ddlToYearPermit.ClientID%>").value;
                 ToMonth = document.getElementById("<%=ddlToMonthPermit.ClientID%>").value;
                FromMonth = document.getElementById("<%=ddlFromMonthPermit.ClientID%>").value;
                divToLoadChart = "divIstimaraBarChart";
            }
            $NonCon.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "Compzit_Home_Awms.aspx/GenerateBarChart",
                data: '{OrgId:"' + OrgId + '" ,CorpId: "' + CorpId + '",FromYear:"' + FromYear + '",ToYear:"' + ToYear + '",ToMonth:"' + ToMonth + '",FromMonth:"' + FromMonth + '",BarType:"' + BarType + '"}',
                dataType: "json",
                success: function (data) {
                    if (data.d != "") {
                        // jQuery('#ReportTable').append(data.d);
                        DynamicBarChart(data.d, divToLoadChart)
                    }
                    else {
                        document.getElementById(divToLoadChart).innerHTML = "No data available";
                    }
                }
            });
            return false;
        }
        function DynamicBarChart(dynamicBarData, divIdBarChart) {
            var jsonDynamicBarData = "";
            if (dynamicBarData != "") {
                jsonDynamicBarData = ConvertToJson(dynamicBarData);
            }
            else {
                jsonDynamicBarData = "";
            }
            document.getElementById(divIdBarChart).innerHTML = "";
            // Bar Chart
            Morris.Bar({
                element: divIdBarChart,
                data: jsonDynamicBarData,
                xkey: 'DATE',
                ykeys: ['COUNT'],
                labels: ['COUNT'],
                barRatio: 0.7,
                xLabelAngle: 90,
                hideHover: 'auto',
                resize: true,
                yLabelFormat: function (y) { return y != Math.round(y) ? '' : y; },
                gridTextFamily: 'Calibri'
                //gridIntegers: true,
                //ymin: 0
            });
        }
        function LoadVehicleList() {
            window.location.href = "/AWMS/AWMS_Master/gen_Vehicle_Master/gen_Vehicle_Master_List.aspx";
        }
        function LoadViolationList() {
            window.location.href = "/AWMS/AWMS_Transaction/gen_Traffic_Violation/gen_Traffic_Violation_List.aspx";
        }
        function LoadVehicleStatusMangmnt() {
            window.location.href = "/AWMS/AWMS_Master/gen_Vehicle_Status_Management/gen_Vehicle_Status_Management.aspx";
        }
        function LoadVehicleRenewal(mode) {
            if (mode == 'Permit') {
                if (document.getElementById('divIstimaraBarChart').innerHTML != "No data available") {
                    window.location.href = "/AWMS/AWMS_Master/gen_Insurance_and_PermitRenewal/gen_Insurance_and_PermitRenewal.aspx";
                }
            }
            else {
                if (document.getElementById('divInsuBarChart').innerHTML != "No data available") {
                    window.location.href = "/AWMS/AWMS_Master/gen_Insurance_and_PermitRenewal/gen_Insurance_and_PermitRenewal.aspx";
                }
            }
            
        }
        function LoadDutyRoster() {
            window.location.href = "/AWMS/AWMS_Master/gen_Duty_Roster/gen_Duty_Roster.aspx";
        }
    </script>

    <script>
        var LoadScrollData = 0;
       
        $noCon(function () {
            $noCon(window).scroll(function () {
               // alert($noCon(document).height() + " top " + $noCon(window).scrollTop());
                if ($noCon(window).scrollTop() >5) {
                   // alert($noCon(window).scrollTop());
                    if (LoadScrollData < 1) {
                        LoadScrollData++;
                       //alert('header just passed.');
                       LoadGraph('Insu');
                       LoadGraph('Permit');
                       LoadVhclByClass();
                       LoadVioMonthwise();
                       LoadVhclAllotment();
                       
                   }
                }
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <%--OLD DATA BEFORE MOD--%>

    <%-- <asp:HiddenField ID="hiddenMixedTeamId" runat="server" />
        <asp:HiddenField ID="hiddenUserId" runat="server" />
        <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
        <asp:HiddenField ID="hiddenCorporateId" runat="server" />--%>
    <%--OLD DATA BEFORE MOD ENDS--%>
    <asp:HiddenField ID="hiddenVehicleByYearData" runat="server" />
    <asp:HiddenField ID="hiddenVehicleByTypeData" runat="server" />
    <asp:HiddenField ID="hiddenVhclByServiceDataPie" runat="server" />
    <asp:HiddenField ID="hiddenViolationData" runat="server" />
    <asp:HiddenField ID="hiddenDriverAvailChart" runat="server" />
        <asp:HiddenField ID="HiddenProjectVhclData" runat="server" />
         <asp:HiddenField ID="HiddenProjectData" runat="server" />     
    <asp:HiddenField ID="HiddenVhclData" runat="server" />
     <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <asp:HiddenField ID="HiddenColorList" runat="server" />
    
    <div class="cont_rght" style="width: 100%">
        <div class="sect250">
            <div class="row">
                <h2 style="margin-left: 3%;color: #000;">VEHICLE DETAILS</h2>
                <div class="col-xs-12" id="divVehicleDetails" runat="server" style="margin-left: 1%;">
                    <table class="main_table_5" cellspacing="0" cellpadding="2px">
                        <thead>
                            <tr class="main_table_5_head">
                                <th class="th1_5">SL#</th>

                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="td1_5">1</td>
                            </tr>
                            <tr>
                                <td class="td1_5">2</td>
                            </tr>
                            <tr>
                                <td class="td1_5">3</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <!-- GRAPH START-->
        <div id="wrapper">


            <div id="page-wrapper">

                <div class="container-fluid" style="font-family: calibri;">



                    <div class="row">
                        <div class="col-lg-4">
                            <div class="panelouter">
                                <div class="panel ">
                                    <div class="panel-heading">
                                        <h3 class="panel-title" style=" font-weight: bold;">VEHICLE BY YEAR</h3>
                                    </div>
                                    <div class="panel-body">
                                        <div id="divVehiclesCount" onclick="LoadVehicleList();" style="cursor: pointer;"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="panelouter">
                                <div class="panel ">
                                    <div class="panel-heading">
                                        <h3 class="panel-title" style=" font-weight: bold;">VEHICLE AVAILABILITY CHART</h3>
                                    </div>
                                    <div class="panel-body">
                                        <div class="flot-chart">
                                            <div class="flot-chart-content" onclick="LoadVehicleList();" style="cursor: pointer;" id="flot-pie-chart"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="panelouter">
                                <div class="panel ">
                                    <div class="panel-heading">
                                        <h3 class="panel-title" style=" font-weight: bold;">DRIVER AVAILABILITY CHART</h3>
                                    </div>
                                    <div class="panel-body">
                                        <div class="flot-chart">
                                            <div class="flot-chart-content" onclick="LoadDutyRoster();" style="cursor: pointer;" id="flot-pie-chart-2"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <!-- /.row -->

                    <div class="row">
                        <div class="col-lg-6">
                            <div class="panelouter">
                                <div class="panel ">
                                    <div class="panel-heading">
                                        <h3 class="panel-title" style=" font-weight: bold;">VEHICLE BY CLASS</h3>
                                    </div>
                                    <div class="panel-body">
                                        <div id="divVehicleByType" onclick="LoadVehicleList();" style="cursor: pointer;"></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-6">
                            <div class="panelouter">
                                <div class="panel ">
                                    <div class="panel-heading">
                                        <h3 class="panel-title" style=" font-weight: bold;">VIOLATIONS-MONTH WISE</h3>
                                    </div>
                                    <div class="panel-body">
                                        <div id="divViolations" onclick="LoadViolationList();"  style="cursor: pointer;"></div>
                                    </div>
                                </div>
                                 <div class="panel scroll-y" runat="server" id="divViolationTbl">
                            <table class=" table2 table-bordered" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>&nbsp;</th>
                                        <th>JAN</th>
                                        <th>FEB</th>
                                        <th>MAR</th>
                                        <th>APR</th>
                                        <th>MAY</th>
                                        <th>JUN</th>
                                        <th>JUL</th>
                                        <th>AUG</th>
                                        <th>SEP</th>
                                        <th>OCT</th>
                                        <th>NOV</th>
                                        <th>DEC</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th><span class="vhcle_color" style="background:#5b9bd5"></span> Pending</th>
                                        <td>0</td>
                                        <td>1</td>
                                        <td>2</td>
                                        <td>3</td>
                                        <td>1</td>
                                        <td>1</td>
                                        <td>5</td>
                                        <td>6</td>
                                        <td>4</td>
                                        <td>5</td>
                                        <td>6</td>
                                        <td>7</td>
                                    </tr>
                                    <tr>
                                        <th><span class="vhcle_color" style="background:#ed7d31"></span> Settled</th>
                                        <td>2</td>
                                        <td>0</td>
                                        <td>1</td>
                                        <td>3</td>
                                        <td>7</td>
                                        <td>4</td>
                                        <td>5</td>
                                        <td>6</td>
                                        <td>5</td>
                                        <td>1</td>
                                        <td>4</td>
                                        <td>6</td>
                                    </tr>
                                    <tr>
                                        <th><span class="vhcle_color" style="background:#a4a4a4"></span> Total Amount</th>
                                        <td>2</td>
                                        <td>0</td>
                                        <td>4</td>
                                        <td>1</td>
                                        <td>5</td>
                                        <td>6</td>
                                        <td>3</td>
                                        <td>7</td>
                                        <td>5</td>
                                        <td>1</td>
                                        <td>4</td>
                                        <td>6</td>
                                    </tr>
                                </tbody>
                            </table>
                            </div>
                            </div>
                        </div>

                    </div>
                    <!-- /.row -->



                    <div class="row">

                        <div class="col-lg-12">
                            <div class="panelouter">
                                <div class="panel ">
                                    <div class="panel-heading">
                                        <h3 class="panel-title" style=" font-weight: bold;">VEHICLE ALLOTMENT CHART</h3>
                                    </div>
                                    <div class="panel-body">
                                        <div id="morris-bar-chart-4" onclick="LoadVehicleStatusMangmnt();" style="cursor: pointer;"></div>
                                    </div>
                                </div>
                                  <div class="panel  scroll-y" id="divTblVhclAllotmentTbl" runat="server">
                            <table class=" table2 table-bordered"  cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>&nbsp;</th>
                                        <th>Project 1</th>
                                        <th>Project 2</th>
                                        <th>Project 3</th>
                                        <th>Project 4</th>
                                        <th>Project 5</th>
                                        <th>Project 6</th>
                                        <th>Project 7</th>
                                        <th>Project 8</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th><span class="vhcle_color" style="background:#5b9bd5"></span> car</th>
                                        <td>0</td>
                                        <td>1</td>
                                        <td>2</td>
                                        <td>3</td>
                                        <td>4</td>
                                        <td>5</td>
                                        <td>6</td>
                                        <td>7</td>
                                    </tr>
                                    <tr>
                                        <th><span class="vhcle_color" style="background:#ee7c30"></span> Pickup</th>
                                        <td>2</td>
                                        <td>0</td>
                                        <td>3</td>
                                        <td>7</td>
                                        <td>5</td>
                                        <td>1</td>
                                        <td>4</td>
                                        <td>6</td>
                                    </tr>
                                    <tr>
                                        <th><span class="vhcle_color" style="background:#ffc000"></span> MiniVan</th>
                                        <td>7</td>
                                        <td>4</td>
                                        <td>0</td>
                                        <td>3</td>
                                        <td>5</td>
                                        <td>6</td>
                                        <td>2</td>
                                        <td>1</td>
                                    </tr>
                                    <tr>
                                        <th><span class="vhcle_color" style="background:#4472c4"></span> Bus</th>
                                        <td>1</td>
                                        <td>5</td>
                                        <td>6</td>
                                        <td>2</td>
                                        <td>7</td>
                                        <td>0</td>
                                        <td>4</td>
                                        <td>3</td>
                                    </tr>
                                </tbody>
                            </table>
                            </div>
                            </div>
                        </div>

                    </div>
                    <!-- /.row -->



                </div>
                <!-- /.container-fluid -->

            </div>
            <!-- /#page-wrapper -->

        </div>
        <!-- GRAPH START-->
            <!-- GRAPH START Akhil Anand 07-07-2017-->
                
       <div class="col-lg-6" style="font-family: calibri;">
                    	<div class="panelouter">
                            <div class="panel ">
                                <div class="panel-heading">
                                    <h3 class="panel-title" style=" font-weight: bold;">ISTIMARA EXPIRY</h3>
                                    <br />
                                    
                                    <span class="frm_to_sty">FROM&nbsp;:</span>
                                   
                                            
                                         <asp:DropDownList ID="ddlFromMonthPermit" class="drp_sty" runat="server"></asp:DropDownList>
                                        <asp:DropDownList ID="ddlFromYearPermit" class="drp_sty" runat="server"></asp:DropDownList>
                                       <br /><br />
                                    <span class="frm_to_sty">TO &nbsp;&nbsp;&nbsp;&nbsp;:<span>
                                   
                                           <asp:DropDownList ID="ddlToMonthPermit" class="drp_sty" runat="server"></asp:DropDownList>
                                        <asp:DropDownList ID="ddlToYearPermit" class="drp_sty" runat="server"></asp:DropDownList>
                                      <br />
                                      <button class="Gene_sty" style="margin-left: 11%;width: 61%;" onclick="return LoadGraph('Permit');">Generate</button> 
                                         <%--<asp:Button runat="server" CssClass="Gene_sty" ID="btnGenPremit" Text="Generate" OnClientClick="LoadGraph('Permit');" />--%>
                                         
                                </div><br /><br />
                                <div class="panel-body">
                                    <div id="divIstimaraBarChart"  onclick="LoadVehicleRenewal('Permit');" style="cursor: pointer;"></div>
                                </div>
                            </div>
                        </div>
                    </div> 
                    
                    
                    <div class="col-lg-6" style="font-family: calibri;">
                    	<div class="panelouter">
                            <div class="panel ">
                                <div class="panel-heading">
                                    <h3 class="panel-title" style=" font-weight: bold;">INSURANCE EXPIRY</h3>
                                    
                                    <br />
                                    
                                    <span class="frm_to_sty">FROM&nbsp;:</span>
                                 
                                   
                                        <asp:DropDownList ID="ddlFromMonthInsu" class="drp_sty" runat="server"></asp:DropDownList>
                                        <asp:DropDownList ID="ddlFromYearInsu" class="drp_sty" runat="server"></asp:DropDownList>
                                       <br /><br />
                                    <span class="frm_to_sty">TO &nbsp;&nbsp;&nbsp;&nbsp;:<span>
                                   
                                             <asp:DropDownList ID="ddlToMonthInsu" class="drp_sty" runat="server"></asp:DropDownList>
                                        <asp:DropDownList ID="ddlToYearInsu" class="drp_sty" runat="server"></asp:DropDownList>
                                      <br />
                                          <button class="Gene_sty" style="margin-left: 11%;width: 61%;" onclick="return LoadGraph('Insu');">Generate</button> 
                                    <%--<asp:Button runat="server" CssClass="Gene_sty" ID="btnGenInsu" OnClientClick="LoadGraph('Insu');" Text="Generate"  />--%>
                                </div><br /><br />
                                <div class="panel-body">
                                    <div id="divInsuBarChart" onclick="LoadVehicleRenewal('Insu');" style="cursor: pointer;"></div>
                                </div>
                            </div>
                        </div>
                    </div> 
    
           <!-- closed Akhil Anand GRAPH START 07-07-2017-->



        <div class="sect250">
            <div class="row">
                <h2 style="margin-left: 3%;color: #000;">WATER CARD DETAILS</h2>
                <div class="col-xs-12" id="divWaterCardDeatils" runat="server" style="margin-left: 1%;">
                    <table class="main_table_6" cellspacing="0" cellpadding="2px">
                        <thead>
                            <tr class="main_table_6_head">
                                <th class="th1_6">SL#</th>
                                <th class="th2_6">Water Card Number</th>
                                <th class="th3_6">Bank Name</th>
                                <th class="th4_6">Balance Amount</th>
                                <th class="th5_6">Expiry Date</th>
                                <th class="th6_6">Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="td1_6">1</td>
                                <td class="td2_6">RS 51771</td>
                                <td class="td3_6">TATA</td>
                                <td class="td4_6">XLRB</td>
                                <td class="td5_6">DIESEL</td>
                                <td class="td6_6">PRIVATE</td>
                            </tr>
                            <tr>
                                <td class="td1_6">2</td>
                                <td class="td2_6">RS 51771</td>
                                <td class="td3_6">TATA</td>
                                <td class="td4_6">XLRB</td>
                                <td class="td5_6">DIESEL</td>
                                <td class="td6_6">PRIVATE</td>
                            </tr>
                            <tr>
                                <td class="td1_6">3</td>
                                <td class="td2_6">RS 51771</td>
                                <td class="td3_6">TATA</td>
                                <td class="td4_6">XLRB</td>
                                <td class="td5_6">DIESEL</td>
                                <td class="td6_6">PRIVATE</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>


    </div>
</asp:Content>

