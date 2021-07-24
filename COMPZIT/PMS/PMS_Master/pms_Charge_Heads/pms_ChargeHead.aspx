<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="pms_ChargeHead.aspx.cs" Inherits="PMS_PMS_Master_pms_Charge_Heads_pms_ChargeHead" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/js/New%20js/js/select2.min.js"></script>
    <link href="/css/New%20css/select2.min.css" rel="stylesheet" />
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/js/Common/Common.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <style>
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
    </style>

    <script>

        confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }

        function DisableEnter(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }

        $(document).ready(function () {
            var CatID = document.getElementById("<%=hiddenCHCategory.ClientID%>").value;
            var CatIDString = CatID;
            eachString = CatIDString.split(',');
            var newVar = new Array();
            for (count = 0; count < eachString.length; count++) {
                if (eachString[count] != "") {
                    newVar.push(eachString[count]);
                    $("#<%= ddlCategory.ClientID %>").each(function () {
                               $('option', this).each(function () {
                                   if ($(this).val() == eachString[count]) {
                                       $(this).attr('selected', 'selected')
                                   };
                               });
                           });
                            //SORTING DDL
                           var options = $("#<%=ddlCategory.ClientID%> option");
                            options.detach().sort(function (a, b) {
                                var at = $(a).text();
                                var bt = $(b).text();
                                return (at > bt) ? 1 : ((at < bt) ? -1 : 0);
                            });
                            options.appendTo('#<%=ddlCategory.ClientID%>');
                    }
                }

            $('#cphMain_ddlCountry').val(newVar);
            $("#cphMain_ddlCountry").trigger("change");
        });

            var $noCon = jQuery.noConflict();

            function ValidateChargeHead() {

                var ret = true;

                var ddlCntryIdvalues;
                var sel = "";

                var ddlCntryIdvalues;
                var sel = "";

                ddlCntryIdvalues = $('#cphMain_ddlCategory').val();
                $("#cphMain_ddlCategory option:selected").each(function () {
                    var $this = $(this);
                    if ($this.length) {
                        var selText = $this.val();
                        sel = sel + selText + ",";
                        //alert(sel);
                        document.getElementById("<%=hiddenCHCategory.ClientID%>").value = sel;
                }
            });


            var chargeHead = document.getElementById("<%=txtChargeHead.ClientID%>").value.trim();
            var Code = document.getElementById("<%=txtChargeHeadCode.ClientID%>").value.trim();
            var Category = document.getElementById("<%=ddlCategory.ClientID%>").value.trim();

            var CalculationMethod = document.getElementById("<%=ddlCalcultnMethod.ClientID%>").value.trim();
            document.getElementById("<%=txtChargeHeadCode.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtChargeHead.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlCategory.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlCalcultnMethod.ClientID%>").style.borderColor = "";
            $('.select2-selection').css('border-color', 'none');


            if (CalculationMethod == "") {
                document.getElementById("<%=ddlCategory.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlCategory.ClientID%>").focus();
                ret = false;
            }

            if (Category == "") {


                $('.select2-selection').css('border-color', 'red');
                document.getElementById("<%=ddlCategory.ClientID%>").focus();
                ret = false;
            }
            if (Code == "") {
                document.getElementById("<%=txtChargeHeadCode.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtChargeHeadCode.ClientID%>").focus();
                ret = false;
            }
            if (chargeHead == "") {
                document.getElementById("<%=txtChargeHead.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtChargeHead.ClientID%>").focus();
                ret = false;
            }
            if (ret == false) {
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $noCon(window).scrollTop(0);
            }

            return ret;
        }


        function AlertClearAll() {

            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want clear all data in this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "pms_ChargeHead.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "pms_ChargeHead.aspx";
            }

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
                        window.location.href = "pms_ChargeHeadList.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "pms_ChargeHeadList.aspx";
            }
        }

        function SuccessInsert() {
            $noCon("#success-alert").html("Charge head inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function SuccessUpdation() {
            $noCon("#success-alert").html("Charge head updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function DuplicationMsg() {
            document.getElementById("<%=txtChargeHead.ClientID%>").style.borderColor = "Red";
            $noCon("#divWarning").html("Duplication error! Charge head cannot be duplicated.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:HiddenField ID="hiddenCHCategory" runat="server" />
    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Pms.aspx">Procurement Management</a></li>
        <li><a href="pms_ChargeHeadList.aspx">Charge Heads</a></li>
        <li class="active">Add Charge Head</li>
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
            <div class="content_box1 cont_contr">
                <div id="divReportCaption" runat="server">
                    <h2>
                        <asp:Label ID="lblEntry" runat="server"> Add Charge Head</asp:Label></h2>
                </div>
                <div class="form-group fg5 ">
                    <label for="email" class="fg2_la1">Charge Name:<span class="spn1">*</span></label>
                    <asp:TextBox ID="txtChargeHead" runat="server" autocomplete="off" MaxLength="100" class="form-control fg2_inp1 fg_chs1 inp_mst" onkeydown="return  IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" onkeyup="textCounter(cphMain_txtChargeHead,100)" Style=""></asp:TextBox>
                </div>
                <div class="form-group fg5 fg2_a">
                    <label for="email" class="fg2_la1">Charge Code:<span class="spn1">*</span></label>
                    <asp:TextBox ID="txtChargeHeadCode" runat="server" autocomplete="off" MaxLength="50" class="form-control fg2_inp1 fg_chs1 inp_mst" onkeydown="return  IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" onkeyup="textCounter(cphMain_txtChargeHeadCode,50)"></asp:TextBox>
                </div>

                <div class="form-group fg2 fg4_a">
                    <label for="email" class="fg2_la1">Charge Category:<span class="spn1">*</span></label>
                    <div id="divCategory">
                        <asp:DropDownList multiple ID="ddlCategory" Style=""   class="form-control fg2_inp1 fg_chs1 inp_mst" runat="server" onkeypress="return DisableEnter(event)" >
                         </asp:DropDownList>

                    </div>
                </div>
                <div class="form-group fg5 fg2_a">
                    <label for="email" class="fg2_la1">Calculation Method:<span class="spn1">*</span></label>
                    <asp:DropDownList ID="ddlCalcultnMethod" class="form-control fg2_inp1 fg_chs1 inp_mst" runat="server" onkeypress="return DisableEnter(event)" Style="">
                        <asp:ListItem Text="Addition" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Deduction" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group fg7 fg5_mr">
                    <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
                    <div class="check1">
                        <div class="">
                            <label class="switch">
                                <input type="checkbox" runat="server" checked="checked" onkeypress="return DisableEnter(event)" id="ChkStatus" />
                                <span class="slider_tog round"></span>
                            </label>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="free_sp"></div>

                <div class="ssub_cont pull-right">
                    <div class="save_sec">
                        <asp:Button ID="btnsave" runat="server" OnClientClick="return ValidateChargeHead();" class="btn sub1" Text="Save" OnClick="btnsave_Click" />
                        <asp:Button ID="btnsaveAndClose" runat="server" OnClientClick="return ValidateChargeHead();" class="btn sub3" Text="Save & Close" OnClick="btnsave_Click" />
                        <asp:Button ID="btnUpdate" runat="server" OnClientClick="return ValidateChargeHead();" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnUpdateAndClose" runat="server" OnClientClick="return ValidateChargeHead();" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" />
                        <input type="button" tabindex="10" id="btnCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn sub4" />
                        <asp:Button ID="ButtnClear" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                    </div>
                    <div class="edit_sec">
                    </div>
                </div>
            </div>
        </div>
    </div>

 
            <div id="divList" class="list_b" style="cursor: pointer;" onclick="return ConfirmMessage()" title="Back to List">
            <i class="fa fa-arrow-circle-left"></i>
        </div>

       <script type="text/javascript">
        
           $("#cphMain_ddlCategory").select2();
           $("#checkbox").click(function () {
               if ($("#checkbox").is(':checked')) {
                   $("#cphMain_ddlCategory > option").prop("selected", "selected");
                   $("#cphMain_ddlCategory").trigger("change");
               } else {
                   $("#cphMain_ddlCategory > option").removeAttr("selected");
                   $("#cphMain_ddlCategory").trigger("change");
               }
           });
   
</script>
    
</asp:Content>

