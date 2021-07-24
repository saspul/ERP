<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="Compzit_Home_Finance.aspx.cs" Inherits="Home_Compzit_Home_Compzit_Home_Finance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>    
    <script src="/js/Common/Common.js"></script> 
     
   <script>
       $(document).ready(function () {
           $(".wrapper,.d2_con").click(function () {
               $(".d2_con").hide(300);
           });
           $(".d2").mouseover(function () {
               $(".d2_con").show(300);
           });
       });
</script>
<script>
    $(document).ready(function () {
        $(".wrapper,.d1_con").click(function () {
            $(".d1_con").hide(300);
        });
        $(".d1").mouseover(function () {
            $(".d1_con").show(300);
        });
    });
</script>


<script>
    $(document).ready(function () {
        $(".wrapper,.d3_con").click(function () {
            $(".d3_con").hide(300);
        });
        $(".d3").mouseover(function () {
            $(".d3_con").show(300);
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(".wrapper,.d4_con").click(function () {
            $(".d4_con").hide(400);
        });
        $(".d4").mouseover(function () {
            $(".d4_con").show(400);
        });
        if ( document.getElementById("cphMain_divBankBookLdgr").innerHTML == "") {
            $('#myCarousel1 a').css({ "pointer-events": "none" });
        }
        else {
            $('#myCarousel1 a').css({ "pointer-events": "" });
        }
        if (document.getElementById("cphMain_divCashBookLdgr").innerHTML == "") {
        $('#myCarousel a').css({ "pointer-events": "none" });
        }
        else {
        $('#myCarousel a').css({ "pointer-events": "" });
         }

    });
</script>
<script>
    function BankBookBUclick(CorpId, CorpName, Mode) {

        if (Mode == "13") {
            document.getElementById("cphMain_lblBUseleBank").innerHTML = CorpName;
        }
        else {
            document.getElementById("cphMain_lblBUseleCash").innerHTML = CorpName;
        }
        var dateTo = document.getElementById("cphMain_dateCashBook").innerHTML;
        if (CorpId != "" && dateTo != "") {
            $.ajax({
                type: "POST",
                async: false,
                url: "Compzit_Home_Finance.aspx/LoadBankBook",
                data: '{CorpId:"' + CorpId + '",dateTo:"' + dateTo + '",Mode:"' + Mode + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (Mode == "13") {
                        document.getElementById("cphMain_divBankBookLdgr").innerHTML = response.d;
                        if (response.d == "") {
                            $('#myCarousel1 a').css({ "pointer-events": "none" });
                        }
                        else {
                            $('#myCarousel1 a').css({ "pointer-events": "" });
                        }
                    }
                    else {
                        document.getElementById("cphMain_divCashBookLdgr").innerHTML = response.d;
                        if (response.d == "") {
                            $('#myCarousel a').css({ "pointer-events": "none" });
                        }
                        else {
                            $('#myCarousel a').css({ "pointer-events": "" });
                        }
                    }

                },
                failure: function (response) {
                }
            });
        }
        return false;
    }
    function DebtorChange(CurrencyId, CurrencyAbbr,mode) {
        var dateTo = document.getElementById("cphMain_dateCashBook").innerHTML;
        var orgID = '<%= Session["ORGID"] %>';
        if (CurrencyId != "" && dateTo != "" && orgID != "") {
            $.ajax({
                type: "POST",
                async: false,
                url: "Compzit_Home_Finance.aspx/LoadDebtorBu",
                data: '{orgID:"' + orgID + '",dateTo:"' + dateTo + '",CurrencyId:"' + CurrencyId + '",mode:"' + mode + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (mode == "15") {
                        document.getElementById("dtDebBu").innerHTML = response.d;
                    }
                    else {
                        document.getElementById("dtCreBu").innerHTML = response.d;
                    }
                },
                failure: function (response) {
                }
            });
        }
        return false;
    }

    //040
    $(window).ready(function () {
        var EditVal = document.getElementById("<%=HiddenFinancialYear.ClientID%>").value;

        if (EditVal != "") {
            showFinYearr(EditVal);
        }
        Sales();
        Purchase();
        ProfitLoss();
    });


</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">


<asp:HiddenField ID="HiddenFinancialYear" runat="server" /> 


