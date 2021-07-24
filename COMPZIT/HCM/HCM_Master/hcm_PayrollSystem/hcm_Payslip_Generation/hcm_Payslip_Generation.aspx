<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Payslip_Generation.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Payslip_Generation_hcm_Payslip_Generation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

     <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>

    <script src="/js/bootstrap/bootstrap.min.js"></script>

    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />

    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />

    <script src="/js/jQueryUI/jquery-ui.min.js"></script>
    <script src="/js/jQueryUI/jquery-ui.js"></script>

    <script src="/js/HCM/Common.js"></script>

    <script>
        var $noCon = jQuery.noConflict();

        $noCon(window).load(function () {

            document.getElementById("<%=ddlMonth.ClientID%>").focus();

        });

        function ValidatePayslip() {

            var ret = true;

            var Month = document.getElementById("<%=ddlMonth.ClientID%>").value;
            var Year = document.getElementById("<%=ddlYear.ClientID%>").value;

            document.getElementById("<%=ddlYear.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlMonth.ClientID%>").style.borderColor = "";

            if (Month == "--SELECT MONTH--") {
                document.getElementById("<%=ddlMonth.ClientID%>").style.borderColor = "Red";
                $noCon("#divDangerAlert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divDangerAlert").fadeTo(2000, 500).slideUp(500, function () {
                    document.getElementById("<%=ddlMonth.ClientID%>").focus();
                    document.getElementById("<%=ddlMonth.ClientID%>").style.borderColor = "Red";
                });
                $noCon(window).scrollTop(0);
                ret = false;
            }

            if (Year == "--SELECT YEAR--") {
                document.getElementById("<%=ddlYear.ClientID%>").style.borderColor = "Red";
                $noCon("#divDangerAlert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divDangerAlert").fadeTo(2000, 500).slideUp(500, function () {
                    document.getElementById("<%=ddlYear.ClientID%>").focus();
                    document.getElementById("<%=ddlYear.ClientID%>").style.borderColor = "Red";
                });
                $noCon(window).scrollTop(0);
                ret = false;
            }


            return ret;
        }


        function SalaryNotPrcsdMessage() {

            $noCon("#divWarningAlert").html("Salary not processed for the respective month and year!");
            $noCon("#divWarningAlert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#divWarningAlert").alert();
           $noCon(window).scrollTop(0);
       }

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:HiddenField ID="hiddenStaffWrkr" runat="server" />

    <div class="alert alert-success" id="divSuccessAlert" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>

    <div class="alert alert-danger" id="divDangerAlert" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>

       <div class="alert alert-warning" id="divWarningAlert" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>

   <div id="main" style="height: 1004px;">
      
      <section id="widget-grid" class="">
           <div class="row">

            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
               <div id="wid-id-0">

        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/PaySlip.png" style="vertical-align: middle;" />
            Payslip Generation
        </div>

        <div class="smart-form" style="float: left; width: 93.5%;">

        <div style="border: .5px solid #9ba48b; background-color: #f3f3f3; width: 98%; margin-top: 2%; padding: 0%; float: left; margin-bottom: 0%;height: 112px;">

                              <div style="width: 100%; float: left;" class="formdiv">

                                     <div style="width: 50%; float: left;">
                                          <section style="width: 95%; margin-left: 5%;">
                                             <label class="lblh2" style="float: left; width: 35%;margin-top:0%;">Employee</label>
                                                 <asp:Label ID="lblEmpName" runat="server" style="width: 55%;"></asp:Label>
                                           </section>
                                     </div>
                                     <div style="width: 50%; float: left;">
                                          <section style="width: 95%; margin-left: 7%;">
                                              <label class="lblh2" style="float: left; width: 35%;margin-top:0%;">Designation</label>
                                                  <asp:Label ID="lblDesgntn" runat="server" style="width: 55%;"></asp:Label>
                                           </section>
                                      </div>

                                </div>

                                <div style="width: 100%; float: left;" class="formdiv">

                                     <div style="width: 50%; float: left;">
                                          <section style="width: 95%; margin-left: 5%;">
                                             <label class="lblh2" style="float: left; width: 35%;margin-top:0%;">Department</label>
                                              <asp:Label ID="lblDeprtmnt" runat="server" style="width: 55%;"></asp:Label>
                                           </section>
                                     </div>

                                     <div style="width: 50%; float: left;">
                                          <section style="width: 95%; margin-left: 7%;">
                                              <label class="lblh2" style="float: left; width: 35%;margin-top:0%;">Division</label>
                                              <asp:Label ID="lblDivsn" runat="server" style="width: 55%;"></asp:Label>
                                           </section>
                                      </div>

                                </div>
            </div>


          <div style="background: white;float:left;width:98%;margin-top: 3%;border: 1px solid;padding: 36px 0px;margin-bottom:0%;">

                 <div style="width: 31%; float: left;margin-top: 1%;">
                    <section style="width: 95%; margin-left: 5%;">
                        <label class="lblh2" style="float: left; width: 35%;">Month*</label>
                        <label class="select" style="float: left; width: 60%;">
                            <asp:DropDownList ID="ddlMonth" CssClass="form-control" class="form1" runat="server" onkeypress="return DisableEnter(event)">
                            </asp:DropDownList>
                        </label>
                    </section>
                </div>

                <div style="width: 31%; float: left;margin-top: 1%;">
                    <section style="width: 95%; margin-left: 5%;">
                        <label class="lblh2" style="float: left; width: 35%;">Year*</label>
                        <label class="select" style="float: left; width: 60%;">
                            <asp:DropDownList ID="ddlYear" CssClass="form-control" class="form1" runat="server" onkeypress="return DisableEnter(event)">
                            </asp:DropDownList>
                        </label>
                    </section>
                </div>

            <div style="float: left;margin-left: 4%;margin-top: 1%;">
                    <asp:Button ID="btnGenerate" Style="cursor: pointer; float: right; margin-right: 10%; padding: 0 22px; font: 300 15px/29px 'Calibri',Helvetica,Arial,sans-serif;" runat="server" class="btn  btn-primary" Text="Generate" OnClick="btnGenerate_Click" OnClientClick="return ValidatePayslip()"  />
             </div>

              <div style="float: left;margin-left: 10%;margin-top: 1%;">
                    <asp:Button ID="btnprint" Style="cursor: pointer; float: right; margin-right: 10%; padding: 0 22px; font: 300 15px/29px 'Calibri',Helvetica,Arial,sans-serif;" runat="server" class="btn  btn-primary" Text="Print" OnClick="btnprint_Click" OnClientClick="return ValidatePayslip()"  />
             </div>




        <div id="divPreview" runat="server" style="width:90%;margin-left:5%;margin-top:10%;">

            <div id="divPayslip" runat="server" style="margin-bottom:1%;">
                  <br />
                  <br />
              </div>

            <div id="divLabourCard" runat="server" >

                <div id="divLabourCardHeader" runat="server" >
                  <br />
                  <br />
               </div>
               <div id="divLabourCardbody" runat="server" style="margin-top:1%;margin-bottom:1%;">
                  <br />
                  <br />
               </div>

           </div>

       </div>

          </div>

        </div>
      </div>

     </article>
    </div>
   </section>

 </div>



