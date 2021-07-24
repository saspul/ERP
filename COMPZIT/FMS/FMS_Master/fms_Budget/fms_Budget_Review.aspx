<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Budget_Review.aspx.cs" Inherits="FMS_FMS_Master_fms_Budget_fms_Budget_Review" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>

    
    <script>
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
            return false;
        }
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            ShowDtls(null,'JAN', '01');
        });
        function SuccessMsg() {
            $noCon("#success-alert").html("Review submitted successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function AlrdySub() {
            $noCon("#divWarning").html("Review already submitted.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function ConfirmMessage() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Budget_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
            }
            else {
                window.location.href = "fms_Budget_List.aspx";
            }
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenupd" runat="server" />
    <asp:HiddenField ID="HiddenFieldBudjetId" runat="server" />
    <asp:HiddenField ID="HiddenFieldDecimalCnt" runat="server" />
    <asp:HiddenField ID="HiddenFieldTableId" runat="server" />
    <asp:HiddenField ID="HiddenFieldBudgtDataLedgr" runat="server" />
    <asp:HiddenField ID="HiddenFieldCurrMnth" runat="server" />
    <asp:HiddenField ID="HiddenFieldBdgtsubmitSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldBdgtsubmitStsCost" runat="server" />


    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li><a href="fms_Budget_List.aspx">Monthly Budgeting List</a></li>
        <li class="active">Monthly Budgeting-Review</li>
    </ol>

    <div class="myAlert-bottom alert alert-danger" id="divWarning" style="display: none">
        <button type="button" class="close" data-dismiss="alert">x</button>
    </div>
    <div class="myAlert-top alert alert-success" id="success-alert" style="display: none">
        <button type="button" class="close" data-dismiss="alert">x</button>
    </div>

    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">
            <div class="content_box1 cont_contr">
                <h2>
                    <asp:Label ID="lblEntry" runat="server"> </asp:Label>
                </h2>

                <div class="form-group fg2">
                    <label for="email" class="fg2_la1">Budget Name<span class="spn1">*</span>:</label>
                    <input class="form-control fg2_inp1 fg_chs1" id="txtBudgtName" onkeypress="return isTag(event)" onkeydown="return isTag(event)" type="text" runat="server" style="text-transform: uppercase;" maxlength="100" />
                </div>

                <div class="form-group fg2">
                    <label for="email" class="fg2_la1">Year<span class="spn1">*</span>:</label>
                    <input class="form-control fg2_inp1 fg_chs1" id="ddlMainCostCenter" onkeypress="return isTag(event)" onkeydown="return isTag(event)" type="text" runat="server" style="text-transform: uppercase; display: none;" maxlength="100" />
                    <input class="form-control fg2_inp1 fg_chs1" id="ddlYear" onkeypress="return isTag(event)" onkeydown="return isTag(event)" type="text" runat="server" style="text-transform: uppercase;" maxlength="100" />
                    <select style="display: none;" class="form-control" id="ddlMainCostCenter1" runat="server" onkeypress="return isTag(event)" onkeydown="return isTag(event)">
                    </select>
                </div>


                <div class="form-group fg2">
                    <label for="email" class="fg2_la1">Mode<span class="spn1">*</span>:</label>
                    <input class="form-control fg2_inp1 fg_chs1" id="ddlMode" onkeypress="return isTag(event)" onkeydown="return isTag(event)" type="text" runat="server" style="text-transform: uppercase;" maxlength="100" />
                </div>

                <div class="form-group fg2">
                    <label for="email" class="fg2_la1">Purticular<span class="spn1">*</span>:</label>
                    <select class="form-control fg2_inp1 fg_chs1 i" id="ddlParticularType" runat="server" onchange="cahngeType();" onkeypress="return isTag(event)" onkeydown="return isTag(event)">
                        <option value="0">Ledger</option>
                        <option value="1">Cost Center</option>
                    </select>
                </div>
                <div class="clearfix"></div>
                <div class="devider divid"></div>

                
                        <div class="">

                            <div class="tab_1" id="myTab"   runat="server">
                            </div>
                            <div class="tab_1content" style="display:block;">
                                <table class="table table-bordered" id="tabMain">
                                    <thead class="thead1">
                                        <tr>
                                            <th class="col-md-3 t_r">Particular</th>
                                            <th class="col-md-2 t_r">Budgeted Amount</th>
                                            <th class="col-md-2 t_r">Actual Amount</th>
                                            <th class="col-md-2 t_r">Variance</th>
                                            <th class="col-md-3 tr_l">Reason </th>
                                        </tr>
                                    </thead>
                                    <tbody id="tabMainBody" runat="server">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                <div class="clearfix"></div>
                <div class="free_sp"></div>
               
                <div class="sub_cont pull-right">
                    <div class="save_sec">
                        <asp:Button ID="bttnsave" runat="server" OnClientClick="return ValidateBudgt(this);" OnClick="bttnsave_Click" class="btn sub1" Text="Submit" />
                        <asp:Button ID="btnCancel" runat="server" OnClientClick="return ConfirmMessage();" class="btn sub4" Text="Cancel" />

                    </div>
                </div>
                <div id="divList" class="list_b" runat="server" style="cursor: pointer;" onclick="return ConfirmMessage()" title="Back to List">
                    <i class="fa fa-arrow-circle-left"></i>
                </div>
            </div>
      

    <script>
       
        //function openmnth(evt, cityName) {
        //    var i, tabcontent, tablinks;
        //    tabcontent = document.getElementsByClassName("tab_1content");
        //    for (i = 0; i < tabcontent.length; i++) {
        //        tabcontent[i].style.display = "none";
        //    }
        //    tablinks = document.getElementsByClassName("tablinks");
        //    for (i = 0; i < tablinks.length; i++) {
        //        tablinks[i].className = tablinks[i].className.replace(" active", "");
        //    }
        //    document.getElementById(cityName).style.display = "block";
        //    evt.currentTarget.className += " active";
        //}

        // Get the element with id="defaultOpen" and click on it
       

        // Get the element with id="defaultOpen" and click on it
      

        function ValidateBudgt(ClickedBtn) {
            var ret = true;
            document.getElementById("<%=HiddenFieldBudgtDataLedgr.ClientID%>").value = "";         
            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];
            var tableOtherItem = document.getElementById("tabMain");
            for (var i = tableOtherItem.rows.length - 1; i > 0; i--) {
                var validRowID = (tableOtherItem.rows[i].cells[0].innerHTML);
                var LedgrTabId = (tableOtherItem.rows[i].cells[1].innerHTML);
                var LedgrReasn = document.getElementById("txtReason" + validRowID).value.trim();               
                var $add = jQuery.noConflict();
                var client = JSON.stringify({
                    LEDGRTABID: "" + LedgrTabId + "",
                    LEDGRREASN: "" + LedgrReasn + ""
                });
                tbClientJobSheduling.push(client);            
            }
            $add("#cphMain_HiddenFieldBudgtDataLedgr").val(JSON.stringify(tbClientJobSheduling));
            return true;
        }
        function isTag(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }

        function ShowDtls(evt, mnth, FullMnth) {
         
            document.getElementById("<%=HiddenFieldCurrMnth.ClientID%>").value = mnth;         
            document.getElementById("<%=HiddenFieldTableId.ClientID%>").value = mnth+"-"+FullMnth;
            var BudgtId = document.getElementById("<%=HiddenFieldBudjetId.ClientID%>").value;
            var year = document.getElementById("cphMain_ddlMainCostCenter").value;
            var mode = document.getElementById("cphMain_ddlMode").value;
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var FloatingValueMoney = document.getElementById("<%=HiddenFieldDecimalCnt.ClientID%>").value;
            var Type = document.getElementById("cphMain_ddlParticularType").value;

           
            //document.getElementById(mnth).style.display = "block";
            if (evt != null) {
                tablinks = document.getElementsByClassName("tablinks");
                for (i = 0; i < tablinks.length; i++) {
                    tablinks[i].className = tablinks[i].className.replace(" active", "");

                }
                evt.currentTarget.className += " active";
            }
           
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "fms_Budget_Review.aspx/ShowMnthDtls",
                data: '{BudgtId: "' + BudgtId + '",mnth: "' + mnth + '",FullMnth: "' + FullMnth + '",year: "' + year + '",mode: "' + mode + '",orgID: "' + orgID + '",corptID: "' + corptID + '",FloatingValueMoney: "' + FloatingValueMoney + '",Type: "' + Type + '"}',
                dataType: "json",
                success: function (data) {
                    document.getElementById("cphMain_tabMainBody").innerHTML = data.d;
                    var str = "";
                    if (document.getElementById("cphMain_ddlParticularType").value == "0") {
                         str = document.getElementById("<%=HiddenFieldBdgtsubmitSts.ClientID%>").value;
                    }
                    else {
                         str = document.getElementById("<%=HiddenFieldBdgtsubmitStsCost.ClientID%>").value;
                    }
                    var n = str.includes(mnth);
                    if (n == true || $("#tdNoData").length>0) {
                        document.getElementById("cphMain_bttnsave").style.visibility = "hidden";
                        $("#cphMain_tabMainBody :input").attr("disabled", true);
                    }
                    else {
                        document.getElementById("cphMain_bttnsave").style.visibility = "visible";
                    }
                }
            });
        }
        function cahngeType(){
            var objVal = document.getElementById("<%=HiddenFieldTableId.ClientID%>").value;
            var objValArr = objVal.split('-');
            ShowDtls(null,objValArr[0], objValArr[1]);
        }     
       </script>
</asp:Content>