<div class="text3 d4_con" id="dtBankBookBu" runat="server" style="width: 10%;">
</div>
<div class="text3 d3_con" id="dtCashBookBu" runat="server" style="width: 10%;">
</div>

<div class="text3 d1_con" id="dtDebBu">
</div>

<div class="text3 d2_con" id="dtCreBu" >
</div>
   <ol class="breadcrumb">
    <li><a id="aHome" runat="server" href="">Home</a></li>
    <li class="active">Finance Management</li>  
  </ol>

     <div class="myAlert-top alert alert-success" id="success-alert">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Success!</strong> Changes completed succesfully
    </div>

    <div class="myAlert-bottom alert alert-danger" id="divWarning">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Danger!</strong> Request not conmpleted
    </div>

	<div class="content_sec2 cont_contr">
		<div class="content_area_container cont_contr">	
      <div class="contant2">
        <div class="text1">
          <div class="choose1">
           <h3>
            <a class="d3">
              <span class="spn3"><label id="lblBUseleCash" runat="server"> </label> 
                <i class="fa fa-angle-down" aria-hidden="true"></i>
              </span>
            </a>
              <i class="fa fa-sitemap" aria-hidden="true" title="Business Unit"></i>
           </h3>
          </div>
         <div class="clearfix"></div>
          
          <div class="as_on2">CASH BOOK BALANCE AS ON 
            <span class="spn2" id="dateCashBook" runat="server"></span>
          </div>
    <div id="myCarousel" class="carousel slide" data-ride="carousel">

    <!-- Wrapper for slides -->
    <div class="carousel-inner" id="divCashBookLdgr" runat="server">
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
      <span class="fa fa-angle-double-left fa_slide"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" data-slide="next">
      <span class="fa fa-angle-double-right fa_slide"></span>
      <span class="sr-only">Next</span>
    </a>
  </div>
    </div>

        <div class="text2">
          <div class="choose1">
            <h3>
            <a  class="d4">
              <span class="spn3"><label id="lblBUseleBank" runat="server"></label> <i class="fa fa-angle-down" aria-hidden="true"></i></span>
            </a>
                <i class="fa fa-sitemap" aria-hidden="true" title="Business Unit"></i>
            </h3>
          </div>
         <div class="clearfix"></div>

          <div class="as_on2">BANK BOOK BALANCE AS ON <span class="spn2" id="dateBankBook" runat="server"></span>
          </div>


<div id="myCarousel1" class="carousel slide" data-ride="carousel">
     <!-- Wrapper for slides -->
    <div class="carousel-inner" id="divBankBookLdgr" runat="server">
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel1" data-slide="prev">
      <span class="fa fa-angle-double-left fa_slide"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel1" data-slide="next">
      <span class="fa fa-angle-double-right fa_slide"></span>
      <span class="sr-only">Next</span>
    </a>
  </div>



</div>



<div class="text3" id="divDebtor" runat="server">  
  <div class="as_on1"><h5  class="cre2">DEBTORS OUTSTANDING</h5></div>
    <div id="myCarousel2" class="carousel slide" data-ride="">
    <!-- Wrapper for slides -->
    <div class="carousel-inner slas1" id="divDebtorAmnts" runat="server">
      
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control sl_l" href="#myCarousel2" data-slide="prev">
      <span class="fa fa-angle-left fa_slide sl1"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control sl_r" href="#myCarousel2" data-slide="next">
      <span class="fa fa-angle-right fa_slide sl1"></span>
      <span class="sr-only">Next</span>
    </a>
  </div>
    </div>

<div class="text3" id="divCreditor" runat="server">  
  <div class="as_on1"><h5 class="cre1">CREDITORS OUTSTANDING</h5></div>
    <div id="myCarousel3" class="carousel slide" data-ride="">
    <!-- Wrapper for slides -->
    <div class="carousel-inner slas1" id="divCreditorAmnts" runat="server">
     </div>
    

    <!-- Left and right controls -->
    <a class="left carousel-control sl_l" href="#myCarousel3" data-slide="prev">
      <span class="fa fa-angle-left fa_slide sl1"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control sl_r" href="#myCarousel3" data-slide="next">
      <span class="fa fa-angle-right fa_slide sl1"></span>
      <span class="sr-only">Next</span>
    </a>
  </div>