<style>
    body
        {
            font-size: 12px;
            font-family: Tahoma,Arial;
            
        }
        .top_row
        {
            font-size: 10px;
            font-weight: Bold;
            text-align:center;
        }
         .thT {
            border-right:solid 1px #939191;
        }
        .section
        {
            font-weight: Bold;
            background-color: #e7e7e7;
        }
        .row1
        {
            
        }
        .D0
        {
            display: none;
        }
        .tab tr td
        {
            padding: 4px 2px;
            border: solid 1px #939191;
            border-collapse: collapse;
        }
        .tab
        {
            border: solid 1px #555555;
            border-collapse: collapse;
            width:96%;
        }
        
        
        a
        {
            color: #000000;
            text-decoration: none;
        }
        
        .hidden1
        {
            display: none;
        }
         .hidden2
        {
            display: none;
        }
        .pagehead
        {
            color: #09045E;
            font-family: calibri,tahoma;
            font-size: 10pt;
            font-weight: bold;
            text-transform: uppercase;
        }
        .bordertop td
        {
            border-top: solid 1px #000000;
        }
        .clear
        {
            clear: both;
            font-size: 0px;
            padding: 0px;
            line-height: 0px;
            height: 0px;
        }
        .table_heading{font-weight:bold}
        .table_heading1{font-weight:bold}
        .table_heading2{font-weight:bold}
        .companyName{font-weight:bold}
         .footersummary
        {
            border-collapse:collapse;
        }
        .footersummary td
        {
            border:#fff solid 1px !important;   
            font-weight:bold;
        }
</style>

</asp:Content>

