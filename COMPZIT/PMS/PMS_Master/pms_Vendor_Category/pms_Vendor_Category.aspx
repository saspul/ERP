<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="pms_Vendor_Category.aspx.cs" Inherits="PMS_PMS_Master_pms_Vendor_Category_pms_Vendor_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/js/Common/Common.js"></script>
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

        var $noCon = jQuery.noConflict();

        function ValidateVendorCategory() {
            var ret = true;
            var Category = document.getElementById("<%=txtCategory.ClientID%>").value.trim();
            var Code = document.getElementById("<%=txtCategoryCode.ClientID%>").value.trim();
            document.getElementById("<%=txtCategoryCode.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCategory.ClientID%>").style.borderColor = "";


            if (Code == "") {
                document.getElementById("<%=txtCategoryCode.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCategoryCode.ClientID%>").focus();
                ret = false;
            }
            if (Category == "") {
                document.getElementById("<%=txtCategory.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCategory.ClientID%>").focus();
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
                        window.location.href = "pms_Vendor_Category.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "pms_Vendor_Category.aspx";
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
                        window.location.href = "pms_VendorCategoryList.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "pms_VendorCategoryList.aspx";
            }
        }

        function SuccessInsert() {
            $noCon("#success-alert").html("Vendor category inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function SuccessUpdation() {
            $noCon("#success-alert").html("Vender category updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function DuplicationMsg() {
            document.getElementById("<%=txtCategory.ClientID%>").style.borderColor = "Red";
            $noCon("#divWarning").html("Duplication error! Vendor category cannot be duplicated.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Pms.aspx">Procurement Management</a></li>
        <li><a href="pms_VendorCategoryList.aspx">Vendor Category</a></li>
        <li class="active">Add Vendor category</li>
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
                        <asp:Label ID="lblEntry" runat="server"> Add Account Group</asp:Label></h2>
                </div>

                <div class="form-group fg4">
                    <label for="email" class="fg2_la1">Vendor Category:<span class="spn1">*</span></label>
                    <asp:TextBox ID="txtCategory" runat="server" autocomplete="off" MaxLength="100" class="form-control fg2_inp1 fg_chs1 inp_mst" onkeydown="return  IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" onkeyup="textCounter(cphMain_txtCategory,100)" Style=""></asp:TextBox>
                </div>

                <div class="form-group fg4">
                    <label for="email" class="fg2_la1">Vendor Category Code:<span class="spn1">*</span></label>

                    <asp:TextBox ID="txtCategoryCode" runat="server" autocomplete="off" MaxLength="50" class="form-control fg2_inp1 fg_chs1 inp_mst" onkeydown="return  IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" onkeyup="textCounter(cphMain_txtCategoryCode,50)"></asp:TextBox>
                </div>

                <div class="form-group fg2 fg2_mr">
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
                        <asp:Button ID="btnsave" runat="server" OnClientClick="return ValidateVendorCategory();" class="btn sub1" Text="Save" OnClick="btnsave_Click" />
                        <asp:Button ID="btnsaveAndClose" runat="server" OnClientClick="return ValidateVendorCategory();" class="btn sub3" Text="Save & Close" OnClick="btnsave_Click" />
                        <asp:Button ID="btnUpdate" runat="server" OnClientClick="return ValidateVendorCategory();" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnUpdateAndClose" runat="server" OnClientClick="return ValidateVendorCategory();" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" />
                        <input type="button" tabindex="10" id="btnCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn sub4" />
                        <asp:Button ID="ButtnClear" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                    </div>
                    <div class="edit_sec">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divList" class="list_b" runat="server" style="cursor: pointer;" onclick="return ConfirmMessage()" title="Back to List">
        <i class="fa fa-arrow-circle-left"></i>
    </div>
</asp:Content>