</div>

      

        <div class="clearfix"></div>

        <%--<div class="text_2_1" style="display:none;">--%>
        <div class="text_2_1">
          <h1 class="tr_c"  id="fincyr" ></h1> <%--EVM 040--%>
          <div class="text_3_1">
            <h3 class="tr_c">Profit & Loss Analysis</h3>
            <div class="prs_1">
              <h5>Profit / Loss</h5>
              <span id="dispCurrency"></span><%-- emp-0043--%>
            </div>
            <div class="prs_2">
              <h5 id="dispProfit"></h5>
              <span id="dispAmount"></span>
            </div>
            <div class="prs_1 blink_1">
              <p>Previous year closing not done</p>
            </div>
          </div>
          <div class="text_3_1">
            <h3 class="tr_c">Sales Analysis</h3>
            <div class="prs_1_1">
              <h5>Sales Amount in <span id="sales_abbrv"></span></h5>  <%--EVM 040--%>
            </div>
            <div class="prs_1_2">
              <span id="salestotal"></span>
            </div>
          </div>
          <div class="text_3_1">
            <h3 class="tr_c">Purchase Analysis</h3>
            <div class="prs_1_1">
              <h5>Purchase Amount in <span id="purchase_abbrv"> </span></h5> <%--EVM 040--%>
            </div>
            <div class="prs_1_2">
              <span id="purchasetotal"></span>
            </div>
          </div>
        </div>



    </div>    
  </div>
</div>

    <button class="tog_btn" id="divMainNotf" runat="server" onclick="return false;">
  <i class="fa fa-exclamation-triangle" aria-hidden="true"></i>
  <span class="badge beln cht cht1 pen_b" id="sMainNotfCnt" runat="server"></span>
</button>
<div class="target">
    <div class="pending1" type="button"   data-toggle="modal" data-target="#myrecur" title="Payment Recurring" id="menu1" runat="server" onclick="return recurClick(1);">
  <i class="fa fa-retweet" aria-hidden="true"><i class="fa fa-money ftm" aria-hidden="true"></i></i>
  <span class="badge beln cht cht1 pen_b" id="sPendOrdNum" runat="server"></span>
</div>
    
     <div class="pending1" type="button"   data-toggle="modal" data-target="#myrecur" title="Receipt Recurring" id="menu2" runat="server" onclick="return recurClick(2);">
    <i class="fa fa-retweet" aria-hidden="true"><i class="fa fa-list-alt ftm1" aria-hidden="true"></i></i>
  <span class="badge beln cht cht1 pen_b" id="sPendOrdNumRecp" runat="server"></span>
</div>


   <div class="tar_ico" type="button"  data-toggle="modal" data-target="#myrecur2" title="Receipt Postdated Cheque" id="menu3" runat="server" onclick="return postChequeClick(1);">
    <i class="fa fa-list-alt" aria-hidden="true"></i>
    <span class="badge beln cht cht1 pen_b" id="recpPostNum" runat="server"></span>
  </div>

   <div class="tar_ico" type="button"   data-toggle="modal" data-target="#myrecur2" title="Payment Postdated Cheque" id="menu4" runat="server" onclick="return postChequeClick(2);">
    <i class="fa fa-money" aria-hidden="true"></i>
    <span class="badge beln cht cht1 pen_b" id="payPostNum" runat="server"></span>
  </div>


</div> 

<!-- Modal -->
<div class="modal fade" id="myrecur" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog rec_db" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Pending Actions</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
       <table class="table table-bordered table-fixed">
    <thead class="thead1">
      <tr>
        <th class="td_rec">Date</th>
        <th class="td_rec1">Ref#</th>
        <th class="td_rec">Action</th>
      </tr>
    </thead>
    <tbody id="myTable" runat="server">
     
    </tbody>
    <tbody id="myTable2" runat="server">
     
    </tbody>
  </table>
      </div>
    </div>
  </div>
</div>


 <div class="modal fade" id="myrecur2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog2 rec_db" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="hPostCheque"></h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btncl">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>

      <div class="modal-body">
        <table class="table table-bordered">
          <thead class="thead1">
            <tr>
              <th class="th_b2 tr_l">Ref#</th>
              <th class="th_b2 tr_l">Bank</th>
              <th class="td_b2 tr_l">Party</th>
              <th class="td_b6 tr_l">Cheque#</th>
              <th class="th_b7">Date</th>
              <th class="th_b7 tr_r">Amount </th>
              <th class="th_b2 tr_l">Remark</th>
              <th class="th_b6">Generate</th>
              <th class="th_b6">Paid/Reject</th>
            </tr>
          </thead>
    <tbody id="recpPostTbody" runat="server">
    </tbody>
    <tbody id="payPostTbody" runat="server">
    </tbody>
   </table>
      </div>
    </div>
  </div>
</div>



<div id="pan_l" class="l1">
</div>
    <!---slide toogle of pending Orders--->
<script>
    $(document).ready(function () {
        $(".flip_o").mouseover(function () {
            $(".l1").show("200");
        });
        $(".flip_o").mouseout(function () {
            $(".l1").hide("");
        });
    });


    function RecurReject(strid) { 
        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to reject this item?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {
        var UserId = '<%= Session["USERID"] %>';
        if (strid != "" && UserId != "") {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "Compzit_Home_Finance.aspx/RecurReject",
                        data: '{strid:"' + strid + '",UserId:"' + UserId + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            successReject();
                            window.location.href = "Compzit_Home_Finance.aspx";
                            return false;
                        },
                        failure: function (response) {
                        }
                    });
                }
                return false;
            }
            else {
                return false;
            }
        });
        return false;
    }

    function successReject() {
        $("#success-alert").html("Postdated cheque is rejected successfully.");
        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
        });
        return false;
    }

    function ShowOrderDtls(strid) {
        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        if (strid != "" && CorpId!="") {
            $.ajax({
                type: "POST",
                async: false,
                url: "Compzit_Home_Finance.aspx/ShowOrderDtls",
                data: '{strid:"' + strid + '",CorpId:"' + CorpId + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    document.getElementById("pan_l").innerHTML = response.d;
                },
                failure: function (response) {
                }
            });
        }
        return false;
    }
    $(document).ready(function () {
        $(".wr2").click(function () {
            $(".target").hide(300);
        });
        $(".tog_btn").mouseover(function () {
            $(".target").show(300);
        });
    });

    function recurClick(mode) {
        if (mode == 1) {
            document.getElementById("cphMain_myTable2").style.display = "block";
            document.getElementById("cphMain_myTable").style.display = "none";
            document.getElementById("exampleModalLabel").innerText = "Payment Recurring";
        }
        else {
            document.getElementById("cphMain_myTable2").style.display = "none";
            document.getElementById("cphMain_myTable").style.display = "block";
            document.getElementById("exampleModalLabel").innerText = "Receipt Recurring";
        }
    }
    function postChequeClick(mode) {
        if (mode == 1) {
            document.getElementById("cphMain_recpPostTbody").style.display = "";
            document.getElementById("cphMain_payPostTbody").style.display = "none";
            document.getElementById("hPostCheque").innerText = "Receipt Postdated Cheque";
        }
        else {
            document.getElementById("cphMain_recpPostTbody").style.display = "none";
            document.getElementById("cphMain_payPostTbody").style.display = "";
            document.getElementById("hPostCheque").innerText = "Payment Postdated Cheque";
        }
    }
    function PaidRejctStatusUpdate(ChequeId, ChequeBkId, Status, Mode) {
            var PaymntRecptId = 0;
            var usrId = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
            var TransType = Mode;
            var Msg = "";
            var PaymntReceiptId = document.getElementById("tdPaymntRecptId" + ChequeBkId).value;


            var tdPaymntRecptRef = "";
            if (Status == "1" && PaymntReceiptId == "") {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "Compzit_Home_Finance.aspx/CheckPaymentInserted",
                    data: '{TransType:"' + TransType + '",strCorpID:"' + strCorpID + '",strOrgIdID:"' + strOrgIdID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        tdPaymntRecptRef = response.d;
                    }
                });
            }





            if (Status == "1") {
                if (TransType == "0") {                   
                 if (PaymntReceiptId != "") {
            Msg = "Are you sure you want to mark as paid the payment voucher?";
        }
        else {
         Msg = "Are you sure you want to generate payment voucher with Ref#" + tdPaymntRecptRef + " ?";
        }
                }
                else {
                   if (PaymntReceiptId != "") {
            Msg = "Are you sure you want to mark as paid the receipt voucher?";
        }
        else {
        Msg = "Are you sure you want to generate receipt voucher with Ref#" + tdPaymntRecptRef + "?";
        }
                }
            }
            else if (Status == "2") {
                Msg = "Are you sure you want to mark as rejected?";
            }
            ezBSAlert({
                type: "confirm",
                messageText: Msg,
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    if (ChequeId != '') {

                        $.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "Compzit_Home_Finance.aspx/ChequePaidRejectStatus",
                            data: '{usrId: "' + usrId + '",ChequeId: "' + ChequeId + '",strCorpID: "' + strCorpID + '",strOrgIdID: "' + strOrgIdID + '",ChequeBkId: "' + ChequeBkId + '",Status: "' + Status + '",TransType: "' + TransType + '",PaymntRecptId: "' + PaymntReceiptId + '"}',
                            dataType: "json",
                            success: function (data) {
                                var ReopenSts = data.d[0];
                                $(window).scrollTop(0);
                                var SucessDetails = ReopenSts;
                                if (SucessDetails != "Rejected" && SucessDetails != "Paid" && SucessDetails != "failed" && SucessDetails != "Payment" && SucessDetails != "CnclReject") {

                                    if (Status == "1") {
                                        if (PaymntReceiptId != "") {
                                            if (TransType == "0") {
                                                window.location.href = "/FMS/FMS_Master/fms_Payment_Account/fms_Payment_Account.aspx?Id=" + SucessDetails;
                                            }
                                            else {
                                                window.location.href = "/FMS/FMS_Master/fms_Receipt_Account/fms_Receipt_Account.aspx?Id=" + SucessDetails;
                                            }
                                        }
                                        else {
                                            if (TransType == "0") {
                                                $("#success-alert").html("Payment voucher generated successfully with <b>REF# : <font size=\"3\">" + data.d[2] + "</font><b>");
                                                $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                                                });
                                            }
                                            else {
                                                $("#success-alert").html("Receipt voucher generated successfully with <b>REF# : <font size=\"3\">" + data.d[2] + "</font><b>");
                                                $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                                                });
                                            }
                                            document.getElementById("tdPaymntRecptId" + ChequeBkId).value = SucessDetails;

                                            document.getElementById("btnChequeReject" + ChequeBkId).disabled = true;
                                            document.getElementById("btnGen" + ChequeBkId).disabled = true;
                                            document.getElementById("btnChequePaid" + ChequeBkId).disabled = false;
                                        }
                                    }
                                    else if (Status == "2") {
                                        $('#rowPst' + ChequeBkId).remove();
                                        UpdNotfCnt(Mode);
                                        $("#success-alert").html("Postdated cheque is rejected successfully.");
                                        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                                        });
                                    }
                                }
                                else if (SucessDetails == "Rejected") {
                                    $('#rowPst' + ChequeBkId).remove();
                                    UpdNotfCnt(Mode);
                                    $("#divWarning").html("Cheque is already rejected!.");
                                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                    });
                                }
                                else if (SucessDetails == "Paid") {
                                    $('#rowPst' + ChequeBkId).remove();
                                    UpdNotfCnt(Mode);
                                    $("#divWarning").html("Cheque is already Paid!.");
                                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                    });
                                }
                                else if (SucessDetails == "Payment") {
                                    if (Mode == "0") {
                                        $("#divWarning").html("Payment voucher is already generated!.");
                                    }
                                    else {
                                        $("#divWarning").html("Receipt voucher is already generated!.");
                                    }
                                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                    });


                                    document.getElementById("tdPaymntRecptId" + ChequeBkId).value = data.d[1];
                                    document.getElementById("btnChequeReject" + ChequeBkId).disabled = true;
                                    document.getElementById("btnGen" + ChequeBkId).disabled = true;
                                    document.getElementById("btnChequePaid" + ChequeBkId).disabled = false;

                                }
                               
                                else {
                                    $("#divWarning").html("Some error occured!.");
                                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                    });
                                }


                            }
                        });
                    }
                }
            });
            return false;
    }
    function UpdNotfCnt(Mode){

        if(Mode=="0"){
            var cnt=  parseInt(document.getElementById("cphMain_payPostNum").innerText);
            cnt=cnt-1;
            if(cnt<=0){
                document.getElementById("cphMain_menu4").style.display = "none";
                
                document.getElementById("btncl").click();
            }
            else{
                document.getElementById("cphMain_payPostNum").innerText=cnt;
            }                                            
        }
        else{
            var cnt=  parseInt(document.getElementById("cphMain_recpPostNum").innerText);
            cnt=cnt-1;
            if(cnt<=0){
                document.getElementById("cphMain_menu3").style.display="none";                                              
                document.getElementById("btncl").click();
            }
            else{
                document.getElementById("cphMain_recpPostNum").innerText=cnt;
            }   
        }
        var totCnt=parseInt(document.getElementById("cphMain_sMainNotfCnt").innerText);
        totCnt=totCnt-1;
        if (totCnt <= 0) {
            document.getElementById("cphMain_divMainNotf").style.display = "none";
        }
        else {
            document.getElementById("cphMain_sMainNotfCnt").innerText = totCnt;
        }
    }



    //EVM 040 start
    function Sales() {
        var corpid = '<%= Session["CORPOFFICEID"] %>';
        var orgid = '<%= Session["ORGID"] %>';
        var financeid = '<%=Session["FINCYRID"]%>';
        var currencyid = '<%=Session["CRNCMSTID"]%>';
        $.ajax({
            type: "POST",
            async: false,
            url: "Compzit_Home_Finance.aspx/LoadSalesTotal",
            data: '{intorgid:"' + orgid + '" ,intCorporateOfficeID:"' + corpid + '",intFinancialYrId:"' + financeid + '",intCurrencyId:"' + currencyid + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.d != "") {
                    document.getElementById("sales_abbrv").innerText = response.d[0];
                    document.getElementById("salestotal").innerText = response.d[1];
                }

            }
        });
        return false;
    }
    function Purchase() {
        var corpid = '<%= Session["CORPOFFICEID"] %>';
        var orgid = '<%= Session["ORGID"] %>';
        var financeid = '<%=Session["FINCYRID"]%>';
        var currencyid = '<%=Session["CRNCMSTID"]%>';
        //alert(corpid + "-" + orgid + "-" + financeid + "-" + currencyid);


        $.ajax({
            type: "POST",
            async: false,
            url: "Compzit_Home_Finance.aspx/LoadPurchaseTotal",
            data: '{intorgid:"' + orgid + '" ,intCorporateOfficeID:"' + corpid + '",intFinancialYrId:"' + financeid + '",intCurrencyId:"' + currencyid + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.d != "") {
                    //alert(response.d[1]);
                    // document.getElementById("dispCurrency").innerText = response.d[1];
                    document.getElementById("purchase_abbrv").innerText = response.d[0];
                    document.getElementById("purchasetotal").innerText = response.d[1];

                }

            }
        });
        return false;
    }

    function showFinYearr(FINCYR_ID) {
        if (FINCYR_ID != 0) {

            document.getElementById("fincyr").innerText = "FINANCIAL YEAR :   " + FINCYR_ID;
        }
    }
    //EVM 040 END

    //emp-0043 start
    function ProfitLoss() {

        var corpid = '<%= Session["CORPOFFICEID"] %>';
        var orgid = '<%= Session["ORGID"] %>';
        var financeid = '<%=Session["FINCYRID"]%>';
        var currencyid = '<%=Session["CRNCMSTID"]%>';
        var ShowZero = 0;


        $.ajax({
            type: "POST",
            async: false,
            url: "Compzit_Home_Finance.aspx/LoadProfitLoss",
            data: '{intshowZerosts:"' + ShowZero + '",intorgid:"' + orgid + '" ,intCorporateOfficeID:"' + corpid + '",intFinancialYrId:"' + financeid + '",intCurrencyId:"' + currencyid + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.d != "") {

                    document.getElementById("dispCurrency").innerText = "Amount in " + response.d[0];
                    document.getElementById("dispAmount").innerText = response.d[1];
                    document.getElementById("dispProfit").innerText = response.d[2];
                    if (response.d[3] = 0) {
                        document.getElementById("dispstatus").style.display = "none";
                    }
                }
            }
        });
        return false;
    }
    //end


</script>
</asp:Content>

